Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class UCAgenciaSucursal
#Region "Attributes"
    Dim agenciaSA As New establecimientoSA
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(dgCuentasFinancieras, True, False, 10.0F)
        getAgenciaFull()
    End Sub

#End Region

#Region "Methods"
    Private Sub getAgenciaFull()


        Dim listaAgencias = agenciaSA.ObtenerListaEstablecimientos(Gempresas.IdEmpresaRuc)

        Transporte.ListaAgencias = listaAgencias

        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("nombre")
        dt.Columns.Add("ubigeo")
        dt.Columns.Add("estado")
        dt.Columns.Add("predeterminado", GetType(Boolean))
        dt.Columns.Add("Baja", GetType(Boolean))

        Dim statusBaja As Boolean = False

        For Each i In Transporte.ListaAgencias
            If i.TipoEstab = "AG" Then
                statusBaja = False
            ElseIf i.TipoEstab = "AGI" Then
                statusBaja = True
            End If
            dt.Rows.Add(i.idCentroCosto, i.nombre, i.ubigeo, "activo", i.predeterminada, statusBaja)
        Next

        dgCuentasFinancieras.DataSource = dt
    End Sub

    Private Sub AgregarItem(agencia As centrocosto)
        With dgCuentasFinancieras.Table
            .AddNewRecord.SetCurrent()
            .AddNewRecord.BeginEdit()
            .CurrentRecord.SetValue("id", agencia.idCentroCosto)
            .CurrentRecord.SetValue("nombre", agencia.nombre)
            .CurrentRecord.SetValue("ubigeo", agencia.ubigeo)
            .CurrentRecord.SetValue("estado", "activo")
            .CurrentRecord.SetValue("predeterminado", agencia.predeterminada)
            .AddNewRecord.EndEdit()
            '  .TableDirty = True
        End With
    End Sub

    Private Sub ModificarItem(agencia As centrocosto)
        With dgCuentasFinancieras.Table
            .CurrentRecord.SetValue("id", agencia.idCentroCosto)
            .CurrentRecord.SetValue("nombre", agencia.nombre)
            .CurrentRecord.SetValue("ubigeo", agencia.ubigeo)
            .CurrentRecord.SetValue("estado", "activo")
            .CurrentRecord.SetValue("predeterminado", agencia.predeterminada)
        End With
        dgCuentasFinancieras.Refresh()
    End Sub

    Private chk As Boolean, check As Boolean = False
    Private ht As New ArrayList()
    Private Sub dgvCompra_TableControlCheckBoxClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgCuentasFinancieras.TableControlCheckBoxClick
        Dim style As GridTableCellStyleInfo = DirectCast(e.TableControl.GetTableViewStyleInfo(e.Inner.RowIndex, e.Inner.ColIndex), GridTableCellStyleInfo)
        Dim el As Element = Me.dgCuentasFinancieras.Table.GetInnerMostCurrentElement()

        Dim colindexVal As Integer = style.CellIdentity.ColIndex

        Dim RowIndex2 As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.RowIndex
        If RowIndex2 > -1 Then
            Select Case colindexVal
                'Case 18

                '    If style.Enabled Then
                '        Dim column As Integer = Me.dgCuentasFinancieras.TableModel.NameToColIndex("Baja")
                '        ' Console.WriteLine("CheckBoxClicked")
                '        '   Dim s = e.TableControl.Table.CurrentRecord.GetValue("colModVenta")
                '        If style.Enabled AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell Then
                '            chk = CBool(Me.dgCuentasFinancieras.TableModel(style.TableCellIdentity.RowIndex, column).CellValue)

                '            e.TableControl.BeginUpdate()

                '            e.TableControl.EndUpdate(True)
                '        End If
                '        If style.Enabled AndAlso (style.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell OrElse style.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell) AndAlso style.TableCellIdentity.Column.Name = "chPago" Then
                '            Dim currentRecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
                '            Dim curStatus As Boolean = Boolean.Parse(style.Text)
                '            e.TableControl.BeginUpdate()

                '            If curStatus Then
                '                '   CheckBoxValue = False
                '            End If
                '            If curStatus = True Then
                '                Dim RowIndex As Integer = e.Inner.RowIndex
                '                Dim ColIndex As Integer = e.Inner.ColIndex

                '                Me.dgCuentasFinancieras.TableModel(RowIndex, 19).CellValue = "No Pagado"

                '            Else
                '                Dim RowIndex As Integer = e.Inner.RowIndex
                '                Dim ColIndex As Integer = e.Inner.ColIndex

                '                Me.dgCuentasFinancieras.TableModel(RowIndex, 19).CellValue = "Pagado"



                '            End If
                '            e.TableControl.EndUpdate()
                '            If ht.Contains(curStatus) AndAlso (Not ht.Contains((Not curStatus))) Then
                '            ElseIf Not ht.Contains(curStatus) Then
                '            End If
                '            ht.Clear()
                '        End If
                '    End If
                '    'End If




                Case 6

                    '      Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(e.Inner.RowIndex, e.Inner.ColIndex), GridTableCellStyleInfo)
                    If style.Enabled Then
                        Dim column As Integer = Me.dgCuentasFinancieras.TableModel.NameToColIndex("Baja")
                        ' Console.WriteLine("CheckBoxClicked")
                        '   Dim s = e.TableControl.Table.CurrentRecord.GetValue("colModVenta")
                        If style.Enabled AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell Then
                            chk = CBool(Me.dgCuentasFinancieras.TableModel(style.TableCellIdentity.RowIndex, column).CellValue)

                            e.TableControl.BeginUpdate()

                            e.TableControl.EndUpdate(True)
                        End If
                        If style.Enabled AndAlso (style.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell OrElse style.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell) AndAlso style.TableCellIdentity.Column.Name = "Baja" Then
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
                                dgCuentasFinancieras.TableModel(RowIndex, 4).CellValue = "activo" ' curStatus

                                '******************************************************************
                                GetChangeStatusAgencia(RowIndex, "AG")

                            Else ' si es check de bonificacion esta en False: Entonces ->
                                Dim RowIndex As Integer = e.Inner.RowIndex
                                Dim ColIndex As Integer = e.Inner.ColIndex
                                '     MsgBox(True)
                                Me.dgCuentasFinancieras.TableModel(RowIndex, 4).CellValue = "Inactivo"

                                GetChangeStatusAgencia(RowIndex, "AGI")

                            End If
                            e.TableControl.EndUpdate()
                            If ht.Contains(curStatus) AndAlso (Not ht.Contains((Not curStatus))) Then
                            ElseIf Not ht.Contains(curStatus) Then
                            End If
                            ht.Clear()
                        End If
                    End If
            End Select
            Me.dgCuentasFinancieras.TableControl.Refresh()
        End If
    End Sub

    Private Sub dgCuentasFinancieras_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgCuentasFinancieras.TableControlCellClick

    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        Dim f As New FormCrearOrgnizacionNegocio()
        f.Manipulation = Entity.EntityState.Added
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        If f.Tag IsNot Nothing Then
            Dim c = CType(f.Tag, centrocosto)
            Transporte.ListaAgencias.Add(c)
            AgregarItem(c)
        End If
    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click
        Dim r As Record = dgCuentasFinancieras.Table.CurrentRecord
        If r IsNot Nothing Then
            Dim f As New FormCrearOrgnizacionNegocio(Integer.Parse(r.GetValue("id")))
            f.Manipulation = Entity.EntityState.Modified
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
            If f.Tag IsNot Nothing Then
                Dim c = CType(f.Tag, centrocosto)
                Transporte.ListaAgencias.Add(c)
                ModificarItem(c)
            End If
        Else
            MessageBox.Show("Debe seleccionar una agecia válida", "Seleccionar fila", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton3.Click
        Cursor = Cursors.WaitCursor
        Try
            getAgenciaFull()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
        Try
            Dim r As Record = dgCuentasFinancieras.Table.CurrentRecord
            If r IsNot Nothing Then
                Dim obj As New centrocosto With
                {
                .idCentroCosto = Integer.Parse(r.GetValue("id"))
                }

                agenciaSA.PredeterminarAgencia(obj)
                MessageBox.Show("Datos configurados!", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information)

                GEstableciento = New GEstablecimiento
                GEstableciento.IdEstablecimiento = Integer.Parse(r.GetValue("id"))
                GEstableciento.NombreEstablecimiento = r.GetValue("nombre")
                GEstableciento.Ubigeo = r.GetValue("ubigeo")

                For Each i In dgCuentasFinancieras.Table.Records
                    i.SetValue("predeterminado", False)
                Next
                r.SetValue("predeterminado", True)
            Else
                MessageBox.Show("Debe inidicar una agencia", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub GetChangeStatusAgencia(rowIndex As Integer, tipo As String)
        If rowIndex <> -1 Then
            Dim idAgencia = Integer.Parse(Me.dgCuentasFinancieras.TableModel(rowIndex, 1).CellValue)
            Dim obj As New centrocosto With
            {
            .idCentroCosto = idAgencia,
            .TipoEstab = tipo
            }
            agenciaSA.ChangeEstatusAgencia(obj)
            dgCuentasFinancieras.Refresh()
            getAgenciaFull()
        End If
    End Sub

#End Region
End Class
