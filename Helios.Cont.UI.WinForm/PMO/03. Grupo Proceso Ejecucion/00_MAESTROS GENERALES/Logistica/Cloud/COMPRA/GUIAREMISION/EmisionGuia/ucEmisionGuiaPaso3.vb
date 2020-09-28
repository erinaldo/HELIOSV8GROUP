Imports System.Drawing.Drawing2D
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms.Tools
Imports Helios.General
Public Class ucEmisionGuiaPaso3

#Region "Attributes"
    Private listaUbigeoFull As List(Of regiones)
    Dim Ubregion As New regiones
    Dim UbregionLlegada As New regiones
#End Region

#Region "Constructors"
    Public Sub New(formGuiaRemision8 As FormGuiaRemision8)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GetUbigeo()
        CargarDEfaultUbigeo()
        _formGuiaRemision8 = formGuiaRemision8
    End Sub

    Public ReadOnly Property _formGuiaRemision8 As FormGuiaRemision8
#End Region

#Region "Methods"
    Private Sub listaProvincia(cod As String, comboDistrito As ComboBoxAdv)
        ' Dim codPro As String = cbDepartamento.SelectedValue.ToString

        Try

            Dim provincia = Ubregion.provincia.Where(Function(z) z.id = cod).FirstOrDefault

            comboDistrito.DisplayMember = "name"
            comboDistrito.ValueMember = "id"
            comboDistrito.DataSource = provincia.distrito.ToList

            comboDistrito.SelectedIndex = -1

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub listaDepartamento(idDep As String, comboPronvincia As ComboBoxAdv, comboDistrito As ComboBoxAdv)
        Try

            Ubregion = listaUbigeoFull.Where(Function(z) z.id = idDep).FirstOrDefault

            comboPronvincia.DisplayMember = "name"
            comboPronvincia.ValueMember = "id"
            comboPronvincia.DataSource = Ubregion.provincia.ToList

            Dim provincia = Ubregion.provincia.Where(Function(z) z.id = comboPronvincia.SelectedValue).FirstOrDefault

            comboDistrito.DisplayMember = "name"
            comboDistrito.ValueMember = "id"
            comboDistrito.DataSource = provincia.distrito.ToList


            comboPronvincia.SelectedIndex = -1
            comboDistrito.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub GetUbigeo()
        Dim ActivoUbigeoSA As New ubigeoSA
        listaUbigeoFull = ActivoUbigeoSA.ListarGetUbigeos()
    End Sub

    Private Sub CargarDEfaultUbigeo()
        Try
            'Dim result = Diferentes.Distinct(New ItemEqualityComparer())

            comboDepartamento.DisplayMember = "name"
            comboDepartamento.ValueMember = "id"
            comboDepartamento.DataSource = listaUbigeoFull
            comboDepartamento.SelectedValue = "120000"

            Ubregion = listaUbigeoFull.Where(Function(z) z.id = "120000").FirstOrDefault

            comboProvincia.DisplayMember = "name"
            comboProvincia.ValueMember = "id"
            comboProvincia.DataSource = Ubregion.provincia.ToList
            comboProvincia.SelectedValue = "120100"

            Dim provincia = Ubregion.provincia.Where(Function(z) z.id = "120100").FirstOrDefault

            comboDistrito.DisplayMember = "name"
            comboDistrito.ValueMember = "id"
            comboDistrito.DataSource = provincia.distrito.ToList
            comboDistrito.SelectedValue = "120107"

            '-----------------------------------------------------------------------------

            Dim ubigeosList = New List(Of regiones)
            ubigeosList.AddRange(listaUbigeoFull)

            comboDepartamentoLlegada.DisplayMember = "name"
            comboDepartamentoLlegada.ValueMember = "id"
            comboDepartamentoLlegada.DataSource = ubigeosList
            comboDepartamentoLlegada.SelectedValue = "120000"

            UbregionLlegada = listaUbigeoFull.Where(Function(z) z.id = "120000").FirstOrDefault

            comboProvinciaLlegada.DisplayMember = "name"
            comboProvinciaLlegada.ValueMember = "id"
            comboProvinciaLlegada.DataSource = UbregionLlegada.provincia.ToList
            comboProvinciaLlegada.SelectedValue = "120100"

            Dim provinciaLlegada = UbregionLlegada.provincia.Where(Function(z) z.id = "120100").FirstOrDefault

            comboDistritoLlegada.DisplayMember = "name"
            comboDistritoLlegada.ValueMember = "id"
            comboDistritoLlegada.DataSource = provinciaLlegada.distrito.ToList
            comboDistritoLlegada.SelectedValue = "120107"


            comboDepartamento.SelectedIndex = -1
            comboProvincia.SelectedIndex = -1
            comboDistrito.SelectedIndex = -1

            comboDepartamentoLlegada.SelectedIndex = -1
            comboProvinciaLlegada.SelectedIndex = -1
            comboDistritoLlegada.SelectedIndex = -1

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


#End Region

#Region "Events"
    Private Sub comboDepartamento_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles comboDepartamento.SelectionChangeCommitted
        listaDepartamento(comboDepartamento.SelectedValue, comboProvincia, comboDistrito)
    End Sub

    Private Sub comboProvincia_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles comboProvincia.SelectionChangeCommitted
        listaProvincia(comboProvincia.SelectedValue, comboDistrito)
    End Sub

    Private Sub comboDepartamentoLlegada_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles comboDepartamentoLlegada.SelectionChangeCommitted
        listaDepartamento(comboDepartamentoLlegada.SelectedValue, comboProvinciaLlegada, comboDistritoLlegada)
    End Sub

    Private Sub comboProvinciaLlegada_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles comboProvinciaLlegada.SelectionChangeCommitted
        listaProvincia(comboProvinciaLlegada.SelectedValue, comboDistritoLlegada)
    End Sub

    Private Sub sfButton1_Paint(sender As Object, e As PaintEventArgs) Handles sfButton1.Paint
        Dim radius As Integer = 5
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim rect As Rectangle = New Rectangle(Me.sfButton1.ClientRectangle.X + 1, Me.sfButton1.ClientRectangle.Y + 1, Me.sfButton1.ClientRectangle.Width - 2, Me.sfButton1.ClientRectangle.Height - 2)
        sfButton1.Region = New Region(GetRoundedRect(rect, radius))
        rect = New Rectangle(rect.X + 1, rect.Y + 1, rect.Width - 2, rect.Height - 2)
        e.Graphics.DrawPath(New Pen(Color.Green), GetRoundedRect(rect, radius))
    End Sub

    Private Sub SfButton2_Paint(sender As Object, e As PaintEventArgs) Handles SfButton2.Paint
        Dim radius As Integer = 5
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim rect As Rectangle = New Rectangle(Me.sfButton1.ClientRectangle.X + 1, Me.sfButton1.ClientRectangle.Y + 1, Me.sfButton1.ClientRectangle.Width - 2, Me.sfButton1.ClientRectangle.Height - 2)
        sfButton1.Region = New Region(GetRoundedRect(rect, radius))
        rect = New Rectangle(rect.X + 1, rect.Y + 1, rect.Width - 2, rect.Height - 2)
        e.Graphics.DrawPath(New Pen(Color.LightCoral), GetRoundedRect(rect, radius))
    End Sub

    Private Sub SfButton3_Paint(sender As Object, e As PaintEventArgs) Handles SfButton3.Paint
        Dim radius As Integer = 5
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim rect As Rectangle = New Rectangle(Me.sfButton1.ClientRectangle.X + 1, Me.sfButton1.ClientRectangle.Y + 1, Me.sfButton1.ClientRectangle.Width - 2, Me.sfButton1.ClientRectangle.Height - 2)
        sfButton1.Region = New Region(GetRoundedRect(rect, radius))
        rect = New Rectangle(rect.X + 1, rect.Y + 1, rect.Width - 2, rect.Height - 2)
        e.Graphics.DrawPath(New Pen(Color.FromKnownColor(KnownColor.HotTrack)), GetRoundedRect(rect, radius))
    End Sub

    Private Sub comboDepartamento_KeyDown(sender As Object, e As KeyEventArgs) Handles comboDepartamento.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            listaDepartamento(comboDepartamento.SelectedValue, comboProvincia, comboDistrito)
        End If
    End Sub

    Private Sub comboDepartamentoLlegada_KeyDown(sender As Object, e As KeyEventArgs) Handles comboDepartamentoLlegada.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            listaDepartamento(comboDepartamentoLlegada.SelectedValue, comboProvinciaLlegada, comboDistritoLlegada)
        End If
    End Sub

    Private Sub comboProvincia_KeyDown(sender As Object, e As KeyEventArgs) Handles comboProvincia.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            listaProvincia(comboProvincia.SelectedValue, comboDistrito)
        End If
    End Sub

    Private Sub comboProvinciaLlegada_KeyDown(sender As Object, e As KeyEventArgs) Handles comboProvinciaLlegada.KeyDown
        If e.KeyCode = Keys.Enter Then

        End If
    End Sub

    Private Sub comboDepartamento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles comboDepartamento.KeyPress
        If e.KeyChar >= "a"c AndAlso e.KeyChar <= "z"c Then e.KeyChar = Convert.ToChar(e.KeyChar.ToString().ToUpper())
        If Convert.ToInt32(e.KeyChar) = Convert.ToInt32(Keys.Enter) Then
            listaProvincia(comboProvinciaLlegada.SelectedValue, comboDistritoLlegada)
            comboProvinciaLlegada.SelectionLength = comboProvinciaLlegada.Text.Trim.Length
        End If


    End Sub

    Private Sub comboProvincia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles comboProvincia.KeyPress
        If e.KeyChar >= "a"c AndAlso e.KeyChar <= "z"c Then e.KeyChar = Convert.ToChar(e.KeyChar.ToString().ToUpper())
    End Sub

    Private Sub comboDistrito_KeyPress(sender As Object, e As KeyPressEventArgs) Handles comboDistrito.KeyPress
        If e.KeyChar >= "a"c AndAlso e.KeyChar <= "z"c Then e.KeyChar = Convert.ToChar(e.KeyChar.ToString().ToUpper())
    End Sub

    Private Sub comboProvinciaLlegada_KeyPress(sender As Object, e As KeyPressEventArgs) Handles comboProvinciaLlegada.KeyPress
        If e.KeyChar >= "a"c AndAlso e.KeyChar <= "z"c Then e.KeyChar = Convert.ToChar(e.KeyChar.ToString().ToUpper())
    End Sub

    Private Sub comboDepartamentoLlegada_KeyPress(sender As Object, e As KeyPressEventArgs) Handles comboDepartamentoLlegada.KeyPress
        If e.KeyChar >= "a"c AndAlso e.KeyChar <= "z"c Then e.KeyChar = Convert.ToChar(e.KeyChar.ToString().ToUpper())
    End Sub

    Private Sub comboDistritoLlegada_KeyPress(sender As Object, e As KeyPressEventArgs) Handles comboDistritoLlegada.KeyPress
        If e.KeyChar >= "a"c AndAlso e.KeyChar <= "z"c Then e.KeyChar = Convert.ToChar(e.KeyChar.ToString().ToUpper())
    End Sub

    Private Sub comboDepartamento_KeyUp(sender As Object, e As KeyEventArgs) Handles comboDepartamento.KeyUp
        If e.KeyCode = Keys.Enter Then
            If comboDepartamento.Text.Trim.Length > 0 Then
                comboDepartamento.SelectionStart = comboDepartamento.Text.Trim.Length
            End If
        End If
    End Sub

    Private Sub comboProvincia_KeyUp(sender As Object, e As KeyEventArgs) Handles comboProvincia.KeyUp
        If e.KeyCode = Keys.Enter Then
            If comboProvincia.Text.Trim.Length > 0 Then
                comboProvincia.SelectionStart = comboProvincia.Text.Trim.Length
            End If
        End If
    End Sub

    Private Sub comboDistrito_KeyUp(sender As Object, e As KeyEventArgs) Handles comboDistrito.KeyUp
        If e.KeyCode = Keys.Enter Then
            If comboDistrito.Text.Trim.Length > 0 Then
                comboDistrito.SelectionStart = comboDistrito.Text.Trim.Length
            End If
        End If
    End Sub

    Private Sub comboDepartamentoLlegada_KeyUp(sender As Object, e As KeyEventArgs) Handles comboDepartamentoLlegada.KeyUp
        If e.KeyCode = Keys.Enter Then
            If comboDepartamentoLlegada.Text.Trim.Length > 0 Then
                comboDepartamentoLlegada.SelectionStart = comboDepartamentoLlegada.Text.Trim.Length
            End If
        End If
    End Sub

    Private Sub comboProvinciaLlegada_KeyUp(sender As Object, e As KeyEventArgs) Handles comboProvinciaLlegada.KeyUp
        If e.KeyCode = Keys.Enter Then
            If comboProvinciaLlegada.Text.Trim.Length > 0 Then
                comboProvinciaLlegada.SelectionStart = comboProvinciaLlegada.Text.Trim.Length
            End If
        End If
    End Sub

    Private Sub comboDistritoLlegada_KeyUp(sender As Object, e As KeyEventArgs) Handles comboDistritoLlegada.KeyUp
        If e.KeyCode = Keys.Enter Then
            If comboDistritoLlegada.Text.Trim.Length > 0 Then
                comboDistritoLlegada.SelectionStart = comboDistritoLlegada.Text.Trim.Length
            End If
        End If
    End Sub

    Private Sub SfButton2_Click(sender As Object, e As EventArgs) Handles SfButton2.Click
        _formGuiaRemision8.Close()
    End Sub

    Private Sub sfButton1_Click(sender As Object, e As EventArgs) Handles sfButton1.Click
        If comboDepartamento.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(Me.comboDepartamento, "Departamento de partida")
            Exit Sub
        Else
            ErrorProvider1.SetError(Me.comboDepartamento, "")
        End If

        If comboProvincia.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(Me.comboProvincia, "Provincia de partida")
            Exit Sub
        Else
            ErrorProvider1.SetError(Me.comboProvincia, "")
        End If

        If comboDistrito.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(Me.comboDistrito, "Distrito de partida")
            Exit Sub
        Else
            ErrorProvider1.SetError(Me.comboDistrito, "")
        End If

        If TextDireccionPartida.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(Me.TextDireccionPartida, "Ingrese el domicilio de partida")
            Exit Sub
        Else
            ErrorProvider1.SetError(Me.TextDireccionPartida, "")
        End If
        '---------------------------------------------------------------------------------------------------


        If comboDepartamentoLlegada.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(Me.comboDepartamentoLlegada, "Departamento de llegada")
            Exit Sub
        Else
            ErrorProvider1.SetError(Me.comboDepartamentoLlegada, "")
        End If

        If comboProvinciaLlegada.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(Me.comboProvinciaLlegada, "Provincia de llegada")
            Exit Sub
        Else
            ErrorProvider1.SetError(Me.comboProvinciaLlegada, "")
        End If

        If comboDistritoLlegada.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(Me.comboDistritoLlegada, "Distrito de llegada")
            Exit Sub
        Else
            ErrorProvider1.SetError(Me.comboDistritoLlegada, "")
        End If

        If TextDireccionLlegada.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(Me.TextDireccionLlegada, "Ingrese el domicilio de llegada")
            Exit Sub
        Else
            ErrorProvider1.SetError(Me.TextDireccionLlegada, "")
        End If


        _formGuiaRemision8.sliderTop.Left = (_formGuiaRemision8.BunifuFlatButton2).Left
        _formGuiaRemision8.sliderTop.Width = (_formGuiaRemision8.BunifuFlatButton2).Width

        _formGuiaRemision8._ucEmisionGuiaPaso1.Visible = False
        _formGuiaRemision8._ucEmisionGuiaPaso2.Visible = False
        _formGuiaRemision8._ucEmisionGuiaPaso3.Visible = False
        _formGuiaRemision8._ucEmisionGuiaPaso5.Visible = False
        _formGuiaRemision8._ucEmisionGuiaPaso4.Visible = True

        _formGuiaRemision8._ucEmisionGuiaPaso4.ComboTipoTransporte.Text = _formGuiaRemision8._ucEmisionGuiaPaso1.ComboTipoTransporte.Text

    End Sub

    Private Sub SfButton3_Click(sender As Object, e As EventArgs) Handles SfButton3.Click
        _formGuiaRemision8.sliderTop.Left = (_formGuiaRemision8.BunifuFlatButton1).Left
        _formGuiaRemision8.sliderTop.Width = (_formGuiaRemision8.BunifuFlatButton1).Width

        _formGuiaRemision8._ucEmisionGuiaPaso1.Visible = False
        _formGuiaRemision8._ucEmisionGuiaPaso2.Visible = True
        _formGuiaRemision8._ucEmisionGuiaPaso3.Visible = False
        _formGuiaRemision8._ucEmisionGuiaPaso4.Visible = False
        _formGuiaRemision8._ucEmisionGuiaPaso5.Visible = False
        _formGuiaRemision8._ucEmisionGuiaPaso2.GetDetalleVenta()
    End Sub
#End Region

End Class
