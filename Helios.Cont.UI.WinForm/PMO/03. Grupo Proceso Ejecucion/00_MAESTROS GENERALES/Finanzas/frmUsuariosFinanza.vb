Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Tools
Public Class frmUsuariosFinanza
    Inherits frmMaster
    Public lblusuario As New Label
    Public lblEntidades As New Label
    Public lblAsignar As New Label
    Public lblCajaFull As New Label

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.WindowState = FormWindowState.Normal
        GridCFG(dgvCajasAssig) ' modelo de los datagrid 
        GridCFG(dgvUsuarios)
        GridCFG(dgvEntidadFinanciera)
        GridCFG(dgvUsuarioActivo)
        GridCFG(dgvEF)
        GridCFG(dgvReporteCaja)
        cargarConteoUsuario()
        lblPeriodo.Text = "Período: " & PeriodoGeneral

    End Sub

#Region "métodos"

    Sub cargarConteoUsuario()
        ConteoUsuario()
        ConteoEntidades()
        ConteoAsignacion()
        ConteoCajaFull()
        Me.treeViewAdv2.Nodes(0).CustomControl = lblusuario
        Me.treeViewAdv2.Nodes(1).CustomControl = lblEntidades
        Me.treeViewAdv2.Nodes(2).CustomControl = lblAsignar
        Me.treeViewAdv2.Nodes(3).CustomControl = lblCajaFull
    End Sub

    Public Sub ConteoUsuario()
        Dim usuarioSA As New UsuarioSA
        Dim usuario As Integer

        usuario = usuarioSA.ListadoUsuariosconteo()

        Me.lblusuario.Text = usuario
        lblusuario.AutoSize = False
        lblusuario.BackColor = Color.Transparent
        lblusuario.Dock = DockStyle.Fill
        lblusuario.ForeColor = Color.Yellow
        lblusuario.TextAlign = ContentAlignment.MiddleLeft
    End Sub

    Public Sub ConteoEntidades()
        Dim EstadosFinancierosSA As New EstadosFinancierosSA
        Dim totalesEntidad As Integer

        totalesEntidad = EstadosFinancierosSA.ListadoEstadosFinanConteo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)

        Me.lblEntidades.Text = totalesEntidad
        lblEntidades.AutoSize = False
        lblEntidades.BackColor = Color.Transparent
        lblEntidades.Dock = DockStyle.Fill
        lblEntidades.ForeColor = Color.Yellow
        lblEntidades.TextAlign = ContentAlignment.MiddleLeft
    End Sub

    Public Sub ConteoAsignacion()
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Dim totalesCaja As New Integer

        totalesCaja = cajaUsuarioSA.ListadoCajaAsigConteo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)

        Me.lblAsignar.Text = totalesCaja
        lblAsignar.AutoSize = False
        lblAsignar.BackColor = Color.Transparent
        lblAsignar.Dock = DockStyle.Fill
        lblAsignar.ForeColor = Color.Yellow
        lblAsignar.TextAlign = ContentAlignment.MiddleLeft
    End Sub

    Public Sub ConteoCajaFull()
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Dim totalesCajaFull As New Integer

        totalesCajaFull = cajaUsuarioSA.ListadoCajaFullConteo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)

        Me.lblCajaFull.Text = totalesCajaFull
        lblCajaFull.AutoSize = False
        lblCajaFull.BackColor = Color.Transparent
        lblCajaFull.Dock = DockStyle.Fill
        lblCajaFull.ForeColor = Color.Yellow
        lblCajaFull.TextAlign = ContentAlignment.MiddleLeft
    End Sub

    Private Sub EliminarSL(idCajaUsuario As Integer)
        Dim documentoSA As New DocumentoSA
        Dim documentoDetalleSA As New DocumentoCompraDetalleSA
        Dim objDocumento As New documento
        Dim objNuevo As New totalesAlmacen

        With objDocumento

            .tipoDoc = 9901
            .idDocumento = Me.dgvCajasAssig.Table.CurrentRecord.GetValue("idcajaUsuario")
        End With

        If (documentoSA.DeleteUsuarioCajaSL(objDocumento).Length > 0) Then

            MessageBox.Show("No se pudo eliminar la caja", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Me.dgvCajasAssig.Table.CurrentRecord.Delete()
            MessageBox.Show("caja eliminada!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Public Sub EliminarPersona(intIdPersona As Integer)
        Dim usuarioSA As New UsuarioSA
        Dim usuarioBE As New Usuario
        usuarioBE.IDUsuario = intIdPersona
        usuarioSA.DeletePersonaXCaja(usuarioBE)
        PanelError.Visible = True
        lblEstado.Text = "Usuario eliminado"
    End Sub

    Public Sub EliminarEntidadFinanciera(intIdEntidad As Integer)
        Dim estadosFinancierosSA As New EstadosFinancierosSA
        Dim estadosFinancierosBE As New estadosFinancieros
        estadosFinancierosBE.idestado = intIdEntidad
        estadosFinancierosSA.DeleteEF(estadosFinancierosBE)
        PanelError.Visible = True
        lblEstado.Text = "Usuario eliminado"
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

    Public Sub ObtenerListaCajaAsignacionDetalle(idCajausuario As Integer, idpersona As Integer, fechaRegistro As DateTime)
        Dim cajausuariosa As New cajaUsuarioSA

        Dim cajausuario As New List(Of cajaUsuario)

        cajausuario = cajausuariosa.usp_ResumenTransaccionesXusuarioCajaXCierre(New cajaUsuario With {.idcajaUsuario = idCajausuario, .idPersona = idpersona, .fechaRegistro = fechaRegistro})

        Dim dt As New DataTable("Entidades financieras")
        dt.Columns.Add(New DataColumn("idCajaUsuario", GetType(Integer)))
        dt.Columns.Add(New DataColumn("idPersona", GetType(Integer)))
        dt.Columns.Add(New DataColumn("nombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("tipo", GetType(String)))
        dt.Columns.Add(New DataColumn("moneda", GetType(String)))
        dt.Columns.Add(New DataColumn("fondoMN", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("fondoME", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("ingresoAdicMN", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("ingresoAdicME", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("saldoMN", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("saldoME", GetType(Decimal)))

        For Each i In cajausuario
            Dim dr As DataRow = dt.NewRow()

            Select Case i.moneda
                Case 1
                    dr(0) = i.idcajaUsuario
                    dr(1) = i.idPersona
                    dr(2) = i.NombreEntidad
                    dr(3) = i.Tipo
                    dr(4) = "NACIONAL"
                    dr(5) = i.fondoMN
                    dr(6) = 0
                    dr(7) = i.ingresoAdicMN
                    dr(8) = 0
                    dr(9) = i.Saldo
                    dr(10) = 0
                    dt.Rows.Add(dr)
                Case 2
                    dr(0) = i.idcajaUsuario
                    dr(1) = i.idPersona
                    dr(2) = i.NombreEntidad
                    dr(3) = i.Tipo
                    dr(4) = "EXTRANJERA"
                    dr(5) = i.fondoMN
                    dr(6) = i.fondoME
                    dr(7) = i.ingresoAdicMN
                    dr(8) = i.ingresoAdicME
                    dr(9) = i.Saldo
                    dr(10) = i.SaldoME
                    dt.Rows.Add(dr)
            End Select



        Next
        dgvCajasAssig.DataSource = dt

    End Sub

    Public Property ListadoPadre As List(Of Integer)
    Private Function GetParentTable() As DataTable
        Dim dt As New DataTable("ParentTable")
        Dim cajaSa As New cajaUsuarioSA
        Dim usuarioSA As New Helios.Seguridad.WCFService.ServiceAccess.UsuarioSA

        dt = New DataTable("ParentTable")

        dt.Columns.Add(New DataColumn("idcajaUsuario", GetType(Integer)))
        dt.Columns.Add(New DataColumn("fechaRegistro", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("NombreCajaOrigen", GetType(String)))
        dt.Columns.Add(New DataColumn("NombrePersona", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreCajaDestino", GetType(String)))
        dt.Columns.Add(New DataColumn("fondoMN", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("fondoME", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("pass", GetType(String)))
        dt.Columns.Add(New DataColumn("estadoCaja", GetType(String)))



        Dim Str As String = Nothing
        Dim user As New Usuario
        ListadoPadre = New List(Of Integer)()
        For Each i As cajaUsuario In cajaSa.ListaCajasHabilitadas(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
            user = usuarioSA.UbicarUsuarioXid(New Usuario With {.IDUsuario = i.idPersona})

            Dim dr As DataRow = dt.NewRow()
            Str = Nothing
            Str = CDate(i.fechaRegistro).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idcajaUsuario
            dr(1) = Str
            dr(2) = i.NombreCajaOrigen
            dr(3) = user.Nombres & ", " & user.ApellidoPaterno & " " & user.ApellidoMaterno
            dr(4) = String.Empty
            dr(5) = i.fondoMN
            dr(6) = i.fondoME
            dr(7) = i.idcajaUsuario
            dr(8) = i.estadoCaja
            dt.Rows.Add(dr)

            ListadoPadre.Add(i.idcajaUsuario)
        Next

        Return dt
    End Function

    Public Sub GetCajaActivas()
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Dim usuriaoSA As New UsuarioSA
        Dim usuario As New Usuario
        Dim listaCajaUsuario As New List(Of cajaUsuario)
        Dim listaUsuario As New List(Of Usuario)

        Dim dt As New DataTable("Entidades financieras")
        dt.Columns.Add(New DataColumn("idPersona", GetType(Integer)))
        dt.Columns.Add(New DataColumn("idCaja", GetType(Integer)))
        dt.Columns.Add(New DataColumn("nombre", GetType(String)))
        dt.Columns.Add(New DataColumn("DNI", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))

        'listaCajaUsuario = cajaUsuarioSA.ObtenerCajaUsuarioFull

        For Each i In cajaUsuarioSA.ObtenerCajaUsuarioFullEstado()
            usuario = New Usuario
            usuario.IDUsuario = i.idPersona

            usuario = usuriaoSA.UbicarUsuarioXid(usuario)
            If (Not IsNothing(usuario)) Then
                Dim dr As DataRow = dt.NewRow()

                dr(0) = i.idPersona
                dr(1) = i.idcajaUsuario
                dr(2) = usuario.Nombres & " " & usuario.ApellidoPaterno & " " & usuario.ApellidoMaterno
                dr(3) = usuario.NroDocumento
                Select Case i.estadoCaja
                    Case "A"
                        dr(4) = "ABIERTO"
                    Case "C"
                        dr(4) = "CERRADO"
                End Select

                dt.Rows.Add(dr)

            End If
        Next
        dgvUsuarioActivo.DataSource = dt


    End Sub

    Public Sub GetAsignaciones()
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Dim usuriaoSA As New UsuarioSA
        Dim usuario As New Usuario
        Dim listaCajaUsuario As New List(Of cajaUsuario)
        Dim listaUsuario As New List(Of Usuario)
        Dim dt As New DataTable("Entidades financieras")
        dt.Columns.Add(New DataColumn("idPersona", GetType(Integer)))
        dt.Columns.Add(New DataColumn("idCaja", GetType(Integer)))
        dt.Columns.Add(New DataColumn("nombre", GetType(String)))
        dt.Columns.Add(New DataColumn("DNI", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaRegistro", GetType(DateTime)))

        'listaCajaUsuario = cajaUsuarioSA.ObtenerCajaUsuarioFull


        dgvEntidadFinanciera.Table.Records.DeleteAll()
        dgvCajasAssig.Table.Records.DeleteAll()

        For Each i In cajaUsuarioSA.ObtenerCajaUsuarioFull(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
            usuario = New Usuario
            usuario.IDUsuario = i.idPersona

            usuario = usuriaoSA.UbicarUsuarioXid(usuario)
            If (Not IsNothing(usuario)) Then
                Dim dr As DataRow = dt.NewRow()

                Select Case i.estadoCaja
                    Case "A"
                        dr(0) = i.idPersona
                        dr(1) = i.idcajaUsuario
                        dr(2) = usuario.Nombres & " " & usuario.ApellidoPaterno & " " & usuario.ApellidoMaterno
                        dr(3) = usuario.NroDocumento
                        Select Case i.estadoCaja
                            Case "A"
                                dr(4) = "ABIERTO"
                        End Select
                        dr(5) = i.fechaRegistro
                        dt.Rows.Add(dr)

                End Select


            End If
        Next
        dgvEntidadFinanciera.DataSource = dt


    End Sub

    Public Sub ObtenerListaCajaAsignacionReporte()
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Dim usuriaoSA As New UsuarioSA
        Dim usuario As New Usuario
        Dim listaCajaUsuario As New List(Of cajaUsuario)
        Dim listaUsuario As New List(Of Usuario)

        Dim dt As New DataTable("Entidades financieras")
        dt.Columns.Add(New DataColumn("idPersona", GetType(Integer)))
        dt.Columns.Add(New DataColumn("idCaja", GetType(Integer)))
        dt.Columns.Add(New DataColumn("nombre", GetType(String)))
        dt.Columns.Add(New DataColumn("DNI", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaRegistro", GetType(DateTime)))

        'listaCajaUsuario = cajaUsuarioSA.ObtenerCajaUsuarioFull

        For Each i In cajaUsuarioSA.ObtenerCajaUsuarioFull(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
            usuario = New Usuario
            usuario.IDUsuario = i.idPersona

            usuario = usuriaoSA.UbicarUsuarioXid(usuario)
            If (Not IsNothing(usuario)) Then
                Dim dr As DataRow = dt.NewRow()

                dr(0) = i.idPersona
                dr(1) = i.idcajaUsuario
                dr(2) = usuario.Nombres & " " & usuario.ApellidoPaterno & " " & usuario.ApellidoMaterno
                dr(3) = usuario.NroDocumento
                Select Case i.estadoCaja
                    Case "A"
                        dr(4) = "ABIERTO"
                    Case "C"
                        dr(4) = "CERRADO"
                End Select
                dr(5) = i.fechaRegistro
                dt.Rows.Add(dr)


            End If
        Next
        dgvReporteCaja.DataSource = dt


    End Sub


    Dim parentToChildRelationDescriptor As New GridRelationDescriptor()
    Dim parentTable As New DataTable
    Dim childTable As New DataTable

    Private Function GetChildTable() As DataTable
        Dim cajaSa As New cajaUsuarioSA
        Dim usuarioSA As New Helios.Seguridad.WCFService.ServiceAccess.UsuarioSA

        Dim dt As New DataTable("ChildTable")
        dt = New DataTable("ChildTable")

        dt.Columns.Add(New DataColumn("idcajaUsuario", GetType(Integer)))
        'lower case c
        dt.Columns.Add(New DataColumn("Usuario", GetType(String)))
        dt.Columns.Add(New DataColumn("Importe", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("Estado", GetType(String)))
        dt.Columns.Add(New DataColumn("idPadre", GetType(Integer)))
        'upper case P
        Dim user As New Usuario

        For Each x As cajaUsuario In cajaSa.UbicarCajasHijasFull(ListadoPadre)
            user = usuarioSA.UbicarUsuarioXid(New Usuario With {.IDUsuario = x.idPersona})
            Dim dr As DataRow = dt.NewRow()
            dr(0) = x.idcajaUsuario
            dr(1) = user.Nombres & ", " & user.ApellidoPaterno & " " & user.ApellidoMaterno
            dr(2) = x.fondoMN
            dr(3) = x.estadoCaja
            dr(4) = x.idPadre
            dt.Rows.Add(dr)
        Next

        Return dt
    End Function

    Private Sub LoadCajas()

        Dim dSet As New DataSet()
        parentTable = GetParentTable()
        If parentTable.Rows.Count > 0 Then
            childTable = GetChildTable()
            If childTable.Rows.Count > 0 Then
                dSet.Tables.AddRange(New DataTable() {parentTable, childTable})

                'setup the relations
                Dim parentColumn As DataColumn = parentTable.Columns("idcajaUsuario")
                Dim childColumn As DataColumn = childTable.Columns("idPadre")
                dSet.Relations.Add("ParentToChild", parentColumn, childColumn)
            End If
        End If

        Me.dgvCajasAssig.DataSource = parentTable
        Me.dgvCajasAssig.Engine.BindToCurrencyManager = False

        'Me.dgvCajasAssig.GridVisualStyles = GridVisualStyles.Metro
        'Me.dgvCajasAssig.GridOfficeScrollBars = OfficeScrollBars.Metro
        Me.dgvCajasAssig.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = False
        Me.dgvCajasAssig.TopLevelGroupOptions.ShowCaption = False

    End Sub

    Private Sub GetUsuarioCajas()
        Dim UsuarioSA As New UsuarioSA

        Dim dt As New DataTable("Usuarios")
        dt.Columns.Add(New DataColumn("idPersona", GetType(Integer)))
        dt.Columns.Add(New DataColumn("dni", GetType(String)))
        dt.Columns.Add(New DataColumn("Nombres", GetType(String)))
        dt.Columns.Add(New DataColumn("appat", GetType(String)))
        dt.Columns.Add(New DataColumn("apmat", GetType(String)))
        'dt.Columns.Add(New DataColumn("fechaActualizacion", GetType(String)))

        Dim str As String
        For Each i As Usuario In UsuarioSA.GetListaUsuarios()

            If (i.Rol = "Cajero") Then
                Dim dr As DataRow = dt.NewRow()
                str = Nothing
                '  str = CDate(i.fechaActualizacion).ToString("dd-MMM hh:mm tt ")
                dr(0) = i.IDUsuario
                If (Not IsNothing(i.NroDocumento)) Then
                    dr(1) = i.NroDocumento
                Else
                    dr(1) = ""
                End If
                dr(2) = i.Nombres
                dr(3) = i.ApellidoPaterno
                dr(4) = i.ApellidoMaterno
                'dr(4) = str
                dt.Rows.Add(dr)
            End If


        Next
        dgvUsuarios.DataSource = dt

    End Sub

    Public Sub ObtenerListaCajas()
        Dim entidadSA As New EstadosFinancierosSA

        Dim dt As New DataTable("Entidades financieras")
        dt.Columns.Add(New DataColumn("idEF", GetType(Integer)))
        dt.Columns.Add(New DataColumn("moneda", GetType(String)))
        dt.Columns.Add(New DataColumn("cuenta", GetType(String)))
        dt.Columns.Add(New DataColumn("descripEF", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoEF", GetType(String)))

        For Each i In entidadSA.ObtenerEstadosFinancierosPorEstablecimiento(New estadosFinancieros With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
            Dim dr As DataRow = dt.NewRow()

            dr(0) = i.idestado
            If i.codigo = 1 Then
                dr(1) = ("NACIONAL")
            Else
                dr(1) = ("EXTRANJERA")
            End If
            dr(2) = i.cuenta
            dr(3) = i.descripcion
            If (i.tipo = "BC") Then
                dr(4) = "BANCO"
            ElseIf (i.tipo = "EF") Then
                dr(4) = "EFECTIVO"
            ElseIf (i.tipo = "TC") Then
                dr(4) = "TARJETA"
            End If
            dt.Rows.Add(dr)
        Next
        dgvEF.DataSource = dt
    End Sub

#End Region

    Private Sub frmUsuariosFinanza_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmUsuariosFinanza_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        treeViewAdv2.BackColor = Color.MediumSeaGreen
        TabUsuariosCaja.Parent = TabControlAdv1
        TabAsignaciones.Parent = Nothing
        TabActivas.Parent = Nothing
    End Sub

    Private Sub treeViewAdv2_AfterSelect(sender As Object, e As EventArgs) Handles treeViewAdv2.AfterSelect
        Select Case treeViewAdv2.SelectedNode.Tag
            Case "Administración usuarios"
                TabUsuariosCaja.Parent = TabControlAdv1
                TabAsignaciones.Parent = Nothing
                TabActivas.Parent = Nothing
                TabReporteCaja.Parent = Nothing
                TabCajaBanco.Parent = Nothing
                btCloseBox.Visible = False
                ToolStripButton33.Visible = True
                ToolStripButton34.Visible = True
                ToolStripButton35.Visible = True
            Case "Administración Caja y Bancos"
                TabUsuariosCaja.Parent = Nothing
                TabAsignaciones.Parent = Nothing
                TabActivas.Parent = Nothing
                TabReporteCaja.Parent = Nothing
                TabCajaBanco.Parent = TabControlAdv1
                btCloseBox.Visible = False
                ToolStripButton33.Visible = False
                ToolStripButton34.Visible = False
                ToolStripButton35.Visible = False
            Case "Asignaciones"
                TabUsuariosCaja.Parent = Nothing
                TabAsignaciones.Parent = TabControlAdv1
                TabActivas.Parent = Nothing
                TabReporteCaja.Parent = Nothing
                TabCajaBanco.Parent = Nothing
                btCloseBox.Visible = True
                ToolStripButton33.Visible = False
                ToolStripButton34.Visible = False
                ToolStripButton35.Visible = False
            Case "Activas"
                TabUsuariosCaja.Parent = Nothing
                TabAsignaciones.Parent = Nothing
                TabActivas.Parent = TabControlAdv1
                TabReporteCaja.Parent = Nothing
                TabCajaBanco.Parent = Nothing
                btCloseBox.Visible = False
                ToolStripButton33.Visible = False
                ToolStripButton34.Visible = False
                ToolStripButton35.Visible = False
            Case "Reportes"
                TabUsuariosCaja.Parent = Nothing
                TabAsignaciones.Parent = Nothing
                TabActivas.Parent = Nothing
                TabReporteCaja.Parent = TabControlAdv1
                TabCajaBanco.Parent = Nothing
                btCloseBox.Visible = False
                ToolStripButton33.Visible = False
                ToolStripButton34.Visible = False
                ToolStripButton35.Visible = False
        End Select
    End Sub

    Private Sub treeViewAdv2_Click(sender As Object, e As EventArgs) Handles treeViewAdv2.Click

    End Sub

    Private Sub treeViewAdv2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles treeViewAdv2.MouseDoubleClick
        Me.Cursor = Cursors.WaitCursor
        Select Case treeViewAdv2.SelectedNode.Tag
            Case "Administración usuarios"
                GetUsuarioCajas()
            Case "Administración Caja y Bancos"
                ObtenerListaCajas()
            Case "Asignaciones"
                GetAsignaciones()
            Case "Activas"
                GetCajaActivas()
            Case "Reportes"
                ObtenerListaCajaAsignacionReporte()
        End Select
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvEntidadFinanciera_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvEntidadFinanciera.TableControlCellClick
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(Me.dgvEntidadFinanciera.Table.CurrentRecord) Then
            ObtenerListaCajaAsignacionDetalle(Me.dgvEntidadFinanciera.Table.CurrentRecord.GetValue("idCaja"), Me.dgvEntidadFinanciera.Table.CurrentRecord.GetValue("idPersona"), Me.dgvEntidadFinanciera.Table.CurrentRecord.GetValue("fechaRegistro"))
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Me.Cursor = Cursors.WaitCursor
        With frmModalCaja
            .manipulacionDatos(True)
            .strEstadoManipulacion = ENTITY_ACTIONS.INSERT
            .ObtenerMascaraMercaderia()
            .txtCuentaID.Text = "101"
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            cargarConteoUsuario()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton14_Click(sender As Object, e As EventArgs) Handles ToolStripButton14.Click
        Me.Cursor = Cursors.WaitCursor
        Dim f As New frmAbrirCajaUsuario ' frmCreaUsuarioEmpresa
        f.strEstadoManipulacion = ENTITY_ACTIONS.INSERT
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        cargarConteoUsuario()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs) Handles ToolStripButton9.Click
        If TabControlAdv1.SelectedTab Is TabUsuariosCaja Then
            If Not IsNothing(Me.dgvUsuarios.Table.CurrentRecord) Then
                With frmCrearUsuarioEmpresa
                    .strEstadoManipulacion = ENTITY_ACTIONS.UPDATE
                    .strTipoAdmin = "CAJERO"
                    .CargarDatos()
                    .UbicarUsaurio(Me.dgvUsuarios.Table.CurrentRecord.GetValue("idPersona"))
                    .idUsuario = (Me.dgvUsuarios.Table.CurrentRecord.GetValue("idPersona"))
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            Else
                MessageBox.Show("Debe seleccionar un usuario!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        ElseIf TabControlAdv1.SelectedTab Is TabAsignaciones Then
            If Not IsNothing(Me.dgvEntidadFinanciera.Table.CurrentRecord) Then
                With frmAbrirCajaUsuario
                    .strEstadoManipulacion = ENTITY_ACTIONS.UPDATE

                    If (Me.dgvEntidadFinanciera.Table.CurrentRecord.GetValue("estado")) = "ABIERTO" Then
                        .idCajauser = Me.dgvEntidadFinanciera.Table.CurrentRecord.GetValue("idCaja")
                        .UbicarCajaUsuario()
                        .StartPosition = FormStartPosition.CenterParent
                        .ShowDialog()
                    Else
                        MessageBox.Show("La caja esta cerrada!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End With
            End If

        ElseIf TabControlAdv1.SelectedTab Is TabCajaBanco Then
            If Not IsNothing(Me.dgvEF.Table.CurrentRecord) Then
                With frmModalCaja
                    .strEstadoManipulacion = ENTITY_ACTIONS.UPDATE
                    .idEstados = Me.dgvEF.Table.CurrentRecord.GetValue("idEF")
                    .manipulacionDatos(False)
                    .UbicarPorID(Me.dgvEF.Table.CurrentRecord.GetValue("idEF"))
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()

                End With
            End If

        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        If TabControlAdv1.SelectedTab Is TabUsuariosCaja Then
            If Not IsNothing(Me.dgvUsuarios.Table.CurrentRecord) Then
                Dim cajaUsaurioSA As New cajaUsuarioSA
                Dim conteoCaja As Integer
                conteoCaja = cajaUsaurioSA.UbicarCajaXPersona(Me.dgvUsuarios.Table.CurrentRecord.GetValue("idPersona"), GEstableciento.IdEstablecimiento, Gempresas.IdEmpresaRuc)

                If (conteoCaja = 0) Then
                    If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        EliminarPersona(Me.dgvUsuarios.Table.CurrentRecord.GetValue("idPersona"))
                        Me.dgvUsuarios.Table.CurrentRecord.Delete()
                        cargarConteoUsuario()
                    End If
                Else
                    MessageBox.Show("No se puede eliminar usuario!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If


            Else
                Me.Cursor = Cursors.Arrow
            End If
        ElseIf TabControlAdv1.SelectedTab Is TabAsignaciones Then

            Dim ventaSA As New documentoVentaAbarrotesSA
            Dim el As Element = Me.dgvCajasAssig.Table.GetInnerMostCurrentElement()
            Try
                If el IsNot Nothing Then
                    Dim table As GridTable = TryCast(el.ParentTable, GridTable)
                    Dim tableControl As GridTableControl = Me.dgvCajasAssig.GetTableControl(table.TableDescriptor.Name)
                    Dim cc As GridCurrentCell = tableControl.CurrentCell
                    Dim style As GridTableCellStyleInfo = table.GetTableCellStyle(cc.RowIndex, cc.ColIndex)
                    Dim rec As GridRecord = TryCast(el, GridRecord)
                    If rec Is Nothing AndAlso TypeOf el Is GridRecordRow Then
                        rec = TryCast(el.ParentRecord, GridRecord)
                    End If
                    If rec IsNot Nothing Then

                        If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            EliminarSL(rec.GetValue("idcajaUsuario"))
                            cargarConteoUsuario()
                        End If

                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        ElseIf TabControlAdv1.SelectedTab Is TabCajaBanco Then

            Dim ventaSA As New documentoVentaAbarrotesSA

            Try
                If Not IsNothing(Me.dgvEF.Table.CurrentRecord) Then
                    Dim cajaUsaurioSA As New cajaUsuarioSA
                    Dim documentoCajaSA As New DocumentoCajaSA
                    Dim conteoDocumentoCaja As Integer
                    Dim conteoEntidad As Integer
                    conteoEntidad = cajaUsaurioSA.UbicarCajaXIdEntidadOrigen(Me.dgvEF.Table.CurrentRecord.GetValue("idEF"), GEstableciento.IdEstablecimiento, Gempresas.IdEmpresaRuc)
                    conteoDocumentoCaja += documentoCajaSA.UbicarDocCajaXIdEntidadOrigen(Me.dgvEF.Table.CurrentRecord.GetValue("idEF"), GEstableciento.IdEstablecimiento, Gempresas.IdEmpresaRuc) + conteoEntidad


                    If (conteoDocumentoCaja = 0) Then
                        If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            EliminarEntidadFinanciera(Me.dgvEF.Table.CurrentRecord.GetValue("idEF"))
                            Me.dgvEF.Table.CurrentRecord.Delete()
                            cargarConteoUsuario()
                        End If
                    Else
                        MessageBox.Show("No se puede eliminar Entidad Financiera!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If


                Else
                    Me.Cursor = Cursors.Arrow
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Me.Cursor = Cursors.WaitCursor
        If TabControlAdv1.SelectedTab Is TabUsuariosCaja Then
            GetUsuarioCajas()
            cargarConteoUsuario()
        ElseIf TabControlAdv1.SelectedTab Is TabAsignaciones Then
            GetAsignaciones()
            cargarConteoUsuario()
        ElseIf TabControlAdv1.SelectedTab Is TabCajaBanco Then
            cargarConteoUsuario()
            ObtenerListaCajas()
        ElseIf TabControlAdv1.SelectedTab Is TabReporteCaja Then
            cargarConteoUsuario()
            ObtenerListaCajaAsignacionReporte()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btCloseBox_Click(sender As Object, e As EventArgs) Handles btCloseBox.Click
        Me.Cursor = Cursors.WaitCursor
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Dim cajaUser As New cajaUsuario
        Dim el As Element = Me.dgvEntidadFinanciera.Table.GetInnerMostCurrentElement()
        Try
            If el IsNot Nothing Then

                Dim table As GridTable = TryCast(el.ParentTable, GridTable)
                Dim tableControl As GridTableControl = Me.dgvEntidadFinanciera.GetTableControl(table.TableDescriptor.Name)
                Dim cc As GridCurrentCell = tableControl.CurrentCell
                Dim style As GridTableCellStyleInfo = table.GetTableCellStyle(cc.RowIndex, cc.ColIndex)
                Dim rec As GridRecord = TryCast(el, GridRecord)
                If rec Is Nothing AndAlso TypeOf el Is GridRecordRow Then
                    rec = TryCast(el.ParentRecord, GridRecord)
                End If
                If rec IsNot Nothing Then

                    If cajaUsuarioSA.UbicarCajaUsuarioPorID(rec.GetValue("idCaja")).estadoCaja = "A" Then

                        '   Console.WriteLine(style.TableCellIdentity.Column.Name)
                        'MsgBox(rec.GetValue("idcajaUsuario"))
                        If Not IsNothing(Me.dgvEntidadFinanciera.Table.CurrentRecord) Then
                            'Dim f As New frmCerrarCajaUsuario(Me.dgvEntidadFinanciera.Table.CurrentRecord)
                            Dim f As New frmCerrarCajaDetallado(Me.dgvEntidadFinanciera.Table.CurrentRecord)
                            f.idPersona = dgvEntidadFinanciera.Table.CurrentRecord.GetValue("idPersona")
                            f.dniPerCaja = dgvEntidadFinanciera.Table.CurrentRecord.GetValue("dni")
                            f.txtUsuariocaja.Text = dgvEntidadFinanciera.Table.CurrentRecord.GetValue("nombre")
                            f.txtUsuariocaja.Tag = dgvEntidadFinanciera.Table.CurrentRecord.GetValue("idCaja")
                            f.txtfecApertura.Text = dgvEntidadFinanciera.Table.CurrentRecord.GetValue("fechaRegistro")
                            f.StartPosition = FormStartPosition.CenterParent
                            f.ShowDialog()
                            GetAsignaciones()
                            cargarConteoUsuario()
                        Else
                            If MessageBoxAdv.Show("Desea cerrar la caja seleccionada?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                                cajaUser = New cajaUsuario
                                cajaUser.idcajaUsuario = rec.GetValue("idCaja")
                                cajaUser.estadoCaja = "C"
                                cajaUsuarioSA.CerrarAbrirCajaSubUsuario(cajaUser)
                                MessageBoxAdv.Show("Caja cerrada correctamente", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)

                            End If
                        End If


                    End If

                End If
            Else
                Throw New Exception("Debe elegir un usuario.!!")
            End If
        Catch ex As Exception
            MessageBoxAdv.Show("Debe elegir un usuario", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not IsNothing(Me.dgvReporteCaja.Table.CurrentRecord) Then
            With frmCajausuario
                .ConsultaReporte(Me.dgvReporteCaja.Table.CurrentRecord.GetValue("idCaja"), Me.dgvReporteCaja.Table.CurrentRecord.GetValue("idPersona"), Me.dgvReporteCaja.Table.CurrentRecord.GetValue("nombre"), Me.dgvReporteCaja.Table.CurrentRecord.GetValue("DNI"))
                .ShowDialog()
            End With
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Not IsNothing(Me.dgvReporteCaja.Table.CurrentRecord) Then
            With frmCajaUsuarioCierre
                .ConsultaReportePost(Me.dgvReporteCaja.Table.CurrentRecord.GetValue("idCaja"), Me.dgvReporteCaja.Table.CurrentRecord.GetValue("idPersona"), Me.dgvReporteCaja.Table.CurrentRecord.GetValue("nombre"), Me.dgvReporteCaja.Table.CurrentRecord.GetValue("DNI"), Me.dgvReporteCaja.Table.CurrentRecord.GetValue("fechaRegistro"))
                .ShowDialog()
            End With
        End If
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        With frmCrearUsuarioEmpresa
            .strTipoAdmin = "CAJERO"
            .CargarDatos()
            .strEstadoManipulacion = ENTITY_ACTIONS.INSERT
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            cargarConteoUsuario()
        End With
    End Sub

    Private Sub ToolStripButton33_Click(sender As Object, e As EventArgs) Handles ToolStripButton33.Click
        If Not IsNothing(Me.dgvUsuarios.Table.CurrentRecord) Then
            With frmCrearUsuarioEmpresa
                .GroupBox1.Visible = False
                .strEstadoManipulacion = ENTITY_ACTIONS.UPDATE
                .strTipoAdmin = "CAJERO"
                '.CargarDatos()
                .UbicarUsaurio(Me.dgvUsuarios.Table.CurrentRecord.GetValue("idPersona"))
                .idUsuario = (Me.dgvUsuarios.Table.CurrentRecord.GetValue("idPersona"))
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
        Else
            MessageBox.Show("Debe seleccionar un usuario!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ToolStripButton34_Click(sender As Object, e As EventArgs) Handles ToolStripButton34.Click
        Try
            If Not IsNothing(Me.dgvUsuarios.Table.CurrentRecord) Then
                Dim cajaUsaurioSA As New cajaUsuarioSA
                Dim conteoCaja As Integer
                conteoCaja = cajaUsaurioSA.UbicarCajaXPersona(Me.dgvUsuarios.Table.CurrentRecord.GetValue("idPersona"), GEstableciento.IdEstablecimiento, Gempresas.IdEmpresaRuc)

                If (conteoCaja = 0) Then
                    If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        EliminarPersona(Me.dgvUsuarios.Table.CurrentRecord.GetValue("idPersona"))
                        Me.dgvUsuarios.Table.CurrentRecord.Delete()
                    End If
                Else
                    MessageBox.Show("No se puede eliminar usuario!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub ToolStripButton35_Click(sender As Object, e As EventArgs) Handles ToolStripButton35.Click
        GetUsuarioCajas()
    End Sub
End Class