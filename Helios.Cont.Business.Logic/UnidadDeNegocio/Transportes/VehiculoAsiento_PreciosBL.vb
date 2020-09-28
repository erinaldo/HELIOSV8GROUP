Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Imports System.Data.Entity
Imports Helios.General

Public Class VehiculoAsiento_PreciosBL
    Inherits BaseBL

    Public Function CargaAsientos(be As vehiculoAsiento_Precios) As List(Of vehiculoAsiento_Precios)
        Return HeliosData.vehiculoAsiento_Precios.Where(Function(o) o.ruta_id = be.ruta_id And o.programacion_id = be.programacion_id).ToList
    End Function

    Public Function GetConsultarEnviosPorProgramacion(be As vehiculoAsiento_Precios) As List(Of vehiculoAsiento_Precios)
        Dim obj As vehiculoAsiento_Precios
        Dim con = (From prec In HeliosData.vehiculoAsiento_Precios
                   Join venta In HeliosData.documentoventaTransporte On prec.idDocumentoVenta Equals venta.idDocumento
                   Join serv In HeliosData.ruta_HorarioServicios On New With {prec.codigoServicio} Equals New With {serv.codigoServicio}
                   Join per In HeliosData.Persona On venta.idPersona Equals per.codigo
                   Join rut In HeliosData.rutas On prec.ruta_id Equals rut.ruta_id
                   Where
                    CLng(prec.programacion_id) = be.programacion_id
                   Order By
                    prec.idComponente
                   Select
                       CodigoPer = per.codigo,
                       prec.programacion_id,
                       prec.idComponente,
                       venta.idDocumento,
                       venta.serie,
                       venta.numero,
                       serv.descripcionCorta,
                       per.nombreCompleto,
                       rut.ciudadDestino,
                       rut.ruta_id,
                       per.tipodoc,
                       venta.total,
                       DNI = per.idPersona,
                       serv.codigoServicio,
                       serv.descripcionLarga,
                       serv.costoEstimado).ToList

        GetConsultarEnviosPorProgramacion = New List(Of vehiculoAsiento_Precios)
        For Each i In con
            obj = New vehiculoAsiento_Precios
            obj.idComponente = i.idComponente
            obj.programacion_id = i.programacion_id
            obj.CustomPersona = New Persona With
            {
            .codigo = i.CodigoPer,
            .idPersona = i.DNI,
            .nombreCompleto = i.nombreCompleto
            }
            obj.CustomRuta = New rutas With
            {
            .ruta_id = i.ruta_id,
            .ciudadDestino = i.ciudadDestino
            }
            obj.CustomDocumentoVentaTransporte = New documentoventaTransporte With
            {
            .idDocumento = i.idDocumento,
            .serie = i.serie,
            .numero = i.numero,
            .total = i.total
            }
            obj.CustomRuta_HorarioServicios = New ruta_HorarioServicios With
            {
            .codigoServicio = i.codigoServicio,
            .descripcionCorta = i.descripcionCorta,
            .descripcionLarga = i.descripcionLarga,
            .costoEstimado = i.costoEstimado
            }
            GetConsultarEnviosPorProgramacion.Add(obj)
        Next

    End Function

    Public Function getInfraestructuraTransporteXProgramacion(distribucionBE As vehiculoAsiento_Precios) As List(Of vehiculoAsiento_Precios)
        Try

            Dim conteo As Integer = 0
            Dim obj As New vehiculoAsiento_Precios
            Dim ListaDistribucion As New List(Of vehiculoAsiento_Precios)

            Dim consulta = HeliosData.ListaTransporteXProgramacion(distribucionBE.idEmpresa,
                                                                       distribucionBE.idEstablecimiento,
                                                                        distribucionBE.moneda,
                                                                        distribucionBE.estado,
                                                                        distribucionBE.usuarioActualizacion,
                                                                          distribucionBE.numeracion,
                                                                        distribucionBE.piso,
                                                                        distribucionBE.segmento).ToList
            '              



            For Each i In consulta
                obj = New vehiculoAsiento_Precios
                obj.idDistribucion = i.idDistribucion
                obj.idEmpresa = i.idEmpresa
                obj.idEstablecimiento = i.idEstablecimiento
                obj.idComponente = i.idComponente
                obj.idInfraestructura = i.idInfraestructura
                obj.estado = i.estado
                obj.numeracion = i.numeracion
                obj.segmento = i.segmento
                obj.piso = i.piso
                obj.precio_id = i.precio_id
                obj.precioAsientoMN = i.precioAsientoMN
                obj.origen = i.origen
                obj.idItem = i.idItem
                obj.descripcionItem = i.descripcionItem
                obj.destino = i.destino
                obj.sexo = i.SEXO
                obj.usuarioActualizacion = i.usuarioActualizacion
                obj.fechaActualizacion = i.fechaActualizacion
                ListaDistribucion.Add(obj)
            Next
            Return ListaDistribucion
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function

    Public Function updateAsientoTransportexID(i As vehiculoAsiento_Precios) As vehiculoAsiento_Precios
        Try
            Using ts As New TransactionScope

                Dim CambioEstado = (From n In HeliosData.vehiculoAsiento_Precios
                                    Where n.estado = i.estado).FirstOrDefault

                If (Not IsNothing(CambioEstado)) Then
                    CambioEstado.[estado] = "A"
                    HeliosData.SaveChanges()
                End If

                Dim obj = (From n In HeliosData.vehiculoAsiento_Precios
                           Where n.precio_id = i.precio_id And n.idEmpresa = i.idEmpresa).FirstOrDefault

                obj.[estado] = i.estado

                HeliosData.SaveChanges()
                ts.Complete()

                Return obj
            End Using

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function updateAsientoTransportexIDxVerificaion(i As vehiculoAsiento_Precios) As vehiculoAsiento_Precios
        Try
            Dim CONDICION As New Boolean
            Dim documentoventatransSA As New documentoventaTransporteBL

            Using ts As New TransactionScope

                CONDICION = documentoventatransSA.GetVerificarDisponibilidadAsiento(i)

                If (CONDICION = False) Then
                    Dim CambioEstado = (From n In HeliosData.vehiculoAsiento_Precios
                                        Where n.estado = i.estado).FirstOrDefault

                    If (Not IsNothing(CambioEstado)) Then
                        CambioEstado.[estado] = "A"
                        HeliosData.SaveChanges()
                    End If

                    Dim obj = (From n In HeliosData.vehiculoAsiento_Precios
                               Where n.precio_id = i.precio_id And n.idEmpresa = i.idEmpresa).FirstOrDefault

                    obj.[estado] = i.estado

                    HeliosData.SaveChanges()
                    ts.Complete()

                    Return obj
                Else
                    Throw New Exception(("YA EXISTE UNA VENTA CON EL ASIENTO SELECCIONADO"))
                End If

            End Using

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function updateAsientoTransporteConfirmacionxID(i As vehiculoAsiento_Precios) As vehiculoAsiento_Precios
        Try
            Using ts As New TransactionScope


                Dim obj = (From n In HeliosData.vehiculoAsiento_Precios
                           Where n.precio_id = i.precio_id And n.idEmpresa = i.idEmpresa).FirstOrDefault

                obj.[estado] = i.estado
                obj.sexo = i.sexo

                HeliosData.SaveChanges()
                ts.Complete()

                Return obj
            End Using

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function updateAsientoPrecioXaNULACIONID(i As vehiculoAsiento_Precios) As vehiculoAsiento_Precios
        Try
            Using ts As New TransactionScope


                Dim obj = (From n In HeliosData.vehiculoAsiento_Precios
                           Where n.programacion_id = i.programacion_id And n.idEmpresa = i.idEmpresa And n.precio_id = i.precio_id).FirstOrDefault


                obj.estado = i.estado
                obj.sexo = ""

                HeliosData.SaveChanges()

                ts.Complete()

                Return i
            End Using

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function updateAsientoPrecioXall(i As vehiculoAsiento_Precios) As vehiculoAsiento_Precios
        Try
            Using ts As New TransactionScope


                Dim obj = (From n In HeliosData.vehiculoAsiento_Precios
                           Where n.programacion_id = i.programacion_id And n.idEmpresa = i.idEmpresa).ToList

                For Each item In obj
                    item.precioAsientoMN = i.precioAsientoMN

                    HeliosData.SaveChanges()
                Next

                ts.Complete()

                Return i
            End Using

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function updateAsientoPrecioXID(i As vehiculoAsiento_Precios) As vehiculoAsiento_Precios
        Try
            Using ts As New TransactionScope


                Dim obj = (From n In HeliosData.vehiculoAsiento_Precios
                           Where n.programacion_id = i.programacion_id And n.idEmpresa = i.idEmpresa And n.precio_id = i.precio_id).FirstOrDefault


                obj.precioAsientoMN = i.precioAsientoMN

                HeliosData.SaveChanges()

                ts.Complete()

                Return i
            End Using

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function GetConsultarProgramacionXbus(be As vehiculoAsiento_Precios) As vehiculoAsiento_Precios
        Try

            Dim obj As vehiculoAsiento_Precios
            Dim i = (From dis In HeliosData.distribucionInfraestructura
                     Where
                           CLng(dis.idActivo) = be.idActivo
                     Group dis By dis.idActivo Into g = Group
                     Select
                           cantidadAsientos = CType(g.Count(Function(p) p.idDistribucion <> Nothing), Int64?),
                           asientoReservados = (CType((Aggregate t1 In
                      (From vh In HeliosData.vehiculoAsiento_Precios
                       Where
                           vh.idActivo = idActivo And
                           CLng(vh.programacion_id) = be.programacion_id And
                           vh.estado = "R"
                       Select New With {
                           vh.precio_id
                           }) Into Count()), Int64?)),
                           asientoUsados = (CType((Aggregate t1 In
                      (From vh In HeliosData.vehiculoAsiento_Precios
                       Where
                           vh.idActivo = idActivo And
                           CLng(vh.programacion_id) = be.programacion_id And
                           vh.estado = "U"
                       Select New With {
                           vh.precio_id
                           }) Into Count()), Int64?))).FirstOrDefault

            GetConsultarProgramacionXbus = New vehiculoAsiento_Precios

            obj = New vehiculoAsiento_Precios
            obj.conteoTotalAsientos = i.cantidadAsientos
            obj.conteoTotalAsientosOcupados = i.asientoUsados
            obj.conteoTotalAsientosReservados = i.asientoReservados

            GetConsultarProgramacionXbus = (obj)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function GetConsultarProgramacionXbusAsientos(be As vehiculoAsiento_Precios) As List(Of vehiculoAsiento_Precios)
        Try

            Dim obj As vehiculoAsiento_Precios
            Dim consulta = (From dis In HeliosData.vehiculoAsiento_Precios
                            Where
                           CLng(dis.idActivo) = be.idActivo And dis.programacion_id = be.programacion_id).ToList

            GetConsultarProgramacionXbusAsientos = New List(Of vehiculoAsiento_Precios)
            For Each i In consulta
                obj = New vehiculoAsiento_Precios
                obj.[ruta_id] = i.[ruta_id]
                obj.[horario_id] = i.[horario_id]
                obj.[codigoServicio] = i.[codigoServicio]
                obj.[precio_id] = i.[precio_id]
                obj.[idDistribucion] = i.[idDistribucion]
                obj.[idComponente] = i.[idComponente]
                obj.[idEmpresa] = i.[idEmpresa]
                obj.[idEstablecimiento] = i.[idEstablecimiento]
                obj.[tareo_id] = i.[tareo_id]
                obj.[idDocumentoVenta] = i.[idDocumentoVenta]
                obj.[idActivo] = i.[idActivo]
                obj.[programacion_id] = i.[programacion_id]
                obj.[fechaProgramada] = i.[fechaProgramada]
                obj.[vence] = i.[vence]
                obj.[origen] = i.[origen]
                obj.[moneda] = i.[moneda]
                obj.[numeracion] = i.[numeracion]
                obj.[precioAsientoMN] = i.[precioAsientoMN]
                obj.[precioAsientoME] = i.[precioAsientoME]
                obj.[sexo] = i.[sexo]
                obj.[abreviaturaReserva] = i.idDistribucion
                obj.[colorReserva] = i.[colorReserva]
                obj.[horaReserva] = i.[horaReserva]
                obj.[idConfiguracion] = i.[idConfiguracion]
                obj.[estado] = i.[estado]
                obj.destino = i.destino
                obj.idItem = i.idItem
                obj.descripcionItem = i.descripcionItem
                obj.[usuarioActualizacion] = i.[usuarioActualizacion]
                obj.[fechaActualizacion] = i.[fechaActualizacion]

                GetConsultarProgramacionXbusAsientos.Add(obj)
            Next
        Catch ex As Exception
            Throw ex
        End Try

    End Function

End Class
