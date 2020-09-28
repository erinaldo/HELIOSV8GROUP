Imports Helios.Cont.Business.Entity
Imports Helios.General
'Imports Helios.Planilla.Business.Entity

Imports Helios.Cont.WCFService.ServiceAccess
'Imports Helios.Planilla.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Public Class frmAsignaciondeServicios

#Region "Constructor"

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        GridCFGDetetail(dgvItemsNoasignados)
        GridCFGDetetail(dgvAsientosNoAsignados)
        ' Add any initialization after the InitializeComponent() call.

    End Sub

#End Region

    

#Region "Metodos"


    
    Public Sub GrabarGastoCostoLibro()

        Dim objeto As New documentoLibroDiarioDetalle
        Dim Lista As New List(Of documentoLibroDiarioDetalle)
        Dim documentoCompraDetalleSA As New documentoLibroDiarioSA

        For Each r As Record In dgvAsientosNoAsignados.Table.Records
            objeto = New documentoLibroDiarioDetalle

            If r.GetValue("valBonif") = "S" Then

                objeto.idDocumento = r.GetValue("idDocumento")
                objeto.secuencia = r.GetValue("secuencia")
                If cboTipoCosteo.Text = "COSTOS" Then
                    objeto.tipoCosto = "PC"
                ElseIf cboTipoCosteo.Text = "GASTOS" Then
                    objeto.tipoCosto = "PG"
                End If
                Lista.Add(objeto)





            End If
        Next

        documentoCompraDetalleSA.EnvioCostoGastoLibro(Lista)

        GetItemsAsientosNoAsignados()

    End Sub


    Public Sub GrabarGastoCosto()

        Dim objeto As New documentocompradetalle
        Dim Lista As New List(Of documentocompradetalle)
        Dim documentoCompraDetalleSA As New DocumentoCompraDetalleSA

        For Each r As Record In dgvItemsNoasignados.Table.Records
            objeto = New documentocompradetalle

            If r.GetValue("valBonif") = "S" Then

                objeto.idDocumento = r.GetValue("idDocumento")
                objeto.secuencia = r.GetValue("secuencia")
                If cboTipoCosteo.Text = "COSTOS" Then
                    objeto.tipoCosto = "PC"
                ElseIf cboTipoCosteo.Text = "GASTOS" Then
                    objeto.tipoCosto = "PG"
                End If
                Lista.Add(objeto)





            End If
        Next

        documentoCompraDetalleSA.EnvioDeServiciosAProduccion(Lista)

        ListaCompraDeServicios()

    End Sub

    'Private Sub GetItemsNoAsignadosFinanzas()
    '    Dim DocumentoCajaSA As New DocumentoCajaSA

    '    DocumentoCajaSA = New DocumentoCajaSA()
    '    Dim dt As New DataTable

    '    dt.Columns.Add("idDocumento")
    '    dt.Columns.Add("movimientoCaja")
    '    dt.Columns.Add("fechaCobro")
    '    dt.Columns.Add("entidadFinanciera")
    '    dt.Columns.Add("tipoDocPago")
    '    dt.Columns.Add("numeroDoc")
    '    dt.Columns.Add("moneda")
    '    dt.Columns.Add("montoSoles")
    '    dt.Columns.Add("montoUsd")
    '    dt.Columns.Add("idCosto")
    '    dt.Columns.Add("NombreProyectoGeneral")
    '    dt.Columns.Add("idSubProyecto")
    '    dt.Columns.Add("Subproyecto")
    '    dt.Columns.Add("idEDT")
    '    dt.Columns.Add("edt")
    '    dt.Columns.Add("tipoCosto")
    '    dt.Columns.Add("idElemento")
    '    dt.Columns.Add("Elemento")
    '    dt.Columns.Add("abrev")
    '    dt.Columns.Add("glosa")
    '    dt.Columns.Add("fechaTrabajo")
    '    dt.Columns.Add("secuencia")
    '    dt.Columns.Add("cuentaCosteo")

    '    Dim lista = DocumentoCajaSA.GetFinanzasParaCosteoGasto(New documentoCaja With {.idEmpresa = Gempresas.IdEmpresaRuc,
    '                                                                                   .idEstablecimiento = GEstableciento.IdEstablecimiento})


    '    For Each i In lista


    '        dt.Rows.Add(i.idDocumento,
    '                    i.movimientoCaja,
    '                    i.fechaCobro,
    '                    i.entidadFinanciera,
    '                    i.tipoDocPago,
    '                    i.numeroDoc,
    '                    i.moneda, i.montoSoles, i.montoUsd,
    '                    Nothing, Nothing, Nothing, Nothing, i.idcosto,
    '                    i.nombreCosto, Nothing, Nothing, Nothing, i.tipoCosto,
    '                    i.glosa, DateTime.Now, i.idEstado, i.cuentaCosteo)
    '    Next

    '    dgFinanzas.DataSource = dt ' documentocajaSA.GetItemsNoAsignadosFinanzas(New documentoCaja With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento,
    '    '.asientoCosto = StatusAsientoCosto.AsientoPorConfirmar})
    'End Sub



    Public Sub GetItemsAsientosNoAsignados()
        Dim libroSA As New documentoLibroDiarioSA
        Dim dt As New DataTable
        dt.Columns.Add("idDocumento")
        dt.Columns.Add("secuencia")
        dt.Columns.Add("FechaDoc")
        dt.Columns.Add("TipoDoc")
        dt.Columns.Add("NumDoc")
        dt.Columns.Add("Moneda")
        dt.Columns.Add("cuenta")
        dt.Columns.Add("descripcionItem")
        dt.Columns.Add("importeMN")
        dt.Columns.Add("importeME")
        dt.Columns.Add("TipoOperacion")
        dt.Columns.Add("idCosto")
        dt.Columns.Add("NombreProyectoGeneral")
        dt.Columns.Add("idSubProyecto")
        dt.Columns.Add("Subproyecto")
        dt.Columns.Add("idEDT")
        dt.Columns.Add("edt")
        dt.Columns.Add("tipoCosto")
        dt.Columns.Add("idElemento")
        dt.Columns.Add("Elemento")
        dt.Columns.Add("abrev")
        dt.Columns.Add("fechaTrabajo")
        dt.Columns.Add("cuentaCosteo")

        dt.Columns.Add("chBonif", GetType(Boolean))
        dt.Columns.Add("valBonif", GetType(String))

        dt.Columns.Add("modulo", GetType(String))

        For Each i In libroSA.ListarAsientosManualesSinCosteo(New documentoLibroDiario With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                                                .fechaPeriodo = PeriodoGeneral})
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idDocumento
            dr(1) = i.secuencia
            dr(2) = i.fecha
            dr(3) = i.tipoDocumento
            dr(4) = i.nroDoc
            dr(5) = i.moneda
            dr(6) = i.cuenta
            dr(7) = i.descripcion

            If i.tipoAsiento = "D" Then
                dr(8) = i.importeMN
                dr(9) = i.importeME
            Else
                dr(8) = (i.importeMN) * -1
                dr(9) = (i.importeME) * -1
            End If


            dr(10) = i.operacion
            dr(11) = 0
            dr(12) = ""
            dr(13) = Nothing
            dr(14) = Nothing
            dr(15) = Nothing
            dr(16) = Nothing
            dr(17) = Nothing
            dr(18) = Nothing
            dr(19) = Nothing
            dr(20) = Nothing
            'If i.tipoCosto = "PC" Then
            '    dr(20) = Nothing
            'ElseIf i.tipoCosto = "PG" Then
            '    dr(20) = "HG"
            'End If

            dr(21) = DateTime.Now
            dr(22) = Nothing

            dr(23) = False
            dr(24) = "N"
            dr(25) = i.modulo

            dt.Rows.Add(dr)
        Next



        dgvAsientosNoAsignados.DataSource = dt 'compraSA.ListaRecursosCosto(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento,
        '                                                                                        .fechaContable = PeriodoGeneral})
        dgvAsientosNoAsignados.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended

    End Sub


    Public Sub ListaCompraDeServicios()
        Dim compraSA As New DocumentoCompraSA
        Dim dt As New DataTable
        dt.Columns.Add("idDocumento")
        dt.Columns.Add("secuencia")
        dt.Columns.Add("proveedor")
        dt.Columns.Add("FechaDoc")
        dt.Columns.Add("TipoDoc")
        dt.Columns.Add("Serie")
        dt.Columns.Add("NumDoc")
        dt.Columns.Add("Moneda")
        dt.Columns.Add("idItem")
        dt.Columns.Add("descripcionItem")
        dt.Columns.Add("tipoExistencia")
        dt.Columns.Add("destino")
        dt.Columns.Add("unidad1")
        dt.Columns.Add("monto1")
        dt.Columns.Add("montokardex")
        dt.Columns.Add("montokardexUS")
        dt.Columns.Add("TipoOperacion")
        dt.Columns.Add("idPadreDTCompra")

        dt.Columns.Add("fechaTrabajo")

        dt.Columns.Add("montouso")
        dt.Columns.Add("montosaldo")

        dt.Columns.Add("chBonif", GetType(Boolean))
        dt.Columns.Add("valBonif", GetType(String))


        For Each i In compraSA.ServiciosSinCosteo(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento,
                                                                                                .fechaContable = PeriodoGeneral})
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idDocumento
            dr(1) = i.secuencia

            dr(2) = i.NombreProveedor

            dr(3) = i.FechaDoc
            dr(4) = i.TipoDoc
            dr(5) = i.Serie
            dr(6) = i.NumDoc
            dr(7) = i.Moneda
            dr(8) = i.idItem
            dr(9) = i.descripcionItem
            dr(10) = i.tipoExistencia

            dr(11) = i.destino
            dr(12) = "UND" 'i.unidad1
            dr(13) = i.monto1
            dr(14) = i.montokardex
            dr(15) = i.montokardexUS
            dr(16) = i.TipoOperacion
            dr(17) = i.idPadreDTCompra

            dr(18) = DateTime.Now

            dr(19) = CDec(0.0)
            dr(20) = CDec(0.0)

            dr(21) = False
            dr(22) = "N"


            'Me.dgvCompra.Table.CurrentRecord.SetValue("chBonif", False)
            'Me.dgvCompra.Table.CurrentRecord.SetValue("valBonif", "N")

            dt.Rows.Add(dr)
        Next

        dgvItemsNoasignados.DataSource = dt 'compraSA.ListaRecursosCosto(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento,
        '                                                                                        .fechaContable = PeriodoGeneral})
        dgvItemsNoasignados.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended

    End Sub

    Sub GridCFGDetetail(grid As GridGroupingControl)
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
#End Region

    Private Sub frmAsignaciondeServicios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListaCompraDeServicios()
        GetItemsAsientosNoAsignados()
        'GetItemsNoAsignadosFinanzas()
    End Sub

    Private Sub dgvItemsNoasignados_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvItemsNoasignados.TableControlCellClick

    End Sub

    Private chk As Boolean, check As Boolean = False
    Private ht As New ArrayList()
    Private Sub dgvItemsNoasignados_TableControlCheckBoxClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvItemsNoasignados.TableControlCheckBoxClick
        Dim style As GridTableCellStyleInfo = DirectCast(e.TableControl.GetTableViewStyleInfo(e.Inner.RowIndex, e.Inner.ColIndex), GridTableCellStyleInfo)
        Dim el As Element = Me.dgvItemsNoasignados.Table.GetInnerMostCurrentElement()

        Dim colindexVal As Integer = style.CellIdentity.ColIndex

        Dim RowIndex2 As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.RowIndex
        If RowIndex2 > -1 Then
            Select Case colindexVal
                Case 18





                Case 22

                    '      Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(e.Inner.RowIndex, e.Inner.ColIndex), GridTableCellStyleInfo)
                    If style.Enabled Then
                        Dim column As Integer = Me.dgvItemsNoasignados.TableModel.NameToColIndex("chBonif")
                        ' Console.WriteLine("CheckBoxClicked")
                        '   Dim s = e.TableControl.Table.CurrentRecord.GetValue("colModVenta")
                        If style.Enabled AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell Then
                            chk = CBool(Me.dgvItemsNoasignados.TableModel(style.TableCellIdentity.RowIndex, column).CellValue)

                            e.TableControl.BeginUpdate()

                            e.TableControl.EndUpdate(True)
                        End If
                        If style.Enabled AndAlso (style.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell OrElse style.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell) AndAlso style.TableCellIdentity.Column.Name = "chBonif" Then
                            Dim currentRecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
                            Dim curStatus As Boolean = Boolean.Parse(style.Text)
                            e.TableControl.BeginUpdate()

                            If curStatus Then
                                '   CheckBoxValue = False
                            End If
                            If curStatus = True Then
                                Dim RowIndex As Integer = e.Inner.RowIndex
                                Dim ColIndex As Integer = e.Inner.ColIndex
                                '      MsgBox(False)
                                Me.dgvItemsNoasignados.TableModel(RowIndex, 23).CellValue = "N" ' curStatus

                                '******************************************************************

                            Else
                                Dim RowIndex As Integer = e.Inner.RowIndex
                                Dim ColIndex As Integer = e.Inner.ColIndex
                                '     MsgBox(True)
                                Me.dgvItemsNoasignados.TableModel(RowIndex, 23).CellValue = "S"


                            End If
                            e.TableControl.EndUpdate()
                            If ht.Contains(curStatus) AndAlso (Not ht.Contains((Not curStatus))) Then
                            ElseIf Not ht.Contains(curStatus) Then
                            End If
                            ht.Clear()
                        End If
                    End If
            End Select

            Me.dgvItemsNoasignados.TableControl.Refresh()

        End If
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Dim conteo As Integer = 0


        If TabControl1.SelectedIndex = 0 Then

            If dgvItemsNoasignados.Table.Records.Count > 0 Then



                For Each r As Record In dgvItemsNoasignados.Table.Records


                    If r.GetValue("valBonif") = "S" Then

                       
                        conteo += 1




                    End If
                Next

                If conteo > 0 Then
                    GrabarGastoCosto()

                Else
                    MessageBox.Show("Debe Confirmar al menso un documento!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Else
                MessageBox.Show("No hay servicios disponibles!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        ElseIf TabControl1.SelectedIndex = 1 Then

            If dgvAsientosNoAsignados.Table.Records.Count > 0 Then

                For Each r As Record In dgvAsientosNoAsignados.Table.Records


                    If r.GetValue("valBonif") = "S" Then


                        conteo += 1




                    End If
                Next

                If conteo > 0 Then
                    GrabarGastoCostoLibro()

                Else
                    MessageBox.Show("Debe Confirmar al menso un documento!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If




            Else
                MessageBox.Show("No hay Asientos Manuales disponibles!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        End If
    End Sub

    Private Sub dgvAsientosNoAsignados_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvAsientosNoAsignados.TableControlCellClick

    End Sub

    Private Sub dgvAsientosNoAsignados_TableControlCheckBoxClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvAsientosNoAsignados.TableControlCheckBoxClick
        Dim style As GridTableCellStyleInfo = DirectCast(e.TableControl.GetTableViewStyleInfo(e.Inner.RowIndex, e.Inner.ColIndex), GridTableCellStyleInfo)
        Dim el As Element = Me.dgvAsientosNoAsignados.Table.GetInnerMostCurrentElement()

        Dim colindexVal As Integer = style.CellIdentity.ColIndex

        Dim RowIndex2 As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.RowIndex
        If RowIndex2 > -1 Then
            Select Case colindexVal
                Case 18





                Case 24

                    '      Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(e.Inner.RowIndex, e.Inner.ColIndex), GridTableCellStyleInfo)
                    If style.Enabled Then
                        Dim column As Integer = Me.dgvAsientosNoAsignados.TableModel.NameToColIndex("chBonif")
                        ' Console.WriteLine("CheckBoxClicked")
                        '   Dim s = e.TableControl.Table.CurrentRecord.GetValue("colModVenta")
                        If style.Enabled AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell Then
                            chk = CBool(Me.dgvAsientosNoAsignados.TableModel(style.TableCellIdentity.RowIndex, column).CellValue)

                            e.TableControl.BeginUpdate()

                            e.TableControl.EndUpdate(True)
                        End If
                        If style.Enabled AndAlso (style.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell OrElse style.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell) AndAlso style.TableCellIdentity.Column.Name = "chBonif" Then
                            Dim currentRecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
                            Dim curStatus As Boolean = Boolean.Parse(style.Text)
                            e.TableControl.BeginUpdate()

                            If curStatus Then
                                '   CheckBoxValue = False
                            End If
                            If curStatus = True Then
                                Dim RowIndex As Integer = e.Inner.RowIndex
                                Dim ColIndex As Integer = e.Inner.ColIndex
                                '      MsgBox(False)
                                Me.dgvAsientosNoAsignados.TableModel(RowIndex, 25).CellValue = "N" ' curStatus

                                '******************************************************************

                            Else
                                Dim RowIndex As Integer = e.Inner.RowIndex
                                Dim ColIndex As Integer = e.Inner.ColIndex
                                '     MsgBox(True)
                                Me.dgvAsientosNoAsignados.TableModel(RowIndex, 25).CellValue = "S"


                            End If
                            e.TableControl.EndUpdate()
                            If ht.Contains(curStatus) AndAlso (Not ht.Contains((Not curStatus))) Then
                            ElseIf Not ht.Contains(curStatus) Then
                            End If
                            ht.Clear()
                        End If
                    End If
            End Select

            Me.dgvAsientosNoAsignados.TableControl.Refresh()

        End If
    End Sub
End Class