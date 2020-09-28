Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class mascaraProdTerminadoBL
    Inherits BaseBL

    Public Function Insert(ByVal mascaraProdTerminadoBE As mascaraProdTerminado) As Integer
        Using ts As New TransactionScope
            HeliosData.mascaraProdTerminado.Add(mascaraProdTerminadoBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return mascaraProdTerminadoBE.idProd
        End Using
    End Function

    Public Sub Update(ByVal mascaraProdTerminadoBE As mascaraProdTerminado)
        Using ts As New TransactionScope
            Dim masckProdTerm As mascaraProdTerminado = HeliosData.mascaraProdTerminado.Where(Function(o) _
                                            o.idProd = mascaraProdTerminadoBE.idProd).First()

            masckProdTerm.tipoExistencia = mascaraProdTerminadoBE.tipoExistencia
            masckProdTerm.cuentaIngAlmacen = mascaraProdTerminadoBE.cuentaIngAlmacen
            masckProdTerm.nameIngAlmacen = mascaraProdTerminadoBE.nameIngAlmacen
            masckProdTerm.cuentaIngAlmacen2 = mascaraProdTerminadoBE.cuentaIngAlmacen2
            masckProdTerm.nameIngAlmacen2 = mascaraProdTerminadoBE.nameIngAlmacen2
            masckProdTerm.cuentaVenta = mascaraProdTerminadoBE.cuentaVenta
            masckProdTerm.nameVenta = mascaraProdTerminadoBE.nameVenta
            masckProdTerm.cuentaVentapt = mascaraProdTerminadoBE.cuentaVentapt
            masckProdTerm.nameVentapt = mascaraProdTerminadoBE.nameVentapt
            masckProdTerm.cuentaVentapt2 = mascaraProdTerminadoBE.cuentaVentapt2
            masckProdTerm.nameVentapt2 = mascaraProdTerminadoBE.nameVentapt2

            'HeliosData.ObjectStateManager.GetObjectStateEntry(masckProdTerm).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


    Public Sub Delete(ByVal mascaraProdTerminadoBE As mascaraProdTerminado)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(mascaraProdTerminadoBE)
    End Sub

    Public Function GetListar_mascaraProdTerminado() As List(Of mascaraProdTerminado)
        Return (From a In HeliosData.mascaraProdTerminado Select a).ToList
    End Function

    Public Function GetUbicar_mascaraProdTerminadoPorID(idProd As Integer) As mascaraProdTerminado
        Return (From a In HeliosData.mascaraProdTerminado
                 Where a.idProd = idProd Select a).First
    End Function
End Class
