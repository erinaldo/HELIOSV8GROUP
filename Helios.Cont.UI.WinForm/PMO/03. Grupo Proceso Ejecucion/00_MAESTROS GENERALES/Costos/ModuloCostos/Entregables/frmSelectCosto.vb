Imports Syncfusion.Windows.Forms.Tools
Imports Helios.Cont.Business.Entity
Imports Helios.General
'Imports Helios.Planilla.Business.Entity

Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
'Imports Helios.Planilla.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Imports Syncfusion.GridHelperClasses
Public Class frmSelectCosto
#Region "Constructor"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        GetProyectosGeneralesCMB()
        ' Add any initialization after the InitializeComponent() call.
        'cboProyectoGeneral.SelectedValue = idproyectoGeneral
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
#End Region


#Region "Metodos"

    Sub GetEntregables(idSubproyecto As Integer)
        Dim costoSA As New recursoCostoSA
        Dim costo As New List(Of recursoCosto)

        '     If Not IsNothing(cboSubProyecto.SelectedValue) Then

        costo = costoSA.GetOrdenesDeProduccionInfo(New recursoCosto With {.idCosto = idSubproyecto, .status = StatusProductosTerminados.Pendiente})
        cboEntregable.DisplayMember = "nombreCosto"
        cboEntregable.ValueMember = "idCosto"
        cboEntregable.DataSource = costo

        cboEntregable.SelectedIndex = -1
        '   End If
    End Sub

    Public Sub GetSubProyectos(idProyectoGeneral As Integer)
        Dim recursoSA As New recursoCostoSA
        Dim lista As New List(Of recursoCosto)
        lista = recursoSA.GetListaSubProyectos(New recursoCosto With {.tipo = "HC", .idpadre = idProyectoGeneral, .status = StatusProductosTerminados.Pendiente})
        'lista = recursoSA.GetListaProtectosByProyGeneral(New recursoCosto With {.tipo = "HC", .idpadre = idProyectoGeneral})
        Dim query = lista.Where(Function(o) o.subtipo <> TipoCosto.HC_Mercaderia).ToList
        cboSubProyecto.DataSource = query
        cboSubProyecto.DisplayMember = "nombreCosto"
        cboSubProyecto.ValueMember = "idCosto"
    End Sub

    Private Sub GetProyectosGeneralesCMB()
        Dim costoSA As New recursoCostoSA
        cboProyectoGeneral.DisplayMember = "nombreCosto"
        cboProyectoGeneral.ValueMember = "idCosto"
        cboProyectoGeneral.DataSource = costoSA.GetListaRecursosXtipo(New recursoCosto With {.tipo = "HC", .subtipo = "PY"})
    End Sub
#End Region

    Private Sub frmSelectCosto_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cboProyectoGeneral_Click(sender As Object, e As EventArgs) Handles cboProyectoGeneral.Click

    End Sub

    Private Sub cboSubProyecto_Click(sender As Object, e As EventArgs) Handles cboSubProyecto.Click

    End Sub

    Private Sub cboSubProyecto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSubProyecto.SelectedIndexChanged
        Dim costoSA As New recursoCostoSA

        If cboSubProyecto.SelectedIndex > -1 Then
            '   If rbHojaCosto.Checked = True Then
            Dim recursoSA As New recursoCostoSA

            Dim codValue = cboSubProyecto.SelectedValue


            If IsNumeric(codValue) Then
                'codValue = Val(codValue)
                'txtTipoCosto.Text = costoSA.GetCostoById(New recursoCosto With {.idCosto = codValue}).subtipo

                'cboElemento.Visible = True

                'cboElemento.DisplayMember = "nombreCosto"
                'cboElemento.ValueMember = "idCosto"
                'cboElemento.DataSource = recursoSA.GetElementosCostoByCosto(New recursoCosto With {.idCosto = codValue})

                GetEntregables(codValue)




            End If
        End If
        'cboElemento.SelectedIndex = -1
    End Sub

    Private Sub cboEntregable_Click(sender As Object, e As EventArgs) Handles cboEntregable.Click

    End Sub

    Private Sub cboEntregable_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEntregable.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        Dim costoSA As New recursoCostoSA

        Dim DetalleEntregable As New recursoCosto
        If cboEntregable.SelectedIndex > -1 Then

            'elemento
            Dim recursoSA As New recursoCostoSA



            '''''cargar


            DetalleEntregable = costoSA.GetCostoById(New recursoCosto With {.idCosto = cboEntregable.SelectedValue})
            ' txtTipoProy.Text = costoSA.GetCostoById(New recursoCosto With {.idCosto = cboEntregable.SelectedValue}).subtipo


            txtTipoProy.Text = DetalleEntregable.subtipo

            Select Case DetalleEntregable.estado

                Case "PRO"
                    txtEstado.Text = "EN PROCESO"
                Case "SUS"
                    txtEstado.Text = "SUSPENDIDO"
                Case "EJE"
                    txtEstado.Text = "EJECUTADO"

            End Select
            'txtEstado.Text = DetalleEntregable.estado



        Else

        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click


        If Not txtEstado.Text = "EN PROCESO" Then
            MessageBox.Show("El Entregable debe estar en proceso!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Not cboSubProyecto.Text.Trim.Length > 0 Then
            MessageBox.Show("Debe identificar el sub proyecto!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Not cboEntregable.Text.Trim.Length > 0 Then
            MessageBox.Show("Debe identificar el entregable!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If




        Dim obj As New SeleccionCosto
        'obj.idProyectoGeneral = cboProyectoGeneral.SelectedValue
        'obj.ProyectoGeneral = cboProyectoGeneral.Text
        'obj.idSubProyecto = cboSubProyecto.SelectedValue
        'obj.SubProyecto = cboSubProyecto.Text
        obj.idEntregable = cboEntregable.SelectedValue
        obj.Entregable = cboEntregable.Text
        ''obj.TipoCosto = txtTipoCosto.Text
        'obj.TipoCosto = txtTipoProy.Text
        'obj.idElemento = cboElemento.SelectedValue
        'obj.ElementoCosto = cboElemento.Text
        'obj.Abreviatura = "HC"
        'obj.fechaTrabajo = txtFechaTrabajo.Value


        Me.Tag = obj
        Close()
    End Sub

    Private Sub cboProyectoGeneral_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboProyectoGeneral.SelectedIndexChanged
        Me.cboEntregable.DataSource = Nothing
        Me.cboSubProyecto.DataSource = Nothing
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Cursor = Cursors.WaitCursor
        GetSubProyectos(cboProyectoGeneral.SelectedValue)
        cboSubProyecto.SelectedIndex = -1
        Me.Cursor = Cursors.Arrow
    End Sub
End Class