Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Tools
Public Class frmEstadoSituacionFinanciera
#Region "Attributes"

#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        años()
        ' Add any initialization after the InitializeComponent() call.
        'GridCFG(dgvUsuarioActivo)

    End Sub
#End Region

#Region "Methods"

    Public Sub años()
        Dim AniosSA As New empresaPeriodoSA
        cboAnios.DisplayMember = "periodo"
        cboAnios.ValueMember = "periodo"
        cboAnios.DataSource = AniosSA.GetListar_empresaPeriodo(New empresaPeriodo With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento})
        cboAnios.Text = AnioGeneral

        cboMes.SelectedIndex = DateTime.Now.Month - 1

    End Sub


    Private Sub EstadoGeneralMensual(anioPeriodo As String, mesPeriodo As String)
        Dim movimiento As New List(Of movimiento)
        Dim PagoComercial As New movimiento
        Dim PagoComercialRel As New movimiento
        Dim PagoLetrasCobro As New movimiento
        Dim movimientoSA As New MovimientoSA
        Dim CobroComercial As New movimiento
        Dim CuentaAnticipo As New movimiento
        Dim CuentaRendir As New movimiento
        Dim CierreResultadoSA As New cierreResultadosSA
        Dim CierreResultado As New List(Of cierreResultados)


        'COBROS
        lblCuenta10.Text = "0.00"
        lblCuenta11.Text = "0.00"
        lblCuentaXCobrar.Text = "0.00"
        lblCobroCuenta13.Text = "0.00"
        lblLetrasCobrar.Text = "0.00"
        lblCobro14.Text = "0.00"
        lblCobro16.Text = "0.00"
        lblCobro17.Text = "0.00"
        lblcuenta18.Text = "0.00"
        lblcuenta19.Text = "0.00"
        lblCobro422.Text = "0.00"
        lblCobro432.Text = "0.00"
        lblcuentarendir.Text = "0.00"
        lblInventariosCobro.Text = "0.00"
        lblCuenta29.Text = "0.00"
        lblActivoInmovilizadoCobro.Text = "0.00"
        lblCuenta36.Text = "0.00"
        lblCuenta39.Text = "0.00"
        lblcobro40111.Text = "0.00"
        lblCobro40.Text = "0.00"
        'PAGOS
        lblRemuneraciones.Text = "0.00"

        lblComprasPeriodo.Text = "0.00"
        lblPagoCuenta43.Text = "0.00"
        lblLetraPago.Text = "0.00"

        lblPago44.Text = "0.00"
        lblPago45.Text = "0.00"
        lblPago46.Text = "0.00"
        lblPago47.Text = "0.00"

        lblPago122.Text = "0.00"
        lblPago132.Text = "0.00"

        lblcuenta48.Text = "0.00"
        lblcuenta49.Text = "0.00"

        lblpago40111.Text = "0.00"
        lblPago40.Text = "0.00"

        lblCuenta50.Text = "0.00"
        lblCuenta51.Text = "0.00"
        lblCuenta52.Text = "0.00"
        lblCuenta56.Text = "0.00"
        lblCuenta57.Text = "0.00"
        lblCuenta58.Text = "0.00"
        lblCuenta59.Text = "0.00"
        blResultado.Text = "0.00"



        movimiento = movimientoSA.BalanceGeneralMensual(anioPeriodo, mesPeriodo, Gempresas.IdEmpresaRuc)
        PagoComercial = movimientoSA.CuentaPagoComercialMensual(anioPeriodo, mesPeriodo, Gempresas.IdEmpresaRuc)
        PagoComercialRel = movimientoSA.CuentaPagoComercialRelMensual(anioPeriodo, mesPeriodo, Gempresas.IdEmpresaRuc)
        PagoLetrasCobro = movimientoSA.CuentaPagoLetrasMensual(anioPeriodo, mesPeriodo, Gempresas.IdEmpresaRuc)
        CobroComercial = movimientoSA.CuentaCobroComercialMensual(anioPeriodo, mesPeriodo, Gempresas.IdEmpresaRuc)
        CuentaAnticipo = movimientoSA.CuentaAnticiposMensual(anioPeriodo, mesPeriodo, Gempresas.IdEmpresaRuc)
        CuentaRendir = movimientoSA.CuentaEntregaRendirMensual(anioPeriodo, mesPeriodo, Gempresas.IdEmpresaRuc)

        'Dim MesNuevo = String.Format("{0:00}", mesPeriodo)
        CierreResultado = CierreResultadoSA.GetUbicaCierreResultado(Gempresas.IdEmpresaRuc, anioPeriodo, mesPeriodo)

        Dim FechaAnt As DateTime
        Dim FechaAct As DateTime
        FechaAnt = Format(Now, anioPeriodo & "-" & mesPeriodo & "-01")
        FechaAnt = FechaAnt.AddMonths(-1)
        FechaAct = Format(Now, anioPeriodo & "-" & mesPeriodo & "-01")

        Dim periodo_Anterior = String.Format("{0:00}", FechaAnt.Month) & FechaAnt.Year
        Dim periodo_Actual = String.Format("{0:00}", FechaAct.Month) & FechaAct.Year



        If CierreResultado.Count > 0 Then

            For Each i In CierreResultado
                If i.periodo = periodo_Anterior Then
                    lblCuenta59.Text = i.utilidadPerdida
                ElseIf i.periodo = periodo_Actual Then
                    blResultado.Text = i.utilidadPerdida
                End If
            Next

        End If

        'If Not IsNothing(CierreResultado) Then
        '    blResultado.Text = CierreResultado.utilidadPerdida
        'End If


        'cuenta42 excepto 422 y 423    y cuenta 40111 DEBE HABER

        lblComprasPeriodo.Text = (PagoComercial.debeSaldoS - PagoComercial.haberSaldoS) * -1
        'cobro cuenta 16 menos 1681
        lblCobro16.Text = PagoComercial.debe16 - PagoComercial.haber16


        lblPagoCuenta43.Text = (PagoComercialRel.debeSaldoS - PagoComercialRel.haberSaldoS) * -1

        'igv cuenta 40111
        If PagoComercialRel.debe40111 - PagoComercialRel.haber40111 < 0 Then
            lblpago40111.Text = (PagoComercialRel.debe40111 - PagoComercialRel.haber40111) * -1

        ElseIf PagoComercialRel.debe40111 - PagoComercialRel.haber40111 > 0 Then

            lblcobro40111.Text = PagoComercialRel.debe40111 - PagoComercialRel.haber40111
        End If
        'tributos cuenta 40 menos la 40111 debe o haber
        If PagoComercialRel.debe40 - PagoComercialRel.haber40 < 0 Then
            lblPago40.Text = (PagoComercialRel.debe40 - PagoComercialRel.haber40) * -1
        ElseIf PagoComercialRel.debe40 - PagoComercialRel.haber40 > 0 Then
            lblCobro40.Text = PagoComercialRel.debe40 - PagoComercialRel.haber40
        End If


        '/////////////////////////////////////////////////////////////////////////////////
        'cuenta 423 y 433

        lblLetraPago.Text = (PagoLetrasCobro.debeSaldoS - PagoLetrasCobro.haberSaldoS) * -1

        'cuenta cobro 123 y 133
        lblLetrasCobrar.Text = PagoLetrasCobro.debeLetra - PagoLetrasCobro.haberLetra


        '//////////////////////////////////////////////////////////////////////////
        'cobro cuenta 12 menos 122
        lblCuentaXCobrar.Text = CobroComercial.debeSaldoS - CobroComercial.haberSaldoS
        'cobro cuenta 13 menos 132 y 133
        lblCobroCuenta13.Text = CobroComercial.debe13 - CobroComercial.haber13

        'cobro cuenta 422
        lblCobro422.Text = CuentaAnticipo.debeSaldoS - CuentaAnticipo.haberSaldoS
        'cobro cuenta 432
        lblCobro432.Text = CuentaAnticipo.debe432 - CuentaAnticipo.haber432
        'pago cuenta 122 
        lblPago122.Text = (CuentaAnticipo.debe122 - CuentaAnticipo.haber122) * -1
        'pago cuenta 132

        lblPago132.Text = (CuentaAnticipo.debe132 - CuentaAnticipo.haber132) * -1

        'cobro cuenta 1413 1433 1443 1681
        lblcuentarendir.Text = CuentaRendir.debeSaldoS - CuentaRendir.haberSaldoS
        'cobro cuenta 14 menos 1413 1433 1443 1681
        lblCobro14.Text = CuentaRendir.debe14 - CuentaRendir.haber14


        For Each i In movimiento
            Select Case i.cuenta

                Case "10"
                    'EFECTIVO Y EQUIVALENTES DE EFECTIVO
                    lblCuenta10.Text = i.debeSaldoS - i.haberSaldoS

                Case "11"
                    'INVERSIONES FINANCIERAS 
                    lblCuenta11.Text = i.debeSaldoS - i.haberSaldoS

                Case "17"
                    'Ctas por cobrar diversas - Relacionadas
                    If i.debeSaldoS - i.haberSaldoS > 0 Then
                        lblCobro17.Text = i.debeSaldoS - i.haberSaldoS
                    End If

                Case "18"
                    'Servicios y otros contratados por anticipado 
                    lblcuenta18.Text = i.debeSaldoS - i.haberSaldoS

                Case "19"
                    'COBRANZA DUDOSA  (mostrar en negativo)
                    If i.debeSaldoS - i.haberSaldoS > 0 Then
                        lblcuenta19.Text = (i.debeSaldoS - i.haberSaldoS) * -1
                    End If

                Case "29"

                    lblCuenta29.Text = i.debeSaldoS - i.haberSaldoS

                Case "36"

                    lblCuenta36.Text = i.debeSaldoS - i.haberSaldoS

                Case "39"

                    lblCuenta39.Text = i.debeSaldoS - i.haberSaldoS

                Case "41"

                    lblRemuneraciones.Text = (i.debeSaldoS - i.haberSaldoS)

                Case "44"

                    lblPago44.Text = (i.haberSaldoS - i.debeSaldoS)
                Case "45"

                    lblPago45.Text = (i.haberSaldoS - i.debeSaldoS)
                Case "46"

                    lblPago46.Text = (i.haberSaldoS - i.debeSaldoS)
                Case "47"

                    lblPago47.Text = (i.haberSaldoS - i.debeSaldoS)

                Case "48"
                    lblcuenta48.Text = (i.haberSaldoS - i.debeSaldoS)
                Case "49"
                    lblcuenta49.Text = (i.haberSaldoS - i.debeSaldoS)

                Case "50"
                    'CAPITAL
                    lblCuenta50.Text = (i.haberSaldoS - i.debeSaldoS)
                Case "51"
                    'ACCIONES DE INVERSION
                    lblCuenta51.Text = (i.haberSaldoS - i.debeSaldoS)
                Case "52"
                    'CAPITAL ADICIONAL 
                    lblCuenta52.Text = (i.haberSaldoS - i.debeSaldoS)
                Case "56"
                    'RESULTADOS NO REALIZADOS 
                    lblCuenta56.Text = (i.haberSaldoS - i.debeSaldoS)
                Case "57"
                    'EXCEDENTE DE REVALUACION 
                    lblCuenta57.Text = (i.haberSaldoS - i.debeSaldoS)
                Case "58"
                    'RESERVAS 
                    lblCuenta58.Text = (i.haberSaldoS - i.debeSaldoS)
                Case "59"
                    'RESULTADOS ACUMULADOS 
                    lblCuenta59.Text = (i.haberSaldoS - i.debeSaldoS)

                Case "20", "21", "22", "23", "24", "25", "26", "27", "28"
                    lblInventariosCobro.Text += (i.debeSaldoS - i.haberSaldoS)

                Case "30", "31", "32", "33", "34", "35", "37", "38"
                    lblActivoInmovilizadoCobro.Text += (i.debeSaldoS - i.haberSaldoS)
            End Select

        Next

        SUMATORIA()


    End Sub



    Private Sub EstadoGeneral()
        Dim movimiento As New List(Of movimiento)
        Dim PagoComercial As New movimiento
        Dim PagoComercialRel As New movimiento
        Dim PagoLetrasCobro As New movimiento
        Dim movimientoSA As New MovimientoSA
        Dim CobroComercial As New movimiento
        Dim CuentaAnticipo As New movimiento
        Dim CuentaRendir As New movimiento
        'COBROS
        lblCuenta10.Text = "0.00"
        lblCuenta11.Text = "0.00"
        lblCuentaXCobrar.Text = "0.00"
        lblCobroCuenta13.Text = "0.00"
        lblLetrasCobrar.Text = "0.00"
        lblCobro14.Text = "0.00"
        lblCobro16.Text = "0.00"
        lblCobro17.Text = "0.00"
        lblcuenta18.Text = "0.00"
        lblcuenta19.Text = "0.00"
        lblCobro422.Text = "0.00"
        lblCobro432.Text = "0.00"
        lblcuentarendir.Text = "0.00"
        lblInventariosCobro.Text = "0.00"
        lblCuenta29.Text = "0.00"
        lblActivoInmovilizadoCobro.Text = "0.00"
        lblCuenta36.Text = "0.00"
        lblCuenta39.Text = "0.00"
        lblcobro40111.Text = "0.00"
        lblCobro40.Text = "0.00"
        'PAGOS
        lblRemuneraciones.Text = "0.00"

        lblComprasPeriodo.Text = "0.00"
        lblPagoCuenta43.Text = "0.00"
        lblLetraPago.Text = "0.00"

        lblPago44.Text = "0.00"
        lblPago45.Text = "0.00"
        lblPago46.Text = "0.00"
        lblPago47.Text = "0.00"

        lblPago122.Text = "0.00"
        lblPago132.Text = "0.00"

        lblcuenta48.Text = "0.00"
        lblcuenta49.Text = "0.00"

        lblpago40111.Text = "0.00"
        lblPago40.Text = "0.00"

        lblCuenta50.Text = "0.00"
        lblCuenta51.Text = "0.00"
        lblCuenta52.Text = "0.00"
        lblCuenta56.Text = "0.00"
        lblCuenta57.Text = "0.00"
        lblCuenta58.Text = "0.00"
        lblCuenta59.Text = "0.00"




        movimiento = movimientoSA.BalanceGeneralAnual(New asiento With {.fechaProceso = New DateTime(AnioGeneral, MesGeneral, DateTime.Now.Date.Day)})
        PagoComercial = movimientoSA.CuentaPagoComercial(New asiento With {.fechaProceso = New DateTime(AnioGeneral, MesGeneral, DateTime.Now.Date.Day)})
        PagoComercialRel = movimientoSA.CuentaPagoComercialRel(New asiento With {.fechaProceso = New DateTime(AnioGeneral, MesGeneral, DateTime.Now.Date.Day)})
        PagoLetrasCobro = movimientoSA.CuentaPagoLetras(New asiento With {.fechaProceso = New DateTime(AnioGeneral, MesGeneral, DateTime.Now.Date.Day)})
        CobroComercial = movimientoSA.CuentaCobroComercial(New asiento With {.fechaProceso = New DateTime(AnioGeneral, MesGeneral, DateTime.Now.Date.Day)})
        CuentaAnticipo = movimientoSA.CuentaAnticipos(New asiento With {.fechaProceso = New DateTime(AnioGeneral, MesGeneral, DateTime.Now.Date.Day)})
        CuentaRendir = movimientoSA.CuentaEntregaRendir(New asiento With {.fechaProceso = New DateTime(AnioGeneral, MesGeneral, DateTime.Now.Date.Day)})

        'cuenta42 excepto 422 y 423    y cuenta 40111 DEBE HABER

        lblComprasPeriodo.Text = (PagoComercial.debeSaldoS - PagoComercial.haberSaldoS) * -1
        'cobro cuenta 16 menos 1681
        lblCobro16.Text = PagoComercial.debe16 - PagoComercial.haber16


        lblPagoCuenta43.Text = (PagoComercialRel.debeSaldoS - PagoComercialRel.haberSaldoS) * -1

        'igv cuenta 40111
        If PagoComercialRel.debe40111 - PagoComercialRel.haber40111 < 0 Then
            lblpago40111.Text = (PagoComercialRel.debe40111 - PagoComercialRel.haber40111) * -1

        ElseIf PagoComercialRel.debe40111 - PagoComercialRel.haber40111 > 0 Then

            lblcobro40111.Text = PagoComercialRel.debe40111 - PagoComercialRel.haber40111
        End If
        'tributos cuenta 40 menos la 40111 debe o haber
        If PagoComercialRel.debe40 - PagoComercialRel.haber40 < 0 Then
            lblPago40.Text = (PagoComercialRel.debe40 - PagoComercialRel.haber40) * -1
        ElseIf PagoComercialRel.debe40 - PagoComercialRel.haber40 > 0 Then
            lblCobro40.Text = PagoComercialRel.debe40 - PagoComercialRel.haber40
        End If


        '/////////////////////////////////////////////////////////////////////////////////
        'cuenta 423 y 433

        lblLetraPago.Text = (PagoLetrasCobro.debeSaldoS - PagoLetrasCobro.haberSaldoS) * -1

        'cuenta cobro 123 y 133
        lblLetrasCobrar.Text = PagoLetrasCobro.debeLetra - PagoLetrasCobro.haberLetra


        '//////////////////////////////////////////////////////////////////////////
        'cobro cuenta 12 menos 122
        lblCuentaXCobrar.Text = CobroComercial.debeSaldoS - CobroComercial.haberSaldoS
        'cobro cuenta 13 menos 132 y 133
        lblCobroCuenta13.Text = CobroComercial.debe13 - CobroComercial.haber13

        'cobro cuenta 422
        lblCobro422.Text = CuentaAnticipo.debeSaldoS - CuentaAnticipo.haberSaldoS
        'cobro cuenta 432
        lblCobro432.Text = CuentaAnticipo.debe432 - CuentaAnticipo.haber432
        'pago cuenta 122 
        lblPago122.Text = (CuentaAnticipo.debe122 - CuentaAnticipo.haber122) * -1
        'pago cuenta 132

        lblPago132.Text = (CuentaAnticipo.debe132 - CuentaAnticipo.haber132) * -1

        'cobro cuenta 1413 1433 1443 1681
        lblcuentarendir.Text = CuentaRendir.debeSaldoS - CuentaRendir.haberSaldoS
        'cobro cuenta 14 menos 1413 1433 1443 1681
        lblCobro14.Text = CuentaRendir.debe14 - CuentaRendir.haber14


        For Each i In movimiento
            Select Case i.cuenta

                Case "10"
                    'EFECTIVO Y EQUIVALENTES DE EFECTIVO
                    lblCuenta10.Text = i.debeSaldoS - i.haberSaldoS

                Case "11"
                    'INVERSIONES FINANCIERAS 
                    lblCuenta11.Text = i.debeSaldoS - i.haberSaldoS

                Case "17"
                    'Ctas por cobrar diversas - Relacionadas
                    If i.debeSaldoS - i.haberSaldoS > 0 Then
                        lblCobro17.Text = i.debeSaldoS - i.haberSaldoS
                    End If

                Case "18"
                    'Servicios y otros contratados por anticipado 
                    lblcuenta18.Text = i.debeSaldoS - i.haberSaldoS

                Case "19"
                    'COBRANZA DUDOSA  (mostrar en negativo)
                    If i.debeSaldoS - i.haberSaldoS > 0 Then
                        lblcuenta19.Text = (i.debeSaldoS - i.haberSaldoS) * -1
                    End If

                Case "29"

                    lblCuenta29.Text = i.debeSaldoS - i.haberSaldoS

                Case "36"

                    lblCuenta36.Text = i.debeSaldoS - i.haberSaldoS

                Case "39"

                    lblCuenta39.Text = i.debeSaldoS - i.haberSaldoS

                Case "41"

                    lblRemuneraciones.Text = (i.debeSaldoS - i.haberSaldoS)

                Case "44"

                    lblPago44.Text = (i.haberSaldoS - i.debeSaldoS)
                Case "45"

                    lblPago45.Text = (i.haberSaldoS - i.debeSaldoS)
                Case "46"

                    lblPago46.Text = (i.haberSaldoS - i.debeSaldoS)
                Case "47"

                    lblPago47.Text = (i.haberSaldoS - i.debeSaldoS)

                Case "48"
                    lblcuenta48.Text = (i.haberSaldoS - i.debeSaldoS)
                Case "49"
                    lblcuenta49.Text = (i.haberSaldoS - i.debeSaldoS)

                Case "50"
                    'CAPITAL
                    lblCuenta50.Text = (i.haberSaldoS - i.debeSaldoS)
                Case "51"
                    'ACCIONES DE INVERSION
                    lblCuenta51.Text = (i.haberSaldoS - i.debeSaldoS)
                Case "52"
                    'CAPITAL ADICIONAL 
                    lblCuenta52.Text = (i.haberSaldoS - i.debeSaldoS)
                Case "56"
                    'RESULTADOS NO REALIZADOS 
                    lblCuenta56.Text = (i.haberSaldoS - i.debeSaldoS)
                Case "57"
                    'EXCEDENTE DE REVALUACION 
                    lblCuenta57.Text = (i.haberSaldoS - i.debeSaldoS)
                Case "58"
                    'RESERVAS 
                    lblCuenta58.Text = (i.haberSaldoS - i.debeSaldoS)
                Case "59"
                    'RESULTADOS ACUMULADOS 
                    lblCuenta59.Text = (i.haberSaldoS - i.debeSaldoS)

                Case "20", "21", "22", "23", "24", "25", "26", "27", "28"
                    lblInventariosCobro.Text += (i.debeSaldoS - i.haberSaldoS)

                Case "30", "31", "32", "33", "34", "35", "37", "38"
                    lblActivoInmovilizadoCobro.Text += (i.debeSaldoS - i.haberSaldoS)
            End Select

        Next

        SUMATORIA()


    End Sub

    Public Sub SUMATORIA()
        'suma cobros

        'Dim suma = 0
        'suma += Convert.ToDecimal(lblCuenta10.Text) + Convert.ToDecimal(lblCuenta11.Text) + Convert.ToDecimal(lblCuentaXCobrar.Text) + Convert.ToDecimal(lblCobroCuenta13.Text)
        'suma += Convert.ToDecimal(lblLetrasCobrar.Text) + Convert.ToDecimal(lblCobro14.Text) + Convert.ToDecimal(lblCobro16.Text) + Convert.ToDecimal(lblCobro17.Text) + Convert.ToDecimal(lblcuenta18.Text)
        'suma += Convert.ToDecimal(lblcuenta19.Text) + Convert.ToDecimal(lblCobro422.Text) + Convert.ToDecimal(lblCobro432.Text) + Convert.ToDecimal(lblcuentarendir.Text) + Convert.ToDecimal(lblInventariosCobro.Text)
        'suma += Convert.ToDecimal(lblCuenta29.Text) + Convert.ToDecimal(lblActivoInmovilizadoCobro.Text) + Convert.ToDecimal(lblCuenta36.Text) + Convert.ToDecimal(lblCuenta39.Text) + Convert.ToDecimal(lblcobro40111.Text) + Convert.ToDecimal(lblCobro40.Text)

        lbltotalcobro.Text = (Convert.ToDecimal(lblCuenta10.Text) + Convert.ToDecimal(lblCuenta11.Text) + Convert.ToDecimal(lblCuentaXCobrar.Text) + Convert.ToDecimal(lblCobroCuenta13.Text) +
                                Convert.ToDecimal(lblLetrasCobrar.Text) + Convert.ToDecimal(lblCobro14.Text) + Convert.ToDecimal(lblCobro16.Text) + Convert.ToDecimal(lblCobro17.Text) + Convert.ToDecimal(lblcuenta18.Text) +
                               Convert.ToDecimal(lblcuenta19.Text) + Convert.ToDecimal(lblCobro422.Text) + Convert.ToDecimal(lblCobro432.Text) + Convert.ToDecimal(lblcuentarendir.Text) + Convert.ToDecimal(lblInventariosCobro.Text) +
                               Convert.ToDecimal(lblCuenta29.Text) + Convert.ToDecimal(lblActivoInmovilizadoCobro.Text) + Convert.ToDecimal(lblCuenta36.Text) + Convert.ToDecimal(lblCuenta39.Text) + Convert.ToDecimal(lblcobro40111.Text) +
                              Convert.ToDecimal(lblCobro40.Text))

        'sumapago 
        lblsubtotal.Text = (Convert.ToDecimal(lblRemuneraciones.Text) + Convert.ToDecimal(lblComprasPeriodo.Text) + Convert.ToDecimal(lblPagoCuenta43.Text) + Convert.ToDecimal(lblLetraPago.Text) +
                             Convert.ToDecimal(lblPago44.Text) + Convert.ToDecimal(lblPago45.Text) + Convert.ToDecimal(lblPago46.Text) + Convert.ToDecimal(lblPago47.Text) + Convert.ToDecimal(lblPago122.Text) +
                           Convert.ToDecimal(lblPago132.Text) + Convert.ToDecimal(lblcuenta48.Text) + Convert.ToDecimal(lblcuenta49.Text) + Convert.ToDecimal(lblpago40111.Text) +
                           Convert.ToDecimal(lblPago40.Text))
        lblsubtotal2.Text = (Convert.ToDecimal(lblCuenta50.Text) + Convert.ToDecimal(lblCuenta51.Text) + Convert.ToDecimal(lblCuenta52.Text) +
                             Convert.ToDecimal(lblCuenta56.Text) + Convert.ToDecimal(lblCuenta57.Text) + Convert.ToDecimal(lblCuenta58.Text) + Convert.ToDecimal(lblCuenta59.Text) + Convert.ToDecimal(blResultado.Text))

        lbltotalpago.Text = Convert.ToDecimal(lblsubtotal.Text) + Convert.ToDecimal(lblsubtotal2.Text)

    End Sub

#Region "TIMER"

#End Region
#End Region

#Region "Events"


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        EstadoGeneral()
    End Sub

    Private Sub LinkLabel8_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel8.LinkClicked
        Dim FechaAnt As DateTime
        FechaAnt = Format(Now, cboAnios.Text & "-" & txtNumeroMes.Text & "-01")

        FechaAnt = FechaAnt.AddMonths(1)
        FechaAnt = FechaAnt.AddDays(-1)
        Dim f As New frmEstadoCuentaActivo
        f.LblTipoCuenta.Text = "11"
        f.txtFechaFin.Value = FechaAnt
        f.LblCabezera.Text = "INVERSIONES FINANCIERAS  11"
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel30_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel30.LinkClicked
        Dim FechaAnt As DateTime
        FechaAnt = Format(Now, cboAnios.Text & "-" & txtNumeroMes.Text & "-01")

        FechaAnt = FechaAnt.AddMonths(1)
        FechaAnt = FechaAnt.AddDays(-1)
        Dim f As New frmEstadoCuentaActivo
        f.LblTipoCuenta.Text = "12"
        f.txtFechaFin.Value = FechaAnt
        f.LblCabezera.Text = "CUENTAS POR COBRAR COMERCIALES -TERCEROS  (excepto:  122 - 123) "
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel9_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel9.LinkClicked
        Dim FechaAnt As DateTime
        FechaAnt = Format(Now, cboAnios.Text & "-" & txtNumeroMes.Text & "-01")

        FechaAnt = FechaAnt.AddMonths(1)
        FechaAnt = FechaAnt.AddDays(-1)
        Dim f As New frmEstadoCuentaActivo
        f.LblTipoCuenta.Text = "13"
        f.txtFechaFin.Value = FechaAnt
        f.LblCabezera.Text = "CUENTAS POR COBRAR COMERCIALES -RELACIONADAS  (excepto: 132 - 133)"
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel10_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel10.LinkClicked
        Dim FechaAnt As DateTime
        FechaAnt = Format(Now, cboAnios.Text & "-" & txtNumeroMes.Text & "-01")

        FechaAnt = FechaAnt.AddMonths(1)
        FechaAnt = FechaAnt.AddDays(-1)
        Dim f As New frmEstadoCuentaActivo
        f.LblTipoCuenta.Text = "123133"
        f.txtFechaFin.Value = FechaAnt
        f.LblCabezera.Text = "LETRAS POR COBRAR"
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel11_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel11.LinkClicked
        Dim FechaAnt As DateTime
        FechaAnt = Format(Now, cboAnios.Text & "-" & txtNumeroMes.Text & "-01")

        FechaAnt = FechaAnt.AddMonths(1)
        FechaAnt = FechaAnt.AddDays(-1)
        Dim f As New frmEstadoCuentaActivo
        f.LblTipoCuenta.Text = "14"
        f.txtFechaFin.Value = FechaAnt
        f.LblCabezera.Text = "CTAS. POR COBRAR PERSON. ACC. (SOCIOS) DIRECT Y GERENT EXCEPTO  1413-1433-1443"
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel13_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel13.LinkClicked
        Dim FechaAnt As DateTime
        FechaAnt = Format(Now, cboAnios.Text & "-" & txtNumeroMes.Text & "-01")

        FechaAnt = FechaAnt.AddMonths(1)
        FechaAnt = FechaAnt.AddDays(-1)
        Dim f As New frmEstadoCuentaActivo
        f.LblTipoCuenta.Text = "16"
        f.txtFechaFin.Value = FechaAnt
        f.LblCabezera.Text = "CTAS POR COBRAR DIVERSAS - TERCEROS 16"
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel14_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel14.LinkClicked
        Dim FechaAnt As DateTime
        FechaAnt = Format(Now, cboAnios.Text & "-" & txtNumeroMes.Text & "-01")

        FechaAnt = FechaAnt.AddMonths(1)
        FechaAnt = FechaAnt.AddDays(-1)
        Dim f As New frmEstadoCuentaActivo
        f.LblTipoCuenta.Text = "17"
        f.txtFechaFin.Value = FechaAnt
        f.LblCabezera.Text = "CTAS POR COBRAR DIVERSAS - RELACIONADAS 17"
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel12_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel12.LinkClicked
        Dim FechaAnt As DateTime
        FechaAnt = Format(Now, cboAnios.Text & "-" & txtNumeroMes.Text & "-01")

        FechaAnt = FechaAnt.AddMonths(1)
        FechaAnt = FechaAnt.AddDays(-1)
        Dim f As New frmEstadoCuentaActivo
        f.LblTipoCuenta.Text = "19"
        f.txtFechaFin.Value = FechaAnt
        f.LblCabezera.Text = "19 COBRANZA DUDOSA"
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel31_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel31.LinkClicked
        Dim FechaAnt As DateTime
        FechaAnt = Format(Now, cboAnios.Text & "-" & txtNumeroMes.Text & "-01")

        FechaAnt = FechaAnt.AddMonths(1)
        FechaAnt = FechaAnt.AddDays(-1)
        Dim f As New frmEstadoCuentaActivo
        f.LblTipoCuenta.Text = "18"
        f.txtFechaFin.Value = FechaAnt
        f.LblCabezera.Text = "18 SERVICIOS Y OTROS CONTRATADOS POR ANTICIPOS"
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel32_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel32.LinkClicked
        Dim FechaAnt As DateTime
        FechaAnt = Format(Now, cboAnios.Text & "-" & txtNumeroMes.Text & "-01")

        FechaAnt = FechaAnt.AddMonths(1)
        FechaAnt = FechaAnt.AddDays(-1)
        Dim f As New frmEstadoCuentaActivo
        f.LblTipoCuenta.Text = "422"

        f.txtFechaFin.Value = FechaAnt
        f.LblCabezera.Text = "ANTICIPOS A PROVEEDORES 422"
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel33_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel33.LinkClicked
        Dim FechaAnt As DateTime
        FechaAnt = Format(Now, cboAnios.Text & "-" & txtNumeroMes.Text & "-01")

        FechaAnt = FechaAnt.AddMonths(1)
        FechaAnt = FechaAnt.AddDays(-1)
        Dim f As New frmEstadoCuentaActivo
        f.LblTipoCuenta.Text = "432"
        f.txtFechaFin.Value = FechaAnt
        f.LblCabezera.Text = "CTAS ANTICIPOS OTORGADOS A RELACIONADAS 432"
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel34_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel34.LinkClicked
        Dim FechaAnt As DateTime
        FechaAnt = Format(Now, cboAnios.Text & "-" & txtNumeroMes.Text & "-01")

        FechaAnt = FechaAnt.AddMonths(1)
        FechaAnt = FechaAnt.AddDays(-1)
        Dim f As New frmEstadoCuentaActivo
        f.LblTipoCuenta.Text = "1413-1433-1443-1681"
        f.txtFechaFin.Value = FechaAnt
        f.LblCabezera.Text = "ENTREGAS A RENDIR"
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel35_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel35.LinkClicked
        Dim FechaAnt As DateTime
        FechaAnt = Format(Now, cboAnios.Text & "-" & txtNumeroMes.Text & "-01")

        FechaAnt = FechaAnt.AddMonths(1)
        FechaAnt = FechaAnt.AddDays(-1)
        Dim f As New frmEstadoCuentaActivo
        f.LblTipoCuenta.Text = "20-21-22-23-24-25-26-27-28"
        f.txtFechaFin.Value = FechaAnt
        f.LblCabezera.Text = "INVENTARIOS 20-21-22-23-24-25-26-27-28"
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel36_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel36.LinkClicked
        Dim FechaAnt As DateTime
        FechaAnt = Format(Now, cboAnios.Text & "-" & txtNumeroMes.Text & "-01")

        FechaAnt = FechaAnt.AddMonths(1)
        FechaAnt = FechaAnt.AddDays(-1)
        Dim f As New frmEstadoCuentaActivo
        f.LblTipoCuenta.Text = "29"

        f.txtFechaFin.Value = FechaAnt
        f.LblCabezera.Text = "DESVALORIZACION DE INVETARIOS 29"
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel37_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel37.LinkClicked
        Dim FechaAnt As DateTime
        FechaAnt = Format(Now, cboAnios.Text & "-" & txtNumeroMes.Text & "-01")

        FechaAnt = FechaAnt.AddMonths(1)
        FechaAnt = FechaAnt.AddDays(-1)
        Dim f As New frmEstadoCuentaActivo
        f.LblTipoCuenta.Text = "30-31-32-33-34-35-37-38"
        f.txtFechaFin.Value = FechaAnt
        f.LblCabezera.Text = "ACTIVO INMOVILIZADO 30-31-32-33-34-35-37-38"
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel38_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel38.LinkClicked
        Dim FechaAnt As DateTime
        FechaAnt = Format(Now, cboAnios.Text & "-" & txtNumeroMes.Text & "-01")

        FechaAnt = FechaAnt.AddMonths(1)
        FechaAnt = FechaAnt.AddDays(-1)

        Dim f As New frmEstadoCuentaActivo
        f.LblTipoCuenta.Text = "36"
        f.txtFechaFin.Value = FechaAnt
        f.LblCabezera.Text = "DESVALORIZACION DE ACTIVO INMOVILIZADO 36"
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel39_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel39.LinkClicked
        Dim FechaAnt As DateTime
        FechaAnt = Format(Now, cboAnios.Text & "-" & txtNumeroMes.Text & "-01")

        FechaAnt = FechaAnt.AddMonths(1)
        FechaAnt = FechaAnt.AddDays(-1)
        Dim f As New frmEstadoCuentaActivo
        f.LblTipoCuenta.Text = "39"

        f.txtFechaFin.Value = FechaAnt
        f.LblCabezera.Text = "DEPRECIACION, AMORTIZACION Y AGOTAMIENTOS ACUMULADOS 39"
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

        Dim FechaAnt As DateTime
        FechaAnt = Format(Now, cboAnios.Text & "-" & txtNumeroMes.Text & "-01")
        FechaAnt = FechaAnt.AddMonths(1)
        FechaAnt = FechaAnt.AddDays(-1)



        Dim f As New frmEstadoCuentaPasivo
        f.LblTipoCuenta.Text = "41"
        f.txtFechaFin.Value = FechaAnt
        f.LblCabezera.Text = "REMUNERACIONES Y PARTICIPACIONES POR PAGAR"
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked

        Dim FechaAnt As DateTime
        FechaAnt = Format(Now, cboAnios.Text & "-" & txtNumeroMes.Text & "-01")
        FechaAnt = FechaAnt.AddMonths(1)
        FechaAnt = FechaAnt.AddDays(-1)


        Dim f As New frmEstadoCuentaPasivo
        f.LblTipoCuenta.Text = "42"
        f.LblCabezera.Text = "CUENTAS POR PAGAR COMERCIALES - TERCEROS (excepto: 422 - 423)"
        f.txtFechaFin.Value = FechaAnt
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked

        Dim FechaAnt As DateTime
        FechaAnt = Format(Now, cboAnios.Text & "-" & txtNumeroMes.Text & "-01")

        FechaAnt = FechaAnt.AddMonths(1)
        FechaAnt = FechaAnt.AddDays(-1)

        Dim f As New frmEstadoCuentaPasivo
        f.LblTipoCuenta.Text = "43"
        f.txtFechaFin.Value = FechaAnt
        f.LblCabezera.Text = "CUENTAS POR PAGAR COMERCIALES - RELACIONADAS (excepto: 432 - 433)"
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked

        Dim FechaAnt As DateTime
        FechaAnt = Format(Now, cboAnios.Text & "-" & txtNumeroMes.Text & "-01")

        FechaAnt = FechaAnt.AddMonths(1)
        FechaAnt = FechaAnt.AddDays(-1)


        Dim f As New frmEstadoCuentaPasivo
        f.LblTipoCuenta.Text = "423433"
        f.txtFechaFin.Value = FechaAnt
        f.LblCabezera.Text = "LETRAS POR PAGAR"
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked

        Dim FechaAnt As DateTime
        FechaAnt = Format(Now, cboAnios.Text & "-" & txtNumeroMes.Text & "-01")

        FechaAnt = FechaAnt.AddMonths(1)

        FechaAnt = FechaAnt.AddDays(-1)

        Dim f As New frmEstadoCuentaPasivo
        f.LblTipoCuenta.Text = "44"
        f.txtFechaFin.Value = FechaAnt
        f.LblCabezera.Text = "CUENTAS POR PAGAR A LOS ACC (socios)Direct y Gerentes"
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel6_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel6.LinkClicked

        Dim FechaAnt As DateTime
        FechaAnt = Format(Now, cboAnios.Text & "-" & txtNumeroMes.Text & "-01")

        FechaAnt = FechaAnt.AddMonths(1)

        FechaAnt = FechaAnt.AddDays(-1)

        Dim f As New frmEstadoCuentaPasivo
        f.LblTipoCuenta.Text = "45"
        f.LblCabezera.Text = "OBLIGACIONES FINANCIERAS"
        f.StartPosition = FormStartPosition.CenterParent
        f.txtFechaFin.Value = FechaAnt
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel16_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel16.LinkClicked
        Dim FechaAnt As DateTime
        FechaAnt = Format(Now, cboAnios.Text & "-" & txtNumeroMes.Text & "-01")

        FechaAnt = FechaAnt.AddMonths(1)
        FechaAnt = FechaAnt.AddDays(-1)


        Dim f As New frmEstadoCuentaPasivo
        f.LblTipoCuenta.Text = "47"
        f.txtFechaFin.Value = FechaAnt
        f.LblCabezera.Text = "CUENTAS POR PAGAR DIVERSAS - RELACIONADAS"
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel15_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel15.LinkClicked

        Dim FechaAnt As DateTime
        FechaAnt = Format(Now, cboAnios.Text & "-" & txtNumeroMes.Text & "-01")

        FechaAnt = FechaAnt.AddMonths(1)

        FechaAnt = FechaAnt.AddDays(-1)

        Dim f As New frmEstadoCuentaPasivo
        f.LblTipoCuenta.Text = "46"
        f.txtFechaFin.Value = FechaAnt
        f.LblCabezera.Text = "CUENTAS POR PAGAR DIVERSAS - TERCEROS "
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel17_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel17.LinkClicked

        Dim FechaAnt As DateTime
        FechaAnt = Format(Now, cboAnios.Text & "-" & txtNumeroMes.Text & "-01")

        FechaAnt = FechaAnt.AddMonths(1)

        FechaAnt = FechaAnt.AddDays(-1)

        Dim f As New frmEstadoCuentaPasivo
        f.LblTipoCuenta.Text = "122"
        f.txtFechaFin.Value = FechaAnt
        f.LblCabezera.Text = "ANTICIPOS DE CLIENTES"
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel18_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel18.LinkClicked

        Dim FechaAnt As DateTime
        FechaAnt = Format(Now, cboAnios.Text & "-" & txtNumeroMes.Text & "-01")

        FechaAnt = FechaAnt.AddMonths(1)

        FechaAnt = FechaAnt.AddDays(-1)
        Dim f As New frmEstadoCuentaPasivo
        f.LblTipoCuenta.Text = "132"
        f.txtFechaFin.Value = FechaAnt
        f.LblCabezera.Text = "ANTICIPOS RECIBIDOS DE RELACIONADOS"
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel19_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel19.LinkClicked
        Dim FechaAnt As DateTime
        FechaAnt = Format(Now, cboAnios.Text & "-" & txtNumeroMes.Text & "-01")

        FechaAnt = FechaAnt.AddMonths(1)
        FechaAnt = FechaAnt.AddDays(-1)
        Dim f As New frmEstadoCuentaPasivo
        f.LblTipoCuenta.Text = "48"
        f.txtFechaFin.Value = FechaAnt
        f.LblCabezera.Text = "PROVISIONES"
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel20_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel20.LinkClicked

        Dim FechaAnt As DateTime
        FechaAnt = Format(Now, cboAnios.Text & "-" & txtNumeroMes.Text & "-01")

        FechaAnt = FechaAnt.AddMonths(1)
        FechaAnt = FechaAnt.AddDays(-1)
        Dim f As New frmEstadoCuentaPasivo
        f.LblTipoCuenta.Text = "49"
        f.txtFechaFin.Value = FechaAnt
        f.LblCabezera.Text = "PASIVO DIFERIDO"
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel21_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel21.LinkClicked
        Dim f As New frmEstadoCuentaPasivo
        f.LblTipoCuenta.Text = "50"
        f.LblCabezera.Text = "CAPITAL"
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel22_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel22.LinkClicked
        Dim f As New frmEstadoCuentaPasivo
        f.LblTipoCuenta.Text = "51"
        f.LblCabezera.Text = "ACCIONES DE INVERSIÓN"
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel23_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel23.LinkClicked
        Dim f As New frmEstadoCuentaPasivo
        f.LblTipoCuenta.Text = "52"
        f.LblCabezera.Text = "CAPITAL ADICIONAL "
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel24_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel24.LinkClicked
        Dim f As New frmEstadoCuentaPasivo
        f.LblTipoCuenta.Text = "56"
        f.LblCabezera.Text = "RESULTADOS NO REALIZADOS "
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel25_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel25.LinkClicked
        Dim f As New frmEstadoCuentaPasivo
        f.LblTipoCuenta.Text = "57"
        f.LblCabezera.Text = "EXCEDENTE DE REVALUACIÓN "
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel26_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel26.LinkClicked
        Dim f As New frmEstadoCuentaPasivo
        f.LblTipoCuenta.Text = "58"
        f.LblCabezera.Text = "RESERVAS "
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel27_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel27.LinkClicked
        Dim f As New frmEstadoCuentaPasivo
        f.LblTipoCuenta.Text = "59"
        f.LblCabezera.Text = "RESULTADOS ACUMULADOS "
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

#End Region

    Private Sub LinkLabel7_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel7.LinkClicked

        Dim FechaAnt As DateTime
        FechaAnt = Format(Now, cboAnios.Text & "-" & txtNumeroMes.Text & "-01")

        FechaAnt = FechaAnt.AddMonths(1)
        FechaAnt = FechaAnt.AddDays(-1)
        Dim f As New frmEstadoCuentaActivo
        f.LblTipoCuenta.Text = "10"
        f.txtFechaFin.Value = FechaAnt
        f.LblCabezera.Text = "EFECTIVO Y EQUIVALENTES DE EFECTIVO 10"
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub frmEstadoSituacionFinanciera_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        If cboAnios.Text.Trim.Length > 0 Then
            If cboMes.Text = "ENERO" Then
                EstadoGeneralMensual(cboAnios.Text, "1")
            ElseIf cboMes.Text = "FEBRERO" Then
                EstadoGeneralMensual(cboAnios.Text, "2")
            ElseIf cboMes.Text = "MARZO" Then
                EstadoGeneralMensual(cboAnios.Text, "3")
            ElseIf cboMes.Text = "ABRIL" Then
                EstadoGeneralMensual(cboAnios.Text, "4")
            ElseIf cboMes.Text = "MAYO" Then
                EstadoGeneralMensual(cboAnios.Text, "5")
            ElseIf cboMes.Text = "JUNIO" Then
                EstadoGeneralMensual(cboAnios.Text, "6")
            ElseIf cboMes.Text = "JULIO" Then
                EstadoGeneralMensual(cboAnios.Text, "7")
            ElseIf cboMes.Text = "AGOSTO" Then
                EstadoGeneralMensual(cboAnios.Text, "8")
            ElseIf cboMes.Text = "SETIEMBRE" Then
                EstadoGeneralMensual(cboAnios.Text, "9")
            ElseIf cboMes.Text = "OCTUBRE" Then
                EstadoGeneralMensual(cboAnios.Text, "10")
            ElseIf cboMes.Text = "NOVIEMBRE" Then
                EstadoGeneralMensual(cboAnios.Text, "11")
            ElseIf cboMes.Text = "DICIEMBRE" Then
                EstadoGeneralMensual(cboAnios.Text, "12")
            End If
        Else
            MessageBox.Show("eliga un año")
        End If
    End Sub

    Private Sub cboMes_Click(sender As Object, e As EventArgs) Handles cboMes.Click

    End Sub

    Private Sub cboMes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMes.SelectedIndexChanged

        If cboMes.Text = "ENERO" Then
            txtNumeroMes.Text = "1"
        ElseIf cboMes.Text = "FEBRERO" Then
            txtNumeroMes.Text = "2"
        ElseIf cboMes.Text = "MARZO" Then
            txtNumeroMes.Text = "3"
        ElseIf cboMes.Text = "ABRIL" Then
            txtNumeroMes.Text = "4"
        ElseIf cboMes.Text = "MAYO" Then
            txtNumeroMes.Text = "5"
        ElseIf cboMes.Text = "JUNIO" Then
            txtNumeroMes.Text = "6"
        ElseIf cboMes.Text = "JULIO" Then
            txtNumeroMes.Text = "7"
        ElseIf cboMes.Text = "AGOSTO" Then
            txtNumeroMes.Text = "8"
        ElseIf cboMes.Text = "SETIEMBRE" Then
            txtNumeroMes.Text = "9"
        ElseIf cboMes.Text = "OCTUBRE" Then
            txtNumeroMes.Text = "10"
        ElseIf cboMes.Text = "NOVIEMBRE" Then
            txtNumeroMes.Text = "11"
        ElseIf cboMes.Text = "DICIEMBRE" Then
            txtNumeroMes.Text = "12"
        End If

    End Sub

    Private Sub LinkLabel28_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel28.LinkClicked

    End Sub

    Private Sub LinkLabel40_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel40.LinkClicked

    End Sub

    Private Sub Panel65_Paint(sender As Object, e As PaintEventArgs) Handles Panel65.Paint

    End Sub

    Private Sub LinkLabel41_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel41.LinkClicked

    End Sub
End Class