Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Public Class frmCierreInventario
    Inherits frmMaster

    Public Sub New(intalmacen As Integer)

        ' This call is required by the designer.
        InitializeComponent()
        CargarAlmacenes()
        ' Add any initialization after the InitializeComponent() call.
        ResumenProductos()
        Me.WindowState = FormWindowState.Maximized
        txtfecha.Value = Date.Now
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        CargarAlmacenes()
        ResumenProductos()
        Me.WindowState = FormWindowState.Maximized
        txtfecha.Value = Date.Now
    End Sub

#Region "Métodos"
    Private Sub CargarAlmacenes()
        Dim almacenSA As New almacenSA
        Dim tablaSA As New tablaDetalleSA

        lstAlmacen.DisplayMember = "descripcionAlmacen"
        lstAlmacen.ValueMember = "idAlmacen"
        lstAlmacen.DataSource = almacenSA.GetListar_almacenes(GEstableciento.IdEstablecimiento)

    End Sub

    Public Sub GrabarLista()
        Dim cierreSA As New CierreInventarioSA
        Dim cierre As New cierreinventario
        Dim lista As New List(Of cierreinventario)
        Try
            For Each r As Record In dgvCompra.Table.Records
                cierre = New cierreinventario
                cierre.idEmpresa = Gempresas.IdEmpresaRuc
                cierre.idCentroCosto = GEstableciento.IdEstablecimiento
                cierre.periodo = PeriodoGeneral.ToString.Replace("/", "")
                cierre.idAlmacen = r.GetValue("idAlmacen")
                cierre.idItem = r.GetValue("idItem")
                cierre.anio = txtfecha.Value.Year
                cierre.mes = txtfecha.Value.Month
                cierre.dia = txtfecha.Value.Day
                cierre.cantidad = r.GetValue("cantidad")
                cierre.importe = r.GetValue("importe")
                cierre.importeUS = r.GetValue("importeME")
                cierre.unidad = r.GetValue("unidad")
                cierre.usuarioModificacion = usuario.IDUsuario
                cierre.fechaModificacion = DateTime.Now
                lista.Add(cierre)
            Next

            cierreSA.CerrarInventario(lista)
            lblEstado.Text = "Inventario Cerrado"
            Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ResumenProductos()
        Dim TotalesAlmacenSA As New TotalesAlmacenSA
        Dim InventarioSA As New inventarioMovimientoSA


        Dim dt As New DataTable("Cierre de inv. ")
        dt.Columns.Add(New DataColumn("idAlmacen", GetType(Integer)))
        dt.Columns.Add(New DataColumn("almacen", GetType(String)))
        dt.Columns.Add(New DataColumn("idItem", GetType(String)))
        dt.Columns.Add(New DataColumn("gravado", GetType(String)))

        dt.Columns.Add(New DataColumn("Descripcion", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoExistencia", GetType(String)))
        dt.Columns.Add(New DataColumn("unidad", GetType(String)))

        dt.Columns.Add(New DataColumn("cantidad", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importe", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeME", GetType(Decimal)))

        'For Each i In InventarioSA.MostrarCierreInvPorPeriodo(New InventarioMovimiento With {.fecha = New Date(AnioGeneral, MesGeneral, 1), .idEmpresa = Gempresas.IdEmpresaRuc})

        '    Dim strGravado As String = IIf(i.destinoGravadoItem = 1, "Gravado", "No gravado")
        '    Dim dr As DataRow = dt.NewRow()
        '    dr(0) = i.idAlmacen
        '    dr(1) = i.NombreAlmacen
        '    dr(2) = i.idItem
        '    dr(3) = strGravado
        '    dr(4) = i.descripcion
        '    dr(5) = i.tipoExistencia
        '    dr(6) = i.unidad
        '    dr(7) = i.cantidad
        '    dr(8) = i.monto
        '    dr(9) = i.montoUSD
        '    dt.Rows.Add(dr)
        'Next

        For Each i As totalesAlmacen In TotalesAlmacenSA.GetProductosXempresa(New totalesAlmacen With {.idEmpresa = Gempresas.IdEmpresaRuc})
            Dim strGravado As String = IIf(i.origenRecaudo = 1, "Gravado", "No gravado")
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.idAlmacen
            dr(1) = i.NomAlmacen
            dr(2) = i.idItem
            dr(3) = strGravado
            dr(4) = i.descripcion
            dr(5) = i.tipoExistencia
            dr(6) = i.unidadMedida
            dr(7) = i.cantidad
            dr(8) = i.importeSoles
            dr(9) = i.importeDolares
            dt.Rows.Add(dr)
        Next
        dgvCompra.DataSource = dt
        dgvCompra.TableOptions.ListBoxSelectionMode = SelectionMode.One
    End Sub
#End Region

    Private Sub frmCierreInventario_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmCierreInventario_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub pcAlmacen_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcAlmacen.CloseUp
        'Me.Cursor = Cursors.WaitCursor
        'If e.PopupCloseType = PopupCloseType.Done Then
        '    If lstAlmacen.SelectedItems.Count > 0 Then
        '        Me.txtAlmacen.Tag = lstAlmacen.SelectedValue
        '        txtAlmacen.Text = lstAlmacen.Text
        '        'ResumenProductos()
        '    End If
        'End If
        '' Set focus back to textbox.
        'If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
        '    Me.txtAlmacen.Focus()
        'End If
        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs)
        'pcAlmacen.Font = New Font("Segoe UI", 8)
        'pcAlmacen.Size = New Size(260, 110)
        'Me.pcAlmacen.ParentControl = Me.txtAlmacen
        'Me.pcAlmacen.ShowPopup(Point.Empty)
    End Sub

    Private Sub lstAlmacen_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstAlmacen.MouseDoubleClick
        Me.pcAlmacen.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub btnCard_Click(sender As Object, e As EventArgs) Handles btnCard.Click
        Me.Cursor = Cursors.WaitCursor
        GrabarLista()
        Me.Cursor = Cursors.Arrow
    End Sub
End Class