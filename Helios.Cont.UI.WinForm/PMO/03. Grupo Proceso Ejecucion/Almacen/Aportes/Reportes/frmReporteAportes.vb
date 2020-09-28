Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess

'martin
Imports Microsoft.Reporting.WinForms
Imports System.Security
Imports System.Security.Permissions

Public Class frmReporteAportes
    Inherits frmMaster

    Property reportName As String
    Property reportData As Object
    Property subreportData As Object
    Property hasSubReport As Boolean
    Property nombreMainDS As String


#Region "METODOS"


#Region "TIMER"

    Sub parpadeo()
        Static parpadear As Boolean

        If Not parpadear Then
            lblEstado.ForeColor = lblEstado.BackColor
            lblEstado.BackColor = Color.Yellow
        Else
            lblEstado.ForeColor = SystemColors.WindowText
        End If

        parpadear = Not parpadear
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If TiempoRestante > 0 Then
            parpadeo()

            'lblAgregar.Visible = True
            'lblMensaje.Visible = True
            'tsSave.Enabled = False
            'lblMensaje.Text = "Agregar otro en: " & TiempoRestante
            TiempoRestante = TiempoRestante - 1
        ElseIf TiempoRestante = 0 Then
            Timer1.Enabled = False
            lblEstado.ForeColor = Color.Navy
            lblEstado.BackColor = Color.Transparent
            '      Dispose()
        Else
            Timer1.Enabled = False
            'Ejecuta tu función cuando termina el tiempo
            TiempoEjecutar(10)

        End If
    End Sub
    Private TiempoRestante As Integer
    Public Sub TimerOn(ByRef Interval As Short)
        If Interval > 0 Then
            Timer1.Enabled = True
        Else
            Timer1.Enabled = False
        End If

    End Sub
    Public Function TiempoEjecutar(ByVal Tiempo As Integer)
        TiempoEjecutar = ""
        TiempoRestante = Tiempo  ' 1 minutos=60 segundos 
        Timer1.Interval = 400

        Call TimerOn(1000) ' Hechanos a andar el timer
    End Function
#End Region




    Sub ProveedoresShows()
        Me.Cursor = Cursors.WaitCursor
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        datos.Clear()
        'With frmModalEntidades
        '    .lblTipo.Text = "PR"
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        '    If datos.Count > 0 Then

        '        txtidProveedor.Text = datos(0).ID
        '        txtProveedor.Text = datos(0).NombreEntidad

        '        txtProveedor.Focus()
        '    Else

        '        txtidProveedor.Text = String.Empty
        '        txtProveedor.Text = String.Empty

        '        txtProveedor.Focus()
        '    End If
        'End With

        Me.Cursor = Cursors.Arrow
    End Sub

    Public Sub ConsultaReporteAportaciones(strPeriodo As String)
        Dim compraSA As New documentoCompraRPTSA
        Dim personaSA As New PersonaSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0


        Me.reportName = "Helios.Cont.Presentation.WinForm.RegistroCompraAporte.rdlc"
        Me.reportData = compraSA.OntenerListadoComprasPorAportaciones(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, strPeriodo)
        Me.nombreMainDS = "DSCompraApor"

        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCompras.KeepSessionAlive = True
        rptCompras.Reset()
        rptCompras.LocalReport.DataSources.Add(reporte)
        rptCompras.LocalReport.Refresh()
        rptCompras.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCompras.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpPeriodo", strPeriodo))
        oParams.Add(New ReportParameter("rpRuc", Gempresas.IdEmpresaRuc))
        oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa))
        oParams.Add(New ReportParameter("rpEstablecimiento", GEstableciento.NombreEstablecimiento))
        rptCompras.LocalReport.SetParameters(oParams)
        rptCompras.RefreshReport()
        rptCompras.SetDisplayMode(DisplayMode.PrintLayout)
        rptCompras.ZoomMode = ZoomMode.Percent
        rptCompras.ZoomPercent = 75
    End Sub


    'martin reporte por empresa
    Public Sub ConsultaReporteAportacionesEmpresa(strPeriodo As String)
        Dim compraSA As New documentoCompraRPTSA
        Dim personaSA As New PersonaSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0


        Me.reportName = "Helios.Cont.Presentation.WinForm.RegistroCompraAportacionesEmpresa.rdlc"
        Me.reportData = compraSA.OntenerListadoComprasAportacionesPorEmpresa(Gempresas.IdEmpresaRuc, strPeriodo)
        Me.nombreMainDS = "DSCompraApor2"

        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCompras.KeepSessionAlive = True
        rptCompras.Reset()
        rptCompras.LocalReport.DataSources.Add(reporte)
        rptCompras.LocalReport.Refresh()
        rptCompras.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCompras.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpPeriodo", strPeriodo))
        oParams.Add(New ReportParameter("rpRuc", Gempresas.IdEmpresaRuc))
        oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa))
        rptCompras.LocalReport.SetParameters(oParams)
        rptCompras.RefreshReport()
        rptCompras.SetDisplayMode(DisplayMode.PrintLayout)
        rptCompras.ZoomMode = ZoomMode.Percent
        rptCompras.ZoomPercent = 75
    End Sub





    'reporte aportaciones empresa y proveedor


    Public Sub ConsultaReporteCompraProveedor(strPeriodo As String)
        Dim compraSA As New documentoCompraRPTSA
        Dim personaSA As New PersonaSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0

        Me.reportName = "Helios.Cont.Presentation.WinForm.RegistroCompraAportacionesProveedor.rdlc"
        Me.reportData = compraSA.OntenerListadoComprasAportacionesPorProveedor(Gempresas.IdEmpresaRuc, CDec(txtidProveedor.Text), strPeriodo)
        Me.nombreMainDS = "DSCompraApor3"

        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCompras.KeepSessionAlive = True
        rptCompras.Reset()
        rptCompras.LocalReport.DataSources.Add(reporte)
        rptCompras.LocalReport.Refresh()
        rptCompras.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCompras.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpPeriodo", strPeriodo))
        oParams.Add(New ReportParameter("rpRuc", Gempresas.IdEmpresaRuc))
        oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa))
        oParams.Add(New ReportParameter("rpProveedor", txtProveedor.Text))
        rptCompras.LocalReport.SetParameters(oParams)
        rptCompras.RefreshReport()
        rptCompras.SetDisplayMode(DisplayMode.PrintLayout)
        rptCompras.ZoomMode = ZoomMode.Percent
        rptCompras.ZoomPercent = 75
    End Sub


    'martin reporte compra proveedor establecimiento empresa


    Public Sub ConsultaReporteCompraProveedorEstablecimiento(strPeriodo As String)
        Dim compraSA As New documentoCompraRPTSA
        Dim personaSA As New PersonaSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0


        Me.reportName = "Helios.Cont.Presentation.WinForm.RegistroCompraAportacionProveedorEstablec.rdlc"
        Me.reportData = compraSA.OntenerListadoComprasAportacionesPorProveedorEstablec(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, CDec(txtidProveedor.Text), strPeriodo)
        Me.nombreMainDS = "DSCompraApor4"

        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCompras.KeepSessionAlive = True
        rptCompras.Reset()
        rptCompras.LocalReport.DataSources.Add(reporte)
        rptCompras.LocalReport.Refresh()
        rptCompras.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCompras.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpPeriodo", strPeriodo))
        oParams.Add(New ReportParameter("rpRuc", Gempresas.IdEmpresaRuc))
        oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa))
        oParams.Add(New ReportParameter("rpEstablecimiento", GEstableciento.NombreEstablecimiento))
        oParams.Add(New ReportParameter("rpProveedor", txtProveedor.Text))
        rptCompras.LocalReport.SetParameters(oParams)
        rptCompras.RefreshReport()
        rptCompras.SetDisplayMode(DisplayMode.PrintLayout)
        rptCompras.ZoomMode = ZoomMode.Percent
        rptCompras.ZoomPercent = 75
    End Sub
#End Region

    Private Sub KryptonCheckButton2_Click(sender As System.Object, e As System.EventArgs) Handles KryptonCheckButton2.Click
        ConsultaReporteAportaciones(lblPerido.Text)
        KryptonCheckButton1.Checked = False
        KryptonCheckButton2.Checked = True
        KryptonCheckButton5.Checked = False
        KryptonCheckButton4.Checked = False
    End Sub

    Private Sub frmReporteAportes_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim cfecha As Date = DateTime.Now.Date
        lblPerido.Text = String.Format("{0:00}", Convert.ToInt32(cfecha.Month)) & "/" & PeriodoGeneral
    End Sub

    Private Sub KryptonCheckButton1_Click(sender As System.Object, e As System.EventArgs) Handles KryptonCheckButton1.Click
        ConsultaReporteAportacionesEmpresa(lblPerido.Text)
        KryptonCheckButton1.Checked = True
        KryptonCheckButton2.Checked = False
        KryptonCheckButton5.Checked = False
        KryptonCheckButton4.Checked = False
    End Sub

    Private Sub KryptonCheckButton5_Click(sender As System.Object, e As System.EventArgs) Handles KryptonCheckButton5.Click
        If CDec(txtidProveedor.Text) > 0 Then
            ConsultaReporteCompraProveedor(lblPerido.Text)

            KryptonCheckButton1.Checked = False
            KryptonCheckButton2.Checked = False
            KryptonCheckButton5.Checked = True
            KryptonCheckButton4.Checked = False
        Else

            lblEstado.Text = "Debe elegir un proveedor"
            Timer1.Enabled = True
            TiempoEjecutar(5)

            KryptonCheckButton1.Checked = False
            KryptonCheckButton2.Checked = False
            KryptonCheckButton5.Checked = True
            KryptonCheckButton4.Checked = False

        End If
    End Sub

    Private Sub LinkProveedor_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkProveedor.LinkClicked
        ProveedoresShows()
    End Sub

    Private Sub KryptonCheckButton4_Click(sender As System.Object, e As System.EventArgs) Handles KryptonCheckButton4.Click
        If CDec(txtidProveedor.Text) > 0 Then
            ConsultaReporteCompraProveedorEstablecimiento(lblPerido.Text)

            KryptonCheckButton1.Checked = False
            KryptonCheckButton2.Checked = False
            KryptonCheckButton5.Checked = False
            KryptonCheckButton4.Checked = True

        Else

            lblEstado.Text = "Debe elegir un proveedor"
            Timer1.Enabled = True
            TiempoEjecutar(5)
            KryptonCheckButton1.Checked = False
            KryptonCheckButton2.Checked = False
            KryptonCheckButton5.Checked = False
            KryptonCheckButton4.Checked = True

        End If
    End Sub
End Class