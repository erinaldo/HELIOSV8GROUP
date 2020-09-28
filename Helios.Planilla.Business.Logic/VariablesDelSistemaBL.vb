Imports Helios.Planilla.Business.Entity

Public Class VariablesDelSistemaBL

    Inherits BaseBL(Of VariablesDelSistema)

    Public Function VariablesDelSistemaSelxTipoConcepto(item As VariablesDelSistema) As List(Of VariablesDelSistema)
        Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Reading)
            Return scope.DBContext.VariablesDelSistema.Where(Function(o) o.TipoConcepto = item.TipoConcepto).ToList
        End Using
    End Function
End Class
