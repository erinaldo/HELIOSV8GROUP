Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class TabCM_RegistroDatosGenerales

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
        Dim objDatosGeneralesSA As New datosGeneralesSA
        Dim objDatosGenerales As New datosGenerales

        Dim dt As New DataTable("Datos Generales")
        dt.Columns.Add(New DataColumn("idConfiguracion", GetType(Integer)))
        dt.Columns.Add(New DataColumn("razonSocial", GetType(String)))
        dt.Columns.Add(New DataColumn("nombreCorto", GetType(String)))
        dt.Columns.Add(New DataColumn("ruc", GetType(String)))
        dt.Columns.Add(New DataColumn("direccion", GetType(String)))
        dt.Columns.Add(New DataColumn("nroImpresion", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipo", GetType(String)))
        dt.Columns.Add(New DataColumn("predeterminado", GetType(String)))

        objDatosGenerales.idEmpresa = Gempresas.IdEmpresaRuc
        objDatosGenerales.idEstablecimiento = GEstableciento.IdEstablecimiento

        Dim str As String
        For Each i As datosGenerales In objDatosGeneralesSA.UbicaEmpresaFull(objDatosGenerales)
            Dim dr As DataRow = dt.NewRow()

            dr(0) = (i.idConfiguracion)
            dr(1) = i.razonSocial
            dr(2) = i.nombreCorto
            dr(3) = i.ruc
            dr(4) = i.direccionPrincipal
            dr(5) = i.nroImpresion.GetValueOrDefault
            dr(6) = i.formatoImpresion
            Select Case i.predeterminado
                Case 0
                    dr(7) = "NO"
                Case 1
                    dr(7) = "SI"
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

    Private Sub updateImpresion(idConfiguracion As Integer)
        Dim datosGeneralesSA As New datosGeneralesSA
        Try

            datosGeneralesSA.updatePredeterminado(New datosGenerales With {.idConfiguracion = idConfiguracion, .idEmpresa = Gempresas.IdEmpresaRuc})

            MessageBox.Show("Impresión Pretederminado con exito", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Cursor = Cursors.WaitCursor
        If Not IsNothing(dgPedidos.Table.CurrentRecord) Then
            Dim f As New frmDatosGenerales(dgPedidos.Table.CurrentRecord.GetValue("idConfiguracion"))
            f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
            'f.btOperacion.Enabled = True
            f.BringToFront()
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
            Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetListaDatosGenerales()))
            thread.Start()
        Else
            MessageBox.Show("Debe seleccionar un pedido/venta!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Cursor = Cursors.WaitCursor
        If Not IsNothing(dgPedidos.Table.CurrentRecord) Then
            Dim f As New frmDatosGenerales(dgPedidos.Table.CurrentRecord.GetValue("idConfiguracion"))
            f.ManipulacionEstado = ENTITY_ACTIONS.DELETE
            'f.btOperacion.Enabled = False
            f.BringToFront()
            f.ShowDialog()
        Else
            MessageBox.Show("Debe seleccionar un pedido/venta!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Try

            Dim f As New frmDatosGenerales()
            f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
            'f.btOperacion.Enabled = True
            f.BringToFront()
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
            Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetListaDatosGenerales()))
            thread.Start()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetListaDatosGenerales()))
        thread.Start()
    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        Try

            If Not IsNothing(Me.dgPedidos.Table.CurrentRecord) Then
                If MessageBox.Show("Desea Eliminar el item seleccionado?", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Eliminar(Me.dgPedidos.Table.CurrentRecord.GetValue("idConfiguracion"))
                    dgPedidos.Table.CurrentRecord.Delete()
                    Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetListaDatosGenerales()))
                    thread.Start()
                    CustomListaDatosGenerales = datosGeneralesSA.UbicaEmpresaFull(New datosGenerales With {.idEmpresa = Gempresas.IdEmpresaRuc})
                End If
            Else
                MessageBox.Show("Debe seleccionar un item válido!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click
        Try
            Cursor = Cursors.WaitCursor
            If Not IsNothing(Me.dgPedidos.Table.CurrentRecord) Then
                'If MessageBox.Show("Desea Eliminar el item seleccionado?", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                updateImpresion(Me.dgPedidos.Table.CurrentRecord.GetValue("idConfiguracion"))
                Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetListaDatosGenerales()))
                thread.Start()
                CustomListaDatosGenerales = datosGeneralesSA.UbicaEmpresaFull(New datosGenerales With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento})
                'End If
            Else
                MessageBox.Show("Debe seleccionar un item válido!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs) Handles ToolStripButton9.Click
        Dim f As New Tab_FormatoImpresion()
        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        f.btOperacion.Enabled = True
        f.BringToFront()
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
    End Sub
End Class
