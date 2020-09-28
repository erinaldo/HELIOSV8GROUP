Imports Helios.Cont.Business.Entity
Public Class movimientocajaextranjeraSA
    Public Function GetMovimientosDetalleByDepodito(be As movimientocajaextranjera) As List(Of movimientocajaextranjera)
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.GetMovimientosDetalleByDepodito(be)
    End Function
End Class