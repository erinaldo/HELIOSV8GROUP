Imports Helios.Planilla.Business.Entity
Imports Helios.Planilla.Data.EF
Imports System.Data.Entity.Infrastructure
Imports System.Data.Entity

Public MustInherit Class BaseBL(Of T As BaseBE)
    Public Sub Insert(item As T)
        Try
            'Using scope As New UnitOfWorkScope(Of PlanillaEntities)(UnitOfWorkScope(Of PlanillaEntities).UnitOfWorkScopePurpose.Writing)
            Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Writing)
                'scope.DBContext.Set(Of T).Add(item)
                'scope.SaveChanges()
                scope.DBContext.Entry(item).State = System.Data.Entity.EntityState.Added
                scope.SaveChanges()
            End Using
        Catch dbex As System.Data.Entity.Validation.DbEntityValidationException
            Dim raise As Exception = dbex
            For Each validationErrors In dbex.EntityValidationErrors
                For Each validationError In validationErrors.ValidationErrors
                    Dim message = String.Format("{0}:{1}", validationErrors.Entry.Entity.ToString,
                                                validationError.ErrorMessage)
                    raise = New InvalidOperationException(message, raise)
                Next
            Next
            Throw raise
        End Try

    End Sub

    Public Sub Update(item As T)
        Try
            'Using scope As New UnitOfWorkScope(Of PlanillaEntities)(UnitOfWorkScope(Of PlanillaEntities).UnitOfWorkScopePurpose.Writing)
            Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Writing)
                'scope.DBContext.Set(Of T).ed()
                'scope.SaveChanges()
                scope.DBContext.Entry(item).State = System.Data.Entity.EntityState.Modified
                scope.SaveChanges()
            End Using
        Catch dbex As System.Data.Entity.Validation.DbEntityValidationException
            Dim raise As Exception = dbex
            For Each validationErrors In dbex.EntityValidationErrors
                For Each validationError In validationErrors.ValidationErrors
                    Dim message = String.Format("{0}:{1}", validationErrors.Entry.Entity.ToString,
                                                validationError.ErrorMessage)
                    raise = New InvalidOperationException(message, raise)
                Next
            Next
            Throw raise
        End Try
    End Sub

    Public Sub Delete(item As T)
        Try
            'Using scope As New UnitOfWorkScope(Of PlanillaEntities)(UnitOfWorkScope(Of PlanillaEntities).UnitOfWorkScopePurpose.Writing)
            Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Writing)
                scope.DBContext.Entry(item).State = System.Data.Entity.EntityState.Deleted
                scope.SaveChanges()
            End Using
        Catch dbex As System.Data.Entity.Validation.DbEntityValidationException
            Dim raise As Exception = dbex
            For Each validationErrors In dbex.EntityValidationErrors
                For Each validationError In validationErrors.ValidationErrors
                    Dim message = String.Format("{0}:{1}", validationErrors.Entry.Entity.ToString,
                                                validationError.ErrorMessage)
                    raise = New InvalidOperationException(message, raise)
                Next
            Next
            Throw raise
        End Try
    End Sub

    Public Function Sel(item As T) As T
        Try
            'Using scope As New UnitOfWorkScope(Of PlanillaEntities)(UnitOfWorkScope(Of PlanillaEntities).UnitOfWorkScopePurpose.Reading)
            Using scope As New PlanillaUnitOfWorkScope(PlanillaUnitOfWorkScope.UnitOfWorkScopePurpose.Reading)
                'Return scope.DBContext.Entry(item).Entity
                Return scope.DBContext.Set(Of T).Find(Me.GetKeys(item, scope.DBContext))
            End Using
        Catch dbex As System.Data.Entity.Validation.DbEntityValidationException
            Dim raise As Exception = dbex
            For Each validationErrors In dbex.EntityValidationErrors
                For Each validationError In validationErrors.ValidationErrors
                    Dim message = String.Format("{0}:{1}", validationErrors.Entry.Entity.ToString,
                                                validationError.ErrorMessage)
                    raise = New InvalidOperationException(message, raise)
                Next
            Next
            Throw raise
        End Try
    End Function


    Private Function GetKeys(entidad As T, context As DbContext) As Object()

        Dim objectSet = CType(context, IObjectContextAdapter).ObjectContext.CreateObjectSet(Of T)()
        Dim KeyNames = objectSet.EntitySet.ElementType.KeyMembers.Select(Function(o) o.Name).ToArray

        Dim type As Type = GetType(T)

        Dim Keys(KeyNames.Length - 1) As Object
        For i = 0 To KeyNames.Length - 1
            Keys(i) = type.GetProperty(KeyNames(i)).GetValue(entidad, Nothing)
        Next
        Return Keys
    End Function

End Class
