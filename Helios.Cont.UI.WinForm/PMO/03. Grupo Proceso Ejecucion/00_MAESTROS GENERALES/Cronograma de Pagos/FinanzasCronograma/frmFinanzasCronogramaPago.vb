Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess

Public Class frmFinanzasCronogramaPago
    Inherits frmMaster

#Region "Contructores"

    Public Sub New()

        InitializeComponent()
        txtFechaInicio.Value = DateTime.Now
        txtFechaFin.Value = DateTime.Now
        ConteoVencidosCronograma()
    End Sub

#End Region

#Region "Metodos"

    Public Sub EliminarHijoCronograma(iddocumento As Integer)
        Dim objeto As New CronogramaSA

        objeto.DeleteHijoCronograma(iddocumento)

    End Sub

    Public Sub ConteoVencidosCronograma()
        Dim cronogramaSA As New CronogramaSA

        Dim conteo2 = cronogramaSA.ConteoVencidosCronograma()
        Dim conteo3 = cronogramaSA.ConteoDeNoNegociados()
        Dim conteo4 = cronogramaSA.ConteoDeAsientosNoNegociados()

        lblConteoCompra.Text = conteo3
        lblConteoAsiento.Text = conteo4
        lblVencidos.Text = conteo2

    End Sub

    Private Sub ProgramacionObligaciones(TipoProg As String, fechainicio As Date, fechafin As Date)
        Dim documentoVentaSA As New CronogramaSA
        Dim documentoLibro As New List(Of Cronograma)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable
        Dim entidadSA As New entidadSA
        Dim personaSA As New PersonaSA
        'Dim monto As Decimal = CDec(0.0)
        'Dim montome As Decimal = CDec(0.0)
        'Dim strPeriodo As String = String.Format("{0:00}", Convert.ToInt32(txtPeriodo.Value.Month)) & "/" & txtPeriodo.Value.Year

        dgvObligaciones.Table.Records.DeleteAll()

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

        documentoLibro = documentoVentaSA.UbicarCronogramaFecha(TipoProg, fechainicio, fechafin)


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
                dr(10) = i.idCronograma
                dr(12) = i.idDocumentoRef
                dr(13) = False
                dr(14) = "N"

                dt.Rows.Add(dr)

            Next

            dgvObligaciones.DataSource = dt
            dgvObligaciones.TableDescriptor.Columns("fecha").Width = 0
            dgvObligaciones.TableDescriptor.Columns("fechaPago").Width = 0

        Else

        End If
    End Sub

    Private Sub ProgramacionObligacionesVencidos(TipoProg As String)
        Dim documentoVentaSA As New CronogramaSA
        Dim documentoLibro As New List(Of Cronograma)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable
        Dim entidadSA As New entidadSA
        Dim personaSA As New PersonaSA
        'Dim monto As Decimal = CDec(0.0)
        'Dim montome As Decimal = CDec(0.0)


        'Dim strPeriodo As String = String.Format("{0:00}", Convert.ToInt32(txtPeriodo.Value.Month)) & "/" & txtPeriodo.Value.Year
        dgvObligaciones.Table.Records.DeleteAll()

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
        documentoLibro = documentoVentaSA.UbicarCronogramaVencidos(TipoProg)


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


            dgvObligaciones.DataSource = dt

            dgvObligaciones.TableDescriptor.Columns("fecha").Width = 100
            dgvObligaciones.TableDescriptor.Columns("fechaPago").Width = 100

        Else

        End If
    End Sub


#End Region

#Region "Eventos"

    Private Sub ButtonAdv34_Click(sender As Object, e As EventArgs) Handles ButtonAdv34.Click
        Me.Cursor = Cursors.WaitCursor
        ButtonAdv64.Visible = False
        ButtonAdv65.Visible = False
        ProgramacionObligaciones("P", txtFechaInicio.Value, txtFechaFin.Value)

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv36_Click(sender As Object, e As EventArgs) Handles ButtonAdv36.Click
        Me.Cursor = Cursors.WaitCursor
        ButtonAdv64.Visible = False
        ButtonAdv65.Visible = False

        Dim f As New frmCronogramaKanban
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        ProgramacionObligaciones("P", txtFechaInicio.Value, txtFechaFin.Value)
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv68_Click(sender As Object, e As EventArgs) Handles ButtonAdv68.Click
        ButtonAdv64.Visible = False
        ButtonAdv65.Visible = False

        Dim f As New frmDeudaMensualProveedor
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub

    Private Sub ButtonAdv35_Click(sender As Object, e As EventArgs) Handles ButtonAdv35.Click
        ButtonAdv64.Visible = False
        ButtonAdv65.Visible = False
        Dim f As New frmFlujoPagos
        f.StartPosition = FormStartPosition.CenterParent
        f.Size = New Size(1340, 708)
        f.ShowDialog()
        ProgramacionObligacionesVencidos("P")
        ConteoVencidosCronograma()
    End Sub

    Private Sub ButtonAdv69_Click(sender As Object, e As EventArgs) Handles ButtonAdv69.Click
        ButtonAdv64.Visible = False
        ButtonAdv65.Visible = False

        Dim f As New frmFlujoAsientoManualPago
        f.StartPosition = FormStartPosition.CenterParent
        f.txtTipoConsulta.Text = "PAGO"
        f.ShowDialog()
        ProgramacionObligacionesVencidos("P")
        ConteoVencidosCronograma()
    End Sub

    Private Sub ButtonAdv66_Click(sender As Object, e As EventArgs) Handles ButtonAdv66.Click
        Me.Cursor = Cursors.WaitCursor
        ButtonAdv64.Visible = True
        ButtonAdv65.Visible = True
        ProgramacionObligacionesVencidos("P")
        ConteoVencidosCronograma()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv64_Click(sender As Object, e As EventArgs) Handles ButtonAdv64.Click
        Me.Cursor = Cursors.WaitCursor

        If Not IsNothing(dgvObligaciones.Table.CurrentRecord) Then

            Dim f As New frmMantenimientoCrono
            f.lblIdCronograma.Text = dgvObligaciones.Table.CurrentRecord.GetValue("idcronograma")
            f.txtImporteMN.Value = dgvObligaciones.Table.CurrentRecord.GetValue("monto")
            f.txtImporteME.Value = dgvObligaciones.Table.CurrentRecord.GetValue("montome")
            f.txtGlosa.Text = dgvObligaciones.Table.CurrentRecord.GetValue("glosa")
            f.txtProveedor.Text = dgvObligaciones.Table.CurrentRecord.GetValue("nombres")
            f.txtFecha.Value = dgvObligaciones.Table.CurrentRecord.GetValue("fecha")
            f.txtfechapago.Value = dgvObligaciones.Table.CurrentRecord.GetValue("fechaPago")

            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()

            ProgramacionObligacionesVencidos("P")

        Else
            ' MessageBox.Show("Seleccione un Item a Editar")
            MessageBox.Show("Seleccione un Item a Editar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv65_Click(sender As Object, e As EventArgs) Handles ButtonAdv65.Click
        Me.Cursor = Cursors.WaitCursor

        If Not IsNothing(dgvObligaciones.Table.CurrentRecord) Then

            If MessageBox.Show("Desea Eliminar el Item Seleccionado!", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                EliminarHijoCronograma(dgvObligaciones.Table.CurrentRecord.GetValue("idcronograma"))
                dgvObligaciones.Table.CurrentRecord.Delete()

            End If

        Else
            ' MessageBox.Show("Seleccione un Item a Eliminar")
            MessageBox.Show("Seleccione un Item a Eliminar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

#End Region

End Class