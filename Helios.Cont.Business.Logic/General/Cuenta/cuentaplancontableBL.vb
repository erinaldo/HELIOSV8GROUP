Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class cuentaplancontableBL
    Inherits BaseBL

    Public Function Insert(ByVal cuentaplancontableBE As cuentaplancontable) As Integer
        Using ts As New TransactionScope
            HeliosData.cuentaplancontable.Add(cuentaplancontableBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return cuentaplancontableBE.cuenta

        End Using
    End Function

    Public Sub Update(ByVal cuentaplancontableBE As cuentaplancontable)
        Using ts As New TransactionScope
            Dim ctaplancontable As cuentaplancontable = HeliosData.cuentaplancontable.Where(Function(o) _
                                            o.idPlanContable = cuentaplancontableBE.idPlanContable _
                                            And o.cuenta = cuentaplancontableBE.cuenta).First()

            ctaplancontable.cuentaPadre = cuentaplancontableBE.cuentaPadre
            ctaplancontable.descripcion = cuentaplancontableBE.descripcion
            ctaplancontable.nivel = cuentaplancontableBE.nivel
            ctaplancontable.tipo = cuentaplancontableBE.tipo
            ctaplancontable.saldo = cuentaplancontableBE.saldo
            ctaplancontable.origen = cuentaplancontableBE.origen
            ctaplancontable.Cdc = cuentaplancontableBE.Cdc
            ctaplancontable.Aanual = cuentaplancontableBE.Aanual
            ctaplancontable.Acm = cuentaplancontableBE.Acm
            ctaplancontable.Observaciones = cuentaplancontableBE.Observaciones
            ctaplancontable.usuarioModificacion = cuentaplancontableBE.usuarioModificacion
            ctaplancontable.fechaModificacion = cuentaplancontableBE.fechaModificacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(ctaplancontable).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


    Public Sub Delete(ByVal cuentaplancontableBE As cuentaplancontable)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(cuentaplancontableBE)
    End Sub

    Public Function GetListar_cuentaplancontable() As List(Of cuentaplancontable)
        Return (From a In HeliosData.cuentaplancontable Select a).ToList
    End Function

    Public Function GetUbicar_cuentaplancontablePorID(cuenta As String) As cuentaplancontable
        Return (From a In HeliosData.cuentaplancontable
                 Where a.cuenta = cuenta Select a).First
    End Function
End Class
