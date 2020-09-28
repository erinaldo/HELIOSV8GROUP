Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class laborRecursoPersonaBL
    Inherits BaseBL

    Public Function Insert(ByVal laborRecursoPersonaBE As laborRecursoPersona) As Integer
        Using ts As New TransactionScope
            HeliosData.laborRecursoPersona.Add(laborRecursoPersonaBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return laborRecursoPersonaBE.secuencia
        End Using
    End Function

    Public Sub Update(ByVal laborRecursoPersonaBE As laborRecursoPersona)
        Using ts As New TransactionScope
            Dim laborRecPersona As laborRecursoPersona = HeliosData.laborRecursoPersona.Where(Function(o) _
                                            o.secuencia = laborRecursoPersonaBE.secuencia _
                                            And o.idlaborRecurso = laborRecursoPersonaBE.idlaborRecurso).First()

            laborRecPersona.grupoOperacional = laborRecursoPersonaBE.grupoOperacional
            laborRecPersona.establePersonal = laborRecursoPersonaBE.establePersonal
            laborRecPersona.unidadArea = laborRecursoPersonaBE.unidadArea
            laborRecPersona.idPersonal = laborRecursoPersonaBE.idPersonal
            laborRecPersona.usuarioActualizacion = laborRecursoPersonaBE.usuarioActualizacion
            laborRecPersona.fechaActualizacion = laborRecursoPersonaBE.fechaActualizacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(laborRecPersona).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


    Public Sub Delete(ByVal laborRecursoPersonaBE As laborRecursoPersona)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(laborRecursoPersonaBE)
    End Sub

    Public Function GetListar_laborRecursoPersona() As List(Of laborRecursoPersona)
        Return (From a In HeliosData.laborRecursoPersona Select a).ToList
    End Function

    Public Function GetUbicar_laborRecursoPersonaPorID(Secuencia As Integer) As laborRecursoPersona
        Return (From a In HeliosData.laborRecursoPersona
                 Where a.secuencia = Secuencia Select a).First
    End Function
End Class
