Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid


Public Class frmVentaTicketDirecta
    Inherits frmMaster
    Dim time As Integer = 0
    Dim statusForm As New frmMensajeCodigoVenta
    Dim UserControl1 As New ucConfiguracion
    Dim UcConfigCaja As New ucConfiguracionCaja
    Dim toolTip As Popup
    Dim toolTipCaja As Popup
    Public ManipulacionEstado As String
    Private CheckBoxClicked As Boolean = False
    Public Property ListaAsientonTransito As New List(Of asiento)
    Public fecha As DateTime
    Public Property txtComprobante As String
    '  Public Property IIf(rbBoleta.Checked = True, "12.1", "12.2") As String
    Public Property NumeroComprobante() As String
    Public Property txtSerie() As String
    Dim colorx As GridMetroColors
    Dim ReferenciaFondoMN, ReferenciaFondoME As Decimal

    Public Property SerieTicket() As String
    Public Property NumeroTicket() As String
    Public Property TipoDocVenta() As String

    Public Property lblIdDocumento() As Integer
#Region "Variables DetalleCompra"
    Public Property nudBase4 As Decimal = 0
    Public Property nudBase1 As Decimal = 0
    Public Property nudBase2 As Decimal = 0
    Public Property nudBase3 As Decimal = 0

    Public Property nudMontoIgv1 As Decimal = 0
    Public Property nudMontoIgv2 As Decimal = 0
    Public Property nudMontoIgv3 As Decimal = 0

    Public Property nudBaseus4 As Decimal = 0
    Public Property nudBaseus1 As Decimal = 0
    Public Property nudBaseus2 As Decimal = 0
    Public Property nudBaseus3 As Decimal = 0

    Public Property nudMontoIgvus1 As Decimal = 0
    Public Property nudMontoIgvus2 As Decimal = 0
    Public Property nudMontoIgvus3 As Decimal = 0

    Public Property nudIsc1 As Decimal = 0
    Public Property nudIsc2 As Decimal = 0
    Public Property nudIsc3 As Decimal = 0
    Public Property nudIscus1 As Decimal = 0
    Public Property nudIscus2 As Decimal = 0
    Public Property nudIscus3 As Decimal = 0

    Public Property nudOtrosTributosus1 As Decimal = 0
    Public Property nudOtrosTributosus2 As Decimal = 0
    Public Property nudOtrosTributosus3 As Decimal = 0
    Public Property nudOtrosTributosus4 As Decimal = 0

    Public Property nudOtrosTributos1 As Decimal = 0
    Public Property nudOtrosTributos2 As Decimal = 0
    Public Property nudOtrosTributos3 As Decimal = 0
    Public Property nudOtrosTributos4 As Decimal = 0

    ' Public Property IIf(rbBoleta.Checked = True, "12.1", "12.2")Caja As Integer
    Public Property txtComprobanteCaja As String
    Public Property txtNumCaja As String
    Public Property txtIdEstablecimientoCaja As Integer
    Public Property txtEstablecimientoCaja As String
    Public Property txtIdCaja As Integer
    Public Property txtCaja As String
    Public Property txtCuentaEF As String

    '   Public Property GlosaCompra As String = Nothing
#End Region


#Region "PROVEEDOR"
    Public Sub InsertProveedor()
        Dim objCliente As New entidad
        Dim entidadSA As New entidadSA
        Try
            'Se asigna cada uno de los datos registrados
            objCliente.idEmpresa = Gempresas.IdEmpresaRuc
            objCliente.tipoEntidad = TIPO_ENTIDAD.CLIENTE

            If btnRuc.Checked = True Then
                objCliente.tipoDoc = "6"
            ElseIf btnDni.Checked = True Then
                objCliente.tipoDoc = "1"
            ElseIf btnPassport.Checked = True Then
                objCliente.tipoDoc = "7"
            ElseIf btnCarnetEx.Checked = True Then
                objCliente.tipoDoc = "4"
            End If
            objCliente.nrodoc = txtDocProveedor.Text.Trim

            If rbNatural.Checked = True Then
                objCliente.appat = txtApePat.Text.Trim
                objCliente.nombre1 = txtNomProv.Text.Trim
                objCliente.nombreCompleto = objCliente.appat & ", " & objCliente.nombre1
                objCliente.tipoPersona = "N"
            ElseIf rbJuridico.Checked = True Then
                objCliente.nombre = txtNomProv.Text.Trim
                objCliente.nombreCompleto = txtNomProv.Text.Trim
                objCliente.tipoPersona = "J"
            End If
            objCliente.cuentaAsiento = "1213"
            objCliente.estado = "A"
            objCliente.usuarioModificacion = "NN"
            objCliente.fechaModificacion = DateTime.Now

            Dim codx As Integer = entidadSA.GrabarEntidad(objCliente)
            'lblEstado.Text = "Entidad registrada:" & vbCrLf & "Tipo: " & objCliente.tipoEntidad & vbCrLf & "Nombre: " & objCliente.nombreCompleto
            'lblEstado.Image = My.Resources.ok4

            Dim n As New ListViewItem(codx)
            n.SubItems.Add(objCliente.nombreCompleto)
            n.SubItems.Add(objCliente.cuentaAsiento)
            n.SubItems.Add(objCliente.nrodoc)
            lsvProveedor.Items.Add(n)

            txtProveedor.Tag = codx
            txtProveedor.Text = objCliente.nombreCompleto
            txtRuc.Text = objCliente.nrodoc
            txtCuenta.Text = objCliente.cuentaAsiento
        Catch ex As Exception
            'Manejo de errores
            MsgBox("No se pudo grabar el cliente." & vbCrLf & ex.Message)
        End Try
    End Sub
#End Region


    Public Sub CargarEntidadesXtipo(strTipo As String, strBusqueda As String)
        Dim entidadSA As New entidadSA
        Try

            lsvProveedor.Items.Clear()
            For Each i As entidad In entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, TIPO_ENTIDAD.CLIENTE, strBusqueda)
                Dim n As New ListViewItem(i.idEntidad)
                n.SubItems.Add(i.nombreCompleto)
                n.SubItems.Add(i.cuentaAsiento)
                n.SubItems.Add(i.nrodoc)
                lsvProveedor.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub



#Region "TIMER"
    Sub parpadeo()
        Static parpadear As Boolean

        'If Not parpadear Then
        '    lblEstado.ForeColor = lblEstado.BackColor
        '    lblEstado.BackColor = Color.Yellow
        'Else
        '    lblEstado.ForeColor = SystemColors.WindowText
        'End If

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
            'lblEstado.ForeColor = Color.Navy
            'lblEstado.BackColor = Color.Transparent
            PanelError.Visible = False
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
    Sub GridCFG()
        Me.gridGroupingControl1.TableOptions.ShowRowHeader = False
        Me.gridGroupingControl1.TopLevelGroupOptions.ShowCaption = False


        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        Me.gridGroupingControl1.SetMetroStyle(colorx)
        Me.gridGroupingControl1.BorderStyle = System.Windows.Forms.BorderStyle.None

        'Me.gridGroupingControl1.BrowseOnly = true
        'Me.gridGroupingControl1.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        'Me.gridGroupingControl1.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        'Me.gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One
        Me.gridGroupingControl1.TableOptions.SelectionBackColor = Color.Gray
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.Format = "MMM dd yyyy"
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.Hide
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).HeaderText = "Date"
        'Me.gridGroupingControl1.TableDescriptor.Columns(1).HeaderText = "Category"
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.Currency
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromArgb(168, 178, 189)
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.TextAlign = GridTextAlign.Left

        'this.gridGroupingControl1.TableDescriptor.Columns["Amount"].Width = (this.tableLayoutPanel3.Width / 5) - 50;
        Me.gridGroupingControl1.AllowProportionalColumnSizing = False
        Me.gridGroupingControl1.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        Me.gridGroupingControl1.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center


        Me.gridGroupingControl1.Table.DefaultColumnHeaderRowHeight = 25
        Me.gridGroupingControl1.Table.DefaultRecordRowHeight = 20
        Me.gridGroupingControl1.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        Me.WindowState = FormWindowState.Maximized
        GConfiguracion = New GConfiguracionModulo
        'GFichaUsuarios = New GFichaUsuario
        QGlobalColorSchemeManager1.Global.CurrentTheme = Qios.DevSuite.Components.QColorScheme.LunaBlueThemeName
        ObtenerAlmacenes()
        Docking()
        GridCFG()
        configuracionModuloV2(Gempresas.IdEmpresaRuc, "VT2", Me.Text, GEstableciento.IdEstablecimiento)
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        lblPerido.Text = "Período: " & PeriodoGeneral 'String.Format("{0:00}", Convert.ToInt32(cfecha.Month)) & "/" & PeriodoGeneral
        ObtenerListaControlesLoad()
        txtAlmacen.Text = TmpNombreAlmacen
        txtAlmacen.Tag = TmpIdAlmacen


        txtFechaComprobante.Select()

    End Sub

#Region "Eventos DGV"
    Private Sub Validar_Numeros(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        Dim Celda As DataGridViewCell = Me.dgvNuevoDoc.CurrentCell()

        If Celda.ColumnIndex = 5 Or Celda.ColumnIndex = 10 Or Celda.ColumnIndex = 11 Then

            If e.KeyChar = "."c Or e.KeyChar = ","c Then

                If InStr(Celda.EditedFormattedValue.ToString, ".", CompareMethod.Text) > 0 Then

                    e.Handled = True
                Else

                    e.Handled = False
                End If
            Else

                If Len(Trim(Celda.EditedFormattedValue.ToString)) > 0 Then

                    If Char.IsNumber(e.KeyChar) Or e.KeyChar = Convert.ToChar(8) Then

                        e.Handled = False
                    Else

                        e.Handled = True
                    End If
                Else

                    If e.KeyChar = "0"c Then

                        e.Handled = True
                    Else

                        If Char.IsNumber(e.KeyChar) Or e.KeyChar = Convert.ToChar(8) Then

                            e.Handled = False
                        Else

                            e.Handled = True
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Public Sub TotalesCabeceras()
        Dim cTotalCosto As Decimal = 0
        Dim cTotalCostoME As Decimal = 0


        Dim cTotalMN As Decimal = 0
        Dim cTotalME As Decimal = 0

        Dim cTotalBI As Decimal = 0
        Dim cTotalBI_ME As Decimal = 0

        Dim cTotalIGV As Decimal = 0
        Dim cTotalIGV_ME As Decimal = 0

        Dim cTotalIsc As Decimal = 0
        Dim cTotalIsc_ME As Decimal = 0

        Dim cTotalOTC As Decimal = 0
        Dim cTotalOTC_ME As Decimal = 0
        For Each i As DataGridViewRow In dgvNuevoDoc.Rows
            If i.Cells(22).Value() <> Helios.Cont.Business.Entity.BaseBE.EntityAction.DELETE Then
                cTotalMN += CDec(i.Cells(10).Value)
                cTotalME += CDec(i.Cells(11).Value)

                cTotalBI += CDec(i.Cells(14).Value)
                cTotalBI_ME += CDec(i.Cells(18).Value)

                cTotalIGV += CDec(i.Cells(16).Value)
                cTotalIGV_ME += CDec(i.Cells(20).Value)

                cTotalIsc += CDec(i.Cells(15).Value)
                cTotalIsc_ME += CDec(i.Cells(19).Value)

                cTotalOTC += CDec(i.Cells(17).Value)
                cTotalOTC_ME += CDec(i.Cells(21).Value)

                cTotalCosto += CDec(i.Cells(33).Value)
                cTotalCostoME += CDec(i.Cells(34).Value)
            End If
        Next

        txtTotalBImn.Text = cTotalBI.ToString("N2")
        txtTotalBIme.Text = cTotalBI_ME.ToString("N2")



        txtMontoIGVmn.Text = cTotalIGV.ToString("N2")
        txtMontoIGVme.Text = cTotalIGV_ME.ToString("N2")



        Select Case txtComprobante
            Case "02", "03"
                txtTotalPedidomn.Text = cTotalMN   'cTotalMN.ToString("N2")
                txtTotalPedidome.Text = cTotalME   'cTotalME.ToString("N2")
                txtCostomn.Text = cTotalCosto
                txtCostome.Text = cTotalCostoME
            Case "08"
                'Instrucciones
            Case Else
                txtTotalPedidomn.Text = cTotalBI + cTotalIGV   'cTotalMN.ToString("N2")
                txtTotalPedidome.Text = cTotalBI_ME + cTotalIGV_ME  'cTotalME.ToString("N2")
                txtCostomn.Text = cTotalCosto
                txtCostome.Text = cTotalCostoME
        End Select

    End Sub

    Public Sub totales_xx()
        Dim i As Integer

        Dim bi1, bi2 As Decimal ' igv, IGVUS As Decimal ' totalp As Decimal , totalbase3, totalbase4,
        Dim bi1me, bi2me As Decimal 'tus3, tus4 
        Dim totalIgv1 As Decimal = 0
        Dim totalIgv1_ME As Decimal = 0
        Dim totalIgv2 As Decimal = 0
        Dim totalIgv2_ME As Decimal = 0


        Dim NUDVALUE As Decimal = Math.Round((txtIgv.Value / 100) + 1, 2)
        For i = 0 To dgvNuevoDoc.Rows.Count - 1
            'total += carrito.Rows(i)(5)
            If dgvNuevoDoc.Rows(i).Cells(22).Value() <> Helios.Cont.Business.Entity.BaseBE.EntityAction.DELETE Then
                If Not dgvNuevoDoc.Rows(i).DefaultCellStyle.BackColor = Color.FromArgb(209, 227, 254) Then
                    If dgvNuevoDoc.Rows(i).Cells(1).Value() = "1" Then

                        bi1 += dgvNuevoDoc.Rows(i).Cells(14).Value() ' total base 01 soles
                        bi1me += dgvNuevoDoc.Rows(i).Cells(18).Value() ' total base 01 dolares
                        totalIgv1 += dgvNuevoDoc.Rows(i).Cells(16).Value()
                        totalIgv1_ME += dgvNuevoDoc.Rows(i).Cells(20).Value()

                    ElseIf dgvNuevoDoc.Rows(i).Cells(1).Value() = "2" Then

                        bi2 += dgvNuevoDoc.Rows(i).Cells(14).Value()
                        bi2me += dgvNuevoDoc.Rows(i).Cells(18).Value() ' total base 01
                        totalIgv2 += dgvNuevoDoc.Rows(i).Cells(16).Value()
                        totalIgv2_ME += dgvNuevoDoc.Rows(i).Cells(20).Value()

                    End If
                End If
            End If

        Next
        nudBase1 = bi1.ToString("N2")
        nudBaseus1 = bi1me.ToString("N2")
        nudBase2 = bi2.ToString("N2")
        nudBaseus2 = bi2me.ToString("N2")

        nudMontoIgv1 = totalIgv1.ToString("N2")
        nudMontoIgvus1 = totalIgv1_ME.ToString("N2")
        nudMontoIgv2 = totalIgv2.ToString("N2")
        nudMontoIgvus2 = totalIgv2_ME.ToString("N2")

    End Sub

    Private Sub CellEndEditRefresh()
        '**************************************************************
        If dgvNuevoDoc.Rows.Count > 0 Then

            For Each i As DataGridViewRow In dgvNuevoDoc.Rows
                If i.Cells(22).Value <> Helios.Cont.Business.Entity.BaseBE.EntityAction.DELETE Then
                    If txtTipoCambio.Value > 0 Then
                        'DECLARANDO VARIABLES
                        Dim colPrecUnitAlmacen As Decimal = 0 '
                        Dim colPrecUnitUSAlmacen As Decimal = 0 '

                        colPrecUnitAlmacen = i.Cells(6).Value '
                        colPrecUnitUSAlmacen = i.Cells(28).Value '


                        Dim colPrecUnit As Decimal = 0 '
                        Dim colPrecUnitUSD As Decimal = 0 '
                        Dim colDestinoGravado As Decimal = 0 '

                        colPrecUnit = i.Cells(8).Value '
                        colPrecUnitUSD = i.Cells(9).Value '
                        colDestinoGravado = i.Cells(1).Value '

                        Dim colCantidad As Decimal = i.Cells(5).Value '
                        Dim colCantidadDisponible As Decimal = i.Cells(7).Value '

                        Dim colBI As Decimal = 0
                        Dim colBI_ME As Decimal = 0
                        Dim colIGV_ME As Decimal = 0
                        Dim colIGV As Decimal = 0
                        Dim colMN As Decimal = Math.Round(colCantidad * colPrecUnit, 2)
                        Dim colME As Decimal = Math.Round(colCantidad * colPrecUnitUSD, 2)


                        Dim colCostoMN As Decimal = Math.Round(colCantidad * colPrecUnitAlmacen, 2)
                        Dim colCostoME As Decimal = Math.Round(colCantidad * colPrecUnitUSAlmacen, 2)

                        If colCantidad > 0 AndAlso colMN > 0 Then

                            colBI = Math.Round(colMN / 1.18, 2)
                            colBI_ME = Math.Round(colME / 1.18, 2)
                            colIGV = Math.Round((colMN / 1.18) * 0.18, 2) ' Math.Round(colBI * 0.18, 2)
                            colIGV_ME = Math.Round((colME / 1.18) * 0.18, 2) ' Math.Round(colBI_ME * 0.18, 2)

                        Else
                            colBI = 0
                            colBI_ME = 0
                            colIGV = 0
                            colIGV_ME = 0
                        End If

                        If colCantidad > colCantidadDisponible Then
                            MsgBox("Debe ingresar un monto, " & vbCrLf & "que no supere la cantidad disponible.", MsgBoxStyle.Information, "Atención!")
                            i.Cells(5).Value = 0
                            Exit Sub
                        Else
                            i.Cells(5).Value = colCantidad.ToString("N2")
                        End If

                        Dim valor As Decimal = 0
                        Dim NUDIGV_VALUE As Decimal = 0
                        '  If IsNothing(cboMoneda.SelectedValue) Then Exit Sub
                        If cboMoneda.SelectedValue = 1 Then
                            Select Case colDestinoGravado
                                Case 1
                                    NUDIGV_VALUE = Math.Round((txtIgv.Value / 100) + 1, 2)
                                    i.Cells(8).Value() = colPrecUnit.ToString("N2") 'prec unit usd
                                    i.Cells(9).Value() = colPrecUnitUSD.ToString("N2") 'prec unit usd

                                    i.Cells(10).Value() = colMN.ToString("N2")
                                    i.Cells(11).Value() = colME.ToString("N2") ' MONTO TOTAL DOLARES
                                    i.Cells(14).Value() = colBI.ToString("N2") ' monto para el kardex
                                    i.Cells(16).Value() = colIGV.ToString("N2") ' monto igv del item
                                    i.Cells(18).Value() = colBI_ME.ToString("N2")  ' monto para el kardex USD
                                    i.Cells(20).Value() = colIGV_ME.ToString("N2")   ' monto para el kardex USD

                                    i.Cells(33).Value() = colCostoMN.ToString("N2")
                                    i.Cells(34).Value() = colCostoME.ToString("N2")

                                Case 2

                                    NUDIGV_VALUE = "0.00" 'Math.Round((nudIgv.Value / 100) + 1, 2)

                                    i.Cells(8).Value() = colPrecUnit.ToString("N2") 'prec unit usd
                                    i.Cells(9).Value() = colPrecUnitUSD.ToString("N2") 'prec unit usd

                                    i.Cells(10).Value() = colMN.ToString("N2")
                                    i.Cells(11).Value() = colME.ToString("N2") ' MONTO TOTAL DOLARES
                                    i.Cells(14).Value() = colMN.ToString("N2")
                                    i.Cells(16).Value() = "0.00" ' monto igv del item
                                    i.Cells(18).Value() = colME.ToString("N2")  ' monto para el kardex USD
                                    i.Cells(20).Value() = "0.00"

                                    i.Cells(33).Value() = colCostoMN.ToString("N2")
                                    i.Cells(34).Value() = colCostoME.ToString("N2")

                            End Select
                            totales_xx()
                            TotalesCabeceras()
                            ReferenciaFondoMN = CDec(txtTotalPedidomn.Text)
                            ReferenciaFondoME = CDec(txtTotalPedidome.Text)

                        Else
                            'IMPLEMENTAR CODIGO PARA MONEDA EXTRANJERA
                        End If

                    Else
                        MsgBox("Ingrese un tipo de cambio mayor a cero", MsgBoxStyle.Information, "Atención!")
                        txtTipoCambio.Focus()
                        txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
                    End If
                End If

            Next
        End If

    End Sub
#End Region

#Region "VALIDA USUARIO CAJA"
    'Public Function TieneCuentaFinanciera(Optional intIdDocumento As Integer = Nothing) As Boolean
    '    Dim efSA As New EstadosFinancierosSA
    '    Dim ef As New estadosFinancieros
    '    Dim estableSA As New establecimientoSA

    '    GFichaUsuarios = New GFichaUsuario
    '    Select Case ManipulacionEstado
    '        Case ENTITY_ACTIONS.INSERT

    '            If IsNothing(GFichaUsuarios.NombrePersona) Then
    '                With frmFichaUsuarioCaja
    '                    ModuloAppx = ModuloSistema.CAJA
    '                    .lblNivel.Text = "Caja"
    '                    .lblEstadoCaja.Visible = True
    '                    .GroupBox1.Visible = True
    '                    .GroupBox2.Visible = True
    '                    .GroupBox4.Visible = True
    '                    .cboMoneda.Visible = True
    '                    .Timer1.Enabled = True
    '                    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
    '                    .StartPosition = FormStartPosition.CenterParent
    '                    .ShowDialog()
    '                    If IsNothing(GFichaUsuarios.NombrePersona) Then
    '                        Return False
    '                    Else
    '                        Return True
    '                    End If
    '                End With
    '            End If
    '        Case ENTITY_ACTIONS.UPDATE
    '            With frmFichaUsuarioCaja
    '                ModuloAppx = ModuloSistema.CAJA
    '                .lblNivel.Text = "Caja"
    '                .lblEstadoCaja.Visible = True
    '                .GroupBox1.Visible = True
    '                .GroupBox2.Visible = True
    '                .GroupBox4.Visible = True
    '                .cboMoneda.Visible = True
    '                .Timer1.Enabled = False
    '                .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
    '                .StartPosition = FormStartPosition.CenterParent
    '                .UbicarUsuarioCaja(intIdDocumento, "VENTA")
    '                .ShowDialog()
    '                If IsNothing(GFichaUsuarios.NombrePersona) Then
    '                    Return False
    '                Else
    '                    Return True
    '                End If
    '            End With
    '    End Select
    '    Return True

    'End Function
#End Region

#Region "CANASTA VENTA"
    Private Sub ObtenerCanastaVentaFiltro(IntIdAlmacen As Integer, strTipoExistencia As String, strProducto As String)
        Dim CanastaSA As New TotalesAlmacenSA
        Dim listaSA As New ListadoPrecioSA
        Dim lista As New listadoPrecios

        Dim dt As New DataTable()
        Try
            dt.Columns.Add("destino", GetType(String))
            dt.Columns.Add("idItem", GetType(Integer))
            dt.Columns.Add("descripcion", GetType(String))
            dt.Columns.Add("unidad", GetType(String))
            dt.Columns.Add("idPres", GetType(String))
            dt.Columns.Add("presentacion", GetType(String))
            dt.Columns.Add("cantidad", GetType(Decimal))
            dt.Columns.Add("puKardexmn", GetType(Decimal))
            dt.Columns.Add("puKardexme", GetType(Decimal))
            dt.Columns.Add("importeMn", GetType(Decimal))
            dt.Columns.Add("importeME", GetType(Decimal))
            dt.Columns.Add("pvmenor", GetType(Decimal))
            dt.Columns.Add("pvmenorme", GetType(Decimal))
            dt.Columns.Add("pvmayor", GetType(Decimal))
            dt.Columns.Add("pvmayorme", GetType(Decimal))
            dt.Columns.Add("pvGmayor", GetType(Decimal))
            dt.Columns.Add("pvGmayorme", GetType(Decimal))

            'ListView1.Items.Clear()
            Dim cprecioVentaFinalMenorMN As Decimal = 0
            Dim cprecioVentaFinalMenorME As Decimal = 0
            Dim cmontoDsctounitMenorMN As Decimal = 0
            Dim cmontoDsctounitMenorME As Decimal = 0
            Dim cprecioVentaFinalMayorMN As Decimal = 0
            Dim cprecioVentaFinalGMayorMN As Decimal = 0
            Dim cprecioVentaFinalMayorME As Decimal = 0
            Dim cprecioVentaFinalGMayorME As Decimal = 0
            Dim cdetalleMenor As String = Nothing
            Dim cdetalleMayor As String = Nothing
            Dim cdetalleGMayor As String = Nothing
            For Each i As totalesAlmacen In CanastaSA.ObtenerCanastaDeVentaPorProducto(IntIdAlmacen, strTipoExistencia, strProducto)
                If CDec(i.cantidad) > 0 Then
                    Dim valPrecUnitario As Decimal = Math.Round(CDec(i.importeSoles) / CDec(i.cantidad), 2)
                    Dim valPrecUnitarioUS As Decimal = Math.Round(CDec(i.importeDolares) / CDec(i.cantidad), 2)

                    lista = listaSA.PrecioVentaXitemXiva(i.idAlmacen, i.idItem, "SIVA") ' no funciona aqui

                    If Not IsNothing(lista) Then
                        With lista 'listaSA.UbicarVentaPorItem(i.idAlmacen, i.idItem)
                            cprecioVentaFinalMenorMN = IIf(IsNothing(.pvmenor), 0, .pvmenor)
                            cprecioVentaFinalMenorME = IIf(IsNothing(.pvmenorme), 0, .pvmenorme)
                            cmontoDsctounitMenorMN = 0 'IIf(IsNothing(.montoDsctounitMenorMN), 0, .montoDsctounitMenorMN)
                            cmontoDsctounitMenorME = 0 ' IIf(IsNothing(.montoDsctounitMenorME), 0, .montoDsctounitMenorME)
                            cprecioVentaFinalMayorMN = IIf(IsNothing(.pvmayor), 0, .pvmayor)
                            cprecioVentaFinalGMayorMN = IIf(IsNothing(.pvgranmayor), 0, .pvgranmayor)
                            cprecioVentaFinalMayorME = IIf(IsNothing(.pvmayorme), 0, .pvmayorme)
                            cprecioVentaFinalGMayorME = IIf(IsNothing(.pvgranmayorme), 0, .pvgranmayorme)

                        End With
                    Else
                        lblEstado.Text = "EL producto no contiene una configuración de precio.!"
                        lblEstado.Image = My.Resources.warning2
                    End If

                    Dim dr As DataRow = dt.NewRow()
                    dr(0) = i.origenRecaudo
                    dr(1) = i.idItem
                    dr(2) = i.descripcion
                    dr(3) = i.unidadMedida
                    dr(4) = i.Presentacion
                    dr(5) = i.NombrePresentacion
                    dr(6) = i.cantidad
                    dr(7) = valPrecUnitario
                    dr(8) = valPrecUnitarioUS
                    dr(9) = i.importeSoles
                    dr(10) = i.importeDolares

                    dr(11) = cprecioVentaFinalMenorMN
                    dr(12) = cprecioVentaFinalMenorME
                    dr(13) = cprecioVentaFinalMayorMN
                    dr(14) = cprecioVentaFinalMayorME
                    dr(15) = cprecioVentaFinalGMayorMN
                    dr(16) = cprecioVentaFinalGMayorME
                    dt.Rows.Add(dr)

                End If

            Next
            gridGroupingControl1.DataSource = dt
            gridGroupingControl1.TableDescriptor.Relations.Clear()
            gridGroupingControl1.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
            gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One
            'dgvEntrada.Appearance.AnyRecordFieldCell.Enabled = False
            gridGroupingControl1.GroupDropPanel.Visible = True
            gridGroupingControl1.TableDescriptor.GroupedColumns.Clear()
        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try

    End Sub

    Function SoloNumeros(ByVal Keyascii As Short) As Short
        If InStr("1234567890.", Chr(Keyascii)) = 0 Then
            SoloNumeros = 0
        Else
            SoloNumeros = Keyascii
        End If
        Select Case Keyascii
            Case 8
                SoloNumeros = Keyascii
            Case 13
                SoloNumeros = Keyascii
        End Select
    End Function
    Sub calculos()
        If rbMenor.Checked = True Then
            If lblMenor.Text.Trim.Length > 0 Then

                lblTotalMN.Text = Math.Round(CDec(txtCantidad.Text) * CDec(lblMenor.Value), 2)

            End If
            If lblMenorME.Text.Trim.Length > 0 Then

                lblTotalME.Text = Math.Round(CDec(txtCantidad.Text) * CDec(lblMenorME.Value), 2)

            End If
        End If
        If rbMayor.Checked = True Then

            If lblMayor.Text.Trim.Length > 0 Then

                lblTotalMN.Text = Math.Round(CDec(txtCantidad.Text) * CDec(lblMayor.Value), 2)

            End If

            If lblMayorME.Text.Trim.Length > 0 Then

                lblTotalME.Text = Math.Round(CDec(txtCantidad.Text) * CDec(lblMayorME.Value), 2)

            End If
        End If
        If rbgmayor.Checked = True Then

            If lblGMayor.Text.Trim.Length > 0 Then

                lblTotalMN.Text = Math.Round(CDec(txtCantidad.Text) * CDec(lblGMayor.Value), 2)

            End If

            If lblGMayorME.Text.Trim.Length > 0 Then

                lblTotalME.Text = Math.Round(CDec(txtCantidad.Text) * CDec(lblGMayorME.Value), 2)

            End If
        End If
    End Sub
#End Region

#Region "Métodos"
    Private Function GlosaVenta() As String
        Return String.Concat("Por ventas con ticket directa", Space(1), "según/ ", Space(1), GConfiguracion.NombreComprobante, Space(1), "Nro.", Space(1), GConfiguracion.Serie, "-", ", de Fecha:", Space(1), txtFechaComprobante.Value)
    End Function

    Enum Sys
        Inicio
        Proceso
    End Enum

    Sub InfoConfiguracion(n As Sys)
        If Not IsNothing(GConfiguracion) Then
            If Not IsNothing(GConfiguracion.NomModulo) Then
                UserControl1.lblCodigo.Text = "VT2"
                UserControl1.lblModulo.Text = Me.Text
                UserControl1.lblConfiguracion.Text = IIf(GConfiguracion.TipoConfiguracion = "M", "MANUAL", "PROGRAMADA")
                UserControl1.lblComprobante.Text = GConfiguracion.NombreComprobante
                UserControl1.lblSerie.Text = GConfiguracion.Serie
                UserControl1.lblNumImpresiones.Text = IIf(IsNothing(GConfiguracion.ValorActual), 0, GConfiguracion.ValorActual)
                UserControl1.lblAlmacen.Text = GConfiguracion.NombreAlmacen
                UserControl1.lblCaja.Text = GConfiguracion.NomCaja
                ' position the tooltip with its stem towards the right end of the button
                If n = Sys.Inicio Then

                ElseIf n = Sys.Proceso Then
                    toolTip.Show(btnConfiguracion)
                End If

            End If
        End If
    End Sub

    Sub InfoConfiguracionCaja(n As Sys)

        If Not IsNothing(GFichaUsuarios) Then
            If Not IsNothing(GFichaUsuarios.NombrePersona) Then


                UcConfigCaja.lblidPersona.Text = GFichaUsuarios.IdPersona
                UcConfigCaja.lblEncargado.Text = GFichaUsuarios.NombrePersona
                UcConfigCaja.lblCajaHabilitada.Text = GFichaUsuarios.NomCajaDestinb
                UcConfigCaja.lblMoneda.Text = GFichaUsuarios.Moneda
                ' position the tooltip with its stem towards the right end of the button
                If n = Sys.Inicio Then

                ElseIf n = Sys.Proceso Then
                    toolTipCaja.Show(btnConfigCaja)
                End If

            End If
        End If
    End Sub

    Public Sub ObtenerListaControlesLoad()
        Dim tablaSA As New tablaDetalleSA

        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("name")

        dt.Rows.Add(1, "NACIONAL")
        dt.Rows.Add(2, "EXTRANJERA")

        cboMoneda.ValueMember = "id"
        cboMoneda.DisplayMember = "name"
        cboMoneda.DataSource = dt
        cboMoneda.SelectedIndex = 0



    End Sub

    'Public Sub configuracionModulo2(strIDEmpresa As String, strIdModulo As String, strNomModulo As String, intIdEstablecimiento As Integer)
    '    Dim moduloConfiguracionSA As New ModuloConfiguracionSA
    '    Dim moduloConfiguracion As New moduloConfiguracion
    '    Dim numeracionSA As New NumeracionBoletaSA
    '    Dim TablaSA As New tablaDetalleSA
    '    Dim almacenSA As New almacenSA
    '    Dim cajaSA As New EstadosFinancierosSA

    '    moduloConfiguracion = moduloConfiguracionSA.UbicarConfiguracionPorEmpresaModulo(strIdModulo, strIDEmpresa, intIdEstablecimiento)
    '    If Not IsNothing(moduloConfiguracion) Then
    '        With moduloConfiguracion
    '            GConfiguracion = New GConfiguracionModulo
    '            GConfiguracion.IdModulo = .idModulo
    '            GConfiguracion.NomModulo = strNomModulo
    '            GConfiguracion.TipoConfiguracion = .tipoConfiguracion
    '            Select Case .tipoConfiguracion
    '                Case "P"
    '                    With numeracionSA.GetUbicar_numeracionBoletasPorID(.configComprobante)
    '                        GConfiguracion.ConfigComprobante = .IdEnumeracion
    '                        GConfiguracion.TipoComprobante = .tipo
    '                        GConfiguracion.NombreComprobante = TablaSA.GetUbicarTablaID(10, .tipo).descripcion
    '                        GConfiguracion.Serie = .serie
    '                        GConfiguracion.ValorActual = .valorInicial
    '                        '    IIf(rbBoleta.Checked = True, "12.1", "12.2") = .tipo

    '                    End With
    '                Case "M"

    '            End Select
    '            If Not IsNothing(.configAlmacen) Then
    '                Dim estableSA As New establecimientoSA
    '                With almacenSA.GetUbicar_almacenPorID(.configAlmacen)

    '                End With
    '            End If
    '            If Not IsNothing(.ConfigentidadFinanciera) Then
    '                With cajaSA.GetUbicar_estadosFinancierosPorID(.ConfigentidadFinanciera)
    '                    GConfiguracion.IDCaja = .idestado
    '                    GConfiguracion.NomCaja = .descripcion
    '                    txtIdEstablecimientoCaja = .idEstablecimiento
    '                    txtCaja = .descripcion
    '                    txtIdCaja = .idestado
    '                End With
    '            End If

    '        End With
    '    Else
    '        lblEstado.Text = "Este módulo no contiene una configuración disponible, intentelo más tarde.!"

    '    End If
    'End Sub
    Private Sub Docking()
        Me.dockingManager1.DockControl(Me.PanelCanasta, Me, Syncfusion.Windows.Forms.Tools.DockingStyle.Right, 426)
        dockingManager1.DockControlInAutoHideMode(PanelCanasta, Syncfusion.Windows.Forms.Tools.DockingStyle.Right, 426)
        dockingClientPanel1.BringToFront()
        dockingManager1.MDIActivatedVisibility = True
        Me.dockingClientPanel1.AutoScroll = True
        Me.dockingClientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        dockingManager1.SetDockLabel(PanelCanasta, "Canasta de Existencias")
    End Sub

    Private Sub ObtenerAlmacenes()
        Dim almacenSA As New almacenSA
        Dim almacen As New List(Of almacen)

        almacen = almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
        lstAlmacen.ValueMember = "idAlmacen"
        lstAlmacen.DisplayMember = "descripcionAlmacen"
        lstAlmacen.DataSource = almacen
    End Sub
#End Region

#Region "Manipulación Data"
    Private Function ListaTotalesAlmacen() As List(Of totalesAlmacen)
        Dim objTotalesDet As New totalesAlmacen
        Dim ListaTotales As New List(Of totalesAlmacen)
        Dim almacenSA As New almacenSA
        For Each i As DataGridViewRow In dgvNuevoDoc.Rows
            If dgvNuevoDoc.Rows(i.Index).Cells(22).Value() <> Business.Entity.BaseBE.EntityAction.DELETE Then
                objTotalesDet = New totalesAlmacen
                objTotalesDet.Action = Business.Entity.BaseBE.EntityAction.INSERT
                objTotalesDet.SecuenciaDetalle = 0
                objTotalesDet.idEmpresa = Gempresas.IdEmpresaRuc
                objTotalesDet.Modulo = "N"
                objTotalesDet.idEstablecimiento = almacenSA.GetUbicar_almacenPorID(dgvNuevoDoc.Rows(i.Index).Cells(24).Value()).idEstablecimiento
                objTotalesDet.idAlmacen = dgvNuevoDoc.Rows(i.Index).Cells(24).Value()
                objTotalesDet.origenRecaudo = dgvNuevoDoc.Rows(i.Index).Cells(1).Value()
                objTotalesDet.tipoCambio = txtTipoCambio.Value
                objTotalesDet.tipoExistencia = dgvNuevoDoc.Rows(i.Index).Cells(23).Value()
                objTotalesDet.idItem = dgvNuevoDoc.Rows(i.Index).Cells(2).Value()
                objTotalesDet.descripcion = dgvNuevoDoc.Rows(i.Index).Cells(3).Value()
                objTotalesDet.idUnidad = dgvNuevoDoc.Rows(i.Index).Cells(4).Value()
                objTotalesDet.unidadMedida = Nothing
                objTotalesDet.cantidad = CType(dgvNuevoDoc.Rows(i.Index).Cells(5).Value() * -1, Decimal)
                objTotalesDet.precioUnitarioCompra = CType(dgvNuevoDoc.Rows(i.Index).Cells(8).Value(), Decimal)
                objTotalesDet.importeSoles = CType(dgvNuevoDoc.Rows(i.Index).Cells(33).Value() * -1, Decimal)
                objTotalesDet.importeDolares = CType(dgvNuevoDoc.Rows(i.Index).Cells(34).Value() * -1, Decimal)
                objTotalesDet.montoIsc = 0
                objTotalesDet.montoIscUS = 0
                objTotalesDet.Otros = 0
                objTotalesDet.OtrosUS = 0
                objTotalesDet.porcentajeUtilidad = 0
                objTotalesDet.importePorcentaje = 0
                objTotalesDet.importePorcentajeUS = 0
                objTotalesDet.precioVenta = 0
                objTotalesDet.precioVentaUS = 0
                objTotalesDet.usuarioActualizacion = GFichaUsuarios.IdCajaUsuario
                objTotalesDet.fechaActualizacion = Date.Now
                ListaTotales.Add(objTotalesDet)
            End If

        Next

        Return ListaTotales
    End Function

    Function ListaDeleteTotales() As List(Of totalesAlmacen)
        Dim objActividadDeleteEO As New totalesAlmacen
        Dim almacenSA As New almacenSA
        Dim ListaDeleteEO As New List(Of totalesAlmacen)
        For Each i As DataGridViewRow In dgvNuevoDoc.Rows
            If dgvNuevoDoc.Rows(i.Index).Cells(22).Value() = Business.Entity.BaseBE.EntityAction.UPDATE Or
              dgvNuevoDoc.Rows(i.Index).Cells(22).Value() = Business.Entity.BaseBE.EntityAction.DELETE Then

                objActividadDeleteEO = New totalesAlmacen
                objActividadDeleteEO.Action = Business.Entity.BaseBE.EntityAction.INSERT
                objActividadDeleteEO.TipoDoc = IIf(rbBoleta.Checked = True, "12.1", "12.2")
                objActividadDeleteEO.SecuenciaDetalle = dgvNuevoDoc.Rows(i.Index).Cells(0).Value()
                objActividadDeleteEO.idEmpresa = Gempresas.IdEmpresaRuc
                objActividadDeleteEO.Modulo = "N"
                objActividadDeleteEO.idEstablecimiento = dgvNuevoDoc.Rows(i.Index).Cells(26).Value()
                objActividadDeleteEO.idAlmacen = dgvNuevoDoc.Rows(i.Index).Cells(24).Value()
                objActividadDeleteEO.origenRecaudo = dgvNuevoDoc.Rows(i.Index).Cells(1).Value()
                objActividadDeleteEO.tipoCambio = "2.77"
                objActividadDeleteEO.tipoExistencia = dgvNuevoDoc.Rows(i.Index).Cells(23).Value()
                objActividadDeleteEO.idItem = dgvNuevoDoc.Rows(i.Index).Cells(2).Value()
                objActividadDeleteEO.descripcion = dgvNuevoDoc.Rows(i.Index).Cells(3).Value()
                ListaDeleteEO.Add(objActividadDeleteEO)
            End If
        Next

        Return ListaDeleteEO
    End Function

    Function ComprobanteCaja() As documento
        Dim nDocumentoCaja As New documento()
        Dim objCaja As New documentoCaja
        Dim objCajaDetalle As New documentoCajaDetalle
        Dim ListaCajaDetalle As New List(Of documentoCajaDetalle)

        nDocumentoCaja.idDocumento = lblIdDocumento
        nDocumentoCaja.idEmpresa = Gempresas.IdEmpresaRuc
        nDocumentoCaja.idCentroCosto = txtIdEstablecimientoCaja 'GEstableciento.IdEstablecimiento
        If IsNothing(GProyectos) Then
        Else
            nDocumentoCaja.idProyecto = GProyectos.IdProyectoActividad
        End If
        nDocumentoCaja.tipoDoc = "109"
        nDocumentoCaja.fechaProceso = fecha
        nDocumentoCaja.nroDoc = Nothing  ' IIf(rbEfectivo.Checked = True, Nothing, txtSerieComp.Text & "-" & txtNumeroComp.Text)
        nDocumentoCaja.idOrden = Nothing
        nDocumentoCaja.tipoOperacion = "01"
        nDocumentoCaja.usuarioActualizacion = GFichaUsuarios.IdCajaUsuario
        nDocumentoCaja.fechaActualizacion = DateTime.Now


        objCaja.idDocumento = 0
        objCaja.idEmpresa = Gempresas.IdEmpresaRuc
        objCaja.idEstablecimiento = txtIdEstablecimientoCaja ' GEstableciento.IdEstablecimiento
        objCaja.fechaProceso = fecha
        objCaja.fechaCobro = fecha
        objCaja.tipoMovimiento = TIPO_VENTA.PAGO.COBRADO
        objCaja.TipoDocumentoPago = "109"
        objCaja.codigoLibro = IIf(rbBoleta.Checked = True, "12.1", "12.2")
        objCaja.periodo = PeriodoGeneral
        objCaja.tipoDocPago = "109"
        objCaja.NumeroDocumento = Nothing ' IIf(rbEfectivo.Checked = True, Nothing, txtSerieComp.Text & "-" & txtNumeroComp.Text)
        objCaja.moneda = IIf(cboMoneda.SelectedValue = 1, "1", "2") ' txtCodMoneda.Text ' IIf(cboMoneda.Text = "MONEDA NACIONAL (SOLES)", "SOL", "USD")
        objCaja.tipoCambio = txtTipoCambio.Value
        objCaja.montoSoles = CDec(txtTotalPedidomn.Text)
        objCaja.montoUsd = CDec(txtTotalPedidome.Text)

        objCaja.glosa = GlosaVenta()
        objCaja.entregado = "SI"
        objCaja.entidadFinanciera = txtIdCaja
        objCaja.usuarioModificacion = GFichaUsuarios.IdCajaUsuario
        objCaja.fechaModificacion = DateTime.Now
        nDocumentoCaja.documentoCaja = objCaja

        For Each i As DataGridViewRow In dgvNuevoDoc.Rows
            If dgvNuevoDoc.Rows(i.Index).Cells(22).Value() <> Helios.Cont.Business.Entity.BaseBE.EntityAction.DELETE Then
                objCajaDetalle = New documentoCajaDetalle
                objCajaDetalle.idDocumento = 0
                objCajaDetalle.fecha = fecha
                objCajaDetalle.montoSoles = CDec(dgvNuevoDoc.Rows(i.Index).Cells(10).Value())
                objCajaDetalle.montoUsd = CDec(dgvNuevoDoc.Rows(i.Index).Cells(11).Value())
                objCajaDetalle.entregado = "SI"
                objCajaDetalle.documentoAfectado = lblIdDocumento
                objCajaDetalle.usuarioModificacion = GFichaUsuarios.IdCajaUsuario
                objCajaDetalle.fechaModificacion = DateTime.Now
                ListaCajaDetalle.Add(objCajaDetalle)
            End If
        Next

        nDocumentoCaja.documentoCaja.documentoCajaDetalle = ListaCajaDetalle

        Return nDocumentoCaja
    End Function

    Sub AsientoVenta()
        Dim nMovimiento As New movimiento
        Dim nAsiento As New asiento

        nAsiento.idAsiento = 0
        nAsiento.idDocumento = lblIdDocumento
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idDocumentoRef = lblIdDocumento
        nAsiento.fechaProceso = fecha
        nAsiento.idAlmacen = Nothing
        nAsiento.nombreAlmacen = Nothing
        nAsiento.idEntidad = Nothing ' txtIdCliente.Text
        nAsiento.nombreEntidad = txtCliente.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        nAsiento.codigoLibro = "14"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_Existencia
        nAsiento.glosa = "ASIENTO x VENTA PAGADA-TICKET"
        nAsiento.importeMN = txtTotalPedidomn.Text
        nAsiento.importeME = txtTotalPedidome.Text
        nAsiento.fechaActualizacion = DateTime.Now
        nAsiento.usuarioActualizacion = GFichaUsuarios.IdCajaUsuario
        ListaAsientonTransito.Add(nAsiento)

        nAsiento.movimiento.Add(AS_CAJA(CDec(txtTotalPedidomn.Text), CDec(txtTotalPedidome.Text)))
        For Each i As DataGridViewRow In dgvNuevoDoc.Rows
            If dgvNuevoDoc.Rows(i.Index).Cells(22).Value() <> Business.Entity.BaseBE.EntityAction.DELETE Then
                Select Case IIf(rbBoleta.Checked = True, "12.1", "12.2")

                    Case "03", "02"
                        MV_Item_Transito(dgvNuevoDoc.Rows(i.Index).Cells(25).Value, dgvNuevoDoc.Rows(i.Index).Cells(3).Value, CDec(dgvNuevoDoc.Rows(i.Index).Cells(33).Value), CDec(dgvNuevoDoc.Rows(i.Index).Cells(34).Value), dgvNuevoDoc.Rows(i.Index).Cells(23).Value)
                    Case Else

                        Select Case dgvNuevoDoc.Rows(i.Index).Cells(1).Value
                            Case "1"
                                MV_Item_Transito(dgvNuevoDoc.Rows(i.Index).Cells(25).Value, dgvNuevoDoc.Rows(i.Index).Cells(3).Value, CDec(dgvNuevoDoc.Rows(i.Index).Cells(33).Value), CDec(dgvNuevoDoc.Rows(i.Index).Cells(34).Value), dgvNuevoDoc.Rows(i.Index).Cells(23).Value)
                            Case Else
                                MV_Item_Transito(dgvNuevoDoc.Rows(i.Index).Cells(25).Value, dgvNuevoDoc.Rows(i.Index).Cells(3).Value, CDec(dgvNuevoDoc.Rows(i.Index).Cells(33).Value), CDec(dgvNuevoDoc.Rows(i.Index).Cells(34).Value), dgvNuevoDoc.Rows(i.Index).Cells(23).Value)

                        End Select
                End Select


                nMovimiento = New movimiento
                nMovimiento.cuenta = RecuperaCuentaVenta(dgvNuevoDoc.Rows(i.Index).Cells(25).Value, dgvNuevoDoc.Rows(i.Index).Cells(23).Value)
                nMovimiento.descripcion = dgvNuevoDoc.Rows(i.Index).Cells(3).Value
                nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
                'Select Case lblTipoDoc.Text
                '    Case "03", "02"
                '        nMovimiento.monto = CDec(i.SubItems(5).Text)
                '        nMovimiento.montoUSD = CDec(i.SubItems(6).Text)
                '    Case Else
                Select Case dgvNuevoDoc.Rows(i.Index).Cells(1).Value
                    Case "1"
                        nMovimiento.monto = CDec(dgvNuevoDoc.Rows(i.Index).Cells(14).Value)
                        nMovimiento.montoUSD = CDec(dgvNuevoDoc.Rows(i.Index).Cells(18).Value)
                    Case Else
                        nMovimiento.monto = CDec(dgvNuevoDoc.Rows(i.Index).Cells(10).Value)
                        nMovimiento.montoUSD = CDec(dgvNuevoDoc.Rows(i.Index).Cells(11).Value)
                        'End Select
                End Select
                'nMovimiento.monto = CDec(i.SubItems(13).Text)
                'nMovimiento.montoUSD = CDec(i.SubItems(14).Text)
                nMovimiento.fechaActualizacion = DateTime.Now
                nMovimiento.usuarioActualizacion = "Jiuni"


                nAsiento.movimiento.Add(nMovimiento)
            End If




        Next
        nAsiento.movimiento.Add(AS_IGV(CDec(txtMontoIGVmn.Text), CDec(txtMontoIGVme.Text)))
        '   Return nAsiento
    End Sub

    Public Function AS_CAJA(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
              .cuenta = txtCuentaEF,
              .descripcion = txtCaja,
              .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
              .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = "Jiuni"}

        Return nMovimiento
    End Function

    Public Function AS_IGV(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
              .cuenta = "40111",
              .descripcion = "I.G.V.",
              .tipo = ASIENTO_CONTABLE.UBICACION.HABER,
              .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = "Jiuni"}

        Return nMovimiento
    End Function

    Public Function AsientoTransito(cMonto As Decimal, cMontoUS As Decimal) As asiento
        Dim nAsiento As New asiento
        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = Nothing ' txtIdCliente.Text
        nAsiento.nombreEntidad = txtCliente.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        nAsiento.fechaProceso = fecha
        nAsiento.codigoLibro = "1"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_Existencia
        nAsiento.importeMN = cMonto
        nAsiento.importeME = cMontoUS
        nAsiento.glosa = GlosaVenta()
        nAsiento.usuarioActualizacion = "jiuni"
        nAsiento.fechaActualizacion = DateTime.Now
        Return nAsiento
    End Function

    Public Sub MV_Item_Transito(cCuenta As String, cproducto As String, cMonto As Decimal, cMontoUS As Decimal, strTipoExistencia As String)
        Dim asientoTransitod As New asiento
        Dim mascaraSA As New mascaraContable2SA
        Dim mascaraExistenciasSA As New mascaraContableExistenciaSA
        Dim nMovimiento As New movimiento

        asientoTransitod = AsientoTransito(cMonto, cMontoUS) ' CABECERA ASIENTO

        'MOVIMIENTOS -1 cuenta 20
        nMovimiento = New movimiento
        'Select Case strTipoExistencia
        '    Case "01"
        '        With mascaraSA.GetUbicar_mascaraContable2PorEmpresa(Gempresas.IdEmpresaRuc, cCuenta)
        nMovimiento.cuenta = "69112"
        '        End With
        'End Select


        nMovimiento.descripcion = cproducto
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
        nMovimiento.monto = cMonto
        nMovimiento.montoUSD = cMontoUS
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = "Jiuni"
        asientoTransitod.movimiento.Add(nMovimiento)

        'MOVIMIENTOS - 2 cuenta 28
        nMovimiento = New movimiento
        'Select Case strTipoExistencia
        '    Case "01"
        '        With mascaraSA.GetUbicar_mascaraContable2PorEmpresa(Gempresas.IdEmpresaRuc, cCuenta)
        nMovimiento.cuenta = "20111"
        '        End With

        'End Select

        nMovimiento.descripcion = cproducto
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
        nMovimiento.monto = cMonto
        nMovimiento.montoUSD = cMontoUS
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = "Jiuni"
        asientoTransitod.movimiento.Add(nMovimiento)

        ListaAsientonTransito.Add(asientoTransitod)
    End Sub

    Public Function RecuperaCuentaVenta(cCuenta As String, strTipoExistencia As String) As String
        Dim mascaraSA As New mascaraContable2SA
        Dim mascaraExistenciasSA As New mascaraContableExistenciaSA
        Dim strCuenta As String = Nothing

        'Select Case strTipoExistencia
        '    Case "01"
        '        With mascaraSA.GetUbicar_mascaraContable2PorEmpresa(Gempresas.IdEmpresaRuc, cCuenta)
        strCuenta = "70111"
        '        End With
        'End Select
        Return strCuenta
    End Function

    Sub Grabar()
        Dim VentaSA As New documentoVentaAbarrotesSA
        Dim ndocumento As New documento()
        Dim DocCaja As New documento

        Dim ListaTotales As New List(Of totalesAlmacen)
        Dim docVentaSA As New documentoVentaAbarrotesSA

        Dim nDocumentoVenta As New documentoventaAbarrotes()
        Dim objDocumentoVentaDet As New documentoventaAbarrotesDet
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        Dim asientoSA As New AsientoSA
        ' Dim ListaAsiento As New List(Of asiento)
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento

        Dim ListaDetalle As New List(Of documentoventaAbarrotesDet)

        Dim cajaUsarioBE As New cajaUsuario
        Dim cajaUsariodetalleBE As New cajaUsuariodetalle
        Dim cajaUsariodetalleListaBE As New List(Of cajaUsuariodetalle)

        With ndocumento
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            If IsNothing(GProyectos) Then
            Else
                .idProyecto = GProyectos.IdProyectoActividad
            End If
            .tipoDoc = IIf(rbBoleta.Checked = True, "12.1", "12.2")
            .fechaProceso = fecha
            .nroDoc = GConfiguracion.Serie ' & "-" & txtNumeroComp.Text.Trim
            .idOrden = Nothing ' Me.IdOrden
            .tipoOperacion = "01"
            .usuarioActualizacion = GFichaUsuarios.IdCajaUsuario
            .fechaActualizacion = DateTime.Now
        End With

        'With cajaUsarioBE
        '    .idcajaUsuario = GFichaUsuarios.IdCajaUsuario
        '    .ingresoAdicMN = CDec(lblTotalAdquisiones.Text)
        '    .ingresoAdicME = CDec(lblTotalUS.Text)
        'End With

        'cajaUsariodetalleBE = New cajaUsuariodetalle
        'cajaUsariodetalleBE.idcajaUsuario = GFichaUsuarios.IdCajaUsuario
        'cajaUsariodetalleBE.tipoDoc = IIf(rbBoleta.Checked = True, "12.1", "12.2")
        'cajaUsariodetalleBE.tipoVenta = TIPO_VENTA.VENTA_AL_TICKET_DIRECTA
        'cajaUsariodetalleBE.importeMN = CDec(lblTotalAdquisiones.Text)
        'cajaUsariodetalleBE.importeME = CDec(lblTotalUS.Text)
        'cajaUsariodetalleListaBE.Add(cajaUsariodetalleBE)

        'cajaUsarioBE.cajaUsuariodetalle = cajaUsariodetalleListaBE


        DocCaja = ComprobanteCaja()

        With nDocumentoVenta
            .TipoConfiguracion = GConfiguracion.TipoConfiguracion
            .IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante)
            If IsNothing(GProyectos) Then
            Else
                .idPadre = GProyectos.IdProyectoActividad
            End If
            .TipoDocNumeracion = Nothing ' lblTipoDocNumeracion.Text
            .codigoLibro = "8"
            .tipoDocumento = IIf(rbBoleta.Checked = True, "12.1", "12.2")
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idEstablecimiento = GEstableciento.IdEstablecimiento
            .fechaDoc = fecha
            .fechaPeriodo = lblPerido.Text
            .serie = GConfiguracion.Serie
            .numeroDoc = Nothing 'txtNumeroComp.Text
            .idCliente = 0
            .nombrePedido = txtCliente.Text
            .moneda = IIf(cboMoneda.SelectedValue = 1, "1", "2")
            .tasaIgv = txtIgv.Value ' IIf(IsNothing(nudIgv.Value) Or String.IsNullOrEmpty(nudIgv.Value) Or String.IsNullOrWhiteSpace(nudIgv.Value), Nothing, Trim(nudIgv.Value))
            .tipoCambio = IIf(txtTipoCambio.Value = 0 Or txtTipoCambio.Value = "0.00", 0, CDec(txtTipoCambio.Value))

            '****************** DESTINO EN SOLES ************************************************************************
            .bi01 = IIf(nudBase1 = 0 Or nudBase1 = "0.00", CDec(0.0), CDec(nudBase1))
            .bi02 = IIf(nudBase2 = 0 Or nudBase2 = "0.00", CDec(0.0), CDec(nudBase2))

            .isc01 = IIf(nudIsc1 = 0 Or nudIsc1 = "0.00", CDec(0.0), CDec(nudIsc1))
            .isc02 = IIf(nudIsc2 = 0 Or nudIsc2 = "0.00", CDec(0.0), CDec(nudIsc2))

            .igv01 = IIf(nudMontoIgv1 = 0 Or nudMontoIgv1 = "0.00", CDec(0.0), CDec(nudMontoIgv1))
            .igv02 = IIf(nudMontoIgv2 = 0 Or nudMontoIgv2 = "0.00", CDec(0.0), CDec(nudMontoIgv2))

            .otc01 = IIf(nudOtrosTributos1 = 0 Or nudOtrosTributos1 = "0.00", CDec(0.0), CDec(nudOtrosTributos1))
            .otc02 = IIf(nudOtrosTributos2 = 0 Or nudOtrosTributos2 = "0.00", CDec(0.0), CDec(nudOtrosTributos2))

            '****************************************************************************************************************

            '****************** DESTINO EN DOLARES ************************************************************************
            .bi01us = IIf(nudBaseus1 = 0 Or nudBaseus1 = "0.00", CDec(0.0), CDec(nudBaseus1))
            .bi02us = IIf(nudBaseus2 = 0 Or nudBaseus2 = "0.00", CDec(0.0), CDec(nudBaseus2))

            .isc01us = IIf(nudIscus1 = 0 Or nudIscus1 = "0.00", CDec(0.0), CDec(nudIscus1))
            .isc02us = IIf(nudIscus2 = 0 Or nudIscus2 = "0.00", CDec(0.0), CDec(nudIscus2))

            .igv01us = IIf(nudMontoIgvus1 = 0 Or nudMontoIgvus1 = "0.00", CDec(0.0), CDec(nudMontoIgvus1))
            .igv02us = IIf(nudMontoIgvus2 = 0 Or nudMontoIgvus2 = "0.00", CDec(0.0), CDec(nudMontoIgvus2))

            .otc01us = IIf(nudOtrosTributosus1 = 0 Or nudOtrosTributosus1 = "0.00", CDec(0.0), CDec(nudOtrosTributosus1))
            .otc02us = IIf(nudOtrosTributosus2 = 0 Or nudOtrosTributosus2 = "0.00", CDec(0.0), CDec(nudOtrosTributosus2))

            '****************************************************************************************************************
            .ImporteNacional = IIf(txtTotalPedidomn.Text = 0 Or txtTotalPedidomn.Text = "0.00", CDec(0.0), CDec(txtTotalPedidomn.Text))
            .ImporteExtranjero = IIf(txtTotalPedidome.Text = 0 Or txtTotalPedidome.Text = "0.00", CDec(0.0), CDec(txtTotalPedidome.Text))

            .tipoVenta = TIPO_VENTA.VENTA_AL_TICKET_DIRECTA
            .estadoCobro = TIPO_VENTA.PAGO.COBRADO
            .glosa = GlosaVenta()
            '    .RE = Nothing ' IIf(IsNothing(txtDestinoref.Text) Or String.IsNullOrEmpty(txtDestinoref.Text) Or String.IsNullOrWhiteSpace(txtDestinoref.Text), Nothing, Trim(txtDestinoref.Text.Trim))
            ' = TIPO_VENTA.VENTA_PAGADA
            ' .DocumentoSustentado = "S"
            .usuarioActualizacion = GFichaUsuarios.IdCajaUsuario
            .fechaActualizacion = DateTime.Now
        End With
        ndocumento.documentoventaAbarrotes = nDocumentoVenta

        For Each i As DataGridViewRow In dgvNuevoDoc.Rows

            Dim almacenSA As New almacenSA
            objDocumentoVentaDet = New documentoventaAbarrotesDet
            objDocumentoVentaDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoVentaDet.IdEstablecimiento = almacenSA.GetUbicar_almacenPorID(i.Cells(24).Value()).idEstablecimiento
            objDocumentoVentaDet.FechaDoc = fecha

            objDocumentoVentaDet.TipoDoc = IIf(rbBoleta.Checked = True, "12.1", "12.2")
            objDocumentoVentaDet.idAlmacenOrigen = CDec(i.Cells(24).Value())
            objDocumentoVentaDet.establecimientoOrigen = almacenSA.GetUbicar_almacenPorID(i.Cells(24).Value()).idEstablecimiento
            objDocumentoVentaDet.cuentaOrigen = i.Cells(25).Value()
            objDocumentoVentaDet.idItem = i.Cells(2).Value()
            objDocumentoVentaDet.DetalleItem = i.Cells(3).Value()
            objDocumentoVentaDet.tipoExistencia = i.Cells(23).Value()
            objDocumentoVentaDet.destino = i.Cells(1).Value()
            objDocumentoVentaDet.unidad1 = i.Cells(4).Value().ToString.Trim
            objDocumentoVentaDet.monto1 = CDec(i.Cells(5).Value())
            objDocumentoVentaDet.unidad2 = i.Cells(29).Value()
            objDocumentoVentaDet.monto2 = i.Cells(31).Value()
            objDocumentoVentaDet.precioUnitario = CDec(i.Cells(8).Value())
            objDocumentoVentaDet.precioUnitarioUS = CDec(i.Cells(9).Value())
            objDocumentoVentaDet.importeMN = CDec(i.Cells(10).Value())
            objDocumentoVentaDet.importeME = CDec(i.Cells(11).Value())
            objDocumentoVentaDet.descuentoMN = CDec(i.Cells(12).Value())
            objDocumentoVentaDet.descuentoME = CDec(i.Cells(13).Value())

            objDocumentoVentaDet.montokardex = CDec(i.Cells(14).Value())
            objDocumentoVentaDet.montoIsc = CDec(i.Cells(15).Value())
            objDocumentoVentaDet.montoIgv = CDec(i.Cells(16).Value())
            objDocumentoVentaDet.otrosTributos = CDec(i.Cells(17).Value())
            '**********************************************************************************
            objDocumentoVentaDet.montokardexUS = CDec(i.Cells(18).Value())
            objDocumentoVentaDet.montoIscUS = CDec(i.Cells(19).Value())
            objDocumentoVentaDet.montoIgvUS = CDec(i.Cells(20).Value())
            objDocumentoVentaDet.otrosTributosUS = CDec(i.Cells(21).Value())
            '  objDocumentoVentaDet.PreEvento = i.Cells(25).Value()
            objDocumentoVentaDet.estadoMovimiento = "SI" 'ENTREGADO/COBRADO
            objDocumentoVentaDet.entregado = "S"
            '**********************************************************************************
            objDocumentoVentaDet.importeMNK = CDec(i.Cells(6).Value())
            objDocumentoVentaDet.importeMEK = CDec(i.Cells(28).Value())
            objDocumentoVentaDet.fechaVcto = IIf(IsNothing(i.Cells(30).Value()), Nothing, CDate(i.Cells(30).Value()))

            objDocumentoVentaDet.salidaCostoMN = CDec(i.Cells(33).Value()) ' Math.Round(CDec(i.Cells(6).Value()) * CDec(i.Cells(5).Value()), 2)
            objDocumentoVentaDet.salidaCostoME = CDec(i.Cells(34).Value()) 'Math.Round(CDec(i.Cells(28).Value()) * CDec(i.Cells(5).Value()), 2)

            objDocumentoVentaDet.preEvento = IIf(IsNothing(i.Cells(27).Value()), Nothing, i.Cells(27).Value())
            objDocumentoVentaDet.usuarioModificacion = GFichaUsuarios.IdCajaUsuario
            objDocumentoVentaDet.fechaModificacion = Date.Now
            objDocumentoVentaDet.tipoVenta = i.Cells(32).Value()

            objDocumentoVentaDet.Glosa = GlosaVenta()
            ' objDocumentoCompraDet.BonificacionMN =
            ListaDetalle.Add(objDocumentoVentaDet)

        Next


        ndocumento.documentoventaAbarrotes.documentoventaAbarrotesDet = ListaDetalle
        'TOTALES ALMACEN
        ListaTotales = ListaTotalesAlmacen()

        AsientoVenta()
        ndocumento.asiento = ListaAsientonTransito
        Dim xcod As Integer = VentaSA.SaveVentaDirectaTicket(ndocumento, ListaTotales, DocCaja, cajaUsarioBE)
        lblEstado.Text = "venta registrada!"
        lblEstado.Image = My.Resources.ok4
        Dispose()
    End Sub

    Sub UpdateVenta()
        Dim VentaSA As New documentoVentaAbarrotesSA
        Dim ndocumento As New documento()
        Dim DocCaja As New documento

        Dim ListaTotales As New List(Of totalesAlmacen)
        Dim ListaDeleteEO As New List(Of totalesAlmacen)

        Dim nDocumentoVenta As New documentoventaAbarrotes()
        Dim objDocumentoVentaDet As New documentoventaAbarrotesDet
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        Dim asientoSA As New AsientoSA
        ' Dim ListaAsiento As New List(Of asiento)
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento

        Dim ListaDetalle As New List(Of documentoventaAbarrotesDet)

        'Dim cajaUsuarioMontos As New cajaUsuario
        'Dim cajaEliminarMontos As New cajaUsuario
        'Dim cajaUsariodetalleBE As New cajaUsuariodetalle
        'Dim cajaUsariodetalleListaBE As New List(Of cajaUsuariodetalle)

        'With cajaUsuarioMontos
        '    .IdDocumentoVenta = lblIdDocumento.Text
        '    .idcajaUsuario = GFichaUsuarios.IdCajaUsuario
        '    .ingresoAdicMN = CDec(lblTotalAdquisiones.Text)
        '    .ingresoAdicME = CDec(lblTotalUS.Text)
        'End With

        'cajaUsariodetalleBE = New cajaUsuariodetalle
        'cajaUsariodetalleBE.idcajaUsuario = GFichaUsuarios.IdCajaUsuario
        'cajaUsariodetalleBE.tipoDoc = IIf(rbBoleta.Checked = True, "12.1", "12.2")
        'cajaUsariodetalleBE.tipoVenta = TIPO_VENTA.VENTA_AL_TICKET_DIRECTA
        'cajaUsariodetalleBE.importeMN = CDec(lblTotalAdquisiones.Text)
        'cajaUsariodetalleBE.importeME = CDec(lblTotalUS.Text)
        'cajaUsariodetalleListaBE.Add(cajaUsariodetalleBE)

        'cajaUsuarioMontos.cajaUsuariodetalle = cajaUsariodetalleListaBE

        'With cajaEliminarMontos
        '    .idcajaUsuario = GFichaUsuarios.IdCajaUsuario
        '    .IdDocumentoVenta = lblIdDocumento.Text
        'End With

        With ndocumento
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idDocumento = lblIdDocumento
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            If IsNothing(GProyectos) Then
            Else
                .idProyecto = GProyectos.IdProyectoActividad
            End If
            .tipoDoc = IIf(rbBoleta.Checked = True, "12.1", "12.2")
            .fechaProceso = fecha
            .nroDoc = txtSerie & "-" & NumeroComprobante
            .idOrden = Nothing ' Me.IdOrden
            .tipoOperacion = "01"
            .usuarioActualizacion = GFichaUsuarios.IdCajaUsuario
            .fechaActualizacion = DateTime.Now
        End With

        With nDocumentoVenta
            .idDocumento = lblIdDocumento
            If IsNothing(GProyectos) Then
            Else
                .idPadre = GProyectos.IdProyectoActividad
            End If
            .TipoDocNumeracion = Nothing ' lblTipoDocNumeracion.Text
            .codigoLibro = "8"
            .tipoDocumento = IIf(rbBoleta.Checked = True, "12.1", "12.2")
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idEstablecimiento = GEstableciento.IdEstablecimiento
            .fechaDoc = fecha ' PERIODO
            .fechaPeriodo = lblPerido.Text
            .serie = txtSerie
            .numeroDoc = NumeroComprobante
            .nombrePedido = txtCliente.Text
            ' .nombrePedido = txtPedidoRef.Text
            .moneda = IIf(cboMoneda.SelectedValue = 1, "1", "2")
            .tasaIgv = txtIgv.Value ' IIf(IsNothing(nudIgv.Value) Or String.IsNullOrEmpty(nudIgv.Value) Or String.IsNullOrWhiteSpace(nudIgv.Value), Nothing, Trim(nudIgv.Value))
            .tipoCambio = IIf(txtTipoCambio.Value = 0 Or txtTipoCambio.Value = "0.00", 0, CDec(txtTipoCambio.Value))

            '****************** DESTINO EN SOLES ************************************************************************
            .bi01 = IIf(nudBase1 = 0 Or nudBase1 = "0.00", CDec(0.0), CDec(nudBase1))
            .bi02 = IIf(nudBase2 = 0 Or nudBase2 = "0.00", CDec(0.0), CDec(nudBase2))

            .isc01 = IIf(nudIsc1 = 0 Or nudIsc1 = "0.00", CDec(0.0), CDec(nudIsc1))
            .isc02 = IIf(nudIsc2 = 0 Or nudIsc2 = "0.00", CDec(0.0), CDec(nudIsc2))

            .igv01 = IIf(nudMontoIgv1 = 0 Or nudMontoIgv1 = "0.00", CDec(0.0), CDec(nudMontoIgv1))
            .igv02 = IIf(nudMontoIgv2 = 0 Or nudMontoIgv2 = "0.00", CDec(0.0), CDec(nudMontoIgv2))

            .otc01 = IIf(nudOtrosTributos1 = 0 Or nudOtrosTributos1 = "0.00", CDec(0.0), CDec(nudOtrosTributos1))
            .otc02 = IIf(nudOtrosTributos2 = 0 Or nudOtrosTributos2 = "0.00", CDec(0.0), CDec(nudOtrosTributos2))

            '****************************************************************************************************************

            '****************** DESTINO EN DOLARES ************************************************************************
            .bi01us = IIf(nudBaseus1 = 0 Or nudBaseus1 = "0.00", CDec(0.0), CDec(nudBaseus1))
            .bi02us = IIf(nudBaseus2 = 0 Or nudBaseus2 = "0.00", CDec(0.0), CDec(nudBaseus2))

            .isc01us = IIf(nudIscus1 = 0 Or nudIscus1 = "0.00", CDec(0.0), CDec(nudIscus1))
            .isc02us = IIf(nudIscus2 = 0 Or nudIscus2 = "0.00", CDec(0.0), CDec(nudIscus2))

            .igv01us = IIf(nudMontoIgvus1 = 0 Or nudMontoIgvus1 = "0.00", CDec(0.0), CDec(nudMontoIgvus1))
            .igv02us = IIf(nudMontoIgvus2 = 0 Or nudMontoIgvus2 = "0.00", CDec(0.0), CDec(nudMontoIgvus2))

            .otc01us = IIf(nudOtrosTributosus1 = 0 Or nudOtrosTributosus1 = "0.00", CDec(0.0), CDec(nudOtrosTributosus1))
            .otc02us = IIf(nudOtrosTributosus2 = 0 Or nudOtrosTributosus2 = "0.00", CDec(0.0), CDec(nudOtrosTributosus2))

            '****************************************************************************************************************
            .ImporteNacional = IIf(txtTotalPedidomn.Text = 0 Or txtTotalPedidomn.Text = "0.00", CDec(0.0), CDec(txtTotalPedidomn.Text))
            .ImporteExtranjero = IIf(txtTotalPedidome.Text = 0 Or txtTotalPedidome.Text = "0.00", CDec(0.0), CDec(txtTotalPedidome.Text))

            .tipoVenta = TIPO_VENTA.VENTA_AL_TICKET_DIRECTA
            .estadoCobro = TIPO_VENTA.PAGO.COBRADO
            .glosa = GlosaVenta()
            '    .RE = Nothing ' IIf(IsNothing(txtDestinoref.Text) Or String.IsNullOrEmpty(txtDestinoref.Text) Or String.IsNullOrWhiteSpace(txtDestinoref.Text), Nothing, Trim(txtDestinoref.Text.Trim))
            ' = TIPO_VENTA.VENTA_PAGADA
            ' .DocumentoSustentado = "S"
            .usuarioActualizacion = GFichaUsuarios.IdCajaUsuario
            .fechaActualizacion = DateTime.Now
        End With
        ndocumento.documentoventaAbarrotes = nDocumentoVenta

        For Each i As DataGridViewRow In dgvNuevoDoc.Rows

            Dim almacenSA As New almacenSA
            objDocumentoVentaDet = New documentoventaAbarrotesDet
            objDocumentoVentaDet.idDocumento = lblIdDocumento
            objDocumentoVentaDet.secuencia = dgvNuevoDoc.Rows(i.Index).Cells(0).Value()
            objDocumentoVentaDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoVentaDet.IdEstablecimiento = almacenSA.GetUbicar_almacenPorID(dgvNuevoDoc.Rows(i.Index).Cells(24).Value()).idEstablecimiento
            objDocumentoVentaDet.FechaDoc = fecha

            objDocumentoVentaDet.TipoDoc = IIf(rbBoleta.Checked = True, "12.1", "12.2")
            objDocumentoVentaDet.idAlmacenOrigen = CDec(dgvNuevoDoc.Rows(i.Index).Cells(24).Value())
            objDocumentoVentaDet.establecimientoOrigen = almacenSA.GetUbicar_almacenPorID(dgvNuevoDoc.Rows(i.Index).Cells(24).Value()).idEstablecimiento
            objDocumentoVentaDet.cuentaOrigen = dgvNuevoDoc.Rows(i.Index).Cells(25).Value()
            objDocumentoVentaDet.idItem = dgvNuevoDoc.Rows(i.Index).Cells(2).Value()
            objDocumentoVentaDet.DetalleItem = dgvNuevoDoc.Rows(i.Index).Cells(3).Value()
            objDocumentoVentaDet.tipoExistencia = dgvNuevoDoc.Rows(i.Index).Cells(23).Value()
            objDocumentoVentaDet.destino = dgvNuevoDoc.Rows(i.Index).Cells(1).Value()
            objDocumentoVentaDet.unidad1 = dgvNuevoDoc.Rows(i.Index).Cells(4).Value().ToString.Trim
            objDocumentoVentaDet.monto1 = CDec(dgvNuevoDoc.Rows(i.Index).Cells(5).Value())
            objDocumentoVentaDet.unidad2 = dgvNuevoDoc.Rows(i.Index).Cells(29).Value()
            objDocumentoVentaDet.monto2 = dgvNuevoDoc.Rows(i.Index).Cells(31).Value()
            objDocumentoVentaDet.precioUnitario = CDec(dgvNuevoDoc.Rows(i.Index).Cells(8).Value())
            objDocumentoVentaDet.precioUnitarioUS = CDec(dgvNuevoDoc.Rows(i.Index).Cells(9).Value())
            objDocumentoVentaDet.importeMN = CDec(dgvNuevoDoc.Rows(i.Index).Cells(10).Value())
            objDocumentoVentaDet.importeME = CDec(dgvNuevoDoc.Rows(i.Index).Cells(11).Value())
            objDocumentoVentaDet.descuentoMN = CDec(dgvNuevoDoc.Rows(i.Index).Cells(12).Value())
            objDocumentoVentaDet.descuentoME = CDec(dgvNuevoDoc.Rows(i.Index).Cells(13).Value())

            objDocumentoVentaDet.montokardex = CDec(dgvNuevoDoc.Rows(i.Index).Cells(14).Value())
            objDocumentoVentaDet.montoIsc = CDec(dgvNuevoDoc.Rows(i.Index).Cells(15).Value())
            objDocumentoVentaDet.montoIgv = CDec(dgvNuevoDoc.Rows(i.Index).Cells(16).Value())
            objDocumentoVentaDet.otrosTributos = CDec(dgvNuevoDoc.Rows(i.Index).Cells(17).Value())
            '**********************************************************************************
            objDocumentoVentaDet.montokardexUS = CDec(dgvNuevoDoc.Rows(i.Index).Cells(18).Value())
            objDocumentoVentaDet.montoIscUS = CDec(dgvNuevoDoc.Rows(i.Index).Cells(19).Value())
            objDocumentoVentaDet.montoIgvUS = CDec(dgvNuevoDoc.Rows(i.Index).Cells(20).Value())
            objDocumentoVentaDet.otrosTributosUS = CDec(dgvNuevoDoc.Rows(i.Index).Cells(21).Value())
            '  objDocumentoVentaDet.PreEvento = dgvNuevoDoc.Rows(i.Index).Cells(25).Value()
            objDocumentoVentaDet.estadoMovimiento = "NO" 'ENTREGADO/COBRADO
            '**********************************************************************************
            objDocumentoVentaDet.importeMNK = CDec(dgvNuevoDoc.Rows(i.Index).Cells(6).Value())
            objDocumentoVentaDet.importeMEK = CDec(dgvNuevoDoc.Rows(i.Index).Cells(28).Value())
            objDocumentoVentaDet.fechaVcto = IIf(IsNothing(dgvNuevoDoc.Rows(i.Index).Cells(30).Value()), Nothing, CDate(dgvNuevoDoc.Rows(i.Index).Cells(30).Value()))

            objDocumentoVentaDet.salidaCostoMN = CDec(dgvNuevoDoc.Rows(i.Index).Cells(33).Value()) ' Math.Round(CDec(dgvNuevoDoc.Rows(i.Index).Cells(6).Value()) * CDec(dgvNuevoDoc.Rows(i.Index).Cells(5).Value()), 2)
            objDocumentoVentaDet.salidaCostoME = CDec(dgvNuevoDoc.Rows(i.Index).Cells(34).Value()) 'Math.Round(CDec(dgvNuevoDoc.Rows(i.Index).Cells(28).Value()) * CDec(dgvNuevoDoc.Rows(i.Index).Cells(5).Value()), 2)

            objDocumentoVentaDet.preEvento = IIf(IsNothing(dgvNuevoDoc.Rows(i.Index).Cells(27).Value()), Nothing, dgvNuevoDoc.Rows(i.Index).Cells(27).Value())
            objDocumentoVentaDet.usuarioModificacion = GFichaUsuarios.IdCajaUsuario
            objDocumentoVentaDet.fechaModificacion = Date.Now
            objDocumentoVentaDet.tipoVenta = dgvNuevoDoc.Rows(i.Index).Cells(32).Value()
            If dgvNuevoDoc.Rows(i.Index).Cells(22).Value() = Business.Entity.BaseBE.EntityAction.UPDATE Then
                objDocumentoVentaDet.Action = Business.Entity.BaseBE.EntityAction.UPDATE
            ElseIf dgvNuevoDoc.Rows(i.Index).Cells(22).Value() = Business.Entity.BaseBE.EntityAction.INSERT Then
                objDocumentoVentaDet.Action = Business.Entity.BaseBE.EntityAction.INSERT
            ElseIf dgvNuevoDoc.Rows(i.Index).Cells(22).Value() = Business.Entity.BaseBE.EntityAction.DELETE Then
                objDocumentoVentaDet.Action = Business.Entity.BaseBE.EntityAction.DELETE
            End If

            objDocumentoVentaDet.Glosa = GlosaVenta()

            ListaDetalle.Add(objDocumentoVentaDet)
            '   End If
        Next

        ndocumento.documentoventaAbarrotes.documentoventaAbarrotesDet = ListaDetalle
        'TOTALES ALMACEN
        ListaTotales = ListaTotalesAlmacen()
        ListaDeleteEO = ListaDeleteTotales()
        DocCaja = ComprobanteCaja()

        AsientoVenta()
        ndocumento.asiento = ListaAsientonTransito
        Dim xcod As Integer = VentaSA.UpdateVentaDirectaTicket(ndocumento, ListaTotales, ListaDeleteEO, DocCaja,
                                                               Nothing, Nothing)
        lblEstado.Text = "venta modificada!"
        lblEstado.Image = My.Resources.ok4
        Dispose()
    End Sub

    Public Sub UbicarDocumento(ByVal intIdDocumento As Integer)
        Dim objDoc As New DocumentoSA
        Dim objDocCompra As New documentoVentaAbarrotesSA
        Dim objDocCompraDet As New documentoVentaAbarrotesDetSA
        Dim objTabla As New tablaDetalleSA
        Dim objEntidad As New entidadSA
        Dim nEntidad As New entidad
        Dim VALUEDES As String = ""
        Dim insumosSA As New detalleitemsSA



        Dim inventarioBL As New inventarioMovimientoSA
        Dim almacenSA As New almacenSA
        Dim almacen As New almacen

        Dim totalesAlmacenSA As New TotalesAlmacenSA

        Dim documentoCajaDetalleSA As New DocumentoCajaDetalleSA
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim objDocCaja As New DocumentoSA
        Dim establecSA As New establecimientoSA
        Dim estadoF As New EstadosFinancierosSA
        Try
            With objDoc.UbicarDocumento(intIdDocumento)
                fecha = .fechaProceso
                txtFechaComprobante.Value = .fechaProceso
                'COMPROBANTE
                With objTabla.GetUbicarTablaID(10, .tipoDoc)
                    TipoDocVenta = .codigoDetalle
                    txtComprobante = .descripcion
                End With
            End With

            'CABECERA COMPROBANTE
            With objDocCompra.GetUbicar_documentoventaAbarrotesPorID(intIdDocumento)
                txtCliente.Text = .nombrePedido
                lblIdDocumento = .idDocumento
                lblPerido.Text = .fechaPeriodo
                txtSerie = .serie
                NumeroComprobante = .numeroDoc
                txtTipoCambio.Value = .tipoCambio

                If .tipoDocumento = "12.1" Then
                    rbBoleta.Checked = True
                Else
                    rbFactura.Checked = True
                End If

            End With

            'DETALLE DE LA COMPRA
            dgvNuevoDoc.Rows.Clear()
            For Each i In objDocCompraDet.GetUbicar_documentoventaAbarrotesDetPorIDocumento(intIdDocumento)
                If i.destino = "1" Then
                    VALUEDES = "1"
                ElseIf i.destino.Trim = "2" Then
                    VALUEDES = "2"
                ElseIf i.destino.Trim = "3" Then
                    VALUEDES = "3"
                ElseIf i.destino.Trim = "4" Then
                    VALUEDES = "4"
                End If
                dgvNuevoDoc.Rows.Add(i.secuencia,
                                    i.destino,
                                    i.idItem,
                                    i.nombreItem,
                                    i.unidad1,
                                    i.monto1,
                                   i.importeMNK, totalesAlmacenSA.GetUbicarProductoTAlmacen(i.idAlmacenOrigen, i.idItem).cantidad,
                                    i.precioUnitario,
                                    i.precioUnitarioUS,
                                    i.importeMN,
                                    i.importeME,
                                    i.descuentoMN,
                                    i.descuentoME,
                                    i.montokardex,
                                    i.montoIsc,
                                    i.montoIgv,
                                    i.otrosTributos,
                                    i.montokardexUS,
                                    i.montoIscUS,
                                    i.montoIgvUS,
                                    i.otrosTributosUS, Helios.Cont.Business.Entity.BaseBE.EntityAction.UPDATE,
                                    i.tipoExistencia,
                                    i.idAlmacenOrigen,
                                    i.cuentaOrigen,
                                    i.establecimientoOrigen,
                                    i.preEvento,
                                    i.importeMEK, i.unidad2,
                                    i.fechaVcto,
                                    i.monto2,
                                    i.tipoVenta,
                                    i.salidaCostoMN,
                                    i.salidaCostoME)

            Next
            '     lblTotalItems.Text = "Nro. de items: " & dgvNuevoDoc.Rows.Count
            totales_xx()
            TotalesCabeceras()
        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try

    End Sub
#End Region

    Private Sub frmVentaTicketDirecta_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmVentaTicketDirecta_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Dim DocumentoCompraSA As New DocumentoCompraDetalleSA
        toolTip = New Popup(UserControl1)
        toolTip.AutoClose = False
        toolTip.FocusOnOpen = False
        toolTip.ShowingAnimation = PopupAnimations.Blend
        InfoConfiguracion(Sys.Inicio)

        toolTipCaja = New Popup(UcConfigCaja)
        toolTipCaja.AutoClose = False
        toolTipCaja.FocusOnOpen = False
        toolTipCaja.ShowingAnimation = PopupAnimations.Blend
        InfoConfiguracionCaja(Sys.Inicio)

        If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
            cboMoneda.SelectedValue = 1
            rbBoleta.Checked = True
            If Not IsNothing(GFichaUsuarios.NombrePersona) Then

            Else
                dockingClientPanel1.Enabled = False
            End If
            Dim cajaSA As New EstadosFinancierosSA
            With cajaSA.GetUbicar_estadosFinancierosPorID(GFichaUsuarios.IdCajaDestino)
                txtIdCaja = .idestado
                txtCaja = .descripcion
                txtIdEstablecimientoCaja = .idEstablecimiento
                txtCuentaEF = .cuenta
            End With
        Else

        End If

    End Sub

    Private Sub PegarToolStripButton_Click(sender As System.Object, e As System.EventArgs)
        Dispose()
    End Sub

    Private Sub btnConfigCaja_Click(sender As System.Object, e As System.EventArgs) Handles btnConfigCaja.Click
        If Not IsNothing(GFichaUsuarios.NombrePersona) Then
            InfoConfiguracionCaja(Sys.Proceso)
        Else
            With frmFichaUsuarioCaja
                ModuloAppx = ModuloSistema.CAJA
                .lblNivel.Text = "Caja"
                .lblEstadoCaja.Visible = True
                '.GroupBox1.Visible = True
                '.GroupBox2.Visible = True
                '.GroupBox4.Visible = True
                '.cboMoneda.Visible = True
                .Timer1.Enabled = True
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
                If IsNothing(GFichaUsuarios.NombrePersona) Then
                    dockingClientPanel1.Enabled = False
                Else
                    Dim cfecha As Date = Date.Now.Day & "/" & PeriodoGeneral
                    dockingClientPanel1.Enabled = True
                    ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
                    txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
                    Panel8.Visible = False

                    cboMoneda.SelectedValue = 1
                End If
            End With
        End If
    End Sub

    Private Sub btnConfiguracion_Click(sender As System.Object, e As System.EventArgs) Handles btnConfiguracion.Click
        InfoConfiguracion(Sys.Proceso)
    End Sub

    Private Sub btnVer_Click(sender As System.Object, e As System.EventArgs) Handles btnVer.Click
        dockingManager1.SetDockVisibility(PanelCanasta, True)
    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click

    End Sub

    Private Sub txtTipoCambio_ValueChanged(sender As System.Object, e As System.EventArgs) Handles txtTipoCambio.ValueChanged
        If dgvNuevoDoc.Rows.Count > 0 Then
            If txtTipoCambio.Value > 0 Then
                CellEndEditRefresh()
            End If
        End If
    End Sub



    Private Sub pcAlmacen_BeforePopup(sender As System.Object, e As System.ComponentModel.CancelEventArgs)
        Me.pcAlmacen.BackColor = Color.FromArgb(227, 241, 254)
    End Sub


    Private Sub ButtonAdv5_Click(sender As System.Object, e As System.EventArgs)
        Me.pcAlmacen.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub ButtonAdv4_Click(sender As System.Object, e As System.EventArgs)
        Me.pcAlmacen.HidePopup(PopupCloseType.Canceled)
    End Sub





    Private Sub txtCantidad_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub



    Private Sub pcPrecios_BeforePopup(sender As System.Object, e As System.ComponentModel.CancelEventArgs)
        'Me.pcPrecios.BackColor = Color.White
    End Sub
#Region "Métodos Lista Precios"

    Public Sub AgregarAcanasta()
        Me.Cursor = Cursors.WaitCursor

        Dim valTipoVenta As String = Nothing
        Dim valPUmn As Decimal = 0
        Dim valPUme As Decimal = 0
        If rbMenor.Checked = True Then
            valTipoVenta = "MN"
            valPUmn = lblMenor.Value ' .Cells(14).Value
            valPUme = lblMenorME.Value
        ElseIf rbMayor.Checked = True Then
            valTipoVenta = "MY"
            valPUmn = lblMayor.Value ' .Cells(14).Value
            valPUme = lblMayorME.Value ' .Cells(15).Value
        ElseIf rbgmayor.Checked = True Then
            valTipoVenta = "GMY"
            valPUmn = lblGMayor.Value ' .Cells(14).Value
            valPUme = lblGMayorME.Value '.Cells(15).Value
        End If


        dgvNuevoDoc.Rows.Add(0, Me.gridGroupingControl1.Table.CurrentRecord.GetValue("destino"),
                                    Me.gridGroupingControl1.Table.CurrentRecord.GetValue("idItem"),
                                    Me.gridGroupingControl1.Table.CurrentRecord.GetValue("descripcion"),
                                    Me.gridGroupingControl1.Table.CurrentRecord.GetValue("unidad"),
                                    CDec(txtCantidad.Text).ToString("N2"),
                                    Me.gridGroupingControl1.Table.CurrentRecord.GetValue("puKardexmn"),
                                    Me.gridGroupingControl1.Table.CurrentRecord.GetValue("cantidad"),
                                    valPUmn,
                                    valPUme,
                                    CDec(lblTotalMN.Text),
                                    CDec(lblTotalME.Text),
                                    0,
                                    0,
                                    0,
                                    0,
                                    0,
                                    0,
                                    0,
                                    0,
                                    0,
                                    0,
                                    Business.Entity.BaseBE.EntityAction.INSERT,
                                    txtExistencia.Tag,
                                    txtAlmacen.Tag,
                                    Nothing,
                                    GEstableciento.IdEstablecimiento,
                                    Nothing,
                                    Me.gridGroupingControl1.Table.CurrentRecord.GetValue("puKardexme"),
                                    Me.gridGroupingControl1.Table.CurrentRecord.GetValue("idPres"),
                                    Nothing,
                                    Me.gridGroupingControl1.Table.CurrentRecord.GetValue("presentacion"),
                                    valTipoVenta,
                                    0,
                                    0)
        Me.Cursor = Cursors.Arrow
    End Sub
    Private Sub AceptarPrecioProducto(intDisponible As Decimal)
        If txtCantidad.Text.Trim.Length > 0 Then
            If txtCantidad.Text = "." Then
                MsgBox("La cantidad debe ser un número válido.", MsgBoxStyle.Information, "Atención!")
                txtCantidad.Clear()
                txtCantidad.Focus()
            Else
                If txtCantidad.Text > 0 Then
                    If CDec(txtCantidad.Text) > intDisponible Then
                        MsgBox("No hay suficiente cantidad pra realizar la venta, " & vbCrLf & "Verifique la cantidad en su inventario!", MsgBoxStyle.Information, "Atención!")
                        txtCantidad.Focus()
                        txtCantidad.Select(0, txtCantidad.Text.Length)
                    Else
                        AgregarAcanasta()
                    End If
                Else
                    MsgBox("La cantidad debe ser mayor a cero.", MsgBoxStyle.Information, "Atención")
                    txtCantidad.Focus()
                    txtCantidad.Select(0, txtCantidad.Text.Length)
                End If
            End If
        Else
            MsgBox("La cantidad debe ser un número válido.", MsgBoxStyle.Information, "Atención!")
            txtCantidad.Focus()
        End If
    End Sub
    Dim precioSA As New ListadoPrecioSA
    Dim precio As New listadoPrecios
    Public Sub LOadDatos(intIdAlmacen As Integer, intIdItem As Integer)
        precio = precioSA.UbicarVentaPorItem(intIdAlmacen, intIdItem)

        lblMenor.Value = precio.pvmenor.GetValueOrDefault
        lblMenorME.Value = precio.pvmenorme.GetValueOrDefault

        lblMayor.Value = precio.pvmayor.GetValueOrDefault
        lblMayorME.Value = precio.pvmayorme.GetValueOrDefault

        lblGMayor.Value = precio.pvgranmayor.GetValueOrDefault
        lblGMayorME.Value = precio.pvgranmayorme.GetValueOrDefault

    End Sub

    Private Sub ConfiguracionVenta()

        If CDec(Me.gridGroupingControl1.Table.CurrentRecord.GetValue("pvmenor")) = 0 Then
            lblEstado.Text = "El producto no tiene configurado un precio.!!"
            lblEstado.Image = My.Resources.warning2
        Else
            LOadDatos(txtAlmacen.Tag, Me.gridGroupingControl1.Table.CurrentRecord.GetValue("idItem"))

            txtFiltrar.Clear()
            txtFiltrar.Focus()

        End If

    End Sub
#End Region





    Private Sub dgvNuevoDoc_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvNuevoDoc.CellEndEdit
        If dgvNuevoDoc.Rows.Count > 0 Then
            If txtTipoCambio.Value > 0 Then
                'DECLARANDO VARIABLES
                Dim colPrecUnitAlmacen As Decimal = 0 '
                Dim colPrecUnitUSAlmacen As Decimal = 0 '
                colPrecUnitAlmacen = dgvNuevoDoc.Item(6, dgvNuevoDoc.CurrentRow.Index).Value '
                colPrecUnitUSAlmacen = dgvNuevoDoc.Item(28, dgvNuevoDoc.CurrentRow.Index).Value '
                Dim colPrecUnit As Decimal = 0 '
                Dim colPrecUnitUSD As Decimal = 0 '
                Dim colDestinoGravado As Decimal = 0 '
                colPrecUnit = dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value '
                colPrecUnitUSD = dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value '
                colDestinoGravado = dgvNuevoDoc.Item(1, dgvNuevoDoc.CurrentRow.Index).Value '
                Dim colCantidad As Decimal = dgvNuevoDoc.Item(5, dgvNuevoDoc.CurrentRow.Index).Value '
                Dim colCantidadDisponible As Decimal = dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value '
                Dim colBI As Decimal = 0
                Dim colBI_ME As Decimal = 0
                Dim colIGV_ME As Decimal = 0
                Dim colIGV As Decimal = 0
                Dim colMN As Decimal = Math.Round(colCantidad * colPrecUnit, 2)
                Dim colME As Decimal = Math.Round(colCantidad * colPrecUnitUSD, 2)
                Dim colCostoMN As Decimal = Math.Round(colCantidad * colPrecUnitAlmacen, 2)
                Dim colCostoME As Decimal = Math.Round(colCantidad * colPrecUnitUSAlmacen, 2)

                If colCantidad > 0 AndAlso colMN > 0 Then

                    colBI = Math.Round(colMN / 1.18, 2)
                    colBI_ME = Math.Round(colME / 1.18, 2)
                    colIGV = Math.Round((colMN / 1.18) * 0.18, 2) ' Math.Round(colBI * 0.18, 2)
                    colIGV_ME = Math.Round((colME / 1.18) * 0.18, 2) ' Math.Round(colBI_ME * 0.18, 2)

                Else

                    colBI = 0
                    colBI_ME = 0
                    colIGV = 0
                    colIGV_ME = 0

                End If

                Select Case dgvNuevoDoc.Columns(e.ColumnIndex).Name
                    Case "Can1"
                        If colCantidad > colCantidadDisponible Then
                            MsgBox("Debe ingresar un monto, " & vbCrLf & "que no supere la cantidad disponible.", MsgBoxStyle.Information, "Atención!")
                            dgvNuevoDoc.Item(5, dgvNuevoDoc.CurrentRow.Index).Value = 0
                            Exit Sub
                        Else

                            dgvNuevoDoc.Item(5, dgvNuevoDoc.CurrentRow.Index).Value = colCantidad.ToString("N2")

                        End If
                End Select
                Dim valor As Decimal = 0
                Dim NUDIGV_VALUE As Decimal = 0

                If cboMoneda.SelectedValue = 1 Then
                    Select Case colDestinoGravado
                        Case 1
                            NUDIGV_VALUE = Math.Round((txtIgv.Value / 100) + 1, 2)
                            If dgvNuevoDoc.Columns(e.ColumnIndex).Name = "Can1" Then

                                If Not IsNothing(colMN) Then
                                    dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnit.ToString("N2") 'prec unit usd
                                    dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnitUSD.ToString("N2") 'prec unit usd

                                    dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = colMN.ToString("N2")
                                    dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() = colME.ToString("N2") ' MONTO TOTAL DOLARES
                                    dgvNuevoDoc.Item(14, dgvNuevoDoc.CurrentRow.Index).Value() = colBI.ToString("N2") ' monto para el kardex
                                    dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value() = colIGV.ToString("N2") ' monto igv del item
                                    dgvNuevoDoc.Item(18, dgvNuevoDoc.CurrentRow.Index).Value() = colBI_ME.ToString("N2")  ' monto para el kardex USD
                                    dgvNuevoDoc.Item(20, dgvNuevoDoc.CurrentRow.Index).Value() = colIGV_ME.ToString("N2")   ' monto para el kardex USD

                                    dgvNuevoDoc.Item(33, dgvNuevoDoc.CurrentRow.Index).Value() = colCostoMN.ToString("N2")
                                    dgvNuevoDoc.Item(34, dgvNuevoDoc.CurrentRow.Index).Value() = colCostoME.ToString("N2")
                                End If

                            ElseIf dgvNuevoDoc.Columns(e.ColumnIndex).Name = "ImporteNeto" Then

                                dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnit.ToString("N2") 'prec unit usd
                                dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnitUSD.ToString("N2") 'prec unit usd

                                dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = colMN.ToString("N2")
                                dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() = colME.ToString("N2") ' MONTO TOTAL DOLARES
                                dgvNuevoDoc.Item(14, dgvNuevoDoc.CurrentRow.Index).Value() = colBI.ToString("N2") ' monto para el kardex
                                dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value() = colIGV.ToString("N2") ' monto igv del item
                                dgvNuevoDoc.Item(18, dgvNuevoDoc.CurrentRow.Index).Value() = colBI_ME.ToString("N2")  ' monto para el kardex USD
                                dgvNuevoDoc.Item(20, dgvNuevoDoc.CurrentRow.Index).Value() = colIGV_ME.ToString("N2")   ' monto para el kardex USD

                                dgvNuevoDoc.Item(33, dgvNuevoDoc.CurrentRow.Index).Value() = colCostoMN.ToString("N2")
                                dgvNuevoDoc.Item(34, dgvNuevoDoc.CurrentRow.Index).Value() = colCostoME.ToString("N2")


                            End If


                        Case 2
                            NUDIGV_VALUE = "0.00" 'Math.Round((nudIgv.Value / 100) + 1, 2)
                            If dgvNuevoDoc.Columns(e.ColumnIndex).Name = "Can1" Then

                                If Not IsNothing(colMN) Then
                                    dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnit.ToString("N2") 'prec unit usd
                                    dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnitUSD.ToString("N2") 'prec unit usd

                                    dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = colMN.ToString("N2")
                                    dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() = colME.ToString("N2") ' MONTO TOTAL DOLARES
                                    dgvNuevoDoc.Item(14, dgvNuevoDoc.CurrentRow.Index).Value() = colMN.ToString("N2")
                                    dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' monto igv del item
                                    dgvNuevoDoc.Item(18, dgvNuevoDoc.CurrentRow.Index).Value() = colME.ToString("N2")  ' monto para el kardex USD
                                    dgvNuevoDoc.Item(20, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"

                                    dgvNuevoDoc.Item(33, dgvNuevoDoc.CurrentRow.Index).Value() = colCostoMN.ToString("N2")
                                    dgvNuevoDoc.Item(34, dgvNuevoDoc.CurrentRow.Index).Value() = colCostoME.ToString("N2")

                                End If

                            ElseIf dgvNuevoDoc.Columns(e.ColumnIndex).Name = "ImporteNeto" Then

                                dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnit.ToString("N2") 'prec unit usd
                                dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnitUSD.ToString("N2") 'prec unit usd

                                dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = colMN.ToString("N2")
                                dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() = colME.ToString("N2") ' MONTO TOTAL DOLARES
                                dgvNuevoDoc.Item(14, dgvNuevoDoc.CurrentRow.Index).Value() = colMN.ToString("N2")
                                dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' monto igv del item
                                dgvNuevoDoc.Item(18, dgvNuevoDoc.CurrentRow.Index).Value() = colME.ToString("N2")  ' monto para el kardex USD
                                dgvNuevoDoc.Item(20, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"

                                dgvNuevoDoc.Item(33, dgvNuevoDoc.CurrentRow.Index).Value() = colCostoMN.ToString("N2")
                                dgvNuevoDoc.Item(34, dgvNuevoDoc.CurrentRow.Index).Value() = colCostoME.ToString("N2")

                            End If

                    End Select
                    totales_xx()
                    TotalesCabeceras()
                Else
                    'IMPLEMENTAR CODIGO PARA MONEDA EXTRANJERA
                End If

            Else
                MsgBox("Ingrese un tipo de cambio mayor a cero", MsgBoxStyle.Information, "Atención!")
                txtTipoCambio.Focus()
                txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
            End If

        End If
    End Sub

    Private Sub dgvNuevoDoc_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvNuevoDoc.CellFormatting
        If e.RowIndex > -1 Then
            If e.ColumnIndex = Me.dgvNuevoDoc.Columns("Gravado").Index _
    AndAlso (e.Value IsNot Nothing) Then

                With Me.dgvNuevoDoc.Rows(e.RowIndex).Cells(e.ColumnIndex)
                    If e.Value.Equals("1") Then
                        .ToolTipText = "1: ADQ. AFECTOS AL I.G.V."
                    ElseIf e.Value.Equals("2") Then
                        .ToolTipText = "2: ADQ. NO AFECTOS AL I.G.V."
                    End If

                End With

            End If
        End If
    End Sub

    Private Sub dgvNuevoDoc_CurrentCellDirtyStateChanged(sender As Object, e As System.EventArgs) Handles dgvNuevoDoc.CurrentCellDirtyStateChanged
        Try
            If dgvNuevoDoc.IsCurrentCellDirty Then
                dgvNuevoDoc.CommitEdit(DataGridViewDataErrorContexts.Commit)
            End If

            If TypeOf dgvNuevoDoc.CurrentCell Is DataGridViewCheckBoxCell Then
                dgvNuevoDoc.CommitEdit(DataGridViewDataErrorContexts.Commit)
            End If


        Catch
        End Try
    End Sub

    Private Sub dgvNuevoDoc_EditingControlShowing(sender As Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvNuevoDoc.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf Validar_Numeros
    End Sub

    Private Sub dgvNuevoDoc_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgvNuevoDoc.KeyDown
        Dim conteo As Integer = dgvNuevoDoc.Rows.Count
        Try
            If e.KeyCode = Keys.Enter Then
                Select Case (dgvNuevoDoc.CurrentCell.ColumnIndex)
                    Case 5
                        If cboMoneda.SelectedValue Then
                            If conteo = 1 Then
                                Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc(10, Me.dgvNuevoDoc.CurrentCell.RowIndex)
                            Else
                                Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc(10, Me.dgvNuevoDoc.CurrentCell.RowIndex)
                            End If
                        Else
                            If conteo = 1 Then
                                Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc(11, Me.dgvNuevoDoc.CurrentCell.RowIndex)
                            Else
                                Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc(11, Me.dgvNuevoDoc.CurrentCell.RowIndex)
                            End If
                        End If

                End Select
                e.SuppressKeyPress = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgvNuevoDoc_RowPostPaint(sender As Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgvNuevoDoc.RowPostPaint
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

    Private Sub btnAsignarPrecio_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub btnConfigCaja_MouseLeave(sender As Object, e As System.EventArgs) Handles btnConfigCaja.MouseLeave
        toolTipCaja.Close()
    End Sub

    Private Sub btnConfiguracion_MouseLeave(sender As Object, e As System.EventArgs) Handles btnConfiguracion.MouseLeave
        toolTip.Close()
    End Sub

    Private Sub GuardarToolStripButton_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
            fecha = New DateTime(txtFechaComprobante.Value.Year, txtFechaComprobante.Value.Month, txtFechaComprobante.Value.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        Else
            fecha = New DateTime(fecha.Year, fecha.Month, txtFechaComprobante.Value.Day, txtFechaComprobante.Value.Hour, txtFechaComprobante.Value.Minute, txtFechaComprobante.Value.Second)
        End If
    End Sub


    Private Sub ListView1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub txtFiltrar_TextChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub dgvNuevoDoc_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvNuevoDoc.CellContentClick

    End Sub






    Private Sub btnAsignarPrecio_Click_1(sender As Object, e As EventArgs) Handles btnAsignarPrecio.Click

    End Sub

    Private Sub gridGroupingControl1_TableControlCellClick(sender As Object, e As Grid.Grouping.GridTableControlCellClickEventArgs) Handles gridGroupingControl1.TableControlCellClick

    End Sub

    Private Sub txtFiltrar_KeyDown(sender As Object, e As KeyEventArgs)
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtAlmacen.Text.Trim.Length > 0 Then
                If txtFiltrar.Text.Trim.Length > 0 Then

                    ObtenerCanastaVentaFiltro(txtAlmacen.Tag, txtExistencia.Tag, txtFiltrar.Text.Trim)
                    lblEstado.Text = "productos encontrados: " & gridGroupingControl1.Table.Records.Count
                    lblEstado.Image = My.Resources.ok4
                Else
                    lblEstado.Text = "Digitar un producto válido!"
                    lblEstado.Image = My.Resources.warning2
                End If
            Else
                lblEstado.Text = "Debe ingresar un almacén válido"
                txtAlmacen.Select()
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lstAlmacen_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstAlmacen.MouseDoubleClick
        If lstAlmacen.SelectedItems.Count > 0 Then
            Me.pcAlmacen.HidePopup(PopupCloseType.Done)
        End If
    End Sub






    Private Sub dropDownBtn_Click(sender As Object, e As EventArgs)
        pcAlmacen.Font = New Font("Tahoma", 8)
        pcAlmacen.Size = New Size(260, 110)
        Me.pcAlmacen.ParentControl = Me.txtAlmacen
        Me.pcAlmacen.ShowPopup(Point.Empty)
    End Sub

    Private Sub pcAlmacen_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcAlmacen.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lstAlmacen.SelectedItems.Count > 0 Then
                Me.txtAlmacen.Tag = lstAlmacen.SelectedValue
                txtAlmacen.Text = lstAlmacen.Text

                gridGroupingControl1.Table.Records.DeleteAll()

            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtAlmacen.Focus()
        End If
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs)
        lblProducto.Text = String.Empty
    End Sub


    Private Sub txtCantidad_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCantidad.KeyDown
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True

                If Not IsNothing(Me.gridGroupingControl1.Table.CurrentRecord) Then
                    lblProducto.Text = String.Empty
                    AceptarPrecioProducto(Me.gridGroupingControl1.Table.CurrentRecord.GetValue("cantidad"))
                    If dgvNuevoDoc.Rows.Count > 0 Then
                        If txtTipoCambio.Value > 0 Then
                            CellEndEditRefresh()
                        End If

                    End If
                End If
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtCantidad_KeyPress1(sender As Object, e As KeyPressEventArgs) Handles txtCantidad.KeyPress
        Dim KeyAscii As Short = CShort(Asc(e.KeyChar))
        KeyAscii = CShort(SoloNumeros(KeyAscii))
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub


    Private Sub txtCantidad_TextChanged(sender As Object, e As EventArgs) Handles txtCantidad.TextChanged
        If txtCantidad.Text.Trim.Length > 0 Then
            If txtCantidad.Text = "." Then
                MsgBox("Ingrese un valor válido!", MsgBoxStyle.Information, "Atención!")
                txtCantidad.Clear()
                txtCantidad.Focus()
            Else
                calculos()
            End If
        End If
    End Sub

    Private Sub gridGroupingControl1_TableControlCellDoubleClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles gridGroupingControl1.TableControlCellDoubleClick

    End Sub

    Private Sub gridGroupingControl1_TableControlCurrentCellControlDoubleClick(sender As Object, e As GridTableControlControlEventArgs) Handles gridGroupingControl1.TableControlCurrentCellControlDoubleClick
        Me.Cursor = Cursors.WaitCursor
        If CDec(Me.gridGroupingControl1.Table.CurrentRecord.GetValue("pvmenor")) > 0 Then
            LOadDatos(txtAlmacen.Tag, CInt(Me.gridGroupingControl1.Table.CurrentRecord.GetValue("idItem")))

            txtBuscarProducto.Text = Me.gridGroupingControl1.Table.CurrentRecord.GetValue("descripcion")
            txtBuscarProducto.Tag = Me.gridGroupingControl1.Table.CurrentRecord.GetValue("idItem")
            txtCantidad.Text = 0
            txtCantidad.Focus()
            txtCantidad.Select(0, txtCantidad.Text.Length)

        Else
            lblEstado.Text = "El producto seleccionado no tiene un precio de venta!"
            lblEstado.Image = My.Resources.warning2
            txtBuscarProducto.Text = String.Empty
            txtBuscarProducto.Tag = String.Empty
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStrip2_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip2.ItemClicked

    End Sub

    Private Sub txtFiltrar_TextChanged_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub

    Private Sub lstAlmacen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstAlmacen.SelectedIndexChanged

    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btGrabar_Click(sender As Object, e As EventArgs) Handles btGrabar.Click
        Me.Cursor = Cursors.WaitCursor
        If txtCliente.Text.Trim.Length > 0 Then
            'Me.lblEstado.Image = My.Resources.ok4  ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\warning2.png")
            Me.lblEstado.Text = "Done comprador!"
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)
        Else
            'Me.lblEstado.Image = My.Resources.warning2   ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\warning2.png")
            Me.lblEstado.Text = "Ingrese el nombre del comprador!"
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If

        If dgvNuevoDoc.Rows.Count > 0 Then
            Me.lblEstado.Image = My.Resources.ok4 ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\ok.ico")
            Me.lblEstado.Text = "Done!"
            If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
                If (CDec(txtTotalPedidomn.Text) <= CDec(GFichaUsuarios.FondoMN)) Then
                    Grabar()
                Else
                    lblEstado.Text = "La compra debe ser menor a S/." & GFichaUsuarios.FondoMN
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)
                    'lblEstado.Image = My.Resources.warning2
                End If

            Else
                Dim Filas As Integer = dgvNuevoDoc.DisplayedRowCount(True)
                If Filas > 0 Then
                    If (CDec(txtTotalPedidomn.Text) <= CDec(GFichaUsuarios.FondoMN + ReferenciaFondoMN)) Then
                        UpdateVenta()
                    Else
                        lblEstado.Text = "No debe exceder el monto de S/." & CDec(GFichaUsuarios.FondoMN + ReferenciaFondoMN)
                        Timer1.Enabled = True
                        PanelError.Visible = True
                        TiempoEjecutar(10)
                        'lblEstado.Image = My.Resources.warning2
                    End If
                Else
                    ' Me.lblEstado.Image = My.Resources.warning2 ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\warning2.png")
                    Me.lblEstado.Text = "Ingrese items a la canasta de compra!"
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)
                    'Timer1.Enabled = True
                    'TiempoEjecutar(5)
                End If
            End If



            '    Grabar()
            'Else
            '    Dim Filas As Integer = dgvNuevoDoc.DisplayedRowCount(True)
            '    If Filas > 0 Then
            '        UpdateVenta()
            '    Else
            '        Me.lblEstado.Image = My.Resources.warning2 ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\warning2.png")
            '        Me.lblEstado.Text = "Ingrese items a la canasta de compra!"
            '        Me.Cursor = Cursors.Arrow
            '    End If
            'End If

        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        If dgvNuevoDoc.Rows.Count > 0 Then

            If Not IsNothing(dgvNuevoDoc.CurrentRow) Then

                If dgvNuevoDoc.Item(22, dgvNuevoDoc.CurrentRow.Index).Value = Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT Then
                    dgvNuevoDoc.Rows.RemoveAt(dgvNuevoDoc.CurrentCell.RowIndex)
                    If dgvNuevoDoc.Rows.Count > 0 Then
                        CellEndEditRefresh()
                    Else
                        nudBase1 = 0.0
                        nudBaseus1 = 0.0
                        nudBase2 = 0.0
                        nudBaseus2 = 0.0

                        nudMontoIgv1 = 0.0
                        nudMontoIgvus1 = 0.0
                        nudMontoIgv2 = 0.0
                        nudMontoIgvus2 = 0.0

                        txtTotalBImn.Text = 0.0
                        txtTotalBIme.Text = 0.0


                        txtMontoIGVmn.Text = 0.0
                        txtMontoIGVme.Text = 0.0

                        txtTotalPedidomn.Text = 0.0
                        txtTotalPedidome.Text = 0.0
                    End If
                ElseIf dgvNuevoDoc.Item(22, dgvNuevoDoc.CurrentRow.Index).Value = Helios.Cont.Business.Entity.BaseBE.EntityAction.UPDATE Then

                    dgvNuevoDoc.Item(22, dgvNuevoDoc.CurrentRow.Index).Value = Helios.Cont.Business.Entity.BaseBE.EntityAction.DELETE
                    Dim pos As Integer = Me.dgvNuevoDoc.CurrentRow.Index

                    dgvNuevoDoc.CurrentCell = Nothing
                    Me.dgvNuevoDoc.Rows(pos).Visible = False

                End If
                If dgvNuevoDoc.Rows.Count > 0 Then
                    CellEndEditRefresh()
                End If
            End If
        End If
    End Sub

    Private Sub txtCliente_TextChanged(sender As Object, e As EventArgs) Handles txtCliente.TextChanged
        If txtCliente.Text.Trim.Length > 0 Then
            lblComprador.Text = txtCliente.Text
        Else
            lblComprador.Text = String.Empty
        End If
    End Sub

    Private Sub txtFiltrar_KeyDown1(sender As Object, e As KeyEventArgs) Handles txtFiltrar.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtAlmacen.Text.Trim.Length > 0 Then
                If txtFiltrar.Text.Trim.Length > 0 Then
                    ' ObtenerCanastaVenta(txtIDAlmacen.Text, txtIdExistencia.Text)
                    ObtenerCanastaVentaFiltro(txtAlmacen.Tag, txtExistencia.Tag, txtFiltrar.Text.Trim)
                    lblEstado.Text = "productos encontrados: " & gridGroupingControl1.Table.Records.Count

                Else
                    lblEstado.Text = "Digitar un producto válido!"

                End If
            Else
                lblEstado.Text = "Debe ingresar un almacén válido"
                txtAlmacen.Select()
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtFiltrar_TextChanged_2(sender As Object, e As EventArgs) Handles txtFiltrar.TextChanged

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        PanelError.Visible = False
        Timer1.Enabled = False
    End Sub

    Private Sub dropDownBtn_Click_1(sender As Object, e As EventArgs) Handles dropDownBtn.Click
        pcAlmacen.Font = New Font("Tahoma", 8)
        pcAlmacen.Size = New Size(260, 110)
        Me.pcAlmacen.ParentControl = Me.txtAlmacen
        Me.pcAlmacen.ShowPopup(Point.Empty)
    End Sub
    'Public Sub configuracionModulo(strIDEmpresa As String, strIdModulo As String, strNomModulo As String, intIdEstablecimiento As Integer)
    '    Dim moduloConfiguracionSA As New ModuloConfiguracionSA
    '    Dim moduloConfiguracion As New moduloConfiguracion
    '    Dim numeracionSA As New NumeracionBoletaSA
    '    Dim TablaSA As New tablaDetalleSA
    '    Dim almacenSA As New almacenSA
    '    Dim cajaSA As New EstadosFinancierosSA

    '    moduloConfiguracion = moduloConfiguracionSA.UbicarConfiguracionPorEmpresaModulo(strIdModulo, strIDEmpresa, intIdEstablecimiento)
    '    If Not IsNothing(moduloConfiguracion) Then
    '        With moduloConfiguracion
    '            GConfiguracion2 = New GConfiguracionModulo
    '            GConfiguracion2.IdModulo = .idModulo
    '            GConfiguracion2.NomModulo = strNomModulo
    '            GConfiguracion2.TipoConfiguracion = .tipoConfiguracion
    '            Select Case .tipoConfiguracion
    '                Case "P"
    '                    With numeracionSA.GetUbicar_numeracionBoletasPorID(.configComprobante)
    '                        GConfiguracion2.ConfigComprobante = .IdEnumeracion

    '                        If rbBoleta.Checked = True Then
    '                            GConfiguracion2.TipoComprobante = .tipo
    '                            GConfiguracion2.NombreComprobante = TablaSA.GetUbicarTablaID(10, .tipo).descripcion
    '                            GConfiguracion2.Serie = .serie
    '                            GConfiguracion2.ValorActual = .valorInicial
    '                            SerieTicket = .serie
    '                            TipoDocVenta = GConfiguracion2.NombreComprobante
    '                        End If


    '                        If rbFactura.Checked = True Then
    '                            GConfiguracion2.TipoComprobante = .tipo1
    '                            GConfiguracion2.NombreComprobante = TablaSA.GetUbicarTablaID(10, .tipo1).descripcion
    '                            GConfiguracion2.Serie = .serie1
    '                            GConfiguracion2.ValorActual = .valorInicial1
    '                            SerieTicket = .serie1
    '                            TipoDocVenta = GConfiguracion2.NombreComprobante
    '                        End If
    '                        'txtSerieComp.Visible = True
    '                        'txtSerieComp.Text = .serie
    '                        'txtNumeroComp.Visible = False
    '                        'IIf(rbBoleta.Checked = True, "12.1", "12.2").Text = GConfiguracion.TipoComprobante
    '                        'txtComprobante.Text = GConfiguracion.NombreComprobante
    '                        'LinkTipoDoc.Enabled = False
    '                        'txtSerieComp.Enabled = False
    '                    End With
    '                Case "M"
    '                    'txtSerieComp.Visible = True
    '                    'txtNumeroComp.Visible = True
    '                    'LinkTipoDoc.Enabled = True
    '                    'txtSerieComp.Enabled = True
    '            End Select
    '            If Not IsNothing(.configAlmacen) Then
    '                Dim estableSA As New establecimientoSA
    '                With almacenSA.GetUbicar_almacenPorID(.configAlmacen)
    '                    GConfiguracion2.IdAlmacen = .idAlmacen
    '                    GConfiguracion2.NombreAlmacen = .descripcionAlmacen

    '                    'txtAlmacen.Text = GConfiguracion.NombreAlmacen
    '                    'txtIdAlmacen.Text = GConfiguracion.IdAlmacen
    '                    'With estableSA.UbicaEstablecimientoPorID(.idEstablecimiento)
    '                    '    'txtIdEstableAlmacen.Text = .idCentroCosto
    '                    '    'txtEstableAlmacen.Text = .nombre
    '                    'End With
    '                End With
    '            End If
    '            If Not IsNothing(.ConfigentidadFinanciera) Then
    '                With cajaSA.GetUbicar_estadosFinancierosPorID(.ConfigentidadFinanciera)
    '                    GConfiguracion2.IDCaja = .idestado
    '                    GConfiguracion2.NomCaja = .descripcion
    '                End With
    '            End If

    '        End With
    '    Else
    '        lblEstado.Text = "Este módulo no contiene una configuración disponible, intentelo más tarde.!"
    '        'Timer1.Enabled = True
    '        'TabCompra.Enabled = False
    '        'TiempoEjecutar(5)
    '    End If
    'End Sub

    Public Sub configuracionModuloV2(strIDEmpresa As String, strIdModulo As String, strNomModulo As String, intIdEstablecimiento As Integer)
        Try

            Dim moduloConfiguracionSA As New ModuloConfiguracionSA
            Dim moduloConfiguracion As New moduloConfiguracion
            Dim numeracionSA As New NumeracionBoletaSA
            Dim TablaSA As New tablaDetalleSA
            Dim almacenSA As New almacenSA
            Dim cajaSA As New EstadosFinancierosSA

            Dim RecuperacionNumeracion = numeracionSA.GetUbicar_numeracionBoletasXUnidadNegocio(New numeracionBoletas With {.empresa = strIDEmpresa, .establecimiento = intIdEstablecimiento, .codigoNumeracion = strIdModulo, .estado = "A"})

            If (Not IsNothing(RecuperacionNumeracion)) Then
                GConfiguracion = New GConfiguracionModulo
                GConfiguracion.ConfigComprobante = CInt(RecuperacionNumeracion.IdEnumeracion)
                If rbBoleta.Checked = True Then
                    GConfiguracion.TipoComprobante = RecuperacionNumeracion.tipo
                    GConfiguracion.NombreComprobante = TablaSA.GetUbicarTablaID(10, RecuperacionNumeracion.tipo).descripcion
                    GConfiguracion.Serie = RecuperacionNumeracion.serie
                    GConfiguracion.ValorActual = RecuperacionNumeracion.valorInicial
                    SerieTicket = RecuperacionNumeracion.serie
                    TipoDocVenta = GConfiguracion.NombreComprobante
                End If


                If rbFactura.Checked = True Then
                    GConfiguracion.TipoComprobante = RecuperacionNumeracion.tipo1
                    GConfiguracion.NombreComprobante = TablaSA.GetUbicarTablaID(10, RecuperacionNumeracion.tipo1).descripcion
                    GConfiguracion.Serie = RecuperacionNumeracion.serie1
                    GConfiguracion.ValorActual = RecuperacionNumeracion.valorInicial1
                    SerieTicket = RecuperacionNumeracion.serie1
                    TipoDocVenta = GConfiguracion.NombreComprobante
                End If
            Else
                Throw New Exception("Verificar configuración")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub rbBoleta_CheckedChanged(sender As Object, e As EventArgs) Handles rbBoleta.CheckedChanged
        Me.Cursor = Cursors.WaitCursor
        If rbBoleta.Checked = True Then
            GConfiguracion = New GConfiguracionModulo
            configuracionModuloV2(Gempresas.IdEmpresaRuc, "VT2", Me.Text, GEstableciento.IdEstablecimiento)

        End If
        Me.Cursor = Cursors.Arrow

        If rbBoleta.Checked = True Then
            Label19.Visible = False
            txtProveedor.Visible = False
            Label13.Visible = False
            Label15.Visible = False
            txtRuc.Visible = False
            txtCuenta.Visible = False
            PictureBox2.Visible = False
        End If

    End Sub

    Private Sub rbFactura_CheckedChanged(sender As Object, e As EventArgs) Handles rbFactura.CheckedChanged
        Me.Cursor = Cursors.WaitCursor
        If rbFactura.Checked = True Then
            GConfiguracion = New GConfiguracionModulo
            configuracionModuloV2(Gempresas.IdEmpresaRuc, "VT2", Me.Text, GEstableciento.IdEstablecimiento)
        End If
        Me.Cursor = Cursors.Arrow

        If rbFactura.Checked = True Then
            Label19.Visible = True
            txtProveedor.Visible = True
            Label13.Visible = True
            Label15.Visible = True
            txtRuc.Visible = True
            txtCuenta.Visible = True
            PictureBox2.Visible = True
        End If
    End Sub

    Private Sub txtProveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProveedor.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Me.popupControlContainer1.ParentControl = Me.txtProveedor
            Me.popupControlContainer1.ShowPopup(Point.Empty)
            CargarEntidadesXtipo(TIPO_ENTIDAD.CLIENTE, txtProveedor.Text.Trim)
        End If
    End Sub

    Private Sub txtProveedor_TextChanged(sender As Object, e As EventArgs) Handles txtProveedor.TextChanged

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        txtDocProveedor.Clear()
        txtNomProv.Clear()
        txtApePat.Clear()
        txtDocProveedor.Select()
        rbNatural.Checked = True
        pcProveedor.Font = New Font("Tahoma", 8)
        pcProveedor.Size = New Size(321, 252)
        Me.pcProveedor.ParentControl = Me.txtProveedor
        Me.pcProveedor.ShowPopup(Point.Empty)
    End Sub

    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvProveedor.MouseDoubleClick
        If lsvProveedor.SelectedItems.Count > 0 Then
            Me.popupControlContainer1.HidePopup(PopupCloseType.Done)

            'txtAlmacen.Select()
        End If
    End Sub

    Private Sub lsvProveedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvProveedor.SelectedIndexChanged

    End Sub

    Private Sub popupControlContainer1_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles popupControlContainer1.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvProveedor.SelectedItems.Count > 0 Then
                Me.txtProveedor.Text = lsvProveedor.SelectedItems(0).SubItems(1).Text
                txtProveedor.ValueMember = lsvProveedor.SelectedItems(0).SubItems(0).Text
                txtRuc.Text = lsvProveedor.SelectedItems(0).SubItems(3).Text
                txtCuenta.Text = lsvProveedor.SelectedItems(0).SubItems(2).Text
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtProveedor.Focus()
        End If
    End Sub

    Private Sub popupControlContainer1_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles popupControlContainer1.BeforePopup
        Me.popupControlContainer1.BackColor = Color.FromArgb(227, 241, 254)
    End Sub

    Private Sub btnRuc_Click(sender As Object, e As EventArgs) Handles btnRuc.Click
        btnRuc.Checked = True
        If btnRuc.Checked = True Then
            btnDni.Checked = False
            btnPassport.Checked = False
            btnCarnetEx.Checked = False
        End If
    End Sub

    Private Sub btnDni_Click(sender As Object, e As EventArgs) Handles btnDni.Click
        btnDni.Checked = True
        If btnDni.Checked = True Then
            btnRuc.Checked = False
            btnPassport.Checked = False
            btnCarnetEx.Checked = False
        End If
    End Sub

    Private Sub btnPassport_Click(sender As Object, e As EventArgs) Handles btnPassport.Click
        btnPassport.Checked = True
        If btnPassport.Checked = True Then
            btnRuc.Checked = False
            btnDni.Checked = False
            btnCarnetEx.Checked = False
        End If
    End Sub

    Private Sub btnCarnetEx_Click(sender As Object, e As EventArgs) Handles btnCarnetEx.Click
        btnCarnetEx.Checked = True
        If btnCarnetEx.Checked = True Then
            btnRuc.Checked = False
            btnDni.Checked = False
            btnPassport.Checked = False
        End If
    End Sub

    Private Sub btnGRabarProv_Click(sender As Object, e As EventArgs) Handles btnGRabarProv.Click
        If Not txtDocProveedor.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese el nro de documento del cliente"
            pcProveedor.Font = New Font("Tahoma", 8)
            pcProveedor.Size = New Size(321, 252)
            Me.pcProveedor.ParentControl = Me.txtProveedor
            Me.pcProveedor.ShowPopup(Point.Empty)
            txtDocProveedor.Select()
            Exit Sub
        End If

        If Not txtNomProv.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese el nombre del cliente"
            pcProveedor.Font = New Font("Tahoma", 8)
            pcProveedor.Size = New Size(321, 252)
            Me.pcProveedor.ParentControl = Me.txtProveedor
            Me.pcProveedor.ShowPopup(Point.Empty)
            txtNomProv.Select()
            Exit Sub
        End If

        If rbNatural.Checked = True Then
            If Not txtApePat.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese los apellidos del cliente"
                pcProveedor.Font = New Font("Tahoma", 8)
                pcProveedor.Size = New Size(321, 252)
                Me.pcProveedor.ParentControl = Me.txtProveedor
                Me.pcProveedor.ShowPopup(Point.Empty)
                txtApePat.Select()
                Exit Sub
            End If
        End If
        btnGRabarProv.Tag = "G"
        Me.pcProveedor.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub pcProveedor_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles pcProveedor.BeforePopup
        Me.pcProveedor.BackColor = Color.White
    End Sub

    Private Sub pcProveedor_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcProveedor.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If Not txtDocProveedor.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese el nro de documento del cliente"
                pcProveedor.Font = New Font("Tahoma", 8)
                pcProveedor.Size = New Size(321, 252)
                Me.pcProveedor.ParentControl = Me.txtProveedor
                Me.pcProveedor.ShowPopup(Point.Empty)
                txtDocProveedor.Select()
                Exit Sub
            End If

            If Not txtNomProv.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese el nombre del cliente"
                pcProveedor.Font = New Font("Tahoma", 8)
                pcProveedor.Size = New Size(321, 252)
                Me.pcProveedor.ParentControl = Me.txtProveedor
                Me.pcProveedor.ShowPopup(Point.Empty)
                txtNomProv.Select()
                Exit Sub
            End If

            If rbNatural.Checked = True Then
                If Not txtApePat.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Ingrese los apellidos del cliente"
                    pcProveedor.Font = New Font("Tahoma", 8)
                    pcProveedor.Size = New Size(321, 252)
                    Me.pcProveedor.ParentControl = Me.txtProveedor
                    Me.pcProveedor.ShowPopup(Point.Empty)
                    txtApePat.Select()
                    Exit Sub
                End If
            End If
            If btnGRabarProv.Tag = "G" Then
                InsertProveedor()
                btnGRabarProv.Tag = "N"
            Else
                pcProveedor.Font = New Font("Tahoma", 8)
                pcProveedor.Size = New Size(321, 252)
                Me.pcProveedor.ParentControl = Me.txtProveedor
                Me.pcProveedor.ShowPopup(Point.Empty)
            End If

        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtProveedor.Focus()
        End If
    End Sub

    Private Sub rbNatural_CheckChanged(sender As Object, e As EventArgs) Handles rbNatural.CheckChanged
        If rbNatural.Checked = True Then
            txtNomProv.Visible = True
            txtNomProv.Clear()
            txtApePat.Visible = True
            txtApePat.Clear()
            Label31.Visible = True
            txtNomProv.Select()
            Label30.Text = "Nombres:"
        End If
    End Sub

    Private Sub rbJuridico_CheckChanged(sender As Object, e As EventArgs) Handles rbJuridico.CheckChanged
        If rbJuridico.Checked = True Then
            txtNomProv.Visible = True
            txtNomProv.Clear()
            txtApePat.Visible = False
            txtApePat.Clear()
            Label31.Visible = False
            txtNomProv.Select()
            Label30.Text = "Nombre o Razón Social:"
        End If
    End Sub

    Private Sub btnAprobar_Click(sender As Object, e As EventArgs) Handles btnAprobar.Click

    End Sub

    Private Sub ButtonAdv1_Click_1(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        If Not IsNothing(Me.gridGroupingControl1.Table.CurrentRecord) Then
            With frmInsertarPrecio

                .txtid.Text = (Me.gridGroupingControl1.Table.CurrentRecord.GetValue("idItem"))
                .txtDescripcion.Text = (Me.gridGroupingControl1.Table.CurrentRecord.GetValue("descripcion"))
                .txtxmenor.Text = (Me.gridGroupingControl1.Table.CurrentRecord.GetValue("pvmenor"))
                .txtxmayor.Text = (Me.gridGroupingControl1.Table.CurrentRecord.GetValue("pvmayor"))
                .txtxgranmayor.Text = (Me.gridGroupingControl1.Table.CurrentRecord.GetValue("pvGmayor"))
                .txtalmacen.Text = txtAlmacen.Tag
                .StartPosition = FormStartPosition.CenterParent
                '.WindowState = FormWindowState.Maximized
                .ShowDialog()

            End With

        Else
            MessageBox.Show("seleccione un item")
        End If
    End Sub

    Private Sub ButtonAdv2_Click_1(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Me.Cursor = Cursors.WaitCursor
        'If e.KeyCode = Keys.Enter Then
        '    e.SuppressKeyPress = True
        If txtAlmacen.Text.Trim.Length > 0 Then
            If txtFiltrar.Text.Trim.Length > 0 Then
                ' ObtenerCanastaVenta(txtIDAlmacen.Text, txtIdExistencia.Text)
                ObtenerCanastaVentaFiltro(txtAlmacen.Tag, txtExistencia.Tag, txtFiltrar.Text.Trim)
                lblEstado.Text = "productos encontrados: " & gridGroupingControl1.Table.Records.Count
                lblEstado.Image = My.Resources.ok4
            Else
                lblEstado.Text = "Digitar un producto válido!"
                lblEstado.Image = My.Resources.warning2
            End If
        Else
            lblEstado.Text = "Debe ingresar un almacén válido"
            txtAlmacen.Select()
        End If
        ' End If
        Me.Cursor = Cursors.Arrow
    End Sub
End Class