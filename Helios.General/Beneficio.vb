Public Module Beneficio

    Public Enum TipoTabla
        regalo = 0
        Bonificacion = 1
        DescuentoRebaja = 2
        Promocion = 3
        ValesDeConsumo = 4
        valesDeDescuento = 5
    End Enum


    Public Enum TipoBeneficio
        Documento = 1
        Item = 2
        LineaDeProducto = 3
    End Enum

    Public Enum StatusBeneficio
        Inactivo
        Activo
    End Enum
End Module
