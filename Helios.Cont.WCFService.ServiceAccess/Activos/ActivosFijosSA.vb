Imports Helios.Cont.Business.Entity
Public Class ActivosFijosSA

    Public Function InsertActivoFijo(activosFijosBE As activosFijos) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.InsertActivoFijo(activosFijosBE)
    End Function

    Public Function GetListar_activosFijosEmpresa(be As activosFijos) As List(Of activosFijos)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListar_activosFijosEmpresa(be)
    End Function

#Region "Transporte"

    Public Function GetListar_activosFijos() As List(Of activosFijos)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListar_activosFijos()
    End Function

    Public Function GetListar_activosFijosSeriePlaca(be As activosFijos) As List(Of activosFijos)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListar_activosFijosSeriePlaca(be)
    End Function

    Public Function GetUbicar_activosFijosPorID(idActivo As Integer) As activosFijos
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicar_activosFijosPorID(idActivo)
    End Function

    Public Function ModificarActivo(activosFijosBE As activosFijos) As activosFijos
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ModificarActivo(activosFijosBE)
    End Function

    Public Sub ChangeEstatusActivo(obj As activosFijos)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.ChangeEstatusActivo(obj)
    End Sub

    Public Function GetListar_activosFijosConteoAsientos() As List(Of activosFijos)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListar_activosFijosConteoAsientos()
    End Function

#End Region

End Class
