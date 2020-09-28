Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Public Class FormCrearCategory

    Public Property Manipulacion As String

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(cat As item)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        MappingCategory(cat)
    End Sub

    Private Sub MappingCategory(cat As item)
        With cat
            textCategory.Text = .descripcion
            Select Case .preciocompratipo
                Case "PCT"
                    ComboCategoria.Text = "PORCENTAJE"

                Case "NN"
                    ComboCategoria.Text = "SIN CONFIGURACION"
                Case Else
                    ComboCategoria.Text = "MONTO FIJO"
            End Select
            TextPrecioCompra.DecimalValue = .precioCompra.GetValueOrDefault
            TextUtilidad1.DecimalValue = .firstpercent.GetValueOrDefault
            TextUtilidad2.DecimalValue = .beforepercent.GetValueOrDefault
            textCategory.Tag = cat.idItem
        End With
        Manipulacion = ENTITY_ACTIONS.UPDATE
    End Sub

    Private Sub BunifuThinButton21_Click(sender As Object, e As EventArgs) Handles BunifuThinButton21.Click
        Try
            Select Case Manipulacion
                Case ENTITY_ACTIONS.INSERT
                    GrabarCategory()
                Case ENTITY_ACTIONS.UPDATE
                    EditarCategory()
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub EditarCategory()
        Dim itemSA As New itemSA
        Dim tipoConfig As String = String.Empty
        Select Case ComboCategoria.Text
            Case "SIN CONFIGURACION"
                tipoConfig = "NN"
            Case "PORCENTAJE"
                tipoConfig = "PCT"
            Case Else
                tipoConfig = "FJ"
        End Select

        Dim obj As New item With {
         .idItem = textCategory.Tag,
        .idPadre = 0,
        .idEmpresa = Gempresas.IdEmpresaRuc,
        .idEstablecimiento = GEstableciento.IdEstablecimiento,
        .fechaIngreso = Date.Now,
        .descripcion = textCategory.Text.Trim,
        .tipo = "C",
        .preciocompratipo = tipoConfig,
        .precioCompra = TextPrecioCompra.DecimalValue,
        .firstpercent = TextUtilidad1.DecimalValue,
        .beforepercent = TextUtilidad2.DecimalValue,
        .usuarioActualizacion = usuario.IDUsuario,
        .fechaActualizacion = Date.Now
        }
        itemSA.UpdateCategoria(obj)
        MessageBox.Show("Categoría editada!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Tag = obj
        Close()
    End Sub

    Private Sub GrabarCategory()
        Dim itemSA As New itemSA
        Dim tipoConfig As String = String.Empty
        Select Case ComboCategoria.Text
            Case "SIN CONFIGURACION"
                tipoConfig = "NN"
            Case "PORCENTAJE"
                tipoConfig = "PCT"
            Case Else
                tipoConfig = "FJ"
        End Select

        Dim obj As New item With {
        .idPadre = 0,
        .idEmpresa = Gempresas.IdEmpresaRuc,
        .idEstablecimiento = GEstableciento.IdEstablecimiento,
        .fechaIngreso = Date.Now,
        .descripcion = textCategory.Text.Trim,
        .tipo = "C",
        .preciocompratipo = tipoConfig,
        .precioCompra = TextPrecioCompra.DecimalValue,
        .firstpercent = TextUtilidad1.DecimalValue,
        .beforepercent = TextUtilidad2.DecimalValue,
        .usuarioActualizacion = usuario.IDUsuario,
        .fechaActualizacion = Date.Now
        }
        Dim cod = itemSA.SaveCategoria(obj)
        obj.idItem = cod
        MessageBox.Show("Categoría registrada!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Tag = obj
        Close()
    End Sub

    Private Sub ComboCategoria_Click(sender As Object, e As EventArgs) Handles ComboCategoria.Click

    End Sub

    Private Sub ComboCategoria_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboCategoria.SelectedValueChanged
        '  Label3.Visible = True
        '  TextPrecioCompra.Visible = True
        Select Case ComboCategoria.Text
            Case "SIN CONFIGURACION"
                '         Label3.Visible = False
                '        TextPrecioCompra.Visible = False

                Label4.Visible = False
                TextUtilidad1.Visible = False

                Label5.Visible = False
                TextUtilidad2.Visible = False

            Case "PORCENTAJE"
                Label4.Visible = True
                TextUtilidad1.Visible = True

                Label5.Visible = True
                TextUtilidad2.Visible = True
            Case Else
                Label4.Visible = False
                TextUtilidad1.Visible = False

                Label5.Visible = False
                TextUtilidad2.Visible = False
        End Select


        If ComboCategoria.Text = "MONTO FIJO" Then

        Else

        End If
    End Sub

    Private Sub TextUtilidad1_TextChanged(sender As Object, e As EventArgs) Handles TextUtilidad1.TextChanged
        TextUtilidad2.MaxValue = TextUtilidad1.DecimalValue
    End Sub
End Class