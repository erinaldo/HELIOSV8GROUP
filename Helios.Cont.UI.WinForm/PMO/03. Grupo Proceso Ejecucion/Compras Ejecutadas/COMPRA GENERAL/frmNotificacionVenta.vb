Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping
Public Class frmNotificacionVenta
    Inherits frmMaster

    Public Sub New(intIdDocumento As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Ventas(intIdDocumento)
    End Sub

    Private Sub Ventas(intIdDocumento As Integer)
        Dim ventaSA As New documentoVentaAbarrotesDetSA

        dgvVentas.DataSource = ventaSA.GetVentasNotificadasAtendCompras(intIdDocumento)

    End Sub

    Private Sub frmNotificacionVenta_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmNotificacionVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class