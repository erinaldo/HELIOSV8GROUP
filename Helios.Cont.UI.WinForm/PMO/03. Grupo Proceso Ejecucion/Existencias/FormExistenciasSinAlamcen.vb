Imports Helios.Cont.Business.Entity
Imports Helios.Cont.Presentation.WinForm
Imports Helios.Cont.WCFService.ServiceAccess
Imports Syncfusion.Grouping

Public Class FormExistenciasSinAlamcen
    Implements IConfirmarCompraRapida

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        General.FormatoGridAvanzado(GridTotales, True, False, 11.0F)
        GetProducts()
    End Sub

    Public Sub ConfirmaTransaccion(Confirmado As Boolean) Implements IConfirmarCompraRapida.ConfirmaTransaccion
        If Confirmado = True Then
            If GridTotales.Table.CurrentRecord IsNot Nothing Then
                GridTotales.Table.CurrentRecord.Delete()
                GridTotales.Refresh()
            End If
        End If
    End Sub


#End Region

#Region "Methods"
    Private Sub GetProducts()
        Dim itemSA As New detalleitemsSA

        Dim products = itemSA.GetArticulosSinAlmacen(General.Gempresas.IdEmpresaRuc, 1)
        Dim dt As New DataTable
        dt.Columns.Add("idItem")
        dt.Columns.Add("destino")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("unidad")
        dt.Columns.Add("tipo")
        dt.Columns.Add("pvmenor")
        dt.Columns.Add("pvmenorme")
        dt.Columns.Add("pvmayor")
        dt.Columns.Add("pvmayorme")
        dt.Columns.Add("pvGmayor")
        dt.Columns.Add("pvGmayorme")

        For Each i In products
            dt.Rows.Add(
                i.codigodetalle,
                i.origenProducto,
                i.descripcionItem,
                i.unidad1,
                i.tipoExistencia,
                i.precioMenor.GetValueOrDefault, 0,
                i.precioMayor.GetValueOrDefault, 0,
            i.precioGranMayor.GetValueOrDefault, 0)
        Next
        GridTotales.DataSource = dt
    End Sub

    Private Sub RoundButton21_Click(sender As Object, e As EventArgs) Handles RoundButton21.Click
        Dim r As Record = GridTotales.Table.CurrentRecord
        If r IsNot Nothing Then
            Dim f As New FormCompraRapida(New detalleitems With
                                              {
                                              .codigodetalle = r.GetValue("idItem"),
                                              .descripcionItem = r.GetValue("descripcion")
                                              })
            f.StartPosition = FormStartPosition.CenterScreen
            f.ShowDialog(Me)
            GetProducts()
        End If
    End Sub
#End Region

End Class