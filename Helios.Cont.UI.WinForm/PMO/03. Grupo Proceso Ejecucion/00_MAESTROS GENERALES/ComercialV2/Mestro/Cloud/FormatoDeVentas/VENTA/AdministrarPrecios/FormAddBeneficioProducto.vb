Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Public Class FormAddBeneficioProducto
    Public Property objEntiad As Object
    Public Property Action As String
#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Action = ENTITY_ACTIONS.INSERT
        ComboAtributoAfectado.Visible = True
    End Sub

    Public Sub New(be As detalleitemequivalencia_beneficio)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        objEntiad = be
        MappingBeneficio(be)
        Action = ENTITY_ACTIONS.UPDATE
        ComboAtributoAfectado.Visible = True
    End Sub

#End Region

#Region "Methods"
    Public Sub GetComboMotivo(opcion As String)
        comboMotivo.Items.Clear()

        Select Case opcion
            Case "IMPORTE"
                comboMotivo.Items.Add("Por importe de consumo")
                ' comboMotivo.Items.Add("Por volumen de compras")
                comboMotivo.Items.Add("Dscto por lanzamiento")
                comboMotivo.Items.Add("Dscto por aniversario del establecimiento")
                comboMotivo.Items.Add("Compras ecommerce (compras on line)")
                comboMotivo.Items.Add("Cambio de temporada")
                comboMotivo.Items.Add("Flash (solo por hoy)")
                comboMotivo.Items.Add("Dscto por amarres, segundo item paga 50%")
            Case "CANTIDAD"
                'comboMotivo.Items.Add("Por importe de consumo")
                comboMotivo.Items.Add("Por volumen de compras")
                comboMotivo.Items.Add("Dscto por lanzamiento")
                comboMotivo.Items.Add("Dscto por aniversario del establecimiento")
                comboMotivo.Items.Add("Compras ecommerce (compras on line)")
                comboMotivo.Items.Add("Cambio de temporada")
                comboMotivo.Items.Add("Flash (solo por hoy)")
        End Select
    End Sub

    Private Sub MappingBeneficio(be As detalleitemequivalencia_beneficio)
        With be
            ComboTipobeneficio.Text = .tipobeneficio
            comboMotivo.Text = .beneficio_detalle
            ComboAtributoAfectado.Text = .tipoafectacion
            TextEvaluacion.DecimalValue = .valor_evaluado
            ComboConversion.Text = .valor_conversion
            TextBeneficioFinal.DecimalValue = .valor_beneficio
        End With
    End Sub

    Private Sub AddBeneficio()
        Dim be = CType(objEntiad, detalleitem_equivalencias)
        Dim beneficioSA As New detalleitemequivalencia_beneficioSA
        Dim aplica As String = String.Empty
        Dim motivo As String = String.Empty

        Select Case comboMotivo.Text
            Case "Por importe de consumo"
                motivo = "1"
            Case "Por volumen de compras"
                motivo = "2"
            Case "Dscto por lanzamiento"
                motivo = "3"
            Case "Dscto por aniversario del establecimiento"
                motivo = "4"
            Case "Compras ecommerce"
                motivo = "5"
            Case "Cambio de temporada"
                motivo = "6"
            Case "Flash (solo pro hoy)"
                motivo = "7"
        End Select

        Select Case ComboAplica.Text
            Case "Por cada"
                aplica = "1"
            Case "Superior a..."
                aplica = "2"
        End Select

        Dim obj As New detalleitemequivalencia_beneficio With
        {
        .Action = BaseBE.EntityAction.INSERT,
        .codigodetalle = be.codigodetalle,
        .equivalencia_id = be.equivalencia_id,
        .modalidadVenta = IIf(ComboModalidadVenta.Text = "VIRTUAL", "V", "T"),
        .beneficio_detalle = comboMotivo.Text.Trim,' motivo,'TextDetalle.Text.Trim,
        .tipobeneficio = ComboTipobeneficio.Text,
        .aplica = aplica,
        .tipoafectacion = ComboAtributoAfectado.Text,
        .valor_evaluado = TextEvaluacion.DecimalValue,
        .valor_conversion = ComboConversion.Text,
        .valor_beneficio = TextBeneficioFinal.DecimalValue,
        .estado = 1,
        .usuarioActualizacion = usuario.IDUsuario,
        .fechaActualizacion = Date.Now
        }
        Dim eq = beneficioSA.BeneficioSave(obj)
        Tag = eq
        Close()
    End Sub

    Private Sub EditBeneficio()
        Dim be = CType(objEntiad, detalleitemequivalencia_beneficio)
        Dim beneficioSA As New detalleitemequivalencia_beneficioSA

        Dim obj As New detalleitemequivalencia_beneficio With
        {
        .Action = BaseBE.EntityAction.UPDATE,
        .beneficio_id = be.beneficio_id,
        .codigodetalle = be.codigodetalle,
        .equivalencia_id = be.equivalencia_id,
        .beneficio_detalle = comboMotivo.Text.Trim,
        .tipobeneficio = ComboTipobeneficio.Text,
        .tipoafectacion = ComboAtributoAfectado.Text,
        .valor_evaluado = TextEvaluacion.DecimalValue,
        .valor_conversion = ComboConversion.Text,
        .valor_beneficio = TextBeneficioFinal.DecimalValue,
        .estado = 1,
        .usuarioActualizacion = usuario.IDUsuario,
        .fechaActualizacion = Date.Now
        }
        Dim eq = beneficioSA.BeneficioSave(obj)
        Tag = eq
        Close()
    End Sub

    Private Sub BunifuThinButton21_Click(sender As Object, e As EventArgs) Handles BunifuThinButton21.Click
        If comboMotivo.Text.Trim.Length = 0 Then
            MessageBox.Show("Describir el beneficio!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If TextEvaluacion.DecimalValue <= 0 Then
            MessageBox.Show("Ingrese un valor mayor a cero!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextEvaluacion.Select()
            Exit Sub
        End If

        If TextBeneficioFinal.DecimalValue <= 0 Then
            MessageBox.Show("Ingrese un valor mayor a cero!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextBeneficioFinal.Select()
            Exit Sub
        End If

        Select Case Action
            Case ENTITY_ACTIONS.INSERT
                AddBeneficio()
            Case ENTITY_ACTIONS.UPDATE
                EditBeneficio()
        End Select
    End Sub

    Private Sub FormAddBeneficioProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ComboTipobeneficio_Click(sender As Object, e As EventArgs) Handles ComboTipobeneficio.Click

    End Sub

    Private Sub ComboTipobeneficio_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboTipobeneficio.SelectedValueChanged
        If ComboTipobeneficio.Text = "OFERTA" Then
            ComboTipobeneficio.Text = "IMPORTE"
            ComboConversion.Text = "VALOR UNICO"
        ElseIf ComboTipobeneficio.Text = "DESCUENTO" Then
            ComboTipobeneficio.Text = "IMPORTE"
            ComboConversion.Text = "PORCENTAJE"
        End If
    End Sub

    Private Sub ComboConversion_Click(sender As Object, e As EventArgs) Handles ComboConversion.Click

    End Sub

    Private Sub ComboConversion_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboConversion.SelectedValueChanged

    End Sub

    Private Sub comboMotivo_Click(sender As Object, e As EventArgs) Handles comboMotivo.Click

    End Sub

    Private Sub comboMotivo_SelectedValueChanged(sender As Object, e As EventArgs) Handles comboMotivo.SelectedValueChanged
        'comboMotivo.Enabled = True
        If comboMotivo.Text.Trim.Length > 0 Then
            Select Case comboMotivo.Text
                Case "Por importe de consumo"
                    ComboAtributoAfectado.Text = "IMPORTE"
                    'comboMotivo.Enabled = False
                Case "Por volumen de compras"
                    ComboAtributoAfectado.Text = "CANTIDAD"
                    'comboMotivo.Enabled = False
            End Select
        End If
    End Sub
#End Region

#Region "events"

#End Region

End Class