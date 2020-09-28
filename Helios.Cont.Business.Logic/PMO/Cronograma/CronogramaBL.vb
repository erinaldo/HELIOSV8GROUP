Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Imports System.Data.Entity.DbFunctions

Public Class CronogramaBL
    Inherits BaseBL

    Public Function GetListarCuotasDocumento(iddoc As Integer) As List(Of Cronograma)
        Dim Lista As New List(Of Cronograma)
        Dim objRecurso As New Cronograma

        Dim consulta = (From cro In HeliosData.Cronograma
                        Where cro.idDocumentoRef = iddoc).ToList

        For Each obj In consulta
            objRecurso = New Cronograma
            objRecurso.idCronograma = obj.idCronograma
            objRecurso.idDocumentoRef = obj.idDocumentoRef
            objRecurso.fechaPago = obj.fechaPago
            objRecurso.fechaoperacion = obj.fechaoperacion
            objRecurso.nrocuota = obj.nrocuota
            objRecurso.montoAutorizadoMN = obj.montoAutorizadoMN
            objRecurso.montoAutorizadoME = obj.montoAutorizadoME
            objRecurso.estado = obj.estado
            Lista.Add(objRecurso)
        Next

        Return Lista
    End Function

    Public Function GetListarCuotasDocumentoPagos(iddoc As Integer) As List(Of Cronograma)
        Dim Lista As New List(Of Cronograma)
        Dim objRecurso As New Cronograma

        Dim consulta = (From cro In HeliosData.Cronograma
                        Group Join caja In HeliosData.documentoCaja
                            On caja.idcosto Equals cro.idCronograma
                            Into mov_join = Group
                        From mov In mov_join.DefaultIfEmpty()
                        Where cro.idDocumentoRef = iddoc
                        Group New With {cro, mov} By
                            cro.idCronograma,
                            cro.idDocumentoRef,
                            cro.fechaPago,
                            cro.fechaoperacion,
                            cro.nrocuota,
                            cro.montoAutorizadoMN,
                            cro.montoAutorizadoME,
                            cro.estado
                            Into g = Group
                        Select
                            idCronograma,
                            idDocumentoRef,
                            fechaPago,
                            fechaoperacion,
                            nrocuota,
                            montoAutorizadoMN,
                            montoAutorizadoME,
                            estado,
                            Pagos = CType(g.Sum(Function(p) p.mov.montoSoles), Decimal?)
                        ).ToList

        For Each obj In consulta
            objRecurso = New Cronograma
            objRecurso.idCronograma = obj.idCronograma
            objRecurso.idDocumentoRef = obj.idDocumentoRef
            objRecurso.fechaPago = obj.fechaPago
            objRecurso.fechaoperacion = obj.fechaoperacion
            objRecurso.nrocuota = obj.nrocuota
            objRecurso.montoAutorizadoMN = obj.montoAutorizadoMN
            objRecurso.montoAutorizadoME = obj.montoAutorizadoME
            objRecurso.PagosMN = obj.Pagos.GetValueOrDefault
            objRecurso.estado = obj.estado
            Lista.Add(objRecurso)
        Next

        Return Lista
    End Function


    Public Sub DeleteCronoDocumento(ByVal cronograma As List(Of Cronograma))
        For Each i In cronograma
            Me.DeleteCronoHijo(i.idCronograma)
        Next

    End Sub


    Public Function GetListarCronogramaDpcumento(iddoc As Integer) As List(Of Cronograma)
        Dim Lista As New List(Of Cronograma)
        Dim listaTipoCompra As New List(Of String)
        Dim objRecurso As New Cronograma
        Dim list As New List(Of String)
        Dim list2 As New List(Of String)



        Dim consulta = (From cro In HeliosData.Cronograma
                        Where cro.idDocumentoRef = iddoc And cro.estado = "PN").ToList

        For Each obj In consulta
            objRecurso = New Cronograma
            objRecurso.fechaoperacion = obj.fechaoperacion
            objRecurso.fechaPago = obj.fechaPago
            objRecurso.montoAutorizadoMN = obj.montoAutorizadoMN
            objRecurso.montoAutorizadoME = obj.montoAutorizadoME
            objRecurso.idCronograma = obj.idCronograma
            Lista.Add(objRecurso)
        Next

        Return Lista
    End Function


    Public Function GetListarCobrosPorMes(tipoProg As String) As List(Of Cronograma)
        Dim Lista As New List(Of Cronograma)
        Dim listaTipoCompra As New List(Of String)
        Dim objRecurso As New Cronograma
        Dim list As New List(Of String)
        Dim list2 As New List(Of String)

        list.Add("PN")
        list.Add("OB")
        list.Add("AP")
        list2.Add("C")
        list2.Add("CA")

        Dim consulta = (From prod In HeliosData.Cronograma
                        Where prod.fechaPago.Value.Year = AnioGeneral And prod.moneda = "1" _
                      And list2.Contains(prod.tipo) And list.Contains(prod.estado)
                        Group prod By prod.identidad, prod.tipoRazon, prod.estado, prod.fechaContable
                         Into grouping = Group
                        Select identidad, tipoRazon, estado, fechaContable,
                            Totalmn = grouping.Sum(Function(p) p.montoAutorizadoMN),
                            Totalme = grouping.Sum(Function(p) p.montoAutorizadoME)).ToList

        For Each obj In consulta
            objRecurso = New Cronograma
            objRecurso.fechaContable = obj.fechaContable
            objRecurso.montoAutorizadoMN = obj.Totalmn
            objRecurso.montoAutorizadoME = obj.Totalme
            Lista.Add(objRecurso)
        Next

        Return Lista
    End Function



    Public Function UbicarCronogramaPorEntidadCobro(idprov As Integer, tipoprov As String) As List(Of Cronograma)
        Dim cronoBE As New Cronograma
        Dim Lista As New List(Of Cronograma)
        Dim list As New List(Of String)
        Dim listTipo As New List(Of String)

        list.Add("PN")
        list.Add("OB")
        list.Add("AP")
        listTipo.Add("C")
        listTipo.Add("CA")

        Dim consulta = (From prod In HeliosData.Cronograma
                        Where list.Contains(prod.estado) And listTipo.Contains(prod.tipo) _
                        And prod.identidad = idprov And prod.tipoRazon = tipoprov
                        Group prod By prod.identidad, prod.tipoRazon, prod.fechaContable
                         Into grouping = Group
                        Select identidad, tipoRazon, fechaContable,
                        Totalmn = grouping.Sum(Function(p) p.montoAutorizadoMN),
                        Totalme = grouping.Sum(Function(p) p.montoAutorizadoME)).ToList

        For Each i In consulta

            cronoBE = New Cronograma
            cronoBE.tipo = "P"
            cronoBE.montoAutorizadoMN = i.Totalmn
            cronoBE.montoAutorizadoME = i.Totalme
            cronoBE.fechaContable = i.fechaContable
            cronoBE.identidad = i.identidad
            cronoBE.tipoRazon = i.tipoRazon
            Lista.Add(cronoBE)

        Next

        Return Lista
    End Function



    Public Function GetCronogramaCobroFecha(tipoProgramado As String, FechaInicio As Date, FechaFin As Date) As List(Of Cronograma)
        Dim cronoBE As New Cronograma
        Dim Lista As New List(Of Cronograma)
        Dim list As New List(Of String)
        Dim listTipo As New List(Of String)

        list.Add("PN")
        list.Add("OB")
        list.Add("AP")
        listTipo.Add("C")
        listTipo.Add("CA")

        Dim consulta = (From prod In HeliosData.Cronograma
                        Where list.Contains(prod.estado) And listTipo.Contains(prod.tipo) _
                        And TruncateTime(prod.fechaPago) >= FechaInicio.Date And TruncateTime(prod.fechaPago) <= FechaFin.Date
                        Group prod By prod.identidad, prod.tipoRazon
                       Into grouping = Group
                        Select identidad, tipoRazon,
                        Totalmn = grouping.Sum(Function(p) p.montoAutorizadoMN),
                        Totalme = grouping.Sum(Function(p) p.montoAutorizadoME)).ToList


        For Each i In consulta
            cronoBE = New Cronograma
            cronoBE.tipo = "C"
            cronoBE.montoAutorizadoMN = i.Totalmn
            cronoBE.montoAutorizadoME = i.Totalme
            cronoBE.glosa = ""
            cronoBE.identidad = i.identidad
            cronoBE.tipoRazon = i.tipoRazon
            cronoBE.tipocambio = CDec(0.0)
            cronoBE.fechaoperacion = DateTime.Now
            cronoBE.fechaPago = DateTime.Now
            cronoBE.idCronograma = 0
            cronoBE.idDocumentoRef = 0

            Lista.Add(cronoBE)
        Next

        Return Lista
    End Function




    Public Function ConteoVencidosCronograma() As Integer

        Dim list As New List(Of String)
        Dim list2 As New List(Of String)

        list.Add("PN")
        list.Add("OB")
        list.Add("AP")
        list2.Add("P")
        list2.Add("PA")

        Dim consulta = (From prod In HeliosData.Cronograma
                        Where list.Contains(prod.estado) And list2.Contains(prod.tipo) _
                        And TruncateTime(prod.fechaPago) < TruncateTime(DateTime.Now)).Count

        Return consulta
    End Function

    Public Function ConteoVencidosCobroCronograma() As Integer

        Dim list As New List(Of String)
        Dim list2 As New List(Of String)

        list.Add("PN")
        list.Add("OB")
        list.Add("AP")
        list2.Add("C")
        list2.Add("CA")

        Dim consulta = (From prod In HeliosData.Cronograma
                        Where list.Contains(prod.estado) And list2.Contains(prod.tipo) _
                        And TruncateTime(prod.fechaPago) < TruncateTime(DateTime.Now)).Count

        Return consulta
    End Function



    Public Function GetListarPagosPorMes(tipoProg As String) As List(Of Cronograma)
        Dim Lista As New List(Of Cronograma)
        Dim listaTipoCompra As New List(Of String)
        Dim objRecurso As New Cronograma
        Dim list As New List(Of String)
        Dim list2 As New List(Of String)

        list.Add("PN")
        list.Add("OB")
        list.Add("AP")
        list2.Add("P")
        list2.Add("PA")

        Dim consulta = (From prod In HeliosData.Cronograma
                        Where prod.fechaPago.Value.Year = AnioGeneral And prod.moneda = "1" _
                      And list2.Contains(prod.tipo) And list.Contains(prod.estado)
                        Group prod By prod.identidad, prod.tipoRazon, prod.estado, prod.fechaContable
                         Into grouping = Group
                        Select identidad, tipoRazon, estado, fechaContable,
                            Totalmn = grouping.Sum(Function(p) p.montoAutorizadoMN),
                            Totalme = grouping.Sum(Function(p) p.montoAutorizadoME)).ToList

        For Each obj In consulta
            objRecurso = New Cronograma
            objRecurso.fechaContable = obj.fechaContable
            objRecurso.montoAutorizadoMN = obj.Totalmn
            objRecurso.montoAutorizadoME = obj.Totalme
            Lista.Add(objRecurso)
        Next

        Return Lista
    End Function


    Public Function UbicarCronogramaVencidosCobro(tipoProgramado As String) As List(Of Cronograma)
        Dim cronoBE As New Cronograma
        Dim Lista As New List(Of Cronograma)
        Dim list As New List(Of String)
        Dim list2 As New List(Of String)

        list.Add("PN")
        list.Add("OB")
        list.Add("AP")
        list2.Add("C")
        list2.Add("CA")

        Dim consulta = (From prod In HeliosData.Cronograma
                        Where list.Contains(prod.estado) And list2.Contains(prod.tipo) _
                        And TruncateTime(prod.fechaPago) < TruncateTime(DateTime.Now)).ToList


        For Each i In consulta
            cronoBE = New Cronograma
            cronoBE.tipo = i.tipo
            cronoBE.montoAutorizadoMN = i.montoAutorizadoMN
            cronoBE.montoAutorizadoME = i.montoAutorizadoME
            cronoBE.glosa = i.glosa
            cronoBE.tipocambio = CDec(0.0)
            cronoBE.fechaoperacion = i.fechaoperacion
            cronoBE.fechaPago = i.fechaPago
            cronoBE.idCronograma = i.idCronograma
            cronoBE.idDocumentoRef = i.idDocumentoRef



            Lista.Add(cronoBE)
        Next

        Return Lista
    End Function

    Public Function UbicarCronogramaVencidos(tipoProgramado As String) As List(Of Cronograma)
        Dim cronoBE As New Cronograma
        Dim Lista As New List(Of Cronograma)
        Dim list As New List(Of String)
        Dim list2 As New List(Of String)

        list.Add("PN")
        list.Add("OB")
        list.Add("AP")
        list2.Add("P")
        list2.Add("PA")

        Dim consulta = (From prod In HeliosData.Cronograma
                        Where list.Contains(prod.estado) And list2.Contains(prod.tipo) _
                        And TruncateTime(prod.fechaPago) < TruncateTime(DateTime.Now)).ToList


        For Each i In consulta
            cronoBE = New Cronograma
            cronoBE.tipo = i.tipo
            cronoBE.montoAutorizadoMN = i.montoAutorizadoMN
            cronoBE.montoAutorizadoME = i.montoAutorizadoME
            cronoBE.glosa = i.glosa
            cronoBE.tipocambio = CDec(0.0)
            cronoBE.fechaoperacion = i.fechaoperacion
            cronoBE.fechaPago = i.fechaPago
            cronoBE.idCronograma = i.idCronograma
            cronoBE.idDocumentoRef = i.idDocumentoRef



            Lista.Add(cronoBE)
        Next

        Return Lista
    End Function

    Public Function GetCronogramaDetalleTipoMes(idprov As Integer, tipoRazon As String, tipoEstado As String, mes As Integer, tipoProg As String, TipoMoneda As String) As List(Of Cronograma)
        Dim cronoBE As New Cronograma
        Dim Lista As New List(Of Cronograma)

        Dim consulta = (From n In HeliosData.Cronograma
                        Join doc In HeliosData.documentocompra
                        On doc.idDocumento Equals n.idDocumentoRef
                        Where n.identidad = idprov And n.tipoRazon = tipoRazon And n.estado = tipoEstado And n.tipo = tipoProg _
                        And n.fechaPago.Value.Month = mes And n.fechaPago.Value.Year = DateTime.Now.Year And n.moneda = TipoMoneda).ToList


        For Each i In consulta
            cronoBE = New Cronograma

            cronoBE.idCronograma = i.n.idCronograma
            cronoBE.tipo = i.n.tipo
            cronoBE.identidad = i.n.identidad
            cronoBE.moneda = i.n.moneda
            cronoBE.montoAutorizadoMN = i.n.montoAutorizadoMN
            cronoBE.montoAutorizadoME = i.n.montoAutorizadoME
            cronoBE.tipoRazon = i.n.tipoRazon
            cronoBE.glosa = i.n.glosa
            cronoBE.tipocambio = i.n.tipocambio
            cronoBE.fechaoperacion = i.doc.fechaDoc
            cronoBE.fechaPago = i.n.fechaPago
            cronoBE.estado = i.n.estado
            cronoBE.idDocumentoPago = i.n.idDocumentoPago
            cronoBE.idDocumentoRef = i.n.idDocumentoRef
            cronoBE.serie = i.doc.serie
            cronoBE.nrodoc = i.doc.numeroDoc



            Lista.Add(cronoBE)
        Next

        Return Lista
    End Function

    Friend Sub ActualizarCronogramaCuota(IdCronograma As Integer?)
        Using ts As New TransactionScope

            Dim cro = HeliosData.Cronograma.Where(Function(o) o.idCronograma = IdCronograma).SingleOrDefault

            If cro IsNot Nothing Then
                Dim sumaPagosCronograma = Aggregate n In HeliosData.documentoCaja
                                             Where n.idcosto = IdCronograma
                                                 Into SumaPagos = Sum(n.montoSoles)

                If cro.montoAutorizadoMN = sumaPagosCronograma.GetValueOrDefault Then
                    cro.estado = "1"
                Else
                    cro.estado = "0"
                End If
            End If
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Function GetCronogramaTrabajo(mes As Integer, TipoMoneda As String) As List(Of Cronograma)
        Dim cronoBE As New Cronograma

        Dim Lista As New List(Of Cronograma)
        Dim list As New List(Of String)
        Dim listTipo As New List(Of String)

        list.Add("PN")
        list.Add("OB")
        list.Add("AP")
        list.Add("PG")
        listTipo.Add("P")
        listTipo.Add("PA")


        Dim consulta = (From prod In HeliosData.Cronograma
                        Where prod.fechaPago.Value.Month = mes And prod.fechaPago.Value.Year = DateTime.Now.Year _
                        And listTipo.Contains(prod.tipo) And list.Contains(prod.estado) And prod.moneda = TipoMoneda
                        Group prod By prod.tipo, prod.identidad, prod.tipoRazon, prod.estado, prod.moneda
                         Into grouping = Group
                        Select tipo, identidad, tipoRazon, estado, moneda,
                        Totalmn = grouping.Sum(Function(p) p.montoAutorizadoMN),
                        Totalme = grouping.Sum(Function(p) p.montoAutorizadoME)).ToList

        For Each i In consulta
            cronoBE = New Cronograma
            'cronoBE.idCronograma = i.idCronograma
            cronoBE.idCronograma = 0
            cronoBE.tipo = i.tipo
            cronoBE.identidad = i.identidad
            cronoBE.moneda = i.moneda
            'cronoBE.montoAutorizadoMN = i.montoAutorizadoMN
            'cronoBE.montoAutorizadoME = i.montoAutorizadoME
            cronoBE.montoAutorizadoMN = i.Totalmn
            cronoBE.montoAutorizadoME = i.Totalme
            cronoBE.tipoRazon = i.tipoRazon
            'cronoBE.glosa = i.prod.glosa
            'cronoBE.tipocambio = i.tipocambio
            'cronoBE.tipocambio = CDec(0.0)

            'cronoBE.fechaoperacion = i.fechaoperacion
            'cronoBE.fechaPago = i.fechaPago
            'cronoBE.fechaoperacion = i.prod.fechaoperacion
            'cronoBE.fechaPago = i.prod.fechaPago
            'cronoBE.estado = i.estado
            cronoBE.estado = i.estado
            'cronoBE.idDocumentoPago = i.idDocumentoPago
            'cronoBE.idDocumentoRef = i.idDocumentoRef
            cronoBE.idDocumentoPago = 0
            cronoBE.idDocumentoRef = 0



            Lista.Add(cronoBE)
        Next

        Return Lista
    End Function


    Public Function UbicarCronogramaPorEntidad(idprov As Integer, tipoprov As String) As List(Of Cronograma)
        Dim cronoBE As New Cronograma
        Dim Lista As New List(Of Cronograma)
        Dim list As New List(Of String)
        Dim listTipo As New List(Of String)

        list.Add("PN")
        list.Add("OB")
        list.Add("AP")
        listTipo.Add("P")
        listTipo.Add("PA")

        Dim consulta = (From prod In HeliosData.Cronograma
                        Where list.Contains(prod.estado) And listTipo.Contains(prod.tipo) _
                        And prod.identidad = idprov And prod.tipoRazon = tipoprov
                        Group prod By prod.identidad, prod.tipoRazon, prod.fechaContable
                         Into grouping = Group
                        Select identidad, tipoRazon, fechaContable,
                        Totalmn = grouping.Sum(Function(p) p.montoAutorizadoMN),
                        Totalme = grouping.Sum(Function(p) p.montoAutorizadoME)).ToList

        For Each i In consulta

            cronoBE = New Cronograma
            cronoBE.tipo = "P"
            cronoBE.montoAutorizadoMN = i.Totalmn
            cronoBE.montoAutorizadoME = i.Totalme
            cronoBE.fechaContable = i.fechaContable
            cronoBE.identidad = i.identidad
            cronoBE.tipoRazon = i.tipoRazon
            Lista.Add(cronoBE)

        Next

        Return Lista
    End Function


    Public Function UbicarCronogramaFecha(tipoProgramado As String, FechaInicio As Date, FechaFin As Date) As List(Of Cronograma)
        Dim cronoBE As New Cronograma
        Dim Lista As New List(Of Cronograma)
        Dim list As New List(Of String)
        Dim listTipo As New List(Of String)

        list.Add("PN")
        list.Add("OB")
        list.Add("AP")
        listTipo.Add("P")
        listTipo.Add("PA")

        Dim consulta = (From prod In HeliosData.Cronograma
                        Where list.Contains(prod.estado) And listTipo.Contains(prod.tipo) _
                        And TruncateTime(prod.fechaPago) >= FechaInicio.Date And TruncateTime(prod.fechaPago) <= FechaFin.Date
                        Group prod By prod.identidad, prod.tipoRazon
                         Into grouping = Group
                        Select identidad, tipoRazon,
                        Totalmn = grouping.Sum(Function(p) p.montoAutorizadoMN),
                        Totalme = grouping.Sum(Function(p) p.montoAutorizadoME)).ToList

        For Each i In consulta

            cronoBE = New Cronograma
            cronoBE.tipo = "P"
            cronoBE.montoAutorizadoMN = i.Totalmn
            cronoBE.montoAutorizadoME = i.Totalme
            cronoBE.glosa = ""
            cronoBE.identidad = i.identidad
            cronoBE.tipoRazon = i.tipoRazon
            cronoBE.tipocambio = CDec(0.0)
            cronoBE.fechaoperacion = DateTime.Now
            cronoBE.fechaPago = DateTime.Now
            cronoBE.idCronograma = 0
            cronoBE.idDocumentoRef = 0
            Lista.Add(cronoBE)

        Next

        Return Lista
    End Function


    Public Function GetCronogramaPagoCobroHistorial(tipoProgramado As String) As List(Of Cronograma)
        Dim cronoBE As New Cronograma
        Dim Lista As New List(Of Cronograma)
        Dim list As New List(Of String)

        list.Add("PG")
        'list.Add("OB")
        'list.Add("AP")
        'list.Add("PN")




        '(From m In HeliosData.documentoCajaDetalle
        '                 Join b In HeliosData.documentoLibroDiarioDetalle On New With {.IdDocumento = CInt(m.documentoAfectado)} Equals New With {.IdDocumento = b.IdDocumento} And New With {.secuencia = CInt(m.documentoAfectadodetalle)} Equals New With {.secuencia = b.secuencia}
        '                Join a In HeliosData.documentoLibroDiario On New With {.IdDocumento = CInt(b.IdDocumento)} Equals New With {.IdDocumento = a.IdDocumento}
        'Where()
        'a.Moneda = "1" And a.fecha.Value.Year = AnioGeneral And
        ' b.cuenta = mov.cuenta And b.tipoPago = "P"
        '                Select New With {
        '                m.montoSolesTransacc
        '                }) Into Sum(t1.montoSolesTransacc)), Decimal?)),



        'Dim consulta = (From prod In HeliosData.Cronograma _
        '                Join caja In HeliosData.documentoCajaDetalle _
        '                On prod.idDocumentoRef Equals caja.documentoAfectado
        '                Where list.Contains(prod.estado) And prod.tipo = tipoProgramado _
        '                Group prod By prod.fechaoperacion, prod.tipo, prod.glosa, prod.fechaPago  
        '                Into grouping = Group _
        '                Select tipo, glosa, fechaoperacion, fechaPago,
        '               Totalmn = grouping.Sum(Function(p) p.montoAutorizadoMN),
        '                Totalme = grouping.Sum(Function(p) p.montoAutorizadoME)).tolist

        Dim consulta = (From prod In HeliosData.Cronograma
                        Where list.Contains(prod.estado) And prod.tipo = tipoProgramado
                        Group prod By prod.fechaoperacion, prod.tipo, prod.glosa, prod.fechaPago Into grouping = Group
                        Select tipo, glosa, fechaoperacion, fechaPago,
                        Totalmn = grouping.Sum(Function(p) p.montoAutorizadoMN),
                        Totalme = grouping.Sum(Function(p) p.montoAutorizadoME)).ToList





        For Each i In consulta
            cronoBE = New Cronograma

            Dim num As Integer = Me.conteoPagos(i.tipo, i.fechaoperacion)

            If num > 0 Then
            Else
                cronoBE.tipo = i.tipo
                cronoBE.montoAutorizadoMN = i.Totalmn
                cronoBE.montoAutorizadoME = i.Totalme
                cronoBE.glosa = i.glosa
                cronoBE.tipocambio = CDec(0.0)
                cronoBE.fechaoperacion = i.fechaoperacion
                cronoBE.fechaPago = i.fechaPago
                Lista.Add(cronoBE)
            End If


        Next

        Return Lista
    End Function

    Public Function conteoPagos(tipoP As String, fechaCrono As DateTime)


        Dim list As New List(Of String)

        list.Add("OB")
        list.Add("AP")
        list.Add("PN")

        Dim ventaDetalle = (From n In HeliosData.Cronograma
                            Where n.tipo = tipoP And n.fechaoperacion = fechaCrono And list.Contains(n.estado)).Count


        Return ventaDetalle

    End Function





    Public Sub EliminarPagosProgramado(idcajapago As Integer, estadoA As String)
        Dim docbl As New documentoBL
        Dim docAfectado As Integer = 0
        Using ts As New TransactionScope

            Dim consulta = (From n In HeliosData.documentoCaja
                            Join doc In HeliosData.documentoCajaDetalle
                            On doc.idDocumento Equals n.idDocumento
                            Where n.idDocumento = idcajapago
                            ).ToList

            For Each i In consulta
                Me.UpdateEstadoPago(i.doc.documentoAfectado, i.doc.documentoAfectadodetalle)

                If Not docAfectado = i.doc.documentoAfectado Then
                    docAfectado = i.doc.documentoAfectado
                    docbl.CompraPendienteUpdate(docAfectado)
                    docbl.UpdatePendienteCronograma(docAfectado, estadoA, idcajapago)
                End If
            Next

            docbl.DeleteSingleVariableSL(idcajapago)

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub




    Public Function GetPagosxProgramacion(idprov As Integer, tipoRazsoc As String, tipoEstado As String, mes As Integer) As List(Of Cronograma)
        Dim cronoBE As New Cronograma
        Dim Lista As New List(Of Cronograma)

        'Dim consulta = (From n In HeliosData.Cronograma _
        '                Join doc In HeliosData.documentocompra _
        '                On doc.idDocumento Equals n.idDocumentoRef _
        '                Where n.identidad = idprov And n.tipoRazon = tipoRazon And n.estado = tipoEstado And n.fechaoperacion = fechaprog).ToList

        Dim consulta = (From n In HeliosData.Cronograma
                        Join doc In HeliosData.documentoCaja
                        On doc.idDocumento Equals n.idDocumentoPago
                        Where n.identidad = idprov And n.tipoRazon = tipoRazsoc And n.estado = tipoEstado And n.fechaoperacion.Value.Month = mes
                        Group n By n.identidad, n.tipo, n.moneda, n.tipoRazon, n.glosa, n.estado, n.idDocumentoPago, doc.fechaProceso Into grouping = Group
                        Select identidad, tipo, tipoRazon, glosa, moneda, estado, idDocumentoPago, fechaProceso,
                       Totalmn = grouping.Sum(Function(p) p.montoAutorizadoMN),
                       Totalme = grouping.Sum(Function(p) p.montoAutorizadoME)).ToList



        'Dim consulta = (From prod In HeliosData.Cronograma _
        '                Where prod.estado = "PN" _
        '               Group prod By prod.identidad, prod.tipo, prod.moneda, prod.tipoRazon, prod.glosa Into grouping = Group _
        '                Select identidad, tipo, tipoRazon, glosa, moneda,
        '                Totalmn = grouping.Sum(Function(p) p.montoAutorizadoMN),
        '                Totalme = grouping.Sum(Function(p) p.montoAutorizadoME)).tolist

        For Each i In consulta
            cronoBE = New Cronograma
            'cronoBE.idCronograma = i.idCronograma
            'cronoBE.idCronograma = 0
            'cronoBE.tipo = i.tipo
            'cronoBE.identidad = i.identidad
            'cronoBE.moneda = i.moneda
            cronoBE.montoAutorizadoMN = i.Totalmn
            cronoBE.montoAutorizadoME = i.Totalme
            'cronoBE.tipoRazon = i.tipoRazon
            'cronoBE.tipocambio = CDec(0.0)
            cronoBE.fechaoperacion = DateTime.Now
            cronoBE.fechaPago = i.fechaProceso
            'cronoBE.estado = i.estado
            cronoBE.idDocumentoPago = i.idDocumentoPago
            'cronoBE.idDocumentoRef = 0
            'cronoBE.serie = "0"
            cronoBE.nrodoc = i.idDocumentoPago



            Lista.Add(cronoBE)
        Next

        Return Lista
    End Function



    Public Function ObtenerMontoProgramadoAsiento(intIdRef As Integer, secuencia As Integer) As Cronograma
        Dim objItem As New Cronograma
        Dim lisT2 As New List(Of String)
        Dim monto As Decimal = CDec(0.0)
        Dim montome As Decimal = CDec(0.0)
        lisT2.Add("PN")
        lisT2.Add("OB")
        lisT2.Add("AP")

        Dim obj = (From p In HeliosData.Cronograma
                   Where p.idDocumentoRef = intIdRef And p.idDocumentoDetalleRef = secuencia And lisT2.Contains(p.estado)).ToList

        If obj.Count > 0 Then
            objItem = New Cronograma
            For Each i In obj
                monto += i.montoAutorizadoMN
                montome += i.montoAutorizadoME
            Next
            objItem.montoAutorizadoMN = monto
            objItem.montoAutorizadoME = montome
        Else
            objItem = New Cronograma
            objItem.montoAutorizadoMN = CDec(0.0)
            objItem.montoAutorizadoME = CDec(0.0)
        End If
        Return objItem
    End Function


    Public Function ObtenerMontoProgramado(intIdRef As Integer) As Cronograma
        Dim objItem As New Cronograma
        Dim lisT2 As New List(Of String)
        Dim monto As Decimal = CDec(0.0)
        Dim montome As Decimal = CDec(0.0)
        lisT2.Add("PN")
        lisT2.Add("OB")
        lisT2.Add("AP")

        Dim obj = (From p In HeliosData.Cronograma
                   Where p.idDocumentoRef = intIdRef And lisT2.Contains(p.estado)).ToList

        If obj.Count > 0 Then
            objItem = New Cronograma
            For Each i In obj
                monto += i.montoAutorizadoMN
                montome += i.montoAutorizadoME
            Next
            objItem.montoAutorizadoMN = monto
            objItem.montoAutorizadoME = montome
        Else
            objItem = New Cronograma
            objItem.montoAutorizadoMN = CDec(0.0)
            objItem.montoAutorizadoME = CDec(0.0)
        End If
        Return objItem
    End Function




    Public Sub UpdateEstadoLista(ByVal CronogramaBE As IList(Of Cronograma))
        Using ts As New TransactionScope


            For Each i In CronogramaBE
                Me.UpdateEstadoCrono(i.idCronograma, i.estado, i.idDocumentoPago)
            Next

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub UpdateEstadoCrono(idcrono As Integer, estado As String, idpago As Integer)
        Using ts As New TransactionScope
            Dim docCronograma As Cronograma = HeliosData.Cronograma.Where(Function(o) _
                                            o.idCronograma = idcrono).First()

            docCronograma.estado = estado
            docCronograma.idDocumentoPago = idpago

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub





    Public Function GetCronogramaDetalleTipoCobros(idprov As Integer, tipoRazon As String, tipoEstado As String, fechaprog As DateTime, tipomoneda As String) As List(Of Cronograma)
        Dim cronoBE As New Cronograma
        Dim Lista As New List(Of Cronograma)

        Dim consulta = (From n In HeliosData.Cronograma
                        Join doc In HeliosData.documentoventaAbarrotes
                        On doc.idDocumento Equals n.idDocumentoRef
                        Where n.identidad = idprov And n.tipoRazon = tipoRazon And n.estado = tipoEstado _
                        And n.fechaoperacion = fechaprog And n.moneda = tipomoneda).ToList



        For Each i In consulta
            cronoBE = New Cronograma
            'cronoBE.idCronograma = i.idCronograma
            cronoBE.idCronograma = i.n.idCronograma
            cronoBE.tipo = i.n.tipo
            cronoBE.identidad = i.n.identidad
            cronoBE.moneda = i.n.moneda
            cronoBE.montoAutorizadoMN = i.n.montoAutorizadoMN
            cronoBE.montoAutorizadoME = i.n.montoAutorizadoME
            cronoBE.tipoRazon = i.n.tipoRazon
            cronoBE.glosa = i.n.glosa
            cronoBE.tipocambio = i.n.tipocambio
            cronoBE.fechaoperacion = i.n.fechaoperacion
            cronoBE.fechaPago = i.n.fechaPago
            cronoBE.estado = i.n.estado
            cronoBE.idDocumentoPago = i.n.idDocumentoPago
            cronoBE.idDocumentoRef = i.n.idDocumentoRef
            cronoBE.serie = i.doc.serie
            cronoBE.nrodoc = i.doc.numeroDoc



            Lista.Add(cronoBE)
        Next

        Return Lista
    End Function


    Public Function GetCronogramaTipoAsientoMes(idprov As Integer, tipoRazon As String, tipoEstado As String, mes As Integer, tipoProg As String, tipoMoneda As String) As List(Of Cronograma)
        Dim cronoBE As New Cronograma
        Dim Lista As New List(Of Cronograma)

        Dim consulta = (From n In HeliosData.Cronograma
                        Join doc In HeliosData.documentoLibroDiario
                        On doc.idDocumento Equals n.idDocumentoRef
                        Join det In HeliosData.documentoLibroDiarioDetalle
                        On det.idDocumento Equals n.idDocumentoRef And det.secuencia Equals n.idDocumentoDetalleRef
                        Where n.identidad = idprov And n.tipoRazon = tipoRazon And n.estado = tipoEstado And n.tipo = tipoProg _
                        And n.fechaPago.Value.Month = mes And n.fechaPago.Value.Year = DateTime.Now.Year And n.moneda = tipoMoneda).ToList


        For Each i In consulta
            cronoBE = New Cronograma

            cronoBE.idCronograma = i.n.idCronograma
            cronoBE.tipo = i.n.tipo
            cronoBE.identidad = i.n.identidad
            cronoBE.moneda = i.n.moneda
            cronoBE.montoAutorizadoMN = i.n.montoAutorizadoMN
            cronoBE.montoAutorizadoME = i.n.montoAutorizadoME
            cronoBE.tipoRazon = i.n.tipoRazon
            cronoBE.glosa = i.n.glosa
            cronoBE.tipocambio = i.n.tipocambio
            cronoBE.fechaoperacion = i.doc.fecha
            cronoBE.fechaPago = i.n.fechaPago
            cronoBE.estado = i.n.estado
            cronoBE.idDocumentoPago = i.n.idDocumentoPago
            cronoBE.idDocumentoRef = i.n.idDocumentoRef
            cronoBE.idDocumentoDetalleRef = i.n.idDocumentoDetalleRef
            cronoBE.cuenta = i.det.cuenta
            cronoBE.descripcion = i.det.descripcion
            ' cronoBE.serie = i.doc.serie
            cronoBE.nrodoc = i.doc.nroDoc
            cronoBE.descripcion = i.n.descripcion



            Lista.Add(cronoBE)
        Next

        Return Lista
    End Function


    Public Function GetCronogramaDetalleTipoAsiento(idprov As Integer, tipoRazon As String, tipoEstado As String, fechaprog As DateTime, tipomoneda As String, fechaven As DateTime) As List(Of Cronograma)
        Dim cronoBE As New Cronograma
        Dim Lista As New List(Of Cronograma)

        Dim consulta = (From n In HeliosData.Cronograma
                        Join doc In HeliosData.documentoLibroDiario
                        On doc.idDocumento Equals n.idDocumentoRef
                        Where n.identidad = idprov And n.tipoRazon = tipoRazon And n.estado = tipoEstado _
                        And n.fechaoperacion = fechaprog And n.moneda = tipomoneda And n.fechaPago = fechaven).ToList

        'Dim consulta = (From prod In HeliosData.Cronograma _
        '                Where prod.estado = "PN" _
        '               Group prod By prod.identidad, prod.tipo, prod.moneda, prod.tipoRazon, prod.glosa Into grouping = Group _
        '                Select identidad, tipo, tipoRazon, glosa, moneda,
        '                Totalmn = grouping.Sum(Function(p) p.montoAutorizadoMN),
        '                Totalme = grouping.Sum(Function(p) p.montoAutorizadoME)).tolist

        For Each i In consulta
            cronoBE = New Cronograma
            'cronoBE.idCronograma = i.idCronograma
            cronoBE.idCronograma = i.n.idCronograma
            cronoBE.tipo = i.n.tipo
            cronoBE.identidad = i.n.identidad
            cronoBE.moneda = i.n.moneda
            cronoBE.montoAutorizadoMN = i.n.montoAutorizadoMN
            cronoBE.montoAutorizadoME = i.n.montoAutorizadoME
            cronoBE.tipoRazon = i.n.tipoRazon
            cronoBE.glosa = i.n.glosa
            cronoBE.tipocambio = i.n.tipocambio
            cronoBE.fechaoperacion = i.n.fechaoperacion
            cronoBE.fechaPago = i.n.fechaPago
            cronoBE.estado = i.n.estado
            cronoBE.idDocumentoPago = i.n.idDocumentoPago
            cronoBE.idDocumentoRef = i.n.idDocumentoRef
            cronoBE.idDocumentoDetalleRef = i.n.idDocumentoDetalleRef
            ' cronoBE.serie = i.doc.serie
            cronoBE.nrodoc = i.doc.nroDoc
            cronoBE.descripcion = i.n.descripcion



            Lista.Add(cronoBE)
        Next

        Return Lista
    End Function






    Public Function GetCronogramaDetalleTipo(idprov As Integer, tipoRazon As String, tipoEstado As String, fechaprog As DateTime, tipomoneda As String, fechaVen As DateTime) As List(Of Cronograma)
        Dim cronoBE As New Cronograma
        Dim Lista As New List(Of Cronograma)

        Dim consulta = (From n In HeliosData.Cronograma
                        Join doc In HeliosData.documentocompra
                        On doc.idDocumento Equals n.idDocumentoRef
                        Where n.identidad = idprov And n.tipoRazon = tipoRazon And n.estado = tipoEstado _
                        And n.fechaoperacion = fechaprog And n.moneda = tipomoneda And n.fechaPago = fechaVen).ToList

        'Dim consulta = (From prod In HeliosData.Cronograma _
        '                Where prod.estado = "PN" _
        '               Group prod By prod.identidad, prod.tipo, prod.moneda, prod.tipoRazon, prod.glosa Into grouping = Group _
        '                Select identidad, tipo, tipoRazon, glosa, moneda,
        '                Totalmn = grouping.Sum(Function(p) p.montoAutorizadoMN),
        '                Totalme = grouping.Sum(Function(p) p.montoAutorizadoME)).tolist

        For Each i In consulta
            cronoBE = New Cronograma
            'cronoBE.idCronograma = i.idCronograma
            cronoBE.idCronograma = i.n.idCronograma
            cronoBE.tipo = i.n.tipo
            cronoBE.identidad = i.n.identidad
            cronoBE.moneda = i.n.moneda
            cronoBE.montoAutorizadoMN = i.n.montoAutorizadoMN
            cronoBE.montoAutorizadoME = i.n.montoAutorizadoME
            cronoBE.tipoRazon = i.n.tipoRazon
            cronoBE.glosa = i.n.glosa
            cronoBE.tipocambio = i.n.tipocambio
            cronoBE.fechaoperacion = i.n.fechaoperacion
            cronoBE.fechaPago = i.n.fechaPago
            cronoBE.estado = i.n.estado
            cronoBE.idDocumentoPago = i.n.idDocumentoPago
            cronoBE.idDocumentoRef = i.n.idDocumentoRef
            cronoBE.serie = i.doc.serie
            cronoBE.nrodoc = i.doc.numeroDoc



            Lista.Add(cronoBE)
        Next

        Return Lista
    End Function


    Public Function GetCronogramaDetalleCobros(fechaProg As DateTime, fechaVen As DateTime) As List(Of Cronograma)
        Dim cronoBE As New Cronograma
        Dim Lista As New List(Of Cronograma)

        Dim consulta = (From n In HeliosData.Cronograma
                        Join doc In HeliosData.documentoventaAbarrotes
                        On doc.idDocumento Equals n.idDocumentoRef
                        Where n.fechaoperacion = fechaProg And n.tipo = "C" And n.fechaPago = fechaVen).ToList



        For Each i In consulta
            cronoBE = New Cronograma
            'cronoBE.idCronograma = i.idCronograma
            cronoBE.idCronograma = 0
            cronoBE.tipo = i.n.tipo
            cronoBE.identidad = i.n.identidad
            cronoBE.moneda = i.n.moneda
            cronoBE.montoAutorizadoMN = i.n.montoAutorizadoMN
            cronoBE.montoAutorizadoME = i.n.montoAutorizadoME
            cronoBE.tipoRazon = i.n.tipoRazon
            cronoBE.glosa = i.n.glosa
            cronoBE.tipocambio = i.n.tipocambio
            cronoBE.fechaoperacion = i.n.fechaoperacion
            cronoBE.fechaPago = i.n.fechaPago
            cronoBE.estado = i.n.estado
            cronoBE.idDocumentoPago = i.n.idDocumentoPago
            cronoBE.idDocumentoRef = i.n.idDocumentoRef
            cronoBE.serie = i.doc.serie
            cronoBE.nrodoc = i.doc.numeroDoc



            Lista.Add(cronoBE)
        Next

        Return Lista
    End Function


    Public Function GetCronogramaDetalleAsiento(fechaProg As DateTime) As List(Of Cronograma)
        Dim cronoBE As New Cronograma
        Dim Lista As New List(Of Cronograma)

        Dim consulta = (From n In HeliosData.Cronograma
                        Join doc In HeliosData.documentoLibroDiario
                        On doc.idDocumento Equals n.idDocumentoRef
                        Where n.fechaoperacion = fechaProg And n.tipo = "PA").ToList


        'Dim consulta = (From prod In HeliosData.Cronograma _
        '                Where prod.estado = "PN" _
        '               Group prod By prod.identidad, prod.tipo, prod.moneda, prod.tipoRazon, prod.glosa Into grouping = Group _
        '                Select identidad, tipo, tipoRazon, glosa, moneda,
        '                Totalmn = grouping.Sum(Function(p) p.montoAutorizadoMN),
        '                Totalme = grouping.Sum(Function(p) p.montoAutorizadoME)).tolist




        For Each i In consulta
            cronoBE = New Cronograma
            'cronoBE.idCronograma = i.idCronograma
            cronoBE.idCronograma = 0
            cronoBE.tipo = i.n.tipo
            cronoBE.identidad = i.n.identidad
            cronoBE.moneda = i.n.moneda
            cronoBE.montoAutorizadoMN = i.n.montoAutorizadoMN
            cronoBE.montoAutorizadoME = i.n.montoAutorizadoME
            cronoBE.tipoRazon = i.n.tipoRazon
            cronoBE.glosa = i.n.glosa
            cronoBE.tipocambio = i.n.tipocambio
            cronoBE.fechaoperacion = i.n.fechaoperacion
            cronoBE.fechaPago = i.n.fechaPago
            cronoBE.estado = i.n.estado
            cronoBE.idDocumentoPago = i.n.idDocumentoPago
            cronoBE.idDocumentoRef = i.n.idDocumentoRef
            cronoBE.nrodoc = i.doc.nroDoc
            cronoBE.descripcion = i.n.descripcion




            Lista.Add(cronoBE)
        Next

        Return Lista
    End Function




    Public Function GetCronogramaDetalle(fechaProg As DateTime, fechaVen As DateTime) As List(Of Cronograma)
        Dim cronoBE As New Cronograma
        Dim Lista As New List(Of Cronograma)

        Dim consulta = (From n In HeliosData.Cronograma
                        Join doc In HeliosData.documentocompra
                        On doc.idDocumento Equals n.idDocumentoRef
                        Where n.fechaoperacion = fechaProg And n.fechaPago = fechaVen And n.tipo = "P").ToList


        'Dim consulta = (From prod In HeliosData.Cronograma _
        '                Where prod.estado = "PN" _
        '               Group prod By prod.identidad, prod.tipo, prod.moneda, prod.tipoRazon, prod.glosa Into grouping = Group _
        '                Select identidad, tipo, tipoRazon, glosa, moneda,
        '                Totalmn = grouping.Sum(Function(p) p.montoAutorizadoMN),
        '                Totalme = grouping.Sum(Function(p) p.montoAutorizadoME)).tolist




        For Each i In consulta
            cronoBE = New Cronograma
            'cronoBE.idCronograma = i.idCronograma
            cronoBE.idCronograma = 0
            cronoBE.tipo = i.n.tipo
            cronoBE.identidad = i.n.identidad
            cronoBE.moneda = i.n.moneda
            cronoBE.montoAutorizadoMN = i.n.montoAutorizadoMN
            cronoBE.montoAutorizadoME = i.n.montoAutorizadoME
            cronoBE.tipoRazon = i.n.tipoRazon
            cronoBE.glosa = i.n.glosa
            cronoBE.tipocambio = i.n.tipocambio
            cronoBE.fechaoperacion = i.n.fechaoperacion
            cronoBE.fechaPago = i.n.fechaPago
            cronoBE.estado = i.n.estado
            cronoBE.idDocumentoPago = i.n.idDocumentoPago
            cronoBE.idDocumentoRef = i.n.idDocumentoRef
            cronoBE.serie = i.doc.serie
            cronoBE.nrodoc = i.doc.numeroDoc



            Lista.Add(cronoBE)
        Next

        Return Lista
    End Function



    Public Sub UpdateEstadoDeletCobro(ByVal CronogramaBE As Cronograma, ByVal iddocpago As Integer)
        Dim documentobl As New documentoBL

        Using ts As New TransactionScope
            Dim docCronograma As Cronograma = HeliosData.Cronograma.Where(Function(o) _
                                            o.idCronograma = CronogramaBE.idCronograma).First()


            Me.updateCobroVenta(iddocpago)
            documentobl.DeleteSingleVariableSL(iddocpago)
            docCronograma.estado = CronogramaBE.estado
            docCronograma.idDocumentoPago = CronogramaBE.idDocumentoPago

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    'busquda de cobro
    Public Sub updateCobroVenta(idcajapago As Integer)
        Dim docbl As New documentoBL
        Dim consulta = (From n In HeliosData.documentoCaja
                        Join doc In HeliosData.documentoCajaDetalle
                        On doc.idDocumento Equals n.idDocumento
                        Where n.idDocumento = idcajapago
                        ).ToList

        For Each i In consulta
            Me.UpdateEstadoCobro(i.doc.documentoAfectado, i.doc.documentoAfectadodetalle)
            docbl.VentaSaldadaDocs(i.doc.documentoAfectado)
        Next

    End Sub
    'cambio documento venta
    Public Sub UpdateEstadoCobro(iddocumento As Integer, idsecuencia As Integer)
        Using ts As New TransactionScope
            Dim docCronograma As documentoventaAbarrotesDet = HeliosData.documentoventaAbarrotesDet.Where(Function(o) _
                                            o.idDocumento = iddocumento And o.secuencia = idsecuencia).First()

            docCronograma.estadoPago = "PN"


            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub




    Public Sub UpdateEstadoDeletPago(ByVal CronogramaBE As Cronograma, ByVal iddocpago As Integer)
        Dim documentobl As New documentoBL

        Using ts As New TransactionScope
            Dim docCronograma As Cronograma = HeliosData.Cronograma.Where(Function(o) _
                                            o.idCronograma = CronogramaBE.idCronograma).First()

            Me.updatepagoscompra(iddocpago)
            documentobl.DeleteSingleVariableSL(iddocpago)
            docCronograma.estado = CronogramaBE.estado
            docCronograma.idDocumentoPago = CronogramaBE.idDocumentoPago

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    ''busqueda de pagos
    Public Sub updatepagoscompra(idcajapago As Integer)
        Dim docbl As New documentoBL

        Dim consulta = (From n In HeliosData.documentoCaja
                        Join doc In HeliosData.documentoCajaDetalle
                        On doc.idDocumento Equals n.idDocumento
                        Where n.idDocumento = idcajapago
                        ).ToList

        For Each i In consulta
            Me.UpdateEstadoPago(i.doc.documentoAfectado, i.doc.documentoAfectadodetalle)
            docbl.CompraSaldadaDocs(i.doc.documentoAfectado)
        Next

    End Sub
    'cambio estado
    Public Sub UpdateEstadoPago(iddocumento As Integer, idsecuencia As Integer)
        Using ts As New TransactionScope
            Dim docCronograma As documentocompradetalle = HeliosData.documentocompradetalle.Where(Function(o) _
                                            o.idDocumento = iddocumento And o.secuencia = idsecuencia).First()

            docCronograma.estadoPago = "PN"


            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub


    '''3444
    Public Sub UpdateEstado(ByVal CronogramaBE As Cronograma)
        Using ts As New TransactionScope
            Dim docCronograma As Cronograma = HeliosData.Cronograma.Where(Function(o) _
                                            o.idCronograma = CronogramaBE.idCronograma).First()

            docCronograma.estado = CronogramaBE.estado
            docCronograma.idDocumentoPago = CronogramaBE.idDocumentoPago

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub



    Public Function GetCronogramaPendiente() As List(Of Cronograma)
        Dim cronoBE As New Cronograma
        Dim Lista As New List(Of Cronograma)

        Dim consulta = (From n In HeliosData.Cronograma
                        Where n.estado = "PN"
                        ).ToList

        For Each i In consulta
            cronoBE = New Cronograma
            cronoBE.idCronograma = i.idCronograma
            cronoBE.tipo = i.tipo
            cronoBE.identidad = i.identidad
            cronoBE.montoAutorizadoMN = i.montoAutorizadoMN
            cronoBE.montoAutorizadoME = i.montoAutorizadoME
            cronoBE.tipoRazon = i.tipoRazon
            cronoBE.glosa = i.glosa
            cronoBE.fechaoperacion = i.fechaoperacion
            Lista.Add(cronoBE)
        Next

        Return Lista
    End Function



    Public Sub UpdateHijoCronograma(ByVal CronogramaBE As Cronograma)
        Using ts As New TransactionScope
            Dim docCronograma As Cronograma = HeliosData.Cronograma.Where(Function(o) _
                                            o.idCronograma = CronogramaBE.idCronograma).First()

            docCronograma.montoAutorizadoMN = CronogramaBE.montoAutorizadoMN
            docCronograma.fechaPago = CronogramaBE.fechaPago
            docCronograma.montoAutorizadoME = CronogramaBE.montoAutorizadoME
            'docCronograma.montoAutorizadoME = CronogramaBE.montoAutorizadoME

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub




    Public Sub DeleteCronoHijo(ByVal intIdCronograma As Integer)
        Using ts As New TransactionScope

            Dim consulta As Cronograma = HeliosData.Cronograma.Where(Function(o) o.idCronograma = intIdCronograma).FirstOrDefault
            CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(consulta)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub



    Public Function GetCronogramaTotalesTipo(fechaprog As DateTime, tipoprog As String, fechaVen As DateTime) As List(Of Cronograma)
        Dim cronoBE As New Cronograma
        Dim Lista As New List(Of Cronograma)

        'Dim consulta = (From n In HeliosData.Cronograma _
        '                ).ToList


        Dim consulta = (From prod In HeliosData.Cronograma
                        Where prod.fechaoperacion = fechaprog And prod.tipo = tipoprog And prod.fechaPago = fechaVen
                        Group prod By prod.identidad, prod.tipo, prod.moneda, prod.tipoRazon, prod.glosa, prod.estado, prod.fechaoperacion, prod.fechaPago Into grouping = Group
                        Select identidad, tipo, tipoRazon, glosa, moneda, estado, fechaoperacion, fechaPago,
                        Totalmn = grouping.Sum(Function(p) p.montoAutorizadoMN),
                        Totalme = grouping.Sum(Function(p) p.montoAutorizadoME)).ToList

        For Each i In consulta
            cronoBE = New Cronograma
            'cronoBE.idCronograma = i.idCronograma
            cronoBE.idCronograma = 0
            cronoBE.tipo = i.tipo
            cronoBE.identidad = i.identidad
            cronoBE.moneda = i.moneda
            'cronoBE.montoAutorizadoMN = i.montoAutorizadoMN
            'cronoBE.montoAutorizadoME = i.montoAutorizadoME
            cronoBE.montoAutorizadoMN = i.Totalmn
            cronoBE.montoAutorizadoME = i.Totalme
            cronoBE.tipoRazon = i.tipoRazon
            cronoBE.glosa = i.glosa
            'cronoBE.tipocambio = i.tipocambio
            cronoBE.tipocambio = CDec(0.0)

            'cronoBE.fechaoperacion = i.fechaoperacion
            'cronoBE.fechaPago = i.fechaPago
            cronoBE.fechaoperacion = i.fechaoperacion
            cronoBE.fechaPago = i.fechaPago
            'cronoBE.estado = i.estado
            cronoBE.estado = i.estado
            'cronoBE.idDocumentoPago = i.idDocumentoPago
            'cronoBE.idDocumentoRef = i.idDocumentoRef
            cronoBE.idDocumentoPago = 0
            cronoBE.idDocumentoRef = 0


            Lista.Add(cronoBE)
        Next

        Return Lista
    End Function




    Public Function GetCronogramaPagoCobro(tipoProgramado As String) As List(Of Cronograma)
        Dim cronoBE As New Cronograma
        Dim Lista As New List(Of Cronograma)
        Dim list As New List(Of String)

        list.Add("PN")
        list.Add("OB")
        list.Add("AP")

        Dim consulta = (From prod In HeliosData.Cronograma
                        Where list.Contains(prod.estado) And prod.tipo = tipoProgramado
                        Group prod By prod.fechaoperacion, prod.tipo, prod.glosa, prod.fechaPago Into grouping = Group
                        Select tipo, glosa, fechaoperacion, fechaPago,
                        Totalmn = grouping.Sum(Function(p) p.montoAutorizadoMN),
                        Totalme = grouping.Sum(Function(p) p.montoAutorizadoME)).ToList


        For Each i In consulta
            cronoBE = New Cronograma
            cronoBE.tipo = i.tipo
            cronoBE.montoAutorizadoMN = i.Totalmn
            cronoBE.montoAutorizadoME = i.Totalme
            cronoBE.glosa = i.glosa
            cronoBE.tipocambio = CDec(0.0)
            cronoBE.fechaoperacion = i.fechaoperacion
            cronoBE.fechaPago = i.fechaPago



            Lista.Add(cronoBE)
        Next

        Return Lista
    End Function

    Public Function GetCronograma() As List(Of Cronograma)
        Dim cronoBE As New Cronograma
        Dim Lista As New List(Of Cronograma)
        Dim list As New List(Of String)


        list.Add("PN")
        list.Add("OB")
        list.Add("AP")



        'Dim consulta = (From n In HeliosData.Cronograma _
        '                ).ToList


        'Dim consulta = (From prod In HeliosData.Cronograma _
        '                Where prod.estado = "PN" _
        '               Group prod By prod.identidad, prod.tipo, prod.moneda, prod.tipoRazon, prod.glosa Into grouping = Group _
        '                Select identidad, tipo, tipoRazon, glosa, moneda,
        '                Totalmn = grouping.Sum(Function(p) p.montoAutorizadoMN),
        '                Totalme = grouping.Sum(Function(p) p.montoAutorizadoME)).tolist


        '2222:
        'Dim consulta = (From prod In HeliosData.Cronograma _
        '               Group prod By prod.identidad, prod.tipo, prod.moneda, prod.tipoRazon, prod.glosa Into grouping = Group _
        '                Select identidad, tipo, tipoRazon, glosa, moneda,
        '                Totalmn = grouping.Sum(Function(p) p.montoAutorizadoMN),
        '                Totalme = grouping.Sum(Function(p) p.montoAutorizadoME)).tolist

        'Dim consulta = (From prod In HeliosData.Cronograma _
        '                Where list.Contains(prod.estado) _
        '               Group prod By prod.fechaoperacion, prod.tipo, prod.moneda, prod.glosa, prod.fechaPago Into grouping = Group _
        '                Select tipo, glosa, moneda, fechaoperacion, fechaPago,
        '                Totalmn = grouping.Sum(Function(p) p.montoAutorizadoMN),
        '                Totalme = grouping.Sum(Function(p) p.montoAutorizadoME)).tolist
        Dim consulta = (From prod In HeliosData.Cronograma
                        Where list.Contains(prod.estado)
                        Group prod By prod.fechaoperacion, prod.tipo, prod.glosa, prod.fechaPago Into grouping = Group
                        Select tipo, glosa, fechaoperacion, fechaPago,
                        Totalmn = grouping.Sum(Function(p) p.montoAutorizadoMN),
                        Totalme = grouping.Sum(Function(p) p.montoAutorizadoME)).ToList


        For Each i In consulta
            cronoBE = New Cronograma
            'cronoBE.idCronograma = i.idCronograma
            ' cronoBE.idCronograma = 0
            cronoBE.tipo = i.tipo
            ' cronoBE.identidad = i.identidad
            'cronoBE.moneda = i.moneda
            'cronoBE.montoAutorizadoMN = i.montoAutorizadoMN
            'cronoBE.montoAutorizadoME = i.montoAutorizadoME
            cronoBE.montoAutorizadoMN = i.Totalmn
            cronoBE.montoAutorizadoME = i.Totalme
            ' cronoBE.tipoRazon = i.tipoRazon
            cronoBE.glosa = i.glosa
            'cronoBE.tipocambio = i.tipocambio
            cronoBE.tipocambio = CDec(0.0)

            'cronoBE.fechaoperacion = i.fechaoperacion
            'cronoBE.fechaPago = i.fechaPago
            cronoBE.fechaoperacion = i.fechaoperacion
            cronoBE.fechaPago = i.fechaPago
            'cronoBE.estado = i.estado
            'cronoBE.estado = "PN"
            'cronoBE.idDocumentoPago = i.idDocumentoPago
            'cronoBE.idDocumentoRef = i.idDocumentoRef
            'cronoBE.idDocumentoPago = 0
            'cronoBE.idDocumentoRef = 0


            Lista.Add(cronoBE)
        Next

        Return Lista
    End Function





    Public Sub InsertCronograma(ByVal cronogramaBE As List(Of Cronograma))
        Dim docCronograma As New Cronograma

        Using ts As New TransactionScope
            For Each i In cronogramaBE

                docCronograma = New Cronograma
                docCronograma.tipo = i.tipo
                docCronograma.fechaoperacion = i.fechaoperacion
                docCronograma.fechaPago = i.fechaPago

                docCronograma.fechaContable = String.Format("{0:00}", i.fechaPago.Value.Month) & "/" & i.fechaPago.Value.Year
                'docCronograma.fechaContable = PeriodoGeneral

                docCronograma.identidad = i.identidad.GetValueOrDefault
                docCronograma.moneda = i.moneda
                docCronograma.tipocambio = i.tipocambio
                docCronograma.montoAutorizadoMN = i.montoAutorizadoMN
                docCronograma.montoAutorizadoME = i.montoAutorizadoME
                docCronograma.usuarioActualizacion = i.usuarioActualizacion
                docCronograma.usuarioResponssable = i.usuarioResponssable

                docCronograma.tipoRazon = i.tipoRazon
                docCronograma.glosa = i.glosa
                docCronograma.autorizacion = "N"
                docCronograma.estado = "PN"
                docCronograma.idDocumentoPago = i.idDocumentoPago
                docCronograma.idDocumentoRef = i.idDocumentoRef

                If i.glosa = "PAGO ASIENTO MANUAL" Then

                    docCronograma.idDocumentoDetalleRef = i.idDocumentoDetalleRef
                    docCronograma.descripcion = i.descripcion
                    docCronograma.cuenta = i.cuenta
                ElseIf i.glosa = "COBRO ASIENTO MANUAL" Then
                    docCronograma.idDocumentoDetalleRef = i.idDocumentoDetalleRef
                    docCronograma.descripcion = i.descripcion
                    docCronograma.cuenta = i.cuenta

                End If


                HeliosData.Cronograma.Add(docCronograma)
            Next

            HeliosData.SaveChanges()
            ts.Complete()
            '   documentocompraBE.idDocumento = docCompra.idDocumento
        End Using
    End Sub


End Class
