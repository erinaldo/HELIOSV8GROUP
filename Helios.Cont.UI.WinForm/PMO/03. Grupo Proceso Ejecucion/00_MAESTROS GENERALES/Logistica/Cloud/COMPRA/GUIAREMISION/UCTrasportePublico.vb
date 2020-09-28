Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Text.RegularExpressions
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports PopupControl
Imports ProcesosGeneralesCajamiSoft
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports HtmlAgilityPack
Public Class UCTrasportePublico

#Region "ATRIBUTOS"

    Private Property SelRazon As entidad
    Private Property entidadSA As New entidadSA
    Dim tipotroDoc As Integer
    Public Property ruc As String
#End Region
#Region "CONSTRUCTOR"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        dtpfechaEntregaBien.Value = DateTime.Now

        cbFechaGuia.Value = DateTime.Now
    End Sub
#End Region

    Private Sub txtrucTraspubl_KeyDown(sender As Object, e As KeyEventArgs) Handles txtrucTraspubl.KeyDown
        tipotroDoc = 1

        Dim nombres = String.Empty
        Try
            'TextNumIdentrazon.Enabled = False
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True

                If txtrucTraspubl.Text = ruc Then
                    MessageBox.Show("Trasportista no debe ser igual a Destinatario", "Debe Ingresar RUC correcto", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtrucTraspubl.Clear()
                    txtdatosTraspubl.Clear()
                Else

                    Select Case txtrucTraspubl.Text.Trim.Length
                        Case 8 'dni
                            MessageBox.Show("Debe Ingresar un número correcto de ruc", "Ingrese Correcto en numero de RUC", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        'SelRazon = New entidad

                        'If My.Computer.Network.IsAvailable = True Then
                        '    'PictureLoad.Visible = True

                        '    nombres = GetConsultarDNIReniec(txtrucTraspubl.Text.Trim)

                        '    If nombres.Trim.Length > 0 Then

                        '        If nombres = "DNI no encontrado en Padrón Electoral" Then
                        '            txtrucTraspubl.Clear()
                        '            txtdatosTraspubl.Text = String.Empty
                        '            txtdatosTraspubl.Tag = Nothing
                        '            'PictureLoad.Visible = False
                        '            Exit Sub
                        '        End If

                        '        SelRazon.tipoEntidad = "CL"
                        '        SelRazon.nombreCompleto = nombres
                        '        SelRazon.nrodoc = txtrucTraspubl.Text.Trim
                        '        SelRazon.tipoDoc = "1"
                        '        SelRazon.tipoPersona = "N"
                        '        txtdatosTraspubl.Text = nombres

                        '        Dim existeEnDB = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", txtrucTraspubl.Text.Trim)

                        '        If existeEnDB Is Nothing Then
                        '            txtdatosTraspubl.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        '            GrabarEntidadRapida()
                        '            'PictureLoad.Visible = False
                        '        Else
                        '            txtdatosTraspubl.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        '            txtdatosTraspubl.Tag = existeEnDB.idEntidad
                        '            'If RadioButton2.Checked = True Then
                        '            'TextFiltrar.Focus()
                        '            'TextFiltrar.Select()
                        '            'ElseIf RadioButton1.Checked = True Then
                        '            '    txtruc.Focus()
                        '            '    txtruc.Select()
                        '            'End If
                        '        End If
                        '    Else
                        '        txtrucTraspubl.Clear()
                        '        txtdatosTraspubl.Text = String.Empty
                        '        txtdatosTraspubl.Tag = Nothing
                        '    End If
                        '    'PictureLoad.Visible = False
                        'Else

                        '    'CUANDO NO HAY CONEXION A INTERNET
                        '    Dim existeEnDB = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", txtrucTraspubl.Text.Trim)
                        '    If existeEnDB Is Nothing Then
                        '        SelRazon.tipoEntidad = "CL"
                        '        SelRazon.nombreCompleto = txtdatosTraspubl.Text.Trim
                        '        SelRazon.nrodoc = txtrucTraspubl.Text.Trim
                        '        SelRazon.tipoDoc = "1"
                        '        SelRazon.tipoPersona = "N"
                        '        'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        '        'GrabarEntidadRapida()
                        '        GrabarEnFormBasico()
                        '        'PictureLoad.Visible = False
                        '    Else
                        '        txtdatosTraspubl.Text = existeEnDB.nombreCompleto
                        '        txtdatosTraspubl.Tag = existeEnDB.idEntidad
                        '        txtdatosTraspubl.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        '        'If RadioButton2.Checked = True Then
                        '        'TextFiltrar.Focus()
                        '        'TextFiltrar.Select()
                        '        'ElseIf RadioButton1.Checked = True Then
                        '        '    txtruc.Focus()
                        '        '    txtruc.Select()
                        '        'End If
                        '    End If
                        'End If



                        Case 11 'razonSocial
                            'PictureLoad.Visible = True
                            Dim objeto As Boolean = ValidationRUC(txtrucTraspubl.Text.Trim)
                            If objeto = False Then
                                'PictureLoad.Visible = False
                                MessageBox.Show("Debe Ingresar un número correcto de ruc", "Ingresar identificación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Cursor = Cursors.Default
                                txtdatosTraspubl.Clear()
                                Exit Sub
                            End If

                            If My.Computer.Network.IsAvailable = True Then
                                'VALIDAR SI EXISTE EN LA bd LOCAL PRIMERO 
                                If GetValidarLocalDB(txtrucTraspubl.Text.Trim) = False Then
                                    txtrucTraspubl.ReadOnly = True

                                    Select Case ToggleConsultas.ToggleState
                                        Case ToggleButton2.ToggleButtonState.OFF ' API
                                            '  GetConsultaSunatAsync(TextNumIdentrazon.Text.Trim)
                                            GetApiSunat(txtrucTraspubl.Text.Trim)
                                        Case ToggleButton2.ToggleButtonState.ON ' WEB
                                            BgProveedor.RunWorkerAsync()
                                    End Select
                                End If
                            Else
                                'SI NO HAY CONEXION A INTERNET
                                If GetValidarLocalDB(txtrucTraspubl.Text.Trim) = False Then
                                    Dim nroDoc = txtrucTraspubl.Text.Trim.Substring(0, 1).ToString
                                    If nroDoc = "1" Then
                                        'SelRazon.tipoEntidad = "CL"
                                        'SelRazon.nombreCompleto = TextEmpresaPasajero.Text.Trim
                                        'SelRazon.nrodoc = TextNumIdentrazon.Text.Trim
                                        'SelRazon.tipoDoc = "6"
                                        'SelRazon.tipoPersona = "N"
                                        'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                        'GrabarEntidadRapida()
                                        GrabarEnFormBasico()
                                        'PictureLoad.Visible = False
                                        If txtrucTraspubl.Text.Trim.Length > 0 Then
                                            'TextFiltrar.Select()
                                            'TextFiltrar.Focus()
                                        Else
                                            txtrucTraspubl.Clear()
                                            txtrucTraspubl.Select()
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
                                        'PictureLoad.Visible = False
                                        If txtdatosTraspubl.Text.Trim.Length > 0 Then
                                            'TextFiltrar.Select()
                                            'TextFiltrar.Focus()
                                        Else
                                            txtrucTraspubl.Clear()
                                            txtrucTraspubl.Select()
                                        End If
                                    End If
                                End If
                            End If

                        Case Else
                            txtdatosTraspubl.Text = String.Empty
                            txtrucTraspubl.Text = String.Empty
                            MessageBox.Show("Ingrese un documento correcto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End Select
                End If
            End If
            '    TextNumIdentrazon.Enabled = True

        Catch ew As WebException

            If ew.Status = WebExceptionStatus.ProtocolError Then
                'PictureLoad.Visible = False
                Dim [error] As String = New System.IO.StreamReader(ew.Response.GetResponseStream()).ReadToEnd()
                MessageBox.Show("DNI no encontrado en el padron, verifique si es menor de edad")
                txtrucTraspubl.Clear()
                txtrucTraspubl.Select()
                txtrucTraspubl.Focus()
                txtrucTraspubl.Clear()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub



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


    Private Sub GrabarEntidadRapida()
        Dim obEntidad As New entidad
        Dim entidadSA As New entidadSA
        Try

            obEntidad.idEmpresa = Gempresas.IdEmpresaRuc
            obEntidad.idOrganizacion = GEstableciento.IdEstablecimiento
            obEntidad.tipoEntidad = "CL"
            obEntidad.tipoDoc = SelRazon.tipoDoc
            obEntidad.tipoPersona = SelRazon.tipoPersona
            obEntidad.nrodoc = SelRazon.nrodoc
            If tipotroDoc = 1 Then
                obEntidad.nombreCompleto = txtdatosTraspubl.Text.Trim
            ElseIf tipotroDoc = 2 Then
                obEntidad.nombreCompleto = txtDatoTraspor.Text.Trim
            End If

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

            If tipotroDoc = 1 Then
                txtdatosTraspubl.Tag = codx
                Dim entidad As New entidad
                entidad.idEntidad = codx
                entidad.nrodoc = txtrucTraspubl.Text.Trim
                entidad.nombreCompleto = obEntidad.nombreCompleto
                entidad.tipoDoc = obEntidad.tipoDoc
                Me.Tag = entidad

            ElseIf tipotroDoc = 2 Then
                txtDatoTraspor.Tag = codx
                Dim entidad As New entidad
                entidad.idEntidad = codx
                entidad.nrodoc = txtdniDatosTras.Text.Trim
                entidad.nombreCompleto = obEntidad.nombreCompleto
                entidad.tipoDoc = obEntidad.tipoDoc
                Me.Tag = entidad
            End If
            'If RadioButton2.Checked = True Then
            '    textPersona.Focus()
            '    textPersona.Select()
            'ElseIf RadioButton1.Checked = True Then
            '    txtruc.Focus()
            '    txtruc.Select()
            'End If
            'Transporte.ListaEmpresas.Add(entidad)

            '    Dispose()

            'Se asigna cada uno de los datos registrados

        Catch ex As Exception
            'Manejo de errores
            MsgBox("No se pudo grabar el cliente." & vbCrLf & ex.Message, MsgBoxStyle.Critical)
            Me.Tag = Nothing
        End Try
    End Sub


    Private Function GetValidarLocalDB(idEntidad As String) As Boolean
        GetValidarLocalDB = False
        Dim entidadSA As New entidadSA

        Dim entidad = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", idEntidad)
        If entidad IsNot Nothing Then
            SelRazon = New entidad
            SelRazon = entidad

            If tipotroDoc = 1 Then
                txtdatosTraspubl.Text = entidad.nombreCompleto
                txtdatosTraspubl.Tag = entidad.idEntidad
                GetValidarLocalDB = True
                'PictureLoad.Visible = False

                If txtdatosTraspubl.Text.Trim.Length > 0 Then
                    'TextFiltrar.Select()
                    'TextFiltrar.Focus()
                Else
                    txtrucTraspubl.Clear()
                    txtrucTraspubl.Select()
                End If
            ElseIf tipotroDoc = 2 Then
                txtDatoTraspor.Text = entidad.nombreCompleto
                txtDatoTraspor.Tag = entidad.idEntidad
                GetValidarLocalDB = True
                'PictureLoad.Visible = False

                If txtDatoTraspor.Text.Trim.Length > 0 Then
                    'TextFiltrar.Select()
                    'TextFiltrar.Focus()
                Else
                    txtdniDatosTras.Clear()
                    txtdniDatosTras.Select()
                End If
            End If


        End If
    End Function

    Private Sub GrabarEnFormBasico()
        Dim f As New frmCrearENtidades
        f.strTipo = TIPO_ENTIDAD.CLIENTE
        f.CaptionLabels(0).Text = "Nuevo cliente"
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        If tipotroDoc = 1 Then
            If f.Tag IsNot Nothing Then
                Dim ent = CType(f.Tag, entidad)
                txtrucTraspubl.Text = ent.nrodoc
                txtdatosTraspubl.Text = ent.nombreCompleto
                txtdatosTraspubl.Tag = ent.idEntidad
            Else
                txtrucTraspubl.Text = String.Empty
                txtdatosTraspubl.Text = String.Empty
                txtdatosTraspubl.Tag = Nothing
            End If
        ElseIf tipotroDoc = 2 Then
            If f.Tag IsNot Nothing Then
                Dim ent = CType(f.Tag, entidad)
                txtdniDatosTras.Text = ent.nrodoc
                txtDatoTraspor.Text = ent.nombreCompleto
                txtDatoTraspor.Tag = ent.idEntidad
            Else
                txtdniDatosTras.Text = String.Empty
                txtDatoTraspor.Text = String.Empty
                txtDatoTraspor.Tag = Nothing
            End If
        End If


    End Sub


    Private Async Sub GetApiSunat(ByVal nroruc As String)
        SelRazon = New entidad()

        Using client = New HttpClient()

            If nroruc.ToString().Trim().Substring(0, 1) = "1" Then
                SelRazon.tipoPersona = "N"
            ElseIf nroruc.ToString().Trim().Substring(0, 1) = "2" Then
                SelRazon.tipoPersona = "J"
            End If

            'client.BaseAddress = New Uri("https://api.peruonline.cloud/v1/?ruc=10449245691")
            Dim responseTask = Await client.GetAsync("https://api.peruonline.cloud/v1/?ruc=" & nroruc)
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

                If tipotroDoc = 1 Then
                    txtdatosTraspubl.Text = students.NombreORazonSocial
                ElseIf tipotroDoc = 2 Then
                    txtDatoTraspor.Text = students.NombreORazonSocial
                End If

                SelRazon.estado = students.EstadoDelContribuyente
                SelRazon.nrodoc = students.Ruc
                SelRazon.direccion = students.Direccion & " " & students.Manzana & " " & students.Lote & " " & students.CodigoDeZona & " " & students.TipoDeZona

                SelRazon.TipoVia = students.TipoDeVia
                SelRazon.Via = students.NombreDeVia
                SelRazon.Ubigeo = students.Ubigeo

                GrabarEntidadRapida()
                'PictureLoad.Visible = False
            Else
                GetConsultaSunatAsync(nroruc)

                'TextProveedor.Clear()
                'PictureLoad.Visible = False
            End If

            If tipotroDoc = 1 Then
                txtrucTraspubl.ReadOnly = False
            ElseIf tipotroDoc = 2 Then
                txtdniDatosTras.ReadOnly = False
            End If



        End Using
    End Sub

    Private Sub BgProveedor_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgProveedor.DoWork
        If tipotroDoc = 1 Then
            GetConsultaSunatThread(txtrucTraspubl.Text)
        ElseIf tipotroDoc = 2 Then
            GetConsultaSunatThread(txtdniDatosTras.Text)
        End If
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
                '********/1/***************
                If tipotroDoc = 1 Then
                    txtdatosTraspubl.Text = company.RazonSocial
                ElseIf tipotroDoc = 2 Then
                    '********/2/***************
                    txtDatoTraspor.Text = company.RazonSocial
                End If



                SelRazon.nombreContacto = company.RazonSocial
                SelRazon.estado = company.ContribuyenteEstado
                SelRazon.nrodoc = company.Ruc
                SelRazon.direccion = company.DomicilioFiscal
                GrabarEntidadRapida()
                'PictureLoad.Visible = False
            Else

                If tipotroDoc = 1 Then
                    txtdatosTraspubl.Clear()
                ElseIf tipotroDoc = 2 Then
                    txtDatoTraspor.Clear()
                End If



                'PictureLoad.Visible = False
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

                If tipotroDoc = 1 Then
                    txtdatosTraspubl.Text = company.RazonSocial
                ElseIf tipotroDoc = 2 Then
                    '********/2/***************
                    txtDatoTraspor.Text = company.RazonSocial
                End If

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
                GrabarEntidadRapida()
                'PictureLoad.Visible = False
            Else

                If tipotroDoc = 1 Then
                    txtdatosTraspubl.Clear()
                ElseIf tipotroDoc = 2 Then
                    txtDatoTraspor.Clear()
                End If


                'PictureLoad.Visible = False
            End If
        End If
        If tipotroDoc = 1 Then
            txtrucTraspubl.ReadOnly = False
        ElseIf tipotroDoc = 2 Then
            txtdniDatosTras.ReadOnly = False
        End If

    End Sub

    Private Sub txtdniDatosTras_KeyDown(sender As Object, e As KeyEventArgs) Handles txtdniDatosTras.KeyDown
        tipotroDoc = 2

        Dim nombres = String.Empty
        Try
            'TextNumIdentrazon.Enabled = False
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True

                Select Case txtdniDatosTras.Text.Trim.Length
                    Case 8 'dni

                        SelRazon = New entidad

                        If My.Computer.Network.IsAvailable = True Then
                            'PictureLoad.Visible = True

                            nombres = GetConsultarDNIReniec(txtdniDatosTras.Text.Trim)

                            If nombres.Trim.Length > 0 Then

                                If nombres = "DNI no encontrado en Padrón Electoral" Then
                                    txtdniDatosTras.Clear()
                                    txtDatoTraspor.Text = String.Empty
                                    txtDatoTraspor.Tag = Nothing
                                    'PictureLoad.Visible = False
                                    Exit Sub
                                End If

                                SelRazon.tipoEntidad = "CL"
                                SelRazon.nombreCompleto = nombres
                                SelRazon.nrodoc = txtdniDatosTras.Text.Trim
                                SelRazon.tipoDoc = "1"
                                SelRazon.tipoPersona = "N"
                                txtDatoTraspor.Text = nombres

                                Dim existeEnDB = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", txtdniDatosTras.Text.Trim)

                                If existeEnDB Is Nothing Then
                                    txtDatoTraspor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    GrabarEntidadRapida()
                                    'PictureLoad.Visible = False
                                Else
                                    txtDatoTraspor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    txtDatoTraspor.Tag = existeEnDB.idEntidad
                                    'If RadioButton2.Checked = True Then
                                    'TextFiltrar.Focus()
                                    'TextFiltrar.Select()
                                    'ElseIf RadioButton1.Checked = True Then
                                    '    txtruc.Focus()
                                    '    txtruc.Select()
                                    'End If
                                End If
                            Else
                                txtdniDatosTras.Clear()
                                txtDatoTraspor.Text = String.Empty
                                txtDatoTraspor.Tag = Nothing
                            End If
                            'PictureLoad.Visible = False
                        Else

                            'CUANDO NO HAY CONEXION A INTERNET
                            Dim existeEnDB = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", txtdniDatosTras.Text.Trim)
                            If existeEnDB Is Nothing Then
                                SelRazon.tipoEntidad = "CL"
                                SelRazon.nombreCompleto = txtDatoTraspor.Text.Trim
                                SelRazon.nrodoc = txtdniDatosTras.Text.Trim
                                SelRazon.tipoDoc = "1"
                                SelRazon.tipoPersona = "N"
                                'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                'GrabarEntidadRapida()
                                GrabarEnFormBasico()
                                'PictureLoad.Visible = False
                            Else
                                txtDatoTraspor.Text = existeEnDB.nombreCompleto
                                txtDatoTraspor.Tag = existeEnDB.idEntidad
                                txtDatoTraspor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                'If RadioButton2.Checked = True Then
                                'TextFiltrar.Focus()
                                'TextFiltrar.Select()
                                'ElseIf RadioButton1.Checked = True Then
                                '    txtruc.Focus()
                                '    txtruc.Select()
                                'End If
                            End If
                        End If



                    Case 11 'razonSocial
                        'PictureLoad.Visible = True
                        Dim objeto As Boolean = ValidationRUC(txtdniDatosTras.Text.Trim)
                        If objeto = False Then
                            'PictureLoad.Visible = False
                            MessageBox.Show("Debe Ingresar un número correcto de ruc", "Ingresar identificación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Cursor = Cursors.Default
                            txtDatoTraspor.Clear()
                            Exit Sub
                        End If

                        If My.Computer.Network.IsAvailable = True Then
                            'VALIDAR SI EXISTE EN LA bd LOCAL PRIMERO 
                            If GetValidarLocalDB(txtdniDatosTras.Text.Trim) = False Then
                                txtdniDatosTras.ReadOnly = True

                                Select Case ToggleConsultas.ToggleState
                                    Case ToggleButton2.ToggleButtonState.OFF ' API
                                        '  GetConsultaSunatAsync(TextNumIdentrazon.Text.Trim)
                                        GetApiSunat(txtdniDatosTras.Text.Trim)
                                    Case ToggleButton2.ToggleButtonState.ON ' WEB
                                        BgProveedor.RunWorkerAsync()
                                End Select
                            End If
                        Else
                            'SI NO HAY CONEXION A INTERNET
                            If GetValidarLocalDB(txtdniDatosTras.Text.Trim) = False Then
                                Dim nroDoc = txtdniDatosTras.Text.Trim.Substring(0, 1).ToString
                                If nroDoc = "1" Then
                                    'SelRazon.tipoEntidad = "CL"
                                    'SelRazon.nombreCompleto = TextEmpresaPasajero.Text.Trim
                                    'SelRazon.nrodoc = TextNumIdentrazon.Text.Trim
                                    'SelRazon.tipoDoc = "6"
                                    'SelRazon.tipoPersona = "N"
                                    'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    'GrabarEntidadRapida()
                                    GrabarEnFormBasico()
                                    'PictureLoad.Visible = False
                                    If txtdniDatosTras.Text.Trim.Length > 0 Then
                                        'TextFiltrar.Select()
                                        'TextFiltrar.Focus()
                                    Else
                                        txtdniDatosTras.Clear()
                                        txtdniDatosTras.Select()
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
                                    'PictureLoad.Visible = False
                                    If txtDatoTraspor.Text.Trim.Length > 0 Then
                                        'TextFiltrar.Select()
                                        'TextFiltrar.Focus()
                                    Else
                                        txtdniDatosTras.Clear()
                                        txtdniDatosTras.Select()
                                    End If
                                End If
                            End If
                        End If

                    Case Else
                        txtDatoTraspor.Text = String.Empty
                        txtdniDatosTras.Text = String.Empty
                        MessageBox.Show("Ingrese un documento correcto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Select

            End If
            '    TextNumIdentrazon.Enabled = True

        Catch ew As WebException

            If ew.Status = WebExceptionStatus.ProtocolError Then
                'PictureLoad.Visible = False
                Dim [error] As String = New System.IO.StreamReader(ew.Response.GetResponseStream()).ReadToEnd()
                MessageBox.Show("DNI no encontrado en el padron, verifique si es menor de edad")
                txtdniDatosTras.Clear()
                txtdniDatosTras.Select()
                txtdniDatosTras.Focus()
                txtdniDatosTras.Clear()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class
