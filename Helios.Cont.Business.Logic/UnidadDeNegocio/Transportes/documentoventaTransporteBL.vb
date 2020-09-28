Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports System.Data.Entity.DbFunctions
Imports System.Data.Entity
Imports System.Data.Entity.Migrations

Public Class documentoventaTransporteBL
    Inherits BaseBL


    Public Sub UpdateAnulacionEnviada(objDocumento As Integer, idNum As Integer, nroTicket As String)

        Try
            Using ts As New TransactionScope()
                Dim documento As documentoventaTransporte = HeliosData.documentoventaTransporte.Where(Function(o) _
                                            o.idDocumento = objDocumento).First()

                documento.EnvioSunat = "SI"
                'documento.ticketElectronico = nroTicket
                'documento.numeracionElectronica = idNum

                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Sub ReenviarDocumentoEliminado(idDocumento As Integer, idPse As String)
        Try
            Dim venta = HeliosData.documentoventaTransporte.Where(Function(o) o.idDocumento = idDocumento).FirstOrDefault

            Using ts As New TransactionScope
                venta.estadoCobro = "ANU"
                If venta.tipoVenta = "ENDAS" Then
                    If venta.EnvioSunat = "PE" Then  ' SI HA SIDO ENVIADO Y ELIMANDO
                        venta.EnvioSunat = "PE"
                        If idPse > 0 Then
                            venta.idPSE = idPse
                            If My.Computer.Network.IsAvailable = True Then
                                If My.Computer.Network.Ping("148.102.27.231") Then
                                    If venta.tipoDocumento = "01" Then
                                        Dim estado = ComunicacionBajaFactura(venta)
                                        venta.EnvioSunat = estado
                                    ElseIf venta.tipoDocumento = "03" Then
                                        Dim estado = EnviarBoletaEliminada(venta)
                                        venta.EnvioSunat = estado
                                    End If
                                End If
                            End If
                        End If

                    End If
                End If

                venta.usuarioActualizacion = venta.usuarioActualizacion
                venta.fechaActualizacion = DateTime.Now
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Sub ListaEnvioSunatAnuladosTrans(lista As List(Of documentoventaTransporte), nroTicket As String, idNum As Integer)

        Dim numeracionBL As New numeracionBoletasBL
        Dim cval As Integer = 0
        Try

            Using ts As New TransactionScope()

                cval = numeracionBL.GenerarNumeroPorID(idNum)

                For Each i In lista
                    Me.UpdateEnvioSunatResumen(i.idDocumento, cval, nroTicket)
                Next



                HeliosData.SaveChanges()
                ts.Complete()
            End Using

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub UpdateEnvioSunatResumen(objDocumento As Integer, idNum As Integer, nroTicket As String)

        Try
            Using ts As New TransactionScope()
                Dim documento As documentoventaTransporte = HeliosData.documentoventaTransporte.Where(Function(o) _
                                            o.idDocumento = objDocumento).First()

                documento.EnvioSunat = "SI"


                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Sub ListaEnvioSunatResumenTrans(lista As List(Of documentoventaTransporte), idNum As Integer, nroTicket As String)

        Dim numeracionBL As New numeracionBoletasBL
        Dim cval As Integer = 0
        Try

            Using ts As New TransactionScope()

                cval = numeracionBL.GenerarNumeroPorID(idNum)

                For Each i In lista
                    Me.UpdateEnvioSunatResumenTrans(i.idDocumento, cval, nroTicket)
                Next




                HeliosData.SaveChanges()
                ts.Complete()
            End Using

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub UpdateEnvioSunatResumenTrans(objDocumento As Integer, idNum As Integer, nroTicket As String)

        Try
            Using ts As New TransactionScope()
                Dim documento As documentoventaTransporte = HeliosData.documentoventaTransporte.Where(Function(o) _
                                            o.idDocumento = objDocumento).First()

                documento.EnvioSunat = "SI"


                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Function GetResumenVentasSelCajero(be As documentoCaja) As documentoCaja
        Dim con = (From DocumentoCaja In HeliosData.documentoCaja
                   Where
                     DocumentoCaja.movimientoCaja = be.movimientoCaja And
                     CLng(DocumentoCaja.idCajaUsuario) = be.idCajaUsuario
                   Group DocumentoCaja By DocumentoCaja.movimientoCaja Into g = Group
                   Select
                     movimientoCaja,
                     TotalEncomiendas = CType(g.Sum(Function(p) p.montoSoles), Decimal?)).FirstOrDefault

        GetResumenVentasSelCajero = New documentoCaja
        If con IsNot Nothing Then
            GetResumenVentasSelCajero.movimientoCaja = con.movimientoCaja
            GetResumenVentasSelCajero.montoSoles = con.TotalEncomiendas.GetValueOrDefault
        End If

    End Function


    Function BuscarDocumentosAnuladosPeriodoTrans(fecha As DateTime, tipoDoc As String, ruc As String) As List(Of documentoventaTransporte)

        'Dim consulta = (From i In HeliosData.documentoventaAbarrotes
        '                Where TruncateTime(i.fechaDoc) = fecha.Date And i.tipoDocumento = tipoDoc And i.tipoVenta = "VPOS" _
        '                    And Not i.EnvioSunat = "SI" And i.idEmpresa = ruc And i.estadoCobro = "ANU" And Not i.EnvioSunat = "VA").ToList

        Dim consulta = (From i In HeliosData.documentoventaTransporte
                        Where i.fechadoc.Value.Year = fecha.Year And
                            i.fechadoc.Value.Month = fecha.Month _
                            And i.tipoDocumento = tipoDoc And i.tipoVenta = General.TIPO_VENTA.VENTA_ENCOMIENDAS _
                            And i.EnvioSunat = "PE" And i.idEmpresa = ruc And i.estado = General.Transporte.EncomiendaEstado.Anulado).ToList

        Return consulta
    End Function


    Function BuscarDocumentosAnuladosFechaTrans(fecha As DateTime, tipoDoc As String, ruc As String) As List(Of documentoventaTransporte)

        'Dim consulta = (From i In HeliosData.documentoventaAbarrotes
        '                Where TruncateTime(i.fechaDoc) = fecha.Date And i.tipoDocumento = tipoDoc And i.tipoVenta = "VPOS" _
        '                    And Not i.EnvioSunat = "SI" And i.idEmpresa = ruc And i.estadoCobro = "ANU" And Not i.EnvioSunat = "VA").ToList

        Dim consulta = (From i In HeliosData.documentoventaTransporte
                        Where TruncateTime(i.fechadoc) = fecha.Date And i.tipoDocumento = tipoDoc And i.tipoVenta = General.TIPO_VENTA.VENTA_ENCOMIENDAS _
                            And i.EnvioSunat = "PE" And i.idEmpresa = ruc And i.estado = General.Transporte.EncomiendaEstado.Anulado).ToList

        Return consulta
    End Function

    Function BuscarBoletasAnuladasPeriodoTrans(fecha As DateTime, IdEmpresa As String) As List(Of documentoventaTransporte)

        Dim objeto As documentoventaTransporte
        Dim lista As New List(Of documentoventaTransporte)

        Dim consulta = (From i In HeliosData.documentoventaTransporte
                        Join x In HeliosData.entidad On i.razonSocial Equals x.idEntidad
                        Where i.fechadoc.Value.Year = fecha.Year _
                            And i.fechadoc.Value.Month = fecha.Month _
                         And i.tipoDocumento = "03" And i.tipoVenta = General.TIPO_VENTA.VENTA_ENCOMIENDAS And i.EnvioSunat = "PE" And i.estado = General.Transporte.EncomiendaEstado.Anulado _
                            And i.idEmpresa = IdEmpresa
                        Select
                                idDoc = i.idDocumento,
                            fechadoc = i.fechadoc,
                                tipodDoc = i.tipoDocumento,
                                serie = i.serie,
                            numero = i.numero,
                            nrodoc = x.nrodoc,
                            tipDocClie = x.tipoDoc,
                            moneda = i.moneda,
                            gravada = i.baseImponible1,
                            exonerada = i.baseImponible2,
                            igv = i.igv1,
                            importe = i.total).Take(250)

        For Each i In consulta

            objeto = New documentoventaTransporte
            objeto.idDocumento = i.idDoc
            objeto.tipoDocumento = i.tipodDoc
            objeto.serie = i.serie
            objeto.numero = i.numero
            objeto.nrodoc = i.nrodoc
            objeto.tipDocClie = i.tipDocClie
            objeto.moneda = i.moneda
            objeto.baseImponible1 = i.gravada
            objeto.baseImponible2 = i.exonerada.GetValueOrDefault
            objeto.igv1 = i.igv
            objeto.total = i.importe
            objeto.fechadoc = i.fechadoc


            lista.Add(objeto)
        Next

        Return lista

    End Function


    Function BuscarBoletasAnuladasTrans(fecha As DateTime, IdEmpresa As String) As List(Of documentoventaTransporte)

        Dim objeto As documentoventaTransporte
        Dim lista As New List(Of documentoventaTransporte)

        Dim consulta = (From i In HeliosData.documentoventaTransporte
                        Join x In HeliosData.entidad On i.razonSocial Equals x.idEntidad
                        Where TruncateTime(i.fechadoc) = fecha.Date _
                         And i.tipoDocumento = "03" And i.tipoVenta = General.TIPO_VENTA.VENTA_ENCOMIENDAS And i.EnvioSunat = "PE" And i.estado = General.Transporte.EncomiendaEstado.Anulado _
                            And i.idEmpresa = IdEmpresa
                        Select
                                idDoc = i.idDocumento,
                                tipodDoc = i.tipoDocumento,
                                serie = i.serie,
                            numero = i.numero,
                            nrodoc = x.nrodoc,
                            tipDocClie = x.tipoDoc,
                            moneda = i.moneda,
                            gravada = i.baseImponible1,
                            exonerada = i.baseImponible2,
                            igv = i.igv1,
                            importe = i.total).Take(250)

        For Each i In consulta

            objeto = New documentoventaTransporte
            objeto.idDocumento = i.idDoc
            objeto.tipoDocumento = i.tipodDoc
            objeto.serie = i.serie
            objeto.numero = i.numero
            objeto.nrodoc = i.nrodoc
            objeto.tipDocClie = i.tipDocClie
            objeto.moneda = i.moneda
            objeto.baseImponible1 = i.gravada
            objeto.baseImponible2 = i.exonerada.GetValueOrDefault
            objeto.igv1 = i.igv
            objeto.total = i.importe


            lista.Add(objeto)
        Next

        Return lista

    End Function


    Function BuscarFacturanoEnviadasTrans(fecha As DateTime, tipoDoc As String, idEmpresa As String) As List(Of documentoventaTransporte)

        Dim objeto As documentoventaTransporte
        Dim lista As New List(Of documentoventaTransporte)

        Dim list As New List(Of String)

        list.Add("VA") 'envio anulado y validado
        list.Add("PE")  'enviado anulado 
        list.Add("SI") 'enviado sin anular

        If tipoDoc = "01" Then

            'Dim consulta = (From i In HeliosData.documentoventaAbarrotes
            '                Where TruncateTime(i.fechaDoc) = fecha.Date And i.tipoDocumento = tipoDoc And i.tipoVenta = "VPOS" And Not i.EnvioSunat = "SI" And Not i.estadoCobro = "ANU" And Not i.EnvioSunat = "VA").ToList

            Dim consulta = (From i In HeliosData.documentoventaTransporte
                            Where TruncateTime(i.fechadoc) = fecha.Date And i.tipoDocumento = tipoDoc And i.tipoVenta = General.TIPO_VENTA.VENTA_ENCOMIENDAS And Not i.EnvioSunat = "SI" And Not i.EnvioSunat = "VA" And Not i.EnvioSunat = "PE" And i.idEmpresa = idEmpresa).ToList

            Return consulta

        ElseIf tipoDoc = "07" Then

            'Dim consulta = (From i In HeliosData.documentoventaAbarrotes
            '                Join x In HeliosData.documentoventaAbarrotes On i.idPadre Equals x.idDocumento
            '                Where TruncateTime(i.fechaDoc) = fecha.Date And i.tipoDocumento = tipoDoc And i.tipoVenta = "NTCE" And Not i.EnvioSunat = "SI" And x.tipoDocumento = "01" And
            '                    i.idEmpresa = idEmpresa And x.tipoVenta = "VELC" And
            '                    list.Contains(x.EnvioSunat)
            '                Select i).ToList
            'Return consulta


        ElseIf tipoDoc = "03" Then

            Dim consulta = (From i In HeliosData.documentoventaTransporte
                            Join x In HeliosData.entidad On i.razonSocial Equals x.idEntidad
                            Where TruncateTime(i.fechadoc) = fecha.Date And i.tipoDocumento = tipoDoc And i.tipoVenta = General.TIPO_VENTA.VENTA_ENCOMIENDAS And Not i.EnvioSunat = "SI" And Not i.EnvioSunat = "VA" And
                                Not General.Transporte.EncomiendaEstado.Anulado And i.idEmpresa = idEmpresa
                            Select
                                    idDoc = i.idDocumento,
                                    tipodDoc = i.tipoDocumento,
                                    serie = i.serie,
                                numero = i.numero,
                                nrodoc = x.nrodoc,
                                tipDocClie = x.tipoDoc,
                                moneda = i.moneda,
                                gravada = i.baseImponible1,
                                exonerada = i.baseImponible2,
                                igv = i.igv1,
                                importe = i.total).Take(250)

            For Each i In consulta

                objeto = New documentoventaTransporte
                objeto.idDocumento = i.idDoc
                objeto.tipoDocumento = i.tipodDoc
                objeto.serie = i.serie
                objeto.numero = i.numero
                objeto.nrodoc = i.nrodoc
                objeto.tipDocClie = i.tipDocClie
                objeto.moneda = i.moneda
                objeto.baseImponible1 = i.gravada
                objeto.baseImponible2 = i.exonerada.GetValueOrDefault
                objeto.igv1 = i.igv
                objeto.total = i.importe


                lista.Add(objeto)
            Next

            Return lista

        End If




    End Function


    Function ListaCpePendientesDeEnvioTransporte(fecha As DateTime, idEmpresa As String) As List(Of documentoventaTransporte)

        '  Dim objeto As documentoventaAbarrotes
        Dim lista As New List(Of documentoventaTransporte)

        Dim list As New List(Of String)

        list.Add("VELC") 'envio anulado y validado
        list.Add("NTCE")  'enviado anulado 


        Dim listaTransporte As New List(Of String)
        listaTransporte.Add(General.TIPO_VENTA.VENTA_ENCOMIENDAS)
        listaTransporte.Add(General.TIPO_VENTA.VENTA_PASAJES)

        lista = (From i In HeliosData.documentoventaTransporte
                 Where i.fechadoc.Value.Year = fecha.Year And i.fechadoc.Value.Month = fecha.Month And
                              listaTransporte.Contains(i.tipoVenta) And Not i.EnvioSunat = "SI" And Not i.EnvioSunat = "VA" _
                                And Not i.EnvioSunat = "PE" And i.idEmpresa = idEmpresa).ToList
        Return lista
    End Function


    Function DocumentosAnuladosPendientesTransporte(fecha As DateTime, ruc As String) As List(Of documentoventaTransporte)

        Dim listaTransporte As New List(Of String)

        listaTransporte.Add(General.TIPO_VENTA.VENTA_ENCOMIENDAS)
        listaTransporte.Add(General.TIPO_VENTA.VENTA_PASAJES)

        Dim consulta = (From i In HeliosData.documentoventaTransporte
                        Where i.fechadoc.Value.Year = fecha.Year And
                             i.fechadoc.Value.Month = fecha.Month And
                            listaTransporte.Contains(i.tipoVenta) And i.EnvioSunat = "PE" And
                            i.idEmpresa = ruc And i.estadoCobro = "ANU").ToList

        Return consulta
    End Function


    Function BuscarFacturanoEnviadasPeriodoTrans(fecha As DateTime, tipoDoc As String, idEmpresa As String) As List(Of documentoventaTransporte)

        Dim objeto As documentoventaTransporte
        Dim lista As New List(Of documentoventaTransporte)

        Dim list As New List(Of String)

        list.Add("VA") 'envio anulado y validado
        list.Add("PE")  'enviado anulado 
        list.Add("SI") 'enviado sin anular

        If tipoDoc = "01" Or tipoDoc = "03" Then

            'Dim consulta = (From i In HeliosData.documentoventaAbarrotes
            '                Where TruncateTime(i.fechaDoc) = fecha.Date And i.tipoDocumento = tipoDoc And i.tipoVenta = "VPOS" And Not i.EnvioSunat = "SI" And Not i.estadoCobro = "ANU" And Not i.EnvioSunat = "VA").ToList

            Dim consulta = (From i In HeliosData.documentoventaTransporte
                            Where i.fechadoc.Value.Year = fecha.Year And i.fechadoc.Value.Month = fecha.Month And
                                i.tipoDocumento = tipoDoc And
                                i.tipoVenta = General.TIPO_VENTA.VENTA_ENCOMIENDAS And Not i.EnvioSunat = "SI" And Not i.EnvioSunat = "VA" _
                                And Not i.EnvioSunat = "PE" And i.idEmpresa = idEmpresa).ToList

            Return consulta

            'ElseIf tipoDoc = "07" Then




            'ElseIf tipoDoc = "03" Then

            '    Dim consulta = (From i In HeliosData.documentoventaTransporte
            '                    Join x In HeliosData.entidad On i.razonSocial Equals x.idEntidad
            '                    Where i.fechadoc.Value.Year = fecha.Year And i.fechadoc.Value.Month = fecha.Month And
            '                        i.tipoDocumento = tipoDoc And i.tipoVenta = General.TIPO_VENTA.VENTA_ENCOMIENDAS And Not i.EnvioSunat = "SI" And Not i.EnvioSunat = "VA" And Not i.estado = General.Transporte.EncomiendaEstado.Anulado And i.idEmpresa = idEmpresa
            '                    Select
            '                            idDoc = i.idDocumento,
            '                            tipodDoc = i.tipoDocumento,
            '                            serie = i.serie,
            '                        numero = i.numero,
            '                        nrodoc = x.nrodoc,
            '                        tipDocClie = x.tipoDoc,
            '                        bi01 = i.baseImponible1,
            '                        igv = i.igv1,
            '                        moneda = i.moneda,
            '                        importe = i.total).Take(250)

            '    For Each i In consulta

            '        objeto = New documentoventaTransporte
            '        objeto.idDocumento = i.idDoc
            '        objeto.tipoDocumento = i.tipodDoc
            '        objeto.serie = i.serie
            '        objeto.numero = i.numero
            '        objeto.nrodoc = i.nrodoc
            '        objeto.tipDocClie = i.tipDocClie
            '        objeto.moneda = i.moneda
            '        objeto.baseImponible1 = i.bi01
            '        objeto.igv1 = i.igv
            '        objeto.total = i.importe


            '        lista.Add(objeto)
            '    Next

            '    Return lista

        End If

    End Function


    Public Function AlertaEnvioPSETrasporte(Empresa As String) As documentoventaTransporte

        Dim obj As documentoventaTransporte

        Dim noenv As New List(Of String)
        noenv.Add("VA") 'envio anulado y validado
        noenv.Add("PE")  'enviado anulado 
        noenv.Add("SI") 'enviado sin anular


        Dim list As New List(Of String)
        list.Add("VPSJ")
        list.Add("ENDAS")


        Dim consulta = (From tip In HeliosData.entidad
                        Where tip.idEmpresa = Empresa
                        Select
                    tip.idEmpresa, tip.nombreCompleto,
                   CPEPEN = (CType((Aggregate t1 In
                    (From w In HeliosData.documentoventaTransporte
                     Where
                   list.Contains(w.tipoVenta) And Not noenv.Contains(w.EnvioSunat) And w.idEmpresa = tip.idEmpresa
                     Select New With {
                    w.idDocumento
                    }) Into Count(t1.idDocumento)), Integer?)),
                     ANUPEN = (CType((Aggregate t1 In
                    (From w In HeliosData.documentoventaTransporte
                     Where
                    w.tipoVenta = General.TIPO_VENTA.VENTA_ENCOMIENDAS And w.EnvioSunat = "PE" And w.idEmpresa = tip.idEmpresa _
                    And w.estado = General.Transporte.EncomiendaEstado.Anulado
                     Select New With {
                    w.idDocumento
                    }) Into Count(t1.idDocumento)), Integer?))).Distinct().FirstOrDefault

        If Not IsNothing(consulta) Then
            obj = New documentoventaTransporte
            obj.CpePen = consulta.CPEPEN
            obj.AnuPen = consulta.ANUPEN

        Else
            obj = New documentoventaTransporte
            obj.CpePen = 0
            obj.AnuPen = 0
        End If



        Return obj

    End Function



    Public Function AlertaPSETrasporte(Empresa As String) As documentoventaTransporte

        Dim obj As documentoventaTransporte

        Dim noenv As New List(Of String)
        noenv.Add("VA") 'envio anulado y validado
        noenv.Add("PE")  'enviado anulado 
        noenv.Add("SI") 'enviado sin anular


        Dim consulta = (From tip In HeliosData.entidad
                        Where tip.idEmpresa = Empresa
                        Select
                    tip.idEmpresa, tip.nombreCompleto,
                   FACTURAS = (CType((Aggregate t1 In
                    (From w In HeliosData.documentoventaTransporte
                     Where
                    w.tipoDocumento = "01" And
                    w.tipoVenta = General.TIPO_VENTA.VENTA_ENCOMIENDAS And Not noenv.Contains(w.EnvioSunat) And w.idEmpresa = tip.idEmpresa
                     Select New With {
                    w.idDocumento
                    }) Into Count(t1.idDocumento)), Integer?)),
                   BOLETAS = (CType((Aggregate t1 In
                    (From w In HeliosData.documentoventaTransporte
                     Where
                    w.tipoDocumento = "03" And
                    w.tipoVenta = General.TIPO_VENTA.VENTA_ENCOMIENDAS And Not noenv.Contains(w.EnvioSunat) And w.idEmpresa = tip.idEmpresa
                     Select New With {
                    w.idDocumento
                    }) Into Count(t1.idDocumento)), Integer?)),
                     FACTURAANU = (CType((Aggregate t1 In
                    (From w In HeliosData.documentoventaTransporte
                     Where
                    w.tipoDocumento = "01" And
                    w.tipoVenta = General.TIPO_VENTA.VENTA_ENCOMIENDAS And w.EnvioSunat = "PE" And w.idEmpresa = tip.idEmpresa _
                    And w.estado = General.Transporte.EncomiendaEstado.Anulado
                     Select New With {
                    w.idDocumento
                    }) Into Count(t1.idDocumento)), Integer?)),
                     BOLETAANU = (CType((Aggregate t1 In
                    (From w In HeliosData.documentoventaTransporte
                     Where
                    w.tipoDocumento = "03" And
                    w.tipoVenta = General.TIPO_VENTA.VENTA_ENCOMIENDAS And w.EnvioSunat = "PE" And w.idEmpresa = tip.idEmpresa _
                    And w.estado = General.Transporte.EncomiendaEstado.Anulado
                     Select New With {
                    w.idDocumento
                    }) Into Count(t1.idDocumento)), Integer?))).Distinct().FirstOrDefault

        If Not IsNothing(consulta) Then
            obj = New documentoventaTransporte
            obj.CantFact = consulta.FACTURAS
            obj.CantBol = consulta.BOLETAS
            obj.CantNotaFact = 0
            obj.CantNotaBol = 0
            obj.CantFactAnu = consulta.FACTURAANU
            obj.CantBolAnu = consulta.BOLETAANU

        Else
            obj = New documentoventaTransporte
            obj.CantFact = 0
            obj.CantBol = 0
            obj.CantNotaFact = 0
            obj.CantNotaBol = 0
            obj.CantFactAnu = 0
            obj.CantBolAnu = 0
        End If



        Return obj

    End Function


    Public Sub UpdateFacturasXEstadoTrans(objDocumento As Integer, estado As String)

        Try
            Using ts As New TransactionScope()
                Dim documento As documentoventaTransporte = HeliosData.documentoventaTransporte.Where(Function(o) _
                                            o.idDocumento = objDocumento).First()
                documento.EnvioSunat = estado
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetEncomiendasSelAgenciaDestino(be As documentoventaTransporte) As List(Of documentoventaTransporte)
        Dim consulta = (From det In HeliosData.documentoventaTransporteDetalle
                        Join e In HeliosData.entidad On New With {.IdEntidad = CInt(det.documentoventaTransporte.razonSocial)} Equals New With {.IdEntidad = e.idEntidad}
                        Group Join per In HeliosData.Persona On per.codigo Equals det.documentoventaTransporte.idPersona Into per_join = Group
                        From per In per_join.DefaultIfEmpty()
                        Where
                            det.documentoventaTransporte.idEmpresa = be.idEmpresa And
                            det.documentoventaTransporte.agenciaDestino_id = be.agenciaDestino_id And
                            det.documentoventaTransporte.fechadoc.Value.Year = be.fechadoc.Value.Year And
                            det.documentoventaTransporte.fechadoc.Value.Month = be.fechadoc.Value.Month And
                            det.documentoventaTransporte.fechadoc.Value.Day = be.fechadoc.Value.Day And
                            det.estado = be.estado And
                            det.documentoventaTransporte.tipoVenta = "ENDAS" And det.documentoventaTransporte.estado <> General.Transporte.EncomiendaEstado.Anulado
                        Select
                            det.documentoventaTransporte.comprador,
                            det.documentoventaTransporte.serie,
                            det.documentoventaTransporte.numero,
                            IdDocumento = CType(det.documentoventaTransporte.idDocumento, Int32?),
                            Fechadoc = CType(det.documentoventaTransporte.fechadoc, DateTime?),
                            det.documentoventaTransporte.ciudadOrigen,
                            Remitente = e.nombreCompleto,
                            det.documentoventaTransporte.ciudadDestino,
                            Consignado = per.nombreCompleto,
                            det.documentoventaTransporte.estadoCobro,
                            Estado = CType(det.documentoventaTransporte.estado, Int32?),
                            Total = CType(det.documentoventaTransporte.total, Decimal?),
                            det.secuencia,
                            det.tipo,
                            det.detalle,
                            importeDetail = det.importe,
                            det.cantidad)

        GetEncomiendasSelAgenciaDestino = New List(Of documentoventaTransporte)
        For Each i In consulta
            GetEncomiendasSelAgenciaDestino.Add(New documentoventaTransporte With
                                            {
                                            .CustomDocumentoVentaDetalle =
                                             New documentoventaTransporteDetalle With
                                             {
                                             .secuencia = i.secuencia,
                                             .tipo = i.tipo,
                                             .cantidad = i.cantidad,
                                             .detalle = i.detalle,
                                             .importe = i.importeDetail
                                             },
                                            .idDocumento = i.IdDocumento,
                                            .comprador = i.comprador,
                                            .serie = i.serie,
                                            .numero = i.numero,
                                            .fechadoc = i.Fechadoc,
                                            .ciudadOrigen = i.ciudadOrigen,
                                            .Remitente = i.Remitente,
                                            .ciudadDestino = i.ciudadDestino,
                                            .Consignado = i.Consignado,
                                            .itemsEnviados = 0,
                                            .total = i.Total,
                                            .estadoCobro = i.estadoCobro,
                                            .estado = i.Estado
                                            })
        Next


    End Function

    Public Function GetEncomiendasSelAgenciaDestinoMes(be As documentoventaTransporte) As List(Of documentoventaTransporte)
        Dim consulta = (From det In HeliosData.documentoventaTransporteDetalle
                        Join e In HeliosData.entidad On New With {.IdEntidad = CInt(det.documentoventaTransporte.razonSocial)} Equals New With {.IdEntidad = e.idEntidad}
                        Group Join per In HeliosData.Persona On per.codigo Equals det.documentoventaTransporte.idPersona Into per_join = Group
                        From per In per_join.DefaultIfEmpty()
                        Where
                            det.documentoventaTransporte.idEmpresa = be.idEmpresa And
                            det.documentoventaTransporte.agenciaDestino_id = be.agenciaDestino_id And
                            det.documentoventaTransporte.fechadoc.Value.Year = be.fechadoc.Value.Year And
                            det.documentoventaTransporte.fechadoc.Value.Month = be.fechadoc.Value.Month And
                            det.estado = be.estado And
                            det.documentoventaTransporte.tipoVenta = "ENDAS" And det.documentoventaTransporte.estado <> General.Transporte.EncomiendaEstado.Anulado
                        Select
                            det.documentoventaTransporte.comprador,
                            det.documentoventaTransporte.serie,
                            det.documentoventaTransporte.numero,
                            IdDocumento = CType(det.documentoventaTransporte.idDocumento, Int32?),
                            Fechadoc = CType(det.documentoventaTransporte.fechadoc, DateTime?),
                            det.documentoventaTransporte.ciudadOrigen,
                            Remitente = e.nombreCompleto,
                            det.documentoventaTransporte.ciudadDestino,
                            Consignado = per.nombreCompleto,
                            det.documentoventaTransporte.estadoCobro,
                            Estado = CType(det.documentoventaTransporte.estado, Int32?),
                            Total = CType(det.documentoventaTransporte.total, Decimal?),
                            det.secuencia,
                            det.tipo,
                            det.detalle,
                            importeDetail = det.importe,
                            det.cantidad)

        GetEncomiendasSelAgenciaDestinoMes = New List(Of documentoventaTransporte)
        For Each i In consulta
            GetEncomiendasSelAgenciaDestinoMes.Add(New documentoventaTransporte With
                                            {
                                            .CustomDocumentoVentaDetalle =
                                             New documentoventaTransporteDetalle With
                                             {
                                             .secuencia = i.secuencia,
                                             .tipo = i.tipo,
                                             .cantidad = i.cantidad,
                                             .detalle = i.detalle,
                                             .importe = i.importeDetail
                                             },
                                            .idDocumento = i.IdDocumento,
                                            .comprador = i.comprador,
                                            .serie = i.serie,
                                            .numero = i.numero,
                                            .fechadoc = i.Fechadoc,
                                            .ciudadOrigen = i.ciudadOrigen,
                                            .Remitente = i.Remitente,
                                            .ciudadDestino = i.ciudadDestino,
                                            .Consignado = i.Consignado,
                                            .itemsEnviados = 0,
                                            .total = i.Total,
                                            .estadoCobro = i.estadoCobro,
                                            .estado = i.Estado
                                            })
        Next


    End Function

    Public Function GetEncomiendasSelCajero(be As documentoventaTransporte) As List(Of documentoventaTransporte)
        Dim consulta = (From det In HeliosData.documentoventaTransporte
                        Join e In HeliosData.entidad On New With {.IdEntidad = CInt(det.razonSocial)} Equals New With {.IdEntidad = e.idEntidad}
                        Where
                            det.idcajaUsuario = be.idcajaUsuario And
                          det.tipoVenta = "ENDAS" And det.estado <> General.Transporte.EncomiendaEstado.Anulado
                        Select
                            det.serie,
                            det.numero,
                            IdDocumento = CType(det.idDocumento, Int32?),
                            Fechadoc = CType(det.fechadoc, DateTime?),
                            det.ciudadOrigen,
                            Remitente = e.nombreCompleto,
                            det.ciudadDestino,
                            det.estadoCobro,
                            Estado = CType(det.estado, Int32?),
                            Total = CType(det.total, Decimal?))

        GetEncomiendasSelCajero = New List(Of documentoventaTransporte)
        For Each i In consulta
            GetEncomiendasSelCajero.Add(New documentoventaTransporte With
                                            {
                                            .idDocumento = i.IdDocumento,
                                            .serie = i.serie,
                                            .numero = i.numero,
                                            .fechadoc = i.Fechadoc,
                                            .ciudadOrigen = i.ciudadOrigen,
                                            .Remitente = i.Remitente,
                                            .ciudadDestino = i.ciudadDestino,
                                            .itemsEnviados = 0,
                                            .total = i.Total,
                                            .estadoCobro = i.estadoCobro,
                                            .estado = i.Estado
                                            })
        Next


    End Function

    Public Function GetCiudadesPorEntregarOrigen(be As documentoventaTransporte) As List(Of documentoventaTransporte)


        Dim con = (From vt In HeliosData.documentoventaTransporteDetalle
                   Join agenciaDestino In HeliosData.centrocosto On New With {.IdCentroCosto = CInt(vt.documentoventaTransporte.agenciaDestino_id)} Equals New With {.IdCentroCosto = agenciaDestino.idCentroCosto}
                   Where
                      CLng(vt.documentoventaTransporte.idOrganizacion) = be.idOrganizacion And
                    CLng(vt.documentoventaTransporte.estado) = be.estado
                   Group New With {agenciaDestino, vt} By
                              agenciaDestino.idCentroCosto,
                              agenciaDestino.nombre
                             Into g = Group
                   Select
                              IdCentroCosto = CType(idCentroCosto, Int32?),
                              nombre,
                              pendientes = CType(g.Count(Function(p) p.vt.secuencia <> Nothing), Int64?)).ToList

        GetCiudadesPorEntregarOrigen = New List(Of documentoventaTransporte)
        For Each i In con
            GetCiudadesPorEntregarOrigen.Add(New documentoventaTransporte With
                                             {
                                             .agenciaDestino_id = i.IdCentroCosto,
                                             .ciudadDestino = i.nombre,
                                             .TotalPendientes = i.pendientes
                                             })
        Next
    End Function

    Public Function GetCiudadesPorEntregarOrigenFecha(be As documentoventaTransporte, opcion As String) As List(Of documentoventaTransporte)

        GetCiudadesPorEntregarOrigenFecha = New List(Of documentoventaTransporte)

        Select Case opcion
            Case "PorMes"
                Dim con = ((From det In HeliosData.documentoventaTransporteDetalle
                            Join agencia_destino In HeliosData.centrocosto On New With {.IdCentroCosto = CInt(det.documentoventaTransporte.agenciaDestino_id)} Equals New With {.IdCentroCosto = agencia_destino.idCentroCosto}
                            Where
                              CLng(det.documentoventaTransporte.idOrganizacion) = be.idOrganizacion _
                                And det.documentoventaTransporte.fechadoc.Value.Year = be.fechadoc.Value.Year _
                                And det.documentoventaTransporte.fechadoc.Value.Month = be.fechadoc.Value.Month
                            Select
                              IdCentroCosto = CType(agencia_destino.idCentroCosto, Int32?),
                              agencia_destino.nombre,
                              Pendientes = ((Aggregate t1 In
                                            (From d In HeliosData.documentoventaTransporteDetalle
                                             Where
                                                 CLng(d.estado) = 0 And
                                                 d.documentoventaTransporte.agenciaDestino_id = agencia_destino.idCentroCosto
                                             Select
                                                 d,
                                                 d.documentoventaTransporte)
                                                 Into Count())),
                                Entregados = ((Aggregate t1 In
                                                   (From d In HeliosData.documentoventaTransporteDetalle
                                                    Where
                                                        CLng(d.estado) = 1 And
                                                d.documentoventaTransporte.agenciaDestino_id = agencia_destino.idCentroCosto
                                                    Select
                                                        d,
                                                        d.documentoventaTransporte)
                                                   Into Count()))).Distinct()).ToList


                For Each i In con
                    GetCiudadesPorEntregarOrigenFecha.Add(New documentoventaTransporte With
                                                          {
                                                           .agenciaDestino_id = i.IdCentroCosto,
                                                           .ciudadDestino = i.nombre,
                                                           .TotalPendientes = i.Pendientes,
                                                           .TotalEntregados = i.Entregados
                                                          })
                Next


            Case "PorDia"

                Dim con = ((From det In HeliosData.documentoventaTransporteDetalle
                            Join agencia_destino In HeliosData.centrocosto On New With {.IdCentroCosto = CInt(det.documentoventaTransporte.agenciaDestino_id)} Equals New With {.IdCentroCosto = agencia_destino.idCentroCosto}
                            Where
                              CLng(det.documentoventaTransporte.idOrganizacion) = be.idOrganizacion _
                                And det.documentoventaTransporte.fechadoc.Value.Year = be.fechadoc.Value.Year _
                                And det.documentoventaTransporte.fechadoc.Value.Month = be.fechadoc.Value.Month _
                                And det.documentoventaTransporte.fechadoc.Value.Day = be.fechadoc.Value.Day _
                                And det.estado = 0 And det.documentoventaTransporte.estado <> 5
                            Select
                              IdCentroCosto = CType(agencia_destino.idCentroCosto, Int32?),
                              agencia_destino.nombre,
                              Pendientes = ((Aggregate t1 In
                                            (From d In HeliosData.documentoventaTransporteDetalle
                                             Where
                                                 CLng(d.estado) = 0 And
                                                 d.documentoventaTransporte.estado <> 5 And
                                                 d.documentoventaTransporte.fechadoc.Value.Year = be.fechadoc.Value.Year And
                                                 d.documentoventaTransporte.fechadoc.Value.Month = be.fechadoc.Value.Month And
                                                 d.documentoventaTransporte.fechadoc.Value.Day = be.fechadoc.Value.Day And
                                                 d.documentoventaTransporte.agenciaDestino_id = agencia_destino.idCentroCosto
                                             Select
                                                 d,
                                                 d.documentoventaTransporte)
                                                 Into Count())),
                                Entregados = ((Aggregate t1 In
                                                   (From d In HeliosData.documentoventaTransporteDetalle
                                                    Where
                                                CLng(d.estado) = 1 And
                                                        d.documentoventaTransporte.estado <> 5 And
                                                 d.documentoventaTransporte.fechadoc.Value.Year = be.fechadoc.Value.Year And
                                                 d.documentoventaTransporte.fechadoc.Value.Month = be.fechadoc.Value.Month And
                                                 d.documentoventaTransporte.fechadoc.Value.Day = be.fechadoc.Value.Day And
                                                 d.documentoventaTransporte.agenciaDestino_id = agencia_destino.idCentroCosto
                                                    Select
                                                        d,
                                                        d.documentoventaTransporte)
                                                   Into Count()))).Distinct()).ToList

                For Each i In con
                    GetCiudadesPorEntregarOrigenFecha.Add(New documentoventaTransporte With
                                                          {
                                                           .agenciaDestino_id = i.IdCentroCosto,
                                                           .ciudadDestino = i.nombre,
                                                           .TotalPendientes = i.Pendientes,
                                                           .TotalEntregados = i.Entregados
                                                          })
                Next

        End Select

    End Function

    Public Function EnviarBoletaEliminada(item As documentoventaTransporte) As String
        Try

            Dim numeracionBoletasBL As New numeracionBoletasBL
            Dim entidadSA As New entidadBL
            Dim numerobaja = numeracionBoletasBL.GenerarNumeroXTipo(item.idOrganizacion, "RSD", "03")
            Dim numer As String = String.Format("{0:00000}", CInt(numerobaja))

            Dim numerobol = String.Format("{0:00000000}", CInt(item.numero))
            Dim receptor = entidadSA.GetUbicarEntPorID(item.idEmpresa, item.razonSocial)

            Dim objeto As Helios.Fact.Sunat.Business.Entity.DocumentoResumenDetalle
            Dim Resumen = New Helios.Fact.Sunat.Business.Entity.DocumentoResumen
            'CABEZERA
            Resumen.Action = 0
            Resumen.idEmpresa = item.idPSE 'Gempresas.ubigeo
            Resumen.Contribuyente_id = item.idEmpresa
            Resumen.IdDocumento = String.Format("RC-{0:yyyyMMdd}-" & numer, DateTime.Today)
            Resumen.FechaEmision = DateTime.Now
            Resumen.FechaReferencia = item.fechadoc
            Resumen.FechaRecepcion = DateTime.Now
            Resumen.EnvioSunat = "NO"
            Resumen.TipoResumen = "AN"
            'DETALLE
            objeto = New Helios.Fact.Sunat.Business.Entity.DocumentoResumenDetalle
            objeto.idSecuencia = 1
            objeto.TipoDocumento = item.tipoDocumento
            objeto.IdDocumento = item.serie & "-" & numerobol
            objeto.NroDocumentoReceptor = receptor.nrodoc
            objeto.TipoDocumentoReceptor = receptor.tipoDoc
            objeto.CodigoEstadoItem = 3 'CInt(i.GetValue("estado"))

            'If item.moneda = "1" Then
            objeto.Moneda = "PEN"
            'ElseIf item.moneda = "2" Then
            'objeto.Moneda = "USD"
            'End If

            objeto.TotalVenta = item.total
            objeto.TotalIgv = item.igv1
            objeto.Gravadas = item.baseImponible1
            objeto.Exoneradas = item.baseImponible2

            Resumen.DocumentoResumenDetalle.Add(objeto)

            Dim codigo = Helios.Fact.Sunat.WCFService.ServiceAccess.Admin.DocumentoResumenSA.DocumentoResumenSave(Resumen, Nothing)

            If codigo.idResumen > 0 Then
                'ActualizarBoletas(listaActEstado, IIf(IsNothing(conf.ConfigComprobante), 0, conf.ConfigComprobante), "0")

                'documentoSA.UpdateAnulacionEnviada(item.idDocumento, numerobaja, 0)

                'MessageBox.Show("El Resumen se Envio Correctamente al PSE")
                Return "SI"
            Else
                Return "PE"
            End If

        Catch ex As Exception

            Return "PE"

        End Try
    End Function


    Public Function ComunicacionBajaFactura(objeto As documentoventaTransporte) As String

        Try
            Dim numeracionBoletasBL As New numeracionBoletasBL
            Dim numerobaja = numeracionBoletasBL.GenerarNumeroXTipo(objeto.idOrganizacion, "BAJA", "01")
            Dim objetoBaja As Helios.Fact.Sunat.Business.Entity.ComunicacionBajaDetalle
            'CABEZERA
            Dim comunicacion As New Helios.Fact.Sunat.Business.Entity.ComunicacionBaja
            comunicacion.Action = 0
            comunicacion.idEmpresa = objeto.idPSE 'Gempresas.ubigeo 'lblIdPse.Text
            comunicacion.IdDocumento = String.Format("RA-{0:yyyyMMdd}-" & numerobaja, DateTime.Today)
            comunicacion.FechaEmision = DateTime.Now
            comunicacion.FechaReferencia = objeto.fechadoc  'dtpFechaDocs.Value
            comunicacion.FechaRecepcion = DateTime.Now
            comunicacion.EnvioSunat = "NO"
            comunicacion.Contribuyente_id = objeto.idEmpresa
            'DETALLE
            objetoBaja = New Helios.Fact.Sunat.Business.Entity.ComunicacionBajaDetalle
            objetoBaja.Id = 1
            objetoBaja.Serie = objeto.serie ' i.GetValue("serie")
            objetoBaja.Correlativo = String.Format("{0:00000000}", CInt(objeto.numero))
            objetoBaja.TipoDocumento = objeto.tipoDocumento
            objetoBaja.MotivoBaja = "ANULACION DE LA FACTURA"
            comunicacion.ComunicacionBajaDetalle.Add(objetoBaja)

            Dim codigo = Helios.Fact.Sunat.WCFService.ServiceAccess.Admin.ComunicacionBajaSA.ComunicacionBajaSave(comunicacion, Nothing)

            If codigo.idComunicacion > 0 Then
                'ActualizarEnvioSunat("0", objeto)
                'Me.UpdateAnulacionEnviada(objeto.idDocumento, numerobaja, 0)
                Return "SI"
            Else
                Return "PE"

            End If


        Catch ex As Exception
            Return "PE"
        End Try

    End Function

    Public Sub EliminarVentaEncomienda(documentoBE As documento)
        Dim inventarioBL As New totalesAlmacenBL
        Dim invBL As New InventarioMovimientoBL
        Dim documentocompraBL As New documentocompraBL
        Dim documentocompradetalleBL As New documentocompradetalleBL
        Dim notificacionAlmacenBL As New notificacionAlmacenBL
        Dim documentoGuiaBL As New documentoGuiaBL
        Dim asientoBL As New AsientoBL
        Dim documentoCajaBl As New documentoCajaDetalleBL
        Dim recursoCostoBL As New recursoCostoDetalleBL
        Dim documentoBL As New documentoBL
        Dim documentoDetalleObligacionBL As New documentoObligacionTributariaDetalleBL
        Try
            Using ts As New TransactionScope

                Dim encomienda = HeliosData.documentoventaTransporte.Where(Function(o) o.idDocumento = documentoBE.idDocumento).Single

                If encomienda.estado = General.Transporte.EncomiendaEstado.Anulado Then
                    Throw New Exception("El comprobante ya fue anulado, elija otro.!")
                End If

                'If encomienda.estado = General.Transporte.EncomiendaEstado.Entregado Then
                '    Throw New Exception("No puede eliminar un documento que ya fue entregado!")
                'End If

                'eliminando documento caja
                documentoCajaBl.DeleteDocumentoCaja(documentoBE.idDocumento)

                'eliminando guía de remisión
                documentoGuiaBL.EliminarGuiaGeneral(documentoBE.idDocumento)

                encomienda.estado = General.EncomiendaEstado.Anulado



                ' Select Case encomienda.tipoDocumento
                'Case "01"
                'If encomienda.EnvioSunat = "SI" Then  ' SI HA SIDO ENVIADO Y ELIMANDO
                '    encomienda.EnvioSunat = "PE"


                'If documentoBE.idPse > 0 Then
                '    encomienda.idPSE = documentoBE.idPse
                'If My.Computer.Network.IsAvailable = True Then
                '    If My.Computer.Network.Ping("148.102.27.231") Then
                '        If encomienda.tipoDocumento = "01" Then

                '            Dim estado = ComunicacionBajaFactura(encomienda)
                '            encomienda.EnvioSunat = estado

                '        ElseIf encomienda.tipoDocumento = "03" Then

                '            Dim estado = EnviarBoletaEliminada(encomienda)
                '            encomienda.EnvioSunat = estado
                '        End If
                '    End If
                'End If
                'End If





                'Else encomienda.EnvioSunat = Nothing
                '            encomienda.EnvioSunat = "NE"       ' NO ENVIADO Y ELIMINADO
                '        End If
                'Case "03"
                '    encomienda.EnvioSunat = "PE"
                ' End Select

                'encomienda.baseImponible1 = 0
                'encomienda.baseImponible2 = 0
                'encomienda.igv1 = 0
                'encomienda.igv2 = 0
                'encomienda.total = 0


                'Dim encomiendaDetalle = HeliosData.documentoventaTransporteDetalle.Where(Function(o) o.idDocumento = documentoBE.idDocumento).ToList

                'For Each i In encomiendaDetalle
                '    i.
                'Next


                encomienda.estadoCobro = "ANU"

                If encomienda.EnvioSunat = "SI" Then  ' SI HA SIDO ENVIADO Y ELIMANDO
                    encomienda.EnvioSunat = "PE"
                Else encomienda.EnvioSunat = Nothing
                    encomienda.EnvioSunat = "NE"       ' NO ENVIADO Y ELIMINADO
                End If



                encomienda.estadoCobro = "ANU"
                If encomienda.EnvioSunat = "SI" Then  ' SI HA SIDO ENVIADO Y ELIMANDO
                    encomienda.EnvioSunat = "PE"
                Else encomienda.EnvioSunat = Nothing
                    encomienda.EnvioSunat = "NE"       ' NO ENVIADO Y ELIMINADO
                End If


                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function GetEncomiendasByProgramacion(be As documentoventaTransporte) As List(Of documentoventaTransporte)
        Dim consulta = (From det In HeliosData.documentoventaTransporteDetalle
                        Join e In HeliosData.entidad On New With {.IdEntidad = CInt(det.documentoventaTransporte.razonSocial)} Equals New With {.IdEntidad = e.idEntidad}
                        Join per In HeliosData.Persona On New With {.Codigo = CInt(det.documentoventaTransporte.idPersona)} Equals New With {.Codigo = per.codigo}
                        Where
                            det.documentoventaTransporte.programacion_id = be.programacion_id And
                            det.documentoventaTransporte.tipoVenta = "ENDAS"
                        Select
                          Contenido = det.detalle,
                          IdDocumento = CType(det.documentoventaTransporte.idDocumento, Int32?),
                          Fechadoc = CType(det.documentoventaTransporte.fechadoc, DateTime?),
                          det.documentoventaTransporte.ciudadOrigen,
                          Remitente = e.nombreCompleto,
                          det.documentoventaTransporte.ciudadDestino,
                          Consignado = per.nombreCompleto,
                          det.documentoventaTransporte.estadoCobro,
                          Estado = CType(det.documentoventaTransporte.estado, Int32?),
                          Total = CType(det.documentoventaTransporte.total, Decimal?))

        GetEncomiendasByProgramacion = New List(Of documentoventaTransporte)
        For Each i In consulta
            GetEncomiendasByProgramacion.Add(New documentoventaTransporte With
                                            {
                                            .comprador = i.Contenido,
                                            .idDocumento = i.IdDocumento,
                                            .fechadoc = i.Fechadoc,
                                            .ciudadOrigen = i.ciudadOrigen,
                                            .Remitente = i.Remitente,
                                            .ciudadDestino = i.ciudadDestino,
                                            .Consignado = i.Consignado,
                                            .total = i.Total,
                                            .estadoCobro = i.estadoCobro,
                                            .estado = i.Estado
                                            })
        Next


    End Function

    Public Function GetConsultaEncomiendasFecha(be As documentoventaTransporte) As List(Of documentoventaTransporte)
        'NumIdentClie = ent.nrodoc,
        Dim consulta = (From vt In HeliosData.documentoventaTransporteDetalle
                        Join ent In HeliosData.entidad On New With {.IdEntidad = CInt(vt.documentoventaTransporte.razonSocial)} Equals New With {.IdEntidad = ent.idEntidad}
                        Group Join per In HeliosData.Persona On New With {.Codigo = CInt(vt.documentoventaTransporte.idPersona)} Equals New With {.Codigo = per.codigo} Into per_join = Group
                        From per In per_join.DefaultIfEmpty()
                        Where
                             vt.documentoventaTransporte.idEmpresa = be.idEmpresa And
                            vt.documentoventaTransporte.idOrganizacion = be.idOrganizacion And
                            vt.documentoventaTransporte.fechadoc.Value.Year = be.fechadoc.Value.Year And
                            vt.documentoventaTransporte.fechadoc.Value.Month = be.fechadoc.Value.Month And
                            vt.documentoventaTransporte.fechadoc.Value.Day = be.fechadoc.Value.Day And
                            vt.documentoventaTransporte.tipoVenta = "ENDAS"
                        Group New With {vt.documentoventaTransporte, ent, per, vt} By
                            Comprador = vt.documentoventaTransporte.comprador,
                            Serieventa = vt.documentoventaTransporte.serie,
                            Numeroventa = vt.documentoventaTransporte.numero,
                            IdDocumento = CType(vt.documentoventaTransporte.idDocumento, Int32?),
                            Fechadoc = CType(vt.documentoventaTransporte.fechadoc, DateTime?),
                            vt.documentoventaTransporte.ciudadOrigen,
                            ent.nombreCompleto,
                            vt.documentoventaTransporte.ciudadDestino,
                            Column1 = per.nombreCompleto,
                            vt.documentoventaTransporte.estadoCobro,
                            Estado = CType(vt.documentoventaTransporte.estado, Int32?),
                            vt.documentoventaTransporte.EnvioSunat,
                            vt.documentoventaTransporte.tipoDocumento,
                            Total = CType(vt.documentoventaTransporte.total, Decimal?)
                            Into g = Group
                        Select
                            Comprador,
                            Serieventa,
                            Numeroventa,
                            IdDocumento = CType(IdDocumento, Int32?),
                            Fechadoc = CType(Fechadoc, DateTime?),
                            ciudadOrigen,
                            Remitente = nombreCompleto,
                            ciudadDestino,
                            Consignado = Column1,
                            estadoCobro,
                            Estado = CType(Estado, Int32?),
                            EnvioSunat,
                            tipoDocumento,
                            Total = CType(Total, Decimal?),
                            totalitems = CType(g.Count(Function(p) p.vt.secuencia <> Nothing), Int64?)
)

        'Dim consulta = (From det In HeliosData.documentoventaTransporteDetalle
        '                Join e In HeliosData.entidad On New With {.IdEntidad = CInt(det.documentoventaTransporte.razonSocial)} Equals New With {.IdEntidad = e.idEntidad}
        '                Join per In HeliosData.Persona On New With {.Codigo = CInt(det.documentoventaTransporte.idPersona)} Equals New With {.Codigo = per.codigo}
        '                Where
        '                    det.documentoventaTransporte.idEmpresa = be.idEmpresa And
        '                    det.documentoventaTransporte.idOrganizacion = be.idOrganizacion And
        '                    det.documentoventaTransporte.fechadoc.Value.Year = be.fechadoc.Value.Year And
        '                    det.documentoventaTransporte.fechadoc.Value.Month = be.fechadoc.Value.Month And
        '                    det.documentoventaTransporte.fechadoc.Value.Day = be.fechadoc.Value.Day And
        '                  det.documentoventaTransporte.tipoVenta = "ENDAS"
        '                Group New With {det.documentoventaTransporte, e, per, det} By
        '                  IdDocumento = CType(det.documentoventaTransporte.idDocumento, Int32?),
        '                  Fechadoc = CType(det.documentoventaTransporte.fechadoc, DateTime?),
        '                  det.documentoventaTransporte.ciudadOrigen,
        '                  Remitente = e.nombreCompleto,
        '                  det.documentoventaTransporte.ciudadDestino,
        '                  Consignado = per.nombreCompleto,
        '                  det.documentoventaTransporte.estadoCobro,
        '                    det.documentoventaTransporte.EnvioSunat,
        '                    det.documentoventaTransporte.tipoDocumento,
        '                  Estado = CType(det.documentoventaTransporte.estado, Int32?),
        '                  Total = CType(det.documentoventaTransporte.total, Decimal?)
        '                 Into g = Group
        '                Select
        '                  IdDocumento = CType(IdDocumento, Int32?),
        '                  Fechadoc = CType(Fechadoc, DateTime?),
        '                  ciudadOrigen,
        '                  Remitente,
        '                  ciudadDestino,
        '                  Consignado,
        '                  items = CType(g.Count(Function(p) p.det.secuencia <> Nothing), Int64?),
        '                  Total = CType(Total, Decimal?),
        '                  estadoCobro,
        '                    EnvioSunat,
        '                    tipoDocumento,
        '                  Estado = CType(Estado, Int32?))

        GetConsultaEncomiendasFecha = New List(Of documentoventaTransporte)
        For Each i In consulta
            GetConsultaEncomiendasFecha.Add(New documentoventaTransporte With
                                            {
                                            .idDocumento = i.IdDocumento,
                                            .comprador = i.Comprador,
                                            .fechadoc = i.Fechadoc,
                                            .ciudadOrigen = i.ciudadOrigen,
                                            .Remitente = i.Remitente,
                                            .ciudadDestino = i.ciudadDestino,
                                            .Consignado = i.Consignado,
                                            .itemsEnviados = i.totalitems,
                                            .total = i.Total,
                                            .estadoCobro = i.estadoCobro,
                                            .EnvioSunat = i.EnvioSunat,
                                            .tipoDocumento = i.tipoDocumento,
                                            .serie = i.Serieventa,
                                            .numero = i.Numeroventa,
                                            .estado = i.Estado
                                            })
        Next


    End Function

    Public Function GetConsultaTransporteFecha(be As documentoventaTransporte) As List(Of documentoventaTransporte)
        'NumIdentClie = ent.nrodoc,

        Dim lista As New List(Of String)
        lista.Add("ENDAS")
        lista.Add("VPSJ")

        Dim consulta = (From vt In HeliosData.documentoventaTransporteDetalle
                        Join ent In HeliosData.entidad On New With {.IdEntidad = CInt(vt.documentoventaTransporte.razonSocial)} Equals New With {.IdEntidad = ent.idEntidad}
                        Group Join per In HeliosData.Persona On New With {.Codigo = CInt(vt.documentoventaTransporte.idPersona)} Equals New With {.Codigo = per.codigo} Into per_join = Group
                        From per In per_join.DefaultIfEmpty()
                        Where
                             vt.documentoventaTransporte.idEmpresa = be.idEmpresa And
                            vt.documentoventaTransporte.idOrganizacion = be.idOrganizacion And
                            vt.documentoventaTransporte.fechadoc.Value.Year = be.fechadoc.Value.Year And
                            vt.documentoventaTransporte.fechadoc.Value.Month = be.fechadoc.Value.Month And
                            vt.documentoventaTransporte.fechadoc.Value.Day = be.fechadoc.Value.Day And
                           lista.Contains(vt.documentoventaTransporte.tipoVenta)
                        Group New With {vt.documentoventaTransporte, ent, per, vt} By
                            Comprador = vt.documentoventaTransporte.comprador,
                            Serieventa = vt.documentoventaTransporte.serie,
                            Numeroventa = vt.documentoventaTransporte.numero,
                            IdDocumento = CType(vt.documentoventaTransporte.idDocumento, Int32?),
                            Fechadoc = CType(vt.documentoventaTransporte.fechadoc, DateTime?),
                            vt.documentoventaTransporte.ciudadOrigen,
                            ent.nombreCompleto,
                            vt.documentoventaTransporte.ciudadDestino,
                            Column1 = per.nombreCompleto,
                            vt.documentoventaTransporte.estadoCobro,
                            Estado = CType(vt.documentoventaTransporte.estado, Int32?),
                            vt.documentoventaTransporte.EnvioSunat,
                            vt.documentoventaTransporte.tipoDocumento,
                            vt.idDistribucion,
                            vt.documentoventaTransporte.tipoVenta,
                            Total = CType(vt.documentoventaTransporte.total, Decimal?)
                            Into g = Group
                        Select
                            Comprador,
                            Serieventa,
                            Numeroventa,
                            IdDocumento = CType(IdDocumento, Int32?),
                            Fechadoc = CType(Fechadoc, DateTime?),
                            ciudadOrigen,
                            Remitente = nombreCompleto,
                            ciudadDestino,
                            Consignado = Column1,
                            estadoCobro,
                            Estado = CType(Estado, Int32?),
                            EnvioSunat,
                            tipoDocumento,
                            idDistribucion,
                            tipoVenta,
                            Total = CType(Total, Decimal?),
                            totalitems = CType(g.Count(Function(p) p.vt.secuencia <> Nothing), Int64?)
)


        GetConsultaTransporteFecha = New List(Of documentoventaTransporte)
        For Each i In consulta
            GetConsultaTransporteFecha.Add(New documentoventaTransporte With
                                            {
                                            .idDocumento = i.IdDocumento,
                                            .comprador = i.Comprador,
                                            .fechadoc = i.Fechadoc,
                                            .ciudadOrigen = i.ciudadOrigen,
                                            .Remitente = i.Remitente,
                                            .ciudadDestino = i.ciudadDestino,
                                            .Consignado = i.Consignado,
                                            .itemsEnviados = i.totalitems,
                                            .total = i.Total,
                                            .estadoCobro = i.estadoCobro,
                                            .EnvioSunat = i.EnvioSunat,
                                            .tipoDocumento = i.tipoDocumento,
                                            .serie = i.Serieventa,
                                            .numero = i.Numeroventa,
                                            .tipoVenta = i.tipoVenta,
                                            .idDistribucion = i.idDistribucion.GetValueOrDefault,
                                            .estado = i.Estado
                                            })
        Next


    End Function

    'NumIdentClie = ent.nrodoc,
    Public Function GetConsultaEncomiendasSelMes(be As documentoventaTransporte) As List(Of documentoventaTransporte)
        Dim consulta = (From vt In HeliosData.documentoventaTransporteDetalle
                        Join ent In HeliosData.entidad On New With {.IdEntidad = CInt(vt.documentoventaTransporte.razonSocial)} Equals New With {.IdEntidad = ent.idEntidad}
                        Group Join per In HeliosData.Persona On New With {.Codigo = CInt(vt.documentoventaTransporte.idPersona)} Equals New With {.Codigo = per.codigo} Into per_join = Group
                        From per In per_join.DefaultIfEmpty()
                        Where
                             vt.documentoventaTransporte.idEmpresa = be.idEmpresa And
                            vt.documentoventaTransporte.idOrganizacion = be.idOrganizacion And
                            vt.documentoventaTransporte.fechadoc.Value.Year = be.fechadoc.Value.Year And
                            vt.documentoventaTransporte.fechadoc.Value.Month = be.fechadoc.Value.Month And
                            vt.documentoventaTransporte.tipoVenta = "ENDAS"
                        Group New With {vt.documentoventaTransporte, ent, per, vt} By
                            Comprador = vt.documentoventaTransporte.comprador,
                            Serieventa = vt.documentoventaTransporte.serie,
                            Numeroventa = vt.documentoventaTransporte.numero,
                            IdDocumento = CType(vt.documentoventaTransporte.idDocumento, Int32?),
                            Fechadoc = CType(vt.documentoventaTransporte.fechadoc, DateTime?),
                            vt.documentoventaTransporte.ciudadOrigen,
                            ent.nombreCompleto,
                            vt.documentoventaTransporte.ciudadDestino,
                            Column1 = per.nombreCompleto,
                            vt.documentoventaTransporte.estadoCobro,
                            Estado = CType(vt.documentoventaTransporte.estado, Int32?),
                            vt.documentoventaTransporte.EnvioSunat,
                            vt.documentoventaTransporte.tipoDocumento,
                            Total = CType(vt.documentoventaTransporte.total, Decimal?)
                            Into g = Group
                        Select
                            Comprador,
                            Serieventa,
                            Numeroventa,
                            IdDocumento = CType(IdDocumento, Int32?),
                            Fechadoc = CType(Fechadoc, DateTime?),
                            ciudadOrigen,
                            Remitente = nombreCompleto,
                            ciudadDestino,
                            Consignado = Column1,
                            estadoCobro,
                            Estado = CType(Estado, Int32?),
                            EnvioSunat,
                            tipoDocumento,
                            Total = CType(Total, Decimal?),
                            totalitems = CType(g.Count(Function(p) p.vt.secuencia <> Nothing), Int64?)
)

        'Dim consulta = (From det In HeliosData.documentoventaTransporteDetalle
        '                Join e In HeliosData.entidad On New With {.IdEntidad = CInt(det.documentoventaTransporte.razonSocial)} Equals New With {.IdEntidad = e.idEntidad}
        '                Join per In HeliosData.Persona On New With {.Codigo = CInt(det.documentoventaTransporte.idPersona)} Equals New With {.Codigo = per.codigo}
        '                Where
        '                    det.documentoventaTransporte.idEmpresa = be.idEmpresa And
        '                    det.documentoventaTransporte.idOrganizacion = be.idOrganizacion And
        '                    det.documentoventaTransporte.fechadoc.Value.Year = be.fechadoc.Value.Year And
        '                    det.documentoventaTransporte.fechadoc.Value.Month = be.fechadoc.Value.Month And
        '                    det.documentoventaTransporte.fechadoc.Value.Day = be.fechadoc.Value.Day And
        '                  det.documentoventaTransporte.tipoVenta = "ENDAS"
        '                Group New With {det.documentoventaTransporte, e, per, det} By
        '                  IdDocumento = CType(det.documentoventaTransporte.idDocumento, Int32?),
        '                  Fechadoc = CType(det.documentoventaTransporte.fechadoc, DateTime?),
        '                  det.documentoventaTransporte.ciudadOrigen,
        '                  Remitente = e.nombreCompleto,
        '                  det.documentoventaTransporte.ciudadDestino,
        '                  Consignado = per.nombreCompleto,
        '                  det.documentoventaTransporte.estadoCobro,
        '                    det.documentoventaTransporte.EnvioSunat,
        '                    det.documentoventaTransporte.tipoDocumento,
        '                  Estado = CType(det.documentoventaTransporte.estado, Int32?),
        '                  Total = CType(det.documentoventaTransporte.total, Decimal?)
        '                 Into g = Group
        '                Select
        '                  IdDocumento = CType(IdDocumento, Int32?),
        '                  Fechadoc = CType(Fechadoc, DateTime?),
        '                  ciudadOrigen,
        '                  Remitente,
        '                  ciudadDestino,
        '                  Consignado,
        '                  items = CType(g.Count(Function(p) p.det.secuencia <> Nothing), Int64?),
        '                  Total = CType(Total, Decimal?),
        '                  estadoCobro,
        '                    EnvioSunat,
        '                    tipoDocumento,
        '                  Estado = CType(Estado, Int32?))

        GetConsultaEncomiendasSelMes = New List(Of documentoventaTransporte)
        For Each i In consulta
            GetConsultaEncomiendasSelMes.Add(New documentoventaTransporte With
                                            {
                                            .idDocumento = i.IdDocumento,
                                            .comprador = i.Comprador,
                                            .fechadoc = i.Fechadoc,
                                            .ciudadOrigen = i.ciudadOrigen,
                                            .Remitente = i.Remitente,
                                            .ciudadDestino = i.ciudadDestino,
                                            .Consignado = i.Consignado,
                                            .itemsEnviados = i.totalitems,
                                            .total = i.Total,
                                            .estadoCobro = i.estadoCobro,
                                            .EnvioSunat = i.EnvioSunat,
                                            .tipoDocumento = i.tipoDocumento,
                                            .serie = i.Serieventa,
                                            .numero = i.Numeroventa,
                                            .estado = i.Estado
                                            })
        Next


    End Function


    Public Function GetConsultaTransporteSelMes(be As documentoventaTransporte) As List(Of documentoventaTransporte)
        Try


            Dim lista As New List(Of String)
            lista.Add("ENDAS")
            lista.Add("VPSJ")

            Dim consulta = (From vt In HeliosData.documentoventaTransporteDetalle
                            Join ent In HeliosData.entidad On New With {.IdEntidad = CInt(vt.documentoventaTransporte.razonSocial)} Equals New With {.IdEntidad = ent.idEntidad}
                            Group Join per In HeliosData.entidad On New With {.IdEntidad = CInt(vt.documentoventaTransporte.idPersona)} Equals New With {.IdEntidad = per.idEntidad} Into per_join = Group
                            From per In per_join.DefaultIfEmpty()
                            Where
                                 vt.documentoventaTransporte.idEmpresa = be.idEmpresa And
                                vt.documentoventaTransporte.idOrganizacion = be.idOrganizacion And
                                vt.documentoventaTransporte.fechadoc.Value.Year = be.fechadoc.Value.Year And
                                vt.documentoventaTransporte.fechadoc.Value.Month = be.fechadoc.Value.Month And
                                lista.Contains(vt.documentoventaTransporte.tipoVenta)
                            Group New With {vt.documentoventaTransporte, ent, per, vt} By
                                Comprador = vt.documentoventaTransporte.comprador,
                                Serieventa = vt.documentoventaTransporte.serie,
                                Numeroventa = vt.documentoventaTransporte.numero,
                                IdDocumento = CType(vt.documentoventaTransporte.idDocumento, Int32?),
                                Fechadoc = CType(vt.documentoventaTransporte.fechadoc, DateTime?),
                                vt.documentoventaTransporte.ciudadOrigen,
                                ent.nombreCompleto,
                                ent.nrodoc,
                                vt.documentoventaTransporte.ciudadDestino,
                                Column1 = per.nombreCompleto,
                                vt.documentoventaTransporte.estadoCobro,
                                Estado = CType(vt.documentoventaTransporte.estado, Int32?),
                                vt.documentoventaTransporte.EnvioSunat,
                                vt.documentoventaTransporte.tipoDocumento,
                                vt.documentoventaTransporte.tipoVenta,
                                vt.idDistribucion,
                                Total = CType(vt.documentoventaTransporte.total, Decimal?)
                                Into g = Group
                            Select
                                Comprador,
                                Serieventa,
                                Numeroventa,
                                IdDocumento = CType(IdDocumento, Int32?),
                                Fechadoc = CType(Fechadoc, DateTime?),
                                ciudadOrigen,
                                Remitente = nombreCompleto,
                                ciudadDestino,
                                Consignado = Column1,
                                estadoCobro,
                                Estado = CType(Estado, Int32?),
                                EnvioSunat,
                                tipoDocumento,
                                nrodoc,
                                tipoVenta,
                                idDistribucion,
                                Total = CType(Total, Decimal?),
                                totalitems = CType(g.Count(Function(p) p.vt.secuencia <> Nothing), Int64?)
    )

            GetConsultaTransporteSelMes = New List(Of documentoventaTransporte)
            For Each i In consulta
                GetConsultaTransporteSelMes.Add(New documentoventaTransporte With
                                                {
                                                .idDocumento = i.IdDocumento,
                                                .comprador = i.Comprador,
                                                .fechadoc = i.Fechadoc,
                                                .ciudadOrigen = i.ciudadOrigen,
                                                .Remitente = i.Remitente,
                                                .ciudadDestino = i.ciudadDestino,
                                                .Consignado = i.Consignado,
                                                .itemsEnviados = i.totalitems,
                                                .total = i.Total,
                                                .estadoCobro = i.estadoCobro,
                                                .EnvioSunat = i.EnvioSunat,
                                                .tipoDocumento = i.tipoDocumento,
                                                .serie = i.Serieventa,
                                                .nrodoc = i.nrodoc,
                                                .numero = i.Numeroventa,
                                                .tipoVenta = i.tipoVenta,
                                                .idDistribucion = i.idDistribucion.GetValueOrDefault,
                                                .estado = i.Estado
                                                })
            Next
        Catch ex As Exception
            Throw (ex)
        End Try

    End Function

    Public Function GetEncomiendasSelEstadoEntrega(be As documentoventaTransporte) As List(Of documentoventaTransporte)

        Dim consulta = (From det In HeliosData.documentoventaTransporteDetalle
                        Join e In HeliosData.entidad On New With {.IdEntidad = CInt(det.documentoventaTransporte.razonSocial)} Equals New With {.IdEntidad = e.idEntidad}
                        Join per In HeliosData.Persona On New With {.Codigo = CInt(det.documentoventaTransporte.idPersona)} Equals New With {.Codigo = per.codigo}
                        Where
                            det.documentoventaTransporte.idEmpresa = be.idEmpresa And
                            det.documentoventaTransporte.idOrganizacion = be.idOrganizacion And
                            det.documentoventaTransporte.estado = be.estado And
                          det.documentoventaTransporte.tipoVenta = "ENDAS" And det.documentoventaTransporte.estado <> General.Transporte.EncomiendaEstado.Anulado
                        Select
                            det.documentoventaTransporte.serie,
                            det.documentoventaTransporte.numero,
                            IdDocumento = CType(det.documentoventaTransporte.idDocumento, Int32?),
                            Fechadoc = CType(det.documentoventaTransporte.fechadoc, DateTime?),
                            det.documentoventaTransporte.ciudadOrigen,
                            Remitente = e.nombreCompleto,
                            det.documentoventaTransporte.ciudadDestino,
                            Consignado = per.nombreCompleto,
                            det.documentoventaTransporte.estadoCobro,
                            Estado = CType(det.documentoventaTransporte.estado, Int32?),
                            Total = CType(det.documentoventaTransporte.total, Decimal?),
                            det.secuencia,
                            det.detalle,
                            importeDetail = det.importe,
                            det.cantidad)

        GetEncomiendasSelEstadoEntrega = New List(Of documentoventaTransporte)
        For Each i In consulta
            GetEncomiendasSelEstadoEntrega.Add(New documentoventaTransporte With
                                            {
                                            .CustomDocumentoVentaDetalle =
                                             New documentoventaTransporteDetalle With
                                             {
                                             .secuencia = i.secuencia,
                                             .cantidad = i.cantidad,
                                             .detalle = i.detalle,
                                             .importe = i.importeDetail
                                             },
                                            .idDocumento = i.IdDocumento,
                                            .serie = i.serie,
                                            .numero = i.numero,
                                            .fechadoc = i.Fechadoc,
                                            .ciudadOrigen = i.ciudadOrigen,
                                            .Remitente = i.Remitente,
                                            .ciudadDestino = i.ciudadDestino,
                                            .Consignado = i.Consignado,
                                            .itemsEnviados = 0,
                                            .total = i.Total,
                                            .estadoCobro = i.estadoCobro,
                                            .estado = i.Estado
                                            })
        Next


    End Function

    Public Function GetEncomiendasSelEstadoEntregaConteo(be As documentoventaTransporte) As Integer
        'det.idOrganizacion = be.idOrganizacion And
        GetEncomiendasSelEstadoEntregaConteo = 0
        Dim consulta = (From det In HeliosData.documentoventaTransporteDetalle
                        Join doc In HeliosData.documentoventaTransporte
                            On doc.idDocumento Equals det.idDocumento
                        Where
                            doc.idEmpresa = be.idEmpresa And
                            det.estado = be.estado And
                            doc.tipoVenta = "ENDAS" And doc.estado <> General.Transporte.EncomiendaEstado.Anulado).Count

        GetEncomiendasSelEstadoEntregaConteo = consulta


    End Function

    Public Function GetEncomiendasSelEstadoEntregaRDLC(be As documentoventaTransporte) As List(Of documentoventaTransporte)

        Dim consulta = (From det In HeliosData.documentoventaTransporteDetalle
                        Join e In HeliosData.entidad On New With {.IdEntidad = CInt(det.documentoventaTransporte.razonSocial)} Equals New With {.IdEntidad = e.idEntidad}
                        Group Join per In HeliosData.Persona On New With {.Codigo = CInt(det.documentoventaTransporte.idPersona)} Equals New With {.Codigo = per.codigo} Into per_join = Group
                        From per In per_join.DefaultIfEmpty()
                        Where
                            det.documentoventaTransporte.idEmpresa = be.idEmpresa And
                            det.documentoventaTransporte.agenciaDestino_id = be.agenciaDestino_id And
                            det.documentoventaTransporte.estado = be.estado And
                          det.documentoventaTransporte.tipoVenta = "ENDAS" And det.documentoventaTransporte.estado <> General.Transporte.EncomiendaEstado.Anulado
                        Select
                            det.documentoventaTransporte.comprador,
                            det.documentoventaTransporte.serie,
                            det.documentoventaTransporte.numero,
                          IdDocumento = CType(det.documentoventaTransporte.idDocumento, Int32?),
                          Fechadoc = CType(det.documentoventaTransporte.fechadoc, DateTime?),
                          det.documentoventaTransporte.ciudadOrigen,
                          Remitente = e.nombreCompleto,
                          det.documentoventaTransporte.ciudadDestino,
                          Consignado = per.nombreCompleto,
                          det.documentoventaTransporte.estadoCobro,
                          Estado = CType(det.documentoventaTransporte.estado, Int32?),
                          Total = CType(det.documentoventaTransporte.total, Decimal?),
                            det.tipo,
                            det.secuencia,
                            det.detalle,
                            importeDetail = det.importe,
                            det.cantidad)

        GetEncomiendasSelEstadoEntregaRDLC = New List(Of documentoventaTransporte)
        For Each i In consulta
            GetEncomiendasSelEstadoEntregaRDLC.Add(New documentoventaTransporte With
                                            {
                                            .comprador = i.comprador,
                                            .serie = i.serie,
                                            .numero = i.numero,
                                            .tipo = i.tipo,
                                             .Secuencia = i.secuencia,
                                             .Cantidad = i.cantidad,
                                             .ContenidoEnviado = i.detalle,
                                             .CostoDetalle = i.importeDetail,
                                            .idDocumento = i.IdDocumento,
                                            .fechadoc = i.Fechadoc,
                                            .ciudadOrigen = i.ciudadOrigen,
                                            .Remitente = i.Remitente,
                                            .ciudadDestino = i.ciudadDestino,
                                            .Consignado = i.Consignado,
                                            .itemsEnviados = 0,
                                            .total = i.Total,
                                            .estadoCobro = i.estadoCobro,
                                            .estado = i.Estado
                                            })
        Next


    End Function


    Public Function GetMovimientosByProgramacion(be As documentoventaTransporte) As List(Of documentoventaTransporte)
        Dim obj As documentoventaTransporteDetalle
        Dim ListaDetalle As List(Of documentoventaTransporteDetalle)


        Dim con = (From n In HeliosData.documentoventaTransporte.Include("documentoventaTransporteDetalle")
                   Where n.programacion_id = be.programacion_id And
                       n.tipoVenta = be.tipoVenta
                   Select
                           n.idDocumento,
                           n.fechadoc,
                           n.tipoDocumento,
                           n.serie,
                           n.numero,
                           n.numeroAsiento,
                           n.total,
                       n.estado,
                           n.documentoventaTransporteDetalle).ToList

        GetMovimientosByProgramacion = New List(Of documentoventaTransporte)
        For Each i In con

            ListaDetalle = New List(Of documentoventaTransporteDetalle)
            For Each c In i.documentoventaTransporteDetalle
                obj = New documentoventaTransporteDetalle With
                {
                .secuencia = c.secuencia,
                .detalle = c.detalle,
                .unidadMedida = c.unidadMedida,
                .tipo = c.tipo,
                .importe = c.importe,
                .estado = c.estado
                }
                ListaDetalle.Add(obj)
            Next

            GetMovimientosByProgramacion.Add(New documentoventaTransporte With
                                             {
                                             .idDocumento = i.idDocumento,
                                             .fechadoc = i.fechadoc,
                                             .tipoDocumento = i.tipoDocumento,
                                             .serie = i.serie,
                                             .numero = i.numero,
                                             .numeroAsiento = i.numeroAsiento,
                                             .total = i.total,
                                             .estado = i.estado,
                                             .documentoventaTransporteDetalle = ListaDetalle
                                             })
        Next


    End Function

    Public Function GetConsultaEncomiendasFechaProgramada(be As documentoventaTransporte) As List(Of documentoventaTransporte)

        Dim consulta = (From det In HeliosData.documentoventaTransporte.Include("documentoventaTransporteDetalle")
                        Join e In HeliosData.entidad On New With {.IdEntidad = CInt(det.razonSocial)} Equals New With {.IdEntidad = e.idEntidad}
                        Join per In HeliosData.Persona On New With {.Codigo = CInt(det.idPersona)} Equals New With {.Codigo = per.codigo}
                        Where
                            det.idEmpresa = be.idEmpresa And
                            det.idOrganizacion = be.idOrganizacion And
                            det.programacion_id = be.programacion_id And
                            det.tipoVenta = "ENDAS"
                        Select
                          IdDocumento = CType(det.idDocumento, Int32?),
                          Fechadoc = CType(det.fechadoc, DateTime?),
                          det.ciudadOrigen,
                            det.razonSocial,
                          Remitente = e.nombreCompleto,
                          det.ciudadDestino,
                            det.idPersona,
                          Consignado = per.nombreCompleto,
                          det.estadoCobro,
                          Estado = CType(det.estado, Int32?),
                          Total = CType(det.total, Decimal?),
                            det.documentoventaTransporteDetalle)

        GetConsultaEncomiendasFechaProgramada = New List(Of documentoventaTransporte)
        Dim obj As documentoventaTransporteDetalle
        Dim LisatDetalle As List(Of documentoventaTransporteDetalle)


        For Each i In consulta

            LisatDetalle = New List(Of documentoventaTransporteDetalle)
            For Each d In i.documentoventaTransporteDetalle
                obj = New documentoventaTransporteDetalle With
                {
                .detalle = d.detalle,
                .secuencia = d.secuencia
                }
                LisatDetalle.Add(obj)
            Next

            GetConsultaEncomiendasFechaProgramada.Add(New documentoventaTransporte With
                                            {
                                            .razonSocial = i.razonSocial,
                                            .idPersona = i.idPersona,
                                            .idDocumento = i.IdDocumento,
                                            .fechadoc = i.Fechadoc,
                                            .ciudadOrigen = i.ciudadOrigen,
                                            .Remitente = i.Remitente,
                                            .ciudadDestino = i.ciudadDestino,
                                            .Consignado = i.Consignado,
                                            .total = i.Total,
                                            .estadoCobro = i.estadoCobro,
                                            .estado = i.Estado,
                                            .documentoventaTransporteDetalle = LisatDetalle
                                            })
        Next


    End Function

    Public Function DocumentoTransporteSelID(be As documentoventaTransporte) As documentoventaTransporte
        DocumentoTransporteSelID = New documentoventaTransporte
        'Group Join per In HeliosData.Persona On New With {.Codigo = CInt(det.idPersona)} Equals New With {.Codigo = per.codigo} Into per_join = Group
        Dim consulta = (From det In HeliosData.documentoventaTransporte.Include("documentoventaTransporteDetalle")
                        Join e In HeliosData.entidad On New With {.IdEntidad = CInt(det.razonSocial)} Equals New With {.IdEntidad = e.idEntidad}
                        Group Join per In HeliosData.Persona On New With {.Codigo = CInt(det.idPersona)} Equals New With {.Codigo = per.codigo} Into per_join = Group
                        From per In per_join.DefaultIfEmpty()
                        Where
                            det.idDocumento = be.idDocumento
                        Select
                            per,
                            det.idOrganizacion,
                            det.agenciaDestino_id,
                            det.serie,
                            det.numero,
                            det.tipoDocumento,
                            det.comprador,
                            IdDocumento = CType(det.idDocumento, Int32?),
                            Fechadoc = CType(det.fechadoc, DateTime?),
                            det.ciudadOrigen,
                            det.razonSocial,
                            Remitente = e.nombreCompleto,
                            det.ciudadDestino,
                            det.idPersona,
                            det.telefonoRemitente,
                            det.fechaProgramada,
                            det.telefonoConsignado,
                            Consignado = per.nombreCompleto,
                            det.estadoCobro,
                            det.edad,
                            Estado = CType(det.estado, Int32?),
                            igv = CType(det.igv1, Decimal?),
                            bi01 = CType(det.baseImponible1, Decimal?),
                            bi02 = CType(det.baseImponible2, Decimal?),
                            Total = CType(det.total, Decimal?),
                            det.documentoventaTransporteDetalle).ToList


        Dim obj As documentoventaTransporteDetalle
        Dim LisatDetalle As List(Of documentoventaTransporteDetalle)
        Dim objpersona As New Persona
        For Each i In consulta

            If i.per IsNot Nothing Then
                objpersona = New Persona With
                {
                   .idPersona = i.per.idPersona,
                .nombreCompleto = i.per.nombreCompleto,
                .codigo = i.per.codigo
                }
            End If

            LisatDetalle = New List(Of documentoventaTransporteDetalle)
            For Each d In i.documentoventaTransporteDetalle
                obj = New documentoventaTransporteDetalle With
                {
                .detalle = d.detalle,
                .secuencia = d.secuencia,
                .cantidad = d.cantidad,
                .tipo = d.tipo,
                .unidadMedida = d.unidadMedida,
                .importe = d.importe,
                 .manifiesto = d.manifiesto
                }
                LisatDetalle.Add(obj)
            Next

            DocumentoTransporteSelID = New documentoventaTransporte With
                                            {
                                            .idOrganizacion = i.idOrganizacion,
                                            .agenciaDestino_id = i.agenciaDestino_id,
                                            .comprador = i.comprador,
                                            .razonSocial = i.razonSocial,
                                            .idPersona = i.idPersona,
                                            .idDocumento = i.IdDocumento,
                                            .serie = i.serie,
                                            .numero = i.numero,
                                            .tipoDocumento = i.tipoDocumento,
                                            .fechadoc = i.Fechadoc,
                                            .ciudadOrigen = i.ciudadOrigen,
                                            .Remitente = i.Remitente,
                                            .ciudadDestino = i.ciudadDestino,
                                            .Consignado = i.Consignado,
                                            .baseImponible1 = i.bi01,
                                            .baseImponible2 = i.bi02,
                                            .igv1 = i.igv,
                                            .fechaProgramada = i.fechaProgramada,
                                            .total = i.Total,
                                            .edad = i.edad,
                                            .estadoCobro = i.estadoCobro,
                                            .estado = i.Estado,
                                            .telefonoConsignado = i.telefonoConsignado,
                                            .telefonoRemitente = i.telefonoRemitente,
                                            .documentoventaTransporteDetalle = LisatDetalle,
                                            .CustomPerson = objpersona
            }
        Next

    End Function

    Public Function DocumentoTransporteSelIDVer2(be As documentoventaTransporte) As documentoventaTransporte
        DocumentoTransporteSelIDVer2 = New documentoventaTransporte
        'Group Join per In HeliosData.Persona On New With {.Codigo = CInt(det.idPersona)} Equals New With {.Codigo = per.codigo} Into per_join = Group
        Dim consulta = (From det In HeliosData.documentoventaTransporte.Include("documentoventaTransporteDetalle")
                        Join e In HeliosData.entidad On New With {.IdEntidad = CInt(det.razonSocial)} Equals New With {.IdEntidad = e.idEntidad}
                        Group Join per In HeliosData.entidad On New With {.IdEntidad = CInt(det.idPersona)} Equals New With {.IdEntidad = per.idEntidad} Into per_join = Group
                        From per In per_join.DefaultIfEmpty()
                        Where
                            det.idDocumento = be.idDocumento
                        Select
                            per,
                            det.idOrganizacion,
                            det.agenciaDestino_id,
                            det.serie,
                            det.numero,
                            det.tipoDocumento,
                            det.comprador,
                            IdDocumento = CType(det.idDocumento, Int32?),
                            Fechadoc = CType(det.fechadoc, DateTime?),
                            det.ciudadOrigen,
                            det.razonSocial,
                            Remitente = e.nombreCompleto,
                            det.ciudadDestino,
                            det.idPersona,
                            det.telefonoRemitente,
                            det.fechaProgramada,
                            det.telefonoConsignado,
                            Consignado = per.nombreCompleto,
                            det.estadoCobro,
                            det.edad,
                            det.numeroAsiento,
                            det.nroPlaca,
                                      det.UbigeoCiudadDestino,
                            det.UbigeoCiudadOrigen,
                            Estado = CType(det.estado, Int32?),
                            igv = CType(det.igv1, Decimal?),
                            bi01 = CType(det.baseImponible1, Decimal?),
                            bi02 = CType(det.baseImponible2, Decimal?),
                            Total = CType(det.total, Decimal?),
                            det.documentoventaTransporteDetalle).ToList


        Dim obj As documentoventaTransporteDetalle
        Dim LisatDetalle As List(Of documentoventaTransporteDetalle)
        Dim objpersona As New Persona
        For Each i In consulta

            If i.per IsNot Nothing Then
                objpersona = New Persona With
                {
                .idPersona = i.per.nrodoc,
                .nombreCompleto = i.per.nombreCompleto,
                .codigo = i.per.idEntidad
                }
            End If

            LisatDetalle = New List(Of documentoventaTransporteDetalle)
            For Each d In i.documentoventaTransporteDetalle
                obj = New documentoventaTransporteDetalle With
                {
                .detalle = d.detalle,
                .secuencia = d.secuencia,
                .cantidad = d.cantidad,
                .tipo = d.tipo,
                .destino = d.destino,
                .sku = d.sku,
                .codigoBarraSerie = d.codigoBarraSerie,
                .unidadMedida = d.unidadMedida,
                .importe = d.importe,
                 .manifiesto = d.manifiesto
                }
                LisatDetalle.Add(obj)
            Next

            DocumentoTransporteSelIDVer2 = New documentoventaTransporte With
                                            {
                                            .idOrganizacion = i.idOrganizacion,
                                            .agenciaDestino_id = i.agenciaDestino_id,
                                            .comprador = i.comprador,
                                            .razonSocial = i.razonSocial,
                                            .idPersona = i.idPersona,
                                            .idDocumento = i.IdDocumento,
                                            .serie = i.serie,
                                            .numero = i.numero,
                                            .tipoDocumento = i.tipoDocumento,
                                            .fechadoc = i.Fechadoc,
                                            .ciudadOrigen = i.ciudadOrigen,
                                            .Remitente = i.Remitente,
                                            .ciudadDestino = i.ciudadDestino,
                                            .Consignado = i.Consignado,
                                            .baseImponible1 = i.bi01,
                                            .baseImponible2 = i.bi02,
                                            .igv1 = i.igv,
                                            .fechaProgramada = i.fechaProgramada,
                                            .total = i.Total,
                                            .edad = i.edad,
                                            .UbigeoCiudadDestino = i.UbigeoCiudadDestino,
                                            .UbigeoCiudadOrigen = i.UbigeoCiudadOrigen,
                                            .estadoCobro = i.estadoCobro,
                                            .estado = i.Estado,
                                            .nroPlaca = i.nroPlaca,
                                            .numeroAsiento = i.numeroAsiento,
                                            .telefonoConsignado = i.telefonoConsignado,
                                            .telefonoRemitente = i.telefonoRemitente,
                                            .documentoventaTransporteDetalle = LisatDetalle,
                                            .CustomPerson = objpersona
            }
        Next

    End Function

    Public Function DocumentoTransporteSelIDVehiculoXProg(be As documentoventaTransporte) As documentoventaTransporte
        DocumentoTransporteSelIDVehiculoXProg = New documentoventaTransporte
        'Group Join per In HeliosData.Persona On New With {.Codigo = CInt(det.idPersona)} Equals New With {.Codigo = per.codigo} Into per_join = Group
        Dim consulta = (From det In HeliosData.documentoventaTransporte.Include("documentoventaTransporteDetalle")
                        Join e In HeliosData.entidad On New With {.IdEntidad = CInt(det.razonSocial)} Equals New With {.IdEntidad = e.idEntidad}
                        Group Join per In HeliosData.entidad On New With {.IdEntidad = CInt(det.idPersona)} Equals New With {.IdEntidad = per.idEntidad} Into per_join = Group
                        From per In per_join.DefaultIfEmpty()
                        Where
                            det.numeroAsiento = be.idDistribucion And
                            det.programacion_id = be.programacion_id
                        Select
                            per,
                            det.idOrganizacion,
                            det.agenciaDestino_id,
                            det.serie,
                            det.numero,
                            det.tipoDocumento,
                            det.comprador,
                            IdDocumento = CType(det.idDocumento, Int32?),
                            Fechadoc = CType(det.fechadoc, DateTime?),
                            det.ciudadOrigen,
                            det.razonSocial,
                            Remitente = e.nombreCompleto,
                            det.ciudadDestino,
                            det.UbigeoCiudadDestino,
                            det.UbigeoCiudadOrigen,
                            det.idPersona,
                            det.telefonoRemitente,
                            det.fechaProgramada,
                            det.telefonoConsignado,
                            Consignado = per.nombreCompleto,
                            det.estadoCobro,
                            det.edad,
                            det.numeroAsiento,
                            Estado = CType(det.estado, Int32?),
                            igv = CType(det.igv1, Decimal?),
                            bi01 = CType(det.baseImponible1, Decimal?),
                            bi02 = CType(det.baseImponible2, Decimal?),
                            Total = CType(det.total, Decimal?),
                            det.documentoventaTransporteDetalle).ToList


        Dim obj As documentoventaTransporteDetalle
        Dim LisatDetalle As List(Of documentoventaTransporteDetalle)
        Dim objpersona As New Persona
        For Each i In consulta

            If i.per IsNot Nothing Then
                objpersona = New Persona With
                {
                .idPersona = i.per.nrodoc,
                .nombreCompleto = i.per.nombreCompleto,
                .codigo = i.per.idEntidad
                }
            End If

            LisatDetalle = New List(Of documentoventaTransporteDetalle)
            For Each d In i.documentoventaTransporteDetalle
                obj = New documentoventaTransporteDetalle With
                {
                .detalle = d.detalle,
                .secuencia = d.secuencia,
                .cantidad = d.cantidad,
                .tipo = d.tipo,
                .unidadMedida = d.unidadMedida,
                .importe = d.importe,
                 .manifiesto = d.manifiesto,
                 .destino = d.destino
                }
                LisatDetalle.Add(obj)
            Next

            DocumentoTransporteSelIDVehiculoXProg = New documentoventaTransporte With
                                            {
                                            .idOrganizacion = i.idOrganizacion,
                                            .agenciaDestino_id = i.agenciaDestino_id,
                                            .comprador = i.comprador,
                                            .razonSocial = i.razonSocial,
                                            .idPersona = i.idPersona,
                                            .idDocumento = i.IdDocumento,
                                            .serie = i.serie,
                                            .numero = i.numero,
                                            .tipoDocumento = i.tipoDocumento,
                                            .fechadoc = i.Fechadoc,
                                            .ciudadOrigen = i.ciudadOrigen,
                                            .Remitente = i.Remitente,
                                            .ciudadDestino = i.ciudadDestino,
                                            .Consignado = i.Consignado,
                                            .baseImponible1 = i.bi01,
                                            .baseImponible2 = i.bi02,
                                            .igv1 = i.igv,
                                            .UbigeoCiudadDestino = i.UbigeoCiudadDestino,
                                            .UbigeoCiudadOrigen = i.UbigeoCiudadOrigen,
                                            .fechaProgramada = i.fechaProgramada,
                                            .total = i.Total,
                                            .edad = i.edad,
                                            .estadoCobro = i.estadoCobro,
                                            .estado = i.Estado,
                                            .numeroAsiento = i.numeroAsiento,
                                            .telefonoConsignado = i.telefonoConsignado,
                                            .telefonoRemitente = i.telefonoRemitente,
                                            .documentoventaTransporteDetalle = LisatDetalle,
                                            .CustomPerson = objpersona
            }
        Next

    End Function

    Public Function DocumentoTransportePasajesSelID(be As documentoventaTransporte) As List(Of documentoventaTransporte)
        DocumentoTransportePasajesSelID = New List(Of documentoventaTransporte)
        Dim consulta = (From det In HeliosData.documentoventaTransporte.Include("documentoventaTransporteDetalle")
                        Join e In HeliosData.entidad On New With {.IdEntidad = CInt(det.razonSocial)} Equals New With {.IdEntidad = e.idEntidad}
                        Group Join per In HeliosData.entidad On New With {.IdEntidad = CInt(det.idPersona)} Equals New With {.IdEntidad = per.idEntidad} Into per_join = Group
                        From per In per_join.DefaultIfEmpty()
                        Where
                         det.programacion_id = be.programacion_id
                        Select
                            per,
                            det.idOrganizacion,
                            det.agenciaDestino_id,
                            det.serie,
                            det.numero,
                            det.tipoDocumento,
                            det.comprador,
                            IdDocumento = CType(det.idDocumento, Int32?),
                            Fechadoc = CType(det.fechadoc, DateTime?),
                            det.ciudadOrigen,
                            det.razonSocial,
                            Remitente = e.nombreCompleto,
                            det.ciudadDestino,
                            det.numeroAsiento,
                            det.idPersona,
                            det.telefonoRemitente,
                            det.fechaProgramada,
                            det.telefonoConsignado,
                            Consignado = per.nombreCompleto,
                            det.estadoCobro,
                            det.edad,
                                                        Estado = CType(det.estado, Int32?),
                            igv = CType(det.igv1, Decimal?),
                            bi01 = CType(det.baseImponible1, Decimal?),
                            bi02 = CType(det.baseImponible2, Decimal?),
                            Total = CType(det.total, Decimal?),
                            det.documentoventaTransporteDetalle).ToList


        Dim obj As documentoventaTransporteDetalle
        Dim LisatDetalle As List(Of documentoventaTransporteDetalle)
        Dim objpersona As New Persona
        For Each i In consulta

            If i.per IsNot Nothing Then
                objpersona = New Persona With
                {
                  .idPersona = i.per.nrodoc,
                .nombreCompleto = i.per.nombreCompleto,
                .codigo = i.per.idEntidad
                            }
            End If
            '.idPersona = i.per.idPersona,
            '    .nombreCompleto = i.per.nombreCompleto,
            '    .codigo = i.per.codigo
            LisatDetalle = New List(Of documentoventaTransporteDetalle)
            For Each d In i.documentoventaTransporteDetalle
                obj = New documentoventaTransporteDetalle With
                {
                .detalle = d.detalle,
                .secuencia = d.secuencia,
                .cantidad = d.cantidad,
                .tipo = d.tipo,
                .unidadMedida = d.unidadMedida,
                .importe = d.importe,
                .manifiesto = d.manifiesto
                }
                LisatDetalle.Add(obj)
            Next

            DocumentoTransportePasajesSelID.Add(New documentoventaTransporte With
                                            {
                                            .idOrganizacion = i.idOrganizacion,
                                            .agenciaDestino_id = i.agenciaDestino_id,
                                            .comprador = i.comprador,
                                            .razonSocial = i.razonSocial,
                                            .idPersona = i.idPersona,
                                            .idDocumento = i.IdDocumento,
                                            .serie = i.serie,
                                            .numero = i.numero,
                                            .tipoDocumento = i.tipoDocumento,
                                            .fechadoc = i.Fechadoc,
                                            .ciudadOrigen = i.ciudadOrigen,
                                            .Remitente = i.Remitente,
                                            .ciudadDestino = i.ciudadDestino,
                                            .Consignado = i.Consignado,
                                            .baseImponible1 = i.bi01,
                                            .baseImponible2 = i.bi02,
                                            .igv1 = i.igv,
                                            .numeroAsiento = i.numeroAsiento,
                                            .fechaProgramada = i.fechaProgramada,
                                            .total = i.Total,
                                            .estadoCobro = i.estadoCobro,
                                            .estado = i.Estado,
                                            .edad = i.edad,
                                            .telefonoConsignado = i.telefonoConsignado,
                                            .telefonoRemitente = i.telefonoRemitente,
                                            .documentoventaTransporteDetalle = LisatDetalle,
                                            .CustomPerson = objpersona
            })
        Next

    End Function

    Private Shared Sub Part_Documento(ByRef objDocumento As documento)
        Dim DocumentoBL As New documentoBL
        Dim numeracionBL As New numeracionBoletasBL
        Dim cval As Integer = 0

        If objDocumento.documentoventaTransporte.IdNumeracion > 0 Then
            cval = Convert.ToInt32(numeracionBL.GenerarNumeroPorID(objDocumento.documentoventaTransporte.IdNumeracion))
            cval = cval
            objDocumento.nroDoc = objDocumento.documentoventaTransporte.serie & "-" & cval
            objDocumento.documentoventaTransporte.numero = cval
        Else
            objDocumento.nroDoc = objDocumento.documentoventaTransporte.serie & "-" & objDocumento.documentoventaTransporte.numero
            objDocumento.documentoventaTransporte.numero = objDocumento.documentoventaTransporte.numero
        End If


        DocumentoBL.Insert(objDocumento)
        objDocumento.idDocumento = objDocumento.idDocumento
        Select Case objDocumento.IsFormatoGeneral
            Case True
                objDocumento.CustomSerie = objDocumento.documentoventaTransporte.serie
                objDocumento.CustomNumero = objDocumento.documentoventaTransporte.numero
            Case False
                objDocumento.CustomSerie = objDocumento.documentoventaTransporte.serie
                objDocumento.CustomNumero = cval
        End Select

    End Sub

    Private Shared Sub Part_DocumentoV2(ByRef objDocumento As documento)
        Dim DocumentoBL As New documentoBL
        Dim numeracionBL As New numeracionBoletasBL
        Dim cval As Integer = 0

        ' Dim serieConfigurada As String = String.Empty
        Dim codigoSeguridad As String = String.Empty
        Select Case objDocumento.tipoDoc
            Case "03"
                '      serieConfigurada = "B001"
                codigoSeguridad = "VT2E"
            Case "01"
                '     serieConfigurada = "F001"
                codigoSeguridad = "VT3E"
        End Select

        'Dim nuevoNumero = numeracionBL.ObtenerDocumentoPorEstablecimiento(objDocumento.idCentroCosto, serieConfigurada, codigoSeguridad, objDocumento.tipoDoc)

        Dim nuevoNumero = numeracionBL.NumeracionBoletasSel(objDocumento.idCentroCosto, codigoSeguridad, objDocumento.tipoDoc)


        cval = Convert.ToInt32(numeracionBL.GenerarNumeroPorID(nuevoNumero.IdEnumeracion))
        cval = cval
        objDocumento.nroDoc = nuevoNumero.serie & "-" & cval 'serieConfigurada
        objDocumento.documentoventaTransporte.serie = nuevoNumero.serie 'serieConfigurada
        objDocumento.documentoventaTransporte.numero = cval

        DocumentoBL.Insert(objDocumento)
        objDocumento.idDocumento = objDocumento.idDocumento
        Select Case objDocumento.IsFormatoGeneral
            Case True
                objDocumento.CustomSerie = nuevoNumero.serie ' serieConfigurada
                objDocumento.CustomNumero = objDocumento.documentoventaTransporte.numero
            Case False
                objDocumento.CustomSerie = nuevoNumero.serie 'serieConfigurada
                objDocumento.CustomNumero = cval
        End Select

    End Sub

    Public Sub InsertSingleContado(ByVal documentoventaAbarrotesBE As documentoventaTransporte, intIdDocmento As Integer)
        Dim docVentaAbarrotes As New documentoventaTransporte
        'Dim numeracionBL As New numeracionBoletasBL
        'Dim cval As Integer = 0
        Using ts As New TransactionScope
            docVentaAbarrotes = New documentoventaTransporte With
            {
            .idDocumento = intIdDocmento,
            .tareo_id = 1,
            .agenciaDestino_id = documentoventaAbarrotesBE.agenciaDestino_id,
            .tipoOperacion = documentoventaAbarrotesBE.tipoOperacion,
            .idEmpresa = documentoventaAbarrotesBE.idEmpresa,
            .idOrganizacion = documentoventaAbarrotesBE.idOrganizacion,
            .programacion_id = documentoventaAbarrotesBE.programacion_id,
            .UbigeoCiudadOrigen = documentoventaAbarrotesBE.UbigeoCiudadOrigen,
            .ciudadOrigen = documentoventaAbarrotesBE.ciudadOrigen,
            .UbigeoCiudadDestino = documentoventaAbarrotesBE.UbigeoCiudadDestino,
            .ciudadDestino = documentoventaAbarrotesBE.ciudadDestino,
            .tipoDocumento = documentoventaAbarrotesBE.tipoDocumento,
            .fechaProgramada = documentoventaAbarrotesBE.fechaProgramada,
            .fechadoc = documentoventaAbarrotesBE.fechadoc,
            .fechaVcto = documentoventaAbarrotesBE.fechaVcto,
            .serie = documentoventaAbarrotesBE.serie,
            .numero = documentoventaAbarrotesBE.numero,
            .razonSocial = documentoventaAbarrotesBE.razonSocial,
            .idPersona = documentoventaAbarrotesBE.idPersona,
            .comprador = documentoventaAbarrotesBE.comprador,
            .moneda = documentoventaAbarrotesBE.moneda,
            .tipocambio = documentoventaAbarrotesBE.tipocambio,
            .tasaIgv = documentoventaAbarrotesBE.tasaIgv,
            .baseImponible1 = documentoventaAbarrotesBE.baseImponible1,
            .baseImponible2 = documentoventaAbarrotesBE.baseImponible2,
            .igv1 = documentoventaAbarrotesBE.igv1,
            .igv2 = documentoventaAbarrotesBE.igv2,
            .total = documentoventaAbarrotesBE.total,
            .estadoCobro = documentoventaAbarrotesBE.estadoCobro,
            .glosa = documentoventaAbarrotesBE.glosa,
            .tipoVenta = documentoventaAbarrotesBE.tipoVenta,
            .numeroAsiento = documentoventaAbarrotesBE.numeroAsiento,
            .estado = documentoventaAbarrotesBE.estado,
              .edad = documentoventaAbarrotesBE.edad,
                     .nroPlaca = documentoventaAbarrotesBE.nroPlaca,
            .idcajaUsuario = documentoventaAbarrotesBE.idcajaUsuario,
            .telefonoConsignado = documentoventaAbarrotesBE.telefonoConsignado,
                 .telefonoRemitente = documentoventaAbarrotesBE.telefonoRemitente,
            .usuarioActualizacion = documentoventaAbarrotesBE.usuarioActualizacion,
            .fechaActualizacion = documentoventaAbarrotesBE.fechaActualizacion
            }

            HeliosData.documentoventaTransporte.Add(docVentaAbarrotes)
            HeliosData.SaveChanges()
            ts.Complete()
            documentoventaAbarrotesBE.idDocumento = docVentaAbarrotes.idDocumento
            documentoventaAbarrotesBE.numero = docVentaAbarrotes.numero
        End Using
    End Sub

    Public Function DocumentoventaTransporteSave(objDocumento As documento) As Integer
        Dim asientoBL As New AsientoBL
        Dim anticipoBL As New DocumentoAnticipoConciliacionBL
        Dim docDetBL As New documentoventaTransporteDetalleBL
        Dim docDetBE As New documentoventaTransporteDetalle
        Dim codDocumentoVenta As Integer
        Try
            Using ts As New TransactionScope()

                Dim usuarioIDCaja = objDocumento.IDCajaUsuario
                Dim EscajaActiva = HeliosData.cajaUsuario.Any(Function(o) o.idcajaUsuario = usuarioIDCaja And o.estadoCaja = "A")


                Dim CONSULTA = (From det In HeliosData.documentoventaTransporte Where det.numeroAsiento = objDocumento.documentoventaTransporte.numeroAsiento And
                                                                                    det.programacion_id = objDocumento.documentoventaTransporte.programacion_id And
                                                                                    det.estadoCobro = "DC" And det.tipoVenta = "VPSJ").Count

                If EscajaActiva Then
                    If (CONSULTA = 0) Then
                        objDocumento.fechaActualizacion = DateTime.Now
                        'Documento insertado
                        Part_DocumentoV2(objDocumento)
                        codDocumentoVenta = objDocumento.idDocumento
                        'Documento venta
                        InsertSingleContado(objDocumento.documentoventaTransporte, objDocumento.idDocumento)
                        docDetBL.InsertarDocTransporteDet(objDocumento.documentoventaTransporte.documentoventaTransporteDetalle, codDocumentoVenta)
                        PagoDeLaVentaSinLote(objDocumento, objDocumento.documentoventaTransporte)

                        'objDocumento.documentoventaTransporte.CustomVehiculoAsiento_Precios.idDocumentoVenta = codDocumentoVenta
                        'DocumentoventaTransporteSaveVehiculoAsiento(objDocumento.documentoventaTransporte.CustomVehiculoAsiento_Precios)

                        HeliosData.SaveChanges()
                        ts.Complete()
                    Else
                        Throw New Exception("Asiento Registrado")
                    End If
                Else
                    Throw New Exception("El usuario no tiene una caja activa!")
                End If



                Return codDocumentoVenta 'objDocumento.idDocumento
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function DocumentoventaTransporteReservacionSave(objDocumento As documento, idDocumentoREf As Integer) As Integer
        Dim asientoBL As New AsientoBL
        Dim anticipoBL As New DocumentoAnticipoConciliacionBL
        Dim docDetBL As New documentoventaTransporteDetalleBL
        Dim docDetBE As New documentoventaTransporteDetalle
        Dim codDocumentoVenta As Integer
        Try
            Using ts As New TransactionScope()

                Dim usuarioIDCaja = objDocumento.IDCajaUsuario
                Dim EscajaActiva = HeliosData.cajaUsuario.Any(Function(o) o.idcajaUsuario = usuarioIDCaja And o.estadoCaja = "A")

                If EscajaActiva Then
                    Dim EliminarReserva = (From det In HeliosData.documento Where det.idDocumento = idDocumentoREf).FirstOrDefault

                    If (Not IsNothing(EliminarReserva)) Then
                        CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(EliminarReserva)
                        HeliosData.SaveChanges()

                        Dim CONSULTA = (From det In HeliosData.documentoventaTransporte Where det.numeroAsiento = objDocumento.documentoventaTransporte.numeroAsiento And
                                                                                        det.programacion_id = objDocumento.documentoventaTransporte.programacion_id And
                                                                                        det.estadoCobro = "DC" And det.tipoVenta = "VPSJ").Count

                        If (CONSULTA = 0) Then
                            objDocumento.fechaActualizacion = DateTime.Now
                            'Documento insertado
                            Part_DocumentoV2(objDocumento)
                            codDocumentoVenta = objDocumento.idDocumento
                            'Documento venta
                            InsertSingleContado(objDocumento.documentoventaTransporte, objDocumento.idDocumento)
                            docDetBL.InsertarDocTransporteDet(objDocumento.documentoventaTransporte.documentoventaTransporteDetalle, codDocumentoVenta)
                            PagoDeLaVentaSinLote(objDocumento, objDocumento.documentoventaTransporte)

                            'objDocumento.documentoventaTransporte.CustomVehiculoAsiento_Precios.idDocumentoVenta = codDocumentoVenta
                            'DocumentoventaTransporteSaveVehiculoAsiento(objDocumento.documentoventaTransporte.CustomVehiculoAsiento_Precios)

                            HeliosData.SaveChanges()
                            ts.Complete()
                        Else
                            Throw New Exception("Asiento Registrado")
                        End If
                    Else
                        Throw New Exception("Revisar Venta")
                    End If
                Else
                    Throw New Exception("El usuario no tiene una caja activa!")
                End If



                Return codDocumentoVenta 'objDocumento.idDocumento
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub DocumentoTransporteReservacionEliminar(idDocumentoREf As Integer)
        Try
            Using ts As New TransactionScope()


                Dim EliminarReserva = (From det In HeliosData.documento Where det.idDocumento = idDocumentoREf).FirstOrDefault

                If (Not IsNothing(EliminarReserva)) Then
                    CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(EliminarReserva)
                    HeliosData.SaveChanges()

                Else
                    Throw New Exception("Revisar Venta")
                End If
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Sub ReEnviarFacturaElectronica(idDocumento As Integer, IdPse As String, estado As String)

        Dim documentoSA As New documentoventaAbarrotesBL
        Dim documentoDetSA As New documentoventaAbarrotesDetBL
        Dim entidadSA As New entidadBL
        Dim DetalleFactura As Fact.Sunat.Business.Entity.DocumentoElectronicoDetalle

        Try

            Dim comprobante = DocumentoTransporteSelID(New documentoventaTransporte With {.idDocumento = idDocumento})
            Dim receptor = entidadSA.GetUbicarEntPorID(Gempresas.IdEmpresaRuc, comprobante.razonSocial)
            Dim numerovent As String = String.Format("{0:00000000}", comprobante.numero)
            Dim tipoDoc = String.Format("{0:00}", comprobante.tipoDocumento)
            Dim conteo As Integer = 0

            '//Enviando el documento

            Dim Factura As New Fact.Sunat.Business.Entity.DocumentoElectronico

            'Datos del Cliente 
            Factura.Action = 0
            Factura.idEmpresa = IdPse
            Factura.Contribuyente_id = Gempresas.IdEmpresaRuc
            Factura.EnvioSunat = "NO"
            'Receptor de la Factura
            Factura.NroDocumentoRec = receptor.nrodoc
            Factura.TipoDocumentoRec = receptor.tipoDoc
            Factura.NombreLegalRec = receptor.nombreCompleto
            'Datos Generales De La Factura
            Factura.IdDocumento = comprobante.serie & "-" & numerovent
            Factura.FechaEmision = comprobante.fechadoc
            Factura.FechaRecepcion = DateTime.Now 'fecha en la que se envia al PSE
            Factura.FechaVencimiento = DateTime.Now
            Factura.HoraEmision = comprobante.fechadoc.Value.ToString("HH:mm:ss")
            'If comprobante.moneda = "1" Then
            Factura.Moneda = "PEN"
            'ElseIf comprobante.moneda = "2" Then
            '    Factura.Moneda = "USD"
            'End If
            Factura.TipoDocumento = tipoDoc
            Factura.TotalIgv = comprobante.igv1
            Factura.TotalVenta = comprobante.total
            Factura.Gravadas = comprobante.baseImponible1
            Factura.Exoneradas = comprobante.baseImponible2
            Factura.TipoOperacion = "0101"

            'Cargando el Detalle de la Factura

            For Each i In comprobante.documentoventaTransporteDetalle
                conteo += 1
                Dim preciounit As Decimal = Math.Round(CDec(i.importe / i.cantidad), 2)
                Dim calcbi As Decimal = Math.Round(CDec(CalculoBaseImponible(i.importe, 1.18)), 2)
                Dim calcigv As Decimal = Math.Round(CDec(i.importe - calcbi), 2)

                DetalleFactura = New Fact.Sunat.Business.Entity.DocumentoElectronicoDetalle
                DetalleFactura.Id = conteo
                DetalleFactura.Cantidad = i.cantidad
                DetalleFactura.PrecioReferencial = preciounit 'i.precioUnitario
                DetalleFactura.CodigoItem = i.secuencia
                DetalleFactura.Descripcion = i.detalle
                DetalleFactura.UnidadMedida = i.unidadMedida
                DetalleFactura.Impuesto = calcigv
                ' If i.destino = "1" Then
                DetalleFactura.TipoImpuesto = "10" 'CATALOGO 7
                DetalleFactura.TipoPrecio = "01" 'CATALOGO 16
                DetalleFactura.PrecioUnitario = CalculoBaseImponible(preciounit, 1.18) 'FormatNumber
                'ElseIf i.destino = "2" Then
                '  DetalleFactura.TipoImpuesto = "20" 'CATALOGO 7
                'DetalleFactura.TipoPrecio = "01" '"02"  'CATALOGO 16
                '  DetalleFactura.PrecioUnitario = i.precioUnitario
                'End If
                DetalleFactura.TotalVenta = calcbi 'i.montokardex
                'DetalleItems .Descuento = "falta"
                'DetalleItems .ImpuestoSelectivo = "falta"
                'DetalleItems.OtroImpuesto = "falta"
                'DetalleItems.PlacaVehiculo = "falta"
                Factura.DocumentoElectronicoDetalle.Add(DetalleFactura)
            Next


            'Enviando al PSE
            Dim codigo = Helios.Fact.Sunat.WCFService.ServiceAccess.Admin.DocumentoElectronicoSA.DocumentoElectronicoSave(Factura, Nothing)

            If codigo.idDocumentoElectronico > 0 Then

                UpdateFacturasXEstadoTrans(comprobante.idDocumento, estado)

            End If

        Catch ex As Exception

        End Try


    End Sub


    Public Sub EnvioFacturaElectronica(facturaCab As documentoventaTransporte)

        Try

            Dim entidadSA As New entidadBL
            Dim DetalleFactura As Fact.Sunat.Business.Entity.DocumentoElectronicoDetalle
            Dim receptor = entidadSA.GetUbicarEntPorID(Gempresas.IdEmpresaRuc, facturaCab.razonSocial)
            Dim numerovent As String = String.Format("{0:00000000}", facturaCab.numero)
            Dim tipoDoc = String.Format("{0:00}", facturaCab.tipoDocumento)
            Dim conteo As Integer = 0
            'cabezera de la factura
            Dim Factura As New Fact.Sunat.Business.Entity.DocumentoElectronico
            'Datos del Cliente 
            Factura.Action = 0
            Factura.idEmpresa = facturaCab.idPSE 'idPSE 'lblIdPse.Text
            Factura.Contribuyente_id = Gempresas.IdEmpresaRuc
            Factura.EnvioSunat = "NO"
            'Receptor de la Factura
            Factura.NroDocumentoRec = receptor.nrodoc
            Factura.TipoDocumentoRec = receptor.tipoDoc
            Factura.NombreLegalRec = receptor.nombreCompleto
            'Datos Generales De La Factura
            Factura.IdDocumento = facturaCab.serie & "-" & numerovent
            Factura.FechaEmision = facturaCab.fechadoc
            Factura.FechaRecepcion = DateTime.Now 'fecha en la que se envia al PSE
            Factura.FechaVencimiento = DateTime.Now
            Factura.HoraEmision = facturaCab.fechadoc.Value.ToString("HH:mm:ss")
            'If documneotventaTransporte.moneda = "1" Then
            Factura.Moneda = "PEN"
            'ElseIf documneotventaTransporte.moneda = "2" Then
            '    Factura.Moneda = "USD"
            'End If
            Factura.TipoDocumento = tipoDoc
            Factura.TotalIgv = facturaCab.igv1
            Factura.TotalVenta = facturaCab.total
            Factura.Gravadas = facturaCab.baseImponible1
            Factura.Exoneradas = 0
            Factura.TipoOperacion = "0101"

            'Detalle de la Factura
            For Each i In facturaCab.documentoventaTransporteDetalle
                conteo += 1
                Dim preciounit As Decimal = Math.Round(CDec(i.importe / i.cantidad), 2)
                Dim calcbi As Decimal = Math.Round(CDec(CalculoBaseImponible(i.importe, 1.18)), 2)
                Dim calcigv As Decimal = Math.Round(CDec(i.importe - calcbi), 2)

                DetalleFactura = New Fact.Sunat.Business.Entity.DocumentoElectronicoDetalle
                DetalleFactura.Id = conteo
                DetalleFactura.Cantidad = i.cantidad
                DetalleFactura.PrecioReferencial = preciounit 'i.precioUnitario
                DetalleFactura.CodigoItem = i.secuencia
                DetalleFactura.Descripcion = i.detalle
                DetalleFactura.UnidadMedida = i.unidadMedida
                DetalleFactura.Impuesto = calcigv
                ' If i.destino = "1" Then
                DetalleFactura.TipoImpuesto = "10" 'CATALOGO 7
                DetalleFactura.TipoPrecio = "01" 'CATALOGO 16
                DetalleFactura.PrecioUnitario = CalculoBaseImponible(preciounit, 1.18) 'FormatNumber
                'ElseIf i.destino = "2" Then
                '  DetalleFactura.TipoImpuesto = "20" 'CATALOGO 7
                'DetalleFactura.TipoPrecio = "01" '"02"  'CATALOGO 16
                '  DetalleFactura.PrecioUnitario = i.precioUnitario
                'End If
                DetalleFactura.TotalVenta = calcbi 'i.montokardex
                'DetalleItems .Descuento = "falta"
                'DetalleItems .ImpuestoSelectivo = "falta"
                'DetalleItems.OtroImpuesto = "falta"
                'DetalleItems.PlacaVehiculo = "falta"
                Factura.DocumentoElectronicoDetalle.Add(DetalleFactura)
            Next
            'Enviando al PSE
            Dim codigo = Helios.Fact.Sunat.WCFService.ServiceAccess.Admin.DocumentoElectronicoSA.DocumentoElectronicoSave(Factura, Nothing)
            If codigo.idDocumentoElectronico > 0 Then
                UpdateFacturasXEstadoTrans(facturaCab.idDocumento, "SI")
            End If

        Catch ex As Exception

        End Try
    End Sub


    Public Function DocumentoventaEncomiendaSave(objDocumento As documento) As Integer
        Dim asientoBL As New AsientoBL
        Dim anticipoBL As New DocumentoAnticipoConciliacionBL
        Dim codDocumentoVenta As Integer
        Try
            Using ts As New TransactionScope()
                objDocumento.fechaActualizacion = DateTime.Now
                'Documento insertado
                Part_DocumentoV2(objDocumento)
                codDocumentoVenta = objDocumento.idDocumento
                'Documento venta
                InsertSingleContado(objDocumento.documentoventaTransporte, objDocumento.idDocumento)
                Part_Detalle(objDocumento)
                PagoDeLaVentaSinLote(objDocumento, objDocumento.documentoventaTransporte)

                'If objDocumento.documentoventaTransporte.idPSE > 0 Then
                '    If My.Computer.Network.IsAvailable = True Then
                '        If My.Computer.Network.Ping("148.102.27.231") Then
                '            If objDocumento.documentoventaTransporte.tipoVenta = "ENDAS" Then
                '                EnvioFacturaElectronica(objDocumento.documentoventaTransporte)
                '            End If
                '        End If
                '    End If
                'End If

                HeliosData.SaveChanges()
                ts.Complete()
                Return codDocumentoVenta 'objDocumento.idDocumento
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub Part_Detalle(objDocumento As documento)
        Dim totalesBL As New totalesAlmacenBL
        Dim inventario As New InventarioMovimientoBL
        Dim ventaDetalleBL As New documentoventaAbarrotesDetBL
        Dim t As New totalesAlmacen

        Using ts As New TransactionScope
            For Each i In objDocumento.documentoventaTransporte.documentoventaTransporteDetalle
                i.idDocumento = objDocumento.idDocumento
                'Dim codSecuenciaDetalle As Integer = ventaDetalleBL.InsertSingleContado(i, objDocumento.idDocumento)
                'i.secuencia = codSecuenciaDetalle
                HeliosData.documentoventaTransporteDetalle.Add(i)
            Next
            Dim numeroVenta = objDocumento.CustomNumero
            HeliosData.SaveChanges()
            ts.Complete()
        End Using


    End Sub

    Public Sub DocumentoventaTransporteSaveVehiculoAsiento(be As vehiculoAsiento_Precios)
        Try
            Using ts As New TransactionScope()
                HeliosData.vehiculoAsiento_Precios.Add(be)
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PagoDeLaVentaSinLote(objDocumento As documento, listaVenta As documentoventaTransporte)
        If Not IsNothing(objDocumento.ListaCustomDocumento) Then
            For Each i In objDocumento.ListaCustomDocumento
                If objDocumento.documentoventaTransporte.IdNumeracion > 0 Then
                    i.nroDoc = objDocumento.documentoventaTransporte.serie & "-" & objDocumento.CustomNumero
                    i.documentoCaja.numeroDoc = objDocumento.documentoventaTransporte.serie & "-" & objDocumento.CustomNumero
                Else
                    i.nroDoc = objDocumento.documentoventaTransporte.serie & "-" & objDocumento.documentoventaTransporte.numero
                    i.documentoCaja.numeroDoc = objDocumento.documentoventaTransporte.serie & "-" & objDocumento.documentoventaTransporte.numero
                End If
                i.nroDoc = objDocumento.CustomSerie & "-" & objDocumento.CustomNumero
                SaveCajaJPS_SinLote(i, objDocumento.idDocumento, objDocumento.documentoventaTransporte)
            Next
        End If
    End Sub

    Private Sub SaveCajaJPS_SinLote(nCaja As documento, intIdCompra As Integer, listaVenta As documentoventaTransporte)
        Dim nDetalle As documentoCajaDetalle
        Dim DocumentoBL As New documentoBL
        Dim documentoCajaBL As New documentoCajaBL
        Dim documentoCajaDetalleBL As New documentoCajaDetalleBL
        Using ts As New TransactionScope
            DocumentoBL.Insert(nCaja)
            nCaja.documentoCaja.numeroDoc = nCaja.nroDoc
            'nCaja.documentoCaja.tipoOperacion = "01"
            documentoCajaBL.Insert(nCaja.documentoCaja, nCaja.idDocumento)
            For Each i In nCaja.documentoCaja.documentoCajaDetalle

                'Dim articuloVenta = listaVenta _
                '    .Where(Function(o) o.idItem = i.idItem And o.tipobeneficio <> "OFERTA").Single

                nDetalle = New documentoCajaDetalle
                nDetalle.idDocumento = nCaja.idDocumento
                nDetalle.documentoAfectado = intIdCompra
                nDetalle.documentoAfectadodetalle = 0 'articuloVenta.secuencia
                nDetalle.secuencia = i.secuencia
                nDetalle.fecha = i.fecha
                nDetalle.idItem = i.idItem
                nDetalle.DetalleItem = i.DetalleItem
                nDetalle.montoSoles = i.montoSoles
                nDetalle.montoSolesTransacc = i.montoSoles
                nDetalle.montoUsd = i.montoUsd
                nDetalle.montoUsdTransacc = i.montoUsd
                nDetalle.entregado = i.entregado
                nDetalle.diferTipoCambio = i.diferTipoCambio
                nDetalle.tipoCambioTransacc = i.tipoCambioTransacc
                nDetalle.idCajaUsuario = i.idCajaUsuario
                nDetalle.otroMN = i.otroMN
                nDetalle.usuarioModificacion = i.usuarioModificacion
                nDetalle.fechaModificacion = i.fechaModificacion

                HeliosData.documentoCajaDetalle.Add(nDetalle)
            Next
            '   documentoCajaDetalleBL.Insert(nCaja, nCaja.idDocumento, intIdCompra)
            HeliosData.SaveChanges()
            ts.Complete()
        End Using

    End Sub

    Public Sub ActualizarEntrega(lista As List(Of documentoventaTransporte), listaEncomiendas As List(Of rutaTareoEncomienda))
        Using ts As New TransactionScope
            For Each i In lista
                Dim obj = HeliosData.documentoventaTransporte.Where(Function(o) o.idDocumento = i.idDocumento).Single
                obj.estado = General.Transporte.EncomiendaEstado.Entregado
            Next

            For Each i In listaEncomiendas
                For Each x In i.rutaTareoEncomiendaDetalle
                    Dim detalle = HeliosData.documentoventaTransporteDetalle.Where(Function(o) o.secuencia = x.venta_detalle_id).SingleOrDefault

                    detalle.estado = General.Transporte.EncomiendaEstado.Entregado
                Next
            Next

            HeliosData.rutaTareoEncomienda.AddRange(listaEncomiendas)

            HeliosData.SaveChanges()
            ts.Complete()
        End Using
    End Sub

    Public Sub ActualizarRutaDestino(be As documentoventaTransporte)
        Try
            Using ts As New TransactionScope
                Dim venta = HeliosData.documentoventaTransporte.Where(Function(o) o.idDocumento = be.idDocumento).Single

                If venta.estado = General.Transporte.EncomiendaEstado.Anulado Then
                    Throw New Exception("No puede manipular una venta anulada!")
                End If
                If be.idPersona Is Nothing Then
                    venta.idPersona = Nothing
                Else
                    venta.idPersona = be.idPersona
                End If
                venta.comprador = be.comprador
                venta.ciudadDestino = be.ciudadDestino
                venta.agenciaDestino_id = be.agenciaDestino_id
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Function GetTransporteDocXIDAnulacion(be As documentoventaTransporteDetalle) As documentoventaTransporte
        GetTransporteDocXIDAnulacion = New documentoventaTransporte
        Dim I = (From det In HeliosData.documentoventaTransporte
                 Join e In HeliosData.documentoventaTransporteDetalle On New With {.idDocumento = CInt(det.idDocumento)} Equals New With {.idDocumento = e.idDocumento}
                 Where
                         e.idDistribucion = be.idDistribucion And
                         det.estadoCobro <> "ANU"
                 Select
                            det.idOrganizacion,
                            det.agenciaDestino_id,
                            det.serie,
                            det.numero,
                            det.tipoDocumento,
                            det.comprador,
                            IdDocumento = CType(det.idDocumento, Int32?),
                            Fechadoc = CType(det.fechadoc, DateTime?),
                            det.ciudadOrigen,
                            det.razonSocial,
                            det.ciudadDestino,
                            det.idPersona,
                            det.telefonoRemitente,
                            det.fechaProgramada,
                            det.telefonoConsignado,
                            det.estadoCobro,
                            det.edad,
                     det.programacion_id,
                     det.numeroAsiento,
                     e.idDistribucion,
                     det.EnvioSunat,
                            Estado = CType(det.estado, Int32?),
                            igv = CType(det.igv1, Decimal?),
                            bi01 = CType(det.baseImponible1, Decimal?),
                            bi02 = CType(det.baseImponible2, Decimal?),
                            Total = CType(det.total, Decimal?)).FirstOrDefault




        GetTransporteDocXIDAnulacion = (New documentoventaTransporte With
                                            {
                                            .idOrganizacion = I.idOrganizacion,
                                            .agenciaDestino_id = I.agenciaDestino_id,
                                            .comprador = I.comprador,
                                            .razonSocial = I.razonSocial,
                                            .idPersona = I.idPersona,
                                            .idDocumento = I.IdDocumento,
                                            .serie = I.serie,
                                            .numero = I.numero,
                                            .tipoDocumento = I.tipoDocumento,
                                            .fechadoc = I.Fechadoc,
                                            .ciudadOrigen = I.ciudadOrigen,
                                                                                  .ciudadDestino = I.ciudadDestino,
                                                                                      .baseImponible1 = I.bi01,
                                                                                      .numeroAsiento = I.numeroAsiento,
                                                                                      .idDistribucion = I.idDistribucion,
                                                                                      .programacion_id = I.programacion_id,
                                            .baseImponible2 = I.bi02,
                                            .igv1 = I.igv,
                                            .fechaProgramada = I.fechaProgramada,
                                            .total = I.Total,
                                            .estadoCobro = I.estadoCobro,
                                            .estado = I.Estado,
                                            .edad = I.edad,
                                            .EnvioSunat = I.EnvioSunat,
                                            .telefonoConsignado = I.telefonoConsignado,
                                            .telefonoRemitente = I.telefonoRemitente
                                                       })


    End Function

    Public Function GetPasajeroXAsiwentoAnulacion(be As documentoventaTransporte) As documentoventaTransporte
        Try


            GetPasajeroXAsiwentoAnulacion = New documentoventaTransporte
            Dim I = (From det In HeliosData.documentoventaTransporte
                     Join e In HeliosData.documentoventaTransporteDetalle On New With {.idDocumento = CInt(det.idDocumento)} Equals New With {.idDocumento = e.idDocumento}
                     Where
                              CLng(det.numeroAsiento) = be.idDistribucion And
                            CLng(det.programacion_id) = be.programacion_id And
                               det.estadoCobro = "DC"
                     Select
                                         det.idOrganizacion,
                                         det.agenciaDestino_id,
                                         det.serie,
                                         det.numero,
                                         det.tipoDocumento,
                                         det.comprador,
                                         IdDocumento = CType(det.idDocumento, Int32?),
                                         Fechadoc = CType(det.fechadoc, DateTime?),
                                         det.ciudadOrigen,
                                         det.razonSocial,
                                         det.ciudadDestino,
                                         det.idPersona,
                                         det.telefonoRemitente,
                                         det.fechaProgramada,
                                         det.telefonoConsignado,
                                         det.estadoCobro,
                         det.numeroAsiento,
                         e.idDistribucion,
                         det.programacion_id,
                                         det.edad,
                                  det.EnvioSunat,
                                         Estado = CType(det.estado, Int32?),
                                         igv = CType(det.igv1, Decimal?),
                                         bi01 = CType(det.baseImponible1, Decimal?),
                                         bi02 = CType(det.baseImponible2, Decimal?),
                                         Total = CType(det.total, Decimal?)).FirstOrDefault


            If (Not IsNothing(I)) Then


                GetPasajeroXAsiwentoAnulacion = (New documentoventaTransporte With
                                                {
                                                .idOrganizacion = I.idOrganizacion,
                                                .agenciaDestino_id = I.agenciaDestino_id,
                                                .comprador = I.comprador,
                                                .razonSocial = I.razonSocial,
                                                .idPersona = I.idPersona,
                                                .idDocumento = I.IdDocumento,
                                                .serie = I.serie,
                                                .numero = I.numero,
                                                .tipoDocumento = I.tipoDocumento,
                                                .fechadoc = I.Fechadoc,
                                                .ciudadOrigen = I.ciudadOrigen,
                                                                                      .ciudadDestino = I.ciudadDestino,
                                                                                          .baseImponible1 = I.bi01,
                                                .baseImponible2 = I.bi02,
                                                .igv1 = I.igv,
                                                .fechaProgramada = I.fechaProgramada,
                                                .total = I.Total,
                                                .estadoCobro = I.estadoCobro,
                                                .estado = I.Estado,
                                                .idDistribucion = I.idDistribucion,
                                                .programacion_id = I.programacion_id,
                                                .numeroAsiento = I.numeroAsiento,
                                                .edad = I.edad,
                                                .EnvioSunat = I.EnvioSunat,
                                                .telefonoConsignado = I.telefonoConsignado,
                                                .telefonoRemitente = I.telefonoRemitente
                                                           })
            Else
                Throw New Exception("Asiento libre")

            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function GetVerificarDisponibilidadAsiento(be As vehiculoAsiento_Precios) As Boolean
        Try
            Dim CONDICION As Boolean

            Dim con = (From vt In HeliosData.documentoventaTransporte
                       Where
                          CLng(vt.numeroAsiento) = be.idDistribucion And
                        CLng(vt.programacion_id) = be.programacion_id And
                           vt.estadoCobro = "DC").ToList

            If (con.Count > 0) Then
                CONDICION = True
            Else
                CONDICION = False
            End If

            Return CONDICION
        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Sub UpdateProgramacionXCAmbioPlaca(be As rutaProgramacionSalidas, vehiculoAsiento_PreciosBE As vehiculoAsiento_Precios)
        Dim documentoVEntaDetBL As New documentoventaTransporteDetalleBL
        Try
            Using ts As New TransactionScope()
                Dim documento As List(Of documentoventaTransporte) = HeliosData.documentoventaTransporte.Where(Function(o) _
                                            o.programacion_id = be.nroProgramcionAnterior And
                                            o.numeroAsiento = vehiculoAsiento_PreciosBE.numeracion).ToList

                If (documento.Count > 0) Then
                    For Each item In documento
                        item.programacion_id = be.programacion_id
                        HeliosData.SaveChanges()

                        documentoVEntaDetBL.UpdateProgramacionDetalleXCAmbioPlaca(vehiculoAsiento_PreciosBE, item.idDocumento)

                    Next
                End If



                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub



End Class

