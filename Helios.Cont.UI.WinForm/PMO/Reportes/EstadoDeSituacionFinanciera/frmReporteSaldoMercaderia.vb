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

Imports Microsoft.Reporting.WinForms
Imports System.Security
Imports System.Security.Permissions

Public Class frmReporteSaldoMercaderia

    Property reportName As String
    Property reportData As Object
    Property subreportData As Object
    Property hasSubReport As Boolean
    Property nombreMainDS As String

#Region "metodos"

    Private Sub CargarCMB()
        Dim almacenSA As New almacenSA
        Dim tablaSA As New tablaDetalleSA
        Dim lista As New List(Of tabladetalle)

        cboAlmacen.DisplayMember = "descripcionAlmacen"
        cboAlmacen.ValueMember = "idAlmacen"
        cboAlmacen.DataSource = almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})


        lista = New List(Of tabladetalle)
        lista = tablaSA.GetListaTablaDetalle(5, "1")
        lista.Add(New tabladetalle With {.idtabla = 5, .codigoDetalle = "00", .codigoDetalle2 = "00", .descripcion = "-Todos-"})

        cboTipoExistencia.DisplayMember = "descripcion"
        cboTipoExistencia.ValueMember = "codigoDetalle"
        cboTipoExistencia.DataSource = lista
        cboTipoExistencia.SelectedValue = "00"

    End Sub


    Public Sub Consultar(intIdAlmacen As Integer)
        Dim totalesAlmacenSA As New TotalesAlmacenSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.Formato3.7MercaderiaProductoTerm.rdlc"
        Me.reportData = totalesAlmacenSA.GetProductosByAlmacen(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                                               .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                               .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA,
                                                                               .idAlmacen = intIdAlmacen}, cboTipoExistencia.SelectedValue)
        Me.nombreMainDS = "DsExistencia"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptMercaderias.KeepSessionAlive = True
        rptMercaderias.Reset()
        rptMercaderias.LocalReport.DataSources.Add(reporte)
        rptMercaderias.LocalReport.Refresh()
        rptMercaderias.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptMercaderias.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa))
        'oParams.Add(New ReportParameter("rpAnio", "al - " & FormatDateTime(DateTime.Now, DateFormat.ShortDate)))
        rptMercaderias.LocalReport.SetParameters(oParams)
        rptMercaderias.RefreshReport()
        rptMercaderias.SetDisplayMode(DisplayMode.PrintLayout)
        rptMercaderias.ZoomMode = ZoomMode.Percent
        rptMercaderias.ZoomPercent = 75
    End Sub
#End Region

    Private Sub frmReporteSaldoMercaderia_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.rptMercaderias.RefreshReport()
        CargarCMB()
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        If cboAlmacen.SelectedIndex > -1 Then
            Dim codAlmacen = cboAlmacen.SelectedValue
            If IsNumeric(codAlmacen) Then
                Consultar(codAlmacen)
            End If
        End If
    End Sub
End Class
