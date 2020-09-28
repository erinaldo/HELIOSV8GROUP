Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class cajaUsuarioRPT
    Inherits BaseBL
    Public Function ResumenTransaccionesXusuarioCajaReporte(be As cajaUsuario) As List(Of cajaUsuario)
        Dim obj As New cajaUsuario
        Dim list As New List(Of cajaUsuario)

        Dim consulta = (From n In HeliosData.usp_ResumenTransaccionesXusuarioCajaXCierre(be.idPersona, be.idcajaUsuario, be.fechaRegistro)
                       Select n).ToList

        For Each i In consulta
            obj = New cajaUsuario



            obj.idcajaUsuario = i.idcajaUsuario
            obj.idPersona = be.idPersona
            obj.idEntidad = i.idEntidad
            obj.NombreEntidad = i.descripcion
            obj.Tipo = i.tipo
            obj.moneda = i.moneda
            obj.fondoMN = i.Inicio
            obj.fondoME = i.InicioME

            If (i.moneda = 1) Then
                obj.ingresoAdicMN = i.ingresos
                obj.otrosEgresosMN = i.egresos
                obj.ingresoAdicME = 0.0
                obj.otrosEgresosME = 0.0
            Else
                obj.ingresoAdicMN = 0.0
                obj.otrosEgresosMN = 0.0
                obj.ingresoAdicME = i.ingresosME
                obj.otrosEgresosME = i.egresosME
            End If

            list.Add(obj)

        Next
        Return list
    End Function
End Class
