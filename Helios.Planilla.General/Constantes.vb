Public Module Constantes
    Public Enum StatusCargo
        Activo = 1
        Inactivo = 0
    End Enum

    Public Enum Tabla_SituacionTrabajador
        BAJA = 0
        ACTIVO_SUBSIDIADO = 1
        SIN_VINC_LAB_POR_LIQUIDAR = 2
        SUSPENSIÓN_PERFECTA_DE_LABORES = 3
    End Enum

    Public Structure PlanillaConceptos
        Const Ingresos = "100"
        Const IngresosAsignaciones = "200"
        Const IngresosBonificaciones = "300"
        Const IngresosGratificaciones = "400"
        Const IngresosIndemnizaciones = "500"
        Const DeduccionesTrabajador = "600"
        Const DescuentosTrabajador = "700"
        Const AportacionesEmpleador = "800"
        Const Conceptosvarios = "900"
        Const OtrosConceptos = "1000"
    End Structure

End Module
