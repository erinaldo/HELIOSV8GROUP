Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Imports System.Data.Entity
Public Class infraestructuraBL
    Inherits BaseBL

    Public Sub EliminarInfraestructuraXID(i As infraestructura)
        Try
            Dim consulta As infraestructura = HeliosData.infraestructura.Where(Function(o) o.idInfraestructura = i.idInfraestructura).FirstOrDefault
            Using ts As New TransactionScope
                If Not IsNothing(consulta) Then
                    CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(consulta)

                    Dim consultaSector As infraestructura = HeliosData.infraestructura.Where(Function(o) o.idPadre = i.idInfraestructura).FirstOrDefault

                    If Not IsNothing(consultaSector) Then
                        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(consultaSector)

                        Dim consultaPiso As infraestructura = HeliosData.infraestructura.Where(Function(o) o.idPadre = consultaSector.idInfraestructura).FirstOrDefault

                        If Not IsNothing(consultaPiso) Then
                            CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(consultaPiso)

                        End If
                    End If

                End If
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function getListaInfraestructuraFull(infraestructuraBE As infraestructura) As List(Of infraestructura)
        Dim lista As New List(Of infraestructura)
        Dim obj As New infraestructura

        Dim consulta = (From tipo In HeliosData.infraestructura
                        Where
                           tipo.estado = "A" And
                            tipo.idEmpresa = infraestructuraBE.idEmpresa And
                            tipo.idEstablecimiento = infraestructuraBE.idEstablecimiento
                        Select
                            tipo.nombre,
                            tipo.numero,
                            tipo.idInfraestructura,
                            tipo.estado,
                            tipo.tipo,
                            tipo.idPadre).ToList

        If (Not IsNothing(consulta)) Then
            If (consulta.Count > 0) Then
                For Each i In consulta
                    obj = New infraestructura
                    obj.[idInfraestructura] = i.[idInfraestructura]
                    obj.[nombre] = i.[nombre]
                    obj.[estado] = i.[estado]
                    obj.tipo = i.tipo
                    obj.numero = i.numero
                    obj.idPadre = i.idPadre
                    HeliosData.infraestructura.Add(obj)
                    lista.Add(obj)
                Next
            End If
        End If

        Return lista
    End Function

    Public Function getListaInfraestructura(infraestructuraBE As infraestructura) As List(Of infraestructura)
        Dim lista As New List(Of infraestructura)
        Dim obj As New infraestructura

        Dim consulta = (From a In HeliosData.infraestructura
                        Where a.idEmpresa = infraestructuraBE.idEmpresa And a.idEstablecimiento = infraestructuraBE.idEstablecimiento And
                            a.tipo = infraestructuraBE.tipo).ToList

        For Each i In consulta
            obj = New infraestructura
            obj.[idInfraestructura] = i.[idInfraestructura]
            obj.[idEmpresa] = i.[idEmpresa]
            obj.[idEstablecimiento] = i.[idEstablecimiento]
            obj.[idPadre] = i.[idPadre]
            obj.[nombre] = i.[nombre]
            obj.[cantidad] = i.[cantidad]
            obj.numero = i.numero
            obj.[estado] = i.[estado]
            obj.[tipo] = i.[tipo]
            obj.estructura = i.estructura
            obj.[usuarioActualizacion] = i.[usuarioActualizacion]
            obj.[fechaActualizacion] = i.[fechaActualizacion]
            HeliosData.infraestructura.Add(obj)
            lista.Add(obj)
        Next

        Return lista
    End Function

    Public Function getListaInfraestructuraxIDPadre(infraestructuraBE As infraestructura) As List(Of infraestructura)
        Dim lista As New List(Of infraestructura)
        Dim obj As New infraestructura

        Dim consulta = (From a In HeliosData.infraestructura
                        Where a.idEmpresa = infraestructuraBE.idEmpresa And a.idEstablecimiento = infraestructuraBE.idEstablecimiento And
                           infraestructuraBE.ListaTipo.Contains(a.tipo) And a.idPadre = infraestructuraBE.idPadre).ToList

        For Each i In consulta
            obj = New infraestructura
            obj.[idInfraestructura] = i.[idInfraestructura]
            obj.[idEmpresa] = i.[idEmpresa]
            obj.[idEstablecimiento] = i.[idEstablecimiento]
            obj.[idPadre] = i.[idPadre]
            obj.[nombre] = i.[nombre]
            obj.[cantidad] = i.[cantidad]
            obj.[estado] = i.[estado]
            obj.[tipo] = i.[tipo]
            obj.estructura = i.estructura
            obj.numero = i.numero
            obj.[usuarioActualizacion] = i.[usuarioActualizacion]
            obj.[fechaActualizacion] = i.[fechaActualizacion]
            HeliosData.infraestructura.Add(obj)
            lista.Add(obj)
        Next

        Return lista
    End Function

    Public Sub EditarInfraestructuraEstado(i As infraestructura)
        Try
            Using ts As New TransactionScope
                Dim obj = (From n In HeliosData.infraestructura
                           Where n.idInfraestructura = i.idInfraestructura And n.idEmpresa = i.idEmpresa And n.idEstablecimiento = i.idEstablecimiento).FirstOrDefault

                obj.[estado] = i.[estado]

                HeliosData.SaveChanges()
                ts.Complete()

            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub EliminarInfraestructuraFull(i As infraestructura)
        Try
            Using ts As New TransactionScope
                Dim obj = (From n In HeliosData.infraestructura
                           Where n.idEmpresa = i.idEmpresa And n.idEstablecimiento = i.idEstablecimiento).ToList

                For Each item In obj
                    item.[estado] = i.[estado]
                    HeliosData.SaveChanges()
                Next

                ts.Complete()

            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function getInfraestructuraEstructura(infraestructurabe As infraestructura) As List(Of infraestructura)
        Dim ListaInfraestructura As New List(Of infraestructura)
        Dim obj As New infraestructura

        Dim consulta = (From a In HeliosData.infraestructura
                        Group Join b In HeliosData.infraestructura On CInt(a.idPadre) Equals b.idInfraestructura Into b_join = Group
                        From b In b_join.DefaultIfEmpty()
                        Join c In HeliosData.infraestructura On CInt(b.idPadre) Equals c.idInfraestructura
                        Where
                            a.estado = "A" And
                            b.estado = "A" And c.estado = "A" _
                            And a.idEmpresa = infraestructurabe.idEmpresa _
                            And a.idEstablecimiento = infraestructurabe.idEstablecimiento
                        Select
                                   a.idInfraestructura,
                                   piso = a.nombre,
                                   sector = b.nombre,
                                   bloque = c.nombre,
                                   estado = a.estado).ToList


        If (Not IsNothing(consulta)) Then
            For Each item In consulta
                obj = New infraestructura
                obj.Bloque = item.bloque
                obj.Sector = item.sector
                obj.Piso = item.piso
                obj.estado = item.estado
                obj.idInfraestructura = item.idInfraestructura

                ListaInfraestructura.Add(obj)
            Next

        End If
        Return ListaInfraestructura
    End Function

    Public Function getListaInfraestructuraFullPedido(infraestructuraBE As infraestructura) As List(Of infraestructura)
        Dim lista As New List(Of infraestructura)
        Dim obj As New infraestructura

        Dim consulta = (From a In HeliosData.infraestructura
                        Where a.idEmpresa = infraestructuraBE.idEmpresa And a.idEstablecimiento = infraestructuraBE.idEstablecimiento).ToList

        For Each i In consulta
            obj = New infraestructura
            obj.[idInfraestructura] = i.[idInfraestructura]
            obj.[idEmpresa] = i.[idEmpresa]
            obj.[idEstablecimiento] = i.[idEstablecimiento]
            obj.[idPadre] = i.[idPadre]
            obj.[nombre] = i.[nombre]
            obj.[cantidad] = i.[cantidad]
            obj.numero = i.numero
            obj.[estado] = i.[estado]
            obj.[tipo] = i.[tipo]
            obj.estructura = i.estructura
            obj.[usuarioActualizacion] = i.[usuarioActualizacion]
            obj.[fechaActualizacion] = i.[fechaActualizacion]
            HeliosData.infraestructura.Add(obj)
            lista.Add(obj)
        Next

        Return lista
    End Function

    Public Function Saveinfraestructura(i As infraestructura) As Integer
        Dim obj As New infraestructura()
        Try

            Using ts As New TransactionScope
                obj = New infraestructura()
                obj.[idEmpresa] = i.[idEmpresa]
                obj.[idEstablecimiento] = i.[idEstablecimiento]
                obj.[idPadre] = i.[idPadre]
                obj.[nombre] = i.[nombre]
                obj.[cantidad] = i.[cantidad]
                obj.[estado] = i.[estado]
                obj.[tipo] = i.[tipo]
                obj.numero = i.numero
                obj.estructura = i.estructura
                obj.[usuarioActualizacion] = i.[usuarioActualizacion]
                obj.[fechaActualizacion] = i.[fechaActualizacion]
                HeliosData.infraestructura.Add(obj)
                HeliosData.SaveChanges()
                ts.Complete()
                Return obj.idInfraestructura
            End Using

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function EditarNombreInfra(i As infraestructura) As infraestructura
        Try
            Using ts As New TransactionScope
                Dim obj = (From n In HeliosData.infraestructura
                           Where n.idInfraestructura = i.idInfraestructura And n.idEmpresa = i.idEmpresa And n.idEstablecimiento = i.idEstablecimiento).FirstOrDefault

                obj.nombre = i.nombre

                HeliosData.SaveChanges()
                ts.Complete()
                Return obj
            End Using

        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function SavePLantillaInfra(listaInfraestructura As List(Of infraestructura)) As Integer
        Dim obj As New infraestructura()
        Dim componenteBL As New componenteBL
        Dim listaComponente As New List(Of componente)
        Dim distribucionBL As New distribucionInfraestructuraBL
        Try

            Using ts As New TransactionScope

                For Each i In listaInfraestructura
                    obj = New infraestructura()
                    obj.[idEmpresa] = i.[idEmpresa]
                    obj.[idEstablecimiento] = i.[idEstablecimiento]
                    obj.[idPadre] = i.[idPadre]
                    obj.[nombre] = i.[nombre]
                    obj.[cantidad] = i.[cantidad]
                    obj.[estado] = i.[estado]
                    obj.[tipo] = i.[tipo]
                    obj.numero = i.numero
                    obj.estructura = i.estructura
                    obj.[usuarioActualizacion] = i.[usuarioActualizacion]
                    obj.[fechaActualizacion] = i.[fechaActualizacion]
                    HeliosData.infraestructura.Add(obj)
                    HeliosData.SaveChanges()
                    Dim idnfraestructura = obj.idInfraestructura

                    listaComponente = componenteBL.SaveComponentePlantilla(i.componenteBE)

                    distribucionBL.SaveDistribucionInfraestructuraFull(idnfraestructura, listaComponente)

                Next

                ts.Complete()

            End Using

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function SaveActivoInfra(listaInfraestructura As List(Of infraestructura)) As Integer
        Dim obj As New infraestructura()
        Dim componenteBL As New componenteBL
        Dim listaComponente As New List(Of componente)
        Dim distribucionBL As New distribucionInfraestructuraBL
        Try

            Using ts As New TransactionScope

                For Each i In listaInfraestructura

                    listaComponente = componenteBL.SaveComponentePlantilla(i.componenteBE)

                    distribucionBL.SaveDistribucionInfraestructuraXActivo(listaComponente)

                Next

                ts.Complete()

            End Using

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function getCONTEOPlANTILLA(infraestructuraBE As infraestructura) As Integer
        Dim lista As New List(Of infraestructura)
        Dim obj As New infraestructura

        Dim consulta = (From tipo In HeliosData.infraestructura
                        Where
                           tipo.estado = "A" And
                            tipo.estado = "P" And
                            tipo.idEmpresa = infraestructuraBE.idEmpresa
                        ).Count

        Return consulta
    End Function

End Class
