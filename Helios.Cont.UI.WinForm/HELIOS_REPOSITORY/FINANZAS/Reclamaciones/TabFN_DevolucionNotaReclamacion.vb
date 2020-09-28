Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping

Public Class TabFN_DevolucionNotaReclamacion
#Region "Attributes"
    Public Property anticipoSA As New documentoAnticipoSA
    Public Property documentoAnticipoConciliacionSA As New documentoAnticipoConciliacionSA
    Public moduloR As String
    Public estadoR As String
    'Public Property FormMDI As FormMaestroReclamacionPagos
#End Region

#Region "Constructors"
    Public Sub New(estado As String, modulo As String) ', Form As FormMaestroReclamacionPagos)

        ' This call is required by the designer.
        InitializeComponent()
        'FormMDI = Form
        ' Add any initialization after the InitializeComponent() call.
        moduloR = modulo
        estadoR = estado
        FormatoGridAvanzado(GridNotas, True, False, 10.0F)
        'If moduloR = "VENTAS" Then
        '    GetNotas(estado)
        'ElseIf moduloR = "COMPRAS" Then

        '    GetNotasCompras(estado)
        'End If


        txtPeriodo.Value = DateTime.Now
    End Sub
#End Region

#Region "Methods"

    Private Sub GetNotasCompras(estado As String)

        Dim dt As New DataTable
        dt.Columns.Add("idDocumento")
        dt.Columns.Add("fecha")
        dt.Columns.Add("tipo")
        dt.Columns.Add("nrodoc")
        dt.Columns.Add("monto")
        dt.Columns.Add("usado")
        dt.Columns.Add("saldo")
        dt.Columns.Add("estado")
        dt.Columns.Add("entidad")
        dt.Columns.Add("identidad")

        For Each i In anticipoSA.GetReclamacionesStatusCompras(New documentocompra With
                                                             {
                                                             .idEmpresa = Gempresas.IdEmpresaRuc,
                                                             .idCentroCosto = GEstableciento.IdEstablecimiento,
                                                             .tipoCompra = "VRC",
                                                             .estadoPago = estado
                                                             })

            dt.Rows.Add(i.idDocumento, i.fechaDoc, "NOTA DE CREDITO", i.numeroDoc, i.importeMN, i.TotalNotas, i.SaldoReclamacion.GetValueOrDefault, i.EstadoName, i.CustomEntidad.nombreCompleto, i.CustomEntidad.idEntidad)
        Next
        GridNotas.DataSource = dt
        GridNotas.BackColor = Color.White
    End Sub

    Private Sub GetNotas(estado As String)

        Dim dt As New DataTable
        dt.Columns.Add("idDocumento")
        dt.Columns.Add("fecha")
        dt.Columns.Add("tipo")
        dt.Columns.Add("nrodoc")
        dt.Columns.Add("monto")
        dt.Columns.Add("usado")
        dt.Columns.Add("saldo")
        dt.Columns.Add("estado")
        dt.Columns.Add("entidad")
        dt.Columns.Add("identidad")

        For Each i In anticipoSA.GetReclamacionesStatusVenta(New documentoventaAbarrotes With
                                                             {
                                                             .idEmpresa = Gempresas.IdEmpresaRuc,
                                                             .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                             .tipoVenta = "VRC",
                                                             .estadoCobro = estado
                                                             })

            dt.Rows.Add(i.idDocumento, i.fechaDoc, "NOTA DE CREDITO", i.numeroDoc, i.importeMN, i.TotalNotas, i.SaldoReclamacion.GetValueOrDefault, i.EstadoName, i.CustomEntidad.nombreCompleto, i.CustomEntidad.idEntidad)
        Next
        GridNotas.DataSource = dt
        GridNotas.BackColor = Color.White
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim ventaSA As New documentoVentaAbarrotesSA
        If GridNotas.Table.Records.Count = 0 Then Exit Sub

        Dim r As Record = GridNotas.Table.CurrentRecord
        If r IsNot Nothing Then

            If moduloR = "VENTAS" Then
                ventaSA.CambiarEstadoNotaCreditoAnticipo(New documentoventaAbarrotes With
                                                     {
                                                     .idDocumento = r.GetValue("idDocumento"),
                                                     .estadoCobro = EstadoCobroNotaCredito.DevolucionTramitePendiente
                                                     })
            ElseIf moduloR = "COMPRAS" Then
                ventaSA.CambiarEstadoRecCompra(New documentocompra With
                                                     {
                                                     .idDocumento = r.GetValue("idDocumento"),
                                                     .estadoPago = EstadoCobroNotaCredito.DevolucionTramitePendiente
                                                     })

            End If



            r.Delete()
                'FormMDI.GetStatus()
                'FormMDI.GetStatusNotasCreditoREM()
                MessageBox.Show("Devolucion en trámite!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Seleccione una fila válida!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub PanelError_Paint(sender As Object, e As PaintEventArgs) Handles PanelError.Paint

    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        If moduloR = "VENTAS" Then
            GetNotas(estadoR)
        ElseIf moduloR = "COMPRAS" Then

            GetNotasCompras(estadoR)
        End If
    End Sub
#End Region

End Class
