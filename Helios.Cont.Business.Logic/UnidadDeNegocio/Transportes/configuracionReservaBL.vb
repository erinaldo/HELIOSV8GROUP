Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF

Public Class configuracionReservaBL
    Inherits BaseBL

    Public Function GetConfiguracion(configuracionBE As configuracionReserva) As List(Of configuracionReserva)
        Return HeliosData.configuracionReserva.Where(Function(o) o.idEmpresa = configuracionBE.idEmpresa).ToList
    End Function

    Public Function GetConfiguracionID(be As configuracionReserva) As configuracionReserva
        Dim listaHorarios As New List(Of ruta_horarios)
        Dim con = (From n In HeliosData.configuracionReserva Where n.idConfiguracion = be.idConfiguracion).SingleOrDefault


        Dim obj As New configuracionReserva With
        {
        .[idConfiguracion] = con.[idConfiguracion],
        .[idEmpresa] = con.[idEmpresa],
        .[idEstablecimiento] = con.[idEstablecimiento],
        .[descripcion] = con.[descripcion],
        .[color] = con.[color],
        .[abreviatura] = con.[abreviatura],
        .[estado] = con.[estado],
        .[usuarioActualizacion] = con.[usuarioActualizacion],
        .[fechaModificacion] = con.[fechaModificacion]
        }


        Return obj
    End Function

    Function GetConfiguracionInsert(be As configuracionReserva) As configuracionReserva
        Using ts As New TransactionScope

            Dim obj As New configuracionReserva With
            {
            .[idConfiguracion] = be.[idConfiguracion],
            .[idEmpresa] = be.[idEmpresa],
            .[idEstablecimiento] = be.[idEstablecimiento],
            .[descripcion] = be.[descripcion],
            .[color] = be.[color],
            .[abreviatura] = be.[abreviatura],
            .[estado] = be.[estado],
            .[usuarioActualizacion] = be.[usuarioActualizacion],
            .[fechaModificacion] = be.[fechaModificacion]
            }

            HeliosData.configuracionReserva.Add(obj)
            HeliosData.SaveChanges()
            ts.Complete()
            obj.idConfiguracion = obj.idConfiguracion
            Return obj
        End Using
    End Function

    Function GetConfiguracionUpdate(be As configuracionReserva) As configuracionReserva
        Using ts As New TransactionScope

            Dim con = (From n In HeliosData.configuracionReserva Where n.idConfiguracion = be.idConfiguracion).SingleOrDefault

            Dim obj As New configuracionReserva With
            {
                      .[idEstablecimiento] = con.[idEstablecimiento],
            .[descripcion] = con.[descripcion],
            .[color] = con.[color],
            .[abreviatura] = con.[abreviatura],
            .[estado] = con.[estado],
            .[usuarioActualizacion] = con.[usuarioActualizacion],
            .[fechaModificacion] = con.[fechaModificacion]
            }

            HeliosData.configuracionReserva.Add(obj)
            HeliosData.SaveChanges()
            ts.Complete()
            obj.idConfiguracion = obj.idConfiguracion
            Return obj
        End Using
    End Function

End Class
