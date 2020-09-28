Imports Helios.Cont.WCFService.ServiceAccess

Public Class FormViewVentaGeneral

#Region "Attributes"
    Public Property ventaSA As New documentoVentaAbarrotesSA
    Public Property documentoSA As New DocumentoSA
#End Region

#Region "Methods"
    Private Sub GetVenta(idDocumento As Integer)
        Dim entidadSA As New entidadSA
        Dim venta = ventaSA.GetVentaID(New Business.Entity.documento With {.idDocumento = idDocumento})
        Dim ent = entidadSA.UbicarEntidadPorID(venta.idCliente).FirstOrDefault
        LabelFecha.Text = $"{"Fecha: "}{venta.fechaDoc}"
        TextComprador.Text = venta.nombrePedido
        TextNumeroVenta.Text = $"{venta.serieVenta}-{venta.numeroVenta}"
        If venta IsNot Nothing Then
            Select Case venta.tipoDocumento
                Case "01"
                    ComboComprobante.Text = "FACTURA ELECTRONICA"
                Case "03"
                    ComboComprobante.Text = "BOLETA ELECTRONICA"
                Case "9907"
                    ComboComprobante.Text = "NOTA DE VENTA"
                Case Else
                    ComboComprobante.Text = "PROFORMA"
            End Select
        End If

        TextCliente.Text = ent.nombreCompleto
        TextCliente.Tag = ent.idEntidad
        txtruc.Text = ent.nrodoc

        TextBaseImponible.DecimalValue = venta.bi01
        TextIVA.DecimalValue = venta.igv01
        TextTotal.DecimalValue = venta.ImporteNacional
        DigitalGauge2.Value = venta.ImporteNacional

        Dim dt As New DataTable
        dt.Columns.Add("codigo")
        dt.Columns.Add("gravado")
        dt.Columns.Add("idProducto")
        dt.Columns.Add("item")
        dt.Columns.Add("um")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("vcmn")
        dt.Columns.Add("totalmn")
        dt.Columns.Add("igvmn")
        dt.Columns.Add("pumn")
        dt.Columns.Add("tipoPrecio")
        dt.Columns.Add("totalpagar")

        For Each i In venta.documentoventaAbarrotesDet.ToList
            dt.Rows.Add(i.secuencia, i.destino, i.idItem, i.nombreItem, i.unidad1, i.monto1, i.montokardex, 0, i.montoIgv, i.precioUnitario, "-", i.importeMN)
        Next

        dgvCompra.DataSource = dt
    End Sub
#End Region

#Region "Constructors"
    Public Sub New(idDocumento As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GetVenta(idDocumento)
    End Sub


#End Region
End Class