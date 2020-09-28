Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Imports System.Data.Entity
Public Class componenteBL

    Inherits BaseBL

    Public Function getListaComponenteXTipo(componenteBE As componente) As List(Of componente)
        Dim lista As New List(Of componente)
        Dim obj As New componente

        Dim consulta = (From a In HeliosData.componente
                        Where a.idEmpresa = componenteBE.idEmpresa And a.idEstablecimiento = componenteBE.idEstablecimiento And
                            a.tipo = componenteBE.tipo And a.estado = componenteBE.estado).ToList

        For Each i In consulta
            obj = New componente
            obj.idComponente = i.idComponente
            obj.[idEmpresa] = i.[idEmpresa]
            obj.[idEstablecimiento] = i.[idEstablecimiento]
            obj.[idPadre] = i.[idPadre]
            obj.idItem = i.idItem
            obj.descripcionItem = i.descripcionItem
            obj.[estado] = i.[estado]
            obj.[tipo] = i.[tipo]
            obj.[usuarioActualizacion] = i.[usuarioActualizacion]
            obj.[fechaActualizacion] = i.[fechaActualizacion]
            obj.imagen = i.imagen
            obj.direccionImagen = i.direccionImagen
            HeliosData.componente.Add(obj)
            lista.Add(obj)
        Next

        Return lista
    End Function

    Public Function getListaComponente(componenteBE As componente) As List(Of componente)
        Dim lista As New List(Of componente)
        Dim obj As New componente

        'Dim consulta = (From a In HeliosData.componente
        '                Where a.idEmpresa = componenteBE.idEmpresa And a.idEstablecimiento = componenteBE.idEstablecimiento And
        '                    a.idPadre <> 0).ToList


        Dim consulta = (From com In HeliosData.componente
                        Where
                            com.estado = "A" And
                            com.tipo = "TD"
                        Group com By
                            com.idEmpresa,
                            com.idEstablecimiento,
                            com.idPadre,
                            com.idItem,
                            com.descripcionItem,
                            com.estado,
                           com.tipo
                            Into g = Group
                        Select
                            idEmpresa,
                            idEstablecimiento,
                            idPadre,
                            idItem,
                            descripcionItem,
                            estado,
                            tipo,
                            conteoComponente = (CType((Aggregate t1 In
                              (From c In HeliosData.componente
                               Where
                                   c.idPadre = idPadre
                               Select New With {
                                   c.idPadre
                                   }) Into Count()), Int64?))).ToList


        For Each i In consulta
            obj = New componente

            obj.[idEmpresa] = i.[idEmpresa]
            obj.[idEstablecimiento] = i.[idEstablecimiento]
            obj.[idPadre] = i.[idPadre]
            obj.idItem = i.idItem
            obj.descripcionItem = i.descripcionItem
            obj.[estado] = i.[estado]
            obj.[tipo] = i.[tipo]
            obj.[usuarioActualizacion] = i.conteoComponente
            HeliosData.componente.Add(obj)
            lista.Add(obj)
        Next

        Return lista
    End Function

    Public Function SaveComponenteFull(listaComponente As List(Of componente)) As Integer
        Dim obj As New componente()
        Try

            Using ts As New TransactionScope

                For Each i In listaComponente
                    obj = New componente
                    obj.[idComponente] = i.[idComponente]
                    obj.[idEmpresa] = i.[idEmpresa]
                    obj.[idEstablecimiento] = i.[idEstablecimiento]
                    obj.[idPadre] = i.[idPadre]
                    obj.[idItem] = i.[idItem]
                    obj.[descripcionItem] = i.[descripcionItem]
                    obj.[estado] = i.[estado]
                    obj.[tipo] = i.[tipo]
                    obj.[usuarioActualizacion] = i.[usuarioActualizacion]
                    obj.[fechaActualizacion] = i.[fechaActualizacion]
                    obj.imagen = i.imagen
                    obj.direccionImagen = i.direccionImagen
                    HeliosData.componente.Add(obj)
                    HeliosData.SaveChanges()
                Next
                ts.Complete()
                Return obj.idComponente
            End Using

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function SaveComponente(i As componente) As Integer
        Dim obj As New componente()
        Try

            Using ts As New TransactionScope
                obj = New componente
                obj.[idComponente] = i.[idComponente]
                obj.[idEmpresa] = i.[idEmpresa]
                obj.[idEstablecimiento] = i.[idEstablecimiento]
                obj.[idPadre] = i.[idPadre]
                obj.[idItem] = i.[idItem]
                obj.[descripcionItem] = i.[descripcionItem]
                obj.[estado] = i.[estado]
                obj.[tipo] = i.[tipo]
                obj.[usuarioActualizacion] = i.[usuarioActualizacion]
                obj.[fechaActualizacion] = i.[fechaActualizacion]
                HeliosData.componente.Add(obj)
                HeliosData.SaveChanges()
                ts.Complete()
                Return obj.idComponente
            End Using

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function getListaComponenteXIdPadre(componenteBE As componente) As List(Of componente)
        Dim lista As New List(Of componente)
        Dim obj As New componente

        Dim consulta = (From a In HeliosData.componente
                        Where a.idEmpresa = componenteBE.idEmpresa And a.idEstablecimiento = componenteBE.idEstablecimiento And
                            a.tipo = componenteBE.tipo And a.idPadre = componenteBE.idPadre And a.estado = componenteBE.estado).ToList

        For Each i In consulta
            obj = New componente
            obj.idComponente = i.idComponente
            obj.[idEmpresa] = i.[idEmpresa]
            obj.[idEstablecimiento] = i.[idEstablecimiento]
            obj.[idPadre] = i.[idPadre]
            obj.idItem = i.idItem
            obj.descripcionItem = i.descripcionItem
            obj.[estado] = i.[estado]
            obj.[tipo] = i.[tipo]
            obj.[usuarioActualizacion] = i.[usuarioActualizacion]
            obj.[fechaActualizacion] = i.[fechaActualizacion]
            obj.imagen = i.imagen
            obj.direccionImagen = i.direccionImagen
            HeliosData.componente.Add(obj)
            lista.Add(obj)
        Next

        Return lista
    End Function

    Public Sub EditarComponenteXDistribucion(ID As Integer, Estado As String)
        Try
            Using ts As New TransactionScope
                Dim obj = (From n In HeliosData.componente
                           Where n.idComponente = ID).FirstOrDefault

                obj.[estado] = Estado

                HeliosData.SaveChanges()
                ts.Complete()

            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    'nuevo componente

    Public Function SaveComponentePlantilla(i As componente) As List(Of componente)
        Dim obj As New componente()
        Dim listacomponente As New List(Of componente)
        Try

            Using ts As New TransactionScope

                obj = New componente
                obj.[idComponente] = i.[idComponente]
                obj.[idEmpresa] = i.[idEmpresa]
                obj.[idEstablecimiento] = i.[idEstablecimiento]
                obj.[idPadre] = i.[idPadre]
                obj.[idItem] = i.[idItem]
                obj.[descripcionItem] = i.[descripcionItem]
                obj.[estado] = i.[estado]
                obj.[tipo] = i.[tipo]
                obj.[usuarioActualizacion] = i.[usuarioActualizacion]
                obj.[fechaActualizacion] = i.[fechaActualizacion]
                HeliosData.componente.Add(obj)
                HeliosData.SaveChanges()
                Dim ID = obj.idComponente

                For Each item In i.listaComponentes
                    obj = New componente
                    obj.[idComponente] = i.[idComponente]
                    obj.[idEmpresa] = i.[idEmpresa]
                    obj.[idEstablecimiento] = i.[idEstablecimiento]
                    obj.[idPadre] = ID
                    obj.[idItem] = i.[idItem]
                    obj.[descripcionItem] = i.[descripcionItem]
                    obj.[estado] = item.[estado]
                    obj.[tipo] = i.[tipo]
                    obj.[usuarioActualizacion] = i.[usuarioActualizacion]
                    obj.[fechaActualizacion] = i.[fechaActualizacion]
                    HeliosData.componente.Add(obj)
                    HeliosData.SaveChanges()
                    obj.idComponente = obj.idComponente
                    obj.idActivo = i.idActivo
                    obj.IDInfraestructura = item.IDInfraestructura
                    obj.tipoServicio = item.tipoServicio
                    listacomponente.Add(obj)
                Next

                ts.Complete()

                Return listacomponente
            End Using

        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
