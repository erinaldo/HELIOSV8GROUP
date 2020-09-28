Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess

Public Class FormVentaEnConsigna
#Region "Attributes"

#End Region

#Region "Constructors"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        GetCombos()
    End Sub

#End Region

#Region "Methdos"
    Private Sub GetCombos()
        Dim tablaSA As New tablaDetalleSA
        CboUnidad.DataSource = tablaSA.GetListaTablaDetalle(6, "1")
        CboUnidad.DisplayMember = "descripcion"
        CboUnidad.ValueMember = "codigoDetalle2"
    End Sub

    Private Sub EnviarProductoConsignado()
        Dim t As New totalesAlmacen With
        {
        .idItem = 0,
        .descripcion = TextProducto.Text.Trim,
        .idUnidad = CboUnidad.SelectedValue,
        .unidadMedida = CboUnidad.SelectedValue,
        .tipoExistencia = "01",
        .origenRecaudo = 1,
        .PMprecioMN = TextPrecUnitVenta.DecimalValue,
        .PMprecioME = 0,
        .cantidad = TextCant.DecimalValue,
        .importeSoles = TextTotalCompra.DecimalValue,
        .importeDolares = 0,
        .Marca = "Doc."
        }

        Dim miInterfaz As IProductoConsignado = TryCast(Me.Owner, IProductoConsignado)
        If miInterfaz IsNot Nothing Then miInterfaz.EnviarConsigna(t)
        TextProducto.Clear()
        TextCant.Clear()
        TextPrecUnitCompra.Clear()
        TextTotalCompra.Clear()
        TextPrecUnitVenta.Clear()
    End Sub


    Private Sub calculo()
        TextTotalCompra.DecimalValue = TextCant.DecimalValue * TextPrecUnitCompra.DecimalValue
    End Sub

    Private Function ValidarGrabado() As Boolean
        Dim listaErrores As Integer = 0

        If TextProducto.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(TextProducto, "El campo producto es requerido")
            listaErrores += 1
        Else
            ErrorProvider1.SetError(TextProducto, Nothing)
        End If

        If TextCant.DecimalValue <= 0 Then
            ErrorProvider1.SetError(TextCant, "El campo cantidad debe ser mayor a cero.")
            listaErrores += 1
        Else
            ErrorProvider1.SetError(TextCant, Nothing)
        End If

        If TextPrecUnitCompra.DecimalValue <= 0 Then
            ErrorProvider1.SetError(TextPrecUnitCompra, "El campo precio de compra debe ser mayor a cero.")
            listaErrores += 1
        Else
            ErrorProvider1.SetError(TextPrecUnitCompra, Nothing)
        End If

        If TextPrecUnitVenta.DecimalValue <= 0 Then
            ErrorProvider1.SetError(TextPrecUnitVenta, "El campo precio de venta debe ser mayor a cero.")
            listaErrores += 1
        Else
            ErrorProvider1.SetError(TextPrecUnitVenta, Nothing)
        End If

        If listaErrores > 0 Then
            ValidarGrabado = False
        Else
            ValidarGrabado = True
        End If
    End Function

#End Region

#Region "Events"
    Private Sub ButtonGrabar_Click(sender As Object, e As EventArgs) Handles ButtonGrabar.Click
        If ValidarGrabado() Then
            EnviarProductoConsignado()
        End If
    End Sub

    Private Sub TextCant_TextChanged(sender As Object, e As EventArgs) Handles TextCant.TextChanged
        If IsNumeric(TextCant.DecimalValue) Then
            calculo()
        End If
    End Sub

    Private Sub TextPrecUnitCompra_TextChanged(sender As Object, e As EventArgs) Handles TextPrecUnitCompra.TextChanged
        If IsNumeric(TextPrecUnitCompra.DecimalValue) Then
            calculo()
        End If
    End Sub
#End Region

End Class