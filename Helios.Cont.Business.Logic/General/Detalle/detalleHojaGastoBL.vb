Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class detalleHojaGastoBL
    Inherits BaseBL

    Public Function Insert(ByVal detalleHojaGastoBE As detalleHojaGasto) As Integer
        Using ts As New TransactionScope
            HeliosData.detalleHojaGasto.Add(detalleHojaGastoBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return detalleHojaGastoBE.secuencia
        End Using
    End Function

    Public Sub Update(ByVal detalleHojaGastoBE As detalleHojaGasto)
        Using ts As New TransactionScope
            Dim detHojaGasto As detalleHojaGasto = HeliosData.detalleHojaGasto.Where(Function(o) _
                                            o.idGasto = detalleHojaGastoBE.idGasto _
                                            And o.idEmpresa = detalleHojaGastoBE.idEmpresa _
                                            And o.idEstablecimiento = detalleHojaGastoBE.idEstablecimiento _
                                            And o.idActividad = detalleHojaGastoBE.idActividad).First()

            detHojaGasto.idGasto = detalleHojaGastoBE.idGasto
            detHojaGasto.idEmpresa = detalleHojaGastoBE.idEmpresa
            detHojaGasto.idEstablecimiento = detalleHojaGastoBE.idEstablecimiento
            detHojaGasto.secuencia = detalleHojaGastoBE.secuencia
            detHojaGasto.idEstablecimientoOrigen = detalleHojaGastoBE.idEstablecimientoOrigen
            detHojaGasto.idActividad = detalleHojaGastoBE.idActividad
            detHojaGasto.idDocumento = detalleHojaGastoBE.idDocumento
            detHojaGasto.elementoCosto = detalleHojaGastoBE.elementoCosto
            detHojaGasto.codigoLibro = detalleHojaGastoBE.codigoLibro
            detHojaGasto.fecha = detalleHojaGastoBE.fecha
            detHojaGasto.destinoGravado = detalleHojaGastoBE.destinoGravado
            detHojaGasto.cuentaConcepto = detalleHojaGastoBE.cuentaConcepto
            detHojaGasto.descripcionConcepto = detalleHojaGastoBE.descripcionConcepto
            detHojaGasto.idTrabajador = detalleHojaGastoBE.idTrabajador
            detHojaGasto.importe = detalleHojaGastoBE.importe
            detHojaGasto.importeUSD = detalleHojaGastoBE.importeUSD
            detHojaGasto.usuarioActualizacion = detalleHojaGastoBE.usuarioActualizacion
            detHojaGasto.fechaActualizacion = detalleHojaGastoBE.fechaActualizacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(detHojaGasto).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal detalleHojaGastoBE As detalleHojaGasto)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(detalleHojaGastoBE)
    End Sub

    Public Function GetListar_detalleHojaGasto() As List(Of detalleHojaGasto)
        Return (From a In HeliosData.detalleHojaGasto Select a).ToList
    End Function

    Public Function GetUbicar_detalleHojaGastoPorID(Secuencia As Integer) As detalleHojaGasto
        Return (From a In HeliosData.detalleHojaGasto
                 Where a.secuencia = Secuencia Select a).First
    End Function
End Class

