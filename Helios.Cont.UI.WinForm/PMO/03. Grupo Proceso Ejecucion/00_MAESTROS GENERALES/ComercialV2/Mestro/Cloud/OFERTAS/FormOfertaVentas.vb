Imports Helios.Cont.Business.Entity
Imports Helios.Cont.Presentation.WinForm
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General

Public Class FormOfertaVentas
    Implements IExistencias

    Public Property Manipulacion() As String

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GetConfigGrid()
        FormatoGridAvanzado(GridOferta, False, False)
    End Sub

    Public Sub New(id As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UbicarOferta(id)
    End Sub

    Private Sub GetConfigGrid()
        Dim dt As New DataTable
        dt.Columns.Add("iditem")
        dt.Columns.Add("detalle")
        dt.Columns.Add("UM")
        dt.Columns.Add("cantidad")

        GridOferta.DataSource = dt
    End Sub

    Public Sub EnviarItem(productoBE As detalleitems) Implements IExistencias.EnviarItem
        Me.GridOferta.Table.AddNewRecord.SetCurrent()
        Me.GridOferta.Table.AddNewRecord.BeginEdit()
        Me.GridOferta.Table.CurrentRecord.SetValue("iditem", productoBE.codigodetalle)
        Me.GridOferta.Table.CurrentRecord.SetValue("detalle", productoBE.descripcionItem)
        Me.GridOferta.Table.CurrentRecord.SetValue("UM", productoBE.unidad1)
        Me.GridOferta.Table.CurrentRecord.SetValue("cantidad", 1)
        Me.GridOferta.Table.AddNewRecord.EndEdit()
    End Sub

    Private Sub FormOfertaVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim f As New FormCanastaCompras
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
    End Sub

    Private Sub ButtonAdv19_Click(sender As Object, e As EventArgs) Handles ButtonAdv19.Click
        If GridOferta.Table.Records.Count > 0 Then
            If Manipulacion = ENTITY_ACTIONS.INSERT Then
                GrabarOferta()
            ElseIf Manipulacion = ENTITY_ACTIONS.UPDATE Then

            End If
        Else
            MessageBox.Show("Debe agregar al menos, un producto a la canasta!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub UbicarOferta(id As Integer)
        Dim ofertaSA As New OfertaSA
        Dim oferta = ofertaSA.OfertaSel(New oferta With {.id = id})
        If oferta IsNot Nothing Then

            Select Case oferta.tipo
                Case "B"
                    ComboTipo.Text = "BASICO"
                Case "I"
                    ComboTipo.Text = "INTERMEDIO"
                Case "P"
                    ComboTipo.Text = "PREMIUM"
            End Select

            Tag = oferta.id
            TextCodigo.Text = oferta.codigo
            TextNomCorto.Text = oferta.nombreCorto
            TextDescripcion.Text = oferta.nombreCorto
            ComboTipo.Text = oferta.tipo
            TextInicio.Text = oferta.fechaEmision
            TextFinaliza.Text = oferta.Vence
            TextPrecioVenta.DecimalValue = 0
        End If
    End Sub

    Private Sub GrabarOferta()
        Dim ofertaSA As New OfertaSA
        Dim lista As New List(Of ofertadetalle)
        Dim tipo As String = String.Empty

        Select Case ComboTipo.Text
            Case "BASICO"
                tipo = "B"
            Case "INTERMEDIO"
                tipo = "I"
            Case "PREMIUM"
                tipo = "P"
        End Select

        Dim oferta As New oferta With
        {
        .Action = BaseBE.EntityAction.INSERT,
        .idemprea = Gempresas.IdEmpresaRuc,
        .idEstablecimiento = GEstableciento.IdEstablecimiento,
        .tipo = tipo,
        .codigo = TextCodigo.Text.Trim,
        .fechaEmision = TextInicio.Value,
        .Vence = TextFinaliza.Value,
        .estado = "A",
        .nombreCorto = TextNomCorto.Text.Trim,
        .descripcion = TextDescripcion.Text.Trim,
        .precioventa = TextPrecioVenta.DecimalValue,
        .usuarioActualizacion = usuario.IDUsuario,
        .fechaActualizacion = Date.Now
        }

        lista = New List(Of ofertadetalle)
        For Each i In GridOferta.Table.Records
            lista.Add(New ofertadetalle With
                      {
                      .idalmacen = 0,
                      .iditem = Integer.Parse(i.GetValue("iditem")),
                      .lote = 0,
                      .detalle = i.GetValue("detalle"),
                      .cantidad = CDec(i.GetValue("cantidad")),
                      .usuarioActualizacion = usuario.IDUsuario,
                      .fechaActualizacion = Date.Now
                      })
        Next
        oferta.ofertadetalle = lista
        ofertaSA.SaveOferta(oferta)
        MessageBox.Show("Oferta registrada!", "Grabado", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Close()
    End Sub

    Private Sub EditarOferta()
        Dim ofertaSA As New OfertaSA
        Dim lista As New List(Of ofertadetalle)

        Dim tipo As String = String.Empty

        Select Case ComboTipo.Text
            Case "BASICO"
                tipo = "B"
            Case "INTERMEDIO"
                tipo = "I"
            Case "PREMIUM"
                tipo = "P"
        End Select

        Dim oferta As New oferta With
        {
        .Action = BaseBE.EntityAction.UPDATE,
        .id = Tag,
        .idemprea = Gempresas.IdEmpresaRuc,
        .idEstablecimiento = GEstableciento.IdEstablecimiento,
        .tipo = tipo,
        .codigo = TextCodigo.Text.Trim,
        .fechaEmision = TextInicio.Value,
        .Vence = TextFinaliza.Value,
        .estado = "A",
        .nombreCorto = TextNomCorto.Text.Trim,
        .descripcion = TextDescripcion.Text.Trim,
        .precioventa = TextPrecioVenta.DecimalValue,
        .usuarioActualizacion = usuario.IDUsuario,
        .fechaActualizacion = Date.Now
        }

        lista = New List(Of ofertadetalle)
        For Each i In GridOferta.Table.Records
            lista.Add(New ofertadetalle With
                      {
                      .idalmacen = 0,
                      .iditem = i.GetValue("iditem"),
                      .lote = 0,
                      .detalle = i.GetValue("detalle"),
                      .cantidad = CDec(i.GetValue("cantidad")),
                      .usuarioActualizacion = usuario.IDUsuario,
                      .fechaActualizacion = Date.Now
                      })
        Next
        oferta.ofertadetalle = lista
        ofertaSA.SaveOferta(oferta)
        MessageBox.Show("Oferta registrada!", "Grabado", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Close()
    End Sub
End Class