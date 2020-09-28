Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class FormClasificacionItem

#Region "Atributos"

    Dim listaCategoriasItem As New List(Of item)

#End Region

#Region "Constructor"

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        FormatoGridBlack2(dgvDetalles, False)
        Columnas()
        Loadcombos()
        ' Add any initialization after the InitializeComponent() call.
        dgvDetalles.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
    End Sub
#End Region

#Region "Metodos"


    Public Sub listaCamposModelo(idClas As Integer, idPadre As Integer)


        dgvDetalles.Table.Records.DeleteAll()


        Dim caracteristicasSA As New caracteristicaItemSA

        Dim item As New caracteristicaItem
        item.idPadre = idPadre
        item.idSubClasificacion = idClas
        item.tipo = "DET"

        Dim consulta = caracteristicasSA.listaCamposModelo(item)
        For Each i In consulta

            dgvDetalles.Table.AddNewRecord.SetCurrent()
            dgvDetalles.Table.AddNewRecord.BeginEdit()
            dgvDetalles.Table.CurrentRecord.SetValue("idCaracteristica", i.idCaracteristica)
            dgvDetalles.Table.CurrentRecord.SetValue("campo", i.campo)
            dgvDetalles.Table.CurrentRecord.SetValue("descripcion", i.descripcion)
            dgvDetalles.Table.AddNewRecord.EndEdit()

        Next
    End Sub


    Public Sub GrabarDetalle()

        Try

            Dim caracteristicaItemSA As New caracteristicaItemSA
            Dim lista As New List(Of caracteristicaItem)
            Dim objeto As caracteristicaItem

            For Each r As Record In dgvDetalles.Table.Records
                objeto = New caracteristicaItem

                objeto.idSubClasificacion = txtCategoria.Tag
                objeto.idPadre = txtModelo.Tag
                objeto.tipo = "DET"
                objeto.campo = r.GetValue("campo")
                objeto.descripcion = r.GetValue("descripcion")
                lista.Add(objeto)
            Next

            caracteristicaItemSA.GuardarcaracteristicaItem(lista)
            MessageBox.Show("Se Grabo Correctamente")
            Close()
        Catch ex As Exception
            MessageBox.Show("No se Pudo Guardar")
        End Try



    End Sub


    Public Sub Loadcombos()
        'CMBClasificacion()
        ListaCateriasItem()
    End Sub


    Public Sub ListaCateriasItem()
        Dim categoriaSA As New itemSA
        ' categoriaSA.GetListaPadre()
        listaCategoriasItem = New List(Of item)
        listaCategoriasItem = categoriaSA.GetListaCategoriasItem(New item With
                                                          {
                                                          .idEmpresa = Gempresas.IdEmpresaRuc
                                                          })
    End Sub


    'Dim listaCategoria As New List(Of item)
    'Private Sub CMBClasificacion()
    '    Dim categoriaSA As New itemSA
    '    ' categoriaSA.GetListaPadre()
    '    listaCategoria = New List(Of item)
    '    listaCategoria = categoriaSA.GetListaItemsPorTipo(New item With
    '                                                      {
    '                                                      .idEmpresa = Gempresas.IdEmpresaRuc,
    '                                                      .tipo = TipoGrupoArticulo.CategoriaGeneral
    '                                                      })
    'End Sub


    Dim listaModelos As New List(Of caracteristicaItem)
    Private Sub CMBgrupoClasificacion(idSubClasificacion As Integer)
        Dim caracteristicaItemSA As New caracteristicaItemSA
        ' categoriaSA.GetListaPadre()
        listaModelos = New List(Of caracteristicaItem)
        listaModelos = caracteristicaItemSA.listaModelos(New caracteristicaItem With
                                                          {
                                                          .tipo = "MO",
                                                          .idSubClasificacion = idSubClasificacion
                                                          })

    End Sub

    Public Sub Columnas()
        Dim dt As New DataTable

        dt.Columns.Add("idCaracteristica")
        dt.Columns.Add("campo")
        dt.Columns.Add("descripcion")
        dgvDetalles.DataSource = dt

    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        'dgvDetalles.Table.AddNewRecord.SetCurrent()
        'dgvDetalles.Table.AddNewRecord.BeginEdit()
        'dgvDetalles.Table.CurrentRecord.SetValue("idCaracteristica", 0)
        'dgvDetalles.Table.CurrentRecord.SetValue("campo", "")
        'dgvDetalles.Table.CurrentRecord.SetValue("descripcion", "")

        'dgvDetalles.Table.AddNewRecord.EndEdit()


        Try



            If Not txtCategoria.Tag Is Nothing Then

                If Not txtModelo.Tag Is Nothing Then

                    Dim datos As List(Of item) = item.Instance()
                    datos.Clear()

                    Dim f As New FormRegistroModeloDetalle
                    'f.txtDescripcion.Text = txtModelo.Text
                    f.lbliDSubClasificacion.Text = txtCategoria.Tag
                    f.lblIdPadre.Text = txtModelo.Tag
                    'txtModelo.Clear()
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()

                    'CMBgrupoClasificacion(txtCategoria.Tag)
                    If datos.Count > 0 Then
                        'txtModelo.Text = datos(0).descripcion
                        'txtModelo.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        'txtModelo.Tag = CInt(datos(0).idItem)

                        listaCamposModelo(txtCategoria.Tag, txtModelo.Tag)
                    End If
                Else
                    MessageBox.Show("Seleccione Un Modelo")

                End If
            Else
                    MessageBox.Show("Seleccione Una SubClasificacion")
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

        Try

            If Not txtCategoria.Tag Is Nothing Then

                Dim datos As List(Of item) = item.Instance()
                datos.Clear()

                Dim f As New FormRegistroModelo
                f.txtDescripcion.Text = txtModelo.Text
                f.lbliDSubClasificacion.Text = txtCategoria.Tag
                txtModelo.Clear()
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()

                CMBgrupoClasificacion(txtCategoria.Tag)
                If datos.Count > 0 Then
                    txtModelo.Text = datos(0).descripcion
                    txtModelo.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                    txtModelo.Tag = CInt(datos(0).idItem)
                End If

            Else
                MessageBox.Show("Seleccione Una SubClasificacion")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub pcModelo_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcModelo.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvModelo.SelectedItems.Count > 0 Then
                txtModelo.Text = lsvModelo.Text
                txtModelo.Tag = lsvModelo.SelectedValue
                'txtSubCategoria.Clear()
                txtModelo.ForeColor = Color.White  'Color.FromKnownColor(KnownColor.HotTrack)
                ' Label43.Text = "0 items"
                '  Productoshijos()

                listaCamposModelo(txtCategoria.Tag, txtModelo.Tag)

            End If
        End If
        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtModelo.Focus()
        End If
    End Sub

    Private Sub lsvModelo_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvModelo.MouseDoubleClick
        Me.pcModelo.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub txtModelo_TextChanged(sender As Object, e As EventArgs) Handles txtModelo.TextChanged
        txtModelo.ForeColor = Color.White
        txtModelo.Tag = Nothing
    End Sub

    Private Sub txtModelo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtModelo.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        Else
            Me.pcModelo.Font = New Font("Segoe UI", 8)
            Me.pcModelo.Size = New Size(241, 110)
            Me.pcModelo.ParentControl = Me.txtModelo
            Me.pcModelo.ShowPopup(Point.Empty)
            'Dim consulta = (From n In listaModelos
            '                Where n.descripcion.StartsWith(txtModelo.Text)).ToList


            Dim consulta = (From n In listaCategoriasItem
                            Where n.descripcion.StartsWith(txtModelo.Text) And n.tipo = TipoGrupoArticulo.Presentacion).ToList


            lsvModelo.DataSource = consulta
            lsvModelo.DisplayMember = "descripcion"
            lsvModelo.ValueMember = "idItem"
            'e.Handled = True
        End If

        '  If Not Me.pcLikeCategoria.IsShowing() Then

        '   End If

        '    If Not Me.pcLikeCategoria.IsShowing() Then
        If e.KeyCode = Keys.Down Then
            Me.pcModelo.Font = New Font("Segoe UI", 8)
            Me.pcModelo.Size = New Size(241, 110)
            Me.pcModelo.ParentControl = Me.txtModelo
            Me.pcModelo.ShowPopup(Point.Empty)
            lsvModelo.Focus()
        End If
        '   End If

        ' e.SuppressKeyPress = True
        If e.KeyCode = Keys.Escape Then
            If Me.pcModelo.IsShowing() Then
                Me.pcModelo.HidePopup(PopupCloseType.Canceled)
            End If
        End If
    End Sub

    Private Sub lsvCategoria_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvCategoria.MouseDoubleClick
        Me.pcLikeCategoria.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub pcLikeCategoria_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcLikeCategoria.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvCategoria.SelectedItems.Count > 0 Then
                txtCategoria.Text = lsvCategoria.Text
                txtCategoria.Tag = lsvCategoria.SelectedValue
                txtModelo.Clear()
                txtCategoria.ForeColor = Color.White  'Color.FromKnownColor(KnownColor.HotTrack)



                CMBgrupoClasificacion(lsvCategoria.SelectedValue)

                ' Label43.Text = "0 items"
                '  Productoshijos()
            End If
        End If
        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtCategoria.Focus()
        End If
    End Sub

    Private Sub txtCategoria_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCategoria.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        Else

            'listaCategoriasItem

            Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.pcLikeCategoria.Size = New Size(241, 110)
            Me.pcLikeCategoria.ParentControl = Me.txtCategoria
            Me.pcLikeCategoria.ShowPopup(Point.Empty)
            Dim consulta = (From n In listaCategoriasItem
                            Where n.descripcion.StartsWith(txtCategoria.Text) And n.tipo = TipoGrupoArticulo.CategoriaGeneral).ToList

            If consulta.Count > 0 Then
                txtModelo.Enabled = True
            End If


            lsvCategoria.DataSource = consulta
            lsvCategoria.DisplayMember = "descripcion"
            lsvCategoria.ValueMember = "idItem"
            'e.Handled = True
        End If

        '  If Not Me.pcLikeCategoria.IsShowing() Then

        '   End If

        '    If Not Me.pcLikeCategoria.IsShowing() Then
        If e.KeyCode = Keys.Down Then
            Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.pcLikeCategoria.Size = New Size(241, 110)
            Me.pcLikeCategoria.ParentControl = Me.txtCategoria
            Me.pcLikeCategoria.ShowPopup(Point.Empty)
            lsvCategoria.Focus()
        End If
        '   End If

        ' e.SuppressKeyPress = True
        If e.KeyCode = Keys.Escape Then
            If Me.pcLikeCategoria.IsShowing() Then
                Me.pcLikeCategoria.HidePopup(PopupCloseType.Canceled)
            End If
        End If
    End Sub

    Private Sub txtCategoria_TextChanged(sender As Object, e As EventArgs) Handles txtCategoria.TextChanged

    End Sub

    Private Sub btOperacion_Click(sender As Object, e As EventArgs) 
        GrabarDetalle()
    End Sub
#End Region

End Class