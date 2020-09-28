Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports System.Data.Entity.DbFunctions
Public Class UCOtrosEgresos

#Region "Fields"
    Dim cajaUsuarioSA As New cajaUsuarioSA
    Property empresaPeriodoSA As New empresaCierreMensualSA
    Dim selectionColl As New Hashtable()
    Dim hoveredIndex As Integer = 0
    Dim filter As New GridExcelFilter()
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(dgvOtrosMov, True, False, 9.0F)
        OrdenamientoGrid(dgvOtrosMov, True)
    End Sub
#End Region

#Region "Methods"
    Private Sub GetAnularOperacion(idOperacion As Integer)
        Dim cajaSA As New DocumentoCajaSA
        Try
            cajaSA.AnularOtrosPagos(New documento With {.idDocumento = idOperacion})
            dgvOtrosMov.Table.CurrentRecord.Delete()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Verificar transacción")
        End Try
    End Sub

    Private Sub GetMovimientosPeriodo(intIdEstablecimiento As Integer, strPeriodo As String, strMovimiento As String)
        Dim DocumentoCompraSA As New DocumentoCompraSA
        Dim listaDocCaja As New List(Of documentoCaja)
        Dim listaEstado As New List(Of String)
        Dim dt As New DataTable("Gastos - período ")
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
        dt.Columns.Add(New DataColumn("usuariosys", GetType(String)))

        Dim str As String

        'listaEstado.Add(TIPO_ESTADO_CAJA.NO_USADO)
        'listaEstado.Add(TIPO_ESTADO_CAJA.USADO_PARCIAL)
        'listaEstado.Add(TIPO_ESTADO_CAJA.USADO_TOTAL)
        'listaEstado.Add(TIPO_ESTADO_cAJA.ANULADO)
        'listaEstado.Add(TIPO_ESTADO_cAJA.DEVOLUCION)
        Dim IDempresa As String = Gempresas.IdEmpresaRuc
        Dim fechaProceso = GetPeriodoConvertirToDate(strPeriodo)



        If usuario.tipoCaja IsNot Nothing Then
            If usuario.tipoCaja = Tipo_Caja.ADMINISTRATIVO Then


                listaDocCaja = documentoCajaSA.GetOperacionesCaja(New documentoCaja With {
                                                          .idEmpresa = IDempresa,
                                                          .idEstablecimiento = intIdEstablecimiento,
                                                          .fechaProceso = fechaProceso,
                                                          .movimientoCaja = strMovimiento,
                                                          .tipousuario = Tipo_Caja.GENERAL}).Where(Function(o) o.estado = "1").ToList

            ElseIf usuario.tipoCaja = Tipo_Caja.PUNTO_DE_VENTA Then

                listaDocCaja = documentoCajaSA.GetOperacionesCaja(New documentoCaja With {
                                                          .idEmpresa = IDempresa,
                                                          .idEstablecimiento = intIdEstablecimiento,
                                                          .fechaProceso = fechaProceso,
                                                          .movimientoCaja = strMovimiento,
                                                          .tipousuario = Tipo_Caja.PUNTO_DE_VENTA}).Where(Function(o) o.estado = "1").ToList
            End If

        End If


        'listaDocCaja = documentoCajaSA.ObtenerMovimientosPorPeriodoFinanzas(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, strPeriodo, strMovimiento).Where(Function(o) o.estado = "1").ToList


        For Each i As documentoCaja In listaDocCaja
            Select Case i.movimientoCaja

                Case "OSC"

                    Dim dr As DataRow = dt.NewRow()
                    str = Nothing
                    str = CDate(i.fechaCobro).ToString("dd-MMM hh:mm tt ")
                    dr(0) = i.idDocumento
                    dr(1) = i.tipoOperacion
                    dr(2) = "COMPROBANTE DE CAJA"
                    'Select Case i.movimientoCaja
                    '    Case "OSC"
                    '        dr(2) = "OTRAS SALIDA DE CAJA"
                    'End Select
                    dr(3) = str
                    dr(4) = i.numeroDoc
                    Select Case i.moneda
                        Case 1
                            dr(5) = "NACIONAL"
                        Case 2
                            dr(5) = "EXTRANJERA"
                    End Select
                    dr(6) = i.montoSoles
                    dr(7) = i.tipoCambio
                    dr(8) = i.montoUsd
                    dr(9) = i.NomCajaOrigen
                    dr(10) = "-"
                    dr(11) = i.idPersonal
                    dr(12) = i.tipoPersona
                    dr(13) = i.MontoEgresosMN
                    dr(14) = i.MontoEgresosME
                    dr(15) = CDec(i.montoSoles - i.MontoEgresosMN)
                    dr(16) = CDec(i.montoUsd - i.MontoEgresosME)
                    Select Case i.estado
                        Case "1"
                            dr(17) = "Activo"
                        Case "0"
                            dr(17) = "Anulado"
                            'Case TIPO_ESTADO_CAJA.NO_USADO
                            '    dr(17) = "PENDIENTE DE USO"
                            'Case TIPO_ESTADO_CAJA.USADO_PARCIAL
                            '    dr(17) = "IMPUTADO PARCIALMENTE"
                            'Case TIPO_ESTADO_CAJA.USADO_TOTAL
                            '    dr(17) = "IMPUTADO TOTAL"
                            'Case TIPO_ESTADO_CAJA.ANULADO
                            '    dr(17) = "REVERTIDO-ANULADO"
                            'Case TIPO_ESTADO_CAJA.DEVOLUCION
                            '    dr(17) = "DEVOLUCION"
                    End Select
                    Dim usuarioSoftpack = Seguridad.General.ListaUsuariosSoftpack.Where(Function(o) o.IDUsuario = i.usuarioModificacion).SingleOrDefault
                    If usuarioSoftpack IsNot Nothing Then
                        dr(18) = usuarioSoftpack.Full_Name
                    Else
                        dr(18) = "NN"
                    End If
                    dt.Rows.Add(dr)
            End Select
        Next
        dgvOtrosMov.DataSource = dt
    End Sub

    Private Sub GetMovimientosDia(intIdEstablecimiento As Integer, strPeriodo As String, strMovimiento As String, fechaLab As Date)
        Dim listaDocCaja As List(Of documentoCaja) = Nothing
        Dim listaEstado As New List(Of String)
        Dim dt As New DataTable("Ingresos - del día " & fechaLab & " ")
        Dim documentoCajaSA As New DocumentoCajaSA
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("movimiento", GetType(String)))
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
        dt.Columns.Add(New DataColumn("usuariosys", GetType(String)))
        Dim str As String

        'listaEstado.Add(TIPO_ESTADO_CAJA.NO_USADO)
        'listaEstado.Add(TIPO_ESTADO_CAJA.USADO_PARCIAL)
        'listaEstado.Add(TIPO_ESTADO_CAJA.USADO_TOTAL)
        'listaEstado.Add(TIPO_ESTADO_cAJA.ANULADO)
        'listaEstado.Add(TIPO_ESTADO_cAJA.DEVOLUCION)

        'listaDocCaja = documentoCajaSA.ObtenerMovimientosPorPeriodoFinanzas(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, strPeriodo, strMovimiento) _
        '    .Where(Function(o) o.estado = "1" _
        '    And o.fechaCobro.Value.Year = fechaLab.Year _
        '    And o.fechaCobro.Value.Month = fechaLab.Month _
        '    And o.fechaCobro.Value.Day = fechaLab.Day).ToList
        Dim IDempresa As String = Gempresas.IdEmpresaRuc
        Dim fechaProceso = GetPeriodoConvertirToDate(strPeriodo)

        If usuario.tipoCaja IsNot Nothing Then
            If usuario.tipoCaja = Tipo_Caja.ADMINISTRATIVO Then


                listaDocCaja = documentoCajaSA.GetOperacionesCaja(New documentoCaja With {
                                                          .idEmpresa = IDempresa,
                                                          .idEstablecimiento = intIdEstablecimiento,
                                                          .fechaProceso = fechaProceso,
                                                          .movimientoCaja = strMovimiento,
                                                          .tipousuario = Tipo_Caja.GENERAL}).Where(Function(o) o.estado = "1" _
                                                          And o.fechaCobro.Value.Year = fechaLab.Year _
                                                          And o.fechaCobro.Value.Month = fechaLab.Month _
                                                          And o.fechaCobro.Value.Day = fechaLab.Day).ToList

            ElseIf usuario.tipoCaja = Tipo_Caja.PUNTO_DE_VENTA Then

                listaDocCaja = documentoCajaSA.GetOperacionesCaja(New documentoCaja With {
                                                          .idEmpresa = IDempresa,
                                                          .idEstablecimiento = intIdEstablecimiento,
                                                          .fechaProceso = fechaProceso,
                                                          .movimientoCaja = strMovimiento,
                                                          .tipousuario = Tipo_Caja.PUNTO_DE_VENTA}).Where(Function(o) o.estado = "1" _
                                                          And o.fechaCobro.Value.Year = fechaLab.Year _
                                                          And o.fechaCobro.Value.Month = fechaLab.Month _
                                                          And o.fechaCobro.Value.Day = fechaLab.Day).ToList
            End If



        End If


        For Each i As documentoCaja In listaDocCaja
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaCobro).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoOperacion
            dr(2) = "COMPROBANTE DE CAJA"
            dr(3) = str
            dr(4) = i.numeroDoc
            Select Case i.moneda
                Case 1
                    dr(5) = "NACIONAL"
            End Select
            dr(6) = CDec(i.montoSoles).ToString("N2")
            dr(7) = i.tipoCambio
            dr(8) = CDec(i.montoUsd).ToString("N2")
            dr(9) = "-"
            dr(10) = i.NomCajaOrigen
            dr(11) = i.idPersonal
            dr(12) = i.tipoPersona
            dr(13) = i.MontoEgresosMN
            dr(14) = i.MontoEgresosME
            dr(15) = CDec(i.montoSoles - i.MontoEgresosMN)
            dr(16) = CDec(i.montoUsd - i.MontoEgresosME)
            Select Case i.estado
                Case "1"
                    dr(17) = "Activo"
                Case "0"
                    dr(17) = "Anulado"
                    'Case TIPO_ESTADO_CAJA.NO_USADO
                    '    dr(17) = "PENDIENTE DE USO"
                    'Case TIPO_ESTADO_CAJA.USADO_PARCIAL
                    '    dr(17) = "IMPUTADO PARCIALMENTE"
                    'Case TIPO_ESTADO_CAJA.USADO_TOTAL
                    '    dr(17) = "IMPUTADO TOTAL"
                    'Case TIPO_ESTADO_CAJA.ANULADO
                    '    dr(17) = "REVERTIDO-ANULADO"
                    'Case TIPO_ESTADO_CAJA.DEVOLUCION
                    '    dr(17) = "DEVOLUCION"
            End Select
            Dim usuarioSoftpack = Seguridad.General.ListaUsuariosSoftpack.Where(Function(o) o.IDUsuario = i.usuarioModificacion).SingleOrDefault
            If usuarioSoftpack IsNot Nothing Then
                dr(18) = usuarioSoftpack.Full_Name
            Else
                dr(18) = "NN"
            End If
            dt.Rows.Add(dr)
        Next
        dgvOtrosMov.DataSource = dt
    End Sub
#End Region


    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click
        Cursor = Cursors.WaitCursor
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.NUEVA_SALIDA_CAJA_Botón___, AutorizacionRolList) Then
            Dim cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
            If Not IsNothing(cajaUsuario) Then
                GetGlobalMappingCajaUsuario(cajaUsuario, usuario.IDUsuario, usuario.CustomUsuario.Full_Name)
                Dim f As New FormPagoEgreso
                f.txtAnioCompra.Text = DateTime.Now.Year
                f.cboMesCompra.SelectedValue = String.Format("{0:00}", DateTime.Now.Month)
                f.txtHora.Value = DateTime.Now
                f.TxtDia.Text = DateTime.Now.Day
                f.StartPosition = FormStartPosition.CenterParent
                f.txtTipoCambio.Value = TmpTipoCambio
                f.ShowDialog(Me)
            Else
                MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
        Cursor = Cursors.WaitCursor
        If Not IsNothing(Me.dgvOtrosMov.Table.CurrentRecord) Then
            Dim f As New FormVerPagos(Me.dgvOtrosMov.Table.CurrentRecord.GetValue("idDocumento"))
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
        Else
            MessageBox.Show("Debe seleccionar un item!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Cursor = Cursors.WaitCursor
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.ANULAR_SALIDA_CAJA_Botón___, AutorizacionRolList) Then
            If Not IsNothing(Me.dgvOtrosMov.Table.CurrentRecord) Then
                If MessageBox.Show("Desea anular la transacción elegida?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Dim cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
                    If Not IsNothing(cajaUsuario) Then
                        GetGlobalMappingCajaUsuario(cajaUsuario, usuario.IDUsuario, usuario.CustomUsuario.Full_Name)
                        GetAnularOperacion(Integer.Parse(dgvOtrosMov.Table.CurrentRecord.GetValue("idDocumento")))
                    Else
                        MessageBox.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End If
            Else
                MessageBox.Show("Debe seleccionar una item!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BunifuFlatButton5_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton5.Click
        Dim f As New FormFiltroAvanzadoPeriodo()
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        If f.Tag IsNot Nothing Then
            Dim periodoSel = CType(f.Tag, DateTime?)
            PictureLoad.Visible = True
            BunifuFlatButton5.Enabled = False
            GetMovimientosPeriodo(GEstableciento.IdEstablecimiento, GetPeriodo(periodoSel, True), "OSC")
            PictureLoad.Visible = False
            BunifuFlatButton5.Enabled = True
        End If
    End Sub

    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton3.Click
        Dim f As New FormFiltroAvanzadoDia()
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        If f.Tag IsNot Nothing Then
            Dim FechaSel = CType(f.Tag, DateTime?)
            PictureLoad.Visible = True
            BunifuFlatButton5.Enabled = False
            GetMovimientosDia(GEstableciento.IdEstablecimiento, GetPeriodo(FechaSel, True), "OSC", FechaSel)
            PictureLoad.Visible = False
            BunifuFlatButton5.Enabled = True
        End If
    End Sub
End Class
