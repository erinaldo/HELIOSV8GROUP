Imports Helios.Planilla.Business.Entity

Public Class TablaDetalleBL
    Inherits BaseBL(Of TablaDetalle)

    Public Function TablaDetalleSelxTabla(item As TablaDetalle) As List(Of TablaDetalle)
        Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Reading)
            Return scope.DBContext.TablaDetalle.OrderBy(Function(o) o.DescripcionCorta).Where(Function(o) o.IDTabla = item.IDTabla).ToList
        End Using
    End Function

    Public Function TablaDetalleDepartamentos() As List(Of TablaDetalle)
        Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Reading)
            Return scope.DBContext.TablaDetalle.OrderBy(Function(o) o.DescripcionCorta).Where(Function(o) o.IDTabla = 14 And o.DescripcionLarga.StartsWith("DEPARTAMENTO")).ToList
        End Using
    End Function

    Public Function TablaDetalleProvincia(item As TablaDetalle) As List(Of TablaDetalle)
        Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Reading)
            Return scope.DBContext.TablaDetalle.OrderBy(Function(o) o.DescripcionCorta).Where(Function(o) o.IDTabla = 14 And CLng(CStr(o.IDTablaDetalle).Length) <= 4 And CStr(o.IDTablaDetalle).StartsWith(item.IDTablaDetalle)).ToList
        End Using
    End Function

    Public Function TablaDetalleDistrito(item As TablaDetalle) As List(Of TablaDetalle)
        Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Reading)
            Return scope.DBContext.TablaDetalle.OrderBy(Function(o) o.DescripcionCorta).Where(Function(o) o.IDTabla = 14 And CLng(CStr(o.IDTablaDetalle).Length) <= 6 And
                                                                                                  CLng(CStr(o.IDTablaDetalle).Length) > 5 And CStr(o.IDTablaDetalle).StartsWith(item.IDTablaDetalle)).ToList
        End Using
    End Function

End Class
