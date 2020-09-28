Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Femiani.Forms.UI.Input
Public Class frmModalCajaXEmpresa
    Inherits frmMaster


    Dim ACTDBSuggestions As New AutoCompleteStringCollection()
    Dim sgstBancos As New AutoCompleteStringCollection()
    Public Property strEstadoManipulacion() As String
    Public Property ImporteDB() As Decimal = 0
    Public Property IdDocFueNte() As Integer
    Public Property idEstados() As Integer

    'Public Property IdUnidOrg() As Integer

    Public Sub New(Id As Integer)

        ' This call is required by the designer.
        InitializeComponent()
        loADcmb()
        ' Add any initialization after the InitializeComponent() call.
        txtFecha.Value = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        'IdUnidOrg = Id
        ListarUnidOrganicas()
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        loADcmb()
        ' Add any initialization after the InitializeComponent() call.
        txtFecha.Value = New DateTime(AnioGeneral, MesGeneral, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        ListarUnidOrganicas()
    End Sub

#Region "Métodos"

    Public Sub ListarUnidOrganicas()

        Try
            Dim sa As New CentrocostosSA


            Dim ListaUnidadOrganica = New List(Of centrocosto)


            ListaUnidadOrganica = (sa.GetObtenerEstablecimiento(Gempresas.IdEmpresaRuc).Where(Function(o) o.TipoEstab = "UN").ToList)



            cboUnidOrg.ValueMember = "idCentroCosto"
            cboUnidOrg.DisplayMember = "nombre"
            cboUnidOrg.DataSource = ListaUnidadOrganica

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Sub loADcmb()
        Dim tablaSA As New tablaDetalleSA
        cboBanco.DisplayMember = "descripcion"
        cboBanco.ValueMember = "codigoDetalle"
        cboBanco.DataSource = tablaSA.GetListaTablaDetalle(3, "1")
        txtCodigoCuenta.Text = "104"
    End Sub

    Public Sub UbicarPorID(intCodigo As Integer)
        Dim entidadSA As New EstadosFinancierosSA

        With entidadSA.GetUbicar_estadosFinancierosPorID(intCodigo)
            Select Case .tipo
                Case "EF"
                    cboTipoCuenta.Text = "Efectivo"
                Case "BC"
                    cboTipoCuenta.Text = "Banco"
                Case "TC"
                    cboTipoCuenta.Text = "Tarjeta de Crédito"
            End Select
            cboBanco.SelectedValue = .idBanco
            txtFecha.Value = .fechaBalance
            Select Case cboTipoCuenta.Text
                Case "EF"
                    cboTipoCuenta.Text = "Efectivo"

                Case "TC"
                    cboTipoCuenta.Text = "Tarjeta de Crédito"
                Case "BC"
                    cboTipoCuenta.Text = "Banco"
            End Select
            Select Case .codigo
                Case "1"
                    cboMoneda.Text = "MONEDA NACIONAL"
                Case "2"
                    cboMoneda.Text = "MONEDA EXTRANJERA"
            End Select

            txtBalanceInicial.DecimalValue = .importeBalanceMN
            ImporteDB = .importeBalanceMN
            txtDescripcion.Tag = .idestado
            txtDescripcion.Text = .descripcion
            txtCuentaID.Text = .cuenta
            txtNumCuentaCorriente.Text = .nroCtaCorriente

            IdDocFueNte = .usuarioActualizacion
        End With
    End Sub

    Public Function GetDocumento() As documento
        Dim documentoSA As New DocumentoSA
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim ndocumento As New documento
        Dim ndocumentoCaja As New documentoCaja
        Dim ndocumentoCajaDetalle As New documentoCajaDetalle
        Dim ListadocumentoCajaDetalle As New List(Of documentoCajaDetalle)
        Dim asiento As New asiento
        Dim ListaAsiento As New List(Of asiento)

        With ndocumento
            .idDocumento = IdDocFueNte
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = cboUnidOrg.SelectedValue  'GEstableciento.IdEstablecimiento
            '       .idProyecto = GProyectos.IdProyectoActividad
            .tipoDoc = "001"
            .fechaProceso = txtFecha.Value
            .nroDoc = "-"
            .idOrden = Nothing
            .tipoOperacion = "01"
            .usuarioActualizacion = Nothing
            .fechaActualizacion = DateTime.Now
        End With

        With ndocumentoCaja
            '   .idDocumento = lblIdDocumento.Text

            .periodo = PeriodoGeneral
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idEstablecimiento = cboUnidOrg.SelectedValue  ' GEstableciento.IdEstablecimiento
            .tipoMovimiento = TIPO_VENTA.PAGO.COBRADO
            .TipoDocumentoPago = "001"
            .codigoProveedor = Nothing 'txtPersona.ValueMember
            .fechaProceso = txtFecha.Value
            .fechaCobro = txtFecha.Value
            .tipoDocPago = "001"
            .numeroDoc = "-"
            .moneda = cboMoneda.SelectedValue

            .codigoLibro = "9909"
            .tipoMovimiento = "DC"
            .tipoOperacion = "OEC"
            .entidadFinanciera = 0

            .numeroOperacion = "-"
            .tipoCambio = 1
            .montoSoles = txtBalanceInicial.DecimalValue
            .montoUsd = txtBalanceInicial.DecimalValue
            .glosa = "Ingreso de dinero por apertura de cuenta financiera"
            .entregado = "SI"
            .usuarioModificacion = Nothing
            .fechaModificacion = DateTime.Now
        End With

        ndocumento.documentoCaja = ndocumentoCaja

        ndocumentoCajaDetalle = New documentoCajaDetalle
        ndocumentoCajaDetalle.fecha = txtFecha.Value
        ndocumentoCajaDetalle.idItem = "00"
        ndocumentoCajaDetalle.DetalleItem = "Ingreso de dinero por apertura de cuenta financiera"
        ndocumentoCajaDetalle.montoSoles = txtBalanceInicial.DecimalValue
        ndocumentoCajaDetalle.montoUsd = txtBalanceInicial.DecimalValue

        ndocumentoCajaDetalle.entregado = "SI"
        '  ndocumentoCajaDetalle.DiferenciaTipoCambio = 0

        ndocumentoCajaDetalle.documentoAfectado = 0
        ndocumentoCajaDetalle.usuarioModificacion = Nothing
        ndocumentoCajaDetalle.fechaModificacion = Date.Now
        ListadocumentoCajaDetalle.Add(ndocumentoCajaDetalle)

        AsientoContableCaja()
        ndocumento.asiento = ListaAsientos
        ndocumento.documentoCaja.documentoCajaDetalle = ListadocumentoCajaDetalle

        Return ndocumento
    End Function

    Public Property ListaAsientos As New List(Of asiento)

    Public Sub AsientoContableCaja()
        Dim asientoBL As New asiento
        Dim nMovimiento As New movimiento
        ListaAsientos = New List(Of asiento)
        asientoBL = New asiento
        asientoBL.idEmpresa = Gempresas.IdEmpresaRuc
        asientoBL.idCentroCostos = cboUnidOrg.SelectedValue  '= GEstableciento.IdEstablecimiento
        asientoBL.idEntidad = 0
        asientoBL.nombreEntidad = txtDescripcion.Text
        asientoBL.tipoEntidad = "BC"
        asientoBL.fechaProceso = txtFecha.Value
        asientoBL.codigoLibro = "1"
        asientoBL.tipo = "D"
        asientoBL.tipoAsiento = ASIENTO_CONTABLE.Finanzas

        asientoBL.importeMN = CDec(txtBalanceInicial.DecimalValue)
        asientoBL.importeME = CDec(txtBalanceInicial.DecimalValue)
        asientoBL.glosa = "Ingreso de dinero por apertura de cuenta financiera"


        nMovimiento = New movimiento
        Select Case cboTipoCuenta.Text
            Case "Efectivo"
                nMovimiento.cuenta = "101"
            Case "Tarjeta de Crédito"
                nMovimiento.cuenta = "104"
            Case "Banco"
                nMovimiento.cuenta = "104"
        End Select

        nMovimiento.descripcion = txtDescripcion.Text
        nMovimiento.tipo = "D"
        nMovimiento.monto = CDec(txtBalanceInicial.DecimalValue)
        nMovimiento.montoUSD = CDec(txtBalanceInicial.DecimalValue)
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        nMovimiento.fechaActualizacion = DateTime.Now
        asientoBL.movimiento.Add(nMovimiento)


        nMovimiento = New movimiento
        nMovimiento.cuenta = "2000"
        nMovimiento.descripcion = "Por regularizar"
        nMovimiento.tipo = "H"
        nMovimiento.monto = CDec(txtBalanceInicial.DecimalValue)
        nMovimiento.montoUSD = CDec(txtBalanceInicial.DecimalValue)
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        nMovimiento.fechaActualizacion = DateTime.Now
        asientoBL.movimiento.Add(nMovimiento)

        ListaAsientos.Add(asientoBL)
    End Sub

    Public Sub Grabar()
        Dim entidadSA As New EstadosFinancierosSA
        Dim entidad As New estadosFinancieros
        Dim Documento As New documento
        With entidad
            .idBanco = cboBanco.SelectedValue
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idEstablecimiento = cboUnidOrg.SelectedValue  ' GEstableciento.IdEstablecimiento
            .codigo = IIf(cboMoneda.Text = "MONEDA NACIONAL", "1", "2")
            .fechaBalance = txtFecha.Value
            Select Case cboTipoCuenta.Text
                Case "Caja especial"
                    .tipo = "EE"
                    .cuenta = txtCodigoCuenta.Text
                Case "Caja"
                    .tipo = "EF"
                    .cuenta = txtCodigoCuenta.Text
                Case "Tarjeta de Crédito"
                    .tipo = "TC"
                    .cuenta = txtCodigoCuenta.Text
                Case "Banco"
                    .tipo = "BC"
                    .cuenta = txtCodigoCuenta.Text
                Case "Caja Pos"
                    .tipo = "EP"
                    .cuenta = txtCodigoCuenta.Text
            End Select

            .descripcion = txtDescripcion.Text.Trim
            .nroCtaCorriente = txtNumCuentaCorriente.Text
            .tipocambio = 1
            .importeBalanceMN = 0 ' txtBalanceInicial.DecimalValue
            .importeBalanceME = 0 ' txtBalanceInicial.DecimalValue
            .usuarioActualizacion = Nothing
            .fechaActualizacion = DateTime.Now
        End With

        'Documento = GetDocumento()

        Dim xCod As Integer = entidadSA.InsertEFDoc(entidad, Nothing)
        lblEstado.Text = "entidad registrada"
        '  lblEstado.Image = My.Resources.ok4

        'Dim n As New ListViewItem(xCod)
        'n.SubItems.Add(txtDescripcion.Text)
        'n.SubItems.Add(IIf(entidad.tipo = "BC", "BANCO", "EFECTIVO"))
        'n.SubItems.Add(txtCuentaID.Text)
        'With frmMantenimientoCajas
        '    .lsvCajas.Items.Add(n)
        'End With
        Close()
    End Sub

    Public Sub Editar()
        Dim entidadSA As New EstadosFinancierosSA
        Dim entidad As New estadosFinancieros
        Dim Documento As New documento
        With entidad
            .idestado = txtDescripcion.Tag
            .idBanco = cboBanco.SelectedValue
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idEstablecimiento = cboUnidOrg.SelectedValue  ' GEstableciento.IdEstablecimiento
            .codigo = IIf(cboMoneda.Text = "MONEDA NACIONAL", "1", "2")
            .fechaBalance = txtFecha.Value
            Select Case cboTipoCuenta.Text
                Case "Caja"
                    .tipo = "EF"
                    .cuenta = cboCuenta.SelectedValue
                Case "Tarjeta de Crédito"
                    .tipo = "TC"
                    .cuenta = cboCuenta.SelectedValue
                Case "Banco"
                    .tipo = "BC"
                    .cuenta = cboCuenta.SelectedValue
                Case "Cajero"
                    .tipo = "EP"
                    .cuenta = txtCodigoCuenta.Text
            End Select

            .descripcion = txtDescripcion.Text.Trim
            .nroCtaCorriente = txtNumCuentaCorriente.Text
            .tipocambio = 1
            .importeBalanceMN = txtBalanceInicial.DecimalValue
            .importeBalanceME = txtBalanceInicial.DecimalValue
            .usuarioActualizacion = Nothing
            .fechaActualizacion = DateTime.Now
        End With

        If ImporteDB = txtBalanceInicial.DecimalValue Then
            Documento = Nothing
        Else
            Documento = GetDocumento()
        End If

        entidadSA.UpdateEFDoc(entidad, Documento)
        lblEstado.Text = "entidad actualizada"
        Close()
    End Sub

    Public Sub manipulacionDatos(strCondicion As Boolean)
        cboTipoCuenta.Enabled = strCondicion
        cboBanco.Enabled = strCondicion
        txtNumCuentaCorriente.Enabled = strCondicion
        cboCuenta.Enabled = strCondicion
        cboMoneda.Enabled = strCondicion
    End Sub

    Public Sub ObtenerMascaraMercaderia()
        Dim cuentaSA As New cuentaplanContableEmpresaSA

        Try
            ACTDBSuggestions.Clear()
            txtCuentaID.Items.Clear()
            Me.txtCuentaID.Text = String.Empty
            For Each i As cuentaplanContableEmpresa In cuentaSA.ObtenerCuentasConf(Gempresas.IdEmpresaRuc, "1")
                ACTDBSuggestions.Add(i.cuenta)
                Me.txtCuentaID.Items.Add(New AutoCompleteEntry(i.cuenta, i.cuenta, i.cuenta))
                Me.Validate()
            Next
        Catch ex As Exception
            lblEstado.Text = "No se pudo cargar la información para las cuentas. " & ex.Message
            lblEstado.Image = My.Resources.warning2
        End Try
    End Sub
#End Region
    Private Sub frmModalCaja_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmModalCaja_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Dim asientoSA As New cuentaplanContableEmpresaSA
        Dim DT As New DataTable("Table1")
        DT.Columns.Add("cuenta")
        DT.Columns.Add("descripcion")

        For Each i In asientoSA.ListarCuentasPorPadre(Gempresas.IdEmpresaRuc, "10")
            Dim dr As DataRow = DT.NewRow
            dr(0) = i.cuenta
            dr(1) = i.descripcion
            DT.Rows.Add(dr)
        Next

        Dim view As DataView = New DataView(DT)

        ' DATASOURCE is DATAVIEW

        Me.cboCuenta.DataSource = view

        Me.cboCuenta.DisplayMember = "descripcion"

        Me.cboCuenta.ValueMember = "cuenta"

    End Sub

    Private Sub Panel1_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        'Dim cuentaSA As New cuentaplanContableEmpresaSA
        'If txtCuentaID.Text.Trim.Length > 0 Then
        '    If ACTDBSuggestions.Contains(txtCuentaID.Text.Trim) Then
        '        '  lblEstado.Text = "Ingreso correcto - cuenta contable"
        '        lblEstado.Image = My.Resources.ok4
        '        lblEstado.Tag = "EX"
        '        txtCuenta.Text = cuentaSA.ObtenerCuentaPorID(Gempresas.IdEmpresaRuc, txtCuentaID.Text).descripcion
        '    Else
        '        lblEstado.Text = "cuenta contable no existente!"
        '        lblEstado.Image = My.Resources.warning2
        '        lblEstado.Tag = "NEX"
        '        txtCuenta.Text = String.Empty
        '    End If
        'End If
    End Sub

    Private Sub txtCuentaID_Load(sender As System.Object, e As System.EventArgs) Handles txtCuentaID.Load

    End Sub

    Private Sub txtCuentaID_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtCuentaID.Validating
        If txtCuentaID.Text.Trim.Length > 0 Then
            If ACTDBSuggestions.Contains(txtCuentaID.Text.Trim) Then
                lblEstado.Text = "Ingreso correcto - cuenta contable"
                lblEstado.Image = My.Resources.ok4
                lblEstado.Tag = "EX"
                e.Cancel = False

            Else
                lblEstado.Text = "cuenta contable no existente!"
                lblEstado.Image = My.Resources.warning2
                lblEstado.Tag = "NEX"
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub rbEfectivo_CheckedChanged(sender As System.Object, e As System.EventArgs)
        'If rbEfectivo.Checked = True Then
        '    txtDescripcion.Text = String.Empty
        '    txtNumCuentaCorriente.Enabled = False
        '    txtCuentaID.Text = "101"
        '    txtCuenta.Text = "CAJA / EFECTIVO"
        'End If
    End Sub

    Private Sub rbBanco_CheckedChanged(sender As System.Object, e As System.EventArgs)
        'If rbBanco.Checked = True Then
        '    txtDescripcion.Text = String.Empty
        '    txtNumCuentaCorriente.Enabled = True
        '    txtCuentaID.Text = "104"
        '    txtCuenta.Text = "CUENTAS CORRIENTES EN INSTITUCIONES FINANCIERAS"
        'End If
    End Sub

    Private Sub PegarToolStripButton_Click(sender As Object, e As EventArgs) Handles PegarToolStripButton.Click
        Dispose()
    End Sub


    Private Sub btGrabar_Click_1(sender As Object, e As EventArgs) Handles btGrabar.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            If Not txtDescripcion.Text.Trim.Length > 0 Then
                MessageBox.Show("Ingrese una descripción válida!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '    lblEstado.Image = My.Resources.warning2
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
            'If Not txtCuenta.Text.Trim.Length > 0 Then
            '    'lblEstado.Text = "Ingrese una cuenta válida!"
            '    MessageBox.Show("Ingrese una cuenta válida!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    '    lblEstado.Image = My.Resources.warning2
            '    Me.Cursor = Cursors.Arrow
            '    Exit Sub
            'End If

            If Not txtCodigoCuenta.Text.Trim.Length > 0 Then
                MessageBox.Show("Ingrese un código de cuenta contable válido!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                'lblEstado.Text = "Ingrese un código de cuenta contable válido!"
                txtCodigoCuenta.Select()
                '    lblEstado.Image = My.Resources.warning2
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
            If strEstadoManipulacion = ENTITY_ACTIONS.INSERT Then
                Grabar()
            ElseIf strEstadoManipulacion = ENTITY_ACTIONS.UPDATE Then
                Editar()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboTipoCuenta_Click(sender As Object, e As EventArgs) Handles cboTipoCuenta.Click

    End Sub

    Private Sub cboTipoCuenta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoCuenta.SelectedIndexChanged
        Select Case cboTipoCuenta.Text
            Case "Caja", "Caja Pos"
                cboBanco.Visible = False
                Label5.Visible = False
                txtNumCuentaCorriente.Visible = False
                Label8.Visible = False
                txtCodigoCuenta.Text = "101"
            Case "Tarjeta de Crédito"
                cboBanco.Visible = True
                Label5.Visible = True
                txtCodigoCuenta.Text = "104"
            Case "Banco"
                cboBanco.Visible = True
                Label5.Visible = True
                txtNumCuentaCorriente.Visible = True
                Label8.Visible = True
                txtCodigoCuenta.Text = "104"
        End Select
    End Sub

    Private Sub cboCuenta_Click(sender As Object, e As EventArgs) Handles cboCuenta.Click

    End Sub

    'Private Sub cboCuenta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCuenta.SelectedIndexChanged
    '    'If cboCuenta.SelectedIndex > 0 Then
    '    '    Select Case cboTipoCuenta.Text
    '    '        Case "Efectivo"
    '    '            cboCuenta.SelectedValue = "101"
    '    '        Case "Tarjeta de Crédito"
    '    '            cboCuenta.SelectedValue = "104"
    '    '        Case "Banco"
    '    '            cboCuenta.SelectedValue = "104"
    '    '    End Select
    '    Dim value As Object = cboCuenta.SelectedValue

    '    If (TypeOf value Is Integer) Then
    '        ' Lo pasamos a la función únicamente si es
    '        ' del tipo Integer.
    '        '
    '        txtCodigoCuenta.Text = cboCuenta.SelectedValue & "1"
    '    End If

    'End Sub

    Private Sub cboCuenta_SelectedIndexChanging(sender As Object, e As Syncfusion.Windows.Forms.Tools.SelectedIndexChangingArgs) Handles cboCuenta.SelectedIndexChanging
        Dim value As Object = cboCuenta.SelectedValue

        If (TypeOf value Is String) Then
            ' Lo pasamos a la función únicamente si es
            ' del tipo Integer.
            '
            txtCodigoCuenta.Text = cboCuenta.SelectedValue
        End If
    End Sub

    Private Sub cboCuenta_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboCuenta.SelectedValueChanged

    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click

    End Sub
End Class