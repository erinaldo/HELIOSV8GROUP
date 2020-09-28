Imports Helios.Cont.Business.Entity
Imports Helios.General
'Imports Helios.Planilla.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Public Class frmPersonalExistente
    Public xManipulacion As String
#Region "Metodos"
    Public Sub GRabar()
        Dim PersonaSA As New PersonaSA
        Dim nPersona As New Helios.Cont.Business.Entity.Persona

        With nPersona
            .idPersona = txtNumDoc.Text.Trim
            .idEmpresa = Gempresas.IdEmpresaRuc
            .appat = txtAppat.Text.Trim
            .apmat = txtApmat.Text.Trim
            .nombres = txtNombres.Text.Trim
            .nombreCompleto = String.Concat(.appat, " ", .apmat, ", ", .nombres)
            .usuarioActualizacion = "NN"
            .fechaActualizacion = DateTime.Now
        End With
        PersonaSA.InsertPersona(nPersona)
        Me.lblEstado.Image = My.Resources.ok4
        Me.lblEstado.Text = "Trabajador registrado!"
        Timer1.Enabled = False
    End Sub

    Public Sub Editar()
        Dim PersonaSA As New PersonaSA
        Dim nPersona As New Helios.Cont.Business.Entity.Persona
        With nPersona
            .idPersona = txtNumDoc.Text.Trim
            .idEmpresa = Gempresas.IdEmpresaRuc
            .appat = txtAppat.Text.Trim
            .apmat = txtApmat.Text.Trim
            .nombres = txtNombres.Text.Trim
            .nombreCompleto = String.Concat(.appat, " ", .apmat, ", ", .nombres)
            .usuarioActualizacion = "NN"
            .fechaActualizacion = DateTime.Now
        End With
        PersonaSA.EditarPersona(nPersona)
        Me.lblEstado.Image = My.Resources.ok4
        Me.lblEstado.Text = "Persona modificada!"
        Timer1.Enabled = False
    End Sub

    Public Sub EliminarPersona()
        Dim PersonaSA As New PersonaSA
        Dim nPersona As New Helios.Cont.Business.Entity.Persona
        With nPersona
            .idPersona = txtNumDoc.Text.Trim
            .idEmpresa = Gempresas.IdEmpresaRuc
        End With
        PersonaSA.EliminarPersona(nPersona)
        Me.lblEstado.Image = My.Resources.ok4
        Me.lblEstado.Text = "Persona Eliminada!"

    End Sub

    Public Sub ObtenerTrabPorDoc(ByVal NumDoc As String)
        Dim personaSA As New PersonaSA
        Dim persona As New Business.Entity.Persona
        Try
            lsvPersonas.Items.Clear()
            persona = personaSA.ObtenerPersonaNumDoc(Gempresas.IdEmpresaRuc, NumDoc)
            If Not IsNothing(persona) Then
                With persona
                    If Not IsNothing(personaSA) Then
                        Dim n As New ListViewItem(.idPersona)
                        n.SubItems.Add(.nombreCompleto)
                        lsvPersonas.Items.Add(n)
                    End If
                End With
            Else
                lblEstado.Text = "El trabajador no existe, o no esta registrado!"
                lblEstado.Image = My.Resources.warning2
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub ObtenerTrabPorNombres(ByVal NumBres As String)
        Dim personaSA As New PersonaSA
        Try
            lsvPersonas.Items.Clear()
            For Each i In personaSA.ObtenerPersonaPorNombres(Gempresas.IdEmpresaRuc, NumBres)
                Dim n As New ListViewItem(i.idPersona)
                n.SubItems.Add(i.nombreCompleto)
                lsvPersonas.Items.Add(n)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

#End Region

    Private Sub ImprimirToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles ImprimirToolStripButton.Click
        Try
            Dim objPersona As New Personas(txtNumDoc.Text, txtNombres.Text, txtAppat.Text, txtApmat.Text)
            Select Case xManipulacion
                Case ENTITY_ACTIONS.INSERT
                    GRabar()
                Case ENTITY_ACTIONS.UPDATE
                    Editar()
            End Select
            ObtenerTrabPorDoc(txtNumDoc.Text.Trim)
            LimpiarCajas(gbx1)
        Catch ex As Exception
            '  MsgBox(ex.Message, MsgBoxStyle.Critical, "Atención")
            Me.lblEstado.Image = My.Resources.warning2
            Me.lblEstado.Text = ex.Message
            Me.textFilterNum.Text = txtNumDoc.Text
            LimpiarCajas(gbx1)
            ObtenerTrabPorDoc(textFilterNum.Text.Trim)
            '   textFilterNum_KeyDown(sender, e)
            'Timer1.Enabled = True
            'Timer1.Interval = 500
            'Timer1.Start()
        End Try

    End Sub

    Private Sub textFilterNum_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles textFilterNum.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            ObtenerTrabPorDoc(textFilterNum.Text.Trim)
        End If
    End Sub

    Private Sub textFilterNum_TextChanged(sender As System.Object, e As System.EventArgs) Handles textFilterNum.TextChanged

    End Sub

    Private Sub lsvPersonas_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lsvPersonas.MouseDoubleClick
        Me.Cursor = Cursors.WaitCursor
        If lsvPersonas.SelectedItems.Count > 0 Then
            Dim personaSA As New PersonaSA
            Dim n As New RecuperarCarteras()
            Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
            datos.Clear()
            With personaSA.ObtenerPersonaNumDoc(Gempresas.IdEmpresaRuc, lsvPersonas.SelectedItems(0).SubItems(0).Text)
                n.ID = lsvPersonas.SelectedItems(0).SubItems(0).Text
                n.NombreEntidad = .nombres
                n.Appat = .appat
                n.Apmat = .apmat
                datos.Add(n)
            End With
            Dispose()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lsvPersonas_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lsvPersonas.SelectedIndexChanged
        If lsvPersonas.SelectedItems.Count > 0 Then
            btnEdit.Enabled = True
        Else
            btnEdit.Enabled = False
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        Dispose()
    End Sub

    Private Sub NuevoToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles NuevoToolStripButton.Click
        LimpiarCajas(gbx1)
        ImprimirToolStripButton.Enabled = True
        xManipulacion = ENTITY_ACTIONS.INSERT
        gbx1.Enabled = True
        Me.lblEstado.Image = My.Resources.ok4
        Me.lblEstado.Text = "Trabajador: Ingreso interactivo."
        txtNumDoc.Enabled = True
        txtNombres.Select()
        txtNombres.Focus()
    End Sub

    Private Sub AyudaToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles AyudaToolStripButton.Click
        Select Case xManipulacion
            Case ENTITY_ACTIONS.INSERT
                ImprimirToolStripButton.Enabled = False
                gbx1.Enabled = False
                LimpiarCajas(gbx1)
                Me.lblEstado.Image = My.Resources.ok4
                Me.lblEstado.Text = "Trabajador: Ingreso interactivo."
            Case ENTITY_ACTIONS.UPDATE
                ImprimirToolStripButton.Enabled = False
                btnEdit.Enabled = False
                gbx1.Enabled = False
                LimpiarCajas(gbx1)
                Me.lblEstado.Image = My.Resources.ok4
                Me.lblEstado.Text = "Trabajador: Ingreso interactivo."
        End Select
    End Sub

    Private Sub btnEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnEdit.Click
        Dim personaSA As New PersonaSA
        ImprimirToolStripButton.Enabled = True
        LimpiarCajas(gbx1)
        xManipulacion = ENTITY_ACTIONS.UPDATE
        gbx1.Enabled = True
        Me.lblEstado.Image = My.Resources.ok4
        Me.lblEstado.Text = "Trabajador: Edición interactiva."
        With personaSA.ObtenerPersonaNumDoc(Gempresas.IdEmpresaRuc, lsvPersonas.SelectedItems(0).SubItems(0).Text)
            txtNumDoc.Enabled = False
            txtAppat.Text = .appat
            txtApmat.Text = .apmat
            txtNombres.Text = .nombres
            txtNumDoc.Text = .idPersona
        End With
       
    End Sub

    Private Sub textFilterNombres_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles textFilterNombres.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            ObtenerTrabPorNombres(textFilterNombres.Text.Trim)
        End If
    End Sub

    Private Sub textFilterNombres_TextChanged(sender As System.Object, e As System.EventArgs) Handles textFilterNombres.TextChanged

    End Sub

    Private Sub txtNombres_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtNombres.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtAppat.Focus()
            txtAppat.Select(0, txtAppat.Text.Length)
        End If
    End Sub

    Private Sub txtNombres_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNombres.TextChanged

    End Sub

    Private Sub txtAppat_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtAppat.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtApmat.Focus()
            txtApmat.Select(0, txtApmat.Text.Length)
        End If
    End Sub

    Private Sub txtAppat_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtAppat.TextChanged

    End Sub

    Private Sub txtApmat_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtApmat.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtNumDoc.Focus()
            txtNumDoc.Select(0, txtNumDoc.Text.Length)
        End If
    End Sub

    Private Sub txtApmat_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtApmat.TextChanged

    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Static parpadear As Boolean

        If Not parpadear Then
            lblEstado.ForeColor = lblEstado.BackColor
        Else
            lblEstado.ForeColor = SystemColors.WindowText
        End If

        parpadear = Not parpadear
    End Sub
End Class