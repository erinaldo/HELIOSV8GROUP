Imports System.IO
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Public Class USubMaestroServicios

    Public Property UCMaestroTipoServicio As USubMaestroTipoServicio
    Public Property USubMaestroServicioExistencia As USubMaestroServicioExistencia



    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call.
        UCMaestroTipoServicio = New USubMaestroTipoServicio() With {.Dock = DockStyle.Fill, .Visible = True}
        PanelBodyServicio.Controls.Add(UCMaestroTipoServicio)

        USubMaestroServicioExistencia = New USubMaestroServicioExistencia() With {.Dock = DockStyle.Fill, .Visible = False}
        PanelBodyServicio.Controls.Add(USubMaestroServicioExistencia)

    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click, BunifuFlatButton3.Click
        Try

            sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
            sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width

            Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)

            Select Case btn.Tag

                Case "Tipo de Servicio"
                    PanelBodyServicio.Visible = True
                    USubMaestroServicioExistencia.Visible = False
                    If UCMaestroTipoServicio IsNot Nothing Then
                        UCMaestroTipoServicio.Visible = True
                        UCMaestroTipoServicio.BringToFront()
                        UCMaestroTipoServicio.Show()
                    End If

                Case "Tipo de Servicio(Cliente)"
                    PanelBodyServicio.Visible = True
                    UCMaestroTipoServicio.Visible = False
                    If USubMaestroServicioExistencia IsNot Nothing Then
                        USubMaestroServicioExistencia.Visible = True
                        USubMaestroServicioExistencia.BringToFront()
                        USubMaestroServicioExistencia.Show()
                    End If

            End Select

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
