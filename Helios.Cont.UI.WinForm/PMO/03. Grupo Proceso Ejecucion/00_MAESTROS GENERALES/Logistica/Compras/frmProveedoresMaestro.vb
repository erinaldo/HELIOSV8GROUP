Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General.Constantes
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.GridHelperClasses

Public Class frmProveedoresMaestro

#Region "Attributes"
    Dim entidad As New entidadSA
    Dim documentoVentasSA As New documentoVentaAbarrotesSA
    Dim SumVentaProveedor As Integer = 0
    Dim selectionColl As New Hashtable()
    Dim hoveredIndex As Integer = 0
    Dim UsuarioEstadoCaja As New UsuarioEstadoCaja
    Dim objEntidad As New entidad
    Dim filter As New GridExcelFilter()
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGrid(dgvProveedor)
        ListaProveedores()
    End Sub
#End Region

#Region "Methods"
    Public Sub CambiarStatusEntidad(r As Record)
        Dim entidadSA As New entidadSA

        entidadSA.CambiarStatusEntidad(New entidad With {.idEntidad = Val(r.GetValue("idEntidad")),
                                                         .estado = StatusEntidad.Inactivo})

        MessageBox.Show("Proveedor se cambio a estado a inactivo!", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ListaProveedores()
    End Sub

    Private Sub ListaProveedores()
        Dim dt As New DataTable()
        dt.Columns.Add("idEntidad")
        dt.Columns.Add("tipoDoc")
        dt.Columns.Add("nroDoc")
        dt.Columns.Add("tipo")
        dt.Columns.Add("razon")
        dt.Columns.Add("direc")
        dt.Columns.Add("fono")

        For Each i In entidad.GetListarEntidad(New entidad With {.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR, .idEmpresa = Gempresas.IdEmpresaRuc, .idOrganizacion = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.idEntidad
            Select Case i.tipoDoc
                Case "6"
                    dr(1) = "RUC"
                Case "1"
                    dr(1) = "DNI"
                Case "7"
                    dr(1) = "PASSAPORTE"
                Case "4"
                    dr(1) = "CARNET DE EXTRANJERIA"
            End Select

            dr(2) = i.nrodoc
            dr(3) = IIf(i.tipoPersona = "N", "NATURAL", "JURIDICO")
            dr(4) = i.nombreCompleto
            dr(5) = i.direccion
            dr(6) = i.telefono
            dt.Rows.Add(dr)
        Next
        dgvProveedor.DataSource = dt
    End Sub

    Private Sub IsMouseHover(row As Integer, col As Integer, isHover As Boolean, GGC As GridGroupingControl)
        Dim color As New GridMetroColors()
        Dim id As GridTableCellStyleInfoIdentity = GGC.TableControl.GetTableViewStyleInfo(row, col).TableCellIdentity
        If id.DisplayElement.IsRecord() Then
            Dim key As Integer = id.DisplayElement.GetRecord().Id
            hoveredIndex = row
            selectionColl.Clear()
            GGC.TableControl.Refresh()
        End If
        GGC.TableControl.Selections.Clear()
    End Sub
#End Region

#Region "Events"
    Private Sub ToggleButton21_ButtonStateChanged(sender As Object, e As ToggleButton2.ToggleButtonStateEventArgs) Handles ToggleButton21.ButtonStateChanged
        If ToggleButton21.ToggleState = ToggleButton2.ToggleButtonState.OFF Then
            dgvProveedor.TopLevelGroupOptions.ShowFilterBar = True
            dgvProveedor.NestedTableGroupOptions.ShowFilterBar = True
            dgvProveedor.ChildGroupOptions.ShowFilterBar = True
            For Each col As GridColumnDescriptor In dgvProveedor.TableDescriptor.Columns
                col.AllowFilter = True
            Next
            filter.AllowResize = True
            filter.AllowFilterByColor = True
            filter.EnableDateFilter = True
            filter.EnableNumberFilter = True

            dgvProveedor.OptimizeFilterPerformance = True
            dgvProveedor.ShowNavigationBar = True
            filter.WireGrid(dgvProveedor)
        Else
            filter.ClearFilters(dgvProveedor)
            dgvProveedor.TopLevelGroupOptions.ShowFilterBar = False
        End If
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        With frmCrearENtidades
            .CaptionLabels(0).Text = "Nuevo proveedor"
            .strTipo = TIPO_ENTIDAD.PROVEEDOR
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        Cursor = Cursors.WaitCursor
        If Not IsNothing(dgvProveedor.Table.CurrentRecord) Then
            If dgvProveedor.Table.CurrentRecord.GetValue("razon") <> "PROVEEDORES VARIOS" Then
                Dim f As New frmCrearENtidades(CInt(dgvProveedor.Table.CurrentRecord.GetValue("idEntidad")))
                f.CaptionLabels(0).Text = "Editar proveedor"
                f.strTipo = TIPO_ENTIDAD.PROVEEDOR
                '   f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                f.intIdEntidad = dgvProveedor.Table.CurrentRecord.GetValue("idEntidad")
                'f.UbicarEntidad(dgvProveedor.Table.CurrentRecord.GetValue("idEntidad"))
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
            End If
        Else
            MessageBox.Show("Debe seleccionar un cliente!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Cursor = Cursors.WaitCursor
        ListaProveedores()
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click
        If dgvProveedor.Table.Records.Count > 0 Then
            If Not IsNothing(dgvProveedor.Table.CurrentRecord) Then
                If MessageBox.Show("Cambiar a inactivo al proveedor seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    CambiarStatusEntidad(dgvProveedor.Table.CurrentRecord)
                End If
            End If
        End If
    End Sub

    Private Sub dgvProveedor_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvProveedor.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            dgvProveedor.TableControl.Selections.Clear()
        End If
    End Sub

    Private Sub dgvProveedor_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgvProveedor.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgvProveedor)
    End Sub
#End Region

End Class