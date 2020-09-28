Imports System.Xml
Public Class FormGestionProductos

#Region "Attributes"
    Public Property Tab_GestionCategoria As Tab_GestionCategoria
    Public Property Tab_GestionSubCategoria As Tab_GestionSubCategoria
    Public Property Tab_GestionDetallesItem As Tab_GestionDetallesItem
    Public Property Tab_GestionComposicion As Tab_GestionComposicion

    Dim Formulario As Object = Nothing
    Dim m_xmld As XmlDocument
    Dim m_nodelist As XmlNodeList
    Dim m_node As XmlNode

#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Tab_GestionCategoria = New Tab_GestionCategoria()
        Tab_GestionCategoria.Dock = DockStyle.Fill
        PanelBody.Controls.Add(Tab_GestionCategoria)

        Tab_GestionSubCategoria = New Tab_GestionSubCategoria()
        Tab_GestionSubCategoria.Dock = DockStyle.Fill
        PanelBody.Controls.Add(Tab_GestionSubCategoria)

        Tab_GestionDetallesItem = New Tab_GestionDetallesItem()
        Tab_GestionDetallesItem.Dock = DockStyle.Fill
        PanelBody.Controls.Add(Tab_GestionDetallesItem)

        Tab_GestionComposicion = New Tab_GestionComposicion()
        Tab_GestionComposicion.Dock = DockStyle.Fill
        PanelBody.Controls.Add(Tab_GestionComposicion)

        CARGAR()

        If (Formulario = True) Then
            BunifuFlatButton15.Enabled = False
        ElseIf (FORMULARIO = False) Then
            BunifuFlatButton15.Enabled = True
        End If

    End Sub

#End Region


#Region "METODOS"

    Private Sub CARGAR()

        'Creamos el "Document"
        m_xmld = New XmlDocument()

        'Cargamos el archivo
        m_xmld.Load("C:\SPKconfiguration.xml")

        'Obtenemos la lista de los nodos "name"
        m_nodelist = m_xmld.SelectNodes("/spk/Mantenimiento")

        'Iniciamos el ciclo de lectura
        For Each m_node In m_nodelist
            'Obtenemos el Formulario de inicio
            Formulario = m_node.ChildNodes.Item(1).InnerText

            If (Formulario = "CLASIFICACION") Then
                Formulario = False
            ElseIf (Formulario = "CLASIFICACION") Then
                Formulario = True
            End If
            Exit For
        Next
    End Sub


#End Region

    Private Sub BunifuFlatButton15_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton15.Click, BunifuFlatButton3.Click, BunifuFlatButton1.Click, BunifuFlatButton2.Click
        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width
        '  End If
        Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)
        Select Case btn.Text
            Case "CATEGORIA"
                Tab_GestionSubCategoria.Visible = False
                Tab_GestionDetallesItem.Visible = False
                Tab_GestionComposicion.Visible = False
                If Tab_GestionCategoria IsNot Nothing Then
                    Tab_GestionCategoria.Visible = True
                    Tab_GestionCategoria.BringToFront()
                    Tab_GestionCategoria.Show()
                End If
            Case "SUB CATEGORIA"
                Tab_GestionCategoria.Visible = False
                Tab_GestionDetallesItem.Visible = False
                Tab_GestionComposicion.Visible = False
                If Tab_GestionSubCategoria IsNot Nothing Then
                    Tab_GestionSubCategoria.TipoManejo = Formulario
                    Tab_GestionSubCategoria.Visible = True
                    Tab_GestionSubCategoria.BringToFront()
                    Tab_GestionSubCategoria.Show()
                End If
            Case "PRODUCTO"
                Tab_GestionCategoria.Visible = False
                Tab_GestionSubCategoria.Visible = False
                Tab_GestionComposicion.Visible = False
                If Tab_GestionDetallesItem IsNot Nothing Then
                    Tab_GestionDetallesItem.Visible = True
                    Tab_GestionDetallesItem.TipoManejo = Formulario
                    Tab_GestionDetallesItem.BringToFront()
                    Tab_GestionDetallesItem.Show()
                End If
            Case "COMPOSICION"
                Tab_GestionCategoria.Visible = False
                Tab_GestionSubCategoria.Visible = False
                Tab_GestionDetallesItem.Visible = False
                If Tab_GestionComposicion IsNot Nothing Then
                    Tab_GestionComposicion.GetProductos()
                    Tab_GestionComposicion.Visible = True
                    Tab_GestionComposicion.BringToFront()
                    Tab_GestionDetallesItem.Show()
                End If
        End Select
    End Sub

    Private Sub BunifuImageButton2_Click(sender As Object, e As EventArgs) Handles bunifuImageButton2.Click
        Close()
    End Sub

End Class