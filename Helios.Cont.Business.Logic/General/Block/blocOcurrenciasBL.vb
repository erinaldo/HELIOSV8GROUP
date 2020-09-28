Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class blocOcurrenciasBL
    Inherits BaseBL

    Public Function Insert(ByVal blocOcurrenciasBE As blocOcurrencias) As Integer
        Using ts As New TransactionScope
            HeliosData.blocOcurrencias.Add(blocOcurrenciasBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return blocOcurrenciasBE.secuencia
        End Using
    End Function

    Public Sub Update(ByVal blocOcurrenciasBE As blocOcurrencias)
        Using ts As New TransactionScope
            Dim blocOcurr As blocOcurrencias = HeliosData.blocOcurrencias.Where(Function(o) _
                                            o.secuencia = blocOcurrenciasBE.secuencia).First()

            blocOcurr.idGop = blocOcurrenciasBE.idGop
            blocOcurr.codigoActividad = blocOcurrenciasBE.codigoActividad
            blocOcurr.fecha = blocOcurrenciasBE.fecha
            blocOcurr.Descripcion = blocOcurrenciasBE.Descripcion
            blocOcurr.Avance = blocOcurrenciasBE.Avance
            blocOcurr.calidadLabor = blocOcurrenciasBE.calidadLabor
            blocOcurr.usuarioActualizacion = blocOcurrenciasBE.usuarioActualizacion
            blocOcurr.fechaActualizacion = blocOcurrenciasBE.fechaActualizacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(blocOcurr).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal blocOcurrenciasBE As blocOcurrencias)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(blocOcurrenciasBE)
    End Sub

    Public Function GetListar_blocOcurrencias() As List(Of blocOcurrencias)
        Return (From a In HeliosData.blocOcurrencias Select a).ToList
    End Function

    Public Function GetUbicar_blocOcurrenciasPorID(Secuencia As Integer) As blocOcurrencias
        Return (From a In HeliosData.blocOcurrencias
                Where a.secuencia = Secuencia Select a).First
    End Function
End Class
