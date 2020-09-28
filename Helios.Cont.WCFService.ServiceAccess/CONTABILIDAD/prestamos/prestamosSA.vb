Imports Helios.Cont.Business.Entity
Public Class prestamosSA

    Public Function ObtenerCuotasVencidas(ByVal idBeneficiario As Integer, tipo As String) As List(Of prestamos)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerCuotasVencidas(idBeneficiario, tipo)
    End Function

    Public Function ObtenerPrestamosPagoCobro(ByVal periodo As String, tipo As String) As List(Of prestamos)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerPrestamoPagoCobro(periodo, tipo)
    End Function


    Public Function ObtenerPrestamosRecibidoXperiodo(ByVal strIdEmpresa As String, intIdEstablecimiento As Integer, ByVal strPeriodo As String, strTipoPrestamo As String) As List(Of prestamos)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerPrestamosRecibidoXperiodo(strIdEmpresa, intIdEstablecimiento, strPeriodo, strTipoPrestamo)
    End Function

    Public Function ObtenerTodoCuotasVencidas(tipo As String) As List(Of prestamos)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerTodoCuotasVencidas(tipo)
    End Function

    Public Sub UpdateConfirmarPrestamo(iddocumento As Integer)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdateConfirmarPrestamo(iddocumento)
    End Sub

 

    Public Function RptPrestamosMayorMenor(ByVal inicio As Decimal, ByVal fin As Decimal) As List(Of prestamos)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.RptPrestamosMayorMenor(inicio, fin)
    End Function


    Public Function ObtenerDesembolsoApto(idempresa As String, tipo As String) As List(Of prestamos)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerDesembolsoApto(idempresa, tipo)
    End Function


    Public Function ObtenerPrestamosAprobadosBeneficiario(ByVal idBeneficiario As Integer, tipo As String, tipoProv As String) As List(Of prestamos)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerPrestamoAprobadoBeneficiario(idBeneficiario, tipo, tipoProv)
    End Function


    Public Function ObtenerPrestamosAprobadosDesembolsado(ByVal idBeneficiario As Integer, tipo As String, tipp As String) As List(Of prestamos)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerPrestamoAprobadoDesembolsado(idBeneficiario, tipo, tipp)
    End Function

    Public Function ObtenerPrestamosEmitidos(ByVal strIdEmpresa As String, ByVal strEstado As String, strTipoPrestamo As String) As List(Of prestamos)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerPrestamosEmitidos(strIdEmpresa, strEstado, strTipoPrestamo)
    End Function

    Public Function ObtenerPrestamosEmitidosXperiodo(ByVal strIdEmpresa As String, intIdEstablecimiento As Integer, ByVal strPeriodo As String, strTipoPrestamo As String) As List(Of prestamos)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerPrestamosEmitidosXperiodo(strIdEmpresa, intIdEstablecimiento, strPeriodo, strTipoPrestamo)
    End Function

    Public Function RptPrestamosOtorgados(ByVal idBeneficiario As Integer) As List(Of prestamos)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.RptPrestamosOtorgados(idBeneficiario)
    End Function

    Public Function UbicarPrestamoXcodigoDefault(intCodigo As Integer) As prestamos
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarPrestamoXcodigoDefault(intCodigo)
    End Function

    Public Function PrestamoEstadoAprobado(intCodigo As Integer) As Boolean
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.PrestamoEstadoAprobado(intCodigo)
    End Function

    Public Function UbicarPrestamoXcodigoSingle(intIdDocumento As Integer) As prestamos
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarPrestamoXcodigoSingle(intIdDocumento)
    End Function

    Public Function ObtenerPrestamosXperiodo(ByVal strIdEmpresa As String, intIdEstablecimiento As Integer, ByVal strPeriodo As String, strTipoPrestamo As String) As List(Of prestamos)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerPrestamosXperiodo(strIdEmpresa, intIdEstablecimiento, strPeriodo, strTipoPrestamo)
    End Function

    Public Function SavePrePrestamo(prestamosBE As prestamos) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SavePrePrestamo(prestamosBE)
    End Function

    Public Sub EditarPrePrestamo(prestamosBE As prestamos)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EditarPrePrestamo(prestamosBE)
    End Sub

    Public Sub EliminarPrePrestamo(prestamosBE As prestamos)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarPrePrestamo(prestamosBE)
    End Sub

    Public Sub EliminarPrestamoAprobado(prestamosBE As prestamos)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarPrestamoAprobado(prestamosBE)
    End Sub

    Public Function ObtenerPrestamos(ByVal strIdEmpresa As String, ByVal strEstado As String, strTipoPrestamo As String) As List(Of prestamos)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerPrestamos(strIdEmpresa, strEstado, strTipoPrestamo)
    End Function

    Public Function UbicarPrestamoXcodigo(intCodigo As Integer) As prestamos
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarPrestamoXcodigo(intCodigo)
    End Function
End Class
