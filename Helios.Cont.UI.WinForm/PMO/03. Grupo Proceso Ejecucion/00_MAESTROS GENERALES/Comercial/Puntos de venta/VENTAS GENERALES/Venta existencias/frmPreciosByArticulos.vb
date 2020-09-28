Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Public Class frmPreciosByArticulos
    Inherits frmMaster

    Protected precioSA As ConfiguracionPrecioProductoSA
    Protected record As Record

    Public Sub New(r As Record)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UbicarUltimosPreciosXproducto(r)
        txtArticulo.Tag = r.GetValue("idProducto")
        txtArticulo.Text = r.GetValue("item")
        record = r
    End Sub

    Public Sub New(be As detalleitems)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        txtArticulo.Tag = be.codigodetalle
        txtArticulo.Text = be.descripcionItem
        UbicarUltimosPreciosXproductoV2(be.codigodetalle)
    End Sub

#Region "Métodos"
    Public Sub UbicarUltimosPreciosXproducto(r As Record)
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim dt As New DataTable("Historial de últimas entradas ")
        dt.Columns.Add("fecha")
        dt.Columns.Add("idPrecio")
        dt.Columns.Add("Precio")
        dt.Columns.Add("tipoConfig")
        dt.Columns.Add("tasa")
        dt.Columns.Add("Preciomn")
        dt.Columns.Add("Preciome")

        For Each i In precioSA.ListarPreciosXproductoMaxFecha(0, r.GetValue("idProducto"))
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.fecha
            dr(1) = i.idPrecio
            dr(2) = i.descripcion
            dr(3) = IIf(i.tipo = "P", "%", "Fijo")
            dr(4) = i.valPorcentaje
            dr(5) = i.precioMN
            dr(6) = i.precioME
            dt.Rows.Add(dr)
        Next
        GridGroupingControl2.DataSource = dt
        GridGroupingControl2.TableOptions.ListBoxSelectionMode = SelectionMode.One
        GridGroupingControl2.Visible = True
    End Sub

    Public Sub UbicarUltimosPreciosXproductoV2(intIdItem As Integer)
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim dt As New DataTable("Historial de últimas entradas ")
        dt.Columns.Add("fecha")
        dt.Columns.Add("idPrecio")
        dt.Columns.Add("Precio")
        dt.Columns.Add("tipoConfig")
        dt.Columns.Add("tasa")
        dt.Columns.Add("Preciomn")
        dt.Columns.Add("Preciome")

        For Each i In precioSA.ListarPreciosXproductoMaxFecha(0, intIdItem)
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.fecha
            dr(1) = i.idPrecio
            dr(2) = i.descripcion
            dr(3) = IIf(i.tipo = "P", "%", "Fijo")
            dr(4) = i.valPorcentaje
            dr(5) = i.precioMN
            dr(6) = i.precioME
            dt.Rows.Add(dr)
        Next
        GridGroupingControl2.DataSource = dt
        GridGroupingControl2.TableOptions.ListBoxSelectionMode = SelectionMode.One
        GridGroupingControl2.Visible = True
    End Sub

#End Region

    Private Sub frmPreciosByArticulos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub RoundButton21_Click(sender As Object, e As EventArgs) Handles RoundButton21.Click
        Dim r As Record = GridGroupingControl2.Table.CurrentRecord
        If r IsNot Nothing Then
            precioSA = New ConfiguracionPrecioProductoSA
            precioSA.EliminarPrecio(New configuracionPrecioProducto With {.idPrecio = r.GetValue("idPrecio"), .idproducto = txtArticulo.Tag, .fecha = r.GetValue("fecha")})
            RoundButton22_Click(sender, e)
        Else
            MessageBox.Show("Debe seleccionar un precio!", "Seleccionar fila", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub RoundButton22_Click(sender As Object, e As EventArgs) Handles RoundButton22.Click
        If record IsNot Nothing Then
            UbicarUltimosPreciosXproducto(record)
        Else
            UbicarUltimosPreciosXproductoV2(txtArticulo.Tag)
        End If
    End Sub
End Class