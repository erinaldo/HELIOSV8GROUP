Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Public Class UCInventarioInicial
#Region "Attributes"
    Private compras As List(Of documentocompra)
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(dgvKardexVal, True, False, 9.0F)
        ' AddCompras()
        'LoadLSV()
        '  ListView3.FullRowSelect = True
    End Sub
#End Region

#Region "Methods"
    Public Sub GetLoadGRID(idDocumento As Integer)
        Dim conteo As Integer = 1
        Dim dt As New DataTable
        dt.Columns.Add("Numero")
        dt.Columns.Add("Afectacion")
        dt.Columns.Add("TipoExistencia")
        dt.Columns.Add("Producto")
        dt.Columns.Add("Unidad")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("preciounitario")
        dt.Columns.Add("ImporteTotal")
        dt.Columns.Add("Almacen")

        Dim doc = compras.Where(Function(o) o.idDocumento = idDocumento).SingleOrDefault

        For Each i In doc.documentocompradetalle.ToList
            dt.Rows.Add(conteo, i.destino, i.tipoExistencia, i.descripcionItem, i.unidad1, i.monto1, i.precioUnitario.GetValueOrDefault, i.importe, i.almacenRef)
            conteo += 1
        Next
        dgvKardexVal.DataSource = dt
    End Sub

    Public Sub AddCompras()
        Dim compraSA As New DocumentoCompraSA

        compras = compraSA.GetInventarioInicial(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento})

    End Sub

    Public Sub LoadLSV()
        ListView3.Items.Clear()

        For Each i In compras.ToList
            Dim usuarioSel = UsuariosList.Where(Function(o) o.IDUsuario = i.usuarioActualizacion).SingleOrDefault

            Dim n As New ListViewItem(i.idDocumento)
            n.SubItems.Add(i.fechaDoc)
            n.SubItems.Add(If(usuarioSel IsNot Nothing, usuarioSel.Full_Name, "-"))
            ListView3.Items.Add(n)
        Next
        ListView3.Refresh()
    End Sub

    Private Sub ListView3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView3.SelectedIndexChanged
        If ListView3.SelectedItems.Count > 0 Then
            GetLoadGRID(Integer.Parse(ListView3.SelectedItems(0).SubItems(0).Text))
        End If
    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
        If ListView3.SelectedItems.Count > 0 Then
            GetLoadGRID(Integer.Parse(ListView3.SelectedItems(0).SubItems(0).Text))
        End If
    End Sub

    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton3.Click
        Dim f As New FormImportarExcelInventario
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click

    End Sub


#End Region
End Class
