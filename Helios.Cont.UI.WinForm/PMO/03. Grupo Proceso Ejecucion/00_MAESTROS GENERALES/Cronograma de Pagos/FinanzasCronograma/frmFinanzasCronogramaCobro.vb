Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Tools

Public Class frmFinanzasCronogramaCobro
    Inherits frmMaster

#Region "Contructores"

    Public Sub New()
        InitializeComponent()
        txtFechaCobro.Value = DateTime.Now
        txtFechaCobroFin.Value = DateTime.Now
        ConteoVencidosCronogramaCobros()
    End Sub

#End Region

#Region "Metodos"

    Private Sub CronogramaAcreencias(TipoProg As String, fechainicio As Date, fechafin As Date)
        Dim documentoVentaSA As New CronogramaSA
        Dim documentoLibro As New List(Of Cronograma)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable
        Dim entidadSA As New entidadSA
        Dim personaSA As New PersonaSA
        'Dim monto As Decimal = CDec(0.0)
        'Dim montome As Decimal = CDec(0.0)


        'Dim strPeriodo As String = String.Format("{0:00}", Convert.ToInt32(txtPeriodo.Value.Month)) & "/" & txtPeriodo.Value.Year


        dt.Columns.Add("nombres", GetType(String))
        dt.Columns.Add("monto", GetType(Decimal))
        dt.Columns.Add("montome", GetType(Decimal))
        dt.Columns.Add("tipo", GetType(String))
        dt.Columns.Add("importe", GetType(Decimal))
        dt.Columns.Add("importeme", GetType(Decimal))
        dt.Columns.Add("glosa", GetType(String))
        dt.Columns.Add("fecha", GetType(Date))
        dt.Columns.Add("fechaPago", GetType(Date))
        dt.Columns.Add("estado", GetType(String))
        dt.Columns.Add("idcronograma", GetType(Integer))
        dt.Columns.Add("id", GetType(Integer))
        dt.Columns.Add("idDocRef", GetType(Integer))

        documentoLibro = documentoVentaSA.GetCronogramaCobroFecha(TipoProg, fechainicio, fechafin)

        If Not IsNothing(documentoLibro) Then


            For Each i In documentoLibro
                Dim dr As DataRow = dt.NewRow()

                dr(11) = 0
                dr(0) = "N"

                dr(1) = i.montoAutorizadoMN
                dr(2) = i.montoAutorizadoME

                If i.tipo = "P" Then
                    dr(3) = "Pago"
                ElseIf i.tipo = "C" Then
                    dr(3) = "Cobro"
                ElseIf i.tipo = "CA" Then
                    dr(3) = "Cobro Asiento"
                ElseIf i.tipo = "PA" Then

                    dr(3) = "Pago Asiento"
                End If

                dr(4) = CDec(0.0)
                dr(5) = CDec(0.0)
                'dr(6) = i.glosa
                Select Case i.tipoRazon
                    Case TIPO_ENTIDAD.PROVEEDOR

                        With entidadSA.UbicarEntidadPorID(i.identidad).First
                            dr(6) = .nombreCompleto

                        End With
                    Case TIPO_ENTIDAD.CLIENTE

                        With entidadSA.UbicarEntidadPorID(i.identidad).First
                            dr(6) = .nombreCompleto
                        End With
                    Case "TR"

                        With personaSA.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.identidad, "TR")
                            dr(6) = .nombreCompleto
                        End With
                End Select

                dr(7) = i.fechaoperacion
                dr(8) = i.fechaPago
                dr(9) = "N"
                dr(10) = 0
                dr(12) = 0
                dt.Rows.Add(dr)

            Next


            dgvAcreencias.DataSource = dt
            dgvAcreencias.TableDescriptor.Columns("fecha").Width = 0
            dgvAcreencias.TableDescriptor.Columns("fechaPago").Width = 0
            'dgvProcesoCrono.ShowGroupDropArea = False
            'dgvProcesoCrono.TableDescriptor.GroupedColumns.Clear()
            'dgvProcesoCrono.TableDescriptor.GroupedColumns.Add("nombres")

            ' Me.dgvAcreencias.TableOptions.ListBoxSelectionMode = SelectionMode.One


        Else

        End If
    End Sub

    Public Sub ConteoVencidosCronogramaCobros()
        Dim cronogramaSA As New CronogramaSA

        Dim conteo2 = cronogramaSA.ConteoVencidosCobroCronograma()
        Dim conteo3 = cronogramaSA.ConteoVentasNoNegociados()
        Dim conteo4 = cronogramaSA.ConteoDeAsientosNoNegociadosCobro()


        lblConteoVenta.Text = conteo3
        lblConteoOtraVenta.Text = conteo4
        txtVencidoCobro.Text = conteo2

    End Sub

    Public Sub ConteoVencidosCronogramaAsientos()
        Dim cronogramaSA As New CronogramaSA

        'Dim conteo2 = cronogramaSA.ConteoVencidosCobroCronograma()
        'Dim conteo3 = cronogramaSA.ConteoVentasNoNegociados()
        Dim conteo4 = cronogramaSA.ConteoDeAsientosNoNegociadosCobro()


        'lblConteoVenta.Text = conteo3
        lblConteoOtraVenta.Text = conteo4
        'txtVencidoCobro.Text = conteo2

    End Sub

    Public Sub ConteoVencidosCronogramaVen()
        Dim cronogramaSA As New CronogramaSA

        Dim conteo2 = cronogramaSA.ConteoVencidosCobroCronograma()
        'Dim conteo3 = cronogramaSA.ConteoVentasNoNegociados()
        'Dim conteo4 = cronogramaSA.ConteoDeAsientosNoNegociadosCobro()


        'lblConteoVenta.Text = conteo3
        'lblConteoOtraVenta.Text = conteo4
        txtVencidoCobro.Text = conteo2

    End Sub

    Public Sub ConteoVencidosDocumentoNoProg()
        Dim cronogramaSA As New CronogramaSA

        'Dim conteo2 = cronogramaSA.ConteoVencidosCobroCronograma()
        Dim conteo3 = cronogramaSA.ConteoVentasNoNegociados()
        'Dim conteo4 = cronogramaSA.ConteoDeAsientosNoNegociadosCobro()


        lblConteoVenta.Text = conteo3
        'lblConteoOtraVenta.Text = conteo4
        'txtVencidoCobro.Text = conteo2

    End Sub

    Private Sub UbicarCronogramaVencidosCobro(TipoProg As String)
        Dim documentoVentaSA As New CronogramaSA
        Dim documentoLibro As New List(Of Cronograma)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable
        Dim entidadSA As New entidadSA
        Dim personaSA As New PersonaSA
        'Dim monto As Decimal = CDec(0.0)
        'Dim montome As Decimal = CDec(0.0)

        'Dim strPeriodo As String = String.Format("{0:00}", Convert.ToInt32(txtPeriodo.Value.Month)) & "/" & txtPeriodo.Value.Year
        dgvAcreencias.Table.Records.DeleteAll()

        dt.Columns.Add("nombres", GetType(String))
        dt.Columns.Add("monto", GetType(Decimal))
        dt.Columns.Add("montome", GetType(Decimal))
        dt.Columns.Add("tipo", GetType(String))
        dt.Columns.Add("importe", GetType(Decimal))
        dt.Columns.Add("importeme", GetType(Decimal))
        dt.Columns.Add("glosa", GetType(String))
        dt.Columns.Add("fecha", GetType(Date))
        dt.Columns.Add("fechaPago", GetType(Date))
        dt.Columns.Add("estado", GetType(String))
        dt.Columns.Add("idcronograma", GetType(Integer))
        dt.Columns.Add("id", GetType(Integer))
        dt.Columns.Add("idDocRef", GetType(Integer))
        dt.Columns.Add("check", GetType(Boolean))
        dt.Columns.Add("valcheck", GetType(String))

        'documentoLibro = documentoVentaSA.GetCronogramaPagoCobro(TipoProg)
        documentoLibro = documentoVentaSA.UbicarCronogramaVencidosCobro(TipoProg)


        If Not IsNothing(documentoLibro) Then


            For Each i In documentoLibro
                Dim dr As DataRow = dt.NewRow()

                dr(11) = 0
                dr(0) = "N"

                dr(1) = i.montoAutorizadoMN
                dr(2) = i.montoAutorizadoME

                If i.tipo = "P" Then
                    dr(3) = "Pago"
                ElseIf i.tipo = "C" Then
                    dr(3) = "Cobro"
                ElseIf i.tipo = "PA" Then

                    dr(3) = "Pago Asiento"
                End If

                dr(4) = CDec(0.0)
                dr(5) = CDec(0.0)
                dr(6) = i.glosa

                dr(7) = i.fechaoperacion
                dr(8) = i.fechaPago
                dr(9) = "N"
                dr(10) = i.idCronograma
                dr(12) = i.idDocumentoRef

                dr(13) = False
                dr(14) = "N"

                dt.Rows.Add(dr)

            Next


            dgvAcreencias.DataSource = dt

            dgvAcreencias.TableDescriptor.Columns("fecha").Width = 100
            dgvAcreencias.TableDescriptor.Columns("fechaPago").Width = 100
            'dgvProcesoCrono.ShowGroupDropArea = False
            'dgvProcesoCrono.TableDescriptor.GroupedColumns.Clear()
            'dgvProcesoCrono.TableDescriptor.GroupedColumns.Add("nombres")

            'Me.dgvObligaciones.TableOptions.ListBoxSelectionMode = SelectionMode.One


        Else

        End If
    End Sub

    Public Sub EliminarHijoCronograma(iddocumento As Integer)
        Dim objeto As New CronogramaSA

        objeto.DeleteHijoCronograma(iddocumento)

    End Sub

#End Region

#Region "Eventos"

    Private Sub ButtonAdv31_Click(sender As Object, e As EventArgs) Handles ButtonAdv31.Click
        Me.Cursor = Cursors.WaitCursor
        ButtonAdv71.Visible = False
        ButtonAdv72.Visible = False
        'ProgramacionObligaciones("P", txtFechaInicio.Value, txtFechaFin.Value)
        CronogramaAcreencias("C", txtFechaCobro.Value, txtFechaCobroFin.Value)
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv50_Click(sender As Object, e As EventArgs) Handles ButtonAdv50.Click
        ButtonAdv71.Visible = False
        ButtonAdv72.Visible = False

        Dim f As New frmCobroMensualProveedor
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub

    Private Sub ButtonAdv51_Click(sender As Object, e As EventArgs) Handles ButtonAdv51.Click
        ButtonAdv71.Visible = False
        ButtonAdv72.Visible = False
        Dim f As New frmFlujoCobros
        f.StartPosition = FormStartPosition.CenterParent
        '.Label4.Text = "Acreencias"
        '.cbotipo.Text = "COBROS"
        f.ShowDialog()

        ConteoVencidosDocumentoNoProg()
    End Sub

    Private Sub ButtonAdv52_Click(sender As Object, e As EventArgs) Handles ButtonAdv52.Click
        ButtonAdv71.Visible = False
        ButtonAdv72.Visible = False

        Dim f As New frmFlujoAsientoManualPago
        f.StartPosition = FormStartPosition.CenterParent
        f.txtTipoConsulta.Text = "COBRO"
        '.Label4.Text = "Acreencias"
        '.cbotipo.Text = "COBROS"
        f.ShowDialog()
        'ProgramacionObligacionesVencidos("P")
        ConteoVencidosCronogramaAsientos()
    End Sub

    Private Sub ButtonAdv53_Click(sender As Object, e As EventArgs) Handles ButtonAdv53.Click
        Me.Cursor = Cursors.WaitCursor
        ButtonAdv71.Visible = True
        ButtonAdv72.Visible = True
        UbicarCronogramaVencidosCobro("C")
        ConteoVencidosCronogramaCobros()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv71_Click(sender As Object, e As EventArgs) Handles ButtonAdv71.Click
        Me.Cursor = Cursors.WaitCursor

        If Not IsNothing(dgvAcreencias.Table.CurrentRecord) Then

            Dim f As New frmMantenimientoCrono
            f.lblIdCronograma.Text = dgvAcreencias.Table.CurrentRecord.GetValue("idcronograma")
            f.txtImporteMN.Value = dgvAcreencias.Table.CurrentRecord.GetValue("monto")
            f.txtImporteME.Value = dgvAcreencias.Table.CurrentRecord.GetValue("montome")
            f.txtGlosa.Text = dgvAcreencias.Table.CurrentRecord.GetValue("glosa")
            f.txtProveedor.Text = dgvAcreencias.Table.CurrentRecord.GetValue("nombres")
            f.txtFecha.Value = dgvAcreencias.Table.CurrentRecord.GetValue("fecha")
            f.txtfechapago.Value = dgvAcreencias.Table.CurrentRecord.GetValue("fechaPago")

            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()

            UbicarCronogramaVencidosCobro("C")
            ConteoVencidosCronogramaVen()

        Else
            ' MessageBox.Show("Seleccione un Item a Editar")
            MessageBox.Show("Seleccione un Item a Editar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv72_Click(sender As Object, e As EventArgs) Handles ButtonAdv72.Click
        Me.Cursor = Cursors.WaitCursor

        If Not IsNothing(dgvAcreencias.Table.CurrentRecord) Then

            If MessageBox.Show("Desea Eliminar el Item Seleccionado!", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then



                EliminarHijoCronograma(dgvAcreencias.Table.CurrentRecord.GetValue("idcronograma"))
                dgvAcreencias.Table.CurrentRecord.Delete()


            End If



        Else
            ' MessageBox.Show("Seleccione un Item a Eliminar")
            MessageBox.Show("Seleccione un Item a Eliminar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

#End Region

End Class