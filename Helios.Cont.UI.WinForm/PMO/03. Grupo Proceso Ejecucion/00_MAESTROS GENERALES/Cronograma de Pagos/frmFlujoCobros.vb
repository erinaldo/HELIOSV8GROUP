Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Tools

Public Class frmFlujoCobros
    Inherits frmMaster



    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GridCFG(dgvCobranzas)
        'GridCFG(dgvCobroProgramado)
        'GetTableGrid2()

        ' txtFecha.Value = DateTime.Now
        ' txtfechaprogramacion.Value = DateTime.Now
        'txtPeriodo.Value = New DateTime(AnioGeneral, MesGeneral, DateTime.Now.Day)

        'getConfigGrid()
    End Sub

#Region "Metodos"


    'Sub GrabarCronograma()
    '    Dim cronoSA As New CronogramaSA
    '    Dim obj As New Cronograma
    '    Dim lista As New List(Of Cronograma)
    '    Try
    '        For Each i As Record In dgvCobroProgramado.Table.Records

    '            If i.GetValue("pago") > 0 Then
    '                obj = New Cronograma

    '                ' obj.identidad = i.GetValue("idProveedor")
    '                Dim prove As Integer = i.GetValue("idproveedor")
    '                obj.identidad = prove
    '                'obj.tipoRazon = i.GetValue("tipoProv")
    '                'obj.tipoRazon = "PR"

    '                'obj.moneda = i.GetValue("moneda")
    '                If i.GetValue("moneda") = "NAC" Then
    '                    obj.moneda = "1"
    '                ElseIf i.GetValue("moneda") = "EXT" Then
    '                    obj.moneda = "2"
    '                End If

    '                'obj.tipocambio = CDec(i.GetValue("tipocambio"))
    '                obj.tipocambio = TmpTipoCambio

    '                obj.montoAutorizadoMN = CDec(i.GetValue("pago"))
    '                obj.montoAutorizadoME = CDec(i.GetValue("pagome"))
    '                obj.glosa = "COBRO A CLIENTES"
    '                'obj.tipoRazon = i.GetValue("tipoProv")
    '                obj.tipoRazon = "CL"

    '                'If i.GetValue("tipo") = "Pago" Then

    '                obj.tipo = "C"

    '                'ElseIf i.GetValue("tipo") = "Cobro" Then
    '                '    obj.tipo = "C"
    '                'End If

    '                obj.idDocumentoRef = i.GetValue("idDocumento")

    '                obj.fechaPago = txtFecha.Value
    '                obj.fechaoperacion = txtfechaprogramacion.Value

    '                obj.usuarioActualizacion = usuario.IDUsuario
    '                obj.fechaActualizacion = DateTime.Now
    '                obj.idDocumentoPago = 0
    '                lista.Add(obj)


    '            ElseIf i.GetValue("pagome") > 0 Then

    '                obj = New Cronograma
    '                Dim prove As Integer = i.GetValue("idproveedor")
    '                obj.identidad = prove
    '                If i.GetValue("moneda") = "NAC" Then
    '                    obj.moneda = "1"
    '                ElseIf i.GetValue("moneda") = "EXT" Then
    '                    obj.moneda = "2"
    '                End If
    '                obj.tipocambio = TmpTipoCambio
    '                obj.montoAutorizadoMN = CDec(i.GetValue("pago"))
    '                obj.montoAutorizadoME = CDec(i.GetValue("pagome"))
    '                obj.glosa = "COBRO A CLIENTES"
    '                obj.tipoRazon = "PR"
    '                obj.tipo = "C"
    '                obj.idDocumentoRef = i.GetValue("idDocumento")
    '                obj.fechaPago = txtFecha.Value
    '                obj.fechaoperacion = txtfechaprogramacion.Value

    '                obj.usuarioActualizacion = usuario.IDUsuario
    '                obj.fechaActualizacion = DateTime.Now
    '                obj.idDocumentoPago = 0
    '                lista.Add(obj)
    '            End If
    '        Next
    '        cronoSA.InsetCronograma(lista)
    '        Dispose()
    '    Catch ex As Exception
    '        'lblEstado.Text = ex.Message
    '        'PanelError.Visible = True
    '        'Timer1.Enabled = True
    '        'TiempoEjecutar(10)
    '    End Try
    'End Sub





    'Sub GetTableGrid2()
    '    Dim dt As New DataTable()


    '    dt.Columns.Add("idDocumento", GetType(Integer))
    '    dt.Columns.Add("idproveedor", GetType(Integer))
    '    dt.Columns.Add("tipoprov", GetType(String))
    '    dt.Columns.Add("nombres", GetType(String))
    '    dt.Columns.Add("fecha", GetType(String))
    '    dt.Columns.Add("tipoVenta", GetType(String))
    '    dt.Columns.Add("tipoDoc", GetType(String))
    '    dt.Columns.Add("serie", GetType(String))
    '    dt.Columns.Add("numero", GetType(String))
    '    dt.Columns.Add("moneda", GetType(String))
    '    dt.Columns.Add("tipoCambio", GetType(Decimal))
    '    dt.Columns.Add("pago", GetType(Decimal))
    '    dt.Columns.Add("pagome", GetType(Decimal))

    '    dgvCobroProgramado.DataSource = dt
    'End Sub

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
        'GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        'GGC.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        'GGC.TableOptions.ListBoxSelectionMode = SelectionMode.One
        GGC.TableOptions.SelectionBackColor = Color.Gray
        GGC.AllowProportionalColumnSizing = False
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        GGC.Table.DefaultColumnHeaderRowHeight = 23
        GGC.Table.DefaultRecordRowHeight = 20
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 7.5F

    End Sub

    Private Sub UbicarTodosVentaNroSerie()
        Dim documentoVentaSA As New documentoVentaAbarrotesSA
        Dim documentoVenta As New List(Of documentoventaAbarrotes)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable
        'Dim strPeriodo As String = String.Format("{0:00}", Convert.ToInt32(txtPeriodoAFC.Value.Month)) & "/" & txtPeriodoAFC.Value.Year

        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("fecha", GetType(String))
        dt.Columns.Add("tipoVenta", GetType(String))
        dt.Columns.Add("tipoDoc", GetType(String))
        dt.Columns.Add("serie", GetType(String))
        dt.Columns.Add("numero", GetType(String))
        dt.Columns.Add("moneda", GetType(String))
        dt.Columns.Add("importeMN", GetType(Decimal))
        dt.Columns.Add("tipoCambio", GetType(Decimal))
        dt.Columns.Add("importeME", GetType(Decimal))
        dt.Columns.Add("abonoMN", GetType(Decimal))
        dt.Columns.Add("abonoME", GetType(Decimal))
        dt.Columns.Add("saldoMN", GetType(Decimal))
        dt.Columns.Add("saldoME", GetType(Decimal))
        dt.Columns.Add("estadoPago", GetType(String))
        dt.Columns.Add("dia", GetType(Integer))
        dt.Columns.Add("montoVenc", GetType(Decimal))
        dt.Columns.Add("montoVencme", GetType(Decimal))
        dt.Columns.Add("fechaVcto", GetType(String))
        dt.Columns.Add("montocrono", GetType(Decimal))
        dt.Columns.Add("montocronome", GetType(Decimal))
        dt.Columns.Add("montoxprog", GetType(Decimal))
        dt.Columns.Add("montoxprogme", GetType(Decimal))
        dt.Columns.Add("pago", GetType(Decimal))
        dt.Columns.Add("pagome", GetType(Decimal))
        dt.Columns.Add("idProveedor", GetType(Integer))
        dt.Columns.Add("nombre", GetType(String))

        documentoVenta = documentoVentaSA.UbicarTodosVentaPorClienteMNME(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
        Dim str As String
        Dim str2 As String
        If Not IsNothing(documentoVenta) Then
            For Each i In documentoVenta
                Dim dr As DataRow = dt.NewRow()
                str = Nothing
                str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
                str2 = Nothing
                str2 = CDate(i.fechaVcto).ToString("dd-MMM hh:mm tt ")
                dr(0) = i.idDocumento
                dr(1) = str
                dr(2) = i.tipoVenta
                dr(3) = i.tipoDocumento
                dr(4) = i.serie
                dr(5) = i.numeroDoc
                dr(10) = i.PagoSumaMN
                dr(11) = i.PagoSumaME


                Select Case i.moneda
                    Case CStr(1)
                        dr(6) = "NAC"
                        dr(7) = i.ImporteNacional
                        dr(8) = i.tipoCambio
                        dr(9) = CDec(0.0)
                        dr(12) = CDec(i.ImporteNacional - i.PagoSumaMN).ToString("N2")
                        dr(13) = CDec(0.0)
                    Case Else
                        dr(6) = "EXT"
                        dr(7) = CDec(0.0)
                        dr(8) = i.tipoCambio
                        dr(9) = i.ImporteExtranjero
                        dr(12) = CDec(0.0)
                        dr(13) = CDec(i.ImporteExtranjero - i.PagoSumaME).ToString("N2")

                End Select



                'dr(7) = i.ImporteNacional
                'dr(8) = i.tipoCambio
                'dr(9) = i.ImporteExtranjero

                'dr(12) = CDec(i.ImporteNacional - i.PagoSumaMN).ToString("N2")
                'dr(13) = CDec(i.ImporteExtranjero - i.PagoSumaME).ToString("N2")

                Select Case i.estadoCobro
                    Case TIPO_VENTA.PAGO.COBRADO
                        dr(14) = "Saldado"
                    Case TIPO_VENTA.PAGO.PENDIENTE_PAGO
                        dr(14) = "Pendiente"
                End Select

                'monto vencidos dolares y soles
                If DateTime.Now.Date > i.fechaVcto Then

                    If i.moneda = "1" Then
                        Dim dias As Integer
                        Dim fecha1 As Date
                        Dim fecha2 As Date
                        fecha1 = DateTime.Now
                        fecha2 = i.fechaDoc
                        dias = (fecha1 - fecha2).TotalDays

                        dr(15) = dias
                        dr(16) = CDec(i.ImporteNacional - i.PagoSumaMN).ToString("N2")
                        dr(17) = CDec(0.0)

                    ElseIf i.moneda = "2" Then
                        Dim dias As Integer
                        Dim fecha1 As Date
                        Dim fecha2 As Date
                        fecha1 = DateTime.Now
                        fecha2 = i.fechaDoc
                        dias = (fecha1 - fecha2).TotalDays

                        dr(15) = dias
                        dr(16) = CDec(0.0)
                        dr(17) = CDec(i.ImporteExtranjero - i.PagoSumaME).ToString("N2")

                    End If
                Else
                    dr(15) = 0
                    dr(16) = 0
                    dr(17) = 0
                End If


                dr(18) = str2
                If i.moneda = "1" Then
                    dr(19) = i.montocrono
                    dr(20) = CDec(0.0)
                    dr(21) = CDec(i.ImporteNacional - i.PagoSumaMN - i.montocrono).ToString("N2")
                    dr(22) = CDec(0.0)
                    dr(23) = CDec(0.0)
                    dr(24) = CDec(0.0)
                    dr(25) = i.idCliente
                    dr(26) = i.NombreEntidad

                    If CDec(i.ImporteNacional - i.PagoSumaMN - i.montocrono).ToString("N2") > 0 Then
                        dt.Rows.Add(dr)
                    End If


                ElseIf i.moneda = "2" Then
                    dr(19) = CDec(0.0)
                    dr(20) = i.montocronome
                    dr(21) = CDec(CDec(0.0))
                    dr(22) = CDec(i.ImporteExtranjero - i.PagoSumaME - i.montocronome).ToString("N2")
                    dr(23) = CDec(0.0)
                    dr(24) = CDec(0.0)
                    dr(25) = i.idCliente
                    dr(26) = i.NombreEntidad

                    If CDec(i.ImporteExtranjero - i.PagoSumaME - i.montocronome).ToString("N2") > 0 Then
                        dt.Rows.Add(dr)
                    End If
                End If

                'dt.Rows.Add(dr)
            Next
            dgvCobranzas.DataSource = dt
            Me.dgvCobranzas.TableOptions.ListBoxSelectionMode = SelectionMode.One

            'Select Case cboMonedaCobro.Text
            '    Case "NACIONAL"
            '        dgvCobranzaCli.TableDescriptor.Columns("importeMN").Width = 70
            '        dgvCobranzaCli.TableDescriptor.Columns("abonoMN").Width = 70
            '        dgvCobranzaCli.TableDescriptor.Columns("saldoMN").Width = 70
            '        dgvCobranzaCli.TableDescriptor.Columns("tipoCambio").Width = 0
            '        dgvCobranzaCli.TableDescriptor.Columns("importeME").Width = 0
            '        dgvCobranzaCli.TableDescriptor.Columns("abonoME").Width = 0
            '        dgvCobranzaCli.TableDescriptor.Columns("saldoME").Width = 0
            '    Case "EXTRANJERA"
            '        dgvCobranzaCli.TableDescriptor.Columns("tipoCambio").Width = 70
            '        dgvCobranzaCli.TableDescriptor.Columns("importeME").Width = 70
            '        dgvCobranzaCli.TableDescriptor.Columns("abonoME").Width = 70
            '        dgvCobranzaCli.TableDescriptor.Columns("saldoME").Width = 70
            '        dgvCobranzaCli.TableDescriptor.Columns("importeMN").Width = 0
            '        dgvCobranzaCli.TableDescriptor.Columns("abonoMN").Width = 0
            '        dgvCobranzaCli.TableDescriptor.Columns("saldoMN").Width = 0
            'End Select


        Else

        End If
    End Sub





    Private Sub UbicarVentaNroSerie(RucCliente As Integer)
        Dim documentoVentaSA As New documentoVentaAbarrotesSA
        Dim documentoVenta As New List(Of documentoventaAbarrotes)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable
        'Dim strPeriodo As String = String.Format("{0:00}", Convert.ToInt32(txtPeriodoAFC.Value.Month)) & "/" & txtPeriodoAFC.Value.Year

        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("fecha", GetType(String))
        dt.Columns.Add("tipoVenta", GetType(String))
        dt.Columns.Add("tipoDoc", GetType(String))
        dt.Columns.Add("serie", GetType(String))
        dt.Columns.Add("numero", GetType(String))
        dt.Columns.Add("moneda", GetType(String))
        dt.Columns.Add("importeMN", GetType(Decimal))
        dt.Columns.Add("tipoCambio", GetType(Decimal))
        dt.Columns.Add("importeME", GetType(Decimal))
        dt.Columns.Add("abonoMN", GetType(Decimal))
        dt.Columns.Add("abonoME", GetType(Decimal))
        dt.Columns.Add("saldoMN", GetType(Decimal))
        dt.Columns.Add("saldoME", GetType(Decimal))
        dt.Columns.Add("estadoPago", GetType(String))
        dt.Columns.Add("dia", GetType(Integer))
        dt.Columns.Add("montoVenc", GetType(Decimal))
        dt.Columns.Add("montoVencme", GetType(Decimal))
        dt.Columns.Add("fechaVcto", GetType(String))
        dt.Columns.Add("montocrono", GetType(Decimal))
        dt.Columns.Add("montocronome", GetType(Decimal))
        dt.Columns.Add("montoxprog", GetType(Decimal))
        dt.Columns.Add("montoxprogme", GetType(Decimal))
        dt.Columns.Add("pago", GetType(Decimal))
        dt.Columns.Add("pagome", GetType(Decimal))
        dt.Columns.Add("idProveedor", GetType(Integer))
        dt.Columns.Add("nombre", GetType(String))

        documentoVenta = documentoVentaSA.UbicarVentaPorClienteMNME(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, RucCliente)
        Dim str As String
        Dim str2 As String
        If Not IsNothing(documentoVenta) Then
            For Each i In documentoVenta
                Dim dr As DataRow = dt.NewRow()
                str = Nothing
                str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
                str2 = Nothing
                str2 = CDate(i.fechaVcto).ToString("dd-MMM hh:mm tt ")
                dr(0) = i.idDocumento
                dr(1) = str
                dr(2) = i.tipoVenta
                dr(3) = i.tipoDocumento
                dr(4) = i.serie
                dr(5) = i.numeroDoc
                dr(10) = i.PagoSumaMN
                dr(11) = i.PagoSumaME


                Select Case i.moneda
                    Case CStr(1)
                        dr(6) = "NAC"
                        dr(7) = i.ImporteNacional
                        dr(8) = i.tipoCambio
                        dr(9) = CDec(0.0)
                        dr(12) = CDec(i.ImporteNacional - i.PagoSumaMN).ToString("N2")
                        dr(13) = CDec(0.0)
                    Case Else
                        dr(6) = "EXT"
                        dr(7) = CDec(0.0)
                        dr(8) = i.tipoCambio
                        dr(9) = i.ImporteExtranjero
                        dr(12) = CDec(0.0)
                        dr(13) = CDec(i.ImporteExtranjero - i.PagoSumaME).ToString("N2")

                End Select



                'dr(7) = i.ImporteNacional
                'dr(8) = i.tipoCambio
                'dr(9) = i.ImporteExtranjero

                'dr(12) = CDec(i.ImporteNacional - i.PagoSumaMN).ToString("N2")
                'dr(13) = CDec(i.ImporteExtranjero - i.PagoSumaME).ToString("N2")

                Select Case i.estadoCobro
                    Case TIPO_VENTA.PAGO.COBRADO
                        dr(14) = "Saldado"
                    Case TIPO_VENTA.PAGO.PENDIENTE_PAGO
                        dr(14) = "Pendiente"
                End Select

                'monto vencidos dolares y soles
                If DateTime.Now.Date > i.fechaVcto Then

                    If i.moneda = "1" Then
                        Dim dias As Integer
                        Dim fecha1 As Date
                        Dim fecha2 As Date
                        fecha1 = DateTime.Now
                        fecha2 = i.fechaDoc
                        dias = (fecha1 - fecha2).TotalDays

                        dr(15) = dias
                        dr(16) = CDec(i.ImporteNacional - i.PagoSumaMN).ToString("N2")
                        dr(17) = CDec(0.0)




                    ElseIf i.moneda = "2" Then
                        Dim dias As Integer
                        Dim fecha1 As Date
                        Dim fecha2 As Date
                        fecha1 = DateTime.Now
                        fecha2 = i.fechaDoc
                        dias = (fecha1 - fecha2).TotalDays

                        dr(15) = dias
                        dr(16) = CDec(0.0)
                        dr(17) = CDec(i.ImporteExtranjero - i.PagoSumaME).ToString("N2")




                    End If
                Else
                    dr(15) = 0
                    dr(16) = 0
                    dr(17) = 0
                End If


                dr(18) = str2
                If i.moneda = "1" Then
                    dr(19) = i.montocrono
                    dr(20) = CDec(0.0)
                    dr(21) = CDec(i.ImporteNacional - i.PagoSumaMN - i.montocrono).ToString("N2")
                    dr(22) = CDec(0.0)
                    dr(23) = CDec(0.0)
                    dr(24) = CDec(0.0)
                    dr(25) = txtCliente.Tag
                    dr(26) = txtCliente.Text

                    If CDec(i.ImporteNacional - i.PagoSumaMN - i.montocrono).ToString("N2") > 0 Then
                        dt.Rows.Add(dr)
                    End If

                ElseIf i.moneda = "2" Then
                    dr(19) = CDec(0.0)
                    dr(20) = i.montocronome
                    dr(21) = CDec(CDec(0.0))
                    dr(22) = CDec(i.ImporteExtranjero - i.PagoSumaME - i.montocronome).ToString("N2")
                    dr(23) = CDec(0.0)
                    dr(24) = CDec(0.0)
                    dr(25) = txtCliente.Tag
                    dr(26) = txtCliente.Text

                    If CDec(i.ImporteExtranjero - i.PagoSumaME - i.montocronome).ToString("N2") > 0 Then
                        dt.Rows.Add(dr)
                    End If
                End If

                'dt.Rows.Add(dr)
            Next
            dgvCobranzas.DataSource = dt
            Me.dgvCobranzas.TableOptions.ListBoxSelectionMode = SelectionMode.One

            'Select Case cboMonedaCobro.Text
            '    Case "NACIONAL"
            '        dgvCobranzaCli.TableDescriptor.Columns("importeMN").Width = 70
            '        dgvCobranzaCli.TableDescriptor.Columns("abonoMN").Width = 70
            '        dgvCobranzaCli.TableDescriptor.Columns("saldoMN").Width = 70
            '        dgvCobranzaCli.TableDescriptor.Columns("tipoCambio").Width = 0
            '        dgvCobranzaCli.TableDescriptor.Columns("importeME").Width = 0
            '        dgvCobranzaCli.TableDescriptor.Columns("abonoME").Width = 0
            '        dgvCobranzaCli.TableDescriptor.Columns("saldoME").Width = 0
            '    Case "EXTRANJERA"
            '        dgvCobranzaCli.TableDescriptor.Columns("tipoCambio").Width = 70
            '        dgvCobranzaCli.TableDescriptor.Columns("importeME").Width = 70
            '        dgvCobranzaCli.TableDescriptor.Columns("abonoME").Width = 70
            '        dgvCobranzaCli.TableDescriptor.Columns("saldoME").Width = 70
            '        dgvCobranzaCli.TableDescriptor.Columns("importeMN").Width = 0
            '        dgvCobranzaCli.TableDescriptor.Columns("abonoMN").Width = 0
            '        dgvCobranzaCli.TableDescriptor.Columns("saldoMN").Width = 0
            'End Select


        Else

        End If
    End Sub


    Public Sub CargarEntidadesXtipo(strBusqueda As String)
        Dim entidadSA As New entidadSA
        Try
            lsvProveedor.Items.Clear()
            For Each i As entidad In entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, TIPO_ENTIDAD.CLIENTE, strBusqueda)
                Dim n As New ListViewItem(i.idEntidad)
                n.SubItems.Add(i.nombreCompleto)
                n.SubItems.Add(i.cuentaAsiento)
                n.SubItems.Add(i.nrodoc)
                lsvProveedor.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub

#End Region

    Private Sub frmFlujoCobros_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmFlujoCobros_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtCliente_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCliente.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Me.popupControlContainer1.ParentControl = Me.txtCliente
            Me.popupControlContainer1.ShowPopup(Point.Empty)
            CargarEntidadesXtipo(txtCliente.Text.Trim)
        End If
    End Sub

    Private Sub txtCliente_TextChanged(sender As Object, e As EventArgs) Handles txtCliente.TextChanged

    End Sub

    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvProveedor.MouseDoubleClick
        If lsvProveedor.SelectedItems.Count > 0 Then
            Me.popupControlContainer1.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub lsvProveedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvProveedor.SelectedIndexChanged

    End Sub

    Private Sub popupControlContainer1_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles popupControlContainer1.CloseUp
        Me.Cursor = Cursors.WaitCursor
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvProveedor.SelectedItems.Count > 0 Then


                Me.txtCliente.Text = lsvProveedor.SelectedItems(0).SubItems(1).Text
                txtCliente.Tag = lsvProveedor.SelectedItems(0).SubItems(0).Text
                txtRuc.Text = lsvProveedor.SelectedItems(0).SubItems(3).Text



                ' txtCuenta.Text = lsvProveedor.SelectedItems(0).SubItems(2).Text
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then


            Me.txtCliente.Focus()

        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv15_Click(sender As Object, e As EventArgs) Handles ButtonAdv15.Click
        Me.Cursor = Cursors.WaitCursor
        If txtCliente.Text.Trim.Length > 0 Then


            If Not IsNothing(txtCliente.Tag) Then

            Else
                MessageBox.Show("Ingrese una Identificacion ", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtCliente.Focus()
                Exit Sub
            End If


            'Select Case cboMonedaCobro.Text
            '    Case "NACIONAL"
            '        UbicarVentaNroSerie(txtCliente.Tag, "1")
            '        'UbicarVentaNroSeriePago(txtBuscarProveedorPago.Tag, "1")
            '    Case "EXTRANJERA"
            '        UbicarVentaNroSerie(txtCliente.Tag, "2")
            'End Select

            UbicarVentaNroSerie(txtCliente.Tag)


        Else
            'lblEstado.Text = "Seleccione un cliente antes de realizar la tarea!"
            'PanelError.Visible = True
            'Timer1.Enabled = True
            'TiempoEjecutar(10)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub GradientPanel15_Paint(sender As Object, e As PaintEventArgs) Handles GradientPanel15.Paint

    End Sub

    

    Private Sub dgvCobranzaCli_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCobranzas.TableControlCellClick

    End Sub

    Private Sub dgvCobranzaCli_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvCobranzas.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        If Not IsNothing(Me.dgvCobranzas.Table.CurrentRecord) Then
            Select Case ColIndex

                Case 24


                    If Me.dgvCobranzas.Table.CurrentRecord.GetValue("moneda") = "NAC" Then

                        If Me.dgvCobranzas.Table.CurrentRecord.GetValue("pago") >= 0 Then

                            If Me.dgvCobranzas.Table.CurrentRecord.GetValue("pago") <= Me.dgvCobranzas.Table.CurrentRecord.GetValue("montoxprog") Then


                            Else

                                Me.dgvCobranzas.Table.CurrentRecord.SetValue("pago", CDec(0.0))
                                Me.dgvCobranzas.Table.CurrentRecord.SetValue("pagome", CDec(0.0))

                                MessageBox.Show("Ingrese un Monto Menor o Igual al monto por programar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)


                            End If

                        Else
                            Me.dgvCobranzas.Table.CurrentRecord.SetValue("pago", CDec(0.0))
                            Me.dgvCobranzas.Table.CurrentRecord.SetValue("pagome", CDec(0.0))
                        End If
                    Else

                        Me.dgvCobranzas.Table.CurrentRecord.SetValue("pago", CDec(0.0))
                    End If

                Case 25

                    If Me.dgvCobranzas.Table.CurrentRecord.GetValue("moneda") = "EXT" Then

                        If Me.dgvCobranzas.Table.CurrentRecord.GetValue("pagome") >= 0 Then

                            If Me.dgvCobranzas.Table.CurrentRecord.GetValue("pagome") <= Me.dgvCobranzas.Table.CurrentRecord.GetValue("montoxprogme") Then


                            Else

                                Me.dgvCobranzas.Table.CurrentRecord.SetValue("pago", CDec(0.0))
                                Me.dgvCobranzas.Table.CurrentRecord.SetValue("pagome", CDec(0.0))

                                MessageBox.Show("Ingrese un Monto Menor o Igual ala deuda!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)


                            End If

                        Else
                            Me.dgvCobranzas.Table.CurrentRecord.SetValue("pago", CDec(0.0))
                            Me.dgvCobranzas.Table.CurrentRecord.SetValue("pagome", CDec(0.0))
                        End If
                    Else
                        Me.dgvCobranzas.Table.CurrentRecord.SetValue("pagome", CDec(0.0))

                    End If
            End Select
        End If
    End Sub

   

    

    

    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click
        Me.Cursor = Cursors.WaitCursor

        If Not IsNothing(dgvCobranzas.Table.CurrentRecord) Then
            If dgvCobranzas.Table.CurrentRecord.GetValue("moneda") = "NAC" Then
                If dgvCobranzas.Table.CurrentRecord.GetValue("montoxprog") > 0 Then
                    Dim f As New frmNegociacionCobross
                    f.lblIdDocumento.Text = dgvCobranzas.Table.CurrentRecord.GetValue("idDocumento")
                    f.txtImporteCompramn.Value = dgvCobranzas.Table.CurrentRecord.GetValue("montoxprog")
                    f.txtImporteComprame.Value = dgvCobranzas.Table.CurrentRecord.GetValue("montoxprogme")
                    f.txttipocambio.Value = dgvCobranzas.Table.CurrentRecord.GetValue("tipoCambio")
                    f.txtMoneda.Text = dgvCobranzas.Table.CurrentRecord.GetValue("moneda")
                    f.txtSerie.Text = dgvCobranzas.Table.CurrentRecord.GetValue("serie")
                    f.txtNumero.Text = dgvCobranzas.Table.CurrentRecord.GetValue("numero")
                    '.txtCliente.Text = txtCliente.Text
                    '.txtCliente.Tag = txtCliente.Tag
                    f.txtCliente.Text = dgvCobranzas.Table.CurrentRecord.GetValue("nombre")
                    f.txtCliente.Tag = dgvCobranzas.Table.CurrentRecord.GetValue("idProveedor")
                    f.txtRuc.Text = txtRuc.Text
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()

                    UbicarVentaNroSerie(txtCliente.Tag)
                End If


            ElseIf dgvCobranzas.Table.CurrentRecord.GetValue("moneda") = "EXT" Then
                If dgvCobranzas.Table.CurrentRecord.GetValue("montoxprogme") > 0 Then
                    Dim f As New frmNegociacionCobross
                    f.lblIdDocumento.Text = dgvCobranzas.Table.CurrentRecord.GetValue("idDocumento")
                    f.txtImporteCompramn.Value = dgvCobranzas.Table.CurrentRecord.GetValue("montoxprog")
                    f.txtImporteComprame.Value = dgvCobranzas.Table.CurrentRecord.GetValue("montoxprogme")
                    f.txttipocambio.Value = dgvCobranzas.Table.CurrentRecord.GetValue("tipoCambio")
                    f.txtMoneda.Text = dgvCobranzas.Table.CurrentRecord.GetValue("moneda")
                    f.txtSerie.Text = dgvCobranzas.Table.CurrentRecord.GetValue("serie")
                    f.txtNumero.Text = dgvCobranzas.Table.CurrentRecord.GetValue("numero")
                    '.txtCliente.Text = txtCliente.Text
                    '.txtCliente.Tag = txtCliente.Tag
                    f.txtCliente.Text = dgvCobranzas.Table.CurrentRecord.GetValue("nombre")
                    f.txtCliente.Tag = dgvCobranzas.Table.CurrentRecord.GetValue("idProveedor")
                    f.txtRuc.Text = txtRuc.Text
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()

                    UbicarVentaNroSerie(txtCliente.Tag)
                End If


            End If

        Else
            ' MessageBox.Show("Seleccione un Item a Editar")
            MessageBox.Show("Seleccione un Item a Editar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

  
    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Me.Cursor = Cursors.WaitCursor
        UbicarTodosVentaNroSerie()
        Me.Cursor = Cursors.Arrow
    End Sub
End Class