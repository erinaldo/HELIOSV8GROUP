Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class LibroDiarioRPT
    Inherits BaseBL

    Public Function ObtenerAsientosPorPeriodoFullReporte() As List(Of asiento)
        Dim lista As New List(Of asiento)
        Dim lista2 As New List(Of movimiento)
        Dim lista3 As New List(Of asiento)
        Dim objMostrarEncaja As asiento

        lista = (From n In HeliosData.asiento Select n).ToList
        Dim a As Integer = 0
        For Each x In lista
            a = a + 1
            objMostrarEncaja = New asiento()
            objMostrarEncaja.fechaProceso = x.fechaProceso
            objMostrarEncaja.glosa = x.glosa
            objMostrarEncaja.tipoEntidad = x.tipoEntidad
            objMostrarEncaja.codigoLibro = x.codigoLibro
            objMostrarEncaja.nombreEntidad = x.nombreEntidad
            objMostrarEncaja.idDocumento = a
            lista3.Add(objMostrarEncaja)
            Dim strIdAsiento As Integer = x.idAsiento
            Dim montocero As Integer = 0
            lista2 = (From i In HeliosData.movimiento _
                            Where i.idAsiento = strIdAsiento _
                           Select i).ToList
            For Each m In lista2
                objMostrarEncaja = New asiento()
                objMostrarEncaja.fechaProceso = Nothing
                objMostrarEncaja.usuarioActualizacion = m.usuarioActualizacion
                If (m.tipo = "D") Then
                    objMostrarEncaja.importeMN = m.monto
                    objMostrarEncaja.importeME = montocero
                Else
                    objMostrarEncaja.importeMN = montocero
                    objMostrarEncaja.importeME = m.monto
                End If
                objMostrarEncaja.Descripcion = m.descripcion
                lista3.Add(objMostrarEncaja)
            Next
        Next
        Return lista3.ToList
    End Function

    Public Function UbicarReporteAsientoPorDocumento(intIdDocumento As Integer) As List(Of asiento)
        Dim lista As New List(Of asiento)
        Dim lista2 As New List(Of movimiento)
        Dim lista3 As New List(Of asiento)
        Dim objMostrarEncaja As asiento
        lista = (From n In HeliosData.asiento Where n.idDocumento = intIdDocumento Select n).ToList
        Dim a As Integer = 0
        For Each x In lista
            a = a + 1
            objMostrarEncaja = New asiento()
            objMostrarEncaja.fechaProceso = x.fechaProceso
            objMostrarEncaja.glosa = x.glosa
            objMostrarEncaja.tipoEntidad = x.tipoEntidad
            objMostrarEncaja.codigoLibro = x.codigoLibro
            objMostrarEncaja.nombreEntidad = x.nombreEntidad
            objMostrarEncaja.idDocumento = a
            lista3.Add(objMostrarEncaja)
            Dim strIdAsiento As Integer = x.idAsiento
            Dim montocero As Integer = 0
            lista2 = (From i In HeliosData.movimiento _
                            Where i.idAsiento = strIdAsiento _
                           Select i).ToList
            For Each m In lista2
                objMostrarEncaja = New asiento()
                objMostrarEncaja.fechaProceso = Nothing
                objMostrarEncaja.usuarioActualizacion = m.usuarioActualizacion
                If (m.tipo = "D") Then
                    objMostrarEncaja.importeMN = m.monto
                    objMostrarEncaja.importeME = montocero
                Else
                    objMostrarEncaja.importeMN = montocero
                    objMostrarEncaja.importeME = m.monto
                End If
                objMostrarEncaja.Descripcion = m.descripcion
                lista3.Add(objMostrarEncaja)
            Next
        Next
        Return lista3.ToList
    End Function

    Public Function UbicarReporteAsientoPorEntidad(intidEntidad As Integer) As List(Of asiento)
        Dim lista As New List(Of asiento)
        Dim lista2 As New List(Of movimiento)
        Dim lista3 As New List(Of asiento)
        Dim objMostrarEncaja As asiento
        lista = (From n In HeliosData.asiento Where n.idEntidad = intidEntidad Select n).ToList
        Dim a As Integer = 0
        For Each x In lista
            a = a + 1
            objMostrarEncaja = New asiento()
            objMostrarEncaja.fechaProceso = x.fechaProceso
            objMostrarEncaja.glosa = x.glosa
            objMostrarEncaja.tipoEntidad = x.tipoEntidad
            objMostrarEncaja.codigoLibro = x.codigoLibro
            objMostrarEncaja.nombreEntidad = x.nombreEntidad
            objMostrarEncaja.idDocumento = a
            lista3.Add(objMostrarEncaja)
            Dim strIdAsiento As Integer = x.idAsiento
            Dim montocero As Integer = 0
            lista2 = (From i In HeliosData.movimiento _
                            Where i.idAsiento = strIdAsiento _
                           Select i).ToList
            For Each m In lista2
                objMostrarEncaja = New asiento()
                objMostrarEncaja.fechaProceso = Nothing
                objMostrarEncaja.usuarioActualizacion = m.usuarioActualizacion
                If (m.tipo = "D") Then
                    objMostrarEncaja.importeMN = m.monto
                    objMostrarEncaja.importeME = montocero
                Else
                    objMostrarEncaja.importeMN = montocero
                    objMostrarEncaja.importeME = m.monto
                End If
                objMostrarEncaja.Descripcion = m.descripcion
                lista3.Add(objMostrarEncaja)
            Next
        Next
        Return lista3.ToList
    End Function

    Public Function UbicarReporteAsientoPorTipo(srtidTipo As String) As List(Of asiento)
        Dim lista As New List(Of asiento)
        Dim lista2 As New List(Of movimiento)
        Dim lista3 As New List(Of asiento)
        Dim objMostrarEncaja As asiento
        lista = (From n In HeliosData.asiento Select n).ToList
        Dim a As Integer = 0
        For Each x In lista
            a = a + 1
            objMostrarEncaja = New asiento()
            objMostrarEncaja.fechaProceso = x.fechaProceso
            objMostrarEncaja.glosa = x.glosa
            objMostrarEncaja.tipoEntidad = x.tipoEntidad
            objMostrarEncaja.codigoLibro = x.codigoLibro
            objMostrarEncaja.nombreEntidad = x.nombreEntidad
            objMostrarEncaja.idDocumento = a
            lista3.Add(objMostrarEncaja)
            Dim strIdAsiento As Integer = x.idAsiento
            Dim montocero As Integer = 0
            lista2 = (From i In HeliosData.movimiento _
                            Where i.idAsiento = strIdAsiento _
                           Select i).ToList
            For Each m In lista2
                objMostrarEncaja = New asiento()
                objMostrarEncaja.fechaProceso = Nothing
                objMostrarEncaja.usuarioActualizacion = m.usuarioActualizacion
                If (m.tipo = "D") Then
                    objMostrarEncaja.importeMN = m.monto
                    objMostrarEncaja.importeME = montocero
                Else
                    objMostrarEncaja.importeMN = montocero
                    objMostrarEncaja.importeME = m.monto
                End If
                objMostrarEncaja.Descripcion = m.descripcion
                lista3.Add(objMostrarEncaja)
            Next
        Next
        Return lista3.ToList
    End Function

    Public Function UbicarReporteAsientoPorFecha(srtFechaInicio As Date, srtFechaHasta As Date, srtidTipo As String) As List(Of asiento)
        Dim lista As New List(Of asiento)
        Dim lista2 As New List(Of movimiento)
        Dim lista3 As New List(Of asiento)
        Dim objMostrarEncaja As asiento
        lista = (From n In HeliosData.asiento _
                 Where n.fechaProceso >= (srtFechaInicio) _
                AndAlso n.fechaProceso <= (srtFechaHasta) _
                And n.codigoLibro = srtidTipo Select n).ToList
        Dim a As Integer = 0
        For Each x In lista
            a = a + 1
            objMostrarEncaja = New asiento()
            objMostrarEncaja.fechaProceso = x.fechaProceso
            objMostrarEncaja.glosa = x.glosa
            objMostrarEncaja.tipoEntidad = x.tipoEntidad
            objMostrarEncaja.codigoLibro = x.codigoLibro
            objMostrarEncaja.nombreEntidad = x.nombreEntidad
            objMostrarEncaja.idDocumento = a
            lista3.Add(objMostrarEncaja)
            Dim strIdAsiento As Integer = x.idAsiento
            Dim montocero As Integer = 0
            lista2 = (From i In HeliosData.movimiento _
                            Where i.idAsiento = strIdAsiento _
                           Select i).ToList
            For Each m In lista2
                objMostrarEncaja = New asiento()
                objMostrarEncaja.fechaProceso = Nothing
                objMostrarEncaja.usuarioActualizacion = m.usuarioActualizacion
                If (m.tipo = "D") Then
                    objMostrarEncaja.importeMN = m.monto
                    objMostrarEncaja.importeME = montocero
                Else
                    objMostrarEncaja.importeMN = montocero
                    objMostrarEncaja.importeME = m.monto
                End If
                objMostrarEncaja.Descripcion = m.descripcion
                lista3.Add(objMostrarEncaja)
            Next
        Next
        Return lista3.ToList
    End Function


    Public Function UbicarReporteAsientosPorPeriodoFull(srtFechaAnio As Integer) As List(Of asiento)
        ' Dim lista As New List(Of asiento)
        Dim lista2 As New List(Of movimiento)
        Dim lista3 As New List(Of asiento)
        Dim TotalDS, TotalHS, TotalDUSD, TotalHUSD As Decimal

        Dim objMostrarEncaja As asiento
        Dim lista = (From n In HeliosData.asiento _
                 Join d In HeliosData.documento _
                 On n.idDocumento Equals d.idDocumento _
                 Where n.fechaProceso.Value.Year = (srtFechaAnio) _
                 And n.idEmpresa = Gempresas.IdEmpresaRuc).ToList
        Dim a As Integer = 0
        For Each x In lista
            a = a + 1
            TotalDS = 0.0
            TotalHS = 0.0
            TotalDUSD = 0.0
            TotalHUSD = 0.0
            objMostrarEncaja = New asiento()
            objMostrarEncaja.fechaProceso = x.n.fechaProceso
            objMostrarEncaja.glosa = x.n.glosa
            objMostrarEncaja.idAsiento = x.n.idAsiento
            objMostrarEncaja.tipoEntidad = x.n.tipoEntidad
            objMostrarEncaja.codigoLibro = x.n.codigoLibro
            objMostrarEncaja.nombreEntidad = x.n.nombreEntidad
            objMostrarEncaja.nroDoc = x.d.nroDoc
            objMostrarEncaja.NroCorrelativo = a
            lista3.Add(objMostrarEncaja)
            Dim strIdAsiento As Integer = x.n.idAsiento
            lista2 = (From i In HeliosData.movimiento _
                            Where i.idAsiento = strIdAsiento _
                           Select i).ToList
            For Each m In lista2
                objMostrarEncaja = New asiento()

                objMostrarEncaja.Descripcion = m.descripcion
                objMostrarEncaja.fechaProceso = Nothing
                objMostrarEncaja.cuentaCont = m.cuenta
                'objMostrarEncaja.NroCorrelativo = a + 1
                If (m.tipo = "D") Then
                    objMostrarEncaja.importeMN = m.monto
                    objMostrarEncaja.montoCeroMN = m.Montocero

                    objMostrarEncaja.importeME = m.montoUSD
                    objMostrarEncaja.montoCeroME = m.MontoceroUSD

                    TotalDS += m.monto
                    TotalDUSD += m.montoUSD

                Else
                    objMostrarEncaja.importeMN = m.Montocero
                    objMostrarEncaja.montoCeroMN = m.monto

                    objMostrarEncaja.importeME = m.MontoceroUSD
                    objMostrarEncaja.montoCeroME = m.montoUSD

                    TotalHS += m.monto
                    TotalHUSD += m.montoUSD
                End If
                lista3.Add(objMostrarEncaja)

            Next
            If (lista2.Count > 0) Then
                objMostrarEncaja = New asiento()
                objMostrarEncaja.Descripcion = "TOTAL"
                objMostrarEncaja.importeMN = TotalDS
                objMostrarEncaja.montoCeroMN = TotalHS

                objMostrarEncaja.importeME = TotalDUSD
                objMostrarEncaja.montoCeroME = TotalHUSD
                lista3.Add(objMostrarEncaja)
            End If
        Next
        Return lista3.ToList
    End Function

    Public Function UbicarReporteAsientoPorPeriodo(srtFechaAnio As String, srtFechaMes As String) As List(Of asiento)
        'Dim lista As New List(Of asiento)
        Dim lista2 As New List(Of movimiento)
        Dim lista3 As New List(Of asiento)
        Dim TotalDS, TotalHS, TotalDUSD, TotalHUSD As Decimal
        Dim objMostrarEncaja As asiento

        Dim lista = (From n In HeliosData.asiento _
                 Join doc In HeliosData.documento _
                 On n.idDocumento Equals doc.idDocumento
                Where n.fechaProceso.Value.Month = srtFechaMes _
                AndAlso n.fechaProceso.Value.Year = srtFechaAnio _
                And n.idEmpresa = Gempresas.IdEmpresaRuc).ToList
        Dim a As Integer = 0
        For Each x In lista
            a = a + 1
            TotalDS = 0.0
            TotalHS = 0.0
            TotalDUSD = 0.0
            TotalHUSD = 0.0
            objMostrarEncaja = New asiento()
            objMostrarEncaja.fechaProceso = x.n.fechaProceso
            objMostrarEncaja.glosa = x.n.glosa
            objMostrarEncaja.idAsiento = x.n.idAsiento
            objMostrarEncaja.tipoEntidad = x.n.tipoEntidad
            objMostrarEncaja.codigoLibro = x.n.codigoLibro
            objMostrarEncaja.nombreEntidad = x.n.nombreEntidad
            objMostrarEncaja.nroDoc = x.doc.nroDoc
            objMostrarEncaja.NroCorrelativo = a
            lista3.Add(objMostrarEncaja)
            Dim strIdAsiento As Integer = x.n.idAsiento
            lista2 = (From i In HeliosData.movimiento _
                            Where i.idAsiento = strIdAsiento _
                           Select i).ToList
            For Each m In lista2
                objMostrarEncaja = New asiento()

                objMostrarEncaja.Descripcion = m.descripcion
                objMostrarEncaja.fechaProceso = Nothing
                objMostrarEncaja.cuentaCont = m.cuenta
                'objMostrarEncaja.NroCorrelativo = a + 1
                If (m.tipo = "D") Then
                    objMostrarEncaja.importeMN = m.monto
                    objMostrarEncaja.montoCeroMN = m.Montocero

                    objMostrarEncaja.importeME = m.montoUSD
                    objMostrarEncaja.montoCeroME = m.MontoceroUSD

                    TotalDS += m.monto
                    TotalDUSD += m.montoUSD

                Else
                    objMostrarEncaja.importeMN = m.Montocero
                    objMostrarEncaja.montoCeroMN = m.monto

                    objMostrarEncaja.importeME = m.MontoceroUSD
                    objMostrarEncaja.montoCeroME = m.montoUSD

                    TotalHS += m.monto
                    TotalHUSD += m.montoUSD
                End If
                lista3.Add(objMostrarEncaja)

            Next
            If (lista2.Count > 0) Then
                objMostrarEncaja = New asiento()
                objMostrarEncaja.Descripcion = "TOTAL"
                objMostrarEncaja.importeMN = TotalDS
                objMostrarEncaja.montoCeroMN = TotalHS

                objMostrarEncaja.importeME = TotalDUSD
                objMostrarEncaja.montoCeroME = TotalHUSD
                lista3.Add(objMostrarEncaja)
            End If
        Next
        Return lista3.ToList
    End Function

    Public Function UbicarReporteAsientoPorAcumulado(dtpDesdeAnio As Date, dtphastaAnio As Date) As List(Of asiento)
        Dim lista As New List(Of asiento)
        Dim lista2 As New List(Of movimiento)
        Dim lista3 As New List(Of asiento)
        Dim TotalDS, TotalHS, TotalDUSD, TotalHUSD As Decimal
        Dim objMostrarEncaja As asiento
        lista = (From n In HeliosData.asiento _
                Where n.fechaProceso.Value > dtpDesdeAnio _
                AndAlso n.fechaProceso.Value < dtphastaAnio _
                And n.idEmpresa = Gempresas.IdEmpresaRuc _
                Select n).ToList
        Dim a As Integer = 0
        For Each x In lista
            a = a + 1
            TotalDS = 0.0
            TotalHS = 0.0
            TotalDUSD = 0.0
            TotalHUSD = 0.0
            objMostrarEncaja = New asiento()
            objMostrarEncaja.fechaProceso = x.fechaProceso
            objMostrarEncaja.glosa = x.glosa
            objMostrarEncaja.tipoEntidad = x.tipoEntidad
            objMostrarEncaja.codigoLibro = x.codigoLibro
            objMostrarEncaja.nombreEntidad = x.nombreEntidad
            objMostrarEncaja.nroDoc = x.nroDoc
            objMostrarEncaja.NroCorrelativo = a
            lista3.Add(objMostrarEncaja)
            Dim strIdAsiento As Integer = x.idAsiento
            lista2 = (From i In HeliosData.movimiento _
                            Where i.idAsiento = strIdAsiento _
                           Select i).ToList
            For Each m In lista2
                objMostrarEncaja = New asiento()

                objMostrarEncaja.Descripcion = m.descripcion
                objMostrarEncaja.fechaProceso = Nothing
                objMostrarEncaja.cuentaCont = m.cuenta
                'objMostrarEncaja.NroCorrelativo = a + 1
                If (m.tipo = "D") Then
                    objMostrarEncaja.importeMN = m.monto
                    objMostrarEncaja.montoCeroMN = m.Montocero

                    objMostrarEncaja.importeME = m.montoUSD
                    objMostrarEncaja.montoCeroME = m.MontoceroUSD

                    TotalDS += m.monto
                    TotalDUSD += m.montoUSD

                Else
                    objMostrarEncaja.importeMN = m.Montocero
                    objMostrarEncaja.montoCeroMN = m.monto

                    objMostrarEncaja.importeME = m.MontoceroUSD
                    objMostrarEncaja.montoCeroME = m.montoUSD

                    TotalHS += m.monto
                    TotalHUSD += m.montoUSD
                End If
                lista3.Add(objMostrarEncaja)

            Next
            If (lista2.Count > 0) Then
                objMostrarEncaja = New asiento()
                objMostrarEncaja.Descripcion = "TOTAL"
                objMostrarEncaja.importeMN = TotalDS
                objMostrarEncaja.montoCeroMN = TotalHS

                objMostrarEncaja.importeME = TotalDUSD
                objMostrarEncaja.montoCeroME = TotalHUSD
                lista3.Add(objMostrarEncaja)
            End If
        Next
        Return lista3.ToList
    End Function
End Class
