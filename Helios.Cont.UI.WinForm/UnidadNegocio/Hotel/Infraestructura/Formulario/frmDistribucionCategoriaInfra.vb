Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Microsoft
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Tools
Imports Syncfusion.Drawing
Imports System.Threading

Public Class frmDistribucionCategoriaInfra
    Inherits frmMaster

    Public Property EstadoManipulacion() As String
    Public Property listacategoriaInfraestructura As New List(Of categoriaInfraestructura)
    Public Property UnidadNegocioID As Integer
    Dim codigo As Integer = 0
    Public Alert As Alert
    Dim numeracion As Integer
    Private node As TreeNodeAdv = Nothing
    Public nodePadre = New TreeNode

    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
    Private Thread As Thread

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'FormatoGridPequeño(dgvDetalleArea, False, 11.0F)
        'FormatoGridPequeño(dgAtendido, False, 11.0F)
        'CargarCombos()

        FormatoGridAvanzado(dgvComponente, False, False)

        Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() CargarCategoria()))
        Thread.Start()

        CrearNodosDelPadre()

    End Sub

    Private Sub CargarCategoria()
        Try

            Dim tipoServicioInfraestructuraBE As New tipoServicioInfraestructura
            Dim tipoServicioInfraestructuraSA As New tipoServicioInfraestructuraSA
            Dim listatipoServicioInfraestructura As New List(Of tipoServicioInfraestructura)

            tipoServicioInfraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
            tipoServicioInfraestructuraBE.idEstablecimiento = GEstableciento.IdEstablecimiento

            listatipoServicioInfraestructura = tipoServicioInfraestructuraSA.GetUbicartipoServicioInfraSinClasificacion(tipoServicioInfraestructuraBE)

            Dim dt As New DataTable

            With dt.Columns
                .Add("idServicio")
                .Add("descripcionTipoServicio")
            End With

            For Each i In listatipoServicioInfraestructura
                Dim dr As DataRow = dt.NewRow()
                dr(0) = i.idTipoServicio
                dr(1) = i.descripcionTipoServicio
                dt.Rows.Add(dr)
            Next

            setDatasource(dt)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub setDatasource(ByVal table As DataTable)
        If Me.InvokeRequired Then
            Dim deleg As New SetDataSourceDelegate(AddressOf setDatasource)
            Invoke(deleg, New Object() {table})
        Else
            dgvComponente.DataSource = table
            dgvComponente.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended
        End If
    End Sub

    Private Sub CrearNodosDelPadre()
        Try

            Dim categoriaInfraestructuraBE As New categoriaInfraestructura
            Dim categoriaInfraestructuraSA As New categoriaInfraestructuraSA

            categoriaInfraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
            categoriaInfraestructuraBE.idEstablecimiento = GEstableciento.IdEstablecimiento

            listacategoriaInfraestructura = categoriaInfraestructuraSA.GetUbicarCategoriaAndListaSubCategoria(categoriaInfraestructuraBE)


            Dim contqao As Integer = 0
            Dim contarHijos As Integer = 0
            Dim contarEncabezado As Integer = 0
            Dim contarComponente As Integer = 0

            tvListaModulos.Nodes.Clear()

            Dim nodeEncabezado = New TreeNode

            'Descripción o texto del nodo
            nodeEncabezado.Text = GEstableciento.NombreEstablecimiento

            'Si necesito guardar el valor del IdentificadorNodo dentro del mismo nodo
            nodeEncabezado.Name = 0

            'Si necesito guardar el valor del IdentificadorPadre dentro del mismo nodo
            nodeEncabezado.Tag = 0
            tvListaModulos.Nodes.Add(nodeEncabezado)

            Dim consultaPadre = (From a In listacategoriaInfraestructura Order By a.idCategoria Ascending Select a).ToList

            For Each PADRE In consultaPadre
                nodePadre = New TreeNode

                'Descripción o texto del nodo
                nodePadre.Text = PADRE.descripcionInfraestructura

                'Si necesito guardar el valor del IdentificadorNodo dentro del mismo nodo
                nodePadre.Name = PADRE.idCategoria

                'Si necesito guardar el valor del IdentificadorPadre dentro del mismo nodo
                nodePadre.Tag = PADRE.idCategoria
                tvListaModulos.Nodes(contarEncabezado).Nodes.Add(nodePadre)

                Dim consulta = (From a In PADRE.tipoServicioInfraestructura Where a.idCategoria = nodePadre.Tag
                                Order By a.descripcionTipoServicio Ascending Select a).ToList

                If ((consulta.Count) > 0) Then
                    For Each hijos In consulta

                        Dim nodeHIJO = New TreeNode

                        'Descripción o texto del nodo
                        nodeHIJO.Text = hijos.descripcionTipoServicio

                        'Si necesito guardar el valor del IdentificadorNodo dentro del mismo nodo
                        nodeHIJO.Name = hijos.idTipoServicio

                        'Si necesito guardar el valor del IdentificadorPadre dentro del mismo nodo
                        nodeHIJO.Tag = hijos.idTipoServicio
                        tvListaModulos.Nodes(contarEncabezado).Nodes(contqao).Nodes.Add(nodeHIJO)

                        If (consulta.Count > 1) Then
                            contarHijos += 1
                        Else
                            contarHijos = 0
                        End If
                        contarComponente = 0
                    Next

                    contarHijos = 0
                End If
                'contarHijos += 1
                contqao += 1
            Next
            tvListaModulos.EndUpdate()
            tvListaModulos.ExpandAll()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub GrabarDistribucion(idCategoria As Integer, listaComponente As List(Of tipoServicioInfraestructura))
        Dim tipoServicioInfraestructuraBE As New tipoServicioInfraestructura
        Dim tipoServicioInfraestructuraSA As New tipoServicioInfraestructuraSA
        Dim listaDistribucion As New List(Of tipoServicioInfraestructura)

        'tipoServicioInfraestructuraSA.EditarTipoServicioInfraestructuraXCategoria(listaComponente)

    End Sub

    Private Sub dgvInfraestructura_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs)
        CrearNodosDelPadre()
    End Sub

    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton3.Click
        Dim tipoServicioInfraestructuraeBE As New tipoServicioInfraestructura
        Dim listatipoServicioInfraestructura As New List(Of tipoServicioInfraestructura)
        Dim ConteoCheck As Integer = 0
        Try

            If (txtClasificacion.Text.Length > 0) Then

            Else
                Exit Sub
            End If

            If (txtClasificacion.Tag > 0) Then

            Else
                Exit Sub
            End If

            For Each ITEM In dgvComponente.Table.Records
                ConteoCheck += 1
            Next

            If (ConteoCheck > 0) Then
                If (Not IsNothing(dgvComponente.Table.CurrentRecord)) Then
                    If MessageBox.Show("Desea realizar la distribución?", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                        For Each ITEM In dgvComponente.Table.SelectedRecords
                            'If (ITEM.GetValue("seleccion") = True) Then
                            tipoServicioInfraestructuraeBE = New tipoServicioInfraestructura
                            tipoServicioInfraestructuraeBE.descripcionTipoServicio = ITEM.Record.GetValue("descripcionTipoServicio")
                            tipoServicioInfraestructuraeBE.idTipoServicio = ITEM.Record.GetValue("idServicio")
                            tipoServicioInfraestructuraeBE.idCategoria = txtClasificacion.Tag
                            listatipoServicioInfraestructura.Add(tipoServicioInfraestructuraeBE)
                            ITEM.Record.Delete()
                            'End If
                        Next

                        GrabarDistribucion(txtClasificacion.Tag, listatipoServicioInfraestructura)
                        CrearNodosDelPadre()
                    End If
                Else

                    MessageBox.Show("Debe seleccionar una infraestructura")
                End If
            Else
                MessageBox.Show("Debe seleccionar un componente")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs)
        Dispose()
    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click
        If MessageBox.Show("Desea Eliminar toda la distribución?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            'EliminarDistribucion()
        End If
    End Sub

    Private Sub TvListaModulos_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles tvListaModulos.AfterSelect
        txtClasificacion.Text = Me.tvListaModulos.SelectedNode.Text
        txtClasificacion.Tag = Me.tvListaModulos.SelectedNode.Tag
    End Sub
End Class