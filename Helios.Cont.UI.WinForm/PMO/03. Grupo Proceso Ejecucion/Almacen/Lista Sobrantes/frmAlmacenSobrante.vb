Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Public Class frmAlmacenTransfenciaSobrante
    Inherits frmMaster
    Public idDocNotificacion As Integer

    Public Sub UbicarDocumento(ByVal intSerie As String, ByVal intComprobante As String, ByVal intProveedor As Integer)
        Dim objDocCompraDet As New DocumentoCompraDetalleSA
        Dim VALUEDES As String = ""
        Dim insumosSA As New detalleitemsSA
        Dim documentoCajaDetalleSA As New DocumentoCajaDetalleSA
        Dim totalesAlmacenSA As New TotalesAlmacenSA

        Try
            dgvCompra.Rows.Clear()
            For Each i In objDocCompraDet.GetUbicar_documentocompradetallePorCompraSL(intSerie, intComprobante, TIPO_SITUACION.ALMACEN_FISICO_SOBRANTE, intProveedor)
                If i.monto1 > 0 Then

                    dgvCompra.Rows.Add(i.idDocumento,
                                   i.secuencia,
                                   i.idItem,
                                   i.descripcionItem,
                                   FormatNumber(i.monto1, 2),
                                   0,
                                   0, 0,
                                   0,
                                   0,
                                   "Elegir almacen")
                End If
            Next
        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try
    End Sub

    Public Sub UbicarDocumentoPorId(ByVal intIdDocumento As Integer)
        Dim objDocCompraDet As New DocumentoCompraDetalleSA
        Dim VALUEDES As String = ""
        Dim insumosSA As New detalleitemsSA
        Dim documentoCajaDetalleSA As New DocumentoCajaDetalleSA
        Dim totalesAlmacenSA As New TotalesAlmacenSA

        Try
            dgvCompra.Rows.Clear()
            For Each i In objDocCompraDet.UbicarDocumentoCompraDetalleSituacion(intIdDocumento, TIPO_SITUACION.ALMACEN_FISICO_SOBRANTE)
                If i.monto1 > 0 Then

                    dgvCompra.Rows.Add(i.idDocumento,
                                   i.secuencia,
                                   i.idItem,
                                   i.descripcionItem,
                                   FormatNumber(i.monto1, 2),
                                   0,
                                   0, 0,
                                   0,
                                   0,
                                   "Elegir almacen")


                End If
            Next
        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try
    End Sub

    Public Sub UbicarDocumentoPorItem(ByVal strNombreItem As String)

        Dim objDocCompraDet As New DocumentoCompraDetalleSA
        Dim VALUEDES As String = ""
        Dim insumosSA As New detalleitemsSA
        Dim documentoCajaDetalleSA As New DocumentoCajaDetalleSA

        Try
            'DETALLE DE LA COMPRA
            dgvCompra.Rows.Clear()

            For Each i In objDocCompraDet.GetUbicar_documentocompradetallePorItem(strNombreItem, "TRS")
                dgvCompra.Rows.Add(i.idDocumento,
                            i.secuencia,
                                    i.idItem,
                                    i.descripcionItem,
                                     FormatNumber(i.monto1, 2),
                                    i.precioUnitario,
                                  i.montokardex,
                                   i.montokardexUS,
                                        i.montoIsc,
                                         i.montoIscUS,
                                           "Elegir almacen",
                                "Cantidad")
            Next
        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub txtSerie_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSerie.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtNumero.Select()
        End If
    End Sub

    Private Sub dgvCompra_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCompra.CellClick
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        datos.Clear()
        If e.ColumnIndex = 10 Then
            'Se ha pulsado sobre un botón
            With frmTotalProdAlmacen
                .txtCantidad.Text = dgvCompra.SelectedRows(0).Cells(4).Value
                .txtDescripcion.Text = dgvCompra.SelectedRows(0).Cells(3).Value
                .txtIdItem.Text = dgvCompra.SelectedRows(0).Cells(2).Value
                .ObtenerListaAlmacen(dgvCompra.SelectedRows(0).Cells(2).Value)
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
                If datos.Count > 0 Then
                    dgvCompra.Item(6, dgvCompra.CurrentRow.Index).Value = datos(0).PMmn
                    dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value = datos(0).PMme
                    dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value = datos(0).Montomn
                    dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value = datos(0).Montome
                    dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value = datos(0).IdProceso
                    dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value = datos(0).NomProceso
                    dgvCompra.Item(5, dgvCompra.CurrentRow.Index).Value = datos(0).IdEvento '- dgvCompra.SelectedRows(0).Cells(4).Value
                End If
            End With
        End If
    End Sub

    Private Sub GuardarToolStripButton_Click(sender As Object, e As EventArgs) Handles GuardarToolStripButton.Click

    End Sub

    Public Sub Grabar()
        Dim TotalesAlmacenSA As New TotalesAlmacenSA
        Dim TotalesAlmacen As New totalesAlmacen
        Dim ListaTotales As New List(Of totalesAlmacen)
        Dim documento As New documento
        Dim n As New RecuperarCarteras()
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        Dim conteo As Integer = 0
        Try
            datos.Clear()
            For Each i As DataGridViewRow In dgvCompra.Rows

                TotalesAlmacen = New totalesAlmacen
                TotalesAlmacen.idDocumento = i.Cells(0).Value()
                TotalesAlmacen.idEmpresa = Gempresas.IdEmpresaRuc
                TotalesAlmacen.idEstablecimiento = GEstableciento.IdEstablecimiento
                TotalesAlmacen.cantidad = CDec(i.Cells(5).Value())
                TotalesAlmacen.idMovimiento = i.Cells(0).Value()
                TotalesAlmacen.idAlmacen = CDec(i.Cells(11).Value())
                TotalesAlmacen.idItem = CDec(i.Cells(2).Value())
                TotalesAlmacen.precioUnitarioCompra = 0
                TotalesAlmacen.importeSoles = CDec(i.Cells(8).Value())
                TotalesAlmacen.importeDolares = CDec(i.Cells(9).Value())
                TotalesAlmacen.montoIsc = 0
                TotalesAlmacen.montoIscUS = 0
                ListaTotales.Add(TotalesAlmacen)
            Next
            n.IdResponsable = TotalesAlmacenSA.UpdateTotalesAlmacen2(ListaTotales, idDocNotificacion)
            
            Me.lblEstado.Image = My.Resources.ok4
            Me.lblEstado.Text = ("Se Elimino con exito")
            dgvCompra.Rows.Clear()
            txtNumero.Clear()
            txtSerie.Clear()
            datos.Add(n)
            Dispose()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub QRibbonInputBox2_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtNumero.Select()
        End If
    End Sub

    Private Sub frmAlmacenTransfenciaSobrante_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub btGrabar_Click(sender As Object, e As EventArgs) Handles btGrabar.Click
        Grabar()
    End Sub
End Class