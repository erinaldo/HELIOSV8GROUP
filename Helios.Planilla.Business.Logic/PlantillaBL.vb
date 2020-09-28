Imports Helios.Planilla.Business.Entity

Public Class PlantillaBL
    Inherits BaseBL(Of Plantilla)

    Public Function PlantillaSelAll() As List(Of Plantilla)
        Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Reading)
            Return scope.DBContext.Plantilla.OrderBy(Function(o) o.DescripcionCorta).ToList
        End Using
    End Function

    ''' <summary>
    ''' Graba información de planilla incluído sus detalles
    ''' </summary>
    ''' <param name="item"></param>
    ''' <remarks></remarks>
    Public Sub PlanillaSaveAll(ByVal item As Plantilla, log As TransactionDataBE)
        Dim BLPlantillaDetalle As New PlantillaDetalleBL
        item.UsuarioModificacion = log.LoggedUser
        item.FechaModificacion = Date.Now
        Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Writing)
            'Se inserta el registro principal
            If item.Action = BaseBE.EntityAction.UPDATE Then
                Me.Update(item)
            Else
                Me.Insert(item)
            End If
            'Se inserta los detalles
            For Each obj In item.PlantillaDetalle
                obj.Plantilla = item
                obj.IDPlantilla = item.IDPlantilla
                obj.UsuarioModificacion = log.LoggedUser
                obj.FechaModificacion = Date.Now
                Select Case obj.Action
                    Case BaseBE.EntityAction.DELETE
                        BLPlantillaDetalle.Delete(obj)
                    Case BaseBE.EntityAction.INSERT
                        BLPlantillaDetalle.Insert(obj)
                    Case BaseBE.EntityAction.UPDATE
                        BLPlantillaDetalle.Update(obj)
                End Select
            Next
            scope.SaveChanges()
        End Using
    End Sub
End Class
