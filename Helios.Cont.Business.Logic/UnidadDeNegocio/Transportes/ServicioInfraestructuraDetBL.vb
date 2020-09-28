Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports System.Data.Entity.DbFunctions
Public Class ServicioInfraestructuraDetBL
    Inherits BaseBL

    Public Sub InsertServicioInfraestructuradet(objDocumento As List(Of servicioInfraestructuraDet))
        Try
            Using ts As New TransactionScope

                For Each item In objDocumento
                    Dim existe = HeliosData.servicioInfraestructuraDet.Any(Function(o) o.detalleServicio = item.detalleServicio)
                    If existe Then
                        Throw New Exception("El detalle ya existe asignado no esta disponible, ingrese otro")
                    End If
                    HeliosData.servicioInfraestructuraDet.Add(item)
                    HeliosData.SaveChanges()
                Next
                ts.Complete()

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub InsertServicioInfraestructuraSingle(objDocumento As servicioInfraestructuraDet)
        Try
            Using ts As New TransactionScope


                Dim existe = HeliosData.servicioInfraestructuraDet.Any(Function(o) o.detalleServicio = objDocumento.detalleServicio)
                If existe Then
                    Throw New Exception("El detalle ya existe asignado no esta disponible, ingrese otro")
                End If
                HeliosData.servicioInfraestructuraDet.Add(objDocumento)
                HeliosData.SaveChanges()

                ts.Complete()

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UpdateServicioInfraestructuraSingle(objDocumento As servicioInfraestructuraDet)
        'Try
        '    Using ts As New TransactionScope


        '        Dim existe = HeliosData.servicioInfraestructuraDet(Function(o) o.detalleServicio = objDocumento.detalleServicio)
        '        If existe Then
        '            Throw New Exception("El detalle ya existe asignado no esta disponible, ingrese otro")
        '        End If
        '        HeliosData.servicioInfraestructuraDet.Add(objDocumento)
        '        HeliosData.SaveChanges()

        '        ts.Complete()

        '    End Using
        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Sub


    Public Function GellAllServiciosInfraDet(IdServicio As Integer) As List(Of servicioInfraestructuraDet)

        Dim obj As New servicioInfraestructuraDet


        Dim con = (From n In HeliosData.servicioInfraestructuraDet Where n.idServicioInfraestructura = IdServicio).ToList

        GellAllServiciosInfraDet = New List(Of servicioInfraestructuraDet)

        For Each x In con

            obj = New servicioInfraestructuraDet With
            {
              .[idServicioInfraestructura] = x.[idServicioInfraestructura],
                        .[servicio] = x.[servicio],
                        .[detalleServicio] = x.[detalleServicio],
                        .[estado] = x.[estado],
                        .[usuarioModificacion] = x.[usuarioModificacion],
                        .[fechaModificacion] = x.[fechaModificacion]
            }
            GellAllServiciosInfraDet.Add(obj)
        Next

    End Function

    Public Function GellAllServiciosInfraDetxID(IdServicio As Integer, IdServicioDet As Integer) As servicioInfraestructuraDet

        Dim obj As New servicioInfraestructuraDet


        Dim x = (From n In HeliosData.servicioInfraestructuraDet Where n.idServicioInfraestructura = IdServicio And n.servicio = IdServicioDet).FirstOrDefault

        GellAllServiciosInfraDetxID = New servicioInfraestructuraDet


        obj = New servicioInfraestructuraDet With
            {
              .[idServicioInfraestructura] = x.[idServicioInfraestructura],
                        .[servicio] = x.[servicio],
                        .[detalleServicio] = x.[detalleServicio],
                        .[estado] = x.[estado],
                        .[usuarioModificacion] = x.[usuarioModificacion],
                        .[fechaModificacion] = x.[fechaModificacion]
            }

        GellAllServiciosInfraDetxID = (obj)

    End Function

End Class
