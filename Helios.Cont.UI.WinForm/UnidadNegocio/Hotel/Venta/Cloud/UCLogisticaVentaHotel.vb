
Public Class UCLogisticaVentaHotel

#Region "Attributes"
    Private UCVentas As UCVentas
    Private UCNotas As UCNotaVentas
    Private UCVentasAnuladas As UCVentasAnuladas
    Private UCProformas As UCProformas
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

        UCVentas.Dock = DockStyle.Fill
        UCNotas.Dock = DockStyle.Fill
        UCVentasAnuladas.Dock = DockStyle.Fill

        PanelBody.Controls.Add(UCVentas)
        PanelBody.Controls.Add(UCNotas)
        PanelBody.Controls.Add(UCVentasAnuladas)
        PanelBody.Controls.Add(UCProformas)

        UCNotas.Visible = False
        UCVentasAnuladas.Visible = False
        UCProformas.Visible = False

    End Sub
#End Region

#Region "Methods"

#End Region

#Region "Events"
    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) 
        Dim cajaUsuarioSA As New Helios.Cont.WCFService.ServiceAccess.cajaUsuarioSA
        Try
            If General.ClipBoardDocumento IsNot Nothing AndAlso General.ClipBoardDocumento.documentoventaAbarrotes IsNot Nothing Then

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

    Private Sub BunifuFlatButton15_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton15.Click, BunifuFlatButton2.Click
        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width
        '  End If
        'BunifuFlatButton4.Visible = True
        Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)
        Select Case btn.Text
            Case "Ventas"
                UCNotas.Visible = False
                UCVentasAnuladas.Visible = False
                UCProformas.Visible = False
                If UCVentas IsNot Nothing Then
                    UCVentas.Visible = True
                    UCVentas.BringToFront()
                    UCVentas.Show()
                End If
            Case "Notas"
                UCVentasAnuladas.Visible = False
                UCVentas.Visible = False
                UCProformas.Visible = False
                If UCNotas IsNot Nothing Then
                    UCNotas.Visible = True
                    UCNotas.BringToFront()
                    UCNotas.Show()
                End If
            Case "Anulados"
                UCNotas.Visible = False
                UCVentas.Visible = False
                UCProformas.Visible = False
                If UCVentasAnuladas IsNot Nothing Then
                    'BunifuFlatButton4.Visible = False
                    UCVentasAnuladas.Visible = True
                    UCVentasAnuladas.BringToFront()
                    UCVentasAnuladas.Show()
                End If

            Case "Proformas"
                UCNotas.Visible = False
                UCVentas.Visible = False
                UCVentasAnuladas.Visible = False
                If UCProformas IsNot Nothing Then
                    UCProformas.Visible = True
                    UCProformas.BringToFront()
                    UCProformas.Show()
                End If
        End Select
    End Sub


#End Region
End Class
