Imports System.Transactions
Imports Helios.Cont.Business.Entity
Imports System.Data.Entity.DbFunctions
Imports Helios.General

Public Class Entidadmembresia_GymBL
    Inherits BaseBL

    Public Sub GetMembresiasVencidasDelDia(be As List(Of Entidadmembresia_Gym))
        Using ts As New TransactionScope
            For Each i In be
                Dim r = HeliosData.Entidadmembresia_Gym.Where(Function(o) o.idDocumento = i.idDocumento).FirstOrDefault
                If r IsNot Nothing Then
                    r.statusMembresia = Gimnasio_EstadoMembresia.Baja
                End If
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function GetDocumentoCajaMembresiaByDocumento(iddocumento As Integer) As Entidadmembresia_Gym
        Dim i = (From mem In HeliosData.Entidadmembresia_Gym
                 Join ent In HeliosData.entidad
                          On ent.idEntidad Equals mem.idEntidad
                 Join m In HeliosData.membresia_Gym
                          On m.idMembresia Equals mem.idMembresia
                 Where mem.idDocumento = iddocumento
                 Select New With
                     {
                     mem.idMembresia,
                     m.tipoDuracion,
                     m.valorDuracion,
                     m.detalle,
                     m.tipo,
                     m.fechafin,
                     mem.tipodoc,
                     mem.serie,
                     mem.numero,
                     m.descripcion,
                     mem.idDocumento,
                     mem.tipoServicio,
                     mem.idEntidad,
                     ent.nombreCompleto,
                     ent.nrodoc,
                     mem.fechaRegistro,
                     mem.fechaInicio,
                     mem.fechaVcto,
                     mem.congela_dia,
                     mem.opGravado,
                     mem.importe,
                     mem.statusPago,
                     mem.statusMembresia,
                     .PagoAcuenta = (Aggregate n In HeliosData.documentoCajaDetalle
                                          Where n.documentoAfectado = iddocumento
                                              Into Sum(n.montoSoles)),
                     .PagoAcuentaME = (Aggregate n In HeliosData.documentoCajaDetalle
                                          Where n.documentoAfectado = iddocumento
                                              Into Sum(n.montoUsd))
                     }).FirstOrDefault

        If i IsNot Nothing Then
            GetDocumentoCajaMembresiaByDocumento = New Entidadmembresia_Gym With
                                               {
                                               .idMembresia = i.idMembresia,
                                               .tipodoc = i.tipodoc,
                                               .serie = i.serie,
                                               .numero = i.numero,
                                               .CustomMembresia = New membresia_Gym With {.idMembresia = i.idMembresia, .descripcion = i.descripcion, .tipoDuracion = i.tipoDuracion, .valorDuracion = i.valorDuracion, .detalle = i.detalle, .tipo = i.tipo, .fechafin = i.fechafin},
                                               .idDocumento = i.idDocumento,
                                               .tipoServicio = i.tipoServicio,
                                               .idEntidad = i.idEntidad,
                                               .CustomEntidad = New entidad With {.idEntidad = i.idEntidad, .nombreCompleto = i.nombreCompleto, .nrodoc = i.nrodoc},
                                               .fechaRegistro = i.fechaRegistro,
                                               .fechaInicio = i.fechaInicio,
                                               .fechaVcto = i.fechaVcto,
                                               .congela_dia = i.congela_dia,
                                               .opGravado = i.opGravado,
                                               .importe = i.importe,
                                               .statusPago = i.statusPago,
                                               .statusMembresia = i.statusMembresia,
                                               .CustomDocumentoCaja = New documentoCaja With {.montoSoles = i.PagoAcuenta.GetValueOrDefault, .montoUsd = i.PagoAcuentaME.GetValueOrDefault}
                                               }
        Else
            GetDocumentoCajaMembresiaByDocumento = Nothing
        End If
    End Function

    Public Function GetMembresiaActivaXSocio(be As Entidadmembresia_Gym) As Entidadmembresia_Gym
        Dim listaPagos As New List(Of String)
        listaPagos.Add(Gimnasio_EstadoMembresiaPago.PagoParcial)
        listaPagos.Add(Gimnasio_EstadoMembresiaPago.Pendiente)

        Dim i = (From mem In HeliosData.Entidadmembresia_Gym
                 Join ent In HeliosData.entidad
                          On ent.idEntidad Equals mem.idEntidad
                 Join m In HeliosData.membresia_Gym
                          On m.idMembresia Equals mem.idMembresia
                 Where mem.idEmpresa = be.idEmpresa _
                     And mem.idEntidad = be.idEntidad _
                     And mem.statusMembresia = Gimnasio_EstadoMembresia.Activo
                 Select New With
                     {
                     mem.idMembresia,
                     m.tipoDuracion,
                     m.valorDuracion,
                     m.detalle,
                     m.tipo,
                     m.fechafin,
                     mem.tipodoc,
                     mem.serie,
                     mem.numero,
                     m.descripcion,
                     mem.idDocumento,
                     mem.tipoServicio,
                     mem.idEntidad,
                     ent.nombreCompleto,
                     ent.nrodoc,
                     mem.fechaRegistro,
                     mem.fechaInicio,
                     mem.fechaVcto,
                     mem.congela_dia,
                     mem.opGravado,
                     mem.importe,
                     mem.statusPago,
                     mem.statusMembresia,
                     .ConteoDeudas = (From n In HeliosData.Entidadmembresia_Gym
                                      Where n.idEntidad = be.idEntidad And listaPagos.Contains(n.statusPago)).Count
                     }).FirstOrDefault

        If i IsNot Nothing Then
            GetMembresiaActivaXSocio = New Entidadmembresia_Gym With
                                               {
                                               .idMembresia = i.idMembresia,
                                               .tipodoc = i.tipodoc,
                                               .serie = i.serie,
                                               .numero = i.numero,
                                               .CustomMembresia = New membresia_Gym With {.idMembresia = i.idMembresia, .descripcion = i.descripcion, .tipoDuracion = i.tipoDuracion, .valorDuracion = i.valorDuracion, .detalle = i.detalle, .tipo = i.tipo, .fechafin = i.fechafin},
                                               .idDocumento = i.idDocumento,
                                               .tipoServicio = i.tipoServicio,
                                               .idEntidad = i.idEntidad,
                                               .CustomEntidad = New entidad With {.idEntidad = i.idEntidad, .nombreCompleto = i.nombreCompleto, .nrodoc = i.nrodoc},
                                               .fechaRegistro = i.fechaRegistro,
                                               .fechaInicio = i.fechaInicio,
                                               .fechaVcto = i.fechaVcto,
                                               .congela_dia = i.congela_dia,
                                               .opGravado = i.opGravado,
                                               .importe = i.importe,
                                               .statusPago = i.statusPago,
                                               .statusMembresia = i.statusMembresia,
                                               .DeudasXpagar = i.ConteoDeudas
                                               }
        Else
            GetMembresiaActivaXSocio = Nothing
        End If
    End Function

    Public Function GetMembresiasContratadasXSocio(be As Entidadmembresia_Gym) As List(Of Entidadmembresia_Gym)
        Dim consulta = (From mem In HeliosData.Entidadmembresia_Gym
                        Join ent In HeliosData.entidad
                          On ent.idEntidad Equals mem.idEntidad
                        Join m In HeliosData.membresia_Gym
                          On m.idMembresia Equals mem.idMembresia
                        Where mem.idEmpresa = be.idEmpresa _
                     And mem.idEntidad = be.idEntidad
                        Select New With
                     {
                     mem.idMembresia,
                           mem.tipodoc,
                           mem.serie,
                           mem.numero,
                           m.descripcion,
                           mem.idDocumento,
                           mem.tipoServicio,
                           mem.idEntidad,
                           ent.nombreCompleto,
                           ent.nrodoc,
                           mem.fechaRegistro,
                           mem.fechaInicio,
                           mem.fechaVcto,
                           mem.contract_mes,
                           mem.contract_dia,
                           mem.congela_mes,
                           mem.congela_dia,
                           mem.importe,
                            mem.opGravado,
                           mem.statusPago,
                           mem.statusMembresia
                     }).ToList

        GetMembresiasContratadasXSocio = New List(Of Entidadmembresia_Gym)
        For Each i In consulta
            GetMembresiasContratadasXSocio.Add(New Entidadmembresia_Gym With
                                               {
                                               .idMembresia = i.idMembresia,
                                               .tipodoc = i.tipodoc,
                                               .serie = i.serie,
                                               .numero = i.numero,
                                               .CustomMembresia = New membresia_Gym With {.idMembresia = i.idMembresia, .descripcion = i.descripcion},
                                               .idDocumento = i.idDocumento,
                                               .tipoServicio = i.tipoServicio,
                                               .idEntidad = i.idEntidad,
                                               .CustomEntidad = New entidad With {.idEntidad = i.idEntidad, .nombreCompleto = i.nombreCompleto, .nrodoc = i.nrodoc},
                                               .fechaRegistro = i.fechaRegistro,
                                               .fechaInicio = i.fechaInicio,
                                               .fechaVcto = i.fechaVcto,
                                               .congela_dia = i.congela_dia,
                                               .importe = i.importe,
                                               .opGravado = i.opGravado,
                                               .statusPago = i.statusPago,
                                               .statusMembresia = i.statusMembresia
                                               })
        Next
    End Function


    'And mem.idEmpresa = be.idEmpresa _
    Public Function GetRegistroMembresiasByPeriodo(be As Entidadmembresia_Gym) As List(Of Entidadmembresia_Gym)
        Dim consulta = (From mem In HeliosData.Entidadmembresia_Gym
                        Join ent In HeliosData.entidad
                          On ent.idEntidad Equals mem.idEntidad
                        Join m In HeliosData.membresia_Gym
                          On m.idMembresia Equals mem.idMembresia
                        Where mem.periodo = be.periodo _
                      And mem.idEstablecimiento = be.idEstablecimiento
                        Select New With
                          {
                           mem.idMembresia,
                           mem.tipodoc,
                           mem.serie,
                           mem.numero,
                           m.descripcion,
                           mem.idDocumento,
                           mem.tipoServicio,
                           mem.idEntidad,
                           ent.nombreCompleto,
                           ent.nrodoc,
                           mem.fechaRegistro,
                           mem.fechaInicio,
                           mem.fechaVcto,
                           mem.contract_mes,
                           mem.contract_dia,
                           mem.congela_mes,
                           mem.congela_dia,
                           mem.importe,
                            mem.opGravado,
                           mem.statusPago,
                           mem.statusMembresia
                          }).ToList

        GetRegistroMembresiasByPeriodo = New List(Of Entidadmembresia_Gym)
        For Each i In consulta
            GetRegistroMembresiasByPeriodo.Add(New Entidadmembresia_Gym With
                                               {
                                               .idMembresia = i.idMembresia,
                                               .tipodoc = i.tipodoc,
                                               .serie = i.serie,
                                               .numero = i.numero,
                                               .CustomMembresia = New membresia_Gym With {.idMembresia = i.idMembresia, .descripcion = i.descripcion},
                                               .idDocumento = i.idDocumento,
                                               .tipoServicio = i.tipoServicio,
                                               .idEntidad = i.idEntidad,
                                               .CustomEntidad = New entidad With {.idEntidad = i.idEntidad, .nombreCompleto = i.nombreCompleto, .nrodoc = i.nrodoc},
                                               .fechaRegistro = i.fechaRegistro,
                                               .fechaInicio = i.fechaInicio,
                                               .fechaVcto = i.fechaVcto,
                                               .contract_mes = i.contract_mes,
                                               .contract_dia = i.contract_dia,
                                               .congela_mes = i.congela_mes,
                                               .congela_dia = i.congela_dia,
                                               .importe = i.importe,
                                               .opGravado = i.opGravado,
                                               .statusPago = i.statusPago,
                                               .statusMembresia = i.statusMembresia
                                               })
        Next

    End Function

    Public Function GetRegistroMembresiasByEmpresa(be As Entidadmembresia_Gym) As List(Of Entidadmembresia_Gym)
        Dim listaStatus As New List(Of String)
        listaStatus.Add(Gimnasio_EstadoMembresiaPago.PagoParcial)
        listaStatus.Add(Gimnasio_EstadoMembresiaPago.Pendiente)

        Dim consulta = (From mem In HeliosData.Entidadmembresia_Gym
                        Join ent In HeliosData.entidad
                          On ent.idEntidad Equals mem.idEntidad
                        Join m In HeliosData.membresia_Gym
                          On m.idMembresia Equals mem.idMembresia
                        Where mem.idEmpresa = be.idEmpresa _
                            And mem.idEstablecimiento = be.idEstablecimiento _
                            And mem.idEntidad = be.idEntidad _
                            And listaStatus.Contains(mem.statusPago)
                        Select New With
                          {
                            mem.periodo,
                           mem.idMembresia,
                           mem.tipodoc,
                           mem.serie,
                           mem.numero,
                           m.descripcion,
                           mem.idDocumento,
                           mem.tipoServicio,
                           mem.idEntidad,
                           ent.nombreCompleto,
                           ent.nrodoc,
                           mem.fechaRegistro,
                           mem.fechaInicio,
                           mem.fechaVcto,
                           mem.contract_mes,
                           mem.contract_dia,
                           mem.congela_mes,
                           mem.congela_dia,
                           mem.importe,
                           mem.statusPago,
                           mem.statusMembresia
                          }).ToList

        GetRegistroMembresiasByEmpresa = New List(Of Entidadmembresia_Gym)
            For Each i In consulta
                GetRegistroMembresiasByEmpresa.Add(New Entidadmembresia_Gym With
                                                   {
                                                   .idMembresia = i.idMembresia,
                                                   .periodo = i.periodo,
                                                   .tipodoc = i.tipodoc,
                                                   .serie = i.serie,
                                                   .numero = i.numero,
                                                   .CustomMembresia = New membresia_Gym With {.idMembresia = i.idMembresia, .descripcion = i.descripcion},
                                                   .idDocumento = i.idDocumento,
                                                   .tipoServicio = i.tipoServicio,
                                                   .idEntidad = i.idEntidad,
                                                   .CustomEntidad = New entidad With {.idEntidad = i.idEntidad, .nombreCompleto = i.nombreCompleto, .nrodoc = i.nrodoc},
                                                   .fechaRegistro = i.fechaRegistro,
                                                   .fechaInicio = i.fechaInicio,
                                                   .fechaVcto = i.fechaVcto,
                                                   .contract_mes = i.contract_mes,
                                                   .contract_dia = i.contract_dia,
                                                   .congela_mes = i.congela_mes,
                                                   .congela_dia = i.congela_dia,
                                                   .importe = i.importe,
                                                   .statusPago = i.statusPago,
                                                   .statusMembresia = i.statusMembresia
                                                   })
            Next

    End Function

    Public Function GetUbicarDocumentoMembresia(idDocumento As Integer) As Entidadmembresia_Gym
        Dim i = (From mem In HeliosData.Entidadmembresia_Gym
                 Join ent In HeliosData.entidad
                          On ent.idEntidad Equals mem.idEntidad
                 Join m In HeliosData.membresia_Gym
                          On m.idMembresia Equals mem.idMembresia
                 Where mem.idDocumento = idDocumento
                 Select New With
                     {
                     mem.periodo,
                     mem.idMembresia,
                     m.tipoDuracion,
                     m.valorDuracion,
                     m.detalle,
                     m.tipo,
                     m.fechafin,
                     mem.tipodoc,
                     mem.serie,
                     mem.numero,
                     m.descripcion,
                     mem.idDocumento,
                     mem.tipoServicio,
                     mem.idEntidad,
                     ent.nombreCompleto,
                     ent.nrodoc,
                     mem.fechaRegistro,
                     mem.fechaInicio,
                     mem.fechaVcto,
                     mem.congela_dia,
                     mem.opGravado,
                     mem.importe,
                     mem.statusPago,
                     mem.statusMembresia
                     }).FirstOrDefault

        If i IsNot Nothing Then
            GetUbicarDocumentoMembresia = New Entidadmembresia_Gym With
                                               {
                                               .idMembresia = i.idMembresia,
                                               .periodo = i.periodo,
                                               .tipodoc = i.tipodoc,
                                               .serie = i.serie,
                                               .numero = i.numero,
                                               .CustomMembresia = New membresia_Gym With {.idMembresia = i.idMembresia, .descripcion = i.descripcion, .tipoDuracion = i.tipoDuracion, .valorDuracion = i.valorDuracion, .detalle = i.detalle, .tipo = i.tipo, .fechafin = i.fechafin},
                                               .idDocumento = i.idDocumento,
                                               .tipoServicio = i.tipoServicio,
                                               .idEntidad = i.idEntidad,
                                               .CustomEntidad = New entidad With {.idEntidad = i.idEntidad, .nombreCompleto = i.nombreCompleto, .nrodoc = i.nrodoc},
                                               .fechaRegistro = i.fechaRegistro,
                                               .fechaInicio = i.fechaInicio,
                                               .fechaVcto = i.fechaVcto,
                                               .congela_dia = i.congela_dia,
                                               .opGravado = i.opGravado,
                                               .importe = i.importe,
                                               .statusPago = i.statusPago,
                                               .statusMembresia = i.statusMembresia
                                               }
        Else
            GetUbicarDocumentoMembresia = Nothing
        End If
    End Function

    Public Sub GetConfirmarInicio(be As Entidadmembresia_Gym, isEnabled As Boolean)
        Dim asistenciaBL As New Helios.Planilla.Business.Logic.ControlDeAsistenciaBL
        Try
            Dim asistencia = asistenciaBL.ControlDeAsistenciaSelxSocio(New Planilla.Business.Entity.ControlDeAsistencia With {.iddocumentoref = be.idDocumento, .IDPersonal = be.idEntidad})
            If asistencia.Count > 0 Then
                Throw New Exception("No se puede cambiar la fecha de inicio," & vbCrLf & "debido a que registra asistencia.")
            End If
            Dim ob = HeliosData.Entidadmembresia_Gym.Where(Function(o) o.idDocumento = be.idDocumento).FirstOrDefault
            Dim congelamientos = HeliosData.membresia_congelamiento.Where(Function(o) o.idDocumento = be.idDocumento).ToList

            Using ts As New TransactionScope
                If ob IsNot Nothing Then
                    For Each i In congelamientos
                        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(i)
                    Next

                    '  If ob.fechaInicio Is Nothing Then
                    If isEnabled = True Then
                        ob.fechaInicio = be.fechaInicio.Value.Date
                        ob.fechaVcto = be.fechaVcto
                    Else
                        ob.fechaInicio = Nothing
                        ob.fechaVcto = Nothing
                    End If
                    '   End If
                Else
                    Throw New Exception("Ya se registró la fecha de inicio en otra ocasión," & vbCrLf & "intente más tarde")
                End If
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetMembresiasPorVencer(be As Entidadmembresia_Gym) As List(Of Entidadmembresia_Gym)
        Dim consulta = (From mem In HeliosData.Entidadmembresia_Gym
                        Join ent In HeliosData.entidad
                          On ent.idEntidad Equals mem.idEntidad
                        Join m In HeliosData.membresia_Gym
                          On m.idMembresia Equals mem.idMembresia
                        Where mem.idEmpresa = be.idEmpresa And
                            mem.idEstablecimiento = be.idEstablecimiento And
                            TruncateTime(mem.fechaVcto) >= be.fechaInicio And
                            TruncateTime(mem.fechaVcto) <= be.fechaVcto
                        Select New With
                          {
                            mem.idMembresia,
                            mem.tipodoc,
                            mem.serie,
                            mem.numero,
                            m.descripcion,
                            mem.idDocumento,
                            mem.tipoServicio,
                            mem.idEntidad,
                            ent.nombreCompleto,
                            ent.nrodoc,
                            mem.fechaRegistro,
                            mem.fechaInicio,
                            mem.fechaVcto,
                            mem.congela_dia,
                            mem.importe,
                            mem.statusPago,
                            mem.statusMembresia
                            }).ToList

        GetMembresiasPorVencer = New List(Of Entidadmembresia_Gym)
        For Each i In consulta
            GetMembresiasPorVencer.Add(New Entidadmembresia_Gym With
                                               {
                                               .idMembresia = i.idMembresia,
                                               .tipodoc = i.tipodoc,
                                               .serie = i.serie,
                                               .numero = i.numero,
                                               .CustomMembresia = New membresia_Gym With {.idMembresia = i.idMembresia, .descripcion = i.descripcion},
                                               .idDocumento = i.idDocumento,
                                               .tipoServicio = i.tipoServicio,
                                               .idEntidad = i.idEntidad,
                                               .CustomEntidad = New entidad With {.idEntidad = i.idEntidad, .nombreCompleto = i.nombreCompleto, .nrodoc = i.nrodoc},
                                               .fechaRegistro = i.fechaRegistro,
                                               .fechaInicio = i.fechaInicio,
                                               .fechaVcto = i.fechaVcto,
                                               .congela_dia = i.congela_dia,
                                               .importe = i.importe,
                                               .statusPago = i.statusPago,
                                               .statusMembresia = i.statusMembresia
                                               })
        Next
    End Function

    Public Function GetMembresiasPorVencerPeriodo(be As Entidadmembresia_Gym) As List(Of Entidadmembresia_Gym)
        Dim fechaPeriodo = CType(be.periodo & "/01", Date)
        Dim consulta = (From mem In HeliosData.Entidadmembresia_Gym
                        Join ent In HeliosData.entidad
                          On ent.idEntidad Equals mem.idEntidad
                        Join m In HeliosData.membresia_Gym
                          On m.idMembresia Equals mem.idMembresia
                        Where mem.idEmpresa = be.idEmpresa And
                            mem.idEstablecimiento = be.idEstablecimiento And
                            mem.fechaVcto.Value.Year = fechaPeriodo.Year And
                            mem.fechaVcto.Value.Month = fechaPeriodo.Month
                        Select New With
                          {
                            mem.idMembresia,
                            mem.tipodoc,
                            mem.serie,
                            mem.numero,
                            m.descripcion,
                            mem.idDocumento,
                            mem.tipoServicio,
                            mem.idEntidad,
                            ent.nombreCompleto,
                            ent.nrodoc,
                            mem.fechaRegistro,
                            mem.fechaInicio,
                            mem.fechaVcto,
                            mem.congela_dia,
                            mem.importe,
                            mem.statusPago,
                            mem.statusMembresia
                            }).ToList

        GetMembresiasPorVencerPeriodo = New List(Of Entidadmembresia_Gym)
        For Each i In consulta
            GetMembresiasPorVencerPeriodo.Add(New Entidadmembresia_Gym With
                                               {
                                               .idMembresia = i.idMembresia,
                                               .tipodoc = i.tipodoc,
                                               .serie = i.serie,
                                               .numero = i.numero,
                                               .CustomMembresia = New membresia_Gym With {.idMembresia = i.idMembresia, .descripcion = i.descripcion},
                                               .idDocumento = i.idDocumento,
                                               .tipoServicio = i.tipoServicio,
                                               .idEntidad = i.idEntidad,
                                               .CustomEntidad = New entidad With {.idEntidad = i.idEntidad, .nombreCompleto = i.nombreCompleto, .nrodoc = i.nrodoc},
                                               .fechaRegistro = i.fechaRegistro,
                                               .fechaInicio = i.fechaInicio,
                                               .fechaVcto = i.fechaVcto,
                                               .congela_dia = i.congela_dia,
                                               .importe = i.importe,
                                               .statusPago = i.statusPago,
                                               .statusMembresia = i.statusMembresia
                                               })
        Next
    End Function

    Public Function GetMembresiasPorStatusMembresiaXfecha(be As Entidadmembresia_Gym) As List(Of Entidadmembresia_Gym)
        ' Dim fechaPeriodo = CType(be.periodo & "/01", Date)
        Dim consulta = (From mem In HeliosData.Entidadmembresia_Gym
                        Join ent In HeliosData.entidad
                          On ent.idEntidad Equals mem.idEntidad
                        Join m In HeliosData.membresia_Gym
                          On m.idMembresia Equals mem.idMembresia
                        Where mem.idEmpresa = be.idEmpresa And
                            mem.idEstablecimiento = be.idEstablecimiento And
                            mem.statusMembresia = be.statusMembresia And
                            mem.fechaVcto.Value.Year = be.fechaVcto.Value.Year And
                            mem.fechaVcto.Value.Month = be.fechaVcto.Value.Month And
                            mem.fechaVcto.Value.Day = be.fechaVcto.Value.Day
                        Select New With
                          {
                            mem.idMembresia,
                            mem.tipodoc,
                            mem.serie,
                            mem.numero,
                            m.descripcion,
                            mem.idDocumento,
                            mem.tipoServicio,
                            mem.idEntidad,
                            ent.nombreCompleto,
                            ent.nrodoc,
                            mem.fechaRegistro,
                            mem.fechaInicio,
                            mem.fechaVcto,
                            mem.congela_dia,
                            mem.importe,
                            mem.statusPago,
                            mem.statusMembresia
                            }).ToList

        GetMembresiasPorStatusMembresiaXfecha = New List(Of Entidadmembresia_Gym)
        For Each i In consulta
            GetMembresiasPorStatusMembresiaXfecha.Add(New Entidadmembresia_Gym With
                                                      {
                                               .idMembresia = i.idMembresia,
                                               .tipodoc = i.tipodoc,
                                               .serie = i.serie,
                                               .numero = i.numero,
                                               .CustomMembresia = New membresia_Gym With {.idMembresia = i.idMembresia, .descripcion = i.descripcion},
                                               .idDocumento = i.idDocumento,
                                               .tipoServicio = i.tipoServicio,
                                               .idEntidad = i.idEntidad,
                                               .CustomEntidad = New entidad With {.idEntidad = i.idEntidad, .nombreCompleto = i.nombreCompleto, .nrodoc = i.nrodoc},
                                               .fechaRegistro = i.fechaRegistro,
                                               .fechaInicio = i.fechaInicio,
                                               .fechaVcto = i.fechaVcto,
                                               .congela_dia = i.congela_dia,
                                               .importe = i.importe,
                                               .statusPago = i.statusPago,
                                               .statusMembresia = i.statusMembresia
                                               })
        Next
    End Function

    Public Function GetMembresiasPorStatusMembresiaXfechaConteo(be As Entidadmembresia_Gym) As Integer
        GetMembresiasPorStatusMembresiaXfechaConteo = 0
        GetMembresiasPorStatusMembresiaXfechaConteo =
            (From mem In HeliosData.Entidadmembresia_Gym
             Join ent In HeliosData.entidad
                 On ent.idEntidad Equals mem.idEntidad
             Join m In HeliosData.membresia_Gym
                 On m.idMembresia Equals mem.idMembresia
             Where mem.idEmpresa = be.idEmpresa And
                 mem.idEstablecimiento = be.idEstablecimiento And
                 mem.statusMembresia = be.statusMembresia And
                 mem.fechaVcto.Value.Year = be.fechaVcto.Value.Year And
                 mem.fechaVcto.Value.Month = be.fechaVcto.Value.Month And
                 mem.fechaVcto.Value.Day = be.fechaVcto.Value.Day).Count

    End Function

    Public Sub GetEliminarMembresia(be As Entidadmembresia_Gym)
        Dim documentoBL As New documentoBL
        Try
            Using ts As New TransactionScope
                Dim pagos = (From n In HeliosData.documentoCajaDetalle
                             Where n.documentoAfectado = be.idDocumento
                             Select n.idDocumento).Distinct.ToList

                For Each i In pagos
                    documentoBL.DeleteSingleVariable(i)
                Next
                documentoBL.DeleteSingleVariable(be.idDocumento)
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetRegistroMembresiasByCliente(be As Entidadmembresia_Gym) As List(Of Entidadmembresia_Gym)
        Dim consulta = (From mem In HeliosData.Entidadmembresia_Gym
                        Join ent In HeliosData.entidad
                          On ent.idEntidad Equals mem.idEntidad
                        Join m In HeliosData.membresia_Gym
                          On m.idMembresia Equals mem.idMembresia
                        Where mem.idEntidad = be.idEntidad _
                      And mem.idEstablecimiento = be.idEstablecimiento
                        Select New With
                          {
                           mem.idMembresia,
                           mem.tipodoc,
                           mem.serie,
                           mem.numero,
                           m.descripcion,
                           mem.idDocumento,
                           mem.tipoServicio,
                           mem.idEntidad,
                           ent.nombreCompleto,
                           ent.nrodoc,
                           mem.fechaRegistro,
                           mem.fechaInicio,
                           mem.fechaVcto,
                           mem.contract_mes,
                           mem.contract_dia,
                           mem.congela_mes,
                           mem.congela_dia,
                           mem.importe,
                            mem.opGravado,
                           mem.statusPago,
                           mem.statusMembresia
                          }).ToList

        GetRegistroMembresiasByCliente = New List(Of Entidadmembresia_Gym)
        For Each i In consulta
            GetRegistroMembresiasByCliente.Add(New Entidadmembresia_Gym With
                                               {
                                               .idMembresia = i.idMembresia,
                                               .tipodoc = i.tipodoc,
                                               .serie = i.serie,
                                               .numero = i.numero,
                                               .CustomMembresia = New membresia_Gym With {.idMembresia = i.idMembresia, .descripcion = i.descripcion},
                                               .idDocumento = i.idDocumento,
                                               .tipoServicio = i.tipoServicio,
                                               .idEntidad = i.idEntidad,
                                               .CustomEntidad = New entidad With {.idEntidad = i.idEntidad, .nombreCompleto = i.nombreCompleto, .nrodoc = i.nrodoc},
                                               .fechaRegistro = i.fechaRegistro,
                                               .fechaInicio = i.fechaInicio,
                                               .fechaVcto = i.fechaVcto,
                                               .contract_mes = i.contract_mes,
                                               .contract_dia = i.contract_dia,
                                               .congela_mes = i.congela_mes,
                                               .congela_dia = i.congela_dia,
                                               .importe = i.importe,
                                               .opGravado = i.opGravado,
                                               .statusPago = i.statusPago,
                                               .statusMembresia = i.statusMembresia
                                               })
        Next

    End Function

End Class
