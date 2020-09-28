Imports System.Threading
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class UCClasificacionInfraestructura

#Region "Attributes"
    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
    Private Thread As Thread
    Dim filter As New GridExcelFilter()
#End Region

#Region "Constructors"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
        Dim f As New frmNuevaClasificacionInfraestructura
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        CargarCategoria()
    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click
        Cursor = Cursors.WaitCursor
        If Not IsNothing(dgvCompras.Table.CurrentRecord) Then
            Dim f As New frmNuevaClasificacionInfraestructura(dgvCompras.Table.CurrentRecord.GetValue("idEntidad"))
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            CargarCategoria()
        Else
            MessageBox.Show("Debe seleccionar una categoria!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton3.Click
        FormatoGridAvanzado(dgvCompras, True, False, 9.0F, SelectionMode.MultiExtended)
        Dim empresa As String = Gempresas.IdEmpresaRuc
        PictureLoad.Visible = True
        Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() CargarCategoria()))
        Thread.Start()

    End Sub

#End Region

#Region "Methods"

    Private Sub CargarCategoria()
        Try

            Dim categoriaInfraestructuraBE As New categoriaInfraestructura
            Dim categoriaInfraestructuraSA As New categoriaInfraestructuraSA
            Dim listacategoriaInfraestructura As New List(Of categoriaInfraestructura)

            categoriaInfraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
            categoriaInfraestructuraBE.idEstablecimiento = GEstableciento.IdEstablecimiento

            listacategoriaInfraestructura = categoriaInfraestructuraSA.GetUbicarCategoriaInfraestructura(categoriaInfraestructuraBE)

            Dim dt As New DataTable
            With dt.Columns
                .Add("idComponente")
                .Add("idPadre")
                .Add("descripcionItem")
                .Add("tipo")
                .Add("estado")
            End With

            For Each i In listacategoriaInfraestructura
                Dim dr As DataRow = dt.NewRow()
                dr(0) = i.idCategoria
                dr(1) = ""
                dr(2) = i.descripcionInfraestructura
                dr(3) = "C"
                dr(4) = "A"
                dt.Rows.Add(dr)
            Next
            setDatasource(dt)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub setDatasource(ByVal table As DataTable)
        If Me.InvokeRequired Then
            Dim deleg As New SetDataSourceDelegate(AddressOf setDatasource)
            Invoke(deleg, New Object() {table})
        Else
            dgvCompras.DataSource = table
            PictureLoad.Visible = False
        End If
    End Sub

    Private Sub ElimnarItem(idCategoria As Integer)
        Dim categoriaInfraestructuraSA As New categoriaInfraestructuraSA
        Dim objcategoriaInfraestructura As New categoriaInfraestructura
        Try
            With objcategoriaInfraestructura
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                .idCategoria = idCategoria
            End With

            'categoriaInfraestructuraSA.DeleteCategoria(objcategoriaInfraestructura)
            dgvCompras.Table.CurrentRecord.Delete()
            MessageBox.Show("venta anulada!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

#End Region

End Class
