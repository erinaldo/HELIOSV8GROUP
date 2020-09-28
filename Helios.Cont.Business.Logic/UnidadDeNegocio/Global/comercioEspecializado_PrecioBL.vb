Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class comercioEspecializado_PrecioBL
    Inherits BaseBL

    Public Function GetComercioEspecializado_Precio(be As comercioEspecializado_Precio) As List(Of comercioEspecializado_Precio)
        Try
            Dim listaHorarios As New List(Of comercioEspecializado_Precio)

            Dim consulta = (From n In HeliosData.comercioEspecializado_Precio Where n.idEmpresa = be.idEmpresa And n.idEstablecimiento = be.idEstablecimiento).ToList


            For Each con In consulta
                Dim obj As New comercioEspecializado_Precio With
           {
           .[idComercioEspecializado] = con.[idComercioEspecializado],
               .[idCentroCostoHorario] = con.[idCentroCostoHorario],
                 .[idDistribucion] = con.[idDistribucion],
                 .[idComponente] = con.[idComponente],
                 .[idEmpresa] = con.[idEmpresa],
                 .[idEstablecimiento] = con.[idEstablecimiento],
                 .[idActivo] = con.[idActivo],
                 .[origen] = con.[origen],
                  .[moneda] = con.[moneda],
                .[numeracion] = con.[numeracion],
                .[precioAsientoMN] = con.[precioAsientoMN],
                .[precioAsientoME] = con.[precioAsientoME],
                .[idConfiguracion] = con.[idConfiguracion],
                .[idItem] = con.[idItem],
                .[descripcionItem] = con.[descripcionItem],
                .[destino] = con.[destino],
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

    Public Function GetComercioEspecializado_PrecioxID(be As comercioEspecializado_Precio) As comercioEspecializado_Precio
        Try

            Dim con = (From n In HeliosData.comercioEspecializado_Precio Where n.idComercioEspecializado = be.idComercioEspecializado And
                                                                     n.idEmpresa = be.idEmpresa And
                                                                     n.idEstablecimiento = be.idEstablecimiento).SingleOrDefault


            Dim obj As New comercioEspecializado_Precio With
           {
          .[idComercioEspecializado] = con.[idComercioEspecializado],
               .[idCentroCostoHorario] = con.[idCentroCostoHorario],
                 .[idDistribucion] = con.[idDistribucion],
                 .[idComponente] = con.[idComponente],
                 .[idEmpresa] = con.[idEmpresa],
                 .[idEstablecimiento] = con.[idEstablecimiento],
                 .[idActivo] = con.[idActivo],
                 .[origen] = con.[origen],
                  .[moneda] = con.[moneda],
                .[numeracion] = con.[numeracion],
                .[precioAsientoMN] = con.[precioAsientoMN],
                .[precioAsientoME] = con.[precioAsientoME],
                .[idConfiguracion] = con.[idConfiguracion],
                .[idItem] = con.[idItem],
                .[descripcionItem] = con.[descripcionItem],
                .[destino] = con.[destino],
                .[estado] = con.[estado],
                .[usuarioActualizacion] = con.[usuarioActualizacion],
                .[fechaActualizacion] = con.[fechaActualizacion]
           }

            Return obj

        Catch ex As Exception
            Throw (ex)
        End Try
    End Function

    Public Function GetInsertarComercioEspecializado_Precio(con As comercioEspecializado_Precio) As comercioEspecializado_Precio
        Try
            Using ts As New TransactionScope

                Dim obj As New comercioEspecializado_Precio With
           {
               .[idCentroCostoHorario] = con.[idCentroCostoHorario],
                 .[idDistribucion] = con.[idDistribucion],
                 .[idComponente] = con.[idComponente],
                 .[idEmpresa] = con.[idEmpresa],
                 .[idEstablecimiento] = con.[idEstablecimiento],
                 .[idActivo] = con.[idActivo],
                 .[origen] = con.[origen],
                  .[moneda] = con.[moneda],
                .[numeracion] = con.[numeracion],
                .[precioAsientoMN] = con.[precioAsientoMN],
                .[precioAsientoME] = con.[precioAsientoME],
                .[idConfiguracion] = con.[idConfiguracion],
                .[idItem] = con.[idItem],
                .[descripcionItem] = con.[descripcionItem],
                .[destino] = con.[destino],
                .[estado] = con.[estado],
                .[usuarioActualizacion] = con.[usuarioActualizacion],
                .[fechaActualizacion] = con.[fechaActualizacion]
                }

                HeliosData.comercioEspecializado_Precio.Add(obj)
                HeliosData.SaveChanges()
                ts.Complete()

                Return obj

            End Using
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function

    Public Function GetUpdateComercioEspecializado_Precio(be As comercioEspecializado_Precio) As comercioEspecializado_Precio
        Try
            Using ts As New TransactionScope

                Dim con = (From n In HeliosData.comercioEspecializado_Precio Where n.idComercioEspecializado = be.idComercioEspecializado And
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

    Public Sub GetDeleteComercioEspecializado_Precio(ByVal be As comercioEspecializado_Precio)
        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(be)
    End Sub

End Class
