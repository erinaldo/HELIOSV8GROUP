Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess

Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Public Class frmMasterOrdenesGenerales
    Inherits frmMaster


    Dim filter As New GridExcelFilter()
    Private dt As DataTable
    Private dtTableGrd As DataTable
    Private chk As Boolean, check As Boolean = False
    Private ht As New ArrayList()
    Dim flag As String = Nothing
    Private CheckBoxValue As Boolean = False
    Dim TipoOrden As Integer

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        lblPeriodo.Text = "Período: " & PeriodoGeneral
        GridCFG(dgvAprobacion)
        'GridCFG(dgvCompras)
        GridCFG(dgvOrdenCompraAprob)
        'GridCFG(dgvServicio)
        GridCFG(dgvOrdenServicioAprobado)
        GridCFG(dgvListOrdenCompra)
        GridCFG(dgvListOrdenServicio)

    End Sub

    Private Sub ListBox1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListBox1.MouseDoubleClick
        Me.Cursor = Cursors.WaitCursor
        If ListBox1.SelectedItems.Count > 0 Then
            Me.PopupControlContainer2.HidePopup(PopupCloseType.Done)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PopupControlContainer2_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles PopupControlContainer2.BeforePopup
        Me.PopupControlContainer2.BackColor = Color.White
    End Sub

    Private Sub PopupControlContainer2_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles PopupControlContainer2.CloseUp
        Me.Cursor = Cursors.WaitCursor
        If e.PopupCloseType = PopupCloseType.Done Then
            Select Case ListBox1.Text
                Case "Orden de compra"
                    With frmOrdenCompra
                        .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        .WindowState = FormWindowState.Maximized
                        .ShowDialog()
                    End With
                Case "Orden de servicio"
                    With frmOrdenServicios
                        .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        .WindowState = FormWindowState.Maximized
                        .ShowDialog()
                    End With
            End Select
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then

        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btOperacion_Click(sender As Object, e As EventArgs)
        'Me.PopupControlContainer2.ParentControl = Me.btOperacion
        'Me.PopupControlContainer2.ShowPopup(Point.Empty)
    End Sub


#Region "Metodos"
    Sub GridCFG(GGC As GridGroupingControl)
        Dim colorx As New GridMetroColors()
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
      
        GGC.AllowProportionalColumnSizing = False
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center

        GGC.Table.DefaultColumnHeaderRowHeight = 23
        GGC.Table.DefaultRecordRowHeight = 20
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub
#End Region

#Region "metodos"

    Public Sub ListaOrdenCompraAprobado(ByVal strEstadoOrden As String)
        Dim DocumentoCompraSA As New DocumentoCompraSA
        ' Llamada necesaria para el diseñador.

        dt = New DataTable()
        dt.Columns.Add("idDocumento", GetType(String))
        dt.Columns.Add("NombreEntidad", GetType(String))
        dt.Columns.Add("fechaDoc", GetType(String))
        dt.Columns.Add("importeTotal", GetType(Decimal))
        dt.Columns.Add("importeUS", GetType(Decimal))
        dt.Columns.Add("tipoCompra", GetType(String))
        dt.Columns.Add("descripcionCompra", GetType(String))

        For Each row In DocumentoCompraSA.GetListarOrdenCompraNoAprobadoSL(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, strEstadoOrden, TIPO_COMPRA.ORDEN_APROBADO)
            Dim dr As DataRow = dt.NewRow()
            dr(0) = row.idDocumento
            dr(1) = row.NombreEntidad
            dr(2) = CDate(row.fechaDoc).Date
            dr(3) = row.importeTotal
            dr(4) = row.importeUS
            dr(5) = row.tipoCompra
            If row.tipoCompra = TIPO_COMPRA.ORDEN_APROBADO Then
                'dr(6) = True
                dr(6) = "APROBADO"
            Else
                'dr(6) = False
                dr(6) = "PENDIENTE"
            End If

            dt.Rows.Add(dr)
        Next
        Me.dgvOrdenCompraAprob.DataSource = dt
        Me.dgvOrdenCompraAprob.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = False

    End Sub

    Public Sub ListaOrdenCompraNoAprobado(ByVal strEstadoOrden As String)
        Dim DocumentoCompraSA As New DocumentoCompraSA
        ' Llamada necesaria para el diseñador.

        dt = New DataTable()
        dt.Columns.Add("idDocumento", GetType(String))
        dt.Columns.Add("nroDoc", GetType(String))
        dt.Columns.Add("tipoDoc", GetType(String))
        dt.Columns.Add("fechaDoc", GetType(String))
        dt.Columns.Add("moneda", GetType(String))
        dt.Columns.Add("NombreEntidad", GetType(String))
        dt.Columns.Add("importeMN", GetType(Decimal))
        dt.Columns.Add("importeME", GetType(Decimal))
        dt.Columns.Add("estado", GetType(String))
        dt.Columns.Add("descripcion", GetType(String)) '9
        dt.Columns.Add("tipoCompra", GetType(String))

        For Each row In DocumentoCompraSA.GetListarOrdenCompraNoAprobadoSL(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, strEstadoOrden, TIPO_COMPRA.ORDEN_COMPRA)
            Dim dr As DataRow = dt.NewRow()
            dr(0) = row.idDocumento
            dr(1) = row.numeroDoc
            dr(2) = row.tipoDoc
            dr(3) = (row.fechaDoc)
            dr(4) = row.monedaDoc
            dr(5) = row.NombreEntidad

            Select Case row.monedaDoc
                Case 1
                    dr(6) = row.importeTotal
                    dr(7) = 0.0

                Case 2
                    dr(6) = 0.0
                    dr(7) = row.importeUS

            End Select

            If row.situacion = TIPO_COMPRA.ORDEN_APROBADO Then
                dr(8) = True
                dr(9) = "LISTO PARA APROBAR"
            Else
                dr(8) = False
                dr(9) = "PENDIENTE"
            End If
            dr(10) = row.tipoCompra
            dt.Rows.Add(dr)
        Next



        Me.dgvListOrdenCompra.DataSource = dt
        Me.dgvListOrdenCompra.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = False

        'AddHandler dgvAprobacion.TableControlCheckBoxClick, AddressOf gridGroupingControl1_TableControlCheckBoxClick

    End Sub

    Public Sub EliminarDocumento(iddoc As Integer)
        Dim documentoSA As New DocumentoSA
        Dim nDocumento As New documento()
        documentoSA.DeleteSingleVariable(iddoc)
    End Sub

    Public Sub ListaOrdenServicio(srtEstadoOrden As String)
        Dim DocumentoCompraSA As New DocumentoCompraSA
        ' Llamada necesaria para el diseñador.

        dt = New DataTable()

        dt.Columns.Add("idDocumento", GetType(String))
        dt.Columns.Add("nroDoc", GetType(String))
        dt.Columns.Add("tipoDoc", GetType(String))
        dt.Columns.Add("fechaDoc", GetType(String))
        dt.Columns.Add("moneda", GetType(String))
        dt.Columns.Add("NombreEntidad", GetType(String))
        dt.Columns.Add("importeMN", GetType(Decimal))
        dt.Columns.Add("importeME", GetType(Decimal))
        dt.Columns.Add("estado", GetType(String))
        dt.Columns.Add("descripcion", GetType(String)) '9
        dt.Columns.Add("tipoCompra", GetType(String))

        For Each row In DocumentoCompraSA.GetListarOrdenCompraNoAprobadoSL(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, srtEstadoOrden, TIPO_COMPRA.ORDEN_SERVICIO)
            Dim dr As DataRow = dt.NewRow()
            dr(0) = row.idDocumento
            dr(1) = row.numeroDoc
            dr(2) = row.tipoDoc
            dr(3) = (row.fechaDoc)
            dr(4) = row.monedaDoc
            dr(5) = row.NombreEntidad
            Select Case row.monedaDoc
                Case 1
                    dr(6) = row.importeTotal
                    dr(7) = 0.0
                Case 2
                    dr(6) = 0.0
                    dr(7) = row.importeUS
            End Select
            If row.situacion = TIPO_COMPRA.ORDEN_SERVICIO_APROBADO Then
                dr(8) = True
                dr(9) = "LISTO PARA APROBAR ORDEN"
            Else
                dr(8) = False
                dr(9) = "ENTREGABLES PENDIENTE"
            End If
            dr(10) = row.tipoCompra
            dt.Rows.Add(dr)
        Next
        Me.dgvListOrdenServicio.DataSource = dt
        Me.dgvListOrdenServicio.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = False

        'AddHandler dgvAprobacionServ.TableControlCheckBoxClick, AddressOf gridGroupingControlServi_TableControlCheckBoxClick
    End Sub

    Public Sub ListaOrdenServicioAprobado(srtEstadoOrden As String)
        Dim DocumentoCompraSA As New DocumentoCompraSA
        ' Llamada necesaria para el diseñador.

        dt = New DataTable()
        dt.Columns.Add("idDocumento", GetType(String))
        dt.Columns.Add("NombreEntidad", GetType(String))
        dt.Columns.Add("fechaDoc", GetType(String))
        dt.Columns.Add("importeTotal", GetType(Decimal))
        dt.Columns.Add("importeUS", GetType(Decimal))
        dt.Columns.Add("tipoCompra", GetType(String))
        dt.Columns.Add("descripcionCompra", GetType(String))

        For Each row In DocumentoCompraSA.GetListarOrdenCompraNoAprobadoSL(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, srtEstadoOrden, TIPO_COMPRA.ORDEN_SERVICIO_APROBADO)
            Dim dr As DataRow = dt.NewRow()
            'dr(0) = row.idDocumento
            'dr(1) = row.NombreEntidad
            'dr(2) = CDate(row.fechaDoc).Date
            'dr(3) = row.tipoCompra
            'If row.tipoCompra = TIPO_COMPRA.ORDEN_SERVICIO_APROBADO Then
            '    dr(4) = "APROBADO"
            '    'ckAprobarFull.Checked = True
            'Else
            '    dr(4) = "PENDIENTE"
            '    'ckAprobarFull.Checked = False
            'End If

            dr(0) = row.idDocumento
            dr(1) = row.NombreEntidad
            dr(2) = CDate(row.fechaDoc).Date
            dr(3) = row.importeTotal
            dr(4) = row.importeUS
            dr(5) = row.tipoCompra
            If row.tipoCompra = TIPO_COMPRA.ORDEN_SERVICIO_APROBADO Then
                'dr(6) = True
                dr(6) = "APROBADO"
            Else
                'dr(6) = False
                dr(6) = "PENDIENTE"
            End If



            dt.Rows.Add(dr)
        Next
        Me.dgvOrdenServicioAprobado.DataSource = dt
        Me.dgvOrdenServicioAprobado.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = False

        'AddHandler dgvAprobacionServ.TableControlCheckBoxClick, AddressOf gridGroupingControlServi_TableControlCheckBoxClick

    End Sub
#End Region

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

    Private Sub dgvServicio_TableControlDrawCell(sender As Object, e As GridTableControlDrawCellEventArgs) Handles dgvServicio.TableControlDrawCell
        If e.Inner.Style.CellType = "PushButton" Then
            e.Inner.Cancel = True

            ' //Draw the Image in a cell.
            If e.Inner.ColIndex = 6 Then
                e.Inner.Style.Description = "btMuevo"
                Dim sButtonText As String = e.Inner.Style.Description
                e.Inner.Style.Description = String.Empty
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)

                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3), New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6))
                e.Inner.Graphics.DrawImage(Me.ImageList1.Images(0), irect)
            End If

            If e.Inner.ColIndex = 7 Then
                e.Inner.Style.Description = "btEditar"
                Dim sButtonText As String = e.Inner.Style.Description
                e.Inner.Style.Description = String.Empty
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)

                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3), New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6))

                e.Inner.Graphics.DrawImage(Me.ImageList1.Images(1), irect)
            End If

        End If

    End Sub

    Private Sub dgvServicio_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs) Handles dgvServicio.TableControlPushButtonClick
        Me.Cursor = Cursors.WaitCursor
        Dim nRecursoSA As New DocumentoCompraSA
        Dim nRecurso As New documentocompra
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        Try
            If e.Inner.ColIndex = 6 Then
                If (Me.dgvServicio.TableModel(e.Inner.RowIndex, 5).CellValue = True) Then
                    nRecurso = New documentocompra
                    With nRecurso
                        .Action = Business.Entity.BaseBE.EntityAction.UPDATE
                        .idDocumento = CInt(Me.dgvServicio.TableModel(e.Inner.RowIndex, 1).CellValue)
                        .tipoCompra = TIPO_COMPRA.ORDEN_SERVICIO_APROBADO
                    End With
                    nRecursoSA.EstadoSoli(nRecurso)
                    ListaOrdenServicio(TIPO_COMPRA.ORDEN_SERVICIO)
                    'Me.dgvServicio.Table.CurrentRecord.Delete()
                    PanelError.Visible = True
                    lblEstado.Text = "Orden de servicio fue aprobado con exito!"
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                Else
                    lblEstado.Visible = True
                    PanelError.Visible = True
                    lblEstado.Text = "Debe ingresar el objeto de la contratación"
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                End If
            ElseIf e.Inner.ColIndex = 7 Then
                'If Not IsNothing(Me.dgvServicio.Table.CurrentRecord) Then

                If Not IsNothing(Me.dgvServicio.TableModel(e.Inner.RowIndex, 1).CellValue) Then
                    With frmDetalleOrdenServicio
                        datos.Clear()
                        .UbicarDocumentoServicio((Me.dgvServicio.TableModel(e.Inner.RowIndex, 1).CellValue))
                        .StartPosition = FormStartPosition.CenterParent
                        '.WindowState = FormWindowState.Maximized
                        .ShowDialog()
                        If datos.Count > 0 Then
                            If (datos(0).IdProceso = 1) Then
                                Me.dgvServicio.TableModel(e.Inner.RowIndex, 5).CellValue = True
                                Me.dgvServicio.TableModel(e.Inner.RowIndex, 4).CellValue = "LISTO PARA APROBAR ORDEN"
                                'Me.dgvServicio.Table.CurrentRecord.SetValue("Estado", True)
                                'Me.dgvServicio.Table.CurrentRecord.SetValue("descripcion", "LISTO PARA APROBAR ORDEN")
                            End If
                        End If
                    End With
                End If
            End If
            'End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvCompras_TableControlDrawCell(sender As Object, e As GridTableControlDrawCellEventArgs) Handles dgvCompras.TableControlDrawCell
        If e.Inner.Style.CellType = "PushButton" Then
            e.Inner.Cancel = True

            ' //Draw the Image in a cell.
            If e.Inner.ColIndex = 8 Then
                e.Inner.Style.Description = "btMuevo"
                Dim sButtonText As String = e.Inner.Style.Description
                e.Inner.Style.Description = String.Empty
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)

                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3), New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6))
                e.Inner.Graphics.DrawImage(Me.ImageList1.Images(0), irect)
            End If

            If e.Inner.ColIndex = 9 Then
                e.Inner.Style.Description = "btEditar"
                Dim sButtonText As String = e.Inner.Style.Description
                e.Inner.Style.Description = String.Empty
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)

                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3), New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6))

                e.Inner.Graphics.DrawImage(Me.ImageList1.Images(1), irect)
            End If

        End If

    End Sub

    Private Sub dgvCompras_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs) Handles dgvCompras.TableControlPushButtonClick
        Me.Cursor = Cursors.WaitCursor
        Dim nRecursoSA As New DocumentoCompraSA
        Dim nRecurso As New documentocompra
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        Try
            If e.Inner.ColIndex = 8 Then
                If (Me.dgvCompras.TableModel(e.Inner.RowIndex, 6).CellValue = True) Then
                    nRecurso = New documentocompra
                    With nRecurso
                        .Action = Business.Entity.BaseBE.EntityAction.UPDATE
                        .idDocumento = CInt(Me.dgvCompras.TableModel(e.Inner.RowIndex, 1).CellValue)
                        .tipoCompra = TIPO_COMPRA.ORDEN_APROBADO
                    End With
                    nRecursoSA.EstadoSoli(nRecurso)
                    'Me.dgvCompras.Table.CurrentRecord.Delete()
                    ListaOrdenCompraNoAprobado(TIPO_COMPRA.ORDEN_COMPRA)
                    PanelError.Visible = True
                    lblEstado.Text = "Orden de compra fue aprobado con exito!"
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                Else
                    PanelError.Visible = True
                    lblEstado.Text = "Debe ingresar fechas de entrega"
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                End If
            ElseIf e.Inner.ColIndex = 9 Then
                'If Not IsNothing(Me.dgvCompras.Table.CurrentRecord) Then
                If (Not IsNothing(Me.dgvCompras.TableModel(e.Inner.RowIndex, 1).CellValue)) Then
                    'If Not IsNothing(Me.dgvCompras.Table.CurrentRecord.GetValue("idDocumento")) Then
                    With frmDetalleOrdenDeCompra
                        datos.Clear()
                        .idDocumento = (Me.dgvCompras.TableModel(e.Inner.RowIndex, 1).CellValue) ' (Me.dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))
                        '.HistorialCompra(Me.dgvCompras.TableModel(e.Inner.RowIndex, 1).CellValue)
                        .StartPosition = FormStartPosition.CenterParent
                        .WindowState = FormWindowState.Maximized
                        .ShowDialog()

                        If datos.Count > 0 Then
                            If (datos(0).IdProceso = 1) Then
                                ListaOrdenCompraNoAprobado(TIPO_COMPRA.ORDEN_COMPRA)
                            End If
                        End If

                    End With
                    'End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvAprobacion_TableControlDrawCell(sender As Object, e As GridTableControlDrawCellEventArgs) Handles dgvAprobacion.TableControlDrawCell
        If e.Inner.Style.CellType = "PushButton" Then
            e.Inner.Cancel = True

            If e.Inner.ColIndex = 7 Then
                e.Inner.Style.Description = "btEditar"
                Dim sButtonText As String = e.Inner.Style.Description
                e.Inner.Style.Description = String.Empty
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)

                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3), New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6))
                e.Inner.Graphics.DrawImage(Me.ImageList1.Images(1), irect)
            End If

        End If
    End Sub

    Private Sub dgvAprobacion_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs) Handles dgvAprobacion.TableControlPushButtonClick
        Me.Cursor = Cursors.WaitCursor
        Dim nRecursoSA As New DocumentoCompraSA
        Dim nRecurso As New documentocompra
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        Try
            If e.Inner.ColIndex = 7 Then
                'If Not IsNothing(Me.dgvAprobacion.Table.CurrentRecord) Then
                If ((Me.dgvAprobacion.TableModel(e.Inner.RowIndex, 1).CellValue)) Then
                    With frmOrdenDeCompraExistencia
                        .UbicarDocumentos(CInt(Me.dgvAprobacion.TableModel(e.Inner.RowIndex, 1).CellValue))
                        .StartPosition = FormStartPosition.CenterParent
                        .WindowState = FormWindowState.Maximized
                        .ShowDialog()
                    End With
                End If
                'End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvServicioAprobado_TableControlDrawCell(sender As Object, e As GridTableControlDrawCellEventArgs) Handles dgvServicioAprobado.TableControlDrawCell
        If e.Inner.Style.CellType = "PushButton" Then
            e.Inner.Cancel = True

            If e.Inner.ColIndex = 5 Then
                e.Inner.Style.Description = "btEditar"
                Dim sButtonText As String = e.Inner.Style.Description
                e.Inner.Style.Description = String.Empty
                e.Inner.Renderer.Draw(e.Inner.Graphics, e.Inner.Bounds, e.Inner.RowIndex, e.Inner.ColIndex, e.Inner.Style)

                Dim irect As New Rectangle(New Point(e.Inner.Bounds.X + 3, e.Inner.Bounds.Y + 3), New Size(e.Inner.Bounds.Size.Width - 6, e.Inner.Bounds.Size.Height - 6))
                e.Inner.Graphics.DrawImage(Me.ImageList1.Images(1), irect)
            End If

        End If
    End Sub

    Private Sub dgvServicioAprobado_TableControlPushButtonClick(sender As Object, e As GridTableControlCellPushButtonClickEventArgs) Handles dgvServicioAprobado.TableControlPushButtonClick
        Me.Cursor = Cursors.WaitCursor
        Dim nRecursoSA As New DocumentoCompraSA
        Dim nRecurso As New documentocompra
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        Try
            If e.Inner.ColIndex = 5 Then
                'If Not IsNothing(Me.dgvServicioAprobado.Table.CurrentRecord) Then
                If Not IsNothing(Me.dgvServicioAprobado.TableModel(e.Inner.RowIndex, 1).CellValue) Then
                    With frmOrdenServiciosGeneral
                        .limpiarCaja()
                        .UbicarDocumentoServicio(CInt(Me.dgvServicioAprobado.TableModel(e.Inner.RowIndex, 1).CellValue))
                        .StartPosition = FormStartPosition.CenterParent
                        .ShowDialog()
                    End With
                End If
            End If
            'End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Public Sub refrecarOrdenDeCompra()
        TabPageAdv4.Parent = Nothing
        TabPageAdv1.Parent = TabControlAdv1
        TabPageAdv2.Parent = Nothing
        TabPageAdv3.Parent = Nothing
        ListaOrdenCompraNoAprobado(TIPO_COMPRA.ORDEN_COMPRA)
    End Sub


    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        dt.DefaultView.RowFilter = "NombreEntidad Like '%" & txtBuscar.Text & "%'"
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        dt.DefaultView.RowFilter = "NombreEntidad Like '%" & TextBox1.Text & "%'"
    End Sub


    Private Sub CompraDeExistenciasServiciosToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub CompraDeServiciosPúblicosToolStripMenuItem_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub btAprobar_Click(sender As Object, e As EventArgs)




    End Sub

    Private Sub btDeleSel_Click(sender As Object, e As EventArgs)
        'If TabControlAdv2.SelectedTab Is tabOrdenCompra Then
        '    If Not IsNothing(Me.dgvOrdenCompra.Table.CurrentRecord) Then
        '        With frmOrdenDeCompraExistencia
        '            .UbicarDocumentos(CInt(Me.dgvOrdenCompra.Table.CurrentRecord.GetValue("idDocumento")))
        '            .StartPosition = FormStartPosition.CenterParent
        '            .WindowState = FormWindowState.Maximized
        '            .ShowDialog()
        '        End With
        '    End If

        'ElseIf TabControlAdv2.SelectedTab Is tabOrdenServicio Then
        '    If Not IsNothing(Me.dgvServicioAprobado.Table.CurrentRecord) Then
        '        With frmOrdenDeCompraExistencia
        '            .UbicarDocumentos(CInt(Me.dgvServicioAprobado.Table.CurrentRecord.GetValue("idDocumento")))
        '            .StartPosition = FormStartPosition.CenterParent
        '            .WindowState = FormWindowState.Maximized
        '            .ShowDialog()
        '        End With
        '    End If
        'End If

        Me.Cursor = Cursors.WaitCursor
        Select Case tvaListaOrden.SelectedNode.Text
            Case "Servicio"
                If Not IsNothing(Me.dgvServicio.Table.CurrentRecord) Then

                    Dim f As New frmOrdenCompras("ORDEN")
                    f.strTipo = "ORDEN"
                    f.WindowState = FormWindowState.Normal
                    f.lblIdDocumento = Me.dgvServicio.Table.CurrentRecord.GetValue("idDocumento")
                    f.UbicarDocumento(Me.dgvServicio.Table.CurrentRecord.GetValue("idDocumento"))
                    f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                    f.ShowDialog()
                End If

            Case "Servicios aprobados"

            Case "Compra"

                If Not IsNothing(Me.dgvListOrdenCompra.Table.CurrentRecord) Then
                    Dim f As New frmOrdenCompras("ORDEN")
                    f.strTipo = "ORDEN"
                    f.WindowState = FormWindowState.Normal
                    f.lblIdDocumento = Me.dgvListOrdenCompra.Table.CurrentRecord.GetValue("idDocumento")
                    f.UbicarDocumento(Me.dgvListOrdenCompra.Table.CurrentRecord.GetValue("idDocumento"))
                    f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                    f.ShowDialog()
                End If


        End Select


    End Sub

    Private Sub ToolStripButton2_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Me.Cursor = Cursors.WaitCursor
        Select Case TipoOrden
            Case 1 ' ORDEN SERVICIO
                ListaOrdenServicio(TIPO_COMPRA.ORDEN_SERVICIO)
            Case 2 ' ORDEN COMPRA
                ListaOrdenCompraNoAprobado(TIPO_COMPRA.ORDEN_COMPRA)
            Case 3 ' APROBAR ORDEN COMPRA
                ListaOrdenCompraAprobado(TIPO_COMPRA.ORDEN_APROBADO)
            Case 4
                ListaOrdenCompraAprobado(TIPO_COMPRA.ORDEN_APROBADO)
        End Select
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton1_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Me.Cursor = Cursors.WaitCursor
        If TabControlAdv2.SelectedTab Is tabOrdenCompra Then
            If Not IsNothing(Me.dgvListOrdenCompra.Table.CurrentRecord) Then
                If MessageBox.Show("Desea Elimiar el item seleccionado?", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    EliminarDocumento(Val(Me.dgvListOrdenCompra.Table.CurrentRecord.GetValue("idDocumento")))
                End If
            Else
                MessageBox.Show("Debe seleccionar un item válido!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        ElseIf (TabControlAdv2.SelectedTab Is tabOrdenServicio) Then
            If Not IsNothing(Me.dgvListOrdenServicio.Table.CurrentRecord) Then
                If MessageBox.Show("Desea Elimiar el item seleccionado?", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    EliminarDocumento(Val(Me.dgvListOrdenServicio.Table.CurrentRecord.GetValue("idDocumento")))
                End If
            Else
                MessageBox.Show("Debe seleccionar un item válido!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs) Handles ToolStripButton9.Click
        Me.Cursor = Cursors.WaitCursor
        Select Case TipoOrden
            Case 1
                If Not IsNothing(Me.dgvListOrdenServicio.Table.CurrentRecord) Then

                    Dim f As New frmOrdenCompras("SERVICIO")
                    f.strTipo = "SERVICIO"
                    f.WindowState = FormWindowState.Normal
                    f.lblIdDocumento = Me.dgvListOrdenServicio.Table.CurrentRecord.GetValue("idDocumento")
                    f.UbicarDocumento(Me.dgvListOrdenServicio.Table.CurrentRecord.GetValue("idDocumento"))
                    f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                    f.ShowDialog()


                    'With frmOrdenServicios
                    '    .lblIdDocumento = Me.dgvServicio.Table.CurrentRecord.GetValue("idDocumento")
                    '    .UbicarDocumentos(Me.dgvServicio.Table.CurrentRecord.GetValue("idDocumento"))
                    '    .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                    '    .WindowState = FormWindowState.Maximized
                    '    .Tag = "M"
                    '    .ShowDialog()
                    'End With
                End If

            Case 4

            Case 2

                If Not IsNothing(Me.dgvListOrdenCompra.Table.CurrentRecord) Then
                    Dim f As New frmOrdenCompras("ORDEN")
                    f.strTipo = "ORDEN"
                    f.WindowState = FormWindowState.Normal
                    f.lblIdDocumento = Me.dgvListOrdenCompra.Table.CurrentRecord.GetValue("idDocumento")
                    f.UbicarDocumento(Me.dgvListOrdenCompra.Table.CurrentRecord.GetValue("idDocumento"))
                    f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                    f.ShowDialog()
                End If
                '    With frmOrdenCompra
                '        .lblIdDocumento = Me.dgvCompras.Table.CurrentRecord.GetValue("idDocumento")
                '        .UbicarDocumentos(Me.dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))
                '        .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                '        .WindowState = FormWindowState.Maximized
                '        '.Tag = "M"
                '        .ShowDialog()
                '    End With
                'End If

        End Select
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton16_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub

    Sub UpdateDoc(intIdDocumento As Integer)
        Dim nRecursoSA As New DocumentoCompraSA
        Dim nRecurso As New documentocompra
        nRecurso = New documentocompra With {
        .Action = Business.Entity.BaseBE.EntityAction.UPDATE,
        .idDocumento = intIdDocumento,
        .tipoCompra = TIPO_COMPRA.ORDEN_APROBADO}
        If (nRecursoSA.EstadoSoli(nRecurso)) Then
            'lblEstado.Text = " editado!"
            'lblEstado.Image = My.Resources.ok4
        Else
            'lblEstado.Text = "Error al grabar Cadena!"
            'lblEstado.Image = My.Resources.cross
        End If
    End Sub

    Sub UpdateDocServicio(intIdDocumento As Integer)
        Dim nRecursoSA As New DocumentoCompraSA
        Dim nRecurso As New documentocompra
        nRecurso = New documentocompra With {
        .Action = Business.Entity.BaseBE.EntityAction.UPDATE,
        .idDocumento = intIdDocumento,
        .tipoCompra = TIPO_COMPRA.ORDEN_SERVICIO_APROBADO}
        If (nRecursoSA.EstadoSoli(nRecurso)) Then
            'lblEstado.Text = " editado!"
            'lblEstado.Image = My.Resources.ok4
        Else
            'lblEstado.Text = "Error al grabar Cadena!"
            'lblEstado.Image = My.Resources.cross
        End If
    End Sub


    Private Sub lblEfectivo_Click(sender As Object, e As EventArgs) Handles lblEfectivo.Click
        tabOrdenCompra.Parent = TabControlAdv2
        TabOrdenCompraAprob.Parent = Nothing
        tabOrdenServicio.Parent = Nothing
        tabOrdenServicioAprob.Parent = Nothing
        TabDashboard.Parent = Nothing
        ListaOrdenCompraNoAprobado(TIPO_COMPRA.ORDEN_COMPRA)
        TipoOrden = 2
    End Sub

    Private Sub Label27_Click(sender As Object, e As EventArgs) Handles Label27.Click
        tabOrdenCompra.Parent = Nothing
        TabOrdenCompraAprob.Parent = Nothing
        tabOrdenServicio.Parent = Nothing
        tabOrdenServicioAprob.Parent = TabControlAdv2
        TabDashboard.Parent = Nothing
        ListaOrdenServicioAprobado(TIPO_COMPRA.ORDEN_SERVICIO_APROBADO)
        TipoOrden = 3
    End Sub

    Private Sub Label29_Click(sender As Object, e As EventArgs) Handles Label29.Click
        tabOrdenCompra.Parent = Nothing
        TabOrdenCompraAprob.Parent = Nothing
        tabOrdenServicio.Parent = TabControlAdv2
        tabOrdenServicioAprob.Parent = Nothing
        TabDashboard.Parent = Nothing
        ListaOrdenServicio(TIPO_COMPRA.ORDEN_SERVICIO)
        TipoOrden = 1
    End Sub

    Private Sub lblTarjeta_Click(sender As Object, e As EventArgs) Handles lblTarjeta.Click
        tabOrdenCompra.Parent = Nothing
        TabOrdenCompraAprob.Parent = TabControlAdv2
        tabOrdenServicio.Parent = Nothing
        tabOrdenServicioAprob.Parent = Nothing
        TabDashboard.Parent = Nothing
        ListaOrdenCompraAprobado(TIPO_COMPRA.ORDEN_APROBADO)

        TipoOrden = 4
    End Sub

    Private Sub ToolStripButton11_Click(sender As Object, e As EventArgs) Handles tsbOC.Click
        Dim f As New frmOrdenCompras("ORDEN")
        f.strTipo = "ORDEN"
        f.WindowState = FormWindowState.Normal
        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        f.ShowDialog()

        ListaOrdenCompraNoAprobado(TIPO_COMPRA.ORDEN_COMPRA)
    End Sub


    Private Sub tvaListaOrden_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles tvaListaOrden.MouseDoubleClick
        'Me.Cursor = Cursors.WaitCursor
        LoadingAnimator.Wire(Me.dgvCompras.TableControl)
        Select Case tvaListaOrden.SelectedNode.Text
            Case "Dashboard"
                TabDashboard.Parent = Nothing
                tabOrdenCompra.Parent = Nothing
                tabOrdenServicio.Parent = Nothing
                TabOrdenCompraAprob.Parent = Nothing
                tabOrdenServicioAprob.Parent = Nothing

            Case "Orden de compras"
                GridCFG(dgvListOrdenCompra)

                TabDashboard.Parent = Nothing
                tabOrdenCompra.Parent = TabControlAdv2
                tabOrdenServicio.Parent = Nothing
                TabOrdenCompraAprob.Parent = Nothing
                tabOrdenServicioAprob.Parent = Nothing
                ListaOrdenCompraNoAprobado(TIPO_COMPRA.ORDEN_COMPRA)
                TipoOrden = 2
                tsbOC.Visible = True
                tsbOS.Visible = False
            Case "Orden de servicios"
                GridCFG(dgvListOrdenServicio)
                'btSelectAll.Visible = False
                TabDashboard.Parent = Nothing
                tabOrdenCompra.Parent = Nothing
                tabOrdenServicio.Parent = TabControlAdv2
                TabOrdenCompraAprob.Parent = Nothing
                tabOrdenServicioAprob.Parent = Nothing
                ListaOrdenServicio(TIPO_COMPRA.ORDEN_SERVICIO)
                TipoOrden = 1
                tsbOC.Visible = False
                tsbOS.Visible = True

            Case "Orden de compras aprobadas"
                GridCFG(dgvOrdenCompraAprob)
                TabDashboard.Parent = Nothing
                tabOrdenCompra.Parent = Nothing
                tabOrdenServicio.Parent = Nothing
                TabOrdenCompraAprob.Parent = TabControlAdv2
                tabOrdenServicioAprob.Parent = Nothing
                ListaOrdenCompraAprobado(TIPO_COMPRA.ORDEN_APROBADO)
                TipoOrden = 4

            Case "Orden de servicios aprobadas"
                GridCFG(dgvOrdenServicioAprobado)
                TabDashboard.Parent = Nothing
                tabOrdenCompra.Parent = Nothing
                tabOrdenServicio.Parent = Nothing
                TabOrdenCompraAprob.Parent = Nothing
                tabOrdenServicioAprob.Parent = TabControlAdv2
                ListaOrdenServicioAprobado(TIPO_COMPRA.ORDEN_SERVICIO_APROBADO)
                TipoOrden = 3

        End Select
        '   Me.Cursor = Cursors.Arrow
        LoadingAnimator.UnWire(Me.dgvCompras.TableControl)
    End Sub

    Private Sub tvaListaOrden_AfterSelect(sender As Object, e As EventArgs) Handles tvaListaOrden.AfterSelect
        Select Case tvaListaOrden.SelectedNode.Text
            Case "Dashboard"
                TabDashboard.Parent = Nothing
                tabOrdenCompra.Parent = Nothing
                tabOrdenServicio.Parent = Nothing
                TabOrdenCompraAprob.Parent = Nothing
                tabOrdenServicioAprob.Parent = Nothing

            Case "Orden de compras"
                GridCFG(dgvListOrdenCompra)

                TabDashboard.Parent = Nothing
                tabOrdenCompra.Parent = TabControlAdv2
                tabOrdenServicio.Parent = Nothing
                TabOrdenCompraAprob.Parent = Nothing
                tabOrdenServicioAprob.Parent = Nothing

            Case "Orden de servicios"
                GridCFG(dgvListOrdenServicio)
                'btSelectAll.Visible = False
                TabDashboard.Parent = Nothing
                tabOrdenCompra.Parent = Nothing
                tabOrdenServicio.Parent = TabControlAdv2
                TabOrdenCompraAprob.Parent = Nothing
                tabOrdenServicioAprob.Parent = Nothing

            Case "Orden de compras aprobadas"
                GridCFG(dgvOrdenCompraAprob)
                TabDashboard.Parent = Nothing
                tabOrdenCompra.Parent = Nothing
                tabOrdenServicio.Parent = Nothing
                TabOrdenCompraAprob.Parent = TabControlAdv2
                tabOrdenServicioAprob.Parent = Nothing

            Case "Orden de servicios aprobadas"
                GridCFG(dgvOrdenServicioAprobado)
                TabDashboard.Parent = Nothing
                tabOrdenCompra.Parent = Nothing
                tabOrdenServicio.Parent = Nothing
                TabOrdenCompraAprob.Parent = Nothing
                tabOrdenServicioAprob.Parent = TabControlAdv2

        End Select
        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        Me.Cursor = Cursors.WaitCursor
        If TabControlAdv2.SelectedTab Is tabOrdenCompra Then
            If Not IsNothing(Me.dgvListOrdenCompra.Table.CurrentRecord) Then
                If MessageBox.Show("Desea aprobar la orden seleccionada?", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    If (Me.dgvListOrdenCompra.Table.CurrentRecord.GetValue("descripcion") = "LISTO PARA APROBAR") Then
                        UpdateDoc(Me.dgvListOrdenCompra.Table.CurrentRecord.GetValue("idDocumento"))
                        dgvListOrdenCompra.Table.CurrentRecord.Delete()
                    Else
                        MessageBox.Show("Debe ingresar detalles de entrega!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End If
            Else
                MessageBox.Show("Debe seleccionar un item válido!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        ElseIf (TabControlAdv2.SelectedTab Is tabOrdenServicio) Then
            If MessageBox.Show("Desea aprobar la orden seleccionada?", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If (Me.dgvListOrdenServicio.Table.CurrentRecord.GetValue("descripcion") = "LISTO PARA APROBAR ORDEN") Then
                    UpdateDocServicio(Me.dgvListOrdenServicio.Table.CurrentRecord.GetValue("idDocumento"))
                    dgvListOrdenServicio.Table.CurrentRecord.Delete()
                Else
                    MessageBox.Show("Debe ingresar detalles de entrega!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        Else
            MessageBox.Show("Debe seleccionar un item válido!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        If TabControlAdv2.SelectedTab Is tabOrdenCompra Then
            If Not IsNothing(Me.dgvListOrdenCompra.Table.CurrentRecord) Then

                With frmDetalleOrdenDeCompra
                    'datos.Clear()
                    .idDocumento = (Me.dgvListOrdenCompra.Table.CurrentRecord.GetValue("idDocumento")) ' (Me.dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))
                    '.HistorialCompra(Me.dgvListOrdenCompra.Table.CurrentRecord.GetValue("idDocumento"))
                    '.ListardataGRid(Me.dgvListOrdenCompra.Table.CurrentRecord.GetValue("moneda"))
                    .txtProveedor.Text = Me.dgvListOrdenCompra.Table.CurrentRecord.GetValue("NombreEntidad")

                    'Select Case Me.dgvListOrdenCompra.Table.CurrentRecord.GetValue("moneda")
                    '    Case 1
                    '        .txtMoneda.Text = "NACIONAL"
                    '    Case 2
                    '        .txtMoneda.Text = "EXTRANJERA"
                    'End Select

                    .StartPosition = FormStartPosition.CenterParent
                    '.WindowState = FormWindowState.Maximized
                    .ShowDialog()


                    ListaOrdenCompraNoAprobado(TIPO_COMPRA.ORDEN_COMPRA)


                    'If Not IsNothing(Me.dgvListOrdenCompra.Table.CurrentRecord) Then
                    '    If MessageBox.Show("Desea aprobar la orden seleccionada?", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    '        If (Me.dgvListOrdenCompra.Table.CurrentRecord.GetValue("descripcion") = "LISTO PARA APROBAR") Then
                    '            UpdateDoc(Me.dgvListOrdenCompra.Table.CurrentRecord.GetValue("idDocumento"))
                    '            dgvListOrdenCompra.Table.CurrentRecord.Delete()
                    '        Else
                    '            MessageBox.Show("Debe ingresar detalles de entrega!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    '        End If
                    '    End If
                    'Else
                    '    MessageBox.Show("Debe seleccionar un item válido!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    'End If


                    'If datos.Count > 0 Then
                    '    If (datos(0).IdProceso = 1) Then
                    '        ListaOrdenCompraNoAprobado(TIPO_COMPRA.ORDEN_COMPRA)
                    '    End If
                    'End If

                End With


            End If

        ElseIf TabControlAdv2.SelectedTab Is tabOrdenServicio Then
            If Not IsNothing(Me.dgvListOrdenServicio.Table.CurrentRecord) Then

                With frmDetalleOrdenServicio
                    'datos.Clear()
                    .idDocumento = (Me.dgvListOrdenServicio.Table.CurrentRecord.GetValue("idDocumento")) ' (Me.dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))
                    .UbicarDocumentoServicio(Me.dgvListOrdenServicio.Table.CurrentRecord.GetValue("idDocumento"))
                    .StartPosition = FormStartPosition.CenterParent

                    .txtProveedorServicio.Text = Me.dgvListOrdenServicio.Table.CurrentRecord.GetValue("NombreEntidad")

                    Select Case Me.dgvListOrdenServicio.Table.CurrentRecord.GetValue("moneda")
                        Case 1
                            .txtMoneda.Text = "NACIONAL"
                        Case 2
                            .txtMoneda.Text = "EXTRANJERA"
                    End Select
                    .actualizaDataGridEstado()
                    '.WindowState = FormWindowState.Maximized
                    .ShowDialog()

                    ListaOrdenCompraNoAprobado(TIPO_COMPRA.ORDEN_SERVICIO)

                End With
            End If
        End If

    End Sub

    Private Sub ToolStripButton13_Click(sender As Object, e As EventArgs) Handles tsbOS.Click
        Dim f As New frmOrdenCompras("SERVICIOS")
        f.strTipo = "SERVICIOS"
        f.WindowState = FormWindowState.Normal
        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        f.ShowDialog()
        ListaOrdenServicio(TIPO_COMPRA.ORDEN_SERVICIO)
    End Sub
End Class