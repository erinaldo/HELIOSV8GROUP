Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General.Constantes

Public Class Tab_FormatoImpresion
    Public Property ManipulacionEstado() As String
    Dim IMAGEN As String
    Dim IdConfiguracion As Integer

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        rbImagenTotal.Visible = True
        rbSinImagen.Checked = True
        cboFormato.Enabled = True

        cboFormato.Items.Clear()
        cboFormato.Items.Add("1")
        cboFormato.Items.Add("2")
        cboFormato.Items.Add("3")
        cboFormato.Items.Add("4")

    End Sub


#Region "METODOS"
    Sub cargarImagen()
        Try
            Me.OpenFileDialog1.ShowDialog()
            If Me.OpenFileDialog1.FileName <> "" Then
                txtRuta.Text = Me.OpenFileDialog1.FileName
                IMAGEN = OpenFileDialog1.FileName
                Dim largo As Integer = IMAGEN.Length
                Dim imagen2 As String
                imagen2 = CStr(Microsoft.VisualBasic.Mid(RTrim(IMAGEN), largo - 2, largo))
                If imagen2 <> "gif" And imagen2 <> "bmp" And imagen2 <> "jpg" And imagen2 <> "jpeg" And imagen2 <> "GIF" And imagen2 <> "BMP" And imagen2 <> "JPG" And imagen2 <> "JPEG" Then
                    imagen2 = CStr(Microsoft.VisualBasic.Mid(RTrim(IMAGEN), largo - 3, largo))
                    If imagen2 <> "jpeg" And imagen2 <> "JPEG" And imagen2 <> "log1" Then
                        txtRuta.Clear()
                        MsgBox("Formato no valido") : Exit Sub
                        If imagen2 <> "log1" Then Exit Sub
                    End If
                    pcImagen.Load(IMAGEN)

                Else
                    pcImagen.Load(IMAGEN)
                End If
            End If
        Catch ex As Exception

        End Try
        'PictureBox1.Load(IMAGEN)
    End Sub

    Public Sub GrabarEmpresa()
        Dim objDatosGenerales As New datosGenerales
        Dim datosGeneralesSA As New datosGeneralesSA
        Try
            'Se asigna cada uno de los datos registrados
            objDatosGenerales.idEmpresa = Gempresas.IdEmpresaRuc   ' Trim(txtCodigoDocumento.Text)
            objDatosGenerales.idEstablecimiento = GEstableciento.IdEstablecimiento
            objDatosGenerales.idclientespk = Gempresas.IDCliente
            objDatosGenerales.razonSocial = Gempresas.NomEmpresa
            objDatosGenerales.ruc = Gempresas.IdEmpresaRuc
            objDatosGenerales.direccionPrincipal = Gempresas.direccionEmpresa
            'objDatosGenerales.direccionSecudaria = txtDireccion2.Text
            objDatosGenerales.telefono1 = Gempresas.TelefonoEmpresa
            'objDatosGenerales.telefono2 = txtTelefono2.Text
            'objDatosGenerales.telefono3 = txtTelefono3.Text
            'objDatosGenerales.telefono4 = txtTelefono4.Text
            'objDatosGenerales.e_mail = txtCorreo.Text
            'objDatosGenerales.password = txtPassword.Text
            objDatosGenerales.logo = txtRuta.Text
            'objDatosGenerales.publicidad = txtPublicidad.Text
            'objDatosGenerales.nroCuentaSoles = txtCuentasSoles.Text
            'objDatosGenerales.nroCuentaDolares = txtCuentasDolares.Text
            'objDatosGenerales.nroCuentaSoles2 = txtCuentasSoles2.Text
            'objDatosGenerales.nroCuentaDolares2 = txtCuentasDolares2.Text
            'objDatosGenerales.glosario = txtDescripcion.Text
            objDatosGenerales.nombreGiro = txtFormato.Text
            'objDatosGenerales.condicionImpresion = txtNroCuentaEspecial.Text
            'Solo una impresion

            If (cboTipo.Text = "A4") Then
                objDatosGenerales.formatoImpresion = "A4"
                objDatosGenerales.formato = cboFormato.Text
            ElseIf (cboTipo.Text = "Ticket") Then
                objDatosGenerales.formatoImpresion = "TK"
            ElseIf (cboTipo.Text = "A5") Then
                objDatosGenerales.formatoImpresion = "A5"

            End If

            If (chLogoCentro.Checked = True) Then
                objDatosGenerales.posicionLogo = "CT"
            ElseIf (chLogoIzq.Checked = True) Then
                objDatosGenerales.posicionLogo = "IZ"
            Else
                objDatosGenerales.posicionLogo = "NN"
            End If


            If (chCuadrado.Checked = True) Then
                objDatosGenerales.nombreImpresion = "C"
            ElseIf (chRectangular.Checked = True) Then
                objDatosGenerales.nombreImpresion = "R"
            End If


            If (rbConImagen.Checked = True) Then
                objDatosGenerales.formaImpresion = "CI"
            ElseIf (rbSinImagen.Checked = True) Then
                objDatosGenerales.formaImpresion = "SL"
            ElseIf (rbImagenTotal.Checked = True) Then
                objDatosGenerales.formaImpresion = "IT"
                objDatosGenerales.posicionLogo = "IT"
            End If

            objDatosGenerales.nroImpresion = txtNroImpresion.Value
            objDatosGenerales.predeterminado = 0
            objDatosGenerales.usuarioActualizacion = usuario.UsuarioActualizacion
            objDatosGenerales.fechaActualizacion = DateTime.Now
            datosGeneralesSA.InsertEmpresa(objDatosGenerales)
            MessageBox.Show("Datos generales registrado!", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


#End Region

    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        Try
            If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
                GrabarEmpresa()
                Dispose()
            Else
                'updateDatos()
                Dispose()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Panel7_Paint(sender As Object, e As PaintEventArgs) Handles Panel7.Paint
        Try
            cargarImagen()
            If (txtRuta.Text = "OpenFileDialog1") Then
                txtRuta.Clear()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cboTipo_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboTipo.SelectionChangeCommitted
        If (cboTipo.SelectedItem = "A4") Then
            rbImagenTotal.Visible = True
            rbSinImagen.Checked = True
            cboFormato.Enabled = True

            cboFormato.Items.Clear()
            cboFormato.Items.Add("1")
            cboFormato.Items.Add("2")
            cboFormato.Items.Add("3")
            cboFormato.Items.Add("4")
        ElseIf (cboTipo.SelectedItem = "Ticket") Then
            rbImagenTotal.Visible = False
            rbSinImagen.Checked = True
            cboFormato.Enabled = True

            cboFormato.Items.Clear()
            cboFormato.Items.Add("1")
            cboFormato.Items.Add("2")
            cboFormato.Items.Add("3")
        ElseIf (cboTipo.SelectedItem = "A5") Then
            rbImagenTotal.Visible = True
            rbSinImagen.Checked = True
            cboFormato.Enabled = False

            cboFormato.Items.Clear()
            cboFormato.Items.Add("1")
            'cboFormato.Items.Add("2")
            'cboFormato.Items.Add("3")
            'cboFormato.Items.Add("4")
        End If
    End Sub

    Private Sub rbSinImagen_CheckedChanged(sender As Object, e As EventArgs) Handles rbSinImagen.CheckedChanged
        Try
            If (rbSinImagen.Checked = True) Then
                rbSinImagen.Checked = True
                rbConImagen.Checked = False
                rbImagenTotal.Checked = False
                pnLogo.Visible = False
                txtRuta.Text = String.Empty
                pcImagen.Image = Nothing
                chCuadrado.Enabled = False
                chRectangular.Enabled = False
                chLogoIzq.Enabled = False
                chLogoCentro.Enabled = False
                Panel7.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub rbConImagen_CheckedChanged(sender As Object, e As EventArgs) Handles rbConImagen.CheckedChanged
        Try
            If (rbConImagen.Checked = True) Then
                rbConImagen.Checked = True
                pnLogo.Visible = True
                txtRuta.Text = String.Empty
                pcImagen.Image = Nothing
                rbSinImagen.Checked = False
                rbImagenTotal.Checked = False
                pnLogo.Enabled = True
                chCuadrado.Enabled = True
                chRectangular.Enabled = True
                chLogoIzq.Enabled = True
                chLogoCentro.Enabled = True
                Panel7.Enabled = True

                Select Case cboTipo.Text
                    Case "Ticket"
                        chLogoCentro.Visible = False
                        chLogoIzq.Visible = False
                        chLogoCentro.Checked = False
                        chLogoIzq.Checked = False
                    Case Else
                        chLogoCentro.Visible = True
                        chLogoIzq.Visible = True
                        chLogoCentro.Checked = True
                        chLogoIzq.Checked = False
                End Select

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub rbImagenTotal_CheckedChanged(sender As Object, e As EventArgs) Handles rbImagenTotal.CheckedChanged
        Try
            If (rbImagenTotal.Checked = True) Then
                rbImagenTotal.Checked = True
                pnLogo.Visible = True
                pnLogo.Enabled = True
                txtRuta.Text = String.Empty
                pcImagen.Image = Nothing
                rbSinImagen.Checked = False
                rbConImagen.Checked = False
                chCuadrado.Enabled = False
                chRectangular.Enabled = False
                chLogoIzq.Enabled = False
                chLogoCentro.Enabled = False
                Panel7.Enabled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub chCuadrado_CheckedChanged(sender As Object, e As EventArgs) Handles chCuadrado.CheckedChanged
        If (chCuadrado.Checked = True) Then
            chCuadrado.Checked = True
            chRectangular.Checked = False
        Else
            chCuadrado.Checked = False
            chRectangular.Checked = True
        End If
    End Sub

    Private Sub chRectangular_CheckedChanged(sender As Object, e As EventArgs) Handles chRectangular.CheckedChanged
        If (chRectangular.Checked = True) Then
            chCuadrado.Checked = False
            chRectangular.Checked = True
        Else
            chCuadrado.Checked = True
            chRectangular.Checked = False
        End If
    End Sub

    Private Sub chLogoCentro_CheckedChanged(sender As Object, e As EventArgs) Handles chLogoCentro.CheckedChanged
        If (chLogoCentro.Checked = True) Then
            chLogoCentro.Checked = True
            chLogoIzq.Checked = False
            chCuadrado.Checked = True
            chRectangular.Checked = False
        Else
            chLogoCentro.Checked = False
            chLogoIzq.Checked = True
        End If
    End Sub

    Private Sub chLogoIzq_CheckedChanged(sender As Object, e As EventArgs) Handles chLogoIzq.CheckedChanged
        If (chLogoIzq.Checked = True) Then
            chLogoIzq.Checked = True
            chLogoCentro.Checked = False
        Else
            chLogoIzq.Checked = False
            chLogoCentro.Checked = True
        End If
    End Sub
End Class
