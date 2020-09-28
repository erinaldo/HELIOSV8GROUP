Imports Helios.Cont.Business.Entity
Imports Helios.General
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Public Class frmReporteContableMasterDetalle
    Public Sub BuscarMovimientosdetalle(strCuenta As String)
        Dim documentoSA As New MovimientoSA
        dgvMovimientoDetalle.Rows.Clear()

        For Each i In documentoSA.GetUbicarDocumentoDetallePorIdDocumento(strCuenta)
            Select Case i.tipo
                Case "D"
                    dgvMovimientoDetalle.Rows.Add(i.idmovimiento,
                       i.origen,
                                 i.fechaActualizacion,
                                 i.nombreEntidad,
                                 i.descripcion,
                                 i.nroDoc,
                                 i.monto,
                                 i.Montocero,
                                 i.montoUSD,
                                 i.Montocero)
                Case "H"
                    dgvMovimientoDetalle.Rows.Add(i.idmovimiento,
                                                 i.origen,
                                i.fechaActualizacion,
                                 i.nombreEntidad,
                                 i.descripcion,
                                 i.nroDoc,
                                 i.Montocero,
                                 i.monto,
                                 i.Montocero,
                                 i.montoUSD)
            End Select
        Next
    End Sub

    Public Sub SetFormattingDetalle()
        With Me.dgvMovimientoDetalle
            .Columns("debe").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("haber").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("debeUSD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("haberUSD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With

    End Sub
End Class