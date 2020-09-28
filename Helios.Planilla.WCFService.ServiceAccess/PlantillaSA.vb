Imports Helios.Planilla.Business.Entity
Imports Helios.Planilla.WCFService.MessageContract
Public Class PlantillaSA
    ''' <summary>
    ''' Graba información de la plantilla incluido sus detalles
    ''' </summary>
    ''' <param name="item">plantilla</param>
    ''' <remarks></remarks>
    Public Sub PlantillaSaveAll(ByVal item As Plantilla, log As TransactionDataBE)
        Dim miServicio = GetServiceProxy()
        Dim request As New PlantillaRequest
        request.Plantilla = item
        request.TransactionData = log
        request.Operacion = PlantillaOperation.PlantillaSaveAll
        Dim response = miServicio.SCO_Plantilla(request)

    End Sub
    ''' <summary>
    ''' Retorna información general de la plantilla
    ''' </summary>
    ''' <param name="item">plantilla.IDPlantilla</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function PlantillaSel(ByVal item As Plantilla) As Plantilla
        Dim miServicio = GetServiceProxy()
        Dim request As New PlantillaRequest
        request.Plantilla = item
        request.Operacion = PlantillaOperation.PlantillaSel
        Dim response = miServicio.SCO_Plantilla(request)
        Return response.Plantilla
    End Function

    Public Function PlantillaSelAll() As List(Of Plantilla)
        Dim miServicio = GetServiceProxy()
        Dim request As New PlantillaRequest
        request.Operacion = PlantillaOperation.PlantillaSelAll
        Dim response = miServicio.SCO_Plantilla(request)
        Return response.ListaPlantilla
    End Function
End Class
