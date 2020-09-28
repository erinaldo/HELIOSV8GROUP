Public Class UCControlMantenimiento

#Region "Attributes"
    Private TabMG_Productos As TabMG_Productos
    Private TabMG_TablasGenerales As TabMG_TablasGenerales
    Private TabCM_RegistroDatosGenerales As TabCM_RegistroDatosGenerales
    Private TabMG_Categorias As TabMG_Categorias
    Private TabMG_ModuloNumeracion As TabMG_ModuloNumeracion

#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        TabMG_TablasGenerales = New TabMG_TablasGenerales With {.Dock = DockStyle.Fill}
        TabMG_Productos = New TabMG_Productos() With {.Dock = DockStyle.Fill}
        TabCM_RegistroDatosGenerales = New TabCM_RegistroDatosGenerales() With {.Dock = DockStyle.Fill}
        TabMG_Categorias = New TabMG_Categorias() With {.Dock = DockStyle.Fill}
        TabMG_ModuloNumeracion = New TabMG_ModuloNumeracion() With {.Dock = DockStyle.Fill}
        PanelBody.Controls.Add(TabMG_TablasGenerales)
        PanelBody.Controls.Add(TabMG_Productos)
        PanelBody.Controls.Add(TabCM_RegistroDatosGenerales)
        PanelBody.Controls.Add(TabMG_Categorias)
        PanelBody.Controls.Add(TabMG_ModuloNumeracion)
    End Sub


#End Region

#Region "Methods"

#End Region

#Region "Events"
    Private Sub BunifuFlatButton15_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton15.Click, BunifuFlatButton5.Click, BunifuFlatButton3.Click, BunifuFlatButton2.Click, BunifuFlatButton1.Click, BunifuFlatButton4.Click, BunifuFlatButton7.Click
        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width
        '  End If
        Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)
        Select Case btn.Text
            Case "Tablas generales"
                TabMG_Categorias.Visible = False
                TabMG_Productos.Visible = False
                TabCM_RegistroDatosGenerales.Visible = False
                TabMG_ModuloNumeracion.Visible = False
                If TabMG_TablasGenerales IsNot Nothing Then
                    TabMG_TablasGenerales.Visible = True
                    TabMG_TablasGenerales.BringToFront()
                    TabMG_TablasGenerales.Show()
                End If
            Case "Tipo de cambio"
                TabMG_Categorias.Visible = False
                TabCM_RegistroDatosGenerales.Visible = False
                TabMG_TablasGenerales.Visible = False
                TabMG_Productos.Visible = False
                TabMG_ModuloNumeracion.Visible = False
            Case "Producto"
                TabMG_Categorias.Visible = False
                TabMG_TablasGenerales.Visible = False
                TabMG_ModuloNumeracion.Visible = False
                If TabMG_Productos IsNot Nothing Then
                    TabMG_Productos.Visible = True
                    TabMG_Productos.BringToFront()
                    TabMG_Productos.Show()
                End If
            Case "Servicio"
                TabCM_RegistroDatosGenerales.Visible = False
                TabMG_TablasGenerales.Visible = False
                TabMG_Productos.Visible = False
                TabMG_Categorias.Visible = False
                TabMG_ModuloNumeracion.Visible = False
            Case "Categoria/grupo"
                TabCM_RegistroDatosGenerales.Visible = False
                TabMG_TablasGenerales.Visible = False
                TabMG_Productos.Visible = False
                TabMG_Categorias.Visible = True
                TabMG_ModuloNumeracion.Visible = False
            Case "Formatos Impresión"
                TabMG_TablasGenerales.Visible = False
                TabMG_Productos.Visible = False
                TabCM_RegistroDatosGenerales.Visible = True
                TabMG_Categorias.Visible = False
                TabMG_ModuloNumeracion.Visible = False
            Case "Numeración"
                TabMG_TablasGenerales.Visible = False
                TabMG_Productos.Visible = False
                TabCM_RegistroDatosGenerales.Visible = False
                TabMG_Categorias.Visible = False
                TabMG_ModuloNumeracion.Visible = True
        End Select
    End Sub

    Private Sub BunifuFlatButton6_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton6.Click
        Visible = False
        PanelBody.Visible = True
    End Sub
#End Region


End Class
