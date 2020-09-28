Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Public Class frmNuevoProyectoGeneral
    Inherits frmMaster

    Public Property Manipulacion As String

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        CargarTrabajadores()
        txtInicio.Value = DateTime.Now
        txtFinaliza.Value = DateTime.Now
    End Sub

#Region "Métodos"
    Dim listaPersonas As New List(Of Persona)
    Public Sub CargarTrabajadores()
        Dim personaSA As New PersonaSA


        listaPersonas = personaSA.ObtenerPersona(New Persona With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                 .tipoPersona = "T"}).ToList


    End Sub

    Private Sub Grabar()
        Dim costo As New recursoCosto
        Dim proceso As New recursoCosto
        Dim recursoSA As New recursoCostoSA
        Dim lista As New List(Of cuentaplanContableEmpresa)

        costo = New recursoCosto
        costo.tipo = "HC"
        costo.subtipo = TipoCosto.Proyecto
        costo.status = StatusCosto.Proceso
        costo.nombreCosto = txtNuevoCosto.Text.Trim
        costo.codigo = "00"
        costo.detalle = Nothing
        costo.subdetalle = Nothing
        costo.inicio = txtInicio.Value
        costo.finaliza = txtFinaliza.Value
        costo.director = Val(txtDirector.Tag)
        costo.procesado = "N"
        costo.usuarioActualizacion = usuario.IDUsuario
        costo.fechaActualizacion = DateTime.Now
        recursoSA.GrabarCostoOne(costo)
        Close()
    End Sub
#End Region

    Private Sub frmNuevoProyectoGeneral_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Close()
    End Sub

    Private Sub popupControlContainer1_CloseUp(sender As Object, e As Syncfusion.Windows.Forms.PopupClosedEventArgs) Handles popupControlContainer1.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvPersona.SelectedItems.Count > 0 Then
                txtDirector.Text = lsvPersona.Text

                '  txtDirector.Clear()
                txtDirector.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                txtDirector.Tag = lsvPersona.SelectedValue
            End If
        End If
        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtDirector.Focus()
        End If
    End Sub

    Private Sub txtDirector_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDirector.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        Else
            Me.popupControlContainer1.Font = New Font("Segoe UI", 8)
            Me.popupControlContainer1.Size = New Size(271, 110)
            Me.popupControlContainer1.ParentControl = Me.txtDirector
            Me.popupControlContainer1.ShowPopup(Point.Empty)
            Dim consulta = (From n In listaPersonas _
                     Where n.nombreCompleto.StartsWith(txtDirector.Text)).ToList

            lsvPersona.DataSource = consulta
            lsvPersona.DisplayMember = "nombreCompleto"
            lsvPersona.ValueMember = "idPersona"
            'e.Handled = True
        End If

        '  If Not Me.pcLikeCategoria.IsShowing() Then

        '   End If

        '    If Not Me.pcLikeCategoria.IsShowing() Then
        If e.KeyCode = Keys.Down Then
            Me.popupControlContainer1.Font = New Font("Segoe UI", 8)
            Me.popupControlContainer1.Size = New Size(271, 110)
            Me.popupControlContainer1.ParentControl = Me.txtDirector
            Me.popupControlContainer1.ShowPopup(Point.Empty)
            lsvPersona.Focus()
        End If
        '   End If

        ' e.SuppressKeyPress = True
        If e.KeyCode = Keys.Escape Then
            If Me.popupControlContainer1.IsShowing() Then
                Me.popupControlContainer1.HidePopup(PopupCloseType.Canceled)
            End If
        End If
    End Sub

    Private Sub txtDirector_TextChanged(sender As Object, e As EventArgs) Handles txtDirector.TextChanged
        txtDirector.ForeColor = Color.Black
        txtDirector.Tag = Nothing
    End Sub

    Private Sub lsvPersona_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvPersona.MouseDoubleClick
        Me.popupControlContainer1.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub lsvPersona_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvPersona.SelectedIndexChanged

    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        With FrmNuevaPersona
            .StartPosition = FormStartPosition.CenterParent
            '.Label9.Visible = False
            .cboCuenta.Visible = False
            .ShowDialog()
            CargarTrabajadores()
        End With
    End Sub

    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        Me.Cursor = Cursors.WaitCursor

        If Not txtDirector.Text.Trim.Length > 0 Then

            MessageBox.Show("Ingrese el director del proyecto", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If
        If txtDirector.Text.Trim.Length > 0 Then
            If txtDirector.ForeColor = Color.Black Then
                MessageBox.Show("Verificar el ingreso correcto del director del proyecto", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtDirector.Select()
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
        End If

        If Manipulacion = ENTITY_ACTIONS.INSERT Then

            If txtNuevoCosto.Text.Trim.Length > 0 Then
                'If dgvProductosTerminados.Table.Records.Count > 0 Then
                Grabar()
                'Else
                '    MessageBox.Show("Debe ingresar al menos un producto terminado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                '    Me.Cursor = Cursors.Arrow
                '    Exit Sub
                'End If

            Else
                MessageBox.Show("Debe indicar el campo nombre del costo", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
            'Else
            '    MessageBox.Show("Debe ingresar al menos un proceso.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    TabControl1.SelectTab(1)
            '    Me.Cursor = Cursors.Arrow
            '    Exit Sub
            'End If


        Else
            '   Editar()
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub GradientPanel1_Paint(sender As Object, e As PaintEventArgs) Handles GradientPanel1.Paint

    End Sub
End Class