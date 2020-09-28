Imports Helios.Cont.Business.Entity.BaseBE
Imports Helios.General
Imports Helios.Cont.Business.Entity

Imports Helios.Cont.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping


Public Class frmAsignarNumeroGuia
    Inherits frmMaster

    Public Property Movimiento As String

    Public Property idDocumento As Integer
    Public Property idPadre As Integer

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

#Region "Métodos"

    Sub grabarNumeroGuia()

        Dim objdocumento As New documentoGuia
        Dim objdocumentoSA As New DocumentoGuiaSA

        With objdocumento
            .idDocumento = idDocumento
            .numeroDoc = txtNumero.Text.Trim
            .serie = txtSerie.Text.Trim
            .estadoGuia = "DC"
            .idEntidadTransporte = idPadre
        End With

        objdocumentoSA.updateDocumentoTransferencia(objdocumento)

    End Sub

#End Region

    Private Sub frmDistribucionMasiva_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmDistribucionMasiva_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtFecha.Value = New DateTime(AnioGeneral, MesGeneral, DateTime.Now.Date.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0)
    End Sub

    Private Sub cboEstable_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub cboEstable_SelectedIndexChanged(sender As Object, e As EventArgs)
        'Me.Cursor = Cursors.WaitCursor
        'Dim codEstable = cboEstable.SelectedValue
        'If IsNumeric(codEstable) Then
        '    Dim almacenSA As New almacenSA
        '    cboAlmacen.DisplayMember = "descripcionAlmacen"
        '    cboAlmacen.ValueMember = "idAlmacen"
        '    cboAlmacen.DataSource = almacenSA.GetListar_almacenExceptAV(codEstable)
        'End If
        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Dispose()
    End Sub

    Private Sub ButtonAdv15_Click(sender As Object, e As EventArgs) Handles ButtonAdv15.Click

        Try

            If Not txtSerie.Text.Trim.Length > 0 Then
                MessageBox.Show("Ingrese la serie de la guía", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtSerie.Select()
                txtSerie.Focus()
                Exit Sub
            End If

            If Not txtNumero.Text.Trim.Length > 0 Then
                MessageBox.Show("Ingrese el número de guía", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtNumero.Select()
                txtNumero.Focus()
                Exit Sub
            End If
            grabarNumeroGuia()
            Dispose()


        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Me.Tag = Nothing
        End Try
    End Sub

    Private Sub txtSerie_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSerie.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                txtNumero.Select()
            End If
        Catch ex As Exception
            txtSerie.Clear()
        End Try

    End Sub

    Private Sub txtSerie_LostFocus(sender As Object, e As EventArgs) Handles txtSerie.LostFocus
        Try
            If txtSerie.Text.Trim.Length > 0 Then
                '  If chFormato.Checked = True Then
                txtSerie.Text = String.Format("{0:00000}", Convert.ToInt32(txtSerie.Text))
                'End If
            End If

        Catch ex As Exception

            If IsNumeric(Microsoft.VisualBasic.Mid(Trim(txtSerie.Text), 2, 1)) = True Then

                If IsNumeric(Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 1)) = True Then

                    If Not IsNumeric(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1)) = True Then

                        If Len(txtSerie.Text) <= 2 Then

                            txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + "000" + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 1))

                        ElseIf Len(txtSerie.Text) <= 3 Then

                            txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + "00" + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 2))

                        ElseIf Len(txtSerie.Text) <= 4 Then

                            txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + "0" + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 3))

                        ElseIf Len(txtSerie.Text) <= 5 Then

                            txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 4))

                        End If
                    End If
                Else

                    txtSerie.Select()
                    txtSerie.Focus()
                    txtSerie.Clear()
                    MessageBox.Show("INGRESE PRIMERO SOLO UNA LETRA SEGUIDO DE UN NUMERO")

                End If

            Else

                txtSerie.Select()
                txtSerie.Focus()
                txtSerie.Clear()
                MessageBox.Show("INGRESE PRIMERO SOLO UNA LETRA SEGUIDO DE UN NUMERO")

            End If

        End Try
    End Sub

    Private Sub txtSerie_TextChanged(sender As Object, e As EventArgs) Handles txtSerie.TextChanged

    End Sub

    Private Sub txtNumero_LostFocus(sender As Object, e As EventArgs) Handles txtNumero.LostFocus
        Try
            If txtNumero.Text.Trim.Length > 0 Then
                '    If chFormato.Checked = True Then
                If txtNumero.Text.Contains(".") Then
                    txtNumero.Text.Replace(".", "")
                End If

                txtNumero.Text = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumero.Text))

                'End If
            End If
        Catch ex As Exception
            txtNumero.Select()
            txtNumero.Focus()
            txtNumero.Clear()
        End Try

    End Sub

    Private Sub txtNumero_TextChanged(sender As Object, e As EventArgs) Handles txtNumero.TextChanged

    End Sub
End Class