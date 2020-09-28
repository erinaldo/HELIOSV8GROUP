Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General.Constantes
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping
Public Class frmIngresoXAnticipoMaster

#Region "Attributes"
    Dim listaMeses As New List(Of MesesAnio)
    Public Property empresaPeriodoSA As New empresaCierreMensualSA
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GridCFG(dgvOtrosMov)
        Meses()
    End Sub
#End Region

#Region "Methods"
    Private Sub Meses()
        Dim empresaAnioSA As New empresaPeriodoSA
        listaMeses = New List(Of MesesAnio)
        Dim obj As New MesesAnio
        For x = 1 To 12
            obj = New MesesAnio
            obj.Codigo = String.Format("{0:00}", CInt(x))
            obj.Mes = New DateTime(AnioGeneral, x, 1).ToString("MMMM")
            listaMeses.Add(obj)
        Next x

        cboAnio.DisplayMember = "periodo"
        cboAnio.ValueMember = "periodo"
        cboAnio.DataSource = empresaAnioSA.GetListar_empresaPeriodo(New empresaPeriodo With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento})
        cboAnio.Text = AnioGeneral

        cboMesCompra.DisplayMember = "Mes"
        cboMesCompra.ValueMember = "Codigo"
        cboMesCompra.DataSource = listaMeses
        cboMesCompra.SelectedValue = MesGeneral
    End Sub

    Private Sub GetMovimientosPeriodo(intIdEstablecimiento As Integer, strPeriodo As String, strMovimiento As String)
        Dim DocumentoCompraSA As New DocumentoCompraSA
        Dim listaDocCaja As List(Of documentoCaja)
        Dim listaEstado As New List(Of String)
        Dim dt As New DataTable("Movimientos ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("movimiento", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("tipoDocPago", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaCobro", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroOperacion", GetType(String)))
        dt.Columns.Add(New DataColumn("moneda", GetType(String)))
        dt.Columns.Add(New DataColumn("montoSoles"))
        dt.Columns.Add(New DataColumn("tipoCambio", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoUsd"))
        dt.Columns.Add(New DataColumn("NomCajaOrigen", GetType(String)))
        dt.Columns.Add(New DataColumn("NomCajaDestino", GetType(String)))
        dt.Columns.Add(New DataColumn("idPersonal", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoPersona", GetType(String)))
        dt.Columns.Add(New DataColumn("movimientoMN", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("movimientoME", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("saldoMN", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("saldoME", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        Dim str As String

        'listaEstado.Add(TIPO_ESTADO_cAJA.NO_USADO)
        'listaEstado.Add(TIPO_ESTADO_cAJA.USADO_PARCIAL)
        'listaEstado.Add(TIPO_ESTADO_cAJA.USADO_TOTAL)
        'listaEstado.Add(TIPO_ESTADO_cAJA.ANULADO)
        'listaEstado.Add(TIPO_ESTADO_cAJA.DEVOLUCION)

        listaDocCaja = documentoCajaSA.ObtenerMovimientosPorPeriodoFinanzas(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, strPeriodo, strMovimiento)

        For Each i As documentoCaja In listaDocCaja

            Select Case i.movimientoCaja

                Case "AR"
                    Dim dr As DataRow = dt.NewRow()
                    str = Nothing
                    str = CDate(i.fechaProceso).ToString("dd-MMM hh:mm tt ")
                    dr(0) = i.idDocumento
                    dr(1) = i.tipoOperacion
                    dr(2) = "COMPROBANTE DE CAJA"
                    dr(3) = str
                    dr(4) = i.numeroDoc
                    Select Case i.moneda
                        Case 1
                            dr(5) = "NACIONAL"
                        Case 2
                            dr(5) = "EXTRANJERA"
                    End Select
                    dr(6) = CDec(i.montoSoles).ToString("N2")
                    dr(7) = i.tipoCambio
                    dr(8) = CDec(i.montoUsd).ToString("N2")
                    dr(9) = "-"
                    dr(10) = i.NomCajaOrigen
                    dr(11) = i.idPersonal.GetValueOrDefault
                    dr(12) = i.tipoPersona
                    If (i.MontoEgresosMN > 0) Then
                        dr(13) = i.MontoEgresosMN
                        dr(14) = i.MontoEgresosME
                    Else
                        dr(13) = 0.0
                        dr(14) = 0.0
                    End If

                    dr(15) = CDec(i.montoSoles - i.MontoEgresosMN)
                    dr(16) = CDec(i.montoUsd - i.MontoEgresosME)

                    Select Case i.estado
                        Case TIPO_ESTADO_CAJA.NO_USADO
                            dr(17) = "PENDIENTE DE USO"
                        Case TIPO_ESTADO_CAJA.USADO_PARCIAL
                            dr(17) = "IMPUTADO PARCIALMENTE"
                        Case TIPO_ESTADO_CAJA.USADO_TOTAL
                            dr(17) = "IMPUTADO TOTAL"
                        Case TIPO_ESTADO_CAJA.ANULADO
                            dr(17) = "REVERTIDO-ANULADO"
                        Case TIPO_ESTADO_CAJA.DEVOLUCION
                            dr(17) = "DEVOLUCION"
                    End Select

                    dt.Rows.Add(dr)

            End Select

        Next

        dgvOtrosMov.DataSource = dt

    End Sub

    Sub GridCFG(GGC As GridGroupingControl)
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = False
        GGC.ShowColumnHeaders = True

        Dim colorx As New GridMetroColors()

        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        GGC.SetMetroStyle(colorx)
        GGC.BorderStyle = System.Windows.Forms.BorderStyle.None
        GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        GGC.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        GGC.TableOptions.ListBoxSelectionMode = SelectionMode.One
        GGC.TableOptions.SelectionBackColor = Color.Gray
        GGC.AllowProportionalColumnSizing = False
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center

        GGC.Table.DefaultColumnHeaderRowHeight = 27
        GGC.Table.DefaultRecordRowHeight = 20
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub
#End Region

#Region "Events"
    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click
        Dim r As Record = dgvOtrosMov.Table.CurrentRecord
        If Not IsNothing(r) Then
            Dim f As New frmCambiarPeriodo2(New documentoCaja With {.idDocumento = Val(r.GetValue("idDocumento"))})
            f.operacion = StatusTipoOperacion.OTRAS_SALIDAS_DE_DINERO
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()

            Dim periodoG As String = cboMesCompra.SelectedValue & "/" & CInt(cboAnio.Text)
            GetMovimientosPeriodo(GEstableciento.IdEstablecimiento, periodoG, "OSC")

        End If
    End Sub

    Private Sub frmOtrasSalidasCaja_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    'Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click
    '    Cursor = Cursors.WaitCursor
    '    Dim periodoG As String = cboMesCompra.SelectedValue & "/" & CInt(cboAnio.Text)
    '    GetMovimientosPeriodo(GEstableciento.IdEstablecimiento, periodoG, "OSC")
    '    Cursor = Cursors.Default
    'End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        Cursor = Cursors.WaitCursor
        If Not IsNothing(Me.dgvOtrosMov.Table.CurrentRecord) Then
            Dim f As New frmAnticiposModal(StatusTipoOperacion.ANTICIPOS_RECIBIDOS) ' frmCreaUsuarioEmpresa
            f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
            f.UbicarDocumento(Me.dgvOtrosMov.Table.CurrentRecord.GetValue("idDocumento"))
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()

        Else
            MessageBox.Show("Debe seleccionar una item!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Cursor = Cursors.WaitCursor

        Dim fechaAnt = New Date(AnioGeneral, CInt(cboMesCompra.SelectedValue), 1)
        fechaAnt = fechaAnt.AddMonths(-1)
        Dim periodoAnteriorEstaCerrado = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
        If periodoAnteriorEstaCerrado = False Then
            MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
            Cursor = Cursors.Default
            Exit Sub
        End If

        Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.anio = AnioGeneral, .mes = CInt(cboMesCompra.SelectedValue)})
        If Not IsNothing(valida) Then
            If valida = True Then
                MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If

        Dim cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
        If Not IsNothing(cajaUsuario) Then
            GetGlobalMappingCajaUsuario(cajaUsuario, usuario.IDUsuario, usuario.CustomUsuario.Full_Name)

            Dim f As New frmAnticiposModal(StatusTipoOperacion.ANTICIPOS_RECIBIDOS) ' frmCreaUsuarioEmpresa
            f.lblMovimiento.Tag = "AR"
            f.lblMovimiento.Text = "ANTICIPOS RECIBIDOS"
            f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
            f.txtTipoCambio.Value = TmpTipoCambio
            f.txtAnioCompra.Text = CInt(cboAnio.Text)
            f.txtPeriodo.Value = New Date(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), Date.Now.Day)
            f.txtHora.Value = New DateTime(cboAnio.Text, CInt(cboMesCompra.SelectedValue), Date.Now.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
            f.cboMesCompra.SelectedValue = cboMesCompra.SelectedValue
            f.txtDia.Value = New Date(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), Date.Now.Day)
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            Me.Cursor = Cursors.Arrow

        Else
            MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Cursor = Cursors.WaitCursor
        Dim periodoG As String = cboMesCompra.SelectedValue & "/" & CInt(cboAnio.Text)
        GetMovimientosPeriodo(GEstableciento.IdEstablecimiento, periodoG, "AR")
        Cursor = Cursors.Default
    End Sub

#End Region

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Cursor = Cursors.WaitCursor
        If Not IsNothing(Me.dgvOtrosMov.Table.CurrentRecord) Then

            Dim fechaAnt = New Date(AnioGeneral, CInt(cboMesCompra.SelectedValue), 1)
            fechaAnt = fechaAnt.AddMonths(-1)
            Dim periodoAnteriorEstaCerrado = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            If periodoAnteriorEstaCerrado = False Then
                MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                Cursor = Cursors.Default
                Exit Sub
            End If

            Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.anio = AnioGeneral, .mes = CInt(cboMesCompra.SelectedValue)})
            If Not IsNothing(valida) Then
                If valida = True Then
                    MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If

            If (TIPO_ESTADO_NOMBRE_CAJA.ANULADO <> Me.dgvOtrosMov.Table.CurrentRecord.GetValue("estado")) Then

                If (dgvOtrosMov.Table.CurrentRecord.GetValue("saldoMN") > 0) Then
                    Dim cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
                    If Not IsNothing(cajaUsuario) Then
                        GetGlobalMappingCajaUsuario(cajaUsuario, usuario.IDUsuario, usuario.CustomUsuario.Full_Name)

                        Dim f As New frmReversionModal(StatusTipoOperacion.REVERSIONES) ' frmCreaUsuarioEmpresa

                        f.txtAnioCompra.Text = CInt(cboAnio.Text)
                        f.txtPeriodo.Value = New Date(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), 1)
                        f.lblMovimiento.Tag = "AR"
                        f.lblMovimiento.Text = "ANTICIPOS RECIBIDOS"
                        f.CaptionLabels(0).Text = "ANTICIPOS RECIBIDOS"
                        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        f.cboMesCompra.SelectedValue = cboMesCompra.SelectedValue
                        f.cboMesCompra.Enabled = True
                        f.txtHora.Value = New DateTime(cboAnio.Text, CInt(cboMesCompra.SelectedValue), DiaLaboral.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                        f.tipoEntidad = "CL"
                        f.DigitalGauge2.Value = dgvOtrosMov.Table.CurrentRecord.GetValue("saldoMN")
                        f.idDocumentoPadre = dgvOtrosMov.Table.CurrentRecord.GetValue("idDocumento")
                        f.UbicarDocumentoEditar(Me.dgvOtrosMov.Table.CurrentRecord.GetValue("idDocumento"))
                        f.txtDia.Value = New Date(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), DiaLaboral.Day)
                        f.StartPosition = FormStartPosition.CenterParent
                        f.ShowDialog()
                        Dim periodoG As String = cboMesCompra.SelectedValue & "/" & CInt(cboAnio.Text)
                        GetMovimientosPeriodo(GEstableciento.IdEstablecimiento, periodoG, "AR")
                    Else
                        MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End If
            Else
                MessageBoxAdv.Show("El anticipo esta anulado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Debe seleccionar una item!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click
        Cursor = Cursors.WaitCursor
        If Not IsNothing(Me.dgvOtrosMov.Table.CurrentRecord) Then
            With frmListaReversioneFinanzas
                '.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                .GetCuentasFinancieras(Me.dgvOtrosMov.Table.CurrentRecord.GetValue("idDocumento"))
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
        Else
            MessageBox.Show("Debe seleccionar una item!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv7_Click(sender As Object, e As EventArgs) Handles ButtonAdv7.Click
        Cursor = Cursors.WaitCursor
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Dim fechaAnt = New Date(AnioGeneral, CInt(cboMesCompra.SelectedValue), 1)
        fechaAnt = fechaAnt.AddMonths(-1)
        Dim periodoAnteriorEstaCerrado = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
        If periodoAnteriorEstaCerrado = False Then
            MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
            Cursor = Cursors.Default
            Exit Sub
        End If

        Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.anio = AnioGeneral, .mes = CInt(cboMesCompra.SelectedValue)})
        If Not IsNothing(valida) Then
            If valida = True Then
                MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If

        If Not IsNothing(Me.dgvOtrosMov.Table.CurrentRecord) Then
            If (dgvOtrosMov.Table.CurrentRecord.GetValue("estado") = TIPO_ESTADO_NOMBRE_CAJA.NO_USADO) Then
                'If (dgvOtrosMov.Table.CurrentRecord.GetValue("saldoMN") > 0) Then
                Dim cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
                If Not IsNothing(cajaUsuario) Then
                    GetGlobalMappingCajaUsuario(cajaUsuario, usuario.IDUsuario, usuario.CustomUsuario.Full_Name)

                    Dim f As New frmAnticiposModal(StatusTipoOperacion.ANTICIPOS_RECIBIDOS)
                    f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                    f.lblMovimiento.Tag = "AR"
                    f.lblMovimiento.Text = "ANTICIPOS RECIBIDOS"
                    f.CaptionLabels(0).Text = "ANTICIPOS RECIBIDOS"
                    f.UbicarDocumentoEditar(Me.dgvOtrosMov.Table.CurrentRecord.GetValue("idDocumento"))
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()
                    Dim periodoG As String = cboMesCompra.SelectedValue & "/" & CInt(cboAnio.Text)
                    GetMovimientosPeriodo(GEstableciento.IdEstablecimiento, periodoG, "AR")

                Else
                    MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
                'Else
                '    MessageBoxAdv.Show("No puede editar el anticipo!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                'End If
            Else
                MessageBoxAdv.Show("No puede editar el anticipo!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Debe seleccionar una item!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
            Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv8_Click(sender As Object, e As EventArgs) Handles ButtonAdv8.Click
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Cursor = Cursors.WaitCursor

        Dim fechaAnt = New Date(AnioGeneral, CInt(cboMesCompra.SelectedValue), 1)
        fechaAnt = fechaAnt.AddMonths(-1)
        Dim periodoAnteriorEstaCerrado = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
        If periodoAnteriorEstaCerrado = False Then
            MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
            Cursor = Cursors.Default
            Exit Sub
        End If

        Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.anio = AnioGeneral, .mes = CInt(cboMesCompra.SelectedValue)})
        If Not IsNothing(valida) Then
            If valida = True Then
                MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If

        If Not IsNothing(Me.dgvOtrosMov.Table.CurrentRecord) Then

            If (TIPO_ESTADO_NOMBRE_CAJA.ANULADO <> Me.dgvOtrosMov.Table.CurrentRecord.GetValue("estado")) Then

                Dim cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
                If Not IsNothing(cajaUsuario) Then
                    GetGlobalMappingCajaUsuario(cajaUsuario, usuario.IDUsuario, usuario.CustomUsuario.Full_Name)

                    Dim f As New frmConfirmarDevolucion(StatusTipoOperacion.ANTICIPOS_OTORGADOS)

                    f.txtAnioCompra.Text = CInt(cboAnio.Text)
                    f.txtPeriodo.Value = New Date(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), 1)
                    f.lblMovimiento.Tag = "AR"
                    f.lblMovimiento.Text = "ANTICIPOS RECIBIDOS"
                    f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    f.cboMesCompra.SelectedValue = cboMesCompra.SelectedValue
                    f.cboMesCompra.Enabled = True
                    f.txtHora.Value = New DateTime(cboAnio.Text, CInt(cboMesCompra.SelectedValue), DiaLaboral.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                    f.DigitalGauge2.Value = dgvOtrosMov.Table.CurrentRecord.GetValue("saldoMN")
                    f.idDocumentoPadre = dgvOtrosMov.Table.CurrentRecord.GetValue("idDocumento")
                    f.UbicarDocumentoEditar(Me.dgvOtrosMov.Table.CurrentRecord.GetValue("idDocumento"))
                    f.tipoEntidad = Me.dgvOtrosMov.Table.CurrentRecord.GetValue("tipoPersona")
                    f.txtDia.Value = New Date(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), DiaLaboral.Day)
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()

                Else
                    MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBoxAdv.Show("El anticipo esta anulado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Debe seleccionar un item válido!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default

    End Sub
End Class