Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmMenuDistribucion
#Region "Métodos"


    Private Sub load_almacen()
        Dim objalmacen As New Almacensa
        Dim objTablas As New tablaDetalleSA
        Dim dt, dtRecaudo As New DataTable()
        Try
            dt.Columns.Add("codigo")
            dt.Columns.Add("descripcion")
            dt.Rows.Add("", "")
            For Each i As almacen In objalmacen.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
                dt.Rows.Add(i.idAlmacen, i.descripcionAlmacen)
            Next
            cboAlmacen.DisplayMember = "descripcion"
            cboAlmacen.ValueMember = "codigo"
            cboAlmacen.DataSource = dt
            cboAlmacen.Refresh()

            cboComprobante.DisplayMember = "descripcion"
            cboComprobante.ValueMember = "codigoDetalle"
            cboComprobante.DataSource = objTablas.GetListaTablaDetalle(10, "1")
            cboComprobante.SelectedValue = "99"


            cboDestino.DisplayMember = "descripcion"
            cboDestino.ValueMember = "codigoDetalle"
            cboDestino.DataSource = objTablas.GetListaTablaDetalle(101, "1")
        Catch ex As Exception
            MsgBox("No se puedo cargar la información para los combos" & vbCrLf & ex.Message)
        End Try
    End Sub

    Public Sub ObtenerEstablecimientos()
        Dim objListas As New establecimientoSA
        Dim dtEstab As New DataTable()
        Try

            dtEstab.Columns.Add("idCentroCosto")
            dtEstab.Columns.Add("Empresa")
            dtEstab.Columns.Add("Nombre")
            dtEstab.Columns.Add("Tipo")
            dtEstab.Rows.Add("", "", "", "")
            For Each i In objListas.ObtenerListaEstablecimientos(Gempresas.IdEmpresaRuc)
                dtEstab.Rows.Add(i.idCentroCosto, i.idEmpresa, i.nombre, i.TipoEstab)
            Next
            cboEstablecimiento.DataSource = dtEstab
            cboEstablecimiento.DisplayMember = "Nombre"
            cboEstablecimiento.ValueMember = "idCentroCosto"
            cboEstablecimiento.Refresh()
        Catch ex As Exception

        End Try
    End Sub
#End Region

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dispose()
    End Sub

    Private Sub frmMenuDistribucion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        exMenu.Expand()
    End Sub

    Private Sub cboEstablecimiento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEstablecimiento.SelectedIndexChanged
        If cboEstablecimiento.SelectedIndex > 0 Then
            load_almacen()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim valDate As String = String.Concat(txtDia.Text, "/", txtMes.Text, "/", txtAnio.Text)
        If IsDate(valDate) Then
            If Tag = 1 Then
                'With frmEntradaItems
                '    If chAplicarAll.Checked = False Then
                '        .dgvDistribucion.Item(0, .dgvDistribucion.CurrentRow.Index).Value = cboEstablecimiento.SelectedValue
                '        .dgvDistribucion.Item(1, .dgvDistribucion.CurrentRow.Index).Value = cboAlmacen.SelectedValue
                '        .dgvDistribucion.Item(2, .dgvDistribucion.CurrentRow.Index).Value = cboEstablecimiento.Text
                '        .dgvDistribucion.Item(3, .dgvDistribucion.CurrentRow.Index).Value = cboAlmacen.Text
                '        .dgvDistribucion.Item(5, .dgvDistribucion.CurrentRow.Index).Value = CDate(valDate).ToShortDateString
                '        .dgvDistribucion.Item(6, .dgvDistribucion.CurrentRow.Index).Value = cboComprobante.SelectedValue
                '        .dgvDistribucion.Item(7, .dgvDistribucion.CurrentRow.Index).Value = txtSerie.Text
                '        .dgvDistribucion.Item(8, .dgvDistribucion.CurrentRow.Index).Value = txtNumero.Text
                '    Else
                '        For x = 0 To .dgvDistribucion.Rows.Count - 1
                '            ' .dgvDistribucion.Rows(x).Cells(7).Value = String.Empty
                '            ' .dgvDistribucion.Rows(x).Cells(8).Value = String.Empty
                '            .dgvDistribucion.Rows(x).Cells(0).Value = cboEstablecimiento.SelectedValue
                '            .dgvDistribucion.Rows(x).Cells(1).Value = cboAlmacen.SelectedValue
                '            .dgvDistribucion.Rows(x).Cells(2).Value = cboEstablecimiento.Text
                '            .dgvDistribucion.Rows(x).Cells(3).Value = cboAlmacen.Text
                '            .dgvDistribucion.Rows(x).Cells(5).Value = CDate(valDate).ToShortDateString
                '            .dgvDistribucion.Rows(x).Cells(6).Value = cboComprobante.SelectedValue
                '            .dgvDistribucion.Rows(x).Cells(7).Value = txtSerie.Text
                '            .dgvDistribucion.Rows(x).Cells(8).Value = txtNumero.Text
                '        Next x
                '    End If
                'End With
            ElseIf Tag = 2 Then
                With frmDistribucionMasiva
                    If chAplicarAll.Checked = False Then
                        .dgvDistribucion.Item(0, .dgvDistribucion.CurrentRow.Index).Value = cboEstablecimiento.SelectedValue
                        .dgvDistribucion.Item(1, .dgvDistribucion.CurrentRow.Index).Value = cboAlmacen.SelectedValue
                        .dgvDistribucion.Item(2, .dgvDistribucion.CurrentRow.Index).Value = cboEstablecimiento.Text
                        .dgvDistribucion.Item(3, .dgvDistribucion.CurrentRow.Index).Value = cboAlmacen.Text
                        .dgvDistribucion.Item(4, .dgvDistribucion.CurrentRow.Index).Value = cboDestino.SelectedValue
                        .dgvDistribucion.Item(5, .dgvDistribucion.CurrentRow.Index).Value = CDate(valDate).ToShortDateString
                        .dgvDistribucion.Item(6, .dgvDistribucion.CurrentRow.Index).Value = cboComprobante.SelectedValue
                        .dgvDistribucion.Item(7, .dgvDistribucion.CurrentRow.Index).Value = txtSerie.Text
                        .dgvDistribucion.Item(8, .dgvDistribucion.CurrentRow.Index).Value = txtNumero.Text
                    Else
                        For x = 0 To .dgvDistribucion.Rows.Count - 1
                            ' .dgvDistribucion.Rows(x).Cells(7).Value = String.Empty
                            ' .dgvDistribucion.Rows(x).Cells(8).Value = String.Empty
                            .dgvDistribucion.Rows(x).Cells(0).Value = cboEstablecimiento.SelectedValue
                            .dgvDistribucion.Rows(x).Cells(1).Value = cboAlmacen.SelectedValue
                            .dgvDistribucion.Rows(x).Cells(2).Value = cboEstablecimiento.Text
                            .dgvDistribucion.Rows(x).Cells(3).Value = cboAlmacen.Text
                            .dgvDistribucion.Rows(x).Cells(4).Value = cboDestino.SelectedValue
                            .dgvDistribucion.Rows(x).Cells(5).Value = CDate(valDate).ToShortDateString
                            .dgvDistribucion.Rows(x).Cells(6).Value = cboComprobante.SelectedValue
                            .dgvDistribucion.Rows(x).Cells(7).Value = txtSerie.Text
                            .dgvDistribucion.Rows(x).Cells(8).Value = txtNumero.Text
                        Next x
                    End If
                End With

            End If
        Else
            MsgBox("Dígite una fecha válida", MsgBoxStyle.Information, "Aviso del sistema.")
            txtDia.Focus()
            Exit Sub
        End If
        Dispose()
    End Sub

    Private Sub cboComprobante_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboComprobante.SelectedIndexChanged
        If String.IsNullOrEmpty(cboComprobante.ValueMember.ToString) Then
            Return
        Else
            If cboComprobante.Text = "" Then
                cboComprobante.Text = ""
                txtDoc.Text = ""
            Else
                txtDoc.Text = cboComprobante.SelectedValue.ToString
                txtSerie.Clear()
                txtNumero.Clear()
                Select Case txtDoc.Text
                    Case "01", "03", "07", "08", "23", "34", "35", "37", "55", "99"
                        txtSerie.MaxLength = 10
                        '     lblFechaDoc.Text = "Fc. Emisión:"
                    Case "04", "10"
                        txtSerie.MaxLength = 10
                        '    lblFechaDoc.Text = "Fc. Pago:"
                    Case "05", "06", "11", "13", "15", "16", "17",
                        "18", "21", "22", "24", "25", "26", "27", "28",
                        "29", "30", "32"
                        txtSerie.MaxLength = 10
                        '   lblFechaDoc.Text = "Fc. Emisión:"
                        ' SOLO NUMEROS
                    Case "10"
                        txtSerie.Enabled = False
                        '  lblFechaDoc.Text = "Fc. Pago:"
                    Case "12", "14", "36", "87", "88" ' maquina registradora
                        ' SOLO NUMEROS Y FALANUMERICOS
                        txtSerie.MaxLength = 10
                        ' lblFechaDoc.Text = "Fc. Emisión:"
                End Select
            End If
        End If
    End Sub

    Private Sub txtSerie_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtSerie.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            txtNumero.Focus()
            txtNumero.Select(0, txtNumero.Text.Length)
        End If
    End Sub

    Private Sub txtSerie_LostFocus(sender As Object, e As System.EventArgs) Handles txtSerie.LostFocus
        Try
            Select Case txtDoc.Text
                Case "01", "03", "04", "07", "08", "23", "34", "35", "37", "55", "99"
                    If Not txtSerie.Text = "" Or Not String.IsNullOrEmpty(txtSerie.Text) Then
                        If IsNumeric(txtSerie.Text) Then
                            txtSerie.Text = String.Format("{0:00000}", Convert.ToInt32(txtSerie.Text))
                        Else
                            MessageBox.Show("Serie inválida", "Ingresa otra vez", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            txtSerie.Clear()
                            txtSerie.Focus()
                            txtSerie.SelectAll()
                        End If
                    End If
                Case "05", "06", "11", "13", "15", "16", "17", "18", "21", "22", "24", "25", "26", "27", "28",
                    "29", "30", "32"

                    If Not txtSerie.Text = "" Or Not String.IsNullOrEmpty(txtSerie.Text) Then
                        If IsNumeric(txtSerie.Text) Then
                            '        txtSerie.Text = String.Format("{0:00000}", Convert.ToInt32(txtSerie.Text))
                        Else
                            MessageBox.Show("Serie inválida", "Ingresa otra vez", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            txtSerie.Clear()
                            txtSerie.Focus()
                            txtSerie.SelectAll()
                        End If
                    End If
                    ' SOLO NUMEROS
                Case "10"

                Case "12", "14", "36", "87", "88" ' maquina registradora
                    ' SOLO NUMEROS Y FALANUMERICOS

            End Select
        Catch ex As Exception
            MsgBox("Formato Incorrecto " + vbCrLf + ex.Message)
        End Try
    End Sub

    Private Sub txtNumero_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumero.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            e.Handled = True
            chAplicarAll.Focus()
        End If
    End Sub

    Private Sub txtNumero_LostFocus(sender As Object, e As System.EventArgs) Handles txtNumero.LostFocus
        Try
            Select Case txtDoc.Text
                Case "01", "03", "04", "07", "08", "23", "34", "35", "37", "55", "99"
                    If Not txtNumero.Text = "" Or Not String.IsNullOrEmpty(txtNumero.Text) Then
                        If IsNumeric(txtNumero.Text) Then
                            If txtNumero.Text.Length = 20 Then

                            Else
                                txtNumero.Text = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumero.Text))
                            End If
                        Else
                            MessageBox.Show("Número inválido", "Ingresa otra vez", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            txtNumero.Clear()
                            txtNumero.Focus()
                            txtNumero.SelectAll()
                        End If
                    End If
                Case "05", "06", "11", "13", "15", "16", "17", "18", "21", "22", "24", "25", "26", "27", "28",
                    "29", "30", "32"

                    If Not txtNumero.Text = "" Or Not String.IsNullOrEmpty(txtNumero.Text) Then
                        If IsNumeric(txtNumero.Text) Then
                            If txtNumero.Text.Length = 20 Then

                            Else
                                '     txtNumeroDoc.Text = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumeroDoc.Text))
                            End If
                        Else
                            MessageBox.Show("Número inválido", "Ingresa otra vez", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            txtNumero.Clear()
                            txtNumero.Focus()
                            txtNumero.SelectAll()
                        End If
                    End If
                    ' SOLO NUMEROS
                Case "10"
                    If Not txtNumero.Text = "" Or Not String.IsNullOrEmpty(txtNumero.Text) Then
                        If IsNumeric(txtNumero.Text) Then
                            If txtNumero.Text.Length = 20 Then

                            Else
                                '     txtNumeroDoc.Text = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumeroDoc.Text))
                            End If
                        Else
                            MessageBox.Show("Número inválido", "Ingresa otra vez", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            txtNumero.Clear()
                            txtNumero.Focus()
                            txtNumero.SelectAll()
                        End If
                    End If
                Case "12", "14", "36", "87", "88" ' maquina registradora
                    ' SOLO NUMEROS Y FALANUMERICOS

            End Select
        Catch ex As Exception
            MsgBox("Formato Incorrecto..!" + vbCrLf + ex.Message)
            txtNumero.Clear()
        End Try
    End Sub

    Private Sub txtSerie_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSerie.TextChanged

    End Sub

    Private Sub txtDia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDia.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            txtMes.Focus()
            txtMes.Select(0, txtMes.Text.Length)
        End If
    End Sub

    Private Sub txtDia_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDia.LostFocus
        txtDia.Text = String.Format("{0:00}", Convert.ToInt32(txtDia.Text))
    End Sub

    Private Sub txtDia_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtDia.MaskInputRejected

    End Sub

    Private Sub txtMes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMes.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            txtAnio.Focus()
            txtAnio.Select(0, txtAnio.Text.Length)
        End If
    End Sub

    Private Sub txtMes_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMes.LostFocus
        If txtMes.Text.Trim.Length > 0 Then
            txtMes.Text = String.Format("{0:00}", Convert.ToInt32(txtMes.Text))
        End If
    End Sub

    Private Sub txtAnio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAnio.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            txtSerie.Focus()
            txtSerie.Select(0, txtSerie.Text.Length)
        End If
    End Sub

    Private Sub txtAnio_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAnio.LostFocus
        '   txtAnio.Text = String.Format("{0:0000}", Convert.ToInt32(txtAnio.Text))
    End Sub

    Private Sub txtAnio_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtAnio.MaskInputRejected

    End Sub

    Private Sub txtDia_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtDia.MouseClick
        txtDia.Select(0, txtDia.Text.Length)
    End Sub

    Private Sub txtMes_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles txtMes.MaskInputRejected

    End Sub

    Private Sub txtMes_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtMes.MouseClick
        txtMes.Select(0, txtMes.Text.Length)
    End Sub

    Private Sub txtAnio_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtAnio.MouseClick
        txtAnio.Select(0, txtAnio.Text.Length)
    End Sub

    Private Sub txtNumero_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNumero.TextChanged

    End Sub
End Class