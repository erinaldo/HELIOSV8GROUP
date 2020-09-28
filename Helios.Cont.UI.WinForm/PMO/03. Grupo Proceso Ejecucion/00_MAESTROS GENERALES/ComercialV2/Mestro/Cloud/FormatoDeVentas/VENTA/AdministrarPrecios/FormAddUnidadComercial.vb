Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Public Class FormAddUnidadComercial

#Region "Attributes"
    Public Property objEntiad As Object
    Public Property ListaEquivalencias As List(Of detalleitem_equivalencias)

#End Region

#Region "Constructors"
    Public Sub New(Lista As List(Of detalleitem_equivalencias))
        ListaEquivalencias = Lista
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        TextContenidoNeto.MinValue = Lista.Where(Function(o) o.flag = "MIN").Min(Function(o) o.contenido_neto).GetValueOrDefault
        TextContenidoNeto.MaxValue = 1000 'Lista.Where(Function(o) o.flag = "MAX").Max(Function(o) o.contenido_neto).GetValueOrDefault
    End Sub


#End Region

#Region "Methods"
    Private Sub GrabarUnidad()
        Dim unidadSA As New detalleitem_equivalenciasSA
        Dim be = CType(objEntiad, detalleitem_equivalencias)
        Dim unidad As New detalleitem_equivalencias With
        {
        .Action = BaseBE.EntityAction.INSERT,
        .codigodetalle = be.codigodetalle,
        .detalle = TextUnidadPrincipal.Tag,
        .unidadComercial = TextUnidadComercial.Text,
        .contenido_neto = TextContenidoNeto.DecimalValue,
        .contenido = 0,'TextRepresentacion.DecimalValue,
        .fraccionUnidad = 0, 'TextEquivalencia.DecimalValue,
        .flag = "N",
        .estado = "A",
        .usuarioActualizacion = usuario.IDUsuario,
        .fechaActualizacion = Date.Now
        }

        '.detalleitemequivalencia_catalogos = New List(Of detalleitemequivalencia_catalogos) From
        '{
        'New detalleitemequivalencia_catalogos With {
        '                                    .codigodetalle = be.codigodetalle,
        '                                    .nombre_corto = "LISTA A",
        '                                    .nombre_largo = "LISTA B",
        '                                    .predeterminado = True,
        '                                    .estado = 1
        '                                    }
        '    }

        Dim und = unidadSA.SaveEquivalencia(unidad)
        MessageBox.Show("Unidad comercial registrada", "Grabado", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Tag = und
        Close()
    End Sub
#End Region

#Region "Events"
    Private Sub BunifuThinButton21_Click(sender As Object, e As EventArgs) Handles BunifuThinButton21.Click
        Cursor = Cursors.WaitCursor
        Try
            If TextContenidoNeto.DecimalValue <= 0 Then
                MessageBox.Show("Contenido mayor a cero", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextContenidoNeto.Select()
                Exit Sub
            End If

            Dim contenidoNew = TextContenidoNeto.DecimalValue
            Dim existe = ListaEquivalencias.Any(Function(o) o.contenido_neto = contenidoNew)
            If existe Then
                MessageBox.Show("Contenido ingresado ya existe, ingrese otro", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextContenidoNeto.Select()
                Exit Sub
            End If

            If TextUnidadComercial.Text.Trim.Length > 0 Then
                'If TextRepresentacion.DecimalValue > 0 Then
                '    If TextEquivalencia.DecimalValue > 0 Then
                GrabarUnidad()
                        '    Else
                        '        MessageBox.Show("Debe ingresar un factor de conversión mayor a cero", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        '        TextEquivalencia.Select()
                        '    End If
                        'Else
                        '    MessageBox.Show("Debe ingresar una representación mayor a cero", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        '    TextRepresentacion.Select()
                        'End If
                    Else
                TextUnidadComercial.Select()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Atención")
        End Try

        Cursor = Cursors.Default
    End Sub

    Private Sub TextRepresentacion_TextChanged(sender As Object, e As EventArgs)
        '    GetcalculoEquivalencia()
    End Sub

    'Private Sub GetcalculoEquivalencia()



    '    If TextRepresentacion.DecimalValue >= 1 Then
    '        Dim unidad = 1
    '        Dim Representacion As Decimal = TextRepresentacion.DecimalValue
    '        Dim resultado = unidad / Representacion
    '        TextEquivalencia.DecimalValue = resultado
    '    Else
    '        TextEquivalencia.DecimalValue = 0
    '    End If
    'End Sub

    'Private Sub CalculoContenido()
    '    Dim contenido As Decimal = 0
    '    Dim contenidoNeto As Decimal = TextContenidoNeto.DecimalValue
    '    Dim fraccion As Decimal = 0

    '    If ListaEquivalencias.Count = 0 Then
    '        contenido = contenidoNeto / contenidoNeto
    '    Else
    '        Dim primeraFila As Decimal = ListaEquivalencias.Max(Function(o) o.contenido_neto).GetValueOrDefault ' ListaEquivalencias.FirstOrDefault.contenido_neto.GetValueOrDefault
    '        If contenidoNeto > 0 Then
    '            contenido = primeraFila / contenidoNeto
    '        Else
    '            contenido = 0 'primeraFila / contenidoNeto
    '        End If

    '    End If
    '    If contenido > 0 Then
    '        fraccion = 1 / contenido
    '    Else
    '        fraccion = 0
    '    End If
    '    TextRepresentacion.DecimalValue = contenido
    '    TextEquivalencia.DecimalValue = fraccion

    'End Sub

    Private Sub TextContenidoNeto_TextChanged(sender As Object, e As EventArgs) Handles TextContenidoNeto.TextChanged
        'CalculoContenido()
    End Sub
#End Region

End Class