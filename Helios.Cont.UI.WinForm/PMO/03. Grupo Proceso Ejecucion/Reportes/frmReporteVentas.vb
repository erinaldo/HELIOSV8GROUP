Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess

'martin
Imports Microsoft.Reporting.WinForms
Imports System.Security
Imports System.Security.Permissions
Public Class frmReporteVentas

    Property reportName As String
    Property reportData As Object
    Property subreportData As Object
    Property hasSubReport As Boolean
    Property nombreMainDS As String

#Region "metodos"

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

    'CLIENTES
    Sub ClientesShows()
        Me.Cursor = Cursors.WaitCursor
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        datos.Clear()
        'With frmModalEntidades
        '    .lblTipo.Text = "CL"
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        '    If datos.Count > 0 Then
        '        txtidCliente.Text = datos(0).ID
        '        txtCliente.Text = datos(0).Appat
        '        txtCliente.Focus()
        '    Else
        '        txtidCliente.Text = String.Empty
        '        txtCliente.Text = String.Empty
        '        txtCliente.Focus()
        '    End If
        'End With

        Me.Cursor = Cursors.Arrow
    End Sub


    'reporte por periodo empresa estableciemineto
    Public Sub ConsultaReporte(strPeriodo As String)
        Dim compraSA As New documentoVentaRPTSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.RegistroVentaAbarrotes.rdlc"
        Me.reportData = compraSA.OntenerListadoVentasAbarrotesPorPeriodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, strPeriodo)
        Me.nombreMainDS = "DSVentas"
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


    ' venta de abarrotes por empresa

    Public Sub ConsultaReporteVentasEmpresa(strPeriodo As String)
        Dim compraSA As New documentoVentaRPTSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.RegistroVentaAbarrotesEmpresa.rdlc"
        Me.reportData = compraSA.OntenerListadoVentasAbarrotesPorEmpresa(Gempresas.IdEmpresaRuc, strPeriodo)
        Me.nombreMainDS = "DSVenta2"

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

    'reporte por periodo empresa Cliente
    Public Sub ConsultaReporteCliente(strPeriodo As String)
        Dim compraSA As New documentoVentaRPTSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.RegistroVentaAbarrotesCliente.rdlc"
        Me.reportData = compraSA.OntenerListadoVentasAbarrotesPorCliente(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, strPeriodo, CDec(txtidCliente.Text))
        Me.nombreMainDS = "DSVenta3"

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
        oParams.Add(New ReportParameter("rpCliente", txtCliente.Text))
        rptCompras.LocalReport.SetParameters(oParams)
        rptCompras.RefreshReport()
        rptCompras.SetDisplayMode(DisplayMode.PrintLayout)
        rptCompras.ZoomMode = ZoomMode.Percent
        rptCompras.ZoomPercent = 75
    End Sub

#End Region
    Private Sub frmReporteVentas_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub KryptonCheckButton2_Click(sender As System.Object, e As System.EventArgs) Handles KryptonCheckButton2.Click
        ConsultaReporte(lblPerido.Text)


        KryptonCheckButton2.Checked = True
        KryptonCheckButton1.Checked = False
        KryptonCheckButton3.Checked = False
        
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

    Private Sub KryptonCheckButton1_Click(sender As System.Object, e As System.EventArgs) Handles KryptonCheckButton1.Click
        ConsultaReporteVentasEmpresa(lblPerido.Text)

        KryptonCheckButton1.Checked = True
        KryptonCheckButton2.Checked = False
        KryptonCheckButton3.Checked = False
    End Sub

    Private Sub KryptonCheckButton3_Click(sender As System.Object, e As System.EventArgs) Handles KryptonCheckButton3.Click
        If CDec(txtidCliente.Text) > 0 Then

            ConsultaReporteCliente(lblPerido.Text)
            KryptonCheckButton3.Checked = True
            KryptonCheckButton1.Checked = False
            KryptonCheckButton2.Checked = False
        Else
            lblEstado.Text = "Debe elegir un cliente"
            Timer1.Enabled = True
            TiempoEjecutar(5)
            KryptonCheckButton3.Checked = True
            KryptonCheckButton1.Checked = False
            KryptonCheckButton2.Checked = False
        End If
    End Sub

    Private Sub LinkProveedor_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkProveedor.LinkClicked
        ClientesShows()
    End Sub
End Class