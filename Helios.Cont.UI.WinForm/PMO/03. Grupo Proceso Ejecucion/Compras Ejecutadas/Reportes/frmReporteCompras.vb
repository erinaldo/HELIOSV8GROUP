Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess

'martin
Imports Microsoft.Reporting.WinForms
Imports System.Security
Imports System.Security.Permissions

Public Class frmReporteCompras
    Inherits frmMaster

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Dim cfecha As Date = DateTime.Now.Date
        lblPerido.Text = String.Format("{0:00}", Convert.ToInt32(cfecha.Month)) & "/" & PeriodoGeneral
    End Sub

    Property reportName As String
    Property reportData As Object
    Property subreportData As Object
    Property hasSubReport As Boolean
    Property nombreMainDS As String



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

#Region "metodos"

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
    'martin proveedores




    'martin reporte por empresa
    Public Sub ConsultaReporteEmpresa(strPeriodo As String)
        Dim compraSA As New documentoCompraRPTSA
        Dim personaSA As New PersonaSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0


        Me.reportName = "Helios.Cont.Presentation.WinForm.RegistroCompraEmpresa.rdlc"
        Me.reportData = compraSA.OntenerListadoComprasPorEmpresa(Gempresas.IdEmpresaRuc, strPeriodo)
        Me.nombreMainDS = "DSCompra2"

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


    'martin reporte por periodo


    Public Sub ConsultaReporte(strPeriodo As String)
        Dim compraSA As New documentoCompraRPTSA
        Dim personaSA As New PersonaSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0


        Me.reportName = "Helios.Cont.Presentation.WinForm.RegistroCompra.rdlc"
        Me.reportData = compraSA.OntenerListadoComprasPorPeriodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, strPeriodo)
        Me.nombreMainDS = "DSCompras"

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

    'lista de compras con bonificacion


    Public Sub ConsultaReporteCompraConBonificacion(strPeriodo As String)
        Dim compraSA As New documentoCompraRPTSA
        Dim personaSA As New PersonaSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0

        Me.reportName = "Helios.Cont.Presentation.WinForm.RegistroCompraConBonificaciones.rdlc"
        Me.reportData = compraSA.OntenerListadoComprasConBonificacion(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, strPeriodo)
        Me.nombreMainDS = "DSCompras3"

        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCompras.KeepSessionAlive = True
        rptCompras.Reset()
        rptCompras.LocalReport.DataSources.Add(reporte)
        rptCompras.LocalReport.Refresh()
        rptCompras.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCompras.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpPeriodo", strPeriodo))
        oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa))
        oParams.Add(New ReportParameter("rpEstablecimiento", GEstableciento.NombreEstablecimiento))
        rptCompras.LocalReport.SetParameters(oParams)
        rptCompras.RefreshReport()
        rptCompras.SetDisplayMode(DisplayMode.PrintLayout)
        rptCompras.ZoomMode = ZoomMode.Percent
        rptCompras.ZoomPercent = 75
    End Sub




    'reporte empresa y proveedor


    Public Sub ConsultaReporteCompraProveedor(strPeriodo As String)
        Dim compraSA As New documentoCompraRPTSA
        Dim personaSA As New PersonaSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0

        Me.reportName = "Helios.Cont.Presentation.WinForm.RegistroCompraProveedor.rdlc"
        Me.reportData = compraSA.OntenerListadoComprasPorProveedor(Gempresas.IdEmpresaRuc, CDec(txtidProveedor.Text), strPeriodo)
        Me.nombreMainDS = "DSCompras4"

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


        Me.reportName = "Helios.Cont.Presentation.WinForm.RegistroCompraProveedorEstablec.rdlc"
        Me.reportData = compraSA.OntenerListadoComprasPorProveedorEstablec(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, CDec(txtidProveedor.Text), strPeriodo)
        Me.nombreMainDS = "DSCompras5"

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

    Private Sub frmReporteCompras_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        With rptCompraPeriodo
            .ConsultaReporte("2/2015")
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        'martin

        'With rptCompraEmpresa
        '    .ConsultaReporteEmpresa("03/2014")
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        'End With
    End Sub

    Private Sub rptCompras_Load(sender As System.Object, e As System.EventArgs)


    End Sub

    Private Sub KryptonCheckButton1_Click(sender As System.Object, e As System.EventArgs) Handles KryptonCheckButton1.Click
        ConsultaReporteEmpresa(lblPerido.Text)
        KryptonCheckButton1.Checked = True
        KryptonCheckButton2.Checked = False
        KryptonCheckButton3.Checked = False
        KryptonCheckButton5.Checked = False
        KryptonCheckButton4.Checked = False

    End Sub

    Private Sub QRibbonCaption1_ItemActivated(sender As System.Object, e As Qios.DevSuite.Components.QCompositeEventArgs)

    End Sub

    Private Sub KryptonCheckButton2_Click(sender As System.Object, e As System.EventArgs) Handles KryptonCheckButton2.Click
        ConsultaReporte(lblPerido.Text)

        KryptonCheckButton2.Checked = True
        KryptonCheckButton1.Checked = False
        KryptonCheckButton3.Checked = False
        KryptonCheckButton5.Checked = False
        KryptonCheckButton4.Checked = False
    End Sub

    Private Sub KryptonCheckButton3_Click(sender As System.Object, e As System.EventArgs) Handles KryptonCheckButton3.Click
        ConsultaReporteCompraConBonificacion(lblPerido.Text)
        KryptonCheckButton1.Checked = False
        KryptonCheckButton2.Checked = False
        KryptonCheckButton3.Checked = True
        KryptonCheckButton5.Checked = False
        KryptonCheckButton4.Checked = False

    End Sub

    Private Sub frmReporteCompras_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
      
    End Sub

    Private Sub LinkProveedor_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkProveedor.LinkClicked
        ProveedoresShows()
    End Sub

    Private Sub KryptonCheckButton5_Click(sender As System.Object, e As System.EventArgs) Handles KryptonCheckButton5.Click
        If CDec(txtidProveedor.Text) > 0 Then
            ConsultaReporteCompraProveedor(lblPerido.Text)

            KryptonCheckButton1.Checked = False
            KryptonCheckButton2.Checked = False
            KryptonCheckButton3.Checked = False
            KryptonCheckButton5.Checked = True
            KryptonCheckButton4.Checked = False
        Else

            lblEstado.Text = "Debe elegir un proveedor"
            Timer1.Enabled = True
            TiempoEjecutar(5)


            KryptonCheckButton1.Checked = False
            KryptonCheckButton2.Checked = False
            KryptonCheckButton3.Checked = False
            KryptonCheckButton5.Checked = True
            KryptonCheckButton4.Checked = False

        End If






    End Sub

    Private Sub KryptonCheckButton4_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub KryptonCheckButton4_Click_1(sender As System.Object, e As System.EventArgs) Handles KryptonCheckButton4.Click
        If CDec(txtidProveedor.Text) > 0 Then
            ConsultaReporteCompraProveedorEstablecimiento(lblPerido.Text)

            KryptonCheckButton1.Checked = False
            KryptonCheckButton2.Checked = False
            KryptonCheckButton3.Checked = False
            KryptonCheckButton5.Checked = False
            KryptonCheckButton4.Checked = True

        Else

            lblEstado.Text = "Debe elegir un proveedor"
            Timer1.Enabled = True
            TiempoEjecutar(5)
            KryptonCheckButton1.Checked = False
            KryptonCheckButton2.Checked = False
            KryptonCheckButton3.Checked = False
            KryptonCheckButton5.Checked = False
            KryptonCheckButton4.Checked = True

        End If
    End Sub

    Private Sub lblPerido_Click(sender As System.Object, e As System.EventArgs) Handles lblPerido.Click

    End Sub

    Private Sub lblPerido_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lblPerido.MouseUp
        Dim p As Point = e.Location
        p.Offset(lblPerido.Bounds.Location)
        ContextMenuStrip1.Show(ToolStrip4.PointToScreen(p))
        cboPeriodo.DroppedDown = True



    End Sub

    Private Sub cboPeriodo_Click(sender As System.Object, e As System.EventArgs) Handles cboPeriodo.Click

    End Sub

    Private Sub cboPeriodo_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboPeriodo.SelectedIndexChanged
        Select Case cboPeriodo.Text
            Case "ENERO"
                lblPerido.Text = "01" & "/" & PeriodoGeneral
            Case "FEBRERO"
                lblPerido.Text = "02" & "/" & PeriodoGeneral
            Case "MARZO"
                lblPerido.Text = "03" & "/" & PeriodoGeneral
            Case "ABRIL"
                lblPerido.Text = "04" & "/" & PeriodoGeneral
            Case "MAYO"
                lblPerido.Text = "05" & "/" & PeriodoGeneral
            Case "JUNIO"
                lblPerido.Text = "06" & "/" & PeriodoGeneral
            Case "JULIO"
                lblPerido.Text = "07" & "/" & PeriodoGeneral
            Case "AGOSTO"
                lblPerido.Text = "08" & "/" & PeriodoGeneral
            Case "SETIEMBRE"
                lblPerido.Text = "09" & "/" & PeriodoGeneral
            Case "OCTUBRE"
                lblPerido.Text = "10" & "/" & PeriodoGeneral
            Case "NOVIEMBRE"
                lblPerido.Text = "11" & "/" & PeriodoGeneral
            Case "DICIEMBRE"
                lblPerido.Text = "12" & "/" & PeriodoGeneral
        End Select

        ContextMenuStrip1.Hide()
    End Sub

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        'Dim fecha As DateTime = New DateTime(PeriodoGeneral, DateTime.Now.Month, DateTime.Now.Day)
        '  lblPerido.Text = lblPerido.Text & "/" & lblPerido.Text.Replace(PeriodoGeneral, PeriodoGeneral)
    End Sub

    Private Sub rptCompras_Load_1(sender As System.Object, e As System.EventArgs) Handles rptCompras.Load

    End Sub

    Private Sub GroupBox2_Enter(sender As System.Object, e As System.EventArgs) Handles GroupBox2.Enter

    End Sub
End Class