Public Class MDIPrincipalModel
    Property Usuario As Integer
    Property Modulos As List(Of Modulo)

    Public Sub New()
        CargarModulos()
    End Sub

    Public Sub CargarModulos()
        Modulos = New List(Of Modulo)

        Modulos.Add(New Modulo With {.IDModulo = 1, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "VENTAS", .IDModuloPadre = Nothing, .Orden = 1})
        Modulos.Add(New Modulo With {.IDModulo = 2, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "PRODUCCION", .IDModuloPadre = Nothing, .Orden = 2})
        Modulos.Add(New Modulo With {.IDModulo = 3, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "CONTRATO DE CONSTRUCCION", .IDModuloPadre = Nothing, .Orden = 3})
        Modulos.Add(New Modulo With {.IDModulo = 4, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "SERVICIOS EDUCATIVOS", .IDModuloPadre = Nothing, .Orden = 4})
        Modulos.Add(New Modulo With {.IDModulo = 5, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "CONSUMO INMEDIATO", .IDModuloPadre = Nothing, .Orden = 5})
        Modulos.Add(New Modulo With {.IDModulo = 6, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "SERVICIOS VARIOS", .IDModuloPadre = Nothing, .Orden = 6})
        Modulos.Add(New Modulo With {.IDModulo = 7, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "SERVICIOS DE TRANSPORTE", .IDModuloPadre = Nothing, .Orden = 7})
        Modulos.Add(New Modulo With {.IDModulo = 8, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "SERVICIOS DE HOTELERIA", .IDModuloPadre = Nothing, .Orden = 8})
        Modulos.Add(New Modulo With {.IDModulo = 9, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "ARRENDAMIENTO DE BIENES", .IDModuloPadre = Nothing, .Orden = 9})



        Modulos.Add(New Modulo With {.IDModulo = 99, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Sub Proyectos",
                                  .IDModuloPadre = Nothing, .IDCategoria = 1, .Orden = 1})

        Modulos.Add(New Modulo With {.IDModulo = 500, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Activos",
                                     .IDModuloPadre = 99, .IDCategoria = 1, .Orden = 1, .Formulario = "frmGridProyectos"})

        Modulos.Add(New Modulo With {.IDModulo = 501, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Culminados",
                                     .IDModuloPadre = 99, .IDCategoria = 1, .Orden = 1, .Formulario = ""})


        Modulos.Add(New Modulo With {.IDModulo = 100, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Mercaderías",
                                  .IDModuloPadre = Nothing, .IDCategoria = 1, .Orden = 2})

        Modulos.Add(New Modulo With {.IDModulo = 101, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Productos Terminados",
                               .IDModuloPadre = Nothing, .IDCategoria = 1, .Orden = 3})

        Modulos.Add(New Modulo With {.IDModulo = 102, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Prestación de Servicios",
                              .IDModuloPadre = Nothing, .IDCategoria = 1, .Orden = 4})


        'produccion

        Modulos.Add(New Modulo With {.IDModulo = 103, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Sub Proyectos",
                                  .IDModuloPadre = Nothing, .IDCategoria = 2, .Orden = 1})

        Modulos.Add(New Modulo With {.IDModulo = 600, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Activos",
                                     .IDModuloPadre = 103, .IDCategoria = 2, .Orden = 1, .Formulario = "frmGridProyectos"})

        Modulos.Add(New Modulo With {.IDModulo = 601, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Culminados",
                                     .IDModuloPadre = 103, .IDCategoria = 2, .Orden = 1, .Formulario = "GridProduccionCulminados"})

        Modulos.Add(New Modulo With {.IDModulo = 104, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Orden de Producción",
                            .IDModuloPadre = Nothing, .IDCategoria = 2, .Orden = 5, .Formulario = "frmOrdenProduccionDocumento"})

        Modulos.Add(New Modulo With {.IDModulo = 105, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Presupuesto",
                           .IDModuloPadre = Nothing, .IDCategoria = 2, .Orden = 6, .Formulario = "frmPresupuestoMaestro"})


        'CONSTRUCCION
        Modulos.Add(New Modulo With {.IDModulo = 106, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Sub Proyectos",
                                 .IDModuloPadre = Nothing, .IDCategoria = 3, .Orden = 1})

        Modulos.Add(New Modulo With {.IDModulo = 700, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Activos",
                                     .IDModuloPadre = 106, .IDCategoria = 3, .Orden = 1, .Formulario = "frmGridProyectos"})

        Modulos.Add(New Modulo With {.IDModulo = 701, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Culminados",
                                     .IDModuloPadre = 106, .IDCategoria = 3, .Orden = 1, .Formulario = ""})


        'CATEGORIAS
        'Modulos.Add(New Modulo With {.IDModulo = 1, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "LOGISTICA", .IDModuloPadre = Nothing, .Orden = 1})
        ''      Modulos.Add(New Modulo With {.IDModulo = 2, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "APORTES", .IDModuloPadre = Nothing, .Orden = 2})
        'Modulos.Add(New Modulo With {.IDModulo = 3, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "INVENTARIOS", .IDModuloPadre = Nothing, .Orden = 3})
        'Modulos.Add(New Modulo With {.IDModulo = 5, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "COMERCIAL", .IDModuloPadre = Nothing, .Orden = 5})
        'Modulos.Add(New Modulo With {.IDModulo = 4, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "FINANZAS", .IDModuloPadre = Nothing, .Orden = 4})
        'Modulos.Add(New Modulo With {.IDModulo = 6, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "CONTABILIDAD", .IDModuloPadre = Nothing, .Orden = 6})
        'Modulos.Add(New Modulo With {.IDModulo = 7, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "SISTEMA", .IDModuloPadre = Nothing, .Orden = 7})
        'Modulos.Add(New Modulo With {.IDModulo = 8, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "CATALOGO TABLAS", .IDModuloPadre = Nothing, .Orden = 8})
        'Modulos.Add(New Modulo With {.IDModulo = 9, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "CENTRAL", .IDModuloPadre = Nothing, .Orden = 9})

        'NIVELES DE "CATEGORIA CONFIGURACION"
        'Modulos.Add(New Modulo With {.IDModulo = 11, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "1. Solicitudes",
        '                             .IDModuloPadre = Nothing, .IDCategoria = 1, .Orden = 1})
        'Modulos.Add(New Modulo With {.IDModulo = 111, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Solicitud de compras",
        '                             .IDModuloPadre = 11, .IDCategoria = 1, .Orden = 1, .Formulario = "frmMasterSolicitudesCompra"})
        'Modulos.Add(New Modulo With {.IDModulo = 112, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Aprobación de Solicitudes",
        '                             .IDModuloPadre = 11, .IDCategoria = 1, .Orden = 1, .Formulario = Nothing})

        'Modulos.Add(New Modulo With {.IDModulo = 12, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "2. Logística",
        '                             .IDModuloPadre = Nothing, .IDCategoria = 1, .Orden = 1})
        'Modulos.Add(New Modulo With {.IDModulo = 121, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "A. Cotizaciones/recepción de proformas",
        '                             .IDModuloPadre = 12, .IDCategoria = 1, .Orden = 1, .Formulario = Nothing})

        'Modulos.Add(New Modulo With {.IDModulo = 122, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "B. Compras",
        '                             .IDModuloPadre = 12, .IDCategoria = 1, .Orden = 1})
        'Modulos.Add(New Modulo With {.IDModulo = 1221, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Gestión de Ordenes",
        '                             .IDModuloPadre = 122, .IDCategoria = 1, .Orden = 1, .Formulario = "frmMasterOrdenCompra"})
        'Modulos.Add(New Modulo With {.IDModulo = 1222, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Compras",
        '                            .IDModuloPadre = 122, .IDCategoria = 1, .Orden = 1, .Formulario = "frmMasterCompras"})


        'Modulos.Add(New Modulo With {.IDModulo = 611, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Central Compras",
        '                            .IDModuloPadre = Nothing, .IDCategoria = 9, .Orden = 9, .Formulario = "frmCentralCompras"})
        ''Modulos.Add(New Modulo With {.IDModulo = 1223, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "C-Directa con recepción",
        ''                           .IDModuloPadre = 122, .IDCategoria = 1, .Orden = 1, .Formulario = "frmCompraDirectaRecepcion"})
        ''Modulos.Add(New Modulo With {.IDModulo = 1224, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "C-Directa sin recepción",
        ''                           .IDModuloPadre = 122, .IDCategoria = 1, .Orden = 1, .Formulario = "frmCompraPagadaSinRecepcion"})
        ''Modulos.Add(New Modulo With {.IDModulo = 1225, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "C-Al crédito sin recepción",
        ''                   .IDModuloPadre = 122, .IDCategoria = 1, .Orden = 1, .Formulario = "frmCompraCreditoSinRecepcion"})

        ''Modulos.Add(New Modulo With {.IDModulo = 1226, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Reportes",
        ''                            .IDModuloPadre = 122, .IDCategoria = 1, .Orden = 1, .Formulario = "frmReporteCompras"})
        ''--------------------------------------------------------------------------------------------------------------------------------





        'Modulos.Add(New Modulo With {.IDModulo = 17, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Movimientos",
        '                             .IDModuloPadre = Nothing, .IDCategoria = 3, .Orden = 3})
        'Modulos.Add(New Modulo With {.IDModulo = 18, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Existencia en tránsito",
        '                            .IDModuloPadre = 17, .IDCategoria = 3, .Orden = 3, .Formulario = "frmInventarioTransito"})
        'Modulos.Add(New Modulo With {.IDModulo = 19, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Kárdex de existencias",
        '                        .IDModuloPadre = 17, .IDCategoria = 3, .Orden = 3, .Formulario = "frmKardex"})
        'Modulos.Add(New Modulo With {.IDModulo = 20, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Inventario total",
        '                       .IDModuloPadre = 17, .IDCategoria = 3, .Orden = 3, .Formulario = "frmtotalAlmacen"})

        'Modulos.Add(New Modulo With {.IDModulo = 100, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Otros movimientos",
        '                      .IDModuloPadre = 17, .IDCategoria = 3, .Orden = 3, .Formulario = "frmMasterLogistica"})

        'Modulos.Add(New Modulo With {.IDModulo = 500, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Notificaciones",
        '         .IDModuloPadre = 17, .IDCategoria = 3, .Orden = 3, .Formulario = "frmTransferenciaSobrante"})

        'Modulos.Add(New Modulo With {.IDModulo = 22, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Reportes de inventario",
        '               .IDModuloPadre = 17, .IDCategoria = 3, .Orden = 3, .Formulario = "frmReporteAlmacen"})

        'Modulos.Add(New Modulo With {.IDModulo = 23, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Almacenes",
        '                           .IDModuloPadre = Nothing, .IDCategoria = 3, .Orden = 3})
        'Modulos.Add(New Modulo With {.IDModulo = 24, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Listado de almacenes",
        '                           .IDModuloPadre = 23, .IDCategoria = 3, .Orden = 3, .Formulario = "frmMasterAlmacen"})

        ' ''APORTES
        ''Modulos.Add(New Modulo With {.IDModulo = 406, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Aportes",
        ''                             .IDModuloPadre = Nothing, .IDCategoria = 3, .Orden = 3})

        ''Modulos.Add(New Modulo With {.IDModulo = 407, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Registro de Aportes",
        ''                             .IDModuloPadre = 406, .IDCategoria = 3, .Orden = 3, .Formulario = "frmAportesGeneral"})

        ''Modulos.Add(New Modulo With {.IDModulo = 408, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Reportes",
        ''                            .IDModuloPadre = 406, .IDCategoria = 3, .Orden = 3, .Formulario = "frmReporteAportes"})

        ''CAJAS CUENTA FINANCIERAS
        'Modulos.Add(New Modulo With {.IDModulo = 25, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Apertura de cuentas de caja y bancos",
        '                             .IDModuloPadre = Nothing, .IDCategoria = 4, .Orden = 4})
        'Modulos.Add(New Modulo With {.IDModulo = 26, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Registro de usuarios de caja",
        '                         .IDModuloPadre = 25, .IDCategoria = 4, .Orden = 4, .Formulario = "frmMaestroCajas"}) '"frmMantenimientoCajas"

        'Modulos.Add(New Modulo With {.IDModulo = 602, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Registro cuentas financieras",
        '                        .IDModuloPadre = 25, .IDCategoria = 4, .Orden = 4, .Formulario = "frmMaestroCajas"}) '"frmMantenimientoCajas"

        'Modulos.Add(New Modulo With {.IDModulo = 603, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Asignacion de caja y/o efectivo por usuario",
        '                        .IDModuloPadre = 25, .IDCategoria = 4, .Orden = 4, .Formulario = "frmMaestroCajas"}) '"frmMantenimientoCajas"

        'Modulos.Add(New Modulo With {.IDModulo = 27, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Consulta cajas online",
        '                        .IDModuloPadre = 25, .IDCategoria = 4, .Orden = 4, .Formulario = "frmCajaInfo"})

        'Modulos.Add(New Modulo With {.IDModulo = 28, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Cuentas por pagar",
        '                            .IDModuloPadre = Nothing, .IDCategoria = 4, .Orden = 4, .Formulario = "frmPagosModal"}) ' "frmCuentasAPagar"
        ''Modulos.Add(New Modulo With {.IDModulo = 29, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Compras/Servicios",
        ''                        .IDModuloPadre = 28, .IDCategoria = 4, .Orden = 4, .Formulario = "frmCuentasAPagar"})
        'Modulos.Add(New Modulo With {.IDModulo = 31, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Cuentas por Cobrar",
        '                       .IDModuloPadre = Nothing, .IDCategoria = 4, .Orden = 4, .Formulario = "frmModuloCobros"})

        'Modulos.Add(New Modulo With {.IDModulo = 30, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Otros movimientos",
        '                       .IDModuloPadre = Nothing, .IDCategoria = 4, .Orden = 4, .Formulario = "frmMasterCajaMovimientos"})


        ''Modulos.Add(New Modulo With {.IDModulo = 32, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Ventas/Servicios",
        ''                        .IDModuloPadre = 31, .IDCategoria = 4, .Orden = 4, .Formulario = "frmCuentasACobrar"})
        ''Modulos.Add(New Modulo With {.IDModulo = 33, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Otros cobros",
        ''                       .IDModuloPadre = 31, .IDCategoria = 4, .Orden = 4, .Formulario = Nothing})

        'Modulos.Add(New Modulo With {.IDModulo = 403, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Prestámos otorgados",
        '                             .IDModuloPadre = Nothing, .IDCategoria = 4, .Orden = 4, .Formulario = "frmPrestamosMaster"})

        'Modulos.Add(New Modulo With {.IDModulo = 404, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Prestámos recibidos",
        '                            .IDModuloPadre = Nothing, .IDCategoria = 4, .Orden = 4, .Formulario = "frmMaestroPrestamosRecibidos"})


        'Modulos.Add(New Modulo With {.IDModulo = 606, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Consulta de pagos",
        '                            .IDModuloPadre = Nothing, .IDCategoria = 4, .Orden = 4, .Formulario = "frmConsultaCajas"})

        ''---------------------------------------------------------------------------------------------------------------------------------------


        'Modulos.Add(New Modulo With {.IDModulo = 21, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Configuración de precios de venta",
        '                       .IDModuloPadre = Nothing, .IDCategoria = 5, .Orden = 5, .Formulario = "frmConfigPrecioVenta"}) ''frmConfigPrecioVenta

        'Modulos.Add(New Modulo With {.IDModulo = 34, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Gestión de Ventas",
        '                            .IDModuloPadre = Nothing, .IDCategoria = 5, .Orden = 5})
        'Modulos.Add(New Modulo With {.IDModulo = 35, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Pedidos interactivos",
        '                     .IDModuloPadre = 34, .IDCategoria = 5, .Orden = 5, .Formulario = "frmMasterVentas"}) 'CajaRegistradora"

        'Modulos.Add(New Modulo With {.IDModulo = 608, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Ventas",
        '                    .IDModuloPadre = 34, .IDCategoria = 5, .Orden = 5, .Formulario = "frmMaestroVentaNormal"})

        'Modulos.Add(New Modulo With {.IDModulo = 610, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Cobro de pedidos de venta",
        '            .IDModuloPadre = Nothing, .IDCategoria = 5, .Orden = 5, .Formulario = "frmCajaTicket"})




        ''Modulos.Add(New Modulo With {.IDModulo = 36, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Ventas con ticket al contado",
        ''                      .IDModuloPadre = 34, .IDCategoria = 5, .Orden = 5, .Formulario = "frmMantenimientoVentaDirecta"})
        ''Modulos.Add(New Modulo With {.IDModulo = 37, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Ventas Generales existencias/servicios",
        ''                     .IDModuloPadre = 34, .IDCategoria = 5, .Orden = 5, .Formulario = "frmMasterVentaGeneral"})
        ''Modulos.Add(New Modulo With {.IDModulo = 38, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Análisis de Rentabilidad",
        ''                    .IDModuloPadre = 34, .IDCategoria = 5, .Orden = 5, .Formulario = "frmRentabilidad"})
        ''Modulos.Add(New Modulo With {.IDModulo = 39, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Cobro interactivo de Tickets",
        ''                   .IDModuloPadre = 34, .IDCategoria = 5, .Orden = 5, .Formulario = "frmPagoTicket"})
        ''Modulos.Add(New Modulo With {.IDModulo = 40, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Reportes",
        ''                    .IDModuloPadre = 34, .IDCategoria = 5, .Orden = 5, .Formulario = Nothing})

        'Modulos.Add(New Modulo With {.IDModulo = 41, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Ver hoja de trabajo",
        '                           .IDModuloPadre = Nothing, .IDCategoria = 6, .Orden = 6, .Formulario = "frmReporteContableMaster"})


        'Modulos.Add(New Modulo With {.IDModulo = 400, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Configuración",
        '                             .IDModuloPadre = Nothing, .IDCategoria = 7, .Orden = 7, .Formulario = Nothing}) '"frmConfigSistema"
        'Modulos.Add(New Modulo With {.IDModulo = 401, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Configuración de series",
        '                           .IDModuloPadre = 400, .IDCategoria = 7, .Orden = 7, .Formulario = "frmConfiguracionesInicio"})
        'Modulos.Add(New Modulo With {.IDModulo = 402, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Gestión cuentas",
        '                         .IDModuloPadre = 400, .IDCategoria = 7, .Orden = 7, .Formulario = "frmControlCuenta"})
        'Modulos.Add(New Modulo With {.IDModulo = 405, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Cierres contables",
        '                         .IDModuloPadre = 400, .IDCategoria = 7, .Orden = 7, .Formulario = "frmCierreContable"})
        'Modulos.Add(New Modulo With {.IDModulo = 609, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Configuración comprobantes",
        '                               .IDModuloPadre = 400, .IDCategoria = 7, .Orden = 7, .Formulario = "frmConfiguracionesInicio"})
        'Modulos.Add(New Modulo With {.IDModulo = 612, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Cuentas manuales",
        '                             .IDModuloPadre = 400, .IDCategoria = 7, .Orden = 7, .Formulario = "frmMasterLibro"})


        'Modulos.Add(New Modulo With {.IDModulo = 600, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Aportes",
        '                         .IDModuloPadre = Nothing, .IDCategoria = 6, .Orden = 6, .Formulario = "frmMasterSaldoAporte"})

        'Modulos.Add(New Modulo With {.IDModulo = 601, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Modulo Caja Saldos",
        '                      .IDModuloPadre = Nothing, .IDCategoria = 6, .Orden = 6, .Formulario = "frmPagarSaldos"})

        'Modulos.Add(New Modulo With {.IDModulo = 604, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Tablas del Sistema",
        '                      .IDModuloPadre = Nothing, .IDCategoria = 8, .Orden = 8, .Formulario = "frmTablasGenerales"})

        'Modulos.Add(New Modulo With {.IDModulo = 605, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Existencias",
        '                     .IDModuloPadre = Nothing, .IDCategoria = 8, .Orden = 8, .Formulario = "frmExistencias"})

        'Modulos.Add(New Modulo With {.IDModulo = 607, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Historial tipo de cambio",
        '                    .IDModuloPadre = Nothing, .IDCategoria = 8, .Orden = 8, .Formulario = "frmMaestroTipoCambio"})

        '"frmSaldos"
    End Sub


End Class

