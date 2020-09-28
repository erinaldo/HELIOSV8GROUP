Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Tools
Imports Helios.Cont.Business.Entity
Imports Helios.General
'Imports Helios.Planilla.Business.Entity

Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
'Imports Helios.Planilla.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmConfigInicioXempresa
    Inherits frmMaster

    Dim almacen As List(Of almacen)
    Private dtTableGrd As DataTable

    Public Property ControlBounds() As Rectangle
        Get
            Return m_ControlBounds
        End Get
        Set(ByVal value As Rectangle)
            m_ControlBounds = Value
        End Set
    End Property
    Private m_ControlBounds As Rectangle


    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
        Using brush As Brush = New SolidBrush(Color.FromArgb(45, Color.White))
            e.Graphics.FillRectangle(brush, e.ClipRectangle)
        End Using
        Me.Opacity = 68
    End Sub

    Private Sub ObtenerTipoCambioMax()
        Dim tipoCambioSA As New tipoCambioSA
        Dim tipoCambio As New tipoCambio

        tipoCambio = tipoCambioSA.GetListaTipoCambioMaxFecha(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
        If Not IsNothing(tipoCambio) Then
            With tipoCambio
                'txtFechaIgv.Value = .fechaIgv
                txtFechaIgv.Value = DateTime.Now
                nudTipoCambioCompra.Value = .compra
                nudTipoCambio.Value = .venta
            End With
        Else
            txtFechaIgv.Value = DateTime.Now
            nudTipoCambioCompra.Value = 0
            nudTipoCambio.Value = 0
        End If
    End Sub

    'Private Sub CargarAlmaceNes(intIdEstablecimiento As Integer)
    '    Dim almaceN As New almacenSA
    '    lstAlmacen.DisplayMember = ""
    '    lstAlmacen.ValueMember = "idAlmacen"
    '    lstAlmacen.DataSource = almaceN.GetListar_almacenExceptAV(intIdEstablecimiento)
    'End Sub

    Private Sub Grabar()
        Dim config As New configuracionInicio
        Dim existe As New configuracionInicio
        Dim configsa As New ConfiguracionInicioSA
        With config
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = txtEstablecimiento.ValueMember
            .idalmacenVenta = txtAlmacenTrab.ValueMember
            .anio = cboAnios.Text
            .mes = String.Format("{0:00}", Convert.ToInt32(txtMes.Value.Month))
            If IsDate(New DateTime(cboAnios.Text, txtMes.Value.Month, txtDiaLaboral.Value.Day)) Then
                .dia = New DateTime(cboAnios.Text, txtMes.Value.Month, txtDiaLaboral.Value.Day)
            Else
                Throw New Exception("Validar la fecha")
            End If
            .periodo = String.Format("{0:00}", Convert.ToInt32(txtMes.Value.Month)) & "/" & cboAnios.Text
            .tipocambio = nudTipoCambio.Value
            .iva = nupIGV.Value

            .retencion4ta = nudRenta.Value
            'agremarti

            If rbConIva.Checked = True Then
                .tipoIva = "SIVA"
            ElseIf rbSinIVA.Checked = True Then
                .tipoIva = "NIVA"
            End If

            existe = configsa.ObtenerConfigXempresa(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)

            If Not IsNothing(existe) Then
                configsa.EditarConfigInicio(config)
            Else
                configsa.InsertConfigInicio(config)
            End If
            GEstableciento = New GEstablecimiento
            GEstableciento.IdEstablecimiento = txtEstablecimiento.ValueMember
            GEstableciento.NombreEstablecimiento = txtEstablecimiento.Text
            TmpIdAlmacen = txtAlmacenTrab.ValueMember
            TmpNombreAlmacen = txtAlmacenTrab.Text
            AnioGeneral = cboAnios.Text
            MesGeneral = String.Format("{0:00}", Convert.ToInt32(txtMes.Value.Month))
            DiaLaboral = New DateTime(cboAnios.Text, txtMes.Value.Month, txtDiaLaboral.Value.Day)
            PeriodoGeneral = String.Format("{0:00}", Convert.ToInt32(txtMes.Value.Month)) & "/" & cboAnios.Text



            TmpTipoCambio = nudTipoCambio.Value
            TmpIGV = nupIGV.Value
            If rbConIva.Checked = True Then
                TmpTipoIVA = "SIVA"
            Else
                TmpTipoIVA = "NIVA"
            End If

            TmpRetencion4 = nudRenta.Value
            'agre

            Dispose()

        End With
    End Sub

    Public Sub ObtenerConfiguracionPorEmpresa(strIdEmpresa As String)
        Dim configSA As New ConfiguracionInicioSA
        Dim config As New configuracionInicio
        Dim estableSA As New establecimientoSA
        Dim almacenSA As New almacenSA
        config = configSA.ObtenerConfigXempresa(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
        If Not IsNothing(config) Then
            With config
                txtEstablecimiento.ValueMember = .idCentroCosto
                txtEstablecimiento.Text = estableSA.UbicaEstablecimientoPorID(.idCentroCosto).nombre
                txtAlmacenTrab.ValueMember = .idalmacenVenta
                txtAlmacenTrab.Text = almacenSA.GetUbicar_almacenPorID(.idalmacenVenta).descripcionAlmacen
                cboAnios.Text = .anio
                txtMes.Value = New Date(Now.Date.Year, CInt(.mes), Date.Now.Day)
                txtDiaLaboral.Value = New Date(cboAnios.Text, txtMes.Value.Month, .dia.Value.Day)
                nudTipoCambio.Value = .tipocambio
                nupIGV.Value = .iva
                Select Case .tipoIva
                    Case "SIVA"
                        rbConIva.Checked = True
                    Case "NIVA"
                        rbSinIVA.Checked = True
                End Select
            End With
        Else
            '   MessageBoxAdv.Show("No hay una configuración existente!", "Atención!", MessageBoxButtons.OK)
        End If
    End Sub

    Public Sub New(strIdEmpresa As String)

        ' This call is required by the designer.
        InitializeComponent()
        QGlobalColorSchemeManager1.Global.CurrentTheme = Qios.DevSuite.Components.QColorScheme.LunaBlueThemeName
        ' Add any initialization after the InitializeComponent() call.
        IniciarControles()
        ObtenerConfiguracionPorEmpresa(Gempresas.IdEmpresaRuc)
        ObtenerTipoCambioMax()
        'If Not IsNothing(GEstableciento) Then
        '    If Not IsNothing(GEstableciento.NombreEstablecimiento) Then
        '        txtEstablecimiento.ValueMember = GEstableciento.IdEstablecimiento
        '        txtEstablecimiento.Text = GEstableciento.NombreEstablecimiento

        '    End If
        'End If

    End Sub

#Region "Métodos"

    Public Sub IniciarControles()

        Dim estableSA As New establecimientoSA
        Dim almacenSA As New almacenSA

        For Each i In estableSA.ObtenerListaEstablecimientos(Gempresas.IdEmpresaRuc)
            lstEstablecimiento.Items.Add(New Destablecimiento(i.nombre, i.idCentroCosto))
        Next
        lstEstablecimiento.DisplayMember = "Name"
        lstEstablecimiento.ValueMember = "Id"

        'Dim moduloSA As New ModuloConfiguracionSA
        'lstModulos.DisplayMember = "descripcionModulo"
        'lstModulos.ValueMember = "idModulo"
        'lstModulos.DataSource = moduloSA.ListaModulos()

        Dim tablaSA As New tablaDetalleSA
        'cboMoneda.ValueMember = "codigoDetalle"
        'cboMoneda.DisplayMember = "descripcion"
        'cboMoneda.DataSource = tablaSA.GetListaTablaDetalle(4, "1")

        cboTipoEstable.ValueMember = "codigoDetalle"
        cboTipoEstable.DisplayMember = "descripcion"
        cboTipoEstable.DataSource = tablaSA.GetListaTablaDetalle(14, "1")

        Dim AniosSA As New empresaPeriodoSA
        cboAnios.DisplayMember = "periodo"
        cboAnios.ValueMember = "periodo"
        cboAnios.DataSource = AniosSA.GetListar_empresaPeriodo(New empresaPeriodo With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento})

        'UbicarExistencias()
    End Sub

    Private Sub updateUtilidadExistencias()
        Dim listaUtilidad As New List(Of item)
        Dim itemSA As New itemSA
        Dim item As New item
        For Each i As DataGridViewRow In dgvItems.Rows
            If i.Cells(3).Value = 1 Then
                item = New item
                With item
                    .idItem = i.Cells(0).Value
                    .utilidad = CDec(i.Cells(2).Value)
                End With
                listaUtilidad.Add(item)
            End If
        Next
        If Not IsNothing(listaUtilidad) Then
            itemSA.UpdateCategoriaFull(listaUtilidad)
        End If
    End Sub

#Region "ESTABLECIMIENTO"
    Public Class Destablecimiento

        Private _name As String
        Private _id As Integer
        Public Sub New(ByVal name As String, ByVal id As Integer)
            _name = name
            _id = id
        End Sub

        Sub New()
            ' TODO: Complete member initialization 
        End Sub

        Public Property Name() As String
            Get
                Return _name
            End Get
            Set(ByVal value As String)
                _name = value
            End Set
        End Property
        Public Property Id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal value As Integer)
                _id = value
            End Set
        End Property
    End Class

    Private Sub GrabarEstablecimiento()
        Dim estableSA As New establecimientoSA
        Dim estable As New centrocosto
        With estable
            .idEmpresa = Gempresas.IdEmpresaRuc
            .nombre = txtNewEstable.Text.Trim
            .TipoEstab = cboTipoEstable.SelectedValue
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With
        Dim codx As Integer = estableSA.InsertEstablecimiento(estable)

        GEstableciento.IdEstablecimiento = codx
        GEstableciento.NombreEstablecimiento = txtNewEstable.Text.Trim

        lstEstablecimiento.Items.Add(New Destablecimiento(txtNewEstable.Text.Trim, codx))
        txtEstablecimiento.ValueMember = codx
        txtEstablecimiento.Text = txtNewEstable.Text.Trim
    End Sub
#End Region

    Private Sub GrabarAnio()
        Dim AnioSA As New empresaPeriodoSA
        Dim Anio As New empresaPeriodo
        Try
            Anio.idEmpresa = Gempresas.IdEmpresaRuc
            Anio.periodo = txtnewAnio.Value.Year
            Anio.usuarioActualizacion = "Jiuni"
            Anio.fechaActualizacion = DateTime.Now
            Anio.message = "crear"
            AnioSA.InsertarPeriodo(Anio)

            Dim AniosSA As New empresaPeriodoSA
            cboAnios.DisplayMember = "periodo"
            cboAnios.ValueMember = "periodo"
            cboAnios.DataSource = AniosSA.GetListar_empresaPeriodo(New empresaPeriodo With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento})

            PeriodoGeneral = String.Format("{0:00}", Convert.ToInt32(txtMes.Value.Month)) & "/" & txtnewAnio.Value.Year
            AnioGeneral = txtnewAnio.Value.Year
            cboAnios.Text = AnioGeneral ' txtnewAnio.Value.Year
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub UbicarExistencias()
        Dim objLista As New List(Of item)
        Dim itemSA As New itemSA

        txtbuscarItems.Clear()
        Dim dt As New DataTable("Existencias " & "ID")

        dt.Columns.Add(New DataColumn("ID", GetType(Integer)))
        dt.Columns.Add(New DataColumn("Descripcion", GetType(String)))
        dt.Columns.Add(New DataColumn("Utilidad", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("Estado", GetType(Integer)))

        objLista = itemSA.GetListaItemPorEmpresa(Gempresas.IdEmpresaRuc, txtEstablecimiento.ValueMember)

        For Each i As item In objLista

            Dim dr As DataRow = dt.NewRow()
            dr(0) = CInt(i.idItem)
            dr(1) = i.descripcion
            dr(2) = i.utilidad
            dr(3) = CInt(0)

            dt.Rows.Add(dr)
        Next

        dgvItems.DataSource = dt
        dtTableGrd = dt
        dgvItems.Columns(0).Visible = False
        dgvItems.Columns(1).Width = 200
        dgvItems.Columns(1).DefaultCellStyle.ForeColor = SystemColors.HotTrack
        dgvItems.Columns(1).ReadOnly = True
        dgvItems.Columns(2).Width = 70
        dgvItems.Columns(3).Visible = False
    End Sub

#End Region

    Private Sub frmConfigInicioXempresa_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing



        Dispose()
    End Sub

    Private Sub frmConfigInicioXempresa_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'cboAnios.Text = DateTime.Now.Year
        ''txtMes.Value = New (DateTime.Now.Month)
        'txtMes.Value = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
        'txtDiaLaboral.Value = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)


        Dim almacenSA As New almacenSA
        lstAlmacen.DisplayMember = "descripcionAlmacen"
        lstAlmacen.ValueMember = "idAlmacen"
        almacen = almacenSA.GetListar_almacenExceptAV(GEstableciento.IdEstablecimiento)
        lstAlmacen.DataSource = almacen


        cboAnios.Text = AnioGeneral
        txtMes.Value = New DateTime(AnioGeneral, MesGeneral, DateTime.Now.Day)
        txtDiaLaboral.Value = DiaLaboral

        nudRenta.Value = TmpRetencion4



        'cboAnios.SelectedValue = AnioGeneral

        'txtMes.Value = New DateTime(AnioGeneral, MesGeneral, DateTime.Now.Day)

        Panel2.Left = (Me.ClientSize.Width - Panel2.Width) / 2
        Panel2.Top = (Me.ClientSize.Height - Panel2.Height) / 2
    End Sub

    Private Sub tbnAlmacen_Click(sender As Object, e As EventArgs) Handles tbnAlmacen.Click
        popupControlContainer1.Font = New Font("Tahoma", 8)
        popupControlContainer1.Size = New Size(344, 130)
        Me.popupControlContainer1.ParentControl = Me.txtEstablecimiento
        Me.popupControlContainer1.ShowPopup(Point.Empty)
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        pcNuevoEstablecimiento.Font = New Font("Tahoma", 8)
        pcNuevoEstablecimiento.Size = New Size(322, 148)
        Me.pcNuevoEstablecimiento.ParentControl = Me.txtEstablecimiento
        Me.pcNuevoEstablecimiento.ShowPopup(Point.Empty)
        txtNewEstable.Clear()
        txtNewEstable.Select()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        pcAño.Font = New Font("Tahoma", 8)
        pcAño.Size = New Size(141, 83)
        Me.pcAño.ParentControl = Me.cboAnios
        Me.pcAño.ShowPopup(Point.Empty)
        txtnewAnio.Select()
    End Sub

    Private Sub cboAnios_Click(sender As Object, e As EventArgs) Handles cboAnios.Click

    End Sub

    Private Sub cboAnios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAnios.SelectedIndexChanged
        'PeriodoGeneral = String.Format("{0:00}", Convert.ToInt32(txtMes.Value.Month)) & "/" & cboAnios.SelectedValue
        'AnioGeneral = cboAnios.SelectedValue
    End Sub

    Public Shared Function diasDelMes(mes As Integer, año As Integer) As Integer
        Select Case mes
            ' Enero
            ' Marzo
            ' Mayo
            ' Julio
            ' Agosto
            ' Octubre
            Case 0, 2, 4, 6, 7, 9, _
                11
                ' Diciembre
                Return 31
                ' Abril
                ' Junio
                ' Septiembre
            Case 3, 5, 8, 10
                ' Noviembre
                Return 30
            Case 1
                ' Febrero
                If ((año Mod 100 = 0) AndAlso (año Mod 400 = 0)) OrElse ((año Mod 100 <> 0) AndAlso (año Mod 4 = 0)) Then
                    Return 29
                Else
                    ' Año Bisiesto
                    Return 28
                End If


            Case Else
                Throw New Exception("El mes debe estar entre 0 y 11")
        End Select
    End Function

    Private Sub txtMes_ValueChanged(sender As Object, e As EventArgs) Handles txtMes.ValueChanged
        'PeriodoGeneral = String.Format("{0:00}", Convert.ToInt32(txtMes.Value.Month)) & "/" & cboAnios.SelectedValue
        'MesGene ral = String.Format("{0:00}", Convert.ToInt32(txtMes.Value.Month))
        'Dim s = diasDelMes(txtMes.Value.Month - 1, cboAnios.Text)
        'txtDiaLaboral.Value = DateTime.Now
        txtDiaLaboral.Value = New DateTime(cboAnios.Text, txtMes.Value.Month, 1)
        'txtDiaLaboral.MinValue = New DateTime(cboAnios.Text, txtMes.Value.Month, 1)

    End Sub

    Private Sub nudTipoCambio_ValueChanged(sender As Object, e As EventArgs) Handles nudTipoCambio.ValueChanged
        'TmpTipoCambio = nudTipoCambio.Value
    End Sub

    Private Sub ButtonAdv12_Click(sender As Object, e As EventArgs) Handles ButtonAdv12.Click
        PopupControlContainer3.Font = New Font("Tahoma", 8)
        PopupControlContainer3.Size = New Size(344, 130)
        Me.PopupControlContainer3.ParentControl = Me.txtAlmacenTrab
        Me.PopupControlContainer3.ShowPopup(Point.Empty)
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        With frmNuevoAlmacen
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
            .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
            .txtEstablecimiento.Text = GEstableciento.NombreEstablecimiento
            .txtEstablecimiento.Tag = GEstableciento.IdEstablecimiento
            .txtEmpresa.Text = Gempresas.NomEmpresa
            .txtEmpresa.Tag = Gempresas.IdEmpresaRuc
            .StartPosition = FormStartPosition.CenterParent
            '.WindowState = FormWindowState.Maximized
            .ShowDialog()
        End With
    End Sub

    Private Sub PopupControlContainer3_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles PopupControlContainer3.BeforePopup
        Me.PopupControlContainer3.BackColor = Color.FromArgb(227, 241, 254)
    End Sub

    Private Sub PopupControlContainer3_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles PopupControlContainer3.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lstAlmacen.SelectedItems.Count > 0 Then
                Me.txtAlmacenTrab.ValueMember = lstAlmacen.SelectedValue
                txtAlmacenTrab.Text = lstAlmacen.Text

                'TmpIdAlmacen = lstAlmacen.SelectedValue
                'TmpNombreAlmacen = lstAlmacen.Text

                'For Each item In almacen
                '    If (txtAlmacenTrab.ValueMember = item.idAlmacen) Then
                '        '    nudPorGanancia.Value = item.porcentajeUtilidad
                '        '   TmpPorcGanacia = nudPorGanancia.Value
                '    End If
                'Next
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtAlmacenTrab.Focus()
        End If
    End Sub

    Private Sub popupControlContainer1_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles popupControlContainer1.BeforePopup
        Me.popupControlContainer1.BackColor = Color.FromArgb(227, 241, 254)
    End Sub

    Private Sub popupControlContainer1_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles popupControlContainer1.CloseUp
        Dim almacenSA As New almacenSA
        GEstableciento = New GEstablecimiento
        If e.PopupCloseType = PopupCloseType.Done Then
            If lstEstablecimiento.SelectedItems.Count > 0 Then
                Me.txtEstablecimiento.ValueMember = lstEstablecimiento.SelectedValue
                txtEstablecimiento.Text = lstEstablecimiento.Text
                txtEstablecimiento.ValueMember = DirectCast(Me.lstEstablecimiento.SelectedItem, Destablecimiento).Id
                ' ListadoProductosPorCategoriaTipoExistencia(txtCategoria.ValueMember, cboTipoExistencia.SelectedValue)
                GEstableciento.IdEstablecimiento = DirectCast(Me.lstEstablecimiento.SelectedItem, Destablecimiento).Id
                GEstableciento.NombreEstablecimiento = lstEstablecimiento.Text
                txtAlmacenTrab.Clear()
                txtAlmacenTrab.ValueMember = String.Empty
                lstAlmacen.DisplayMember = "descripcionAlmacen"
                lstAlmacen.ValueMember = "idAlmacen"
                almacen = almacenSA.GetListar_almacenExceptAV(txtEstablecimiento.ValueMember)
                lstAlmacen.DataSource = almacen
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtEstablecimiento.Focus()
        End If
    End Sub

    Private Sub pcAño_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles pcAño.BeforePopup
        Me.pcAño.BackColor = Color.FromArgb(227, 241, 254)
    End Sub

    Private Sub pcAño_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcAño.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then

            If ButtonAdv11.Tag = "G" Then
                GrabarAnio()
                ButtonAdv11.Tag = "N"
            Else
                pcAño.Font = New Font("Tahoma", 8)
                pcAño.Size = New Size(141, 83)
                Me.pcAño.ParentControl = Me.cboAnios
                Me.pcAño.ShowPopup(Point.Empty)
            End If

        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.cboAnios.Focus()
        End If
    End Sub

    Private Sub ButtonAdv13_Click(sender As Object, e As EventArgs) Handles ButtonAdv13.Click
        PopupControlContainer4.Font = New Font("Tahoma", 8)
        PopupControlContainer4.Size = New Size(300, 200)
        Me.PopupControlContainer4.ParentControl = ButtonAdv13
        Me.PopupControlContainer4.ShowPopup(Point.Empty)
        txtbuscarItems.Select()
        txtbuscarItems.Focus()
        UbicarExistencias()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Me.PopupControlContainer4.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.PopupControlContainer4.HidePopup(PopupCloseType.Canceled)
    End Sub

    Private Sub dgvItems_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvItems.CellContentClick

    End Sub

    Private Sub dgvItems_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvItems.CellEndEdit
        If (dgvItems.Item(2, dgvItems.CurrentRow.Index).Value >= 0) Then
            dgvItems.Item(3, dgvItems.CurrentRow.Index).Value = 1
        End If
    End Sub

    Private Sub txtbuscarItems_TextChanged(sender As Object, e As EventArgs) Handles txtbuscarItems.TextChanged
        dtTableGrd.DefaultView.RowFilter = "Descripcion Like '%" & txtbuscarItems.Text & "%'"
    End Sub

    Private Sub PopupControlContainer4_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles PopupControlContainer4.BeforePopup
        Me.PopupControlContainer4.BackColor = Color.FromArgb(227, 241, 254)
    End Sub

    Private Sub PopupControlContainer4_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles PopupControlContainer4.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            'If dgvItems.SelectedRows.Count > 0 Then
            updateUtilidadExistencias()
            'End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
        End If
    End Sub

    Private Sub lstAlmacen_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstAlmacen.MouseDoubleClick
        Me.PopupControlContainer3.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub lstEstablecimiento_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstEstablecimiento.MouseDoubleClick
        Me.popupControlContainer1.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub cboIVA_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub nupIGV_ValueChanged(sender As Object, e As EventArgs) Handles nupIGV.ValueChanged
        'TmpIGV = nupIGV.Value
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ButtonAdv11_Click(sender As Object, e As EventArgs) Handles ButtonAdv11.Click
        pcAño.Font = New Font("Tahoma", 8)
        pcAño.Size = New Size(141, 83)
        Me.pcAño.ParentControl = Me.cboAnios
        Me.pcAño.ShowPopup(Point.Empty)
        txtnewAnio.Select()

        ButtonAdv11.Tag = "G"
        Me.pcAño.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub ButtonAdv7_Click(sender As Object, e As EventArgs) Handles ButtonAdv7.Click
        Me.pcAño.HidePopup(PopupCloseType.Canceled)
    End Sub

    Private Sub frmConfigInicioXempresa_Shown(sender As Object, e As EventArgs) Handles Me.Shown

    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Dispose()
    End Sub

    Private Sub pcNuevoEstablecimiento_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles pcNuevoEstablecimiento.BeforePopup
        Me.pcNuevoEstablecimiento.BackColor = Color.FromArgb(227, 241, 254)
    End Sub

    Private Sub pcNuevoEstablecimiento_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcNuevoEstablecimiento.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If Not txtNewEstable.Text.Trim.Length > 0 Then
                '  lblEstado.Text = "Ingrese el nombre de la clasificación"
                pcNuevoEstablecimiento.Font = New Font("Tahoma", 8)
                pcNuevoEstablecimiento.Size = New Size(322, 148)
                Me.pcNuevoEstablecimiento.ParentControl = Me.txtEstablecimiento
                Me.pcNuevoEstablecimiento.ShowPopup(Point.Empty)
                txtNewEstable.Select()
                Exit Sub
            End If


            If ButtonAdv1.Tag = "G" Then
                GrabarEstablecimiento()
                ButtonAdv1.Tag = "N"
            Else
                pcNuevoEstablecimiento.Font = New Font("Tahoma", 8)
                pcNuevoEstablecimiento.Size = New Size(322, 148)
                Me.pcNuevoEstablecimiento.ParentControl = Me.txtEstablecimiento
                Me.pcNuevoEstablecimiento.ShowPopup(Point.Empty)
            End If

        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtEstablecimiento.Focus()
        End If
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        If Not txtNewEstable.Text.Trim.Length > 0 Then
            ' lblEstado.Text = "Ingrese el nombre de la clasificación"
            pcNuevoEstablecimiento.Font = New Font("Tahoma", 8)
            pcNuevoEstablecimiento.Size = New Size(318, 102)
            Me.pcNuevoEstablecimiento.ParentControl = Me.txtEstablecimiento
            Me.pcNuevoEstablecimiento.ShowPopup(Point.Empty)
            txtNewEstable.Select()
            Exit Sub
        End If
        ButtonAdv1.Tag = "G"
        Me.pcNuevoEstablecimiento.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click
        Me.pcNuevoEstablecimiento.HidePopup(PopupCloseType.Canceled)
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Me.Cursor = Cursors.WaitCursor
        If Not txtEstablecimiento.Text.Trim.Length > 0 Then
            Me.Cursor = Cursors.Arrow
            MessageBoxAdv.Show("Ingrese un establecimiento de trabajo!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If Not txtAlmacenTrab.Text.Trim.Length > 0 Then
            Me.Cursor = Cursors.Arrow
            MessageBoxAdv.Show("Ingrese un almacén de trabajo!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If Not nudTipoCambio.Value > 0 Then
            Me.Cursor = Cursors.Arrow
            MessageBoxAdv.Show("Ingrese un tipo de cambio mayor a cero!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If Not nupIGV.Value > 0 Then
            Me.Cursor = Cursors.Arrow
            MessageBoxAdv.Show("El valor del IVA debe ser mayor a cero!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Grabar()



        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        With frmTipoCambio
            .txtFechaIgv.Value = DateTime.Now
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            ObtenerTipoCambioMax()
        End With
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        ObtenerTipoCambioMax()
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub txtDiaLaboral_ValueChanged(sender As Object, e As EventArgs) Handles txtDiaLaboral.ValueChanged

    End Sub

    Private Sub txtFechaIgv_ValueChanged(sender As Object, e As EventArgs) Handles txtFechaIgv.ValueChanged

    End Sub

    Private Sub lstEstablecimiento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstEstablecimiento.SelectedIndexChanged

    End Sub
End Class