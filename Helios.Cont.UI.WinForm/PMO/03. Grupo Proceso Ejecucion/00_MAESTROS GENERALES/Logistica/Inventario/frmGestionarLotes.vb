Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess

Public Class frmGestionarLotes
    Private totalesSA As TotalesAlmacenSA

#Region "Constructors"
    Public Sub New(intIdItem As Integer, codigoLote As Integer, idalmacen As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        totalesSA = New TotalesAlmacenSA
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        UbicarProducto(intIdItem, codigoLote, idalmacen)
    End Sub
#End Region


#Region "Methods"
    Public Sub UbicarProducto(intIdItem As Integer, codigoLote As Integer, idalmacen As Integer)

        Dim obj = totalesSA.GetUbicarArticuloLote(New Business.Entity.totalesAlmacen With {.idItem = intIdItem, .codigoLote = codigoLote, .idAlmacen = idalmacen})

        If obj IsNot Nothing Then
            txtProductoNew.Text = obj.descripcion
            txtProductoNew.Tag = obj.idItem
            txtCodigoBarra.Text = obj.CodigoBarra
            txtCodigoLote.Text = obj.CustomLote.codigoLote
            txtNroLote.Text = obj.CustomLote.nroLote
            If obj.CustomLote.fechaProduccion.HasValue Then
                txtFechaproduccion.Value = obj.CustomLote.fechaProduccion.GetValueOrDefault
            Else
                txtFechaproduccion.Value = Date.Now
            End If
            If obj.CustomLote.fechaVcto.HasValue Then
                txtFechaVcto.Value = obj.CustomLote.fechaVcto.GetValueOrDefault
            Else
                txtFechaVcto.Value = Date.Now
            End If
            TxtSerie.Text = obj.CustomLote.serie
            TxtSku.Text = obj.CustomLote.sku
            TxtComposicion.Text = obj.CustomLote.composicion
        End If


    End Sub
#End Region

#Region "Events"
    Private Sub frmGestionarLotes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With txtFechaVcto
            .DropDownNormalColor = Color.FromArgb(180, 26, 30)
            .DropDownPressedColor = Color.FromArgb(180, 26, 30)
            .DropDownSelectedColor = Color.FromArgb(180, 26, 30)
        End With
    End Sub

    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        EditarLote()
    End Sub

    Private Sub EditarLote()
        Dim loteSA As New recursoCostoLoteSA

        loteSA.EditarLote(New recursoCostoLote With
                          {
                            .nroLote = txtNroLote.Text,
                            .codigoLote = txtCodigoLote.Text,
                            .detalle = txtProductoNew.Text,
                            .fechaProduccion = txtFechaproduccion.Value,
                            .fechaVcto = txtFechaVcto.Value,
                            .serie = TxtSerie.Text,
                            .sku = TxtSku.Text,
                            .composicion = TxtComposicion.Text
                          })
        MessageBox.Show("lote editado!", "!Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Close()
    End Sub
#End Region
End Class