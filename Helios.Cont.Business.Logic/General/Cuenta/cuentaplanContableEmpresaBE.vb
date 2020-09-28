Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class cuentaplanContableEmpresaBE
    Inherits BaseBL

   


    Public Function Insert(ByVal cuentaplanContableEmpresaBE As cuentaplanContableEmpresa) As Integer
        Using ts As New TransactionScope
            HeliosData.cuentaplanContableEmpresa.Add(cuentaplanContableEmpresaBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return cuentaplanContableEmpresaBE.cuenta
        End Using
    End Function

    Public Sub Update(ByVal cuentaplanContableEmpresaBE As cuentaplanContableEmpresa)
        Using ts As New TransactionScope
            Dim ctaplanContableEmp As cuentaplanContableEmpresa = HeliosData.cuentaplanContableEmpresa.Where(Function(o) _
                                            o.idEmpresa = cuentaplanContableEmpresaBE.idEmpresa _
                                            And o.cuenta = cuentaplanContableEmpresaBE.cuenta).First()

            ctaplanContableEmp.cuentaPadre = cuentaplanContableEmpresaBE.cuentaPadre
            ctaplanContableEmp.descripcion = cuentaplanContableEmpresaBE.descripcion
            ctaplanContableEmp.Observaciones = cuentaplanContableEmpresaBE.Observaciones
            ctaplanContableEmp.usuarioModificacion = cuentaplanContableEmpresaBE.usuarioModificacion
            ctaplanContableEmp.fechaModificacion = cuentaplanContableEmpresaBE.fechaModificacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(ctaplanContableEmp).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


    Public Sub Delete(ByVal cuentaplanContableEmpresaBE As cuentaplanContableEmpresa)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(cuentaplanContableEmpresaBE)
    End Sub

    Public Function GetListar_cuentaplanContableEmpresa() As List(Of cuentaplanContableEmpresa)
        Return (From a In HeliosData.cuentaplanContableEmpresa Select a).ToList
    End Function

    Public Function GetUbicar_cuentaplanContableEmpresaPorID(cuenta As String) As cuentaplanContableEmpresa
        Return (From a In HeliosData.cuentaplanContableEmpresa
                 Where a.cuenta = cuenta Select a).First
    End Function
End Class
