Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmNuevaListaPrecio

    Public Property IdAlmacen() As Integer
    Public Property IdItem() As Integer
#Region "TIMER"
    Sub parpadeo()
        Static parpadear As Boolean

        If Not parpadear Then
            lblEstado.ForeColor = lblEstado.BackColor
            lblEstado.BackColor = Color.Yellow
        Else
            lblEstado.ForeColor = SystemColors.WindowText
        End If

        parpadear = Not parpadear
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If TiempoRestante > 0 Then
            parpadeo()

            'lblAgregar.Visible = True
            'lblMensaje.Visible = True
            'tsSave.Enabled = False
            'lblMensaje.Text = "Agregar otro en: " & TiempoRestante
            TiempoRestante = TiempoRestante - 1
        ElseIf TiempoRestante = 0 Then
            Timer1.Enabled = False
            lblEstado.ForeColor = Color.Navy
            lblEstado.BackColor = Color.Transparent
            '      Dispose()
        Else
            Timer1.Enabled = False
            'Ejecuta tu función cuando termina el tiempo
            TiempoEjecutar(10)

        End If
    End Sub
    Private TiempoRestante As Integer
    Public Sub TimerOn(ByRef Interval As Short)
        If Interval > 0 Then
            Timer1.Enabled = True
        Else
            Timer1.Enabled = False
        End If

    End Sub
    Public Function TiempoEjecutar(ByVal Tiempo As Integer)
        TiempoEjecutar = ""
        TiempoRestante = Tiempo  ' 1 minutos=60 segundos 
        Timer1.Interval = 400

        Call TimerOn(1000) ' Hechanos a andar el timer
    End Function
#End Region


#Region "Métodos"
    Public Sub CargraCombos()
        Dim objLista As New TablaDetallesa
  
        Try
            cbomenor.DataSource = objLista.GetListaTablaDetalle(104, "1")
            cbomenor.DisplayMember = "descripcion"
            cbomenor.ValueMember = "codigoDetalle"


            cboMayor.DataSource = objLista.GetListaTablaDetalle(104, "1")
            cboMayor.DisplayMember = "descripcion"
            cboMayor.ValueMember = "codigoDetalle"


            cboGranMayor.DataSource = objLista.GetListaTablaDetalle(104, "1")
            cboGranMayor.DisplayMember = "descripcion"
            cboGranMayor.ValueMember = "codigoDetalle"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Grabar()
        Dim objConfiEO As New listadoPrecios
        Dim ListadoSA As New ListadoPrecioSA
        Try
            With objConfiEO
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                '   .idAlmacen = IdAlmacen ' frmListaPreciosExistencias.txtAlmacen.ValueMember
                .tipoExistencia = lbltipoEx.Text
                .destinoGravado = lblDestino.Text
                .idItem = IdItem ' frmListaPreciosExistencias.lsvListado.SelectedItems(0).SubItems(5).Text
                .descripcion = lblNombreItem.Text
                .presentacion = lblPresentacion.Text
                .unidad = Nothing ' lblUnidad.Text
                .fecha = txtFechaRegistro.Value
                .valcompraIgvMN = nudVCconIGVMN.Value
                .valcompraSinIgvMN = nudVCsinIGVMN.Value
                .valcompraIgvME = Math.Round(CDec(nudVCconIGVMN.Value) / CDec(txtTipoCambio.Text), 2) ' nudVCconIGVME.Value
                .valcompraSinIgvME = Math.Round(CDec(nudVCsinIGVMN.Value) / CDec(txtTipoCambio.Text), 2)
                .tipoConfiguracion = IIf(cboModalidad.SelectedIndex = 0, "PC", "MF")
                If cboModalidad.SelectedIndex = 0 Then
                    .montoUtilidad = nudUtilidadMN.Value
                    .montoUtilidadME = nudUtilidadMN.Value
                ElseIf cboModalidad.SelectedIndex = 1 Then
                    .montoUtilidad = nudUtilidadMN.Value
                    .montoUtilidadME = nudUtilidadME.Value
                End If
                .utilidadsinIgvMN = txtUtilsinIGVMN.Text
                .valorVentaMN = txtValorVentaMN.Text
                .igvMN = txtIgvMN.Text
                .iscMN = txtIscMN.Text
                .otcMN = txtOtcMN.Text
                .precioVentaMN = txtPrecioVentaMN.Text
                .utilidadsinIgvME = Math.Round(CDec(txtUtilsinIGVMN.Text) / CDec(txtTipoCambio.Text), 2)
                .valorVentaME = Math.Round(CDec(txtValorVentaMN.Text) / CDec(txtTipoCambio.Text), 2)
                .igvME = Math.Round(CDec(txtIgvMN.Text) / CDec(txtTipoCambio.Text), 2)
                .iscME = Math.Round(CDec(txtIscMN.Text) / CDec(txtTipoCambio.Text), 2)
                .otcME = Math.Round(CDec(txtOtcMN.Text) / CDec(txtTipoCambio.Text), 2)
                .precioVentaME = Math.Round(CDec(txtPrecioVentaMN.Text) / CDec(txtTipoCambio.Text), 2)

                .PorDsctounitMenor = txtmnPor.Text
                .montoDsctounitMenorMN = txtmnImporteMN.Text
                .montoDsctounitMenorME = Math.Round(CDec(txtmnImporteMN.Text) / CDec(txtTipoCambio.Text), 2)
                .precioVentaFinalMenorMN = txtmnVFMN.Text
                .precioVentaFinalMenorME = Math.Round(CDec(txtmnVFMN.Text) / CDec(txtTipoCambio.Text), 2)

                .PorDsctounitMayor = txtmyPor.Text
                .montoDsctounitMayorMN = txtmyImporteMN.Text
                .montoDsctounitMayorME = Math.Round(CDec(txtmyImporteMN.Text) / CDec(txtTipoCambio.Text), 2)
                .precioVentaFinalMayorMN = txtmyVFMN.Text
                .precioVentaFinalMayorME = Math.Round(CDec(txtmyVFMN.Text) / CDec(txtTipoCambio.Text), 2)

                .PorDsctounitGMayor = txtgmyPor.Text
                .montoDsctounitGMayorMN = txtgmyImporteMN.Text
                .montoDsctounitGMayorME = Math.Round(CDec(txtgmyImporteMN.Text) / CDec(txtTipoCambio.Text), 2)
                .precioVentaFinalGMayorMN = txtgmyVFMN.Text
                .precioVentaFinalGMayorME = Math.Round(CDec(txtgmyVFMN.Text) / CDec(txtTipoCambio.Text), 2)

                .DetalleMenor = cbomenor.SelectedValue
                .DetalleMayor = cboMayor.SelectedValue
                .DetalleGMayor = cboGranMayor.SelectedValue

                .CantidadMenor = nudMenor.Value
                .CantidadMayor = nudMayor.Value
                .CantidadGMayor = nudGMayor.Value
                .usuarioActualizacion = "Jiuni"
                .fechaActualizacion = Date.Now

            End With

            ListadoSA.InsertListadoPrecio(objConfiEO)
            Dispose()
        Catch ex As Exception
            MsgBox("No se grabó correctamente." & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del Sistema.!")
        End Try
    End Sub

    'Public Sub UbicarPM(ByVal strIdEmpresa As String, ByVal intIdEstablecimiento As Integer,
    '                                        ByVal intIdAlmacen As Integer, ByVal strTipoExistencia As String,
    '                                        ByVal strDestinoGrav As String, ByVal intItem As Integer,
    '                                        ByVal strPresentacion As String, ByVal strUnidad As String)

    '    Dim objLista() As HeliosService.InventarioMovimientoBO
    '    Try
    '        objLista = objService.GetObtenerUtimoPM(strIdEmpresa, intIdEstablecimiento,
    '                                                intIdAlmacen, strTipoExistencia,
    '                                                strDestinoGrav, intItem,
    '                                                strPresentacion, strUnidad)

    '        '  nudVCconIGVMN.Value = objLista(0).PrecioUnitE
    '        '  nudVCconIGVME.Value = objLista(0).PrecioUnitUSD
    '        If objLista.Length > 0 Then
    '            nudVCsinIGVMN.Value = CDec(objLista(0).PrecioUnitE) ' / CDec(objLista(0).cantidad), 2)
    '            nudVCsinIGVME.Value = CDec(objLista(0).PrecioUnitUSD) ' / CDec(objLista(0).cantidad), 2)
    '        End If
    '        'If lblDestino.Text = "1" Then
    '        '    nudVCsinIGVMN.Value = Math.Round(objLista(0).PrecioUnitE / 1.18, 2)
    '        '    nudVCsinIGVME.Value = Math.Round(objLista(0).PrecioUnitUSD / 1.18, 2)
    '        'Else
    '        '    nudVCsinIGVMN.Value = objLista(0).PrecioUnitE
    '        '    nudVCsinIGVME.Value = objLista(0).PrecioUnitUSD
    '        'End If

    '    Catch ex As Exception
    '        MsgBox("No se obtuvieron registros correctamente." & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del Sistema.!")
    '    End Try

    'End Sub
#End Region

#Region "CalcularMontos"
    Private Sub Calculos()
        nudVCconIGVMN.Value = Math.Round(nudVCsinIGVMN.Value * 1.18, 2)
        If cboModalidad.SelectedIndex = 0 Then
            txtUtilsinIGVMN.Text = Math.Round(nudVCsinIGVMN.Value * CDec(nudUtilidadMN.Value / 100), 2)
        ElseIf cboModalidad.SelectedIndex = 1 Then
            txtUtilsinIGVMN.Text = nudUtilidadMN.Value
        End If
        txtValorVentaMN.Text = Math.Round(nudVCsinIGVMN.Value + CDec(txtUtilsinIGVMN.Text), 2)
        If lblDestino.Text = "1" Then
            txtIgvMN.Text = Math.Round(CDec(txtValorVentaMN.Text) * CDec(0.18), 2)
        Else
            txtIgvMN.Text = "0.00"
        End If
        txtPrecioVentaMN.Text = Math.Round(CDec(txtValorVentaMN.Text) + CDec(txtIgvMN.Text) + CDec(txtIscMN.Text) + CDec(txtOtcMN.Text), 2)
        txtmnVFMN.Text = txtPrecioVentaMN.Text
        txtmyVFMN.Text = txtPrecioVentaMN.Text
        txtgmyVFMN.Text = txtPrecioVentaMN.Text
    End Sub

    Private Sub CalculosME()
        nudVCconIGVME.Value = Math.Round(nudVCsinIGVME.Value * 1.18, 2)
        ' MONEDA EXTRANJERA
        If cboModalidad.SelectedIndex = 0 Then
            txtUtilsinIGVME.Text = Math.Round(nudVCsinIGVME.Value * CDec(nudUtilidadMN.Value / 100), 2)
        ElseIf cboModalidad.SelectedIndex = 1 Then
            txtUtilsinIGVME.Text = nudUtilidadME.Value
        End If
        txtValorVentaME.Text = Math.Round(nudVCsinIGVME.Value + CDec(txtUtilsinIGVME.Text), 2)
        If lblDestino.Text = "1" Then
            txtIgvME.Text = Math.Round(CDec(txtValorVentaME.Text) * CDec(0.18), 2)
        Else
            txtIgvME.Text = "0.00"
        End If
        txtPrecioVentaME.Text = Math.Round(CDec(txtValorVentaME.Text) + CDec(txtIgvME.Text) + CDec(txtIscME.Text) + CDec(txtOtcME.Text), 2)
    End Sub

    Private Sub CalculoMenor()
        If IsNumeric(txtmnPor.Text) Then
            If CDec(txtmnPor.Text) > 0 Then
                txtmnImporteMN.Text = Math.Round(CDec(txtValorVentaMN.Text) * CDec(txtmnPor.Text) / 100, 2)
                txtmnVFMN.Text = Math.Round(CDec(txtPrecioVentaMN.Text) - CDec(txtmnImporteMN.Text), 2)
            End If
        End If
    End Sub

    Private Sub CalculoMenorME()
        If CDec(txtmnPorME.Text) > 0 Then
            txtmnImporteME.Text = Math.Round(CDec(txtValorVentaME.Text) * CDec(txtmnPorME.Text) / 100, 2)
            txtmnVFME.Text = Math.Round(CDec(txtPrecioVentaME.Text) - CDec(txtmnImporteME.Text), 2)
        End If
    End Sub

    Private Sub CalculoMayor()
        If CDec(txtmyPor.Text) > 0 Then
            txtmyImporteMN.Text = Math.Round(CDec(txtValorVentaMN.Text) * CDec(txtmyPor.Text) / 100, 2)
            txtmyVFMN.Text = Math.Round(CDec(txtPrecioVentaMN.Text) - CDec(txtmyImporteMN.Text), 2)
        End If
    End Sub

    Private Sub CalculoMayorEX()
        If CDec(txtmyPorME.Text) > 0 Then
            txtmyImporteME.Text = Math.Round(CDec(txtValorVentaME.Text) * CDec(txtmyPorME.Text) / 100, 2)
            txtmyVFME.Text = Math.Round(CDec(txtPrecioVentaME.Text) - CDec(txtmyImporteME.Text), 2)
        End If
    End Sub

    Private Sub CalculoGranMayor()
        If CDec(txtgmyPor.Text) > 0 Then
            txtgmyImporteMN.Text = Math.Round(CDec(txtValorVentaMN.Text) * CDec(txtgmyPor.Text) / 100, 2)
            txtgmyVFMN.Text = Math.Round(CDec(txtPrecioVentaMN.Text) - CDec(txtgmyImporteMN.Text), 2)
        End If
    End Sub

    Private Sub CalculoGranMayorME()
        If CDec(txtgmyPorME.Text) > 0 Then
            txtgmyImporteME.Text = Math.Round(CDec(txtValorVentaME.Text) * CDec(txtgmyPorME.Text) / 100, 2)
            txtgmyVFME.Text = Math.Round(CDec(txtPrecioVentaME.Text) - CDec(txtgmyImporteME.Text), 2)
        End If
    End Sub
#End Region

    Private Sub nudVCconIGVMN_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles nudVCconIGVMN.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            nudVCsinIGVMN.Focus()
            nudVCsinIGVMN.Select(0, nudVCsinIGVMN.Text.Length)
        End If
    End Sub

    Private Sub nudMN_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles nudVCconIGVMN.MouseClick
        nudVCconIGVMN.Select(0, nudVCconIGVMN.Text.Length)
    End Sub

    Private Sub nudVCsinIGVMN_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles nudVCsinIGVMN.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            nudUtilidadMN.Focus()
            nudUtilidadMN.Select(0, nudUtilidadMN.Text.Length)
        End If
    End Sub

    Private Sub nudME_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles nudVCsinIGVMN.MouseClick
        nudVCsinIGVMN.Select(0, nudVCsinIGVMN.Text.Length)
    End Sub

    Private Sub frmNuevaListaPrecio_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmNuevaListaPrecio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'CargraCombos()
        cboModalidad.SelectedIndex = 0
        'UbicarPM(CEmpresa, CEstablecimiento, frmListaPreciosExistencias.cboalmacen.SelectedValue,
        '         lbltipoEx.Text, lblDestino.Text, frmListaPreciosExistencias.lsvListado.SelectedItems(0).SubItems(5).Text,
        '         lblPresentacion.Text, lblUnidad.Text)
        Habilitar(0)
        txtTipoCambio.Enabled = True
        txtTipoCambio.Select()
        txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
    End Sub

    Public Sub LimpiarCajas()
        Dim i As Control
        For Each i In Me.Controls
            If TypeOf i Is TextBox Then i.Text = "0.00"
            '  If TypeOf i Is NumericUpDown Then i.Text = "0.00"
        Next


    End Sub

    Public Sub Habilitar(ByVal caso As Byte)
        Dim i As Control
        Select Case caso
            Case 1
                For Each i In Me.Controls
                    If TypeOf i Is TextBox Then i.Enabled = True
                    If TypeOf i Is NumericUpDown Then i.Enabled = True
                Next
            Case 0
                For Each i In Me.Controls
                    If TypeOf i Is TextBox Then i.Enabled = False
                    If TypeOf i Is NumericUpDown Then i.Enabled = False
                Next
        End Select
    End Sub

    Private Sub cboModalidad_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboModalidad.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtFechaRegistro.Focus()
        End If
    End Sub
    Private Sub cboModalidad_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboModalidad.SelectedIndexChanged
        LimpiarCajas()
        nudUtilidadMN.Value = 0
        nudUtilidadME.Value = 0
        If cboModalidad.SelectedIndex = 0 Then
            lblValConfMN.Text = "POR PORCENTAJE"
            lblValConfME.Text = "POR PORCENTAJE"
        Else
            lblValConfMN.Text = "MONTO FIJO"
            lblValConfME.Text = "MONTO FIJO"
        End If
        txtTipoCambio.Focus()
        txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
    End Sub

    Private Sub nudVCconIGVMN_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nudVCconIGVMN.ValueChanged
        'If CDec(txtTipoCambio.Text) > 0 Then
        '    nudVCconIGVME.Value = Math.Round(nudVCconIGVMN.Value / CDec(txtTipoCambio.Text), 2)
        'End If
    End Sub

    Private Sub nudVCsinIGVMN_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nudVCsinIGVMN.ValueChanged

        Dim valIGV As Decimal = 0
        valIGV = Math.Round(CDec(nudVCsinIGVMN.Value) * 0.18, 2)

        nudVCconIGVMN.Value = Math.Round(CDec(valIGV) + CDec(nudVCsinIGVMN.Value), 2)

        'If IsNumeric(txtTipoCambio.Text) And CDec(txtTipoCambio.Text) > 0 Then
        '    nudVCsinIGVME.Value = Math.Round(nudVCsinIGVMN.Value / CDec(txtTipoCambio.Text), 2)
        '    If nudUtilidadMN.Value > 0 Then
        '        If nudVCsinIGVMN.Value > 0 Then
        '            Calculos()
        '            txtmnPor_TextChanged(sender, e)
        '            txtmyPor_TextChanged(sender, e)
        '            txtgmyPor_TextChanged(sender, e)
        '        End If
        '    End If
        'End If
    End Sub

    Private Sub nudUtilidadMN_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles nudUtilidadMN.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtmnPor.Focus()
            txtmnPor.Select(0, txtmnPor.Text.Length)
        End If
    End Sub

    Private Sub nudUtilidadMN_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles nudUtilidadMN.MouseClick
        nudUtilidadMN.Select(0, nudUtilidadMN.Text.Length)
    End Sub

    Private Sub nudUtilidadMN_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nudUtilidadMN.ValueChanged
        If txtTipoCambio.Text.Trim.Length > 0 Then
            If CDec(txtTipoCambio.Text) > 0 And IsNumeric(txtTipoCambio.Text) Then
                If nudUtilidadMN.Value >= 0 Then
                    Calculos()
                    nudUtilidadME.Value = Math.Round(nudUtilidadMN.Value / CDec(txtTipoCambio.Text), 2)
                    txtmnPor_TextChanged(sender, e)
                    txtmyPor_TextChanged(sender, e)
                    txtgmyPor_TextChanged(sender, e)
                End If
            End If
        End If
    End Sub

    Private Sub nudVCconIGVME_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles nudVCconIGVME.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            nudVCsinIGVME.Focus()
            nudVCsinIGVME.Select(0, nudVCsinIGVME.Text.Length)
        End If
    End Sub

    Private Sub nudVCconIGVME_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles nudVCconIGVME.MouseClick
        nudVCconIGVME.Select(0, nudVCconIGVME.Text.Length)
    End Sub

    Private Sub nudVCconIGVME_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nudVCconIGVME.ValueChanged

    End Sub

    Private Sub nudVCsinIGVME_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles nudVCsinIGVME.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            nudUtilidadME.Focus()
            nudUtilidadME.Select(0, nudUtilidadME.Text.Length)
        End If
    End Sub

    Private Sub nudVCsinIGVME_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles nudVCsinIGVME.MouseClick
        nudVCsinIGVME.Select(0, nudVCsinIGVME.Text.Length)
    End Sub

    Private Sub nudVCsinIGVME_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nudVCsinIGVME.ValueChanged
        If nudUtilidadME.Value > 0 Then
            If nudVCsinIGVME.Value > 0 Then
                CalculosME()
                txtmnPorME_TextChanged(sender, e)
                txtmyPorME_TextChanged(sender, e)
                txtgmyPorME_TextChanged(sender, e)
            End If
        End If
    End Sub

    Private Sub nudUtilidadME_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles nudUtilidadME.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtUtilsinIGVMN.Focus()
            txtUtilsinIGVMN.Select(0, txtUtilsinIGVMN.Text.Length)
        End If
    End Sub

    Private Sub nudUtilidadME_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles nudUtilidadME.MouseClick
        nudUtilidadME.Select(0, nudUtilidadME.Text.Length)
    End Sub

    Private Sub nudUtilidadME_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nudUtilidadME.ValueChanged
        If nudUtilidadME.Value >= 0 Then
            CalculosME()
            txtmnPorME_TextChanged(sender, e)
            txtmyPorME_TextChanged(sender, e)
            txtgmyPorME_TextChanged(sender, e)
        End If
    End Sub

    Private Sub txtTipoCambio_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtTipoCambio.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtTipoCambio.Text = CDec(txtTipoCambio.Text).ToString("N2")
            nudUtilidadMN.Focus()
            nudUtilidadMN.Select(0, nudUtilidadMN.Text.Length)
        End If
    End Sub

    Private Sub txtTipoCambio_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtTipoCambio.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub
    Function SoloNumeros(ByVal Keyascii As Short) As Short
        If InStr("1234567890.", Chr(Keyascii)) = 0 Then
            SoloNumeros = 0
        Else
            SoloNumeros = Keyascii
        End If
        Select Case Keyascii
            Case 8
                SoloNumeros = Keyascii
            Case 13
                SoloNumeros = Keyascii
        End Select
    End Function

    Private Sub txtTipoCambio_LostFocus(sender As Object, e As System.EventArgs) Handles txtTipoCambio.LostFocus
        If IsNumeric(txtTipoCambio.Text) Then
            If CDec(txtTipoCambio.Text) > 0 Then
                txtTipoCambio.Text = CDec(txtTipoCambio.Text).ToString("N2")
            Else
                '       MsgBox("El t/c debe ser mayor a cero.", MsgBoxStyle.Information, "Atención!")
                txtTipoCambio.Focus()
                txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
            End If
        Else
            txtTipoCambio.Focus()
            txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
        End If
    End Sub
    Private Sub txtTipoCambio_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtTipoCambio.MouseClick
        txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
    End Sub

    Private Sub txtTipoCambio_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTipoCambio.TextChanged
        If txtTipoCambio.Text.Trim.Length > 0 Then
            If IsNumeric(txtTipoCambio.Text) Then
                If CDec(txtTipoCambio.Text) > 0 Then
                    nudVCsinIGVMN_ValueChanged(sender, e)
                    Habilitar(1)
                Else
                    Dim i As Control
                    For Each i In Me.Controls
                        If TypeOf i Is TextBox Then i.Text = "0.00"
                    Next
                    Habilitar(0)
                    txtTipoCambio.Enabled = True
                End If
            Else
                txtTipoCambio.Enabled = True
                txtTipoCambio.Text = 0
                txtTipoCambio.Focus()
                txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
            End If
        End If
    End Sub

    Private Sub txtUtilsinIGVMN_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtUtilsinIGVMN.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then

            e.SuppressKeyPress = True
            If Not txtUtilsinIGVMN.Text.Trim.Length > 0 Then
                txtUtilsinIGVMN.Text = "0.00"
            Else
                txtUtilsinIGVMN.Text = CDec(txtUtilsinIGVMN.Text).ToString("N2")
                txtValorVentaMN.Focus()
                txtValorVentaMN.Select(0, txtValorVentaMN.Text.Length)
            End If

        End If
    End Sub

    Private Sub txtUtilsinIGVMN_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtUtilsinIGVMN.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtUtilsinIGVMN_LostFocus(sender As Object, e As System.EventArgs) Handles txtUtilsinIGVMN.LostFocus
        If IsNumeric(txtUtilsinIGVMN.Text) Then
            txtUtilsinIGVMN.Text = CDec(txtUtilsinIGVMN.Text).ToString("N2")
        End If
    End Sub

    Private Sub txtUtilsinIGVMN_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtUtilsinIGVMN.MouseClick
        txtUtilsinIGVMN.Select(0, txtUtilsinIGVMN.Text.Length)
    End Sub

    Private Sub txtUtilsinIGVMN_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtUtilsinIGVMN.TextChanged

    End Sub

    Private Sub txtValorVentaMN_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtValorVentaMN.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            If Not txtValorVentaMN.Text.Trim.Length > 0 Then
                txtValorVentaMN.Text = "0.00"
            Else
                txtValorVentaMN.Text = CDec(txtValorVentaMN.Text).ToString("N2")
                txtIgvMN.Focus()
                txtIgvMN.Select(0, txtIgvMN.Text.Length)
            End If
        End If
    End Sub

    Private Sub txtValorVentaMN_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtValorVentaMN.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtValorVentaMN_LostFocus(sender As Object, e As System.EventArgs) Handles txtValorVentaMN.LostFocus
        If IsNumeric(txtValorVentaMN.Text) Then
            txtValorVentaMN.Text = CDec(txtValorVentaMN.Text).ToString("N2")
        End If
    End Sub

    Private Sub txtValorVentaMN_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtValorVentaMN.MouseClick
        txtValorVentaMN.Select(0, txtValorVentaMN.Text.Length)
    End Sub

    Private Sub txtValorVentaMN_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtValorVentaMN.TextChanged

    End Sub

    Private Sub txtIgvMN_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtIgvMN.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            If Not txtIgvMN.Text.Trim.Length > 0 Then
                txtIgvMN.Text = "0.00"
            Else
                txtIgvMN.Text = CDec(txtIgvMN.Text).ToString("N2")
                txtIscMN.Focus()
                txtIscMN.Select(0, txtIscMN.Text.Length)
            End If
        End If
    End Sub

    Private Sub txtIgvMN_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtIgvMN.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtIgvMN_Leave(sender As Object, e As System.EventArgs) Handles txtIgvMN.Leave

    End Sub

    Private Sub txtIgvMN_LostFocus(sender As Object, e As System.EventArgs) Handles txtIgvMN.LostFocus
        If IsNumeric(txtIgvMN.Text) Then
            txtIgvMN.Text = CDec(txtIgvMN.Text).ToString("N2")
        End If
    End Sub

    Private Sub txtIgvMN_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtIgvMN.MouseClick
        txtIgvMN.Select(0, txtIgvMN.Text.Length)
    End Sub

    Private Sub txtIgvMN_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtIgvMN.TextChanged

    End Sub

    Private Sub txtIscMN_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtIscMN.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            If Not txtIscMN.Text.Trim.Length > 0 Then
                txtIscMN.Text = "0.00"
            Else
                txtIscMN.Text = CDec(txtIscMN.Text).ToString("N2")
                txtOtcMN.Focus()
                txtOtcMN.Select(0, txtOtcMN.Text.Length)
            End If
        End If
    End Sub

    Private Sub txtIscMN_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtIscMN.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtIscMN_LostFocus(sender As Object, e As System.EventArgs) Handles txtIscMN.LostFocus
        If IsNumeric(txtIscMN.Text) Then
            txtIscMN.Text = CDec(txtIscMN.Text).ToString("N2")
        End If
    End Sub

    Private Sub txtIscMN_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtIscMN.MouseClick
        txtIscMN.Select(0, txtIscMN.Text.Length)
    End Sub

    Private Sub txtIscMN_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtIscMN.TextChanged

    End Sub

    Private Sub txtOtcMN_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtOtcMN.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            If Not txtOtcMN.Text.Trim.Length > 0 Then
                txtOtcMN.Text = "0.00"
            Else
                txtOtcMN.Text = CDec(txtOtcMN.Text).ToString("N2")
                txtPrecioVentaMN.Focus()
                txtPrecioVentaMN.Select(0, txtPrecioVentaMN.Text.Length)
            End If
        End If
    End Sub

    Private Sub txtOtcMN_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtOtcMN.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtOtcMN_LostFocus(sender As Object, e As System.EventArgs) Handles txtOtcMN.LostFocus
        If IsNumeric(txtOtcMN.Text) Then
            txtOtcMN.Text = CDec(txtOtcMN.Text).ToString("N2")
        End If
    End Sub

    Private Sub txtOtcMN_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtOtcMN.MouseClick
        txtOtcMN.Select(0, txtOtcMN.Text.Length)
    End Sub

    Private Sub txtOtcMN_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtOtcMN.TextChanged
        If txtTipoCambio.Text.Trim.Length > 0 And CDec(txtTipoCambio.Text) > 0 Then
            If IsNumeric(txtOtcMN.Text) Then
                If CDec(txtOtcMN.Text) >= 0 Then
                    txtOtcME.Text = Math.Round(CDec(txtOtcMN.Text) / 2, 2)
                    Calculos()
                    CalculosME()
                End If
            End If
        End If
    End Sub

    Private Sub txtPrecioVentaMN_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtPrecioVentaMN.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            If Not txtPrecioVentaMN.Text.Trim.Length > 0 Then
                txtPrecioVentaMN.Text = "0.00"
            Else
                txtPrecioVentaMN.Text = CDec(txtPrecioVentaMN.Text).ToString("N2")
                txtmnPor.Focus()
                txtmnPor.Select(0, txtmnPor.Text.Length)
            End If
        End If
    End Sub

    Private Sub txtPrecioVentaMN_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrecioVentaMN.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtPrecioVentaMN_LostFocus(sender As Object, e As System.EventArgs) Handles txtPrecioVentaMN.LostFocus
        If IsNumeric(txtPrecioVentaMN.Text) Then
            txtPrecioVentaMN.Text = CDec(txtPrecioVentaMN.Text).ToString("N2")
        End If
    End Sub

    Private Sub txtPrecioVentaMN_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtPrecioVentaMN.MouseClick
        txtPrecioVentaMN.Select(0, txtPrecioVentaMN.Text.Length)
    End Sub

    Private Sub txtPrecioVentaMN_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPrecioVentaMN.TextChanged

    End Sub

    Private Sub txtmnPor_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtmnPor.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            If Not txtmnPor.Text.Trim.Length > 0 Then
                txtmnPor.Text = "0.00"
            Else
                txtmnPor.Text = CDec(txtmnPor.Text).ToString("N2")
                txtmyPor.Focus()
                txtmyPor.Select(0, txtmyPor.Text.Length)
            End If
        End If
    End Sub

    Private Sub txtmnPor_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtmnPor.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtmnPor_LostFocus(sender As Object, e As System.EventArgs) Handles txtmnPor.LostFocus
        If IsNumeric(txtmnPor.Text) Then
            txtmnPor.Text = CDec(txtmnPor.Text).ToString("N2")
        End If
    End Sub

    Private Sub txtmnPor_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtmnPor.MouseClick
        txtmnPor.Select(0, txtmnPor.Text.Length)
    End Sub

    Private Sub txtmnPor_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtmnPor.TextChanged
        If txtTipoCambio.Text.Trim.Length > 0 And CDec(txtTipoCambio.Text) > 0 Then
            If IsNumeric(txtTipoCambio.Text) And CDec(txtTipoCambio.Text) > 0 Then
                CalculoMenor()
                If IsNumeric(txtmnPor.Text) Then
                    txtmnPorME.Text = txtmnPor.Text ' Math.Round(CDec(txtmnPor.Text) / CDec(txtTipoCambio.Text), 2)
                End If
            End If
        End If
    End Sub

    Private Sub txtmnImporteMN_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtmnImporteMN.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtmnImporteMN.Text = CDec(txtmnImporteMN.Text).ToString("N2")
            txtmnVFMN.Focus()
            txtmnVFMN.Select(0, txtmnVFMN.Text.Length)
        End If
    End Sub

    Private Sub txtmnImporteMN_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtmnImporteMN.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtmnImporteMN_LostFocus(sender As Object, e As System.EventArgs) Handles txtmnImporteMN.LostFocus
        If IsNumeric(txtmnImporteMN.Text) Then
            txtmnImporteMN.Text = CDec(txtmnImporteMN.Text).ToString("N2")
        End If
    End Sub

    Private Sub txtmnImporteMN_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtmnImporteMN.MouseClick
        txtmnImporteMN.Select(0, txtmnImporteMN.Text.Length)
    End Sub

    Private Sub txtmnImporteMN_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtmnImporteMN.TextChanged

    End Sub

    Private Sub txtmnVFMN_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtmnVFMN.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtmnVFMN.Text = CDec(txtmnVFMN.Text).ToString("N2")
            txtmyPor.Focus()
            txtmyPor.Select(0, txtmyPor.Text.Length)
        End If
    End Sub

    Private Sub txtmnVFMN_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtmnVFMN.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtmnVFMN_LostFocus(sender As Object, e As System.EventArgs) Handles txtmnVFMN.LostFocus
        If IsNumeric(txtmnVFMN.Text) Then
            txtmnVFMN.Text = CDec(txtmnVFMN.Text).ToString("N2")
        End If
    End Sub

    Private Sub txtmnVFMN_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtmnVFMN.MouseClick
        txtmnVFMN.Select(0, txtmnVFMN.Text.Length)
    End Sub

    Private Sub txtmnVFMN_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtmnVFMN.TextChanged

    End Sub

    Private Sub txtmyPor_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtmyPor.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            If Not txtmyPor.Text.Trim.Length > 0 Then
                txtmyPor.Text = "0.00"
            Else
                txtmyPor.Text = CDec(txtmyPor.Text).ToString("N2")
                txtgmyPor.Focus()
                txtgmyPor.Select(0, txtgmyPor.Text.Length)
            End If
        End If
    End Sub

    Private Sub txtmyPor_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtmyPor.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtmyPor_LostFocus(sender As Object, e As System.EventArgs) Handles txtmyPor.LostFocus
        If IsNumeric(txtmyPor.Text) Then
            txtmyPor.Text = CDec(txtmyPor.Text).ToString("N2")
        End If
    End Sub

    Private Sub txtmyPor_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtmyPor.MouseClick
        txtmyPor.Select(0, txtmyPor.Text.Length)
    End Sub

    Private Sub txtmyPor_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtmyPor.TextChanged
        If txtTipoCambio.Text.Trim.Length > 0 And CDec(txtTipoCambio.Text) > 0 Then
            If IsNumeric(txtTipoCambio.Text) And CDec(txtTipoCambio.Text) > 0 Then
                CalculoMayor()
                txtmyPorME.Text = txtmyPor.Text 'Math.Round(CDec(txtmyPor.Text) / CDec(txtTipoCambio.Text), 2)
            End If
        End If
    End Sub

    Private Sub txtmyImporteMN_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtmyImporteMN.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtmyImporteMN.Text = CDec(txtmyImporteMN.Text).ToString("N2")
            txtmyVFMN.Focus()
            txtmyVFMN.Select(0, txtmyVFMN.Text.Length)
        End If
    End Sub

    Private Sub txtmyImporteMN_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtmyImporteMN.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtmyImporteMN_LostFocus(sender As Object, e As System.EventArgs) Handles txtmyImporteMN.LostFocus
        If IsNumeric(txtmyImporteMN.Text) Then
            txtmyImporteMN.Text = CDec(txtmyImporteMN.Text).ToString("N2")
        End If
    End Sub

    Private Sub txtmyImporteMN_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtmyImporteMN.MouseClick
        txtmyImporteMN.Select(0, txtmyImporteMN.Text.Length)
    End Sub

    Private Sub txtmyImporteMN_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtmyImporteMN.TextChanged

    End Sub

    Private Sub txtmyVFMN_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtmyVFMN.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtmyVFMN.Text = CDec(txtmyVFMN.Text).ToString("N2")
            txtgmyPor.Focus()
            txtgmyPor.Select(0, txtgmyPor.Text.Length)
        End If
    End Sub

    Private Sub txtmyVFMN_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtmyVFMN.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtmyVFMN_LostFocus(sender As Object, e As System.EventArgs) Handles txtmyVFMN.LostFocus
        If IsNumeric(txtmyVFMN.Text) Then
            txtmyVFMN.Text = CDec(txtmyVFMN.Text).ToString("N2")
        End If
    End Sub

    Private Sub txtmyVFMN_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtmyVFMN.MouseClick
        txtmyVFMN.Select(0, txtmyVFMN.Text.Length)
    End Sub

    Private Sub txtmyVFMN_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtmyVFMN.TextChanged

    End Sub

    Private Sub txtgmyPor_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtgmyPor.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            If Not txtgmyPor.Text.Trim.Length > 0 Then
                txtgmyPor.Text = "0.00"
            Else
                txtgmyPor.Text = CDec(txtgmyPor.Text).ToString("N2")
                txtgmyImporteMN.Focus()
                txtgmyImporteMN.Select(0, txtgmyImporteMN.Text.Length)
            End If
        End If
    End Sub

    Private Sub txtgmyPor_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtgmyPor.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtgmyPor_LostFocus(sender As Object, e As System.EventArgs) Handles txtgmyPor.LostFocus
        If IsNumeric(txtgmyPor.Text) Then
            txtgmyPor.Text = CDec(txtgmyPor.Text).ToString("N2")
        End If
    End Sub

    Private Sub txtgmyPor_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtgmyPor.MouseClick
        txtgmyPor.Select(0, txtgmyPor.Text.Length)
    End Sub

    Private Sub txtgmyPor_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtgmyPor.TextChanged
        If txtTipoCambio.Text.Trim.Length > 0 And CDec(txtTipoCambio.Text) > 0 Then
            If IsNumeric(txtTipoCambio.Text) And CDec(txtTipoCambio.Text) > 0 Then
                CalculoGranMayor()
                txtgmyPorME.Text = txtgmyPor.Text 'Math.Round(CDec(txtgmyPor.Text) / CDec(txtTipoCambio.Text), 2)
            End If
        End If
    End Sub

    Private Sub txtgmyImporteMN_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtgmyImporteMN.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtgmyImporteMN.Text = CDec(txtgmyImporteMN.Text).ToString("N2")
            txtgmyVFMN.Focus()
            txtgmyVFMN.Select(0, txtgmyVFMN.Text.Length)
        End If
    End Sub

    Private Sub txtgmyImporteMN_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtgmyImporteMN.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtgmyImporteMN_LostFocus(sender As Object, e As System.EventArgs) Handles txtgmyImporteMN.LostFocus
        If IsNumeric(txtgmyImporteMN.Text) Then
            txtgmyImporteMN.Text = CDec(txtgmyImporteMN.Text).ToString("N2")
        End If
    End Sub

    Private Sub txtgmyImporteMN_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtgmyImporteMN.MouseClick
        txtgmyImporteMN.Select(0, txtgmyImporteMN.Text.Length)
    End Sub

    Private Sub txtgmyImporteMN_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtgmyImporteMN.TextChanged

    End Sub

    Private Sub txtgmyVFMN_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtgmyVFMN.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtgmyVFMN.Text = CDec(txtgmyVFMN.Text).ToString("N2")
            txtUtilsinIGVME.Focus()
            txtUtilsinIGVME.Select(0, txtgmyVFMN.Text.Length)
        End If
    End Sub

    Private Sub txtgmyVFMN_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtgmyVFMN.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtgmyVFMN_LostFocus(sender As Object, e As System.EventArgs) Handles txtgmyVFMN.LostFocus
        If IsNumeric(txtgmyVFMN.Text) Then
            txtgmyVFMN.Text = CDec(txtgmyVFMN.Text).ToString("N2")
        End If
    End Sub

    Private Sub txtgmyVFMN_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtgmyVFMN.MouseClick
        txtgmyVFMN.Select(0, txtgmyVFMN.Text.Length)
    End Sub

    Private Sub txtgmyVFMN_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtgmyVFMN.TextChanged

    End Sub

    Private Sub txtUtilsinIGVME_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtUtilsinIGVME.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtUtilsinIGVME_LostFocus(sender As Object, e As System.EventArgs) Handles txtUtilsinIGVME.LostFocus
        If IsNumeric(txtUtilsinIGVME.Text) Then
            txtUtilsinIGVME.Text = CDec(txtUtilsinIGVME.Text).ToString("N2")
        End If
    End Sub

    Private Sub txtUtilsinIGVME_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtUtilsinIGVME.MouseClick
        txtUtilsinIGVME.Select(0, txtUtilsinIGVME.Text.Length)
    End Sub

    Private Sub txtUtilsinIGVME_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtUtilsinIGVME.TextChanged

    End Sub

    Private Sub txtValorVentaME_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtValorVentaME.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtValorVentaME_LostFocus(sender As Object, e As System.EventArgs) Handles txtValorVentaME.LostFocus
        If IsNumeric(txtValorVentaME.Text) Then
            txtValorVentaME.Text = CDec(txtValorVentaME.Text).ToString("N2")
        End If
    End Sub

    Private Sub txtValorVentaME_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtValorVentaME.MouseClick
        txtValorVentaME.Select(0, txtValorVentaME.Text.Length)
    End Sub

    Private Sub txtValorVentaME_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtValorVentaME.TextChanged

    End Sub

    Private Sub txtIgvME_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtIgvME.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtIgvME_LostFocus(sender As Object, e As System.EventArgs) Handles txtIgvME.LostFocus
        If IsNumeric(txtIgvME.Text) Then
            txtIgvME.Text = CDec(txtIgvME.Text).ToString("N2")
        End If
    End Sub

    Private Sub txtIgvME_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtIgvME.MouseClick
        txtIgvME.Select(0, txtIgvME.Text.Length)
    End Sub

    Private Sub txtIgvME_RegionChanged(sender As Object, e As System.EventArgs) Handles txtIgvME.RegionChanged

    End Sub

    Private Sub txtIgvME_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtIgvME.TextChanged

    End Sub

    Private Sub txtIscME_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtIscME.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtIscME_LostFocus(sender As Object, e As System.EventArgs) Handles txtIscME.LostFocus
        If IsNumeric(txtIscME.Text) Then
            txtIscME.Text = CDec(txtIscME.Text).ToString("N2")
        End If
    End Sub

    Private Sub txtIscME_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtIscME.MouseClick
        txtIscME.Select(0, txtIscME.Text.Length)
    End Sub

    Private Sub txtIscME_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtIscME.TextChanged

    End Sub

    Private Sub txtOtcME_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtOtcME.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtOtcME_LostFocus(sender As Object, e As System.EventArgs) Handles txtOtcME.LostFocus
        If IsNumeric(txtOtcME.Text) Then
            txtOtcME.Text = CDec(txtOtcME.Text).ToString("N2")
        End If
    End Sub

    Private Sub txtOtcME_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtOtcME.MouseClick
        txtOtcME.Select(0, txtOtcME.Text.Length)
    End Sub

    Private Sub txtOtcME_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtOtcME.TextChanged

    End Sub

    Private Sub txtPrecioVentaME_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrecioVentaME.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtPrecioVentaME_LostFocus(sender As Object, e As System.EventArgs) Handles txtPrecioVentaME.LostFocus
        If IsNumeric(txtPrecioVentaME.Text) Then
            txtPrecioVentaME.Text = CDec(txtPrecioVentaME.Text).ToString("N2")
        End If
    End Sub

    Private Sub txtPrecioVentaME_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtPrecioVentaME.MouseClick
        txtPrecioVentaME.Select(0, txtPrecioVentaME.Text.Length)
    End Sub

    Private Sub txtPrecioVentaME_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPrecioVentaME.TextChanged

    End Sub

    Private Sub txtmnPorME_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtmnPorME.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtmnPorME_LostFocus(sender As Object, e As System.EventArgs) Handles txtmnPorME.LostFocus
        If IsNumeric(txtmnPorME.Text) Then
            txtmnPorME.Text = CDec(txtmnPorME.Text).ToString("N2")
        End If
    End Sub

    Private Sub txtmnPorME_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtmnPorME.MouseClick
        txtmnPorME.Select(0, txtmnPorME.Text.Length)
    End Sub

    Private Sub txtmnPorME_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtmnPorME.TextChanged
        CalculoMenorME()
    End Sub

    Private Sub txtmnImporteME_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtmnImporteME.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtmnImporteME_LostFocus(sender As Object, e As System.EventArgs) Handles txtmnImporteME.LostFocus
        If IsNumeric(txtmnImporteME.Text) Then
            txtmnImporteME.Text = CDec(txtmnImporteME.Text).ToString("N2")
        End If
    End Sub

    Private Sub txtmnImporteME_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtmnImporteME.MouseClick
        txtmnImporteME.Select(0, txtmnImporteME.Text.Length)
    End Sub

    Private Sub txtmnImporteME_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtmnImporteME.TextChanged

    End Sub

    Private Sub txtmnVFME_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtmnVFME.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtmnVFME_LostFocus(sender As Object, e As System.EventArgs) Handles txtmnVFME.LostFocus
        If IsNumeric(txtmnVFME.Text) Then
            txtmnVFME.Text = CDec(txtmnVFME.Text).ToString("N2")
        End If
    End Sub

    Private Sub txtmnVFME_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtmnVFME.MouseClick
        txtmnVFME.Select(0, txtmnVFME.Text.Length)
    End Sub

    Private Sub txtmnVFME_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtmnVFME.TextChanged

    End Sub

    Private Sub txtmyPorME_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtmyPorME.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtmyPorME_LostFocus(sender As Object, e As System.EventArgs) Handles txtmyPorME.LostFocus
        If IsNumeric(txtmyPorME.Text) Then
            txtmyPorME.Text = CDec(txtmyPorME.Text).ToString("N2")
        End If
    End Sub

    Private Sub txtmyPorME_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtmyPorME.MouseClick
        txtmyPorME.Select(0, txtmyPorME.Text.Length)
    End Sub

    Private Sub txtmyPorME_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtmyPorME.TextChanged
        CalculoMayorEX()
    End Sub

    Private Sub txtmyImporteME_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtmyImporteME.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtmyImporteME_LostFocus(sender As Object, e As System.EventArgs) Handles txtmyImporteME.LostFocus
        If IsNumeric(txtmyImporteME.Text) Then
            txtmyImporteME.Text = CDec(txtmyImporteME.Text).ToString("N2")
        End If
    End Sub

    Private Sub txtmyImporteME_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtmyImporteME.MouseClick
        txtmyImporteME.Select(0, txtmyImporteME.Text.Length)
    End Sub

    Private Sub txtmyImporteME_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtmyImporteME.TextChanged

    End Sub

    Private Sub txtmyVFME_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtmyVFME.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtmyVFME_LostFocus(sender As Object, e As System.EventArgs) Handles txtmyVFME.LostFocus
        If IsNumeric(txtmyVFME.Text) Then
            txtmyVFME.Text = CDec(txtmyVFME.Text).ToString("N2")
        End If
    End Sub

    Private Sub txtmyVFME_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtmyVFME.MouseClick
        txtmyVFME.Select(0, txtmyVFME.Text.Length)
    End Sub

    Private Sub txtmyVFME_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtmyVFME.TextChanged

    End Sub

    Private Sub txtgmyPorME_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtgmyPorME.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtgmyPorME_LostFocus(sender As Object, e As System.EventArgs) Handles txtgmyPorME.LostFocus
        If IsNumeric(txtgmyPorME.Text) Then
            txtgmyPorME.Text = CDec(txtgmyPorME.Text).ToString("N2")
        End If
    End Sub

    Private Sub txtgmyPorME_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtgmyPorME.MouseClick
        txtgmyPorME.Select(0, txtgmyPorME.Text.Length)
    End Sub

    Private Sub txtgmyPorME_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtgmyPorME.TextChanged
        CalculoGranMayorME()
    End Sub

    Private Sub txtgmyImporteME_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtgmyImporteME.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtgmyImporteME_LostFocus(sender As Object, e As System.EventArgs) Handles txtgmyImporteME.LostFocus
        If IsNumeric(txtgmyImporteME.Text) Then
            txtgmyImporteME.Text = CDec(txtgmyImporteME.Text).ToString("N2")
        End If
    End Sub

    Private Sub txtgmyImporteME_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtgmyImporteME.MouseClick
        txtgmyImporteME.Select(0, txtgmyImporteME.Text.Length)
    End Sub

    Private Sub txtgmyImporteME_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtgmyImporteME.TextChanged

    End Sub

    Private Sub txtgmyVFME_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtgmyVFME.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtgmyVFME_LostFocus(sender As Object, e As System.EventArgs) Handles txtgmyVFME.LostFocus
        If IsNumeric(txtgmyVFME.Text) Then
            txtgmyVFME.Text = CDec(txtgmyVFME.Text).ToString("N2")
        End If
    End Sub

    Private Sub txtgmyVFME_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtgmyVFME.MouseClick
        txtgmyVFME.Select(0, txtgmyVFME.Text.Length)
    End Sub

    Private Sub txtFechaRegistro_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtFechaRegistro.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtTipoCambio.Focus()
            txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
        End If
    End Sub

    Private Sub txtFechaRegistro_ValueChanged(sender As System.Object, e As System.EventArgs) Handles txtFechaRegistro.ValueChanged

    End Sub

    Private Sub btnConsulta_Click(sender As System.Object, e As System.EventArgs)
        'With frmConsultaPM
        '    .CargarPM(CEmpresa, CEstablecimiento, frmListaPreciosExistencias.cboalmacen.SelectedValue,
        '         lbltipoEx.Text, lblDestino.Text, frmListaPreciosExistencias.lsvListado.SelectedItems(0).SubItems(5).Text,
        '         lblPresentacion.Text, lblUnidad.Text)
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        'End With
    End Sub

    Private Sub nudMenor_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles nudMenor.MouseClick
        nudMenor.Select(0, nudMenor.Text.Length)
    End Sub

    Private Sub nudMenor_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudMenor.ValueChanged

    End Sub

    Private Sub nudMayor_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles nudMayor.MouseClick
        nudMayor.Select(0, nudMayor.Text.Length)
    End Sub

    Private Sub nudMayor_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudMayor.ValueChanged

    End Sub

    Private Sub nudGMayor_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles nudGMayor.MouseClick
        nudGMayor.Select(0, nudGMayor.Text.Length)
    End Sub

    Private Sub nudGMayor_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudGMayor.ValueChanged

    End Sub

    Private Sub GuardarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles GuardarToolStripButton.Click
        If txtTipoCambio.Text > 0 Then

            If nudUtilidadMN.Value > 0 Then

                If Not IsDate(txtFechaRegistro.Text) Then
                    MsgBox("Ingrese un formato válido.", MsgBoxStyle.Information, "Atención.!")
                    txtFechaRegistro.Focus()
                    '      txtFechaRegistro.Select(0, txtFechaRegistro.Text.Length)
                Else
                    Grabar()
                End If


            Else
                lblEstado.Text = "Ingrese utilidad"
                lblEstado.Visible = True
                Timer1.Enabled = True
                TiempoEjecutar(5)
            End If

        Else

            lblEstado.Text = "Ingrese Tipo de cambio"
            lblEstado.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(5)
        End If

    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        Dispose()
    End Sub
End Class