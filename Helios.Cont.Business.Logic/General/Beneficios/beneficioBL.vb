Imports System.Transactions
Imports Helios.Cont.Business.Entity
Imports Helios.General.Constantes

Public Class beneficioBL
    Inherits BaseBL

    'Public Sub RegisterClientBeneficeSolo(be As beneficio)
    '    Dim afiliacionBL As New EntidadAfiliacionBeneficioBL
    '    Using ts As New TransactionScope()
    '        BeneficioSave(be)
    '        HeliosData.SaveChanges()
    '        ts.Complete()
    '    End Using
    'End Sub

    Public Sub RegisterClientBenefice(be As beneficio)
        Dim afiliacionBL As New EntidadAfiliacionBeneficioBL
        Try
            Using ts As New TransactionScope()

                Dim Existe = HeliosData.beneficio.Any(Function(o) o.idCliente = be.idCliente And o.detalleBeneficio = be.detalleBeneficio And o.idOrganizacion = be.idOrganizacion)

                If Existe Then
                    Throw New Exception("No puede registrar el beneficio, verifique los campos")
                End If
                BeneficioSave(be)
                'afiliacionBL.ChangeStatusAfiliado(New EntidadAfiliacionBeneficio With
                '                                  {
                '                                  .idEntidad = be.idCliente,
                '                                  .status = StatusAfiliacionBeneficiosCliente.Aprobado
                '                                  })
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub RegisterClientBeneficeCupon(be As beneficio)
        Dim afiliacionBL As New EntidadAfiliacionBeneficioBL
        Try
            Using ts As New TransactionScope()

                'Dim Existe = HeliosData.beneficio.Any(Function(o) o.idCliente = be.idCliente And o.detalleBeneficio = be.detalleBeneficio)

                'If Existe Then
                '    Throw New Exception("No puede registrar el beneficio, verifique los campos")
                'End If
                BeneficioSave(be)
                'afiliacionBL.ChangeStatusAfiliado(New EntidadAfiliacionBeneficio With
                '                                  {
                '                                  .idEntidad = be.idCliente,
                '                                  .status = StatusAfiliacionBeneficiosCliente.Aprobado
                '                                  })
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub BeneficioSave(be As beneficio)
        Using ts As New TransactionScope()
            HeliosData.beneficio.Add(be)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function BeneficioSelXID(be As beneficio) As beneficio
        BeneficioSelXID = New beneficio

        Dim consulta = (From n In HeliosData.beneficio
                        Where n.beneficio_id = be.beneficio_id
                        Select
                            n.estado,
                            n.beneficio_id,
                            n.tipoTabla,
                            n.detalleBeneficio,
                            n.tipoBeneficio,
                            n.beneficioReferencia,
                            n.beneficioReferenciaCantidad,
                            n.afectoComprobante,
                            n.tipoAfectacion,
                            n.importeBase,
                            n.valorConvertido,
                            n.vigencia,
                            n.esPremioRegaloBonif,
                            n.idCliente,
                            n.produccion_id).SingleOrDefault

        If consulta IsNot Nothing Then
            BeneficioSelXID = New beneficio With
            {
            .estado = consulta.estado,
            .beneficio_id = consulta.beneficio_id,
            .tipoTabla = consulta.tipoTabla,
            .detalleBeneficio = consulta.detalleBeneficio,
            .tipoBeneficio = consulta.tipoBeneficio,
            .beneficioReferencia = consulta.beneficioReferencia,
            .beneficioReferenciaCantidad = consulta.beneficioReferenciaCantidad,
            .afectoComprobante = consulta.afectoComprobante,
            .tipoAfectacion = consulta.tipoAfectacion,
            .importeBase = consulta.importeBase,
            .valorConvertido = consulta.valorConvertido,
            .vigencia = consulta.vigencia,
            .esPremioRegaloBonif = consulta.esPremioRegaloBonif,
            .idCliente = consulta.idCliente,
            .produccion_id = consulta.produccion_id
            }
        Else
            BeneficioSelXID = Nothing
        End If
    End Function

    Public Function BeneficioSelCliente(be As beneficio) As List(Of beneficio)
        BeneficioSelCliente = New List(Of beneficio)

        Dim consulta = (From n In HeliosData.beneficio
                        Where n.idCliente = be.idCliente
                        Select
                            n.beneficio_id,
                            n.tipoTabla,
                            n.detalleBeneficio,
                            n.tipoBeneficio,
                            n.beneficioReferencia,
                            n.beneficioReferenciaCantidad,
                            n.afectoComprobante,
                            n.tipoAfectacion,
                            n.importeBase,
                            n.valorConvertido,
                            n.vigencia,
                            n.esPremioRegaloBonif,
                            n.idCliente,
                            n.produccion_id).ToList()

        BeneficioSelCliente = New List(Of beneficio)
        For Each i In consulta
            BeneficioSelCliente.Add(New beneficio With
                                    {
                                    .beneficio_id = i.beneficio_id,
                                    .tipoTabla = i.tipoTabla,
                                    .detalleBeneficio = i.detalleBeneficio,
                                    .tipoBeneficio = i.tipoBeneficio,
                                    .beneficioReferencia = i.beneficioReferencia,
                                    .beneficioReferenciaCantidad = i.beneficioReferenciaCantidad,
                                    .afectoComprobante = i.afectoComprobante,
                                    .tipoAfectacion = i.tipoAfectacion,
                                    .importeBase = i.importeBase,
                                    .valorConvertido = i.valorConvertido,
                                    .vigencia = i.vigencia,
                                    .esPremioRegaloBonif = i.esPremioRegaloBonif,
                                    .idCliente = i.idCliente,
                                    .produccion_id = i.produccion_id
                                    })
        Next
    End Function

    Public Function BeneficioSelClienteProductions(be As beneficio) As beneficio
        BeneficioSelClienteProductions = New beneficio

        Dim i = (From n In HeliosData.beneficio
                 Where n.idCliente = be.idCliente
                 Select
                            n.beneficio_id,
                            n.tipoTabla,
                            n.detalleBeneficio,
                            n.tipoBeneficio,
                            n.beneficioReferencia,
                            n.beneficioReferenciaCantidad,
                            n.afectoComprobante,
                            n.tipoAfectacion,
                            n.importeBase,
                            n.valorConvertido,
                            n.vigencia,
                            n.esPremioRegaloBonif,
                            n.idCliente,
                            n.produccion_id).SingleOrDefault


        If i IsNot Nothing Then
            BeneficioSelClienteProductions = New beneficio With
                                    {
                                    .beneficio_id = i.beneficio_id,
                                    .tipoTabla = i.tipoTabla,
                                    .detalleBeneficio = i.detalleBeneficio,
                                    .tipoBeneficio = i.tipoBeneficio,
                                    .beneficioReferencia = i.beneficioReferencia,
                                    .beneficioReferenciaCantidad = i.beneficioReferenciaCantidad,
                                    .afectoComprobante = i.afectoComprobante,
                                    .tipoAfectacion = i.tipoAfectacion,
                                    .importeBase = i.importeBase,
                                    .valorConvertido = i.valorConvertido,
                                    .vigencia = i.vigencia,
                                    .esPremioRegaloBonif = i.esPremioRegaloBonif,
                                    .idCliente = i.idCliente,
                                    .produccion_id = i.produccion_id
                                    }
        Else
            Return Nothing
        End If


    End Function

    Public Function BeneficioListaClienteProductions(be As beneficio) As List(Of beneficio)
        BeneficioListaClienteProductions = New List(Of beneficio)

        Dim con = (From n In HeliosData.beneficio
                   Join prod In HeliosData.detalleitems
                       On prod.codigodetalle Equals CInt(n.detalleBeneficio)
                   Where n.idCliente = be.idCliente And n.tipoTabla <> 5
                   Select
                       prod.codigodetalle,
                       prod.descripcionItem,
                       n.beneficio_id,
                            n.tipoTabla,
                            n.detalleBeneficio,
                            n.tipoBeneficio,
                            n.beneficioReferencia,
                            n.beneficioReferenciaCantidad,
                            n.afectoComprobante,
                            n.tipoAfectacion,
                            n.importeBase,
                            n.valorConvertido,
                            n.vigencia,
                            n.esPremioRegaloBonif,
                            n.idCliente,
                            n.produccion_id).ToList

        For Each i In con
            BeneficioListaClienteProductions.Add(New beneficio With
                                    {
                                    .beneficio_id = i.beneficio_id,
                                    .tipoTabla = i.tipoTabla,
                                    .detalleBeneficio = i.detalleBeneficio,
                                    .tipoBeneficio = i.tipoBeneficio,
                                    .beneficioReferencia = i.beneficioReferencia,
                                    .beneficioReferenciaCantidad = i.beneficioReferenciaCantidad,
                                    .afectoComprobante = i.afectoComprobante,
                                    .tipoAfectacion = i.tipoAfectacion,
                                    .importeBase = i.importeBase,
                                    .valorConvertido = i.valorConvertido,
                                    .vigencia = i.vigencia,
                                    .esPremioRegaloBonif = i.esPremioRegaloBonif,
                                    .idCliente = i.idCliente,
                                    .produccion_id = i.produccion_id,
                                    .CustomProducto = New detalleitems With
                                                 {
                                                 .codigodetalle = i.codigodetalle,
                                                 .descripcionItem = i.descripcionItem
                                                 }
                                    })
        Next

    End Function

    Public Function BeneficioListaClienteProductionCupones(be As beneficio) As List(Of beneficio)
        BeneficioListaClienteProductionCupones = New List(Of beneficio)

        Dim con = (From n In HeliosData.beneficio
                   Join prod In HeliosData.beneficioProduccionConsumo
                       On prod.produccion_id Equals n.produccion_id
                   Where n.idCliente = be.idCliente
                   Select
                           prod.produccion_id,
                           prod.descripcion,
                           prod.fechaEmision,
                           prod.nroImpresionMax,
                           prod.tipo,
                           prod.valor,
                           n.beneficio_id,
                            n.tipoTabla,
                            n.detalleBeneficio,
                            n.tipoBeneficio,
                            n.beneficioReferencia,
                            n.beneficioReferenciaCantidad,
                            n.afectoComprobante,
                            n.tipoAfectacion,
                            n.importeBase,
                            n.valorConvertido,
                            n.vigencia,
                            n.esPremioRegaloBonif,
                            n.idCliente).ToList

        For Each i In con
            BeneficioListaClienteProductionCupones.Add(New beneficio With
                                    {
                                    .beneficio_id = i.beneficio_id,
                                    .tipoTabla = i.tipoTabla,
                                    .detalleBeneficio = i.detalleBeneficio,
                                    .tipoBeneficio = i.tipoBeneficio,
                                    .beneficioReferencia = i.beneficioReferencia,
                                    .beneficioReferenciaCantidad = i.beneficioReferenciaCantidad,
                                    .afectoComprobante = i.afectoComprobante,
                                    .tipoAfectacion = i.tipoAfectacion,
                                    .importeBase = i.importeBase,
                                    .valorConvertido = i.valorConvertido,
                                    .vigencia = i.vigencia,
                                    .esPremioRegaloBonif = i.esPremioRegaloBonif,
                                    .idCliente = i.idCliente,
                                    .produccion_id = i.produccion_id,
                                    .CustomBeneficioProduccion = New beneficioProduccionConsumo With
                                                 {
                                                 .produccion_id = i.produccion_id,
                                                 .descripcion = i.descripcion,
                                                 .fechaEmision = i.fechaEmision,
                                                 .nroImpresionMax = i.nroImpresionMax,
                                                 .tipo = i.tipo,
                                                 .valor = i.valor
                                                 }
                                    })
        Next

    End Function

    Public Function CatalogoDeClientesBeneficio(be As entidad) As List(Of entidad)
        CatalogoDeClientesBeneficio = New List(Of entidad)
        Dim tipoEntidadList As New List(Of String)
        tipoEntidadList.Add(TIPO_ENTIDAD.CLIENTE)
        tipoEntidadList.Add("VR")

        Dim con = (From ent In HeliosData.entidad
                   Join af In HeliosData.EntidadAfiliacionBeneficio
                           On af.idEntidad Equals ent.idEntidad
                   Where ent.idEmpresa = be.idEmpresa And
                       ent.idOrganizacion = be.idOrganizacion And
                       tipoEntidadList.Contains(ent.tipoEntidad) And
                       ent.tieneBeneficio = be.tieneBeneficio And
                       af.status = General.StatusAfiliacionBeneficiosCliente.Aprobado
                   Select
                       ent.idEntidad,
                       ent.nombreCompleto,
                       ent.nombreContacto,
                       ent.tipoDoc,
                       ent.nrodoc,
                       ent.tipoEntidad,
                       ent.tipoPersona,
                       ent.telefono,
                       ent.celular,
                       ent.email).ToList

        For Each i In con
            CatalogoDeClientesBeneficio.Add(New entidad With
                                    {
                                    .idEntidad = i.idEntidad,
                                    .nombreCompleto = i.nombreCompleto,
                                    .nombreContacto = i.nombreContacto,
                                    .tipoDoc = i.tipoDoc,
                                    .nrodoc = i.nrodoc,
                                    .tipoEntidad = i.tipoEntidad,
                                    .tipoPersona = i.tipoPersona,
                                    .telefono = i.telefono,
                                    .celular = i.celular,
                                    .email = i.email
                                    })
        Next

    End Function
End Class
