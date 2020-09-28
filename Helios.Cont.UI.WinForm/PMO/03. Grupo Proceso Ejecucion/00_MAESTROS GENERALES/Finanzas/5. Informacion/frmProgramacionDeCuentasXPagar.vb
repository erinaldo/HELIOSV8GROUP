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
Public Class frmProgramacionDeCuentasXPagar
#Region "Attributes"
    Private chk As Boolean, check As Boolean = False
    Private ht As New ArrayList()
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        FormatoGridPequeño(dgvObligaciones, True)
        FormatoGridPequeño(dgvObligacionesDetalle, True)
        ' Add any initialization after the InitializeComponent() call.
        'GridCFG(dgvUsuarioActivo)

    End Sub
#End Region

#Region "Methods"

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
            'dgvProcesoCrono.ShowGroupDropArea = False
            'dgvProcesoCrono.TableDescriptor.GroupedColumns.Clear()
            'dgvProcesoCrono.TableDescriptor.GroupedColumns.Add("nombres")

            'Me.dgvObligaciones.TableOptions.ListBoxSelectionMode = SelectionMode.One


        Else

        End If
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
        dt.Columns.Add("idBeneficiario", GetType(Integer))
        dt.Columns.Add("tipoBeneficiario", GetType(String))
        'documentoLibro = documentoVentaSA.GetCronogramaPagoCobro(TipoProg)
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
                            dr(15) = i.identidad
                            dr(16) = TIPO_ENTIDAD.PROVEEDOR

                        End With
                    Case TIPO_ENTIDAD.CLIENTE

                        With entidadSA.UbicarEntidadPorID(i.identidad).First
                            dr(6) = .nombreCompleto
                            dr(15) = i.identidad
                            dr(16) = TIPO_ENTIDAD.CLIENTE
                        End With
                    Case "TR"

                        With personaSA.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.identidad, "TR")
                            dr(6) = .nombreCompleto
                            dr(15) = i.identidad
                            dr(16) = "TR"
                        End With
                End Select

                'dr(6) = i.glosa

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

    Public Sub ConteoVencidosCronograma()
        Dim cronogramaSA As New CronogramaSA

        Dim conteo2 = cronogramaSA.ConteoVencidosCronograma()
        Dim conteo3 = cronogramaSA.ConteoDeNoNegociados()
        Dim conteo4 = cronogramaSA.ConteoDeAsientosNoNegociados()


        lblConteoCompra.Text = conteo3
        lblConteoAsiento.Text = conteo4
        lblVencidos.Text = conteo2

    End Sub
    'Public Sub ConteoVencidosCronogramaCobros()
    '    Dim cronogramaSA As New CronogramaSA

    '    Dim conteo2 = cronogramaSA.ConteoVencidosCobroCronograma()
    '    Dim conteo3 = cronogramaSA.ConteoVentasNoNegociados()
    '    Dim conteo4 = cronogramaSA.ConteoDeAsientosNoNegociadosCobro()


    '    lblConteoVenta.Text = conteo3
    '    lblConteoOtraVenta.Text = conteo4
    '    txtVencidoCobro.Text = conteo2

    'End Sub

#Region "TIMER"

#End Region
#End Region

#Region "Events"



    Private Sub dgvObligaciones_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvObligaciones.TableControlCellClick
        Dim style2 As GridTableCellStyleInfo = e.TableControl.Model(e.Inner.RowIndex, e.Inner.ColIndex)
        If style2.Enabled Then
            If style2.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso style2.TableCellIdentity.Column.Name = "check" Then
                e.Inner.Cancel = True
            End If
            Console.WriteLine(e.Inner.RowIndex.ToString() & "TableControlCellClick")
        End If
    End Sub

    Private Sub dgvObligaciones_TableControlCheckBoxClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvObligaciones.TableControlCheckBoxClick
        Dim style As GridTableCellStyleInfo = DirectCast(e.TableControl.GetTableViewStyleInfo(e.Inner.RowIndex, e.Inner.ColIndex), GridTableCellStyleInfo)
        Dim el As Element = Me.dgvObligaciones.Table.GetInnerMostCurrentElement()

        Dim colindexVal As Integer = style.CellIdentity.ColIndex

        Dim RowIndex2 As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.RowIndex
        If RowIndex2 > -1 Then
            Select Case colindexVal


                Case 14

                    '      Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(e.Inner.RowIndex, e.Inner.ColIndex), GridTableCellStyleInfo)
                    If style.Enabled Then
                        Dim column As Integer = Me.dgvObligaciones.TableModel.NameToColIndex("check")
                        ' Console.WriteLine("CheckBoxClicked")
                        '   Dim s = e.TableControl.Table.CurrentRecord.GetValue("colModVenta")
                        If style.Enabled AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell Then
                            chk = CBool(Me.dgvObligaciones.TableModel(style.TableCellIdentity.RowIndex, column).CellValue)

                            e.TableControl.BeginUpdate()

                            e.TableControl.EndUpdate(True)
                        End If
                        If style.Enabled AndAlso (style.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell OrElse style.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell) AndAlso style.TableCellIdentity.Column.Name = "check" Then
                            Dim currentRecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
                            Dim curStatus As Boolean = Boolean.Parse(style.Text)
                            e.TableControl.BeginUpdate()

                            If curStatus Then
                                '   CheckBoxValue = False
                            End If
                            If curStatus = True Then
                                Dim RowIndex As Integer = e.Inner.RowIndex
                                Dim ColIndex As Integer = e.Inner.ColIndex
                                '      MsgBox(False)
                                Me.dgvObligaciones.TableModel(RowIndex, 15).CellValue = "N" ' curStatus



                            Else
                                Dim RowIndex As Integer = e.Inner.RowIndex
                                Dim ColIndex As Integer = e.Inner.ColIndex
                                '     MsgBox(True)
                                Me.dgvObligaciones.TableModel(RowIndex, 15).CellValue = "S"

                                '******************************************************************

                            End If
                            e.TableControl.EndUpdate()
                            If ht.Contains(curStatus) AndAlso (Not ht.Contains((Not curStatus))) Then
                            ElseIf Not ht.Contains(curStatus) Then
                            End If
                            ht.Clear()
                        End If
                    End If
            End Select

            Me.dgvObligaciones.TableControl.Refresh()

        End If
    End Sub

    Private Sub ButtonAdv36_Click(sender As Object, e As EventArgs) Handles ButtonAdv36.Click
        Me.Cursor = Cursors.WaitCursor
        ButtonAdv64.Visible = False
        ButtonAdv65.Visible = False
        'If Not IsNothing(dgvObligaciones.Table.CurrentRecord) Then


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
        '.Label4.Text = "Obligaciones"
        '.cbotipo.Text = "PAGOS"
        f.Size = New Size(1340, 708)
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

    Private Sub ButtonAdv69_Click(sender As Object, e As EventArgs) Handles ButtonAdv69.Click
        ButtonAdv64.Visible = False
        ButtonAdv65.Visible = False

        Dim f As New frmFlujoAsientoManualPago
        f.StartPosition = FormStartPosition.CenterParent
        f.txtTipoConsulta.Text = "PAGO"
        '.Label4.Text = "Acreencias"
        '.cbotipo.Text = "COBROS"
        f.ShowDialog()
        ProgramacionObligacionesVencidos("P")
        ConteoVencidosCronograma()
    End Sub

    Private Sub ButtonAdv34_Click(sender As Object, e As EventArgs) Handles ButtonAdv34.Click
        Me.Cursor = Cursors.WaitCursor
        ButtonAdv64.Visible = False
        ButtonAdv65.Visible = False
        ProgramacionObligaciones("P", txtFechaInicio.Value, txtFechaFin.Value)

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

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Me.Cursor = Cursors.WaitCursor

        If Not IsNothing(dgvObligaciones.Table.CurrentRecord) Then

            Dim f As New frmDocumentosProgramadosProv
           
            f.txtBeneficiario.Text = dgvObligaciones.Table.CurrentRecord.GetValue("glosa")
            f.txtidBeneficiario.Text = dgvObligaciones.Table.CurrentRecord.GetValue("idBeneficiario")
            f.txtTipo.Text = dgvObligaciones.Table.CurrentRecord.GetValue("tipoBeneficiario")
           

            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()



        Else
            ' MessageBox.Show("Seleccione un Item a Editar")
            MessageBox.Show("Seleccione un Proveedor!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub frmProgramacionDeCuentasXPagar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub lblConteoCompra_Click(sender As Object, e As EventArgs) Handles lblConteoCompra.Click

    End Sub
End Class