Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Cont.Business.Entity

Public Class frmActaConstitucionAprobado
    Dim Tipo As String

    Public Structure TIPO_RECURSO
        Const FULL = "F"
        Const PORITEM = "I"
    End Structure

    Public Sub ObtenerListaCotizacion(strTipoRecurso As String)
        Dim recursoSA As New actividadRecursoSA
        Try
            dgvPropuesta.Rows.Clear()
            For Each i In recursoSA.ListaRecursosCotizacionGastoFinal(GProyectos.IdProyecto, strTipoRecurso, "C")

                dgvPropuesta.Rows.Add(i.idActividad, i.idActividadRecurso, i.fechaIngreso, i.Descripcion,
                                      "Seleccionar", i.detalleExtra, i.unidadMedida, i.cant,
                                      i.costoUnit, i.igvImporte, i.precioFinal, "LC", i.ReferenciaSustento, i.Total, _
                                      0, 0, 0, 0, i.idItem)
            Next
            For Each i In recursoSA.ListaRecursosGastosFinal(GProyectos.IdProyecto, strTipoRecurso, "G")
                dgvPropuesta.Rows.Add(i.idActividad, i.idActividadRecurso, i.fechaIngreso.Value.Date, i.Descripcion, i.TipoRecurso,
                                   i.detalleExtra, i.unidadMedida, i.CantRequerida,
                                      i.ValorMercadoPu, i.Igv, i.NetoPagar, "LG", i.ReferenciaSustento, i.Total, 0, _
                                      0, 0, 0, i.idItem)
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        Dispose()
    End Sub

    Private Sub LinkLabel1_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles LinkLabel1.MouseClick
        LinkLabel1.ContextMenuStrip.Show(LinkLabel1, e.Location)
        Tipo = TIPO_RECURSO.FULL
    End Sub

    Private Sub dgvPropuesta_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPropuesta.CellContentClick
        If e.ColumnIndex = 4 Then
            ContextMenuStrip2.Show(dgvPropuesta, dgvPropuesta.PointToClient(Windows.Forms.Cursor.Position))
            Tipo = TIPO_RECURSO.PORITEM
        End If
    End Sub

    Private Sub EXISTENCIAToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EXISTENCIAToolStripMenuItem.Click
        Select Case Tipo
            Case "F"
                For i As Integer = 0 To dgvPropuesta.Rows.Count - 1
                    dgvPropuesta.Rows(i).Cells(4).Value = "EX"
                Next
            Case "I"
                dgvPropuesta.Item(4, dgvPropuesta.CurrentRow.Index).Value = "EX"
        End Select
    End Sub

    Private Sub SERVICIOCONTRATOToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SERVICIOCONTRATOToolStripMenuItem.Click
        Select Case Tipo
            Case "F"
                For i As Integer = 0 To dgvPropuesta.Rows.Count - 1
                    dgvPropuesta.Rows(i).Cells(4).Value = "GS"
                Next
            Case "I"
                dgvPropuesta.Item(4, dgvPropuesta.CurrentRow.Index).Value = "GS"
        End Select
    End Sub

    Private Sub RECURSOSHUMANOSToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RECURSOSHUMANOSToolStripMenuItem.Click
        Select Case Tipo
            Case "F"
                For i As Integer = 0 To dgvPropuesta.Rows.Count - 1
                    dgvPropuesta.Rows(i).Cells(4).Value = "RH"
                Next
            Case "I"
                dgvPropuesta.Item(4, dgvPropuesta.CurrentRow.Index).Value = "RH"
        End Select

    End Sub

    Sub Grabar()
        Dim objDetalle As New detalleitems
        Dim detalleSA As New detalleitemsSA
        Dim recursoSA As New actividadRecursoSA
        Dim objrecurso As New actividadRecurso
        Dim ListaRecurso As New List(Of actividadRecurso)
        Dim ListaRecursoCalculo As New List(Of actividadRecurso)
        'Dim ListaLiquidacion As New List(Of totalesLiquidacion)
        'Dim objLiquidacionDet As New totalesLiquidacion()
        Dim conteo As Integer = 0
        Dim codigoDetalle As Integer
        Dim tipoCuenta As Integer = 0

        Try
            For Each J As DataGridViewRow In dgvPropuesta.Rows
                codigoDetalle = Nothing
                If (J.Cells(4).Value = "EX") Then
                    tipoCuenta = "602111"
                ElseIf (J.Cells(4).Value = "GS") Then
                    tipoCuenta = "63"
                ElseIf (J.Cells(4).Value = "RH") Then
                    tipoCuenta = "62"
                ElseIf (J.Cells(4).Value = "Seleccionar" Or J.Cells(4).Value = "K") Then
                    conteo += 1
                End If
                objrecurso = New actividadRecurso With {
                           .Action = Business.Entity.BaseBE.EntityAction.INSERT,
                           .idProyecto = GProyectos.IdProyectoActividad,
                           .IdEstablecimiento = GEstableciento.IdEstablecimiento,
                           .Idempresa = Gempresas.IdEmpresaRuc,
                           .idActividadRecurso = J.Cells(1).Value,
                           .idActividad = J.Cells(0).Value,
                           .idItem = codigoDetalle,
                           .TipoRecurso = J.Cells(4).Value,
                           .Clasificacion = J.Cells(18).Value,
                           .tipoPlan = "AP",
                           .unidadMedida = J.Cells(6).Value,
                           .cuentaContable = tipoCuenta,
                           .Tipo = J.Cells(11).Value}

                ListaRecurso.Add(objrecurso)

                ''LIQUIDACION INSERT
                'objLiquidacionDet = New totalesLiquidacion()

                'objLiquidacionDet.idEmpresa = Gempresas.IdEmpresaRuc
                'objLiquidacionDet.idEstablecimiento = GEstableciento.IdEstablecimiento
                'objLiquidacionDet.idActividad = GProyectos.IdProyecto
                'objLiquidacionDet.tipoLiquidacion = "INCIDENCIA DIRECTA"
                'objLiquidacionDet.Otros = "CADIN"
                'objLiquidacionDet.modulo = "N"
                'objLiquidacionDet.Fecha = DateTime.Now.Date

                'objLiquidacionDet.LI_ib_ini = 0 ' nudIgv.Value  'IGV
                'objLiquidacionDet.LI_ib_ns = 0 'nudIgv.Value 'IGV
                'objLiquidacionDet.LI_ib_adic = 0 ' nudIgv.Value 'IGV

                'objLiquidacionDet.RefSustento1 = J.Cells(12).Value 'i.LI_cfAcum_ini

                'Select Case J.Cells(12).Value
                '    Case TipoReferenciaSustento.COSTO_IGV
                '        'PRIMERO(REPORTE)
                '        objLiquidacionDet.LI_cfAcum_ini = Math.Round((CDec(J.Cells(13).Value) / 1.18) * 0.18, 2) 'i.LI_cfAcum_ini
                '        objLiquidacionDet.LI_cfAcum_ns = Math.Round((CDec(J.Cells(13).Value) / 1.18) * 0.18, 2) ' i.LI_cfAcum_ns
                '        objLiquidacionDet.LI_afAcum_adic = Math.Round((CDec(J.Cells(13).Value) / 1.18) * 0.18, 2) ' i.LI_afAcum_adic

                '        'segundo(reporte)
                '        objLiquidacionDet.LR_costov_ini = Math.Round((CDec(J.Cells(13).Value) / 1.18) + CDec(J.Cells(14).Value) + CDec(J.Cells(15).Value), 2)
                '        objLiquidacionDet.LR_costov_ns = Math.Round((CDec(J.Cells(13).Value) / 1.18) + +CDec(J.Cells(14).Value) + CDec(J.Cells(15).Value), 2)
                '        objLiquidacionDet.LR_costov_adic = Math.Round((CDec(J.Cells(13).Value) / 1.18) + +CDec(J.Cells(14).Value) + CDec(J.Cells(15).Value), 2)

                '        '3er reporte
                '        objLiquidacionDet.LOO_ReDeAp_ini = Math.Round(CDec(J.Cells(14).Value) + CDec(J.Cells(15).Value) + CDec(J.Cells(16).Value) + CDec(J.Cells(17).Value), 2)
                '        objLiquidacionDet.LOO_ReDeAp_ns = Math.Round(CDec(J.Cells(14).Value) + CDec(J.Cells(15).Value) + CDec(J.Cells(16).Value) + CDec(J.Cells(17).Value), 2)
                '        objLiquidacionDet.LOO_ReDeAp_adic = Math.Round(CDec(J.Cells(14).Value) + CDec(J.Cells(15).Value) + CDec(J.Cells(16).Value) + CDec(J.Cells(17).Value), 2)

                '        'ANALISIS FINANCIERO
                '        objLiquidacionDet.AF_TotalPagoProvSust_ini = CDec(J.Cells(13).Value)
                '        objLiquidacionDet.AF_TotalPagoProvSust_ns = CDec(J.Cells(13).Value)
                '        objLiquidacionDet.AF_TotalPagoProvSust_adic = CDec(J.Cells(13).Value)

                '    Case TipoReferenciaSustento.SOLO_COSTO
                '        'PRIMERO(REPORTE)
                '        objLiquidacionDet.LI_cfAcum_ini = 0 'i.LI_cfAcum_ini
                '        objLiquidacionDet.LI_cfAcum_ns = 0 ' i.LI_cfAcum_ns
                '        objLiquidacionDet.LI_afAcum_adic = 0 ' i.LI_afAcum_adic

                '        'segundo(reporte)
                '        objLiquidacionDet.LR_costov_ini = Math.Round((CDec(J.Cells(13).Value)) + CDec(J.Cells(14).Value) + CDec(J.Cells(15).Value), 2)
                '        objLiquidacionDet.LR_costov_ns = Math.Round((CDec(J.Cells(13).Value)) + +CDec(J.Cells(14).Value) + CDec(J.Cells(15).Value), 2)
                '        objLiquidacionDet.LR_costov_adic = Math.Round((CDec(J.Cells(13).Value)) + +CDec(J.Cells(14).Value) + CDec(J.Cells(15).Value), 2)
                '        '3er reporte
                '        objLiquidacionDet.LOO_ReDeAp_ini = Math.Round(CDec(J.Cells(14).Value) + CDec(J.Cells(15).Value) + CDec(J.Cells(16).Value) + CDec(J.Cells(17).Value), 2)
                '        objLiquidacionDet.LOO_ReDeAp_ns = Math.Round(CDec(J.Cells(14).Value) + CDec(J.Cells(15).Value) + CDec(J.Cells(16).Value) + CDec(J.Cells(17).Value), 2)
                '        objLiquidacionDet.LOO_ReDeAp_adic = Math.Round(CDec(J.Cells(14).Value) + CDec(J.Cells(15).Value) + CDec(J.Cells(16).Value) + CDec(J.Cells(17).Value), 2)

                '        'ANALISIS FINANCIERO
                '        objLiquidacionDet.AF_TotalPagoProvSust_ini = CDec(J.Cells(13).Value)
                '        objLiquidacionDet.AF_TotalPagoProvSust_ns = CDec(J.Cells(13).Value)
                '        objLiquidacionDet.AF_TotalPagoProvSust_adic = CDec(J.Cells(13).Value)
                '    Case TipoReferenciaSustento.NO_SUSTENTADO
                '        objLiquidacionDet.LI_cfAcum_ini = 0 'i.LI_cfAcum_ini
                '        objLiquidacionDet.LI_cfAcum_ns = 0 ' i.LI_cfAcum_ns
                '        objLiquidacionDet.LI_afAcum_adic = 0 ' i.LI_afAcum_adic
                '        'segundo(reporte)
                '        objLiquidacionDet.LR_costov_ini = Math.Round(0 + CDec(J.Cells(14).Value) + CDec(J.Cells(15).Value), 2)
                '        objLiquidacionDet.LR_costov_ns = Math.Round(0 + +CDec(J.Cells(14).Value) + CDec(J.Cells(15).Value), 2)
                '        objLiquidacionDet.LR_costov_adic = Math.Round(0 + +CDec(J.Cells(14).Value) + CDec(J.Cells(15).Value), 2)
                '        '3er reporte
                '        objLiquidacionDet.LOO_ReDeAp_ini = Math.Round(CDec(J.Cells(14).Value) + CDec(J.Cells(15).Value) + CDec(J.Cells(16).Value) + CDec(J.Cells(17).Value), 2)
                '        objLiquidacionDet.LOO_ReDeAp_ns = Math.Round(CDec(J.Cells(14).Value) + CDec(J.Cells(15).Value) + CDec(J.Cells(16).Value) + CDec(J.Cells(17).Value), 2)
                '        objLiquidacionDet.LOO_ReDeAp_adic = Math.Round(CDec(J.Cells(14).Value) + CDec(J.Cells(15).Value) + CDec(J.Cells(16).Value) + CDec(J.Cells(17).Value), 2)

                '        'ANALISIS FINANCIERO
                '        objLiquidacionDet.AF_TotalPagoProvSust_ini = 0.0
                '        objLiquidacionDet.AF_TotalPagoProvSust_ns = 0.0
                '        objLiquidacionDet.AF_TotalPagoProvSust_adic = 0.0
                'End Select

                ''no sustentados
                'If (J.Cells(12).Value = "NO SUSTENTADO") Then
                '    objLiquidacionDet.AF_RefGastoNoSust_ini = CDec(J.Cells(13).Value)
                'Else
                '    objLiquidacionDet.AF_RefGastoNoSust_ini = 0
                'End If

                'If (J.Cells(12).Value = "NO SUSTENTADO") Then
                '    objLiquidacionDet.AF_RefGastoNoSust_ns = CDec(J.Cells(13).Value)
                'Else
                '    objLiquidacionDet.AF_RefGastoNoSust_ns = 0
                'End If

                'objLiquidacionDet.LP_TotalPagoProvCSSust_ini = CDec(J.Cells(13).Value)
                'objLiquidacionDet.LP_TotalPagoProvCSSust_ns = CDec(J.Cells(13).Value)
                'objLiquidacionDet.LP_TotalPagoProvCSSust_adic = CDec(J.Cells(13).Value)

                'objLiquidacionDet.tipoPlan = "AP"

                'objLiquidacionDet.usuarioActualizacion = "NN"
                'objLiquidacionDet.fechaActualizacion = DateTime.Now
                'ListaLiquidacion.Add(objLiquidacionDet)

            Next
            If (conteo > 0) Then
                lblEstado.Text = "Debe ingresar el tipo de recurso a todos los Items"
                lblEstado.Image = My.Resources.cross
            Else
                With frmActaConstitucionMaster
                    recursoSA.InsertCotizacionFinal(ListaRecurso)
                    'recursoSA.UpdateCotizacionFinal(ListaRecurso)
                    UpdateEDT(GProyectos.IdProyecto, GProyectos.IdProyectoActividad, "EDT")
                    UpdateProyecto("APROBADO")
                    frmActaConstitucionMaster.lblAprobado.Enabled = False
                    .validarCotizacion()
                    GModoProyecto = "Aprobado"
                    lblEstado.Text = "Cotización agregada!"
                    lblEstado.Image = My.Resources.ok4
                    Dispose()
                End With
            End If
        Catch ex As Exception
            lblEstado.Text = "Error al grabar cotización" & vbCrLf & ex.Message
            lblEstado.Image = My.Resources.cross
        End Try

    End Sub

    Public Sub UpdateProyecto(strOpcion As String)
        Dim ProyectoPlaneacionSA As New ProyectoPlaneacionSA
        Dim ProyectoPlaneacion As New ProyectoPlaneacion
        Try
            Select Case strOpcion
                Case "APROBADO"
                    ProyectoPlaneacion = New ProyectoPlaneacion With {
                    .estadoCosto = "A",
                    .idProyecto = GProyectos.IdProyectoActividad,
                    .idEmpresa = Gempresas.IdEmpresaRuc,
                    .idEstablecimiento = GEstableciento.IdEstablecimiento,
                    .fechaModificacion = Date.Now}
            End Select
            If (ProyectoPlaneacionSA.EditarProyecto(ProyectoPlaneacion)) Then
                lblEstado.Image = My.Resources.ok4
            End If
        Catch ex As Exception
            lblEstado.Image = My.Resources.cross
        End Try
    End Sub

    Public Sub UpdateEDT(IntIDProyecto As Integer, IntIDActividad As Integer, strModulo As String)
        Dim ActividadSA As New ActividadesSA
        Dim Actividad As New Actividades
        Dim ListaActividad As New List(Of Actividades)
        Try
            ActividadSA.GrabarActividadListaEDT(GProyectos.IdProyectoActividad, GProyectos.IdProyecto, "A")
            lblEstado.Image = My.Resources.ok4
        Catch ex As Exception
            lblEstado.Image = My.Resources.cross
        End Try
    End Sub


    Private Sub GuardarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles GuardarToolStripButton.Click
        Grabar()
    End Sub
End Class