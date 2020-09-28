Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Imports System.Data.Entity.Migrations

Public Class activosFijosBL
    Inherits BaseBL

    Public Function Insert(ByVal activosFijosBE As activosFijos) As Integer
        Using ts As New TransactionScope
            HeliosData.activosFijos.Add(activosFijosBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return activosFijosBE.idActivo
        End Using
    End Function

    Public Sub Update(ByVal activosFijosBE As activosFijos)
        Using ts As New TransactionScope
            Dim actFijo As activosFijos = HeliosData.activosFijos.Where(Function(o) _
                                            o.idActivo = activosFijosBE.idActivo _
                                            And o.cuenta = activosFijosBE.cuenta _
                                            And o.idEmpresa = activosFijosBE.idEmpresa).First()

            actFijo.idEstablecimiento = activosFijosBE.idEstablecimiento
            actFijo.descripcionItem = activosFijosBE.descripcionItem
            actFijo.unidadMedida = activosFijosBE.unidadMedida
            actFijo.unidad2 = activosFijosBE.unidad2
            actFijo.tipoActivo = activosFijosBE.tipoActivo
            actFijo.marca = activosFijosBE.marca
            actFijo.modelo = activosFijosBE.modelo
            actFijo.nroSeriePlaca = activosFijosBE.nroSeriePlaca
            actFijo.destinoGravado = activosFijosBE.destinoGravado
            actFijo.usuarioActualizacion = activosFijosBE.usuarioActualizacion
            actFijo.fechaActualizacion = activosFijosBE.fechaActualizacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(actFijo).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal activosFijosBE As activosFijos)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(activosFijosBE)
    End Sub

    Public Function GetListar_activosFijos() As List(Of activosFijos)
        Return (From a In HeliosData.activosFijos Select a).ToList
    End Function

    Public Function GetListar_activosFijosEmpresa(be As activosFijos) As List(Of activosFijos)
        Return HeliosData.activosFijos.Where(Function(o) o.idEmpresa = be.idEmpresa And o.idEstablecimiento = be.idEstablecimiento).ToList
    End Function

    Public Function GetUbicar_activosFijosPorID(idActivo As Integer) As activosFijos
        Return (From a In HeliosData.activosFijos
                Where a.idActivo = idActivo Select a).First
    End Function

#Region "Transporte"
    Public Function GetListar_activosFijosSeriePlaca(be As activosFijos) As List(Of activosFijos)
        Return HeliosData.activosFijos.Where(Function(o) o.idEmpresa = be.idEmpresa And o.idEstablecimiento = be.idEstablecimiento And o.nroSeriePlaca = be.nroSeriePlaca).ToList
    End Function

    Public Sub ChangeEstatusActivo(obj As activosFijos)
        Using ts As New TransactionScope
            Dim activo = HeliosData.activosFijos.Where(Function(o) o.idActivo = obj.idActivo).SingleOrDefault
            activo.tipoActivo = obj.tipoActivo
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function ModificarActivo(ByVal activosFijosBE As activosFijos) As activosFijos
        Using ts As New TransactionScope
            HeliosData.activosFijos.AddOrUpdate(activosFijosBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return activosFijosBE
        End Using
    End Function

    Public Function GetListar_activosFijosConteoAsientos() As List(Of activosFijos)
        Dim act As New activosFijos
        Dim consulta = (From activo In HeliosData.activosFijos
                        Select
                            activo.idActivo, activo.idEntidad, activo.cuenta,
                            activo.idEmpresa, activo.idEstablecimiento,
                            activo.descripcionItem, activo.unidadMedida,
                            activo.unidad2, activo.tipoActivo, activo.anio,
                            activo.nroSeriePlaca, activo.marca, activo.modelo,
                            activo.motor, activo.color, activo.transimision,
                            activo.odometro, activo.sistemaCombustion, activo.combustible,
                            activo.direccion, activo.destinoGravado, activo.usuarioActualizacion,
                            activo.fechaActualizacion,
            conteoASientos = (CType((Aggregate t1 In (From dis In HeliosData.distribucionInfraestructura
                                                      Where
                                                          dis.idActivo = activo.idActivo
                                                      Select New With {
                                                          dis.idDistribucion
                                                          }) Into Count()), Int64?))).ToList


        GetListar_activosFijosConteoAsientos = New List(Of activosFijos)
        For Each item In consulta
            act = New activosFijos
            act.idActivo = item.idActivo
            act.idEntidad = item.idEntidad
            act.cuenta = item.cuenta
            act.idEmpresa = item.idEmpresa
            act.idEstablecimiento = item.idEstablecimiento
            act.descripcionItem = item.descripcionItem
            act.unidadMedida = item.unidadMedida
            act.unidad2 = item.unidad2
            act.tipoActivo = item.tipoActivo
            act.anio = item.anio
            act.nroSeriePlaca = item.nroSeriePlaca
            act.marca = item.marca
            act.modelo = item.modelo
            act.motor = item.motor
            act.color = item.color
            act.transimision = item.transimision
            act.odometro = item.odometro
            act.sistemaCombustion = item.sistemaCombustion
            act.combustible = item.combustible
            act.direccion = item.direccion
            act.destinoGravado = item.destinoGravado
            act.usuarioActualizacion = item.conteoASientos

            GetListar_activosFijosConteoAsientos.Add(act)
        Next


    End Function

#End Region

End Class
