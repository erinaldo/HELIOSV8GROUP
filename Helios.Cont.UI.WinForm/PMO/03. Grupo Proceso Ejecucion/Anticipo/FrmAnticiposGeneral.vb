Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.GridHelperClasses
Imports System.ComponentModel
Imports Syncfusion.Grouping

Public Class FrmAnticiposGeneral

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        Me.WindowState = FormWindowState.Maximized
        ' Add any initialization after the InitializeComponent() call.
      
        GridCFG(dgvAnticipos)
        GridCFG(dgvAnticiposOtor)
        
        'lblPeriodo.Text = "Período: " & PeriodoGeneral

    End Sub

#Region "metodos"


#Region "TIMER"
    Sub parpadeo()
        Static parpadear As Boolean

        'If Not parpadear Then
        '    lblEstado.ForeColor = lblEstado.BackColor
        '    lblEstado.BackColor = Color.Yellow
        'Else
        '    lblEstado.ForeColor = SystemColors.WindowText
        'End If

        parpadear = Not parpadear
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If TiempoRestante > 0 Then
            parpadeo()

            'lblAgregar.Visible = True
            'lblMensaje.Visible = True
            'tsSave.Enabled = False
            'lblMensaje.Text = "Agregar otro en: " & TiempoRestante
            TiempoRestante = TiempoRestante - 1
        ElseIf TiempoRestante = 0 Then
            Timer1.Enabled = False
            'lblEstado.ForeColor = Color.Navy
            'lblEstado.BackColor = Color.Transparent
            PanelError.Visible = False
            '      Dispose()
        Else
            Timer1.Enabled = False
            'Ejecuta tu función cuando termina el tiempo
            TiempoEjecutar(10)

        End If
    End Sub
    Private TiempoRestante As Integer
    Public Sub TimerOn(ByRef Interval As Short)
        If Interval > 0 Then
            Timer1.Enabled = True
        Else
            Timer1.Enabled = False
        End If

    End Sub
    Public Function TiempoEjecutar(ByVal Tiempo As Integer)
        TiempoEjecutar = ""
        TiempoRestante = Tiempo  ' 1 minutos=60 segundos 
        Timer1.Interval = 400

        Call TimerOn(1000) ' Hechanos a andar el timer
    End Function
#End Region

    Public Class ChildList
        Inherits ArrayList
        Implements ITypedList

#Region "ITypedList Members"

        Public Function GetItemProperties(listAccessors As PropertyDescriptor()) As PropertyDescriptorCollection Implements ITypedList.GetItemProperties
            Return TypeDescriptor.GetProperties(GetType(Data))
        End Function

        Public Function GetListName(listAccessors As PropertyDescriptor()) As String Implements ITypedList.GetListName
            Return "Data"
        End Function

#End Region


    End Class

    Public Class Data
        Public Sub New()
            Me.New("", 0)
        End Sub

        Public Sub New(pers As String, imp As Decimal)
            Me.Persona = pers
            Me.ImporteSub = imp
        End Sub
        Private Perso As String
        Public Property Persona() As String
            Get
                Return Me.Perso
            End Get
            Set(value As String)
                Me.Perso = value
            End Set
        End Property

        Private importe_ As String
        Public Property ImporteSub() As String
            Get
                Return Me.importe_
            End Get
            Set(value As String)
                Me.importe_ = value
            End Set
        End Property

    End Class

    Public Sub ListarAnticiposProveedorActual(idprov As Integer, tipo As String)
        Dim DocumentoAnticipoSL As New documentoAnticipo
        Dim dt As New DataTable("Aportes de Proveedor - período " & PeriodoGeneral & " ")
        Dim documentoAnticipoSA As New documentoAnticipoSA
        Dim str As String
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoDocumento", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoOperacion", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoAnticipo", GetType(String)))
        dt.Columns.Add(New DataColumn("razonSocial", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoCambio", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("ImporteNacional", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("ImporteExtranjero", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("Saldo", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("Monto", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("idEntidadFinanciera", GetType(String)))

        For Each i As documentoAnticipo In documentoAnticipoSA.getTableAnticiposMontoActual(idprov, tipo)
            Dim dr As DataRow = dt.NewRow()
            'str = Nothing
            'str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")

            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            Select Case i.tipoDocumento
                Case "9901"
                    dr(1) = "VOUCHER CONTABLE"
            End Select
            dr(2) = i.numeroDoc
            dr(3) = str
            Select Case i.tipoOperacion
                Case "103"
                    dr(4) = "ANTICIPO RECIBIDO"
                Case "104"
                    dr(4) = "ANTICIPOS OTORGADOS"
            End Select
            dr(5) = i.tipoAnticipo
            dr(6) = txtProveedor.Text
            dr(7) = i.TipoCambio
            dr(8) = i.MontoDeudaSoles
            dr(9) = i.MontoDeudaUSD
            dr(10) = i.MontoPagadoSoles
            dr(11) = i.MontoDeudaSoles - i.MontoPagadoSoles
            dr(12) = i.razonSocial
            'Dim deuda As Decimal
            'deuda = CDec(0)
            'deuda = i.MontoDeudaSoles - i.MontoPagadoSoles

            'If deuda > 0 Then

            '    dr(0) = i.idDocumento
            '    dr(1) = i.numeroDoc
            '    dr(2) = i.tipoAnticipo
            '    dr(3) = i.razonSocial
            '    dr(4) = i.TipoCambio
            '    dr(5) = i.MontoDeudaSoles
            '    dr(6) = i.MontoPagadoSoles
            '    dr(7) = i.MontoDeudaSoles - i.MontoPagadoSoles
            '    dr(8) = i.MontoDeudaUSD - i.MontoPagadoUSD
            '    dr(9) = CDec(0.0)
            dt.Rows.Add(dr)
            'End If


        Next
        dgvAnticipos.DataSource = dt

    End Sub

    Public Sub ListarAnticiposOtorgadosActual(idprov As Integer, tipo As String)
        Dim DocumentoAnticipoSL As New documentoAnticipo
        Dim dt As New DataTable("Aportes de Proveedor - período " & PeriodoGeneral & " ")
        Dim documentoAnticipoSA As New documentoAnticipoSA
        Dim str As String
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoDocumento", GetType(String)))

        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoOperacion", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoAnticipo", GetType(String)))

        dt.Columns.Add(New DataColumn("razonSocial", GetType(String)))

        dt.Columns.Add(New DataColumn("tipoCambio", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("ImporteNacional", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("ImporteExtranjero", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("Saldo", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("Monto", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("idEntidadFinanciera", GetType(String)))

        For Each i As documentoAnticipo In documentoAnticipoSA.getTableAnticiposMontoActual(idprov, tipo)
            Dim dr As DataRow = dt.NewRow()
            'str = Nothing
            'str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")

            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            Select Case i.tipoDocumento
                Case "9901"
                    dr(1) = "VOUCHER CONTABLE"
            End Select
            dr(2) = i.numeroDoc
            dr(3) = str
            Select Case i.tipoOperacion
                Case "103"
                    dr(4) = "ANTICIPO RECIBIDO"
            End Select
            dr(5) = i.tipoAnticipo
            dr(6) = txtProveedor.Text
            dr(7) = i.TipoCambio
            dr(8) = i.MontoDeudaSoles
            dr(9) = i.MontoDeudaUSD
            dr(10) = i.MontoPagadoSoles
            dr(11) = i.MontoDeudaSoles - i.MontoPagadoSoles
            dr(12) = i.razonSocial
            'Dim deuda As Decimal
            'deuda = CDec(0)
            'deuda = i.MontoDeudaSoles - i.MontoPagadoSoles

            'If deuda > 0 Then

            '    dr(0) = i.idDocumento
            '    dr(1) = i.numeroDoc
            '    dr(2) = i.tipoAnticipo
            '    dr(3) = i.razonSocial
            '    dr(4) = i.TipoCambio
            '    dr(5) = i.MontoDeudaSoles
            '    dr(6) = i.MontoPagadoSoles
            '    dr(7) = i.MontoDeudaSoles - i.MontoPagadoSoles
            '    dr(8) = i.MontoDeudaUSD - i.MontoPagadoUSD
            '    dr(9) = CDec(0.0)
            dt.Rows.Add(dr)
            'End If


        Next
        dgvAnticiposOtor.DataSource = dt

    End Sub






    Private Sub getTableAnticiposPorTipoProveedor(tipo As String, idprov As Integer)
        Dim DocumentoAnticipoSL As New documentoAnticipo
        Dim dt As New DataTable("Aportes de Proveedor - período " & PeriodoGeneral & " ")
        Dim documentoAnticipoSA As New documentoAnticipoSA
        Dim cl1 As New ChildList()
        Dim al As New ArrayList()

        Dim str As String

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoDocumento", GetType(String)))

        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoOperacion", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoAnticipo", GetType(String)))

        dt.Columns.Add(New DataColumn("razonSocial", GetType(String)))

        dt.Columns.Add(New DataColumn("tipoCambio", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("ImporteNacional", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("ImporteExtranjero", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("idEntidadFinanciera", GetType(String)))



        For Each i As documentoAnticipo In documentoAnticipoSA.getTableAnticiposPorTipoProvee(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, PeriodoGeneral, tipo, idprov)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            Select Case i.tipoDocumento
                Case "9901"
                    dr(1) = "VOUCHER CONTABLE"
            End Select
            dr(2) = i.numeroDoc
            dr(3) = str
            Select Case i.tipoOperacion
                Case "103"
                    dr(4) = "ANTICIPO RECIBIDO"
            End Select
            dr(5) = i.tipoAnticipo
            dr(6) = i.NombreEntidad
            dr(7) = i.TipoCambio
            dr(8) = i.importeMN
            dr(9) = i.importeME
            dr(10) = i.NombreEstadoFinanciero
            dt.Rows.Add(dr)
        Next
        dgvAnticipos.DataSource = dt

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

        GGC.Table.DefaultColumnHeaderRowHeight = 45
        GGC.Table.DefaultRecordRowHeight = 40
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Public Sub CargarEntidadesXtipo(strTipo As String, strBusqueda As String)
        Dim entidadSA As New entidadSA
        Try
            lsvProveedor.Items.Clear()
            For Each i As entidad In entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, strTipo, strBusqueda)
                Dim n As New ListViewItem(i.idEntidad)
                n.SubItems.Add(i.nombreCompleto)
                n.SubItems.Add(i.cuentaAsiento)
                n.SubItems.Add(i.nrodoc)
                lsvProveedor.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub


    Public Sub CargarProveedores(strTipo As String, strBusqueda As String)
        Dim entidadSA As New entidadSA
        Try
            lsvProveedor2.Items.Clear()
            For Each i As entidad In entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, strTipo, strBusqueda)
                Dim n As New ListViewItem(i.idEntidad)
                n.SubItems.Add(i.nombreCompleto)
                n.SubItems.Add(i.cuentaAsiento)
                n.SubItems.Add(i.nrodoc)
                lsvProveedor2.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub
#End Region

    Private Sub txtProveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProveedor.KeyDown
        If e.Alt Then
            If e.KeyCode = Keys.Down Then
                If Not Me.popupControlContainer1.IsShowing() Then
                    ' Let the popup align around the source textBox.
                    Me.popupControlContainer1.ParentControl = Me.txtProveedor
                    ' Passing Point.Empty will align it automatically around the above ParentControl.
                    Me.popupControlContainer1.ShowPopup(Point.Empty)

                    e.Handled = True
                End If
            End If
        End If
        '' Escape should close the popup.
        If e.KeyCode = Keys.Escape Then
            If Me.popupControlContainer1.IsShowing() Then
                Me.popupControlContainer1.HidePopup(PopupCloseType.Canceled)
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtProveedor.Text.Trim.Length > 0 Then
                Me.popupControlContainer1.ParentControl = Me.txtProveedor
                Me.popupControlContainer1.ShowPopup(Point.Empty)
                ' CargarEntidadesXtipo(TIPO_ENTIDAD.PROVEEDOR, txtProveedor.Text.Trim)





                If chProv.Checked = True Then
                    CargarEntidadesXtipo(TIPO_ENTIDAD.PROVEEDOR, txtProveedor.Text.Trim)
                    'ElseIf chTrab.Checked = True Then
                    '    CargarTrabajadoresXnivel("TR", txtProveedor.Text.Trim)

                ElseIf chCli.Checked = True Then
                    'CargarTrabajadoresXnivel("CL", txtProveedor.Text.Trim)
                    CargarEntidadesXtipo(TIPO_ENTIDAD.CLIENTE, txtProveedor.Text.Trim)
                End If


            End If
        End If
    End Sub


    Private Sub txtProveedor_TextChanged(sender As Object, e As EventArgs) Handles txtProveedor.TextChanged

    End Sub

    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvProveedor.MouseDoubleClick
        If lsvProveedor.SelectedItems.Count > 0 Then
            Me.popupControlContainer1.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub lsvProveedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvProveedor.SelectedIndexChanged

    End Sub

    Private Sub popupControlContainer1_CloseUp(sender As Object, e As Syncfusion.Windows.Forms.PopupClosedEventArgs) Handles popupControlContainer1.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvProveedor.SelectedItems.Count > 0 Then
                Me.txtProveedor.Text = lsvProveedor.SelectedItems(0).SubItems(1).Text
                txtProveedor.Tag = lsvProveedor.SelectedItems(0).SubItems(0).Text
                'txtRuc.Text = lsvProveedor.SelectedItems(0).SubItems(3).Text
                ' txtCuenta.Text = lsvProveedor.SelectedItems(0).SubItems(2).Text

                'If txtSerie.Text.Trim.Length > 0 AndAlso txtNumero.Text.Trim.Length > 0 AndAlso txtProveedor.Text.Trim.Length > 0 Then
                '    txtGlosa.Text = "Por la compra según " & cboTipoDoc.Text & Space(1) & "Nro. " & txtSerie.Text.Trim & "-" & txtNumero.Text.Trim & Space(1) & "del proveedor " & txtProveedor.Text.Trim
                'End If

                'txtSerieGuia.Select()
                'txtSerieGuia.SelectAll()
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtProveedor.Focus()
        End If
    End Sub


    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click



        If txtProveedor.Text.Trim.Length > 0 Then
            
            ListarAnticiposProveedorActual(CType(txtProveedor.Tag, Integer), "AR")

        Else
            lblEstado.Text = "Seleccione un proveedor a buscar"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End If
    End Sub

    

    

   

    Private Sub chProv_Click(sender As Object, e As EventArgs) Handles chProv.Click
        chProv.Checked = True

        chCli.Checked = False
        txtProveedor.Clear()
    End Sub

    Private Sub chCli_Click(sender As Object, e As EventArgs) Handles chCli.Click
        chProv.Checked = False

        chCli.Checked = True
        txtProveedor.Clear()
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs)
        If txtProveedor.Text.Trim.Length > 0 Then
            ListarAnticiposProveedorActual(CType(txtProveedor.Tag, Integer), "AO")
        Else
            lblEstado.Text = "Seleccione un proveedor a buscar"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End If
    End Sub

    Private Sub ToolStripButton13_Click(sender As Object, e As EventArgs) Handles ToolStripButton13.Click
        'With frmModalAnticipo
        '    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
        '    If txtProveedor.Text.Trim.Length > 0 Then
        '        .txtProveedor.Text = txtProveedor.Text
        '        .txtProveedor.Tag = txtProveedor.Tag
        '    End If
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        'End With

        Me.Cursor = Cursors.WaitCursor
        Dim f As New frmModalAnticipo
        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        If txtProveedor.Text.Trim.Length > 0 Then
            f.txtCliente2.Text = txtProveedor.Text
            f.txtCliente2.Tag = txtProveedor.Tag
        End If
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()

        ListarAnticiposProveedorActual(CType(txtProveedor.Tag, Integer), "AR")
        Me.Cursor = Cursors.Arrow



    End Sub

    Private Sub ToolStripButton18_Click(sender As Object, e As EventArgs) Handles ToolStripButton18.Click
        If dgvAnticipos.Table.SelectedRecords.Count > 0 Then
            If dgvAnticipos.Table.CurrentRecord.GetValue("Monto") > 0 Then
                'With frmAnticipoRecibidoDevolucion
                '    .StartPosition = FormStartPosition.CenterParent
                '    .ObtenerSaldoAnticipo(dgvAnticipos.Table.CurrentRecord.GetValue("idDocumento"))
                '    .txtProveedor.Text = txtProveedor.Text
                '    .txtProveedor.Tag = txtProveedor.Tag
                '    .lblanticipo.Text = (dgvAnticipos.Table.CurrentRecord.GetValue("idDocumento"))
                '    .ShowDialog()
                'End With


                Me.Cursor = Cursors.WaitCursor
                Dim f As New frmAnticipoRecibidoDevolucion
                f.ObtenerSaldoAnticipo(dgvAnticipos.Table.CurrentRecord.GetValue("idDocumento"))
                f.txtProveedor.Text = txtProveedor.Text
                f.txtProveedor.Tag = txtProveedor.Tag
                f.lblanticipo.Text = (dgvAnticipos.Table.CurrentRecord.GetValue("idDocumento"))
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()

                ListarAnticiposProveedorActual(CType(txtProveedor.Tag, Integer), "AR")

            Else
                MessageBox.Show("El Anticipo no Tiene Saldo")
            End If

        Else
            MessageBox.Show("Seleccione un Anticipo")
        End If


    End Sub

    Private Sub ToolStripButton20_Click(sender As Object, e As EventArgs) Handles ToolStripButton20.Click
        'With frmModalAnticipoOtor
        '    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
        '    If txtProveedor2.Text.Trim.Length > 0 Then
        '        .txtProveedor.Text = txtProveedor2.Text
        '        .txtProveedor.Tag = txtProveedor2.Tag
        '    End If
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        'End With


        Me.Cursor = Cursors.WaitCursor
        Dim f As New frmModalAnticipoOtor
        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        If txtProveedor2.Text.Trim.Length > 0 Then
            f.txtCliente2.Text = txtProveedor2.Text
            f.txtCliente2.Tag = txtProveedor2.Tag
        End If
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()

        ListarAnticiposOtorgadosActual(CType(txtProveedor2.Tag, Integer), "AO")
        Me.Cursor = Cursors.Arrow


    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
      

        If dgvAnticiposOtor.Table.SelectedRecords.Count > 0 Then
            If dgvAnticiposOtor.Table.CurrentRecord.GetValue("Monto") > 0 Then


                'With frmAnticipoOtorgadoDevolucion
                '    .StartPosition = FormStartPosition.CenterParent
                '    .ObtenerSaldoAnticipo(dgvAnticiposOtor.Table.CurrentRecord.GetValue("idDocumento"))
                '    .txtProveedor.Text = txtProveedor2.Text
                '    .txtProveedor.Tag = txtProveedor2.Tag
                '    .lblanticipo.Text = (dgvAnticiposOtor.Table.CurrentRecord.GetValue("idDocumento"))
                '    .ShowDialog()
                'End With


                Me.Cursor = Cursors.WaitCursor
                Dim f As New frmAnticipoOtorgadoDevolucion
                f.ObtenerSaldoAnticipo(dgvAnticiposOtor.Table.CurrentRecord.GetValue("idDocumento"))
                f.txtProveedor.Text = txtProveedor2.Text
                f.txtProveedor.Tag = txtProveedor2.Tag
                f.lblanticipo.Text = (dgvAnticiposOtor.Table.CurrentRecord.GetValue("idDocumento"))
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()

                ListarAnticiposOtorgadosActual(CType(txtProveedor2.Tag, Integer), "AO")



            Else
                MessageBox.Show("El Anticipo no Tiene Saldo")
            End If
        Else
            MessageBox.Show("Seleccione un Anticipo")
        End If
    End Sub

    Private Sub TextBoxExt1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProveedor2.KeyDown
        If e.Alt Then
            If e.KeyCode = Keys.Down Then
                If Not Me.PopupControlContainer3.IsShowing() Then
                    ' Let the popup align around the source textBox.
                    Me.PopupControlContainer3.ParentControl = Me.txtProveedor2
                    ' Passing Point.Empty will align it automatically around the above ParentControl.
                    Me.PopupControlContainer3.ShowPopup(Point.Empty)

                    e.Handled = True
                End If
            End If
        End If
        '' Escape should close the popup.
        If e.KeyCode = Keys.Escape Then
            If Me.PopupControlContainer3.IsShowing() Then
                Me.PopupControlContainer3.HidePopup(PopupCloseType.Canceled)
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtProveedor2.Text.Trim.Length > 0 Then
                Me.PopupControlContainer3.ParentControl = Me.txtProveedor2
                Me.PopupControlContainer3.ShowPopup(Point.Empty)
              
                CargarProveedores(TIPO_ENTIDAD.PROVEEDOR, txtProveedor2.Text.Trim)
                

        End If
        End If
    End Sub

    Private Sub TextBoxExt1_TextChanged(sender As Object, e As EventArgs) Handles txtProveedor2.TextChanged

    End Sub

    Private Sub ButtonAdv8_Click(sender As Object, e As EventArgs) Handles ButtonAdv8.Click

        If txtProveedor2.Text.Trim.Length > 0 Then

            ListarAnticiposOtorgadosActual(CType(txtProveedor2.Tag, Integer), "AO")

        Else
            lblEstado.Text = "Seleccione un proveedor a buscar"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End If
    End Sub

    Private Sub lsvProveedor2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvProveedor2.SelectedIndexChanged
        If lsvProveedor2.SelectedItems.Count > 0 Then
            Me.PopupControlContainer3.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub PopupControlContainer3_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles PopupControlContainer3.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvProveedor2.SelectedItems.Count > 0 Then
                Me.txtProveedor2.Text = lsvProveedor2.SelectedItems(0).SubItems(1).Text
                txtProveedor2.Tag = lsvProveedor2.SelectedItems(0).SubItems(0).Text

            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtProveedor2.Focus()
        End If
    End Sub

    Private Sub ToolStripButton17_Click(sender As Object, e As EventArgs) Handles ToolStripButton17.Click


        If dgvAnticipos.Table.SelectedRecords.Count > 0 Then
            ' btnNuevoPago(dgvPagosVarios.Table.CurrentRecord.GetValue("moneda"), dgvPagosVarios.Table.CurrentRecord.GetValue("idDocumento"))
            With FrmHistorialAnticipo
                .DetalleAnticipo(dgvAnticipos.Table.CurrentRecord.GetValue("idDocumento"))
                .ShowDialog()
            End With

        End If

        'If dgvAnticipos.Table.SelectedRecords.Count > 0 Then
        '    ' btnNuevoPago(dgvPagosVarios.Table.CurrentRecord.GetValue("moneda"), dgvPagosVarios.Table.CurrentRecord.GetValue("idDocumento"))


        '    With FrmHistorialAnticipo
        '        .DetalleAnticipo(dgvAnticipos.Table.CurrentRecord.GetValue("idDocumento"))
        '        .ShowDialog()
        '    End With

        'End If
    End Sub

    Private Sub ToolStripButton21_Click(sender As Object, e As EventArgs) Handles ToolStripButton21.Click
        If dgvAnticiposOtor.Table.SelectedRecords.Count > 0 Then
            ' btnNuevoPago(dgvPagosVarios.Table.CurrentRecord.GetValue("moneda"), dgvPagosVarios.Table.CurrentRecord.GetValue("idDocumento"))
            With FrmHistorialAnticipo
                .DetalleAnticipo(dgvAnticiposOtor.Table.CurrentRecord.GetValue("idDocumento"))
                .ShowDialog()
            End With

        End If
    End Sub

    Private Sub FrmAnticiposGeneral_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class