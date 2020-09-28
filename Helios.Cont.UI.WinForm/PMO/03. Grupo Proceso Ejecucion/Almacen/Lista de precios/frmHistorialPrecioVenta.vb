Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Public Class frmHistorialPrecioVenta
    Inherits frmMaster

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

    End Sub

    Private Function getParentTablePrecioVentaPorProducto(intIdAlmacen As Integer, intIdItem As Integer, strTipoIVA As String) As DataTable
        Dim objLista As New List(Of listadoPrecios)
        Dim listadoSA As New ListadoPrecioSA
        Dim objTablaSA As New tablaDetalleSA
        Dim objTabla As New tabladetalle
        Dim productoSA As New detalleitemsSA
        Dim producto As New detalleitems

        Dim dt As New DataTable("Producto, PV. ")

        dt.Columns.Add(New DataColumn("fecha", GetType(String)))
        dt.Columns.Add(New DataColumn("vc", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("porcUtilidad", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("impUti1", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("vv", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("igv", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precVenta", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("vc2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("porcUtilidad2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("impUti2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("vv2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("igv2", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precVenta2", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("vc3", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("porcUtilidad3", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("impUti3", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("vv3", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("igv3", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("precVenta3", GetType(Decimal)))
      

        Dim str As String

        objLista = listadoSA.ObtenerPrecioPorItemSL(intIdAlmacen, intIdItem, strtipoIVA)

        For Each i As listadoPrecios In objLista

            Dim dr As DataRow = dt.NewRow()
            Str = Nothing

            str = CDate(i.fecha).ToString("dd-MMM-yyyy hh:mm tt ")
            dr(0) = str
            dr(1) = 0
            dr(2) = i.porcUtimenor
            dr(3) = i.montoUtimenor
            dr(4) = i.vvmenor
            dr(5) = i.igvmenor
            dr(6) = i.pvmenor

            dr(7) = 0
            dr(8) = i.porcUtimayor
            dr(9) = i.montoUtimayor
            dr(10) = i.vvmayor
            dr(11) = i.igvmayor
            dr(12) = i.pvmayor

            dr(13) = 0
            dr(14) = i.porcUtigranmayor
            dr(15) = i.montoUtigranmayor
            dr(16) = i.vvgranmayor
            dr(17) = i.igvgranmayor
            dr(18) = i.pvgranmayor
         
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    Public Sub ObtenerListaPorAlmacenPorProducto(intIdAlmacen As Integer, strIditem As Integer, strTipoIVA As String)
        Dim parentTable As DataTable = getParentTablePrecioVentaPorProducto(intIdAlmacen, strIditem, strTipoIVA)
        Me.dgvMenor.DataSource = parentTable
        dgvMenor.TableDescriptor.Relations.Clear()
        dgvMenor.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
        dgvMenor.TableOptions.ListBoxSelectionMode = SelectionMode.One
        dgvMenor.Appearance.AnyRecordFieldCell.Enabled = False
        dgvMenor.GroupDropPanel.Visible = True
        dgvMenor.TableDescriptor.GroupedColumns.Clear()
        '   dgvCompra.TableDescriptor.GroupedColumns.Add("descripcion")
    End Sub

    Private Sub frmHistorialPrecioVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class