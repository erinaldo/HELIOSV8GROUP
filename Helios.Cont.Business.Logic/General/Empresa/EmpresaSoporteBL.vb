Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class EmpresaSoporteBL
    Inherits BaseBL

    Public Function Insert(ByVal EmpresaSoporteBE As EmpresaSoporte) As Integer
        Using ts As New TransactionScope
            HeliosData.EmpresaSoporte.Add(EmpresaSoporteBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return EmpresaSoporteBE.idSoporte
        End Using
    End Function

    Public Sub Update(ByVal EmpresaSoporteBE As EmpresaSoporte)
        Using ts As New TransactionScope
            Dim EmpSoporte As EmpresaSoporte = HeliosData.EmpresaSoporte.Where(Function(o) _
                                            o.idSoporte = EmpresaSoporteBE.idSoporte _
                                            And o.idEmpresa = EmpresaSoporteBE.idEmpresa).First()

            EmpSoporte.tipoSoporte = EmpresaSoporteBE.tipoSoporte
            EmpSoporte.descripcion = EmpresaSoporteBE.descripcion
            EmpSoporte.otros = EmpresaSoporteBE.otros
            EmpSoporte.usuarioActualizacion = EmpresaSoporteBE.usuarioActualizacion
            EmpSoporte.fechaActualizacion = EmpresaSoporteBE.fechaActualizacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(EmpSoporte).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal EmpresaSoporteBE As EmpresaSoporte)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(EmpresaSoporteBE)
    End Sub

    Public Function GetListar_EmpresaSoporte() As List(Of EmpresaSoporte)
        Return (From a In HeliosData.EmpresaSoporte Select a).ToList
    End Function

    Public Function GetUbicar_EmpresaSoportePorID(idSoporte As Integer) As EmpresaSoporte
        Return (From a In HeliosData.EmpresaSoporte
                 Where a.idSoporte = idSoporte Select a).First
    End Function
End Class
