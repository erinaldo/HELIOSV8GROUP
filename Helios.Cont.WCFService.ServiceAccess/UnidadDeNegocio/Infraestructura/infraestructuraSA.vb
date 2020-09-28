Imports Helios.Cont.Business.Entity
Public Class infraestructuraSA

    Public Sub EliminarInfraestructuraXID(i As infraestructura)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarInfraestructuraXID(i)
    End Sub

    Public Function getListaInfraestructuraFull(infraestructuraBE As infraestructura) As List(Of infraestructura)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.getListaInfraestructuraFull(infraestructuraBE)
    End Function

    Public Function getListaInfraestructura(infraestructuraBE As infraestructura) As List(Of infraestructura)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.getListaInfraestructura(infraestructuraBE)
    End Function

    Public Function getListaInfraestructuraxIDPadre(infraestructuraBE As infraestructura) As List(Of infraestructura)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.getListaInfraestructuraxIDPadre(infraestructuraBE)
    End Function

    Public Sub EditarInfraestructuraEstado(i As infraestructura)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EditarInfraestructuraEstado(i)
    End Sub

    Public Sub EliminarInfraestructuraFull(i As infraestructura)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarInfraestructuraFull(i)
    End Sub

    Public Function getInfraestructuraEstructura(infraestructurabe As infraestructura) As List(Of infraestructura)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.getInfraestructuraEstructura(infraestructurabe)
    End Function

    Public Function getListaInfraestructuraFullPedido(infraestructuraBE As infraestructura) As List(Of infraestructura)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.getListaInfraestructuraFullPedido(infraestructuraBE)
    End Function

    Public Function Saveinfraestructura(i As infraestructura) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.Saveinfraestructura(i)
    End Function

    Public Function EditarNombreInfra(i As infraestructura) As infraestructura
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.EditarNombreInfra(i)
    End Function

    'TRANSPORTE

    Public Function SavePLantillaInfra(infraestructuraBE As List(Of infraestructura)) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SavePLantillaInfra(infraestructuraBE)
    End Function

    Public Function SaveActivoInfra(infraestructuraBE As List(Of infraestructura)) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.SaveActivoInfra(infraestructuraBE)
    End Function

    Public Function getCONTEOPlANTILLA(infraestructuraBE As infraestructura) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.getCONTEOPlANTILLA(infraestructuraBE)
    End Function

End Class
