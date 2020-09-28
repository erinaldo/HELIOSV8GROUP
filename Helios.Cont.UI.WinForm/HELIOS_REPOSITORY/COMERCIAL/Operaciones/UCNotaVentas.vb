Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Grouping

Public Class UCNotaVentas
#Region "Attributes"
    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(dgPedidos, True, False, 9.0F)
        OrdenamientoGrid(dgPedidos, True)
    End Sub
#End Region

#Region "Methods"
    Public Sub setDatasource(ByVal table As DataTable)
        If Me.InvokeRequired Then
            Dim deleg As New SetDataSourceDelegate(AddressOf setDatasource)
            Invoke(deleg, New Object() {table})
        Else
            dgPedidos.DataSource = table
            PictureLoad.Visible = False
            BunifuFlatButton5.Enabled = True
        End If
    End Sub

    Private Sub GetListaVentasPorPeriodo(estable As Integer, period As String)
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim dt As New DataTable("Nota de venta - " & period)
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
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("estadoPreparado", GetType(String)))
        dt.Columns.Add(New DataColumn("idPadre", GetType(Integer)))
        dt.Columns.Add(New DataColumn("sustentado", GetType(String)))

        Dim str As String
        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarNotaDeVentasPeriodo(estable, period)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = "NOTA DE VENTA"
            dr(2) = str

            dr(4) = i.tipoDocumento
            dr(5) = i.serieVenta
            dr(6) = i.numeroVenta
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
            dr(9) = FormatNumber(i.ImporteNacional, 2)
            dr(10) = i.tipoCambio
            dr(11) = FormatNumber(i.ImporteExtranjero, 2)
            dr(12) = i.moneda
            dr(13) = i.usuarioActualizacion
            Select Case i.estadoCobro
                Case "DC"
                    dr(14) = "Cobrado"
                Case "ANU"
                    dr(14) = "Anulado"
                Case TIPO_VENTA.AnuladaPorNotaCredito
                    dr(14) = "Anulado x NC."
                Case Else
                    dr(14) = "Pendiente"
            End Select
            Select Case i.notaCredito
                Case StatusVentaMatizados.PorPreparar
                    dr(15) = "Pendiente"
                Case StatusVentaMatizados.TerminadaYentregada
                    dr(15) = "Entregada"
            End Select
            If i.tipoVenta = "NTC" Then
                dr(16) = i.idPadre
            End If
            dr(17) = If(i.estado = StatusNotaDeVentas.Sustentado, "Sustentado", "No Sustentado")
            dt.Rows.Add(dr)
        Next
        setDatasource(dt)
    End Sub

    Private Sub GetListaVentasPorDia(estable As Integer, fecha As Date)
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim dt As New DataTable("Notas del día - " & fecha)
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
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("estadoPreparado", GetType(String)))
        dt.Columns.Add(New DataColumn("idPadre", GetType(Integer)))
        dt.Columns.Add(New DataColumn("sustentado", GetType(String)))

        Dim str As String
        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarNotaDeVentasDia(New documentoventaAbarrotes With {.idEstablecimiento = estable, .fechaDoc = fecha})
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = "NOTA DE VENTA"
            dr(2) = str

            dr(4) = i.tipoDocumento
            dr(5) = i.serieVenta
            dr(6) = i.numeroVenta
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
            dr(9) = FormatNumber(i.ImporteNacional, 2)
            dr(10) = i.tipoCambio
            dr(11) = FormatNumber(i.ImporteExtranjero, 2)
            dr(12) = i.moneda
            dr(13) = i.usuarioActualizacion
            Select Case i.estadoCobro
                Case "DC"
                    dr(14) = "Cobrado"
                Case "ANU"
                    dr(14) = "Anulado"
                Case TIPO_VENTA.AnuladaPorNotaCredito
                    dr(14) = "Anulado x NC."
                Case Else
                    dr(14) = "Pendiente"
            End Select
            Select Case i.notaCredito
                Case StatusVentaMatizados.PorPreparar
                    dr(15) = "Pendiente"
                Case StatusVentaMatizados.TerminadaYentregada
                    dr(15) = "Entregada"
            End Select
            If i.tipoVenta = "NTC" Then
                dr(16) = i.idPadre
            End If
            dr(17) = If(i.estado = StatusNotaDeVentas.Sustentado, "Sustentado", "No Sustentado")
            dt.Rows.Add(dr)
        Next
        setDatasource(dt)
    End Sub

    Public Sub EliminarPV(intIdDocumento As Integer)
        Dim documentoSA As New documentoVentaAbarrotesSA
        Dim objDocumento As New documento
        Try
            With objDocumento
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idCentroCosto = GEstableciento.IdEstablecimiento
                .idDocumento = intIdDocumento
            End With

            documentoSA.AnularNotaVenta(objDocumento)
            'documentoSA.EliminarVentaGeneralPV(objDocumento)
            dgPedidos.Table.CurrentRecord.Delete()
            dgPedidos.Refresh()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region

#Region "Events"
    Private Sub BunifuFlatButton5_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton5.Click
        Dim f As New FormFiltroAvanzadoPeriodo()
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        If f.Tag IsNot Nothing Then
            Dim periodoSel = CType(f.Tag, DateTime?)
            PictureLoad.Visible = True
            BunifuFlatButton5.Enabled = False
            Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetListaVentasPorPeriodo(GEstableciento.IdEstablecimiento, GetPeriodo(periodoSel, True))))
            thread.Start()
        End If
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        Cursor = Cursors.WaitCursor
        If Not IsNothing(Me.dgPedidos.Table.CurrentRecord) Then
            If MessageBox.Show("Desea Eliminar el item seleccionado?", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                EliminarPV(Val(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento")))
            End If
        Else
            MessageBox.Show("Debe seleccionar un item válido!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
        PictureLoad.Visible = True
        Dim r As Record = Me.dgPedidos.Table.CurrentRecord
        If r IsNot Nothing Then
            Dim f As New FormVentaNueva(Integer.Parse(r.GetValue("idDocumento")))
            f.ToolStrip1.Enabled = False
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
        End If
        PictureLoad.Visible = False
    End Sub

    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton3.Click
        Dim f As New FormFiltroAvanzadoDia()
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        If f.Tag IsNot Nothing Then
            Dim FechaSel = CType(f.Tag, DateTime?)
            PictureLoad.Visible = True
            BunifuFlatButton5.Enabled = False
            Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetListaVentasPorDia(GEstableciento.IdEstablecimiento, FechaSel)))
            thread.Start()
        End If
    End Sub

    Private Sub BunifuFlatButton6_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton6.Click
        Cursor = Cursors.WaitCursor
        Dim r As Record = dgPedidos.Table.CurrentRecord
        If r IsNot Nothing Then
            Dim f As New FormImpresionEquivalencia(Integer.Parse(r.GetValue("idDocumento"))) 'FormImpresionNuevo(Integer.Parse(r.GetValue("idDocumento")))
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
        Else
            MessageBox.Show("Debe seleccionar un documento válido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BunifuFlatButton7_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton7.Click

        PictureLoad.Visible = True
        Dim r As Record = Me.dgPedidos.Table.CurrentRecord
        If r IsNot Nothing Then
            Dim f As New FormEmitirGuiaRemision(Integer.Parse(r.GetValue("idDocumento")))
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
        Else
            MessageBox.Show("NO selecciono nada")
        End If
        PictureLoad.Visible = False
    End Sub

    Private Sub BunifuFlatButton9_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton9.Click
        PictureLoad.Visible = True
        Dim r As Record = Me.dgPedidos.Table.CurrentRecord
        If r IsNot Nothing Then
            Dim ventaSA As New documentoVentaAbarrotesSA
            Dim venta = ventaSA.GetVentaID(New documento() With {.idDocumento = Integer.Parse(r.GetValue("idDocumento").ToString)})
            If venta IsNot Nothing Then
                Dim ucHistorial As New ucHistorialGuiaDoc(venta)
                ucHistorial.StartPosition = FormStartPosition.CenterParent
                ucHistorial.ShowDialog(Me)
            End If
        End If
        PictureLoad.Visible = False
    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click

    End Sub
#End Region
End Class
