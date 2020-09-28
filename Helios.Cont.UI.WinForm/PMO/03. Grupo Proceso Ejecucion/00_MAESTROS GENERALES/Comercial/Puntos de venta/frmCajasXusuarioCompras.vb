Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Public Class frmCajasXusuarioCompras
    Inherits frmMaster

    Dim colorx As New GridMetroColors()
    Dim ListadocajaDelUsuario As New List(Of cajaUsuario)
    Dim idCajaUsuario As Integer
    Dim cajausuario As New List(Of cajaUsuario)
    Dim saldoMN As Decimal
    'Public r As Record
    'Public lstWriteBits As List(Of String)
    'Public dataPagos As New DataTable
    Public dt As New DataTable
    Public a As Integer
    Public tipoVenta As String
    Dim gridCaja As New GridGroupingControl
    Dim Pago As String = "DC"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        Me.KeyPreview = True
        'GridCFG2(dgvEntidades)
        GridCFG(dgvPagos)

        If (Not IsNothing(usuario.IDUsuario)) Then
            dgvPagos.DataSource = UbicarCajasHijas()
            cargarDatosCuentas()
            CargarCajasTipo(usuario.IDUsuario)
            CMBCajasDelUsuarioPV()
            saldoMN = DigitalGauge2.Value
            '    ListaDocPago()
        End If
        'Me.dgvPagos.TableDescriptor.Columns("montoMN").ReadOnly = True
        chTipoMovimientoCaja.Tag = 0
        ToolStripLabel10.Text = Gempresas.NomEmpresa
        ToolStripLabel12.Text = GEstableciento.NombreEstablecimiento

    End Sub

    Public Function UbicarCajasHijas() As DataTable

        dt.Columns.Add("idEntidad")
        dt.Columns.Add("ef")
        dt.Columns.Add("pago")
        dt.Columns.Add("moneda")
        dt.Columns.Add("tipocambio", GetType(Decimal))
        dt.Columns.Add("montoMN", GetType(Double))
        dt.Columns.Add("montoME", GetType(Double))
        dt.Columns.Add("total", GetType(Double))
        dt.Columns.Add("importePendiente", GetType(Decimal))
        dt.Columns.Add("vueltoMN", GetType(Decimal))
        dt.Columns.Add("vueltoME", GetType(Decimal))
        dt.Columns.Add("saldo", GetType(Decimal))
        dt.Columns.Add("idempresa", GetType(String))
        dt.Columns.Add("cuenta", GetType(Integer))
        dt.Columns.Add("tipoPago", GetType(String))
        dt.Columns.Add("entidadFinanciera", GetType(String))
        dt.Columns.Add("NroOperacion", GetType(Integer))
        dt.Columns.Add("ImporteDisp", GetType(Decimal))
        dt.Columns.Add("descripcionCuenta", GetType(String))

        Return dt
    End Function


    Sub cargarDatosCuentas()
        Dim cuentaUsuarioDetalleSA As New cajaUsuarioSA

        Dim objCuenta As New cajaUsuario

        objCuenta = cuentaUsuarioDetalleSA.UbicarUsuarioAbierto(usuario.IDUsuario)

        If (Not IsNothing(objCuenta)) Then
            idCajaUsuario = objCuenta.idcajaUsuario
        End If


    End Sub

    Public Sub CargarCajasTipo(idpersona As Integer)
        Dim cajausuariosa As New cajaUsuarioSA
        Try
            If (Not IsNothing(idpersona) And (idCajaUsuario) > 0) Then
                cajausuario = cajausuariosa.ResumenTransaccionesXusuarioCajaPago(New cajaUsuario With {.idcajaUsuario = idCajaUsuario, .idPersona = idpersona})
            End If
        Catch ex As Exception

        End Try
    End Sub

    'Public Sub ListaDocPago()
    '    Dim tablaSA As New tablaDetalleSA
    '    Dim tabla As New List(Of tabladetalle)

    '    tabla = tablaSA.GetListaTablaDetalle(1, "1")
    '    'tabla = (From n In tabla _
    '    '             Where listaCuenta.Contains(n.codigoDetalle) _
    '    '            Select n).ToList
    '    cboTipoDocumento.DataSource = tabla
    '    cboTipoDocumento.ValueMember = "codigoDetalle"
    '    cboTipoDocumento.DisplayMember = "descripcion"
    '    cboTipoDocumento.SelectedValue = "001"

    '    cboEntidad.ValueMember = "codigoDetalle"
    '    cboEntidad.DisplayMember = "descripcion"
    '    cboEntidad.DataSource = tablaSA.GetListaTablaDetalle(3, "1")
    '    cboEntidad.SelectedValue = -1

    'End Sub

    'Public Function GetTableAlmacen() As DataTable
    '    Dim tablaSA As New tablaDetalleSA
    '    Dim tabla As New List(Of tabladetalle)

    '    Dim almacenSA As New almacenSA
    '    Dim dt As New DataTable()
    '    dt.Columns.Add("codigoDetalle", GetType(Integer))
    '    dt.Columns.Add("descripcion", GetType(String))


    '    For Each i In tablaSA.GetListaTablaDetalle(1, "1")

    '        Dim dr As DataRow = dt.NewRow()
    '        dr(0) = i.idtabla
    '        dr(1) = i.descripcion
    '        dt.Rows.Add(dr)
    '    Next

    '    Return dt
    'End Function

    'Public Function GetTableAlmacen2() As DataTable
    '    Dim tablaSA As New tablaDetalleSA
    '    Dim tabla As New List(Of tabladetalle)

    '    Dim almacenSA As New almacenSA
    '    Dim dt As New DataTable()
    '    dt.Columns.Add("codigoDetalle", GetType(Integer))
    '    dt.Columns.Add("descripcion", GetType(String))


    '    For Each i In tablaSA.GetListaTablaDetalle(3, "1")

    '        Dim dr As DataRow = dt.NewRow()
    '        dr(0) = i.idtabla
    '        dr(1) = i.descripcion
    '        dt.Rows.Add(dr)
    '    Next

    '    Return dt
    'End Function

    Sub GridCFG(grid As GridGroupingControl)
        grid.TableOptions.ShowRowHeader = False
        grid.TopLevelGroupOptions.ShowCaption = False


        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        grid.SetMetroStyle(colorx)
        grid.BorderStyle = System.Windows.Forms.BorderStyle.None

        'Me.gridGroupingControl1.BrowseOnly = true
        'Me.gridGroupingControl1.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        'Me.gridGroupingControl1.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        'Me.gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One
        grid.TableOptions.SelectionBackColor = Color.Gray
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.Format = "MMM dd yyyy"
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.Hide
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).HeaderText = "Date"
        'Me.gridGroupingControl1.TableDescriptor.Columns(1).HeaderText = "Category"
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.Currency
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromArgb(168, 178, 189)
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.TextAlign = GridTextAlign.Left

        'this.gridGroupingControl1.TableDescriptor.Columns["Amount"].Width = (this.tableLayoutPanel3.Width / 5) - 50;
        grid.AllowProportionalColumnSizing = False
        grid.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        grid.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        grid.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
        grid.ShowRowHeaders = False

        grid.Table.DefaultColumnHeaderRowHeight = 25
        grid.Table.DefaultRecordRowHeight = 30
        grid.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Private Sub CMBCajasDelUsuarioPV()
        Try

            For Each item In cajausuario
                GridPago(item)

            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub GridPago(cajaBE As cajaUsuario)

        Dim cuentaUsuarioDetalleSA As New cajaUsuarioDetalleSA
        Dim contador As Integer = 0
        Dim saldooagado As Integer = 0
        Dim contadorMon As Integer = 0
        CurrencyTextBox1.Text = 0.0
        For Each i In dgvPagos.Table.Records
            If (i.GetValue("idEntidad") = cajaBE.idEntidad) Then
                contador += 1
            End If
            If (dgvPagos.Table.Records.Count > 1) Then
                If (i.GetValue("saldo") = 0) Then
                    saldooagado = 1
                End If
            End If
            If (i.GetValue("moneda") = "EXTRANJERO") Then
                contadorMon = 1
            End If

        Next

        If (contador = 0) Then

            If Not IsNothing(cajaBE) Then
                If (cajaBE.moneda = TipoMoneda.Nacional And cajaBE.Tipo = CuentaFinanciera.Efectivo) Then
                    'Dim i = (From a In listaCajaUsuario Where a.moneda = 1).FirstOrDefault

                    Me.dgvPagos.Table.AddNewRecord.SetCurrent()
                    Me.dgvPagos.Table.AddNewRecord.BeginEdit()
                    Me.dgvPagos.Table.CurrentRecord.SetValue("idEntidad", cajaBE.idEntidad) '1
                    Me.dgvPagos.Table.CurrentRecord.SetValue("ef", cajaBE.NombreEntidad) '2
                    Me.dgvPagos.Table.CurrentRecord.SetValue("pago", "EFECTIVO")
                    Me.dgvPagos.Table.CurrentRecord.SetValue("moneda", "NACIONAL")
                    Me.dgvPagos.Table.CurrentRecord.SetValue("tipocambio", 0.0) '5
                    Me.dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0) '7
                    Me.dgvPagos.Table.CurrentRecord.SetValue("importePendiente", 0.0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0) '10
                    Me.dgvPagos.Table.CurrentRecord.SetValue("idempresa", cajaBE.idEmpresa)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("cuenta", cajaBE.cuentaCajaOrigen)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("ImporteDisp", CDec(cajaBE.otrosIngresosMN))
                    Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 0
                    If (contadorMon = 1) Then
                        'Me.dgvPagos.TableDescriptor.Columns("montoMN").Width = 0
                        Me.dgvPagos.TableDescriptor.Columns("montoME").Width = 175
                        Me.dgvPagos.TableDescriptor.Columns("vueltoME").Width = 90
                        Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 75
                    Else
                        'Me.dgvPagos.TableDescriptor.Columns("montoMN").Width = 0
                        Me.dgvPagos.TableDescriptor.Columns("montoME").Width = 0
                        Me.dgvPagos.TableDescriptor.Columns("vueltoME").Width = 0
                        Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 0
                    End If

                    Me.dgvPagos.Table.AddNewRecord.EndEdit()


                ElseIf (cajaBE.moneda = TipoMoneda.Extranjero And cajaBE.Tipo = CuentaFinanciera.Efectivo) Then
                    'Dim i = (From a In listaCajaUsuario Where a.moneda = 2).FirstOrDefault

                    Me.dgvPagos.Table.AddNewRecord.SetCurrent()
                    Me.dgvPagos.Table.AddNewRecord.BeginEdit()
                    Me.dgvPagos.Table.CurrentRecord.SetValue("idEntidad", cajaBE.idEntidad) '1
                    Me.dgvPagos.Table.CurrentRecord.SetValue("ef", cajaBE.NombreEntidad) '2
                    Me.dgvPagos.Table.CurrentRecord.SetValue("pago", "EFECTIVO")
                    Me.dgvPagos.Table.CurrentRecord.SetValue("moneda", "EXTRANJERO")
                    Me.dgvPagos.Table.CurrentRecord.SetValue("tipocambio", CDec(TmpTipoCambioTransaccionCompra))
                    Me.dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0) '7
                    Me.dgvPagos.Table.CurrentRecord.SetValue("importePendiente", 0.0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0) '10
                    Me.dgvPagos.Table.CurrentRecord.SetValue("idempresa", cajaBE.idEmpresa)
                    Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 50
                    Me.dgvPagos.Table.CurrentRecord.SetValue("cuenta", cajaBE.cuentaCajaOrigen)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("ImporteDisp", CDec(cajaBE.otrosIngresosMN))
                    Me.dgvPagos.TableDescriptor.Columns("montoME").Width = 175
                    Me.dgvPagos.TableDescriptor.Columns("vueltoME").Width = 90
                    Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 75

                    Me.dgvPagos.Table.AddNewRecord.EndEdit()

                ElseIf (cajaBE.moneda = TipoMoneda.Nacional And cajaBE.Tipo = CuentaFinanciera.Banco) Then
                    'Dim i = (From a In listaCajaUsuario Where a.moneda = 1).FirstOrDefault

                    Me.dgvPagos.Table.AddNewRecord.SetCurrent()
                    Me.dgvPagos.Table.AddNewRecord.BeginEdit()
                    Me.dgvPagos.Table.CurrentRecord.SetValue("idEntidad", cajaBE.idEntidad) '1
                    Me.dgvPagos.Table.CurrentRecord.SetValue("ef", cajaBE.NombreEntidad) '2
                    Me.dgvPagos.Table.CurrentRecord.SetValue("pago", "BANCO")
                    Me.dgvPagos.Table.CurrentRecord.SetValue("moneda", "NACIONAL")
                    Me.dgvPagos.Table.CurrentRecord.SetValue("tipocambio", 0.0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0) '7
                    Me.dgvPagos.Table.CurrentRecord.SetValue("importePendiente", 0.0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0) '10
                    Me.dgvPagos.Table.CurrentRecord.SetValue("idempresa", cajaBE.idEmpresa)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("cuenta", cajaBE.cuentaCajaOrigen)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("ImporteDisp", CDec(cajaBE.otrosIngresosMN))
                    If (contadorMon = 1) Then
                        'Me.dgvPagos.TableDescriptor.Columns("montoMN").Width = 0
                        Me.dgvPagos.TableDescriptor.Columns("montoME").Width = 175
                        Me.dgvPagos.TableDescriptor.Columns("vueltoME").Width = 90
                        Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 75
                    Else
                        'Me.dgvPagos.TableDescriptor.Columns("montoMN").Width = 0
                        Me.dgvPagos.TableDescriptor.Columns("montoME").Width = 0
                        Me.dgvPagos.TableDescriptor.Columns("vueltoME").Width = 0
                        Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 0
                    End If
                    Me.dgvPagos.Table.AddNewRecord.EndEdit()


                ElseIf (cajaBE.moneda = TipoMoneda.Extranjero And cajaBE.Tipo = CuentaFinanciera.Banco) Then
                    'Dim i = (From a In listaCajaUsuario Where a.moneda = 2).FirstOrDefault

                    Me.dgvPagos.Table.AddNewRecord.SetCurrent()
                    Me.dgvPagos.Table.AddNewRecord.BeginEdit()
                    Me.dgvPagos.Table.CurrentRecord.SetValue("idEntidad", cajaBE.idEntidad) '1
                    Me.dgvPagos.Table.CurrentRecord.SetValue("ef", cajaBE.NombreEntidad) '2
                    Me.dgvPagos.Table.CurrentRecord.SetValue("pago", "BANCO")
                    Me.dgvPagos.Table.CurrentRecord.SetValue("moneda", "EXTRANJERO")
                    Me.dgvPagos.Table.CurrentRecord.SetValue("tipocambio", CDec(TmpTipoCambioTransaccionCompra))
                    Me.dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0) '7
                    Me.dgvPagos.Table.CurrentRecord.SetValue("importePendiente", 0.0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0) '10
                    Me.dgvPagos.Table.CurrentRecord.SetValue("idempresa", cajaBE.idEmpresa)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("cuenta", cajaBE.cuentaCajaOrigen)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("ImporteDisp", CDec(cajaBE.otrosIngresosMN))
                    Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 50

                    'Me.dgvPagos.TableDescriptor.Columns("montoMN").Width = 0
                    Me.dgvPagos.TableDescriptor.Columns("montoME").Width = 175
                    Me.dgvPagos.TableDescriptor.Columns("vueltoME").Width = 90
                    Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 75

                    Me.dgvPagos.Table.AddNewRecord.EndEdit()


                ElseIf (cajaBE.moneda = TipoMoneda.Nacional And cajaBE.Tipo = CuentaFinanciera.Tarjeta_Credito) Then
                    'Dim i = (From a In listaCajaUsuario Where a.moneda = 1).FirstOrDefault

                    Me.dgvPagos.Table.AddNewRecord.SetCurrent()
                    Me.dgvPagos.Table.AddNewRecord.BeginEdit()
                    Me.dgvPagos.Table.CurrentRecord.SetValue("idEntidad", cajaBE.idEntidad) '1
                    Me.dgvPagos.Table.CurrentRecord.SetValue("ef", cajaBE.NombreEntidad) '2
                    Me.dgvPagos.Table.CurrentRecord.SetValue("pago", "TARJETA CREDITO")
                    Me.dgvPagos.Table.CurrentRecord.SetValue("moneda", "NACIONAL")
                    Me.dgvPagos.Table.CurrentRecord.SetValue("tipocambio", 0.0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0) '7
                    Me.dgvPagos.Table.CurrentRecord.SetValue("importePendiente", 0.0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0) '10
                    Me.dgvPagos.Table.CurrentRecord.SetValue("idempresa", cajaBE.idEmpresa)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("cuenta", cajaBE.cuentaCajaOrigen)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("ImporteDisp", CDec(cajaBE.otrosIngresosMN))
                    If (contadorMon = 1) Then
                        'Me.dgvPagos.TableDescriptor.Columns("montoMN").Width = 0
                        Me.dgvPagos.TableDescriptor.Columns("montoME").Width = 175
                        Me.dgvPagos.TableDescriptor.Columns("vueltoME").Width = 90
                        Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 75
                    Else
                        'Me.dgvPagos.TableDescriptor.Columns("montoMN").Width = 0
                        Me.dgvPagos.TableDescriptor.Columns("montoME").Width = 0
                        Me.dgvPagos.TableDescriptor.Columns("vueltoME").Width = 0
                        Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 0
                    End If
                    Me.dgvPagos.Table.AddNewRecord.EndEdit()


                ElseIf (cajaBE.moneda = TipoMoneda.Extranjero And cajaBE.Tipo = CuentaFinanciera.Tarjeta_Credito) Then
                    'Dim i = (From a In listaCajaUsuario Where a.moneda = 2).FirstOrDefault

                    Me.dgvPagos.Table.AddNewRecord.SetCurrent()
                    Me.dgvPagos.Table.AddNewRecord.BeginEdit()
                    Me.dgvPagos.Table.CurrentRecord.SetValue("idEntidad", cajaBE.idEntidad) '1
                    Me.dgvPagos.Table.CurrentRecord.SetValue("ef", cajaBE.NombreEntidad) '2
                    Me.dgvPagos.Table.CurrentRecord.SetValue("pago", "TARJETA CREDITO")
                    Me.dgvPagos.Table.CurrentRecord.SetValue("moneda", "EXTRANJERO")
                    Me.dgvPagos.Table.CurrentRecord.SetValue("tipocambio", CDec(TmpTipoCambioTransaccionCompra))
                    Me.dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0) '7
                    Me.dgvPagos.Table.CurrentRecord.SetValue("importePendiente", 0.0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0) '10
                    Me.dgvPagos.Table.CurrentRecord.SetValue("idempresa", cajaBE.idEmpresa)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("cuenta", cajaBE.cuentaCajaOrigen)
                    Me.dgvPagos.Table.CurrentRecord.SetValue("ImporteDisp", CDec(cajaBE.otrosIngresosMN))
                    Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 50

                    'Me.dgvPagos.TableDescriptor.Columns("montoMN").Width = 0
                    Me.dgvPagos.TableDescriptor.Columns("montoME").Width = 175
                    Me.dgvPagos.TableDescriptor.Columns("vueltoME").Width = 90
                    Me.dgvPagos.TableDescriptor.Columns("tipocambio").Width = 75

                    Me.dgvPagos.Table.AddNewRecord.EndEdit()

                End If
                CurrencyTextBox1.Text += Me.dgvPagos.Table.CurrentRecord.GetValue("ImporteDisp")
            End If

        Else
            PanelError.Visible = True
            lblEstado.Text = "ya existe una entidad financiera!"
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End If


    End Sub


#Region "TIMER"
    Sub parpadeo()
        Static parpadear As Boolean



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


    Private Sub dgvEntidades_MouseDoubleClick(sender As Object, e As MouseEventArgs)

    End Sub

    Private Sub dgvEntidades_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs)
        Dim cajaBE = (From a In cajausuario Where a.Tipo = CuentaFinanciera.Efectivo And a.moneda = TipoMoneda.Nacional).FirstOrDefault

        If Not IsNothing(cajaBE) Then
            GridPago(cajaBE)
        Else
            PanelError.Visible = True
            lblEstado.Text = "ya existe una entidad financiera!"
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End If
    End Sub

    Private Sub dgvPagos_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvPagos.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim sumaPagos As Double = 0
        Dim sumaPagosME As Double = 0
        Dim sumatotal As Double = 0
        Dim numerOper As String
        Dim CobroMN As Decimal
        Dim CobroME As Decimal
        Dim importeIngreso As Decimal
        Dim tipoCambio As Decimal
        Dim calculoSaldoME As Decimal
        Dim entidadSA As New EstadosFinancierosSA
        Dim importeTotalRecibido As Decimal = 0
        Dim vueltoTotalEntregar As Decimal = 0
        Dim importeCobrado As Decimal = 0
        Dim totalMN As Decimal = 0
        Dim contador As Integer = 0
        Dim ultimoSaldo As Decimal = 0
        Try
            If Not IsNothing(Me.dgvPagos.Table.CurrentRecord) Then
                Select Case ColIndex

                    Case 5 ' importe recibido

                        If (chTipoMovimientoCaja.Tag = 0) Then

                            If (dgvPagos.Table.CurrentRecord.GetValue("ImporteDisp") >= dgvPagos.Table.CurrentRecord.GetValue("importePendiente")) Then
                                If (CDec(txtRetencion.Text) <> CDec(DigitalGauge2.Value)) Then
                                    For Each i In dgvPagos.Table.Records
                                        importeCobrado += i.GetValue("montoMN")
                                        ultimoSaldo = (CDec(DigitalGauge2.Value))
                                        totalMN = i.GetValue("montoMN")
                                        CobroMN = i.GetValue("montoMN")
                                        If (i.GetValue("moneda") = "NACIONAL") Then
                                            If (totalMN > 0) Then
                                                If (Pago = "DC") Then
                                                    If (totalMN = CDec(DigitalGauge2.Value)) Then

                                                        If (contador = 0) Then
                                                            i.SetValue("montoMN", CDec(DigitalGauge2.Value))
                                                            i.SetValue("montoME", 0.0)
                                                            i.SetValue("vueltoMN", 0)
                                                            i.SetValue("vueltoME", 0.0)
                                                            i.SetValue("saldo", 0.0)
                                                            Pago = "PG"
                                                        Else
                                                            i.SetValue("montoMN", totalMN - (importeCobrado - CDec(ultimoSaldo)))
                                                            i.SetValue("montoME", 0)
                                                            i.SetValue("vueltoMN", importeCobrado - CDec(ultimoSaldo))
                                                            i.SetValue("vueltoME", 0)
                                                            i.SetValue("saldo", 0.0)
                                                        End If

                                                    ElseIf (ultimoSaldo > CDec(totalMN)) Then

                                                        If (((ultimoSaldo)) > importeCobrado) Then
                                                            i.SetValue("montoMN", totalMN)
                                                            i.SetValue("montoME", 0)
                                                            i.SetValue("vueltoMN", 0)
                                                            i.SetValue("vueltoME", 0)
                                                            i.SetValue("saldo", (CDec(ultimoSaldo)) - importeCobrado)
                                                            contador += 1
                                                        Else
                                                            i.SetValue("montoMN", totalMN - (importeCobrado - CDec(ultimoSaldo)))
                                                            i.SetValue("montoME", 0)
                                                            i.SetValue("vueltoMN", importeCobrado - CDec(ultimoSaldo))
                                                            i.SetValue("vueltoME", 0)
                                                            i.SetValue("saldo", 0.0)
                                                            Pago = "PG"
                                                        End If
                                                    ElseIf (ultimoSaldo < CDec(totalMN)) Then
                                                        dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
                                                        dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0)
                                                        dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0.0)
                                                        dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0.0)
                                                        dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0)
                                                        PanelError.Visible = True
                                                        lblEstado.Text = "No debe exceder el monto permitido!"
                                                        Timer1.Enabled = True
                                                        TiempoEjecutar(10)
                                                    End If

                                                Else


                                                    ''If (totalMN <> CobroMN) Then
                                                    ''    contador += 1
                                                    ''    If (contador <> 0) Then
                                                    'If (((ultimoSaldo)) > importeCobrado) Then
                                                    '    i.SetValue("montoMN", totalMN)
                                                    '    i.SetValue("montoME", 0)
                                                    '    i.SetValue("vueltoMN", 0)
                                                    '    i.SetValue("vueltoME", 0)
                                                    '    i.SetValue("saldo", (CDec(ultimoSaldo)) - importeCobrado)
                                                    '    contador += 1
                                                    'Else
                                                    '    i.SetValue("montoMN", totalMN - (importeCobrado - CDec(ultimoSaldo)))
                                                    '    i.SetValue("montoME", 0)
                                                    '    i.SetValue("vueltoMN", importeCobrado - CDec(ultimoSaldo))
                                                    '    i.SetValue("vueltoME", 0)
                                                    '    i.SetValue("saldo", 0.0)
                                                    '    Pago = "PG"
                                                    'End If
                                                    ''End If
                                                    ''Else
                                                    '    'dgvPagos.Table.CurrentRecord.SetValue("importePendiente", 0.0)
                                                    '    'dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
                                                    '    'dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0)
                                                    '    'dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0.0)
                                                    '    'dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0.0)
                                                    '    'dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0)
                                                    '    'PanelError.Visible = True
                                                    '    'lblEstado.Text = "El pago ya se realizo en su totalidad!"
                                                    '    'Timer1.Enabled = True
                                                    '    'TiempoEjecutar(10)
                                                    'End If

                                                End If
                                            End If
                                        End If
                                    Next

                                    txtTotalBase.Text = 0.0
                                    txtRetencion.Text = 0.0
                                    txtTotalIva.Text = 0.0
                                    For Each x In dgvPagos.Table.Records
                                        txtTotalBase.Text += x.GetValue("montoMN")
                                        txtRetencion.Text += x.GetValue("montoMN")
                                        txtTotalIva.Text += x.GetValue("vueltoMN")

                                    Next
                                Else
                                    If MessageBox.Show("Desea reiniciar los pagos?", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                        dgvPagos.Table.Records.DeleteAll()
                                        CMBCajasDelUsuarioPV()
                                        txtRetencion.Text = 0.0
                                        txtTotalBase.Text = 0.0
                                        txtTotalIva.Text = 0.0
                                        saldoMN = 0.0
                                        Pago = "DC"
                                    Else
                                        dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
                                        dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0)
                                        dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0.0)
                                        dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0.0)
                                        dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0)
                                        'dgvPagos.Table.CurrentRecord.SetValue("importePendiente", dgvPagos.Table.CurrentRecord.GetValue("montoMN"))
                                        PanelError.Visible = True
                                        lblEstado.Text = "El pago ya se realizo en su totalidad!"
                                        Timer1.Enabled = True
                                        TiempoEjecutar(10)
                                    End If


                                End If
                            Else
                                dgvPagos.Table.CurrentRecord.SetValue("importePendiente", 0.0)
                                PanelError.Visible = True
                                lblEstado.Text = "el monto no debe exceder al permitido!"
                                Timer1.Enabled = True
                                TiempoEjecutar(10)
                            End If


                        ElseIf (chTipoMovimientoCaja.Tag = 1) Then

                            If (dgvPagos.Table.CurrentRecord.GetValue("ImporteDisp") >= dgvPagos.Table.CurrentRecord.GetValue("importePendiente")) Then


                                If (dgvPagos.Table.CurrentRecord.GetValue("importePendiente") > 0) Then


                                    If (dgvPagos.Table.CurrentRecord.GetValue("moneda") = "NACIONAL") Then
                                        importeIngreso = dgvPagos.Table.CurrentRecord.GetValue("importePendiente")
                                        'dgvPagos.Table.CurrentRecord.SetValue("tipocambio", 0.0)
                                        dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
                                        dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0)
                                        dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0.0)
                                        dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0.0)
                                        dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0)
                                        'dgvVenta.Table.Records.DeleteAll()
                                        'ObtenerDetallePedido()

                                        dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0)
                                        saldoMN = 0
                                        For Each i In dgvPagos.Table.Records
                                            If (i.GetValue("saldo") <> 0) Then
                                                saldoMN = CDec(i.GetValue("saldo"))
                                            End If
                                            'importeTotalRecibido += CDec(i.GetValue("importePendiente"))
                                        Next
                                        If (saldoMN = 0) Then
                                            numerOper = DigitalGauge2.Value
                                            'importeCobrado = numerOper

                                        Else
                                            numerOper = saldoMN
                                        End If

                                        If (dgvPagos.Table.Records.Count > 0) Then

                                        Else

                                        End If

                                        If (importeIngreso >= CDec(DigitalGauge2.Value)) Then
                                            'dgvPagos.Table.CurrentRecord.SetValue("tipocambio", TmpTipoCambio)
                                            'dgvPagos.Table.CurrentRecord.SetValue("montoME", CDec(DigitalGauge2.Value / TmpTipoCambio))
                                            dgvPagos.Table.CurrentRecord.SetValue("montoMN", CDec(DigitalGauge2.Value))
                                            'dgvPagos.Table.CurrentRecord.SetValue("tipocambio", 0.0)
                                            dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0)
                                            dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", importeIngreso - CDec(DigitalGauge2.Value))
                                            dgvPagos.Table.CurrentRecord.SetValue("vueltoME", CDec((importeIngreso - CDec(DigitalGauge2.Value)) / TmpTipoCambio))
                                            dgvPagos.Table.CurrentRecord.SetValue("saldo", CDec(numerOper) - CDec(DigitalGauge2.Value))

                                        ElseIf (importeIngreso < CDec(DigitalGauge2.Value)) Then
                                            'dgvPagos.Table.CurrentRecord.SetValue("tipocambio", TmpTipoCambio)
                                            'dgvPagos.Table.CurrentRecord.SetValue("montoME", CDec(importeIngreso / TmpTipoCambio))
                                            dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
                                            dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0)
                                            dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0.0)
                                            dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0.0)
                                            dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0)

                                            'txtTotalBase.Text = importeTotalRecibido
                                            'txtRetencion.Text = 0.0
                                            'txtTotalIva.Text = 0.0
                                        End If
                                        'lsvPagosRegistrados.Items.Clear()
                                        'CalculoPagos(r)
                                    Else
                                        dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
                                        dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0)
                                        dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0.0)
                                        dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0.0)
                                        dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0)
                                        'txtTotalBase.Text = importeTotalRecibido
                                    End If
                                Else
                                    dgvPagos.Table.CurrentRecord.SetValue("importePendiente", 0.0)
                                    'dgvPagos.Table.CurrentRecord.SetValue("tipocambio", 0.0)
                                    dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
                                    dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0)
                                    dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0.0)
                                    dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0.0)
                                    dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0)
                                    'txtTotalBase.Text = 0.0
                                    'txtRetencion.Text = 0.0
                                    'txtTotalIva.Text = 0.0
                                    PanelError.Visible = True
                                    lblEstado.Text = "el monto no debe ser negativo!"
                                    Timer1.Enabled = True
                                    TiempoEjecutar(10)

                                End If
                                'End If
                                txtTotalBase.Text = 0.0
                                txtRetencion.Text = 0.0
                                txtTotalIva.Text = 0.0
                                For Each x In dgvPagos.Table.Records
                                    importeTotalRecibido += x.GetValue("importePendiente")
                                    importeCobrado += x.GetValue("montoMN")
                                    vueltoTotalEntregar += x.GetValue("vueltoMN")
                                Next
                                txtTotalBase.Text = importeTotalRecibido
                                txtRetencion.Text = importeCobrado
                                txtTotalIva.Text = vueltoTotalEntregar


                            End If
                            PanelError.Visible = True
                            lblEstado.Text = "el monto no debe exceder al permitido!"
                            Timer1.Enabled = True
                            TiempoEjecutar(10)
                        End If


                    Case 6 ' moneda nacional
                        CobroMN = dgvPagos.Table.CurrentRecord.GetValue("montoMN")
                        importeIngreso = dgvPagos.Table.CurrentRecord.GetValue("importePendiente")

                        If (CobroMN > 0) Then
                            If (importeIngreso > 0) Then
                                dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0)
                                saldoMN = 0
                                For Each i In dgvPagos.Table.Records
                                    If (i.GetValue("saldo") <> 0) Then
                                        saldoMN = i.GetValue("saldo")
                                    End If
                                    'importeTotalRecibido += i.GetValue("montoMN")
                                    'vueltoTotalEntregar += i.GetValue("vueltoMN")
                                Next
                                If (saldoMN = 0) Then
                                    numerOper = DigitalGauge2.Value
                                Else
                                    numerOper = saldoMN
                                End If



                                If (dgvPagos.Table.CurrentRecord.GetValue("moneda") = "EXTRANJERO") Then

                                    CobroME = CDec(CobroMN / dgvPagos.Table.CurrentRecord.GetValue("tipocambio"))

                                    If (CobroME <> 0 And CobroMN <> 0) Then
                                        If (CobroME <= importeIngreso) Then
                                            If (CobroMN <= numerOper) Then
                                                'dgvPagos.Table.CurrentRecord.SetValue("tipocambio", CDec(CobroMN / CobroME).ToString("N3"))
                                                tipoCambio = dgvPagos.Table.CurrentRecord.GetValue("tipocambio")
                                                If (numerOper <= CobroMN) Then
                                                    dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", ((importeIngreso - CobroME) * tipoCambio))
                                                    dgvPagos.Table.CurrentRecord.SetValue("vueltoME", (importeIngreso - CobroME))
                                                    dgvPagos.Table.CurrentRecord.SetValue("saldo", (0.0))
                                                    dgvPagos.Table.CurrentRecord.SetValue("montoME", (CobroME))
                                                Else

                                                    dgvPagos.Table.CurrentRecord.SetValue("vueltoME", (importeIngreso - CobroME))
                                                    dgvPagos.Table.CurrentRecord.SetValue("montoME", (CobroME))
                                                    If (numerOper > CobroMN) Then
                                                        dgvPagos.Table.CurrentRecord.SetValue("saldo", (numerOper - CobroMN))
                                                        dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", ((importeIngreso - CobroME) * tipoCambio))
                                                    Else
                                                        dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", ((importeIngreso - CobroME) * tipoCambio))
                                                        dgvPagos.Table.CurrentRecord.SetValue("saldo", (numerOper - CobroMN))
                                                    End If

                                                End If

                                                'txtRetencion.Text = importeTotalRecibido
                                                'txtTotalIva.Text = (vueltoTotalEntregar) - dgvPagos.Table.CurrentRecord.GetValue("montoMn")
                                                'lsvPagosRegistrados.Items.Clear()
                                                'CalculoPagos()
                                            Else

                                                If (CobroMN > numerOper) Then
                                                    'dgvPagos.Table.CurrentRecord.SetValue("tipocambio", 0.0)
                                                    dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
                                                    dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0)
                                                    dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0.0)
                                                    dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0.0)
                                                    dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0)
                                                    'txtRetencion.Text = 0.0
                                                    'txtTotalIva.Text = 0.0
                                                    PanelError.Visible = True
                                                    lblEstado.Text = "No debe exceder el monto permitido!"
                                                    Timer1.Enabled = True
                                                    TiempoEjecutar(10)
                                                Else
                                                    dgvPagos.Table.CurrentRecord.SetValue("tipocambio", CDec(CobroMN / CobroME).ToString("N3"))
                                                    tipoCambio = dgvPagos.Table.CurrentRecord.GetValue("tipocambio")
                                                    dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", ((importeIngreso - CobroME) * tipoCambio))
                                                    dgvPagos.Table.CurrentRecord.SetValue("vueltoME", (importeIngreso - CobroME))
                                                    dgvPagos.Table.CurrentRecord.SetValue("saldo", (0.0))
                                                End If

                                            End If
                                        Else
                                            dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
                                            dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0)
                                            dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0.0)
                                            dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0.0)
                                            dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0)
                                            PanelError.Visible = True
                                            lblEstado.Text = "No debe exceder el monto permitido!"
                                            Timer1.Enabled = True
                                            TiempoEjecutar(10)
                                        End If



                                    Else
                                        calculoSaldoME = CDec(CobroMN / TmpTipoCambioTransaccionCompra)

                                        If (calculoSaldoME <= importeIngreso) Then


                                            If (CobroMN <= numerOper) Then
                                                'dgvPagos.Table.CurrentRecord.SetValue("tipocambio", (TmpTipoCambio))
                                                'dgvPagos.Table.CurrentRecord.SetValue("montoME", (CobroMN / TmpTipoCambio))
                                                'dgvPagos.Table.CurrentRecord.SetValue("tipocambio", (0))
                                                dgvPagos.Table.CurrentRecord.SetValue("montoME", CDec(CobroMN / TmpTipoCambioTransaccionCompra))
                                                dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", (importeIngreso - CDec(CobroMN / TmpTipoCambioTransaccionCompra)) * TmpTipoCambioTransaccionCompra)
                                                dgvPagos.Table.CurrentRecord.SetValue("vueltoME", importeIngreso - CDec(CobroMN / TmpTipoCambioTransaccionCompra)) '((importeIngreso - CobroMN) / TmpTipoCambio))
                                                dgvPagos.Table.CurrentRecord.SetValue("saldo", (numerOper - CobroMN))
                                                'lsvPagosRegistrados.Items.Clear()
                                                'CalculoPagos()
                                            Else
                                                dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
                                                dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0)
                                                dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0.0)
                                                dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0.0)
                                                dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0)
                                                PanelError.Visible = True
                                                lblEstado.Text = "No debe exceder el monto permitido!"
                                                Timer1.Enabled = True
                                                TiempoEjecutar(10)
                                            End If
                                        Else
                                            dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
                                            dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0)
                                            dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0.0)
                                            dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0.0)
                                            dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0)
                                            PanelError.Visible = True
                                            lblEstado.Text = "No debe exceder el monto permitido!"
                                            Timer1.Enabled = True
                                            TiempoEjecutar(10)
                                        End If

                                    End If

                                Else

                                    If (CobroMN <= importeIngreso) Then
                                        If (CobroMN <= numerOper) Then
                                            'dgvPagos.Table.CurrentRecord.SetValue("tipocambio", (TmpTipoCambio))
                                            'dgvPagos.Table.CurrentRecord.SetValue("montoME", (CobroMN / TmpTipoCambio))
                                            'dgvPagos.Table.CurrentRecord.SetValue("tipocambio", (0))
                                            dgvPagos.Table.CurrentRecord.SetValue("montoME", (0))
                                            dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", (importeIngreso - CobroMN))
                                            dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0) '((importeIngreso - CobroMN) / TmpTipoCambio))
                                            dgvPagos.Table.CurrentRecord.SetValue("saldo", (numerOper - CobroMN))


                                            'txtRetencion.Text = importeTotalRecibido
                                            'txtTotalIva.Text = (vueltoTotalEntregar) - dgvPagos.Table.CurrentRecord.GetValue("montoMn")

                                            'lsvPagosRegistrados.Items.Clear()
                                            'CalculoPagos()
                                        Else
                                            'dgvPagos.Table.CurrentRecord.SetValue("tipocambio", 0.0)
                                            dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
                                            dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0)
                                            dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0.0)
                                            dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0.0)
                                            dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0)
                                            PanelError.Visible = True

                                            'txtRetencion.Text = 0.0
                                            'txtTotalIva.Text = 0.0
                                            lblEstado.Text = "No debe exceder el monto permitido!"
                                            Timer1.Enabled = True
                                            TiempoEjecutar(10)
                                        End If
                                    Else
                                        'dgvPagos.Table.CurrentRecord.SetValue("tipocambio", 0.0)
                                        dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
                                        dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0)
                                        dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0.0)
                                        dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0.0)
                                        dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0)
                                        PanelError.Visible = True
                                        lblEstado.Text = "No debe exceder el monto permitido!"
                                        Timer1.Enabled = True
                                        TiempoEjecutar(10)
                                    End If

                                End If
                            Else
                                'dgvPagos.Table.CurrentRecord.SetValue("tipocambio", 0.0)
                                dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
                                dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0)
                                dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0.0)
                                dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0.0)
                                dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0)
                                PanelError.Visible = True
                                lblEstado.Text = "debe ingresar monto recibido!"
                                Timer1.Enabled = True
                                TiempoEjecutar(10)

                            End If
                        Else
                            'dgvPagos.Table.CurrentRecord.SetValue("tipocambio", 0.0)
                            dgvPagos.Table.CurrentRecord.SetValue("montoMN", 0.0)
                            dgvPagos.Table.CurrentRecord.SetValue("montoME", 0.0)
                            dgvPagos.Table.CurrentRecord.SetValue("vueltoMN", 0.0)
                            dgvPagos.Table.CurrentRecord.SetValue("vueltoME", 0.0)
                            dgvPagos.Table.CurrentRecord.SetValue("saldo", 0.0)
                            PanelError.Visible = True
                            lblEstado.Text = "El importe no debe ser negativo!"
                            Timer1.Enabled = True
                            TiempoEjecutar(10)
                        End If
                        txtTotalBase.Text = 0.0
                        txtRetencion.Text = 0.0
                        txtTotalIva.Text = 0.0
                        For Each x In dgvPagos.Table.Records
                            importeTotalRecibido += x.GetValue("importePendiente")
                            importeCobrado += x.GetValue("montoMN")
                            vueltoTotalEntregar += x.GetValue("vueltoMN")
                        Next
                        txtTotalBase.Text = importeTotalRecibido
                        txtRetencion.Text = importeCobrado
                        txtTotalIva.Text = vueltoTotalEntregar

                        'Case 11

                        '    If (dgvPagos.Table.CurrentRecord.GetValue("tipoPago") = "001") Then
                        '        dgvPagos.Table.CurrentRecord.SetValue("entidadFinanciera", "")
                        '    End If

                        'Case 12

                        '    If (dgvPagos.Table.CurrentRecord.GetValue("tipoPago") = "001") Then
                        '        dgvPagos.Table.CurrentRecord.SetValue("entidadFinanciera", "")
                        '        PanelError.Visible = True
                        '        lblEstado.Text = "No se ingresa ningun casillero!"
                        '        Timer1.Enabled = True
                        '        TiempoEjecutar(10)
                        '    End If

                End Select
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs)
        dgvPagos.Table.Records.DeleteAll()
        CMBCajasDelUsuarioPV()
    End Sub

    Private Sub btGrabar_Click(sender As Object, e As EventArgs) Handles btGrabar.Click

        Dim saldo As Decimal = 0

        For Each item In dgvPagos.Table.Records
            saldo += item.GetValue("montoMN")
        Next

        If (saldo = DigitalGauge2.Value) Then

            Select Case tipoVenta
                Case TIPO_VENTA.VENTA_POS_DIRECTA
                    a = 1
                    frmVentaPVdirecta.llenarGrid(dgvPagos, 1)
                    Me.Dispose()
                Case TIPO_VENTA.VENTA_ANTICIPADA
                    a = 1
                    frmAnticipoXVenta.llenarGrid(dgvPagos, 1)
                    Me.Dispose()
                Case TIPO_VENTA.VENTA_GENERAL
                    a = 1
                    frmVenta.llenarGrid(dgvPagos, 1)
                    Me.Dispose()
                Case TIPO_COMPRA.COMPRA_ANTICIPADA_RECIBIDA
                    a = 1
                    frmCompraAnticipada.llenarGrid(dgvPagos, 1)
                    Me.Dispose()

                Case TIPO_COMPRA.COMPRA_PAGADA
                    a = 1
                    frmComprasContado.llenarGrid(dgvPagos, 1)
                    Me.Dispose()

                Case TIPO_COMPRA.COMPRA_SERVICIO_PUBLICO
                    a = 1
                    frmServicioPublicoContado.llenarGrid(dgvPagos, 1)
                    Me.Dispose()

                Case TIPO_COMPRA.COMPRA_RECIBO_HONORARIOS
                    a = 1
                    frmReciboHonorariosContado.llenarGrid(dgvPagos, 1)
                    Me.Dispose()
            End Select

        Else
            PanelError.Visible = True
            lblEstado.Text = "El importe debe ser saldado en su totalidad!"
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End If

    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        a = 0
        Me.Dispose()
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        dgvPagos.Table.Records.DeleteAll()
        CMBCajasDelUsuarioPV()
        txtRetencion.Text = 0.0
        txtTotalBase.Text = 0.0
        txtTotalIva.Text = 0.0
        CurrencyTextBox1.Text = 0.0
        saldoMN = 0.0
        Pago = "DC"
    End Sub

    Private Sub frmCajasXusuario_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F6 Then
            Tag = 0
            Me.Dispose()
        ElseIf e.KeyCode = Keys.Delete Then
            dgvPagos.Table.Records.DeleteAll()
            CMBCajasDelUsuarioPV()
            txtRetencion.Text = 0.0
            txtTotalBase.Text = 0.0
            txtTotalIva.Text = 0.0
        End If
    End Sub

    Private Sub frmCajasXusuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        Select Case e.KeyChar
            Case ChrW(Keys.F6)
                Tag = 0
                Me.Dispose()
            Case ChrW(Keys.Delete)
                dgvPagos.Table.Records.DeleteAll()
                CMBCajasDelUsuarioPV()
                txtRetencion.Text = 0.0
                txtTotalBase.Text = 0.0
                txtTotalIva.Text = 0.0
        End Select
    End Sub


    Private Sub frmCajasXusuario_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.F6 Then
            Tag = 0
            Me.Dispose()
        ElseIf e.KeyCode = Keys.Delete Then
            dgvPagos.Table.Records.DeleteAll()
            CMBCajasDelUsuarioPV()
            txtRetencion.Text = 0.0
            txtTotalBase.Text = 0.0
            txtTotalIva.Text = 0.0
        End If
    End Sub


    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles chTipoMovimientoCaja.CheckedChanged
        If (chTipoMovimientoCaja.Checked = True) Then
            chTipoMovimientoCaja.Tag = 1
            Me.dgvPagos.TableDescriptor.Columns("montoMN").ReadOnly = False
            dgvPagos.Table.Records.DeleteAll()
            CMBCajasDelUsuarioPV()
            txtRetencion.Text = 0.0
            txtTotalBase.Text = 0.0
            txtTotalIva.Text = 0.0
            saldoMN = 0.0
            Pago = "DC"
        Else
            chTipoMovimientoCaja.Tag = 0
            Me.dgvPagos.TableDescriptor.Columns("montoMN").ReadOnly = False
            dgvPagos.Table.Records.DeleteAll()
            CMBCajasDelUsuarioPV()
            txtRetencion.Text = 0.0
            txtTotalBase.Text = 0.0
            txtTotalIva.Text = 0.0
            saldoMN = 0.0
            Pago = "DC"
        End If
    End Sub

    Dim comboTableP As New DataTable
    Dim comboTableP2 As New DataTable
    'Private Sub frmCajasXusuarioCompras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '    comboTableP = Me.GetTableAlmacen
    '    Dim ggcStyle As GridTableCellStyleInfo = dgvPagos.TableDescriptor.Columns(12).Appearance.AnyRecordFieldCell
    '    ggcStyle.CellType = "ComboBox"
    '    ggcStyle.DataSource = Me.comboTableP
    '    ggcStyle.ValueMember = "codigoDetalle"
    '    ggcStyle.DisplayMember = "descripcion"
    '    ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive
    '    dgvPagos.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
    '    dgvPagos.ShowRowHeaders = False

    '    comboTableP2 = Me.GetTableAlmacen2
    '    Dim ggcStyle2 As GridTableCellStyleInfo = dgvPagos.TableDescriptor.Columns(13).Appearance.AnyRecordFieldCell
    '    ggcStyle2.CellType = "ComboBox"
    '    ggcStyle2.DataSource = Me.comboTableP2
    '    ggcStyle2.ValueMember = "codigoDetalle"
    '    ggcStyle2.DisplayMember = "descripcion"
    '    ggcStyle2.DropDownStyle = GridDropDownStyle.Exclusive
    '    dgvPagos.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
    '    dgvPagos.ShowRowHeaders = False
    'End Sub


    'Private Sub Button5_Click(sender As Object, e As EventArgs)
    '    Dim nombreUbigeo As String
    '    Dim nombreEntidad As String
    '    Dim nombreTipo As String
    '    'If (Not IsNothing(cboEntidad.SelectedValue)) Then
    '    '    If (Not IsNothing(cboTipoDocumento.SelectedValue)) Then
    '    If Not IsNothing(Me.dgvPagos.Table.CurrentRecord) Then
    '        nombreUbigeo = cboTipoDocumento.Text & cboEntidad.Text
    '        nombreTipo = cboTipoDocumento.SelectedValue
    '        nombreEntidad = cboEntidad.SelectedValue

    '        If (nombreTipo.Length > 0) Then


    '            If (nombreTipo = "109") Then

    '                dgvPagos.Table.CurrentRecord.SetValue("tipoPago", (nombreTipo))
    '                dgvPagos.Table.CurrentRecord.SetValue("entidadFinanciera", "")
    '                dgvPagos.Table.CurrentRecord.SetValue("descripcionCuenta", nombreUbigeo)
    '                dgvPagos.Table.CurrentRecord.SetValue("NroOperacion", 0)
    '            Else
    '                If (nombreEntidad.Length > 0) Then
    '                    dgvPagos.Table.CurrentRecord.SetValue("tipoPago", (nombreTipo))
    '                    dgvPagos.Table.CurrentRecord.SetValue("entidadFinanciera", (nombreEntidad))
    '                    dgvPagos.Table.CurrentRecord.SetValue("descripcionCuenta", nombreUbigeo)
    '                    dgvPagos.Table.CurrentRecord.SetValue("NroOperacion", txtCuentaCorriente.Text)
    '                End If

    '            End If
    '        End If

    '        Panel1.Visible = False
    '    End If

    '    '    Else
    '    'Me.lblEstado.Text = "Debe ingresar bien los campos!"
    '    'Timer1.Enabled = True
    '    'PanelError.Visible = True
    '    'TiempoEjecutar(10)
    '    '    End If
    '    'Else
    '    'Me.lblEstado.Text = "Debe ingresar bien los campos!"
    '    'Timer1.Enabled = True
    '    'PanelError.Visible = True
    '    'TiempoEjecutar(10)
    '    'End If


    '    'If (Panel7.Tag = 1) Then
    '    '    nombreUbigeo = con.departamento & "/" & con.provincia & "/" & con.distrito
    '    '    txtUbigeo.Tag = con.ubigeo1
    '    '    txtUbigeo.Text = nombreUbigeo
    '    '    Panel7.Visible = False
    '    'Else
    '    '    If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
    '    '        nombreUbigeo = con.departamento & "/" & con.provincia & "/" & con.distrito
    '    '        dgvCompra.Table.CurrentRecord.SetValue("idUbigeo", con.ubigeo1)
    '    '        dgvCompra.Table.CurrentRecord.SetValue("nombreUbigeo", nombreUbigeo)
    '    '        TextBoxExt1.Clear()
    '    '        TextBoxExt4.Clear()
    '    '        TextBoxExt3.Clear()
    '    '        Panel7.Visible = False
    '    '    End If
    '    'End If




    'End Sub

    Private Sub dgvPagos_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs) Handles dgvPagos.TableControlPushButtonClick
        Dim nombreUbigeo As String
        Dim nombreEntidad As String
        Dim nombreTipo As String
        '    Panel1.Tag = 0
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        If Not IsNothing(Me.dgvPagos.Table.CurrentRecord) Then
            If (ColIndex = 1 Or ColIndex = 2 Or ColIndex = 3 Or ColIndex = 4 Or ColIndex = 5 Or ColIndex = 9 Or ColIndex = 10 Or ColIndex = 11 _
            Or ColIndex = 6 Or ColIndex = 7 Or ColIndex = 8) Then

                If (dgvPagos.Table.CurrentRecord.GetValue("montoMN") > 0) Then
                    Dim f As New frmDetallePagoDirecto
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()
                    If Not IsNothing(f.Tag) Then
                        Dim c = CType(f.Tag, CajaSeleccionada)
                        nombreUbigeo = c.FormaPagoDetalle & c.entidadDetalle ' cboTipoDocumento.Text & cboEntidad.Text
                        nombreTipo = c.FormaPago ' cboTipoDocumento.SelectedValue
                        nombreEntidad = c.entidad 'cboEntidad.SelectedValue

                        If (nombreTipo.Length > 0) Then


                            If (nombreTipo = "109") Then
                                dgvPagos.TableModel(e.Inner.RowIndex, 9).CellValue = nombreUbigeo
                                dgvPagos.TableModel(e.Inner.RowIndex, 10).CellValue = 0
                                dgvPagos.TableModel(e.Inner.RowIndex, 12).CellValue = nombreTipo
                                dgvPagos.TableModel(e.Inner.RowIndex, 13).CellValue = c.entidad
                                'dgvPagos.Table.CurrentRecord.SetValue("tipoPago", (nombreTipo))
                                'dgvPagos.Table.CurrentRecord.SetValue("entidadFinanciera", "")
                                'dgvPagos.Table.CurrentRecord.SetValue("descripcionCuenta", nombreUbigeo)
                                'dgvPagos.Table.CurrentRecord.SetValue("NroOperacion", 0)
                            Else
                                If (nombreEntidad.Length > 0) Then
                                    dgvPagos.TableModel(e.Inner.RowIndex, 9).CellValue = nombreUbigeo
                                    dgvPagos.TableModel(e.Inner.RowIndex, 10).CellValue = c.CuentaCorriente
                                    dgvPagos.TableModel(e.Inner.RowIndex, 12).CellValue = nombreTipo
                                    dgvPagos.TableModel(e.Inner.RowIndex, 13).CellValue = c.entidad

                                    'dgvPagos.Table.CurrentRecord.SetValue("tipoPago", (nombreTipo))
                                    'dgvPagos.Table.CurrentRecord.SetValue("entidadFinanciera", (nombreEntidad))
                                    'dgvPagos.Table.CurrentRecord.SetValue("descripcionCuenta", nombreUbigeo)
                                    'dgvPagos.Table.CurrentRecord.SetValue("NroOperacion", c.CuentaCorriente)
                                End If

                            End If
                        End If

                    End If

                    'cboTipoDocumento.SelectedValue = -1
                    'cboEntidad.SelectedValue = -1
                    'txtCuentaCorriente.Clear()
                    'Panel1.Visible = True
                Else
                    Me.lblEstado.Text = "Debe ingresar un monto!"
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)
                End If

            Else
                Me.lblEstado.Text = "Debe seleccionar el campo de manipulación!"
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
            End If
        Else
            Me.lblEstado.Text = "Debe seleccionar el campo Provincia/Departamento/Distrito!"
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)
        End If
    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click

    End Sub

    Private Sub dgvPagos_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvPagos.TableControlCellClick
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        If Not IsNothing(Me.dgvPagos.Table.CurrentRecord) Then

            If (dgvPagos.Table.CurrentRecord.GetValue("montoMN") > 0) Then
                'cboTipoDocumento.SelectedValue = -1
                'cboEntidad.SelectedValue = -1
                'txtCuentaCorriente.Clear()
                'Panel1.Visible = True
                Else
                    Me.lblEstado.Text = "Debe ingresar un monto!"
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)
                End If

            Else
                Me.lblEstado.Text = "Debe seleccionar el campo de manipulación!"
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
            End If

    End Sub

   
End Class