Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping

Public Class UCPagoCompletoDocumento

#Region "Attributes"
    Public Property cuentaSA As New EstadosFinancierosSA
    Public Property DocCaja As List(Of documento)
    Public Property UCCompraCabecera As UCEstructuraDocumentocabecera
    Private listaMediosPago As List(Of tabladetalle)
    Private listaCuentas As List(Of estadosFinancieros)
#End Region

#Region "Constructors"
    Public Sub New(documentoCaja As List(Of documento), ucCompra As UCEstructuraDocumentocabecera)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        FormatoGridAvanzado(GridCompra, False, False, 9.0F)
        DocCaja = documentoCaja
        UCCompraCabecera = ucCompra
        GetCombos()
        FormatoGrid()
    End Sub
#End Region

#Region "Methods"
    Private Sub FormatoGrid()
        For Each i In GridCompra.TableDescriptor.Columns
            i.AllowSort = False
            i.Appearance.AnyRecordFieldCell.TextColor = Color.Black
        Next
    End Sub

    Private Sub GetCombos()
        listaMediosPago = General.TablasGenerales.GetFormasDePago
        listaCuentas = cuentaSA.ObtenerEstadosFinancierosPorEstablecimiento(New estadosFinancieros With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})

        cboFormaPago.DataSource = listaMediosPago.ToList()
        cboFormaPago.DisplayMember = "descripcion"
        cboFormaPago.ValueMember = "codigoDetalle"

        ComboCuentaFinanciera.DataSource = listaCuentas.ToList()
        ComboCuentaFinanciera.DisplayMember = "descripcion"
        ComboCuentaFinanciera.ValueMember = "idestado"

    End Sub

    Private Sub AgregarPago()

        Dim codigoDocumento = System.Guid.NewGuid()


        Dim documento As New documento With
        {
        .Codigo = codigoDocumento.ToString(),
        .idEmpresa = Gempresas.IdEmpresaRuc,
        .idCentroCosto = GEstableciento.IdEstablecimiento,
        .tipoDoc = "9903",
        .fechaProceso = Date.Now,
        .moneda = "1",
        .idEntidad = UCCompraCabecera.TextProveedor.Tag,
        .entidad = UCCompraCabecera.TextProveedor.Text,
        .tipoEntidad = "PR",
        .nrodocEntidad = UCCompraCabecera.TextNumIdentrazon.Text,
        .nroDoc = 0,
        .tipoOperacion = StatusTipoOperacion.PAGO_A_PROVEEDORES,
        .usuarioActualizacion = usuario.IDUsuario,
        .fechaActualizacion = Date.Now
        }

        documento.documentoCaja = New documentoCaja With
        {
        .dni = codigoDocumento.ToString(),
        .idEmpresa = Gempresas.IdEmpresaRuc,
        .idEstablecimiento = GEstableciento.IdEstablecimiento,
        .codigoLibro = "1",
        .tipoMovimiento = TIPO_COMPRA.PAGO.PAGADO,
        .codigoProveedor = documento.idEntidad,
        .idPersonal = documento.idEntidad,
        .tipoPersona = documento.tipoEntidad,
        .fechaProceso = documento.fechaProceso,
        .periodo = GetPeriodo(documento.fechaProceso, True),
        .fechaCobro = documento.fechaProceso,
        .tipoDocPago = documento.tipoDoc,
        .formapago = cboFormaPago.SelectedValue,
        .numeroDoc = documento.nroDoc,
        .moneda = documento.moneda,
        .entidadFinanciera = ComboCuentaFinanciera.SelectedValue,
        .entidadFinancieraDestino = Nothing,
        .tipoOperacion = documento.tipoOperacion,
        .numeroOperacion = TextNumOper.Text,
        .tipoCambio = TmpTipoCambio,
        .ctaCorrienteDeposito = TextCodigoTarjeta.Text,
        .montoSoles = TextMonto.DecimalValue,
        .montoUsd = 0,
        .glosa = "Pago al contado",
        .entregado = "SI",
        .movimientoCaja = TIPO_COMPRA.COMPRA,
        .idcosto = 0,
        .estado = 1,
        .estadopago = 1,
        .usuarioModificacion = usuario.IDUsuario,
        .fechaModificacion = Date.Now,
        .documentoCajaDetalle = New List(Of documentoCajaDetalle)
        }

        Dim montoPago = TextMonto.DecimalValue
        For Each i In UCCompraCabecera.ListaproductosComprados
            If montoPago > 0 Then
                If i.MontoSaldoV2 > 0 Then
                    If i.MontoSaldoV2 > montoPago Then
                        Dim canUso = montoPago
                        i.MontoPago = canUso
                        i.estadoPago = i.ItemPendiente
                    ElseIf i.MontoSaldoV2 = montoPago Then
                        i.MontoPago = montoPago
                        i.estadoPago = i.ItemSaldado
                    Else
                        Dim canUso = i.MontoSaldoV2
                        i.MontoPago = canUso
                        i.estadoPago = i.ItemSaldado
                    End If
                    montoPago -= i.MontoPago 'ImporteDisponible
                    documento.documentoCaja.documentoCajaDetalle.Add(New documentoCajaDetalle With
                                   {
                                   .fecha = Date.Now,
                                   .codigoLote = 0,
                                   .otroMN = 0,
                                   .idItem = i.idItem,
                                   .DetalleItem = i.CustomProducto.descripcionItem,
                                   .montoSoles = i.MontoPago,
                                   .montoUsd = FormatNumber(i.MontoPago / TmpTipoCambio, 2),
                                   .diferTipoCambio = TmpTipoCambio,
                                   .tipoCambioTransacc = TmpTipoCambio,
                                   .entregado = "SI",
                                   .usuarioModificacion = usuario.IDUsuario,
                                   .documentoAfectado = CInt(Me.Tag),
                                   .documentoAfectadodetalle = i.secuencia,
                                   .cuenta = i.CodigoCosto,
                                   .EstadoCobro = i.estadoPago,
                                   .fechaModificacion = DateTime.Now
                                   })

                    i.estadoPago = i.estadoPago
                    i.CustomDocumentoCaja.Add(New documentoCaja With {.dni = codigoDocumento.ToString(), .cuentaCosteo = i.CodigoCosto, .montoSoles = i.MontoPago})
                End If

                'If i.MontoSaldo > 0 Then
                '    If i.MontoSaldo > montoPago Then
                '        Dim canUso = montoPago
                '        i.MontoPago = canUso
                '        i.estadoPago = i.ItemPendiente
                '    ElseIf i.MontoSaldo = montoPago Then
                '        i.MontoPago = montoPago
                '        i.estadoPago = i.ItemSaldado
                '    Else
                '        Dim canUso = i.MontoSaldo
                '        i.MontoPago = canUso
                '        i.estadoPago = i.ItemSaldado
                '    End If
                '    montoPago -= i.MontoPago 'ImporteDisponible
                '    documento.documentoCaja.documentoCajaDetalle.Add(New documentoCajaDetalle With
                '                   {
                '                   .fecha = Date.Now,
                '                   .codigoLote = 0,
                '                   .otroMN = 0,
                '                   .idItem = i.idItem,
                '                   .DetalleItem = i.CustomProducto.descripcionItem,
                '                   .montoSoles = i.MontoPago,
                '                   .montoUsd = FormatNumber(i.MontoPago / TmpTipoCambio, 2),
                '                   .diferTipoCambio = TmpTipoCambio,
                '                   .tipoCambioTransacc = TmpTipoCambio,
                '                   .entregado = "SI",
                '                   .usuarioModificacion = usuario.IDUsuario,
                '                   .documentoAfectado = CInt(Me.Tag),
                '                   .documentoAfectadodetalle = i.secuencia,
                '                   .cuenta = i.CodigoCosto,
                '                   .EstadoCobro = i.estadoPago,
                '                   .fechaModificacion = DateTime.Now
                '                   })

                '    i.estadoPago = i.estadoPago

                'End If
            End If
        Next
        TextMonto.DecimalValue = 0
        DocCaja.Add(documento)
        SumaPagos()
    End Sub

    Public Sub SumaPagos()
        Dim suma = Aggregate i In DocCaja
                       Into SumaPagos = Sum(i.documentoCaja.montoSoles)

        TextPagado.DecimalValue = suma
        TextSaldo.DecimalValue = TextCompraTotal.DecimalValue - suma
    End Sub

    Public Sub LoadGrid()
        Dim dt As New DataTable
        dt.Columns.Add("IDforma")
        dt.Columns.Add("forma")
        dt.Columns.Add("idCuenta")
        dt.Columns.Add("Cuenta")
        dt.Columns.Add("tipodoc")
        dt.Columns.Add("nrooper")
        dt.Columns.Add("codigoTarjeta")
        dt.Columns.Add("monto")
        dt.Columns.Add("action")
        dt.Columns.Add("iddocumento")

        ListDetalle.Items.Clear()

        For Each i In DocCaja.ToList
            Dim MedioPago = listaMediosPago.Where(Function(o) o.codigoDetalle = i.documentoCaja.formapago).FirstOrDefault

            Dim cuenta = listaCuentas.Where(Function(o) o.idestado = i.documentoCaja.entidadFinanciera).FirstOrDefault

            dt.Rows.Add(
                MedioPago.codigoDetalle,
                MedioPago.descripcion,
                cuenta.idestado,
                cuenta.descripcion,
                i.documentoCaja.tipoDocPago,
                i.documentoCaja.numeroOperacion,
                i.documentoCaja.ctaCorrienteDeposito,
                i.documentoCaja.montoSoles, Nothing, i.Codigo)
        Next
        GridCompra.DataSource = dt
    End Sub
#End Region

#Region "Events"
    Private Sub BunifuThinButton24_Click(sender As Object, e As EventArgs) Handles BunifuThinButton24.Click
        If TextMonto.DecimalValue > 0 Then
            If ValidarImporteCompra() Then
                If validarCuentaExistente() = False Then
                    AgregarPago()
                    LoadGrid()
                Else
                    MessageBox.Show("Debe ingresar una cuenta nueva", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    ComboCuentaFinanciera.Select()
                    ComboCuentaFinanciera.DroppedDown = True
                End If
            Else
                MessageBox.Show("Debe ingresar un importe que no suepre la compra total", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Debe ingresar un monto a pagar mayor a cero", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Function ValidarImporteCompra() As Boolean
        ValidarImporteCompra = True

        Dim suma = Aggregate i In DocCaja
                       Into SumaPagos = Sum(i.documentoCaja.montoSoles)

        Dim montoabonado = TextMonto.DecimalValue + suma.GetValueOrDefault

        If montoabonado > TextCompraTotal.DecimalValue Then
            ValidarImporteCompra = False
        End If
    End Function

    Private Function validarCuentaExistente() As Boolean
        Dim cuenta = ComboCuentaFinanciera.SelectedValue

        Dim existe = DocCaja.Any(Function(o) o.documentoCaja.entidadFinanciera = cuenta)

        Return existe
    End Function

    Private Sub GridEquivalencia_TableControlDrawCell(sender As Object, e As GridTableControlDrawCellEventArgs) Handles GridCompra.TableControlDrawCell
        If e.Inner.Style.CellType = "PushButton" Then
            e.Inner.Cancel = True

            ' //Draw the Image in a cell.
            If e.Inner.ColIndex = 7 Then
                e.Inner.Style.Description = "Eliminar"
                e.Inner.Style.TextColor = Color.Black
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)
                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3),
                                           New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6)
                    )
                '    e.Inner.Graphics.DrawImage(Me.ImageList1.Images(0), irect)
            End If
        End If
    End Sub

    Private Sub GridEquivalencia_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs) Handles GridCompra.TableControlPushButtonClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.Inner.ColIndex = 7 Then
                Dim idDocumento = GridCompra.TableModel(e.Inner.RowIndex, 8).CellValue
                Dim MontoPagoAborrar = CDec(GridCompra.TableModel(e.Inner.RowIndex, 6).CellValue)
                Dim PagoDoc = DocCaja.Where(Function(o) o.Codigo = idDocumento).Single

                For Each i In PagoDoc.documentoCaja.documentoCajaDetalle.ToList
                    Dim itemCompra = UCCompraCabecera.ListaproductosComprados.Where(Function(o) o.CodigoCosto = i.cuenta).Single

                    'Dim pagoSel = itemCompra.CustomDocumentoCaja.Where(Function(o) o.montoSoles = MontoPagoAborrar).FirstOrDefault

                    For Each x In itemCompra.CustomDocumentoCaja.Where(Function(o) o.dni = PagoDoc.Codigo).ToList
                        itemCompra.CustomDocumentoCaja.Remove(x)
                    Next

                    'itemCompra.CustomDocumentoCaja = New List(Of documentoCaja)


                    ' itemCompra.MontoSaldo = itemCompra.MontoSaldo + i.montoSoles
                    'itemCompra.MontoPago = itemCompra.MontoPago - i.montoSoles

                Next

                DocCaja.Remove(PagoDoc)
                LoadGrid()
                SumaPagos()
                ListDetalle.Items.Clear()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub GridCompra_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridCompra.TableControlCellClick
        Dim currenrecord = GridCompra.Table.CurrentRecord
        If currenrecord IsNot Nothing Then
            Dim codigo = currenrecord.GetValue("iddocumento").ToString
            Getdetalle(codigo)
        End If
    End Sub

    Private Sub GridCompra_TableControlCurrentCellChanged(sender As Object, e As GridTableControlEventArgs) Handles GridCompra.TableControlCurrentCellChanged

    End Sub

    Private Sub dgvCompra_TableControlKeyDown(sender As Object, e As GridTableControlKeyEventArgs) Handles GridCompra.TableControlKeyDown
        Try
            Dim cc As GridCurrentCell = GridCompra.TableControl.CurrentCell
            If cc.RowIndex > -1 Then
                If e.Inner.KeyCode = Keys.Up Then
                    If cc IsNot Nothing Then
                        cc.ConfirmChanges()
                        If cc.RowIndex = 2 Then
                            Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(cc.RowIndex, cc.ColIndex), GridTableCellStyleInfo)
                            Dim currenrecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()

                            Dim codigo = currenrecord.GetValue("iddocumento").ToString
                            Getdetalle(codigo)

                        Else
                            Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(cc.RowIndex - 1, cc.ColIndex), GridTableCellStyleInfo)
                            Dim currenrecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
                            Dim codigo = currenrecord.GetValue("iddocumento").ToString
                            Getdetalle(codigo)
                        End If

                    End If
                ElseIf e.Inner.KeyCode = Keys.Down Then
                    If cc IsNot Nothing Then
                        cc.ConfirmChanges()
                        Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(cc.RowIndex + 1, cc.ColIndex), GridTableCellStyleInfo)
                        If style IsNot Nothing Then
                            ' Dim rows = dgvCompra.Table.Records.Count
                            If style.TableCellIdentity IsNot Nothing Then
                                Dim currenrecord = style.TableCellIdentity.DisplayElement.GetRecord()
                                If currenrecord IsNot Nothing Then
                                    Dim codigo = currenrecord.GetValue("iddocumento").ToString
                                    Getdetalle(codigo)
                                End If
                            End If

                        End If

                    End If

                Else
                    cc.ConfirmChanges()
                    Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(cc.RowIndex, cc.ColIndex), GridTableCellStyleInfo)
                    Dim currenrecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
                    Dim codigo = currenrecord.GetValue("iddocumento").ToString
                    Getdetalle(codigo)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Getdetalle(codigo As String)
        ListDetalle.Items.Clear()
        Dim listaDetalle = (From n In DocCaja
                            Where n.Codigo = codigo).SingleOrDefault


        For Each i As documentoCajaDetalle In listaDetalle.documentoCaja.documentoCajaDetalle.ToList
            Dim n As New ListViewItem(i.DetalleItem)
            n.SubItems.Add(i.montoSoles)
            ListDetalle.Items.Add(n)
        Next
        ListDetalle.Refresh()
    End Sub

    Private Sub BunifuThinButton21_Click(sender As Object, e As EventArgs) Handles BunifuThinButton21.Click
        For Each i In UCCompraCabecera.ListaproductosComprados.ToList
            i.CustomDocumentoCaja = New List(Of documentoCaja)
            i.MontoPago = 0
            i.estadoPago = "PN"
        Next
        DocCaja = New List(Of documento)
        GridCompra.Table.Records.DeleteAll()
        ListDetalle.Items.Clear()
    End Sub
#End Region

End Class
