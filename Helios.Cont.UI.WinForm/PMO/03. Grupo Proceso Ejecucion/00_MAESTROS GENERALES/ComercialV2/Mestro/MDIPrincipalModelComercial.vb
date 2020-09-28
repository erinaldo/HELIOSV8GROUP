Public Class MDIPrincipalModelComercial

    Property Usuario As Integer
    Property Modulos As List(Of Modulo)

    Public Sub New()
        ModulosComercial()
    End Sub

    Private Sub ModulosComercial()
        Modulos = New List(Of Modulo)
        'CATEGORIAS PADRES
        Modulos.Add(New Modulo With {.IDModulo = 1, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "Pedidos", .IDModuloPadre = Nothing, .Orden = 1})
        Modulos.Add(New Modulo With {.IDModulo = 2, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "Cotizaciones", .IDModuloPadre = Nothing, .Orden = 2})
        Modulos.Add(New Modulo With {.IDModulo = 3, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "Ventas", .IDModuloPadre = Nothing, .Orden = 3})
        Modulos.Add(New Modulo With {.IDModulo = 4, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "Cobros", .IDModuloPadre = Nothing, .Orden = 4})
        Modulos.Add(New Modulo With {.IDModulo = 5, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "Entregas", .IDModuloPadre = Nothing, .Orden = 5})
        Modulos.Add(New Modulo With {.IDModulo = 6, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "Informes", .IDModuloPadre = Nothing, .Orden = 6})


        'Nodos secundarios
        ' Caja y Bancos {2}
        Modulos.Add(New Modulo With {.IDModulo = 10, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Pedidos",
                                    .IDModuloPadre = Nothing, .IDCategoria = 1, .Orden = 1, .Formulario = "frmPedidosMaestro"})
        Modulos.Add(New Modulo With {.IDModulo = 11, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Pedidos Reservados",
                                   .IDModuloPadre = Nothing, .IDCategoria = 1, .Orden = 2, .Formulario = ""})
        Modulos.Add(New Modulo With {.IDModulo = 12, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Cotizaciones",
                                   .IDModuloPadre = Nothing, .IDCategoria = 2, .Orden = 1, .Formulario = "frmcotizacionMaestro"})
        Modulos.Add(New Modulo With {.IDModulo = 13, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Seguimiento",
                                   .IDModuloPadre = Nothing, .IDCategoria = 2, .Orden = 2, .Formulario = ""})

        ' Ventas {3}
        Modulos.Add(New Modulo With {.IDModulo = 14, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Registro de ventas",
                                   .IDModuloPadre = Nothing, .IDCategoria = 3, .Orden = 1, .Formulario = "frmVentasMaestro"})
        Modulos.Add(New Modulo With {.IDModulo = 15, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Clientes",
                                   .IDModuloPadre = Nothing, .IDCategoria = 3, .Orden = 2, .Formulario = "frmClientesMaestro"})
        Modulos.Add(New Modulo With {.IDModulo = 16, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Ventas Anuladas",
                                   .IDModuloPadre = Nothing, .IDCategoria = 3, .Orden = 2, .Formulario = ""})
        Modulos.Add(New Modulo With {.IDModulo = 17, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Consultar entregas",
                                   .IDModuloPadre = Nothing, .IDCategoria = 3, .Orden = 2, .Formulario = "frmConsultaVentaGuiaRem"})
        Modulos.Add(New Modulo With {.IDModulo = 18, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Resumen contable de ventas",
                         .IDModuloPadre = Nothing, .IDCategoria = 3, .Orden = 3, .Formulario = "frmResumenContableVentas"})
    End Sub
End Class
