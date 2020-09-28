Public Class FormRepositoryFinanzas

#Region "Attributes"
    Public UCAdministrarCuentas As UCAdministrarCuentas
    Public UCControlOperaciones As UCControlOperaciones
    Private UCCuentasXpagar As UCCuentasXpagar
    Private UCCuentasXcobrar As UCCuentasXcobrar
    'Private UCAnticiposControl As UCAnticiposControl
    'Private UCReclamacionesControl As UCReclamacionesControl

#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        BtPagos.Visible = True
        BunifuFlatButton3.Visible = True

        UCAdministrarCuentas = New UCAdministrarCuentas With {.Dock = DockStyle.Fill}
        UCControlOperaciones = New UCControlOperaciones With {.Dock = DockStyle.Fill, .Visible = False}

        UCCuentasXpagar = New UCCuentasXpagar With {.Dock = DockStyle.Fill, .Visible = False}
        UCCuentasXcobrar = New UCCuentasXcobrar With {.Dock = DockStyle.Fill, .Visible = False}
        'UCAnticiposControl = New UCAnticiposControl With {.Dock = DockStyle.Fill, .Visible = False}
        'UCReclamacionesControl = New UCReclamacionesControl With {.Dock = DockStyle.Fill, .Visible = False}

        PanelBody.Controls.Add(UCAdministrarCuentas)
        PanelBody.Controls.Add(UCControlOperaciones)
        PanelBody.Controls.Add(UCCuentasXpagar)
        PanelBody.Controls.Add(UCCuentasXcobrar)
        'PanelBody.Controls.Add(UCAnticiposControl)
        'PanelBody.Controls.Add(UCReclamacionesControl)

    End Sub
#End Region

#Region "Methods"

#End Region

#Region "Events"
    Private Sub BunifuFlatButton15_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton15.Click, BunifuFlatButton4.Click, BunifuFlatButton2.Click, BunifuFlatButton16.Click, BtPagos.Click, BunifuFlatButton3.Click, BunifuFlatButton5.Click, BunifuFlatButton6.Click
        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width
        '  End If
        Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)
        Select Case btn.Text
            Case "MIS CUENTAS"
                'UCCuentasXpagar.Visible = False
                'UCCuentasXcobrar.Visible = False
                UCControlOperaciones.Visible = False
                'UCAnticiposControl.Visible = False
                'UCReclamacionesControl.Visible = False

                If UCAdministrarCuentas IsNot Nothing Then
                    UCAdministrarCuentas.Visible = True
                    UCAdministrarCuentas.BringToFront()
                    UCAdministrarCuentas.Show()
                End If
            Case "OPERACIONES"
                'UCCuentasXpagar.Visible = False
                'UCCuentasXcobrar.Visible = False
                UCAdministrarCuentas.Visible = False
                'UCAnticiposControl.Visible = False
                'UCReclamacionesControl.Visible = False

                If UCControlOperaciones IsNot Nothing Then
                    UCControlOperaciones.Visible = True
                    UCControlOperaciones.BringToFront()
                    UCControlOperaciones.Show()
                End If
            Case "TABLERO"

            Case "FINANZAS"

            Case "CUENTAS X PAGAR"
                UCControlOperaciones.Visible = False
                UCCuentasXcobrar.Visible = False
                UCAdministrarCuentas.Visible = False
                'UCAnticiposControl.Visible = False
                ' UCReclamacionesControl.Visible = False
                'UCControlFinanzas.Visible = False
                If UCCuentasXpagar IsNot Nothing Then
                    UCCuentasXpagar.Visible = True
                    UCCuentasXpagar.BringToFront()
                    UCCuentasXpagar.Show()
                End If

            Case "CUENTAS X COBRAR"
                UCCuentasXpagar.Visible = False
                UCControlOperaciones.Visible = False
                UCAdministrarCuentas.Visible = False
                'UCAnticiposControl.Visible = False
                'UCReclamacionesControl.Visible = False
                'UCControlFinanzas.Visible = False
                If UCCuentasXcobrar IsNot Nothing Then
                    UCCuentasXcobrar.Visible = True
                    UCCuentasXcobrar.BringToFront()
                    UCCuentasXcobrar.Show()
                End If

                'Case "ANTICIPOS"
                '    UCCuentasXpagar.Visible = False
                '    UCControlOperaciones.Visible = False
                '    UCAdministrarCuentas.Visible = False
                '    UCCuentasXcobrar.Visible = False
                '    UCReclamacionesControl.Visible = False
                '    If UCAnticiposControl IsNot Nothing Then
                '        UCAnticiposControl.Visible = True
                '        UCAnticiposControl.BringToFront()
                '        UCAnticiposControl.Show()
                '    End If

                'Case "RECLAMACIONES"
                '    UCCuentasXpagar.Visible = False
                '    UCControlOperaciones.Visible = False
                '    UCAdministrarCuentas.Visible = False
                '    UCCuentasXcobrar.Visible = False
                '    UCAnticiposControl.Visible = False
                '    If UCReclamacionesControl IsNot Nothing Then
                '        UCReclamacionesControl.Visible = True
                '        UCReclamacionesControl.BringToFront()
                '        UCReclamacionesControl.Show()
                '    End If

        End Select
    End Sub

    Private Sub bunifuImageButton2_Click(sender As Object, e As EventArgs) Handles bunifuImageButton2.Click
        Close()
    End Sub

    Private Sub BunifuImageButton1_Click(sender As Object, e As EventArgs) Handles BunifuImageButton1.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

#End Region


End Class