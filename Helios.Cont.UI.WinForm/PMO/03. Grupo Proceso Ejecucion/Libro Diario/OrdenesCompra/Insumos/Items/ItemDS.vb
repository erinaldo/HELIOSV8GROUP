Public Class ItemDS
    Inherits Material

    Public Property CodigoDetalle As Integer
    Private _DescripcionItem As String

    Public Property DescripcionItem() As String
        Get
            Return _DescripcionItem
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                Throw New Exception("Ingrese una descripción")
            Else
                If value.Trim.Length > 0 Then
                    _DescripcionItem = value
                Else
                    Throw New Exception("Ingrese una descripción")
                End If
            End If
        End Set
    End Property


    Sub New(descripcionItem As String, clas As String, presentac As String, unidad As String, tipoex As String, cuenta As String)
        Me.DescripcionItem = descripcionItem
        Me.Clasificacion = clas
        Me.Presentacion = presentac
        Me.UnidadMedida = unidad
        Me.TipoEx = tipoex
        Me.Cuenta = cuenta
    End Sub
End Class
