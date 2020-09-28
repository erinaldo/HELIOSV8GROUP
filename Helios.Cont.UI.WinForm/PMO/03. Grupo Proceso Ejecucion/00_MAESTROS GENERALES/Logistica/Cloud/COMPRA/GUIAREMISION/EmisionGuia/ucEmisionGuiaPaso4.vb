Imports System.Drawing.Drawing2D
Imports System.Drawing.Printing
Imports System.Net
Imports System.Net.Http
Imports System.Threading.Tasks
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Newtonsoft.Json
Imports ProcesosGeneralesCajamiSoft
Imports Syncfusion.DocIO
Imports Syncfusion.DocIO.DLS
Imports Syncfusion.DocToPDFConverter
Imports Syncfusion.OfficeChartToImageConverter
Imports Syncfusion.Pdf
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Tools

Public Class ucEmisionGuiaPaso4

#Region "Attributes"
    'Public ListaPropertiesGuia As List(Of documentoGuiaProperties)
    Dim entidadSA As New entidadSA
#End Region

#Region "Constructors"
    Public Sub New(formGuiaRemision8 As FormGuiaRemision8)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'ListaPropertiesGuia = New List(Of documentoGuiaProperties)
        FormatGrid_DarkCell(GridVehiculos, Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Bottom, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center, BorderStyle.FixedSingle)
        FormatGrid_DarkCell(GridConductores, Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Bottom, Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center, BorderStyle.FixedSingle)
        DateEntrega.Value = DateTime.Now
        DateInicioTraslado.Value = DateTime.Now

        SelectTransporteTab()
        _formGuiaRemision8 = formGuiaRemision8

        ServicePointManager.ServerCertificateValidationCallback = AddressOf AcceptAllCertifications

    End Sub

    Public ReadOnly Property _formGuiaRemision8 As FormGuiaRemision8
#End Region

#Region "Methods"

    Public Function AcceptAllCertifications(ByVal sender As Object, ByVal certification As System.Security.Cryptography.X509Certificates.X509Certificate, ByVal chain As System.Security.Cryptography.X509Certificates.X509Chain, ByVal sslPolicyErrors As System.Net.Security.SslPolicyErrors) As Boolean
        Return True
    End Function
    Private Sub SelectTransporteTab()
        If ComboTipoTransporte.Text = "PUBLICO" Then
            Me.TabControlAdv1.SelectedTab = Me.TabPagePublico
            If _formGuiaRemision8 Is Nothing Then Exit Sub
            If _formGuiaRemision8._ucEmisionGuiaPaso1 IsNot Nothing Then
                _formGuiaRemision8._ucEmisionGuiaPaso1.ComboTipoTransporte.Text = "PUBLICO"
            End If

        Else
            Me.TabControlAdv1.SelectedTab = Me.TabPagePrivado
            If _formGuiaRemision8 Is Nothing Then Exit Sub
            If _formGuiaRemision8._ucEmisionGuiaPaso1 IsNot Nothing Then
                _formGuiaRemision8._ucEmisionGuiaPaso1.ComboTipoTransporte.Text = "PRIVADO"
            End If

        End If
    End Sub
#End Region

#Region "Events"
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

    Private Sub GetGridPlacas()
        Dim dt As New DataTable("Placas registradas")
        dt.Columns.Add("id")
        dt.Columns.Add("nro")
        dt.Columns.Add("placa")
        dt.Columns.Add("btDel")

        Dim conteo = 1
        For Each i In _formGuiaRemision8.ListaPropertiesGuia.Where(Function(o) o.tipo = "PLACA").ToList()
            dt.Rows.Add(i.CodigoAuth, conteo, i.property_value)
            conteo += 1
        Next
        GridVehiculos.DataSource = dt
    End Sub

    Private Sub GetGridConductores()
        Dim dt As New DataTable("Conductores registrados")
        dt.Columns.Add("id")
        dt.Columns.Add("nro")
        dt.Columns.Add("tipodoc")
        dt.Columns.Add("nrodoc")
        dt.Columns.Add("btEliminar")

        Dim conteo = 1
        For Each i In _formGuiaRemision8.ListaPropertiesGuia.Where(Function(o) o.tipo = "CONDUCTOR").ToList()
            dt.Rows.Add(i.CodigoAuth, conteo, i.property_value2, i.property_value)
            conteo += 1
        Next
        GridConductores.DataSource = dt
    End Sub

    Private Sub BtAgregarVehiculo_Click(sender As Object, e As EventArgs) Handles BtAgregarVehiculo.Click
        If textPlaca.Text.Trim().Length = 0 Then
            MessageBox.Show("Ingresar un número de placa válido")
            Return
        Else
            Dim guiaPlaca = New documentoGuiaProperties() With {
                .CodigoAuth = Guid.NewGuid.ToString(),
                .tipo = "PLACA",
                .nameproperty = "NRO DE PLACA",
                .property_value = textPlaca.Text.Trim(),
                .usuarioModificacion = 1,
                .fechaModificacion = Date.Now
            }
            _formGuiaRemision8.ListaPropertiesGuia.Add(guiaPlaca)
            GetGridPlacas()
            textPlaca.Clear()
        End If
    End Sub

    Private Sub btAgregarConductor_Click(sender As Object, e As EventArgs) Handles btAgregarConductor.Click
        If TextNumDocConductor.Text.Trim().Length = 0 Then
            MessageBox.Show("Ingresar un número de documento válido")
            Return
        Else
            Dim guiaConductor = New documentoGuiaProperties() With {
                .CodigoAuth = Guid.NewGuid.ToString(),
                .tipo = "CONDUCTOR",
                .nameproperty = "NAME",
                .property_value = TextNumDocConductor.Text.Trim(),
                .property_value2 = ComboDocDestinatario.Text,
                .usuarioModificacion = 1,
                .fechaModificacion = Date.Now
            }
            _formGuiaRemision8.ListaPropertiesGuia.Add(guiaConductor)
            GetGridConductores()
            TextNumDocConductor.Clear()
        End If
    End Sub

    Private Sub GridVehiculos_TableControlDrawCell(sender As Object, e As GridTableControlDrawCellEventArgs) Handles GridVehiculos.TableControlDrawCell
        If e.Inner.Style.CellType = "PushButton" Then
            e.Inner.Cancel = True

            ' //Draw the Image in a cell.
            If e.Inner.ColIndex = 4 Then
                e.Inner.Style.Description = "Eliminar"
                e.Inner.Style.TextColor = Color.LightGreen
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)
                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3),
                                           New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6)
                    )
                '    e.Inner.Graphics.DrawImage(Me.ImageList1.Images(0), irect)
            End If
        End If
    End Sub

    Private Sub GridVehiculos_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs) Handles GridVehiculos.TableControlPushButtonClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.Inner.ColIndex = 4 Then
                If GridVehiculos.Table.CurrentRecord IsNot Nothing Then
                    If GridVehiculos.Table.CurrentRecord IsNot Nothing Then
                        Dim style As GridTableCellStyleInfo = e.TableControl.Model(e.Inner.RowIndex, e.Inner.ColIndex)
                        Dim codigoVenta = style.TableCellIdentity.Table.CurrentRecord.GetValue("id")
                        Dim ventaDet = _formGuiaRemision8.ListaPropertiesGuia.Where(Function(o) o.CodigoAuth = codigoVenta).SingleOrDefault()
                        _formGuiaRemision8.ListaPropertiesGuia.Remove(ventaDet)
                        GetGridPlacas()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub GridConductores_TableControlDrawCell(sender As Object, e As GridTableControlDrawCellEventArgs) Handles GridConductores.TableControlDrawCell
        If e.Inner.Style.CellType = "PushButton" Then
            e.Inner.Cancel = True

            ' //Draw the Image in a cell.
            If e.Inner.ColIndex = 5 Then
                e.Inner.Style.Description = "Eliminar"
                e.Inner.Style.TextColor = Color.LightGreen
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)
                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3),
                                           New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6)
                    )
                '    e.Inner.Graphics.DrawImage(Me.ImageList1.Images(0), irect)
            End If
        End If
    End Sub

    Private Sub GridConductores_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs) Handles GridConductores.TableControlPushButtonClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.Inner.ColIndex = 5 Then
                If GridConductores.Table.CurrentRecord IsNot Nothing Then
                    If GridConductores.Table.CurrentRecord IsNot Nothing Then
                        Dim style As GridTableCellStyleInfo = e.TableControl.Model(e.Inner.RowIndex, e.Inner.ColIndex)
                        Dim codigoVenta = style.TableCellIdentity.Table.CurrentRecord.GetValue("id")
                        Dim ventaDet = _formGuiaRemision8.ListaPropertiesGuia.Where(Function(o) o.CodigoAuth = codigoVenta).SingleOrDefault()
                        _formGuiaRemision8.ListaPropertiesGuia.Remove(ventaDet)
                        GetGridConductores()
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub SfButton2_Click(sender As Object, e As EventArgs) Handles SfButton2.Click
        _formGuiaRemision8.Close()
    End Sub

    Private Sub SfButton3_Click(sender As Object, e As EventArgs) Handles SfButton3.Click
        _formGuiaRemision8.sliderTop.Left = (_formGuiaRemision8.BunifuFlatButton15).Left
        _formGuiaRemision8.sliderTop.Width = (_formGuiaRemision8.BunifuFlatButton15).Width

        _formGuiaRemision8._ucEmisionGuiaPaso1.Visible = False
        _formGuiaRemision8._ucEmisionGuiaPaso2.Visible = False
        _formGuiaRemision8._ucEmisionGuiaPaso4.Visible = False
        _formGuiaRemision8._ucEmisionGuiaPaso5.Visible = False
        _formGuiaRemision8._ucEmisionGuiaPaso3.Visible = True
    End Sub

    Private Sub ComboTipoTransporte_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboTipoTransporte.SelectionChangeCommitted
        SelectTransporteTab()
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
                rClient.endPoint = "http://apis.grupotecom.com/api/ConsultaDni?dni=" & Dni
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
                fullName = res("result")("NombreCompleto")
                fullName = Trim(fullName)
                'appat = res("result")("ApellidoPaterno").ToString() 'res.apellido_paterno
                'apmat = res("result")("ApellidoMaterno").ToString() ' res.apellido_materno
                'nom = res("result")("Nombres").ToString() 'res.nombres
                'fullName = Trim($"{appat} {apmat} {nom}")
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

    Private Sub GrabarEnFormBasicoPublico(TextNumIdentrazon As TextBoxExt, textName As TextBoxExt)
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
            End Select
        End Using
    End Sub

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

    Private Sub TextNumDocPublico_KeyDown(sender As Object, e As KeyEventArgs) Handles TextNumDocPublico.KeyDown
        Dim nombres = String.Empty
        Try
            'TextNumDocPublico.Enabled = False
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True

                Select Case TextNumDocPublico.Text.Trim.Length
                    Case 8 'dni
                        ComboDocPublico.Text = "DNI"
                        SelRazon = New entidad

                        If My.Computer.Network.IsAvailable = True Then
                            nombres = GetConsultarDNIReniecAPIs(TextNumDocPublico.Text.Trim)

                            If nombres.Trim.Length > 0 Then

                                If nombres = "DNI no encontrado en Padrón Electoral" Then
                                    TextNumDocPublico.Clear()
                                    TextTransportistaPublico.Text = String.Empty
                                    TextTransportistaPublico.Tag = Nothing
                                    Exit Sub
                                End If

                                SelRazon.tipoEntidad = "CL"
                                SelRazon.nombreCompleto = nombres
                                SelRazon.nrodoc = TextNumDocPublico.Text.Trim
                                SelRazon.tipoDoc = "1"
                                SelRazon.tipoPersona = "N"
                                TextTransportistaPublico.Text = nombres

                                Dim existeEnDB = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", TextNumDocPublico.Text.Trim)

                                If existeEnDB Is Nothing Then
                                    TextTransportistaPublico.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    GrabarEntidadRapida(TextTransportistaPublico, TextNumDocPublico)
                                Else
                                    TextTransportistaPublico.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    TextTransportistaPublico.Tag = existeEnDB.idEntidad

                                End If
                            Else
                                TextNumDocPublico.Clear()
                                TextTransportistaPublico.Text = String.Empty
                                TextTransportistaPublico.Tag = Nothing
                            End If

                        Else

                            'CUANDO NO HAY CONEXION A INTERNET
                            Dim existeEnDB = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", TextNumDocPublico.Text.Trim)
                            If existeEnDB Is Nothing Then
                                SelRazon.tipoEntidad = "CL"
                                SelRazon.nombreCompleto = TextTransportistaPublico.Text.Trim
                                SelRazon.nrodoc = TextNumDocPublico.Text.Trim
                                SelRazon.tipoDoc = "1"
                                SelRazon.tipoPersona = "N"
                                'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                'GrabarEntidadRapida()
                                GrabarEnFormBasico(TextNumDocPublico, TextTransportistaPublico)
                            Else
                                TextTransportistaPublico.Text = existeEnDB.nombreCompleto
                                TextTransportistaPublico.Tag = existeEnDB.idEntidad
                                TextTransportistaPublico.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)

                            End If
                        End If



                    Case 11 'razonSocial
                        ComboDocPublico.Text = "RUC"
                        Dim objeto As Boolean = ValidationRUC(TextNumDocPublico.Text.Trim)
                        If objeto = False Then

                            MessageBox.Show("Debe Ingresar un número correcto de ruc", "Ingresar identificación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Cursor = Cursors.Default
                            TextTransportistaPublico.Clear()
                            Exit Sub
                        End If

                        If My.Computer.Network.IsAvailable = True Then
                            'VALIDAR SI EXISTE EN LA bd LOCAL PRIMERO 
                            If GetValidarLocalDB(TextNumDocPublico.Text.Trim, TextTransportistaPublico, TextNumDocPublico) = False Then
                                TextNumDocPublico.ReadOnly = True

                                'Select Case ToggleConsultas.ToggleState
                                '    Case ToggleButton2.ToggleButtonState.OFF ' API
                                '  GetConsultaSunatAsync(TextNumDocPublico.Text.Trim)
                                GetApiSunat(TextNumDocPublico.Text.Trim, TextTransportistaPublico, TextNumDocPublico)
                                '    Case ToggleButton2.ToggleButtonState.ON ' WEB
                                '        BgProveedor.RunWorkerAsync()
                                'End Select
                            End If
                        Else
                            'SI NO HAY CONEXION A INTERNET
                            If GetValidarLocalDB(TextNumDocPublico.Text.Trim, TextTransportistaPublico, TextNumDocPublico) = False Then
                                Dim nroDoc = TextNumDocPublico.Text.Trim.Substring(0, 1).ToString
                                If nroDoc = "1" Then
                                    'SelRazon.tipoEntidad = "CL"
                                    'SelRazon.nombreCompleto = TextEmpresaPasajero.Text.Trim
                                    'SelRazon.nrodoc = TextNumDocPublico.Text.Trim
                                    'SelRazon.tipoDoc = "6"
                                    'SelRazon.tipoPersona = "N"
                                    'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    'GrabarEntidadRapida()
                                    GrabarEnFormBasico(TextNumDocPublico, TextTransportistaPublico)

                                    If TextTransportistaPublico.Text.Trim.Length > 0 Then

                                    Else
                                        TextNumDocPublico.Clear()
                                        TextNumDocPublico.Select()
                                    End If
                                ElseIf nroDoc = "2" Then
                                    'SelRazon.tipoEntidad = "CL"
                                    'SelRazon.nombreCompleto = TextEmpresaPasajero.Text.Trim
                                    'SelRazon.nrodoc = TextNumDocPublico.Text.Trim
                                    'SelRazon.tipoDoc = "6"
                                    'SelRazon.tipoPersona = "J"
                                    'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    'GrabarEntidadRapida()
                                    GrabarEnFormBasico(TextNumDocPublico, TextTransportistaPublico)

                                    If TextTransportistaPublico.Text.Trim.Length > 0 Then

                                    Else
                                        TextNumDocPublico.Clear()
                                        TextNumDocPublico.Select()
                                    End If
                                End If
                            End If
                        End If

                    Case Else
                        TextTransportistaPublico.Text = String.Empty
                        TextNumDocPublico.Text = String.Empty
                        MessageBox.Show("Ingrese un documento correcto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Select

            End If
            '    TextNumDocPublico.Enabled = True

        Catch ew As WebException

            If ew.Status = WebExceptionStatus.ProtocolError Then
                Dim [error] As String = New System.IO.StreamReader(ew.Response.GetResponseStream()).ReadToEnd()
                MessageBox.Show("DNI no encontrado en el padron, verifique si es menor de edad")
                TextNumDocPublico.Clear()
                TextNumDocPublico.Select()
                TextNumDocPublico.Focus()
                TextTransportistaPublico.Clear()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub sfButton1_Click(sender As Object, e As EventArgs) Handles sfButton1.Click

        If ComboTipoTransporte.Text = "PUBLICO" Then
            If TextNumDocPublico.Text.Trim.Length = 0 Then
                ErrorProvider1.SetError(Me.TextNumDocPublico, "Identificar Ruc transportista")
                Exit Sub
            Else
                ErrorProvider1.SetError(Me.TextNumDocPublico, "")
            End If


            If txtDniTransportistaPublico.Text.Trim.Length = 0 Then
                ErrorProvider1.SetError(Me.txtDniTransportistaPublico, "Identificar transportista")
                Exit Sub
            Else
                ErrorProvider1.SetError(Me.txtDniTransportistaPublico, "")
            End If

            If txtPlacaVehicular.Text.Trim.Length = 0 Then
                ErrorProvider1.SetError(Me.txtPlacaVehicular, "Identificar Placa Vehicular")
                Exit Sub
            Else
                ErrorProvider1.SetError(Me.txtPlacaVehicular, "")
            End If

        Else

            'If GridVehiculos.Table.Records.Count = 0 Then
            '    ErrorProvider1.SetError(Me.Label6, "Ingresar vehículos")
            '    Exit Sub
            'Else
            '    ErrorProvider1.SetError(Me.Label6, "")
            'End If

            'If GridConductores.Table.Records.Count = 0 Then
            '    ErrorProvider1.SetError(Me.Label7, "Ingresar los conductores")
            '    Exit Sub
            'Else
            '    ErrorProvider1.SetError(Me.Label7, "")
            'End If


            If txtRucTransportistaPrivado.Text.Trim.Length = 0 Then
                ErrorProvider1.SetError(Me.txtRucTransportistaPrivado, "Identificar Ruc transportista")
                Exit Sub
            Else
                ErrorProvider1.SetError(Me.txtRucTransportistaPrivado, "")
            End If


            If txtDniTransportistaPrivado.Text.Trim.Length = 0 Then
                ErrorProvider1.SetError(Me.txtDniTransportistaPrivado, "Identificar transportista")
                Exit Sub
            Else
                ErrorProvider1.SetError(Me.txtDniTransportistaPrivado, "")
            End If

            If txtPlacaVehicularPrivado.Text.Trim.Length = 0 Then
                ErrorProvider1.SetError(Me.txtPlacaVehicularPrivado, "Identificar Placa Vehicular")
                Exit Sub
            Else
                ErrorProvider1.SetError(Me.txtPlacaVehicularPrivado, "")
            End If

        End If



        _formGuiaRemision8.sliderTop.Left = (_formGuiaRemision8.BunifuFlatButton8).Left
        _formGuiaRemision8.sliderTop.Width = (_formGuiaRemision8.BunifuFlatButton8).Width

        _formGuiaRemision8._ucEmisionGuiaPaso1.Visible = False
        _formGuiaRemision8._ucEmisionGuiaPaso2.Visible = False
        _formGuiaRemision8._ucEmisionGuiaPaso4.Visible = False
        _formGuiaRemision8._ucEmisionGuiaPaso3.Visible = False
        _formGuiaRemision8._ucEmisionGuiaPaso5.Visible = True

        Dim documentoGuiaGenerado = GenerarDocumentoGuia()

        _formGuiaRemision8._ucEmisionGuiaPaso5.CustomDocumento = documentoGuiaGenerado


        '     ExecuteMail_Doc(documentoGuiaGenerado)
    End Sub



    Private Function GenerarDocumentoGuia() As documento
        Dim obj = MappingDocumento()
        MappingDocumentoCompraCabecera(obj)
        MappingDocumentoCompraCabeceraDetalle(obj)
        Return obj
    End Function


#End Region

#Region "Generate guia"
    Public doc As WordDocument
    Dim startPageIndex As Integer = 0
    Dim endPageIndex As Integer = 0
    Dim images As System.Drawing.Image()
    Private Sub ExecuteMail_Doc(guia As documento)

        Try
            doc = New WordDocument()
            '   Dim strPath As String = "D:\MyContract\reports\SalesInvoiceDemo2.doc"
            Dim strPath2 As String = "D:\Helios8\reports\NameCompany.doc"
            Dim strPath3 As String = "D:\Helios8\reports\NameCompany2.doc"
            'Dim strPath2 As String = "D:\Helios8\reports\Guia.doc"
            doc.Open(strPath2, FormatType.Doc)

            'Dim fieldCompany As String() = New String() {"NameCompany"}
            'Dim fieldCompanyValue As String() = New String() {Gempresas.NomEmpresa}
            Dim dt = GetTestOrder(guia)
            doc.MailMerge.ExecuteGroup(dt)
            doc.MailMerge.ExecuteGroup(GetDetalleGuia(guia.documentoGuia.documentoguiaDetalle.ToList()))
            doc.MailMerge.Execute(dt)

            'doc.MailMerge.ExecuteGroup(GetTestOrderTotals())
            'doc.MailMerge.ExecuteGroup(GetTestOrderCake())
            '   doc.MailMerge += New MergeFieldEventHandler(MailMerge_MergeField)

            doc.Save(strPath3)
            'System.Diagnostics.Process.Start(strPath3)

            '    GetPDF(strPath3)
            GetPDFConvet(strPath3)

        Catch Ex As Exception
            MessageBox.Show(Ex.Message)
        End Try
    End Sub

    Private Sub GetPDFConvet(path As String)
        Dim wordDoc = New WordDocument(path, Syncfusion.DocIO.FormatType.Automatic)
        wordDoc.ChartToImageConverter = New ChartToImageConverter()
        wordDoc.ChartToImageConverter.ScalingMode = Syncfusion.OfficeChart.ScalingMode.Normal

        Dim Converter = New DocToPDFConverter()
        '//Enable Direct PDF rendering mode for faster conversion.
        Converter.Settings.EnableFastRendering = False
        Converter.Settings.EmbedCompleteFonts = False
        Converter.Settings.EmbedFonts = False
        Converter.Settings.AutoTag = False
        Converter.Settings.PreserveFormFields = True
        Converter.Settings.ExportBookmarks = True

        Dim pdfDoc As PdfDocument = Converter.ConvertToPDF(wordDoc)
        '  //Save the pdf file
        Dim pathSave = "C:\archivos\documentoguia.pdf"
        'pdfDoc.Save("DoctoPDF.pdf")
        pdfDoc.Save(pathSave)
    End Sub

    Private Sub GetPDF(strPath3 As String)
        Dim doc2 = New WordDocument(strPath3)
        images = doc.RenderAsImages(ImageType.Metafile)
        endPageIndex = images.Length
        doc2.Close()

#Region "PrintSettings"
        'Create a PrintDialog
        Dim PrintDialog = New System.Windows.Forms.PrintDialog()
        '   // dialog.PrinterSetting
        PrintDialog.Document = New PrintDocument()
        '    //Set all Possible print ranges as true
        PrintDialog.AllowCurrentPage = True
        '   //printDialog.AllowSelection = true;
        PrintDialog.AllowSomePages = True
        '  //Set the start And end page index
        PrintDialog.PrinterSettings.FromPage = 1

        PrintDialog.PrinterSettings.ToPage = images.Length

#End Region

        If PrintDialog.ShowDialog = DialogResult.OK Then

            'Check if the Page Range exceeds the End page
            If PrintDialog.PrinterSettings.FromPage > 0 AndAlso PrintDialog.PrinterSettings.ToPage <= images.Length Then
                'Set the start page of the document to print
                startPageIndex = PrintDialog.PrinterSettings.FromPage - 1
                'Set the end page of the document to Print
                endPageIndex = PrintDialog.PrinterSettings.ToPage
                'Retrieve the Page need to be rendered
                PrintDialog.Document.Print()

                AddHandler PrintDialog.Document.PrintPage, AddressOf OnPrintPage


                '                    PrintDialog.Document.PrintPage += New PrintPageEventHandler(OnPrintPage)
                'Print the document
                PrintDialog.Document.Print()
            Else

                'If the Page range exceeds the 12
                'If MessageBox.Show("The page range is invalid" & Environment.NewLine & "Enter numbers between 1 and " + images.Length.ToString(), "Print Error", MessageBoxButtons.OK, MessageBoxIcon.[Error]) Is DialogResult.Yes Then
                'End If
            End If

            'Dispose the print dialog
            PrintDialog.Dispose()
            'Exit
            ' this.Close();
        End If
    End Sub

    Protected Overridable Sub OnPrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs)
        'Current page width
        Dim currentPageWidth As Integer = images(startPageIndex).Width
        'Current page height
        Dim currentPageHeight As Integer = images(startPageIndex).Height
        'Visible clip bounds width
        Dim visibleClipBoundsWidth As Integer = CInt(e.Graphics.VisibleClipBounds.Width)
        'Visible clip bounds height
        Dim visibleClipBoundsHeight As Integer = CInt(e.Graphics.VisibleClipBounds.Height)

        'Check if the page layout is landscape or portrait
        If currentPageWidth > currentPageHeight Then
            'Translate the Position 
            e.Graphics.TranslateTransform(0, visibleClipBoundsHeight)
            'Rotates the object at 270 degrees
            e.Graphics.RotateTransform(270.0F)
            'Draw the current page
            e.Graphics.DrawImage(images(startPageIndex), New System.Drawing.Rectangle(0, 0, currentPageWidth, currentPageHeight))
        Else
            'Draw the current page
            e.Graphics.DrawImage(images(startPageIndex), New System.Drawing.Rectangle(0, 0, visibleClipBoundsWidth, visibleClipBoundsHeight))
        End If

        'Dispose the current page
        images(startPageIndex).Dispose()
        'Increment the start page index 
        startPageIndex += 1

        'check if the start page index is lesser than end page index
        If startPageIndex < endPageIndex Then
            e.HasMorePages = True 'if the document contain more than one pages
        Else
            startPageIndex = 0
        End If
    End Sub


    Private Sub MailMerge_MergeField(ByVal sender As Object, ByVal args As MergeFieldEventArgs)
        If args.RowIndex Mod 2 = 0 Then
            args.CharacterFormat.TextColor = Color.DarkBlue
        End If
    End Sub

    Private Function GetTestOrder(doc As documento) As DataTable
        Dim dt = New DataTable("Orders")
        dt.TableName = "Orders"
        dt.Columns.Add("NameCompany")
        dt.Columns.Add("idEmpresa")
        dt.Columns.Add("fecEmision")
        dt.Columns.Add("fecentregabien")
        dt.Columns.Add("motivo")
        dt.Columns.Add("modalidad")
        dt.Columns.Add("pesobruto")
        dt.Columns.Add("razonSocial") 'Destinatario
        dt.Columns.Add("razonSocialDoc") 'Destinatario
        dt.Columns.Add("numdocTrans") 'Transportista
        dt.Columns.Add("razonTrans") 'Transportista
        dt.Columns.Add("ubigeopartida")
        dt.Columns.Add("ubigeodestino")
        dt.Columns.Add("observaciones")

        Dim dr As DataRow
        dr = dt.NewRow
        dr(0) = Gempresas.NomEmpresa
        dr(1) = Gempresas.IdEmpresaRuc
        dr(2) = doc.fechaProceso.ToShortDateString
        dr(3) = doc.documentoGuia.fechaTraslado
        dr(4) = doc.documentoGuia.motivoTraslado
        dr(5) = doc.documentoGuia.tipoVehiculo
        dr(6) = doc.documentoGuia.PesoBruTotal

        dr(7) = doc.documentoGuia.nombreDestinatario
        dr(8) = doc.documentoGuia.DocDestinatario

        dr(9) = doc.documentoGuia.nroDocTrasportista
        dr(10) = doc.documentoGuia.razonSocialTrasportista

        dr(11) = $"{doc.documentoGuia.puntoPartida}-{doc.documentoGuia.direccionPartida}"
        dr(12) = $"{doc.documentoGuia.puntoLlegada}-{doc.documentoGuia.DireccionLlegada}"
        dr(13) = doc.documentoGuia.ObserTrasPublico
        dt.Rows.Add(dr)

        Return dt
    End Function

    Private Function GetDetalleGuia(Lista As List(Of documentoguiaDetalle)) As DataTable
        Dim dt As New DataTable("Orderdetail")
        dt.TableName = "Orderdetail"
        dt.Columns.Add("nroItem")
        dt.Columns.Add("codigoBien")
        dt.Columns.Add("nombreItem")
        dt.Columns.Add("unidadItem")
        dt.Columns.Add("cantidadItem")

        Dim conteo As Integer = 1
        For Each i In Lista
            dt.Rows.Add(conteo, $"P-{i.idItem}", i.descripcionItem, i.unidadMedida, i.cantidad)
            conteo += 1
        Next
        Return dt
    End Function

    Private Function MappingDocumento() As documento

        Dim tipoOper As String
        '  Dim TIPODOC As Integer

        tipoOper = General.StatusTipoOperacion.GUIA_REMISION
        'If IsDBNull(cbTipoDocdes.SelectedValue) Then
        '    TIPODOC = cbTipoDocdes.SelectedValue
        'Else
        '    TIPODOC = cbtipoDesOtro.SelectedValue
        'End If

        MappingDocumento = New documento With
            {
        .idEmpresa = Gempresas.IdEmpresaRuc,
        .idCentroCosto = GEstableciento.IdEstablecimiento,
        .idProyecto = 0,
        .tipoDoc = "09",
        .fechaProceso = DateTime.Now,
        .moneda = "",
        .idEntidad = _formGuiaRemision8._venta.CustomEntidad.idEntidad,
        .entidad = _formGuiaRemision8._venta.CustomEntidad.nombreCompleto,
        .tipoEntidad = TIPO_ENTIDAD.CLIENTE,
        .nrodocEntidad = _formGuiaRemision8._venta.CustomEntidad.nrodoc,
        .nroDoc = "-",' "200",'$"{UCEstructuraCabeceraVentaV2.txtSerie.Text}-{UCEstructuraCabeceraVentaV2.txtNumero.Text}",
        .idOrden = 0,
        .tipoOperacion = tipoOper,
        .usuarioActualizacion = usuario.IDUsuario,
        .fechaActualizacion = Date.Now
        }
    End Function

    Private Sub MappingDocumentoCompraCabecera(be As documento)
        Dim TipoOtros As String = String.Empty
        Dim cantiTipo As Integer

        Dim TRASPORTE As Boolean

        TRASPORTE = False '0
        Dim fechaTraslado As DateTime
        Dim observaciones4 As String
        ' End If
        If (ComboTipoTransporte.Text = "PRIVADO") Then
            fechaTraslado = DateInicioTraslado.Value
            observaciones4 = TextObservacionPrivada.Text
        Else
            fechaTraslado = DateInicioTrasladoPublico.Value 'DateEntrega.Value
            observaciones4 = TextObservacionesPublico.Text
        End If

        Dim TipoDocDes As String = String.Empty
        If _formGuiaRemision8._ucEmisionGuiaPaso1.ComboDocDestinatario.Text = "DNI" Then
            TipoDocDes = "1"
        ElseIf _formGuiaRemision8._ucEmisionGuiaPaso1.ComboDocDestinatario.Text = "RUC" Then
            TipoDocDes = "6"
        End If

        Dim obj As New documentoGuia With
        {
        .codigoLibro = "8",
        .estado = "VG",
        .idDocumentoPadre = _formGuiaRemision8._venta.idDocumento,
        .idEmpresa = be.idEmpresa,
        .idCentroCosto = GEstableciento.IdEstablecimiento,
        .fechaDoc = Date.Now,
        .fechaTraslado = fechaTraslado,
        .periodo = GetPeriodo(Date.Now, True),
        .tipoDoc = "09",
        .serie = "0",
        .numeroDoc = "0",
        .idEntidad = _formGuiaRemision8._venta.idCliente,
        .motivoTraslado = _formGuiaRemision8._ucEmisionGuiaPaso1.cbomotivotrasl.Text,
        .DescripcionMotivo = _formGuiaRemision8._ucEmisionGuiaPaso1.cbomotivotrasl.Text,
        .DAM = _formGuiaRemision8._ucEmisionGuiaPaso1.TextNumeracionDam.Text,
        .monedaDoc = be.moneda,
        .puntoPartida = _formGuiaRemision8._ucEmisionGuiaPaso3.comboDistrito.SelectedValue,'$"{_formGuiaRemision8._ucEmisionGuiaPaso3.comboDepartamento.SelectedValue},{_formGuiaRemision8._ucEmisionGuiaPaso3.comboProvincia.SelectedValue},{_formGuiaRemision8._ucEmisionGuiaPaso3.comboDistrito.SelectedValue}",
        .direccionPartida = _formGuiaRemision8._ucEmisionGuiaPaso3.TextDireccionPartida.Text,
        .puntoLlegada = _formGuiaRemision8._ucEmisionGuiaPaso3.comboDistritoLlegada.SelectedValue,'$"{_formGuiaRemision8._ucEmisionGuiaPaso3.comboDepartamentoLlegada.SelectedValue},{_formGuiaRemision8._ucEmisionGuiaPaso3.comboProvinciaLlegada.SelectedValue},{_formGuiaRemision8._ucEmisionGuiaPaso3.comboDistritoLlegada.SelectedValue}",
        .DireccionLlegada = _formGuiaRemision8._ucEmisionGuiaPaso3.TextDireccionLlegada.Text,
        .AsignarOtraGuia = "-",
        .Trasbordo = TRASPORTE,
        .tipoVehiculo = _formGuiaRemision8._ucEmisionGuiaPaso1.ComboTipoTransporte.Text,
        .fechaEntrega = DateEntrega.Value,
         .ObserTrasPublico = observaciones4,
         .TipoDocDestinatario = TipoDocDes,'_formGuiaRemision8._ucEmisionGuiaPaso1.ComboDocDestinatario.Text,
         .DocDestinatario = _formGuiaRemision8._ucEmisionGuiaPaso1.TextNumDocDestinatario.Text,
         .nombreDestinatario = _formGuiaRemision8._ucEmisionGuiaPaso1.TextDestinatario.Text,
         .TipoDocProveedor = "-",
         .docProveedor = "-",
         .DatosProveedor = "-",
         .OtroTipoOperacion = TipoOtros,
        .OtroCantidad = cantiTipo,
        .PesoBruTotal = _formGuiaRemision8._ucEmisionGuiaPaso2.TextPesoBruto.DecimalValue,
        .usuarioActualizacion = be.usuarioActualizacion, 'usuario.IDUsuario,
        .fechaActualizacion = Date.Now,
        .tipoTransporte = ComboTipoTransporte.Text
        }

        If obj.tipoTransporte = "PUBLICO" Then
            obj.RucTrasporte = TextNumDocPublico.Text
            obj.nroDocTrasportista = txtDniTransportistaPublico.Text
            obj.razonSocialTrasportista = TextTransportistaPublico.Text
            obj.placaVehiculo = txtPlacaVehicular.Text
            obj.NroDocumentoConductor = txtDniTransportistaPublico.Text
            obj.datosTrasporte = TextTransportistaPublico.Text
        Else
            obj.RucTrasporte = txtRucTransportistaPrivado.Text
            obj.nroDocTrasportista = txtDniTransportistaPrivado.Text
            obj.razonSocialTrasportista = TextTransportistaPrivado.Text
            obj.placaVehiculo = txtPlacaVehicularPrivado.Text
            obj.NroDocumentoConductor = txtDniTransportistaPrivado.Text
            obj.datosTrasporte = TextTransportistaPrivado.Text
        End If



        be.documentoGuia = obj
        be.documentoGuia.documentoGuiaProperties = _formGuiaRemision8.ListaPropertiesGuia

        be.documentoGuia.documentoguiaDetalle = New List(Of documentoguiaDetalle)
    End Sub

    Private Sub MappingDocumentoCompraCabeceraDetalle(obj As documento)
        Dim objDet As documentoguiaDetalle

        For Each i In _formGuiaRemision8._ucEmisionGuiaPaso2.listBienesAtrasladar

            objDet = New documentoguiaDetalle With
                            {
                            .secuenciaRef = i.secuencia,
                            .idDocumentoPadre = i.idDocumento,
                            .idItem = i.idItem,
                            .tipoExistencia = i.tipoExistencia,
                            .descripcionItem = i.nombreItem,
                            .destino = i.destino,
                            .unidadMedida = i.unidad1,
                            .cantidad = i.monto1,
                            .almacenRef = i.idAlmacenOrigen,
                            .AfectoInventario = i.AfectoInventario,
                            .contenido_neto = i.monto2,
                            .nombreComercial = i.nombreComercial,
                            .usuarioModificacion = obj.usuarioActualizacion,' usuario.IDUsuario,
                            .fechaModificacion = Date.Now
                            }

            obj.documentoGuia.documentoguiaDetalle.Add(objDet)
        Next
    End Sub

    Private Sub TabControlAdv1_SelectedIndexChanging(sender As Object, args As SelectedIndexChangingEventArgs) Handles TabControlAdv1.SelectedIndexChanging
        'args.Cancel = True
    End Sub

    Private Sub TextNumDocConductor_TextChanged(sender As Object, e As EventArgs) Handles TextNumDocConductor.TextChanged

    End Sub

    Private Sub TextNumDocPublico_TextChanged(sender As Object, e As EventArgs) Handles TextNumDocPublico.TextChanged

    End Sub

    Private Sub txtDniTransportistaPublico_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDniTransportistaPublico.KeyDown
        Dim nombres = String.Empty
        Try
            'TextNumDocPublico.Enabled = False
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True

                Select Case txtDniTransportistaPublico.Text.Trim.Length
                    Case 8 'dni
                        ComboDocPublico.Text = "DNI"
                        SelRazon = New entidad

                        If My.Computer.Network.IsAvailable = True Then
                            nombres = GetConsultarDNIReniecAPIs(txtDniTransportistaPublico.Text.Trim)

                            If nombres.Trim.Length > 0 Then

                                If nombres = "DNI no encontrado en Padrón Electoral" Then
                                    txtDniTransportistaPublico.Clear()
                                    txtDniTransportistaPublico.Text = String.Empty
                                    txtDniTransportistaPublico.Tag = Nothing
                                    Exit Sub
                                End If

                                SelRazon.tipoEntidad = "CL"
                                SelRazon.nombreCompleto = nombres
                                SelRazon.nrodoc = TextNumDocPublico.Text.Trim
                                SelRazon.tipoDoc = "1"
                                SelRazon.tipoPersona = "N"
                                txtIdentificacionTransportistanombre.Text = nombres

                                Dim existeEnDB = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", txtDniTransportistaPublico.Text.Trim)

                                If existeEnDB Is Nothing Then
                                    txtIdentificacionTransportistanombre.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    GrabarEntidadRapida(txtIdentificacionTransportistanombre, txtDniTransportistaPublico)
                                Else
                                    txtIdentificacionTransportistanombre.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    txtIdentificacionTransportistanombre.Tag = existeEnDB.idEntidad

                                End If
                            Else
                                txtDniTransportistaPublico.Clear()
                                txtIdentificacionTransportistanombre.Text = String.Empty
                                txtIdentificacionTransportistanombre.Tag = Nothing
                            End If

                        Else

                            'CUANDO NO HAY CONEXION A INTERNET
                            Dim existeEnDB = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", txtDniTransportistaPublico.Text.Trim)
                            If existeEnDB Is Nothing Then
                                SelRazon.tipoEntidad = "CL"
                                SelRazon.nombreCompleto = txtIdentificacionTransportistanombre.Text.Trim
                                SelRazon.nrodoc = txtDniTransportistaPublico.Text.Trim
                                SelRazon.tipoDoc = "1"
                                SelRazon.tipoPersona = "N"
                                'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                'GrabarEntidadRapida()
                                GrabarEnFormBasicoPublico(TextNumDocPublico, TextTransportistaPublico)
                            Else
                                TextTransportistaPublico.Text = existeEnDB.nombreCompleto
                                TextTransportistaPublico.Tag = existeEnDB.idEntidad
                                TextTransportistaPublico.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)

                            End If
                        End If



                    Case 11 'razonSocial
                        ComboDocPublico.Text = "RUC"
                        Dim objeto As Boolean = ValidationRUC(TextNumDocPublico.Text.Trim)
                        If objeto = False Then

                            MessageBox.Show("Debe Ingresar un número correcto de ruc", "Ingresar identificación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Cursor = Cursors.Default
                            TextTransportistaPublico.Clear()
                            Exit Sub
                        End If

                        If My.Computer.Network.IsAvailable = True Then
                            'VALIDAR SI EXISTE EN LA bd LOCAL PRIMERO 
                            If GetValidarLocalDB(TextNumDocPublico.Text.Trim, TextTransportistaPublico, TextNumDocPublico) = False Then
                                TextNumDocPublico.ReadOnly = True

                                'Select Case ToggleConsultas.ToggleState
                                '    Case ToggleButton2.ToggleButtonState.OFF ' API
                                '  GetConsultaSunatAsync(TextNumDocPublico.Text.Trim)
                                GetApiSunat(TextNumDocPublico.Text.Trim, TextTransportistaPublico, TextNumDocPublico)
                                '    Case ToggleButton2.ToggleButtonState.ON ' WEB
                                '        BgProveedor.RunWorkerAsync()
                                'End Select
                            End If
                        Else
                            'SI NO HAY CONEXION A INTERNET
                            If GetValidarLocalDB(TextNumDocPublico.Text.Trim, TextTransportistaPublico, TextNumDocPublico) = False Then
                                Dim nroDoc = TextNumDocPublico.Text.Trim.Substring(0, 1).ToString
                                If nroDoc = "1" Then
                                    'SelRazon.tipoEntidad = "CL"
                                    'SelRazon.nombreCompleto = TextEmpresaPasajero.Text.Trim
                                    'SelRazon.nrodoc = TextNumDocPublico.Text.Trim
                                    'SelRazon.tipoDoc = "6"
                                    'SelRazon.tipoPersona = "N"
                                    'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    'GrabarEntidadRapida()
                                    GrabarEnFormBasico(TextNumDocPublico, TextTransportistaPublico)

                                    If TextTransportistaPublico.Text.Trim.Length > 0 Then

                                    Else
                                        TextNumDocPublico.Clear()
                                        TextNumDocPublico.Select()
                                    End If
                                ElseIf nroDoc = "2" Then
                                    'SelRazon.tipoEntidad = "CL"
                                    'SelRazon.nombreCompleto = TextEmpresaPasajero.Text.Trim
                                    'SelRazon.nrodoc = TextNumDocPublico.Text.Trim
                                    'SelRazon.tipoDoc = "6"
                                    'SelRazon.tipoPersona = "J"
                                    'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    'GrabarEntidadRapida()
                                    GrabarEnFormBasico(TextNumDocPublico, TextTransportistaPublico)

                                    If TextTransportistaPublico.Text.Trim.Length > 0 Then

                                    Else
                                        TextNumDocPublico.Clear()
                                        TextNumDocPublico.Select()
                                    End If
                                End If
                            End If
                        End If

                    Case Else
                        TextTransportistaPublico.Text = String.Empty
                        TextNumDocPublico.Text = String.Empty
                        MessageBox.Show("Ingrese un documento correcto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Select

            End If
            '    TextNumDocPublico.Enabled = True

        Catch ew As WebException

            If ew.Status = WebExceptionStatus.ProtocolError Then
                Dim [error] As String = New System.IO.StreamReader(ew.Response.GetResponseStream()).ReadToEnd()
                MessageBox.Show("DNI no encontrado en el padron, verifique si es menor de edad")
                TextNumDocPublico.Clear()
                TextNumDocPublico.Select()
                TextNumDocPublico.Focus()
                TextTransportistaPublico.Clear()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtRucTransportistaPrivado_TextChanged(sender As Object, e As EventArgs) Handles txtRucTransportistaPrivado.TextChanged

    End Sub

    Private Sub txtRucTransportistaPrivado_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRucTransportistaPrivado.KeyDown
        Dim nombres = String.Empty
        Try
            'TextNumDocPublico.Enabled = False
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True

                Select Case txtRucTransportistaPrivado.Text.Trim.Length
                    'Case 8 'dni
                    '    ComboDocPublico.Text = "DNI"
                    '    SelRazon = New entidad

                    '    If My.Computer.Network.IsAvailable = True Then
                    '        nombres = GetConsultarDNIReniecAPIs(txtRucTransportistaPrivado.Text.Trim)

                    '        If nombres.Trim.Length > 0 Then

                    '            If nombres = "DNI no encontrado en Padrón Electoral" Then
                    '                txtRucTransportistaPrivado.Clear()
                    '                txtRucTransportistaPrivado.Text = String.Empty
                    '                txtRucTransportistaPrivado.Tag = Nothing
                    '                Exit Sub
                    '            End If

                    '            SelRazon.tipoEntidad = "CL"
                    '            SelRazon.nombreCompleto = nombres
                    '            SelRazon.nrodoc = TextNumDocPublico.Text.Trim
                    '            SelRazon.tipoDoc = "1"
                    '            SelRazon.tipoPersona = "N"
                    '            txtIdentificacionTransportistanombre.Text = nombres

                    '            Dim existeEnDB = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", txtRucTransportistaPrivado.Text.Trim)

                    '            If existeEnDB Is Nothing Then
                    '                txtIdentificacionTransportistanombre.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                    '                GrabarEntidadRapida(txtIdentificacionTransportistanombre, txtRucTransportistaPrivado)
                    '            Else
                    '                txtIdentificacionTransportistanombre.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                    '                txtIdentificacionTransportistanombre.Tag = existeEnDB.idEntidad

                    '            End If
                    '        Else
                    '            txtRucTransportistaPrivado.Clear()
                    '            txtIdentificacionTransportistanombre.Text = String.Empty
                    '            txtIdentificacionTransportistanombre.Tag = Nothing
                    '        End If

                    '    Else

                    '        'CUANDO NO HAY CONEXION A INTERNET
                    '        Dim existeEnDB = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", txtRucTransportistaPrivado.Text.Trim)
                    '        If existeEnDB Is Nothing Then
                    '            SelRazon.tipoEntidad = "CL"
                    '            SelRazon.nombreCompleto = txtIdentificacionTransportistanombre.Text.Trim
                    '            SelRazon.nrodoc = txtRucTransportistaPrivado.Text.Trim
                    '            SelRazon.tipoDoc = "1"
                    '            SelRazon.tipoPersona = "N"
                    '            'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                    '            'GrabarEntidadRapida()
                    '            GrabarEnFormBasicoPublico(TextNumDocPublico, txtRucTransportistaPrivado)
                    '        Else
                    '            txtRucTransportistaPrivado.Text = existeEnDB.nombreCompleto
                    '            txtRucTransportistaPrivado.Tag = existeEnDB.idEntidad
                    '            txtRucTransportistaPrivado.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)

                    '        End If
                    '    End If



                    Case 11 'razonSocial
                        ComboDocPublico.Text = "RUC"
                        Dim objeto As Boolean = ValidationRUC(txtRucTransportistaPrivado.Text.Trim)
                        If objeto = False Then

                            MessageBox.Show("Debe Ingresar un número correcto de ruc", "Ingresar identificación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Cursor = Cursors.Default
                            txtRucTransportistaPrivado.Clear()
                            Exit Sub
                        End If

                        If My.Computer.Network.IsAvailable = True Then
                            'VALIDAR SI EXISTE EN LA bd LOCAL PRIMERO 
                            If GetValidarLocalDB(txtRucTransportistaPrivado.Text.Trim, TextTransportistaPrivado, txtRucTransportistaPrivado) = False Then
                                txtRucTransportistaPrivado.ReadOnly = True

                                'Select Case ToggleConsultas.ToggleState
                                '    Case ToggleButton2.ToggleButtonState.OFF ' API
                                '  GetConsultaSunatAsync(TextNumDocPublico.Text.Trim)
                                GetApiSunat(txtRucTransportistaPrivado.Text.Trim, TextTransportistaPrivado, txtRucTransportistaPrivado)
                                '    Case ToggleButton2.ToggleButtonState.ON ' WEB
                                '        BgProveedor.RunWorkerAsync()
                                'End Select
                            End If
                        Else
                            'SI NO HAY CONEXION A INTERNET
                            If GetValidarLocalDB(txtRucTransportistaPrivado.Text.Trim, TextTransportistaPrivado, txtRucTransportistaPrivado) = False Then
                                Dim nroDoc = txtRucTransportistaPrivado.Text.Trim.Substring(0, 1).ToString
                                If nroDoc = "1" Then
                                    'SelRazon.tipoEntidad = "CL"
                                    'SelRazon.nombreCompleto = TextEmpresaPasajero.Text.Trim
                                    'SelRazon.nrodoc = TextNumDocPublico.Text.Trim
                                    'SelRazon.tipoDoc = "6"
                                    'SelRazon.tipoPersona = "N"
                                    'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    'GrabarEntidadRapida()
                                    GrabarEnFormBasico(txtRucTransportistaPrivado, TextTransportistaPrivado)

                                    If TextTransportistaPrivado.Text.Trim.Length > 0 Then

                                    Else
                                        txtRucTransportistaPrivado.Clear()
                                        txtRucTransportistaPrivado.Select()
                                    End If
                                ElseIf nroDoc = "2" Then
                                    'SelRazon.tipoEntidad = "CL"
                                    'SelRazon.nombreCompleto = TextEmpresaPasajero.Text.Trim
                                    'SelRazon.nrodoc = TextNumDocPublico.Text.Trim
                                    'SelRazon.tipoDoc = "6"
                                    'SelRazon.tipoPersona = "J"
                                    'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    'GrabarEntidadRapida()
                                    GrabarEnFormBasico(txtRucTransportistaPrivado, TextTransportistaPrivado)

                                    If TextTransportistaPrivado.Text.Trim.Length > 0 Then

                                    Else
                                        txtRucTransportistaPrivado.Clear()
                                        txtRucTransportistaPrivado.Select()
                                    End If
                                End If
                            End If
                        End If

                    Case Else
                        TextTransportistaPrivado.Text = String.Empty
                        txtRucTransportistaPrivado.Text = String.Empty
                        MessageBox.Show("Ingrese un documento correcto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Select

            End If
            '    TextNumDocPublico.Enabled = True

        Catch ew As WebException

            If ew.Status = WebExceptionStatus.ProtocolError Then
                Dim [error] As String = New System.IO.StreamReader(ew.Response.GetResponseStream()).ReadToEnd()
                MessageBox.Show("DNI no encontrado en el padron, verifique si es menor de edad")
                TextNumDocPublico.Clear()
                TextNumDocPublico.Select()
                TextNumDocPublico.Focus()
                TextTransportistaPublico.Clear()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtDniTransportistaPublico_TextChanged(sender As Object, e As EventArgs) Handles txtDniTransportistaPublico.TextChanged

    End Sub

    Private Sub txtDniTransportistaPrivado_TextChanged(sender As Object, e As EventArgs) Handles txtDniTransportistaPrivado.TextChanged

    End Sub

    Private Sub txtDniTransportistaPrivado_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDniTransportistaPrivado.KeyDown
        Dim nombres = String.Empty
        Try
            'TextNumDocPublico.Enabled = False
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True

                Select Case txtDniTransportistaPrivado.Text.Trim.Length
                    Case 8 'dni
                        ComboDocPublico.Text = "DNI"
                        SelRazon = New entidad

                        If My.Computer.Network.IsAvailable = True Then
                            nombres = GetConsultarDNIReniecAPIs(txtDniTransportistaPrivado.Text.Trim)

                            If nombres.Trim.Length > 0 Then

                                If nombres = "DNI no encontrado en Padrón Electoral" Then
                                    txtDniTransportistaPrivado.Clear()
                                    txtDniTransportistaPrivado.Text = String.Empty
                                    txtDniTransportistaPrivado.Tag = Nothing
                                    Exit Sub
                                End If

                                SelRazon.tipoEntidad = "CL"
                                SelRazon.nombreCompleto = nombres
                                SelRazon.nrodoc = TextNumDocPublico.Text.Trim
                                SelRazon.tipoDoc = "1"
                                SelRazon.tipoPersona = "N"
                                txtIdentificacionTransportistanombrePrivado.Text = nombres

                                Dim existeEnDB = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", txtDniTransportistaPrivado.Text.Trim)

                                If existeEnDB Is Nothing Then
                                    txtIdentificacionTransportistanombrePrivado.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    GrabarEntidadRapida(txtIdentificacionTransportistanombrePrivado, txtDniTransportistaPrivado)
                                Else
                                    txtIdentificacionTransportistanombrePrivado.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    txtIdentificacionTransportistanombrePrivado.Tag = existeEnDB.idEntidad

                                End If
                            Else
                                txtDniTransportistaPrivado.Clear()
                                txtIdentificacionTransportistanombrePrivado.Text = String.Empty
                                txtIdentificacionTransportistanombrePrivado.Tag = Nothing
                            End If

                        Else

                            'CUANDO NO HAY CONEXION A INTERNET
                            Dim existeEnDB = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", txtDniTransportistaPrivado.Text.Trim)
                            If existeEnDB Is Nothing Then
                                SelRazon.tipoEntidad = "CL"
                                SelRazon.nombreCompleto = txtIdentificacionTransportistanombrePrivado.Text.Trim
                                SelRazon.nrodoc = txtDniTransportistaPrivado.Text.Trim
                                SelRazon.tipoDoc = "1"
                                SelRazon.tipoPersona = "N"
                                'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                'GrabarEntidadRapida()
                                GrabarEnFormBasicoPublico(txtDniTransportistaPrivado, txtIdentificacionTransportistanombrePrivado)
                            Else
                                txtDniTransportistaPrivado.Text = existeEnDB.nombreCompleto
                                txtDniTransportistaPrivado.Tag = existeEnDB.idEntidad
                                txtDniTransportistaPrivado.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)

                            End If
                        End If



                        'Case 11 'razonSocial
                        '    ComboDocPublico.Text = "RUC"
                        '    Dim objeto As Boolean = ValidationRUC(TextNumDocPublico.Text.Trim)
                        '    If objeto = False Then

                        '        MessageBox.Show("Debe Ingresar un número correcto de ruc", "Ingresar identificación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        '        Cursor = Cursors.Default
                        '        TextTransportistaPrivado.Clear()
                        '        Exit Sub
                        '    End If

                        '    If My.Computer.Network.IsAvailable = True Then
                        '        'VALIDAR SI EXISTE EN LA bd LOCAL PRIMERO 
                        '        If GetValidarLocalDB(txtDniTransportistaPrivado.Text.Trim, TextTransportistaPrivado, TextNumDocPublico) = False Then
                        '            TextNumDocPublico.ReadOnly = True

                        '            'Select Case ToggleConsultas.ToggleState
                        '            '    Case ToggleButton2.ToggleButtonState.OFF ' API
                        '            '  GetConsultaSunatAsync(TextNumDocPublico.Text.Trim)
                        '            GetApiSunat(TextNumDocPublico.Text.Trim, TextTransportistaPublico, TextNumDocPublico)
                        '            '    Case ToggleButton2.ToggleButtonState.ON ' WEB
                        '            '        BgProveedor.RunWorkerAsync()
                        '            'End Select
                        '        End If
                        '    Else
                        '        'SI NO HAY CONEXION A INTERNET
                        '        If GetValidarLocalDB(TextNumDocPublico.Text.Trim, TextTransportistaPublico, TextNumDocPublico) = False Then
                        '            Dim nroDoc = TextNumDocPublico.Text.Trim.Substring(0, 1).ToString
                        '            If nroDoc = "1" Then
                        '                'SelRazon.tipoEntidad = "CL"
                        '                'SelRazon.nombreCompleto = TextEmpresaPasajero.Text.Trim
                        '                'SelRazon.nrodoc = TextNumDocPublico.Text.Trim
                        '                'SelRazon.tipoDoc = "6"
                        '                'SelRazon.tipoPersona = "N"
                        '                'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        '                'GrabarEntidadRapida()
                        '                GrabarEnFormBasico(TextNumDocPublico, TextTransportistaPublico)

                        '                If TextTransportistaPublico.Text.Trim.Length > 0 Then

                        '                Else
                        '                    TextNumDocPublico.Clear()
                        '                    TextNumDocPublico.Select()
                        '                End If
                        '            ElseIf nroDoc = "2" Then
                        '                'SelRazon.tipoEntidad = "CL"
                        '                'SelRazon.nombreCompleto = TextEmpresaPasajero.Text.Trim
                        '                'SelRazon.nrodoc = TextNumDocPublico.Text.Trim
                        '                'SelRazon.tipoDoc = "6"
                        '                'SelRazon.tipoPersona = "J"
                        '                'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        '                'GrabarEntidadRapida()
                        '                GrabarEnFormBasico(TextNumDocPublico, TextTransportistaPublico)

                        '                If TextTransportistaPublico.Text.Trim.Length > 0 Then

                        '                Else
                        '                    TextNumDocPublico.Clear()
                        '                    TextNumDocPublico.Select()
                        '                End If
                        '            End If
                        '        End If
                        '    End If

                    Case Else
                        TextTransportistaPrivado.Text = String.Empty
                        txtIdentificacionTransportistanombrePrivado.Text = String.Empty
                        MessageBox.Show("Ingrese un documento correcto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Select

            End If
            '    TextNumDocPublico.Enabled = True

        Catch ew As WebException

            If ew.Status = WebExceptionStatus.ProtocolError Then
                Dim [error] As String = New System.IO.StreamReader(ew.Response.GetResponseStream()).ReadToEnd()
                MessageBox.Show("DNI no encontrado en el padron, verifique si es menor de edad")
                TextNumDocPublico.Clear()
                TextNumDocPublico.Select()
                TextNumDocPublico.Focus()
                TextTransportistaPublico.Clear()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region
End Class
