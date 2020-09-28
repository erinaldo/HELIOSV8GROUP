Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class hojaCostosBL
    Inherits BaseBL


    Public Sub InsertCosto(compraBE As documentocompra)
        Dim obj As New hojaCostos

        Using ts As New TransactionScope
            For Each i In compraBE.documentocompradetalle
                obj = New hojaCostos With
                      {
                .idEmpresa = compraBE.idEmpresa,
                .idEstablecimiento = compraBE.idCentroCosto,
                .tipoCosto = compraBE.tipocosto,
                .idCosto = compraBE.idCosto,
                .estado = compraBE.estadoPago,
                .idDocumento = compraBE.idDocumento,
                .codigoLibro = compraBE.codigoLibro,
                .fecha = compraBE.fechaDoc,
                .cuenta = Nothing,
                .idAlmacen = Nothing,
                .idItem = i.idItem,
                .detalle = i.descripcionItem,
                .destinoGravado = i.destino,
                .idTrabajador = Nothing,
                .tipoExistencia = i.tipoExistencia,
                .unidadMedida = i.unidad1,
                .cantidad = i.monto1,
                .importe = i.montokardex,
                .importeUS = i.montokardexUS,
                .codigoEntidad = compraBE.idProveedor,
                .tipoEntidad = "PR",
                .documentoDestino = Nothing,
                .serie = Nothing,
                .numero = Nothing,
                .usuarioActualizacion = compraBE.usuarioActualizacion,
                .fechaActualizacion = compraBE.fechaActualizacion
                    }
                HeliosData.hojaCostos.Add(obj)
            Next
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function Insert(ByVal hojaCostosBE As hojaCostos) As Integer
        Using ts As New TransactionScope
            HeliosData.hojaCostos.Add(hojaCostosBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return hojaCostosBE.codigoGenerado
        End Using
    End Function

    'Public Sub Update(ByVal hojaCostosBE As hojaCostos)
    '    Using ts As New TransactionScope
    '        Dim hojaCostos As hojaCostos = HeliosData.hojaCostos.Where(Function(o) _
    '                                        o.codigoGenerado = hojaCostosBE.codigoGenerado _
    '                                        And o.idEmpresa = hojaCostosBE.idEmpresa _
    '                                        And o.idEstablecimiento = hojaCostosBE.idEstablecimiento _
    '                                        And o.idProyecto = hojaCostosBE.idProyecto _
    '                                        And o.idEstrategia = hojaCostosBE.idEstrategia _
    '                                        And o.idProceso = hojaCostosBE.idProceso _
    '                                        And o.idActividad = hojaCostosBE.idActividad).First()

    '        hojaCostos.idDocumento = hojaCostosBE.idDocumento
    '        hojaCostos.elementoCosto = hojaCostosBE.elementoCosto
    '        hojaCostos.codigoLibro = hojaCostosBE.codigoLibro
    '        hojaCostos.fecha = hojaCostosBE.fecha
    '        hojaCostos.cuenta = hojaCostosBE.cuenta
    '        hojaCostos.idAlmacen = hojaCostosBE.idAlmacen
    '        hojaCostos.idItem = hojaCostosBE.idItem
    '        hojaCostos.detalle = hojaCostosBE.detalle
    '        hojaCostos.destinoGravado = hojaCostosBE.destinoGravado
    '        hojaCostos.idTrabajador = hojaCostosBE.idTrabajador
    '        hojaCostos.tipoExistencia = hojaCostosBE.tipoExistencia
    '        hojaCostos.unidadMedida = hojaCostosBE.unidadMedida
    '        hojaCostos.cantidad = hojaCostosBE.cantidad
    '        hojaCostos.importe = hojaCostosBE.importe
    '        hojaCostos.importeUS = hojaCostosBE.importeUS
    '        hojaCostos.codigoEntidad = hojaCostosBE.codigoEntidad
    '        hojaCostos.tipoEntidad = hojaCostosBE.tipoEntidad
    '        hojaCostos.documentoDestino = hojaCostosBE.documentoDestino
    '        hojaCostos.serie = hojaCostosBE.serie
    '        hojaCostos.numero = hojaCostosBE.numero
    '        hojaCostos.usuarioActualizacion = hojaCostosBE.usuarioActualizacion
    '        hojaCostos.fechaActualizacion = hojaCostosBE.fechaActualizacion

    '        'HeliosData.ObjectStateManager.GetObjectStateEntry(hojaCostos).State.ToString()

    '        HeliosData.SaveChanges()
    '        ts.Complete()
    '    End Using
    'End Sub

    Public Sub Delete(ByVal hojaCostosBE As hojaCostos)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(hojaCostosBE)
    End Sub

    Public Function GetListar_hojaCostos() As List(Of hojaCostos)
        Return (From a In HeliosData.hojaCostos Select a).ToList
    End Function

    Public Function GetUbicar_hojaCostosPorID(codigoGenerado As Integer) As hojaCostos
        Return (From a In HeliosData.hojaCostos
                 Where a.codigoGenerado = codigoGenerado Select a).First
    End Function
End Class
