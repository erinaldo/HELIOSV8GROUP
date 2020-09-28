Imports System.IO
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General

Public Class Tab_AreasDeAtencion

    Private TabPedidoPiscina_EP As TabPedidoPiscina_EP
    Private frmPendienteAtencion As frmPendienteAtencion
    Private frmPendienteAtencionBarra As frmPendienteAtencionBarra

    Dim tipoFrm As String

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        TabPedidoPiscina_EP = New TabPedidoPiscina_EP With {.Dock = DockStyle.Fill}
        pnContenedor.Controls.Add(TabPedidoPiscina_EP)
        TabPedidoPiscina_EP.Visible = False

        frmPendienteAtencion = New frmPendienteAtencion With {.Dock = DockStyle.Fill}
        pnContenedor.Controls.Add(frmPendienteAtencion)
        frmPendienteAtencion.Visible = False

        frmPendienteAtencionBarra = New frmPendienteAtencionBarra With {.Dock = DockStyle.Fill}
        pnContenedor.Controls.Add(frmPendienteAtencionBarra)
        frmPendienteAtencionBarra.Visible = False

    End Sub

#Region "Metodos"
    Private Sub AbrirFormEnPanel(Of Miform As {Form, New})()
        Dim Formulario As Form
        Formulario = pnContenedor.Controls.OfType(Of Miform)().FirstOrDefault() 'Busca el formulario en la coleccion
        'Si form no fue econtrado/ no existe
        If Formulario Is Nothing Then
            Formulario = New Miform()
            Formulario.TopLevel = False
            Formulario.FormBorderStyle = FormBorderStyle.None
            Formulario.Dock = DockStyle.Fill

            pnContenedor.Controls.Add(Formulario)
            pnContenedor.Tag = Formulario
            'AddHandler Formulario.FormClosed, AddressOf Me.CerrarFormulario

            Formulario.Show()
            Formulario.BringToFront()

        Else
            Formulario.BringToFront()
        End If

    End Sub

    Public Sub ConfigForm(Parametro1 As String, Parametro2 As String)

        Me.Cursor = Cursors.WaitCursor

        Select Case Parametro2
            Case "TabListaInfraestructura"

            Case "Tab_ListaPedidos"

                Dim ListaEstado As New List(Of String)
                ListaEstado.Add("PN")
                ListaEstado.Add("AN")
                ListaEstado.Add("PR")
                ListaEstado.Add("DC")


        End Select


        Me.Cursor = Cursors.Arrow
    End Sub

#End Region


    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click
        Try
            sliderTop.Left = BunifuFlatButton2.Left
            sliderTop.Width = BunifuFlatButton2.Width

            TabPedidoPiscina_EP.BringToFront()
            TabPedidoPiscina_EP.Show()
            TabPedidoPiscina_EP.Visible = True
            frmPendienteAtencion.Visible = False
            frmPendienteAtencionBarra.Visible = False

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        Try
            sliderTop.Left = BunifuFlatButton1.Left
            sliderTop.Width = BunifuFlatButton1.Width

            frmPendienteAtencion.BringToFront()
            frmPendienteAtencion.Show()
            TabPedidoPiscina_EP.Visible = False
            frmPendienteAtencion.Visible = True
            frmPendienteAtencionBarra.Visible = False

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton3.Click
        Try

            sliderTop.Left = BunifuFlatButton3.Left
            sliderTop.Width = BunifuFlatButton3.Width

            frmPendienteAtencionBarra.BringToFront()
            frmPendienteAtencionBarra.Show()
            TabPedidoPiscina_EP.Visible = False
            frmPendienteAtencion.Visible = False
            frmPendienteAtencionBarra.Visible = True

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
