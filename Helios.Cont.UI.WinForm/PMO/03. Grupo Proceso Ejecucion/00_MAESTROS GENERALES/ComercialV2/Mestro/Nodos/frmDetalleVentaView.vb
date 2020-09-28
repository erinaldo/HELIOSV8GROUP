Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class frmDetalleVentaView

#Region "Attributes"
    Public VentaDoc As documentoventaAbarrotes
#End Region

#Region "Constructors"
    Public Sub New(idDocumento As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormatoGridAvanzado(dgvVenta, True, False)
        ObtenerDetallePedido(idDocumento)
    End Sub

    Public Sub New(venta As documentoventaAbarrotes)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(dgvVenta, False, False)
        VentaDoc = venta
        ObtenerDetallePedido(VentaDoc)
    End Sub
#End Region

#Region "Methods"
    Public Sub ObtenerDetallePedido(intIdDocumento As Integer)
        Dim ventaDetalleSA As New documentoVentaAbarrotesDetSA
        Try
            Dim dt As New DataTable()
            dt.Columns.Add("codigo")
            dt.Columns.Add("gravado")
            dt.Columns.Add("idProducto")
            dt.Columns.Add("item")
            dt.Columns.Add("um")
            dt.Columns.Add("cantidad", GetType(Decimal))
            dt.Columns.Add("vcmn", GetType(Decimal))
            dt.Columns.Add("totalmn", GetType(Decimal))
            dt.Columns.Add("vcme", GetType(Decimal))
            dt.Columns.Add("totalme", GetType(Decimal))
            dt.Columns.Add("igvmn", GetType(Decimal))
            dt.Columns.Add("igvme", GetType(Decimal))
            dt.Columns.Add("tipoExistencia")
            dt.Columns.Add("almacen")
            dt.Columns.Add("pumn", GetType(Decimal))
            dt.Columns.Add("pume", GetType(Decimal))
            dt.Columns.Add("costoMN", GetType(Decimal))
            dt.Columns.Add("costoME", GetType(Decimal))
            dt.Columns.Add("pagado", GetType(Decimal))
            dt.Columns.Add("pagadoME", GetType(Decimal))
            dt.Columns.Add("estado", GetType(String))
            dt.Columns.Add("stock", GetType(Boolean))

            For Each i As documentoventaAbarrotesDet In ventaDetalleSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(intIdDocumento)
                Dim dr As DataRow = dt.NewRow
                dr(0) = i.secuencia
                dr(1) = i.destino
                dr(2) = i.idItem
                dr(3) = i.nombreItem
                dr(4) = i.unidad1
                dr(5) = i.monto1

                dr(6) = i.montokardex
                dr(7) = i.importeMN
                dr(8) = i.montokardexUS
                dr(9) = i.importeME

                dr(10) = i.montoIgv
                dr(11) = i.montoIgvUS
                dr(12) = i.tipoExistencia
                'If i.tipoExistencia = "GS" Then
                '    dr(12) = String.Empty
                'Else
                dr(13) = i.idAlmacenOrigen
                'End If

                dr(14) = i.precioUnitario
                dr(15) = i.precioUnitarioUS
                dr(16) = i.salidaCostoMN
                dr(17) = i.salidaCostoME
                dr(18) = i.importeMN
                dr(19) = i.importeME
                dr(20) = "NO"
                dr(21) = i.AfectoInventario
                dt.Rows.Add(dr)
            Next

            dgvVenta.DataSource = dt

        Catch ex As Exception
            MsgBox("Error al cargar datos." & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del Sistema!")
        End Try
    End Sub

    Public Sub ObtenerDetallePedido(venta As documentoventaAbarrotes)
        Try
            Dim dt As New DataTable()
            dt.Columns.Add("codigo")
            dt.Columns.Add("gravado")
            dt.Columns.Add("idProducto")
            dt.Columns.Add("item")
            dt.Columns.Add("um")
            dt.Columns.Add("cantidad", GetType(Decimal))
            dt.Columns.Add("vcmn", GetType(Decimal))
            dt.Columns.Add("totalmn", GetType(Decimal))
            dt.Columns.Add("vcme", GetType(Decimal))
            dt.Columns.Add("totalme", GetType(Decimal))
            dt.Columns.Add("igvmn", GetType(Decimal))
            dt.Columns.Add("igvme", GetType(Decimal))
            dt.Columns.Add("tipoExistencia")
            dt.Columns.Add("almacen")
            dt.Columns.Add("pumn", GetType(Decimal))
            dt.Columns.Add("pume", GetType(Decimal))
            dt.Columns.Add("costoMN", GetType(Decimal))
            dt.Columns.Add("costoME", GetType(Decimal))
            dt.Columns.Add("pagado", GetType(Decimal))
            dt.Columns.Add("pagadoME", GetType(Decimal))
            dt.Columns.Add("estado", GetType(String))
            dt.Columns.Add("stock", GetType(Boolean))
            dt.Columns.Add("icbper", GetType(Decimal))
            dt.Columns.Add("info", GetType(String))

            For Each i As documentoventaAbarrotesDet In venta.documentoventaAbarrotesDet.ToList
                Dim dr As DataRow = dt.NewRow

                dr(0) = i.secuencia
                dr(1) = i.destino
                dr(2) = i.idItem
                dr(3) = i.nombreItem
                dr(4) = i.unidad1
                dr(5) = i.monto1

                dr(6) = i.montokardex
                dr(7) = i.importeMN
                dr(8) = i.montokardexUS
                dr(9) = i.importeME

                dr(10) = i.montoIgv
                dr(11) = i.montoIgvUS
                dr(12) = i.tipoExistencia
                'If i.tipoExistencia = "GS" Then
                '    dr(12) = String.Empty
                'Else
                dr(13) = i.idAlmacenOrigen
                'End If

                dr(14) = i.precioUnitario
                dr(15) = i.precioUnitarioUS
                dr(16) = i.salidaCostoMN.GetValueOrDefault
                dr(17) = i.salidaCostoME.GetValueOrDefault
                dr(18) = i.importeMN
                dr(19) = i.importeME
                dr(20) = "NO"
                Select Case tmpConfigInicio.FormatoVenta
                    Case "FACT"
                        dr(21) = False
                    Case Else
                        'i.AfectoInventario = i.CustomProducto.AfectoStock.GetValueOrDefault

                        dr(21) = i.AfectoInventario
                End Select
                dr(22) = i.montoIcbper.GetValueOrDefault
                dr(23) = i.tipobeneficio
                dt.Rows.Add(dr)
                'i.AfectoInventario = True
            Next

            dgvVenta.DataSource = dt
            Select Case tmpConfigInicio.FormatoVenta
                Case "FACT"
                    dgvVenta.TableDescriptor.Columns("stock").ReadOnly = True

                Case Else
                    dgvVenta.TableDescriptor.Columns("stock").ReadOnly = False
            End Select
        Catch ex As Exception
            MsgBox("Error al cargar datos." & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del Sistema!")
        End Try
    End Sub

    Private col2Check As Boolean = True
    Private Sub DgvVenta_TableControlCellClick(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs) Handles dgvVenta.TableControlCellClick
        Dim style As GridTableCellStyleInfo = e.TableControl.Model(e.Inner.RowIndex, e.Inner.ColIndex)

        If style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso style.TableCellIdentity.Column.Name = "stock" Then
            Me.col2Check = Not Me.col2Check

            For Each i In dgvVenta.Table.Records
                i.SetValue("stock", Me.col2Check)

                Dim item = VentaDoc.documentoventaAbarrotesDet.Where(Function(o) o.secuencia = Integer.Parse(i.GetValue("codigo"))).SingleOrDefault
                If item IsNot Nothing Then
                    With item
                        .AfectoInventario = Me.col2Check
                    End With
                End If
            Next

            e.Inner.Cancel = True
        End If
    End Sub

    Private Sub dgvVenta_TableControlCheckBoxClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvVenta.TableControlCheckBoxClick
        Me.Cursor = Cursors.WaitCursor
        Dim obj As New documentocompra
        Dim RowIndex As Integer = e.Inner.RowIndex
        Dim cc As GridCurrentCell = dgvVenta.TableControl.CurrentCell
        cc.ConfirmChanges()

        If RowIndex > -1 Then
            e.TableControl.CurrentCell.EndEdit()
            e.TableControl.Table.TableDirty = True
            e.TableControl.Table.EndEdit()

            Dim style3 As GridTableCellStyleInfo = e.TableControl.Model(e.Inner.RowIndex, e.Inner.ColIndex)
            If style3.Enabled Then
                If style3.TableCellIdentity.Column.Name = "bonificacion" Then

                ElseIf style3.TableCellIdentity.Column.Name = "stock" Then
                    Dim afectaStock = Me.dgvVenta.TableModel(RowIndex, 8).CellValue
                    Select Case afectaStock
                        Case "False" 'TRUE
                            If RowIndex <> -1 Then
                                Dim item = VentaDoc.documentoventaAbarrotesDet.Where(Function(o) o.secuencia = Me.dgvVenta.TableModel(RowIndex, 1).CellValue).SingleOrDefault
                                If item IsNot Nothing Then
                                    With item
                                        .AfectoInventario = True
                                    End With
                                End If
                            End If
                        Case Else ' FALSE
                            If RowIndex <> -1 Then
                                Dim item = VentaDoc.documentoventaAbarrotesDet.Where(Function(o) o.secuencia = Me.dgvVenta.TableModel(RowIndex, 1).CellValue).SingleOrDefault
                                If item IsNot Nothing Then
                                    With item
                                        .AfectoInventario = False
                                    End With
                                End If
                            End If
                    End Select
                End If
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvVenta_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvVenta.QueryCellStyleInfo
        If e.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso e.TableCellIdentity.Column.Name = "stock" Then
            e.Style.CellType = "CheckBox"
            e.Style.Description = e.Style.Text
            e.Style.CellValue = Me.col2Check
            e.Style.Enabled = True
        End If
    End Sub
#End Region


#Region "Events"

#End Region

End Class