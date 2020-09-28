Public Class Vehiculo
    Inherits Helios.Cont.Business.Entity.activosFijos

#Region "Attributes"
    Public Property ListaMarca As List(Of Vehiculo_Marca)
    Public Property ListaModelo As List(Of Vehiculo_Modelo)
    Public Property ListaMotor As List(Of Vehiculo_Motor)
    Public Property ListaTransmision As List(Of Vehiculo_Transimision)
    Public Property ListaTipo As List(Of Vehiculo_Tipo)
    Public Property ListaSistemaCombustion As List(Of Vehiculo_SistemaCombustion)
    Public Property ListaCombustible As List(Of Vehiculo_Combustible)
    Public Property ListaDireccion As List(Of Vehiculo_Direccion)
#End Region

#Region "Constructors"
    Public Sub New()
        ListaMarca = GetMarcas()
        ListaModelo = GetModelos()
        ListaMotor = GetMotor()
        ListaTransmision = GetTransmision()
        ListaTipo = GetTipos()
        ListaSistemaCombustion = GetSistemaCombustion()
        ListaCombustible = GetCombustible()
        ListaDireccion = GetDireccion()
    End Sub
#End Region

#Region "Adicionales"
    Public Class Vehiculo_Transimision
        Property IDTransimision As String
        Property TransmisionName As String
    End Class

    Public Class Vehiculo_Tipo
        Property IDTipo As String
        Property TipoName As String
    End Class

    Public Class Vehiculo_Marca
        Property IDMarca As String
        Property MarcaName As String
    End Class

    Public Class Vehiculo_Modelo
        Property IDModelo As String
        Property ModeloName As String
    End Class

    Public Class Vehiculo_Motor
        Property IDMotor As String
        Property MotorName As String
    End Class

    Public Class Vehiculo_SistemaCombustion
        Property IDSistemaCMB As String
        Property SistemaName As String
    End Class

    Public Class Vehiculo_Combustible
        Property IDCombustible As String
        Property CombustibleName As String
    End Class

    Public Class Vehiculo_Direccion
        Property IDDir As String
        Property DirName As String
    End Class
#End Region

#Region "Methods"
    Private Function GetMarcas() As List(Of Vehiculo_Marca)
        GetMarcas = New List(Of Vehiculo_Marca) From
            {
            New Vehiculo_Marca With {.IDMarca = "1", .MarcaName = "No Disponible"},
            New Vehiculo_Marca With {.IDMarca = "2", .MarcaName = "MAZDA"},
            New Vehiculo_Marca With {.IDMarca = "3", .MarcaName = "HYUNDAI"}
            }
    End Function

    Private Function GetModelos() As List(Of Vehiculo_Modelo)
        GetModelos = New List(Of Vehiculo_Modelo) From
            {
            New Vehiculo_Modelo With {.IDModelo = "1", .ModeloName = "No Disponible"},
            New Vehiculo_Modelo With {.IDModelo = "2", .ModeloName = "4Runner"},
            New Vehiculo_Modelo With {.IDModelo = "3", .ModeloName = "Agya"},
            New Vehiculo_Modelo With {.IDModelo = "4", .ModeloName = "Avanza"}
            }
    End Function

    Private Function GetMotor() As List(Of Vehiculo_Motor)
        GetMotor = New List(Of Vehiculo_Motor) From
            {
            New Vehiculo_Motor With {.IDMotor = "1", .MotorName = "No Disponible"},
            New Vehiculo_Motor With {.IDMotor = "2", .MotorName = "1GR-FE"}
            }
    End Function

    Private Function GetTransmision() As List(Of Vehiculo_Transimision)
        GetTransmision = New List(Of Vehiculo_Transimision) From
            {
            New Vehiculo_Transimision With {.IDTransimision = "1", .TransmisionName = "No disponible"},
            New Vehiculo_Transimision With {.IDTransimision = "2", .TransmisionName = "Automática"},
            New Vehiculo_Transimision With {.IDTransimision = "3", .TransmisionName = "Sincrónica"},
            New Vehiculo_Transimision With {.IDTransimision = "4", .TransmisionName = "Otra"}
            }
    End Function

    Private Function GetTipos() As List(Of Vehiculo_Tipo)
        GetTipos = New List(Of Vehiculo_Tipo) From
            {
            New Vehiculo_Tipo With {.IDTipo = "9", .TipoName = "No Disponible"},
            New Vehiculo_Tipo With {.IDTipo = "1", .TipoName = "CABINA"},
            New Vehiculo_Tipo With {.IDTipo = "2", .TipoName = "CAVA"},
            New Vehiculo_Tipo With {.IDTipo = "3", .TipoName = "CHASIS"},
            New Vehiculo_Tipo With {.IDTipo = "4", .TipoName = "CHUTO"},
            New Vehiculo_Tipo With {.IDTipo = "5", .TipoName = "COUPE"},
            New Vehiculo_Tipo With {.IDTipo = "6", .TipoName = "ESTACA"},
            New Vehiculo_Tipo With {.IDTipo = "7", .TipoName = "FULGON"},
            New Vehiculo_Tipo With {.IDTipo = "8", .TipoName = "MINIBUS"},
            New Vehiculo_Tipo With {.IDTipo = "10", .TipoName = "OTRO"},
            New Vehiculo_Tipo With {.IDTipo = "11", .TipoName = "PANEL"},
            New Vehiculo_Tipo With {.IDTipo = "12", .TipoName = "PICK UP"},
            New Vehiculo_Tipo With {.IDTipo = "13", .TipoName = "RANCHERA"},
            New Vehiculo_Tipo With {.IDTipo = "14", .TipoName = "SEDAN"},
            New Vehiculo_Tipo With {.IDTipo = "15", .TipoName = "SW"},
            New Vehiculo_Tipo With {.IDTipo = "16", .TipoName = "TECHO DURO"},
            New Vehiculo_Tipo With {.IDTipo = "17", .TipoName = "VAN"},
            New Vehiculo_Tipo With {.IDTipo = "18", .TipoName = "MOTO"},
            New Vehiculo_Tipo With {.IDTipo = "19", .TipoName = "BICICLETA"},
            New Vehiculo_Tipo With {.IDTipo = "20", .TipoName = "LANCHA"},
            New Vehiculo_Tipo With {.IDTipo = "21", .TipoName = "MAQUINARIA PESADA"}
            }
    End Function

    Private Function GetSistemaCombustion() As List(Of Vehiculo_SistemaCombustion)
        GetSistemaCombustion = New List(Of Vehiculo_SistemaCombustion) From
            {
            New Vehiculo_SistemaCombustion With {.IDSistemaCMB = "1", .SistemaName = "No disponible"},
            New Vehiculo_SistemaCombustion With {.IDSistemaCMB = "2", .SistemaName = "Carburado"},
            New Vehiculo_SistemaCombustion With {.IDSistemaCMB = "3", .SistemaName = "Inyección"},
            New Vehiculo_SistemaCombustion With {.IDSistemaCMB = "4", .SistemaName = "Turbo carburado"},
            New Vehiculo_SistemaCombustion With {.IDSistemaCMB = "5", .SistemaName = "Turbo inyección"},
            New Vehiculo_SistemaCombustion With {.IDSistemaCMB = "6", .SistemaName = "Otro"}
            }
    End Function

    Private Function GetCombustible() As List(Of Vehiculo_Combustible)
        GetCombustible = New List(Of Vehiculo_Combustible) From
            {
            New Vehiculo_Combustible With {.IDCombustible = "1", .CombustibleName = "No disponible"},
            New Vehiculo_Combustible With {.IDCombustible = "2", .CombustibleName = "Diésel"},
            New Vehiculo_Combustible With {.IDCombustible = "3", .CombustibleName = "Gas"},
            New Vehiculo_Combustible With {.IDCombustible = "4", .CombustibleName = "Gasolina"},
            New Vehiculo_Combustible With {.IDCombustible = "5", .CombustibleName = "Otro"}
            }
    End Function

    Private Function GetDireccion() As List(Of Vehiculo_Direccion)
        GetDireccion = New List(Of Vehiculo_Direccion) From
            {
            New Vehiculo_Direccion With {.IDDir = "1", .DirName = "No disponible"},
            New Vehiculo_Direccion With {.IDDir = "2", .DirName = "Hidráulica"},
            New Vehiculo_Direccion With {.IDDir = "3", .DirName = "Mecánica"},
            New Vehiculo_Direccion With {.IDDir = "4", .DirName = "Otro"}
            }
    End Function
#End Region

End Class
