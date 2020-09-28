Public Class MDIPrincipalModelFinanzas

    Property Usuario As Integer
    Property Modulos As List(Of Modulo)

    Public Sub New()
        Modulos = New List(Of Modulo)

        'CATEGORIAS PADRES
        Modulos.Add(New Modulo With {.IDModulo = 1, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "Configuración", .IDModuloPadre = Nothing, .Orden = 1})
        Modulos.Add(New Modulo With {.IDModulo = 2, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "Caja y Bancos", .IDModuloPadre = Nothing, .Orden = 2})
        Modulos.Add(New Modulo With {.IDModulo = 3, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "Cuentas por pagar", .IDModuloPadre = Nothing, .Orden = 3})
        Modulos.Add(New Modulo With {.IDModulo = 4, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "Cuentas por cobrar", .IDModuloPadre = Nothing, .Orden = 4})
        Modulos.Add(New Modulo With {.IDModulo = 5, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "Usuarios de caja", .IDModuloPadre = Nothing, .Orden = 5})
        Modulos.Add(New Modulo With {.IDModulo = 6, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "Informes", .IDModuloPadre = Nothing, .Orden = 6})

        'Nodos secundarios
        ' Caja y Bancos {2}
        Modulos.Add(New Modulo With {.IDModulo = 10, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Cuentas Financieras",
                                    .IDModuloPadre = Nothing, .IDCategoria = 2, .Orden = 1, .Formulario = "frmCuentasFinancieras"})
        Modulos.Add(New Modulo With {.IDModulo = 11, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Movimiento por item M.N.",
                                    .IDModuloPadre = Nothing, .IDCategoria = 2, .Orden = 2, .Formulario = "frmMovimientosMN"})
        Modulos.Add(New Modulo With {.IDModulo = 12, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Movimiento por documento M.N.",
                                   .IDModuloPadre = Nothing, .IDCategoria = 2, .Orden = 3, .Formulario = "frmModalMovimientosMN"})
        Modulos.Add(New Modulo With {.IDModulo = 13, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Movimientos M.E.",
                                   .IDModuloPadre = Nothing, .IDCategoria = 2, .Orden = 4, .Formulario = "frmMovimientoME"})
        Modulos.Add(New Modulo With {.IDModulo = 14, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Transferencia entre cajas",
                                  .IDModuloPadre = Nothing, .IDCategoria = 2, .Orden = 5, .Formulario = "frmTransferenciaCajas"})
        Modulos.Add(New Modulo With {.IDModulo = 15, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Entregas a rendir cuentas",
                                  .IDModuloPadre = Nothing, .IDCategoria = 2, .Orden = 6})
        Modulos.Add(New Modulo With {.IDModulo = 16, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Compra venta - moneda extranjera",
                                 .IDModuloPadre = Nothing, .IDCategoria = 2, .Orden = 7})
        Modulos.Add(New Modulo With {.IDModulo = 17, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Otros ingresos {MN:ME}",
                                 .IDModuloPadre = Nothing, .IDCategoria = 2, .Orden = 8, .Formulario = "frmOtrasEntradasCaja"})
        Modulos.Add(New Modulo With {.IDModulo = 18, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Otras sálidas {MN:ME}",
                                 .IDModuloPadre = Nothing, .IDCategoria = 2, .Orden = 9, .Formulario = "frmOtrasSalidasCaja"})
        Modulos.Add(New Modulo With {.IDModulo = 19, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Aportes {MN:ME}",
                                .IDModuloPadre = Nothing, .IDCategoria = 2, .Orden = 10, .Formulario = "frmAporteMaster"})
        Modulos.Add(New Modulo With {.IDModulo = 20, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Ingreso por Anticipos",
                                  .IDModuloPadre = Nothing, .IDCategoria = 2, .Orden = 11, .Formulario = "frmIngresoXAnticipoMaster"})
        Modulos.Add(New Modulo With {.IDModulo = 21, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Salida por Anticipos",
                                    .IDModuloPadre = Nothing, .IDCategoria = 2, .Orden = 12, .Formulario = "frmSalidaXAnticipoMaster"})
        Modulos.Add(New Modulo With {.IDModulo = 22, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Historial - Ingresos por Devolución",
                                    .IDModuloPadre = Nothing, .IDCategoria = 2, .Orden = 13, .Formulario = "frmIngresoXDevolucionMaster"})
        Modulos.Add(New Modulo With {.IDModulo = 23, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Historial - Salidas por Devolución",
                                    .IDModuloPadre = Nothing, .IDCategoria = 2, .Orden = 14, .Formulario = "frmSalidaXDevolucionMaster"})
        Modulos.Add(New Modulo With {.IDModulo = 24, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Historial de Reversiones",
                                    .IDModuloPadre = Nothing, .IDCategoria = 2, .Orden = 15, .Formulario = "frmReversionMaster"})
        Modulos.Add(New Modulo With {.IDModulo = 25, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Historial - Transacciones de Caja",
                                    .IDModuloPadre = Nothing, .IDCategoria = 2, .Orden = 16, .Formulario = "frmMovmientoTransaccionMaster"})

        ' Cuentas por pagar {3}
        Modulos.Add(New Modulo With {.IDModulo = 26, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Cuentas por pagar",
                                   .IDModuloPadre = Nothing, .IDCategoria = 3, .Orden = 1, .Formulario = "FormCuentasPorPagar"}) '"frmFinanzaCuentasPagar"
        Modulos.Add(New Modulo With {.IDModulo = 27, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Otras cuentas por pagar",
                                   .IDModuloPadre = Nothing, .IDCategoria = 3, .Orden = 2, .Formulario = "frmFinanzasotrasCuentasPorPagar"})
        Modulos.Add(New Modulo With {.IDModulo = 28, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Anticipos recibidos",
                                   .IDModuloPadre = Nothing, .IDCategoria = 3, .Orden = 3, .Formulario = "frmAnticiposPorPagar"})
        Modulos.Add(New Modulo With {.IDModulo = 29, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Reclamaciones",
                                  .IDModuloPadre = Nothing, .IDCategoria = 3, .Orden = 4, .Formulario = "frmReclamaciones"})
        Modulos.Add(New Modulo With {.IDModulo = 30, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Cronograma de Obligaciones",
                                  .IDModuloPadre = Nothing, .IDCategoria = 3, .Orden = 5, .Formulario = "frmFinanzasCronogramaPago"})

        ' Cuentas por cobrar {4}
        Modulos.Add(New Modulo With {.IDModulo = 31, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Cuentas por cobrar",
                                   .IDModuloPadre = Nothing, .IDCategoria = 4, .Orden = 1, .Formulario = "frmFinanzasCuentasPorCobrar"})
        Modulos.Add(New Modulo With {.IDModulo = 32, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Otras cuentas por cobrar",
                                   .IDModuloPadre = Nothing, .IDCategoria = 4, .Orden = 2, .Formulario = "frmOtrasCuentasPorCobrarFinanzas"})
        Modulos.Add(New Modulo With {.IDModulo = 33, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Anticipos otorgados",
                                   .IDModuloPadre = Nothing, .IDCategoria = 4, .Orden = 3, .Formulario = "frmAnticiposPorCobrar"})
        Modulos.Add(New Modulo With {.IDModulo = 34, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Reclamaciones",
                                  .IDModuloPadre = Nothing, .IDCategoria = 4, .Orden = 4, .Formulario = "frmReclamacionesProv"})
        Modulos.Add(New Modulo With {.IDModulo = 35, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Cronograma de Acreencias",
                                  .IDModuloPadre = Nothing, .IDCategoria = 4, .Orden = 5, .Formulario = "frmFinanzasCronogramaCobro"})

        ' Usuario de Caja {5}
        Modulos.Add(New Modulo With {.IDModulo = 36, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Administración de usuarios",
                                   .IDModuloPadre = Nothing, .IDCategoria = 5, .Orden = 1, .Formulario = "frmAdminUsuariosCaja"})
        Modulos.Add(New Modulo With {.IDModulo = 37, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Caja: Abrir-Cerrar",
                                   .IDModuloPadre = Nothing, .IDCategoria = 5, .Orden = 2, .Formulario = "frmAbrirCerrar_Caja"})
        Modulos.Add(New Modulo With {.IDModulo = 38, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Historial de caja",
                                   .IDModuloPadre = Nothing, .IDCategoria = 5, .Orden = 3, .Formulario = "frmHistorialCajas"})
        Modulos.Add(New Modulo With {.IDModulo = 39, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Reportes",
                                   .IDModuloPadre = Nothing, .IDCategoria = 5, .Orden = 4, .Formulario = "frmReporteCaja"})


        ' información {6}
        Modulos.Add(New Modulo With {.IDModulo = 40, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Cuentas por cobrar (Acreencias)",
                                   .IDModuloPadre = Nothing, .IDCategoria = 6, .Orden = 1, .Formulario = "frmCuentasXCobrarAcreencias"})
        Modulos.Add(New Modulo With {.IDModulo = 41, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Programación de cuentas por cobrar (Acreencias)",
                                   .IDModuloPadre = Nothing, .IDCategoria = 6, .Orden = 2, .Formulario = "frmProgramacionDeCuentasXCobrar"})
        Modulos.Add(New Modulo With {.IDModulo = 42, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Cuentas por pagar (obligaciones)",
                                   .IDModuloPadre = Nothing, .IDCategoria = 6, .Orden = 3, .Formulario = "frmCuentasXpagarObligaciones"})
        Modulos.Add(New Modulo With {.IDModulo = 43, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Programación de cuentas por pagar (obligaciones)",
                                   .IDModuloPadre = Nothing, .IDCategoria = 6, .Orden = 4, .Formulario = "frmProgramacionDeCuentasXPagar"})
        Modulos.Add(New Modulo With {.IDModulo = 44, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Estado de situación financiera",
                                   .IDModuloPadre = Nothing, .IDCategoria = 6, .Orden = 5, .Formulario = "frmEstadoSituacionFinanciera"})
        Modulos.Add(New Modulo With {.IDModulo = 45, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Estado de resultado",
                                   .IDModuloPadre = Nothing, .IDCategoria = 6, .Orden = 6, .Formulario = "frmEstadoResultado"})


    End Sub

End Class
