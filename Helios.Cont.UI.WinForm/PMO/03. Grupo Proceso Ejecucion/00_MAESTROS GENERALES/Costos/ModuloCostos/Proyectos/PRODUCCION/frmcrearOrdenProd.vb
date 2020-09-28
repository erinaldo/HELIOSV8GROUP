Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping

Public Class frmcrearOrdenProd
    Inherits frmMaster
    Public Property CodigoProducto() As Integer

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        txtInicio.Value = tmpConfigInicio.dia
    End Sub

#Region "Métodos"

    Public Sub GetCantidadProducida(be As recursoCosto)

        Dim costoSA As New recursoCostoSA
        Dim costo As New recursoCosto

        costo = costoSA.GetCantidadEntregadaProduccion(be)
        If Not IsNothing(costo) Then
            TextBoxExt1.Text = costo.cantidad.GetValueOrDefault
        End If

    End Sub

    Private Sub Grabar()
        Dim documento As documento
        Dim costo As New recursoCosto
        Dim proceso As New recursoCosto
        Dim recursoSA As New recursoCostoSA
        Dim lista As New List(Of cuentaplanContableEmpresa)
        Dim asiento As asiento
        Dim mov As movimiento
        Dim listaAsientos As List(Of asiento)
        documento = New documento With
        {
            .idEmpresa = Gempresas.IdEmpresaRuc,
            .idCentroCosto = GEstableciento.IdEstablecimiento,
            .idProyecto = Val(txtActividadActual.Tag),
            .tipoDoc = "1",
            .fechaProceso = txtInicio.Value,
            .nroDoc = "0",
            .idOrden = 0,
            .tipoOperacion = "0",
            .usuarioActualizacion = usuario.IDUsuario,
            .fechaActualizacion = Date.Now
            }

        costo = New recursoCosto
        costo.idpadre = Val(txtActividadActual.Tag)
        costo.tipo = "HC"
        costo.subtipo = TipoCosto.ProductoProducido
        costo.status = StatusProductosTerminados.Pendiente
        costo.nombreCosto = txtActividadActual.Text.Trim
        costo.codigo = CodigoProducto
        costo.detalle = txtGlosa.Text
        costo.subdetalle = Nothing
        costo.inicio = txtInicio.Value
        costo.finaliza = Nothing
        costo.director = Nothing ' Val(txtDirector.Tag)
        costo.procesado = "N"
        costo.cantidad = txtCantidadProducida.DecimalValue
        costo.costo = txtPU.DecimalValue * txtCantidadProducida.DecimalValue
        costo.usuarioActualizacion = usuario.IDUsuario
        costo.fechaActualizacion = DateTime.Now



        listaAsientos = New List(Of asiento)

        asiento = New asiento
        asiento.idEmpresa = Gempresas.IdEmpresaRuc
        asiento.idCentroCostos = GEstableciento.IdEstablecimiento
        asiento.fechaProceso = txtInicio.Value
        asiento.codigoLibro = "13"
        asiento.tipo = "D"
        asiento.tipoAsiento = "AS.D"
        asiento.importeMN = txtPU.DecimalValue * txtCantidadProducida.DecimalValue
        asiento.importeME = 0
        asiento.glosa = "Envio de productos terminados a planta"
        asiento.usuarioActualizacion = usuario.IDUsuario
        asiento.fechaActualizacion = Date.Now
        listaAsientos.Add(asiento)

        '1 Asiento
        mov = New movimiento
        mov.cuenta = "713"
        mov.descripcion = txtActividadActual.Text.Trim
        mov.tipo = "D"
        mov.monto = txtPU.DecimalValue * txtCantidadProducida.DecimalValue
        mov.montoUSD = 0
        mov.usuarioActualizacion = usuario.IDUsuario
        mov.fechaActualizacion = Date.Now
        asiento.movimiento.Add(mov)

        mov = New movimiento
        mov.cuenta = "231"
        mov.descripcion = txtActividadActual.Text.Trim
        mov.tipo = "H"
        mov.monto = txtPU.DecimalValue * txtCantidadProducida.DecimalValue
        mov.montoUSD = 0
        mov.usuarioActualizacion = usuario.IDUsuario
        mov.fechaActualizacion = Date.Now
        asiento.movimiento.Add(mov)

        '2º Asiento
        mov = New movimiento
        mov.cuenta = "92"
        mov.descripcion = txtActividadActual.Text.Trim
        mov.tipo = "D"
        mov.monto = txtPU.DecimalValue * txtCantidadProducida.DecimalValue
        mov.montoUSD = 0
        mov.usuarioActualizacion = usuario.IDUsuario
        mov.fechaActualizacion = Date.Now
        asiento.movimiento.Add(mov)

        mov = New movimiento
        mov.cuenta = "791"
        mov.descripcion = txtActividadActual.Text.Trim
        mov.tipo = "H"
        mov.monto = txtPU.DecimalValue * txtCantidadProducida.DecimalValue
        mov.montoUSD = 0
        mov.usuarioActualizacion = usuario.IDUsuario
        mov.fechaActualizacion = Date.Now
        asiento.movimiento.Add(mov)

        documento.asiento = listaAsientos

        costo.CustomDocumento = documento
        recursoSA.GrabarProduccionParcial(costo)
        'recursoSA.GrabarCostoProducido(costo)
        Close()
    End Sub
#End Region

    Private Sub frmcrearOrdenProd_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtActividadActual_TextChanged(sender As Object, e As EventArgs) Handles txtActividadActual.TextChanged

    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Cursor = Cursors.WaitCursor
        Grabar()
        Cursor = Cursors.Arrow
    End Sub

    Private Sub CurrencyTextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtPU.TextChanged

    End Sub
End Class