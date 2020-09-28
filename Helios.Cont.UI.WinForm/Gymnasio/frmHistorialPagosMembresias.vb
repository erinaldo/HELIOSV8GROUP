Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class frmHistorialPagosMembresias
#Region "Attributes"
    Dim parentTable As New DataTable
    Dim ChildTable As New DataTable
    Dim cajaSA As New DocumentoCajaSA
#End Region

#Region "Constructors"
    Public Sub New(idDocumento As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormatoGridPequeño(dgvCompras, True)
        LoadHistorialCajasXcompra(idDocumento)
        Tag = idDocumento
    End Sub
#End Region

#Region "Methods"
    Private Function getParentCaja(intIdCompra As Integer) As DataTable
        Dim dt As New DataTable("ParentTable")

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("fecha", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("moneda", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoCambio", GetType(String)))

        dt.Columns.Add(New DataColumn("montoSoles", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoUsd", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("operacion", GetType(String)))
        dt.Columns.Add(New DataColumn("tipo", GetType(String)))
        dt.Columns.Add(New DataColumn("periodo", GetType(String)))

        Dim str As String
        For Each i As documentoCaja In cajaSA.ListadoComprobaNtesXidPadre(intIdCompra)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaCobro).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = str
            dr(2) = i.tipoDocPago
            dr(3) = i.numeroDoc
            dr(4) = i.moneda
            dr(5) = i.tipoCambio
            dr(6) = i.montoSoles.GetValueOrDefault
            dr(7) = i.montoUsd.GetValueOrDefault
            dr(8) = i.tipoOperacion
            dr(9) = "EFECTIVO"
            dr(10) = i.periodo
            dt.Rows.Add(dr)
        Next

        Return dt
    End Function

    Public Sub LoadHistorialCajasXcompra(IdDocumento As Integer)

        Dim dSet As New DataSet()
        parentTable = getParentCaja(IdDocumento)
        ChildTable = getChildCaja(IdDocumento)
        dSet.Tables.AddRange(New DataTable() {parentTable, ChildTable})

        'setup the relations
        Dim parentColumn As DataColumn = parentTable.Columns("idDocumento")
        Dim childColumn As DataColumn = ChildTable.Columns("idDocumento")
        dSet.Relations.Add("ParentToChild", parentColumn, childColumn)

        Me.dgvCompras.DataSource = parentTable
        Me.dgvCompras.Engine.BindToCurrencyManager = False

        Me.dgvCompras.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = False
        Me.dgvCompras.TopLevelGroupOptions.ShowCaption = False


    End Sub

    Private Function getChildCaja(intIdDocume As Integer) As DataTable
        Dim dt As New DataTable("ChildTable")
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("DetalleItems", GetType(String)))
        dt.Columns.Add(New DataColumn("montoSoles", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoUsd", GetType(Decimal)))

        For Each i As documentoCajaDetalle In cajaSA.ListadoCajaDetalleHijos(intIdDocume)
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.idDocumento
            dr(1) = i.DetalleItem
            dr(2) = i.montoSoles
            dr(3) = i.montoUsd
            dt.Rows.Add(dr)
        Next

        Return dt
    End Function

    Public Sub EliminarDocumento(intIdDocumento As Integer, codigoOperacion As String)
        Dim documentoSA As New DocumentoSA
        Dim docCajaSA As New DocumentoCajaSA
        Dim nDocumento As New documento()
        With nDocumento
            .IdDocumentoAfectado = Tag
            .idDocumento = intIdDocumento
            .idOrden = codigoOperacion
            '     .usuarioActualizacion = docCajaSA.GetUbicar_documentoCajaPorID(intIdDocumento).usuarioModificacion
        End With
        documentoSA.EliminarPagoMembresia(nDocumento)
        dgvCompras.Table.CurrentRecord.Delete()
        'lblEstado.Text = "Pago eliminado correctamente"
        'PanelError.Visible = True
        'Timer1.Enabled = True
        'TiempoEjecutar(10)
        '  HistorialCompra(txtFechaCompra.ValueMember)
    End Sub
#End Region

#Region "Events"
    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        LoadHistorialCajasXcompra(Tag)
    End Sub

    Private Sub PrintToolStripButton_Click(sender As Object, e As EventArgs) Handles PrintToolStripButton.Click
        Cursor = Cursors.WaitCursor
        Try
            'If Not IsNothing(Me.dgvHistorial.Table.CurrentRecord) Then
            '    EliminarDocumento(CInt(Me.dgvHistorial.Table.CurrentRecord.GetValue("idDocumento")))
            'End If
            Dim el As Element = Me.dgvCompras.Table.GetInnerMostCurrentElement()

            If el IsNot Nothing Then
                Dim table As GridTable = TryCast(el.ParentTable, GridTable)
                Dim tableControl As GridTableControl = Me.dgvCompras.GetTableControl(table.TableDescriptor.Name)
                Dim cc As GridCurrentCell = tableControl.CurrentCell
                Dim style As GridTableCellStyleInfo = table.GetTableCellStyle(cc.RowIndex, cc.ColIndex)
                Dim rec As GridRecord = TryCast(el, GridRecord)
                If rec Is Nothing AndAlso TypeOf el Is GridRecordRow Then
                    rec = TryCast(el.ParentRecord, GridRecord)
                End If
                If rec IsNot Nothing Then
                    If MessageBox.Show("Desea eliminar el pago seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        EliminarDocumento(rec.GetValue("idDocumento"), rec.GetValue("operacion"))
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Cursor = Cursors.Arrow
    End Sub
#End Region
End Class