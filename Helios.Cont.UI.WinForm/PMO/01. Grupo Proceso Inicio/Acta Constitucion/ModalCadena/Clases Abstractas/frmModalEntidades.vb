Imports Helios.Cont.Business.Entity
Imports Helios.General

Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmModalEntidades



    'Structure TIPO_ENTIDAD
    '    Const PROVEEDOR = "PR"
    '    Const CLIENTE = "CL"
    'End Structure

    Enum TipoBusqueda
        PorNombres = 0
        PorNroDoc = 1
    End Enum

#Region "Métodos"


    Public Sub BuscarEntidades(ByVal opcion As Byte)
        ' Dim objService = HeliosSEProxy.CrearProxyHELIOS()
        Dim entidadSA As New entidadSA
        Dim objLista As New List(Of entidad)
        Try
            If opcion = TipoBusqueda.PorNombres Then
                objLista = entidadSA.ListarEntidadesPorNombres(lblTipo.Text, Gempresas.IdEmpresaRuc, txtBusqueda.Text.Trim)
            ElseIf opcion = TipoBusqueda.PorNroDoc Then
                objLista = entidadSA.ListarEntidadesPorRuc(lblTipo.Text, Gempresas.IdEmpresaRuc, txtBusqueda.Text.Trim)
            End If
            lsvEntidades.Items.Clear()
            lsvEntidades.Columns.Clear()
            lsvEntidades.Columns.Add("ID", 0)
            lsvEntidades.Columns.Add("Cuenta", 70)
            lsvEntidades.Columns.Add("Nombres", 200)
            lsvEntidades.Columns.Add("t/Doc.", 0)
            lsvEntidades.Columns.Add("Nro.", 80)
            lsvEntidades.Columns.Add("TIPO", 0)

            For Each i As entidad In objLista
                Dim n As New ListViewItem(i.idEntidad)
                n.SubItems.Add(i.cuentaAsiento)
                n.SubItems.Add(i.nombreCompleto)
                n.SubItems.Add(i.tipoDoc)
                n.SubItems.Add(i.nrodoc)
                n.SubItems.Add(i.tipoPersona)
                lsvEntidades.Items.Add(n)
            Next
            If lsvEntidades.Items.Count > 0 Then
                lsvEntidades.Items(0).Selected = True
                lsvEntidades.Items(0).Focused = True
                lsvEntidades.FocusedItem.EnsureVisible()
            End If
           
        Catch ex As Exception
            MsgBox("No se pudo cargar la información requerida.!" & vbCrLf & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
#End Region

    Private Sub frmModalEntidades_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmModalEntidades_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        txtBusqueda.Select()
    End Sub

    Private Sub txtBusqueda_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtBusqueda.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            BuscarEntidades(IIf(rbNum.Checked = True, TipoBusqueda.PorNroDoc, TipoBusqueda.PorNombres))
            lsvEntidades.Focus()
        End If
    End Sub

    Private Sub txtBusqueda_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtBusqueda.TextChanged

    End Sub

    Private Sub lsvEntidades_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles lsvEntidades.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If lsvEntidades.SelectedItems.Count > 0 Then
                Dim n As New RecuperarCarteras()
                Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
                datos.Clear()
                n.ID = lsvEntidades.SelectedItems(0).SubItems(0).Text
                n.NroDoc = lsvEntidades.SelectedItems(0).SubItems(4).Text
                n.NombreEntidad = lsvEntidades.SelectedItems(0).SubItems(2).Text
                n.Cuenta = lsvEntidades.SelectedItems(0).SubItems(1).Text
                datos.Add(n)
                Dispose()
            End If
        End If
    End Sub

    Private Sub lsvEntidades_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lsvEntidades.MouseDoubleClick
        If lsvEntidades.SelectedItems.Count > 0 Then
            Dim n As New RecuperarCarteras()
            Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
            datos.Clear()
            n.ID = lsvEntidades.SelectedItems(0).SubItems(0).Text
            n.NroDoc = lsvEntidades.SelectedItems(0).SubItems(4).Text
            n.NombreEntidad = lsvEntidades.SelectedItems(0).SubItems(2).Text
            n.Cuenta = lsvEntidades.SelectedItems(0).SubItems(1).Text
            n.Appat = lsvEntidades.SelectedItems(0).SubItems(2).Text
            datos.Add(n)
            Dispose()
        End If
    End Sub

    Private Sub lsvEntidades_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lsvEntidades.SelectedIndexChanged

    End Sub

    Private Sub NuevoToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles NuevoToolStripButton.Click
        '  Dim valstr As String = Nothing

        If lblTipo.Text = TIPO_ENTIDAD.PERSONAL_PLANILLA Then
            'With frmgestionAccionista
            '    .CargarCombos()
            '    .intManipulacion = Manipulacion.Nuevo
            '    .cEntidad = TIPO_ENTIDAD.PERSONAL_PLANILLA
            '    .lblEntidad.Text = "Registro del Personal"
            '    .Text = "Personal: Ingreso Interactivo."
            '    .gbxCuentas.Visible = False
            '    .StartPosition = FormStartPosition.CenterParent
            '    .ShowDialog()
            'End With
        Else
            With frmDetalleCliente
                .StartPosition = FormStartPosition.CenterParent
                If lblTipo.Text = TIPO_ENTIDAD.PROVEEDOR Then
                    .xtipoEntidad = TIPO_ENTIDAD.PROVEEDOR
                    .Text = "Proveedores: Ingreso Interactivo."
                    .rb42.Text = "42"
                    .rb43.Text = "43"
                    .txtSiglas.Text = TIPO_ENTIDAD.PROVEEDOR
                ElseIf lblTipo.Text = TIPO_ENTIDAD.CLIENTE Then
                    .xtipoEntidad = TIPO_ENTIDAD.CLIENTE
                    .Text = "Clientes: Ingreso Interactivo."
                    .rb42.Text = "12"
                    .rb43.Text = "13"
                    .txtSiglas.Text = TIPO_ENTIDAD.CLIENTE
                End If
                .txtSiglas.ReadOnly = True
                .txtCodigoCliente.ReadOnly = True
                .txtRazon.Focus()
                .CargarCombos()
                .cboDocumento.SelectedValue = 6
                .rb42.Checked = True
                .Manipulacionx = ENTITY_ACTIONS.INSERT
                .ShowDialog()
                BuscarEntidades(IIf(rbNum.Checked = True, TipoBusqueda.PorNroDoc, TipoBusqueda.PorNombres))
            End With
        End If


    End Sub

    Private Sub AbrirToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles AbrirToolStripButton.Click
        If lsvEntidades.SelectedItems.Count > 0 Then

            If lblTipo.Text = TIPO_ENTIDAD.PERSONAL_PLANILLA Then
                'With frmgestionAccionista
                '    .CargarCombos()
                '    .UbicarEntidad(TIPO_ENTIDAD.PERSONAL_PLANILLA, lsvEntidades.SelectedItems(0).SubItems(0).Text, CEmpresa)
                '    .intManipulacion = Manipulacion.Editar
                '    .cEntidad = TIPO_ENTIDAD.PERSONAL_PLANILLA
                '    .lblEntidad.Text = "Registro del Personal"
                '    .Text = "Personal: Ingreso Interactivo."
                '    .gbxCuentas.Visible = False
                '    .StartPosition = FormStartPosition.CenterParent
                '    .ShowDialog()
                'End With
            Else
                With frmDetalleCliente
                    .StartPosition = FormStartPosition.CenterParent
                    If lblTipo.Text = TIPO_ENTIDAD.PROVEEDOR Then
                        .xtipoEntidad = TIPO_ENTIDAD.PROVEEDOR
                        .Text = "Proveedores: Ingreso Interactivo."
                        .rb42.Text = "42"
                        .rb43.Text = "43"
                        .txtSiglas.Text = TIPO_ENTIDAD.PROVEEDOR
                    ElseIf lblTipo.Text = TIPO_ENTIDAD.CLIENTE Then
                        .xtipoEntidad = TIPO_ENTIDAD.CLIENTE
                        .Text = "Clientes: Ingreso Interactivo."
                        .rb42.Text = "12"
                        .rb43.Text = "13"
                        .txtSiglas.Text = TIPO_ENTIDAD.CLIENTE
                    End If
                    .txtSiglas.ReadOnly = True
                    .txtCodigoCliente.ReadOnly = True
                    .txtRazon.Focus()
                    .CargarCombos()
                    .rb42.Checked = True
                    .UbicarEntidad(lsvEntidades.SelectedItems(0).SubItems(0).Text)
                    .Manipulacionx = ENTITY_ACTIONS.UPDATE
                    .ShowDialog()
                    BuscarEntidades(IIf(rbNum.Checked = True, TipoBusqueda.PorNroDoc, TipoBusqueda.PorNombres))
                End With
            End If


        Else
            MsgBox("Seleccione una entidad(fila) para realizar la operación.", MsgBoxStyle.Information, "Atención!")
        End If
    End Sub

    Private Sub rbNum_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbNum.CheckedChanged

    End Sub

    Private Sub GuardarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles GuardarToolStripButton.Click

    End Sub
End Class