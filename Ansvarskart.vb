﻿Public Class Ansvarskart

    Public app As New Mindjet.MindManager.Interop.Application
    Public currentDocument As Mindjet.MindManager.Interop.Document
    Public lstNames As New List(Of String)
    Const strMainFolder = "C:\Users\knjetl\Dropbox\Geodataseksjonen\PrPerson\"


    Sub initMM()
        currentDocument = app.ActiveDocument
    End Sub



    Private Sub Ansvarskart_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initMM()
        txtMMdoc.Text = currentDocument.FullName

    End Sub

    Sub PersonLoop(strProcess As String, Optional strName As String = "")
        currentDocument.Filter.RevealFilteredTopics()
        Dim mainTopic As Mindjet.MindManager.Interop.Topic
        mainTopic = currentDocument.CentralTopic
        mainTopic.Filtered = False

        'Fagområde - skal alltid vises
        Dim fagTopic As Mindjet.MindManager.Interop.Topic
        For Each fagTopic In mainTopic.AllSubTopics
            If InStr(fagTopic.Text, "Dataforvaltning") <> 0 Then
                fagTopic.Filtered = False
                'Driftsoppgaver/Utviklingsoppgaver - skal alltid vises
                Dim duTopic As Mindjet.MindManager.Interop.Topic
                For Each duTopic In fagTopic.AllSubTopics
                    duTopic.Filtered = False
                    'Ansvarsområder/Prosjektgrupperinger skal alltid vises
                    Dim ansvTopic As Mindjet.MindManager.Interop.Topic
                    For Each ansvTopic In duTopic.AllSubTopics
                        ansvTopic.Filtered = False
                        'Herfra og ned vises de elementene en person tilhører, med søsken på laveste nivå
                        Dim taskTopic As Mindjet.MindManager.Interop.Topic
                        For Each taskTopic In ansvTopic.AllSubTopics
                            Select Case strProcess
                                Case "nameList"
                                    'MsgBox(taskTopic.Text)
                                    nameList(taskTopic)
                                Case "nameFilter"
                                    taskTopic.Filtered = recFilterLoop(taskTopic, strName)
                                    viewSiblings(taskTopic)

                            End Select

                        Next taskTopic
                    Next ansvTopic
                Next duTopic
            Else
                fagTopic.Filtered = True
            End If
        Next fagTopic

        'Eksporter bildefil
        currentDocument.GraphicExport.ExportZoomed(strMainFolder & strName & ".png", Mindjet.MindManager.Interop.MmGraphicType.mmGraphicTypePng, 1)
    End Sub

    Sub nameList(tpc As Mindjet.MindManager.Interop.Topic)
        Dim siblingTpc As Mindjet.MindManager.Interop.Topic
        siblingTpc = tpc

        If siblingTpc.AllSubTopics.Count = 0 Then
            Dim strName As String = siblingTpc.Text
            txtStatus.Text = Now & " Navn: " & strName
            If Not lstNames.Contains(strName) Then lstNames.Add(strName)
        End If

        Dim subTpc As Mindjet.MindManager.Interop.Topic
        For Each subTpc In siblingTpc.AllSubTopics
            nameList(subTpc)
        Next subTpc


    End Sub

    Function recFilterLoop(tpc As Mindjet.MindManager.Interop.Topic, Str As String) As Boolean
        'recursive search and filter topics
        Dim siblingTpc As Mindjet.MindManager.Interop.Topic
        siblingTpc = tpc

        recFilterLoop = True
        If siblingTpc.AllSubTopics.Count = 0 Then
            'Last level - test for string
            If siblingTpc.Text = Str Then
                recFilterLoop = False
                siblingTpc.Font.Bold = True
            Else
                siblingTpc.Font.Bold = False
            End If
        End If

        Dim subTpc As Mindjet.MindManager.Interop.Topic
        For Each subTpc In siblingTpc.AllSubTopics
            subTpc.Filtered = recFilterLoop(subTpc, Str)
            If subTpc.Filtered = False Then
                recFilterLoop = False
            End If
        Next subTpc

    End Function

    Sub viewSiblings(tpc As Mindjet.MindManager.Interop.Topic)
        'recursive loop through topics, view last level siblings

        Dim siblingTpc As Mindjet.MindManager.Interop.Topic
        siblingTpc = tpc

        If siblingTpc.AllSubTopics.Count = 0 Then
            'Last level - view if parent not filtered
            If siblingTpc.ParentTopic.Filtered = False Then siblingTpc.Filtered = False
        End If

        Dim subTpc As Mindjet.MindManager.Interop.Topic
        For Each subTpc In siblingTpc.AllSubTopics
            viewSiblings(subTpc)
        Next subTpc

    End Sub

    Private Sub btnNameList_Click(sender As Object, e As EventArgs) Handles btnNameList.Click
        Me.Cursor = Cursors.WaitCursor
        lbNames.Items.Clear()

        PersonLoop("nameList")
        lstNames.Sort()
        For Each strName As String In lstNames
            lbNames.Items.Add(strName)
        Next
        txtStatus.Text = Now & " Antall navn: " & lbNames.Items.Count

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub btnSelectAll_Click(sender As Object, e As EventArgs) Handles btnSelectAll.Click
        For i As Integer = 0 To lbNames.Items.Count - 1
            lbNames.SetItemChecked(i, True)
        Next
        btnExportPNG.Enabled = True
    End Sub

    Private Sub btnNone_Click(sender As Object, e As EventArgs) Handles btnNone.Click
        For i As Integer = 0 To lbNames.Items.Count - 1
            lbNames.SetItemChecked(i, False)
        Next
        btnExportPNG.Enabled = False
    End Sub

    Private Sub btnExportPNG_Click(sender As Object, e As EventArgs) Handles btnExportPNG.Click
        Dim itemChecked As Object
        Me.Cursor = Cursors.WaitCursor

        For Each itemChecked In lbNames.CheckedItems
            Dim strName As String = itemChecked.ToString
            txtStatus.Text = Now & " Filtrerer og eksporterer png for: " & strName
            PersonLoop("nameFilter", strName)
        Next

        txtStatus.Text = Now & " Fullført eksport av indiviudelle planer for " & lbNames.CheckedItems.Count & " personer"

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub lbNames_SelectedValueChanged(sender As Object, e As EventArgs) Handles lbNames.SelectedValueChanged
        btnExportPNG.Enabled = True

    End Sub

    Private Sub btnNotes_Click(sender As Object, e As EventArgs) Handles btnNotes.Click
        printNotes(currentDocument.CentralTopic)
    End Sub

    Sub printNotes(tpc As Mindjet.MindManager.Interop.Topic)
        Dim siblingTpc As Mindjet.MindManager.Interop.Topic
        siblingTpc = tpc

        'Finn en god datatype for notater
        'Skriv notater til fil, med topic.text & ":" først 

        Dim subTpc As Mindjet.MindManager.Interop.Topic
        For Each subTpc In siblingTpc.AllSubTopics
            printNotes(subTpc)
        Next subTpc


    End Sub
End Class