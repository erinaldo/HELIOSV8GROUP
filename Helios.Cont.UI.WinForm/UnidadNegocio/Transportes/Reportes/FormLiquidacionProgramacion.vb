Imports System.Security
Imports System.Security.Permissions
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Microsoft.Reporting.WinForms

Public Class FormLiquidacionProgramacion

    Property reportName As String
    Property reportData As Object
    Property subreportData As Object
    Property hasSubReport As Boolean
    Property nombreMainDS As String
    Dim form As FormConsolidarSalidaEmbarque

    Public Sub New(programacion_id As Integer, FormConsolidarSalidaEmbarque As FormConsolidarSalidaEmbarque)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        form = FormConsolidarSalidaEmbarque
        ConsultaReporte(programacion_id)
    End Sub

    Private Sub FormLiquidacionProgramacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '   Me.ReportViewer1.RefreshReport()
    End Sub


    Public Sub ConsultaReporte(programacion_id As Integer)
        Try


            Dim ventaSA As New DocumentoventaTransporteSA

            Dim lista = ventaSA.GetMovimientosByProgramacion(New documentoventaTransporte With {.programacion_id = programacion_id, .tipoVenta = General.TIPO_VENTA.VENTA_PASAJES})

            Me.reportName = "Helios.Cont.Presentation.WinForm.rpvLiquidacionProgramacion.rdlc"
            Me.reportData = lista
            Me.nombreMainDS = "DSLiquidacion"
            Dim reporte As New ReportDataSource(nombreMainDS, reportData)
            ReportViewer1.KeepSessionAlive = True
            ReportViewer1.Reset()
            ReportViewer1.LocalReport.DataSources.Add(reporte)
            ReportViewer1.LocalReport.Refresh()
            ReportViewer1.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
            ReportViewer1.LocalReport.ReportEmbeddedResource = reportName
            Dim oParams As New List(Of ReportParameter)
            oParams.Add(New ReportParameter("rpRutas", CStr(form.TextRuta.Text)))
            oParams.Add(New ReportParameter("rpFecha", CStr(form.TextFechaProgramada.Value.ToShortDateString)))
            oParams.Add(New ReportParameter("rpHora", CStr(form.TextFechaProgramada.Value.ToShortTimeString)))
            oParams.Add(New ReportParameter("rpBus", CStr(form.TextCodigoPlaca.Text)))
            ReportViewer1.LocalReport.SetParameters(oParams)
            ReportViewer1.RefreshReport()
            ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
            ReportViewer1.ZoomMode = ZoomMode.Percent
            ReportViewer1.ZoomPercent = 75
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class