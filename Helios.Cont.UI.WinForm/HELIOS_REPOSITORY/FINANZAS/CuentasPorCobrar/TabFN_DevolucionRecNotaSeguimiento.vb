Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class TabFN_DevolucionRecNotaSeguimiento

#Region "Attributes"
    Public Property anticipoSA As New documentoAnticipoSA
    Public Property documentoAnticipoConciliacionSA As New documentoAnticipoConciliacionSA
    Public moduloR As String
    Public estadoR As String
    ' Public Property FormMDI As FormMaestroReclamacionPagos
#End Region

#Region "Constructors"
    Public Sub New(estado As String, modulo As String) ', Form As FormMaestroReclamacionPagos)

        ' This call is required by the designer.
        InitializeComponent()

        'FormMDI = Form
        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(GridNotas, True, False, 10.0F)
        FormatoGridAvanzado(GridGroupingControl1, True, False, 10.0F)

        ' FormatoGridAvanzado(GridDetalle, True, False, 10.0F)
        Select Case estado
            Case Anticipo.EstadoCobroNotaCredito.DevolucionTramitePendiente
                ToolStripLabel1.Text = "Devoluciones - Pendientes"
                ToolStripButton1.Visible = True
            Case Anticipo.EstadoCobroNotaCredito.DevolucionTramiteParcial
                ToolStripLabel1.Text = "Devoluciones - Parcial"
                ToolStripButton1.Visible = True
            Case Anticipo.EstadoCobroNotaCredito.DevolucionTramiteCompleto
                ToolStripLabel1.Text = "Devoluciones - Completadas"
                ToolStripButton1.Visible = False
        End Select

        moduloR = modulo
        estadoR = estado
        'If moduloR = "VENTAS" Then
        '    GetNotas(estado)
        'ElseIf moduloR = "COMPRAS" Then
        '    GetNotasCompras(estado)
        'End If

        txtPeriodo.Value = DateTime.Now
    End Sub
#End Region

#Region "Methods"
    Private Sub GetDetallePagos(idDocumento As Integer)
        Dim cajaSA As New DocumentoCajaSA
        Dim dt As New DataTable
        With dt
            .Columns.Add("idDocumento")
            .Columns.Add("fecha")
            .Columns.Add("formapago")
            .Columns.Add("entidadfinanciera")
            .Columns.Add("monto")
        End With

        Dim lista = cajaSA.ListadoComprobaNtesXidPadre(idDocumento)
        For Each i In lista
            dt.Rows.Add(i.idDocumento, i.fechaCobro, i.formapago, i.NombreCaja, i.montoSoles.GetValueOrDefault)
        Next
        GridGroupingControl1.DataSource = dt
    End Sub



    Private Sub GetNotasCompras(estado As String)

        Dim dt As New DataTable
        dt.Columns.Add("idDocumento")
        dt.Columns.Add("fecha")
        dt.Columns.Add("tipo")
        dt.Columns.Add("nrodoc")
        dt.Columns.Add("monto")
        dt.Columns.Add("usado")
        dt.Columns.Add("saldo")
        dt.Columns.Add("estado")
        dt.Columns.Add("entidad")
        dt.Columns.Add("identidad")

        For Each i In anticipoSA.GetDevolucionCompraSeguimiento(New documentocompra With
                                                             {
                                                             .idEmpresa = Gempresas.IdEmpresaRuc,
                                                             .idCentroCosto = GEstableciento.IdEstablecimiento,
                                                             .tipoCompra = "VRC",
                                                             .estadoPago = estado
                                                             })

            dt.Rows.Add(i.idDocumento, i.fechaDoc, "NOTA DE CREDITO", i.numeroDoc, i.importeMN, i.TotalNotas, i.SaldoReclamacion.GetValueOrDefault, i.EstadoName, i.CustomEntidad.nombreCompleto, i.CustomEntidad.idEntidad)
        Next
        GridNotas.DataSource = dt
        GridNotas.BackColor = Color.White
    End Sub


    Private Sub GetNotas(estado As String)

        Dim dt As New DataTable
        dt.Columns.Add("idDocumento")
        dt.Columns.Add("fecha")
        dt.Columns.Add("tipo")
        dt.Columns.Add("nrodoc")
        dt.Columns.Add("monto")
        dt.Columns.Add("usado")
        dt.Columns.Add("saldo")
        dt.Columns.Add("estado")
        dt.Columns.Add("entidad")
        dt.Columns.Add("identidad")

        For Each i In anticipoSA.GetDevolucionVentaSeguimiento(New documentoventaAbarrotes With
                                                             {
                                                             .idEmpresa = Gempresas.IdEmpresaRuc,
                                                             .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                             .tipoVenta = "VRC",
                                                             .estadoCobro = estado
                                                             })

            dt.Rows.Add(i.idDocumento, i.fechaDoc, "NOTA DE CREDITO", i.numeroDoc, i.importeMN, i.TotalNotas, i.SaldoReclamacion.GetValueOrDefault, i.EstadoName, i.CustomEntidad.nombreCompleto, i.CustomEntidad.idEntidad)
        Next
        GridNotas.DataSource = dt
        GridNotas.BackColor = Color.White
    End Sub


    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim entSA As New entidadSA

        Dim r As Record = GridNotas.Table.CurrentRecord
        If r IsNot Nothing Then

            If moduloR = "VENTAS" Then
                Dim ent = entSA.UbicarEntidadPorID(r.GetValue("identidad"))
                Dim f As New FormCrearDevoluciónRecl(ent.First,
                                                Integer.Parse(r.GetValue("idDocumento"))) ', FormMDI)
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog(Me)
                GetDetallePagos(Integer.Parse(r.GetValue("idDocumento")))

            ElseIf moduloR = "COMPRAS" Then

                Dim ent = entSA.UbicarEntidadPorID(r.GetValue("identidad"))
                Dim f As New FormCrearDevoluciónReclCobro(ent.First,
                                                Integer.Parse(r.GetValue("idDocumento"))) ', FormMDI)
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog(Me)
                GetDetallePagos(Integer.Parse(r.GetValue("idDocumento")))


            End If

        End If

    End Sub

    Private Sub GridResumenFormaPago_SelectedRecordsChanged(sender As Object, e As SelectedRecordsChangedEventArgs) Handles GridNotas.SelectedRecordsChanged
        'Cursor = Cursors.WaitCursor
        'If e.SelectedRecord IsNot Nothing Then
        '    Dim r As Record = e.SelectedRecord.Record
        '    If r IsNot Nothing Then
        '        If GridNotas.Table.Records.Count > 0 Then
        '            GetDetallePagos(Integer.Parse(r.GetValue("idDocumento")))
        '        End If
        '    End If
        'End If
        'Cursor = Cursors.Default
    End Sub

    Private Sub dgvKardexVal_TableControlDrawCell(sender As Object, e As GridTableControlDrawCellEventArgs) Handles GridGroupingControl1.TableControlDrawCell
        If e.Inner.Style.CellType = "PushButton" Then
            e.Inner.Cancel = True

            ' //Draw the Image in a cell.
            If e.Inner.ColIndex = 6 Then
                e.Inner.Style.Description = "Eliminar"
                e.Inner.Style.TextColor = Color.Black
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)
                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3),
                                           New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6)
                    )
                'Linea para agregar un icono
                ' e.Inner.Graphics.DrawImage(Me.ImageList1.Images(0), irect)
            End If
        End If
    End Sub

    Private Sub dgvKardexVal_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs) Handles GridGroupingControl1.TableControlPushButtonClick
        Me.Cursor = Cursors.WaitCursor
        Dim ventaSA As New documentoVentaAbarrotesSA
        Try
            If MessageBox.Show("Desea eliminar el pago seleccionado?", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                If e.Inner.ColIndex = 6 Then
                    Dim idDocumento = GridGroupingControl1.TableModel(e.Inner.RowIndex, 1).CellValue
                    ventaSA.EliminarPagoDevolucion(New documento With {
                                                   .idDocumento = idDocumento,
                                                   .idPrestamo = GridNotas.Table.CurrentRecord.GetValue("idDocumento")
                                                   })
                    GetDetallePagos(Integer.Parse(GridNotas.Table.CurrentRecord.GetValue("idDocumento")))
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        If moduloR = "VENTAS" Then
            GetNotas(estadoR)
        ElseIf moduloR = "COMPRAS" Then
            GetNotasCompras(estadoR)
        End If
    End Sub

    Private Sub GridNotas_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridNotas.TableControlCellClick

    End Sub

#End Region

End Class
