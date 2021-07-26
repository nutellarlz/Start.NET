' 
' 
'            _____ _             _     _   _ ______ _______ 
'           / ____| |           | |   | \ | |  ____|__   __|
'          | (___ | |_ __ _ _ __| |_  |  \| | |__     | |   
'           \___ \| __/ _` | '__| __| | . ` |  __|    | |   
'           ____) | || (_| | |  | |_ _| |\  | |____   | |   
'          |_____/ \__\__,_|_|   \__(_)_| \_|______|  |_|   
' 
'                 Copyright © 2021 Josiah Horton
' 
' This is what remains of the first iteration of the Start.NET Start Menu...
' I was first developing it using WinForms which I now see was a mistake...
' If someone want's to pick up where I left off, what's wrong with you?
' Also, this can be done.  It actually may be relatively easy to finish the
' legacy WinForms SDN Start Menu, but I think it will be a fruitless endevour
' as the WPF version has far mor potential in my opinion.  Nevertheless, I
' shall not be the one to stop you from expending your own energy on this.  I
' commend you for your spirit.  I wish you the best.
' 
' 

Imports System.IO


Public Class Form1

    Dim path As String
    Dim nextPath As String
    Dim fileName As String
    Dim proc As New System.Diagnostics.Process()
    Dim pinnedStart As String
    Dim pinnedView As Boolean

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)
        MyBase.Top = Screen.PrimaryScreen.WorkingArea.Bottom - Me.Height
        MyBase.Left = Screen.PrimaryScreen.WorkingArea.Left
        searchTextBox.Text = "Search programs and files"
        btnUser.Text = Environ("USERNAME")
        btnProfile.BackgroundImage = GetUserTile(Environ("USERNAME"))
        pinnedStart = "C:\ProgramData\Microsoft\Windows\Start Menu\Programs\"
        pinnedView = True


        'path = "C:\Documents and Settings\Administrator\Start Menu\Programs\"
        'path = "C:\ProgramData\Microsoft\Windows\Start Menu\Programs\"
        'path = Environ("USERPROFILE") + "\Start Menu\"

        If My.Computer.Info.OSVersion.StartsWith(5) Then
            pinnedStart = Environ("USERPROFILE") + "\Start Menu\"
            path = pinnedStart
        Else
            'path = Environ("ALLUSERSPROFILE") + "\Microsoft\Windows\Start Menu\Programs\"
            If My.Computer.FileSystem.DirectoryExists(Environ("USERPROFILE") + "\SDN Start Menu\") Then
                'path = Environ("ALLUSERSPROFILE") + "\Microsoft\Windows\Start Menu\Programs\"
                If My.Computer.FileSystem.FileExists(Environ("USERPROFILE") + "\SDN Start Menu\Explorer.lnk") Then
                    pinnedStart = Environ("USERPROFILE") + "\SDN Start Menu\"
                    path = pinnedStart
                Else
                    pinnedStart = Environ("USERPROFILE") + "\SDN Start Menu\"
                    CreateShortCut(Environ("SystemRoot") + "\Explorer.exe", pinnedStart, "Explorer")
                    path = pinnedStart
                End If

            Else
                My.Computer.FileSystem.CreateDirectory(Environ("USERPROFILE") + "\SDN Start Menu\")
                pinnedStart = Environ("USERPROFILE") + "\SDN Start Menu\"
                path = pinnedStart
            End If
        End If


        For Each i In My.Computer.FileSystem.GetFiles(pinnedStart)
            mainMenuList.Items.Add(i.Substring(i.LastIndexOf("\") + 1), ImageList1.Images.Count() - 1)
        Next

    End Sub

    Private Sub Form1_LostFocus(sender As Object, e As EventArgs) Handles Me.LostFocus
        Me.Close()
    End Sub

    Private Function CreateShortCut(ByVal TargetName As String, ByVal ShortCutPath As String, ByVal ShortCutName As String) As Boolean
        Dim oShell As Object
        Dim oLink As Object
        'you don’t need to import anything in the project reference to create the Shell Object

        Try

            oShell = CreateObject("WScript.Shell")
            oLink = oShell.CreateShortcut(ShortCutPath & "\" & ShortCutName & ".lnk")

            oLink.TargetPath = TargetName
            oLink.WindowStyle = 1
            oLink.Save()
        Catch ex As Exception

        End Try

    End Function

    ' clearing the search box when clicked
    Private Sub searchTextBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles searchTextBox.GotFocus
        searchTextBox.Text = ""
    End Sub

    ' re-adding the hint text to the search box when focus is lost
    Private Sub searchTextBox_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles searchTextBox.LostFocus
        searchTextBox.Text = "Search programs and files"
    End Sub

    Private Sub mainMenuList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles mainMenuList.SelectedIndexChanged
        nextPath = path + "\" + mainMenuList.FocusedItem.Text
        fileName = mainMenuList.FocusedItem.Text
    End Sub

    Private Sub mainMenuList_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles mainMenuList.MouseDoubleClick
        If My.Computer.FileSystem.FileExists(nextPath) Then
            Diagnostics.Process.Start(path + "\" + fileName)
            Me.Close()
        ElseIf My.Computer.FileSystem.DirectoryExists(nextPath) Then
            'Diagnostics.Process.Start(path + "\" + fileName)
            'Me.Close()
            path = nextPath
            mainMenuList.Clear()
            'mainMenuList.Items.Add()
            For Each i In My.Computer.FileSystem.GetDirectories(path)
                mainMenuList.Items.Add(i.Substring(i.LastIndexOf("\") + 1), ImageList1.Images.Count() - 2)
            Next
            For Each i In My.Computer.FileSystem.GetDirectories(path)
                mainMenuList.Items.Add(i.Substring(i.LastIndexOf("\") + 1), ImageList1.Images.Count() - 1)
            Next
        Else
            Diagnostics.Process.Start(path + "\" + fileName)

        End If
        'proc = Process.Start(nextPath + fileName, "")
    End Sub

    Private Sub btnUser_Click(sender As Object, e As EventArgs) Handles btnUser.Click
        Diagnostics.Process.Start(Environ("USERPROFILE"))
        Me.Close()
    End Sub

    Private Sub btnDocuments_Click(sender As Object, e As EventArgs) Handles btnDocuments.Click
        Diagnostics.Process.Start(Environ("USERPROFILE") + "\Documents")
        Me.Close()
    End Sub

    Private Sub btnPictures_Click(sender As Object, e As EventArgs) Handles btnPictures.Click
        Diagnostics.Process.Start(Environ("USERPROFILE") + "\Pictures")
        Me.Close()
    End Sub

    Private Sub btnMusic_Click(sender As Object, e As EventArgs) Handles btnMusic.Click
        Diagnostics.Process.Start(Environ("USERPROFILE") + "\Music")
        Me.Close()
    End Sub

    Private Sub btnComputer_Click(sender As Object, e As EventArgs) Handles btnComputer.Click
        'Diagnostics.Process.Start("C:\")
        Diagnostics.Process.Start(Environ("SystemDrive"))
        Me.Close()
    End Sub

    Private Sub btnControlPanel_Click(sender As Object, e As EventArgs) Handles btnControlPanel.Click
        Diagnostics.Process.Start("control")
        'Diagnostics.Process.Start(Environ("SYSTEMROOT") + "\system32\control.exe")
        Me.Close()
    End Sub

    Private Sub btnPowerOptions_Click(sender As Object, e As EventArgs)
        powerMenu.Show()
    End Sub

    Private Sub powerMenu_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles powerMenu.Opening

    End Sub

    Private Sub btnProfile_Click(sender As Object, e As EventArgs) Handles btnProfile.Click
        Shell("control userpasswords")
        Me.Close()
    End Sub

    Private Sub btnTaskbarSettings_Click(sender As Object, e As EventArgs) Handles btnTaskbarSettings.Click
        Shell("rundll32.exe shell32.dll,Options_RunDLL 1")
        Me.Close()
    End Sub

    Private Sub btnShowAll_Click(sender As Object, e As EventArgs) Handles btnShowAll.Click
        If pinnedView = True Then
            mainMenuList.View = View.List
            path = Environ("ALLUSERSPROFILE") + "\Microsoft\Windows\Start Menu\Programs\"
            mainMenuList.Clear()
            'mainMenuList.Items.Add()
            For Each i In My.Computer.FileSystem.GetDirectories(path)
                mainMenuList.Items.Add(i.Substring(i.LastIndexOf("\") + 1), ImageList1.Images.Count() - 2)
            Next
            For Each i In My.Computer.FileSystem.GetFiles(path)
                mainMenuList.Items.Add(i.Substring(i.LastIndexOf("\") + 1), ImageList1.Images.Count() - 1)
            Next
            pinnedView = False
        Else
            mainMenuList.View = View.Tile
            mainMenuList.Clear()
            'mainMenuList.Items.Add()
            path = pinnedStart
            For Each i In My.Computer.FileSystem.GetFiles(pinnedStart)
                mainMenuList.Items.Add(i.Substring(i.LastIndexOf("\") + 1), ImageList1.Images.Count() - 1)
            Next
            pinnedView = True
        End If
    End Sub
End Class