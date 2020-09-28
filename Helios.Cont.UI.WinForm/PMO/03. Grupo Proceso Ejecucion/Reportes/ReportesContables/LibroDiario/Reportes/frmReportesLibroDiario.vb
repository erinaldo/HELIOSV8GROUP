Public Class frmReportesLibroDiario

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        ExpandCollapsePanel1.ExpandedHeight = 75
        vaciarCajas()
        GroupBox3.Visible = False
        Label6.Visible = False
        txtidProveedor.Visible = False
        txtProveedor.Visible = False
        LinkProveedor.Visible = False
        Label1.Visible = True
        txtDocumento.Visible = True
        Label3.Visible = False
        txtIdComprobante.Visible = False
        txtComprobante.Visible = False
        LinkTipoDoc.Visible = False
        Label8.Visible = False
        dtpPeriodoMes.Visible = False
        dtpPeriodoAnio.Visible = False
        Label2.Visible = False
        Tag = "Documento"
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        ExpandCollapsePanel1.ExpandedHeight = 75
        Tag = "Entidad"
        vaciarCajas()
        GroupBox3.Visible = False
        Label6.Visible = True
        txtidProveedor.Visible = True
        txtProveedor.Visible = True
        LinkProveedor.Visible = True
        Label1.Visible = False
        txtDocumento.Visible = False
        Label3.Visible = False
        txtIdComprobante.Visible = False
        txtComprobante.Visible = False
        LinkTipoDoc.Visible = False
        Label8.Visible = False
        dtpPeriodoMes.Visible = False
        dtpPeriodoAnio.Visible = False
        Label2.Visible = False
    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        ExpandCollapsePanel1.ExpandedHeight = 75
        Tag = "Codigo Libro"
        Label6.Visible = False
        txtidProveedor.Visible = False
        txtProveedor.Visible = False
        LinkProveedor.Visible = False
        Label1.Visible = False
        txtDocumento.Visible = False
        Label3.Visible = True
        txtIdComprobante.Visible = True
        txtComprobante.Visible = True
        LinkTipoDoc.Visible = True
        GroupBox3.Visible = False
        Label8.Visible = False
        dtpPeriodoMes.Visible = False
        dtpPeriodoAnio.Visible = False
        Label2.Visible = False
        vaciarCajas()
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        ExpandCollapsePanel1.ExpandedHeight = 113
        Tag = "Fecha Progreso"
        Label6.Visible = False
        txtidProveedor.Visible = False
        txtProveedor.Visible = False
        LinkProveedor.Visible = False
        Label1.Visible = False
        txtDocumento.Visible = False
        Label3.Visible = True
        txtIdComprobante.Visible = True
        txtComprobante.Visible = True
        LinkTipoDoc.Visible = True
        GroupBox3.Visible = True
        Label8.Visible = False
        dtpPeriodoMes.Visible = False
        dtpPeriodoAnio.Visible = False
        Label2.Visible = False
        vaciarCajas()
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        ExpandCollapsePanel1.ExpandedHeight = 75
        Tag = "Período"
        Label6.Visible = False
        txtidProveedor.Visible = False
        txtProveedor.Visible = False
        LinkProveedor.Visible = False
        Label1.Visible = False
        txtDocumento.Visible = False
        Label3.Visible = True
        txtIdComprobante.Visible = False
        txtComprobante.Visible = False
        LinkTipoDoc.Visible = False
        GroupBox3.Visible = False
        Label8.Visible = True
        dtpPeriodoMes.Visible = True
        dtpPeriodoAnio.Visible = True
        Label2.Visible = True
        vaciarCajas()
    End Sub

    Sub vaciarCajas()
        txtidProveedor.Clear()
        txtProveedor.Clear()
        txtDocumento.Clear()
        txtIdComprobante.Clear()
        txtComprobante.Clear()
        txtFechaInicio.Value = Date.Now
        txtFechaFin.Value = Date.Now
    End Sub

    Private Sub frmReportesLibroDiario_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ExpandCollapsePanel1.ExpandedHeight = 0
    End Sub

    Private Sub LinkTipoDoc_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkTipoDoc.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
        datos.Clear()
        'With frmModalComprobantesTabla
        '    .lblTipo.Text = "8"
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        '    If datos.Count > 0 Then
        '        txtIdComprobante.Text = datos(0).ID
        '        txtComprobante.Text = datos(0).NombreCampo
        '    Else
        '        txtIdComprobante.Text = String.Empty
        '        txtComprobante.Text = String.Empty
        '        MsgBox("Debe ingresar un comprobante.", MsgBoxStyle.Information, "Atención!")
        '    End If
        'End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub LinkProveedor_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkProveedor.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        ProveedoresShows()
        Me.Cursor = Cursors.Arrow
    End Sub

    Sub ProveedoresShows()
        Me.Cursor = Cursors.WaitCursor
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        datos.Clear()
        'With frmModalEntidades
        '    .lblTipo.Text = "PR"
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        '    If datos.Count > 0 Then
        '        txtidProveedor.Text = datos(0).ID
        '        txtProveedor.Text = datos(0).NombreEntidad
        '        txtProveedor.Focus()
        '    Else
        '        txtidProveedor.Text = String.Empty
        '        txtProveedor.Text = String.Empty
        '        txtProveedor.Focus()
        '    End If
        'End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub QRibbonApplicationButton1_ItemActivated(sender As System.Object, e As Qios.DevSuite.Components.QCompositeEventArgs) Handles QRibbonApplicationButton1.ItemActivated
        Me.Cursor = Cursors.WaitCursor
        With frmModalReportesLibroDiario
            Select Case Tag
                Case "Documento"
                    If (txtDocumento.Text.Length > 0) Then
                        .Tag = "Documento"
                        .ConsultaReporte(txtDocumento.Text, 1, 1, CDate(txtFechaInicio.Value).Date, CDate(txtFechaFin.Value).Date, (dtpPeriodoMes.Value), (dtpPeriodoAnio.Value), 2014)
                        .StartPosition = FormStartPosition.CenterScreen
                        .Show()
                    End If
                Case "Entidad"
                    If (txtidProveedor.Text.Length > 0) Then
                        .Tag = "Entidad"
                        .ConsultaReporte(1, 1, txtidProveedor.Text, CDate(txtFechaInicio.Value).Date, CDate(txtFechaFin.Value).Date, (dtpPeriodoMes.Value), (dtpPeriodoAnio.Value), 2014)
                        .StartPosition = FormStartPosition.CenterScreen
                        .Show()
                    End If
                Case "Código Libro"
                    If (txtComprobante.Text.Length > 0) Then
                        .Tag = "Código Libro"
                        .ConsultaReporte(1, txtIdComprobante.Text, 1, CDate(txtFechaInicio.Value).Date, CDate(txtFechaFin.Value).Date, (dtpPeriodoMes.Value), (dtpPeriodoAnio.Value), 2014)
                        .StartPosition = FormStartPosition.CenterScreen
                        .Show()
                    End If
                Case "Fecha Progreso"
                    If (txtComprobante.Text.Length > 0) Then
                        .Tag = "Fecha Progreso"
                        .ConsultaReporte(1, txtIdComprobante.Text, 1, CDate(txtFechaInicio.Value).Date, CDate(txtFechaFin.Value).Date, (dtpPeriodoMes.Value), (dtpPeriodoAnio.Value), 2014)
                        .StartPosition = FormStartPosition.CenterScreen
                        .Show()
                    End If
                Case "Período"
                    If (dtpPeriodoMes.Text.Length > 0) Then
                        .Tag = "Período"
                        .ConsultaReporte(1, 1, 1, CDate(txtFechaInicio.Value).Date, CDate(txtFechaFin.Value).Date, (dtpPeriodoMes.Value), (dtpPeriodoAnio.Value), 2014)
                        .StartPosition = FormStartPosition.CenterScreen
                        .Show()
                    End If
            End Select
        End With
        Me.Cursor = Cursors.Arrow
    End Sub
End Class