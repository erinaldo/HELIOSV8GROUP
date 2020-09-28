Imports Helios.Cont.Business.Entity

Public Class FormGuiaRemision8
    Public _ucEmisionGuiaPaso1 As ucEmisionGuiaPaso1
    Public _ucEmisionGuiaPaso2 As ucEmisionGuiaPaso2
    Public _ucEmisionGuiaPaso3 As ucEmisionGuiaPaso3
    Public _ucEmisionGuiaPaso4 As ucEmisionGuiaPaso4
    Public _ucEmisionGuiaPaso5 As ucEmisionGuiaPaso5
    Public ListaPropertiesGuia As List(Of documentoGuiaProperties)
#Region "Constructors"
    Public Sub New(venta As documentoventaAbarrotes)

        ' This call is required by the designer.
        InitializeComponent()
        ListaPropertiesGuia = New List(Of documentoGuiaProperties)
        ' Add any initialization after the InitializeComponent() call.
        _ucEmisionGuiaPaso1 = New ucEmisionGuiaPaso1(Me) With {.Dock = DockStyle.Bottom.Fill, .Visible = True}
        _ucEmisionGuiaPaso2 = New ucEmisionGuiaPaso2(Me) With {.Dock = DockStyle.Bottom.Fill, .Visible = False}
        _ucEmisionGuiaPaso3 = New ucEmisionGuiaPaso3(Me) With {.Dock = DockStyle.Bottom.Fill, .Visible = False}
        _ucEmisionGuiaPaso4 = New ucEmisionGuiaPaso4(Me) With {.Dock = DockStyle.Bottom.Fill, .Visible = False}
        _ucEmisionGuiaPaso5 = New ucEmisionGuiaPaso5(Me) With {.Dock = DockStyle.Bottom.Fill, .Visible = False}

        PanelBody.Controls.Add(_ucEmisionGuiaPaso1)
        PanelBody.Controls.Add(_ucEmisionGuiaPaso2)
        PanelBody.Controls.Add(_ucEmisionGuiaPaso3)
        PanelBody.Controls.Add(_ucEmisionGuiaPaso4)
        PanelBody.Controls.Add(_ucEmisionGuiaPaso5)
        _venta = venta
        _ucEmisionGuiaPaso1.cbomotivotrasl.Text = "VENTA"
    End Sub

    Public ReadOnly Property _venta As documentoventaAbarrotes
#End Region
    Private Sub FormGuiaRemision8_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton3.Click, BunifuFlatButton8.Click, BunifuFlatButton2.Click, BunifuFlatButton15.Click, BunifuFlatButton1.Click
        'sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
        'sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width
        ''  End If
        'Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)
        'Select Case btn.Text
        '    Case "Emisión de Guía"
        '        _ucEmisionGuiaPaso1.Visible = True
        '        _ucEmisionGuiaPaso2.Visible = False
        '        _ucEmisionGuiaPaso3.Visible = False
        '        _ucEmisionGuiaPaso4.Visible = False
        '        _ucEmisionGuiaPaso5.Visible = False
        '    Case "Bienes a trasladar"
        '        _ucEmisionGuiaPaso1.Visible = False
        '        _ucEmisionGuiaPaso2.Visible = True
        '        _ucEmisionGuiaPaso3.Visible = False
        '        _ucEmisionGuiaPaso4.Visible = False
        '        _ucEmisionGuiaPaso5.Visible = False
        '        _ucEmisionGuiaPaso2.GetDetalleVenta()
        '    Case "Ubicación (Ubigeo)"
        '        _ucEmisionGuiaPaso1.Visible = False
        '        _ucEmisionGuiaPaso2.Visible = False
        '        _ucEmisionGuiaPaso4.Visible = False
        '        _ucEmisionGuiaPaso5.Visible = False
        '        _ucEmisionGuiaPaso3.Visible = True

        '    Case "Transporte"
        '        _ucEmisionGuiaPaso1.Visible = False
        '        _ucEmisionGuiaPaso2.Visible = False
        '        _ucEmisionGuiaPaso3.Visible = False
        '        _ucEmisionGuiaPaso5.Visible = False
        '        _ucEmisionGuiaPaso4.Visible = True
        '    Case "Finalizar y registrar"
        '        _ucEmisionGuiaPaso1.Visible = False
        '        _ucEmisionGuiaPaso2.Visible = False
        '        _ucEmisionGuiaPaso3.Visible = False
        '        _ucEmisionGuiaPaso4.Visible = False
        '        _ucEmisionGuiaPaso5.Visible = True
        'End Select
    End Sub

    Private Sub BunifuFlatButton8_ChangeUICues(sender As Object, e As UICuesEventArgs) Handles BunifuFlatButton8.ChangeUICues, BunifuFlatButton2.ChangeUICues, BunifuFlatButton15.ChangeUICues, BunifuFlatButton1.ChangeUICues

    End Sub
End Class