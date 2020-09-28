Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General.Constantes
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class TabLG_RegistroNotasCompra

#Region "Attributes"
    Dim CompraSA As New DocumentoCompraSA
    Dim selectionColl As New Hashtable()
    Dim hoveredIndex As Integer = 0
    Dim filter As New GridExcelFilter()
    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
    Public Property fso As New FeedbackForm
    Dim Alert As Alert
#End Region

#Region "Constructors"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormatoGridAvanzado(dgvCompras, True, False)
        GradientPanel11.Visible = True
        GetCombos()
    End Sub
#End Region

#Region "Methods"
    Sub ElimnarDoc()
        If Not IsNothing(Me.dgvCompras.Table.CurrentRecord) Then
            CompraSA.AnularNotaDeCompra(New documento With
                                  {
                                  .idDocumento = Integer.Parse(dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))
                                  })
            Alert = New Alert("Nota de compra anulada", alertType.info)
            Alert.TopMost = True
            Alert.Show()
            dgvCompras.Table.CurrentRecord.Delete()
            dgvCompras.Refresh()
        End If
    End Sub

    Private Sub GetCombos()
        Dim anioSA As New empresaPeriodoSA

        cboMesCompra.DataSource = ListaDeMeses()
        cboMesCompra.DisplayMember = "Mes"
        cboMesCompra.ValueMember = "Codigo"
        cboMesCompra.SelectedValue = String.Format("{0:00}", DateTime.Now.Month)

        cboAnio.DataSource = anioSA.GetListar_empresaPeriodo(New empresaPeriodo With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento})
        cboAnio.DisplayMember = "periodo"
        cboAnio.ValueMember = "periodo"
        cboAnio.Text = DateTime.Now.Year.ToString
    End Sub

    Private Sub GetModalWait()
        fso = New FeedbackForm
        fso.StartPosition = FormStartPosition.CenterScreen
        fso.TopMost = True
        fso.Show()
        Me.ResumeLayout(True)
        fso.Refresh()
    End Sub

    Private Sub GetNotasDeComprasXPeriodo(intIdEstablecimiento As Integer, strPeriodo As String)
        Dim DocumentoCompra As New List(Of documentocompra)

        Dim dt As New DataTable("Período: " & strPeriodo & " ")
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))

        dt.Columns.Add(New DataColumn("tipoDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("TipoPersona ", GetType(String)))

        dt.Columns.Add(New DataColumn("importeTotal"))
        dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeUS"))

        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("usuarioActualizacion", GetType(String)))
        dt.Columns.Add(New DataColumn("situacion", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("Aprobado", GetType(String)))
        dt.Columns.Add(New DataColumn("ant", GetType(Integer)))
        dt.Columns.Add("detraccion")

        DocumentoCompra = CompraSA.GetNotasDeComprasPorPeriodo(New Business.Entity.documentocompra With
                                                                   {
                                                                   .idCentroCosto = intIdEstablecimiento,
                                                                   .fechaContable = strPeriodo}).Where(
                                                                   Function(o) o.tipoCompra <> TIPO_COMPRA.NOTA_COMPRA_ANULADA).ToList
        'Dim dr As DataRow = dt.NewRow()
        Dim str As String
        For Each i As documentocompra In DocumentoCompra
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM HH:mm tt ")
            dt.Rows.Add(
                i.idDocumento,
                i.tipoCompra,
                str,
                i.tipoDoc,
                i.serie,
                i.numeroDoc,
                i.tipoDocEntidad,
                i.NroDocEntidad,
                i.NombreEntidad,
                i.TipoPersona,
                CDec(i.importeTotal).ToString("N2"),
                i.tcDolLoc,
                i.importeUS,
                i.monedaDoc,
                i.usuarioActualizacion,
                i.situacion,
                If(i.estadoPago = TIPO_COMPRA.PAGO.PAGADO, "Saladado", "Pendiente"),
                If(i.aprobado = "S", "Aprobado", "Pendiente"),
                i.Atraso,
                If(i.tieneDetraccion = "S", "Si", "No"))
        Next
        setDatasource(dt)
    End Sub

    Private Sub GetNotasDeComprasdia(intIdEstablecimiento As Integer, strPeriodo As String)
        Dim DocumentoCompra As New List(Of documentocompra)

        Dim dt As New DataTable("Notas de compras del día")
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))

        dt.Columns.Add(New DataColumn("tipoDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("TipoPersona ", GetType(String)))

        dt.Columns.Add(New DataColumn("importeTotal"))
        dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeUS"))

        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("usuarioActualizacion", GetType(String)))
        dt.Columns.Add(New DataColumn("situacion", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("Aprobado", GetType(String)))
        dt.Columns.Add(New DataColumn("ant", GetType(Integer)))
        dt.Columns.Add("detraccion")

        DocumentoCompra = CompraSA.GetNotasDeComprasPorPeriodo(New Business.Entity.documentocompra With
                                                                   {
                                                                   .idCentroCosto = intIdEstablecimiento,
                                                                   .fechaContable = strPeriodo}).Where(
                                                                   Function(o) o.tipoCompra <> TIPO_COMPRA.NOTA_COMPRA_ANULADA And
                                                                   o.fechaDoc.Value.Year = DateTime.Now.Date.Year And
                                                                   o.fechaDoc.Value.Month = DateTime.Now.Date.Month And
                                                                   o.fechaDoc.Value.Day = DateTime.Now.Date.Day).ToList

        Dim str As String
        For Each i As documentocompra In DocumentoCompra
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM HH:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoCompra
            dr(2) = str
            dr(3) = i.tipoDoc
            dr(4) = i.serie
            dr(5) = i.numeroDoc
            dr(6) = i.tipoDocEntidad
            dr(7) = i.NroDocEntidad
            dr(8) = i.NombreEntidad
            dr(9) = i.TipoPersona

            If i.tipoCompra = "BOFR" Then
                dr(10) = CDec(0.0)
                dr(11) = CDec(0.0)
                dr(12) = CDec(0.0)
            Else
                dr(10) = CDec(i.importeTotal).ToString("N2")
                dr(11) = i.tcDolLoc
                dr(12) = i.importeUS
            End If



            'dr(11) = i.tcDolLoc
            'dr(12) = i.importeUS
            dr(13) = i.monedaDoc
            dr(14) = i.usuarioActualizacion
            dr(15) = i.situacion
            Select Case i.estadoPago
                Case TIPO_COMPRA.PAGO.PAGADO
                    dr(16) = "Saldado"
                Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                    dr(16) = "Pendiente"
            End Select

            Select Case i.aprobado
                Case "S"
                    dr(17) = "Aprobado"
                Case Else
                    dr(17) = "Pendiente"
            End Select
            dr(18) = i.Atraso
            dr(19) = If(i.tieneDetraccion = "S", "Si", "No")
            dt.Rows.Add(dr)
        Next
        setDatasource(dt)
    End Sub

    Public Sub setDatasource(ByVal table As DataTable)
        If Me.InvokeRequired Then
            Dim deleg As New SetDataSourceDelegate(AddressOf setDatasource)
            Invoke(deleg, New Object() {table})
        Else
            dgvCompras.DataSource = table
            dgvCompras.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended
            dgvCompras.TopLevelGroupOptions.ShowCaption = True
            ProgressBar1.Visible = False
        End If
    End Sub

#End Region

#Region "Events"
    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        ProgressBar1.Visible = True
        ProgressBar1.Style = ProgressBarStyle.Marquee
        Dim periodoSel = GetPeriodo(New Date(cboAnio.Text, cboMesCompra.SelectedValue, 1), True)
        Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetNotasDeComprasXPeriodo(GEstableciento.IdEstablecimiento, periodoSel)))
        thread.Start()
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        ProgressBar1.Visible = True
        ProgressBar1.Style = ProgressBarStyle.Marquee
        Dim periodoSel = GetPeriodo(New Date(cboAnio.Text, cboMesCompra.SelectedValue, 1), True)
        Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetNotasDeComprasdia(GEstableciento.IdEstablecimiento, periodoSel)))
        thread.Start()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        If dgvCompras.Table.Records.Count > 0 Then
            If Not IsNothing(dgvCompras.Table.CurrentRecord) Then
                GetModalWait()

                Dim f As New FormNotaDeCompra(Integer.Parse(dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))) 'frmEditcompra
                f.WindowState = FormWindowState.Normal
                f.StartPosition = FormStartPosition.CenterParent
                fso.Dispose()
                f.ShowDialog()
            Else
                MessageBox.Show("Debe seleccionar un item!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        If ToolStripButton3.Tag = "Inactivo" Then
            dgvCompras.TopLevelGroupOptions.ShowFilterBar = True
            dgvCompras.NestedTableGroupOptions.ShowFilterBar = True
            dgvCompras.ChildGroupOptions.ShowFilterBar = True
            For Each col As GridColumnDescriptor In dgvCompras.TableDescriptor.Columns
                col.AllowFilter = True
            Next
            filter.AllowResize = True
            filter.AllowFilterByColor = True
            filter.EnableDateFilter = True
            filter.EnableNumberFilter = True

            dgvCompras.OptimizeFilterPerformance = True
            dgvCompras.ShowNavigationBar = True
            filter.WireGrid(dgvCompras)
            ToolStripButton3.Tag = "activo"
        Else
            ToolStripButton3.Tag = "Inactivo"
            filter.ClearFilters(dgvCompras)
            dgvCompras.TopLevelGroupOptions.ShowFilterBar = False
        End If
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Try
            If dgvCompras.Table.Records.Count > 0 Then
                If Not IsNothing(dgvCompras.Table.CurrentRecord) Then
                    If MessageBox.Show("Desea eliminar el registro seleccionada!", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        ElimnarDoc()
                    End If
                End If
            End If
        Catch ex As Exception
            If ex.Message = "ETEA" Then
                '        Alert = New Alert("Tiene produtos relacionados a otros almacenes", alertType.Errors)
                MsgBox("Tiene productos relacionados a otros almacenes", MsgBoxStyle.Critical, "Verificar documentos")
            Else
                Alert = New Alert(ex.Message, alertType.Errors)
                Alert.TopMost = True
                Alert.Show()
            End If

        End Try
    End Sub
#End Region

End Class
