Imports Helios.Cont.Business.Entity
Public Class datosGeneralesSA

    Public Sub updatePredeterminado(datoGeneralBE As datosGenerales)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.updatePredeterminado(datoGeneralBE)
    End Sub

    Public Function UbicaEmpresaFull(datosgerales As datosGenerales) As List(Of datosGenerales)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicaEmpresaFull(datosgerales)
    End Function

    Public Function UbicaEmpresaID(idDatoGeneral As String) As datosGenerales
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.UbicaEmpresaID(idDatoGeneral)
    End Function

    Public Function InsertEmpresa(datoGeneralBE As datosGenerales) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.InsertEmpresa(datoGeneralBE)
    End Function

    Public Function updateDatos(datoGeneralBE As datosGenerales) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.updateDatos(datoGeneralBE)
    End Function

    Public Sub EliminarImpresion(datoGeneralBE As datosGenerales)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarImpresion(datoGeneralBE)
    End Sub

End Class
