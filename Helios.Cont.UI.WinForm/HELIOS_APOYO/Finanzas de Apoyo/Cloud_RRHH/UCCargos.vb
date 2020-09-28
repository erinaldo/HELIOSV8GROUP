Imports System.Threading
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.Business.Entity
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class UCCargos


#Region "Fields"
    Dim filter As New GridExcelFilter()
    Private Thread As Thread
    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)


#End Region

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        'If (Not IsNothing(Gempresas)) Then

        '    'FormatoGridAvanzado(dgPerfilesUsuario, True, False)
        '    Dim empresa As String = Gempresas.IdEmpresaRuc
        '    'ProgressBar1.Visible = True
        '    'ProgressBar1.Style = ProgressBarStyle.Marquee
        'End If



    End Sub

#Region "Metodos"


    Private Sub CrearNodosDelPadre()
        Try
            Dim nodePadre As TreeNode
            Dim rolbe As New Rol
            Dim contqao As Integer = 0
            Dim contarHijos As Integer = 0
            Dim nietsosA As Integer = 0
            Dim nietoB As Integer = 0
            Dim contarEncabezado As Integer = 0


            'rolbe.IDEmpresa = Gempresas.IdEmpresaRuc
            'rolbe.IDEstablecimiento = GEstableciento.IdEstablecimiento

            'rolbe.idEmpresa = Gempresas.IdEmpresaRuc
            'rolbe.idEstablecimiento = GEstableciento.IdEstablecimiento

            Dim sa As New RolSA
            Dim lista = sa.RoleListSingle(rolbe)


            TreeView1.Nodes.Clear()

            Dim nodeEncabezado = New TreeNode

            'Descripción o texto del nodo
            nodeEncabezado.Text = "JERARQUIA DE CARGOS"
            nodeEncabezado.ForeColor = Color.Red
            'Si necesito guardar el valor del IdentificadorNodo dentro del mismo nodo
            nodeEncabezado.Name = 0

            'Si necesito guardar el valor del IdentificadorPadre dentro del mismo nodo
            nodeEncabezado.Tag = 0
            TreeView1.Nodes.Add(nodeEncabezado)

            Dim consultaPadre = (From a In lista Where a.idPadre Is Nothing
                                 Order By a.IDRol Ascending Select a).ToList

            'Dim consultaPadre = (From a In listaOr Where a.idPadre = 0 And a.idCentroCosto = cbunidadnegocioOrg.SelectedValue
            '                     Order By a.idOrganigrama Ascending Select a).ToList

            For Each PADRE In consultaPadre
                nodePadre = New TreeNode

                'Descripción o texto del nodo
                nodePadre.Text = PADRE.Descripcion

                'Si necesito guardar el valor del IdentificadorNodo dentro del mismo nodo
                nodePadre.Name = PADRE.IDRol

                'Si necesito guardar el valor del IdentificadorPadre dentro del mismo nodo
                nodePadre.Tag = PADRE.IDRol
                TreeView1.Nodes(contarEncabezado).Nodes.Add(nodePadre)

                Dim consulta = (From a In lista Where a.idPadre = nodePadre.Tag
                                Order By a.IDRol Ascending Select a).ToList

                If ((consulta.Count) > 0) Then
                    For Each hijos In consulta

                        Dim nodeHIJO = New TreeNode

                        'Descripción o texto del nodo
                        nodeHIJO.Text = hijos.Descripcion
                        nodeHIJO.ForeColor = Color.FromArgb(32, 182, 82)
                        'Si necesito guardar el valor del IdentificadorNodo dentro del mismo nodo
                        nodeHIJO.Name = hijos.IDRol

                        'Si necesito guardar el valor del IdentificadorPadre dentro del mismo nodo
                        nodeHIJO.Tag = hijos.IDRol
                        TreeView1.Nodes(contarEncabezado).Nodes(contqao).Nodes.Add(nodeHIJO)

                        Dim consultANietos = (From a In lista Where a.idPadre = nodeHIJO.Tag
                                              Order By a.IDRol Ascending Select a).ToList

                        For Each NIETOS In consultANietos
                            Dim nodeNieto = New TreeNode

                            'Descripción o texto del nodo
                            nodeNieto.Text = NIETOS.Descripcion

                            'Si necesito guardar el valor del IdentificadorNodo dentro del mismo nodo
                            nodeNieto.Name = NIETOS.IDRol

                            'Si necesito guardar el valor del IdentificadorPadre dentro del mismo nodo
                            nodeNieto.Tag = NIETOS.IDRol
                            TreeView1.Nodes(contarEncabezado).Nodes(contqao).Nodes(contarHijos).Nodes.Add(nodeNieto)


                            Dim consultanietosA = (From m In lista Where m.idPadre = nodeNieto.Tag
                                                   Order By m.IDRol Ascending Select m).ToList

                            For Each nietosA In consultanietosA

                                Dim nodeNietosA = New TreeNode

                                nodeNietosA.Text = nietosA.Descripcion
                                nodeNietosA.ForeColor = Color.FromArgb(7, 117, 129)
                                nodeNietosA.Name = nietosA.IDRol

                                nodeNietosA.Tag = nietosA.IDRol
                                TreeView1.Nodes(contarEncabezado).Nodes(contqao).Nodes(contarHijos).Nodes(nietsosA).Nodes.Add(nodeNietosA)

                                Dim consultaNietoB = (From p In lista Where p.idPadre = nodeNietosA.Tag
                                                      Order By p.IDRol Ascending Select p).ToList

                                For Each nietosB In consultaNietoB
                                    Dim nodoNietoB = New TreeNode

                                    nodoNietoB.Text = nietosB.Descripcion

                                    nodoNietoB.Name = nietosB.IDRol

                                    nodoNietoB.Tag = nietosB.IDRol

                                    TreeView1.Nodes(contarEncabezado).Nodes(contqao).Nodes(contarHijos).Nodes(nietsosA).Nodes(nietoB).Nodes.Add(nodoNietoB)
                                Next
                                nietoB += 1

                            Next
                            nietoB = 0
                            If (consulta.Count > 1) Then
                                nietsosA += 1
                            Else
                                nietsosA = 0
                            End If
                        Next
                        nietsosA = 0
                        If (consulta.Count > 1) Then
                            contarHijos += 1
                        Else
                            contarHijos = 0
                        End If
                    Next
                    contarHijos = 0
                End If
                'contarHijos += 1
                contqao += 1
            Next
            TreeView1.EndUpdate()
            TreeView1.ExpandAll()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub


#End Region

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs)
        If TreeView1.SelectedNode IsNot Nothing Then
            Dim nodo = TreeView1.SelectedNode.Name

            Dim f As New frmNuevoCargo(nodo)
            'f.strEstadoManipulacion = ENTITY_ACTIONS.UPDATE
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            CrearNodosDelPadre()
        End If
    End Sub

    Private Sub btnArea_Click(sender As Object, e As EventArgs)
        If TreeView1.SelectedNode IsNot Nothing Then
            Dim nodo = TreeView1.SelectedNode.Name

            Dim f As New frmNuevoAreaOperativa(nodo)
            f.txtDescripcion.Text = TreeView1.SelectedNode.Text
            f.txtDescripcion.Tag = nodo
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            'CrearNodosDelPadre()
        End If
    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        Try
            Dim organizacionSA As New OrganizacionSA
            Dim listaUnidadOrg As New List(Of organizacion)

            listaUnidadOrg = organizacionSA.GetObtenerOrganigramaXPerfil(New organizacion With {.tipo = TreeView1.SelectedNode.Name})

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click
        CrearNodosDelPadre()
    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
        Cursor = Cursors.WaitCursor
        'If Not IsNothing(Me.dgPerfilesUsuario.Table.CurrentRecord) Then
        Dim f As New frmNuevoCargoGeneral()
        'f.strEstadoManipulacion = ENTITY_ACTIONS.UPDATE
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()

        CrearNodosDelPadre()

        'End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton3.Click
        'ACTUALIZAR
        If TreeView1.SelectedNode IsNot Nothing Then
            Dim nodo = TreeView1.SelectedNode.Name


            Dim f As New frmNuevoCargo(nodo)
            'f.strEstadoManipulacion = ENTITY_ACTIONS.UPDATE
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()

            CrearNodosDelPadre()

        End If
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs)

    End Sub
End Class
