Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class UCNumeracion

    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
    Private Property datosGeneralesSA() As New datosGeneralesSA
    Dim listaCentrocosto As New List(Of centrocosto)
    Dim unidadID As Integer

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        FormatoGrid(dgPedidos)

    End Sub


    Private Sub cargarUnidad()
        Dim CentrocostosSA As New establecimientoSA

        listaCentrocosto = CentrocostosSA.ObtenerListaEstablecimientos(Gempresas.IdEmpresaRuc).ToList


        cboUnidadOrganica.ValueMember = "idCentroCosto"
        cboUnidadOrganica.DisplayMember = "nombre"
        cboUnidadOrganica.DataSource = listaCentrocosto
        cboUnidadOrganica.SelectedValue = -1

    End Sub

    Private Sub GetListaDatosGenerales()
        Try

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

            'objNumeracionBoleta.empresa = Gempresas.IdEmpresaRuc
            'objNumeracionBoleta.establecimiento = GEstableciento.IdEstablecimiento


            For Each i As numeracionBoletas In objNumeracionBoletaSA.GetListar_numeracionBoletasAll(objNumeracionBoleta).Where(Function(O) O.establecimiento = unidadID).ToList
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

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub setDatasource(ByVal table As DataTable)
        If Me.InvokeRequired Then
            Dim deleg As New SetDataSourceDelegate(AddressOf setDatasource)
            Invoke(deleg, New Object() {table})
        Else
            dgPedidos.DataSource = table
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

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click
        pnUnidadOrganica.Visible = True
        cargarUnidad()
    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
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

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click

    End Sub

    Private Sub BunifuFlatButton5_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton5.Click
        Try
            pnUnidadOrganica.Visible = False
            Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetListaDatosGenerales()))
            thread.Start()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BunifuFlatButton6_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton6.Click
        pnUnidadOrganica.Visible = False
    End Sub

    Private Sub cboUnidadOrganica_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboUnidadOrganica.SelectionChangeCommitted
        unidadID = cboUnidadOrganica.SelectedValue
    End Sub
End Class
