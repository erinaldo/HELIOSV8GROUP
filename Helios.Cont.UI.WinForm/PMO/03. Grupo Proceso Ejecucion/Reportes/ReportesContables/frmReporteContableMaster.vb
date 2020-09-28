Imports Helios.Cont.Business.Entity
Imports Helios.General
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General.Constantes.TIPO_COMPRA

Public Class frmReporteContableMaster
    Inherits frmMaster

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Dim cfecha As Date = DateTime.Now.Date
        MaximizeBox = False
        MinimizeBox = False

        dtpPeriodoMes.Value = New Date(Date.Now.Year, MesGeneral, Date.Now.Day)
        dtpPeriodoAnio.Value = New Date(AnioGeneral, Date.Now.Month, Date.Now.Day)
        dtpAnio.Value = New Date(AnioGeneral, Date.Now.Month, Date.Now.Day)
        'dtpAnio.Text = New DateTime(PeriodoGeneral, cfecha.Month, cfecha.Day)
        'dtpPeriodoAnio.Text = New DateTime(PeriodoGeneral, cfecha.Month, cfecha.Day)
        lblPerido.Text = PeriodoGeneral ' String.Format("{0:00}", Convert.ToInt32(cfecha.Month)) & "/" & PeriodoGeneral
        BuscarMovimientosFull(AnioGeneral)
        'txtDesdeA.Text = "/" & PeriodoGeneral
        'txtHastaD.Text = "/" & PeriodoGeneral
        SetFormatting()
    End Sub

    Dim listaCuenta As New List(Of String)

    Public Sub BuscarMovimientosFull(strPeriodo As Integer)
        Dim movimientoSA As New MovimientoSA
        Dim debeSaldoS, haberSaldoS, debeSaldoUSD, haverSaldoUSD As Decimal
        Dim totalDT, totalHT, totalDS, totalHS, totalDDT, totalHDT, totalDDS, totalHDS As Decimal
        dgvMovimiento.Rows.Clear()

        For Each i In movimientoSA.BuscarMovimientosFull(strPeriodo)
            If (i.monto > i.Montocero) Then
                debeSaldoS = i.monto - i.Montocero
                haberSaldoS = 0.0
            Else
                haberSaldoS = i.Montocero - i.monto
                debeSaldoS = 0.0
            End If

            If (i.montoUSD > i.MontoceroUSD) Then
                debeSaldoUSD = i.montoUSD - i.MontoceroUSD
                haverSaldoUSD = 0.0
            Else
                haverSaldoUSD = i.MontoceroUSD - i.montoUSD
                debeSaldoUSD = 0.0
            End If

            dgvMovimiento.Rows.Add(i.cuenta,
                         i.descripcion,
                         i.monto,
                         i.Montocero,
                        debeSaldoS,
                        haberSaldoS,
                         i.montoUSD,
                         i.MontoceroUSD,
                         debeSaldoUSD,
                         haverSaldoUSD)

            totalDT += CDec(i.monto).ToString("N2")
            totalHT += CDec(i.Montocero).ToString("N2")
            totalDS += CDec(debeSaldoS).ToString("N2")
            totalHS += CDec(haberSaldoS).ToString("N2")
            totalDDT += CDec(i.montoUSD).ToString("N2")
            totalHDT += CDec(i.MontoceroUSD).ToString("N2")
            totalDDS += CDec(debeSaldoUSD).ToString("N2")
            totalHDS += CDec(haverSaldoUSD).ToString("N2")

            listaCuenta.Add(i.cuenta)
        Next
        txtDebeSM.Text = totalDT
        txtHaberSM.Text = totalHT
        txtDebeSS.Text = totalDS
        txtHaberSS.Text = totalHS
        txtDebeDM.Text = totalDDT
        txtHaberDM.Text = totalHDT
        txtDebeDS.Text = totalDDS
        txtHaberDS.Text = totalHDS
    End Sub

    Public Sub BuscarMovimientosPorMes(strPeriodo As Integer, intMes As Integer)
        Dim movimientoSA As New MovimientoSA
        Dim debeSaldoS, haberSaldoS, debeSaldoUSD, haverSaldoUSD As Decimal
        Dim totalDT, totalHT, totalDS, totalHS, totalDDT, totalHDT, totalDDS, totalHDS As Decimal
        dgvMovimiento.Rows.Clear()

        For Each i In movimientoSA.BuscarMovimientosPorMes(strPeriodo, intMes)
            If (i.monto > i.Montocero) Then
                debeSaldoS = i.monto - i.Montocero
                haberSaldoS = 0.0
            Else
                haberSaldoS = i.Montocero - i.monto
                debeSaldoS = 0.0
            End If

            If (i.montoUSD > i.MontoceroUSD) Then
                debeSaldoUSD = i.montoUSD - i.MontoceroUSD
                haverSaldoUSD = 0.0
            Else
                haverSaldoUSD = i.MontoceroUSD - i.montoUSD
                debeSaldoUSD = 0.0
            End If

            dgvMovimiento.Rows.Add(i.cuenta,
                         i.descripcion,
                         i.monto,
                         i.Montocero,
                        debeSaldoS,
                        haberSaldoS,
                         i.montoUSD,
                         i.MontoceroUSD,
                         debeSaldoUSD,
                         haverSaldoUSD)

            totalDT += CDec(i.monto).ToString("N2")
            totalHT += CDec(i.Montocero).ToString("N2")
            totalDS += CDec(debeSaldoS).ToString("N2")
            totalHS += CDec(haberSaldoS).ToString("N2")
            totalDDT += CDec(i.montoUSD).ToString("N2")
            totalHDT += CDec(i.MontoceroUSD).ToString("N2")
            totalDDS += CDec(debeSaldoUSD).ToString("N2")
            totalHDS += CDec(haverSaldoUSD).ToString("N2")

            listaCuenta.Add(i.cuenta)
        Next

        txtDebeSM.Text = totalDT
        txtHaberSM.Text = totalHT
        txtDebeSS.Text = totalDS
        txtHaberSS.Text = totalHS
        txtDebeDM.Text = totalDDT
        txtHaberDM.Text = totalHDT
        txtDebeDS.Text = totalDDS
        txtHaberDS.Text = totalHDS
    End Sub

    Public Sub BuscarMovimientosPorAcumulado(strFechaDesde As Date, strFechaHasta As Date)
        Dim movimientoSA As New MovimientoSA
        Dim debeSaldoS, haberSaldoS, debeSaldoUSD, haverSaldoUSD As Decimal
        Dim totalDT, totalHT, totalDS, totalHS, totalDDT, totalHDT, totalDDS, totalHDS As Decimal
        dgvMovimiento.Rows.Clear()

        For Each i In movimientoSA.BuscarMovimientosPorAcumulado(strFechaDesde, strFechaHasta)
            If (i.monto > i.Montocero) Then
                debeSaldoS = i.monto - i.Montocero
                haberSaldoS = 0.0
            Else
                haberSaldoS = i.Montocero - i.monto
                debeSaldoS = 0.0
            End If

            If (i.montoUSD > i.MontoceroUSD) Then
                debeSaldoUSD = i.montoUSD - i.MontoceroUSD
                haverSaldoUSD = 0.0
            Else
                haverSaldoUSD = i.MontoceroUSD - i.montoUSD
                debeSaldoUSD = 0.0
            End If

            dgvMovimiento.Rows.Add(i.cuenta,
                         i.descripcion,
                         i.monto,
                         i.Montocero,
                        debeSaldoS,
                        haberSaldoS,
                         i.montoUSD,
                         i.MontoceroUSD,
                         debeSaldoUSD,
                         haverSaldoUSD)

            totalDT += CDec(i.monto).ToString("N2")
            totalHT += CDec(i.Montocero).ToString("N2")
            totalDS += CDec(debeSaldoS).ToString("N2")
            totalHS += CDec(haberSaldoS).ToString("N2")
            totalDDT += CDec(i.montoUSD).ToString("N2")
            totalHDT += CDec(i.MontoceroUSD).ToString("N2")
            totalDDS += CDec(debeSaldoUSD).ToString("N2")
            totalHDS += CDec(haverSaldoUSD).ToString("N2")

            listaCuenta.Add(i.cuenta)
        Next

        txtDebeSM.Text = totalDT
        txtHaberSM.Text = totalHT
        txtDebeSS.Text = totalDS
        txtHaberSS.Text = totalHS
        txtDebeDM.Text = totalDDT
        txtHaberDM.Text = totalHDT
        txtDebeDS.Text = totalDDS
        txtHaberDS.Text = totalHDS
    End Sub

    Private Sub dgvMovimiento_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles dgvMovimiento.MouseClick
        With frmReporteContableMasterDetalle
            .BuscarMovimientosdetalle(dgvMovimiento.SelectedRows(0).Cells(0).Value)
            'soles
            .txtDebeT.Text = CDec(dgvMovimiento.SelectedRows(0).Cells(2).Value).ToString("N2")
            .txtHaberT.Text = CDec(dgvMovimiento.SelectedRows(0).Cells(3).Value).ToString("N2")
            .txtDebeS.Text = CDec(dgvMovimiento.SelectedRows(0).Cells(4).Value).ToString("N2")
            .txtHaberS.Text = CDec(dgvMovimiento.SelectedRows(0).Cells(5).Value).ToString("N2")
            'dolares
            .txtDebeTUSD.Text = CDec(dgvMovimiento.SelectedRows(0).Cells(6).Value).ToString("N2")
            .txtHaberTUSD.Text = CDec(dgvMovimiento.SelectedRows(0).Cells(7).Value).ToString("N2")
            .txtDebeSUSD.Text = CDec(dgvMovimiento.SelectedRows(0).Cells(8).Value).ToString("N2")
            .txtHaberSUSD.Text = CDec(dgvMovimiento.SelectedRows(0).Cells(9).Value).ToString("N2")
            'nombre de la cuenta general
            .SetFormattingDetalle()
            .txtCuenta.Text = String.Concat("{" + dgvMovimiento.SelectedRows(0).Cells(0).Value + "}  " + dgvMovimiento.SelectedRows(0).Cells(1).Value)
            .StartPosition = FormStartPosition.CenterScreen
            .Show()
        End With
    End Sub

    Private Sub SetFormatting()
        With Me.dgvMovimiento
            .Columns("debeSoles").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("haberSoles").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("debeSaldo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("haberSaldo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("debeUSD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("haberUSD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("debeSaldoUSD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("haberSaldoUSD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        End With
    End Sub

    Private Sub frmReporteContableMaster_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmReporteContableMaster_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub rbAcumulado_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbAcumulado.CheckedChanged
        If (rbAcumulado.Checked = True) Then
            ValidarCajas(True)
            dtpPeriodoMes.Enabled = False
            txtDesdeAnio.Select()
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        If (rbMensual.Checked = True) Then
            BuscarMovimientosPorMes(2014, dtpPeriodoMes.Value.Month)
        ElseIf (rbAcumulado.Checked = True) Then
            BuscarMovimientosPorAcumulado(CDate(String.Concat(txtDesdeAnio.Text + txtDesdeA.Text)).Date, CDate(String.Concat(txtHastaAnio.Text + txtHastaD.Text)).Date)
        ElseIf (rbTodo.Checked = True) Then
            BuscarMovimientosFull(2014)
        End If
    End Sub

    Private Sub rbMensual_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbMensual.CheckedChanged
        If (rbMensual.Checked = True) Then
            ValidarCajas(False)
            dtpPeriodoMes.Enabled = True
            dtpPeriodoMes.Select()
        End If
    End Sub

    Sub ValidarCajas(srtValidacion As Boolean)
        txtDesdeAnio.Enabled = srtValidacion
        txtDesdeA.Enabled = srtValidacion
        txtHastaAnio.Enabled = srtValidacion
        txtHastaD.Enabled = srtValidacion
    End Sub

    Private Sub lblLibroDiario_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblLibroDiario.LinkClicked

        With frmModalReportesLibroDiario
            If (rbAcumulado.Checked = True) Then
                .Tag = TIPO_REPORTE.ACUMULADO
                .listaDeReportesAsientoPorMes(CDate(String.Concat(txtDesdeAnio.Text + txtDesdeA.Text)).Date, CDate(String.Concat(txtHastaAnio.Text + txtHastaD.Text)).Date)
                .StartPosition = FormStartPosition.CenterScreen
                .Show()
            ElseIf (rbMensual.Checked = True) Then
                .Tag = TIPO_REPORTE.PERIODO
                .listaDeReportesAsientoPorMes(dtpPeriodoAnio.Value, dtpPeriodoMes.Value)
                .StartPosition = FormStartPosition.CenterScreen
                .Show()
            ElseIf (rbTodo.Checked = True) Then
                .Tag = TIPO_REPORTE.FULL
                .listaDeReportesAsientoFull(AnioGeneral)
                .StartPosition = FormStartPosition.CenterScreen
                .Show()
            End If
        End With
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        With frmReporteHojaTrabajoFinal
            If (rbAcumulado.Checked = True) Then
                .Tag = TIPO_REPORTE.ACUMULADO
                .listaDeReportesHojaTrabajoPorAcumulado(CDate(String.Concat(txtDesdeAnio.Text + txtDesdeA.Text)).Date, CDate(String.Concat(txtHastaAnio.Text + txtHastaD.Text)).Date)
                .StartPosition = FormStartPosition.CenterScreen
                .Show()
            ElseIf (rbMensual.Checked = True) Then
                .Tag = TIPO_REPORTE.PERIODO
                .listaDeReportesAsientoPorMes((dtpPeriodoAnio.Value), (dtpPeriodoMes.Value))
                .StartPosition = FormStartPosition.CenterScreen
                .Show()
            ElseIf (rbTodo.Checked = True) Then
                .Tag = TIPO_REPORTE.FULL
                .listaDeReportesHojaTrabajoFinalFull(AnioGeneral)
                .StartPosition = FormStartPosition.CenterScreen
                .Show()

            End If
        End With
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        With frmLibroMayorTipoReporte
            If (rbAcumulado.Checked = True Or rbMensual.Checked = True Or rbTodo.Checked = True) Then
                .listaCuenta = listaCuenta
                .StartPosition = FormStartPosition.CenterScreen
                .Show()
            End If
        End With
    End Sub

    Private Sub LinkLabel8_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        With frmLibroMayorTipoReporte
            If (rbAcumulado.Checked = True Or rbMensual.Checked = True Or rbTodo.Checked = True) Then
                .listaCuenta = listaCuenta
                .StartPosition = FormStartPosition.CenterScreen
                .Show()
            End If
        End With
    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        With frmInformeClase
            If (rbAcumulado.Checked = True) Then
                .Tag = TIPO_REPORTE.ACUMULADO
                .fechaDesde = CDate(String.Concat(txtDesdeAnio.Text + txtDesdeA.Text)).Date
                .fechaHasta = CDate(String.Concat(txtHastaAnio.Text + txtHastaD.Text)).Date
                .anio = (txtDesdeA.Text)
                .txtClase.Select()
                .StartPosition = FormStartPosition.CenterScreen
                .Show()
            ElseIf (rbMensual.Checked = True) Then
                .Tag = TIPO_REPORTE.PERIODO
                .anio = (dtpPeriodoAnio.Value)
                .Mes = (dtpPeriodoMes.Value)
                .txtClase.Select()
                .StartPosition = FormStartPosition.CenterScreen
                .Show()
            ElseIf (rbTodo.Checked = True) Then
                .Tag = TIPO_REPORTE.FULL
                .anio = (dtpAnio.Value)
                .txtClase.Select()
                .StartPosition = FormStartPosition.CenterScreen
                .Show()
            End If
        End With
    End Sub

    Private Sub LinkLabel7_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel7.LinkClicked
        With frmInformeCuentaContable
            If (rbAcumulado.Checked = True Or rbMensual.Checked = True Or rbTodo.Checked = True) Then
                .llenarCuentas(listaCuenta)
                .StartPosition = FormStartPosition.CenterScreen
                .Show()
            End If
        End With
    End Sub

    Private Sub LinkLabel6_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel6.LinkClicked

    End Sub

    Private Sub txtDesdeAnio_LostFocus(sender As Object, e As System.EventArgs) Handles txtDesdeAnio.LostFocus
        Dim srt As String = txtDesdeAnio.Text.Substring(3, 2)
        Dim cFechas As New DateTime(PeriodoGeneral, srt, 1)

        If Not IsDate(cFechas) Then
            MsgBox("Debe digitar una fecha válida!")
        End If
    End Sub

    Private Sub txtDesdeAnio_MaskInputRejected(sender As System.Object, e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtDesdeAnio.MaskInputRejected

    End Sub

    Private Sub txtDesdeAnio_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtDesdeAnio.MouseClick
        txtDesdeAnio.Select(0, 0)
    End Sub

    Private Sub txtHastaAnio_MaskInputRejected(sender As System.Object, e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtHastaAnio.MaskInputRejected

    End Sub

    Private Sub txtHastaAnio_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtHastaAnio.MouseClick
        txtDesdeAnio.Select(0, 0)
    End Sub

    Private Sub dtpPeriodoAnio_ValueChanged(sender As Object, e As EventArgs) Handles dtpPeriodoAnio.ValueChanged

    End Sub

    Private Sub LinkLabel10_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel10.LinkClicked

    End Sub

    Private Sub LinkLabel9_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel9.LinkClicked

    End Sub

    Private Sub LinkLabel11_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel11.LinkClicked

    End Sub
End Class