Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Public Class FormAddPrecioEquivalencia

    Public Property TipoEntidad As String
    Public Property objEntiad As Object
    Public Property equivalenciaSA As New detalleitem_equivalenciasSA
    Public Property precioSA As New detalleitemequivalencia_preciosSA

    Private Sub BunifuThinButton21_Click(sender As Object, e As EventArgs) Handles BunifuThinButton21.Click

        Select Case TipoEntidad
            Case "EQUIVALENCIA"
                If TextDetalle.Text.Trim.Length > 0 Then
                    AddEquivalencia()
                Else
                    MessageBox.Show("Debe ingresar una descripción", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    TextDetalle.Select()
                End If
            Case "PRECIO"
                If ComboPrecio.Text.Trim.Length > 0 Then
                    AddPrecio()
                Else
                    MessageBox.Show("Debe ingresar una descripción", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    ComboPrecio.Select()
                End If
        End Select
    End Sub

    Private Sub AddEquivalencia()
        Dim be = CType(objEntiad, detalleitem_equivalencias)

        Dim obj As New detalleitem_equivalencias With
        {
        .Action = BaseBE.EntityAction.INSERT,
        .codigodetalle = be.codigodetalle,
        .detalle = TextDetalle.Text.Trim,
        .fraccionUnidad = TextValor.DecimalValue,
        .estado = "A",
        .usuarioActualizacion = usuario.IDUsuario,
        .fechaActualizacion = Date.Now
        }
        Dim eq = equivalenciaSA.SaveEquivalencia(obj)
        Tag = eq
        Close()
    End Sub

    Private Sub AddPrecio()
        Dim be = CType(objEntiad, detalleitemequivalencia_precios)
        '.rango_final = TextRangoFin.DecimalValue,
        Dim obj As New detalleitemequivalencia_precios With
        {
        .Action = BaseBE.EntityAction.INSERT,
        .idCatalogo = be.idCatalogo,
        .equivalencia_id = be.equivalencia_id,
        .codigodetalle = be.codigodetalle,
        .rango_inicio = TextRangoInicio.DecimalValue,
        .precioCode = ComboPrecio.Text.Trim,
        .precio = TextValor.DecimalValue,
        .precioCredito = TextValorCredito.DecimalValue,
        .estado = 1,
        .usuarioActualizacion = usuario.IDUsuario,
        .fechaActualizacion = Date.Now
        }
        Dim prec = precioSA.PrecioEquivalenciaSave(obj)
        Tag = prec
        Close()
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