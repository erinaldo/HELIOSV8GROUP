Public Class Modulo
    Property IDModulo As Int32
    Property Descripcion As String
    Property IDCategoria As Int32
    Property IDModuloPadre As Int32?
    Property IDSeguridad As Int32
    Property TipoModulo As ModuloTipo
    Property Formulario As String
    Property Transaccion As String
    Property Orden As Int16

    Public Enum ModuloTipo
        Nivel = 0
        Categoria = 1
    End Enum
   
End Class
