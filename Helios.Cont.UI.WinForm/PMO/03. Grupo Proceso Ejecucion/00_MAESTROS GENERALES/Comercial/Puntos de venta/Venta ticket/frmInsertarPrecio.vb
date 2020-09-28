Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Public Class frmInsertarPrecio
    Inherits frmMaster



#Region "metodos"
    Public Sub GrabarPrecio()


        Dim TC As Decimal = TmpTipoCambio
        Dim objConfiEO As New listadoPrecios
        Dim ListadoSA As New ListadoPrecioSA
        Dim totalesAlmacenSA As New TotalesAlmacenSA
        Dim ListaPrecioFull As New List(Of listadoPrecios)

        Dim tipoExistencia As String
        Dim destinoGravado As String
        Dim presentacion As String
        Dim unidad As String

        Dim items As New listadoPrecios
        Try
            ' If e.Inner.ColIndex = 18 Then

            'If CDec(Me.dgvCompra.TableModel(e.Inner.RowIndex, 9).CellValue) > 0 Then
            With totalesAlmacenSA.GetUbicarProductoTAlmacen(CInt(txtalmacen.Text), CInt(txtid.Text))
                tipoExistencia = .tipoExistencia
                destinoGravado = .origenRecaudo
                presentacion = .Presentacion
                unidad = Nothing ' lblUnidad.Text
            End With

            objConfiEO = New listadoPrecios
            With objConfiEO
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                .tipoExistencia = tipoExistencia
                .destinoGravado = destinoGravado
                .idItem = CInt(txtid.Text)
                .descripcion = txtDescripcion.Text
                .presentacion = presentacion
                .unidad = Nothing ' lblUnidad.Text
                .fecha = DateTime.Now
                .tipoConfiguracion = "F"
                .porcUtimenor = 0
                .porcUtimayor = 0
                .porcUtigranmayor = 0
                .vcmenor = 0
                .vcmenorme = 0
                .vcmayor = 0
                .vcmayorme = 0
                .vcgranmayor = 0
                .vcgranmayorme = 0
                .montoUtimenor = 0
                .montoUtimenorme = 0
                .montoUtimayor = 0
                .montoUtimayorme = 0
                .montoUtigranmayor = 0
                .montoUtigranmayorme = 0

                .vvmenor = 0
                .vvmenorme = 0

                .vvmayor = 0
                .vvmayorme = 0

                .vvgranmayor = 0
                .vvgranmayorme = 0

                .igvmenor = 0
                .igvmenormeme = 0

                .igvmayor = 0
                .igvmayormeme = 0

                .igvgranmayor = 0
                .igvgranmayorme = 0


                .pvmenor = CDec(txtxmenor.Text)
                .pvmenorme = Math.Round(CDec(txtxmenor.Text) / TmpTipoCambio, 2)

                .pvmayor = CDec(txtxmayor.Text)
                .pvmayorme = Math.Round(CDec(txtxmayor.Text) / TmpTipoCambio, 2)

                .pvgranmayor = CDec(txtxgranmayor.Text)
                .pvgranmayorme = Math.Round(CDec(txtxgranmayor.Text) / TmpTipoCambio, 2)
            End With

            Dim cod = ListadoSA.InsertarPrecioVV(objConfiEO)

            Dispose()
        Catch

        End Try

    End Sub

#End Region
    Private Sub frmInsertarPrecio_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmInsertarPrecio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtTipoCambio.Text = TmpTipoCambio
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If CDec(txtxmenor.Text) >= 1 Then
            If CDec(txtxmayor.Text) >= 1 Then
                If CDec(txtxgranmayor.Text) >= 1 Then
                    GrabarPrecio()
                Else
                    MessageBox.Show("ingrese una cantidad mayor a 0")
                End If
            Else
                MessageBox.Show("ingrese una cantidad mayor a 0")
            End If
        Else
            MessageBox.Show("ingrese una cantidad mayor a 0")
        End If
    End Sub

   

    

    Private Sub txtxmenor_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtxmayor_KeyDown(sender As Object, e As KeyEventArgs)
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                txtxgranmayor.Select()
            End If
        Catch ex As Exception
            'lblEstado.Text = ex.Message
            txtxgranmayor.Clear()
        End Try
    End Sub

    

    Private Sub txtxmayor_TextChanged(sender As Object, e As EventArgs)

    End Sub

    

    Private Sub txtxgranmayor_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not (Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar)) Then
            e.Handled = True
        End If

        If txtxgranmayor.Text.Trim.Length > 0 Then

            txtxgranmayorme.Text = txtxgranmayor.Text * TmpTipoCambio
        End If
    End Sub

    Private Sub txtxgranmayor_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dispose()
    End Sub

    Private Sub txtTotalBase_KeyDown(sender As Object, e As KeyEventArgs) Handles txtxmenor.KeyDown
        If txtxmenor.Text.Trim.Length > 0 Then

            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                txtxmenorme.Text = txtxmenor.Text / TmpTipoCambio
                txtxmayor.Select()
            End If


        End If
    End Sub

    Private Sub txtTotalBase_TextChanged(sender As Object, e As EventArgs) Handles txtxmenor.TextChanged

    End Sub

    Private Sub txtxmayor_KeyDown1(sender As Object, e As KeyEventArgs) Handles txtxmayor.KeyDown
        If txtxmayor.Text.Trim.Length > 0 Then



            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                txtxmayorme.Text = txtxmayor.Text / TmpTipoCambio
                txtxgranmayor.Select()
            End If

        End If
    End Sub

    Private Sub CurrencyTextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtxmayor.TextChanged
        
    End Sub

    Private Sub CurrencyTextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtxgranmayor.KeyDown
        If txtxgranmayor.Text.Trim.Length > 0 Then


            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                txtxgranmayorme.Text = txtxgranmayor.Text / TmpTipoCambio
                txtxmenor.Select()
            End If
        End If
    End Sub

    Private Sub CurrencyTextBox2_TextChanged(sender As Object, e As EventArgs) Handles txtxgranmayor.TextChanged

    End Sub
End Class