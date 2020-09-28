Imports Helios.Planilla.Business.Entity
Imports Helios.Planilla.WCFService.ServiceAccess

Public Class frmNuevoConceptoPlanilla

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        LoadCombos()
    End Sub



#Region "Métodos"
    Private Sub LoadCombos()
        Dim servicio As New Concepto
        Dim Listados As New TablaDetalleSA
        Dim lstMoneda = Listados.TablaDetalleSelxTabla(New TablaDetalle With {.IDTabla = 1022})
        Dim lstTipoCalculo = Listados.TablaDetalleSelxTabla(New TablaDetalle With {.IDTabla = 1019})
        Dim lstTipoConcepto = Listados.TablaDetalleSelxTabla(New TablaDetalle With {.IDTabla = 1020})
        Dim lstTipoPlanilla = Listados.TablaDetalleSelxTabla(New TablaDetalle With {.IDTabla = 1021})

        Label2.Text = "Código formula"
        '  Dim cargoSA As New Helios.Planilla.WCFService.ServiceAccess.CargosSA
        cboTipoPlanilla.DataSource = lstTipoPlanilla 'cargoSA.CargosSelAll()
        cboTipoPlanilla.ValueMember = "IDTablaDetalle"
        cboTipoPlanilla.DisplayMember = "DescripcionLarga"

        cboMoneda.DataSource = lstMoneda
        cboMoneda.ValueMember = "IDTablaDetalle"
        cboMoneda.DisplayMember = "DescripcionLarga"
        cboMoneda.SelectedValue = 1

        cboTipoCalculo.DataSource = lstTipoCalculo
        cboTipoCalculo.ValueMember = "IDTablaDetalle"
        cboTipoCalculo.DisplayMember = "DescripcionLarga"

        cboTipoConcepto.DataSource = lstTipoConcepto
        cboTipoConcepto.ValueMember = "IDTablaDetalle"
        cboTipoConcepto.DisplayMember = "DescripcionLarga"
    End Sub

    Public Function GrabarValidaControles() As Boolean
        If txtDescripcionLarga.Text.Trim.Length <= 0 Then
            MessageBox.Show("Debe ingresar una descripción del concepto!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If txtAbreviatura.Text.Trim.Length <= 0 Then
            MessageBox.Show("Debe ingresar una abreviatura válida!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If cboTipoCalculo.Text = "FORMULA" Then
            If txtFormula.Text.Trim.Length <= 0 Then
                MessageBox.Show("Debe ingresar una formula válida!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

        ElseIf cboTipoCalculo.Text = "IMPORTE" Then
            If txtValorTipoCalculo.Text.Trim.Length <= 0 Then
                MessageBox.Show("Debe ingresar un valor válido!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            If Not IsNumeric(txtValorTipoCalculo.Text) Then
                MessageBox.Show("Debe ingresar un valor tipo numérico!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            If txtValorTipoCalculo.DoubleValue <= 0 Then
                MessageBox.Show("Debe ingresar un valor mayor a cero!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
        End If

        Return True
    End Function

    Public Sub Grabar()
        Dim servicio As New ConceptoSA
        Dim objConcepto As New Concepto

        With objConcepto
            '.IDConcepto = 1
            .IDContable = 1 ' txtIDContable.Text
            .IDSunat = 1 ' txtIDSunat.Text
            .Orden = txtOrden.Value
            .DescripcionCorta = txtAbreviatura.Text.Trim
            .DescripcionLarga = txtDescripcionLarga.Text.Trim
            .Moneda = cboMoneda.SelectedValue
            .TipoPlanilla = String.Format("{0:00}", cboTipoPlanilla.SelectedValue)
            .TipoCalculo = String.Format("{0:00}", cboTipoCalculo.SelectedValue)
            .TipoConcepto = cboTipoConcepto.SelectedValue

            If cboTipoCalculo.Text = "FORMULA" Then
                .Formula = txtFormula.Text.Trim
                .ValorCalculo = 0

            ElseIf cboTipoCalculo.Text = "IMPORTE" Then
                .Formula = Nothing ' txtFormula.Text.Trim
                .ValorCalculo = CDec(txtValorTipoCalculo.Text)
            End If


            .Action = BaseBE.EntityAction.INSERT
            .Activo = True
        End With
        servicio.ConceptoSave(objConcepto, UserManager.TransactionData)
        Me.Close()
    End Sub
#End Region



    Private Sub frmNuevoConceptoPlanilla_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        If GrabarValidaControles() = True Then
            Grabar()
        End If
    End Sub

    Private Sub btnIF_Click(sender As Object, e As EventArgs) Handles btnIF.Click
        txtFormula.Text = txtFormula.Text.Trim & "IF"
    End Sub

    Private Sub btnVariables_Click(sender As Object, e As EventArgs) Handles btnVariables.Click
        Dim frm As New frmConceptoslocVariable
        frm.StartPosition = FormStartPosition.CenterParent
        frm.ShowDialog(Me)
        If Not IsNothing(SelConcepto) Then
            txtFormula.Text = txtFormula.Text.Trim + SelConcepto.Trim
        End If
    End Sub

    Private Sub btnVarSistema_Click(sender As Object, e As EventArgs) Handles btnVarSistema.Click
        Dim frm As New FrmConceptosLocSistema
        frm.StartPosition = FormStartPosition.CenterParent
        frm.ShowDialog(Me)
        If Not IsNothing(SelConcepto) Then
            txtFormula.Text = txtFormula.Text.Trim + SelConcepto.Trim
        End If
    End Sub

    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        Try
            Dim largo As Integer
            If txtFormula.Text <> "" Then
                largo = txtFormula.Text.Length
                txtFormula.Text = Mid(txtFormula.Text, 1, largo - 1)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtFormula.Clear()
    End Sub

    Private Sub btnMas_Click(sender As Object, e As EventArgs) Handles btnMas.Click
        txtFormula.Text = txtFormula.Text.Trim & "+"
    End Sub

    Private Sub btnMenos_Click(sender As Object, e As EventArgs) Handles btnMenos.Click
        txtFormula.Text = txtFormula.Text.Trim & "-"
    End Sub

    Private Sub btnMultiplicarbtnMultiplicar_Click(sender As Object, e As EventArgs) Handles btnMultiplicar.Click
        txtFormula.Text = txtFormula.Text.Trim & "*"
    End Sub

    Private Sub btnDividir_Click(sender As Object, e As EventArgs) Handles btnDividir.Click
        txtFormula.Text = txtFormula.Text.Trim & "/"
    End Sub

    Private Sub btnParentizd_Click(sender As Object, e As EventArgs) Handles btnParentizd.Click
        txtFormula.Text = txtFormula.Text.Trim & "("
    End Sub

    Private Sub btnParentder_Click(sender As Object, e As EventArgs) Handles btnParentder.Click
        txtFormula.Text = txtFormula.Text.Trim & ")"
    End Sub

    Private Sub btnMenor_Click(sender As Object, e As EventArgs) Handles btnMenor.Click
        txtFormula.Text = txtFormula.Text.Trim & "<"
    End Sub

    Private Sub btnMayor_Click(sender As Object, e As EventArgs) Handles btnMayor.Click
        txtFormula.Text = txtFormula.Text.Trim & ">"
    End Sub

    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        txtFormula.Text = txtFormula.Text.Trim & "1"
    End Sub

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        txtFormula.Text = txtFormula.Text.Trim & "2"
    End Sub

    Private Sub btn3_Click(sender As Object, e As EventArgs) Handles btn3.Click
        txtFormula.Text = txtFormula.Text.Trim & "3"
    End Sub

    Private Sub btn4_Click(sender As Object, e As EventArgs) Handles btn4.Click
        txtFormula.Text = txtFormula.Text.Trim & "4"
    End Sub

    Private Sub btn5_Click(sender As Object, e As EventArgs) Handles btn5.Click
        txtFormula.Text = txtFormula.Text.Trim & "5"
    End Sub

    Private Sub btn6_Click(sender As Object, e As EventArgs) Handles btn6.Click
        txtFormula.Text = txtFormula.Text.Trim & "6"
    End Sub

    Private Sub btn7_Click(sender As Object, e As EventArgs) Handles btn7.Click
        txtFormula.Text = txtFormula.Text.Trim & "7"
    End Sub

    Private Sub btn8_Click(sender As Object, e As EventArgs) Handles btn8.Click
        txtFormula.Text = txtFormula.Text.Trim & "8"
    End Sub

    Private Sub btn9_Click(sender As Object, e As EventArgs) Handles btn9.Click
        txtFormula.Text = txtFormula.Text.Trim & "9"
    End Sub

    Private Sub btn0_Click(sender As Object, e As EventArgs) Handles btn0.Click
        txtFormula.Text = txtFormula.Text.Trim & "0"
    End Sub

    Private Sub btnDecimal_Click(sender As Object, e As EventArgs) Handles btnDecimal.Click
        txtFormula.Text = txtFormula.Text.Trim & "."
    End Sub

    Private Sub cboTipoCalculo_Click(sender As Object, e As EventArgs) Handles cboTipoCalculo.Click

    End Sub

    Private Sub cboTipoCalculo_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboTipoCalculo.SelectedValueChanged
        If cboTipoCalculo.Text = "FORMULA" Then
            txtValorTipoCalculo.Enabled = False
            txtValorTipoCalculo.DoubleValue = 0
            GradientPanel2.Visible = True
        ElseIf cboTipoCalculo.Text = "IMPORTE" Then
            txtValorTipoCalculo.Enabled = True
            txtValorTipoCalculo.DoubleValue = 0
            GradientPanel2.Visible = False
        End If
    End Sub
End Class