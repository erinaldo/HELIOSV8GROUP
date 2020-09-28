Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports System.Data.Entity.DbFunctions
Public Class ServicioInfraestructuraBL
    Inherits BaseBL

    Public Sub InsertServicioInfraestructura(objDocumento As servicioInfraestructura)
        Try
            Using ts As New TransactionScope
                Dim existe = HeliosData.servicioInfraestructura.Any(Function(o) o.descripcionServicio = objDocumento.descripcionServicio)
                If existe Then
                    Throw New Exception("El código asignado no esta disponible, ingrese otro")
                End If
                HeliosData.servicioInfraestructura.Add(objDocumento)
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UpdateServicioInfraestructura(objDocumento As servicioInfraestructura)
        Try
            Using ts As New TransactionScope
                Dim documento As servicioInfraestructura = HeliosData.servicioInfraestructura.Where(Function(o) _
                                            o.idServicioInfraestructura = objDocumento.idServicioInfraestructura).First()

                If Not IsNothing(documento) Then

                    documento.[descripcionServicio] = objDocumento.[descripcionServicio]
                    documento.[tipoServicio] = objDocumento.[tipoServicio]
                    documento.[usuarioModificacion] = objDocumento.[usuarioModificacion]
                    documento.[fechaModificacion] = objDocumento.[fechaModificacion]

                    HeliosData.SaveChanges()
                    ts.Complete()
                End If
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GellAllServiciosInfra() As List(Of servicioInfraestructura)

        Dim obj As New ServicioInfraestructura
        Dim listaservicioInfraestructura As New List(Of servicioInfraestructuraDet)
        Dim con = (From n In HeliosData.servicioInfraestructura.Include("servicioInfraestructuraDet")).ToList


        GellAllServiciosInfra = New List(Of servicioInfraestructura)

        For Each i In con

            listaservicioInfraestructura = New List(Of servicioInfraestructuraDet)
            For Each x In i.servicioInfraestructuraDet
                listaservicioInfraestructura.Add(New servicioInfraestructuraDet With
                           {
                        .[idServicioInfraestructura] = x.[idServicioInfraestructura],
                        .[servicio] = x.[servicio],
                        .[detalleServicio] = x.[detalleServicio],
                        .[estado] = x.[estado],
                        .[usuarioModificacion] = x.[usuarioModificacion],
                        .[fechaModificacion] = x.[fechaModificacion]
                          })
            Next

            obj = New servicioInfraestructura With
            {
              .[idServicioInfraestructura] = i.[idServicioInfraestructura],
                .[idEmpresa] = i.[idEmpresa],
                .[idEstablecimiento] = i.[idEstablecimiento],
                .[descripcionServicio] = i.[descripcionServicio],
                .[tipoServicio] = i.[tipoServicio],
                .[usuarioModificacion] = i.[usuarioModificacion],
                .[fechaModificacion] = i.[fechaModificacion],
                .servicioInfraestructuraDet = listaservicioInfraestructura
            }
            GellAllServiciosInfra.Add(obj)
        Next

    End Function


End Class
