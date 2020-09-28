Imports Helios.Cont.Business.Entity
Public Class establecimientoSA

    Public Function ObtenerListaEstablecimientos(strIDEmpresa As String) As List(Of centrocosto)
        Dim miServicio = General.GetHeliosProxy()
        Dim miLista As List(Of centrocosto)
        miLista = miServicio.GetListaEstablecimientos(strIDEmpresa)
        Return miLista
    End Function

    Public Function UbicaEstablecimientoPorID(intIdEstable As Integer) As centrocosto
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetUbicaEstablecimientoID(intIdEstable)
    End Function

    Public Function InsertEstablecimiento(estableBE As centrocosto) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.InsertEstablecimiento(estableBE)
    End Function

#Region "Transporte"
    Public Sub ChangeEstatusAgencia(obj As centrocosto)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.ChangeEstatusAgencia(obj)
    End Sub
    Public Sub PredeterminarAgencia(obj As centrocosto)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.PredeterminarAgencia(obj)
    End Sub

    Public Function InsertEstablecimientoSingle(estableBE As centrocosto) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.InsertEstablecimientoSingle(estableBE)
    End Function

#End Region

End Class
