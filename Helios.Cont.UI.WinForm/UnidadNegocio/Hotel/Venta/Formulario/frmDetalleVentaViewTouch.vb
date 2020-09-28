Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class frmDetalleVentaViewTouch

#Region "Attributes"
    Public VentaDoc As documentoventaAbarrotes
#End Region

#Region "Constructors"
    Public Sub New(ListaDocumento As documentoventaAbarrotes)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormatoGridAvanzado(dgvVenta, True, False)
        'VentaDoc = venta
        ObtenerDetallePedido(ListaDocumento)
    End Sub

#End Region

#Region "Methods"
    Public Sub ObtenerDetallePedido(listaDocumento As documentoventaAbarrotes)
        Dim dt As New DataTable
        Dim ventaDetalleSA As New documentoVentaAbarrotesDetSA
        Try

            'DETALLE DE LA COMPRA
            dgvVenta.Table.Records.DeleteAll()

            With dt.Columns
                .Add("codigo")
                .Add("gravado")
                .Add("idProducto")
                .Add("item")
                .Add("um")
                .Add("cantidad")
                .Add("pumn")
                .Add("pume")
                .Add("totalmn")
                .Add("totalme")
                .Add("igvmn")
                .Add("igvme")
                .Add("tipoExistencia")
                .Add("estado")
            End With

            Dim consulta = ventaDetalleSA.GetUbicar_documentoventaAbarrotesXListaIdDocumento(listaDocumento)

            For Each i In consulta '.Where(Function(o) tables.Contains(o.idtabla)).ToList

                dt.Rows.Add(i.idDocumento,
                        i.destino,
                        i.idItem,
                       i.nombreItem,
                        i.unidad1,
                        i.monto1,
                        i.precioUnitario,
                        i.precioUnitarioUS,
                        i.importeMN,
                        i.importeME,
                        i.montoIgv,
                        i.montoIgvUS,
                        i.tipoExistencia,
                        i.estadoPago)
            Next

            dgvVenta.DataSource = dt

        Catch ex As Exception
            MsgBox("Error al cargar datos." & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del Sistema!")
        End Try
    End Sub

    'Public Sub ObtenerDetallePedido(venta As documentoventaAbarrotes)
    '    Try
    '        Dim dt As New DataTable()
    '        dt.Columns.Add("codigo")
    '        dt.Columns.Add("gravado")
    '        dt.Columns.Add("idProducto")
    '        dt.Columns.Add("item")
    '        dt.Columns.Add("um")
    '        dt.Columns.Add("cantidad", GetType(Decimal))
    '        dt.Columns.Add("vcmn", GetType(Decimal))
    '        dt.Columns.Add("totalmn", GetType(Decimal))
    '        dt.Columns.Add("vcme", GetType(Decimal))
    '        dt.Columns.Add("totalme", GetType(Decimal))
    '        dt.Columns.Add("igvmn", GetType(Decimal))
    '        dt.Columns.Add("igvme", GetType(Decimal))
    '        dt.Columns.Add("tipoExistencia")
    '        dt.Columns.Add("almacen")
    '        dt.Columns.Add("pumn", GetType(Decimal))
    '        dt.Columns.Add("pume", GetType(Decimal))
    '        dt.Columns.Add("costoMN", GetType(Decimal))
    '        dt.Columns.Add("costoME", GetType(Decimal))
    '        dt.Columns.Add("pagado", GetType(Decimal))
    '        dt.Columns.Add("pagadoME", GetType(Decimal))
    '        dt.Columns.Add("estado", GetType(String))
    '        dt.Columns.Add("stock", GetType(Boolean))

    '        For Each i As documentoventaAbarrotesDet In venta.documentoventaAbarrotesDet.ToList
    '            Dim dr As DataRow = dt.NewRow
    '            dr(0) = i.secuencia
    '            dr(1) = i.destino
    '            dr(2) = i.idItem
    '            dr(3) = i.nombreItem
    '            dr(4) = i.unidad1
    '            dr(5) = i.monto1

    '            dr(6) = i.montokardex
    '            dr(7) = i.importeMN
    '            dr(8) = i.montokardexUS
    '            dr(9) = i.importeME

    '            dr(10) = i.montoIgv
    '            dr(11) = i.montoIgvUS
    '            dr(12) = i.tipoExistencia
    '            'If i.tipoExistencia = "GS" Then
    '            '    dr(12) = String.Empty
    '            'Else
    '            dr(13) = i.idAlmacenOrigen
    '            'End If

    '            dr(14) = i.precioUnitario
    '            dr(15) = i.precioUnitarioUS
    '            dr(16) = i.salidaCostoMN.GetValueOrDefault
    '            dr(17) = i.salidaCostoME.GetValueOrDefault
    '            dr(18) = i.importeMN
    '            dr(19) = i.importeME
    '            dr(20) = "NO"
    '            dr(21) = i.AfectoInventario
    '            dt.Rows.Add(dr)

    '            'i.AfectoInventario = True
    '        Next

    '        dgvVenta.DataSource = dt

    '    Catch ex As Exception
    '        MsgBox("Error al cargar datos." & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del Sistema!")
    '    End Try
    'End Sub

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
#End Region


#Region "Events"

#End Region

End Class