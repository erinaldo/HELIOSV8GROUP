Imports Syncfusion.Windows.Forms.Tools
Imports Helios.Cont.Business.Entity
Imports Helios.General
'Imports Helios.Planilla.Business.Entity

Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
'Imports Helios.Planilla.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Imports Syncfusion.GridHelperClasses


Public Class fmHistorialCosteo

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        GridCFGDetetail(dgvHistorial)
        GetItems()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

#Region "Metodos"


    Public Sub ProduccionEnviada(idEntregle As Integer)
        Dim documentoSA As New documentoLibroDiarioSA
        Dim Lista As New List(Of documentoLibroDiario)

        Me.dgvHistorial.Table.Records.DeleteAll()

        Try
            Lista = documentoSA.HistorialCosteo(idEntregle)


            For Each i In Lista

                Me.dgvHistorial.Table.AddNewRecord.SetCurrent()
                Me.dgvHistorial.Table.AddNewRecord.BeginEdit()
                Me.dgvHistorial.Table.CurrentRecord.SetValue("idDocumento", i.idDocumento)
                Me.dgvHistorial.Table.CurrentRecord.SetValue("fecha", i.fecha)
                Me.dgvHistorial.Table.CurrentRecord.SetValue("tipoDoc", i.tipoDoc)
                Me.dgvHistorial.Table.CurrentRecord.SetValue("nroDoc", i.nroDoc)
                Me.dgvHistorial.Table.CurrentRecord.SetValue("importe", i.importeMN)
                Me.dgvHistorial.Table.CurrentRecord.SetValue("tipoCliente", i.tipoRazonSocial)
                Me.dgvHistorial.Table.CurrentRecord.SetValue("idCliente", i.razonSocial)

                If i.estado = "REC" Then
                    Me.dgvHistorial.Table.CurrentRecord.SetValue("reconocimiento", "SI")
                ElseIf i.estado = "PREC" Then
                    Me.dgvHistorial.Table.CurrentRecord.SetValue("reconocimiento", "NO")
                End If



                Me.dgvHistorial.Table.AddNewRecord.EndEdit()


            Next

        Catch ex As Exception

        End Try
    End Sub


    Public Sub GetItems()
        Dim compraSA As New DocumentoCompraSA
        Dim dt As New DataTable
        dt.Columns.Add("idDocumento")
        dt.Columns.Add("fecha")
        dt.Columns.Add("tipoDoc")
        dt.Columns.Add("nroDoc")
        dt.Columns.Add("importe")
        dt.Columns.Add("tipoCliente")
        dt.Columns.Add("idCliente")
        dt.Columns.Add("reconocimiento")
        dgvHistorial.DataSource = dt

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
    Private Sub fmHistorialCosteo_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub fmHistorialCosteo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ProduccionEnviada(lblidEntregable.Text)
    End Sub

    Private Sub btnReconocimiento_Click(sender As Object, e As EventArgs) Handles btnReconocimiento.Click
        Cursor = Cursors.WaitCursor
        'If cboMes.Text.Trim.Length > 0 Then
        'validarCierreAnterior()
        'ValidarCierreActual()
        Dim objeto As New documentoLibroDiario

        If Not IsNothing(Me.dgvHistorial.Table.CurrentRecord) Then


            If Me.dgvHistorial.Table.CurrentRecord.GetValue("reconocimiento") = "NO" Then



                Dim f As New frmReconocimientoIngreso

                objeto = New documentoLibroDiario
                objeto.idDocReferencia = CInt(Me.dgvHistorial.Table.CurrentRecord.GetValue("idDocumento"))
                objeto.importeMN = CInt(Me.dgvHistorial.Table.CurrentRecord.GetValue("importe"))
                objeto.tipoRazonSocial = CStr(Me.dgvHistorial.Table.CurrentRecord.GetValue("tipoCliente"))
                objeto.razonSocial = CInt(Me.dgvHistorial.Table.CurrentRecord.GetValue("idCliente"))
                f.LlenarReconocimiento(objeto)
                f.lblidCosto.Text = lblidEntregable.Text

                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()

                ProduccionEnviada(lblidEntregable.Text)

            Else
                MessageBox.Show("Este Documento ya tiene Reconocimiento!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Cursor = Cursors.Default
            End If
        Else
            MessageBox.Show("Debe seleccionar una item!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Cursor = Cursors.Default
        End If
        'Else
        '    MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    cboMes.Select()
        '    cboMes.DroppedDown = True
        'End If
        Cursor = Cursors.Default



        '//////////////////////////////

    End Sub

   
End Class