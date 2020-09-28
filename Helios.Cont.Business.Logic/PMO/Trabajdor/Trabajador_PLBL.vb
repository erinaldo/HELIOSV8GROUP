Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class Trabajador_PLBL
    Inherits BaseBL

    Public Sub Insert(ByVal trabBE As Trabajador_PL)
        Using ts As New TransactionScope
            'Se inserta entidad
            HeliosData.Trabajador_PL.Add(trabBE)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Update(ByVal trabBE As Trabajador_PL)
        Using ts As New TransactionScope
            'Se actualiza entidadBE
            'HeliosData.asiento.Attach(asientoBE)
            HeliosData.Trabajador_PL.Attach(trabBE)
            HeliosData.Entry(trabBE).State = System.Data.Entity.EntityState.Modified
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal trabBE As Trabajador_PL)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(trabBE)
    End Sub

    Function ObtenerTrabPorEmpresa(strIdEmpresa As String) As List(Of Trabajador_PL)
        Return (From a In HeliosData.Trabajador_PL
              Where a.idEmpresa = strIdEmpresa _
              Select a).ToList
    End Function

    Function ObtenerTrabPorEstable(intIdEstable As Integer) As List(Of Trabajador_PL)
        Return (From a In HeliosData.Trabajador_PL
              Where a.idEstablecimiento = intIdEstable _
              Select a).ToList
    End Function

    Function ObtenerTrabPorDNI(strDNI As String, intIdEstable As Integer) As Trabajador_PL
        Return (From a In HeliosData.Trabajador_PL
              Where a.codTrabajdor = strDNI _
              And a.idEstablecimiento = intIdEstable _
              Select a).First
    End Function

    Function ObtenerTrabPorDNIExcel(strDNI As String, intIdEstable As Integer) As Integer
        Return (From a In HeliosData.Trabajador_PL
              Where a.codTrabajdor = strDNI _
              And a.idEstablecimiento = intIdEstable Select a.codTrabajdor).FirstOrDefault
    End Function

End Class
