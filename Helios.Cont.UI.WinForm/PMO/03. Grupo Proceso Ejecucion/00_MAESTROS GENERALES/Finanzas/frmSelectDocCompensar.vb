Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Tools

Public Class frmSelectDocCompensar


    Public Property objetoDocCompensacion As documento

#Region "Constructor"
    Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        'GridCFG(dgvDocumento)
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

#End Region

#Region "Metodos"


    Public Sub UbicarDetalleAnticipo(intIddocumento As Integer)
        Dim detalleSA As New DocumentoCompraDetalleSA
        Dim objLista As New DocumentoCajaDetalleSA



        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable



        dt.Columns.Add("idDocumento")
        dt.Columns.Add("secuencia")
        dt.Columns.Add("destino")
        dt.Columns.Add("idItem")
        dt.Columns.Add("DetalleItem")
        dt.Columns.Add("TipoExistencia")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("importe")
        dt.Columns.Add("importeme")
        dt.Columns.Add("importUsado")
        dt.Columns.Add("importUsadome")
        dt.Columns.Add("saldo")
        dt.Columns.Add("saldome")


        Try






            For Each i As documentoCajaDetalle In objLista.ObtenerAnticipoDetails(intIddocumento)

                Dim dr As DataRow = dt.NewRow()

                dr(0) = i.idDocumento
                dr(1) = i.secuencia
                dr(2) = ""
                dr(3) = ""
                dr(4) = ""
                dr(5) = ""
                dr(6) = ""
                dr(7) = i.montoSoles
                dr(8) = i.montoUsd
                dr(9) = 0
                dr(10) = 0
                dr(11) = i.montoSoles
                dr(12) = i.montoUsd

                dt.Rows.Add(dr)
            Next
            dgvDocumentoDet.DataSource = dt

        Catch ex As Exception

        End Try
    End Sub

    Public Sub Reparticion()





        Dim nudSaldo As Decimal = txtMontoXUsar.Value
        'Dim nudSaldoME As Decimal = j.importeUS
        Dim nudSaldoME As Decimal = txtMontoXUsar.Value / TmpTipoCambio
        Dim cSaldo As Decimal = 0
            Dim cSaldoex As Decimal = 0
            Dim cSaldoME As Decimal = 0
            Dim cSaldoexME As Decimal = 0
            'Dim PagoActual As Decimal = j.importeTotal
            'Dim PagoActualME As Decimal = j.importeTotal / TmpTipoCambioTransaccionVenta
            Dim PagoActual As Decimal = CDec(0.0)
            Dim PagoActualME As Decimal = CDec(0.0)




            For Each i As Record In dgvDocumentoDet.Table.Records
                If nudSaldo > 0 Then

                    If i.GetValue("saldo") > 0 Then



                        If nudSaldo > 0 Then

                            cSaldo = Math.Round((CDec(i.GetValue("saldo"))), 2) - nudSaldo
                            If cSaldo >= 0 Then
                            'nudSaldo += Math.Round((CDec(i.GetValue("pago"))), 2)
                            i.SetValue("importUsado", nudSaldo + CDec(i.GetValue("importUsado")))
                            i.SetValue("saldo", cSaldo)

                            i.SetValue("importUsadome", CDec(i.GetValue("importUsado")) / TmpTipoCambioTransaccionVenta)
                            i.SetValue("importUsadome", (nudSaldo + CDec(i.GetValue("importUsado"))) / TmpTipoCambioTransaccionVenta)

                            PagoActual = nudSaldo
                                PagoActualME = nudSaldo / TmpTipoCambioTransaccionVenta


                                nudSaldo = 0

                            Else
                                PagoActual = CDec(i.GetValue("saldo"))
                                PagoActualME = CDec(i.GetValue("saldo")) / TmpTipoCambioTransaccionVenta

                            i.SetValue("importUsado", CDec(i.GetValue("saldo")) + CDec(i.GetValue("importUsado")))
                            i.SetValue("saldo", CDec(0.0))

                            i.SetValue("importUsadome", ((CDec(i.GetValue("saldo")) + CDec(i.GetValue("importUsado")))) / TmpTipoCambioTransaccionVenta)
                            i.SetValue("saldome", CDec(0.0))

                                'PagoActual = nudSaldo
                                'PagoActualME = (nudSaldo) / TmpTipoCambioTransaccionVenta


                                nudSaldo = cSaldo * -1



                            End If

                        Else
                            'i.SetValue("saldo", CDec(i.GetValue("saldo")))
                            'i.SetValue("saldome", CDec(i.GetValue("saldome")))
                        End If

                    End If




                End If
            Next


    End Sub

    Sub GridCFG(GGC As GridGroupingControl)
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = False
        GGC.ShowColumnHeaders = True

        Dim colorx As New GridMetroColors()

        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        GGC.SetMetroStyle(colorx)
        GGC.BorderStyle = System.Windows.Forms.BorderStyle.None

        '  GGC.BrowseOnly = True
        GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        GGC.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        GGC.TableOptions.ListBoxSelectionMode = SelectionMode.One
        GGC.TableOptions.SelectionBackColor = Color.Gray
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.Format = "MMM dd yyyy"
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.Hide
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).HeaderText = "Date"
        'Me.gridGroupingControl1.TableDescriptor.Columns(1).HeaderText = "Category"
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.Currency
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromArgb(168, 178, 189)
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.TextAlign = GridTextAlign.Left

        'this.gridGroupingControl1.TableDescriptor.Columns["Amount"].Width = (this.tableLayoutPanel3.Width / 5) - 50;
        GGC.AllowProportionalColumnSizing = False
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        GGC.Table.DefaultColumnHeaderRowHeight = 23
        GGC.Table.DefaultRecordRowHeight = 20
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Private Sub UbicarAnticiposProveedor(RucProveedor As String, strPeriodo As String)
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim documentoCompra As New List(Of documentoCaja)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable

        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("tipoCompra", GetType(String))
        dt.Columns.Add("Fecha")
        dt.Columns.Add("periodo", GetType(String))

        dt.Columns.Add("TipoDoc", GetType(String))
        dt.Columns.Add("Serie", GetType(String))
        dt.Columns.Add("Numero", GetType(String))
        dt.Columns.Add("moneda", GetType(String))
        dt.Columns.Add("montoMN", GetType(Decimal))
        dt.Columns.Add("montoME", GetType(Decimal))
        dt.Columns.Add("cuotas", GetType(Integer))


        dt.Columns.Add("entidadFinanciera", GetType(String))
        dt.Columns.Add("formapago", GetType(String))
        dt.Columns.Add("numeroOperacion", GetType(String))
        dt.Columns.Add("ctaCorrienteDeposito", GetType(String))
        dt.Columns.Add("bancoEntidad", GetType(String))
        dt.Columns.Add("tipoOperacion", GetType(String))

        documentoCompra = documentoCajaSA.UbicarAnticiposProveedor(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, RucProveedor, strPeriodo)

        Dim str As String
        If Not IsNothing(documentoCompra) Then
            'Dim SaldoPagosMN As Decimal = 0
            'Dim SaldoPagosME As Decimal = 0
            For Each i In documentoCompra

                'SaldoPagosMN = 0
                'SaldoPagosME = 0

                'SaldoPagosMN = i.importeTotal - i.PagoSumaMN
                'SaldoPagosME = i.importeUS - i.PagoSumaME

                ''nota de credito
                'SaldoPagosMN = SaldoPagosMN - i.PagoNotaCreditoMN + i.PagoNotaDebitoMN
                'SaldoPagosME = SaldoPagosME - i.PagoNotaCreditoME + i.PagoNotaDebitoME


                Dim dr As DataRow = dt.NewRow()
                'str = Nothing
                'str = CDate(i.fechaProceso).ToString("dd-MMM hh:mm tt ")
                dr(0) = i.idDocumento
                dr(1) = i.movimientoCaja
                dr(2) = i.fechaProceso
                dr(3) = i.periodo
                dr(4) = i.glosa
                dr(5) = "-"
                dr(6) = i.numeroDoc
                Select Case i.moneda
                    Case 1
                        dr(7) = "NAC"
                    Case Else
                        dr(7) = "EXT"

                End Select

                dr(8) = i.montoSoles
                dr(9) = i.montoUsd

                dr(10) = 0

                dr(11) = i.entidadFinanciera
                dr(12) = i.formapago
                dr(13) = i.numeroOperacion
                dr(14) = i.ctaCorrienteDeposito
                dr(15) = i.bancoEntidad
                dr(16) = i.tipoOperacion

                dt.Rows.Add(dr)
            Next
            dgvDocumento.DataSource = dt

        Else

        End If
    End Sub

#End Region

    Private Sub frmSelectDocCompensar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click
        Me.Cursor = Cursors.WaitCursor
        Dim strPeriodo As String = String.Format("{0:00}", CInt(txtPeriodo.Value.Month))
        strPeriodo = String.Concat(strPeriodo, "/", txtPeriodo.Value.Year)

        If cbotipoDocumento.Text = "COMPRAS" Then
            'UbicarCompraXProveedorNroSerie(txtRuc.Text, strPeriodo)
        ElseIf cbotipoDocumento.Text = "VENTAS" Then
            'UbicarVentaXProveedorNroSerie(txtRuc.Text, strPeriodo)
        ElseIf cbotipoDocumento.Text = "ANTICIPOS" Then

            UbicarAnticiposProveedor(txtRucPago.Text, strPeriodo)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvDocumentoDet_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvDocumentoDet.TableControlCellClick

    End Sub

    Private Sub txtMontoXUsar_ValueChanged(sender As Object, e As EventArgs) Handles txtMontoXUsar.ValueChanged
        If dgvDocumentoDet.Table.Records.Count > 0 Then



            If txtMontoXUsar.Value <= txtMontoXComp.Value Then
                If txtMontoXUsar.Value > 0 Then

                    If txtMontoXUsar.Value <= txtMontoDocSelec.Value Then

                        Reparticion()

                    Else
                        MessageBox.Show("Solo puedes usar maximo " & txtMontoDocSelec.Value & " Del Documento Seleccionado", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                        txtMontoXUsar.Value = CDec(0.0)
                    End If

                End If

            Else
                txtMontoXUsar.Value = CDec(0.0)

                MessageBox.Show("Solo necesitas como maximo " & txtMontoXComp.Value & " Del Documento Seleccionado", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else

            MessageBox.Show("Seleccione un Documento para Compensar")
            Exit Sub
        End If

    End Sub

    Private Sub dgvDocumento_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvDocumento.TableControlCellClick
        dgvDocumentoDet.Table.Records.DeleteAll()
        txtMontoXUsar.Value = 0
    End Sub


    Private Sub dgvDocumento_TableControlCurrentCellControlDoubleClick(sender As Object, e As GridTableControlControlEventArgs) Handles dgvDocumento.TableControlCurrentCellControlDoubleClick
        If Not IsNothing(Me.dgvDocumento.Table.CurrentRecord) Then



            If cbotipoDocumento.Text = "COMPRAS" Then
                'UbicarDetalle(dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))
            ElseIf cbotipoDocumento.Text = "VENTAS" Then
                ' UbicarDetallePago(dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))
            ElseIf cbotipoDocumento.Text = "ANTICIPOS" Then

                UbicarDetalleAnticipo(dgvDocumento.Table.CurrentRecord.GetValue("idDocumento"))

                txtMontoDocSelec.Value = CDec(dgvDocumento.Table.CurrentRecord.GetValue("montoMN"))

            End If

        Else
            MessageBox.Show("Debe seleccionar una item!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub frmSelectDocCompensar_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click

        If dgvDocumentoDet.Table.Records.Count > 0 Then

            Dim objetoCaja As New documentoCaja
            Dim objetoCajaDetalle As New documentoCajaDetalle
            Dim ListaCajaDet As New List(Of documentoCajaDetalle)



            If Not txtMontoXUsar.Value > 0 Then
                MessageBox.Show("Ingrese un Monto mayor a 0")
                Exit Sub
            End If

            Dim idCaja As Integer
            Select Case usuario.CustomUsuario.CustomUsuarioRol.IDRol
                Case 3, 4
                    idCaja = GFichaUsuarios.IdCajaUsuario
                Case Else
                    idCaja = 0
            End Select



            objetoDocCompensacion = New documento





            objetoDocCompensacion.tipoDoc = "ANTICIPO"

            'documentocaja
            objetoCaja.idDocumento = dgvDocumento.Table.CurrentRecord.GetValue("idDocumento")
            objetoCaja.montoSoles = txtMontoXUsar.Value
            objetoCaja.montoUsd = txtMontoXUsar.Value * TmpTipoCambio
            objetoCaja.SerieCompra = dgvDocumento.Table.CurrentRecord.GetValue("Serie")
            objetoCaja.numeroCompra = dgvDocumento.Table.CurrentRecord.GetValue("Numero")

            objetoCaja.entidadFinanciera = dgvDocumento.Table.CurrentRecord.GetValue("entidadFinanciera")
            objetoCaja.formapago = dgvDocumento.Table.CurrentRecord.GetValue("formapago")
            objetoCaja.numeroOperacion = dgvDocumento.Table.CurrentRecord.GetValue("numeroOperacion")
            objetoCaja.ctaCorrienteDeposito = dgvDocumento.Table.CurrentRecord.GetValue("ctaCorrienteDeposito")
            objetoCaja.bancoEntidad = dgvDocumento.Table.CurrentRecord.GetValue("bancoEntidad")

            objetoCaja.tipoOperacion = dgvDocumento.Table.CurrentRecord.GetValue("tipoOperacion")
            objetoCaja.idCajaUsuario = idCaja

            objetoCaja.fechaProceso = CDate(dgvDocumento.Table.CurrentRecord.GetValue("Fecha"))


            objetoDocCompensacion.documentoCaja = objetoCaja

            'docuemntocajadetalle
            For Each i As Record In dgvDocumentoDet.Table.Records
                objetoCajaDetalle = New documentoCajaDetalle
                objetoCajaDetalle.idDocumento = i.GetValue("idDocumento")
                objetoCajaDetalle.secuencia = i.GetValue("secuencia")
                objetoCajaDetalle.ImporteNacional = i.GetValue("importUsado")
                objetoCajaDetalle.ImporteExtranjero = i.GetValue("importUsadome")
                ListaCajaDet.Add(objetoCajaDetalle)


            Next


            objetoDocCompensacion.documentoCaja.documentoCajaDetalle = ListaCajaDet

            Dispose()


        Else

            MessageBox.Show("Seleccione un Documento para Compensar")
            Exit Sub
        End If
    End Sub
End Class