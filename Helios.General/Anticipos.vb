Public Module Anticipo

    Public Structure Tipo
        Const Recibido = "AR"
        Const otorgado = "AO"
    End Structure

    Public Enum Estado
        Emitido
        NotaCredito
        NotaCreditoParcial
        DevolucionDeDinero
        Compensado
        Rechazado
    End Enum

    Public Structure TipoOperacion
        Const PagoAnticipado = "01"
        Const Garantia = "02"
    End Structure

    Public Structure EstadoCobroNotaCredito
        Const Pendiente = "PN"
        Const Parcial = "PR"
        Const Completado = "CT"
        Const SolicitudDevolucion = "SOD"
        Const DevolucionTramitePendiente = "DVPN"
        Const DevolucionTramiteParcial = "DVPR"
        Const DevolucionTramiteCompleto = "DVCP"
    End Structure


End Module
