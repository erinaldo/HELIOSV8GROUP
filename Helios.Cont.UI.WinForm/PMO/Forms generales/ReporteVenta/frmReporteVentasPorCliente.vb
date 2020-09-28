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


Public Class frmReporteVentasPorCliente

    Inherits frmMaster

    Property reportName As String
    Property reportData As Object
    Property subreportData As Object
    Property hasSubReport As Boolean
    Property nombreMainDS As String
    Dim listaSubCategoria As New List(Of item)

#Region "metodos"

    Public Sub ObtenerListaControlesLoad()
        Dim eNtidadSA As New entidadSA
        Dim eNtidad As New List(Of entidad)

        Dim objENtidad As New entidad With {.idEntidad = -1, .nombreCompleto = "Todos los clientes", .nrodoc = 0}
        eNtidad = eNtidadSA.GetListarEntidad(New entidad With {.tipoEntidad = TIPO_ENTIDAD.CLIENTE, .idEmpresa = Gempresas.IdEmpresaRuc, .idOrganizacion = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
        eNtidad.Add(objENtidad)

        cboclientes.ValueMember = "idEntidad"
        cboclientes.DisplayMember = "nombreCompleto"
        cboclientes.DataSource = eNtidad
    End Sub


    Public Sub ConsultaReportePorCliente(idclie As Integer, nameart As String, ini As Date, fin As Date)
        Dim totalesAlmacenSA As New documentoVentaAbarrotesSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.rptVentaClieArt.rdlc"
        'Me.reportData = totalesAlmacenSA.ListadoVentaClienteArticulo(idclie, nameart, ini, fin)
        Me.reportData = totalesAlmacenSA.ListadoVentaClienteOrAnticulo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, idclie, nameart, ini, fin, "CL")
        Me.nombreMainDS = "dsventa"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        ReportViewer1.KeepSessionAlive = True
        ReportViewer1.Reset()
        ReportViewer1.LocalReport.DataSources.Add(reporte)
        ReportViewer1.LocalReport.Refresh()
        ReportViewer1.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        ReportViewer1.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa))
        'oParams.Add(New ReportParameter("rpEstablecimiento", GEstableciento.NombreEstablecimiento))
        'oParams.Add(New ReportParameter("rpPeriodo", PeriodoGeneral))
        oParams.Add(New ReportParameter("rpFecha", dateinicio.Value.ToShortDateString & " al " & datefin.Value.ToShortDateString))
        ReportViewer1.LocalReport.SetParameters(oParams)
        ReportViewer1.RefreshReport()
        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        ReportViewer1.ZoomMode = ZoomMode.Percent
        ReportViewer1.ZoomPercent = 75
    End Sub

    Public Sub ConsultaReportePorClientexArticulo(idclie As Integer, nameart As String, ini As Date, fin As Date)
        Dim totalesAlmacenSA As New documentoVentaAbarrotesSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.rptVentaClieArt.rdlc"
        'Me.reportData = totalesAlmacenSA.ListadoVentaClienteArticulo(idclie, nameart, ini, fin)
        Me.reportData = totalesAlmacenSA.ListadoVentaClienteOrAnticulo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, idclie, nameart, ini, fin, "CLART")
        Me.nombreMainDS = "dsventa"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        ReportViewer1.KeepSessionAlive = True
        ReportViewer1.Reset()
        ReportViewer1.LocalReport.DataSources.Add(reporte)
        ReportViewer1.LocalReport.Refresh()
        ReportViewer1.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        ReportViewer1.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa))
        'oParams.Add(New ReportParameter("rpEstablecimiento", GEstableciento.NombreEstablecimiento))
        'oParams.Add(New ReportParameter("rpPeriodo", PeriodoGeneral))
        oParams.Add(New ReportParameter("rpFecha", dateinicio.Value.ToShortDateString & " al " & datefin.Value.ToShortDateString))
        ReportViewer1.LocalReport.SetParameters(oParams)
        ReportViewer1.RefreshReport()
        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        ReportViewer1.ZoomMode = ZoomMode.Percent
        ReportViewer1.ZoomPercent = 75
    End Sub

    Public Sub ConsultaReportePorArticulo(idclie As Integer, nameart As String, ini As Date, fin As Date)
        Dim totalesAlmacenSA As New documentoVentaAbarrotesSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.rptVentaClieArt.rdlc"
        'Me.reportData = totalesAlmacenSA.ListadoVentaClienteArticulo(idclie, nameart, ini, fin)
        Me.reportData = totalesAlmacenSA.ListadoVentaClienteOrAnticulo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, idclie, nameart, ini, fin, "ART")
        Me.nombreMainDS = "dsventa"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        ReportViewer1.KeepSessionAlive = True
        ReportViewer1.Reset()
        ReportViewer1.LocalReport.DataSources.Add(reporte)
        ReportViewer1.LocalReport.Refresh()
        ReportViewer1.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        ReportViewer1.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa))
        'oParams.Add(New ReportParameter("rpEstablecimiento", GEstableciento.NombreEstablecimiento))
        'oParams.Add(New ReportParameter("rpPeriodo", PeriodoGeneral))
        oParams.Add(New ReportParameter("rpFecha", dateinicio.Value.ToShortDateString & " al " & datefin.Value.ToShortDateString))
        ReportViewer1.LocalReport.SetParameters(oParams)
        ReportViewer1.RefreshReport()
        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        ReportViewer1.ZoomMode = ZoomMode.Percent
        ReportViewer1.ZoomPercent = 75
    End Sub


    Private Sub ListaMercaderias(strTipoEx As String, strBusqueda As String)
        Dim existenciaSA As New detalleitemsSA
        lsvListadoItems.Items.Clear()
        For Each i In existenciaSA.GetUbicarProductoXdescripcion2(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, Nothing, strTipoEx, strBusqueda)
            Dim n As New ListViewItem(i.codigodetalle)
            n.SubItems.Add(i.descripcionItem)
            '   n.SubItems.Add(i.codigo & "   " & "-" & "   " & i.descripcionItem)
            n.SubItems.Add(i.unidad1)
            n.SubItems.Add(i.tipoExistencia)
            n.SubItems.Add(i.origenProducto)
            n.SubItems.Add(i.codigo)
            n.SubItems.Add(0)
            n.SubItems.Add(i.cuenta)
            n.SubItems.Add(i.presentacion)
            lsvListadoItems.Items.Add(n)
        Next

    End Sub

#End Region

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub frmReporteVentasPorCliente_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dateinicio.Value = DateTime.Now
        datefin.Value = DateTime.Now
        ObtenerListaControlesLoad()
        rbCliente.Checked = True
        cboclientes.Visible = True
        Label2.Visible = True
        cboclientes.SelectedValue = -1
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        'If txtbuscar.Text.Trim.Length > 0 Then
        '    ConsultaReportePorCliente(cboclientes.SelectedValue, txtbuscar.Text, dateinicio.Value, datefin.Value)
        'Else
        Dim fechaInicio = New DateTime(dateinicio.Value.Year, dateinicio.Value.Month, dateinicio.Value.Day, 12, 0, 0)
        Dim fechaFinal = New DateTime(datefin.Value.Year, datefin.Value.Month, datefin.Value.Day, 23, 59, 59)
        If rbArticulo.Checked = True Then
            ConsultaReportePorArticulo(cboclientes.SelectedValue, txtbuscar.Text, fechaInicio, fechaFinal)
        ElseIf rbCliente.Checked = True Then
            ConsultaReportePorCliente(cboclientes.SelectedValue, txtbuscar.Text, fechaInicio, fechaFinal)
        ElseIf rbProArt.Checked = True Then
            ConsultaReportePorClientexArticulo(cboclientes.SelectedValue, txtbuscar.Text, fechaInicio, fechaFinal)
        Else
            'lblmesage.Visible = True
            'lblmesage.Text = "debe escribir algun producto"
            MessageBox.Show("Escribir algun producto a buscar")
        End If
    End Sub

    Private Sub rbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles rbCliente.CheckedChanged
        If (rbCliente.Checked = True) Then
            rbCliente.Checked = True
            rbArticulo.Checked = False
            rbProArt.Checked = False
            ConsultaReportePorArticulo(0, Nothing, Nothing, Nothing)
            cboclientes.SelectedValue = -1
            dateinicio.Value = DateTime.Now
            datefin.Value = DateTime.Now
            pnCliente.Visible = True
            pnArticulo.Visible = False
            pnFecha.Location = New Point(364, 74)
        End If
    End Sub

    Private Sub rbArticulo_CheckedChanged(sender As Object, e As EventArgs) Handles rbArticulo.CheckedChanged
        If (rbArticulo.Checked = True) Then
            rbArticulo.Checked = True
            rbCliente.Checked = False
            rbProArt.Checked = False
            ConsultaReportePorArticulo(0, Nothing, Nothing, Nothing)
            txtbuscar.Clear()
            txtbuscar.Select()
            dateinicio.Value = DateTime.Now
            datefin.Value = DateTime.Now
            pnCliente.Visible = False
            pnArticulo.Visible = True
            pnFecha.Location = New Point(367, 74)
            pnArticulo.Location = New Point(50, 74)
        End If
    End Sub

    Private Sub rbProArt_CheckedChanged(sender As Object, e As EventArgs) Handles rbProArt.CheckedChanged
        If (rbProArt.Checked = True) Then
            rbArticulo.Checked = False
            rbCliente.Checked = False
            rbProArt.Checked = True
            ConsultaReportePorArticulo(0, Nothing, Nothing, Nothing)
            txtbuscar.Clear()
            cboclientes.SelectedValue = -1
            dateinicio.Value = DateTime.Now
            datefin.Value = DateTime.Now
            pnCliente.Visible = True
            pnArticulo.Visible = True
            pnFecha.Location = New Point(680, 74)
            pnArticulo.Location = New Point(367, 74)
        End If
    End Sub

    Private Sub txtbuscar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtbuscar.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Me.popupControlContainer1.ParentControl = Me.txtbuscar
            Me.popupControlContainer1.ShowPopup(Point.Empty)


            ListaMercaderias("01", txtbuscar.Text.Trim)

            Me.Cursor = Cursors.Arrow

            e.Handled = True

        End If
    End Sub

    Private Sub lsvSubCategoria_MouseDoubleClick(sender As Object, e As MouseEventArgs)
        Me.popupControlContainer1.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub popupControlContainer1_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles popupControlContainer1.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvListadoItems.SelectedItems.Count > 0 Then
                Me.txtbuscar.Text = lsvListadoItems.SelectedItems(0).SubItems(1).Text

                txtbuscar.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)

            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtbuscar.Focus()
        End If
    End Sub

    Private Sub lsvListadoItems_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvListadoItems.MouseDoubleClick
        If lsvListadoItems.SelectedItems.Count > 0 Then
            Me.popupControlContainer1.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub txtbuscar_Click(sender As Object, e As EventArgs) Handles txtbuscar.Click
        txtbuscar.Select()
        txtbuscar.Select(0, txtbuscar.Text.Length)
    End Sub

    Private Sub txtbuscar_TextChanged(sender As Object, e As EventArgs) Handles txtbuscar.TextChanged

    End Sub
End Class
