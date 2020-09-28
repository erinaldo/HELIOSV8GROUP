Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General.Constantes
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.GridHelperClasses

Public Class frmClientesMaestro

#Region "Attributes"
    Dim entidad As New entidadSA
    Dim documentoVentasSA As New documentoVentaAbarrotesSA
    Dim SumVentaProveedor As Integer = 0
    Dim selectionColl As New Hashtable()
    Dim hoveredIndex As Integer = 0
    Dim UsuarioEstadoCaja As New UsuarioEstadoCaja
    Dim objEntidad As New entidad
    Dim filter As New GridExcelFilter()
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGrid(dgvCliente)
        ListaClientes()
    End Sub
#End Region

#Region "Methods"
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

    Private Sub IsMouseHover(row As Integer, col As Integer, isHover As Boolean, GGC As GridGroupingControl)
        Dim color As New GridMetroColors()
        Dim id As GridTableCellStyleInfoIdentity = GGC.TableControl.GetTableViewStyleInfo(row, col).TableCellIdentity
        If id.DisplayElement.IsRecord() Then
            Dim key As Integer = id.DisplayElement.GetRecord().Id
            hoveredIndex = row
            selectionColl.Clear()
            GGC.TableControl.Refresh()
        End If
        GGC.TableControl.Selections.Clear()
    End Sub

    Private Sub ListaClientes()
        Dim dt As New DataTable()
        dt.Columns.Add("idEntidad")
        dt.Columns.Add("tipoDoc")
        dt.Columns.Add("nroDoc")
        dt.Columns.Add("tipo")
        dt.Columns.Add("razon")
        dt.Columns.Add("direc")
        dt.Columns.Add("fono")

        For Each i In entidad.GetListarEntidad(New entidad With {.tipoEntidad = TIPO_ENTIDAD.CLIENTE, .idEmpresa = Gempresas.IdEmpresaRuc, .idOrganizacion = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.idEntidad
            Select Case i.tipoDoc
                Case "6"
                    dr(1) = "RUC"
                Case "1"
                    dr(1) = "DNI"
                Case "7"
                    dr(1) = "PASSAPORTE"
                Case "4"
                    dr(1) = "CARNET DE EXTRANJERIA"
            End Select

            dr(2) = i.nrodoc
            dr(3) = IIf(i.tipoPersona = "N", "NATURAL", "JURIDICO")
            dr(4) = i.nombreCompleto
            dr(5) = i.direccion
            dr(6) = i.telefono
            dt.Rows.Add(dr)
        Next
        dgvCliente.DataSource = dt
    End Sub

    Sub ElimnarCliente()
        UsuarioEstadoCaja = New UsuarioEstadoCaja
        objEntidad = New entidad
        If Not IsNothing(Me.dgvCliente.Table.CurrentRecord) Then
            objEntidad.idEntidad = Me.dgvCliente.Table.CurrentRecord.GetValue("idEntidad")
            entidad.DeleteEntidad(objEntidad)
            dgvCliente.Table.CurrentRecord.Delete()
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
            lblEstado.Text = "Cliente eliminado!"

        End If
    End Sub
#End Region

#Region "Events"

    Private Sub ToggleButton21_ButtonStateChanged(sender As Object, e As ToggleButton2.ToggleButtonStateEventArgs) Handles ToggleButton21.ButtonStateChanged
        If ToggleButton21.ToggleState = ToggleButton2.ToggleButtonState.OFF Then
            dgvCliente.TopLevelGroupOptions.ShowFilterBar = True
            dgvCliente.NestedTableGroupOptions.ShowFilterBar = True
            dgvCliente.ChildGroupOptions.ShowFilterBar = True
            For Each col As GridColumnDescriptor In dgvCliente.TableDescriptor.Columns
                col.AllowFilter = True
            Next
            filter.AllowResize = True
            filter.AllowFilterByColor = True
            filter.EnableDateFilter = True
            filter.EnableNumberFilter = True

            dgvCliente.OptimizeFilterPerformance = True
            dgvCliente.ShowNavigationBar = True
            Filter.WireGrid(dgvCliente)
        Else
            Filter.ClearFilters(dgvCliente)
            dgvCliente.TopLevelGroupOptions.ShowFilterBar = False
        End If
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Dim f As New frmCrearENtidades
        f.CaptionLabels(0).Text = "Nuevo cliente"
        f.strTipo = TIPO_ENTIDAD.CLIENTE
        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        Cursor = Cursors.WaitCursor
        If Not IsNothing(dgvCliente.Table.CurrentRecord) Then
            If dgvCliente.Table.CurrentRecord.GetValue("razon") <> "CLIENTES VARIOS" Then
                Dim f As New frmCrearENtidades(CInt(dgvCliente.Table.CurrentRecord.GetValue("idEntidad")))
                f.CaptionLabels(0).Text = "Editar cliente"
                f.strTipo = TIPO_ENTIDAD.CLIENTE
                '   f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                f.intIdEntidad = dgvCliente.Table.CurrentRecord.GetValue("idEntidad")
                '   f.UbicarEntidad(dgvCliente.Table.CurrentRecord.GetValue("idEntidad"))
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
            End If
        Else
            MessageBox.Show("Debe seleccionar un cliente!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click
        SumVentaProveedor = 0
        If Not IsNothing(dgvCliente.Table.CurrentRecord) Then
            SumVentaProveedor = documentoVentasSA.UbicarVentaPorClienteXperiodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, Me.dgvCliente.Table.CurrentRecord.GetValue("nroDoc"), PeriodoGeneral).Count
            If (SumVentaProveedor = 0) Then
                ElimnarCliente()
            Else
                PanelError.Visible = True
                Timer1.Enabled = True
                TiempoEjecutar(10)
                lblEstado.Text = "El Cliente tiene movimientos, error al eliminar!"
            End If
        End If
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Cursor = Cursors.WaitCursor
        ListaClientes()
        Cursor = Cursors.Default
    End Sub

    Private Sub dgvCliente_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvCliente.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If
            dgvCliente.TableControl.Selections.Clear()
        End If
    End Sub

    Private Sub dgvCliente_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgvCliente.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgvCliente)
    End Sub
#End Region

End Class