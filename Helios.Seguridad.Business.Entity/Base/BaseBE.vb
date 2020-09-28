
Public MustInherit Class BaseBE
    Inherits JNetFx.Framework.General.Domain.Entity

    Enum EntityAction
        INSERT = 0
        UPDATE = 1
        DELETE = 2
    End Enum
    Public Property Action As EntityAction
End Class
