Partial Public Class detalleitem_equivalencias
    Inherits BaseBE
    Public Property IDGUI As String
    Public ReadOnly Property estado_bool As Boolean
        Get
            estado_bool = False
            If estado = "I" Then
                estado_bool = True
            ElseIf estado = "A" Then
                estado_bool = False
            End If
        End Get
    End Property


    Public Property Stock() As Decimal

    Public Property CostoTotal() As Decimal


End Class
