Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Tools
Public Class frmNuevoPrecio
    Inherits frmMaster

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        CargarCombos()
        ' Add any initialization after the InitializeComponent() call.
        GridConfig()
        GridCFG(dgvPrecios)
    End Sub

#Region "Métodos"

    Sub GridCFG(grid As GridGroupingControl)
        grid.TableOptions.ShowRowHeader = False
        grid.TopLevelGroupOptions.ShowCaption = False

        Dim colorx As New GridMetroColors()
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

        grid.Table.DefaultColumnHeaderRowHeight = 25
        grid.Table.DefaultRecordRowHeight = 20
        grid.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Sub GridConfig()

        Dim dt As New DataTable()

        dt.Columns.Add("tipoPrec", GetType(String))
        dt.Columns.Add("idPrecio", GetType(String))
        dt.Columns.Add("precio", GetType(String))
        dt.Columns.Add("modo", GetType(Decimal))
        dt.Columns.Add("valVentamn", GetType(Decimal))
        dt.Columns.Add("valVentame", GetType(Decimal))
        dt.Columns.Add("utilidadmn", GetType(Decimal))
        dt.Columns.Add("utilidadme", GetType(Decimal))
        dt.Columns.Add("ivamn", GetType(Decimal))
        dt.Columns.Add("ivame", GetType(Decimal))
        dt.Columns.Add("precventamn", GetType(Decimal))
        dt.Columns.Add("precventame", GetType(Decimal))

        dgvPrecios.DataSource = dt

    End Sub

    'Sub CalculoprecioVenta()
    '    Dim precVentaMN As Decimal = 0
    '    Dim precVentaME As Decimal = 0
    '    Dim valVentaMN As Decimal = 0
    '    Dim valVentaME As Decimal = 0
    '    Dim ivaMN As Decimal = 0
    '    Dim ivaME As Decimal = 0
    '    If rbSinIva.Checked = True Then
    '        valVentaMN = txtPrecUNit.DecimalValue * (txtValPorcentaje.DecimalValue / 100)
    '        valVentaMN = valVentaMN + txtPrecUNit.DecimalValue

    '        valVentaME = txtPrecUNitme.DecimalValue * (txtValPorcentaje.DecimalValue / 100)
    '        valVentaME = valVentaME + txtPrecUNitme.DecimalValue

    '        txtValVentaMN.DecimalValue = valVentaMN
    '        txtValVentaME.DecimalValue = valVentaME

    '        '--------------------------------------------------------------------------------
    '        'hallando el iva
    '        ivaMN = valVentaMN * 0.18
    '        ivaME = valVentaME * 0.18

    '        txtIvaMN.DecimalValue = ivaMN
    '        txtIvaME.DecimalValue = ivaME
    '        '-------------------------------------------------------------------------------

    '        'Precio Total Final
    '        precVentaMN = valVentaMN + ivaMN
    '        precVentaME = valVentaME + ivaME

    '        txtPrecioMN.DecimalValue = precVentaMN
    '        txtPrecioME.DecimalValue = precVentaME
    '    ElseIf rbConIva.Checked = True Then

    '        valVentaMN = txtPUconIVAMN.DecimalValue * (txtValPorcentaje.DecimalValue / 100)
    '        'valVentaMN = valVentaMN + txtPUconIVAMN.DecimalValue

    '        valVentaME = txtPUconIVAME.DecimalValue * (txtValPorcentaje.DecimalValue / 100)
    '        'valVentaME = valVentaME + txtPUconIVAME.DecimalValue

    '        txtValVentaMN.DecimalValue = valVentaMN
    '        txtValVentaME.DecimalValue = valVentaME
    '        '--------------------------------------------------------------------------------
    '        'no aplica iva para este caso
    '        txtIvaMN.DecimalValue = 0
    '        txtIvaME.DecimalValue = 0
    '        '-------------------------------------------------------------------------------

    '        'Precio Total Final
    '        precVentaMN = txtPUconIVAMN.DecimalValue + valVentaMN
    '        precVentaME = txtPUconIVAME.DecimalValue + valVentaME

    '        txtPrecioMN.DecimalValue = precVentaMN
    '        txtPrecioME.DecimalValue = precVentaME
    '    End If
    'End Sub

    Sub CalculoprecioVentaGrid(r As Record)
        Dim precVentaMN As Decimal = 0
        Dim precVentaME As Decimal = 0
        Dim valVentaMN As Decimal = 0
        Dim valVentaME As Decimal = 0
        Dim ivaMN As Decimal = 0
        Dim ivaME As Decimal = 0
        Dim utilidadMN As Decimal = 0
        Dim utilidadME As Decimal = 0

        If CDec(r.GetValue("modo")) > 0 Then
            If r.GetValue("tipoPrec") = "2" Then ' SIN IVA
                'UTILIDAD
                utilidadMN = txtPrecUNit.DecimalValue * (CDec(r.GetValue("modo")) / 100)
                utilidadME = txtPrecUNitme.DecimalValue * (CDec(r.GetValue("modo")) / 100)
                r.SetValue("utilidadmn", utilidadMN)
                r.SetValue("utilidadme", utilidadME)

                'VALOR DE VENTA
                valVentaMN = utilidadMN + txtPrecUNit.DecimalValue
                valVentaME = utilidadME + txtPrecUNitme.DecimalValue
                r.SetValue("valVentamn", valVentaMN)
                r.SetValue("valVentame", valVentaME)

                '--------------------------------------------------------------------------------
                'hallando el iva
                ivaMN = valVentaMN * 0.18
                ivaME = valVentaME * 0.18

                r.SetValue("ivamn", ivaMN)
                r.SetValue("ivame", ivaME)
                '-------------------------------------------------------------------------------

                'Precio Total Final
                precVentaMN = valVentaMN + ivaMN
                precVentaME = valVentaME + ivaME

                r.SetValue("precventamn", precVentaMN)
                r.SetValue("precventame", precVentaME)
            ElseIf r.GetValue("tipoPrec") = "1" Then ' CON IVA
                'UTILIDAD
                utilidadMN = txtPUconIVAMN.DecimalValue * (CDec(r.GetValue("modo")) / 100)
                utilidadME = txtPUconIVAME.DecimalValue * (CDec(r.GetValue("modo")) / 100)
                r.SetValue("utilidadmn", utilidadMN)
                r.SetValue("utilidadme", utilidadME)

                'VALOR DE VENTA
                valVentaMN = 0
                valVentaME = 0
                r.SetValue("valVentamn", valVentaMN)
                r.SetValue("valVentame", valVentaME)
                '--------------------------------------------------------------------------------
                'no aplica iva para este caso
                r.SetValue("ivamn", 0)
                r.SetValue("ivame", 0)
                '-------------------------------------------------------------------------------

                'Precio Total Final
                precVentaMN = txtPUconIVAMN.DecimalValue + utilidadMN
                precVentaME = txtPUconIVAME.DecimalValue + utilidadME

                r.SetValue("precventamn", precVentaMN)
                r.SetValue("precventame", precVentaME)
            Else
                MessageBox.Show("")
            End If
        End If


    End Sub

    Sub Ubicar(intPrecio As Integer)
        Dim precioSA As New ConfiguracionPrecioSA

        With precioSA.EncontrarPrecioXitem(New configuracionPrecio With {.idPrecio = intPrecio})
            txtTipo.Text = .tipo
            TextBoxExt1.Text = .tasaPorcentaje
        End With
    End Sub

    Sub CargarCombos()
        Dim precioSA As New ConfiguracionPrecioSA

        cboTipo.DisplayMember = "precio"
        cboTipo.ValueMember = "idPrecio"
        cboTipo.DataSource = precioSA.ListadoPrecios()

    End Sub

    Sub Grabar()
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim precio As New configuracionPrecioProducto
        Dim Lista As New List(Of configuracionPrecioProducto)
        Try
            For Each r As Record In dgvPrecios.Table.Records
                precio = New configuracionPrecioProducto
                precio.idPrecio = r.GetValue("idPrecio")
                precio.idproducto = CInt(txtProducto.Tag)
                precio.fecha = DateTime.Now
                precio.tipo = r.GetValue("tipoPrec")
                precio.valPorcentaje = r.GetValue("modo")
                precio.nroLote = Nothing
                precio.descripcion = r.GetValue("precio")

                If CDec(r.GetValue("precventamn")) <= 0 Then
                    Throw New Exception("El precio de venta debe ser mayor a cero")
                End If

                'If CDec(r.GetValue("precventame")) <= 0 Then
                '    Throw New Exception("El precio de venta debe ser mayor a cero")
                'End If

                If Not CDec(r.GetValue("precventamn")) > 0 Then
                    Throw New Exception("El precio de venta debe ser mayor a cero")
                End If

                Dim valMN As Decimal = CDec(r.GetValue("precventamn"))
                Dim valME As Decimal = CDec(r.GetValue("precventame"))
                Dim valVentaMN = FormatNumber(CDec(valMN), 2)
                Dim valVentaME = FormatNumber(CDec(valME), 2)

                precio.precioMN = CDec(valVentaMN)
                precio.precioME = CDec(valVentaME)
                Lista.Add(precio)
            Next
            'If Lista.Where(Function(o) o.valPorcentaje = 0).Count = 0 Then
            precioSA.GrabarPrecio(Lista)
            'Else
            '    Throw New Exception("Debe configurar todos los items de la canasta!")
            'End If
            Close()
        Catch ex As Exception
            MessageBoxAdv.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub
#End Region

    Public Function GetTable() As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("id", GetType(String))
        dt.Columns.Add("name", GetType(String))

        Dim dr As DataRow = dt.NewRow()
        dr(0) = "1"
        dr(1) = "CON IVA"
        dt.Rows.Add(dr)

        Dim dr1 As DataRow = dt.NewRow()
        dr1(0) = "2"
        dr1(1) = "SIN IVA"
        dt.Rows.Add(dr1)

        Return dt

    End Function

    Private Sub frmNuevoPrecio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ggcStyle As GridTableCellStyleInfo = dgvPrecios.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell
        ggcStyle.CellType = "ComboBox"
        ggcStyle.DataSource = GetTable()
        ggcStyle.ValueMember = "id"
        ggcStyle.DisplayMember = "name"
        ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive
        'dgvPrecios.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
        ChPrecioSoles.Checked = True
        ChPrecioDolares.Checked = False
        dgvPrecios.TableDescriptor.Columns("precventamn").Width = 100
        dgvPrecios.TableDescriptor.Columns("precventame").Width = 0
    End Sub

    Private Sub cboTipo_Click(sender As Object, e As EventArgs) Handles cboTipo.Click

    End Sub

    Private Sub cboTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipo.SelectedIndexChanged
        If cboTipo.Text.Trim.Length > 0 Then
            Ubicar(cboTipo.SelectedValue)
        End If
    End Sub

    'Private Sub txtValPorcentaje_TextChanged(sender As Object, e As EventArgs)
    '    If txtValPorcentaje.DecimalValue > 0 Then
    '        CalculoprecioVenta()
    '    End If
    'End Sub

    'Private Sub rbSinIva_CheckChanged(sender As Object, e As EventArgs)
    '    If rbSinIva.Checked = True Then
    '        If txtValPorcentaje.DecimalValue > 0 Then
    '            CalculoprecioVenta()
    '        End If
    '    End If
    'End Sub

    Private Sub rbConIva_CheckChanged(sender As Object, e As EventArgs)
        'If rbConIva.Checked = True Then
        '    If txtValPorcentaje.DecimalValue > 0 Then
        '        CalculoprecioVenta()
        '    End If
        'End If
    End Sub

    Private Sub GradientPanel2_Paint(sender As Object, e As PaintEventArgs) Handles GradientPanel2.Paint

    End Sub

    Private Sub cboModo_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub cboModo_SelectedIndexChanged(sender As Object, e As EventArgs)
        'If cboModo.Text = "%" Then
        '    txtValPorcentaje.Enabled = True
        '    txtValPorcentaje.Select()
        'Else
        '    txtValPorcentaje.DecimalValue = 0
        '    txtValPorcentaje.Enabled = False
        '    txtPrecioMN.Select()
        'End If
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        If ChReferencia.Checked = False Then
            For Each i As Record In dgvPrecios.Table.Records

                If i.GetValue("idPrecio") = cboTipo.SelectedValue Then
                    MessageBox.Show("El precio ya se encuentra en la canasta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            Next



            'If Not IsNothing(dgvPrecios.Table.CurrentRecord) Then
            If txtProveedor.Text.Trim.Length > 0 Then
                Me.dgvPrecios.Table.AddNewRecord.SetCurrent()
                Me.dgvPrecios.Table.AddNewRecord.BeginEdit()
                Me.dgvPrecios.Table.CurrentRecord.SetValue("tipoPrec", "1")
                Me.dgvPrecios.Table.CurrentRecord.SetValue("idPrecio", cboTipo.SelectedValue)
                Me.dgvPrecios.Table.CurrentRecord.SetValue("precio", cboTipo.Text)
                Me.dgvPrecios.Table.CurrentRecord.SetValue("modo", 0.0)
                Me.dgvPrecios.Table.CurrentRecord.SetValue("valVentamn", 0.0)
                Me.dgvPrecios.Table.CurrentRecord.SetValue("valVentame", 0.0)
                Me.dgvPrecios.Table.CurrentRecord.SetValue("utilidadmn", 0.0)
                Me.dgvPrecios.Table.CurrentRecord.SetValue("utilidadme", 0.0)
                Me.dgvPrecios.Table.CurrentRecord.SetValue("ivamn", 0.0)
                Me.dgvPrecios.Table.CurrentRecord.SetValue("ivame", 0.0)
                Me.dgvPrecios.Table.CurrentRecord.SetValue("precventamn", 0.0)
                Me.dgvPrecios.Table.CurrentRecord.SetValue("precventame", 0.0)
                Me.dgvPrecios.Table.AddNewRecord.EndEdit()

            Else
                MessageBox.Show("Agrege ultimas entradas")

            End If
        Else

            For Each i As Record In dgvPrecios.Table.Records

                If i.GetValue("idPrecio") = cboTipo.SelectedValue Then
                    MessageBox.Show("El precio ya se encuentra en la canasta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            Next

            Me.dgvPrecios.Table.AddNewRecord.SetCurrent()
            Me.dgvPrecios.Table.AddNewRecord.BeginEdit()
            Me.dgvPrecios.Table.CurrentRecord.SetValue("tipoPrec", "1")
            Me.dgvPrecios.Table.CurrentRecord.SetValue("idPrecio", cboTipo.SelectedValue)
            Me.dgvPrecios.Table.CurrentRecord.SetValue("precio", cboTipo.Text)
            Me.dgvPrecios.Table.CurrentRecord.SetValue("modo", 0.0)
            Me.dgvPrecios.Table.CurrentRecord.SetValue("valVentamn", 0.0)
            Me.dgvPrecios.Table.CurrentRecord.SetValue("valVentame", 0.0)
            Me.dgvPrecios.Table.CurrentRecord.SetValue("utilidadmn", 0.0)
            Me.dgvPrecios.Table.CurrentRecord.SetValue("utilidadme", 0.0)
            Me.dgvPrecios.Table.CurrentRecord.SetValue("ivamn", 0.0)
            Me.dgvPrecios.Table.CurrentRecord.SetValue("ivame", 0.0)
            Me.dgvPrecios.Table.CurrentRecord.SetValue("precventamn", 0.0)
            Me.dgvPrecios.Table.CurrentRecord.SetValue("precventame", 0.0)
            Me.dgvPrecios.Table.AddNewRecord.EndEdit()
        End If
    End Sub

    Private Sub dgvPrecios_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvPrecios.TableControlCellClick

    End Sub

    Private Sub dgvPrecios_TableControlCurrentCellChanged(sender As Object, e As GridTableControlEventArgs) Handles dgvPrecios.TableControlCurrentCellChanged
        Dim cc As GridCurrentCell = dgvPrecios.TableControl.CurrentCell
        cc.ConfirmChanges()

        If Not IsNothing(cc) Then
            Select Case cc.ColIndex
                Case 4, 1
                    If ChReferencia.Checked = False Then
                        CalculoprecioVentaGrid(dgvPrecios.Table.CurrentRecord)
                    Else

                    End If

                Case 11

                    Dim colMN As Decimal = CDec(dgvPrecios.TableModel(cc.RowIndex, cc.ColIndex).CellValue)
                    '      Dim colME As Decimal = CDec(Me.dgvPrecios.Table.CurrentRecord.GetValue("precventamn"))
                    Dim colME = colMN / TmpTipoCambio

                    Me.dgvPrecios.Table.CurrentRecord.SetValue("precventame", colME.ToString("N2"))

                Case 12

                    Dim colME As Decimal = CDec(dgvPrecios.TableModel(cc.RowIndex, cc.ColIndex).CellValue)
                    '      Dim colME As Decimal = CDec(Me.dgvPrecios.Table.CurrentRecord.GetValue("precventamn"))
                    Dim colMN = colME * TmpTipoCambio

                    Me.dgvPrecios.Table.CurrentRecord.SetValue("precventamn", colMN.ToString("N2"))


            End Select
        End If

        '        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        'Dim cc As GridCurrentCell = dgvPrecios.TableControl.CurrentCell
        'cc.ConfirmChanges()

        'If Not IsNothing(cc) Then
        '    Select Case cc.ColIndex
        '        Case 4, 1
        '            If ChReferencia.Checked = False Then
        '                CalculoprecioVentaGrid(dgvPrecios.Table.CurrentRecord)
        '            Else

        '            End If

        '        Case 11

        '            Dim colME As Decimal = CDec(dgvPrecios.TableModel(cc.RowIndex, cc.ColIndex).CellValue)
        '            '      Dim colME As Decimal = CDec(Me.dgvPrecios.Table.CurrentRecord.GetValue("precventamn"))
        '            colME = colME / TmpTipoCambio

        '            Me.dgvPrecios.Table.CurrentRecord.SetValue("precventame", colME.ToString("N2"))
        '    End Select
        'End If
        'If Not IsNothing(Me.dgvPrecios.Table.CurrentRecord) Then
        '    Select Case cc.ColIndex
        '        Case 4, 1
        '            If ChReferencia.Checked = False Then
        '                CalculoprecioVentaGrid(dgvPrecios.Table.CurrentRecord)
        '            Else

        '            End If

        '    End Select
        'End If
    End Sub


    Private Sub dgvPrecios_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvPrecios.TableControlCurrentCellEditingComplete
        'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        'If Not IsNothing(Me.dgvPrecios.Table.CurrentRecord) Then
        '    Select Case ColIndex
        '        Case 4, 1
        '            If ChReferencia.Checked = False Then
        '                CalculoprecioVentaGrid(dgvPrecios.Table.CurrentRecord)
        '            Else

        '            End If

        '        Case 11
        '            Dim colME As Decimal = CDec(Me.dgvPrecios.Table.CurrentRecord.GetValue("precventamn"))
        '            colME = colME / TmpTipoCambio

        '            Me.dgvPrecios.Table.CurrentRecord.SetValue("precventame", colME.ToString("N2"))
        '    End Select
        'End If
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Close()
    End Sub

    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            If dgvPrecios.Table.Records.Count > 0 Then
                If ChReferencia.Checked = False Then
                    If txtProveedor.Text.Trim.Length > 0 Then
                        Grabar()
                    Else
                        MessageBoxAdv.Show("Debe seleccionar una ultima entrada!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Else
                    Grabar()
                End If

            Else
                MessageBoxAdv.Show("Ingrese al menos un precio a la canasta!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBoxAdv.Show(ex.Message)
        End Try

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click
        If Not IsNothing(Me.dgvPrecios.Table.CurrentRecord) Then
            Me.dgvPrecios.Table.CurrentRecord.Delete()
        End If
    End Sub

    Private Sub dgvPrecios_TableControlCurrentCellKeyPress(sender As Object, e As GridTableControlKeyPressEventArgs) Handles dgvPrecios.TableControlCurrentCellKeyPress

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label7_Click_1(sender As Object, e As EventArgs) Handles Label7.Click
        '  Dim f As New frmUltimasCompras
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        datos.Clear()
        With frmUltimasCompras
            .txtItem.Text = txtProducto.Text
            .txtItem.ValueMember = txtProducto.Tag
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            If datos.Count > 0 Then
                txtfecha.Text = datos(0).Cuenta
                txtPrecUNit.DecimalValue = datos(0).PMmn
                txtPrecUNitme.DecimalValue = datos(0).PMme

                Select Case txtGrav.Text
                    Case 1
                        If datos(0).TasaIva > 0 Then
                            txtPUconIVAMN.DecimalValue = (CDec(datos(0).PMmn) * CDec(datos(0).TasaIva)) + txtPrecUNit.DecimalValue
                            txtPUconIVAME.DecimalValue = (CDec(datos(0).PMme) * CDec(datos(0).TasaIva)) + txtPrecUNitme.DecimalValue
                        Else
                            txtPUconIVAMN.DecimalValue = txtPrecUNit.DecimalValue
                            txtPUconIVAME.DecimalValue = txtPrecUNitme.DecimalValue
                        End If

                    Case 2
                        txtPUconIVAMN.DecimalValue = txtPrecUNit.DecimalValue
                        txtPUconIVAME.DecimalValue = txtPrecUNitme.DecimalValue
                End Select



                'txtValorEntrada.DecimalValue = datos(0).ValCompraMN
                'txtValorEntradame.DecimalValue = datos(0).ValCompraME
                txtPrecCompra.DecimalValue = datos(0).Montomn
                txtPrecComprame.DecimalValue = datos(0).Montome
                txtProveedor.Text = datos(0).NomProceso

                dgvPrecios.Visible = True
            End If
        End With
        'f.txtItem.Text = txtProducto.Text
        'f.txtItem.ValueMember = txtProducto.Tag
        'f.StartPosition = FormStartPosition.CenterParent
        'f.ShowDialog()
    End Sub

    Private Sub ChReferencia_CheckedChanged(sender As Object, e As EventArgs) Handles ChReferencia.CheckedChanged
        If ChReferencia.Checked = True Then
            Label7.Visible = False
            dgvPrecios.Visible = True
        Else
            Label7.Visible = True
            dgvPrecios.Visible = False
        End If
    End Sub

    Private Sub dgvPrecios_TableControlCurrentCellChanging(sender As Object, e As GridTableControlCancelEventArgs) Handles dgvPrecios.TableControlCurrentCellChanging

    End Sub

    Private Sub dgvPrecios_TableControlCurrentCellActivating(sender As Object, e As GridTableControlCurrentCellActivatingEventArgs) Handles dgvPrecios.TableControlCurrentCellActivating

    End Sub

    Private Sub ChPrecioDolares_OnChange(sender As Object, e As EventArgs) Handles ChPrecioDolares.OnChange
        If ChPrecioDolares.Checked = True Then
            ChPrecioSoles.Checked = False
            dgvPrecios.TableDescriptor.Columns("precventamn").Width = 0
            dgvPrecios.TableDescriptor.Columns("precventame").Width = 100
        ElseIf ChPrecioDolares.Checked = False Then

        End If
    End Sub

    Private Sub ChPrecioSoles_OnChange(sender As Object, e As EventArgs) Handles ChPrecioSoles.OnChange
        If ChPrecioSoles.Checked = True Then
            ChPrecioDolares.Checked = False
            dgvPrecios.TableDescriptor.Columns("precventamn").Width = 100
            dgvPrecios.TableDescriptor.Columns("precventame").Width = 0
        ElseIf ChPrecioSoles.Checked = False Then

        End If
    End Sub
End Class