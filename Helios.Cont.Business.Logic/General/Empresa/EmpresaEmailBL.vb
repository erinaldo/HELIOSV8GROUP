Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class EmpresaEmailBL
    Inherits BaseBL

    Public Function Insert(ByVal EmpresaEmailBE As EmpresaEmail) As Integer
        Using ts As New TransactionScope
            HeliosData.EmpresaEmail.Add(EmpresaEmailBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return EmpresaEmailBE.codigo
        End Using
    End Function

    Public Sub Update(ByVal EmpresaEmailBE As EmpresaEmail)
        Using ts As New TransactionScope
            Dim EmpEmail As EmpresaEmail = HeliosData.EmpresaEmail.Where(Function(o) _
                                            o.codigo = EmpresaEmailBE.codigo _
                                            And o.idEmpresa = EmpresaEmailBE.idEmpresa).First()

            EmpEmail.nombreUsuario = EmpresaEmailBE.nombreUsuario
            EmpEmail.passUsuario = EmpresaEmailBE.passUsuario
            EmpEmail.email = EmpresaEmailBE.email
            EmpEmail.tipoCorreo = EmpresaEmailBE.tipoCorreo
            EmpEmail.usuarioActualizacion = EmpresaEmailBE.usuarioActualizacion
            EmpEmail.fechaActualizacion = EmpresaEmailBE.fechaActualizacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(EmpEmail).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal EmpresaEmailBE As EmpresaEmail)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(EmpresaEmailBE)
    End Sub

    Public Function GetListar_EmpresaEmail() As List(Of EmpresaEmail)
        Return (From a In HeliosData.EmpresaEmail Select a).ToList
    End Function

    Public Function GetUbicar_EmpresaEmailPorID(codigo As Integer) As EmpresaEmail
        Return (From a In HeliosData.EmpresaEmail
                 Where a.codigo = codigo Select a).First
    End Function
End Class
