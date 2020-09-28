Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class FormCanastaPedidoDeVentasInfra

    Protected Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
    Public Property DocumentoVentaSA As New documentoVentaAbarrotesSA
    Public Property DocumentoVentaDetSA As New documentoVentaAbarrotesDetSA

    Public Property listaDistribucion As List(Of String)

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        FormatoGridAvanzado(GridPedidos, False, False, 11.0F)
        GridPedidos.Enabled = True
        ProgressBar1.Visible = True
        ProgressBar1.Style = ProgressBarStyle.Marquee
        Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf GetListaVentasPorPeriodo))
        thread.Start()
    End Sub
#End Region

#Region "Methods"
    Private Sub GetListaVentasPorPeriodo()
        Dim dt As New DataTable("Pedidos del día " & Date.Now & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("pedido", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("importeTotal", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeUS", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("usuarioActualizacion", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("estadoPreparado", GetType(String)))
        dt.Columns.Add(New DataColumn("idcliente", GetType(Integer)))
        dt.Columns.Add(New DataColumn("validar", GetType(Boolean)))


        Dim str As String
        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarAllVentasPeriodoPendienteInfra(GEstableciento.IdEstablecimiento, PeriodoGeneral, listaDistribucion).OrderByDescending(Function(o) o.fechaDoc).ToList
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoVenta
            dr(2) = str
            dr(3) = i.nombrePedido
            dr(4) = i.tipoDocumento
            dr(5) = i.serie
            dr(6) = i.numeroDoc
            dr(7) = i.NroDocEntidad
            dr(8) = i.NombreEntidad
            dr(9) = FormatNumber(i.ImporteNacional, 2)
            dr(10) = i.tipoCambio
            dr(11) = FormatNumber(i.ImporteExtranjero, 2)
            dr(12) = i.moneda
            dr(13) = i.usuarioActualizacion

            Select Case i.tipoVenta
                Case "NTC"
                    dr(14) = "-"
                Case Else
                    Select Case i.estadoCobro
                        Case "DC"
                            dr(14) = "Cobrado"
                        Case "ANU"
                            dr(14) = "Anulado"
                        Case TIPO_VENTA.AnuladaPorNotaCredito
                            dr(14) = "Anulado x NC."
                        Case Else
                            dr(14) = "Pendiente"
                    End Select
            End Select
            Select Case i.notaCredito
                Case StatusVentaMatizados.PorPreparar
                    dr(15) = "Pendiente"
                Case StatusVentaMatizados.TerminadaYentregada
                    dr(15) = "Entregada"
            End Select
            dr(16) = i.idCliente
            dr(17) = True
            dt.Rows.Add(dr)
        Next
        setDataSource(dt)
    End Sub

    Private Sub setDataSource(ByVal table As DataTable)
        If Me.InvokeRequired Then
            'Me.Invoke(New SetDataSourceDelegate(AddressOf setDataSource), table)

            Dim deleg As New SetDataSourceDelegate(AddressOf setDataSource)
            Invoke(deleg, New Object() {table})
        Else
            GridPedidos.DataSource = table
            GridPedidos.TopLevelGroupOptions.ShowCaption = True
            ProgressBar1.Visible = False
        End If
    End Sub

    Private Sub GridPedidos_TableControlCellClick(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs) Handles GridPedidos.TableControlCellClick

    End Sub

    Private Sub GridPedidos_TableControlCellDoubleClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridPedidos.TableControlCellDoubleClick

    End Sub

    Private Sub ButtonAdv15_Click(sender As Object, e As EventArgs) Handles ButtonAdv15.Click
        ProgressBar1.Visible = True
        ProgressBar1.Style = ProgressBarStyle.Marquee
        Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf GetListaVentasPorPeriodo))
        thread.Start()
    End Sub

    Public Sub EliminarPedido(intIdDocumento As Integer)
        Dim documentoSA As New DocumentoSA
        Dim objDocumento As New documento
        Try
            With objDocumento
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idCentroCosto = GEstableciento.IdEstablecimiento
                .idDocumento = intIdDocumento
            End With

            documentoSA.EliminarPedidos(objDocumento)
            Me.GridPedidos.Table.CurrentRecord.Delete()
            GridPedidos.Refresh()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Dim DocumentoSA As New DocumentoSA
        Try
            If GridPedidos.Table.Records.Count > 0 Then
                If Not IsNothing(Me.GridPedidos.Table.CurrentRecord) Then
                    If MessageBox.Show("Desea elimiar el pedido seleccionado?", "Pedidos de venta!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Dim r As Record = GridPedidos.Table.CurrentRecord
                        If r IsNot Nothing Then
                            Dim codDocumento = Integer.Parse(r.GetValue("idDocumento"))
                            EliminarPedido(codDocumento)
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al eliminar, consulte con el proveedor del sistema!")
        End Try

    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click
        LoadingAnimator.Wire(GridPedidos.TableControl)
        Dim r As Record = GridPedidos.Table.CurrentRecord
        Dim nombrePedido = Nothing
        If r IsNot Nothing Then
            Dim frmDetalleVentaView = New frmDetalleVentaView(Integer.Parse(r.GetValue("idDocumento")))
            nombrePedido = r.GetValue("pedido")
            If nombrePedido.ToString.Trim.Length > 0 Then
                frmDetalleVentaView.CaptionLabels(1).Text = r.GetValue("pedido")
            Else
                frmDetalleVentaView.CaptionLabels(1).Text = r.GetValue("NombreEntidad")
            End If
            frmDetalleVentaView.StartPosition = FormStartPosition.CenterParent
            frmDetalleVentaView.ShowDialog(Me)
        Else
            MessageBox.Show("Debe seleccionar un pedido!", "Seleccionar Fila", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        LoadingAnimator.UnWire(GridPedidos.TableControl)
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Dim listaDocumento As New List(Of Integer)
        If GridPedidos.Table.Records.Count > 0 Then

            For Each ITEM In GridPedidos.Table.Records
                If (ITEM.GetValue("validar") = True) Then
                    Dim codDocumento = Integer.Parse(ITEM.GetValue("idDocumento"))
                    listaDocumento.Add(codDocumento)
                End If
            Next

            Dim venta = DocumentoVentaSA.GetListaVentaID(New documento With {.ListaDocumentoID = listaDocumento, .tipoDoc = "VNP"})
            'Tag = venta
            'Close()


            If (venta.Count > 0) Then

                Dim f As New FormCajeroIndependienteV2
                f.DocumentoVentaLista = venta
                f.CargarPagos()
                f.MaximizeBox = False
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog(Me)
                Dispose()
            End If


        End If
    End Sub
#End Region
End Class