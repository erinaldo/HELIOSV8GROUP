Imports System.Threading
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Public Class UCLogisticaAlmacenXEmpresa

#Region "Attributes"
    Public Property UCTransferencias As UCTransferenciasXEmpresa
    'Public Property UCInventarioInicial As UCInventarioInicial
    Public Property UCInventario As UCInventarioXEmpresa
    Public Property UCKardex As UCKardexXEmpresa

    'Public Property UCMercaderiaEntransito As UCMercaderiaEntransitoXEmpresa
    Public Property UCAdministrarAlmacen As UCAdministrarAlmacenXEmpresa
    Private Thread As Thread
    Friend Delegate Sub SetDelegateTransito(ByVal pendientes As Integer, stockMinimo As Integer, conteoRechazados As Integer)

    Public Property UCOtrasEntradas As UCOtrasEntradasXEmpresa
    Public Property FormRepositoryLogistica As FormRepositoryLogisticaApoyo
    Public Property UCOtrasSalidas As UCOtrasSalidasxEmpresa
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UCOtrasEntradas = New UCOtrasEntradasXEmpresa With {.Dock = DockStyle.Fill}
        UCOtrasSalidas = New UCOtrasSalidasxEmpresa With {.Dock = DockStyle.Fill}
        UCInventario = New UCInventarioXEmpresa
        UCKardex = New UCKardexXEmpresa
        'UCEnvioProductoPendienteRecepcion = New UCEnvioProductoPendienteRecepcion(Me)
        'UCMercaderiaEntransito = New UCMercaderiaEntransitoXEmpresa(Me)
        UCAdministrarAlmacen = New UCAdministrarAlmacenXEmpresa
        'UCInventarioInicial = New UCInventarioInicial With {.Dock = DockStyle.Fill}
        UCTransferencias = New UCTransferenciasXEmpresa With {.Dock = DockStyle.Fill, .Visible = False}


        UCInventario.Dock = DockStyle.Fill
        UCKardex.Dock = DockStyle.Fill
        'UCMercaderiaEntransito.Dock = DockStyle.Fill
        'UCEnvioProductoPendienteRecepcion.Dock = DockStyle.Fill
        UCAdministrarAlmacen.Dock = DockStyle.Fill

        PanelBody.Controls.Add(UCOtrasEntradas)
        PanelBody.Controls.Add(UCOtrasSalidas)

        PanelBody.Controls.Add(UCInventario)
        PanelBody.Controls.Add(UCKardex)
        'PanelBody.Controls.Add(UCMercaderiaEntransito)
        'PanelBody.Controls.Add(UCEnvioProductoPendienteRecepcion)
        PanelBody.Controls.Add(UCAdministrarAlmacen)
        PanelBody.Controls.Add(UCTransferencias)

        UCOtrasSalidas.Visible = False
        UCInventario.Visible = False
        UCKardex.Visible = False
        'UCMercaderiaEntransito.Visible = False
        'UCEnvioProductoPendienteRecepcion.Visible = False
        UCAdministrarAlmacen.Visible = False
        'UCInventarioInicial.Visible = False


        Adorner.AddBadgeTo(BTTransito, "0+")
        Adorner.AddBadgeTo(BTEnCurso, "0+")
        'ThreadTransito()
    End Sub


#End Region

#Region "Methods"
    'Public Sub ThreadTransito()
    '    Dim empresa = Gempresas.IdEmpresaRuc
    '    Dim estable = GEstableciento.IdEstablecimiento.GetValueOrDefault
    '    Thread = New Thread(New System.Threading.ThreadStart(Sub() GetProductosEnTransito(empresa, estable)))
    '    Thread.Start()
    'End Sub

    'Private Sub GetProductosEnTransito(empresa As String, estable As Integer?)
    '    Dim compraSA As New DocumentoCompraSA
    '    Dim totalesSA As New TotalesAlmacenSA

    '    Dim conteoTransito = compraSA.GetCountExistenciaTransito(New documentocompra With {
    '                                               .idEmpresa = empresa,
    '                                               .idCentroCosto = estable,
    '                                               .StatusEntregaProductosTransito = "1"})

    '    Dim conteoRechazados = compraSA.GetCountExistenciaTransito(New documentocompra With {
    '                                               .idEmpresa = empresa,
    '                                               .idCentroCosto = estable,
    '                                               .StatusEntregaProductosTransito = "2"})

    '    ' Dim pocoStock = totalesSA.GetAlertaIventarioMinimoConteo(New totalesAlmacen With {.idEmpresa = empresa})
    '    setConteoTransito(conteoTransito, 0, conteoRechazados)
    'End Sub

    'Private Sub setConteoTransito(pendientes As Integer, pocoStock As Integer, conteoRechazados As Integer)
    '    If Me.InvokeRequired Then
    '        'Me.Invoke(New SetDataSourceDelegate(AddressOf setDataSource), table)

    '        Dim deleg As New SetDelegateTransito(AddressOf setConteoTransito)
    '        Invoke(deleg, New Object() {pendientes, pocoStock, conteoRechazados})
    '    Else
    '        Adorner.SetBadgeText(BTTransito, $"{pendientes.ToString()}+")
    '        Adorner.SetBadgeText(BTEnCurso, $"{conteoRechazados.ToString()}+")
    '        '  Adorner.SetClickAction(BTTransito, BTTransito_Click_badget)

    '    End If
    'End Sub

#End Region

#Region "Events"
    Private Sub BunifuFlatButton15_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton15.Click, BunifuFlatButton2.Click, BunifuFlatButton1.Click, BTTransito.Click, BTEnCurso.Click, BunifuFlatButton3.Click, BunifuFlatButton6.Click, BunifuFlatButton5.Click, BunifuFlatButton4.Click
        Try
            Dim btn = sender
            'Dim btn2 = CType(sender, Button)

            If btn IsNot Nothing Then
                Select Case btn.Text
                    Case "Otras entradas"
                        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
                        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width


                        UCInventario.Visible = False
                        UCOtrasSalidas.Visible = False

                        UCKardex.Visible = False

                        UCAdministrarAlmacen.Visible = False
                        UCTransferencias.Visible = False
                        If UCOtrasEntradas IsNot Nothing Then
                            UCOtrasEntradas.Visible = True
                            UCOtrasEntradas.BringToFront()
                            UCOtrasEntradas.Show()
                        End If
                    Case "Otras sálidas"
                        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
                        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width


                        UCOtrasEntradas.Visible = False
                        UCInventario.Visible = False

                        UCKardex.Visible = False

                        UCAdministrarAlmacen.Visible = False
                        UCTransferencias.Visible = False
                        If UCOtrasSalidas IsNot Nothing Then
                            UCOtrasSalidas.Visible = True
                            UCOtrasSalidas.BringToFront()
                            UCOtrasSalidas.Show()
                        End If

                    Case "Inventario valorizado"
                        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
                        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width


                        UCOtrasEntradas.Visible = False
                        UCOtrasSalidas.Visible = False

                        UCKardex.Visible = False

                        UCAdministrarAlmacen.Visible = False
                        UCTransferencias.Visible = False
                        If UCInventario IsNot Nothing Then
                            UCInventario.Visible = True
                            UCInventario.BringToFront()
                            UCInventario.Show()
                        End If
                    Case "Kardex"
                        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
                        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width

                        UCOtrasEntradas.Visible = False
                        UCOtrasSalidas.Visible = False

                        UCInventario.Visible = False

                        UCAdministrarAlmacen.Visible = False
                        UCTransferencias.Visible = False
                        If UCKardex IsNot Nothing Then
                            UCKardex.Visible = True
                            UCKardex.BringToFront()
                            UCKardex.Show()
                        End If
                    Case "Almacén"
                        Cursor = Cursors.WaitCursor

                        UCOtrasEntradas.Visible = False
                        UCOtrasSalidas.Visible = False

                        'UCKardex.Visible = False
                        'UCInventario.Visible = False
                        'UCEnvioProductoPendienteRecepcion.Visible = False
                        'UCMercaderiaEntransito.Visible = False
                        'UCInventarioInicial.Visible = False
                        'UCTransferencias.Visible = False
                        If UCAdministrarAlmacen IsNot Nothing Then
                            UCAdministrarAlmacen.GetAlmacenes()
                            UCAdministrarAlmacen.Visible = True
                            UCAdministrarAlmacen.BringToFront()
                            UCAdministrarAlmacen.Show()
                        End If
                        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
                        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width
                        Cursor = Cursors.Default




                    Case "Transferencias"
                        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
                        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width

                        UCOtrasEntradas.Visible = False
                        UCOtrasSalidas.Visible = False

                        UCInventario.Visible = False
                        'UCEnvioProductoPendienteRecepcion.Visible = False
                        UCAdministrarAlmacen.Visible = False
                        UCKardex.Visible = False
                        If UCTransferencias IsNot Nothing Then
                            UCTransferencias.Visible = True
                            UCTransferencias.BringToFront()
                            UCTransferencias.Show()
                        End If

                End Select
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        '  End If
        'Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)



    End Sub

    Private Sub GradientPanel1_Paint(sender As Object, e As PaintEventArgs) Handles GradientPanel1.Paint

    End Sub

    Private Sub BunifuFlatButton7_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton7.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            If UCOtrasEntradas.Visible = True Then
                Dim f As New FormCrearCompra("ALMACEN")
                'f.ComboComprobante.Text = "Otra entrada"
                f.ComboComprobante.Enabled = False
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog(Me)
            ElseIf UCOtrasSalidas.Visible = True Then
                Dim f As New FormVentaNueva
                f.ComboComprobante.Text = "OTRA SALIDA DE ALMACEN"
                f.ComboComprobante.Enabled = False
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog(Me)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub


#End Region

End Class
