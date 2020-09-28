Public Class Form1
    Public objcontex As HELIOSEntities
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim articleQuery = objcontex.ExecuteStoreCommand("select * from empresa")

    End Sub
End Class
