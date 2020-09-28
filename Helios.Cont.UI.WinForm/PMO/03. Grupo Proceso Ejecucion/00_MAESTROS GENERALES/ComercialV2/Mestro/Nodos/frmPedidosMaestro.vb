Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General.Constantes
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class frmPedidosMaestro
#Region "Attributes"
    Dim selectionColl As New Hashtable()
    Dim hoveredIndex As Integer = 0
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGrid(dgPedidos)
        Meses()
        txtAnioCompra.Text = AnioGeneral
        GetListaNotasPedido()
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

    Public Sub EliminarPV(intIdDocumento As Integer)
        Dim documentoSA As New DocumentoSA
        Dim objDocumento As New documento
        Try
            With objDocumento
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idCentroCosto = GEstableciento.IdEstablecimiento
                .idDocumento = intIdDocumento
            End With

            documentoSA.EliminarVentaGeneralPV(objDocumento)
            Me.dgPedidos.Table.CurrentRecord.Delete()

        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub

    Private Sub IsMouseHover(row As Integer, col As Integer, isHover As Boolean, GGC As GridGroupingControl)
        Dim color As New GridMetroColors()
        Dim id As GridTableCellStyleInfoIdentity = GGC.TableControl.GetTableViewStyleInfo(row, col).TableCellIdentity
        If id.DisplayElement.IsRecord() Then
            Dim key As Integer = id.DisplayElement.GetRecord().Id
            'if (selectionColl.Contains(key))
            '    selectionColl[key] = isHover;
            'else
            hoveredIndex = row
            selectionColl.Clear()
            'if (selectionColl.Count == 0)
            '    selectionColl.Add(key, isHover);
            GGC.TableControl.Refresh()
        End If

        GGC.TableControl.Selections.Clear()

    End Sub

    Private Sub GetListaNotasPedido()
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim dt As New DataTable("Pedidos-")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("pedido", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("importeTotal", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeUS", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("usuarioActualizacion", GetType(String)))

        'lower case p
        dt.Columns.Add(New DataColumn("estado", GetType(String)))

        Dim str As String

        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarAllNotasPedido(GEstableciento.IdEstablecimiento, cboMesPedido.SelectedValue & "/" & AnioGeneral)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoVenta
            dr(2) = str

            dr(4) = i.tipoDocumento
            dr(5) = i.serie
            Select Case i.tipoVenta
                Case TIPO_VENTA.VENTA_AL_TICKET, TIPO_VENTA.VENTA_NOTA_PEDIDO
                    'dr(3) = i.nombrePedido
                    dr(6) = i.numeroDoc
                Case TIPO_VENTA.VENTA_GENERAL
                    'dr(3) = "-"
                    dr(6) = i.numeroDocNormal
            End Select

            Select Case i.NroDocEntidad
                Case Is = Nothing
                    dr(3) = i.nombrePedido
                    dr(7) = "-"
                    dr(8) = i.nombrePedido
                Case Else
                    dr(3) = i.NombreEntidad
                    dr(7) = i.NroDocEntidad
                    dr(8) = i.NombreEntidad
            End Select
            dr(9) = i.ImporteNacional
            dr(10) = i.tipoCambio
            dr(11) = i.ImporteExtranjero
            dr(12) = i.moneda
            dr(13) = i.usuarioActualizacion
            dr(14) = i.estadoCobro
            dt.Rows.Add(dr)
        Next
        dgPedidos.DataSource = dt

    End Sub

    Private Sub Meses()
        Dim listaMeses As New List(Of MesesAnio)
        Dim obj As New MesesAnio

        For x = 1 To 12
            obj = New MesesAnio
            obj.Codigo = String.Format("{0:00}", CInt(x))
            obj.Mes = New DateTime(AnioGeneral, x, 1).ToString("MMMM")
            listaMeses.Add(obj)
        Next x

        cboMesPedido.DisplayMember = "Mes"
        cboMesPedido.ValueMember = "Codigo"
        cboMesPedido.DataSource = listaMeses
        cboMesPedido.SelectedValue = MesGeneral
    End Sub
#End Region

#Region "Events"
    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        If cboMesPedido.Text.Trim.Length > 0 Then
            Dim f As New frmVentaPV
            f.lblPerido.Text = cboMesPedido.SelectedValue & "/" & AnioGeneral
            f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
            f.StartPosition = FormStartPosition.CenterParent
            f.WindowState = FormWindowState.Maximized
            f.ShowDialog()
            GetListaNotasPedido()
        Else
            MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboMesPedido.Select()
            cboMesPedido.DroppedDown = True
        End If

    End Sub

    Private Sub ButtonAdv19_Click(sender As Object, e As EventArgs) Handles ButtonAdv19.Click
        Cursor = Cursors.WaitCursor
        GetListaNotasPedido()
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        Dim f As New frmVentaPV(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento"))
        f.StartPosition = FormStartPosition.CenterParent
        f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
        f.ShowDialog()
    End Sub

    Private Sub dgPedidos_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgPedidos.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            dgPedidos.TableControl.Selections.Clear()
        End If
    End Sub

    Private Sub dgPedidos_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgPedidos.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgPedidos)
    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click
        Cursor = Cursors.WaitCursor
        If Not IsNothing(Me.dgPedidos.Table.CurrentRecord) Then
            If MessageBox.Show("Desea Elimiar el item seleccionado?", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                EliminarPV(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento"))
            End If
        Else
            MessageBox.Show("Debe seleccionar un item válido!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Arrow
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        PanelError.Visible = False
        Timer1.Enabled = False
    End Sub

#End Region

End Class