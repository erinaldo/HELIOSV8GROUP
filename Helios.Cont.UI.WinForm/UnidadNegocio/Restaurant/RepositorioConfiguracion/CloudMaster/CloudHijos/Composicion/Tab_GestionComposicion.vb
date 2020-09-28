Imports System.IO
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class Tab_GestionComposicion

#Region "Attributes"
    Public listaProductos As List(Of detalleitems)
    Public listaComposicion As List(Of composicion)
#End Region

#Region "Constructors"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        FormatoGridAvanzado(dgvPedidoDetalle, False, False)

        FormatoGrid(dgvPedidoDetalle)
    End Sub

    Private Sub DgvPedidoDetalle_TableControlDrawCell(sender As Object, e As GridTableControlDrawCellEventArgs)
        If e.Inner.Style.CellType = "PushButton" Then
            e.Inner.Cancel = True

            ' //Draw the Image in a cell.
            If e.Inner.ColIndex = 5 Then
                e.Inner.Style.Description = "Administrar"
                e.Inner.Style.TextColor = Color.Black

                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)
                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3),
                                           New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6)
                              )
                'e.Inner.Graphics.DrawImage(Me.ImageList1.Images(0), irect)

            End If
        End If
    End Sub

    Private Sub DgvPedidoDetalle_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs)
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.Inner.ColIndex = 3 Then

            ElseIf e.Inner.ColIndex = 5 Then

                Dim style = e.TableControl.GetTableViewStyleInfo(e.Inner.RowIndex, e.Inner.ColIndex)
                Dim Record = style.TableCellIdentity.DisplayElement.GetRecord()
                If Record IsNot Nothing Then
                    Dim form As New frmComposicion(Record.GetValue("codigoDetalle"))
                    form.EstadoManipulacion = ENTITY_ACTIONS.INSERT
                    form.lblNombreComposicion.Text = "COMPOSICION - " & Record.GetValue("descripcion")
                    form.lblNombreComposicion.Tag = Record.GetValue("codigoDetalle")
                    'form.TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                    'form.TXTcOMPRADOR.ReadOnly = True
                    form.GetListaProductosTerminados("TODO")
                    form.StartPosition = FormStartPosition.CenterParent
                    form.ShowDialog(Me)

                    'GetDocumentoVentaID()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub
#End Region

#Region "Metodos"

    Public Sub relacionGrid()
        Try

            Dim listaSA As New detalleitemsSA
            listaProductos = listaSA.GetExistenciasXTipoExistencia(New detalleitems With {
                                                                    .tipoExistencia = TipoExistencia.ProductoTerminado,
                                                                    .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                    .idEstablecimiento = GEstableciento.IdEstablecimiento
                                                                    })

            Dim compsicionSA As New composicionSA

            listaComposicion = compsicionSA.GetUbicarComposicion(New composicion With
                                                                 {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                                 .idEstablecimiento = GEstableciento.IdEstablecimiento}).ToList


            Dim parentTable As DataTable = GetProductos()
            Dim ChildTable As DataTable = GetProductosDetalleComposicion()



            dgvPedidoDetalle.GridVisualStyles = GridVisualStyles.Metro
            dgvPedidoDetalle.GridOfficeScrollBars = OfficeScrollBars.Metro

            Dim parentToChildRelationDescriptor = New GridRelationDescriptor
            dgvPedidoDetalle.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = False
            dgvPedidoDetalle.TopLevelGroupOptions.ShowCaption = False

            'dgvPedidoDetalle.GetTable("MyChildTable").DefaultRecordRowHeight = 35

            parentToChildRelationDescriptor.ChildTableName = "Composicion"
            parentToChildRelationDescriptor.RelationKind = RelationKind.RelatedMasterDetails
            parentToChildRelationDescriptor.RelationKeys.Add("CodigoDetalle", "CodigoDetalle")

            dgvPedidoDetalle.TableDescriptor.Relations.Add(parentToChildRelationDescriptor)

            dgvPedidoDetalle.Engine.SourceListSet.Add("Producto", parentTable)
            dgvPedidoDetalle.Engine.SourceListSet.Add("Composicion", ChildTable)

            dgvPedidoDetalle.DataSource = parentTable

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Public Function GetProductos() As DataTable
        Try

            Dim dt = New DataTable("Producto")
            Dim conteo As Integer = 0
            Dim EstadoComposicion As Boolean

            dgvPedidoDetalle.Table.Records.DeleteAll()

            'Dim dt As New DataTable
            dt.Columns.Add("CodigoDetalle")
            dt.Columns.Add("descripcion")
            dt.Columns.Add("estado")
            dt.Columns.Add("composicion")
            dt.Columns.Add("agregar")

            For Each i In listaProductos

                If (listaComposicion.Where(Function(o) o.idProducto = i.codigodetalle).Count > 0) Then
                    EstadoComposicion = True
                Else
                    EstadoComposicion = False
                End If

                dt.Rows.Add(
                   i.codigodetalle,
                      i.descripcionItem,
                   "HABILITADO",
                    EstadoComposicion,
                    Nothing
                   )
                conteo = conteo + 1
            Next

            Return dt
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Function

    Public Function GetProductosDetalleComposicion() As DataTable
        Try

            Dim dt = New DataTable("Composicion")
            Dim conteo As Integer = 0

            dt.Columns.Add("ID")
            dt.Columns.Add("Nombre Composición")
            dt.Columns.Add("Unidad de Medida")
            dt.Columns.Add("Consumo")
            dt.Columns.Add("Precio")
            dt.Columns.Add("CodigoDetalle")

            For Each i In listaComposicion

                dt.Rows.Add(
                  i.idComposicion,
                  i.descripcionComposicion,
                 i.unidadMedida,
                  i.cantidad,
                  i.importeMN,
                  i.idProducto
                  )

            Next

            Return dt
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Function

    Public Sub GetProductosAll()
        Try

            Dim dt = New DataTable("ParentTable")
            Dim conteo As Integer = 0
            Dim listaSA As New detalleitemsSA
            Dim EstadoComposicion As Boolean
            Dim compsicionSA As New composicionSA

            listaProductos = listaSA.GetExistenciasXTipoExistencia(New detalleitems With {
                                                                    .tipoExistencia = TipoExistencia.ProductoTerminado,
                                                                    .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                    .idEstablecimiento = GEstableciento.IdEstablecimiento
                                                                    })

            listaComposicion = compsicionSA.GetUbicarComposicion(New composicion With
                                                                 {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                                 .idEstablecimiento = GEstableciento.IdEstablecimiento}).ToList

            'Dim dt As New DataTable
            dt.Columns.Add("CodigoDetalle")
            dt.Columns.Add("descripcion")
            dt.Columns.Add("estado")
            dt.Columns.Add("composicion")
            dt.Columns.Add("agregar")

            dgvPedidoDetalle.Table.Records.DeleteAll()

            For Each i In listaProductos

                If (listaComposicion.Where(Function(o) o.idProducto = i.codigodetalle).Count > 0) Then
                    EstadoComposicion = True
                Else
                    EstadoComposicion = False
                End If

                dt.Rows.Add(
                   i.codigodetalle,
                      i.descripcionItem,
                   "HABILITADO",
                    EstadoComposicion,
                    Nothing
                   )

                conteo = conteo + 1
            Next

            dgvPedidoDetalle.DataSource = dt

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub GetProductosfILTRO(textoFilter As String)
        'Dim lista = itemSA.GetExistenciasByEstablecimiento(GEstableciento.IdEstablecimiento).Where(Function(o) o.descripcionItem.Contains(textoFilter)).ToList '.Where(Function(o) o.estado = "A").ToList
        Dim itemSA As New detalleitemsSA
        Dim NuevaDescripcion As String = String.Empty
        Dim delimitadores() As String = {" "}
        Dim vectoraux() As String
        vectoraux = textoFilter.Split(delimitadores, StringSplitOptions.None)

        'mostrar resultado
        For Each item As String In vectoraux
            NuevaDescripcion += item & "%"
        Next
        Dim lista = itemSA.GetArticulosSytem(Gempresas.IdEmpresaRuc, NuevaDescripcion).ToList '.Where(Function(o) o.estado = "A").ToList

        Dim dt As New DataTable
        dt.Columns.Add("ID")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("estado")
        dt.Columns.Add("composicion")
        dt.Columns.Add("agregar")

        dgvPedidoDetalle.Table.Records.DeleteAll()

        For Each i In listaProductos

            dt.Rows.Add(
                    i.codigodetalle,
                    i.item.descripcion,
                    i.descripcionItem,
                    "HABILITADO",
                     False,
                     Nothing
                    )
        Next
        dgvPedidoDetalle.DataSource = dt
    End Sub

    Public Sub GetDocumentoVentaID()
        Dim dt As New DataTable
        Dim itemSA As New itemSA
        Dim itemBE As New item
        Dim listaCategoria As New List(Of item)

        itemBE.idEmpresa = Gempresas.IdEmpresaRuc
        itemBE.idEstablecimiento = GEstableciento.IdEstablecimiento
        itemBE.tipo = "C"

        listaCategoria = itemSA.GetListaItemsPorTipo(itemBE)

        dgvPedidoDetalle.Table.Records.DeleteAll()

        With dt.Columns
            .Add("ID")
            .Add("descripcion")
            .Add("estado")
            .Add("eliminar")
            .Add("actualizar")
            .Add("inhabilitar")
        End With

        For Each i In listaCategoria

            dt.Rows.Add(i.idItem,
                    i.descripcion,
                    "HABILITADO",
                    "", "",
                    False)

        Next
        dgvPedidoDetalle.DataSource = dt

    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs)
        Dim f As New frmNuevaClasificacion
        'f.MANIPULACION = ENTITY_ACTIONS.INSERT
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        GetDocumentoVentaID()
    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click
        GetProductosAll()
    End Sub

    Private Sub TextBuscarProduct_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBuscarProduct.KeyDown
        Cursor = Cursors.WaitCursor
        Try
            If e.KeyCode = Keys.Enter Then
                If TextBuscarProduct.Text.Trim.Length > 2 Then
                    e.SuppressKeyPress = True
                    GetProductosfILTRO(TextBuscarProduct.Text.Trim)
                Else
                    TextBuscarProduct.Select()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Cursor = Cursors.Default
    End Sub

    Private Sub BunifuFlatButton1_Click_1(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        relacionGrid()
    End Sub

    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton3.Click
        Try

            If (Not IsNothing(dgvPedidoDetalle.Table.CurrentRecord)) Then
                'Dim form As New frmComposicion(dgvPedidoDetalle.Table.CurrentRecord("IDpadre"))
                'form.EstadoManipulacion = ENTITY_ACTIONS.INSERT
                'form.lblNombreComposicion.Text = "COMPOSICION - " & dgvPedidoDetalle.Table.CurrentRecord("descripcion")
                'form.lblNombreComposicion.Tag = dgvPedidoDetalle.Table.CurrentRecord("IDpadre")

                'form.GetListaProductosTerminados("TODO")
                'form.StartPosition = FormStartPosition.CenterParent
                'form.ShowDialog(Me)

                Dim form As New frmComposicionSingle(dgvPedidoDetalle.Table.CurrentRecord("CodigoDetalle"))
                form.EstadoManipulacion = ENTITY_ACTIONS.INSERT
                form.Label1.Text = "COMPOSICION - " & dgvPedidoDetalle.Table.CurrentRecord("descripcion")
                form.Label1.Tag = dgvPedidoDetalle.Table.CurrentRecord("CodigoDetalle")

                form.GetListaProductosTerminados("TODO")
                form.StartPosition = FormStartPosition.CenterParent
                form.ShowDialog(Me)
            Else
                MessageBox.Show("DEBE SELECCIONAR UN PRODCUTO TERMENIDO")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

#End Region

#Region "Events"


#End Region

End Class
