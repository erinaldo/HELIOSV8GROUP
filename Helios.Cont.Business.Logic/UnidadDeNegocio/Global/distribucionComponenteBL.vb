Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class distribucionComponenteBL
    Inherits BaseBL

    Public Function GetDistribucionComponente(be As distribucionComponente) As List(Of distribucionComponente)
        Try
            Dim listaHorarios As New List(Of distribucionComponente)

            Dim consulta = (From n In HeliosData.distribucionComponente Where n.idEmpresa = be.idEmpresa And n.idEstablecimiento = be.idEstablecimiento).ToList


            For Each con In consulta
                Dim obj As New distribucionComponente With
           {
           .[idDistribucionComponente] = con.[idDistribucionComponente],
               .[idComponente] = con.[idComponente],
                 .[idEmpresa] = con.[idEmpresa],
                 .[idEstablecimiento] = con.[idEstablecimiento],
                 .[descripcionDistribucion] = con.[descripcionDistribucion],
                 .[tipo] = con.[tipo],
                 .[dimension] = con.[dimension],
                 .[primeraCarateristica] = con.[primeraCarateristica],
                 .[segundaCaracteristica] = con.[segundaCaracteristica],
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

    Public Function GetDistribucionComponentexID(be As distribucionComponente) As distribucionComponente
        Try

            Dim con = (From n In HeliosData.distribucionComponente Where n.idDistribucionComponente = be.idDistribucionComponente And
                                                                     n.idEmpresa = be.idEmpresa And
                                                                     n.idEstablecimiento = be.idEstablecimiento).SingleOrDefault


            Dim obj As New distribucionComponente With
           {
           .[idDistribucionComponente] = con.[idDistribucionComponente],
               .[idComponente] = con.[idComponente],
                 .[idEmpresa] = con.[idEmpresa],
                 .[idEstablecimiento] = con.[idEstablecimiento],
                 .[descripcionDistribucion] = con.[descripcionDistribucion],
                 .[tipo] = con.[tipo],
                 .[dimension] = con.[dimension],
                 .[primeraCarateristica] = con.[primeraCarateristica],
                 .[segundaCaracteristica] = con.[segundaCaracteristica],
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

    Public Function GetInsertarDistribucionComponente(con As distribucionComponente) As distribucionComponente
        Try
            Using ts As New TransactionScope

                Dim obj As New distribucionComponente With
           {
                        .[idComponente] = con.[idComponente],
                 .[idEmpresa] = con.[idEmpresa],
                 .[idEstablecimiento] = con.[idEstablecimiento],
                 .[descripcionDistribucion] = con.[descripcionDistribucion],
                 .[tipo] = con.[tipo],
                 .[dimension] = con.[dimension],
                 .[primeraCarateristica] = con.[primeraCarateristica],
                 .[segundaCaracteristica] = con.[segundaCaracteristica],
                 .[imagenUbicacion] = con.[imagenUbicacion],
                 .[estado] = con.[estado],
                 .[usuarioActualizacion] = con.[usuarioActualizacion],
                .[fechaActualizacion] = con.[fechaActualizacion]
           }

                HeliosData.distribucionComponente.Add(obj)
                HeliosData.SaveChanges()
                ts.Complete()

                Return obj

            End Using
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function

    Public Function GetUpdateDistribucionComponente(be As distribucionComponente) As distribucionComponente
        Try
            Using ts As New TransactionScope

                Dim con = (From n In HeliosData.distribucionComponente Where n.idDistribucionComponente = be.idDistribucionComponente And
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

    Public Sub GetDeleteDistribucionComponente(ByVal be As distribucionComponente)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(be)
    End Sub

End Class
