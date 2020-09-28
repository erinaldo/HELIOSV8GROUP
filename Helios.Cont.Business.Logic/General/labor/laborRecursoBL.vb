Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class laborRecursoBL
    Inherits BaseBL

    Public Function Insert(ByVal laborRecursoBE As laborRecurso) As Integer
        Using ts As New TransactionScope
            HeliosData.laborRecurso.Add(laborRecursoBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return laborRecursoBE.idlaborRecurso
        End Using
    End Function
    Public Sub Update(ByVal laborRecursoBE As laborRecurso)
        Using ts As New TransactionScope
            Dim laborRec As laborRecurso = HeliosData.laborRecurso.Where(Function(o) _
                                            o.idlaborRecurso = laborRecursoBE.idlaborRecurso _
                                            And o.idLabor = laborRecursoBE.idLabor).First()

            laborRec.idActividadRecurso = laborRecursoBE.idActividadRecurso
            laborRec.descripcionItem = laborRecursoBE.descripcionItem
            laborRec.unidad = laborRecursoBE.unidad
            laborRec.cantidad = laborRecursoBE.cantidad
            laborRec.precUnit = laborRecursoBE.precUnit
            laborRec.Importe = laborRecursoBE.Importe
            laborRec.usuarioActualizacion = laborRecursoBE.usuarioActualizacion
            laborRec.fechaActualizacion = laborRecursoBE.fechaActualizacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(laborRec).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


    Public Sub Delete(ByVal laborRecursoBE As laborRecurso)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(laborRecursoBE)
    End Sub

    Public Function GetListar_laborRecurso() As List(Of laborRecurso)
        Return (From a In HeliosData.laborRecurso Select a).ToList
    End Function

    Public Function GetUbicar_laborRecursoPorID(idlaborRecurso As Integer) As laborRecurso
        Return (From a In HeliosData.laborRecurso
                 Where a.idlaborRecurso = idlaborRecurso Select a).First
    End Function
End Class
