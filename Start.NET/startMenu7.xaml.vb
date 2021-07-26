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
' Welcome to the Start.NET project!  The purpose of Start.NET is to bring
' the functionality of the more modern Windows Start Menus to older
' systems (and hopefully ReactOS) as well as providing the choice to use
' the older Start Menu options in newer releases.  In addition to this,
' SDN should be able to do this using VB.NET/C# because it's easy to mod
' and it's lightweight.
' 
' 
' This is the Windows 7 style start menu window.
' 
' 

Imports System
Imports System.Collections
Imports System.IO

Public Class startMenu7

    ' I kinda forgot what each of these does...  I'll document them when I remember...
    Dim path As String
    Dim nextPath As String
    Dim fileName As String
    Dim proc As New System.Diagnostics.Process()
    Dim pinnedStart As String
    Dim pinnedView As Boolean

    ' this is the stuff that happens when the start menu loads
    Private Sub startMenu7_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs) Handles Me.Loaded
        ' here we're grabbing the working area we're rendering on because we don't  have
        ' the oh-so-helpful System.Windows.Forms.Screen in WPF
        Dim desktopWorkingArea = System.Windows.SystemParameters.WorkArea
        ' we're moving the start menu to the bottom left
        Me.Left = desktopWorkingArea.Left
        Me.Top = desktopWorkingArea.Bottom - Me.Height

        ' the search box should already have this as the default text, but just in  case
        ' it doesn't have any default text, we have this...
        searchTextBox.Text = "Search programs and files"

        ' now we nee to set the user button's text to the username of whomever's logged
        ' in atm
        btnUser.Content = Environment.GetEnvironmentVariable("UserName")

        ' now we have our wonderful userImage module grab our user image
        Dim bitmapImage As BitmapImage = GetUserTile(Environment.UserName)
        ' let's set the background of our profile button to the user image we just got
        btnProfile.Background = New ImageBrush(bitmapImage)

        ' okay...  there's literally no point in doing this because we're just gonna
        ' write over whatever we set it to...
        pinnedStart = Environment.GetEnvironmentVariable("ALLUSERSPROFILE") + "\Microsoft\Windows\Start Menu\Programs\"
        ' this is important tho...  this is gonna be used to tell if we should be rendering
        ' the pinned items or all items
        pinnedView = True

        ' now we check what version of Windows (or ReactOS) we're running
        If My.Computer.Info.OSVersion.StartsWith(5) Then ' basically Windows XP
            ' the Start Menu folder is perfectly accesible in XP but not after that...
            pinnedStart = Environment.GetEnvironmentVariable("USERPROFILE") + "\Start Menu\Programs"
            ' just keeping track of where we are...
            path = pinnedStart
        Else ' sooooo...  not XP then?
            ' then let's check if we have our custom SDN Start Menu folder
            If My.Computer.FileSystem.DirectoryExists(Environment.GetEnvironmentVariable("USERPROFILE") + "\SDN Start Menu\") Then
                ' now we make sure we've got some pinned items
                If My.Computer.FileSystem.FileExists(Environment.GetEnvironmentVariable("USERPROFILE") + "\SDN Start Menu\Explorer.lnk") Then
                    ' okay!  we're good to go!  set this as our pinned start and move on!
                    pinnedStart = Environment.GetEnvironmentVariable("USERPROFILE") + "\SDN Start Menu\"
                    ' just keeping track of where we are...
                    path = pinnedStart
                Else ' okay...  well then we need to get some pinned items...
                    ' this is our shortcut creator.  I documented how to use it down by
                    ' its code
                    CreateShortCut(Environment.GetEnvironmentVariable("SystemRoot") + "\Explorer.exe", pinnedStart, "Explorer")
                    ' okay!  we're good to go!  set this as our pinned start and move on!
                    pinnedStart = Environment.GetEnvironmentVariable("USERPROFILE") + "\SDN Start Menu\"
                    ' just keeping track of where we are...
                    path = pinnedStart
                End If

            Else ' well this is awkward...  we've got literally nothing
                ' let's create our SDN Start Menu directory
                My.Computer.FileSystem.CreateDirectory(Environment.GetEnvironmentVariable("USERPROFILE") + "\SDN Start Menu\")
                ' this is our shortcut creator.  I documented how to use it down by
                ' its code
                CreateShortCut(Environment.GetEnvironmentVariable("SystemRoot") + "\Explorer.exe", pinnedStart, "Explorer")
                ' okay!  we're good to go!  set this as our pinned start and move on!
                pinnedStart = Environment.GetEnvironmentVariable("USERPROFILE") + "\SDN Start Menu\"
                ' just keeping track of where we are...
                path = pinnedStart
            End If
        End If

        For Each i In My.Computer.FileSystem.GetFiles(pinnedStart)
            ' This calls the renderPinnedItem function and passes each i to it.  All
            ' the rendering is handled by renderPinnedItem so as to not bloat the sub.
            mainMenuList.Items.Add(renderPinnedItem(i))
        Next
    End Sub

    ' I bestow this function with the task of rendering thy pinned start menu items.
    ' He who is pinned shall be rendered, and he who is rendered shall be pinned.
    Private Function renderPinnedItem(ByVal i As String)
        ' shortcutName is the name of the *.lnk file with the *.lnk extension.  This
        ' is used for getting the app name and getting the full path of the shortcut.
        Dim shortcutName = i.Substring(i.LastIndexOf("\") + 1)
        ' set nextPath to the current path and the shortcut name to create the full
        ' path of the shortcut.
        nextPath = path + "\" + shortcutName
        ' create the app name by removing the last 4 chars of the shortcutName (.lnk)
        Dim appName = shortcutName.Substring(0, shortcutName.Length - 4)

        ' create a new startMenuItem to populate with our shortcut data
        Dim startMenuShortcut As New startMenuItem
        ' set the appTitle text to the appName we created earlier
        startMenuShortcut.appTitle.Text = appName
        ' set the shortcutLink to our nextPath
        ' this is important because the startMenuItem will tell the computer to start
        ' a process with this path
        startMenuShortcut.shortcutLink = nextPath
        ' this is probably redundant since everywhere I'm using this I could just as
        ' easily use i
        fileName = i
        ' case in point...  this 👇🏻
        ' icon is going to be our shortcut icon that we're extracting
        Dim icon = Drawing.Icon.ExtractAssociatedIcon(fileName)
        ' now we convert the icon to a bitmap because reasons
        Dim bmp = icon.ToBitmap()

        ' this is ripped straight out of stackoverflow
        ' but the commentary is all mine
        ' this is our memory stream that we'll use to do the little shwoopy shwoop to
        ' make our bitmap a usable image source for the startMenuItem.appIcon
        Dim strm As MemoryStream = New MemoryStream()
        ' this saves our bitmap as a png to our shwoopy shwoop
        bmp.Save(strm, System.Drawing.Imaging.ImageFormat.Png)
        ' now we create a bitmap image because if we've made it this far we might as
        ' well keep complicating things
        Dim bmpImage As BitmapImage = New BitmapImage()
        ' we open our bitmap.  as it opens, our mind races, trying to come to grips
        ' with the power we hold
        bmpImage.BeginInit()
        ' we unsheathe our shwoopy shwoop...
        strm.Seek(0, SeekOrigin.Begin)
        ' and ATTACK!!!
        ' I...  I mean...
        ' adapt...
        bmpImage.StreamSource = strm
        ' we close our bitmap, realizing that no one is worthy of such power
        bmpImage.EndInit()

        ' now we set our startMenuShortcut's appIcon source to our new bitmap that
        ' we've created
        startMenuShortcut.appIcon.Source = bmpImage

        ' let's return all of our har work to whomever called upon us to do it
        Return startMenuShortcut
    End Function

    ' Thy pinned be replaced by all.  For he loved them all so much that he gave
    ' his only begotten pinned.
    Private Function renderAllItem(ByVal i As String)
        ' shortcutName is the name of the *.lnk file with the *.lnk extension.  This
        ' is used for getting the app name and getting the full path of the shortcut.
        Dim shortcutName = i.Substring(i.LastIndexOf("\") + 1)
        ' set nextPath to the current path and the shortcut name to create the full
        ' path of the shortcut.
        nextPath = path + "\" + shortcutName
        ' create the app name by removing the last 4 chars of the shortcutName (.lnk)
        Dim appName = shortcutName.Substring(0, shortcutName.Length - 4)

        ' create a new startMenuItem to populate with our shortcut data
        Dim startMenuShortcut As New searchItemDetails
        ' set the appTitle text to the appName we created earlier
        startMenuShortcut.appTitle.Text = appName
        ' set the shortcutLink to our nextPath
        ' this is important because the startMenuItem will tell the computer to start
        ' a process with this path
        startMenuShortcut.shortcutLink = nextPath
        ' this is probably redundant since everywhere I'm using this I could just as
        ' easily use i
        fileName = i
        ' case in point...  this 👇🏻
        ' icon is going to be our shortcut icon that we're extracting
        Dim icon = Drawing.Icon.ExtractAssociatedIcon(fileName)
        ' now we convert the icon to a bitmap because reasons
        Dim bmp = icon.ToBitmap()

        ' this is ripped straight out of stackoverflow
        ' but the commentary is all mine
        ' this is our memory stream that we'll use to do the little shwoopy shwoop to
        ' make our bitmap a usable image source for the startMenuItem.appIcon
        Dim strm As MemoryStream = New MemoryStream()
        ' this saves our bitmap as a png to our shwoopy shwoop
        bmp.Save(strm, System.Drawing.Imaging.ImageFormat.Png)
        ' now we create a bitmap image because if we've made it this far we might as
        ' well keep complicating things
        Dim bmpImage As BitmapImage = New BitmapImage()
        ' we open our bitmap.  as it opens, our mind races, trying to come to grips
        ' with the power we hold
        bmpImage.BeginInit()
        ' we unsheathe our shwoopy shwoop...
        strm.Seek(0, SeekOrigin.Begin)
        ' and ATTACK!!!
        ' I...  I mean...
        ' adapt...
        bmpImage.StreamSource = strm
        ' we close our bitmap, realizing that no one is worthy of such power
        bmpImage.EndInit()

        ' now we set our startMenuShortcut's appIcon source to our new bitmap that
        ' we've created
        startMenuShortcut.appIcon.Source = bmpImage

        ' let's return all of our har work to whomever called upon us to do it
        Return startMenuShortcut
    End Function

    ' this is the function that can be called to create shortcuts anywhere.
    ' to use, call the function CreateShortCut([path of target], [path to save
    ' shortcut], [name of shortcut])
    ' this too came from the long lost land of StackOverflow
    Private Function CreateShortCut(ByVal TargetName As String, ByVal ShortCutPath As String, ByVal ShortCutName As String) As Boolean

        Dim oShell As Object
        Dim oLink As Object
        ' you don’t need to import anything in the project reference to create the
        ' Shell Object

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

    Private Sub btnProfile_Click(sender As Object, e As RoutedEventArgs) Handles btnProfile.Click
        Interaction.Shell("control userpasswords")
        Me.Close()
    End Sub

    ' this launches our user folder
    Private Sub btnUser_Click(sender As Object, e As RoutedEventArgs) Handles btnUser.Click
        Diagnostics.Process.Start(Environ("USERPROFILE"))
        Me.Close()
    End Sub

    ' this launches the documents folder
    Private Sub btnDocuments_Click(sender As Object, e As RoutedEventArgs) Handles btnDocuments.Click
        Diagnostics.Process.Start(Environ("USERPROFILE") + "\Documents")
        Me.Close()
    End Sub

    ' this launches the pictures folder
    Private Sub btnPictures_Click(sender As Object, e As RoutedEventArgs) Handles btnPictures.Click
        Diagnostics.Process.Start(Environ("USERPROFILE") + "\Pictures")
        Me.Close()
    End Sub

    ' this launches the music folder
    Private Sub btnMusic_Click(sender As Object, e As RoutedEventArgs) Handles btnMusic.Click
        Diagnostics.Process.Start(Environ("USERPROFILE") + "\Music")
        Me.Close()
    End Sub

    ' technically this opens the system drive, not the "My Computer" area that you'd
    ' expect the computer button to open
    Private Sub btnComputer_Click(sender As Object, e As RoutedEventArgs) Handles btnComputer.Click
        Diagnostics.Process.Start(Environ("SystemDrive"))
        Me.Close()
    End Sub

    ' this launches the control pannel
    Private Sub btnControlPanel_Click(sender As Object, e As RoutedEventArgs) Handles btnControlPanel.Click
        Diagnostics.Process.Start("control")
        Me.Close()
    End Sub

    Private Sub btnTaskbarSettings_Click(sender As Object, e As RoutedEventArgs) Handles btnTaskbarSettings.Click
        Interaction.Shell("rundll32.exe shell32.dll,Options_RunDLL 1")
        Me.Close()
    End Sub

    Private Sub btnPowerOptions_Click(sender As Object, e As RoutedEventArgs) Handles btnPowerOptions.Click
        powerOptions.Visibility = Visibility.Visible
    End Sub

    Private Sub btnShowAll_Click(ByVal sender As Object, ByVal e As RoutedEventArgs) Handles btnShowAll.Click
        If My.Computer.Info.OSVersion.StartsWith(5) Then
            If pinnedView = True Then
                path = "C:\Documents and Settings\All Users\Start Menu\Programs\"
                'path = "shell:::{4234d49b-0245-4df3-B780-3893943456e1}"
                mainMenuList.Items.Clear()
                For Each i In My.Computer.FileSystem.GetFiles(path)
                    ' This calls the renderPinnedItem function and passes each i to it.  All
                    ' the rendering is handled by renderPinnedItem so as to not bloat the sub.
                    mainMenuList.Items.Add(renderAllItem(i))
                Next
                pinnedView = False
            Else
                mainMenuList.Items.Clear()
                path = pinnedStart
                For Each i In My.Computer.FileSystem.GetFiles(pinnedStart)
                    ' This calls the renderPinnedItem function and passes each i to it.  All
                    ' the rendering is handled by renderPinnedItem so as to not bloat the sub.
                    mainMenuList.Items.Add(renderPinnedItem(i))
                Next
                pinnedView = True
            End If
        Else
            If pinnedView = True Then
                path = Environ("ALLUSERSPROFILE") + "\Microsoft\Windows\Start Menu\Programs\"
                'path = "shell:::{4234d49b-0245-4df3-B780-3893943456e1}"
                mainMenuList.Items.Clear()
                For Each i In My.Computer.FileSystem.GetFiles(path)
                    ' This calls the renderPinnedItem function and passes each i to it.  All
                    ' the rendering is handled by renderPinnedItem so as to not bloat the sub.
                    mainMenuList.Items.Add(renderAllItem(i))
                Next
                path = Environ("APPDATA") + "\Microsoft\Windows\Start Menu\Programs\"
                'path = "shell:::{4234d49b-0245-4df3-B780-3893943456e1}"
                For Each i In My.Computer.FileSystem.GetFiles(path)
                    ' This calls the renderPinnedItem function and passes each i to it.  All
                    ' the rendering is handled by renderPinnedItem so as to not bloat the sub.
                    mainMenuList.Items.Add(renderAllItem(i))
                Next
                pinnedView = False
            Else
                mainMenuList.Items.Clear()
                path = pinnedStart
                For Each i In My.Computer.FileSystem.GetFiles(pinnedStart)
                    ' This calls the renderPinnedItem function and passes each i to it.  All
                    ' the rendering is handled by renderPinnedItem so as to not bloat the sub.
                    mainMenuList.Items.Add(renderPinnedItem(i))
                Next
                pinnedView = True
            End If
        End If
    End Sub
End Class