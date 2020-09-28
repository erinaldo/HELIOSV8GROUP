Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class ordenComprasBL
    Inherits BaseBL

    Public Function Insert(ByVal ordenComprasBE As ordenCompras) As Integer
        Using ts As New TransactionScope
            HeliosData.ordenCompras.Add(ordenComprasBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return ordenComprasBE.idOrden
        End Using
    End Function

    Public Sub Update(ByVal ordenComprasBE As ordenCompras)
        Using ts As New TransactionScope
            Dim ordCompras As ordenCompras = HeliosData.ordenCompras.Where(Function(o) _
                                            o.idOrden = ordenComprasBE.idOrden).First()

            ordCompras.idEmpresa = ordenComprasBE.idEmpresa
            ordCompras.idEstablecimiento = ordenComprasBE.idEstablecimiento
            ordCompras.idProyecto = ordenComprasBE.idProyecto
            ordCompras.idEvento = ordenComprasBE.idEvento
            ordCompras.idProceso = ordenComprasBE.idProceso
            ordCompras.idTarea = ordenComprasBE.idTarea
            ordCompras.tipoOrden = ordenComprasBE.tipoOrden
            ordCompras.codigoOrden = ordenComprasBE.codigoOrden
            ordCompras.fechaProceso = ordenComprasBE.fechaProceso
            ordCompras.periodo = ordenComprasBE.periodo
            ordCompras.tipoOperacion = ordenComprasBE.tipoOperacion
            ordCompras.confirmado = ordenComprasBE.confirmado
            ordCompras.importeMN = ordenComprasBE.importeMN
            ordCompras.importeME = ordenComprasBE.importeME
            ordCompras.usuarioModificacion = ordenComprasBE.usuarioModificacion
            ordCompras.fechaModificacion = ordenComprasBE.fechaModificacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(ordCompras).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


    Public Sub Delete(ByVal ordenComprasBE As ordenCompras)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(ordenComprasBE)
    End Sub

    Public Function GetListar_ordenCompras() As List(Of ordenCompras)
        Return (From a In HeliosData.ordenCompras Select a).ToList
    End Function

    Public Function GetUbicar_ordenComprasPorID(idOrden As Integer) As ordenCompras
        Return (From a In HeliosData.ordenCompras
                 Where a.idOrden = idOrden Select a).First
    End Function
End Class
