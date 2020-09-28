Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class sist_recaudacionBL
    Inherits BaseBL

    Public Function Insert(ByVal sist_recaudacionBE As sist_recaudacion) As Integer
        Using ts As New TransactionScope
            HeliosData.sist_recaudacion.Add(sist_recaudacionBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return sist_recaudacionBE.id
        End Using
    End Function

    Public Sub Update(ByVal sist_recaudacionBE As sist_recaudacion)
        Using ts As New TransactionScope
            Dim sist_recd As sist_recaudacion = HeliosData.sist_recaudacion.Where(Function(o) _
                                            o.id = sist_recaudacionBE.id _
                                            And o.idItem = sist_recaudacionBE.idItem).First()

            sist_recd.tipoSistema = sist_recaudacionBE.tipoSistema
            sist_recd.modulo = sist_recaudacionBE.modulo
            sist_recd.descripcion = sist_recaudacionBE.descripcion
            sist_recd.tasa = sist_recaudacionBE.tasa
            sist_recd.vigencia = sist_recaudacionBE.vigencia
            sist_recd.cuenta = sist_recaudacionBE.cuenta
            sist_recd.ubicacion = sist_recaudacionBE.ubicacion
            sist_recd.montoAfecto = sist_recaudacionBE.montoAfecto
            sist_recd.usuarioModificacion = sist_recaudacionBE.usuarioModificacion
            sist_recd.fechaModificacion = sist_recaudacionBE.fechaModificacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(sist_recd).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal sist_recaudacionBE As sist_recaudacion)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(sist_recaudacionBE)
    End Sub

    Public Function GetListar_sist_recaudacion() As List(Of sist_recaudacion)
        Return (From a In HeliosData.sist_recaudacion Select a).ToList
    End Function

    Public Function GetUbicar_sist_recaudacionPorID(id As Integer) As sist_recaudacion
        Return (From a In HeliosData.sist_recaudacion
                 Where a.id = id Select a).First
    End Function
End Class
