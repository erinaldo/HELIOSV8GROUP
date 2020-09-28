Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Tools
Public Class frmAbrirCerrar_Caja

#Region "Attributes"
    Public Property cajaUsuarioSA As New cajaUsuarioSA
    Public Property cajaUser As New cajaUsuario
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GridCFG(dgvEntidadFinanciera)
        GridCFG(dgvCajasAssig)
        GetAsignaciones()
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

    Public Sub ObtenerListaCajaAsignacionDetalle(idCajausuario As Integer, idpersona As Integer, fechaRegistro As DateTime)
        Dim cajausuariosa As New cajaUsuarioSA
        Dim finanza As New estadosFinancieros
        Dim finanzaSA As New EstadosFinancierosSA
        Dim cajausuario As New List(Of cajaUsuario)

        cajausuario = cajausuariosa.ResumenTransaccionesXusuarioCajaPago(New cajaUsuario With {.idcajaUsuario = idCajausuario, .idPersona = idpersona, .fechaRegistro = fechaRegistro})

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
        dt.Columns.Add(New DataColumn("empresa"))
        dt.Columns.Add(New DataColumn("estable"))
        dt.Columns.Add(New DataColumn("pagoMN"))
        dt.Columns.Add(New DataColumn("pagoME"))

        For Each i In cajausuario
            finanza = finanzaSA.GetUbicar_estadosFinancierosPorID(i.idEntidad)


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
                    dr(11) = finanza.idEmpresa
                    dr(12) = finanza.idEstablecimiento
                    dr(13) = i.otrosEgresosMN
                    dr(14) = 0.0
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
                    dr(11) = finanza.idEmpresa
                    dr(12) = finanza.idEstablecimiento
                    dr(13) = i.otrosEgresosMN
                    dr(14) = 0.0
                    dt.Rows.Add(dr)
            End Select



        Next
        dgvCajasAssig.DataSource = dt

    End Sub
#End Region

#Region "Events"
    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Me.Cursor = Cursors.WaitCursor
        cajaUsuarioSA = New cajaUsuarioSA
        cajaUser = New cajaUsuario
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
                            Dim f As New frmCerrarCajaDetallado(Me.dgvEntidadFinanciera.Table.CurrentRecord)
                            '.IDCajaUser =
                            '.ListaCierresPorModulo(rec.GetValue("idCajaUsuario"))
                            '.UbicarCaja(rec.GetValue("idCajaUsuario"))
                            f.idPersona = dgvEntidadFinanciera.Table.CurrentRecord.GetValue("idPersona")
                            f.dniPerCaja = dgvEntidadFinanciera.Table.CurrentRecord.GetValue("dni")
                            f.txtUsuariocaja.Text = dgvEntidadFinanciera.Table.CurrentRecord.GetValue("nombre")
                            f.txtUsuariocaja.Tag = dgvEntidadFinanciera.Table.CurrentRecord.GetValue("idCaja")
                            f.txtfecApertura.Text = dgvEntidadFinanciera.Table.CurrentRecord.GetValue("fechaRegistro")
                            f.consultaMovimientoCaja(dgvEntidadFinanciera.Table.CurrentRecord.GetValue("idCaja"))
                            f.StartPosition = FormStartPosition.CenterParent
                            f.ShowDialog()
                            GetAsignaciones()
                            dgvCajasAssig.Table.Records.DeleteAll()
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
        'Me.Cursor = Cursors.WaitCursor
        'cajaUsuarioSA = New cajaUsuarioSA
        'cajaUser = New cajaUsuario
        'Dim el As Element = Me.dgvEntidadFinanciera.Table.GetInnerMostCurrentElement()
        'Try
        '    If el IsNot Nothing Then
        '        Dim table As GridTable = TryCast(el.ParentTable, GridTable)
        '        Dim tableControl As GridTableControl = Me.dgvEntidadFinanciera.GetTableControl(table.TableDescriptor.Name)
        '        Dim cc As GridCurrentCell = tableControl.CurrentCell
        '        Dim style As GridTableCellStyleInfo = table.GetTableCellStyle(cc.RowIndex, cc.ColIndex)
        '        Dim rec As GridRecord = TryCast(el, GridRecord)
        '        If rec Is Nothing AndAlso TypeOf el Is GridRecordRow Then
        '            rec = TryCast(el.ParentRecord, GridRecord)
        '        End If
        '        If rec IsNot Nothing Then

        '            If cajaUsuarioSA.UbicarCajaUsuarioPorID(rec.GetValue("idCaja")).estadoCaja = "A" Then

        '                '   Console.WriteLine(style.TableCellIdentity.Column.Name)
        '                'MsgBox(rec.GetValue("idcajaUsuario"))
        '                If Not IsNothing(Me.dgvEntidadFinanciera.Table.CurrentRecord) Then
        '                    Dim f As New frmCerrarCajaDetallado(Me.dgvEntidadFinanciera.Table.CurrentRecord)
        '                    '.IDCajaUser =
        '                    '.ListaCierresPorModulo(rec.GetValue("idCajaUsuario"))
        '                    '.UbicarCaja(rec.GetValue("idCajaUsuario"))
        '                    f.idPersona = dgvEntidadFinanciera.Table.CurrentRecord.GetValue("idPersona")
        '                    f.dniPerCaja = dgvEntidadFinanciera.Table.CurrentRecord.GetValue("dni")
        '                    f.txtUsuariocaja.Text = dgvEntidadFinanciera.Table.CurrentRecord.GetValue("nombre")
        '                    f.txtUsuariocaja.Tag = dgvEntidadFinanciera.Table.CurrentRecord.GetValue("idCaja")
        '                    f.txtfecApertura.Text = dgvEntidadFinanciera.Table.CurrentRecord.GetValue("fechaRegistro")
        '                    f.StartPosition = FormStartPosition.CenterParent
        '                    f.ShowDialog()
        '                    GetAsignaciones()
        '                    dgvCajasAssig.Table.Records.DeleteAll()
        '                Else
        '                    If MessageBoxAdv.Show("Desea cerrar la caja seleccionada?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
        '                        cajaUser = New cajaUsuario
        '                        cajaUser.idcajaUsuario = rec.GetValue("idCaja")
        '                        cajaUser.estadoCaja = "C"
        '                        cajaUsuarioSA.CerrarAbrirCajaSubUsuario(cajaUser)
        '                        MessageBoxAdv.Show("Caja cerrada correctamente", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '                    End If
        '                End If
        '            End If

        '        End If
        '    Else
        '        Throw New Exception("Debe elegir un usuario.!!")
        '    End If
        'Catch ex As Exception
        '    MessageBoxAdv.Show("Debe elegir un usuario", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        'Me.Cursor = Cursors.WaitCursor
        'Dim f As New frmAbrirCajaUsuario ' frmCreaUsuarioEmpresa
        'f.strEstadoManipulacion = ENTITY_ACTIONS.INSERT
        'f.StartPosition = FormStartPosition.CenterParent
        'f.ShowDialog()
        'GetAsignaciones()
        'dgvCajasAssig.Table.Records.DeleteAll()
        'Me.Cursor = Cursors.Arrow
        'Me.Cursor = Cursors.WaitCursor
        Dim f As New FormCrearCajero
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)

        'Dim f As New frmModalAbrirCajaUsuario ' frmCreaUsuarioEmpresa
        'f.cboMesCompra.SelectedValue = MesGeneral
        'f.cboMesCompra.Enabled = True
        'f.txtDia.Value = New Date(AnioGeneral, MesGeneral, DiaLaboral.Day)
        'f.strEstadoManipulacion = ENTITY_ACTIONS.INSERT
        'f.txtPeriodo.Value = New Date(AnioGeneral, CInt(MesGeneral), 1)
        'f.StartPosition = FormStartPosition.CenterParent
        'f.ShowDialog()
        GetAsignaciones()
        dgvCajasAssig.Table.Records.DeleteAll()
        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        If Not IsNothing(Me.dgvEntidadFinanciera.Table.CurrentRecord) Then
            With frmAbrirCajaUsuario
                .strEstadoManipulacion = ENTITY_ACTIONS.UPDATE

                If (Me.dgvEntidadFinanciera.Table.CurrentRecord.GetValue("estado")) = "ABIERTO" Then
                    .idCajauser = Me.dgvEntidadFinanciera.Table.CurrentRecord.GetValue("idCaja")
                    .UbicarCajaUsuario()
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                    'GetAsignaciones()
                    dgvCajasAssig.Table.Records.DeleteAll()
                Else
                    MessageBox.Show("La caja esta cerrada!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End With
        End If
    End Sub

    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click
        Cursor = Cursors.WaitCursor
        GetAsignaciones()
        Cursor = Cursors.Default
    End Sub
    Private Sub dgvEntidadFinanciera_TableControlCellClick(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs) Handles dgvEntidadFinanciera.TableControlCellClick
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(Me.dgvEntidadFinanciera.Table.CurrentRecord) Then
            ObtenerListaCajaAsignacionDetalle(Me.dgvEntidadFinanciera.Table.CurrentRecord.GetValue("idCaja"), Me.dgvEntidadFinanciera.Table.CurrentRecord.GetValue("idPersona"), Me.dgvEntidadFinanciera.Table.CurrentRecord.GetValue("fechaRegistro"))
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub frmAbrirCerrar_Caja_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
#End Region

End Class