Public Class ucPagoVentaCalzado
#Region "Attributes"
    Public Property FormVenta As FormVentaCalzados
    Public UCPagoCompletoDocumento As UCPagoVentaCompletoCalzado
    '  Public UCCronogramaPagos As UCCronogramaPagos
#End Region

    Public Sub New(FormCrearventa As FormVentaCalzados)

        ' This call is required by the designer.
        InitializeComponent()
        FormVenta = FormCrearventa
        ' Add any initialization after the InitializeComponent() call.
        UCPagoCompletoDocumento = New UCPagoVentaCompletoCalzado(FormCrearventa)

        UCPagoCompletoDocumento.Dock = DockStyle.Fill
        UCPagoCompletoDocumento.BringToFront()
        PanelBody.Controls.Add(UCPagoCompletoDocumento)
        UCPagoCompletoDocumento.Visible = True
    End Sub

    Private Sub RBSi_CheckedChanged(sender As Object, e As EventArgs) Handles RBSi.CheckedChanged
        If RBSi.Checked = True Then
            GroupBox2.Visible = True
            GroupBox1.Visible = True
            PanelBody.Visible = True
        End If
    End Sub

    Private Sub RBNo_CheckedChanged(sender As Object, e As EventArgs) Handles RBNo.CheckedChanged
        If RBNo.Checked = True Then
            GroupBox2.Visible = False
            GroupBox1.Visible = False
            PanelBody.Visible = False

            For Each i In FormVenta.ListaproductosVendidos.ToList
                'i.CustomDocumentoCaja = New List(Of documentoCaja)
                i.MontoPago = 0
                i.estadoPago = "PN"
            Next
        End If
    End Sub

    Private Sub RBPagoAcumulado_CheckedChanged(sender As Object, e As EventArgs) Handles RBPagoAcumulado.CheckedChanged
        If RBSi.Checked = True Then
            If RBPagoAcumulado.Checked = True Then
                'If UCCronogramaPagos IsNot Nothing Then
                '    UCCronogramaPagos.Visible = False
                'End If
                If UCPagoCompletoDocumento IsNot Nothing Then
                    UCPagoCompletoDocumento.Visible = True
                End If
            End If
        End If
    End Sub

    Private Sub RBCronograma_CheckedChanged(sender As Object, e As EventArgs) Handles RBCronograma.CheckedChanged
        If RBSi.Checked = True Then
            If RBCronograma.Checked = True Then
                If UCPagoCompletoDocumento IsNot Nothing Then
                    UCPagoCompletoDocumento.Visible = False
                End If
                'If UCCronogramaPagos IsNot Nothing Then
                '    UCCronogramaPagos.Visible = True
                'End If
            End If
        End If
    End Sub

End Class
