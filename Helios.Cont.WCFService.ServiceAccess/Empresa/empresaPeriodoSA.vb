Imports Helios.Cont.Business.Entity
Public Class empresaPeriodoSA

    Public Function GetUbicar_empresaPeriodoPorID(idempresa As String, periodo As String, idCentroCostos As Integer) As empresaPeriodo
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_empresaPeriodoPorID(idempresa, periodo, idCentroCostos)
    End Function

    Public Function GetListar_empresaPeriodo(empresaPeriodoBE As empresaPeriodo) As List(Of empresaPeriodo)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListar_empresaPeriodo(empresaPeriodoBE)
    End Function

    Public Function InsertarPeriodo(ByVal empresaPeriodoBE As empresaPeriodo) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.InsertarPeriodo(empresaPeriodoBE)
    End Function
End Class
