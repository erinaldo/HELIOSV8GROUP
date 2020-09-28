Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports PopupControl
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class ucDistribucion

#Region "Attributes"
    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
    Dim entidadSA As New entidadSA
    Private lstVentas As List(Of documentoventaAbarrotes)
    Public consultaClientes As List(Of entidad)
    Dim popup As Popup
    Public ControlEntidades As ucBuscarEntidades
    Public Property ListaGuias As List(Of documentoGuia)
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        FormatGrid_DarkCell(GridTraslado, Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center, BorderStyle.None)
        FormatGrid_DarkCell(gridGuias, Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center, BorderStyle.None)
        BunifuFlatButton8.Enabled = True
        ControlEntidades = New ucBuscarEntidades(Me)
        '   UserControl = New ucBuscarEntidades(Me)
        popup = New Popup(ControlEntidades)
        popup.Resizable = True
    End Sub
#End Region

#Region "Methods"
    Private Sub FillLSVClientes(consulta As List(Of entidad))
        LsvProveedor.Items.Clear()
        '     Dim image = ImageList1.Images(0)
        For Each i In consulta
            Dim n As New ListViewItem(i.idEntidad)

            n.SubItems.Add(i.nombreCompleto)
            n.SubItems.Add(i.nrodoc)
            n.SubItems.Add(i.tipoDoc)
            LsvProveedor.Items.Add(n)
        Next
    End Sub

    'GetVentasXDistribuirSelDate
    Private Sub GetVentasXDistribuirSelDate(ConsultarPor As String)
        Dim ventaSA As New documentoVentaAbarrotesSA
        Dim doc As New documento
        doc.TipoEnvio = ConsultarPor
        lstVentas = ventaSA.GetVentasXDistribuirSelDate(New documentoventaAbarrotes() With
                                                               {
                                                               .documento = doc,
                                                               .estadoEntrega = EstadoTrasladoVenta.EntregaConExito,
                                                               .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                               .fechaDoc = DateTime.Now
                                                        })

        Dim dt As New DataTable("Ventas pendiente de traslado")
        dt.Columns.Add("id")
        dt.Columns.Add("fechaoper")
        dt.Columns.Add("tipodoc")
        dt.Columns.Add("serie")
        dt.Columns.Add("numero")
        dt.Columns.Add("cliente")
        dt.Columns.Add("total")
        dt.Columns.Add("estadopago")
        dt.Columns.Add("estadotraslado")
        dt.Columns.Add("bttraslado")
        dt.Columns.Add("btHistorial")

        Dim statusPago = ""
        Dim statusTraslado = ""
        For Each i In lstVentas
            Select Case i.estadoCobro
                Case "DC"
                    statusPago = "Cobrado"
                Case "ANU"
                    statusPago = "Anulado"
                Case TIPO_VENTA.AnuladaPorNotaCredito
                    statusPago = "Anulado x NC."
                Case Else
                    statusPago = "Pendiente"
            End Select

            Select Case i.estadoEntrega
                Case EstadoTrasladoVenta.Pedido
                    statusTraslado = "Pendiente"
                Case EstadoTrasladoVenta.TrasladoParcial
                    statusTraslado = "Parcial"
                Case EstadoTrasladoVenta.EntregaConExito
                    statusTraslado = "Completado"
                Case Else
                    statusTraslado = "Rechazado"
            End Select

            dt.Rows.Add(i.idDocumento,
                       CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt "),
                        i.tipoDocumento,
                        i.serieVenta,
                        i.numeroVenta,
                        i.NombreEntidad,
                        i.ImporteNacional,
                        statusPago,
                        statusTraslado)
        Next
        GridTraslado.DataSource = dt

    End Sub

    Private Sub GetVentasXdistribuir()
        Dim ventaSA As New documentoVentaAbarrotesSA
        lstVentas = ventaSA.GetVentasXDistribuirSelCliente(New documentoventaAbarrotes() With
                                                               {
                                                               .estadoEntrega = EstadoTrasladoVenta.EntregaConExito,
                                                               .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                               .idCliente = Integer.Parse(TextCliente.Tag.ToString())})

        Dim dt As New DataTable("Ventas pendiente de traslado")
        dt.Columns.Add("id")
        dt.Columns.Add("fechaoper")
        dt.Columns.Add("tipodoc")
        dt.Columns.Add("serie")
        dt.Columns.Add("numero")
        dt.Columns.Add("cliente")
        dt.Columns.Add("total")
        dt.Columns.Add("estadopago")
        dt.Columns.Add("estadotraslado")
        dt.Columns.Add("bttraslado")
        dt.Columns.Add("btHistorial")

        Dim statusPago = ""
        Dim statusTraslado = ""
        For Each i In lstVentas
            Select Case i.estadoCobro
                Case "DC"
                    statusPago = "Cobrado"
                Case "ANU"
                    statusPago = "Anulado"
                Case TIPO_VENTA.AnuladaPorNotaCredito
                    statusPago = "Anulado x NC."
                Case Else
                    statusPago = "Pendiente"
            End Select

            Select Case i.estadoEntrega
                Case EstadoTrasladoVenta.Pedido
                    statusTraslado = "Pendiente"
                Case EstadoTrasladoVenta.TrasladoParcial
                    statusTraslado = "Parcial"
                Case EstadoTrasladoVenta.EntregaConExito
                    statusTraslado = "Completado"
                Case Else
                    statusTraslado = "Rechazado"
            End Select

            dt.Rows.Add(i.idDocumento,
                       CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt "),
                        i.tipoDocumento,
                        i.serieVenta,
                        i.numeroVenta,
                        i.NombreEntidad,
                        i.ImporteNacional,
                        statusPago,
                        statusTraslado)
        Next
        GridTraslado.DataSource = dt

    End Sub

    Public Sub GetVentasXdistribuirSelCliente(idCliente As Integer)
        Dim ventaSA As New documentoVentaAbarrotesSA
        Dim listaPendientes = lstVentas.Where(Function(o) o.idCliente = idCliente).ToList

        Dim dt As New DataTable("Ventas pendiente de traslado")
        dt.Columns.Add("id")
        dt.Columns.Add("fechaoper")
        dt.Columns.Add("tipodoc")
        dt.Columns.Add("serie")
        dt.Columns.Add("numero")
        dt.Columns.Add("cliente")
        dt.Columns.Add("total")
        dt.Columns.Add("estadopago")
        dt.Columns.Add("estadotraslado")
        dt.Columns.Add("bttraslado")
        dt.Columns.Add("btHistorial")

        Dim statusPago = ""
        Dim statusTraslado = ""
        For Each i In listaPendientes
            Select Case i.estadoCobro
                Case "DC"
                    statusPago = "Cobrado"
                Case "ANU"
                    statusPago = "Anulado"
                Case TIPO_VENTA.AnuladaPorNotaCredito
                    statusPago = "Anulado x NC."
                Case Else
                    statusPago = "Pendiente"
            End Select

            Select Case i.estadoEntrega
                Case EstadoTrasladoVenta.Pedido
                    statusTraslado = "Pendiente"
                Case EstadoTrasladoVenta.TrasladoParcial
                    statusTraslado = "Parcial"
                Case EstadoTrasladoVenta.EntregaConExito
                    statusTraslado = "Completado"
                Case Else
                    statusTraslado = "Rechazado"
            End Select

            dt.Rows.Add(i.idDocumento,
                       CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt "),
                        i.tipoDocumento,
                        i.serieVenta,
                        i.numeroVenta,
                        i.NombreEntidad,
                        i.ImporteNacional,
                        statusPago,
                        statusTraslado)
        Next
        GridTraslado.DataSource = dt

    End Sub
#End Region

#Region "Events"
    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click

        If lstVentas IsNot Nothing Then
            Dim consulClientes = (From n In lstVentas
                                  Select n.CustomEntidad).ToList


            consultaClientes = consulClientes 'entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, "CL", TextLikeCliente.Text.Trim)
            ControlEntidades.FillLSVClientes(consultaClientes)
            'popup.Show(TryCast(sender, ButtonAdv))
            popup.Show(TextCliente)
        End If



    End Sub

    Private Sub LsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles LsvProveedor.MouseDoubleClick
        Me.pcLikeCategoria.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub pcLikeCategoria_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcLikeCategoria.CloseUp
        Dim beneficioSA As New beneficioSA
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.PopupCloseType = PopupCloseType.Done Then
                If LsvProveedor.SelectedItems.Count > 0 Then

                    TextCliente.Text = LsvProveedor.SelectedItems(0).SubItems(1).Text
                    TextCliente.Tag = LsvProveedor.SelectedItems(0).SubItems(0).Text
                    LabelNumDoc.Text = LsvProveedor.SelectedItems(0).SubItems(2).Text
                End If
            End If

            'Set focus back to textbox.
            If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
                Me.TextCliente.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub BunifuFlatButton8_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton8.Click
        Try
            'GetVentasXdistribuir()
            GetVentasXDistribuirSelDate(ComboDateConsulta.Text)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub GridPrecios_TableControlDrawCell(sender As Object, e As GridTableControlDrawCellEventArgs) Handles GridTraslado.TableControlDrawCell
        If e.Inner.Style.CellType = "PushButton" Then
            e.Inner.Cancel = True

            ' //Draw the Image in a cell.
            If e.Inner.ColIndex = 10 Then
                e.Inner.Style.Description = "Trasladar"
                e.Inner.Style.TextColor = Color.Yellow
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)
                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3),
                                           New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6)
                    )
                '    e.Inner.Graphics.DrawImage(Me.ImageList1.Images(0), irect)
            End If

            If e.Inner.ColIndex = 11 Then
                e.Inner.Style.Description = "Historial"
                e.Inner.Style.TextColor = Color.Yellow
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)
                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3),
                                           New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6)
                    )
                '    e.Inner.Graphics.DrawImage(Me.ImageList1.Images(0), irect)
            End If
        End If
    End Sub

    Private Sub GridPrecios_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs) Handles GridTraslado.TableControlPushButtonClick
        Me.Cursor = Cursors.WaitCursor
        Dim precioSA As New detalleitemequivalencia_preciosSA
        Try
            If e.Inner.ColIndex = 10 Then
                If GridTraslado.Table.CurrentRecord IsNot Nothing Then
                    If GridTraslado.Table.CurrentRecord IsNot Nothing Then
                        Dim style As GridTableCellStyleInfo = e.TableControl.Model(e.Inner.RowIndex, e.Inner.ColIndex)
                        Dim codigoVenta = style.TableCellIdentity.Table.CurrentRecord.GetValue("id")
                        Dim venta = lstVentas.Where(Function(o) o.idDocumento = codigoVenta).SingleOrDefault()

                        If venta IsNot Nothing Then
                            Dim f As New FormGuiaRemision8(venta)
                            f.StartPosition = FormStartPosition.CenterParent
                            f.ShowDialog(Me)
                        End If

                    End If
                End If
            End If

            If e.Inner.ColIndex = 11 Then
                If GridTraslado.Table.CurrentRecord IsNot Nothing Then
                    If GridTraslado.Table.CurrentRecord IsNot Nothing Then
                        Dim style As GridTableCellStyleInfo = e.TableControl.Model(e.Inner.RowIndex, e.Inner.ColIndex)
                        Dim codigoVenta = style.TableCellIdentity.Table.CurrentRecord.GetValue("id")
                        Dim venta = lstVentas.Where(Function(o) o.idDocumento = codigoVenta).SingleOrDefault()

                        If venta IsNot Nothing Then
                            Dim f As New ucHistorialGuiaDoc(venta)
                            f.StartPosition = FormStartPosition.CenterParent
                            f.ShowDialog(Me)
                        End If

                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub TextLikeCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles TextLikeCliente.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Dim filter = TextLikeCliente.Text.Trim
            Dim consulta = consultaClientes.Where(Function(o) o.nombreCompleto.Contains(filter) Or o.nrodoc.Contains(filter)).ToList
            LsvProveedor.Items.Clear()
            If consulta.Count > 0 Then
                FillLSVClientes(consulta)
                Me.pcLikeCategoria.Size = New Size(320, 194)
                Me.pcLikeCategoria.ParentControl = Me.TextCliente
                Me.pcLikeCategoria.ShowPopup(Point.Empty)
            End If
        End If
    End Sub

    Private Sub ComboDateConsulta_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboDateConsulta.SelectionChangeCommitted
        Select Case ComboDateConsulta.Text
            Case "HOY"

            Case "ESTA SEMANA"

            Case "ESTE MES"

        End Select
    End Sub

    Private Sub BunifuFlatButton5_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton5.Click
        Dim f As New FormFiltroAvanzadoPeriodo()
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        If f.Tag IsNot Nothing Then
            Dim periodoSel = CType(f.Tag, DateTime?)
            PictureLoad.Visible = True
            BunifuFlatButton5.Enabled = False
            Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetListaGuiasMes(periodoSel, "MES")))
            thread.Start()
        End If
    End Sub

    Private Sub GetListaGuiasMes(dateSel As DateTime, tipoEnvio As String)
        Dim documentoguiaSA As New DocumentoGuiaSA

        Dim flag As String
        If (tipoEnvio = "MES") Then
            flag = "Guía emitidas del Mes " & GetPeriodo(dateSel, True)
        Else
            flag = "Guía emitidas del Día " & dateSel.ToShortDateString
        End If

        Dim dt As New DataTable(flag)
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("fecha", GetType(String)))
        dt.Columns.Add(New DataColumn("comprobante", GetType(String)))
        dt.Columns.Add(New DataColumn("nro", GetType(String)))
        dt.Columns.Add(New DataColumn("cliente", GetType(String)))
        dt.Columns.Add(New DataColumn("docliente", GetType(String)))
        dt.Columns.Add(New DataColumn("almacenpartida", GetType(String)))
        dt.Columns.Add(New DataColumn("almacenllegada", GetType(String)))
        dt.Columns.Add(New DataColumn("itemsTransferidos", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))

        Dim str As String
        Dim doc As New documento
        doc.TipoEnvio = tipoEnvio
        ListaGuias = documentoguiaSA.GetGuiaRemisionListSelDate(New documentoGuia With {.fechaDoc = dateSel, .documento = doc})
        For Each i As documentoGuia In documentoguiaSA.GetGuiaRemisionListSelDate(New documentoGuia With {.fechaDoc = dateSel, .documento = doc}).ToList
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = str
            dr(2) = i.tipoDoc
            dr(3) = $"{i.serie}-{i.numeroDoc}"
            dr(4) = i.CustomEntidad.nombreCompleto
            dr(5) = i.CustomEntidad.nrodoc
            dr(6) = i.direccionPartida
            dr(7) = i.DireccionLlegada
            dr(8) = $"{i.documentoguiaDetalle.Count} item(s)"
            dr(9) = i.estado
            dt.Rows.Add(dr)
        Next
        setDatasource(dt)
    End Sub

    Public Sub setDatasource(ByVal table As DataTable)
        If Me.InvokeRequired Then
            Dim deleg As New SetDataSourceDelegate(AddressOf setDatasource)
            Invoke(deleg, New Object() {table})
        Else
            gridGuias.DataSource = table
            PictureLoad.Visible = False
            BunifuFlatButton5.Enabled = True
            BunifuFlatButton3.Enabled = True
        End If
    End Sub

    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton3.Click
        Dim f As New FormFiltroAvanzadoDia()
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        If f.Tag IsNot Nothing Then
            Dim FechaSel = CType(f.Tag, DateTime?)
            PictureLoad.Visible = True
            BunifuFlatButton3.Enabled = False

            Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetListaGuiasMes(FechaSel, "DIA")))
            thread.Start()

        End If
    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs)
        'Dim r As Record = gridGuias.Table.CurrentRecord
        'If r IsNot Nothing Then
        '    Dim f As New ucHistorialGuiaDoc(venta)
        '    f.StartPosition = FormStartPosition.CenterParent
        '    f.ShowDialog(Me)
        'End If
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        Dim r As Record = gridGuias.Table.CurrentRecord
        'Dim guiaSA As New DocumentoSA
        Dim guiaSA As New DocumentoGuiaSA
        If r IsNot Nothing Then
            If MessageBox.Show("Elminar guía seleccionada?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim codigoGuia = r.GetValue("idDocumento")
                '    guiaSA.DeleteSingleVariable(codigoGuia)
                guiaSA.EliminatGuia(New documento() With {.idDocumento = codigoGuia})
                MessageBox.Show("Documento eliminado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                r.Delete()
            End If
        End If
    End Sub
#End Region


End Class
