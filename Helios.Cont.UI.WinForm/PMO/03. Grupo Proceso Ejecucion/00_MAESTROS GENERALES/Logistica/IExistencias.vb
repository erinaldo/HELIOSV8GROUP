Imports Helios.Cont.Business.Entity

Interface IExistencias
    Sub EnviarItem(ByVal productoBE As detalleitems)
End Interface

Interface IServicio
    Sub EnviarServicio(ByVal ServicioBE As servicio)
End Interface

Interface IPrecio
    Sub CambiarPrecio(ByVal precio As configuracionPrecioProducto)
End Interface

Interface IProductoConsignado
    Sub EnviarConsigna(ByVal be As totalesAlmacen)
End Interface

Interface IProductoCompra
    Sub EnviarProducto(ByVal be As documentocompradetalle)
End Interface

