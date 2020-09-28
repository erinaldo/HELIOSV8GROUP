Imports Helios.Cont.Business.Entity

Public Class caracteristicaItemSA

    Public Function InsertCabezera(be As caracteristicaItem) As caracteristicaItem
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.InsertCabezera(be)
    End Function


    Public Function listaCamposModelo(be As caracteristicaItem) As List(Of caracteristicaItem)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.listaCamposModelo(be)
    End Function

    Public Function listaModelos(be As caracteristicaItem) As List(Of caracteristicaItem)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.listaModelos(be)
    End Function

    Public Sub GuardarcaracteristicaItem(be As List(Of caracteristicaItem))
        Dim miServicio = General.GetHeliosProxy()
        miServicio.GuardarcaracteristicaItem(be)
    End Sub

End Class
