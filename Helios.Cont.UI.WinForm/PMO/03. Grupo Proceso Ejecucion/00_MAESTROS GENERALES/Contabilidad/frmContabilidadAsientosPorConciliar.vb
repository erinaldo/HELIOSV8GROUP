Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class frmContabilidadAsientosPorConciliar

#Region "Attributes"
    Public Property ListaAsientos As New List(Of asiento)
    Public Property ListaMovimiento As New List(Of movimiento)
    Public Property ListadoCuentasContables As New List(Of cuentaplanContableEmpresa)
    Public Property ListadoOperaciones As New List(Of tabladetalle)
    Public Property TablaSA As New tablaDetalleSA
#End Region

#Region "Constructors"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormatoGridPequeño(dgvAlerta, True)
        FormatoGridPequeño(dgvMovimientos, False)
        txtPeriodo.Value = GetPeriodoConvertirToDate(PeriodoGeneral)
        getAlertasInventario()
        ListadoOperaciones = TablaSA.GetListaTablaDetalle(12, "1")
        LoadCombos()
    End Sub


#End Region

#Region "Methods"

    Dim n As New asiento

    Private Sub GrabarListaAsientos()
        Dim asientoSA As New AsientoSA

        'If dgvAlerta.Table.CurrentRecord.GetValue("tipoCompra") = "OSC" Or dgvAlerta.Table.CurrentRecord.GetValue("tipoCompra") = TIPO_VENTA.OTRAS_SALIDAS Then

        Dim sumMov = (From t In ListaMovimiento
                      Where t.cuenta.StartsWith("6")).ToList

        Dim keyCosto As Integer = 0
        For Each i In sumMov
            Dim cod = Mid(i.cuenta, 1, 2)
            Select Case cod
                Case 62 To 68
                    keyCosto += 1
                Case Else

            End Select
        Next

        If keyCosto > 0 Then
            'If panelCosto.Visible = True Then
            '    If rbCosto.Checked Or rbGasto.Checked = True Then

            'Dim updateCosto = (From n In ListaAsientos
            '                   Select n).ToList

            'For Each i In updateCosto
            '    If rbCosto.Checked = True Then
            '        i.idCosto = cboElementoCosto.SelectedValue
            '        i.IdProceso = cboproceso2.SelectedValue
            '    ElseIf rbGasto.Checked = True Then
            '        i.idCosto = cboCosto.SelectedValue
            '        i.IdProceso = cboproceso2.SelectedValue
            '    End If
            'Next

            '        validacionCosto() ' add asiento adicional por el costo


            '        If cboproceso2.Text.Trim.Length > 0 Then
            asientoSA.GrabarListaAsientosXConciliar(ListaAsientos)

            For Each i In ListaAsientos
                For Each r As Record In dgvAlerta.Table.Records
                    If r.GetValue("idDocumento") = i.idDocumento Then
                        r.Delete()
                    End If
                Next
            Next
            MessageBoxAdv.Show("Comprobantes asignados!", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ButtonAdv1.Focus()
            ButtonAdv1.Select()
            ListaAsientos = New List(Of asiento)
            ListaMovimiento = New List(Of movimiento)
            lstAsientos.DataSource = Nothing
            dgvMovimientos.DataSource = New List(Of movimiento)
            lblOperacion.Text = String.Empty
            getAlertasInventario()

            '        Else
            '            MessageBoxAdv.Show("Debe seleccionar un proceso!", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '            cboproceso2.Select()
            '            cboproceso2.DroppedDown = True
            '        End If

            '    Else
            '        panelCosto.Visible = True
            '        MessageBox.Show("Debe Identificar el costo!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    End If
            'Else
            '    panelCosto.Visible = True
            '    MessageBox.Show("Debe Identificar el costo!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    rbGasto.Checked = True
            'End If
        Else
            asientoSA.GrabarListaAsientosXConciliar(ListaAsientos)


            For Each i In ListaAsientos
                For Each r As Record In dgvAlerta.Table.Records
                    If r.GetValue("idDocumento") = i.idDocumento Then
                        r.Delete()
                    End If
                Next
            Next
            MessageBoxAdv.Show("Comprobantes asignados!", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ButtonAdv1.Focus()
            ButtonAdv1.Select()
            ListaAsientos = New List(Of asiento)
            ListaMovimiento = New List(Of movimiento)
            lstAsientos.DataSource = Nothing
            dgvMovimientos.DataSource = New List(Of movimiento)
            lblOperacion.Text = String.Empty
            getAlertasInventario()
        End If


        'If panelCosto.Visible Then
        '    If validacionCajaCosto() = True Then
        '        Dim updateCosto = (From n In ListaAsientos _
        '                          Select n).ToList

        '        For Each i In updateCosto
        '            i.idCosto = cboElementoCosto.SelectedValue
        '        Next

        '    Else
        '        Exit Sub

        '    End If

        'Else

        'End If



    End Sub

    Private Sub AddAsientoFinanzas()
        Dim n As New asiento
        n.periodo = GetPeriodo(txtPeriodo.Value, True)
        n.Action = Business.Entity.BaseBE.EntityAction.INSERT
        n.idDocumento = Val(dgvAlerta.Table.CurrentRecord.GetValue("idDocumento"))
        n.idEmpresa = Gempresas.IdEmpresaRuc
        n.idCentroCostos = GEstableciento.IdEstablecimiento
        n.fechaProceso = DateTime.Now

        Select Case dgvAlerta.Table.CurrentRecord.GetValue("tipoCompra")
            Case "OEC"
                n.codigoLibro = "1"
            Case "OSC"
                n.codigoLibro = "1"
            Case TIPO_COMPRA.OTRAS_ENTRADAS
                n.codigoLibro = "13"
            Case TIPO_VENTA.OTRAS_SALIDAS
                n.codigoLibro = "13"
        End Select

        n.tipo = "D"
        n.tipoAsiento = "AS-M"
        n.glosa = lblDetalleOperacion.Text
        If ListaAsientos.Count > 0 Then
            n.idAsiento = ListaAsientos.Count + 1
            n.Descripcion = "Asiento " & ListaAsientos.Count + 1
        Else
            n.idAsiento = 1
            n.Descripcion = "Asiento " & 1
        End If
        n.usuarioActualizacion = usuario.IDUsuario
        n.fechaActualizacion = DateTime.Now
        ListaAsientos.Add(n)
        '--------------------------------------------------------------------------------------
        'MOVIMIENTO
        Select Case dgvAlerta.Table.CurrentRecord.GetValue("tipoCompra")
            Case "OEC"
                Dim nc As New movimiento
                nc.idAsiento = n.idAsiento
                If ListaMovimiento.Count > 0 Then
                    nc.idmovimiento = ListaMovimiento.Count + 1
                Else
                    nc.idmovimiento = 1
                End If
                nc.cuenta = dgvAlerta.Table.CurrentRecord.GetValue("NroDocEntidad")
                nc.descripcion = dgvAlerta.Table.CurrentRecord.GetValue("NombreEntidad")
                nc.tipo = "D"
                nc.monto = CDec(dgvAlerta.Table.CurrentRecord.GetValue("importeTotal"))
                nc.montoUSD = 0
                nc.tipoModulo = "OES"
                ListaMovimiento.Add(nc)
            Case "OSC"
                Dim nc As New movimiento
                nc.idAsiento = n.idAsiento
                If ListaMovimiento.Count > 0 Then
                    nc.idmovimiento = ListaMovimiento.Count + 1
                Else
                    nc.idmovimiento = 1
                End If
                nc.cuenta = dgvAlerta.Table.CurrentRecord.GetValue("NroDocEntidad")
                nc.descripcion = dgvAlerta.Table.CurrentRecord.GetValue("NombreEntidad")
                nc.tipo = "H"
                nc.monto = CDec(dgvAlerta.Table.CurrentRecord.GetValue("importeTotal"))
                nc.montoUSD = 0
                nc.tipoModulo = "OES"
                ListaMovimiento.Add(nc)
            Case TIPO_COMPRA.OTRAS_ENTRADAS

            Case TIPO_VENTA.OTRAS_SALIDAS

        End Select
        GetListadoAsientos(Val(dgvAlerta.Table.CurrentRecord.GetValue("idDocumento")))
        GetListadoMovimientoByAsiento(New asiento With {.idAsiento = n.idAsiento})
    End Sub

    Private Sub AddAsientoInventarioOE()
        Dim n As New asiento
        n.periodo = GetPeriodo(txtPeriodo.Value, True)
        n.Action = Business.Entity.BaseBE.EntityAction.INSERT
        n.idDocumento = Val(dgvAlerta.Table.CurrentRecord.GetValue("idDocumento"))
        n.idEmpresa = Gempresas.IdEmpresaRuc
        n.idCentroCostos = GEstableciento.IdEstablecimiento
        n.fechaProceso = DateTime.Now
        n.codigoLibro = "13"
        n.tipo = "D"
        n.tipoAsiento = "AS-M"
        n.glosa = lblDetalleOperacion.Text
        If ListaAsientos.Count > 0 Then
            n.idAsiento = ListaAsientos.Count + 1
            n.Descripcion = "Asiento " & ListaAsientos.Count + 1
        Else
            n.idAsiento = 1
            n.Descripcion = "Asiento " & 1
        End If
        n.usuarioActualizacion = usuario.IDUsuario
        n.fechaActualizacion = DateTime.Now
        ListaAsientos.Add(n)
        '--------------------------------------------------------------------------------------
        'MOVIMIENTO
        Select Case dgvAlerta.Table.CurrentRecord.GetValue("tipoCompra")
            Case TIPO_COMPRA.OTRAS_ENTRADAS

                For Each i As ListViewItem In lsvPlantilla.Items
                    Select Case i.SubItems(5).Text
                        Case "MERCADERIA" '01
                            Dim nc As New movimiento
                            nc.idAsiento = n.idAsiento
                            If ListaMovimiento.Count > 0 Then
                                nc.idmovimiento = ListaMovimiento.Count + 1
                            Else
                                nc.idmovimiento = 1
                            End If
                            nc.cuenta = "20111"
                            nc.descripcion = i.SubItems(1).Text
                            nc.tipo = "D"
                            nc.monto = CDec(i.SubItems(4).Text).ToString("N2")
                            nc.montoUSD = 0

                            ListaMovimiento.Add(nc)


                        Case "PRODUCTO TERMINADO" '02
                            Dim nc As New movimiento
                            nc.idAsiento = n.idAsiento
                            If ListaMovimiento.Count > 0 Then
                                nc.idmovimiento = ListaMovimiento.Count + 1
                            Else
                                nc.idmovimiento = 1
                            End If
                            nc.cuenta = "211"
                            nc.descripcion = i.SubItems(1).Text
                            nc.tipo = "D"
                            nc.monto = CDec(i.SubItems(4).Text).ToString("N2")
                            nc.montoUSD = 0

                            ListaMovimiento.Add(nc)

                        Case "MATERIAS PRIMAS" '03
                            Dim nc As New movimiento
                            nc.idAsiento = n.idAsiento
                            If ListaMovimiento.Count > 0 Then
                                nc.idmovimiento = ListaMovimiento.Count + 1
                            Else
                                nc.idmovimiento = 1
                            End If
                            nc.cuenta = "241"
                            nc.descripcion = i.SubItems(1).Text
                            nc.tipo = "D"
                            nc.monto = CDec(i.SubItems(4).Text).ToString("N2")
                            nc.montoUSD = 0

                            ListaMovimiento.Add(nc)
                        Case "ENVASES Y EMBALAJES" '04
                            Dim nc As New movimiento
                            nc.idAsiento = n.idAsiento
                            If ListaMovimiento.Count > 0 Then
                                nc.idmovimiento = ListaMovimiento.Count + 1
                            Else
                                nc.idmovimiento = 1
                            End If
                            nc.cuenta = "261"
                            nc.descripcion = i.SubItems(1).Text
                            nc.tipo = "D"
                            nc.monto = CDec(i.SubItems(4).Text).ToString("N2")
                            nc.montoUSD = 0

                            ListaMovimiento.Add(nc)

                        Case "MATERIALES AUXILIARES, SUMINISTROS Y RESPUESTOS" '05
                            Dim nc As New movimiento
                            nc.idAsiento = n.idAsiento
                            If ListaMovimiento.Count > 0 Then
                                nc.idmovimiento = ListaMovimiento.Count + 1
                            Else
                                nc.idmovimiento = 1
                            End If
                            nc.cuenta = "251"
                            nc.descripcion = i.SubItems(1).Text
                            nc.tipo = "D"
                            nc.monto = CDec(i.SubItems(4).Text).ToString("N2")
                            nc.montoUSD = 0

                            ListaMovimiento.Add(nc)

                        Case "SUB-PRODUCTOS, DESECHOS Y DESPERDICIOS" '06
                            Dim nc As New movimiento
                            nc.idAsiento = n.idAsiento
                            If ListaMovimiento.Count > 0 Then
                                nc.idmovimiento = ListaMovimiento.Count + 1
                            Else
                                nc.idmovimiento = 1
                            End If
                            nc.cuenta = "221"
                            nc.descripcion = i.SubItems(1).Text
                            nc.tipo = "D"
                            nc.monto = CDec(i.SubItems(4).Text).ToString("N2")
                            nc.montoUSD = 0

                            ListaMovimiento.Add(nc)

                        Case "PRODUCTOS EN PROCESO" '07
                            Dim nc As New movimiento
                            nc.idAsiento = n.idAsiento
                            If ListaMovimiento.Count > 0 Then
                                nc.idmovimiento = ListaMovimiento.Count + 1
                            Else
                                nc.idmovimiento = 1
                            End If
                            nc.cuenta = "231"
                            nc.descripcion = i.SubItems(1).Text
                            nc.tipo = "D"
                            nc.monto = CDec(i.SubItems(4).Text).ToString("N2")
                            nc.montoUSD = 0

                            ListaMovimiento.Add(nc)

                        Case "ACTIVO INMOVILIZADO" '08
                            Dim nc As New movimiento
                            nc.idAsiento = n.idAsiento
                            If ListaMovimiento.Count > 0 Then
                                nc.idmovimiento = ListaMovimiento.Count + 1
                            Else
                                nc.idmovimiento = 1
                            End If
                            nc.cuenta = "338"
                            nc.descripcion = i.SubItems(1).Text
                            nc.tipo = "D"
                            nc.monto = CDec(i.SubItems(4).Text).ToString("N2")
                            nc.montoUSD = 0

                            ListaMovimiento.Add(nc)
                    End Select
                Next


            Case TIPO_VENTA.OTRAS_SALIDAS
                For Each i As ListViewItem In lsvPlantilla.Items
                    Select Case i.SubItems(5).Text
                        Case "MERCADERIA" '01
                            Dim nc As New movimiento
                            nc.idAsiento = n.idAsiento
                            If ListaMovimiento.Count > 0 Then
                                nc.idmovimiento = ListaMovimiento.Count + 1
                            Else
                                nc.idmovimiento = 1
                            End If
                            nc.cuenta = "20111"
                            nc.descripcion = i.SubItems(1).Text
                            nc.tipo = "H"
                            nc.monto = CDec(i.SubItems(4).Text).ToString("N2")
                            nc.montoUSD = 0

                            ListaMovimiento.Add(nc)


                        Case "PRODUCTO TERMINADO" '02
                            Dim nc As New movimiento
                            nc.idAsiento = n.idAsiento
                            If ListaMovimiento.Count > 0 Then
                                nc.idmovimiento = ListaMovimiento.Count + 1
                            Else
                                nc.idmovimiento = 1
                            End If
                            nc.cuenta = "211"
                            nc.descripcion = i.SubItems(1).Text
                            nc.tipo = "H"
                            nc.monto = CDec(i.SubItems(4).Text).ToString("N2")
                            nc.montoUSD = 0

                            ListaMovimiento.Add(nc)

                        Case "MATERIAS PRIMAS" '03
                            Dim nc As New movimiento
                            nc.idAsiento = n.idAsiento
                            If ListaMovimiento.Count > 0 Then
                                nc.idmovimiento = ListaMovimiento.Count + 1
                            Else
                                nc.idmovimiento = 1
                            End If
                            nc.cuenta = "241"
                            nc.descripcion = i.SubItems(1).Text
                            nc.tipo = "H"
                            nc.monto = CDec(i.SubItems(4).Text).ToString("N2")
                            nc.montoUSD = 0

                            ListaMovimiento.Add(nc)
                        Case "ENVASES Y EMBALAJES" '04
                            Dim nc As New movimiento
                            nc.idAsiento = n.idAsiento
                            If ListaMovimiento.Count > 0 Then
                                nc.idmovimiento = ListaMovimiento.Count + 1
                            Else
                                nc.idmovimiento = 1
                            End If
                            nc.cuenta = "261"
                            nc.descripcion = i.SubItems(1).Text
                            nc.tipo = "H"
                            nc.monto = CDec(i.SubItems(4).Text).ToString("N2")
                            nc.montoUSD = 0

                            ListaMovimiento.Add(nc)

                        Case "MATERIALES AUXILIARES, SUMINISTROS Y RESPUESTOS" '05
                            Dim nc As New movimiento
                            nc.idAsiento = n.idAsiento
                            If ListaMovimiento.Count > 0 Then
                                nc.idmovimiento = ListaMovimiento.Count + 1
                            Else
                                nc.idmovimiento = 1
                            End If
                            nc.cuenta = "251"
                            nc.descripcion = i.SubItems(1).Text
                            nc.tipo = "H"
                            nc.monto = CDec(i.SubItems(4).Text).ToString("N2")
                            nc.montoUSD = 0

                            ListaMovimiento.Add(nc)

                        Case "SUB-PRODUCTOS, DESECHOS Y DESPERDICIOS" '06
                            Dim nc As New movimiento
                            nc.idAsiento = n.idAsiento
                            If ListaMovimiento.Count > 0 Then
                                nc.idmovimiento = ListaMovimiento.Count + 1
                            Else
                                nc.idmovimiento = 1
                            End If
                            nc.cuenta = "221"
                            nc.descripcion = i.SubItems(1).Text
                            nc.tipo = "H"
                            nc.monto = CDec(i.SubItems(4).Text).ToString("N2")
                            nc.montoUSD = 0

                            ListaMovimiento.Add(nc)

                        Case "PRODUCTOS EN PROCESO" '07
                            Dim nc As New movimiento
                            nc.idAsiento = n.idAsiento
                            If ListaMovimiento.Count > 0 Then
                                nc.idmovimiento = ListaMovimiento.Count + 1
                            Else
                                nc.idmovimiento = 1
                            End If
                            nc.cuenta = "231"
                            nc.descripcion = i.SubItems(1).Text
                            nc.tipo = "H"
                            nc.monto = CDec(i.SubItems(4).Text).ToString("N2")
                            nc.montoUSD = 0

                            ListaMovimiento.Add(nc)

                        Case "ACTIVO INMOVILIZADO" '08
                            Dim nc As New movimiento
                            nc.idAsiento = n.idAsiento
                            If ListaMovimiento.Count > 0 Then
                                nc.idmovimiento = ListaMovimiento.Count + 1
                            Else
                                nc.idmovimiento = 1
                            End If
                            nc.cuenta = "338"
                            nc.descripcion = i.SubItems(1).Text
                            nc.tipo = "H"
                            nc.monto = CDec(i.SubItems(4).Text).ToString("N2")
                            nc.montoUSD = 0

                            ListaMovimiento.Add(nc)
                    End Select
                Next
        End Select
        GetListadoAsientos(Val(dgvAlerta.Table.CurrentRecord.GetValue("idDocumento")))
        GetListadoMovimientoByAsiento(New asiento With {.idAsiento = n.idAsiento})
    End Sub

    Private Sub AddAsiento()
        Dim n As New asiento
        n.periodo = GetPeriodo(txtPeriodo.Value, True)
        n.Action = Business.Entity.BaseBE.EntityAction.INSERT
        n.idDocumento = Val(dgvAlerta.Table.CurrentRecord.GetValue("idDocumento"))
        n.idEmpresa = Gempresas.IdEmpresaRuc
        n.idCentroCostos = GEstableciento.IdEstablecimiento
        n.fechaProceso = DateTime.Now

        Select Case dgvAlerta.Table.CurrentRecord.GetValue("tipoCompra")
            Case "OEC"
                n.codigoLibro = "1"
            Case "OSC"
                n.codigoLibro = "1"
            Case TIPO_COMPRA.OTRAS_ENTRADAS
                n.codigoLibro = "13"
            Case TIPO_VENTA.OTRAS_SALIDAS
                n.codigoLibro = "13"
        End Select

        n.tipo = "D"
        n.tipoAsiento = "AS-M"
        n.glosa = lblDetalleOperacion.Text
        If ListaAsientos.Count > 0 Then
            n.idAsiento = ListaAsientos.Count + 1
            n.Descripcion = "Asiento " & ListaAsientos.Count + 1
        Else
            n.idAsiento = 1
            n.Descripcion = "Asiento " & 1
        End If
        n.usuarioActualizacion = usuario.IDUsuario
        n.fechaActualizacion = DateTime.Now
        ListaAsientos.Add(n)
        GetListadoAsientos(Val(dgvAlerta.Table.CurrentRecord.GetValue("idDocumento")))
    End Sub

    Private Sub AddMovimiento()
        Dim n As New movimiento
        n.idAsiento = lstAsientos.SelectedValue
        'martin
        Dim numAsiento As Integer = lstAsientos.SelectedValue

        Dim consulta = (From list In ListaAsientos
                        Where list.idAsiento = numAsiento).FirstOrDefault


        If consulta.codigoLibro = "1" Then
            n.tipoModulo = "OES"
        End If
        'martin
        If ListaMovimiento.Count > 0 Then
            n.idmovimiento = ListaMovimiento.Count + 1
        Else
            n.idmovimiento = 1
        End If
        n.cuenta = txtCuentaSel.Tag
        n.descripcion = txtCuentaSel.Text
        n.tipo = "D"
        n.monto = 0
        n.montoUSD = 0

        ListaMovimiento.Add(n)

        GetListadoMovimientoByAsiento(New asiento With {.idAsiento = lstAsientos.SelectedValue})
    End Sub

    Private Sub EliminarFilaMovimiento(mov As movimiento)
        Dim consulta = (From n In ListaMovimiento
                        Where n.idmovimiento = mov.idmovimiento).FirstOrDefault

        ListaMovimiento.Remove(consulta)
        GetListadoMovimientoByAsiento(New asiento With {.idAsiento = lstAsientos.SelectedValue})
    End Sub

    Private Sub LoadCombos()
        Dim dt As New DataTable
        Dim tablaSA As New tablaDetalleSA

        cboOperacion.DisplayMember = "descripcion"
        cboOperacion.ValueMember = "codigoDetalle"
        cboOperacion.DataSource = tablaSA.GetListaTablaDetalle(12, "1")

        Dim cuentaSA As New cuentaplanContableEmpresaSA
        ListadoCuentasContables = cuentaSA.ObtenerCuentasPorEmpresaEscalable(Gempresas.IdEmpresaRuc)

        dt.Columns.Add("id")
        dt.Columns.Add("name")
        Dim dr As DataRow = dt.NewRow
        dr(0) = "D"
        dr(1) = "DEBE"
        dt.Rows.Add(dr)

        Dim dr1 As DataRow = dt.NewRow
        dr1(0) = "H"
        dr1(1) = "HABER"
        dt.Rows.Add(dr1)

        Dim ggcStyle As GridTableCellStyleInfo = dgvMovimientos.TableDescriptor.Columns("tipo").Appearance.AnyRecordFieldCell
        ggcStyle.CellType = "ComboBox"
        ggcStyle.DataSource = dt
        ggcStyle.ValueMember = "id"
        ggcStyle.DisplayMember = "name"
        ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive

    End Sub

    Private Sub getAlertasInventario()
        Dim documentoSA As New DocumentoCompraSA

        Dim conteo1 = documentoSA.GetNumAlertasInventariosSinAsiento(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                                                  .idCentroCosto = GEstableciento.IdEstablecimiento,
                                                                                  .fechaContable = GetPeriodo(txtPeriodo.Value, True),
                                                                                  .aprobado = "N", .tipoCompra = TIPO_COMPRA.OTRAS_ENTRADAS})


        Dim conteo2 = documentoSA.GetNumFinanzasSinAsiento(New documentoCaja With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                                                 .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                                 .periodo = GetPeriodo(txtPeriodo.Value, True),
                                                                                 .estado = "N"})


        lblAlertaInventario.Text = conteo1
        lblAlertaFinanzas.Text = conteo2

        ' lblAlertasgeneral.Text = conteo1 + conteo2
    End Sub

    Private Sub GetListadoAsientos(intIdDocumento As Integer)
        Dim con = (From n In ListaAsientos
                   Where n.idDocumento = intIdDocumento).ToList

        lstAsientos.DataSource = con
        lstAsientos.ValueMember = "idAsiento"
        lstAsientos.DisplayMember = "Descripcion"
    End Sub

    Private Sub GetListadoMovimientoByAsiento(be As asiento)
        Dim con = (From n In ListaMovimiento
                   Where n.idAsiento = be.idAsiento).ToList

        dgvMovimientos.DataSource = con
    End Sub

    Private Sub EliminarAsientoByCodigo(be As asiento)

        Dim con1 = (From n In ListaMovimiento
                    Where n.idAsiento = be.idAsiento).ToList

        For Each i In con1
            ListaMovimiento.Remove(i)
        Next

        Dim con2 = (From n In ListaAsientos
                    Where n.idAsiento = be.idAsiento).FirstOrDefault

        ListaAsientos.Remove(con2)

        If Not IsNothing(dgvAlerta.Table.CurrentRecord) Then
            GetListadoAsientos(Val(dgvAlerta.Table.CurrentRecord.GetValue("idDocumento")))
        End If

        If lstAsientos.SelectedItems.Count > 0 Then
            GetListadoMovimientoByAsiento(New asiento With {.idAsiento = lstAsientos.SelectedValue})
        Else
            dgvMovimientos.DataSource = New List(Of movimiento)
        End If
    End Sub

    Private Sub GetAlertaFinanzas()
        Dim compraSA As New DocumentoCompraSA
        Dim dt As New DataTable()

        dt.Columns.Add("idDocumento")
        dt.Columns.Add("tipoCompra")
        dt.Columns.Add("fechaDoc")
        dt.Columns.Add("tipoDoc")
        dt.Columns.Add("serie")
        dt.Columns.Add("numeroDoc")
        dt.Columns.Add("tipoDocEntidad")
        dt.Columns.Add("NroDocEntidad")
        dt.Columns.Add("NombreEntidad")
        dt.Columns.Add("tipoPersona")
        dt.Columns.Add("importeTotal")
        dt.Columns.Add("tcDolLoc")
        dt.Columns.Add("importeUS")
        dt.Columns.Add("monedaDoc")
        dt.Columns.Add("usuarioActualizacion")
        dt.Columns.Add("glosa")
        dt.Columns.Add("tipooperacion")

        For Each i In compraSA.GetFinanzasSinAsiento(New documentoCaja With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                                                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                                  .periodo = GetPeriodo(txtPeriodo.Value, True),
                                                                                  .estado = "N"})

            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idDocumento
            dr(1) = i.movimientoCaja
            dr(2) = i.fechaProceso
            dr(3) = i.tipoDocPago
            dr(4) = "-"
            dr(5) = i.numeroDoc
            dr(6) = ""
            dr(7) = i.entidadFinanciera
            dr(8) = i.NombreEntidad
            dr(9) = ""
            dr(10) = i.montoSoles
            dr(11) = i.tipoCambio
            dr(12) = i.montoUsd
            dr(13) = i.moneda
            dr(14) = i.usuarioModificacion
            dr(15) = i.glosa
            dr(16) = i.tipoOperacion
            dt.Rows.Add(dr)
        Next
        dgvAlerta.DataSource = dt

        If dgvAlerta.Table.Records.Count > 0 Then
            dgvAlerta.Table.Records(0).SetCurrent()
            dgvAlerta.Table.Records(0).SetSelected(True)

            Dim detallename = (From n In ListadoOperaciones
                               Where n.codigoDetalle = dgvAlerta.Table.CurrentRecord.GetValue("tipooperacion")).FirstOrDefault

            lblOperacion.Text = "Tipo Operación: " & detallename.descripcion

            lblDetalleOperacion.Text = dgvAlerta.Table.CurrentRecord.GetValue("glosa")

            dgvMovimientos.DataSource = New List(Of movimiento)
            'GetListadoAsientos(Val(dgvAlerta.Table.CurrentRecord.GetValue("idDocumento")))
            'UbicarDetalleComprobante(Val(dgvAlerta.Table.CurrentRecord.GetValue("idDocumento")))
        End If

    End Sub

    Private Sub GetAlertaInventarios()
        Dim compraSA As New DocumentoCompraSA
        Dim dt As New DataTable()

        dt.Columns.Add("idDocumento")
        dt.Columns.Add("tipoCompra")
        dt.Columns.Add("fechaDoc")
        dt.Columns.Add("tipoDoc")
        dt.Columns.Add("serie")
        dt.Columns.Add("numeroDoc")
        dt.Columns.Add("tipoDocEntidad")
        dt.Columns.Add("NroDocEntidad")
        dt.Columns.Add("NombreEntidad")
        dt.Columns.Add("tipoPersona")
        dt.Columns.Add("importeTotal")
        dt.Columns.Add("tcDolLoc")
        dt.Columns.Add("importeUS")
        dt.Columns.Add("monedaDoc")
        dt.Columns.Add("usuarioActualizacion")
        dt.Columns.Add("glosa")
        dt.Columns.Add("tipooperacion")

        For Each i In compraSA.GetInventariosSinAsiento(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                                                  .idCentroCosto = GEstableciento.IdEstablecimiento,
                                                                                  .fechaContable = GetPeriodo(txtPeriodo.Value, True),
                                                                                  .aprobado = "N", .tipoCompra = TIPO_COMPRA.OTRAS_ENTRADAS})

            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idDocumento
            dr(1) = i.tipoCompra
            dr(2) = i.fechaDoc
            dr(3) = i.tipoDoc
            dr(4) = i.serie
            dr(5) = i.numeroDoc
            dr(6) = ""
            dr(7) = ""
            dr(8) = ""
            dr(9) = ""
            dr(10) = i.importeTotal
            dr(11) = i.tcDolLoc
            dr(12) = i.importeUS
            dr(13) = i.monedaDoc
            dr(14) = i.usuarioActualizacion
            dr(15) = i.glosa
            dr(16) = i.tipoOperacion
            dt.Rows.Add(dr)
        Next
        dgvAlerta.DataSource = dt

        If dgvAlerta.Table.Records.Count > 0 Then
            dgvAlerta.Table.Records(0).SetCurrent()
            dgvAlerta.Table.Records(0).SetSelected(True)

            Dim detallename = (From n In ListadoOperaciones
                               Where n.codigoDetalle = dgvAlerta.Table.CurrentRecord.GetValue("tipooperacion")).FirstOrDefault

            lblOperacion.Text = "Tipo Operación: " & detallename.descripcion

            lblDetalleOperacion.Text = dgvAlerta.Table.CurrentRecord.GetValue("glosa")

            dgvMovimientos.DataSource = New List(Of movimiento)
            GetListadoAsientos(Val(dgvAlerta.Table.CurrentRecord.GetValue("idDocumento")))
            UbicarDetalleComprobante(Val(dgvAlerta.Table.CurrentRecord.GetValue("idDocumento")))
        End If

    End Sub

    Private Sub UbicarDetalleComprobante(intIdDocumento As Integer)
        Dim compraSA As New DocumentoCompraDetalleSA
        Dim suma As Decimal = 0
        lsvPlantilla.Items.Clear()

        For Each i In compraSA.UbicarDocumentoCompraDetalle(intIdDocumento)
            suma += CDec(i.importe)
            Dim n As New ListViewItem(i.secuencia)
            n.SubItems.Add(i.descripcionItem)
            n.SubItems.Add(i.destino)
            n.SubItems.Add(i.monto1)
            n.SubItems.Add(i.importe)
            Select Case i.tipoExistencia
                Case "01"
                    n.SubItems.Add("MERCADERIA")
                Case "02"
                    n.SubItems.Add("PRODUCTO TERMINADO")
                Case "03"
                    n.SubItems.Add("MATERIAS PRIMAS")
                Case "04"
                    n.SubItems.Add("ENVASES Y EMBALAJES")
                Case "05"
                    n.SubItems.Add("MATERIALES AUXILIARES, SUMINISTROS Y RESPUESTOS")
                Case "06"
                    n.SubItems.Add("SUB-PRODUCTOS, DESECHOS Y DESPERDICIOS")
                Case "07"
                    n.SubItems.Add("PRODUCTOS EN PROCESO")

                Case "08"
                    n.SubItems.Add("ACTIVO INMOVILIZADO")

            End Select

            lsvPlantilla.Items.Add(n)

            'Dim n2 As New ListViewItem()
            'Select Case i.tipoExistencia
            '    Case "01"
            '        n2.SubItems.Add("MERCADERIA").BackColor = Color.LightYellow
            '    Case "02"
            '        n2.SubItems.Add("PRODUCTO TERMINADO").BackColor = Color.LightYellow
            '    Case "03"
            '        n2.SubItems.Add("MATERIAS PRIMAS").BackColor = Color.LightYellow
            '    Case "04"
            '        n2.SubItems.Add("ENVASES Y EMBALAJES").BackColor = Color.LightYellow
            '    Case "05"
            '        n2.SubItems.Add("MATERIALES AUXILIARES, SUMINISTROS Y RESPUESTOS").BackColor = Color.LightYellow
            '    Case "06"
            '        n2.SubItems.Add("SUB-PRODUCTOS, DESECHOS Y DESPERDICIOS").BackColor = Color.LightYellow
            '    Case "07"
            '        n2.SubItems.Add("PRODUCTOS EN PROCESO").BackColor = Color.LightYellow

            '    Case "08"
            '        n2.SubItems.Add("ACTIVO INMOVILIZADO").BackColor = Color.LightYellow

            'End Select
            'n2.SubItems.Add(String.Empty)
            'n2.SubItems.Add(String.Empty)
            'n2.SubItems.Add(String.Empty)
            'n2.SubItems.Add(String.Empty)
            'lsvPlantilla.Items.Add(n2)

        Next

        'Dim n1 As New ListViewItem()
        'n1.SubItems.Add("Total")
        'n1.SubItems.Add(String.Empty)
        'n1.SubItems.Add(String.Empty)
        'n1.SubItems.Add(suma)
        'n1.SubItems.Add(String.Empty)
        'lsvPlantilla.Items.Add(n1)
    End Sub
#End Region

#Region "Events"
    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Me.Cursor = Cursors.WaitCursor
        lsvPlantilla.Items.Clear()
        ListaAsientos = New List(Of asiento)
        ListaMovimiento = New List(Of movimiento)
        GetAlertaInventarios()
        'ToolStripButton6_Click(sender, e)
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Me.Cursor = Cursors.WaitCursor
        lsvPlantilla.Items.Clear()
        ListaAsientos = New List(Of asiento)
        ListaMovimiento = New List(Of movimiento)
        GetAlertaFinanzas()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvAlerta_TableControlCellClick(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs) Handles dgvAlerta.TableControlCellClick
        Me.Cursor = Cursors.WaitCursor

        If Not IsNothing(dgvAlerta.Table.CurrentRecord) Then
            Dim detallename = (From n In ListadoOperaciones
                               Where n.codigoDetalle = dgvAlerta.Table.CurrentRecord.GetValue("tipooperacion")).FirstOrDefault

            lblOperacion.Text = "Tipo Operación: " & detallename.descripcion

            lblDetalleOperacion.Text = dgvAlerta.Table.CurrentRecord.GetValue("glosa")

            dgvMovimientos.DataSource = New List(Of movimiento)
            GetListadoAsientos(Val(dgvAlerta.Table.CurrentRecord.GetValue("idDocumento")))
            UbicarDetalleComprobante(Val(dgvAlerta.Table.CurrentRecord.GetValue("idDocumento")))
        End If



        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        If Not IsNothing(dgvAlerta.Table.CurrentRecord) Then
            AddAsiento()
        Else
            MessageBoxAdv.Show("Debe seleccionar el documento base!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub ToolStripButton13_Click(sender As Object, e As EventArgs) Handles ToolStripButton13.Click
        If Not IsNothing(dgvAlerta.Table.CurrentRecord) Then
            ListaAsientos = New List(Of asiento)
            ListaMovimiento = New List(Of movimiento)


            Select Case dgvAlerta.Table.CurrentRecord.GetValue("tipoCompra")
                Case "OEC", "OSC"
                    AddAsientoFinanzas()

                Case TIPO_COMPRA.OTRAS_ENTRADAS
                    AddAsientoInventarioOE()
                Case TIPO_VENTA.OTRAS_SALIDAS
                    AddAsientoInventarioOE()
            End Select


        End If
    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        If lstAsientos.SelectedItems.Count > 0 Then
            EliminarAsientoByCodigo(New asiento With {.idAsiento = lstAsientos.SelectedValue})
        End If
    End Sub

    Private Sub ToolStripButton12_Click(sender As Object, e As EventArgs) Handles ToolStripButton12.Click
        GetListadoAsientos(Val(dgvAlerta.Table.CurrentRecord.GetValue("idDocumento")))
    End Sub

    Private Sub lstAsientos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstAsientos.SelectedIndexChanged
        If Not IsNothing(dgvAlerta.Table.CurrentRecord) Then
            Dim cod = lstAsientos.SelectedValue
            If IsNumeric(cod) Then
                GetListadoMovimientoByAsiento(New asiento With {.idAsiento = lstAsientos.SelectedValue})
            End If
        End If
    End Sub

    Private Sub txtCodigoCuentaBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtCodigoCuentaBuscar.TextChanged

    End Sub

    Private Sub txtCodigoCuentaBuscar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodigoCuentaBuscar.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        Else
            Me.pcCuentas.Font = New Font("Segoe UI", 8)
            Me.pcCuentas.Size = New Size(337, 142)
            Me.pcCuentas.ParentControl = Me.txtCodigoCuentaBuscar
            Me.pcCuentas.ShowPopup(Point.Empty)
            Dim consulta = (From n In ListadoCuentasContables
                            Where n.cuenta.StartsWith(txtCodigoCuentaBuscar.Text)).ToList

            lsvCuentasEncontradas.DataSource = consulta
            lsvCuentasEncontradas.DisplayMember = "descripcion"
            lsvCuentasEncontradas.ValueMember = "cuenta"

            e.Handled = True
        End If

        '  If Not Me.pcLikeCategoria.IsShowing() Then

        '   End If

        '    If Not Me.pcLikeCategoria.IsShowing() Then
        If e.KeyCode = Keys.Down Then
            Me.pcCuentas.Font = New Font("Segoe UI", 8)
            Me.pcCuentas.Size = New Size(337, 142)
            Me.pcCuentas.ParentControl = Me.txtCodigoCuentaBuscar
            Me.pcCuentas.ShowPopup(Point.Empty)
            lsvCuentasEncontradas.Focus()
        End If
        '   End If

        ' e.SuppressKeyPress = True
        If e.KeyCode = Keys.Escape Then
            If Me.pcCuentas.IsShowing() Then
                Me.pcCuentas.HidePopup(PopupCloseType.Canceled)
            End If
        End If
    End Sub

    Private Sub pcCuentas_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcCuentas.CloseUp
        Me.Cursor = Cursors.WaitCursor
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvCuentasEncontradas.SelectedItems.Count > 0 Then
                txtCuentaSel.Text = lsvCuentasEncontradas.Text
                txtCuentaSel.Tag = lsvCuentasEncontradas.SelectedValue


                If lstAsientos.SelectedItems.Count > 0 Then
                    If txtCuentaSel.Text.Trim.Length > 0 Then
                        AddMovimiento()
                    End If
                End If
            End If
        End If
        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtCodigoCuentaBuscar.Focus()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lsvCuentasEncontradas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvCuentasEncontradas.SelectedIndexChanged

    End Sub

    Private Sub lsvCuentasEncontradas_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvCuentasEncontradas.MouseDoubleClick
        If lsvCuentasEncontradas.SelectedItems.Count > 0 Then
            Me.pcCuentas.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click
        Me.Cursor = Cursors.WaitCursor
        If ListaAsientos.Count > 0 Then
            For Each i In ListaAsientos

                Dim conteoMov = ListaMovimiento.Where(Function(o) o.idAsiento = i.idAsiento).Count

                If conteoMov > 0 Then

                    For Each mov In ListaMovimiento

                        'validar si tiene costeo de entreewdas y salidas de caja

                        If mov.tipoModulo = "OES" Then

                            If Mid(mov.cuenta, 1, 2) = "62" Or Mid(mov.cuenta, 1, 2) = "63" Or
                                Mid(mov.cuenta, 1, 2) = "64" Or Mid(mov.cuenta, 1, 2) = "65" Or
                                Mid(mov.cuenta, 1, 2) = "66" Or Mid(mov.cuenta, 1, 2) = "67" Or
                                Mid(mov.cuenta, 1, 2) = "68" Then

                                If Not IsNothing(mov.costeo) Then

                                Else
                                    MessageBoxAdv.Show(i.Descripcion & vbCrLf & vbCrLf & "Debe ser costeado.", "Antención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                    Me.Cursor = Cursors.Arrow
                                    Exit Sub
                                End If
                            End If


                        End If

                            'dfgdfgdfgdfg
                            If i.idAsiento = mov.idAsiento Then

                            Dim sumaDebe As Decimal = 0
                            sumaDebe = ListaMovimiento.Where(Function(o) o.idAsiento = i.idAsiento And o.tipo = "D").Sum(Function(o) o.monto)

                            If sumaDebe <= 0 Then
                                MessageBoxAdv.Show(i.Descripcion & vbCrLf & vbCrLf & "El monto de la columna del debe es cero, verifique.", "Antención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                Me.Cursor = Cursors.Arrow
                                Exit Sub
                            End If


                            Dim sumaHaber As Decimal = 0
                            sumaHaber = ListaMovimiento.Where(Function(o) o.idAsiento = i.idAsiento And o.tipo = "H").Sum(Function(o) o.monto)


                            If sumaHaber <= 0 Then
                                MessageBoxAdv.Show(i.Descripcion & vbCrLf & vbCrLf & "El monto de la columna del haber es cero, verifique.", "Antención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                Me.Cursor = Cursors.Arrow
                                Exit Sub
                            End If

                            If sumaDebe <> sumaHaber Then
                                MessageBoxAdv.Show("El " & i.Descripcion & vbCrLf & vbCrLf & "Deben cuadrar los asientos del debe y haber.", "Antención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                Me.Cursor = Cursors.Arrow
                                Exit Sub
                            End If

                            i.movimiento.Add(mov)
                        End If
                    Next
                Else
                    MessageBoxAdv.Show(i.Descripcion & vbCrLf & vbCrLf & "El asiento no contiene movimientos!", "Antención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If

            Next
        Else
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If

        GrabarListaAsientos()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub frmContabilidadAsientosPorConciliar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListaAsientos = New List(Of asiento)
        ListaMovimiento = New List(Of movimiento)
        dgvMovimientos.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        If Not IsNothing(dgvMovimientos.Table.CurrentRecord) Then


            Dim cuentaP As String = dgvMovimientos.Table.CurrentRecord.GetValue("cuenta")

            If Mid(cuentaP, 1, 2) = "62" Or Mid(cuentaP, 1, 2) = "63" Or
                                Mid(cuentaP, 1, 2) = "64" Or Mid(cuentaP, 1, 2) = "65" Or
                                Mid(cuentaP, 1, 2) = "66" Or Mid(cuentaP, 1, 2) = "67" Or
                                Mid(cuentaP, 1, 2) = "68" Then

                Dim f As New frmSelectCosto()
                f.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
                f.StartPosition = FormStartPosition.CenterParent
                f.WindowState = FormWindowState.Normal
                f.ShowDialog()
                If Not IsNothing(f.Tag) Then
                    Dim c = CType(f.Tag, SeleccionCosto)

                    Me.dgvMovimientos.Table.CurrentRecord.SetValue("costeo", c.Entregable)
                    Me.dgvMovimientos.Table.CurrentRecord.SetValue("idCosto", c.idEntregable)
                    Me.dgvMovimientos.Table.CurrentRecord.SetValue("tipoCosto", "PC")

                End If

            Else
                MessageBox.Show("Solo se puede costear cuentas de la 62 al 68!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Else
            MessageBox.Show("No ha seleccionado los items!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If
    End Sub

    Private Sub dgvMovimientos_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvMovimientos.TableControlCellClick

    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click

    End Sub
#End Region
End Class