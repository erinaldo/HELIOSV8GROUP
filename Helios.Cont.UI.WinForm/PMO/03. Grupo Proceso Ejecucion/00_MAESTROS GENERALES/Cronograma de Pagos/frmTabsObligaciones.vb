Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Tools

Public Class frmTabsObligaciones


#Region "Obligaciones"

    Public Sub UbicarDocumentoDetalleOtrasObligaciones(fechaprog As DateTime)

        Dim documentoVentaSA As New CronogramaSA
        Dim documentoLibro As New List(Of Cronograma)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable
        Dim entidadSA As New entidadSA
        Dim personaSA As New PersonaSA
        'Dim monto As Decimal = CDec(0.0)
        'Dim montome As Decimal = CDec(0.0)


        'Dim strPeriodo As String = String.Format("{0:00}", Convert.ToInt32(txtPeriodo.Value.Month)) & "/" & txtPeriodo.Value.Year


        dt.Columns.Add("nombres", GetType(String))
        dt.Columns.Add("serie", GetType(String))
        dt.Columns.Add("nrodoc", GetType(String))
        dt.Columns.Add("monto", GetType(Decimal))
        dt.Columns.Add("montome", GetType(Decimal))
        dt.Columns.Add("tipo", GetType(String))
        dt.Columns.Add("importe", GetType(Decimal))
        dt.Columns.Add("importeme", GetType(Decimal))
        dt.Columns.Add("glosa", GetType(String))
        dt.Columns.Add("fecha", GetType(Date))
        dt.Columns.Add("fechaPago", GetType(Date))
        dt.Columns.Add("estado", GetType(String))
        dt.Columns.Add("idcronograma", GetType(Integer))
        dt.Columns.Add("id", GetType(Integer))
        dt.Columns.Add("idDocRef", GetType(Integer))
        dt.Columns.Add("moneda", GetType(String))
        dt.Columns.Add("descripcion", GetType(String))
        documentoLibro = documentoVentaSA.GetCronogramaDetalleAsiento(fechaprog)

        If Not IsNothing(documentoLibro) Then


            For Each i In documentoLibro
                Dim dr As DataRow = dt.NewRow()



                If IsNothing(i.identidad) Then

                Else

                    Select Case i.tipoRazon
                        Case TIPO_ENTIDAD.PROVEEDOR
                            dr(13) = i.identidad
                            With entidadSA.UbicarEntidadPorID(i.identidad).First
                                dr(0) = .nombreCompleto
                            End With
                        Case TIPO_ENTIDAD.CLIENTE
                            dr(13) = i.identidad
                            With entidadSA.UbicarEntidadPorID(i.identidad).First
                                dr(0) = .nombreCompleto
                            End With
                        Case "TR"
                            dr(13) = i.identidad
                            With personaSA.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.identidad, "TR")
                                dr(0) = .nombreCompleto
                            End With
                    End Select
                End If

                dr(1) = " "
                dr(2) = i.nrodoc

                dr(3) = i.montoAutorizadoMN
                dr(4) = i.montoAutorizadoME

                If i.tipo = "P" Then
                    dr(5) = "Pago"
                ElseIf i.tipo = "C" Then
                    dr(5) = "Cobro"
                ElseIf i.tipo = "PA" Then
                    dr(5) = "Pago Asiento"
                End If

                dr(6) = CDec(0.0)
                dr(7) = CDec(0.0)
                dr(8) = i.glosa




                dr(9) = i.fechaoperacion
                dr(10) = i.fechaPago.GetValueOrDefault

                If i.estado = "PN" Then
                    dr(11) = "Pendiente"
                ElseIf i.estado = "AP" Then
                    dr(11) = "Aprobado"
                ElseIf i.estado = "OB" Then
                    dr(11) = "Observado"
                ElseIf i.estado = "PG" Then
                    dr(11) = "Desembolsado"
                End If

                dr(12) = i.idCronograma

                'dr(14) = i.idDocumentoRef
                dr(14) = i.idDocumentoRef
                dr(15) = i.moneda
                dr(16) = i.descripcion
                'monto += i.montoAutorizadoMN
                'montome += i.montoAutorizadoME


                dt.Rows.Add(dr)

            Next

            'txtImporteMN.Value = monto
            'txtImporteME.Value = montome

            dgvOtraObligacionDetalle.DataSource = dt
            'dgvProcesoCrono.ShowGroupDropArea = False
            'dgvProcesoCrono.TableDescriptor.GroupedColumns.Clear()
            'dgvProcesoCrono.TableDescriptor.GroupedColumns.Add("nombres")

            Me.dgvOtraObligacionDetalle.TableOptions.ListBoxSelectionMode = SelectionMode.One


        Else

        End If


    End Sub


    Public Sub UbicarDocumentoDetalleObligaciones(fechaprog As DateTime, fechaven As DateTime)

        Dim documentoVentaSA As New CronogramaSA
        Dim documentoLibro As New List(Of Cronograma)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable
        Dim entidadSA As New entidadSA
        Dim personaSA As New PersonaSA
        'Dim monto As Decimal = CDec(0.0)
        'Dim montome As Decimal = CDec(0.0)


        'Dim strPeriodo As String = String.Format("{0:00}", Convert.ToInt32(txtPeriodo.Value.Month)) & "/" & txtPeriodo.Value.Year


        dt.Columns.Add("nombres", GetType(String))
        dt.Columns.Add("serie", GetType(String))
        dt.Columns.Add("nrodoc", GetType(String))
        dt.Columns.Add("monto", GetType(Decimal))
        dt.Columns.Add("montome", GetType(Decimal))
        dt.Columns.Add("tipo", GetType(String))
        dt.Columns.Add("importe", GetType(Decimal))
        dt.Columns.Add("importeme", GetType(Decimal))
        dt.Columns.Add("glosa", GetType(String))
        dt.Columns.Add("fecha", GetType(Date))
        dt.Columns.Add("fechaPago", GetType(Date))
        dt.Columns.Add("estado", GetType(String))
        dt.Columns.Add("idcronograma", GetType(Integer))
        dt.Columns.Add("id", GetType(Integer))
        dt.Columns.Add("idDocRef", GetType(Integer))
        dt.Columns.Add("moneda", GetType(String))
        documentoLibro = documentoVentaSA.GetCronogramaDetalle(fechaprog, fechaven)

        If Not IsNothing(documentoLibro) Then


            For Each i In documentoLibro
                Dim dr As DataRow = dt.NewRow()



                If IsNothing(i.identidad) Then

                Else

                    Select Case i.tipoRazon
                        Case TIPO_ENTIDAD.PROVEEDOR
                            dr(13) = i.identidad
                            With entidadSA.UbicarEntidadPorID(i.identidad).First
                                dr(0) = .nombreCompleto
                            End With
                        Case TIPO_ENTIDAD.CLIENTE
                            dr(13) = i.identidad
                            With entidadSA.UbicarEntidadPorID(i.identidad).First
                                dr(0) = .nombreCompleto
                            End With
                        Case "TR"
                            dr(13) = i.identidad
                            With personaSA.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.identidad, "TR")
                                dr(0) = .nombreCompleto
                            End With
                    End Select
                End If

                dr(1) = i.serie
                dr(2) = i.nrodoc

                dr(3) = i.montoAutorizadoMN
                dr(4) = i.montoAutorizadoME

                If i.tipo = "P" Then
                    dr(5) = "Pago"
                ElseIf i.tipo = "C" Then
                    dr(5) = "Cobro"
                End If

                dr(6) = CDec(0.0)
                dr(7) = CDec(0.0)
                dr(8) = i.glosa




                dr(9) = i.fechaoperacion
                dr(10) = i.fechaPago.GetValueOrDefault

                If i.estado = "PN" Then
                    dr(11) = "Pendiente"
                ElseIf i.estado = "AP" Then
                    dr(11) = "Aprobado"
                ElseIf i.estado = "OB" Then
                    dr(11) = "Observado"
                ElseIf i.estado = "PG" Then
                    dr(11) = "Desembolsado"
                End If

                dr(12) = i.idCronograma

                'dr(14) = i.idDocumentoRef
                dr(14) = i.idDocumentoRef
                dr(15) = i.moneda
                'monto += i.montoAutorizadoMN
                'montome += i.montoAutorizadoME


                dt.Rows.Add(dr)

            Next

            'txtImporteMN.Value = monto
            'txtImporteME.Value = montome

            dgvObligacionesDetalle.DataSource = dt
            'dgvProcesoCrono.ShowGroupDropArea = False
            'dgvProcesoCrono.TableDescriptor.GroupedColumns.Clear()
            'dgvProcesoCrono.TableDescriptor.GroupedColumns.Add("nombres")

            Me.dgvObligacionesDetalle.TableOptions.ListBoxSelectionMode = SelectionMode.One


        Else

        End If


    End Sub

    Private Sub ProgramacionOtrasObligaciones(TipoProg As String)
        Dim documentoVentaSA As New CronogramaSA
        Dim documentoLibro As New List(Of Cronograma)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable
        Dim entidadSA As New entidadSA
        Dim personaSA As New PersonaSA
        'Dim monto As Decimal = CDec(0.0)
        'Dim montome As Decimal = CDec(0.0)


        'Dim strPeriodo As String = String.Format("{0:00}", Convert.ToInt32(txtPeriodo.Value.Month)) & "/" & txtPeriodo.Value.Year


        dt.Columns.Add("nombres", GetType(String))
        dt.Columns.Add("monto", GetType(Decimal))
        dt.Columns.Add("montome", GetType(Decimal))
        dt.Columns.Add("tipo", GetType(String))
        dt.Columns.Add("importe", GetType(Decimal))
        dt.Columns.Add("importeme", GetType(Decimal))
        dt.Columns.Add("glosa", GetType(String))
        dt.Columns.Add("fecha", GetType(Date))
        dt.Columns.Add("fechaPago", GetType(Date))
        dt.Columns.Add("estado", GetType(String))
        dt.Columns.Add("idcronograma", GetType(Integer))
        dt.Columns.Add("id", GetType(Integer))
        dt.Columns.Add("idDocRef", GetType(Integer))

        documentoLibro = documentoVentaSA.GetCronogramaPagoCobro(TipoProg)

        If Not IsNothing(documentoLibro) Then


            For Each i In documentoLibro
                Dim dr As DataRow = dt.NewRow()

                dr(11) = 0
                dr(0) = "N"

                dr(1) = i.montoAutorizadoMN
                dr(2) = i.montoAutorizadoME

                If i.tipo = "P" Then
                    dr(3) = "Pago"
                ElseIf i.tipo = "C" Then
                    dr(3) = "Cobro"
                ElseIf i.tipo = "PA" Then

                    dr(3) = "Pago Asiento"
                End If

                dr(4) = CDec(0.0)
                dr(5) = CDec(0.0)
                dr(6) = i.glosa

                dr(7) = i.fechaoperacion
                dr(8) = i.fechaPago
                dr(9) = "N"
                dr(10) = 0
                dr(12) = 0
                dt.Rows.Add(dr)

            Next


            dgvOtraObligaciones.DataSource = dt
            'dgvProcesoCrono.ShowGroupDropArea = False
            'dgvProcesoCrono.TableDescriptor.GroupedColumns.Clear()
            'dgvProcesoCrono.TableDescriptor.GroupedColumns.Add("nombres")

            Me.dgvOtraObligaciones.TableOptions.ListBoxSelectionMode = SelectionMode.One


        Else

        End If
    End Sub


    Private Sub ProgramacionObligaciones(TipoProg As String)
        Dim documentoVentaSA As New CronogramaSA
        Dim documentoLibro As New List(Of Cronograma)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable
        Dim entidadSA As New entidadSA
        Dim personaSA As New PersonaSA
        'Dim monto As Decimal = CDec(0.0)
        'Dim montome As Decimal = CDec(0.0)


        'Dim strPeriodo As String = String.Format("{0:00}", Convert.ToInt32(txtPeriodo.Value.Month)) & "/" & txtPeriodo.Value.Year


        dt.Columns.Add("nombres", GetType(String))
        dt.Columns.Add("monto", GetType(Decimal))
        dt.Columns.Add("montome", GetType(Decimal))
        dt.Columns.Add("tipo", GetType(String))
        dt.Columns.Add("importe", GetType(Decimal))
        dt.Columns.Add("importeme", GetType(Decimal))
        dt.Columns.Add("glosa", GetType(String))
        dt.Columns.Add("fecha", GetType(Date))
        dt.Columns.Add("fechaPago", GetType(Date))
        dt.Columns.Add("estado", GetType(String))
        dt.Columns.Add("idcronograma", GetType(Integer))
        dt.Columns.Add("id", GetType(Integer))
        dt.Columns.Add("idDocRef", GetType(Integer))

        documentoLibro = documentoVentaSA.GetCronogramaPagoCobro(TipoProg)

        If Not IsNothing(documentoLibro) Then


            For Each i In documentoLibro
                Dim dr As DataRow = dt.NewRow()

                dr(11) = 0
                dr(0) = "N"

                dr(1) = i.montoAutorizadoMN
                dr(2) = i.montoAutorizadoME

                If i.tipo = "P" Then
                    dr(3) = "Pago"
                ElseIf i.tipo = "C" Then
                    dr(3) = "Cobro"
                ElseIf i.tipo = "PA" Then

                    dr(3) = "Pago Asiento"
                End If

                dr(4) = CDec(0.0)
                dr(5) = CDec(0.0)
                dr(6) = i.glosa

                dr(7) = i.fechaoperacion
                dr(8) = i.fechaPago
                dr(9) = "N"
                dr(10) = 0
                dr(12) = 0
                dt.Rows.Add(dr)

            Next


            dgvObligaciones.DataSource = dt
            'dgvProcesoCrono.ShowGroupDropArea = False
            'dgvProcesoCrono.TableDescriptor.GroupedColumns.Clear()
            'dgvProcesoCrono.TableDescriptor.GroupedColumns.Add("nombres")

            Me.dgvObligaciones.TableOptions.ListBoxSelectionMode = SelectionMode.One


        Else

        End If
    End Sub

    Private Sub OtrasObligaciones()
        Dim documentoVentaSA As New DocumentoCompraSA
        Dim documentoLibro As New List(Of documentoLibroDiarioDetalle)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable
        Dim entidadSA As New entidadSA
        Dim personaSA As New PersonaSA

        dt.Columns.Add("idProveedor", GetType(Integer))
        dt.Columns.Add("cuenta", GetType(String))
        dt.Columns.Add("descripcion", GetType(String))
        dt.Columns.Add("razonSocial", GetType(String))
        dt.Columns.Add("deuda", GetType(Decimal))
        dt.Columns.Add("montoPago", GetType(Decimal))
        dt.Columns.Add("saldo", GetType(Decimal))
        dt.Columns.Add("montoVencido", GetType(Decimal))
        dt.Columns.Add("montoProg", GetType(Decimal))
        dt.Columns.Add("deudaME", GetType(Decimal))
        dt.Columns.Add("montoPagoME", GetType(Decimal))
        dt.Columns.Add("saldome", GetType(Decimal))
        dt.Columns.Add("montoVencidoME", GetType(Decimal))
        dt.Columns.Add("montoProgME", GetType(Decimal))


        documentoLibro = documentoVentaSA.DeudasGeneralesAsiento()

        If Not IsNothing(documentoLibro) Then


            For Each i In documentoLibro
                Dim dr As DataRow = dt.NewRow()

                dr(0) = 1
                dr(1) = i.cuenta
                dr(2) = i.descripcion
                dr(3) = ""

                dr(4) = i.importeMN
                dr(5) = i.ImportePagoMN
                dr(6) = i.importeMN - i.ImportePagoMN
                dr(7) = i.montovencido - i.ImportePagoVencidoMN
                dr(8) = i.montocrono


                dr(9) = i.importeME
                dr(10) = i.ImportePagoME
                dr(11) = i.importeME - i.ImportePagoME
                dr(12) = i.montovencidome - i.ImportePagoVencidoME
                dr(13) = i.montocronome

                'doccompra.ImportePagoVencidoMN = i.PagoDeudaVencida.GetValueOrDefault
                'doccompra.ImportePagoVencidoME = i.PagoDeudaVencidaME.GetValueOrDefault

                dt.Rows.Add(dr)

            Next


            dgvGeneralPagos.DataSource = dt
            Me.dgvGeneralPagos.TableOptions.ListBoxSelectionMode = SelectionMode.One

            dgvGeneralPagos.TableDescriptor.Columns("razonSocial").Width = 0
            dgvGeneralPagos.TableDescriptor.Columns("cuenta").Width = 70
            dgvGeneralPagos.TableDescriptor.Columns("descripcion").Width = 180
        Else

        End If
    End Sub

    Private Sub ObligacionesGenerales()
        Dim documentoVentaSA As New DocumentoCompraSA
        Dim documentoLibro As New List(Of documentocompra)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable
        Dim entidadSA As New entidadSA
        Dim personaSA As New PersonaSA


        dt.Columns.Add("idProveedor", GetType(Integer))
        dt.Columns.Add("cuenta", GetType(String))
        dt.Columns.Add("descripcion", GetType(String))
        dt.Columns.Add("razonSocial", GetType(String))
        dt.Columns.Add("deuda", GetType(Decimal))
        dt.Columns.Add("montoPago", GetType(Decimal))
        dt.Columns.Add("saldo", GetType(Decimal))
        dt.Columns.Add("montoVencido", GetType(Decimal))
        dt.Columns.Add("montoProg", GetType(Decimal))
        dt.Columns.Add("deudaME", GetType(Decimal))
        dt.Columns.Add("montoPagoME", GetType(Decimal))
        dt.Columns.Add("saldome", GetType(Decimal))
        dt.Columns.Add("montoVencidoME", GetType(Decimal))
        dt.Columns.Add("montoProgME", GetType(Decimal))





        documentoLibro = documentoVentaSA.DeudasGenerales()

        If Not IsNothing(documentoLibro) Then


            For Each i In documentoLibro
                Dim dr As DataRow = dt.NewRow()

                dr(0) = i.idProveedor
                dr(1) = ""
                dr(2) = ""
                dr(3) = i.NombreEntidad

                dr(4) = i.importeTotal
                dr(5) = i.ImportePagoMN
                dr(6) = i.importeTotal - i.ImportePagoMN
                dr(7) = i.montovencido - i.ImportePagoVencidoMN
                dr(8) = i.montocrono


                dr(9) = i.importeUS
                dr(10) = i.ImportePagoME
                dr(11) = i.importeUS - i.ImportePagoME
                dr(12) = i.montovencidome - i.ImportePagoVencidoME
                dr(13) = i.montocronome

                'doccompra.ImportePagoVencidoMN = i.PagoDeudaVencida.GetValueOrDefault
                'doccompra.ImportePagoVencidoME = i.PagoDeudaVencidaME.GetValueOrDefault

                dt.Rows.Add(dr)

            Next


            dgvGeneralPagos.DataSource = dt
            Me.dgvGeneralPagos.TableOptions.ListBoxSelectionMode = SelectionMode.One

            dgvGeneralPagos.TableDescriptor.Columns("cuenta").Width = 0
            dgvGeneralPagos.TableDescriptor.Columns("descripcion").Width = 0
            dgvGeneralPagos.TableDescriptor.Columns("razonSocial").Width = 180

        Else

        End If
    End Sub

#End Region


#Region "ACREENCIAS"


    Private Sub OtrasAcreencias()
        Dim documentoVentaSA As New DocumentoCompraSA
        Dim documentoLibro As New List(Of documentoLibroDiarioDetalle)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable
        Dim entidadSA As New entidadSA
        Dim personaSA As New PersonaSA

        dt.Columns.Add("idProveedor", GetType(Integer))
        dt.Columns.Add("cuenta", GetType(String))
        dt.Columns.Add("descripcion", GetType(String))
        dt.Columns.Add("razonSocial", GetType(String))
        dt.Columns.Add("deuda", GetType(Decimal))
        dt.Columns.Add("montoPago", GetType(Decimal))
        dt.Columns.Add("saldo", GetType(Decimal))
        dt.Columns.Add("montoVencido", GetType(Decimal))
        dt.Columns.Add("montoProg", GetType(Decimal))
        dt.Columns.Add("deudaME", GetType(Decimal))
        dt.Columns.Add("montoPagoME", GetType(Decimal))
        dt.Columns.Add("saldome", GetType(Decimal))
        dt.Columns.Add("montoVencidoME", GetType(Decimal))
        dt.Columns.Add("montoProgME", GetType(Decimal))


        documentoLibro = documentoVentaSA.CobrosGeneralesAsiento()

        If Not IsNothing(documentoLibro) Then


            For Each i In documentoLibro
                Dim dr As DataRow = dt.NewRow()

                dr(0) = 1
                dr(1) = i.cuenta
                dr(2) = i.descripcion
                dr(3) = ""

                dr(4) = i.importeMN
                dr(5) = i.ImportePagoMN
                dr(6) = i.importeMN - i.ImportePagoMN
                dr(7) = i.montovencido - i.ImportePagoVencidoMN
                dr(8) = i.montocrono


                dr(9) = i.importeME
                dr(10) = i.ImportePagoME
                dr(11) = i.importeME - i.ImportePagoME
                dr(12) = i.montovencidome - i.ImportePagoVencidoME
                dr(13) = i.montocronome

                'doccompra.ImportePagoVencidoMN = i.PagoDeudaVencida.GetValueOrDefault
                'doccompra.ImportePagoVencidoME = i.PagoDeudaVencidaME.GetValueOrDefault

                dt.Rows.Add(dr)

            Next


            dgvGeneralCobros.DataSource = dt
            Me.dgvGeneralCobros.TableOptions.ListBoxSelectionMode = SelectionMode.One

            dgvGeneralCobros.TableDescriptor.Columns("razonSocial").Width = 0
            dgvGeneralCobros.TableDescriptor.Columns("cuenta").Width = 70
            dgvGeneralCobros.TableDescriptor.Columns("descripcion").Width = 180
        Else

        End If
    End Sub

    Public Sub CronogramaAcreenciasDetalle(fechaprog As DateTime, fechaven As DateTime)

        Dim documentoVentaSA As New CronogramaSA
        Dim documentoLibro As New List(Of Cronograma)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable
        Dim entidadSA As New entidadSA
        Dim personaSA As New PersonaSA
        'Dim monto As Decimal = CDec(0.0)
        'Dim montome As Decimal = CDec(0.0)


        'Dim strPeriodo As String = String.Format("{0:00}", Convert.ToInt32(txtPeriodo.Value.Month)) & "/" & txtPeriodo.Value.Year


        dt.Columns.Add("nombres", GetType(String))
        dt.Columns.Add("serie", GetType(String))
        dt.Columns.Add("nrodoc", GetType(String))
        dt.Columns.Add("monto", GetType(Decimal))
        dt.Columns.Add("montome", GetType(Decimal))
        dt.Columns.Add("tipo", GetType(String))
        dt.Columns.Add("importe", GetType(Decimal))
        dt.Columns.Add("importeme", GetType(Decimal))
        dt.Columns.Add("glosa", GetType(String))
        dt.Columns.Add("fecha", GetType(Date))
        dt.Columns.Add("fechaPago", GetType(Date))
        dt.Columns.Add("estado", GetType(String))
        dt.Columns.Add("idcronograma", GetType(Integer))
        dt.Columns.Add("id", GetType(Integer))
        dt.Columns.Add("idDocRef", GetType(Integer))
        dt.Columns.Add("moneda", GetType(String))
        documentoLibro = documentoVentaSA.GetCronogramaDetalleCobro(fechaprog, fechaven)

        If Not IsNothing(documentoLibro) Then


            For Each i In documentoLibro
                Dim dr As DataRow = dt.NewRow()



                If IsNothing(i.identidad) Then

                Else

                    Select Case i.tipoRazon
                        Case TIPO_ENTIDAD.PROVEEDOR
                            dr(13) = i.identidad
                            With entidadSA.UbicarEntidadPorID(i.identidad).First
                                dr(0) = .nombreCompleto
                            End With
                        Case TIPO_ENTIDAD.CLIENTE
                            dr(13) = i.identidad
                            With entidadSA.UbicarEntidadPorID(i.identidad).First
                                dr(0) = .nombreCompleto
                            End With
                        Case "TR"
                            dr(13) = i.identidad
                            With personaSA.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.identidad, "TR")
                                dr(0) = .nombreCompleto
                            End With
                    End Select
                End If

                dr(1) = i.serie
                dr(2) = i.nrodoc

                dr(3) = i.montoAutorizadoMN
                dr(4) = i.montoAutorizadoME

                If i.tipo = "P" Then
                    dr(5) = "Pago"
                ElseIf i.tipo = "C" Then
                    dr(5) = "Cobro"
                End If

                dr(6) = CDec(0.0)
                dr(7) = CDec(0.0)
                dr(8) = i.glosa




                dr(9) = i.fechaoperacion
                dr(10) = i.fechaPago.GetValueOrDefault

                If i.estado = "PN" Then
                    dr(11) = "Pendiente"
                ElseIf i.estado = "AP" Then
                    dr(11) = "Aprobado"
                ElseIf i.estado = "OB" Then
                    dr(11) = "Observado"
                ElseIf i.estado = "PG" Then
                    dr(11) = "Desembolsado"
                End If

                dr(12) = i.idCronograma

                'dr(14) = i.idDocumentoRef
                dr(14) = i.idDocumentoRef
                dr(15) = i.moneda
                'monto += i.montoAutorizadoMN
                'montome += i.montoAutorizadoME


                dt.Rows.Add(dr)

            Next

            'txtImporteMN.Value = monto
            'txtImporteME.Value = montome

            dgvAcreenciasDet.DataSource = dt
            'dgvProcesoCrono.ShowGroupDropArea = False
            'dgvProcesoCrono.TableDescriptor.GroupedColumns.Clear()
            'dgvProcesoCrono.TableDescriptor.GroupedColumns.Add("nombres")

            Me.dgvAcreenciasDet.TableOptions.ListBoxSelectionMode = SelectionMode.One


        Else

        End If


    End Sub


    Private Sub CronogramaAcreencias(TipoProg As String)
        Dim documentoVentaSA As New CronogramaSA
        Dim documentoLibro As New List(Of Cronograma)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable
        Dim entidadSA As New entidadSA
        Dim personaSA As New PersonaSA
        'Dim monto As Decimal = CDec(0.0)
        'Dim montome As Decimal = CDec(0.0)


        'Dim strPeriodo As String = String.Format("{0:00}", Convert.ToInt32(txtPeriodo.Value.Month)) & "/" & txtPeriodo.Value.Year


        dt.Columns.Add("nombres", GetType(String))
        dt.Columns.Add("monto", GetType(Decimal))
        dt.Columns.Add("montome", GetType(Decimal))
        dt.Columns.Add("tipo", GetType(String))
        dt.Columns.Add("importe", GetType(Decimal))
        dt.Columns.Add("importeme", GetType(Decimal))
        dt.Columns.Add("glosa", GetType(String))
        dt.Columns.Add("fecha", GetType(Date))
        dt.Columns.Add("fechaPago", GetType(Date))
        dt.Columns.Add("estado", GetType(String))
        dt.Columns.Add("idcronograma", GetType(Integer))
        dt.Columns.Add("id", GetType(Integer))
        dt.Columns.Add("idDocRef", GetType(Integer))

        documentoLibro = documentoVentaSA.GetCronogramaPagoCobro(TipoProg)

        If Not IsNothing(documentoLibro) Then


            For Each i In documentoLibro
                Dim dr As DataRow = dt.NewRow()

                dr(11) = 0
                dr(0) = "N"

                dr(1) = i.montoAutorizadoMN
                dr(2) = i.montoAutorizadoME

                If i.tipo = "P" Then
                    dr(3) = "Pago"
                ElseIf i.tipo = "C" Then
                    dr(3) = "Cobro"
                ElseIf i.tipo = "PA" Then

                    dr(3) = "Pago Asiento"
                End If

                dr(4) = CDec(0.0)
                dr(5) = CDec(0.0)
                dr(6) = i.glosa

                dr(7) = i.fechaoperacion
                dr(8) = i.fechaPago
                dr(9) = "N"
                dr(10) = 0
                dr(12) = 0
                dt.Rows.Add(dr)

            Next


            dgvAcreencias.DataSource = dt
            'dgvProcesoCrono.ShowGroupDropArea = False
            'dgvProcesoCrono.TableDescriptor.GroupedColumns.Clear()
            'dgvProcesoCrono.TableDescriptor.GroupedColumns.Add("nombres")

            Me.dgvAcreencias.TableOptions.ListBoxSelectionMode = SelectionMode.One


        Else

        End If
    End Sub

    Private Sub AcreenciasGenerales()
        Dim documentoVentaSA As New documentoVentaAbarrotesSA
        Dim documentoLibro As New List(Of documentoventaAbarrotes)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable
        Dim entidadSA As New entidadSA
        Dim personaSA As New PersonaSA


        dt.Columns.Add("idProveedor", GetType(Integer))
        dt.Columns.Add("cuenta", GetType(String))
        dt.Columns.Add("descripcion", GetType(String))
        dt.Columns.Add("razonSocial", GetType(String))
        dt.Columns.Add("deuda", GetType(Decimal))
        dt.Columns.Add("montoPago", GetType(Decimal))
        dt.Columns.Add("saldo", GetType(Decimal))
        dt.Columns.Add("montoVencido", GetType(Decimal))
        dt.Columns.Add("montoProg", GetType(Decimal))
        dt.Columns.Add("deudaME", GetType(Decimal))
        dt.Columns.Add("montoPagoME", GetType(Decimal))
        dt.Columns.Add("saldome", GetType(Decimal))
        dt.Columns.Add("montoVencidoME", GetType(Decimal))
        dt.Columns.Add("montoProgME", GetType(Decimal))



        documentoLibro = documentoVentaSA.CobrosGenerales()

        If Not IsNothing(documentoLibro) Then


            For Each i In documentoLibro
                Dim dr As DataRow = dt.NewRow()

                dr(0) = i.idCliente
                dr(1) = ""
                dr(2) = ""
                dr(3) = i.NombreEntidad

                dr(4) = i.ImporteNacional
                dr(5) = i.importeCostoMN
                dr(6) = i.ImporteNacional - i.importeCostoMN
                dr(7) = i.montovencido - i.ImportePagoVencidoMN
                dr(8) = i.montocrono


                dr(9) = i.ImporteExtranjero
                dr(10) = i.importeCostoME
                dr(11) = i.ImporteExtranjero - i.importeCostoME
                dr(12) = i.montovencidome - i.ImportePagoVencidoME
                dr(13) = i.montocronome

                'doccompra.ImportePagoVencidoMN = i.PagoDeudaVencida.GetValueOrDefault
                'doccompra.ImportePagoVencidoME = i.PagoDeudaVencidaME.GetValueOrDefault

                dt.Rows.Add(dr)

            Next


            dgvGeneralCobros.DataSource = dt
            Me.dgvGeneralCobros.TableOptions.ListBoxSelectionMode = SelectionMode.One

            dgvGeneralCobros.TableDescriptor.Columns("cuenta").Width = 0
            dgvGeneralCobros.TableDescriptor.Columns("descripcion").Width = 0
            dgvGeneralCobros.TableDescriptor.Columns("razonSocial").Width = 180
        Else

        End If
    End Sub
#End Region

    Private Sub frmTabsObligaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonAdv46_Click(sender As Object, e As EventArgs) Handles ButtonAdv46.Click
        AcreenciasGenerales()
    End Sub

    Private Sub ButtonAdv45_Click(sender As Object, e As EventArgs) Handles ButtonAdv45.Click
        With frmFlujoCobros
            .StartPosition = FormStartPosition.CenterParent
            '.Label4.Text = "Acreencias"
            '.cbotipo.Text = "COBROS"
            .ShowDialog()
        End With
    End Sub

    Private Sub ButtonAdv47_Click(sender As Object, e As EventArgs) Handles ButtonAdv47.Click
        With frmFlujoCobros
            .StartPosition = FormStartPosition.CenterParent
            '.Label4.Text = "Acreencias"
            '.cbotipo.Text = "COBROS"
            .ShowDialog()
        End With
    End Sub

    Private Sub ButtonAdv48_Click(sender As Object, e As EventArgs) Handles ButtonAdv48.Click
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(dgvAcreencias.Table.CurrentRecord) Then


            With frmCronogramaKanban

                'If dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo") = "Pago" Then

                '    .Programacion(dgvProcesoCrono.Table.CurrentRecord.GetValue("fecha"), "P")
                '    .txtTipoProgramacion.Text = "PAGOS"
                'ElseIf dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo") = "Cobro" Then

                .Programacion(dgvAcreencias.Table.CurrentRecord.GetValue("fecha"), "C", dgvAcreencias.Table.CurrentRecord.GetValue("fechaPago"))
                .txtTipoProgramacion.Text = "COBROS"
                'ElseIf dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo") = "Pago Asiento" Then

                '.Programacion(dgvProcesoCrono.Table.CurrentRecord.GetValue("fecha"), "PA")
                '.txtTipoProgramacion.Text = "PAGOS ASIENTO"

                'End If


                .txtFechaVen.Value = dgvAcreencias.Table.CurrentRecord.GetValue("fechaPago")
                .txtFecha.Value = dgvAcreencias.Table.CurrentRecord.GetValue("fecha")
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With

        Else
            ' MessageBox.Show("Seleccione un Item a Eliminar")
            MessageBox.Show("Seleccione un Programacion para trabajar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv44_Click(sender As Object, e As EventArgs) Handles ButtonAdv44.Click
        CronogramaAcreencias("C")
    End Sub

    Private Sub ButtonAdv43_Click(sender As Object, e As EventArgs) Handles ButtonAdv43.Click
        With frmHistorialCronograma

            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
    End Sub

    Private Sub dgvAcreencias_SelectedRecordsChanging(sender As Object, e As SelectedRecordsChangedEventArgs) Handles dgvAcreencias.SelectedRecordsChanging
        Me.Cursor = Cursors.WaitCursor
        'GridGroupingControl2.Table.Records.DeleteAll()
        If Not IsNothing(dgvAcreencias.Table.CurrentRecord) Then
            'UbicarDocumentoDetalle(dgvProcesoCrono.Table.CurrentRecord.GetValue("id"), "PR")
            If dgvAcreencias.Table.CurrentRecord.GetValue("tipo") = "Pago" Then

                'UbicarDocumentoDetalle(dgvProcesoCrono.Table.CurrentRecord.GetValue("fecha"))
            ElseIf dgvAcreencias.Table.CurrentRecord.GetValue("tipo") = "Cobro" Then

                CronogramaAcreenciasDetalle(dgvAcreencias.Table.CurrentRecord.GetValue("fecha"), dgvAcreencias.Table.CurrentRecord.GetValue("fechaPago"))

            ElseIf dgvAcreencias.Table.CurrentRecord.GetValue("tipo") = "Pago Asiento" Then

                'UbicarDocumentoDetalleAsiento(dgvProcesoCrono.Table.CurrentRecord.GetValue("fecha"))
            End If

        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvAcreencias_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvAcreencias.TableControlCellClick

    End Sub

    Private Sub ButtonAdv27_Click(sender As Object, e As EventArgs) Handles ButtonAdv27.Click
        ObligacionesGenerales()
    End Sub

    Private Sub ButtonAdv25_Click(sender As Object, e As EventArgs) Handles ButtonAdv25.Click
        OtrasObligaciones()
    End Sub

    Private Sub ButtonAdv26_Click(sender As Object, e As EventArgs) Handles ButtonAdv26.Click
        With frmFlujoPagos
            .StartPosition = FormStartPosition.CenterParent
            '.Label4.Text = "Obligaciones"
            '.cbotipo.Text = "PAGOS"
            .Size = New Size(1340, 708)
            .ShowDialog()
        End With
    End Sub

    Private Sub ButtonAdv28_Click(sender As Object, e As EventArgs) Handles ButtonAdv28.Click
        With frmFlujoAsientoManualPago
            .StartPosition = FormStartPosition.CenterParent
            '.Label4.Text = "Obligaciones"
            '.cbotipo.Text = "PAGOS"
            .Size = New Size(1340, 708)
            .ShowDialog()
        End With
    End Sub

    Private Sub ButtonAdv33_Click(sender As Object, e As EventArgs) Handles ButtonAdv33.Click
        With frmFlujoPagos
            .StartPosition = FormStartPosition.CenterParent
            '.Label4.Text = "Obligaciones"
            '.cbotipo.Text = "PAGOS"
            .Size = New Size(1340, 708)
            .ShowDialog()
        End With
    End Sub

    Private Sub ButtonAdv34_Click(sender As Object, e As EventArgs) Handles ButtonAdv34.Click
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(dgvObligaciones.Table.CurrentRecord) Then


            With frmCronogramaKanban


                .Programacion(dgvObligaciones.Table.CurrentRecord.GetValue("fecha"), "P", dgvObligaciones.Table.CurrentRecord.GetValue("fechaPago"))
                .txtTipoProgramacion.Text = "PAGOS"
                'If dgvObligaciones.Table.CurrentRecord.GetValue("tipo") = "Pago" Then

                '    .Programacion(dgvObligaciones.Table.CurrentRecord.GetValue("fecha"), "P")
                '    .txtTipoProgramacion.Text = "PAGOS"
                'ElseIf dgvObligaciones.Table.CurrentRecord.GetValue("tipo") = "Cobro" Then

                '    .Programacion(dgvObligaciones.Table.CurrentRecord.GetValue("fecha"), "C")
                '    .txtTipoProgramacion.Text = "COBROS"
                'ElseIf dgvObligaciones.Table.CurrentRecord.GetValue("tipo") = "Pago Asiento" Then

                '    .Programacion(dgvObligaciones.Table.CurrentRecord.GetValue("fecha"), "PA")
                '    .txtTipoProgramacion.Text = "PAGOS ASIENTO"

                'End If


                .txtFechaVen.Value = dgvObligaciones.Table.CurrentRecord.GetValue("fechaPago")
                .txtFecha.Value = dgvObligaciones.Table.CurrentRecord.GetValue("fecha")
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With

        Else
            ' MessageBox.Show("Seleccione un Item a Eliminar")
            MessageBox.Show("Seleccione un Programacion para trabajar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv31_Click(sender As Object, e As EventArgs) Handles ButtonAdv31.Click
        Me.Cursor = Cursors.WaitCursor

        'If ComboBox1.Text = "PAGOS" Then
        ProgramacionObligaciones("P")
        'ElseIf ComboBox1.Text = "COBROS" Then
        '    Programacion("C")
        'ElseIf ComboBox1.Text = "PAGOS ASIENTO" Then
        '    Programacion("PA")
        'End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv30_Click(sender As Object, e As EventArgs) Handles ButtonAdv30.Click
        With frmHistorialCronograma

            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
    End Sub

    Private Sub dgvObligaciones_SelectedRecordsChanging(sender As Object, e As SelectedRecordsChangedEventArgs) Handles dgvObligaciones.SelectedRecordsChanging
        Me.Cursor = Cursors.WaitCursor
        'GridGroupingControl2.Table.Records.DeleteAll()
        If Not IsNothing(dgvObligaciones.Table.CurrentRecord) Then
            'UbicarDocumentoDetalle(dgvProcesoCrono.Table.CurrentRecord.GetValue("id"), "PR")
            If dgvObligaciones.Table.CurrentRecord.GetValue("tipo") = "Pago" Then

                UbicarDocumentoDetalleObligaciones(dgvObligaciones.Table.CurrentRecord.GetValue("fecha"), dgvObligaciones.Table.CurrentRecord.GetValue("fechaPago"))
            ElseIf dgvObligaciones.Table.CurrentRecord.GetValue("tipo") = "Cobro" Then

                'UbicarDocumentoDetalleCobro(dgvProcesoCrono.Table.CurrentRecord.GetValue("fecha"))

            ElseIf dgvObligaciones.Table.CurrentRecord.GetValue("tipo") = "Pago Asiento" Then

                'UbicarDocumentoDetalleAsiento(dgvProcesoCrono.Table.CurrentRecord.GetValue("fecha"))
            End If

        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvObligaciones_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvObligaciones.TableControlCellClick

    End Sub

    Private Sub ButtonAdv38_Click(sender As Object, e As EventArgs) Handles ButtonAdv38.Click
        With frmFlujoAsientoManualPago
            .StartPosition = FormStartPosition.CenterParent
            '.Label4.Text = "Acreencias"
            '.cbotipo.Text = "COBROS"
            .ShowDialog()
        End With
    End Sub

    Private Sub ButtonAdv39_Click(sender As Object, e As EventArgs) Handles ButtonAdv39.Click
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(dgvOtraObligaciones.Table.CurrentRecord) Then


            With frmCronogramaKanban

                'If dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo") = "Pago" Then

                '    .Programacion(dgvProcesoCrono.Table.CurrentRecord.GetValue("fecha"), "P")
                '    .txtTipoProgramacion.Text = "PAGOS"
                'ElseIf dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo") = "Cobro" Then

                '    .Programacion(dgvProcesoCrono.Table.CurrentRecord.GetValue("fecha"), "C")
                '    .txtTipoProgramacion.Text = "COBROS"
                'ElseIf dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo") = "Pago Asiento" Then

                .Programacion(dgvOtraObligaciones.Table.CurrentRecord.GetValue("fecha"), "PA", dgvOtraObligaciones.Table.CurrentRecord.GetValue("fechaPago"))
                .txtTipoProgramacion.Text = "PAGOS ASIENTO"

                'End If


                .txtFechaVen.Value = dgvOtraObligaciones.Table.CurrentRecord.GetValue("fechaPago")
                .txtFecha.Value = dgvOtraObligaciones.Table.CurrentRecord.GetValue("fecha")
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With

        Else
            ' MessageBox.Show("Seleccione un Item a Eliminar")
            MessageBox.Show("Seleccione un Programacion para trabajar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv32_Click(sender As Object, e As EventArgs) Handles ButtonAdv32.Click
        Me.Cursor = Cursors.WaitCursor

        'If ComboBox1.Text = "PAGOS" Then
        'ProgramacionObligaciones("P")
        'ElseIf ComboBox1.Text = "COBROS" Then
        '    Programacion("C")
        'ElseIf ComboBox1.Text = "PAGOS ASIENTO" Then

        ProgramacionOtrasObligaciones("PA")
        'End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv29_Click(sender As Object, e As EventArgs) Handles ButtonAdv29.Click
        With frmHistorialCronograma

            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
    End Sub

    Private Sub dgvOtraObligaciones_SelectedRecordsChanging(sender As Object, e As SelectedRecordsChangedEventArgs) Handles dgvOtraObligaciones.SelectedRecordsChanging
        Me.Cursor = Cursors.WaitCursor
        'GridGroupingControl2.Table.Records.DeleteAll()
        If Not IsNothing(dgvOtraObligaciones.Table.CurrentRecord) Then
            'UbicarDocumentoDetalle(dgvProcesoCrono.Table.CurrentRecord.GetValue("id"), "PR")
            If dgvOtraObligaciones.Table.CurrentRecord.GetValue("tipo") = "Pago" Then

                'UbicarDocumentoDetalleObligaciones(dgvObligaciones.Table.CurrentRecord.GetValue("fecha"))
            ElseIf dgvOtraObligaciones.Table.CurrentRecord.GetValue("tipo") = "Cobro" Then

                'UbicarDocumentoDetalleCobro(dgvProcesoCrono.Table.CurrentRecord.GetValue("fecha"))

            ElseIf dgvOtraObligaciones.Table.CurrentRecord.GetValue("tipo") = "Pago Asiento" Then
                'UbicarDocumentoDetalleObligaciones(dgvObligaciones.Table.CurrentRecord.GetValue("fecha"))
                UbicarDocumentoDetalleOtrasObligaciones(dgvOtraObligaciones.Table.CurrentRecord.GetValue("fecha"))
            End If

        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvOtraObligaciones_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvOtraObligaciones.TableControlCellClick

    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        OtrasAcreencias()
    End Sub

    Private Sub ButtonAdv55_Click(sender As Object, e As EventArgs) Handles ButtonAdv55.Click

    End Sub
End Class