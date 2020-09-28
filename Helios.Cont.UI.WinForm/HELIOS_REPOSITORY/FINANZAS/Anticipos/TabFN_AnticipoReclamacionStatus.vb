Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping

Public Class TabFN_AnticipoReclamacionStatus
#Region "Attributes"
    Public Property anticipoSA As New documentoAnticipoSA
    Public Property documentoAnticipoConciliacionSA As New documentoAnticipoConciliacionSA

    Public tipoA As String
    Public estadoA As String
    'Public Property FormMDI As FormMaestroModuloAnticipos

    Public Property FormPurchase As TabCT_ControlXCliente

#End Region

#Region "Constructors"
    Public Sub New(estado As String, tipo As String) ', form As FormMaestroModuloAnticipos)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(GridNotas, True, False, 10.0F)
        'FormatoGridAvanzado(GridDetalle, True, False, 10.0F)
        Select Case estado
            Case Anticipo.EstadoCobroNotaCredito.Pendiente
                ToolStripLabel1.Text = "Notas de crédito - Pendientes"

            Case Anticipo.EstadoCobroNotaCredito.Parcial
                ToolStripLabel1.Text = "Notas de crédito - En Curso"

            Case Anticipo.EstadoCobroNotaCredito.Completado
                ToolStripLabel1.Text = "Notas de crédito - Completadas"

        End Select
        'FormMDI = Form
        tipoA = tipo
        estadoA = estado
        'If tipoA = "AR" Then
        '    GetNotas(estado)
        'ElseIf tipoA = "AO" Then
        '    GetNotasCompras(estado)
        'End If
    End Sub

    Public Sub New(formRepPiscina As TabCT_ControlXCliente, estado As String, tipo As String)

        ' This call is required by the designer.
        InitializeComponent()
        'FormMDI = form
        FormatoGridAvanzado(GridNotas, True, False, 10.0F)
        'FormatoGridAvanzado(GridDetalle, True, False, 10.0F)
        Select Case estado
            Case Anticipo.EstadoCobroNotaCredito.Pendiente
                ToolStripLabel1.Text = "Notas de crédito - Pendientes"

            Case Anticipo.EstadoCobroNotaCredito.Parcial
                ToolStripLabel1.Text = "Notas de crédito - En Curso"

            Case Anticipo.EstadoCobroNotaCredito.Completado
                ToolStripLabel1.Text = "Notas de crédito - Completadas"

        End Select
        'FormMDI = Form
        tipoA = tipo
        estadoA = estado
        GradientPanel17.Visible = False
        ToolStripButton4.Visible = False
        FormPurchase = formRepPiscina

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

    Private Sub GetDetalle(idDocumento As Integer)
        Dim dt As New DataTable
        dt.Columns.Add("secuencia")
        dt.Columns.Add("fecha")
        dt.Columns.Add("tipooperacion")
        dt.Columns.Add("detalle")
        dt.Columns.Add("monto")
        dt.Columns.Add("caja")

        For Each i In documentoAnticipoConciliacionSA.GetMovimientosByDocumento(New documentoAnticipoConciliacion With {.idDocumento = idDocumento})
            dt.Rows.Add(i.secuencia, i.fechaRegistro, i.tipoOperacion, i.detalle, i.importe, i.idCajaUsuario)
        Next
        GridDetalle.DataSource = dt
    End Sub

    Private Sub GetAprobarEnvioADevolucion(idDoc As Integer, r As Record)
        Dim documentoVentaSA As New documentoVentaAbarrotesSA
        Dim obj As New documentoventaAbarrotes
        obj.idDocumento = idDoc
        obj.estadoCobro = Anticipo.EstadoCobroNotaCredito.SolicitudDevolucion
        documentoVentaSA.CambiarEstadoNotaCreditoAnticipo(obj)
        r.Delete()
        GridDetalle.Table.Records.DeleteAll()
        'FormMDI.GetStatus()
        'FormMDI.GetStatusNotasCreditoREM()
        MessageBox.Show("Nota de crédito enviada a devolución!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
#End Region

#Region "Events"
    Private Sub GridResumenFormaPago_SelectedRecordsChanged(sender As Object, e As SelectedRecordsChangedEventArgs) Handles GridNotas.SelectedRecordsChanged
        'Cursor = Cursors.WaitCursor
        'If e.SelectedRecord IsNot Nothing Then
        '    Dim r As Record = e.SelectedRecord.Record
        '    If r IsNot Nothing Then
        '        If GridNotas.Table.Records.Count > 0 Then
        '            GetDetalle(Integer.Parse(r.GetValue("idDocumento")))
        '        End If
        '    End If
        'End If
        'Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim r As Record = GridNotas.Table.CurrentRecord
        If r IsNot Nothing Then
            If GridNotas.Table.Records.Count > 0 Then
                GetAprobarEnvioADevolucion(Integer.Parse(r.GetValue("idDocumento")), r)
            End If
        End If
    End Sub

    Private Sub GridNotas_TableControlCellClick(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs) Handles GridNotas.TableControlCellClick

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
