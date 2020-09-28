Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Helios.Seguridad.Business.Entity
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class frmNuevoProductoDetalle

#Region "Attributes"
    Public Property autorizaSA As New AsegurableSA
    Public Property autorizaProductoSA As New ProductoSA
    Public Property rolSA As New RolSA
    Public Property frmModulos As frmModalSistemas
    Dim tipo As String
    Dim asegurableBE As New Asegurable
    Public Property ListadoAsegurableGenerico As New List(Of Asegurable)
    Public dt As New DataTable()

    Public nodePadre = New TreeNode
    Dim productoDetalle As New Seguridad.Business.Entity.ProductoDetalle
    Dim listaproducto As New List(Of Seguridad.Business.Entity.ProductoDetalle)
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'FormatoGridPequeño(dgPerfilAutoriza, False)
        'GetPefiles()
        txtFecha.Text = Date.Now
        GetListaAsegurables()

    End Sub
#End Region

#Region "Methods"


    Public Sub GetListaAsegurables()

        dt.Columns.Add("IDAsegurable", GetType(Integer))
        dt.Columns.Add("IDAsegurablePadre", GetType(Integer))
        dt.Columns.Add("Nombre", GetType(String))
        dt.Columns.Add("modulo", GetType(String))
        dt.Columns.Add("autorizado", GetType(Boolean))

        asegurableBE = New Asegurable
        'asegurableBE.IDCliente = "GENERICO"
        asegurableBE.IDEmpresa = Gempresas.IdEmpresaRuc
        asegurableBE.IDEstablecimiento = GEstableciento.IdEstablecimiento
        ListadoAsegurableGenerico = New List(Of Asegurable)
        ListadoAsegurableGenerico = autorizaSA.GetListaAsegurablesPadre(asegurableBE)

        CrearNodosDelPadre()

    End Sub


    Private Sub CrearNodosDelPadre()

        Dim contqao As Integer = 0
        Dim contarHijos As Integer = 0

        tvListaModulos.Nodes.Clear()

        Dim consultaPadre = (From a In ListadoAsegurableGenerico Where a.IDEmpresa = Gempresas.IdEmpresaRuc
                             Order By a.IDAsegurable Ascending Select a).ToList

        For Each PADRE In consultaPadre
            nodePadre = New TreeNode

            'Descripción o texto del nodo
            nodePadre.Text = PADRE.Nombre

            'Si necesito guardar el valor del IdentificadorNodo dentro del mismo nodo
            nodePadre.Name = PADRE.IDAsegurable

            'Si necesito guardar el valor del IdentificadorPadre dentro del mismo nodo
            nodePadre.Tag = PADRE.IDAsegurable
            tvListaModulos.Nodes.Add(nodePadre)

            Dim consulta = (From a In ListadoAsegurableGenerico Where a.IDAsegurablePadre = nodePadre.Tag
                            Order By a.IDAsegurable Ascending Select a).ToList

            If ((consulta.Count) > 0) Then
                For Each hijos In consulta

                    Dim nodeHIJO = New TreeNode

                    'Descripción o texto del nodo
                    nodeHIJO.Text = hijos.Nombre

                    'Si necesito guardar el valor del IdentificadorNodo dentro del mismo nodo
                    nodeHIJO.Name = hijos.IDAsegurable

                    'Si necesito guardar el valor del IdentificadorPadre dentro del mismo nodo
                    nodeHIJO.Tag = hijos.IDAsegurable
                    tvListaModulos.Nodes(contqao).Nodes.Add(nodeHIJO)

                    Dim consultANietos = (From a In ListadoAsegurableGenerico Where a.IDAsegurablePadre = nodeHIJO.Tag
                                          Order By a.IDAsegurable Ascending Select a).ToList

                    For Each NIETOS In consultANietos
                        Dim nodeNieto = New TreeNode

                        'Descripción o texto del nodo
                        nodeNieto.Text = NIETOS.Nombre

                        'Si necesito guardar el valor del IdentificadorNodo dentro del mismo nodo
                        nodeNieto.Name = NIETOS.IDAsegurable

                        'Si necesito guardar el valor del IdentificadorPadre dentro del mismo nodo
                        nodeNieto.Tag = NIETOS.IDAsegurable
                        tvListaModulos.Nodes(contqao).Nodes(contarHijos).Nodes.Add(nodeNieto)
                    Next
                    contarHijos += 1
                Next

            End If
            contqao += 1
        Next
        tvListaModulos.EndUpdate()
    End Sub

    Dim conteo As Integer = 0

    Public Sub GetGrabarModulos()
        Dim producto As New Seguridad.Business.Entity.Producto

        Try
            producto = New Seguridad.Business.Entity.Producto
            With producto
                .nombre = txtTipo.Text
                .descripcion = txtDescripcion.Text
                .UsuarioActualizacion = "SISTEMA"
                .FechaActualizacion = Date.Now
            End With

            'Se Declara una colección de nodos apartir de tu Treeview
            'del que se va a recorrer
            Dim nodes As TreeNodeCollection = tvListaModulos.Nodes
            'Se recorren los nodos principales
            For Each n As TreeNode In nodes
                If n.Checked = True Then
                    'Si esta marcado mostramos el texto del nodo
                    productoDetalle = New ProductoDetalle
                    With productoDetalle
                        .IDAsegurable = n.Name
                        .estadoProducto = True
                        .UsuarioActualizacion = "SISTEMA"
                        .FechaActualizacion = Date.Now
                        conteo += 1
                    End With
                    listaproducto.Add(productoDetalle)
                End If
                'Se Declara un metodo para que recorra los hijos de los principales
                'Y los hijos de los hijos....Recorrido Total en pocas palabras
                'Para ello se envía el nodo actual para evaluar si tiene hijos
                'For Each tn As TreeNode In n.Nodes
                ''Se Verifica si esta marcado...
                'If tn.Checked = True Then
                '    'Si esta marcado mostramos el texto del nodo
                '    With productoDetalle
                '        .IDAsegurable = n.Name
                '        .estadoProducto = True
                '        .UsuarioActualizacion = "SISTEMA"
                '        .FechaActualizacion = Date.Now
                '    End With
                '    listaproducto.Add(productoDetalle)
                'End If
                ''Ahora hago verificacion a los hijos del nodo actual            
                ''Esta iteración no acabara hasta llegar al ultimo nodo principal
                RecorrerNodos(n)
                'Next
            Next


            'For Each item In tvListaModulos.Nodes
            '    If (item.Checked = True) Then
            '        With productoDetalle
            '            .IDAsegurable = item.nodes.text.ToString
            '            .estadoProducto = item.nodes.name
            '            .UsuarioActualizacion = "SISTEMA"
            '            .FechaActualizacion = Date.Now
            '        End With
            '    End If
            '    listaproducto.Add(productoDetalle)
            'Next

            producto.ProductoDetalle = listaproducto

            autorizaProductoSA.insertAsegurableProducto(producto)
            MessageBox.Show("Porducto grabado correctamente!", "!Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Dispose()
        Catch ex As Exception
            MsgBox("Error al grabar producto. " & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del Sistema!")

        End Try

    End Sub

    Private Sub RecorrerNodos(treeNode As TreeNode)
        Try
            'Si el nodo que recibimos tiene hijos se recorrerá
            'para luego verificar si esta o no checado
            For Each tn As TreeNode In treeNode.Nodes
                'Se Verifica si esta marcado...
                If tn.Checked = True Then
                    'Si esta marcado mostramos el texto del nodo
                    productoDetalle = New ProductoDetalle
                    With productoDetalle
                        .IDAsegurable = tn.Name
                        .estadoProducto = True
                        .UsuarioActualizacion = "SISTEMA"
                        .FechaActualizacion = Date.Now

                    End With
                    listaproducto.Add(productoDetalle)
                End If
                'Ahora hago verificacion a los hijos del nodo actual            
                'Esta iteración no acabara hasta llegar al ultimo nodo principal
                RecorrerNodos(tn)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

#End Region

#Region "Events"
    'Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs)
    '    Cursor = Cursors.WaitCursor
    '    listaModulos(cboPErfil.SelectedItem)
    '    Cursor = Cursors.Default
    'End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs)
        frmModulos = New frmModalSistemas
        frmModulos.StartPosition = FormStartPosition.CenterParent
        frmModulos.ShowDialog()
        If Not IsNothing(frmModulos.Tag) Then
            Dim c = CType(frmModulos.Tag, Producto)
            'agregar fila al GGC
            'dgPerfilAutoriza.Table.AddNewRecord.SetCurrent()
            'dgPerfilAutoriza.Table.AddNewRecord.BeginEdit()
            'dgPerfilAutoriza.Table.CurrentRecord.SetValue("IDAsegurable", c.IDAsegurable)
            'dgPerfilAutoriza.Table.CurrentRecord.SetValue("Nombre", c.Nomasegurable)
            'dgPerfilAutoriza.Table.CurrentRecord.SetValue("autorizado", c.EstaAutorizado)
            'dgPerfilAutoriza.Table.AddNewRecord.EndEdit()
            'c.Action = BaseBE.EntityAction.INSERT
            'c.id = cboPErfil.SelectedValue
            'c.UsuarioActualizacion = usuario.IDUsuario
            'c.FechaActualizacion = Date.Now
            'autorizaSA.InsertItem(c)
            'GetAutorizacionesByRol()
        End If
    End Sub

#End Region


    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        GetGrabarModulos()
    End Sub

    Private Sub CheckAllChildNodes(treeNode As TreeNode, nodeChecked As Boolean)
        Dim node As TreeNode
        For Each node In treeNode.Nodes
            node.Checked = nodeChecked
            If node.Nodes.Count > 0 Then
                ' If the current node has child nodes, call the CheckAllChildsNodes method recursively.
                CheckAllChildNodes(node, nodeChecked)
            End If
        Next node
    End Sub

    Private Sub tvListaModulos_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles tvListaModulos.AfterCheck

        ' The code only executes if the user caused the checked state to change.
        If e.Action <> TreeViewAction.Unknown Then
            If e.Node.Nodes.Count > 0 Then
                ' Calls the CheckAllChildNodes method, passing in the current 
                ' Checked value of the TreeNode whose checked state changed. 
                Me.CheckAllChildNodes(e.Node, e.Node.Checked)
            End If
        End If

    End Sub



End Class