Imports Helios.Cont.Business.Entity
Imports Helios.General
Public Class UCRankingProductos

#Region "Attributes"

#End Region

#Region "Constructors"
    Public Sub New(ListaVentas As List(Of documentoventaAbarrotes))

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridBlack(GridRentabilidad, True)
        GetRankingProductos(ListaVentas)
    End Sub

#End Region

#Region "Methods"
    Private Sub GetRankingProductos(listaVentas As List(Of documentoventaAbarrotes))
        Dim dt As New DataTable
        dt.Columns.Add("Codigo")
        dt.Columns.Add("Producto")
        dt.Columns.Add("Afectacion")
        dt.Columns.Add("tipoexistencia")
        dt.Columns.Add("unidad")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("totalventa")

        For Each i In listaVentas
            For Each det In i.documentoventaAbarrotesDet.OrderByDescending(Function(o) o.importeMN).ToList
                dt.Rows.Add(
                    det.CustomProducto.codigo,
                    det.CustomProducto.descripcionItem,
                    det.CustomProducto.origenProducto,
                    det.CustomProducto.tipoExistencia,
                    det.CustomProducto.unidad1, det.monto1.GetValueOrDefault, det.importeMN.GetValueOrDefault.ToString("N2"))
            Next
        Next
        GridRentabilidad.DataSource = dt
    End Sub
#End Region

#Region "Events"

#End Region

End Class
