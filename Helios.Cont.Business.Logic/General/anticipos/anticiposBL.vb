Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class anticiposBL
    Inherits BaseBL

    Public Function Insert(ByVal anticiposBE As anticipos) As Integer
        Using ts As New TransactionScope
            HeliosData.anticipos.Add(anticiposBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return anticiposBE.idDocumento
        End Using
    End Function

    Public Sub Update(ByVal anticiposBE As anticipos)
        Using ts As New TransactionScope
            Dim anticipos As anticipos = HeliosData.anticipos.Where(Function(o) _
                                            o.idDocumento = anticiposBE.idDocumento).First()

            anticipos.idEmpresa = anticiposBE.idEmpresa
            anticipos.idEstablecimiento = anticiposBE.idEstablecimiento
            anticipos.tipoMovimiento = anticiposBE.tipoMovimiento
            anticipos.fechaPeriodo = anticiposBE.fechaPeriodo
            anticipos.fechaProceso = anticiposBE.fechaProceso
            anticipos.tipoDoc = anticiposBE.tipoDoc
            anticipos.numero = anticiposBE.numero
            anticipos.moneda = anticiposBE.moneda
            anticipos.idEntidad = anticiposBE.idEntidad
            anticipos.nombreEntidad = anticiposBE.nombreEntidad
            anticipos.tipoEntidad = anticiposBE.tipoEntidad
            anticipos.tipocambio = anticiposBE.tipocambio
            anticipos.formaPago = anticiposBE.formaPago
            anticipos.idEstablecimientoCaja = anticiposBE.idEstablecimientoCaja
            anticipos.entidadFinanciera = anticiposBE.entidadFinanciera
            anticipos.nombreFinanciera = anticiposBE.nombreFinanciera
            anticipos.importeMN = anticiposBE.importeMN
            anticipos.importeME = anticiposBE.importeME
            anticipos.glosa = anticiposBE.glosa
            anticipos.usuarioActualizacion = anticiposBE.usuarioActualizacion
            anticipos.fechaActualizacion = anticiposBE.fechaActualizacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(anticipos).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal anticiposBE As anticipos)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(anticiposBE)
    End Sub

    Public Function GetListar_anticipos() As List(Of anticipos)
        Return (From a In HeliosData.anticipos Select a).ToList
    End Function

    Public Function GetUbicar_anticiposPorID(idDocumento As Integer) As anticipos
        Return (From a In HeliosData.anticipos
                Where a.idDocumento = idDocumento Select a).First
    End Function
End Class
