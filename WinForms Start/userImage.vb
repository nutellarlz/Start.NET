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

Imports System.Text
Imports System
Imports System.Runtime.InteropServices

Module userImage

    <DllImport("shell32", EntryPoint:="#261", CharSet:=CharSet.Unicode, PreserveSig:=False)>
    Public Sub GetUserTilePath(username As String, whatever As UInt32, picpath As StringBuilder, maxLength As Integer)
    End Sub

    Public Function GetUserTilePath(username As String) As String
        Dim sb As StringBuilder
        sb = New StringBuilder(1000)
        GetUserTilePath(username, 2147483648, sb, sb.Capacity)
        Return sb.ToString()
    End Function

    Public Function GetUserTile(username As String) As Image
        Return Image.FromFile(GetUserTilePath(username))
    End Function

End Module
