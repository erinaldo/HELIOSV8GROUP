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

Public Class frmInfraestructura
    Inherits frmMaster

    Public Property EstadoManipulacion() As String
    Public Property listaInfraestructura As New List(Of infraestructura)
    Public Property UnidadNegocioID As Integer
    Dim codigo As Integer = 0
    Public Alert As Alert
    Dim numeracion As Integer
    Private node As TreeNodeAdv = Nothing
    Public nodePadre = New TreeNode

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        CargarCombos()
        CrearNodosDelPadre(0)
    End Sub

    Private Sub CrearNodosDelPadre(TIPO As Integer)
        Try
            Dim infraestructuraSA As New infraestructuraSA
            Dim infraestructuraBE As New infraestructura

            If (TIPO = 1) Then
                infraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
                infraestructuraBE.idEstablecimiento = GEstableciento.IdEstablecimiento
                listaInfraestructura = infraestructuraSA.getListaInfraestructuraFull(infraestructuraBE)
            End If

            Dim contqao As Integer = 0
            Dim contarHijos As Integer = 0
            Dim contarEncabezado As Integer = 0

            tvListaModulos.Nodes.Clear()

            Dim nodeEncabezado = New TreeNode

            'Descripción o texto del nodo
            nodeEncabezado.Text = "EMPRESA PRUEBAS SAC" & "/" & "UNIDAD DE NEGOCIO"

            'Si necesito guardar el valor del IdentificadorNodo dentro del mismo nodo
            nodeEncabezado.Name = 0

            'Si necesito guardar el valor del IdentificadorPadre dentro del mismo nodo
            nodeEncabezado.Tag = 0
            tvListaModulos.Nodes.Add(nodeEncabezado)

            Dim consultaPadre = (From a In listaInfraestructura Where a.idPadre = 0
                                 Order By a.idInfraestructura Ascending Select a).ToList

            For Each PADRE In consultaPadre
                nodePadre = New TreeNode

                'Descripción o texto del nodo
                nodePadre.Text = PADRE.nombre

                'Si necesito guardar el valor del IdentificadorNodo dentro del mismo nodo
                nodePadre.Name = PADRE.idInfraestructura

                'Si necesito guardar el valor del IdentificadorPadre dentro del mismo nodo
                nodePadre.Tag = PADRE.idInfraestructura
                tvListaModulos.Nodes(contarEncabezado).Nodes.Add(nodePadre)

                Dim consulta = (From a In listaInfraestructura Where a.idPadre = nodePadre.Tag
                                Order By a.idInfraestructura Ascending Select a).ToList

                If ((consulta.Count) > 0) Then
                    For Each hijos In consulta

                        Dim nodeHIJO = New TreeNode

                        'Descripción o texto del nodo
                        nodeHIJO.Text = hijos.nombre

                        'Si necesito guardar el valor del IdentificadorNodo dentro del mismo nodo
                        nodeHIJO.Name = hijos.idInfraestructura

                        'Si necesito guardar el valor del IdentificadorPadre dentro del mismo nodo
                        nodeHIJO.Tag = hijos.idInfraestructura
                        tvListaModulos.Nodes(contarEncabezado).Nodes(contqao).Nodes.Add(nodeHIJO)

                        Dim consultANietos = (From a In listaInfraestructura Where a.idPadre = nodeHIJO.Tag
                                              Order By a.idInfraestructura Ascending Select a).ToList

                        For Each NIETOS In consultANietos
                            Dim nodeNieto = New TreeNode

                            'Descripción o texto del nodo
                            nodeNieto.Text = NIETOS.nombre

                            'Si necesito guardar el valor del IdentificadorNodo dentro del mismo nodo
                            nodeNieto.Name = NIETOS.idInfraestructura

                            'Si necesito guardar el valor del IdentificadorPadre dentro del mismo nodo
                            nodeNieto.Tag = NIETOS.idInfraestructura
                            tvListaModulos.Nodes(contarEncabezado).Nodes(contqao).Nodes(contarHijos).Nodes.Add(nodeNieto)

                        Next
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
            tvListaModulos.EndUpdate()
            tvListaModulos.ExpandAll()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub CargarCombos()
        Dim infraestructuraSA As New infraestructuraSA
        Dim infraestructuraBE As New infraestructura
        Dim listaInfraestructuraBloque As New List(Of infraestructura)
        Dim listaInfraestructuraPiso As New List(Of infraestructura)
        Dim listaInfraestructuraSector As New List(Of infraestructura)

        Try
            infraestructuraBE = New infraestructura
            infraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
            infraestructuraBE.idEstablecimiento = GEstableciento.IdEstablecimiento

            listaInfraestructura = infraestructuraSA.getListaInfraestructuraFull(infraestructuraBE)

            If (listaInfraestructura.Count > 0) Then

                listaInfraestructuraBloque = (From item In listaInfraestructura Where item.tipo = "B").ToList

                cboBloque.Items.Clear()
                cboBloque.ValueMember = "idInfraestructura"
                cboBloque.DisplayMember = "nombre"
                cboBloque.DataSource = listaInfraestructuraBloque
                cboBloque.SelectedValue = -1
                cboPiso.Items.Clear()
                cboSector.Items.Clear()
                If (cboBloque.SelectedValue > -1) Then

                    listaInfraestructuraSector = (From item In listaInfraestructura Where item.tipo = "S" And item.idPadre = cboBloque.SelectedValue).ToList

                    cboSector.DataSource = listaInfraestructuraPiso
                    cboSector.ValueMember = "idInfraestructura"
                    cboSector.DisplayMember = "nombre"
                    cboPiso.Items.Clear()

                    If (cboPiso.SelectedValue > -1) Then

                        listaInfraestructuraSector = (From item In listaInfraestructura Where item.tipo = "P" And item.idPadre = cboSector.SelectedValue).ToList

                        cboPiso.DataSource = listaInfraestructuraPiso
                        cboPiso.ValueMember = "idInfraestructura"
                        cboPiso.DisplayMember = "nombre"

                    End If

                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            End Try

    End Sub

    Private Sub EliminarInfraestructura(Id As Integer)
        Dim infraestructuraSA As New infraestructuraSA
        Dim infraestructuraBE As New infraestructura

        Try
            infraestructuraBE = New infraestructura
            infraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
            infraestructuraBE.idEstablecimiento = GEstableciento.IdEstablecimiento
            infraestructuraBE.idInfraestructura = Id

            infraestructuraSA.EliminarInfraestructuraXID(infraestructuraBE)
            LIMPIAR()
            CargarCombos()
            CrearNodosDelPadre(0)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub LIMPIAR()
        cboBloque.DataSource = Nothing
        cboPiso.DataSource = Nothing
        cboSector.DataSource = Nothing
        tvListaModulos.Nodes.Clear()
    End Sub

    Private Sub PictureBox2_Click_1(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim infraestructuraSA As New infraestructuraSA
        Dim infraestructuraBE As New infraestructura
        Dim listaInfraestructura As New List(Of infraestructura)

        Try
            Dim f As New FrmNuevaInfraestructura
            f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
            f.txtServicioNew.Select()
            f.CaptionLabels(0).Text = "Nuevo Infraestructura"
            f.tipo = "B"

            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            If Not IsNothing(f.Tag) Then
                Dim c = CType(f.Tag, infraestructura)

                infraestructuraBE.tipo = "B"
                infraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
                infraestructuraBE.idEstablecimiento = GEstableciento.IdEstablecimiento

                listaInfraestructura = infraestructuraSA.getListaInfraestructura(infraestructuraBE)

                cboPiso.DataSource = Nothing
                cboSector.DataSource = Nothing
                cboBloque.DataSource = Nothing
                cboBloque.ValueMember = "idInfraestructura"
                cboBloque.DisplayMember = "nombre"
                cboBloque.DataSource = listaInfraestructura
                cboBloque.SelectedValue = c.idInfraestructura
                'TREEVIEW

                CrearNodosDelPadre(1)

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    Private Sub cboBloque_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboBloque.SelectionChangeCommitted
        Dim infraestructuraSA As New infraestructuraSA
        Dim infraestructuraBE As New infraestructura
        Dim listaInfraestructura As New List(Of infraestructura)

        Try
            'Select Case ChSector.Checked
            '    Case True

            'dgvDetalleArea.Table.Records.DeleteAll()
            cboSector.DataSource = Nothing
            cboPiso.DataSource = Nothing

            infraestructuraBE.ListaTipo = New List(Of String)
            infraestructuraBE.ListaTipo.Add("S")
            'infraestructuraBE.tipo = "S"
            infraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
            infraestructuraBE.idEstablecimiento = GEstableciento.IdEstablecimiento
            infraestructuraBE.idPadre = cboBloque.SelectedValue

            listaInfraestructura = infraestructuraSA.getListaInfraestructuraxIDPadre(infraestructuraBE)
            cboSector.DataSource = Nothing
            cboSector.DataSource = listaInfraestructura
            cboSector.ValueMember = "idInfraestructura"
            cboSector.DisplayMember = "nombre"


            infraestructuraBE.ListaTipo = New List(Of String)
            infraestructuraBE.ListaTipo.Add("P")

            infraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
            infraestructuraBE.idEstablecimiento = GEstableciento.IdEstablecimiento
            infraestructuraBE.idPadre = cboSector.SelectedValue

            listaInfraestructura = infraestructuraSA.getListaInfraestructuraxIDPadre(infraestructuraBE)
            cboPiso.DataSource = Nothing
            cboPiso.DataSource = listaInfraestructura
            cboPiso.ValueMember = "idInfraestructura"
            cboPiso.DisplayMember = "nombre"

            listaInfraestructura = New List(Of infraestructura)
            infraestructuraBE = New infraestructura
            infraestructuraBE.ListaTipo = New List(Of String)
            infraestructuraBE.ListaTipo.Add("M")
            infraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
            infraestructuraBE.idEstablecimiento = GEstableciento.IdEstablecimiento
            infraestructuraBE.estado = "A"
            infraestructuraBE.tipo = "M"
            infraestructuraBE.idPadre = cboPiso.SelectedValue


            If (Not IsNothing(cboPiso.SelectedValue)) Then

                listaInfraestructura = infraestructuraSA.getListaInfraestructuraxIDPadre(infraestructuraBE)

                'For Each item In listaInfraestructura
                '    Me.dgvDetalleArea.Table.AddNewRecord.SetCurrent()
                '    Me.dgvDetalleArea.Table.AddNewRecord.BeginEdit()
                '    Me.dgvDetalleArea.Table.CurrentRecord.SetValue("nombre", item.nombre) '0
                '    Me.dgvDetalleArea.Table.CurrentRecord.SetValue("cantidad", item.cantidad)
                '    Me.dgvDetalleArea.Table.CurrentRecord.SetValue("numero", item.numero)
                '    Me.dgvDetalleArea.Table.CurrentRecord.SetValue("estado", "A")
                '    Me.dgvDetalleArea.Table.CurrentRecord.SetValue("idInfraestructura", cboPiso.SelectedValue)
                '    Me.dgvDetalleArea.Table.AddNewRecord.EndEdit()
                'Next
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub cboPiso_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboPiso.SelectionChangeCommitted
        Dim infraestructuraSA As New infraestructuraSA
        Dim infraestructuraBE As New infraestructura
        Dim listaInfraestructura As New List(Of infraestructura)

        Try

            'dgvDetalleArea.Table.Records.DeleteAll()

            listaInfraestructura = New List(Of infraestructura)
            infraestructuraBE = New infraestructura
            infraestructuraBE.ListaTipo = New List(Of String)
            infraestructuraBE.ListaTipo.Add("M")
            infraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
            infraestructuraBE.idEstablecimiento = GEstableciento.IdEstablecimiento
            infraestructuraBE.estado = "A"
            infraestructuraBE.tipo = "M"
            infraestructuraBE.idPadre = cboPiso.SelectedValue

            listaInfraestructura = infraestructuraSA.getListaInfraestructuraxIDPadre(infraestructuraBE)

            'For Each item In listaInfraestructura
            '    Me.dgvDetalleArea.Table.AddNewRecord.SetCurrent()
            '    Me.dgvDetalleArea.Table.AddNewRecord.BeginEdit()
            '    Me.dgvDetalleArea.Table.CurrentRecord.SetValue("nombre", item.nombre) '0
            '    Me.dgvDetalleArea.Table.CurrentRecord.SetValue("cantidad", item.cantidad)
            '    Me.dgvDetalleArea.Table.CurrentRecord.SetValue("numero", item.numero)
            '    Me.dgvDetalleArea.Table.CurrentRecord.SetValue("estado", "A")
            '    Me.dgvDetalleArea.Table.CurrentRecord.SetValue("idInfraestructura", cboPiso.SelectedValue)
            '    Me.dgvDetalleArea.Table.AddNewRecord.EndEdit()
            'Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboSector_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboSector.SelectionChangeCommitted
        Dim infraestructuraSA As New infraestructuraSA
        Dim infraestructuraBE As New infraestructura
        Dim listaInfraestructura As New List(Of infraestructura)

        Try

            'dgvDetalleArea.Table.Records.DeleteAll()
            cboPiso.DataSource = Nothing

            infraestructuraBE.ListaTipo = New List(Of String)
            infraestructuraBE.ListaTipo.Add("P")

            infraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
            infraestructuraBE.idEstablecimiento = GEstableciento.IdEstablecimiento
            infraestructuraBE.idPadre = cboSector.SelectedValue

            listaInfraestructura = infraestructuraSA.getListaInfraestructuraxIDPadre(infraestructuraBE)
            cboPiso.DataSource = Nothing
            cboPiso.DataSource = listaInfraestructura
            cboPiso.ValueMember = "idInfraestructura"
            cboPiso.DisplayMember = "nombre"


            listaInfraestructura = New List(Of infraestructura)
            infraestructuraBE = New infraestructura
            infraestructuraBE.ListaTipo = New List(Of String)
            infraestructuraBE.ListaTipo.Add("M")
            infraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
            infraestructuraBE.idEstablecimiento = GEstableciento.IdEstablecimiento
            infraestructuraBE.estado = "A"
            infraestructuraBE.tipo = "M"
            infraestructuraBE.idPadre = cboPiso.SelectedValue

            listaInfraestructura = infraestructuraSA.getListaInfraestructuraxIDPadre(infraestructuraBE)

            'For Each item In listaInfraestructura
            '    Me.dgvDetalleArea.Table.AddNewRecord.SetCurrent()
            '    Me.dgvDetalleArea.Table.AddNewRecord.BeginEdit()
            '    Me.dgvDetalleArea.Table.CurrentRecord.SetValue("nombre", item.nombre) '0
            '    Me.dgvDetalleArea.Table.CurrentRecord.SetValue("cantidad", item.cantidad)
            '    Me.dgvDetalleArea.Table.CurrentRecord.SetValue("numero", item.cantidad)
            '    Me.dgvDetalleArea.Table.CurrentRecord.SetValue("estado", "A")
            '    Me.dgvDetalleArea.Table.CurrentRecord.SetValue("idInfraestructura", cboPiso.SelectedValue)
            '    Me.dgvDetalleArea.Table.AddNewRecord.EndEdit()
            'Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub frmInfraestructura_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dispose()
    End Sub

    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs)
        CargarCombos()
    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs)
        If (tvListaModulos.Nodes.Count > 1) Then
            MessageBox.Show("Ya existe Infraestructura")
        Else
        End If
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        Dispose()
    End Sub

    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton3.Click
        LIMPIAR()
        CargarCombos()
        CrearNodosDelPadre(1)
    End Sub

    Private Sub PictureBox1_Click_2(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim infraestructuraSA As New infraestructuraSA
        Dim infraestructuraBE As New infraestructura
        Dim listaInfraestructura As New List(Of infraestructura)

        Try

            If (cboBloque.SelectedValue > -1) Then

                Dim f As New FrmNuevaInfraestructura(cboBloque.SelectedValue, cboBloque.Text)
                f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                f.txtServicioNew.Select()
                f.CaptionLabels(0).Text = "Editar Infraestructura"
                f.tipo = "B"
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
                If Not IsNothing(f.Tag) Then
                    Dim c = CType(f.Tag, infraestructura)

                    infraestructuraBE.tipo = "B"
                    infraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
                    infraestructuraBE.idEstablecimiento = GEstableciento.IdEstablecimiento

                    listaInfraestructura = infraestructuraSA.getListaInfraestructura(infraestructuraBE)

                    cboPiso.DataSource = Nothing
                    cboSector.DataSource = Nothing
                    cboBloque.DataSource = Nothing
                    cboBloque.ValueMember = "idInfraestructura"
                    cboBloque.DisplayMember = "nombre"
                    cboBloque.DataSource = listaInfraestructura
                    cboBloque.SelectedValue = c.idInfraestructura
                    'TREEVIEW

                    CrearNodosDelPadre(1)

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        Dim infraestructuraSA As New infraestructuraSA
        Dim infraestructuraBE As New infraestructura
        Dim listaInfraestructura As New List(Of infraestructura)

        Try
            If (cboBloque.SelectedValue > -1) Then
                Dim f As New FrmNuevaInfraestructura(cboSector.SelectedValue, cboSector.Text)
                f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                f.txtServicioNew.Select()
            f.CaptionLabels(0).Text = "Editar Infraestructura"
            f.tipo = "S"
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
                If Not IsNothing(f.Tag) Then
                    Dim c = CType(f.Tag, infraestructura)

                    infraestructuraBE.tipo = "S"
                    infraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
                    infraestructuraBE.idEstablecimiento = GEstableciento.IdEstablecimiento

                    listaInfraestructura = infraestructuraSA.getListaInfraestructura(infraestructuraBE)

                    cboPiso.DataSource = Nothing
                    cboSector.DataSource = Nothing
                    cboBloque.DataSource = Nothing
                    cboBloque.ValueMember = "idInfraestructura"
                    cboBloque.DisplayMember = "nombre"
                    cboBloque.DataSource = listaInfraestructura
                    cboBloque.SelectedValue = c.idInfraestructura
                    'TREEVIEW

                    CrearNodosDelPadre(1)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        Dim infraestructuraSA As New infraestructuraSA
        Dim infraestructuraBE As New infraestructura
        Dim listaInfraestructura As New List(Of infraestructura)

        Try
            If (cboBloque.SelectedValue > -1) Then
                Dim f As New FrmNuevaInfraestructura(cboPiso.SelectedValue, cboPiso.Text)
                f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                f.txtServicioNew.Select()
            f.CaptionLabels(0).Text = "Editar Infraestructura"
            f.tipo = "P"
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
                If Not IsNothing(f.Tag) Then
                    Dim c = CType(f.Tag, infraestructura)

                    infraestructuraBE.tipo = "P"
                    infraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
                    infraestructuraBE.idEstablecimiento = GEstableciento.IdEstablecimiento

                    listaInfraestructura = infraestructuraSA.getListaInfraestructura(infraestructuraBE)

                    cboPiso.DataSource = Nothing
                    cboSector.DataSource = Nothing
                    cboBloque.DataSource = Nothing
                    cboBloque.ValueMember = "idInfraestructura"
                    cboBloque.DisplayMember = "nombre"
                    cboBloque.DataSource = listaInfraestructura
                    cboBloque.SelectedValue = c.idInfraestructura
                    'TREEVIEW

                    CrearNodosDelPadre(1)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        If (cboBloque.SelectedValue > -1) Then
            If MessageBox.Show("Desea Eliminar Bloque?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                EliminarInfraestructura(cboBloque.SelectedValue)
            End If
        Else
            MessageBox.Show("Verifique la selección del Bloque")
        End If
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        If (cboBloque.SelectedValue > -1) Then
            If MessageBox.Show("Desea Eliminar Sector?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                EliminarInfraestructura(cboBloque.SelectedValue)
            End If
        Else
            MessageBox.Show("Verifique la selección del Sector")
        End If
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        If (cboBloque.SelectedValue > -1) Then
            If MessageBox.Show("Desea Eliminar Piso?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                EliminarInfraestructura(cboBloque.SelectedValue)
            End If
        Else
            MessageBox.Show("Verifique la selección del Piso")
        End If
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Dim infraestructuraSA As New infraestructuraSA
        Dim infraestructuraBE As New infraestructura
        Dim listaInfraestructura As New List(Of infraestructura)

        Try

            If (cboBloque.SelectedValue > -1) Then
                Dim f As New FrmNuevaInfraestructura(cboBloque.SelectedValue)
                f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                f.txtServicioNew.Select()
                f.CaptionLabels(0).Text = "Nuevo Sector"
                f.tipo = "S"

                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
                If Not IsNothing(f.Tag) Then
                    Dim c = CType(f.Tag, infraestructura)

                    infraestructuraBE.tipo = "S"
                    infraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
                    infraestructuraBE.idEstablecimiento = GEstableciento.IdEstablecimiento

                    listaInfraestructura = infraestructuraSA.getListaInfraestructura(infraestructuraBE)

                    cboPiso.DataSource = Nothing
                    cboSector.DataSource = Nothing
                    cboSector.ValueMember = "idInfraestructura"
                    cboSector.DisplayMember = "nombre"
                    cboSector.DataSource = listaInfraestructura
                    cboSector.SelectedValue = c.idInfraestructura
                    'TREEVIEW

                    CrearNodosDelPadre(1)

                End If
            Else
                MessageBox.Show("Debe selecionar un bloque")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub PxSector_Click(sender As Object, e As EventArgs) Handles pxSector.Click
        Dim infraestructuraSA As New infraestructuraSA
        Dim infraestructuraBE As New infraestructura
        Dim listaInfraestructura As New List(Of infraestructura)

        Try
            If (cboSector.SelectedValue > -1) Then
                Dim f As New FrmNuevaInfraestructura(cboSector.SelectedValue)
                f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                f.txtServicioNew.Select()
                f.CaptionLabels(0).Text = "Nuevo Piso"
                f.tipo = "P"

                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
                If Not IsNothing(f.Tag) Then
                    Dim c = CType(f.Tag, infraestructura)

                    infraestructuraBE.tipo = "P"
                    infraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
                    infraestructuraBE.idEstablecimiento = GEstableciento.IdEstablecimiento

                    listaInfraestructura = infraestructuraSA.getListaInfraestructura(infraestructuraBE)

                    cboPiso.DataSource = Nothing

                    cboPiso.ValueMember = "idInfraestructura"
                    cboPiso.DisplayMember = "nombre"
                    cboPiso.DataSource = listaInfraestructura
                    cboPiso.SelectedValue = c.idInfraestructura
                    'TREEVIEW

                    CrearNodosDelPadre(1)

                End If
            Else
                MessageBox.Show("Debe selecionar un sector")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class