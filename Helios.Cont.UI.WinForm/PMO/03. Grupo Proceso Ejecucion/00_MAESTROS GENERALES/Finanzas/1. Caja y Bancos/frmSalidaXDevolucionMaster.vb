Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General.Constantes
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping
Public Class frmSalidaXDevolucionMaster

#Region "Attributes"
    Dim listaMeses As New List(Of MesesAnio)
    Public Property empresaPeriodoSA As New empresaCierreMensualSA
    Dim parentTable As New DataTable
    Dim childTable As New DataTable

    Dim parentToChildRelationDescriptor As New GridRelationDescriptor()
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridPequeño(GridGroupingControl2, True)
        Meses()
    End Sub
#End Region

#Region "Methods"
    Private Sub Meses()
        Dim empresaAnioSA As New empresaPeriodoSA
        listaMeses = New List(Of MesesAnio)
        Dim obj As New MesesAnio
        For x = 1 To 12
            obj = New MesesAnio
            obj.Codigo = String.Format("{0:00}", CInt(x))
            obj.Mes = New DateTime(AnioGeneral, x, 1).ToString("MMMM")
            listaMeses.Add(obj)
        Next x

        cboAnio.DisplayMember = "periodo"
        cboAnio.ValueMember = "periodo"
        cboAnio.DataSource = empresaAnioSA.GetListar_empresaPeriodo(New empresaPeriodo With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento})
        cboAnio.Text = AnioGeneral

        cboMesCompra.DisplayMember = "Mes"
        cboMesCompra.ValueMember = "Codigo"
        cboMesCompra.DataSource = listaMeses
        cboMesCompra.SelectedValue = MesGeneral
    End Sub

    Private Function GetMovimientosPeriodo(intIdEstablecimiento As Integer, strPeriodo As String, strMovimiento As String) As DataTable
        Dim DocumentoCompraSA As New DocumentoCompraSA
        Dim listaDocCaja As List(Of documentoCaja)
        Dim listaEstado As New List(Of String)
        Dim listaTransac As New List(Of String)
        Dim listaMov As New List(Of String)

        Dim dt As New DataTable("ParentTable")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("movimiento", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("tipoDocPago", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaCobro", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroOperacion", GetType(String)))
        dt.Columns.Add(New DataColumn("moneda", GetType(String)))
        dt.Columns.Add(New DataColumn("montoSoles"))
        dt.Columns.Add(New DataColumn("movimientoMN", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("saldoMN", GetType(Decimal)))

        Dim str As String

        listaEstado.Add(TIPO_ESTADO_cAJA.USADO_PARCIAL)
        listaEstado.Add(TIPO_ESTADO_cAJA.USADO_TOTAL)


        listaMov.Add(MovimientoCaja.Otras_Entradas)
        listaMov.Add(MovimientoCaja.Anticipos_recibidos)
        listaMov.Add(MovimientoCaja.Aportes)

        listaTransac.Add(MovimientoCaja.Devolucion)
        'listaTransac.Add(MovimientoCaja.Compensacion)

        listaDocCaja = documentoCajaSA.ObtenerAnticiposConDevolucion(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, strPeriodo, listaMov, listaEstado, listaTransac)

        For Each i As documentoCaja In listaDocCaja

            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaProceso).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoOperacion
            dr(2) = "COMPROBANTE DE CAJA"
            dr(3) = str
            dr(4) = i.numeroDoc
            Select Case i.moneda
                Case 1
                    dr(5) = "NACIONAL"
                Case 2
                    dr(5) = "EXTRANJERA"
            End Select
            dr(6) = CDec(i.montoSoles).ToString("N2")
            dr(7) = i.MontoEgresosMN
            dr(8) = CDec(i.montoSoles - i.MontoEgresosMN)

            dt.Rows.Add(dr)
        Next

        Return dt

    End Function

    Private Function GetMovimientosChildrem(anio As Integer, mes As Integer) As DataTable
        Dim DocumentoCompraSA As New DocumentoCompraSA
        Dim listaDocCaja As List(Of documentoCaja)
        Dim listaEstado As New List(Of String)
        Dim listaMov As New List(Of String)
        Dim listaTipoMov As New List(Of String)
        Dim dt As New DataTable("ChildTable")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("movimiento", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDocPago", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaCobro", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroOperacion", GetType(String)))
        dt.Columns.Add(New DataColumn("moneda", GetType(String)))
        dt.Columns.Add(New DataColumn("montoSoles"))
        dt.Columns.Add(New DataColumn("idPadre", GetType(Integer)))

        Dim str As String

        'listaEstado.Add("N")
        listaEstado.Add("D")

        listaMov.Add(MovimientoCaja.Devolucion)
        'listaMov.Add(MovimientoCaja.Compensacion)

        listaTipoMov.Add("PG")
        'listaTipoMov.Add("DC")

        listaDocCaja = documentoCajaSA.ObtenerMovCajaDevolucion(Gempresas.IdEmpresaRuc, anio, mes, listaTipoMov, listaEstado, listaMov)

        For Each i As documentoCaja In listaDocCaja

            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaProceso).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idEstado
            dr(1) = i.tipoOperacion
            dr(2) = "COMPROBANTE DE CAJA"
            dr(3) = str
            dr(4) = i.numeroDoc
            Select Case i.moneda
                Case 1
                    dr(5) = "NACIONAL"
                Case 2
                    dr(5) = "EXTRANJERA"
            End Select
            dr(6) = CDec(i.montoSoles).ToString("N2")
            dr(7) = (i.idDocumento)

            dt.Rows.Add(dr)

        Next

        Return dt

    End Function

    Sub GridCFG(GGC As GridGroupingControl)
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = False
        GGC.ShowColumnHeaders = True

        Dim colorx As New GridMetroColors()

        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        GGC.SetMetroStyle(colorx)
        GGC.BorderStyle = System.Windows.Forms.BorderStyle.None
        GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        GGC.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        GGC.TableOptions.ListBoxSelectionMode = SelectionMode.One
        GGC.TableOptions.SelectionBackColor = Color.Gray
        GGC.AllowProportionalColumnSizing = False
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center

        GGC.Table.DefaultColumnHeaderRowHeight = 27
        GGC.Table.DefaultRecordRowHeight = 20
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub
#End Region

#Region "Events"

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs)
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Cursor = Cursors.WaitCursor

        Dim fechaAnt = New Date(AnioGeneral, CInt(cboMesCompra.SelectedValue), 1)
        fechaAnt = fechaAnt.AddMonths(-1)
        Dim periodoAnteriorEstaCerrado = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
        If periodoAnteriorEstaCerrado = False Then
            MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
            Cursor = Cursors.Default
            Exit Sub
        End If

        Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.anio = AnioGeneral, .mes = CInt(cboMesCompra.SelectedValue)})
        If Not IsNothing(valida) Then
            If valida = True Then
                MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If

        Dim cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
        If Not IsNothing(cajaUsuario) Then
            GetGlobalMappingCajaUsuario(cajaUsuario, usuario.IDUsuario, usuario.CustomUsuario.Full_Name)

            'Dim f As New frmAnticiposModal(StatusTipoOperacion.ANTICIPOS_RECIBIDOS)

            'With frmConfirmarDevolucion(StatusTipoOperacion.ANTICIPOS_OTORGADOS)
            '    .txtAnioCompra.Text = CInt(cboAnio.Text)
            '    .txtPeriodo.Value = New Date(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), 1)
            '    .lblMovimiento.Tag = "AO"
            '    .lblMovimiento.Text = "ANTICIPOS OTORGADOS"
            '    .CaptionLabels(0).Text = "ANTICIPOS OTORGADOS"
            '    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            '    .ObtenerTablaGenerales(dgvOtrosMov.Table.CurrentRecord.GetValue("movimiento"))
            '    .cboMesCompra.SelectedValue = cboMesCompra.SelectedValue
            '    .cboMesCompra.Enabled = True
            '    .txtHora.Value = New DateTime(cboAnio.Text, CInt(cboMesCompra.SelectedValue), DiaLaboral.Day, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
            '    .DigitalGauge2.Value = dgvOtrosMov.Table.CurrentRecord.GetValue("saldoMN")
            '    .idDocumentoPadre = dgvOtrosMov.Table.CurrentRecord.GetValue("idDocumento")
            '    .UbicarDocumentoEditar(Me.dgvOtrosMov.Table.CurrentRecord.GetValue("idDocumento"))
            '    .tipoEntidad = Me.dgvOtrosMov.Table.CurrentRecord.GetValue("tipoPersona")
            '    .txtDia.Value = New Date(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), DiaLaboral.Day)
            '    .StartPosition = FormStartPosition.CenterParent
            '    .ShowDialog()
            'End With
        Else
            MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Cursor = Cursors.WaitCursor
        Dim periodoG As String = cboMesCompra.SelectedValue & "/" & CInt(cboAnio.Text)
        'GetMovimientosPeriodo(GEstableciento.IdEstablecimiento, periodoG, "AO")

        parentTable = New DataTable
        childTable = New DataTable

        GridGroupingControl2.Table.Records.DeleteAll()

        parentTable = GetMovimientosPeriodo(GEstableciento.IdEstablecimiento, periodoG, "AO")
        childTable = GetMovimientosChildrem(cboAnio.Text, cboMesCompra.SelectedValue)

        parentToChildRelationDescriptor.ChildTableName = "MyChildTable"

        parentToChildRelationDescriptor.RelationKind = Syncfusion.Grouping.RelationKind.RelatedMasterDetails
        parentToChildRelationDescriptor.RelationKeys.Add("idDocumento", "idDocumento")

        'Adds relation to Parent Table.
        GridGroupingControl2.TableDescriptor.Relations.Add(parentToChildRelationDescriptor)
        'Dim childToGrandChildRelationDescriptor As New GridRelationDescriptor()


        'parentToChildRelationDescriptor.ChildTableDescriptor.Relations.Add(childToGrandChildRelationDescriptor)

        Me.GridGroupingControl2.Engine.SourceListSet.Add("MyParentTable", parentTable)
        Me.GridGroupingControl2.Engine.SourceListSet.Add("MyChildTable", childTable)

        Me.GridGroupingControl2.DataSource = parentTable

        '*************************************************************

        'parentToChildRelationDescriptor2.ChildTableName = "MyChildTable2"


        'parentToChildRelationDescriptor2.RelationKind = Syncfusion.Grouping.RelationKind.RelatedMasterDetails
        'parentToChildRelationDescriptor2.RelationKeys.Add("parentID", "ParentID")

        ''Adds relation to Parent Table.
        'GridGroupingControl1.TableDescriptor.Relations.Add(parentToChildRelationDescriptor2)
        'Dim childToGrandChildRelationDescriptor2 As New GridRelationDescriptor()

        ''Same as SourceListSetEntry.Name for Grand Child Table.
        ''childToGrandChildRelationDescriptor.ChildTableName = "MyGrandChildTable"
        ''childToGrandChildRelationDescriptor.RelationKind = Syncfusion.Grouping.RelationKind.RelatedMasterDetails
        ''childToGrandChildRelationDescriptor.RelationKeys.Add("childID", "ChildID")

        ''Adds relation to Child Table.
        'parentToChildRelationDescriptor2.ChildTableDescriptor.Relations.Add(childToGrandChildRelationDescriptor2)

        'Me.GridGroupingControl1.Engine.SourceListSet.Add("MyParentTable2", parentTable2)
        'Me.GridGroupingControl1.Engine.SourceListSet.Add("MyChildTable2", childTable2)
        ''Me.GridGroupingControl1.Engine.SourceListSet.Add("MyGrandChildTable", grandChildTable)

        'Me.GridGroupingControl1.DataSource = parentTable2


        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        Cursor = Cursors.WaitCursor
        If Not IsNothing(Me.GridGroupingControl2.Table.CurrentRecord) Then
            Dim f As New frmAnticiposModal(StatusTipoOperacion.ANTICIPOS_RECIBIDOS) ' frmCreaUsuarioEmpresa
            f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
            f.UbicarDocumento(Me.GridGroupingControl2.Table.CurrentRecord.GetValue("idDocumento"))
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()

        Else
            MessageBox.Show("Debe seleccionar una item!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GradientPanel11_Paint(sender As Object, e As PaintEventArgs) Handles GradientPanel11.Paint

    End Sub

#End Region




End Class