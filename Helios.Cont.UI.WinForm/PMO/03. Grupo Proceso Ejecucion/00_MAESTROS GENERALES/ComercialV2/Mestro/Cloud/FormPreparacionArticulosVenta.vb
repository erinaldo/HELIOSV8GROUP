Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Helios.General
Imports System.Data.Entity.DbFunctions
Public Class FormPreparacionArticulosVenta
    Public Property VentaSA As New documentoVentaAbarrotesSA

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(GridPendientes, False, False)
        FormatoGridAvanzado(GridGroupingControl1, True, False)
        txtFecha.Visible = True
    End Sub

    Private Sub GetVentasXentregar()
        Dim dt As New DataTable()
        dt.Columns.Add("id")
        dt.Columns.Add("fecha")
        dt.Columns.Add("tipodoc")
        dt.Columns.Add("numero")
        dt.Columns.Add("cliente")
        dt.Columns.Add("total")

        Dim lista = VentaSA.GetVentasStatusPreparacionAlmacen(New documentoventaAbarrotes With {
                                                          .idEmpresa = Gempresas.IdEmpresaRuc,
                                                          .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                          .estadoEntrega = StatusArticuloVentaPreparado.Pendiente,
                                                          .estadoCobro = TIPO_VENTA.PAGO.COBRADO})

        For Each i In lista
            dt.Rows.Add(
                i.idDocumento,
                i.fechaDoc,
                i.tipoDocumento,
                String.Format("{0}-{1}", i.serieVenta, i.numeroVenta, i.idCliente, i.ImporteNacional
                ))
        Next
        GridPendientes.DataSource = dt
    End Sub

    Private Sub dgvKardexVal_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs) Handles GridPendientes.TableControlPushButtonClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.Inner.ColIndex = 7 Then
                If MessageBox.Show("Confirmar entrega de la venta ?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Dim IdVenta = GridPendientes.TableModel(e.Inner.RowIndex, 1).CellValue
                    VentaSA.PrepararEntregaVenta(
                        New documentoventaAbarrotes With
                        {
                        .estadoEntrega = StatusArticuloVentaPreparado.ListoParaEntregar,
                        .idDocumento = IdVenta
                        })
                    '        GridPendientes.Table.CurrentRecord.Delete()
                    GetVentasXentregar(txtFecha.Value)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub dgvKardexVal_TableControlDrawCell(sender As Object, e As GridTableControlDrawCellEventArgs) Handles GridPendientes.TableControlDrawCell
        If e.Inner.Style.CellType = "PushButton" Then
            e.Inner.Cancel = True

            ' //Draw the Image in a cell.
            If e.Inner.ColIndex = 7 Then
                e.Inner.Style.Description = "Confirmar Entregar"
                e.Inner.Style.TextColor = Color.Black
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)
                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3),
                                           New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6)
                    )
                '    e.Inner.Graphics.DrawImage(Me.ImageList1.Images(0), irect)
            End If
        End If
    End Sub

    Private Sub FormPreparacionArticulosVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtFecha.Value = DateTime.Now
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Cursor = Cursors.WaitCursor
        Try
            GetVentasXentregar(txtFecha.Value)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub GetVentasXentregar(value As Date)
        Dim dt As New DataTable()
        dt.Columns.Add("id")
        dt.Columns.Add("fecha")
        dt.Columns.Add("tipodoc")
        dt.Columns.Add("numero")
        dt.Columns.Add("cliente")
        dt.Columns.Add("total")
        dt.Columns.Add("pagado")

        Dim lista = VentaSA.GetVentasStatusPreparacionAlmacen(New documentoventaAbarrotes With {
                                                          .idEmpresa = Gempresas.IdEmpresaRuc,
                                                          .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                          .estadoEntrega = StatusArticuloVentaPreparado.Pendiente})

        For Each i In lista.Where(Function(o) o.fechaDoc.Value.Year = value.Year And
                o.fechaDoc.Value.Month = value.Month And
                o.fechaDoc.Value.Day = value.Day And
                o.estadoCobro = TIPO_VENTA.PAGO.COBRADO).ToList
            dt.Rows.Add(
                i.idDocumento,
                i.fechaDoc,
                i.tipoDocumento,
                String.Format("{0}:{1}", i.serieVenta, i.numeroVenta),
                i.NombreEntidad,
                i.ImporteNacional,
                If(i.estadoCobro = "PN", "Pendiente", "Pagado"))
        Next
        GridPendientes.DataSource = dt
        GridGroupingControl1.Table.Records.DeleteAll()
    End Sub

    Private Sub GridPendientes_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridPendientes.TableControlCellClick
        Me.Cursor = Cursors.WaitCursor
        If GridPendientes.Table.CurrentRecord IsNot Nothing Then
            GetDetalleVenta(Val(GridPendientes.Table.CurrentRecord.GetValue("id")))
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub GetDetalleVenta(id As Integer)
        Dim conteo As Integer = 0
        Dim detalleSA As New documentoVentaAbarrotesDetSA
        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("producto")
        dt.Columns.Add("unidad")
        dt.Columns.Add("cantidad")
        Dim lista = detalleSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(id)
        For Each i In lista
            conteo = conteo + 1
            dt.Rows.Add(conteo, i.nombreItem, i.unidad1, i.monto1)
        Next
        GridGroupingControl1.DataSource = dt
        Label2.Text = "Nro. de productos : " & lista.Count
    End Sub
End Class