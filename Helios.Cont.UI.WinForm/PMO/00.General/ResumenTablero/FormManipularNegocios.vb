Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports System.IO
Imports Microsoft.VisualBasic.FileIO
Imports System.Net
Public Class FormManipularNegocios

    Dim listaCentrocosto As New List(Of centrocosto)
    Dim centrocostoBE As New centrocosto
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        CrearNodosDelPadre()

        'ListarAsegurableRol()
    End Sub

    Private Sub ButtonAdv15_Click(sender As Object, e As EventArgs) Handles ButtonAdv15.Click
        Dispose()
    End Sub

#Region "Metodos"
    Sub ListarAsegurableRol(idUnidadNeogcio As Integer)
        Try

            Dim SA As New negocioComercialSA
            Dim ListaObjeto As New List(Of negocioComercial)
            Dim NegocioCentoCostosSA As New centroCostosXNComercialSA
            Dim listaCentroCostosXNComercial As New List(Of centroCostosXNComercial)
            Dim listaIDNegocio As New List(Of Integer)

            listaCentroCostosXNComercial = NegocioCentoCostosSA.GetListacentroCostosXNComercial(New centroCostosXNComercial With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = idUnidadNeogcio})

            ListaObjeto = SA.GetListaNegocioComercial().ToList


            'Dim ListaConPermiso = (From i In ListaObjeto Where ).ToList
            'Dim listaPermisos = (From i In listaCentroCostosXNComercial Where Not i.IDRol > 0).ToList

            GridGroupingControl1.Table.Records.DeleteAll()

            Dim dt As New DataTable("Lista - Modulos")
            dt.Columns.Add(New DataColumn("IDRol", GetType(Integer)))
            dt.Columns.Add(New DataColumn("IDEmpresa", GetType(String)))
            dt.Columns.Add(New DataColumn("IDEstablecimiento", GetType(Integer)))
            dt.Columns.Add(New DataColumn("Nombre", GetType(String)))
            dt.Columns.Add(New DataColumn("estado", GetType(String)))

            For Each i In listaCentroCostosXNComercial
                Dim dr As DataRow = dt.NewRow()

                dr(0) = i.IdNegocioComercial
                dr(1) = i.idEmpresa
                dr(2) = i.idCentroCosto
                dr(3) = i.nombreComercial
                dr(4) = i.EstaAutorizado
                dt.Rows.Add(dr)

                listaIDNegocio.Add(i.IdNegocioComercial)

                'Dim obj = listaPermisos.Where(Function(o) o.IDAsegurable = i.IDAsegurable).SingleOrDefault
                'If obj IsNot Nothing Then
                '    listaPermisos.Remove(obj)
                'End If
            Next
            GridGroupingControl1.DataSource = dt

            ListView1.Items.Clear()

            For Each i In ListaObjeto.Where(Function(o) Not listaIDNegocio.Contains(o.IdNegocioComercial)).ToList
                Dim n As New ListViewItem(i.IdNegocioComercial)
                n.SubItems.Add(i.nombreRubro)
                n.SubItems.Add(i.nombreRubro)
                ListView1.Items.Add(n)
            Next
            ListView1.Refresh()
            pnNegociosEspecializados.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub RegistrarPermiso(idaseg As Integer)
        Try

            Dim sa As New centroCostosXNComercialSA
            Dim objeto As New centroCostosXNComercial

            Dim entNuevo As New centrocosto
            entNuevo = CType(trOrganigrama.SelectedNode.Tag, centrocosto)


            objeto.IdEmpresa = Gempresas.IdEmpresaRuc
            objeto.idCentroCosto = entNuevo.idCentroCosto
            objeto.IdNegocioComercial = idaseg
            objeto.EstaAutorizado = "SI"
            objeto.idUsuario = usuario.IDUsuario
            objeto.usuarioActualizacion = "Maykol"
            objeto.FechaActualizacion = DateTime.Now

            sa.GetInsertarcentroCostosXNComercial(objeto)

            MessageBox.Show("OK")
            'pnNegociosEspecializados.Visible = False
            'Dim entNuevo As New centrocosto

            'If (trOrganigrama.SelectedNode.Text = Gempresas.NomEmpresa) Then
            '    MessageBox.Show("Seleccione una Unidad de Negocio")
            'ElseIf (trOrganigrama.SelectedNode.Text = GEstableciento.NombreEstablecimiento) Then
            '    MessageBox.Show("Seleccione una Unidad de Negocio")
            'Else
            '    entNuevo = CType(trOrganigrama.SelectedNode.Tag, centrocosto)

            ListarAsegurableRol(entNuevo.idCentroCosto)


            'End If

        Catch ex As Exception
            MessageBox.Show("No se Pudo dar Permiso")
        End Try

    End Sub

    Sub EliminarPermisoRol(idaseg As Integer)
        Try

            Dim sa As New centroCostosXNComercialSA
            Dim objeto As New centroCostosXNComercial

            objeto.idEmpresa = Gempresas.IdEmpresaRuc
            objeto.idCentroCosto = GEstableciento.IdEstablecimiento
            objeto.IdNegocioComercial = idaseg
            objeto.EstaAutorizado = True
            objeto.usuarioActualizacion = "Maykol"
            objeto.fechaActualizacion = DateTime.Now

            sa.EliminarPermisoNegocioCOmercial(objeto)

            MessageBox.Show("OK")
            pnNegociosEspecializados.Visible = False
            Dim entNuevo As New centrocosto

            If (trOrganigrama.SelectedNode.Text = Gempresas.NomEmpresa) Then
                MessageBox.Show("Seleccione una Unidad de Negocio")
            ElseIf (trOrganigrama.SelectedNode.Text = GEstableciento.NombreEstablecimiento) Then
                MessageBox.Show("Seleccione una Unidad de Negocio")
            Else
                entNuevo = CType(trOrganigrama.SelectedNode.Tag, centrocosto)

                ListarAsegurableRol(entNuevo.idCentroCosto)


            End If

        Catch ex As Exception
            MessageBox.Show("No se Pudo Eliminar Permiso")
        End Try
    End Sub

#End Region

#Region "ARBOL DE ORGANIGRAMA"

    Private Sub CrearNodosDelPadre()
        Try

            Dim nodePadre As TreeNode
            Dim contqao As Integer = 0
            Dim contarHijos As Integer = 0
            Dim nietsosA As Integer = 0
            Dim nietoB As Integer = 0
            Dim contarEncabezado As Integer = 0
            Dim establecimientoSA As New establecimientoSA

            listaCentrocosto = establecimientoSA.ObtenerListaEstablecimientos(Gempresas.IdEmpresaRuc).ToList


            trOrganigrama.Nodes.Clear()

            Dim nodeEncabezado = New TreeNode

            'Descripción o texto del nodo
            nodeEncabezado.Text = Gempresas.NomEmpresa
            nodeEncabezado.ForeColor = Color.Red
            'Si necesito guardar el valor del IdentificadorNodo dentro del mismo nodo
            nodeEncabezado.Name = 0

            'Si necesito guardar el valor del IdentificadorPadre dentro del mismo nodo
            nodeEncabezado.Tag = 0
            trOrganigrama.Nodes.Add(nodeEncabezado)

            Dim consultaPadre = (From a In listaCentrocosto Where a.idpadre = 0 Select a).ToList

            'Dim consultaPadre = (From a In listaOr Where a.idPadre = 0 And a.idCentroCosto = cbunidadnegocioOrg.SelectedValue
            '                     Order By a.idOrganigrama Ascending Select a).ToList

            For Each PADRE In consultaPadre
                nodePadre = New TreeNode

                'Descripción o texto del nodo
                nodePadre.Text = PADRE.nombre

                'Si necesito guardar el valor del IdentificadorNodo dentro del mismo nodo
                nodePadre.Name = PADRE.idCentroCosto

                'Si necesito guardar el valor del IdentificadorPadre dentro del mismo nodo
                nodePadre.Tag = PADRE

                Dim ent = CType(nodePadre.Tag, centrocosto)

                trOrganigrama.Nodes(contarEncabezado).Nodes.Add(nodePadre)

                Dim consulta = (From a In listaCentrocosto Where a.idpadre = ent.idCentroCosto
                                Order By a.idCentroCosto Ascending Select a).ToList

                If ((consulta.Count) > 0) Then
                    For Each hijos In consulta

                        Dim nodeHIJO = New TreeNode

                        'Descripción o texto del nodo
                        nodeHIJO.Text = hijos.nombre
                        nodeHIJO.ForeColor = Color.FromArgb(32, 182, 82)
                        'Si necesito guardar el valor del IdentificadorNodo dentro del mismo nodo
                        nodeHIJO.Name = hijos.idCentroCosto

                        'Si necesito guardar el valor del IdentificadorPadre dentro del mismo nodo
                        'nodeHIJO.Tag = hijos.ID

                        nodeHIJO.Tag = hijos

                        Dim entHijo = CType(nodeHIJO.Tag, centrocosto)

                        trOrganigrama.Nodes(contarEncabezado).Nodes(contqao).Nodes.Add(nodeHIJO)

                        Dim consultANietos = (From a In listaCentrocosto Where a.idpadre = entHijo.idCentroCosto
                                              Order By a.idCentroCosto Ascending Select a).ToList

                        For Each NIETOS In consultANietos
                            Dim nodeNieto = New TreeNode

                            'Descripción o texto del nodo
                            nodeNieto.Text = NIETOS.nombre

                            'Si necesito guardar el valor del IdentificadorNodo dentro del mismo nodo
                            nodeNieto.Name = NIETOS.idCentroCosto

                            'Si necesito guardar el valor del IdentificadorPadre dentro del mismo nodo
                            'nodeNieto.Tag = NIETOS.ID
                            nodeNieto.Tag = NIETOS

                            Dim entNieto = CType(nodeNieto.Tag, centrocosto)

                            trOrganigrama.Nodes(contarEncabezado).Nodes(contqao).Nodes(contarHijos).Nodes.Add(nodeNieto)


                            Dim consultanietosA = (From m In listaCentrocosto Where m.idpadre = entNieto.idCentroCosto
                                                   Order By m.idCentroCosto Ascending Select m).ToList

                            For Each nietosA In consultanietosA

                                Dim nodeNietosA = New TreeNode

                                nodeNietosA.Text = nietosA.nombre
                                nodeNietosA.ForeColor = Color.FromArgb(7, 117, 129)
                                nodeNietosA.Name = nietosA.idCentroCosto

                                'nodeNietosA.Tag = nietosA.ID
                                nodeNietosA.Tag = nietosA

                                Dim entnodeNietosA = CType(nodeNieto.Tag, centrocosto)
                                trOrganigrama.Nodes(contarEncabezado).Nodes(contqao).Nodes(contarHijos).Nodes(nietsosA).Nodes.Add(nodeNietosA)

                                Dim consultaNietoB = (From p In listaCentrocosto Where p.idpadre = entnodeNietosA.idCentroCosto
                                                      Order By p.idCentroCosto Ascending Select p).ToList

                                For Each nietosB In consultaNietoB
                                    Dim nodoNietoB = New TreeNode

                                    nodoNietoB.Text = nietosB.nombre

                                    nodoNietoB.Name = nietosB.idCentroCosto

                                    'nodoNietoB.Tag = nietosB.ID
                                    nodeNietosA.Tag = nietosB
                                    trOrganigrama.Nodes(contarEncabezado).Nodes(contqao).Nodes(contarHijos).Nodes(nietsosA).Nodes(nietoB).Nodes.Add(nodoNietoB)
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
            trOrganigrama.EndUpdate()
            trOrganigrama.ExpandAll()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub ListView1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListView1.MouseDoubleClick
        If (Not IsNothing(trOrganigrama.SelectedNode)) Then
            If (GridGroupingControl1.Table.Records.Count = 0) Then
                If ListView1.SelectedItems.Count = 0 Then Exit Sub
                RegistrarPermiso(Int32.Parse(ListView1.SelectedItems(0).SubItems(0).Text))
            Else
                MessageBox.Show("Ya tiene un negocio especializado")
            End If
        Else
                MessageBox.Show("Debe Selecciona runa unidad de negocio")
        End If
    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        Try
            If Not IsNothing(GridGroupingControl1.Table.CurrentRecord) Then
                EliminarPermisoRol(CInt(GridGroupingControl1.Table.CurrentRecord.GetValue("IDAsegurable")))
            Else
                MessageBox.Show("Debe seleccionar un modulo!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub TrOrganigrama_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles trOrganigrama.AfterSelect
        Try

            If (trOrganigrama.SelectedNode.Text = Gempresas.NomEmpresa) Then

            Else
                Dim entNuevo As New centrocosto
                entNuevo = CType(trOrganigrama.SelectedNode.Tag, centrocosto)

                GridGroupingControl1.Table.Records.DeleteAll()
                Select Case entNuevo.TipoEstab
                    Case "UN"
                        ListarAsegurableRol(entNuevo.idCentroCosto)
                    Case Else
                        MessageBox.Show("Seleccione una Unidad de Negocio")
                End Select

            End If


            'If (trOrganigrama.SelectedNode.Text = Gempresas.NomEmpresa) Then

            'ElseIf (trOrganigrama.SelectedNode.Text = GEstableciento.NombreEstablecimiento) Then


            'Else
            '    MessageBox.Show("Seleccione una Unidad de Negocio")
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click

        If (GridGroupingControl1.Table.Records.Count = 0) Then
            pnNegociosEspecializados.Visible = True
        Else
            MessageBox.Show("Ya existe un negocio especialzado")
            pnNegociosEspecializados.Visible = False
            End If


    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        pnNegociosEspecializados.Visible = False
    End Sub
#End Region

End Class