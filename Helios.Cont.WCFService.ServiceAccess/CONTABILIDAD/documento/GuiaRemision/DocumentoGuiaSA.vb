Imports Helios.Cont.Business.Entity
Public Class DocumentoGuiaSA

    Public Function GetVentaIDGuia(be As documento) As documentoGuia
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetVentaIDGuia(be)
    End Function

    Public Function GetREcuperarImpresion(be As documento) As documentoGuia
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetREcuperarImpresion(be)
    End Function

    Public Sub UpdateGuiaXEstado(iddoc As Integer, estado As String)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdateGuiaXEstado(iddoc, estado)
    End Sub

    Public Sub EliminatGuia(be As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminatGuia(be)
    End Sub

    Public Function GetGuiaRemisionListSelDate(be As documentoGuia) As List(Of documentoGuia)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetGuiaRemisionListSelDate(be)
    End Function
    Public Function ListaGuiasTransferenciasXEntidadV2(be As documentocompra, tipoPerson As String) As List(Of documentoGuia)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListaGuiasTransferenciasXEntidadV2(be, tipoPerson)
    End Function

    Public Function ListaGuiasTransferenciasXEntidad(be As documentocompra) As List(Of documentoGuia)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListaGuiasTransferenciasXEntidad(be)
    End Function

    Public Function UbicarGuiaPorIdDocumento(intIdDocumento As Integer) As documentoGuia
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarGuiaPorIdDocumento(intIdDocumento)
    End Function

    Public Function ListaGuiasPorCompra(intIdDocumentoCompra As Integer) As List(Of documentoGuia)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListaGuiasPorCompra(intIdDocumentoCompra)
    End Function

    Public Function ListaGuiasPorCompraConEntidad(intIdDocumentoCompra As Integer) As List(Of documentoGuia)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListaGuiasPorCompraConEntidad(intIdDocumentoCompra)
    End Function

    Public Function ListaGuiasPorCompraSinEntidad(intIdDocumentoCompra As Integer) As List(Of documentoGuia)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListaGuiasPorCompraSinEntidad(intIdDocumentoCompra)
    End Function



    Public Function SaveGuiaRemisionEntregado(objDocumento As documento) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveGuiaRemisionEntregado(objDocumento)
    End Function

    Public Function UbicarGuiaPendiente() As List(Of documentoGuia)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicarGuiaPendiente()
    End Function

    Public Sub updateDocumentoTransferencia(objdocumento As documentoGuia)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.updateDocumentoTransferencia(objdocumento)
    End Sub

    Public Function ListaGuiasPorCompraSinNumeracion(intIdEstablecimiento As Integer, srtPeriodo As String, strIdEmpresarial As String) As List(Of documentoGuia)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ListaGuiasPorCompraSinNumeracion(intIdEstablecimiento, srtPeriodo, strIdEmpresarial)
    End Function

    Public Sub RecepcionInventario(doc As documento)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.RecepcionInventario(doc)
    End Sub

#Region "GUIAFABIO"

    Public Function RegistrarGuiaRemision(BE As documento) As documento
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.RegistrarGuiaRemision(BE)
    End Function


    Public Function SAVEGUIA(DOCUMENTOGUIA As documentoGuia) As documentoGuia
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SAVEGUIA(DOCUMENTOGUIA)

    End Function
#End Region
End Class
