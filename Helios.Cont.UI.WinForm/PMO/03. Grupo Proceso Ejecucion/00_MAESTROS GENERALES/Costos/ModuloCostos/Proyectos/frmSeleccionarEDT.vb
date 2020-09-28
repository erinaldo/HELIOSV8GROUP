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
Public Class frmSeleccionarEDT
    Inherits frmMaster

    Public Sub New(idproyectoGeneral As Integer)

        ' This call is required by the designer.
        InitializeComponent()
        GetProyectosGeneralesCMB()
        ' Add any initialization after the InitializeComponent() call.
        cboProyectoGeneral.SelectedValue = idproyectoGeneral
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        GetProyectosGeneralesCMB()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

#Region "Métodos"
    Sub GetEntregables(idSubproyecto As Integer)
        Dim costoSA As New recursoCostoSA
        Dim costo As New List(Of recursoCosto)

        '     If Not IsNothing(cboSubProyecto.SelectedValue) Then

        costo = costoSA.GetOrdenesDeProduccionInfo(New recursoCosto With {.idCosto = idSubproyecto, .status = StatusProductosTerminados.Pendiente})
        cboEntregable.DisplayMember = "nombreCosto"
        cboEntregable.ValueMember = "idCosto"
        cboEntregable.DataSource = costo
        '   End If
    End Sub

    'Sub ComboProcesos1(intIdCostoPadre As Integer)
    '    Dim costoSA As New recursoCostoSA
    '    ' ()
    '    cboEdt.DataSource = costoSA.GetProcesosByCosto(New recursoCosto With {.idCosto = intIdCostoPadre})
    '    'cboProceso.DataSource = costoSA.GetActividadProcesoByProyecto(New recursoCosto With {.idCosto = intIdCostoPadre})
    '    cboEdt.ValueMember = "idCosto"
    '    cboEdt.DisplayMember = "nombreCosto"
    'End Sub

    Private Sub GetProyectosGeneralesCMB()
        Dim costoSA As New recursoCostoSA
        cboProyectoGeneral.DisplayMember = "nombreCosto"
        cboProyectoGeneral.ValueMember = "idCosto"
        cboProyectoGeneral.DataSource = costoSA.GetListaRecursosXtipo(New recursoCosto With {.tipo = "HC", .subtipo = "PY"})
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
#End Region

    Private Sub frmSeleccionarEDT_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click

        If Not cboSubProyecto.Text.Trim.Length > 0 Then
            MessageBox.Show("Debe identificar el sub proyecto!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Not cboEntregable.Text.Trim.Length > 0 Then
            MessageBox.Show("Debe identificar el entregable!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Not cboElemento.Text.Trim.Length > 0 Then
            MessageBox.Show("Debe identificar el elemento del costo!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If


        Dim obj As New SeleccionCosto
        obj.idProyectoGeneral = cboProyectoGeneral.SelectedValue
        obj.ProyectoGeneral = cboProyectoGeneral.Text
        obj.idSubProyecto = cboSubProyecto.SelectedValue
        obj.SubProyecto = cboSubProyecto.Text
        obj.idEntregable = cboEntregable.SelectedValue
        obj.Entregable = cboEntregable.Text
        'obj.TipoCosto = txtTipoCosto.Text
        obj.TipoCosto = txtTipoProy.Text
        obj.idElemento = cboElemento.SelectedValue
        obj.ElementoCosto = cboElemento.Text
        obj.Abreviatura = "HC"


        Me.Tag = obj
        Close()
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Me.Cursor = Cursors.WaitCursor
        GetSubProyectos(cboProyectoGeneral.SelectedValue)
        cboSubProyecto.SelectedIndex = -1
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboSubProyecto_Click(sender As Object, e As EventArgs) Handles cboSubProyecto.Click

    End Sub

    Private Sub cboElemento_Click(sender As Object, e As EventArgs) Handles cboElemento.Click

    End Sub

    Private Sub cboSubProyecto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSubProyecto.SelectedIndexChanged
        Dim costoSA As New recursoCostoSA
        cboElemento.DataSource = Nothing
        'cboEdt.DataSource = Nothing
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

    Private Sub cboSubProyecto_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboSubProyecto.SelectedValueChanged
        'Me.Cursor = Cursors.WaitCursor

        'Dim codSubProyecto = cboSubProyecto.SelectedValue
        'If Not IsNothing(codSubProyecto) Then
        '    If IsNumeric(codSubProyecto) Then
        '        GetEntregables(codSubProyecto)
        '    End If
        'End If
        'cboEntregable.SelectedIndex = -1
        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboProyectoGeneral_Click(sender As Object, e As EventArgs) Handles cboProyectoGeneral.Click

    End Sub

    Private Sub cboEntregable_Click(sender As Object, e As EventArgs) Handles cboEntregable.Click

    End Sub

    Private Sub cboEntregable_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEntregable.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        Dim costoSA As New recursoCostoSA
        'Dim tip As String
        If cboEntregable.SelectedIndex > -1 Then

            'elemento
            Dim recursoSA As New recursoCostoSA

            Dim codValue = cboEntregable.SelectedValue

            If IsNumeric(codValue) Then
                codValue = Val(codValue)
                cboElemento.Visible = True

                cboElemento.DisplayMember = "nombreCosto"
                cboElemento.ValueMember = "idCosto"
                cboElemento.DataSource = recursoSA.GetElementosCostoByCosto(New recursoCosto With {.idCosto = codValue})



            End If


            cboElemento.SelectedIndex = -1

            '''''cargar
            txtTipoProy.Text = costoSA.GetCostoById(New recursoCosto With {.idCosto = cboEntregable.SelectedValue}).subtipo
            'tip = costoSA.GetCostoById(New recursoCosto With {.idCosto = cboEntregable.SelectedValue}).subtipo

            'If tip = TipoCosto.CONTRATOS_DE_CONSTRUCCION Then
            '    txtTipoProy.Text = "HC - CONSTRUC. Y SIMILARES"
            'ElseIf tip = TipoCosto.CONTRATOS_DE_SERVICIOS_POR_VALORIZACIONES_O_SIMILARES Then
            '    txtTipoProy.Text = "HC - SERV. VARIOS"
            'ElseIf tip = TipoCosto.CONTRATOS_DE_ARRENDAMIENTOS Then
            '    txtTipoProy.Text = "HC - ARRENDAMIENTO"
            'ElseIf tip = TipoCosto.OP_CONTINUA_DE_BIENES Then
            '    txtTipoProy.Text = "HC - PRODUCCION"
            'ElseIf tip = TipoCosto.OP_DE_BIENES_CONTROL_INDEPENDIENTE Then
            '    txtTipoProy.Text = "OP. DE BIENES - CONTROL INDEPENDIENTE"
            'ElseIf tip = TipoCosto.OP_CONTINUA_DE_SERVICIOS Then
            '    txtTipoProy.Text = "HC - SERV. EDUCAT"
            'ElseIf tip = TipoCosto.OP_DE_SERVICIOS_CONTROL_INDEPENDIENTE Then
            '    txtTipoProy.Text = "HC - SERV. TRANSP"
            'ElseIf tip = TipoCosto.OP_DE_SERVICIOS_CONSUMO_INMEDIATO_DE_BIENES Then
            '    txtTipoProy.Text = "HC - CONSUMO INMEDIATO"
            'ElseIf tip = TipoCosto.ActivoFijo Then
            '    txtTipoProy.Text = "ACTIVO FIJO"
            'ElseIf tip = TipoCosto.GastoAdministrativo Then
            '    txtTipoProy.Text = "GASTO ADMINISTRATIVO"
            'ElseIf tip = TipoCosto.GastoVentas Then
            '    txtTipoProy.Text = "GASTO DE VENTAS"
            'ElseIf tip = TipoCosto.GastoFinanciero Then
            '    txtTipoProy.Text = "GASTO FINANCIERO"
            'ElseIf tip = TipoCosto.HC_Mercaderia Then
            '    txtTipoProy.Text = "HC - MERCADERIA"
            'Else
            '    txtTipoProy.Text = ""
            'End If
        Else











        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cboEdt_Click(sender As Object, e As EventArgs)

    End Sub
End Class