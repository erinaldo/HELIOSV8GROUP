Public Class MDIPrincipalModelLogistica
    Property Usuario As Integer
    Property Modulos As List(Of Modulo)

    Public Sub New()
        ModulosComercial()
    End Sub

    Private Sub ModulosComercial()
        Modulos = New List(Of Modulo)
        'CATEGORIAS PADRES
        Modulos.Add(New Modulo With {.IDModulo = 1, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "Cotizaciones", .IDModuloPadre = Nothing, .Orden = 1})
        Modulos.Add(New Modulo With {.IDModulo = 2, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "Ordenes de Compra", .IDModuloPadre = Nothing, .Orden = 2})
        Modulos.Add(New Modulo With {.IDModulo = 3, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "Compras", .IDModuloPadre = Nothing, .Orden = 3})
        Modulos.Add(New Modulo With {.IDModulo = 4, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "Inventario", .IDModuloPadre = Nothing, .Orden = 4})
        Modulos.Add(New Modulo With {.IDModulo = 5, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "Precios", .IDModuloPadre = Nothing, .Orden = 5})
        Modulos.Add(New Modulo With {.IDModulo = 6, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "Reportes", .IDModuloPadre = Nothing, .Orden = 6})



        Modulos.Add(New Modulo With {.IDModulo = 11, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Ordenes de Compra",
                                   .IDModuloPadre = Nothing, .IDCategoria = 2, .Orden = 1, .Formulario = ""})
        Modulos.Add(New Modulo With {.IDModulo = 12, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Ordenes de Servicio",
                                   .IDModuloPadre = Nothing, .IDCategoria = 2, .Orden = 2, .Formulario = ""})

        Modulos.Add(New Modulo With {.IDModulo = 13, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Registro de Compras",
                                   .IDModuloPadre = Nothing, .IDCategoria = 3, .Orden = 1, .Formulario = "frmComprasMaestro"})
        Modulos.Add(New Modulo With {.IDModulo = 14, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Proveedores",
                           .IDModuloPadre = Nothing, .IDCategoria = 3, .Orden = 2, .Formulario = "frmProveedoresMaestro"})
        Modulos.Add(New Modulo With {.IDModulo = 15, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Detracciones",
                           .IDModuloPadre = Nothing, .IDCategoria = 3, .Orden = 3, .Formulario = "frmModuloDetracciones"})
        Modulos.Add(New Modulo With {.IDModulo = 38, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Compras observadas",
                           .IDModuloPadre = Nothing, .IDCategoria = 3, .Orden = 3, .Formulario = "frmComprasObservadas"})
        Modulos.Add(New Modulo With {.IDModulo = 40, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Resumen contable de compras",
                           .IDModuloPadre = Nothing, .IDCategoria = 3, .Orden = 3, .Formulario = "frmResumenContableCompras"})


        Modulos.Add(New Modulo With {.IDModulo = 16, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Inventarios en trásito x compras",
                          .IDModuloPadre = Nothing, .IDCategoria = 4, .Orden = 1, .Formulario = "frmExistenciasEnTransito"})

        Modulos.Add(New Modulo With {.IDModulo = 17, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Invent. tránsito transf. entre almacenes",
              .IDModuloPadre = Nothing, .IDCategoria = 4, .Orden = 2, .Formulario = "frmEntregaArticulosXconfirmar"})

        Modulos.Add(New Modulo With {.IDModulo = 18, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Otros movimientos",
                          .IDModuloPadre = Nothing, .IDCategoria = 4, .Orden = 3, .Formulario = "frmMovimientosInventario"})

        Modulos.Add(New Modulo With {.IDModulo = 39, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Cambios de Inventario",
                          .IDModuloPadre = Nothing, .IDCategoria = 4, .Orden = 3, .Formulario = "frmListaCambioInventario"})

        Modulos.Add(New Modulo With {.IDModulo = 19, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Transferencia entre almacenes",
             .IDModuloPadre = Nothing, .IDCategoria = 4, .Orden = 4, .Formulario = "frmMovimientoTransferencia"})


        Modulos.Add(New Modulo With {.IDModulo = 20, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Reclasificación de inventarios",
                     .IDModuloPadre = Nothing, .IDCategoria = 4, .Orden = 5, .Formulario = "frmCambioInventarioArticulo"})

        'movimiento de periodo - padre
        Modulos.Add(New Modulo With {.IDModulo = 21, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Movimiento con observación",
                                     .IDModuloPadre = Nothing, .IDCategoria = 4, .Orden = 6})

        'Modulos.Add(New Modulo With {.IDModulo = 22, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Movim. sin guía de remisión",
        '     .IDModuloPadre = 21, .IDCategoria = 4, .Orden = 7, .Formulario = "frmMovimientosSinNumGuia"})

        'Modulos.Add(New Modulo With {.IDModulo = 23, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Generar guía de remisión",
        '     .IDModuloPadre = 21, .IDCategoria = 4, .Orden = 8, .Formulario = "frmMovimientosSinNumGuia"})

        Modulos.Add(New Modulo With {.IDModulo = 24, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Pendientes de entrega por ventas",
             .IDModuloPadre = 21, .IDCategoria = 4, .Orden = 9, .Formulario = "frmEntregaArticulosXconfirmar"})

        Modulos.Add(New Modulo With {.IDModulo = 25, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Confirmación de entregas",
            .IDModuloPadre = 21, .IDCategoria = 4, .Orden = 10, .Formulario = "frmEntregaArticulosXconfirmar"})

        ' Informacion -padre
        Modulos.Add(New Modulo With {.IDModulo = 26, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Información",
                                 .IDModuloPadre = Nothing, .IDCategoria = 4, .Orden = 11})

        Modulos.Add(New Modulo With {.IDModulo = 27, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Inventario valorizado",
                                    .IDModuloPadre = 26, .IDCategoria = 4, .Orden = 12, .Formulario = "frmInventarioValorizado"})

        Modulos.Add(New Modulo With {.IDModulo = 28, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Kardex",
                                    .IDModuloPadre = 26, .IDCategoria = 4, .Orden = 13, .Formulario = "frmModeloKardex"})

        Modulos.Add(New Modulo With {.IDModulo = 29, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Rotación de existencias",
                                    .IDModuloPadre = 26, .IDCategoria = 4, .Orden = 14, .Formulario = "frmRotacionArticulos"})

        Modulos.Add(New Modulo With {.IDModulo = 30, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Orden de compra conocimiento",
                                    .IDModuloPadre = 26, .IDCategoria = 4, .Orden = 15, .Formulario = "frmOrdenesCompraAprobadas"})

        '   Configuracion -padre
        Modulos.Add(New Modulo With {.IDModulo = 31, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Configuraciones",
                                .IDModuloPadre = Nothing, .IDCategoria = 4, .Orden = 16})

        Modulos.Add(New Modulo With {.IDModulo = 32, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Almacenes",
                                    .IDModuloPadre = 31, .IDCategoria = 4, .Orden = 17, .Formulario = "frmGestionAlmacenes"})

        Modulos.Add(New Modulo With {.IDModulo = 33, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Precios: Existencias",
                     .IDModuloPadre = Nothing, .IDCategoria = 5, .Orden = 1, .Formulario = "frmExistenciaPrecios"})
        Modulos.Add(New Modulo With {.IDModulo = 34, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Precios: Servicios",
                    .IDModuloPadre = Nothing, .IDCategoria = 5, .Orden = 2, .Formulario = "frmServiciosPrecios"})
        Modulos.Add(New Modulo With {.IDModulo = 35, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Artículos sin precio",
                     .IDModuloPadre = Nothing, .IDCategoria = 5, .Orden = 3, .Formulario = "frmArticulosSinPrecio"})
        Modulos.Add(New Modulo With {.IDModulo = 36, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Precios observados",
                    .IDModuloPadre = Nothing, .IDCategoria = 5, .Orden = 4, .Formulario = "frmPreciosObservados"})
        Modulos.Add(New Modulo With {.IDModulo = 37, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Configuración",
                    .IDModuloPadre = Nothing, .IDCategoria = 5, .Orden = 5, .Formulario = "frmAdminPrecios"})


    End Sub
End Class
