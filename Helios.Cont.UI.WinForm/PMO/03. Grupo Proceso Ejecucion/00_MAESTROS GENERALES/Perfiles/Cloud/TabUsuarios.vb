Imports System.Threading
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.Business.Entity
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping


Public Class TabUsuarios

#Region "Fields"
    Dim filter As New GridExcelFilter()
    Private Thread As Thread
    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
    Public Property RolSA As New RolSA

#End Region

#Region "Constructors"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormatoGridAvanzado(dgPerfilesUsuario, True, False)
        'GetTableGrid()
        'Dim empresa As String = Gempresas.IdEmpresaRuc
        'ProgressBar1.Visible = True
        'ProgressBar1.Style = ProgressBarStyle.Marquee
        'Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetClientes(empresa)))
        'Thread.Start()

    End Sub
#End Region

#Region "Methods"

    'Sub GetTableGrid()
    '    Dim dt As New DataTable()



    '    dt.Columns.Add("IDUsuario", GetType(Integer))

    '    dt.Columns.Add("idCargo", GetType(String))
    '    dt.Columns.Add("cargo", GetType(String))

    '    dt.Columns.Add("TipoDocumento", GetType(String))
    '    dt.Columns.Add("NroDocumento", GetType(String))
    '    dt.Columns.Add("Full_Name", GetType(String))
    '    dt.Columns.Add("estado", GetType(String))
    '    dt.Columns.Add("codigoVendedor", GetType(String))

    '    dgPerfilesUsuario.DataSource = dt
    'End Sub


    Private Sub GetClientes(empresa As String)
        Try
            Dim dt As New DataTable("Usuario")
            Dim UsuarioSA As New UsuarioSA

            dt.Columns.Add(New DataColumn("IDUsuario", GetType(Integer)))

            dt.Columns.Add(New DataColumn("idCargo", GetType(String)))
            dt.Columns.Add(New DataColumn("cargo", GetType(String)))

            dt.Columns.Add(New DataColumn("TipoDocumento", GetType(String)))
            dt.Columns.Add(New DataColumn("NroDocumento", GetType(String)))
            dt.Columns.Add(New DataColumn("Full_Name", GetType(String)))
            dt.Columns.Add(New DataColumn("estado", GetType(String)))
            dt.Columns.Add(New DataColumn("codigoVendedor", GetType(String)))


            'dgPerfilesUsuario.Table.Records.DeleteAll()

            Dim contador As Integer

            If UsuariosList IsNot Nothing Then

                For Each i In UsuariosList.Where(Function(O) O.TipoDocumento <> "SUPER").ToList  'UsuarioSA.ListadoUsuariosXclienteCargo(New Usuario With {.IDEmpresa = Gempresas.IdEmpresaRuc, .IDEstablecimiento = GEstableciento.IdEstablecimiento})

                    'For Each i In UsuarioSA.ListadoUsuariosXcliente(Gempresas.IDCliente)
                    Dim dr As DataRow = dt.NewRow()

                    dr(0) = i.IDUsuario
                    dr(1) = ""
                    dr(2) = "" 'i.UsuarioRol

                    If (i.TipoDocumento.Length > 0) Then
                        dr(3) = i.TipoDocumento
                    Else
                        dr(3) = ""
                    End If
                    If ((i.NroDocumento.Length) > 0) Then
                        dr(4) = i.NroDocumento
                    Else
                        dr(4) = ""
                    End If
                    dr(5) = i.Full_Name
                    dr(6) = i.estado
                    dr(7) = i.codigo


                    '    Me.dgPerfilesUsuario.Table.AddNewRecord.SetCurrent()
                    '    Me.dgPerfilesUsuario.Table.AddNewRecord.BeginEdit()
                    'Me.dgPerfilesUsuario.Table.CurrentRecord.SetValue("IDUsuario", i.IDUsuario)
                    'Me.dgPerfilesUsuario.Table.CurrentRecord.SetValue("idCargo", "")
                    'Me.dgPerfilesUsuario.Table.CurrentRecord.SetValue("cargo", "")

                    'If (i.TipoDocumento.Length > 0) Then
                    '    Me.dgPerfilesUsuario.Table.CurrentRecord.SetValue("TipoDocumento", i.TipoDocumento)
                    'Else
                    '    Me.dgPerfilesUsuario.Table.CurrentRecord.SetValue("TipoDocumento", "")
                    'End If
                    'If ((i.NroDocumento.Length) > 0) Then
                    '    Me.dgPerfilesUsuario.Table.CurrentRecord.SetValue("NroDocumento", i.NroDocumento)
                    'Else
                    '    Me.dgPerfilesUsuario.Table.CurrentRecord.SetValue("NroDocumento", "")
                    'End If


                    'Me.dgPerfilesUsuario.Table.CurrentRecord.SetValue("Full_Name", i.Full_Name)
                    'Me.dgPerfilesUsuario.Table.CurrentRecord.SetValue("Estado", i.estado)
                    'Me.dgPerfilesUsuario.Table.CurrentRecord.SetValue("codigoVendedor", i.codigo)
                    'Me.dgPerfilesUsuario.Table.AddNewRecord.EndEdit()




                    dt.Rows.Add(dr)
                Next
                contador = dt.Rows.Count
                'dgvUsuariosSys.DataSource = dt
                setDatasource(dt)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub setDatasource(ByVal table As DataTable)
        If Me.InvokeRequired Then
            Dim deleg As New SetDataSourceDelegate(AddressOf setDatasource)
            Invoke(deleg, New Object() {table})
        Else
            dgPerfilesUsuario.DataSource = table
            ProgressBar1.Visible = False
        End If
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub CARGARCARGOS()
        Dim r As Record = dgPerfilesUsuario.Table.CurrentRecord
        If r IsNot Nothing Then
            If dgPerfilesUsuario.Table.Records.Count > 0 Then
                Dim value As String = r.GetValue("IDUsuario").ToString()
                Dim user = UsuariosList.Where(Function(o) o.IDUsuario = value).Single


                If user IsNot Nothing Then
                    ListLotes.Items.Clear()

                    For Each i In user.UsuarioRol  '.OrderByDescending(Function(o) o.CustomLote.fechaentrada).ToList
                        Dim n As New ListViewItem(i.IDRol)
                        n.SubItems.Add(i.nombrePerfil)
                        n.SubItems.Add(i.tipoEF)

                        If ((i.estado) = "A") Then
                            n.SubItems.Add("ACTIVO")
                        Else
                            n.SubItems.Add("INACTIVO")
                        End If
                        ListLotes.Items.Add(n)
                    Next
                    ListLotes.Refresh()
                End If

            End If
        End If

    End Sub

    Public Sub cambiarEstado(idUsuario As Integer, tipo As String)
        Dim usuario As New Usuario
        Dim usuarioSA As New UsuarioSA
        Dim objUsusario As New Usuario
        Dim tipoEstado As String = String.Empty
        Try
            If (tipo = "A") Then
                tipoEstado = "C"
            ElseIf (tipo = "C") Then
                tipoEstado = "A"
            End If


            With usuario
                .IDUsuario = idUsuario
                .estado = tipoEstado
            End With
            usuarioSA.UpdateUsuarioXID(usuario)

        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True

        End Try
    End Sub


    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        'With frmCrearENtidades
        '    .CaptionLabels(0).Text = "Nuevo cliente"
        '    .strTipo = TIPO_ENTIDAD.CLIENTE
        '    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        'End With

        Cursor = Cursors.WaitCursor
        'If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.EDITAR_USUARIO_Botón___, AutorizacionRolList) Then

        If validarPermisos(PermisosDelSistema.MODULO_DE_USUARIOS_, AutorizacionRolList) = 1 Then



            If Not IsNothing(Me.dgPerfilesUsuario.Table.CurrentRecord) Then
                Dim f As New frmCrearPerfilesDelSistema(Me.dgPerfilesUsuario.Table.CurrentRecord.GetValue("IDRol"))
                f.strEstadoManipulacion = ENTITY_ACTIONS.UPDATE
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
            End If
        End If

        Cursor = Cursors.Default
    End Sub

    'Public Function validarPermisos(idaseg As Integer, lista As List(Of AutorizacionRol)) As Integer

    '    Dim consulta = (From i In lista
    '                    Where i.IDAsegurable = idaseg).Count

    '    Return consulta
    'End Function



    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Cursor = Cursors.WaitCursor
        'If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.ASIGNAR_CODIGO_VENDEDOR_Botón___, AutorizacionRolList) Then


        If validarPermisos(PermisosDelSistema.MODULO_DE_USUARIOS_, AutorizacionRolList) Then


            If Not IsNothing(Me.dgPerfilesUsuario.Table.CurrentRecord) Then
                Dim f As New frmAsignarCodigo()
                f.usuarioID = Me.dgPerfilesUsuario.Table.CurrentRecord.GetValue("IDUsuario")
                f.strEstadoManipulacion = ENTITY_ACTIONS.INSERT
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
                Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetClientes(Nothing)))
                Thread.Start()
            Else
                MsgBox("Debe seleccionar un documento", MsgBoxStyle.Critical, "Verificar documentos")
            End If
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Try
            'If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.ESTADO_USUARIO_Botón___, AutorizacionRolList) Then
            If validarPermisos(PermisosDelSistema.MODULO_DE_USUARIOS_, AutorizacionRolList) = 1 Then



                If Not IsNothing(dgPerfilesUsuario.Table.CurrentRecord) Then


                    If Me.dgPerfilesUsuario.Table.CurrentRecord.GetValue("NroDocumento") = "-" Then

                        MessageBox.Show("Admin no se puede cambiar de Estado seleccione otro")
                    Else

                        If MessageBox.Show("Desea cambiar de estado!", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            cambiarEstado(dgPerfilesUsuario.Table.CurrentRecord.GetValue("IDUsuario"), dgPerfilesUsuario.Table.CurrentRecord.GetValue("estado"))
                            Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetClientes(Nothing)))
                            Thread.Start()
                        End If
                    End If

                Else
                    MsgBox("Debe seleccionar un cliente", MsgBoxStyle.Critical, "Verificar documentos")
                End If
            Else
                MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MsgBox("No se pudo cambiar el estado", MsgBoxStyle.Critical, "Verificar documentos")
        End Try
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click

        Try
            ListLotes.Items.Clear()

            ProgressBar1.Visible = True
            ProgressBar1.Style = ProgressBarStyle.Marquee
            Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetClientes(Gempresas.IdEmpresaRuc)))
            Thread.Start()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        Cursor = Cursors.WaitCursor
        'If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.ASIGNAR_CODIGO_VENDEDOR_Botón___, AutorizacionRolList) Then

        If validarPermisos(PermisosDelSistema.MODULO_DE_USUARIOS_, AutorizacionRolList) Then

            If Not IsNothing(Me.dgPerfilesUsuario.Table.CurrentRecord) Then
                Dim f As New frmVerPassword(dgPerfilesUsuario.Table.CurrentRecord.GetValue("IDUsuario"))

                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
            Else
                MsgBox("Debe seleccionar un documento", MsgBoxStyle.Critical, "Verificar documentos")
            End If
        End If

        Cursor = Cursors.Default

    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        ListLotes.Items.Clear()
        Cursor = Cursors.WaitCursor
        'If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.ASIGNAR_CODIGO_VENDEDOR_Botón___, AutorizacionRolList) Then
        Dim usuarioListSA As New Helios.Seguridad.WCFService.ServiceAccess.UsuarioSA

        'If validarPermisos(PermisosDelSistema.MODULO_DE_USUARIOS_, AutorizacionRolList) Then


        If Not IsNothing(Me.dgPerfilesUsuario.Table.CurrentRecord) Then


                If Me.dgPerfilesUsuario.Table.CurrentRecord.GetValue("NroDocumento") = "-" Then

                    MessageBox.Show("Admin no se puede cambiar de Cargo seleccione otro")
                Else
                'CInt(Me.dgPerfilesUsuario.Table.CurrentRecord.GetValue("idCargo"))
                Dim f As New frmEditarCargo()
                f.lblidusuario.Text = Me.dgPerfilesUsuario.Table.CurrentRecord.GetValue("IDUsuario")
                    'f.strEstadoManipulacion = ENTITY_ACTIONS.INSERT
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()
                    Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetClientes(Nothing)))
                Thread.Start()

                UsuariosList = usuarioListSA.ListadoUsuariosv2()
                'CARGARCARGOS()
            End If


            Else
                MsgBox("Debe seleccionar un documento", MsgBoxStyle.Critical, "Verificar documentos")
            End If



        'End If

        Cursor = Cursors.Default
    End Sub



    Private Sub dgPerfilesUsuario_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgPerfilesUsuario.TableControlCellClick
        Dim r As Record = dgPerfilesUsuario.Table.CurrentRecord
        If r IsNot Nothing Then
            If dgPerfilesUsuario.Table.Records.Count > 0 Then
                Dim value As String = r.GetValue("IDUsuario").ToString()
                Dim user = UsuariosList.Where(Function(o) o.IDUsuario = value).Single


                If user IsNot Nothing Then
                    ListLotes.Items.Clear()

                    For Each i In user.UsuarioRol  '.OrderByDescending(Function(o) o.CustomLote.fechaentrada).ToList
                        Dim n As New ListViewItem(i.IDRol)
                        n.SubItems.Add(i.nombrePerfil)
                        n.SubItems.Add(i.tipoEF)

                        If ((i.estado) = "A") Then
                            n.SubItems.Add("ACTIVO")
                        Else
                            n.SubItems.Add("INACTIVO")
                        End If
                        ListLotes.Items.Add(n)
                    Next
                    ListLotes.Refresh()
                End If

            End If
        End If
    End Sub

    Private Sub dgPerfilesUsuario_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgPerfilesUsuario.QueryCellStyleInfo

        'If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.Column.Name = "cargo" AndAlso e.TableCellIdentity.DisplayElement.Kind = Syncfusion.Grouping.DisplayElementKind.Record Then

        '    Dim value As String = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("IDUsuario").ToString()
        '    Dim prod = UsuariosList.Where(Function(o) o.IDUsuario = value).SingleOrDefault
        '    If prod IsNot Nothing Then
        '        'Select Case prod.tipoExistencia
        '        '    Case TipoExistencia.ServicioGasto

        '        '    Case Else
        '        Dim listaEquivalencias = prod.UsuarioRol

        '        '   If value = "a" Then
        '        e.Style.CellType = "ComboBox"
        '        e.Style.DataSource = listaEquivalencias
        '        e.Style.DisplayMember = "nombrePerfil"
        '        e.Style.ValueMember = "IDRol"
        '        e.Style.DropDownStyle = GridDropDownStyle.Exclusive
        '        'ElseIf value = "b" Then
        '        '    e.Style.DataSource = ZipCodes
        '        '    e.Style.DisplayMember = "City"
        '        '    e.Style.ValueMember = "Class"
        '        'ElseIf value = "c" Then
        '        '    e.Style.DataSource = Shippers
        '        '    e.Style.DisplayMember = "Shipper ID"
        '        '    e.Style.ValueMember = "Company Name"
        '        'End If
        '        'End Select
        '    End If



        'End If




    End Sub

    Private Sub dgPerfilesUsuario_QueryAccessibilityHelp(sender As Object, e As QueryAccessibilityHelpEventArgs) Handles dgPerfilesUsuario.QueryAccessibilityHelp

    End Sub

    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click
        ListLotes.Items.Clear()
        Dim usuarioListSA As New Helios.Seguridad.WCFService.ServiceAccess.UsuarioSA

        Dim f As New frmCrearUsuariosDelSistema
        f.strEstadoManipulacion = General.ENTITY_ACTIONS.INSERT
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()

        UsuariosList = usuarioListSA.ListadoUsuariosv2()
    End Sub

    Private Sub ToolStripButton11_Click(sender As Object, e As EventArgs) Handles ToolStripButton11.Click
        Try
            If (Not IsNothing(dgPerfilesUsuario.Table.CurrentRecord)) Then
                If (ListLotes.SelectedItems.Count > 0) Then
                    Dim f As New FrmConfiguracionPerfilXUsuario(ListLotes.SelectedItems(0).SubItems(0).Text, dgPerfilesUsuario.Table.CurrentRecord.GetValue("IDUsuario"))
                    f.txtIdRol.Text = ListLotes.SelectedItems(0).SubItems(0).Text
                    f.txtRol.Text = ListLotes.SelectedItems(0).SubItems(1).Text
                    f.strEstadoManipulacion = ENTITY_ACTIONS.UPDATE
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog(Me)
                Else
                    MessageBox.Show("DEBE SELECCIONAR UN CARGO")
                End If
            Else
                MessageBox.Show("DEBE SELECCIONAR UN USUARIO")
                ListLotes.Items.Clear()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton10_Click(sender As Object, e As EventArgs) Handles ToolStripButton10.Click

        Cursor = Cursors.WaitCursor
        'If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.ASIGNAR_CODIGO_VENDEDOR_Botón___, AutorizacionRolList) Then
        ListLotes.Items.Clear()

        If validarPermisos(PermisosDelSistema.MODULO_DE_USUARIOS_, AutorizacionRolList) Then


            If Not IsNothing(Me.dgPerfilesUsuario.Table.CurrentRecord) Then
                Dim f As New frmEditarContraseña(CInt(Me.dgPerfilesUsuario.Table.CurrentRecord.GetValue("IDUsuario")))
                f.lblidusuario.Text = Me.dgPerfilesUsuario.Table.CurrentRecord.GetValue("IDUsuario")
                'f.strEstadoManipulacion = ENTITY_ACTIONS.INSERT
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
                Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetClientes(Nothing)))
                Thread.Start()
            Else
                MsgBox("Debe seleccionar un documento", MsgBoxStyle.Critical, "Verificar documentos")
            End If
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton12_Click(sender As Object, e As EventArgs) Handles ToolStripButton12.Click
        Try
            Dim usuarioListSA As New Helios.Seguridad.WCFService.ServiceAccess.UsuarioSA
            If (ListLotes.SelectedItems.Count > 0) Then
                If MessageBox.Show("Desea activar cargo?", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Dim usuarioRolsa As New UsuarioRolSA

                    Dim idRol As Integer = ListLotes.SelectedItems(0).SubItems(0).Text
                    Dim estado As String = String.Empty

                    usuarioRolsa.updateEstadoRoleUser(New UsuarioRol With {.IDRol = idRol,
                                                      .IDUsuario = dgPerfilesUsuario.Table.CurrentRecord.GetValue("IDUsuario"),
                                                      .estado = "A"})
                    UsuariosList = usuarioListSA.ListadoUsuariosv2()
                    CARGARCARGOS()
                End If
            Else
                MessageBox.Show("DEBE SELECCIONAR UN CARGO")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub ToolStripButton13_Click(sender As Object, e As EventArgs) Handles ToolStripButton13.Click
        Try
            Dim usuarioListSA As New Helios.Seguridad.WCFService.ServiceAccess.UsuarioSA
            If (ListLotes.SelectedItems.Count > 0) Then
                If MessageBox.Show("Desea inactivar cargo?", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Dim usuarioRolsa As New UsuarioRolSA

                    Dim idRol As Integer = ListLotes.SelectedItems(0).SubItems(0).Text
                    Dim estado As String = String.Empty

                    usuarioRolsa.updateEstadoRoleUser(New UsuarioRol With {.IDRol = idRol,
                                                      .IDUsuario = dgPerfilesUsuario.Table.CurrentRecord.GetValue("IDUsuario"),
                                                      .estado = "I"})
                End If
                UsuariosList = usuarioListSA.ListadoUsuariosv2()
                CARGARCARGOS()

            Else
                MessageBox.Show("DEBE SELECCIONAR UN CARGO")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub





#End Region
End Class
