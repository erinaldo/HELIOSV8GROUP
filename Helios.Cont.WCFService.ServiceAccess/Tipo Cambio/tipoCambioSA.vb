Imports Helios.Cont.Business.Entity
Public Class tipoCambioSA

    Public Function GeTipoCambioXfecha(idEmpresa As String, fecha As Date, intIdEstablecimiento As Integer) As tipoCambio
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GeTipoCambioXfecha(idEmpresa, fecha, intIdEstablecimiento)
    End Function

    Public Sub DeleteTC(tipoCambioBE As tipoCambio)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.DeleteTC(tipoCambioBE)
    End Sub

    Public Function ObtenerTipoCambioXfecha(idempresa As String, fecha As Date, intIdEstablecimiento As Integer) As tipoCambio
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerTipoCambioXfecha(idempresa, fecha, intIdEstablecimiento)
    End Function

    Public Function CambiarTipoCambio(ByVal tipoCambioBE As tipoCambio) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.CambiarTipoCambio(tipoCambioBE)
    End Function

    Public Function GetListaTipoCambioMaxFecha(idEmpresa As String, intIdEstablecimiento As Integer) As tipoCambio
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaTipoCambioMaxFecha(idEmpresa, intIdEstablecimiento)
    End Function

    Public Function InsertTC(ByVal tipoCambioBE As tipoCambio) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.InsertTC(tipoCambioBE)
    End Function

    Public Sub EditartTC(ByVal tipoCambioBE As tipoCambio)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EditarTC(tipoCambioBE)
    End Sub

    Public Function GetListar_tipoCambio() As List(Of tipoCambio)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListar_tipoCambio()
    End Function

    Public Function GetListar_tipoCambioByPeriodo(idempresa As String, mes As Integer, anio As Integer, intIdEstablecimiento As Integer)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListar_tipoCambioByPeriodo(idempresa, mes, anio, intIdEstablecimiento)
    End Function
End Class
