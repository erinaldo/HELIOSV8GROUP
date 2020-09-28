Imports Helios.Cont.Business.Entity
Imports System.Transactions
Imports Helios.General.Constantes
Imports Helios.Cont.Data.EF
Public Class prestamosBL
    Inherits BaseBL


    Public Sub UpdateConfirmarPrestamo(idDocumento As Integer)
        Try
            Using ts As New TransactionScope
                Dim obj As prestamos = HeliosData.prestamos.Where(Function(o) o.idDocumento = idDocumento _
                                                                      And o.entregaPendiente = "NO").FirstOrDefault
                If Not IsNothing(obj) Then
                    With obj
                        .entregaPendiente = "SI"
                    End With
                End If

                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub



    Public Function ListadoTodoCuotasVencidas(tipo As String) As List(Of prestamos)
        Dim lista As New List(Of prestamos)
        Dim objPrestamo As New prestamos

        Dim consulta = (From n In HeliosData.prestamos _
                        Join doc In HeliosData.documentoPrestamos _
                        On doc.idDocumento Equals n.idDocumento _
                       Where n.entregaPendiente = "SI" And n.idEmpresa = Gempresas.IdEmpresaRuc And n.desembolso = "SI" And n.tipoPrestamo = tipo And n.estado = "PN" _
                       And doc.fechaVcto < DateTime.Now And doc.estadoPago = "PN").ToList

        For Each i In consulta
            objPrestamo = New prestamos
            objPrestamo.idDocumento = i.n.idDocumento
            objPrestamo.DocPrestamo = i.n.DocPrestamo
            objPrestamo.nroDoc = i.n.nroDoc
            objPrestamo.fechaPrestamo = i.n.fechaPrestamo
            objPrestamo.idBeneficiario = i.n.idBeneficiario
            objPrestamo.tipoBeneficiario = i.n.tipoBeneficiario
            objPrestamo.tipoCambio = i.n.tipoCambio
            objPrestamo.monto = i.doc.montoSoles
            objPrestamo.montoUSD = i.doc.montoDolares
            objPrestamo.desembolso = i.n.desembolso

            objPrestamo.idCuota = i.doc.idCuota
            objPrestamo.nomCuota = i.doc.referencia
            objPrestamo.fechaVen = i.doc.fechaVcto
            objPrestamo.fechaPlazo = i.doc.fechaPlazo

            lista.Add(objPrestamo)
        Next

        Return lista
    End Function



    Public Function ListadoCuotasVencidas(idBeneficiario As Integer, tipo As String) As List(Of prestamos)
        Dim lista As New List(Of prestamos)
        Dim objPrestamo As New prestamos

        Dim consulta = (From n In HeliosData.prestamos _
                        Join doc In HeliosData.documentoPrestamos _
                        On doc.idDocumento Equals n.idDocumento _
                       Where n.idBeneficiario = idBeneficiario And n.idEmpresa = Gempresas.IdEmpresaRuc And
                       n.entregaPendiente = "SI" And n.desembolso = "SI" And n.tipoPrestamo = tipo And n.estado = "PN" _
                       And doc.fechaVcto < DateTime.Now And doc.estadoPago = "PN").ToList

        For Each i In consulta
            objPrestamo = New prestamos
            objPrestamo.idDocumento = i.n.idDocumento
            objPrestamo.DocPrestamo = i.n.DocPrestamo
            objPrestamo.nroDoc = i.n.nroDoc
            objPrestamo.fechaPrestamo = i.n.fechaPrestamo
            objPrestamo.idBeneficiario = i.n.idBeneficiario
            objPrestamo.tipoBeneficiario = i.n.tipoBeneficiario
            objPrestamo.tipoCambio = i.n.tipoCambio
            objPrestamo.monto = i.doc.montoSoles
            objPrestamo.montoUSD = i.doc.montoDolares
            objPrestamo.desembolso = i.n.desembolso

            objPrestamo.idCuota = i.doc.idCuota
            objPrestamo.nomCuota = i.doc.referencia
            objPrestamo.fechaVen = i.doc.fechaVcto
            objPrestamo.fechaPlazo = i.doc.fechaPlazo

            lista.Add(objPrestamo)
        Next

        Return lista
    End Function




    Public Function SaveIngresoDesembolso(objDocumentoBE As documento, documentoBE As prestamos) As Integer
        Dim documentoBL As New documentoBL
        Dim docprestamobl As New documentoPrestamosBL
        Dim cajaDetalleBL As New documentoCajaDetalleBL
        Dim AsientoBL As New AsientoBL
        Dim doc As New documentoCajaBL

        Try
            Using ts As New TransactionScope()
                documentoBL.Insert(objDocumentoBE)
                doc.InsertME(objDocumentoBE.documentoCaja, objDocumentoBE.idDocumento)
                'cajaDetalleBL.InsertApertura(objDocumentoBE, objDocumentoBE.idDocumento)
                cajaDetalleBL.InsertCajaME(objDocumentoBE, objDocumentoBE.idDocumento, objDocumentoBE.documentoCaja.entidadFinanciera)

                Me.IngresoFechaPrestamo(documentoBE)

                Me.ConfirmarDesembolso(objDocumentoBE.idPrestamo)
                AsientoBL.SavebyGroupDoc(objDocumentoBE)
                HeliosData.SaveChanges()
                ts.Complete()
                Return objDocumentoBE.idDocumento
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Sub IngresoFechaPrestamo(prestamosBE As prestamos)
        Try
            Using ts As New TransactionScope
                Dim obj As prestamos = HeliosData.prestamos.Where(Function(o) o.idDocumento = prestamosBE.idDocumento).FirstOrDefault
                If Not IsNothing(obj) Then
                    With obj

                        .fechaDesembolso = prestamosBE.fechaDesembolso
                        '.nroDoc = prestamosBE.nroDoc
                    End With
                End If
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Public Function ListadoDesembolsoApto(idempresa As String, tipo As String) As List(Of prestamos)
        Dim lista As New List(Of prestamos)
        Dim objPrestamo As New prestamos

        Dim consulta = (From n In HeliosData.prestamos _
                       Where n.idEmpresa = Gempresas.IdEmpresaRuc And _
                       n.entregaPendiente = "SI" And n.desembolso = "NO" And n.tipoPrestamo = tipo).ToList


        For Each i In consulta
            objPrestamo = New prestamos
            objPrestamo.idDocumento = i.idDocumento
            objPrestamo.DocPrestamo = i.DocPrestamo
            objPrestamo.nroDoc = i.nroDoc
            objPrestamo.fechaPrestamo = i.fechaPrestamo
            objPrestamo.idBeneficiario = i.idBeneficiario
            objPrestamo.tipoBeneficiario = i.tipoBeneficiario
            objPrestamo.tipoCambio = i.tipoCambio
            objPrestamo.monto = i.monto
            objPrestamo.montoUSD = i.montoUSD
            objPrestamo.desembolso = i.desembolso

            'objPrestamo.montoInteresSoles = i.montoInteresSoles
            'objPrestamo.montoInteresUSD = i.montoInteresUSD
            'objPrestamo.montoSeguroMN = i.montoSeguroMN
            'objPrestamo.montoSeguroME = i.montoSeguroME
            'objPrestamo.montoOtroMN = i.montoOtroMN
            'objPrestamo.montoOtroME = i.montoOtroME
            'objPrestamo.montoPorteMN = i.montoPorteMN
            'objPrestamo.montoPorteME = i.montoPorteME
            'objPrestamo.montoEnvCuentaMN = i.montoEnvCuentaMN
            'objPrestamo.montoEnvCuentaME = i.montoEnvCuentaME

            objPrestamo.numCuotas = i.numCuotas
            objPrestamo.fechaInicio = i.fechaInicio
            objPrestamo.modoPago = i.modoPago
            objPrestamo.diaPago = i.diaPago
            objPrestamo.plazoDias = i.plazoDias
            objPrestamo.tipo = i.tipo

            lista.Add(objPrestamo)
        Next

        Return lista
    End Function



    Public Sub ConfirmarDesembolso(intCodigo As Integer)
        Dim OBJD As New prestamos
        Try
            Using ts As New TransactionScope()
                OBJD = (From s In HeliosData.prestamos _
                                Where s.idDocumento = intCodigo).First

                OBJD.desembolso = "SI"
                'OBJD.entregaPendiente = "SI"
                'OBJD.nroDoc = strNum
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UpdateFechaPrestamo(prestamosBE As prestamos)
        Try
            Using ts As New TransactionScope
                Dim obj As prestamos = HeliosData.prestamos.Where(Function(o) o.idDocumento = prestamosBE.idDocumento).FirstOrDefault
                If Not IsNothing(obj) Then
                    With obj

                        .modoPago = prestamosBE.modoPago
                        .fechaInicio = prestamosBE.fechaInicio
                        .diaPago = prestamosBE.diaPago
                        .plazoDias = prestamosBE.plazoDias
                        .fechaDesembolso = prestamosBE.fechaDesembolso
                        '.nroDoc = prestamosBE.nroDoc

                    End With
                End If
                'HeliosData.ObjectStateManager.GetObjectStateEntry(obj).State.ToString()
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function PrestamosMayoresMenores(montoini As Decimal, montofin As Decimal) As List(Of prestamos)
        Dim lista As New List(Of prestamos)
        Dim objPrestamo As New prestamos
        Dim entidadbl As New entidadBL

        Dim consulta = (From n In HeliosData.prestamos _
                       Where n.idEmpresa = Gempresas.IdEmpresaRuc And _
                       n.monto >= montoini And n.monto <= montofin).ToList

        For Each i In consulta
            objPrestamo = New prestamos
            objPrestamo.idDocumento = i.idDocumento
            objPrestamo.DocPrestamo = i.DocPrestamo
            objPrestamo.nroDoc = i.nroDoc
            objPrestamo.fechaPrestamo = i.fechaPrestamo

            With entidadbl.UbicarEntidadPorIdEntidad(Gempresas.IdEmpresaRuc, i.tipoBeneficiario, i.idBeneficiario)

                objPrestamo.tipoBeneficiario = .nombreCompleto
            End With

            objPrestamo.monto = i.monto
            objPrestamo.montoUSD = i.montoUSD

            objPrestamo.desembolso = i.desembolso

            objPrestamo.periodo = i.periodo
            objPrestamo.fechaDesembolso = i.fechaDesembolso
            objPrestamo.numCuotas = i.numCuotas
            objPrestamo.estado = i.estado


            lista.Add(objPrestamo)
        Next

        Return lista
    End Function


    Public Function SaveDesembolso(objDocumentoBE As documento, documentoBE As prestamos, listaDocumentos As List(Of documentoPrestamos)) As Integer
        Dim documentoBL As New documentoBL
        Dim docprestamobl As New documentoPrestamosBL
        Dim cajaDetalleBL As New documentoCajaDetalleBL
        Dim AsientoBL As New AsientoBL
        Dim doc As New documentoCajaBL

        Try
            Using ts As New TransactionScope()
                documentoBL.Insert(objDocumentoBE)
                doc.InsertME(objDocumentoBE.documentoCaja, objDocumentoBE.idDocumento)
                'cajaDetalleBL.InsertApertura(objDocumentoBE, objDocumentoBE.idDocumento)
                cajaDetalleBL.InsertCajaME(objDocumentoBE, objDocumentoBE.idDocumento, objDocumentoBE.documentoCaja.entidadFinanciera)

                docprestamobl.UpdateFechaDesembolso(documentoBE, listaDocumentos)

                Me.ConfirmarDesembolso(objDocumentoBE.idPrestamo)
                AsientoBL.SavebyGroupDoc(objDocumentoBE)
                HeliosData.SaveChanges()
                ts.Complete()
                Return objDocumentoBE.idDocumento
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function



    Public Function ListadoPrestamoAprobadosBenefi(idBeneficiario As Integer, tipo As String, tipoProv As String) As List(Of prestamos)
        Dim lista As New List(Of prestamos)
        Dim objPrestamo As New prestamos

        Dim consulta = (From n In HeliosData.prestamos _
                       Where n.idBeneficiario = idBeneficiario And n.tipoBeneficiario = tipoProv And _
                       n.entregaPendiente = "SI" And n.desembolso = "NO" And n.tipoPrestamo = tipo).ToList


        For Each i In consulta
            objPrestamo = New prestamos
            objPrestamo.idDocumento = i.idDocumento
            objPrestamo.DocPrestamo = i.DocPrestamo
            objPrestamo.nroDoc = i.nroDoc
            objPrestamo.fechaPrestamo = i.fechaPrestamo
            objPrestamo.idBeneficiario = i.idBeneficiario
            objPrestamo.tipoBeneficiario = i.tipoBeneficiario
            objPrestamo.tipoCambio = i.tipoCambio
            objPrestamo.monto = i.monto
            objPrestamo.montoUSD = i.montoUSD
            objPrestamo.desembolso = i.desembolso
            objPrestamo.numCuotas = i.numCuotas
            objPrestamo.fechaInicio = i.fechaInicio
            objPrestamo.modoPago = i.modoPago
            objPrestamo.diaPago = i.diaPago
            objPrestamo.plazoDias = i.plazoDias
            objPrestamo.tipo = i.tipo
            objPrestamo.cuentaTipo = i.cuentaTipo
            objPrestamo.tipoCuenta = i.tipoCuenta
            objPrestamo.moneda = i.moneda

            lista.Add(objPrestamo)
        Next

        Return lista
    End Function

    Public Function ListadoPrestamoPagoCobro(ByVal strPeriodo As String, tipo As String) As List(Of prestamos)
        Dim lista As New List(Of prestamos)
        Dim objPrestamo As New prestamos

        Dim consulta = (From n In HeliosData.prestamos _
                       Where n.periodo = strPeriodo And _
                       n.entregaPendiente = "SI" And n.desembolso = "SI" And n.tipoPrestamo = tipo And n.estado = "PN").ToList

        For Each i In consulta
            objPrestamo = New prestamos
            objPrestamo.idDocumento = i.idDocumento
            objPrestamo.DocPrestamo = i.DocPrestamo
            objPrestamo.nroDoc = i.nroDoc
            objPrestamo.fechaPrestamo = i.fechaPrestamo
            objPrestamo.idBeneficiario = i.idBeneficiario
            objPrestamo.tipoBeneficiario = i.tipoBeneficiario
            objPrestamo.tipoCambio = i.tipoCambio
            objPrestamo.monto = i.monto
            objPrestamo.montoUSD = i.montoUSD
            objPrestamo.desembolso = i.desembolso
            objPrestamo.estado = i.estado

            lista.Add(objPrestamo)
        Next

        Return lista
    End Function


    Public Function ListadoPrestamoAprobadoDesembolsado(idBeneficiario As Integer, tipo As String, tipoprov As String) As List(Of prestamos)
        Dim lista As New List(Of prestamos)
        Dim objPrestamo As New prestamos
        Dim doccajaBL As New documentoCajaBL
        Dim objetoCaja As New documentoCaja

        Dim consulta = (From n In HeliosData.prestamos _
                       Where n.idBeneficiario = idBeneficiario And n.tipoBeneficiario = tipoprov And _
                       n.entregaPendiente = "SI" And n.desembolso = "SI" And n.tipoPrestamo = tipo).ToList

        For Each i In consulta
            objPrestamo = New prestamos
            objPrestamo.idDocumento = i.idDocumento
            objPrestamo.DocPrestamo = i.DocPrestamo
            objPrestamo.nroDoc = i.nroDoc
            objPrestamo.fechaPrestamo = i.fechaPrestamo
            objPrestamo.idBeneficiario = i.idBeneficiario
            objPrestamo.tipoBeneficiario = i.tipoBeneficiario
            objPrestamo.tipoCambio = i.tipoCambio
            objPrestamo.monto = i.monto
            objPrestamo.montoUSD = i.montoUSD
            objPrestamo.desembolso = i.desembolso
            objPrestamo.estado = i.estado
            objPrestamo.cuentaTipo = i.cuentaTipo
            objPrestamo.cuentaDevengado = i.cuentaDevengado
            objPrestamo.tipoCuenta = i.tipoCuenta
            objPrestamo.tipoDevengado = i.tipoDevengado
            objPrestamo.interes = i.interes

            objetoCaja = doccajaBL.PagosPorPrestamo(i.idDocumento)
            objPrestamo.abono = objetoCaja.montoSoles


            lista.Add(objPrestamo)
        Next

        Return lista
    End Function

    Public Function ObtenerPrestamosEmitidos(ByVal strIdEmpresa As String, ByVal intIDEstablecimiento As String, strTipoPrestamo As String) As List(Of prestamos)
        Try
            Dim lista As New List(Of prestamos)
            Dim objPrestamo As New prestamos
            Dim entidadbl As New entidadBL

            Dim consulta = (From s In HeliosData.prestamos _
                                          Where s.idEmpresa = strIdEmpresa _
                                          And s.idEstablecimiento = intIDEstablecimiento _
                                          And s.fechaPrestamo.Value.Year = DateTime.Now.Year _
                                          And s.fechaPrestamo.Value.Month = DateTime.Now.Month _
                                          And s.fechaPrestamo.Value.Day = DateTime.Now.Day _
                                          And s.tipoPrestamo = strTipoPrestamo _
                                          And s.entregaPendiente = "NO"
                                          Select s).ToList


            For Each i In consulta
                objPrestamo = New prestamos
                objPrestamo.idDocumento = i.idDocumento
                objPrestamo.fechaPrestamo = i.fechaPrestamo
                objPrestamo.codigo = i.codigo
                objPrestamo.DocPrestamo = i.DocPrestamo

                objPrestamo.tipoBeneficiario = i.tipoBeneficiario
                objPrestamo.idBeneficiario = i.idBeneficiario

                objPrestamo.moneda = i.moneda
                objPrestamo.tipoCambio = i.tipoCambio

                objPrestamo.tipoActivo = i.tipoActivo
                objPrestamo.monto = i.monto
                objPrestamo.montoUSD = i.montoUSD
                'objPrestamo.montoInteresSoles = i.montoInteresSoles
                'objPrestamo.montoInteresUSD = i.montoInteresUSD
                objPrestamo.entregaPendiente = i.entregaPendiente
                lista.Add(objPrestamo)
            Next

            Return lista

        Catch ex As Exception
            Throw ex
        End Try

    End Function





    Public Function ObtenerPrestamosEmitidosXperiodo(ByVal strIdEmpresa As String, intIdEstablecimiento As Integer, ByVal strPeriodo As String,
                                             strTipoPrestamo As String) As List(Of prestamos)
        Try

            Dim lista As New List(Of prestamos)
            Dim objPrestamo As New prestamos
            Dim entidadbl As New entidadBL
            '    And s.estado = strEstado _
            Dim consulta = (From s In HeliosData.prestamos _
                                          Where s.idEmpresa = strIdEmpresa _
                                          And s.idEstablecimiento = intIdEstablecimiento _
                                          And s.periodo = strPeriodo _
                                          And s.tipoPrestamo = strTipoPrestamo _
                                          And s.entregaPendiente = "NO"
                                          Select s).ToList

            For Each i In consulta
                objPrestamo = New prestamos
                objPrestamo.idDocumento = i.idDocumento
                objPrestamo.fechaPrestamo = i.fechaPrestamo
                objPrestamo.codigo = i.codigo
                objPrestamo.DocPrestamo = i.DocPrestamo

                objPrestamo.tipoBeneficiario = i.tipoBeneficiario
                objPrestamo.idBeneficiario = i.idBeneficiario

                objPrestamo.moneda = i.moneda
                objPrestamo.tipoCambio = i.tipoCambio

                objPrestamo.tipoActivo = i.tipoActivo
                objPrestamo.monto = i.monto
                objPrestamo.montoUSD = i.montoUSD
                'objPrestamo.montoInteresSoles = i.montoInteresSoles
                'objPrestamo.montoInteresUSD = i.montoInteresUSD
                objPrestamo.entregaPendiente = i.entregaPendiente
                lista.Add(objPrestamo)
            Next

            Return lista


        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function ObtenerPrestamosRecibidoXperiodo(ByVal strIdEmpresa As String, intIdEstablecimiento As Integer, ByVal strPeriodo As String,
                                             strTipoPrestamo As String) As List(Of prestamos)
        Try

            Dim lista As New List(Of prestamos)
            Dim objPrestamo As New prestamos
            Dim entidadbl As New entidadBL
            '    And s.estado = strEstado _
            Dim consulta = (From s In HeliosData.prestamos _
                                          Where s.idEmpresa = strIdEmpresa _
                                          And s.idEstablecimiento = intIdEstablecimiento _
                                          And s.periodo = strPeriodo _
                                          And s.tipoPrestamo = strTipoPrestamo _
                                          Select s).ToList

            For Each i In consulta
                objPrestamo = New prestamos
                objPrestamo.idDocumento = i.idDocumento
                objPrestamo.fechaPrestamo = i.fechaPrestamo
                objPrestamo.codigo = i.codigo
                objPrestamo.DocPrestamo = i.DocPrestamo

                objPrestamo.tipoBeneficiario = i.tipoBeneficiario
                objPrestamo.idBeneficiario = i.idBeneficiario

                objPrestamo.moneda = i.moneda
                objPrestamo.tipoCambio = i.tipoCambio

                objPrestamo.tipoActivo = i.tipoActivo
                objPrestamo.monto = i.monto
                objPrestamo.montoUSD = i.montoUSD
                'objPrestamo.montoInteresSoles = i.montoInteresSoles
                'objPrestamo.montoInteresUSD = i.montoInteresUSD
                objPrestamo.entregaPendiente = i.entregaPendiente
                lista.Add(objPrestamo)
            Next

            Return lista


        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function ListadoPrestamoOtorgados(idBeneficiario As Integer) As List(Of prestamos)
        Dim lista As New List(Of prestamos)
        Dim objPrestamo As New prestamos
        Dim entidadbl As New entidadBL

        Dim consulta = (From n In HeliosData.prestamos _
                       Where n.idBeneficiario = idBeneficiario And _
                       n.entregaPendiente = "SI" And n.desembolso = "SI").ToList

        For Each i In consulta
            objPrestamo = New prestamos
            objPrestamo.idDocumento = i.idDocumento
            objPrestamo.DocPrestamo = i.DocPrestamo
            objPrestamo.nroDoc = i.nroDoc
            objPrestamo.fechaPrestamo = i.fechaPrestamo

            With entidadbl.UbicarEntidadPorIdEntidad(Gempresas.IdEmpresaRuc, i.tipoBeneficiario, i.idBeneficiario)

                objPrestamo.tipoBeneficiario = .nombreCompleto
            End With

            objPrestamo.monto = i.monto
            objPrestamo.montoUSD = i.montoUSD

            objPrestamo.desembolso = i.desembolso
            objPrestamo.periodo = i.periodo
            objPrestamo.fechaDesembolso = i.fechaDesembolso
            objPrestamo.numCuotas = i.numCuotas
            objPrestamo.estado = i.estado
            lista.Add(objPrestamo)
        Next

        Return lista
    End Function


    Public Function UbicarPrestamoXcodigo(intCodigo As Integer) As prestamos
        Dim objPrestamo As New prestamos

        Dim consulta = (HeliosData.prestamos.Where(Function(o) o.codigo = intCodigo And o.entregaPendiente = "NO")).FirstOrDefault


        objPrestamo.idDocumento = consulta.idDocumento
        objPrestamo.codigo = consulta.codigo
        objPrestamo.nroDoc = consulta.nroDoc
        objPrestamo.fechaPrestamo = consulta.fechaPrestamo
        objPrestamo.moneda = consulta.moneda
        objPrestamo.tipoBeneficiario = consulta.tipoBeneficiario
        objPrestamo.idBeneficiario = consulta.idBeneficiario
        objPrestamo.tipoCambio = consulta.tipoCambio
        objPrestamo.monto = consulta.monto
        objPrestamo.montoUSD = consulta.montoUSD
        'objPrestamo.interes = consulta.interes
        ' objPrestamo.montoInteresSoles = consulta.montoInteresSoles
        'objPrestamo.montoInteresUSD = consulta.montoInteresUSD
        'objPrestamo.seguro = consulta.seguro
        'objPrestamo.portes = consulta.portes
        'objPrestamo.envCuenta = consulta.envCuenta
        objPrestamo.numCuotas = consulta.numCuotas
        ' objPrestamo.moratorio = consulta.moratorio
        'objPrestamo.compensatorio = consulta.compensatorio
        ' objPrestamo.otro = consulta.otro
        'objPrestamo.otro1 = consulta.otro1
        objPrestamo.modoPago = consulta.modoPago
        'objPrestamo.seguro = consulta.seguro
        'objPrestamo.portesPorc = consulta.portesPorc
        'objPrestamo.envCuenPorc = consulta.envCuenPorc
        objPrestamo.diaPago = consulta.diaPago
        objPrestamo.fechaInicio = consulta.fechaInicio
        objPrestamo.plazoDias = consulta.plazoDias



        Return objPrestamo
    End Function

    'Public Function UbicarPrestamoXcodigo(intCodigo As Integer) As prestamos
    '    Return (HeliosData.prestamos.Where(Function(o) o.codigo = intCodigo And o.entregaPendiente = "NO")).FirstOrDefault
    'End Function

    Public Function UbicarPrestamoXcodigoDefault(intCodigo As Integer) As prestamos
        Return (HeliosData.prestamos.Where(Function(o) o.codigo = intCodigo)).FirstOrDefault
    End Function

    Public Function PrestamoEstadoAprobado(intCodigo As Integer) As Boolean
        Dim c = (HeliosData.prestamos.Where(Function(o) o.codigo = intCodigo And o.entregaPendiente = "SI")).FirstOrDefault

        If Not IsNothing(c) Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function UbicarPrestamoXcodigoSingle(intIdDocumento As Integer) As prestamos
        Return (HeliosData.prestamos.Where(Function(o) o.idDocumento = intIdDocumento)).FirstOrDefault
    End Function


    Public Function SavePrestamoRec(prestamosBE As prestamos, iddocumento As Integer) As Integer
        Dim nDocumento As New prestamos
        Dim numeracionBL As New numeracionBoletasBL
        Dim cval As Integer

        Try
            Using ts As New TransactionScope

                With nDocumento
                    .idDocumento = iddocumento
                    .idEmpresa = prestamosBE.idEmpresa
                    .idEstablecimiento = prestamosBE.idEstablecimiento
                    .DocPrestamo = prestamosBE.DocPrestamo
                    .fechaPrestamo = prestamosBE.fechaPrestamo
                    .periodo = prestamosBE.periodo
                    .tipoPrestamo = prestamosBE.tipoPrestamo
                    .tipoBeneficiario = prestamosBE.tipoBeneficiario
                    .idBeneficiario = prestamosBE.idBeneficiario
                    .detalleGlosa = prestamosBE.detalleGlosa
                    .moneda = prestamosBE.moneda
                    .tipoCambio = prestamosBE.tipoCambio
                    .tipo = prestamosBE.tipo
                    .monto = prestamosBE.monto
                    .montoUSD = prestamosBE.montoUSD
                    .interes = prestamosBE.interes

                    .cuentaTipo = prestamosBE.cuentaTipo
                    .cuentaDevengado = prestamosBE.cuentaDevengado



                    cval = Convert.ToInt32(numeracionBL.GenerarNumeroPorID(prestamosBE.IdNumeracion))

                    .nroDoc = cval

                    .tipoActivo = prestamosBE.tipoActivo
                    .entregaPendiente = prestamosBE.entregaPendiente
                    .desembolso = prestamosBE.desembolso
                    .estado = prestamosBE.estado
                    .usuarioActualizacion = prestamosBE.usuarioActualizacion
                    .fechaActualizacion = prestamosBE.fechaActualizacion
                    .fechaDesembolso = prestamosBE.fechaDesembolso
                    .numCuotas = prestamosBE.numCuotas
                    .modoPago = prestamosBE.modoPago
                    .diaPago = prestamosBE.diaPago
                    .fechaInicio = prestamosBE.fechaInicio
                    .plazoDias = prestamosBE.plazoDias

                End With


                HeliosData.prestamos.Add(nDocumento)
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return prestamosBE.codigo
    End Function

    Public Function Save(prestamosBE As prestamos) As Integer
        Dim nDocumento As New prestamos
        Try
            Using ts As New TransactionScope

                With nDocumento

                    '.idDocumento = CInt(0)
                    .idEmpresa = prestamosBE.idEmpresa
                    .idEstablecimiento = prestamosBE.idEstablecimiento
                    .DocPrestamo = prestamosBE.DocPrestamo
                    .fechaPrestamo = prestamosBE.fechaPrestamo
                    .periodo = prestamosBE.periodo
                    .tipoPrestamo = prestamosBE.tipoPrestamo
                    .tipoBeneficiario = prestamosBE.tipoBeneficiario


                    .idBeneficiario = prestamosBE.idBeneficiario
                    .detalleGlosa = prestamosBE.detalleGlosa
                    '.nroDoc = prestamosBE.nroDoc
                    .moneda = prestamosBE.moneda
                    .tipoCambio = prestamosBE.tipoCambio

                    .tipo = prestamosBE.tipo

                    .monto = prestamosBE.monto
                    .montoUSD = prestamosBE.montoUSD


                    .tipoActivo = prestamosBE.tipoActivo
                    .entregaPendiente = prestamosBE.entregaPendiente
                    .desembolso = prestamosBE.desembolso
                    .estado = prestamosBE.estado
                    .usuarioActualizacion = prestamosBE.usuarioActualizacion
                    .fechaActualizacion = prestamosBE.fechaActualizacion

                    .fechaDesembolso = prestamosBE.fechaDesembolso

                    .numCuotas = prestamosBE.numCuotas


                    'porcentajes

                    .modoPago = prestamosBE.modoPago

                    .diaPago = prestamosBE.diaPago

                    .fechaInicio = prestamosBE.fechaInicio

                    .plazoDias = prestamosBE.plazoDias

                End With


                HeliosData.prestamos.Add(nDocumento)
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
        Return prestamosBE.codigo
    End Function


    'Public Function Save(prestamosBE As prestamos) As Integer
    '    Try
    '        Using ts As New TransactionScope
    '            HeliosData.prestamos.Add(prestamosBE)
    '            HeliosData.SaveChanges()
    '            ts.Complete()
    '        End Using
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    '    Return prestamosBE.codigo
    'End Function

    Public Sub ConfirmarPrestamo(intCodigo As Integer, strNum As String)
        Dim OBJD As New prestamos
        Try
            Using ts As New TransactionScope()
                OBJD = (From s In HeliosData.prestamos _
                                Where s.codigo = intCodigo).First

                OBJD.estado = "C"
                OBJD.entregaPendiente = "SI"
                OBJD.nroDoc = strNum
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UpdatePrePrestamo(prestamosBE As prestamos)
        Try
            Using ts As New TransactionScope
                Dim obj As prestamos = HeliosData.prestamos.Where(Function(o) o.codigo = prestamosBE.codigo).FirstOrDefault
                If Not IsNothing(obj) Then
                    With obj
                        .tipoPrestamo = prestamosBE.tipoPrestamo
                        .DocPrestamo = prestamosBE.DocPrestamo
                        .nroDoc = prestamosBE.nroDoc
                        .fechaPrestamo = prestamosBE.fechaPrestamo
                        .tipoBeneficiario = prestamosBE.tipoBeneficiario
                        .idBeneficiario = prestamosBE.idBeneficiario
                        .detalleGlosa = prestamosBE.detalleGlosa
                        .moneda = prestamosBE.moneda
                        .tipoCambio = prestamosBE.tipoCambio
                        .monto = prestamosBE.monto
                        .montoUSD = prestamosBE.montoUSD

                        .tipoActivo = prestamosBE.tipoActivo
                        .entregaPendiente = prestamosBE.entregaPendiente
                        .estado = prestamosBE.estado

                        .usuarioActualizacion = prestamosBE.usuarioActualizacion
                        .fechaActualizacion = prestamosBE.fechaActualizacion
                    End With
                End If
                'HeliosData.ObjectStateManager.GetObjectStateEntry(obj).State.ToString()
                HeliosData.SaveChanges()
                ts.Complete()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ElimiarPrePrestamo(prestamosBE As prestamos)
        Try
            Using ts As New TransactionScope
                Dim obj As prestamos = HeliosData.prestamos.Where(Function(o) o.codigo = prestamosBE.codigo).FirstOrDefault
                If Not IsNothing(obj) Then
                    CType(HeliosData, System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext.DeleteObject(obj)
                    HeliosData.SaveChanges()
                    ts.Complete()
                End If

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub EliminarPrestamoAprobado(prestamosBE As prestamos)
        Dim documentoBL As New documentoBL
        Dim totalesCajaUsuario As New CajaUsuarioBL

        Dim cajaDetalle As List(Of documentoCajaDetalle) = HeliosData.documentoCajaDetalle.Where(Function(o) o.documentoAfectado = prestamosBE.idDocumento).ToList
        For Each i In cajaDetalle
            '        totalesCajaUsuario.DeleteTotalesCajaUsuarioDocCajaDetallePrestamoOT(i.idDocumento, i.usuarioModificacion, prestamosBE.idDocumento)
            documentoBL.DeleteSinglePagado(i.idDocumento)
        Next

        Dim consultaDocsPrestamo As List(Of documentoPrestamos) = HeliosData.documentoPrestamos.Where(Function(o) o.idDocumento = prestamosBE.idDocumento).ToList

        For Each i In consultaDocsPrestamo
            documentoBL.DeleteSingleVariable(i.idDocumento)
        Next
        ElimiarPrePrestamo(prestamosBE)
    End Sub

    Public Function ListaPrestamosPorEstado(intIdEstablecimiento As Integer)
        Return (From n In HeliosData.prestamos _
                Where n.idEstablecimiento = intIdEstablecimiento).ToList
    End Function



    Public Function ObtenerPrestamos(ByVal strIdEmpresa As String, ByVal intIDEstablecimiento As String, strTipoPrestamo As String) As List(Of prestamos)
        Try
            Dim lista As New List(Of prestamos)
            Dim objPrestamo As New prestamos
            '    And s.estado = strEstado _
            Dim consulta = (From s In HeliosData.prestamos _
                                          Where s.idEmpresa = strIdEmpresa _
                                          And s.idEstablecimiento = intIDEstablecimiento _
                                          And s.fechaPrestamo.Value.Year = DateTime.Now.Year _
                                          And s.fechaPrestamo.Value.Month = DateTime.Now.Month _
                                          And s.fechaPrestamo.Value.Day = DateTime.Now.Day _
                                          And s.tipoPrestamo = strTipoPrestamo _
                                          And s.entregaPendiente = "NO" _
                                          Select s).ToList

            For Each i In consulta
                objPrestamo = New prestamos
                objPrestamo.idDocumento = i.idDocumento
                objPrestamo.codigo = i.codigo
                objPrestamo.DocPrestamo = i.DocPrestamo
                objPrestamo.nroDoc = i.nroDoc
                objPrestamo.fechaPrestamo = i.fechaPrestamo
                objPrestamo.tipoBeneficiario = i.tipoBeneficiario
                objPrestamo.idBeneficiario = i.idBeneficiario
                objPrestamo.moneda = i.moneda
                objPrestamo.tipoCambio = i.tipoCambio
                'objPrestamo.interes = i.interes
                objPrestamo.tipoActivo = i.tipoActivo
                objPrestamo.monto = i.monto
                objPrestamo.montoUSD = i.montoUSD
                'objPrestamo.montoInteresSoles = i.montoInteresSoles
                'objPrestamo.montoInteresUSD = i.montoInteresUSD
                objPrestamo.entregaPendiente = i.entregaPendiente
                objPrestamo.desembolso = i.desembolso
                objPrestamo.periodo = i.periodo
                objPrestamo.fechaDesembolso = i.fechaDesembolso
                objPrestamo.numCuotas = i.numCuotas
                objPrestamo.estado = i.estado
                lista.Add(objPrestamo)
            Next

            Return lista

        Catch ex As Exception
            Throw ex
        End Try

    End Function




    Public Function ObtenerPrestamosXperiodo(ByVal strIdEmpresa As String, intIdEstablecimiento As Integer, ByVal strPeriodo As String,
                                             strTipoPrestamo As String) As List(Of prestamos)
        Try


            Dim lista As New List(Of prestamos)
            Dim objPrestamo As New prestamos
            Dim entidadbl As New entidadBL
            '    And s.estado = strEstado _
            Dim consulta = (From s In HeliosData.prestamos _
                                          Where s.idEmpresa = strIdEmpresa _
                                          And s.idEstablecimiento = intIdEstablecimiento _
                                          And s.periodo = strPeriodo _
                                          And s.tipoPrestamo = strTipoPrestamo _
                                          And s.entregaPendiente = "NO" _
                                          Select s).ToList
            For Each i In consulta
                objPrestamo = New prestamos
                objPrestamo.idDocumento = i.idDocumento
                objPrestamo.codigo = i.codigo
                objPrestamo.DocPrestamo = i.DocPrestamo

                objPrestamo.nroDoc = i.nroDoc
                objPrestamo.fechaPrestamo = i.fechaPrestamo
                objPrestamo.tipoBeneficiario = i.tipoBeneficiario
                objPrestamo.idBeneficiario = i.idBeneficiario

                ' With entidadBL.UbicarEntidadPorIdEntidad(Gempresas.IdEmpresaRuc, i.tipoBeneficiario, i.idBeneficiario)

                'objPrestamo.tipoBeneficiario = .nombreCompleto
                'End With
                objPrestamo.moneda = i.moneda
                objPrestamo.tipoCambio = i.tipoCambio
                'objPrestamo.interes = i.interes
                objPrestamo.tipoActivo = i.tipoActivo

                objPrestamo.monto = i.monto
                objPrestamo.montoUSD = i.montoUSD



                objPrestamo.entregaPendiente = i.entregaPendiente

                objPrestamo.desembolso = i.desembolso
                objPrestamo.periodo = i.periodo
                objPrestamo.fechaDesembolso = i.fechaDesembolso
                objPrestamo.numCuotas = i.numCuotas
                objPrestamo.estado = i.estado
                lista.Add(objPrestamo)
            Next

            Return lista
        Catch ex As Exception
            Throw ex
        End Try

    End Function


    'Public Function ObtenerPrestamosXperiodo(ByVal strIdEmpresa As String, intIdEstablecimiento As Integer, ByVal strPeriodo As String,
    '                                         strTipoPrestamo As String) As List(Of prestamos)
    '    Try

    '        '    And s.estado = strEstado _
    '        Return (From s In HeliosData.prestamos _
    '                                      Where s.idEmpresa = strIdEmpresa _
    '                                      And s.idEstablecimiento = intIdEstablecimiento _
    '                                      And s.periodo = strPeriodo _
    '                                      And s.tipoPrestamo = strTipoPrestamo _
    '                                      Select s).ToList

    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    'End Function

End Class
