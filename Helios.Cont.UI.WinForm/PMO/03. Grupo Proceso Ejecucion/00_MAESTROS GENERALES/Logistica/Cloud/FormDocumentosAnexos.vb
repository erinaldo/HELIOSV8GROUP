Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class FormDocumentosAnexos
    Private listaProductos As List(Of documentocompradetalle)

#Region "Attributes"
    Private Property CompraSA As New DocumentoCompraSA
    Private Property CompraDetalleSA As New DocumentoCompraDetalleSA
    Private Property idCompra As Integer
#End Region

#Region "Constructors"
    Public Sub New(idDocumento As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormatoGridAvanzado(GridProductos, True, False)
        GetDetalleCompra(idDocumento)
        idCompra = idDocumento
    End Sub
#End Region

#Region "Methods"
    Private Sub GetDetalleCompra(idDocumento As Integer)
        Dim dt As New DataTable()
        With dt.Columns
            .Add("codigo")
            .Add("gravado")
            .Add("idProducto")
            .Add("item")
            .Add("um")
            .Add("cantidad")
            .Add("totalmn")
        End With

        listaProductos = CompraDetalleSA.GetUbicarDetalleCompraLote(idDocumento).Where(Function(o) o.ItemEntregadototal = "S").ToList()

        For Each i In listaProductos
            dt.Rows.Add(i.secuencia, i.destino, i.idItem, i.descripcionItem, i.unidad1, i.monto1, i.importe)
        Next
        GridProductos.DataSource = dt
    End Sub
#End Region

#Region "Events"
    Private Sub FormDocumentosAnexos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub GridItems_TableControlCellDoubleClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridProductos.TableControlCellDoubleClick
        Dim loteSA As New recursoCostoLoteSA
        Dim guiaSa As New DocumentoGuiaDetalleSA
        If GridProductos.Table.SelectedRecords.Count Then

            Dim codigo = GridProductos.Table.CurrentRecord.GetValue("codigo")
            Dim obj = listaProductos.Where(Function(o) o.secuencia = codigo).Single  '  CompraDetalleSA.GetUbicar_documentocompradetallePorID(Integer.Parse(codigo))
            If obj.ItemEntregadototal = "N" Then
                MessageBox.Show("El producto seleccionado, está en transito", "Verificar almacén en transito", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If CheckBox1.Checked = True Then
                If Not IsNothing(obj) Then
                    Dim listaArticulosEnviados = guiaSa.GetAlmacenesDistribuidosParaEmision(codigo, idCompra)
                    For Each i In listaArticulosEnviados
                        'obj.CustomRecursoCostoLote = New Business.Entity.recursoCostoLote
                        obj.CustomRecursoCostoLote = loteSA.GetLoteByID(obj.codigoLote)
                        obj.almacenRef = i.almacenRef
                        Dim miInterfaz As IProductoCompra = TryCast(Me.Owner, IProductoCompra)
                        If miInterfaz IsNot Nothing Then miInterfaz.EnviarProducto(obj)
                    Next

                End If
            Else
                If Not IsNothing(obj) Then
                    'obj.CustomRecursoCostoLote = New Business.Entity.recursoCostoLote
                    obj.CustomRecursoCostoLote = loteSA.GetLoteByID(obj.CustomRecursoCostoLote.codigoLote)
                    Dim miInterfaz As IProductoCompra = TryCast(Me.Owner, IProductoCompra)
                    If miInterfaz IsNot Nothing Then miInterfaz.EnviarProducto(obj)
                End If
            End If


        End If
    End Sub

    Private Sub GridProductos_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridProductos.TableControlCellClick

    End Sub
#End Region


End Class