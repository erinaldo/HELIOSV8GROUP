Imports Helios.Cont.Business.Entity
Imports Helios.General.Constantes

Interface IForm

    Sub EnviarProducto(ByVal productoBE As totalesAlmacen)

End Interface

Interface IListaInventario
    Sub EnviarListaArticulos(ByVal lista As List(Of totalesAlmacen))
End Interface

Interface IForm2
    Sub EnviarDocumento(ByVal productoBE As documentoventaAbarrotes)
End Interface


Interface IListaDocumento
    Sub EnviarListaDocumento(ByVal lista As List(Of documentoventaAbarrotes))
End Interface

Interface IBusquedaAvanzadaProductos
    Sub BusquedaAvanzadaProductos(be As BusquedaAvanzadaProductos)
End Interface

Interface IOferta
    Sub RecuperarOferta(be As oferta)
End Interface

Interface IConfirmarCompraRapida
    Sub ConfirmaTransaccion(Confirmado As Boolean)
End Interface

Interface ICommitOperacion
    Sub Commit(Confirmado As Boolean)
End Interface

Interface ICommitOperacionMKT
    Sub Commit(Confirmado As Boolean, idDocumento As Integer)
End Interface

Interface ICommitOperacionMKTIenda
    Sub Commit(Confirmado As Boolean, idDocumento As Integer, NombreTienda As String, FormaPago As String)
End Interface

Interface IListaServicio
    Sub EnviarListaServicio(ByVal lista As List(Of totalesAlmacen))
End Interface


