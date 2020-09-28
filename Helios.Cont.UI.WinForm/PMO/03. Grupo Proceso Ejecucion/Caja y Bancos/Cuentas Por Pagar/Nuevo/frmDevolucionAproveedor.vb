Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping
Public Class frmDevolucionAproveedor
	Inherits frmMaster
	Public Property manipulacionEstado As String
	Public Property lblIdProveedor() As String
    Public Property lblCuentaProveedor() As String
    Public Property lblNomProveedor() As String

    Public Property lblIdDocumento As String

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

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ObtenerTablaGenerales()
        'ListaDocPago()
        txtTipoCambio.value = TmpTipoCambio
    End Sub


#Region "Métodos"


	Public Sub CargarDiferenciasdeImporte()
		Dim dt As New DataTable
		Dim documentoCajaEtalleSA As New DocumentoCajaDetalleSA
		Dim ListadocumentoCajaEtalle As New List(Of documentoCajaDetalle)
		Dim sumatoriaMN As Decimal
		Dim sumatoriaME As Decimal
		Dim DifsumatoriaMN As Decimal
		Dim DifsumatoriaME As Decimal
		Dim diferenciaCaja As Decimal


		Dim ListadocumentoCajaEtalle2 As New List(Of documentoCajaDetalle)

		dt.Columns.Add("idDocumento", GetType(Integer))
		dt.Columns.Add("TC", GetType(Decimal))
		dt.Columns.Add("importeMN", GetType(Decimal))
		dt.Columns.Add("importeME", GetType(Decimal))
		dt.Columns.Add("TCCompra", GetType(Decimal))
		dt.Columns.Add("importeCompraMN", GetType(Decimal))
		dt.Columns.Add("importeCompraME", GetType(Decimal))
		dt.Columns.Add("difMNCajaMN", GetType(Decimal))
		dt.Columns.Add("difMNCajaME", GetType(Decimal))

		If (cboMoneda.SelectedValue = 2 And tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF) Then
			ListadocumentoCajaEtalle = documentoCajaEtalleSA.ObtenerCajaDetalleME(txtImporteComprame.Value, cboDepositoHijo.SelectedValue)

			Me.dgvDiferencia.TableDescriptor.StackedHeaderRows.Clear()
			Me.dgvDiferencia.TableDescriptor.StackedHeaderRows.Remove("Row1")

			Dim gridStackedHeaderRowDescriptor1 As New GridStackedHeaderRowDescriptor()
			gridStackedHeaderRowDescriptor1.Name = "Row1"

			Dim gridStackedHeaderRowDescriptor2 As New GridStackedHeaderRowDescriptor()
			gridStackedHeaderRowDescriptor1.Name = "Row2"

			' Create an object for GridStackedHeaderDescriptor
			Dim gridStackedHeaderDescriptor1 As New GridStackedHeaderDescriptor()
			Dim gridStackedHeaderDescriptor2 As New GridStackedHeaderDescriptor()
			Dim gridStackedHeaderDescriptor3 As New GridStackedHeaderDescriptor()
			Dim gridStackedHeaderDescriptor4 As New GridStackedHeaderDescriptor()

			gridStackedHeaderDescriptor4.Appearance.StackedHeaderCell.Themed = False
			gridStackedHeaderDescriptor4.Appearance.StackedHeaderCell.TextColor = System.Drawing.Color.White
			gridStackedHeaderDescriptor4.Appearance.StackedHeaderCell.BackColor = Color.Red

			gridStackedHeaderDescriptor1.HeaderText = "CAJA Y BANCOS - " & cboDepositoHijo.Text

			gridStackedHeaderDescriptor1.Name = "StackedHeader 1"

			gridStackedHeaderDescriptor2.HeaderText = "CUENTAS POR PAGAR"
			gridStackedHeaderDescriptor2.Name = "StackedHeader 2"

			gridStackedHeaderDescriptor3.HeaderText = "DIFERENCIAS"
			gridStackedHeaderDescriptor3.Name = "StackedHeader 3"

			gridStackedHeaderDescriptor4.HeaderText = "DIFERENCIA T/C POR CAJA"
			gridStackedHeaderDescriptor4.Name = "StackedHeader 4"

			gridStackedHeaderDescriptor1.VisibleColumns.AddRange(New GridStackedHeaderVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("idDocumento"),
																	New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("TC"),
																	 New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("importeMN"),
																		   New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("importeME")})


			gridStackedHeaderDescriptor2.VisibleColumns.AddRange(New GridStackedHeaderVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("TCCompra"),
																	New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("importeCompraMN"),
																		   New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("importeCompraME")})

			gridStackedHeaderDescriptor3.VisibleColumns.AddRange(New GridStackedHeaderVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("difMNCajaMN"),
																	New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("difMNCajaME")})

			gridStackedHeaderRowDescriptor1.Headers.Add(gridStackedHeaderDescriptor1)
			gridStackedHeaderRowDescriptor1.Headers.Add(gridStackedHeaderDescriptor2)
			gridStackedHeaderRowDescriptor1.Headers.Add(gridStackedHeaderDescriptor3)
			gridStackedHeaderRowDescriptor2.Headers.Add(gridStackedHeaderDescriptor4)

			Me.dgvDiferencia.TableDescriptor.StackedHeaderRows.Add(gridStackedHeaderRowDescriptor2)
			Me.dgvDiferencia.TableDescriptor.StackedHeaderRows.Add(gridStackedHeaderRowDescriptor1)
			Me.dgvDiferencia.TopLevelGroupOptions.ShowStackedHeaders = True

			If Not IsNothing(ListadocumentoCajaEtalle) Then

				For Each i In ListadocumentoCajaEtalle
					Dim dr As DataRow = dt.NewRow()
					If (i.montoSoles > 0 And i.montoUsd > 0) Then
						dr(0) = i.idDocumento
						dr(1) = i.diferTipoCambio
						dr(2) = i.montoSoles
						dr(3) = i.montoUsd
						dr(4) = lblTipoCambio.Text
						sumatoriaMN = CDec(i.montoUsd * lblTipoCambio.Text).ToString("N2")
						sumatoriaME = CDec(i.montoUsd)
						dr(5) = sumatoriaMN
						dr(6) = sumatoriaME
						DifsumatoriaMN = CDec((lblTipoCambio.Text - i.diferTipoCambio) * i.montoUsd).ToString("N2")
						DifsumatoriaME = CDec(i.montoUsd - sumatoriaME)
						dr(7) = DifsumatoriaMN
						dr(8) = DifsumatoriaME

						diferenciaCaja += DifsumatoriaMN

						dt.Rows.Add(dr)
					End If

				Next
				dgvDiferencia.DataSource = dt
				Me.dgvDiferencia.TableOptions.ListBoxSelectionMode = SelectionMode.One
				'txtImporteCompramn.Value = sumatoriaMN
				txtDiferenciaMontos.Value = diferenciaCaja

			Else
			End If
		ElseIf (cboMoneda.SelectedValue = 1 And tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF) Then
			'ListadocumentoCajaEtalle = documentoCajaEtalleSA.ObtenerCajaDetalleME(txtImporteComprame.Value, cboDepositoHijo.SelectedValue)

			Me.dgvDiferencia.TableDescriptor.StackedHeaderRows.Clear()
			Me.dgvDiferencia.TableDescriptor.StackedHeaderRows.Remove("Row1")

			Dim gridStackedHeaderRowDescriptor1 As New GridStackedHeaderRowDescriptor()
			gridStackedHeaderRowDescriptor1.Name = "Row1"

			Dim gridStackedHeaderRowDescriptor2 As New GridStackedHeaderRowDescriptor()
			gridStackedHeaderRowDescriptor1.Name = "Row2"

			' Create an object for GridStackedHeaderDescriptor
			Dim gridStackedHeaderDescriptor1 As New GridStackedHeaderDescriptor()
			Dim gridStackedHeaderDescriptor2 As New GridStackedHeaderDescriptor()
			Dim gridStackedHeaderDescriptor3 As New GridStackedHeaderDescriptor()
			Dim gridStackedHeaderDescriptor4 As New GridStackedHeaderDescriptor()

			gridStackedHeaderDescriptor4.Appearance.StackedHeaderCell.Themed = False
			gridStackedHeaderDescriptor4.Appearance.StackedHeaderCell.TextColor = System.Drawing.Color.White
			gridStackedHeaderDescriptor4.Appearance.StackedHeaderCell.BackColor = Color.Red

			gridStackedHeaderDescriptor1.HeaderText = "CUENTAS POR PAGAR"
			gridStackedHeaderDescriptor1.Name = "StackedHeader 1"

			gridStackedHeaderDescriptor2.HeaderText = "FACTURA DE COMPRA"
			gridStackedHeaderDescriptor2.Name = "StackedHeader 2"

			gridStackedHeaderDescriptor3.HeaderText = "DIFERENCIAS"
			gridStackedHeaderDescriptor3.Name = "StackedHeader 3"

			gridStackedHeaderDescriptor4.HeaderText = "DIFERENCIA T/C POR CUENTAS POR PAGAR"
			gridStackedHeaderDescriptor4.Name = "StackedHeader 4"

			gridStackedHeaderDescriptor1.VisibleColumns.AddRange(New GridStackedHeaderVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("idDocumento"),
																	New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("TC"),
																	 New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("importeMN"),
																		   New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("importeME")})


			gridStackedHeaderDescriptor2.VisibleColumns.AddRange(New GridStackedHeaderVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("TCCompra"),
																	New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("importeCompraMN"),
																		   New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("importeCompraME")})

			gridStackedHeaderDescriptor3.VisibleColumns.AddRange(New GridStackedHeaderVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("difMNCajaMN"),
																	New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("difMNCajaME")})


			gridStackedHeaderRowDescriptor1.Headers.Add(gridStackedHeaderDescriptor1)
			gridStackedHeaderRowDescriptor1.Headers.Add(gridStackedHeaderDescriptor2)
			gridStackedHeaderRowDescriptor1.Headers.Add(gridStackedHeaderDescriptor3)
			gridStackedHeaderRowDescriptor2.Headers.Add(gridStackedHeaderDescriptor4)

			Me.dgvDiferencia.TableDescriptor.StackedHeaderRows.Add(gridStackedHeaderRowDescriptor2)
			Me.dgvDiferencia.TableDescriptor.StackedHeaderRows.Add(gridStackedHeaderRowDescriptor1)

			' Display Stacked Headers 
			Me.dgvDiferencia.TopLevelGroupOptions.ShowStackedHeaders = True



			If (manipulacionEstado = ENTITY_ACTIONS.UPDATE) Then
				Dim tipoCAmbio As Decimal
				Dim dr As DataRow = dt.NewRow()

				tipoCAmbio = CDec(txtImporteCompramn.Value / lblDeudaPendienteme.Text)

				dr(0) = 0
				dr(1) = txtTipoCambio.Value
				dr(2) = txtImporteCompramn.Value
				dr(3) = CDec(txtImporteCompramn.Value / (tipoCAmbio)).ToString("N2")
				dr(4) = lblTipoCambio.Text
				sumatoriaME = CDec(txtImporteCompramn.Value / tipoCAmbio).ToString("N2")
				sumatoriaMN = ((sumatoriaME) * lblTipoCambio.Text)


				dr(5) = sumatoriaMN
				dr(6) = sumatoriaME
				DifsumatoriaMN = CDec(sumatoriaMN - txtImporteCompramn.Value).ToString("N2")
				DifsumatoriaME = CDec(sumatoriaME - CDec(txtImporteCompramn.Value / tipoCAmbio)).ToString("N2")
				dr(7) = DifsumatoriaMN
				dr(8) = DifsumatoriaME

				dt.Rows.Add(dr)
				dgvDiferencia.DataSource = dt

				txtDiferenciaMontos.Value = DifsumatoriaMN
			Else
				Dim dr As DataRow = dt.NewRow()
				dr(0) = 0
				dr(1) = txtTipoCambio.Value
				dr(2) = txtImporteCompramn.Value
				dr(3) = CDec(txtImporteCompramn.Value / txtTipoCambio.Value).ToString("N2")
				dr(4) = lblTipoCambio.Text
				sumatoriaMN = CDec((CDec(txtImporteCompramn.Value / txtTipoCambio.Value) * lblTipoCambio.Text))
				sumatoriaME = CDec(txtImporteCompramn.Value / txtTipoCambio.Value).ToString("N2")

				dr(5) = sumatoriaMN
				dr(6) = sumatoriaME
				DifsumatoriaMN = CDec(sumatoriaMN - txtImporteCompramn.Value).ToString("N2")
				DifsumatoriaME = CDec(sumatoriaME - CDec(txtImporteCompramn.Value / txtTipoCambio.Value)).ToString("N2")
				dr(7) = DifsumatoriaMN
				dr(8) = DifsumatoriaME

				dt.Rows.Add(dr)
				dgvDiferencia.DataSource = dt

				txtDiferenciaMontos.Value = DifsumatoriaMN
			End If



		ElseIf (cboMoneda.SelectedValue = 2 And tb19.ToggleState = ToggleButton2.ToggleButtonState.ON) Then
			ListadocumentoCajaEtalle = documentoCajaEtalleSA.ObtenerCajaDetalleME(txtImporteComprame.Value, cboDepositoHijo.SelectedValue)

			Me.dgvDiferencia.TableDescriptor.StackedHeaderRows.Clear()
			Me.dgvDiferencia.TableDescriptor.StackedHeaderRows.Remove("Row1")

			Dim gridStackedHeaderRowDescriptor1 As New GridStackedHeaderRowDescriptor()
			gridStackedHeaderRowDescriptor1.Name = "Row1"

			Dim gridStackedHeaderRowDescriptor2 As New GridStackedHeaderRowDescriptor()
			gridStackedHeaderRowDescriptor1.Name = "Row2"

			' Create an object for GridStackedHeaderDescriptor
			Dim gridStackedHeaderDescriptor1 As New GridStackedHeaderDescriptor()
			Dim gridStackedHeaderDescriptor2 As New GridStackedHeaderDescriptor()
			Dim gridStackedHeaderDescriptor3 As New GridStackedHeaderDescriptor()
			Dim gridStackedHeaderDescriptor4 As New GridStackedHeaderDescriptor()

			gridStackedHeaderDescriptor4.Appearance.StackedHeaderCell.Themed = False
			gridStackedHeaderDescriptor4.Appearance.StackedHeaderCell.TextColor = System.Drawing.Color.White
			gridStackedHeaderDescriptor4.Appearance.StackedHeaderCell.BackColor = Color.Red

			gridStackedHeaderDescriptor1.HeaderText = "CAJA Y BANCOS"
			gridStackedHeaderDescriptor1.Name = "StackedHeader 1"

			gridStackedHeaderDescriptor2.HeaderText = "CUENTAS POR PAGAR"
			gridStackedHeaderDescriptor2.Name = "StackedHeader 2"

			gridStackedHeaderDescriptor3.HeaderText = "DIFERENCIAS"
			gridStackedHeaderDescriptor3.Name = "StackedHeader 3"

			gridStackedHeaderDescriptor4.HeaderText = "DIFERENCIA T/C POR CAJA"
			gridStackedHeaderDescriptor4.Name = "StackedHeader 4"

			gridStackedHeaderDescriptor1.VisibleColumns.AddRange(New GridStackedHeaderVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("idDocumento"),
																	New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("TC"),
																	 New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("importeMN"),
																		   New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("importeME")})

			gridStackedHeaderDescriptor2.VisibleColumns.AddRange(New GridStackedHeaderVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("TCCompra"),
																	New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("importeCompraMN"),
																		   New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("importeCompraME")})

			gridStackedHeaderDescriptor3.VisibleColumns.AddRange(New GridStackedHeaderVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("difMNCajaMN"),
																	New Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("difMNCajaME")})


			gridStackedHeaderRowDescriptor1.Headers.Add(gridStackedHeaderDescriptor1)
			gridStackedHeaderRowDescriptor1.Headers.Add(gridStackedHeaderDescriptor2)
			gridStackedHeaderRowDescriptor1.Headers.Add(gridStackedHeaderDescriptor3)
			gridStackedHeaderRowDescriptor2.Headers.Add(gridStackedHeaderDescriptor4)

			Me.dgvDiferencia.TableDescriptor.StackedHeaderRows.Add(gridStackedHeaderRowDescriptor2)
			Me.dgvDiferencia.TableDescriptor.StackedHeaderRows.Add(gridStackedHeaderRowDescriptor1)

			' Display Stacked Headers 
			Me.dgvDiferencia.TopLevelGroupOptions.ShowStackedHeaders = True

			If Not IsNothing(ListadocumentoCajaEtalle) Then

				For Each i In ListadocumentoCajaEtalle
					Dim dr As DataRow = dt.NewRow()

					dr(0) = i.idDocumento
					dr(1) = i.diferTipoCambio
					dr(2) = i.montoSoles
					dr(3) = i.montoUsd
					dr(4) = txtTipoCambio.Value
					sumatoriaMN = CDec((i.montoUsd * txtTipoCambio.Value)).ToString("N2")
					sumatoriaME = i.montoUsd
					dr(5) = sumatoriaMN
					dr(6) = sumatoriaME

					DifsumatoriaMN = CDec((txtTipoCambio.Text - i.diferTipoCambio) * i.montoUsd).ToString("N2")
					DifsumatoriaME = CDec(sumatoriaME - i.montoUsd)
					dr(7) = DifsumatoriaMN
					dr(8) = DifsumatoriaME

					diferenciaCaja += DifsumatoriaMN

					dt.Rows.Add(dr)

				Next
				dgvDiferencia.DataSource = dt
				Me.dgvDiferencia.TableOptions.ListBoxSelectionMode = SelectionMode.One
				'txtImporteCompramn.Value = sumatoriaMN
				txtDiferenciaMontos.Value = diferenciaCaja
			Else
			End If
		End If

	End Sub

	'Public Sub CargarMovimientosDetallado(intIdDocumento As Integer)
	'	Dim dt As New DataTable
	'	Dim DocumentoCajaDetalleSA As New DocumentoCompraDetalleSA
	'	Dim ListadocumentoCajaEtalle As New List(Of documentoCajaDetalle)
	'	Dim documentoCajaEtalleSA As New DocumentoCajaDetalleSA
	'	Dim saldoME As Decimal = 0
	'	Dim saldoMN As Decimal = 0
	'	Dim saldoItem As Decimal = 0
	'	Dim saldoItemME As Decimal = 0
	'	Dim listadocumento As New List(Of documentoCajaDetalle)
	'	Dim docuem As New documentoCajaDetalle
	'	Dim cajaUsariodetalleBE As New cajaUsuariodetalle
	'	Dim cajaUsariodetalleListaBE As New List(Of cajaUsuariodetalle)
	'	Dim ndocumentoCajaDetalle As New documentoCajaDetalle
	'	Dim ListadocumentoCajaDetalle As New List(Of documentoCajaDetalle)

	'	dt.Columns.Add("idDocumento", GetType(Integer)) '1
	'	dt.Columns.Add("item", GetType(String)) '2
	'	dt.Columns.Add("importeMN", GetType(Decimal)) '3
	'	dt.Columns.Add("importeME", GetType(Decimal)) '4
	'	dt.Columns.Add("TC", GetType(Decimal)) '5
	'	dt.Columns.Add("pagoMN", GetType(Decimal)) '6
	'	dt.Columns.Add("pagoME", GetType(Decimal)) '7
	'	dt.Columns.Add("saldoMN", GetType(Decimal)) '8
	'	dt.Columns.Add("saldoME", GetType(Decimal)) '9


	'	For Each i As DataGridViewRow In dgvDetalleItems.Rows
	'		If CDec(dgvDetalleItems.Rows(i.Index).Cells(6).Value()) > 0 Then
	'			ndocumentoCajaDetalle = New documentoCajaDetalle
	'			ndocumentoCajaDetalle.fecha = txtFechaTrans.Value
	'			ndocumentoCajaDetalle.idItem = dgvDetalleItems.Rows(i.Index).Cells(0).Value()
	'			ndocumentoCajaDetalle.DetalleItem = dgvDetalleItems.Rows(i.Index).Cells(1).Value()

	'			Select Case cboMoneda.SelectedValue
	'				Case 1
	'					ndocumentoCajaDetalle.montoSoles = CDec(dgvDetalleItems.Rows(i.Index).Cells(6).Value())
	'					ndocumentoCajaDetalle.montoUsd = CDec(dgvDetalleItems.Rows(i.Index).Cells(7).Value())
	'				Case 2
	'					Select Case tb19.ToggleState
	'						Case ToggleButton2.ToggleButtonState.OFF 'dolares
	'							ndocumentoCajaDetalle.montoSoles = CDec(dgvDetalleItems.Rows(i.Index).Cells(7).Value() * txtTipoCambio.Value).ToString("N2")
	'							ndocumentoCajaDetalle.montoUsd = CDec(dgvDetalleItems.Rows(i.Index).Cells(7).Value())
	'						Case ToggleButton2.ToggleButtonState.ON 'soles
	'							ndocumentoCajaDetalle.montoSoles = CDec(dgvDetalleItems.Rows(i.Index).Cells(6).Value())
	'							ndocumentoCajaDetalle.montoUsd = CDec(dgvDetalleItems.Rows(i.Index).Cells(7).Value())
	'					End Select
	'			End Select

	'			ndocumentoCajaDetalle.entregado = "SI"
	'			ndocumentoCajaDetalle.tipoCambioTransacc = txtTipoCambio.Value
	'			ndocumentoCajaDetalle.moneda = cboMoneda.SelectedValue
	'			ndocumentoCajaDetalle.documentoAfectado = lblIdDocumento.Text
	'			ndocumentoCajaDetalle.usuarioModificacion = CStr(cboDepositoHijo.SelectedValue)
	'			ndocumentoCajaDetalle.fechaModificacion = txtFechaTrans.Value
	'			ndocumentoCajaDetalle.idCajaPadre = cboDepositoHijo.SelectedValue
	'			ndocumentoCajaDetalle.documentoAfectadodetalle = dgvDetalleItems.Rows(i.Index).Cells(11).Value()
	'			ListadocumentoCajaDetalle.Add(ndocumentoCajaDetalle)
	'		End If
	'	Next

	'	dgvDistribucionME.Table.Records.DeleteAll()
	'	ListadocumentoCajaEtalle = documentoCajaEtalleSA.ObtenerCajaDetalleME(txtImporteComprame.Value, cboDepositoHijo.SelectedValue)

	'	For Each i In ListadocumentoCajaDetalle

	'		Dim consultaCaja = (From c In ListadocumentoCajaEtalle
	'							Order By c.fecha).ToList
	'		For Each item In consultaCaja

	'			Dim Salidas = (Aggregate n In listadocumento
	'					   Where n.documentoAfectado = item.idDocumento
	'					   Into sumMN = Sum(n.montoSoles), sumME = Sum(n.montoUsd))

	'			Select Case i.moneda
	'				Case 2
	'					saldoME = i.montoUsd
	'					saldoMN = i.montoSoles
	'					If (saldoME > 0) Then
	'						Dim dr As DataRow = dt.NewRow()
	'						dr(0) = i.idItem
	'						dr(1) = i.DetalleItem
	'						If ((item.montoUsd - Salidas.sumME.GetValueOrDefault) >= i.montoUsd And i.montoUsd = 0) Then
	'							dr(2) = i.montoSoles
	'							dr(3) = i.montoUsd
	'							dr(4) = item.diferTipoCambio
	'							dr(5) = i.ImporteNacional
	'							dr(6) = i.montoUsd
	'							dr(7) = CDec(i.montoSoles - i.montoSoles).ToString("N2")
	'							dr(8) = CDec(i.montoUsd - i.montoUsd).ToString("N2")
	'							saldoME = item.montoUsd - i.montoUsd
	'							saldoMN = item.montoSoles - i.montoSoles
	'							i.montoUsd = saldoME
	'							i.montoSoles = saldoMN
	'							dt.Rows.Add(dr)
	'						ElseIf ((item.montoUsd - Salidas.sumME.GetValueOrDefault) <= i.montoUsd And i.montoUsd = 0) Then
	'							dr(2) = i.montoSoles
	'							dr(3) = i.montoUsd
	'							dr(4) = item.diferTipoCambio
	'							dr(5) = i.montoSoles
	'							dr(6) = i.montoUsd
	'							dr(7) = CDec(i.montoSoles - i.montoSoles).ToString("N2")
	'							dr(8) = CDec(i.montoUsd - i.montoUsd).ToString("N2")
	'							saldoME = item.montoUsd - i.montoUsd
	'							saldoMN = item.montoSoles - i.montoSoles
	'							i.montoUsd = saldoME
	'							i.montoSoles = saldoMN
	'							dt.Rows.Add(dr)
	'						ElseIf ((item.montoUsd - Salidas.sumME.GetValueOrDefault) < i.montoUsd And i.montoUsd > 0 And (item.montoUsd - Salidas.sumME.GetValueOrDefault) > 0) Then
	'							dr(2) = i.montoSoles
	'							dr(3) = i.montoUsd
	'							dr(4) = item.diferTipoCambio
	'							dr(5) = Math.Round(CDec((item.montoUsd - Salidas.sumME.GetValueOrDefault) * item.diferTipoCambio), 2)
	'							dr(6) = (item.montoUsd - Salidas.sumME.GetValueOrDefault)
	'							dr(7) = CDec(i.montoSoles - dr(5)).ToString("N2")
	'							dr(8) = CDec(i.montoUsd - dr(6)).ToString("N2")
	'							saldoME = saldoME - dr(6)
	'							saldoMN = saldoMN - dr(5)
	'							i.montoUsd = saldoME
	'							i.montoSoles = saldoMN
	'							docuem = New documentoCajaDetalle
	'							docuem.documentoAfectado = item.idDocumento
	'							docuem.montoSoles = dr(5)
	'							docuem.montoUsd = dr(6)
	'							listadocumento.Add(docuem)
	'							dt.Rows.Add(dr)
	'						ElseIf ((item.montoUsd - Salidas.sumME) > i.montoUsd And i.montoUsd > 0) Then
	'							dr(2) = i.montoSoles
	'							dr(3) = i.montoUsd
	'							dr(4) = item.diferTipoCambio
	'							dr(5) = Math.Round(CDec(i.montoUsd * item.diferTipoCambio), 2)
	'							dr(6) = i.montoUsd
	'							dr(7) = CDec(i.montoSoles - dr(5)).ToString("N2")
	'							dr(8) = CDec(i.montoUsd - dr(6)).ToString("N2")
	'							saldoME = saldoME - i.montoUsd
	'							saldoMN = saldoMN - i.montoSoles
	'							i.montoUsd = saldoME
	'							i.montoSoles = saldoMN
	'							docuem = New documentoCajaDetalle
	'							docuem.documentoAfectado = item.idDocumento
	'							docuem.montoSoles = dr(5)
	'							docuem.montoUsd = dr(6)
	'							listadocumento.Add(docuem)
	'							dt.Rows.Add(dr)
	'						ElseIf ((item.montoUsd - Salidas.sumME) > i.montoUsd And i.montoUsd < 0) Then
	'							dr(2) = i.montoSoles
	'							dr(3) = i.montoUsd
	'							dr(4) = item.diferTipoCambio
	'							dr(5) = Math.Round(CDec((i.montoUsd * -1) * item.diferTipoCambio), 2)
	'							dr(6) = Math.Round(CDec(i.montoUsd * -1), 2)
	'							dr(7) = CDec(i.montoSoles - dr(5)).ToString("N2")
	'							dr(8) = CDec(i.montoUsd - dr(6)).ToString("N2")
	'							saldoME = item.montoUsd - i.montoUsd
	'							saldoMN = item.montoSoles - i.montoSoles
	'							i.montoUsd = saldoME
	'							i.montoSoles = saldoMN
	'							docuem = New documentoCajaDetalle
	'							docuem.documentoAfectado = item.idDocumento
	'							docuem.montoSoles = dr(5)
	'							docuem.montoUsd = dr(6)
	'							listadocumento.Add(docuem)
	'							dt.Rows.Add(dr)
	'						ElseIf ((item.montoUsd - Salidas.sumME) = i.montoUsd And i.montoUsd > 0) Then
	'							dr(2) = i.montoSoles
	'							dr(3) = i.montoUsd
	'							dr(4) = item.diferTipoCambio
	'							dr(5) = Math.Round(CDec(i.montoUsd * item.diferTipoCambio), 2)
	'							dr(6) = i.montoUsd
	'							dr(7) = CDec(i.montoSoles - dr(5)).ToString("N2")
	'							dr(8) = CDec(i.montoUsd - dr(6)).ToString("N2")
	'							saldoME = saldoME - i.montoUsd
	'							saldoMN = saldoMN - i.montoSoles
	'							i.montoUsd = saldoME
	'							i.montoSoles = saldoMN
	'							docuem = New documentoCajaDetalle
	'							docuem.documentoAfectado = item.idDocumento
	'							docuem.montoSoles = dr(5)
	'							docuem.montoUsd = dr(6)
	'							listadocumento.Add(docuem)
	'							dt.Rows.Add(dr)
	'						End If

	'					End If
	'			End Select


	'		Next

	'	Next

	'	dgvDistribucionME.DataSource = dt


	'End Sub

	Public Sub CargarCajasTipo(strBusqueda As String)
        Dim estadoSA As New EstadosFinancierosSA
        Dim taBLASA As New tablaDetalleSA
        Dim ListaestadoBL As New List(Of estadosFinancieros)
        Dim estadoBL As New estadosFinancieros

        Try
			Me.cboDepositoHijo.DataSource = estadoSA.ObtenerEFPorCuentaFinanciera(New estadosFinancieros With {.idEmpresa = Gempresas.IdEmpresaRuc,
																				  .idEstablecimiento = GEstableciento.IdEstablecimiento,
																				  .tipo = strBusqueda,
																				  .tipoConsulta = StatusTipoConsulta.XEmpresa})
			Me.cboDepositoHijo.DisplayMember = "descripcion"
            Me.cboDepositoHijo.ValueMember = "idestado"
            cboDepositoHijo.SelectedValue = -1

			cboMoneda.ValueMember = "codigoDetalle"
			cboMoneda.DisplayMember = "descripcion"
			cboMoneda.DataSource = taBLASA.GetListaTablaDetalle(4, "1")
			cboMoneda.SelectedValue = -1

		Catch ex As Exception

		End Try
	End Sub

	Private Sub cargarCtasFinan()
		If cboTipo.Text = "CUENTAS EN EFECTIVO" Then
			CargarCajasTipo("EF")
			Dim lista As New List(Of String)
			lista.Add("001")
			lista.Add("109")
			ListaDocPago(lista)
			cboTipoDocumento.SelectedValue = "001"
		ElseIf cboTipo.Text = "CUENTAS EN BANCO" Then
			CargarCajasTipo("BC")
			Dim lista As New List(Of String)
			lista.Add("001")
			lista.Add("003")
			lista.Add("007")
			lista.Add("111")
			ListaDocPago(lista)
			cboTipoDocumento.SelectedValue = "001"
		ElseIf cboTipo.Text = "TARJETA DE CREDITO" Then
			CargarCajasTipo("TC")
			Dim lista As New List(Of String)
			lista.Add("001")
			ListaDocPago(lista)
			cboTipoDocumento.SelectedValue = "001"
		End If
	End Sub

	Private Sub cargarDatosCuenta(idCaja As Integer)
		Dim estadoSA As New EstadosFinancierosSA
		Dim estadoBL As New estadosFinancieros
		Dim estadoSaldoBL As New estadosFinancieros

		estadoBL = estadoSA.GetUbicar_estadosFinancierosPorID(cboDepositoHijo.SelectedValue)
		estadoSaldoBL = estadoSA.GetEstadoSaldoEFME(cboDepositoHijo.SelectedValue, Date.Now)
		If (Not IsNothing(estadoBL)) Then
			cboMoneda.SelectedValue = estadoBL.codigo
			txtCuentaOrigen.Text = estadoBL.cuenta
			nudDeudaPendienteme.Value = estadoSaldoBL.importeBalanceME
			nudDeudaPendientemn.Value = estadoSaldoBL.importeBalanceMN
			Select Case cboMoneda.SelectedValue
				Case 1
					'pnNacional.Location = New Point(49, 25)
					'pnExtranjero.Location = New Point(420, 25)
					'pnImpMEDisp.Location = New Point(170, 21)
					'pnImpMNDisp.Location = New Point(9, 21)
					'nudMonedaExtranjero.Enabled = False
					'               nudMonedaNacional.Enabled = True
					'               'PictureBox5.Visible = False
					'               pnDiferencia.Visible = False
					'               nudMonedaNacional.Value = 0.0
					'               nudMonedaExtranjero.Value = 0.0
					'               txtTipoCambio.Value = 0
					'txtDiferenciaMontos.Value = 0

					txtImporteComprame.Enabled = True
					txtImporteCompramn.Enabled = False
					PictureBox5.Visible = False
					pnDiferencia.Visible = False
					txtImporteCompramn.Value = 0.0
					txtImporteComprame.Value = 0.0
					txtDiferenciaMontos.Value = 0

					Select Case tb19.ToggleState
						Case ToggleButton2.ToggleButtonState.OFF 'dolares
							'                     pnTipoCambio.Visible = True
							'                     pnExtranjero.Visible = True
							'                     pnDiferencia.Visible = True
							'                     pnDiferencia.Location = New Point(650, 25)
							'pnTipoCambio.Enabled = True

							colMN.Visible = False
							colSaldoMN.Visible = False
							colPagoMN.Visible = False
							'  pnImpMNDisp.Visible = True
							colME.Visible = True
							colSaldoME.Visible = True
							colPagoME.Visible = True
							PanelDetallePagos.Enabled = True
						Case ToggleButton2.ToggleButtonState.ON 'soles
							'pnTipoCambio.Visible = True
							'pnExtranjero.Visible = True
							'pnDiferencia.Visible = False
							'pnTipoCambio.Enabled = False
							'txtTipoCambio.Value = lblTipoCambio.Text
							txtImporteCompramn.Enabled = True
							'pnTipoCambio.Visible = True
							'pnExtranjero.Visible = True
							'pnDiferencia.Visible = False
							'pnTipoCambio.Enabled = False
							txtTipoCambio.Value = lblTipoCambio.Text
							''     pnImpMEDisp.Visible = False
							'pnTipoCambioCompra.Visible = False
							'pnTipoCambio.Visible = False
							'pnDiferencia.Visible = False
							'pnExtranjero.Visible = False
							colME.Visible = False
							colSaldoME.Visible = False
							colPagoME.Visible = False
							PanelDetallePagos.Enabled = True
					End Select

				Case 2

					'pnExtranjero.Location = New Point(49, 25)
					'pnImpMEDisp.Location = New Point(9, 21)
					'pnImpMNDisp.Location = New Point(170, 21)
					'nudMonedaExtranjero.Enabled = True
					'nudMonedaNacional.Enabled = False
					''PictureBox5.Visible = True
					'pnDiferencia.Visible = True
					'nudMonedaNacional.Value = 0.0
					'nudMonedaExtranjero.Value = 0.0
					'txtTipoCambio.Value = 0
					'txtDiferenciaMontos.Value = 0
					PictureBox5.Visible = True
					pnDiferencia.Visible = True
					txtImporteCompramn.Value = 0.0
					txtImporteComprame.Value = 0.0
					txtDiferenciaMontos.Value = 0
					Select Case tb19.ToggleState
						Case ToggleButton2.ToggleButtonState.OFF 'dolares
							'pnTipoCambio.Visible = True
							'pnExtranjero.Visible = True
							'pnDiferencia.Visible = True
							'pnExtranjero.Enabled = True
							'pnNacional.Location = New Point(430, 25)
							'pnDiferencia.Location = New Point(650, 25)
							'txtTipoCambio.Value = lblTipoCambio.Text
							'pnTipoCambio.Enabled = False
							pnSaldoMN.Visible = False
							pnTipoCambio.Visible = True
							pnExtranjero.Visible = True
							pnDiferencia.Visible = True
							pnExtranjero.Enabled = True
							pnNacional.Enabled = False
							'pnExtranjero.Location = New Point(49, 25)
							'pnNacional.Location = New Point(430, 25)
							'pnDiferencia.Location = New Point(650, 25)
							txtTipoCambio.Value = lblTipoCambio.Text
							pnTipoCambio.Enabled = False
							'       pnImpMNDisp.Visible = False
							'pnTipoCambioCompra.Visible = True
							pnTipoCambio.Visible = True
							pnDiferencia.Visible = True
							pnExtranjero.Visible = True
							PanelDetallePagos.Enabled = True
							colMN.Visible = False
							colSaldoMN.Visible = False
							colPagoMN.Visible = False
							colME.Visible = True
							colSaldoME.Visible = True
							colPagoME.Visible = True
						Case ToggleButton2.ToggleButtonState.ON 'soles
							'pnTipoCambio.Visible = True
							'pnExtranjero.Visible = True
							'pnDiferencia.Visible = True
							'pnNacional.Location = New Point(430, 25)
							'pnDiferencia.Location = New Point(650, 25)
							'txtTipoCambio.Value = 0.0
							'pnTipoCambio.Enabled = True

							pnSaldoME.Visible = True
							pnTipoCambio.Visible = True
							pnExtranjero.Visible = True
							pnDiferencia.Visible = True
							'pnNacional.Location = New Point(49, 25)
							'pnExtranjero.Location = New Point(430, 25)
							'pnDiferencia.Location = New Point(650, 25)
							pnTipoCambio.Enabled = False
							pnNacional.Enabled = True
							pnExtranjero.Enabled = False
							'      pnImpMEDisp.Visible = True
							'pnTipoCambioCompra.Visible = True
							pnDiferencia.Visible = True
							pnExtranjero.Visible = True
							colMN.Visible = True
							colSaldoMN.Visible = True
							colPagoMN.Visible = True
							colME.Visible = False
							colSaldoME.Visible = False
							colPagoME.Visible = False
							txtImporteCompramn.Enabled = True
							PanelDetallePagos.Enabled = True
					End Select
			End Select
		End If
	End Sub

	Public Function AS_DebeCaja(Cuenta As String, cDescripcion As String, cMonto As Decimal, cMontoUS As Decimal) As movimiento
		Dim nMovimiento As New movimiento
		nMovimiento = New movimiento With {
			  .cuenta = "46",
			  .descripcion = "CUENTAS POR PAGAR DIVERSAS – TERCEROS",
			  .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
			  .monto = cMonto,
			  .montoUSD = cMontoUS,
			  .fechaActualizacion = DateTime.Now,
			  .usuarioActualizacion = GFichaUsuarios.IdCajaUsuario}

		Return nMovimiento
	End Function

	Public Function AS_HaberCliente(cMonto As Decimal, cMontoUS As Decimal) As movimiento
		Dim EFSA As New EstadosFinancierosSA
		Dim nMovimiento As New movimiento
		Dim EF As New estadosFinancieros
		EF = EFSA.GetUbicar_estadosFinancierosPorID(GFichaUsuarios.IdCajaDestino)

		nMovimiento = New movimiento With {
	  .cuenta = EF.cuenta,
	  .descripcion = EF.descripcion,
	  .tipo = ASIENTO_CONTABLE.UBICACION.HABER,
	  .monto = cMonto,
	  .montoUSD = cMontoUS,
	  .fechaActualizacion = DateTime.Now,
	  .usuarioActualizacion = GFichaUsuarios.IdCajaUsuario}

		Return nMovimiento


	End Function

	Function asientoCaja() As asiento
		Dim cuentaFinacieraSA As New EstadosFinancierosSA
		Dim nAsiento As New asiento
		Dim nDebe As New movimiento
		Dim nHaber As New movimiento

		nAsiento = New asiento
		nAsiento.idDocumento = 0
		nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
		nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
		nAsiento.idEntidad = lblIdProveedor
		nAsiento.nombreEntidad = lblNomProveedor
		nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
		nAsiento.fechaProceso = txtFechaComprobante.Text
		nAsiento.codigoLibro = "1"
		nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
		nAsiento.tipoAsiento = ASIENTO_CONTABLE.PAGO_COMPRA
		nAsiento.importeMN = txtImporteCompramn.Value   ' dgvDetalleItems.Rows(i.Index).Cells(6).Value()
		nAsiento.importeME = txtImporteComprame.Value   ' dgvDetalleItems.Rows(i.Index).Cells(7).Value()
		nAsiento.glosa = "DEVOLUCIÓN A PORVEEDORES" & txtFechaComprobante.Text
		nAsiento.usuarioActualizacion = GFichaUsuarios.IdCajaUsuario
		nAsiento.fechaActualizacion = DateTime.Now

		For Each i As DataGridViewRow In dgvDetalleItems.Rows
			If CDec(dgvDetalleItems.Rows(i.Index).Cells(6).Value()) > 0 Then
				nAsiento.movimiento.Add(AS_DebeCaja(cuentaFinacieraSA.GetUbicar_estadosFinancierosPorID(GFichaUsuarios.IdCajaDestino).cuenta, dgvDetalleItems.Rows(i.Index).Cells(1).Value(), dgvDetalleItems.Rows(i.Index).Cells(6).Value(), dgvDetalleItems.Rows(i.Index).Cells(7).Value()))
				nAsiento.movimiento.Add(AS_HaberCliente(dgvDetalleItems.Rows(i.Index).Cells(6).Value(), dgvDetalleItems.Rows(i.Index).Cells(7).Value()))
			End If
		Next

		Return nAsiento
	End Function

	Public Sub Grabar()
		Dim documentoCompraSA As New DocumentoCompraSA
		Dim documentoSA As New DocumentoSA
		Dim documentoCajaSA As New DocumentoCajaSA
		Dim ndocumento As New documento
		Dim ndocumentoCaja As New documentoCaja
		Dim ndocumentoCajaDetalle As New documentoCajaDetalle
		Dim ListadocumentoCajaDetalle As New List(Of documentoCajaDetalle)
		Dim asiento As New asiento
		Dim ListaAsiento As New List(Of asiento)

		Dim n As New RecolectarDatos()
		Dim datos As List(Of RecolectarDatos) = RecolectarDatos.Instance()
		datos.Clear()
		Try

			With ndocumento
				.idDocumento = lblIdDocumento
				.idEmpresa = Gempresas.IdEmpresaRuc
				.idCentroCosto = GEstableciento.IdEstablecimiento
				If Not IsNothing(GProyectos) Then
					.idProyecto = GProyectos.IdProyectoActividad
				End If
				.tipoDoc = cboTipoDocumento.SelectedValue
				.fechaProceso = txtFechaComprobante.Text
				.nroDoc = txtNumeroOper.Text.Trim
				.idOrden = Nothing
				.tipoOperacion = "9922"
				.usuarioActualizacion = usuario.IDUsuario
				.fechaActualizacion = DateTime.Now
			End With

			With ndocumentoCaja
				.codigoLibro = "9922"
				.periodo = PeriodoGeneral
				.idDocumento = lblIdDocumento
				.idEmpresa = Gempresas.IdEmpresaRuc
				.idEstablecimiento = GEstableciento.IdEstablecimiento
				.tipoMovimiento = TIPO_VENTA.PAGO.COBRADO
				.codigoProveedor = lblIdProveedor
				.fechaProceso = txtFechaComprobante.Text
				.fechaCobro = txtFechaComprobante.Text
				.tipoDocPago = cboTipoDocumento.SelectedValue
				If cboTipoDocumento.SelectedValue = "109" Then
					.numeroDoc = Nothing
					.entregado = "SI"
				ElseIf cboTipoDocumento.SelectedValue = "007" Then
					.numeroDoc = txtNumeroOper.Text
					.numeroOperacion = Nothing
					.entregado = "NO"
				Else
					.numeroDoc = txtNumeroOper.Text
					.numeroOperacion = txtNumeroOper.Text
					.ctaCorrienteDeposito = txtCtaCorriente.Text
					.bancoEntidad = cboEntidad.SelectedValue
					.entregado = "SI"
				End If
				.entidadFinanciera = usuario.IDUsuario
				.tipoCambio = txtTipoCambio.Value
				.montoSoles = txtImporteCompramn.Value
				.montoUsd = txtImporteComprame.Value
				.glosa = "DEVOLUCIÓN A PROVEEDORES -" & txtNumeroOper.Text
				.usuarioModificacion = usuario.IDUsuario
				.fechaModificacion = DateTime.Now
				.DeudaEvalMN = CDec(lblDeudaPendiente.Text)
				.DeudaEvalME = CDec(lblDeudaPendienteme.Text)
			End With

			ndocumento.documentoCaja = ndocumentoCaja


			For Each i As DataGridViewRow In dgvDetalleItems.Rows
				If CDec(dgvDetalleItems.Rows(i.Index).Cells(6).Value()) > 0 Then
					ndocumentoCajaDetalle = New documentoCajaDetalle
					ndocumentoCajaDetalle.fecha = txtFechaComprobante.Text
					ndocumentoCajaDetalle.idItem = dgvDetalleItems.Rows(i.Index).Cells(0).Value()
					ndocumentoCajaDetalle.DetalleItem = dgvDetalleItems.Rows(i.Index).Cells(1).Value()
					ndocumentoCajaDetalle.montoSoles = CDec(dgvDetalleItems.Rows(i.Index).Cells(6).Value())
					ndocumentoCajaDetalle.montoUsd = CDec(dgvDetalleItems.Rows(i.Index).Cells(7).Value())
					ndocumentoCajaDetalle.entregado = "SI"
					'  ndocumentoCajaDetalle.DiferenciaTipoCambio = 0
					ndocumentoCajaDetalle.documentoAfectado = lblIdDocumento
					ndocumentoCajaDetalle.documentoAfectadodetalle = dgvDetalleItems.Rows(i.Index).Cells(11).Value()
					ndocumentoCajaDetalle.usuarioModificacion = usuario.IDUsuario
					ndocumentoCajaDetalle.fechaModificacion = Date.Now
					ListadocumentoCajaDetalle.Add(ndocumentoCajaDetalle)
				End If
			Next
			ndocumento.documentoCaja.documentoCajaDetalle = ListadocumentoCajaDetalle
			Select Case cboTipoDocumento.SelectedValue
				Case "109", "003"
					asiento = asientoCaja()
					ListaAsiento.Add(asiento)
					ndocumento.asiento = ListaAsiento
				Case "007"
					'   cajaUsarioBE = Nothing
			End Select

			n.IdAlmacen = documentoCajaSA.GrabarExcedenteCompra(ndocumento, Nothing)
			datos.Add(n)
			lblEstado.Text = "Transacción realizada con éxito!"
			lblEstado.Image = My.Resources.ok4
			Dispose()
		Catch ex As Exception
			lblEstado.Text = ex.Message
			lblEstado.Image = My.Resources.warning2
		End Try
	End Sub

	Public Sub ListaDocPago(listaCuenta As List(Of String))
		Dim tablaSA As New tablaDetalleSA
		Dim tabla As New List(Of tabladetalle)
		'Dim lista As New List(Of String)
		'lista.Add("109")
		'lista.Add("007")
		'lista.Add("003")
		tabla = tablaSA.GetListaTablaDetalle(1, "1")
		tabla = (From n In tabla
				 Where listaCuenta.Contains(n.codigoDetalle)
				 Select n).ToList
		cboTipoDocumento.DataSource = tabla
		cboTipoDocumento.ValueMember = "codigoDetalle"
		cboTipoDocumento.DisplayMember = "descripcion"
		cboTipoDocumento.Enabled = True
		cboTipoDocumento.SelectedValue = "109"
	End Sub

	Public Sub UbicarDocumento(intIdDocumento As Integer)
		Dim documentoSA As New DocumentoSA
		Dim tablaSA As New tablaDetalleSA
		Dim entidadSA As New entidadSA
		Dim itemSA As New detalleitemsSA

		Dim documentoCajaDetalleSA As New DocumentoCajaDetalleSA
		Dim documentoCajaSA As New DocumentoCajaSA
		Dim objDocCaja As New DocumentoSA
		Dim establecSA As New establecimientoSA
		Dim estadoF As New EstadosFinancierosSA
		Try
			With documentoSA.UbicarDocumento(intIdDocumento)

				txtFechaComprobante.Tag = .idDocumento
				txtFechaComprobante.Text = .fechaProceso
				txtNumeroOper.Text = .nroDoc
				cboTipoDocumento.SelectedValue = .tipoDoc
				'  txtComprobante.Text = tablaSA.GetUbicarTablaID(1, .tipoDoc).descripcion
			End With

			With documentoCajaSA.GetUbicar_documentoCajaPorID(intIdDocumento)
				cboMoneda.SelectedValue = .moneda
				txtTipoCambio.Value = .tipoCambio
				txtImporteCompramn.Value = .montoSoles
				txtImporteComprame.Value = .montoUsd

				With entidadSA.UbicarEntidadPorID(.codigoProveedor).First
					lblNomProveedor = .nombreCompleto
					lblIdProveedor = .idEntidad
					lblCuentaProveedor = .cuentaAsiento
				End With
			End With
			dgvDetalleItems.Rows.Clear()
			For Each i In documentoCajaDetalleSA.GetUbicar_DetallePorIdDocumento(intIdDocumento)
				dgvDetalleItems.Rows.Add(i.secuencia, i.DetalleItem, itemSA.InvocarProductoID(i.idItem).unidad1, "0.00", i.montoSoles, i.montoUsd, "0.00", "0.00", "0.00", "0.00",
										 Helios.Cont.Business.Entity.BaseBE.EntityAction.UPDATE)
			Next

		Catch ex As Exception
			lblEstado.Text = ex.Message
			PanelError.Visible = True
			Timer1.Enabled = True
			TiempoEjecutar(10)
		End Try
	End Sub

	Public Sub ObtenerTablaGenerales()
		Dim tablaSA As New tablaDetalleSA
		'cboMonedaCuenta.ValueMember = "codigoDetalle"
		'cboMonedaCuenta.DisplayMember = "descripcion"
		'cboMonedaCuenta.DataSource = tablaSA.GetListaTablaDetalle(4, "1")

		cboEntidad.ValueMember = "codigoDetalle"
		cboEntidad.DisplayMember = "descripcion"
		cboEntidad.DataSource = tablaSA.GetListaTablaDetalle(3, "1")
	End Sub


	Sub CalculoGRID()
		Dim valDolares As Decimal = 0
		Dim nudvalueImporte As Decimal = txtImporteCompramn.Value
		Dim nudSaldo As Decimal = nudvalueImporte
		Dim cSaldo As Decimal = 0
		Dim cSaldoex As Decimal = 0
		Dim montoMN As Decimal = 0
		If (cboMoneda.SelectedValue = 1 And tb19.ToggleState = ToggleButton2.ToggleButtonState.ON) Then
			If (CDec(txtImporteCompramn.Value <= lblDeudaPendiente.Text)) Then
				If (txtImporteCompramn.Value > 0) Then

					montoMN = Math.Round(CDec(txtImporteCompramn.Value), 2)

					valDolares = montoMN / txtTipoCambio.Value
					txtImporteComprame.Value = CDec(valDolares)

					For Each i As DataGridViewRow In dgvDetalleItems.Rows
						cSaldo = CDec(i.Cells(4).Value) - nudSaldo
						cSaldoex = CDec(i.Cells(5).Value) - valDolares
						'If CDec(i.Cells(4).Value) = "" Then
						If cSaldo >= 0 Then
							i.Cells(6).Value = CDec(nudSaldo)
							i.Cells(8).Value = CDec(cSaldo)
							'   i.Cells(7).Value = Math.Round(CDec(i.Cells(6).Value) / nudTipoCambio.Value, 2)
							'    i.Cells(9).Value = Math.Round(CDec(i.Cells(5).Value) - CDec(i.Cells(7).Value), 2)
							nudSaldo = 0
						Else
							i.Cells(6).Value = CDec(i.Cells(4).Value)
							i.Cells(8).Value = "0.00"
							'   i.Cells(7).Value = Math.Round(CDec(i.Cells(6).Value) / nudTipoCambio.Value, 2)
							'   i.Cells(9).Value = Math.Round(CDec(i.Cells(5).Value) - CDec(i.Cells(7).Value), 2)
							nudSaldo = cSaldo * -1
						End If

						If cSaldoex >= 0 Then
							i.Cells(7).Value = CDec(valDolares)
							i.Cells(9).Value = CDec(cSaldoex)
							'   i.Cells(7).Value = Math.Round(CDec(i.Cells(6).Value) / nudTipoCambio.Value, 2)
							'    i.Cells(9).Value = Math.Round(CDec(i.Cells(5).Value) - CDec(i.Cells(7).Value), 2)
							valDolares = 0
						Else
							i.Cells(7).Value = CDec(i.Cells(5).Value)
							i.Cells(9).Value = "0.00"
							'   i.Cells(7).Value = Math.Round(CDec(i.Cells(6).Value) / nudTipoCambio.Value, 2)
							'   i.Cells(9).Value = Math.Round(CDec(i.Cells(5).Value) - CDec(i.Cells(7).Value), 2)
							valDolares = cSaldoex * -1
						End If

					Next
				End If

			Else
				txtImporteComprame.Value = 0
				txtImporteCompramn.Value = 0
				txtDiferenciaMontos.Value = 0
				lblEstado.Text = "Ingreso del importe no debe exceder S/." & lblDeudaPendiente.Text
				Timer1.Enabled = True
				PanelError.Visible = True
				TiempoEjecutar(10)
				txtImporteCompramn.Select()
				txtImporteCompramn.Select(0, txtImporteCompramn.Text.Length)

			End If

			' COMPRA MONEDA EXTRAJERA  Y PAGO MONEDA EXTRANJERA
		ElseIf (cboMoneda.SelectedValue = 2 And tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF) Then
			valDolares = txtImporteComprame.Value
			'txtImporteComprame.Value = valDolares

			For Each i As DataGridViewRow In dgvDetalleItems.Rows
				cSaldo = CDec(i.Cells(4).Value) - nudSaldo
				cSaldoex = CDec(i.Cells(5).Value) - valDolares
				'If CDec(i.Cells(4).Value) = "" Then
				If cSaldo >= 0 Then
					i.Cells(6).Value = nudSaldo
					i.Cells(8).Value = cSaldo
					'   i.Cells(7).Value = Math.Round(CDec(i.Cells(6).Value) / nudTipoCambio.Value, 2)
					'    i.Cells(9).Value = Math.Round(CDec(i.Cells(5).Value) - CDec(i.Cells(7).Value), 2)
					nudSaldo = 0
				Else
					i.Cells(6).Value = i.Cells(4).Value
					i.Cells(8).Value = "0.00"
					'   i.Cells(7).Value = Math.Round(CDec(i.Cells(6).Value) / nudTipoCambio.Value, 2)
					'   i.Cells(9).Value = Math.Round(CDec(i.Cells(5).Value) - CDec(i.Cells(7).Value), 2)
					nudSaldo = cSaldo * -1
				End If

				If cSaldoex >= 0 Then
					i.Cells(7).Value = valDolares
					i.Cells(9).Value = cSaldoex
					'   i.Cells(7).Value = Math.Round(CDec(i.Cells(6).Value) / nudTipoCambio.Value, 2)
					'    i.Cells(9).Value = Math.Round(CDec(i.Cells(5).Value) - CDec(i.Cells(7).Value), 2)
					valDolares = 0
				Else
					i.Cells(7).Value = i.Cells(5).Value
					i.Cells(9).Value = "0.00"
					'   i.Cells(7).Value = Math.Round(CDec(i.Cells(6).Value) / nudTipoCambio.Value, 2)
					'   i.Cells(9).Value = Math.Round(CDec(i.Cells(5).Value) - CDec(i.Cells(7).Value), 2)
					valDolares = cSaldoex * -1
				End If

			Next
			CargarDiferenciasdeImporte()
			'CargarMovimientosDetallado(lblIdDocumento.Text)

			' compra moneda nacional pago en moneda extrajera

		ElseIf (cboMoneda.SelectedValue = 2 And tb19.ToggleState = ToggleButton2.ToggleButtonState.ON) Then
			If (txtTipoCambio.Value > 0) Then
				Dim precioME As Decimal = 0
				Dim precio As Decimal = 0
				Dim parteDecimal As Decimal = 0
				Dim sumatoriaPagoME As Decimal = 0
				If ((txtImporteCompramn.Value) <= lblDeudaPendiente.Text) Then

					montoMN = Math.Round(CDec(txtImporteCompramn.Value), 2)

					valDolares = montoMN / txtTipoCambio.Value
					txtImporteComprame.Value = valDolares
					txtImporteCompramn.Value = montoMN
					If (valDolares <= nudDeudaPendienteme.Value) Then



						If (txtImporteCompramn.Value > 0) Then


							For Each i As DataGridViewRow In dgvDetalleItems.Rows
								cSaldo = CDec(i.Cells(4).Value) - nudSaldo
								cSaldoex = CDec(i.Cells(5).Value) - valDolares
								'If CDec(i.Cells(4).Value) = "" Then
								If cSaldo >= 0 Then
									i.Cells(6).Value = CDec(nudSaldo)
									i.Cells(8).Value = CDec(cSaldo)
									'   i.Cells(7).Value = Math.Round(CDec(i.Cells(6).Value) / nudTipoCambio.Value, 2)
									'    i.Cells(9).Value = Math.Round(CDec(i.Cells(5).Value) - CDec(i.Cells(7).Value), 2)
									nudSaldo = 0
								Else
									i.Cells(6).Value = CDec(i.Cells(4).Value)
									i.Cells(8).Value = "0.00"
									'   i.Cells(7).Value = Math.Round(CDec(i.Cells(6).Value) / nudTipoCambio.Value, 2)
									'   i.Cells(9).Value = Math.Round(CDec(i.Cells(5).Value) - CDec(i.Cells(7).Value), 2)
									nudSaldo = cSaldo * -1
								End If

								If cSaldoex >= 0 Then
									i.Cells(7).Value = CDec(i.Cells(6).Value / txtTipoCambio.Value).ToString("N2")
									i.Cells(9).Value = CDec(i.Cells(5).Value - i.Cells(7).Value)
									'   i.Cells(7).Value = Math.Round(CDec(i.Cells(6).Value) / nudTipoCambio.Value, 2)
									'    i.Cells(9).Value = Math.Round(CDec(i.Cells(5).Value) - CDec(i.Cells(7).Value), 2)
									valDolares = 0
								Else
									i.Cells(7).Value = CDec(i.Cells(6).Value / txtTipoCambio.Value).ToString("N2")
									i.Cells(9).Value = "0.00"
									'   i.Cells(7).Value = Math.Round(CDec(i.Cells(6).Value) / nudTipoCambio.Value, 2)
									'   i.Cells(9).Value = Math.Round(CDec(i.Cells(5).Value) - CDec(i.Cells(7).Value), 2)
									valDolares = cSaldoex * -1
								End If

							Next

							CargarDiferenciasdeImporte()
							'CargarMovimientosDetallado(lblIdDocumento.Text)
						End If
					Else
						txtImporteComprame.Value = 0
						txtImporteCompramn.Value = 0
						txtDiferenciaMontos.Value = 0
						lblEstado.Text = "Ingreso del importe ME no debe exceder S/." & nudDeudaPendienteme.Value
						Timer1.Enabled = True
						PanelError.Visible = True
						TiempoEjecutar(10)
						txtImporteCompramn.Select()
						txtImporteCompramn.Select(0, txtImporteCompramn.Text.Length)
					End If
				Else
					txtImporteComprame.Value = 0
					txtTipoCambio.Value = 0
					txtImporteCompramn.Value = 0
					txtDiferenciaMontos.Value = 0
					lblEstado.Text = "Ingreso del importe no debe exceder S/." & lblDeudaPendiente.Text
					Timer1.Enabled = True
					PanelError.Visible = True
					TiempoEjecutar(10)
					txtImporteComprame.Select()
					txtImporteComprame.Select(0, txtImporteComprame.Text.Length)
				End If
			Else
				txtTipoCambio.Select()
				txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
			End If

		Else
			' compra moneda extranjera  pago en moneda nacional
			If (txtTipoCambio.Value > 0) Then


				If (manipulacionEstado = ENTITY_ACTIONS.UPDATE) Then
					valDolares = txtImporteCompramn.Value / txtTipoCambio.Value
				Else
					valDolares = txtImporteCompramn.Value / txtTipoCambio.Value
					txtImporteComprame.Value = valDolares
				End If



				If CDec(txtImporteComprame.Value <= lblDeudaPendienteme.Text) Then
					For Each i As DataGridViewRow In dgvDetalleItems.Rows
						cSaldo = CDec(i.Cells(4).Value) - nudSaldo
						cSaldoex = CDec(i.Cells(5).Value) - valDolares
						'If CDec(i.Cells(4).Value) = "" Then


						If cSaldoex >= 0 Then
							i.Cells(7).Value = valDolares 'valDolares
							i.Cells(9).Value = cSaldoex
							'   i.Cells(7).Value = Math.Round(CDec(i.Cells(6).Value) / nudTipoCambio.Value, 2)
							'    i.Cells(9).Value = Math.Round(CDec(i.Cells(5).Value) - CDec(i.Cells(7).Value), 2)
							valDolares = 0
						Else
							i.Cells(7).Value = CDec(i.Cells(5).Value) ' i.Cells(5).Value
							i.Cells(9).Value = "0.00"
							'   i.Cells(7).Value = Math.Round(CDec(i.Cells(6).Value) / nudTipoCambio.Value, 2)
							'   i.Cells(9).Value = Math.Round(CDec(i.Cells(5).Value) - CDec(i.Cells(7).Value), 2)
							valDolares = cSaldoex * -1
						End If


						If cSaldo >= 0 Then
							i.Cells(6).Value = CDec(i.Cells(7).Value * txtTipoCambio.Value)  'nudSaldo
							i.Cells(8).Value = CDec(i.Cells(4).Value - i.Cells(6).Value)
							'   i.Cells(7).Value = Math.Round(CDec(i.Cells(6).Value) / nudTipoCambio.Value, 2)
							'    i.Cells(9).Value = Math.Round(CDec(i.Cells(5).Value) - CDec(i.Cells(7).Value), 2)
							nudSaldo = 0
						Else
							i.Cells(6).Value = CDec(i.Cells(5).Value * txtTipoCambio.Value)
							i.Cells(8).Value = CDec(i.Cells(4).Value - i.Cells(6).Value)
							'   i.Cells(7).Value = Math.Round(CDec(i.Cells(6).Value) / nudTipoCambio.Value, 2)
							'   i.Cells(9).Value = Math.Round(CDec(i.Cells(5).Value) - CDec(i.Cells(7).Value), 2)
							nudSaldo = cSaldo * -1
						End If


					Next

					CargarDiferenciasdeImporte()
					'CargarMovimientosDetallado(lblIdDocumento.Text)
				Else
					txtImporteComprame.Value = 0
					txtTipoCambio.Value = 0
					txtImporteCompramn.Value = 0
					txtDiferenciaMontos.Value = 0
					lblEstado.Text = "Ingreso del importe no debe exceder $." & lblDeudaPendienteme.Text
					Timer1.Enabled = True
					PanelError.Visible = True
					TiempoEjecutar(10)
					txtImporteCompramn.Select()
					txtImporteCompramn.Select(0, txtImporteCompramn.Text.Length)

					Exit Sub
				End If
			Else
				lblEstado.Text = "Ingrese un tipo cambio"
				Timer1.Enabled = True
				PanelError.Visible = True
				TiempoEjecutar(10)
				txtTipoCambio.Focus()
				txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
				Exit Sub
			End If

		End If

	End Sub
	'Sub CalculoGRID()
	'	Dim valDolares As Decimal = 0
	'	Dim nudvalueImporte As Decimal = txtImporteCompramn.Value
	'	Dim nudSaldo As Decimal = nudvalueImporte
	'	Dim cSaldo As Decimal = 0
	'	Dim cSaldoex As Decimal = 0

	'	valDolares = Math.Round(txtImporteCompramn.Value / txtTipoCambio.Value, 2)
	'	txtImporteComprame.Value = valDolares

	'	For Each i As DataGridViewRow In dgvDetalleItems.Rows
	'		cSaldo = CDec(i.Cells(4).Value) - nudSaldo
	'		cSaldoex = CDec(i.Cells(5).Value) - valDolares
	'		'If CDec(i.Cells(4).Value) = "" Then
	'		If cSaldo >= 0 Then
	'			i.Cells(6).Value = nudSaldo
	'			i.Cells(8).Value = cSaldo
	'			'   i.Cells(7).Value = Math.Round(CDec(i.Cells(6).Value) / nudTipoCambio.Value, 2)
	'			'    i.Cells(9).Value = Math.Round(CDec(i.Cells(5).Value) - CDec(i.Cells(7).Value), 2)
	'			nudSaldo = 0
	'		Else
	'			i.Cells(6).Value = i.Cells(4).Value
	'			i.Cells(8).Value = "0.00"
	'			'   i.Cells(7).Value = Math.Round(CDec(i.Cells(6).Value) / nudTipoCambio.Value, 2)
	'			'   i.Cells(9).Value = Math.Round(CDec(i.Cells(5).Value) - CDec(i.Cells(7).Value), 2)
	'			nudSaldo = cSaldo * -1
	'		End If


	'		If cSaldoex >= 0 Then
	'			i.Cells(7).Value = valDolares
	'			i.Cells(9).Value = cSaldoex
	'			'   i.Cells(7).Value = Math.Round(CDec(i.Cells(6).Value) / nudTipoCambio.Value, 2)
	'			'    i.Cells(9).Value = Math.Round(CDec(i.Cells(5).Value) - CDec(i.Cells(7).Value), 2)
	'			valDolares = 0
	'		Else
	'			i.Cells(7).Value = i.Cells(5).Value
	'			i.Cells(9).Value = "0.00"
	'			'   i.Cells(7).Value = Math.Round(CDec(i.Cells(6).Value) / nudTipoCambio.Value, 2)
	'			'   i.Cells(9).Value = Math.Round(CDec(i.Cells(5).Value) - CDec(i.Cells(7).Value), 2)
	'			valDolares = cSaldoex * -1
	'		End If
	'	Next
	'End Sub

	Sub CalculoSoles()
		If cboMoneda.SelectedValue = 1 Then
			If txtTipoCambio.Value > 0 Then
				If CDec(txtImporteCompramn.Value) > CDec(lblDeudaPendiente.Text) Then
					MsgBox("El valor ingreso excede el valor permitido.", MsgBoxStyle.Information, String.Concat("Monto permitido (S/.):", Space(2), lblDeudaPendiente.Text))
					txtImporteCompramn.Value = 0
					txtImporteComprame.Value = 0
					Exit Sub
				End If
			End If
		End If
	End Sub
#End Region

	Private Sub frmDevolucionAproveedor_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
		Dispose()
	End Sub

	Private Sub frmDevolucionAproveedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

	End Sub

	Private Sub cboTipoDocumento_SelectedIndexChanged(sender As Object, e As System.EventArgs)
		If cboTipoDocumento.ValueMember.Trim.Length > 0 Then
			txtNumeroOper.Clear()
			txtCtaCorriente.Clear()
			If cboTipoDocumento.SelectedValue = "109" Then
				txtNumeroOper.Clear()
				txtNumeroOper.Visible = False

			ElseIf cboTipoDocumento.SelectedValue = "007" Then
				txtNumeroOper.Clear()
				txtNumeroOper.Visible = True
			Else
				txtNumeroOper.Clear()
				txtNumeroOper.Visible = True
			End If
		End If
	End Sub

	Private Sub txtMontoMN_TextChanged(sender As Object, e As EventArgs)
		If txtTipoCambio.Value > 0 Then
			If txtImporteCompramn.Value > 0 Then
				CalculoSoles()
				CalculoGRID()
			End If
		End If

	End Sub

	Private Sub txtTipoCambio_TextChanged(sender As Object, e As EventArgs)
		txtMontoMN_TextChanged(sender, e)
	End Sub

	Private Sub cboTipoCuenta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipo.SelectedIndexChanged
		Me.Cursor = Cursors.WaitCursor

		txtImporteCompramn.Value = 0
		txtImporteComprame.Value = 0
		txtTipoCambio.Value = 0
		txtDiferenciaMontos.Value = 0
		txtNumeroOper.Clear()
		cboDepositoHijo.SelectedValue = -1
		cboMoneda.SelectedValue = -1
		txtCtaCorriente.Clear()
		nudDeudaPendienteme.Value = 0
		nudDeudaPendientemn.Value = 0
		cargarCtasFinan()
		Me.Cursor = Cursors.Arrow
	End Sub

	Private Sub cboDepositoHijo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDepositoHijo.SelectedIndexChanged
		Me.Cursor = Cursors.WaitCursor
		'Dim value As Object = Me.cboDepositoHijo.SelectedValue

		'nudMonedaNacional.Value = 0
		'nudMonedaExtranjero.Value = 0
		'txtTipoCambio.Value = 0
		'txtDiferenciaMontos.Value = 0
		'txtNumeroOper.Clear()
		'cboMonedaCuenta.SelectedValue = -1
		'txtCtaCorriente.Clear()
		'nudDeudaPendienteme.Value = 0
		'nudDeudaPendientemn.Value = 0

		'If IsNumeric(value) Then
		'          cargarDatosCuenta(CInt(value))
		'      Else
		'          'txtFondoEF.DecimalValue = 0
		'      End If
		'Me.Cursor = Cursors.Arrow
		Me.Cursor = Cursors.WaitCursor
		Dim value As Object = Me.cboDepositoHijo.SelectedValue
		If (Me.cboDepositoHijo.Items.Count > 0) Then
			If IsNumeric(value) Then
				cargarDatosCuenta(CInt(value))
			End If
		End If
		Me.Cursor = Cursors.Arrow
	End Sub

	Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click
		Dispose()
	End Sub

	Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
		If txtImporteCompramn.Value > 0 Then

			If cboTipoDocumento.SelectedValue = "109" Then

			ElseIf cboTipoDocumento.SelectedValue = "007" Then
				If Not txtNumeroOper.Text.Trim.Length > 0 Then
					lblEstado.Text = "Ingrese el número del tipo de documento."
					Timer1.Enabled = True
					PanelError.Visible = True
					TiempoEjecutar(10)
					Exit Sub
				End If
			Else
				If Not txtNumeroOper.Text.Trim.Length > 0 Then
					lblEstado.Text = "Ingrese el número del tipo de documento."
					'lblEstado.Image = My.Resources.warning2
					Timer1.Enabled = True
					PanelError.Visible = True
					TiempoEjecutar(10)
					txtNumeroOper.Focus()
					Exit Sub
				End If
				If Not txtNumeroOper.Text.Trim.Length > 0 Then
					lblEstado.Text = "Ingrese el número de operación de la transacción."
					'lblEstado.Image = My.Resources.warning2
					Timer1.Enabled = True
					PanelError.Visible = True
					TiempoEjecutar(10)
					txtNumeroOper.Focus()
					Exit Sub
				End If
				If Not txtCtaCorriente.Text.Trim.Length > 0 Then
					lblEstado.Text = "Ingrese el número de cta. corriente del banco."
					'lblEstado.Image = My.Resources.warning2
					Timer1.Enabled = True
					PanelError.Visible = True
					TiempoEjecutar(10)
					txtCtaCorriente.Focus()
					Exit Sub
				End If
			End If

			'    If manipulacionEstado = ENTITY_ACTIONS.INSERT Then
			Grabar()
			'ElseIf manipulacionEstado = ENTITY_ACTIONS.UPDATE Then
			'    '   Editar()
			'End If
		Else
			lblEstado.Text = "Ingresar el importe a pagar!"
			'lblEstado.Image = My.Resources.warning2
			Timer1.Enabled = True
			PanelError.Visible = True
			TiempoEjecutar(10)
		End If
	End Sub

	Private Sub cboDepositoHijo_Click(sender As Object, e As EventArgs) Handles cboDepositoHijo.Click

	End Sub





	Private Sub txtTipoCambio_ValueChanged(sender As Object, e As EventArgs) Handles txtTipoCambio.ValueChanged
		If (cboDepositoHijo.SelectedValue > -1) Then
			Select Case cboMoneda.SelectedValue
				Case 1
					txtImporteCompramn_ValueChanged(sender, e)
				Case 2
					txtImporteComprame_ValueChanged(sender, e)
			End Select
		End If
	End Sub

	Private Sub txtImporteCompramn_ValueChanged(sender As Object, e As EventArgs) Handles txtImporteCompramn.ValueChanged
		If (tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF) Then
		ElseIf (tb19.ToggleState = ToggleButton2.ToggleButtonState.ON) Then
            'If (CDec(txtImporteCompramn.Value <= nudDeudaPendientemn.Value) And txtImporteCompramn.Value <> 0) Then
            If manipulacionEstado = ENTITY_ACTIONS.INSERT Then
					'ME - ME
					If (cboMoneda.SelectedValue = 2 And tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF) Then
						If txtTipoCambio.Value > 0 Then
							txtImporteComprame.Value = txtImporteCompramn.Value / txtTipoCambio.Value
							pnDiferencia.Visible = True
							CalculoSoles()
							CalculoGRID()
						End If
						'MN - ME
					ElseIf (cboMoneda.SelectedValue = 1 And tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF) Then
						pnDiferencia.Visible = True
						CalculoGRID()
					ElseIf (cboMoneda.SelectedValue = 1 And tb19.ToggleState = ToggleButton2.ToggleButtonState.ON) Then
						CalculoGRID()
						'ME - MN
					ElseIf (cboMoneda.SelectedValue = 2 And tb19.ToggleState = ToggleButton2.ToggleButtonState.ON) Then
						CalculoGRID()
					End If
				ElseIf manipulacionEstado = ENTITY_ACTIONS.UPDATE Then
					CalculoGRID()
				End If
                'ElseIf (txtImporteCompramn.Value <> 0) Then
                '	lblEstado.Text = "no debe exceder el monto permitido"
                '	Timer1.Enabled = True
                '	PanelError.Visible = True
                '	TiempoEjecutar(10)
                '	txtImporteCompramn.Value = 0.0
                'End If
            End If
	End Sub

	Private Sub txtImporteComprame_ValueChanged(sender As Object, e As EventArgs) Handles txtImporteComprame.ValueChanged
		If (cboMoneda.SelectedValue = 2 And tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF) Then
			If (CDec(txtImporteComprame.Value <= nudDeudaPendienteme.Value)) Then
				If manipulacionEstado = ENTITY_ACTIONS.INSERT Then
					'ME - ME
					If (cboMoneda.SelectedValue = 2 And tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF) Then
						If (txtImporteComprame.Value <= lblDeudaPendienteme.Text And txtImporteComprame.Value > 0) Then
							If txtTipoCambio.Value > 0 Then
								txtImporteCompramn.Value = txtImporteComprame.Value * txtTipoCambio.Value
								pnDiferencia.Visible = True
								'CargarDiferenciasdeImporte()
								'CalculoDolares()
								CalculoGRID()
							Else
								txtTipoCambio.Value = 0
								lblEstado.Text = "Ingrese el tipo de cambio."
								Timer1.Enabled = True
								PanelError.Visible = True
								TiempoEjecutar(10)
								txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
							End If
						ElseIf (txtImporteComprame.Value <> 0) Then
							txtImporteCompramn.Value = 0
							txtDiferenciaMontos.Value = 0
							txtImporteComprame.Value = 0
							lblEstado.Text = "La moneda no debe exceder al monto de la factura."
							Timer1.Enabled = True
							PanelError.Visible = True
							TiempoEjecutar(10)
							txtImporteComprame.Select(0, txtImporteComprame.Text.Length)
						End If
						'MN - ME
					ElseIf (cboMoneda.SelectedValue = 1 And tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF) Then
						If txtTipoCambio.Value > 0 Then
							txtImporteComprame.Value = txtImporteCompramn.Value / txtTipoCambio.Value
							pnDiferencia.Visible = True
							CalculoSoles()
							CalculoGRID()
						End If
						'MN - MN
					ElseIf (cboMoneda.SelectedValue = 1 And tb19.ToggleState = ToggleButton2.ToggleButtonState.ON) Then
						If txtTipoCambio.Value > 0 Then
							If (txtImporteComprame.Value <= lblDeudaPendienteme.Text) Then
								txtImporteCompramn.Value = txtImporteComprame.Value * txtTipoCambio.Value
								pnDiferencia.Visible = True
								'CalculoDolares()
								CalculoGRID()
							Else
								txtImporteComprame.Value = 0
								txtTipoCambio.Value = 0
								txtImporteCompramn.Value = 0
								txtDiferenciaMontos.Value = 0
								lblEstado.Text = "La moneda no debe exceder al monto de la factura."
								Timer1.Enabled = True
								PanelError.Visible = True
								TiempoEjecutar(10)
								txtImporteComprame.Select(0, txtImporteComprame.Text.Length)
							End If
						Else
							lblEstado.Text = "Ingrese el tipo de cambio."
							Timer1.Enabled = True
							PanelError.Visible = True
							TiempoEjecutar(10)
							txtTipoCambio.Value = 0
							txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
						End If

						'ME - MN
					ElseIf (cboMoneda.SelectedValue = 2 And tb19.ToggleState = ToggleButton2.ToggleButtonState.ON) Then

						If txtTipoCambio.Value > 0 Then
							txtImporteCompramn.Value = txtImporteComprame.Value * txtTipoCambio.Value
							If (txtImporteCompramn.Value <= lblDeudaPendiente.Text) Then
								pnDiferencia.Visible = True
								'CalculoDolares()
								CalculoGRID()
							Else
								txtTipoCambio.Value = 0
								txtImporteCompramn.Value = 0
								txtImporteComprame.Value = 0
								txtDiferenciaMontos.Value = 0
								lblEstado.Text = "La moneda no debe exceder al monto de la factura."
								Timer1.Enabled = True
								PanelError.Visible = True
								TiempoEjecutar(10)
								txtImporteCompramn.Select(0, txtImporteCompramn.Text.Length)

							End If
						Else
							txtTipoCambio.Value = 0
							lblEstado.Text = "Ingrese el tipo de cambio."
							Timer1.Enabled = True
							PanelError.Visible = True
							TiempoEjecutar(10)
							txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
						End If

					End If
				ElseIf manipulacionEstado = ENTITY_ACTIONS.UPDATE Then
					CalculoGRID()
				End If
			Else
				txtImporteComprame.Value = 0
				lblEstado.Text = "La moneda no debe exceder al monto disponible de la cuenta."
				Timer1.Enabled = True
				PanelError.Visible = True
				TiempoEjecutar(10)
			End If

		ElseIf (cboMoneda.SelectedValue = 1 And tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF) Then

			If txtTipoCambio.Value > 0 Then
				txtImporteCompramn.Value = txtImporteComprame.Value * txtTipoCambio.Value


				If (txtImporteCompramn.Value <= nudDeudaPendientemn.Value) Then
					If (txtImporteCompramn.Value <= nudDeudaPendientemn.Value) Then
						pnDiferencia.Visible = True
						'CalculoDolares()
						CalculoGRID()
					Else
						lblEstado.Text = "La moneda no debe exceder al monto de la factura."
						txtImporteCompramn.Value = 0
						txtImporteComprame.Value = 0
						txtDiferenciaMontos.Value = 0
						Timer1.Enabled = True
						PanelError.Visible = True
						TiempoEjecutar(10)
					End If

				Else
					'txtTipoCambio.Value = 0
					txtImporteCompramn.Value = 0
					txtImporteComprame.Value = 0
					txtDiferenciaMontos.Value = 0
					lblEstado.Text = "La moneda no debe exceder al monto de la factura."
					Timer1.Enabled = True
					PanelError.Visible = True
					TiempoEjecutar(10)
					txtImporteCompramn.Select(0, txtImporteCompramn.Text.Length)

				End If
			Else
				txtTipoCambio.Value = 0
				lblEstado.Text = "Ingrese el tipo de cambio."
				Timer1.Enabled = True
				PanelError.Visible = True
				TiempoEjecutar(10)
				txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
			End If
		End If
	End Sub
End Class