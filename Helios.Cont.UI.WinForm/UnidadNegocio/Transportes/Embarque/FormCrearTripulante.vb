Imports System.IO
Imports System.Net
Imports System.Threading
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Public Class FormCrearTripulante
#Region "Attributes"

#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ComboComprobante.Enabled = False
    End Sub
#End Region

#Region "Methods"
    Public Sub GrabarPersona()
        Dim personaSA As New PersonaSA
        Dim obj As New Persona
        obj.idEntidad = 0 ' entidadSel.idEntidad
        obj.idPersona = TextCodigoPersona.Text.Trim
        obj.idEmpresa = Gempresas.IdEmpresaRuc
        obj.idOrganizacion = GEstableciento.IdEstablecimiento
        obj.edad = TextEdad.DecimalValue
        obj.fechaNac = Date.Now
        obj.tipoPersona = "T"
        obj.nombreCompleto = TextNombres.Text.Trim
        Select Case ComboComprobante.Text
            Case "DNI"
                obj.tipodoc = "1"
                'obj.nombreComercial = $"{TextApellidos.Text.Trim}, {TextNombres.Text.Trim}"
            Case "RUC"
                obj.tipodoc = "6"
               'obj.nombreComercial = TextNombreComercial.Text.Trim
            Case "CARNET EXTRANJERIA"
                obj.tipodoc = "4"
                'obj.nombreComercial = $"{TextApellidos.Text.Trim}, {TextNombres.Text.Trim}"
            Case "PASAPORTE"
                obj.tipodoc = "7"
                'obj.nombreComercial = $"{TextApellidos.Text.Trim}, {TextNombres.Text.Trim}"
        End Select
        obj.appat = "-"
        obj.apmat = "-"
        obj.nombres = TextNombres.Text.Trim
        obj.telefono = TextCodigoLic.Text.Trim
        obj.usuarioActualizacion = usuario.IDUsuario
        obj.fechaActualizacion = Date.Now
        Dim per = personaSA.InsertPersona(obj)
        Me.Tag = per
        MessageBox.Show("Tripulante registrado con éxito!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Close()
    End Sub

    Private Sub GetConsultarDNIReniec(Dni As String)
        Dim CLIENTE As New WebClient
        Dim PAGINA As Stream = CLIENTE.OpenRead("http://aplicaciones007.jne.gob.pe/srop_publico/Consulta/Afiliado/GetNombresCiudadano?DNI=" & Dni)
        Dim LECTOR As New StreamReader(PAGINA)
        Dim MIHTML As String = LECTOR.ReadToEnd
        ' Dim array = MIHTML.Split("|")

        TextNombres.Text = MIHTML.Replace("|", Space(1))

    End Sub

    Private Function ValidarGrabado() As Boolean
        Dim listaErrores As Integer = 0
        'If chPedido.Checked = True Then

        If ComboComprobante.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(ComboComprobante, "Ingrese un documento de identidad")
            listaErrores += 1
        Else
            ErrorProvider1.SetError(ComboComprobante, Nothing)
        End If

        If TextCodigoPersona.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(TextCodigoPersona, "Ingrese un número de identidad")
            listaErrores += 1
        Else
            ErrorProvider1.SetError(TextCodigoPersona, Nothing)
        End If

        If TextNombres.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(TextNombres, "Ingrese los nombres")
            listaErrores += 1
        Else
            ErrorProvider1.SetError(TextNombres, Nothing)
        End If

        If listaErrores > 0 Then
            ValidarGrabado = False
        Else
            ValidarGrabado = True
        End If
    End Function

#End Region

#Region "Events"
    Private Sub RoundButton26_Click(sender As Object, e As EventArgs) Handles RoundButton26.Click
        Close()
    End Sub

    Private Sub RoundButton25_Click(sender As Object, e As EventArgs) Handles RoundButton25.Click
        Try
            If ValidarGrabado() Then
                GrabarPersona()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TextCodigoPersona_TextChanged(sender As Object, e As EventArgs) Handles TextCodigoPersona.TextChanged

    End Sub

    Private Sub TextCodigoPersona_KeyDown(sender As Object, e As KeyEventArgs) Handles TextCodigoPersona.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If TextCodigoPersona.Text.Trim.Length > 0 Then
                GetConsultarDNIReniec(TextCodigoPersona.Text.Trim)
            End If
        End If
    End Sub

#End Region
End Class