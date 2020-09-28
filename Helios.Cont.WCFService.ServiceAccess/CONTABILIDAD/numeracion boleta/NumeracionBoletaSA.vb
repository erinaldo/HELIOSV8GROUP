Imports Helios.Cont.Business.Entity
Public Class NumeracionBoletaSA

    Function GenerarNumeroXTipo(intIdEstablecimiento As Integer, strcodigoNumeracion As String, strTipo As String) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GenerarNumeroXTipo(intIdEstablecimiento, strcodigoNumeracion, strTipo)
    End Function

    Public Sub InsertarNumeracionInicio(lista As List(Of numeracionBoletas), listaCentroCostos As List(Of centrocosto))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.InsertarNumeracionInicio(lista, listaCentroCostos)
    End Sub

    Public Sub InsertarNumeracionXUnidOrg(lista As List(Of numeracionBoletas))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.InsertarNumeracionXUnidOrg(lista)
    End Sub

    Function ObtenerDocumentoPorEstablecimiento(intIdEstablecimiento As Integer, ByVal strSerie As String,
                                                strcodigoNumeracion As String, strTipo As String) As numeracionBoletas
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerDocumentoPorEstablecimiento(intIdEstablecimiento, strSerie, strcodigoNumeracion, strTipo)
    End Function

    Function ObtenerSeriesPorModulo(intIdEstablecimiento As Integer, strModulo As String) As List(Of numeracionBoletas)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerSeriesPorModulo(intIdEstablecimiento, strModulo)
    End Function

    Public Function ObtenerAncladosPorComprobante(strIdEmpresa As String, intIdEstablecimiento As Integer, strComprobante As String) As List(Of numeracionBoletas)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerAncladosPorComprobante(strIdEmpresa, intIdEstablecimiento, strComprobante)
    End Function

    'Public Function ObtenerNumeracionPredterminada(strIdEmpresa As String, intIdEstablecimiento As Integer, strComprobante As String, strTipoDoc As String) As numeracionBoletas
    '    Dim miServicio = General.GetHeliosProxy()
    '    Return miServicio.ObtenerNumeracionPredterminada(strIdEmpresa, intIdEstablecimiento, strComprobante, strTipoDoc)
    'End Function

    Public Function ObtenerNumeracionPredterminada(strIdEmpresa As String, intIdEstablecimiento As Integer, strTipoDoc As String) As numeracionBoletas
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerNumeracionPredterminada(strIdEmpresa, intIdEstablecimiento, strTipoDoc)
    End Function


    Public Function ObtenerNumeracionEES(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strSerie As String) As List(Of numeracionBoletas)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerNumeracionEES(strIdEmpresa, intIdEstablecimiento, strSerie)
    End Function

    Public Sub UpdatePredeterminadoAll(nNumeracionBE As numeracionBoletas)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdatePredeterminadoAll(nNumeracionBE)
    End Sub

    Public Function GetTieneConfiguracion(strIdEmpresa As String, ByVal intIdEstablecimiento As Integer, ByVal strSerie As String) As Boolean
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetTieneConfiguracion(strIdEmpresa, intIdEstablecimiento, strSerie)
    End Function

    Public Function InsertNumBoletas(ByVal numeracionBoletasBE As numeracionBoletas) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.InsertNumBoletas(numeracionBoletasBE)
    End Function

    Public Sub EditarNumBoletas(ByVal numeracionBoletasBE As numeracionBoletas)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EditarNumBoletas(numeracionBoletasBE)
    End Sub

    Public Sub EliminarNumBoletas(ByVal numeracionBoletasBE As numeracionBoletas)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarNumBoletas(numeracionBoletasBE)
    End Sub

    Public Function GetUbicar_numeracionBoletasPorID(IdEnumeracion As Integer) As numeracionBoletas
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_numeracionBoletasPorID(IdEnumeracion)
    End Function

    Public Function GetUbicar_numeracionBoletasXUnidadNegocio(numeracionBoletasBE As numeracionBoletas) As numeracionBoletas
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_numeracionBoletasXUnidadNegocio(numeracionBoletasBE)
    End Function

    Public Function NumeracionBoletasSelV2(intIdEstablecimiento As Integer,
                                         strcodigoNumeracion As String, strTipo As String, idCargo As Integer) As numeracionBoletas
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.NumeracionBoletasSelV2(intIdEstablecimiento, strcodigoNumeracion, strTipo, idCargo)
    End Function

    Function GetListar_numeracionBoletasAll(numeracionBoletasBE As numeracionBoletas) As List(Of numeracionBoletas)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListar_numeracionBoletasAll(numeracionBoletasBE)
    End Function

    Function GetListar_numeracionBoletasXCargo(numeracionBoletasBE As numeracionBoletas) As List(Of numeracionBoletas)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListar_numeracionBoletasXCargo(numeracionBoletasBE)
    End Function

End Class
