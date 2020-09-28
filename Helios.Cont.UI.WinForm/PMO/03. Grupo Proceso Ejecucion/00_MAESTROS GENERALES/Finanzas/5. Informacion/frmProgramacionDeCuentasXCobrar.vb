Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Tools
Public Class frmProgramacionDeCuentasXCobrar
#Region "Attributes"

#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'GridCFG(dgvUsuarioActivo)
        FormatoGridPequeño(dgvAcreencias, True)
        FormatoGridPequeño(dgvAcreenciasDet, True)
        ConteoVencidosCronogramaCobros()

    End Sub
#End Region

#Region "Methods"

    Public Sub CronogramaAcreenciasDetalle(fechaprog As DateTime, fechaven As DateTime)

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
        dt.Columns.Add("serie", GetType(String))
        dt.Columns.Add("nrodoc", GetType(String))
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
        dt.Columns.Add("moneda", GetType(String))
        documentoLibro = documentoVentaSA.GetCronogramaDetalleCobro(fechaprog, fechaven)

        If Not IsNothing(documentoLibro) Then


            For Each i In documentoLibro
                Dim dr As DataRow = dt.NewRow()



                If IsNothing(i.identidad) Then

                Else

                    Select Case i.tipoRazon
                        Case TIPO_ENTIDAD.PROVEEDOR
                            dr(13) = i.identidad
                            With entidadSA.UbicarEntidadPorID(i.identidad).First
                                dr(0) = .nombreCompleto
                            End With
                        Case TIPO_ENTIDAD.CLIENTE
                            dr(13) = i.identidad
                            With entidadSA.UbicarEntidadPorID(i.identidad).First
                                dr(0) = .nombreCompleto
                            End With
                        Case "TR"
                            dr(13) = i.identidad
                            With personaSA.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.identidad, "TR")
                                dr(0) = .nombreCompleto
                            End With
                    End Select
                End If

                dr(1) = i.serie
                dr(2) = i.nrodoc

                dr(3) = i.montoAutorizadoMN
                dr(4) = i.montoAutorizadoME

                If i.tipo = "P" Then
                    dr(5) = "Pago"
                ElseIf i.tipo = "C" Then
                    dr(5) = "Cobro"
                End If

                dr(6) = CDec(0.0)
                dr(7) = CDec(0.0)
                dr(8) = i.glosa




                dr(9) = i.fechaoperacion
                dr(10) = i.fechaPago.GetValueOrDefault

                If i.estado = "PN" Then
                    dr(11) = "Pendiente"
                ElseIf i.estado = "AP" Then
                    dr(11) = "Aprobado"
                ElseIf i.estado = "OB" Then
                    dr(11) = "Observado"
                ElseIf i.estado = "PG" Then
                    dr(11) = "Desembolsado"
                End If

                dr(12) = i.idCronograma

                'dr(14) = i.idDocumentoRef
                dr(14) = i.idDocumentoRef
                dr(15) = i.moneda
                'monto += i.montoAutorizadoMN
                'montome += i.montoAutorizadoME


                dt.Rows.Add(dr)

            Next

            'txtImporteMN.Value = monto
            'txtImporteME.Value = montome

            dgvAcreenciasDet.DataSource = dt
            'dgvProcesoCrono.ShowGroupDropArea = False
            'dgvProcesoCrono.TableDescriptor.GroupedColumns.Clear()
            'dgvProcesoCrono.TableDescriptor.GroupedColumns.Add("nombres")

            Me.dgvAcreenciasDet.TableOptions.ListBoxSelectionMode = SelectionMode.One


        Else

        End If


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

    Public Sub ConteoVencidosCronogramaCobros()
        Dim cronogramaSA As New CronogramaSA

        Dim conteo2 = cronogramaSA.ConteoVencidosCobroCronograma()
        Dim conteo3 = cronogramaSA.ConteoVentasNoNegociados()
        Dim conteo4 = cronogramaSA.ConteoDeAsientosNoNegociadosCobro()


        lblConteoVenta.Text = conteo3
        lblConteoOtraVenta.Text = conteo4
        txtVencidoCobro.Text = conteo2

    End Sub

    Public Sub ConteoVentasVencidos()
        Dim cronogramaSA As New CronogramaSA

        ' Dim conteo2 = cronogramaSA.ConteoVencidosCobroCronograma()
        Dim conteo3 = cronogramaSA.ConteoVentasNoNegociados()
        'Dim conteo4 = cronogramaSA.ConteoDeAsientosNoNegociadosCobro()


        lblConteoVenta.Text = conteo3
        'lblConteoOtraVenta.Text = conteo4
        'txtVencidoCobro.Text = conteo2

    End Sub


    Public Sub ConteoOtrasObligacionesVencidos()
        Dim cronogramaSA As New CronogramaSA

        ' Dim conteo2 = cronogramaSA.ConteoVencidosCobroCronograma()
        ' Dim conteo3 = cronogramaSA.ConteoVentasNoNegociados()
        Dim conteo4 = cronogramaSA.ConteoDeAsientosNoNegociadosCobro()


        ' lblConteoVenta.Text = conteo3
        lblConteoOtraVenta.Text = conteo4
        'txtVencidoCobro.Text = conteo2

    End Sub


    Public Sub ConteoSoloVencidosCrono()
        Dim cronogramaSA As New CronogramaSA

        Dim conteo2 = cronogramaSA.ConteoVencidosCobroCronograma()
        ' Dim conteo3 = cronogramaSA.ConteoVentasNoNegociados()
        'Dim conteo4 = cronogramaSA.ConteoDeAsientosNoNegociadosCobro()


        ' lblConteoVenta.Text = conteo3
        'lblConteoOtraVenta.Text = conteo4
        txtVencidoCobro.Text = conteo2

    End Sub


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
        dt.Columns.Add("idBeneficiario", GetType(Integer))
        dt.Columns.Add("tipoBeneficiario", GetType(String))

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
                            dr(13) = i.identidad
                            dr(14) = TIPO_ENTIDAD.PROVEEDOR
                        End With
                    Case TIPO_ENTIDAD.CLIENTE

                        With entidadSA.UbicarEntidadPorID(i.identidad).First
                            dr(6) = .nombreCompleto
                            dr(13) = i.identidad
                            dr(14) = TIPO_ENTIDAD.CLIENTE
                        End With
                    Case "TR"

                        With personaSA.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.identidad, "TR")
                            dr(6) = .nombreCompleto
                            dr(13) = i.identidad
                            dr(14) = "TR"
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

#Region "TIMER"

#End Region
#End Region

#Region "Events"



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

        ConteoVentasVencidos()
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
        ConteoOtrasObligacionesVencidos()
    End Sub

    Private Sub ButtonAdv53_Click(sender As Object, e As EventArgs) Handles ButtonAdv53.Click
        Me.Cursor = Cursors.WaitCursor
        ButtonAdv71.Visible = True
        ButtonAdv72.Visible = True
        UbicarCronogramaVencidosCobro("C")
        ConteoSoloVencidosCrono()
        Me.Cursor = Cursors.Arrow
    End Sub


    Private Sub dgvAcreencias_SelectedRecordsChanging(sender As Object, e As SelectedRecordsChangedEventArgs) Handles dgvAcreencias.SelectedRecordsChanging
        'Me.Cursor = Cursors.WaitCursor
        ''GridGroupingControl2.Table.Records.DeleteAll()
        'If Not IsNothing(dgvAcreencias.Table.CurrentRecord) Then
        '    'UbicarDocumentoDetalle(dgvProcesoCrono.Table.CurrentRecord.GetValue("id"), "PR")
        '    If dgvAcreencias.Table.CurrentRecord.GetValue("tipo") = "Pago" Then

        '        'UbicarDocumentoDetalle(dgvProcesoCrono.Table.CurrentRecord.GetValue("fecha"))
        '    ElseIf dgvAcreencias.Table.CurrentRecord.GetValue("tipo") = "Cobro" Then

        '        CronogramaAcreenciasDetalle(dgvAcreencias.Table.CurrentRecord.GetValue("fecha"), dgvAcreencias.Table.CurrentRecord.GetValue("fechaPago"))

        '    ElseIf dgvAcreencias.Table.CurrentRecord.GetValue("tipo") = "Pago Asiento" Then

        '        'UbicarDocumentoDetalleAsiento(dgvProcesoCrono.Table.CurrentRecord.GetValue("fecha"))
        '    End If

        'End If
        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv71_Click(sender As Object, e As EventArgs) Handles ButtonAdv71.Click
        'Me.Cursor = Cursors.WaitCursor

        'If Not IsNothing(GridGroupingControl6.Table.CurrentRecord) Then

        '    Dim f As New frmMantenimientoCrono
        '    f.lblIdCronograma.Text = GridGroupingControl6.Table.CurrentRecord.GetValue("idcronograma")
        '    f.txtImporteMN.Value = GridGroupingControl6.Table.CurrentRecord.GetValue("monto")
        '    f.txtImporteME.Value = GridGroupingControl6.Table.CurrentRecord.GetValue("montome")
        '    f.txtGlosa.Text = GridGroupingControl6.Table.CurrentRecord.GetValue("glosa")
        '    f.txtProveedor.Text = GridGroupingControl6.Table.CurrentRecord.GetValue("nombres")
        '    f.txtFecha.Value = GridGroupingControl6.Table.CurrentRecord.GetValue("fecha")
        '    f.txtfechapago.Value = GridGroupingControl6.Table.CurrentRecord.GetValue("fechaPago")

        '    f.StartPosition = FormStartPosition.CenterParent
        '    f.ShowDialog()

        '    UbicarCronogramaVencidosCobro("C")

        'Else
        '    ' MessageBox.Show("Seleccione un Item a Editar")
        '    MessageBox.Show("Seleccione un Item a Editar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If

        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv72_Click(sender As Object, e As EventArgs) Handles ButtonAdv72.Click
        'Me.Cursor = Cursors.WaitCursor

        'If Not IsNothing(GridGroupingControl6.Table.CurrentRecord) Then

        '    If MessageBox.Show("Desea Eliminar el Item Seleccionado!", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then



        '        EliminarHijoCronograma(GridGroupingControl6.Table.CurrentRecord.GetValue("idcronograma"))
        '        GridGroupingControl6.Table.CurrentRecord.Delete()


        '    End If



        'Else
        '    ' MessageBox.Show("Seleccione un Item a Eliminar")
        '    MessageBox.Show("Seleccione un Item a Eliminar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If

        'Me.Cursor = Cursors.Arrow
    End Sub
#End Region

    Private Sub lblConteoVenta_Click(sender As Object, e As EventArgs) Handles lblConteoVenta.Click

    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Me.Cursor = Cursors.WaitCursor

        If Not IsNothing(dgvAcreencias.Table.CurrentRecord) Then

            Dim f As New frmDocumentosProgramadosCobro

            f.txtBeneficiario.Text = dgvAcreencias.Table.CurrentRecord.GetValue("glosa")
            f.txtidBeneficiario.Text = dgvAcreencias.Table.CurrentRecord.GetValue("idBeneficiario")
            f.txtTipo.Text = dgvAcreencias.Table.CurrentRecord.GetValue("tipoBeneficiario")


            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()



        Else
            ' MessageBox.Show("Seleccione un Item a Editar")
            MessageBox.Show("Seleccione un Proveedor!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub frmProgramacionDeCuentasXCobrar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class