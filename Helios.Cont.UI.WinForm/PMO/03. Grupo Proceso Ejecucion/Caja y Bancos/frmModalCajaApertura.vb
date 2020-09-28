Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Femiani.Forms.UI.Input
Public Class frmModalCajaApertura
    Inherits frmMaster

    Dim ACTDBSuggestions As New AutoCompleteStringCollection()
    Dim sgstBancos As New AutoCompleteStringCollection()
    Public Property strEstadoManipulacion() As String
    Public Property ImporteDB() As Decimal = 0
    Public Property IdDocFueNte() As Integer

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        loADcmb()
        txtFecha.Value = New DateTime(AnioGeneral, MesGeneral, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        txtTipoCambio.DecimalValue = TmpTipoCambio
    End Sub


#Region "Métodos"

    Sub loADcmb()
        Dim tablaSA As New tablaDetalleSA
        cboBanco.DisplayMember = "descripcion"
        cboBanco.ValueMember = "codigoDetalle"
        cboBanco.DataSource = tablaSA.GetListaTablaDetalle(3, "1")
        txtCodigoCuenta.Text = "101"
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
            'txtCuentaID.Text = .cuenta
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
            .idCentroCosto = GEstableciento.IdEstablecimiento
            '       .idProyecto = GProyectos.IdProyectoActividad
            .idEntidad = usuario.IDUsuario
            .entidad = usuario.CustomUsuario.Full_Name
            .tipoEntidad = "US"
            .nrodocEntidad = usuario.CustomUsuario.NroDocumento
            .tipoDoc = "001"
            .fechaProceso = txtFecha.Value
            .nroDoc = "-"
            .idOrden = Nothing
            .tipoOperacion = "105"
            .usuarioActualizacion = Nothing
            .fechaActualizacion = DateTime.Now
        End With

        With ndocumentoCaja
            '   .idDocumento = lblIdDocumento.Text

            .periodo = PeriodoGeneral
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idEstablecimiento = GEstableciento.IdEstablecimiento
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
            .estado = "S"
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

        'AsientoContableCaja()
        ndocumento.asiento = Nothing ' ListaAsientos
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
        asientoBL.idCentroCostos = GEstableciento.IdEstablecimiento
        asientoBL.idEntidad = 0
        asientoBL.nombreEntidad = txtDescripcion.Text
        asientoBL.tipoEntidad = "BC"
        asientoBL.fechaProceso = txtFecha.Value
        asientoBL.codigoLibro = "1"
        asientoBL.tipo = "D"
        asientoBL.tipoAsiento = ASIENTO_CONTABLE.OTRAS_ENTRADAS_CAJA

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
        nMovimiento.usuarioActualizacion = "Jiuni"
        nMovimiento.fechaActualizacion = DateTime.Now
        asientoBL.movimiento.Add(nMovimiento)


        nMovimiento = New movimiento
        nMovimiento.cuenta = "2000"
        nMovimiento.descripcion = "Por regularizar"
        nMovimiento.tipo = "H"
        nMovimiento.monto = CDec(txtBalanceInicial.DecimalValue)
        nMovimiento.montoUSD = CDec(txtBalanceInicial.DecimalValue)
        nMovimiento.usuarioActualizacion = "Jiuni"
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
            .idEstablecimiento = GEstableciento.IdEstablecimiento
            .codigo = IIf(cboMoneda.Text = "MONEDA NACIONAL", "1", "2")
            .fechaBalance = txtFecha.Value
            Select Case cboTipoCuenta.Text
                Case "Efectivo"
                    .tipo = "EF"
                    .cuenta = txtCodigoCuenta.Text
                Case "Tarjeta de Crédito"
                    .tipo = "TC"
                    .cuenta = txtCodigoCuenta.Text
                Case "Banco"
                    .tipo = "BC"
                    .cuenta = txtCodigoCuenta.Text
            End Select

            .descripcion = txtDescripcion.Text.Trim
            .nroCtaCorriente = txtNumCuentaCorriente.Text
            .tipocambio = txtTipoCambio.DecimalValue
            .importeBalanceMN = txtBalanceInicial.DecimalValue
            .importeBalanceME = txtBalanceInicialme.DecimalValue
            .usuarioActualizacion = Nothing
            .fechaActualizacion = DateTime.Now
        End With

        Documento = GetDocumento()
        Dim xCod As Integer = entidadSA.GrabarEFApertura(entidad, Documento)
        MessageBox.Show("Entidad Financ. registrada", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Dispose()
    End Sub

    Public Sub Editar()
        Dim entidadSA As New EstadosFinancierosSA
        Dim entidad As New estadosFinancieros
        Dim Documento As New documento
        With entidad
            .idestado = txtDescripcion.Tag
            .idBanco = cboBanco.SelectedValue
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idEstablecimiento = GEstableciento.IdEstablecimiento
            .codigo = IIf(cboMoneda.Text = "MONEDA NACIONAL", "1", "2")
            .fechaBalance = txtFecha.Value
            Select Case cboTipoCuenta.Text
                Case "Efectivo"
                    .tipo = "EF"
                    .cuenta = cboCuenta.SelectedValue
                Case "Tarjeta de Crédito"
                    .tipo = "TC"
                    .cuenta = cboCuenta.SelectedValue
                Case "Banco"
                    .tipo = "BC"
                    .cuenta = cboCuenta.SelectedValue
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
        'lblEstado.Text = "entidad actualizada"
        Dispose()
    End Sub

#End Region

    Private Sub frmModalCajaApertura_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmModalCajaApertura_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

    Private Sub btGrabar_Click(sender As Object, e As EventArgs) Handles btGrabar.Click
        Me.Cursor = Cursors.WaitCursor
        If Not txtDescripcion.Text.Trim.Length > 0 Then
            MessageBox.Show("Ingrese una descripción válida!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If

        If Not txtCodigoCuenta.Text.Trim.Length > 0 Then
            MessageBox.Show("Ingrese un código de cuenta contable válido!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCodigoCuenta.Select()
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If
        If strEstadoManipulacion = ENTITY_ACTIONS.INSERT Then
            Grabar()
        ElseIf strEstadoManipulacion = ENTITY_ACTIONS.UPDATE Then
            Editar()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboTipoCuenta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoCuenta.SelectedIndexChanged
        Select Case cboTipoCuenta.Text
            Case "Efectivo"
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

    Private Sub cboCuenta_SelectedIndexChanging(sender As Object, e As Syncfusion.Windows.Forms.Tools.SelectedIndexChangingArgs) Handles cboCuenta.SelectedIndexChanging
        Dim value As Object = cboCuenta.SelectedValue

        If (TypeOf value Is String) Then
            ' Lo pasamos a la función únicamente si es
            ' del tipo Integer.
            '
            txtCodigoCuenta.Text = cboCuenta.SelectedValue
        End If
    End Sub

    Private Sub cboMoneda_Click(sender As Object, e As EventArgs) Handles cboMoneda.Click

    End Sub

    Private Sub cboMoneda_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMoneda.SelectedIndexChanged
        Select Case cboMoneda.Text
            Case "MONEDA NACIONAL"
                lbltipoCambio.Visible = False
                txtTipoCambio.Visible = False

                lblBalanceME.Visible = False
                txtBalanceInicialme.Visible = False

            Case Else

                lbltipoCambio.Visible = True
                txtTipoCambio.Visible = True

                lblBalanceME.Visible = True
                txtBalanceInicialme.Visible = True

        End Select
        'txtTipoCambio_TextChanged(sender, e)
    End Sub

    Private Sub txtTipoCambio_TextChanged(sender As Object, e As EventArgs) Handles txtTipoCambio.TextChanged
        'Select Case cboMoneda.Text
        '    Case "MONEDA NACIONAL"
        '        Dim balME As Decimal = Math.Round(txtBalanceInicial.DecimalValue / txtTipoCambio.DecimalValue, 2)
        '        txtBalanceInicialme.DecimalValue = balME
        '    Case Else
        '        Dim balMN As Decimal = Math.Round(txtBalanceInicialme.DecimalValue * txtTipoCambio.DecimalValue, 2)
        '        txtBalanceInicial.DecimalValue = balMN

        'End Select
    End Sub

    Private Sub txtBalanceInicial_TextChanged(sender As Object, e As EventArgs) Handles txtBalanceInicial.TextChanged
        'txtTipoCambio_TextChanged(sender, e)
        Select Case cboMoneda.Text
            Case "MONEDA NACIONAL"
                'Dim balME As Decimal = Math.Round(txtBalanceInicial.DecimalValue / txtTipoCambio.DecimalValue, 2)
                'txtBalanceInicialme.DecimalValue = balME
            Case Else
                Dim balMN As Decimal = txtBalanceInicial.DecimalValue
                Dim balME As Decimal = txtBalanceInicialme.DecimalValue
                If txtBalanceInicial.DecimalValue > 0 And txtBalanceInicialme.DecimalValue > 0 Then
                    Dim tc As Decimal = balMN / balME
                    txtTipoCambio.DecimalValue = tc
                End If
        End Select
    End Sub

    Private Sub txtBalanceInicialme_TextChanged(sender As Object, e As EventArgs) Handles txtBalanceInicialme.TextChanged
        'txtTipoCambio_TextChanged(sender, e)
        Select Case cboMoneda.Text
            Case "MONEDA NACIONAL"
                'Dim balME As Decimal = Math.Round(txtBalanceInicial.DecimalValue / txtTipoCambio.DecimalValue, 2)
                'txtBalanceInicialme.DecimalValue = balME
            Case Else
                Dim balMN As Decimal = txtBalanceInicial.DecimalValue
                Dim balME As Decimal = txtBalanceInicialme.DecimalValue
                If txtBalanceInicial.DecimalValue > 0 And txtBalanceInicialme.DecimalValue > 0 Then
                    Dim tc As Decimal = balMN / balME
                    txtTipoCambio.DecimalValue = tc
                End If

        End Select
    End Sub
End Class