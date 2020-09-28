Imports System.Data.Entity.Migrations
Imports System.Transactions
Imports Helios.Cont.Business.Entity
Imports JNetFx.Framework.General

Public Class clientesSoftPackBL
    Inherits BaseBL

    Public Sub Save(be As clientesSoftPack, empresaBE As empresa, listaCentoCosto As List(Of centrocosto))
        Try


            'Dim autorizacionRolBL As New Seguridad.Business.Logic.AutorizacionRolBL
            Dim empresaBL As New empresaBL
            Dim encriptador As New Cryptography
            '   Dim asegurables As New Seguridad.Business.Entity.Asegurable
            '   Dim AsegurableBL As New Seguridad.Business.Logic.AsegurableBL
            '   Dim AutenticacionUsuarioBL As New Seguridad.Business.Logic.AutenticacionUsuarioBL
            '   Dim SeguridadproductoBL As New Seguridad.Business.Logic.productoDetalleBL

            '   Dim ProductoAquirido = SeguridadproductoBL.GetListaProductoDetalleInicio(be.IDProducto)
            'Using ts As New TransactionScope

            If be.Action = BaseBE.EntityAction.UPDATE Then
                HeliosData.clientesSoftPack.AddOrUpdate(be)
            Else

                Dim estadosFinancierosBL As New estadosFinancierosBL
                Dim estadosFinancierosBE As New estadosFinancieros

                '         Dim a = encriptador.getSHA1Hash(encriptador.Decode(fsdfd))
                Dim idCliente = GetInsert(be)
                empresaBE.idclientespk = idCliente.idclientespk
                empresaBE.ruc = be.nroDoc

                empresaBL.Insert(empresaBE)


                '//ESTADOS FINANCIEROS----------------
                estadosFinancierosBE = New estadosFinancieros
                estadosFinancierosBE.[idEmpresa] = empresaBE.ruc
                estadosFinancierosBE.[idEstablecimiento] = 0
                estadosFinancierosBE.[idBanco] = "01"
                estadosFinancierosBE.[cuenta] = 101
                estadosFinancierosBE.[codigo] = 1
                estadosFinancierosBE.[tipo] = "EF"
                estadosFinancierosBE.[descripcion] = "EFECTIVO GENERAL"
                estadosFinancierosBE.[nroCtaCorriente] = Nothing
                estadosFinancierosBE.[tipocambio] = 1
                estadosFinancierosBE.[fechaBalance] = Date.Now
                estadosFinancierosBE.[importeBalanceMN] = 0.0
                estadosFinancierosBE.[importeBalanceME] = 0.0
                estadosFinancierosBE.[predeterminado] = Nothing
                estadosFinancierosBE.[usuarioActualizacion] = "ADMINISTRADOR"
                estadosFinancierosBE.[fechaActualizacion] = Date.Now
                estadosFinancierosBL.Insert(estadosFinancierosBE)

                estadosFinancierosBE = New estadosFinancieros
                estadosFinancierosBE.[idEmpresa] = empresaBE.idEmpresa
                estadosFinancierosBE.[idEstablecimiento] = 0
                estadosFinancierosBE.[idBanco] = "01"
                estadosFinancierosBE.[cuenta] = 101
                estadosFinancierosBE.[codigo] = 1
                estadosFinancierosBE.[tipo] = "EP"
                estadosFinancierosBE.[descripcion] = "EFECTIVO POS"
                estadosFinancierosBE.[nroCtaCorriente] = Nothing
                estadosFinancierosBE.[tipocambio] = 1
                estadosFinancierosBE.[fechaBalance] = Date.Now
                estadosFinancierosBE.[importeBalanceMN] = 0.0
                estadosFinancierosBE.[importeBalanceME] = 0.0
                estadosFinancierosBE.[predeterminado] = Nothing
                estadosFinancierosBE.[usuarioActualizacion] = "ADMINISTRADOR"
                estadosFinancierosBE.[fechaActualizacion] = Date.Now
                estadosFinancierosBL.Insert(estadosFinancierosBE)

                If (empresaBE.tipoCreacion = "GR") Then
                    empresaBL.InsertarEmpresaOne(empresaBE,
                                         be.ListaMascaraContable2,
                                         be.ListaCuentaMascara,
                                         be.ListamascaraGastosEmpresa,
                                         be.ListacuentaplanContableEmpresa,
                                         listaCentoCosto)
                End If



                '// SE 



                '    be.IDProducto = be.IDProducto
                ' LINEA INVALIDA     Dim ProductoAquirido = SeguridadproductoBL.GetListaProductoDetalleInicio(be.IDProducto)
                'If ProductoAquirido.Count > 0 Then
                '    For Each s In ProductoAquirido
                '        asegurables = New Seguridad.Business.Entity.Asegurable
                '        asegurables.IDAsegurable = s.IDAsegurable
                '        asegurables.IDAsegurablePadre = s.IDAsegurablePadre
                '        asegurables.IDCliente = idCliente.idclientespk
                '        asegurables.Nombre = s.Nombre
                '        asegurables.Descripcion = s.Descripcion
                '        asegurables.CodRef = s.formulario
                '        asegurables.orden = s.orden
                '        asegurables.UsuarioActualizacion = "Sistema"
                '        asegurables.FechaActualizacion = DateTime.Now
                '        AsegurableBL.Insert(asegurables)
                '    Next
                'End If
                '    Dim idRol = AutenticacionUsuarioBL.MappingUsuarioAdmin(idCliente.idclientespk)
                '    autorizacionRolBL.InsertarListaAsegurables(ProductoAquirido, idRol, idCliente.idclientespk)
            End If
            HeliosData.SaveChanges()
            'ts.Complete()
            'End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Public Sub Save(ByVal be As clientesSoftPack)
    '    Dim autorizacionRolBL As New Seguridad.Business.Logic.AutorizacionRolBL
    '    Dim empresaBL As New empresaBL
    '    Dim encriptador As New Cryptography
    '    Dim asegurables As New Seguridad.Business.Entity.Asegurable
    '    Dim AsegurableBL As New Seguridad.Business.Logic.AsegurableBL
    '    Dim AutenticacionUsuarioBL As New Seguridad.Business.Logic.AutenticacionUsuarioBL
    '    Dim SeguridadproductoBL As New Seguridad.Business.Logic.productoDetalleBL

    '    Dim ProductoAquirido = SeguridadproductoBL.GetListaProductoDetalleInicio(be.IDProducto)
    '    'Using ts As New TransactionScope

    '    If be.Action = BaseBE.EntityAction.UPDATE Then
    '        HeliosData.clientesSoftPack.AddOrUpdate(be)
    '    Else
    '        '         Dim a = encriptador.getSHA1Hash(encriptador.Decode(fsdfd))
    '        Dim idCliente = GetInsert(be)
    '        be.empresa.FirstOrDefault.idclientespk = idCliente.idclientespk
    '        be.empresa.FirstOrDefault.ruc = be.nroDoc
    '        empresaBL.InsertarEmpresaOne(be.empresa.FirstOrDefault,
    '                                  be.ListaMascaraContable2,
    '                                  be.ListaCuentaMascara,
    '                                  be.ListamascaraGastosEmpresa,
    '                                  be.ListacuentaplanContableEmpresa)

    '        be.IDProducto = be.IDProducto
    '        'LINEA INVALIDA     Dim ProductoAquirido = SeguridadproductoBL.GetListaProductoDetalleInicio(be.IDProducto)
    '        If ProductoAquirido.Count > 0 Then
    '            For Each s In ProductoAquirido
    '                asegurables = New Seguridad.Business.Entity.Asegurable
    '                asegurables.IDAsegurable = s.IDAsegurable
    '                asegurables.IDAsegurablePadre = s.IDAsegurablePadre
    '                asegurables.IDCliente = idCliente.idclientespk
    '                asegurables.Nombre = s.Nombre
    '                asegurables.Descripcion = s.Descripcion
    '                asegurables.CodRef = s.formulario
    '                asegurables.orden = s.orden
    '                asegurables.UsuarioActualizacion = "Sistema"
    '                asegurables.FechaActualizacion = DateTime.Now
    '                AsegurableBL.Insert(asegurables)
    '            Next
    '        End If
    '        Dim idRol = AutenticacionUsuarioBL.MappingUsuarioAdmin(idCliente.idclientespk)
    '        autorizacionRolBL.InsertarListaAsegurables(ProductoAquirido, idRol, idCliente.idclientespk)
    '    End If
    '    HeliosData.SaveChanges()
    '    'ts.Complete()
    '    'End Using
    'End Sub

    Private Function GetInsert(be As clientesSoftPack) As clientesSoftPack
        Using ts As New TransactionScope
            HeliosData.clientesSoftPack.Add(be)
            HeliosData.SaveChanges()
            ts.Complete()
            GetInsert = New clientesSoftPack
            GetInsert.idclientespk = be.idclientespk
            GetInsert.nroDoc = be.nroDoc
        End Using
    End Function

    Public Function ClientesSoftPackxAll() As List(Of clientesSoftPack)
        Return HeliosData.clientesSoftPack.OrderBy(Function(o) o.razonsocial).ToList
    End Function

    Public Function GetEmpresasClientes(rucCliente As String) As List(Of clientesSoftPack)
        Return HeliosData.clientesSoftPack.OrderBy(Function(o) o.razonsocial).Where(Function(o) o.nroDoc = rucCliente).ToList
    End Function

    Public Function GetProductoClientesXID(ClienteID As String) As clientesSoftPack
        Return HeliosData.clientesSoftPack.OrderBy(Function(o) o.IDProducto).Where(Function(o) o.idclientespk = ClienteID).FirstOrDefault
    End Function
End Class
