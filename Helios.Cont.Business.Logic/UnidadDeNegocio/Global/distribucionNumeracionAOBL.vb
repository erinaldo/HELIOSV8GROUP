Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class distribucionNumeracionAOBL
    Inherits BaseBL

    Public Function GetDistribucionNumeracionBL(be As distribucionNumeracionAO) As List(Of distribucionNumeracionAO)
        Try
            Dim listaHorarios As New List(Of distribucionNumeracionAO)

            Dim consulta = (From n In HeliosData.distribucionNumeracionAO).ToList


            For Each con In consulta
                Dim obj As New distribucionNumeracionAO With
           {
               .[IdEnumeracion] = con.[IdEnumeracion],
               .idCargo = con.idCargo,
               .idRol = con.idRol,
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

    Public Function GetdistribucionNumeracionAOxID(be As distribucionNumeracionAO) As distribucionNumeracionAO
        Try

            Dim con = (From n In HeliosData.distribucionNumeracionAO Where n.IdEnumeracion = be.IdEnumeracion).SingleOrDefault


            Dim obj As New distribucionNumeracionAO With
           {
               .[IdEnumeracion] = con.[IdEnumeracion],
               .idCargo = con.idCargo,
               .idRol = con.idRol,
               .[estado] = con.[estado],
               .[usuarioActualizacion] = con.[usuarioActualizacion],
               .[fechaActualizacion] = con.[fechaActualizacion]
           }

            Return obj

        Catch ex As Exception
            Throw (ex)
        End Try
    End Function

    Public Function InsertNumeracionXAreaOperativa(con As distribucionNumeracionAO) As Integer
        Try
            Dim numeracionBoletaBL As New numeracionBoletasBL

            Using ts As New TransactionScope

                con.numeracionBoletas.afectoUN = False

                Dim idNumeracion = numeracionBoletaBL.Insert(con.numeracionBoletas)


                Dim obj As New distribucionNumeracionAO With
           {
               .idCargo = con.idCargo,
               .IdEnumeracion = idNumeracion,
               .idRol = con.idRol,
               .[estado] = con.[estado],
                .[usuarioActualizacion] = con.[usuarioActualizacion],
               .[fechaActualizacion] = con.[fechaActualizacion]
           }

                HeliosData.distribucionNumeracionAO.Add(obj)
                HeliosData.SaveChanges()


                ts.Complete()

                Return 1

            End Using
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function

    Public Function InsertAreaOperativaNumeracion(con As distribucionNumeracionAO) As Integer
        Try
            Dim numeracionBoletaBL As New numeracionBoletasBL

            Using ts As New TransactionScope


                Dim obj As New distribucionNumeracionAO With
           {
               .idCargo = con.idCargo,
               .IdEnumeracion = con.IdEnumeracion,
               .idRol = con.idRol,
               .[estado] = con.[estado],
               .idCentroCosto = con.idCentroCosto,
                .[usuarioActualizacion] = con.[usuarioActualizacion],
               .[fechaActualizacion] = con.[fechaActualizacion]
           }

                HeliosData.distribucionNumeracionAO.Add(obj)
                HeliosData.SaveChanges()

                ts.Complete()

                Return 1

            End Using
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function

    Public Function InsertListaNumeracionAo(conItem As List(Of distribucionNumeracionAO)) As Integer
        Try
            Dim numeracionBoletaBL As New numeracionBoletasBL

            Using ts As New TransactionScope

                For Each con In conItem
                    Dim obj As New distribucionNumeracionAO With
           {
               .idCargo = con.idCargo,
               .IdEnumeracion = con.IdEnumeracion,
               .idRol = con.idRol,
               .[estado] = con.[estado],
               .idCentroCosto = con.idCentroCosto,
                .[usuarioActualizacion] = con.[usuarioActualizacion],
               .[fechaActualizacion] = con.[fechaActualizacion]
           }

                    HeliosData.distribucionNumeracionAO.Add(obj)
                    HeliosData.SaveChanges()
                Next

                ts.Complete()

                Return 1

            End Using
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function

    Public Function GetUpdatedistribucionNumeracionAO(be As distribucionNumeracionAO) As distribucionNumeracionAO
        Try
            Using ts As New TransactionScope

                Dim con = (From n In HeliosData.distribucionNumeracionAO Where n.IdEnumeracion = be.IdEnumeracion).SingleOrDefault

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

    Public Sub GetDeletedistribucionNumeracionAO(ByVal be As distribucionNumeracionAO)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(be)
    End Sub

End Class
