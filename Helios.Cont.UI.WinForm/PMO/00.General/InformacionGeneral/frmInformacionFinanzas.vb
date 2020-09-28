Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Chart
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping

Public Class frmInformacionFinanzas
    Inherits frmMaster

#Region "Attributes"
    Dim listaCuentasFinancieras As List(Of Integer)
    Dim listaUsuario As New List(Of cajaUsuario)
    Dim listaID As List(Of Integer)
    Public ListaEstadosFinancieros As List(Of estadosFinancieros)
    Dim ListacajausuarioXEntidadFinanciera As New documentoCaja
    Dim ListaCajaBancosXUsuarios As New List(Of documentoCaja)
    Dim listaMeses As New List(Of MesesAnio)
    Dim charthelp As Syncfusion.GridHelperClasses.GroupingChartHelper = New Syncfusion.GridHelperClasses.GroupingChartHelper()
#End Region

#Region "Constructors"
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        LoadCombos()
        FormatoGridAvanzado(GridResumenFormaPago, True, False, 10.0F)
        FormatoGridAvanzado(GridBeneficios, False, False, 10.0F)
        FormatoGridAvanzado(GridDetalleFormaPago, True, False, 10.0F)
        GetCierreCajaDinero()
        txtFechaLaboral.Value = Date.Now
        txtFechaLaboral.Enabled = True
        'dtFechaInicio.Value = Date.Now
        'dtFechaFin.Value = Date.Now
        'txtAnioCompra.Text = AnioGeneral
        'Meses()

    End Sub

#End Region

#Region "Methods"

    Private Sub GetDetalleMovByFormaPago(IDFormapago As String)
        Dim cajaSA As New DocumentoCajaSA
        Dim dt As New DataTable
        dt.Columns.Add("persona")
        dt.Columns.Add("nroident")
        dt.Columns.Add("movimiento")
        dt.Columns.Add("monto")

        Dim DocumentoBE = New documentoCaja
        DocumentoBE.idEmpresa = Gempresas.IdEmpresaRuc
        DocumentoBE.idEstablecimiento = GEstableciento.IdEstablecimiento
        DocumentoBE.ListaIDCajas = listaCuentasFinancieras
        DocumentoBE.IDformapago = IDFormapago


        Dim movimiento As String = String.Empty

        For Each i In cajaSA.GetMovimientosByFormaPago(DocumentoBE, listaID)
            Select Case i.tipoMovimiento
                Case "DC"
                    movimiento = "Ingreso"
                Case "PG"
                    movimiento = "Egreso"
                Case Else
                    movimiento = "Otros"
            End Select

            dt.Rows.Add(i.NombreEntidad, i.numeroDoc, movimiento, i.montoSoles)
        Next
        GridDetalleFormaPago.DataSource = dt
    End Sub

    Public Sub GetSumarioVentas()
        Dim totalEfectivo As Decimal = 0
        Dim totalOtros As Decimal = 0
        For Each i In GridResumenFormaPago.Table.Records
            If i.GetValue("formapago") = "EFECTIVO" Then
                totalEfectivo += CDec(i.GetValue("importe"))
            Else
                totalOtros += CDec(i.GetValue("importe"))
            End If
        Next
        LabelBase.Text = totalEfectivo.ToString("N2")
        LabelTotalOtros.Text = totalOtros.ToString("N2")

        LabelTotalCierre.Text = CDec(totalEfectivo + totalOtros).ToString("N2")
    End Sub

    Sub Sumaarqueo()
        Dim suma As Decimal = 0
        For Each i In GridBeneficios.Table.Records
            suma += CDec(i.GetValue("importe"))
        Next
        Label69.Text = suma.ToString("N2")
    End Sub

    Private Sub GuardarCierre()

        Dim cajaUsuarioSA As New cajaUsuarioSA
        Dim objcajaUsuario As New cajaUsuario
        Dim nDocumento As New documento
        Dim asiento As New asiento
        Dim ListaAsiento As New List(Of asiento)
        Try
            GridBeneficios.TableControl.CurrentCell.EndEdit()
            GridBeneficios.TableControl.Table.TableDirty = True
            GridBeneficios.TableControl.Table.EndEdit()

            With objcajaUsuario
                .idcajaUsuario = CInt(TextboxJiu1.Tag)
                .fechaCierre = DateTimePickerAdv1.Value
                .enUso = "N"
                .estadoCaja = "C"
                .otrosEgresosMN = 0 ' nudImporteEgresosmn.Value
                .otrosEgresosME = 0 ' nudImporteEgresosme.Value
                .ingresoAdicMN = 0 ' nudIngresoMN.Value
                .ingresoAdicME = 0 'nudIngresoME.Value
                .idCajaCierre = 0 ' txtCajaDestino.ValueMember
            End With

            objcajaUsuario.cajaUsuarioDineroEntregado = New List(Of cajaUsuarioDineroEntregado)
            For Each i In GridBeneficios.Table.Records
                objcajaUsuario.cajaUsuarioDineroEntregado.Add(New cajaUsuarioDineroEntregado With
                                                              {
                                                              .idcajaUsuario = CInt(TextboxJiu1.Tag),
                                                              .equivalencia = Decimal.Parse(i.GetValue("equivalencia")),
                                                              .cantidad = Decimal.Parse(i.GetValue("cantidad")),
                                                              .importe = Decimal.Parse(i.GetValue("importe")),
                                                              .usuarioActualizacion = usuario.IDUsuario,
                                                              .fechaActualizacion = Date.Now
                                                              })
            Next

            If CDec(LabelTotalOtros.Text) > 0 Then
                objcajaUsuario.cajaUsuarioDineroEntregado.Add(New cajaUsuarioDineroEntregado With
                                                              {
                                                              .idcajaUsuario = CInt(TextboxJiu1.Tag),
                                                              .equivalencia = 0,
                                                              .cantidad = 1,
                                                              .importe = CDec(LabelTotalOtros.Text),
                                                              .usuarioActualizacion = usuario.IDUsuario,
                                                              .fechaActualizacion = Date.Now
                                                              })
            End If

            nDocumento.CustomDocumentoCaja = Nothing

            Dim cajausuario As cajaUsuario = cajaUsuarioSA.CerrarCajaUsuario(objcajaUsuario, nDocumento)
            MessageBox.Show("Caja cerrada con exito!", "Caja finalizada", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Tag = "cerrado"
            Dim user = ListaCajasActivas.Where(Function(o) o.idcajaUsuario = CInt(TextboxJiu1.Tag)).SingleOrDefault
            If user IsNot Nothing Then
                ListaCajasActivas.Remove(user)
            End If
            Close()
        Catch ex As Exception
            Tag = Nothing
        End Try
    End Sub

    Private Sub GetCierreCajaDinero()
        Dim dt As New DataTable
        dt.Columns.Add("idItem")
        dt.Columns.Add("detalle")
        dt.Columns.Add("equivalencia")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("importe")

        dt.Rows.Add(0, "200 (Billete)", 200, 0, 0)
        dt.Rows.Add(0, "100 (Billete)", 100, 0, 0)
        dt.Rows.Add(0, "50 (Billete)", 50, 0, 0)
        dt.Rows.Add(0, "20 (Billete)", 20, 0, 0)
        dt.Rows.Add(0, "10 (Billete)", 10, 0, 0)
        dt.Rows.Add(0, "5 SOL", 5, 0, 0)
        dt.Rows.Add(0, "2 SOL", 2, 0, 0)
        dt.Rows.Add(0, "1 SOL", 1, 0, 0)
        dt.Rows.Add(0, "0.20 CENTIMOS", 0.2, 0, 0)
        dt.Rows.Add(0, "0.10 CENTIMOS", 0.1, 0, 0)
        dt.Rows.Add(0, "0.05 CENTIMOS", 0.05, 0, 0)
        dt.Rows.Add(0, "0.01 CENTIMOS", 0.01, 0, 0)
        GridBeneficios.DataSource = dt

        GridBeneficios.TableDescriptor.Columns("equivalencia").Width = 0
    End Sub


    Private Sub GetChartFormaPago()

        Me.chartControl1.CustomPalette = New Color() {(System.Drawing.Color.FromArgb((CInt(((CByte((17)))))), (CInt(((CByte((158)))))), (CInt(((CByte((218)))))))), (System.Drawing.Color.FromArgb((CInt(((CByte((222)))))), (CInt(((CByte((62)))))), (CInt(((CByte((108)))))))), (System.Drawing.Color.FromArgb((CInt(((CByte((252)))))), (CInt(((CByte((218)))))), (CInt(((CByte((33)))))))), Color.Cyan, Color.BlueViolet, Color.Brown, Color.Chocolate, Color.RoyalBlue}

        charthelp.Wire(Me.GridResumenFormaPago, Me.chartControl1, "formapago", New ArrayList From {
        "importe"
    })

        Me.chartControl1.Palette = ChartColorPalette.Custom
        Me.chartControl1.PrimaryYAxis.Title = "Total"
        Me.chartControl1.PrimaryYAxis.TitleColor = Color.DarkBlue
        Me.chartControl1.PrimaryYAxis.TitleFont = New Font("Segoe UI", 10, FontStyle.Bold)
        Me.chartControl1.PrimaryXAxis.Title = "Forma de pago" & "- " & "Items"
        Me.chartControl1.PrimaryXAxis.TitleColor = Color.DarkBlue
        Me.chartControl1.PrimaryXAxis.TitleFont = New Font("Segoe UI", 10, FontStyle.Bold)
        chartControl1.ColumnWidthMode = ChartColumnWidthMode.RelativeWidthMode
        EnableSelection()
    End Sub

    Private Sub EnableSelection()
        Me.GridResumenFormaPago.TableModel.Options.AllowSelection = Grid.GridSelectionFlags.Any
        Me.GridResumenFormaPago.TableModel.Options.ListBoxSelectionMode = SelectionMode.MultiExtended
        charthelp.ViewType = ViewType.SelectionView
        Me.CheckBox1.Checked = False
    End Sub

    Private Sub LoadCombos()
        Dim estableSA As New establecimientoSA
        ComboEstable.DataSource = estableSA.ObtenerListaEstablecimientos(Gempresas.IdEmpresaRuc).Where(Function(o) o.TipoEstab = "UN").ToList
        ComboEstable.DisplayMember = "nombre"
        ComboEstable.ValueMember = "idCentroCosto"
        ComboEstable.Text = GEstableciento.NombreEstablecimiento
    End Sub

    Private Sub GetResumenFormaPago(ListaCajas As List(Of Integer))
        Dim cajaSA As New DocumentoCajaSA

        Dim dt As New DataTable()
        dt.Columns.Add("formapago")
        dt.Columns.Add("importe")
        dt.Columns.Add("IDForma")
        For Each i In cajaSA.GetResumenXFormaPago(New documentoCaja With
                                                  {
                                                  .idEmpresa = Gempresas.IdEmpresaRuc,
                                                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                  .idCajaUsuario = listaID.First,
                                                  .ListaIDCajas = ListaCajas
                                                  })

            dt.Rows.Add(i.formapago, i.TotalIngresos.GetValueOrDefault - i.TotalEgresos.GetValueOrDefault, i.IDformapago)

        Next
        GridResumenFormaPago.DataSource = dt

        GetChartFormaPago()
    End Sub

    Private Sub Meses()
        listaMeses = New List(Of MesesAnio)
        Dim obj As New MesesAnio
        For x = 1 To 12
            obj = New MesesAnio
            obj.Codigo = String.Format("{0:00}", CInt(x))
            obj.Mes = New DateTime(AnioGeneral, x, 1).ToString("MMMM")
            listaMeses.Add(obj)
        Next x

        cboMesCompra.DisplayMember = "Mes"
        cboMesCompra.ValueMember = "Codigo"
        cboMesCompra.DataSource = listaMeses
        cboMesCompra.SelectedValue = MesGeneral
    End Sub

    Public Sub consultaMovimientoCaja()
        Dim cajaBE As New cajaUsuario
        Dim DocCajaSA As New DocumentoCajaSA

        cajaBE = New cajaUsuario
        cajaBE.idEmpresa = Gempresas.IdEmpresaRuc
        cajaBE.idEstablecimiento = ComboEstable.SelectedValue '  GEstableciento.IdEstablecimiento
        cajaBE.estadoCaja = "A"

        ListaCajaBancosXUsuarios = DocCajaSA.ResumenEntidadesFinancieras(cajaBE, listaID)

        'cboEntidades.DataSource = ListaCajaBancosXUsuarios ' cajaSA.GetCuentasFinancierasByEmpresa(Gempresas.IdEmpresaRuc, "EF")
        'cboEntidades.Tag = 1
        'cboEntidades.ValueMember = "idEstado"
        'cboEntidades.DisplayMember = "DetalleItem"
        'cboEntidades.SelectedValue = -1

    End Sub

    Public Sub GetCombos()
        Dim cajaUsuarioSA As New cajaUsuarioSA

        ListaEstadosFinancieros = New List(Of estadosFinancieros)

        For Each i As cajaUsuario In cajaUsuarioSA.ResumenTransaccionesXusuarioCajaPago(New cajaUsuario With {.idcajaUsuario = GFichaUsuarios.IdCajaUsuario, .idPersona = usuario.IDUsuario})
            ListaEstadosFinancieros.Add(New estadosFinancieros With {.idestado = i.idEntidad, .descripcion = i.NombreEntidad, .tipo = i.Tipo, .codigo = i.moneda})
        Next

    End Sub

    Public Sub Loadcontroles()

        'cboEntidades.DataSource = ListaEstadosFinancieros ' cajaSA.GetCuentasFinancierasByEmpresa(Gempresas.IdEmpresaRuc, "EF")
        'cboEntidades.ValueMember = "idestado"
        'cboEntidades.DisplayMember = "descripcion"

    End Sub

    Sub limpiar()
        lblSaldoInicial.Text = 0
        lblVentas.Text = 0
        lblCuentasPorCobrar.Text = 0
        lblOtrosIngresos.Text = 0
        lblAnticiposRecibidas.Text = 0
        lblGarantiasRecibidas.Text = 0
        lblReclamaciones.Text = 0
        lblTransferenciasRecibidas.Text = 0
        lblCuentasPorPagar.Text = 0
        lblOtrosEgresos.Text = 0
        lblTransferenciaEfectuadas.Text = 0
        lblReclamacionesClientes.Text = 0
        lblAnticiposOtorgados.Text = 0
        lblSaldoFinal.Text = 0
        LabelBase.Text = 0
        lblNotas.Text = 0
    End Sub

    Sub VERMovimientos()
        Dim DocCajaSA As New DocumentoCajaSA
        Dim anticipoSA As New documentoAnticipoConciliacionSA
        Dim fechaRegistro As DateTime = txtFechaLaboral.Value
        Dim ingresos As Decimal = 0.0
        Dim egresos As Decimal = 0.0

        limpiar()
        Dim consulta = ListaCajaBancosXUsuarios.Sum(Function(o) o.montoSoles).GetValueOrDefault
        'If (Not IsNothing(CONSULTA)) Then
        lblSaldoInicial.Text = consulta
        'fechaRegistro = CONSULTA.fechaProceso

        listaCuentasFinancieras = New List(Of Integer)
        For Each i In ListaCajaBancosXUsuarios
            listaCuentasFinancieras.Add(i.idEstado)
        Next

        If listaCuentasFinancieras.Count > 0 Then
            ListacajausuarioXEntidadFinanciera =
                  DocCajaSA.ListaResumenXEntidadV2(
                  listaID,
                  txtFechaLaboral.Value,
                  Date.Now,
                  Gempresas.IdEmpresaRuc,
                  GEstableciento.IdEstablecimiento,
                  listaCuentasFinancieras)
        End If

        If (Not IsNothing(ListacajausuarioXEntidadFinanciera)) Then
            'ingresos
            lblVentas.Text = CDec(ListacajausuarioXEntidadFinanciera.ventaContado.GetValueOrDefault) + CDec(ListacajausuarioXEntidadFinanciera.ventaPost.GetValueOrDefault)
            lblOtrosIngresos.Text = ListacajausuarioXEntidadFinanciera.otrasEntradas.GetValueOrDefault

            LabelIngresosEspeciales.Text = ListacajausuarioXEntidadFinanciera.EntradaDineroEspecial.GetValueOrDefault

            'LabelEntregasRendir.Text = ListacajausuarioXEntidadFinanciera.EntregasArendir.GetValueOrDefault

            lblCuentasPorCobrar.Text = ListacajausuarioXEntidadFinanciera.cuentasXcobrar.GetValueOrDefault
            lblAnticiposRecibidas.Text = ListacajausuarioXEntidadFinanciera.anticiposRecibidos.GetValueOrDefault
            lblGarantiasRecibidas.Text = ListacajausuarioXEntidadFinanciera.Aporte.GetValueOrDefault
            lblTransferenciasRecibidas.Text = ListacajausuarioXEntidadFinanciera.transferenciaRecibido.GetValueOrDefault
            lblNotas.Text = ListacajausuarioXEntidadFinanciera.notaVenta.GetValueOrDefault
            LabelventasReimpresas.Text = ListacajausuarioXEntidadFinanciera.VentaHeredadaMN.GetValueOrDefault
            txtImporteVentaElectronica.Text = ListacajausuarioXEntidadFinanciera.VentaElectronicas.GetValueOrDefault
            ingresos = CDec(lblSaldoInicial.Text) + CDec(lblVentas.Text) + CDec(lblOtrosIngresos.Text) +
                        CDec(lblCuentasPorCobrar.Text) + CDec(lblAnticiposRecibidas.Text) + CDec(lblGarantiasRecibidas.Text) + CDec(lblTransferenciasRecibidas.Text) + CDec(lblNotas.Text) + CDec(txtImporteVentaElectronica.Text) + CDec(LabelIngresosEspeciales.Text)
            'Egresos
            lblOtrosEgresos.Text = ListacajausuarioXEntidadFinanciera.otrasSalidas.GetValueOrDefault
            lblAnticiposOtorgados.Text = ListacajausuarioXEntidadFinanciera.anticiposOtorgados.GetValueOrDefault
            lblTransferenciaEfectuadas.Text = ListacajausuarioXEntidadFinanciera.transferenciaOtorgado.GetValueOrDefault
            lblCuentasPorPagar.Text = ListacajausuarioXEntidadFinanciera.cuentasXPagar.GetValueOrDefault
            egresos = CDec(lblOtrosEgresos.Text) + CDec(lblAnticiposOtorgados.Text) + CDec(lblTransferenciaEfectuadas.Text) + CDec(lblCuentasPorPagar.Text) + CDec(LabelEntregasRendir.Text)
            lblSaldoFinal.Text = CDec(ingresos) - CDec(egresos)
            LabelBase.Text = CDec(ingresos) - CDec(egresos)
            GetResumenFormaPago(listaCuentasFinancieras)
        End If

        Dim anticipo = anticipoSA.GetMovimientosByCajaUsuario(New documentoAnticipoConciliacion With
                                                              {
                                                              .fechaRegistro = Date.Now,
                                                              .idCajaUsuario = listaID.FirstOrDefault
                                                              })

        If anticipo IsNot Nothing Then
            LabelReclamacionClienteAnt.Text = CDec(anticipo.Where(Function(o) o.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES).Select(Function(o) o.importe).FirstOrDefault.GetValueOrDefault)
        End If
    End Sub

    Sub VERMovimientos(UsuarioCaja As Integer)
        Dim DocCajaSA As New DocumentoCajaSA
        Dim anticipoSA As New documentoAnticipoConciliacionSA
        Dim fechaRegistro As DateTime
        Dim ingresos As Decimal = 0.0
        Dim egresos As Decimal = 0.0
        Dim newListUsers As New List(Of Integer)
        newListUsers.Add(UsuarioCaja)


        limpiar()
        Dim consulta = ListaCajaBancosXUsuarios.Sum(Function(o) o.montoSoles).GetValueOrDefault
        'If (Not IsNothing(CONSULTA)) Then
        lblSaldoInicial.Text = consulta
        'fechaRegistro = CONSULTA.fechaProceso

        listaCuentasFinancieras = New List(Of Integer)
        'For Each i In ListaCajaBancosXUsuarios
        '    listaCuentasFinancieras.Add(i.idEstado)
        'Next

        'If listaCuentasFinancieras.Count > 0 Then
        ListacajausuarioXEntidadFinanciera =
                  DocCajaSA.ListaResumenXEntidadV2(
                  newListUsers,
                  fechaRegistro,
                  Date.Now,
                  Gempresas.IdEmpresaRuc,
                  GEstableciento.IdEstablecimiento,
                  listaCuentasFinancieras)
        'End If

        If (Not IsNothing(ListacajausuarioXEntidadFinanciera)) Then
            'ingresos
            lblVentas.Text = CDec(ListacajausuarioXEntidadFinanciera.ventaContado.GetValueOrDefault) + CDec(ListacajausuarioXEntidadFinanciera.ventaPost.GetValueOrDefault)
            lblOtrosIngresos.Text = ListacajausuarioXEntidadFinanciera.otrasEntradas.GetValueOrDefault
            lblCuentasPorCobrar.Text = ListacajausuarioXEntidadFinanciera.cuentasXcobrar.GetValueOrDefault
            lblAnticiposRecibidas.Text = ListacajausuarioXEntidadFinanciera.anticiposRecibidos.GetValueOrDefault
            lblGarantiasRecibidas.Text = ListacajausuarioXEntidadFinanciera.Aporte.GetValueOrDefault
            lblTransferenciasRecibidas.Text = ListacajausuarioXEntidadFinanciera.transferenciaRecibido.GetValueOrDefault
            lblNotas.Text = ListacajausuarioXEntidadFinanciera.notaVenta.GetValueOrDefault
            LabelventasReimpresas.Text = ListacajausuarioXEntidadFinanciera.VentaHeredadaMN.GetValueOrDefault
            txtImporteVentaElectronica.Text = ListacajausuarioXEntidadFinanciera.VentaElectronicas.GetValueOrDefault
            ingresos = CDec(lblSaldoInicial.Text) + CDec(lblVentas.Text) + CDec(lblOtrosIngresos.Text) +
                        CDec(lblCuentasPorCobrar.Text) + CDec(lblAnticiposRecibidas.Text) + CDec(lblGarantiasRecibidas.Text) + CDec(lblTransferenciasRecibidas.Text) + CDec(lblNotas.Text) + CDec(txtImporteVentaElectronica.Text)
            'Egresos
            lblOtrosEgresos.Text = ListacajausuarioXEntidadFinanciera.otrasSalidas.GetValueOrDefault
            lblAnticiposOtorgados.Text = ListacajausuarioXEntidadFinanciera.anticiposOtorgados.GetValueOrDefault
            lblTransferenciaEfectuadas.Text = ListacajausuarioXEntidadFinanciera.transferenciaOtorgado.GetValueOrDefault
            lblCuentasPorPagar.Text = ListacajausuarioXEntidadFinanciera.cuentasXPagar.GetValueOrDefault
            egresos = CDec(lblOtrosEgresos.Text) + CDec(lblAnticiposOtorgados.Text) + CDec(lblTransferenciaEfectuadas.Text) + CDec(lblCuentasPorPagar.Text)
            lblSaldoFinal.Text = CDec(ingresos) - CDec(egresos)
            LabelBase.Text = CDec(ingresos) - CDec(egresos)
            GetResumenFormaPago(listaCuentasFinancieras)
        End If

        Dim anticipo = anticipoSA.GetMovimientosByCajaUsuario(New documentoAnticipoConciliacion With
                                                              {
                                                              .fechaRegistro = Date.Now,
                                                              .idCajaUsuario = UsuarioCaja
                                                              })

        If anticipo IsNot Nothing Then
            LabelReclamacionClienteAnt.Text = CDec(anticipo.Where(Function(o) o.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES).Select(Function(o) o.importe).FirstOrDefault.GetValueOrDefault)
        End If
    End Sub
#End Region

#Region "Events"

#End Region

    Private Sub frmHistorialCajaCierre_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dispose()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try

            Dim userCaja = ListaCajasActivas.Where(Function(o) o.idPersona = usuario.IDUsuario).FirstOrDefault
            If userCaja IsNot Nothing Then
                If ListaCajaBancosXUsuarios IsNot Nothing Then
                    If ListaCajaBancosXUsuarios.Count > 0 Then
                        If lsvListadoItems.Items.Count > 0 Then
                            'VERMovimientos(userCaja.idcajaUsuario)
                            VERMovimientos()
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        'End If

        'Else
        '    MessageBoxAdv.Show("Debe seleccionar una cuenta financiera", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If

    End Sub

    Private Sub rbTodo_CheckedChanged(sender As Object, e As EventArgs) Handles rbTodo.CheckedChanged
        If (rbTodo.Checked = True) Then
            pnPeriodo.Enabled = False
            pnDia.Enabled = False
            pnHora.Enabled = False
            pnDia.Visible = False
            pnPeriodo.Visible = False
            pnHora.Visible = False
            btnAceptar.Location = New Point(180, 258)
            'limpiar()
        End If
    End Sub

    Private Sub Periodo_CheckedChanged(sender As Object, e As EventArgs) Handles Periodo.CheckedChanged
        If (Periodo.Checked = True) Then
            pnPeriodo.Enabled = True
            pnDia.Enabled = False
            pnHora.Enabled = False
            pnDia.Visible = False
            pnHora.Visible = False
            pnPeriodo.Visible = True
            btnAceptar.Location = New Point(179, 325)
            'limpiar()
        End If
    End Sub

    Private Sub rbDia_CheckedChanged(sender As Object, e As EventArgs) Handles rbDia.CheckedChanged
        If (rbDia.Checked = True) Then
            pnDia.Enabled = False
            pnPeriodo.Enabled = False
            pnHora.Enabled = True
            pnHora.Visible = True
            pnPeriodo.Visible = False
            pnDia.Visible = False
            btnAceptar.Location = New Point(179, 420)
            'limpiar()
            dtFechaActual.Value = DateTime.Now
            dtHoraInicio.Value = dtFechaActual.Value
            dtHoraFin.Value = dtFechaActual.Value
        End If
    End Sub

    Private Sub rbPorDia_CheckedChanged(sender As Object, e As EventArgs) Handles rbPorDia.CheckedChanged
        If (rbPorDia.Checked = True) Then
            pnPeriodo.Enabled = False
            pnDia.Enabled = True
            pnHora.Enabled = False
            pnPeriodo.Visible = False
            pnHora.Visible = False
            pnDia.Visible = True
            pnDia.Location = New Point(6, 254)
            btnAceptar.Location = New Point(176, 378)
            'limpiar()

        End If
    End Sub

    Private Sub ckbHora_CheckedChanged(sender As Object, e As EventArgs) Handles ckbHora.CheckedChanged
        If (ckbHora.Checked = True) Then
            Panel10.Enabled = True
            Panel10.Visible = True
            rbDia.Tag = 1
            dtHoraInicio.Value = dtFechaActual.Value
            dtHoraFin.Value = dtFechaActual.Value
        Else
            Panel10.Enabled = False
            Panel10.Visible = False
            rbDia.Tag = 0
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        Dim f As New frmContenedorResumenGeneral  ' frmMaestroComercial ' frmMasterGeneralVentas
        f.listaUsuario = listaID
        f.ToolStripTabItem1.Text = "VENTAS"
        f.tipoConsulta = "VENTAS"
        f.FechaLaboral = txtFechaLaboral.Value
        'f.idEntidad = cboEntidades.SelectedValue
        f.listIDCajas = listaCuentasFinancieras
        f.StartPosition = FormStartPosition.CenterScreen
        f.Show()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        Dim f As New frmContenedorResumenGeneral  ' frmMaestroComercial ' frmMasterGeneralVentas
        f.listaUsuario = listaID
        f.ToolStripTabItem1.Text = "CUENTAS POR COBRAR"
        f.tipoConsulta = "CUENTAS"
        f.FechaLaboral = txtFechaLaboral.Value
        ' f.idEntidad = cboEntidades.SelectedValue
        f.listIDCajas = listaCuentasFinancieras
        f.StartPosition = FormStartPosition.CenterScreen
        f.Show()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        Dim f As New frmContenedorResumenGeneral  ' frmMaestroComercial ' frmMasterGeneralVentas
        f.listaUsuario = listaID
        f.ToolStripTabItem1.Text = "OTRAS ENTRADAS DE DINERO"
        f.tipoConsulta = "OEC"
        f.FechaLaboral = txtFechaLaboral.Value
        f.ToolStripDropDownButton3.Visible = False
        ' f.idEntidad = cboEntidades.SelectedValue
        f.StartPosition = FormStartPosition.CenterScreen
        f.Show()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        Dim f As New frmContenedorResumenGeneral  ' frmMaestroComercial ' frmMasterGeneralVentas
        f.listaUsuario = listaID
        f.ToolStripTabItem1.Text = "OTRAS SALIDAS DE DINERO"
        f.tipoConsulta = "OSC"
        f.ToolStripDropDownButton3.Visible = False
        ' f.idEntidad = cboEntidades.SelectedValue
        f.listIDCajas = listaCuentasFinancieras
        f.StartPosition = FormStartPosition.CenterScreen
        f.Show()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub LinkLabel6_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel6.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        Dim f As New frmContenedorResumenGeneral  ' frmMaestroComercial ' frmMasterGeneralVentas
        f.listaUsuario = listaID
        f.ToolStripTabItem1.Text = "OTROS"
        f.tipoConsulta = "OTROS"
        f.FechaLaboral = txtFechaLaboral.Value
        ' f.idEntidad = cboEntidades.SelectedValue
        f.listIDCajas = listaCuentasFinancieras
        f.StartPosition = FormStartPosition.CenterScreen
        f.Show()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboEntidades_SelectedValueChanged(sender As Object, e As EventArgs)
        limpiar()
    End Sub


    Private Sub LinkLabel8_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel8.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        Dim f As New frmContenedorResumenGeneral  ' frmMaestroComercial ' frmMasterGeneralVentas
        f.listaUsuario = listaID
        f.ToolStripTabItem1.Text = "ELECTRONICAS"
        f.tipoConsulta = "ELECTRONICAS"
        f.FechaLaboral = txtFechaLaboral.Value
        ' f.idEntidad = cboEntidades.SelectedValue
        f.listIDCajas = listaCuentasFinancieras
        f.StartPosition = FormStartPosition.CenterScreen
        f.Show()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub frmInformacionFinanzas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim boundWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim boundHeight As Integer = Screen.PrimaryScreen.Bounds.Height
        Dim x As Integer = boundWidth - Me.Width
        Dim y As Integer = boundHeight - Me.Height
        Me.Location = New Point(x \ 2, y \ 2)
    End Sub

    Private Sub LinkLabel9_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel9.LinkClicked
        Cursor = Cursors.WaitCursor
        Try
            lsvListadoItems.Items.Clear()
            limpiar()
            Dim f As New frmBusquedaPersonaXCaja()
            f.CaptionLabels(0).Text = "Personas"
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            listaID = New List(Of Integer)
            listaUsuario = f.lista
            If listaUsuario Is Nothing Then Exit Sub

            If (listaUsuario.Count > 0) Then
                lsvListadoItems.Items.Clear()
                lsvListadoItems.Columns.Clear()
                lsvListadoItems.Columns.Add("ID", 0, HorizontalAlignment.Left)
                lsvListadoItems.Columns.Add("DNI", 70, HorizontalAlignment.Left)
                lsvListadoItems.Columns.Add("Nombre completo", 150, HorizontalAlignment.Left)
                lsvListadoItems.Columns(0).DisplayIndex = lsvListadoItems.Columns.Count - 1

                For Each i In listaUsuario
                    Dim n As New ListViewItem(i.idcajaUsuario)
                    n.SubItems.Add(i.numeroDocumento)
                    n.SubItems.Add(i.NombrePersona)
                    'n.SubItems.Add("Seleccion")
                    lsvListadoItems.Items.Add(n)
                    listaID.Add(i.idcajaUsuario)
                    'conteo += 1
                Next

                consultaMovimientoCaja()
                VERMovimientos()

            Else
                Cursor = Cursors.Default
                MessageBoxAdv.Show("No existe persona", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        'cboEntidades.DataSource = Nothing

        Cursor = Cursors.Default
    End Sub

    Private Sub RoundButton22_Click(sender As Object, e As EventArgs) Handles RoundButton22.Click
        PanelCierreCaja.Visible = False
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        If listaUsuario IsNot Nothing Then
            If listaUsuario.Count > 0 Then
                PanelCierreCaja.Location = New Point(11, 15)
                PanelCierreCaja.Size = New Size(869, 617)
                PanelCierreCaja.Visible = True
                TextboxJiu1.Tag = listaUsuario.FirstOrDefault.idcajaUsuario
                TextboxJiu1.Text = listaUsuario.FirstOrDefault.NombrePersona
                GetSumarioVentas()
            End If
        End If
    End Sub

    Private Sub RoundButton21_Click(sender As Object, e As EventArgs) Handles RoundButton21.Click
        'If CDec(Label69.Text) > 0 Then
        If MessageBox.Show("Esta seguro de cerrar la caja!", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                Dim usuarioCaja = ListaCajasActivas.Where(Function(o) o.idPersona = usuario.IDUsuario).FirstOrDefault
                If usuarioCaja IsNot Nothing Then
                    GuardarCierre()
                Else
                    MessageBox.Show("El usuario no registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        'End If
    End Sub


    Private Sub GridBeneficios_TableControlCellClick(sender As Object, e As Grid.Grouping.GridTableControlCellClickEventArgs) Handles GridBeneficios.TableControlCellClick

    End Sub

    Private Sub GridBeneficios_TableControlCurrentCellChanged(sender As Object, e As GridTableControlEventArgs) Handles GridBeneficios.TableControlCurrentCellChanged
        Dim cc As GridCurrentCell = GridBeneficios.TableControl.CurrentCell
        cc.ConfirmChanges()

        If cc.ColIndex > -1 Then
            Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)

            If style.TableCellIdentity.Column.Name = "cantidad" Then
                Dim ValorCantidad As Decimal = Decimal.Parse(cc.Renderer.ControlText)

                'If CDec(Label69.Text) <= CDec(LabelBase.Text) Then
                If ValorCantidad > 0 Then
                    Dim value As Decimal = Convert.ToDecimal(ValorCantidad)
                    cc.Renderer.ControlValue = value
                    Dim valorEquivale = Me.GridBeneficios.Table.CurrentRecord.GetValue("equivalencia")
                    Dim total = valorEquivale * ValorCantidad
                    Me.GridBeneficios.Table.CurrentRecord.SetValue("importe", total)
                Else
                    Me.GridBeneficios.Table.CurrentRecord.SetValue("importe", 0)
                End If
                'Else
                '    MessageBox.Show("La suma de balance no es igual al resumen del día", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                '    Me.GridBeneficios.Table.CurrentRecord.SetValue("importe", 0)
                'End If
                Sumaarqueo()
            End If
        End If
    End Sub

    Private Sub RoundButton23_Click(sender As Object, e As EventArgs) Handles RoundButton23.Click
        GetCierreCajaDinero()
        GetSumarioVentas()
        Label69.Text = "0"
    End Sub

    Private Sub LinkLabel7_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel7.LinkClicked

    End Sub

    Private Sub GridResumenFormaPago_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridResumenFormaPago.TableControlCellClick
        'Cursor = Cursors.WaitCursor
        'Dim r As Record = GridResumenFormaPago.Table.CurrentRecord
        'If r IsNot Nothing Then
        '    If GridResumenFormaPago.Table.Records.Count > 0 Then
        '        GetDetalleMovByFormaPago(r.GetValue("IDForma"))
        '    End If
        'End If
        'Cursor = Cursors.Default
    End Sub

    Private Sub GridResumenFormaPago_SelectedRecordsChanged(sender As Object, e As SelectedRecordsChangedEventArgs) Handles GridResumenFormaPago.SelectedRecordsChanged
        Cursor = Cursors.WaitCursor
        If e.SelectedRecord IsNot Nothing Then
            Dim r As Record = e.SelectedRecord.Record
            If r IsNot Nothing Then
                If GridResumenFormaPago.Table.Records.Count > 0 Then
                    GetDetalleMovByFormaPago(r.GetValue("IDForma"))
                End If
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub LinkLabel10_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel10.LinkClicked

    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click

    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click

    End Sub

    Private Sub Label19_Click(sender As Object, e As EventArgs) Handles Label19.Click

    End Sub
End Class