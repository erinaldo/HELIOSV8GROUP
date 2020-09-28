Imports System.IO
Imports System.Net
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports ProcesosGeneralesCajamiSoft
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports HtmlAgilityPack
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq


Public Class TabP_IdentificacionCliente

    Private Property SelRazon As entidad
    Private Property entidadSA As New entidadSA

    Private Property personaBeneficioSA As New personaBeneficioSA

    Public Property FormPurchase As FormControlHotel

    Public Sub New(formRepPiscina As FormControlHotel)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormPurchase = formRepPiscina
    End Sub


#Region "RUC Consulta"
    Private Function GetConsultarDNIReniec(Dni As String) As String
        Dim CLIENTE As New WebClient
        'Dim PAGINA As Stream = CLIENTE.OpenRead("http://aplicaciones007.jne.gob.pe/srop_publico/Consulta/Afiliado/GetNombresCiudadano?DNI=" & Dni)
        Dim PAGINA As Stream = CLIENTE.OpenRead("http://clientes.reniec.gob.pe/padronElectoral2012/consulta.htm?hTipo=2&hDni=" & Dni)
        Dim LECTOR As New StreamReader(PAGINA)
        Dim MIHTML As String = LECTOR.ReadToEnd
        Dim nombres = String.Empty
        ' Dim array = MIHTML.Split("|")
        Dim posicion = 0
        Dim doc As HtmlAgilityPack.HtmlDocument = New HtmlAgilityPack.HtmlDocument
        doc.LoadHtml(MIHTML)

        For Each node As HtmlTextNode In doc.DocumentNode.SelectNodes("//text()")
            Select Case posicion
                Case 36
                    nombres = node.Text
                    Exit For
                Case 42
                   ' TextDNI.Text = node.Text
                Case 60
                  '  TextProvincia.Text = node.Text
                Case 66
                 '   TextDepartamento.Text = node.Text
                Case 54
                    '   TextDistrito.Text = node.Text
            End Select
            posicion = posicion + 1
        Next


        '  nombres = MIHTML.Replace("|", Space(1))
        Return Trim(nombres)
    End Function

    Private Sub GetConsultaSunatThread(ruc As String)
        SelRazon = New entidad
        Dim nroDoc = ruc.Substring(0, 1).ToString
        If nroDoc = "1" Then

            'getRuc donde ase llama como el company
            Dim sunat As New Helios.Consultas.Sunat.Sunat()
            sunat.GenerateCapchaTemporal()
            Dim valorCapcha = sunat.Decode_CapchaTemporal()
            Dim company As ProcesosJH.DatosRuc = ProcesosJH.ConsultarRUC(ruc, valorCapcha)

            'Dim datosSunat = New Helios.Sunat.Consulta.GetConsultaSunat()
            'Dim company = datosSunat.GetConsultaRuc(ruc)

            '  Dim company = CType(Await SoftPackERP_Sunat.GetRucContribuyenteSPK.GetContribuyente(ruc), SoftPackERP_Sunat.CompanyJuridico)
            If company.Ruc IsNot Nothing Then
                If company.RazonSocial = "ERROR" Then

                Else
                    SelRazon.tipoPersona = "N"
                    SelRazon.tipoDoc = "6"
                    SelRazon.tipoEntidad = "PR"
                    SelRazon.nombreCompleto = company.RazonSocial
                    SelRazon.nombreContacto = company.RazonSocial
                    SelRazon.estado = company.Estado_Contribuyente
                    SelRazon.nrodoc = company.Ruc
                    SelRazon.direccion = company.DireccionDomicilioFiscal
                End If

            Else

            End If
        ElseIf nroDoc = "2" Then
            Dim sunat As New Helios.Consultas.Sunat.Sunat()
            sunat.GenerateCapchaTemporal()
            Dim valorCapcha = sunat.Decode_CapchaTemporal()
            Dim company As ProcesosJH.DatosRuc = ProcesosJH.ConsultarRUC(ruc, valorCapcha)

            'Dim company = CType(Await SoftPackERP_Sunat.GetRucContribuyenteSPK.GetContribuyente(ruc), SoftPackERP_Sunat.CompanyJuridico)
            If company.Ruc IsNot Nothing Then
                'If company.ContribuyenteTipo = "SOCIEDAD ANONIMA CERRADA" Then
                If company.RazonSocial = "ERROR" Then

                Else
                    SelRazon.tipoPersona = "J"
                    SelRazon.tipoDoc = "6"
                    SelRazon.tipoEntidad = "PR"
                    SelRazon.nombreCompleto = company.RazonSocial
                    SelRazon.nombreContacto = company.RazonSocial
                    SelRazon.estado = company.Estado_Contribuyente
                    SelRazon.direccion = company.DireccionDomicilioFiscal
                    SelRazon.nrodoc = company.Ruc

                End If
            Else

            End If
        End If
    End Sub

    Private Sub GrabarEntidadRapidaThread()
        Dim obEntidad As New entidad
        Dim entidadSA As New entidadSA
        Try
            'Se asigna cada uno de los datos registrados
            obEntidad.idEmpresa = Gempresas.IdEmpresaRuc
            obEntidad.idOrganizacion = GEstableciento.IdEstablecimiento
            obEntidad.tipoEntidad = "CL"
            obEntidad.tipoDoc = SelRazon.tipoDoc
            obEntidad.tipoPersona = SelRazon.tipoPersona
            obEntidad.nrodoc = SelRazon.nrodoc
            obEntidad.nombreCompleto = SelRazon.nombreCompleto
            obEntidad.cuentaAsiento = "1213"
            obEntidad.direccion = SelRazon.direccion
            obEntidad.estado = StatusEntidad.Activo
            Dim codx As Integer = entidadSA.GrabarEntidad(obEntidad)

            TextProveedor.Tag = codx
            Dim entidad As New entidad
            entidad.idEntidad = codx
            entidad.nrodoc = TextNumIdentrazon.Text.Trim
            entidad.nombreCompleto = obEntidad.nombreCompleto
            entidad.tipoDoc = obEntidad.tipoDoc
            Me.Tag = entidad

        Catch ex As Exception
            MsgBox("No se pudo grabar el cliente." & vbCrLf & ex.Message, MsgBoxStyle.Critical)
            Me.Tag = Nothing
        End Try
    End Sub

    Private Sub GrabarEntidadRapida()
        Dim obEntidad As New entidad
        Dim entidadSA As New entidadSA
        Try
            'Se asigna cada uno de los datos registrados
            obEntidad.idEmpresa = Gempresas.IdEmpresaRuc
            obEntidad.idOrganizacion = GEstableciento.IdEstablecimiento
            obEntidad.tipoEntidad = "CL"
            obEntidad.tipoDoc = SelRazon.tipoDoc
            obEntidad.tipoPersona = SelRazon.tipoPersona
            obEntidad.nrodoc = SelRazon.nrodoc
            obEntidad.nombreCompleto = TextProveedor.Text.Trim
            obEntidad.cuentaAsiento = "1213"
            obEntidad.direccion = SelRazon.direccion
            obEntidad.estado = StatusEntidad.Activo
            Dim codx As Integer = entidadSA.GrabarEntidad(obEntidad)

            TextProveedor.Tag = codx
            Dim entidad As New entidad
            entidad.idEntidad = codx
            entidad.nrodoc = TextNumIdentrazon.Text.Trim
            entidad.nombreCompleto = obEntidad.nombreCompleto
            entidad.tipoDoc = obEntidad.tipoDoc
            entidad.tipoEntidad = obEntidad.tipoEntidad
            Me.Tag = entidad

        Catch ex As Exception
            'Manejo de errores
            MsgBox("No se pudo grabar el cliente." & vbCrLf & ex.Message, MsgBoxStyle.Critical)
            Me.Tag = Nothing
        End Try
    End Sub

    Private Sub GrabarEnFormBasico()
        Dim f As New frmCrearENtidades
        f.strTipo = TIPO_ENTIDAD.CLIENTE
        f.CaptionLabels(0).Text = "Nuevo cliente"
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        If f.Tag IsNot Nothing Then
            Dim ent = CType(f.Tag, entidad)
            TextNumIdentrazon.Text = ent.nrodoc
            TextProveedor.Text = ent.nombreCompleto
            TextProveedor.Tag = ent.idEntidad
            txtTipo.Text = ent.tipoEntidad

            lblEstadoCliente.Text = "CLIENTE NUEVO"
            lblEstadoCliente.Visible = True

        Else
            TextNumIdentrazon.Text = String.Empty
            TextProveedor.Text = String.Empty
            TextProveedor.Tag = Nothing
            txtTipo.Clear()
            lblEstadoCliente.Visible = False
        End If
    End Sub

    Private Function GetValidarLocalDB(idEntidad As String) As Boolean
        GetValidarLocalDB = False
        Dim entidadSA As New entidadSA

        Dim entidad = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", idEntidad)
        If entidad IsNot Nothing Then
            SelRazon = New entidad
            SelRazon = entidad
            TextProveedor.Text = entidad.nombreCompleto
            TextProveedor.Tag = entidad.idEntidad
            txtTipo.Text = entidad.tipoEntidad

            Select Case entidad.tipoEntidad
                Case "CL"
                    If (entidad.estado = "A") Then
                        lblEstadoCliente.Text = "CLIENTE ACTIVO"
                        lblEstadoCliente.Visible = True
                    Else
                        lblEstadoCliente.Text = "CLIENTE INACTIVO"
                        lblEstadoCliente.Visible = True
                    End If
                Case "CLE"
                    If (entidad.estado = "A") Then
                        lblEstadoCliente.Text = "CLIENTE EXTERNO ACTIVO"
                        lblEstadoCliente.Visible = True
                    Else
                        lblEstadoCliente.Text = "CLIENTE EXTERNO INACTIVO"
                        lblEstadoCliente.Visible = True
                    End If
            End Select

            GetValidarLocalDB = True

            If TextProveedor.Text.Trim.Length > 0 Then
                'TextFiltrar.Select()
                'TextFiltrar.Focus()
            Else
                TextNumIdentrazon.Clear()
                textDireccion.Clear()
                TextNumIdentrazon.Select()
                txtTipo.Select()
                lblEstadoCliente.Visible = False
            End If
        End If
    End Function

    Private Async Sub GetConsultaSunatAsync(ruc As String)
        SelRazon = New entidad
        Dim nroDoc = ruc.Substring(0, 1).ToString
        If nroDoc = "1" Then
            Dim company = CType(Await SoftPackERP_Sunat.GetRucContribuyenteSPK.GetContribuyente(ruc), SoftPackERP_Sunat.CompanyJuridico)
            If company IsNot Nothing Then
                ' If company.ContribuyenteTipo = "PERSONA NATURAL SIN NEGOCIO" Then
                SelRazon.tipoPersona = "N"
                SelRazon.tipoDoc = "6"
                ' End If
                SelRazon.tipoEntidad = "CL"
                SelRazon.nombreCompleto = company.RazonSocial
                TextProveedor.Text = company.RazonSocial
                textDireccion.Text = company.DomicilioFiscal
                SelRazon.nombreContacto = company.RazonSocial
                SelRazon.estado = company.ContribuyenteEstado
                SelRazon.nrodoc = company.Ruc
                SelRazon.direccion = company.DomicilioFiscal
                GrabarEntidadRapida()

            Else
                TextProveedor.Clear()
                textDireccion.Clear()

            End If
        ElseIf nroDoc = "2" Then
            Dim company = CType(Await SoftPackERP_Sunat.GetRucContribuyenteSPK.GetContribuyente(ruc), SoftPackERP_Sunat.CompanyJuridico)
            If company IsNot Nothing Then
                'If company.ContribuyenteTipo = "SOCIEDAD ANONIMA CERRADA" Then
                SelRazon.tipoPersona = "J"
                SelRazon.tipoDoc = "6"
                '  End If
                SelRazon.nombreCompleto = company.RazonSocial
                SelRazon.nombreContacto = company.RazonSocial
                TextProveedor.Text = company.RazonSocial
                textDireccion.Text = company.DomicilioFiscal
                SelRazon.estado = company.ContribuyenteEstado
                SelRazon.direccion = company.DomicilioFiscal
                SelRazon.nrodoc = company.Ruc

                GrabarEntidadRapida()

            Else
                TextProveedor.Clear()
                textDireccion.Clear()

            End If
        End If
        TextNumIdentrazon.ReadOnly = False
    End Sub
#End Region

#Region "Metodos"
    Public Function GetCodigoVendedor() As Helios.Seguridad.Business.Entity.Usuario
        GetCodigoVendedor = Nothing
        Dim f As New FormCodigoVendedor
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        If f.Tag IsNot Nothing Then
            Dim c = CType(f.Tag, Helios.Seguridad.Business.Entity.Usuario)
            GetCodigoVendedor = c
        End If
    End Function
#End Region


    Private Sub TextProveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles TextNumIdentrazon.KeyDown
        'Dim nombres = String.Empty
        'Try

        '    Select Case TextNumIdentrazon.Text.Trim.Length
        '        Case 8 'dni

        '            SelRazon = New entidad

        '            If My.Computer.Network.IsAvailable = True Then

        '                nombres = GetConsultarDNIReniec(TextNumIdentrazon.Text.Trim)

        '                If nombres.Trim.Length > 0 Then

        '                    If nombres = "DNI no encontrado en Padrón Electoral" Then
        '                        TextNumIdentrazon.Clear()
        '                        TextProveedor.Text = String.Empty
        '                        TextProveedor.Tag = Nothing
        '                        textDireccion.Text = String.Empty

        '                        Exit Sub
        '                    End If

        '                    SelRazon.tipoEntidad = "CL"
        '                    SelRazon.nombreCompleto = nombres
        '                    SelRazon.nrodoc = TextNumIdentrazon.Text.Trim
        '                    SelRazon.tipoDoc = "1"
        '                    SelRazon.tipoPersona = "N"
        '                    TextProveedor.Text = nombres

        '                    Dim existeEnDB = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", TextNumIdentrazon.Text.Trim)

        '                    If existeEnDB Is Nothing Then

        '                        Dim existeEnBDHospedado = personaBeneficioSA.UbicarHospedadoPorRucNro(Gempresas.IdEmpresaRuc, TextNumIdentrazon.Text.Trim)

        '                        If existeEnBDHospedado Is Nothing Then
        '                            TextProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        '                            GrabarEntidadRapida()
        '                            lblEstadoCliente.Text = "CLIENTE NUEVO"
        '                            lblEstadoCliente.Visible = True
        '                            txtTipo.Text = "CL"
        '                        Else
        '                            TextProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        '                            TextProveedor.Tag = existeEnBDHospedado.idPersonaBeneficio
        '                            txtTipo.Text = "HP"
        '                            If (existeEnBDHospedado.estado = "A") Then
        '                                lblEstadoCliente.Text = "HOSPEDADO ACTIVO"
        '                                lblEstadoCliente.Visible = True
        '                            Else
        '                                lblEstadoCliente.Text = "HOSPEDADO INACTIVO"
        '                                lblEstadoCliente.Visible = True
        '                            End If
        '                        End If

        '                    Else
        '                        lblEstadoCliente.Text = "CLIENTE"
        '                        TextProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        '                        TextProveedor.Tag = existeEnDB.idEntidad
        '                        Select Case existeEnDB.tipoEntidad
        '                            Case "CL"
        '                                If (existeEnDB.estado = "A") Then
        '                                    lblEstadoCliente.Text = "CLIENTE ACTIVO"
        '                                    lblEstadoCliente.Visible = True
        '                                Else
        '                                    lblEstadoCliente.Text = "CLIENTE INACTIVO"
        '                                    lblEstadoCliente.Visible = True
        '                                End If
        '                            Case "CLE"
        '                                If (existeEnDB.estado = "A") Then
        '                                    lblEstadoCliente.Text = "CLIENTE EXTERNO ACTIVO"
        '                                    lblEstadoCliente.Visible = True
        '                                Else
        '                                    lblEstadoCliente.Text = "CLIENTE EXTERNO INACTIVO"
        '                                    lblEstadoCliente.Visible = True
        '                                End If
        '                        End Select

        '                    End If

        '                Else
        '                    TextNumIdentrazon.Clear()
        '                    txtTipo.Clear()
        '                    TextProveedor.Text = String.Empty
        '                    TextProveedor.Tag = Nothing
        '                End If

        '            Else

        '                'CUANDO NO HAY CONEXION A INTERNET
        '                Dim existeEnDB = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", TextNumIdentrazon.Text.Trim)
        '                If existeEnDB Is Nothing Then

        '                    Dim existeEnBDHospedado = personaBeneficioSA.UbicarHospedadoPorRucNro(Gempresas.IdEmpresaRuc, TextNumIdentrazon.Text.Trim)

        '                    If existeEnBDHospedado Is Nothing Then
        '                        SelRazon.tipoEntidad = "CL"
        '                        SelRazon.nombreCompleto = TextProveedor.Text.Trim
        '                        SelRazon.nrodoc = TextNumIdentrazon.Text.Trim
        '                        SelRazon.tipoDoc = "1"
        '                        SelRazon.tipoPersona = "N"
        '                        'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        '                        'GrabarEntidadRapida()
        '                        GrabarEnFormBasico()
        '                    Else
        '                        TextProveedor.Text = existeEnBDHospedado.nombrePersona
        '                        TextProveedor.Tag = existeEnBDHospedado.idEntidad
        '                        txtTipo.Text = "HP"
        '                        TextProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)

        '                        If (existeEnBDHospedado.estado = "A") Then
        '                            lblEstadoCliente.Text = "HOSPEDADO ACTIVO"
        '                            lblEstadoCliente.Visible = True
        '                        Else
        '                            lblEstadoCliente.Text = "HOSPEDADO INACTIVO"
        '                            lblEstadoCliente.Visible = True
        '                        End If
        '                    End If

        '                Else
        '                    TextProveedor.Text = existeEnDB.nombreCompleto
        '                    TextProveedor.Tag = existeEnDB.idEntidad
        '                    txtTipo.Text = existeEnDB.tipoEntidad
        '                    TextProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)

        '                    Select Case existeEnDB.tipoEntidad
        '                        Case "CL"
        '                            If (existeEnDB.estado = "A") Then
        '                                lblEstadoCliente.Text = "CLIENTE ACTIVO"
        '                                lblEstadoCliente.Visible = True
        '                            Else
        '                                lblEstadoCliente.Text = "CLIENTE INACTIVO"
        '                                lblEstadoCliente.Visible = True
        '                            End If
        '                        Case "CLE"
        '                            If (existeEnDB.estado = "A") Then
        '                                lblEstadoCliente.Text = "CLIENTE EXTERNO ACTIVO"
        '                                lblEstadoCliente.Visible = True
        '                            Else
        '                                lblEstadoCliente.Text = "CLIENTE EXTERNO INACTIVO"
        '                                lblEstadoCliente.Visible = True
        '                            End If
        '                    End Select
        '                End If

        '            End If

        '        Case 11 'razonSocial

        '            Dim objeto As Boolean = ValidationRUC(TextNumIdentrazon.Text.Trim)
        '            If objeto = False Then

        '                MessageBox.Show("Debe Ingresar un número correcto de ruc", "Ingresar identificación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '                Cursor = Cursors.Default
        '                TextProveedor.Clear()
        '                textDireccion.Clear()
        '                Exit Sub
        '            End If

        '            If My.Computer.Network.IsAvailable = True Then
        '                'VALIDAR SI EXISTE EN LA bd LOCAL PRIMERO 
        '                If GetValidarLocalDB(TextNumIdentrazon.Text.Trim) = False Then
        '                    TextNumIdentrazon.ReadOnly = True

        '                    'Select Case ToggleConsultas.ToggleState
        '                    'Case ToggleButton2.ToggleButtonState.OFF ' API
        '                    GetConsultaSunatAsync(TextNumIdentrazon.Text.Trim)
        '                    ' Case ToggleButton2.ToggleButtonState.ON ' WEB
        '                    '.RunWorkerAsync()
        '                    '
        '                End If
        '            Else
        '                'SI NO HAY CONEXION A INTERNET
        '                If GetValidarLocalDB(TextNumIdentrazon.Text.Trim) = False Then
        '                    Dim nroDoc = TextNumIdentrazon.Text.Trim.Substring(0, 1).ToString
        '                    If nroDoc = "1" Then
        '                        'SelRazon.tipoEntidad = "CL"
        '                        'SelRazon.nombreCompleto = TextEmpresaPasajero.Text.Trim
        '                        'SelRazon.nrodoc = TextNumIdentrazon.Text.Trim
        '                        'SelRazon.tipoDoc = "6"
        '                        'SelRazon.tipoPersona = "N"
        '                        'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        '                        'GrabarEntidadRapida()
        '                        GrabarEnFormBasico()

        '                        If TextProveedor.Text.Trim.Length > 0 Then
        '                            'TextFiltrar.Select()
        '                            'TextFiltrar.Focus()
        '                        Else
        '                            TextNumIdentrazon.Clear()
        '                            TextNumIdentrazon.Select()
        '                        End If
        '                    ElseIf nroDoc = "2" Then
        '                        'SelRazon.tipoEntidad = "CL"
        '                        'SelRazon.nombreCompleto = TextEmpresaPasajero.Text.Trim
        '                        'SelRazon.nrodoc = TextNumIdentrazon.Text.Trim
        '                        'SelRazon.tipoDoc = "6"
        '                        'SelRazon.tipoPersona = "J"
        '                        'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        '                        'GrabarEntidadRapida()
        '                        GrabarEnFormBasico()

        '                        If TextProveedor.Text.Trim.Length > 0 Then
        '                            'TextFiltrar.Select()
        '                            'TextFiltrar.Focus()
        '                        Else
        '                            TextNumIdentrazon.Clear()
        '                            TextNumIdentrazon.Select()
        '                            textDireccion.Clear()
        '                            txtTipo.Clear()
        '                            lblEstadoCliente.Visible = False
        '                        End If
        '                    End If
        '                End If
        '            End If

        '        Case Else
        '            TextProveedor.Text = String.Empty
        '            textDireccion.Text = String.Empty
        '            TextNumIdentrazon.Text = String.Empty
        '            txtTipo.Text = String.Empty
        '            lblEstadoCliente.Visible = False
        '            MessageBox.Show("Ingrese un documento correcto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    End Select

        'Catch ew As WebException

        '    If ew.Status = WebExceptionStatus.ProtocolError Then

        '        Dim [error] As String = New System.IO.StreamReader(ew.Response.GetResponseStream()).ReadToEnd()
        '        MessageBox.Show("DNI no encontrado en el padron, verifique si es menor de edad")
        '        TextNumIdentrazon.Clear()
        '        TextNumIdentrazon.Select()
        '        TextNumIdentrazon.Focus()
        '        TextProveedor.Clear()
        '        txtTipo.Clear()
        '        lblEstadoCliente.Visible = False
        '    End If

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub

    Private Sub BgProveedor_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BgProveedor.DoWork
        GetConsultaSunatThread(TextNumIdentrazon.Text)
    End Sub

    Private Sub BgProveedor_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BgProveedor.RunWorkerCompleted
        If SelRazon.nrodoc IsNot Nothing Then
            SelRazon.tipoEntidad = "CL"
            SelRazon.nombreCompleto = SelRazon.nombreCompleto.ToString.Replace(Chr(34), "")
            GrabarEntidadRapidaThread()
            TextNumIdentrazon.Text = SelRazon.nrodoc
            TextProveedor.Text = SelRazon.nombreCompleto
            textDireccion.Text = SelRazon.direccion
            TextNumIdentrazon.ReadOnly = False
            SelRazon = New entidad

        Else
            TextProveedor.Clear()
            textDireccion.Clear()
            TextProveedor.Tag = Nothing
            TextNumIdentrazon.ReadOnly = False
            SelRazon = New entidad
            TextNumIdentrazon.Select()
        End If
    End Sub

    Private Sub RoundButton22_Click(sender As Object, e As EventArgs) Handles RoundButton22.Click
        Dim nombres = String.Empty
        Try
            Dim entidadBE As New entidad
            entidadBE.nrodoc = TextNumIdentrazon.Text
            entidadBE.estado = "A"

            Select Case TextNumIdentrazon.Text.Trim.Length
                Case 8 'dni

                    SelRazon = New entidad

                    If My.Computer.Network.IsAvailable = True Then

                        'nombres = GetConsultarDNIReniec(TextNumIdentrazon.Text.Trim)
                        nombres = GetConsultarDNIReniecAPIs(TextNumIdentrazon.Text.Trim)
                        If nombres.Trim.Length > 0 Then

                            If nombres = "DNI no encontrado en Padrón Electoral" Then
                                TextNumIdentrazon.Clear()
                                TextProveedor.Text = String.Empty
                                TextProveedor.Tag = Nothing
                                textDireccion.Text = String.Empty

                                Exit Sub
                            End If

                            SelRazon.tipoEntidad = "CL"
                            SelRazon.nombreCompleto = nombres
                            SelRazon.nrodoc = TextNumIdentrazon.Text.Trim
                            SelRazon.tipoDoc = "1"
                            SelRazon.tipoPersona = "N"
                            TextProveedor.Text = nombres

                            'Dim existeEnBDHospedado = personaBeneficioSA.UbicarHospedadoPorRucNro(Gempresas.IdEmpresaRuc, TextNumIdentrazon.Text.Trim)
                            Dim existeEnDB = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", TextNumIdentrazon.Text.Trim)

                            If existeEnDB Is Nothing Then
                                TextProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                GrabarEntidadRapida()

                            Else
                                TextProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                TextProveedor.Tag = existeEnDB.idEntidad
                            End If

                        Else
                            TextNumIdentrazon.Clear()
                            txtTipo.Clear()
                            TextProveedor.Text = String.Empty
                            TextProveedor.Tag = Nothing
                        End If

                    Else

                        'CUANDO NO HAY CONEXION A INTERNET
                        Dim existeEnDB = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", TextNumIdentrazon.Text.Trim)
                        If existeEnDB Is Nothing Then


                            SelRazon.tipoEntidad = "CL"
                            SelRazon.nombreCompleto = TextProveedor.Text.Trim
                            SelRazon.nrodoc = TextNumIdentrazon.Text.Trim
                            SelRazon.tipoDoc = "1"
                            SelRazon.tipoPersona = "N"
                            'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                            'GrabarEntidadRapida()
                            GrabarEnFormBasico()
                        Else
                            TextProveedor.Text = existeEnDB.nombreCompleto
                            TextProveedor.Tag = existeEnDB.idEntidad
                            txtTipo.Text = existeEnDB.tipoEntidad
                            TextProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)

                        End If

                    End If

                Case 11 'razonSocial

                    Dim objeto As Boolean = ValidationRUC(TextNumIdentrazon.Text.Trim)
                    If objeto = False Then

                        MessageBox.Show("Debe Ingresar un número correcto de ruc", "Ingresar identificación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Cursor = Cursors.Default
                        TextProveedor.Clear()
                        textDireccion.Clear()
                        Exit Sub
                    End If

                    If My.Computer.Network.IsAvailable = True Then
                        'VALIDAR SI EXISTE EN LA bd LOCAL PRIMERO 
                        If GetValidarLocalDB(TextNumIdentrazon.Text.Trim) = False Then
                            TextNumIdentrazon.ReadOnly = True

                            'Select Case ToggleConsultas.ToggleState
                            'Case ToggleButton2.ToggleButtonState.OFF ' API
                            GetConsultaSunatAsync(TextNumIdentrazon.Text.Trim)
                            ' Case ToggleButton2.ToggleButtonState.ON ' WEB
                            '.RunWorkerAsync()
                            '
                        End If
                    Else
                        'SI NO HAY CONEXION A INTERNET
                        If GetValidarLocalDB(TextNumIdentrazon.Text.Trim) = False Then
                            Dim nroDoc = TextNumIdentrazon.Text.Trim.Substring(0, 1).ToString
                            If nroDoc = "1" Then
                                'SelRazon.tipoEntidad = "CL"
                                'SelRazon.nombreCompleto = TextEmpresaPasajero.Text.Trim
                                'SelRazon.nrodoc = TextNumIdentrazon.Text.Trim
                                'SelRazon.tipoDoc = "6"
                                'SelRazon.tipoPersona = "N"
                                'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                'GrabarEntidadRapida()
                                GrabarEnFormBasico()

                                If TextProveedor.Text.Trim.Length > 0 Then
                                    'TextFiltrar.Select()
                                    'TextFiltrar.Focus()
                                Else
                                    TextNumIdentrazon.Clear()
                                    TextNumIdentrazon.Select()
                                End If
                            ElseIf nroDoc = "2" Then
                                'SelRazon.tipoEntidad = "CL"
                                'SelRazon.nombreCompleto = TextEmpresaPasajero.Text.Trim
                                'SelRazon.nrodoc = TextNumIdentrazon.Text.Trim
                                'SelRazon.tipoDoc = "6"
                                'SelRazon.tipoPersona = "J"
                                'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                'GrabarEntidadRapida()
                                GrabarEnFormBasico()

                                If TextProveedor.Text.Trim.Length > 0 Then
                                    'TextFiltrar.Select()
                                    'TextFiltrar.Focus()
                                Else
                                    TextNumIdentrazon.Clear()
                                    TextNumIdentrazon.Select()
                                    textDireccion.Clear()

                                End If
                            End If
                        End If
                    End If

                Case Else
                    TextProveedor.Text = String.Empty
                    textDireccion.Text = String.Empty
                    TextNumIdentrazon.Text = String.Empty
                    txtTipo.Text = String.Empty
                    lblEstadoCliente.Visible = False
                    MessageBox.Show("Ingrese un documento correcto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Select


            Dim consulta = entidadSA.GetUbicarClienteOrHuesped(entidadBE)

            If (Not IsNothing(consulta)) Then
                Select Case consulta.clienteActivo
                    Case >= 1
                        lblEstadoCliente.Text = "CLIENTE ACTIVO"
                        lblEstadoCliente.Visible = True
                    Case = 0
                        Select Case consulta.totalVEntas
                            Case >= 1
                                lblEstadoCliente.Text = "CLIENTE INACTIVO"
                                lblEstadoCliente.Visible = True
                            Case = 0
                                Dim existeEnBDHospedado = personaBeneficioSA.UbicarHospedadoPorRucNro(Gempresas.IdEmpresaRuc, TextNumIdentrazon.Text.Trim)

                                If (Not IsNothing(existeEnBDHospedado)) Then
                                    lblEstadoCliente.Text = "HOSPEDADO"
                                    lblEstadoCliente.Visible = True
                                Else
                                    lblEstadoCliente.Text = "CLIENTE NUEVO"
                                    lblEstadoCliente.Visible = True
                                End If
                        End Select
                End Select

            Else
                MessageBox.Show("DNI no encontrado en el padron, verifique si es menor de edad")

            End If


        Catch ew As WebException

            If ew.Status = WebExceptionStatus.ProtocolError Then

                Dim [error] As String = New System.IO.StreamReader(ew.Response.GetResponseStream()).ReadToEnd()
                MessageBox.Show("DNI no encontrado en el padron, verifique si es menor de edad")
                TextNumIdentrazon.Clear()
                TextNumIdentrazon.Select()
                TextNumIdentrazon.Focus()
                TextProveedor.Clear()
                txtTipo.Clear()
                lblEstadoCliente.Visible = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub RoundButton23_Click(sender As Object, e As EventArgs) Handles RoundButton23.Click
        FormPurchase.TabP_IdentificacionCliente.Visible = False
        FormPurchase.TabCT_ControlXCliente.Visible = False
        If FormPurchase.TabRC_RecepcionPersona IsNot Nothing Then
            FormPurchase.TabRC_RecepcionPersona.Visible = True
            FormPurchase.TabRC_RecepcionPersona.pnPrincipal.Visible = True
            FormPurchase.TabRC_RecepcionPersona.GetCargarFechas()
            FormPurchase.TabRC_RecepcionPersona.limpiarCajas()
            FormPurchase.TabRC_RecepcionPersona.TextNumIdentrazon.Text = TextNumIdentrazon.Text
            FormPurchase.TabRC_RecepcionPersona.TextProveedor.Text = TextProveedor.Text
            FormPurchase.TabRC_RecepcionPersona.TextProveedor.Tag = TextProveedor.Tag
            FormPurchase.TabRC_RecepcionPersona.textDireccion.Text = textDireccion.Text
            FormPurchase.TabRC_RecepcionPersona.TextNumIdentrazon.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            FormPurchase.TabRC_RecepcionPersona.TextProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            FormPurchase.TabRC_RecepcionPersona.textDireccion.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            FormPurchase.TabRC_RecepcionPersona.BringToFront()
            FormPurchase.TabRC_RecepcionPersona.Show()
        End If
    End Sub

    Private Sub RoundButton25_Click(sender As Object, e As EventArgs) Handles RoundButton25.Click
        Try
            FormPurchase.TabP_IdentificacionCliente.Visible = False
            FormPurchase.TabRC_RecepcionPersona.Visible = False
            If FormPurchase.TabCT_ControlXCliente IsNot Nothing Then

                FormPurchase.TabCT_ControlXCliente.Visible = True
                Select Case txtTipo.Text
                    Case "HP"
                        FormPurchase.TabCT_ControlXCliente.txtTipoCliente.Text = "HOSPEDADO"
                    Case "CL"
                        FormPurchase.TabCT_ControlXCliente.txtTipoCliente.Text = "CLIENTE"
                    Case "CLE"
                        FormPurchase.TabCT_ControlXCliente.txtTipoCliente.Text = " CLIENTE EXTERNO"
                End Select

                FormPurchase.TabCT_ControlXCliente.TextNumIdentrazon.Text = TextNumIdentrazon.Text
                FormPurchase.TabCT_ControlXCliente.TextProveedor.Text = TextProveedor.Text
                FormPurchase.TabCT_ControlXCliente.TextProveedor.Tag = TextProveedor.Tag
                FormPurchase.TabCT_ControlXCliente.llamarCArgar()
                FormPurchase.TabCT_ControlXCliente.TextNumIdentrazon.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                FormPurchase.TabCT_ControlXCliente.TextProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                FormPurchase.TabCT_ControlXCliente.BringToFront()
                FormPurchase.TabCT_ControlXCliente.Show()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TextNumIdentrazon_TextChanged(sender As Object, e As EventArgs) Handles TextNumIdentrazon.TextChanged
        TextProveedor.Clear()
        lblEstadoCliente.Text = "ESTADO"
        lblEstadoCliente.Visible = False
    End Sub

    Private Sub RoundButton26_Click(sender As Object, e As EventArgs) Handles RoundButton26.Click
        Try
            Dim personaBeneficioSA As New personaBeneficioSA
            Dim personaBeneficioBE As New personaBeneficio

            personaBeneficioBE.idEntidad = TextProveedor.Tag
            personaBeneficioBE.estado = "A"

            Dim CONSULTA = personaBeneficioSA.UbicarHospedadoPorID(personaBeneficioBE)

            Dim VENDEDOR = GetCodigoVendedor()

            If (Not IsNothing(VENDEDOR)) Then
                Dim f As New FormVentaNuevaTouch()
                f.ComboComprobante.Text = "PEDIDO"
                f.CheckStock.Checked = True
                f.UCEstructuraCabeceraVentaV2.RoundButton21.Visible = False
                f.UCEstructuraCabeceraVentaV2.txtIDResponsable = VENDEDOR.IDUsuario
                f.UCEstructuraCabeceraVentaV2.txtNombreResponsable = VENDEDOR.Nombres & " " & VENDEDOR.ApellidoPaterno & " " & VENDEDOR.ApellidoMaterno
                f.UCEstructuraCabeceraVentaV2.txtInfraestructura.Text = CONSULTA.nombreHabitacion
                f.UCEstructuraCabeceraVentaV2.txtInfraestructura.Tag = CONSULTA.idDistribucion
                f.UCEstructuraCabeceraVentaV2.RadioButton2.Checked = True
                f.UCEstructuraCabeceraVentaV2.txtCheckIn.Visible = False
                f.UCEstructuraCabeceraVentaV2.txtCheckOn.Visible = False
                f.UCEstructuraCabeceraVentaV2.txtdias.Visible = False
                f.UCEstructuraCabeceraVentaV2.lblCheckIn.Visible = False
                f.UCEstructuraCabeceraVentaV2.Label20.Visible = False
                f.UCEstructuraCabeceraVentaV2.Label19.Visible = False
                f.UCEstructuraCabeceraVentaV2.TextNumIdentrazon.Text = TextNumIdentrazon.Text
                f.UCEstructuraCabeceraVentaV2.TextProveedor.Text = TextProveedor.Text
                f.UCEstructuraCabeceraVentaV2.TextProveedor.Tag = TextProveedor.Tag
                f.UCEstructuraCabeceraVentaV2.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function GetConsultarDNIReniecAPIs(Dni As String) As String
        Dim strJSON As String = String.Empty
        Dim rClient As RESTClientAPI = New RESTClientAPI()
        Dim appat As String = String.Empty
        Dim apmat As String = String.Empty
        Dim nom As String = String.Empty
        Dim fullName As String = String.Empty
        Select Case ApiReniecOption
            Case ApisReniec.ApiReniecCloud
                rClient.endPoint = "https://api.reniec.cloud/dni/" & Dni
            Case ApisReniec.ApiGrupoTeComCom
                rClient.endPoint = "http://apis.grupotecom.com/api/ConsultaDni?dni=" & Dni
            Case ApisReniec.ApiConsultasDsdInformaticos
                rClient.endPoint = "http://consultas.dsdinformaticos.com/reniec.php?dni=" & Dni
        End Select

        strJSON = rClient.makeRequest()
        Dim res = JsonConvert.DeserializeObject(strJSON)

        Select Case ApiReniecOption
            Case ApisReniec.ApiReniecCloud
                appat = res("apellido_paterno").ToString() 'res.apellido_paterno
                apmat = res("apellido_materno").ToString() ' res.apellido_materno
                nom = res("nombres").ToString() 'res.nombres
                fullName = Trim($"{appat} {apmat} {nom}")
            Case ApisReniec.ApiGrupoTeComCom

                fullName = res("result")("NombreCompleto")
                fullName = Trim(fullName)
            Case ApisReniec.ApiConsultasDsdInformaticos
                appat = res("result")("ApellidoPaterno").ToString() 'res.apellido_paterno
                apmat = res("result")("ApellidoMaterno").ToString() ' res.apellido_materno
                nom = res("result")("Nombres").ToString() 'res.nombres
                fullName = Trim($"{appat} {apmat} {nom}")
        End Select

        'Dim s = res("dni").ToString()




        '  nombres = MIHTML.Replace("|", Space(1))
        Return fullName
    End Function

End Class
