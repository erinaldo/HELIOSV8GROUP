Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmModalNegativos

#Region "Constructors"
    Public Sub New(be As List(Of totalesAlmacen))

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GetNegativos(be)
    End Sub
#End Region

#Region "Methods"
    Public Sub GetNegativos(be As List(Of totalesAlmacen))
        ListView1.Items.Clear()
        For Each i In be
            Dim n As New ListViewItem
            n.Text = i.NomAlmacen
            n.SubItems.Add(i.descripcion)
            n.SubItems.Add(i.cantidad)
            ListView1.Items.Add(n)
        Next
    End Sub
#End Region

End Class