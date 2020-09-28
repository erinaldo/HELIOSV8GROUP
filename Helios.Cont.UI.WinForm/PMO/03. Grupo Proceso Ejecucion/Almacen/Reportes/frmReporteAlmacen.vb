Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess

Imports Microsoft.Reporting.WinForms
Imports System.Security
Imports System.Security.Permissions
Public Class frmReporteAlmacen
    Inherits frmMaster

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Dim cfecha As Date = DateTime.Now.Date
        lstProductos.Visible = False
        DateTimePicker1.Visible = False
        DateTimePicker2.Visible = False
        lbldesde.Visible = False
        lblhasta.Visible = False


        lblPerido.Text = String.Format("{0:00}", Convert.ToInt32(cfecha.Month)) & "/" & PeriodoGeneral

        ObtenerAlmacenesCombo(GEstableciento.IdEstablecimiento)
        ObtenerItemsProd(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
        cbotipoexistencia.ComboBox.Visible = False
    End Sub



    Property reportName As String
    Property reportData As Object
    Property subreportData As Object
    Property hasSubReport As Boolean
    Property nombreMainDS As String

#Region "metodos"


    Public Sub ObtenerItemsProd(idempresa As String, idestable As Integer)
        Dim almacenSA As New TotalesAlmacenSA
        cbotipoexistencia.ComboBox.BindingContext = Me.BindingContext
        cbotipoexistencia.ComboBox.ValueMember = "idItem"
        cbotipoexistencia.ComboBox.DisplayMember = "descripcion"
        cbotipoexistencia.ComboBox.FormattingEnabled = True
        cbotipoexistencia.ComboBox.DataSource = almacenSA.GetListaItemsProd(idempresa, idestable)
    End Sub



    Public Sub ObtenerAlmacenesCombo(intIdEstablecimiento As Integer)
        Dim almacenSA As New almacenSA
        cboalmacen.ComboBox.BindingContext = Me.BindingContext
        cboalmacen.ComboBox.ValueMember = "idAlmacen"
        cboalmacen.ComboBox.DisplayMember = "descripcionAlmacen"
        cboalmacen.ComboBox.FormattingEnabled = True
        cboalmacen.ComboBox.DataSource = almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
    End Sub

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

    'almacen detalles

    Public Sub ConsultaAlmacenesDetalle()
        Dim totalesAlmacenSA As New TotalesAlmacenSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.ReporteAlmacenesDetalle.rdlc"
        Me.reportData = totalesAlmacenSA.GetListaAlmacenDetalle(Gempresas.IdEmpresaRuc, CDec(GEstableciento.IdEstablecimiento))
        Me.nombreMainDS = "DSTotAlmacenDet"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCompras.KeepSessionAlive = True
        rptCompras.Reset()
        rptCompras.LocalReport.DataSources.Add(reporte)
        rptCompras.LocalReport.Refresh()
        rptCompras.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCompras.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa))
        oParams.Add(New ReportParameter("rpEstablecimiento", GEstableciento.NombreEstablecimiento))
        rptCompras.LocalReport.SetParameters(oParams)
        rptCompras.RefreshReport()
        rptCompras.SetDisplayMode(DisplayMode.PrintLayout)
        rptCompras.ZoomMode = ZoomMode.Percent
        rptCompras.ZoomPercent = 75
    End Sub


    Public Sub ObetnerListaProductosLST(intIdAlmacen As Integer)
        Dim totalesSA As New TotalesAlmacenSA

        lstProductos.DisplayMember = "descripcion"
        lstProductos.ValueMember = "idItem"
        lstProductos.DataSource = totalesSA.GetListaProductosPorAlmacen(intIdAlmacen)


        lblEstado.Text = "Productos encontrados: " & lstProductos.Items.Count
    End Sub




    Public Sub ConsultaReporte()
        Dim compraSA As New inventarioMovimientoSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Dim prod As String
        prod = lstProductos.Text

        Me.reportName = "Helios.Cont.Presentation.WinForm.ReporteAlmacen.rdlc"
        Me.reportData = compraSA.ObtenerProductosalmacen(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, cboalmacen.ComboBox.SelectedValue, lstProductos.SelectedValue, DateTimePicker1.Value, DateTimePicker2.Value)
        Me.nombreMainDS = "DSAlmacen"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCompras.KeepSessionAlive = True
        rptCompras.Reset()
        rptCompras.LocalReport.DataSources.Add(reporte)
        rptCompras.LocalReport.Refresh()
        rptCompras.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCompras.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa))
        oParams.Add(New ReportParameter("rpEstablecimiento", GEstableciento.NombreEstablecimiento))
        oParams.Add(New ReportParameter("rpAlmacen", cboalmacen.ComboBox.Text))
        oParams.Add(New ReportParameter("rpProducto", prod))
        rptCompras.LocalReport.SetParameters(oParams)
        rptCompras.RefreshReport()
        rptCompras.SetDisplayMode(DisplayMode.PrintLayout)
        rptCompras.ZoomMode = ZoomMode.Percent
        rptCompras.ZoomPercent = 75
    End Sub

    Public Sub ConsultaReportePorEstablec()
        Dim compraSA As New inventarioMovimientoSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.ReporteAlmacenEstablecimiento.rdlc"
        Me.reportData = compraSA.ObtenerProductosalmacenEstablec(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, cboalmacen.ComboBox.SelectedValue, DateTimePicker1.Value, DateTimePicker2.Value)
        Me.nombreMainDS = "DSAlmacen2"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCompras.KeepSessionAlive = True
        rptCompras.Reset()
        rptCompras.LocalReport.DataSources.Add(reporte)
        rptCompras.LocalReport.Refresh()
        rptCompras.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCompras.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa))
        oParams.Add(New ReportParameter("rpEstablecimiento", GEstableciento.NombreEstablecimiento))
        oParams.Add(New ReportParameter("rpAlmacen", cboalmacen.ComboBox.Text))
        rptCompras.LocalReport.SetParameters(oParams)
        rptCompras.RefreshReport()
        rptCompras.SetDisplayMode(DisplayMode.PrintLayout)
        rptCompras.ZoomMode = ZoomMode.Percent
        rptCompras.ZoomPercent = 75
    End Sub


    'martin

    Public Sub ConsultaReporteTotalesAlmacen()
        Dim totalesAlmacenSA As New TotalesAlmacenSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.ReporteTotalesAlmacen.rdlc"
        Me.reportData = totalesAlmacenSA.GetListaProductosPorAlmacen(CDec(cboalmacen.ComboBox.SelectedValue))
        Me.nombreMainDS = "DSTotalesAlmacen"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCompras.KeepSessionAlive = True
        rptCompras.Reset()
        rptCompras.LocalReport.DataSources.Add(reporte)
        rptCompras.LocalReport.Refresh()
        rptCompras.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCompras.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa))
        oParams.Add(New ReportParameter("rpEstablecimiento", GEstableciento.NombreEstablecimiento))
        oParams.Add(New ReportParameter("rpAlmacen", cboalmacen.ComboBox.Text))
        rptCompras.LocalReport.SetParameters(oParams)
        rptCompras.RefreshReport()
        rptCompras.SetDisplayMode(DisplayMode.PrintLayout)
        rptCompras.ZoomMode = ZoomMode.Percent
        rptCompras.ZoomPercent = 75
    End Sub



    'martin
    Public Sub ConsultaReporteTotalesPorItems()
        Dim totalesAlmacenSA As New TotalesAlmacenSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.ReporteAlmacenPorItem.rdlc"
        Me.reportData = totalesAlmacenSA.GetListaProductosPorItems(CDec(cboalmacen.ComboBox.SelectedValue), CDec(cbotipoexistencia.ComboBox.SelectedValue))
        Me.nombreMainDS = "DSTotalesAlmacen2"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCompras.KeepSessionAlive = True
        rptCompras.Reset()
        rptCompras.LocalReport.DataSources.Add(reporte)
        rptCompras.LocalReport.Refresh()
        rptCompras.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCompras.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa))
        oParams.Add(New ReportParameter("rpEstablecimiento", GEstableciento.NombreEstablecimiento))
        oParams.Add(New ReportParameter("rpAlmacen", cboalmacen.ComboBox.Text))
        oParams.Add(New ReportParameter("rpItem", cbotipoexistencia.ComboBox.Text))
        rptCompras.LocalReport.SetParameters(oParams)
        rptCompras.RefreshReport()
        rptCompras.SetDisplayMode(DisplayMode.PrintLayout)
        rptCompras.ZoomMode = ZoomMode.Percent
        rptCompras.ZoomPercent = 75
    End Sub


    'MARTIN GUIA DE REMISION


    Public Sub ConsultaGuiaRemision()
        Dim totalesAlmacenSA As New DocumentoGuiaDetalleSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.ReporteGuiaRemision.rdlc"
        Me.reportData = totalesAlmacenSA.UbicarDocumentoGuiaRemision(Gempresas.IdEmpresaRuc, lblPerido.Text)
        Me.nombreMainDS = "DSGuiaRe"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCompras.KeepSessionAlive = True
        rptCompras.Reset()
        rptCompras.LocalReport.DataSources.Add(reporte)
        rptCompras.LocalReport.Refresh()
        rptCompras.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCompras.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa))
        oParams.Add(New ReportParameter("rpEstablecimiento", GEstableciento.NombreEstablecimiento))
        rptCompras.LocalReport.SetParameters(oParams)
        rptCompras.RefreshReport()
        rptCompras.SetDisplayMode(DisplayMode.PrintLayout)
        rptCompras.ZoomMode = ZoomMode.Percent
        rptCompras.ZoomPercent = 75
    End Sub

#End Region

    Private Sub lstProductos_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub lblAlmacen_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub KryptonCheckButton2_Click(sender As System.Object, e As System.EventArgs) Handles KryptonCheckButton2.Click

        lstProductos.Visible = True
        cbotipoexistencia.ComboBox.Visible = False

        DateTimePicker1.Visible = True
        DateTimePicker2.Visible = True
        lbldesde.Visible = True
        lblhasta.Visible = True


        If cboalmacen.ComboBox.SelectedValue > 0 Then

            If lstProductos.SelectedItems.Count > 0 Then
                ConsultaReporte()
                KryptonCheckButton1.Checked = False
                KryptonCheckButton2.Checked = True
                KryptonCheckButton3.Checked = False
                KryptonCheckButton4.Checked = False
                KryptonCheckButton5.Checked = False
                KryptonCheckButton6.Checked = False
            Else
                lblEstado.Text = "Debe Seleccionar una Existencia"
                Timer1.Enabled = True
                TiempoEjecutar(5)
                KryptonCheckButton1.Checked = False
                KryptonCheckButton2.Checked = True
                KryptonCheckButton3.Checked = False
                KryptonCheckButton4.Checked = False
                KryptonCheckButton5.Checked = False
                KryptonCheckButton6.Checked = False
            End If
        Else
            lblEstado.Text = "Seleccione un Almacen"
            Timer1.Enabled = True
            TiempoEjecutar(5)
            KryptonCheckButton1.Checked = False
            KryptonCheckButton2.Checked = True
            KryptonCheckButton3.Checked = False
            KryptonCheckButton4.Checked = False
            KryptonCheckButton5.Checked = False
            KryptonCheckButton6.Checked = False
        End If
    End Sub

    Private Sub QRibbonCaption1_ItemActivated(sender As System.Object, e As Qios.DevSuite.Components.QCompositeEventArgs)

    End Sub

    Private Sub frmReporteAlmacen_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub KryptonCheckButton1_Click(sender As System.Object, e As System.EventArgs) Handles KryptonCheckButton1.Click
        lstProductos.Visible = False
        cbotipoexistencia.ComboBox.Visible = False

        DateTimePicker1.Visible = True
        DateTimePicker2.Visible = True
        lbldesde.Visible = True
        lblhasta.Visible = True



        If cboalmacen.ComboBox.SelectedValue > 0 Then
            ConsultaReportePorEstablec()
            KryptonCheckButton1.Checked = True
            KryptonCheckButton2.Checked = False
            KryptonCheckButton3.Checked = False
            KryptonCheckButton4.Checked = False
            KryptonCheckButton5.Checked = False
            KryptonCheckButton6.Checked = False




        Else
            lblEstado.Text = "Debe Seleccionar un Almacen"
            Timer1.Enabled = True
            TiempoEjecutar(5)
            KryptonCheckButton1.Checked = True
            KryptonCheckButton2.Checked = False
            KryptonCheckButton3.Checked = False
            KryptonCheckButton4.Checked = False
            KryptonCheckButton5.Checked = False
            KryptonCheckButton6.Checked = False
        End If

    End Sub

    Private Sub KryptonCheckButton3_Click(sender As System.Object, e As System.EventArgs) Handles KryptonCheckButton3.Click
        lstProductos.Visible = False
        cbotipoexistencia.ComboBox.Visible = False

        DateTimePicker1.Visible = False
        DateTimePicker2.Visible = False
        lbldesde.Visible = False
        lblhasta.Visible = False



        If cboalmacen.ComboBox.SelectedValue > 0 Then
            ConsultaReporteTotalesAlmacen()
            KryptonCheckButton1.Checked = False
            KryptonCheckButton2.Checked = False
            KryptonCheckButton3.Checked = True
            KryptonCheckButton4.Checked = False
            KryptonCheckButton5.Checked = False
            KryptonCheckButton6.Checked = False

        Else
            lblEstado.Text = "Debe Seleccionar un Almacen"
            Timer1.Enabled = True
            TiempoEjecutar(5)
            KryptonCheckButton1.Checked = False
            KryptonCheckButton2.Checked = False
            KryptonCheckButton3.Checked = True
            KryptonCheckButton4.Checked = False
            KryptonCheckButton5.Checked = False
            KryptonCheckButton6.Checked = False

        End If
    End Sub

    Private Sub KryptonCheckButton4_Click(sender As System.Object, e As System.EventArgs) Handles KryptonCheckButton4.Click
        lstProductos.Visible = False
        cbotipoexistencia.ComboBox.Visible = True


        DateTimePicker1.Visible = False
        DateTimePicker2.Visible = False
        lbldesde.Visible = False
        lblhasta.Visible = False


        If cbotipoexistencia.ComboBox.SelectedValue > 0 Then
            If cboalmacen.ComboBox.SelectedValue > 0 Then
                ConsultaReporteTotalesPorItems()
                KryptonCheckButton1.Checked = False
                KryptonCheckButton2.Checked = False
                KryptonCheckButton3.Checked = False
                KryptonCheckButton4.Checked = True
                KryptonCheckButton5.Checked = False
                KryptonCheckButton6.Checked = False

            Else
                lblEstado.Text = "Debe Seleccionar un Almacen"
                Timer1.Enabled = True
                TiempoEjecutar(5)
                KryptonCheckButton1.Checked = False
                KryptonCheckButton2.Checked = False
                KryptonCheckButton3.Checked = False
                KryptonCheckButton4.Checked = True
                KryptonCheckButton5.Checked = False
                KryptonCheckButton6.Checked = False

            End If

        Else
            lblEstado.Text = "Debe Seleccionar un Tipo de Existencia"
            Timer1.Enabled = True
            TiempoEjecutar(5)
            KryptonCheckButton1.Checked = False
            KryptonCheckButton2.Checked = False
            KryptonCheckButton3.Checked = False
            KryptonCheckButton4.Checked = True
            KryptonCheckButton5.Checked = False
            KryptonCheckButton6.Checked = False

        End If
    End Sub

    Private Sub Label3_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub ToolStripLabel1_Click(sender As System.Object, e As System.EventArgs)

        With FrmProdItems
            .ObtenerItemsProd(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
            .StartPosition = FormStartPosition.CenterParent

            .ShowDialog()
            'If datos.Count > 0 Then
            '    lblIdAlmacen.Text = datos(0).ID
            '    lblAlmacen.Text = datos(0).NombreEntidad
            '    ObetnerListaProductosLST(lblIdAlmacen.Text)
            'End If
        End With
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As System.Object, e As System.EventArgs) Handles DateTimePicker1.ValueChanged

        If KryptonCheckButton2.Checked = True Then
            If cboalmacen.ComboBox.SelectedValue > 0 Then
                If lstProductos.SelectedItems.Count > 0 Then
                    ConsultaReporte()
                    KryptonCheckButton1.Checked = False
                    KryptonCheckButton2.Checked = True
                    KryptonCheckButton3.Checked = False
                    KryptonCheckButton4.Checked = False
                Else
                    lblEstado.Text = "Debe Seleccionar una Existencia"
                    Timer1.Enabled = True
                    TiempoEjecutar(5)
                    KryptonCheckButton1.Checked = False
                    KryptonCheckButton2.Checked = True
                    KryptonCheckButton3.Checked = False
                    KryptonCheckButton4.Checked = False
                End If
            Else
                lblEstado.Text = "Seleccione un Almacen"
                Timer1.Enabled = True
                TiempoEjecutar(5)
                KryptonCheckButton1.Checked = False
                KryptonCheckButton2.Checked = True
            End If



        ElseIf KryptonCheckButton1.Checked = True Then
            If cboalmacen.ComboBox.SelectedValue > 0 Then
                ConsultaReportePorEstablec()
                KryptonCheckButton1.Checked = True
                KryptonCheckButton2.Checked = False
                KryptonCheckButton3.Checked = False
                KryptonCheckButton4.Checked = False
            Else
                lblEstado.Text = "Debe Seleccionar un Almacen"
                Timer1.Enabled = True
                TiempoEjecutar(5)
                KryptonCheckButton1.Checked = True
                KryptonCheckButton2.Checked = False
                KryptonCheckButton3.Checked = False
                KryptonCheckButton4.Checked = False
            End If
        End If
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As System.Object, e As System.EventArgs) Handles DateTimePicker2.ValueChanged
        If KryptonCheckButton2.Checked = True Then
            If cboalmacen.ComboBox.SelectedValue > 0 Then
                If lstProductos.SelectedItems.Count > 0 Then
                    ConsultaReporte()
                    KryptonCheckButton1.Checked = False
                    KryptonCheckButton2.Checked = True
                    KryptonCheckButton3.Checked = False
                    KryptonCheckButton4.Checked = False
                Else
                    lblEstado.Text = "Debe Seleccionar una Existencia"
                    Timer1.Enabled = True
                    TiempoEjecutar(5)
                    KryptonCheckButton1.Checked = False
                    KryptonCheckButton2.Checked = True
                    KryptonCheckButton3.Checked = False
                    KryptonCheckButton4.Checked = False
                End If
            Else
                lblEstado.Text = "Seleccione un Almacen"
                Timer1.Enabled = True
                TiempoEjecutar(5)
                KryptonCheckButton1.Checked = False
                KryptonCheckButton2.Checked = True
            End If

        ElseIf KryptonCheckButton1.Checked = True Then
            If cboalmacen.ComboBox.SelectedValue > 0 Then
                ConsultaReportePorEstablec()
                KryptonCheckButton1.Checked = True
                KryptonCheckButton2.Checked = False
                KryptonCheckButton3.Checked = False
                KryptonCheckButton4.Checked = False
            Else
                lblEstado.Text = "Debe Seleccionar un Almacen"
                Timer1.Enabled = True
                TiempoEjecutar(5)
                KryptonCheckButton1.Checked = True
                KryptonCheckButton2.Checked = False
                KryptonCheckButton3.Checked = False
                KryptonCheckButton4.Checked = False
            End If
        End If
    End Sub

    Private Sub KryptonCheckButton5_Click(sender As System.Object, e As System.EventArgs) Handles KryptonCheckButton5.Click
        lstProductos.Visible = False
        cbotipoexistencia.ComboBox.Visible = False

        ConsultaGuiaRemision()
        KryptonCheckButton1.Checked = False
        KryptonCheckButton2.Checked = False
        KryptonCheckButton3.Checked = False
        KryptonCheckButton4.Checked = False
        KryptonCheckButton5.Checked = True
        KryptonCheckButton6.Checked = False
    End Sub

    Private Sub KryptonCheckButton6_Click(sender As System.Object, e As System.EventArgs) Handles KryptonCheckButton6.Click
        ConsultaAlmacenesDetalle()
        cbotipoexistencia.ComboBox.Visible = False
        KryptonCheckButton1.Checked = False
        KryptonCheckButton2.Checked = False
        KryptonCheckButton3.Checked = False
        KryptonCheckButton4.Checked = False
        KryptonCheckButton5.Checked = False
        KryptonCheckButton6.Checked = True
    End Sub

    Private Sub frmReporteAlmacen_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
       
    End Sub

    Private Sub cboalmacen_Click(sender As System.Object, e As System.EventArgs) Handles cboalmacen.Click

    End Sub

    Private Sub cboalmacen_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboalmacen.SelectedIndexChanged
        If CDec(cboalmacen.ComboBox.SelectedValue) > 0 Then
            ObetnerListaProductosLST(cboalmacen.ComboBox.SelectedValue)
            If KryptonCheckButton2.Checked = True Then
                lstProductos.Visible = True
            End If
            If KryptonCheckButton2.Checked = True Then   'martin
                ConsultaReporte()
                DateTimePicker1.Visible = True
                DateTimePicker2.Visible = True
            ElseIf (KryptonCheckButton1.Checked = True) Then
                ConsultaReportePorEstablec()
                DateTimePicker1.Visible = True
                DateTimePicker2.Visible = True
            ElseIf (KryptonCheckButton3.Checked = True) Then
                DateTimePicker1.Visible = False
                DateTimePicker2.Visible = False
                ConsultaReporteTotalesAlmacen()
            ElseIf (KryptonCheckButton4.Checked = True) Then
                DateTimePicker1.Visible = False
                DateTimePicker2.Visible = False
                If cbotipoexistencia.ComboBox.SelectedValue > 0 Then
                    ConsultaReporteTotalesPorItems()
                End If
            End If
        End If
    End Sub

    Private Sub cbotipoexistencia_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub cbotipoexistencia_SelectedIndexChanged(sender As Object, e As System.EventArgs)

    End Sub

    Private Sub cbotipoexistencia_Click_1(sender As System.Object, e As System.EventArgs) Handles cbotipoexistencia.Click

    End Sub

    Private Sub cbotipoexistencia_SelectedIndexChanged1(sender As Object, e As System.EventArgs) Handles cbotipoexistencia.SelectedIndexChanged
        If KryptonCheckButton4.Checked = True Then
            If cbotipoexistencia.ComboBox.SelectedValue > 0 Then
                ConsultaReporteTotalesPorItems()
            End If
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

    Private Sub cboPeriodo_RightToLeftChanged(sender As Object, e As System.EventArgs) Handles cboPeriodo.RightToLeftChanged

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

    Private Sub ToolStrip4_ItemClicked(sender As System.Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolStrip4.ItemClicked

    End Sub
End Class