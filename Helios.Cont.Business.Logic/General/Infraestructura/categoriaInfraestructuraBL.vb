Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Imports System.Data.Entity
Public Class categoriaInfraestructuraBL
    Inherits BaseBL

    Public Function GetUbicarCategoriaInfraestructura(categoriaInfraestructuraBE As categoriaInfraestructura) As List(Of categoriaInfraestructura)
        Dim lista As New List(Of categoriaInfraestructura)
        Dim obj As New categoriaInfraestructura

        Dim consulta = (From a In HeliosData.categoriaInfraestructura
                        Where a.idEmpresa = categoriaInfraestructuraBE.idEmpresa).ToList

        For Each i In consulta
            obj = New categoriaInfraestructura
            obj.[idCategoria] = i.[idCategoria]
            obj.[idEmpresa] = i.[idEmpresa]
            obj.[idEstablecimiento] = i.[idEstablecimiento]
            obj.[descripcionInfraestructura] = i.[descripcionInfraestructura]
            obj.[estado] = i.[estado]
            obj.[usuarioActualizacion] = i.[usuarioActualizacion]
            obj.[fechaActualizacion] = i.[fechaActualizacion]
            lista.Add(obj)
        Next

        Return lista
    End Function

    Public Function GetUbicarCategoriaAndListaSubCategoria(categoriaInfraestructuraBE As categoriaInfraestructura) As List(Of categoriaInfraestructura)
        Dim lista As New List(Of categoriaInfraestructura)
        Dim listaSubClasificacion As New List(Of tipoServicioInfraestructura)
        Dim obj As New categoriaInfraestructura

        Dim consulta = (From a In HeliosData.categoriaInfraestructura.Include("tipoServicioInfraestructura").Where _
                            (Function(d) d.idEmpresa = categoriaInfraestructuraBE.idEmpresa).ToList).ToList

        For Each prec In consulta

            For Each SubCat In prec.tipoServicioInfraestructura
                listaSubClasificacion.Add(New tipoServicioInfraestructura With
                                                                    {
                                                                    .idTipoServicio = SubCat.idTipoServicio,
                                                                    .descripcionTipoServicio = SubCat.descripcionTipoServicio,
                                                                    .idCategoria = SubCat.idCategoria
                                                                    })
            Next

            obj = New categoriaInfraestructura
            obj.tipoServicioInfraestructura = (listaSubClasificacion)
            obj.[idCategoria] = prec.[idCategoria]
            obj.[idEmpresa] = prec.[idEmpresa]
            obj.[idEstablecimiento] = prec.[idEstablecimiento]
            obj.[descripcionInfraestructura] = prec.[descripcionInfraestructura]
            obj.[estado] = prec.[estado]
            obj.[usuarioActualizacion] = prec.[usuarioActualizacion]
            obj.[fechaActualizacion] = prec.[fechaActualizacion]
            lista.Add(obj)
        Next

        Return lista
    End Function

    Public Function SaveCategoriaInfraestructura(objCategoria As categoriaInfraestructura) As Integer
        Dim obj As New categoriaInfraestructura()
        Try

            Using ts As New TransactionScope
                obj = New categoriaInfraestructura()

                obj.[idCategoria] = objCategoria.[idCategoria]
                obj.[idEmpresa] = objCategoria.[idEmpresa]
                obj.[idEstablecimiento] = objCategoria.[idEstablecimiento]
                obj.[descripcionInfraestructura] = objCategoria.[descripcionInfraestructura]
                obj.[estado] = objCategoria.[estado]
                obj.[usuarioActualizacion] = objCategoria.[usuarioActualizacion]
                obj.[fechaActualizacion] = objCategoria.[fechaActualizacion]

                HeliosData.categoriaInfraestructura.Add(obj)
                HeliosData.SaveChanges()
                ts.Complete()
                Return obj.[idCategoria]
            End Using

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetUbicarCategoriaInfraestructuraXID(categoriaInfraestructuraBE As categoriaInfraestructura) As categoriaInfraestructura
        Dim lista As New List(Of categoriaInfraestructura)
        Dim obj As New categoriaInfraestructura

        Dim consulta = (From a In HeliosData.categoriaInfraestructura
                        Where a.idEmpresa = categoriaInfraestructuraBE.idEmpresa And a.idCategoria = categoriaInfraestructuraBE.idCategoria).FirstOrDefault


        obj = New categoriaInfraestructura
        obj.[idCategoria] = consulta.[idCategoria]
        obj.[idEmpresa] = consulta.[idEmpresa]
        obj.[idEstablecimiento] = consulta.[idEstablecimiento]
        obj.[descripcionInfraestructura] = consulta.[descripcionInfraestructura]
        obj.[estado] = consulta.[estado]
        obj.[usuarioActualizacion] = consulta.[usuarioActualizacion]
        obj.[fechaActualizacion] = consulta.[fechaActualizacion]

        Return obj
    End Function


End Class
