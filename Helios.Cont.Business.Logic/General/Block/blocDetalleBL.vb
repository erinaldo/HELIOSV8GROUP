Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class blocDetalleBL
    Inherits BaseBL

    Public Function Insert(ByVal blocDetalleBE As blocDetalle) As Integer
        Using ts As New TransactionScope
            HeliosData.blocDetalle.Add(blocDetalleBE)
            HeliosData.SaveChanges()
            ts.Complete()
            Return blocDetalleBE.IdBloc
        End Using
    End Function

    Public Sub Update(ByVal blocDetalleBE As blocDetalle)
        Using ts As New TransactionScope
            Dim blocDet As blocDetalle = HeliosData.blocDetalle.Where(Function(o) _
                                            o.IdBloc = blocDetalleBE.IdBloc _
                                            And o.secuencia = blocDetalleBE.secuencia).First()

            blocDet.descripcion = blocDetalleBE.descripcion
            blocDet.numDoc = blocDetalleBE.numDoc
            blocDet.detalleExtra = blocDetalleBE.detalleExtra
            blocDet.unidad = blocDetalleBE.unidad
            blocDet.cantidad = blocDetalleBE.cantidad
            blocDet.precUnit = blocDetalleBE.precUnit
            blocDet.importe = blocDetalleBE.importe
            blocDet.usuarioActualizacion = blocDetalleBE.usuarioActualizacion
            blocDet.fechaActualizacion = blocDetalleBE.fechaActualizacion

            'HeliosData.ObjectStateManager.GetObjectStateEntry(blocDet).State.ToString()

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub Delete(ByVal blocDetalleBE As blocDetalle)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(blocDetalleBE)
    End Sub

    Public Function GetListar_blocDetalle() As List(Of blocDetalle)
        Return (From a In HeliosData.blocDetalle Select a).ToList
    End Function

    Public Function GetUbicar_blocDetallePorID(IdBloc As Integer) As blocDetalle
        Return (From a In HeliosData.blocDetalle
                Where a.IdBloc = IdBloc Select a).First
    End Function

End Class
