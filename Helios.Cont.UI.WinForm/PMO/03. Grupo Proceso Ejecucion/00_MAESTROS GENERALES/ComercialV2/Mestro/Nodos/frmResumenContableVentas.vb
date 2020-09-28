Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Cont.Business.Entity
Imports Helios.General
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Public Class frmResumenContableVentas

#Region "Attributes"
    Dim hoveredIndex As Integer = 0

    Dim selectionColl As New Hashtable()
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        años()
        FormatoGrid(dgvHojaTrabajo)
    End Sub
#End Region

#Region "Methods"
    Private Sub GetHojaTrabajoCompras(dtpPeriodoAnio As Integer, dtpPEriodoMes As Integer)
        'Dim compraSA As New HojaTrabajoFinalRPTSA
        Dim cierreSA As New AsientoSA
        Dim cuentasa As New cuentaplanContableEmpresaSA
        Dim SumaDebe As Decimal = 0
        Dim SumaHaber As Decimal = 0

        Dim dt As New DataTable("Hoja de Trabajo de compras")
        dt.Columns.Add(New DataColumn("cuenta"))
        dt.Columns.Add(New DataColumn("nomCuenta"))
        dt.Columns.Add(New DataColumn("debe"))
        dt.Columns.Add(New DataColumn("haber"))

        'dgvCuentaDetalle.DataSource

        For Each i As usp_HojaTrabajoXmodulo_Result In cierreSA.GetHojaTrabajoXmodulo(New asiento With {.tipoAsiento = ASIENTO_CONTABLE.Venta_Existencia, .idEmpresa = Gempresas.IdEmpresaRuc, .periodo = String.Format("{0:00}", dtpPEriodoMes) & "/" & dtpPeriodoAnio})

            If i.TOTAL_DEBE = 0 AndAlso i.TOTAL_HABER = 0 Then

            Else
                SumaDebe = 0
                SumaHaber = 0

                Dim dr As DataRow = dt.NewRow()
                dr(0) = i.cuenta
                dr(1) = i.descripcion
                dr(2) = CDec(i.TOTAL_DEBE)
                dr(3) = CDec(i.TOTAL_HABER)
                dt.Rows.Add(dr)
            End If
        Next
        dgvHojaTrabajo.DataSource = dt
        dgvHojaTrabajo.TableOptions.ListBoxSelectionMode = SelectionMode.One
    End Sub
    Private Sub IsMouseHover(row As Integer, col As Integer, isHover As Boolean, GGC As GridGroupingControl)
        'Dim color As New GridMetroColors()
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

    Public Sub años()
        Dim AniosSA As New empresaPeriodoSA
        cboAnios.DisplayMember = "periodo"
        cboAnios.ValueMember = "periodo"
        cboAnios.DataSource = AniosSA.GetListar_empresaPeriodo(New empresaPeriodo With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento})
        cboAnios.Text = AnioGeneral

        cboMes.SelectedIndex = DateTime.Now.Month - 1
    End Sub
#End Region

#Region "Events"
    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        LoadingAnimator.Wire(Me.dgvHojaTrabajo.TableControl)
        If cboAnios.Text.Trim.Length > 0 Then
            If cboMes.Text = "ENERO" Then
                GetHojaTrabajoCompras(cboAnios.Text, "01")
            ElseIf cboMes.Text = "FEBRERO" Then
                GetHojaTrabajoCompras(cboAnios.Text, "02")
            ElseIf cboMes.Text = "MARZO" Then
                GetHojaTrabajoCompras(cboAnios.Text, "03")
            ElseIf cboMes.Text = "ABRIL" Then
                GetHojaTrabajoCompras(cboAnios.Text, "04")
            ElseIf cboMes.Text = "MAYO" Then
                GetHojaTrabajoCompras(cboAnios.Text, "05")
            ElseIf cboMes.Text = "JUNIO" Then
                GetHojaTrabajoCompras(cboAnios.Text, "06")
            ElseIf cboMes.Text = "JULIO" Then
                GetHojaTrabajoCompras(cboAnios.Text, "07")
            ElseIf cboMes.Text = "AGOSTO" Then
                GetHojaTrabajoCompras(cboAnios.Text, "08")
            ElseIf cboMes.Text = "SETIEMBRE" Then
                GetHojaTrabajoCompras(cboAnios.Text, "09")
            ElseIf cboMes.Text = "OCTUBRE" Then
                GetHojaTrabajoCompras(cboAnios.Text, "10")
            ElseIf cboMes.Text = "NOVIEMBRE" Then
                GetHojaTrabajoCompras(cboAnios.Text, "11")
            ElseIf cboMes.Text = "DICIEMBRE" Then
                GetHojaTrabajoCompras(cboAnios.Text, "12")
            End If
        Else
            MessageBox.Show("eliga un año")
        End If
        LoadingAnimator.UnWire(Me.dgvHojaTrabajo.TableControl)
    End Sub

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
    End Sub

    Private Sub dgvHojaTrabajo_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgvHojaTrabajo.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgvHojaTrabajo)
    End Sub
#End Region

End Class