Imports System.IO
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General

Public Class Tab_Habitaciones

    Private TabMG_GestionHabitacion As TabMG_GestionHabitacion

    Dim tipoFrm As String

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        TabMG_GestionHabitacion = New TabMG_GestionHabitacion With {.Dock = DockStyle.Fill}
        pnContenedor.Controls.Add(TabMG_GestionHabitacion)
        TabMG_GestionHabitacion.Visible = False

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


    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click, BunifuFlatButton7.Click, BunifuFlatButton6.Click, BunifuFlatButton5.Click, BunifuFlatButton4.Click, BunifuFlatButton3.Click, BunifuFlatButton1.Click
        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width
        '  End If
        Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)
        Select Case btn.Text
            Case "DISPONIBLES"
                If TabMG_GestionHabitacion IsNot Nothing Then
                    TabMG_GestionHabitacion.tipoLista = "A"
                    TabMG_GestionHabitacion.flowProductoDetalle.Controls.Clear()
                    TabMG_GestionHabitacion.Visible = True
                    TabMG_GestionHabitacion.BringToFront()
                    TabMG_GestionHabitacion.Show()
                End If
            Case "EN USO"
                If TabMG_GestionHabitacion IsNot Nothing Then
                    TabMG_GestionHabitacion.tipoLista = "U"
                    TabMG_GestionHabitacion.flowProductoDetalle.Controls.Clear()
                    TabMG_GestionHabitacion.Visible = True
                    TabMG_GestionHabitacion.BringToFront()
                    TabMG_GestionHabitacion.Show()
                End If
            Case "HABILITAR DISPONIBILIDAD"
                If TabMG_GestionHabitacion IsNot Nothing Then
                    TabMG_GestionHabitacion.tipoLista = "P"
                    TabMG_GestionHabitacion.flowProductoDetalle.Controls.Clear()
                    TabMG_GestionHabitacion.Visible = True
                    TabMG_GestionHabitacion.BringToFront()
                    TabMG_GestionHabitacion.Show()
                End If
            Case "EN MANTENIMIENTO"
                If TabMG_GestionHabitacion IsNot Nothing Then
                    TabMG_GestionHabitacion.tipoLista = "M"
                    TabMG_GestionHabitacion.flowProductoDetalle.Controls.Clear()
                    TabMG_GestionHabitacion.Visible = True
                    TabMG_GestionHabitacion.BringToFront()
                    TabMG_GestionHabitacion.Show()
                End If
            Case "HABITACIONES CON COMPROMISO"

            Case "TIPOS DE HABITACIONES"

            Case "CARACTERISTICAS DE LAS HABITACIONES"

        End Select
    End Sub

End Class
