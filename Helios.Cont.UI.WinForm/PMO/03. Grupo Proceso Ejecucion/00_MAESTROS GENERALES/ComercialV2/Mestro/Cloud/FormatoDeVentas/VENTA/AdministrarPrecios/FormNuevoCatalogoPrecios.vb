Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess

Public Class FormNuevoCatalogoPrecios

    Public Property CodigoProducto As Integer
    Public Property CodigoEquivalencia As Integer
    Public Property ManipulacionEntity As Entity.EntityState
    Public Property SelCodigoCatalogo As Integer

    Public Property SelPredeterminado As Boolean

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ManipulacionEntity = Entity.EntityState.Added
    End Sub

    Public Sub New(idCatalogo As Integer, nombreCatalogo As String, statusPredeterminado As Boolean)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        SelCodigoCatalogo = idCatalogo
        UbicarCatalogo(SelCodigoCatalogo, nombreCatalogo, statusPredeterminado)
        ManipulacionEntity = Entity.EntityState.Modified
    End Sub

    Private Sub UbicarCatalogo(selCodigoCatalogo As Integer, nombreCatalogo As String, statusPredeterminado As Boolean)
        TextNombreCatalogo.Tag = selCodigoCatalogo
        TextNombreCatalogo.Text = nombreCatalogo
        SelPredeterminado = statusPredeterminado
    End Sub

    Private Sub BunifuThinButton21_Click(sender As Object, e As EventArgs) Handles BunifuThinButton21.Click
        If TextNombreCatalogo.Text.Trim.Length > 0 Then
            If ManipulacionEntity = Entity.EntityState.Added Then
                Grabar()
            Else
                Editar()
            End If
        Else
            MessageBox.Show("Debe ingresar una descripción valida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextNombreCatalogo.Select()
            TextNombreCatalogo.Focus()
        End If
    End Sub

    Private Sub Grabar()
        Dim catalogoSA As New detalleitemequivalencia_catalogosSA
        Dim obj As New detalleitemequivalencia_catalogos With
        {
        .Action = BaseBE.EntityAction.INSERT,
        .codigodetalle = CodigoProducto,
        .equivalencia_id = CodigoEquivalencia,
        .nombre_corto = TextNombreCatalogo.Text.Trim,
        .nombre_largo = TextNombreCatalogo.Text.Trim,
        .predeterminado = False,
        .estado = 1
        }

        Dim catalogo = catalogoSA.CatalogoPrecioSave(obj)
        Tag = catalogo
        Close()
    End Sub

    Private Sub Editar()
        Dim catalogoSA As New detalleitemequivalencia_catalogosSA
        Dim obj As New detalleitemequivalencia_catalogos With
        {
        .Action = BaseBE.EntityAction.UPDATE,
        .idCatalogo = SelCodigoCatalogo,
        .codigodetalle = CodigoProducto,
        .equivalencia_id = CodigoEquivalencia,
        .nombre_corto = TextNombreCatalogo.Text.Trim,
        .nombre_largo = TextNombreCatalogo.Text.Trim,
        .predeterminado = SelPredeterminado,
        .estado = 1
        }
        Dim catalogo = catalogoSA.CatalogoPrecioSave(obj)
        Tag = catalogo
        Close()
    End Sub
End Class