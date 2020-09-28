Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmHistorialPagosMembresia

#Region "Métodos"
    Public Sub EliminarDocumento(intIdDocumento As Integer)
        Dim documentoSA As New DocumentoSA
        Dim nDocumento As New documento()
        With nDocumento
            .idDocumento = intIdDocumento
        End With
        documentoSA.EliminarDocumentoCaja(nDocumento)
        lsvHistorial.SelectedItems(0).Remove()
        lblEstado.Text = "Pago eliminado correctamente"
        lblEstado.Image = My.Resources.ok4
    End Sub

    Public Sub Totales()
        Dim tsoles As Decimal = 0
        Dim tDolares As Decimal = 0
        Try
            For Each i As ListViewItem In lsvHistorial.Items
                tsoles += CDec(i.SubItems(10).Text)
                tDolares += CDec(i.SubItems(11).Text)
            Next
            lblSoles.Text = tsoles.ToString("N2")
            lblDolares.Text = tDolares.ToString("N2")
        Catch ex As Exception
            MsgBox("Calculos erróneos" & ex.Message, MsgBoxStyle.Information, "Aviso de Sistema")
        End Try
    End Sub

    Public Sub ObtenerHistorialPagos(ByVal intIdDocumento As Integer)

        Dim objLista As New DocumentoCajaDetalleSA
        Dim grupoActual As Integer = 0
        Dim g As New ListViewGroup
        Try
            lsvHistorial.Items.Clear()
            'lsvHistorial.Columns.Clear()
            'lsvHistorial.Columns.Add("ID Compra", 0) '0
            'lsvHistorial.Columns.Add("ID Proveedor", 0) '01
            'lsvHistorial.Columns.Add("Proveedor", 147) '02
            'lsvHistorial.Columns.Add("Fecha Cobro", 79) '03
            'lsvHistorial.Columns.Add("Moneda", 58) '04
            'lsvHistorial.Columns.Add("Tipo Doc", 0) '05
            'lsvHistorial.Columns.Add("Comprobante", 90) '06
            'lsvHistorial.Columns.Add("T/C", 60) '07
            'lsvHistorial.Columns.Add("Número Operación", 112) '08
            'lsvHistorial.Columns.Add("ID Documento", 0) '09
            'lsvHistorial.Columns.Add("S/.", 80) '10
            'lsvHistorial.Columns.Add("USD", 80) '11
            'lsvHistorial.Columns.Add("ITF S/.", 0) '12
            'lsvHistorial.Columns.Add("ITF USD", 0) '13

            For Each i As documentoCajaDetalle In objLista.ObtenerHistorialPagos(intIdDocumento)
                If i.idDocumento <> grupoActual Then
                    g = New ListViewGroup("Pago nro.: " & i.idDocumento & "-" & i.nomDocumento)
                    grupoActual = i.idDocumento
                    lsvHistorial.Groups.Add(g)
                End If

                Dim n As New ListViewItem(i.documentoAfectado)
                n.SubItems.Add(i.idCliente)
                n.SubItems.Add(i.nomEntidad)
                n.SubItems.Add(i.fechaDoc)
                n.SubItems.Add(i.moneda)
                n.SubItems.Add(i.tipoDocumento)
                n.SubItems.Add(i.nomDocumento)
                n.SubItems.Add(i.tipoCambioTransacc)
                n.SubItems.Add(i.numeroDocNormal)
                n.SubItems.Add(i.idDocumento)
                n.SubItems.Add(i.montoSoles)
                n.SubItems.Add(i.montoUsd)
                n.Group = g
                lsvHistorial.Items.Add(n)
            Next
            Totales()
        Catch ex As Exception
            MsgBox("Error al cargar Datos. " & ex.Message)
        End Try
    End Sub
#End Region

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        Dispose()
    End Sub

    Private Sub GuardarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles GuardarToolStripButton.Click
        If lsvHistorial.SelectedItems.Count > 0 Then
            If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                EliminarDocumento(lsvHistorial.SelectedItems(0).SubItems(9).Text)
            End If
        End If
    End Sub

    Private Sub AbrirToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles AbrirToolStripButton.Click
        If lsvHistorial.SelectedItems.Count > 0 Then
            With frmModalCobro
                .Estado = ENTITY_ACTIONS.UPDATE
                .StartPosition = FormStartPosition.CenterParent
                .UbicarDocumento(lsvHistorial.SelectedItems(0).SubItems(9).Text)
                .lblIdDocumento.Text = lsvHistorial.SelectedItems(0).SubItems(0).Text
                .ShowDialog()
            End With
        End If

    End Sub
End Class