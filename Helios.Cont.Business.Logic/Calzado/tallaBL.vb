Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Imports System.Data.Entity

Public Class tallaBL
    Inherits BaseBL


    Public Function GetPlantillaTallaSelcategory(be As talla) As List(Of talla)
        Dim con = HeliosData.talla.Include(Function(o) o.talla_equivalencias).Where(Function(o) o.idcategoria = be.idcategoria).ToList()
        Return GetTallas(con)
    End Function

    Public Function GetPlantillaTallas() As List(Of talla)
        Dim con = HeliosData.talla.Include(Function(o) o.talla_equivalencias).ToList()
        Return GetTallas(con)
    End Function

    Public Function GetTallas(list As List(Of talla)) As List(Of talla)
        GetTallas = New List(Of talla)
        For Each i In list
            GetTallas.Add(New talla() With
                          {
                          .idtalla = i.idtalla,
                          .idcategoria = i.idcategoria,
                          .genero = i.genero,
                          .estado = i.estado,
                          .talla_equivalencias = GetTallaEquivalencias(i.talla_equivalencias.ToList())
                          })
        Next
    End Function

    Private Function GetTallaEquivalencias(list As List(Of talla_equivalencias)) As List(Of talla_equivalencias)
        GetTallaEquivalencias = New List(Of talla_equivalencias)
        For Each i In list
            GetTallaEquivalencias.Add(New talla_equivalencias With
                                      {
                                      .id_equivalencia = i.id_equivalencia,
                                      .idtalla = i.idtalla,
                                      .usa = i.usa,
                                      .uk = i.uk,
                                      .eur = i.eur,
                                      .cm = i.cm,
                                      .ot = i.ot
                                      })
        Next
    End Function
End Class
