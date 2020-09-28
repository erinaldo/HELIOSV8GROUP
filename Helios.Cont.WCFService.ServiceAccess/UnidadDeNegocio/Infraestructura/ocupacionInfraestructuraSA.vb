Imports Helios.Cont.Business.Entity
Public Class ocupacionInfraestructuraSA
    Public Function listaAlertaCheckOn(objOcupacion As ocupacionInfraestructura) As List(Of ocupacionInfraestructura)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.listaAlertaCheckOn(objOcupacion)
    End Function

    Sub EditarOcupacionInfra(i As ocupacionInfraestructura)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EditarOcupacionInfra(i)
    End Sub

    Public Function listaOcupacionInfraestructura(objOcupacion As ocupacionInfraestructura) As List(Of ocupacionInfraestructura)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.listaOcupacionInfraestructura(objOcupacion)
    End Function

    Public Function OcupacionInfra(objOcupacion As ocupacionInfraestructura) As ocupacionInfraestructura
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.OcupacionInfra(objOcupacion)
    End Function

    Public Function GetListaOcupacionInfra(objOcupacion As ocupacionInfraestructura) As List(Of ocupacionInfraestructura)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetListaOcupacionInfra(objOcupacion)
    End Function

End Class
