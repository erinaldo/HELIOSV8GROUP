Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Microsoft.Reporting.WinForms
Imports System.Security
Imports System.Security.Permissions
Public Class frmCostoByProyecto
    Inherits frmMaster

    Property reportName As String
    Property reportData As Object
    Property subreportData As Object
    Property hasSubReport As Boolean
    Property nombreMainDS As String

    Public Sub New(strtipo As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'GetProyectos(strtipo)


    End Sub

#Region "métodos"

    Public Sub GetCostoByTipo(be As recursoCosto)
        Dim recursoSA As New recursoCostoSA

        cboProyecto.DataSource = recursoSA.GetListaRecursosXtipo(New recursoCosto With {.tipo = be.tipo,
                                                                                      .subtipo = be.subtipo})
        cboProyecto.DisplayMember = "nombreCosto"
        cboProyecto.ValueMember = "idCosto"

    End Sub

    Public Sub GetProyectos(strTipo As String)
        Dim recursoSA As New recursoCostoSA

        cboProyecto.DisplayMember = "nombreCosto"
        cboProyecto.ValueMember = "idCosto"
        Select Case strTipo
            Case TipoCosto.Proyecto,
                TipoCosto.CONTRATOS_DE_CONSTRUCCION,
                TipoCosto.CONTRATOS_DE_ARRENDAMIENTOS,
                TipoCosto.CONTRATOS_DE_SERVICIOS_POR_VALORIZACIONES_O_SIMILARES
                cboProyecto.DataSource = recursoSA.GetListaRecursosXtipo(New recursoCosto With {.tipo = "HC", .subtipo = TipoCosto.Proyecto})
            Case TipoCosto.OrdenProduccion,
                TipoCosto.OP_CONTINUA_DE_BIENES,
                TipoCosto.OP_CONTINUA_DE_SERVICIOS,
                TipoCosto.OP_DE_BIENES_CONTROL_INDEPENDIENTE,
                TipoCosto.OP_DE_SERVICIOS_CONSUMO_INMEDIATO_DE_BIENES,
                TipoCosto.OP_DE_SERVICIOS_CONTROL_INDEPENDIENTE
                cboProyecto.DataSource = recursoSA.GetListaRecursosXtipo(New recursoCosto With {.tipo = "HC", .subtipo = TipoCosto.OrdenProduccion})
            Case TipoCosto.ActivoFijo
                cboProyecto.DataSource = recursoSA.GetListaRecursosXtipo(New recursoCosto With {.tipo = "HC", .subtipo = TipoCosto.ActivoFijo})
        End Select

    End Sub

    Public Sub ConsultaReporteCosto()
        Dim costoSA As New recursoCostoSA
        Dim costo As New recursoCosto



        Me.reportName = "Helios.Cont.Presentation.WinForm.rpvCostoByProyecto.rdlc"
        Me.reportData = costoSA.GetResporteItemsByProyecto(New recursoCosto With {.idCosto = cboProyecto.SelectedValue})
        Me.nombreMainDS = "DSCosto"
        Dim reporte As New ReportDataSource(nombreMainDS, reportData)
        ReportViewer1.KeepSessionAlive = True
        ReportViewer1.Reset()
        ReportViewer1.LocalReport.DataSources.Add(reporte)
        ReportViewer1.LocalReport.Refresh()
        ReportViewer1.LocalReport.SetBasePermissionsForSandboxAppDomain(New PermissionSet(PermissionState.Unrestricted))
        ReportViewer1.LocalReport.ReportEmbeddedResource = reportName

        costo = costoSA.GetCostoById(New recursoCosto With {.idCosto = cboProyecto.SelectedValue})

        Dim oParams As New List(Of ReportParameter)
        oParams.Add(New ReportParameter("rpEmpresa", Gempresas.NomEmpresa))
        oParams.Add(New ReportParameter("rpProyecto", cboProyecto.Text & vbCrLf & costo.inicio & "  al  " & costo.finaliza))
        ReportViewer1.LocalReport.SetParameters(oParams)
        ReportViewer1.RefreshReport()
        ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        ReportViewer1.ZoomMode = ZoomMode.Percent
        ReportViewer1.ZoomPercent = 75
    End Sub

#End Region

    Private Sub frmCostoByProyecto_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Me.Cursor = Cursors.WaitCursor
        If cboProyecto.Text.Trim.Length > 0 Then
            ConsultaReporteCosto()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub CBOConsultas_Click(sender As Object, e As EventArgs) Handles CBOConsultas.Click

    End Sub

    Private Sub CBOConsultas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBOConsultas.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        Select Case CBOConsultas.Text
            Case "CONTRATOS DE CONSTRUCCION"

                GetCostoByTipo(New recursoCosto With {.tipo = "HC", .subtipo = TipoCosto.CONTRATOS_DE_CONSTRUCCION})

            Case "CONTRATOS DE SERVICIOS POR VALORIZACIONES O SIMILARES"

                GetCostoByTipo(New recursoCosto With {.tipo = "HC", .subtipo = TipoCosto.CONTRATOS_DE_SERVICIOS_POR_VALORIZACIONES_O_SIMILARES})
                

            Case "CONTRATOS DE ARRENDAMIENTOS"

                GetCostoByTipo(New recursoCosto With {.tipo = "HC", .subtipo = TipoCosto.CONTRATOS_DE_ARRENDAMIENTOS})

            Case "OP. CONTINUA DE BIENES"
                GetCostoByTipo(New recursoCosto With {.tipo = "HC", .subtipo = TipoCosto.OP_CONTINUA_DE_BIENES})

            Case "OP. DE BIENES - CONTROL INDEPENDIENTE"
                GetCostoByTipo(New recursoCosto With {.tipo = "HC", .subtipo = TipoCosto.OP_DE_BIENES_CONTROL_INDEPENDIENTE})

            Case "OP. CONTINUA DE SERVICIOS"
                GetCostoByTipo(New recursoCosto With {.tipo = "HC", .subtipo = TipoCosto.OP_CONTINUA_DE_SERVICIOS})

            Case "OP. DE SERVICIOS - CONTROL INDEPENDIENTE"
             
                GetCostoByTipo(New recursoCosto With {.tipo = "HC", .subtipo = TipoCosto.OP_DE_SERVICIOS_CONTROL_INDEPENDIENTE})

            Case "OP. DE SERVICIOS - CONSUMO INMEDIATO DE BIENES"
                GetCostoByTipo(New recursoCosto With {.tipo = "HC", .subtipo = TipoCosto.OP_DE_SERVICIOS_CONSUMO_INMEDIATO_DE_BIENES})

            Case "ACTIVO FIJO"
                GetCostoByTipo(New recursoCosto With {.tipo = "HC", .subtipo = TipoCosto.ActivoFijo})

            Case "GASTO ADMINISTRATIVO"
                GetCostoByTipo(New recursoCosto With {.tipo = "HG", .subtipo = TipoCosto.GastoAdministrativo})

            Case "GASTO DE VENTAS"
                GetCostoByTipo(New recursoCosto With {.tipo = "HG", .subtipo = TipoCosto.GastoVentas})

            Case "GASTO FINANCIERO"
            
                GetCostoByTipo(New recursoCosto With {.tipo = "HG", .subtipo = TipoCosto.GastoFinanciero})

        End Select
        Me.Cursor = Cursors.Arrow
    End Sub
End Class
