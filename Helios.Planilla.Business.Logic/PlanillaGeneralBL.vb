Imports Helios.Planilla.Business.Entity

Public Class PlanillaGeneralBL
    Inherits BaseBL(Of PlanillaGeneral)

    Public Function PlanillaGeneralSelxID(item As PlanillaGeneral) As PlanillaGeneral
        Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Reading)
            Return scope.DBContext.PlanillaGeneral.Where(Function(o) o.IDPersonal = item.IDPersonal).FirstOrDefault
        End Using
    End Function

    Public Function PlanillaGeneralSelXPeriodo(item As PlanillaGeneral) As List(Of PlanillaGeneral)

        Dim lista As New List(Of PlanillaGeneral)
        Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Reading)

            ' Return scope.DBContext.PlanillaGeneral.Where(Function(o) o.AnioPlanilla = item.AnioPlanilla).ToList

            Dim consulta = (From pla In scope.DBContext.PlanillaGeneral
                            Join per In scope.DBContext.Personal On New With {pla.IDPersonal} Equals New With {per.IDPersonal}
                            Join cargo In scope.DBContext.PersonalCargo On New With {pla.IDCargo} Equals New With {cargo.IDCargo}
                            Where
                               CLng(pla.AnioPlanilla) = item.AnioPlanilla And
                               CLng(pla.MesPlanilla) = item.MesPlanilla
                            Group New With {pla, per, cargo} By
                                pla.IDPersonal,
                                pla.IDCargo,
                                cargo.DescripcionLarga,
                                pla.MesPlanilla,
                                pla.AnioPlanilla,
                                per.Nombre,
                                per.ApellidoMaterno,
                                per.ApellidoPaterno
                                Into g = Group
                            Select
                                IDPersonal,
                                IDCargo,
                                MesPlanilla,
                                AnioPlanilla,
                                DescripcionLarga,
                                ApellidoMaterno,
                                ApellidoPaterno,
                                Nombre,
                               Ingresos = CType(g.Sum(Function(p) (If(
                               (New String() {"100", "200", "300", "400", "500"}).Contains(p.pla.TipoConcepto), p.pla.Importe, 0))), Decimal?),
                               Deducciones_trabajador = CType(g.Sum(Function(p) (If(
                               (New String() {"600"}).Contains(p.pla.TipoConcepto), p.pla.Importe, 0))), Decimal?),
                               Descuentos_trabajador = CType(g.Sum(Function(p) (If(
                               (New String() {"700"}).Contains(p.pla.TipoConcepto), p.pla.Importe, 0))), Decimal?),
                               Aportaciones_empleador = CType(g.Sum(Function(p) (If(
                               (New String() {"800"}).Contains(p.pla.TipoConcepto), p.pla.Importe, 0))), Decimal?)).ToList


            For Each i In consulta
                lista.Add(New PlanillaGeneral With {
                    .IDPersonal = i.IDPersonal,
                    .IDCargo = i.IDCargo,
                    .MesPlanilla = i.MesPlanilla,
                    .AnioPlanilla = i.AnioPlanilla,
                    .Cargo = i.DescripcionLarga,
                    .FullName = String.Format("{0} {1} {2}", i.ApellidoPaterno, i.ApellidoMaterno, i.Nombre),
                    .ConceptoIngresos = i.Ingresos.GetValueOrDefault,
                    .ConceptoDeducciones = i.Deducciones_trabajador.GetValueOrDefault,
                    .ConceptoDescuentos = i.Descuentos_trabajador.GetValueOrDefault,
                    .ConceptoAportes = i.Aportaciones_empleador.GetValueOrDefault
                          })
            Next

            Return lista
        End Using
    End Function

    Public Function PlanillaGeneralSelxPersonalTipoConcepto(item As PlanillaGeneral) As List(Of PlanillaGeneral)
        Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Reading)
            Return scope.DBContext.PlanillaGeneral.Where(Function(o) o.IDPersonal = item.IDPersonal And o.TipoConcepto = item.TipoConcepto).ToList
        End Using
    End Function

    Public Function PlanillaGeneralSave(item As PlanillaGeneral, log As TransactionDataBE) As PlanillaGeneral
        Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Writing)
            If item.Action = BaseBE.EntityAction.INSERT Then
                Me.Insert(item)
            Else
                Me.Update(item)
            End If
            scope.SaveChanges()
        End Using
        Return item
    End Function
End Class
