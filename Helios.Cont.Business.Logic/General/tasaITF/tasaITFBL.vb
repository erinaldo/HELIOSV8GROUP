Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class tasaITFBL
    Inherits BaseBL

    Public Function Insert(ByVal tasaITFBE As tasaITF) As Integer
        Using ts As New TransactionScope
            HeliosData.tasaITF.Add(tasaITFBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return tasaITFBE.idTasa
        End Using
    End Function

    Public Sub Update(ByVal tasaITFBE As tasaITF)
        Using ts As New TransactionScope
            Dim tasaITF As tasaITF = HeliosData.tasaITF.Where(Function(o) _
                                            o.idTasa = tasaITFBE.idTasa).First()

            tasaITF.tasaProcentaje = tasaITFBE.tasaProcentaje
            tasaITF.tasaCovertido = tasaITFBE.tasaCovertido
            tasaITF.fechaInicial = tasaITFBE.fechaInicial
            tasaITF.fechaHasta = tasaITFBE.fechaHasta
            tasaITF.continuo = tasaITFBE.continuo
            tasaITF.usuarioActualizacion = tasaITFBE.usuarioActualizacion
            tasaITF.fechaActualizacion = tasaITFBE.fechaActualizacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(tasaITF).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal tasaITFBE As tasaITF)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(tasaITFBE)
    End Sub

    Public Function GetListar_tasaITF() As List(Of tasaITF)
        Return (From a In HeliosData.tasaITF Select a).ToList
    End Function

    Public Function GetUbicar_tasaITFPorID(idTasa As Integer) As tasaITF
        Return (From a In HeliosData.tasaITF
                 Where a.idTasa = idTasa Select a).First
    End Function
End Class
