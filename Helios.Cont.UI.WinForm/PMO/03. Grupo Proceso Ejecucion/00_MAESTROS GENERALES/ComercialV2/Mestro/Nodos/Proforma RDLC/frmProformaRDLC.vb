Imports Microsoft.Reporting.WinForms
Imports System.Security
Imports System.Security.Permissions
Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmProformaRDLC

    Property reportName As String
    Property reportData As Object
    Property subreportData As Object
    Property hasSubReport As Boolean
    Property nombreMainDS As String

    Public Sub New(iddoc As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ConsultaProforma(iddoc)
        WindowState = FormWindowState.Maximized
    End Sub

#Region "Metodos"
    Public Sub ConsultaProforma(iddoc As Integer)
        Dim ventaSA As New documentoVentaAbarrotesSA
        Dim ventaDetSA As New documentoVentaAbarrotesDetSA
        Dim entidadSA As New entidadSA
        Dim totalUtilidad As Decimal = 0
        Dim totalUtilidadme As Decimal = 0
        Dim totalVentas As Decimal = 0

        Dim venta = ventaSA.GetUbicar_documentoventaAbarrotesPorID(iddoc)
        Dim cliente = entidadSA.UbicarEntidadPorID(venta.idCliente).FirstOrDefault

        Me.reportName = "Helios.Cont.Presentation.WinForm.rptProforma.rdlc"
        Me.reportData = ventaDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(iddoc)
        Me.nombreMainDS = "DSProforma"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        ReportViewer1.KeepSessionAlive = True
        ReportViewer1.Reset()
        ReportViewer1.LocalReport.DataSources.Add(reporte)
        ReportViewer1.LocalReport.Refresh()
        ReportViewer1.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        ReportViewer1.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa & "-" & Gempresas.Ruc))
        If cliente IsNot Nothing Then
            oParams.Add(New ReportParameter("rpRazon", cliente.nombreCompleto)) '
            oParams.Add(New ReportParameter("rptDNI", If(IsNothing(cliente.nrodoc), "-", cliente.nrodoc)))
        Else
            oParams.Add(New ReportParameter("rpRazon", "VARIOS")) '
            oParams.Add(New ReportParameter("rptDNI", "-"))
        End If

        oParams.Add(New ReportParameter("rpUsuario", usuario.CustomUsuario.Full_Name))
        oParams.Add(New ReportParameter("rpNumero", "PROFORMA DE VENTA - NRO. " & venta.serie & "-" & venta.numeroDoc))
        ReportViewer1.LocalReport.SetParameters(oParams)
        ReportViewer1.RefreshReport()
        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        ReportViewer1.ZoomMode = ZoomMode.Percent
        ReportViewer1.ZoomPercent = 75
    End Sub
#End Region

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
