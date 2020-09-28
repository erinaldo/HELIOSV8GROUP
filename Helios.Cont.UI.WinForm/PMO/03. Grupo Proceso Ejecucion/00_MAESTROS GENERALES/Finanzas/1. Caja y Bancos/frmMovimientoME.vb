Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class frmMovimientoME

#Region "Attributes"
    Public Property ListaEstadosFiancierosME() As New List(Of estadosFinancieros)
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GridCFG(dgDepositoExtranjero)
        GridCFG(GridGroupingControl1)

        txtPeriodoAFME.Value = DateTime.Now

    End Sub
#End Region

#Region "Métodos"
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

    Sub DetallePagosME(iddoc As Integer)
        Dim cajaSA As New movimientocajaextranjeraSA
        Dim dt As New DataTable
        dt.Columns.Add("fecha")
        dt.Columns.Add("tipo")
        dt.Columns.Add("importe")
        dt.Columns.Add("tipocambioinit")
        dt.Columns.Add("tipocambio2")
        dt.Columns.Add("diferencia")
        Dim strTipo As String = Nothing
        For Each i In cajaSA.GetMovimientosDetalleByDepodito(New movimientocajaextranjera With {.idDocumento = iddoc})
            If i.tipomovimiento = StatusCajaExtranjera.cobro Then
                strTipo = "Cobro"
            Else
                strTipo = "Pago"
            End If
            dt.Rows.Add(i.fecha, strTipo, i.importe, i.tipocambioorigen, i.tipocambio, i.tipocambio - i.tipocambioorigen)
        Next
        GridGroupingControl1.DataSource = dt
    End Sub

    Public Sub GetDepositosME(be As estadosFinancieros)
        Dim cajaSA As New DocumentoCajaSA
        Dim dt As New DataTable
        dt.Columns.Add("iddoc")
        dt.Columns.Add("fecha")
        dt.Columns.Add("montodeposito")
        dt.Columns.Add("saldo")
        dt.Columns.Add("tipocambio")
        dt.Columns.Add("estado")

        Dim strEstado As String = Nothing
        For Each i In cajaSA.GetDepositosExtranjeros(be)
            If i.estadopago = StatusPagoMonedaExtranjera.Pendiente Then
                strEstado = "Pendiente"
            Else
                strEstado = "Saldado"
            End If

            dt.Rows.Add(i.idDocumento, i.fechaProceso, CDec(i.montoUsd).ToString("N2"), CDec(i.montoUsd - i.ImporteDesembolsado).ToString("N2"), i.tipoCambio, strEstado)
        Next
        dgDepositoExtranjero.DataSource = dt

    End Sub

    Sub ConsultasKardexME()
        Dim strPeriodo As String = Nothing
        strPeriodo = String.Format("{0:00}", CInt(txtPeriodoAFME.Value.Month)) & "/" & txtPeriodoAFME.Value.Year

        GetDepositosME(New estadosFinancieros With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                    .idestado = cboEntidadFinancieraME.SelectedValue,
                                                    .fechaBalance = New DateTime(txtPeriodoAFME.Value.Year, txtPeriodoAFME.Value.Month, 1)})
        'GetTableXperiodoME(CInt(cboEntidadFinancieraME.SelectedValue), strPeriodo)
    End Sub

    Public Sub CargarCajasTipoME(tiping As String)
        Dim estadoSA As New EstadosFinancierosSA
        Try
            ListaEstadosFiancierosME = estadoSA.ObtenerEstadosFinancierosPorMoneda(CInt(GEstableciento.IdEstablecimiento), tiping, CStr(2))
            Me.cboEntidadFinancieraME.DataSource = ListaEstadosFiancierosME
            Me.cboEntidadFinancieraME.DisplayMember = "descripcion"
            Me.cboEntidadFinancieraME.ValueMember = "idestado"
            cboEntidadFinancieraME.SelectedValue = -1
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
#End Region

#Region "Events"
    Private Sub frmMovimientoME_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cboEntidadFinancieraME_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEntidadFinancieraME.SelectedIndexChanged
        '    dgvKardexME.Table.Records.DeleteAll()
        If (Not IsNothing(ListaEstadosFiancierosME)) Then

            Dim cod = cboEntidadFinancieraME.SelectedValue

            If IsNumeric(cod) Then
                Dim conusulta = (From a In ListaEstadosFiancierosME Where a.idestado = cod Select a).FirstOrDefault
                If (Not IsNothing(conusulta)) Then
                    Select Case conusulta.codigo
                        Case 2
                            cboMonedakardexME.Text = "EXTRANJERA"
                    End Select

                End If
            End If
        End If
    End Sub

    Private Sub cboTipoME_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoME.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        '  dgvKardexME.Table.Records.DeleteAll()
        If cboTipoME.Text = "CUENTAS EN EFECTIVO" Then
            CargarCajasTipoME(CuentaFinanciera.Efectivo)
        ElseIf cboTipoME.Text = "CUENTAS EN BANCO" Then
            CargarCajasTipoME(CuentaFinanciera.Banco)
        ElseIf cboTipoME.Text = "TARJETA DE CREDITO" Then
            CargarCajasTipoME(CuentaFinanciera.Tarjeta_Credito)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Me.Cursor = Cursors.WaitCursor
        If (cboEntidadFinancieraME.Text.Length > 0) Then
            ConsultasKardexME()
        Else
            MessageBox.Show("Debe seleccionar una entidad financiera!")
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgDepositoExtranjero_TableControlCellClick(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs) Handles dgDepositoExtranjero.TableControlCellClick
        Me.Cursor = Cursors.WaitCursor
        Dim r As Record = dgDepositoExtranjero.Table.CurrentRecord
        If Not IsNothing(r) Then
            DetallePagosME(Val(r.GetValue("iddoc")))
        End If
        Me.Cursor = Cursors.Arrow
    End Sub
#End Region

End Class