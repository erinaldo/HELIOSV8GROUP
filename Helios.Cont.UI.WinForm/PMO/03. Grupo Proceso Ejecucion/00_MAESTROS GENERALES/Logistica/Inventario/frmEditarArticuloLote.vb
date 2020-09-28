Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess

Public Class frmEditarArticuloLote

#Region "Attributes"
    Public Property objInventario As totalesAlmacen
    Dim itemSA As New detalleitemsSA
    Dim totalesSA As New TotalesAlmacenSA
    Public alert As Alert
#End Region

#Region "Constructors"
    Public Sub New(intIdItem As Integer, codigoLote As Integer, idalmacen As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        LoadControles()
        UbicarProducto(intIdItem, codigoLote, idalmacen)
    End Sub
#End Region

#Region "methods"
    Private Sub LoadControles()
        Dim tablaSA As New tablaDetalleSA
        Try

            cboUnidades.DataSource = tablaSA.GetListaTablaDetalle(6, "1")
            cboUnidades.DisplayMember = "descripcion"
            cboUnidades.ValueMember = "codigoDetalle2"

        Catch ex As Exception

        End Try
    End Sub

    Public Sub UbicarProducto(intIdItem As Integer, codigoLote As Integer, idalmacen As Integer)

        Dim obj = totalesSA.GetUbicarArticuloLote(New Business.Entity.totalesAlmacen With {.idItem = intIdItem, .codigoLote = codigoLote, .idAlmacen = idalmacen})

        If obj IsNot Nothing Then
            txtProductoNew.Text = obj.descripcion
            txtProductoNew.Tag = obj.idItem
            txtCodigoBarra.Text = obj.CodigoBarra
            cboUnidades.SelectedValue = obj.idUnidad
            txtCodigoLote.Text = obj.CustomLote.codigoLote
            If obj.CustomLote.fechaProduccion.HasValue Then
                txtFechaproduccion.Value = obj.CustomLote.fechaProduccion.GetValueOrDefault
            Else
                txtFechaproduccion.Value = Date.Now
            End If
            If obj.CustomLote.fechaVcto.HasValue Then
                txtFechalote.Value = obj.CustomLote.fechaVcto.GetValueOrDefault
            Else
                txtFechalote.Value = Date.Now
            End If

        End If


    End Sub

    Private Sub EditarArticulo()
        objInventario = New totalesAlmacen
        objInventario.idItem = txtProductoNew.Tag
        objInventario.descripcion = txtProductoNew.Text.Trim
        objInventario.idUnidad = cboUnidades.SelectedValue
        objInventario.CodigoBarra = txtCodigoBarra.Text
        objInventario.CustomLote = New recursoCostoLote With
        {
        .codigoLote = txtCodigoLote.Text,
        .fechaProduccion = txtFechaproduccion.Value,
        .fechaVcto = txtFechalote.Value
        }
        totalesSA.EditarArticuloLOTE(objInventario)
        alert = New Alert("Artículo modificado", General.Constantes.alertType.success)
        alert.TopMost = True
        alert.Show()
        Close()
    End Sub

    Private Function ValidarGrabado() As Boolean
        Dim listaErrores As Integer = 0

        'If Not txtCategoria.Text.Trim.Length > 0 Then
        '    ErrorProvider1.SetError(txtCategoria, "Ingrese la clasificación general")
        '    listaErrores += 1
        'Else
        '    ErrorProvider1.SetError(txtCategoria, Nothing)
        'End If

        'If txtCategoria.Text.Trim.Length > 0 Then
        '    If txtCategoria.ForeColor = Color.Black Then
        '        ErrorProvider1.SetError(txtCategoria, "Verificar el ingreso correcto de la clasificación general")
        '        listaErrores += 1
        '    Else
        '        ErrorProvider1.SetError(txtCategoria, Nothing)
        '    End If
        'End If


        If txtProductoNew.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(txtProductoNew, "Ingrese el nombre del artículo")
            listaErrores += 1
        Else
            ErrorProvider1.SetError(txtProductoNew, Nothing)
        End If
        If listaErrores > 0 Then
            ValidarGrabado = False
        Else
            ValidarGrabado = True
        End If
    End Function
#End Region

#Region "Events"
    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Close()
    End Sub

    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        If ValidarGrabado() = True Then
            EditarArticulo()
        End If
    End Sub

    Private Sub txtFechalote_ValueChanged(sender As Object, e As EventArgs) Handles txtFechalote.ValueChanged

    End Sub

    Private Sub frmEditarArticuloLote_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
#End Region

End Class