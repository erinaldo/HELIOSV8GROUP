Imports System.ComponentModel

Public Class FormRepositoryPiscina
#Region "Attributes"
    Public Property Tab_RecepcionControl As Tab_RecepcionControl
    Public Property Tab_Infraestructura As Tab_Infraestructura

    Public Property Tab_Huesped As Tab_Huesped

    Public Property Tab_Habitaciones As Tab_Habitaciones

    Public Property Tab_Atencion As Tab_Atencion

#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Tab_Atencion = New Tab_Atencion
        Tab_RecepcionControl = New Tab_RecepcionControl()
        Tab_Infraestructura = New Tab_Infraestructura()
        Tab_Huesped = New Tab_Huesped()
        Tab_Habitaciones = New Tab_Habitaciones()

        Tab_Atencion = New Tab_Atencion With {.Dock = DockStyle.Fill}
        Tab_RecepcionControl = New Tab_RecepcionControl With {.Dock = DockStyle.Fill}
        Tab_Infraestructura = New Tab_Infraestructura With {.Dock = DockStyle.Fill}
        Tab_Huesped = New Tab_Huesped With {.Dock = DockStyle.Fill}
        Tab_Habitaciones = New Tab_Habitaciones With {.Dock = DockStyle.Fill}

        PanelBody.Controls.Add(Tab_RecepcionControl)
        PanelBody.Controls.Add(Tab_Infraestructura)
        PanelBody.Controls.Add(Tab_Huesped)
        PanelBody.Controls.Add(Tab_Habitaciones)
        PanelBody.Controls.Add(Tab_Atencion)
    End Sub

#End Region

    Private Sub BunifuFlatButton15_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click, BunifuFlatButton15.Click, BunifuFlatButton1.Click, BunifuFlatButton6.Click, BunifuFlatButton5.Click
        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width
        '  End If
        Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)
        Select Case btn.Text
            Case "RECEPCIÓN Y CONTROL"
                Tab_Atencion.Visible = False
                Tab_Infraestructura.Visible = False
                Tab_Huesped.Visible = False
                Tab_Habitaciones.Visible = False

                If Tab_RecepcionControl IsNot Nothing Then
                    Tab_RecepcionControl.Visible = True
                    Tab_RecepcionControl.BringToFront()
                    Tab_RecepcionControl.Show()
                End If
            Case "GESTIÓN DE LAS HABITACIONES"
                Tab_Atencion.Visible = False
                Tab_Infraestructura.Visible = False
                Tab_Huesped.Visible = False
                Tab_RecepcionControl.Visible = False

                If Tab_Habitaciones IsNot Nothing Then
                    Tab_Habitaciones.Visible = True
                    Tab_Habitaciones.BringToFront()
                    Tab_Habitaciones.Show()
                End If
            Case "GESTIÓN DE LA ATENCIÓN"
                Tab_RecepcionControl.Visible = False
                Tab_Infraestructura.Visible = False
                Tab_Huesped.Visible = False
                Tab_Habitaciones.Visible = False

                If Tab_Atencion IsNot Nothing Then
                    Tab_Atencion.Visible = True
                    Tab_Atencion.BringToFront()
                    Tab_Atencion.Show()
                End If
            Case "GESTIÓN DE HUESPEDES"
                Tab_Atencion.Visible = False
                Tab_Infraestructura.Visible = False
                Tab_RecepcionControl.Visible = False
                Tab_Habitaciones.Visible = False

                If Tab_Huesped IsNot Nothing Then
                    Tab_Huesped.Visible = True
                    Tab_Huesped.BringToFront()
                    Tab_Huesped.Show()
                End If
            Case "GESTIÓN DE LA INFRAESTRUCTURA"
                Tab_Atencion.Visible = False
                Tab_RecepcionControl.Visible = False
                Tab_Huesped.Visible = False
                Tab_Habitaciones.Visible = False

                If Tab_Infraestructura IsNot Nothing Then
                    Tab_Infraestructura.Visible = True
                    Tab_Infraestructura.BringToFront()
                    Tab_Infraestructura.Show()
                End If

            Case "GESTIÓN DE PRECIOS"
                Tab_Atencion.Visible = False
                Tab_RecepcionControl.Visible = False
                Tab_Huesped.Visible = False
                Tab_Habitaciones.Visible = False

                If Tab_Infraestructura IsNot Nothing Then
                    Tab_Infraestructura.Visible = True
                    Tab_Infraestructura.BringToFront()
                    Tab_Infraestructura.Show()
                End If

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