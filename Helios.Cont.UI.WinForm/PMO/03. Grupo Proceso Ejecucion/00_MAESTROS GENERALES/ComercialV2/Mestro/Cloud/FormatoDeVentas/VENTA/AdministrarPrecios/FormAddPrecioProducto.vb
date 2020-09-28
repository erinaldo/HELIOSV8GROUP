Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess

Public Class FormAddPrecioProducto
    Public Property objEntiad As detalleitems

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub AddPrecio()
        Dim precioSA As New detalleitem_preciosSA

        Dim obj As New detalleitem_precios With
        {
        .Action = BaseBE.EntityAction.INSERT,
        .codigodetalle = objEntiad.codigodetalle,
        .tipo_rango = "F",
        .rango_inicio = TextRangoInicio.DecimalValue,
        .rango_final = TextRangoFin.DecimalValue,
        .tipo_precio = ComboPrecio.Text.Trim,
        .ultimoCosto = 0,
        .VContadoPrecioConIgv = TextContadoConIgv.DecimalValue,
        .VContadoPrecioSinIgv = TextContadoSinIgv.DecimalValue,
        .VCreditoPrecioConIgv = TextCreditoConIgv.DecimalValue,
        .VCreditoPrecioSinIgv = TextCreditoSinIgv.DecimalValue,
        .usuarioActualizacion = usuario.IDUsuario,
        .fechaActualizacion = Date.Now
        }
        Dim prec = precioSA.DetalleItemPrecioSave(obj)
        Tag = prec
        Close()
    End Sub

    Private Sub BunifuThinButton21_Click(sender As Object, e As EventArgs) Handles BunifuThinButton21.Click
        If ComboPrecio.Text.Trim.Length > 0 Then
            AddPrecio()
        Else
            MessageBox.Show("Debe ingresar un tipo de precio para agregar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ComboPrecio.Select()
        End If
    End Sub

    Private Sub ComboPrecio_Click(sender As Object, e As EventArgs) Handles ComboPrecio.Click

    End Sub

    Private Sub ComboPrecio_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboPrecio.SelectedValueChanged
        Select Case ComboPrecio.Text
            Case "OTRO"
                ComboPrecio.DropDownStyle = ComboBoxStyle.DropDown
            Case Else
                ComboPrecio.DropDownStyle = ComboBoxStyle.DropDownList
        End Select
    End Sub
End Class