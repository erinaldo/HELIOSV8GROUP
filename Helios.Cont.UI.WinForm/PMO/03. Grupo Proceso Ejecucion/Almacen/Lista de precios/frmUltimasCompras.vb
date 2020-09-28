Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Public Class frmUltimasCompras
    Inherits frmMaster

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        Me.WindowState = FormWindowState.Normal
        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(dgvEntrada, True, False)
    End Sub



#Region "Métodos"
    Public Sub UltimasEntradas(intCuota As Integer)
        Dim CompraSA As New DocumentoCompraDetalleSA
        Dim dt As New DataTable()

        dt.Columns.Add("FechaDoc", GetType(String)) '0
        dt.Columns.Add("tipoCompra", GetType(String)) '01
        dt.Columns.Add("TipoDoc", GetType(String)) '02
        dt.Columns.Add("descripcionItem", GetType(String)) '03
        dt.Columns.Add("cantidad", GetType(Decimal)) '04
        dt.Columns.Add("unidad1", GetType(String)) '05
        dt.Columns.Add("bonificacion", GetType(String)) '06
        dt.Columns.Add("precioUnitario", GetType(Decimal)) '07
        dt.Columns.Add("valCompraMN", GetType(Decimal)) '08
        dt.Columns.Add("importe", GetType(Decimal)) '09
        dt.Columns.Add("precioUnitarioUS", GetType(Decimal)) '010
        dt.Columns.Add("valCompraME", GetType(Decimal)) '011
        dt.Columns.Add("importeUS", GetType(Decimal)) '012
        dt.Columns.Add("proveedor", GetType(String)) '013
        dt.Columns.Add("tasaIva", GetType(Decimal)) '014
        dt.Columns.Add("precioUnitarioIva")

        Dim str As String
        For Each i In CompraSA.UltimasEntradasPorFecha(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, intCuota, txtItem.ValueMember)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.FechaDoc).ToString("dd-MMM-yy hh:mm tt ")
            dr(0) = str
            dr(1) = i.tipoCompra
            dr(2) = i.TipoDoc
            dr(3) = i.descripcionItem
            dr(4) = i.monto1.GetValueOrDefault
            dr(5) = i.unidad1
            Select Case i.bonificacion
                Case "S"
                    dr(6) = "SI"
                Case Else
                    dr(6) = "NO"
            End Select

            Select Case i.tipoCompra
                Case TIPO_COMPRA.COMPRA
                    dr(7) = Math.Round(i.montokardex.GetValueOrDefault / i.monto1.GetValueOrDefault, 2) ' i.precioUnitario
                    dr(8) = i.montokardex.GetValueOrDefault
                    dr(9) = i.importe.GetValueOrDefault
                    dr(10) = Math.Round(i.montokardexUS.GetValueOrDefault / i.monto1.GetValueOrDefault, 2) ' i.precioUnitarioUS.GetValueOrDefault
                    dr(11) = i.montokardexUS
                    dr(12) = i.importeUS.GetValueOrDefault

                    dr(15) = Math.Round(i.importe.GetValueOrDefault / i.monto1.GetValueOrDefault, 2)
                Case Else
                    dr(7) = Math.Round(i.importe.GetValueOrDefault / i.monto1.GetValueOrDefault, 2)
                    dr(8) = i.importe.GetValueOrDefault
                    dr(9) = i.importe.GetValueOrDefault
                    dr(10) = i.precioUnitarioUS.GetValueOrDefault
                    dr(11) = i.importeUS
                    dr(12) = i.importeUS.GetValueOrDefault

                    Dim puSin = Math.Round(i.importe.GetValueOrDefault / i.monto1.GetValueOrDefault, 2)
                    Dim iva = Math.Round(puSin * 0.18, 2)
                    Dim precioConva = puSin + iva
                    dr(15) = CDec(precioConva).ToString("N2")
            End Select
            dr(13) = i.NombreProveedor
            dr(14) = i.PorcIva

            dt.Rows.Add(dr)
        Next

        Me.dgvEntrada.DataSource = dt
        dgvEntrada.TableDescriptor.Relations.Clear()
        dgvEntrada.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
        dgvEntrada.TableOptions.ListBoxSelectionMode = SelectionMode.One
        'dgvEntrada.Appearance.AnyRecordFieldCell.Enabled = False
        dgvEntrada.GroupDropPanel.Visible = True
        dgvEntrada.TableDescriptor.GroupedColumns.Clear()

    End Sub
#End Region

    Private Sub frmUltimasCompras_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmUltimasCompras_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cboMov_Click(sender As Object, e As EventArgs) Handles cboMov.Click

    End Sub

    Private Sub cboMov_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMov.SelectedIndexChanged
        'Me.Cursor = Cursors.WaitCursor
        'Select Case cboMov.Text
        '    Case "5 últimas entradas"
        '        UltimasEntradas(5)

        '    Case "10 últimas entradas"
        '        UltimasEntradas(10)

        '    Case "15 últimas entradas"
        '        UltimasEntradas(15)

        '    Case Else
        '        dgvEntrada.Table.Records.DeleteAll()
        'End Select
        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvEntrada_TableControlCurrentCellControlDoubleClick(sender As Object, e As Grid.Grouping.GridTableControlControlEventArgs) Handles dgvEntrada.TableControlCurrentCellControlDoubleClick
        Dim n As New RecuperarCarteras
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        datos.Clear()

        If MessageBoxAdv.Show("Desea seleccionar el valor de compra?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then

            Select Case Me.dgvEntrada.Table.CurrentRecord.GetValue("tipoCompra")
                Case "OEA", "OSA"
                    ValorEntrada = Math.Round(CDbl(Me.dgvEntrada.Table.CurrentRecord.GetValue("importe")) / CDbl(Me.dgvEntrada.Table.CurrentRecord.GetValue("cantidad")), 2)
                    ValorEntradaME = Math.Round(CDbl(Me.dgvEntrada.Table.CurrentRecord.GetValue("importeUS")) / CDbl(Me.dgvEntrada.Table.CurrentRecord.GetValue("cantidad")), 2)
                Case Else
                    Dim cant = dgvEntrada.Table.CurrentRecord.GetValue("cantidad")
                    If cant = 0 Then
                        ValorEntrada = CDec(dgvEntrada.Table.CurrentRecord.GetValue("valCompraMN"))
                        ValorEntradaME = CDec(dgvEntrada.Table.CurrentRecord.GetValue("valCompraME"))
                    Else
                        ValorEntrada = Math.Round(CDbl(Me.dgvEntrada.Table.CurrentRecord.GetValue("valCompraMN")) / CDbl(Me.dgvEntrada.Table.CurrentRecord.GetValue("cantidad")), 2)
                        ValorEntradaME = Math.Round(CDbl(Me.dgvEntrada.Table.CurrentRecord.GetValue("valCompraME")) / CDbl(Me.dgvEntrada.Table.CurrentRecord.GetValue("cantidad")), 2)
                    End If
            End Select


            n.Cuenta = Me.dgvEntrada.Table.CurrentRecord.GetValue("FechaDoc") 'fecha
            n.PMmn = ValorEntrada
            n.PMme = ValorEntradaME
            n.Montomn = Me.dgvEntrada.Table.CurrentRecord.GetValue("importe")
            n.Montome = Me.dgvEntrada.Table.CurrentRecord.GetValue("importeUS")
            n.NomProceso = Me.dgvEntrada.Table.CurrentRecord.GetValue("proveedor")
            n.ValCompraMN = Me.dgvEntrada.Table.CurrentRecord.GetValue("valCompraMN")
            n.ValCompraME = Me.dgvEntrada.Table.CurrentRecord.GetValue("valCompraME")
            n.TasaIva = Me.dgvEntrada.Table.CurrentRecord.GetValue("tasaIva")
            datos.Add(n)

            'With frmNuevoPrecio
            '    .txtfecha.Text = ""
            '    .txtPrecUNit.DecimalValue = ValorEntrada
            '    .txtPrecUNitme.DecimalValue = ValorEntradaME
            '    .txtValorEntrada.DecimalValue = Me.dgvEntrada.Table.CurrentRecord.GetValue("valCompraMN")
            '    .txtValorEntradame.DecimalValue = Me.dgvEntrada.Table.CurrentRecord.GetValue("valCompraME")
            '    .txtPrecioMN.DecimalValue = Me.dgvEntrada.Table.CurrentRecord.GetValue("importe")
            '    .txtPrecioME.DecimalValue = Me.dgvEntrada.Table.CurrentRecord.GetValue("importeUS")
            '    .txtProveedor.Text = Me.dgvEntrada.Table.CurrentRecord.GetValue("proveedor")
            'End With
            Dispose()
        End If
    End Sub

    Private Sub dgvEntrada_TableControlCellClick(sender As Object, e As Grid.Grouping.GridTableControlCellClickEventArgs) Handles dgvEntrada.TableControlCellClick

    End Sub

    Private Sub RoundButton21_Click(sender As Object, e As EventArgs) Handles RoundButton21.Click
        Me.Cursor = Cursors.WaitCursor
        Select Case cboMov.Text
            Case "5 últimas entradas"
                UltimasEntradas(5)

            Case "10 últimas entradas"
                UltimasEntradas(10)

            Case "15 últimas entradas"
                UltimasEntradas(15)

            Case Else
                dgvEntrada.Table.Records.DeleteAll()
        End Select
        Me.Cursor = Cursors.Arrow
    End Sub
End Class