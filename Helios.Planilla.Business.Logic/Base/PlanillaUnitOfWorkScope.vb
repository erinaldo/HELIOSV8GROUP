
Imports Helios.Planilla.Data.EF
Imports JNetFx.Framework.Data

Public Class PlanillaUnitOfWorkScope
    Inherits UnitOfWorkScope(Of PlanillaEntities)

    Public Sub New(purpose As UnitOfWorkScopePurpose)
        MyBase.New(purpose)
    End Sub

End Class
