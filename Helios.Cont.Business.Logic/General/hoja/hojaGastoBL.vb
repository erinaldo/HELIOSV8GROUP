Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class hojaGastoBL
    Inherits BaseBL

    Public Function Insert(ByVal hojaGastoBE As hojaGasto) As Integer
        Using ts As New TransactionScope
            HeliosData.hojaGasto.Add(hojaGastoBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return hojaGastoBE.idGasto
        End Using
    End Function

    Public Sub Update(ByVal hojaGastoBE As hojaGasto)
        Using ts As New TransactionScope
            Dim hojaGasto As hojaGasto = HeliosData.hojaGasto.Where(Function(o) _
                                            o.idGasto = hojaGastoBE.idGasto _
                                            And o.idEmpresa = hojaGastoBE.idEmpresa _
                                            And o.idEstablecimiento = hojaGastoBE.idEstablecimiento).First()

            hojaGasto.descripcion = hojaGastoBE.descripcion
            hojaGasto.codigoCuenta = hojaGastoBE.codigoCuenta
            hojaGasto.usuarioActualizacion = hojaGastoBE.usuarioActualizacion
            hojaGasto.fechaActualizacion = hojaGastoBE.fechaActualizacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(hojaGasto).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal hojaGastoBE As hojaGasto)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(hojaGastoBE)
    End Sub

    Public Function GetListar_hojaGasto() As List(Of hojaGasto)
        Return (From a In HeliosData.hojaGasto Select a).ToList
    End Function

    Public Function GetUbicar_hojaGastoPorID(idGasto As String) As hojaGasto
        Return (From a In HeliosData.hojaGasto
                 Where a.idGasto = idGasto Select a).First
    End Function
End Class
