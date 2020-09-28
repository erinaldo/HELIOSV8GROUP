Imports System.ComponentModel
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class FormCrearEncomienda

#Region "Attributes"
    Dim thread As System.Threading.Thread
    Public Property listaClientes As List(Of entidad)
    Friend Delegate Sub SetDataSourceDelegate(ByVal lista As List(Of Persona))
    Friend Delegate Sub SetDataSourceDelegateEntidad(ByVal lista As List(Of entidad))
    Dim entidadSA As New entidadSA
    Dim PersonaSA As New PersonaSA
    Public Property listaPersonas As List(Of Persona)

    Dim conf As New GConfiguracionModulo
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(GridEncomiendas, False, False, 10.0F)
        FormatoGridAvanzado(dgvCuentas, False, False, 10.0F)
        cargarCajas()
        GetUsuarioUnico()
        GetDocsVenta()
        GetMappingGridEncomiendas()
        threadClientes()
        threadPersonas()
        GetMappingColumnsGridByUsuario(Integer.Parse(ComboCaja.SelectedValue))
        TextDetalleEnvio.Enabled = True
        TextFechaProgramada.Value = Date.Now
        DateTimePickerAdv1.Value = Date.Now
    End Sub


#End Region

#Region "Methods"

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
            Dim user = UsuariosList.Where(Function(o) o.IDUsuario = usuario.IDUsuario).SingleOrDefault
            If user IsNot Nothing Then
                TextCodigoVendedor.Text = user.codigo
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

    'Private Sub GetNumeracion(strIdModulo As String, strIDEmpresa As String)
    '    Dim moduloConfiguracionSA As New ModuloConfiguracionSA
    '    Dim moduloConfiguracion As New moduloConfiguracion
    '    moduloConfiguracion = moduloConfiguracionSA.UbicarConfiguracionPorEmpresaModulo(strIdModulo, strIDEmpresa, GEstableciento.IdEstablecimiento)
    '    conf = New GConfiguracionModulo
    '    conf = ConfigurarComprobanteVenta(moduloConfiguracion)
    '    'SetDataSourceNumeracion(moduloConfiguracion)
    'End Sub

    'Public Function ConfigurarComprobanteVenta(moduloConfiguracion As moduloConfiguracion) As GConfiguracionModulo
    '    Dim numeracionSA As New NumeracionBoletaSA
    '    Dim TablaSA As New tablaDetalleSA
    '    Dim almacenSA As New almacenSA
    '    Dim cajaSA As New EstadosFinancierosSA

    '    If Not IsNothing(moduloConfiguracion) Then
    '        With moduloConfiguracion
    '            GConfiguracion2 = New GConfiguracionModulo
    '            GConfiguracion2.IdModulo = .idModulo
    '            GConfiguracion2.TipoConfiguracion = .tipoConfiguracion
    '            Select Case .tipoConfiguracion
    '                Case "P"
    '                    With numeracionSA.GetUbicar_numeracionBoletasPorID(.configComprobante)
    '                        GConfiguracion2.ConfigComprobante = .IdEnumeracion

    '                        If cboTipoDoc.Text = "BOLETA" Then
    '                            GConfiguracion2.TipoComprobante = "12.1" ' .tipo
    '                            GConfiguracion2.Serie = .serie
    '                            GConfiguracion2.ValorActual = .valorInicial

    '                        End If
    '                        If cboTipoDoc.Text = "FACTURA" Then
    '                            GConfiguracion2.TipoComprobante = "12.2" '.tipo
    '                            GConfiguracion2.Serie = .serie
    '                            GConfiguracion2.ValorActual = .valorInicial

    '                        End If

    '                        If cboTipoDoc.Text = "FACTURA ELECTRONICA" Then

    '                            GConfiguracion2.TipoComprobante = "01" '.tipo
    '                            GConfiguracion2.Serie = .serie
    '                            GConfiguracion2.ValorActual = .valorInicial


    '                        End If
    '                        If cboTipoDoc.Text = "BOLETA ELECTRONICA" Then
    '                            GConfiguracion2.TipoComprobante = "03" ' .tipo
    '                            GConfiguracion2.Serie = .serie
    '                            GConfiguracion2.ValorActual = .valorInicial

    '                        End If

    '                        If cboTipoDoc.Text = "PROFORMA" Then
    '                            GConfiguracion2.TipoComprobante = .tipo
    '                            GConfiguracion2.Serie = .serie
    '                            GConfiguracion2.ValorActual = .valorInicial
    '                        End If
    '                    End With
    '                Case "M"

    '            End Select

    '        End With
    '    Else
    '        '  lblEstado.Text = "Este módulo no contiene una configuración disponible, intentelo más tarde.!"
    '        ' Timer1.Enabled = True
    '        'TabCompra.Enabled = False
    '        'TiempoEjecutar(5)
    '    End If
    '    Return GConfiguracion2
    'End Function

    Public Function configuracionModuloV2(strIDEmpresa As String, strIdModulo As String, strNomModulo As String, intIdEstablecimiento As Integer) As GConfiguracionModulo
        Try
            Dim numeracionSA As New NumeracionBoletaSA
            Dim TablaSA As New tablaDetalleSA
            Dim almacenSA As New almacenSA
            Dim cajaSA As New EstadosFinancierosSA

            Dim RecuperacionNumeracion = numeracionSA.GetUbicar_numeracionBoletasXUnidadNegocio(New numeracionBoletas With {.empresa = strIDEmpresa, .establecimiento = intIdEstablecimiento, .codigoNumeracion = strIdModulo, .estado = "A"})

            If (Not IsNothing(RecuperacionNumeracion)) Then
                GConfiguracion = New GConfiguracionModulo
                GConfiguracion.ConfigComprobante = CInt(RecuperacionNumeracion.IdEnumeracion)

                If cboTipoDoc.Text = "BOLETA" Then
                    GConfiguracion.TipoComprobante = "12.1" ' .tipo
                    GConfiguracion.Serie = RecuperacionNumeracion.serie
                    GConfiguracion.ValorActual = RecuperacionNumeracion.valorInicial

                End If
                If cboTipoDoc.Text = "FACTURA" Then
                    GConfiguracion.TipoComprobante = "12.2" '.tipo
                    GConfiguracion.Serie = RecuperacionNumeracion.serie
                    GConfiguracion.ValorActual = RecuperacionNumeracion.valorInicial

                End If

                If cboTipoDoc.Text = "FACTURA ELECTRONICA" Then

                    GConfiguracion.TipoComprobante = "01" '.tipo
                    GConfiguracion.Serie = RecuperacionNumeracion.serie
                    GConfiguracion.ValorActual = RecuperacionNumeracion.valorInicial


                End If
                If cboTipoDoc.Text = "BOLETA ELECTRONICA" Then
                    GConfiguracion.TipoComprobante = "03" ' .tipo
                    GConfiguracion.Serie = RecuperacionNumeracion.serie
                    GConfiguracion.ValorActual = RecuperacionNumeracion.valorInicial

                End If

                If cboTipoDoc.Text = "PROFORMA" Then
                    GConfiguracion.TipoComprobante = RecuperacionNumeracion.tipo
                    GConfiguracion.Serie = RecuperacionNumeracion.serie
                    GConfiguracion.ValorActual = RecuperacionNumeracion.valorInicial
                End If

            Else
                Throw New Exception("Verificar configuración")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return GConfiguracion
    End Function

    Private Sub threadPersonas()
        Dim tipo = TIPO_ENTIDAD.CLIENTE
        Dim empresa = Gempresas.IdEmpresaRuc
        thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() Getpersonas(tipo, empresa)))
        thread.Start()
    End Sub

    Private Sub Getpersonas(tipo As String, empresa As String)
        Dim lista As New List(Of Persona)
        lista = New List(Of Persona)
        lista.AddRange(PersonaSA.ObtenerPersona(New Persona With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                 .tipoPersona = "T"}).ToList)
        setDataSource(lista)
    End Sub

    Private Sub setDataSource(ByVal lista As List(Of Persona))
        If Me.InvokeRequired Then
            'Me.Invoke(New SetDataSourceDelegate(AddressOf setDataSource), table)

            Dim deleg As New SetDataSourceDelegate(AddressOf setDataSource)
            Invoke(deleg, New Object() {lista})
        Else
            listaPersonas = New List(Of Persona)
            listaPersonas = lista
        End If
    End Sub

    Private Sub threadClientes()
        Dim tipo = TIPO_ENTIDAD.CLIENTE
        Dim empresa = Gempresas.IdEmpresaRuc
        thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetClientes(tipo, empresa)))
        thread.Start()
    End Sub

    Private Sub GetClientes(tipo As String, empresa As String)
        Dim lista As New List(Of entidad)
        lista = New List(Of entidad)
        '  Dim varios = VarClienteGeneral ' entidadSA.UbicarEntidadVarios("VR", Gempresas.IdEmpresaRuc, String.Empty)
        'Dim lista = entidadSA.ObtenerListaEntidad(tipo, empresa)
        lista.Add(VarClienteGeneral)
        lista.AddRange(entidadSA.GetListarEntidad(New entidad With {.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR, .idEmpresa = Gempresas.IdEmpresaRuc, .idOrganizacion = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA}))
        setDataSourceEntidad(lista)
    End Sub

    Private Sub setDataSourceEntidad(ByVal lista As List(Of entidad))
        If Me.InvokeRequired Then
            'Me.Invoke(New SetDataSourceDelegate(AddressOf setDataSource), table)

            Dim deleg As New SetDataSourceDelegateEntidad(AddressOf setDataSourceEntidad)
            Invoke(deleg, New Object() {lista})
        Else
            listaClientes = New List(Of entidad)
            listaClientes = lista
        End If
    End Sub

    Private Sub GetRutasPorDia()
        Dim status As String = String.Empty
        Dim rutaSA As New RutaProgramacionSalidasSA
        ListProgamacion.Items.Clear()

        Dim lista = rutaSA.GetProgramacionPorFechaLaboral(New rutaProgramacionSalidas With
                                                          {
                                                          .fechaProgramacion = DateTimePickerAdv1.Value
                                                          })


        For Each i In lista
            Select Case i.estado
                Case ProgramacionEstado.VehiculoAsignadoEnCurso
                    status = "En Curso"
                Case ProgramacionEstado.VehiculoAsignadoRutaCulminada
                    status = "Culminada"
                Case ProgramacionEstado.VentaCerrada
                    status = "Venta cerrada"
                Case ProgramacionEstado.VentaEnMostrador
                    status = "En mostrador"
                Case ProgramacionEstado.ZonaEmbarque
                    status = "Embarque"
            End Select

            Dim n As New ListViewItem(i.programacion_id)
            n.SubItems.Add(If(i.tipo = "I", "SALIDA", "VUELTA"))
            n.SubItems.Add(i.fechaProgramacion)
            n.SubItems.Add(i.fechaProgramacion.Value.ToShortTimeString)
            n.SubItems.Add(i.CustomRutas.CustomRuta_horarios.horario_id)
            n.SubItems.Add(i.ruta_id)
            n.SubItems.Add(i.CustomRutas.ciudadDestino)
            n.SubItems.Add(status)
            ListProgamacion.Items.Add(n)
        Next
        ListProgamacion.Refresh()

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
                            listaPersonas.Add(c)
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

    Private Sub RoundButton28_Click(sender As Object, e As EventArgs) Handles RoundButton28.Click
        Cursor = Cursors.WaitCursor
        GetRutasPorDia()
        Cursor = Cursors.Default
    End Sub

    Private Sub TextEmpresaPasajero_TextChanged(sender As Object, e As EventArgs) Handles TextEmpresaPasajero.TextChanged
        TextEmpresaPasajero.ForeColor = Color.Black
        TextEmpresaPasajero.Tag = Nothing
        If TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            TextNumIdentrazon.Visible = True
        Else
            TextNumIdentrazon.Visible = False
        End If
    End Sub

    Private Sub TextEmpresaPasajero_KeyDown(sender As Object, e As KeyEventArgs) Handles TextEmpresaPasajero.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        ElseIf e.KeyCode = Keys.Enter Then
            Me.PCEmpresas.Size = New Size(319, 128)
            Me.PCEmpresas.ParentControl = Me.TextEmpresaPasajero
            Me.PCEmpresas.ShowPopup(Point.Empty)
            Dim consulta As New List(Of entidad)
            consulta.Add(New entidad With {.nombreCompleto = "Agregar nuevo"})

            Dim consulta2 = (From n In listaClientes
                             Where n.nombreCompleto.StartsWith(TextEmpresaPasajero.Text) Or n.nrodoc.StartsWith(TextEmpresaPasajero.Text)).ToList


            consulta.AddRange(consulta2)
            FillLSVClientesGeneral(consulta)
            If consulta.Count <= 1 Then
                If MessageBox.Show("El cliente ingresado no existe!. Desea crearlo ahora?", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                    Dim f As New frmCrearENtidades(TextEmpresaPasajero.Text)
                    f.CaptionLabels(0).Text = "Nuevo cliente"
                    f.strTipo = TIPO_ENTIDAD.CLIENTE
                    f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()
                    If f.Tag IsNot Nothing Then
                        Dim c = CType(f.Tag, entidad)
                        TextEmpresaPasajero.Text = c.nombreCompleto
                        TextEmpresaPasajero.Tag = c.idEntidad
                        TextNumIdentrazon.Visible = True
                        TextNumIdentrazon.Text = c.nrodoc
                        TextNumIdentrazon.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        listaClientes.Add(c)
                    End If

                End If

            End If

        Else
            '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.PCEmpresas.Size = New Size(282, 128)
            Me.PCEmpresas.ParentControl = Me.TextEmpresaPasajero
            Me.PCEmpresas.ShowPopup(Point.Empty)
            Dim consulta As New List(Of entidad)
            consulta.Add(New entidad With {.nombreCompleto = "Agregar nuevo"})

            Dim consulta2 = (From n In listaClientes
                             Where n.nombreCompleto.StartsWith(TextEmpresaPasajero.Text) Or n.nrodoc.StartsWith(TextEmpresaPasajero.Text)).ToList




            consulta.AddRange(consulta2)
            FillLSVClientesGeneral(consulta)
            e.Handled = True
        End If

        If e.KeyCode = Keys.Down Then
            '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.PCEmpresas.Size = New Size(282, 128)
            Me.PCEmpresas.ParentControl = Me.TextEmpresaPasajero
            Me.PCEmpresas.ShowPopup(Point.Empty)
            ListEmpresas.Focus()
        End If
        '   End If

        ' e.SuppressKeyPress = True
        If e.KeyCode = Keys.Escape Then
            If Me.PCEmpresas.IsShowing() Then
                Me.PCEmpresas.HidePopup(PopupCloseType.Canceled)
            End If
        End If
    End Sub

    Private Sub ListEmpresas_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListEmpresas.MouseDoubleClick
        Me.PCEmpresas.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub PCEmpresas_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles PCEmpresas.CloseUp
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.PopupCloseType = PopupCloseType.Done Then
                If ListEmpresas.SelectedItems.Count > 0 Then
                    If ListEmpresas.SelectedItems(0).SubItems(1).Text = "Agregar nuevo" Then
                        Dim f As New frmCrearENtidades
                        f.CaptionLabels(0).Text = "Nuevo cliente"
                        f.strTipo = TIPO_ENTIDAD.CLIENTE
                        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        'f.tipoPersona(TIPO_ENTIDAD.CLIENTE)
                        f.StartPosition = FormStartPosition.CenterParent
                        f.ShowDialog()
                        If Not IsNothing(f.Tag) Then
                            Dim c = CType(f.Tag, entidad)
                            listaClientes.Add(c)
                            'txtTipoDocClie.Text = c.tipoDoc
                            TextEmpresaPasajero.Text = c.nombreCompleto
                            TextNumIdentrazon.Text = c.nrodoc
                            TextEmpresaPasajero.Tag = c.idEntidad
                            TextNumIdentrazon.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                            TextNumIdentrazon.Visible = True
                            TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        End If
                    Else
                        TextEmpresaPasajero.Text = ListEmpresas.SelectedItems(0).SubItems(1).Text
                        TextEmpresaPasajero.Tag = ListEmpresas.SelectedItems(0).SubItems(0).Text
                        TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        TextNumIdentrazon.Text = ListEmpresas.SelectedItems(0).SubItems(2).Text
                        ' txtTipoDocClie.Text = LsvProveedor.SelectedItems(0).SubItems(3).Text
                        TextNumIdentrazon.Visible = True


                        'TextBenefClienteBase.Text = beneficio.importeBase.GetValueOrDefault
                        'TextValorAfecto.Text = beneficio.valorConvertido

                        'Select Case beneficio.tipoAfectacion
                        '    Case "I"
                        '        TextTipoBeneficio.Text = "IMPORTE"
                        '    Case "C"
                        '        TextTipoBeneficio.Text = "CANTIDAD"
                        '    Case "P"
                        '        TextTipoBeneficio.Text = "PORCENTAJE"
                        'End Select

                    End If
                    'ListaMercaderiasXIdHijo(Val(txtSubCategoria.Tag), cboTipoExistencia.SelectedValue)
                End If
            End If

            'Set focus back to textbox.
            If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
                Me.TextEmpresaPasajero.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub textPersona_TextChanged(sender As Object, e As EventArgs) Handles textPersona.TextChanged
        textPersona.ForeColor = Color.Black
        textPersona.Tag = Nothing
        If textPersona.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            txtruc.Visible = True
        Else
            txtruc.Visible = False
        End If
    End Sub

    Private Sub textPersona_KeyDown(sender As Object, e As KeyEventArgs) Handles textPersona.KeyDown
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

            Dim consulta2 = (From n In listaPersonas
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
    End Sub

    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles LsvProveedor.MouseDoubleClick
        Me.pcLikeCategoria.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub RoundButton21_Click(sender As Object, e As EventArgs) Handles RoundButton21.Click
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

    Private Sub AgregarItem()
        With GridEncomiendas.Table
            .AddNewRecord.SetCurrent()
            .AddNewRecord.BeginEdit()
            .CurrentRecord.SetValue("codigo", 0)
            .CurrentRecord.SetValue("tipo", ComboTipo.Text)
            .CurrentRecord.SetValue("detalle", TextDetalleEnvio.Text.Trim)
            .CurrentRecord.SetValue("cantidad", txtCant.DecimalValue)
            .CurrentRecord.SetValue("unidad", "UND")
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

    Private Sub RoundButton22_Click(sender As Object, e As EventArgs) Handles RoundButton22.Click

        GetMappingEnvio(Integer.Parse(ListProgamacion.SelectedItems(0).SubItems(5).Text))
        PanelCrearEncomienda.Visible = False
    End Sub

    Private Sub GetMappingEnvio(id_ruta As Integer)
        Dim rutaSA As New RutasSA
        Dim persona As Persona = Nothing
        Dim razonSocialEmpresa As entidad = Nothing
        Dim rutaSel As rutas = Nothing
        Dim servicio As ruta_HorarioServicios = Nothing


        persona = listaPersonas.Where(Function(o) o.codigo = CInt(textPersona.Tag)).SingleOrDefault
        razonSocialEmpresa = listaClientes.Where(Function(o) o.idEntidad = CInt(TextEmpresaPasajero.Tag)).SingleOrDefault
        rutaSel = rutaSA.RutaSelID(New rutas With {.ruta_id = id_ruta}) ' ListaRutasActivas.Where(Function(o) o.ruta_id = id_ruta).SingleOrDefault


        TextNombres.Text = $"{persona.nombres}, {persona.appat}"
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


        TextCiudadDestino.Text = rutaSel.ciudadDestino
        TextDestinoUbigeo.Text = rutaSel.ciudadDestinoUbigeo

        TextCiudadOrigen.Text = rutaSel.ciudadOrigen
        TextOrigenUbigeo.Text = rutaSel.ciudadOrigenUbigeo

        txtTotalPagar.DecimalValue = GetPorPagar()
    End Sub

    Private Function GetPorPagar() As Decimal
        GetPorPagar = 0
        For Each i In GridEncomiendas.Table.Records
            GetPorPagar += CDec(i.GetValue("importe"))
        Next
    End Function

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        PanelCrearEncomienda.Visible = True
        PanelCrearEncomienda.Size = New Size(806, 594)
    End Sub

    Private Sub FormCrearEncomienda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PanelCrearEncomienda.Visible = True
        PanelCrearEncomienda.Size = New Size(806, 594)
    End Sub

    Private Sub cboTipoDoc_Click(sender As Object, e As EventArgs) Handles cboTipoDoc.Click

    End Sub

    Private Sub cboTipoDoc_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboTipoDoc.SelectedValueChanged
        If cboTipoDoc.Text.Trim.Length > 0 Then
            Select Case cboTipoDoc.Text
                Case "BOLETA"


                    'txtNumero.Clear()
                    'txtSerie.Visible = False
                    'txtSerie.ReadOnly = True
                    'txtNumero.Visible = False
                    'txtNumero.ReadOnly = True

                    'txtruc.Text = 0
                    'TXTcOMPRADOR.Text = "VARIOS"
                    'txtruc.Select(0, txtruc.Text.Length)
                    'txtruc.Focus()
                    'Getclientepedido()

                    ProgressBar2.Visible = True
                    ProgressBar2.Style = ProgressBarStyle.Marquee
                    BackgroundWorker1.RunWorkerAsync()


                Case "FACTURA"


                    'txtNumero.Clear()
                    'txtSerie.Visible = False
                    'txtSerie.ReadOnly = True
                    'txtNumero.Visible = False
                    'txtNumero.ReadOnly = True

                    'txtruc.Clear()
                    'TXTcOMPRADOR.Clear()
                    'txtruc.Select(0, txtruc.Text.Length)
                    'txtruc.Focus()
                    '  Getclientepedido()

                    ProgressBar2.Visible = True
                    ProgressBar2.Style = ProgressBarStyle.Marquee
                    BackgroundWorker1.RunWorkerAsync()



                Case "NOTA DE VENTA"

                    'txtruc.Text = 0
                    'TXTcOMPRADOR.Text = "VARIOS"
                    'txtruc.Select(0, txtruc.Text.Length)
                    'txtruc.Focus()

                Case "BOLETA ELECTRONICA"


                    'txtNumero.Clear()
                    'txtSerie.Visible = False
                    'txtSerie.ReadOnly = True
                    'txtNumero.Visible = False
                    'txtNumero.ReadOnly = True


                    ProgressBar2.Visible = True
                    ProgressBar2.Style = ProgressBarStyle.Marquee
                    BackgroundWorker1.RunWorkerAsync()
                Case "FACTURA ELECTRONICA"

                    'txtNumero.Clear()
                    'txtSerie.Visible = False
                    'txtSerie.ReadOnly = True
                    'txtNumero.Visible = False
                    'txtNumero.ReadOnly = True


                    ProgressBar2.Visible = True
                    ProgressBar2.Style = ProgressBarStyle.Marquee
                    BackgroundWorker1.RunWorkerAsync()

            End Select
            'GetResetCantidades()
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            If BackgroundWorker1.CancellationPending Then
                ' MessageBox.Show("Up to here? ...")
                e.Cancel = True
            Else
                Dim strIdModulo As String = Nothing
                If cboTipoDoc.Text = "BOLETA" Then
                    strIdModulo = "VT2"
                ElseIf cboTipoDoc.Text = "FACTURA" Then
                    strIdModulo = "VT3"
                ElseIf cboTipoDoc.Text = "BOLETA ELECTRONICA" Then
                    strIdModulo = "VT2E"
                ElseIf cboTipoDoc.Text = "FACTURA ELECTRONICA" Then
                    strIdModulo = "VT3E"
                ElseIf cboTipoDoc.Text = "PROFORMA" Then
                    strIdModulo = "COTIZACION"
                End If
                Dim strIDEmpresa = General.Gempresas.IdEmpresaRuc
                configuracionModuloV2(strIDEmpresa, strIdModulo, "", GEstableciento.IdEstablecimiento)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If e.Cancelled Then

        Else

            'txtSerie.Text = conf.Serie
            ProgressBar2.Visible = False
        End If
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

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        Dim cajaUsuaroSA As New cajaUsuarioSA
        Dim entidadSA As New EstadosFinancierosSA
        Dim envio As EnvioImpresionVendedorPernos = Nothing
        Try
            cargarCajas()

            Select Case cboTipoDoc.Text
                Case "FACTURA", "FACTURA ELECTRONICA"
                    Dim objeto As Boolean = ValidationRUC(TextNumIdent.Text.Trim)
                    If objeto = False Then
                        MessageBox.Show("Debe Ingresar un número correcto de ruc", "Ingresar identificación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Cursor = Cursors.Default
                        Exit Sub
                    End If
                Case "BOLETA ELECTRONICA", "BOLETA"
                    Dim rsp = validarDNI(TextNumIdent.Text.Trim)
                    If rsp = False Then
                        MessageBox.Show("Debe Ingresar un número correcto de DNI", "Ingresar identificación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Cursor = Cursors.Default
                        Exit Sub
                    End If
            End Select


            Dim codigoVendedor = TextCodigoVendedor.Text.Trim
            Dim usuarioSel = UsuariosList.Where(Function(o) o.codigo = codigoVendedor).FirstOrDefault

            If usuarioSel IsNot Nothing Then
                Dim cajaUsuario = cajaUsuaroSA.UbicarCajaUsuarioPorID(ComboCaja.SelectedValue)

                '   Dim ef = entidadSA.GetUbicar_estadosFinancierosPorID(cajaUsuario.idCajaOrigen)

                envio = New EnvioImpresionVendedorPernos With
                    {
                    .CodigoVendedor = TextCodigoVendedor.Text.Trim,
                    .IDCaja = cajaUsuario.idcajaUsuario,' ComboCaja.SelectedValue,
                    .IDVendedor = usuarioSel.IDUsuario,
                    .print = True,
                    .Nombreprint = String.Empty,
                    .NombreCajero = ComboCaja.Text,
                    .EntidadFinanciera = 0,'ef.idestado,
                    .EntidadFinancieraName = String.Empty
                }

                If ValidarGrabado() = True Then
                    txtFecha.Value = Date.Now

                    If Not chCredito.Checked = True Then
                        Dim pagos As Decimal = SumaPagos()

                        If pagos <= 0 Then
                            MessageBox.Show("Debe ingresar un pago mayor a cero!", "Pagar venta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                            'objPleaseWait.Close()
                            Exit Sub
                        End If

                        If pagos > 0 AndAlso pagos < txtTotalPagar.DecimalValue Then
                            If MessageBox.Show("Está realizando una cobranza parcial, Desea Continuar?", "Pagar venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                                '   objPleaseWait.Close()
                                Exit Sub
                            End If
                        End If
                    End If

                    'objPleaseWait = New FeedbackForm()
                    'objPleaseWait.StartPosition = FormStartPosition.CenterScreen
                    'objPleaseWait.Show()
                    GrabarVentaPasaje(envio)

                End If


            Else
                MessageBox.Show("Ingrese un código valido", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextCodigoVendedor.Select()
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub GrabarVentaPasaje(envio As EnvioImpresionVendedorPernos)
        Dim ventaSA As New DocumentoventaTransporteSA
        Dim obj As documentoventaTransporteDetalle
        Dim ListaDetalle As List(Of documentoventaTransporteDetalle)

        txtFecha.Value = Date.Now
        Dim tipodoc As String = String.Empty
        Select Case cboTipoDoc.Text
            Case "BOLETA ELECTRONICA"
                tipodoc = "03"
            Case "FACTURA ELECTRONICA"
                tipodoc = "01"
            Case "RESERVAR"
                tipodoc = "9901"
        End Select

        Dim documento As New documento With
        {
        .idEmpresa = Gempresas.IdEmpresaRuc,
        .idCentroCosto = GEstableciento.IdEstablecimiento,
        .tipoDoc = tipodoc,
        .fechaProceso = txtFecha.Value,
        .moneda = "1",
        .idEntidad = TextNombres.Tag,
        .entidad = TextNombres.Text,
        .tipoEntidad = "PS",
        .nrodocEntidad = TextNumIdent.Text,
        .nroDoc = "1",
        .idOrden = 0,
        .tipoOperacion = StatusTipoOperacion.VENTA,
        .usuarioActualizacion = usuario.IDUsuario,
        .fechaActualizacion = Date.Now
        }

        documento.documentoventaTransporte = New documentoventaTransporte With
        {
        .tareo_id = 1,
        .programacion_id = Integer.Parse(ListProgamacion.SelectedItems(0).SubItems(0).Text),
         .TipoConfiguracion = If(conf Is Nothing, Nothing, conf.TipoConfiguracion),
          .IdNumeracion = IIf(IsNothing(conf.ConfigComprobante), 0, conf.ConfigComprobante),
        .tipoOperacion = StatusTipoOperacion.VENTA,
        .idEmpresa = Gempresas.IdEmpresaRuc,
        .idOrganizacion = GEstableciento.IdEstablecimiento,
        .UbigeoCiudadOrigen = TextOrigenUbigeo.Text,
        .ciudadOrigen = TextCiudadOrigen.Text,
        .UbigeoCiudadDestino = TextDestinoUbigeo.Text,
        .ciudadDestino = TextCiudadDestino.Text,
        .tipoDocumento = tipodoc,
        .fechaProgramada = TextFechaProgramada.Value,
        .fechadoc = txtFecha.Value,
        .serie = conf.Serie,
        .numero = 0,
        .idPersona = Integer.Parse(TextNombres.Tag),
        .razonSocial = Integer.Parse(TextRaZonSocial.Tag),
        .comprador = TextNombres.Text,
        .moneda = "1",
        .tipocambio = 1,
        .tasaIgv = 0.18,
        .baseImponible1 = Math.Round(CDec(CalculoBaseImponible(TExtTotal.DecimalValue, 1.18)), 2),
        .baseImponible2 = 0,
        .igv1 = TExtTotal.DecimalValue - Math.Round(CDec(CalculoBaseImponible(TExtTotal.DecimalValue, 1.18)), 2),
        .igv2 = 0,
        .total = txtTotalPagar.DecimalValue,
        .estadoCobro = TIPO_VENTA.PAGO.PENDIENTE_PAGO,
        .glosa = "Venta de encomiendas",
        .tipoVenta = TIPO_VENTA.VENTA_ENCOMIENDAS,
        .numeroAsiento = 0,
        .estado = 1,
        .usuarioActualizacion = usuario.IDUsuario,
        .fechaActualizacion = Date.Now
        }

        ListaDetalle = New List(Of documentoventaTransporteDetalle)
        For Each i In GridEncomiendas.Table.Records
            obj = New documentoventaTransporteDetalle
            obj.tipo = "P" ' i.GetValue("tipo")
            obj.detalle = i.GetValue("detalle")
            obj.cantidad = CDec(i.GetValue("cantidad"))
            obj.unidadMedida = i.GetValue("unidad")
            obj.importe = CDec(i.GetValue("importe"))
            obj.estado = 1
            obj.usuarioActualizacion = usuario.IDUsuario
            obj.fechaActualizacion = Date.Now
            ListaDetalle.Add(obj)
        Next
        documento.documentoventaTransporte.documentoventaTransporteDetalle = ListaDetalle

        Dim ListaPagos = ListaPagosCajas(documento.documentoventaTransporte, envio)
        documento.documentoventaTransporte.estadoCobro = TIPO_VENTA.PAGO.COBRADO
        documento.ListaCustomDocumento = ListaPagos 'ListaPagosCajas(c)
        Dim codVenta = ventaSA.DocumentoventaEncomiendaSave(documento)
        'formVentaPasajes.ReiniciarForm(True, codVenta)

        Close()
    End Sub


    Public Function ListaPagosCajas(venta As documentoventaTransporte, envio As EnvioImpresionVendedorPernos) As List(Of documento)
        Dim nDocumentoCaja As New documento
        Dim objCaja As New documentoCaja
        Dim ListaDoc As New List(Of documento)
        For Each i In dgvCuentas.Table.Records
            If Decimal.Parse(i.GetValue("abonado")) > 0 Then
                nDocumentoCaja = New documento
                nDocumentoCaja.idDocumento = CInt(Me.Tag)
                nDocumentoCaja.idEmpresa = Gempresas.IdEmpresaRuc
                nDocumentoCaja.idCentroCosto = GEstableciento.IdEstablecimiento
                nDocumentoCaja.tipoDoc = venta.tipoDocumento ' cbotipoDocPago.SelectedValue
                nDocumentoCaja.fechaProceso = txtFecha.Value
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
                objCaja.idEstablecimiento = GEstableciento.IdEstablecimiento
                objCaja.fechaProceso = txtFecha.Value
                objCaja.fechaCobro = txtFecha.Value
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
                               .documentoAfectado = CInt(Me.Tag),
                               .documentoAfectadodetalle = 0,
                               .EstadoCobro = "DC",
                               .fechaModificacion = DateTime.Now
                               })

    End Function

    Private Sub TextRaZonSocial_TextChanged(sender As Object, e As EventArgs) Handles TextRaZonSocial.TextChanged

    End Sub
#End Region



End Class