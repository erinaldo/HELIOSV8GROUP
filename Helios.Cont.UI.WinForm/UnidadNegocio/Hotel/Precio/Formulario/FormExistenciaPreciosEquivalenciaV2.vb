
Public Class FormExistenciaPreciosEquivalenciaV2

    Private UC_ExistenciaPrecio As UC_ExistenciaPrecio
    Private UC_FormExistenciaPreciosEquivalencia As FormExistenciaPreciosEquivalencia
    Private UC_FormServiciosPreciosEquivalencia As UC_FormServiciosPreciosEquivalencia
    Private UC_FormProductoTerminadoPreciosEquivalencia As UC_FormProductoTerminadoPreciosEquivalencia
    Private UC_FormBienesAlquilerPreciosEquivalencia As UC_FormBienesAlquilerPreciosEquivalencia

#Region "Attributes"

#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UC_ExistenciaPrecio = New UC_ExistenciaPrecio With {.Dock = DockStyle.Fill}
        UC_FormExistenciaPreciosEquivalencia = New FormExistenciaPreciosEquivalencia With {.Dock = DockStyle.Fill}
        UC_FormServiciosPreciosEquivalencia = New UC_FormServiciosPreciosEquivalencia With {.Dock = DockStyle.Fill}
        UC_FormProductoTerminadoPreciosEquivalencia = New UC_FormProductoTerminadoPreciosEquivalencia With {.Dock = DockStyle.Fill}
        UC_FormBienesAlquilerPreciosEquivalencia = New UC_FormBienesAlquilerPreciosEquivalencia With {.Dock = DockStyle.Fill}

        PanelBody.Controls.Add(UC_ExistenciaPrecio)
        PanelBody.Controls.Add(UC_FormExistenciaPreciosEquivalencia)
        PanelBody.Controls.Add(UC_FormServiciosPreciosEquivalencia)
        PanelBody.Controls.Add(UC_FormProductoTerminadoPreciosEquivalencia)
        PanelBody.Controls.Add(UC_FormBienesAlquilerPreciosEquivalencia)
        General.Centrar(Me)

        UC_ExistenciaPrecio.Visible = False
        UC_FormServiciosPreciosEquivalencia.Visible = False
        UC_FormExistenciaPreciosEquivalencia.Visible = True
        UC_FormExistenciaPreciosEquivalencia.BringToFront()
        UC_FormExistenciaPreciosEquivalencia.Show()

    End Sub

    Private Sub BunifuFlatButton15_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton15.Click, BunifuFlatButton4.Click, BunifuFlatButton1.Click, BunifuFlatButton3.Click, BunifuFlatButton2.Click
        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width
        '  End If
        Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)
        Select Case btn.Text

            Case "MERCADERIA"
                UC_ExistenciaPrecio.Visible = False
                UC_FormServiciosPreciosEquivalencia.Visible = False
                UC_FormProductoTerminadoPreciosEquivalencia.Visible = False
                UC_FormBienesAlquilerPreciosEquivalencia.Visible = False

                If UC_FormExistenciaPreciosEquivalencia IsNot Nothing Then
                    UC_FormExistenciaPreciosEquivalencia.Visible = True
                    UC_FormExistenciaPreciosEquivalencia.BringToFront()
                    UC_FormExistenciaPreciosEquivalencia.Show()
                End If

            Case "SERVICIO"
                UC_ExistenciaPrecio.Visible = False
                UC_FormExistenciaPreciosEquivalencia.Visible = False
                UC_FormProductoTerminadoPreciosEquivalencia.Visible = False
                UC_FormBienesAlquilerPreciosEquivalencia.Visible = False

                If UC_FormServiciosPreciosEquivalencia IsNot Nothing Then
                    UC_FormServiciosPreciosEquivalencia.Visible = True
                    UC_FormServiciosPreciosEquivalencia.BringToFront()
                    UC_FormServiciosPreciosEquivalencia.Show()
                End If

            Case "PRODUCTO TERMINADO"
                UC_ExistenciaPrecio.Visible = False
                UC_FormExistenciaPreciosEquivalencia.Visible = False
                UC_FormServiciosPreciosEquivalencia.Visible = False
                UC_FormBienesAlquilerPreciosEquivalencia.Visible = False

                If UC_FormProductoTerminadoPreciosEquivalencia IsNot Nothing Then
                    UC_FormProductoTerminadoPreciosEquivalencia.Visible = True
                    UC_FormProductoTerminadoPreciosEquivalencia.BringToFront()
                    UC_FormProductoTerminadoPreciosEquivalencia.Show()
                End If

            Case "BIENES EN ALQUILER"
                UC_ExistenciaPrecio.Visible = False
                UC_FormExistenciaPreciosEquivalencia.Visible = False
                UC_FormServiciosPreciosEquivalencia.Visible = False
                UC_FormProductoTerminadoPreciosEquivalencia.Visible = False

                If UC_FormBienesAlquilerPreciosEquivalencia IsNot Nothing Then
                    UC_FormBienesAlquilerPreciosEquivalencia.Visible = True
                    UC_FormBienesAlquilerPreciosEquivalencia.BringToFront()
                    UC_FormBienesAlquilerPreciosEquivalencia.Show()
                End If

            Case "INFRAESTRUCTURA"
                UC_FormExistenciaPreciosEquivalencia.Visible = False
                UC_FormServiciosPreciosEquivalencia.Visible = False
                UC_FormProductoTerminadoPreciosEquivalencia.Visible = False
                UC_FormBienesAlquilerPreciosEquivalencia.Visible = False

                If UC_ExistenciaPrecio IsNot Nothing Then
                    UC_ExistenciaPrecio.Visible = True
                    UC_ExistenciaPrecio.BringToFront()
                    UC_ExistenciaPrecio.Show()
                End If

        End Select
    End Sub

    Private Sub BunifuImageButton2_Click(sender As Object, e As EventArgs) Handles bunifuImageButton2.Click
        Dispose()
    End Sub
#End Region

#Region "Methods"

#End Region

#Region "Events"

#End Region

End Class