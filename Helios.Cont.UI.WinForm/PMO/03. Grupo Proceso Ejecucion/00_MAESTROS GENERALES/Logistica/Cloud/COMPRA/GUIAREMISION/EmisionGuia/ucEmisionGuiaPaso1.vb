Imports System.Drawing.Drawing2D
Imports System.Net
Imports System.Net.Http
Imports System.Threading.Tasks
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General.Constantes
Imports Newtonsoft.Json
Imports ProcesosGeneralesCajamiSoft
Imports Syncfusion.Windows.Forms.Tools

Public Class ucEmisionGuiaPaso1
    Public entidadSA As New entidadSA
#Region "Constructors"
    Public Sub New(forGuiaRemision As FormGuiaRemision8)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GetControlsMapping()
        _ForGuiaRemision = forGuiaRemision
        TextNumDocDestinatario.MaxLength = 20
    End Sub

    Public ReadOnly Property _ForGuiaRemision As FormGuiaRemision8
#End Region

#Region "Methods"
    Private Sub GetControlsMapping()
        Dim OBJ As New OTROSTIPODOCUMENTO
        Dim LISTA As New List(Of OTROSTIPODOCUMENTO)


        OBJ = New OTROSTIPODOCUMENTO
        OBJ.Codigo = "0"
        OBJ.Valor = " "
        LISTA.Add(OBJ)
        OBJ = New OTROSTIPODOCUMENTO
        OBJ.Codigo = "1"
        OBJ.Valor = "NÚMERO DE ORDEN DE ENTREGA"
        LISTA.Add(OBJ)
        OBJ = New OTROSTIPODOCUMENTO
        OBJ.Codigo = "2"
        OBJ.Valor = "NÚMERO DE SCOP"
        LISTA.Add(OBJ)
        OBJ = New OTROSTIPODOCUMENTO
        OBJ.Codigo = "3"
        OBJ.Valor = "NÚMERO DE MANIFIESTO DE CARGA"
        LISTA.Add(OBJ)
        OBJ = New OTROSTIPODOCUMENTO
        OBJ.Codigo = "4"
        OBJ.Valor = "NÚMERO DE CONSTANCIA DE DETRACCIÓN"
        LISTA.Add(OBJ)
        OBJ = New OTROSTIPODOCUMENTO
        OBJ.Codigo = "5"
        OBJ.Valor = "OTROS"
        LISTA.Add(OBJ)

        cbOtroDocRelac.DataSource = LISTA
        cbOtroDocRelac.ValueMember = "Codigo"
        cbOtroDocRelac.DisplayMember = "Valor"

        'COMBO MOTIVOS DE TRASLADO
        Dim LISTAMotivos As New List(Of MOTIVOTRASLADO)
        Dim OBJETO As New MOTIVOTRASLADO

        OBJETO = New MOTIVOTRASLADO
        OBJETO.Codigo = "0"
        OBJETO.Valor = " "
        LISTAMotivos.Add(OBJETO)

        OBJETO = New MOTIVOTRASLADO
        OBJETO.Codigo = "1"
        OBJETO.Valor = "VENTA"
        LISTAMotivos.Add(OBJETO)
        OBJETO = New MOTIVOTRASLADO
        OBJETO.Codigo = "2"
        OBJETO.Valor = "COMPRA"
        LISTAMotivos.Add(OBJETO)
        OBJETO = New MOTIVOTRASLADO
        OBJETO.Codigo = "3"
        OBJETO.Valor = "CONSIGNACIÓN"
        LISTAMotivos.Add(OBJETO)
        OBJETO = New MOTIVOTRASLADO
        OBJETO.Codigo = "4"
        OBJETO.Valor = "VENTA SUJETA A CONFIRMACIÓN DEL COMPRADOR"
        LISTAMotivos.Add(OBJETO)
        OBJETO = New MOTIVOTRASLADO
        OBJETO.Codigo = "5"
        OBJETO.Valor = "DEVOLUCIÓN"
        LISTAMotivos.Add(OBJETO)
        OBJETO = New MOTIVOTRASLADO
        OBJETO.Codigo = "6"
        OBJETO.Valor = "RECOJO"
        LISTAMotivos.Add(OBJETO)
        OBJETO = New MOTIVOTRASLADO
        OBJETO.Codigo = "7"
        OBJETO.Valor = "EMISOR ITINERANTE"
        LISTAMotivos.Add(OBJETO)
        OBJETO = New MOTIVOTRASLADO
        OBJETO.Codigo = "8"
        OBJETO.Valor = "TRASLADO ENTRE ESTABLECIMIENTOS DE LA MISMA EMPRESA"
        LISTAMotivos.Add(OBJETO)
        OBJETO = New MOTIVOTRASLADO
        OBJETO.Codigo = "9"
        OBJETO.Valor = "TRASLADO DE TRANSFORMACIÓN"
        LISTAMotivos.Add(OBJETO)
        OBJETO = New MOTIVOTRASLADO
        OBJETO.Codigo = "10"
        OBJETO.Valor = "TRASLADO ZONA PRIMARIA"
        LISTAMotivos.Add(OBJETO)
        OBJETO = New MOTIVOTRASLADO
        OBJETO.Codigo = "11"
        OBJETO.Valor = "TRASLADO EMISOR ITINERANTE COMPROBANTE DE PAGO"
        LISTAMotivos.Add(OBJETO)
        OBJETO = New MOTIVOTRASLADO
        OBJETO.Codigo = "12"
        OBJETO.Valor = "IMPORTACIÓN"
        LISTAMotivos.Add(OBJETO)
        OBJETO = New MOTIVOTRASLADO
        OBJETO.Codigo = "6"
        OBJETO.Valor = "EXPORTACIÓN"
        LISTAMotivos.Add(OBJETO)
        OBJETO = New MOTIVOTRASLADO
        OBJETO.Codigo = "13"
        OBJETO.Valor = "VENTA CON ENTRAGA A TERCEROS"
        LISTAMotivos.Add(OBJETO)
        OBJETO = New MOTIVOTRASLADO
        OBJETO.Codigo = "14"
        OBJETO.Valor = "OTROS"
        LISTAMotivos.Add(OBJETO)

        cbomotivotrasl.DataSource = LISTAMotivos
        cbomotivotrasl.ValueMember = "Codigo"
        cbomotivotrasl.DisplayMember = "Valor"


        TextNumDocRemitente.Text = Gempresas.IdEmpresaRuc
        TextRemitente.Text = Gempresas.NomEmpresa
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

    Private Sub SfButton2_Click(sender As Object, e As EventArgs) Handles SfButton2.Click
        _ForGuiaRemision.Close()
    End Sub

    Private Sub sfButton1_Click(sender As Object, e As EventArgs) Handles sfButton1.Click

        If TextNumDocDestinatario.Text = TextNumDocRemitente.Text Then
            ErrorProvider1.SetError(Me.TextNumDocDestinatario, "El destinatario no puede ser igual al Remitente")
            Exit Sub
        End If


        If TextNumDocDestinatario.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(Me.TextNumDocDestinatario, "Identificar al destinatario")
            ErrorProvider1.SetError(Me.TextDestinatario, "Nombre al destinatario")
            Exit Sub
        Else
            ErrorProvider1.SetError(Me.TextNumDocDestinatario, "")
            ErrorProvider1.SetError(Me.TextDestinatario, "")
        End If


        _ForGuiaRemision.sliderTop.Left = (_ForGuiaRemision.BunifuFlatButton1).Left
        _ForGuiaRemision.sliderTop.Width = (_ForGuiaRemision.BunifuFlatButton1).Width
        _ForGuiaRemision._ucEmisionGuiaPaso1.Visible = False
        _ForGuiaRemision._ucEmisionGuiaPaso2.Visible = True
        _ForGuiaRemision._ucEmisionGuiaPaso3.Visible = False
        _ForGuiaRemision._ucEmisionGuiaPaso4.Visible = False
        _ForGuiaRemision._ucEmisionGuiaPaso5.Visible = False
        _ForGuiaRemision._ucEmisionGuiaPaso2.GetDetalleVenta()
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

    Private Sub GrabarEntidadRapida(Textname As TextBoxExt, TextNumIdentrazon As TextBoxExt)
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
            obEntidad.nombreCompleto = Textname.Text.Trim
            obEntidad.cuentaAsiento = "1213"
            obEntidad.direccion = SelRazon.direccion
            If SelRazon.direccion IsNot Nothing Then
                If SelRazon.direccion.Trim.Length > 0 Then
                    obEntidad.entidadAtributos = New List(Of entidadAtributos)
                    obEntidad.entidadAtributos.Add(New entidadAtributos With {
                                                   .Action = BaseBE.EntityAction.INSERT,
                                                   .tipo = "DOMICILIO",
                                                   .tipoVia = SelRazon.TipoVia,
                                                   .Via = SelRazon.Via,
                                                   .ubigeo = SelRazon.Ubigeo,
                                                   .estado = 1,
                                                   .valorAtributo = SelRazon.direccion,
                                                   .usuarioModificacion = usuario.IDUsuario,
                                                   .fechaModificacion = Date.Now
                                                   })
                End If
            End If
            obEntidad.estado = StatusEntidad.Activo
            Dim codx As Integer = entidadSA.GrabarEntidad(obEntidad)

            Textname.Tag = codx
            Dim entidad As New entidad
            entidad.idEntidad = codx
            entidad.nrodoc = TextNumIdentrazon.Text.Trim
            entidad.nombreCompleto = obEntidad.nombreCompleto
            entidad.tipoDoc = obEntidad.tipoDoc
            Me.Tag = entidad
            'If RadioButton2.Checked = True Then
            '    textPersona.Focus()
            '    textPersona.Select()
            'ElseIf RadioButton1.Checked = True Then
            '    txtruc.Focus()
            '    txtruc.Select()
            'End If
            'Transporte.ListaEmpresas.Add(entidad)

            '    Dispose()
        Catch ex As Exception
            'Manejo de errores
            MsgBox("No se pudo grabar el cliente." & vbCrLf & ex.Message, MsgBoxStyle.Critical)
            Me.Tag = Nothing
        End Try
    End Sub

    Private Function GetValidarLocalDB(idEntidad As String, TextProveedor As TextBoxExt, TextNumIdentrazon As TextBoxExt) As Boolean
        GetValidarLocalDB = False
        Dim entidadSA As New entidadSA

        Dim entidad = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", idEntidad)
        If entidad IsNot Nothing Then
            SelRazon = New entidad
            SelRazon = entidad
            TextProveedor.Text = entidad.nombreCompleto
            TextProveedor.Tag = entidad.idEntidad
            GetValidarLocalDB = True

            If TextProveedor.Text.Trim.Length > 0 Then

            Else
                TextNumIdentrazon.Clear()
                TextNumIdentrazon.Select()
            End If
        End If
    End Function

    Private Sub GrabarEnFormBasico(TextNumIdentrazon As TextBoxExt, textName As TextBoxExt)
        Dim f As New frmCrearENtidades
        f.strTipo = TIPO_ENTIDAD.CLIENTE
        f.CaptionLabels(0).Text = "Nuevo cliente"
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        If f.Tag IsNot Nothing Then
            Dim ent = CType(f.Tag, entidad)
            TextNumIdentrazon.Text = ent.nrodoc
            textName.Text = ent.nombreCompleto
            textName.Tag = ent.idEntidad
        Else
            TextNumIdentrazon.Text = String.Empty
            textName.Text = String.Empty
            textName.Tag = Nothing
        End If
    End Sub

    Private Async Sub GetConsultaSunatAsync(ruc As String, TextProveedor As TextBoxExt, TextNumIdentrazon As TextBoxExt)
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
                SelRazon.nombreContacto = company.RazonSocial
                SelRazon.estado = company.ContribuyenteEstado
                SelRazon.nrodoc = company.Ruc
                SelRazon.direccion = company.DomicilioFiscal
                GrabarEntidadRapida(TextProveedor, TextNumIdentrazon)

            Else
                TextProveedor.Clear()

            End If
        ElseIf nroDoc = "2" Then
            Dim company = CType(Await SoftPackERP_Sunat.GetRucContribuyenteSPK.GetContribuyente(ruc), SoftPackERP_Sunat.CompanyJuridico)
            If company IsNot Nothing Then
                'If company.ContribuyenteTipo = "SOCIEDAD ANONIMA CERRADA" Then
                SelRazon.tipoPersona = "J"
                SelRazon.tipoDoc = "6"
                SelRazon.tipoEntidad = "CL"
                '  End If
                SelRazon.nombreCompleto = company.RazonSocial
                SelRazon.nombreContacto = company.RazonSocial
                TextProveedor.Text = company.RazonSocial
                SelRazon.estado = company.ContribuyenteEstado
                SelRazon.direccion = company.DomicilioFiscal
                SelRazon.nrodoc = company.Ruc
                'If company.RepresentanteLegal IsNot Nothing Then
                '    If company.RepresentanteLegal.Dni41094462 IsNot Nothing Then
                '        With company.RepresentanteLegal.Dni41094462
                '            txtContacto.Text = String.Format("{0}/{1}/{2}", .Cargo, .Nombre, .Desde)
                '        End With
                '    End If
                'End If
                GrabarEntidadRapida(TextProveedor, TextNumIdentrazon)

            Else
                TextProveedor.Clear()

            End If
        End If
        TextNumIdentrazon.ReadOnly = False
    End Sub



    Private Async Sub GetApiSunat(ByVal nroruc As String, TextProveedor As TextBoxExt, TextNumIdentrazon As TextBoxExt)
        SelRazon = New entidad()
        Dim responseTask As New HttpResponseMessage
        Using client = New HttpClient()

            If nroruc.ToString().Trim().Substring(0, 1) = "1" Then
                SelRazon.tipoPersona = "N"
            ElseIf nroruc.ToString().Trim().Substring(0, 1) = "2" Then
                SelRazon.tipoPersona = "J"
            End If
            Select Case ApiRucOption
                Case ApisRuc.ApiRucCloudPeru
                    Try

                        client.Timeout = TimeSpan.FromSeconds(5)
                        'client.BaseAddress = New Uri("https://api.peruonline.cloud/v1/?ruc=10449245691")
                        responseTask = Await client.GetAsync("https://api.peruonline.cloud/v1/?ruc=" & nroruc)
                        ' responseTask.Wait()
                        'Dim result = responseTask.Result

                        If responseTask.IsSuccessStatusCode Then
                            Dim readTask = responseTask.Content.ReadAsAsync(Of SunatContribuyente)()
                            readTask.Wait()
                            Dim students = readTask.Result
                            SelRazon.tipoDoc = "6"
                            SelRazon.tipoEntidad = "CL"
                            SelRazon.nombreCompleto = students.NombreORazonSocial
                            SelRazon.nombreContacto = students.NombreORazonSocial
                            TextProveedor.Text = students.NombreORazonSocial
                            SelRazon.estado = students.EstadoDelContribuyente
                            SelRazon.nrodoc = students.Ruc
                            SelRazon.direccion = students.Direccion

                            SelRazon.TipoVia = students.TipoDeVia
                            SelRazon.Via = students.NombreDeVia
                            SelRazon.Ubigeo = students.Ubigeo

                            GrabarEntidadRapida(TextProveedor, TextNumIdentrazon)
                        Else
                            GetConsultaSunatAsync(nroruc, TextProveedor, TextNumIdentrazon)

                            'TextProveedor.Clear()
                            'PictureLoad.Visible = False
                        End If
                        TextNumIdentrazon.ReadOnly = False
                    Catch ex As WebException

                        TextNumIdentrazon.ReadOnly = False
                    Catch ex As TaskCanceledException

                        TextNumIdentrazon.ReadOnly = False
                        Dim Login As New frmCrearENtidades
                        Login.WebBrowser1.Navigate("https://e-consultaruc.sunat.gob.pe/cl-ti-itmrconsruc/FrameCriterioBusquedaMovil.jsp")
                        Login.strTipo = "CL"
                        Login.StartPosition = FormStartPosition.CenterParent
                        Login.ShowDialog(Me)

                        If Login.Tag IsNot Nothing Then
                            Dim ent = CType(Login.Tag, entidad)
                            TextNumIdentrazon.Text = ent.nrodoc
                            TextProveedor.Text = ent.nombreCompleto
                            TextProveedor.Tag = ent.idEntidad
                        Else
                            TextNumIdentrazon.Text = String.Empty
                            TextProveedor.Text = String.Empty
                            TextProveedor.Tag = Nothing
                        End If

                    End Try
                Case ApisRuc.ApiRucSunatCloud
                    Try

                        client.Timeout = TimeSpan.FromSeconds(5)
                        responseTask = Await client.GetAsync("https://api.sunat.cloud/ruc/" & nroruc)

                        If responseTask.IsSuccessStatusCode Then
                            Dim readTask = responseTask.Content.ReadAsAsync(Of SunatContribuyente2)()
                            readTask.Wait()
                            Dim students = readTask.Result
                            SelRazon.tipoDoc = "6"
                            SelRazon.tipoEntidad = "CL"
                            SelRazon.nombreCompleto = students.NombreORazonSocial
                            SelRazon.nombreContacto = students.NombreORazonSocial
                            TextProveedor.Text = students.NombreORazonSocial
                            SelRazon.estado = students.EstadoDelContribuyente
                            SelRazon.nrodoc = students.Ruc
                            SelRazon.direccion = students.Direccion

                            'SelRazon.TipoVia = students.TipoDeVia
                            'SelRazon.Via = students.NombreDeVia
                            'SelRazon.Ubigeo = students.Ubigeo

                            GrabarEntidadRapida(TextProveedor, TextNumIdentrazon)
                            'PictureLoad.Visible = False
                        Else
                            GetConsultaSunatAsync(nroruc, TextProveedor, TextNumIdentrazon)

                            'TextProveedor.Clear()
                            'PictureLoad.Visible = False
                        End If
                        TextNumIdentrazon.ReadOnly = False

                    Catch ex As WebException

                        TextNumIdentrazon.ReadOnly = False
                    Catch ex As TaskCanceledException

                        TextNumIdentrazon.ReadOnly = False
                        Dim Login As New frmCrearENtidades
                        Login.WebBrowser1.Navigate("https://e-consultaruc.sunat.gob.pe/cl-ti-itmrconsruc/FrameCriterioBusquedaMovil.jsp")
                        Login.strTipo = "CL"
                        Login.StartPosition = FormStartPosition.CenterParent
                        Login.ShowDialog(Me)

                        If Login.Tag IsNot Nothing Then
                            Dim ent = CType(Login.Tag, entidad)
                            TextNumIdentrazon.Text = ent.nrodoc
                            TextProveedor.Text = ent.nombreCompleto
                            TextProveedor.Tag = ent.idEntidad
                        Else
                            TextNumIdentrazon.Text = String.Empty
                            TextProveedor.Text = String.Empty
                            TextProveedor.Tag = Nothing
                        End If

                    End Try
                Case ApisRuc.ApiRucaqfac
                    Try

                        client.Timeout = TimeSpan.FromSeconds(5)
                        responseTask = Await client.GetAsync("http://ruc.aqpfact.pe/sunat/" & nroruc)

                        If responseTask.IsSuccessStatusCode Then
                            Dim readTask = responseTask.Content.ReadAsAsync(Of SunatContribuyente3)()
                            readTask.Wait()
                            Dim students = readTask.Result
                            SelRazon.tipoDoc = "6"
                            SelRazon.tipoEntidad = "CL"
                            SelRazon.nombreCompleto = students.NombreORazonSocial
                            SelRazon.nombreContacto = students.NombreORazonSocial
                            TextProveedor.Text = students.NombreORazonSocial
                            SelRazon.estado = students.EstadoDelContribuyente
                            SelRazon.nrodoc = students.Ruc
                            SelRazon.direccion = students.Direccion

                            'SelRazon.TipoVia = students.TipoDeVia
                            'SelRazon.Via = students.NombreDeVia
                            'SelRazon.Ubigeo = students.Ubigeo

                            GrabarEntidadRapida(TextProveedor, TextNumIdentrazon)
                            'PictureLoad.Visible = False
                        Else
                            GetConsultaSunatAsync(nroruc, TextProveedor, TextNumIdentrazon)

                            'TextProveedor.Clear()
                            'PictureLoad.Visible = False
                        End If
                        TextNumIdentrazon.ReadOnly = False
                    Catch ex As WebException

                        TextNumIdentrazon.ReadOnly = False
                    Catch ex As TaskCanceledException

                        TextNumIdentrazon.ReadOnly = False
                        Dim Login As New frmCrearENtidades
                        Login.strTipo = "CL"
                        Login.WebBrowser1.Navigate("https://e-consultaruc.sunat.gob.pe/cl-ti-itmrconsruc/FrameCriterioBusquedaMovil.jsp")
                        Login.StartPosition = FormStartPosition.CenterParent
                        Login.ShowDialog(Me)

                        If Login.Tag IsNot Nothing Then
                            Dim ent = CType(Login.Tag, entidad)
                            TextNumIdentrazon.Text = ent.nrodoc
                            TextProveedor.Text = ent.nombreCompleto
                            TextProveedor.Tag = ent.idEntidad
                        Else
                            TextNumIdentrazon.Text = String.Empty
                            TextProveedor.Text = String.Empty
                            TextProveedor.Tag = Nothing
                        End If

                    End Try
            End Select
        End Using
    End Sub
    'Private Async Sub GetApiSunat(ByVal nroruc As String, TextProveedor As TextBoxExt, TextNumIdentrazon As TextBoxExt)
    '    SelRazon = New entidad()

    '    Using client = New HttpClient()

    '        If nroruc.ToString().Trim().Substring(0, 1) = "1" Then
    '            SelRazon.tipoPersona = "N"
    '        ElseIf nroruc.ToString().Trim().Substring(0, 1) = "2" Then
    '            SelRazon.tipoPersona = "J"
    '        End If

    '        'client.BaseAddress = New Uri("https://api.peruonline.cloud/v1/?ruc=10449245691")
    '        Dim responseTask = Await client.GetAsync("https://api.peruonline.cloud/v1/?ruc=" & nroruc)
    '        ' responseTask.Wait()
    '        'Dim result = responseTask.Result

    '        If responseTask.IsSuccessStatusCode Then
    '            Dim readTask = responseTask.Content.ReadAsAsync(Of SunatContribuyente)()
    '            readTask.Wait()
    '            Dim students = readTask.Result
    '            SelRazon.tipoDoc = "6"
    '            SelRazon.tipoEntidad = "CL"
    '            SelRazon.nombreCompleto = students.NombreORazonSocial
    '            SelRazon.nombreContacto = students.NombreORazonSocial
    '            TextProveedor.Text = students.NombreORazonSocial
    '            SelRazon.estado = students.EstadoDelContribuyente
    '            SelRazon.nrodoc = students.Ruc
    '            SelRazon.direccion = students.Direccion

    '            SelRazon.TipoVia = students.TipoDeVia
    '            SelRazon.Via = students.NombreDeVia
    '            SelRazon.Ubigeo = students.Ubigeo

    '            GrabarEntidadRapida(TextProveedor, TextNumIdentrazon)
    '        Else
    '            GetConsultaSunatAsync(nroruc, TextProveedor, TextNumIdentrazon)

    '            'TextProveedor.Clear()
    '            'PictureLoad.Visible = False
    '        End If
    '        TextNumIdentrazon.ReadOnly = False
    '    End Using
    'End Sub

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
                    SelRazon.tipoEntidad = "CL"
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
                    SelRazon.tipoEntidad = "CL"
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

    Dim SelRazon As entidad
    Private Sub TextNumDocRemitente_KeyDown(sender As Object, e As KeyEventArgs) Handles TextNumDocRemitente.KeyDown
        'Dim nombres = String.Empty
        'Try
        '    'TextNumDocRemitente.Enabled = False
        '    If e.KeyCode = Keys.Enter Then
        '        e.SuppressKeyPress = True

        '        Select Case TextNumDocRemitente.Text.Trim.Length
        '            Case 8 'dni
        '                comboRemitente.Text = "DNI"
        '                SelRazon = New entidad

        '                If My.Computer.Network.IsAvailable = True Then
        '                    nombres = GetConsultarDNIReniecAPIs(TextNumDocRemitente.Text.Trim)

        '                    If nombres.Trim.Length > 0 Then

        '                        If nombres = "DNI no encontrado en Padrón Electoral" Then
        '                            TextNumDocRemitente.Clear()
        '                            TextRemitente.Text = String.Empty
        '                            TextRemitente.Tag = Nothing
        '                            Exit Sub
        '                        End If

        '                        SelRazon.tipoEntidad = "CL"
        '                        SelRazon.nombreCompleto = nombres
        '                        SelRazon.nrodoc = TextNumDocRemitente.Text.Trim
        '                        SelRazon.tipoDoc = "1"
        '                        SelRazon.tipoPersona = "N"
        '                        TextRemitente.Text = nombres

        '                        Dim existeEnDB = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", TextNumDocRemitente.Text.Trim)

        '                        If existeEnDB Is Nothing Then
        '                            TextRemitente.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        '                            GrabarEntidadRapida(TextRemitente, TextNumDocRemitente)
        '                        Else
        '                            TextRemitente.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        '                            TextRemitente.Tag = existeEnDB.idEntidad

        '                        End If
        '                    Else
        '                        TextNumDocRemitente.Clear()
        '                        TextRemitente.Text = String.Empty
        '                        TextRemitente.Tag = Nothing
        '                    End If

        '                Else

        '                    'CUANDO NO HAY CONEXION A INTERNET
        '                    Dim existeEnDB = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", TextNumDocRemitente.Text.Trim)
        '                    If existeEnDB Is Nothing Then
        '                        SelRazon.tipoEntidad = "CL"
        '                        SelRazon.nombreCompleto = TextRemitente.Text.Trim
        '                        SelRazon.nrodoc = TextNumDocRemitente.Text.Trim
        '                        SelRazon.tipoDoc = "1"
        '                        SelRazon.tipoPersona = "N"
        '                        'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        '                        'GrabarEntidadRapida()
        '                        GrabarEnFormBasico(TextNumDocRemitente, TextRemitente)
        '                    Else
        '                        TextRemitente.Text = existeEnDB.nombreCompleto
        '                        TextRemitente.Tag = existeEnDB.idEntidad
        '                        TextRemitente.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)

        '                    End If
        '                End If



        '            Case 11 'razonSocial
        '                comboRemitente.Text = "RUC"
        '                Dim objeto As Boolean = ValidationRUC(TextNumDocRemitente.Text.Trim)
        '                If objeto = False Then

        '                    MessageBox.Show("Debe Ingresar un número correcto de ruc", "Ingresar identificación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '                    Cursor = Cursors.Default
        '                    TextRemitente.Clear()
        '                    Exit Sub
        '                End If

        '                If My.Computer.Network.IsAvailable = True Then
        '                    'VALIDAR SI EXISTE EN LA bd LOCAL PRIMERO 
        '                    If GetValidarLocalDB(TextNumDocRemitente.Text.Trim, TextRemitente, TextNumDocRemitente) = False Then
        '                        TextNumDocRemitente.ReadOnly = True

        '                        Select Case ToggleConsultas.ToggleState
        '                            Case ToggleButton2.ToggleButtonState.OFF ' API
        '                                '  GetConsultaSunatAsync(TextNumDocRemitente.Text.Trim)
        '                                GetApiSunat(TextNumDocRemitente.Text.Trim, TextRemitente, TextNumDocRemitente)
        '                            Case ToggleButton2.ToggleButtonState.ON ' WEB
        '                                BgProveedor.RunWorkerAsync()
        '                        End Select
        '                    End If
        '                Else
        '                    'SI NO HAY CONEXION A INTERNET
        '                    If GetValidarLocalDB(TextNumDocRemitente.Text.Trim, TextRemitente, TextNumDocRemitente) = False Then
        '                        Dim nroDoc = TextNumDocRemitente.Text.Trim.Substring(0, 1).ToString
        '                        If nroDoc = "1" Then
        '                            'SelRazon.tipoEntidad = "CL"
        '                            'SelRazon.nombreCompleto = TextEmpresaPasajero.Text.Trim
        '                            'SelRazon.nrodoc = TextNumDocRemitente.Text.Trim
        '                            'SelRazon.tipoDoc = "6"
        '                            'SelRazon.tipoPersona = "N"
        '                            'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        '                            'GrabarEntidadRapida()
        '                            GrabarEnFormBasico(TextNumDocRemitente, TextRemitente)

        '                            If TextRemitente.Text.Trim.Length > 0 Then

        '                            Else
        '                                TextNumDocRemitente.Clear()
        '                                TextNumDocRemitente.Select()
        '                            End If
        '                        ElseIf nroDoc = "2" Then
        '                            'SelRazon.tipoEntidad = "CL"
        '                            'SelRazon.nombreCompleto = TextEmpresaPasajero.Text.Trim
        '                            'SelRazon.nrodoc = TextNumDocRemitente.Text.Trim
        '                            'SelRazon.tipoDoc = "6"
        '                            'SelRazon.tipoPersona = "J"
        '                            'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        '                            'GrabarEntidadRapida()
        '                            GrabarEnFormBasico(TextNumDocRemitente, TextRemitente)

        '                            If TextRemitente.Text.Trim.Length > 0 Then

        '                            Else
        '                                TextNumDocRemitente.Clear()
        '                                TextNumDocRemitente.Select()
        '                            End If
        '                        End If
        '                    End If
        '                End If

        '            Case Else
        '                TextRemitente.Text = String.Empty
        '                TextNumDocRemitente.Text = String.Empty
        '                MessageBox.Show("Ingrese un documento correcto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '        End Select

        '    End If
        '    '    TextNumDocRemitente.Enabled = True

        'Catch ew As WebException

        '    If ew.Status = WebExceptionStatus.ProtocolError Then
        '        Dim [error] As String = New System.IO.StreamReader(ew.Response.GetResponseStream()).ReadToEnd()
        '        MessageBox.Show("DNI no encontrado en el padron, verifique si es menor de edad")
        '        TextNumDocRemitente.Clear()
        '        TextNumDocRemitente.Select()
        '        TextNumDocRemitente.Focus()
        '        TextRemitente.Clear()
        '    End If

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub

    Private Sub BgProveedor_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BgProveedor.DoWork
        ' GetConsultaSunatThread(TextNumIdentrazon.Text)
    End Sub

    Private Sub TextNumDocRemitente_TextChanged(sender As Object, e As EventArgs) Handles TextNumDocRemitente.TextChanged

    End Sub

    Private Sub TextNumDocDestinatario_KeyDown(sender As Object, e As KeyEventArgs) Handles TextNumDocDestinatario.KeyDown
        Dim nombres = String.Empty
        Try
            'TextNumDocRemitente.Enabled = False
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True

                Select Case TextNumDocDestinatario.Text.Trim.Length
                    Case 8 'dni
                        ComboDocDestinatario.Text = "DNI"
                        SelRazon = New entidad

                        If My.Computer.Network.IsAvailable = True Then
                            nombres = GetConsultarDNIReniecAPIs(TextNumDocDestinatario.Text.Trim)

                            If nombres.Trim.Length > 0 Then

                                If nombres = "DNI no encontrado en Padrón Electoral" Then
                                    TextNumDocDestinatario.Clear()
                                    TextDestinatario.Text = String.Empty
                                    TextDestinatario.Tag = Nothing
                                    Exit Sub
                                End If

                                SelRazon.tipoEntidad = "CL"
                                SelRazon.nombreCompleto = nombres
                                SelRazon.nrodoc = TextNumDocDestinatario.Text.Trim
                                SelRazon.tipoDoc = "1"
                                SelRazon.tipoPersona = "N"
                                TextDestinatario.Text = nombres

                                Dim existeEnDB = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", TextNumDocDestinatario.Text.Trim)

                                If existeEnDB Is Nothing Then
                                    TextDestinatario.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    GrabarEntidadRapida(TextDestinatario, TextNumDocDestinatario)
                                Else
                                    TextDestinatario.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    TextDestinatario.Tag = existeEnDB.idEntidad

                                End If
                            Else
                                TextNumDocDestinatario.Clear()
                                TextDestinatario.Text = String.Empty
                                TextDestinatario.Tag = Nothing
                            End If

                        Else

                            'CUANDO NO HAY CONEXION A INTERNET
                            Dim existeEnDB = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", TextNumDocDestinatario.Text.Trim)
                            If existeEnDB Is Nothing Then
                                SelRazon.tipoEntidad = "CL"
                                SelRazon.nombreCompleto = TextDestinatario.Text.Trim
                                SelRazon.nrodoc = TextNumDocDestinatario.Text.Trim
                                SelRazon.tipoDoc = "1"
                                SelRazon.tipoPersona = "N"
                                'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                'GrabarEntidadRapida()
                                GrabarEnFormBasico(TextNumDocDestinatario, TextDestinatario)
                            Else
                                TextDestinatario.Text = existeEnDB.nombreCompleto
                                TextDestinatario.Tag = existeEnDB.idEntidad
                                TextDestinatario.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)

                            End If
                        End If



                    Case 11 'razonSocial
                        ComboDocDestinatario.Text = "RUC"
                        Dim objeto As Boolean = ValidationRUC(TextNumDocDestinatario.Text.Trim)
                        If objeto = False Then

                            MessageBox.Show("Debe Ingresar un número correcto de ruc", "Ingresar identificación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Cursor = Cursors.Default
                            TextDestinatario.Clear()
                            Exit Sub
                        End If

                        If My.Computer.Network.IsAvailable = True Then
                            'VALIDAR SI EXISTE EN LA bd LOCAL PRIMERO 
                            If GetValidarLocalDB(TextNumDocDestinatario.Text.Trim, TextDestinatario, TextNumDocDestinatario) = False Then
                                TextNumDocDestinatario.ReadOnly = True

                                Select Case ToggleConsultas.ToggleState
                                    Case ToggleButton2.ToggleButtonState.OFF ' API
                                        '  GetConsultaSunatAsync(TextNumDocDestinatario.Text.Trim)
                                        GetApiSunat(TextNumDocDestinatario.Text.Trim, TextDestinatario, TextNumDocDestinatario)
                                    Case ToggleButton2.ToggleButtonState.ON ' WEB
                                        BgProveedor.RunWorkerAsync()
                                End Select
                            End If
                        Else
                            'SI NO HAY CONEXION A INTERNET
                            If GetValidarLocalDB(TextNumDocDestinatario.Text.Trim, TextDestinatario, TextNumDocDestinatario) = False Then
                                Dim nroDoc = TextNumDocDestinatario.Text.Trim.Substring(0, 1).ToString
                                If nroDoc = "1" Then
                                    'SelRazon.tipoEntidad = "CL"
                                    'SelRazon.nombreCompleto = TextEmpresaPasajero.Text.Trim
                                    'SelRazon.nrodoc = TextNumDocDestinatario.Text.Trim
                                    'SelRazon.tipoDoc = "6"
                                    'SelRazon.tipoPersona = "N"
                                    'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    'GrabarEntidadRapida()
                                    GrabarEnFormBasico(TextNumDocDestinatario, TextDestinatario)

                                    If TextDestinatario.Text.Trim.Length > 0 Then

                                    Else
                                        TextNumDocDestinatario.Clear()
                                        TextNumDocDestinatario.Select()
                                    End If
                                ElseIf nroDoc = "2" Then
                                    'SelRazon.tipoEntidad = "CL"
                                    'SelRazon.nombreCompleto = TextEmpresaPasajero.Text.Trim
                                    'SelRazon.nrodoc = TextNumDocDestinatario.Text.Trim
                                    'SelRazon.tipoDoc = "6"
                                    'SelRazon.tipoPersona = "J"
                                    'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    'GrabarEntidadRapida()
                                    GrabarEnFormBasico(TextNumDocDestinatario, TextDestinatario)

                                    If TextDestinatario.Text.Trim.Length > 0 Then

                                    Else
                                        TextNumDocDestinatario.Clear()
                                        TextNumDocDestinatario.Select()
                                    End If
                                End If
                            End If
                        End If

                    Case Else
                        TextDestinatario.Text = String.Empty
                        TextNumDocDestinatario.Text = String.Empty
                        MessageBox.Show("Ingrese un documento correcto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Select

            End If
            '    TextNumDocDestinatario.Enabled = True

        Catch ew As WebException

            If ew.Status = WebExceptionStatus.ProtocolError Then
                Dim [error] As String = New System.IO.StreamReader(ew.Response.GetResponseStream()).ReadToEnd()
                MessageBox.Show("DNI no encontrado en el padron, verifique si es menor de edad")
                TextNumDocDestinatario.Clear()
                TextNumDocDestinatario.Select()
                TextNumDocDestinatario.Focus()
                TextDestinatario.Clear()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
        If TextNroDocRelacionados.Text.Trim().Length = 0 Then
            MessageBox.Show("Ingresar un número válido")
            TextNroDocRelacionados.Select()
            Return
        Else
            Dim guiaPlaca = New documentoGuiaProperties() With {
                .CodigoAuth = Guid.NewGuid.ToString(),
                .tipo = "ODOC RELACION",
                .nameproperty = cbOtroDocRelac.SelectedValue,
                .property_value = cbOtroDocRelac.Text,
                .property_value2 = TextNroDocRelacionados.Text.Trim(),
                .usuarioModificacion = 1,
                .fechaModificacion = Date.Now
            }
            _ForGuiaRemision.ListaPropertiesGuia.Add(guiaPlaca)
            GetLsvOtrosDocumentos()
            TextNroDocRelacionados.Clear()
            TextNroDocRelacionados.Select()
        End If
    End Sub

    Private Sub GetLsvOtrosDocumentos()
        ListOtrosDoc.Items.Clear()
        Dim lst = _ForGuiaRemision.ListaPropertiesGuia.Where(Function(o) o.tipo = "ODOC RELACION").ToList()
        For Each i In lst
            Dim n As New ListViewItem(i.nameproperty)
            n.SubItems.Add(i.property_value2)
            n.SubItems.Add(i.CodigoAuth)
            ListOtrosDoc.Items.Add(n)
        Next
        ListOtrosDoc.Refresh()
    End Sub

    Private Sub BunifuFlatButton4_KeyDown(sender As Object, e As KeyEventArgs) Handles BunifuFlatButton4.KeyDown
        If e.KeyCode = Keys.Delete Then

        End If
    End Sub

    Private Sub ListOtrosDoc_KeyDown(sender As Object, e As KeyEventArgs) Handles ListOtrosDoc.KeyDown
        If e.KeyCode = Keys.Delete Then
            e.SuppressKeyPress = True
            If ListOtrosDoc.SelectedItems.Count > 0 Then
                Dim codigo = ListOtrosDoc.SelectedItems(0).SubItems(2).Text
                Dim obj = _ForGuiaRemision.ListaPropertiesGuia.Where(Function(o) o.CodigoAuth = codigo).SingleOrDefault
                _ForGuiaRemision.ListaPropertiesGuia.Remove(obj)
                ListOtrosDoc.SelectedItems(0).Remove()
                GetLsvOtrosDocumentos()
            End If
        End If
    End Sub

    Private Sub TextNumDocDestinatario_TextChanged(sender As Object, e As EventArgs) Handles TextNumDocDestinatario.TextChanged

    End Sub
#End Region

End Class
