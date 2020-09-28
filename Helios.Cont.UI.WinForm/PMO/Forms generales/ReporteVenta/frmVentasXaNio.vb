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

Public Class frmVentasXaNio

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

#Region "METODOS"


    Sub LoadANios()
        Dim periodoSA As New empresaPeriodoSA

        cboMes.DisplayMember = "periodo"
        cboMes.ValueMember = "periodo"
        cboMes.DataSource = periodoSA.GetListar_empresaPeriodo(New empresaPeriodo With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento})
    End Sub

    Public Sub ConsultaReporteTotales(anio As String)
        Dim totalesAlmacenSA As New documentoVentaAbarrotesSA
        Dim compra As New List(Of documentoventaAbarrotes)
        Dim mes(11) As Decimal

        Me.reportName = "Helios.Cont.Presentation.WinForm.rvwVentasXmes.rdlc"
        ' Me.reportData = totalesAlmacenSA.GetListarComprasPorANioReporte(GEstableciento.IdEstablecimiento, AnioGeneral)
        compra = totalesAlmacenSA.OntenerVentasAnuales(GEstableciento.IdEstablecimiento, anio)
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
        'oParams.Add(New ReportParameter("rpEstablecimiento", GEstableciento.NombreEstablecimiento))
        oParams.Add(New ReportParameter("rpPeriodo", AnioGeneral))
        ' oParams.Add(New ReportParameter("rpRuc", Gempresas.IdEmpresaRuc))

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
            Select Case i.fechaPeriodo
                Case "01/" & AnioGeneral
                    mes(0) = i.ImporteNacional
                    oParams.Add(New ReportParameter("enero", i.ImporteNacional))
                Case "02/" & AnioGeneral
                    mes(1) = i.ImporteNacional
                    oParams.Add(New ReportParameter("febrero", i.ImporteNacional))
                Case "03/" & AnioGeneral
                    mes(2) = i.ImporteNacional
                    oParams.Add(New ReportParameter("marzo", i.ImporteNacional))
                Case "04/" & AnioGeneral
                    mes(3) = i.ImporteNacional
                    oParams.Add(New ReportParameter("abril", i.ImporteNacional))
                Case "05/" & AnioGeneral
                    mes(4) = i.ImporteNacional
                    oParams.Add(New ReportParameter("mayo", i.ImporteNacional))
                Case "06/" & AnioGeneral
                    mes(5) = i.ImporteNacional
                    oParams.Add(New ReportParameter("junio", i.ImporteNacional))
                Case "07/" & AnioGeneral
                    mes(6) = i.ImporteNacional
                    oParams.Add(New ReportParameter("julio", i.ImporteNacional))
                Case "08/" & AnioGeneral
                    mes(7) = i.ImporteNacional
                    oParams.Add(New ReportParameter("agosto", i.ImporteNacional))
                Case "09/" & AnioGeneral
                    mes(8) = i.ImporteNacional
                    oParams.Add(New ReportParameter("setiembre", i.ImporteNacional))
                Case "10/" & AnioGeneral
                    mes(9) = i.ImporteNacional
                    oParams.Add(New ReportParameter("octubre", i.ImporteNacional))
                Case "11/" & AnioGeneral
                    mes(10) = i.ImporteNacional
                    oParams.Add(New ReportParameter("noviembre", i.ImporteNacional))
                Case "12/" & AnioGeneral
                    mes(11) = i.ImporteNacional
                    oParams.Add(New ReportParameter("diciembre", i.ImporteNacional))
            End Select
        Next


        For x As Integer = 0 To 11
            If mes(x) <= 0 Then
                Select Case x
                    Case 0
                        oParams.Add(New ReportParameter("enero", 0.0))
                    Case 1
                        oParams.Add(New ReportParameter("febrero", 0.0))
                    Case 2
                        oParams.Add(New ReportParameter("marzo", 0.0))
                    Case 3
                        oParams.Add(New ReportParameter("abril", 0.0))
                    Case 4
                        oParams.Add(New ReportParameter("mayo", 0.0))
                    Case 5
                        oParams.Add(New ReportParameter("junio", 0.0))
                    Case 6
                        oParams.Add(New ReportParameter("julio", 0.0))
                    Case 7
                        oParams.Add(New ReportParameter("agosto", 0.0))
                    Case 8
                        oParams.Add(New ReportParameter("setiembre", 0.0))
                    Case 9
                        oParams.Add(New ReportParameter("octubre", 0.0))
                    Case 10
                        oParams.Add(New ReportParameter("noviembre", 0.0))
                    Case 11
                        oParams.Add(New ReportParameter("diciembre", 0.0))
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

    Private Sub frmVentasXaNio_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmVentasXaNio_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        ConsultaReporteTotales(cboMes.Text)
    End Sub
End Class
