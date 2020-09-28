Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess

Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms

Public Class frmMasterModelReportePOS

    Inherits frmMaster

    Private Sub frmMasterModelReporte_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmMasterModelReporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '     Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub PanelError_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub GradientPanel2_Paint(sender As Object, e As PaintEventArgs) Handles GradientPanel2.Paint

    End Sub

    Private Sub Label28_Click(sender As Object, e As EventArgs)
        With frmReporteDocumentoVentas
            .ConsultaReporteTotalesPorPeriodo(PeriodoGeneral)
            .lblPerido.Text = PeriodoGeneral
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Label28_DoubleClick(sender As Object, e As EventArgs)

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim f As New frmComprasXmes
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim f As New frmComprasXaNio
        f.WindowState = FormWindowState.Maximized
        f.Show()
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim f As New frmListaProveedores
        f.WindowState = FormWindowState.Maximized
        f.Show()
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim f As New frmReporteNotaCredito
        f.WindowState = FormWindowState.Maximized
        f.Show()
    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim f As New frmReportePagosMes
        f.WindowState = FormWindowState.Maximized
        f.Show()
    End Sub

    Private Sub LinkLabel6_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel6.LinkClicked
        Dim f As New frmReporteComprasPorProv
        f.WindowState = FormWindowState.Maximized
        f.Show()
    End Sub

    Private Sub LinkLabel7_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim f As New frmReportePagosxProv
        f.WindowState = FormWindowState.Maximized
        f.Show()
    End Sub

    Private Sub LinkLabel8_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim f As New frmReportePagosxProvDetalle
        f.WindowState = FormWindowState.Maximized
        f.Show()
    End Sub

    Private Sub LinkLabel9_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim f As New frmReporteListaInventario
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel10_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim f As New ReporteKardexXproducto
        f.WindowState = FormWindowState.Maximized
        f.Show()
    End Sub

    Private Sub LinkLabel14_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel14.LinkClicked
        Dim f As New frmReporteVentasPorCliente
        f.WindowState = FormWindowState.Maximized
        f.Show()
    End Sub

    Private Sub LinkLabel16_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim f As New frmReporteCobrosxClie
        f.WindowState = FormWindowState.Maximized
        f.Show()
    End Sub

    Private Sub LinkLabel15_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim f As New frmReporteCobrosxClieDetalle
        f.WindowState = FormWindowState.Maximized
        f.Show()
    End Sub

    Private Sub LinkLabel13_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim f As New frmRptNotaCreditoVenta
        f.WindowState = FormWindowState.Maximized
        f.Show()
    End Sub

    Private Sub LinkLabel12_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

        Dim f As New frmListaClientes
        f.WindowState = FormWindowState.Maximized
        f.Show()
    End Sub

    Private Sub LinkLabel11_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel11.LinkClicked
        Dim f As New frmRptListadoFactura
        f.WindowState = FormWindowState.Maximized
        f.Show()
    End Sub

    Private Sub LinkLabel17_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim f As New frmVentasXaNio
        f.WindowState = FormWindowState.Maximized
        f.Show()
    End Sub

    Private Sub LinkLabel18_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim f As New frmRptPagoMesVenta
        f.WindowState = FormWindowState.Maximized
        f.Show()
    End Sub

    Private Sub LinkLabel19_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel19.LinkClicked
        Dim f As New frmComprasXdia
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel20_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel20.LinkClicked
        Dim f As New FmrVentxDia
        f.WindowState = FormWindowState.Maximized
        f.Show()
    End Sub

    Private Sub Label40_Click(sender As Object, e As EventArgs)

    End Sub



    Dim listaCuenta As New List(Of String)





    Private Sub LinkLabel21_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim f As New frmReporteHojaTrabajo
        f.WindowState = FormWindowState.Maximized
        f.Show()
    End Sub

    Private Sub LinkLabel22_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim f As New frmResumenLibroDiario ' frmModalRptLibroDiario
        f.WindowState = FormWindowState.Maximized
        f.Show()
    End Sub

    Private Sub LinkLabel23_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim f As New frmRptLibroMayor
        'f.listaCuenta = listaCuenta
        f.StartPosition = FormStartPosition.CenterScreen
        f.Show()
    End Sub

    Private Sub LinkLabel24_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim f As New FrmBalanceGneral
        f.WindowState = FormWindowState.Maximized
        f.Show()
    End Sub

    Private Sub LinkLabel25_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

        Dim f As New frmRptCuentaContable
        f.WindowState = FormWindowState.Maximized
        f.Show()

    End Sub

    Private Sub LinkLabel26_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim f As New frmRptClaseReporte
        f.WindowState = FormWindowState.Maximized
        f.Show()
    End Sub

    Private Sub Label47_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub LinkLabel36_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel36.LinkClicked
        Dim f As New frmrentabilidadXmes
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel35_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel35.LinkClicked
        Dim f As New frmrentabilidadXdia
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel27_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim f As New frmCostoByProyecto(TipoCosto.Proyecto)
        f.Label1.Text = "RESÚMEN COSTOS POR PROYECTO"
        f.WindowState = FormWindowState.Maximized
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel31_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim f As New frmCostoByGastos
        f.WindowState = FormWindowState.Maximized
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel29_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim f As New frmCostoByProyecto(TipoCosto.OrdenProduccion)
        f.Label1.Text = "RESÚMEN ORDEN DE PRODUCCIÓN"
        f.WindowState = FormWindowState.Maximized
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel30_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim f As New frmCostoByProyecto(TipoCosto.ActivoFijo)
        f.Label1.Text = "ACTIVO INMOVILIZADO EN CURSO"
        f.WindowState = FormWindowState.Maximized
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel34_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

    End Sub

    Private Sub LinkLabel38_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim f As New frmReporteListaPrecios
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel32_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel32.LinkClicked

    End Sub

    Private Sub LinkLabel34_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim f As New frmArticulosVendidosByMes
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel37_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim f As New frmArticulosVendidosByDia
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel39_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim f As New frmReporteMovAlmacen
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel40_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim f As New frmReporteCostoProceso()
        f.CBOConsultas.Enabled = True
        f.CBOConsultas.SelectedIndex = -1
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel41_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim f As New frmReporteElmentoCostoAnual
        f.CBOConsultas.Enabled = True
        f.CBOConsultas.SelectedIndex = -1
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub


    Private Sub LinkLabel2_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Dim f As New frmrentabilidadXFiltro
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub
End Class