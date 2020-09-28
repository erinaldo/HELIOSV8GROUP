Imports Helios.General
Public Class frmMaestroCierre
#Region "Attrbutes"
    Public Property cierreSA As New WCFService.ServiceAccess.empresaCierreMensualSA
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GetCierres()
    End Sub

#End Region

#Region "Methods"
    Private Sub GetCierres()
        ListView1.Items.Clear()
        For Each i In cierreSA.GetCierresByEmpresa(New Business.Entity.empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc})
            Dim n As New ListViewItem(i.anio)
            n.SubItems.Add(i.mes)
            ListView1.Items.Add(n)
        Next
    End Sub

    Private Sub EliminarCierre(n As ListViewItem)
        cierreSA.EliminarCierre(New Business.Entity.empresaCierreMensual With {
                                .idEmpresa = Gempresas.IdEmpresaRuc,
                                .anio = n.SubItems(0).Text,
                                .mes = n.SubItems(1).Text})

        ListView1.SelectedItems(0).Remove()
    End Sub
#End Region

#Region "Events"
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        GetCierres()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ListView1.SelectedItems.Count > 0 Then
            EliminarCierre(ListView1.SelectedItems(0))
        End If
    End Sub
#End Region
End Class