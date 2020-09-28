Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping

Public Class TabFN_ReclamacionStatus
#Region "Attributes"
    Public Property anticipoSA As New documentoAnticipoSA
    Public Property documentoAnticipoConciliacionSA As New documentoAnticipoConciliacionSA
    Public moduloR As String
    Public estadoR As String
    'Public Property FormMDI As FormMaestroReclamacionPagos
#End Region

#Region "Constructors"
    'Public Sub New(estado As String, Form As FormMaestroReclamacionPagos)
    Public Sub New(estado As String, modulo As String)

        ' This call is required by the designer.
        InitializeComponent()
        'FormMDI = Form
        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(GridNotas, True, False, 10.0F)
        FormatoGridAvanzado(GridDetalle, True, False, 10.0F)
        Select Case estado
            Case Anticipo.EstadoCobroNotaCredito.Pendiente
                ToolStripLabel1.Text = "Notas de crédito - Pendientes"
                ToolStripButton1.Visible = False
            Case Anticipo.EstadoCobroNotaCredito.Parcial
                ToolStripLabel1.Text = "Notas de crédito - En Curso"
                ToolStripButton1.Visible = False
            Case Anticipo.EstadoCobroNotaCredito.Completado
                ToolStripLabel1.Text = "Notas de crédito - Completadas"
                ToolStripButton1.Visible = False
        End Select

        moduloR = modulo
        estadoR = estado

        'If moduloR = "VENTAS" Then
        '    GetNotas(estado)
        'ElseIf moduloR = "COMPRAS" Then
        '    GetNotasCompras(estado)

        'End If

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

            dt.Rows.Add(i.idDocumento, i.fechaDoc, "COMPROMISO RECLAMACION", i.numeroDoc, i.importeMN, i.TotalNotas, i.SaldoReclamacion.GetValueOrDefault, i.EstadoName, i.CustomEntidad.nombreCompleto, i.CustomEntidad.idEntidad)
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

            dt.Rows.Add(i.idDocumento, i.fechaDoc, "COMPROMISO RECLAMACION", i.numeroDoc, i.importeMN, i.TotalNotas, i.SaldoReclamacion.GetValueOrDefault, i.EstadoName, i.CustomEntidad.nombreCompleto, i.CustomEntidad.idEntidad)
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

    Private Sub CambiarEstadoRecCompra(idDoc As Integer, r As Record)
        Dim documentoVentaSA As New documentoVentaAbarrotesSA
        Dim obj As New documentocompra
        obj.idDocumento = idDoc
        obj.estadoPago = Anticipo.EstadoCobroNotaCredito.SolicitudDevolucion
        documentoVentaSA.CambiarEstadoRecCompra(obj)
        r.Delete()
        GridDetalle.Table.Records.DeleteAll()

        'FormMDI.GetStatus()
        'FormMDI.GetStatusNotasCreditoREM()

        MessageBox.Show("Nota de crédito enviada a devolución!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

                If moduloR = "VENTAS" Then
                    GetAprobarEnvioADevolucion(Integer.Parse(r.GetValue("idDocumento")), r)
                ElseIf moduloR = "COMPRAS" Then
                    CambiarEstadoRecCompra(Integer.Parse(r.GetValue("idDocumento")), r)
                End If

            End If
            End If



    End Sub

    Private Sub GridNotas_TableControlCellClick(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs) Handles GridNotas.TableControlCellClick

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
