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


Public Class FrmHojaTrabajo

    Inherits frmMaster



    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        '     Me.WindowState = FormWindowState.Maximized
        ' Add any initialization after the InitializeComponent() call.
        GridCFG(dgvHojaTrabajo)
        años()
        SumarioColumnas()
    End Sub

#Region "metodos"


    Public Sub años()
        Dim AniosSA As New empresaPeriodoSA
        cboAnios.DisplayMember = "periodo"
        cboAnios.ValueMember = "periodo"
        cboAnios.DataSource = AniosSA.GetListar_empresaPeriodo(New empresaPeriodo With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento})
        cboAnios.Text = AnioGeneral

        cboMes.SelectedIndex = DateTime.Now.Month - 1
    End Sub


    'Private Sub ListarDetalleCuenta(dtpPeriodoAnio As String, dtpPEriodoMes As String, cuenta As String)
    '    Dim compraSA As New HojaTrabajoFinalRPTSA

    '    Dim dt As New DataTable("Detalle")
    '    dt.Columns.Add(New DataColumn("cuenta", GetType(String)))
    '    dt.Columns.Add(New DataColumn("descripcion", GetType(String)))
    '    dt.Columns.Add(New DataColumn("debe", GetType(Decimal)))
    '    dt.Columns.Add(New DataColumn("haber", GetType(Decimal)))
    '    dt.Columns.Add(New DataColumn("debeme", GetType(Decimal)))
    '    dt.Columns.Add(New DataColumn("hamerme", GetType(Decimal)))

    '    For Each i As movimiento In compraSA.ListarDetallexCuenta(dtpPeriodoAnio, dtpPEriodoMes, cuenta)
    '        Dim dr As DataRow = dt.NewRow()
    '        dr(0) = i.cuenta
    '        dr(1) = i.descripcion
    '        If i.tipo = "H" Then
    '            dr(2) = CDec(0.0)
    '            dr(3) = CDec(i.monto)
    '            dr(4) = CDec(0.0)
    '            dr(5) = CDec(i.montoUSD)

    '        ElseIf i.tipo = "D" Then
    '            dr(2) = CDec(i.monto)
    '            dr(3) = CDec(0.0)
    '            dr(4) = CDec(i.montoUSD)
    '            dr(5) = CDec(0.0)
    '        End If
    '        dt.Rows.Add(dr)
    '    Next
    '    dgvCuentaDetalle.DataSource = dt

    'End Sub



    Private Sub Cuentas(dtpPeriodoAnio As Integer, dtpPEriodoMes As Integer)
        'Dim compraSA As New HojaTrabajoFinalRPTSA
        Dim cierreSA As New CierreContableSA
        Dim SumaDebe As Decimal = 0
        Dim SumaHaber As Decimal = 0

        Dim dt As New DataTable("Hoja de Trabajo")
        dt.Columns.Add(New DataColumn("cuenta"))
        dt.Columns.Add(New DataColumn("nomCuenta"))
        dt.Columns.Add(New DataColumn("debe"))
        dt.Columns.Add(New DataColumn("haber"))
        dt.Columns.Add(New DataColumn("debeMov"))
        dt.Columns.Add(New DataColumn("habermov"))
        dt.Columns.Add(New DataColumn("debeSaldo"))
        dt.Columns.Add(New DataColumn("haberSaldo"))
        dt.Columns.Add(New DataColumn("invDebe"))
        dt.Columns.Add(New DataColumn("invHaber"))
        dt.Columns.Add(New DataColumn("rnDebe"))
        dt.Columns.Add(New DataColumn("rnHaber"))
        dt.Columns.Add(New DataColumn("ajDebe"))
        dt.Columns.Add(New DataColumn("ejHaber"))

        dt.Columns.Add(New DataColumn("rpfDebe"))
        dt.Columns.Add(New DataColumn("rpfHaber"))

        'dgvCuentaDetalle.DataSource

        For Each i As cierrecontable In cierreSA.ReporteSaldoInicioXperiodoHojaTrabajo(dtpPeriodoAnio, dtpPEriodoMes, Gempresas.IdEmpresaRuc)
            SumaDebe = 0
            SumaHaber = 0

            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.cuentaCierre
            dr(1) = i.nomCuenta
            dr(2) = CDec(i.DebeCierre)
            dr(3) = CDec(i.HaberCierre)
            dr(4) = CDec(i.DebeMovimiento)
            '  dr(5) = CDec(i.HaberMovimiento)

            Dim s = i.HaberMovimiento
            dr(5) = CDec(s)

            SumaDebe = CDec(i.DebeCierre) + CDec(i.DebeMovimiento)
            SumaHaber = CDec(i.HaberCierre) + CDec(i.HaberMovimiento)

            If SumaDebe > SumaHaber Then
                dr(6) = CDec(SumaDebe - SumaHaber)
                dr(7) = 0.0

                Dim cuentax = Mid(i.cuentaCierre, 1, 2)

                Select Case cuentax
                    Case 10 To 59 ' 50
                        dr(8) = CDec(SumaDebe - SumaHaber)
                        dr(9) = 0.0
                    Case Else
                        dr(8) = 0.0
                        dr(9) = 0.0
                End Select

                Dim cuentax2 = Mid(i.cuentaCierre, 1, 2)

                Select Case cuentax2
                    Case 60 To 68
                        dr(10) = CDec(SumaDebe - SumaHaber)
                        dr(11) = 0.0
                    Case 70 To 78
                        dr(10) = CDec(SumaDebe - SumaHaber)
                        dr(11) = 0.0
                    Case Else
                        dr(10) = 0.0
                        dr(11) = 0.0

                End Select

                Select Case cuentax2
                    Case 69 To 70 '78
                        dr(14) = CDec(SumaDebe - SumaHaber)
                        dr(15) = 0.0

                    Case 73 To 77
                        dr(14) = CDec(SumaDebe - SumaHaber)
                        dr(15) = 0.0

                        'Case 80 To 91
                        '    dr(14) = CDec(SumaDebe - SumaHaber)
                        '    dr(15) = 0.0

                    Case 94 To 97 ' 92 To 97
                        dr(14) = CDec(SumaDebe - SumaHaber)
                        dr(15) = 0
                    Case Else
                        dr(14) = 0.0
                        dr(15) = 0.0
                End Select

            ElseIf SumaHaber > SumaDebe Then
                dr(6) = 0.0
                dr(7) = CDec(SumaHaber - SumaDebe)

                Dim cuentax = Mid(i.cuentaCierre, 1, 2)

                Select Case cuentax
                    Case 10 To 59
                        dr(8) = 0.0
                        dr(9) = CDec(SumaHaber - SumaDebe)
                    Case Else
                        dr(8) = 0.0
                        dr(9) = 0.0
                End Select

                Dim cuentax2 = Mid(i.cuentaCierre, 1, 2)

                Select Case cuentax2
                    Case 60 To 68
                        dr(10) = 0
                        dr(11) = CDec(SumaHaber - SumaDebe)
                    Case 70 To 78
                        dr(10) = 0
                        dr(11) = CDec(SumaHaber - SumaDebe)
                    Case Else
                        dr(10) = 0.0
                        dr(11) = 0.0
                End Select

                'Select Case cuentax2
                '    Case 69 To 78
                '        dr(14) = 0
                '        dr(15) = CDec(SumaHaber - SumaDebe)

                '    Case Else
                '        dr(14) = 0.0
                '        dr(15) = 0.0
                'End Select

                Select Case cuentax2
                    Case 69 To 70 '78
                        dr(14) = 0.0
                        dr(15) = CDec(SumaHaber - SumaDebe)

                    Case 73 To 77
                        dr(14) = 0.0
                        dr(15) = CDec(SumaHaber - SumaDebe)

                        'Case 80 To 91
                        '    dr(14) = 0.0
                        '    dr(15) = CDec(SumaHaber - SumaDebe)

                    Case 94 To 97 ' 92 To 97
                        dr(14) = 0.0
                        dr(15) = CDec(SumaHaber - SumaDebe)
                    Case Else
                        dr(14) = 0.0
                        dr(15) = 0.0
                End Select

            ElseIf SumaHaber = SumaDebe Then
                dr(6) = 0.0
                dr(7) = 0.0
                dr(8) = 0.0
                dr(9) = 0.0
                dr(10) = 0.0
                dr(11) = 0.0
                dr(12) = 0.0
                dr(13) = 0.0
                dr(14) = 0.0
                dr(15) = 0.0
            End If
            dr(12) = 0.0
            dr(13) = 0.0

            dt.Rows.Add(dr)
        Next
        dgvHojaTrabajo.DataSource = dt
        dgvHojaTrabajo.TableOptions.ListBoxSelectionMode = SelectionMode.One
    End Sub

#End Region

    Dim colorx As New GridMetroColors()
    Sub GridCFG(GGC As GridGroupingControl)
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = False
        GGC.ShowColumnHeaders = True

        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        GGC.SetMetroStyle(colorx)
        GGC.BorderStyle = System.Windows.Forms.BorderStyle.None

        '  GGC.BrowseOnly = True
        GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        GGC.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        GGC.TableOptions.ListBoxSelectionMode = SelectionMode.One
        GGC.TableOptions.SelectionBackColor = Color.Gray
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.Format = "MMM dd yyyy"
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.Hide
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).HeaderText = "Date"
        'Me.gridGroupingControl1.TableDescriptor.Columns(1).HeaderText = "Category"
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.Currency
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromArgb(168, 178, 189)
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.TextAlign = GridTextAlign.Left

        'this.gridGroupingControl1.TableDescriptor.Columns["Amount"].Width = (this.tableLayoutPanel3.Width / 5) - 50;
        GGC.AllowProportionalColumnSizing = False
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        GGC.Table.DefaultColumnHeaderRowHeight = 45
        GGC.Table.DefaultRecordRowHeight = 40
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Private Function sumColumnByName(Column As String) As decimal
        Dim suma As Decimal = 0
        For Each i In dgvHojaTrabajo.Table.Records
            Dim valNumber = i.GetValue(Column).ToString
            If valNumber.Trim.Length > 0 Then
                suma += CDec(i.GetValue(Column))
            End If
        Next
        Return suma
    End Function

    Private Sub SumarioColumnas()


        'RESULTADOS POR NATURALEZA
        Dim scd As New GridSummaryColumnDescriptor()
        scd.DataMember = "invDebe"
        scd.Name = "invDebeREJ"
        scd.SummaryType = Syncfusion.Grouping.SummaryType.DoubleAggregate
        scd.Format = "{Sum:###,###,##0.00}" '"{Sum:#.00}"

        Dim scd1 As New GridSummaryColumnDescriptor()
        scd1.DataMember = "invHaber"
        scd1.Name = "invHaberREJ"
        scd1.SummaryType = Syncfusion.Grouping.SummaryType.DoubleAggregate
        scd1.Format = "{Sum:###,###,##0.00}" ' "{Sum:#.00}"

        Dim scd7 As New GridSummaryColumnDescriptor()
        scd7.DataMember = "rnDebe"
        scd7.Name = "rnDebeREJ"
        scd7.SummaryType = Syncfusion.Grouping.SummaryType.DoubleAggregate
        scd7.Format = "{Sum:###,###,##0.00}" '"{Sum:#.00}"

        Dim scd8 As New GridSummaryColumnDescriptor()
        scd8.DataMember = "rnHaber"
        scd8.Name = "rnHaberREJ"
        scd8.SummaryType = Syncfusion.Grouping.SummaryType.DoubleAggregate
        scd8.Format = "{Sum:###,###,##0.00}" '"{Sum:#.00}"

        '----------------------------------------------------------------
        Dim scd9 As New GridSummaryColumnDescriptor()
        scd9.DataMember = "rpfDebe"
        scd9.Name = "rpfDebeREJ"
        scd9.SummaryType = Syncfusion.Grouping.SummaryType.DoubleAggregate
        scd9.Format = "{Sum:###,###,##0.00}" '"{Sum:#.00}"

        Dim scd10 As New GridSummaryColumnDescriptor()
        scd10.DataMember = "rpfHaber"
        scd10.Name = "rpfHaberREJ"
        scd10.SummaryType = Syncfusion.Grouping.SummaryType.DoubleAggregate
        scd10.Format = "{Sum:###,###,##0.00}" '"{Sum:#.00}"


        Dim scr As New GridSummaryRowDescriptor()
        scr.Name = "RESULT. EJERCICIO"
        scr.SummaryColumns.Add(scd)
        scr.SummaryColumns.Add(scd1)
        scr.SummaryColumns.Add(scd7)
        scr.SummaryColumns.Add(scd8)
        scr.SummaryColumns.Add(scd9)
        scr.SummaryColumns.Add(scd10)


        Me.dgvHojaTrabajo.TableDescriptor.SummaryRows.Add(scr)


        'RESULTADOS TOTALES
        Dim scd3 As New GridSummaryColumnDescriptor()
        scd3.DataMember = "invDebe"
        scd3.Name = "invDebeTOT"
        scd3.SummaryType = Syncfusion.Grouping.SummaryType.DoubleAggregate
        scd3.Format = "{Sum:###,###,##0.00}" '"{Sum:#.00}"

        Dim scd4 As New GridSummaryColumnDescriptor()
        scd4.DataMember = "invHaber"
        scd4.Name = "invHaberTOT"
        scd4.SummaryType = Syncfusion.Grouping.SummaryType.DoubleAggregate
        scd4.Format = "{Sum:###,###,##0.00}" '"{Sum:#.00}"


        '------------------RESUTADOS POR NATURALEZA
        Dim scd5 As New GridSummaryColumnDescriptor()
        scd5.DataMember = "rnDebe"
        scd5.Name = "rnDebeTOT"
        scd5.SummaryType = Syncfusion.Grouping.SummaryType.DoubleAggregate
        scd5.Format = "{Sum:###,###,##0.00}" '"{Sum:#.00}"

        Dim scd6 As New GridSummaryColumnDescriptor()
        scd6.DataMember = "rnHaber"
        scd6.Name = "rnHaberTOT"
        scd6.SummaryType = Syncfusion.Grouping.SummaryType.DoubleAggregate
        scd6.Format = "{Sum:###,###,##0.00}" '"{Sum:#.00}"

        '----------------------------------------------------------------
        Dim scd11 As New GridSummaryColumnDescriptor()
        scd11.DataMember = "rpfDebe"
        scd11.Name = "rpfDebeTOT"
        scd11.SummaryType = Syncfusion.Grouping.SummaryType.DoubleAggregate
        scd11.Format = "{Sum:###,###,##0.00}" '"{Sum:#.00}"

        Dim scd12 As New GridSummaryColumnDescriptor()
        scd12.DataMember = "rpfHaber"
        scd12.Name = "rpfHaberTOT"
        scd12.SummaryType = Syncfusion.Grouping.SummaryType.DoubleAggregate
        scd12.Format = "{Sum:###,###,##0.00}" ' "{Sum:#.00}"


        Dim scr1 As New GridSummaryRowDescriptor()
        scr1.Name = "TOTALES"
        scr1.SummaryColumns.Add(scd3)
        scr1.SummaryColumns.Add(scd4)
        scr1.SummaryColumns.Add(scd5)
        scr1.SummaryColumns.Add(scd6)
        scr1.SummaryColumns.Add(scd11)
        scr1.SummaryColumns.Add(scd12)
        Me.dgvHojaTrabajo.TableDescriptor.SummaryRows.Add(scr1)

    End Sub

    Private Sub FrmHojaTrabajo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        LoadingAnimator.Wire(Me.dgvHojaTrabajo.TableControl)
        If cboAnios.Text.Trim.Length > 0 Then
            If cboMes.Text = "ENERO" Then
                Cuentas(cboAnios.Text, "01")
            ElseIf cboMes.Text = "FEBRERO" Then
                Cuentas(cboAnios.Text, "02")
            ElseIf cboMes.Text = "MARZO" Then
                Cuentas(cboAnios.Text, "03")
            ElseIf cboMes.Text = "ABRIL" Then
                Cuentas(cboAnios.Text, "04")
            ElseIf cboMes.Text = "MAYO" Then
                Cuentas(cboAnios.Text, "05")
            ElseIf cboMes.Text = "JUNIO" Then
                Cuentas(cboAnios.Text, "06")
            ElseIf cboMes.Text = "JULIO" Then
                Cuentas(cboAnios.Text, "07")
            ElseIf cboMes.Text = "AGOSTO" Then
                Cuentas(cboAnios.Text, "08")
            ElseIf cboMes.Text = "SETIEMBRE" Then
                Cuentas(cboAnios.Text, "09")
            ElseIf cboMes.Text = "OCTUBRE" Then
                Cuentas(cboAnios.Text, "10")
            ElseIf cboMes.Text = "NOVIEMBRE" Then
                Cuentas(cboAnios.Text, "11")
            ElseIf cboMes.Text = "DICIEMBRE" Then
                Cuentas(cboAnios.Text, "12")
            End If
        Else
            MessageBox.Show("eliga un año")
        End If
        LoadingAnimator.UnWire(Me.dgvHojaTrabajo.TableControl)
    End Sub
    Dim hoveredIndex As Integer = 0

    Dim selectionColl As New Hashtable()
    Private Sub dgvHojaTrabajo_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvHojaTrabajo.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            Me.dgvHojaTrabajo.TableControl.Selections.Clear()
        End If

        Select Case e.TableCellIdentity.TableCellType
            Case GridTableCellType.SummaryFieldCell
                If e.TableCellIdentity.SummaryColumn.Name = "invDebeTOT" Then

                    Dim sumaDebe As Decimal = sumColumnByName("invDebe")
                    Dim sumaHaber As Decimal = sumColumnByName("invHaber")
                    Dim result As Decimal = 0

                    If sumaDebe > sumaHaber Then
                        result = sumaDebe - sumaHaber
                    Else
                        result = sumaHaber - sumaDebe
                    End If

                    If sumaDebe > sumaHaber Then
                        e.Style.CellValue = sumaDebe + 0
                    Else
                        e.Style.CellValue = sumaDebe + result
                    End If
               
                End If

                If e.TableCellIdentity.SummaryColumn.Name = "invHaberTOT" Then
                    Dim sumaDebe As Decimal? = sumColumnByName("invDebe")
                    Dim sumaHaber As Decimal? = sumColumnByName("invHaber")
                    Dim result As Decimal? = 0

                    If sumaDebe > sumaHaber Then
                        result = sumaDebe - sumaHaber
                    Else
                        result = sumaHaber - sumaDebe
                    End If

                    If sumaHaber > sumaDebe Then
                        e.Style.CellValue = sumaHaber + 0
                    Else
                        e.Style.CellValue = sumaHaber + result
                    End If
                End If

                If e.TableCellIdentity.SummaryColumn.Name = "invDebeREJ" Then
                    Dim sumaDebe As Decimal? = sumColumnByName("invDebe")
                    Dim sumaHaber As Decimal? = sumColumnByName("invHaber")
                    If sumaDebe > sumaHaber Then
                        e.Style.CellValue = 0.0
                    ElseIf sumaHaber > sumaDebe Then
                        'e.Style.CellValue = Math.Round(sumaHaber.GetValueOrDefault - sumaDebe.GetValueOrDefault, 2)
                        e.Style.CellValue = (sumaHaber.GetValueOrDefault - sumaDebe.GetValueOrDefault)
                    Else
                        'e.Style.CellValue = Math.Round(sumaDebe.GetValueOrDefault - sumaHaber.GetValueOrDefault, 2)
                        e.Style.CellValue = (sumaDebe.GetValueOrDefault - sumaHaber.GetValueOrDefault)
                    End If
                End If

                If e.TableCellIdentity.SummaryColumn.Name = "invHaberREJ" Then
                    Dim sumaDebe As Decimal? = sumColumnByName("invDebe")
                    Dim sumaHaber As Decimal? = sumColumnByName("invHaber")

                    If sumaHaber > sumaDebe Then
                        e.Style.CellValue = 0.0
                    ElseIf sumaDebe > sumaHaber Then
                        e.Style.CellValue = (sumaDebe.GetValueOrDefault - sumaHaber.GetValueOrDefault)
                    Else
                        e.Style.CellValue = (sumaHaber.GetValueOrDefault - sumaDebe.GetValueOrDefault)
                    End If
                End If

                If e.TableCellIdentity.SummaryColumn.Name = "rnHaberREJ" Then
                    Dim sumaDebe As Decimal? = sumColumnByName("rnDebe")
                    Dim sumaHaber As Decimal? = sumColumnByName("rnHaber")

                    If sumaHaber > sumaDebe Then
                        e.Style.CellValue = 0.0
                    ElseIf sumaDebe > sumaHaber Then
                        e.Style.CellValue = (sumaDebe.GetValueOrDefault - sumaHaber.GetValueOrDefault)
                    Else
                        e.Style.CellValue = (sumaHaber.GetValueOrDefault - sumaDebe.GetValueOrDefault)
                    End If

                End If

                If e.TableCellIdentity.SummaryColumn.Name = "rnDebeREJ" Then
                    Dim sumaDebe As Decimal? = sumColumnByName("rnDebe")
                    Dim sumaHaber As Decimal? = sumColumnByName("rnHaber")

                    If sumaDebe > sumaHaber Then
                        e.Style.CellValue = 0.0
                    ElseIf sumaHaber > sumaDebe Then
                        e.Style.CellValue = (sumaHaber.GetValueOrDefault - sumaDebe.GetValueOrDefault)
                    Else
                        e.Style.CellValue = (sumaDebe.GetValueOrDefault - sumaHaber.GetValueOrDefault)
                    End If
                End If

                If e.TableCellIdentity.SummaryColumn.Name = "rnDebeTOT" Then

                    Dim sumaDebe As Decimal? = sumColumnByName("rnDebe")
                    Dim sumaHaber As Decimal? = sumColumnByName("rnHaber")
                    Dim result As Decimal? = 0

                    If sumaDebe > sumaHaber Then
                        result = sumaDebe - sumaHaber
                    Else
                        result = sumaHaber - sumaDebe
                    End If

                    If sumaDebe > sumaHaber Then
                        e.Style.CellValue = sumaDebe + 0
                    Else
                        e.Style.CellValue = sumaDebe + result
                    End If

                End If

                If e.TableCellIdentity.SummaryColumn.Name = "rnHaberTOT" Then
                    Dim sumaDebe As Decimal? = sumColumnByName("rnDebe")
                    Dim sumaHaber As Decimal? = sumColumnByName("rnHaber")
                    Dim result As Decimal? = 0

                    If sumaDebe > sumaHaber Then
                        result = sumaDebe - sumaHaber
                    Else
                        result = sumaHaber - sumaDebe
                    End If

                    If sumaHaber > sumaDebe Then
                        e.Style.CellValue = sumaHaber + 0
                    Else
                        e.Style.CellValue = sumaHaber + result
                    End If
                End If


                If e.TableCellIdentity.SummaryColumn.Name = "rpfDebeREJ" Then
                    Dim sumaDebe As Decimal? = sumColumnByName("rpfDebe")
                    Dim sumaHaber As Decimal? = sumColumnByName("rpfHaber")

                    If sumaDebe > sumaHaber Then
                        e.Style.CellValue = 0.0
                    ElseIf sumaHaber > sumaDebe Then
                        e.Style.CellValue = (sumaHaber.GetValueOrDefault - sumaDebe.GetValueOrDefault)
                    Else
                        e.Style.CellValue = (sumaDebe.GetValueOrDefault - sumaHaber.GetValueOrDefault)
                    End If
                End If

                If e.TableCellIdentity.SummaryColumn.Name = "rpfHaberREJ" Then
                    Dim sumaDebe As Decimal? = sumColumnByName("rpfDebe")
                    Dim sumaHaber As Decimal? = sumColumnByName("rpfHaber")

                    If sumaHaber > sumaDebe Then
                        e.Style.CellValue = 0.0
                    ElseIf sumaDebe > sumaHaber Then
                        e.Style.CellValue = (sumaDebe.GetValueOrDefault - sumaHaber.GetValueOrDefault)
                    Else
                        e.Style.CellValue = (sumaHaber.GetValueOrDefault - sumaDebe.GetValueOrDefault)
                    End If
                End If


                If e.TableCellIdentity.SummaryColumn.Name = "rpfDebeTOT" Then

                    Dim sumaDebe As Decimal? = sumColumnByName("rpfDebe")
                    Dim sumaHaber As Decimal? = sumColumnByName("rpfHaber")
                    Dim result As Decimal? = 0

                    If sumaDebe > sumaHaber Then
                        result = sumaDebe - sumaHaber
                    Else
                        result = sumaHaber - sumaDebe
                    End If

                    If sumaDebe > sumaHaber Then
                        e.Style.CellValue = sumaDebe + 0
                    Else
                        e.Style.CellValue = sumaDebe + result
                    End If

                End If

                If e.TableCellIdentity.SummaryColumn.Name = "rpfHaberTOT" Then

                    Dim sumaDebe As Decimal? = sumColumnByName("rpfDebe")
                    Dim sumaHaber As Decimal? = sumColumnByName("rpfHaber")
                    Dim result As Decimal? = 0

                    If sumaDebe > sumaHaber Then
                        result = sumaDebe - sumaHaber
                    Else
                        result = sumaHaber - sumaDebe
                    End If

                    If sumaHaber > sumaDebe Then
                        e.Style.CellValue = sumaHaber + 0
                    Else
                        e.Style.CellValue = sumaHaber + result
                    End If
                End If

                Exit Select
        End Select


    End Sub


    Private Sub dgvHojaTrabajo_SelectedRecordsChanged(sender As Object, e As SelectedRecordsChangedEventArgs) Handles dgvHojaTrabajo.SelectedRecordsChanged

    End Sub


    Private Sub dgvHojaTrabajo_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvHojaTrabajo.TableControlCellClick

    End Sub

    Private Sub dgvHojaTrabajo_TableControlCellDoubleClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvHojaTrabajo.TableControlCellDoubleClick
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(dgvHojaTrabajo.Table.CurrentRecord) Then
            Dim srtMes As String = Nothing
            If cboMes.Text = "ENERO" Then
                srtMes = "01"
            ElseIf cboMes.Text = "FEBRERO" Then
                srtMes = "02"
            ElseIf cboMes.Text = "MARZO" Then
                srtMes = "03"
            ElseIf cboMes.Text = "ABRIL" Then
                srtMes = "04"
            ElseIf cboMes.Text = "MAYO" Then
                srtMes = "05"
            ElseIf cboMes.Text = "JUNIO" Then
                srtMes = "06"
            ElseIf cboMes.Text = "JULIO" Then
                srtMes = "07"
            ElseIf cboMes.Text = "AGOSTO" Then
                srtMes = "08"
            ElseIf cboMes.Text = "SETIEMBRE" Then
                srtMes = "09"
            ElseIf cboMes.Text = "OCTUBRE" Then
                srtMes = "10"
            ElseIf cboMes.Text = "NOVIEMBRE" Then
                srtMes = "11"
            ElseIf cboMes.Text = "DICIEMBRE" Then
                srtMes = "12"
            End If
            Dim r As Record = dgvHojaTrabajo.Table.CurrentRecord
            Dim f As New frmHojaTrabajoDetalle(cboAnios.Text, srtMes, r.GetValue("cuenta"), r)
            f.CaptionLabels(0).Text = "Resumen cuenta contable: " & r.GetValue("cuenta") & " - " & r.GetValue("nomCuenta")
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub
    Private Sub IsMouseHover(row As Integer, col As Integer, isHover As Boolean, GGC As GridGroupingControl)
        Dim color As New GridMetroColors()
        Dim id As GridTableCellStyleInfoIdentity = GGC.TableControl.GetTableViewStyleInfo(row, col).TableCellIdentity
        If id.DisplayElement.IsRecord() Then
            Dim key As Integer = id.DisplayElement.GetRecord().Id
            'if (selectionColl.Contains(key))
            '    selectionColl[key] = isHover;
            'else
            hoveredIndex = row
            selectionColl.Clear()
            'if (selectionColl.Count == 0)
            '    selectionColl.Add(key, isHover);
            GGC.TableControl.Refresh()
        End If

        GGC.TableControl.Selections.Clear()

    End Sub
    Private Sub dgvHojaTrabajo_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgvHojaTrabajo.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgvHojaTrabajo)
    End Sub

    Private Sub dgvHojaTrabajo_TableControlCurrentCellControlDoubleClick(sender As Object, e As GridTableControlControlEventArgs) Handles dgvHojaTrabajo.TableControlCurrentCellControlDoubleClick


    End Sub
End Class