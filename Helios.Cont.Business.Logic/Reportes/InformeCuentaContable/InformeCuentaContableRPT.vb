Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class InformeCuentaContableRPT
    Inherits BaseBL

    Public Function BuscarInformePorCuentaContableReporte(strCuenta As String, strRazonSocial As String) As List(Of movimiento)
        Dim lista2 As New List(Of movimiento)
        Dim objMostrarEncaja As movimiento
        Dim cuentaPadre As String = Nothing

        Dim mov = (From movimiento In HeliosData.movimiento
                   Join asiento In HeliosData.asiento
                   On movimiento.idAsiento Equals asiento.idAsiento
                   Join cuenta In HeliosData.cuentaplanContableEmpresa _
                   On cuenta.cuenta Equals movimiento.cuenta _
                   And cuenta.idEmpresa Equals asiento.idEmpresa _
                   Where movimiento.cuenta = (strCuenta) _
                   And asiento.nombreEntidad = strRazonSocial _
                   And asiento.idEmpresa = Gempresas.IdEmpresaRuc)

        For Each m In mov
            objMostrarEncaja = New movimiento()
            objMostrarEncaja.cuenta = m.cuenta.cuenta
            objMostrarEncaja.descripcion = m.movimiento.descripcion
            objMostrarEncaja.fechaActualizacion = m.asiento.fechaProceso
            objMostrarEncaja.nombreEntidad = m.asiento.nombreEntidad
            objMostrarEncaja.glosa = m.cuenta.descripcion

            If (m.movimiento.tipo = "D") Then
                objMostrarEncaja.monto = m.movimiento.monto
                objMostrarEncaja.Montocero = m.movimiento.Montocero

                objMostrarEncaja.montoUSD = m.movimiento.montoUSD
                objMostrarEncaja.MontoceroUSD = m.movimiento.MontoceroUSD
            Else
                objMostrarEncaja.monto = m.movimiento.Montocero
                objMostrarEncaja.Montocero = m.movimiento.monto

                objMostrarEncaja.montoUSD = m.movimiento.MontoceroUSD
                objMostrarEncaja.MontoceroUSD = m.movimiento.montoUSD

            End If
            lista2.Add(objMostrarEncaja)
        Next
        Return lista2.ToList
    End Function

End Class
