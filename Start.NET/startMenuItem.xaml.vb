Public Class startMenuItem

    Public shortcutLink As String
    Private Sub mainClick_MouseLeftButtonUp(sender As Object, e As MouseButtonEventArgs) Handles mainClick.MouseLeftButtonUp
        Diagnostics.Process.Start(shortcutLink)
        Dim myWindow = Window.GetWindow(Me)
        myWindow.Close()
    End Sub
End Class
