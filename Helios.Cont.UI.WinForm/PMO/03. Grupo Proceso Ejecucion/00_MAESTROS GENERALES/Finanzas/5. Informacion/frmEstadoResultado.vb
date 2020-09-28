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
Public Class frmEstadoResultado
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

    Private Sub EstadoGeneralResultadoMensual(anioPeriodo As String, mesPeriodo As String)
        Dim movimiento As New List(Of movimiento)
        Dim VentaNeta As New movimiento
        Dim VentaNeta2 As New movimiento
        Dim CuentaCostoVenta As New movimiento
        Dim movimientoSA As New MovimientoSA
        Dim CuentaUtilidadOperativa As New movimiento
        Dim CuentaOtrosIngreso As New movimiento
        Dim CuentaRendir As New movimiento
        Dim CierreResultadoSA As New cierreResultadosSA
        Dim CierreResultado As New cierreResultados

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
        'Label18.Text = "0.00"


        ' movimiento = movimientoSA.CuentaVentasNetas(New asiento With {.fechaProceso = New DateTime(AnioGeneral, MesGeneral, DateTime.Now.Date.Day)})
        VentaNeta = movimientoSA.CuentaVentasNetasMensual(anioPeriodo, mesPeriodo, Gempresas.IdEmpresaRuc)
        VentaNeta2 = movimientoSA.CuentaVentasNetas2Mensual(anioPeriodo, mesPeriodo, Gempresas.IdEmpresaRuc)
        CuentaCostoVenta = movimientoSA.CuentaCostoVentaMensual(anioPeriodo, mesPeriodo, Gempresas.IdEmpresaRuc)
        CuentaUtilidadOperativa = movimientoSA.CuentaUtilidadOperativaMensual(anioPeriodo, mesPeriodo, Gempresas.IdEmpresaRuc)
        CuentaOtrosIngreso = movimientoSA.CuentaOtrosIngresoMensual(anioPeriodo, mesPeriodo, Gempresas.IdEmpresaRuc)



        Dim MesNuevo = String.Format("{0:00}", mesPeriodo)
        CierreResultado = CierreResultadoSA.UbicarCierrePorPeriodo(Gempresas.IdEmpresaRuc, MesNuevo & anioPeriodo)

        If Not IsNothing(CierreResultado) Then
            txtManual.Value = CierreResultado.montoImpuesto
        End If




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

        SUMATORIARESULTADO()

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
        'Label18.Text = "0.00"



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

        SUMATORIARESULTADO()

    End Sub

    Public Sub SUMATORIARESULTADO()
        'suma cobros
        lblcuenta70.Text = (Convert.ToDecimal(lblCuenta701.Text) + Convert.ToDecimal(lblCuenta702.Text) + Convert.ToDecimal(lblCuenta703.Text) + Convert.ToDecimal(lblCuenta704.Text) +
                                Convert.ToDecimal(lblCuenta709.Text))

        'sumapago 
        lbltotalbruto.Text = (Convert.ToDecimal(lblcuenta70.Text) + Convert.ToDecimal(lblcuenta73.Text) - Convert.ToDecimal(lblcuenta74.Text))

        lblcuenta69.Text = (Convert.ToDecimal(lblcuenta691.Text) + Convert.ToDecimal(lblcuenta692.Text) + Convert.ToDecimal(lblcuenta693.Text) +
                             Convert.ToDecimal(lblcuenta694.Text) + Convert.ToDecimal(lblcuenta695.Text))

        lblutilidadbruta.Text = Convert.ToDecimal(lbltotalbruto.Text) - Convert.ToDecimal(lblcuenta69.Text)

        lblutilidadoperativa.Text = (Convert.ToDecimal(lblutilidadbruta.Text) - Convert.ToDecimal(lblcuenta94.Text) - Convert.ToDecimal(lblcuenta95.Text) - Convert.ToDecimal(lblcuenta97.Text))


        Label135.Text = Convert.ToDecimal(lblutilidadoperativa.Text) + Convert.ToDecimal(lblcuenta77.Text) + Convert.ToDecimal(lblcuenta75.Text) + Convert.ToDecimal(lblcuenta76.Text)
        'Label18.Text = (Convert.ToDecimal(lblutilidadoperativa.Text) + Convert.ToDecimal(lblcuenta77.Text) + Convert.ToDecimal(lblcuenta75.Text) + Convert.ToDecimal(lblcuenta76.Text))

        If txtManual.Value >= 0 Then
            lblPartidaExt.Text = Convert.ToDecimal(Label135.Text) - txtManual.Value
        ElseIf txtManual.Value < 0 Then
            lblPartidaExt.Text = Convert.ToDecimal(Label135.Text) + txtManual.Value
        End If

        Label13.Text = Convert.ToDecimal(lblPartidaExt.Text) + Convert.ToDecimal(Label10.Text) + Convert.ToDecimal(Label11.Text) + Convert.ToDecimal(Label12.Text)

    End Sub

#Region "TIMER"

#End Region
#End Region

#Region "Events"
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        EstadoGeneralResultado()
    End Sub
#End Region

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        If cboAnios.Text.Trim.Length > 0 Then
            If cboMes.Text = "ENERO" Then
                EstadoGeneralResultadoMensual(cboAnios.Text, "1")
            ElseIf cboMes.Text = "FEBRERO" Then
                EstadoGeneralResultadoMensual(cboAnios.Text, "2")
            ElseIf cboMes.Text = "MARZO" Then
                EstadoGeneralResultadoMensual(cboAnios.Text, "3")
            ElseIf cboMes.Text = "ABRIL" Then
                EstadoGeneralResultadoMensual(cboAnios.Text, "4")
            ElseIf cboMes.Text = "MAYO" Then
                EstadoGeneralResultadoMensual(cboAnios.Text, "5")
            ElseIf cboMes.Text = "JUNIO" Then
                EstadoGeneralResultadoMensual(cboAnios.Text, "6")
            ElseIf cboMes.Text = "JULIO" Then
                EstadoGeneralResultadoMensual(cboAnios.Text, "7")
            ElseIf cboMes.Text = "AGOSTO" Then
                EstadoGeneralResultadoMensual(cboAnios.Text, "8")
            ElseIf cboMes.Text = "SETIEMBRE" Then
                EstadoGeneralResultadoMensual(cboAnios.Text, "9")
            ElseIf cboMes.Text = "OCTUBRE" Then
                EstadoGeneralResultadoMensual(cboAnios.Text, "10")
            ElseIf cboMes.Text = "NOVIEMBRE" Then
                EstadoGeneralResultadoMensual(cboAnios.Text, "11")
            ElseIf cboMes.Text = "DICIEMBRE" Then
                EstadoGeneralResultadoMensual(cboAnios.Text, "12")
            End If
        Else
            MessageBox.Show("eliga un año")
        End If
    End Sub

    Private Sub Label161_Click(sender As Object, e As EventArgs) Handles Label161.Click

    End Sub

    Private Sub frmEstadoResultado_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Panel68_Paint(sender As Object, e As PaintEventArgs) Handles Panel68.Paint

    End Sub

 

    Private Sub txtManual_ValueChanged(sender As Object, e As EventArgs) Handles txtManual.ValueChanged
        ' lblPartidaExt.Text = Convert.ToDecimal(Label135.Text) - txtManual.Value

        If txtManual.Value >= 0 Then
            lblPartidaExt.Text = Convert.ToDecimal(Label135.Text) - txtManual.Value
        ElseIf txtManual.Value < 0 Then
            lblPartidaExt.Text = Convert.ToDecimal(Label135.Text) + txtManual.Value
        End If

        Label13.Text = Convert.ToDecimal(lblPartidaExt.Text) + Convert.ToDecimal(Label10.Text) + Convert.ToDecimal(Label11.Text) + Convert.ToDecimal(Label12.Text)
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class