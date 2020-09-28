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

Public Class frmProduccionEnviada

#Region "Atributos"
    Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        GridCFGDetetail(dgvProductos)
        GetItems()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

#End Region

#Region "Metodos"


    Public Sub ProduccionEnviada(idEntregle As Integer)
        Dim documentoSA As New DocumentoCompraSA
        Dim Lista As New List(Of documentocompradetalle)

        Me.dgvProductos.Table.Records.DeleteAll()

        Try
            Lista = documentoSA.EnvioDeProductosTerminados(PeriodoGeneral, idEntregle)


            For Each i In Lista

                Me.dgvProductos.Table.AddNewRecord.SetCurrent()
                Me.dgvProductos.Table.AddNewRecord.BeginEdit()
                Me.dgvProductos.Table.CurrentRecord.SetValue("idDocumento", i.idDocumento)
                Me.dgvProductos.Table.CurrentRecord.SetValue("fecha", i.fechaDoc)
                Me.dgvProductos.Table.CurrentRecord.SetValue("nroDoc", i.NumDoc)
                Me.dgvProductos.Table.CurrentRecord.SetValue("secuencia", i.secuencia)
                Me.dgvProductos.Table.CurrentRecord.SetValue("idItem", i.idItem)
                Me.dgvProductos.Table.CurrentRecord.SetValue("descripcion", i.descripcionItem)
                Me.dgvProductos.Table.CurrentRecord.SetValue("cant", i.monto1)
                Me.dgvProductos.Table.CurrentRecord.SetValue("pu", i.precioUnitario)
                Me.dgvProductos.Table.CurrentRecord.SetValue("importe", i.importe)
                Me.dgvProductos.Table.CurrentRecord.SetValue("secuencia", i.secuencia)







                Me.dgvProductos.Table.AddNewRecord.EndEdit()


            Next

        Catch ex As Exception

        End Try
    End Sub


    Public Sub GetItems()
        Dim compraSA As New DocumentoCompraSA
        Dim dt As New DataTable
        dt.Columns.Add("idDocumento")
        dt.Columns.Add("fecha")
        dt.Columns.Add("nroDoc")
        dt.Columns.Add("idItem")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("cant")
        dt.Columns.Add("pu")
        dt.Columns.Add("importe")
        dt.Columns.Add("secuencia")

        dgvProductos.DataSource = dt

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
    Private Sub frmProduccionEnviada_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        ProduccionEnviada(lblidEntregable.Text)
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click




        Cursor = Cursors.WaitCursor


        If Not IsNothing(Me.dgvProductos.Table.CurrentRecord) Then



            Dim f As New frmConsumoDeProduccion
            f.lblIdEntregable.Text = lblidEntregable.Text
            f.txtEntregable.Text = txtEntregable.Text


            f.lblIdItem.Text = Me.dgvProductos.Table.CurrentRecord.GetValue("descripcion")
            f.lblCant.Text = Me.dgvProductos.Table.CurrentRecord.GetValue("cant")
            f.lblPrecioUni.Text = Me.dgvProductos.Table.CurrentRecord.GetValue("pu")
            f.lblImporte.Text = Me.dgvProductos.Table.CurrentRecord.GetValue("importe")

            f.lblIdDocumento.Text = Me.dgvProductos.Table.CurrentRecord.GetValue("idDocumento")
            f.lblidSecuencia.Text = Me.dgvProductos.Table.CurrentRecord.GetValue("secuencia")

            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()



        Else
            MessageBox.Show("Debe seleccionar una item!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Cursor = Cursors.Default
    End Sub
End Class