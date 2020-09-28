Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Imports System.Data.Entity
Imports Helios.General
Public Class distribucionInfraestructuraBL
    Inherits BaseBL

    Public Sub EliminarDistribucionFull(i As distribucionInfraestructura)
        Try
            Using ts As New TransactionScope
                Dim obj = (From n In HeliosData.distribucionInfraestructura
                           Where n.idEmpresa = i.idEmpresa And n.idEstablecimiento = i.idEstablecimiento).ToList

                For Each item In obj

                    Dim Consulta = (From n In HeliosData.componente
                                    Where n.idComponente = item.idComponente).FirstOrDefault
                    If (Not IsNothing(Consulta)) Then
                        Consulta.estado = "A"
                        HeliosData.SaveChanges()
                    End If
                    CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(item)
                Next
                HeliosData.SaveChanges()
                ts.Complete()

            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function getListaDistribucionInfraestructura(distribucionInfraestructuraBE As distribucionInfraestructura) As List(Of distribucionInfraestructura)
        Dim conteo As Integer = 0
        Dim obj As New distribucionInfraestructura
        Dim listaDistribucion As New List(Of distribucionInfraestructura)

        Dim consulta = (From a In HeliosData.infraestructura
                        Join b In HeliosData.infraestructura On a.idInfraestructura Equals CInt(b.idPadre)
                        Join c In HeliosData.infraestructura On b.idInfraestructura Equals CInt(c.idPadre)
                        Join dis In HeliosData.distribucionInfraestructura On c.idInfraestructura Equals CInt(dis.idInfraestructura)
                        Where dis.idEmpresa = distribucionInfraestructuraBE.idEmpresa And
                                dis.idEstablecimiento = distribucionInfraestructuraBE.idEstablecimiento
                        Select
                   bloque = a.nombre,
                    sector = b.nombre,
                    piso = c.nombre,
                    dis.descripcionDistribucion,
                    dis.numeracion,
                    dis.estado,
                    dis.idDistribucion).ToList

        For Each item In consulta
            obj = New distribucionInfraestructura
            obj.NombreBloque = item.bloque
            obj.NombreSector = item.sector
            obj.NombrePiso = item.piso
            obj.descripcionDistribucion = item.descripcionDistribucion
            obj.numeracion = item.numeracion
            obj.estado = item.estado
            obj.idDistribucion = item.idDistribucion
            listaDistribucion.Add(obj)
        Next
        Return listaDistribucion
    End Function


    Public Sub updateCategoriaXDistribucion(listaId As List(Of distribucionInfraestructura))
        Try
            Using ts As New TransactionScope

                For Each item In listaId
                    Dim obj = (From n In HeliosData.distribucionInfraestructura
                               Where n.idDistribucion = item.idDistribucion And n.idEmpresa = item.idEmpresa).FirstOrDefault

                    obj.idTipoServicio = item.idTipoServicio

                    HeliosData.SaveChanges()
                Next

                ts.Complete()

            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub EditarNumeracion(i As distribucionInfraestructura)
        Try
            Using ts As New TransactionScope
                Dim obj = (From n In HeliosData.distribucionInfraestructura
                           Where n.idDistribucion = i.idDistribucion And n.idEmpresa = i.idEmpresa).FirstOrDefault

                If (Not IsNothing(obj)) Then
                    obj.numeracion = i.numeracion
                    HeliosData.SaveChanges()
                End If

                ts.Complete()

            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function SaveDistribucionInfraestructuraFull(distribucion As distribucionInfraestructura, listaDistribucionInfraestructura As List(Of distribucionInfraestructura)) As Integer
        Dim obj As New distribucionInfraestructura()
        Dim componenteBL As New componenteBL
        Dim conteo As Integer = 0
        Try

            Using ts As New TransactionScope

                Dim consultas = (From a In HeliosData.distribucionInfraestructura
                                 Where a.tipo = distribucion.idComponente).ToList

                conteo = consultas.Count

                For Each i In listaDistribucionInfraestructura
                    conteo += 1

                    obj = New distribucionInfraestructura
                    obj.[idDistribucion] = i.idDistribucion
                    obj.[idEmpresa] = i.[idEmpresa]
                    obj.[idEstablecimiento] = i.[idEstablecimiento]
                    obj.[idComponente] = i.[idComponente]
                    obj.[idInfraestructura] = i.[idInfraestructura]
                    obj.[descripcionDistribucion] = i.[descripcionDistribucion]
                    obj.[glosario] = i.[glosario]
                    obj.[estado] = i.[estado]
                    obj.[tipo] = i.[tipo]
                    obj.numeracion = conteo
                    obj.[usuarioActualizacion] = i.[usuarioActualizacion]
                    obj.[fechaActualizacion] = i.[fechaActualizacion]
                    HeliosData.distribucionInfraestructura.Add(obj)
                    HeliosData.SaveChanges()

                    componenteBL.EditarComponenteXDistribucion(i.idComponente, "U")

                Next
                ts.Complete()
                Return obj.idDistribucion
            End Using

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function getDistribucionInfraestructuraXtipo(distribucionBE As distribucionInfraestructura) As List(Of distribucionInfraestructura)
        Try

            Dim conteo As Integer = 0
            Dim obj As New distribucionInfraestructura
            Dim ListaDistribucion As New List(Of distribucionInfraestructura)

            Dim consulta = HeliosData.ListaDistribucionInfraestructura(distribucionBE.idEmpresa,
                                                                       distribucionBE.idEstablecimiento,
                                                                        distribucionBE.tipo,
                                                                        distribucionBE.estado,
                                                                        distribucionBE.usuarioActualizacion,
                                                                          distribucionBE.descripcionDistribucion,
                                                                        distribucionBE.Categoria,
                                                                        distribucionBE.SubCategoria).ToList
            '                                                 
            For Each i In consulta
                obj = New distribucionInfraestructura
                obj.[idDistribucion] = i.idDistribucion
                obj.[idEmpresa] = i.[idEmpresa]
                obj.[idEstablecimiento] = i.[idEstablecimiento]
                obj.[idComponente] = i.[idComponente]
                obj.[idInfraestructura] = i.[idInfraestructura]
                obj.numeracion = i.numeracion
                obj.[descripcionDistribucion] = i.[descripcionDistribucion]
                obj.[glosario] = i.[glosario]
                obj.[estado] = i.[estado]
                obj.[tipo] = i.[tipo]
                obj.menor = i.precioXmenor.GetValueOrDefault
                obj.conteoPrecioMenor = i.CtaXCobrar.GetValueOrDefault
                obj.idTipoServicio = i.idTipoServicio
                'obj.idDocumento = i.iddocumento
                obj.[usuarioActualizacion] = i.descripcionTipoServicio
                ListaDistribucion.Add(obj)
            Next
            Return ListaDistribucion
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function

    Public Function getInfraestructura(distribucionBE As distribucionInfraestructura) As List(Of distribucionInfraestructura)
        Try

            Dim conteo As Integer = 0
            Dim obj As New distribucionInfraestructura
            Dim ListaDistribucion As New List(Of distribucionInfraestructura)

            Dim consulta = HeliosData.ListaInfraestructura(distribucionBE.idEmpresa,
                                                                       distribucionBE.idEstablecimiento,
                                                                        distribucionBE.tipo,
                                                                        distribucionBE.estado,
                                                                        distribucionBE.usuarioActualizacion,
                                                                          distribucionBE.descripcionDistribucion,
                                                                        distribucionBE.Categoria,
                                                                        distribucionBE.SubCategoria).ToList
            '                                                 
            For Each i In consulta
                obj = New distribucionInfraestructura
                obj.[idDistribucion] = i.idDistribucion
                obj.[idEmpresa] = i.[idEmpresa]
                obj.[idEstablecimiento] = i.[idEstablecimiento]
                obj.[idComponente] = i.[idComponente]
                obj.[idInfraestructura] = i.[idInfraestructura]
                obj.numeracion = i.numeracion
                obj.[descripcionDistribucion] = i.[descripcionDistribucion]
                obj.[glosario] = i.[glosario]
                obj.[estado] = i.[estado]
                obj.[tipo] = i.[tipo]
                obj.menor = i.precioXmenor.GetValueOrDefault
                obj.conteoPrecioMenor = i.CtaXCobrar.GetValueOrDefault
                obj.idTipoServicio = i.idTipoServicio
                obj.[usuarioActualizacion] = i.descripcionTipoServicio
                obj.Categoria = i.descripcionTipoServicio & " " & i.numeracion
                ListaDistribucion.Add(obj)
            Next
            Return ListaDistribucion
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function

    Public Function getDistribucionInfraHospedado(distribucionBE As distribucionInfraestructura) As List(Of distribucionInfraestructura)
        Try

            Dim conteo As Integer = 0
            Dim obj As New distribucionInfraestructura
            Dim ListaDistribucion As New List(Of distribucionInfraestructura)

            Dim consulta = HeliosData.ListaDistribucionInfraestructuraAndHospedados(distribucionBE.idEmpresa,
                                                                       distribucionBE.idEstablecimiento,
                                                                        distribucionBE.tipo,
                                                                        distribucionBE.estado,
                                                                        distribucionBE.usuarioActualizacion,
                                                                          distribucionBE.descripcionDistribucion,
                                                                        distribucionBE.Categoria,
                                                                        distribucionBE.SubCategoria).ToList
            '                                                 
            For Each i In consulta
                obj = New distribucionInfraestructura
                obj.[idDistribucion] = i.idDistribucion
                obj.[idEmpresa] = i.[idEmpresa]
                obj.[idEstablecimiento] = i.[idEstablecimiento]
                obj.[idComponente] = i.[idComponente]
                obj.[idInfraestructura] = i.[idInfraestructura]
                obj.numeracion = i.numeracion
                obj.[descripcionDistribucion] = i.[descripcionDistribucion]
                obj.[glosario] = i.[glosario]
                obj.[estado] = i.[estado]
                obj.[tipo] = i.[tipo]
                obj.menor = i.precioXmenor.GetValueOrDefault
                obj.conteoPrecioMenor = i.CtaXCobrar.GetValueOrDefault
                obj.idTipoServicio = i.idTipoServicio
                obj.conteoHospedados = i.ConteoHospedado
                obj.[usuarioActualizacion] = i.descripcionTipoServicio
                ListaDistribucion.Add(obj)
            Next
            Return ListaDistribucion
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function

    Public Function getDistribucionInfraestructuraXtipoInfra(distribucionInfraestructuraBE As distribucionInfraestructura) As List(Of distribucionInfraestructura)
        Try

            Dim conteo As Integer = 0
            Dim obj As New distribucionInfraestructura
            Dim ListaDistribucion As New List(Of distribucionInfraestructura)


            'Dim consulta = (From DISTRI In HeliosData.distribucionInfraestructura
            '                Group Join TIP In HeliosData.tipoServicioInfraestructura On CInt(DISTRI.idTipoServicio) Equals TIP.idTipoServicio Into TIP_join = Group
            '                From TIP In TIP_join.DefaultIfEmpty()
            '                Where DISTRI.idEmpresa = distribucionInfraestructuraBE.idEmpresa And
            '      DISTRI.idEstablecimiento = distribucionInfraestructuraBE.idEstablecimiento And
            '    DISTRI.idInfraestructura = CInt(distribucionInfraestructuraBE.idInfraestructura) And
            '        distribucionInfraestructuraBE.listaEstado.Contains(DISTRI.estado)
            '                Select
            '                                    DISTRI.idDistribucion,
            '                                    DISTRI.idEmpresa,
            '                                    DISTRI.idEstablecimiento,
            '                                    DISTRI.idComponente,
            '                                    DISTRI.idInfraestructura,
            '                                    DISTRI.descripcionDistribucion,
            '                                    DISTRI.glosario,
            '                                    DISTRI.estado,
            '                                    DISTRI.tipo,
            '                                    DISTRI.numeracion,
            '                                    DISTRI.directorio,
            '                                    DISTRI.logoID,
            '                                    DISTRI.usuarioActualizacion,
            '                                    DISTRI.fechaActualizacion,
            '                                    IdTipoServicio = CType(TIP.idTipoServicio, Int32?),
            '                     precioMenor = (((From configuracionPrecioProductoes
            '                                           In HeliosData.configuracionPrecioProducto
            '                                      Where
            '                      configuracionPrecioProductoes.idproducto = DISTRI.idDistribucion And
            '                      CLng(configuracionPrecioProductoes.idPrecio) = 1 And
            '                      configuracionPrecioProductoes.fecha =
            '                      (Aggregate t2 In
            '                           (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
            '                            Where
            '                                CLng(configuracionPrecioProductoes0.idPrecio) = 1 _
            '                                And configuracionPrecioProductoes0.idproducto = DISTRI.idDistribucion
            '                            Select configuracionPrecioProductoes0) Into Max(t2.fecha))
            '                                      Select New With
            '                      {
            '                      configuracionPrecioProductoes.precioMN
            '                      }).FirstOrDefault().precioMN)),
            '                                    DescripcionTipoServicio = TIP.descripcionTipoServicio,
            '                                              conteoVenta = (CType((Aggregate t1 In
            '                                                     (From doc In HeliosData.documentoventaAbarrotes
            '                                                      Where
            '                                                          doc.idDistribucion = DISTRI.idDistribucion And
            '                                                          doc.tipoVenta = "VNP"
            '                                                      Select New With {
            '                                                          doc.ImporteNacional
            '                                                          }) Into Sum(t1.ImporteNacional)), Decimal?))).ToList

            'Dim CONSULTA = (From DISTRI In HeliosData.distribucionInfraestructura
            '                Group Join TIP In HeliosData.tipoServicioInfraestructura On CInt(DISTRI.idTipoServicio) Equals TIP.idTipoServicio Into TIP_join = Group
            '                From TIP In TIP_join.DefaultIfEmpty()
            '                Where DISTRI.idEmpresa = distribucionInfraestructuraBE.idEmpresa And
            '                    DISTRI.idEstablecimiento = distribucionInfraestructuraBE.idEstablecimiento And
            '                    DISTRI.idInfraestructura = CInt(distribucionInfraestructuraBE.idInfraestructura) And
            '                    distribucionInfraestructuraBE.listaEstado.Contains(DISTRI.estado)
            '                Select
            '                    DISTRI.idDistribucion,
            '                    DISTRI.idEmpresa,
            '                    DISTRI.idEstablecimiento,
            '                    DISTRI.idComponente,
            '                    DISTRI.idInfraestructura,
            '                    DISTRI.descripcionDistribucion,
            '                    DISTRI.glosario,
            '                    DISTRI.estado,
            '                    DISTRI.tipo,
            '                    DISTRI.numeracion,
            '                    DISTRI.directorio,
            '                    DISTRI.logoID,
            '                    DISTRI.usuarioActualizacion,
            '                    DISTRI.fechaActualizacion,
            '                    IdTipoServicio = CType(TIP.idTipoServicio, Int32?),
            '                    precioMenor = (((From configuracionPrecioProductoes
            '                                           In HeliosData.configuracionPrecioProducto
            '                                     Where
            '                             configuracionPrecioProductoes.idproducto = DISTRI.idDistribucion And
            '                             CLng(configuracionPrecioProductoes.idPrecio) = 1 And
            '                             configuracionPrecioProductoes.fecha =
            '                             (Aggregate t2 In
            '                                  (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
            '                                   Where
            '                                       CLng(configuracionPrecioProductoes0.idPrecio) = 1 _
            '                                       And configuracionPrecioProductoes0.idproducto = DISTRI.idDistribucion
            '                                   Select configuracionPrecioProductoes0) Into Max(t2.fecha))
            '                                     Select New With
            '                             {
            '                             configuracionPrecioProductoes.precioMN
            '                             }).FirstOrDefault().precioMN)),
            '                                    DescripcionTipoServicio = TIP.descripcionTipoServicio,
            '                     conteoVenta = (CType((Aggregate t1 In
            '                                               (From DOC In HeliosData.documentoventaAbarrotesDet
            '                                                Where
            '                                                    DOC.idDistribucion = DISTRI.idDistribucion And
            '                                                    DOC.documentoventaAbarrotes.tipoVenta = "VNP"
            '                                                Select New With {
            '                                                    DOC.importeMN
            '                                                    }) Into Sum(t1.ImporteMN)), Decimal?))).ToList


            Dim consulta = HeliosData.ListaDistribucionInfraestructura(distribucionInfraestructuraBE.idEmpresa,
                                                                       distribucionInfraestructuraBE.idEstablecimiento,
                                                                       distribucionInfraestructuraBE.tipo,
                                                                       distribucionInfraestructuraBE.estado,
                                                                       distribucionInfraestructuraBE.usuarioActualizacion,
                                                                       distribucionInfraestructuraBE.descripcionDistribucion,
                                                                       distribucionInfraestructuraBE.Categoria,
                                                                       distribucionInfraestructuraBE.SubCategoria).ToList

            For Each i In consulta
                obj = New distribucionInfraestructura
                obj.[idDistribucion] = i.idDistribucion
                obj.[idEmpresa] = i.[idEmpresa]
                obj.[idEstablecimiento] = i.[idEstablecimiento]
                obj.[idComponente] = i.[idComponente]
                obj.[idInfraestructura] = i.[idInfraestructura]
                obj.numeracion = i.numeracion
                obj.[descripcionDistribucion] = i.[descripcionDistribucion]
                obj.[glosario] = i.[glosario]
                obj.[estado] = i.[estado]
                obj.[tipo] = i.[tipo]
                obj.menor = i.precioXmenor.GetValueOrDefault
                obj.conteoPrecioMenor = i.CtaXCobrar.GetValueOrDefault
                obj.idTipoServicio = i.IdTipoServicio
                obj.[usuarioActualizacion] = i.DescripcionTipoServicio
                ListaDistribucion.Add(obj)
            Next
            Return ListaDistribucion
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function

    Public Function getDistribucionXReserva(distribucionInfraestructuraBE As distribucionInfraestructura) As List(Of distribucionInfraestructura)
        Try

            Dim conteo As Integer = 0
            Dim obj As New distribucionInfraestructura
            Dim ListaDistribucion As New List(Of distribucionInfraestructura)

            Dim CONSULTA = (From DISTRI In HeliosData.distribucionInfraestructura
                            Group Join TIP In HeliosData.tipoServicioInfraestructura On CInt(DISTRI.idTipoServicio) Equals TIP.idTipoServicio Into TIP_join = Group
                            From TIP In TIP_join.DefaultIfEmpty()
                            Where DISTRI.idEmpresa = distribucionInfraestructuraBE.idEmpresa And
                                DISTRI.idEstablecimiento = distribucionInfraestructuraBE.idEstablecimiento And
                                distribucionInfraestructuraBE.listaEstado.Contains(DISTRI.idDistribucion)
                            Select
                                DISTRI.idDistribucion,
                                DISTRI.idEmpresa,
                                DISTRI.idEstablecimiento,
                                DISTRI.idComponente,
                                DISTRI.idInfraestructura,
                                DISTRI.descripcionDistribucion,
                                DISTRI.glosario,
                                DISTRI.estado,
                                DISTRI.tipo,
                                DISTRI.numeracion,
                                DISTRI.directorio,
                                DISTRI.logoID,
                                DISTRI.usuarioActualizacion,
                                DISTRI.fechaActualizacion,
                                IdTipoServicio = CType(TIP.idTipoServicio, Int32?),
                                precioMenor = (((From configuracionPrecioProductoes
                                                       In HeliosData.configuracionPrecioProducto
                                                 Where
                                         configuracionPrecioProductoes.idproducto = DISTRI.idDistribucion And
                                         CLng(configuracionPrecioProductoes.idPrecio) = 1 And
                                         configuracionPrecioProductoes.fecha =
                                         (Aggregate t2 In
                                              (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                               Where
                                                   CLng(configuracionPrecioProductoes0.idPrecio) = 1 _
                                                   And configuracionPrecioProductoes0.idproducto = DISTRI.idDistribucion
                                               Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                                                 Select New With
                                         {
                                         configuracionPrecioProductoes.precioMN
                                         }).FirstOrDefault().precioMN)),
                                                DescripcionTipoServicio = TIP.descripcionTipoServicio,
                                 conteoVenta = (CType((Aggregate t1 In
                                                           (From DOC In HeliosData.documentoventaAbarrotesDet
                                                            Where
                                                                DOC.idDistribucion = DISTRI.idDistribucion And
                                                                DOC.documentoventaAbarrotes.tipoVenta = "VNP"
                                                            Select New With {
                                                                DOC.importeMN
                                                                }) Into Sum(t1.importeMN)), Decimal?)),
                                 conteoHospedados = (CType((Aggregate t1 In
                                                           (From DOC In HeliosData.personaBeneficio
                                                            Where
                                                                DOC.idDistribucion = DISTRI.idDistribucion And
                                                                DOC.estado = "A" And
                                                                DOC.idDocumento = distribucionInfraestructuraBE.idInfraestructura
                                                            Select New With {
                                                                DOC.idPersonaBeneficio
                                                                }) Into Count(t1.idPersonaBeneficio)), Decimal?))).ToList

            For Each i In CONSULTA
                obj = New distribucionInfraestructura
                obj.[idDistribucion] = i.idDistribucion
                obj.[idEmpresa] = i.[idEmpresa]
                obj.[idEstablecimiento] = i.[idEstablecimiento]
                obj.[idComponente] = i.[idComponente]
                obj.[idInfraestructura] = i.[idInfraestructura]
                obj.numeracion = i.numeracion
                obj.[descripcionDistribucion] = i.[descripcionDistribucion]
                obj.[glosario] = i.[glosario]
                obj.[estado] = i.[estado]
                obj.[tipo] = i.[tipo]
                obj.menor = i.precioMenor
                obj.conteoPrecioMenor = i.conteoVenta.GetValueOrDefault
                obj.idTipoServicio = i.IdTipoServicio
                obj.conteoHospedados = i.conteoHospedados.GetValueOrDefault
                obj.[usuarioActualizacion] = i.DescripcionTipoServicio
                ListaDistribucion.Add(obj)
            Next
            Return ListaDistribucion
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function

    Public Function getDistribucionInfraestructuraXCategoria(distribucionInfraestructuraBE As distribucionInfraestructura) As List(Of distribucionInfraestructura)
        Try

            Dim conteo As Integer = 0
            Dim obj As New distribucionInfraestructura
            Dim ListaDistribucion As New List(Of distribucionInfraestructura)


            'Dim consulta = (From DISTRI In HeliosData.distribucionInfraestructura
            '                Group Join TIP In HeliosData.tipoServicioInfraestructura On CInt(DISTRI.idTipoServicio) Equals TIP.idTipoServicio Into TIP_join = Group
            '                From TIP In TIP_join.DefaultIfEmpty()
            '                Where DISTRI.idEmpresa = distribucionInfraestructuraBE.idEmpresa And
            '                    DISTRI.idEstablecimiento = distribucionInfraestructuraBE.idEstablecimiento And
            '                    DISTRI.idTipoServicio = CInt(distribucionInfraestructuraBE.idTipoServicio) And
            '                    distribucionInfraestructuraBE.listaEstado.Contains(DISTRI.estado)
            '                Select
            '                     DISTRI.idDistribucion,
            '                     DISTRI.idEmpresa,
            '                     DISTRI.idEstablecimiento,
            '                     DISTRI.idComponente,
            '                     DISTRI.idInfraestructura,
            '                     DISTRI.descripcionDistribucion,
            '                     DISTRI.glosario,
            '                     DISTRI.estado,
            '                     DISTRI.tipo,
            '                     DISTRI.numeracion,
            '                     DISTRI.directorio,
            '                     DISTRI.logoID,
            '                     DISTRI.usuarioActualizacion,
            '                     DISTRI.fechaActualizacion,
            '                     IdTipoServicio = CType(TIP.idTipoServicio, Int32?),
            '                       precioMenor = (((From configuracionPrecioProductoes
            '                                            In HeliosData.configuracionPrecioProducto
            '                                        Where
            '                        configuracionPrecioProductoes.idproducto = DISTRI.idDistribucion And
            '                        CLng(configuracionPrecioProductoes.idPrecio) = 1 And
            '                        configuracionPrecioProductoes.fecha =
            '                        (Aggregate t2 In
            '                             (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
            '                              Where
            '                                  CLng(configuracionPrecioProductoes0.idPrecio) = 1 _
            '                                  And configuracionPrecioProductoes0.idproducto = DISTRI.idDistribucion
            '                              Select configuracionPrecioProductoes0) Into Max(t2.fecha))
            '                                        Select New With
            '                        {
            '                        configuracionPrecioProductoes.precioMN
            '                        }).FirstOrDefault().precioMN)),
            '                                     DescripcionTipoServicio = TIP.descripcionTipoServicio,
            '                      conteoVenta = (CType((Aggregate t1 In
            '                                               (From DOC In HeliosData.documentoventaAbarrotesDet
            '                                                Where
            '                                                    DOC.idDistribucion = DISTRI.idDistribucion And
            '                                                    DOC.documentoventaAbarrotes.tipoVenta = "VNP"
            '                                                Select New With {
            '                                                    DOC.importeMN
            '                                                    }) Into Sum(t1.importeMN)), Decimal?))).ToList

            Dim consulta = HeliosData.ListaDistribucionInfraestructura(distribucionInfraestructuraBE.idEmpresa,
                                                                       distribucionInfraestructuraBE.idEstablecimiento,
                                                                        distribucionInfraestructuraBE.tipo,
                                                                        distribucionInfraestructuraBE.estado,
                                                                        distribucionInfraestructuraBE.usuarioActualizacion,
                                                                          distribucionInfraestructuraBE.descripcionDistribucion,
                                                                        distribucionInfraestructuraBE.Categoria,
                                                                        distribucionInfraestructuraBE.SubCategoria).ToList


            For Each i In consulta
                obj = New distribucionInfraestructura
                obj.[idDistribucion] = i.idDistribucion
                obj.[idEmpresa] = i.[idEmpresa]
                obj.[idEstablecimiento] = i.[idEstablecimiento]
                obj.[idComponente] = i.[idComponente]
                obj.[idInfraestructura] = i.[idInfraestructura]
                obj.numeracion = i.numeracion
                obj.[descripcionDistribucion] = i.[descripcionDistribucion]
                obj.[glosario] = i.[glosario]
                obj.[estado] = i.[estado]
                obj.[tipo] = i.[tipo]
                obj.menor = i.precioXmenor.GetValueOrDefault
                obj.conteoPrecioMenor = i.CtaXCobrar.GetValueOrDefault
                obj.idTipoServicio = i.IdTipoServicio
                obj.[usuarioActualizacion] = i.DescripcionTipoServicio
                ListaDistribucion.Add(obj)
            Next
            Return ListaDistribucion
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function


    Public Function updateDistribucionxID(i As distribucionInfraestructura) As distribucionInfraestructura
        Try
            Using ts As New TransactionScope
                Dim obj = (From n In HeliosData.distribucionInfraestructura
                           Where n.idDistribucion = i.idDistribucion And n.idEmpresa = i.idEmpresa).FirstOrDefault

                obj.[estado] = i.estado

                HeliosData.SaveChanges()
                ts.Complete()

                Return obj
            End Using

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function updateDistribucionXCondicion(i As distribucionInfraestructura) As distribucionInfraestructura
        Try
            Using ts As New TransactionScope

                Dim conteoPendiente = (HeliosData.documentoventaAbarrotesDet.Where(Function(n) n.idDistribucion = i.idDistribucion And n.estadoDistribucion = "A").Count(Function(o) o.idDocumento))

                If (conteoPendiente = 0) Then
                    Dim obj = (From n In HeliosData.distribucionInfraestructura
                               Where n.idDistribucion = i.idDistribucion And n.idEmpresa = i.idEmpresa).FirstOrDefault

                    obj.[estado] = i.estado

                    HeliosData.SaveChanges()

                    ts.Complete()
                End If

                Return Nothing
            End Using

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Sub updateDistribucionMasivo(listaID As distribucionInfraestructura)
        Try
            Using ts As New TransactionScope

                For Each item In listaID.listaEstado
                    Dim obj = (From n In HeliosData.distribucionInfraestructura
                               Where n.idDistribucion = item And n.idEmpresa = listaID.idEmpresa).FirstOrDefault
                    obj.[estado] = listaID.estado
                    HeliosData.SaveChanges()
                Next

                ts.Complete()

            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function updateDistribucionRecepcionMasivo(listaID As List(Of distribucionInfraestructura)) As List(Of distribucionInfraestructura)
        Try
            Dim listaInfra As New List(Of distribucionInfraestructura)
            Dim infraBE As New distribucionInfraestructura
            Using ts As New TransactionScope

                For Each item In listaID
                    Dim obj = (From n In HeliosData.distribucionInfraestructura
                               Where n.idDistribucion = item.idDistribucion And n.idEmpresa = item.idEmpresa).FirstOrDefault
                    obj.[estado] = item.estado
                    HeliosData.SaveChanges()

                    infraBE = New distribucionInfraestructura
                    infraBE.[idDistribucion] = obj.idDistribucion
                    infraBE.[idEmpresa] = obj.[idEmpresa]
                    infraBE.[idEstablecimiento] = obj.[idEstablecimiento]
                    infraBE.[idComponente] = obj.[idComponente]
                    infraBE.[idInfraestructura] = obj.[idInfraestructura]
                    infraBE.numeracion = obj.numeracion
                    infraBE.[descripcionDistribucion] = obj.[descripcionDistribucion]
                    infraBE.[glosario] = obj.[glosario]
                    infraBE.[estado] = obj.[estado]
                    infraBE.[tipo] = obj.[tipo]
                    infraBE.idTipoServicio = obj.idTipoServicio
                    infraBE.menor = item.menor
                    listaInfra.Add(infraBE)

                Next

                ts.Complete()
                Return listaInfra
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Sub updateDistribucioRecepciomMasivo(listaID As distribucionInfraestructura)
        Try
            Dim documentoBL As New documentoBL
            Dim documentobe As New documento

            Using ts As New TransactionScope

                For Each item In listaID.listaEstado
                    Dim obj = (From n In HeliosData.distribucionInfraestructura
                               Where n.idDistribucion = item And n.idEmpresa = listaID.idEmpresa).FirstOrDefault
                    obj.[estado] = listaID.estado
                    HeliosData.SaveChanges()
                Next
                'documentobe.idDocumento = listaID.idInfraestructura

                'documentoBL.DeleteSingle(documentobe)
                ts.Complete()

            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function updateDistribucionXRecepcion(listaID As List(Of distribucionInfraestructura)) As List(Of distribucionInfraestructura)
        Try
            Dim listaInfra As New List(Of distribucionInfraestructura)
            Dim infraBE As New distribucionInfraestructura

            Using ts As New TransactionScope

                For Each item In listaID
                    For index As Integer = 1 To item.numeracion
                        Dim UpdateInfra = (From dis In HeliosData.distribucionInfraestructura
                                           Group Join ser In HeliosData.tipoServicioInfraestructura On CInt(dis.idTipoServicio) Equals ser.idTipoServicio Into ser_join = Group
                                           From ser In ser_join.DefaultIfEmpty()
                                           Where dis.estado = "A" And ser.descripcionTipoServicio = item.TipoExistencia
                                           Select
                                   dis.idDistribucion,
                                   dis.idEmpresa,
                                   dis.idEstablecimiento,
                                   dis.idComponente,
                                   dis.idInfraestructura,
                                   IdTipoServicio = CType(dis.idTipoServicio, Int32?),
                                   dis.descripcionDistribucion,
                                   dis.glosario,
                                   dis.estado,
                                   dis.tipo,
                                   dis.numeracion,
                                   dis.directorio,
                                    dis.logoID,
                                       dis.usuarioActualizacion,
                                   dis.fechaActualizacion,
                                   DescripcionTipoServicio = ser.descripcionTipoServicio,
                                                precioMenor = (
                            ((From
                                  configuracionPrecioProductoes
                                  In HeliosData.configuracionPrecioProducto
                              Where
                                  configuracionPrecioProductoes.idproducto = dis.idDistribucion And
                                  CLng(configuracionPrecioProductoes.idPrecio) = 1 And
                                  configuracionPrecioProductoes.fecha =
                                  (Aggregate t2 In
                                       (From configuracionPrecioProductoes0 In HeliosData.configuracionPrecioProducto
                                        Where
                                            CLng(configuracionPrecioProductoes0.idPrecio) = 1 _
                                            And configuracionPrecioProductoes0.idproducto = dis.idDistribucion
                                        Select configuracionPrecioProductoes0) Into Max(t2.fecha))
                              Select New With
                                  {
                                  configuracionPrecioProductoes.precioMN
                                  }).FirstOrDefault().precioMN))).FirstOrDefault

                        Dim obj = (From n In HeliosData.distribucionInfraestructura
                                   Where n.estado = "A" And n.idTipoServicio = UpdateInfra.IdTipoServicio).FirstOrDefault

                        obj.[estado] = "U"
                        HeliosData.SaveChanges()

                        infraBE = New distribucionInfraestructura
                        infraBE.[idDistribucion] = obj.idDistribucion
                        infraBE.[idEmpresa] = obj.[idEmpresa]
                        infraBE.[idEstablecimiento] = obj.[idEstablecimiento]
                        infraBE.[idComponente] = obj.[idComponente]
                        infraBE.[idInfraestructura] = obj.[idInfraestructura]
                        infraBE.numeracion = obj.numeracion
                        infraBE.[descripcionDistribucion] = obj.[descripcionDistribucion]
                        infraBE.[glosario] = obj.[glosario]
                        infraBE.[estado] = obj.[estado]
                        infraBE.[tipo] = obj.[tipo]
                        infraBE.idTipoServicio = obj.idTipoServicio
                        infraBE.menor = UpdateInfra.precioMenor
                        listaInfra.Add(infraBE)
                    Next
                Next

                ts.Complete()
                Return listaInfra
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Sub EditarOcupacionInfra(i As ocupacionInfraestructura)
        Try
            Using ts As New TransactionScope
                Dim obj = (From n In HeliosData.distribucionInfraestructura Where i.listaId.Contains(n.idDistribucion)).ToList

                For Each ITEM In obj
                    ITEM.estado = "A"
                    HeliosData.SaveChanges()
                Next

                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function GetDistribucionInfraestructuraConPrecios(empresa As String, tipo As String) As List(Of distribucionInfraestructura)
        Dim obj As New distribucionInfraestructura
        Dim Lista As New List(Of distribucionInfraestructura)

        'Dim consulta = (From art In HeliosData.distribucionInfraestructura
        '                Join inf In HeliosData.infraestructura On CInt(art.idInfraestructura) Equals CInt(inf.idInfraestructura)
        '                Where
        '                  art.idEmpresa = empresa And
        '                    inf.tipo = "P"
        '                Order By
        '                  art.descripcionDistribucion
        '                Select
        '                  art.idEmpresa,
        '                  art.idEstablecimiento,
        '                  art.idDistribucion,
        '                  art.descripcionDistribucion,
        '                  art.numeracion,
        '                    inf.nombre,
        '                  menor = (
        '                    ((From S In HeliosData.configuracionPrecioProducto
        '                      Where
        '                      art.idDistribucion = S.idproducto And
        '                      CLng(S.idPrecio) = 1 And
        '                      S.fecha = (Aggregate t1 In
        '                        (From ConfiguracionPrecioProducto In HeliosData.configuracionPrecioProducto
        '                         Where
        '                          CLng(ConfiguracionPrecioProducto.idPrecio) = 1 And
        '                          ConfiguracionPrecioProducto.idproducto = S.idproducto And
        '                          ConfiguracionPrecioProducto.tipoModalidad = "IF"
        '                         Select New With {
        '                          ConfiguracionPrecioProducto.fecha
        '                        }) Into Max(t1.fecha))
        '                      Select New With {
        '                      S.precioMN
        '                    }).Take(1).FirstOrDefault().precioMN)),
        '                  mayor = (
        '                    ((From S In HeliosData.configuracionPrecioProducto
        '                      Where
        '                      art.idDistribucion = S.idproducto And
        '                      S.tipoModalidad = "IF" And
        '                      CLng(S.idPrecio) = 2 And
        '                      S.fecha = (Aggregate t1 In
        '                        (From ConfiguracionPrecioProducto In HeliosData.configuracionPrecioProducto
        '                         Where
        '                          CLng(ConfiguracionPrecioProducto.idPrecio) = 2 And
        '                          ConfiguracionPrecioProducto.idproducto = S.idproducto
        '                         Select New With {
        '                          ConfiguracionPrecioProducto.fecha
        '                        }) Into Max(t1.fecha))
        '                      Select New With {
        '                      S.precioMN
        '                    }).Take(1).FirstOrDefault().precioMN)),
        '                  granMayor = (
        '                    ((From S In HeliosData.configuracionPrecioProducto
        '                      Where
        '                      art.idDistribucion = S.idproducto And
        '                      S.tipoModalidad = "IF" And
        '                      CLng(S.idPrecio) = 3 And
        '                      S.fecha = (Aggregate t1 In
        '                        (From ConfiguracionPrecioProducto In HeliosData.configuracionPrecioProducto
        '                         Where
        '                          CLng(ConfiguracionPrecioProducto.idPrecio) = 3 And
        '                          ConfiguracionPrecioProducto.idproducto = S.idproducto
        '                         Select New With {
        '                          ConfiguracionPrecioProducto.fecha
        '                        }) Into Max(t1.fecha))
        '                      Select New With {
        '                      S.precioMN
        '                    }).Take(1).FirstOrDefault().precioMN))).ToList


        Dim CONSULTA = (From DIS In HeliosData.distribucionInfraestructura
                        Group Join TIP In HeliosData.tipoServicioInfraestructura On CInt(DIS.idTipoServicio) Equals TIP.idTipoServicio Into TIP_join = Group
                        From TIP In TIP_join.DefaultIfEmpty()
                        Group Join CAT In HeliosData.categoriaInfraestructura On CInt(TIP.idCategoria) Equals CAT.idCategoria Into CAT_join = Group
                        From CAT In CAT_join.DefaultIfEmpty()
                        Where
                          DIS.idEmpresa = empresa And
                            DIS.infraestructura.tipo = "P"
                        Order By
                          DIS.descripcionDistribucion
                        Select
                            DIS.idEmpresa,
                            DIS.idEstablecimiento,
                            DIS.idDistribucion,
                            DIS.descripcionDistribucion,
                            DIS.numeracion,
                            DescripcionTipoServicio = TIP.descripcionTipoServicio,
                            DescripcionInfraestructura = CAT.descripcionInfraestructura,
                            DIS.infraestructura.nombre,
                     menor = (
                            ((From S In HeliosData.configuracionPrecioProducto
                              Where
                              DIS.idDistribucion = S.idproducto And
                              CLng(S.idPrecio) = 1 And
                              S.fecha = (Aggregate t1 In
                                (From ConfiguracionPrecioProducto In HeliosData.configuracionPrecioProducto
                                 Where
                                  CLng(ConfiguracionPrecioProducto.idPrecio) = 1 And
                                  ConfiguracionPrecioProducto.idproducto = S.idproducto And
                                  ConfiguracionPrecioProducto.tipoModalidad = "IF"
                                 Select New With {
                                  ConfiguracionPrecioProducto.fecha
                                }) Into Max(t1.fecha))
                              Select New With {
                              S.precioMN
                            }).Take(1).FirstOrDefault().precioMN)),
                          mayor = (
                            ((From S In HeliosData.configuracionPrecioProducto
                              Where
                              DIS.idDistribucion = S.idproducto And
                              S.tipoModalidad = "IF" And
                              CLng(S.idPrecio) = 2 And
                              S.fecha = (Aggregate t1 In
                                (From ConfiguracionPrecioProducto In HeliosData.configuracionPrecioProducto
                                 Where
                                  CLng(ConfiguracionPrecioProducto.idPrecio) = 2 And
                                  ConfiguracionPrecioProducto.idproducto = S.idproducto
                                 Select New With {
                                  ConfiguracionPrecioProducto.fecha
                                }) Into Max(t1.fecha))
                              Select New With {
                              S.precioMN
                            }).Take(1).FirstOrDefault().precioMN)),
                          granMayor = (
                            ((From S In HeliosData.configuracionPrecioProducto
                              Where
                              DIS.idDistribucion = S.idproducto And
                              S.tipoModalidad = "IF" And
                              CLng(S.idPrecio) = 3 And
                              S.fecha = (Aggregate t1 In
                                (From ConfiguracionPrecioProducto In HeliosData.configuracionPrecioProducto
                                 Where
                                  CLng(ConfiguracionPrecioProducto.idPrecio) = 3 And
                                  ConfiguracionPrecioProducto.idproducto = S.idproducto
                                 Select New With {
                                  ConfiguracionPrecioProducto.fecha
                                }) Into Max(t1.fecha))
                              Select New With {
                              S.precioMN
                            }).Take(1).FirstOrDefault().precioMN))).ToList


        Dim ValorprecioMenorMN As Decimal = 0
        Dim ValorprecioMenorME As Decimal = 0
        Dim ValorprecioMayorMN As Decimal = 0
        Dim ValorprecioMayorME As Decimal = 0
        Dim ValorprecioGMayorMN As Decimal = 0
        Dim ValorprecioGMayorME As Decimal = 0
        For Each i In CONSULTA
            obj = New distribucionInfraestructura

            '   Dim valorNulo() As String = {"0.00", "0.00"}
            Dim precMenor As String = i.menor.GetValueOrDefault
            Dim precMayor As String = i.mayor.GetValueOrDefault
            Dim precGMayor As String = i.granMayor.GetValueOrDefault


            If precMenor IsNot Nothing Then
                'datosPreciosMenor = precMenor.Split(New Char() {"|"c})
                ValorprecioMenorMN = precMenor
                ValorprecioMenorME = 0
            Else
                ValorprecioMenorMN = 0
                ValorprecioMenorME = 0
            End If

            If precMayor IsNot Nothing Then
                'datosPreciosMayor = precMayor.Split(New Char() {"|"c})
                ValorprecioMayorMN = precMayor ' datosPreciosMayor(0)
                ValorprecioMayorME = 0
            Else
                ValorprecioMayorMN = 0
                ValorprecioMayorME = 0
            End If

            If precGMayor IsNot Nothing Then
                'datosPreciosGranMenor = precGMayor.Split(New Char() {"|"c})
                ValorprecioGMayorMN = precGMayor ' datosPreciosGranMenor(0)
                ValorprecioGMayorME = 0
            Else
                ValorprecioGMayorMN = 0
                ValorprecioGMayorME = 0
            End If


            obj.idDistribucion = i.idDistribucion
            obj.descripcionDistribucion = i.descripcionDistribucion & " " & i.numeracion
            obj.Categoria = i.DescripcionInfraestructura
            obj.SubCategoria = i.DescripcionTipoServicio
            'obj.codigo = i.codigo
            obj.TipoExistencia = "IF"
            obj.unidadMedida = "UND"
            'obj.unidad2 = i.MarcaName
            'obj.presentacion = String.Empty 'i.presentacion
            obj.Codigo = 1
            'obj.precioCompra = i.precioCompra
            obj.menor = ValorprecioMenorMN ' i.menor.GetValueOrDefault '  i.precioMenor.GetValueOrDefault
            obj.mayor = ValorprecioMayorMN ' i.mayor.GetValueOrDefault ' i.PrecioMayor.GetValueOrDefault
            obj.gMayor = ValorprecioGMayorMN ' i.granMayor.GetValueOrDefault ' i.PrecioGranMayor.GetValueOrDefault

            obj.menorME = ValorprecioMenorME ' 0 ' i.precioMenorME.GetValueOrDefault
            obj.mayorME = ValorprecioMayorME '0 ' i.PrecioMayorME.GetValueOrDefault
            obj.gMayorME = ValorprecioGMayorME ' 0 ' i.PrecioGranMayorME.GetValueOrDefault
            obj.NombrePiso = i.nombre

            Lista.Add(obj)
        Next

        Return Lista
    End Function


    Public Function GetDistribucionXAgrupacion() As List(Of distribucionInfraestructura)
        Dim obj As New distribucionInfraestructura
        Dim Lista As New List(Of distribucionInfraestructura)

        Dim consulta = (From dis In HeliosData.distribucionInfraestructura
                        Where
                            dis.estado = "A"
                        Group New With {dis.tipoServicioInfraestructura, dis} By dis.tipoServicioInfraestructura.descripcionTipoServicio Into g = Group
                        Select
                            descripcionTipoServicio,
                            disponibleHabitacion = CType(g.Count(Function(p) p.dis.idInfraestructura >= 1), Int64?)).ToList

        For Each i In CONSULTA
            obj = New distribucionInfraestructura
            If (Not IsNothing(i.descripcionTipoServicio)) Then
                obj.descripcionDistribucion = i.descripcionTipoServicio
                obj.numeracion = i.disponibleHabitacion
            Else
                obj.descripcionDistribucion = "SIN DETERMINAR"
                obj.numeracion = i.disponibleHabitacion
            End If
            Lista.Add(obj)
        Next

        Return Lista
    End Function

    Public Function GetDashboardDistribucion(documentoventaBE As documentoventaAbarrotes) As List(Of distribucionInfraestructura)
        Dim obj As New distribucionInfraestructura
        Dim Lista As New List(Of distribucionInfraestructura)
        Dim listaAnt As New List(Of String)
        listaAnt.Add(Anticipo.Estado.NotaCredito)
        listaAnt.Add(Anticipo.Estado.NotaCreditoParcial)

        Dim ventas = (From DET In HeliosData.documentoventaAbarrotesDet
                      Where
                          documentoventaBE.ListaEstado.Contains(DET.idDistribucion) And
                          DET.estadoDistribucion = "A"
                      Group DET.documentoventaAbarrotes By DET.documentoventaAbarrotes.idEmpresa Into g = Group
                      Select
     VentaTotal = (CType((Aggregate t1 In
                     (From DET2 In HeliosData.documentoventaAbarrotesDet
                      Where
                       documentoventaBE.ListaEstado.Contains(DET2.idDistribucion) And
                          DET2.estadoDistribucion = "A"
                      Select New With {
                          DET2.importeMN
                          }) Into Sum(t1.importeMN)), Decimal?)),
     PedidosPendientes = (CType((Aggregate t1 In
                     (From DOC3 In HeliosData.documentoventaAbarrotes
                      Join det3 In HeliosData.documentoventaAbarrotesDet On DOC3.idDocumento Equals det3.idDocumento
                      Where
                            det3.estadoEntrega = "PN" And
                          documentoventaBE.ListaEstado.Contains(det3.idDistribucion) And
                          det3.estadoDistribucion = "A"
                      Select New With {
                          det3.idDocumento
                          }) Into Count()), Int64?)),
      VentaCredito = (CType((Aggregate t1 In
                     (From DET1 In HeliosData.documentoventaAbarrotesDet
                      Where
                          DET1.documentoventaAbarrotes.estadoCobro = "PN" And
                          DET1.documentoventaAbarrotes.tipoVenta = "VNP" And
                          documentoventaBE.ListaEstado.Contains(DET1.idDistribucion) And
                          DET1.estadoDistribucion = "A"
                      Select New With {
                          DET1.importeMN
                          }) Into Sum(t1.importeMN)), Decimal?)),
     CtasXCobrar = (CType((Aggregate t1 In
                    (From CDET In HeliosData.documentoCajaDetalle
                     Where
                         CDET.documentoCaja.movimientoCaja = "CCR" And
                          CLng(CDET.documentoCaja.codigoProveedor) = documentoventaBE.idCliente
                     Select New With {
                         CDET.montoSoles
                         }) Into Sum(t1.montoSoles)), Decimal?)),
    VentasCtasXCobrar = (CType((Aggregate t1 In
                   (From DET1 In HeliosData.documentoventaAbarrotesDet
                    Where
                        DET1.documentoventaAbarrotes.terminos = "CREDITO" And
                        DET1.documentoventaAbarrotes.tipoVenta = "VELC" And
                         documentoventaBE.ListaEstado.Contains(DET1.idDistribucion) And
                          DET1.estadoDistribucion = "A"
                    Select New With {
                        DET1.importeMN
                        }) Into Sum(t1.importeMN)), Decimal?)),
    AnticiposRecibidos = (CType((Aggregate t1 In
                   (From ant In HeliosData.documentoAnticipo
                    Where
                        CLng(ant.razonSocial) = documentoventaBE.idCliente And
                         listaAnt.Contains(ant.estado)
                    Select New With {
                        ant.importeMN
                        }) Into Sum(t1.importeMN)), Decimal?)),
    AnticipoDevolucion = (CType((Aggregate t1 In
                  (From doc5 In HeliosData.documentoventaAbarrotes
                   Where
                       CLng(doc5.idCliente) = documentoventaBE.idCliente And
                       doc5.tipoVenta = "VNCA" And
                       doc5.estadoCobro = "PN"
                   Select New With {
                       doc5.ImporteNacional
                       }) Into Sum(t1.ImporteNacional)), Decimal?)),
  reclamacion = (CType((Aggregate t1 In
                            (From doc6 In HeliosData.documentoventaAbarrotes
                             Where
                                 CLng(doc6.idCliente) = documentoventaBE.idCliente And
                                 doc6.tipoVenta = "VNCA" And
                                 doc6.estadoCobro = "SOD"
                             Select New With {
                                 doc6.ImporteNacional
                                 }) Into Sum(t1.ImporteNacional)), Decimal?)),
                          idEmpresa).ToList


        obj = New distribucionInfraestructura
            For Each i In ventas
            obj.ctaXCobrar = CDec(i.VentasCtasXCobrar.GetValueOrDefault - i.CtasXCobrar.GetValueOrDefault)
            obj.conteoPedidoPendiente = i.PedidosPendientes.GetValueOrDefault
            obj.VentaCredito = i.VentaCredito.GetValueOrDefault
            obj.VentaTotal = i.VentaTotal.GetValueOrDefault
            obj.VentaXCtasXCobrar = i.VentasCtasXCobrar.GetValueOrDefault
            obj.AnticiposRecibidos = i.AnticiposRecibidos.GetValueOrDefault
            obj.Devolucion = i.AnticipoDevolucion.GetValueOrDefault
            obj.Reclamaciones = i.reclamacion.GetValueOrDefault
        Next


        Lista.Add(obj)

            Return Lista
    End Function

    Public Function GetDashBoardXCliente(documentoBE As documentoventaAbarrotes) As List(Of distribucionInfraestructura)
        Dim obj As New distribucionInfraestructura
        Dim Lista As New List(Of distribucionInfraestructura)
        Dim listaID As New List(Of String)
        Dim HAbitacion = (From docdet In HeliosData.documentoventaAbarrotesDet
                          Join ent In HeliosData.entidad On CType(CInt(docdet.documentoventaAbarrotes.idCliente), Int32?) Equals ent.idEntidad
                          Join inf In HeliosData.distribucionInfraestructura On CInt(docdet.idDistribucion) Equals inf.idDistribucion
                          Where
                              ent.idEntidad = documentoBE.idCliente And
                              docdet.estadoDistribucion = documentoBE.estado And
                              docdet.tipoExistencia = "IF"
                          Select
   ConteoTotalHabitacion = (CType((Aggregate t1 In
                               (From det In HeliosData.documentoventaAbarrotesDet
                                Where
                                    det.tipoExistencia = "IF" And
                                    det.idDocumento = docdet.documentoventaAbarrotes.idDocumento
                                Select New With {
                                    det.idDocumento
                                    }) Into Count()), Int64?)),
    ConteoTotalHospedados = (CType((Aggregate t1 In
                         (From per In HeliosData.personaBeneficio
                          Where
                              per.secuencia = docdet.secuencia And
                              per.idDocumento = docdet.idDocumento
                          Select New With {
                              per.idPersonaBeneficio
                              }) Into Count()), Int64?)),
                                IdDistribucion = CType(docdet.idDistribucion, Int32?),
                                inf.descripcionDistribucion,
                                inf.numeracion,
                                docdet.idDocumento,
                                docdet.secuencia).ToList


        obj = New distribucionInfraestructura
        Dim CONTEO As Integer = 0
        For Each x In HAbitacion
            If (x.ConteoTotalHabitacion = 1) Then
                obj.conteoHabitaciones = x.ConteoTotalHabitacion.GetValueOrDefault
                obj.conteoHospedados = x.ConteoTotalHospedados.GetValueOrDefault
                obj.idDocumento = x.idDocumento
                obj.idDistribucion = x.IdDistribucion
                obj.numeracion = x.numeracion
                obj.secuencia = x.secuencia
                obj.tipo = 1
                listaID.Add(x.IdDistribucion)
                obj.listaEstado = listaID
            ElseIf (x.ConteoTotalHabitacion > 1) Then
                obj.conteoHabitaciones = x.ConteoTotalHabitacion.GetValueOrDefault
                For Each Z In HAbitacion
                    CONTEO += Z.ConteoTotalHospedados.GetValueOrDefault
                    listaID.Add(Z.IdDistribucion)
                Next
                obj.idDistribucion = x.IdDistribucion
                obj.conteoHospedados = CONTEO
                obj.listaEstado = listaID
                obj.tipo = 2
            End If
            Exit For
        Next

        Lista.Add(obj)

        Return Lista
    End Function


    Public Function GetDetalleHabitacion(documentoBE As documentoventaAbarrotes) As List(Of distribucionInfraestructura)
        Dim infraBE As distribucionInfraestructura
        Dim Lista As New List(Of distribucionInfraestructura)

        Dim HAbitacion = (From DIS In HeliosData.distribucionInfraestructura
                          Join det In HeliosData.documentoventaAbarrotesDet On DIS.idDistribucion Equals CInt(det.idDistribucion)
                          Group Join TIP In HeliosData.tipoServicioInfraestructura On CInt(DIS.idTipoServicio) Equals TIP.idTipoServicio Into TIP_join = Group
                          From TIP In TIP_join.DefaultIfEmpty()
                          Group Join CAT In HeliosData.categoriaInfraestructura On CInt(TIP.idCategoria) Equals CAT.idCategoria Into CAT_join = Group
                          From CAT In CAT_join.DefaultIfEmpty()
                          Where
                              CLng(det.documentoventaAbarrotes.idCliente) = documentoBE.idCliente And
                              det.tipoExistencia = "IF" And det.estadoDistribucion = "A"
                          Select
                              IdDistribucion = CType(DIS.idDistribucion, Int32?),
                              DIS.descripcionDistribucion,
                              DIS.numeracion,
                              DIS.estado,
                              DescripcionTipoServicio = TIP.descripcionTipoServicio,
                              DescripcionInfraestructura = CAT.descripcionInfraestructura).ToList



        For Each obj In HAbitacion
            infraBE = New distribucionInfraestructura
            infraBE.[idDistribucion] = obj.IdDistribucion
            infraBE.numeracion = obj.numeracion
            infraBE.[descripcionDistribucion] = obj.[descripcionDistribucion]
            infraBE.[estado] = obj.[estado]
            infraBE.Categoria = obj.DescripcionInfraestructura
            infraBE.SubCategoria = obj.DescripcionTipoServicio

            Lista.Add(infraBE)
        Next

        Return Lista
    End Function

    Public Function GetDetallePedido(documentoBE As documentoventaAbarrotes) As List(Of distribucionInfraestructura)
        Dim infraBE As distribucionInfraestructura
        Dim Lista As New List(Of distribucionInfraestructura)

        Dim HAbitacion = (From DIS In HeliosData.distribucionInfraestructura
                          Join det In HeliosData.documentoventaAbarrotesDet On DIS.idDistribucion Equals CInt(det.idDistribucion)
                          Group Join TIP In HeliosData.tipoServicioInfraestructura On CInt(DIS.idTipoServicio) Equals TIP.idTipoServicio Into TIP_join = Group
                          From TIP In TIP_join.DefaultIfEmpty()
                          Group Join CAT In HeliosData.categoriaInfraestructura On CInt(TIP.idCategoria) Equals CAT.idCategoria Into CAT_join = Group
                          From CAT In CAT_join.DefaultIfEmpty()
                          Where
                              CLng(det.documentoventaAbarrotes.idCliente) = documentoBE.idCliente
                          Select
                              IdDistribucion = CType(DIS.idDistribucion, Int32?),
                              DIS.descripcionDistribucion,
                              DIS.numeracion,
                              DIS.estado,
                              DescripcionTipoServicio = TIP.descripcionTipoServicio,
                              DescripcionInfraestructura = CAT.descripcionInfraestructura).ToList



        For Each obj In HAbitacion
            infraBE = New distribucionInfraestructura
            infraBE.[idDistribucion] = obj.IdDistribucion
            infraBE.numeracion = obj.numeracion
            infraBE.[descripcionDistribucion] = obj.[descripcionDistribucion]
            infraBE.[estado] = obj.[estado]
            infraBE.Categoria = obj.DescripcionInfraestructura
            infraBE.SubCategoria = obj.DescripcionTipoServicio

            Lista.Add(infraBE)
        Next

        Return Lista
    End Function

#Region "Transferecnia"
    Public Function GetDistribucionAsignacionItem(distriBE As distribucionInfraestructura) As distribucionInfraestructura
        Try
            Using ts As New TransactionScope


                Dim obj As New distribucionInfraestructura
                Dim Lista As New List(Of distribucionInfraestructura)

                Dim consulta = (From dis In HeliosData.distribucionInfraestructura
                                Where
                                dis.idEmpresa = distriBE.idEmpresa And dis.idActivo = distriBE.idActivo).ToList

                For Each i In consulta
                    i.idDetalleItem = distriBE.idDetalleItem
                    HeliosData.SaveChanges()
                Next

                ts.Complete()
                Return obj
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub updateDistribucioTrasnportemMasivo(listaID As distribucionInfraestructura)
        Try
            Dim documentoBL As New documentoBL
            Dim documentobe As New documento

            Using ts As New TransactionScope


                Dim obj = (From n In HeliosData.distribucionInfraestructura
                           Where n.idActivo = listaID.idActivo And n.idEmpresa = listaID.idEmpresa).ToList

                For Each item In obj
                    item.[estado] = listaID.estado
                    HeliosData.SaveChanges()
                Next


                ts.Complete()

            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function getInfraestructuraTransporte(distribucionBE As distribucionInfraestructura) As List(Of distribucionInfraestructura)
        Try

            Dim conteo As Integer = 0
            Dim obj As New distribucionInfraestructura
            Dim ListaDistribucion As New List(Of distribucionInfraestructura)

            Dim consulta = HeliosData.ListaInfraestructuraTransporte(distribucionBE.idEmpresa,
                                                                       distribucionBE.idEstablecimiento,
                                                                        distribucionBE.tipo,
                                                                        distribucionBE.estado,
                                                                        distribucionBE.usuarioActualizacion,
                                                                          distribucionBE.descripcionDistribucion,
                                                                        distribucionBE.Categoria,
                                                                        distribucionBE.SubCategoria).ToList
            '                                                 
            For Each i In consulta
                obj = New distribucionInfraestructura
                obj.[idDistribucion] = i.idDistribucion
                obj.[idEmpresa] = i.[idEmpresa]
                obj.[idEstablecimiento] = i.[idEstablecimiento]
                obj.[idComponente] = i.[idComponente]
                obj.[idInfraestructura] = i.[idInfraestructura]
                obj.numeracion = i.numeracion
                obj.[descripcionDistribucion] = i.[descripcionDistribucion]
                obj.[glosario] = i.[glosario]
                obj.[estado] = i.[estado]
                obj.[tipo] = i.[tipo]
                obj.idDetalleItem = i.idDetalleItem
                obj.NombreSector = i.segmento
                obj.NombrePiso = i.piso
                obj.menor = i.precioXmenor.GetValueOrDefault
                obj.conteoPrecioMenor = i.CtaXCobrar.GetValueOrDefault
                obj.idTipoServicio = i.idTipoServicio
                obj.[usuarioActualizacion] = i.descripcionTipoServicio
                obj.Categoria = i.descripcionTipoServicio & " " & i.numeracion
                ListaDistribucion.Add(obj)
            Next
            Return ListaDistribucion
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function

    Public Function updateDistribucionTransportexID(i As distribucionInfraestructura) As distribucionInfraestructura
        Try
            Using ts As New TransactionScope

                Dim CambioEstado = (From n In HeliosData.distribucionInfraestructura
                                    Where n.estado = i.estado).FirstOrDefault

                If (Not IsNothing(CambioEstado)) Then
                    CambioEstado.[estado] = "A"
                    HeliosData.SaveChanges()
                End If

                Dim obj = (From n In HeliosData.distribucionInfraestructura
                           Where n.idDistribucion = i.idDistribucion And n.idEmpresa = i.idEmpresa).FirstOrDefault

                obj.[estado] = i.estado

                HeliosData.SaveChanges()
                ts.Complete()

                Return obj
            End Using

        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region



    ' nuevo componente

    Public Function SaveDistribucionInfraestructuraFull(IdInfraestructura As Integer, listaComponente As List(Of componente)) As Integer
        Try

            Dim obj As distribucionInfraestructura
            Dim CONTEO As Integer = 1

            Using ts As New TransactionScope

                For Each i In listaComponente

                    obj = New distribucionInfraestructura
                    obj.[idEmpresa] = i.[idEmpresa]
                    obj.[idEstablecimiento] = Nothing
                    obj.[idComponente] = i.[idComponente]
                    obj.[idInfraestructura] = IdInfraestructura
                    obj.[descripcionDistribucion] = "ASIENTO"
                    obj.[glosario] = "ASIENTO " & CONTEO
                    obj.[estado] = i.estado
                    obj.[tipo] = i.tipo
                    obj.numeracion = Nothing
                    obj.[usuarioActualizacion] = "ADMINISTRACION"
                    obj.[fechaActualizacion] = Date.Now

                    HeliosData.distribucionInfraestructura.Add(obj)
                    HeliosData.SaveChanges()

                    CONTEO = CONTEO + 1

                Next
                ts.Complete()

                Return 0
            End Using

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'uevo transporte

    Public Function SaveDistribucionInfraestructuraXActivo(listaComponente As List(Of componente)) As Integer
        Try

            Dim obj As distribucionInfraestructura
            Dim CONTEO As Integer = 1

            Using ts As New TransactionScope

                For Each i In listaComponente

                    obj = New distribucionInfraestructura
                    obj.[idEmpresa] = i.[idEmpresa]
                    obj.[idEstablecimiento] = Nothing
                    obj.[idComponente] = i.[idComponente]
                    obj.[idInfraestructura] = i.IDInfraestructura
                    obj.[descripcionDistribucion] = "ASIENTO"
                    obj.[glosario] = "ASIENTO " & CONTEO
                    obj.idActivo = i.idActivo
                    obj.[estado] = i.estado
                    obj.[tipo] = i.tipo
                    obj.numeracion = Nothing
                    obj.idTipoServicio = i.tipoServicio
                    obj.[usuarioActualizacion] = "ADMINISTRACION"
                    obj.[fechaActualizacion] = Date.Now

                    HeliosData.distribucionInfraestructura.Add(obj)
                    HeliosData.SaveChanges()

                    CONTEO = CONTEO + 1

                Next
                ts.Complete()

                Return 0
            End Using

        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function getDistribucionInfraestructuraPlantilla(distribucionInfraestructuraBE As distribucionInfraestructura) As List(Of distribucionInfraestructura)
        Dim conteo As Integer = 0
        Dim obj As New distribucionInfraestructura
        Dim listaInfraestructura As New List(Of distribucionInfraestructura)

        'Dim consulta = (From dis In HeliosData.distribucionInfraestructura Join infra In HeliosData.infraestructura
        '                 On dis.idInfraestructura Equals infra.idInfraestructura
        '                Where dis.estado = distribucionInfraestructuraBE.estado And
        '                                                dis.idEmpresa = distribucionInfraestructuraBE.idEmpresa And
        '                    infra.IdPlantilla = distribucionInfraestructuraBE.IDPlantilla
        '                Select
        '                    dis.idDistribucion,
        '                    dis.idEmpresa,
        '                    dis.idEstablecimiento,
        '                    dis.idComponente,
        '                    dis.idInfraestructura,
        '                    dis.idTipoServicio,
        '                    dis.descripcionDistribucion,
        '                    dis.glosario,
        '                    dis.estado,
        '                    dis.tipo,
        '                    dis.numeracion,
        '                    dis.directorio,
        '                    dis.logoID,
        '                    dis.usuarioActualizacion,
        '                    dis.fechaActualizacion,
        '                    dis.infraestructura.nombre).ToList

        'For Each i In consulta
        '    obj = New distribucionInfraestructura
        '    obj.[idDistribucion] = i.idDistribucion
        '    obj.[idEmpresa] = i.[idEmpresa]
        '    obj.[idEstablecimiento] = i.[idEstablecimiento]
        '    obj.[idComponente] = i.[idComponente]
        '    obj.[idInfraestructura] = i.[idInfraestructura]
        '    obj.[descripcionDistribucion] = i.[descripcionDistribucion]
        '    obj.[glosario] = i.[glosario]
        '    obj.[estado] = i.[estado]
        '    obj.[tipo] = i.[tipo]
        '    obj.numeracion = i.numeracion
        '    obj.NombrePiso = i.nombre
        '    obj.[fechaActualizacion] = i.[fechaActualizacion]

        '    listaInfraestructura.Add(obj)
        'Next

        Return listaInfraestructura

    End Function

    Public Function getDistribucionInfraestructura(distribucionInfraestructuraBE As distribucionInfraestructura) As List(Of distribucionInfraestructura)
        Dim conteo As Integer = 0
        Dim obj As New distribucionInfraestructura
        Dim listaInfraestructura As New List(Of distribucionInfraestructura)

        Dim consulta = (From dis In HeliosData.distribucionInfraestructura
                        Where dis.tipo = distribucionInfraestructuraBE.tipo And
                            dis.idEmpresa = distribucionInfraestructuraBE.idEmpresa And
                            dis.idActivo = distribucionInfraestructuraBE.idActivo
                        Select
                            dis.idDistribucion,
                            dis.idEmpresa,
                            dis.idEstablecimiento,
                            dis.idComponente,
                            dis.idInfraestructura,
                            dis.idTipoServicio,
                            dis.descripcionDistribucion,
                            dis.glosario,
                            dis.estado,
                            dis.tipo,
                            dis.numeracion,
                            dis.directorio,
                            dis.logoID,
                            dis.usuarioActualizacion,
                            dis.fechaActualizacion,
                            dis.infraestructura.nombre).ToList

        For Each i In consulta
            obj = New distribucionInfraestructura
            obj.[idDistribucion] = i.idDistribucion
            obj.[idEmpresa] = i.[idEmpresa]
            obj.[idEstablecimiento] = i.[idEstablecimiento]
            obj.[idComponente] = i.[idComponente]
            obj.[idInfraestructura] = i.[idInfraestructura]
            obj.[descripcionDistribucion] = i.[descripcionDistribucion]
            obj.[glosario] = i.[glosario]
            obj.[estado] = i.[estado]
            obj.[tipo] = i.[tipo]
            obj.numeracion = i.numeracion
            obj.NombrePiso = i.nombre
            obj.[fechaActualizacion] = i.[fechaActualizacion]

            listaInfraestructura.Add(obj)
        Next

        Return listaInfraestructura

    End Function

    Public Function updateDistribucionNumeracion(listaID As List(Of distribucionInfraestructura)) As List(Of distribucionInfraestructura)
        Try
            Dim listaInfra As New List(Of distribucionInfraestructura)
            Dim infraBE As New distribucionInfraestructura
            Using ts As New TransactionScope

                For Each item In listaID
                    Dim obj = (From n In HeliosData.distribucionInfraestructura
                               Where n.idDistribucion = item.idDistribucion And n.idEmpresa = item.idEmpresa And
                                   n.estado = "A").FirstOrDefault

                    If (Not IsNothing(obj)) Then
                        obj.numeracion = item.numeracion
                        HeliosData.SaveChanges()
                    End If

                Next

                ts.Complete()
                Return listaInfra
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Function

End Class
