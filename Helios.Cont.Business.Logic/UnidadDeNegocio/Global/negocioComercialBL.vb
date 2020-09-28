Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class negocioComercialBL
    Inherits BaseBL

    Public Function GetListaNegocioComercial() As List(Of negocioComercial)
        Return HeliosData.negocioComercial().ToList
    End Function

    Public Function GetListaNEgocioComercialXUnidOrg(negocioComercialBE As negocioComercial) As List(Of negocioComercial)

        Try

            Dim selecion As New Boolean


            Dim centroCostosBE As New negocioComercial
            Dim listaNegocioComercial As New List(Of negocioComercial)

            Dim negocioComercial = (From i In HeliosData.negocioComercial
                           ).ToList

            Dim negocioselecionado = (From i In HeliosData.centroCostosXNComercial Where i.idCentroCosto = negocioComercialBE.IdCentroCosto
                           ).FirstOrDefault


            For Each item In negocioComercial

                If (negocioComercial.Where(Function(o) o.IdNegocioComercial = negocioselecionado.IdNegocioComercial).Count > 0) Then
                    selecion = True
                Else
                    selecion = False
                End If

                centroCostosBE = New negocioComercial With
           {
           .[IdNegocioComercial] = item.IdNegocioComercial,
       .[nombreRubro] = item.[nombreRubro],
      .[tipo] = item.[tipo],
                .[estado] = item.[estado],
                .[usuarioActualizacion] = item.[usuarioActualizacion],
                .[fechaActualizacion] = item.[fechaActualizacion],
                .seleccionNegocio = selecion
           }

                listaNegocioComercial.Add(centroCostosBE)

            Next

            Return listaNegocioComercial

        Catch ex As Exception
            Throw ex
        End Try
    End Function


End Class
