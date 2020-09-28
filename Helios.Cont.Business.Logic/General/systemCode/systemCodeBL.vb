Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class systemCodeBL
    Inherits BaseBL

    Public Function Insert(ByVal systemCodeBE As systemCode) As Integer
        Using ts As New TransactionScope
            HeliosData.systemCode.Add(systemCodeBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return systemCodeBE.idtabla
        End Using
    End Function

    Public Sub Update(ByVal systemCodeBE As systemCode)
        Using ts As New TransactionScope
            Dim systemCode As systemCode = HeliosData.systemCode.Where(Function(o) _
                                            o.idtabla = systemCodeBE.idtabla).First()

            systemCode.codigoNumeracion = systemCodeBE.codigoNumeracion
            systemCode.valorInicial = systemCodeBE.valorInicial
            systemCode.empresa = systemCodeBE.empresa
            systemCode.establecimiento = systemCodeBE.establecimiento
            systemCode.usuarioActualizacion = systemCodeBE.usuarioActualizacion
            systemCode.fechaActualizacion = systemCodeBE.fechaActualizacion

            
            'HeliosData.ObjectStateManager.GetObjectStateEntry(systemCode).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal systemCodeBE As systemCode)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(systemCodeBE)
    End Sub

    Public Function GetListar_systemCode() As List(Of systemCode)
        Return (From a In HeliosData.systemCode Select a).ToList
    End Function

    Public Function GetUbicar_systemCodePorID(idtabla As Integer) As systemCode
        Return (From a In HeliosData.systemCode
                 Where a.idtabla = idtabla Select a).First
    End Function
End Class
