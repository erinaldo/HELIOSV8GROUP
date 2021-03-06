Public Class MDIPrincipalModelUsuarios
    Property Modulos As List(Of Modulo)

    Public Sub New()
        ModulosComercial()
    End Sub


    Private Sub ModulosComercial()
        Modulos = New List(Of Modulo)
        'CATEGORIAS PADRES
        Modulos.Add(New Modulo With {.IDModulo = 1, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "Usuarios", .IDModuloPadre = Nothing, .Orden = 1})
        Modulos.Add(New Modulo With {.IDModulo = 2, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "Perfiles", .IDModuloPadre = Nothing, .Orden = 2})
        Modulos.Add(New Modulo With {.IDModulo = 3, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "Modulos", .IDModuloPadre = Nothing, .Orden = 3})
        Modulos.Add(New Modulo With {.IDModulo = 4, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "Reportes", .IDModuloPadre = Nothing, .Orden = 4})



        Modulos.Add(New Modulo With {.IDModulo = 11, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Lista de Usuarios",
                                   .IDModuloPadre = Nothing, .IDCategoria = 1, .Orden = 1, .Formulario = "frmUsuariosListado"})
        Modulos.Add(New Modulo With {.IDModulo = 12, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Administrar Perfiles",
                                   .IDModuloPadre = Nothing, .IDCategoria = 2, .Orden = 1, .Formulario = "frmPerfilesDeUsuario"})

        Modulos.Add(New Modulo With {.IDModulo = 13, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Modulos",
                                   .IDModuloPadre = Nothing, .IDCategoria = 3, .Orden = 1, .Formulario = "frmDetalleModulosSistema"})
        Modulos.Add(New Modulo With {.IDModulo = 14, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Autorizaciones",
                                   .IDModuloPadre = Nothing, .IDCategoria = 3, .Orden = 2, .Formulario = "frmAutorizacionXperfil"})

    End Sub

End Class
