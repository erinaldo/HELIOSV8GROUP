Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Public Class FrmPurchaseCreditNote

#Region "Atributos"

    Public Property ListaproductosComprados As List(Of documentocompradetalle)

#End Region

#Region "Constructor"

    Sub New(IdDocumento As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        FormatoGridAvanzado(GridCompra, False, False, 9.0F)



        Me.GridCompra.TableDescriptor.Columns("equivalencia").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.GridListControl

        Me.GridCompra.TableDescriptor.Columns("equivalencia").Appearance.AnyRecordFieldCell.DisplayMember = "unidadComercial"
        Me.GridCompra.TableDescriptor.Columns("equivalencia").Appearance.AnyRecordFieldCell.ValueMember = "equivalencia_id"
        Me.GridCompra.TableDescriptor.Columns("equivalencia").Appearance.AnyRecordFieldCell.DropDownStyle = GridDropDownStyle.Exclusive
        Me.GridCompra.TableDescriptor.Columns("equivalencia").Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.ShowCurrentCellEditing

        GridCompra.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell

        UbicarDocumentoCompra(IdDocumento)

        ' Add any initialization after the InitializeComponent() call.

    End Sub

#End Region

#Region "Metdos"

    Private Sub UbicarDocumentoCompra(idDocumento As Integer)
        Dim entidadSA As New entidadSA
        Dim compraSA As New DocumentoCompraSA
        Dim compra = compraSA.GetCompraID(New Business.Entity.documento With {.idDocumento = idDocumento})
        Dim ent = entidadSA.UbicarEntidadPorID(compra.idProveedor).FirstOrDefault
        If compra IsNot Nothing Then
            VerCabeceraDocumento(compra, ent)
            VerDetalleCompra(compra)
        End If
    End Sub


    Private Sub VerCabeceraDocumento(venta As documentocompra, ent As entidad)

        'Select Case venta.tipoCompra
        '    Case TIPO_COMPRA.COMPRA
        '        ComboComprobante.Text = "Compra recepción directa"
        '    Case TIPO_COMPRA.NOTA_DE_COMPRA
        '        ComboComprobante.Text = "NOTA DE COMPRA"
        '    Case TIPO_COMPRA.OTRAS_ENTRADAS
        '        ComboComprobante.Text = "Otra entrada"
        'End Select

        '.TxtDia.DecimalValue = venta.fechaDoc.Value.Day
        '.cboMesCompra.SelectedValue = String.Format("{0:00}", venta.fechaDoc.Value.Month)
        '.TextAnio.DecimalValue = venta.fechaDoc.Value.Year
        '.txtHora.Value = venta.fechaDoc.Value
        '.cboMoneda.SelectedValue = venta.monedaDoc
        '.txtTipoCambio.DecimalValue = venta.tipocambio.GetValueOrDefault
        '.txtIva.DoubleValue = venta.tasaIgv
        '.cboTipoDoc.SelectedValue = venta.tipoDoc
        txtSerieAfectado.Text = venta.serie
        txtNumeroAfectado.Text = venta.numeroDoc


        If ent IsNot Nothing Then
            If ent.tipoEntidad = "VR" Then

                txtRazonSocial.Tag = ent.idEntidad
                txtRazonSocial.Text = ent.nombreCompleto
            Else

                txtDniRuc.Text = ent.nrodoc
                txtRazonSocial.Text = ent.nombreCompleto
                txtRazonSocial.Tag = ent.idEntidad
            End If
        End If
    End Sub

    Private Sub VerDetalleCompra(compra As documentocompra)
        Dim productoSA As New detalleitemsSA
        ListaproductosComprados = compra.documentocompradetalle.ToList
        '     UCEstructuraCabeceraVenta.LoadCanastaVentas(UCEstructuraCabeceraVenta.ListaproductosVendidos)


        Dim dt As New DataTable
        dt.Columns.Add("secuencia")
        dt.Columns.Add("destino")
        dt.Columns.Add("lote")
        dt.Columns.Add("idItem")
        dt.Columns.Add("descripcion")

        dt.Columns.Add("tipoEx")
        dt.Columns.Add("almacenRef")

        dt.Columns.Add("unidad")
        dt.Columns.Add("estadocobro")

        dt.Columns.Add("cantidad")
        dt.Columns.Add("equivalencia")
        dt.Columns.Add("contenido_neto")
        dt.Columns.Add("vcmn")
        dt.Columns.Add("pumn")
        dt.Columns.Add("totalmn")
        dt.Columns.Add("vcme")
        dt.Columns.Add("pume")
        dt.Columns.Add("totalme")
        dt.Columns.Add("igvmn")
        dt.Columns.Add("igvme")
        dt.Columns.Add("tipoExistencia")
        dt.Columns.Add("marca")
        dt.Columns.Add("almacen")
        dt.Columns.Add("codigoLote")

        dt.Columns.Add("bonificacion")
        dt.Columns.Add("bonificaionval")

        Dim equivalencia As detalleitem_equivalencias
        Dim id_Equiva = 0
        For Each i In ListaproductosComprados
            Dim articulo = productoSA.GetUbicaProductoID(i.idItem)
            i.CustomProducto = articulo

            Dim eq = articulo.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = i.equivalencia_id).SingleOrDefault

            i.CustomProducto_equivalencia = eq

            If i.CustomProducto_equivalencia IsNot Nothing Then
                i.CodigoCosto = i.secuencia
                equivalencia = i.CustomProducto_equivalencia
                id_Equiva = i.CustomProducto_equivalencia.equivalencia_id



                dt.Rows.Add(i.secuencia,
                        i.CustomProducto.origenProducto,
                        i.idLote,
                        i.CustomProducto.codigodetalle,
                        i.CustomProducto.descripcionItem,
                        i.CustomProducto.tipoExistencia,
                        i.almacenRef,
                        i.CustomProducto.unidad1,
                        i.estadoPago,
                        i.monto1,
                        id_Equiva,
                        equivalencia.contenido_neto.GetValueOrDefault,
                        0,
                        0,
                        i.montokardex.GetValueOrDefault,
                        i.montokardexUS.GetValueOrDefault,
                        i.importe.GetValueOrDefault,
                        i.importeUS.GetValueOrDefault,
                        i.montoIgv.GetValueOrDefault,
                        i.montoIgvUS.GetValueOrDefault,
                        If(i.bonificacion = "S", True, False), i.bonificacion)
            Else
                dt.Rows.Add(i.CodigoCosto,
                        i.CustomProducto.origenProducto,
                        i.CustomProducto.codigodetalle,
                        i.CustomProducto.descripcionItem,
                        i.CustomProducto.unidad1,
                        i.CustomProducto.composicion,
                        i.monto1,
                        "",
                        "",
                        i.montokardex.GetValueOrDefault, 0,
                        i.importe.GetValueOrDefault,
                        i.montokardexUS.GetValueOrDefault, 0,
                        i.importeUS.GetValueOrDefault,
                        i.montoIgv.GetValueOrDefault,
                        i.montoIgvUS.GetValueOrDefault,
                        i.CustomProducto.tipoExistencia,
                        "-",
                        0,
                        0, If(i.bonificacion = "S", True, False), i.bonificacion)
            End If


        Next



        GridCompra.DataSource = dt
        GridCompra.Refresh()
        'GetTotalesDocumento()
    End Sub





    Private Function GetEquivalencias(lista As List(Of detalleitem_equivalencias)) As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("equivalencia_id")
        dt.Columns.Add("unidadComercial")
        dt.Columns.Add("cntenido_neto")

        dt.Columns(0).ColumnMapping = MappingType.Hidden

        For Each i In lista
            dt.Rows.Add(i.equivalencia_id, i.unidadComercial, i.contenido_neto)
        Next
        Return dt
    End Function



    Private Sub GridCompra_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles GridCompra.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.Column.Name = "equivalencia" AndAlso e.TableCellIdentity.DisplayElement.Kind = Syncfusion.Grouping.DisplayElementKind.Record Then

            Dim value As String = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("idItem").ToString()
            Dim codigo As String = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("secuencia").ToString()
            Dim p = ListaproductosComprados.Where(Function(o) o.idItem = value And o.CodigoCosto = codigo).SingleOrDefault
            Dim listaEquivalencias = p.CustomProducto.detalleitem_equivalencias.ToList

            e.Style.DataSource = GetEquivalencias(listaEquivalencias)
            e.Style.DisplayMember = "unidadComercial"
            e.Style.ValueMember = "equivalencia_id"
        End If
    End Sub





#End Region


End Class