Imports System.ComponentModel
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.Presentation.WinForm
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.GroupingGridExcelConverter
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class frmPendienteAtencionBarra


#Region "Attributes"
    Public Property EstadoManipulacion() As String
    Dim listaAreaOperativas As New List(Of infraestructura)
    Public Alert As Alert
    Public IDInfraestructura As String
    Public IDAreaOperativa As String
    Dim CodigoEncargadoPreparacion As Integer
#End Region

#Region "Constructors"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridPequeño(dgvExistencias, False, 9.0F)
        FormatoGridPequeño(dgPedidoPreparado, False, 9.0F)
        'FormatoGridPequeño(dgAtendido, False, 9.0F)
        GetTableGrid()
        'bgCombos.RunWorkerAsync()

        dgvExistencias.Table.Records.DeleteAll()
        dgPedidoPreparado.Table.Records.DeleteAll()
        'dgAtendido.Table.Records.DeleteAll()
        'CargarAreaXId(IDAreaOperativa)

    End Sub
#End Region

#Region "Metodos"

    Sub GetTableGrid()
        Dim dt As New DataTable()

        dt.Columns.Add("idArea", GetType(Integer))
        dt.Columns.Add("fechaPedido", GetType(String))
        dt.Columns.Add("mesa", GetType(String))
        dt.Columns.Add("descripcion", GetType(String))
        dt.Columns.Add("cantidad", GetType(String))
        dt.Columns.Add("estado", GetType(String))
        dt.Columns.Add("tipoExistencia", GetType(String))
        dt.Columns.Add("estadoPago", GetType(String))
        dt.Columns.Add("codVendedor", GetType(Integer))
        dgvExistencias.DataSource = dt

        Dim dtPreparado As New DataTable()

        dtPreparado.Columns.Add("idArea", GetType(Integer))
        dtPreparado.Columns.Add("fechaPedido", GetType(String))
        dtPreparado.Columns.Add("mesa", GetType(String))
        dtPreparado.Columns.Add("descripcion", GetType(String))
        dtPreparado.Columns.Add("cantidad", GetType(String))
        dtPreparado.Columns.Add("estado", GetType(String))
        dtPreparado.Columns.Add("tipoExistencia", GetType(String))
        dtPreparado.Columns.Add("codVendedor", GetType(Integer))
        dtPreparado.Columns.Add("estadoPago", GetType(String))
        dtPreparado.Columns.Add("codPersonaAtencion", GetType(Integer))
        dgPedidoPreparado.DataSource = dtPreparado

    End Sub

    'Public Sub GetCombos()
    '    Try
    '        Dim infraestructuraSA As New infraestructuraSA
    '        Dim areaOperativaBE As New infraestructura

    '        'areaOperativaBE.idEmpresa = Gempresas.IdEmpresaRuc
    '        'areaOperativaBE.estructura = "AT"
    '        'areaOperativaBE.tipo = "AO"

    '        listaAreaOperativas = New List(Of infraestructura)

    '        listaAreaOperativas = infraestructuraSA.GetListarInfraestructuraXAreaOperativa(areaOperativaBE)

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub

    Sub LoadProductosXalmacenSinAsignar(tipoArea As Integer)
        Dim documentoPedidoDet As New List(Of documentoPedidoDet)
        Dim documentoPedidoDetSA As New documentoPedidoDetSA
        Dim documentoPedidoDetBE As New documentoPedido
        'documentoPedidoDetBE.idEmpresa = Gempresas.IdEmpresaRuc
        'documentoPedidoDetBE.idDocumento = tipoArea
        'documentoPedidoDetBE.estadoEntrega = "PN"

        Dim dt As New DataTable()

        dt.Columns.Add("idArea", GetType(Integer))
        dt.Columns.Add("fechaPedido", GetType(String))
        dt.Columns.Add("mesa", GetType(String))
        dt.Columns.Add("descripcion", GetType(String))
        dt.Columns.Add("cantidad", GetType(String))
        dt.Columns.Add("estado", GetType(String))

        'documentoPedidoDet = documentoPedidoDetSA.GetUbicar_DocXInfraPendienteAtencion(documentoPedidoDetBE)

        For Each i In documentoPedidoDet
            Dim dr As DataRow = dt.NewRow
            'dr(0) = i.secuencia
            dr(1) = CStr(CDate(i.FechaDoc).ToShortTimeString)
            dr(2) = i.nombreMesa
            'dr(3) = i.nombreItem
            'dr(4) = i.monto1
            dr(5) = "PN"
            'dr(6) = "ultimas"

            dt.Rows.Add(dr)
        Next
        dgvExistencias.DataSource = dt
        dgvExistencias.TableOptions.ListBoxSelectionMode = SelectionMode.One
    End Sub

    Sub LoadProductosXPedidoEntregado(tipoArea As Integer)
        Dim documentoPedidoDet As New List(Of documentoPedidoDet)
        Dim documentoPedidoDetSA As New documentoPedidoDetSA
        Dim documentoPedidoDetBE As New documentoPedido
        'documentoPedidoDetBE.idEmpresa = Gempresas.IdEmpresaRuc
        'documentoPedidoDetBE.idDocumento = tipoArea
        'documentoPedidoDetBE.estadoEntrega = "PR"

        Dim dt As New DataTable()

        dt.Columns.Add("idArea", GetType(Integer))
        dt.Columns.Add("fechaPedido", GetType(String))
        dt.Columns.Add("mesa", GetType(String))
        dt.Columns.Add("descripcion", GetType(String))
        dt.Columns.Add("cantidad", GetType(String))
        dt.Columns.Add("estado", GetType(String))

        'documentoPedidoDet = documentoPedidoDetSA.GetUbicar_DocXInfraPendienteAtencion(documentoPedidoDetBE)

        For Each i In documentoPedidoDet
            Dim dr As DataRow = dt.NewRow
            'dr(0) = i.secuencia
            dr(1) = CStr(CDate(i.FechaDoc).ToShortTimeString)
            dr(2) = i.nombreMesa
            'dr(3) = i.nombreItem
            'dr(4) = i.monto1
            dr(5) = "PN"
            'dr(6) = "ultimas"

            dt.Rows.Add(dr)
        Next
        dgPedidoPreparado.DataSource = dt
        dgPedidoPreparado.TableOptions.ListBoxSelectionMode = SelectionMode.One
    End Sub

    'Sub CargarAreaXId(tipoArea As String)
    '    Try
    '        Dim areaOperativaBE As New almacen
    '        Dim areaOperativaSA As New almacenSA
    '        Dim areaOperativaRecuperacion As New almacen

    '        areaOperativaBE.predeterminado = tipoArea
    '        areaOperativaBE.idEmpresa = Gempresas.IdEmpresaRuc
    '        areaOperativaBE.tipo = TipoAlmacen.Deposito

    '        areaOperativaRecuperacion = areaOperativaSA.GetAlmaceneTipobyEmpresa(areaOperativaBE)
    '        If (Not IsNothing(areaOperativaRecuperacion)) Then
    '            IDAreaOperativa = areaOperativaRecuperacion.idAlmacen
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub

    Sub LoadProductosXEstado()
        Try
            Dim documentoPedidoDet As New List(Of documentoPedidoDet)
            Dim documentoPedidoDetSA As New documentoPedidoDetSA
            Dim documentoPedidoDetBE As New documentoPedido
            documentoPedidoDetBE.idEmpresa = Gempresas.IdEmpresaRuc
            documentoPedidoDetBE.predeterminado = IDAreaOperativa
            documentoPedidoDetBE.tipo = "AF"

            documentoPedidoDetBE.ListaTipoExistencia = New List(Of String)
            documentoPedidoDetBE.ListaTipoExistencia.Add(TipoExistencia.Mercaderia)

            documentoPedidoDetBE.ListaEstado = New List(Of String)
            documentoPedidoDetBE.ListaEstado.Add("PN")
            documentoPedidoDetBE.ListaEstado.Add("PR")

            Dim listaPendiente As New List(Of documentoPedidoDet)
            Dim listaPreparado As New List(Of documentoPedidoDet)
            'Dim listaAtendido As New List(Of documentoPedidoDet)

            Dim dtPendiente As New DataTable()
            Dim dtPreparacion As New DataTable()

            dtPendiente.Columns.Add("idArea", GetType(Integer))
            dtPendiente.Columns.Add("fechaPedido", GetType(String))
            dtPendiente.Columns.Add("mesa", GetType(String))
            dtPendiente.Columns.Add("descripcion", GetType(String))
            dtPendiente.Columns.Add("cantidad", GetType(String))
            dtPendiente.Columns.Add("estado", GetType(String))
            dtPendiente.Columns.Add("tipoExistencia", GetType(String))
            dtPendiente.Columns.Add("estadoPago", GetType(String))
            dtPendiente.Columns.Add("codVendedor", GetType(Integer))

            dtPreparacion.Columns.Add("idArea", GetType(Integer))
            dtPreparacion.Columns.Add("fechaPedido", GetType(String))
            dtPreparacion.Columns.Add("mesa", GetType(String))
            dtPreparacion.Columns.Add("descripcion", GetType(String))
            dtPreparacion.Columns.Add("cantidad", GetType(String))
            dtPreparacion.Columns.Add("estado", GetType(String))
            dtPreparacion.Columns.Add("tipoExistencia", GetType(String))
            dtPreparacion.Columns.Add("codVendedor", GetType(Integer))
            dtPreparacion.Columns.Add("estadoPago", GetType(String))
            dtPreparacion.Columns.Add("codPersonaAtencion", GetType(Integer))


            documentoPedidoDet = documentoPedidoDetSA.GetUbicar_DocXInfraXAreaFull(documentoPedidoDetBE)

            For Each i In documentoPedidoDet
                Select Case i.estadoEntrega
                    Case "PN"
                        Dim dr As DataRow = dtPendiente.NewRow
                        dr(0) = i.secuencia
                        dr(1) = CStr(CDate(i.FechaDoc).ToShortTimeString)
                        dr(2) = i.nombreMesa
                        dr(3) = i.nombreItem
                        dr(4) = i.monto1
                        dr(5) = "PN"
                        dr(6) = i.tipoExistencia
                        dr(7) = i.estadoPago
                        dr(8) = 11 'i.usuarioModificacion

                        dtPendiente.Rows.Add(dr)
                    Case "PR"
                        Dim dr As DataRow = dtPreparacion.NewRow
                        dr(0) = i.secuencia
                        dr(1) = CStr(CDate(i.FechaDoc).ToShortTimeString)
                        dr(2) = i.nombreMesa
                        dr(3) = i.nombreItem
                        dr(4) = i.monto1
                        dr(5) = "PR"
                        dr(6) = i.tipoExistencia
                        dr(7) = 11 '  i.usuarioModificacion
                        dr(8) = i.estadoPago
                        'If (Not IsNothing(i.idArea)) Then
                        dr(9) = Nothing
                        'End If
                        dtPreparacion.Rows.Add(dr)

                End Select

            Next
            dgvExistencias.Table.Records.DeleteAll()
            dgvExistencias.DataSource = dtPendiente
            dgvExistencias.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended
            dgPedidoPreparado.Table.Records.DeleteAll()
            dgPedidoPreparado.DataSource = dtPreparacion
            dgPedidoPreparado.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

#End Region

    'Private Sub bgCombos_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgCombos.DoWork
    '    If bgCombos.CancellationPending Then
    '        ' MessageBox.Show("Up to here? ...")
    '        e.Cancel = True
    '    Else
    '        GetCombos()
    '    End If
    'End Sub

    'Private Sub bgCombos_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgCombos.RunWorkerCompleted
    '    If e.Cancelled Then

    '    Else
    '        'Loadcontroles()
    '    End If
    'End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs)
        Try
            Dim documentopedidodetSA As New documentoPedidoDetSA
            Dim documentopedidoBE As New documentoPedidoDet

            If (Not IsNothing(dgvExistencias.Table.CurrentRecord)) Then
                If MessageBox.Show("Desea anular el pedido seleccionado?", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    documentopedidoBE.IdEmpresa = Gempresas.IdEmpresaRuc
                    'documentopedidoBE.estadoEntrega = "AN"
                    'documentopedidoBE.secuencia = dgvExistencias.Table.CurrentRecord.GetValue("idArea")

                    documentopedidodetSA.EditarEstadoPedido(documentopedidoBE)

                End If

            ElseIf (Not IsNothing(dgPedidoPreparado.Table.CurrentRecord)) Then
                If MessageBox.Show("Desea anular el pedido seleccionado?", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    documentopedidoBE.IdEmpresa = Gempresas.IdEmpresaRuc
                    'documentopedidoBE.estadoEntrega = "AN"
                    'documentopedidoBE.secuencia = dgPedidoPreparado.Table.CurrentRecord.GetValue("idArea")

                    documentopedidodetSA.EditarEstadoPedido(documentopedidoBE)

                End If
            Else

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
    '    Try
    '        Dim f As New frmRegistroPedidos(cboAreaOperativa.SelectedValue, "AN")
    '        f.lblEstado.Text = "PEDIDOS ANULADOS"
    '        f.StartPosition = FormStartPosition.CenterScreen
    '        f.Show(Me)
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub

    'Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
    '    Try
    '        Dim f As New frmRegistroPedidos(cboAreaOperativa.SelectedValue, "DC")
    '        f.lblEstado.Text = "PEDIDOS ENTREGADOS"
    '        f.StartPosition = FormStartPosition.CenterScreen
    '        f.Show(Me)
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub

    Private Function GetCodigoVendedor() As Helios.Seguridad.Business.Entity.Usuario
        GetCodigoVendedor = Nothing
        Dim f As New FormCodigoVendedor
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        If f.Tag IsNot Nothing Then
            Dim c = CType(f.Tag, Helios.Seguridad.Business.Entity.Usuario)
            GetCodigoVendedor = c
        End If
    End Function

    Private Sub RoundButton21_Click_1(sender As Object, e As EventArgs)

        'Try
        '    Dim documentopedidodetSA As New documentoPedidoDetSA
        '    Dim documentopedidoBE As New documentoPedidoDet

        '    If (Not IsNothing(dgvExistencias.Table.CurrentRecord)) Then

        '        If (dgvExistencias.Table.CurrentRecord.GetValue("tipoExistencia") = "02") Then
        '            documentopedidoBE.IdEmpresa = Gempresas.IdEmpresaRuc
        '            documentopedidoBE.estadoEntrega = "PR"
        '            documentopedidoBE.secuencia = CInt(dgvExistencias.Table.CurrentRecord.GetValue("idArea"))
        '            documentopedidodetSA.EditarEstadoPedido(documentopedidoBE)

        '            'If (cboAreaOperativa.SelectedValue > 0) Then
        '            '    dgvExistencias.Table.Records.DeleteAll()
        '            '    dgPedidoPreparado.Table.Records.DeleteAll()
        '            '    dgAtendido.Table.Records.DeleteAll()
        '            LoadProductosXEstado()
        '            'End If
        '        ElseIf (dgvExistencias.Table.CurrentRecord.GetValue("tipoExistencia") = "01") Then
        '            documentopedidoBE.IdEmpresa = Gempresas.IdEmpresaRuc
        '            documentopedidoBE.estadoEntrega = "AT"
        '            documentopedidoBE.secuencia = CInt(dgvExistencias.Table.CurrentRecord.GetValue("idArea"))

        '            documentopedidodetSA.EditarEstadoPedido(documentopedidoBE)
        '            LoadProductosXEstado()
        '            'If (cboAreaOperativa.SelectedValue > 0) Then
        '            '    dgvExistencias.Table.Records.DeleteAll()
        '            '    dgPedidoPreparado.Table.Records.DeleteAll()
        '            '    dgAtendido.Table.Records.DeleteAll()
        '            '    LoadProductosXEstado(cboAreaOperativa.SelectedValue)
        '            'End If
        '        ElseIf (dgvExistencias.Table.CurrentRecord.GetValue("tipoExistencia") = "GS") Then
        '            documentopedidoBE.IdEmpresa = Gempresas.IdEmpresaRuc
        '            documentopedidoBE.estadoEntrega = "PR"
        '            documentopedidoBE.secuencia = CInt(dgvExistencias.Table.CurrentRecord.GetValue("idArea"))
        '            documentopedidodetSA.EditarEstadoPedido(documentopedidoBE)
        '            LoadProductosXEstado()
        '            'If (cboAreaOperativa.SelectedValue > 0) Then
        '            '    dgvExistencias.Table.Records.DeleteAll()
        '            '    dgPedidoPreparado.Table.Records.DeleteAll()
        '            '    dgAtendido.Table.Records.DeleteAll()
        '            '    LoadProductosXEstado(cboAreaOperativa.SelectedValue)
        '            'End If
        '        End If
        '    Else
        '        MessageBox.Show("No se puede cambiar de estado, selecciones un pedido!", "Atención")
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try

    End Sub

    Private Sub RoundButton23_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub RoundButton24_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub RoundButton25_Click(sender As Object, e As EventArgs)
        Try
            Dim documentopedidodetSA As New documentoPedidoDetSA
            Dim documentopedidoBE As New documentoPedidoDet

            If (Not IsNothing(dgvExistencias.Table.CurrentRecord)) Then

                documentopedidoBE.IdEmpresa = Gempresas.IdEmpresaRuc
                documentopedidoBE.estadoEntrega = "PR"
                documentopedidoBE.secuencia = dgvExistencias.Table.CurrentRecord.GetValue("idArea")
                documentopedidodetSA.EditarEstadoPedido(documentopedidoBE)

                'If (cboAreaOperativa.SelectedValue > 0) Then
                '    dgvExistencias.Table.Records.DeleteAll()
                '    dgPedidoPreparado.Table.Records.DeleteAll()
                '    dgAtendido.Table.Records.DeleteAll()
                '    LoadProductosXEstado(cboAreaOperativa.SelectedValue)
                'End If
            Else
                MessageBox.Show("No se puede cambiar de estado, selecciones un pedido!", "Atención")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs)
        Try
            'Dim f As New frmRegistroPedidos("AP", IDAreaOperativa, "AT")
            'f.lblEstado.Text = "PEDIDOS ENTREGADOS"
            'f.StartPosition = FormStartPosition.CenterScreen
            'f.Show(Me)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub RoundButton25_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub GradientPanel3_Paint(sender As Object, e As PaintEventArgs)

    End Sub

#Region "ver detalles"
    Dim TipoPedido As String

    Private Sub frmPendienteAtencion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ContextMenuStrip = New ContextMenuStrip()
            ContextMenuStrip.Items.Add("Ver documento detalles...")
            AddHandler ContextMenuStrip.ItemClicked, AddressOf contextMenuStrip_ItemClicked
            AddHandler Me.dgvExistencias.TableControlMouseDown, AddressOf gridGroupingControl1_TableControlMouseDown

            'AddHandler ContextMenuStrip.ItemClicked, AddressOf contextMenuStrip_ItemClicked


            'AddHandler ContextMenuStrip.ItemClicked, AddressOf contextMenuStrip_ItemClicked
            AddHandler Me.dgPedidoPreparado.TableControlMouseDown, AddressOf gridGroupingControl1_TableControlMouseDown
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub contextMenuStrip_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)
        Try

            Me.Cursor = Cursors.WaitCursor

            Select Case TipoPedido
                Case "PN"
                    If Not IsNothing(Me.dgvExistencias.Table.CurrentRecord) Then
                        If e.ClickedItem.Text = "Ver documento detalles..." Then
                            ''   Me.dgvCompra.Table.CurrentRecord.Delete()
                            'Dim a As New frmInfComplementariaPedido()
                            'a.txtFecha.Text = Me.dgvExistencias.Table.CurrentRecord.GetValue("fechaPedido")
                            'a.txtNombreProducto.Text = Me.dgvExistencias.Table.CurrentRecord.GetValue("descripcion")
                            'a.txtCantidad.Text = Me.dgvExistencias.Table.CurrentRecord.GetValue("cantidad")
                            'a.txtInfraestructura.Text = Me.dgvExistencias.Table.CurrentRecord.GetValue("mesa")
                            'Select Case Me.dgvExistencias.Table.CurrentRecord.GetValue("estadoPago")
                            '    Case "PN"
                            '        a.txtEstadoPago.Text = "PENDIENTE"
                            '    Case "DC"
                            '        a.txtEstadoPago.Text = "COBRADO"
                            'End Select
                            'a.txtCodVendedor.Text = Me.dgvExistencias.Table.CurrentRecord.GetValue("codVendedor")

                            'a.StartPosition = FormStartPosition.CenterParent
                            'a.ShowDialog(Me)
                        End If
                    End If
                Case "PR"
                    If Not IsNothing(Me.dgPedidoPreparado.Table.CurrentRecord) Then
                        If e.ClickedItem.Text = "Ver documento detalles..." Then
                            'Dim a As New frmInfComplementariaPedido()
                            'a.txtFecha.Text = Me.dgPedidoPreparado.Table.CurrentRecord.GetValue("fechaPedido")
                            'a.txtNombreProducto.Text = Me.dgPedidoPreparado.Table.CurrentRecord.GetValue("descripcion")
                            'a.txtCantidad.Text = Me.dgPedidoPreparado.Table.CurrentRecord.GetValue("cantidad")
                            'a.txtInfraestructura.Text = Me.dgPedidoPreparado.Table.CurrentRecord.GetValue("mesa")
                            'Select Case Me.dgPedidoPreparado.Table.CurrentRecord.GetValue("estadoPago")
                            '    Case "PN"
                            '        a.txtEstadoPago.Text = "PENDIENTE"
                            '    Case "DC"
                            '        a.txtEstadoPago.Text = "COBRADO"
                            'End Select
                            'a.txtCodVendedor.Text = Me.dgPedidoPreparado.Table.CurrentRecord.GetValue("codVendedor")

                            'a.StartPosition = FormStartPosition.CenterParent
                            'a.ShowDialog(Me)
                        End If
                    End If

            End Select

            Me.Cursor = Cursors.Arrow
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'Private Sub contextMenuStripAtendido_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)
    '    Me.Cursor = Cursors.WaitCursor
    '    If Not IsNothing(Me.dgPedidoPreparado.Table.CurrentRecord) Then
    '        If e.ClickedItem.Text = "Ver documento detalles..." Then
    '            Dim a As New frmInfComplementariaPedido()
    '            a.txtFecha.Text = Me.dgPedidoPreparado.Table.CurrentRecord.GetValue("fechaPedido")
    '            a.txtNombreProducto.Text = Me.dgPedidoPreparado.Table.CurrentRecord.GetValue("descripcion")
    '            a.txtCantidad.Text = Me.dgPedidoPreparado.Table.CurrentRecord.GetValue("cantidad")
    '            a.txtInfraestructura.Text = Me.dgPedidoPreparado.Table.CurrentRecord.GetValue("mesa")
    '            Select Case Me.dgPedidoPreparado.Table.CurrentRecord.GetValue("estadoPago")
    '                Case "PN"
    '                    a.txtEstadoPago.Text = "PENDIENTE"
    '                Case "DC"
    '                    a.txtEstadoPago.Text = "COBRADO"
    '            End Select
    '            a.txtCodVendedor.Text = Me.dgPedidoPreparado.Table.CurrentRecord.GetValue("codVendedor")
    '            a.txtEncargado.Text = Me.dgPedidoPreparado.Table.CurrentRecord.GetValue("codPersonaAtencion")
    '            a.StartPosition = FormStartPosition.CenterParent
    '            a.ShowDialog(Me)
    '        End If
    '    End If
    '    Me.Cursor = Cursors.Arrow
    'End Sub

    'Private Sub contextMenuStripPreparado_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)
    '    Me.Cursor = Cursors.WaitCursor
    '    If Not IsNothing(Me.dgvAtendido.Table.CurrentRecord) Then
    '        If e.ClickedItem.Text = "Ver documento detalles..." Then
    '            Dim a As New frmInfComplementariaPedido()
    '            a.txtFecha.Text = Me.dgvAtendido.Table.CurrentRecord.GetValue("fechaPedido")
    '            a.txtNombreProducto.Text = Me.dgvAtendido.Table.CurrentRecord.GetValue("descripcion")
    '            a.txtCantidad.Text = Me.dgvAtendido.Table.CurrentRecord.GetValue("cantidad")
    '            a.txtInfraestructura.Text = Me.dgvAtendido.Table.CurrentRecord.GetValue("mesa")
    '            Select Case Me.dgvAtendido.Table.CurrentRecord.GetValue("estadoPago")
    '                Case "PN"
    '                    a.txtEstadoPago.Text = "PENDIENTE"
    '                Case "DC"
    '                    a.txtEstadoPago.Text = "COBRADO"
    '            End Select
    '            a.txtCodVendedor.Text = Me.dgvAtendido.Table.CurrentRecord.GetValue("codVendedor")
    '            a.txtEncargado.Text = Me.dgvAtendido.Table.CurrentRecord.GetValue("codPersonaAtencion")
    '            a.StartPosition = FormStartPosition.CenterParent
    '            a.ShowDialog(Me)
    '        End If
    '    End If
    '    Me.Cursor = Cursors.Arrow
    'End Sub

    Private Sub gridGroupingControl1_TableControlMouseDown(sender As Object, e As GridTableControlMouseEventArgs)
        Dim row As Integer = 0, col As Integer = 0
        dgvExistencias.TableControl.PointToRowCol(e.Inner.Location, row, col)
        Dim style As GridTableCellStyleInfo = dgvExistencias.TableControl.GetTableViewStyleInfo(row, col)
        'To check whether it is columnheadercell
        If style IsNot Nothing AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso e.Inner.Button = System.Windows.Forms.MouseButtons.Right Then
            '  gridGroupingControl1.ContextMenuStrip = fieldchooser.ContextMenu
        Else
            'If it is not column header cell
            dgvExistencias.ContextMenuStrip = ContextMenuStrip
            TipoPedido = "PN"
        End If

        dgPedidoPreparado.TableControl.PointToRowCol(e.Inner.Location, row, col)
        Dim style2 As GridTableCellStyleInfo = dgPedidoPreparado.TableControl.GetTableViewStyleInfo(row, col)
        'To check whether it is columnheadercell
        If style2 IsNot Nothing AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso e.Inner.Button = System.Windows.Forms.MouseButtons.Right Then
            '  gridGroupingControl1.ContextMenuStrip = fieldchooser.ContextMenu
        Else
            'If it is not column header cell
            dgPedidoPreparado.ContextMenuStrip = ContextMenuStrip
            TipoPedido = "PR"
        End If

    End Sub

    Private Sub dgvExistencias_MouseClick(sender As Object, e As MouseEventArgs)
        TipoPedido = "PN"
    End Sub

    Private Sub dgPedidoPreparado_MouseClick(sender As Object, e As MouseEventArgs)
        TipoPedido = "PR"
    End Sub

    Private Sub GridGroupingControl2_MouseClick(sender As Object, e As MouseEventArgs)
        TipoPedido = "AT"
    End Sub

    Private Sub GridGroupingControl1_MouseClick(sender As Object, e As MouseEventArgs) Handles dgPedidoPreparado.MouseClick
        TipoPedido = "PR"
    End Sub

    Private Sub dgvTransito_MouseClick(sender As Object, e As MouseEventArgs) Handles dgvExistencias.MouseClick
        TipoPedido = "PN"
    End Sub

    Private Sub BunifuFlatButton17_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton17.Click
        Try
            'Dim f As New frmRegistroPedidos("AP", IDAreaOperativa, "AT")
            'f.lblEstado.Text = "PEDIDOS ENTREGADOS"
            'f.StartPosition = FormStartPosition.CenterScreen
            'f.Show(Me)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Try
            Dim documentopedidodetSA As New documentoPedidoDetSA
            Dim documentopedidoBE As New documentoPedidoDet
            Dim listaDocumentopedido As New List(Of documentoPedidoDet)

            Dim Vendedor = GetCodigoVendedor()
            If Vendedor IsNot Nothing Then

                dgvExistencias.TableControl.CurrentCell.EndEdit()
                dgvExistencias.TableControl.Table.TableDirty = True
                dgvExistencias.TableControl.Table.EndEdit()

                listaDocumentopedido = New List(Of documentoPedidoDet)

                For Each ITEMS In dgvExistencias.Table.SelectedRecords
                    documentopedidoBE = New documentoPedidoDet
                    documentopedidoBE.IdEmpresa = Gempresas.IdEmpresaRuc
                    documentopedidoBE.estadoEntrega = "PR"
                    documentopedidoBE.secuencia = ITEMS.Record.GetValue("idArea")
                    'documentopedidoBE.idArea = Vendedor.IDUsuario
                    documentopedidoBE.FechaDoc = Date.Now

                    CodigoEncargadoPreparacion = Vendedor.IDUsuario

                    'documentopedidoBE.informacionComplementariaBE = New informacionComplementaria
                    'documentopedidoBE.informacionComplementariaBE.idEmpresa = Gempresas.IdEmpresaRuc
                    'documentopedidoBE.informacionComplementariaBE.idEstablecimiento = GEstableciento.IdEstablecimiento
                    'documentopedidoBE.informacionComplementariaBE.tipo = "PREPARADO"
                    'documentopedidoBE.informacionComplementariaBE.descripcion = "MOVIMIENTO DEL PRODUCTO POR ESTADO CON FECHA " & Date.Now
                    'documentopedidoBE.informacionComplementariaBE.fechaInformacion = Date.Now
                    'documentopedidoBE.informacionComplementariaBE.estado = "PR"
                    'documentopedidoBE.informacionComplementariaBE.usuarioActualizacion = Vendedor.IDUsuario
                    'documentopedidoBE.informacionComplementariaBE.fechaActualizacion = Date.Now

                    listaDocumentopedido.Add(documentopedidoBE)

                Next

                documentopedidodetSA.EditarEstadoPedidoMasivo(listaDocumentopedido)

                LoadProductosXEstado()


            Else
                MessageBox.Show("Debe un código de vendedor!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton4_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Try
            Dim documentopedidodetSA As New documentoPedidoDetSA
            Dim documentopedidoBE As New documentoPedidoDet
            Dim listaDocumentopedido As New List(Of documentoPedidoDet)

            Dim Vendedor = GetCodigoVendedor()
            If Vendedor IsNot Nothing Then

                dgPedidoPreparado.TableControl.CurrentCell.EndEdit()
                dgPedidoPreparado.TableControl.Table.TableDirty = True
                dgPedidoPreparado.TableControl.Table.EndEdit()

                listaDocumentopedido = New List(Of documentoPedidoDet)

                For Each ITEMS In dgPedidoPreparado.Table.SelectedRecords
                    documentopedidoBE = New documentoPedidoDet
                    documentopedidoBE.IdEmpresa = Gempresas.IdEmpresaRuc
                    documentopedidoBE.estadoEntrega = "PN"
                    documentopedidoBE.secuencia = ITEMS.Record.GetValue("idArea")
                    'documentopedidoBE.idArea = Vendedor.IDUsuario
                    documentopedidoBE.FechaDoc = Date.Now

                    CodigoEncargadoPreparacion = Vendedor.IDUsuario

                    documentopedidoBE.informacionComplementariaBE = New informacionComplementaria
                    documentopedidoBE.informacionComplementariaBE.idEmpresa = Gempresas.IdEmpresaRuc
                    documentopedidoBE.informacionComplementariaBE.idEstablecimiento = GEstableciento.IdEstablecimiento
                    documentopedidoBE.informacionComplementariaBE.tipo = "PEDIDO"
                    documentopedidoBE.informacionComplementariaBE.descripcion = "MOVIMIENTO DEL PRODUCTO POR ESTADO CON FECHA " & Date.Now
                    documentopedidoBE.informacionComplementariaBE.fechaInformacion = Date.Now
                    documentopedidoBE.informacionComplementariaBE.estado = "PN"
                    documentopedidoBE.informacionComplementariaBE.usuarioActualizacion = Vendedor.IDUsuario
                    documentopedidoBE.informacionComplementariaBE.fechaActualizacion = Date.Now
                    listaDocumentopedido.Add(documentopedidoBE)
                Next

                'documentopedidodetSA.EditarEstadoPedidoMasivo(listaDocumentopedido)
                LoadProductosXEstado()

            Else
                MessageBox.Show("Debe un código de vendedor!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        Try
            Dim documentopedidodetSA As New documentoPedidoDetSA
            Dim documentopedidoBE As New documentoPedidoDet
            Dim listaDocumentopedido As New List(Of documentoPedidoDet)

            Dim Vendedor = GetCodigoVendedor()
            If Vendedor IsNot Nothing Then

                dgPedidoPreparado.TableControl.CurrentCell.EndEdit()
                dgPedidoPreparado.TableControl.Table.TableDirty = True
                dgPedidoPreparado.TableControl.Table.EndEdit()

                listaDocumentopedido = New List(Of documentoPedidoDet)

                For Each ITEMS In dgPedidoPreparado.Table.SelectedRecords
                    documentopedidoBE = New documentoPedidoDet
                    documentopedidoBE.IdEmpresa = Gempresas.IdEmpresaRuc
                    documentopedidoBE.estadoEntrega = "AT"
                    'documentopedidoBE.idArea = ITEMS.Record.GetValue("codPersonaAtencion")
                    documentopedidoBE.secuencia = ITEMS.Record.GetValue("idArea")

                    documentopedidoBE.FechaDoc = Date.Now

                    documentopedidoBE.informacionComplementariaBE = New informacionComplementaria
                    documentopedidoBE.informacionComplementariaBE.idEmpresa = Gempresas.IdEmpresaRuc
                    documentopedidoBE.informacionComplementariaBE.idEstablecimiento = GEstableciento.IdEstablecimiento
                    documentopedidoBE.informacionComplementariaBE.tipo = "ATENDIDO"
                    documentopedidoBE.informacionComplementariaBE.descripcion = "MOVIMIENTO DEL PRODUCTO POR ESTADO CON FECHA " & Date.Now
                    documentopedidoBE.informacionComplementariaBE.fechaInformacion = Date.Now
                    documentopedidoBE.informacionComplementariaBE.estado = "AT"
                    documentopedidoBE.informacionComplementariaBE.usuarioActualizacion = ITEMS.Record.GetValue("codPersonaAtencion")
                    documentopedidoBE.informacionComplementariaBE.fechaActualizacion = Date.Now

                    listaDocumentopedido.Add(documentopedidoBE)

                Next

                documentopedidodetSA.EditarEstadoPedidoMasivo(listaDocumentopedido)
                LoadProductosXEstado()

            Else
                MessageBox.Show("Debe un código de vendedor!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
        LoadProductosXEstado()
    End Sub

#End Region

End Class