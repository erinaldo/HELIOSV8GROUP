Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping

Public Class TabFN_DevolucionNotaCreditoAnt
#Region "Attributes"
    Public Property anticipoSA As New documentoAnticipoSA
    Public Property documentoAnticipoConciliacionSA As New documentoAnticipoConciliacionSA
    Public tipoA As String
    Public estadoA As String
    Public Property FormPurchase As TabCT_ControlXCliente
    ' Public Property FormMDI As FormMaestroModuloAnticipos
#End Region

#Region "Constructors"
    Public Sub New(estado As String, tipo As String) ', form As FormMaestroModuloAnticipos)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'FormMDI = Form
        tipoA = tipo
        estadoA = estado
        FormatoGridAvanzado(GridNotas, True, False, 10.0F)
        'If tipoA = "AR" Then
        '    GetNotas(estado)
        'ElseIf tipoA = "AO" Then
        '    GetNotasCompras(estado)
        'End If
    End Sub

    Public Sub New(formRepPiscina As TabCT_ControlXCliente, estado As String, tipo As String) ', form As FormMaestroModuloAnticipos)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'FormMDI = Form
        tipoA = tipo
        estadoA = estado
        FormatoGridAvanzado(GridNotas, True, False, 10.0F)

        FormPurchase = formRepPiscina

        GradientPanel17.Visible = False
        ToolStripButton1.Visible = False
        ToolStripButton4.Visible = False
    End Sub

#End Region

#Region "Methods"

    Public Sub GetNotasXCliente(estado As String, IdCliente As Integer)

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

        For Each i In anticipoSA.GetAnticipoRecibidosStatusAll(New documentoventaAbarrotes With
                                                             {
                                                             .idEmpresa = Gempresas.IdEmpresaRuc,
                                                             .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                             .tipoVenta = "VNCA",
                                                             .estadoCobro = estado,
                                                             .idCliente = IdCliente
                                                             })

            dt.Rows.Add(i.idDocumento, i.fechaDoc, "NOTA DE CREDITO", i.numeroDoc, i.importeMN, i.TotalNotas, i.SaldoReclamacion.GetValueOrDefault, i.EstadoName, i.CustomEntidad.nombreCompleto, i.CustomEntidad.idEntidad)
        Next
        GridNotas.DataSource = dt
        GridNotas.BackColor = Color.White
    End Sub

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

        For Each i In anticipoSA.GetAnticiposOtorgadosStatusAll(New documentocompra With
                                                             {
                                                             .idEmpresa = Gempresas.IdEmpresaRuc,
                                                             .idCentroCosto = GEstableciento.IdEstablecimiento,
                                                             .tipoCompra = "VNCA",
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

        For Each i In anticipoSA.GetAnticipoRecibidosStatusAll(New documentoventaAbarrotes With
                                                             {
                                                             .idEmpresa = Gempresas.IdEmpresaRuc,
                                                             .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                             .tipoVenta = "VNCA",
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


            If tipoA = "AR" Then
                ventaSA.CambiarEstadoNotaCreditoAnticipo(New documentoventaAbarrotes With
                                                     {
                                                     .idDocumento = r.GetValue("idDocumento"),
                                                     .estadoCobro = EstadoCobroNotaCredito.DevolucionTramitePendiente
                                                     })
                r.Delete()
            ElseIf tipoA = "AO" Then
                ventaSA.CambiarEstadoNotaCreditoAnticipoCompra(New documentocompra With
                                                     {
                                                     .idDocumento = r.GetValue("idDocumento"),
                                                     .estadoPago = EstadoCobroNotaCredito.DevolucionTramitePendiente
                                                     })
                r.Delete()
            End If








            'FormMDI.GetStatus()
            'FormMDI.GetStatusNotasCreditoREM()
            MessageBox.Show("Devolucion en trámite!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Seleccione una fila válida!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        If tipoA = "AR" Then
            GetNotas(estadoA)
        ElseIf tipoA = "AO" Then
            GetNotasCompras(estadoA)
        End If
    End Sub
#End Region

End Class
