Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class TabLG_ConfirmarEmitidosVenta

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(dgvCompras, True, False)
    End Sub
#End Region

#Region "Methods"
    Sub GetNotas()
        Dim compraSA As New DocumentoCompraSA
        Dim dt As New DataTable()
        dt.Columns.Add("iddocumento")
        dt.Columns.Add("fecha")
        dt.Columns.Add("tipodoc")
        dt.Columns.Add("nro")
        dt.Columns.Add("action")

        For Each i In compraSA.GetDocumentosCompraByTipo(New Business.Entity.documentocompra With
                                                              {
                                                              .idEmpresa = Gempresas.IdEmpresaRuc,
                                                              .idCentroCosto = GEstableciento.IdEstablecimiento,
                                                              .tipoCompra = TIPO_COMPRA.NOTA_DE_COMPRA_EN_ESPERA
                                                              })

            dt.Rows.Add(i.idDocumento, i.fechaDoc, i.tipoDoc, i.numeroDoc)

        Next
        dgvCompras.DataSource = dt
    End Sub
#End Region

#Region "Events"
    Private Sub dgvKardexVal_TableControlDrawCell(sender As Object, e As GridTableControlDrawCellEventArgs) Handles dgvCompras.TableControlDrawCell
        If e.Inner.Style.CellType = "PushButton" Then
            e.Inner.Cancel = True

            ' //Draw the Image in a cell.
            If e.Inner.ColIndex = 5 Then
                e.Inner.Style.Description = "Confirmar"
                e.Inner.Style.TextColor = Color.Black
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)
                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3),
                                           New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6)
                    )
                '    e.Inner.Graphics.DrawImage(Me.ImageList1.Images(0), irect)
            End If
        End If
    End Sub

    Private Sub dgvKardexVal_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs) Handles dgvCompras.TableControlPushButtonClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.Inner.ColIndex = 5 Then
                Dim f As New frmGeneral_BusquedaEntidad(TIPO_ENTIDAD.CLIENTE)
                f.CaptionLabels(0).Text = "Cliente"
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
                If Not IsNothing(f.Tag) Then
                    'Dim c = DirectCast(f.Tag, entidad)
                    ''Dim c = CType(f.Tag, entidad)
                    ''txtCliente2.Text = c.nombreCompleto
                    ''txtCliente2.Tag = c.idEntidad
                    ''txtRuc2.Text = c.nrodoc
                    ''txtRuc2.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                    ''txtCliente2.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)

                    ''Dim idCliente = Integer.Parse(dgvCompra.TableModel(e.Inner.RowIndex, 10).CellValue)
                    ''Dim NroIdentidadCliente = Integer.Parse(dgvCompra.TableModel(e.Inner.RowIndex, 7).CellValue)
                    ''Dim nombreCliente = Integer.Parse(dgvCompra.TableModel(e.Inner.RowIndex, 8).CellValue)

                    'dgvCompra.TableModel(e.Inner.RowIndex, 10).CellValue = c.idEntidad
                    'dgvCompra.TableModel(e.Inner.RowIndex, 7).CellValue = c.nrodoc
                    'dgvCompra.TableModel(e.Inner.RowIndex, 8).CellValue = c.nombreCompleto

                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Me.Cursor = Cursors.Arrow
    End Sub
#End Region


End Class
