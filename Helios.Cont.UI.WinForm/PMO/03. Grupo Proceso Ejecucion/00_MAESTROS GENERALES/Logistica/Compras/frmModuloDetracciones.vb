Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class frmModuloDetracciones

#Region "Attributes"
    Dim compraSA As New DocumentoCompraSA
    Dim listaMeses As New List(Of MesesAnio)
    Dim selectionColl As New Hashtable()
    Dim hoveredIndex As Integer = 0
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridPequeño(dgvDetracciones, False)
        Meses()
    End Sub
#End Region

#Region "Methods"
    Public Sub IsMouseHover(row As Integer, col As Integer, isHover As Boolean, GGC As GridGroupingControl)
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

    Private Sub UpdateDataDetraccion(be As documentocompra)
        Dim compra As New documentocompra

        compra = New documentocompra With {.idDocumento = be.idDocumento,
                                           .fechaConstancia = be.fechaConstancia,
                                           .nroConstancia = be.nroConstancia,
                                           .periodoTributo = be.periodoTributo
                                          }

        compraSA.UpdateDataDetraccion(compra)
        MessageBox.Show("data actualizada!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub getDetracciones(be As documentocompra)
        Dim dt As New DataTable()
        dt.Columns.Add("idDocumento")
        dt.Columns.Add("fecha")
        dt.Columns.Add("tipoDoc")
        dt.Columns.Add("serie")
        dt.Columns.Add("numero")
        dt.Columns.Add("razon")
        dt.Columns.Add("importe")
        dt.Columns.Add("importeME")
        dt.Columns.Add("periodoTributo")
        dt.Columns.Add("fechaConstancia")
        dt.Columns.Add("nroConstancia")
        dt.Columns.Add("confirmar")

        For Each i In compraSA.GetListadoDetracciones(be)
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idDocumento
            dr(1) = i.fechaDoc
            dr(2) = i.tipoDoc
            dr(3) = i.serie
            dr(4) = i.numeroDoc
            dr(5) = i.nombreProveedor
            dr(6) = i.importeTotal
            dr(7) = i.importeUS
            dr(8) = i.periodoTributo
            If IsNothing(i.periodoTributo) Then
                dr(9) = String.Empty
            Else
                dr(9) = i.fechaConstancia.GetValueOrDefault
            End If
            dr(10) = i.nroConstancia
            If Not IsNothing(i.nroConstancia) Then
                dr(11) = True
            Else
                dr(11) = False
            End If

            dt.Rows.Add(dr)
        Next
        dgvDetracciones.DataSource = dt

    End Sub

    Private Sub Meses()
        Dim empresaAnioSA As New empresaPeriodoSA

        cboAnio.DisplayMember = "periodo"
        cboAnio.ValueMember = "periodo"
        cboAnio.DataSource = empresaAnioSA.GetListar_empresaPeriodo(New empresaPeriodo With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento})
        cboAnio.Text = AnioGeneral

        Dim obj As New MesesAnio
        For x = 1 To 12
            obj = New MesesAnio
            obj.Codigo = String.Format("{0:00}", CInt(x))
            obj.Mes = New DateTime(AnioGeneral, x, 1).ToString("MMMM")
            listaMeses.Add(obj)
        Next x

        cboMes.DisplayMember = "Mes"
        cboMes.ValueMember = "Codigo"
        cboMes.DataSource = listaMeses
        cboMes.SelectedValue = MesGeneral
    End Sub
#End Region

#Region "Events"
    Private Sub dgvDetracciones_TableControlCheckBoxClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvDetracciones.TableControlCheckBoxClick
        Me.Cursor = Cursors.WaitCursor
        Dim obj As New documentocompra
        Dim RowIndex As Integer = e.Inner.RowIndex

        If RowIndex > -1 Then
            e.TableControl.CurrentCell.EndEdit()
            e.TableControl.Table.TableDirty = True
            e.TableControl.Table.EndEdit()

            Dim valCheck = Me.dgvDetracciones.TableModel(RowIndex, 12).CellValue
            Select Case valCheck
                Case "False" 'TRUE

                    Dim nroconst = Me.dgvDetracciones.TableModel(RowIndex, 11).CellValue ' dgvDetracciones.Table.CurrentRecord.GetValue("nroConstancia")
                    Dim periodotri = Me.dgvDetracciones.TableModel(RowIndex, 9).CellValue ' dgvDetracciones.Table.CurrentRecord.GetValue("periodoTributo")
                    Dim fechacons = Me.dgvDetracciones.TableModel(RowIndex, 10).CellValue ' dgvDetracciones.Table.CurrentRecord.GetValue("fechaConstancia")

                    obj.idDocumento = Me.dgvDetracciones.TableModel(RowIndex, 1).CellValue ' Val(dgvDetracciones.Table.CurrentRecord.GetValue("idDocumento"))

                    If IsDate(fechacons) Then
                        obj.fechaConstancia = CType(fechacons, DateTime)
                    Else
                        MessageBox.Show("Indicar la fecha de constancia.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.dgvDetracciones.TableModel(RowIndex, 12).CellValue = True
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    End If

                    If nroconst.ToString.Trim.Length > 0 Then
                        obj.nroConstancia = nroconst
                    Else
                        MessageBox.Show("Indicar el nro de constancia.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.dgvDetracciones.TableModel(RowIndex, 12).CellValue = True
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    End If

                    If periodotri.ToString.Trim.Length > 0 Then

                        If Mid(periodotri, 1, 2) = "01" Or Mid(periodotri, 1, 2) = "02" Or Mid(periodotri, 1, 2) = "03" Or Mid(periodotri, 1, 2) = "04" Or
                            Mid(periodotri, 1, 2) = "05" Or Mid(periodotri, 1, 2) = "06" Or Mid(periodotri, 1, 2) = "07" Or Mid(periodotri, 1, 2) = "08" Or
                            Mid(periodotri, 1, 2) = "09" Or Mid(periodotri, 1, 2) = "10" Or Mid(periodotri, 1, 2) = "11" Or Mid(periodotri, 1, 2) = "12" Then

                            obj.periodoTributo = periodotri

                        Else
                            MessageBox.Show("Indicar el periodo de detracción valido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Me.dgvDetracciones.TableModel(RowIndex, 12).CellValue = True
                            Me.Cursor = Cursors.Arrow
                            Exit Sub
                        End If




                    Else
                        MessageBox.Show("Indicar el periodo de detracción.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.dgvDetracciones.TableModel(RowIndex, 12).CellValue = True
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    End If

                    UpdateDataDetraccion(obj)
                    'MessageBox.Show(True)
                Case Else ' FALSE
                    obj.idDocumento = Val(Me.dgvDetracciones.TableModel(RowIndex, 1).CellValue)
                    obj.fechaConstancia = Nothing
                    obj.nroConstancia = Nothing
                    obj.periodoTributo = Nothing
                    UpdateDataDetraccion(obj)

                    Me.dgvDetracciones.TableModel(RowIndex, 9).CellValue = Nothing
                    Me.dgvDetracciones.TableModel(RowIndex, 10).CellValue = Nothing
                    Me.dgvDetracciones.TableModel(RowIndex, 11).CellValue = Nothing
                    Me.dgvDetracciones.TableModel(RowIndex, 12).CellValue = True
                    'MessageBox.Show(False)
            End Select
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvDetracciones_TableControlCurrentCellChanged(sender As Object, e As GridTableControlEventArgs) Handles dgvDetracciones.TableControlCurrentCellChanged
        Dim cc As GridCurrentCell = e.TableControl.CurrentCell

        If cc.Renderer.StyleInfo.CellType = "CheckBox" Then
            Console.WriteLine(e.TableControl.Table.CurrentRecord.Info)
            Dim dr As DataRowView = e.TableControl.Table.CurrentRecord.GetData()
        End If

    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Cursor = Cursors.WaitCursor
        getDetracciones(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento,
                                                   .fechaContable = String.Concat(cboMes.SelectedValue, "/", cboAnio.Text), .tieneDetraccion = "S"})
        Cursor = Cursors.Default
    End Sub

    'Private Sub dgvDetracciones_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvDetracciones.QueryCellStyleInfo
    '    If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
    '        ' && selectionColl.Count > 0)
    '        Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
    '        If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
    '            e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
    '            '.DeepSkyBlue;
    '            e.Style.TextColor = Color.Gray
    '            e.Style.CurrencyEdit.PositiveColor = Color.Gray
    '        End If

    '        dgvDetracciones.TableControl.Selections.Clear()
    '    End If
    'End Sub

    'Private Sub dgvDetracciones_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgvDetracciones.TableControlCellMouseHoverEnter
    '    IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgvDetracciones)
    'End Sub

    Private Sub frmModuloDetracciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub dgvDetracciones_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvDetracciones.TableControlCellClick

    End Sub

    Private Sub dgvDetracciones_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvDetracciones.QueryCellStyleInfo
        If Not IsNothing(e.TableCellIdentity.Column) Then
            Dim el As Syncfusion.Grouping.Element = e.TableCellIdentity.DisplayElement

            If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "periodoTributo")) Then

                If Me.dgvDetracciones.TableModel(e.TableCellIdentity.RowIndex, 12).CellValue = True Then
                    e.Style.[ReadOnly] = True
                    e.Style.BackColor = Color.Silver
                Else
                    e.Style.[ReadOnly] = False
                    e.Style.BackColor = Color.LightYellow
                End If

            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "fechaConstancia")) Then

                If Me.dgvDetracciones.TableModel(e.TableCellIdentity.RowIndex, 12).CellValue = True Then
                    e.Style.[ReadOnly] = True
                    e.Style.BackColor = Color.Silver
                Else
                    e.Style.[ReadOnly] = False
                    e.Style.BackColor = Color.LightYellow
                End If

            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "nroConstancia")) Then

                If Me.dgvDetracciones.TableModel(e.TableCellIdentity.RowIndex, 12).CellValue = True Then
                    e.Style.[ReadOnly] = True
                    e.Style.BackColor = Color.Silver

                Else
                    e.Style.[ReadOnly] = False
                    e.Style.BackColor = Color.LightYellow
                End If

            End If

            '

        End If
    End Sub

    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click
        Dim r As Record = dgvDetracciones.Table.CurrentRecord
        If r IsNot Nothing Then
            compraSA = New DocumentoCompraSA
            Dim codigoDocumento As Integer = Integer.Parse(r.GetValue("idDocumento"))
            compraSA.GetDetraccionChangeStateByDocumento(New documentocompra With {
                                                         .idDocumento = codigoDocumento,
                                                         .tieneDetraccion = "N"})
            dgvDetracciones.Table.CurrentRecord.Delete()
        Else
            MessageBoxAdv.Show("Debe seleccionar un fila", "Validar fila", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
#End Region

End Class