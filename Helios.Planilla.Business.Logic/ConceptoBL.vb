Imports Helios.Planilla.Business.Entity

Public Class ConceptoBL
    Inherits BaseBL(Of Concepto)

    Public Function ConceptoSelxTipoConcepto(item As Concepto) As List(Of Concepto)
        Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Reading)
            Return scope.DBContext.Concepto.OrderBy(Function(o) o.Orden).Where(Function(o) o.TipoConcepto = item.TipoConcepto).ToList
        End Using
    End Function

    Public Function ConceptoSelxCargo(item As Concepto) As List(Of Concepto)
        Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Reading)
            Return scope.DBContext.Concepto.OrderBy(Function(o) o.Orden).Where(Function(o) o.TipoConcepto = item.TipoConcepto And o.TipoPlanilla = item.TipoPlanilla).ToList
        End Using
    End Function

    Public Function ConceptoSelxActivo(item As Concepto) As List(Of Concepto)
        Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Reading)
            Return scope.DBContext.Concepto.OrderBy(Function(o) o.Orden).Where(Function(o) o.Activo = item.Activo).ToList
        End Using
    End Function

    Public Function ConceptoSelxID(item As Concepto) As Concepto
        Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Reading)
            Return scope.DBContext.Concepto.OrderBy(Function(o) o.Orden).Where(Function(o) o.IDConcepto = item.IDConcepto).FirstOrDefault
        End Using
    End Function

    Public Function ConceptoSave(item As Concepto, log As TransactionDataBE) As Concepto

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

