Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports HtmlAgilityPack
Imports ProcesosGeneralesCajamiSoft
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Helios.General.Constantes
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class FormCrearEncomiendaV2

#Region "Attributes"
    Dim thread As System.Threading.Thread
    'Public Property listaClientes As List(Of entidad)
    Friend Delegate Sub SetDataSourceDelegate(ByVal lista As List(Of Persona))
    Friend Delegate Sub SetDataSourceDelegateEntidad(ByVal lista As List(Of entidad))
    Dim entidadSA As New entidadSA
    Dim PersonaSA As New PersonaSA
    ' Public Property listaPersonas As List(Of Persona)
    'Dim listaAgencias As List(Of centrocosto)

    Dim conf As New GConfiguracionModulo
    Public Property FormInHerits As UCEncomiendas

    Public QR As String
    Public HASH As String
    Public CERTIFICADO As String
    Private Const FormatoFecha As String = "yyyy-MM-dd"
    Public objDatosGenrales As New datosGenerales
    Dim listaDatos As New List(Of datosGenerales)
#End Region

#Region "Constructors"
    Public Sub New(Form As UCEncomiendas)

        ' This call is required by the designer.
        InitializeComponent()
        TextNumIdentrazon.ReadOnly = False
        ' Add any initialization after the InitializeComponent() call.
        FormInHerits = Form
        FormatoGridAvanzado(GridEncomiendas, False, False, 10.0F)
        FormatoGridAvanzado(dgvCuentas, False, False, 10.0F)
        GetAgencias()
        cargarCajas()
        If UsuariosList IsNot Nothing Then
            If UsuariosList.Count = 1 Then
                GetUsuarioDefault()
                GradientPanel8.Enabled = False
            Else

            End If
        End If
        GetDocsVenta()
        GetMappingGridEncomiendas()
        'threadClientes()
        'threadPersonas()
        If IsNumeric(ComboCaja.SelectedValue) Then
            GetMappingColumnsGridByUsuario(Integer.Parse(ComboCaja.SelectedValue))
        End If
        TextDetalleEnvio.Enabled = True
        TextFechaProgramada.Value = Date.Now
        txtFechaVenta.Value = Date.Now
        TextfechaVcto.Value = Date.Now
        TextFechaEnvio.Value = Date.Now
        texHoraEnvio.Value = Date.Now
        textPersona.Enabled = True
        textPersona.ReadOnly = False
        'DateTimePickerAdv1.Value = Date.Now
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        TextNumIdentrazon.ReadOnly = False
        ' Add any initialization after the InitializeComponent() call.

        FormatoGridAvanzado(GridEncomiendas, False, False, 10.0F)
        FormatoGridAvanzado(dgvCuentas, False, False, 10.0F)
        GetAgencias()
        cargarCajas()
        If UsuariosList IsNot Nothing Then
            If UsuariosList.Count = 1 Then
                GetUsuarioDefault()
                GradientPanel8.Enabled = False
            Else

            End If
        End If
        GetDocsVenta()
        GetMappingGridEncomiendas()
        'threadClientes()
        'threadPersonas()
        If IsNumeric(ComboCaja.SelectedValue) Then
            GetMappingColumnsGridByUsuario(Integer.Parse(ComboCaja.SelectedValue))
        End If
        TextDetalleEnvio.Enabled = True
        TextFechaProgramada.Value = Date.Now
        txtFechaVenta.Value = Date.Now
        TextfechaVcto.Value = Date.Now
        TextFechaEnvio.Value = Date.Now
        texHoraEnvio.Value = Date.Now
        textPersona.Enabled = True
        textPersona.ReadOnly = False
        'DateTimePickerAdv1.Value = Date.Now
    End Sub

#End Region
#Region "Methods"

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
                'TextEmpresaPasajero.Text = students.NombreORazonSocial
                SelRazon.estado = students.EstadoDelContribuyente
                SelRazon.nrodoc = students.Ruc
                SelRazon.direccion = students.Direccion
                SelRazon.tipoPersona = "N"



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
        End Using
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
            obEntidad.estado = StatusEntidad.Activo
            Dim codx As Integer = entidadSA.GrabarEntidad(obEntidad)

            TextEmpresaPasajero.Tag = codx
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

    Function validarcantidad() As Integer
        Dim cant As Integer = 0
        For Each i In GridEncomiendas.Table.Records

            If CDec(i.GetValue("cantidad")) = 0 Then
                cant += 1
            End If
        Next

        Return cant


    End Function

    Private Sub F1Button()
        Try



            If GridEncomiendas.Table.Records.Count <= 0 Then
                MessageBox.Show("Debe indicar el detalle de la encomienda o envío!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TextDetalleEnvio.Select()
                Exit Sub
            End If

            If textPersona.Text.Trim.Length > 0 Then
                If RadioButton1.Checked = True Then
                    If textPersona.ForeColor = Color.Black Then
                        MessageBox.Show("Debe indicar al consignado!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        textPersona.Select()
                        textPersona.Focus()
                        Exit Sub
                    End If
                ElseIf RadioButton2.Checked = True Then
                End If

                If TextEmpresaPasajero.Text.Trim.Length > 0 Then
                    'If TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
                    GetMappingEnvio()
                    PanelCrearEncomienda.Visible = False
                    chCredito.Checked = False
                    LblPagoCredito.Visible = False
                    ErrorProvider1.Clear()
                    If IsNumeric(ComboCaja.SelectedValue) Then
                        GetMappingColumnsGridByUsuario(Integer.Parse(ComboCaja.SelectedValue))
                    End If
                    'Else
                    '    MessageBox.Show("Debe indicar un remitente!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '    TextEmpresaPasajero.Select()
                    '    TextEmpresaPasajero.Focus()
                    'End If
                Else
                    MessageBox.Show("Debe indicar un remitente!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TextEmpresaPasajero.Select()
                    TextEmpresaPasajero.Focus()
                End If

            Else
                MessageBox.Show("Debe indicar al consignado!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                textPersona.Select()
                textPersona.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData

            Case Keys.F1
                F1Button()

            Case Keys.F2
                ToolStripButton6.PerformClick()

            Case Else
                'Do Nothing
        End Select

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub GetAgencias()
        Dim agenciaSA As New establecimientoSA
        Dim listaAgenciasOrigen = ListaAgencias.Where(Function(o) o.TipoEstab = "UN").ToList
        '      Dim listaAgenciasDestino = listaAgencias.Where(Function(o) o.TipoEstab = "AG").ToList

        ComboAgenciaOrigen.DataSource = listaAgenciasOrigen
        ComboAgenciaOrigen.DisplayMember = "nombre"
        ComboAgenciaOrigen.ValueMember = "idCentroCosto"
        ComboAgenciaOrigen.Text = GEstableciento.NombreEstablecimiento
    End Sub

    Public Sub GetDocsVenta()
        cboTipoDoc.Items.Clear()
        'cboTipoDoc.Items.Add("NOTA DE VENTA")
        'cboTipoDoc.Items.Add("BOLETA")
        'cboTipoDoc.Items.Add("FACTURA")
        cboTipoDoc.Items.Add("BOLETA ELECTRONICA")
        cboTipoDoc.Items.Add("FACTURA ELECTRONICA")

        cboTipoDoc.Text = "BOLETA ELECTRONICA"
    End Sub



    Private Sub GetUsuarioUnico()
        '    If CheckUsuarioUnico.Checked = True Then
        If UsuariosList IsNot Nothing Then
            Dim user = UsuariosList.Where(Function(o) o.codigo = TextCodigoVendedor.Text.Trim).SingleOrDefault
            If user IsNot Nothing Then
                TextCodigoVendedor.Text = user.codigo
                Dim TienenCajaSel = ListaCajasActivas.Where(Function(o) o.idPersona = user.IDUsuario).FirstOrDefault
                If TienenCajaSel IsNot Nothing Then
                    ComboCaja.SelectedValue = Integer.Parse(TienenCajaSel.idcajaUsuario)
                End If
            Else
                ComboCaja.SelectedIndex = -1
                TextCodigoVendedor.Clear()
            End If
        End If

        '   End If
    End Sub

    Private Sub GetUsuarioDefault()
        '    If CheckUsuarioUnico.Checked = True Then
        If UsuariosList IsNot Nothing Then
            Dim user = UsuariosList.Where(Function(o) o.IDUsuario = usuario.IDUsuario).SingleOrDefault
            If user IsNot Nothing Then
                TextCodigoVendedor.Text = user.codigo
                Dim TienenCajaSel = ListaCajasActivas.Where(Function(o) o.idPersona = user.IDUsuario).FirstOrDefault
                If TienenCajaSel IsNot Nothing Then
                    ComboCaja.SelectedValue = Integer.Parse(TienenCajaSel.idcajaUsuario)
                End If
            Else
                ComboCaja.SelectedIndex = -1
                TextCodigoVendedor.Clear()
            End If
        End If

        '   End If
    End Sub

    Sub cargarCajas()
        If ListaCajasActivas IsNot Nothing Then
            If ListaCajasActivas.Count > 0 Then

                ComboCaja.DataSource = ListaCajasActivas ' cajaUsuarioSA.ListadoCajaXEstado(UsuarioBE)
                ComboCaja.ValueMember = "idcajaUsuario" ' "IDUsuario"
                ComboCaja.DisplayMember = "NombrePersona"
            End If
        End If
    End Sub

    Private Sub GetMappingGridEncomiendas()
        Dim dt As New DataTable
        dt.Columns.Add("codigo")
        dt.Columns.Add("tipo")
        dt.Columns.Add("detalle")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("unidad")
        dt.Columns.Add("importe")

        GridEncomiendas.DataSource = dt
    End Sub

    Private Sub FillLSVClientesGeneral(consulta As List(Of entidad))
        ListEmpresas.Items.Clear()
        '     Dim image = ImageList1.Images(0)
        For Each i In consulta
            Dim n As New ListViewItem(i.idEntidad)

            n.SubItems.Add(i.nombreCompleto)
            n.SubItems.Add(i.nrodoc)
            n.SubItems.Add(i.tipoDoc)
            ListEmpresas.Items.Add(n)
        Next
    End Sub


#End Region

#Region "Events"



    Private Sub pcLikeCategoria_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcLikeCategoria.CloseUp
        Dim beneficioSA As New beneficioSA
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.PopupCloseType = PopupCloseType.Done Then
                If LsvProveedor.SelectedItems.Count > 0 Then
                    If LsvProveedor.SelectedItems(0).SubItems(1).Text = "Agregar nuevo" Then
                        Dim f As New FormCrearPersonaPasajero()
                        f.StartPosition = FormStartPosition.CenterParent
                        f.ShowDialog()
                        If Not IsNothing(f.Tag) Then
                            Dim c = CType(f.Tag, Persona)
                            ListaPersonas.Add(c)
                            textPersona.Text = c.nombreCompleto
                            txtruc.Text = c.idPersona
                            textPersona.Tag = c.codigo
                            txtruc.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                            txtruc.Visible = True
                            textPersona.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        End If
                    Else
                        textPersona.Text = LsvProveedor.SelectedItems(0).SubItems(1).Text
                        textPersona.Tag = LsvProveedor.SelectedItems(0).SubItems(0).Text
                        textPersona.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        txtruc.Text = LsvProveedor.SelectedItems(0).SubItems(2).Text
                        txtruc.Visible = True
                    End If
                End If
            End If

            'Set focus back to textbox.
            If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
                Me.textPersona.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub FillLSVClientes(consulta As List(Of Persona))
        LsvProveedor.Items.Clear()
        '     Dim image = ImageList1.Images(0)
        For Each i In consulta
            Dim n As New ListViewItem(i.codigo)

            n.SubItems.Add(i.nombreCompleto)
            n.SubItems.Add(i.idPersona)
            n.SubItems.Add(i.tipodoc)
            LsvProveedor.Items.Add(n)
        Next
    End Sub

    Private Sub RoundButton28_Click(sender As Object, e As EventArgs)
        Cursor = Cursors.WaitCursor
        'GetRutasPorDia()
        Cursor = Cursors.Default
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
                    If company.TipoContribuyente = "PERSONA NATURAL SIN NEGOCIO" Then
                        SelRazon.tipoPersona = "N"

                    End If
                    SelRazon.tipoPersona = "N"
                    SelRazon.tipoDoc = "6"
                    SelRazon.tipoEntidad = "PR"
                    SelRazon.nombreCompleto = company.RazonSocial
                    SelRazon.nombreContacto = company.RazonSocial
                    SelRazon.estado = company.Estado_Contribuyente
                    SelRazon.nrodoc = company.Ruc
                    SelRazon.direccion = company.DireccionDomicilioFiscal

                    GrabarEntidadRapida()

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
                    SelRazon.nombreCompleto = company.RazonSocial
                    SelRazon.nombreContacto = company.RazonSocial
                    SelRazon.estado = company.Estado_Contribuyente
                    SelRazon.direccion = company.DireccionDomicilioFiscal
                    SelRazon.nrodoc = company.Ruc

                    GrabarEntidadRapida()

                End If
            Else

            End If
        End If

    End Sub

    Private Sub TextEmpresaPasajero_TextChanged(sender As Object, e As EventArgs) Handles TextEmpresaPasajero.TextChanged
        'TextEmpresaPasajero.ForeColor = Color.Black
        'TextEmpresaPasajero.Tag = Nothing
        'If TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
        '    TextNumIdentrazon.Visible = True
        'Else
        '    TextNumIdentrazon.Visible = False
        'End If
    End Sub

    Private Sub TextEmpresaPasajero_KeyDown(sender As Object, e As KeyEventArgs) Handles TextEmpresaPasajero.KeyDown
        'If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        'ElseIf e.KeyCode = Keys.Enter Then
        '    Me.PCEmpresas.Size = New Size(319, 128)
        '    Me.PCEmpresas.ParentControl = Me.TextEmpresaPasajero
        '    Me.PCEmpresas.ShowPopup(Point.Empty)
        '    Dim consulta As New List(Of entidad)
        '    consulta.Add(New entidad With {.nombreCompleto = "Agregar nuevo"})

        '    Dim consulta2 = (From n In Transporte.ListaEmpresas
        '                     Where n.nombreCompleto.StartsWith(TextEmpresaPasajero.Text) Or n.nrodoc.StartsWith(TextEmpresaPasajero.Text)).ToList


        '    consulta.AddRange(consulta2)
        '    FillLSVClientesGeneral(consulta)
        '    If consulta.Count <= 1 Then
        '        If MessageBox.Show("El cliente ingresado no existe!. Desea crearlo ahora?", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

        '            Dim f As New frmCrearENtidades(TextEmpresaPasajero.Text)
        '            f.CaptionLabels(0).Text = "Nuevo cliente"
        '            f.strTipo = TIPO_ENTIDAD.CLIENTE
        '            f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        '            f.StartPosition = FormStartPosition.CenterParent
        '            f.ShowDialog()
        '            If f.Tag IsNot Nothing Then
        '                Dim c = CType(f.Tag, entidad)
        '                TextEmpresaPasajero.Text = c.nombreCompleto
        '                TextEmpresaPasajero.Tag = c.idEntidad
        '                TextNumIdentrazon.Visible = True
        '                TextNumIdentrazon.Text = c.nrodoc
        '                TextNumIdentrazon.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        '                TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        '                Transporte.ListaEmpresas.Add(c)
        '            End If

        '        End If

        '    End If

        'Else
        '    '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
        '    Me.PCEmpresas.Size = New Size(282, 128)
        '    Me.PCEmpresas.ParentControl = Me.TextEmpresaPasajero
        '    Me.PCEmpresas.ShowPopup(Point.Empty)
        '    Dim consulta As New List(Of entidad)
        '    consulta.Add(New entidad With {.nombreCompleto = "Agregar nuevo"})

        '    Dim consulta2 = (From n In Transporte.ListaEmpresas
        '                     Where n.nombreCompleto.StartsWith(TextEmpresaPasajero.Text) Or n.nrodoc.StartsWith(TextEmpresaPasajero.Text)).ToList




        '    consulta.AddRange(consulta2)
        '    FillLSVClientesGeneral(consulta)
        '    e.Handled = True
        'End If

        'If e.KeyCode = Keys.Down Then
        '    '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
        '    Me.PCEmpresas.Size = New Size(282, 128)
        '    Me.PCEmpresas.ParentControl = Me.TextEmpresaPasajero
        '    Me.PCEmpresas.ShowPopup(Point.Empty)
        '    ListEmpresas.Focus()
        'End If
        ''   End If

        '' e.SuppressKeyPress = True
        'If e.KeyCode = Keys.Escape Then
        '    If Me.PCEmpresas.IsShowing() Then
        '        Me.PCEmpresas.HidePopup(PopupCloseType.Canceled)
        '    End If
        'End If
    End Sub

    Private Sub ListEmpresas_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListEmpresas.MouseDoubleClick
        Me.PCEmpresas.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub PCEmpresas_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles PCEmpresas.CloseUp
        'Me.Cursor = Cursors.WaitCursor
        'Try
        '    If e.PopupCloseType = PopupCloseType.Done Then
        '        If ListEmpresas.SelectedItems.Count > 0 Then
        '            If ListEmpresas.SelectedItems(0).SubItems(1).Text = "Agregar nuevo" Then
        '                Dim f As New frmCrearENtidades
        '                f.CaptionLabels(0).Text = "Nuevo cliente"
        '                f.strTipo = TIPO_ENTIDAD.CLIENTE
        '                f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        '                'f.tipoPersona(TIPO_ENTIDAD.CLIENTE)
        '                f.StartPosition = FormStartPosition.CenterParent
        '                f.ShowDialog()
        '                If Not IsNothing(f.Tag) Then
        '                    Dim c = CType(f.Tag, entidad)
        '                    Transporte.ListaEmpresas.Add(c)
        '                    'txtTipoDocClie.Text = c.tipoDoc
        '                    TextEmpresaPasajero.Text = c.nombreCompleto
        '                    TextNumIdentrazon.Text = c.nrodoc
        '                    TextEmpresaPasajero.Tag = c.idEntidad
        '                    TextNumIdentrazon.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        '                    TextNumIdentrazon.Visible = True
        '                    TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        '                End If
        '            Else
        '                TextEmpresaPasajero.Text = ListEmpresas.SelectedItems(0).SubItems(1).Text
        '                TextEmpresaPasajero.Tag = ListEmpresas.SelectedItems(0).SubItems(0).Text
        '                TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        '                TextNumIdentrazon.Text = ListEmpresas.SelectedItems(0).SubItems(2).Text
        '                ' txtTipoDocClie.Text = LsvProveedor.SelectedItems(0).SubItems(3).Text
        '                TextNumIdentrazon.Visible = True


        '                'TextBenefClienteBase.Text = beneficio.importeBase.GetValueOrDefault
        '                'TextValorAfecto.Text = beneficio.valorConvertido

        '                'Select Case beneficio.tipoAfectacion
        '                '    Case "I"
        '                '        TextTipoBeneficio.Text = "IMPORTE"
        '                '    Case "C"
        '                '        TextTipoBeneficio.Text = "CANTIDAD"
        '                '    Case "P"
        '                '        TextTipoBeneficio.Text = "PORCENTAJE"
        '                'End Select

        '            End If
        '            'ListaMercaderiasXIdHijo(Val(txtSubCategoria.Tag), cboTipoExistencia.SelectedValue)
        '        End If
        '    End If

        '    'Set focus back to textbox.
        '    If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
        '        Me.TextEmpresaPasajero.Focus()
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub textPersona_TextChanged(sender As Object, e As EventArgs) Handles textPersona.TextChanged
        If RadioButton1.Checked = True Then
            'textPersona.ForeColor = Color.Black
            'textPersona.Tag = Nothing
            'If textPersona.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            '    txtruc.Visible = True
            'Else
            '    txtruc.Visible = False
            'End If
        End If
    End Sub

    Private Sub textPersona_KeyDown(sender As Object, e As KeyEventArgs) Handles textPersona.KeyDown
        If RadioButton1.Checked = True Then
            If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

            ElseIf e.KeyCode = Keys.Enter Then
                'Me.pcLikeCategoria.Size = New Size(319, 128)
                'Me.pcLikeCategoria.ParentControl = Me.textPersona
                'Me.pcLikeCategoria.ShowPopup(Point.Empty)
                'Dim consulta As New List(Of entidad)
                'consulta.Add(New entidad With {.nombreCompleto = "Agregar nuevo"})



                'Dim consulta2 = (From n In listaPersonas
                '                 Where n.nombreCompleto.StartsWith(textPersona.Text) Or n.idPersona.StartsWith(textPersona.Text)).ToList


                'consulta.AddRange(consulta2)
                'FillLSVClientes(consulta)
                'If consulta.Count <= 1 Then
                '    If MessageBox.Show("El cliente ingresado no existe!. Desea crearlo ahora?", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                '        Dim f As New FormCrearPersonaPasajero()
                '        f.StartPosition = FormStartPosition.CenterParent
                '        f.ShowDialog(Me)
                '        If f.Tag IsNot Nothing Then
                '            Dim c = CType(f.Tag, Persona)
                '            textPersona.Text = c.nombreCompleto
                '            textPersona.Tag = c.idPersona
                '            txtruc.Visible = True
                '            txtruc.Text = c.idPersona
                '            txtruc.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                '            textPersona.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                '            listaPersonas.Add(c)
                '        End If
                '    End If
                'End If
            Else
                '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
                ' If RBNatural.Checked = True Then
                Me.pcLikeCategoria.Size = New Size(282, 128)
                Me.pcLikeCategoria.ParentControl = Me.textPersona
                Me.pcLikeCategoria.ShowPopup(Point.Empty)
                Dim consulta As New List(Of Persona)
                consulta.Add(New Persona With {.nombreCompleto = "Agregar nuevo"})

                Dim consulta2 = (From n In ListaPersonas
                                 Where n.nombreCompleto.StartsWith(textPersona.Text) Or n.idPersona.StartsWith(textPersona.Text)).ToList




                consulta.AddRange(consulta2)
                FillLSVClientes(consulta)
                e.Handled = True
                ' End If

            End If

            If e.KeyCode = Keys.Down Then
                '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
                Me.pcLikeCategoria.Size = New Size(282, 128)
                Me.pcLikeCategoria.ParentControl = Me.textPersona
                Me.pcLikeCategoria.ShowPopup(Point.Empty)
                LsvProveedor.Focus()
            End If
            '   End If

            ' e.SuppressKeyPress = True
            If e.KeyCode = Keys.Escape Then
                If Me.pcLikeCategoria.IsShowing() Then
                    Me.pcLikeCategoria.HidePopup(PopupCloseType.Canceled)
                End If
            End If

        ElseIf RadioButton2.Checked = True Then
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                txtCant.Select()
                txtCant.Focus()
            End If
        End If

    End Sub

    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles LsvProveedor.MouseDoubleClick
        Me.pcLikeCategoria.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub AgregarItemButton()
        If TExtTotal.DecimalValue <= 0 Then
            MessageBox.Show("El importe debe ser mayor a cero!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TExtTotal.Select()
            TExtTotal.Focus()
            Exit Sub
        End If
        If TextDetalleEnvio.Text.Trim.Length > 0 Then
            AgregarItem()
        Else
            MessageBox.Show("Debe indicar el contenido de la encomienda!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextDetalleEnvio.Select()
            TextDetalleEnvio.Focus()
        End If
    End Sub

    Private Sub RoundButton21_Click(sender As Object, e As EventArgs) Handles RoundButton21.Click
        AgregarItemButton()
    End Sub

    Private Sub AgregarItem()
        With GridEncomiendas.Table
            .AddNewRecord.SetCurrent()
            .AddNewRecord.BeginEdit()
            .CurrentRecord.SetValue("codigo", 0)
            .CurrentRecord.SetValue("tipo", ComboTipo.Text)
            .CurrentRecord.SetValue("detalle", TextDetalleEnvio.Text.Trim)
            .CurrentRecord.SetValue("cantidad", txtCant.DecimalValue)
            .CurrentRecord.SetValue("unidad", "NIU")
            .CurrentRecord.SetValue("importe", TExtTotal.DecimalValue)
            .AddNewRecord.EndEdit()
            .TableDirty = True
        End With
        TextDetalleEnvio.Clear()
        TExtTotal.DecimalValue = 0
        txtCant.DecimalValue = 1
    End Sub

    Private Sub RoundButton23_Click(sender As Object, e As EventArgs) Handles RoundButton23.Click
        Dim r As Record = GridEncomiendas.Table.CurrentRecord
        If r IsNot Nothing Then
            r.Delete()
        End If
        GridEncomiendas.Refresh()
    End Sub


    Private Sub GetMappingEnvio()

        Dim distritoSA As New distritosSA
        Dim rutaSA As New RutasSA
        Dim persona As Persona = Nothing
        Dim razonSocialEmpresa As entidad = Nothing
        'Dim rutaSel As rutas = Nothing
        'Dim servicio As ruta_HorarioServicios = Nothing

        'Con identificacion de persona consginada

        If RadioButton1.Checked = True Then
            'persona = ListaPersonas.Where(Function(o) o.codigo = CInt(textPersona.Tag)).SingleOrDefault
            persona = PersonaSA.ObtenerPersonaNumDoc(Gempresas.IdEmpresaRuc, txtruc.Text)
            TextNombres.Text = persona.nombreCompleto ' $"{persona.nombres}, {persona.appat}"
            TextNombres.Tag = persona.codigo
            TextCodigoIdentidad.Text = persona.tipodoc

            Select Case persona.tipodoc
                Case "1"
                    TextTipoDocIdentidad.Text = "DNI"
                Case "4"
                    TextTipoDocIdentidad.Text = "CARNET DE EXTRANJERIA"
                Case "6"
                    TextTipoDocIdentidad.Text = "REGISTRO UNICO DE CONTRIBUYENTES"
                Case "7"
                    TextTipoDocIdentidad.Text = "PASAPORTE"
            End Select
            TextNumIdent.Text = persona.idPersona
        Else
            TextNombres.Text = textPersona.Text
            TextNombres.Tag = VarClienteGeneral.idEntidad
            TextCodigoIdentidad.Text = "1"
        End If

        'razonSocialEmpresa = Transporte.ListaEmpresas.Where(Function(o) o.idEntidad = CInt(TextEmpresaPasajero.Tag)).SingleOrDefault

        razonSocialEmpresa = entidadSA.UbicarEntidadPorID(CInt(TextEmpresaPasajero.Tag)).ToList.FirstOrDefault

        ' rutaSel = rutaSA.RutaSelID(New rutas With {.ruta_id = id_ruta}) ' ListaRutasActivas.Where(Function(o) o.ruta_id = id_ruta).SingleOrDefault

        '------------------------------------------------------------------
        TextRaZonSocial.Text = razonSocialEmpresa.nombreCompleto
        TextRaZonSocial.Tag = razonSocialEmpresa.idEntidad
        TextRuc.Text = razonSocialEmpresa.nrodoc
        TextCodigoComprobanteRazon.Text = razonSocialEmpresa.tipoDoc
        Select Case razonSocialEmpresa.tipoDoc
            Case "1"
                TextTipoDocIdentidadRazon.Text = "DNI"
            Case "4"
                TextTipoDocIdentidadRazon.Text = "CARNET DE EXTRANJERIA"
            Case "6"
                TextTipoDocIdentidadRazon.Text = "REGISTRO UNICO DE CONTRIBUYENTES"
            Case "7"
                TextTipoDocIdentidadRazon.Text = "PASAPORTE"
        End Select


        Dim origen = ListaAgencias.Where(Function(o) o.idCentroCosto = ComboAgenciaOrigen.SelectedValue).SingleOrDefault

        Dim destino = ListaAgencias.Where(Function(o) o.idCentroCosto = ComboAgenciaDestino.SelectedValue).SingleOrDefault

        TextFechaProgramada.Value = New DateTime(TextFechaEnvio.Value.Year, TextFechaEnvio.Value.Month, TextFechaEnvio.Value.Day, texHoraEnvio.Value.Hour, texHoraEnvio.Value.Minute, texHoraEnvio.Value.Second)


        TextCiudadDestino.Text = destino.nombre
        TextDestinoUbigeo.Text = destino.ubigeo

        TextCiudadOrigen.Text = origen.nombre
        TextOrigenUbigeo.Text = origen.ubigeo

        txtTotalPagar.DecimalValue = GetPorPagar()
        ToolStripButton6.Enabled = True
    End Sub

    Private Function GetPorPagar() As Decimal
        GetPorPagar = 0
        For Each i In GridEncomiendas.Table.Records
            GetPorPagar += CDec(i.GetValue("importe"))
        Next
    End Function

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        ToolStripButton6.Enabled = False
        PanelCrearEncomienda.Visible = True
        PanelCrearEncomienda.Size = New Size(806, 594)
    End Sub

    Private Sub FormCrearEncomienda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PanelCrearEncomienda.Visible = True
        PanelCrearEncomienda.Size = New Size(806, 594)
        ComboPrint.Items.Clear()
        Me.CenterToParent()

        ' defaultPrinterSetting = DocumentPrinter.GetDefaultPrinterSetting
        '  Dim f = System.Drawing.Printing.PrinterSettings.InstalledPrinters
        ' If System.Drawing.Printing.PrinterSettings.InstalledPrinters.Count > 0 Then
        Dim instance As New Printing.PrinterSettings
        instance.DefaultPageSettings.Landscape = False
        Dim impresosaPredt As String = instance.PrinterName
        For Each item As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
            ComboPrint.Items.Add(item.ToString)
        Next
        If ComboPrint.Items.Count > 0 Then
            ComboPrint.SelectedText = impresosaPredt
        End If
    End Sub

    Private Sub cboTipoDoc_Click(sender As Object, e As EventArgs) Handles cboTipoDoc.Click

    End Sub

    Private Sub cboTipoDoc_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboTipoDoc.SelectedValueChanged
        'If cboTipoDoc.Text.Trim.Length > 0 Then
        '    Select Case cboTipoDoc.Text
        '        Case "NOTA DE VENTA"

        '            'txtruc.Text = 0
        '            'TXTcOMPRADOR.Text = "VARIOS"
        '            'txtruc.Select(0, txtruc.Text.Length)
        '            'txtruc.Focus()

        '        Case "BOLETA ELECTRONICA"


        '            'txtNumero.Clear()
        '            'txtSerie.Visible = False
        '            'txtSerie.ReadOnly = True
        '            'txtNumero.Visible = False
        '            'txtNumero.ReadOnly = True


        '            'ProgressBar2.Visible = True
        '            'ProgressBar2.Style = ProgressBarStyle.Marquee
        '           ' GetNumeracion()
        '        Case "FACTURA ELECTRONICA"

        '            'txtNumero.Clear()
        '            'txtSerie.Visible = False
        '            'txtSerie.ReadOnly = True
        '            'txtNumero.Visible = False
        '            'txtNumero.ReadOnly = True


        '            'ProgressBar2.Visible = True
        '            'ProgressBar2.Style = ProgressBarStyle.Marquee
        '            '       GetNumeracion()

        '    End Select
        '    'GetResetCantidades()
        'End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)
        'Try
        '    If BackgroundWorker1.CancellationPending Then
        '        ' MessageBox.Show("Up to here? ...")
        '        e.Cancel = True
        '    Else
        '        Dim strIdModulo As String = Nothing
        '        If cboTipoDoc.Text = "BOLETA" Then
        '            strIdModulo = "VT2"
        '        ElseIf cboTipoDoc.Text = "FACTURA" Then
        '            strIdModulo = "VT3"
        '        ElseIf cboTipoDoc.Text = "BOLETA ELECTRONICA" Then
        '            strIdModulo = "VT2E"
        '        ElseIf cboTipoDoc.Text = "FACTURA ELECTRONICA" Then
        '            strIdModulo = "VT3E"
        '        ElseIf cboTipoDoc.Text = "PROFORMA" Then
        '            strIdModulo = "COTIZACION"
        '        End If
        '        Dim strIDEmpresa = General.Gempresas.IdEmpresaRuc
        '        GetNumeracion(strIdModulo, strIDEmpresa)
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs)
        'If e.Cancelled Then

        'Else

        '    'txtSerie.Text = conf.Serie
        '    ProgressBar2.Visible = False
        'End If
    End Sub

    Private Sub GetMappingColumnsGridByUsuario(idCaja As Integer)
        Dim dt As New DataTable
        Dim SA As New EstadosFinancierosConfiguracionPagosSA
        With dt
            .Columns.Add("tipo")
            .Columns.Add("identidad")
            .Columns.Add("entidad")
            .Columns.Add("abonado")
            .Columns.Add("tipocambio")
            .Columns.Add("idforma")
            .Columns.Add("formaPago")
            .Columns.Add("nrooperacion")
        End With

        Dim listaCuentas = SA.GetConfigurationPayCaja(New estadosFinancierosConfiguracionPagos With
                                                 {
                                                 .idEmpresa = Gempresas.IdEmpresaRuc,
                                                 .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                 .IDCaja = idCaja
                                                 })

        For Each i In listaCuentas ' ListaCuentasFinancierasConfiguradas.Where(Function(o) o.IDFormaPago <> "9991").ToList
            If i.FormaPago = "EFECTIVO" And txtTotalPagar.DecimalValue > 0 Then
                dt.Rows.Add(String.Empty, i.identidad, i.entidad, txtTotalPagar.DecimalValue, TmpTipoCambio, i.IDFormaPago, i.FormaPago, "-")
            Else
                dt.Rows.Add(String.Empty, i.identidad, i.entidad, 0.0, TmpTipoCambio, i.IDFormaPago, i.FormaPago, "-")
            End If

        Next

        'If ListaCuentasFinancierasConfiguradas.Count > 0 Then
        '    Dim cuponSel = ListaCuentasFinancierasConfiguradas.Where(Function(o) o.IDFormaPago = "9991").SingleOrDefault
        '    PanelCupon.Tag = cuponSel
        '    TextCodigoCupon.Visible = True
        '    ButtonAdv4.Visible = True
        'End If

        dgvCuentas.DataSource = dt
        LblPagoCredito.Visible = True
        lblPagoVenta.Visible = True

        Dim pagos As Decimal = SumaPagos()
        LblPagoCredito.Text = "SALDO POR COBRAR"
        lblPagoVenta.Text = CDec(txtTotalPagar.Text) - CDec(SumaPagos())
    End Sub

    Private Function SumaPagos() As Decimal
        SumaPagos = 0
        Dim pagoCupones As Decimal = 0
        For Each i In dgvCuentas.Table.Records
            'If i.GetValue("abonado") <= 0 Then
            '    Throw New Exception("El monto abonado debe sre mayor a cero")
            'End If
            SumaPagos += CDec(i.GetValue("abonado"))
        Next
        '    pagoCupones = TextCuponImporte.DecimalValue
        SumaPagos = SumaPagos + pagoCupones
        Return SumaPagos
    End Function

    Private Sub dgvCuentas_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvCuentas.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Try
            Select Case ColIndex
                Case 3
                    Dim pagos As Decimal = SumaPagos()

                    lblPagoVenta.Text = CDec(txtTotalPagar.Text) - CDec(SumaPagos())

                    If (lblPagoVenta.Text = CDec(0.0)) Then
                        ErrorProvider1.Clear()
                    End If

                    If pagos > CDec(txtTotalPagar.Text) Then
                        MessageBox.Show("El pago no debe exceder el valor de la venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        dgvCuentas.Table.CurrentRecord.SetValue("abonado", 0)
                        Exit Sub
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Verificar montos del pago")
        End Try
    End Sub

    Private Sub ChPagoAvanzado_OnChange(sender As Object, e As EventArgs) Handles ChPagoAvanzado.OnChange
        If ChPagoAvanzado.Checked = True Then
            chCredito.Checked = False
            LblPagoCredito.Visible = False
            ErrorProvider1.Clear()
            If IsNumeric(ComboCaja.SelectedValue) Then
                GetMappingColumnsGridByUsuario(Integer.Parse(ComboCaja.SelectedValue))
            End If
        Else
            'ChPagoAvanzado.Checked = True
        End If
    End Sub

    Private Sub chCredito_OnChange(sender As Object, e As EventArgs) Handles chCredito.OnChange
        If chCredito.Checked = True Then
            chCredito.Checked = True
            LblPagoCredito.Visible = True
            ChPagoAvanzado.Checked = False
            ErrorProvider1.Clear()
        Else
            ' chCredito.Checked = True
            LblPagoCredito.Visible = True
        End If
    End Sub

    Private Function ValidarGrabado() As Boolean
        Dim listaErrores As Integer = 0

        'If (ChPagoAvanzado.Checked = True And lblPagoVenta.Text > 0) Then
        '    ErrorProvider1.SetError(Label8, "Debe efectuar la totalidad del pago")
        '    listaErrores += 1
        'End If

        If txtTotalPagar.DecimalValue <= 0 Then
            ErrorProvider1.SetError(txtTotalPagar, "La venta debe ser mayor a cero")
            listaErrores += 1
        Else
            ErrorProvider1.SetError(txtTotalPagar, Nothing)
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

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        Dim cajaUsuaroSA As New cajaUsuarioSA
        Dim entidadSA As New EstadosFinancierosSA
        Dim envio As EnvioImpresionVendedorPernos = Nothing
        Try
            ToolStripButton6.Enabled = False
            'If ToolStripButton6.Enabled Then
            cargarCajas()
            txtFechaVenta.Value = Date.Now
            Select Case cboTipoDoc.Text
                Case "FACTURA", "FACTURA ELECTRONICA"
                    Dim objeto As Boolean = ValidationRUC(TextRuc.Text.Trim)
                    If objeto = False Then
                        MessageBox.Show("Debe Ingresar un número correcto de ruc", "Ingresar identificación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Cursor = Cursors.Default
                        ToolStripButton6.Enabled = True
                        Exit Sub
                    End If
                Case "BOLETA ELECTRONICA", "BOLETA"
                    'If RadioButton1.Checked = True Then

                    'End If
                    Dim rsp = validarDNI(TextRuc.Text.Trim)
                    If rsp = False Then
                        MessageBox.Show("Debe Ingresar un número correcto de DNI", "Ingresar identificación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Cursor = Cursors.Default
                        ToolStripButton6.Enabled = True
                        Exit Sub
                    End If
            End Select

            'If TextCodigoVendedor.Text.Trim.Length <= 0 Then
            '    MessageBox.Show("Debe indicar el codigo del vendedor", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    ToolStripButton6.Enabled = True
            '    Exit Sub
            'End If


            If UsuariosList IsNot Nothing Then
                If UsuariosList.Count = 1 Then

#Region "Un Solo usuario"
                    Dim Vendedor = UsuariosList.Where(Function(o) o.IDUsuario = usuario.IDUsuario).SingleOrDefault
                    If Vendedor IsNot Nothing Then

                        If ListaCajasActivas Is Nothing Then
                            MessageBox.Show("No tiene configurada una caja", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            ToolStripButton6.Enabled = True
                            Exit Sub
                        End If

                        If ListaCajasActivas.Count <= 0 Then
                            MessageBox.Show("No tiene configurada una caja", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            ToolStripButton6.Enabled = True
                            Exit Sub
                        End If

                        TextCodigoVendedor.Text = Vendedor.codigo
                        Dim TienenCajaSel = ListaCajasActivas.Where(Function(o) o.idPersona = Vendedor.IDUsuario).FirstOrDefault
                        If TienenCajaSel IsNot Nothing Then
                            ComboCaja.SelectedValue = Integer.Parse(TienenCajaSel.idcajaUsuario)
                        Else
                            MessageBox.Show("No tiene configurada una caja", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            TextCodigoVendedor.Clear()
                            TextCodigoVendedor.Select()
                            ToolStripButton6.Enabled = True
                            Exit Sub
                        End If


                    Else
                        ComboCaja.SelectedIndex = -1
                        TextCodigoVendedor.Clear()
                        MessageBox.Show("No tiene configurada una caja", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        ToolStripButton6.Enabled = True
                        Exit Sub
                    End If


                    Dim cajaUsuario = cajaUsuaroSA.UbicarCajaUsuarioPorID(ComboCaja.SelectedValue)

                    '   Dim ef = entidadSA.GetUbicar_estadosFinancierosPorID(cajaUsuario.idCajaOrigen)

                    envio = New EnvioImpresionVendedorPernos With
                        {
                        .CodigoVendedor = Vendedor.codigo,
                        .IDCaja = cajaUsuario.idcajaUsuario,' ComboCaja.SelectedValue,
                        .IDVendedor = Vendedor.IDUsuario,
                        .print = True,
                        .Nombreprint = String.Empty,
                        .NombreCajero = ComboCaja.Text,
                        .EntidadFinanciera = 0,'ef.idestado,
                        .EntidadFinancieraName = String.Empty
                    }
#End Region

                Else
#Region "Varios Usuarios"
                    Dim Vendedor = GetCodigoVendedor()
                    If Vendedor IsNot Nothing Then
                        Dim codigoVendedor = Vendedor.codigo ' TextCodigoVendedor.Text.Trim
                        Dim usuarioSel = UsuariosList.Where(Function(o) o.codigo = codigoVendedor).FirstOrDefault

                        If usuarioSel IsNot Nothing Then
                            If ListaCajasActivas Is Nothing Then
                                MessageBox.Show("No tiene configurada una caja", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                ToolStripButton6.Enabled = True
                                Exit Sub
                            End If

                            If ListaCajasActivas.Count <= 0 Then
                                MessageBox.Show("No tiene configurada una caja", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                ToolStripButton6.Enabled = True
                                Exit Sub
                            End If


                            Dim TienenCajaSel = ListaCajasActivas.Where(Function(o) o.idPersona = usuarioSel.IDUsuario).FirstOrDefault
                            If TienenCajaSel IsNot Nothing Then
                                ComboCaja.SelectedValue = Integer.Parse(TienenCajaSel.idcajaUsuario)
                            Else
                                MessageBox.Show("No tiene configurada una caja", "Verificar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                TextCodigoVendedor.Clear()
                                TextCodigoVendedor.Select()
                                ToolStripButton6.Enabled = True
                                Exit Sub
                            End If

                            Dim cajaUsuario = cajaUsuaroSA.UbicarCajaUsuarioPorID(ComboCaja.SelectedValue)

                            '   Dim ef = entidadSA.GetUbicar_estadosFinancierosPorID(cajaUsuario.idCajaOrigen)

                            envio = New EnvioImpresionVendedorPernos With
                                {
                                .CodigoVendedor = Vendedor.codigo,
                                .IDCaja = cajaUsuario.idcajaUsuario,' ComboCaja.SelectedValue,
                                .IDVendedor = usuarioSel.IDUsuario,
                                .print = True,
                                .Nombreprint = String.Empty,
                                .NombreCajero = ComboCaja.Text,
                                .EntidadFinanciera = 0,'ef.idestado,
                                .EntidadFinancieraName = String.Empty
                            }
                        Else
                            MessageBox.Show("Ingrese un código valido", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            TextCodigoVendedor.Select()
                            ToolStripButton6.Enabled = True
                            Exit Sub
                        End If
                    Else
                        MessageBox.Show("Debe ingresar un código de vendedor!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        ToolStripButton6.Enabled = True
                        Exit Sub
                    End If
#End Region
                End If
            Else
                MessageBox.Show("Debe ingresar un código de vendedor!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ToolStripButton6.Enabled = True
                Exit Sub
            End If

            '**************************************************************************************
            '                                   GRABAR PASAJE
            '                                   ZONA DE GRABADO
            '**************************************************************************************

            If ValidarGrabado() = True Then
                txtFechaVenta.Value = Date.Now

                If Not chCredito.Checked = True Then
                    Dim pagos As Decimal = SumaPagos()

                    If pagos <= 0 Then
                        MessageBox.Show("Debe ingresar un pago mayor a cero!", "Pagar venta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                        'objPleaseWait.Close()
                        ToolStripButton6.Enabled = True
                        Exit Sub
                    End If

                    If pagos > 0 AndAlso pagos < txtTotalPagar.DecimalValue Then
                        If MessageBox.Show("Está realizando una cobranza parcial, Desea Continuar?", "Pagar venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                            '   objPleaseWait.Close()
                            ToolStripButton6.Enabled = True
                            Exit Sub
                        End If
                    End If
                End If

                If RBClientesVarios.Checked = True Then
                    If txtTotalPagar.DecimalValue >= 699.99 Then
                        MessageBox.Show("Cuando la venta supera los S/.699.99, " & "debe identificar al cliente con un DNI o RUC.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        ToolStripButton6.Enabled = True
                        Exit Sub
                    End If
                End If

                Dim val = validarcantidad()

                If val > 0 Then
                    MessageBox.Show("La Cantidad no debe ser 0!", "Atención!",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                If GridEncomiendas.Table.Records.Count > 0 Then
                    If MessageBox.Show("La encomienda será envíada a la ciudad de: " & ComboAgenciaDestino.Text & vbCrLf & "¿Está seguro?", "Verificar destino", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then



                        GrabarVentaPasaje(envio)


                    Else
                        ToolStripButton6.Enabled = True
                    End If
                Else
                    MessageBox.Show("Debe ingresar al menos una encomienda!", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                    ToolStripButton6.Enabled = True
                End If

                'objPleaseWait = New FeedbackForm()
                'objPleaseWait.StartPosition = FormStartPosition.CenterScreen
                'objPleaseWait.Show()


            End If
            ' End If
        Catch ex As Exception
            MsgBox(ex.Message)
            ToolStripButton6.Enabled = True
        End Try
    End Sub

    Public Sub EnviarFacturaElectronica(idDocumento As Integer, idPSE As Integer)

        ' Dim documentoSA As New documentoVentaAbarrotesSA
        ' Dim documentoDetSA As New documentoVentaAbarrotesDetSA
        ' Dim entidadSA As New entidadSA
        Dim DetalleFactura As Fact.Sunat.Business.Entity.DocumentoElectronicoDetalle

        Dim documneotventaTransporte As New documentoventaTransporte
        Dim item As New documentoventaTransporte
        item.idDocumento = idDocumento
        Dim DocumentoventaTransporteSA As New DocumentoventaTransporteSA

        Try

            documneotventaTransporte = DocumentoventaTransporteSA.DocumentoTransporteSelID(item)


            ' Dim comprobante = documentoSA.GetUbicar_documentoventaAbarrotesPorID(idDocumento)
            ' Dim comprobanteDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(idDocumento)
            Dim receptor = entidadSA.GetUbicarEntPorID(Gempresas.IdEmpresaRuc, documneotventaTransporte.razonSocial)
            Dim numerovent As String = String.Format("{0:00000000}", documneotventaTransporte.numero)
            Dim tipoDoc = String.Format("{0:00}", documneotventaTransporte.tipoDocumento)
            Dim conteo As Integer = 0

            '//Enviando el documento

            Dim Factura As New Fact.Sunat.Business.Entity.DocumentoElectronico

            'Datos del Cliente 
            Factura.Action = 0
            Factura.idEmpresa = idPSE 'lblIdPse.Text
            Factura.Contribuyente_id = Gempresas.IdEmpresaRuc
            Factura.EnvioSunat = "NO"
            'Receptor de la Factura
            Factura.NroDocumentoRec = receptor.nrodoc
            Factura.TipoDocumentoRec = receptor.tipoDoc
            Factura.NombreLegalRec = receptor.nombreCompleto
            'Datos Generales De La Factura
            Factura.IdDocumento = documneotventaTransporte.serie & "-" & numerovent
            Factura.FechaEmision = documneotventaTransporte.fechadoc
            Factura.FechaRecepcion = DateTime.Now 'fecha en la que se envia al PSE
            Factura.FechaVencimiento = DateTime.Now
            Factura.HoraEmision = documneotventaTransporte.fechadoc.Value.ToString("HH:mm:ss")
            'If documneotventaTransporte.moneda = "1" Then
            Factura.Moneda = "PEN"
            'ElseIf documneotventaTransporte.moneda = "2" Then
            '    Factura.Moneda = "USD"
            'End If
            Factura.TipoDocumento = tipoDoc
            Factura.TotalIgv = documneotventaTransporte.igv1
            Factura.TotalVenta = documneotventaTransporte.total
            Factura.Gravadas = documneotventaTransporte.baseImponible1
            Factura.Exoneradas = 0
            Factura.TipoOperacion = "0101"

            'Cargando el Detalle de la Factura

            For Each i In documneotventaTransporte.documentoventaTransporteDetalle
                conteo += 1
                Dim preciounit As Decimal = Math.Round(CDec(i.importe / i.cantidad), 2)
                Dim calcbi As Decimal = Math.Round(CDec(CalculoBaseImponible(i.importe, 1.18)), 2)
                Dim calcigv As Decimal = Math.Round(CDec(i.importe - calcbi), 2)

                DetalleFactura = New Fact.Sunat.Business.Entity.DocumentoElectronicoDetalle
                DetalleFactura.Id = conteo
                DetalleFactura.Cantidad = i.cantidad
                DetalleFactura.PrecioReferencial = preciounit 'i.precioUnitario
                DetalleFactura.CodigoItem = i.secuencia
                DetalleFactura.Descripcion = i.detalle
                DetalleFactura.UnidadMedida = i.unidadMedida
                DetalleFactura.Impuesto = calcigv


                ' If i.destino = "1" Then
                DetalleFactura.TipoImpuesto = "10" 'CATALOGO 7
                DetalleFactura.TipoPrecio = "01" 'CATALOGO 16
                DetalleFactura.PrecioUnitario = CalculoBaseImponible(preciounit, 1.18) 'FormatNumber
                'ElseIf i.destino = "2" Then
                '  DetalleFactura.TipoImpuesto = "20" 'CATALOGO 7
                'DetalleFactura.TipoPrecio = "01" '"02"  'CATALOGO 16
                '  DetalleFactura.PrecioUnitario = i.precioUnitario
                'End If


                DetalleFactura.TotalVenta = calcbi 'i.montokardex
                'DetalleItems .Descuento = "falta"
                'DetalleItems .ImpuestoSelectivo = "falta"
                'DetalleItems.OtroImpuesto = "falta"
                'DetalleItems.PlacaVehiculo = "falta"
                Factura.DocumentoElectronicoDetalle.Add(DetalleFactura)
            Next


            'Enviando al PSE
            Dim codigo = Helios.Fact.Sunat.WCFService.ServiceAccess.Admin.DocumentoElectronicoSA.DocumentoElectronicoSaveValidado(Factura, Nothing)

            If codigo.idDocumentoElectronico > 0 Then

                UpdateEnvioSunatEstado(documneotventaTransporte.idDocumento, "SI")
                'MessageBox.Show("La Factura se Envio Correctamente al PSE")
            End If

        Catch ex As Exception

            'MessageBox.Show("No se Pudo Enviar")

        End Try


    End Sub



    Public Sub UpdateEnvioSunatEstado(idDoc As Integer, estado As String)
        Try

            Dim docSA As New DocumentoventaTransporteSA

            docSA.UpdateFacturasXEstadoTrans(idDoc, estado)

            'MessageBox.Show("Se Genero Correctamente")
        Catch ex As Exception
            'MessageBox.Show("No se Pudo Actualizar")
        End Try



    End Sub



    Private Sub GrabarVentaPasaje(envio As EnvioImpresionVendedorPernos)

        Try
            Dim personaID As Integer = 0
            Dim comprador As String = String.Empty
            Dim ventaSA As New DocumentoventaTransporteSA
            Dim obj As documentoventaTransporteDetalle
            Dim ListaDetalle As List(Of documentoventaTransporteDetalle)

            txtFechaVenta.Value = Date.Now
            Dim tipodoc As String = String.Empty
            Select Case cboTipoDoc.Text
                Case "BOLETA ELECTRONICA"
                    tipodoc = "03"
                Case "FACTURA ELECTRONICA"
                    tipodoc = "01"
                Case "RESERVAR"
                    tipodoc = "9901"
            End Select

            If RadioButton1.Checked Then
                personaID = Integer.Parse(textPersona.Tag)
                comprador = String.Empty
            End If

            If RadioButton2.Checked Then
                personaID = VarClienteGeneral.idEntidad
                comprador = textPersona.Text.Trim
            End If

            Dim documento As New documento With
            {
            .idEmpresa = Gempresas.IdEmpresaRuc,
            .idCentroCosto = ComboAgenciaOrigen.SelectedValue,
            .tipoDoc = tipodoc,
            .fechaProceso = txtFechaVenta.Value,
            .moneda = "1",
            .idEntidad = TextRaZonSocial.Tag,
            .entidad = TextRaZonSocial.Text,
            .tipoEntidad = "PS",
            .nrodocEntidad = TextRuc.Text,
            .nroDoc = "1",
            .idOrden = 0,
            .tipoOperacion = StatusTipoOperacion.VENTA,
            .usuarioActualizacion = usuario.IDUsuario,
            .fechaActualizacion = Date.Now
            }

            documento.documentoventaTransporte = New documentoventaTransporte With
            {
            .tareo_id = 1,
            .idPSE = Gempresas.ubigeo,
            .programacion_id = 0,
            .agenciaDestino_id = Integer.Parse(ComboAgenciaDestino.SelectedValue),
            .tipoOperacion = StatusTipoOperacion.VENTA,
            .idEmpresa = Gempresas.IdEmpresaRuc,
            .idOrganizacion = ComboAgenciaOrigen.SelectedValue,
            .UbigeoCiudadOrigen = TextOrigenUbigeo.Text,
            .ciudadOrigen = TextCiudadOrigen.Text,
            .UbigeoCiudadDestino = TextDestinoUbigeo.Text,
            .ciudadDestino = TextCiudadDestino.Text,
            .tipoDocumento = tipodoc,
            .fechaProgramada = TextFechaProgramada.Value,
            .fechadoc = txtFechaVenta.Value,
            .fechaVcto = TextfechaVcto.Value,
            .serie = 0,
            .numero = 0,
            .idPersona = personaID,'Integer.Parse(TextNombres.Tag),
            .razonSocial = Integer.Parse(TextRaZonSocial.Tag),
            .comprador = comprador,
            .moneda = "1",
            .tipocambio = 1,
            .tasaIgv = 0.18,
            .baseImponible1 = Math.Round(CDec(CalculoBaseImponible(txtTotalPagar.DecimalValue, 1.18)), 2),
            .baseImponible2 = 0,
            .igv1 = txtTotalPagar.DecimalValue - Math.Round(CDec(CalculoBaseImponible(txtTotalPagar.DecimalValue, 1.18)), 2),
            .igv2 = 0,
            .total = txtTotalPagar.DecimalValue,
            .estadoCobro = TIPO_VENTA.PAGO.PENDIENTE_PAGO,
            .glosa = "Venta de encomiendas",
            .tipoVenta = TIPO_VENTA.VENTA_ENCOMIENDAS,
            .numeroAsiento = 0,
            .estado = Transporte.EncomiendaEstado.PendienteDeEntrega,
            .idcajaUsuario = envio.IDCaja,
            .telefonoRemitente = txtTelefonoRemitente.Text,
            .telefonoConsignado = txtTelefonoConsignado.Text,
            .usuarioActualizacion = usuario.IDUsuario,
            .fechaActualizacion = Date.Now
            }

            ListaDetalle = New List(Of documentoventaTransporteDetalle)
            Dim TIPO As String = String.Empty
            For Each i In GridEncomiendas.Table.Records

                Select Case i.GetValue("tipo")
                    Case "PAQUETE"
                        TIPO = "P"
                    Case "SOBRE"
                        TIPO = "S"
                    Case "CAJA"
                        TIPO = "C"
                    Case "OTROS"
                        TIPO = "O"
                    Case "SACO/COSTAL"
                        TIPO = "CO"
                End Select

                obj = New documentoventaTransporteDetalle
                obj.tipo = TIPO ' i.GetValue("tipo")
                obj.detalle = i.GetValue("detalle")
                obj.cantidad = CDec(i.GetValue("cantidad"))
                obj.unidadMedida = i.GetValue("unidad")
                obj.importe = CDec(i.GetValue("importe"))
                obj.estado = 0
                obj.usuarioActualizacion = usuario.IDUsuario
                obj.fechaActualizacion = Date.Now
                ListaDetalle.Add(obj)
            Next
            documento.documentoventaTransporte.documentoventaTransporteDetalle = ListaDetalle

            Dim ListaPagos = ListaPagosCajas(documento.documentoventaTransporte, envio)
            documento.documentoventaTransporte.estadoCobro = TIPO_VENTA.PAGO.COBRADO
            documento.ListaCustomDocumento = ListaPagos 'ListaPagosCajas(c)
            Dim codVenta = ventaSA.DocumentoventaEncomiendaSave(documento)




            If Gempresas.ubigeo > 0 Then
                If My.Computer.Network.IsAvailable = True Then
                    If My.Computer.Network.Ping("138.128.171.106") Then
                        If cboTipoDoc.Text = "FACTURA ELECTRONICA" Or cboTipoDoc.Text = "BOLETA ELECTRONICA" Then
                            'EnvioPSE(Gempresas.IdEmpresaRuc, impresionTicketDoc.idDocumento)
                            EnviarFacturaElectronica(codVenta, Gempresas.ubigeo)
                        End If
                    End If
                End If
            End If

            If (Not IsNothing(FormInHerits)) Then
                FormInHerits.Conteos()
            End If

            Dim comprobante = ventaSA.DocumentoTransporteSelID(New documentoventaTransporte With
                                                               {
                                                               .idDocumento = codVenta
                                                               })

            Dim entidad = entidadSA.UbicarEntidadPorID(comprobante.razonSocial).FirstOrDefault

            'formVentaPasajes.ReiniciarForm(True, codVenta)
            'ComboPrint.Text

            '''ImprimirTicket("EPSON TM-T20II Receipt5", codVenta, comprobante, entidad)  'LA MERCED


            ImprimirTicket("TICKET", codVenta, comprobante, entidad)  'ADELAIDA

            'ImprimirTicket("\\192.168.1.30\TICKET", codVenta, comprobante, entidad)  'ands 2da maquina

            'ImprimirTicket("TICKET/RUTA", codVenta, comprobante, entidad)  'ADELAIDA

            'ImprimirTicketA4v2("TICKET/RUTA", codVenta, comprobante, entidad)
            'ToolStripButton6.Enabled = True
            Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            ToolStripButton6.Enabled = True
        End Try
    End Sub

    Sub ImprimirTicket(imprimir As String, intIdDocumento As Integer, comprobante As documentoventaTransporte, entidadBE As entidad)
        Try



            Dim a As TicketEncomienda = New TicketEncomienda
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
            '    Dim nombreCliente As String
            Dim documentoSA As New documentoVentaAbarrotesSA
            Dim documentoDetSA As New documentoVentaAbarrotesDetSA
            Dim tipoComprobante As String = String.Empty
            Dim nombreComprabante As String

            listaDatos = CustomListaDatosGenerales

            objDatosGenrales = listaDatos.Where(Function(o) o.NombreFormato = "TK").SingleOrDefault


            If (objDatosGenrales.logo.Length > 0) Then
                ' Logo de la Empresa
                a.HeaderImage = Image.FromFile(objDatosGenrales.logo)
            End If

            If (objDatosGenrales.nombreImpresion = "C") Then
                a.tipoImagen = False
            ElseIf (objDatosGenrales.nombreImpresion = "R") Then
                a.tipoImagen = True
            End If

            'Direccion de La empresa general
            If (objDatosGenrales.tipoImpresion = "S") Then
                a.tipoEncabezado = True
                a.AnadirLineaEmpresa(objDatosGenrales.nombreCorto)
                a.AnadirLineaNombrePropietario(objDatosGenrales.razonSocial)
            ElseIf (objDatosGenrales.tipoImpresion = "N") Then
                a.tipoEncabezado = False
                a.AnadirLineaEmpresa(objDatosGenrales.razonSocial)

            End If

            If (objDatosGenrales.publicidad.Length > 0) Then
                a.tipoPublicidad = True
                a.AnadirLineaNombrePublidad(objDatosGenrales.publicidad)
            Else
                a.tipoPublicidad = False
            End If

            'ruc
            a.TextoIzquierda("R.U.C.: " & objDatosGenrales.idEmpresa)
            'direccion de la empresa
            a.TextoIzquierda(objDatosGenrales.direccionPrincipal)
            a.TextoIzquierda(objDatosGenrales.direccionSecudaria)
            'Telefono de la empresa
            If (objDatosGenrales.telefono3.Length > 0) Then
                a.TextoIzquierda("Telf: " & objDatosGenrales.telefono1 & " - " & objDatosGenrales.telefono2 & " - " & objDatosGenrales.telefono3)
            ElseIf (objDatosGenrales.telefono2.Length > 0) Then
                a.TextoIzquierda("Telf: " & objDatosGenrales.telefono1 & " - " & objDatosGenrales.telefono2)
            Else
                a.TextoIzquierda("Telf: " & objDatosGenrales.telefono1)
            End If


            Select Case comprobante.tipoDocumento
                'Case "12.1"
                '    'ticket.TextoExtremos("Caja # 1", "Ticket boleta # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                '    a.AnadirLineaCaracteresFactura(Gempresas.IdEmpresaRuc, comprobante.serie & " - " & CStr(comprobante.numero).PadLeft(8, "0"c), "BOLETA")
                '    'ticket.TextoIzquierda("Ticket Boleta # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                '    nombreComprabante = "BOLETA" & " " & comprobante.serie & "-" & CStr(comprobante.numero).PadLeft(8, "0"c)
                '    tipoComprobante = "1"
                'Case "12.2"
                '    '  ticket.TextoExtremos("Caja # 1", "Ticket factura # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                '    'ticket.TextoIzquierda("Ticket Factura # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                '    a.AnadirLineaCaracteresFactura(Gempresas.IdEmpresaRuc, comprobante.serie & " - " & CStr(comprobante.numero).PadLeft(8, "0"c), "FACTURA")
                '    nombreComprabante = "FACTURA" & " " & comprobante.serie & "-" & CStr(comprobante.numero).PadLeft(8, "0"c)
                '    tipoComprobante = "1"
                Case "03"
                    a.AnadirLineaComprobante("BOLETA DE VENTA ELECTRONICA")
                    a.AnadirLineaComprobante(comprobante.serie & " - " & CStr(comprobante.numero).PadLeft(8, "0"c))
                    'a.AnadirLineaCaracteresFactura(Gempresas.IdEmpresaRuc, comprobante.serie & " - " & CStr(comprobante.numero).PadLeft(8, "0"c), "BOLETA DE VENTA ELECTRONICA")
                    nombreComprabante = "BOLETA DE VENTA ELECTRONICA" & " " & comprobante.serie & "-" & CStr(comprobante.numero).PadLeft(8, "0"c)
                    tipoComprobante = "2"

                Case "01"
                    a.AnadirLineaComprobante("FACTURA ELECTRONICA")
                    a.AnadirLineaComprobante(comprobante.serie & " - " & CStr(comprobante.numero).PadLeft(8, "0"c))
                    'a.AnadirLineaCaracteresFactura(Gempresas.IdEmpresaRuc, comprobante.serie & " - " & CStr(comprobante.numero).PadLeft(8, "0"c), "FACTURA ELECTRONICA")
                    nombreComprabante = "FACTURA ELECTRONICA" & " " & comprobante.serie & "-" & CStr(comprobante.numero).PadLeft(8, "0"c)
                    tipoComprobante = "2"

                    'Case "9901"
                    '    a.AnadirLineaCaracteresFactura(Gempresas.IdEmpresaRuc, 0 & " - " & CStr(0).PadLeft(8, "0"c), "PROFORMA")
                    '    nombreComprabante = "PROFORMA"
                    '    tipoComprobante = "1"
                    'Case Else

                    '    a.AnadirLineaCaracteresFactura(Gempresas.IdEmpresaRuc, comprobante.serie & " - " & CStr(comprobante.numero).PadLeft(8, "0"c), "NOTA")
                    '    nombreComprabante = "NOTA" & " " & comprobante.serie & "-" & CStr(comprobante.numero).PadLeft(8, "0"c)
                    '    tipoComprobante = "1"
            End Select



            If comprobante.Consignado IsNot Nothing Then

                Dim NBoletaElectronica As String = entidadBE.nombreCompleto
                Dim nBoletaNumero As String
                'ticket.TextoIzquierda(NBoletaElectronica)
                If entidadBE.nrodoc.Trim.Length = 11 Then
                    nBoletaNumero = "R.U.C. - " & entidadBE.nrodoc
                ElseIf entidadBE.nrodoc.Trim.Length = 8 Then
                    nBoletaNumero = "D.N.I. - " & entidadBE.nrodoc
                Else
                    nBoletaNumero = entidadBE.nrodoc
                End If
                'Fecha de Factura
                'LUGAR DE DESTINO
                'Nombre del REMITENTE
                'Nombre del CONSIGNADO
                'DNI CONSIGNADO
                'DNI REMITENTE
                'tipo moneda de la empresa
                'LUGAR DE ORIGEN


                If (comprobante.comprador.Length = 0) Then
                    a.AnadirLineaCaracteresDatosGEnerales(comprobante.fechadoc,
                                               comprobante.ciudadOrigen,
                                              "GENERAL",
                                              "7:00",
                                              "14",
                                              "1",
                                              "2",
                                              comprobante.Remitente,
                                                comprobante.CustomPerson.idPersona,
                                               comprobante.ciudadDestino,
                                                entidadBE.nrodoc,
                                              "NAC",
                                                 comprobante.CustomPerson.nombreCompleto,
                                              "3",
                                              "4",
                                              "5",
                                              "6",
                                              "7")
                Else
                    a.AnadirLineaCaracteresDatosGEnerales(comprobante.fechadoc,
                                                                   comprobante.ciudadOrigen,
                                                                  "GENERAL",
                                                                  "7:00",
                                                                  "14",
                                                                  "1",
                                                                  "2",
                                                                  comprobante.Remitente,
                                                                    comprobante.CustomPerson.idPersona,
                                                                   comprobante.ciudadDestino,
                                                                    entidadBE.nrodoc,
                                                                  "NAC",
                                                                     comprobante.comprador,
                                                                  "3",
                                                                  "4",
                                                                  "5",
                                                                  "6",
                                                                  "7")
                End If


                If (Not IsNothing(HASH)) Then
                        If HASH.Trim.Length > 0 Then
                            QR = (Gempresas.IdEmpresaRuc & "|" & comprobante.tipoDocumento.ToString & "|" & comprobante.serie & "|" & comprobante.numero & "|" & Format(comprobante.igv1, 2) &
                              "|" & comprobante.total & "|" & CDate(comprobante.fechadoc).Date.ToString(FormatoFecha) & "|" & entidadBE.tipoDoc & "|" & entidadBE.nrodoc &
                              "|" & HASH & "|" & CERTIFICADO)

                            QrCodeImgControl1.Text = QR
                        Else
                            QR = (Gempresas.IdEmpresaRuc & "|" & comprobante.tipoDocumento.ToString & "|" & comprobante.serie & "|" & comprobante.numero & "|" & Format(comprobante.igv1, 2) &
                             "|" & comprobante.total & "|" & CDate(comprobante.fechadoc).Date & "|" & entidadBE.tipoDoc & "|" & entidadBE.nrodoc)

                            QrCodeImgControl1.Text = QR
                        End If
                    End If

                    QR = (Gempresas.IdEmpresaRuc & "|" & comprobante.tipoDocumento.ToString & "|" & comprobante.serie & "|" & comprobante.numero & "|" & Format(comprobante.igv1, 2) &
                           "|" & comprobante.total & "|" & CDate(comprobante.fechadoc).Date.ToString(FormatoFecha) & "|" & entidadBE.tipoDoc & "|" & entidadBE.nrodoc)

                Else
                    Dim NBoletaElectronica As String = comprobante.comprador
                'ticket.TextoIzquierda(NBoletaElectronica)
                'Fecha de Factura
                'Lugar de la factura
                'Nombre del cliente
                'direccion del cliente
                'numero del cliente
                'direccion de entrega
                'tipo moneda de la empresa


                'a.AnadirLineaCaracteresDatosGEnerales(comprobante.fechadoc,
                '                                  nombreComprabante,
                '                                  comprobante.Remitente,
                '                                   comprobante.comprador,
                '                                   comprobante.ciudadOrigen,
                '                                  entidad.nrodoc,
                '                                  "PEN",
                '                                     comprobante.ciudadDestino)



                a.AnadirLineaCaracteresDatosGEnerales(comprobante.fechadoc,
                                               comprobante.ciudadOrigen,
                                              "GENERAL",
                                              "7:00",
                                              "14",
                                              "1",
                                              "2",
                                              comprobante.Remitente,
                                                comprobante.CustomPerson.idPersona,
                                               comprobante.ciudadDestino,
                                                entidadBE.nrodoc,
                                              "NAC",
                                                 comprobante.comprador,
                                              "3",
                                              "4",
                                              "5",
                                              "6",
                                              "7")

                QR = (Gempresas.IdEmpresaRuc & "|" & comprobante.tipoDocumento.ToString & "|" & comprobante.serie & "|" & comprobante.numero & "|" & Format(comprobante.igv1, 2) &
                        "|" & comprobante.total & "|" & CDate(comprobante.fechadoc).Date.ToString(FormatoFecha) & "|" & "VARIOS" & "|" & "0")

                QrCodeImgControl1.Text = QR
            End If



            For Each i In comprobante.documentoventaTransporteDetalle.ToList

                'Select Case i.destino
                '    Case OperacionGravada.Grabado
                'gravMN += CDec(i.B)
                'gravME += CDec(i.montokardexUS)

                '    Case OperacionGravada.Exonerado
                '        ExoMN += CDec(i.montokardex)
                '        ExoME += CDec(i.montokardexUS)

                '    Case OperacionGravada.Inafecto
                '        InaMN += CDec(i.montokardex)
                '        InaME += CDec(i.montokardexUS)
                'End Select

                precioUnit = (Math.Round(CDbl(i.importe / i.cantidad), 2))
                PrecioTotal = i.importe

                Select Case i.tipo
                    Case "CO"
                        a.AnadirLineaElementosFactura(i.cantidad, $"{"COSTAL"} {i.detalle}", "UND", "", precioUnit, PrecioTotal)
                    Case "P"
                        a.AnadirLineaElementosFactura(i.cantidad, $"{"PAQUETE"} {i.detalle}", "UND", "", precioUnit, PrecioTotal)

                    Case "S"
                        a.AnadirLineaElementosFactura(i.cantidad, $"{"SOBRE"} {i.detalle}", "UND", "", precioUnit, PrecioTotal)

                    Case "C"
                        a.AnadirLineaElementosFactura(i.cantidad, $"{"CAJA"} {i.detalle}", "UND", "", precioUnit, PrecioTotal)

                    Case "O"
                        a.AnadirLineaElementosFactura(i.cantidad, $"{"OTROS"} {i.detalle}", "UND", "", precioUnit, PrecioTotal)
                    Case Else
                        a.AnadirLineaElementosFactura(i.cantidad, $"{i.detalle}", "UND", "", precioUnit, PrecioTotal)
                End Select

                'a.AnadirElemento(i.monto1, i.unidad1, String.Format("{0:0.00}", precioUnit), String.Format("{0:0.00}", PrecioTotal), i.nombreItem)
                'a.AnadirNombreElemento(i.nombreItem)
            Next


            'a.AnadirDatosGenerales("S/", ExoMN)
            'a.AnadirDatosGenerales("S/", InaMN)
            a.AnadirDatosGenerales("S/", comprobante.baseImponible1)
            a.AnadirDatosGenerales("S/", comprobante.igv1)
            a.AnadirDatosGenerales("S/", String.Format("{0:0.00}", comprobante.total))

            a.headerImagenQR = QrCodeImgControl1.Image

            Dim consultaNombre = (From b In UsuariosList Where b.IDUsuario = usuario.IDUsuario).FirstOrDefault

            'a.AnadirLineaDatos("Vendedor: " & consultaNombre.Nombres & " " & consultaNombre.ApellidoPaterno & " " & consultaNombre.ApellidoMaterno, "Representacion impresa del comprobante", "http://www.softpack.com.pe")


            a.AnadirLineasDatosFinales("FECHA DE EMISION: " & DateTime.Now)
            a.AnadirLineasDatosFinales("CAJERO: " & consultaNombre.Nombres & " " & consultaNombre.ApellidoPaterno & " " & consultaNombre.ApellidoMaterno)

            a.AnadirLineasDatosFinales("")
            a.AnadirLineasDatosFinales("CONDICIONES DE TRANSPORTE DE ENCOMIENDA")
            a.AnadirLineasDatosFinales("1. La empresa no se responsabiliza por deterioro o")
            a.AnadirLineasDatosFinales("mermas por mal enbalaje o desconposiciòn de viveres")
            a.AnadirLineasDatosFinales("frutas (D.S. 24-83-TC)")
            a.AnadirLineasDatosFinales("2. La empresa no se hace responsable de objetos y/o")
            a.AnadirLineasDatosFinales("articulos no declarados.")
            a.AnadirLineasDatosFinales("3. El pago por la perdida de un bulto se hara de")
            a.AnadirLineasDatosFinales("acuerdo a la ley de ferrocarriles Art. 8 10 veces el")
            a.AnadirLineasDatosFinales("valor del flete pagado.")
            a.AnadirLineasDatosFinales("Autorizado mendiante resolución de SUNAT")
            a.AnadirLineasDatosFinales("Representación impresa puede ser consultado")
            a.AnadirLineasDatosFinales("http://www.spk.com.pe/")

            '//Y por ultimo llamamos al metodo PrintTicket para imprimir el ticket, este metodo necesita un 
            '//parametro de tipo string que debe de ser el nombre de la impresora. 
            a.ImprimeTicket(imprimir, "1")

        Catch ex As Exception
            'MessageBox.Show("Verifique su impresion")
            Close()
        End Try

    End Sub

    'Public Sub XmlFactura(comprobante As documentoventaTransporte, comprobanteDetalle As List(Of documentoventaTransporteDetalle))

    '    'Detalle de la Factura
    '    Dim DetalleItems As DetalleDocumento
    '    Dim ListaItems As New List(Of DetalleDocumento)

    '    Dim documentoSA As New documentoVentaAbarrotesSA
    '    Dim documentoDetSA As New documentoVentaAbarrotesDetSA

    '    Dim enti As New entidadSA

    '    Dim conteo As Integer = 0

    '    Dim tipoDoc As String = ""

    '    Dim documentoElectronico As New OpenInvoicePeru.Comun.Dto.Modelos.DocumentoElectronico

    '    'Dim comprobante = documentoSA.GetUbicar_documentoventaAbarrotesPorID(idDocumento)
    '    'Dim comprobanteDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(idDocumento)

    '    Dim receptor = enti.GetUbicarEntPorID(Gempresas.IdEmpresaRuc, comprobante.idPersona)

    '    Dim numerovent As String = String.Format("{0:00000000}", comprobante.numero)

    '    Dim fechaFact As DateTime = comprobante.fechadoc




    '    Try

    '        'Datos Cabezera Factura-------------------------------
    '        documentoElectronico.Emisor = CrearEmisor()

    '        'documentoElectronico.Receptor = CrearReceptor()
    '        documentoElectronico.Receptor.NroDocumento = receptor.nrodoc
    '        documentoElectronico.Receptor.TipoDocumento = receptor.tipoDoc
    '        documentoElectronico.Receptor.NombreLegal = receptor.nombreCompleto



    '        documentoElectronico.IdDocumento = comprobante.serie & "-" & numerovent

    '        'documentoElectronico.IdDocumento = documento.serieVenta & "-" & documento.numeroVenta

    '        documentoElectronico.FechaEmision = fechaFact.ToString(FormatoFecha)  ' documento.fechaDoc.Value.Year & "-" & String.Format("{0:00}", documento.fechaDoc.Value.Month) & "-" & String.Format("{0:00}", documento.fechaDoc.Value.Day)
    '        documentoElectronico.HoraEmision = fechaFact.ToString("HH:mm:ss")

    '        If comprobante.moneda = "1" Then
    '            documentoElectronico.Moneda = "PEN"
    '        ElseIf comprobante.moneda = "2" Then
    '            documentoElectronico.Moneda = "USD"
    '        End If

    '        tipoDoc = String.Format("{0:00}", comprobante.tipoDocumento)

    '        documentoElectronico.TipoDocumento = tipoDoc
    '        documentoElectronico.TotalIgv = comprobante.igv1
    '        documentoElectronico.TotalVenta = comprobante.total  'documento.bi01 + documento.bi02 
    '        documentoElectronico.Gravadas = comprobante.baseImponible1
    '        'documentoElectronico.Exoneradas = documento.bi02
    '        documentoElectronico.Exoneradas = comprobante.baseImponible2
    '        documentoElectronico.TipoOperacion = "0101" 'String.Format("{0:00}", documento.tipoOperacion)
    '        'documentoElectronico .Inafectas = "Falta"
    '        'documentoElectronico .Gratuitas = "falta"
    '        'documentoElectronico.DescuentoGlobal = "falta"
    '        'documentoElectronico .TotalIsc = "falta"
    '        'documentoElectronico .MontoPercepcion = "falta"
    '        'documentoElectronico.MontoDetraccion = "falta"
    '        'documentoElectronico .CalculoDetraccion = "falta"
    '        'documentoElectronico .TotalOtrosTributos = "falta"

    '        'Anexar con Anticipo
    '        'documentoElectronico.TipoDocAnticipo = "falta"
    '        'documentoElectronico.MonedaAnticipo = "falta"
    '        'documentoElectronico.MontoAnticipo = "falta"
    '        'documentoElectronico.DocAnticipo = "falta"

    '        'DatosGuiaTransportista
    '        'documentoElectronico.DatosGuiaTransportista = "Falta"

    '        'documentoElectronico.DatosGuiaTransportista.DireccionOrigen = "Datos Origen" tipo contribuyente
    '        'documentoElectronico.DatosGuiaTransportista.DireccionDestino = "Datos Destino" tipo contribuyente
    '        'documentoElectronico.DatosGuiaTransportista.RucTransportista = ""
    '        'documentoElectronico.DatosGuiaTransportista.TipoDocTransportista = ""
    '        'documentoElectronico.DatosGuiaTransportista.NombreTransportista = ""
    '        'documentoElectronico.DatosGuiaTransportista.NroLicenciaConducir = ""
    '        'documentoElectronico.DatosGuiaTransportista.PlacaVehiculo = ""
    '        'documentoElectronico.DatosGuiaTransportista.CodigoAutorizacion = ""
    '        'documentoElectronico.DatosGuiaTransportista.MarcaVehiculo = ""
    '        'documentoElectronico.DatosGuiaTransportista.ModoTransporte = ""
    '        'documentoElectronico.DatosGuiaTransportista.UnidadMedida = ""
    '        'documentoElectronico.DatosGuiaTransportista.PesoBruto = ""

    '        'Datos Detalle Factura---------------------------------------------
    '        For Each i In comprobanteDetalle
    '            conteo += 1

    '            DetalleItems = New DetalleDocumento
    '            DetalleItems.Id = conteo
    '            DetalleItems.Cantidad = i.cantidad
    '            DetalleItems.PrecioReferencial = i.importe 
    '            DetalleItems.CodigoItem = i.idItem
    '            DetalleItems.Descripcion = i.nombreItem
    '            DetalleItems.UnidadMedida = i.unidad1
    '            DetalleItems.Impuesto = i.montoIgv
    '            If i.destino = "1" Then
    '                DetalleItems.TipoImpuesto = "10" 'CATALOGO 7
    '                DetalleItems.TipoPrecio = "01" 'CATALOGO 16
    '                DetalleItems.PrecioUnitario = CalculoBaseImponible(i.precioUnitario, 1.18) 'FormatNumber(CalculoBaseImponible(i.precioUnitario, 1.18), 2)
    '            ElseIf i.destino = "2" Then
    '                DetalleItems.TipoImpuesto = "20" 'CATALOGO 7
    '                DetalleItems.TipoPrecio = "01" '"02"  'CATALOGO 16
    '                DetalleItems.PrecioUnitario = i.precioUnitario
    '            End If

    '            DetalleItems.TotalVenta = i.montokardex
    '            'DetalleItems .Descuento = "falta"
    '            'DetalleItems .ImpuestoSelectivo = "falta"
    '            'DetalleItems.OtroImpuesto = "falta"
    '            'DetalleItems.PlacaVehiculo = "falta"
    '            ListaItems.Add(DetalleItems)
    '        Next
    '        documentoElectronico.Items = ListaItems

    '        'Relacionar con Documentos como nota de credito nota debito
    '        'For Each 
    '        'DocRelacionado = New DocumentoRelacionado
    '        '    DocRelacionado.NroDocumento = "F001-1"
    '        '    DocRelacionado.TipoDocumento = "07"
    '        '    ListaDocRelacionado.Add(DocRelacionado)
    '        'Next
    '        'documentoElectronico.Relacionados = ListaDocRelacionado

    '        Dim documentoResponse = RestHelper(Of DocumentoElectronico, DocumentoResponse).Execute("GenerarFactura", documentoElectronico)

    '        If Not documentoResponse.Exito Then
    '            MessageBox.Show(documentoResponse.MensajeError)
    '            Exit Sub
    '        End If

    '        Dim firmado As New FirmadoRequest() With {
    '            .TramaXmlSinFirma = documentoResponse.TramaXmlSinFirma,
    '            .CertificadoDigital = Convert.ToBase64String(File.ReadAllBytes("C:\CERIFICADOSOFTPACK.pfx")),
    '            .PasswordCertificado = "7cZGKQsu4idgwzib"
    '        }

    '        Dim responseFirma = RestHelper(Of FirmadoRequest, FirmadoResponse).Execute("Firmar", firmado)

    '        If Not responseFirma.Exito Then
    '            Throw New InvalidOperationException(responseFirma.MensajeError)
    '        End If

    '        HASH = responseFirma.ResumenFirma
    '        CERTIFICADO = responseFirma.ValorFirma

    '        File.WriteAllBytes("C:\FACTURASELECTRONICAS\FACTURAS\" & documentoElectronico.Emisor.NroDocumento & "-" & tipoDoc & "-" & documentoElectronico.IdDocumento & ".xml", Convert.FromBase64String(responseFirma.TramaXmlFirmado))


    '        'MessageBox.Show("Se Genero Correctamente el xml")

    '    Catch ex As Exception
    '        MsgBox("Problemas con el servidor" & vbCrLf & ex.Message)
    '    End Try

    'End Sub

    'Function CrearEmisor() As Compania
    '    Dim Emisor As New Compania

    '    Emisor.NroDocumento = Gempresas.IdEmpresaRuc '"20603127278"
    '    Emisor.TipoDocumento = "6"
    '    Emisor.NombreComercial = Gempresas.NomEmpresa '"INVERSIONES SEÑOR DE ACORIA S.A.C."
    '    Emisor.NombreLegal = Gempresas.NomEmpresa '"INVERSIONES SEÑOR DE ACORIA S.A.C."
    '    Emisor.CodigoAnexo = "0001"

    '    Return Emisor

    'End Function

    Sub ImprimirTicketA4(imprimir As String, intIdDocumento As Integer, comprobante As documentoventaTransporte, entidad As entidad)
        'matricial
        'Dim a As TicketFormatoA5TransporteV2 = New TicketFormatoA5TransporteV2

        '
        Dim a As TicketFormatoA5Transporte = New TicketFormatoA5Transporte
        ' Logo de la Empresa
        a.HeaderImage = Image.FromFile("C:\LogoEmpresa\SELVATOURS.jpg")
        Dim lista As New List(Of String)

        Dim gravMN As Decimal = 0
        Dim gravME As Decimal = 0
        Dim ExoMN As Decimal = 0
        Dim ExoME As Decimal = 0
        Dim InaMN As Decimal = 0
        Dim InaME As Decimal = 0
        Dim ticket As New CrearTicket()
        Dim nombreComprabante As String
        ''  Dim r As Record = dgPedidos.Table.CurrentRecord
        'Dim entidadSA As New entidadSA
        'Dim documentoSA As New DocumentoventaTransporteSA
        ''Dim documentoDetSA As New documentoVentaAbarrotesDetSA
        'Dim comprobante = documentoSA.DocumentoTransporteSelID(New documentoventaTransporte With {.idDocumento = intIdDocumento})
        ''  Dim comprobanteDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(intIdDocumento)
        Dim tipoComprobante As String = String.Empty


        'Dim tipoComprobante As String

        'If comprobante.tipoDocumento = "01" And comprobante.tipoVenta = "VELC" Then
        '    XmlFactura(comprobante, comprobanteDetalle)
        'End If

        'Dim nombreCliente As String
        'Dim rucCliente As String
        'If (objDatosGenrales.logo.Length > 0) Then
        '    ' Logo de la Empresa
        '    a.HeaderImage = Image.FromFile(objDatosGenrales.logo)
        'End If

        'Select Case objDatosGenrales.logo.Length
        '    Case > 0
        '        If (objDatosGenrales.posicionLogo = "CT") Then
        '            If (objDatosGenrales.nombreImpresion = "C") Then
        '                a.tipoImagen = True
        '                a.tipoLogo = "CR"
        '            ElseIf (objDatosGenrales.nombreImpresion = "R") Then
        '                a.tipoImagen = False
        '                a.tipoLogo = "CR"
        '            End If
        '        ElseIf (objDatosGenrales.posicionLogo = "IZ") Then

        '            If (objDatosGenrales.nombreImpresion = "C") Then
        '                a.tipoImagen = True
        '                a.tipoLogo = "IZ"
        '            ElseIf (objDatosGenrales.nombreImpresion = "R") Then
        '                a.tipoImagen = False
        '                a.tipoLogo = "IZ"
        '            End If
        '        End If
        '    Case <= 0
        '        a.tipoLogo = "SL"
        'End Select



        ''Direccion de La empresa general
        'If (objDatosGenrales.tipoImpresion = "S") Then
        '    a.tipoEncabezado = True
        '    a.AnadirLineaEmpresa(objDatosGenrales.nombreCorto)
        '    a.AnadirLineaNombrePropietario(objDatosGenrales.razonSocial)
        'ElseIf (objDatosGenrales.tipoImpresion = "N") Then
        a.tipoEncabezado = False
        a.AnadirLineaEmpresa(Gempresas.NomEmpresa)

        'End If

        'If (objDatosGenrales.publicidad.Length > 0) Then
        '    a.tipoPublicidad = True
        '    a.AnadirLineaNombrePublidad(objDatosGenrales.publicidad)
        'Else
        '    a.tipoPublicidad = False
        'End If


        'Direccion de La empresa general




        'a.AnadirLineaEmpresa(objDatosGenrales.razonSocial)

        'If ((objDatosGenrales.nombreCorto).Count > 0) Then
        '    a.AnadirLineaNombrePropietario("De: " & objDatosGenrales.nombreCorto)
        'End If
        'direccion de la empresa
        a.TextoIzquierda("Domicilio Fiscal: " & "AV. FERROCARRIL N° 1587 HUANCAYO - HUANCAYO - JUNIN")
        'a.TextoIzquierda("Establ. Anexo: " & objDatosGenrales.direccionSecudaria)
        'Telefono de la empresa
        a.TextoIzquierda("Telf: " & "-")
        a.TextoIzquierda("")

        'a.AnadirLineaEmpresa(Gempresas.NomEmpresa)
        ''Telefono de la empresa
        'a.TextoIzquierda(Gempresas.direccionEmpresa)
        ''direccion de la empresa
        'a.TextoIzquierda(Gempresas.TelefonoEmpresa)
        'a.TextoIzquierda("")

        Select Case comprobante.tipoDocumento
            Case "12.1"
                'ticket.TextoExtremos("Caja # 1", "Ticket boleta # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                a.AnadirLineaCaracteresFactura(Gempresas.IdEmpresaRuc, comprobante.serie & " - " & CStr(comprobante.numero).PadLeft(8, "0"c), "BOLETA")
                'ticket.TextoIzquierda("Ticket Boleta # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                nombreComprabante = "BOLETA" & comprobante.serie & comprobante.numero
                tipoComprobante = "1"
            Case "12.2"
                '  ticket.TextoExtremos("Caja # 1", "Ticket factura # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                'ticket.TextoIzquierda("Ticket Factura # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                a.AnadirLineaCaracteresFactura(Gempresas.IdEmpresaRuc, comprobante.serie & " - " & CStr(comprobante.numero).PadLeft(8, "0"c), "FACTURA")
                nombreComprabante = "FACTURA" & comprobante.serie & comprobante.numero
                tipoComprobante = "1"
            Case "03"

                a.AnadirLineaCaracteresFactura(Gempresas.IdEmpresaRuc, comprobante.serie & " - " & CStr(comprobante.numero).PadLeft(8, "0"c), "BOLETA ELECTRONICA")
                nombreComprabante = "FACTURA" & comprobante.serie & comprobante.numero
                tipoComprobante = "2"

            Case "01"
                a.AnadirLineaCaracteresFactura(Gempresas.IdEmpresaRuc, comprobante.serie & " - " & CStr(comprobante.numero).PadLeft(8, "0"c), "FACTURA ELECTRONICA")
                nombreComprabante = "FACTURA" & comprobante.serie & comprobante.numero
                tipoComprobante = "2"

            Case "9901"
                a.AnadirLineaCaracteresFactura(Gempresas.IdEmpresaRuc, 0 & " - " & CStr(0).PadLeft(8, "0"c), "PROFORMA")
                nombreComprabante = "PROFORMA" & comprobante.serie & comprobante.numero
                tipoComprobante = "1"
            Case Else

                a.AnadirLineaCaracteresFactura(Gempresas.IdEmpresaRuc, comprobante.serie & " - " & CStr(comprobante.numero).PadLeft(8, "0"c), "NOTA")
                nombreComprabante = "NOTA" & comprobante.serie & comprobante.numero
                tipoComprobante = "1"
        End Select

        'a.TextoDerecha("RUC: " & "12345678911")
        'Numero de Ruc y Numeracion

        If comprobante.Consignado IsNot Nothing Then

            Dim NBoletaElectronica As String = entidad.nombreCompleto
            Dim nBoletaNumero As String
            'ticket.TextoIzquierda(NBoletaElectronica)
            If entidad.nrodoc.Trim.Length = 11 Then
                nBoletaNumero = "R.U.C. - " & entidad.nrodoc
            ElseIf entidad.nrodoc.Trim.Length = 8 Then
                nBoletaNumero = "D.N.I. - " & entidad.nrodoc
            Else
                nBoletaNumero = entidad.nrodoc
            End If
            'Fecha de Factura
            'LUGAR DE DESTINO
            'Nombre del REMITENTE
            'Nombre del CONSIGNADO
            'DNI CONSIGNADO
            'DNI REMITENTE
            'tipo moneda de la empresa
            'LUGAR DE ORIGEN


            a.AnadirLineaCaracteresDatosGEnerales(comprobante.fechadoc,
                                                  comprobante.ciudadDestino,
                                                  comprobante.Remitente,
                                                  comprobante.Consignado,
                                                 entidad.direccion,
                                                  entidad.nrodoc,
                                                  "PEN",
                                                  comprobante.ciudadOrigen)

            'If (Not IsNothing(HASH)) Then
            '    If HASH.Trim.Length > 0 Then
            '        QR = (Gempresas.IdEmpresaRuc & "|" & comprobante.tipoDocumento.ToString & "|" & comprobante.serieVenta & "|" & comprobante.numeroVenta & "|" & Format(comprobante.igv01, 2) &
            '              "|" & comprobante.ImporteNacional & "|" & CDate(comprobante.fechaDoc).Date.ToString(FormatoFecha) & "|" & entidad.tipoDoc & "|" & entidad.nrodoc &
            '              "|" & HASH & "|" & CERTIFICADO)

            '        QrCodeImgControl1.Text = QR
            '    Else
            '        QR = (Gempresas.IdEmpresaRuc & "|" & comprobante.tipoDocumento.ToString & "|" & comprobante.serieVenta & "|" & comprobante.numeroVenta & "|" & Format(comprobante.igv01, 2) &
            '             "|" & comprobante.ImporteNacional & "|" & CDate(comprobante.fechaDoc).Date.ToString(FormatoFecha) & "|" & entidad.tipoDoc & "|" & entidad.nrodoc)

            '        QrCodeImgControl1.Text = QR
            '    End If
            'Else
            '    QR = (Gempresas.IdEmpresaRuc & "|" & comprobante.tipoDocumento.ToString & "|" & comprobante.serieVenta & "|" & comprobante.numeroVenta & "|" & Format(comprobante.igv01, 2) &
            '         "|" & comprobante.ImporteNacional & "|" & CDate(comprobante.fechaDoc).Date.ToString(FormatoFecha) & "|" & entidad.tipoDoc & "|" & entidad.nrodoc)

            '    QrCodeImgControl1.Text = QR
            'End If


        Else
            Dim NBoletaElectronica As String = comprobante.comprador
            'ticket.TextoIzquierda(NBoletaElectronica)
            'Fecha de Factura
            'Lugar de la factura
            'Nombre del cliente
            'direccion del cliente
            'numero del cliente
            'direccion de entrega
            'tipo moneda de la empresa
            'telefono de la empresa
            a.AnadirLineaCaracteresDatosGEnerales(comprobante.fechadoc,
                                                  comprobante.ciudadDestino,
                                                  comprobante.Remitente,
                                                  comprobante.comprador,
                                                  entidad.direccion,
                                                  entidad.nrodoc,
                                                  "PEN",
                                                  comprobante.ciudadOrigen)

            ''Codigo qr
            'QR = (Gempresas.IdEmpresaRuc & "|" & comprobante.tipoDocumento.ToString & "|" & comprobante.serieVenta & "|" & comprobante.numeroVenta & "|" & Format(comprobante.igv01, 2) &
            '          "|" & comprobante.ImporteNacional & "|" & CDate(comprobante.fechaDoc).Date.ToString(FormatoFecha) & "|" & "VARIOS" & "|" & "0")

            'QrCodeImgControl1.Text = QR
        End If

        '*********************** TODO LOS DETALLES DE LOS ITEM *********************
        'CODIGO
        'DESCRIPCION
        'CANTIDAD
        'UM
        'VALOR VENTA UNITARIO
        'DESCUENTO
        'VALOR DE VENTA TOTAL
        'OTROS CARGOS
        'IMPUESTOS
        'PRECIO DE VENTA
        'VALOR TOTAL
        Dim baseImponible = 0
        Dim igv = 0
        Dim tipo As String = String.Empty
        For Each i In comprobante.documentoventaTransporteDetalle.ToList

            'baseImponible = Math.Round(CDec(CalculoBaseImponible(i.importe, 1.18)), 2)
            'igv = Math.Round(CDec(i.importe - baseImponible), 2)
            Select Case i.tipo
                Case "P"
                    tipo = "PAQUETE"
                Case "C"
                    tipo = "CAJA"
                Case "S"
                    tipo = "SOBRE"
                Case "CO"
                    tipo = "COSTAL"
                Case "O"
                    tipo = "OTRO"
            End Select

            a.AnadirLineaElementosFactura(
                tipo,
                i.detalle,
                i.cantidad,
                i.unidadMedida, 0,
                "0.00", 0, "0.00", 0, i.importe / i.cantidad, i.importe)
            'ticket.AgregaArticuloV2(i.nombreItem, String.Format("{0:0.00}", i.monto1), String.Format("{0:0.00}", i.importeMN / i.monto1), i.importeMN)
        Next

        '********************************** RESUMEN GENERAL DE LA FACTURA **************************
        'GRATUITAS
        a.AnadirDatosGenerales("S/", "0.00")
        'EXONERADAS
        a.AnadirDatosGenerales("S/", "0.00")
        'INAFECTA
        a.AnadirDatosGenerales("S/", "0.00")
        'GRAVADA
        a.AnadirDatosGenerales("S/", comprobante.baseImponible1)
        'TOTAL DESCUENTO
        a.AnadirDatosGenerales("S/", "0.00")
        'I.S.C.
        a.AnadirDatosGenerales("S/", "0.00")
        'I.G.V
        a.AnadirDatosGenerales("S/", comprobante.igv1)
        'IMPORTE TOTAL
        a.AnadirDatosGenerales("S/", comprobante.total)
        'DESCRIPCION DEL IMPORTE TOTAL EN LETRAS
        'a.AnadirLineaTotalFactura(comprobante.total)
        'IMPRIMIR LA FACTUIRA


        Select Case tipoComprobante
            Case "1"
                a.tipoComprobante = "1"
                'enviarCorreo("maych_1@hotmail.com", "maykol_1_1_1", "maych_1@hotmail.com", "Texto Prueba", "Factura", "", NombreNumero)
                'a.GuardanImpresion("Microsoft Print to PDF", nombreComprabante, "maych_1@hotmail.com", "maykol_1_1_1", "maych_1@hotmail.com", "Texto Prueba", "Factura")
                a.ImprimeTicket(imprimir)
            Case "2"
                a.tipoComprobante = "2"
                'enviarCorreo("maych_1@hotmail.com", "maykol_1_1_1", "maych_1@hotmail.com", "Texto Prueba", "Factura", "", NombreNumero)
                'a.GuardanImpresion("Microsoft Print to PDF", nombreComprabante, "maych_1@hotmail.com", "maykol_1_1_1", "maych_1@hotmail.com", "Texto Prueba", "Factura")
                a.ImprimeTicket(imprimir)
        End Select

    End Sub
    Sub ImprimirTicketA4v2(imprimir As String, intIdDocumento As Integer, comprobante As documentoventaTransporte, entidad As entidad)
        'Dim a As TicketFormatoA5Transporte = New TicketFormatoA5Transporte
        Dim a As TicketFormatoA5TransporteV2 = New TicketFormatoA5TransporteV2
        ' Logo de la Empresa
        a.HeaderImage = Image.FromFile("C:\LogoEmpresa\SELVATOURS_NEGRO.jpg")
        Dim lista As New List(Of String)

        Dim gravMN As Decimal = 0
        Dim gravME As Decimal = 0
        Dim ExoMN As Decimal = 0
        Dim ExoME As Decimal = 0
        Dim InaMN As Decimal = 0
        Dim InaME As Decimal = 0
        Dim ticket As New CrearTicket()
        Dim nombreComprabante As String
        ''  Dim r As Record = dgPedidos.Table.CurrentRecord
        'Dim entidadSA As New entidadSA
        'Dim documentoSA As New DocumentoventaTransporteSA
        ''Dim documentoDetSA As New documentoVentaAbarrotesDetSA
        'Dim comprobante = documentoSA.DocumentoTransporteSelID(New documentoventaTransporte With {.idDocumento = intIdDocumento})
        ''  Dim comprobanteDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(intIdDocumento)
        Dim tipoComprobante As String = String.Empty


        'Dim tipoComprobante As String

        'If comprobante.tipoDocumento = "01" And comprobante.tipoVenta = "VELC" Then
        '    XmlFactura(comprobante, comprobanteDetalle)
        'End If

        'Dim nombreCliente As String
        'Dim rucCliente As String
        'If (objDatosGenrales.logo.Length > 0) Then
        '    ' Logo de la Empresa
        '    a.HeaderImage = Image.FromFile(objDatosGenrales.logo)
        'End If

        'Select Case objDatosGenrales.logo.Length
        '    Case > 0
        '        If (objDatosGenrales.posicionLogo = "CT") Then
        '            If (objDatosGenrales.nombreImpresion = "C") Then
        '                a.tipoImagen = True
        '                a.tipoLogo = "CR"
        '            ElseIf (objDatosGenrales.nombreImpresion = "R") Then
        '                a.tipoImagen = False
        '                a.tipoLogo = "CR"
        '            End If
        '        ElseIf (objDatosGenrales.posicionLogo = "IZ") Then

        '            If (objDatosGenrales.nombreImpresion = "C") Then
        '                a.tipoImagen = True
        '                a.tipoLogo = "IZ"
        '            ElseIf (objDatosGenrales.nombreImpresion = "R") Then
        '                a.tipoImagen = False
        '                a.tipoLogo = "IZ"
        '            End If
        '        End If
        '    Case <= 0
        '        a.tipoLogo = "SL"
        'End Select



        ''Direccion de La empresa general
        'If (objDatosGenrales.tipoImpresion = "S") Then
        '    a.tipoEncabezado = True
        '    a.AnadirLineaEmpresa(objDatosGenrales.nombreCorto)
        '    a.AnadirLineaNombrePropietario(objDatosGenrales.razonSocial)
        'ElseIf (objDatosGenrales.tipoImpresion = "N") Then
        a.tipoEncabezado = False
        a.AnadirLineaEmpresa(Gempresas.NomEmpresa)

        'End If

        'If (objDatosGenrales.publicidad.Length > 0) Then
        '    a.tipoPublicidad = True
        '    a.AnadirLineaNombrePublidad(objDatosGenrales.publicidad)
        'Else
        '    a.tipoPublicidad = False
        'End If


        'Direccion de La empresa general




        'a.AnadirLineaEmpresa(objDatosGenrales.razonSocial)

        'If ((objDatosGenrales.nombreCorto).Count > 0) Then
        '    a.AnadirLineaNombrePropietario("De: " & objDatosGenrales.nombreCorto)
        'End If
        'direccion de la empresa
        a.TextoIzquierda("Domicilio Fiscal: " & "AV. FERROCARRIL N° 1587 HUANCAYO - HUANCAYO - JUNIN")
        'a.TextoIzquierda("Establ. Anexo: " & objDatosGenrales.direccionSecudaria)
        'Telefono de la empresa
        a.TextoIzquierda("Telf: " & "-")
        a.TextoIzquierda("")

        'a.AnadirLineaEmpresa(Gempresas.NomEmpresa)
        ''Telefono de la empresa
        'a.TextoIzquierda(Gempresas.direccionEmpresa)
        ''direccion de la empresa
        'a.TextoIzquierda(Gempresas.TelefonoEmpresa)
        'a.TextoIzquierda("")

        Select Case comprobante.tipoDocumento
            Case "12.1"
                'ticket.TextoExtremos("Caja # 1", "Ticket boleta # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                a.AnadirLineaCaracteresFactura(Gempresas.IdEmpresaRuc, comprobante.serie & " - " & CStr(comprobante.numero).PadLeft(8, "0"c), "BOLETA")
                'ticket.TextoIzquierda("Ticket Boleta # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                nombreComprabante = "BOLETA" & comprobante.serie & comprobante.numero
                tipoComprobante = "1"
            Case "12.2"
                '  ticket.TextoExtremos("Caja # 1", "Ticket factura # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                'ticket.TextoIzquierda("Ticket Factura # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                a.AnadirLineaCaracteresFactura(Gempresas.IdEmpresaRuc, comprobante.serie & " - " & CStr(comprobante.numero).PadLeft(8, "0"c), "FACTURA")
                nombreComprabante = "FACTURA" & comprobante.serie & comprobante.numero
                tipoComprobante = "1"
            Case "03"

                a.AnadirLineaCaracteresFactura(Gempresas.IdEmpresaRuc, comprobante.serie & " - " & CStr(comprobante.numero).PadLeft(8, "0"c), "BOLETA ELECTRONICA")
                nombreComprabante = "FACTURA" & comprobante.serie & comprobante.numero
                tipoComprobante = "2"

            Case "01"
                a.AnadirLineaCaracteresFactura(Gempresas.IdEmpresaRuc, comprobante.serie & " - " & CStr(comprobante.numero).PadLeft(8, "0"c), "FACTURA ELECTRONICA")
                nombreComprabante = "FACTURA" & comprobante.serie & comprobante.numero
                tipoComprobante = "2"

            Case "9901"
                a.AnadirLineaCaracteresFactura(Gempresas.IdEmpresaRuc, 0 & " - " & CStr(0).PadLeft(8, "0"c), "PROFORMA")
                nombreComprabante = "PROFORMA" & comprobante.serie & comprobante.numero
                tipoComprobante = "1"
            Case Else

                a.AnadirLineaCaracteresFactura(Gempresas.IdEmpresaRuc, comprobante.serie & " - " & CStr(comprobante.numero).PadLeft(8, "0"c), "NOTA")
                nombreComprabante = "NOTA" & comprobante.serie & comprobante.numero
                tipoComprobante = "1"
        End Select

        'a.TextoDerecha("RUC: " & "12345678911")
        'Numero de Ruc y Numeracion

        If comprobante.Consignado IsNot Nothing Then

            Dim NBoletaElectronica As String = entidad.nombreCompleto
            Dim nBoletaNumero As String
            'ticket.TextoIzquierda(NBoletaElectronica)
            If entidad.nrodoc.Trim.Length = 11 Then
                nBoletaNumero = "R.U.C. - " & entidad.nrodoc
            ElseIf entidad.nrodoc.Trim.Length = 8 Then
                nBoletaNumero = "D.N.I. - " & entidad.nrodoc
            Else
                nBoletaNumero = entidad.nrodoc
            End If
            'Fecha de Factura
            'LUGAR DE DESTINO
            'Nombre del REMITENTE
            'Nombre del CONSIGNADO
            'DNI CONSIGNADO
            'DNI REMITENTE
            'tipo moneda de la empresa
            'LUGAR DE ORIGEN


            a.AnadirLineaCaracteresDatosGEnerales(comprobante.fechadoc,
                                                  comprobante.ciudadDestino,
                                                  comprobante.Remitente,
                                                  comprobante.Consignado,
                                                 entidad.direccion,
                                                  entidad.nrodoc,
                                                  "PEN",
                                                  comprobante.ciudadOrigen)

            'If (Not IsNothing(HASH)) Then
            '    If HASH.Trim.Length > 0 Then
            '        QR = (Gempresas.IdEmpresaRuc & "|" & comprobante.tipoDocumento.ToString & "|" & comprobante.serieVenta & "|" & comprobante.numeroVenta & "|" & Format(comprobante.igv01, 2) &
            '              "|" & comprobante.ImporteNacional & "|" & CDate(comprobante.fechaDoc).Date.ToString(FormatoFecha) & "|" & entidad.tipoDoc & "|" & entidad.nrodoc &
            '              "|" & HASH & "|" & CERTIFICADO)

            '        QrCodeImgControl1.Text = QR
            '    Else
            '        QR = (Gempresas.IdEmpresaRuc & "|" & comprobante.tipoDocumento.ToString & "|" & comprobante.serieVenta & "|" & comprobante.numeroVenta & "|" & Format(comprobante.igv01, 2) &
            '             "|" & comprobante.ImporteNacional & "|" & CDate(comprobante.fechaDoc).Date.ToString(FormatoFecha) & "|" & entidad.tipoDoc & "|" & entidad.nrodoc)

            '        QrCodeImgControl1.Text = QR
            '    End If
            'Else
            '    QR = (Gempresas.IdEmpresaRuc & "|" & comprobante.tipoDocumento.ToString & "|" & comprobante.serieVenta & "|" & comprobante.numeroVenta & "|" & Format(comprobante.igv01, 2) &
            '         "|" & comprobante.ImporteNacional & "|" & CDate(comprobante.fechaDoc).Date.ToString(FormatoFecha) & "|" & entidad.tipoDoc & "|" & entidad.nrodoc)

            '    QrCodeImgControl1.Text = QR
            'End If


        Else
            Dim NBoletaElectronica As String = comprobante.comprador
            'ticket.TextoIzquierda(NBoletaElectronica)
            'Fecha de Factura
            'Lugar de la factura
            'Nombre del cliente
            'direccion del cliente
            'numero del cliente
            'direccion de entrega
            'tipo moneda de la empresa
            'telefono de la empresa
            a.AnadirLineaCaracteresDatosGEnerales(comprobante.fechadoc,
                                                  comprobante.ciudadDestino,
                                                  comprobante.Remitente,
                                                  comprobante.comprador,
                                                  entidad.direccion,
                                                  entidad.nrodoc,
                                                  "PEN",
                                                  comprobante.ciudadOrigen)

            ''Codigo qr
            'QR = (Gempresas.IdEmpresaRuc & "|" & comprobante.tipoDocumento.ToString & "|" & comprobante.serieVenta & "|" & comprobante.numeroVenta & "|" & Format(comprobante.igv01, 2) &
            '          "|" & comprobante.ImporteNacional & "|" & CDate(comprobante.fechaDoc).Date.ToString(FormatoFecha) & "|" & "VARIOS" & "|" & "0")

            'QrCodeImgControl1.Text = QR
        End If

        '*********************** TODO LOS DETALLES DE LOS ITEM *********************
        'CODIGO
        'DESCRIPCION
        'CANTIDAD
        'UM
        'VALOR VENTA UNITARIO
        'DESCUENTO
        'VALOR DE VENTA TOTAL
        'OTROS CARGOS
        'IMPUESTOS
        'PRECIO DE VENTA
        'VALOR TOTAL
        Dim baseImponible = 0
        Dim igv = 0
        Dim tipo As String = String.Empty
        For Each i In comprobante.documentoventaTransporteDetalle.ToList

            'baseImponible = Math.Round(CDec(CalculoBaseImponible(i.importe, 1.18)), 2)
            'igv = Math.Round(CDec(i.importe - baseImponible), 2)
            Select Case i.tipo
                Case "P"
                    tipo = "PAQUETE"
                Case "C"
                    tipo = "CAJA"
                Case "S"
                    tipo = "SOBRE"
                Case "CO"
                    tipo = "COSTAL"
                Case "O"
                    tipo = "OTRO"
            End Select

            a.AnadirLineaElementosFactura(
                tipo,
                i.detalle,
                i.cantidad,
                i.unidadMedida, 0,
                "0.00", 0, "0.00", 0, i.importe / i.cantidad, i.importe)
            'ticket.AgregaArticuloV2(i.nombreItem, String.Format("{0:0.00}", i.monto1), String.Format("{0:0.00}", i.importeMN / i.monto1), i.importeMN)
        Next

        '********************************** RESUMEN GENERAL DE LA FACTURA **************************
        'GRATUITAS
        a.AnadirDatosGenerales("S/", "0.00")
        'EXONERADAS
        a.AnadirDatosGenerales("S/", "0.00")
        'INAFECTA
        a.AnadirDatosGenerales("S/", "0.00")
        'GRAVADA
        a.AnadirDatosGenerales("S/", comprobante.baseImponible1)
        'TOTAL DESCUENTO
        a.AnadirDatosGenerales("S/", "0.00")
        'I.S.C.
        a.AnadirDatosGenerales("S/", "0.00")
        'I.G.V
        a.AnadirDatosGenerales("S/", comprobante.igv1)
        'IMPORTE TOTAL
        a.AnadirDatosGenerales("S/", comprobante.total)
        'DESCRIPCION DEL IMPORTE TOTAL EN LETRAS
        'a.AnadirLineaTotalFactura(comprobante.total)
        'IMPRIMIR LA FACTUIRA


        Select Case tipoComprobante
            Case "1"
                a.tipoComprobante = "1"
                'enviarCorreo("maych_1@hotmail.com", "maykol_1_1_1", "maych_1@hotmail.com", "Texto Prueba", "Factura", "", NombreNumero)
                'a.GuardanImpresion("Microsoft Print to PDF", nombreComprabante, "maych_1@hotmail.com", "maykol_1_1_1", "maych_1@hotmail.com", "Texto Prueba", "Factura")
                a.ImprimeTicket(imprimir)
            Case "2"
                a.tipoComprobante = "2"
                'enviarCorreo("maych_1@hotmail.com", "maykol_1_1_1", "maych_1@hotmail.com", "Texto Prueba", "Factura", "", NombreNumero)
                'a.GuardanImpresion("Microsoft Print to PDF", nombreComprabante, "maych_1@hotmail.com", "maykol_1_1_1", "maych_1@hotmail.com", "Texto Prueba", "Factura")
                a.ImprimeTicket(imprimir)
        End Select

    End Sub


    Public Function ListaPagosCajas(venta As documentoventaTransporte, envio As EnvioImpresionVendedorPernos) As List(Of documento)
        Dim nDocumentoCaja As New documento
        Dim objCaja As New documentoCaja
        Dim ListaDoc As New List(Of documento)
        For Each i In dgvCuentas.Table.Records
            If Decimal.Parse(i.GetValue("abonado")) > 0 Then
                nDocumentoCaja = New documento
                nDocumentoCaja.idDocumento = 0 'CInt(Me.Tag)
                nDocumentoCaja.idEmpresa = Gempresas.IdEmpresaRuc
                nDocumentoCaja.idCentroCosto = ComboAgenciaOrigen.SelectedValue
                nDocumentoCaja.tipoDoc = venta.tipoDocumento ' cbotipoDocPago.SelectedValue
                nDocumentoCaja.fechaProceso = txtFechaVenta.Value
                nDocumentoCaja.nroDoc = conf.Serie
                nDocumentoCaja.idOrden = Nothing
                nDocumentoCaja.moneda = If(cboMoneda.Text = "NACIONAL", "1", "2")

                nDocumentoCaja.idEntidad = venta.idPersona
                nDocumentoCaja.entidad = venta.comprador
                nDocumentoCaja.nrodocEntidad = TextNumIdent.Text

                nDocumentoCaja.tipoEntidad = TIPO_ENTIDAD.CLIENTE
                nDocumentoCaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES
                nDocumentoCaja.usuarioActualizacion = envio.IDCaja ' usuario.IDUsuario
                nDocumentoCaja.fechaActualizacion = DateTime.Now


                'DOCUMENTO CAJA
                objCaja = New documentoCaja
                objCaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES
                objCaja.idDocumento = 0
                objCaja.periodo = GetPeriodo(venta.fechadoc, True)
                objCaja.idEmpresa = Gempresas.IdEmpresaRuc
                objCaja.idEstablecimiento = ComboAgenciaOrigen.SelectedValue
                objCaja.fechaProceso = txtFechaVenta.Value
                objCaja.fechaCobro = txtFechaVenta.Value
                objCaja.tipoMovimiento = TIPO_VENTA.PAGO.COBRADO

                objCaja.codigoProveedor = venta.idPersona
                objCaja.IdProveedor = venta.idPersona
                objCaja.idPersonal = venta.idPersona

                objCaja.TipoDocumentoPago = venta.tipoDocumento 'cbotipoDocPago.SelectedValue
                objCaja.codigoLibro = "1"
                objCaja.tipoDocPago = venta.tipoDocumento
                objCaja.formapago = i.GetValue("idforma")
                objCaja.NumeroDocumento = "-"
                Dim numeroop = i.GetValue("nrooperacion")

                If numeroop.ToString.Trim.Length > 0 Then
                    objCaja.numeroOperacion = i.GetValue("nrooperacion")
                End If


                If i.GetValue("idforma") = "006" Or i.GetValue("idforma") = "007" Then
                    objCaja.estadopago = 1

                End If
                objCaja.movimientoCaja = TIPO_VENTA.VENTA_ENCOMIENDAS
                objCaja.montoSoles = Decimal.Parse(i.GetValue("abonado"))

                objCaja.moneda = If(cboMoneda.Text = "NACIONAL", "1", "2")
                objCaja.tipoCambio = TmpTipoCambio
                objCaja.montoUsd = Decimal.Parse(objCaja.montoSoles / TmpTipoCambio)

                objCaja.estado = "1"
                objCaja.glosa = "Por ventas de pasajes"
                objCaja.entregado = "SI"

                objCaja.entidadFinanciera = i.GetValue("identidad")
                objCaja.NombreEntidad = i.GetValue("entidad")
                objCaja.idCajaUsuario = envio.IDCaja 'GFichaUsuarios.IdCajaUsuario
                objCaja.usuarioModificacion = envio.IDCaja 'usuario.IDUsuario


                objCaja.fechaModificacion = DateTime.Now
                nDocumentoCaja.documentoCaja = objCaja
                nDocumentoCaja.documentoCaja.documentoCajaDetalle = GetDetallePago(objCaja, venta, envio)
                ' asientoDocumento(nDocumentoCaja.documentoCaja)
                ListaDoc.Add(nDocumentoCaja)
            End If
        Next

        Return ListaDoc
    End Function

    Private Function GetDetallePago(objCaja As documentoCaja, i As documentoventaTransporte, envio As EnvioImpresionVendedorPernos) As List(Of documentoCajaDetalle)

        Dim montoPago = objCaja.montoSoles
        GetDetallePago = New List(Of documentoCajaDetalle)
        GetDetallePago.Add(New documentoCajaDetalle With
                               {
                               .fecha = Date.Now,
                               .codigoLote = 0,
                               .otroMN = 0,
                               .idItem = i.numeroAsiento,
                               .DetalleItem = "VENTA ENCOMIENDAS",
                               .montoSoles = i.total,
                               .montoUsd = FormatNumber(i.total / TmpTipoCambio, 2),
                               .diferTipoCambio = TmpTipoCambio,
                               .tipoCambioTransacc = TmpTipoCambio,
                               .entregado = "SI",
                               .idCajaUsuario = envio.IDCaja,
                               .usuarioModificacion = envio.IDCaja,' usuario.IDUsuario,
                               .documentoAfectado = 0,'CInt(Me.Tag),
                               .documentoAfectadodetalle = 0,
                               .EstadoCobro = "DC",
                               .fechaModificacion = DateTime.Now
                               })

    End Function

    Private Sub TextRaZonSocial_TextChanged(sender As Object, e As EventArgs) Handles TextRaZonSocial.TextChanged

    End Sub

    Private Sub ComboAgenciaOrigen_Click(sender As Object, e As EventArgs) Handles ComboAgenciaOrigen.Click

    End Sub

    Private Sub ComboAgenciaOrigen_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboAgenciaOrigen.SelectedValueChanged
        Try
            If IsNumeric(ComboAgenciaOrigen.SelectedValue) Then

                'Dim ListaRutas As New List(Of Integer)

                'ListaRutas.Add(14)
                'ListaRutas.Add(12)
                'ListaRutas.Add(7)
                ''ListaRutas.Add(6)
                'ListaRutas.Add(5)
                'ListaRutas.Add(3)
                'ListaRutas.Add(9)

                Dim lista = ListaAgencias.Where(Function(o) o.TipoEstab = "UN" And o.idCentroCosto <> ComboAgenciaOrigen.SelectedValue).ToList

                ''//pichanaqui
                'Dim lista = ListaAgencias.Where(Function(o) o.TipoEstab = "UN" And Not ListaRutas.Contains(o.idCentroCosto)).ToList

                ComboAgenciaDestino.DataSource = lista
                ComboAgenciaDestino.DisplayMember = "nombre"
                ComboAgenciaDestino.ValueMember = "idCentroCosto"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub ComboTipo_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboTipo.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            TextDetalleEnvio.SelectAll()
            TextDetalleEnvio.Focus()
        End If
    End Sub

    Private Sub txtCant_TextChanged(sender As Object, e As EventArgs) Handles txtCant.TextChanged

    End Sub

    Private Sub txtCant_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCant.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            ComboTipo.Select()
            ComboTipo.Focus()
            ComboTipo.DroppedDown = True
        End If
    End Sub

    Private Sub TextDetalleEnvio_TextChanged(sender As Object, e As EventArgs) Handles TextDetalleEnvio.TextChanged

    End Sub

    Private Sub TextDetalleEnvio_KeyDown(sender As Object, e As KeyEventArgs) Handles TextDetalleEnvio.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            TExtTotal.SelectAll()
            TExtTotal.Focus()
        End If
    End Sub

    Private Sub TExtTotal_TextChanged(sender As Object, e As EventArgs) Handles TExtTotal.TextChanged

    End Sub

    Private Sub TExtTotal_KeyDown(sender As Object, e As KeyEventArgs) Handles TExtTotal.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            'RoundButton21.PerformClick()
            AgregarItemButton()
        End If
    End Sub

    Private Sub TextNumIdentrazon_TextChanged(sender As Object, e As EventArgs) Handles TextNumIdentrazon.TextChanged

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


                        Dim existeEnDB2 = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", TextNumIdentrazon.Text.Trim)
                        If existeEnDB2 Is Nothing Then



                            If My.Computer.Network.IsAvailable = True Then
                                PictureLoad.Visible = True
                                'nombres = GetConsultarDNIReniec(TextNumIdentrazon.Text.Trim)
                                nombres = GetConsultarDNIReniecVER2(TextNumIdentrazon.Text.Trim)

                                If nombres.Trim.Length > 0 Then

                                    If nombres = "DNI no encontrado en Padrón Electoral" Then
                                        TextNumIdentrazon.Clear()
                                        TextEmpresaPasajero.Text = String.Empty
                                        TextEmpresaPasajero.Tag = Nothing
                                        PictureLoad.Visible = False
                                        Exit Sub
                                    End If

                                    SelRazon.tipoEntidad = "CL"
                                    SelRazon.nombreCompleto = nombres
                                    SelRazon.nrodoc = TextNumIdentrazon.Text.Trim
                                    SelRazon.tipoDoc = "1"
                                    SelRazon.tipoPersona = "N"
                                    TextEmpresaPasajero.Text = nombres

                                    Dim existeEnDB = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", TextNumIdentrazon.Text.Trim)

                                    If existeEnDB Is Nothing Then
                                        TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                        GrabarEntidadRapida()
                                        PictureLoad.Visible = False
                                    Else
                                        TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                        TextEmpresaPasajero.Tag = existeEnDB.idEntidad
                                        If RadioButton2.Checked = True Then
                                            textPersona.Focus()
                                            textPersona.Select()
                                        ElseIf RadioButton1.Checked = True Then
                                            txtruc.Focus()
                                            txtruc.Select()
                                        End If
                                    End If
                                Else
                                    TextNumIdentrazon.Clear()
                                    TextEmpresaPasajero.Text = String.Empty
                                    TextEmpresaPasajero.Tag = Nothing
                                End If
                                PictureLoad.Visible = False
                            Else

                                'CUANDO NO HAY CONEXIO A INTERNET
                                Dim existeEnDB = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", TextNumIdentrazon.Text.Trim)
                                If existeEnDB Is Nothing Then
                                    SelRazon.tipoEntidad = "CL"
                                    SelRazon.nombreCompleto = TextEmpresaPasajero.Text.Trim
                                    SelRazon.nrodoc = TextNumIdentrazon.Text.Trim
                                    SelRazon.tipoDoc = "1"
                                    SelRazon.tipoPersona = "N"
                                    'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    'GrabarEntidadRapida()
                                    GrabarEnFormBasico(SelRazon)
                                    PictureLoad.Visible = False
                                Else
                                    TextEmpresaPasajero.Text = existeEnDB.nombreCompleto
                                    TextEmpresaPasajero.Tag = existeEnDB.idEntidad
                                    TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    If RadioButton2.Checked = True Then
                                        textPersona.Focus()
                                        textPersona.Select()
                                    ElseIf RadioButton1.Checked = True Then
                                        txtruc.Focus()
                                        txtruc.Select()
                                    End If
                                End If
                            End If

                        Else

                            TextEmpresaPasajero.Text = existeEnDB2.nombreCompleto
                            TextEmpresaPasajero.Tag = existeEnDB2.idEntidad
                            TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                            If RadioButton2.Checked = True Then
                                textPersona.Focus()
                                textPersona.Select()
                            ElseIf RadioButton1.Checked = True Then
                                txtruc.Focus()
                                txtruc.Select()
                            End If


                        End If

                    Case 11 'razonSocial
                        PictureLoad.Visible = True
                        Dim objeto As Boolean = ValidationRUC(TextNumIdentrazon.Text.Trim)
                        If objeto = False Then
                            PictureLoad.Visible = False
                            MessageBox.Show("Debe Ingresar un número correcto de ruc", "Ingresar identificación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Cursor = Cursors.Default
                            TextEmpresaPasajero.Clear()
                            Exit Sub
                        End If

                        If My.Computer.Network.IsAvailable = True Then
                            'VALIDAR SI EXISTE EN LA bd LOCAL PRIMERO 
                            If GetValidarLocalDB(TextNumIdentrazon.Text.Trim) = False Then
                                'GetConsultaSunatAsync(TextNumIdentrazon.Text.Trim)


                                Select Case ToggleConsultas.ToggleState
                                    Case ToggleButton2.ToggleButtonState.OFF ' API
                                        '  GetConsultaSunatAsync(TextNumIdentrazon.Text.Trim)
                                        GetApiSunat(TextNumIdentrazon.Text.Trim)
                                    Case ToggleButton2.ToggleButtonState.ON ' WEB
                                        'BgProveedor.RunWorkerAsync()
                                        BgEntidad.RunWorkerAsync()
                                End Select


                                BgEntidad.RunWorkerAsync()
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
                                    GrabarEnFormBasico(SelRazon)
                                    PictureLoad.Visible = False
                                ElseIf nroDoc = "2" Then
                                    'SelRazon.tipoEntidad = "CL"
                                    'SelRazon.nombreCompleto = TextEmpresaPasajero.Text.Trim
                                    'SelRazon.nrodoc = TextNumIdentrazon.Text.Trim
                                    'SelRazon.tipoDoc = "6"
                                    'SelRazon.tipoPersona = "J"
                                    'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    'GrabarEntidadRapida()
                                    GrabarEnFormBasico(SelRazon)
                                    PictureLoad.Visible = False
                                End If
                            End If
                        End If

                    Case Else
                        TextEmpresaPasajero.Text = String.Empty
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
                TextEmpresaPasajero.Clear()
            ElseIf ew.Status = WebExceptionStatus.ConnectFailure Then
                MessageBox.Show(ew.Message)
                TextNumIdentrazon.Clear()
                TextNumIdentrazon.Select()
                TextNumIdentrazon.Focus()
                TextEmpresaPasajero.Clear()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub GrabarEnFormBasico(selRazon As entidad)
        Dim f As New frmCrearENtidades
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        If f.Tag IsNot Nothing Then
            Dim ent = CType(f.Tag, entidad)
            TextNumIdentrazon.Text = ent.nrodoc
            TextEmpresaPasajero.Text = ent.nombreCompleto
            TextEmpresaPasajero.Tag = ent.idEntidad

            If RadioButton2.Checked = True Then
                textPersona.Focus()
                textPersona.Select()
            ElseIf RadioButton1.Checked = True Then
                txtruc.Focus()
                txtruc.Select()
            End If
        Else
            TextNumIdentrazon.Text = String.Empty
            TextEmpresaPasajero.Text = String.Empty
            TextEmpresaPasajero.Tag = Nothing
        End If
    End Sub

    Private Sub GrabarEnFormBasico()
        Dim f As New frmCrearENtidades
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        If f.Tag IsNot Nothing Then
            Dim ent = CType(f.Tag, entidad)
            TextNumIdentrazon.Text = ent.nrodoc
            TextEmpresaPasajero.Text = ent.nombreCompleto
            TextEmpresaPasajero.Tag = ent.idEntidad
        Else
            TextNumIdentrazon.Text = String.Empty
            TextEmpresaPasajero.Text = String.Empty
            TextEmpresaPasajero.Tag = Nothing
        End If
    End Sub

    Private Function GetValidarLocalDB(idEntidad As String) As Boolean
        GetValidarLocalDB = False
        Dim entidadSA As New entidadSA

        Dim entidad = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, "CL", idEntidad)
        If entidad IsNot Nothing Then
            SelRazon = New entidad
            SelRazon = entidad
            TextEmpresaPasajero.Text = entidad.nombreCompleto
            TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            TextEmpresaPasajero.Tag = entidad.idEntidad
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
            obEntidad.tipoEntidad = "CL"
            obEntidad.tipoDoc = SelRazon.tipoDoc
            obEntidad.tipoPersona = SelRazon.tipoPersona
            obEntidad.nrodoc = SelRazon.nrodoc
            obEntidad.nombreCompleto = SelRazon.nombreCompleto 'TextEmpresaPasajero.Text.Trim
            obEntidad.cuentaAsiento = "1213"
            obEntidad.direccion = SelRazon.direccion
            obEntidad.estado = StatusEntidad.Activo
            obEntidad.telefono = StatusEntidad.Activo

            Dim codx As Integer = entidadSA.GrabarEntidad(obEntidad)

            TextEmpresaPasajero.Tag = codx
            Dim entidad As New entidad
            entidad.idEntidad = codx
            entidad.nrodoc = TextNumIdentrazon.Text.Trim
            entidad.nombreCompleto = obEntidad.nombreCompleto
            entidad.tipoDoc = obEntidad.tipoDoc
            Me.Tag = entidad
            If RadioButton2.Checked = True Then
                textPersona.Focus()
                textPersona.Select()
            ElseIf RadioButton1.Checked = True Then
                txtruc.Focus()
                txtruc.Select()
            End If
            'Transporte.ListaEmpresas.Add(entidad)

            '    Dispose()
        Catch ex As Exception
            'Manejo de errores
            'MsgBox("No se pudo grabar el cliente." & vbCrLf & ex.Message, MsgBoxStyle.Critical)
            Me.Tag = Nothing
        End Try
    End Sub

    Private Property SelRazon As entidad

    Private Async Sub GetConsultaSunatAsync(ruc As String)
        SelRazon = New entidad
        Dim nroDoc = ruc.Substring(0, 1).ToString
        If nroDoc = "1" Then
            Dim company = CType(Await SoftPackERP_Sunat.GetRucContribuyenteSPK.GetContribuyente(ruc), SoftPackERP_Sunat.CompanyJuridico)
            If company IsNot Nothing Then
                If company.ContribuyenteTipo = "PERSONA NATURAL SIN NEGOCIO" Or company.ContribuyenteTipo = "PERSONA NATURAL CON NEGOCIO" Then
                    SelRazon.tipoPersona = "N"
                    SelRazon.tipoDoc = "6"
                End If
                SelRazon.tipoEntidad = "CL"
                SelRazon.nombreCompleto = company.RazonSocial
                TextEmpresaPasajero.Text = company.RazonSocial
                TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                SelRazon.nombreContacto = company.RazonSocial
                SelRazon.estado = company.ContribuyenteEstado
                SelRazon.nrodoc = company.Ruc
                SelRazon.direccion = company.DomicilioFiscal
                GrabarEntidadRapida()
                PictureLoad.Visible = False
            Else
                TextEmpresaPasajero.Clear()
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
                TextEmpresaPasajero.Text = company.RazonSocial
                TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
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
                TextEmpresaPasajero.Clear()
                PictureLoad.Visible = False
            End If
        End If

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

    'Private Function GetConsultarDNIReniec(Dni As String) As String
    '    Dim CLIENTE As New WebClient
    '    Dim PAGINA = CLIENTE.OpenRead("http://aplicaciones007.jne.gob.pe/srop_publico/Consulta/Afiliado/GetNombresCiudadano?DNI=" & Dni)
    '    Dim LECTOR As New StreamReader(PAGINA)
    '    Dim MIHTML As String = LECTOR.ReadToEnd
    '    ' Dim array = MIHTML.Split("|")

    '    Dim nombres = MIHTML.Replace("|", Space(1))
    '    Return Trim(nombres)
    'End Function

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If TextEmpresaPasajero.Text.Trim.Length > 0 Then
            If TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
                GrabarEntidadRapida()
            End If
        End If

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked Then
            textPersona.Enabled = False
            textPersona.ReadOnly = True
            textPersona.Clear()
            txtruc.Clear()
            txtruc.Visible = True
            txtruc.Enabled = True
            txtruc.ReadOnly = False
            txtruc.Select()
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked Then
            txtruc.Visible = False

            textPersona.Enabled = True
            textPersona.ReadOnly = False
            textPersona.Clear()
            textPersona.Select()
        End If
    End Sub

    Private Sub txtruc_TextChanged(sender As Object, e As EventArgs) Handles txtruc.TextChanged

    End Sub

    Private Sub txtruc_KeyDown(sender As Object, e As KeyEventArgs) Handles txtruc.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
                If RadioButton1.Checked Then

                    If My.Computer.Network.IsAvailable = True Then
                        If txtruc.Text.Trim.Length = 8 Then
                            'Dim nombres = GetConsultarDNIReniec(txtruc.Text.Trim)
                            Dim nombres = GetConsultarDNIReniecVER2(txtruc.Text.Trim)


                            If nombres.Trim.Length > 0 Then
                                textPersona.Text = nombres
                                Dim personaSel = PersonaSA.ObtenerPersonaNumDoc(Gempresas.IdEmpresaRuc, txtruc.Text.Trim)

                                If personaSel Is Nothing Then
                                    'textPersona.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    ' GrabarEntidadRapida()
                                    GrabarPersonaRapida()
                                    PictureLoad.Visible = False
                                Else
                                    textPersona.Text = personaSel.nombreCompleto
                                    'textPersona.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    textPersona.Tag = personaSel.codigo
                                End If
                            Else
                                txtruc.Clear()
                                textPersona.Text = String.Empty
                            End If
                        Else
                            txtruc.Clear()
                            textPersona.Clear()
                            MessageBox.Show("El DNI debe ser de 8 digitos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            PictureLoad.Visible = False
                            Exit Sub
                        End If

                    Else

                        'NO HAY CONEXION A INTERNET
                        Dim existeEnDB = PersonaSA.ObtenerPersonaNumDoc(Gempresas.IdEmpresaRuc, txtruc.Text.Trim)
                        If existeEnDB Is Nothing Then
                            CrearPersonaFormRapido()
                            'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                            'GrabarEntidadRapida()
                            'PictureLoad.Visible = False
                        Else
                            txtruc.Text = existeEnDB.idPersona
                            textPersona.Text = existeEnDB.nombreCompleto
                            textPersona.Tag = existeEnDB.codigo
                            '   textPersona.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        End If
                    End If

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub CrearPersonaFormRapido()
        Dim f As New FormCrearPersonaPasajero
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        If f.Tag IsNot Nothing Then
            Dim per = CType(f.Tag, Persona)
            txtruc.Text = per.idPersona
            textPersona.Text = per.nombreCompleto
            textPersona.Tag = per.codigo
        Else
            txtruc.Text = String.Empty
            textPersona.Text = String.Empty
            textPersona.Tag = Nothing
        End If
    End Sub

    Private Sub GrabarPersonaRapida()
        Dim personaSA As New PersonaSA
        Dim obj As New Persona
        obj.idEntidad = 0 ' entidadSel.idEntidad
        obj.idPersona = txtruc.Text.Trim
        obj.idEmpresa = Gempresas.IdEmpresaRuc
        obj.idOrganizacion = GEstableciento.IdEstablecimiento
        obj.fechaNac = Date.Now
        obj.tipoPersona = "N"
        obj.tipodoc = "1"
        obj.nombreCompleto = textPersona.Text
        obj.appat = "-"
        obj.apmat = "-"
        obj.nombres = "-"
        obj.nivel = "1"
        obj.edad = 0
        obj.usuarioActualizacion = usuario.IDUsuario
        obj.fechaActualizacion = Date.Now
        Dim per = personaSA.InsertPersona(obj)
        textPersona.Tag = per.codigo
    End Sub

    Private Sub TextCodigoVendedor_KeyDown(sender As Object, e As KeyEventArgs) Handles TextCodigoVendedor.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If TextCodigoVendedor.Text.Trim.Length > 0 Then
                GetUsuarioUnico()
            End If
        End If
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        CrearPersonaFormRapido()
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        GrabarEnFormBasico()
    End Sub

    Private Sub ComboAgenciaDestino_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboAgenciaDestino.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            TextNumIdentrazon.Select()
            TextNumIdentrazon.Focus()
        End If
    End Sub

    Private Sub ComboAgenciaDestino_Click(sender As Object, e As EventArgs) Handles ComboAgenciaDestino.Click

    End Sub

    Private Sub TextCodigoVendedor_TextChanged(sender As Object, e As EventArgs) Handles TextCodigoVendedor.TextChanged

    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RBClientesVarios.CheckedChanged
        If RBClientesVarios.Checked = True Then
            TextNumIdentrazon.Enabled = False
            TextEmpresaPasajero.Enabled = False

            TextNumIdentrazon.Text = VarClienteGeneral.idEntidad
            TextEmpresaPasajero.Text = VarClienteGeneral.nombreCompleto
            TextEmpresaPasajero.Tag = VarClienteGeneral.idEntidad
            txtruc.Select()
            txtruc.SelectAll()
        End If
    End Sub

    Private Sub RBIdentRazon_CheckedChanged(sender As Object, e As EventArgs) Handles RBIdentRazon.CheckedChanged
        If RBIdentRazon.Checked = True Then
            TextNumIdentrazon.Enabled = True
            TextEmpresaPasajero.Enabled = False
            TextNumIdentrazon.Clear()
            TextEmpresaPasajero.Clear()
            TextNumIdentrazon.Select()
        End If
    End Sub

    Private Sub BtnF1_Click(sender As Object, e As EventArgs) Handles BtnF1.Click
        F1Button()
    End Sub

    Private Sub BgEntidad_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgEntidad.DoWork
        GetConsultaSunatThread(TextNumIdentrazon.Text.Trim)
    End Sub

    Private Sub BgEntidad_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgEntidad.RunWorkerCompleted
        If SelRazon.nrodoc IsNot Nothing Then
            SelRazon.nombreCompleto = SelRazon.nombreCompleto.ToString.Replace(Chr(34), "")
            GrabarEntidadRapidaThread()
            TextNumIdentrazon.Text = SelRazon.nrodoc
            TextEmpresaPasajero.Text = SelRazon.nombreCompleto
            TextNumIdentrazon.ReadOnly = False
            SelRazon = New entidad
            'TextBoxExt1.Select()

        Else
            TextEmpresaPasajero.Clear()
            TextEmpresaPasajero.Tag = Nothing
            TextNumIdentrazon.ReadOnly = False
            SelRazon = New entidad
            TextNumIdentrazon.Select()
        End If
        PictureLoad.Visible = False
    End Sub

    Private Sub Label20_Click(sender As Object, e As EventArgs) Handles Label20.Click

    End Sub


#End Region


#Region "PRUEBA"
    Private Function GetConsultarDNIReniecVER2(Dni As String) As String
        Try
            Using client = New HttpClient()

                Dim CLIENTE As New WebClient
                'Dim PAGINA As Stream = CLIENTE.OpenRead("http://aplicaciones007.jne.gob.pe/srop_publico/Consulta/Afiliado/GetNombresCiudadano?DNI=" & Dni)
                Dim PAGINA As Stream = CLIENTE.OpenRead("http://consultas.dsdinformaticos.com/reniec.php?dni=" & Dni)
                Dim LECTOR As New StreamReader(PAGINA)
                Dim MIHTML As String = LECTOR.ReadToEnd
                Dim nombres = String.Empty
                ' Dim array = MIHTML.Split("|")
                Dim posicion = 0
                Dim doc As HtmlAgilityPack.HtmlDocument = New HtmlAgilityPack.HtmlDocument
                doc.LoadHtml(MIHTML)

                Dim readTask = doc.DocumentNode.InnerText.ToList

                'Dim obj As DNIContribuyente
                'obj = JsonConvert.DeserializeObject(Of DNIContribuyente)(doc.DocumentNode.InnerText)

                'MsgBox(obj.DNI)
                Dim json As JObject = JObject.Parse(doc.DocumentNode.InnerText)
                'MsgBox(json.SelectToken("result").SelectToken("Nombres"))

                Dim NOMBRECOMPLETO As String = json.SelectToken("result").SelectToken("Nombres")
                Dim APELLIDOPATERNO As String = json.SelectToken("result").SelectToken("ApellidoPaterno")
                Dim APELLIDOMATERNO As String = json.SelectToken("result").SelectToken("ApellidoMaterno")
                Dim FECHANACIMIENTO As String = json.SelectToken("result").SelectToken("FechaNacimiento")
                Dim SEXO As String = json.SelectToken("result").SelectToken("Sexo")

                Dim ENVIONOMBRECOMPLETO As String = NOMBRECOMPLETO & " " & APELLIDOPATERNO & " " & APELLIDOMATERNO

                Return ENVIONOMBRECOMPLETO
            End Using

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function

#End Region

End Class