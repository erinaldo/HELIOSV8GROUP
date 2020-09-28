Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class LibroMayorRPT
    Inherits BaseBL


    Public Function GetUbicarMovimientoLibroMayorFullMensual(strCuenta As List(Of String), periodo As String, mesPer As String) As List(Of movimiento)
        Dim lista3 As New List(Of movimiento)
        Dim objMostrarEncaja As movimiento
        Dim a As Integer = 0
        Dim TotalDS, TotalHS, TotalDUSD, TotalHUSD As Decimal
        Dim listacuentaitems As String = Nothing

        For Each listacuenta In strCuenta
            listacuentaitems = listacuenta
            Dim mov = (From movimiento In HeliosData.movimiento
                       Join cuenta In HeliosData.cuentaplanContableEmpresa
                    On movimiento.cuenta Equals cuenta.cuenta
                       Where movimiento.cuenta = (listacuentaitems)
                       Group movimiento By
                                   movimiento.cuenta,
                                 cuenta.descripcion,
                                 cuenta.cuentaPadre,
                                 cuenta.Observaciones
                                   Into g = Group
                       Select New With {
                                                    .cuenta = cuenta,
                                                    .descripcion = descripcion,
                                                    .Observaciones = Observaciones,
                                                    .cuentaPadre = cuentaPadre}).FirstOrDefault
            a = a + 1
            TotalDS = 0.0
            TotalHS = 0.0
            TotalDUSD = 0.0
            TotalHUSD = 0.0
            objMostrarEncaja = New movimiento()
            objMostrarEncaja.cuenta = mov.cuenta
            objMostrarEncaja.descripcion = mov.descripcion
            objMostrarEncaja.numeroCorrelativo = (a)
            lista3.Add(objMostrarEncaja)

            Dim lista = (From movi In HeliosData.movimiento
                         Join asi In HeliosData.asiento
                         On movi.idAsiento Equals asi.idAsiento
                         Join doc In HeliosData.documento
                         On asi.idDocumento Equals doc.idDocumento
                         Where movi.cuenta = mov.cuenta _
                         And asi.fechaProceso.Value.Year = periodo _
                         And asi.fechaProceso.Value.Month = mesPer _
                         And asi.idEmpresa = Gempresas.IdEmpresaRuc).ToList

            For Each m2 In lista

                objMostrarEncaja = New movimiento()
                objMostrarEncaja.numeroCorrelativo = Nothing
                objMostrarEncaja.descripcion = m2.movi.descripcion
                objMostrarEncaja.fechaActualizacion = m2.asi.fechaProceso
                objMostrarEncaja.nombreEntidad = m2.asi.nombreEntidad
                objMostrarEncaja.nroDoc = m2.doc.nroDoc
                objMostrarEncaja.tipoDoc = m2.doc.tipoDoc
                objMostrarEncaja.codigoLibro = m2.asi.codigoLibro
                objMostrarEncaja.idAsiento = m2.asi.idAsiento

                If (m2.movi.tipo = "D") Then
                    objMostrarEncaja.monto = m2.movi.monto
                    objMostrarEncaja.Montocero = m2.movi.Montocero

                    objMostrarEncaja.montoUSD = m2.movi.montoUSD
                    objMostrarEncaja.MontoceroUSD = m2.movi.MontoceroUSD

                    TotalDS += m2.movi.monto
                    TotalDUSD += m2.movi.montoUSD
                Else
                    objMostrarEncaja.monto = m2.movi.Montocero
                    objMostrarEncaja.Montocero = m2.movi.monto

                    objMostrarEncaja.montoUSD = m2.movi.MontoceroUSD
                    objMostrarEncaja.MontoceroUSD = m2.movi.montoUSD

                    TotalHS += m2.movi.monto
                    TotalHUSD += m2.movi.montoUSD
                End If
                lista3.Add(objMostrarEncaja)
            Next
            If (lista.Count > 0) Then
                objMostrarEncaja = New movimiento()
                objMostrarEncaja.nombreEntidad = "TOTAL"
                objMostrarEncaja.monto = TotalDS
                objMostrarEncaja.Montocero = TotalHS

                objMostrarEncaja.montoUSD = TotalDUSD
                objMostrarEncaja.MontoceroUSD = TotalHUSD
                lista3.Add(objMostrarEncaja)
            End If
        Next
        Return lista3.ToList
    End Function

    Public Function GetUbicarMovimientoLibroMayorFull(strCuenta As List(Of String), periodo As String) As List(Of movimiento)
        Dim lista3 As New List(Of movimiento)
        Dim objMostrarEncaja As movimiento
        Dim a As Integer = 0
        Dim TotalDS, TotalHS, TotalDUSD, TotalHUSD As Decimal
        Dim listacuentaitems As String = Nothing

        For Each listacuenta In strCuenta
            listacuentaitems = listacuenta
            Dim mov = (From movimiento In HeliosData.movimiento
                       Join cuenta In HeliosData.cuentaplanContableEmpresa _
                    On movimiento.cuenta Equals cuenta.cuenta _
                      Where movimiento.cuenta = (listacuentaitems) _
                          Group movimiento By _
                                   movimiento.cuenta,
                                 cuenta.descripcion, _
                                 cuenta.cuentaPadre, _
                                 cuenta.Observaciones _
                                   Into g = Group _
                                   Select New With {
                                                    .cuenta = cuenta,
                                                    .descripcion = descripcion,
                                                    .Observaciones = Observaciones,
                                                    .cuentaPadre = cuentaPadre}).FirstOrDefault
            a = a + 1
            TotalDS = 0.0
            TotalHS = 0.0
            TotalDUSD = 0.0
            TotalHUSD = 0.0
            objMostrarEncaja = New movimiento()
            objMostrarEncaja.cuenta = mov.cuenta
            objMostrarEncaja.descripcion = mov.descripcion
            objMostrarEncaja.numeroCorrelativo = (a)
            lista3.Add(objMostrarEncaja)

            Dim lista = (From movi In HeliosData.movimiento
                         Join asi In HeliosData.asiento
                         On movi.idAsiento Equals asi.idAsiento
                         Join doc In HeliosData.documento
                         On asi.idDocumento Equals doc.idDocumento
                         Where movi.cuenta = mov.cuenta _
                         And asi.fechaProceso.Value.Year = periodo _
                         And asi.idEmpresa = Gempresas.IdEmpresaRuc).ToList

            For Each m2 In lista

                objMostrarEncaja = New movimiento()
                objMostrarEncaja.numeroCorrelativo = Nothing
                objMostrarEncaja.descripcion = m2.movi.descripcion
                objMostrarEncaja.fechaActualizacion = m2.asi.fechaProceso
                objMostrarEncaja.nombreEntidad = m2.asi.nombreEntidad
                objMostrarEncaja.nroDoc = m2.doc.nroDoc
                objMostrarEncaja.tipoDoc = m2.doc.tipoDoc
                objMostrarEncaja.codigoLibro = m2.asi.codigoLibro
                objMostrarEncaja.idAsiento = m2.asi.idAsiento

                If (m2.movi.tipo = "D") Then
                    objMostrarEncaja.monto = m2.movi.monto
                    objMostrarEncaja.Montocero = m2.movi.Montocero

                    objMostrarEncaja.montoUSD = m2.movi.montoUSD
                    objMostrarEncaja.MontoceroUSD = m2.movi.MontoceroUSD

                    TotalDS += m2.movi.monto
                    TotalDUSD += m2.movi.montoUSD
                Else
                    objMostrarEncaja.monto = m2.movi.Montocero
                    objMostrarEncaja.Montocero = m2.movi.monto

                    objMostrarEncaja.montoUSD = m2.movi.MontoceroUSD
                    objMostrarEncaja.MontoceroUSD = m2.movi.montoUSD

                    TotalHS += m2.movi.monto
                    TotalHUSD += m2.movi.montoUSD
                End If
                lista3.Add(objMostrarEncaja)
            Next
            If (lista.Count > 0) Then
                objMostrarEncaja = New movimiento()
                objMostrarEncaja.nombreEntidad = "TOTAL"
                objMostrarEncaja.monto = TotalDS
                objMostrarEncaja.Montocero = TotalHS

                objMostrarEncaja.montoUSD = TotalDUSD
                objMostrarEncaja.MontoceroUSD = TotalHUSD
                lista3.Add(objMostrarEncaja)
            End If
        Next
        Return lista3.ToList
    End Function

    Public Function GetUbicarMovimientoLibroMayorPorIdDocumento(strCuenta As String) As List(Of movimiento)
        Dim lista1 As New List(Of movimiento)
        Dim lista2 As New List(Of asiento)
        Dim lista3 As New List(Of movimiento)
        Dim TotalDS, TotalHS, TotalDUSD, TotalHUSD As Decimal
        Dim objMostrarEncaja As movimiento
        Dim a As Integer = 0

        Dim mov = (From movimiento In HeliosData.movimiento
                   Join cuenta In HeliosData.cuentaplanContableEmpresa _
                On movimiento.cuenta Equals cuenta.cuenta _
                  Where movimiento.cuenta = (strCuenta) _
                      Group movimiento By _
                               movimiento.cuenta,
                             cuenta.descripcion, _
                             cuenta.cuentaPadre, _
                             cuenta.Observaciones _
                               Into g = Group _
                               Select New With {
                                                .cuenta = cuenta,
                                                .descripcion = descripcion,
                                                .Observaciones = Observaciones,
                                                .cuentaPadre = cuentaPadre}).FirstOrDefault
        a = a + 1
        objMostrarEncaja = New movimiento()
        objMostrarEncaja.cuenta = strCuenta
        objMostrarEncaja.descripcion = mov.descripcion
        objMostrarEncaja.numeroCorrelativo = (a)
        lista3.Add(objMostrarEncaja)

        Dim lista = (From movi In HeliosData.movimiento
                     Join asi In HeliosData.asiento
                     On movi.idAsiento Equals asi.idAsiento
                     Join doc In HeliosData.documento
                     On asi.idDocumento Equals doc.idDocumento
                     Where movi.cuenta = strCuenta _
                     And asi.idEmpresa = Gempresas.IdEmpresaRuc).ToList

        For Each m2 In lista

            objMostrarEncaja = New movimiento()
            objMostrarEncaja.numeroCorrelativo = Nothing
            objMostrarEncaja.descripcion = m2.movi.descripcion
            objMostrarEncaja.fechaActualizacion = m2.asi.fechaProceso
            objMostrarEncaja.nombreEntidad = m2.asi.nombreEntidad
            objMostrarEncaja.nroDoc = m2.doc.nroDoc
            objMostrarEncaja.tipoDoc = m2.doc.tipoDoc
            objMostrarEncaja.codigoLibro = m2.asi.codigoLibro
            objMostrarEncaja.idAsiento = m2.asi.idAsiento

            If (m2.movi.tipo = "D") Then
                objMostrarEncaja.monto = m2.movi.monto
                objMostrarEncaja.Montocero = m2.movi.Montocero

                objMostrarEncaja.montoUSD = m2.movi.montoUSD
                objMostrarEncaja.MontoceroUSD = m2.movi.MontoceroUSD

                TotalDS += m2.movi.monto
                TotalDUSD += m2.movi.montoUSD
            Else
                objMostrarEncaja.monto = m2.movi.Montocero
                objMostrarEncaja.Montocero = m2.movi.monto

                objMostrarEncaja.montoUSD = m2.movi.MontoceroUSD
                objMostrarEncaja.MontoceroUSD = m2.movi.montoUSD

                TotalHS += m2.movi.monto
                TotalHUSD += m2.movi.montoUSD
            End If
            lista3.Add(objMostrarEncaja)
        Next
        If (lista.Count > 0) Then
            objMostrarEncaja = New movimiento()
            objMostrarEncaja.nombreEntidad = "TOTAL"
            objMostrarEncaja.monto = TotalDS
            objMostrarEncaja.Montocero = TotalHS

            objMostrarEncaja.montoUSD = TotalDUSD
            objMostrarEncaja.MontoceroUSD = TotalHUSD
            lista3.Add(objMostrarEncaja)
        End If


        Return lista3.ToList
    End Function
End Class
