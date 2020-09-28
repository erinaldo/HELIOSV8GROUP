Imports PopupControl
Public Class UCLogisticaVenta

#Region "Attributes"
    Dim popup As Popup
    Private UCVentas As UCVentas
    Private UCNotas As UCNotaVentas
    Private UCVentasAnuladas As UCVentasAnuladas
    Private UCProformas As UCProformas
    Private ucoper As UCOperacionVenta
    Private ucDistribucion As ucDistribucion
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UCVentas = New UCVentas
        UCNotas = New UCNotaVentas
        UCVentasAnuladas = New UCVentasAnuladas
        UCProformas = New UCProformas With {.Dock = DockStyle.Fill}
        ucDistribucion = New ucDistribucion With {.Dock = DockStyle.Fill, .Visible = False}

        UCVentas.Dock = DockStyle.Fill
        UCNotas.Dock = DockStyle.Fill
        UCVentasAnuladas.Dock = DockStyle.Fill

        PanelBody.Controls.Add(UCVentas)
        PanelBody.Controls.Add(UCNotas)
        PanelBody.Controls.Add(UCVentasAnuladas)
        PanelBody.Controls.Add(UCProformas)
        PanelBody.Controls.Add(ucDistribucion)

        UCNotas.Visible = False
        UCVentasAnuladas.Visible = False
        UCProformas.Visible = False

        ucoper = New UCOperacionVenta
        popup = New Popup(ucoper)
        popup.Resizable = True
    End Sub
#End Region

#Region "Methods"

#End Region

#Region "Events"
    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
        Dim cajaUsuarioSA As New Helios.Cont.WCFService.ServiceAccess.cajaUsuarioSA
        Try
            If General.ClipBoardDocumento IsNot Nothing AndAlso General.ClipBoardDocumento.documentoventaAbarrotes IsNot Nothing Then

                '  popup.Show(TryCast(sender, Bunifu.Framework.UI.BunifuFlatButton))

                If General.ListaCajasActivas.Count = 0 Or General.ListaCajasActivas Is Nothing Then
                    MessageBox.Show("Debe registrar una caja para realizar la venta")
                    General.ListaCajasActivas = cajaUsuarioSA.ListadoCajaXEstado(New Business.Entity.cajaUsuario With {
                                                             .idEmpresa = General.Gempresas.IdEmpresaRuc,
                                                             .idEstablecimiento = General.GEstableciento.IdEstablecimiento,
                                                             .estadoCaja = "A"
                                                             })
                    Exit Sub
                End If

                Dim f As New FormVentaNueva(General.ClipBoardDocumento)
                f.ComboComprobante.Text = "VENTA"
                f.StartPosition = FormStartPosition.CenterParent
                f.Show(Me)
            Else
                If UCProformas.Visible = True Then
                    Dim f As New FormVentaNueva
                    f.ComboComprobante.Text = "PROFORMA"
                    f.StartPosition = FormStartPosition.CenterParent
                    f.Show(Me)
                ElseIf UCVentas.Visible = True Then
                    If General.ListaCajasActivas.Count = 0 Or General.ListaCajasActivas Is Nothing Then



                        MessageBox.Show("Debe registrar una caja para realizar la venta")
                        General.ListaCajasActivas = cajaUsuarioSA.ListadoCajaXEstado(New Business.Entity.cajaUsuario With {
                                                             .idEmpresa = General.Gempresas.IdEmpresaRuc,
                                                             .idEstablecimiento = General.GEstableciento.IdEstablecimiento,
                                                             .estadoCaja = "A"
                                                             })
                        Exit Sub
                    End If
                    '  popup.Show(TryCast(sender, Bunifu.Framework.UI.BunifuFlatButton))

                    Dim f As New FormVentaNueva
                    f.ComboComprobante.Text = "VENTA"
                    f.StartPosition = FormStartPosition.CenterParent
                    f.Show(Me)
                ElseIf UCNotas.Visible = True Then
                    If General.ListaCajasActivas.Count = 0 Or General.ListaCajasActivas Is Nothing Then
                        MessageBox.Show("Debe registrar una caja para realizar la venta")
                        General.ListaCajasActivas = cajaUsuarioSA.ListadoCajaXEstado(New Business.Entity.cajaUsuario With {
                                                             .idEmpresa = General.Gempresas.IdEmpresaRuc,
                                                             .idEstablecimiento = General.GEstableciento.IdEstablecimiento,
                                                             .estadoCaja = "A"
                                                             })
                        Exit Sub
                    End If

                    Dim f As New FormVentaNueva
                    f.ComboComprobante.Text = "NOTA DE VENTA"
                    f.StartPosition = FormStartPosition.CenterParent
                    f.Show(Me)
                End If


            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BunifuFlatButton15_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton15.Click, BunifuFlatButton2.Click, BunifuFlatButton1.Click, BunifuFlatButton3.Click, BunifuFlatButton8.Click
        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width
        '  End If
        BunifuFlatButton4.Visible = True
        Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)
        Select Case btn.Text
            Case "Ventas"
                ucDistribucion.Visible = False
                UCNotas.Visible = False
                UCVentasAnuladas.Visible = False
                UCProformas.Visible = False
                If UCVentas IsNot Nothing Then
                    UCVentas.Visible = True
                    UCVentas.BringToFront()
                    UCVentas.Show()
                End If
            Case "Notas"
                ucDistribucion.Visible = False
                UCVentasAnuladas.Visible = False
                UCVentas.Visible = False
                UCProformas.Visible = False
                If UCNotas IsNot Nothing Then
                    UCNotas.Visible = True
                    UCNotas.BringToFront()
                    UCNotas.Show()
                End If
            Case "Anulados"
                ucDistribucion.Visible = False
                UCNotas.Visible = False
                UCVentas.Visible = False
                UCProformas.Visible = False
                If UCVentasAnuladas IsNot Nothing Then
                    BunifuFlatButton4.Visible = False
                    UCVentasAnuladas.Visible = True
                    UCVentasAnuladas.BringToFront()
                    UCVentasAnuladas.Show()
                End If

            Case "Proformas"
                ucDistribucion.Visible = False
                UCNotas.Visible = False
                UCVentas.Visible = False
                UCVentasAnuladas.Visible = False
                If UCProformas IsNot Nothing Then
                    UCProformas.Visible = True
                    UCProformas.BringToFront()
                    UCProformas.Show()
                End If

            Case "Distribución"
                UCProformas.Visible = False
                UCNotas.Visible = False
                UCVentas.Visible = False
                UCVentasAnuladas.Visible = False
                If ucDistribucion IsNot Nothing Then
                    ucDistribucion.Visible = True
                    ucDistribucion.BringToFront()
                    ucDistribucion.Show()
                End If


        End Select
    End Sub

    Private Sub BunifuFlatButton5_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton5.Click
        'Dim f As New FormVentaNueva
        'f.ComboComprobante.Text = "VENTA"
        'f.UCEstructuraCabeceraVentaV2.cboMoneda.Text = "DOLAR AMERICANO"
        'f.StartPosition = FormStartPosition.CenterParent
        'f.Show(Me)

        Dim cajaUsuarioSA As New Helios.Cont.WCFService.ServiceAccess.cajaUsuarioSA
        Try
            If General.ClipBoardDocumento IsNot Nothing AndAlso General.ClipBoardDocumento.documentoventaAbarrotes IsNot Nothing Then

                '  popup.Show(TryCast(sender, Bunifu.Framework.UI.BunifuFlatButton))

                If General.ListaCajasActivas.Count = 0 Or General.ListaCajasActivas Is Nothing Then
                    MessageBox.Show("Debe registrar una caja para realizar la venta")
                    General.ListaCajasActivas = cajaUsuarioSA.ListadoCajaXEstado(New Business.Entity.cajaUsuario With {
                                                             .idEmpresa = General.Gempresas.IdEmpresaRuc,
                                                             .idEstablecimiento = General.GEstableciento.IdEstablecimiento,
                                                             .estadoCaja = "A"
                                                             })
                    Exit Sub
                End If

                Dim f As New FormVentaNueva(General.ClipBoardDocumento)
                f.ComboComprobante.Text = "VENTA"
                f.UCEstructuraCabeceraVentaV2.cboMoneda.Text = "DOLAR AMERICANO"
                f.StartPosition = FormStartPosition.CenterParent
                f.Show(Me)
            Else
                If UCProformas.Visible = True Then
                    Dim f As New FormVentaNueva
                    f.ComboComprobante.Text = "PROFORMA"
                    f.UCEstructuraCabeceraVentaV2.cboMoneda.Text = "DOLAR AMERICANO"
                    f.StartPosition = FormStartPosition.CenterParent
                    f.Show(Me)
                ElseIf UCVentas.Visible = True Then
                    If General.ListaCajasActivas.Count = 0 Or General.ListaCajasActivas Is Nothing Then



                        MessageBox.Show("Debe registrar una caja para realizar la venta")
                        General.ListaCajasActivas = cajaUsuarioSA.ListadoCajaXEstado(New Business.Entity.cajaUsuario With {
                                                             .idEmpresa = General.Gempresas.IdEmpresaRuc,
                                                             .idEstablecimiento = General.GEstableciento.IdEstablecimiento,
                                                             .estadoCaja = "A"
                                                             })
                        Exit Sub
                    End If
                    '  popup.Show(TryCast(sender, Bunifu.Framework.UI.BunifuFlatButton))

                    Dim f As New FormVentaNueva
                    f.ComboComprobante.Text = "VENTA"
                    f.UCEstructuraCabeceraVentaV2.cboMoneda.Text = "DOLAR AMERICANO"
                    f.StartPosition = FormStartPosition.CenterParent
                    f.Show(Me)
                ElseIf UCNotas.Visible = True Then
                    If General.ListaCajasActivas.Count = 0 Or General.ListaCajasActivas Is Nothing Then
                        MessageBox.Show("Debe registrar una caja para realizar la venta")
                        General.ListaCajasActivas = cajaUsuarioSA.ListadoCajaXEstado(New Business.Entity.cajaUsuario With {
                                                             .idEmpresa = General.Gempresas.IdEmpresaRuc,
                                                             .idEstablecimiento = General.GEstableciento.IdEstablecimiento,
                                                             .estadoCaja = "A"
                                                             })
                        Exit Sub
                    End If

                    Dim f As New FormVentaNueva
                    f.ComboComprobante.Text = "NOTA DE VENTA"
                    f.UCEstructuraCabeceraVentaV2.cboMoneda.Text = "DOLAR AMERICANO"
                    f.StartPosition = FormStartPosition.CenterParent
                    f.Show(Me)
                End If


            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


#End Region
End Class
