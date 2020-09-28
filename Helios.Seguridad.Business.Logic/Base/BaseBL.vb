Imports Helios.Seguridad.Data.EF

Public MustInherit Class BaseBL
    Protected _DbContext As SeguridadEntities
    Public ReadOnly Property SeguridadData As SeguridadEntities
        Get
            If _DbContext Is Nothing Then
                _DbContext = New SeguridadEntities
            End If
            Return _DbContext
        End Get
    End Property
End Class
