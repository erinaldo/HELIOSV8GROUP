Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Public Class frmDatosGenerales
    Inherits frmMaster
    Public Property ManipulacionEstado() As String
    Dim IdConfiguraciona As Integer
    Dim IMAGEN As String
    'Dim instance As New Printing.PrinterSettings
    'Dim impresosaPredt As String = instance.PrinterName
    Dim predeterminado As Integer

    Public Sub New()
        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        chLogoCentro.Checked = True
        chNombreComercial.Checked = False

        'If (cboTipo.Text = "Ticket") Then
        '    rbImagenTotal.Visible = False
        '    rbSinImagen.Checked = True

        'ElseIf cboTipo.Text = "A4" Then
        '    rbImagenTotal.Visible = True
        '    rbSinImagen.Checked = True
        '    PnCuentas.Enabled = True
        '    cboFormato.Enabled = True
        'ElseIf cboTipo.Text = "A5" Then
        '    rbImagenTotal.Visible = True
        '    rbSinImagen.Checked = True

        'End If
        pnLogo.Enabled = False
        txtRuc.Text = Gempresas.IdEmpresaRuc
        txtEmpresa.Text = Gempresas.NomEmpresa
        'cboFormato.Text = "A4"
        cargarCombos("A4")
        cboFormato.Text = "1"
    End Sub

    Private Sub cargarCombos(TipoImpresion As String)
        Try
            cboFormato.Items.Clear()
            If (cboTipo.Text = "A4") Then
                cboFormato.Items.Add("1")
                cboFormato.Items.Add("2")
                cboFormato.Items.Add("3")
                cboFormato.Items.Add("4")
                cboFormato.Items.Add("5")
                'cboFormato.Items.Add("6")
            ElseIf (cboTipo.Text = "Ticket") Then
                cboFormato.Items.Add("1")
                cboFormato.Items.Add("2")
                cboFormato.Items.Add("3")
                'cboFormato.Items.Add("4")
                'cboFormato.Items.Add("5")
                'cboFormato.Items.Add("RESTAURANTE")
                'cboFormato.Items.Add("TRANSPORTE")
            ElseIf (cboTipo.Text = "A5") Then
                cboFormato.Items.Add("1")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    Public Sub New(idConfig As Integer)
        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        CargarDatos(idConfig)
        'cargarDatos()
    End Sub

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

    Sub cargarImagenBD(txtFIle As String)
        Try
            'Me.OpenFileDialog1.ShowDialog()
            'If Me.OpenFileDialog1.FileName <> "" Then
            'txtRuta.Text = txtFIle
            IMAGEN = txtFIle
            Dim largo As Integer = IMAGEN.Length
            Dim imagen2 As String
            imagen2 = CStr(Microsoft.VisualBasic.Mid(RTrim(IMAGEN), largo - 2, largo))
            If imagen2 <> "gif" And imagen2 <> "bmp" And imagen2 <> "jpg" And imagen2 <> "jpeg" And imagen2 <> "GIF" And imagen2 <> "BMP" And imagen2 <> "JPG" And imagen2 <> "JPEG" Then
                imagen2 = CStr(Microsoft.VisualBasic.Mid(RTrim(IMAGEN), largo - 3, largo))
                If imagen2 <> "jpeg" And imagen2 <> "JPEG" And imagen2 <> "log1" Then
                    MsgBox("Formato no valido") : Exit Sub
                    If imagen2 <> "log1" Then Exit Sub
                End If
                pcImagen.Load(IMAGEN)
            Else
                pcImagen.Load(IMAGEN)
            End If
            'End If
        Catch ex As Exception

        End Try
        'PictureBox1.Load(IMAGEN)
    End Sub

    Public Sub CargarDatos(idConfig As Integer)
        Dim datosGeneralesSA As New datosGeneralesSA
        Dim objDatosGenrales As New datosGenerales
        objDatosGenrales = datosGeneralesSA.UbicaEmpresaID(idConfig)

        If (Not IsNothing(objDatosGenrales)) Then

            If (objDatosGenrales.formatoImpresion = "A4") Then
                cboTipo.Text = "A4"
                'PnCuentas.Enabled = True
                cboFormato.Enabled = True
                cboFormato.Text = objDatosGenrales.formato
            ElseIf (objDatosGenrales.formatoImpresion = "TK") Then
                cboFormato.Enabled = True
                cboTipo.Text = "Ticket"
                cboFormato.Text = objDatosGenrales.formato
            ElseIf (objDatosGenrales.formatoImpresion = "A5") Then
                cboTipo.Text = "A5"
                cboFormato.Text = objDatosGenrales.formato
            End If


            '//LLAMA COMO ES LA IMPRESION CON LOGO SIN LOGO Y/O LOGO TOTAL
            Select Case objDatosGenrales.formaImpresion
                Case "CI"
                    rbConImagen.Checked = True
                    rbSinImagen.Checked = False
                    rbImagenTotal.Checked = False
                Case "IT"
                    rbConImagen.Checked = False
                    rbSinImagen.Checked = False
                    rbImagenTotal.Checked = True
                Case "SI"
                    rbConImagen.Checked = False
                    rbSinImagen.Checked = True
                    rbImagenTotal.Checked = False
            End Select

            IdConfiguraciona = objDatosGenrales.idConfiguracion
            txtEmpresa.Text = objDatosGenrales.razonSocial
            txtRuc.Text = objDatosGenrales.ruc
            If (Not IsNothing(objDatosGenrales.nombreCorto)) Then
                If (objDatosGenrales.nombreCorto.Length > 0) Then
                    chNombreComercial.Checked = True
                    txtNombreCorto.Text = objDatosGenrales.nombreCorto
                End If
            End If

            txtDireccion.Text = objDatosGenrales.direccionPrincipal
            txtDireccion2.Text = objDatosGenrales.direccionSecudaria
            txtTelefono1.Text = objDatosGenrales.telefono1
            txtTelefono2.Text = objDatosGenrales.telefono2
            txtTelefono3.Text = objDatosGenrales.telefono3
            txtTelefono4.Text = objDatosGenrales.telefono4
            txtCorreo.Text = objDatosGenrales.e_mail
            txtPassword.Text = objDatosGenrales.password
            txtPublicidad.Text = objDatosGenrales.publicidad
            txtFormato.Text = objDatosGenrales.nombreGiro
            txtNroImpresion.Value = objDatosGenrales.nroImpresion
            predeterminado = objDatosGenrales.predeterminado
            txtCuentasSoles.Text = objDatosGenrales.nroCuentaSoles
            txtCuentasDolares.Text = objDatosGenrales.nroCuentaDolares
            txtCuentasSoles2.Text = objDatosGenrales.nroCuentaSoles2
            txtCuentasDolares2.Text = objDatosGenrales.nroCuentaDolares2

            txtDescripcion.Text = objDatosGenrales.glosario

            If (Not IsNothing(objDatosGenrales.logo)) Then
                cargarImagenBD(objDatosGenrales.logo)
                txtRuta.Text = objDatosGenrales.logo
            End If

            If (objDatosGenrales.posicionLogo = "CT") Then
                chLogoCentro.Checked = True
                chLogoIzq.Checked = False
            ElseIf (objDatosGenrales.posicionLogo = "IZ") Then
                chLogoIzq.Checked = True
                chLogoCentro.Checked = False
            End If

            Select Case objDatosGenrales.nombreImpresion
                Case "R"
                    chCuadrado.Checked = False
                    chRectangular.Checked = True
                Case "C"
                    chCuadrado.Checked = True
                    chRectangular.Checked = False
            End Select

            If (txtRuta.Text.Length > 0) Then
                pnLogo.Enabled = True
            Else
                pnLogo.Enabled = False
            End If

            ManipulacionEstado = ENTITY_ACTIONS.UPDATE
        Else
            ManipulacionEstado = ENTITY_ACTIONS.INSERT
        End If

    End Sub

    Public Sub GrabarEmpresa()
        Dim objDatosGenerales As New datosGenerales
        Dim datosGeneralesSA As New datosGeneralesSA
        Try
            'Se asigna cada uno de los datos registrados
            objDatosGenerales.idEmpresa = Gempresas.IdEmpresaRuc   ' Trim(txtCodigoDocumento.Text)
            objDatosGenerales.idEstablecimiento = GEstableciento.IdEstablecimiento
            objDatosGenerales.idclientespk = Gempresas.IDCliente
            objDatosGenerales.razonSocial = txtEmpresa.Text
            objDatosGenerales.ruc = txtRuc.Text
            objDatosGenerales.direccionPrincipal = txtDireccion.Text
            objDatosGenerales.direccionSecudaria = txtDireccion2.Text
            objDatosGenerales.telefono1 = txtTelefono1.Text
            objDatosGenerales.telefono2 = txtTelefono2.Text
            objDatosGenerales.telefono3 = txtTelefono3.Text
            objDatosGenerales.telefono4 = txtTelefono4.Text
            objDatosGenerales.e_mail = txtCorreo.Text
            objDatosGenerales.password = txtPassword.Text
            objDatosGenerales.logo = txtRuta.Text
            objDatosGenerales.publicidad = txtPublicidad.Text
            objDatosGenerales.nroCuentaSoles = txtCuentasSoles.Text
            objDatosGenerales.nroCuentaDolares = txtCuentasDolares.Text
            objDatosGenerales.nroCuentaSoles2 = txtCuentasSoles2.Text
            objDatosGenerales.nroCuentaDolares2 = txtCuentasDolares2.Text
            objDatosGenerales.glosario = txtDescripcion.Text
            objDatosGenerales.nombreGiro = txtFormato.Text
            'Solo una impresion

            If (cboTipo.Text = "A4") Then
                objDatosGenerales.formatoImpresion = "A4"
                objDatosGenerales.formato = cboFormato.Text
            ElseIf (cboTipo.Text = "Ticket") Then
                objDatosGenerales.formatoImpresion = "TK"
                objDatosGenerales.formato = cboFormato.Text
            ElseIf (cboTipo.Text = "A5") Then
                objDatosGenerales.formatoImpresion = "A5"

            End If
            'End If

            If (chNombreComercial.Checked = True) Then
                objDatosGenerales.nombreCorto = txtNombreCorto.Text
                objDatosGenerales.tipoImpresion = "S"
            ElseIf (chNombreComercial.Checked = False) Then
                objDatosGenerales.nombreCorto = String.Empty
                objDatosGenerales.tipoImpresion = "N"
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

            '//mANIPULAR EL TIPO DE LOGO
            ' CI - CON IMAGEN 
            'SL - SIN IMAGEN
            'IT - IMAGEN TOTAL

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
            CustomListaDatosGenerales = datosGeneralesSA.UbicaEmpresaFull(New datosGenerales With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento}).ToList
            MessageBox.Show("Datos generales registrado!", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        Catch ex As Exception
            'Manejo de errores
            MessageBox.Show(ex.Message)
            'lblEstado.Image = My.Resources.warning2
        End Try
    End Sub

    Public Sub updateDatos()
        Dim objDatosGenerales As New datosGenerales
        Dim datosGeneralesSA As New datosGeneralesSA
        Try
            objDatosGenerales.idConfiguracion = IdConfiguraciona
            objDatosGenerales.idEmpresa = Gempresas.IdEmpresaRuc   ' Trim(txtCodigoDocumento.Text)
            objDatosGenerales.idEstablecimiento = GEstableciento.IdEstablecimiento
            objDatosGenerales.idclientespk = Gempresas.IDCliente
            objDatosGenerales.razonSocial = txtEmpresa.Text
            objDatosGenerales.ruc = txtRuc.Text
            objDatosGenerales.direccionPrincipal = txtDireccion.Text
            objDatosGenerales.direccionSecudaria = txtDireccion2.Text
            objDatosGenerales.telefono1 = txtTelefono1.Text
            objDatosGenerales.telefono2 = txtTelefono2.Text
            objDatosGenerales.telefono3 = txtTelefono3.Text
            objDatosGenerales.telefono4 = txtTelefono4.Text
            objDatosGenerales.e_mail = txtCorreo.Text
            objDatosGenerales.password = txtPassword.Text
            objDatosGenerales.logo = txtRuta.Text
            objDatosGenerales.publicidad = txtPublicidad.Text
            objDatosGenerales.nroCuentaSoles = txtCuentasSoles.Text
            objDatosGenerales.nroCuentaDolares = txtCuentasDolares.Text
            objDatosGenerales.nroCuentaSoles2 = txtCuentasSoles2.Text
            objDatosGenerales.nroCuentaDolares2 = txtCuentasDolares2.Text
            objDatosGenerales.glosario = txtDescripcion.Text
            objDatosGenerales.nombreGiro = txtFormato.Text
            'Solo una impresion

            If (cboTipo.Text = "A4") Then
                objDatosGenerales.formatoImpresion = "A4"
                objDatosGenerales.formato = cboFormato.Text
            ElseIf (cboTipo.Text = "Ticket") Then
                objDatosGenerales.formatoImpresion = "TK"
                objDatosGenerales.formato = cboFormato.Text
            ElseIf (cboTipo.Text = "A5") Then
                objDatosGenerales.formatoImpresion = "A5"

            End If
            'End If

            If (chNombreComercial.Checked = True) Then
                objDatosGenerales.nombreCorto = txtNombreCorto.Text
                objDatosGenerales.tipoImpresion = "S"
            ElseIf (chNombreComercial.Checked = False) Then
                objDatosGenerales.nombreCorto = String.Empty
                objDatosGenerales.tipoImpresion = "N"
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

            '//mANIPULAR EL TIPO DE LOGO
            ' CI - CON IMAGEN 
            'SL - SIN IMAGEN
            'IT - IMAGEN TOTAL

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

            datosGeneralesSA.updateDatos(objDatosGenerales)
            CustomListaDatosGenerales = datosGeneralesSA.UbicaEmpresaFull(New datosGenerales With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento})
            MessageBox.Show("Datos generales actualizados!", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        Catch ex As Exception
            'Manejo de errores
            MessageBox.Show(ex.Message)
            'lblEstado.Image = My.Resources.warning2
        End Try
    End Sub

    'Sub ImprimirTicketA4()
    '    Dim a As Ticket = New Ticket


    '    Dim lista As New List(Of String)

    '    Dim gravMN As Decimal = 0
    '    Dim gravME As Decimal = 0
    '    Dim ExoMN As Decimal = 0
    '    Dim ExoME As Decimal = 0
    '    Dim InaMN As Decimal = 0
    '    Dim InaME As Decimal = 0

    '    Dim tipoComprobante As String


    '    If (txtRuta.Text.Length > 0) Then
    '        ' Logo de la Empresa
    '        a.HeaderImage = Image.FromFile(txtRuta.Text)
    '    End If

    '    Select Case rbConImagen.Checked
    '        Case True
    '            If (chLogoCentro.Checked = True) Then
    '                If (chCuadrado.Checked = True) Then
    '                    a.tipoImagen = True
    '                    a.tipoLogo = "CR"
    '                ElseIf (chRectangular.Checked = True) Then
    '                    a.tipoImagen = False
    '                    a.tipoLogo = "CR"
    '                End If
    '            ElseIf (chLogoCentro.Checked = False) Then

    '                If (chCuadrado.Checked = True) Then
    '                    a.tipoImagen = True
    '                    a.tipoLogo = "IZ"
    '                ElseIf (chRectangular.Checked = True) Then
    '                    a.tipoImagen = False
    '                    a.tipoLogo = "IZ"
    '                End If
    '            End If
    '        Case False
    '            a.tipoLogo = "SL"
    '    End Select



    '    'Direccion de La empresa general
    '    If (chNombreComercial.Checked = True) Then
    '        a.tipoEncabezado = True
    '        a.AnadirLineaEmpresa(txtNombreCorto.Text)
    '        a.AnadirLineaNombrePropietario(txtEmpresa.Text)
    '    ElseIf (chNombreComercial.Checked = False) Then
    '        a.tipoEncabezado = False
    '        a.AnadirLineaEmpresa(txtEmpresa.Text)

    '    End If

    '    If (txtPublicidad.Text.Length > 0) Then
    '        a.tipoPublicidad = True
    '        a.AnadirLineaNombrePublidad(txtPublicidad.Text)
    '    Else
    '        a.tipoPublicidad = False
    '    End If

    '    'a.TextoIzquierda("R.U.C.: " & txtRuc.Text)

    '    ''Logo de la Empresa
    '    'a.HeaderImage = Image.FromFile("C:\LogosSistema\images.png")

    '    ''Direccion de La empresa general

    '    'a.AnadirLineaEmpresa(txtNombreCorto.Text)
    '    'a.AnadirLineaNombrePropietario(txtEmpresa.Text)

    '    'direccion de la empresa
    '    a.TextoIzquierda("Domicilio fiscal: " & txtDireccion.Text)
    '    a.TextoIzquierda("E. Anexo: " & txtDireccion2.Text)
    '    'Telefono de la empresa

    '    If (txtTelefono1.Text.Length > 0 And txtTelefono2.Text.Length = 0 And txtTelefono3.Text.Length = 0 And txtTelefono4.Text.Length = 0) Then
    '        a.TextoIzquierda("Telf: " & txtTelefono1.Text)
    '    ElseIf (txtTelefono1.Text.Length > 0 And txtTelefono2.Text.Length > 0 And txtTelefono3.Text.Length = 0 And txtTelefono4.Text.Length = 0) Then
    '        a.TextoIzquierda("Telf: " & txtTelefono1.Text & " - " & txtTelefono2.Text)
    '    ElseIf (txtTelefono1.Text.Length > 0 And txtTelefono2.Text.Length > 0 And txtTelefono3.Text.Length > 0 And txtTelefono4.Text.Length = 0) Then
    '        a.TextoIzquierda("Telf: " & txtTelefono1.Text & " - " & txtTelefono2.Text & " - " & txtTelefono3.Text)
    '    ElseIf (txtTelefono1.Text.Length > 0 And txtTelefono2.Text.Length > 0 And txtTelefono3.Text.Length > 0 And txtTelefono4.Text.Length > 0) Then
    '        a.TextoIzquierda("Telf: " & txtTelefono1.Text & " - " & txtTelefono2.Text & " - " & txtTelefono3.Text & " - " & txtTelefono4.Text)
    '    End If


    '    a.AnadirLineaCaracteresFactura(txtRuc.Text, "F001" & " - " & CStr("1").PadLeft(8, "0"c), "FACTURA ELECTRONICA")
    '    'nombreComprabante = "FACTURA ELECTRONICA" & "F001" & " - " & CStr("1").PadLeft(8, "0"c)
    '    tipoComprobante = "2"


    '    'a.TextoDerecha("RUC: " & "12345678911")
    '    'Numero de Ruc y Numeracion


    '    'Fecha de Factura
    '    'Lugar de la factura
    '    'Nombre del cliente
    '    'direccion del cliente
    '    'numero del cliente
    '    'direccion de entrega
    '    'tipo moneda de la empresa
    '    'telefono de la empresa
    '    a.AnadirLineaCaracteresDatosGEnerales(Date.Now, "Huancayo - Perù", "Nombre del Cliente", "Direccion del domicilio del cliente", "", "# Documento", "PEN", "# Telefono")


    '    '*********************** TODO LOS DETALLES DE LOS ITEM *********************
    '    'CODIGO
    '    'DESCRIPCION
    '    'CANTIDAD
    '    'UM
    '    'VALOR VENTA UNITARIO
    '    'DESCUENTO
    '    'VALOR DE VENTA TOTAL
    '    'OTROS CARGOS
    '    'IMPUESTOS
    '    'PRECIO DE VENTA
    '    'VALOR TOTAL


    '    a.AnadirLineaElementosFactura("1", "Nombre Producto", "1.000", "UND", "1.00", "0.00", "1.00", "0.00", "1.00", "1.00", "1.00")
    '    'ticket.AgregaArticuloV2(i.nombreItem, String.Format("{0:0.00}", i.monto1), String.Format("{0:0.00}", i.importeMN / i.monto1), i.importeMN)


    '    '********************************** RESUMEN GENERAL DE LA FACTURA **************************
    '    'GRATUITAS
    '    a.AnadirDatosGenerales("S/", "0.00")
    '    'EXONERADAS
    '    a.AnadirDatosGenerales("S/", ExoMN)
    '    'INAFECTA
    '    a.AnadirDatosGenerales("S/", InaMN)
    '    'GRAVADA
    '    a.AnadirDatosGenerales("S/", gravMN)
    '    'TOTAL DESCUENTO
    '    a.AnadirDatosGenerales("S/", "0.00")
    '    'I.S.C.
    '    a.AnadirDatosGenerales("S/", "0.00")
    '    'I.G.V
    '    a.AnadirDatosGenerales("S/", 0.00)
    '    'IMPORTE TOTAL
    '    a.AnadirDatosGenerales("S/", "1.00")
    '    'DESCRIPCION DEL IMPORTE TOTAL EN LETRAS
    '    a.AnadirLineaTotalFactura("1.00")
    '    'IMPRIMIR LA FACTUIRA

    '    Select Case tipoComprobante
    '        Case "1"
    '            a.tipoComprobante = "1"
    '            'enviarCorreo("maych_1@hotmail.com", "maykol_1_1_1", "maych_1@hotmail.com", "Texto Prueba", "Factura", "", NombreNumero)
    '            'a.GuardanImpresion("Microsoft Print to PDF", nombreComprabante, "maych_1@hotmail.com", "maykol_1_1_1", "maych_1@hotmail.com", "Texto Prueba", "Factura")
    '            a.ImprimeTicket(cboImpresorasPrueba.Text)
    '        Case "2"
    '            a.tipoComprobante = "2"
    '            'enviarCorreo("maych_1@hotmail.com", "maykol_1_1_1", "maych_1@hotmail.com", "Texto Prueba", "Factura", "", NombreNumero)
    '            'a.GuardanImpresion("Microsoft Print to PDF", nombreComprabante, "maych_1@hotmail.com", "maykol_1_1_1", "maych_1@hotmail.com", "Texto Prueba", "Factura")
    '            a.ImprimeTicket(cboImpresorasPrueba.Text)
    '    End Select

    'End Sub

    Sub ImprimirTicket()
        Dim a As TickeNuevoFormato = New TickeNuevoFormato
        'a.HeaderImage = "C:\Documents and Settings\Administrador\Mis documentos\COMPU.jpg" 
        Dim gravMN As Decimal = 0
        Dim gravME As Decimal = 0
        Dim ExoMN As Decimal = 0
        Dim ExoME As Decimal = 0
        Dim InaMN As Decimal = 0
        Dim InaME As Decimal = 0
        Dim precioUnit As Decimal = 0
        Dim PrecioTotal As Decimal = 0
        Dim entidadSA As New entidadSA
        Dim documentoSA As New documentoVentaAbarrotesSA
        Dim documentoDetSA As New documentoVentaAbarrotesDetSA

        'Dim nombreCliente As String
        'Dim rucCliente As String
        If (txtRuta.Text.Length > 0) Then
            ' Logo de la Empresa
            a.HeaderImage = Image.FromFile(txtRuta.Text)
        End If

        If (chCuadrado.Checked = True) Then
            a.tipoImagen = True
        ElseIf (chRectangular.Checked = True) Then
            a.tipoImagen = False
        End If

        'Direccion de La empresa general
        If (chNombreComercial.Checked = True) Then
            a.tipoEncabezado = True
            a.AnadirLineaEmpresa(txtNombreCorto.Text)
            a.AnadirLineaNombrePropietario(txtEmpresa.Text)
        ElseIf (chNombreComercial.Checked = False) Then
            a.tipoEncabezado = False
            a.AnadirLineaEmpresa(txtEmpresa.Text)

        End If

        If (txtPublicidad.Text.Length > 0) Then
            a.tipoPublicidad = True
            a.AnadirLineaNombrePublidad(txtPublicidad.Text)
        Else
            a.tipoPublicidad = False
        End If

        a.TextoIzquierda("R.U.C.: " & txtRuc.Text)
        'direccion de la empresa
        a.TextoIzquierda("Domicilio fiscal: " & txtDireccion.Text)

        If (txtDireccion2.Text.Length > 0) Then
            a.TextoIzquierda("E. Anexo: " & txtDireccion2.Text)
        End If

        'Telefono de la empresa

        If (txtTelefono1.Text.Length > 0 And txtTelefono2.Text.Length = 0 And txtTelefono3.Text.Length = 0 And txtTelefono4.Text.Length = 0) Then
            a.TextoIzquierda("Telf: " & txtTelefono1.Text)
        ElseIf (txtTelefono1.Text.Length > 0 And txtTelefono2.Text.Length > 0 And txtTelefono3.Text.Length = 0 And txtTelefono4.Text.Length = 0) Then
            a.TextoIzquierda("Telf: " & txtTelefono1.Text & " - " & txtTelefono2.Text)
        ElseIf (txtTelefono1.Text.Length > 0 And txtTelefono2.Text.Length > 0 And txtTelefono3.Text.Length > 0 And txtTelefono4.Text.Length = 0) Then
            a.TextoIzquierda("Telf: " & txtTelefono1.Text & " - " & txtTelefono2.Text & " - " & txtTelefono3.Text)
        ElseIf (txtTelefono1.Text.Length > 0 And txtTelefono2.Text.Length > 0 And txtTelefono3.Text.Length > 0 And txtTelefono4.Text.Length > 0) Then
            a.TextoIzquierda("Telf: " & txtTelefono1.Text & " - " & txtTelefono2.Text & " - " & txtTelefono3.Text & " - " & txtTelefono4.Text)
        End If


        a.AnadirLineaCaracteresDatosGEnerales(CStr(Date.Now), "FACTURA ELECTRONICA   N° " & "F001" & "-" & "00000001", "Nombre Cliente", "Direccion Cliente", "", "# Doc. Cliente", "PEN", "966557413")

        a.AnadirLineaElementosFactura("1", "Nombre Producto", "UND", String.Format("{0:0.00}", "1.00"), String.Format("{0:0.00}", "1.00"))


        a.AnadirDatosGenerales("S/", 0.00)
        a.AnadirDatosGenerales("S/", 0.00)
        a.AnadirDatosGenerales("S/", 0.00)
        a.AnadirDatosGenerales("S/", 0.00)
        a.AnadirDatosGenerales("S/", String.Format("{0:0.00}", 1.0))


        '//Y por ultimo llamamos al metodo PrintTicket para imprimir el ticket, este metodo necesita un 
        '//parametro de tipo string que debe de ser el nombre de la impresora. 
        a.ImprimeTicket(cboImpresorasPrueba.Text, 1)

    End Sub


    Private Sub Panel7_Click(sender As Object, e As EventArgs)
        cargarImagen()
        If (txtRuta.Text = "OpenFileDialog1") Then
            txtRuta.Clear()
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipo.SelectedIndexChanged
        If (cboTipo.Text = "A4") Then
            rbImagenTotal.Visible = True
            rbSinImagen.Checked = True
            'PnCuentas.Enabled = True
            cboFormato.Enabled = True
            cargarCombos("A4")
        ElseIf (cboTipo.Text = "Ticket") Then
            rbImagenTotal.Visible = False
            rbSinImagen.Checked = True
            'PnCuentas.Enabled = False
            cboFormato.Enabled = True
            cargarCombos("Ticket")
        ElseIf (cboTipo.Text = "A5") Then
            rbImagenTotal.Visible = True
            rbSinImagen.Checked = True
            'PnCuentas.Enabled = False
            cboFormato.Enabled = False
            cargarCombos("A5")
        End If
    End Sub

    Private Sub chNombreComercial_CheckedChanged(sender As Object, e As EventArgs) Handles chNombreComercial.CheckedChanged
        If (chNombreComercial.Checked = True) Then
            txtNombreCorto.Enabled = True
            txtNombreCorto.Clear()
        ElseIf (chNombreComercial.Checked = False) Then
            txtNombreCorto.Enabled = False
            txtNombreCorto.Clear()
        End If
    End Sub

    Private Sub ButtonAdv3_Click_1(sender As Object, e As EventArgs) Handles ButtonAdv3.Click
        pnPrueba.Visible = False
    End Sub

    Private Sub Panel7_Click_1(sender As Object, e As EventArgs) Handles Panel7.Click
        cargarImagen()
        If (txtRuta.Text = "OpenFileDialog1") Then
            txtRuta.Clear()
        End If
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
    Private Sub chLogoIzq_CheckedChanged(sender As Object, e As EventArgs) Handles chLogoIzq.CheckedChanged
        If (chLogoIzq.Checked = True) Then
            chLogoIzq.Checked = True
            chLogoCentro.Checked = False
        Else
            chLogoIzq.Checked = False
            chLogoCentro.Checked = True
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

    Private Sub rbSinImagen_CheckedChanged(sender As Object, e As EventArgs) Handles rbSinImagen.CheckedChanged
        Try
            If (rbSinImagen.Checked = True) Then
                rbSinImagen.Checked = True
                rbConImagen.Checked = False
                rbImagenTotal.Checked = False
                pnLogo.Visible = False
                txtRuta.Text = String.Empty
                pcImagen.Image = Nothing
                'grupoRazonSocial.Enabled = True
                GrupoDatosComplemetarios.Enabled = True
                chCuadrado.Enabled = False
                chRectangular.Enabled = False
                chLogoIzq.Enabled = False
                chLogoCentro.Enabled = False
                Panel7.Enabled = False
                'Else
                '    rbSinImagen.Checked = True
                '    rbConImagen.Checked = False
                '    rbImagenTotal.Checked = False
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
                'grupoRazonSocial.Enabled = True
                GrupoDatosComplemetarios.Enabled = True
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
                'grupoRazonSocial.Enabled = False
                GrupoDatosComplemetarios.Enabled = False
                'txtEmpresa.Text = String.Empty
                'txtNombreCorto.Text = String.Empty
                rbSinImagen.Checked = False
                rbConImagen.Checked = False
                chCuadrado.Enabled = False
                chRectangular.Enabled = False
                chLogoIzq.Enabled = False
                chLogoCentro.Enabled = False
                Panel7.Enabled = True
                'Else
                '    rbImagenTotal.Checked = True
                '    rbSinImagen.Checked = False
                '    rbConImagen.Checked = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs)
        Dispose()
    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub RoundButton21_Click(sender As Object, e As EventArgs) Handles RoundButton21.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            If Not txtEmpresa.Text.Trim.Length > 0 Then
                MessageBox.Show("Ingrese el nombre de la empresa", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If

            If Not txtRuc.Text.Trim.Length > 0 Then
                MessageBox.Show("ingrese Ruc", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If

            If Not cboFormato.Text.Trim.Length > 0 Then
                MessageBox.Show("Ingrese el formato", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Cursor = Cursors.Arrow
                Exit Sub

            End If

            If Not cboTipo.Text.Trim.Length > 0 Then
                MessageBox.Show("Ingrese el tipo de formato", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Cursor = Cursors.Arrow
                Exit Sub

            End If

            If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
                GrabarEmpresa()
                Dispose()
            Else
                updateDatos()
                Dispose()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub RoundButton22_Click(sender As Object, e As EventArgs) Handles RoundButton22.Click
        Dispose()
    End Sub

    Private Sub RoundButton23_Click(sender As Object, e As EventArgs) Handles RoundButton23.Click

    End Sub
End Class