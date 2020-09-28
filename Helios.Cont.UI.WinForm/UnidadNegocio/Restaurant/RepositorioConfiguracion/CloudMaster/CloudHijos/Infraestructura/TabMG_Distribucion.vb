Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Tools


Public Class TabMG_Distribucion

#Region "Attributes"
    Dim selectionColl As New Hashtable()
    Dim hoveredIndex As Integer = 0
    Dim filter As New GridExcelFilter()
    Private node As TreeNodeAdv = Nothing
    Public nodePadre = New TreeNode
#End Region

#Region "Constructors"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormatoGridAvanzado(dgvCompras, True, False)
        GetTableDetalle()
        dgvCompras.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended
    End Sub
#End Region

#Region "Methods"

    Private Sub EliminarDistribucion()
        Dim distribucionBE As New distribucionInfraestructura
        Dim distribucionSA As New distribucionInfraestructuraSA

        distribucionBE.idEmpresa = Gempresas.IdEmpresaRuc
        distribucionBE.idEstablecimiento = GEstableciento.IdEstablecimiento

        distribucionSA.EliminarDistribucionFull(distribucionBE)
        'PanelBody.Controls.Clear()
        MessageBoxAdv.Show("Se elimino exitosamente la distribución!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Private Sub CambiarStatusItem(Id As Integer, estado As String)
        Dim infraestructuraBE As New infraestructura
        Dim infraestructuraSA As New infraestructuraSA

        infraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
        infraestructuraBE.idEstablecimiento = GEstableciento.IdEstablecimiento
        infraestructuraBE.idInfraestructura = Id
        infraestructuraBE.estado = estado

        infraestructuraSA.EditarInfraestructuraEstado(infraestructuraBE)

    End Sub

    Private Sub GetTableDetalle()
        Dim distribucionInfraestructuraSA As New distribucionInfraestructuraSA
        Dim distribucionInfraestructuraBE As New distribucionInfraestructura
        Dim dt As New DataTable
        ' Dim tables() As String = {"1", "2", "6", "10", "14", ""}

        distribucionInfraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
        distribucionInfraestructuraBE.idEstablecimiento = GEstableciento.IdEstablecimiento

        With dt.Columns
            .Add("idtabla")
            .Add("bloque")
            .Add("segmento")
            .Add("piso")
            .Add("descripcion")
            .Add("numero")
            .Add("estado")
        End With

        For Each i In distribucionInfraestructuraSA.getListaDistribucionInfraestructura(distribucionInfraestructuraBE) '.Where(Function(o) tables.Contains(o.idtabla)).ToList
            dt.Rows.Add(i.idDistribucion, i.NombreBloque, i.NombreSector, i.NombrePiso, i.descripcionDistribucion, i.numeracion, i.estado)
        Next
        dgvCompras.DataSource = dt
        dgvCompras.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        dgvCompras.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
    End Sub

    Private Sub IsMouseHover(row As Integer, col As Integer, isHover As Boolean, GGC As GridGroupingControl)
        Dim color As New GridMetroColors()
        Dim id As GridTableCellStyleInfoIdentity = GGC.TableControl.GetTableViewStyleInfo(row, col).TableCellIdentity
        If id.DisplayElement.IsRecord() Then
            Dim key As Integer = id.DisplayElement.GetRecord().Id
            'if (selectionColl.Contains(key))
            '    selectionColl[key] = isHover;
            'else
            hoveredIndex = row
            selectionColl.Clear()
            'if (selectionColl.Count == 0)
            '    selectionColl.Add(key, isHover);
            GGC.TableControl.Refresh()
        End If

        GGC.TableControl.Selections.Clear()

    End Sub

    Private Sub CrearNodosDelPadre(IdTipoServicio As Integer)
        Try

            Dim distribucionTipoServicioBE As New Tipo
            Dim distribucionTipoServicioSA As New distribucionTipoServicioSA
            Dim listadistribucionTipoServicio As New List(Of distribucionTipoServicio)

            ''distribucionTipoServicioBE.idTipoServicio = IdTipoServicio
            ''listadistribucionTipoServicio = distribucionTipoServicioSA.GetUbicarDistribucionFull(distribucionTipoServicioBE)


            'Dim contqao As Integer = 0
            'Dim contarHijos As Integer = 0
            'Dim contarEncabezado As Integer = 0
            'Dim contarComponente As Integer = 0

            'tvListaModulos.Nodes.Clear()

            'Dim nodeEncabezado = New TreeNode

            ''Descripción o texto del nodo
            'nodeEncabezado.Text = "EMPRESA PRUEBAS SAC" & "/" & "UNIDAD DE NEGOCIO"

            ''Si necesito guardar el valor del IdentificadorNodo dentro del mismo nodo
            'nodeEncabezado.Name = 0

            ''Si necesito guardar el valor del IdentificadorPadre dentro del mismo nodo
            'nodeEncabezado.Tag = 0
            'tvListaModulos.Nodes.Add(nodeEncabezado)

            'Dim consultaPadre = (From a In listaInfraestructura Where a.idPadre = 0
            '                     Order By a.idInfraestructura Ascending Select a).ToList

            'For Each PADRE In consultaPadre
            '    nodePadre = New TreeNode

            '    'Descripción o texto del nodo
            '    nodePadre.Text = PADRE.nombre

            '    'Si necesito guardar el valor del IdentificadorNodo dentro del mismo nodo
            '    nodePadre.Name = PADRE.idInfraestructura

            '    'Si necesito guardar el valor del IdentificadorPadre dentro del mismo nodo
            '    nodePadre.Tag = PADRE.idInfraestructura
            '    tvListaModulos.Nodes(contarEncabezado).Nodes.Add(nodePadre)

            '    Dim consulta = (From a In listaInfraestructura Where a.idPadre = nodePadre.Tag
            '                    Order By a.idInfraestructura Ascending Select a).ToList

            '    If ((consulta.Count) > 0) Then
            '        For Each hijos In consulta

            '            Dim nodeHIJO = New TreeNode

            '            'Descripción o texto del nodo
            '            nodeHIJO.Text = hijos.nombre

            '            'Si necesito guardar el valor del IdentificadorNodo dentro del mismo nodo
            '            nodeHIJO.Name = hijos.idInfraestructura

            '            'Si necesito guardar el valor del IdentificadorPadre dentro del mismo nodo
            '            nodeHIJO.Tag = hijos.idInfraestructura
            '            tvListaModulos.Nodes(contarEncabezado).Nodes(contqao).Nodes.Add(nodeHIJO)

            '            Dim consultANietos = (From a In listaInfraestructura Where a.idPadre = nodeHIJO.Tag
            '                                  Order By a.idInfraestructura Ascending Select a).ToList

            '            For Each NIETOS In consultANietos
            '                Dim nodeNieto = New TreeNode

            '                'Descripción o texto del nodo
            '                nodeNieto.Text = NIETOS.nombre

            '                'Si necesito guardar el valor del IdentificadorNodo dentro del mismo nodo
            '                nodeNieto.Name = NIETOS.idInfraestructura

            '                'Si necesito guardar el valor del IdentificadorPadre dentro del mismo nodo
            '                nodeNieto.Tag = NIETOS.idInfraestructura
            '                tvListaModulos.Nodes(contarEncabezado).Nodes(contqao).Nodes(contarHijos).Nodes.Add(nodeNieto)

            '                Dim consultaComponente = (From a In listaDistribucion Where a.idInfraestructura = nodeNieto.Tag
            '                                          Order By a.idDistribucion Ascending Select a).ToList

            '                For Each componente In consultaComponente
            '                    Dim nodeComponente = New TreeNode

            '                    'Descripción o texto del nodo
            '                    nodeComponente.Text = componente.descripcionDistribucion & "  N° " & componente.numeracion

            '                    'Si necesito guardar el valor del IdentificadorNodo dentro del mismo nodo
            '                    nodeComponente.Name = componente.idDistribucion

            '                    'Si necesito guardar el valor del IdentificadorPadre dentro del mismo nodo
            '                    nodeComponente.Tag = componente.idDistribucion
            '                    tvListaModulos.Nodes(contarEncabezado).Nodes(contqao).Nodes(contarHijos).Nodes(contarComponente).Nodes.Add(nodeComponente)

            '                Next
            '                If (consultANietos.Count > 1) Then
            '                    contarComponente += 1
            '                Else
            '                    contarComponente = 0
            '                End If

            '            Next
            '            If (consulta.Count > 1) Then
            '                contarHijos += 1
            '            Else
            '                contarHijos = 0
            '            End If
            '            contarComponente = 0
            '        Next

            '        contarHijos = 0
            '    End If
            '    'contarHijos += 1
            '    contqao += 1
            'Next
            'tvListaModulos.EndUpdate()
            'tvListaModulos.ExpandAll()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

#End Region

#Region "Events"
    Private Sub dgvCompras_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvCompras.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            dgvCompras.TableControl.Selections.Clear()
        End If
    End Sub

    Private Sub dgvCompras_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgvCompras.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgvCompras)
    End Sub

    Private Sub PonerInactivoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PonerInactivoToolStripMenuItem.Click
        Dim r As Record = dgvCompras.Table.CurrentRecord
        If r IsNot Nothing Then
            If MessageBox.Show("Desea dar de baja el item seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                CambiarStatusItem(Integer.Parse(r.GetValue("idtabla")), "AN")
                'ButtonAdv1_Click(sender, e)
            End If
        Else
            MsgBox("Debe seleccionar un item", MsgBoxStyle.Exclamation, "Seleccionar fila")
        End If
    End Sub

    Private Sub ActivarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActivarToolStripMenuItem.Click
        Dim r As Record = dgvCompras.Table.CurrentRecord
        If r IsNot Nothing Then
            If MessageBox.Show("Desea dar de baja el item seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                CambiarStatusItem(Integer.Parse(r.GetValue("idtabla")), "A")
                'ButtonAdv1_Click(sender, e)
            End If
        Else
            MsgBox("Debe seleccionar un item", MsgBoxStyle.Exclamation, "Seleccionar fila")
        End If
    End Sub

    Private Sub EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem.Click
        Dim r As Record = dgvCompras.Table.CurrentRecord
        If r IsNot Nothing Then
            If MessageBox.Show("Desea dar de baja el item seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                CambiarStatusItem(Integer.Parse(r.GetValue("idtabla")), "E")
                'ButtonAdv1_Click(sender, e)
            End If
        Else
            MsgBox("Debe seleccionar un item", MsgBoxStyle.Exclamation, "Seleccionar fila")
        End If
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        If MessageBox.Show("Desea Eliminar toda la distribución?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            EliminarDistribucion()
        End If
    End Sub

    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton3.Click
        Cursor = Cursors.WaitCursor
        GetTableDetalle()
        Cursor = Cursors.Default
    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
        Dim f As New frmInfraestructuraDistribucion
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog()
        GetTableDetalle()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        dgvCompras.TopLevelGroupOptions.ShowFilterBar = True
        dgvCompras.NestedTableGroupOptions.ShowFilterBar = True
        dgvCompras.ChildGroupOptions.ShowFilterBar = True
        For Each col As GridColumnDescriptor In dgvCompras.TableDescriptor.Columns
            col.AllowFilter = True
        Next
        filter.AllowResize = True
        filter.AllowFilterByColor = True
        filter.EnableDateFilter = True
        filter.EnableNumberFilter = True

        dgvCompras.OptimizeFilterPerformance = True
        dgvCompras.ShowNavigationBar = True
        filter.WireGrid(dgvCompras)
    End Sub

    Private Sub BunifuFlatButton5_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton5.Click
        Try

            Dim listaInfra As New List(Of distribucionInfraestructura)
                Dim infraBE As New distribucionInfraestructura

                For Each item In dgvCompras.Table.SelectedRecords
                    infraBE = New distribucionInfraestructura
                    infraBE.idDistribucion = item.Record.GetValue("idtabla")
                    infraBE.descripcionDistribucion = item.Record.GetValue("descripcion")
                    listaInfra.Add(infraBE)
                Next

            If (listaInfra.Count > 0) Then
                Dim f As New frmControlDetalleInfra
                f.GetListaInfraestructura(listaInfra)
                f.StartPosition = FormStartPosition.CenterScreen
                f.ShowDialog()
                GetTableDetalle()
            Else
                MessageBox.Show("Debe Seleccionar uno o mas componentes")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click
        GetTableDetalle()
    End Sub

    Private Sub DgvCompras_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCompras.TableControlCellClick

    End Sub

    Private Sub BunifuFlatButton6_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton6.Click
        Dim f As New FormAdministrarPrecio()
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        GetTableDetalle()
    End Sub

    'Cursor = Cursors.WaitCursor
    'If Not IsNothing(dgvCompras.Table.CurrentRecord) Then
    '    Dim f As New frmTipoServicioDetallexComponente()
    '    f.IdTipoServicio = dgvCompras.Table.CurrentRecord.GetValue("idComponente")
    '    f.cargarDatos()
    '    f.StartPosition = FormStartPosition.CenterParent
    '    f.ShowDialog()
    '    GetTableDetalle()
    'Else
    '    MessageBox.Show("Debe seleccionar una categoria!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    'End If
    'Cursor = Cursors.Default

#End Region

End Class
