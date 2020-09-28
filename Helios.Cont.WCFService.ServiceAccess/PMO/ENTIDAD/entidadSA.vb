Imports Helios.Cont.Business.Entity
Public Class entidadSA

#Region "DEPURADO"
    Public Function GetListarEntidad(EntidadBE As entidad) As List(Of entidad)
        Dim miServicio = General.GetHeliosProxy()
        Dim miLista As List(Of entidad)
        miLista = miServicio.GetListarEntidad(EntidadBE)
        Return miLista
    End Function

#End Region

    Public Sub CambiarStatusEntidad(ByVal entidadBE As entidad)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.CambiarStatusEntidad(entidadBE)
    End Sub

    Public Function UbicarEntidadPorIdentidad(strEmpresa As String, strTipoEntidad As String, identidad As Integer) As entidad
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarEntidadPorId(strEmpresa, strTipoEntidad, identidad)
    End Function

    Public Function UbicarClientePoID(ByVal strNroPersona As String) As entidad
        Dim miServicio = General.GetHeliosProxy()
        Dim miLista As entidad
        miLista = miServicio.UbicarClientePoID(strNroPersona)
        Return miLista
    End Function

    Public Function UbicarClienteXID(ByVal entidadBE As entidad) As entidad
        Dim miServicio = General.GetHeliosProxy()
        Dim miLista As entidad
        miLista = miServicio.UbicarClienteXID(entidadBE)
        Return miLista
    End Function

    Public Sub InsertGrupoEntidad(list As List(Of entidad))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.InsertGrupoEntidad(list)
    End Sub

    Public Function BuscarEntidadXdescripcion(strEmpresa As String, strTipoEntidad As String, strBusqueda As String) As List(Of entidad)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.BuscarEntidadXdescripcion(strEmpresa, strTipoEntidad, strBusqueda)
    End Function

    Public Function UbicarEntidadPorRucNro(strEmpresa As String, strTipoEntidad As String, strNroDoc As String) As entidad
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarEntidadPorRucNro(strEmpresa, strTipoEntidad, strNroDoc)
    End Function

    Public Function UbicarEntidadVarios(ByVal strtipo As String, ByVal strEmpresa As String, ByVal strBusqueda As String, idEstablecimiento As Integer) As entidad
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarEntidadVarios(strtipo, strEmpresa, strBusqueda, idEstablecimiento)
    End Function

    Public Function GrabarEntidad(ByVal nEntidad As entidad) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveEntidad(nEntidad)
    End Function

    Public Sub UpdateEntidad(ByVal nEntidad As entidad)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdateEntidad(nEntidad)
    End Sub

    Public Sub DeleteEntidad(ByVal nEntidad As entidad)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.DeleteEntidad(nEntidad)
    End Sub



    Public Function UbicarEntidadPorID(intIdEntidad As Integer) As List(Of entidad)
        Dim miServicio = General.GetHeliosProxy()
        Dim miLista As List(Of entidad)
        miLista = miServicio.GetUbicarEntidadPorID(intIdEntidad)
        Return miLista
    End Function

    Public Function ListarEntidadesPorNombres(strtipo As String, strEmpresa As String, strBusqueda As String) As List(Of entidad)
        Dim miServicio = General.GetHeliosProxy()
        Dim miLista As List(Of entidad)
        miLista = miServicio.ListarEntidadesPorNombres(strtipo, strEmpresa, strBusqueda)
        Return miLista
    End Function

    Public Function ListarEntidadesPorRuc(strtipo As String, strEmpresa As String, strBusqueda As String) As List(Of entidad)
        Dim miServicio = General.GetHeliosProxy()
        Dim miLista As List(Of entidad)
        miLista = miServicio.ListarEntidadesPorRuc(strtipo, strEmpresa, strBusqueda)
        Return miLista
    End Function

    Public Function GetEntidadesGenerales(tipo As String, strIdEmpresa As String) As List(Of entidad)
        Dim miServicio = General.GetHeliosProxy()
        Dim miLista As List(Of entidad)
        miLista = miServicio.GetEntidadesGenerales(tipo, strIdEmpresa)
        Return miLista
    End Function

    Public Function GetUbicarEntPorID(strEmpresa As String, intIdEntidad As Integer) As entidad
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicarEntPorID(strEmpresa, intIdEntidad)
    End Function

#Region "REstaurant"

    Public Function GetUbicarClienteOrHuesped(entBE As entidad) As entidad
        Dim miServicio = General.GetHeliosProxy()
        Dim miLista As entidad
        miLista = miServicio.GetUbicarClienteOrHuesped(entBE)
        Return miLista
    End Function

    Public Function UbicarEntidadPorRucNroxIdDistribucion(strEmpresa As String, strTipoEntidad As String, strNroDoc As String) As List(Of entidad)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarEntidadPorRucNroxIdDistribucion(strEmpresa, strTipoEntidad, strNroDoc)
    End Function

#End Region

End Class
