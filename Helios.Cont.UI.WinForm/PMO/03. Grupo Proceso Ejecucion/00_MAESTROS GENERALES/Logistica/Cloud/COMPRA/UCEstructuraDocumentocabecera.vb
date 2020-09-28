Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports HtmlAgilityPack
Imports ProcesosGeneralesCajamiSoft
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Threading.Tasks

Public Class UCEstructuraDocumentocabecera


#Region "Attributes"
    Public Property ListaTipoCategorias As New List(Of item)
    Private Property SelRazon As entidad
    Private Property entidadSA As New entidadSA
    Public Property ListaproductosComprados As List(Of documentocompradetalle)
    Private Property ProductoSA As New detalleitemsSA
    Public Property FormPurchase As FormCrearCompra
    Public listaProductos As List(Of detalleitems)
    Public Property ListaDocumentos As List(Of tabladetalle)
    Public Property almacenSA As New almacenSA
#End Region

#Region "Methods"

    Public Sub ListarTipodCategoria()
        Dim itemsa As New itemSA
        Dim TablaSA As New tablaDetalleSA

        ListaTipoCategorias = itemsa.ListaTotalItem(New item With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento})



    End Sub

    Public Sub AgregarComboXTipoCategoria(tipo As String)

        Dim Consultas = (From i In ListaTipoCategorias
                         Where i.tipo = tipo).ToList


        ComboTipoCategorias.ValueMember = "idItem"
        ComboTipoCategorias.DisplayMember = "descripcion"
        ComboTipoCategorias.DataSource = Consultas



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
    Private Sub ChangeTipoCambio(tipocambio As Decimal)
        ZeroRows()
    End Sub

    Private Sub ZeroRows()
        For Each i In GridCompra.Table.Records
            i.SetValue("totalmn", 0)
            i.SetValue("totalme", 0)
            i.SetValue("vcmn", 0)
            i.SetValue("vcme", 0)
            i.SetValue("pumn", 0)
            i.SetValue("pume", 0)
            i.SetValue("igvmn", 0)
            i.SetValue("igvme", 0)

            GetCalculoItem(i)
            EditarItemCompra(i)
        Next
    End Sub

    Private Sub FormatoGrid()
        For Each i In GridCompra.TableDescriptor.Columns
            i.AllowSort = False
            i.Appearance.AnyRecordFieldCell.TextColor = Color.Black
        Next
    End Sub

    Public Sub GetTotalesDocumento()

        Dim sumaTotal As Decimal = 0
        Dim sumaBaseImponible1 As Decimal = 0
        Dim sumaBaseImponible2 As Decimal = 0
        Dim sumaIva1 As Decimal = 0
        Dim sumaIva2 As Decimal = 0

        'MONEDA EXTRANJERA  
        Dim sumaTotalME As Decimal = 0
        Dim sumaBaseImponible1ME As Decimal = 0
        Dim sumaBaseImponible2ME As Decimal = 0
        Dim sumaIva1ME As Decimal = 0
        Dim sumaIva2ME As Decimal = 0

        For Each i In GridCompra.Table.Records

            If (i.GetValue("bonificaionval")) = "N" Then
                sumaTotal += CDec(i.GetValue("totalmn"))
                sumaTotalME += CDec(i.GetValue("totalme"))
                Select Case i.GetValue("gravado")
                    Case "1"
                        sumaBaseImponible1 += CDec(i.GetValue("vcmn"))
                        sumaIva1 += CDec(i.GetValue("igvmn"))

                        sumaBaseImponible1ME += CDec(i.GetValue("vcme"))
                        sumaIva1ME += CDec(i.GetValue("igvme"))
                    Case "2"
                        sumaBaseImponible2 += CDec(i.GetValue("vcmn"))
                        sumaIva2 += CDec(i.GetValue("igvmn"))

                        sumaBaseImponible2ME += CDec(i.GetValue("vcme"))
                        sumaIva2ME += CDec(i.GetValue("igvme"))
                End Select
            End If
        Next

        DigitalTotal.Value = sumaTotal
        DigitalME.Value = sumaTotalME
        'MONEDA NACIONAL
        txtTotalBase.DecimalValue = sumaBaseImponible1
        txtTotalBase2.DecimalValue = sumaBaseImponible2
        txtTotalIva.DecimalValue = sumaIva1

        'MONEDA EXTRANJERA
        txtTotalBaseME.DecimalValue = sumaBaseImponible1ME
        txtTotalBase2me.DecimalValue = sumaBaseImponible2ME
        txtTotalIvaME.DecimalValue = sumaIva1ME
    End Sub

    Private Sub GetTablasGenerales()
        Dim listaMoneda = General.TablasGenerales.GetMonedas()
        ListaDocumentos = General.TablasGenerales.GetComprobantesCompra()
        ListaDocumentos.Add(New tabladetalle With {.codigoDetalle = "9907", .descripcion = "NOTA"})

        Dim empresaAnioSA As New WCFService.ServiceAccess.empresaPeriodoSA

        Dim be As New empresaPeriodo
        be.idEmpresa = Gempresas.IdEmpresaRuc
        be.idCentroCosto = GEstableciento.IdEstablecimiento


        cboAnio.DisplayMember = "periodo"
        cboAnio.ValueMember = "periodo"
        cboAnio.DataSource = empresaAnioSA.GetListar_empresaPeriodo(be)
        cboAnio.SelectedValue = AnioGeneral


        Dim lstperiodomes = ListaDeMeses()

        cboMesPeriodo.DisplayMember = "Mes"
        cboMesPeriodo.ValueMember = "Codigo"
        cboMesPeriodo.DataSource = lstperiodomes
        cboMesPeriodo.SelectedValue = String.Format("{0:00}", Date.Now.Month)

        cboMesCompra.DataSource = General.ListaDeMeses()
        cboMesCompra.DisplayMember = "Mes"
        cboMesCompra.ValueMember = "Codigo"
        cboMesCompra.SelectedValue = String.Format("{0:00}", Date.Now.Month)
        TextAnio.DecimalValue = Date.Now.Year
        txtHora.Value = Date.Now
        cboMoneda.DataSource = listaMoneda
        cboMoneda.DisplayMember = "descripcion"
        cboMoneda.ValueMember = "codigoDetalle"

        cboTipoDoc.DataSource = ListaDocumentos
        cboTipoDoc.DisplayMember = "descripcion"
        cboTipoDoc.ValueMember = "codigoDetalle"

        Me.GridCompra.TableDescriptor.Columns("equivalencia").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.GridListControl

        Me.GridCompra.TableDescriptor.Columns("equivalencia").Appearance.AnyRecordFieldCell.DisplayMember = "unidadComercial"
        Me.GridCompra.TableDescriptor.Columns("equivalencia").Appearance.AnyRecordFieldCell.ValueMember = "equivalencia_id"
        Me.GridCompra.TableDescriptor.Columns("equivalencia").Appearance.AnyRecordFieldCell.DropDownStyle = GridDropDownStyle.Exclusive
        Me.GridCompra.TableDescriptor.Columns("equivalencia").Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.ShowCurrentCellEditing


        DigitalTotal.OuterFrameGradientStartColor = Color.White
        DigitalTotal.OuterFrameGradientEndColor = Color.White
        DigitalTotal.ForeColor = Color.Purple

        DigitalME.OuterFrameGradientStartColor = Color.White
        DigitalME.OuterFrameGradientEndColor = Color.White
        DigitalME.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
    End Sub

    Private Function GetConsultarDNIReniec(Dni As String) As String
        Dim CLIENTE As New WebClient
        'Dim PAGINA As Stream = CLIENTE.OpenRead("http://aplicaciones007.jne.gob.pe/srop_publico/Consulta/Afiliado/GetNombresCiudadano?DNI=" & Dni)
        Dim PAGINA As Stream = CLIENTE.OpenRead("http://clientes.reniec.gob.pe/padronElectoral2012/consulta.htm?hTipo=2&hDni=" & Dni)
        '  Dim PAGINA As Stream = CLIENTE.OpenRead("https://api.reniec.cloud/dni/" & Dni)

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

    Private Function GetValidarLocalDB(idEntidad As String) As Boolean
        GetValidarLocalDB = False
        Dim entidadSA As New entidadSA

        Dim entidad = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "PR", idEntidad)
        If entidad IsNot Nothing Then
            SelRazon = New entidad
            SelRazon = entidad
            TextProveedor.Text = entidad.nombreCompleto
            TextProveedor.Tag = entidad.idEntidad
            GetValidarLocalDB = True
            PictureLoad.Visible = False
        End If
    End Function

    Private Sub GrabarEntidadRapida()
        Dim obEntidad As New entidad
        Dim entidadSA As New entidadSA
        Try
            'Se asigna cada uno de los datos registrados
            obEntidad.idEmpresa = Gempresas.IdEmpresaRuc
            obEntidad.idOrganizacion = GEstableciento.IdEstablecimiento
            obEntidad.tipoEntidad = "PR"
            obEntidad.tipoDoc = SelRazon.tipoDoc
            obEntidad.tipoPersona = SelRazon.tipoPersona
            obEntidad.nrodoc = SelRazon.nrodoc
            obEntidad.nombreCompleto = TextProveedor.Text.Trim
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

            TextProveedor.Tag = codx
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

    Private Sub GrabarEntidadRapidaThread()
        Dim obEntidad As New entidad
        Dim entidadSA As New entidadSA
        Try
            'Se asigna cada uno de los datos registrados
            obEntidad.idEmpresa = Gempresas.IdEmpresaRuc
            obEntidad.idOrganizacion = GEstableciento.IdEstablecimiento
            obEntidad.tipoEntidad = "PR"
            obEntidad.tipoDoc = SelRazon.tipoDoc
            obEntidad.tipoPersona = SelRazon.tipoPersona
            obEntidad.nrodoc = SelRazon.nrodoc
            obEntidad.nombreCompleto = SelRazon.nombreCompleto
            obEntidad.cuentaAsiento = "4213"
            obEntidad.direccion = SelRazon.direccion
            If SelRazon.direccion IsNot Nothing Then
                If SelRazon.direccion.Trim.Length > 0 Then
                    obEntidad.entidadAtributos = New List(Of entidadAtributos)
                    obEntidad.entidadAtributos.Add(New entidadAtributos With {
                                                   .Action = BaseBE.EntityAction.INSERT,
                                                   .tipo = "DOMICILIO",
                                                   .estado = 1,
                                                   .valorAtributo = SelRazon.direccion,
                                                   .usuarioModificacion = usuario.IDUsuario,
                                                   .fechaModificacion = Date.Now
                                                   })
                End If
            End If
            obEntidad.estado = StatusEntidad.Activo
            Dim codx As Integer = entidadSA.GrabarEntidad(obEntidad)

            TextProveedor.Tag = codx
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

    Private Sub GetConsultaSunatAsync(ruc As String)
        SelRazon = New entidad
        Dim nroDoc = ruc.Substring(0, 1).ToString
        If nroDoc = "1" Then

            'getRuc donde ase llama como el company
            Dim sunat As New Helios.Consultas.Sunat.Sunat()
            sunat.GenerateCapcha()
            Dim valorCapcha = sunat.Decode_Capcha()
            Dim company As ProcesosJH.DatosRuc = ProcesosJH.ConsultarRUC(ruc, valorCapcha)

            'Dim datosSunat = New Helios.Sunat.Consulta.GetConsultaSunat()
            'Dim company = datosSunat.GetConsultaRuc(ruc)

            '  Dim company = CType(Await SoftPackERP_Sunat.GetRucContribuyenteSPK.GetContribuyente(ruc), SoftPackERP_Sunat.CompanyJuridico)
            If company.Ruc IsNot Nothing Then
                If company.RazonSocial = "ERROR" Then
                    TextProveedor.Clear()
                    TextNumIdentrazon.Select()
                    PictureLoad.Visible = False
                Else
                    If company.TipoContribuyente = "PERSONA NATURAL SIN NEGOCIO" Then
                        SelRazon.tipoPersona = "N"
                        SelRazon.tipoDoc = "6"
                    End If
                    SelRazon.tipoEntidad = "PR"
                    SelRazon.nombreCompleto = company.RazonSocial
                    TextProveedor.Text = company.RazonSocial
                    SelRazon.nombreContacto = company.RazonSocial
                    SelRazon.estado = company.Estado_Contribuyente
                    SelRazon.nrodoc = company.Ruc
                    SelRazon.direccion = company.DireccionDomicilioFiscal
                    GrabarEntidadRapida()
                    PictureLoad.Visible = False
                    TextBoxExt1.Select()
                End If
                'If company.ContribuyenteTipo = "PERSONA NATURAL SIN NEGOCIO" Then
                '    SelRazon.tipoPersona = "N"
                '    SelRazon.tipoDoc = "6"
                'End If
                'SelRazon.tipoEntidad = "PR"
                'SelRazon.nombreCompleto = company.RazonSocial
                'TextProveedor.Text = company.RazonSocial
                'SelRazon.nombreContacto = company.RazonSocial
                'SelRazon.estado = company.ContribuyenteEstado
                'SelRazon.nrodoc = company.Ruc
                'SelRazon.direccion = company.DomicilioFiscal
                'GrabarEntidadRapida()
                'PictureLoad.Visible = False
                'TextBoxExt1.Select()
            Else
                MessageBox.Show("No hay conexión con el servidor")
                TextProveedor.Clear()
                PictureLoad.Visible = False
            End If
        ElseIf nroDoc = "2" Then
            Dim sunat As New Helios.Consultas.Sunat.Sunat()
            sunat.GenerateCapcha()
            Dim valorCapcha = sunat.Decode_Capcha()
            Dim company As ProcesosJH.DatosRuc = ProcesosJH.ConsultarRUC(ruc, valorCapcha)

            'Dim company = CType(Await SoftPackERP_Sunat.GetRucContribuyenteSPK.GetContribuyente(ruc), SoftPackERP_Sunat.CompanyJuridico)
            If company.Ruc IsNot Nothing Then
                'If company.ContribuyenteTipo = "SOCIEDAD ANONIMA CERRADA" Then
                If company.RazonSocial = "ERROR" Then
                    TextProveedor.Clear()
                    TextNumIdentrazon.Select()
                    PictureLoad.Visible = False
                Else
                    SelRazon.tipoPersona = "J"
                    SelRazon.tipoDoc = "6"
                    '  End If
                    SelRazon.nombreCompleto = company.RazonSocial
                    SelRazon.nombreContacto = company.RazonSocial
                    TextProveedor.Text = company.RazonSocial
                    SelRazon.estado = company.Estado_Contribuyente
                    SelRazon.direccion = company.DireccionDomicilioFiscal
                    SelRazon.nrodoc = company.Ruc
                    'If company.RepresentanteLegal IsNot Nothing Then
                    '    If company.RepresentanteLegal.Dni41094462 IsNot Nothing Then
                    '        With company.RepresentanteLegal.Dni41094462
                    '            txtContacto.Text = String.Format("{0}/{1}/{2}", .Cargo, .Nombre, .Desde)
                    '        End With
                    '    End If
                    'End If
                    GrabarEntidadRapida()
                    PictureLoad.Visible = False
                    TextBoxExt1.Select()
                End If
            Else
                MessageBox.Show("No hay conexión con el servidor")
                TextProveedor.Clear()
                PictureLoad.Visible = False
            End If
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

    'Private Async Sub GetConsultaSunatAsync(ruc As String)
    '    SelRazon = New entidad
    '    Dim nroDoc = ruc.Substring(0, 1).ToString
    '    If nroDoc = "1" Then

    '        'getRuc donde ase llama como el company
    '        Dim sunat As New Helios.Consultas.Sunat.Sunat()
    '        sunat.GenerateCapcha()
    '        Dim valorCapcha = sunat.Decode_Capcha()
    '        Dim company As ProcesosJH.DatosRuc = ProcesosJH.ConsultarRUC(ruc, valorCapcha)

    '        'Dim datosSunat = New Helios.Sunat.Consulta.GetConsultaSunat()
    '        'Dim company = datosSunat.GetConsultaRuc(ruc)

    '        '  Dim company = CType(Await SoftPackERP_Sunat.GetRucContribuyenteSPK.GetContribuyente(ruc), SoftPackERP_Sunat.CompanyJuridico)
    '        If company.Ruc IsNot Nothing Then
    '            If company.TipoContribuyente = "PERSONA NATURAL SIN NEGOCIO" Then
    '                SelRazon.tipoPersona = "N"
    '                SelRazon.tipoDoc = "6"
    '            End If
    '            SelRazon.tipoEntidad = "PR"
    '            SelRazon.nombreCompleto = company.RazonSocial
    '            TextProveedor.Text = company.RazonSocial
    '            SelRazon.nombreContacto = company.RazonSocial
    '            SelRazon.estado = company.Estado_Contribuyente
    '            SelRazon.nrodoc = company.Ruc
    '            SelRazon.direccion = company.DireccionDomicilioFiscal
    '            GrabarEntidadRapida()
    '            PictureLoad.Visible = False
    '            TextBoxExt1.Select()

    '            'If company.ContribuyenteTipo = "PERSONA NATURAL SIN NEGOCIO" Then
    '            '    SelRazon.tipoPersona = "N"
    '            '    SelRazon.tipoDoc = "6"
    '            'End If
    '            'SelRazon.tipoEntidad = "PR"
    '            'SelRazon.nombreCompleto = company.RazonSocial
    '            'TextProveedor.Text = company.RazonSocial
    '            'SelRazon.nombreContacto = company.RazonSocial
    '            'SelRazon.estado = company.ContribuyenteEstado
    '            'SelRazon.nrodoc = company.Ruc
    '            'SelRazon.direccion = company.DomicilioFiscal
    '            'GrabarEntidadRapida()
    '            'PictureLoad.Visible = False
    '            'TextBoxExt1.Select()
    '        Else
    '            MessageBox.Show("No hay conexión con el servidor")
    '            TextProveedor.Clear()
    '            PictureLoad.Visible = False
    '        End If
    '    ElseIf nroDoc = "2" Then
    '        Dim sunat As New Helios.Consultas.Sunat.Sunat()
    '        sunat.GenerateCapcha()
    '        Dim valorCapcha = sunat.Decode_Capcha()
    '        Dim company As ProcesosJH.DatosRuc = ProcesosJH.ConsultarRUC(ruc, valorCapcha)

    '        'Dim company = CType(Await SoftPackERP_Sunat.GetRucContribuyenteSPK.GetContribuyente(ruc), SoftPackERP_Sunat.CompanyJuridico)
    '        If company.Ruc IsNot Nothing Then
    '            'If company.ContribuyenteTipo = "SOCIEDAD ANONIMA CERRADA" Then
    '            SelRazon.tipoPersona = "J"
    '            SelRazon.tipoDoc = "6"
    '            '  End If
    '            SelRazon.nombreCompleto = company.RazonSocial
    '            SelRazon.nombreContacto = company.RazonSocial
    '            TextProveedor.Text = company.RazonSocial
    '            SelRazon.estado = company.Estado_Contribuyente
    '            SelRazon.direccion = company.DireccionDomicilioFiscal
    '            SelRazon.nrodoc = company.Ruc
    '            'If company.RepresentanteLegal IsNot Nothing Then
    '            '    If company.RepresentanteLegal.Dni41094462 IsNot Nothing Then
    '            '        With company.RepresentanteLegal.Dni41094462
    '            '            txtContacto.Text = String.Format("{0}/{1}/{2}", .Cargo, .Nombre, .Desde)
    '            '        End With
    '            '    End If
    '            'End If
    '            GrabarEntidadRapida()
    '            PictureLoad.Visible = False
    '            TextBoxExt1.Select()
    '        Else
    '            MessageBox.Show("No hay conexión con el servidor")
    '            TextProveedor.Clear()
    '            PictureLoad.Visible = False
    '        End If
    '    End If

    'End Sub

    Private Sub GrabarEnFormBasico()
        Dim f As New frmCrearENtidades
        f.strTipo = TIPO_ENTIDAD.PROVEEDOR
        f.CaptionLabels(0).Text = "Nuevo proveedor"
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        If f.Tag IsNot Nothing Then
            Dim ent = CType(f.Tag, entidad)
            TextNumIdentrazon.Text = ent.nrodoc
            TextProveedor.Text = ent.nombreCompleto
            TextProveedor.Tag = ent.idEntidad
            TextBoxExt1.Select()
        Else
            TextNumIdentrazon.Text = String.Empty
            TextProveedor.Text = String.Empty
            TextProveedor.Tag = Nothing
        End If
    End Sub
#End Region

#Region "Constructors"
    Public Sub New(formCompra As FormCrearCompra)

        ' This call is required by the designer.
        InitializeComponent()
        FormPurchase = formCompra
        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(GridCompra, False, False, 9.0F)
        ListaproductosComprados = New List(Of documentocompradetalle)
        GetTablasGenerales()
        ListarTipodCategoria()
        FormatoGrid()
        listaProductos = New List(Of detalleitems)
        GridCompra.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
        ComboDespacho.Items.Add("")
        ComboDespacho.Items.Add("UN ALMACEN")
        'ComboDespacho.Items.Add("EN TRANSITO")

        ServicePointManager.ServerCertificateValidationCallback = AddressOf AcceptAllCertifications

    End Sub

#End Region

#Region "Events"

    Public Function AcceptAllCertifications(ByVal sender As Object, ByVal certification As System.Security.Cryptography.X509Certificates.X509Certificate, ByVal chain As System.Security.Cryptography.X509Certificates.X509Chain, ByVal sslPolicyErrors As System.Net.Security.SslPolicyErrors) As Boolean
        Return True
    End Function

    Private Sub TextNumIdentrazon_KeyDown(sender As Object, e As KeyEventArgs) Handles TextNumIdentrazon.KeyDown
        Dim nombres = String.Empty
        Try
            'TextNumIdentrazon.Enabled = False
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True

                Select Case TextNumIdentrazon.Text.Trim.Length
                    Case 8 'dni

                        SelRazon = New entidad

                        If My.Computer.Network.IsAvailable = True Then
                            PictureLoad.Visible = True
                            'nombres = GetConsultarDNIReniec(TextNumIdentrazon.Text.Trim)
                            nombres = GetConsultarDNIReniecAPIs(TextNumIdentrazon.Text.Trim)

                            If nombres.Trim.Length > 0 Then

                                If nombres = "DNI no encontrado en Padrón Electoral" Then
                                    TextNumIdentrazon.Clear()
                                    TextProveedor.Text = String.Empty
                                    TextProveedor.Tag = Nothing
                                    PictureLoad.Visible = False
                                    Exit Sub
                                End If

                                SelRazon.tipoEntidad = "PR"
                                SelRazon.nombreCompleto = nombres
                                SelRazon.nrodoc = TextNumIdentrazon.Text.Trim
                                SelRazon.tipoDoc = "1"
                                SelRazon.tipoPersona = "N"
                                TextProveedor.Text = nombres

                                Dim existeEnDB = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "PR", TextNumIdentrazon.Text.Trim)

                                If existeEnDB Is Nothing Then
                                    TextProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    GrabarEntidadRapida()
                                    PictureLoad.Visible = False
                                    TextBoxExt1.Select()
                                Else
                                    TextProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    TextProveedor.Tag = existeEnDB.idEntidad
                                    'If RadioButton2.Checked = True Then
                                    TextBoxExt1.Focus()
                                    TextBoxExt1.Select()
                                    'ElseIf RadioButton1.Checked = True Then
                                    '    txtruc.Focus()
                                    '    txtruc.Select()
                                    'End If
                                End If
                            Else
                                TextNumIdentrazon.Clear()
                                TextProveedor.Text = String.Empty
                                TextProveedor.Tag = Nothing
                            End If
                            PictureLoad.Visible = False
                        Else

                            'CUANDO NO HAY CONEXION A INTERNET
                            Dim existeEnDB = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "PR", TextNumIdentrazon.Text.Trim)
                            If existeEnDB Is Nothing Then
                                SelRazon.tipoEntidad = "PR"
                                SelRazon.nombreCompleto = TextProveedor.Text.Trim
                                SelRazon.nrodoc = TextNumIdentrazon.Text.Trim
                                SelRazon.tipoDoc = "1"
                                SelRazon.tipoPersona = "N"
                                'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                'GrabarEntidadRapida()
                                GrabarEnFormBasico()
                                PictureLoad.Visible = False
                                TextBoxExt1.Select()
                            Else
                                TextProveedor.Text = existeEnDB.nombreCompleto
                                TextProveedor.Tag = existeEnDB.idEntidad
                                TextProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                'If RadioButton2.Checked = True Then
                                TextBoxExt1.Focus()
                                TextBoxExt1.Select()
                                'ElseIf RadioButton1.Checked = True Then
                                '    txtruc.Focus()
                                '    txtruc.Select()
                                'End If
                            End If
                        End If



                    Case 11 'razonSocial
                        PictureLoad.Visible = True
                        Dim objeto As Boolean = ValidationRUC(TextNumIdentrazon.Text.Trim)
                        If objeto = False Then
                            PictureLoad.Visible = False
                            MessageBox.Show("Debe Ingresar un número correcto de ruc", "Ingresar identificación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Cursor = Cursors.Default
                            TextProveedor.Clear()
                            Exit Sub
                        End If

                        If My.Computer.Network.IsAvailable = True Then
                            'VALIDAR SI EXISTE EN LA bd LOCAL PRIMERO 
                            If GetValidarLocalDB(TextNumIdentrazon.Text.Trim) = False Then
                                'GetConsultaSunatAsync(TextNumIdentrazon.Text.Trim)
                                TextNumIdentrazon.ReadOnly = True
                                ' BgProveedor.RunWorkerAsync()

                                Select Case ToggleConsultas.ToggleState
                                    Case ToggleButton2.ToggleButtonState.OFF ' API
                                        '  GetConsultaSunatAsync(TextNumIdentrazon.Text.Trim)
                                        GetApiSunat(TextNumIdentrazon.Text.Trim)
                                    Case ToggleButton2.ToggleButtonState.ON ' WEB
                                        BgProveedor.RunWorkerAsync()
                                End Select

                            End If
                        Else
                            'SI NO HAY CONEXION A INTERNET
                            If GetValidarLocalDB(TextNumIdentrazon.Text.Trim) = False Then
                                Dim nroDoc = TextNumIdentrazon.Text.Trim.Substring(0, 1).ToString
                                If nroDoc = "1" Then
                                    'SelRazon.tipoEntidad = "PR"
                                    'SelRazon.nombreCompleto = TextEmpresaPasajero.Text.Trim
                                    'SelRazon.nrodoc = TextNumIdentrazon.Text.Trim
                                    'SelRazon.tipoDoc = "6"
                                    'SelRazon.tipoPersona = "N"
                                    'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    'GrabarEntidadRapida()
                                    GrabarEnFormBasico()
                                    PictureLoad.Visible = False
                                ElseIf nroDoc = "2" Then
                                    'SelRazon.tipoEntidad = "PR"
                                    'SelRazon.nombreCompleto = TextEmpresaPasajero.Text.Trim
                                    'SelRazon.nrodoc = TextNumIdentrazon.Text.Trim
                                    'SelRazon.tipoDoc = "6"
                                    'SelRazon.tipoPersona = "J"
                                    'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    'GrabarEntidadRapida()
                                    GrabarEnFormBasico()
                                    PictureLoad.Visible = False
                                End If
                            End If
                        End If

                    Case Else
                        TextProveedor.Text = String.Empty
                        TextNumIdentrazon.Text = String.Empty
                        MessageBox.Show("Ingrese un documento correcto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Select

            End If
            '    TextNumIdentrazon.Enabled = True

        Catch ew As WebException

            If ew.Status = WebExceptionStatus.ProtocolError Then
                PictureLoad.Visible = False
                Dim [error] As String = New System.IO.StreamReader(ew.Response.GetResponseStream()).ReadToEnd()
                MessageBox.Show("DNI no encontrado en el padron, verifique si es menor de edad")
                TextNumIdentrazon.Clear()
                TextNumIdentrazon.Select()
                TextNumIdentrazon.Focus()
                TextProveedor.Clear()
            ElseIf ew.Status = WebExceptionStatus.ConnectFailure Then
                PictureLoad.Visible = False
                'Dim [error] As String = New System.IO.StreamReader(ew.Response.GetResponseStream()).ReadToEnd()
                MessageBox.Show("No hay conexión con el servidor de la reniec")
                TextNumIdentrazon.Clear()
                TextNumIdentrazon.Select()
                TextNumIdentrazon.Focus()
                TextProveedor.Clear()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Private Async Sub GetApiSunat(ByVal nroruc As String)
    '    SelRazon = New entidad()
    '    Dim responseTask As New HttpResponseMessage
    '    Using client = New HttpClient()
    '        If nroruc.ToString().Trim().Substring(0, 1) = "1" Then
    '            SelRazon.tipoPersona = "N"
    '        ElseIf nroruc.ToString().Trim().Substring(0, 1) = "2" Then
    '            SelRazon.tipoPersona = "J"
    '        End If

    '        Select Case ApiRucOption
    '            Case ApisRuc.ApiRucCloudPeru
    '                responseTask = Await client.GetAsync("https://api.peruonline.cloud/v1/?ruc=" & nroruc)

    '                If responseTask.IsSuccessStatusCode Then
    '                    Dim readTask = responseTask.Content.ReadAsAsync(Of SunatContribuyente)()
    '                    readTask.Wait()
    '                    Dim students = readTask.Result
    '                    SelRazon.tipoDoc = "6"
    '                    SelRazon.tipoEntidad = "CL"
    '                    SelRazon.nombreCompleto = students.NombreORazonSocial
    '                    SelRazon.nombreContacto = students.NombreORazonSocial
    '                    TextProveedor.Text = students.NombreORazonSocial
    '                    SelRazon.estado = students.EstadoDelContribuyente
    '                    SelRazon.nrodoc = students.Ruc
    '                    SelRazon.direccion = students.Direccion & " " & students.Manzana & " " & students.Lote & " " & students.CodigoDeZona & " " & students.TipoDeZona

    '                    SelRazon.TipoVia = students.TipoDeVia
    '                    SelRazon.Via = students.NombreDeVia
    '                    SelRazon.Ubigeo = students.Ubigeo

    '                    GrabarEntidadRapida()
    '                    PictureLoad.Visible = False
    '                Else
    '                    GetConsultaSunatAsync(nroruc)

    '                    'TextProveedor.Clear()
    '                    'PictureLoad.Visible = False
    '                End If
    '                TextNumIdentrazon.ReadOnly = False

    '            Case ApisRuc.ApiRucSunatCloud
    '                responseTask = Await client.GetAsync("https://api.sunat.cloud/ruc/" & nroruc)

    '                If responseTask.IsSuccessStatusCode Then
    '                    Dim readTask = responseTask.Content.ReadAsAsync(Of SunatContribuyente2)()
    '                    readTask.Wait()
    '                    Dim students = readTask.Result
    '                    SelRazon.tipoDoc = "6"
    '                    SelRazon.tipoEntidad = "CL"
    '                    SelRazon.nombreCompleto = students.NombreORazonSocial
    '                    SelRazon.nombreContacto = students.NombreORazonSocial
    '                    TextProveedor.Text = students.NombreORazonSocial
    '                    SelRazon.estado = students.EstadoDelContribuyente
    '                    SelRazon.nrodoc = students.Ruc
    '                    SelRazon.direccion = students.Direccion

    '                    'SelRazon.TipoVia = students.TipoDeVia
    '                    'SelRazon.Via = students.NombreDeVia
    '                    'SelRazon.Ubigeo = students.Ubigeo

    '                    GrabarEntidadRapida()
    '                    PictureLoad.Visible = False
    '                Else
    '                    GetConsultaSunatAsync(nroruc)

    '                    'TextProveedor.Clear()
    '                    'PictureLoad.Visible = False
    '                End If
    '                TextNumIdentrazon.ReadOnly = False

    '            Case ApisRuc.ApiRucaqfac
    '                responseTask = Await client.GetAsync("http://ruc.aqpfact.pe/sunat/" & nroruc)

    '                If responseTask.IsSuccessStatusCode Then
    '                    Dim readTask = responseTask.Content.ReadAsAsync(Of SunatContribuyente3)()
    '                    readTask.Wait()
    '                    Dim students = readTask.Result
    '                    SelRazon.tipoDoc = "6"
    '                    SelRazon.tipoEntidad = "CL"
    '                    SelRazon.nombreCompleto = students.NombreORazonSocial
    '                    SelRazon.nombreContacto = students.NombreORazonSocial
    '                    TextProveedor.Text = students.NombreORazonSocial
    '                    SelRazon.estado = students.EstadoDelContribuyente
    '                    SelRazon.nrodoc = students.Ruc
    '                    SelRazon.direccion = students.Direccion

    '                    'SelRazon.TipoVia = students.TipoDeVia
    '                    'SelRazon.Via = students.NombreDeVia
    '                    'SelRazon.Ubigeo = students.Ubigeo

    '                    GrabarEntidadRapida()
    '                    PictureLoad.Visible = False
    '                Else
    '                    GetConsultaSunatAsync(nroruc)

    '                    'TextProveedor.Clear()
    '                    'PictureLoad.Visible = False
    '                End If
    '                TextNumIdentrazon.ReadOnly = False

    '        End Select
    '    End Using
    ''End Sub

    Private Async Sub GetApiSunat(ByVal nroruc As String)


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
                        responseTask = Await client.GetAsync("https://api.peruonline.cloud/v1/?ruc=" & nroruc)

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
                            SelRazon.direccion = students.Direccion & " " & students.Manzana & " " & students.Lote & " " & students.CodigoDeZona & " " & students.TipoDeZona

                            SelRazon.TipoVia = students.TipoDeVia
                            SelRazon.Via = students.NombreDeVia
                            SelRazon.Ubigeo = students.Ubigeo

                            GrabarEntidadRapida()
                            PictureLoad.Visible = False
                        Else
                            GetConsultaSunatAsync(nroruc)

                            'TextProveedor.Clear()
                            'PictureLoad.Visible = False
                        End If
                        TextNumIdentrazon.ReadOnly = False

                    Catch ex As WebException
                        PictureLoad.Visible = False
                        TextNumIdentrazon.ReadOnly = False
                    Catch ex As TaskCanceledException
                        PictureLoad.Visible = False
                        TextNumIdentrazon.ReadOnly = False
                        Dim Login As New frmCrearENtidades
                        Login.strTipo = TIPO_ENTIDAD.PROVEEDOR
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
                Case ApisRuc.ApiRucSunatCloud
                    'client.Timeout = TimeSpan.FromSeconds(5)
                    'responseTask = Await client.GetAsync("https://api.sunat.cloud/ruc/" & nroruc)

                    'If responseTask.IsSuccessStatusCode Then
                    '    Dim readTask = responseTask.Content.ReadAsAsync(Of SunatContribuyente2)()
                    '    readTask.Wait()
                    '    Dim students = readTask.Result
                    '    SelRazon.tipoDoc = "6"
                    '    SelRazon.tipoEntidad = "CL"
                    '    SelRazon.nombreCompleto = students.NombreORazonSocial
                    '    SelRazon.nombreContacto = students.NombreORazonSocial
                    '    TextProveedor.Text = students.NombreORazonSocial
                    '    SelRazon.estado = students.EstadoDelContribuyente
                    '    SelRazon.nrodoc = students.Ruc
                    '    SelRazon.direccion = students.Direccion

                    '    'SelRazon.TipoVia = students.TipoDeVia
                    '    'SelRazon.Via = students.NombreDeVia
                    '    'SelRazon.Ubigeo = students.Ubigeo

                    '    GrabarEntidadRapida()
                    '    PictureLoad.Visible = False
                    'Else
                    '    GetConsultaSunatAsync(nroruc)

                    '    'TextProveedor.Clear()
                    '    'PictureLoad.Visible = False
                    'End If
                    'TextNumIdentrazon.ReadOnly = False

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
                            GrabarEntidadRapida()
                            PictureLoad.Visible = False
                        Else
                            GetConsultaSunatAsync(nroruc)
                            'TextProveedor.Clear()
                            'PictureLoad.Visible = False
                        End If
                        TextNumIdentrazon.ReadOnly = False
                    Catch ex As WebException
                        PictureLoad.Visible = False
                        TextNumIdentrazon.ReadOnly = False
                    Catch ex As TaskCanceledException
                        PictureLoad.Visible = False
                        TextNumIdentrazon.ReadOnly = False
                        Dim Login As New frmCrearENtidades
                        Login.strTipo = TIPO_ENTIDAD.PROVEEDOR
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

                            GrabarEntidadRapida()
                            PictureLoad.Visible = False
                        Else
                            GetConsultaSunatAsync(nroruc)

                            'TextProveedor.Clear()
                            'PictureLoad.Visible = False
                        End If
                        TextNumIdentrazon.ReadOnly = False
                    Catch ex As WebException
                        PictureLoad.Visible = False
                        TextNumIdentrazon.ReadOnly = False
                    Catch ex As TaskCanceledException
                        PictureLoad.Visible = False
                        TextNumIdentrazon.ReadOnly = False
                        Dim Login As New frmCrearENtidades
                        Login.strTipo = TIPO_ENTIDAD.PROVEEDOR
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

    Private Sub BunifuThinButton23_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBoxExt1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxExt1.KeyDown

        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        ElseIf e.KeyCode = Keys.Enter Then

            'If ComboAlmacen.Text.Trim.Length = 0 Then
            '    MessageBox.Show("Ingrese el almaén de destino!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    ComboDespacho.Select()
            '    ComboDespacho.DroppedDown = True
            '    Exit Sub
            'End If
            If TextBoxExt1.Text.Trim.Length > 0 AndAlso TextBoxExt1.Text.Trim.Length >= 2 Then
                Select Case ComboTipoBusqueda.Text
                    Case "PRODUCTO"


                        PictureLoadingProduct.Visible = True
                        listaProductos = ProductoSA.GetProductosWithEquivalencias(New detalleitems With {.descripcionItem = TextBoxExt1.Text, .idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento})

                        ListProductos.Items.Clear()

                        If listaProductos.Count > 0 Then
                            Dim consulta As New List(Of detalleitems)
                            consulta.Add(New detalleitems With {.descripcionItem = "Agregar nuevo"})
                            consulta.AddRange(listaProductos)
                            GetListProductos(consulta)

                            Me.PopupProductos.Size = New Size(636, 147)
                            Me.PopupProductos.ParentControl = Me.TextBoxExt1
                            Me.PopupProductos.ShowPopup(Point.Empty)
                            PictureLoadingProduct.Visible = False
                        Else
                            If Me.PopupProductos.IsShowing() Then
                                Me.PopupProductos.HidePopup(PopupCloseType.Canceled)
                            End If
                            PictureLoadingProduct.Visible = False

                            If MessageBox.Show("Desea crear el producto ahora?", "Nuevo producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                Dim frmNuevaExistencia As New frmNuevaExistencia
                                With frmNuevaExistencia
                                    If TextBoxExt1.Text.Trim.Length > 0 Then
                                        .UCNuenExistencia.txtProductoNew.Text = TextBoxExt1.Text.Trim
                                    End If

                                    If ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico Then
                                        .UCNuenExistencia.cboTipoExistencia.Enabled = False
                                        .UCNuenExistencia.cboUnidades.SelectedIndex = -1
                                        .UCNuenExistencia.cboUnidades.Enabled = True
                                    Else

                                    End If

                                    If Gempresas.Regimen = "1" Then
                                        .UCNuenExistencia.cboIgv.Text = "1 - GRAVADO"
                                        .UCNuenExistencia.cboIgv.Enabled = True
                                    Else
                                        .UCNuenExistencia.cboIgv.Text = "2 - EXONERADO"
                                        .UCNuenExistencia.cboIgv.Enabled = True
                                    End If
                                    '.UCNuenExistencia.chClasificacion.Checked = False
                                    .UCNuenExistencia.cboTipoExistencia.SelectedValue = "01"
                                    .UCNuenExistencia.cboUnidades.Text = "UNIDAD (BIENES)"
                                    .EstadoManipulacion = ENTITY_ACTIONS.INSERT
                                    .StartPosition = FormStartPosition.CenterParent
                                    .ShowDialog(Me)
                                    If frmNuevaExistencia.Tag IsNot Nothing Then
                                        Dim p = CType(frmNuevaExistencia.Tag, detalleitems)
                                        Dim prod = ProductoSA.GetUbicaProductoID(p.codigodetalle)
                                        listaProductos.Add(prod)
                                        AgregarProductoDetalleCompra(prod)
                                    End If
                                End With
                            End If
                        End If


                    Case "CODIGO BARRA"


                        PictureLoadingProduct.Visible = True
                        listaProductos = ProductoSA.GetProductosWithEquivalencias(New detalleitems With {.descripcionItem = TextBoxExt1.Text,
                                                                                  .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                                  .typeConsult = ComboTipoBusqueda.Text,
                                                                                  .codigo = TextBoxExt1.Text})

                        ListProductos.Items.Clear()

                        If listaProductos.Count > 0 Then
                            Dim consulta As New List(Of detalleitems)
                            consulta.Add(New detalleitems With {.descripcionItem = "Agregar nuevo"})
                            consulta.AddRange(listaProductos)
                            GetListProductos(consulta)

                            Me.PopupProductos.Size = New Size(636, 147)
                            Me.PopupProductos.ParentControl = Me.TextBoxExt1
                            Me.PopupProductos.ShowPopup(Point.Empty)
                            PictureLoadingProduct.Visible = False
                        End If
                    Case "CODIGO INTERNO"
                        PictureLoadingProduct.Visible = True
                        listaProductos = ProductoSA.GetProductosWithEquivalencias(New detalleitems With {.descripcionItem = TextBoxExt1.Text,
                                                                                  .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                                  .typeConsult = ComboTipoBusqueda.Text,
                                                                                  .codigo = TextBoxExt1.Text})

                        ListProductos.Items.Clear()

                        If listaProductos.Count > 0 Then
                            Dim consulta As New List(Of detalleitems)
                            consulta.Add(New detalleitems With {.descripcionItem = "Agregar nuevo"})
                            consulta.AddRange(listaProductos)
                            GetListProductos(consulta)

                            Me.PopupProductos.Size = New Size(636, 147)
                            Me.PopupProductos.ParentControl = Me.TextBoxExt1
                            Me.PopupProductos.ShowPopup(Point.Empty)
                            PictureLoadingProduct.Visible = False
                        End If
                    Case "ADICIONAL1"
                        PictureLoadingProduct.Visible = True
                        listaProductos = ProductoSA.GetProductosWithEquivalencias(New detalleitems With {.descripcionItem = TextBoxExt1.Text,
                                                                                  .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                                  .typeConsult = ComboTipoBusqueda.Text,
                                                                                  .electricidad = TextBoxExt1.Text})

                        ListProductos.Items.Clear()

                        If listaProductos.Count > 0 Then
                            Dim consulta As New List(Of detalleitems)
                            consulta.Add(New detalleitems With {.descripcionItem = "Agregar nuevo"})
                            consulta.AddRange(listaProductos)
                            GetListProductos(consulta)

                            Me.PopupProductos.Size = New Size(636, 147)
                            Me.PopupProductos.ParentControl = Me.TextBoxExt1
                            Me.PopupProductos.ShowPopup(Point.Empty)
                            PictureLoadingProduct.Visible = False
                        End If

                    Case "ADICIONAL2"
                        PictureLoadingProduct.Visible = True
                        listaProductos = ProductoSA.GetProductosWithEquivalencias(New detalleitems With {.descripcionItem = TextBoxExt1.Text,
                                                                                  .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                                  .typeConsult = ComboTipoBusqueda.Text,
                                                                                  .transmision = TextBoxExt1.Text})

                        ListProductos.Items.Clear()

                        If listaProductos.Count > 0 Then
                            Dim consulta As New List(Of detalleitems)
                            consulta.Add(New detalleitems With {.descripcionItem = "Agregar nuevo"})
                            consulta.AddRange(listaProductos)
                            GetListProductos(consulta)

                            Me.PopupProductos.Size = New Size(636, 147)
                            Me.PopupProductos.ParentControl = Me.TextBoxExt1
                            Me.PopupProductos.ShowPopup(Point.Empty)
                            PictureLoadingProduct.Visible = False
                        End If
                    Case "PRESENTACION/MODELO"
                        PictureLoadingProduct.Visible = True
                        listaProductos = ProductoSA.GetProductosWithEquivalencias(New detalleitems With {.descripcionItem = TextBoxExt1.Text,
                                                                                  .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                                  .typeConsult = ComboTipoBusqueda.Text,
                                                                                  .presentacion = TextBoxExt1.Text})

                        ListProductos.Items.Clear()

                        If listaProductos.Count > 0 Then
                            Dim consulta As New List(Of detalleitems)
                            consulta.Add(New detalleitems With {.descripcionItem = "Agregar nuevo"})
                            consulta.AddRange(listaProductos)
                            GetListProductos(consulta)

                            Me.PopupProductos.Size = New Size(636, 147)
                            Me.PopupProductos.ParentControl = Me.TextBoxExt1
                            Me.PopupProductos.ShowPopup(Point.Empty)
                            PictureLoadingProduct.Visible = False
                        End If


                    Case "COLOR"
                        PictureLoadingProduct.Visible = True
                        listaProductos = ProductoSA.GetProductosWithEquivalencias(New detalleitems With {.descripcionItem = TextBoxExt1.Text,
                                                                                  .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                                  .typeConsult = ComboTipoBusqueda.Text,
                                                                                  .color = TextBoxExt1.Text})

                        ListProductos.Items.Clear()

                        If listaProductos.Count > 0 Then
                            Dim consulta As New List(Of detalleitems)
                            consulta.Add(New detalleitems With {.descripcionItem = "Agregar nuevo"})
                            consulta.AddRange(listaProductos)
                            GetListProductos(consulta)

                            Me.PopupProductos.Size = New Size(636, 147)
                            Me.PopupProductos.ParentControl = Me.TextBoxExt1
                            Me.PopupProductos.ShowPopup(Point.Empty)
                            PictureLoadingProduct.Visible = False
                        End If


                    Case "TALLA"
                        PictureLoadingProduct.Visible = True
                        listaProductos = ProductoSA.GetProductosWithEquivalencias(New detalleitems With {.descripcionItem = TextBoxExt1.Text,
                                                                                  .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                                  .typeConsult = ComboTipoBusqueda.Text,
                                                                                  .talla = TextBoxExt1.Text})

                        ListProductos.Items.Clear()

                        If listaProductos.Count > 0 Then
                            Dim consulta As New List(Of detalleitems)
                            consulta.Add(New detalleitems With {.descripcionItem = "Agregar nuevo"})
                            consulta.AddRange(listaProductos)
                            GetListProductos(consulta)

                            Me.PopupProductos.Size = New Size(636, 147)
                            Me.PopupProductos.ParentControl = Me.TextBoxExt1
                            Me.PopupProductos.ShowPopup(Point.Empty)
                            PictureLoadingProduct.Visible = False
                        End If

                    Case "CODIGO BARRA UC"

                        PictureLoadingProduct.Visible = True
                        listaProductos = ProductoSA.GetProductsCodeUnidadComercial(New detalleitems With
                                                          {
                                                          .idEmpresa = Gempresas.IdEmpresaRuc,
                                                          .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                          .codigo = TextBoxExt1.Text
                                                          })

                        ListProductos.Items.Clear()

                        If listaProductos.Count > 0 Then
                            Dim consulta As New List(Of detalleitems)
                            consulta.Add(New detalleitems With {.descripcionItem = "Agregar nuevo"})
                            consulta.AddRange(listaProductos)
                            GetListProductos(consulta)

                            Me.PopupProductos.Size = New Size(636, 147)
                            Me.PopupProductos.ParentControl = Me.TextBoxExt1
                            Me.PopupProductos.ShowPopup(Point.Empty)
                            PictureLoadingProduct.Visible = False
                        Else
                            If Me.PopupProductos.IsShowing() Then
                                Me.PopupProductos.HidePopup(PopupCloseType.Canceled)
                            End If
                            PictureLoadingProduct.Visible = False

                            If MessageBox.Show("Desea crear el producto ahora?", "Nuevo producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                                Dim frmNuevaExistencia As New frmNuevaExistencia
                                With frmNuevaExistencia
                                    If TextBoxExt1.Text.Trim.Length > 0 Then
                                        .UCNuenExistencia.txtProductoNew.Text = TextBoxExt1.Text.Trim
                                    End If

                                    If ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico Then
                                        .UCNuenExistencia.cboTipoExistencia.Enabled = False
                                        .UCNuenExistencia.cboUnidades.SelectedIndex = -1
                                        .UCNuenExistencia.cboUnidades.Enabled = True
                                    Else

                                    End If

                                    If Gempresas.Regimen = "1" Then
                                        .UCNuenExistencia.cboIgv.Text = "1 - GRAVADO"
                                        .UCNuenExistencia.cboIgv.Enabled = True
                                    Else
                                        .UCNuenExistencia.cboIgv.Text = "2 - EXONERADO"
                                        .UCNuenExistencia.cboIgv.Enabled = True
                                    End If
                                    '.UCNuenExistencia.chClasificacion.Checked = False
                                    .UCNuenExistencia.cboTipoExistencia.SelectedValue = "01"
                                    .UCNuenExistencia.cboUnidades.Text = "UNIDAD (BIENES)"
                                    .EstadoManipulacion = ENTITY_ACTIONS.INSERT
                                    .StartPosition = FormStartPosition.CenterParent
                                    .ShowDialog(Me)
                                    If frmNuevaExistencia.Tag IsNot Nothing Then
                                        Dim p = CType(frmNuevaExistencia.Tag, detalleitems)
                                        Dim prod = ProductoSA.GetUbicaProductoID(p.codigodetalle)
                                        listaProductos.Add(prod)
                                        AgregarProductoDetalleCompra(prod)
                                    End If
                                End With
                            End If
                        End If

                End Select


            End If

        Else

        End If



        If e.KeyCode = Keys.Down Then
            '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.PopupProductos.Size = New Size(636, 147)
            Me.PopupProductos.ParentControl = Me.TextBoxExt1
            Me.PopupProductos.ShowPopup(Point.Empty)
            ListProductos.Focus()
        End If
        '   End If

        ' e.SuppressKeyPress = True
        If e.KeyCode = Keys.Escape Then
            If Me.PopupProductos.IsShowing() Then
                Me.PopupProductos.HidePopup(PopupCloseType.Canceled)
            End If
        End If
    End Sub

    Private Sub GetListProductos(consulta As List(Of detalleitems))
        ListProductos.Items.Clear()
        For Each i In consulta
            Dim n As New ListViewItem(i.codigodetalle)
            n.SubItems.Add(i.descripcionItem)
            n.SubItems.Add(i.unidad1)
            n.SubItems.Add(i.composicion)
            If i.recursoCostoLote.Count > 0 Then
                n.SubItems.Add(i.recursoCostoLote.FirstOrDefault.fechaentrada.GetValueOrDefault)
                n.SubItems.Add(i.recursoCostoLote.FirstOrDefault.precioUnitarioIva.GetValueOrDefault)
            Else
                n.SubItems.Add("-")
                n.SubItems.Add("-")
            End If

            ListProductos.Items.Add(n)
        Next
        ListProductos.Refresh()
    End Sub

    Private Sub TextBoxExt1_TextChanged(sender As Object, e As EventArgs) Handles TextBoxExt1.TextChanged

    End Sub

    Private Sub ListProductos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListProductos.SelectedIndexChanged

    End Sub

    Private Sub PopupProductos_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles PopupProductos.CloseUp
        Me.Cursor = Cursors.WaitCursor

        If e.PopupCloseType = PopupCloseType.Done Then
            If ListProductos.SelectedItems.Count > 0 Then
                If ListProductos.SelectedItems(0).SubItems(1).Text = "Agregar nuevo" Then
                    Dim frmNuevaExistencia As New FormNuevoCalzado
                    With frmNuevaExistencia
                        If ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico Then
                            .ucNuevoCalzado.cboTipoExistencia.Enabled = False
                            .ucNuevoCalzado.cboUnidades.SelectedIndex = -1
                            .ucNuevoCalzado.cboUnidades.Enabled = True
                        Else

                        End If

                        If Gempresas.Regimen = "1" Then
                            .ucNuevoCalzado.cboIgv.Text = "1 - GRAVADO"
                            .ucNuevoCalzado.cboIgv.Enabled = True
                        Else
                            .ucNuevoCalzado.cboIgv.Text = "2 - EXONERADO"
                            .ucNuevoCalzado.cboIgv.Enabled = True
                        End If
                        '   .ucNuevoCalzado.chClasificacion.Checked = False
                        .ucNuevoCalzado.cboTipoExistencia.SelectedValue = "01"
                        .ucNuevoCalzado.cboUnidades.Text = "UNIDAD (BIENES)"
                        .EstadoManipulacion = ENTITY_ACTIONS.INSERT
                        .StartPosition = FormStartPosition.CenterParent
                        .ShowDialog()
                        If frmNuevaExistencia.Tag IsNot Nothing Then
                            Dim p = CType(frmNuevaExistencia.Tag, detalleitems)
                            Dim prod = ProductoSA.GetUbicaProductoID(p.codigodetalle)
                            listaProductos.Add(prod)
                            AgregarProductoDetalleCompra(prod)
                        End If
                    End With
                    'Dim frmNuevaExistencia As New frmNuevaExistencia
                    'With frmNuevaExistencia
                    '    If ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico Then
                    '        .UCNuenExistencia.cboTipoExistencia.Enabled = False
                    '        .UCNuenExistencia.cboUnidades.SelectedIndex = -1
                    '        .UCNuenExistencia.cboUnidades.Enabled = True
                    '    Else

                    '    End If

                    '    If Gempresas.Regimen = "1" Then
                    '        .UCNuenExistencia.cboIgv.Text = "1 - GRAVADO"
                    '        .UCNuenExistencia.cboIgv.Enabled = True
                    '    Else
                    '        .UCNuenExistencia.cboIgv.Text = "2 - EXONERADO"
                    '        .UCNuenExistencia.cboIgv.Enabled = True
                    '    End If
                    '    .UCNuenExistencia.chClasificacion.Checked = False
                    '    .UCNuenExistencia.cboTipoExistencia.SelectedValue = "01"
                    '    .UCNuenExistencia.cboUnidades.Text = "UNIDAD (BIENES)"
                    '    .EstadoManipulacion = ENTITY_ACTIONS.INSERT
                    '    .StartPosition = FormStartPosition.CenterParent
                    '    .ShowDialog()
                    '    If frmNuevaExistencia.Tag IsNot Nothing Then
                    '        Dim p = CType(frmNuevaExistencia.Tag, detalleitems)
                    '        Dim prod = ProductoSA.GetUbicaProductoID(p.codigodetalle)
                    '        listaProductos.Add(prod)
                    '        AgregarProductoDetalleCompra(prod)
                    '    End If
                    'End With
                Else
                    AgregarProductoDetalleCompra(ListProductos.SelectedItems(0))
                End If
                'ListaMercaderiasXIdHijo(Val(txtSubCategoria.Tag), cboTipoExistencia.SelectedValue)
            End If
        End If

        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            TextBoxExt1.Focus()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub AgregarProductoDetalleCompra(listViewItem As ListViewItem)
        Dim obj As documentocompradetalle
        Dim idProducto = Integer.Parse(listViewItem.SubItems(0).Text)

        If FormPurchase.UCTransporteDistribucionProductos.UCDistribucionAlmacen.ListaAlmacen IsNot Nothing Then
            Dim av = FormPurchase.UCTransporteDistribucionProductos.UCDistribucionAlmacen.ListaAlmacen.Where(Function(o) o.tipo = "AV").SingleOrDefault
            Dim producto = listaProductos.Where(Function(o) o.codigodetalle = idProducto).SingleOrDefault
            If producto IsNot Nothing Then
                obj = New documentocompradetalle
                Dim cod = System.Guid.NewGuid.ToString()


                Select Case ComboDespacho.Text
                    Case ""

                    Case ""

                End Select

                obj.bonificacion = "N"
                obj.CodigoCosto = cod
                obj.almacenRef = av.idAlmacen
                obj.idItem = producto.codigodetalle
                obj.CustomProducto = producto
                obj.monto1 = 1
                obj.ItemEntregadototal = "S" ' "N"
                obj.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                If producto.detalleitem_equivalencias IsNot Nothing Then
                    If producto.detalleitem_equivalencias.Count > 0 Then
                        obj.CustomProducto_equivalencia = producto.detalleitem_equivalencias.FirstOrDefault
                    End If
                End If
                obj.CustomListaInventarioMovimiento = New List(Of InventarioMovimiento)
                obj.CustomDocumentoCaja = New List(Of documentoCaja)
                ListaproductosComprados.Add(obj)
                LoadCanastaCompras(ListaproductosComprados)
            End If
        Else
            MessageBox.Show("Debe registrar un almacen!")
            Exit Sub
        End If
        ' MsgBox(listViewItem.SubItems(1).Text)
    End Sub

    Private Sub AgregarProductoDetalleCompra(be As detalleitems)
        Dim obj As documentocompradetalle
        Dim idProducto = be.codigodetalle

        If FormPurchase.UCTransporteDistribucionProductos.UCDistribucionAlmacen.ListaAlmacen IsNot Nothing Then
            Dim av = FormPurchase.UCTransporteDistribucionProductos.UCDistribucionAlmacen.ListaAlmacen.Where(Function(o) o.tipo = "AV").SingleOrDefault
            Dim producto = listaProductos.Where(Function(o) o.codigodetalle = idProducto).SingleOrDefault
            If producto IsNot Nothing Then
                obj = New documentocompradetalle
                Dim cod = System.Guid.NewGuid.ToString()


                Select Case ComboDespacho.Text
                    Case "COMPRA NACIONAL DIRECTA"
                        obj.almacenRef = ComboAlmacen.SelectedValue
                End Select

                obj.bonificacion = "N"
                obj.CodigoCosto = cod
                obj.almacenRef = av.idAlmacen
                obj.idItem = producto.codigodetalle
                obj.CustomProducto = producto
                obj.monto1 = 1
                obj.ItemEntregadototal = "S" '"N"
                obj.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                If producto.detalleitem_equivalencias IsNot Nothing Then
                    If producto.detalleitem_equivalencias.Count > 0 Then
                        obj.CustomProducto_equivalencia = producto.detalleitem_equivalencias.FirstOrDefault
                    End If
                End If
                obj.CustomListaInventarioMovimiento = New List(Of InventarioMovimiento)
                obj.CustomDocumentoCaja = New List(Of documentoCaja)
                ListaproductosComprados.Add(obj)
                LoadCanastaCompras(ListaproductosComprados)
            End If
        Else
            MessageBox.Show("Debe registrar un almacen!")
            Exit Sub
        End If
        ' MsgBox(listViewItem.SubItems(1).Text)
    End Sub

    Public Sub LoadCanastaCompras(listaProductos As List(Of documentocompradetalle))
        Dim dt As New DataTable
        dt.Columns.Add("codigo")
        dt.Columns.Add("gravado")
        dt.Columns.Add("idProducto")
        dt.Columns.Add("item")
        dt.Columns.Add("um")
        dt.Columns.Add("contenido")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("contenido_neto")
        dt.Columns.Add("vcmn")
        dt.Columns.Add("pumn")
        dt.Columns.Add("totalmn")
        dt.Columns.Add("vcme")
        dt.Columns.Add("pume")
        dt.Columns.Add("totalme")
        dt.Columns.Add("igvmn")
        dt.Columns.Add("igvme")
        dt.Columns.Add("tipoExistencia")
        dt.Columns.Add("marca")
        dt.Columns.Add("almacen")
        dt.Columns.Add("codigoLote")
        dt.Columns.Add("equivalencia")
        dt.Columns.Add("bonificacion")
        dt.Columns.Add("bonificaionval")

        Dim equivalencia As detalleitem_equivalencias
        Dim id_Equiva = 0
        Dim precioUnitario As Decimal = 0

        For Each i In listaProductos
            If i.CustomProducto_equivalencia IsNot Nothing Then
                If i.importe.GetValueOrDefault = 0 Or i.monto1.GetValueOrDefault = 0 Then
                    precioUnitario = 0
                Else
                    precioUnitario = CalculoBaseImponible(i.importe.GetValueOrDefault, i.monto1.GetValueOrDefault)
                End If
                equivalencia = i.CustomProducto_equivalencia
                id_Equiva = i.CustomProducto_equivalencia.equivalencia_id

                dt.Rows.Add(i.CodigoCosto,
                        i.CustomProducto.origenProducto,
                        i.CustomProducto.codigodetalle,
                        i.CustomProducto.descripcionItem,
                        i.CustomProducto.unidad1,
                        i.CustomProducto.composicion,
                        i.monto1,
                        equivalencia.contenido_neto.GetValueOrDefault,
                        i.montokardex.GetValueOrDefault, precioUnitario,
                        i.importe.GetValueOrDefault,
                        i.montokardexUS.GetValueOrDefault, 0,
                        i.importeUS.GetValueOrDefault,
                        i.montoIgv.GetValueOrDefault,
                        i.montoIgvUS.GetValueOrDefault,
                        i.CustomProducto.tipoExistencia,
                        "-",
                        0,
                        0,
                        id_Equiva, i.GetBonificion, i.bonificacion)
            Else
                dt.Rows.Add(i.CodigoCosto,
                        i.CustomProducto.origenProducto,
                        i.CustomProducto.codigodetalle,
                        i.CustomProducto.descripcionItem,
                        i.CustomProducto.unidad1,
                        i.CustomProducto.composicion,
                        i.monto1,
                        "",
                        i.montokardex.GetValueOrDefault, precioUnitario,
                        i.importe.GetValueOrDefault,
                        i.montokardexUS.GetValueOrDefault, 0,
                        i.importeUS.GetValueOrDefault,
                        i.montoIgv.GetValueOrDefault,
                        i.montoIgvUS.GetValueOrDefault,
                        i.CustomProducto.tipoExistencia,
                        "-",
                        0,
                        0,
                        "", i.GetBonificion, i.bonificacion)
            End If


        Next
        GridCompra.DataSource = dt
        GridCompra.Refresh()
    End Sub

    Private Sub BunifuThinButton24_Click(sender As Object, e As EventArgs) Handles BunifuThinButton24.Click
        Dim frmNuevaExistencia As New frmNuevaExistencia
        'Dim frmNuevaExistencia As New FormNuevoCalzado
        Try
            'With frmNuevaExistencia
            '    If TextBoxExt1.Text.Trim.Length > 0 Then
            '        .ucNuevoCalzado.txtProductoNew.Text = TextBoxExt1.Text.Trim
            '    End If

            '    If ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico Then
            '        .ucNuevoCalzado.cboTipoExistencia.Enabled = False
            '        .ucNuevoCalzado.cboUnidades.SelectedIndex = -1
            '        .ucNuevoCalzado.cboUnidades.Enabled = True
            '    Else

            '    End If

            '    If Gempresas.Regimen = "1" Then
            '        .ucNuevoCalzado.cboIgv.Text = "1 - GRAVADO"
            '        .ucNuevoCalzado.cboIgv.Enabled = True
            '    Else
            '        .ucNuevoCalzado.cboIgv.Text = "2 - EXONERADO"
            '        .ucNuevoCalzado.cboIgv.Enabled = True
            '    End If
            '    '  .ucNuevoCalzado.chClasificacion.Checked = False
            '    .ucNuevoCalzado.cboTipoExistencia.SelectedValue = "01"
            '    .ucNuevoCalzado.cboUnidades.Text = "UNIDAD (BIENES)"
            '    .EstadoManipulacion = ENTITY_ACTIONS.INSERT
            '    .StartPosition = FormStartPosition.CenterParent
            '    .ShowDialog(Me)
            '    If frmNuevaExistencia.Tag IsNot Nothing Then
            '        Dim p = CType(frmNuevaExistencia.Tag, detalleitems)
            '        Dim prod = ProductoSA.GetUbicaProductoID(p.codigodetalle)
            '        listaProductos.Add(prod)
            '        AgregarProductoDetalleCompra(prod)
            '    End If
            'End With

            With frmNuevaExistencia
                If TextBoxExt1.Text.Trim.Length > 0 Then
                    .UCNuenExistencia.txtProductoNew.Text = TextBoxExt1.Text.Trim
                End If

                If ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico Then
                    .UCNuenExistencia.cboTipoExistencia.Enabled = False
                    .UCNuenExistencia.cboUnidades.SelectedIndex = -1
                    .UCNuenExistencia.cboUnidades.Enabled = True
                Else

                End If

                If Gempresas.Regimen = "1" Then
                    .UCNuenExistencia.cboIgv.Text = "1 - GRAVADO"
                    .UCNuenExistencia.cboIgv.Enabled = True
                Else
                    .UCNuenExistencia.cboIgv.Text = "2 - EXONERADO"
                    .UCNuenExistencia.cboIgv.Enabled = True
                End If
                '.UCNuenExistencia.chClasificacion.Checked = False
                .UCNuenExistencia.cboTipoExistencia.SelectedValue = "01"
                .UCNuenExistencia.cboUnidades.Text = "UNIDAD (BIENES)"
                .EstadoManipulacion = ENTITY_ACTIONS.INSERT
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog(Me)
                If frmNuevaExistencia.Tag IsNot Nothing Then
                    Dim p = CType(frmNuevaExistencia.Tag, detalleitems)
                    Dim prod = ProductoSA.GetUbicaProductoID(p.codigodetalle)
                    listaProductos.Add(prod)
                    AgregarProductoDetalleCompra(prod)
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ListProductos_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListProductos.MouseDoubleClick
        If ListProductos.SelectedItems.Count > 0 Then
            PopupProductos.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub GridCompra_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles GridCompra.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.Column.Name = "equivalencia" AndAlso e.TableCellIdentity.DisplayElement.Kind = Syncfusion.Grouping.DisplayElementKind.Record Then

            Dim value As String = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("idProducto").ToString()
            Dim codigo As String = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("codigo").ToString()
            Dim p = ListaproductosComprados.Where(Function(o) o.idItem = value And o.CodigoCosto = codigo).SingleOrDefault
            Dim listaEquivalencias = p.CustomProducto.detalleitem_equivalencias.ToList

            e.Style.DataSource = GetEquivalencias(listaEquivalencias)
            e.Style.DisplayMember = "unidadComercial"
            e.Style.ValueMember = "equivalencia_id"
        End If
    End Sub

    Private Function GetEquivalencias(lista As List(Of detalleitem_equivalencias)) As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("equivalencia_id")
        dt.Columns.Add("unidadComercial")
        dt.Columns.Add("contenido_neto")

        dt.Columns(0).ColumnMapping = MappingType.Hidden

        For Each i In lista
            dt.Rows.Add(i.equivalencia_id, i.unidadComercial, i.contenido_neto)
        Next
        Return dt
    End Function

    Private Sub GridCompra_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles GridCompra.TableControlCurrentCellCloseDropDown

        Dim cc As GridCurrentCell = GridCompra.TableControl.CurrentCell
        cc.ConfirmChanges()

        e.TableControl.CurrentCell.EndEdit()
        e.TableControl.Table.TableDirty = True
        e.TableControl.Table.EndEdit()
        If cc IsNot Nothing Then
            If cc.ColIndex > -1 Then
                Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)

                If style.TableCellIdentity.Column.Name = "equivalencia" Then
                    Dim CodigoEQ As String = cc.Renderer.ControlText
                    Dim r As Record = GridCompra.Table.CurrentRecord
                    If r IsNot Nothing Then
                        Dim codigo = r.GetValue("codigo")
                        Dim item = ListaproductosComprados.Where(Function(o) o.CodigoCosto = codigo And o.idItem = r.GetValue("idProducto")).Single



                        Dim prod = item.CustomProducto.detalleitem_equivalencias.Where(Function(o) o.unidadComercial = CodigoEQ).Single
                        'r.SetValue("cboPrecios", String.Empty)
                        If prod IsNot Nothing Then
                            r.SetValue("contenido_neto", prod.contenido_neto.GetValueOrDefault)
                            item.CustomProducto_equivalencia = prod
                            EditarItemCompra(r)
                        End If
                    End If
                    'Me.GridCompra.Table.CurrentRecord.SetCurrent("equivalencia")
                    'Me.GridCompra.TableControl.CurrentCell.ShowDropDown()
                    'Me.GridCompra.Table.CurrentRecord.SetCurrent("cantidad")
                    'r.SetValue("importeMn", 0)

                    'If text.Trim.Length > 0 Then
                    '    Dim value As Decimal = Convert.ToDecimal(text)
                    '    cc.Renderer.ControlValue = value

                    'End If
                Else
                    'Me.GridCompra.Table.CurrentRecord.SetCurrent("equivalencia")
                    'Me.GridCompra.TableControl.CurrentCell.ShowDropDown()
                End If

            End If
        End If
    End Sub

    Private Sub GridCompra_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridCompra.TableControlCellClick

    End Sub

    Private Sub GridCompra_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles GridCompra.TableControlCurrentCellEditingComplete
        'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        'Dim cc As GridCurrentCell = GridCompra.TableControl.CurrentCell
        'cc.ConfirmChanges()
        'If cc.ColIndex > -1 Then
        '    Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)

        '    If style.TableCellIdentity.Column.Name = "cantidad" Then
        '        If cc.Renderer IsNot Nothing Then
        '            Dim text As String = cc.Renderer.ControlText

        '            If text.Trim.Length > 0 Then
        '                If GridCompra.Table.CurrentRecord IsNot Nothing Then
        '                    EditarItemCompra(GridCompra.Table.CurrentRecord)
        '                End If
        '                'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 7, GridSetCurrentCellOptions.SetFocus)
        '            End If
        '        End If

        '    ElseIf style.TableCellIdentity.Column.Name = "equivalencia" Then
        '        If cc.Renderer IsNot Nothing Then
        '            Dim text As String = cc.Renderer.ControlText

        '            If text.Trim.Length > 0 Then
        '                Dim r = GridCompra.Table.CurrentRecord
        '                If r IsNot Nothing Then
        '                    Dim item = ListaproductosComprados.Where(Function(o) o.CodigoCosto = r.GetValue("codigo")).SingleOrDefault
        '                    If item IsNot Nothing Then
        '                        Dim codeEQ = r.GetValue("equivalencia")
        '                        Dim prodEQ = item.CustomProducto.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = codeEQ).SingleOrDefault
        '                        item.CustomProducto_equivalencia = prodEQ
        '                    End If
        '                End If

        '            End If
        '        End If

        '    ElseIf style.TableCellIdentity.Column.Name = "totalmn" Then
        '        If cc.Renderer IsNot Nothing Then
        '            Dim text As String = cc.Renderer.ControlText

        '            If text.Trim.Length > 0 Then
        '                If GridCompra.Table.CurrentRecord IsNot Nothing Then
        '                    GetCalculoItem(GridCompra.Table.CurrentRecord)
        '                    EditarItemCompra(GridCompra.Table.CurrentRecord)
        '                End If
        '                'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 9, GridSetCurrentCellOptions.SetFocus)
        '            End If
        '        End If
        '    End If
        'End If
    End Sub

    Private Sub EditarItemCompra(RowIndex As Integer)
        If RowIndex <> -1 Then
            Dim item = ListaproductosComprados.Where(Function(o) o.CodigoCosto = Me.GridCompra.TableModel(RowIndex, 1).CellValue).SingleOrDefault
            If item IsNot Nothing Then
                With item
                    .monto1 = Decimal.Parse(Me.GridCompra.TableModel(RowIndex, 7).CellValue)
                    .montokardex = Decimal.Parse(Me.GridCompra.TableModel(RowIndex, 8).CellValue)
                    .montoIgv = Decimal.Parse(Me.GridCompra.TableModel(RowIndex, 9).CellValue)
                    .precioUnitario = 0
                    .importe = Decimal.Parse(Me.GridCompra.TableModel(RowIndex, 11).CellValue)
                    .bonificacion = Me.GridCompra.TableModel(RowIndex, 15).CellValue
                    .CustomListaInventarioMovimiento = New List(Of InventarioMovimiento)
                    .CustomDocumentoCaja = New List(Of documentoCaja)
                    '  .CustomDocumentoCaja = New List(Of documentoCaja)
                End With
                FormPurchase.LimpiarPagos(ListaproductosComprados)
                If item IsNot Nothing Then
                    If Decimal.Parse(Me.GridCompra.TableModel(RowIndex, 7).CellValue) > 0 Then

                        item.CustomListaInventarioMovimiento = New List(Of InventarioMovimiento)
                        GetEntregas(1, Decimal.Parse(Me.GridCompra.TableModel(RowIndex, 7).CellValue), item.CodigoCosto)

                    Else
                        item.CustomListaInventarioMovimiento = New List(Of InventarioMovimiento)
                    End If
                End If

            End If
        End If
        'LoadCanastaCompras(ListaproductosComprados)
    End Sub

    Private Sub EditarItemCompra(r As Record)
        If r IsNot Nothing Then
            Dim precUnit As Decimal = 0
            Dim item = ListaproductosComprados.Where(Function(o) o.CodigoCosto = r.GetValue("codigo")).SingleOrDefault
            If item IsNot Nothing Then
                With item
                    .monto1 = Decimal.Parse(r.GetValue("cantidad"))
                    .montokardex = Decimal.Parse(r.GetValue("vcmn"))
                    .montokardexUS = Decimal.Parse(r.GetValue("vcme"))
                    .montoIgv = Decimal.Parse(r.GetValue("igvmn"))
                    .montoIgvUS = Decimal.Parse(r.GetValue("igvme"))
                    .precioUnitario = 0
                    .importe = Decimal.Parse(r.GetValue("totalmn"))
                    .importeUS = Decimal.Parse(r.GetValue("totalme"))
                    .bonificacion = r.GetValue("bonificaionval")
                    .CustomListaInventarioMovimiento = New List(Of InventarioMovimiento)
                    .CustomDocumentoCaja = New List(Of documentoCaja)
                End With


                Select Case cboMoneda.Text
                    Case "NUEVO SOL"
                        If Decimal.Parse(r.GetValue("cantidad")) = 0 Or Decimal.Parse(r.GetValue("totalmn")) = 0 Then
                            precUnit = 0
                            item.precioUnitario = 0
                            r.SetValue("pumn", 0)
                        Else
                            precUnit = Math.Round(CDec(Decimal.Parse(r.GetValue("totalmn"))) / CDec(Decimal.Parse(r.GetValue("cantidad"))), 2)
                            item.precioUnitario = precUnit
                            r.SetValue("pumn", precUnit)
                        End If

                    Case Else
                        If Decimal.Parse(r.GetValue("cantidad")) = 0 Or Decimal.Parse(r.GetValue("totalme")) = 0 Then
                            precUnit = 0
                            item.precioUnitarioUS = 0
                            r.SetValue("pume", 0)
                        Else
                            precUnit = Math.Round(CDec(Decimal.Parse(r.GetValue("totalmn"))) / CDec(Decimal.Parse(r.GetValue("cantidad"))), 2)
                            item.precioUnitarioUS = precUnit
                            r.SetValue("pume", precUnit)
                        End If

                        If Decimal.Parse(r.GetValue("cantidad")) = 0 Or Decimal.Parse(r.GetValue("totalmn")) = 0 Then
                            precUnit = 0
                            item.precioUnitario = 0
                            r.SetValue("pumn", 0)
                        Else
                            precUnit = Math.Round(CDec(Decimal.Parse(r.GetValue("totalmn"))) / CDec(Decimal.Parse(r.GetValue("cantidad"))), 2)
                            item.precioUnitario = precUnit
                            r.SetValue("pumn", precUnit)
                        End If

                End Select


                FormPurchase.LimpiarPagos(ListaproductosComprados)
                'Dim codigoCompra = ListDetalle.SelectedItems(0).SubItems(0).Text
                'Dim cantidad As Decimal = Decimal.Parse(ListDetalle.SelectedItems(0).SubItems(6).Text)
                If item IsNot Nothing Then
                    If Decimal.Parse(r.GetValue("cantidad")) > 0 Then

                        item.CustomListaInventarioMovimiento = New List(Of InventarioMovimiento)
                        GetEntregas(1, Decimal.Parse(r.GetValue("cantidad")), item.CodigoCosto)

                    Else
                        item.CustomListaInventarioMovimiento = New List(Of InventarioMovimiento)
                    End If
                End If
            End If
        End If
        'LoadCanastaCompras(ListaproductosComprados)
    End Sub

    Private Sub GetEntregas(NumPartes As Long, cantidad As Decimal, codigo As String)

        Dim itemCompra = ListaproductosComprados.Where(Function(o) o.CodigoCosto = codigo).Single
        If itemCompra IsNot Nothing Then
            If cantidad > 0 Then
                Dim division = cantidad / NumPartes
                Dim index As Integer = 1
                Do While index <= NumPartes
                    AddInventario(itemCompra, division)
                    index += 1
                Loop
            End If
        End If
    End Sub

    Private Sub AddInventario(itemCompra As documentocompradetalle, cantDividida As Decimal)
        Dim codigoInv = System.Guid.NewGuid.ToString
        Dim almVirtual As New almacen

        Dim fechaCompra = Date.Now ' New Date(UCEstructuraDocumentocabecera.TxtDia.DecimalValue, CInt(UCEstructuraDocumentocabecera.cboMesCompra.SelectedValue), Date.Now.Year)


        'Select Case ComboDespacho.Text
        '    Case "UN ALMACEN"
        '        almVirtual = New almacen With {.idAlmacen = ComboAlmacen.SelectedValue, .descripcionAlmacen = ComboAlmacen.Text}

        '    Case "EN TRANSITO"
        '        If FormPurchase.UCTransporteDistribucionProductos.UCDistribucionAlmacen.ListaAlmacen IsNot Nothing Then
        '            If FormPurchase.UCTransporteDistribucionProductos.UCDistribucionAlmacen.ListaAlmacen.Count > 0 Then
        '                almVirtual = FormPurchase.UCTransporteDistribucionProductos.UCDistribucionAlmacen.ListaAlmacen.Where(Function(a) a.tipo = "AV").SingleOrDefault
        '            End If
        '        End If
        '    Case Else
        If FormPurchase.UCTransporteDistribucionProductos.UCDistribucionAlmacen.ListaAlmacen IsNot Nothing Then
            If FormPurchase.UCTransporteDistribucionProductos.UCDistribucionAlmacen.ListaAlmacen.Count > 0 Then
                almVirtual = FormPurchase.UCTransporteDistribucionProductos.UCDistribucionAlmacen.ListaAlmacen.Where(Function(a) a.tipo = "AV").SingleOrDefault
            End If
        End If
        'End Select



        Dim Contenido As Decimal = itemCompra.CustomProducto_equivalencia.contenido_neto
        Dim cantidadInventario = Contenido * cantDividida
        Dim costoInventario = itemCompra.montokardex
        Dim costoUnitario = Math.Round(CDec(costoInventario / itemCompra.monto1), 2)
        Dim montoCostoItem = costoUnitario * cantidadInventario


        Dim tipoOperacion As String = Nothing

        Select Case FormPurchase.ComboComprobante.Text
            Case "Compra recepción directa"
                tipoOperacion = StatusTipoOperacion.COMPRA
            Case "NOTA DE COMPRA"
                tipoOperacion = StatusTipoOperacion.COMPRA
            Case "Otra entrada"
                tipoOperacion = StatusTipoOperacion.OTRAS_ENTRADAS_A_ALMACEN
        End Select


        Dim obj As New InventarioMovimiento
        obj.CantEntrada = itemCompra.monto1
        obj.codigoBarra = codigoInv
        obj.idEmpresa = Gempresas.IdEmpresaRuc
        obj.idEstablecimiento = GEstableciento.IdEstablecimiento
        obj.idAlmacen = almVirtual.idAlmacen
        obj.TipoAlmacen = almVirtual.tipo
        obj.nrolote = 0
        obj.MatriculaVehiculo = "nro.matricula"
        obj.Chofer = "nom.chofer"
        obj.tipoOperacion = tipoOperacion ' StatusTipoOperacion.COMPRA
        obj.tipoDocAlmacen = "99"
        obj.serie = txtSerie.Text.Trim
        obj.numero = txtNumero.Text.Trim
        obj.idDocumento = 0
        obj.idDocumentoRef = 0
        obj.descripcion = itemCompra.CustomProducto.descripcionItem
        obj.fechaLaboral = Date.Now
        obj.fecha = fechaCompra
        obj.tipoRegistro = "E"
        obj.destinoGravadoItem = itemCompra.CustomProducto.origenProducto
        obj.tipoProducto = itemCompra.CustomProducto.tipoExistencia
        obj.OrigentipoProducto = "N"
        obj.idItem = itemCompra.CustomProducto.codigodetalle
        obj.marca = itemCompra.CustomProducto.unidad2
        obj.presentacion = itemCompra.CustomProducto.presentacion
        obj.cantidad = cantidadInventario
        obj.unidad = itemCompra.CustomProducto.unidad1
        obj.cantidad2 = 0
        obj.precUnite = costoUnitario
        obj.precUniteUSD = 0
        obj.monto = itemCompra.montokardex 'obj.GetImporteAlmacen ' montoCostoItem
        obj.montoUSD = itemCompra.montokardexUS.GetValueOrDefault
        obj.montoOther = 0
        obj.monedaOther = 0
        obj.disponible = 0
        obj.disponible2 = 0
        obj.saldoMonto = 0
        obj.saldoMontoUsd = 0
        obj.status = "D"
        obj.entragado = "1"
        obj.usuarioActualizacion = usuario.IDUsuario
        obj.consignado = "N"
        obj.fechaActualizacion = Date.Now
        itemCompra.CustomListaInventarioMovimiento.Add(obj)

        '    LoadGridInventario(itemCompra)
    End Sub


    Public Sub GetCalculoItem(r As Record)
        If r IsNot Nothing Then
            'Dim bonificacion = Boolean.Parse(r.GetValue("bonificacion"))
            'Dim gravado As Integer = Integer.Parse(r.GetValue("gravado"))
            'Dim baseImponible As Decimal = 0
            'Dim baseImponibleme As Decimal = 0
            'Dim Iva As Decimal = 0
            'Dim ivame As Decimal = 0
            'Dim total As Decimal = Decimal.Parse(r.GetValue("totalmn"))
            'Dim totalme As Decimal = Decimal.Parse(r.GetValue("totalme"))

            Select Case cboMoneda.Text
                Case "NUEVO SOL"
                    CalculoMN(r)
                Case Else
                    CalculoME(r)
            End Select

            'Select Case gravado
            '    Case 1
            '        baseImponible = Math.Round(CDec(CalculoBaseImponible(total, 1.18)), 2)
            '        Iva = Math.Round(total - baseImponible, 2)
            '    Case 2
            '        baseImponible = total
            '        Iva = 0
            'End Select


        End If
    End Sub

    Private Sub CalculoMN(r As Record)
        Dim bonificacion = Boolean.Parse(r.GetValue("bonificacion"))
        Dim gravado As Integer = Integer.Parse(r.GetValue("gravado"))
        Dim baseImponible As Decimal = 0
        Dim baseImponibleme As Decimal = 0
        Dim Iva As Decimal = 0
        Dim ivame As Decimal = 0
        Dim total As Decimal = Decimal.Parse(r.GetValue("totalmn"))
        Dim totalme As Decimal = 0 'Decimal.Parse(r.GetValue("totalme"))

        Dim item = ListaproductosComprados.Where(Function(o) o.CodigoCosto = r.GetValue("codigo")).SingleOrDefault
        If item IsNot Nothing Then
            Select Case gravado
                Case 2
                    baseImponible = total
                    baseImponibleme = 0
                    Iva = 0
                    ivame = 0
                Case Else
                    baseImponible = Math.Round(CDec(CalculoBaseImponible(total, 1.18)), 2)
                    baseImponibleme = 0 'Math.Round(CDec(CalculoBaseImponible(totalme, 1.18)), 2)
                    Iva = Math.Round(total - baseImponible, 2)
                    ivame = 0 'Math.Round(totalme - baseImponibleme, 2)
            End Select
            'End Select

            'MONEDA NACIONAL
            r.SetValue("vcmn", baseImponible)
            r.SetValue("igvmn", Iva)
            r.SetValue("pumn", 0)
            r.SetValue("totalmn", total)

            'MONEDA EXTRANJERA
            r.SetValue("vcme", baseImponibleme)
            r.SetValue("igvme", ivame)
            r.SetValue("pume", 0)
            r.SetValue("totalme", totalme)

            GridCompra.Refresh()

            GetTotalesDocumento()
        End If
    End Sub

    Private Sub CalculoME(r As Record)
        Dim bonificacion = Boolean.Parse(r.GetValue("bonificacion"))
        Dim gravado As Integer = Integer.Parse(r.GetValue("gravado"))
        Dim baseImponible As Decimal = 0
        Dim baseImponibleme As Decimal = 0
        Dim Iva As Decimal = 0
        Dim ivame As Decimal = 0
        Dim totalme As Decimal = Decimal.Parse(r.GetValue("totalme"))
        Dim total As Decimal = Decimal.Parse(r.GetValue("totalme")) * txtTipoCambio.DecimalValue

        Dim item = ListaproductosComprados.Where(Function(o) o.CodigoCosto = r.GetValue("codigo")).SingleOrDefault
        If item IsNot Nothing Then
            Select Case gravado
                Case 2
                    baseImponible = total
                    baseImponibleme = totalme
                    Iva = 0
                    ivame = 0
                Case Else
                    baseImponible = Math.Round(CDec(CalculoBaseImponible(total, 1.18)), 2)
                    baseImponibleme = Math.Round(CDec(CalculoBaseImponible(totalme, 1.18)), 2)
                    Iva = Math.Round(total - baseImponible, 2)
                    ivame = Math.Round(totalme - baseImponibleme, 2)
            End Select
            'End Select

            'MONEDA NACIONAL
            r.SetValue("vcmn", baseImponible)
            r.SetValue("igvmn", Iva)
            r.SetValue("pumn", 0)
            r.SetValue("totalmn", total)

            'MONEDA EXTRANJERA
            r.SetValue("vcme", baseImponibleme)
            r.SetValue("igvme", ivame)
            r.SetValue("pume", 0)
            r.SetValue("totalme", totalme)

            GridCompra.Refresh()

            GetTotalesDocumento()
        End If
    End Sub

    Public Sub GetCalculoItem(RowIndex As Integer)
        If RowIndex <> -1 Then
            Dim bonificacion = If(Boolean.Parse(Me.GridCompra.TableModel(RowIndex, 14).CellValue) = False, True, False)
            Dim gravado As Integer = Integer.Parse(Me.GridCompra.TableModel(RowIndex, 2).CellValue)
            Dim baseImponible As Decimal = 0
            Dim Iva As Decimal = 0
            Dim total As Decimal = Decimal.Parse(Me.GridCompra.TableModel(RowIndex, 11).CellValue)

            Dim item = ListaproductosComprados.Where(Function(o) o.CodigoCosto = Me.GridCompra.TableModel(RowIndex, 1).CellValue).SingleOrDefault
            If item IsNot Nothing Then
                'Select Case bonificacion
                '    Case True
                '        baseImponible = 0
                '        Iva = 0
                '        total = 0
                '    Case Else
                Select Case gravado
                    Case 2
                        baseImponible = total
                        Iva = 0
                    Case Else
                        baseImponible = Math.Round(CDec(CalculoBaseImponible(total, 1.18)), 2)
                        Iva = Math.Round(total - baseImponible, 2)
                End Select
                'End Select
                Me.GridCompra.TableModel(RowIndex, 8).CellValue = baseImponible
                Me.GridCompra.TableModel(RowIndex, 9).CellValue = Iva
                Me.GridCompra.TableModel(RowIndex, 10).CellValue = 0
                Me.GridCompra.TableModel(RowIndex, 11).CellValue = total
                'r.SetValue("vcmn", baseImponible)
                'r.SetValue("igvmn", Iva)
                'r.SetValue("pumn", 0)

                GridCompra.Refresh()

                GetTotalesDocumento()
            End If



            'Select Case gravado
            '    Case 1
            '        baseImponible = Math.Round(CDec(CalculoBaseImponible(total, 1.18)), 2)
            '        Iva = Math.Round(total - baseImponible, 2)
            '    Case 2
            '        baseImponible = total
            '        Iva = 0
            'End Select


        End If
    End Sub

    Private Sub TextBoxExt1_LostFocus(sender As Object, e As EventArgs) Handles TextBoxExt1.LostFocus
        'PopupProductos.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub GridCompra_TableControlCurrentCellChanged(sender As Object, e As GridTableControlEventArgs) Handles GridCompra.TableControlCurrentCellChanged
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex

        Dim cc As GridCurrentCell = GridCompra.TableControl.CurrentCell
        cc.ConfirmChanges()
        Try
            ' If cc.Renderer IsNot Nothing Then

            If cc.ColIndex > -1 Then
                Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)

                If style.TableCellIdentity.Column.Name = "cantidad" Then

                    If cc.Renderer IsNot Nothing Then

                        '  If e.TableControl.Model.Modified = True Then
                        Dim text As Decimal = cc.Renderer.ControlText

                        If IsNumeric(text) Then
                            GridCompra.Table.CurrentRecord.SetValue("cantidad", text)
                            If GridCompra.Table.CurrentRecord IsNot Nothing Then
                                EditarItemCompra(GridCompra.Table.CurrentRecord)
                            End If
                            'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 7, GridSetCurrentCellOptions.SetFocus)
                        End If
                        ' End If
                    End If
                ElseIf style.TableCellIdentity.Column.Name = "equivalencia" Then
                    If cc.Renderer IsNot Nothing Then
                        Dim text As String = cc.Renderer.ControlText

                        If text.Trim.Length > 0 Then
                            'If e.TableControl.CurrentCell.IsChanging = True Then
                            Dim r = GridCompra.Table.CurrentRecord

                            If r IsNot Nothing Then
                                Dim item = ListaproductosComprados.Where(Function(o) o.CodigoCosto = r.GetValue("codigo")).SingleOrDefault
                                If item IsNot Nothing Then
                                    Dim codeEQ = r.GetValue("equivalencia")
                                    Dim prodEQ = item.CustomProducto.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = codeEQ).SingleOrDefault
                                    item.CustomProducto_equivalencia = prodEQ
                                    EditarItemCompra(GridCompra.Table.CurrentRecord)
                                End If
                            End If
                            '  End If
                        End If
                    End If

                ElseIf style.TableCellIdentity.Column.Name = "totalmn" Then
                    If cc.Renderer IsNot Nothing Then
                        Dim text As String = cc.Renderer.ControlText

                        If text.Trim.Length > 0 Then
                            If GridCompra.Table.CurrentRecord IsNot Nothing Then
                                GetCalculoItem(GridCompra.Table.CurrentRecord)
                                EditarItemCompra(GridCompra.Table.CurrentRecord)
                                FormPurchase.UCCondicionesPago.UCPagoCompletoDocumento.DocCaja = New List(Of documento)
                            End If
                            'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 9, GridSetCurrentCellOptions.SetFocus)
                        End If
                    End If
                ElseIf style.TableCellIdentity.Column.Name = "totalme" Then
                    If cc.Renderer IsNot Nothing Then
                        Dim text As String = cc.Renderer.ControlText

                        If text.Trim.Length > 0 Then
                            If GridCompra.Table.CurrentRecord IsNot Nothing Then
                                GetCalculoItem(GridCompra.Table.CurrentRecord)
                                EditarItemCompra(GridCompra.Table.CurrentRecord)
                                FormPurchase.UCCondicionesPago.UCPagoCompletoDocumento.DocCaja = New List(Of documento)
                            End If
                            'e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 9, GridSetCurrentCellOptions.SetFocus)
                        End If
                    End If
                End If
            End If
            'End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "validar ingreso")
        End Try
    End Sub

    Private Sub TxtDia_TextChanged(sender As Object, e As EventArgs) Handles TxtDia.TextChanged

    End Sub

    Private Sub TxtDia_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtDia.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If TxtDia.Text.Trim.Length > 0 Then
                e.SuppressKeyPress = True
                cboTipoDoc.Select()
                cboTipoDoc.DroppedDown = True
            End If
        End If

    End Sub

    Private Sub cboTipoDoc_Click(sender As Object, e As EventArgs) Handles cboTipoDoc.Click

    End Sub

    Private Sub cboTipoDoc_KeyDown(sender As Object, e As KeyEventArgs) Handles cboTipoDoc.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtNumero.Visible Then
                txtSerie.Select()
                txtSerie.Focus()
            Else
                cboMoneda.Select()
                cboMoneda.Focus()
                cboMoneda.DroppedDown = True
            End If
        End If
    End Sub

    Private Sub txtSerie_TextChanged(sender As Object, e As EventArgs) Handles txtSerie.TextChanged

    End Sub

    Private Sub txtSerie_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSerie.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtNumero.Select()
            txtNumero.Focus()
        End If
    End Sub

    Private Sub txtNumero_TextChanged(sender As Object, e As EventArgs) Handles txtNumero.TextChanged

    End Sub

    Private Sub txtNumero_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumero.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            cboMoneda.Select()
            cboMoneda.DroppedDown = True
        End If
    End Sub

    Private Sub cboMoneda_Click(sender As Object, e As EventArgs) Handles cboMoneda.Click

    End Sub

    Private Sub cboMoneda_KeyDown(sender As Object, e As KeyEventArgs) Handles cboMoneda.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If TextNumIdentrazon.Enabled Then
                TextNumIdentrazon.SelectAll()
                TextNumIdentrazon.Focus()
            Else
                TextBoxExt1.Select()
                TextBoxExt1.Focus()
            End If

        End If
    End Sub

    Sub GetDiasMes(mes As Integer, anio As Integer)
        Dim days As Integer = System.DateTime.DaysInMonth(anio, mes)
        TxtDia.MaxValue = days
        TxtDia.MinValue = 1

    End Sub

    Private Sub cboMesCompra_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboMesCompra.SelectedValueChanged
        If Not IsNothing(cboMesCompra.SelectedValue) Then
            'txtDia.Value = New Date(cboAnio.Text, CInt(cboMesCompra.SelectedValue), 1)
            'txtFechaGuia.Value = New DateTime(cboAnio.Text, CInt(cboMesCompra.SelectedValue), txtDia.Value.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
            If TxtDia.Text.Trim.Length > 0 Then
                GetDiasMes(Integer.Parse(cboMesCompra.SelectedValue), TextAnio.DecimalValue)
            Else
                If IsNumeric(cboMesCompra.SelectedValue) Then
                    GetDiasMes(Integer.Parse(cboMesCompra.SelectedValue), TextAnio.DecimalValue)
                    TxtDia.Clear()
                End If
            End If

            If cboMoneda.SelectedValue = 2 Then
                txtTipoCambio.DecimalValue = 0
            Else
                'If TxtDia.Text.Trim.Length > 0 Then
                '    Dim consulta = (From n In ListaTipoCambio
                '                    Where n.fechaIgv.Year = cboAnio.Text _
                '               And n.fechaIgv.Month = CInt(cboMesCompra.SelectedValue) _
                '               And n.fechaIgv.Day = TxtDia.Text).FirstOrDefault

                '    If Not IsNothing(consulta) Then
                '        txtTipoCambio.DecimalValue = consulta.venta
                '    Else
                '        'txtTipoCambio.DecimalValue = 0
                '    End If
                'End If
            End If
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        GrabarEnFormBasico()
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        If TextProveedor.Tag IsNot Nothing Then
            Dim f As New frmCrearENtidades(CInt(TextProveedor.Tag))
            f.CaptionLabels(0).Text = "Editar Proveedor"
            f.strTipo = TIPO_ENTIDAD.PROVEEDOR
            f.intIdEntidad = TextProveedor.Tag
            'f.UbicarEntidad(dgvProveedor.Table.CurrentRecord.GetValue("idEntidad"))
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()

            Dim Proveedor = entidadSA.UbicarEntidadPorID(CInt(TextProveedor.Tag)).FirstOrDefault

            If Proveedor IsNot Nothing Then
                TextNumIdentrazon.Text = Proveedor.nrodoc
                TextProveedor.Text = Proveedor.nombreCompleto
                TextProveedor.Tag = Proveedor.idEntidad
            End If

        Else
            MessageBox.Show("Debe seleccionar un cliente!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub BunifuThinButton25_Click(sender As Object, e As EventArgs) Handles BunifuThinButton25.Click
        Cursor = Cursors.WaitCursor
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.EDITAR_PRODUCTO_Botón___, AutorizacionRolList) Then
            If TextBoxExt1.Text.Trim.Length > 0 Then
                If TextBoxExt1.Tag IsNot Nothing Then
                    'Dim f As New frmNuevaExistencia(Val(TextBoxExt1.Tag))
                    Dim f As New FormNuevoCalzado(Val(TextBoxExt1.Tag))
                    f.EstadoManipulacion = ENTITY_ACTIONS.UPDATE
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()
                Else
                    MessageBox.Show("Seleccione un producto válido", "Seleccinar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If

        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GridCompra_TableControlCheckBoxClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridCompra.TableControlCheckBoxClick
        Me.Cursor = Cursors.WaitCursor
        Dim obj As New documentocompra
        Dim RowIndex As Integer = e.Inner.RowIndex

        If RowIndex > -1 Then
            e.TableControl.CurrentCell.EndEdit()
            e.TableControl.Table.TableDirty = True
            e.TableControl.Table.EndEdit()

            Dim valCheck = Me.GridCompra.TableModel(RowIndex, 14).CellValue
            Select Case valCheck
                Case "False" 'TRUE
                    Me.GridCompra.TableModel(RowIndex, 15).CellValue = "S"
                    GetCalculoItem(RowIndex)
                    EditarItemCompra(RowIndex)
                    'MessageBox.Show(True)
                Case Else ' FALSE
                    Me.GridCompra.TableModel(RowIndex, 15).CellValue = "N"
                    GetCalculoItem(RowIndex)
                    EditarItemCompra(RowIndex)
                    'MessageBox.Show(False)
            End Select
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub TextNumIdentrazon_TextChanged(sender As Object, e As EventArgs) Handles TextNumIdentrazon.TextChanged

    End Sub

    Private Sub GridCompra_TableControlCurrentCellKeyDown(sender As Object, e As GridTableControlKeyEventArgs) Handles GridCompra.TableControlCurrentCellKeyDown
        If e.Inner.KeyCode = Keys.Enter Then
            Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
            Dim cc As GridCurrentCell = GridCompra.TableControl.CurrentCell
            cc.ConfirmChanges()
            'If cc.Renderer IsNot Nothing Then

            If cc.ColIndex > -1 Then
                Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)

                If style.TableCellIdentity.Column.Name = "equivalencia" Then
                    Me.GridCompra.Table.CurrentRecord.SetCurrent("cantidad")


                ElseIf style.TableCellIdentity.Column.Name = "gravado" Or style.TableCellIdentity.Column.Name = "item" Or style.TableCellIdentity.Column.Name = "codigo" Then
                    Me.GridCompra.Table.CurrentRecord.SetCurrent("equivalencia")
                    Me.GridCompra.TableControl.CurrentCell.ShowDropDown()

                ElseIf style.TableCellIdentity.Column.Name = "cantidad" Then
                    Me.GridCompra.Table.CurrentRecord.SetCurrent("totalmn")
                End If
            End If
            'End If

        End If
    End Sub

    Private Sub ComboDespacho_Click(sender As Object, e As EventArgs) Handles ComboDespacho.Click

    End Sub

    Private Sub ComboDespacho_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboDespacho.SelectedValueChanged
        If ComboDespacho.Text.Trim.Length > 0 Then
            ComboAlmacen.DataSource = Nothing
            ComboAlmacen.Visible = True
            Label18.Visible = True
            Select Case ComboDespacho.Text
                Case "UN ALMACEN"
                    Dim almacenes = almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
                    ComboAlmacen.DataSource = almacenes
                    ComboAlmacen.DisplayMember = "descripcionAlmacen"
                    ComboAlmacen.ValueMember = "idAlmacen"
                Case "EN TRANSITO"
                    Dim almacenes = almacenSA.GetUbicar_almacenVirtual(GEstableciento.IdEstablecimiento)
                    Dim listaAlm As New List(Of almacen)
                    listaAlm.Add(almacenes)
                    ComboAlmacen.DataSource = listaAlm
                    ComboAlmacen.DisplayMember = "descripcionAlmacen"
                    ComboAlmacen.ValueMember = "idAlmacen"
                Case "MULTI-ALMACEN"
                    ComboAlmacen.Visible = False
                    Label18.Visible = False
            End Select
        Else
            ComboAlmacen.DataSource = Nothing
        End If
    End Sub

    Private Sub GridCompra_TableControlCurrentCellShowingDropDown(sender As Object, e As GridTableControlCurrentCellShowingDropDownEventArgs) Handles GridCompra.TableControlCurrentCellShowingDropDown
        If e.Inner.Size.Height = 117 Then
            e.Inner.Size = New Size(e.Inner.Size.Width, 180)
        Else
            e.Inner.Size = New Size(e.Inner.Size.Width, e.Inner.Size.Height)
        End If
    End Sub

    Private Sub BgProveedor_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BgProveedor.DoWork
        GetConsultaSunatThread(TextNumIdentrazon.Text)
    End Sub

    Private Sub BgProveedor_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgProveedor.RunWorkerCompleted
        If SelRazon.nrodoc IsNot Nothing Then
            SelRazon.nombreCompleto = SelRazon.nombreCompleto.ToString.Replace(Chr(34), "")
            GrabarEntidadRapidaThread()
            TextNumIdentrazon.Text = SelRazon.nrodoc
            TextProveedor.Text = SelRazon.nombreCompleto
            TextNumIdentrazon.ReadOnly = False
            SelRazon = New entidad
            TextBoxExt1.Select()

        Else
            TextProveedor.Clear()
            TextProveedor.Tag = Nothing
            TextNumIdentrazon.ReadOnly = False
            SelRazon = New entidad
            TextNumIdentrazon.Select()
        End If
        PictureLoad.Visible = False
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            'cboTipoDoc.Text = "BOLETA"
            TextNumIdentrazon.Enabled = False
            TextNumIdentrazon.Text = VarClienteGeneral.idEntidad
            TextProveedor.Text = VarClienteGeneral.nombreCompleto
            TextProveedor.Tag = VarClienteGeneral.idEntidad
            TextProveedor.Enabled = False
            TextBoxExt1.Select()
            TextBoxExt1.Focus()
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            'cboTipoDoc.Text = "BOLETA"
            TextNumIdentrazon.Enabled = True
            TextNumIdentrazon.Text = String.Empty
            TextProveedor.Text = String.Empty
            TextProveedor.Tag = Nothing
            TextProveedor.Enabled = False

        End If
    End Sub

    Private Sub BunifuThinButton26_Click(sender As Object, e As EventArgs) Handles BunifuThinButton26.Click
        'Dim r As Record = GridCompra.Table.CurrentRecord
        'If r IsNot Nothing Then
        '    Dim item = ListaproductosComprados.Where(Function(o) o.CodigoCosto = r.GetValue("codigo")).SingleOrDefault
        '    Dim form As New FormCrearCompraPrecios(item.CustomProducto.codigodetalle, )
        '    form.StartPosition = FormStartPosition.CenterParent
        '    form.ShowDialog(Me)
        'End If
    End Sub

    Private Sub GridCompra_TableControlDrawCell(sender As Object, e As GridTableControlDrawCellEventArgs) Handles GridCompra.TableControlDrawCell
        If e.Inner.Style.CellType = "PushButton" Then
            e.Inner.Cancel = True

            ' //Draw the Image in a cell.
            If e.Inner.ColIndex = 16 Then
                e.Inner.Style.Description = "Precios"
                e.Inner.Style.TextColor = Color.Black
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)
                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3),
                                           New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6)
                    )
                '    e.Inner.Graphics.DrawImage(Me.ImageList1.Images(0), irect)
            End If
        End If
    End Sub

    Private Sub GridCompra_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs) Handles GridCompra.TableControlPushButtonClick
        Me.Cursor = Cursors.WaitCursor
        Dim precioSA As New detalleitemequivalencia_preciosSA
        Try
            If e.Inner.ColIndex = 16 Then

                Dim sty As GridTableCellStyleInfo = e.TableControl.GetTableViewStyleInfo(e.Inner.RowIndex, e.Inner.ColIndex)
                Dim record = sty.TableCellIdentity.DisplayElement.GetRecord()

                If record Is Nothing Then Exit Sub
                Dim item = ListaproductosComprados.Where(Function(o) o.CodigoCosto = record.GetValue("codigo")).SingleOrDefault
                If item Is Nothing Then Exit Sub

                If Decimal.Parse(record.GetValue("cantidad")) > 0 AndAlso Decimal.Parse(record.GetValue("totalmn")) > 0 Then
                    Dim precioUnitarioCompra = Math.Round(Decimal.Parse(record.GetValue("totalmn")) / Decimal.Parse(record.GetValue("cantidad")), 2)

                    Dim form As New FormCrearCompraPrecios(item.CustomProducto.codigodetalle, precioUnitarioCompra)
                    form.StartPosition = FormStartPosition.CenterParent
                    form.ShowDialog(Me)
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cboMoneda_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboMoneda.SelectedValueChanged
        If cboMoneda.Text = "NUEVO SOL" Then
            GridCompra.TableDescriptor.Columns("totalmn").ReadOnly = False
            GridCompra.TableDescriptor.Columns("totalme").ReadOnly = True
            ZeroRows()
        Else
            GridCompra.TableDescriptor.Columns("totalmn").ReadOnly = True
            GridCompra.TableDescriptor.Columns("totalme").ReadOnly = False
            ZeroRows()
        End If
    End Sub

    Private Sub TxtTipoCambio_TextChanged(sender As Object, e As EventArgs) Handles txtTipoCambio.TextChanged

    End Sub

    Private Sub txtIva_TextChanged(sender As Object, e As EventArgs) Handles txtIva.TextChanged

    End Sub

    Private Sub ComboTipoCategorias_Click(sender As Object, e As EventArgs) Handles ComboTipoCategorias.Click

    End Sub



    Private Sub ComboTipoCategorias_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboTipoCategorias.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True

            If ComboTipoBusqueda.Text.Trim.Length > 0 Then


                Select Case ComboTipoBusqueda.Text

                    Case "CATEGORIA"


                        PictureLoadingProduct.Visible = True
                        listaProductos = ProductoSA.GetProductosWithEquivalencias(New detalleitems With {.descripcionItem = TextBoxExt1.Text,
                                                                                  .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                                  .typeConsult = ComboTipoBusqueda.Text,
                                                                                  .idItem = ComboTipoCategorias.SelectedValue})

                        ListProductos.Items.Clear()

                        If listaProductos.Count > 0 Then
                            Dim consulta As New List(Of detalleitems)
                            consulta.Add(New detalleitems With {.descripcionItem = "Agregar nuevo"})
                            consulta.AddRange(listaProductos)
                            GetListProductos(consulta)

                            Me.PopupProductos.Size = New Size(636, 147)
                            Me.PopupProductos.ParentControl = Me.TextBoxExt1
                            Me.PopupProductos.ShowPopup(Point.Empty)
                            PictureLoadingProduct.Visible = False
                        End If
                    Case "SUBCATEGORIA"

                        PictureLoadingProduct.Visible = True
                        listaProductos = ProductoSA.GetProductosWithEquivalencias(New detalleitems With {.descripcionItem = TextBoxExt1.Text,
                                                                                  .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                                  .typeConsult = ComboTipoBusqueda.Text,
                                                                                  .unidad2 = ComboTipoCategorias.SelectedValue})

                        ListProductos.Items.Clear()

                        If listaProductos.Count > 0 Then
                            Dim consulta As New List(Of detalleitems)
                            consulta.Add(New detalleitems With {.descripcionItem = "Agregar nuevo"})
                            consulta.AddRange(listaProductos)
                            GetListProductos(consulta)

                            Me.PopupProductos.Size = New Size(636, 147)
                            Me.PopupProductos.ParentControl = Me.TextBoxExt1
                            Me.PopupProductos.ShowPopup(Point.Empty)
                            PictureLoadingProduct.Visible = False
                        End If

                    Case "MARCA"


                        PictureLoadingProduct.Visible = True
                        listaProductos = ProductoSA.GetProductosWithEquivalencias(New detalleitems With {.descripcionItem = TextBoxExt1.Text,
                                                                                  .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                                  .typeConsult = ComboTipoBusqueda.Text,
                                                                                  .marcaRef = ComboTipoCategorias.SelectedValue})

                        ListProductos.Items.Clear()

                        If listaProductos.Count > 0 Then
                            Dim consulta As New List(Of detalleitems)
                            consulta.Add(New detalleitems With {.descripcionItem = "Agregar nuevo"})
                            consulta.AddRange(listaProductos)
                            GetListProductos(consulta)

                            Me.PopupProductos.Size = New Size(636, 147)
                            Me.PopupProductos.ParentControl = Me.TextBoxExt1
                            Me.PopupProductos.ShowPopup(Point.Empty)
                            PictureLoadingProduct.Visible = False
                        End If



                End Select



            End If




        End If
    End Sub

    Private Sub ComboTipoBusqueda_Click(sender As Object, e As EventArgs) Handles ComboTipoBusqueda.Click

    End Sub

    Private Sub ComboTipoBusqueda_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboTipoBusqueda.SelectedValueChanged
        Select Case ComboTipoBusqueda.Text
            Case "PRODUCTO"

                TextBoxExt1.Clear()
                TextBoxExt1.Select()

                TextBoxExt1.Visible = True
                ComboTipoCategorias.Visible = False

            Case "SERVICIO"

                TextBoxExt1.Clear()
                TextBoxExt1.Select()

                TextBoxExt1.Visible = True
                ComboTipoCategorias.Visible = False

            Case "CODIGO BARRA"

                TextBoxExt1.Clear()
                TextBoxExt1.Select()


                TextBoxExt1.Visible = True
                ComboTipoCategorias.Visible = False
            Case "CODIGO INTERNO"

                TextBoxExt1.Clear()
                TextBoxExt1.Select()

                TextBoxExt1.Visible = True
                ComboTipoCategorias.Visible = False



            Case "CATEGORIA"
                TextBoxExt1.Visible = False
                ComboTipoCategorias.Visible = True
                AgregarComboXTipoCategoria(TipoGrupoArticulo.CategoriaGeneral)
                ComboTipoCategorias.Select()

            Case "SUBCATEGORIA"
                TextBoxExt1.Visible = False
                ComboTipoCategorias.Visible = True
                AgregarComboXTipoCategoria(TipoGrupoArticulo.SubCategoriaGeneral)
                ComboTipoCategorias.Select()

            Case "MARCA"
                TextBoxExt1.Visible = False
                ComboTipoCategorias.Visible = True
                AgregarComboXTipoCategoria(TipoGrupoArticulo.Marca)
                ComboTipoCategorias.Select()

            Case "PRESENTACION/MODELO"

                TextBoxExt1.Clear()
                TextBoxExt1.Select()
                TextBoxExt1.Visible = True
                ComboTipoCategorias.Visible = False

            Case "COLOR"

                TextBoxExt1.Clear()
                TextBoxExt1.Select()
                TextBoxExt1.Visible = True
                ComboTipoCategorias.Visible = False

            Case "TALLA"

                TextBoxExt1.Clear()
                TextBoxExt1.Select()
                TextBoxExt1.Visible = True
                ComboTipoCategorias.Visible = False
        End Select
    End Sub

#End Region

End Class
