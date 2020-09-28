Imports System.ComponentModel
Imports System.Net
Imports System.IO
Imports System.Threading
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports ProcesosGeneralesCajamiSoft
Imports Syncfusion.Windows.Forms

Public Class FormRealizacionDePagos

#Region "Attributes"
    Private Property config As GConfiguracionModulo
    Dim Alert As Alert
    Private threadTablas As Thread
    Private threadEntidades As Thread
    Public Property ListaEntidad As List(Of entidad)
    Public Property ListaTrabajadores As List(Of Persona)
    Public Property SelRazon As entidad
    Private frmSeleccionCuentaFinanciera As frmSeleccionCuentaFinanciera
#End Region

#Region "Fields"
    Dim entidadSA As New entidadSA
    Dim personaSA As New PersonaSA
    Friend Delegate Sub SetDataSourceDelegate(ByVal lista As List(Of tabladetalle), tipo As String)
    Friend Delegate Sub SetDelegateEntidad(ByVal lista As List(Of entidad), tipo As String)
    Friend Delegate Sub SetDelegatePersona(ByVal Persons As List(Of Persona))
#End Region

#Region "Constructors"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        '   GetThreadTablas()
        GetCombos()
        '   GetThreadEntidades(TIPO_ENTIDAD.PERSONA_GENERAL)
    End Sub

#End Region

#Region "Methods"
    Private Async Sub GetConsultaSunatAsync(ruc As String, TipoEntidad As String)
        SelRazon = New entidad
        Dim nroDoc = ruc.Substring(0, 1).ToString
        If nroDoc = "1" Then
            Dim company = CType(Await SoftPackERP_Sunat.GetRucContribuyenteSPK.GetContribuyente(ruc), SoftPackERP_Sunat.CompanyJuridico)
            If company IsNot Nothing Then
                ' If company.ContribuyenteTipo = "PERSONA NATURAL SIN NEGOCIO" Then
                SelRazon.tipoPersona = "N"
                SelRazon.tipoDoc = "6"
                ' End If
                SelRazon.tipoEntidad = TipoEntidad '"CL"
                SelRazon.nombreCompleto = company.RazonSocial
                TextPersona.Text = company.RazonSocial
                SelRazon.nombreContacto = company.RazonSocial
                SelRazon.estado = company.ContribuyenteEstado
                SelRazon.nrodoc = company.Ruc
                SelRazon.direccion = company.DomicilioFiscal
                GrabarEntidadRapida(TipoEntidad)
                PictureLoad.Visible = False
            Else
                TextPersona.Clear()
                PictureLoad.Visible = False
            End If
        ElseIf nroDoc = "2" Then
            Dim company = CType(Await SoftPackERP_Sunat.GetRucContribuyenteSPK.GetContribuyente(ruc), SoftPackERP_Sunat.CompanyJuridico)
            If company IsNot Nothing Then
                'If company.ContribuyenteTipo = "SOCIEDAD ANONIMA CERRADA" Then
                SelRazon.tipoPersona = "J"
                SelRazon.tipoDoc = "6"
                '  End If
                SelRazon.tipoEntidad = TipoEntidad
                SelRazon.nombreCompleto = company.RazonSocial
                SelRazon.nombreContacto = company.RazonSocial
                TextPersona.Text = company.RazonSocial
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
                GrabarEntidadRapida(TipoEntidad)
                PictureLoad.Visible = False
            Else
                TextPersona.Clear()
                PictureLoad.Visible = False
            End If
        End If
        TextDNI.ReadOnly = False
    End Sub

    Private Function GetValidarLocalDB(idEntidad As String) As Boolean
        GetValidarLocalDB = False
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        If RBCliente.Checked = True Then
            entidad = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", idEntidad)
        ElseIf RBProveedor.Checked = True Then
            entidad = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "PR", idEntidad)
        End If


        If entidad IsNot Nothing Then
            SelRazon = New entidad
            SelRazon = entidad
            TextPersona.Text = entidad.nombreCompleto
            TextPersona.Tag = entidad.idEntidad
            GetValidarLocalDB = True
            PictureLoad.Visible = False

            If TextPersona.Text.Trim.Length > 0 Then
                TextGlosa.Select()
                TextGlosa.Focus()
            Else
                TextDNI.Clear()
                TextDNI.Select()
            End If
        End If
    End Function

    Private Sub GrabarEntidadRapida(tipoentidad As String)
        Dim obEntidad As New entidad
        Dim entidadSA As New entidadSA
        Try
            'Se asigna cada uno de los datos registrados
            obEntidad.idEmpresa = Gempresas.IdEmpresaRuc
            obEntidad.idOrganizacion = GEstableciento.IdEstablecimiento
            obEntidad.tipoEntidad = tipoentidad '"CL"
            obEntidad.tipoDoc = SelRazon.tipoDoc
            obEntidad.tipoPersona = SelRazon.tipoPersona
            obEntidad.nrodoc = SelRazon.nrodoc
            obEntidad.nombreCompleto = TextPersona.Text.Trim
            Select Case tipoentidad
                Case TIPO_ENTIDAD.PROVEEDOR
                    obEntidad.cuentaAsiento = "4212"
                Case TIPO_ENTIDAD.CLIENTE
                    obEntidad.cuentaAsiento = "1213"
            End Select
            '"1213"
            obEntidad.direccion = SelRazon.direccion
            obEntidad.estado = StatusEntidad.Activo
            Dim codx As Integer = entidadSA.GrabarEntidad(obEntidad)

            TextPersona.Tag = codx
            Dim entidad As New entidad
            entidad.idEntidad = codx
            entidad.nrodoc = TextDNI.Text.Trim
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
            MsgBox("No se pudo grabar la persona." & vbCrLf & ex.Message, MsgBoxStyle.Critical)
            Me.Tag = Nothing
        End Try
    End Sub

    Private Function GetConsultarDNIReniec(Dni As String) As String
        Dim CLIENTE As New WebClient
        Dim PAGINA As Stream = CLIENTE.OpenRead("http://aplicaciones007.jne.gob.pe/srop_publico/Consulta/Afiliado/GetNombresCiudadano?DNI=" & Dni)
        Dim LECTOR As New StreamReader(PAGINA)
        Dim MIHTML As String = LECTOR.ReadToEnd
        ' Dim array = MIHTML.Split("|")

        Dim nombres = MIHTML.Replace("|", Space(1))
        Return Trim(nombres)
    End Function

    Private Sub GrabarEnFormBasico()
        Dim f As New frmCrearENtidades
        If RBCliente.Checked = True Then
            f.strTipo = TIPO_ENTIDAD.CLIENTE
            f.CaptionLabels(0).Text = "Nuevo cliente"
        ElseIf RBProveedor.Checked = True Then
            f.strTipo = TIPO_ENTIDAD.PROVEEDOR
            f.CaptionLabels(0).Text = "Nuevo proveedor"
        End If
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        If f.Tag IsNot Nothing Then
            Dim ent = CType(f.Tag, entidad)
            TextDNI.Text = ent.nrodoc
            TextPersona.Text = ent.nombreCompleto
            TextPersona.Tag = ent.idEntidad
        Else
            TextDNI.Text = String.Empty
            TextPersona.Text = String.Empty
            TextPersona.Tag = Nothing
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
                    If RBCliente.Checked = True Then
                        SelRazon.tipoEntidad = "CL"
                    ElseIf RBProveedor.Checked = True Then
                        SelRazon.tipoEntidad = "PR"
                    End If

                    SelRazon.tipoPersona = "N"
                    SelRazon.tipoDoc = "6"
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
                    If RBCliente.Checked = True Then
                        SelRazon.tipoEntidad = "CL"
                    ElseIf RBProveedor.Checked = True Then
                        SelRazon.tipoEntidad = "PR"
                    End If
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

    Private Sub GetCombos()
        cboMesCompra.DisplayMember = "Mes"
        cboMesCompra.ValueMember = "Codigo"
        cboMesCompra.DataSource = ListaDeMeses()
        configuracionModuloV2(Gempresas.IdEmpresaRuc, "OED", Me.Text, GEstableciento.IdEstablecimiento)
    End Sub
    'Public Sub configuracionModulo(strIDEmpresa As String, strIdModulo As String, strNomModulo As String, intIdEstablecimiento As Integer)
    '    Dim moduloConfiguracionSA As New ModuloConfiguracionSA
    '    Dim moduloConfiguracion As New moduloConfiguracion
    '    Dim numeracionSA As New NumeracionBoletaSA
    '    Dim TablaSA As New tablaDetalleSA
    '    Dim almacenSA As New almacenSA
    '    Dim cajaSA As New EstadosFinancierosSA

    '    moduloConfiguracion = moduloConfiguracionSA.UbicarConfiguracionPorEmpresaModulo(strIdModulo, strIDEmpresa, intIdEstablecimiento)
    '    If Not IsNothing(moduloConfiguracion) Then
    '        With moduloConfiguracion
    '            config = New GConfiguracionModulo
    '            config.IdModulo = .idModulo
    '            config.NomModulo = strNomModulo
    '            config.TipoConfiguracion = .tipoConfiguracion
    '            Select Case .tipoConfiguracion
    '                Case "P"
    '                    With numeracionSA.GetUbicar_numeracionBoletasPorID(.configComprobante)
    '                        config.ConfigComprobante = .IdEnumeracion
    '                        config.TipoComprobante = .tipo
    '                        config.NombreComprobante = TablaSA.GetUbicarTablaID(10, .tipo).descripcion
    '                        config.Serie = .serie
    '                        config.ValorActual = .valorInicial
    '                    End With
    '            End Select
    '            If Not IsNothing(.configAlmacen) Then
    '                Dim estableSA As New establecimientoSA
    '                With almacenSA.GetUbicar_almacenPorID(.configAlmacen)
    '                    config.IdAlmacen = .idAlmacen
    '                    config.NombreAlmacen = .descripcionAlmacen
    '                    With estableSA.UbicaEstablecimientoPorID(.idEstablecimiento)
    '                    End With
    '                End With
    '            End If
    '            If Not IsNothing(.ConfigentidadFinanciera) Then
    '                With cajaSA.GetUbicar_estadosFinancierosPorID(.ConfigentidadFinanciera)
    '                    config.IDCaja = .idestado
    '                    config.NomCaja = .descripcion
    '                End With
    '            End If

    '        End With
    '    Else
    '        MsgBox("Este módulo no contiene una configuración disponible, intentelo más tarde.!")
    '    End If
    'End Sub

    Public Sub configuracionModuloV2(strIDEmpresa As String, strIdModulo As String, strNomModulo As String, intIdEstablecimiento As Integer)
        Try

            Dim moduloConfiguracionSA As New ModuloConfiguracionSA
            Dim moduloConfiguracion As New moduloConfiguracion
            Dim numeracionSA As New NumeracionBoletaSA
            Dim TablaSA As New tablaDetalleSA
            Dim almacenSA As New almacenSA
            Dim cajaSA As New EstadosFinancierosSA

            'ANTIGUA NUMERACION
            'Dim RecuperacionNumeracion = numeracionSA.GetUbicar_numeracionBoletasXUnidadNegocio(New numeracionBoletas With {.empresa = strIDEmpresa, .establecimiento = intIdEstablecimiento, .codigoNumeracion = strIdModulo, .estado = "A"})
            'NUVEVA NUMEARACION CON LA BD

            Dim RecuperacionNumeracion = numeracionSA.NumeracionBoletasSelV2(GEstableciento.IdEstablecimiento, "OED", "9903", usuario.IDRol)
            If (Not IsNothing(RecuperacionNumeracion)) Then
                config = New GConfiguracionModulo
                config.ConfigComprobante = CInt(RecuperacionNumeracion.IdEnumeracion)
                config.TipoComprobante = RecuperacionNumeracion.tipo
                config.NombreComprobante = TablaSA.GetUbicarTablaID(10, RecuperacionNumeracion.tipo).descripcion
                config.Serie = RecuperacionNumeracion.serie
                config.ValorActual = RecuperacionNumeracion.valorInicial
            Else
                Throw New Exception("Verificar configuración")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


        'If Not IsNothing(.configAlmacen) Then
        '            Dim estableSA As New establecimientoSA
        '            With almacenSA.GetUbicar_almacenPorID(.configAlmacen)
        '                config.IdAlmacen = .idAlmacen
        '                config.NombreAlmacen = .descripcionAlmacen
        '                With estableSA.UbicaEstablecimientoPorID(.idEstablecimiento)
        '                End With
        '            End With
        '        End If

        'If Not IsNothing(.ConfigentidadFinanciera) Then
        '            With cajaSA.GetUbicar_estadosFinancierosPorID(.ConfigentidadFinanciera)
        '                config.IDCaja = .idestado
        '                config.NomCaja = .descripcion
        '            End With
        '        End If

        '    End With
        'Else
        '    MsgBox("Este módulo no contiene una configuración disponible, intentelo más tarde.!")
        'End If
    End Sub

    Sub HabilitarControles(tipoEntidad As String, estado As Boolean)
        Select Case tipoEntidad
            Case TIPO_ENTIDAD.CLIENTE
                RBProveedor.Enabled = estado
                RBCPlanilla.Enabled = estado
                RBOtros.Enabled = estado
            Case TIPO_ENTIDAD.PROVEEDOR
                RBCliente.Enabled = estado
                RBCPlanilla.Enabled = estado
                RBOtros.Enabled = estado
            Case TIPO_ENTIDAD.PERSONA_GENERAL
                RBCliente.Enabled = estado
                RBProveedor.Enabled = estado
                RBCPlanilla.Enabled = estado
            Case TIPO_ENTIDAD.PERSONAL_PLANILLA
                RBCliente.Enabled = estado
                RBProveedor.Enabled = estado
                RBOtros.Enabled = estado
        End Select

    End Sub

    Private Sub GetThreadTablas(tipo As String)
        threadTablas = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetTablas(tipo)))
        threadTablas.Start()
    End Sub

    Private Sub GetTablas(tipo As String)
        Dim tablaSA As New tablaDetalleSA
        Dim lista = tablaSA.GetListaTablaDetalle(1, "1")
        setDataSource(lista, tipo)
    End Sub

    Private Sub setDataSource(ByVal lista As List(Of tabladetalle), tipo As String)
        If Me.InvokeRequired Then
            Dim deleg As New SetDataSourceDelegate(AddressOf setDataSource)
            Invoke(deleg, New Object() {lista, tipo})
        Else
            Select Case tipo
                Case "EF"
                    Dim tablas() As String = {"004", "008", "009", "109", "9903"}
                    cboFormaPago.DataSource = lista.Where(Function(o) tablas.Contains(o.codigoDetalle)).ToList
                    cboFormaPago.DisplayMember = "descripcion"
                    cboFormaPago.ValueMember = "codigoDetalle"
                Case "BC", "TC"
                    Dim tablas() As String = {"001", "003", "005", "006", "007", "011", "102", "111"}
                    cboFormaPago.DataSource = lista.Where(Function(o) tablas.Contains(o.codigoDetalle)).ToList
                    cboFormaPago.DisplayMember = "descripcion"
                    cboFormaPago.ValueMember = "codigoDetalle"
            End Select
        End If
    End Sub

    Private Sub GetThreadEntidades(strTipo As String)
        Try
            TextPersona.Clear()
            TextDNI.Clear()
            HabilitarControles(strTipo, False)
            threadEntidades = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetEntidades(strTipo)))
            threadEntidades.Start()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        'ProgressBar1.Visible = True
        'ProgressBar1.Style = ProgressBarStyle.Marquee

    End Sub

    Private Sub GetEntidades(tipoPerson As String)

        Select Case tipoPerson
            Case TIPO_ENTIDAD.PROVEEDOR, TIPO_ENTIDAD.CLIENTE
                Dim ListaEntidades As New List(Of entidad)
                ListaEntidades = entidadSA.GetListarEntidad(New entidad With {.tipoEntidad = tipoPerson, .idEmpresa = Gempresas.IdEmpresaRuc, .idOrganizacion = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
                setDataSourceEntidad(ListaEntidades, tipoPerson)
            Case TIPO_ENTIDAD.PERSONA_GENERAL
                Dim listaPersonas As New PersonaSA
                Dim ListaPersons As New List(Of Persona)
                ListaPersons = personaSA.ObtenerPersona(New Persona With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                 .tipoPersona = "T"}).ToList
                setDataSourcePersona(ListaPersons)
        End Select


    End Sub

    Private Sub setDataSourceEntidad(GetEntidades As List(Of entidad), tipo As String)
        If Me.InvokeRequired Then
            Dim deleg As New SetDelegateEntidad(AddressOf setDataSourceEntidad)
            Invoke(deleg, New Object() {GetEntidades, tipo})
        Else
            ListaEntidad = New List(Of entidad)
            ListaEntidad = GetEntidades
            '         ProgressBar1.Visible = False
            HabilitarControles(tipo, True)
        End If
    End Sub

    Private Sub setDataSourcePersona(GetPersonas As List(Of Persona))
        If Me.InvokeRequired Then
            Dim deleg As New SetDelegatePersona(AddressOf setDataSourcePersona)
            Invoke(deleg, New Object() {GetPersonas})
        Else
            ListaTrabajadores = New List(Of Persona)
            ListaTrabajadores = GetPersonas
            'ProgressBar1.Visible = False
            HabilitarControles(TIPO_ENTIDAD.PERSONA_GENERAL, True)
        End If
    End Sub

    Private Sub FillLSVPersonas(consulta As List(Of Persona))
        lsvProveedor.Items.Clear()
        '     Dim image = ImageList1.Images(0)
        For Each i In consulta
            Dim n As New ListViewItem(i.idPersona)

            n.SubItems.Add(i.nombreCompleto)
            n.SubItems.Add(i.idPersona)
            lsvProveedor.Items.Add(n)
        Next
    End Sub

    Private Sub FillLSVEntidades(consulta As List(Of entidad))
        lsvProveedor.Items.Clear()
        '     Dim image = ImageList1.Images(0)
        For Each i In consulta
            Dim n As New ListViewItem(i.idEntidad)

            n.SubItems.Add(i.nombreCompleto)
            n.SubItems.Add(i.nrodoc)
            lsvProveedor.Items.Add(n)
        Next
    End Sub

    Sub Calculo()
        Dim tcambio As Decimal = 0
        Dim Imn As Decimal = 0
        tcambio = txtTipoCambio.Value
        If tcambio > 0 Then
            Imn = txtFondoMN.Value
            txtFondoME.Value = Math.Round(Imn / tcambio, 2)
        End If
    End Sub

    Private Function ValidarGrabado() As Boolean
        Dim listaErrores As Integer = 0

        If TxtDia.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(TxtDia, "El campo fecha es requerido")
            listaErrores += 1
        Else
            ErrorProvider1.SetError(TxtDia, Nothing)
        End If

        If TextPersona.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(TextPersona, "El campo persona es requerido")
            listaErrores += 1
        Else
            ErrorProvider1.SetError(TextPersona, Nothing)
        End If

        If txtCF_name.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(txtCF_name, "El campo entidad financiera es requerido")
            listaErrores += 1
        Else
            ErrorProvider1.SetError(txtCF_name, Nothing)
        End If

        If TextPersona.Text.Trim.Length > 0 Then
            If TextPersona.ForeColor = Color.Black Then
                ErrorProvider1.SetError(TextPersona, "Verificar el ingreso correcto del personal")
                listaErrores += 1
            Else
                ErrorProvider1.SetError(TextPersona, Nothing)
            End If
        Else
            'ErrorProvider1.SetError(TextPersona, Nothing)
        End If

        If txtFondoMN.Value <= 0 Then
            ErrorProvider1.SetError(txtFondoMN, "El importe debe ser mayor a cero")
            listaErrores += 1
        Else
            ErrorProvider1.SetError(txtFondoMN, Nothing)
        End If

        If TextGlosa.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(TextGlosa, "El campo glosa es requerido")
            listaErrores += 1
        Else
            ErrorProvider1.SetError(TextGlosa, Nothing)
        End If

        If listaErrores > 0 Then
            ValidarGrabado = False
        Else
            ValidarGrabado = True
        End If
    End Function

    Private Function GetCodigoVendedor() As Helios.Seguridad.Business.Entity.Usuario
        GetCodigoVendedor = Nothing
        Dim f As New FormCodigoVendedor
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        If f.Tag IsNot Nothing Then
            Dim c = CType(f.Tag, Helios.Seguridad.Business.Entity.Usuario)
            GetCodigoVendedor = c
        End If
    End Function



    ''' <summary>
    ''' Guardar datos de otros ingresos
    ''' </summary>
    Public Sub Grabar()
        Dim cajaUsuaroSA As New cajaUsuarioSA
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim ndocumento As New documento
        Dim ndocumentoCaja As New documentoCaja
        Dim ndocumentoCajaDetalle As New documentoCajaDetalle
        Dim ListadocumentoCajaDetalle As New List(Of documentoCajaDetalle)
        Dim idNumeracion As Integer
        Dim IDCajaUsuario_Login As Integer
        Dim tipoEntidad As String = Nothing





        Dim cajaActiva

        If usuario.tipoCaja = Tipo_Caja.ADMINISTRATIVO Then


            cajaActiva = ListaCajasActivas.Where(Function(o) o.tipoCaja = Tipo_Caja.GENERAL).SingleOrDefault

            If cajaActiva Is Nothing Then
                ListaCajasActivas = cajaUsuaroSA.ListadoCajaXEstado(New cajaUsuario With {
                                                                 .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                 .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                 .estadoCaja = "A"
                                                                 })
                Throw New Exception("La Caja Administrativa no esta Abierta ")

            End If

        ElseIf usuario.tipoCaja = Tipo_Caja.PUNTO_DE_VENTA Then

            'Dim Vendedor As New Seguridad.Business.Entity.Usuario


            'Vendedor = (From i In UsuariosList Where i.IDUsuario = usuario.IDUsuario And i.IDRol = usuario.IDRol).SingleOrDefault
            'If Vendedor Is Nothing Then
            '    Throw New Exception("Usuario no Valido")
            'End If
            '' End If

            'Dim codigoVendedor = Vendedor.codigo


            'If Vendedor Is Nothing Then
            '    Throw New Exception("Debe indicar el código del vendedor!")
            'End If



            cajaActiva = ListaCajasActivas.Where(Function(o) o.idPersona = usuario.IDUsuario And o.IDRol = usuario.IDRol).SingleOrDefault

            If cajaActiva Is Nothing Then
                ListaCajasActivas = cajaUsuaroSA.ListadoCajaXEstado(New cajaUsuario With {
                                                                 .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                 .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                 .estadoCaja = "A"
                                                                 })
                Throw New Exception("Su usuario  no tiene una Caja abierta ")

            End If
        Else
            MessageBox.Show("Su Cargo no esta configurado")
            Exit Sub
        End If




        'Dim cajaUsuario = cajaUsuaroSA.UbicarCajaUsuarioPorID(cajaActiva.idcajaUsuario)
        'If cajaUsuario Is Nothing Then
        '    Throw New Exception("no existe caja activa!")
        'End If


        IDCajaUsuario_Login = GetUsuarioCaja(cajaActiva.idcajaUsuario)
        tipoEntidad = GetEntidadElegida(tipoEntidad)
        idNumeracion = IIf(IsNothing(config.ConfigComprobante), 0, config.ConfigComprobante)
        ndocumento = GetDocumento(idNumeracion, tipoEntidad)
        ndocumentoCaja = GetDocumentoCaja(idNumeracion, IDCajaUsuario_Login, tipoEntidad)
        ndocumento.documentoCaja = ndocumentoCaja
        ndocumentoCajaDetalle = GetDetalleCaja(IDCajaUsuario_Login)
        ListadocumentoCajaDetalle.Add(ndocumentoCajaDetalle)
        ndocumento.documentoCaja.documentoCajaDetalle = ListadocumentoCajaDetalle
        ndocumento.idEmpresa = Gempresas.IdEmpresaRuc
        ndocumento.idCentroCosto = GEstableciento.IdEstablecimiento
        documentoCajaSA.SaveGroupCajaOtrosMovimientosSingleME(ndocumento)

        Alert = New Alert("Ingreso registrado", alertType.success)
        Alert.TopMost = True
        Alert.Show()

        Close()
    End Sub

    Private Function GetDetalleCaja(IDCajaUsuario_Login As Integer) As documentoCajaDetalle
        Return New documentoCajaDetalle With
                {
                .fecha = New DateTime(txtAnioCompra.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, (txtHora.Value.Hour), (txtHora.Value.Minute), (txtHora.Value.Second)),
                .idItem = "00",
                .DetalleItem = TextGlosa.Text.Trim,
                .montoSoles = txtFondoMN.Value,
                .montoSolesTransacc = txtFondoMN.Value,
                .montoUsd = txtFondoME.Value,
                .montoUsdTransacc = txtFondoME.Value,
                .diferTipoCambio = txtTipoCambio.Value,
                .tipoCambioTransacc = txtTipoCambio.Value,
                .moneda = txtCF_moneda.Tag,
                .entregado = "SI",
                .documentoAfectado = 0,
                .idCajaUsuario = IDCajaUsuario_Login,
                .fechaModificacion = DateTime.Now,
                .usuarioModificacion = usuario.IDUsuario
                }
    End Function

    ''' <summary>
    ''' Mapping Tabla DocumentoCaja
    ''' </summary>
    ''' <param name="idNumeracion"></param>
    ''' <param name="IDCajaUsuario_Login"></param>
    ''' <param name="tipoEntidad"></param>
    ''' <returns></returns>
    Private Function GetDocumentoCaja(idNumeracion As Integer, IDCajaUsuario_Login As Integer, tipoEntidad As String) As documentoCaja
        Dim fechaTransaccion = New DateTime(CInt(txtAnioCompra.Text), CInt(cboMesCompra.SelectedValue), CInt(TxtDia.DecimalValue), CInt(txtHora.Value.Hour), CInt(txtHora.Value.Minute), CInt(txtHora.Value.Second))

        Select Case txtCF_tipo.Tag
            Case "EF"
                Return New documentoCaja With
                {
                .periodo = GetPeriodo(New Date(txtAnioCompra.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text), True),
                .idEmpresa = Gempresas.IdEmpresaRuc,
                .idEstablecimiento = GEstableciento.IdEstablecimiento,
                .TipoDocumentoPago = "9908",
                .formapago = cboFormaPago.SelectedValue,
                .codigoProveedor = Integer.Parse(TextDNI.Tag),
                .idPersonal = Integer.Parse(TextDNI.Tag),
                .tipoPersona = tipoEntidad,
                .codigoLibro = "1",
                .tipoDocPago = "9908",
                .numeroDoc = idNumeracion,
                .moneda = txtCF_moneda.Tag,
                .tipoMovimiento = MovimientoCaja.EntradaDinero,
                .tipoOperacion = StatusTipoOperacion.OTRAS_ENTRADAS_DE_DINERO,
                .movimientoCaja = (MovimientoCaja.Otras_Entradas),
                .entidadFinancieraDestino = txtCF_name.Tag, ' aqui guarda destino y no origen
                .numeroOperacion = txtNumOper.Text,
                .ctaIntebancaria = Nothing,
                .fechaProceso = fechaTransaccion,',New DateTime(txtAnioCompra.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, CInt(txtHora.Value.Hour), CInt(txtHora.Value.Minute), CInt(txtHora.Value.Second)),
                .fechaCobro = fechaTransaccion,'New DateTime(txtAnioCompra.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, CInt(txtHora.Value.Hour), CInt(txtHora.Value.Minute), CInt(txtHora.Value.Second)),
                .entregado = If(Chentregado.Checked, "SI", "NO"),
                .tipoCambio = txtTipoCambio.Value,
                .montoSoles = txtFondoMN.Value,
                .montoUsd = txtFondoME.Value,
                .idCajaUsuarioDestino = IDCajaUsuario_Login,
                .glosa = TextGlosa.Text.Trim,
                .estado = "N",
                .idcosto = Nothing,
                .tipoEntidadFinanciera = txtCF_tipo.Tag,
                .usuarioModificacion = usuario.IDUsuario,
                .fechaModificacion = DateTime.Now,
                .fechaProcesoDestino = fechaTransaccion,
                .idRol = usuario.IDRol,
                .IdUsuarioTransaccion = usuario.IDUsuario
                }
            Case "BC"
                Return New documentoCaja With
                {
                .periodo = GetPeriodo(New Date(txtAnioCompra.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text), True),
                .idEmpresa = Gempresas.IdEmpresaRuc,
                .idEstablecimiento = GEstableciento.IdEstablecimiento,
                .TipoDocumentoPago = "9908",
                .formapago = cboFormaPago.SelectedValue,
                .codigoProveedor = Integer.Parse(TextDNI.Tag),
                .idPersonal = Integer.Parse(TextDNI.Tag),
                .tipoPersona = tipoEntidad,
                .codigoLibro = "1",
                .tipoDocPago = "9908",
                .numeroDoc = idNumeracion,
                .moneda = txtCF_moneda.Tag,
                .tipoMovimiento = MovimientoCaja.EntradaDinero,
                .tipoOperacion = StatusTipoOperacion.OTRAS_ENTRADAS_DE_DINERO,
                .movimientoCaja = (MovimientoCaja.Otras_Entradas),
                .entidadFinancieraDestino = txtCF_name.Tag,
                .numeroOperacion = txtNumOper.Text,
                .ctaIntebancaria = Nothing,
                .fechaProceso = fechaTransaccion,',New DateTime(txtAnioCompra.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, CInt(txtHora.Value.Hour), CInt(txtHora.Value.Minute), CInt(txtHora.Value.Second)),
                .fechaCobro = fechaTransaccion,'New DateTime(txtAnioCompra.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, CInt(txtHora.Value.Hour), CInt(txtHora.Value.Minute), CInt(txtHora.Value.Second)),
                .entregado = If(Chentregado.Checked, "SI", "NO"),
                .tipoCambio = txtTipoCambio.Value,
                .montoSoles = txtFondoMN.Value,
                .montoUsd = txtFondoME.Value,
                .idCajaUsuarioDestino = IDCajaUsuario_Login,
                .glosa = TextGlosa.Text.Trim,
                .estado = "N",
                .idcosto = Nothing,
                .tipoEntidadFinanciera = txtCF_tipo.Tag,
                .usuarioModificacion = usuario.IDUsuario,
                .fechaModificacion = DateTime.Now,
                .fechaProcesoDestino = fechaTransaccion,
                .idRol = usuario.IDRol,
                .IdUsuarioTransaccion = usuario.IDUsuario
                }
            Case "EP"
                Return New documentoCaja With
                {
                .periodo = GetPeriodo(New Date(txtAnioCompra.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text), True),
                .idEmpresa = Gempresas.IdEmpresaRuc,
                .idEstablecimiento = GEstableciento.IdEstablecimiento,
                .TipoDocumentoPago = "9908",
                .formapago = cboFormaPago.SelectedValue,
                .codigoProveedor = Integer.Parse(TextDNI.Tag),
                .idPersonal = Integer.Parse(TextDNI.Tag),
                .tipoPersona = tipoEntidad,
                .codigoLibro = "1",
                .tipoDocPago = "9908",
                .numeroDoc = idNumeracion,
                .moneda = txtCF_moneda.Tag,
                .tipoMovimiento = MovimientoCaja.EntradaDinero,
                .tipoOperacion = StatusTipoOperacion.OTRAS_ENTRADAS_DE_DINERO,
                .movimientoCaja = (MovimientoCaja.Otras_Entradas),
                .entidadFinanciera = txtCF_name.Tag,
                .numeroOperacion = txtNumOper.Text,
                .ctaIntebancaria = Nothing,
                .fechaProceso = fechaTransaccion,',New DateTime(txtAnioCompra.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, CInt(txtHora.Value.Hour), CInt(txtHora.Value.Minute), CInt(txtHora.Value.Second)),
                .fechaCobro = fechaTransaccion,'New DateTime(txtAnioCompra.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, CInt(txtHora.Value.Hour), CInt(txtHora.Value.Minute), CInt(txtHora.Value.Second)),
                .entregado = If(Chentregado.Checked, "SI", "NO"),
                .tipoCambio = txtTipoCambio.Value,
                .montoSoles = txtFondoMN.Value,
                .montoUsd = txtFondoME.Value,
                .idCajaUsuario = IDCajaUsuario_Login,
                .glosa = TextGlosa.Text.Trim,
                .estado = "N",
                .idcosto = Nothing,'.tipoEntidadFinanciera = txtCF_tipo.Tag,
                .usuarioModificacion = usuario.IDUsuario,
                .fechaModificacion = DateTime.Now
                }
        End Select


    End Function

    ''' <summary>
    ''' Mapping Tabla Documento
    ''' </summary>
    ''' <param name="idNumeracion"></param>
    ''' <param name="tipoEntidad"></param>
    ''' <returns></returns>
    Private Function GetDocumento(idNumeracion As Integer, tipoEntidad As String) As documento
        Return New documento With
        {
        .idEmpresa = Gempresas.IdEmpresaRuc,
        .idCentroCosto = GEstableciento.IdEstablecimiento,
        .tipoDoc = "9908",
        .fechaProceso = New DateTime(txtAnioCompra.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, CInt(txtHora.Value.Hour), CInt(txtHora.Value.Minute), CInt(txtHora.Value.Second)),
        .nroDoc = idNumeracion,
        .idOrden = Nothing,
        .moneda = Val(txtCF_moneda.Tag),
        .tipoEntidad = tipoEntidad,
        .idEntidad = TextDNI.Tag,
        .entidad = TextPersona.Text,
        .nrodocEntidad = TextDNI.Text,
        .tipoOperacion = StatusTipoOperacion.OTRAS_ENTRADAS_DE_DINERO,
        .usuarioActualizacion = usuario.IDUsuario,
        .fechaActualizacion = DateTime.Now,
        .tipo = "OED",
        .IdPerfil = usuario.IDRol
        }
    End Function

    ''' <summary>
    ''' Recueprar persona elegida
    ''' </summary>
    ''' <param name="tipoEntidad"></param>
    ''' <returns></returns>
    Private Function GetEntidadElegida(tipoEntidad As String) As String
        If (RBProveedor.Checked = True) Then
            tipoEntidad = "PR"
        ElseIf (RBCliente.Checked = True) Then
            tipoEntidad = "CL"
        ElseIf (RBOtros.Checked = True) Then
            tipoEntidad = "TR"
        ElseIf (RBCPlanilla.Checked = True) Then
            tipoEntidad = "PL"
        ElseIf (RadioButton1.Checked = True) Then
            tipoEntidad = "VR"
        End If

        Return tipoEntidad
    End Function

    ''' <summary>
    ''' Identificar usuario de caja logueado
    ''' </summary>
    ''' <returns></returns>
    Private Shared Function GetUsuarioCaja(IDCajaUsuario As Integer) As Integer
        Dim IDCajaUsuario_Login As Integer

        If (Not IsNothing(IDCajaUsuario)) Then
            IDCajaUsuario_Login = IDCajaUsuario 'GFichaUsuarios.IdCajaUsuario
        Else
            IDCajaUsuario_Login = 0
        End If

        Return IDCajaUsuario_Login
    End Function
#End Region

#Region "Events"
    Private Sub FormRealizacionDePagos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtAnioCompra.BorderColor = Color.FromKnownColor(KnownColor.HotTrack)
        txtHora.BorderColor = Color.FromKnownColor(KnownColor.HotTrack)
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RBCliente.CheckedChanged
        If RBCliente.Checked Then
            '    GetThreadEntidades(TIPO_ENTIDAD.CLIENTE)
            TextDNI.Enabled = True
            TextDNI.Clear()
            TextPersona.Clear()
            TextPersona.Enabled = False
        End If
    End Sub

    Private Sub RBProveedor_CheckedChanged(sender As Object, e As EventArgs) Handles RBProveedor.CheckedChanged
        If RBProveedor.Checked Then
            '    GetThreadEntidades(TIPO_ENTIDAD.PROVEEDOR)
            TextDNI.Enabled = True
            TextDNI.Clear()
            TextPersona.Clear()
            TextPersona.Enabled = False
        End If
    End Sub

    Private Sub RBCPlanilla_CheckedChanged(sender As Object, e As EventArgs) Handles RBCPlanilla.CheckedChanged
        If RBCPlanilla.Checked Then
            GetThreadEntidades(TIPO_ENTIDAD.PERSONAL_PLANILLA)
        End If
    End Sub

    Private Sub RBOtros_CheckedChanged(sender As Object, e As EventArgs) Handles RBOtros.CheckedChanged
        'If RBOtros.Checked Then
        '    GetThreadEntidades(TIPO_ENTIDAD.PERSONA_GENERAL)
        'End If
    End Sub

    Private Sub TextPersona_KeyDown(sender As Object, e As KeyEventArgs) Handles TextPersona.KeyDown
        'Try
        '    If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        '    Else

        '        If RBCliente.Checked Or RBProveedor.Checked Then
        '            Dim consulta As New List(Of entidad)
        '            consulta.Add(New entidad With {.nombreCompleto = "Agregar nuevo"})
        '            '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
        '            PopupControlContainer4.Size = New Size(319, 128)
        '            PopupControlContainer4.ParentControl = Me.TextPersona
        '            PopupControlContainer4.ShowPopup(Point.Empty)
        '            Dim consulta2 = (From n In ListaEntidad
        '                             Where n.nombreCompleto.StartsWith(TextPersona.Text) Or n.nrodoc.StartsWith(TextPersona.Text)).ToList

        '            '     consulta.Add(New entidad With {.idEntidad = 0, .nombreCompleto = "Agregar nuevo"})
        '            consulta.AddRange(consulta2)

        '            FillLSVEntidades(consulta)
        '            e.Handled = True
        '        ElseIf RBOtros.Checked Then
        '            PopupControlContainer4.Size = New Size(319, 128)
        '            PopupControlContainer4.ParentControl = Me.TextPersona
        '            PopupControlContainer4.ShowPopup(Point.Empty)

        '            Dim consulta As New List(Of Persona)
        '            consulta.Add(New Persona With {.nombreCompleto = "Agregar nuevo"})
        '            Dim consulta2 = (From n In ListaTrabajadores
        '                             Where n.nombreCompleto.StartsWith(TextPersona.Text) Or n.idPersona.StartsWith(TextPersona.Text)).ToList

        '            consulta.AddRange(consulta2)

        '            FillLSVPersonas(consulta)
        '            e.Handled = True
        '        End If
        '    End If

        '    If e.KeyCode = Keys.Down Then
        '        '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
        '        Me.PopupControlContainer4.Size = New Size(319, 128)
        '        Me.PopupControlContainer4.ParentControl = Me.TextPersona
        '        Me.PopupControlContainer4.ShowPopup(Point.Empty)
        '        lsvProveedor.Focus()
        '    End If
        '    '   End If

        '    ' e.SuppressKeyPress = True
        '    If e.KeyCode = Keys.Escape Then
        '        If Me.PopupControlContainer4.IsShowing() Then
        '            Me.PopupControlContainer4.HidePopup(PopupCloseType.Canceled)
        '        End If
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub

    Private Sub PopupControlContainer4_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles PopupControlContainer4.CloseUp
        Me.Cursor = Cursors.WaitCursor

        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvProveedor.SelectedItems.Count > 0 Then
                If lsvProveedor.SelectedItems(0).SubItems(1).Text = "Agregar nuevo" Then
                    If RBProveedor.Checked Then
                        Dim f As New frmCrearENtidades
                        f.CaptionLabels(0).Text = "Nuevo proveedor"
                        f.strTipo = TIPO_ENTIDAD.PROVEEDOR
                        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        'f.tipoPersona(TIPO_ENTIDAD.CLIENTE)
                        f.StartPosition = FormStartPosition.CenterParent
                        f.ShowDialog()
                        If Not IsNothing(f.Tag) Then
                            Dim c = CType(f.Tag, entidad)
                            ListaEntidad.Add(c)
                            TextPersona.Text = c.nombreCompleto
                            TextDNI.Text = c.nrodoc
                            TextPersona.Tag = c.idEntidad
                            TextDNI.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                            TextDNI.Visible = True
                            TextPersona.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        End If
                    ElseIf RBCliente.Checked Then
                        Dim f As New frmCrearENtidades
                        f.CaptionLabels(0).Text = "Nuevo cliente"
                        f.strTipo = TIPO_ENTIDAD.CLIENTE
                        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        'f.tipoPersona(TIPO_ENTIDAD.CLIENTE)
                        f.StartPosition = FormStartPosition.CenterParent
                        f.ShowDialog()
                        If Not IsNothing(f.Tag) Then
                            Dim c = CType(f.Tag, entidad)
                            ListaEntidad.Add(c)
                            TextPersona.Text = c.nombreCompleto
                            TextDNI.Text = c.nrodoc
                            TextPersona.Tag = c.idEntidad
                            TextDNI.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                            TextDNI.Visible = True
                            TextPersona.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        End If
                    ElseIf RBOtros.Checked Then
                        Dim f As New FrmNuevaPersona()
                        f.StartPosition = FormStartPosition.CenterParent
                        f.ShowDialog()
                        If f.Tag IsNot Nothing Then
                            Dim c = CType(f.Tag, Persona)
                            c.idPersona = c.idPersona
                            TextPersona.Text = c.nombreCompleto
                            TextPersona.Tag = c.idPersona
                            TextDNI.Visible = True
                            TextDNI.Text = c.idPersona
                            TextDNI.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                            TextPersona.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                            ListaTrabajadores.Add(c)
                        End If
                    End If
                Else
                    TextPersona.Text = lsvProveedor.SelectedItems(0).SubItems(1).Text
                    TextPersona.Tag = lsvProveedor.SelectedItems(0).SubItems(0).Text
                    TextPersona.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                    TextDNI.Text = lsvProveedor.SelectedItems(0).SubItems(2).Text
                    TextDNI.Visible = True
                End If
                'ListaMercaderiasXIdHijo(Val(txtSubCategoria.Tag), cboTipoExistencia.SelectedValue)
            End If
        End If

        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            TextPersona.Focus()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvProveedor.MouseDoubleClick
        If lsvProveedor.SelectedItems.Count > 0 Then
            PopupControlContainer4.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub TextPersona_TextChanged(sender As Object, e As EventArgs) Handles TextPersona.TextChanged
        'TextPersona.ForeColor = Color.Black
        'TextPersona.Tag = Nothing
        'If TextPersona.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
        '    TextDNI.Visible = True
        'Else
        '    TextDNI.Visible = False
        'End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Try


            If TxtDia.Text.Trim.Length = 0 Then
                MessageBox.Show("Debe ingresar la fecha de registro", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TxtDia.Select()
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            Dim fechaActual As DateTime = New DateTime(txtAnioCompra.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, CInt(txtHora.Value.Hour), CInt(txtHora.Value.Minute), CInt(txtHora.Value.Second)) ' Format(Now, txtAnioCompra.Text & "-" & cboMesCompra.SelectedValue & "-" & txtDia.text)

            Dim User As cajaUsuario

            If usuario.tipoCaja = Tipo_Caja.ADMINISTRATIVO Then

                User = (From i In ListaCajasActivas Where i.tipoCaja = Tipo_Caja.GENERAL And i.estadoCaja = "A").FirstOrDefault
            ElseIf usuario.tipoCaja = Tipo_Caja.PUNTO_DE_VENTA Then

                User = (From i In ListaCajasActivas Where i.idPersona = usuario.IDUsuario And i.IDRol = usuario.IDRol).FirstOrDefault

            End If






            If User IsNot Nothing Then
                frmSeleccionCuentaFinanciera = New frmSeleccionCuentaFinanciera
                frmSeleccionCuentaFinanciera.txtPeriodo.Value = fechaActual
                'frmSeleccionCuentaFinanciera.GetCuentasFinancieras("CUENTAS EN EFECTIVO")
                frmSeleccionCuentaFinanciera.StartPosition = FormStartPosition.CenterParent
                frmSeleccionCuentaFinanciera.ShowDialog()
                If frmSeleccionCuentaFinanciera.Tag IsNot Nothing Then
                    txtFondoMN.Value = 0
                    txtFondoME.Value = 0
                    txtNumOper.Clear()
                    SaldoEFME.DoubleValue = 0
                    SaldoEFMN.DoubleValue = 0

                    Dim c = CType(frmSeleccionCuentaFinanciera.Tag, estadosFinancieros)
                    Select Case c.tipo
                        Case "EF"
                            txtCF_tipo.Tag = c.tipo
                            txtCF_tipo.Text = "CUENTA EN EFECTIVO"
                            GetThreadTablas("EF")
                        Case "EP"
                            txtCF_tipo.Tag = c.tipo
                            txtCF_tipo.Text = "CUENTA EN EFECTIVO POS"
                            GetThreadTablas("EF")
                        Case "BC"
                            txtCF_tipo.Tag = c.tipo
                            txtCF_tipo.Text = "CUENTAS EN BANCO"
                            GetThreadTablas("BC")
                        Case "TC"
                            txtCF_tipo.Tag = c.tipo
                            txtCF_tipo.Text = "TARJETA DE CREDITO"
                            GetThreadTablas("TC")
                    End Select

                    Select Case c.codigo
                        Case 1
                            txtCF_moneda.Tag = c.codigo
                            txtCF_moneda.Text = "NACIONAL"

                            txtFondoMN.Enabled = True
                            txtTipoCambio.Enabled = False
                            txtTipoCambio.Value = 1
                            txtFondoME.Enabled = False

                            txtFondoMN.Select()
                        Case 2
                            txtCF_moneda.Tag = c.codigo
                            txtCF_moneda.Text = "EXTRANJERA"

                            txtFondoMN.Enabled = False
                            txtTipoCambio.Enabled = True
                            txtTipoCambio.Value = 1
                            txtFondoME.Enabled = True

                            txtFondoME.Select()
                    End Select

                    txtCF_name.Text = c.descripcion
                    txtCF_name.Tag = c.idestado
                    txtCF_cuentaContable.Text = c.cuenta
                    SaldoEFMN.DoubleValue = c.importeBalanceMN.GetValueOrDefault
                    SaldoEFME.DoubleValue = 0
                End If
            Else
                MessageBox.Show("No tiene una caja activa")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub txtFondoMN_Click(sender As Object, e As EventArgs) Handles txtFondoMN.Click
        txtFondoMN.Select(0, txtFondoMN.Text.Length)
    End Sub

    Sub GetDiasMes(mes As Integer, anio As Integer)
        Dim days As Integer = System.DateTime.DaysInMonth(anio, mes)
        TxtDia.MaxValue = days
        TxtDia.MinValue = 1

    End Sub

    Private Sub TxtDia_TextChanged(sender As Object, e As EventArgs) Handles TxtDia.TextChanged
        If cboMesCompra.Text.Trim.Length > 0 Then
            txtCF_tipo.Clear()
            txtCF_name.Clear()
            txtCF_moneda.Clear()
            txtCF_cuentaContable.Clear()
            SaldoEFMN.DoubleValue = 0
            SaldoEFME.DoubleValue = 0
        End If
    End Sub

    Private Sub cboMesCompra_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboMesCompra.SelectedValueChanged
        If Not IsNothing(cboMesCompra.SelectedValue) Then
            If TxtDia.Text.Trim.Length > 0 Then
                GetDiasMes(Integer.Parse(cboMesCompra.SelectedValue), txtAnioCompra.Text)
            Else
                GetDiasMes(Integer.Parse(cboMesCompra.SelectedValue), txtAnioCompra.Text)
                TxtDia.Clear()
            End If
            TxtDia_TextChanged(sender, e)
        End If
    End Sub

    Private Sub txtFondoMN_ValueChanged(sender As Object, e As EventArgs) Handles txtFondoMN.ValueChanged
        Select Case txtCF_moneda.Tag
            Case 1
                Calculo()
        End Select
    End Sub

    Private Sub RoundButton21_Click(sender As Object, e As EventArgs) Handles RoundButton21.Click
        Try
            If ValidarGrabado() = True Then
                Grabar()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Atención!")
        End Try
    End Sub

    Private Sub lsvProveedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvProveedor.SelectedIndexChanged

    End Sub

    Private Sub FormRealizacionDePagos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If threadTablas IsNot Nothing Then
            threadTablas.Abort()
        End If
        If threadEntidades IsNot Nothing Then
            threadEntidades.Abort()
        End If

    End Sub

    Private Sub RadioButton1_CheckedChanged_1(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked Then
            TextDNI.Enabled = False
            TextPersona.Text = VarClienteGeneral.nombreCompleto
            TextPersona.Tag = VarClienteGeneral.idEntidad
            TextDNI.Text = VarClienteGeneral.nrodoc
            TextPersona.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            TextDNI.Tag = VarClienteGeneral.idEntidad
        End If
    End Sub

    Private Sub Chentregado_CheckedChanged(sender As Object, e As EventArgs) Handles Chentregado.CheckedChanged

    End Sub

    Private Sub TextDNI_TextChanged(sender As Object, e As EventArgs) Handles TextDNI.TextChanged

    End Sub

    Private Sub TextDNI_KeyDown(sender As Object, e As KeyEventArgs) Handles TextDNI.KeyDown
        Dim nombres = String.Empty
        Dim existeEnDB As Object = Nothing
        Try
            'TextNumIdentrazon.Enabled = False
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True

                Select Case TextDNI.Text.Trim.Length
                    Case 8 'dni

                        SelRazon = New entidad

                        If My.Computer.Network.IsAvailable = True Then
                            PictureLoad.Visible = True
                            nombres = GetConsultarDNIReniec(TextDNI.Text.Trim)

                            If nombres.Trim.Length > 0 Then

                                If nombres = "DNI no encontrado en Padrón Electoral" Then
                                    TextDNI.Clear()
                                    TextPersona.Text = String.Empty
                                    TextPersona.Tag = Nothing
                                    PictureLoad.Visible = False
                                    Exit Sub
                                End If


                                SelRazon.nombreCompleto = nombres
                                SelRazon.nrodoc = TextDNI.Text.Trim
                                SelRazon.tipoDoc = "1"
                                SelRazon.tipoPersona = "N"
                                TextPersona.Text = nombres


                                If RBCliente.Checked = True Then
                                    SelRazon.tipoEntidad = "CL"
                                    existeEnDB = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", TextDNI.Text.Trim)
                                ElseIf RBProveedor.Checked = True Then
                                    SelRazon.tipoEntidad = "PR"
                                    existeEnDB = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "PR", TextDNI.Text.Trim)
                                End If

                                If existeEnDB Is Nothing Then
                                    TextDNI.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    If RBCliente.Checked = True Then
                                        GrabarEntidadRapida("CL")
                                    ElseIf RBProveedor.Checked = True Then
                                        GrabarEntidadRapida("PR")
                                    End If

                                    PictureLoad.Visible = False
                                Else
                                    TextDNI.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    TextDNI.Tag = existeEnDB.idEntidad

                                    TextGlosa.Focus()
                                    TextGlosa.Select()

                                End If
                            Else
                                TextDNI.Clear()
                                TextPersona.Text = String.Empty
                                TextPersona.Tag = Nothing
                            End If
                            PictureLoad.Visible = False
                        Else

                            'CUANDO NO HAY CONEXION A INTERNET
                            If RBCliente.Checked = True Then
                                existeEnDB = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", TextDNI.Text.Trim)
                            ElseIf RBProveedor.Checked = True Then
                                existeEnDB = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "PR", TextDNI.Text.Trim)
                            End If
                            If existeEnDB Is Nothing Then
                                If RBCliente.Checked = True Then
                                    SelRazon.tipoEntidad = "CL"
                                ElseIf RBProveedor.Checked = True Then
                                    SelRazon.tipoEntidad = "PR"
                                End If
                                SelRazon.nombreCompleto = TextPersona.Text.Trim
                                SelRazon.nrodoc = TextDNI.Text.Trim
                                SelRazon.tipoDoc = "1"
                                SelRazon.tipoPersona = "N"
                                'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                'GrabarEntidadRapida()
                                GrabarEnFormBasico()
                                PictureLoad.Visible = False
                            Else
                                TextPersona.Text = existeEnDB.nombreCompleto
                                TextPersona.Tag = existeEnDB.idEntidad
                                TextPersona.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)

                                TextGlosa.Focus()
                                TextGlosa.Select()
                            End If
                        End If



                    Case 11 'razonSocial
                        PictureLoad.Visible = True
                        Dim objeto As Boolean = ValidationRUC(TextDNI.Text.Trim)
                        If objeto = False Then
                            PictureLoad.Visible = False
                            MessageBox.Show("Debe Ingresar un número correcto de ruc", "Ingresar identificación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Cursor = Cursors.Default
                            TextPersona.Clear()
                            Exit Sub
                        End If

                        If My.Computer.Network.IsAvailable = True Then
                            'VALIDAR SI EXISTE EN LA bd LOCAL PRIMERO 
                            If GetValidarLocalDB(TextDNI.Text.Trim) = False Then
                                TextDNI.ReadOnly = True

                                Select Case ToggleConsultas.ToggleState
                                    Case ToggleButton2.ToggleButtonState.OFF ' API
                                        If RBCliente.Checked = True Then
                                            GetConsultaSunatAsync(TextDNI.Text.Trim, "CL")
                                        ElseIf RBProveedor.Checked = True Then
                                            GetConsultaSunatAsync(TextDNI.Text.Trim, "PR")
                                        End If
                                    Case ToggleButton2.ToggleButtonState.ON ' WEB
                                        BgProveedor.RunWorkerAsync()
                                End Select
                            End If
                        Else
                            'SI NO HAY CONEXION A INTERNET
                            If GetValidarLocalDB(TextDNI.Text.Trim) = False Then
                                Dim nroDoc = TextDNI.Text.Trim.Substring(0, 1).ToString
                                If nroDoc = "1" Then
                                    'SelRazon.tipoEntidad = "CL"
                                    'SelRazon.nombreCompleto = TextEmpresaPasajero.Text.Trim
                                    'SelRazon.nrodoc = TextNumIdentrazon.Text.Trim
                                    'SelRazon.tipoDoc = "6"
                                    'SelRazon.tipoPersona = "N"
                                    'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    'GrabarEntidadRapida()
                                    GrabarEnFormBasico()
                                    PictureLoad.Visible = False
                                    If TextPersona.Text.Trim.Length > 0 Then
                                        TextGlosa.Select()
                                        TextGlosa.Focus()
                                    Else
                                        TextDNI.Clear()
                                        TextDNI.Select()
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
                                    PictureLoad.Visible = False
                                    If TextPersona.Text.Trim.Length > 0 Then
                                        TextGlosa.Select()
                                        TextGlosa.Focus()
                                    Else
                                        TextDNI.Clear()
                                        TextDNI.Select()
                                    End If
                                End If
                            End If
                        End If

                    Case Else
                        TextPersona.Text = String.Empty
                        TextDNI.Text = String.Empty
                        MessageBox.Show("Ingrese un documento correcto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Select

            End If
            '    TextNumIdentrazon.Enabled = True

        Catch ew As WebException

            If ew.Status = WebExceptionStatus.ProtocolError Then
                PictureLoad.Visible = False
                Dim [error] As String = New System.IO.StreamReader(ew.Response.GetResponseStream()).ReadToEnd()
                MessageBox.Show("DNI no encontrado en el padron, verifique si es menor de edad")
                TextPersona.Clear()
                TextDNI.Clear()
                TextDNI.Select()
                TextDNI.Focus()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
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

            TextPersona.Tag = codx
            Dim entidad As New entidad
            entidad.idEntidad = codx
            entidad.nrodoc = TextDNI.Text.Trim
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

    Private Sub BgProveedor_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BgProveedor.DoWork
        GetConsultaSunatThread(TextDNI.Text)
    End Sub

    Private Sub BgProveedor_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgProveedor.RunWorkerCompleted
        If SelRazon.nrodoc IsNot Nothing Then
            SelRazon.tipoEntidad = "CL"
            SelRazon.nombreCompleto = SelRazon.nombreCompleto.ToString.Replace(Chr(34), "")
            GrabarEntidadRapidaThread()
            TextDNI.Text = SelRazon.nrodoc
            TextPersona.Text = SelRazon.nombreCompleto
            TextDNI.ReadOnly = False
            SelRazon = New entidad
            TextGlosa.Select()

        Else
            TextPersona.Clear()
            TextPersona.Tag = Nothing
            TextDNI.ReadOnly = False
            SelRazon = New entidad
            TextDNI.Select()
        End If
        PictureLoad.Visible = False
    End Sub

    Private Sub CboMesCompra_Click(sender As Object, e As EventArgs) Handles cboMesCompra.Click

    End Sub

    Private Sub TxtFondoME_ValueChanged(sender As Object, e As EventArgs) Handles txtFondoME.ValueChanged
        txtFondoMN.Value = Math.Round(txtFondoME.Value * txtTipoCambio.Value, 2)
    End Sub

    Private Sub TxtTipoCambio_ValueChanged(sender As Object, e As EventArgs) Handles txtTipoCambio.ValueChanged
        Select Case txtCF_moneda.Tag
            Case 2
                txtFondoMN.Value = Math.Round(txtFondoME.Value * txtTipoCambio.Value, 2)
        End Select
    End Sub

#End Region

End Class