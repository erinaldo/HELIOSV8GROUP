Imports Helios.Planilla.Business.Entity

Public Class PlantillaDetalleBL
    Inherits BaseBL(Of PlantillaDetalle)

    ''' <summary>
    ''' Retorna la lista de conceptors asociados a una plantilla
    ''' </summary>
    ''' <param name="item">plantillaDetalle.IDPlantilla</param>
    ''' <returns>lista de objetos PlantillaDetalle que representa los conceptos asociados</returns>
    ''' <remarks></remarks>
    Public Function PlantillaDetalleSelxPlantilla(item As PlantillaDetalle) As List(Of PlantillaDetalle)
        Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Reading)
            Return scope.DBContext.PlantillaDetalle.Where(Function(o) o.IDPlantilla = item.IDPlantilla).ToList
        End Using
    End Function

    Public Function PlantillaDetalleSelxPlantillaxConcepto(item As PlantillaDetalle) As PlantillaDetalle
        Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Reading)
            Return scope.DBContext.PlantillaDetalle.Where(Function(o) o.IDPlantilla = item.IDPlantilla And o.IDConcepto = item.IDConcepto).FirstOrDefault
        End Using
    End Function

    Public Function PlantillaDetalleSelxPlantillaV2(item As PlantillaDetalle) As List(Of PlantillaDetalle)
        Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Reading)
            Dim lstConceptos = scope.DBContext.PlantillaDetalle.Where(Function(o) o.IDPlantilla = item.IDPlantilla).Join(scope.DBContext.Concepto,
                                    Function(s) s.IDConcepto,
                                    Function(std) std.IDConcepto,
                                    Function(s, std) New With
                                    {
                                        .IDConepto = s.IDConcepto,
                                        .IDSunat = std.IDSunat,
                                        .IDContable = std.IDContable,
                                        .IDplantilla = s.IDPlantilla,
                                        .DescripcionCorta = std.DescripcionCorta,
                                        .Nombreconcepto = std.DescripcionLarga,
                                        .tipoConcepto = std.TipoConcepto,
                                        .Moneda = std.Moneda,
                                        .TipoCalculo = std.TipoCalculo,
                                        .Formlua = std.Formula,
                                        .ValorConcepto = s.valorConcepto,
                                        .tipoPlanilla = std.TipoPlanilla,
                                        .Requerido = s.Requerido
                                    }).ToList

            PlantillaDetalleSelxPlantillaV2 = New List(Of PlantillaDetalle)
            For Each i In lstConceptos
                PlantillaDetalleSelxPlantillaV2.Add(New PlantillaDetalle With
                                                    {
                                                    .IDPlantilla = i.IDplantilla,
                                                    .valorConcepto = i.ValorConcepto,
                                                    .Requerido = i.Requerido,
                                                    .CustomConcepto = New Concepto With
                                                    {
                                                    .IDConcepto = i.IDConepto,
                                                    .IDSunat = i.IDSunat,
                                                    .IDContable = i.IDContable,
                                                    .DescripcionCorta = i.DescripcionCorta,
                                                    .DescripcionLarga = i.Nombreconcepto,
                                                    .TipoConcepto = i.tipoConcepto,
                                                    .Moneda = i.Moneda,
                                                    .TipoCalculo = i.TipoCalculo,
                                                    .Formula = i.Formlua,
                                                    .ValorCalculo = i.ValorConcepto,
                                                    .TipoPlanilla = i.tipoPlanilla
                                                    }})
            Next

        End Using
    End Function


    Public Function PlanillaDetalleSave(ByVal item As PlantillaDetalle, log As TransactionDataBE) As PlantillaDetalle
        Dim BLPlantillaDetalle As New PlantillaDetalleBL
        'item.UsuarioModificacion = log.LoggedUser
        'item.FechaModificacion = Date.Now
        Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Writing)
            'Se inserta el registro principal
            If item.Action = BaseBE.EntityAction.UPDATE Then
                Me.Update(item)
            Else
                Me.Insert(item)
            End If
            'Se inserta los detalles
            scope.SaveChanges()
        End Using
        Return item
    End Function

End Class
