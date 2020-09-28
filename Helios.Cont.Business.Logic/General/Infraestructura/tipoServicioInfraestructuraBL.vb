Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Imports System.Data.Entity
Public Class tipoServicioInfraestructuraBL
    Inherits BaseBL

    Public Function GetUbicartipoServicioInfraestructura(tipoServicioInfraestructuraBE As tipoServicioInfraestructura) As List(Of tipoServicioInfraestructura)
        Dim lista As New List(Of tipoServicioInfraestructura)
        Dim obj As New tipoServicioInfraestructura

        Dim consulta = (From tip In HeliosData.tipoServicioInfraestructura
                        Group Join cat In HeliosData.categoriaInfraestructura On CInt(tip.idCategoria) Equals cat.idCategoria Into cat_join = Group
                        From cat In cat_join.DefaultIfEmpty()
                        Select
                            tip.idTipoServicio,
                            tip.idEmpresa,
                            tip.idEstablecimiento,
                            IdCategoria = CType(tip.idCategoria, Int32?),
                            tip.descripcionTipoServicio,
                            tip.estadoTipoServicio,
                            tip.usuarioActualizacion,
                            tip.fechaActualizacion,
                            DescripcionInfraestructura = cat.descripcionInfraestructura).ToList


        For Each i In consulta
            obj = New tipoServicioInfraestructura

            obj.[idTipoServicio] = i.[idTipoServicio]
            obj.[idEmpresa] = i.[idEmpresa]
            obj.[idEstablecimiento] = i.[idEstablecimiento]
            obj.[idCategoria] = i.[IdCategoria]
            obj.[descripcionTipoServicio] = i.[descripcionTipoServicio]
            obj.[estadoTipoServicio] = i.[estadoTipoServicio]
            obj.[usuarioActualizacion] = i.[usuarioActualizacion]
            obj.[fechaActualizacion] = i.[fechaActualizacion]
            obj.nombreCategoria = i.DescripcionInfraestructura

            lista.Add(obj)
        Next

        Return lista
    End Function



    Public Function GetUbicartipoServicioInfraSinClasificacion(tipoServicioInfraestructuraBE As tipoServicioInfraestructura) As List(Of tipoServicioInfraestructura)
        Dim lista As New List(Of tipoServicioInfraestructura)
        Dim obj As New tipoServicioInfraestructura

        Dim consulta = (From cat In HeliosData.tipoServicioInfraestructura
                        Where
                            cat.idEmpresa = tipoServicioInfraestructuraBE.idEmpresa And
                            cat.idCategoria.Equals(Nothing)).ToList

        For Each i In consulta
            obj = New tipoServicioInfraestructura

            obj.[idTipoServicio] = i.[idTipoServicio]
            obj.[idEmpresa] = i.[idEmpresa]
            obj.[idEstablecimiento] = i.[idEstablecimiento]
            obj.[idCategoria] = i.[idCategoria]
            obj.[descripcionTipoServicio] = i.[descripcionTipoServicio]
            obj.[estadoTipoServicio] = i.[estadoTipoServicio]
            obj.[usuarioActualizacion] = i.[usuarioActualizacion]
            obj.[fechaActualizacion] = i.[fechaActualizacion]

            lista.Add(obj)
        Next

        Return lista
    End Function

    Public Function GetUbicartipoServicioInfra(tipoServicioInfraestructuraBE As tipoServicioInfraestructura) As List(Of tipoServicioInfraestructura)
        Dim lista As New List(Of tipoServicioInfraestructura)
        Dim obj As New tipoServicioInfraestructura

        Dim consulta = (From cat In HeliosData.tipoServicioInfraestructura
                        Where
                            cat.idEmpresa = tipoServicioInfraestructuraBE.idEmpresa).ToList

        For Each i In consulta
            obj = New tipoServicioInfraestructura

            obj.[idTipoServicio] = i.[idTipoServicio]
            obj.[idEmpresa] = i.[idEmpresa]
            obj.[idEstablecimiento] = i.[idEstablecimiento]
            obj.[idCategoria] = i.[idCategoria]
            obj.[descripcionTipoServicio] = i.[descripcionTipoServicio]
            obj.[estadoTipoServicio] = i.[estadoTipoServicio]
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



    Public Function GetUbicartipoServicioInfraestructuraXID(tipoServicioInfraestructuraBE As tipoServicioInfraestructura) As tipoServicioInfraestructura
        Dim lista As New List(Of tipoServicioInfraestructura)
        Dim obj As New tipoServicioInfraestructura

        Dim consulta = (From a In HeliosData.tipoServicioInfraestructura
                        Where a.idEmpresa = tipoServicioInfraestructuraBE.idEmpresa And a.idTipoServicio = tipoServicioInfraestructuraBE.idTipoServicio).FirstOrDefault


        obj = New tipoServicioInfraestructura

        obj.[idTipoServicio] = consulta.[idTipoServicio]
        obj.[idEmpresa] = consulta.[idEmpresa]
        obj.[idEstablecimiento] = consulta.[idEstablecimiento]
        obj.[idCategoria] = consulta.[idCategoria]
        obj.[descripcionTipoServicio] = consulta.[descripcionTipoServicio]
        obj.[estadoTipoServicio] = consulta.[estadoTipoServicio]
        obj.[usuarioActualizacion] = consulta.[usuarioActualizacion]
        obj.[fechaActualizacion] = consulta.[fechaActualizacion]

        Return obj
    End Function

    '///////////////////////////////////////////////////////////////////////////////////////////////////////////////
    Public Function SaveTipoServicioInfraestructura(objCategoria As tipoServicioInfraestructura) As Integer
        Dim obj As New tipoServicioInfraestructura()
        Try

            Using ts As New TransactionScope

                Dim consulta = (From a In HeliosData.tipoServicioInfraestructura
                                Where a.idEmpresa = objCategoria.idEmpresa And a.descripcionTipoServicio = objCategoria.descripcionTipoServicio).FirstOrDefault

                If (IsNothing(consulta)) Then
                    obj = New tipoServicioInfraestructura()

                    obj.[idTipoServicio] = objCategoria.[idTipoServicio]
                    obj.[idEmpresa] = objCategoria.[idEmpresa]
                    obj.[idEstablecimiento] = objCategoria.[idEstablecimiento]
                    obj.[idCategoria] = objCategoria.[idCategoria]
                    obj.[descripcionTipoServicio] = objCategoria.[descripcionTipoServicio]
                    obj.[estadoTipoServicio] = objCategoria.[estadoTipoServicio]
                    obj.[usuarioActualizacion] = objCategoria.[usuarioActualizacion]
                    obj.[fechaActualizacion] = objCategoria.[fechaActualizacion]

                    HeliosData.tipoServicioInfraestructura.Add(obj)
                    HeliosData.SaveChanges()
                    ts.Complete()
                Else
                    Throw New Exception("YA EXISTE UN SERVICIO CON EL MISMA DESCRIPCIÓN")
                End If

                Return obj.[idTipoServicio]
            End Using

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub EditarTipoServicioInfraestructuraXCategoria(i As tipoServicioInfraestructura, tipo As String)
        Try
            Using ts As New TransactionScope

                If (tipo = "ESTADO") Then
                    Dim obj = (From n In HeliosData.tipoServicioInfraestructura
                               Where n.idTipoServicio = i.idTipoServicio And n.idEmpresa = i.idEmpresa).FirstOrDefault


                    obj.estadoTipoServicio = i.estadoTipoServicio
                ElseIf (tipo = "DESCRIPCION") Then
                    Dim obj = (From n In HeliosData.tipoServicioInfraestructura
                               Where n.idTipoServicio = i.idTipoServicio And n.idEmpresa = i.idEmpresa).FirstOrDefault

                    obj.descripcionTipoServicio = i.descripcionTipoServicio
                End If

                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

End Class
