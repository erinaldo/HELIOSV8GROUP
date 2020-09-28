Imports System.IO
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General

Public Class Tab_Huesped

    Private TabListaHospedados As TabListaHospedados

    Private TabMG_HistorialInfraestructura As TabMG_HistorialInfraestructura

    Private TabListaHospedadosActivos As TabListaHospedadosActivos

    Dim tipoFrm As String

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        TabListaHospedados = New TabListaHospedados With {.Dock = DockStyle.Fill}
        pnContenedor.Controls.Add(TabListaHospedados)
        TabListaHospedados.Visible = False

        TabMG_HistorialInfraestructura = New TabMG_HistorialInfraestructura With {.Dock = DockStyle.Fill}
        pnContenedor.Controls.Add(TabMG_HistorialInfraestructura)
        TabMG_HistorialInfraestructura.Visible = False

        TabListaHospedadosActivos = New TabListaHospedadosActivos With {.Dock = DockStyle.Fill}
        pnContenedor.Controls.Add(TabListaHospedadosActivos)
        TabListaHospedadosActivos.Visible = True

    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click, BunifuFlatButton5.Click, BunifuFlatButton4.Click, BunifuFlatButton3.Click, BunifuFlatButton1.Click
        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width
        '  End If
        Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)
        Select Case btn.Text
            Case "CONTROL DE HOSPEDADOS ACTIVOS"
                TabMG_HistorialInfraestructura.Visible = False
                TabListaHospedados.Visible = False
                If TabListaHospedadosActivos IsNot Nothing Then
                    TabListaHospedadosActivos.Visible = True
                    TabListaHospedadosActivos.BringToFront()
                    TabListaHospedadosActivos.Show()
                End If
            Case "MOVIMIENTOS DE HUESPED (INGRESO Y SALIDA)"
                TabListaHospedados.Visible = False
                TabListaHospedadosActivos.Visible = False
                If TabMG_HistorialInfraestructura IsNot Nothing Then
                    TabMG_HistorialInfraestructura.Visible = True
                    TabMG_HistorialInfraestructura.BringToFront()
                    TabMG_HistorialInfraestructura.Show()
                End If
            Case "ALERTA DEL PROXIMO RETIRO DE HUESPED"
                TabMG_HistorialInfraestructura.Visible = False
                TabListaHospedados.Visible = False
                TabListaHospedadosActivos.Visible = False
            Case "REGISTRO DE HUESPED"
                TabMG_HistorialInfraestructura.Visible = False
                TabListaHospedados.Visible = False
                TabListaHospedadosActivos.Visible = False
            Case "HISTORIAL DE HUESPED"
                TabMG_HistorialInfraestructura.Visible = False
                TabListaHospedadosActivos.Visible = False
                If TabListaHospedados IsNot Nothing Then
                    TabListaHospedados.Visible = True
                    TabListaHospedados.BringToFront()
                    TabListaHospedados.Show()
                End If
        End Select
    End Sub
End Class
