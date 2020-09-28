Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping

Public Class frmModalStockArticuloAlmacen

#Region "Attributes"
    Dim totalesSA As New TotalesAlmacenSA
    Public Property rowArticulo As New totalesAlmacen
#End Region

#Region "Constructors"
    Public Sub New(be As totalesAlmacen)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridPequeño(dgvArticulos, True)
        getStockAlmacenes(be)
        rowArticulo = be
        txtCanDev.Text = be.cantidad
        txtBaseDev.Text = be.importeSoles
        ComboMotivo()
        If dgvArticulos.Table.Records.Count > 0 Then
            dgvArticulos.Table.Records(0).SetCurrent()
            dgvArticulos.Table.Records(0).SetSelected(True)
        End If
        txtCanMov.Select()
    End Sub
#End Region

#Region "Methods"
    Sub ComboMotivo()
        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("name")

        Dim dr As DataRow = dt.NewRow()
        dr(0) = "1"
        dr(1) = "DISMINUIR CANTIDAD"
        dt.Rows.Add(dr)

        Dim dr2 As DataRow = dt.NewRow()
        dr2(0) = "2"
        dr2(1) = "DISMINUIR IMPORTE"
        dt.Rows.Add(dr2)

        Dim dr3 As DataRow = dt.NewRow()
        dr3(0) = "3"
        dr3(1) = "DEVOLUCION DE EXISTENCIAS"
        dt.Rows.Add(dr3)

        Dim dr4 As DataRow = dt.NewRow()
        dr4(0) = "4"
        dr4(1) = "PRONTO PAGO - VOLUMEN DE COMPRA"
        dt.Rows.Add(dr4)

        cboMotivo.DisplayMember = "name"
        cboMotivo.ValueMember = "id"
        cboMotivo.DataSource = dt
        cboMotivo.SelectedValue = "3"
    End Sub

    Public Sub getStockAlmacenes(be As totalesAlmacen)
        Dim dt As New DataTable()
        dt.Columns.Add("idAlmacen")
        dt.Columns.Add("idItem")
        dt.Columns.Add("almacen")
        dt.Columns.Add("item")
        dt.Columns.Add("unidad")
        dt.Columns.Add("cant")
        dt.Columns.Add("monto")
        dt.Columns.Add("montoME")
        dt.Columns.Add("codigoLote")

        For Each i In totalesSA.GetStockAlmacenesBytem(be)
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idAlmacen
            dr(1) = i.idItem
            dr(2) = i.NomAlmacen
            dr(3) = i.descripcion
            dr(4) = i.idUnidad
            dr(5) = i.cantidad
            dr(6) = i.importeSoles
            dr(7) = i.importeDolares
            dr(8) = i.CustomLote.codigoLote
            dt.Rows.Add(dr)
        Next
        dgvArticulos.DataSource = dt
    End Sub
#End Region

#Region "Events"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim cantidad As Decimal = 0
        Dim canSaldo As Decimal = 0
        Dim cantidadOrigen As Decimal = 0
        Dim be As New totalesAlmacen
        If Not IsNothing(dgvArticulos.Table.CurrentRecord) Then
            Try
                be = New totalesAlmacen
                Dim r As Record = dgvArticulos.Table.CurrentRecord

                If Not IsNothing(r) Then

                    Select Case cboMotivo.SelectedValue
                        Case "1"
                            If txtCanMov.DecimalValue > CDec(r.GetValue("cant")) Then
                                MessageBox.Show("La cantidad ingresada supera el stock disponible", "Verificar cantidad", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                                Cursor = Cursors.Default
                            End If

                            If txtCanMov.DecimalValue > CDec(txtCanDev.Text) Then
                                MessageBox.Show("La cantidad ingresada supera la cantidad a devolver", "Verificar cantidad", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                                Cursor = Cursors.Default
                            End If

                        Case "2"

                            If txtBaseMov.DecimalValue > CDec(r.GetValue("monto")) Then
                                MessageBox.Show("El importe ingresado supera el costo disponible", "Verificar costo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                                Cursor = Cursors.Default
                            End If

                            If txtBaseMov.DecimalValue > CDec(txtBaseDev.Text) Then
                                MessageBox.Show("El importe ingresado supera el costo a devolver", "Verificar costo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                                Cursor = Cursors.Default
                            End If

                        Case "3"
                            If txtCanMov.DecimalValue > CDec(r.GetValue("cant")) Then
                                MessageBox.Show("La cantidad ingresada supera el stock disponible", "Verificar cantidad", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                                Cursor = Cursors.Default
                            End If

                            If txtBaseMov.DecimalValue > CDec(r.GetValue("monto")) Then
                                MessageBox.Show("El importe ingresado supera el costo disponible", "Verificar costo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                                Cursor = Cursors.Default
                            End If

                            If txtCanMov.DecimalValue > CDec(txtCanDev.Text) Then
                                MessageBox.Show("La cantidad ingresada supera la cantidad a devolver", "Verificar cantidad", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                                Cursor = Cursors.Default
                            End If

                            If txtBaseMov.DecimalValue > CDec(txtBaseDev.Text) Then
                                MessageBox.Show("El importe ingresado supera el costo a devolver", "Verificar costo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                                Cursor = Cursors.Default
                            End If
                        Case "4"
                            If txtBaseMov.DecimalValue < 0 Then
                                MessageBox.Show("Ingrese un monto mayor a cero", "Verificar cantidad", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                                Cursor = Cursors.Default
                            End If
                            'If txtCanMov.DecimalValue > CDec(r.GetValue("cant")) Then
                            '    MessageBox.Show("La cantidad ingresada supera el stock disponible", "Verificar cantidad", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            '    Exit Sub
                            '    Cursor = Cursors.Default
                            'End If

                            'If txtBaseMov.DecimalValue > CDec(r.GetValue("monto")) Then
                            '    MessageBox.Show("El importe ingresado supera el costo disponible", "Verificar costo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            '    Exit Sub
                            '    Cursor = Cursors.Default
                            'End If

                            'If txtCanMov.DecimalValue > CDec(txtCanDev.Text) Then
                            '    MessageBox.Show("La cantidad ingresada supera la cantidad a devolver", "Verificar cantidad", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            '    Exit Sub
                            '    Cursor = Cursors.Default
                            'End If

                            'If txtBaseMov.DecimalValue > CDec(txtBaseDev.Text) Then
                            '    MessageBox.Show("El importe ingresado supera el costo a devolver", "Verificar costo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            '    Exit Sub
                            '    Cursor = Cursors.Default
                            'End If
                    End Select
                    be.TipoAcces = cboMotivo.SelectedValue
                    be.idAlmacen = Integer.Parse(r.GetValue("idAlmacen").ToString())
                    be.cantidad = txtCanMov.DecimalValue
                    be.importeSoles = txtBaseMov.DecimalValue
                    be.codigoLote =Integer.Parse(r.GetValue("codigoLote").ToString())
                    Tag = be
                    Close()
                Else

                End If


                'Select Case rowArticulo.GetValue("cboMov")
                '    Case "1" ' DISMINUIR CANTIDAD

                '        If Not CDec(rowArticulo.GetValue("canDev")) <= CDec(r.GetValue("cant")) Then
                '            rowArticulo.SetValue("canDev", 0)
                '            rowArticulo.SetValue("vcmn", 0)
                '            rowArticulo.SetValue("ivamn", 0)
                '            rowArticulo.SetValue("totalmn", 0)
                '            rowArticulo.SetValue("vcme", 0)
                '            rowArticulo.SetValue("ivame", 0)
                '            rowArticulo.SetValue("totalme", 0)
                '            rowArticulo.SetValue("pumn", 0)
                '            rowArticulo.SetValue("pume", 0)
                '            MessageBox.Show("No cuenta con stock disponible!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                '        Else
                '            cantidad = CDec(rowArticulo.GetValue("cantCompra"))
                '            canSaldo = cantidad - CDec(rowArticulo.GetValue("canDev"))
                '            rowArticulo.SetValue("canSaldo", canSaldo)
                '            rowArticulo.SetValue("almacenRef", r.GetValue("idAlmacen"))
                '            '  DockingClientPanel1.Enabled = True
                '        End If

                '    Case "2" ' DISMINUIR IMPORTE
                '        If rowArticulo.GetValue("bonificacion") = "NO" Then
                '            '     Calculos()
                '        End If

                '        If Not CDec(rowArticulo.GetValue("vcmn")) <= CDec(r.GetValue("monto")) Then
                '            rowArticulo.SetValue("vcmn", 0)
                '            rowArticulo.SetValue("ivamn", 0)
                '            rowArticulo.SetValue("totalmn", 0)
                '            rowArticulo.SetValue("vcme", 0)
                '            rowArticulo.SetValue("ivame", 0)
                '            rowArticulo.SetValue("totalme", 0)
                '            rowArticulo.SetValue("pumn", 0)
                '            rowArticulo.SetValue("pume", 0)
                '            MessageBox.Show("No cuenta con costo disponible!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                '        Else
                '            Select Case rowArticulo.GetValue("estadoPago")
                '                Case "Pagado"
                '                    Dim saldoFinalmn As Decimal = 0
                '                    Dim saldoFinalme As Decimal = 0

                '                    Dim saldoCompramn As Decimal = 0
                '                    Dim saldoComprame As Decimal = 0
                '                    Dim valAbonomn As Decimal = 0
                '                    Dim valAbonome As Decimal = 0
                '                    Dim ventaOriginalMN As Decimal = 0
                '                    Dim ventaOriginalME As Decimal = 0

                '                    ventaOriginalMN = CDec(rowArticulo.GetValue("compraMN"))
                '                    ventaOriginalME = CDec(rowArticulo.GetValue("compraME"))

                '                    saldoCompramn = CDec(rowArticulo.GetValue("importeMN"))
                '                    saldoComprame = CDec(rowArticulo.GetValue("importeME"))

                '                    valAbonomn = rowArticulo.GetValue("totalmn")
                '                    valAbonome = rowArticulo.GetValue("totalme")

                '                    saldoFinalmn = ventaOriginalMN - valAbonomn
                '                    saldoFinalme = ventaOriginalME - valAbonome

                '                    'If saldoFinalmn < 0 Then
                '                    '    rowArticulo.SetValue("vcmn", 0)
                '                    '    rowArticulo.SetValue("ValDevmn", 0)
                '                    '    rowArticulo.SetValue("ValDevme", 0)
                '                    '    rowArticulo.SetValue("action", "inactivo")
                '                    '    Calculos()
                '                    '    Throw New Exception("El monto ingresado supera al valor original del artículo!")

                '                    'ElseIf saldoFinalmn >= 0 Then
                '                    rowArticulo.SetValue("ValDevmn", valAbonomn)
                '                    rowArticulo.SetValue("ValDevme", valAbonome)
                '                    rowArticulo.SetValue("action", "activo")
                '                    'End If

                '                Case Else

                '                    Dim saldoFinalmn As Decimal = 0
                '                    Dim saldoFinalme As Decimal = 0
                '                    Dim ventaOriginalMN As Decimal = 0
                '                    Dim ventaOriginalME As Decimal = 0

                '                    Dim saldoCompramn As Decimal = 0
                '                    Dim saldoComprame As Decimal = 0
                '                    Dim valAbonomn As Decimal = 0
                '                    Dim valAbonome As Decimal = 0

                '                    ventaOriginalMN = CDec(rowArticulo.GetValue("compraMN"))
                '                    ventaOriginalME = CDec(rowArticulo.GetValue("compraME"))

                '                    saldoCompramn = CDec(rowArticulo.GetValue("importeMN"))
                '                    saldoComprame = CDec(rowArticulo.GetValue("importeME"))


                '                    valAbonomn = rowArticulo.GetValue("totalmn")
                '                    valAbonome = rowArticulo.GetValue("totalme")


                '                    'If saldoCompramn <= 0 Then
                '                    '    rowArticulo.SetValue("vcmn", 0)
                '                    '    rowArticulo.SetValue("vcme", 0)
                '                    '    rowArticulo.SetValue("ValDevmn", 0)
                '                    '    rowArticulo.SetValue("ValDevme", 0)
                '                    '    Calculos()
                '                    '    Throw New Exception("El Comprobante no esta disponible")
                '                    'End If

                '                    'If valAbonomn > ventaOriginalMN Then
                '                    '    rowArticulo.SetValue("vcmn", 0)
                '                    '    rowArticulo.SetValue("vcme", 0)
                '                    '    rowArticulo.SetValue("ValDevmn", 0)
                '                    '    rowArticulo.SetValue("ValDevme", 0)
                '                    '    Calculos()
                '                    '    Throw New Exception("El importe de la nota supera al importe de compra, " & ventaOriginalMN.ToString("N2"))
                '                    'End If

                '                    saldoFinalmn = saldoCompramn - valAbonomn
                '                    saldoFinalme = saldoComprame - valAbonome

                '                    If saldoFinalmn < 0 Then
                '                        rowArticulo.SetValue("ValDevmn", saldoFinalmn * -1)
                '                        rowArticulo.SetValue("ValDevme", saldoFinalme * -1)
                '                        rowArticulo.SetValue("action", "activo")
                '                    Else
                '                        rowArticulo.SetValue("ValDevmn", 0)
                '                        rowArticulo.SetValue("ValDevme", 0)
                '                        rowArticulo.SetValue("action", "inactivo")
                '                    End If
                '            End Select

                '            If rowArticulo.GetValue("bonificacion") = "NO" Then
                '                '    Calculos()
                '            End If
                '            rowArticulo.SetValue("almacenRef", r.GetValue("idAlmacen"))
                '        End If


                '    Case "3" '"DEVOLUCION DE EXISTENCIAS"


                '        If Not CDec(rowArticulo.GetValue("canDev")) <= CDec(r.GetValue("cant")) Then
                '            'rowArticulo.SetValue("canDev", 0)
                '            MessageBox.Show("No cuenta con stock disponible!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                '            rowArticulo.SetValue("canDev", 0)
                '            rowArticulo.SetValue("vcmn", 0)
                '            rowArticulo.SetValue("ivamn", 0)
                '            rowArticulo.SetValue("totalmn", 0)
                '            rowArticulo.SetValue("vcme", 0)
                '            rowArticulo.SetValue("ivame", 0)
                '            rowArticulo.SetValue("totalme", 0)
                '            rowArticulo.SetValue("pumn", 0)
                '            rowArticulo.SetValue("pume", 0)

                '        Else
                '            cantidad = CDec(rowArticulo.GetValue("cantCompra"))
                '            canSaldo = cantidad - CDec(rowArticulo.GetValue("canDev"))
                '            rowArticulo.SetValue("canSaldo", canSaldo)
                '        End If

                '        Select Case rowArticulo.GetValue("estadoPago")
                '            Case "Pagado"
                '                Dim saldoFinalmn As Decimal = 0
                '                Dim saldoFinalme As Decimal = 0

                '                Dim saldoCompramn As Decimal = 0
                '                Dim saldoComprame As Decimal = 0
                '                Dim valAbonomn As Decimal = 0
                '                Dim valAbonome As Decimal = 0
                '                Dim ventaOriginalMN As Decimal = 0
                '                Dim ventaOriginalME As Decimal = 0

                '                ventaOriginalMN = CDec(rowArticulo.GetValue("compraMN"))
                '                ventaOriginalME = CDec(rowArticulo.GetValue("compraME"))

                '                saldoCompramn = CDec(rowArticulo.GetValue("importeMN"))
                '                saldoComprame = CDec(rowArticulo.GetValue("importeME"))

                '                valAbonomn = rowArticulo.GetValue("totalmn")
                '                valAbonome = rowArticulo.GetValue("totalme")

                '                saldoFinalmn = ventaOriginalMN - valAbonomn
                '                saldoFinalme = ventaOriginalME - valAbonome

                '                'If saldoFinalmn < 0 Then
                '                '    rowArticulo.SetValue("vcmn", 0)
                '                '    rowArticulo.SetValue("ValDevmn", 0)
                '                '    rowArticulo.SetValue("ValDevme", 0)
                '                '    rowArticulo.SetValue("action", "inactivo")
                '                '    Calculos()
                '                '    Throw New Exception("El monto ingresado supera al valor original del artículo!")

                '                'ElseIf saldoFinalmn >= 0 Then
                '                rowArticulo.SetValue("ValDevmn", valAbonomn)
                '                rowArticulo.SetValue("ValDevme", valAbonome)
                '                rowArticulo.SetValue("action", "activo")
                '                'End If

                '            Case Else

                '                Dim saldoFinalmn As Decimal = 0
                '                Dim saldoFinalme As Decimal = 0
                '                Dim ventaOriginalMN As Decimal = 0
                '                Dim ventaOriginalME As Decimal = 0

                '                Dim saldoCompramn As Decimal = 0
                '                Dim saldoComprame As Decimal = 0
                '                Dim valAbonomn As Decimal = 0
                '                Dim valAbonome As Decimal = 0

                '                ventaOriginalMN = CDec(rowArticulo.GetValue("compraMN"))
                '                ventaOriginalME = CDec(rowArticulo.GetValue("compraME"))

                '                saldoCompramn = CDec(rowArticulo.GetValue("importeMN"))
                '                saldoComprame = CDec(rowArticulo.GetValue("importeME"))


                '                valAbonomn = rowArticulo.GetValue("totalmn")
                '                valAbonome = rowArticulo.GetValue("totalme")


                '                'If saldoCompramn <= 0 Then
                '                '    rowArticulo.SetValue("vcmn", 0)
                '                '    rowArticulo.SetValue("vcme", 0)
                '                '    rowArticulo.SetValue("ValDevmn", 0)
                '                '    rowArticulo.SetValue("ValDevme", 0)
                '                '    Calculos()
                '                '    Throw New Exception("El Comprobante no esta disponible")
                '                'End If

                '                'If valAbonomn > ventaOriginalMN Then
                '                '    rowArticulo.SetValue("vcmn", 0)
                '                '    rowArticulo.SetValue("vcme", 0)
                '                '    rowArticulo.SetValue("ValDevmn", 0)
                '                '    rowArticulo.SetValue("ValDevme", 0)
                '                '    Calculos()
                '                '    Throw New Exception("El importe de la nota supera al importe de compra, " & ventaOriginalMN.ToString("N2"))
                '                'End If

                '                saldoFinalmn = saldoCompramn - valAbonomn
                '                saldoFinalme = saldoComprame - valAbonome

                '                If saldoFinalmn < 0 Then
                '                    rowArticulo.SetValue("ValDevmn", saldoFinalmn * -1)
                '                    rowArticulo.SetValue("ValDevme", saldoFinalme * -1)
                '                    rowArticulo.SetValue("action", "activo")
                '                Else
                '                    rowArticulo.SetValue("ValDevmn", 0)
                '                    rowArticulo.SetValue("ValDevme", 0)
                '                    rowArticulo.SetValue("action", "inactivo")
                '                End If
                '        End Select
                '        If rowArticulo.GetValue("bonificacion") = "NO" Then
                '            '     Calculos()
                '        End If
                '        rowArticulo.SetValue("almacenRef", r.GetValue("idAlmacen"))
                '        '    DockingClientPanel1.Enabled = True
                'End Select


            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Else
            MessageBox.Show("Deebe seleccionar un item!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub cboMotivo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMotivo.SelectedIndexChanged
        If Not IsNothing(cboMotivo.SelectedValue) Then
            Select Case cboMotivo.SelectedValue
                Case "1" ' disminuir cantidad
                    txtCanMov.Enabled = True
                    txtCanMov.DecimalValue = 0

                    txtBaseMov.Enabled = False
                    txtBaseMov.DecimalValue = 0
                    txtCanMov.Select()

                Case "2" ' disminuir importe

                    txtCanMov.Enabled = False
                    txtCanMov.DecimalValue = 0

                    txtBaseMov.Enabled = True
                    txtBaseMov.DecimalValue = 0
                    txtBaseMov.Select()

                Case "3" ' devolucion de existencias

                    txtCanMov.Enabled = True
                    txtCanMov.DecimalValue = 0

                    txtBaseMov.Enabled = True
                    txtBaseMov.DecimalValue = 0
                    txtCanMov.Select()
                Case "4"
                    txtCanMov.Enabled = False
                    txtCanMov.DecimalValue = 0

                    txtBaseMov.Enabled = True
                    txtBaseMov.DecimalValue = 0
                    txtCanMov.Select()
            End Select
        End If
    End Sub

    Private Sub cboMotivo_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboMotivo.SelectedValueChanged
        If Not IsNothing(cboMotivo.SelectedValue) Then
            Select Case cboMotivo.SelectedValue
                Case "1" ' disminuir cantidad
                    txtCanMov.Enabled = True
                    txtCanMov.DecimalValue = 0

                    txtBaseMov.Enabled = False
                    txtBaseMov.DecimalValue = 0

                Case "2" ' disminuir importe

                    txtCanMov.Enabled = False
                    txtCanMov.DecimalValue = 0

                    txtBaseMov.Enabled = True
                    txtBaseMov.DecimalValue = 0

                Case "3" ' devolucion de existencias

                    txtCanMov.Enabled = True
                    txtCanMov.DecimalValue = 0

                    txtBaseMov.Enabled = True
                    txtBaseMov.DecimalValue = 0

                Case "4"
                    txtCanMov.Enabled = True
                    txtCanMov.DecimalValue = 0

                    txtBaseMov.Enabled = False
                    txtBaseMov.DecimalValue = 0

            End Select
        End If
    End Sub

    Private Sub frmModalStockArticuloAlmacen_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cboMotivo_Click(sender As Object, e As EventArgs) Handles cboMotivo.Click

    End Sub
#End Region


End Class