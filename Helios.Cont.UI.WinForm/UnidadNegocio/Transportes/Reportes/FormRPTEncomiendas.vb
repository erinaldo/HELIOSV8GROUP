Imports System.Security
Imports System.Security.Permissions
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Microsoft.Reporting.WinForms
Public Class FormRPTEncomiendas
    Property formInherits As UCEncomiendasPorEntregar
    Property formInherits_confirma As FormConfirmaEntregaEncomiendas
    Property reportName As String
    Property reportData As Object
    Property subreportData As Object
    Property hasSubReport As Boolean
    Property nombreMainDS As String

    Public Sub New(form As UCEncomiendasPorEntregar, form2 As FormConfirmaEntregaEncomiendas)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        formInherits = form
        formInherits_confirma = form2
        ConsultaReporte()
    End Sub

    Public Sub ConsultaReporte()
        Dim ventaSA As New DocumentoventaTransporteSA

        Dim lista = ventaSA.GetEncomiendasSelEstadoEntregaRDLC(New Business.Entity.documentoventaTransporte With
                                             {
                                             .idEmpresa = Gempresas.IdEmpresaRuc,
                                             .agenciaDestino_id = Integer.Parse(formInherits.ListCiudades.SelectedItems(0).SubItems(0).Text),
                                             .estado = Transporte.EncomiendaEstado.PendienteDeEntrega
                                              })

        Me.reportName = "Helios.Cont.Presentation.WinForm.rdlc_EncomiendasEnviadas.rdlc"
        Me.reportData = lista
        Me.nombreMainDS = "DSEncomienda"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        ReportViewer1.KeepSessionAlive = True
        ReportViewer1.Reset()
        ReportViewer1.LocalReport.DataSources.Add(reporte)
        ReportViewer1.LocalReport.Refresh()
        ReportViewer1.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        ReportViewer1.LocalReport.ReportEmbeddedResource = reportName
        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpOrigen", formInherits_confirma.TextOrigen.Text))
        oParams.Add(New ReportParameter("rpDestino", formInherits_confirma.TextDestino.Text))
        oParams.Add(New ReportParameter("rpFecha", formInherits_confirma.TextFechaProgramada.Value.ToShortDateString))
        oParams.Add(New ReportParameter("rpHora", formInherits_confirma.TextFechaProgramada.Value.ToShortTimeString))
        oParams.Add(New ReportParameter("rpBus", formInherits_confirma.ComboVehiculo.Text))
        oParams.Add(New ReportParameter("rpChofer", formInherits_confirma.ComboChofer.Text))
        'oParams.Add(New ReportParameter("rpItem", cbotipoexistencia.ComboBox.Text))
        ReportViewer1.LocalReport.SetParameters(oParams)
        ReportViewer1.RefreshReport()
        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        ReportViewer1.ZoomMode = ZoomMode.Percent
        ReportViewer1.ZoomPercent = 75
    End Sub

End Class