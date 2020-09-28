Public Class MDIPrincipalModelContabilidad

    Property Usuario As Integer
    Property Modulos As List(Of Modulo)

    Public Sub New()
        ModulosContabilidad()
    End Sub

    Private Sub ModulosContabilidad()
        Modulos = New List(Of Modulo)
        'CATEGORIAS PADRES
        Modulos.Add(New Modulo With {.IDModulo = 1, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "Asientos manuales", .IDModuloPadre = Nothing, .Orden = 1})
        Modulos.Add(New Modulo With {.IDModulo = 2, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "Asiento de apertura/inicio", .IDModuloPadre = Nothing, .Orden = 2})
        Modulos.Add(New Modulo With {.IDModulo = 3, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "Asientos de cierre", .IDModuloPadre = Nothing, .Orden = 3})
        Modulos.Add(New Modulo With {.IDModulo = 4, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "Libros electronicos", .IDModuloPadre = Nothing, .Orden = 4})
        Modulos.Add(New Modulo With {.IDModulo = 5, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "Hoja de trabajo", .IDModuloPadre = Nothing, .Orden = 5})
        Modulos.Add(New Modulo With {.IDModulo = 6, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "Estados financieros", .IDModuloPadre = Nothing, .Orden = 6})


        'Nodos secundarios
        ' Asientos manuales {1}
        Modulos.Add(New Modulo With {.IDModulo = 10, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Registro asientos manuales",
                                    .IDModuloPadre = Nothing, .IDCategoria = 1, .Orden = 1, .Formulario = "frmContabilidadAsientosManuales"})


        Modulos.Add(New Modulo With {.IDModulo = 16, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Asientos x conciliar",
                                    .IDModuloPadre = Nothing, .IDCategoria = 1, .Orden = 2, .Formulario = "frmContabilidadAsientosPorConciliar"})

        ' Asiento de apertura {2}
        Modulos.Add(New Modulo With {.IDModulo = 11, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Asientos de apertura o inicio",
                                   .IDModuloPadre = Nothing, .IDCategoria = 2, .Orden = 1, .Formulario = "frmContabilidadAsientoApertura"})


        ' Asiento de Cierre anual {3}
        Modulos.Add(New Modulo With {.IDModulo = 12, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Asientos de cierres, anual",
                                   .IDModuloPadre = Nothing, .IDCategoria = 3, .Orden = 1, .Formulario = ""})

        ' Libros electronicos {4}
        Modulos.Add(New Modulo With {.IDModulo = 13, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Libros electrónicos",
                                   .IDModuloPadre = Nothing, .IDCategoria = 4, .Orden = 1, .Formulario = "frmFormatosPlevb"})


        ' Hja de trabajo  {5}
        Modulos.Add(New Modulo With {.IDModulo = 14, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Hoja de trabajo",
                                   .IDModuloPadre = Nothing, .IDCategoria = 5, .Orden = 1, .Formulario = "FrmHojaTrabajo"})

        'Estados financieros  {6}
        Modulos.Add(New Modulo With {.IDModulo = 15, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Estados financieros",
                                   .IDModuloPadre = Nothing, .IDCategoria = 6, .Orden = 1, .Formulario = ""})

    End Sub

End Class
