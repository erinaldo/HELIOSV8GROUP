Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.GroupingGridExcelConverter
Imports Syncfusion.Windows.Forms

Public Class FormRegistroDetalleLote

    Public Property listaCaracteristicas As New List(Of caracteristicaItem)

#Region "Constructor"

    Sub New(Stock As Integer, idlote As Integer, idSubClas As Integer, idCaracteristica As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        FormatoGridBlack(GridProductos, False)
        'ColumnasLotes()
        'CMBgrupoClasificacion(idSubClas)
        lblCategoria.Text = idSubClas
        lblidlote.Text = idlote
        Label4.Text = Stock

        listaCamposModelo(idSubClas, idCaracteristica)


        ' Add any initialization after the InitializeComponent() call.
        'detalleLotes(Stock)
    End Sub

#End Region

#Region "Metodos"

    Public Sub listaCamposModelo(idClas As Integer, idPadre As Integer)


        GridProductos.Table.Records.DeleteAll()


        Dim caracteristicasSA As New caracteristicaItemSA

        Dim item As New caracteristicaItem
        item.idPadre = idPadre
        item.idSubClasificacion = idClas
        item.tipo = "DET"

        Dim consulta = caracteristicasSA.listaCamposModelo(item)


        listaCaracteristicas = consulta


        Dim dt As New DataTable("Lista de productos ")

        dt.Columns.Add("conteo")
        dt.Columns.Add("idLote")
        dt.Columns.Add("idDetalleLote")
        For Each i In consulta

            'dgvDetalles.Table.AddNewRecord.SetCurrent()
            'dgvDetalles.Table.AddNewRecord.BeginEdit()
            'dgvDetalles.Table.CurrentRecord.SetValue("idCaracteristica", i.idCaracteristica)
            'dgvDetalles.Table.CurrentRecord.SetValue("campo", i.campo)
            'dgvDetalles.Table.CurrentRecord.SetValue("descripcion", i.descripcion)
            'dgvDetalles.Table.AddNewRecord.EndEdit()
            dt.Columns.Add(i.campo)

        Next
        GridProductos.DataSource = dt


        detalleLotes(Label4.Text)

        'For Each i As totalesAlmacen In listaInventario 'TotalesAlmacenSA.GetInventarioGeneral(be).Where(Function(o) o.cantidad > 0).OrderBy(Function(o) o.descripcion).ToList
        '        Dim strGravado As String = IIf(i.origenRecaudo = 1, "Gravado", "No gravado")
        '        Dim dr As DataRow = dt.NewRow()
        '        dr(0) = i.Clasificicacion
        '        dr(1) = strGravado
        '        dr(2) = i.descripcion
        '        dr(3) = i.tipoExistencia
        '        dr(4) = i.unidadMedida
        '        dr(5) = i.cantidad
        '        dr(6) = i.importeSoles
        '        dr(7) = i.idItem

        '        If i.cantidadMaxima Is Nothing Then
        '            dr(8) = CDec(0.0)
        '        Else
        '            dr(8) = i.cantidadMaxima
        '        End If


        '        If i.cantidadMinima Is Nothing Then
        '            dr(9) = CDec(0.0)
        '        Else
        '            dr(9) = i.cantidadMinima
        '        End If
        '        dr(10) = i.idMovimiento
        '        dr(11) = i.Marca
        '        dr(12) = i.Presentacion
        '        dr(13) = i.status
        '        If i.fechaLote.HasValue Then
        '            dr(14) = i.fechaLote.Value.ToString("dd-MM-yyyy")
        '        End If

        '        dr(15) = i.NroLote
        '        dr(16) = i.codigoLote

        '        Dim total = i.importeSoles.GetValueOrDefault * 0.18
        '        total = FormatNumber(i.importeSoles.GetValueOrDefault + total, 2)
        '        If (i.origenRecaudo = 1) Then
        '            dr(17) = total.ToString("N2")
        '        Else
        '            dr(17) = "-"
        '        End If

        '        If (i.origenRecaudo = 1) Then
        '            dr(18) = total.ToString("N2")
        '        Else
        '            dr(18) = i.importeSoles
        '        End If
        '        dr(19) = i.CantDetalle
        '        dr(20) = i.idSubClasificacion
        '        dt.Rows.Add(dr)
        '    Next




    End Sub

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


    Public Sub GuardarLoteDetalle()
        Try


            Dim lotedetsa As New LoteDetalleSA
            Dim lista As New List(Of LoteDetalle)
            Dim objeto As LoteDetalle
            Dim lote As New recursoCostoLote




            For Each r As Record In GridProductos.Table.Records



                For Each j In listaCaracteristicas
                    objeto = New LoteDetalle
                    objeto.codigoLote = CInt(r.GetValue("idLote"))
                    objeto.numeracion = CInt(r.GetValue("conteo"))
                    objeto.campo = j.campo
                    objeto.descripcion = r.GetValue(j.campo)
                    objeto.estado = "PN"
                    lista.Add(objeto)
                Next


                'objeto.codigoLote = CInt(r.GetValue("idLote"))
                'objeto.marca = r.GetValue("marca")
                'objeto.codigo = r.GetValue("codigo")
                'objeto.color = r.GetValue("color")
                'objeto.modelo = r.GetValue("modelo")
                'objeto.año = CInt(r.GetValue("año"))
                'objeto.estado = "PN"
                'lista.Add(objeto)
            Next

            lote.codigoLote = lblidlote.Text
            lote.idCaracteristica = txtModelo.Tag

            lotedetsa.GuardarLoteDetalle(lote, lista)
            MessageBox.Show("Se Grabo Correctamente")
            Close()
        Catch ex As Exception
            MessageBox.Show("Debe Ingresar Todas las Caracteristicas Del Producto")
        End Try
    End Sub

    Public Sub detalleLotes(Cantidad As Integer)

        Dim conteo = 0
        For i As Integer = 1 To Cantidad

            conteo += 1
            GridProductos.Table.AddNewRecord.SetCurrent()
            GridProductos.Table.AddNewRecord.BeginEdit()
            GridProductos.Table.CurrentRecord.SetValue("conteo", conteo)
            GridProductos.Table.CurrentRecord.SetValue("idLote", lblidlote.Text)
            GridProductos.Table.CurrentRecord.SetValue("idDetalleLote", 0)
            'GridProductos.Table.CurrentRecord.SetValue("marca", "")
            'GridProductos.Table.CurrentRecord.SetValue("color", "")
            'GridProductos.Table.CurrentRecord.SetValue("modelo", "")
            'GridProductos.Table.CurrentRecord.SetValue("codigo", "")
            'GridProductos.Table.CurrentRecord.SetValue("año", "")
            GridProductos.Table.AddNewRecord.EndEdit()

        Next


        'GridProductos.TableDescriptor.Columns("conteo").Width = 0
        GridProductos.TableDescriptor.Columns("idLote").Width = 0
        GridProductos.TableDescriptor.Columns("idDetalleLote").Width = 0




    End Sub



    Public Sub ColumnasLotes()
        Dim dt As New DataTable
        dt.Columns.Add("conteo")
        dt.Columns.Add("idLote")
        dt.Columns.Add("idDetalleLote")
        dt.Columns.Add("marca")
        dt.Columns.Add("color")
        dt.Columns.Add("modelo")
        dt.Columns.Add("codigo")
        dt.Columns.Add("año")
        GridProductos.DataSource = dt

    End Sub

#End Region


    Private Sub FormRegistroDetalleLote_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click

        GridProductos.TableControl.CurrentCell.EndEdit()
        GridProductos.TableControl.Table.TableDirty = True
        GridProductos.TableControl.Table.EndEdit()

        GuardarLoteDetalle()
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
            Dim consulta = (From n In listaModelos
                            Where n.descripcion.StartsWith(txtModelo.Text)).ToList

            lsvModelo.DataSource = consulta
            lsvModelo.DisplayMember = "descripcion"
            lsvModelo.ValueMember = "idCaracteristica"
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

    Private Sub pcModelo_CloseUp(sender As Object, e As Syncfusion.Windows.Forms.PopupClosedEventArgs) Handles pcModelo.CloseUp

        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvModelo.SelectedItems.Count > 0 Then
                txtModelo.Text = lsvModelo.Text
                txtModelo.Tag = lsvModelo.SelectedValue
                'txtSubCategoria.Clear()
                txtModelo.ForeColor = Color.White   'Color.FromKnownColor(KnownColor.HotTrack)
                ' Label43.Text = "0 items"
                '  Productoshijos()

                listaCamposModelo(lblCategoria.Text, lsvModelo.SelectedValue)

            End If
        End If
        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtModelo.Focus()
        End If

    End Sub

    Private Sub lsvModelo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvModelo.SelectedIndexChanged

    End Sub

    Private Sub lsvModelo_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvModelo.MouseDoubleClick
        Me.pcModelo.HidePopup(PopupCloseType.Done)
    End Sub
End Class