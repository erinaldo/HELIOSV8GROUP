Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class centroCostosXNComercialBL
    Inherits BaseBL

    Public Function GetListacentroCostosXNComercial(centroCostosXNComercialBE As centroCostosXNComercial) As List(Of centroCostosXNComercial)
        ''Return HeliosData.centroCostosXNComercial.Where(Function(o) o.idEmpresa = centroCostosXNComercialBE.idEmpresa And
        ''                                                     o.idCentroCosto = centroCostosXNComercialBE.idCentroCosto).ToList
        'Try

        '    Dim centroCostosBE As New centroCostosXNComercial
        '    Dim listacentroCostosXNComercial As New List(Of centroCostosXNComercial)

        '    Dim negocioComercial = (From i In HeliosData.negocioComercial
        '                   ).ToList

        '    Dim negocioselecionado = (From i In HeliosData.centroCostosXNComercial Where i.idCentroCosto = centroCostosXNComercialBE.idCentroCosto
        '                   ).FirstOrDefault


        '    For Each item In negocioComercial

        '        centroCostosBE = New centroCostosXNComercial With
        '   {
        '   .[idEmpresa] = item.[idEmpresa],
        '   .[idCentroCosto] = item.[idCentroCosto],
        '   .[IdNegocioComercial] = item.[IdNegocioComercial],
        '   .[EstaAutorizado] = item.[EstaAutorizado],
        '   .[idUsuario] = item.[idUsuario],
        '   .tipo = item.tipo,
        '   .[usuarioActualizacion] = item.[usuarioActualizacion],
        '   .[fechaActualizacion] = item.[fechaActualizacion],
        '   .nombreComercial = item.nombreComercial
        '   }

        '        listacentroCostosXNComercial.Add(centroCostosBE)

        '    Next

        '    Return listacentroCostosXNComercial

        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Function

    Public Function GetListaNegociosDisponibles(centroCostosXNComercialBE As centroCostosXNComercial) As centroCostosXNComercial
        'Return HeliosData.centroCostosXNComercial.Where(Function(o) o.idEmpresa = centroCostosXNComercialBE.idEmpresa And
        '                                                     o.idCentroCosto = centroCostosXNComercialBE.idCentroCosto).ToList
        Try

            Dim centroCostosBE As New centroCostosXNComercial
            Dim listacentroCostosXNComercial As New List(Of centroCostosXNComercial)

            Dim consulta = (From i In HeliosData.centroCostosXNComercial
                            Join x In HeliosData.negocioComercial On i.IdNegocioComercial Equals x.IdNegocioComercial
                            Where i.idEmpresa = centroCostosXNComercialBE.idEmpresa _
                                And i.idCentroCosto = centroCostosXNComercialBE.idCentroCosto
                            Select
                                         [idEmpresa] = i.[idEmpresa],
                                     [idCentroCosto] = i.[idCentroCosto],
                                         [IdNegocioComercial] = i.[IdNegocioComercial],
                                         [EstaAutorizado] = i.[EstaAutorizado],
                                     [idUsuario] = i.[idUsuario],
                                     [usuarioActualizacion] = x.[usuarioActualizacion],
                                     [fechaActualizacion] = x.[fechaActualizacion],
                                     nombreComercial = x.nombreRubro).FirstOrDefault

            'For Each item In consulta

            If (Not IsNothing(consulta)) Then
                centroCostosBE = New centroCostosXNComercial With
                  {
                  .[idEmpresa] = consulta.[idEmpresa],
                  .[idCentroCosto] = consulta.[idCentroCosto],
                  .[IdNegocioComercial] = consulta.[IdNegocioComercial],
                  .[EstaAutorizado] = consulta.[EstaAutorizado],
                  .[idUsuario] = consulta.[idUsuario],
                  .[usuarioActualizacion] = consulta.[usuarioActualizacion],
                  .[fechaActualizacion] = consulta.[fechaActualizacion],
                  .nombreComercial = consulta.nombreComercial
                  }
            End If



            'listacentroCostosXNComercial.Add(centroCostosBE)

            'Next

            Return centroCostosBE

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetInsertarcentroCostosXNComercial(centroCostosXNComercialBE As centroCostosXNComercial) As centroCostosXNComercial
        Using ts As New TransactionScope

            Dim obj As New centroCostosXNComercial With
            {
            .[idEmpresa] = centroCostosXNComercialBE.[idEmpresa],
            .[idCentroCosto] = centroCostosXNComercialBE.[idCentroCosto],
            .[IdNegocioComercial] = centroCostosXNComercialBE.[IdNegocioComercial],
            .[EstaAutorizado] = centroCostosXNComercialBE.[EstaAutorizado],
            .[idUsuario] = centroCostosXNComercialBE.[idUsuario],
            .[usuarioActualizacion] = centroCostosXNComercialBE.[usuarioActualizacion],
            .[fechaActualizacion] = centroCostosXNComercialBE.[fechaActualizacion]
            }

            HeliosData.centroCostosXNComercial.Add(obj)
            HeliosData.SaveChanges()
            ts.Complete()
            obj.IdNegocioComercial = obj.IdNegocioComercial
            Return obj
        End Using

    End Function

    Public Sub EliminarPermisoNegocioCOmercial(ByVal be As centroCostosXNComercial)
        Dim consulta = (From i In HeliosData.centroCostosXNComercial
                        Where i.idEmpresa = be.idEmpresa And i.idCentroCosto = be.idCentroCosto And i.IdNegocioComercial = be.IdNegocioComercial).FirstOrDefault

        If Not consulta Is Nothing Then

            be.Action = BaseBE.EntityAction.DELETE
            'InsertItem(be)

            Using ts As New TransactionScope

                CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(consulta)

                'scope.DBContext.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Else
            Throw New Exception("El modulo no se pudo eliminar.")
        End If
    End Sub

    Function GetCentroCostosXNComercialUpdate(be As centroCostosXNComercial) As centroCostosXNComercial
        Using ts As New TransactionScope

            Dim con = (From n In HeliosData.centroCostosXNComercial Where n.idEmpresa = be.idEmpresa And n.idCentroCosto = be.idCentroCosto _
                                                                        And n.IdNegocioComercial = be.IdNegocioComercial).SingleOrDefault

            con.EstaAutorizado = be.EstaAutorizado
            HeliosData.SaveChanges()
            ts.Complete()
            Return con
        End Using
    End Function

End Class
