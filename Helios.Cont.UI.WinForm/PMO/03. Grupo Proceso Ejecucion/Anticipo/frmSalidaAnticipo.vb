Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.GridHelperClasses
Imports PopupControl
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Public Class frmSalidaAnticipo
    Inherits frmMaster
    Public ManipulacionEstado As String
    Public montoVenta As Decimal
    Dim idDocumentoPadre As Integer

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
       
    End Sub


#Region "metodo"

    Public Sub CargarEntidadesXtipo(strTipo As String, strBusqueda As String)
        Dim entidadSA As New entidadSA
        Try

            lsvProveedor.Items.Clear()
            For Each i As entidad In entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, TIPO_ENTIDAD.CLIENTE, strBusqueda)
                Dim n As New ListViewItem(i.idEntidad)
                n.SubItems.Add(i.nombreCompleto)
                n.SubItems.Add(i.cuentaAsiento)
                n.SubItems.Add(i.nrodoc)
                lsvProveedor.Items.Add(n)
            Next
        Catch ex As Exception

        End Try

    End Sub

    Public Sub UbicarAnticipoPorVoucher(idProveddor As Integer)
        Dim ventaDetalleSA As New documentoAnticipoSA
        Dim objventaDetalle As New documentoAnticipo
        objventaDetalle = ventaDetalleSA.UbicarAnticipoPorProveedorNroVoucher(idProveddor)
        If Not IsNothing(objventaDetalle) Then
            With objventaDetalle
                If ((.importeMN) > 0) Then
                    nudMonedaNacional.Value = CDec(.importeMN)
                    nudMonedaExtranjero.Value = CDec(.importeMN) / TmpTipoCambio
                    If ((.importeMN) < txtMontoCobrarMN.Value) Then
                        txtAnticipoMN.Value = (.importeMN)
                        txtAnticipoME.Value = CDec(txtAnticipoMN.Value / TmpTipoCambio)
                    Else
                        Dim c = CDec(.importeMN).ToString("N2")
                        DigitalGauge2.Value = c
                        txtAnticipoMN.Value = CDec(txtMontoCobrarMN.Value)
                        txtAnticipoME.Value = CDec(txtAnticipoMN.Value / TmpTipoCambio)
                    End If
                    txtAnticipoMN.Focus()
                    txtAnticipoMN.Select(0, txtAnticipoMN.Text)

                ElseIf (nudMonedaNacional.Value = 0) Then
                    lblEstado.Text = "no tiene ningun anticipo: " & txtProveedor.Text
                    DigitalGauge2.Value = "0.00"
                    txtAnticipoMN.Value = 0
                    txtAnticipoME.Value = 0
                    txtProveedor.Clear()
                    txtProveedor.Select()
                End If
            End With
        Else
            limpiarCajas()
            lblEstado.Text = "no existe anticipo del cliente " & txtProveedor.Text
            txtProveedor.Clear()
            txtProveedor.Select()
        End If

    End Sub

#End Region

    Private Sub txtProveedor_KeyDown(sender As Object, e As KeyEventArgs)

    End Sub

    Public Sub limpiarCajas()
        DigitalGauge2.Value = "0.00"
        nudMonedaNacional.Value = 0
        nudMonedaExtranjero.Value = 0
        txtAnticipoMN.Value = 0
        txtAnticipoME.Value = 0
        txtProveedor.Clear()
        txtProveedor.Select()
    End Sub

    Private Sub dropDownBtn_Click(sender As Object, e As EventArgs) Handles dropDownBtn.Click
        Me.popupControlContainer1.ParentControl = Me.txtProveedor
        Me.popupControlContainer1.ShowPopup(Point.Empty)
    End Sub

    Private Sub popupControlContainer1_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles popupControlContainer1.BeforePopup
        Me.popupControlContainer1.BackColor = Color.FromArgb(227, 241, 254)
    End Sub

    Private Sub popupControlContainer1_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles popupControlContainer1.CloseUp

        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvProveedor.SelectedItems.Count > 0 Then
                UbicarAnticipoPorVoucher(lsvProveedor.SelectedItems(0).SubItems(0).Text)
                Me.txtProveedor.Text = lsvProveedor.SelectedItems(0).SubItems(1).Text
                txtProveedor.Tag = lsvProveedor.SelectedItems(0).SubItems(0).Text
                txtProveedor.Select()
            End If
        End If
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
        End If
    End Sub

    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvProveedor.MouseDoubleClick
        If lsvProveedor.SelectedItems.Count > 0 Then
            Me.popupControlContainer1.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub txtAnticipoMN_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAnticipoMN.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If (CDec(txtAnticipoMN.Value <= txtMontoCobrarMN.Value)) Then
                txtAnticipoME.Value = CDec(txtAnticipoMN.Value / txtTipoCambio.Value)
                txtAnticipoMN.Select(0, txtAnticipoMN.Text.Length)
            Else
                txtAnticipoMN.Value = txtMontoCobrarMN.Value
                lblEstado.Text = "No debe exceder el monto a cobrar"
                txtAnticipoMN.Select(0, txtAnticipoMN.Text.Length)
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub frmSalidaAnticipo_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dispose()
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        If (txtAnticipoMN.Value > 0 And txtAnticipoMN.Value <= txtMontoCobrarMN.Value) Then
            Dim n As New RecuperarCarteras()
            Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
            datos.Clear()
            n.PMmn = txtAnticipoMN.Value
            n.PMme = CDec(txtAnticipoMN.Value / txtTipoCambio.Value)
            n.IdResponsable = txtProveedor.Tag
            datos.Add(n)
            Dispose()
        Else
            lblEstado.Text = "Ingreso incorrecto del voucher de anticipo"
            txtProveedor.Clear()
            txtProveedor.Select()
            txtAnticipoMN.Value = 0
            txtAnticipoME.Value = 0
        End If
    End Sub

    Private Sub frmSalidaAnticipo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtProveedor_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtProveedor_KeyDown1(sender As Object, e As KeyEventArgs) Handles txtProveedor.KeyDown
        If e.Alt Then
            If e.KeyCode = Keys.Down Then
                If Not Me.popupControlContainer1.IsShowing() Then
                    ' Let the popup align around the source textBox.
                    Me.popupControlContainer1.ParentControl = Me.txtProveedor
                    ' Passing Point.Empty will align it automatically around the above ParentControl.
                    Me.popupControlContainer1.ShowPopup(Point.Empty)

                    e.Handled = True
                End If
            End If
        End If
        '' Escape should close the popup.
        If e.KeyCode = Keys.Escape Then
            If Me.popupControlContainer1.IsShowing() Then
                Me.popupControlContainer1.HidePopup(PopupCloseType.Canceled)
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtProveedor.Text.Trim.Length > 0 Then
                Me.popupControlContainer1.ParentControl = Me.txtProveedor
                Me.popupControlContainer1.ShowPopup(Point.Empty)
                limpiarCajas()
                CargarEntidadesXtipo(TIPO_ENTIDAD.CLIENTE, txtProveedor.Text.Trim)
            End If
        End If
    End Sub

    Private Sub txtProveedor_TextChanged_1(sender As Object, e As EventArgs) Handles txtProveedor.TextChanged

    End Sub
End Class