Imports Helios.Cont.Business.Entity
Imports Helios.General
'Imports Helios.Planilla.Business.Entity

Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
'Imports Helios.Planilla.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmMantenimientoCaja

#Region "Métodos"
    Public Sub EliminarTransferencia(intIdDocumento As Integer)
        Dim documentoSA As New DocumentoSA
        Dim documento As New documento

        With documento
            .idDocumento = intIdDocumento
        End With

        documentoSA.EliminarTransferenciaCaja(documento)
        lsvProduccion.SelectedItems(0).Remove()
        lblEstado.Text = "Transferencia eliminada!"
    End Sub

    Public Sub EliminarOtrosMovimientos(intIdDocumento As Integer)
        Dim documentoSA As New DocumentoSA
        Dim documento As New documento

        With documento
            .idDocumento = intIdDocumento
        End With

        documentoSA.EliminarOtrosMovimientosCaja(documento)
        lsvProduccion.SelectedItems(0).Remove()
        lblEstado.Text = "Movimiento eliminado!"
    End Sub

    Public Sub ListadoMovimientos(strPeriodo As String)
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim tablaSA As New tablaDetalleSA
        Dim entidadSA As New EstadosFinancierosSA
        Dim strEntidadF As String = Nothing
        Try
            lsvProduccion.Items.Clear()
            For Each i As documentoCaja In documentoCajaSA.ObtenerMovimientosPorPeriodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, strPeriodo)
                Dim n As New ListViewItem(i.idDocumento)
                n.SubItems.Add(i.fechaCobro)
                Select Case i.tipoOperacion
                    Case "TEC"
                        If i.tipoMovimiento = "PG" Then
                            n.SubItems.Add("TRANFERENCIA DE DINERO")
                            n.SubItems.Add(tablaSA.GetUbicarTablaID(1, i.tipoDocPago).descripcion)
                            n.SubItems.Add(i.numeroOperacion)
                            With entidadSA.GetUbicar_estadosFinancierosPorID(i.entidadFinanciera)
                                strEntidadF = .descripcion
                            End With
                            n.SubItems.Add(strEntidadF)
                            With entidadSA.GetUbicar_estadosFinancierosPorID(i.entidadFinancieraDestino)
                                strEntidadF = .descripcion
                            End With
                            n.SubItems.Add(strEntidadF)
                            n.SubItems.Add(i.moneda)
                            n.SubItems.Add(i.montoSoles)
                            n.SubItems.Add(i.tipoCambio)
                            n.SubItems.Add(i.montoUsd)
                            lsvProduccion.Items.Add(n)
                        End If
                    Case "OEC"
                        n.SubItems.Add("OTRAS ENTRADAS A CAJA")
                        n.SubItems.Add(tablaSA.GetUbicarTablaID(1, i.tipoDocPago).descripcion)
                        n.SubItems.Add(i.numeroOperacion)
                        'With entidadSA.GetUbicar_estadosFinancierosPorID(i.entidadFinanciera)
                        '    strEntidadF = .descripcion
                        'End With
                        n.SubItems.Add(String.Empty)
                        With entidadSA.GetUbicar_estadosFinancierosPorID(i.entidadFinanciera)
                            strEntidadF = .descripcion
                        End With
                        n.SubItems.Add(strEntidadF)
                        n.SubItems.Add(i.moneda)
                        n.SubItems.Add(i.montoSoles)
                        n.SubItems.Add(i.tipoCambio)
                        n.SubItems.Add(i.montoUsd)
                        lsvProduccion.Items.Add(n)
                    Case "OSC"
                        n.SubItems.Add("OTRAS SALIDAS DE CAJA")
                        n.SubItems.Add(tablaSA.GetUbicarTablaID(1, i.tipoDocPago).descripcion)
                        n.SubItems.Add(i.numeroOperacion)
                        With entidadSA.GetUbicar_estadosFinancierosPorID(i.entidadFinanciera)
                            strEntidadF = .descripcion
                        End With
                        n.SubItems.Add(strEntidadF)
                        'With entidadSA.GetUbicar_estadosFinancierosPorID(i.entidadFinancieraDestino)
                        '    strEntidadF = .descripcion
                        'End With
                        n.SubItems.Add(String.Empty)
                        n.SubItems.Add(i.moneda)
                        n.SubItems.Add(i.montoSoles)
                        n.SubItems.Add(i.tipoCambio)
                        n.SubItems.Add(i.montoUsd)
                        lsvProduccion.Items.Add(n)
                End Select
              
            Next
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try
    End Sub
#End Region


    Private Sub NuevoToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles NuevoToolStripButton.Click
        With frmCajaMovimientos
            .manipulacionEstado = ENTITY_ACTIONS.INSERT
            .lblPeriodo.Text = lblPeriodo.Text
            .txtEstablecimientoDestino.ValueMember = GEstableciento.IdEstablecimiento
            .txtEstablecimientoDestino.Text = GEstableciento.NombreEstablecimiento
            .txtEstablecimientoOrigen.ValueMember = GEstableciento.IdEstablecimiento
            .txtEstablecimientoOrigen.Text = GEstableciento.NombreEstablecimiento
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
    End Sub

    Private Sub frmMantenimientoCaja_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub ToolStripButton7_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton7.Click
        '   frmPMO.Panel3.Width = 249
        Dispose()
    End Sub

    Private Sub cboPeriodo_Click(sender As System.Object, e As System.EventArgs) Handles cboPeriodo.Click

    End Sub

    Private Sub cboPeriodo_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboPeriodo.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        Select Case cboPeriodo.Text
            Case "ENERO"
                lblPeriodo.Text = "01" & "/" & PeriodoGeneral
            Case "FEBRERO"
                lblPeriodo.Text = "02" & "/" & PeriodoGeneral
            Case "MARZO"
                lblPeriodo.Text = "03" & "/" & PeriodoGeneral
            Case "ABRIL"
                lblPeriodo.Text = "04" & "/" & PeriodoGeneral
            Case "MAYO"
                lblPeriodo.Text = "05" & "/" & PeriodoGeneral
            Case "JUNIO"
                lblPeriodo.Text = "06" & "/" & PeriodoGeneral
            Case "JULIO"
                lblPeriodo.Text = "07" & "/" & PeriodoGeneral
            Case "AGOSTO"
                lblPeriodo.Text = "08" & "/" & PeriodoGeneral
            Case "SETIEMBRE"
                lblPeriodo.Text = "09" & "/" & PeriodoGeneral
            Case "OCTUBRE"
                lblPeriodo.Text = "10" & "/" & PeriodoGeneral
            Case "NOVIEMBRE"
                lblPeriodo.Text = "11" & "/" & PeriodoGeneral
            Case "DICIEMBRE"
                lblPeriodo.Text = "12" & "/" & PeriodoGeneral
        End Select
        ListadoMovimientos(lblPeriodo.Text)
        ContextMenuStrip1.Hide()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lblPeriodo_Click(sender As System.Object, e As System.EventArgs) Handles lblPeriodo.Click

    End Sub

    Private Sub lblPeriodo_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lblPeriodo.MouseUp
        Dim p As Point = e.Location
        p.Offset(lblPeriodo.Bounds.Location)
        ContextMenuStrip1.Show(ToolStrip4.PointToScreen(p))
        cboPeriodo.DroppedDown = True
    End Sub

    Private Sub GuardarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles GuardarToolStripButton.Click
        If lsvProduccion.SelectedItems.Count > 0 Then
            If lsvProduccion.SelectedItems(0).SubItems(2).Text = "TRANFERENCIA DE DINERO" Then
                If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    EliminarTransferencia(lsvProduccion.SelectedItems(0).SubItems(0).Text)
                End If
            Else
                If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    EliminarOtrosMovimientos(lsvProduccion.SelectedItems(0).SubItems(0).Text)
                End If

            End If
        End If
    End Sub

    Private Sub AbrirToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles AbrirToolStripButton.Click
        Me.Cursor = Cursors.WaitCursor
        If lsvProduccion.SelectedItems.Count > 0 Then
            Select Case lsvProduccion.SelectedItems(0).SubItems(2).Text
                Case "TRANSFERENCIA ENTRE CAJAS"

                Case "OTRAS ENTRADAS A CAJA", "OTRAS SALIDAS DE CAJA"
                    With frmCajaMovimientos
                        .manipulacionEstado = ENTITY_ACTIONS.UPDATE
                        .UbicarDocumento(lsvProduccion.SelectedItems(0).SubItems(0).Text)
                        .StartPosition = FormStartPosition.CenterParent
                        .ShowDialog()
                    End With
            End Select

        End If
        Me.Cursor = Cursors.Arrow
    End Sub
End Class