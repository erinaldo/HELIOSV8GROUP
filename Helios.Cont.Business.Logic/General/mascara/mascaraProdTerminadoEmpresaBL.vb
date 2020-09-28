Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class mascaraProdTerminadoEmpresaBL
    Inherits BaseBL

    Public Function Insert(ByVal mascaraProdTerminadoEmpresaBE As mascaraProdTerminadoEmpresa) As Integer
        Using ts As New TransactionScope
            HeliosData.mascaraProdTerminadoEmpresa.Add(mascaraProdTerminadoEmpresaBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return mascaraProdTerminadoEmpresaBE.idEmpresa
        End Using
    End Function

    Public Sub Update(ByVal mascaraProdTerminadoEmpresaBE As mascaraProdTerminadoEmpresa)
        Using ts As New TransactionScope
            Dim masckProdTerminadoEmp As mascaraProdTerminadoEmpresa = HeliosData.mascaraProdTerminadoEmpresa.Where(Function(o) _
                                            o.idEmpresa = mascaraProdTerminadoEmpresaBE.idEmpresa _
                                            And o.tipoExistencia = mascaraProdTerminadoEmpresaBE.tipoExistencia _
                                            And o.cuentaIngAlmacen = mascaraProdTerminadoEmpresaBE.cuentaIngAlmacen).First()

            masckProdTerminadoEmp.nameIngAlmacen = mascaraProdTerminadoEmpresaBE.nameIngAlmacen
            masckProdTerminadoEmp.cuentaIngAlmacen2 = mascaraProdTerminadoEmpresaBE.cuentaIngAlmacen2
            masckProdTerminadoEmp.nameIngAlmacen2 = mascaraProdTerminadoEmpresaBE.nameIngAlmacen2
            masckProdTerminadoEmp.cuentaVenta = mascaraProdTerminadoEmpresaBE.cuentaVenta
            masckProdTerminadoEmp.nameVenta = mascaraProdTerminadoEmpresaBE.nameVenta
            masckProdTerminadoEmp.cuentaVentapt = mascaraProdTerminadoEmpresaBE.cuentaVentapt
            masckProdTerminadoEmp.nameVentapt = mascaraProdTerminadoEmpresaBE.nameVentapt
            masckProdTerminadoEmp.cuentaVentapt2 = mascaraProdTerminadoEmpresaBE.cuentaVentapt2
            masckProdTerminadoEmp.nameVentapt2 = mascaraProdTerminadoEmpresaBE.nameVentapt2
            masckProdTerminadoEmp.usuarioActualizacion = mascaraProdTerminadoEmpresaBE.usuarioActualizacion
            masckProdTerminadoEmp.fechaActualizacion = mascaraProdTerminadoEmpresaBE.fechaActualizacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(masckProdTerminadoEmp).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


    Public Sub Delete(ByVal mascaraProdTerminadoEmpresaBE As mascaraProdTerminadoEmpresa)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(mascaraProdTerminadoEmpresaBE)
    End Sub

    Public Function GetListar_mascaraProdTerminadoEmpresa() As List(Of mascaraProdTerminadoEmpresa)
        Return (From a In HeliosData.mascaraProdTerminadoEmpresa Select a).ToList
    End Function

    Public Function GetUbicar_mascaraProdTerminadoEmpresaPorID(idEmpresa As String) As mascaraProdTerminadoEmpresa
        Return (From a In HeliosData.mascaraProdTerminadoEmpresa
                 Where a.idEmpresa = idEmpresa Select a).First
    End Function
End Class
