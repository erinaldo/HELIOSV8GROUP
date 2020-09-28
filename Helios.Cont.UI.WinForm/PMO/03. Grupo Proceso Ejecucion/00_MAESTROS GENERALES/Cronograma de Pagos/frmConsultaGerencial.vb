Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Imports System.Collections
Imports System.Collections.Specialized
Imports Syncfusion.Windows.Forms.Tools

Public Class frmConsultaGerencial
    Inherits frmMaster

#Region "Metodos Resultado Funcion"


    Public Sub SUMATORIAResultado()
        'suma cobros
        lblcuenta70.Text = (Convert.ToDecimal(lblCuenta701.Text) + Convert.ToDecimal(lblCuenta702.Text) + Convert.ToDecimal(lblCuenta703.Text) + Convert.ToDecimal(lblCuenta704.Text) +
                                Convert.ToDecimal(lblCuenta709.Text))

        'sumapago 
        lbltotalbruto.Text = (Convert.ToDecimal(lblcuenta70.Text) + Convert.ToDecimal(lblcuenta73.Text) - Convert.ToDecimal(lblcuenta74.Text))

        lblcuenta69.Text = (Convert.ToDecimal(lblcuenta691.Text) + Convert.ToDecimal(lblcuenta692.Text) + Convert.ToDecimal(lblcuenta693.Text) +
                             Convert.ToDecimal(lblcuenta694.Text) + Convert.ToDecimal(lblcuenta695.Text))

        lblutilidadbruta.Text = Convert.ToDecimal(lbltotalbruto.Text) + Convert.ToDecimal(lblcuenta69.Text)

        lblutilidadoperativa.Text = (Convert.ToDecimal(lblutilidadbruta.Text) - Convert.ToDecimal(lblcuenta94.Text) - Convert.ToDecimal(lblcuenta95.Text) - Convert.ToDecimal(lblcuenta97.Text))

        Label18.Text = (Convert.ToDecimal(lblutilidadoperativa.Text) + Convert.ToDecimal(lblcuenta77.Text) + Convert.ToDecimal(lblcuenta75.Text) + Convert.ToDecimal(lblcuenta76.Text))

    End Sub



    Private Sub EstadoGeneralResultado()
        Dim movimiento As New List(Of movimiento)
        Dim VentaNeta As New movimiento
        Dim VentaNeta2 As New movimiento
        Dim CuentaCostoVenta As New movimiento
        Dim movimientoSA As New MovimientoSA
        Dim CuentaUtilidadOperativa As New movimiento
        Dim CuentaOtrosIngreso As New movimiento
        Dim CuentaRendir As New movimiento

        lblCuenta701.Text = "0.00"
        lblCuenta702.Text = "0.00"
        lblCuenta703.Text = "0.00"
        lblCuenta704.Text = "0.00"
        lblCuenta709.Text = "0.00"
        lblcuenta73.Text = "0.00"
        lblcuenta74.Text = "0.00"
        lblcuenta691.Text = "0.00"
        lblcuenta692.Text = "0.00"
        lblcuenta693.Text = "0.00"
        lblcuenta694.Text = "0.00"
        lblcuenta695.Text = "0.00"
        lblcuenta94.Text = "0.00"
        lblcuenta95.Text = "0.00"
        lblcuenta97.Text = "0.00"
        lblcuenta77.Text = "0.00"
        lblcuenta75.Text = "0.00"
        lblcuenta76.Text = "0.00"
        lblcuenta70.Text = "0.00"
        lbltotalbruto.Text = "0.00"
        lblcuenta69.Text = "0.00"
        lblutilidadbruta.Text = "0.00"
        lblutilidadoperativa.Text = "0.00"
        Label18.Text = "0.00"



        ' movimiento = movimientoSA.CuentaVentasNetas(New asiento With {.fechaProceso = New DateTime(AnioGeneral, MesGeneral, DateTime.Now.Date.Day)})
        VentaNeta = movimientoSA.CuentaVentasNetas(New asiento With {.fechaProceso = New DateTime(AnioGeneral, MesGeneral, DateTime.Now.Date.Day)})
        VentaNeta2 = movimientoSA.CuentaVentasNetas2(New asiento With {.fechaProceso = New DateTime(AnioGeneral, MesGeneral, DateTime.Now.Date.Day)})
        CuentaCostoVenta = movimientoSA.CuentaCostoVenta(New asiento With {.fechaProceso = New DateTime(AnioGeneral, MesGeneral, DateTime.Now.Date.Day)})
        CuentaUtilidadOperativa = movimientoSA.CuentaUtilidadOperativa(New asiento With {.fechaProceso = New DateTime(AnioGeneral, MesGeneral, DateTime.Now.Date.Day)})
        CuentaOtrosIngreso = movimientoSA.CuentaOtrosIngreso(New asiento With {.fechaProceso = New DateTime(AnioGeneral, MesGeneral, DateTime.Now.Date.Day)})


        lblCuenta701.Text = (VentaNeta.debeSaldoS - VentaNeta.haberSaldoS) * -1
        lblCuenta702.Text = (VentaNeta.debe702 - VentaNeta.haber702) * -1
        lblCuenta703.Text = (VentaNeta.debe703 - VentaNeta.haber703) * -1
        lblCuenta704.Text = (VentaNeta.debe704 - VentaNeta.haber704) * -1

        lblCuenta709.Text = (VentaNeta2.debeSaldoS - VentaNeta2.haberSaldoS) * -1
        lblcuenta73.Text = (VentaNeta2.debe73 - VentaNeta2.haber73) * -1
        lblcuenta74.Text = (VentaNeta2.debe74 - VentaNeta2.haber74) * -1


        lblcuenta691.Text = VentaNeta2.debe691 - VentaNeta2.haber691

        lblcuenta692.Text = CuentaCostoVenta.debeSaldoS - CuentaCostoVenta.haberSaldoS
        lblcuenta693.Text = CuentaCostoVenta.debe693 - CuentaCostoVenta.haber693
        lblcuenta694.Text = CuentaCostoVenta.debe694 - CuentaCostoVenta.haber694
        lblcuenta695.Text = CuentaCostoVenta.debe695 - CuentaCostoVenta.haber695


        lblcuenta94.Text = CuentaUtilidadOperativa.debeSaldoS - CuentaUtilidadOperativa.haberSaldoS
        lblcuenta95.Text = CuentaUtilidadOperativa.debe95 - CuentaUtilidadOperativa.haber95
        lblcuenta97.Text = CuentaUtilidadOperativa.debe97 - CuentaUtilidadOperativa.haber97

        lblcuenta77.Text = (CuentaOtrosIngreso.debeSaldoS - CuentaOtrosIngreso.haberSaldoS) * -1
        lblcuenta75.Text = (CuentaOtrosIngreso.debe75 - CuentaOtrosIngreso.haber75) * -1
        lblcuenta76.Text = (CuentaOtrosIngreso.debe76 - CuentaOtrosIngreso.haber76) * -1

        SUMATORIAResultado()

    End Sub
#End Region


#Region "Metodos"

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

                    lblRemuneraciones.Text = (i.debeSaldoS - i.haberSaldoS) * -1

                Case "44"

                    lblPago44.Text = (i.haberSaldoS - i.debeSaldoS) * -1
                Case "45"

                    lblPago45.Text = (i.haberSaldoS - i.debeSaldoS) * -1
                Case "46"

                    lblPago46.Text = (i.haberSaldoS - i.debeSaldoS) * -1
                Case "47"

                    lblPago47.Text = (i.haberSaldoS - i.debeSaldoS) * -1

                Case "48"
                    lblcuenta48.Text = (i.haberSaldoS - i.debeSaldoS) * -1
                Case "49"
                    lblcuenta49.Text = (i.haberSaldoS - i.debeSaldoS) * -1

                Case "50"
                    'CAPITAL
                    lblCuenta50.Text = (i.haberSaldoS - i.debeSaldoS) * -1
                Case "51"
                    'ACCIONES DE INVERSION
                    lblCuenta51.Text = (i.haberSaldoS - i.debeSaldoS) * -1
                Case "52"
                    'CAPITAL ADICIONAL 
                    lblCuenta52.Text = (i.haberSaldoS - i.debeSaldoS) * -1
                Case "56"
                    'RESULTADOS NO REALIZADOS 
                    lblCuenta56.Text = (i.haberSaldoS - i.debeSaldoS) * -1
                Case "57"
                    'EXCEDENTE DE REVALUACION 
                    lblCuenta57.Text = (i.haberSaldoS - i.debeSaldoS) * -1
                Case "58"
                    'RESERVAS 
                    lblCuenta58.Text = (i.haberSaldoS - i.debeSaldoS) * -1
                Case "59"
                    'RESULTADOS ACUMULADOS 
                    lblCuenta59.Text = (i.haberSaldoS - i.debeSaldoS) * -1

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
        lbltotalcobro.Text = (Convert.ToDecimal(lblCuenta10.Text) + Convert.ToDecimal(lblCuenta11.Text) + Convert.ToDecimal(lblCuentaXCobrar.Text) + Convert.ToDecimal(lblCobroCuenta13.Text) +
                                Convert.ToDecimal(lblLetrasCobrar.Text) + Convert.ToDecimal(lblCobro14.Text) + Convert.ToDecimal(lblCobro16.Text + lblCobro17.Text) + Convert.ToDecimal(lblcuenta18.Text) +
                               Convert.ToDecimal(lblcuenta19.Text) + Convert.ToDecimal(lblCobro422.Text) + Convert.ToDecimal(lblCobro432.Text) + Convert.ToDecimal(lblcuentarendir.Text) + Convert.ToDecimal(lblInventariosCobro.Text) +
                               Convert.ToDecimal(lblCuenta29.Text) + Convert.ToDecimal(lblActivoInmovilizadoCobro.Text) + Convert.ToDecimal(lblCuenta36.Text) + Convert.ToDecimal(lblCuenta39.Text) + Convert.ToDecimal(lblcobro40111.Text) +
                               Convert.ToDecimal(lblCobro40.Text))

        'sumapago 
        lblsubtotal.Text = (Convert.ToDecimal(lblRemuneraciones.Text) + Convert.ToDecimal(lblComprasPeriodo.Text) + Convert.ToDecimal(lblPagoCuenta43.Text) + Convert.ToDecimal(lblLetraPago.Text) +
                             Convert.ToDecimal(lblPago44.Text) + Convert.ToDecimal(lblPago45.Text) + Convert.ToDecimal(lblPago46.Text) + Convert.ToDecimal(lblPago47.Text) + Convert.ToDecimal(lblPago122.Text) +
                           Convert.ToDecimal(lblPago132.Text) + Convert.ToDecimal(lblcuenta48.Text) + Convert.ToDecimal(lblcuenta49.Text) + Convert.ToDecimal(lblpago40111.Text) +
                           Convert.ToDecimal(lblPago40.Text))
        lblsubtotal2.Text = (Convert.ToDecimal(lblCuenta50.Text) + Convert.ToDecimal(lblCuenta51.Text) + Convert.ToDecimal(lblCuenta52.Text) +
                             Convert.ToDecimal(lblCuenta56.Text) + Convert.ToDecimal(lblCuenta57.Text) + Convert.ToDecimal(lblCuenta58.Text) + Convert.ToDecimal(lblCuenta59.Text))

        lbltotalpago.Text = Convert.ToDecimal(lblsubtotal.Text) + Convert.ToDecimal(lblsubtotal2.Text)

    End Sub


    'Private Sub EstadoGeneral()
    '    Dim documentoVentaSA As New DocumentoCompraSA
    '    Dim documentoLibroSA As New documentoLibroDiarioSA
    '    Dim documentoLibro As New List(Of documentocompra)
    '    Dim documentoLetras As New documentoLibroDiario
    '    Dim Remuneraciones As New documentoLibroDiario
    '    Dim Cuenta43 As New documentoLibroDiario
    '    Dim Cuenta13 As New documentoLibroDiario
    '    Dim Cuenta44454647 As New documentoLibroDiario
    '    Dim Cuenta122132 As New documentoLibroDiario
    '    Dim cuenta141617 As New documentoLibroDiario
    '    Dim cuenta422432 As New documentoLibroDiario
    '    Dim CobroEntregasarendir As New documentoLibroDiario
    '    Dim tablaSA As New tablaDetalleSA
    '    Dim dt As New DataTable
    '    Dim entidadSA As New entidadSA
    '    Dim personaSA As New PersonaSA


    '    documentoLibro = documentoVentaSA.EstadoGeneralEmpresa()
    '    documentoLetras = documentoLibroSA.EstadoLetrasCobroPago()
    '    Remuneraciones = documentoLibroSA.EstadoRemuneracionesPago()
    '    Cuenta43 = documentoLibroSA.EstadoPagoCuenta43()
    '    Cuenta13 = documentoLibroSA.EstadoCobroCuenta13()
    '    Cuenta44454647 = documentoLibroSA.EstadoPagoCuenta44454647()
    '    Cuenta122132 = documentoLibroSA.EstadoPagoCuenta122132()
    '    cuenta141617 = documentoLibroSA.EstadoCobroCuenta141617()
    '    cuenta422432 = documentoLibroSA.EstadoCobroCuenta422432()
    '    CobroEntregasarendir = documentoLibroSA.EstadoCobroEntregasarendir()

    '    If Not IsNothing(documentoLibro) Then

    '        For Each i In documentoLibro
    '            Dim dr As DataRow = dt.NewRow()
    '            lblComprasPeriodo.Text = i.importeTotal - i.ImportePagoMN
    '            lblCuentaXCobrar.Text = i.montocrono - i.montocronome
    '        Next
    '    Else
    '    End If
    '    'If Not IsNothing(documentoLetras) Then
    '    '    For Each i In documentoLetras
    '    '        Dim dr As DataRow = dt.NewRow()
    '    lblLetraPago.Text = documentoLetras.LetrasPorPagar - documentoLetras.PagoLetras
    '    lblLetrasCobrar.Text = documentoLetras.LetrasPorCobrar - documentoLetras.CobroLetras
    '    'Next
    '    'End If
    '    lblRemuneraciones.Text = Remuneraciones.Remuneraciones - Remuneraciones.PagosRemuneraciones


    '    lblPagoCuenta43.Text = Cuenta43.Remuneraciones - Cuenta43.PagosRemuneraciones

    '    lblCobroCuenta13.Text = Cuenta13.Remuneraciones - Cuenta13.PagosRemuneraciones

    '    lblPago44.Text = Cuenta44454647.Pago44
    '    lblPago45.Text = Cuenta44454647.Pago45
    '    lblPago46.Text = Cuenta44454647.Pago46
    '    lblPago47.Text = Cuenta44454647.Pago47

    '    lblPago122.Text = Cuenta122132.Pago122
    '    lblPago132.Text = Cuenta122132.Pago132

    '    lblCobro14.Text = cuenta141617.Cobro14
    '    lblCobro16.Text = cuenta141617.Cobro16
    '    lblCobro17.Text = cuenta141617.Cobro17

    '    lblCobro422.Text = cuenta422432.Cobro422
    '    lblCobro432.Text = cuenta422432.Cobro432

    '    lblcuentarendir.Text = CobroEntregasarendir.Cobro1413 + CobroEntregasarendir.Cobro1433 + CobroEntregasarendir.Cobro1443 + CobroEntregasarendir.Cobro1681


    'End Sub
#End Region

    Private Sub frmConsultaGerencial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblNombreEmpresa.Text = Gempresas.NomEmpresa
        Label2.Text = Gempresas.NomEmpresa

        TabPageAdv1.Parent = TabControlAdv1
        TabPageAdv2.Parent = Nothing
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        EstadoGeneral()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        EstadoGeneralResultado()
    End Sub

    Private Sub LinkLabel8_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel8.LinkClicked
        Dim f As New frmEstadoCuentaActivo
        f.LblTipoCuenta.Text = "11"
        f.LblCabezera.Text = "INVERSIONES FINANCIERAS  11"
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel30_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel30.LinkClicked
        Dim f As New frmEstadoCuentaActivo
        f.LblTipoCuenta.Text = "12"
        f.LblCabezera.Text = "CUENTAS POR COBRAR COMERCIALES -TERCEROS  (excepto:  122 - 123) "
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel9_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel9.LinkClicked
        Dim f As New frmEstadoCuentaActivo
        f.LblTipoCuenta.Text = "13"
        f.LblCabezera.Text = "CUENTAS POR COBRAR COMERCIALES -RELACIONADAS  (excepto: 132 - 133)"
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel10_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel10.LinkClicked
        Dim f As New frmEstadoCuentaActivo
        f.LblTipoCuenta.Text = "123133"
        f.LblCabezera.Text = "LETRAS POR COBRAR"
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel11_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel11.LinkClicked
        Dim f As New frmEstadoCuentaActivo
        f.LblTipoCuenta.Text = "14"
        f.LblCabezera.Text = "CTAS. POR COBRAR PERSON. ACC. (SOCIOS) DIRECT Y GERENT EXCEPTO  1413-1433-1443"
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel13_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel13.LinkClicked
        Dim f As New frmEstadoCuentaActivo
        f.LblTipoCuenta.Text = "16"
        f.LblCabezera.Text = "CTAS POR COBRAR DIVERSAS - TERCEROS 16"
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel14_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel14.LinkClicked
        Dim f As New frmEstadoCuentaActivo
        f.LblTipoCuenta.Text = "17"
        f.LblCabezera.Text = "CTAS POR COBRAR DIVERSAS - RELACIONADAS 17"
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel12_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel12.LinkClicked
        Dim f As New frmEstadoCuentaActivo
        f.LblTipoCuenta.Text = "19"
        f.LblCabezera.Text = "19 COBRANZA DUDOSA"
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel31_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel31.LinkClicked
        Dim f As New frmEstadoCuentaActivo
        f.LblTipoCuenta.Text = "18"
        f.LblCabezera.Text = "18 SERVICIOS Y OTROS CONTRATADOS POR ANTICIPOS"
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel32_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel32.LinkClicked
        Dim f As New frmEstadoCuentaActivo
        f.LblTipoCuenta.Text = "422"
        f.LblCabezera.Text = "ANTICIPOS A PROVEEDORES 422"
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel33_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel33.LinkClicked
        Dim f As New frmEstadoCuentaActivo
        f.LblTipoCuenta.Text = "432"
        f.LblCabezera.Text = "CTAS ANTICIPOS OTORGADOS A RELACIONADAS 432"
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel34_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel34.LinkClicked
        Dim f As New frmEstadoCuentaActivo
        f.LblTipoCuenta.Text = "1413-1433-1443-1681"
        f.LblCabezera.Text = "ENTREGAS A RENDIR"
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel35_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel35.LinkClicked
        Dim f As New frmEstadoCuentaActivo
        f.LblTipoCuenta.Text = "20-21-22-23-24-25-26-27-28"
        f.LblCabezera.Text = "INVENTARIOS 20-21-22-23-24-25-26-27-28"
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel36_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel36.LinkClicked
        Dim f As New frmEstadoCuentaActivo
        f.LblTipoCuenta.Text = "29"
        f.LblCabezera.Text = "DESVALORIZACION DE INVETARIOS 29"
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel37_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel37.LinkClicked
        Dim f As New frmEstadoCuentaActivo
        f.LblTipoCuenta.Text = "30-31-32-33-34-35-37-38"
        f.LblCabezera.Text = "ACTIVO INMOVILIZADO 30-31-32-33-34-35-37-38"
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel38_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel38.LinkClicked
        Dim f As New frmEstadoCuentaActivo
        f.LblTipoCuenta.Text = "36"
        f.LblCabezera.Text = "DESVALORIZACION DE ACTIVO INMOVILIZADO 36"
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel39_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel39.LinkClicked
        Dim f As New frmEstadoCuentaActivo
        f.LblTipoCuenta.Text = "39"
        f.LblCabezera.Text = "DEPRECIACION, AMORTIZACION Y AGOTAMIENTOS ACUMULADOS 39"
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim f As New frmEstadoCuentaPasivo
        f.LblTipoCuenta.Text = "41"
        f.LblCabezera.Text = "REMUNERACIONES Y PARTICIPACIONES POR PAGAR"
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Dim f As New frmEstadoCuentaPasivo
        f.LblTipoCuenta.Text = "42"
        f.LblCabezera.Text = "CUENTAS POR PAGAR COMERCIALES - TERCEROS (excepto: 422 - 423)"
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Dim f As New frmEstadoCuentaPasivo
        f.LblTipoCuenta.Text = "43"
        f.LblCabezera.Text = "CUENTAS POR PAGAR COMERCIALES - RELACIONADAS (excepto: 432 - 433)"
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Dim f As New frmEstadoCuentaPasivo
        f.LblTipoCuenta.Text = "423433"
        f.LblCabezera.Text = "LETRAS POR PAGAR"
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        Dim f As New frmEstadoCuentaPasivo
        f.LblTipoCuenta.Text = "44"
        f.LblCabezera.Text = "CUENTAS POR PAGAR A LOS ACC (socios)Direct y Gerentes"
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel6_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel6.LinkClicked
        Dim f As New frmEstadoCuentaPasivo
        f.LblTipoCuenta.Text = "45"
        f.LblCabezera.Text = "OBLIGACIONES FINANCIERAS"
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel15_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel15.LinkClicked
        Dim f As New frmEstadoCuentaPasivo
        f.LblTipoCuenta.Text = "46"
        f.LblCabezera.Text = "CUENTAS POR PAGAR DIVERSAS - TERCEROS "
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel16_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel16.LinkClicked
        Dim f As New frmEstadoCuentaPasivo
        f.LblTipoCuenta.Text = "47"
        f.LblCabezera.Text = "CUENTAS POR PAGAR DIVERSAS - RELACIONADAS"
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel17_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel17.LinkClicked
        Dim f As New frmEstadoCuentaPasivo
        f.LblTipoCuenta.Text = "122"
        f.LblCabezera.Text = "ANTICIPOS DE CLIENTES"
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel18_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel18.LinkClicked
        Dim f As New frmEstadoCuentaPasivo
        f.LblTipoCuenta.Text = "132"
        f.LblCabezera.Text = "ANTICIPOS RECIBIDOS DE RELACIONADOS"
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub TabPageAdv1_Click(sender As Object, e As EventArgs) Handles TabPageAdv1.Click

    End Sub

    Private Sub LinkLabel19_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel19.LinkClicked
        Dim f As New frmEstadoCuentaPasivo
        f.LblTipoCuenta.Text = "48"
        f.LblCabezera.Text = "PROVISIONES"
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.WindowState = FormWindowState.Normal
        f.ShowDialog()
    End Sub

    Private Sub LinkLabel20_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel20.LinkClicked
        Dim f As New frmEstadoCuentaPasivo
        f.LblTipoCuenta.Text = "49"
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

    Private Sub treeViewAdv2_AfterSelect(sender As Object, e As EventArgs) Handles treeViewAdv2.AfterSelect
        Select treeViewAdv2.SelectedNode.Text
            Case "Estado Financiero"
                'TabDashboard.Parent = TabControlAdv1
                TabPageAdv1.Parent = TabControlAdv1
                TabPageAdv2.Parent = Nothing
                'TabDetracción.Parent = Nothing
                'TabOrdenCompra.Parent = Nothing
                'TabOrdenServicio.Parent = Nothing
               

            Case "Resultado de Función"
                'GridCFG(dgvCompras)
                TabPageAdv1.Parent = Nothing
                TabPageAdv2.Parent = TabControlAdv1
                'TabDashboard.Parent = Nothing
                ''btSelectAll.Visible = True
                'TabDetracción.Parent = Nothing
                'TabOrdenCompra.Parent = Nothing
                'TabOrdenServicio.Parent = Nothing
                'TabPageAdv1.Text = treeViewAdv2.SelectedNode.Text
        End Select
    End Sub
End Class