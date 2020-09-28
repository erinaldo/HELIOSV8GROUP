Imports Helios.Cont.Business.Entity

Public Class UCVentaDescripcion

    Public Property FormVenta As FormVentaNueva
    Public Sub New(FormMaster As FormVentaNueva)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormVenta = FormMaster
    End Sub

End Class
