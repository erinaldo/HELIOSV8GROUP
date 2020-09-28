Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class UCMaestroActivo
#Region "Attributes"
    Public Property FormPurchase As FormTablaPrincipalTransportes
#End Region

#Region "Constructors"
    Public Sub New(formventaNueva As FormTablaPrincipalTransportes)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(GridVehiculo, True, False, 10.0F)

        FormPurchase = formventaNueva

    End Sub
#End Region

#Region "Methods"
    Public Sub GetVehiculos()
        Dim activoSA As New ActivosFijosSA
        Dim distribucionsa As New distribucionInfraestructuraSA

        Dim dt As New DataTable()
        dt.Columns.Add("id")
        dt.Columns.Add("activo")
        dt.Columns.Add("anio")
        dt.Columns.Add("placa")
        dt.Columns.Add("modelo")
        dt.Columns.Add("Baja", GetType(Boolean))
        dt.Columns.Add("control")

        Dim statusActivo As Boolean = False

        For Each i In activoSA.GetListar_activosFijosEmpresa(New Business.Entity.activosFijos With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento})

            If i.tipoActivo = "1" Then
                statusActivo = False
            Else
                statusActivo = True
            End If

            Dim conteo = distribucionsa.getDistribucionInfraestructura(New distribucionInfraestructura With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                          .tipo = "C",
                                                          .idActivo = i.idActivo}).Count


            dt.Rows.Add(i.idActivo, i.descripcionItem, i.anio, i.nroSeriePlaca, i.modelo, statusActivo, conteo)
        Next

        GridVehiculo.DataSource = dt
    End Sub
#End Region

#Region "Events"
    Private chk As Boolean, check As Boolean = False
    Private ht As New ArrayList()
    Private Sub dgvCompra_TableControlCheckBoxClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridVehiculo.TableControlCheckBoxClick
        Dim style As GridTableCellStyleInfo = DirectCast(e.TableControl.GetTableViewStyleInfo(e.Inner.RowIndex, e.Inner.ColIndex), GridTableCellStyleInfo)
        Dim el As Element = Me.GridVehiculo.Table.GetInnerMostCurrentElement()

        Dim colindexVal As Integer = style.CellIdentity.ColIndex

        Dim RowIndex2 As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.RowIndex
        If RowIndex2 > -1 Then
            Select Case colindexVal

                Case 7

                    '      Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(e.Inner.RowIndex, e.Inner.ColIndex), GridTableCellStyleInfo)
                    If style.Enabled Then
                        Dim column As Integer = Me.GridVehiculo.TableModel.NameToColIndex("Baja")
                        ' Console.WriteLine("CheckBoxClicked")
                        '   Dim s = e.TableControl.Table.CurrentRecord.GetValue("colModVenta")
                        If style.Enabled AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell Then
                            chk = CBool(Me.GridVehiculo.TableModel(style.TableCellIdentity.RowIndex, column).CellValue)

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
                                '******************************************************************
                                GetChangeStatusAgencia(RowIndex, "1")

                            Else ' si es check de bonificacion esta en False: Entonces ->
                                Dim RowIndex As Integer = e.Inner.RowIndex
                                Dim ColIndex As Integer = e.Inner.ColIndex
                                '     MsgBox(True)
                                GetChangeStatusAgencia(RowIndex, "0")

                            End If
                            e.TableControl.EndUpdate()
                            If ht.Contains(curStatus) AndAlso (Not ht.Contains((Not curStatus))) Then
                            ElseIf Not ht.Contains(curStatus) Then
                            End If
                            ht.Clear()
                        End If
                    End If
            End Select
            Me.GridVehiculo.TableControl.Refresh()
        End If
    End Sub

    Private Sub GetChangeStatusAgencia(rowIndex As Integer, tipo As String)
        Dim activoSA As New ActivosFijosSA
        If rowIndex <> -1 Then
            Dim idActivo = Integer.Parse(Me.GridVehiculo.TableModel(rowIndex, 1).CellValue)
            Dim obj As New activosFijos With
            {
            .idActivo = idActivo,
            .tipoActivo = tipo
            }
            activoSA.ChangeEstatusActivo(obj)
            GridVehiculo.Refresh()
            GetVehiculos()
        End If
    End Sub

    Private Sub BunifuFlatButton11_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton11.Click
        Dim F As New FormCrearActivo()
        F.Manipulation = Entity.EntityState.Added
        F.StartPosition = FormStartPosition.CenterParent
        F.ShowDialog()
        GetVehiculos()
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        Dim r As Record = GridVehiculo.Table.CurrentRecord
        Try
            If r IsNot Nothing Then
                Dim F As New FormCrearActivo(Integer.Parse(r.GetValue("id")))
                F.Manipulation = Entity.EntityState.Modified
                F.StartPosition = FormStartPosition.CenterParent
                F.ShowDialog()
                GetVehiculos()
            Else
                MessageBox.Show("Debe seleccionar un vehiculo valido!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub GridGroupingControl1_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridVehiculo.TableControlCellClick

    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
        If (Not IsNothing(GridVehiculo.Table.CurrentRecord)) Then

            Me.Visible = False

            If FormPurchase.UCCrearBus IsNot Nothing Then

                FormPurchase.UCCrearBus.Visible = True
                FormPurchase.UCCrearBus.txtActivo.Text = GridVehiculo.Table.CurrentRecord.GetValue("placa")
                FormPurchase.UCCrearBus.txtActivo.Tag = GridVehiculo.Table.CurrentRecord.GetValue("id")

                If (GridVehiculo.Table.CurrentRecord.GetValue("control") > 0) Then
                    FormPurchase.UCCrearBus.cargarBusxACTIVO(CInt(GridVehiculo.Table.CurrentRecord.GetValue("id")))
                    FormPurchase.UCCrearBus.cboPlantilla.Visible = False
                    FormPurchase.UCCrearBus.rbControlAsientos.Checked = True
                    FormPurchase.UCCrearBus.rbEspacio.Checked = False
                    FormPurchase.UCCrearBus.RadioButton1.Checked = False
                    FormPurchase.UCCrearBus.TIPOCONTROL = "NUMERACION"
                Else
                    FormPurchase.UCCrearBus.cargarBus(Nothing, Nothing)
                    FormPurchase.UCCrearBus.cboPlantilla.Visible = True
                    FormPurchase.UCCrearBus.rbControlAsientos.Checked = False
                    FormPurchase.UCCrearBus.rbEspacio.Checked = True
                    FormPurchase.UCCrearBus.RadioButton1.Checked = False
                    FormPurchase.UCCrearBus.cargarTipoServicios()
                    FormPurchase.UCCrearBus.TIPOCONTROL = "ESPACIOS"
                End If

                FormPurchase.UCCrearBus.BringToFront()
                FormPurchase.UCCrearBus.Show()
            End If
        Else
            MessageBox.Show("Debe Seleccionar un item")
        End If

    End Sub

    Private Sub BunifuFlatButton5_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton5.Click
        If (Not IsNothing(GridVehiculo.Table.CurrentRecord)) Then


        Else
            MessageBox.Show("Debe Seleccionar un item")
        End If
    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click
        Cursor = Cursors.WaitCursor
        GetVehiculos()
        Cursor = Cursors.Default
    End Sub
#End Region

End Class
