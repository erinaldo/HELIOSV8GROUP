Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class ActivoDistribucionBL
    Inherits BaseBL

    Public Function GetActivoDistribucion(be As ActivoDistribucion) As List(Of ActivoDistribucion)
        Try
            Dim listaHorarios As New List(Of ActivoDistribucion)

            Dim consulta = (From n In HeliosData.ActivoDistribucion Where n.idEmpresa = be.idEmpresa And n.idEstablecimiento = be.idEstablecimiento).ToList


            For Each con In consulta
                Dim obj As New ActivoDistribucion With
           {
           .[idActivoEnvio] = con.[idActivoEnvio],
           .[idEmpresa] = con.[idEmpresa],
           .[idEstablecimiento] = con.[idEstablecimiento],
           .[descripcionActivioEnvio] = con.[descripcionActivioEnvio],
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

    Public Function GetActivoDistribucionxID(be As ActivoDistribucion) As ActivoDistribucion
        Try

            Dim con = (From n In HeliosData.ActivoDistribucion Where n.idActivoEnvio = be.idActivoEnvio And
                                                                     n.idEmpresa = be.idEmpresa And
                                                                     n.idEstablecimiento = be.idEstablecimiento).SingleOrDefault


            Dim obj As New ActivoDistribucion With
       {
       .[idActivoEnvio] = con.[idActivoEnvio],
       .[idEmpresa] = con.[idEmpresa],
       .[idEstablecimiento] = con.[idEstablecimiento],
       .[descripcionActivioEnvio] = con.[descripcionActivioEnvio],
       .[estado] = con.[estado],
       .[usuarioActualizacion] = con.[usuarioActualizacion],
       .[fechaActualizacion] = con.[fechaActualizacion]
       }

            Return obj

        Catch ex As Exception
            Throw (ex)
        End Try
    End Function

    Public Function GetInsertarActivoDistribucion(con As ActivoDistribucion) As ActivoDistribucion
        Try
            Using ts As New TransactionScope

                Dim obj As New ActivoDistribucion With
           {
           .[idEmpresa] = con.[idEmpresa],
           .[idEstablecimiento] = con.[idEstablecimiento],
           .[descripcionActivioEnvio] = con.[descripcionActivioEnvio],
           .[estado] = con.[estado],
           .[usuarioActualizacion] = con.[usuarioActualizacion],
           .[fechaActualizacion] = con.[fechaActualizacion]
           }

                HeliosData.ActivoDistribucion.Add(obj)
                HeliosData.SaveChanges()
                ts.Complete()

                Return obj

            End Using
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function

    Public Function GetUpdateActivoDistribucion(be As ActivoDistribucion) As ActivoDistribucion
        Try
            Using ts As New TransactionScope

                Dim con = (From n In HeliosData.ActivoDistribucion Where n.idActivoEnvio = be.idActivoEnvio And
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

    Public Sub GetDeleteActivoDistribucion(ByVal be As ActivoDistribucion)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(be)
    End Sub

End Class
