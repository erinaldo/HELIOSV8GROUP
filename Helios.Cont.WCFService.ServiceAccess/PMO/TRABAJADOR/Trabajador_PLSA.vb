Imports Helios.Cont.Business.Entity
Public Class Trabajador_PLSA

    Public Sub GrabarTrabajador(ByVal nTrab As Trabajador_PL)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.SaveTrabajador(nTrab)
    End Sub

    Public Sub UpdateTrabajador(ByVal nTrab As Trabajador_PL)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.UpdateTrabajador(nTrab)
    End Sub

    Public Sub DeleteTrabajador(ByVal nTrab As Trabajador_PL)
        Dim miServicio = General.GetHeliosProxy()
        miServicio.EliminarTrabajador(nTrab)
    End Sub

    Public Function ObtenerListaTrabEmpresa(strIdEmpresa As String) As List(Of Trabajador_PL)
        Dim miServicio = General.GetHeliosProxy()
        Dim miLista As List(Of Trabajador_PL)
        miLista = miServicio.GetListaTrabPorEmpresa(strIdEmpresa)
        Return miLista
    End Function

    Public Function ObtenerListaTrabEstable(intIdEstable As Integer) As List(Of Trabajador_PL)
        Dim miServicio = General.GetHeliosProxy()
        Dim miLista As List(Of Trabajador_PL)
        miLista = miServicio.GetListaTrabPorEstable(intIdEstable)
        Return miLista
    End Function

    Public Function UbicarTrabDNI(strCodTrab As String, intIdEstable As Integer) As Trabajador_PL
        Dim miServicio = General.GetHeliosProxy()
        Dim miLista As Trabajador_PL
        miLista = miServicio.GetUbicaTrab(strCodTrab, intIdEstable)
        Return miLista
    End Function

    Public Function ObtenerTrabPorDNIExcel(strCodTrab As String, intIdEstable As Integer) As Integer
        Dim miServicio = General.GetHeliosProxy()
        Return miServicio.ObtenerTrabPorDNIExcel(strCodTrab, intIdEstable)
    End Function
   
End Class
