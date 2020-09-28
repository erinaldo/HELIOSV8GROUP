Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class TabMG_ModuloNumeracion

    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
    Private Property datosGeneralesSA() As New datosGeneralesSA

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        FormatoGrid(dgPedidos)
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetListaDatosGenerales()))
        thread.Start()
    End Sub

    Private Sub GetListaDatosGenerales()
        Dim objNumeracionBoletaSA As New NumeracionBoletaSA
        Dim objNumeracionBoleta As New numeracionBoletas

        Dim dt As New DataTable("Datos Generales")
        dt.Columns.Add(New DataColumn("IdEnumeracion", GetType(Integer)))
        dt.Columns.Add(New DataColumn("codigoNumeracion", GetType(String)))
        dt.Columns.Add(New DataColumn("tipo", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("valorInicial", GetType(Integer)))
        dt.Columns.Add(New DataColumn("valorMaximo", GetType(Integer)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))

        objNumeracionBoleta.empresa = Gempresas.IdEmpresaRuc
        objNumeracionBoleta.establecimiento = GEstableciento.IdEstablecimiento


        For Each i As numeracionBoletas In objNumeracionBoletaSA.GetListar_numeracionBoletasAll(objNumeracionBoleta).Where(Function(O) O.empresa = Gempresas.IdEmpresaRuc And O.establecimiento = GEstableciento.IdEstablecimiento).ToList
            Dim dr As DataRow = dt.NewRow()

            dr(0) = (i.IdEnumeracion)
            dr(1) = i.codigoNumeracion
            dr(2) = i.tipo
            dr(3) = i.serie
            dr(4) = i.valorInicial.GetValueOrDefault
            dr(5) = i.valorMaximo.GetValueOrDefault

            Select Case i.estado
                Case "A"
                    dr(6) = "ABIERTO"
                Case "C"
                    dr(6) = "CERRADO"
            End Select

            dt.Rows.Add(dr)
        Next
        setDatasource(dt)
    End Sub

    Public Sub setDatasource(ByVal table As DataTable)
        If Me.InvokeRequired Then
            Dim deleg As New SetDataSourceDelegate(AddressOf setDatasource)
            Invoke(deleg, New Object() {table})
        Else
            dgPedidos.DataSource = table
            ProgressBar1.Visible = False
        End If
    End Sub

    Private Sub Eliminar(idConfiguracion As Integer)
        Dim datosGeneralesSA As New datosGeneralesSA
        Try
            datosGeneralesSA.EliminarImpresion(New datosGenerales With {.idConfiguracion = idConfiguracion, .idEmpresa = Gempresas.IdEmpresaRuc})

            MessageBox.Show("Formato de impresión eliminado del sistema", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Try
            Dim f As New Form_CrearModuloNumeracion()
            f.BringToFront()
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
            Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetListaDatosGenerales()))
            thread.Start()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetListaDatosGenerales()))
        thread.Start()
    End Sub
End Class
