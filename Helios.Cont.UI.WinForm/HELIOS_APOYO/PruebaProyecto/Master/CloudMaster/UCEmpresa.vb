Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class UCEmpresa

    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
    Private Property datosGeneralesSA() As New datosGeneralesSA
    Dim listaCentrocosto As New List(Of centrocosto)
    Dim unidadID As Integer
    Dim Repository2 As FormRepositoryConfEmpresa


    Public Sub New(Repository As FormRepositoryConfEmpresa)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        FormatoGrid(dgPedidos)
        Repository2 = Repository
    End Sub

    Private Sub GetListaDatosGenerales()
        Try

            Dim objEmpresaSA As New empresaSA
            Dim objEmpresa As New empresa

            Dim dt As New DataTable("Datos Generales")
            dt.Columns.Add(New DataColumn("idEmpresa", GetType(String)))
            dt.Columns.Add(New DataColumn("razonSocial", GetType(String)))
            dt.Columns.Add(New DataColumn("direccion", GetType(String)))
            dt.Columns.Add(New DataColumn("inicioOperacion", GetType(String)))


            For Each i As empresa In objEmpresaSA.ObtenerListaEmpresas().ToList
                Dim dr As DataRow = dt.NewRow()

                dr(0) = (i.idEmpresa)
                dr(1) = i.razonSocial
                dr(2) = i.direccion
                dr(3) = i.inicioOperacion

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

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click
        GetListaDatosGenerales()
    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
        Dim M As New UCNuevoCliente()
        M.StartPosition = FormStartPosition.CenterParent
        M.ShowDialog()
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        Try

            If (Not IsNothing(dgPedidos.Table.CurrentRecord)) Then
                Gempresas = New GEmpresa
                Gempresas.IdEmpresaRuc = dgPedidos.Table.CurrentRecord.GetValue("idEmpresa")
                Repository2.btnOrganigrama.Visible = True
                Repository2.btnCargo.Visible = False
                Repository2.btnNumeracion.Visible = True
                Repository2.btnTipoDoc.Visible = False
                Repository2.btnProducto.Visible = False
                Repository2.btnApoyo.Visible = True
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton3.Click
        Try

            If (Not IsNothing(dgPedidos.Table.CurrentRecord)) Then
                Dim Login As New FormOrgainizacionV2(dgPedidos.Table.CurrentRecord.GetValue("idEmpresa"))
                Login.StartPosition = FormStartPosition.CenterParent
                Login.ShowDialog()
                Application.DoEvents()
                Me.Dispose()

            Else
                MessageBox.Show("Debe seleccionar una empresa para comenzar")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
