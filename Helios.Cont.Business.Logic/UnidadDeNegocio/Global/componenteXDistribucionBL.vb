Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class componenteXDistribucionBL
    Inherits BaseBL

    Public Function GetComponenteXDistribucion(be As componenteXDistribucion) As List(Of componenteXDistribucion)
        Try
            Dim listaHorarios As New List(Of componenteXDistribucion)

            Dim consulta = (From n In HeliosData.componenteXDistribucion Where n.idEmpresa = be.idEmpresa And n.idEstablecimiento = be.idEstablecimiento).ToList


            For Each con In consulta
                Dim obj As New componenteXDistribucion With
           {
           .[idComponenteXDistribucion] = con.[idComponenteXDistribucion],
               .[idDistribucionComponente] = con.[idDistribucionComponente],
                 .[idEmpresa] = con.[idEmpresa],
                 .[idEstablecimiento] = con.[idEstablecimiento],
                 .[idActivoEnvio] = con.[idActivoEnvio],
                 .[descripcionComponenteXDistribucion] = con.[descripcionComponenteXDistribucion],
                  .[tipoComponente] = con.[tipoComponente],
                .[imagenUbicacion] = con.[imagenUbicacion],
                .[estado] = con.[estado],
                .[usuarioActualizacion] = con.[usuarioActualizacion],
                .[fechaActualizacion] = con.[fechaActualizacion]
           }

                listaHorarios.Add(obj)
            Next

            Return listaHorarios

        Catch ex As Exception
            Throw (ex)
        End Try
    End Function

    Public Function GetComercioComponenteXDistribucionxID(be As componenteXDistribucion) As componenteXDistribucion
        Try

            Dim con = (From n In HeliosData.componenteXDistribucion Where n.idComponenteXDistribucion = be.idComponenteXDistribucion And
                                                                     n.idEmpresa = be.idEmpresa And
                                                                     n.idEstablecimiento = be.idEstablecimiento).SingleOrDefault


            Dim obj As New componenteXDistribucion With
           {
           .[idComponenteXDistribucion] = con.[idComponenteXDistribucion],
               .[idDistribucionComponente] = con.[idDistribucionComponente],
                 .[idEmpresa] = con.[idEmpresa],
                 .[idEstablecimiento] = con.[idEstablecimiento],
                 .[idActivoEnvio] = con.[idActivoEnvio],
                 .[descripcionComponenteXDistribucion] = con.[descripcionComponenteXDistribucion],
                  .[tipoComponente] = con.[tipoComponente],
                .[imagenUbicacion] = con.[imagenUbicacion],
                .[estado] = con.[estado],
                .[usuarioActualizacion] = con.[usuarioActualizacion],
                .[fechaActualizacion] = con.[fechaActualizacion]
           }

            Return obj

        Catch ex As Exception
            Throw (ex)
        End Try
    End Function

    Public Function GetInsertarComponenteXDistribucion(con As componenteXDistribucion) As componenteXDistribucion
        Try
            Using ts As New TransactionScope

                Dim obj As New componenteXDistribucion With
           {
                 .[idDistribucionComponente] = con.[idDistribucionComponente],
                 .[idEmpresa] = con.[idEmpresa],
                 .[idEstablecimiento] = con.[idEstablecimiento],
                 .[idActivoEnvio] = con.[idActivoEnvio],
                 .[descripcionComponenteXDistribucion] = con.[descripcionComponenteXDistribucion],
                  .[tipoComponente] = con.[tipoComponente],
                .[imagenUbicacion] = con.[imagenUbicacion],
                .[estado] = con.[estado],
                .[usuarioActualizacion] = con.[usuarioActualizacion],
                .[fechaActualizacion] = con.[fechaActualizacion]
           }

                HeliosData.componenteXDistribucion.Add(obj)
                HeliosData.SaveChanges()
                ts.Complete()

                Return obj

            End Using
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function

    Public Function GetUpdateComponenteXDistribucion(be As componenteXDistribucion) As componenteXDistribucion
        Try
            Using ts As New TransactionScope

                Dim con = (From n In HeliosData.componenteXDistribucion Where n.idComponenteXDistribucion = be.idComponenteXDistribucion And
                                                                     n.idEmpresa = be.idEmpresa And
                                                                     n.idEstablecimiento = be.idEstablecimiento).SingleOrDefault

                If (Not IsNothing(con)) Then
                    con.[estado] = "A"
                    HeliosData.SaveChanges()
                End If


                ts.Complete()

                Return con
            End Using

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Sub GetDeleteComponenteXDistribucion(ByVal be As componenteXDistribucion)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(be)
    End Sub

End Class
