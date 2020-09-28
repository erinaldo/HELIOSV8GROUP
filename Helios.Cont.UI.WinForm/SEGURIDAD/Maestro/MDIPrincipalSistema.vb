Public Class MDIPrincipalSistema
    Property Modulos As List(Of Modulo)

    Public Sub New()
        ModulosComercial()
    End Sub

    Private Sub ModulosComercial()
        Modulos = New List(Of Modulo)
        'CATEGORIAS PADRES
        Modulos.Add(New Modulo With {.IDModulo = 1, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "Perfiles", .IDModuloPadre = Nothing, .Orden = 1})
        Modulos.Add(New Modulo With {.IDModulo = 2, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "Usuarios", .IDModuloPadre = Nothing, .Orden = 2})
        Modulos.Add(New Modulo With {.IDModulo = 3, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "Modulos", .IDModuloPadre = Nothing, .Orden = 3})
        Modulos.Add(New Modulo With {.IDModulo = 4, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "Productos", .IDModuloPadre = Nothing, .Orden = 4})
        Modulos.Add(New Modulo With {.IDModulo = 5, .TipoModulo = Modulo.ModuloTipo.Categoria, .Descripcion = "Reportes", .IDModuloPadre = Nothing, .Orden = 5})

        Modulos.Add(New Modulo With {.IDModulo = 11, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Lista de Usuarios",
                                   .IDModuloPadre = Nothing, .IDCategoria = 2, .Orden = 1, .Formulario = "frmUsuariosListado"})
        Modulos.Add(New Modulo With {.IDModulo = 12, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Administrar Perfiles",
                                   .IDModuloPadre = Nothing, .IDCategoria = 1, .Orden = 1, .Formulario = "frmPerfilesDeUsuario"})
        Modulos.Add(New Modulo With {.IDModulo = 13, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Lista Perfiles por Usuario",
                                   .IDModuloPadre = Nothing, .IDCategoria = 1, .Orden = 2, .Formulario = "frmListaPerfilesXUsuario"})

        Modulos.Add(New Modulo With {.IDModulo = 14, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Crear Modulos",
                                   .IDModuloPadre = Nothing, .IDCategoria = 3, .Orden = 1, .Formulario = "frmDetalleModulosSistema"})
        Modulos.Add(New Modulo With {.IDModulo = 15, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Autorizaciones",
                                   .IDModuloPadre = Nothing, .IDCategoria = 3, .Orden = 2, .Formulario = "frmPerfilXProducto"})
        Modulos.Add(New Modulo With {.IDModulo = 16, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Autorizaciones x Perfil",
                                   .IDModuloPadre = Nothing, .IDCategoria = 3, .Orden = 3, .Formulario = "frmAutorizacionXperfil"})

        Modulos.Add(New Modulo With {.IDModulo = 17, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Crear Productos",
                           .IDModuloPadre = Nothing, .IDCategoria = 4, .Orden = 1, .Formulario = "frmListaProducto"})
        Modulos.Add(New Modulo With {.IDModulo = 18, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Administrar Productos",
                           .IDModuloPadre = Nothing, .IDCategoria = 4, .Orden = 2, .Formulario = "frmNuevoProductoDetalle"})
        Modulos.Add(New Modulo With {.IDModulo = 19, .TipoModulo = Modulo.ModuloTipo.Nivel, .Descripcion = "Administrar productos detalle",
                          .IDModuloPadre = Nothing, .IDCategoria = 4, .Orden = 3, .Formulario = "frmAutorizacionXModulo"})

    End Sub
End Class
