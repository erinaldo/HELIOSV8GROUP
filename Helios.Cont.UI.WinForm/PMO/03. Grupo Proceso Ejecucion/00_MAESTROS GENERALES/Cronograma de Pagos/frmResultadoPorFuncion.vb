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

Public Class frmResultadoPorFuncion
    Inherits frmMaster

#Region "Metodos"


    Public Sub SUMATORIA()
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



    Private Sub EstadoGeneral()
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

        SUMATORIA()

    End Sub
#End Region

    Private Sub frmResultadoPorFuncion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblNombreEmpresa.Text = Gempresas.NomEmpresa
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        EstadoGeneral()
    End Sub
End Class