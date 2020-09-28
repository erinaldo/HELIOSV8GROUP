Imports System.ComponentModel

Public Class FormMasterReservacion
#Region "Attributes"
    Public Property TabR_Cliente As TabR_Cliente
    Public Property TabR_Asiento As TabR_Asiento

    Public Property programacion_ID As Integer

    Public Property placaBus As Integer

#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.


    End Sub

#End Region

    Private Sub BunifuFlatButton15_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton15.Click, BunifuFlatButton1.Click
        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width
        '  End If
        Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)
        Select Case btn.Text
            Case "CLIENTE"

                TabR_Cliente = New TabR_Cliente(Me) With {
                        .Dock = DockStyle.Fill
                    }
                TabR_Cliente.BringToFront()
                PanelBody.Controls.Add(TabR_Cliente)

            Case "AGENCIA"
                TabR_Asiento = New TabR_Asiento(Me) With {
                                      .Dock = DockStyle.Fill
                                  }
                TabR_Asiento.programacion_ID = programacion_ID
                TabR_Asiento.placaBus = placaBus
                TabR_Asiento.LLAMARiNFRAESTRUCTURA(placaBus, programacion_ID)
                TabR_Asiento.BringToFront()
                PanelBody.Controls.Add(TabR_Asiento)

        End Select
    End Sub

    Private Sub BunifuImageButton2_Click(sender As Object, e As EventArgs) Handles bunifuImageButton2.Click
        Close()
    End Sub

    Private Sub FormRepositoryPiscina_Load(sender As Object, e As EventArgs) Handles Me.Load
        General.Centrar(Me)
    End Sub

    Private Sub BunifuImageButton1_Click(sender As Object, e As EventArgs) Handles BunifuImageButton1.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class