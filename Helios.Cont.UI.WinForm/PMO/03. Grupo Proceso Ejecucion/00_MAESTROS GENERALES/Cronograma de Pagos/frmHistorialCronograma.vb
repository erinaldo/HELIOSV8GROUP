Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Imports System.Collections
Imports System.Collections.Specialized
Imports Syncfusion.Windows.Forms.Tools
Public Class frmHistorialCronograma

    Inherits frmMaster



    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        'Me.WindowState = FormWindowState.Maximized
        ' Add any initialization after the InitializeComponent() call.
        GridCFG(dgvProcesoCrono)

        SumarioColumnas()
    End Sub





#Region "Metodos"

    Public Sub UbicarDocumentoDetalleAsiento(fechaprog As DateTime)

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
        dt.Columns.Add("descripcion", GetType(String))
        documentoLibro = documentoVentaSA.GetCronogramaDetalleAsiento(fechaprog)

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

                dr(1) = " "
                dr(2) = i.nrodoc

                dr(3) = i.montoAutorizadoMN
                dr(4) = i.montoAutorizadoME

                If i.tipo = "P" Then
                    dr(5) = "Pago"
                ElseIf i.tipo = "C" Then
                    dr(5) = "Cobro"
                ElseIf i.tipo = "PA" Then
                    dr(5) = "Pago Asiento"
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
                dr(16) = i.descripcion
                'monto += i.montoAutorizadoMN
                'montome += i.montoAutorizadoME


                dt.Rows.Add(dr)

            Next

            'txtImporteMN.Value = monto
            'txtImporteME.Value = montome

            dgvDetalleCrono.DataSource = dt
            'dgvProcesoCrono.ShowGroupDropArea = False
            'dgvProcesoCrono.TableDescriptor.GroupedColumns.Clear()
            'dgvProcesoCrono.TableDescriptor.GroupedColumns.Add("nombres")

            Me.dgvDetalleCrono.TableOptions.ListBoxSelectionMode = SelectionMode.One


        Else

        End If


    End Sub


    Public Sub UbicarDocumentoDetalleCobro(fechaprog As DateTime, fechaVen As DateTime)

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
        documentoLibro = documentoVentaSA.GetCronogramaDetalleCobro(fechaprog, fechaVen)

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

            dgvDetalleCrono.DataSource = dt
            'dgvProcesoCrono.ShowGroupDropArea = False
            'dgvProcesoCrono.TableDescriptor.GroupedColumns.Clear()
            'dgvProcesoCrono.TableDescriptor.GroupedColumns.Add("nombres")

            Me.dgvDetalleCrono.TableOptions.ListBoxSelectionMode = SelectionMode.One


        Else

        End If


    End Sub


    Public Sub UbicarDocumentoDetalle(fechaprog As DateTime, fechaven As DateTime)

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
        documentoLibro = documentoVentaSA.GetCronogramaDetalle(fechaprog, fechaven)

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

            dgvDetalleCrono.DataSource = dt
            'dgvProcesoCrono.ShowGroupDropArea = False
            'dgvProcesoCrono.TableDescriptor.GroupedColumns.Clear()
            'dgvProcesoCrono.TableDescriptor.GroupedColumns.Add("nombres")

            Me.dgvDetalleCrono.TableOptions.ListBoxSelectionMode = SelectionMode.One


        Else

        End If


    End Sub


    Private Function sumColumnByNamePagos(Column As String) As Decimal
        Dim suma As Decimal = 0
        For Each i In dgvProcesoCrono.Table.Records

            If i.GetValue("tipo") = "Pago" Then
                Dim valNumber = i.GetValue(Column).ToString
                If valNumber.Trim.Length > 0 Then
                    suma += CDec(i.GetValue(Column))
                End If
            End If

        Next
        Return suma
    End Function

    Private Function sumColumnByNameCobros(Column As String) As Decimal
        Dim suma As Decimal = 0
        For Each i In dgvProcesoCrono.Table.Records

            If i.GetValue("tipo") = "Cobro" Then
                Dim valNumber = i.GetValue(Column).ToString
                If valNumber.Trim.Length > 0 Then
                    suma += CDec(i.GetValue(Column))
                End If
            End If

        Next
        Return suma
    End Function


    Private Sub SumarioColumnas()


        'RESULTADOS POR NATURALEZA
        Dim scd As New GridSummaryColumnDescriptor()
        scd.DataMember = "monto"
        scd.Name = "montoPago"
        scd.SummaryType = Syncfusion.Grouping.SummaryType.DoubleAggregate
        scd.Format = "{Sum:###,###,##0.00}" '"{Sum:#.00}"




        Dim scr As New GridSummaryRowDescriptor()
        scr.Name = "TOTAL"
        'scr.Name = "TOTALES PAGOS"
        scr.SummaryColumns.Add(scd)



        Me.dgvProcesoCrono.TableDescriptor.SummaryRows.Add(scr)


        ''RESULTADOS TOTALES
        'Dim scd3 As New GridSummaryColumnDescriptor()
        'scd3.DataMember = "monto"
        'scd3.Name = "montoCobro"
        'scd3.SummaryType = Syncfusion.Grouping.SummaryType.DoubleAggregate
        'scd3.Format = "{Sum:###,###,##0.00}" '"{Sum:#.00}"




        'Dim scr1 As New GridSummaryRowDescriptor()
        'scr1.Name = "TOTALES COBROS"
        'scr1.SummaryColumns.Add(scd3)

        'Me.dgvProcesoCrono.TableDescriptor.SummaryRows.Add(scr1)

    End Sub





    Dim colorx As New GridMetroColors()
    Sub GridCFG(GGC As GridGroupingControl)
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = False
        GGC.ShowColumnHeaders = True

        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        GGC.SetMetroStyle(colorx)
        GGC.BorderStyle = System.Windows.Forms.BorderStyle.None

        '  GGC.BrowseOnly = True
        GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        GGC.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        GGC.TableOptions.ListBoxSelectionMode = SelectionMode.One
        GGC.TableOptions.SelectionBackColor = Color.Gray
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.Format = "MMM dd yyyy"
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.Hide
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).HeaderText = "Date"
        'Me.gridGroupingControl1.TableDescriptor.Columns(1).HeaderText = "Category"
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.Currency
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromArgb(168, 178, 189)
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.TextAlign = GridTextAlign.Left

        'this.gridGroupingControl1.TableDescriptor.Columns["Amount"].Width = (this.tableLayoutPanel3.Width / 5) - 50;
        GGC.AllowProportionalColumnSizing = False
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        GGC.Table.DefaultColumnHeaderRowHeight = 27
        GGC.Table.DefaultRecordRowHeight = 20
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub


    Public Sub EliminarHijoCronograma(iddocumento As Integer)
        Dim objeto As New CronogramaSA

        objeto.DeleteHijoCronograma(iddocumento)

    End Sub



    Private Sub Programacion(TipoProg As String)
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

        documentoLibro = documentoVentaSA.GetCronogramaPagoCobroHistorial(TipoProg)

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
                dr(10) = 0
                dr(12) = 0
                dt.Rows.Add(dr)

            Next


            dgvProcesoCrono.DataSource = dt
            'dgvProcesoCrono.ShowGroupDropArea = False
            'dgvProcesoCrono.TableDescriptor.GroupedColumns.Clear()
            'dgvProcesoCrono.TableDescriptor.GroupedColumns.Add("nombres")

            Me.dgvProcesoCrono.TableOptions.ListBoxSelectionMode = SelectionMode.One


        Else

        End If
    End Sub
#End Region

    Private Sub frmMasterCronograma_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmMasterCronograma_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Programacion()
    End Sub







    'Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click

    '    If Not IsNothing(dgvProcesoCrono.Table.CurrentRecord) Then

    '        With frmMantenimientoCrono
    '            .lblIdCronograma.Text = dgvProcesoCrono.Table.CurrentRecord.GetValue("idcronograma")
    '            .txtImporteMN.Value = dgvProcesoCrono.Table.CurrentRecord.GetValue("monto")
    '            .txtImporteME.Value = dgvProcesoCrono.Table.CurrentRecord.GetValue("montome")
    '            .txtGlosa.Text = dgvProcesoCrono.Table.CurrentRecord.GetValue("glosa")
    '            .txtProveedor.Text = dgvProcesoCrono.Table.CurrentRecord.GetValue("nombres")
    '            .txtFecha.Value = dgvProcesoCrono.Table.CurrentRecord.GetValue("fecha")
    '            .ShowDialog()
    '        End With




    '    End If


    'End Sub

   

   







    Dim hoveredIndex As Integer = 0

    Dim selectionColl As New Hashtable()

    Private Sub dgvProcesoCrono_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvProcesoCrono.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            Me.dgvProcesoCrono.TableControl.Selections.Clear()
        End If

        Select Case e.TableCellIdentity.TableCellType
            Case GridTableCellType.SummaryFieldCell
                If e.TableCellIdentity.SummaryColumn.Name = "montoPago" Then

                    Dim pagos As Decimal = sumColumnByNamePagos("monto")
                    'Dim sumaHaber As Decimal = sumColumnByNameCobros("invHaber")


                    e.Style.CellValue = pagos


                End If

                If e.TableCellIdentity.SummaryColumn.Name = "montoCobro" Then

                    'Dim sumaDebe As Decimal = sumColumnByNamePagos("monto")
                    Dim cobros As Decimal = sumColumnByNameCobros("monto")



                    e.Style.CellValue = cobros


                End If


                Exit Select
        End Select
    End Sub

    Private Sub dgvProcesoCrono_SelectedRecordsChanging(sender As Object, e As SelectedRecordsChangedEventArgs) Handles dgvProcesoCrono.SelectedRecordsChanging
        Me.Cursor = Cursors.WaitCursor
        'GridGroupingControl2.Table.Records.DeleteAll()
        If Not IsNothing(dgvProcesoCrono.Table.CurrentRecord) Then
            'UbicarDocumentoDetalle(dgvProcesoCrono.Table.CurrentRecord.GetValue("id"), "PR")
            If dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo") = "Pago" Then

                UbicarDocumentoDetalle(dgvProcesoCrono.Table.CurrentRecord.GetValue("fecha"), dgvProcesoCrono.Table.CurrentRecord.GetValue("fechaPago"))
            ElseIf dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo") = "Cobro" Then

                UbicarDocumentoDetalleCobro(dgvProcesoCrono.Table.CurrentRecord.GetValue("fecha"), dgvProcesoCrono.Table.CurrentRecord.GetValue("fechaPago"))

            ElseIf dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo") = "Pago Asiento" Then

                UbicarDocumentoDetalleAsiento(dgvProcesoCrono.Table.CurrentRecord.GetValue("fecha"))
            End If

        End If
        Me.Cursor = Cursors.Arrow
    End Sub



    Private Sub dgvProcesoCrono_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvProcesoCrono.TableControlCellClick

    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(dgvProcesoCrono.Table.CurrentRecord) Then


            With frmCronogramaKanban

                If dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo") = "Pago" Then

                    .Programacion(dgvProcesoCrono.Table.CurrentRecord.GetValue("fecha"), "P", dgvProcesoCrono.Table.CurrentRecord.GetValue("fechaPago"))
                    '.txtTipoProgramacion.Text = "PAGOS"
                ElseIf dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo") = "Cobro" Then

                    .Programacion(dgvProcesoCrono.Table.CurrentRecord.GetValue("fecha"), "C", dgvProcesoCrono.Table.CurrentRecord.GetValue("fechaPago"))
                    '.txtTipoProgramacion.Text = "COBROS"
                ElseIf dgvProcesoCrono.Table.CurrentRecord.GetValue("tipo") = "Pago Asiento" Then

                    .Programacion(dgvProcesoCrono.Table.CurrentRecord.GetValue("fecha"), "PA", dgvProcesoCrono.Table.CurrentRecord.GetValue("fechaPago"))
                    ' .txtTipoProgramacion.Text = "PAGOS ASIENTO"

                End If


                '.txtFechaVen.Value = dgvProcesoCrono.Table.CurrentRecord.GetValue("fechaPago")
                '.txtFecha.Value = dgvProcesoCrono.Table.CurrentRecord.GetValue("fecha")
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With

        Else
            ' MessageBox.Show("Seleccione un Item a Eliminar")
            MessageBox.Show("Seleccione un Programacion para trabajar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

   

 


    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click
        Me.Cursor = Cursors.WaitCursor
        'If txtTipoProgramacion.Text = "PAGOS" Then
        '    Programacion("P")
        'ElseIf txtTipoProgramacion.Text = "COBROS" Then
        '    Programacion("C")
        'End If
        If ComboBox1.Text = "PAGOS" Then
            Programacion("P")
        ElseIf ComboBox1.Text = "COBROS" Then
            Programacion("C")
        ElseIf ComboBox1.Text = "OTROS PAGOS " Then
            Programacion("PA")
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        Me.Cursor = Cursors.WaitCursor

        If Not IsNothing(dgvDetalleCrono.Table.CurrentRecord) Then

            With frmMantenimientoCrono
                .lblIdCronograma.Text = dgvDetalleCrono.Table.CurrentRecord.GetValue("idcronograma")
                .txtImporteMN.Value = dgvDetalleCrono.Table.CurrentRecord.GetValue("monto")
                .txtImporteME.Value = dgvDetalleCrono.Table.CurrentRecord.GetValue("montome")
                .txtGlosa.Text = dgvDetalleCrono.Table.CurrentRecord.GetValue("glosa")
                '.txtProveedor.Text = dgvDetalleCrono.Table.CurrentRecord.GetValue("nombres")
                .txtProveedor.Visible = False

                .txtFecha.Value = dgvDetalleCrono.Table.CurrentRecord.GetValue("fecha")
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With


        Else
            ' MessageBox.Show("Seleccione un Item a Editar")
            MessageBox.Show("Seleccione un Item a Editar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click
        Me.Cursor = Cursors.WaitCursor

        If Not IsNothing(dgvDetalleCrono.Table.CurrentRecord) Then

            If MessageBox.Show("Desea Eliminar el Item Seleccionado!", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then



                EliminarHijoCronograma(dgvDetalleCrono.Table.CurrentRecord.GetValue("idcronograma"))
                dgvDetalleCrono.Table.CurrentRecord.Delete()

            End If



        Else
            ' MessageBox.Show("Seleccione un Item a Eliminar")
            MessageBox.Show("Seleccione un Item a Eliminar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub
End Class