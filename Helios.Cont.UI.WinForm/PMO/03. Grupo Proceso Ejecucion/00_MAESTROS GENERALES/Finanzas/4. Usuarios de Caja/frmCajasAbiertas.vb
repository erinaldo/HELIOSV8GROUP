Imports System.ComponentModel
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity

Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Public Class frmCajasAbiertas
#Region "varible"

    Private UCCajaEnActividad As New UCCajaEnActividad
    Private UCCajaEnArqueo As New UCCajaEnArqueo

    Public Property boxUserSA As New cajaUsuarioSA

#End Region

#Region "Builder"
    Sub New()



        ' This call is required by the designer.
        InitializeComponent()
        'FormatoGridAvanzado(DgvOpenBox, True, False)


        UCCajaEnActividad = New UCCajaEnActividad With {.Dock = DockStyle.Fill, .Visible = True}
        UCCajaEnArqueo = New UCCajaEnArqueo With {.Dock = DockStyle.Fill, .Visible = False}

        PanelBody.Controls.Add(UCCajaEnActividad)
        PanelBody.Controls.Add(UCCajaEnArqueo)

        ' Add any initialization after the InitializeComponent() call.

    End Sub
#End Region



#Region "Methods"



    Private Sub frmCajasAbiertas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BunifuFlatButton16_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton16.Click, BunifuFlatButton1.Click
        Try

            Dim boxUserSA As New cajaUsuarioSA

            sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
            sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width
            '  End If
            Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)
            Select Case btn.Text
                Case "Cajas En Actividad"

                    UCCajaEnArqueo.Visible = False


                    If UCCajaEnActividad IsNot Nothing Then
                        UCCajaEnActividad.Visible = True
                        UCCajaEnActividad.BringToFront()
                        UCCajaEnActividad.Show()
                    End If
                Case "Cajas Sin Arqueo"
                    UCCajaEnActividad.Visible = False

                    Dim be As New cajaUsuario
                    be.idEmpresa = Gempresas.IdEmpresaRuc
                    be.idEstablecimiento = GEstableciento.IdEstablecimiento

                    Dim ListOpenBox = boxUserSA.ListBoxOpen(be)

                    If UCCajaEnArqueo IsNot Nothing Then
                        UCCajaEnArqueo.Visible = True
                        UCCajaEnArqueo.BringToFront()
                        UCCajaEnArqueo.Show()
                    End If
                Case "Efectivo en Caja"
                    UCCajaEnActividad.Visible = False
                    UCCajaEnArqueo.Visible = False



            End Select
        Catch ex As Exception

        End Try
    End Sub







#End Region


End Class