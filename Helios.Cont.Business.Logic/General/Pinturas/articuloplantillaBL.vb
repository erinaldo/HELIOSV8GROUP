Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class articuloplantillaBL
    Inherits BaseBL

    Public Sub InsertPlantillaArticulo(be As articuloplantilla)
        Using ts As New TransactionScope
            HeliosData.articuloplantilla.Add(be)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub EditarPlantillaArticulo(be As articuloplantilla)

        Dim obj = HeliosData.articuloplantilla.Where(Function(o) o.secuencia = be.secuencia).FirstOrDefault

        If Not IsNothing(obj) Then
            Using ts As New TransactionScope
                obj.descripcion = be.descripcion
                obj.cant = be.cant
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        End If

    End Sub

    Public Sub EliminarPlantillaArticulo(be As articuloplantilla)

        Dim obj = HeliosData.articuloplantilla.Where(Function(o) o.secuencia = be.secuencia).FirstOrDefault

        If Not IsNothing(obj) Then
            CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(obj)
            HeliosData.SaveChanges()
        End If

    End Sub


    Public Function GetPlantillaByArticulo(be As detalleitems) As List(Of articuloplantilla)
        Dim obj As New articuloplantilla
        Dim Lista As New List(Of articuloplantilla)

        Dim con = (From n In HeliosData.articuloplantilla _
                  Where n.idarticulo = be.codigodetalle And n.idpadre <> 0).ToList


        For Each i In con
            obj = New articuloplantilla With
                  {
                      .idarticulo = i.idarticulo,
                      .secuencia = i.secuencia,
                      .idpadre = i.idpadre,
                      .descripcion = i.descripcion,
                      .cant = i.cant,
                      .otros = i.otros
                      }
            
            Lista.Add(obj)
        Next
        Return Lista
    End Function

    Public Function GetPlantillaByIdPadre(be As articuloplantilla) As List(Of articuloplantilla)
        Dim obj As New articuloplantilla
        Dim Lista As New List(Of articuloplantilla)

        Dim con = (From n In HeliosData.articuloplantilla _
                  Where n.idpadre = be.idpadre).ToList


        For Each i In con
            obj = New articuloplantilla With
                  {
                      .idarticulo = i.idarticulo,
                      .secuencia = i.secuencia,
                      .idpadre = i.idpadre,
                      .descripcion = i.descripcion,
                      .cant = i.cant,
                      .otros = i.otros
                      }

            Lista.Add(obj)
        Next
        Return Lista
    End Function

    Public Function GetPlantillaPadre(be As detalleitems) As List(Of articuloplantilla)
        Dim obj As New articuloplantilla
        Dim Lista As New List(Of articuloplantilla)

        Dim con = (From n In HeliosData.articuloplantilla _
                  Where n.idarticulo = be.codigodetalle And n.idpadre = 0).ToList


        For Each i In con
            obj = New articuloplantilla With
                  {
                      .idarticulo = i.idarticulo,
                      .secuencia = i.secuencia,
                      .idpadre = i.idpadre,
                      .descripcion = i.descripcion
                      }

            Lista.Add(obj)
        Next
        Return Lista
    End Function

End Class
