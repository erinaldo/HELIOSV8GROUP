Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Tools

Public Class frmNegociacionCobross

    Inherits frmMaster

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        txtCliente.BorderStyle = BorderStyle.None
        txtRuc.BorderStyle = BorderStyle.None
        txtTipoProv.BorderStyle = BorderStyle.None
        txtSerie.BorderStyle = BorderStyle.None
        txtNumero.BorderStyle = BorderStyle.None
        txtDescripcion.BorderStyle = BorderStyle.None
        txtCuenta.BorderStyle = BorderStyle.None
        txtfechaprogramacion.BorderStyle = BorderStyle.None
        txtMoneda.BorderStyle = BorderStyle.None
        txtImporteCompramn.BorderStyle = BorderStyle.None
        txtImporteComprame.BorderStyle = BorderStyle.None


        ' Add any initialization after the InitializeComponent() call.
        'GridCFG(dgvPagosV)
        GridCFG(dgvPagosProgramados)
        GetTableGrid2()

        txtfechaprogramacion.Value = DateTime.Now
        txtfechaprogramacion.Value = DateTime.Now
        'txtPeriodo.Value = New DateTime(AnioGeneral, MesGeneral, DateTime.Now.Day)

        'getConfigGrid()
    End Sub

#Region "Metodos"


    Sub GrabarCronogramaAsiento()
        Dim cronoSA As New CronogramaSA
        Dim obj As New Cronograma
        Dim lista As New List(Of Cronograma)
        Try
            For Each i As Record In dgvPagosProgramados.Table.Records

                If i.GetValue("pago") > 0 Then
                    obj = New Cronograma

                    ' obj.identidad = i.GetValue("idProveedor")
                    Dim prove As Integer = i.GetValue("idproveedor")
                    obj.identidad = prove
                    'obj.tipoRazon = i.GetValue("tipoProv")
                    'obj.tipoRazon = "PR"

                    'obj.moneda = i.GetValue("moneda")
                    If i.GetValue("moneda") = "NAC" Then
                        obj.moneda = "1"
                    ElseIf i.GetValue("moneda") = "EXT" Then
                        obj.moneda = "2"
                    End If

                    'obj.tipocambio = CDec(i.GetValue("tipocambio"))
                    obj.tipocambio = TmpTipoCambio

                    obj.montoAutorizadoMN = CDec(i.GetValue("pago"))
                    obj.montoAutorizadoME = CDec(i.GetValue("pagome"))
                    obj.glosa = "COBRO ASIENTO MANUAL"
                    obj.tipoRazon = txtTipoProv.Text


                    obj.tipo = "CA"

                    obj.idDocumentoRef = i.GetValue("idDocumento")
                    obj.idDocumentoDetalleRef = i.GetValue("secuencia")

                    obj.fechaPago = i.GetValue("fechaPago")
                    obj.fechaoperacion = txtfechaprogramacion.Value
                    obj.nrocuota = CInt(i.GetValue("cuota"))
                    obj.descripcion = txtDescripcion.Text
                    obj.cuenta = txtCuenta.Text

                    obj.usuarioActualizacion = usuario.IDUsuario
                    obj.usuarioResponssable = CInt(1)
                    obj.fechaActualizacion = DateTime.Now
                    obj.idDocumentoPago = 0
                    lista.Add(obj)


                ElseIf i.GetValue("pagome") > 0 Then

                    obj = New Cronograma
                    Dim prove As Integer = i.GetValue("idproveedor")
                    obj.identidad = prove
                    If i.GetValue("moneda") = "NAC" Then
                        obj.moneda = "1"
                    ElseIf i.GetValue("moneda") = "EXT" Then
                        obj.moneda = "2"
                    End If
                    obj.tipocambio = TmpTipoCambio
                    obj.montoAutorizadoMN = CDec(i.GetValue("pago"))
                    obj.montoAutorizadoME = CDec(i.GetValue("pagome"))
                    obj.glosa = "COBRO ASIENTO MANUAL"
                    ' obj.tipoRazon = "PR"


                    obj.tipoRazon = txtTipoProv.Text

                    obj.tipo = "CA"
                    obj.idDocumentoRef = i.GetValue("idDocumento")
                    obj.idDocumentoDetalleRef = i.GetValue("secuencia")
                    obj.fechaPago = i.GetValue("fechaPago")
                    obj.fechaoperacion = txtfechaprogramacion.Value

                    obj.descripcion = txtDescripcion.Text
                    obj.cuenta = txtCuenta.Text
                    obj.usuarioResponssable = CInt(1)
                    obj.usuarioActualizacion = usuario.IDUsuario
                    obj.fechaActualizacion = DateTime.Now
                    obj.idDocumentoPago = 0
                    lista.Add(obj)
                End If
            Next

            cronoSA.InsetCronograma(lista)
            Dispose()
        Catch ex As Exception
            'lblEstado.Text = ex.Message
            'PanelError.Visible = True
            'Timer1.Enabled = True
            'TiempoEjecutar(10)
        End Try
    End Sub


    Sub GrabarCronograma()
        Dim cronoSA As New CronogramaSA
        Dim obj As New Cronograma
        Dim lista As New List(Of Cronograma)
        Try
            For Each i As Record In dgvPagosProgramados.Table.Records

                If i.GetValue("pago") > 0 Then
                    obj = New Cronograma

                    ' obj.identidad = i.GetValue("idProveedor")
                    Dim prove As Integer = i.GetValue("idproveedor")
                    obj.identidad = prove
                    'obj.tipoRazon = i.GetValue("tipoProv")
                    'obj.tipoRazon = "PR"

                    'obj.moneda = i.GetValue("moneda")
                    If i.GetValue("moneda") = "NAC" Then
                        obj.moneda = "1"
                    ElseIf i.GetValue("moneda") = "EXT" Then
                        obj.moneda = "2"
                    End If

                    'obj.tipocambio = CDec(i.GetValue("tipocambio"))
                    obj.tipocambio = TmpTipoCambio

                    obj.montoAutorizadoMN = CDec(i.GetValue("pago"))
                    obj.montoAutorizadoME = CDec(i.GetValue("pagome"))
                    obj.glosa = "COBRO A" & " " & txtCliente.Text
                    'obj.tipoRazon = i.GetValue("tipoProv")
                    obj.tipoRazon = "CL"

                    'If i.GetValue("tipo") = "Pago" Then

                    obj.tipo = "C"
                    obj.nrocuota = CInt(i.GetValue("cuota"))
                    'ElseIf i.GetValue("tipo") = "Cobro" Then
                    '    obj.tipo = "C"
                    'End If

                    obj.idDocumentoRef = i.GetValue("idDocumento")
                    obj.fechaPago = i.GetValue("fechaPago")
                    obj.fechaoperacion = txtfechaprogramacion.Value

                    obj.usuarioActualizacion = usuario.IDUsuario
                    obj.fechaActualizacion = DateTime.Now
                    obj.idDocumentoPago = 0
                    lista.Add(obj)


                ElseIf i.GetValue("pagome") > 0 Then

                    obj = New Cronograma
                    Dim prove As Integer = i.GetValue("idproveedor")
                    obj.identidad = prove
                    If i.GetValue("moneda") = "NAC" Then
                        obj.moneda = "1"
                    ElseIf i.GetValue("moneda") = "EXT" Then
                        obj.moneda = "2"
                    End If
                    obj.tipocambio = TmpTipoCambio
                    obj.montoAutorizadoMN = CDec(i.GetValue("pago"))
                    obj.montoAutorizadoME = CDec(i.GetValue("pagome"))
                    obj.glosa = "COBRO A" & " " & txtCliente.Text
                    obj.tipoRazon = "CL"
                    obj.tipo = "C"
                    obj.idDocumentoRef = i.GetValue("idDocumento")
                    obj.fechaPago = i.GetValue("fechaPago")
                    obj.fechaoperacion = txtfechaprogramacion.Value

                    obj.usuarioActualizacion = usuario.IDUsuario
                    obj.fechaActualizacion = DateTime.Now
                    obj.idDocumentoPago = 0
                    lista.Add(obj)
                End If
            Next
            cronoSA.InsetCronograma(lista)
            Dispose()
        Catch ex As Exception
            'lblEstado.Text = ex.Message
            'PanelError.Visible = True
            'Timer1.Enabled = True
            'TiempoEjecutar(10)
        End Try
    End Sub


    Dim colorx As New GridMetroColors()
    Sub GridCFG(GGC As GridGroupingControl)
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = False
        GGC.ShowColumnHeaders = True

        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        GGC.SetMetroStyle(colorx)
        GGC.BorderStyle = System.Windows.Forms.BorderStyle.None

        '  GGC.BrowseOnly = True
        'GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        'GGC.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        'GGC.TableOptions.ListBoxSelectionMode = SelectionMode.One
        GGC.TableOptions.SelectionBackColor = Color.Gray
        GGC.AllowProportionalColumnSizing = False
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        GGC.Table.DefaultColumnHeaderRowHeight = 23
        GGC.Table.DefaultRecordRowHeight = 20
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 7.5F

    End Sub

    Sub GetTableGrid2()
        Dim dt As New DataTable()

        dt.Columns.Add("cuota", GetType(String))
        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("idproveedor", GetType(Integer))
        dt.Columns.Add("tipoprov", GetType(String))
        dt.Columns.Add("nombres", GetType(String))
        dt.Columns.Add("fecha", GetType(String))
        dt.Columns.Add("tipoVenta", GetType(String))
        dt.Columns.Add("tipoDoc", GetType(String))
        dt.Columns.Add("serie", GetType(String))
        dt.Columns.Add("numero", GetType(String))
        dt.Columns.Add("moneda", GetType(String))
        dt.Columns.Add("tipoCambio", GetType(Decimal))
        dt.Columns.Add("pago", GetType(Decimal))
        dt.Columns.Add("pagome", GetType(Decimal))
        dt.Columns.Add("fechaPago", GetType(Date))
        dt.Columns.Add("secuencia", GetType(Integer))

        dgvPagosProgramados.DataSource = dt
    End Sub
#End Region

    Private Sub frmNegociacionPagos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmNegociacionPagos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtCuotas_ValueChanged(sender As Object, e As EventArgs) Handles txtCuotas.ValueChanged
        If txtCuotas.Value > 0 Then
            If txtdiaspago.Value >= 0 Then

                Dim importepago As Decimal = (txtImporteCompramn.Value / txtCuotas.Value).ToString("N2")
                Dim importepagome As Decimal = (txtImporteComprame.Value / txtCuotas.Value).ToString("N2")
                Dim fechaModo As DateTime = txtfechaprogramacion.Value

                If txtImporteCompramn.Value > 0 Or txtImporteComprame.Value > 0 Then

                    dgvPagosProgramados.Table.Records.DeleteAll()
                    For x = 0 To txtCuotas.Value - 1
                        Dim cuota As Decimal
                        cuota = x + 1

                        fechaModo = fechaModo
                        fechaModo = fechaModo.AddDays(CInt(txtdiaspago.Text))
                        '////////////

                        Me.dgvPagosProgramados.Table.AddNewRecord.SetCurrent()
                        Me.dgvPagosProgramados.Table.AddNewRecord.BeginEdit()
                        Me.dgvPagosProgramados.Table.CurrentRecord.SetValue("cuota", cuota)
                        Me.dgvPagosProgramados.Table.CurrentRecord.SetValue("idDocumento", lblIdDocumento.Text)
                        Me.dgvPagosProgramados.Table.CurrentRecord.SetValue("idproveedor", txtCliente.Tag)
                        Me.dgvPagosProgramados.Table.CurrentRecord.SetValue("tipoprov", "PR")
                        Me.dgvPagosProgramados.Table.CurrentRecord.SetValue("nombres", txtCliente.Text)
                        Me.dgvPagosProgramados.Table.CurrentRecord.SetValue("fecha", txtfechaprogramacion.Value)
                        Me.dgvPagosProgramados.Table.CurrentRecord.SetValue("tipoVenta", "")
                        Me.dgvPagosProgramados.Table.CurrentRecord.SetValue("tipoDoc", "")
                        Me.dgvPagosProgramados.Table.CurrentRecord.SetValue("serie", txtSerie.Text)
                        Me.dgvPagosProgramados.Table.CurrentRecord.SetValue("numero", txtNumero.Text)
                        Me.dgvPagosProgramados.Table.CurrentRecord.SetValue("moneda", txtMoneda.Text)
                        Me.dgvPagosProgramados.Table.CurrentRecord.SetValue("tipoCambio", txttipocambio.Value)
                        Me.dgvPagosProgramados.Table.CurrentRecord.SetValue("secuencia", txtSecuencia.Text)


                        If txtMoneda.Text = "NAC" Then
                            Me.dgvPagosProgramados.Table.CurrentRecord.SetValue("pago", importepago)
                            Me.dgvPagosProgramados.Table.CurrentRecord.SetValue("pagome", CDec(0))
                        ElseIf txtMoneda.Text = "EXT" Then
                            Me.dgvPagosProgramados.Table.CurrentRecord.SetValue("pago", CDec(0))
                            Me.dgvPagosProgramados.Table.CurrentRecord.SetValue("pagome", importepagome)
                        End If

                        Me.dgvPagosProgramados.Table.CurrentRecord.SetValue("fechaPago", fechaModo)
                        Me.dgvPagosProgramados.Table.AddNewRecord.EndEdit()

                        If txtMoneda.Text = "NAC" Then
                            dgvPagosProgramados.TableDescriptor.Columns("pagome").Width = 0
                        ElseIf txtMoneda.Text = "EXT" Then
                            dgvPagosProgramados.TableDescriptor.Columns("pago").Width = 0
                        End If

                    Next
                End If
            Else

                MessageBox.Show("Ingrese dias de pagos")
            End If
        Else
            MessageBox.Show("Ingrese numero de cuotas")
        End If
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Me.Cursor = Cursors.WaitCursor


        If txtMoneda.Text = "NAC" Then
            Dim cap As Decimal
            cap = 0
            For Each i As Record In dgvPagosProgramados.Table.Records

                cap += i.GetValue("pago")

            Next

            If Not cap = txtImporteCompramn.Value Then
                'Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montomn", 0)
                MessageBox.Show("El Monto Programado no Cuadra")
                Exit Sub
            End If
        ElseIf txtMoneda.Text = "EXT" Then
            Dim cap As Decimal
            cap = 0
            For Each i As Record In dgvPagosProgramados.Table.Records

                cap += i.GetValue("pagome")

            Next

            If Not cap = txtImporteComprame.Value Then
                'Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montomn", 0)
                MessageBox.Show("El Monto Programado no Cuadra")
                Exit Sub
            End If
        End If





        'If Not txtFecha.Value > DateTime.Now.Date Then
        '    MessageBox.Show("La Fecha de Pago debe ser mayor ala de hoy", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    Exit Sub
        'End If

        If dgvPagosProgramados.Table.Records.Count > 0 Then



            If lbltipo.Text = "CA" Then
                GrabarCronogramaAsiento()
            Else
                GrabarCronograma()
            End If

        Else
            ' MessageBox.Show("Debe Ingresar Items ala Canasta")
            MessageBox.Show("No hay documentos por guardar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Dispose()
    End Sub

    Private Sub dgvPagosProgramados_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvPagosProgramados.QueryCellStyleInfo
        If e.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell OrElse e.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell Then
            If e.TableCellIdentity.Column.Name = "fechaPago" Then
                e.Style.Format = "dd/MM/yyyy h:mm:ss tt"
            End If
            e.Handled = True
        End If
    End Sub

    Private Sub dgvPagosProgramados_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvPagosProgramados.TableControlCellClick

    End Sub

    Private Sub dgvPagosProgramados_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvPagosProgramados.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        If Not IsNothing(Me.dgvPagosProgramados.Table.CurrentRecord) Then
            Select Case ColIndex
                Case 12 ' capital

                    If Me.dgvPagosProgramados.Table.CurrentRecord.GetValue("pago") < 0 Then
                        Me.dgvPagosProgramados.Table.CurrentRecord.SetValue("pago", CDec(0.0))
                    End If
                Case 13
                    If Me.dgvPagosProgramados.Table.CurrentRecord.GetValue("pagome") < 0 Then
                        Me.dgvPagosProgramados.Table.CurrentRecord.SetValue("pagome", CDec(0.0))
                    End If
            End Select

        End If
    End Sub

    Private Sub txtdiaspago_ValueChanged(sender As Object, e As EventArgs) Handles txtdiaspago.ValueChanged
        If txtCuotas.Value > 0 Then
            If txtdiaspago.Value > 0 Then

                Dim importepago As Decimal = (txtImporteCompramn.Value / txtCuotas.Value).ToString("N2")
                Dim importepagome As Decimal = (txtImporteComprame.Value / txtCuotas.Value).ToString("N2")
                Dim fechaModo As DateTime = txtfechaprogramacion.Value

                If txtImporteCompramn.Value > 0 Or txtImporteComprame.Value > 0 Then

                    dgvPagosProgramados.Table.Records.DeleteAll()
                    For x = 0 To txtCuotas.Value - 1
                        Dim cuota As Decimal
                        cuota = x + 1

                        fechaModo = fechaModo
                        fechaModo = fechaModo.AddDays(CInt(txtdiaspago.Text))
                        '////////////

                        Me.dgvPagosProgramados.Table.AddNewRecord.SetCurrent()
                        Me.dgvPagosProgramados.Table.AddNewRecord.BeginEdit()
                        Me.dgvPagosProgramados.Table.CurrentRecord.SetValue("cuota", cuota)
                        Me.dgvPagosProgramados.Table.CurrentRecord.SetValue("idDocumento", lblIdDocumento.Text)
                        Me.dgvPagosProgramados.Table.CurrentRecord.SetValue("idproveedor", txtCliente.Tag)
                        Me.dgvPagosProgramados.Table.CurrentRecord.SetValue("tipoprov", "PR")
                        Me.dgvPagosProgramados.Table.CurrentRecord.SetValue("nombres", txtCliente.Text)
                        Me.dgvPagosProgramados.Table.CurrentRecord.SetValue("fecha", txtfechaprogramacion.Value)
                        Me.dgvPagosProgramados.Table.CurrentRecord.SetValue("tipoVenta", "")
                        Me.dgvPagosProgramados.Table.CurrentRecord.SetValue("tipoDoc", "")
                        Me.dgvPagosProgramados.Table.CurrentRecord.SetValue("serie", txtSerie.Text)
                        Me.dgvPagosProgramados.Table.CurrentRecord.SetValue("numero", txtNumero.Text)
                        Me.dgvPagosProgramados.Table.CurrentRecord.SetValue("moneda", txtMoneda.Text)
                        Me.dgvPagosProgramados.Table.CurrentRecord.SetValue("tipoCambio", txttipocambio.Value)
                        Me.dgvPagosProgramados.Table.CurrentRecord.SetValue("secuencia", txtSecuencia.Text)


                        If txtMoneda.Text = "NAC" Then
                            Me.dgvPagosProgramados.Table.CurrentRecord.SetValue("pago", importepago)
                            Me.dgvPagosProgramados.Table.CurrentRecord.SetValue("pagome", CDec(0))
                        ElseIf txtMoneda.Text = "EXT" Then
                            Me.dgvPagosProgramados.Table.CurrentRecord.SetValue("pago", CDec(0))
                            Me.dgvPagosProgramados.Table.CurrentRecord.SetValue("pagome", importepagome)
                        End If

                        Me.dgvPagosProgramados.Table.CurrentRecord.SetValue("fechaPago", fechaModo)
                        Me.dgvPagosProgramados.Table.AddNewRecord.EndEdit()

                        If txtMoneda.Text = "NAC" Then
                            dgvPagosProgramados.TableDescriptor.Columns("pagome").Width = 0
                        ElseIf txtMoneda.Text = "EXT" Then
                            dgvPagosProgramados.TableDescriptor.Columns("pago").Width = 0
                        End If

                    Next
                End If
            Else

                MessageBox.Show("Ingrese dias de pagos")
            End If
        Else
            MessageBox.Show("Ingrese numero de cuotas")
        End If
    End Sub
End Class