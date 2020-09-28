Imports Helios.Cont.Business.Entity
Public Class totalesLiquidacionSA
    Public Function GetUbicaLiquidacionID(nLiquidacion As totalesLiquidacion) As totalesLiquidacion
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicaLiquidacionID(nLiquidacion)
    End Function

    Public Function GetListaLiquidacionPreliminar(intIdProyecto As Integer, strTipoPlan As String) As List(Of totalesLiquidacion)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaLiquidacionPreliminar(intIdProyecto, strTipoPlan)
    End Function

    Public Sub GetEliminarLiquidacion(nLiquidacion As totalesLiquidacion)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GetEliminarLiquidacion(nLiquidacion)
    End Sub
End Class
