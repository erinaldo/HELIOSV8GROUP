Public Class FormRepositoryComercial
#Region "Attributes"
    Public Property UCLogisticaVenta As UCLogisticaVenta
    Public Property UCClientes As UCClientes
    Public Property UCFlujoCaja As UCFlujoCaja
    '  Public Property UCLogisticaAlmacen As UCLogisticaAlmacen
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UCClientes = New UCClientes
        UCLogisticaVenta = New UCLogisticaVenta()
        UCFlujoCaja = New UCFlujoCaja With {.Dock = DockStyle.Fill}

        UCLogisticaVenta.Dock = DockStyle.Fill
        UCClientes.Dock = DockStyle.Fill

        PanelBody.Controls.Add(UCLogisticaVenta)
        PanelBody.Controls.Add(UCClientes)
        PanelBody.Controls.Add(UCFlujoCaja)
    End Sub

    Public Sub New(OpcionInicio As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Select Case OpcionInicio
            Case "Cierre cajero"
                BunifuFlatButton2.Visible = False
                BunifuFlatButton16.Visible = False
                BunifuFlatButton3.Visible = False
                BunifuFlatButton1.Visible = False
                BunifuFlatButton15.Visible = False
                BunifuFlatButton4.Visible = False
                sliderTop.Visible = False

                UCFlujoCaja = New UCFlujoCaja("Cierre cajero") With {.Dock = DockStyle.Fill, .Visible = True}
                PanelBody.Controls.Add(UCFlujoCaja)
        End Select
    End Sub

#End Region

    Private Sub bunifuImageButton2_Click(sender As Object, e As EventArgs) Handles bunifuImageButton2.Click
        Me.Close()
    End Sub

    Private Sub BunifuImageButton1_Click(sender As Object, e As EventArgs) Handles BunifuImageButton1.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BunifuFlatButton15_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton15.Click, BunifuFlatButton3.Click, BunifuFlatButton2.Click, BunifuFlatButton16.Click, BunifuFlatButton1.Click, BunifuFlatButton4.Click
        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width
        '  End If
        Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)
        Select Case btn.Text
            Case "OPERACIONES"
                UCClientes.Visible = False
                UCFlujoCaja.Visible = False
                If UCLogisticaVenta IsNot Nothing Then
                    UCLogisticaVenta.Visible = True
                    UCLogisticaVenta.BringToFront()
                    UCLogisticaVenta.Show()
                End If
            Case "DISTRIBUCION"

            Case "CLIENTE"
                UCFlujoCaja.Visible = False
                UCLogisticaVenta.Visible = False
                If UCClientes IsNot Nothing Then
                    UCClientes.Visible = True
                    UCClientes.BringToFront()
                    UCClientes.Show()
                End If
            Case "BENEFICIOS"

            Case "TABLERO"

            Case "REPORTES"
                UCClientes.Visible = False
                UCLogisticaVenta.Visible = False
                If UCFlujoCaja IsNot Nothing Then
                    UCFlujoCaja.Visible = True
                    UCFlujoCaja.BringToFront()
                    UCFlujoCaja.Show()
                End If

        End Select
    End Sub

    Private Sub panelheader_Paint(sender As Object, e As PaintEventArgs) Handles panelheader.Paint

    End Sub
End Class