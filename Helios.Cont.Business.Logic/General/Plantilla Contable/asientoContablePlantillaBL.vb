
Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class asientoContablePlantillaBL
    Inherits BaseBL


    Public Function GetPantillasGeneral(tipoOper As String) As List(Of asientoContablePlantilla)
        Dim lista As List(Of asientoContablePlantilla)
        Dim listaRes As New List(Of asientoContablePlantilla)

        lista = HeliosData.asientoContablePlantilla.Where(Function(o) o.tipoOperacion = tipoOper).ToList


        AutoMapper.Mapper.CreateMap(Of asientoContablePlantilla, asientoContablePlantilla)()
        listaRes = AutoMapper.Mapper.Map(Of List(Of asientoContablePlantilla))(lista)
        Return listaRes
    End Function

End Class
