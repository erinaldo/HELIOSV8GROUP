Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.Business.Entity
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class frmNuevoAsegurable

#Region "Attributes"
    Public Property autorizaSA As New AsegurableSA
    Public Property AutorizacionRolSA As New AutorizacionRolSA
    Public Property rolSA As New RolSA
    Public Property frmModulos As frmModalSistemas
    Dim tipo As String
    Public Property IdRol As Integer
    Public Property ListadoAsegurableGenerico As New List(Of Asegurable)
    Public dt As New DataTable()
    Public ClientesSoftPackSA As New ClientesSoftPackSA
    Public nodePadre = New TreeNode
    Dim idProducto As Integer
    Dim AsegurableBE As New Seguridad.Business.Entity.Asegurable
    Dim AutorizacionRolBE As New Seguridad.Business.Entity.AutorizacionRol
    Dim listaAutorizacionRol As New List(Of Seguridad.Business.Entity.AutorizacionRol)
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'FormatoGridPequeño(dgPerfilAutoriza, False)
        'GetPefiles()
        idProducto = ClientesSoftPackSA.GetProductoClientesXID(Gempresas.IDCliente).IDProducto
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
        AsegurableBE.IDEmpresa = Gempresas.IdEmpresaRuc
        ListadoAsegurableGenerico = New List(Of Asegurable)
        ListadoAsegurableGenerico = autorizaSA.GetListaAsegurablesXCliente(asegurableBE)

        CrearNodosDelPadre()

    End Sub


    Private Sub CrearNodosDelPadre()

        Dim contqao As Integer = 0
        Dim contarHijos As Integer = 0
        Dim contarNietos As Integer = 0

        tvListaModulos.Nodes.Clear()

        Dim consultaPadre = (From a In ListadoAsegurableGenerico Where a.Descripcion = "PRINCIPAL"
                             Order By a.IDAsegurable Ascending Select a).ToList

        For Each PADRE In consultaPadre
            nodePadre = New TreeNode

            'Descripción o texto del nodo
            nodePadre.Text = PADRE.Nombre

            'Si necesito guardar el valor del IdentificadorNodo dentro del mismo nodo
            nodePadre.Name = PADRE.IDAsegurable

            'Si necesito guardar el valor del IdentificadorPadre dentro del mismo nodo
            nodePadre.Tag = PADRE.Descripcion

            tvListaModulos.Nodes.Add(nodePadre)
            tvListaModulos.Nodes(contqao).Checked = True
            Dim consulta = (From a In ListadoAsegurableGenerico Where a.IDAsegurablePadre = nodePadre.Name
                            Order By a.IDAsegurable Ascending Select a).ToList

            If ((consulta.Count) > 0) Then
                For Each hijos In consulta

                    Dim nodeHIJO = New TreeNode

                    'Descripción o texto del nodo
                    nodeHIJO.Text = hijos.Nombre

                    'Si necesito guardar el valor del IdentificadorNodo dentro del mismo nodo
                    nodeHIJO.Name = hijos.IDAsegurable

                    'Si necesito guardar el valor del IdentificadorPadre dentro del mismo nodo
                    nodeHIJO.Tag = hijos.Descripcion
                    tvListaModulos.Nodes(contqao).Nodes.Add(nodeHIJO)
                    tvListaModulos.Nodes(contqao).Nodes(contarHijos).Checked = True
                    Dim consultANietos = (From a In ListadoAsegurableGenerico Where a.IDAsegurablePadre = nodeHIJO.Name
                                          Order By a.IDAsegurable Ascending Select a).ToList

                    For Each NIETOS In consultANietos
                        Dim nodeNieto = New TreeNode

                        'Descripción o texto del nodo
                        nodeNieto.Text = NIETOS.Nombre

                        'Si necesito guardar el valor del IdentificadorNodo dentro del mismo nodo
                        nodeNieto.Name = NIETOS.IDAsegurable

                        'Si necesito guardar el valor del IdentificadorPadre dentro del mismo nodo
                        nodeNieto.Tag = NIETOS.Descripcion
                        tvListaModulos.Nodes(contqao).Nodes(contarHijos).Nodes.Add(nodeNieto)

                        If (nodeNieto.Text.Length > 0) Then
                            tvListaModulos.Nodes(contqao).Nodes(contarHijos).Nodes(contarNietos).Checked = True
                        End If
                        contarNietos += 1
                    Next
                    contarHijos += 1
                    contarNietos = 0
                Next
                contarHijos = 0
            End If
            contqao += 1
        Next
        tvListaModulos.ExpandAll()
        tvListaModulos.EndUpdate()
    End Sub

    Dim conteo As Integer = 0
    Dim idPadre As Integer
    Dim idHijo As Integer
    Public Sub GetGrabarModulos()
        Dim producto As New Seguridad.Business.Entity.Producto

        Try
            'Se Declara una colección de nodos apartir de tu Treeview
            'del que se va a recorrer
            Dim nodes As TreeNodeCollection = tvListaModulos.Nodes
            'Se recorren los nodos principales
            For Each n As TreeNode In nodes
                If n.Checked = True Then
                    'Si esta marcado mostramos el texto del nodo
                    AutorizacionRolBE = New AutorizacionRol
                    With AutorizacionRolBE
                        .IDAsegurable = CInt(n.Name)
                        idPadre = n.Name
                        .IDRol = IdRol
                        .IdEmpresa = Gempresas.IdEmpresaRuc
                        .IDProducto = idProducto
                        .EstaAutorizado = True
                        .UsuarioActualizacion = "SISTEMA"
                        .FechaActualizacion = Date.Now
                        conteo += 1
                    End With
                    listaAutorizacionRol.Add(AutorizacionRolBE)
                End If
                RecorrerNodos(n, idPadre)
                'Next
            Next

            If (conteo > 0) Then
                AutorizacionRolSA.InsertProductoXPerfil(listaAutorizacionRol)
            Else
                lblEstado.Text = "No selecciono ningun detalle"
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
            End If

            MessageBox.Show("Asegurable grabado correctamente!", "!Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Dispose()
        Catch ex As Exception
            MsgBox("Error al grabar asegurable. " & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del Sistema!")

        End Try

    End Sub

    Private Sub RecorrerNodos(treeNode As TreeNode, IDPadre As Integer)
        Try
            'Si el nodo que recibimos tiene hijos se recorrerá
            'para luego verificar si esta o no checado
            For Each tn As TreeNode In treeNode.Nodes
                'Se Verifica si esta marcado...
                If tn.Checked = True Then
                    'Si esta marcado mostramos el texto del nodo
                    AutorizacionRolBE = New AutorizacionRol
                    With AutorizacionRolBE
                        With AutorizacionRolBE
                            .IDAsegurable = tn.Name
                            idHijo = tn.Name
                            .IDRol = IdRol
                            .IdEmpresa = Gempresas.IdEmpresaRuc
                            .IDProducto = idProducto
                            .EstaAutorizado = True
                            .UsuarioActualizacion = "SISTEMA"
                            .FechaActualizacion = Date.Now

                        End With
                    End With
                    listaAutorizacionRol.Add(AutorizacionRolBE)
                End If
                'Ahora hago verificacion a los hijos del nodo actual            
                'Esta iteración no acabara hasta llegar al ultimo nodo principal
                RecorrerNodos(tn, idHijo)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

#Region "TIMER"
    Sub parpadeo()
        Static parpadear As Boolean

        'If Not parpadear Then
        '    lblEstado.ForeColor = lblEstado.BackColor
        '    lblEstado.BackColor = Color.Yellow
        'Else
        '    lblEstado.ForeColor = SystemColors.WindowText
        'End If

        parpadear = Not parpadear
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If TiempoRestante > 0 Then
            parpadeo()

            'lblAgregar.Visible = True
            'lblMensaje.Visible = True
            'tsSave.Enabled = False
            'lblMensaje.Text = "Agregar otro en: " & TiempoRestante
            TiempoRestante = TiempoRestante - 1
        ElseIf TiempoRestante = 0 Then
            Timer1.Enabled = False
            'lblEstado.ForeColor = Color.Navy
            'lblEstado.BackColor = Color.Transparent
            PanelError.Visible = False
            '      Dispose()
        Else
            Timer1.Enabled = False
            'Ejecuta tu función cuando termina el tiempo
            TiempoEjecutar(10)

        End If
    End Sub
    Private TiempoRestante As Integer
    Public Sub TimerOn(ByRef Interval As Short)
        If Interval > 0 Then
            Timer1.Enabled = True
        Else
            Timer1.Enabled = False
        End If

    End Sub
    Public Function TiempoEjecutar(ByVal Tiempo As Integer)
        TiempoEjecutar = ""
        TiempoRestante = Tiempo  ' 1 minutos=60 segundos 
        Timer1.Interval = 400

        Call TimerOn(1000) ' Hechanos a andar el timer
    End Function
#End Region

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

        '' The code only executes if the user caused the checked state to change.
        'If e.Action <> TreeViewAction.Unknown Then
        '    If e.Node.Nodes.Count > 0 Then
        '        ' Calls the CheckAllChildNodes method, passing in the current 
        '        ' Checked value of the TreeNode whose checked state changed. 
        '        Me.CheckAllChildNodes(e.Node, e.Node.Checked)
        '    End If
        'End If


        RemoveHandler tvListaModulos.AfterCheck, AddressOf tvListaModulos_AfterCheck

        For Each node As TreeNode In e.Node.Nodes
            node.Checked = e.Node.Checked
        Next

        If e.Node.Checked Then
            If e.Node.Parent Is Nothing = False Then
                Dim allChecked As Boolean = True

                ''For Each node As TreeNode In e.Node.Parent.Nodes
                ''    If Not node.Checked Then
                ''        allChecked = False
                ''    End If
                ''Next

                ''If allChecked Then
                e.Node.Parent.Checked = True
                ''End If
            End If
            ' Calls the CheckAllChildNodes method, passing in the current 
            ' Checked value of the TreeNode whose checked state changed. 
            Me.CheckAllChildNodes(e.Node, True)

        Else

            Me.CheckAllChildNodes(e.Node, False)
            If e.Node.Parent Is Nothing = False Then
                e.Node.Parent.Checked = False
            End If
        End If

        AddHandler tvListaModulos.AfterCheck, AddressOf tvListaModulos_AfterCheck

    End Sub

    Private Sub ButtonAdv2_Click_1(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        GetGrabarModulos()
    End Sub
End Class