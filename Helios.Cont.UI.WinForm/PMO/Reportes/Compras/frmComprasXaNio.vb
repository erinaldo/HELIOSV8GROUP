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
Public Class frmComprasXaNio
    Inherits frmMaster

    Property reportName As String
    Property reportData As Object
    Property subreportData As Object
    Property hasSubReport As Boolean
    Property nombreMainDS As String

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        LoadANios()
    End Sub

#Region "Métodos"
    Sub LoadANios()
        Dim periodoSA As New empresaPeriodoSA

        cboMes.DisplayMember = "periodo"
        cboMes.ValueMember = "periodo"
        cboMes.DataSource = periodoSA.GetListar_empresaPeriodo(New empresaPeriodo With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento})
    End Sub

    Public Sub ConsultaReporteTotalesPorANio(strAnio As String)
        Dim totalesAlmacenSA As New documentoCompraRPTSA
        Dim compra As New List(Of documentocompra)
        Dim mes(11) As Decimal

        Me.reportName = "Helios.Cont.Presentation.WinForm.rvwComprasXmes.rdlc"
        ' Me.reportData = totalesAlmacenSA.GetListarComprasPorANioReporte(GEstableciento.IdEstablecimiento, AnioGeneral)
        compra = totalesAlmacenSA.GetListarComprasPorANioReporte(GEstableciento.IdEstablecimiento, strAnio)
        'Me.nombreMainDS = "DSCompra"
        'Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        ReportViewer1.KeepSessionAlive = True
        ReportViewer1.Reset()
        '   ReportViewer1.LocalReport.DataSources.Add(reporte)
        ReportViewer1.LocalReport.Refresh()
        ReportViewer1.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        ReportViewer1.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa))
        oParams.Add(New ReportParameter("rpAnio", cboMes.Text))

        mes(0) = -1
        mes(1) = -1
        mes(2) = -1
        mes(3) = -1
        mes(4) = -1
        mes(5) = -1
        mes(6) = -1
        mes(7) = -1
        mes(8) = -1
        mes(9) = -1
        mes(10) = -1
        mes(11) = -1


        For Each i In compra
            Select Case i.fechaContable
                Case "01/" & strAnio
                    mes(0) = i.importeTotal
                    oParams.Add(New ReportParameter("rpEnero", i.importeTotal))
                Case "02/" & strAnio
                    mes(1) = i.importeTotal
                    oParams.Add(New ReportParameter("rpFebrero", i.importeTotal))
                Case "03/" & strAnio
                    mes(2) = i.importeTotal
                    oParams.Add(New ReportParameter("rpMarzo", i.importeTotal))
                Case "04/" & AnioGeneral
                    mes(3) = i.importeTotal
                    oParams.Add(New ReportParameter("rpAbril", i.importeTotal))
                Case "05/" & strAnio
                    mes(4) = i.importeTotal
                    oParams.Add(New ReportParameter("rpMayo", i.importeTotal))
                Case "06/" & strAnio
                    mes(5) = i.importeTotal
                    oParams.Add(New ReportParameter("rpJunio", i.importeTotal))
                Case "07/" & strAnio
                    mes(6) = i.importeTotal
                    oParams.Add(New ReportParameter("rpJulio", i.importeTotal))
                Case "08/" & strAnio
                    mes(7) = i.importeTotal
                    oParams.Add(New ReportParameter("rpAgosto", i.importeTotal))
                Case "09/" & strAnio
                    mes(8) = i.importeTotal
                    oParams.Add(New ReportParameter("rpSetiembre", i.importeTotal))
                Case "10/" & strAnio
                    mes(9) = i.importeTotal
                    oParams.Add(New ReportParameter("rpOctubre", i.importeTotal))
                Case "11/" & strAnio
                    mes(10) = i.importeTotal
                    oParams.Add(New ReportParameter("rpNoviembre", i.importeTotal))
                Case "12/" & strAnio
                    mes(11) = i.importeTotal
                    oParams.Add(New ReportParameter("rpDiciembre", i.importeTotal))
            End Select
        Next


        For x As Integer = 0 To 11
            If mes(x) <= 0 Then
                Select Case x
                    Case 0
                        oParams.Add(New ReportParameter("rpEnero", 0.0))
                    Case 1
                        oParams.Add(New ReportParameter("rpFebrero", 0.0))
                    Case 2
                        oParams.Add(New ReportParameter("rpMarzo", 0.0))
                    Case 3
                        oParams.Add(New ReportParameter("rpAbril", 0.0))
                    Case 4
                        oParams.Add(New ReportParameter("rpMayo", 0.0))
                    Case 5
                        oParams.Add(New ReportParameter("rpJunio", 0.0))
                    Case 6
                        oParams.Add(New ReportParameter("rpJulio", 0.0))
                    Case 7
                        oParams.Add(New ReportParameter("rpAgosto", 0.0))
                    Case 8
                        oParams.Add(New ReportParameter("rpSetiembre", 0.0))
                    Case 9
                        oParams.Add(New ReportParameter("rpOctubre", 0.0))
                    Case 10
                        oParams.Add(New ReportParameter("rpNoviembre", 0.0))
                    Case 11
                        oParams.Add(New ReportParameter("rpDiciembre", 0.0))
                End Select
            End If
        Next

        ReportViewer1.LocalReport.SetParameters(oParams)
        ReportViewer1.RefreshReport()
        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        ReportViewer1.ZoomMode = ZoomMode.Percent
        ReportViewer1.ZoomPercent = 100
    End Sub

#End Region

    Private Sub frmComprasXaNio_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed

    End Sub

    Private Sub frmComprasXaNio_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '   Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Me.Cursor = Cursors.WaitCursor
        ConsultaReporteTotalesPorANio(cboMes.Text)
        Me.Cursor = Cursors.Arrow
    End Sub
End Class
