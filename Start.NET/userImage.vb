Imports System.Text
Imports System
Imports System.Runtime.InteropServices

Module userImage

    <DllImport("shell32", EntryPoint:="#261", CharSet:=CharSet.Unicode, PreserveSig:=False)>
    Public Sub GetUserTilePath(ByVal username As String, ByVal whatever As UInt32, ByVal picpath As StringBuilder, ByVal maxLength As Integer)
    End Sub

    Public Function GetUserTilePath(ByVal username As String) As String
        Dim sb As StringBuilder
        sb = New StringBuilder(1000)
        GetUserTilePath(username, 2147483648, sb, sb.Capacity)
        Return sb.ToString()
    End Function

    Public Function GetUserTile(ByVal username As String) As BitmapImage
        'Return Image.FromFile(GetUserTilePath(username))
        Dim bitmap As BitmapImage = New BitmapImage()
        bitmap.BeginInit()
        'bitmap.UriSource = New Uri(GetUserTilePath(username))
        If My.Computer.Info.OSVersion.StartsWith(5) Then
            bitmap.UriSource = New Uri("C:\Documents and Settings\All Users\Application Data\Microsoft\User Account Pictures\" + username + ".bmp")
        Else
            bitmap.UriSource = New Uri(GetUserTilePath(username))
        End If
        bitmap.EndInit()

        Return bitmap
    End Function

End Module