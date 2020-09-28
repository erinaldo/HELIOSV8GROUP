Imports Helios.Cont.Business.Entity
Public Class cajaUsuarioSA

    Public Function ListBoxClosedPendingUser(be As cajaUsuario) As Integer
        Dim myService = General.GetHeliosProxy()
        Return myService.ListBoxClosedPendingUser(be)
    End Function


    Public Function ListPendingForUserWithImport(be As cajaUsuario) As List(Of cajaUsuario)
        Dim myService = General.GetHeliosProxy()
        Return myService.ListPendingForUserWithImport(be)
    End Function

    Public Function ListBoxClosedPending(be As cajaUsuario) As List(Of cajaUsuario)
        Dim myService = General.GetHeliosProxy()
        Return myService.ListBoxClosedPending(be)
    End Function

    Public Function ListBoxClosedPendingCount(be As cajaUsuario) As Integer
        Dim myService = General.GetHeliosProxy()
        Return myService.ListBoxClosedPendingCount(be)
    End Function

    Public Function ListBoxOpen(be As cajaUsuario) As List(Of cajaUsuario)
        Dim myService = General.GetHeliosProxy()
        Return myService.ListBoxOpen(be)
    End Function


    Public Function CajaUsuarioPeriodoSinRecocimiento(be As cajaUsuario) As List(Of cajaUsuario)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.CajaUsuarioPeriodoSinRecocimiento(be)
    End Function

    Public Function CajaUsuarioSelPeriodo(be As cajaUsuario) As List(Of cajaUsuario)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.CajaUsuarioSelPeriodo(be)
    End Function

    Public Sub CerrarCajasActivas(be As List(Of cajaUsuario))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.CerrarCajasActivas(be)
    End Sub

    Public Sub CerrarCajasActivasPC(be As List(Of cajaUsuario))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.CerrarCajasActivasPC(be)
    End Sub
    Public Function UbicarCajeroIDUsuarioActiva(caja As cajaUsuario) As cajaUsuario
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarCajeroIDUsuarioActiva(caja)
    End Function

    Public Function UbicarCajeroIDUsuarioActivaPC(caja As cajaUsuario) As cajaUsuario
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarCajeroIDUsuarioActivaPC(caja)
    End Function
    Public Function ObtenerCajaUsuarioDia(be As cajaUsuario) As List(Of cajaUsuario)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerCajaUsuarioDia(be)
    End Function

    Public Function GetCajasActivasTotalXdia(be As documentoCaja) As cajaUsuario
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetCajasActivasTotalXdia(be)
    End Function

    Public Function ObtenerCajaUsuarioFull(empresa As String, idEstable As Integer) As List(Of cajaUsuario)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerCajaUsuarioFull(empresa, idEstable)
    End Function

    Public Function ObtenerCajaUsuarioFullEstado() As List(Of cajaUsuario)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerCajaUsuarioFullEstado()
    End Function

    Public Function ObtenerCajaUsuarioFullXpersona(strEmpresa As String, idEstablec As Integer, periodo As String, idPersonal As Integer) As List(Of cajaUsuario)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerCajaUsuarioFullXpersona(strEmpresa, idEstablec, periodo, idPersonal)
    End Function

    Public Function ResumenTransaccionesXusuarioCaja(be As cajaUsuario) As List(Of cajaUsuario)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ResumenTransaccionesXusuarioCaja(be)
    End Function

    Public Function ResumenTransaccionesXusuarioCajaPago(be As cajaUsuario) As List(Of cajaUsuario)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ResumenTransaccionesXusuarioCajaPago(be)
    End Function

    Public Function usp_ResumenTransaccionesXusuarioCajaXCierre(be As cajaUsuario) As List(Of cajaUsuario)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.usp_ResumenTransaccionesXusuarioCajaXCierre(be)
    End Function

    Public Sub EditarCajaUsuarioNuevo(objCajaUsuarioBE As cajaUsuario)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EditarCajaUsuarioNuevo(objCajaUsuarioBE)
    End Sub

    Public Function UbicarUsuarioAbierto(intIdCajaUsuario As Integer) As cajaUsuario
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ValidarUsuarioAbierto(intIdCajaUsuario)
    End Function

    Public Function UbicarCajaUsuarioPorID(intIdCajaUsuario As Integer) As cajaUsuario
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarCajaUsuarioPorID(intIdCajaUsuario)
    End Function

    Public Sub EliminarCajaUsuarioFull(ByVal cajaUsuarioBE As cajaUsuario)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarCajaUsuarioFull(cajaUsuarioBE)
    End Sub

    Public Function CerrarCajaUsuario(nCajaUsuario As cajaUsuario, nDocumento As documento) As cajaUsuario
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.CerrarCajaUsuario(nCajaUsuario, nDocumento)
    End Function

    Public Sub AperturarCajaUsuario(nCajaUsuario As cajaUsuario, nDocumento As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.AperturarCajaUsuario(nCajaUsuario, nDocumento)
    End Sub

    Public Function UbicarCajaUsuarioAbierto(intIdCajaUsuario As Integer, strEstado As String) As cajaUsuario
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarCajaUsuarioAbierto(intIdCajaUsuario, strEstado)
    End Function

    Public Sub HabilitarUsoDeCajaUser(ByVal cajaUsuarioBE As cajaUsuario)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.HabilitarUsoDeCajaUser(cajaUsuarioBE)
    End Sub

    Public Function UbicarCajaAsignadaUser(strNumDocUser As String, strEstadoCaja As String, InUso As String, strClave As String) As cajaUsuario
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarCajaAsignadaUser(strNumDocUser, strEstadoCaja, InUso, strClave)
    End Function

    Public Function InsertUsuarioCaja(cajaUsuarioBE As cajaUsuario) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.InsertUsuarioCaja(cajaUsuarioBE)
    End Function

    Public Sub EditarUsuarioCaja(cajaUsuarioBE As cajaUsuario)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EditarUsuarioCaja(cajaUsuarioBE)
    End Sub

    Public Sub EliminarUsuarioCaja(cajaUsuarioBE As cajaUsuario)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarUsuarioCaja(cajaUsuarioBE)
    End Sub

    Public Function ListarPorCaja(intIdCaja As Integer) As List(Of cajaUsuario)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListarPorCaja(intIdCaja)
    End Function

    Public Function ListarPorCajaPorPeriodo(intIdCaja As Integer, strPeriodo As String) As List(Of cajaUsuario)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListarPorCajaPorPeriodo(intIdCaja, strPeriodo)
    End Function

    Public Function UbicarCajasHijasXpadre(iNtIdPadre As Integer) As List(Of cajaUsuario)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarCajasHijasXpadre(iNtIdPadre)
    End Function

    Public Function UbicarCajasHijasFull(ListadoPadres As List(Of Integer)) As List(Of cajaUsuario)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarCajasHijasFull(ListadoPadres)
    End Function

    Public Sub CerrarAbrirCajaSubUsuario(nCajaUsuario As cajaUsuario)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.CerrarAbrirCajaSubUsuario(nCajaUsuario)
    End Sub

    Public Function ListaCajasHabilitadas(strIdEmpresa As String, intIdEstablecimiento As Integer) As List(Of cajaUsuario)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListaCajasHabilitadas(strIdEmpresa, intIdEstablecimiento)
    End Function


    Public Function UbicarCajaUsuarioXID(ByVal intIdCaja As Integer) As cajaUsuario
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarCajaUsuarioXID(intIdCaja)
    End Function

    Public Function ObtenerCajaUser(ByVal intIdCaja As Integer) As cajaUsuario
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerCajaUser(intIdCaja)
    End Function

    Public Function UbicarCajaXPersona(intPersona As Integer, intEstablecimiento As Integer, strEmpresa As String) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarCajaXPersona(intPersona, intEstablecimiento, strEmpresa)
    End Function

    Public Function UbicarCajaXIdEntidadOrigen(intEntidadFinanciera As Integer, intEstablecimiento As Integer, strEmpresa As String) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarCajaXIdEntidadOrigen(intEntidadFinanciera, intEstablecimiento, strEmpresa)
    End Function


    Public Function ValidarCajaXUsuario(intIdPersona As Integer) As cajaUsuario
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ValidarCajaXUsuario(intIdPersona)
    End Function

    Public Function ListadoCajaAsigConteo(strIdEmpresa As String, intIdEstablecimiento As Integer) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListadoCajaAsigConteo(strIdEmpresa, intIdEstablecimiento)
    End Function

    Public Function ListadoCajaFullConteo(strIdEmpresa As String, intIdEstablecimiento As Integer) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListadoCajaFullConteo(strIdEmpresa, intIdEstablecimiento)
    End Function

    Public Function VerificarCajaEstadoXUsuario(idPersona As String) As Boolean
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.VerificarCajaEstadoXUsuario(idPersona)
    End Function

    Public Function ListadoCajaXEstado(caja As cajaUsuario) As List(Of cajaUsuario)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListadoCajaXEstado(caja)
    End Function

    Public Function DocCajaXResumenXID(cajaBE As documentoCaja) As documentoCaja
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.DocCajaXResumenXID(cajaBE)
    End Function
End Class
