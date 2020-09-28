Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid.Grouping
Public Class frmModalBusquedaArticulosAlmacen

#Region "Attributes"
    Public Property lista As New List(Of tabladetalle)
    Public Property tablaSA As New tablaDetalleSA
    Public Property almacenSA As New almacenSA
    Public Property totalesAlmacenSA As New TotalesAlmacenSA
    Public Property articuloSA As New detalleitemsSA
    Dim r As Record
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridPequeño(dgvKardexVal, True)
        LoadCombos()
        ComboStatus()
        r = dgvKardexVal.Table.CurrentRecord
    End Sub
#End Region

#Region "Methods"
    Sub ComboStatus()
        Dim dt As New DataTable
        dt.Columns.Add("id", GetType(Integer))
        dt.Columns.Add("name")

        dt.Rows.Add(StatusArticulo.Activo, "Activo")
        dt.Rows.Add(StatusArticulo.Inactivo, "Inactivo")
        dt.Rows.Add(StatusArticulo.Retenido, "Retenido")
        dt.Rows.Add(StatusArticulo.Vencido, "Vencido")

        Dim ggcStyle As GridTableCellStyleInfo = dgvKardexVal.TableDescriptor.Columns("status").Appearance.AnyRecordFieldCell
        ggcStyle.CellType = "ComboBox"
        ggcStyle.DataSource = dt
        ggcStyle.ValueMember = "id"
        ggcStyle.DisplayMember = "name"
        ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive
    End Sub

    Private Sub LoadCombos()
        lista = New List(Of tabladetalle)
        lista = tablaSA.GetListaTablaDetalle(5, "1")
        lista.Add(New tabladetalle With {.idtabla = 5, .codigoDetalle = "00", .codigoDetalle2 = "00", .descripcion = "-Todos-"})

        cboTipoExistencia.DisplayMember = "descripcion"
        cboTipoExistencia.ValueMember = "codigoDetalle"
        cboTipoExistencia.DataSource = lista

        cboAlmacen.DisplayMember = "descripcionAlmacen"
        cboAlmacen.ValueMember = "idAlmacen"
        cboAlmacen.DataSource = almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
    End Sub
#End Region

#Region "Events"
    Private Sub GetInventarioValorizadoFiltro(intIdAlmacen As Integer)
        Dim totalesAlmacenBE As New List(Of totalesAlmacen)
        Dim dt As New DataTable("Lista de productos ")
        'Clasificicacion
        dt.Columns.Add(New DataColumn("Clasificacion", GetType(String)))
        dt.Columns.Add(New DataColumn("origenRecaudo", GetType(String)))
        dt.Columns.Add(New DataColumn("descripcion", GetType(String)))


        'lower case p
        dt.Columns.Add(New DataColumn("tipoExistencia", GetType(String)))
        dt.Columns.Add(New DataColumn("unidadMedida", GetType(String)))

        dt.Columns.Add(New DataColumn("cantidad", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeSoles", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("idItem", GetType(Integer)))

        dt.Columns.Add(New DataColumn("cantmax", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("cantmin", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("idmovimiento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("marca", GetType(String)))
        dt.Columns.Add(New DataColumn("presentacion", GetType(String)))
        dt.Columns.Add("status")

        For Each i As totalesAlmacen In totalesAlmacenSA.GetFilterArticulosStartWith(New totalesAlmacen With {.idAlmacen = intIdAlmacen,
                                                                                     .tipoExistencia = cboTipoExistencia.SelectedValue, .descripcion = txtBuscarDetalle.Text}).OrderBy(Function(o) o.descripcion).ToList

            Dim strGravado As String = IIf(i.origenRecaudo = 1, "Gravado", "No gravado")
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.Clasificicacion
            dr(1) = strGravado
            dr(2) = i.descripcion
            dr(3) = i.tipoExistencia
            dr(4) = i.unidadMedida
            dr(5) = i.cantidad
            dr(6) = i.importeSoles
            dr(7) = i.idItem

            If i.cantidadMaxima Is Nothing Then
                dr(8) = CDec(0.0)
            Else
                dr(8) = i.cantidadMaxima
            End If


            If i.cantidadMinima Is Nothing Then
                dr(9) = CDec(0.0)
            Else
                dr(9) = i.cantidadMinima
            End If
            dr(10) = i.idMovimiento
            dr(11) = i.Marca
            dr(12) = i.Presentacion
            dr(13) = i.status
            dt.Rows.Add(dr)
        Next
        dgvKardexVal.DataSource = dt
        dgvKardexVal.TableDescriptor.Columns("descripcion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        dgvKardexVal.TableDescriptor.Columns("descripcion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
    End Sub

    Private Sub txtBuscarDetalle_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscarDetalle.KeyDown
        LoadingAnimator.Wire(Me.dgvKardexVal.TableControl)
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If cboAlmacen.SelectedIndex > -1 Then
                Dim codAlmacen = cboAlmacen.SelectedValue
                If IsNumeric(codAlmacen) Then
                    If txtBuscarDetalle.Text.Trim.Length > 0 Then
                        GetInventarioValorizadoFiltro(codAlmacen)
                    End If
                End If
            End If
        End If
        LoadingAnimator.UnWire(Me.dgvKardexVal.TableControl)
    End Sub

    Private Sub dgvKardexVal_TableControlCellDoubleClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvKardexVal.TableControlCellDoubleClick
        r = dgvKardexVal.Table.CurrentRecord
        If Not IsNothing(r) Then
            '     Dim obj = articuloSA.InvocarProductoID(CInt(r.GetValue("idItem")))
            Dim obj As New totalesAlmacen With {.idItem = CInt(r.GetValue("idItem"))}
            Tag = Nothing
            If Not IsNothing(obj) Then
                Tag = obj
            End If
            Close()
        End If
    End Sub

    Private Sub frmModalBusquedaArticulosAlmacen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtBuscarDetalle.Select()
        txtBuscarDetalle.Focus()
    End Sub
#End Region

End Class