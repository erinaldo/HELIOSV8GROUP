Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Public Class FormCrearContrato

    Public Property productoSel As detalleitems
    Public ReadOnly Property _Comision As detalleitemcatalogo_comision

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        DateVigencia.Value = Date.Now

    End Sub

    Public Sub New(comision As detalleitemcatalogo_comision)

        ' This call is required by the designer.
        InitializeComponent()
        _Comision = comision
        MappingControls()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub MappingControls()
        PanelUnidadComercial.Visible = True
        PanelCatalogo.Visible = True
        LabelUnidadComercial.Text = _Comision.customUnidadComercial.unidadComercial
        LabelCatalogo.Text = _Comision.customCatalogoPrecio.nombre_corto

        TextProducto.Text = _Comision.customProducto.descripcionItem
        TextProducto.Tag = _Comision.customProducto.codigodetalle
        TextDescripcion.Text = _Comision.nombre_comision
        DateVigencia.Value = _Comision.vigencia
        If _Comision.tipo_comision = "M" Then
            ComboTipoComision.Text = "MONTO"
        Else
            ComboTipoComision.Text = "PORCENTAJE"
        End If
        NumericApartir.Value = _Comision.apartir_de

    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        If _Comision Is Nothing Then
            RegistrarComision()
        Else
            RegistrarComision(False)
        End If
    End Sub

    Private Sub RegistrarComision(Optional isnew As Boolean = True)
        Dim obj As New detalleitemcatalogo_comision
        Dim comisionSA As New detalleitemcatalogo_comisionSA
        If isnew Then
            obj.Action = BaseBE.EntityAction.INSERT
            obj.equivalencia_id = ComboUnidadComercial.SelectedValue
            obj.idCatalogo = ComboCatalogo.SelectedValue
        Else
            obj.Action = BaseBE.EntityAction.UPDATE
            obj.idComision = _Comision.idComision
            obj.equivalencia_id = _Comision.equivalencia_id
            obj.idCatalogo = _Comision.idCatalogo
        End If

        obj.empresa = Gempresas.IdEmpresaRuc
        obj.unidadNegocio = GEstableciento.IdEstablecimiento
        obj.codigodetalle = TextProducto.Tag

        obj.nombre_comision = TextDescripcion.Text
        obj.tipo_comision = If(ComboTipoComision.Text = "MONTO", "M", "P")
        obj.bloqueado = False
        obj.vigencia = DateVigencia.Value
        obj.apartir_de = NumericApartir.Value
        obj.montoMaximo = 0
        obj.montoMinimo = 0

        comisionSA.detalleitemcatalogo_comisionSave(obj)
        MessageBox.Show("Comision registrada!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Close()

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim f As New FormCanastaProductsGeneral
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me) 
        If f.Tag IsNot Nothing Then
            productoSel = CType(f.Tag, detalleitems)

            TextProducto.Text = productoSel.descripcionItem
            TextProducto.Tag = productoSel.codigodetalle

            Dim unidades As List(Of detalleitem_equivalencias)
            unidades = productoSel.detalleitem_equivalencias.ToList()
            GetComboUnidades(unidades)
            ComboUnidadComercial.SelectedValue = productoSel.customdetalleitem_equivalencias.equivalencia_id
        End If
    End Sub

    Private Sub GetComboUnidades(unidades As List(Of detalleitem_equivalencias))
        ComboUnidadComercial.DataSource = unidades
        ComboUnidadComercial.DisplayMember = "unidadComercial"
        ComboUnidadComercial.ValueMember = "equivalencia_id"
    End Sub

    Private Sub ComboUnidadComercial_Click(sender As Object, e As EventArgs) Handles ComboUnidadComercial.Click

    End Sub

    Private Sub ComboUnidadComercial_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboUnidadComercial.SelectedValueChanged
        If ComboUnidadComercial.Items.Count > 0 Then
            If IsNumeric(ComboUnidadComercial.SelectedValue) Then
                Dim codigoUnidad = Integer.Parse(ComboUnidadComercial.SelectedValue.ToString())
                Dim unidadSel = productoSel.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = codigoUnidad).SingleOrDefault()
                If unidadSel IsNot Nothing Then
                    GetComboCatalogos(unidadSel.detalleitemequivalencia_catalogos.ToList())
                End If
            End If
        End If
    End Sub

    Private Sub GetComboCatalogos(list As List(Of detalleitemequivalencia_catalogos))
        ComboCatalogo.DataSource = list
        ComboCatalogo.DisplayMember = "nombre_corto"
        ComboCatalogo.ValueMember = "idCatalogo"
    End Sub
End Class