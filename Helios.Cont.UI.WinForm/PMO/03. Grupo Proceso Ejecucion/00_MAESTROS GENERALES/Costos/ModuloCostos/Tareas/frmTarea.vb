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
Public Class frmTarea
    Inherits frmMaster
    Public Property Manipulacion As String
    Public Property idProyecto As Integer

    Dim listaPersonas As New List(Of Persona)

    Public Sub New()
      
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        CargarTrabajadores()

    End Sub

    Sub LimitarFechaPadre(intIdProyecto As Integer)
        Dim costoSA As New recursoCostoSA
        Dim costo As New recursoCosto
        Dim personaSA As New PersonaSA

        costo = costoSA.GetCostoById(New recursoCosto With {.idCosto = intIdProyecto})
        If Not IsNothing(costo) Then
            txtInicio.MaxValue = costo.finaliza
            txtFinaliza.MaxValue = costo.finaliza

            txtInicio.MinValue = costo.inicio
            txtFinaliza.MinValue = costo.inicio
            txtFinaliza.Value = costo.finaliza

            With personaSA.ObtenerPersonaNumDoc(Gempresas.IdEmpresaRuc, costo.director)
                txtDirector.Tag = .idPersona
                txtDirector.Text = .nombreCompleto
                txtDirector.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            End With
        End If
        
    End Sub

    Public Sub New(idCosto As Integer, Proyecto As Integer)
        Dim costoSA As New recursoCostoSA
        Dim costo As New recursoCosto
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        CargarTrabajadores()
        UbicarCosto(idCosto)
        costo = costoSA.GetCostoById(New recursoCosto With {.idCosto = Proyecto})
        txtInicio.MaxValue = costo.finaliza
        txtFinaliza.MaxValue = costo.finaliza

        txtInicio.MinValue = costo.inicio
        txtFinaliza.MinValue = costo.inicio
    End Sub

    Public Sub UbicarCosto(idCosto As Integer)
        Dim costoSA As New recursoCostoSA
        Dim costo As New recursoCosto
        Dim persona As New Persona
        Dim personaSA As New PersonaSA

        costo = costoSA.GetCostoById(New recursoCosto With {.idCosto = idCosto})
        If Not IsNothing(costo) Then
            idProyecto = costo.idpadre
            txtdetalle.Text = costo.detalle
            txtNuevoCosto.Text = costo.nombreCosto
            txtNuevoCosto.Tag = costo.idCosto
            txtDirector.Tag = costo.director

            persona = personaSA.ObtenerPersonaNumDoc(Gempresas.IdEmpresaRuc, costo.director)

            If Not IsNothing(persona) Then
                txtDirector.Text = persona.nombreCompleto
                txtDirector.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                txtDirector.Tag = persona.idPersona
            End If
            txtInicio.Value = costo.inicio
            txtFinaliza.Value = costo.finaliza

        End If

    End Sub

    Public Sub CargarTrabajadores()
        Dim personaSA As New PersonaSA


        listaPersonas = personaSA.ObtenerPersona(New Persona With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                 .tipoPersona = "T"}).ToList


    End Sub

    Private Sub GrabarTarea()
        Dim costo As New recursoCosto
        Dim recursoSA As New recursoCostoSA

        costo = New recursoCosto
        costo.idpadre = idProyecto
        costo.tipo = "TRS"
        costo.subtipo = "TRS"
        costo.status = StatusCosto.Avance_Obra_Cartera
        costo.nombreCosto = txtNuevoCosto.Text.Trim
        costo.codigo = txtCodigo.Text.Trim
        costo.detalle = txtdetalle.Text.Trim
        costo.subdetalle = Nothing
        costo.inicio = txtInicio.Value
        costo.finaliza = txtFinaliza.Value
        costo.director = Val(txtDirector.Tag)
        costo.procesado = "N"
        costo.usuarioActualizacion = usuario.IDUsuario
        costo.fechaActualizacion = DateTime.Now

        recursoSA.GrabarTask(costo)
        Dispose()
    End Sub

    Private Sub EditarTarea()
        Dim costo As New recursoCosto
        Dim recursoSA As New recursoCostoSA

        costo = New recursoCosto
        costo.idCosto = txtNuevoCosto.Tag
        costo.idpadre = idProyecto
        costo.tipo = "TRS"
        costo.subtipo = "TRS"
        costo.status = StatusCosto.Proceso
        costo.nombreCosto = txtNuevoCosto.Text.Trim
        costo.codigo = txtCodigo.Text.Trim
        costo.detalle = txtdetalle.Text.Trim
        costo.subdetalle = Nothing
        costo.inicio = txtInicio.Value
        costo.finaliza = txtFinaliza.Value
        costo.director = Val(txtDirector.Tag)
        costo.procesado = "N"
        costo.usuarioActualizacion = usuario.IDUsuario
        costo.fechaActualizacion = DateTime.Now

        recursoSA.EditarCostoTarea(costo)
        Dispose()
    End Sub

    Private Sub frmTarea_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmTarea_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtDirector_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDirector.KeyDown, txtInicio.KeyDown
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
        'txtDirector.Tag = Nothing
    End Sub

    Private Sub popupControlContainer1_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles popupControlContainer1.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvPersona.SelectedItems.Count > 0 Then
                txtDirector.Text = lsvPersona.Text
                txtDirector.Tag = lsvPersona.SelectedValue
                '  txtDirector.Clear()
                txtDirector.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            End If
        End If
        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtDirector.Focus()
        End If
    End Sub

    Private Sub lsvPersona_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvPersona.MouseDoubleClick
        Me.popupControlContainer1.HidePopup(PopupCloseType.Done)
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

        If txtFinaliza.Value < txtInicio.Value Then
            MessageBox.Show("Verificar el ingreso correcto de la fecha de inicio y finalización" & vbCrLf & _
                            "La fecha de vcto. no debe ser menor a la de inicio.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtDirector.Select()
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If

        If Manipulacion = ENTITY_ACTIONS.INSERT Then
            If txtNuevoCosto.Text.Trim.Length > 0 Then
                GrabarTarea()

            Else
                MessageBox.Show("Debe indicar el campo nombre del costo", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If

        Else
            If txtNuevoCosto.Text.Trim.Length > 0 Then
                EditarTarea()

            Else
                MessageBox.Show("Debe indicar el campo nombre del costo", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Dispose()
    End Sub

    Private Sub txtNuevoCosto_TextChanged(sender As Object, e As EventArgs) Handles txtNuevoCosto.TextChanged

    End Sub

    Private Sub txtFinaliza_ValueChanged(sender As Object, e As EventArgs)

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

    Private Sub txtInicio_ValueChanged(sender As Object, e As EventArgs) Handles txtInicio.ValueChanged
        If IsDate(txtInicio.Value) Then

        End If
    End Sub

    Private Sub txtFinaliza_ValueChanged_1(sender As Object, e As EventArgs) Handles txtFinaliza.ValueChanged
        If IsDate(txtFinaliza.Value) Then

        End If
    End Sub
End Class