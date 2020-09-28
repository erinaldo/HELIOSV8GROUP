Imports Helios.Cont.Business.Entity

Public Class UCCondicionesPago
#Region "Attributes"
    Public Property FormCompra As FormCrearCompra
    Public UCPagoCompletoDocumento As UCPagoCompletoDocumento
#End Region

#Region "Constructors"
    Public Sub New(FormCrearCompra As FormCrearCompra)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UCPagoCompletoDocumento = New UCPagoCompletoDocumento(FormCrearCompra.ListaPagos, FormCrearCompra.UCEstructuraDocumentocabecera)
        UCPagoCompletoDocumento.Dock = DockStyle.Fill
        UCPagoCompletoDocumento.BringToFront()
        PanelBody.Controls.Add(UCPagoCompletoDocumento)
        FormCompra = FormCrearCompra
        '  GetListaProductos(FormCrearCompra.UCEstructuraDocumentocabecera.ListaproductosComprados)
    End Sub
#End Region

#Region "Methods"
    'Public Sub GetListaProductos(listaproductosComprados As List(Of documentocompradetalle))
    '    Dim dt As New DataTable
    '    dt.Columns.Add("codigo")
    '    dt.Columns.Add("gravado")
    '    dt.Columns.Add("idProducto")
    '    dt.Columns.Add("item")
    '    dt.Columns.Add("um")
    '    dt.Columns.Add("contenido")
    '    dt.Columns.Add("totalmn")
    '    dt.Columns.Add("Pago")
    '    dt.Columns.Add("saldo")

    '    For Each i In listaproductosComprados
    '        dt.Rows.Add(i.CodigoCosto,
    '                    i.CustomProducto.origenProducto,
    '                    i.CustomProducto.codigodetalle,
    '                    i.CustomProducto.descripcionItem,
    '                    i.CustomProducto.unidad1,
    '                    i.CustomProducto.composicion,
    '                    i.importe, i.MontoPago, i.MontoSaldo)

    '    Next
    '    GridCompra.DataSource = dt
    'End Sub

    Private Sub GenerarPagoPorDocumento(MontoTotalPago As Decimal)
        Dim montoPago = MontoTotalPago

        For Each i In FormCompra.UCEstructuraDocumentocabecera.ListaproductosComprados
            If montoPago > 0 Then
                If i.MontoSaldo > montoPago Then
                    Dim canUso = montoPago
                    i.MontoPago = canUso
                    i.estadoPago = i.ItemPendiente
                ElseIf i.MontoSaldo = montoPago Then
                    i.MontoPago = montoPago
                    i.estadoPago = i.ItemSaldado
                Else
                    Dim canUso = i.MontoSaldo
                    i.MontoPago = canUso
                    i.estadoPago = i.ItemSaldado
                End If
                montoPago -= i.MontoPago

                i.estadoPago = i.estadoPago
            End If
        Next
    End Sub
#End Region

#Region "Events"
    Private Sub BunifuThinButton23_Click(sender As Object, e As EventArgs)
        'If TextAcuenta.DecimalValue > 0 Then
        '    GenerarPagoPorDocumento(TextAcuenta.DecimalValue)
        'End If
    End Sub

    Private Sub RadioButton6_CheckedChanged(sender As Object, e As EventArgs) Handles RBNo.CheckedChanged
        If RBNo.Checked = True Then
            GroupBox2.Visible = False
            GroupBox1.Visible = False
            PanelBody.Visible = False

            If FormCompra IsNot Nothing Then
                If FormCompra.UCEstructuraDocumentocabecera IsNot Nothing Then
                    For Each i In FormCompra.UCEstructuraDocumentocabecera.ListaproductosComprados.ToList
                        i.CustomDocumentoCaja = New List(Of documentoCaja)
                        i.MontoPago = 0
                        i.estadoPago = "PN"
                    Next
                End If
                If FormCompra.UCCondicionesPago IsNot Nothing Then
                    If FormCompra.UCCondicionesPago.UCPagoCompletoDocumento IsNot Nothing Then
                        FormCompra.UCCondicionesPago.UCPagoCompletoDocumento.DocCaja = New List(Of documento)
                        FormCompra.UCCondicionesPago.UCPagoCompletoDocumento.GridCompra.Table.Records.DeleteAll()
                        FormCompra.UCCondicionesPago.UCPagoCompletoDocumento.ListDetalle.Items.Clear()
                    End If
                End If
            End If

        End If
    End Sub

    Private Sub RadioButton7_CheckedChanged(sender As Object, e As EventArgs) Handles RBSi.CheckedChanged
        If RBSi.Checked = True Then
            GroupBox2.Visible = True
            GroupBox1.Visible = True
            PanelBody.Visible = True
        End If
    End Sub
#End Region
End Class
