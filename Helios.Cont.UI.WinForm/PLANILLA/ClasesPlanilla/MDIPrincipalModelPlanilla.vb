Public Class MDIPrincipalModelPlanilla

    Property Usuario As Integer
    Property Modulos As List(Of Modulo)

    Public Sub New()
        CargarModulos()
    End Sub
    Public Sub CargarModulos()
        Modulos = New List(Of Modulo)

        'CATEGORIAS
        Modulos.Add(New Modulo With {.IDModulo = 1, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "Configuración", .IDModuloPadre = Nothing, .Orden = 1})
        Modulos.Add(New Modulo With {.IDModulo = 2, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "Información Trabajador", .IDModuloPadre = Nothing, .Orden = 2})
        Modulos.Add(New Modulo With {.IDModulo = 3, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "Registros", .IDModuloPadre = Nothing, .Orden = 3})
        Modulos.Add(New Modulo With {.IDModulo = 4, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "Procesos", .IDModuloPadre = Nothing, .Orden = 4})
        Modulos.Add(New Modulo With {.IDModulo = 5, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "Reportes", .IDModuloPadre = Nothing, .Orden = 5})
        Modulos.Add(New Modulo With {.IDModulo = 6, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "Declaraciones y Entidades", .IDModuloPadre = Nothing, .Orden = 6})

        ' Modulos.Add(New Modulo With {.IDModulo = 1, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "PLANILLA", .IDModuloPadre = Nothing, .Orden = 1})
        ' Modulos.Add(New Modulo With {.IDModulo = 2, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "REPORTES", .IDModuloPadre = Nothing, .Orden = 2})
        ' Modulos.Add(New Modulo With {.IDModulo = 3, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "CONFIGURACIÓN", .IDModuloPadre = Nothing, .Orden = 3})
        Modulos.Add(New Modulo With {.IDModulo = 7, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "SISTEMA", .IDModuloPadre = Nothing, .Orden = 7})

        'NIVELES DE "CATEGORIA CONFIGURACION"
        Modulos.Add(New Modulo With {.IDModulo = 10, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Maestro conceptos",
                                     .IDModuloPadre = Nothing, .IDCategoria = 1, .Orden = 1, .Formulario = "frmConceptosGenerales"}) '"frmMaestroConceptos"

        Modulos.Add(New Modulo With {.IDModulo = 11, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Plantilla conceptos",
                                     .IDModuloPadre = Nothing, .IDCategoria = 1, .Orden = 2, .Formulario = "frmPlantillaConceptosMaestro"})

        Modulos.Add(New Modulo With {.IDModulo = 12, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Cargos u ocupación",
                                     .IDModuloPadre = Nothing, .IDCategoria = 1, .Orden = 3, .Formulario = "frmMaestroCargos"})

        Modulos.Add(New Modulo With {.IDModulo = 13, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Calculo de Planilla",
                                     .IDModuloPadre = Nothing, .IDCategoria = 1, .Orden = 4, .Formulario = "frmPagoPlanilla"})



        Modulos.Add(New Modulo With {.IDModulo = 14, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Ingreso de Asistencia",
                                     .IDModuloPadre = Nothing, .IDCategoria = 2, .Orden = 1, .Formulario = "frmRegistroAsistencia"})

        Modulos.Add(New Modulo With {.IDModulo = 15, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Asistecia del Personal",
                                     .IDModuloPadre = Nothing, .IDCategoria = 2, .Orden = 2, .Formulario = "frmConsultaAsistenciaTrabajador"})

        Modulos.Add(New Modulo With {.IDModulo = 16, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Personal",
                                     .IDModuloPadre = Nothing, .IDCategoria = 2, .Orden = 3, .Formulario = "frmMaestrotrabajadores"})



    End Sub
End Class
