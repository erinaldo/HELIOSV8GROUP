Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class FormCatalogoUnidadComercial

    Public FormBase As FormExistenciaPreciosEquivalencia
    Public FormBase2 As UCPrincipalProductos
    Public Sub New(FormExistenciaPreciosEquivalencia As FormExistenciaPreciosEquivalencia)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormBase = FormExistenciaPreciosEquivalencia
        General.FormatoGridBlack(GridEquivalencia, False)

    End Sub

    Public Sub New(UCPrincipalProductos As UCPrincipalProductos)

        ' This call is required by the designer.
        InitializeComponent()
        FormBase2 = UCPrincipalProductos
        General.FormatoGridBlack(GridEquivalencia, False)
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub GetEquivalencias()
        Dim dt As New DataTable
        dt.Columns.Add("IDcatalog")
        dt.Columns.Add("nomCorto")
        dt.Columns.Add("nomLargo")
        dt.Columns.Add("estado")
        dt.Columns.Add("predeterminado")



        Dim producto = FormBase2.listaProductos.Where(Function(o) o.codigodetalle = TextProducto.Tag).SingleOrDefault


        'Dim producto = FormBase.listaProductos.Where(Function(o) o.codigodetalle = TextProducto.Tag).SingleOrDefault

        Dim listaUnidadesComercialesCatalogos = producto.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = TextUnidadComercial.Tag).SingleOrDefault

        For Each i In listaUnidadesComercialesCatalogos.detalleitemequivalencia_catalogos.ToList
            dt.Rows.Add(i.idCatalogo, i.nombre_corto, i.nombre_largo, If(i.estado = 1, False, True), i.predeterminado)
        Next
        GridEquivalencia.DataSource = dt
    End Sub

    Private Sub FormCatalogoUnidadComercial_Load(sender As Object, e As EventArgs) Handles Me.Load
        GetEquivalencias()
    End Sub

    Private Sub bunifuImageButton2_Click(sender As Object, e As EventArgs) Handles bunifuImageButton2.Click
        Close()
    End Sub

    Private Sub Editar(rowIndex As Integer, estado As Boolean)
        Dim catalogoSA As New detalleitemequivalencia_catalogosSA

        Dim producto = FormBase2.listaProductos.Where(Function(o) o.codigodetalle = TextProducto.Tag).SingleOrDefault

        Dim UnidadComercial = producto.detalleitem_equivalencias.Where(Function(o) o.equivalencia_id = TextUnidadComercial.Tag).SingleOrDefault

        Dim Catalogo_id As Integer = Me.GridEquivalencia.TableModel(rowIndex, 1).CellValue

        Dim nombreCorto As String = Me.GridEquivalencia.TableModel(rowIndex, 2).CellValue

        Dim nombreLargo As String = Me.GridEquivalencia.TableModel(rowIndex, 3).CellValue

        Dim predeterminado As Boolean = Boolean.Parse(Me.GridEquivalencia.TableModel(rowIndex, 5).CellValue)

        Dim obj As New detalleitemequivalencia_catalogos With
        {
        .Action = BaseBE.EntityAction.UPDATE,
        .idCatalogo = Catalogo_id,
        .codigodetalle = producto.codigodetalle,
        .equivalencia_id = UnidadComercial.equivalencia_id,
        .nombre_corto = nombreCorto,
        .nombre_largo = nombreLargo,
        .estado = If(estado = True, 0, 1),
        .predeterminado = predeterminado
        }
        Dim catalogo = catalogoSA.CatalogoPrecioSave(obj)

        Dim catalogoSel = UnidadComercial.detalleitemequivalencia_catalogos.Where(Function(o) o.idCatalogo = Catalogo_id).SingleOrDefault
        catalogoSel.estado = If(estado = True, 0, 1)


    End Sub

    Private Sub GridEquivalencia_TableControlCellClick(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs) Handles GridEquivalencia.TableControlCellClick

    End Sub

    Private Sub GridEquivalencia_TableControlCheckBoxClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridEquivalencia.TableControlCheckBoxClick
        Me.Cursor = Cursors.WaitCursor
        Dim obj As New documentocompra
        Dim RowIndex As Integer = e.Inner.RowIndex

        If RowIndex > -1 Then
            e.TableControl.CurrentCell.EndEdit()
            e.TableControl.Table.TableDirty = True
            e.TableControl.Table.EndEdit()

            Dim valCheck = Me.GridEquivalencia.TableModel(RowIndex, 4).CellValue
            Select Case valCheck
                Case "False" 'TRUE
                    Editar(RowIndex, True)
                    'MessageBox.Show(True)
                Case Else ' FALSE
                    Editar(RowIndex, False)
                    'MessageBox.Show(False)
            End Select
        End If
        Me.Cursor = Cursors.Arrow
    End Sub
End Class