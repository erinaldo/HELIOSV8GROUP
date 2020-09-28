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
Imports System.Collections
Imports System.Collections.Specialized
Imports Syncfusion.Windows.Forms.Tools

Public Class frmCobroMensualProveedor
    Inherits frmMaster

#Region "Metodos"


    Private Sub ProgramacionObligaciones(idprov As Integer, tipoprov As String)
        Dim documentoVentaSA As New CronogramaSA
        Dim documentoLibro As New List(Of Cronograma)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable
        Dim entidadSA As New entidadSA
        Dim personaSA As New PersonaSA
        'Dim monto As Decimal = CDec(0.0)
        'Dim montome As Decimal = CDec(0.0)
        'Dim strPeriodo As String = String.Format("{0:00}", Convert.ToInt32(txtPeriodo.Value.Month)) & "/" & txtPeriodo.Value.Year

        dgvObligaciones.Table.Records.DeleteAll()


        dt.Columns.Add("monto", GetType(Decimal))
        dt.Columns.Add("montome", GetType(Decimal))
        dt.Columns.Add("periodo", GetType(String))



        documentoLibro = documentoVentaSA.UbicarCronogramaPorEntidadCobro(idprov, tipoprov)


        If Not IsNothing(documentoLibro) Then


            For Each i In documentoLibro
                Dim dr As DataRow = dt.NewRow()

                dr(0) = i.montoAutorizadoMN
                dr(1) = i.montoAutorizadoME
                dr(2) = i.fechaContable

                dt.Rows.Add(dr)

            Next

            dgvObligaciones.DataSource = dt

            'dgvObligaciones.TableDescriptor.Columns("fecha").Width = 0
            'dgvObligaciones.TableDescriptor.Columns("fechaPago").Width = 0

        Else

        End If
    End Sub

    Public Sub UbicarCobrosAnual()

        Dim documentoVentaSA As New CronogramaSA
        Dim documentoLibro As New List(Of Cronograma)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable
        Dim enero As Decimal = CDec(0.0)
        Dim febrero As Decimal = CDec(0.0)
        Dim marzo As Decimal = CDec(0.0)
        Dim abril As Decimal = CDec(0.0)
        Dim mayo As Decimal = CDec(0.0)
        Dim junio As Decimal = CDec(0.0)
        Dim julio As Decimal = CDec(0.0)
        Dim agosto As Decimal = CDec(0.0)
        Dim setiembre As Decimal = CDec(0.0)
        Dim octubre As Decimal = CDec(0.0)
        Dim noviembre As Decimal = CDec(0.0)
        Dim diciembre As Decimal = CDec(0.0)


        dt.Columns.Add("enero", GetType(Decimal))
        dt.Columns.Add("febrero", GetType(Decimal))
        dt.Columns.Add("marzo", GetType(Decimal))
        dt.Columns.Add("abril", GetType(Decimal))
        dt.Columns.Add("mayo", GetType(Decimal))
        dt.Columns.Add("junio", GetType(Decimal))
        dt.Columns.Add("julio", GetType(Decimal))
        dt.Columns.Add("agosto", GetType(Decimal))
        dt.Columns.Add("setiembre", GetType(Decimal))
        dt.Columns.Add("octubre", GetType(Decimal))
        dt.Columns.Add("noviembre", GetType(Decimal))
        dt.Columns.Add("diciembre", GetType(Decimal))


        documentoLibro = documentoVentaSA.GetListarCobrosPorMes("C")

        If Not IsNothing(documentoLibro) Then


            For Each i In documentoLibro


                Select Case i.fechaContable
                    Case "01/" & AnioGeneral
                        enero = i.montoAutorizadoMN
                    Case "02/" & AnioGeneral
                        febrero = i.montoAutorizadoMN
                    Case "03/" & AnioGeneral
                        marzo = i.montoAutorizadoMN
                    Case "04/" & AnioGeneral
                        abril = i.montoAutorizadoMN
                    Case "05/" & AnioGeneral
                        mayo = i.montoAutorizadoMN
                    Case "06/" & AnioGeneral
                        junio = i.montoAutorizadoMN
                    Case "07/" & AnioGeneral
                        julio = i.montoAutorizadoMN
                    Case "08/" & AnioGeneral
                        agosto = i.montoAutorizadoMN
                    Case "09/" & AnioGeneral
                        setiembre = i.montoAutorizadoMN
                    Case "10/" & AnioGeneral
                        octubre = i.montoAutorizadoMN
                    Case "11/" & AnioGeneral
                        noviembre = i.montoAutorizadoMN
                    Case "12/" & AnioGeneral
                        diciembre = i.montoAutorizadoMN
                End Select
            Next

            Dim dr As DataRow = dt.NewRow()
            dr(0) = enero
            dr(1) = febrero
            dr(2) = marzo
            dr(3) = abril
            dr(4) = mayo
            dr(5) = junio
            dr(6) = julio
            dr(7) = agosto
            dr(8) = setiembre
            dr(9) = octubre
            dr(10) = noviembre
            dr(11) = diciembre
            dt.Rows.Add(dr)
            'txtImporteMN.Value = monto
            'txtImporteME.Value = montome

            GridGroupingControl1.DataSource = dt
            'dgvProcesoCrono.ShowGroupDropArea = False
            'dgvProcesoCrono.TableDescriptor.GroupedColumns.Clear()
            'dgvProcesoCrono.TableDescriptor.GroupedColumns.Add("nombres")

            Me.GridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One


        Else

        End If

    End Sub

    Public Sub CargarTrabajadoresXnivel(strNivel As String, strBusqueda As String)
        Dim personaSA As New PersonaSA
        Try
            lsvProveedor.Items.Clear()
            For Each i In personaSA.ObtenerPersonaNumDocPorNivelxDescripcion(Gempresas.IdEmpresaRuc, strNivel, strBusqueda)
                Dim n As New ListViewItem(i.idPersona)
                n.SubItems.Add(i.nombreCompleto)
                n.SubItems.Add(String.Empty)
                n.SubItems.Add(i.idPersona)
                lsvProveedor.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub


    Public Sub CargarEntidadesXtipo(strTipo As String, strBusqueda As String)
        Dim entidadSA As New entidadSA
        Try
            lsvProveedor.Items.Clear()
            For Each i As entidad In entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, strTipo, strBusqueda)
                Dim n As New ListViewItem(i.idEntidad)
                n.SubItems.Add(i.nombreCompleto)
                n.SubItems.Add(i.cuentaAsiento)
                n.SubItems.Add(i.nrodoc)
                lsvProveedor.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub
#End Region

    Private Sub frmCobroMensualProveedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtProveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProveedor.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Me.popupControlContainer1.ParentControl = Me.txtProveedor
            Me.popupControlContainer1.ShowPopup(Point.Empty)
            If chProv.Checked = True Then
                CargarEntidadesXtipo(TIPO_ENTIDAD.PROVEEDOR, txtProveedor.Text.Trim)
            ElseIf chTrab.Checked = True Then
                CargarTrabajadoresXnivel("TR", txtProveedor.Text.Trim)
            ElseIf chCli.Checked = True Then
                CargarEntidadesXtipo(TIPO_ENTIDAD.CLIENTE, txtProveedor.Text.Trim)
            End If
        End If
    End Sub

    Private Sub txtProveedor_TextChanged(sender As Object, e As EventArgs) Handles txtProveedor.TextChanged

    End Sub

    Private Sub popupControlContainer1_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles popupControlContainer1.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvProveedor.SelectedItems.Count > 0 Then
                Me.txtProveedor.Text = lsvProveedor.SelectedItems(0).SubItems(1).Text
                txtProveedor.Tag = lsvProveedor.SelectedItems(0).SubItems(0).Text
                txtRuc.Text = lsvProveedor.SelectedItems(0).SubItems(3).Text
                'txtCuenta = lsvProveedor.SelectedItems(0).SubItems(2).Text
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtProveedor.Focus()
        End If
    End Sub

    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvProveedor.MouseDoubleClick
        If lsvProveedor.SelectedItems.Count > 0 Then
            Me.popupControlContainer1.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub lsvProveedor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvProveedor.SelectedIndexChanged

    End Sub

    Private Sub ButtonAdv15_Click(sender As Object, e As EventArgs) Handles ButtonAdv15.Click
        Me.Cursor = Cursors.WaitCursor
        If txtProveedor.Text.Trim.Length > 0 Then



            If Not IsNothing(txtProveedor.Tag) Then

            Else
                MessageBox.Show("Ingrese una Identificacion ", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtProveedor.Focus()
                Exit Sub
            End If




            If chProv.Checked = True Then

                ProgramacionObligaciones(txtProveedor.Tag, "PR")
            ElseIf chTrab.Checked = True Then

                ProgramacionObligaciones(txtProveedor.Tag, "TR")
            ElseIf chCli.Checked = True Then

                ProgramacionObligaciones(txtProveedor.Tag, "CL")
            End If

        Else
            'lblEstado.Text = "Seleccione un proveedor antes de realizar la tarea!"
            'PanelError.Visible = True
            'Timer1.Enabled = True
            'TiempoEjecutar(10)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub chProv_Click(sender As Object, e As EventArgs) Handles chProv.Click
        chProv.Checked = True
        chTrab.Checked = False
        chCli.Checked = False
        txtProveedor.Clear()
        txtRuc.Clear()
    End Sub

    Private Sub chTrab_Click(sender As Object, e As EventArgs) Handles chTrab.Click
        chProv.Checked = False
        chTrab.Checked = True
        chCli.Checked = False
        txtProveedor.Clear()
        txtRuc.Clear()
    End Sub

    Private Sub chCli_Click(sender As Object, e As EventArgs) Handles chCli.Click
        chProv.Checked = False
        chTrab.Checked = False
        chCli.Checked = True
        txtProveedor.Clear()
        txtRuc.Clear()
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        UbicarCobrosAnual()
    End Sub
End Class