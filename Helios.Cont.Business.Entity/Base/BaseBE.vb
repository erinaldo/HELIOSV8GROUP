
Public MustInherit Class BaseBE
    Inherits JNetFx.Framework.General.Domain.Entity
    'Public Structure TipoEntidad
    '    Const Proveedor = "PR"
    '    Const Cliente = "CL"
    'End Structure
    Enum EntityAction
        INSERT = 0
        UPDATE = 1
        DELETE = 2
    End Enum
    Public Property Action As EntityAction

    'Public Property Entidad As TipoEntidad
End Class
