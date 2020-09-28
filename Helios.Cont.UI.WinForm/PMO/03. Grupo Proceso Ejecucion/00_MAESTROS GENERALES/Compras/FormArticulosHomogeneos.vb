Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Public Class FormArticulosHomogeneos

#Region "Attributes"

#End Region

#Region "Fields"

#End Region

#Region "Constructors"
    Public Sub New(lista As List(Of detalleitems))

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormatoGridAvanzado(GridProductos, True, False)
        GetProductosHomogeneos(lista)
    End Sub

#End Region

#Region "Methdos"
    Private Sub GetProductosHomogeneos(lista As List(Of detalleitems))
        Dim dt As New DataTable
        Dim detalleSA As New detalleitemsSA
        With dt.Columns
            .Add("iditem")
            .Add("descripcion")
            .Add("unidad")
            .Add("tipoexistencia")
        End With
        For Each i In lista
            dt.Rows.Add(i.codigodetalle, i.descripcionItem, i.unidad1, i.tipoExistencia)
        Next
        GridProductos.DataSource = dt
    End Sub

    Private Sub RoundButton22_Click(sender As Object, e As EventArgs) Handles RoundButton22.Click
        Tag = "Cancel"
        Close()
    End Sub

    Private Sub RoundButton21_Click(sender As Object, e As EventArgs) Handles RoundButton21.Click
        Tag = "Grabar"
        Close()
    End Sub
#End Region

#Region "Events"

#End Region

End Class