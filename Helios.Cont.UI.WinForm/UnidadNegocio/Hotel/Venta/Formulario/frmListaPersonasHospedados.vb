Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Drawing
Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping
Imports System.ComponentModel
Imports System.Threading
Imports ProcesosGeneralesCajamiSoft
Imports System.Net
Imports System.IO

Public Class frmListaPersonasHospedados
    Inherits frmMaster

    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
    Private Thread As Thread
    Public Property IdTipoServicio As Integer
    Private Property SelRazon As entidad
    Private Property entidadSA As New entidadSA
    Public listaProductos As New List(Of personaBeneficio)

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Sub New(listaPersona As List(Of personaBeneficio))

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.KeyPreview = True
        AgregarCanastaPrincipal(listaPersona)
    End Sub

#Region "Metodo"

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData

            Case Keys.Escape
                Close()
            Case Else
                'Do Nothing
        End Select

        Return MyBase.ProcessCmdKey(msg, keyData)
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

    Private Sub BgProveedor_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgProveedor.RunWorkerCompleted

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

    Private Function GetConsultarDNIReniec(Dni As String) As String
        Dim CLIENTE As New WebClient
        Dim PAGINA As Stream = CLIENTE.OpenRead("http://aplicaciones007.jne.gob.pe/srop_publico/Consulta/Afiliado/GetNombresCiudadano?DNI=" & Dni)
        Dim LECTOR As New StreamReader(PAGINA)
        Dim MIHTML As String = LECTOR.ReadToEnd
        ' Dim array = MIHTML.Split("|")

        Dim nombres = MIHTML.Replace("|", Space(1))
        Return Trim(nombres)
    End Function

    Private Function GetValidarLocalDB(idEntidad As String) As Boolean
        GetValidarLocalDB = False
        Dim entidadSA As New entidadSA

        Dim entidad = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", idEntidad)
        If entidad IsNot Nothing Then
            SelRazon = New entidad
            SelRazon = entidad
            TextProveedor.Text = entidad.nombreCompleto
            TextProveedor.Tag = entidad.idEntidad
            GetValidarLocalDB = True
            PictureLoad.Visible = False

            If TextProveedor.Text.Trim.Length > 0 Then
                'TextFiltrar.Select()
                'TextFiltrar.Focus()
            Else
                TextNumIdentrazon.Clear()
                TextNumIdentrazon.Select()
            End If
        End If
    End Function

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

    Private Async Sub GetConsultaSunatAsync(ruc As String)
        SelRazon = New entidad
        Dim nroDoc = ruc.Substring(0, 1).ToString
        If nroDoc = "1" Then
            Dim company = CType(Await SoftPackERP_Sunat.GetRucContribuyenteSPK.GetContribuyente(ruc), SoftPackERP_Sunat.CompanyJuridico)
            If company IsNot Nothing Then
                If company.ContribuyenteTipo = "PERSONA NATURAL SIN NEGOCIO" Then
                    SelRazon.tipoPersona = "N"
                    SelRazon.tipoDoc = "6"
                End If
                SelRazon.tipoEntidad = "CL"
                SelRazon.nombreCompleto = company.RazonSocial
                TextProveedor.Text = company.RazonSocial
                SelRazon.nombreContacto = company.RazonSocial
                SelRazon.estado = company.ContribuyenteEstado
                SelRazon.nrodoc = company.Ruc
                SelRazon.direccion = company.DomicilioFiscal
                GrabarEntidadRapida()
                PictureLoad.Visible = False
            Else
                TextProveedor.Clear()
                PictureLoad.Visible = False
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
                PictureLoad.Visible = False
            Else
                TextProveedor.Clear()
                PictureLoad.Visible = False
            End If
        End If

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
        Else
            TextNumIdentrazon.Text = String.Empty
            TextProveedor.Text = String.Empty
            TextProveedor.Tag = Nothing
        End If
    End Sub

    Public Sub AgregarEntidad()
        Try
            Dim obj As New personaBeneficio

            If (TextNumIdentrazon.Text.Length > 0 And TextProveedor.Text.Length > 0) Then

                obj = New personaBeneficio
                obj.idPersonaBeneficio = TextProveedor.Tag
                obj.idEmpresa = Gempresas.IdEmpresaRuc
                obj.idEstablecimiento = GEstableciento.IdEstablecimiento
                obj.nroDocumento = TextNumIdentrazon.Text
                obj.nombrePersona = TextProveedor.Text
                obj.nacionalidad = ""
                obj.sexo = ""
            Else
                obj = New personaBeneficio
                obj.idPersonaBeneficio = 0
                obj.idEmpresa = Gempresas.IdEmpresaRuc
                obj.idEstablecimiento = GEstableciento.IdEstablecimiento
                obj.nroDocumento = 0
                obj.nombrePersona = ""
                obj.nacionalidad = ""
                obj.sexo = ""
            End If

            listaProductos.Add(obj)
            AgregarCanasta(listaProductos)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub AgregarCanasta(listaProductos As List(Of personaBeneficio))
        Dim dt As New DataTable
        Dim conteo As Integer = 1

        dt.Columns.Add("idComponente") '0
        dt.Columns.Add("numero")
        dt.Columns.Add("dni") '2
        dt.Columns.Add("nombre")
        dt.Columns.Add("nacionalidad")
        dt.Columns.Add("sexo")

        For Each i In listaProductos
            dt.Rows.Add(i.idPersonaBeneficio,
                    conteo,
                    i.nroDocumento,
                    i.nombrePersona,
                    i.nacionalidad,
                    i.sexo
                   )
            conteo = conteo + 1
        Next

        dgvCompras.DataSource = dt
        dgvCompras.Refresh()
    End Sub

    Private Sub AgregarCanastaPrincipal(listaProductos As List(Of personaBeneficio))
        Dim dt As New DataTable
        Dim conteo As Integer = 1
        Dim obj As New personaBeneficio
        listaProductos = New List(Of personaBeneficio)
        dt.Columns.Add("idComponente") '0
        dt.Columns.Add("numero")
        dt.Columns.Add("dni") '2
        dt.Columns.Add("nombre")
        dt.Columns.Add("nacionalidad")
        dt.Columns.Add("sexo")

        For Each i In listaProductos
            dt.Rows.Add(i.idPersonaBeneficio,
                    conteo,
                    i.nroDocumento,
                    i.nombrePersona,
                    i.nacionalidad,
                    i.sexo
                   )
            conteo = conteo + 1

            obj = New personaBeneficio
            obj.idPersonaBeneficio = i.idPersonaBeneficio
            obj.idEmpresa = Gempresas.IdEmpresaRuc
            obj.idEstablecimiento = GEstableciento.IdEstablecimiento
            obj.nroDocumento = i.nroDocumento
            obj.nombrePersona = i.nombrePersona
            obj.nacionalidad = i.nacionalidad
            obj.sexo = i.sexo
            listaProductos.Add(obj)
        Next

        dgvCompras.DataSource = dt
        dgvCompras.Refresh()
    End Sub

#End Region

    Public Sub cargarDatos()
        FormatoGridAvanzado(dgvCompras, True, False, 9.0F, SelectionMode.MultiExtended)
        Dim empresa As String = Gempresas.IdEmpresaRuc

        Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() CargarCategoria()))
        Thread.Start()
    End Sub

    Private Sub CargarCategoria()
        Try

            Dim distribucionTipoServicioBE As New distribucionTipoServicio
            Dim distribucionTipoServicioSA As New distribucionTipoServicioSA
            Dim listadistribucionTipoServicio As New List(Of distribucionTipoServicio)

            distribucionTipoServicioBE.idTipoServicio = IdTipoServicio
            listadistribucionTipoServicio = distribucionTipoServicioSA.GetUbicarDistribucionTipoServicio(distribucionTipoServicioBE)

            Dim dt As New DataTable
            With dt.Columns
                .Add("idComponente")
                .Add("numero")
                .Add("descripcionItem")
                .Add("estado")
            End With

            For Each i In listadistribucionTipoServicio
                Dim dr As DataRow = dt.NewRow()
                dr(0) = i.idTipoServicio
                dr(1) = ""
                dr(2) = i.idDistribucionTipoServicio
                dr(3) = i.estado
                dt.Rows.Add(dr)
            Next
            setDatasource(dt)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub setDatasource(ByVal table As DataTable)
        If Me.InvokeRequired Then
            Dim deleg As New SetDataSourceDelegate(AddressOf setDatasource)
            Invoke(deleg, New Object() {table})
        Else
            dgvCompras.DataSource = table
        End If
    End Sub

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
                            nombres = GetConsultarDNIReniec(TextNumIdentrazon.Text.Trim)

                            If nombres.Trim.Length > 0 Then

                                If nombres = "DNI no encontrado en Padrón Electoral" Then
                                    TextNumIdentrazon.Clear()
                                    TextProveedor.Text = String.Empty
                                    TextProveedor.Tag = Nothing
                                    PictureLoad.Visible = False
                                    Exit Sub
                                End If

                                SelRazon.tipoEntidad = "CL"
                                SelRazon.nombreCompleto = nombres
                                SelRazon.nrodoc = TextNumIdentrazon.Text.Trim
                                SelRazon.tipoDoc = "1"
                                SelRazon.tipoPersona = "N"
                                TextProveedor.Text = nombres

                                Dim existeEnDB = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", TextNumIdentrazon.Text.Trim)

                                If existeEnDB Is Nothing Then
                                    TextProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    GrabarEntidadRapida()
                                    PictureLoad.Visible = False
                                Else
                                    TextProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    TextProveedor.Tag = existeEnDB.idEntidad

                                    'TextFiltrar.Focus()
                                    'TextFiltrar.Select()

                                End If
                            Else
                                TextNumIdentrazon.Clear()
                                TextProveedor.Text = String.Empty
                                TextProveedor.Tag = Nothing
                            End If
                            PictureLoad.Visible = False
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
                                PictureLoad.Visible = False
                            Else
                                TextProveedor.Text = existeEnDB.nombreCompleto
                                TextProveedor.Tag = existeEnDB.idEntidad
                                TextProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)

                                'TextFiltrar.Focus()
                                'TextFiltrar.Select()

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
                                TextNumIdentrazon.ReadOnly = True
                                BgProveedor.RunWorkerAsync()
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
                                    PictureLoad.Visible = False
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
                                    PictureLoad.Visible = False
                                    If TextProveedor.Text.Trim.Length > 0 Then
                                        'TextFiltrar.Select()
                                        'TextFiltrar.Focus()
                                    Else
                                        TextNumIdentrazon.Clear()
                                        TextNumIdentrazon.Select()
                                    End If
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
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BunifuFlatButton17_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton17.Click
        Try
            If (TextNumIdentrazon.Text <> "VARIOS") Then
                AgregarEntidad()
                TextNumIdentrazon.Clear()
                TextProveedor.Clear()
                TextNumIdentrazon.Focus()
                TextNumIdentrazon.Select()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BunifuFlatButton2_Click_1(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click
        Try
            Dim entidad As personaBeneficio
            Dim ListaEntidad As New List(Of personaBeneficio)

            If (dgvCompras.Table.Records.Count > 0) Then
                For Each item In dgvCompras.Table.Records
                    entidad = New personaBeneficio
                    entidad.idEntidad = CInt(item.GetValue("idComponente"))
                    entidad.nombrePersona = item.GetValue("nombre")
                    entidad.nacionalidad = item.GetValue("nacionalidad")
                    entidad.sexo = item.GetValue("sexo")
                    entidad.nroDocumento = CInt(item.GetValue("dni"))

                    ListaEntidad.Add(entidad)
                Next
            End If

            Me.Tag = ListaEntidad
            Hide()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        Dispose()
    End Sub

    Private Sub FrmListaPersonasHospedados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim listaMeses As New List(Of MesesAnio)
        Dim obj As New MesesAnio

        obj = New MesesAnio
        obj.Codigo = "M"
        obj.Mes = "MASCULINO"
        listaMeses.Add(obj)

        obj = New MesesAnio
        obj.Codigo = "F"
        obj.Mes = "FEMENINO"
        listaMeses.Add(obj)

        Dim ggcStyle As GridTableCellStyleInfo = dgvCompras.TableDescriptor.Columns(5).Appearance.AnyRecordFieldCell
        ggcStyle.CellType = "ComboBox"
        ggcStyle.DataSource = listaMeses
        ggcStyle.ValueMember = "Codigo"
        ggcStyle.DisplayMember = "Mes"
        ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive


        listaMeses = New List(Of MesesAnio)
        obj = New MesesAnio
        obj.Codigo = "EXT"
        obj.Mes = "EXTRANJERO"
        listaMeses.Add(obj)

        obj = New MesesAnio
        obj.Codigo = "NAC"
        obj.Mes = "PERUANO"
        listaMeses.Add(obj)

        Dim ggcStyle2 As GridTableCellStyleInfo = dgvCompras.TableDescriptor.Columns(4).Appearance.AnyRecordFieldCell
        ggcStyle2.CellType = "ComboBox"
        ggcStyle2.DataSource = listaMeses
        ggcStyle2.ValueMember = "Codigo"
        ggcStyle2.DisplayMember = "Mes"
        ggcStyle2.DropDownStyle = GridDropDownStyle.Exclusive
    End Sub

    Private Sub DgvCompras_TableControlCurrentCellChanged(sender As Object, e As GridTableControlEventArgs) Handles dgvCompras.TableControlCurrentCellChanged
        Dim cc As GridCurrentCell = dgvCompras.TableControl.CurrentCell
        cc.ConfirmChanges()
        If Not IsNothing(cc) Then
            Select Case cc.ColIndex

                Case 3
                    Dim entidadBE As personaBeneficio
                    listaProductos = New List(Of personaBeneficio)

                    If (dgvCompras.Table.Records.Count > 0) Then
                        For Each item In dgvCompras.Table.Records
                            entidadBE = New personaBeneficio
                            entidadBE.idPersonaBeneficio = CInt(item.GetValue("idComponente"))
                            entidadBE.nombrePersona = item.GetValue("nombre")
                            entidadBE.nacionalidad = item.GetValue("nacionalidad")
                            entidadBE.sexo = item.GetValue("sexo")
                            entidadBE.nroDocumento = CInt(item.GetValue("dni"))

                            listaProductos.Add(entidadBE)
                        Next
                    End If
                Case 2
                    Dim entidadBE As personaBeneficio
                    listaProductos = New List(Of personaBeneficio)

                    If (dgvCompras.Table.Records.Count > 0) Then
                        For Each item In dgvCompras.Table.Records
                            entidadBE = New personaBeneficio
                            entidadBE.idPersonaBeneficio = CInt(item.GetValue("idComponente"))
                            entidadBE.nombrePersona = item.GetValue("nombre")
                            entidadBE.nacionalidad = item.GetValue("nacionalidad")
                            entidadBE.sexo = item.GetValue("sexo")
                            entidadBE.nroDocumento = CInt(item.GetValue("dni"))

                            listaProductos.Add(entidadBE)
                        Next
                    End If
                Case 4 ' nacionalidad
                    Dim entidadBE As personaBeneficio
                    listaProductos = New List(Of personaBeneficio)

                    If (dgvCompras.Table.Records.Count > 0) Then
                        For Each item In dgvCompras.Table.Records
                            entidadBE = New personaBeneficio
                            entidadBE.idPersonaBeneficio = CInt(item.GetValue("idComponente"))
                            entidadBE.nombrePersona = item.GetValue("nombre")
                            entidadBE.nacionalidad = item.GetValue("nacionalidad")
                            entidadBE.sexo = item.GetValue("sexo")
                            entidadBE.nroDocumento = CInt(item.GetValue("dni"))

                            listaProductos.Add(entidadBE)
                        Next
                    End If
                Case 5 ' sexo
                    Dim entidadBE As personaBeneficio
                    listaProductos = New List(Of personaBeneficio)

                    If (dgvCompras.Table.Records.Count > 0) Then
                        For Each item In dgvCompras.Table.Records
                            entidadBE = New personaBeneficio
                            entidadBE.idPersonaBeneficio = CInt(item.GetValue("idComponente"))
                            entidadBE.nombrePersona = item.GetValue("nombre")
                            entidadBE.nacionalidad = item.GetValue("nacionalidad")
                            entidadBE.sexo = item.GetValue("sexo")
                            entidadBE.nroDocumento = CInt(item.GetValue("dni"))

                            listaProductos.Add(entidadBE)
                        Next
                    End If
                Case 6
                    Dim entidadBE As personaBeneficio
                    listaProductos = New List(Of personaBeneficio)

                    If (dgvCompras.Table.Records.Count > 0) Then
                        For Each item In dgvCompras.Table.Records
                            entidadBE = New personaBeneficio
                            entidadBE.idPersonaBeneficio = CInt(item.GetValue("idComponente"))
                            entidadBE.nombrePersona = item.GetValue("nombre")
                            entidadBE.nacionalidad = item.GetValue("nacionalidad")
                            entidadBE.sexo = item.GetValue("sexo")
                            entidadBE.nroDocumento = CInt(item.GetValue("dni"))

                            listaProductos.Add(entidadBE)
                        Next
                    End If
            End Select
        End If

    End Sub

    Private Sub BunifuFlatButton4_Click_1(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
        Try

            If (Not IsNothing(dgvCompras.Table.CurrentRecord)) Then
                Dim codigo = dgvCompras.Table.CurrentRecord.GetValue("dni")
                Dim item = listaProductos.Where(Function(o) o.nroDocumento = codigo).SingleOrDefault
                If item IsNot Nothing Then
                    listaProductos.Remove(item)
                    dgvCompras.Table.CurrentRecord.Delete()
                Else
                    MessageBox.Show("Debe seleccionar un item válido!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Debe seleccionar un item válido!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub FrmListaPersonasHospedados_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

    End Sub
End Class