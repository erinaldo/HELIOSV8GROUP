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

Public Class frmEstadoCuentaPasivo
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

        If LblTipoCuenta.Text = "41" Then
            ConsultaCuenta41Mensual(FechaInicio, FechaFin)
        ElseIf LblTipoCuenta.Text = "42" Then
            ConsultaCuenta42Mensual(FechaInicio, FechaFin)
        ElseIf LblTipoCuenta.Text = "43" Then
            ConsultaCuenta43Mensual(FechaInicio, FechaFin)
        ElseIf LblTipoCuenta.Text = "423433" Then
            ConsultaCuenta423433Mensual(FechaInicio, FechaFin)
        ElseIf LblTipoCuenta.Text = "44" Then
            ConsultaPorCuentaMensual("44", FechaInicio, FechaFin)
        ElseIf LblTipoCuenta.Text = "45" Then
            ConsultaPorCuentaMensual("45", FechaInicio, FechaFin)
        ElseIf LblTipoCuenta.Text = "46" Then
            ConsultaPorCuentaMensual46(FechaInicio, FechaFin)
        ElseIf LblTipoCuenta.Text = "47" Then
            ConsultaPorCuentaMensual("47", FechaInicio, FechaFin)
        ElseIf LblTipoCuenta.Text = "122" Then
            ConsultaCuenta122Mensual("VAO", "122", FechaInicio, FechaFin)
        ElseIf LblTipoCuenta.Text = "132" Then
            ConsultaCuenta132Mensual("VAR", "132", FechaInicio, FechaFin)
        ElseIf LblTipoCuenta.Text = "48" Then
            ConsultaPorCuentaMensual("48", FechaInicio, FechaFin)
        ElseIf LblTipoCuenta.Text = "49" Then
            ConsultaPorCuentaMensual("49", FechaInicio, FechaFin)
            'ElseIf LblTipoCuenta.Text = "40111" Then
            '    'no tiene reporte 
        ElseIf LblTipoCuenta.Text = "40" Then
            ConsultaCuenta40Mensual("P", FechaInicio, FechaFin)
        ElseIf LblTipoCuenta.Text = "50" Then
            ConsultaPorCuentaMensual("50", FechaInicio, FechaFin)
        ElseIf LblTipoCuenta.Text = "51" Then
            ConsultaPorCuentaMensual("51", FechaInicio, FechaFin)
        ElseIf LblTipoCuenta.Text = "52" Then
            ConsultaPorCuentaMensual("52", FechaInicio, FechaFin)
        ElseIf LblTipoCuenta.Text = "56" Then
            ConsultaPorCuentaMensual("56", FechaInicio, FechaFin)
        ElseIf LblTipoCuenta.Text = "57" Then
            ConsultaPorCuentaMensual("57", FechaInicio, FechaFin)
        ElseIf LblTipoCuenta.Text = "58" Then
            ConsultaPorCuentaMensual("58", FechaInicio, FechaFin)
        ElseIf LblTipoCuenta.Text = "59" Then
            ConsultaPorCuentaMensual("59", FechaInicio, FechaFin)
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

    Public Sub ConsultaCuenta40Mensual(tipo As String, FechaInicio As Date, FechaFin As Date)
        Dim libroSA As New documentoLibroDiarioSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.rptEstadoCuentaPasivo.rdlc"
        Me.reportData = libroSA.GetUbicar_EstadoCuenta40Mensual(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, tipo, FechaInicio, FechaFin)
        Me.nombreMainDS = "DsPasivo"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCuentaPasiva.KeepSessionAlive = True
        rptCuentaPasiva.Reset()
        rptCuentaPasiva.LocalReport.DataSources.Add(reporte)
        rptCuentaPasiva.LocalReport.Refresh()
        rptCuentaPasiva.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCuentaPasiva.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpTItulo", LblCabezera.Text))
        ' oParams.Add(New ReportParameter("rpAnio", "al - " & FormatDateTime(DateTime.Now, DateFormat.ShortDate)))
        rptCuentaPasiva.LocalReport.SetParameters(oParams)
        rptCuentaPasiva.RefreshReport()
        rptCuentaPasiva.SetDisplayMode(DisplayMode.PrintLayout)
        rptCuentaPasiva.ZoomMode = ZoomMode.Percent
        rptCuentaPasiva.ZoomPercent = 75
    End Sub

    Public Sub ConsultaCuenta40(tipo As String)
        Dim libroSA As New documentoLibroDiarioSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.rptEstadoCuentaPasivo.rdlc"
        Me.reportData = libroSA.GetUbicar_EstadoCuenta40(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, tipo)
        Me.nombreMainDS = "DsPasivo"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCuentaPasiva.KeepSessionAlive = True
        rptCuentaPasiva.Reset()
        rptCuentaPasiva.LocalReport.DataSources.Add(reporte)
        rptCuentaPasiva.LocalReport.Refresh()
        rptCuentaPasiva.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCuentaPasiva.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpTItulo", LblCabezera.Text))
        ' oParams.Add(New ReportParameter("rpAnio", "al - " & FormatDateTime(DateTime.Now, DateFormat.ShortDate)))
        rptCuentaPasiva.LocalReport.SetParameters(oParams)
        rptCuentaPasiva.RefreshReport()
        rptCuentaPasiva.SetDisplayMode(DisplayMode.PrintLayout)
        rptCuentaPasiva.ZoomMode = ZoomMode.Percent
        rptCuentaPasiva.ZoomPercent = 75
    End Sub


    Public Sub ConsultaCuenta132Mensual(tipoAnticipo As String, cuenta As String, FechaInicio As Date, FechaFin As Date)
        Dim libroSA As New documentoLibroDiarioSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.rptEstadoCuentaPasivo.rdlc"
        Me.reportData = libroSA.GetListaEstadoCuenta132Mensual(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, tipoAnticipo, cuenta, FechaInicio, FechaFin)
        Me.nombreMainDS = "DsPasivo"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCuentaPasiva.KeepSessionAlive = True
        rptCuentaPasiva.Reset()
        rptCuentaPasiva.LocalReport.DataSources.Add(reporte)
        rptCuentaPasiva.LocalReport.Refresh()
        rptCuentaPasiva.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCuentaPasiva.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpTItulo", LblCabezera.Text))
        'oParams.Add(New ReportParameter("rpAnio", "al - " & FormatDateTime(DateTime.Now, DateFormat.ShortDate)))
        rptCuentaPasiva.LocalReport.SetParameters(oParams)
        rptCuentaPasiva.RefreshReport()
        rptCuentaPasiva.SetDisplayMode(DisplayMode.PrintLayout)
        rptCuentaPasiva.ZoomMode = ZoomMode.Percent
        rptCuentaPasiva.ZoomPercent = 75
    End Sub

    Public Sub ConsultaCuenta122Mensual(tipoAnticipo As String, cuenta As String, FechaInicio As Date, FechaFin As Date)
        Dim libroSA As New documentoLibroDiarioSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.rptEstadoCuentaPasivo.rdlc"
        Me.reportData = libroSA.GetListaEstadoCuenta122Mensual(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, tipoAnticipo, cuenta, FechaInicio, FechaFin)
        Me.nombreMainDS = "DsPasivo"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCuentaPasiva.KeepSessionAlive = True
        rptCuentaPasiva.Reset()
        rptCuentaPasiva.LocalReport.DataSources.Add(reporte)
        rptCuentaPasiva.LocalReport.Refresh()
        rptCuentaPasiva.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCuentaPasiva.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpTItulo", LblCabezera.Text))
        'oParams.Add(New ReportParameter("rpAnio", "al - " & FormatDateTime(DateTime.Now, DateFormat.ShortDate)))
        rptCuentaPasiva.LocalReport.SetParameters(oParams)
        rptCuentaPasiva.RefreshReport()
        rptCuentaPasiva.SetDisplayMode(DisplayMode.PrintLayout)
        rptCuentaPasiva.ZoomMode = ZoomMode.Percent
        rptCuentaPasiva.ZoomPercent = 75
    End Sub

    Public Sub ConsultaCuenta122(tipoAnticipo As String, cuenta As String)
        Dim libroSA As New documentoLibroDiarioSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.rptEstadoCuentaPasivo.rdlc"
        Me.reportData = libroSA.GetListaEstadoCuenta122(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, tipoAnticipo, cuenta)
        Me.nombreMainDS = "DsPasivo"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCuentaPasiva.KeepSessionAlive = True
        rptCuentaPasiva.Reset()
        rptCuentaPasiva.LocalReport.DataSources.Add(reporte)
        rptCuentaPasiva.LocalReport.Refresh()
        rptCuentaPasiva.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCuentaPasiva.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpTItulo", LblCabezera.Text))
        'oParams.Add(New ReportParameter("rpAnio", "al - " & FormatDateTime(DateTime.Now, DateFormat.ShortDate)))
        rptCuentaPasiva.LocalReport.SetParameters(oParams)
        rptCuentaPasiva.RefreshReport()
        rptCuentaPasiva.SetDisplayMode(DisplayMode.PrintLayout)
        rptCuentaPasiva.ZoomMode = ZoomMode.Percent
        rptCuentaPasiva.ZoomPercent = 75
    End Sub


    Public Sub ConsultaPorCuentaMensual46(FechaInicio As Date, FechaFin As Date)
        Dim libroSA As New documentoLibroDiarioSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.rptEstadoCuentaPasivo.rdlc"
        Me.reportData = libroSA.GetListaEstadoCuenta46Mensual(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, FechaInicio, FechaFin)
        Me.nombreMainDS = "DsPasivo"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCuentaPasiva.KeepSessionAlive = True
        rptCuentaPasiva.Reset()
        rptCuentaPasiva.LocalReport.DataSources.Add(reporte)
        rptCuentaPasiva.LocalReport.Refresh()
        rptCuentaPasiva.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCuentaPasiva.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpTItulo", LblCabezera.Text))
        ' oParams.Add(New ReportParameter("rpAnio", "al - " & FormatDateTime(DateTime.Now, DateFormat.ShortDate)))
        rptCuentaPasiva.LocalReport.SetParameters(oParams)
        rptCuentaPasiva.RefreshReport()
        rptCuentaPasiva.SetDisplayMode(DisplayMode.PrintLayout)
        rptCuentaPasiva.ZoomMode = ZoomMode.Percent
        rptCuentaPasiva.ZoomPercent = 75
    End Sub


    Public Sub ConsultaPorCuentaMensual(Cuenta As String, FechaInicio As Date, FechaFin As Date)
        Dim libroSA As New documentoLibroDiarioSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.rptEstadoCuentaPasivo.rdlc"
        Me.reportData = libroSA.GetUbicar_EstadoXCuentaPasivoMensual(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, Cuenta, FechaInicio, FechaFin)
        Me.nombreMainDS = "DsPasivo"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCuentaPasiva.KeepSessionAlive = True
        rptCuentaPasiva.Reset()
        rptCuentaPasiva.LocalReport.DataSources.Add(reporte)
        rptCuentaPasiva.LocalReport.Refresh()
        rptCuentaPasiva.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCuentaPasiva.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpTItulo", LblCabezera.Text))
        ' oParams.Add(New ReportParameter("rpAnio", "al - " & FormatDateTime(DateTime.Now, DateFormat.ShortDate)))
        rptCuentaPasiva.LocalReport.SetParameters(oParams)
        rptCuentaPasiva.RefreshReport()
        rptCuentaPasiva.SetDisplayMode(DisplayMode.PrintLayout)
        rptCuentaPasiva.ZoomMode = ZoomMode.Percent
        rptCuentaPasiva.ZoomPercent = 75
    End Sub


    Public Sub ConsultaPorCuenta46Anual()
        Dim libroSA As New documentoLibroDiarioSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.rptEstadoCuentaPasivo.rdlc"
        Me.reportData = libroSA.GetListaEstadoCuenta46Anual(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
        Me.nombreMainDS = "DsPasivo"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCuentaPasiva.KeepSessionAlive = True
        rptCuentaPasiva.Reset()
        rptCuentaPasiva.LocalReport.DataSources.Add(reporte)
        rptCuentaPasiva.LocalReport.Refresh()
        rptCuentaPasiva.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCuentaPasiva.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpTItulo", LblCabezera.Text))
        ' oParams.Add(New ReportParameter("rpAnio", "al - " & FormatDateTime(DateTime.Now, DateFormat.ShortDate)))
        rptCuentaPasiva.LocalReport.SetParameters(oParams)
        rptCuentaPasiva.RefreshReport()
        rptCuentaPasiva.SetDisplayMode(DisplayMode.PrintLayout)
        rptCuentaPasiva.ZoomMode = ZoomMode.Percent
        rptCuentaPasiva.ZoomPercent = 75
    End Sub

    Public Sub ConsultaPorCuenta(Cuenta As String)
        Dim libroSA As New documentoLibroDiarioSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.rptEstadoCuentaPasivo.rdlc"
        Me.reportData = libroSA.GetUbicar_EstadoXCuentaPasivo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, Cuenta)
        Me.nombreMainDS = "DsPasivo"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCuentaPasiva.KeepSessionAlive = True
        rptCuentaPasiva.Reset()
        rptCuentaPasiva.LocalReport.DataSources.Add(reporte)
        rptCuentaPasiva.LocalReport.Refresh()
        rptCuentaPasiva.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCuentaPasiva.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpTItulo", LblCabezera.Text))
        ' oParams.Add(New ReportParameter("rpAnio", "al - " & FormatDateTime(DateTime.Now, DateFormat.ShortDate)))
        rptCuentaPasiva.LocalReport.SetParameters(oParams)
        rptCuentaPasiva.RefreshReport()
        rptCuentaPasiva.SetDisplayMode(DisplayMode.PrintLayout)
        rptCuentaPasiva.ZoomMode = ZoomMode.Percent
        rptCuentaPasiva.ZoomPercent = 75
    End Sub

    Public Sub ConsultaCuenta41Mensual(FechaInicio As Date, FechaFin As Date)
        Dim libroSA As New documentoLibroDiarioSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.rptEstadoCuentaPasivo.rdlc"
        Me.reportData = libroSA.GetUbicar_EstadoCuenta41Mensual(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, FechaInicio, FechaFin)
        Me.nombreMainDS = "DsPasivo"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCuentaPasiva.KeepSessionAlive = True
        rptCuentaPasiva.Reset()
        rptCuentaPasiva.LocalReport.DataSources.Add(reporte)
        rptCuentaPasiva.LocalReport.Refresh()
        rptCuentaPasiva.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCuentaPasiva.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpTItulo", LblCabezera.Text))
        'oParams.Add(New ReportParameter("rpAnio", "al - " & FormatDateTime(DateTime.Now, DateFormat.ShortDate)))
        rptCuentaPasiva.LocalReport.SetParameters(oParams)
        rptCuentaPasiva.RefreshReport()
        rptCuentaPasiva.SetDisplayMode(DisplayMode.PrintLayout)
        rptCuentaPasiva.ZoomMode = ZoomMode.Percent
        rptCuentaPasiva.ZoomPercent = 75
    End Sub

    Public Sub ConsultaCuenta41()
        Dim libroSA As New documentoLibroDiarioSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.rptEstadoCuentaPasivo.rdlc"
        Me.reportData = libroSA.GetUbicar_EstadoCuenta41(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
        Me.nombreMainDS = "DsPasivo"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCuentaPasiva.KeepSessionAlive = True
        rptCuentaPasiva.Reset()
        rptCuentaPasiva.LocalReport.DataSources.Add(reporte)
        rptCuentaPasiva.LocalReport.Refresh()
        rptCuentaPasiva.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCuentaPasiva.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpTItulo", LblCabezera.Text))
        'oParams.Add(New ReportParameter("rpAnio", "al - " & FormatDateTime(DateTime.Now, DateFormat.ShortDate)))
        rptCuentaPasiva.LocalReport.SetParameters(oParams)
        rptCuentaPasiva.RefreshReport()
        rptCuentaPasiva.SetDisplayMode(DisplayMode.PrintLayout)
        rptCuentaPasiva.ZoomMode = ZoomMode.Percent
        rptCuentaPasiva.ZoomPercent = 75
    End Sub


    Public Sub ConsultaCuenta42Mensual(FechaInicio As Date, FechaFin As Date)
        Dim libroSA As New documentoLibroDiarioSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.rptEstadoCuentaPasivo.rdlc"
        Me.reportData = libroSA.GetListaEstadoCuenta42Mensual(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, FechaInicio, FechaFin)
        Me.nombreMainDS = "DsPasivo"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCuentaPasiva.KeepSessionAlive = True
        rptCuentaPasiva.Reset()
        rptCuentaPasiva.LocalReport.DataSources.Add(reporte)
        rptCuentaPasiva.LocalReport.Refresh()
        rptCuentaPasiva.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCuentaPasiva.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpTItulo", LblCabezera.Text))
        'oParams.Add(New ReportParameter("rpAnio", "al - " & FormatDateTime(DateTime.Now, DateFormat.ShortDate)))
        rptCuentaPasiva.LocalReport.SetParameters(oParams)
        rptCuentaPasiva.RefreshReport()
        rptCuentaPasiva.SetDisplayMode(DisplayMode.PrintLayout)
        rptCuentaPasiva.ZoomMode = ZoomMode.Percent
        rptCuentaPasiva.ZoomPercent = 75
    End Sub


    Public Sub ConsultaCuenta42()
        Dim libroSA As New documentoLibroDiarioSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.rptEstadoCuentaPasivo.rdlc"
        Me.reportData = libroSA.GetListaEstadoCuenta42(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
        Me.nombreMainDS = "DsPasivo"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCuentaPasiva.KeepSessionAlive = True
        rptCuentaPasiva.Reset()
        rptCuentaPasiva.LocalReport.DataSources.Add(reporte)
        rptCuentaPasiva.LocalReport.Refresh()
        rptCuentaPasiva.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCuentaPasiva.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpTItulo", LblCabezera.Text))
        'oParams.Add(New ReportParameter("rpAnio", "al - " & FormatDateTime(DateTime.Now, DateFormat.ShortDate)))
        rptCuentaPasiva.LocalReport.SetParameters(oParams)
        rptCuentaPasiva.RefreshReport()
        rptCuentaPasiva.SetDisplayMode(DisplayMode.PrintLayout)
        rptCuentaPasiva.ZoomMode = ZoomMode.Percent
        rptCuentaPasiva.ZoomPercent = 75
    End Sub

    Public Sub ConsultaCuenta423433Mensual(FechaInicio As String, FechaFin As String)
        Dim libroSA As New documentoLibroDiarioSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.rptEstadoCuentaPasivo.rdlc"
        Me.reportData = libroSA.GetUbicar_EstadoCuenta423433Mensual(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, FechaInicio, FechaFin)
        Me.nombreMainDS = "DsPasivo"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCuentaPasiva.KeepSessionAlive = True
        rptCuentaPasiva.Reset()
        rptCuentaPasiva.LocalReport.DataSources.Add(reporte)
        rptCuentaPasiva.LocalReport.Refresh()
        rptCuentaPasiva.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCuentaPasiva.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpTItulo", LblCabezera.Text))
        ' oParams.Add(New ReportParameter("rpAnio", "al - " & FormatDateTime(DateTime.Now, DateFormat.ShortDate)))
        rptCuentaPasiva.LocalReport.SetParameters(oParams)
        rptCuentaPasiva.RefreshReport()
        rptCuentaPasiva.SetDisplayMode(DisplayMode.PrintLayout)
        rptCuentaPasiva.ZoomMode = ZoomMode.Percent
        rptCuentaPasiva.ZoomPercent = 75
    End Sub

    Public Sub ConsultaCuenta423433()
        Dim libroSA As New documentoLibroDiarioSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.rptEstadoCuentaPasivo.rdlc"
        Me.reportData = libroSA.GetUbicar_EstadoCuenta423433(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
        Me.nombreMainDS = "DsPasivo"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCuentaPasiva.KeepSessionAlive = True
        rptCuentaPasiva.Reset()
        rptCuentaPasiva.LocalReport.DataSources.Add(reporte)
        rptCuentaPasiva.LocalReport.Refresh()
        rptCuentaPasiva.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCuentaPasiva.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpTItulo", LblCabezera.Text))
        ' oParams.Add(New ReportParameter("rpAnio", "al - " & FormatDateTime(DateTime.Now, DateFormat.ShortDate)))
        rptCuentaPasiva.LocalReport.SetParameters(oParams)
        rptCuentaPasiva.RefreshReport()
        rptCuentaPasiva.SetDisplayMode(DisplayMode.PrintLayout)
        rptCuentaPasiva.ZoomMode = ZoomMode.Percent
        rptCuentaPasiva.ZoomPercent = 75
    End Sub

    Public Sub ConsultaCuenta43Mensual(FechaInicio As Date, FechaFin As Date)
        Dim libroSA As New documentoLibroDiarioSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.rptEstadoCuentaPasivo.rdlc"
        Me.reportData = libroSA.GetUbicar_EstadoCuenta43Mensual(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, FechaInicio, FechaFin)
        Me.nombreMainDS = "DsPasivo"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCuentaPasiva.KeepSessionAlive = True
        rptCuentaPasiva.Reset()
        rptCuentaPasiva.LocalReport.DataSources.Add(reporte)
        rptCuentaPasiva.LocalReport.Refresh()
        rptCuentaPasiva.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCuentaPasiva.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpTItulo", LblCabezera.Text))
        ' oParams.Add(New ReportParameter("rpAnio", "al - " & FormatDateTime(DateTime.Now, DateFormat.ShortDate)))
        rptCuentaPasiva.LocalReport.SetParameters(oParams)
        rptCuentaPasiva.RefreshReport()
        rptCuentaPasiva.SetDisplayMode(DisplayMode.PrintLayout)
        rptCuentaPasiva.ZoomMode = ZoomMode.Percent
        rptCuentaPasiva.ZoomPercent = 75
    End Sub

    Public Sub ConsultaCuenta43()
        Dim libroSA As New documentoLibroDiarioSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0
        Me.reportName = "Helios.Cont.Presentation.WinForm.rptEstadoCuentaPasivo.rdlc"
        Me.reportData = libroSA.GetUbicar_EstadoCuenta43(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
        Me.nombreMainDS = "DsPasivo"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        rptCuentaPasiva.KeepSessionAlive = True
        rptCuentaPasiva.Reset()
        rptCuentaPasiva.LocalReport.DataSources.Add(reporte)
        rptCuentaPasiva.LocalReport.Refresh()
        rptCuentaPasiva.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        rptCuentaPasiva.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpTItulo", LblCabezera.Text))
        ' oParams.Add(New ReportParameter("rpAnio", "al - " & FormatDateTime(DateTime.Now, DateFormat.ShortDate)))
        rptCuentaPasiva.LocalReport.SetParameters(oParams)
        rptCuentaPasiva.RefreshReport()
        rptCuentaPasiva.SetDisplayMode(DisplayMode.PrintLayout)
        rptCuentaPasiva.ZoomMode = ZoomMode.Percent
        rptCuentaPasiva.ZoomPercent = 75
    End Sub


#End Region

    Private Sub frmEstadoCuentaPasivo_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Dim FechaContInicio = Gempresas.InicioOpeaciones
        Dim FechaInicio As DateTime
        FechaInicio = Format(Now, Mid(FechaContInicio, 4, 4) & "-" & Mid(FechaContInicio, 1, 2) & "-01")

        txtFechaInicio.Value = FechaInicio

        Me.rptCuentaPasiva.RefreshReport()
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        If LblTipoCuenta.Text = "41" Then
            ConsultaCuenta41()
        ElseIf LblTipoCuenta.Text = "42" Then
            ConsultaCuenta42()
        ElseIf LblTipoCuenta.Text = "43" Then
            ConsultaCuenta43()
        ElseIf LblTipoCuenta.Text = "423433" Then
            ConsultaCuenta423433()
        ElseIf LblTipoCuenta.Text = "44" Then
            ConsultaPorCuenta("44")
        ElseIf LblTipoCuenta.Text = "45" Then
            ConsultaPorCuenta("45")
        ElseIf LblTipoCuenta.Text = "46" Then
            ConsultaPorCuenta46Anual()
        ElseIf LblTipoCuenta.Text = "47" Then
            ConsultaPorCuenta("47")
        ElseIf LblTipoCuenta.Text = "122" Then
            ConsultaCuenta122("VAO", "122")
        ElseIf LblTipoCuenta.Text = "132" Then
            ConsultaCuenta122("VAR", "132")
        ElseIf LblTipoCuenta.Text = "48" Then
            ConsultaPorCuenta("48")
        ElseIf LblTipoCuenta.Text = "49" Then
            ConsultaPorCuenta("49")
        ElseIf LblTipoCuenta.Text = "40111" Then
            'no tiene reporte 
        ElseIf LblTipoCuenta.Text = "40" Then
            ConsultaCuenta40("P")
        ElseIf LblTipoCuenta.Text = "50" Then
            ConsultaPorCuenta("50")
        ElseIf LblTipoCuenta.Text = "51" Then
            ConsultaPorCuenta("51")
        ElseIf LblTipoCuenta.Text = "52" Then
            ConsultaPorCuenta("52")
        ElseIf LblTipoCuenta.Text = "56" Then
            ConsultaPorCuenta("56")
        ElseIf LblTipoCuenta.Text = "57" Then
            ConsultaPorCuenta("57")
        ElseIf LblTipoCuenta.Text = "58" Then
            ConsultaPorCuenta("58")
        ElseIf LblTipoCuenta.Text = "59" Then
            ConsultaPorCuenta("59")
        End If
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        ReportesMensualesPorCuenta(txtFechaInicio.Value, txtFechaFin.Value)
    End Sub
End Class
