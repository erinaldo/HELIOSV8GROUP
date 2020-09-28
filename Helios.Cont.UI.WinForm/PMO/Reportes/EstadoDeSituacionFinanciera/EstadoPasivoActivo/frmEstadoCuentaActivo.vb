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

Public Class frmEstadoCuentaActivo
    Inherits frmMaster

    Property reportName As String
    Property reportData As Object
    Property subreportData As Object
    Property hasSubReport As Boolean
    Property nombreMainDS As String

#Region "Metodos"

    Public Sub ReportesMensualesPorCuenta(FechaInicio As Date, FechaFin As Date)


        'Dim FechaAct As DateTime
        'FechaAct = Format(Now, anioPeriodo & "-" & mesPeriodo & "-01")
        'Dim periodo_Actual = String.Format("{0:00}", FechaAct.Month) & "/" & FechaAct.Year

        If LblTipoCuenta.Text = "10" Then
            ConsultaCuenta10Mensual(FechaFin.Year, FechaFin.Month)
        ElseIf LblTipoCuenta.Text = "11" Then
            ConsultaCuenta11y18Mensual("11", FechaInicio, FechaFin)
        ElseIf LblTipoCuenta.Text = "12" Then
            ConsultaCuenta12Mensual(FechaInicio, FechaFin)
        ElseIf LblTipoCuenta.Text = "13" Then
            ConsultaCuenta13Mensual(FechaInicio, FechaFin)
        ElseIf LblTipoCuenta.Text = "123133" Then
            ConsultaCuenta123133Mensual(FechaInicio, FechaFin)
        ElseIf LblTipoCuenta.Text = "14" Then
            ConsultaCuenta14Mensual(FechaInicio, FechaFin)
        ElseIf LblTipoCuenta.Text = "16" Then
            ConsultaCuenta16Mensual(FechaInicio, FechaFin)
        ElseIf LblTipoCuenta.Text = "17" Then
            ConsultaPorCuentaMensual("17", FechaInicio, FechaFin)
        ElseIf LblTipoCuenta.Text = "19" Then
            ConsultaPorCuentaInversaMensual("19", FechaInicio, FechaFin)
        ElseIf LblTipoCuenta.Text = "18" Then
            'ConsultaPorCuenta("18")
            ConsultaCuenta11y18Mensual("18", FechaInicio, FechaFin)
        ElseIf LblTipoCuenta.Text = "422" Then
            ConsultaCuenta422Mensual("CVR", "422", FechaInicio, FechaFin)
        ElseIf LblTipoCuenta.Text = "432" Then
            ConsultaCuenta432Mensual("CVO", "432", FechaInicio, FechaFin)
        ElseIf LblTipoCuenta.Text = "1413-1433-1443-1681" Then
            ConsultaCuenta1413Mensual(FechaInicio, FechaFin)
        ElseIf LblTipoCuenta.Text = "20-21-22-23-24-25-26-27-28" Then
            'ConsultaCuenta20al28()
            ConsultaCuenta20(FechaFin)
        ElseIf LblTipoCuenta.Text = "29" Then
            ConsultaPorCuentaInversaMensual("29", FechaInicio, FechaFin)
        ElseIf LblTipoCuenta.Text = "30-31-32-33-34-35-37-38" Then
            ConsultaCuenta30al38Mensual(FechaInicio, FechaFin)
        ElseIf LblTipoCuenta.Text = "36" Then
            ConsultaPorCuentaInversaMensual("36", FechaInicio, FechaFin)
        ElseIf LblTipoCuenta.Text = "39" Then
            ConsultaPorCuentaInversaMensual("39", FechaInicio, FechaFin)
        ElseIf LblTipoCuenta.Text = "40" Then

            ConsultaCuenta40Mensual("C", FechaInicio, FechaFin)
        ElseIf LblTipoCuenta.Text = "40111" Then
            '    'no reporte


        End If
    End Sub

    'Public Sub años()
    '    Dim AniosSA As New empresaPeriodoSA
    '    cboAnios.DisplayMember = "periodo"
    '    cboAnios.ValueMember = "periodo"
    '    cboAnios.DataSource = AniosSA.GetListar_empresaPeriodo(Gempresas.IdEmpresaRuc)
    '    cboAnios.Text = AnioGeneral

    '    cboMes.SelectedIndex = DateTime.Now.Month - 1
    'End Sub

    Public Sub ConsultaCuenta10Mensual(ByVal anioPeriodo As String, ByVal mesPeriodo As String)
        Dim libroSA As New DocumentoCajaSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.rptEstadoCuenta10.rdlc"
        Me.reportData = libroSA.ObtenerCajaOnlineMensual(anioPeriodo, mesPeriodo, Gempresas.IdEmpresaRuc)
        Me.nombreMainDS = "DsCaja"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCuentaActivo.KeepSessionAlive = True
        rptCuentaActivo.Reset()
        rptCuentaActivo.LocalReport.DataSources.Add(reporte)
        rptCuentaActivo.LocalReport.Refresh()
        rptCuentaActivo.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCuentaActivo.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpTItulo", LblCabezera.Text))
        ' oParams.Add(New ReportParameter("rpAnio", "al - " & FormatDateTime(DateTime.Now, DateFormat.ShortDate)))
        rptCuentaActivo.LocalReport.SetParameters(oParams)
        rptCuentaActivo.RefreshReport()
        rptCuentaActivo.SetDisplayMode(DisplayMode.PrintLayout)
        rptCuentaActivo.ZoomMode = ZoomMode.Percent
        rptCuentaActivo.ZoomPercent = 75
    End Sub


    Public Sub ConsultaCuenta10(cuenta As String)
        Dim libroSA As New DocumentoCajaSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.rptEstadoCuenta10.rdlc"
        Me.reportData = libroSA.ObtenerCajaOnlineAnual(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
        Me.nombreMainDS = "DsCaja"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCuentaActivo.KeepSessionAlive = True
        rptCuentaActivo.Reset()
        rptCuentaActivo.LocalReport.DataSources.Add(reporte)
        rptCuentaActivo.LocalReport.Refresh()
        rptCuentaActivo.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCuentaActivo.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpTItulo", LblCabezera.Text))
        ' oParams.Add(New ReportParameter("rpAnio", "al - " & FormatDateTime(DateTime.Now, DateFormat.ShortDate)))
        rptCuentaActivo.LocalReport.SetParameters(oParams)
        rptCuentaActivo.RefreshReport()
        rptCuentaActivo.SetDisplayMode(DisplayMode.PrintLayout)
        rptCuentaActivo.ZoomMode = ZoomMode.Percent
        rptCuentaActivo.ZoomPercent = 75
    End Sub

    Public Sub ConsultaCuenta11y18(cuenta As String)
        Dim libroSA As New documentoLibroDiarioSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.rptEstadoCuentaActivo.rdlc"
        Me.reportData = libroSA.GetListaEstadoCuenta11y18(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, cuenta)
        Me.nombreMainDS = "DsActivo"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCuentaActivo.KeepSessionAlive = True
        rptCuentaActivo.Reset()
        rptCuentaActivo.LocalReport.DataSources.Add(reporte)
        rptCuentaActivo.LocalReport.Refresh()
        rptCuentaActivo.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCuentaActivo.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpTItulo", LblCabezera.Text))
        ' oParams.Add(New ReportParameter("rpAnio", "al - " & FormatDateTime(DateTime.Now, DateFormat.ShortDate)))
        rptCuentaActivo.LocalReport.SetParameters(oParams)
        rptCuentaActivo.RefreshReport()
        rptCuentaActivo.SetDisplayMode(DisplayMode.PrintLayout)
        rptCuentaActivo.ZoomMode = ZoomMode.Percent
        rptCuentaActivo.ZoomPercent = 75
    End Sub

    Public Sub ConsultaCuenta11y18Mensual(cuenta As String, FechaInicio As Date, FechaFin As String)
        Dim libroSA As New documentoLibroDiarioSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.rptEstadoCuentaActivo.rdlc"
        Me.reportData = libroSA.GetListaEstadoCuenta11y18Mensual(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, cuenta, FechaInicio, FechaFin)
        Me.nombreMainDS = "DsActivo"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCuentaActivo.KeepSessionAlive = True
        rptCuentaActivo.Reset()
        rptCuentaActivo.LocalReport.DataSources.Add(reporte)
        rptCuentaActivo.LocalReport.Refresh()
        rptCuentaActivo.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCuentaActivo.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpTItulo", LblCabezera.Text))
        ' oParams.Add(New ReportParameter("rpAnio", "al - " & FormatDateTime(DateTime.Now, DateFormat.ShortDate)))
        rptCuentaActivo.LocalReport.SetParameters(oParams)
        rptCuentaActivo.RefreshReport()
        rptCuentaActivo.SetDisplayMode(DisplayMode.PrintLayout)
        rptCuentaActivo.ZoomMode = ZoomMode.Percent
        rptCuentaActivo.ZoomPercent = 75
    End Sub



    Public Sub ConsultaCuenta20(FechaFin As Date)
        Dim DocumentoCompraSA As New TotalesAlmacenSA

        Dim NuevoPeriodo As String

        NuevoPeriodo = String.Format("{0:00}", FechaFin.Date.Month) & FechaFin.Date.Year




        Me.reportName = "Helios.Cont.Presentation.WinForm.rptEstadoCuenta20.rdlc"
        Me.reportData = DocumentoCompraSA.GetUbicar_EstadoCuenta20(Gempresas.IdEmpresaRuc, NuevoPeriodo)
        Me.nombreMainDS = "DsCuenta20"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCuentaActivo.KeepSessionAlive = True
        rptCuentaActivo.Reset()
        rptCuentaActivo.LocalReport.DataSources.Add(reporte)
        rptCuentaActivo.LocalReport.Refresh()
        rptCuentaActivo.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCuentaActivo.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpTItulo", LblCabezera.Text))
        ' oParams.Add(New ReportParameter("rpAnio", "al - " & FormatDateTime(DateTime.Now, DateFormat.ShortDate)))
        rptCuentaActivo.LocalReport.SetParameters(oParams)
        rptCuentaActivo.RefreshReport()
        rptCuentaActivo.SetDisplayMode(DisplayMode.PrintLayout)
        rptCuentaActivo.ZoomMode = ZoomMode.Percent
        rptCuentaActivo.ZoomPercent = 75
    End Sub

    Public Sub ConsultaCuenta432Mensual(tipoAnticipo As String, cuenta As String, FechaIncio As Date, FechaFin As Date)
        Dim libroSA As New documentoLibroDiarioSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.rptEstadoCuentaActivo.rdlc"
        Me.reportData = libroSA.GetListaEstadoCuenta432Mensual(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, tipoAnticipo, cuenta, FechaIncio, FechaFin)
        Me.nombreMainDS = "DsActivo"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCuentaActivo.KeepSessionAlive = True
        rptCuentaActivo.Reset()
        rptCuentaActivo.LocalReport.DataSources.Add(reporte)
        rptCuentaActivo.LocalReport.Refresh()
        rptCuentaActivo.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCuentaActivo.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpTItulo", LblCabezera.Text))
        ' oParams.Add(New ReportParameter("rpAnio", "al - " & FormatDateTime(DateTime.Now, DateFormat.ShortDate)))
        rptCuentaActivo.LocalReport.SetParameters(oParams)
        rptCuentaActivo.RefreshReport()
        rptCuentaActivo.SetDisplayMode(DisplayMode.PrintLayout)
        rptCuentaActivo.ZoomMode = ZoomMode.Percent
        rptCuentaActivo.ZoomPercent = 75
    End Sub


    Public Sub ConsultaCuenta432(tipoAnticipo As String, cuenta As String)
        Dim libroSA As New documentoLibroDiarioSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.rptEstadoCuentaActivo.rdlc"
        Me.reportData = libroSA.GetListaEstadoCuenta432(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, tipoAnticipo, cuenta)
        Me.nombreMainDS = "DsActivo"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCuentaActivo.KeepSessionAlive = True
        rptCuentaActivo.Reset()
        rptCuentaActivo.LocalReport.DataSources.Add(reporte)
        rptCuentaActivo.LocalReport.Refresh()
        rptCuentaActivo.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCuentaActivo.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpTItulo", LblCabezera.Text))
        ' oParams.Add(New ReportParameter("rpAnio", "al - " & FormatDateTime(DateTime.Now, DateFormat.ShortDate)))
        rptCuentaActivo.LocalReport.SetParameters(oParams)
        rptCuentaActivo.RefreshReport()
        rptCuentaActivo.SetDisplayMode(DisplayMode.PrintLayout)
        rptCuentaActivo.ZoomMode = ZoomMode.Percent
        rptCuentaActivo.ZoomPercent = 75
    End Sub


    Public Sub ConsultaCuenta422Mensual(tipoAnticipo As String, cuenta As String, FechaInicio As Date, FechaFin As Date)
        Dim libroSA As New documentoLibroDiarioSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.rptEstadoCuentaActivo.rdlc"
        Me.reportData = libroSA.GetListaEstadoCuenta422Mensual(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, tipoAnticipo, cuenta, FechaInicio, FechaFin)
        Me.nombreMainDS = "DsActivo"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCuentaActivo.KeepSessionAlive = True
        rptCuentaActivo.Reset()
        rptCuentaActivo.LocalReport.DataSources.Add(reporte)
        rptCuentaActivo.LocalReport.Refresh()
        rptCuentaActivo.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCuentaActivo.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpTItulo", LblCabezera.Text))
        ' oParams.Add(New ReportParameter("rpAnio", "al - " & FormatDateTime(DateTime.Now, DateFormat.ShortDate)))
        rptCuentaActivo.LocalReport.SetParameters(oParams)
        rptCuentaActivo.RefreshReport()
        rptCuentaActivo.SetDisplayMode(DisplayMode.PrintLayout)
        rptCuentaActivo.ZoomMode = ZoomMode.Percent
        rptCuentaActivo.ZoomPercent = 75
    End Sub

    Public Sub ConsultaCuenta422(tipoAnticipo As String, cuenta As String)
        Dim libroSA As New documentoLibroDiarioSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.rptEstadoCuentaActivo.rdlc"
        Me.reportData = libroSA.GetListaEstadoCuenta422(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, tipoAnticipo, cuenta)
        Me.nombreMainDS = "DsActivo"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCuentaActivo.KeepSessionAlive = True
        rptCuentaActivo.Reset()
        rptCuentaActivo.LocalReport.DataSources.Add(reporte)
        rptCuentaActivo.LocalReport.Refresh()
        rptCuentaActivo.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCuentaActivo.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpTItulo", LblCabezera.Text))
        ' oParams.Add(New ReportParameter("rpAnio", "al - " & FormatDateTime(DateTime.Now, DateFormat.ShortDate)))
        rptCuentaActivo.LocalReport.SetParameters(oParams)
        rptCuentaActivo.RefreshReport()
        rptCuentaActivo.SetDisplayMode(DisplayMode.PrintLayout)
        rptCuentaActivo.ZoomMode = ZoomMode.Percent
        rptCuentaActivo.ZoomPercent = 75
    End Sub

    Public Sub ConsultaCuenta122(tipoAnticipo As String, cuenta As String)
        Dim libroSA As New documentoLibroDiarioSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.rptEstadoCuentaActivo.rdlc"
        Me.reportData = libroSA.GetListaEstadoCuenta122(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, tipoAnticipo, cuenta)
        Me.nombreMainDS = "DsActivo"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCuentaActivo.KeepSessionAlive = True
        rptCuentaActivo.Reset()
        rptCuentaActivo.LocalReport.DataSources.Add(reporte)
        rptCuentaActivo.LocalReport.Refresh()
        rptCuentaActivo.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCuentaActivo.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpTItulo", LblCabezera.Text))
        ' oParams.Add(New ReportParameter("rpAnio", "al - " & FormatDateTime(DateTime.Now, DateFormat.ShortDate)))
        rptCuentaActivo.LocalReport.SetParameters(oParams)
        rptCuentaActivo.RefreshReport()
        rptCuentaActivo.SetDisplayMode(DisplayMode.PrintLayout)
        rptCuentaActivo.ZoomMode = ZoomMode.Percent
        rptCuentaActivo.ZoomPercent = 75
    End Sub


    Public Sub ConsultaCuenta40Mensual(tipo As String, FechaInicio As Date, FechaFin As Date)
        Dim libroSA As New documentoLibroDiarioSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.rptEstadoCuentaActivo.rdlc"
        Me.reportData = libroSA.GetUbicar_EstadoCuenta40Mensual(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, tipo, FechaInicio, FechaFin)
        Me.nombreMainDS = "DsActivo"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCuentaActivo.KeepSessionAlive = True
        rptCuentaActivo.Reset()
        rptCuentaActivo.LocalReport.DataSources.Add(reporte)
        rptCuentaActivo.LocalReport.Refresh()
        rptCuentaActivo.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCuentaActivo.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpTItulo", LblCabezera.Text))
        ' oParams.Add(New ReportParameter("rpAnio", "al - " & FormatDateTime(DateTime.Now, DateFormat.ShortDate)))
        rptCuentaActivo.LocalReport.SetParameters(oParams)
        rptCuentaActivo.RefreshReport()
        rptCuentaActivo.SetDisplayMode(DisplayMode.PrintLayout)
        rptCuentaActivo.ZoomMode = ZoomMode.Percent
        rptCuentaActivo.ZoomPercent = 75
    End Sub

    Public Sub ConsultaCuenta40(tipo As String)
        Dim libroSA As New documentoLibroDiarioSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.rptEstadoCuentaActivo.rdlc"
        Me.reportData = libroSA.GetUbicar_EstadoCuenta40(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, tipo)
        Me.nombreMainDS = "DsActivo"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCuentaActivo.KeepSessionAlive = True
        rptCuentaActivo.Reset()
        rptCuentaActivo.LocalReport.DataSources.Add(reporte)
        rptCuentaActivo.LocalReport.Refresh()
        rptCuentaActivo.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCuentaActivo.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpTItulo", LblCabezera.Text))
        ' oParams.Add(New ReportParameter("rpAnio", "al - " & FormatDateTime(DateTime.Now, DateFormat.ShortDate)))
        rptCuentaActivo.LocalReport.SetParameters(oParams)
        rptCuentaActivo.RefreshReport()
        rptCuentaActivo.SetDisplayMode(DisplayMode.PrintLayout)
        rptCuentaActivo.ZoomMode = ZoomMode.Percent
        rptCuentaActivo.ZoomPercent = 75
    End Sub


    Public Sub ConsultaCuenta30al38Mensual(FechaInicio As Date, FechaFin As Date)
        Dim libroSA As New documentoLibroDiarioSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.rptEstadoCuentaActivo.rdlc"
        Me.reportData = libroSA.GetUbicar_EstadoCuenta30al38Mensual(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, FechaInicio, FechaFin)
        Me.nombreMainDS = "DsActivo"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCuentaActivo.KeepSessionAlive = True
        rptCuentaActivo.Reset()
        rptCuentaActivo.LocalReport.DataSources.Add(reporte)
        rptCuentaActivo.LocalReport.Refresh()
        rptCuentaActivo.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCuentaActivo.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpTItulo", LblCabezera.Text))
        ' oParams.Add(New ReportParameter("rpAnio", "al - " & FormatDateTime(DateTime.Now, DateFormat.ShortDate)))
        rptCuentaActivo.LocalReport.SetParameters(oParams)
        rptCuentaActivo.RefreshReport()
        rptCuentaActivo.SetDisplayMode(DisplayMode.PrintLayout)
        rptCuentaActivo.ZoomMode = ZoomMode.Percent
        rptCuentaActivo.ZoomPercent = 75
    End Sub

    Public Sub ConsultaCuenta30al38()
        Dim libroSA As New documentoLibroDiarioSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.rptEstadoCuentaActivo.rdlc"
        Me.reportData = libroSA.GetUbicar_EstadoCuenta30al38(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
        Me.nombreMainDS = "DsActivo"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCuentaActivo.KeepSessionAlive = True
        rptCuentaActivo.Reset()
        rptCuentaActivo.LocalReport.DataSources.Add(reporte)
        rptCuentaActivo.LocalReport.Refresh()
        rptCuentaActivo.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCuentaActivo.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpTItulo", LblCabezera.Text))
        ' oParams.Add(New ReportParameter("rpAnio", "al - " & FormatDateTime(DateTime.Now, DateFormat.ShortDate)))
        rptCuentaActivo.LocalReport.SetParameters(oParams)
        rptCuentaActivo.RefreshReport()
        rptCuentaActivo.SetDisplayMode(DisplayMode.PrintLayout)
        rptCuentaActivo.ZoomMode = ZoomMode.Percent
        rptCuentaActivo.ZoomPercent = 75
    End Sub


    Public Sub ConsultaCuenta20al28()
        Dim libroSA As New documentoLibroDiarioSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.rptEstadoCuentaActivo.rdlc"
        Me.reportData = libroSA.GetUbicar_EstadoCuenta20al28(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
        Me.nombreMainDS = "DsActivo"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCuentaActivo.KeepSessionAlive = True
        rptCuentaActivo.Reset()
        rptCuentaActivo.LocalReport.DataSources.Add(reporte)
        rptCuentaActivo.LocalReport.Refresh()
        rptCuentaActivo.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCuentaActivo.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpTItulo", LblCabezera.Text))
        ' oParams.Add(New ReportParameter("rpAnio", "al - " & FormatDateTime(DateTime.Now, DateFormat.ShortDate)))
        rptCuentaActivo.LocalReport.SetParameters(oParams)
        rptCuentaActivo.RefreshReport()
        rptCuentaActivo.SetDisplayMode(DisplayMode.PrintLayout)
        rptCuentaActivo.ZoomMode = ZoomMode.Percent
        rptCuentaActivo.ZoomPercent = 75
    End Sub

    Public Sub ConsultaCuenta1413Mensual(FechaInicio As Date, FechaFin As Date)
        Dim libroSA As New documentoLibroDiarioSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.rptEstadoCuentaActivo.rdlc"
        Me.reportData = libroSA.GetUbicar_EstadoCuenta1413Mensual(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, FechaInicio, FechaFin)
        Me.nombreMainDS = "DsActivo"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCuentaActivo.KeepSessionAlive = True
        rptCuentaActivo.Reset()
        rptCuentaActivo.LocalReport.DataSources.Add(reporte)
        rptCuentaActivo.LocalReport.Refresh()
        rptCuentaActivo.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCuentaActivo.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpTItulo", LblCabezera.Text))
        ' oParams.Add(New ReportParameter("rpAnio", "al - " & FormatDateTime(DateTime.Now, DateFormat.ShortDate)))
        rptCuentaActivo.LocalReport.SetParameters(oParams)
        rptCuentaActivo.RefreshReport()
        rptCuentaActivo.SetDisplayMode(DisplayMode.PrintLayout)
        rptCuentaActivo.ZoomMode = ZoomMode.Percent
        rptCuentaActivo.ZoomPercent = 75
    End Sub

    Public Sub ConsultaCuenta1413()
        Dim libroSA As New documentoLibroDiarioSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.rptEstadoCuentaActivo.rdlc"
        Me.reportData = libroSA.GetUbicar_EstadoCuenta1413(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
        Me.nombreMainDS = "DsActivo"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCuentaActivo.KeepSessionAlive = True
        rptCuentaActivo.Reset()
        rptCuentaActivo.LocalReport.DataSources.Add(reporte)
        rptCuentaActivo.LocalReport.Refresh()
        rptCuentaActivo.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCuentaActivo.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpTItulo", LblCabezera.Text))
        ' oParams.Add(New ReportParameter("rpAnio", "al - " & FormatDateTime(DateTime.Now, DateFormat.ShortDate)))
        rptCuentaActivo.LocalReport.SetParameters(oParams)
        rptCuentaActivo.RefreshReport()
        rptCuentaActivo.SetDisplayMode(DisplayMode.PrintLayout)
        rptCuentaActivo.ZoomMode = ZoomMode.Percent
        rptCuentaActivo.ZoomPercent = 75
    End Sub

    Public Sub ConsultaCuenta16Mensual(FechaInicio As Date, FechaFin As Date)
        Dim libroSA As New documentoLibroDiarioSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.rptEstadoCuentaActivo.rdlc"
        Me.reportData = libroSA.GetListaEstadoCuenta16Mensual(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, FechaInicio, FechaFin)
        Me.nombreMainDS = "DsActivo"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCuentaActivo.KeepSessionAlive = True
        rptCuentaActivo.Reset()
        rptCuentaActivo.LocalReport.DataSources.Add(reporte)
        rptCuentaActivo.LocalReport.Refresh()
        rptCuentaActivo.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCuentaActivo.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpTItulo", LblCabezera.Text))
        ' oParams.Add(New ReportParameter("rpAnio", "al - " & FormatDateTime(DateTime.Now, DateFormat.ShortDate)))
        rptCuentaActivo.LocalReport.SetParameters(oParams)
        rptCuentaActivo.RefreshReport()
        rptCuentaActivo.SetDisplayMode(DisplayMode.PrintLayout)
        rptCuentaActivo.ZoomMode = ZoomMode.Percent
        rptCuentaActivo.ZoomPercent = 75
    End Sub


    Public Sub ConsultaCuenta16Anual()
        Dim libroSA As New documentoLibroDiarioSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.rptEstadoCuentaActivo.rdlc"
        Me.reportData = libroSA.GetListaEstadoCuenta16Anual(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
        Me.nombreMainDS = "DsActivo"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCuentaActivo.KeepSessionAlive = True
        rptCuentaActivo.Reset()
        rptCuentaActivo.LocalReport.DataSources.Add(reporte)
        rptCuentaActivo.LocalReport.Refresh()
        rptCuentaActivo.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCuentaActivo.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpTItulo", LblCabezera.Text))
        ' oParams.Add(New ReportParameter("rpAnio", "al - " & FormatDateTime(DateTime.Now, DateFormat.ShortDate)))
        rptCuentaActivo.LocalReport.SetParameters(oParams)
        rptCuentaActivo.RefreshReport()
        rptCuentaActivo.SetDisplayMode(DisplayMode.PrintLayout)
        rptCuentaActivo.ZoomMode = ZoomMode.Percent
        rptCuentaActivo.ZoomPercent = 75
    End Sub

    Public Sub ConsultaCuenta16()
        Dim libroSA As New documentoLibroDiarioSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.rptEstadoCuentaActivo.rdlc"
        Me.reportData = libroSA.GetUbicar_EstadoCuenta16(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
        Me.nombreMainDS = "DsActivo"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCuentaActivo.KeepSessionAlive = True
        rptCuentaActivo.Reset()
        rptCuentaActivo.LocalReport.DataSources.Add(reporte)
        rptCuentaActivo.LocalReport.Refresh()
        rptCuentaActivo.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCuentaActivo.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpTItulo", LblCabezera.Text))
        ' oParams.Add(New ReportParameter("rpAnio", "al - " & FormatDateTime(DateTime.Now, DateFormat.ShortDate)))
        rptCuentaActivo.LocalReport.SetParameters(oParams)
        rptCuentaActivo.RefreshReport()
        rptCuentaActivo.SetDisplayMode(DisplayMode.PrintLayout)
        rptCuentaActivo.ZoomMode = ZoomMode.Percent
        rptCuentaActivo.ZoomPercent = 75
    End Sub

    Public Sub ConsultaCuenta14Mensual(FechaInicio As Date, FechaFin As Date)
        Dim libroSA As New documentoLibroDiarioSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.rptEstadoCuentaActivo.rdlc"
        Me.reportData = libroSA.GetUbicar_EstadoCuenta14Mensual(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, FechaInicio, FechaFin)
        Me.nombreMainDS = "DsActivo"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCuentaActivo.KeepSessionAlive = True
        rptCuentaActivo.Reset()
        rptCuentaActivo.LocalReport.DataSources.Add(reporte)
        rptCuentaActivo.LocalReport.Refresh()
        rptCuentaActivo.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCuentaActivo.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpTItulo", LblCabezera.Text))
        ' oParams.Add(New ReportParameter("rpAnio", "al - " & FormatDateTime(DateTime.Now, DateFormat.ShortDate)))
        rptCuentaActivo.LocalReport.SetParameters(oParams)
        rptCuentaActivo.RefreshReport()
        rptCuentaActivo.SetDisplayMode(DisplayMode.PrintLayout)
        rptCuentaActivo.ZoomMode = ZoomMode.Percent
        rptCuentaActivo.ZoomPercent = 75
    End Sub

    Public Sub ConsultaCuenta14()
        Dim libroSA As New documentoLibroDiarioSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.rptEstadoCuentaActivo.rdlc"
        Me.reportData = libroSA.GetUbicar_EstadoCuenta14(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
        Me.nombreMainDS = "DsActivo"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCuentaActivo.KeepSessionAlive = True
        rptCuentaActivo.Reset()
        rptCuentaActivo.LocalReport.DataSources.Add(reporte)
        rptCuentaActivo.LocalReport.Refresh()
        rptCuentaActivo.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCuentaActivo.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpTItulo", LblCabezera.Text))
        ' oParams.Add(New ReportParameter("rpAnio", "al - " & FormatDateTime(DateTime.Now, DateFormat.ShortDate)))
        rptCuentaActivo.LocalReport.SetParameters(oParams)
        rptCuentaActivo.RefreshReport()
        rptCuentaActivo.SetDisplayMode(DisplayMode.PrintLayout)
        rptCuentaActivo.ZoomMode = ZoomMode.Percent
        rptCuentaActivo.ZoomPercent = 75
    End Sub

    Public Sub ConsultaCuenta13Mensual(FechaInicio As Date, FechaFin As Date)
        Dim libroSA As New documentoLibroDiarioSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.rptEstadoCuentaActivo.rdlc"
        Me.reportData = libroSA.GetUbicar_EstadoCuenta13Mensual(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, FechaInicio, FechaFin)
        Me.nombreMainDS = "DsActivo"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCuentaActivo.KeepSessionAlive = True
        rptCuentaActivo.Reset()
        rptCuentaActivo.LocalReport.DataSources.Add(reporte)
        rptCuentaActivo.LocalReport.Refresh()
        rptCuentaActivo.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCuentaActivo.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpTItulo", LblCabezera.Text))
        ' oParams.Add(New ReportParameter("rpAnio", "al - " & FormatDateTime(DateTime.Now, DateFormat.ShortDate)))
        rptCuentaActivo.LocalReport.SetParameters(oParams)
        rptCuentaActivo.RefreshReport()
        rptCuentaActivo.SetDisplayMode(DisplayMode.PrintLayout)
        rptCuentaActivo.ZoomMode = ZoomMode.Percent
        rptCuentaActivo.ZoomPercent = 75
    End Sub

    Public Sub ConsultaCuenta13()
        Dim libroSA As New documentoLibroDiarioSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.rptEstadoCuentaActivo.rdlc"
        Me.reportData = libroSA.GetUbicar_EstadoCuenta13(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
        Me.nombreMainDS = "DsActivo"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCuentaActivo.KeepSessionAlive = True
        rptCuentaActivo.Reset()
        rptCuentaActivo.LocalReport.DataSources.Add(reporte)
        rptCuentaActivo.LocalReport.Refresh()
        rptCuentaActivo.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCuentaActivo.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpTItulo", LblCabezera.Text))
        ' oParams.Add(New ReportParameter("rpAnio", "al - " & FormatDateTime(DateTime.Now, DateFormat.ShortDate)))
        rptCuentaActivo.LocalReport.SetParameters(oParams)
        rptCuentaActivo.RefreshReport()
        rptCuentaActivo.SetDisplayMode(DisplayMode.PrintLayout)
        rptCuentaActivo.ZoomMode = ZoomMode.Percent
        rptCuentaActivo.ZoomPercent = 75
    End Sub


    Public Sub ConsultaCuenta123133Mensual(FechaInicio As Date, FechaFin As Date)
        Dim libroSA As New documentoLibroDiarioSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.rptEstadoCuentaActivo.rdlc"
        Me.reportData = libroSA.GetUbicar_EstadoCuenta123133Mensual(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, FechaInicio, FechaFin)
        Me.nombreMainDS = "DsActivo"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCuentaActivo.KeepSessionAlive = True
        rptCuentaActivo.Reset()
        rptCuentaActivo.LocalReport.DataSources.Add(reporte)
        rptCuentaActivo.LocalReport.Refresh()
        rptCuentaActivo.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCuentaActivo.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpTItulo", LblCabezera.Text))
        ' oParams.Add(New ReportParameter("rpAnio", "al - " & FormatDateTime(DateTime.Now, DateFormat.ShortDate)))
        rptCuentaActivo.LocalReport.SetParameters(oParams)
        rptCuentaActivo.RefreshReport()
        rptCuentaActivo.SetDisplayMode(DisplayMode.PrintLayout)
        rptCuentaActivo.ZoomMode = ZoomMode.Percent
        rptCuentaActivo.ZoomPercent = 75
    End Sub

    Public Sub ConsultaCuenta123133()
        Dim libroSA As New documentoLibroDiarioSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.rptEstadoCuentaActivo.rdlc"
        Me.reportData = libroSA.GetUbicar_EstadoCuenta123133(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
        Me.nombreMainDS = "DsActivo"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCuentaActivo.KeepSessionAlive = True
        rptCuentaActivo.Reset()
        rptCuentaActivo.LocalReport.DataSources.Add(reporte)
        rptCuentaActivo.LocalReport.Refresh()
        rptCuentaActivo.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCuentaActivo.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpTItulo", LblCabezera.Text))
        ' oParams.Add(New ReportParameter("rpAnio", "al - " & FormatDateTime(DateTime.Now, DateFormat.ShortDate)))
        rptCuentaActivo.LocalReport.SetParameters(oParams)
        rptCuentaActivo.RefreshReport()
        rptCuentaActivo.SetDisplayMode(DisplayMode.PrintLayout)
        rptCuentaActivo.ZoomMode = ZoomMode.Percent
        rptCuentaActivo.ZoomPercent = 75
    End Sub


    Public Sub ConsultaPorCuentaMensual(Cuenta As String, FechaInicio As Date, FechaFin As Date)
        Dim libroSA As New documentoLibroDiarioSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.rptEstadoCuentaActivo.rdlc"
        Me.reportData = libroSA.GetUbicar_EstadoXCuentaActivoMensual(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, Cuenta, FechaInicio, FechaFin)
        Me.nombreMainDS = "DsActivo"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCuentaActivo.KeepSessionAlive = True
        rptCuentaActivo.Reset()
        rptCuentaActivo.LocalReport.DataSources.Add(reporte)
        rptCuentaActivo.LocalReport.Refresh()
        rptCuentaActivo.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCuentaActivo.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpTItulo", LblCabezera.Text))
        ' oParams.Add(New ReportParameter("rpAnio", "al - " & FormatDateTime(DateTime.Now, DateFormat.ShortDate)))
        rptCuentaActivo.LocalReport.SetParameters(oParams)
        rptCuentaActivo.RefreshReport()
        rptCuentaActivo.SetDisplayMode(DisplayMode.PrintLayout)
        rptCuentaActivo.ZoomMode = ZoomMode.Percent
        rptCuentaActivo.ZoomPercent = 75
    End Sub

    Public Sub ConsultaPorCuenta(Cuenta As String)
        Dim libroSA As New documentoLibroDiarioSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.rptEstadoCuentaActivo.rdlc"
        Me.reportData = libroSA.GetUbicar_EstadoXCuentaActivo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, Cuenta)
        Me.nombreMainDS = "DsActivo"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCuentaActivo.KeepSessionAlive = True
        rptCuentaActivo.Reset()
        rptCuentaActivo.LocalReport.DataSources.Add(reporte)
        rptCuentaActivo.LocalReport.Refresh()
        rptCuentaActivo.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCuentaActivo.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpTItulo", LblCabezera.Text))
        ' oParams.Add(New ReportParameter("rpAnio", "al - " & FormatDateTime(DateTime.Now, DateFormat.ShortDate)))
        rptCuentaActivo.LocalReport.SetParameters(oParams)
        rptCuentaActivo.RefreshReport()
        rptCuentaActivo.SetDisplayMode(DisplayMode.PrintLayout)
        rptCuentaActivo.ZoomMode = ZoomMode.Percent
        rptCuentaActivo.ZoomPercent = 75
    End Sub

    Public Sub ConsultaPorCuentaInversaMensual(Cuenta As String, FechaInicio As Date, FechaFin As Date)
        Dim libroSA As New documentoLibroDiarioSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.rptEstadoCuentaActivo.rdlc"
        Me.reportData = libroSA.GetUbicar_EstadoXCuentaActivoInversoMensual(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, Cuenta, FechaInicio, FechaFin)
        Me.nombreMainDS = "DsActivo"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCuentaActivo.KeepSessionAlive = True
        rptCuentaActivo.Reset()
        rptCuentaActivo.LocalReport.DataSources.Add(reporte)
        rptCuentaActivo.LocalReport.Refresh()
        rptCuentaActivo.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCuentaActivo.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpTItulo", LblCabezera.Text))
        ' oParams.Add(New ReportParameter("rpAnio", "al - " & FormatDateTime(DateTime.Now, DateFormat.ShortDate)))
        rptCuentaActivo.LocalReport.SetParameters(oParams)
        rptCuentaActivo.RefreshReport()
        rptCuentaActivo.SetDisplayMode(DisplayMode.PrintLayout)
        rptCuentaActivo.ZoomMode = ZoomMode.Percent
        rptCuentaActivo.ZoomPercent = 75
    End Sub

    Public Sub ConsultaPorCuentaInversa(Cuenta As String)
        Dim libroSA As New documentoLibroDiarioSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.rptEstadoCuentaActivo.rdlc"
        Me.reportData = libroSA.GetUbicar_EstadoXCuentaActivoInverso(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, Cuenta)
        Me.nombreMainDS = "DsActivo"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCuentaActivo.KeepSessionAlive = True
        rptCuentaActivo.Reset()
        rptCuentaActivo.LocalReport.DataSources.Add(reporte)
        rptCuentaActivo.LocalReport.Refresh()
        rptCuentaActivo.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCuentaActivo.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpTItulo", LblCabezera.Text))
        ' oParams.Add(New ReportParameter("rpAnio", "al - " & FormatDateTime(DateTime.Now, DateFormat.ShortDate)))
        rptCuentaActivo.LocalReport.SetParameters(oParams)
        rptCuentaActivo.RefreshReport()
        rptCuentaActivo.SetDisplayMode(DisplayMode.PrintLayout)
        rptCuentaActivo.ZoomMode = ZoomMode.Percent
        rptCuentaActivo.ZoomPercent = 75
    End Sub


    Public Sub ConsultaCuenta12Mensual(FechaInicio As Date, FechaFin As Date)
        Dim libroSA As New documentoLibroDiarioSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.rptEstadoCuentaActivo.rdlc"
        Me.reportData = libroSA.GetListaEstadoCuenta12Mensual(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, FechaInicio, FechaFin)
        Me.nombreMainDS = "DsActivo"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCuentaActivo.KeepSessionAlive = True
        rptCuentaActivo.Reset()
        rptCuentaActivo.LocalReport.DataSources.Add(reporte)
        rptCuentaActivo.LocalReport.Refresh()
        rptCuentaActivo.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCuentaActivo.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpTItulo", LblCabezera.Text))
        ' oParams.Add(New ReportParameter("rpAnio", "al - " & FormatDateTime(DateTime.Now, DateFormat.ShortDate)))
        rptCuentaActivo.LocalReport.SetParameters(oParams)
        rptCuentaActivo.RefreshReport()
        rptCuentaActivo.SetDisplayMode(DisplayMode.PrintLayout)
        rptCuentaActivo.ZoomMode = ZoomMode.Percent
        rptCuentaActivo.ZoomPercent = 75
    End Sub

    Public Sub ConsultaCuenta12()
        Dim libroSA As New documentoLibroDiarioSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.rptEstadoCuentaActivo.rdlc"
        Me.reportData = libroSA.GetListaEstadoCuenta12(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
        Me.nombreMainDS = "DsActivo"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCuentaActivo.KeepSessionAlive = True
        rptCuentaActivo.Reset()
        rptCuentaActivo.LocalReport.DataSources.Add(reporte)
        rptCuentaActivo.LocalReport.Refresh()
        rptCuentaActivo.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCuentaActivo.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpTItulo", LblCabezera.Text))
        ' oParams.Add(New ReportParameter("rpAnio", "al - " & FormatDateTime(DateTime.Now, DateFormat.ShortDate)))
        rptCuentaActivo.LocalReport.SetParameters(oParams)
        rptCuentaActivo.RefreshReport()
        rptCuentaActivo.SetDisplayMode(DisplayMode.PrintLayout)
        rptCuentaActivo.ZoomMode = ZoomMode.Percent
        rptCuentaActivo.ZoomPercent = 75
    End Sub
#End Region

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim FechaContInicio = Gempresas.InicioOpeaciones
        Dim FechaInicio As DateTime
        FechaInicio = Format(Now, Mid(FechaContInicio, 4, 4) & "-" & Mid(FechaContInicio, 1, 2) & "-01")

        txtFechaInicio.Value = FechaInicio

        Me.rptCuentaActivo.RefreshReport()
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click

      

        If LblTipoCuenta.Text = "10" Then
            ConsultaCuenta10("10")

        ElseIf LblTipoCuenta.Text = "11" Then
            ConsultaCuenta11y18("11")
        ElseIf LblTipoCuenta.Text = "12" Then
            ConsultaCuenta12()
        ElseIf LblTipoCuenta.Text = "13" Then
            ConsultaCuenta13()
        ElseIf LblTipoCuenta.Text = "123133" Then
            ConsultaCuenta123133()
        ElseIf LblTipoCuenta.Text = "14" Then
            ConsultaCuenta14()
        ElseIf LblTipoCuenta.Text = "16" Then
            ConsultaCuenta16Anual()
        ElseIf LblTipoCuenta.Text = "17" Then
            ConsultaPorCuenta("17")
        ElseIf LblTipoCuenta.Text = "19" Then
            ConsultaPorCuentaInversa("19")
        ElseIf LblTipoCuenta.Text = "18" Then
            'ConsultaPorCuenta("18")
            ConsultaCuenta11y18("18")
        ElseIf LblTipoCuenta.Text = "422" Then
            ConsultaCuenta422("CVR", "422")
        ElseIf LblTipoCuenta.Text = "432" Then
            ConsultaCuenta432("CVO", "432")
        ElseIf LblTipoCuenta.Text = "1413-1433-1443-1681" Then
            ConsultaCuenta1413()
        ElseIf LblTipoCuenta.Text = "20-21-22-23-24-25-26-27-28" Then
            'ConsultaCuenta20al28()
            'ConsultaCuenta20(FechaFin)
        ElseIf LblTipoCuenta.Text = "29" Then
            ConsultaPorCuentaInversa("29")
        ElseIf LblTipoCuenta.Text = "30-31-32-33-34-35-37-38" Then
            ConsultaCuenta30al38()
        ElseIf LblTipoCuenta.Text = "36" Then
            ConsultaPorCuentaInversa("36")
        ElseIf LblTipoCuenta.Text = "39" Then
            ConsultaPorCuentaInversa("39")
        ElseIf LblTipoCuenta.Text = "40" Then

            ConsultaCuenta40("C")
        ElseIf LblTipoCuenta.Text = "40111" Then
            'no reporte


        End If
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click

        ReportesMensualesPorCuenta(txtFechaInicio.Value, txtFechaFin.Value)
        'If cboAnios.Text.Trim.Length > 0 Then
        '    If cboMes.Text = "ENERO" Then
        '        ReportesMensualesPorCuenta(cboAnios.Text, "1")
        '    ElseIf cboMes.Text = "FEBRERO" Then
        '        ReportesMensualesPorCuenta(cboAnios.Text, "2")
        '    ElseIf cboMes.Text = "MARZO" Then
        '        ReportesMensualesPorCuenta(cboAnios.Text, "3")
        '    ElseIf cboMes.Text = "ABRIL" Then
        '        ReportesMensualesPorCuenta(cboAnios.Text, "4")
        '    ElseIf cboMes.Text = "MAYO" Then
        '        ReportesMensualesPorCuenta(cboAnios.Text, "5")
        '    ElseIf cboMes.Text = "JUNIO" Then
        '        ReportesMensualesPorCuenta(cboAnios.Text, "6")
        '    ElseIf cboMes.Text = "JULIO" Then
        '        ReportesMensualesPorCuenta(cboAnios.Text, "7")
        '    ElseIf cboMes.Text = "AGOSTO" Then
        '        ReportesMensualesPorCuenta(cboAnios.Text, "8")
        '    ElseIf cboMes.Text = "SETIEMBRE" Then
        '        ReportesMensualesPorCuenta(cboAnios.Text, "9")
        '    ElseIf cboMes.Text = "OCTUBRE" Then
        '        ReportesMensualesPorCuenta(cboAnios.Text, "10")
        '    ElseIf cboMes.Text = "NOVIEMBRE" Then
        '        ReportesMensualesPorCuenta(cboAnios.Text, "11")
        '    ElseIf cboMes.Text = "DICIEMBRE" Then
        '        ReportesMensualesPorCuenta(cboAnios.Text, "12")
        '    End If
        'Else
        '    MessageBox.Show("eliga un año")
        'End If
    End Sub
End Class
