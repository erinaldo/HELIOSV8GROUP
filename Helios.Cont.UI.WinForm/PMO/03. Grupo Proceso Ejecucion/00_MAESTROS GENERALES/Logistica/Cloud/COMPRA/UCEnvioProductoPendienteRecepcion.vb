Imports Helios.General
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Cont.Business.Entity
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Public Class UCEnvioProductoPendienteRecepcion

#Region "Attributes"
    Private Property compraSA As New DocumentoCompraDetalleSA
    Private Property almacenSA As New almacenSA
    Public Property ListaAlmacen As List(Of almacen)
    Public listaProductos As List(Of inventarioTransito)
    Private UCEntrega As UCEntregaDeMercaderiaLogistica
    Private UCLogisticaAlmacen As UCLogisticaAlmacen
#End Region

#Region "Constructors"
    Public Sub New(UCEntregaDeMercaderiaLogistica As UCEntregaDeMercaderiaLogistica)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UCEntrega = UCEntregaDeMercaderiaLogistica
        FormatoGridAvanzado(GridCompra, False, False, 9.0F)

    End Sub

    Public Sub New(form As UCLogisticaAlmacen)

        ' This call is required by the designer.
        InitializeComponent()
        UCLogisticaAlmacen = form
        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(GridCompra, False, False, 9.0F)
    End Sub
#End Region

#Region "Methods"
    Public Sub GetLoadAlmacenes()
        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("name")

        dt.Rows.Add("2", "EN CURSO")
        dt.Rows.Add("3", "ENTREGADO")

        Dim ggcStyleStatus As GridTableCellStyleInfo = GridCompra.TableDescriptor.Columns("status").Appearance.AnyRecordFieldCell
        ggcStyleStatus.CellType = "ComboBox"
        ggcStyleStatus.DataSource = dt
        ggcStyleStatus.ValueMember = "id"
        ggcStyleStatus.DisplayMember = "name"
        ggcStyleStatus.DropDownStyle = GridDropDownStyle.Exclusive


        ListaAlmacen = almacenSA.GetListar_almacenes(GEstableciento.IdEstablecimiento)

        Dim ggcStyle As GridTableCellStyleInfo = GridCompra.TableDescriptor.Columns("almacen").Appearance.AnyRecordFieldCell
        ggcStyle.CellType = "ComboBox"
        ggcStyle.DataSource = ListaAlmacen
        ggcStyle.ValueMember = "idAlmacen"
        ggcStyle.DisplayMember = "descripcionAlmacen"
        ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive
        GridCompra.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
    End Sub

    Public Sub GetProductosEntransito()
        listaProductos = compraSA.GetProductosEntransitoEquivalencia(New documentocompra With {
                                                                         .idCentroCosto = GEstableciento.IdEstablecimiento,
                                                                         .StatusEntregaProductosTransito = "2"
                                                                         })

    End Sub

    Sub LoadProductosTransito()
        Dim dt As New DataTable
        dt.Columns.Add("codigo")
        dt.Columns.Add("gravado")
        dt.Columns.Add("idProducto")
        dt.Columns.Add("item")
        dt.Columns.Add("um")
        dt.Columns.Add("contenido")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("tipoExistencia")
        dt.Columns.Add("almacen")
        dt.Columns.Add("tipodoc")
        dt.Columns.Add("nrodoc")
        dt.Columns.Add("proveedor")
        dt.Columns.Add("status")
        dt.Columns.Add("sel", GetType(Boolean))

        For Each i In listaProductos
            dt.Rows.Add(
                i.idInventario,
                i.CustomProducto.origenProducto,
                i.CustomProducto.codigodetalle,
                i.CustomProducto.descripcionItem,
                i.CustomDetalleCompra.unidad1,
                i.CustomDetalleCompra.unidad2,
                i.cantidad,
                i.CustomDetalleCompra.tipoExistencia,
                i.almacen,
                i.CustomDetalleCompra.documentocompra.tipoDoc,
                $"{i.CustomDetalleCompra.documentocompra.serie}-{i.CustomDetalleCompra.documentocompra.numeroDoc}",
                i.CustomDetalleCompra.documentocompra.entidad.nombreCompleto, "3", False)
        Next

        GridCompra.DataSource = dt
    End Sub

    Private Sub GrabarGuiaRemisionRecepcionada(doc As documento)
        Dim guiaSA As New DocumentoGuiaSA
        guiaSA.RecepcionInventario(doc)
        LimpiarEnviados()
        UCLogisticaAlmacen.ThreadTransito()
        'UCEntrega.formLogistica.ThreadTransito()
    End Sub

    Private Sub LimpiarEnviados()
        For Each i In GridCompra.Table.Records
            If i.GetValue("status") = True Then
                i.Delete()
            End If
        Next
    End Sub
#End Region

#Region "Events"
    Private Sub BunifuThinButton21_Click(sender As Object, e As EventArgs) Handles BunifuThinButton21.Click
        Try
            If GridCompra.Table.Records.Count > 0 Then
                If ValidarSeleccionados() = True Then
                    ConfirmarEntregas()
                Else
                    MessageBox.Show("Debe seleccionar una fila al menos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function ValidarSeleccionados() As Boolean
        ValidarSeleccionados = False
        For Each i In GridCompra.Table.Records
            If i.GetValue("status") = True Then
                ValidarSeleccionados = True
                Exit For
            End If
        Next
    End Function

    Private Sub ConfirmarEntregas()
        Dim f As New FormAsignarGuiaRemision(Me)
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        If f.Tag IsNot Nothing Then
            Dim c = CType(f.Tag, documento)
            If c.documentoGuia.documentoguiaDetalle.Count > 0 Then
                GrabarGuiaRemisionRecepcionada(c)
            Else
                MessageBox.Show("Debe seleccionar al menos un producto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub GridCompra_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridCompra.TableControlCellClick

    End Sub

    Private Sub GridCompra_TableControlCurrentCellChanged(sender As Object, e As GridTableControlEventArgs) Handles GridCompra.TableControlCurrentCellChanged
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim cc As GridCurrentCell = GridCompra.TableControl.CurrentCell
        cc.ConfirmChanges()
        If cc.Renderer IsNot Nothing Then

            If cc.ColIndex > -1 Then
                Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)

                If style.TableCellIdentity.Column.Name = "almacen" Then
                    If cc.Renderer IsNot Nothing Then

                        If e.TableControl.Model.Modified = True Then
                            Dim text As String = cc.Renderer.ControlText

                            If text.Trim.Length > 0 Then
                                If GridCompra.Table.CurrentRecord IsNot Nothing Then
                                    Dim r = GridCompra.Table.CurrentRecord
                                    Dim item = listaProductos.Where(Function(o) o.idInventario = r.GetValue("codigo")).SingleOrDefault

                                    item.almacen = Integer.Parse(r.GetValue("almacen"))
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub

#End Region

End Class
