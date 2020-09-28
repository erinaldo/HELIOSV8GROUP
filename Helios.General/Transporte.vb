Imports Helios.Cont.Business.Entity

Public Module Transporte

    Public Property ListaEmpresas As List(Of entidad)
    Public Property ListaPersonas As List(Of Persona)
    Public Property ListaAgencias As List(Of centrocosto)
    Public Property ListaModulosNumeracion As List(Of moduloConfiguracion)


    Public Enum ProgramacionEstado
        VentaEnMostrador = 1
        VentaCerrada = 2
        ZonaEmbarque = 3
        VehiculoAsignadoEnCurso = 4
        VehiculoAsignadoRutaCulminada = 5
    End Enum

    Public Enum Tipotareo
        Pasajeros
        Encommiendas
        Giros
        Tripulantes
        Otros
    End Enum

    Public Enum TipotareoGeneral
        SalidaDeAgencia
        LlegadaAdestino
    End Enum

    Public Structure EntidadConsolidacion
        Const Pasajeros = "P"
        Const Equipajes = "E"
        Const Encomiendas = "C"
    End Structure

    Public Enum EntidadConsolidacionStatus
        Pendiente
        Entregado
        Otros
    End Enum

    Public Enum EncomiendaEstado
        PendienteDeEntrega
        Entregado
        Vencido
        Abandonado
        Otros
        Anulado
    End Enum

    Public Enum EncomiendasConsulta
        PorMes
        PorDia
    End Enum


End Module
