Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class centroCostoHorarioBL
    Inherits BaseBL

    Public Function GetcentroCostoHorario(be As centroCostoHorario) As List(Of centroCostoHorario)
        Try
            Dim listaHorarios As New List(Of centroCostoHorario)

            Dim consulta = (From n In HeliosData.centroCostoHorario Where n.idEmpresa = be.idEmpresa And n.idCentroCosto = be.idCentroCosto).ToList


            For Each con In consulta
                Dim obj As New centroCostoHorario With
           {
           .[idCentroCostoHorario] = con.[idCentroCostoHorario],
           .[idEmpresa] = con.[idEmpresa],
           .[idCentroCosto] = con.[idCentroCosto],
           .[diaInicio] = con.[diaInicio],
           .[diaFin] = con.[diaFin],
             .[horarioInicio] = con.[horarioInicio],
           .[horarioFin] = con.[horarioFin],
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

    Public Function GetcentroCostoHorarioxID(be As centroCostoHorario) As centroCostoHorario
        Try

            Dim con = (From n In HeliosData.centroCostoHorario Where n.idCentroCostoHorario = be.idCentroCostoHorario And
                                                                     n.idEmpresa = be.idEmpresa And
                                                                     n.idCentroCosto = be.idCentroCosto).SingleOrDefault


            Dim obj As New centroCostoHorario With
           {
           .[idCentroCostoHorario] = con.[idCentroCostoHorario],
           .[idEmpresa] = con.[idEmpresa],
           .[idCentroCosto] = con.[idCentroCosto],
           .[diaInicio] = con.[diaInicio],
           .[diaFin] = con.[diaFin],
             .[horarioInicio] = con.[horarioInicio],
           .[horarioFin] = con.[horarioFin],
           .[estado] = con.[estado],
           .[usuarioActualizacion] = con.[usuarioActualizacion],
           .[fechaActualizacion] = con.[fechaActualizacion]
           }

            Return obj

        Catch ex As Exception
            Throw (ex)
        End Try
    End Function

    Public Function GetInsertarcentroCostoHorario(con As centroCostoHorario) As centroCostoHorario
        Try
            Using ts As New TransactionScope

                Dim obj As New centroCostoHorario With
           {
           .[idEmpresa] = con.[idEmpresa],
           .[idCentroCosto] = con.[idCentroCosto],
           .[diaInicio] = con.[diaInicio],
           .[diaFin] = con.[diaFin],
             .[horarioInicio] = con.[horarioInicio],
           .[horarioFin] = con.[horarioFin],
           .[estado] = con.[estado],
           .[usuarioActualizacion] = con.[usuarioActualizacion],
           .[fechaActualizacion] = con.[fechaActualizacion]
           }

                HeliosData.centroCostoHorario.Add(obj)
                HeliosData.SaveChanges()
                ts.Complete()

                Return obj

            End Using
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function

    Public Function GetUpdatecentroCostoHorario(be As centroCostoHorario) As centroCostoHorario
        Try
            Using ts As New TransactionScope

                Dim con = (From n In HeliosData.centroCostoHorario Where n.idCentroCostoHorario = be.idCentroCostoHorario And
                                                                     n.idEmpresa = be.idEmpresa And
                                                                     n.idCentroCosto = be.idCentroCosto).SingleOrDefault

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

    Public Sub GetDeletecentroCostoHorario(ByVal be As centroCostoHorario)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(be)
    End Sub

End Class
