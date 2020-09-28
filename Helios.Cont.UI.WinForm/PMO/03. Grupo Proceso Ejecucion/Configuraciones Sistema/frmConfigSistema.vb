Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmConfigSistema
    Inherits frmMaster
    Public Shared AutenticacionUsuario As AutenticacionUsuario
    Public Shared AutorizacionRolList As List(Of AutorizacionRol)

    Enum MODULOS
        COMPRA = 0
        VENTA = 1
    End Enum

#Region "TIMER"
    Sub parpadeo()
        Static parpadear As Boolean

        If Not parpadear Then
            lblEstado.ForeColor = lblEstado.BackColor
            lblEstado.BackColor = Color.Yellow
        Else
            lblEstado.ForeColor = SystemColors.WindowText
        End If

        parpadear = Not parpadear
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If TiempoRestante > 0 Then
            parpadeo()

            'lblAgregar.Visible = True
            'lblMensaje.Visible = True
            'tsSave.Enabled = False
            'lblMensaje.Text = "Agregar otro en: " & TiempoRestante
            TiempoRestante = TiempoRestante - 1
        ElseIf TiempoRestante = 0 Then
            Timer1.Enabled = False
            lblEstado.ForeColor = Color.Navy
            lblEstado.BackColor = Color.Transparent
            dgvConfiguraciones.Rows.RemoveAt(dgvConfiguraciones.Rows.Count - 1)
            ToolStrip4.Enabled = True
            '      Dispose()
        Else
            Timer1.Enabled = False
            'Ejecuta tu función cuando termina el tiempo
            TiempoEjecutar(10)

        End If
    End Sub
    Private TiempoRestante As Integer
    Public Sub TimerOn(ByRef Interval As Short)
        If Interval > 0 Then
            Timer1.Enabled = True
        Else
            Timer1.Enabled = False
        End If

    End Sub
    Public Function TiempoEjecutar(ByVal Tiempo As Integer)
        TiempoEjecutar = ""
        TiempoRestante = Tiempo  ' 1 minutos=60 segundos 
        Timer1.Interval = 400

        Call TimerOn(1000) ' Hechanos a andar el timer
    End Function
#End Region

#Region "Métodos"
    Private Sub ActualizarAlmacenConfiguracion(intIdConfiguracion As Integer, intIdAlmacen As Integer?, intIdCaja As Integer?)
        Dim configuracionSA As New ModuloConfiguracionSA
        Dim moduloConfiguracion As New moduloConfiguracion
        Try
            moduloConfiguracion.idConfiguracion = intIdConfiguracion
            moduloConfiguracion.configAlmacen = intIdAlmacen
            moduloConfiguracion.ConfigentidadFinanciera = intIdCaja
            configuracionSA.UpdateConfigSistema(moduloConfiguracion)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub EliminarConfiguracion(idConfiguracion As Integer)
        Dim moduloSA As New ModuloConfiguracionSA
        Dim modulo As New moduloConfiguracion
        modulo.idConfiguracion = idConfiguracion
        moduloSA.EliminarConfigSistema(modulo)
        lblEstado.Text = "Configuración eliminada!"
        Timer1.Enabled = True
        TiempoEjecutar(5)
    End Sub

    Public Sub ListaConfiguracionesHabilitadas()
        Dim moduloSA As New ModuloConfiguracionSA
        Dim TablaSA As New tablaDetalleSA
        Dim numeracionSA As New NumeracionBoletaSA
        Dim EFSA As New EstadosFinancierosSA
        Dim EF As New estadosFinancieros
        Dim almacenSA As New almacenSA
        Dim almacen As New almacen
        Dim NomAlmacen As String = Nothing
        Dim NomCaja As String = Nothing
        dgvConfiguraciones.Rows.Clear()
        For Each i As moduloConfiguracion In moduloSA.ListaModulosConfigurados(New moduloConfiguracion With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento})
            NomAlmacen = Nothing
            NomCaja = Nothing
            If i.tipoConfiguracion = "M" Then
                If Not IsNothing(i.configAlmacen) Then
                    almacen = almacenSA.GetUbicar_almacenPorID(i.configAlmacen)
                    If Not IsNothing(almacen) Then
                        NomAlmacen = almacen.descripcionAlmacen
                    Else
                        NomAlmacen = Nothing
                    End If
                End If

                If Not IsNothing(i.ConfigentidadFinanciera) Then
                    EF = EFSA.GetUbicar_estadosFinancierosPorID(i.ConfigentidadFinanciera)
                    If Not IsNothing(EF) Then
                        NomCaja = EF.descripcion
                    Else
                        NomCaja = Nothing
                    End If
                End If

                dgvConfiguraciones.Rows.Add(i.idConfiguracion, moduloSA.UbicarModuloPorCodigo(i.idModulo).descripcionModulo, "MANUAL", Nothing, Nothing, i.configAlmacen, NomAlmacen, i.ConfigentidadFinanciera, NomCaja)
            ElseIf i.tipoConfiguracion = "P" Then
                If Not IsNothing(i.configAlmacen) Then
                    almacen = almacenSA.GetUbicar_almacenPorID(i.configAlmacen)

                    If Not IsNothing(almacen) Then
                        NomAlmacen = almacen.descripcionAlmacen
                    Else
                        NomAlmacen = Nothing
                    End If
                End If
                If Not IsNothing(i.ConfigentidadFinanciera) Then
                    EF = EFSA.GetUbicar_estadosFinancierosPorID(i.ConfigentidadFinanciera)
                    If Not IsNothing(EF) Then
                        NomCaja = EF.descripcion
                    Else
                        NomCaja = Nothing
                    End If
                End If
                With numeracionSA.GetUbicar_numeracionBoletasPorID(i.configComprobante)
                    dgvConfiguraciones.Rows.Add(i.idConfiguracion, moduloSA.UbicarModuloPorCodigo(i.idModulo).descripcionModulo, IIf(i.tipoConfiguracion = "M", "MANUAL", "PROGRAMADA"), TablaSA.GetUbicarTablaID(10, .tipo).descripcion, .serie,
                                                i.configAlmacen, NomAlmacen, i.ConfigentidadFinanciera, NomCaja)
                End With
            End If
        Next
    End Sub

    Private Sub GrabarConfiguracion()
        Dim moduloSA As New ModuloConfiguracionSA
        Dim modulo As New moduloConfiguracion
        Dim numeracionSA As New NumeracionBoletaSA
        Dim TAblaSA As New tablaDetalleSA
        With modulo
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idModulo = cboModulo.SelectedValue
            .tipoConfiguracion = IIf(rbManual.Checked = True, "M", "P")
            .configComprobante = CInt(cboComprobant.SelectedValue)
        End With
        Dim xCod As Integer = moduloSA.GrabarConfigSistema(modulo)

        If modulo.tipoConfiguracion = "M" Then
            dgvConfiguraciones.Rows.Add(xCod, moduloSA.UbicarModuloPorCodigo(modulo.idModulo).descripcionModulo,
          "MANUAL")
        ElseIf modulo.tipoConfiguracion = "P" Then
            With numeracionSA.GetUbicar_numeracionBoletasPorID(modulo.configComprobante)
                dgvConfiguraciones.Rows.Add(xCod, moduloSA.UbicarModuloPorCodigo(modulo.idModulo).descripcionModulo,
             "PROGRAMADO", TAblaSA.GetUbicarTablaID(10, .tipo).descripcion, .serie)
            End With

        End If
        dgvConfiguraciones.Rows(dgvConfiguraciones.Rows.Count - 1).Selected = True
        dgvConfiguraciones.CurrentCell = dgvConfiguraciones.Rows(dgvConfiguraciones.Rows.Count - 1).Cells(1)
    End Sub

    Private Sub UbicarNumeracionPorID(intIdNumeracion As Integer)
        Dim numeracionSA As New NumeracionBoletaSA

        With numeracionSA.GetUbicar_numeracionBoletasPorID(intIdNumeracion)
            txtSerieConf.Text = .serie
        End With
    End Sub


    Private Sub UbicarModuloPorID(strModulo As String)
        Dim moduloSA As New ModuloConfiguracionSA
        With moduloSA.UbicarModuloPorCodigo(strModulo)
            If .tipo = "E" Then
                rbEntrada.Checked = True
            ElseIf .tipo = "S" Then
                rbSalida.Checked = True
            End If
        End With
    End Sub

    Public Sub ListaModulos()
        Dim moduloSA As New ModuloConfiguracionSA
        cboModulo.DisplayMember = "descripcionModulo"
        cboModulo.ValueMember = "idModulo"
        cboModulo.DataSource = moduloSA.ListaModulos()
    End Sub

    Private Sub UbicarPredeterminados(NModulo As MODULOS)
        Dim numeracionSA As New NumeracionBoletaSA
        Dim TablaSA As New tablaDetalleSA
        Select Case NModulo
            Case MODULOS.COMPRA
                lsvSeries.Items.Clear()
                For Each i As numeracionBoletas In numeracionSA.ObtenerAncladosPorComprobante(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, "COMPRA")
                    Dim n As New ListViewItem(TablaSA.GetUbicarTablaID(10, i.tipo).descripcion)
                    n.SubItems.Add(i.serie)
                    n.SubItems.Add(i.valorInicial)
                    lsvSeries.Items.Add(n)
                Next
            Case MODULOS.VENTA
                lsvSerieVenta.Items.Clear()
                For Each i As numeracionBoletas In numeracionSA.ObtenerAncladosPorComprobante(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, "VENTA")
                    Dim n As New ListViewItem(TablaSA.GetUbicarTablaID(10, i.tipo).descripcion)
                    n.SubItems.Add(i.serie)
                    n.SubItems.Add(i.valorInicial)
                    lsvSerieVenta.Items.Add(n)
                Next
        End Select
    End Sub

    Private Sub ListaPredeterminados(NModulo As MODULOS)
        Dim numeracionSA As New NumeracionBoletaSA
        Dim TablaSA As New tablaDetalleSA
        Dim dt As New DataTable
        dt.Columns.Add("ID")
        dt.Columns.Add("Name")
        Select Case NModulo
            Case MODULOS.COMPRA
                For Each i As numeracionBoletas In numeracionSA.ObtenerAncladosPorComprobante(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, "COMPRA")
                    dt.Rows.Add(i.IdEnumeracion, TablaSA.GetUbicarTablaID(10, i.tipo).descripcion)
                Next
                cboComprobant.DisplayMember = "Name"
                cboComprobant.ValueMember = "ID"
                cboComprobant.DataSource = dt 'numeracionSA.ObtenerAncladosPorComprobante(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, "COMPRA")
            Case MODULOS.VENTA
                For Each i As numeracionBoletas In numeracionSA.ObtenerAncladosPorComprobante(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, "VENTA")
                    dt.Rows.Add(i.IdEnumeracion, TablaSA.GetUbicarTablaID(10, i.tipo).descripcion)
                Next
                cboComprobant.DisplayMember = "Name"
                cboComprobant.ValueMember = "ID"
                cboComprobant.DataSource = dt  ' numeracionSA.ObtenerAncladosPorComprobante(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, "VENTA")
        End Select
    End Sub

    Private Sub AnclarSerie(intIDNumeracionAnclada As Integer, strTipoDoc As String, nModulo As MODULOS)
        Dim numeracionSA As New NumeracionBoletaSA
        Dim numeracion As New numeracionBoletas
        With numeracion
            .IdEnumeracion = intIDNumeracionAnclada
            .empresa = Gempresas.IdEmpresaRuc
            .establecimiento = GEstableciento.IdEstablecimiento
            Select Case nModulo
                Case MODULOS.COMPRA
                    .codigoNumeracion = "COMPRA"
                Case MODULOS.VENTA
                    .codigoNumeracion = "VENTA"
            End Select
            .tipo = strTipoDoc
            .anclado = "S"
        End With

        numeracionSA.UpdatePredeterminadoAll(numeracion)
        Select Case nModulo
            Case MODULOS.COMPRA
                ListaSeries(MODULOS.COMPRA)
            Case MODULOS.VENTA
                ListaSeries(MODULOS.VENTA)
        End Select

    End Sub

    Private Sub EliminarNum(intIDNumeracion As Integer)
        Dim numeracionSA As New NumeracionBoletaSA
        Dim numeracion As New numeracionBoletas

        numeracion = New numeracionBoletas
        numeracion.IdEnumeracion = intIDNumeracion
        numeracionSA.EliminarNumBoletas(numeracion)
    End Sub

    Public Sub Insertar(nModulo As MODULOS)
        Dim numeracionSA As New NumeracionBoletaSA
        Dim numBoletas As New numeracionBoletas
        numBoletas.empresa = Gempresas.IdEmpresaRuc
        numBoletas.establecimiento = GEstableciento.IdEstablecimiento
        Select Case nModulo
            Case MODULOS.COMPRA
                numBoletas.codigoNumeracion = "COMPRA"
            Case MODULOS.VENTA
                numBoletas.codigoNumeracion = "VENTA"
        End Select
        numBoletas.tipo = txtComprobante.ValueMember
        numBoletas.serie = String.Format("{0:00000}", Convert.ToInt32(txtSerie.Text.Trim))
        numBoletas.valorInicial = nudInicio.Value
        numBoletas.valorMinimo = 0
        numBoletas.valorMaximo = nudMaximo.Value
        numBoletas.incremento = nudINcremento.Value
        numBoletas.anclado = "N"
        numBoletas.usuarioActualizacion = "Jiuni"
        numBoletas.fechaActualizacion = DateTime.Now

        Dim xCodigo As Integer = numeracionSA.InsertNumBoletas(numBoletas)

        Select Case nModulo
            Case MODULOS.COMPRA
                dgvSeries.Rows.Add(xCodigo, txtComprobante.Text, String.Format("{0:00000}", Convert.ToInt32(txtSerie.Text.Trim)), nudInicio.Value,
                              nudINcremento.Value, nudMaximo.Value)
            Case MODULOS.VENTA
                dgvSerieVenta.Rows.Add(xCodigo, txtComprobante.Text, String.Format("{0:00000}", Convert.ToInt32(txtSerie.Text.Trim)), nudInicio.Value,
                           nudINcremento.Value, nudMaximo.Value)
        End Select


    End Sub

    Public Sub ListaSeries(nModulo As MODULOS)
        Dim numeracionSA As New NumeracionBoletaSA
        Dim tablaSA As New tablaDetalleSA
        Select Case nModulo
            Case MODULOS.COMPRA
                dgvSeries.Rows.Clear()
                For Each i In numeracionSA.ObtenerSeriesPorModulo(GEstableciento.IdEstablecimiento, "COMPRA")
                    dgvSeries.Rows.Add(i.IdEnumeracion, tablaSA.GetUbicarTablaID(10, i.tipo).descripcion, i.serie, i.valorInicial, i.incremento, i.valorMaximo)
                Next
            Case MODULOS.VENTA
                dgvSerieVenta.Rows.Clear()
                For Each i In numeracionSA.ObtenerSeriesPorModulo(GEstableciento.IdEstablecimiento, "VENTA")
                    dgvSerieVenta.Rows.Add(i.IdEnumeracion, tablaSA.GetUbicarTablaID(10, i.tipo).descripcion, i.serie, i.valorInicial, i.incremento, i.valorMaximo)
                Next
        End Select

    End Sub
#End Region

    Private Sub QTabPage1_Activated(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub frmConfigSistema_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmConfigSistema_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        TabPage1.Parent = Nothing
        TabPage2.Parent = Nothing
        lblCompra_Click(sender, e)
    End Sub

    Private Sub KryptonLinkLabel1_LinkClicked_1(sender As System.Object, e As System.EventArgs) Handles KryptonLinkLabel1.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
        datos.Clear()
        'With frmModalComprobantesTabla
        '    .lblTipo.Text = "10"
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        '    If datos.Count > 0 Then
        '        txtComprobante.ValueMember = datos(0).ID
        '        txtComprobante.Text = datos(0).NombreCampo
        '        txtSerie.Select()
        '        txtSerie.Focus()
        '    Else
        '        txtComprobante.Select()
        '    End If
        'End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lblCompra_Click(sender As System.Object, e As System.EventArgs) Handles lblCompra.Click
        Me.Cursor = Cursors.WaitCursor
        TabPage1.Parent = TabControl1
        TabPage2.Parent = Nothing
        TabPage3.Parent = Nothing
        ListaSeries(MODULOS.COMPRA)
        UbicarPredeterminados(MODULOS.COMPRA)
        Panel1.Visible = True
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lblVenta_Click(sender As System.Object, e As System.EventArgs) Handles lblVenta.Click
        Me.Cursor = Cursors.WaitCursor
        TabPage1.Parent = Nothing
        TabPage2.Parent = TabControl1
        TabPage3.Parent = Nothing
        ListaSeries(MODULOS.VENTA)
        UbicarPredeterminados(MODULOS.VENTA)
        Panel1.Visible = True
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub GuardarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles GuardarToolStripButton.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            If Not txtComprobante.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingresar el comprobante de la serie!"
                Timer1.Enabled = True
                TiempoEjecutar(5)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If

            If Not txtSerie.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingresar el número de serie!"
                Timer1.Enabled = True
                TiempoEjecutar(5)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
            If TabPage1 Is TabControl1.SelectedTab Then
                Insertar(MODULOS.COMPRA)
            ElseIf TabPage2 Is TabControl1.SelectedTab Then
                Insertar(MODULOS.VENTA)
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            Timer1.Enabled = True
            TiempoEjecutar(5)
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtSerie_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtSerie.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            nudInicio.Select()
            nudInicio.Focus()
        End If
    End Sub

    Private Sub txtSerie_LostFocus(sender As Object, e As System.EventArgs) Handles txtSerie.LostFocus
        Try
            Select Case "99"
                Case "01", "02", "03", "04", "07", "08", "23", "34", "35", "37", "55", "99", "00"
                    If Not txtSerie.Text = "" Or Not String.IsNullOrEmpty(txtSerie.Text) Then
                        If IsNumeric(txtSerie.Text) Then
                            txtSerie.Text = String.Format("{0:00000}", Convert.ToInt32(txtSerie.Text))
                        Else
                            MessageBox.Show("Serie inválida", "Ingresa otra vez", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            txtSerie.Clear()
                            txtSerie.Focus()
                            txtSerie.SelectAll()
                        End If
                    End If
                Case "05", "06", "11", "13", "15", "16", "17", "18", "21", "22", "24", "25", "26", "27", "28",
                    "29", "30", "32"

                    If Not txtSerie.Text = "" Or Not String.IsNullOrEmpty(txtSerie.Text) Then
                        If IsNumeric(txtSerie.Text) Then
                            '        txtSerie.Text = String.Format("{0:00000}", Convert.ToInt32(txtSerie.Text))
                        Else
                            MessageBox.Show("Serie inválida", "Ingresa otra vez", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            txtSerie.Clear()
                            txtSerie.Focus()
                            txtSerie.SelectAll()
                        End If
                    End If
                    ' SOLO NUMEROS
                Case "10"

                Case "12", "14", "36", "87", "88" ' maquina registradora
                    ' SOLO NUMEROS Y FALANUMERICOS

            End Select
        Catch ex As Exception
            MsgBox("Formato Incorrecto " + vbCrLf + ex.Message)
        End Try
    End Sub

    Private Sub txtSerie_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSerie.TextChanged

    End Sub

    Private Sub QRibbonItem2_ItemActivated(sender As System.Object, e As Qios.DevSuite.Components.QCompositeEventArgs) Handles QRibbonItem2.ItemActivated

    End Sub



    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        Me.Cursor = Cursors.WaitCursor
        Dim NumeracionSA As New NumeracionBoletaSA
        If dgvSeries.Rows.Count > 0 Then
            AnclarSerie(dgvSeries.Item(0, dgvSeries.CurrentRow.Index).Value, NumeracionSA.GetUbicar_numeracionBoletasPorID(dgvSeries.Item(0, dgvSeries.CurrentRow.Index).Value).tipo, MODULOS.COMPRA)
        End If
        UbicarPredeterminados(MODULOS.COMPRA)
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtComprobante_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtComprobante.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtSerie.Select()
            txtSerie.Focus()
        End If
    End Sub

    Private Sub txtComprobante_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtComprobante.TextChanged

    End Sub

    Private Sub nudInicio_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles nudInicio.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            nudINcremento.Select()
            nudINcremento.Focus()
        End If
    End Sub

    Private Sub nudInicio_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nudInicio.ValueChanged

    End Sub

    Private Sub nudINcremento_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles nudINcremento.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            nudMaximo.Select()
            nudMaximo.Focus()
        End If
    End Sub

    Private Sub dgvSeries_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSeries.CellClick
        If e.RowIndex > -1 Then
            If e.ColumnIndex = 7 Then
                If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    EliminarNum(dgvSeries.Rows(e.RowIndex).Cells(0).Value)
                    dgvSeries.Rows.RemoveAt(e.RowIndex)
                    UbicarPredeterminados(MODULOS.COMPRA)
                End If
            End If
        End If
    End Sub


    Private Sub dgvSeries_CellPainting(sender As Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgvSeries.CellPainting
        If e.RowIndex > -1 Then
            If e.ColumnIndex = 6 AndAlso e.RowIndex >= 0 Then
                e.Paint(e.CellBounds, DataGridViewPaintParts.All)

                Dim bmpFind As Bitmap = My.Resources.edit4
                Dim ico As Icon = Icon.FromHandle(bmpFind.GetHicon)
                e.Graphics.DrawIcon(ico, e.CellBounds.Left + 3, e.CellBounds.Top + 3)
                e.Handled = True
            End If

            If e.ColumnIndex = 7 AndAlso e.RowIndex >= 0 Then
                e.Paint(e.CellBounds, DataGridViewPaintParts.All)

                Dim bmpFind As Bitmap = My.Resources.icono_eliminar
                Dim ico As Icon = Icon.FromHandle(bmpFind.GetHicon)
                e.Graphics.DrawIcon(ico, e.CellBounds.Left + 3, e.CellBounds.Top + 3)
                e.Handled = True

            End If
        End If
    End Sub

    Private Sub dgvSeries_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSeries.CellContentClick

    End Sub

    Private Sub dgvSerieVenta_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSerieVenta.CellClick
        If e.RowIndex > -1 Then
            If e.ColumnIndex = 7 Then
                If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    EliminarNum(dgvSerieVenta.Rows(e.RowIndex).Cells(0).Value)
                    dgvSerieVenta.Rows.RemoveAt(e.RowIndex)
                    UbicarPredeterminados(MODULOS.VENTA)
                End If
            End If
        End If
    End Sub

    Private Sub dgvSerieVenta_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSerieVenta.CellContentClick

    End Sub

    Private Sub dgvSerieVenta_CellPainting(sender As Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgvSerieVenta.CellPainting
        If e.RowIndex > -1 Then
            If e.ColumnIndex = 6 AndAlso e.RowIndex >= 0 Then
                e.Paint(e.CellBounds, DataGridViewPaintParts.All)

                Dim bmpFind As Bitmap = My.Resources.edit4
                Dim ico As Icon = Icon.FromHandle(bmpFind.GetHicon)
                e.Graphics.DrawIcon(ico, e.CellBounds.Left + 3, e.CellBounds.Top + 3)
                e.Handled = True
            End If

            If e.ColumnIndex = 7 AndAlso e.RowIndex >= 0 Then
                e.Paint(e.CellBounds, DataGridViewPaintParts.All)

                Dim bmpFind As Bitmap = My.Resources.icono_eliminar
                Dim ico As Icon = Icon.FromHandle(bmpFind.GetHicon)
                e.Graphics.DrawIcon(ico, e.CellBounds.Left + 3, e.CellBounds.Top + 3)
                e.Handled = True

            End If
        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            If Not txtComprobante.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingresar el comprobante de la serie!"
                Timer1.Enabled = True
                TiempoEjecutar(5)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If

            If Not txtSerie.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingresar el número de serie!"
                Timer1.Enabled = True
                TiempoEjecutar(5)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
            If TabPage1 Is TabControl1.SelectedTab Then
                Insertar(MODULOS.COMPRA)
            ElseIf TabPage2 Is TabControl1.SelectedTab Then
                Insertar(MODULOS.VENTA)
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            Timer1.Enabled = True
            TiempoEjecutar(5)
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton3_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton3.Click
        Me.Cursor = Cursors.WaitCursor
        Dim NumeracionSA As New NumeracionBoletaSA
        If dgvSerieVenta.Rows.Count > 0 Then
            AnclarSerie(dgvSerieVenta.Item(0, dgvSerieVenta.CurrentRow.Index).Value, NumeracionSA.GetUbicar_numeracionBoletasPorID(dgvSerieVenta.Item(0, dgvSerieVenta.CurrentRow.Index).Value).tipo, MODULOS.VENTA)
        End If
        UbicarPredeterminados(MODULOS.VENTA)
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lblUsuario_Click(sender As System.Object, e As System.EventArgs) Handles lblUsuario.Click
        'Form1.Show()
    End Sub

    Private Sub QRibbonItem5_ItemActivating(sender As System.Object, e As Qios.DevSuite.Components.QCompositeCancelEventArgs) Handles QRibbonItem5.ItemActivating
        Me.Cursor = Cursors.WaitCursor
        TabPage1.Parent = Nothing
        TabPage2.Parent = Nothing
        TabPage3.Parent = TabControl1
        ListaModulos()
        rbManual.Checked = True
        ListaConfiguracionesHabilitadas()
        Panel1.Visible = False
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub QRibbonItem5_ItemActivated(sender As System.Object, e As Qios.DevSuite.Components.QCompositeEventArgs) Handles QRibbonItem5.ItemActivated

    End Sub

    Private Sub QPanel1_Click(sender As System.Object, e As System.EventArgs) Handles QPanel1.Click

    End Sub

    Private Sub GroupBox1_Enter(sender As System.Object, e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub cboModulo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboModulo.SelectedIndexChanged
        If cboModulo.SelectedIndex > -1 Then
            UbicarModuloPorID(cboModulo.SelectedValue)
            If rbManual.Checked = True Then
                rbManual_CheckedChanged(sender, e)
            ElseIf rbProgramado.Checked = True Then
                rbProgramado_CheckedChanged(sender, e)
            End If
        End If
    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As System.Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub

    Private Sub btnManual_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub btnProgamada_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub QRibbonPage1_Activated(sender As System.Object, e As System.EventArgs) Handles QRibbonPage1.Activated

    End Sub

    Private Sub cboComprobant_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboComprobant.SelectedIndexChanged
        If cboComprobant.SelectedIndex > -1 Then
            UbicarNumeracionPorID(cboComprobant.SelectedValue)
        End If
    End Sub

    Private Sub ToolStripButton4_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton4.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            GrabarConfiguracion()
        Catch ex As Exception
            lblEstado.Text = ex.Message
            dgvConfiguraciones.Rows.Add("", "El registro ya existe en la BD.")
            dgvConfiguraciones.Rows(dgvConfiguraciones.Rows.Count - 1).Selected = True
            dgvConfiguraciones.CurrentCell = dgvConfiguraciones.Rows(dgvConfiguraciones.Rows.Count - 1).Cells(1)
            dgvConfiguraciones.Rows(dgvConfiguraciones.Rows.Count - 1).DefaultCellStyle.SelectionForeColor = Color.White
            dgvConfiguraciones.Rows(dgvConfiguraciones.Rows.Count - 1).DefaultCellStyle.SelectionBackColor = Color.Red
            ToolStrip4.Enabled = False
            Timer1.Enabled = True
            TiempoEjecutar(7)
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvConfiguraciones_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvConfiguraciones.CellClick
        If e.RowIndex > -1 Then
            If e.ColumnIndex = 9 Then
                If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    EliminarConfiguracion(dgvConfiguraciones.Rows(e.RowIndex).Cells(0).Value)
                    dgvConfiguraciones.Rows.RemoveAt(e.RowIndex)
                End If
                'ElseIf e.ColumnIndex = 6 Then
                '    showAlmacen()
            End If
        End If
    End Sub
    Sub showAlmacen()
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        datos.Clear()
        With frmModalAlmacen
            .ObtenerAlmacenes(GEstableciento.IdEstablecimiento)
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            If datos.Count > 0 Then
                dgvConfiguraciones.Item(5, dgvConfiguraciones.CurrentRow.Index).Value = datos(0).ID
                dgvConfiguraciones.Item(6, dgvConfiguraciones.CurrentRow.Index).Value = datos(0).NombreEntidad
                ' txtAlmacen.Text = datos(0).NombreEntidad
                ActualizarAlmacenConfiguracion(dgvConfiguraciones.Item(0, dgvConfiguraciones.CurrentRow.Index).Value, datos(0).ID, dgvConfiguraciones.Item(7, dgvConfiguraciones.CurrentRow.Index).Value)
            End If

        End With
    End Sub
    Private Sub dgvConfiguraciones_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvConfiguraciones.CellContentClick

    End Sub

    Private Sub dgvConfiguraciones_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvConfiguraciones.CellDoubleClick
        Me.Cursor = Cursors.WaitCursor
        If e.RowIndex > -1 Then
            If e.ColumnIndex = 6 Then
                showAlmacen()
            ElseIf e.ColumnIndex = 8 Then
                CajaSelecionadaShowed()
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub
    Sub CajaSelecionadaShowed()
        Me.Cursor = Cursors.WaitCursor
        Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
        datos.Clear()

        With frmModalCajaConfig
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            If datos.Count > 0 Then
                dgvConfiguraciones.Item(7, dgvConfiguraciones.CurrentRow.Index).Value = datos(0).ID
                dgvConfiguraciones.Item(8, dgvConfiguraciones.CurrentRow.Index).Value = datos(0).NombreCampo
                ActualizarAlmacenConfiguracion(dgvConfiguraciones.Item(0, dgvConfiguraciones.CurrentRow.Index).Value, dgvConfiguraciones.Item(5, dgvConfiguraciones.CurrentRow.Index).Value, datos(0).ID)
            End If
        End With

        Me.Cursor = Cursors.Arrow
    End Sub
    Private Sub dgvConfiguraciones_CellPainting(sender As Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgvConfiguraciones.CellPainting
        If e.RowIndex > -1 Then

            If e.ColumnIndex = 9 AndAlso e.RowIndex >= 0 Then
                e.Paint(e.CellBounds, DataGridViewPaintParts.All)

                Dim bmpFind As Bitmap = My.Resources.icono_eliminar
                Dim ico As Icon = Icon.FromHandle(bmpFind.GetHicon)
                e.Graphics.DrawIcon(ico, e.CellBounds.Left + 3, e.CellBounds.Top + 3)
                e.Handled = True

            End If
        End If
    End Sub

    Private Sub rbManual_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbManual.CheckedChanged
        If rbManual.Checked = True Then
            Label6.Visible = False
            cboComprobant.Visible = False
            txtSerieConf.Visible = False
        End If
    End Sub

    Private Sub rbProgramado_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbProgramado.CheckedChanged
        If rbProgramado.Checked = True Then
            Label6.Visible = True
            cboComprobant.Visible = True
            txtSerieConf.Visible = True
            ListaPredeterminados(IIf(rbEntrada.Checked = True, MODULOS.COMPRA, MODULOS.VENTA))
        End If
    End Sub

    Private Sub dgvConfiguraciones_RowPostPaint(sender As Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgvConfiguraciones.RowPostPaint
        Dim grid As DataGridView = TryCast(sender, DataGridView)

        If Not grid.RowHeadersVisible Then
            Return
        End If

        'this method overrides the DataGridView's RowPostPaint event 
        'in order to automatically draw numbers on the row header cells
        'and to automatically adjust the width of the column containing
        'the row header cells so that it can accommodate the new row
        'numbers,

        'store a string representation of the row number in 'strRowNumber'
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()

        'prepend leading zeros to the string if necessary to improve
        'appearance. For example, if there are ten rows in the grid,
        'row seven will be numbered as "07" instead of "7". Similarly, if 
        'there are 100 rows in the grid, row seven will be numbered as "007".
        While strRowNumber.Length < grid.RowCount.ToString().Length
            strRowNumber = Convert.ToString("0") & strRowNumber
        End While

        'determine the display size of the row number string using
        'the DataGridView's current font.
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, grid.Font)

        'adjust the width of the column that contains the row header cells 
        'if necessary
        If grid.RowHeadersWidth < CInt(size.Width + 20) Then
            grid.RowHeadersWidth = CInt(size.Width + 20)
        End If

        'this brush will be used to draw the row number string on the
        'row header cell using the system's current ControlText color
        Dim b As Brush = SystemBrushes.ControlText

        'draw the row number string on the current row header cell using
        'the brush defined above and the DataGridView's default font
        e.Graphics.DrawString(strRowNumber, grid.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
    End Sub

End Class