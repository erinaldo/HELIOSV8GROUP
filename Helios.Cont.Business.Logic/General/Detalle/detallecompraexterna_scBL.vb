Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class detallecompraexterna_scBL
    Inherits BaseBL

    Public Function Insert(ByVal detallecompraexterna_scBE As detallecompraexterna_sc) As Integer
        Using ts As New TransactionScope
            HeliosData.detallecompraexterna_sc.Add(detallecompraexterna_scBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return detallecompraexterna_scBE.secuencia
        End Using
    End Function

    Public Sub Update(ByVal detallecompraexterna_scBE As detallecompraexterna_sc)
        Using ts As New TransactionScope
            Dim detCompraexterna_sc As detallecompraexterna_sc = HeliosData.detallecompraexterna_sc.Where(Function(o) _
                                            o.idDocumento = detallecompraexterna_scBE.idDocumento _
                                            And o.secuencia = detallecompraexterna_scBE.secuencia).First()

            detCompraexterna_sc.idItem = detallecompraexterna_scBE.idItem
            detCompraexterna_sc.descripcionItem = detallecompraexterna_scBE.descripcionItem
            detCompraexterna_sc.destino = detallecompraexterna_scBE.destino
            detCompraexterna_sc.unidad1 = detallecompraexterna_scBE.unidad1
            detCompraexterna_sc.cantidad1 = detallecompraexterna_scBE.cantidad1
            detCompraexterna_sc.unidad2 = detallecompraexterna_scBE.unidad2
            detCompraexterna_sc.cantidad2 = detallecompraexterna_scBE.cantidad2
            detCompraexterna_sc.precioUnitario = detallecompraexterna_scBE.precioUnitario
            detCompraexterna_sc.precioUnitarioUS = detallecompraexterna_scBE.precioUnitarioUS
            detCompraexterna_sc.importe = detallecompraexterna_scBE.importe
            detCompraexterna_sc.importeUS = detallecompraexterna_scBE.importeUS
            detCompraexterna_sc.montokardex = detallecompraexterna_scBE.montokardex
            detCompraexterna_sc.montoIsc = detallecompraexterna_scBE.montoIsc
            detCompraexterna_sc.montoIgv = detallecompraexterna_scBE.montoIgv
            detCompraexterna_sc.otrosTributos = detallecompraexterna_scBE.otrosTributos
            detCompraexterna_sc.montokardexUS = detallecompraexterna_scBE.montokardexUS
            detCompraexterna_sc.montoIscUS = detallecompraexterna_scBE.montoIscUS
            detCompraexterna_sc.montoIgvUS = detallecompraexterna_scBE.montoIgvUS
            detCompraexterna_sc.otrosTributosUS = detallecompraexterna_scBE.otrosTributosUS
            detCompraexterna_sc.preEvento = detallecompraexterna_scBE.preEvento
            detCompraexterna_sc.usuarioModificacion = detallecompraexterna_scBE.usuarioModificacion
            detCompraexterna_sc.fechaModificacion = detallecompraexterna_scBE.fechaModificacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(detCompraexterna_sc).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


    Public Sub Delete(ByVal detallecompraexterna_scBE As detallecompraexterna_sc)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(detallecompraexterna_scBE)
    End Sub

    Public Function GetListar_detallecompraexterna_sc() As List(Of detallecompraexterna_sc)
        Return (From a In HeliosData.detallecompraexterna_sc Select a).ToList
    End Function

    Public Function GetUbicar_detallecompraexterna_scPorID(Secuencia As Integer) As detallecompraexterna_sc
        Return (From a In HeliosData.detallecompraexterna_sc
                 Where a.secuencia = Secuencia Select a).First
    End Function
End Class
