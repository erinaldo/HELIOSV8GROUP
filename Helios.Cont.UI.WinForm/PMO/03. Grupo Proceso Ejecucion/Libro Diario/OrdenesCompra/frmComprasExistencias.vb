Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmComprasExistencias
    Public strTipoExistencia As List(Of String)
    Public ManipulacionEstado As String

    Sub Comprobantes()
        Me.Cursor = Cursors.WaitCursor
        Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
        datos.Clear()
        'With frmModalComprobantesTabla
        '    .lblTipo.Text = "10"
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        '    If datos.Count > 0 Then
        '        txtIdComprobante.Text = datos(0).ID
        '        txtComprobante.Text = datos(0).NombreCampo
        '        glosa()
        '        txtSerieComp.Focus()
        '        txtSerieComp.Select(0, txtSerieComp.Text.Length)
        '        If dgvNuevoDoc.Rows.Count > 0 Then
        '            CellEndEditRefresh()
        '        End If
        '    Else
        '        txtIdComprobante.Text = String.Empty
        '        txtComprobante.Text = String.Empty
        '        MsgBox("Debe ingresar un comprobante.", MsgBoxStyle.Information, "Atención!")
        '    End If
        'End With
        Me.Cursor = Cursors.Arrow
    End Sub

#Region "Arbol"
    Dim newNodeUsuario As TreeNode = New TreeNode("Usuario: " & "Jiuni")
    Dim newNodeComprobante As TreeNode = New TreeNode("Comprobante compra")
    Dim newNodeProveedor As TreeNode = New TreeNode("Datos del Proveedor")
    ' Dim newNodeCosto As TreeNode = New TreeNode("Datos Centro de Costo")
    '   Dim newNodePago As TreeNode = New TreeNode("Información del pago")
    Dim newNodeDetalle As TreeNode = New TreeNode("Detalle de la compra")
    Private Sub LoadTree()
        ' TODO: Agregar código a elementos en la vista de árbol
        With tvDatos
            '  Dim newNodeUsuario As TreeNode = New TreeNode("Usuario: " & cIDUsuario)
            tvDatos.Nodes.Add(newNodeUsuario)

            '  Dim newNodeComprobante As TreeNode = New TreeNode("Comprobante compra")
            newNodeComprobante.Tag = "IF"
            tvDatos.Nodes.Add(newNodeComprobante)

            '  Dim newNodeProveedor As TreeNode = New TreeNode("Datos del Proveedor")
            newNodeProveedor.Tag = "DP"
            tvDatos.Nodes.Add(newNodeProveedor)

            '  Dim newNodeCosto As TreeNode = New TreeNode("Datos Centro de Costo")
            'newNodeCosto.Tag = "DC"
            'tvDatos.Nodes.Add(newNodeCosto)

            '   Dim newNodePago As TreeNode = New TreeNode("Información del pago")
            'newNodePago.Tag = "IP"
            'tvDatos.Nodes.Add(newNodePago)

            '   Dim newNodeDetalle As TreeNode = New TreeNode("Detalle de la compra")
            newNodeDetalle.Tag = "DT"
            tvDatos.Nodes.Add(newNodeDetalle)
        End With
    End Sub
#End Region

#Region "TIMER"
    'Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
    '    If TiempoRestante > 0 Then
    '        lblAgregar.Visible = True
    '        lblMensaje.Visible = True
    '        tsSave.Enabled = False
    '        lblMensaje.Text = "Agregar otro en: " & TiempoRestante
    '        TiempoRestante = TiempoRestante - 1
    '    ElseIf TiempoRestante = 0 Then
    '        Dispose()
    '    Else
    '        Timer1.Enabled = False
    '        'Ejecuta tu función cuando termina el tiempo
    '        TiempoEjecutar(10)

    '    End If
    'End Sub
    Private TiempoRestante As Integer
    Public Sub TimerOn(ByRef Interval As Short)
        If Interval > 0 Then
            Timer1.Enabled = True
        Else
            Timer1.Enabled = False
        End If

    End Sub
    Public Function TiempoEjecutar(ByVal Tiempo As Integer)
        TiempoEjecutar = ""
        TiempoRestante = Tiempo  ' 1 minutos=60 segundos 
        Timer1.Interval = 1000

        Call TimerOn(1000) ' Hechanos a andar el timer
    End Function
#End Region

#Region "Métodos"


    Sub deletefila()
        Dim fila As Byte
        Try
            fila = dgvNuevoDoc.CurrentCell.RowIndex
            If fila > -1 And dgvNuevoDoc.Rows.Count > 0 Then
                '  total -= Single.Parse(dgvCentroCostos.Item(0, fila).Value)
                dgvNuevoDoc.Rows.RemoveAt(fila)
                Dim i As Integer
                For i = 0 To dgvNuevoDoc.Rows.Count - 1
                    dgvNuevoDoc.BeginEdit(True)
                    ' dgvNuevoDoc.Rows(i).BeginEdit()
                    '      dgvCentroCostos.Rows(i).Cells(0).Value() = i + 1
                    dgvNuevoDoc.EndEdit()
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Validar_Numeros(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        Dim Celda As DataGridViewCell = Me.dgvNuevoDoc.CurrentCell()

        If Celda.ColumnIndex = 7 Or Celda.ColumnIndex = 10 Or Celda.ColumnIndex = 11 Then

            If e.KeyChar = "."c Or e.KeyChar = ","c Then

                If InStr(Celda.EditedFormattedValue.ToString, ".", CompareMethod.Text) > 0 Then

                    e.Handled = True
                Else

                    e.Handled = False
                End If
            Else

                If Len(Trim(Celda.EditedFormattedValue.ToString)) > 0 Then

                    If Char.IsNumber(e.KeyChar) Or e.KeyChar = Convert.ToChar(8) Then

                        e.Handled = False
                    Else

                        e.Handled = True
                    End If
                Else

                    If e.KeyChar = "0"c Then

                        e.Handled = True
                    Else

                        If Char.IsNumber(e.KeyChar) Or e.KeyChar = Convert.ToChar(8) Then

                            e.Handled = False
                        Else

                            e.Handled = True
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Public Sub Bonificacion()
        '    Dim i As Integer
        Dim base1 As Decimal = 0
        Dim base2 As Decimal = 0
        Dim base3 As Decimal = 0
        Dim base4 As Decimal = 0
        Dim baseus1 As Decimal = 0
        Dim baseus2 As Decimal = 0
        Dim baseus3 As Decimal = 0
        Dim baseus4 As Decimal = 0
        Dim otc1 As Decimal = 0
        Dim otc2 As Decimal = 0
        Dim otc3 As Decimal = 0
        Dim otc4 As Decimal = 0
        Dim otc1US As Decimal = 0
        Dim otc2US As Decimal = 0
        Dim otc3US As Decimal = 0
        Dim otc4US As Decimal = 0
        Dim total As Decimal = 0
        Dim totalbase2 As Decimal = 0
        Dim totalbase3 As Decimal = 0
        Dim totalbase4 As Decimal = 0
        Dim igv As Decimal = 0
        Dim IGVUS As Decimal = 0
        Dim tus1 As Decimal = 0
        Dim tus2 As Decimal = 0
        Dim tus3 As Decimal = 0
        Dim tus4 As Decimal = 0


        'COLUMNAS
        Dim colCantidad As Decimal = 0
        Dim colPU As Decimal = 0
        Dim colPU_ME As Decimal = 0
        Dim colMN As Decimal = 0
        Dim colME As Decimal = 0

        For Each i As DataGridViewRow In dgvNuevoDoc.Rows
            colCantidad = i.Cells(7).Value
            colMN = i.Cells(10).Value
            colME = Math.Round(CDec(i.Cells(10).Value) / CDec(nudTipoCambio.Value), 2)
            colPU = Math.Round(CDec(i.Cells(10).Value) / colCantidad, 2)
            colPU_ME = Math.Round(colME / colCantidad, 2)
            '  If Not dgvNuevoDoc.Rows(i).DefaultCellStyle.BackColor = Color.FromArgb(209, 227, 254) Then
            If colCantidad > 0 Then

                If i.Cells(27).Value = "S" Then
                    totalbase4 += CDec(i.Cells(10).Value())
                    tus4 += CDec(i.Cells(11).Value()) ' total base 01
                    If rbNac.Checked = True Then
                        ' DATOS SOLES

                        Select Case i.Cells(1).Value
                            Case "4"
                                i.Cells(8).Value = colPU ' Math.Round(CDec(i.Cells(10).Value / i.Cells(7).Value), 2).ToString("N2") ' PRECIO UNITARIO SOLES
                                i.Cells(9).Value = colPU_ME ' Math.Round(CDec(i.Cells(11).Value / i.Cells(7).Value), 2).ToString("N2")
                                i.Cells(11).Value = colME ' Math.Round(CDec(i.Cells(10).Value / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2")  ' MONTO TOTAL DOLARES
                                i.Cells(10).Value = colMN

                                i.Cells(12).Value = "0.00"
                                i.Cells(13).Value = "0.00"
                                i.Cells(14).Value = "0.00"
                                i.Cells(15).Value = "0.00"
                                i.Cells(16).Value = "0.00"
                                i.Cells(17).Value = "0.00"
                                i.Cells(18).Value = "0.00"
                                i.Cells(19).Value = "0.00"
                            Case Else
                                i.Cells(8).Value = colPU ' Math.Round(CDec(i.Cells(10).Value / i.Cells(7).Value), 2).ToString("N2") ' PRECIO UNITARIO SOLES
                                i.Cells(9).Value = colPU_ME ' Math.Round(CDec(i.Cells(11).Value / i.Cells(7).Value), 2).ToString("N2")
                                i.Cells(10).Value = colMN
                                i.Cells(11).Value = colME ' Math.Round(CDec(i.Cells(10).Value / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES


                                i.Cells(12).Value = "0.00"
                                i.Cells(13).Value = "0.00"
                                i.Cells(14).Value = "0.00"
                                i.Cells(15).Value = "0.00"
                                i.Cells(16).Value = "0.00"
                                i.Cells(17).Value = "0.00"
                                i.Cells(18).Value = "0.00"
                                i.Cells(19).Value = "0.00"
                        End Select

                    Else 'If 'txtMoneda.Text = "2" Then
                        ' DATOS DOLARES

                        Select Case i.Cells(1).Value
                            Case "4"
                                i.Cells(8).Value = colPU ' Math.Round(CDec(i.Cells(10).Value / i.Cells(7).Value), 2).ToString("N2")
                                i.Cells(9).Value = colPU_ME ' Math.Round(CDec(i.Cells(11).Value / i.Cells(7).Value), 2).ToString("N2")  ' PRECIO UNITARIO DOLARES
                                i.Cells(10).Value = colMN ' Math.Round(CDec(i.Cells(11).Value * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                i.Cells(11).Value = colME

                                i.Cells(12).Value = "0.00"
                                i.Cells(13).Value = "0.00"
                                i.Cells(14).Value = "0.00"
                                i.Cells(15).Value = "0.00"
                                i.Cells(16).Value = "0.00"
                                i.Cells(17).Value = "0.00"
                                i.Cells(18).Value = "0.00"
                                i.Cells(19).Value = "0.00"
                            Case Else
                                i.Cells(8).Value = colPU ' Math.Round(CDec(i.Cells(10).Value / i.Cells(7).Value), 2).ToString("N2")
                                i.Cells(9).Value = colPU_ME ' Math.Round(CDec(i.Cells(11).Value / i.Cells(7).Value), 2).ToString("N2") ' PRECIO UNITARIO DOLARES
                                i.Cells(10).Value = colMN ' Math.Round(CDec(i.Cells(11).Value * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                i.Cells(11).Value = colME

                                i.Cells(12).Value = "0.00"
                                i.Cells(13).Value = "0.00"
                                i.Cells(14).Value = "0.00"
                                i.Cells(15).Value = "0.00"
                                i.Cells(16).Value = "0.00"
                                i.Cells(17).Value = "0.00"
                                i.Cells(18).Value = "0.00"
                                i.Cells(19).Value = "0.00"
                        End Select
                    End If
                End If
            End If
        Next

        Dim NUDVALUE As Decimal = Math.Round((nudIgv.Value / 100) + 1, 2)

        '*********************** SOLES ***********************************************
        '****************IMPUESTO 4*******************
        base4 = totalbase4
        nudBase4.Value = Math.Round(base4, NumDigitos)
        nudBase1.Value = 0
        nudBase2.Value = 0
        nudBase3.Value = 0

        nudMontoIgv1.Value = 0
        nudMontoIgv2.Value = 0
        nudMontoIgv3.Value = 0

        nudBaseus4.Value = Math.Round(tus4, NumDigitos)
        nudBaseus1.Value = 0
        nudBaseus2.Value = 0
        nudBaseus3.Value = 0

        nudMontoIgvus1.Value = 0
        nudMontoIgvus2.Value = 0
        nudMontoIgvus3.Value = 0
        '***********IMPORTE GRAVADO******************
        'subTotales("All")

        '  totales()
        totales_xx()
        TotalesCabeceras()

    End Sub

    Private Sub MyMethodOnCheckBoxes()
        'DO WHAT EVER WHEN THE SELECTED CHECKBOX IS CHECKED
        If CheckBoxClicked Then
            'DO WHAT DO YOU WANT TO, WHEN CHECKBOX IS NOT CHECKED!!
            '  MsgBox(True)
            Bonificacion()
            dgvNuevoDoc.Item(29, dgvNuevoDoc.CurrentRow.Index).Value = "S"

        ElseIf Not CheckBoxClicked Then

            CellEndEditRefresh()
            dgvNuevoDoc.Item(29, dgvNuevoDoc.CurrentRow.Index).Value = "N"

        End If
    End Sub

    Public Sub TotalesCabeceras()
        Dim cTotalMN As Decimal = 0
        Dim cTotalME As Decimal = 0

        Dim cTotalBI As Decimal = 0
        Dim cTotalBI_ME As Decimal = 0

        Dim cTotalIGV As Decimal = 0
        Dim cTotalIGV_ME As Decimal = 0

        Dim cTotalIsc As Decimal = 0
        Dim cTotalIsc_ME As Decimal = 0

        Dim cTotalOTC As Decimal = 0
        Dim cTotalOTC_ME As Decimal = 0
        For Each i As DataGridViewRow In dgvNuevoDoc.Rows
            cTotalMN += CDec(i.Cells(10).Value)
            cTotalME += CDec(i.Cells(11).Value)

            cTotalBI += CDec(i.Cells(12).Value)
            cTotalBI_ME += CDec(i.Cells(16).Value)

            cTotalIGV += CDec(i.Cells(14).Value)
            cTotalIGV_ME += CDec(i.Cells(18).Value)

            cTotalIsc += CDec(i.Cells(13).Value)
            cTotalIsc_ME += CDec(i.Cells(17).Value)

            cTotalOTC += CDec(i.Cells(15).Value)
            cTotalOTC_ME += CDec(i.Cells(19).Value)
        Next

        lblTotalBase.Text = cTotalBI.ToString("N2")
        lblTotalBaseUS.Text = cTotalBI_ME.ToString("N2")

        lblTotalISc.Text = cTotalIsc.ToString("N2")
        lblTotalIScUS.Text = cTotalIsc_ME.ToString("N2")

        lblTotalMontoIgv.Text = cTotalIGV.ToString("N2")
        lblTotalMontoIgvUS.Text = cTotalIGV_ME.ToString("N2")

        lblOtrostribTotal.Text = cTotalOTC.ToString("N2")
        lblOtrostribTotalUS.Text = cTotalOTC_ME.ToString("N2")

        Select Case txtIdComprobante.Text
            Case "02", "03"
                lblTotalAdquisiones.Text = cTotalMN   'cTotalMN.ToString("N2")
                lblTotalUS.Text = cTotalME   'cTotalME.ToString("N2")
            Case "08"
                'Instrucciones
            Case Else

                lblTotalAdquisiones.Text = cTotalBI + cTotalIGV   'cTotalMN.ToString("N2")
                lblTotalUS.Text = cTotalBI_ME + cTotalIGV_ME  'cTotalME.ToString("N2")
        End Select

    End Sub

    Public Sub totales_xx()
        '     Dim objService = HeliosSEProxy.CrearProxyHELIOS
        ' Dim t As DataTable
        Dim i As Integer
        'Dim base1, base2 As Decimal
        'Dim baseus1, baseus2 As Decimal
        'Dim otc1, otc2 As Decimal ', otc3, otc4
        'Dim otc1US, otc2US As Decimal ', otc3US, otc4US
        Dim total, totalbase2 As Decimal ' igv, IGVUS As Decimal ' totalp As Decimal , totalbase3, totalbase4,
        Dim tus1, tus2 As Decimal 'tus3, tus4 
        Dim totalIgv1 As Decimal = 0
        Dim totalIgv1_ME As Decimal = 0
        Dim totalIgv2 As Decimal = 0
        Dim totalIgv2_ME As Decimal = 0
        Dim totalIgv3 As Decimal = 0
        Dim totalIgv3_ME As Decimal = 0
        Dim totalIgv4 As Decimal = 0
        Dim totalIgv4_ME As Decimal = 0



        Dim totalBI3 As Decimal = 0
        Dim totalBI3_ME As Decimal = 0
        Dim totalBI4 As Decimal = 0
        Dim totalBI4_ME As Decimal = 0


        Dim NUDVALUE As Decimal = Math.Round((nudIgv.Value / 100) + 1, 2)
        For i = 0 To dgvNuevoDoc.Rows.Count - 1
            'total += carrito.Rows(i)(5)
            If Not dgvNuevoDoc.Rows(i).DefaultCellStyle.BackColor = Color.FromArgb(209, 227, 254) Then
                If dgvNuevoDoc.Rows(i).Cells(1).Value() = "1" Then

                    total += dgvNuevoDoc.Rows(i).Cells(12).Value() ' total base 01 soles
                    tus1 += dgvNuevoDoc.Rows(i).Cells(16).Value() ' total base 01 dolares
                    totalIgv1 += dgvNuevoDoc.Rows(i).Cells(14).Value()
                    totalIgv1_ME += dgvNuevoDoc.Rows(i).Cells(18).Value()

                ElseIf dgvNuevoDoc.Rows(i).Cells(1).Value() = "2" Then

                    totalbase2 += dgvNuevoDoc.Rows(i).Cells(12).Value()
                    tus2 += dgvNuevoDoc.Rows(i).Cells(16).Value() ' total base 01
                    totalIgv2 += dgvNuevoDoc.Rows(i).Cells(14).Value()
                    totalIgv2_ME += dgvNuevoDoc.Rows(i).Cells(18).Value()

                ElseIf dgvNuevoDoc.Rows(i).Cells(1).Value() = "3" Then
                    totalBI3 += dgvNuevoDoc.Rows(i).Cells(12).Value()
                    totalBI3_ME += dgvNuevoDoc.Rows(i).Cells(16).Value() ' total base 01
                    totalIgv3 += dgvNuevoDoc.Rows(i).Cells(14).Value()
                    totalIgv3_ME += dgvNuevoDoc.Rows(i).Cells(18).Value()

                ElseIf dgvNuevoDoc.Rows(i).Cells(1).Value() = "4" Then
                    totalBI4 += dgvNuevoDoc.Rows(i).Cells(12).Value()
                    totalBI4_ME += dgvNuevoDoc.Rows(i).Cells(16).Value() ' total base 01
                    totalIgv4 += dgvNuevoDoc.Rows(i).Cells(14).Value()
                    totalIgv4_ME += dgvNuevoDoc.Rows(i).Cells(18).Value()
                End If
            End If
        Next
        nudBase1.Value = total.ToString("N2")
        nudBaseus1.Value = tus1.ToString("N2")
        nudBase2.Value = totalbase2.ToString("N2")
        nudBaseus2.Value = tus2.ToString("N2")

        nudBase3.Value = totalBI3.ToString("N2")
        nudBaseus3.Value = totalBI3_ME.ToString("N2")
        nudBase4.Value = totalBI4.ToString("N2")
        nudBaseus4.Value = totalBI4_ME.ToString("N2")

        nudMontoIgv1.Value = totalIgv1.ToString("N2")
        nudMontoIgvus1.Value = totalIgv1_ME.ToString("N2")
        nudMontoIgv2.Value = totalIgv2.ToString("N2")
        nudMontoIgvus2.Value = totalIgv2_ME.ToString("N2")

        nudMontoIgv3.Value = totalIgv3.ToString("N2")
        nudMontoIgvus3.Value = totalIgv3_ME.ToString("N2")
        nudMontoIgv3.Value = totalIgv3.ToString("N2")
        nudMontoIgvus3.Value = totalIgv3_ME.ToString("N2")





    End Sub

    Private Sub CellEndEditRefresh()
        '**************************************************************
        If dgvNuevoDoc.Rows.Count > 0 Then
            'DECLARANDO VARIABLES

            For Each i As DataGridViewRow In dgvNuevoDoc.Rows

                Dim colDestinoGravado As String = 0
                colDestinoGravado = i.Cells(1).Value

                Dim colCantidad As Decimal = dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value


                Dim colBI As Decimal = 0
                Dim colBI_ME As Decimal = 0
                Dim colIGV_ME As Decimal = 0
                Dim colIGV As Decimal = 0
                Dim colMN As Decimal = i.Cells(10).Value
                Dim colME As Decimal = Math.Round(CDec(i.Cells(10).Value) / CDec(nudTipoCambio.Value), 2)
                Dim colPrecUnit As Decimal = 0
                Dim colPrecUnitUSD As Decimal = 0


                If colMN > 0 Then

                    colPrecUnit = Math.Round(colMN / colCantidad, 2)

                    colPrecUnitUSD = Math.Round(colME / colCantidad, 2)

                    colBI = Math.Round(colMN / 1.18, 2)
                    colBI_ME = Math.Round(colME / 1.18, 2)
                    colIGV = Math.Round((colMN / 1.18) * 0.18, 2)
                    colIGV_ME = Math.Round((colME / 1.18) * 0.18, 2)


                Else
                    colPrecUnit = 0

                    colPrecUnitUSD = 0

                    colBI = 0
                    colBI_ME = 0
                    colIGV = 0
                    colIGV_ME = 0
                End If
                Select Case txtIdComprobante.Text ' cboTipoDoc.SelectedValue
                    Case "08"
                        'If dgvDetalleCompra.Columns(e.ColumnIndex).Name = "ImporteNeto" Or dgvDetalleCompra.Columns(e.ColumnIndex).Name = "ImporteUS" Then 'Or dgvDetalleCompra.Columns(e.ColumnIndex).Name = "otrostributos" Or dgvDetalleCompra.Columns(e.ColumnIndex).Name = "OTCus" Then
                        '    totales_xx()
                        'End If
                    Case "03", "02"
                        '   If dgvDetalleCompra.Columns(e.ColumnIndex).Name = "montoSolessc" Or dgvDetalleCompra.Columns(e.ColumnIndex).Name = "Can1" Or dgvDetalleCompra.Columns(e.ColumnIndex).Name = "montoUsdsc" Then 'Or dgvDetalleCompra.Columns(e.ColumnIndex).Name = "otrostributos" Or dgvDetalleCompra.Columns(e.ColumnIndex).Name = "OTCus" Then
                        If nudTipoCambio.Value = 0.0 Then
                            MsgBox("Ingrese Tipo de Cambio..!")
                            nudTipoCambio.Focus()
                            nudTipoCambio.Select(0, nudTipoCambio.Text.Length)
                            Exit Sub
                        End If
                        Dim NUDIGV_VALUE As Decimal = Math.Round((nudIgv.Value / 100) + 1, 2)
                        If colCantidad = 0 And colMN = 0 And colME = 0 Then
                            i.Cells(8).Value() = "0.00"
                            i.Cells(9).Value() = "0.00"
                            Exit Sub
                        Else 'If colCantidad = 0 Then

                            If rbNac.Checked = True Then
                                ' DATOS SOLES
                                Select Case colDestinoGravado
                                    Case "4"
                                        i.Cells(8).Value() = "0.00"  'Math.Round(CDec(neto / cantidad), 4) ' PRECIO UNITARIO SOLES
                                        i.Cells(11).Value() = colME ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2")  ' MONTO TOTAL DOLARES
                                        i.Cells(10).Value() = colMN
                                        i.Cells(9).Value() = "0.00" ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), 4)

                                        i.Cells(12).Value() = "0.00"
                                        i.Cells(13).Value() = "0.00"
                                        i.Cells(14).Value() = "0.00"
                                        i.Cells(15).Value() = "0.00"
                                        i.Cells(16).Value() = "0.00"
                                        i.Cells(17).Value() = "0.00"
                                        i.Cells(18).Value() = "0.00"
                                        i.Cells(19).Value() = "0.00"
                                    Case Else
                                        i.Cells(8).Value() = "0.00"  'Math.Round(CDec(neto / cantidad), 4) ' PRECIO UNITARIO SOLES
                                        i.Cells(11).Value() = colME ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                        i.Cells(10).Value = colMN
                                        i.Cells(9).Value = "0.00" ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), 4)
                                        i.Cells(12).Value() = "0.00"
                                        i.Cells(13).Value() = "0.00"
                                        i.Cells(14).Value() = "0.00"
                                        i.Cells(15).Value() = "0.00"
                                        i.Cells(16).Value() = "0.00"
                                        i.Cells(17).Value() = "0.00"
                                        i.Cells(18).Value() = "0.00"
                                        i.Cells(19).Value() = "0.00"
                                End Select

                            ElseIf rbExt.Checked = True Then
                                ' DATOS DOLARES
                                Select Case colDestinoGravado
                                    Case "4"
                                        i.Cells(9).Value() = "0.00" 'Math.Round(CDec(netous / cantidad), 4) ' PRECIO UNITARIO DOLARES
                                        i.Cells(8).Value() = "0.00" 'Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), 2)
                                        i.Cells(10).Value() = colMN
                                        i.Cells(11).Value() = colME
                                        i.Cells(12).Value() = "0.00"
                                        i.Cells(13).Value() = "0.00"
                                        i.Cells(14).Value() = "0.00"
                                        i.Cells(15).Value() = "0.00"
                                        i.Cells(16).Value() = "0.00"
                                        i.Cells(17).Value() = "0.00"
                                        i.Cells(18).Value() = "0.00"
                                        i.Cells(19).Value() = "0.00"
                                    Case Else
                                        i.Cells(9).Value() = "0.00" 'Math.Round(CDec(netous / cantidad), 4) ' PRECIO UNITARIO DOLARES
                                        i.Cells(10).Value() = colMN ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                        i.Cells(11).Value() = colME ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                        i.Cells(8).Value() = "0.00" 'Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), 2)
                                        i.Cells(12).Value() = "0.00"
                                        i.Cells(13).Value() = "0.00"
                                        i.Cells(14).Value() = "0.00"
                                        i.Cells(15).Value() = "0.00"
                                        i.Cells(16).Value() = "0.00"
                                        i.Cells(17).Value() = "0.00"
                                        i.Cells(18).Value() = "0.00"
                                        i.Cells(19).Value() = "0.00"
                                End Select

                                '      End If
                            ElseIf colCantidad > 0 Then
                                If rbNac.Checked = True Then
                                    ' DATOS SOLES
                                    If i.Cells(1).Value = "4" Then
                                        i.Cells(7).Value() = colCantidad
                                        i.Cells(8).Value() = colPrecUnit ' Math.Round(CDec(neto / colCantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES
                                        i.Cells(9).Value() = colPrecUnitUSD ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / colCantidad), NumDigitos).ToString("N2")
                                        i.Cells(11).Value() = colME ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                        i.Cells(10).Value() = colMN 'CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2")

                                        i.Cells(12).Value() = "0.00"
                                        i.Cells(13).Value() = "0.00"
                                        i.Cells(14).Value() = "0.00"
                                        i.Cells(15).Value() = "0.00"
                                        i.Cells(16).Value() = "0.00"
                                        i.Cells(17).Value() = "0.00"
                                        i.Cells(18).Value() = "0.00"
                                        i.Cells(19).Value() = "0.00"
                                    Else
                                        i.Cells(7).Value() = colCantidad 'CDec(dgvDetalleCompra.Item(7, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                        i.Cells(8).Value() = colPrecUnit ' Math.Round(CDec(neto / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES
                                        i.Cells(9).Value() = colPrecUnitUSD ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                        i.Cells(11).Value() = colME ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                        i.Cells(10).Value() = colMN ' CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2")


                                        i.Cells(12).Value() = "0.00"
                                        i.Cells(13).Value() = "0.00"
                                        i.Cells(14).Value() = "0.00"
                                        i.Cells(15).Value() = "0.00"
                                        i.Cells(16).Value() = "0.00"
                                        i.Cells(17).Value() = "0.00"
                                        i.Cells(18).Value() = "0.00"
                                        i.Cells(19).Value() = "0.00"
                                    End If

                                ElseIf rbExt.Checked = True Then

                                    Select Case colDestinoGravado
                                        Case "4"
                                            ' DATOS DOLARES

                                            i.Cells(7).Value() = colCantidad ' CDec(dgvDetalleCompra.Item(7, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                            i.Cells(8).Value() = colPrecUnit ' Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                            i.Cells(9).Value() = colPrecUnitUSD ' Math.Round(CDec(netous / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO DOLARES
                                            i.Cells(10).Value() = colMN ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                            i.Cells(11).Value() = colME ' CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2")


                                            i.Cells(12).Value() = "0.00"
                                            i.Cells(13).Value() = "0.00"
                                            i.Cells(14).Value() = "0.00"
                                            i.Cells(15).Value() = "0.00"
                                            i.Cells(16).Value() = "0.00"
                                            i.Cells(17).Value() = "0.00"
                                            i.Cells(18).Value() = "0.00"
                                            i.Cells(19).Value() = "0.00"
                                        Case Else
                                            ' DATOS DOLARES
                                            i.Cells(7).Value() = colCantidad ' CDec(dgvDetalleCompra.Item(7, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                            i.Cells(8).Value() = colPrecUnit ' Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                            i.Cells(9).Value() = colPrecUnitUSD ' Math.Round(CDec(netous / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO DOLARES
                                            i.Cells(10).Value() = colMN ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                            i.Cells(11).Value() = colME ' CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2")


                                            i.Cells(12).Value() = "0.00"
                                            i.Cells(13).Value() = "0.00"
                                            i.Cells(14).Value() = "0.00"
                                            i.Cells(15).Value() = "0.00"
                                            i.Cells(16).Value() = "0.00"
                                            i.Cells(17).Value() = "0.00"
                                            i.Cells(18).Value() = "0.00"
                                            i.Cells(19).Value() = "0.00"
                                    End Select

                                End If
                            End If
                            totales_xx()
                            TotalesCabeceras()

                        End If

                        '**********************************************************************************************************************************************************************************
                    Case Else
                        '       If dgvDetalleCompra.Columns(e.ColumnIndex).Name = "montoSolessc" Then
                        If nudTipoCambio.Value = 0.0 Then
                            MsgBox("Ingrese Tipo de Cambio..!")
                            nudTipoCambio.Focus()
                            nudTipoCambio.Select(0, nudTipoCambio.Text.Length)
                            Exit Sub
                        End If

                        Dim NUDIGV_VALUE As Decimal = Math.Round((nudIgv.Value / 100) + 1, 2)
                        If colCantidad = 0 And colMN = 0 And colME = 0 Then
                            i.Cells(8).Value() = "0.00"
                            i.Cells(9).Value() = "0.00"
                            Exit Sub

                        ElseIf colCantidad = 0 Then

                            If rbNac.Checked = True Then
                                ' DATOS SOLES
                                Select Case colDestinoGravado
                                    Case "4"
                                        i.Cells(8).Value() = "0.00"  'Math.Round(CDec(neto / cantidad), 4) ' PRECIO UNITARIO SOLES
                                        i.Cells(9).Value() = "0.00" ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), 4)
                                        i.Cells(11).Value() = colME ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos) ' MONTO TOTAL DOLARES
                                        i.Cells(10).Value() = colMN ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos) ' MONTO TOTAL DOLARES

                                    Case Else

                                        ''   If dgvDetalleCompra.Item(27, dgvDetalleCompra.CurrentRow.Index).Value() = "S" Then
                                        'dgvDetalleCompra.Item(8, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00"  'Math.Round(CDec(neto / cantidad), 4) ' PRECIO UNITARIO SOLES
                                        'dgvDetalleCompra.Item(9, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), 4)
                                        'dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() = colMN ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                        'dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() = colME ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                        'dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" ' monto para el kardex
                                        'dgvDetalleCompra.Item(14, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" ' monto igv del item
                                        'dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" ' monto para el kardex USD
                                        'dgvDetalleCompra.Item(18, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" ' monto para el IGV USD
                                        'dgvDetalleCompra.Item(19, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" ' monto OTROS TRIBUTOS DOLARES
                                        'Else
                                        i.Cells(8).Value() = "0.00"  'Math.Round(CDec(neto / cantidad), 4) ' PRECIO UNITARIO SOLES
                                        i.Cells(9).Value() = "0.00" ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), 4)
                                        i.Cells(10).Value() = colMN ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                        i.Cells(11).Value() = colME ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                        i.Cells(12).Value() = colBI ' Math.Round(CDec(neto / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                        i.Cells(14).Value() = colIGV  ' Math.Round(CDec(neto - CDec(dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto igv del item

                                        i.Cells(16).Value() = colBI_ME ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex USD
                                        i.Cells(18).Value() = colIGV_ME ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() - CDec(dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto para el IGV USD


                                        i.Cells(19).Value() = Math.Round(CDec(i.Cells(15).Value() / nudTipoCambio.Value), NumDigitos).ToString("N2") ' monto OTROS TRIBUTOS DOLARES
                                        '   End If
                                End Select

                            ElseIf rbExt.Checked = True Then
                                ' DATOS DOLARES
                                Select Case colDestinoGravado
                                    Case "4"
                                        i.Cells(9).Value() = "0.00" 'Math.Round(CDec(netous / cantidad), 4) ' PRECIO UNITARIO DOLARES
                                        i.Cells(8).Value() = "0.00" 'Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), 2)
                                        i.Cells(10).Value() = colMN ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                        i.Cells(11).Value() = colME

                                        ' dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos) ' monto para el kardex
                                        ' dgvDetalleCompra.Item(14, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() - CDec(dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos) ' igv del item

                                        '  dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(netous / CDec(NUDIGV_VALUE)), NumDigitos) ' monto para el kardex
                                        '  dgvDetalleCompra.Item(18, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(netous - CDec(dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos) ' monto para el IGV

                                        '  dgvDetalleCompra.Item(15, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvDetalleCompra.Item(19, dgvDetalleCompra.CurrentRow.Index).Value() * nudTipoCambio.Value), NumDigitos) ' monto OTROS TRIBUTOS SOLES
                                    Case Else

                                        'If dgvDetalleCompra.Item(27, dgvDetalleCompra.CurrentRow.Index).Value() = "S" Then
                                        '    dgvDetalleCompra.Item(9, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" 'Math.Round(CDec(netous / cantidad), 4) ' PRECIO UNITARIO DOLARES
                                        '    dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() = colMN 'Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                        '    dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() = colME

                                        '    dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" ' monto para el kardex
                                        '    dgvDetalleCompra.Item(14, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" ' igv del item

                                        '    dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" ' monto para el kardex
                                        '    dgvDetalleCompra.Item(18, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" ' monto para el IGV
                                        '    dgvDetalleCompra.Item(8, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" 'Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), 2)
                                        '    dgvDetalleCompra.Item(15, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" ' monto OTROS TRIBUTOS SOLES
                                        'Else
                                        i.Cells(8).Value() = "0.00"
                                        i.Cells(9).Value() = "0.00"
                                        i.Cells(10).Value() = colMN
                                        i.Cells(11).Value() = colME

                                        i.Cells(12).Value() = colBI ' Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                        i.Cells(14).Value() = colIGV ' Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() - CDec(dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' igv del item

                                        i.Cells(16).Value() = colBI_ME ' Math.Round(CDec(netous / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                        i.Cells(18).Value() = colIGV_ME ' Math.Round(CDec(netous - CDec(dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto para el IGV

                                        i.Cells(15).Value() = Math.Round(CDec(i.Cells(19).Value() * nudTipoCambio.Value), NumDigitos).ToString("N2") ' monto OTROS TRIBUTOS SOLES
                                        'End If
                                End Select

                            End If
                        ElseIf colCantidad > 0 Then
                            If rbNac.Checked = True Then
                                ' DATOS SOLES
                                If colDestinoGravado = "4" Then
                                    i.Cells(7).Value() = colCantidad ' CDec(dgvDetalleCompra.Item(7, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                    i.Cells(8).Value() = colPrecUnit ' Math.Round(CDec(neto / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES
                                    i.Cells(9).Value() = colPrecUnitUSD ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                    i.Cells(11).Value() = colME ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                    i.Cells(10).Value() = colMN ' CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2")
                                    '  dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(neto / CDec(NUDIGV_VALUE)), NumDigitos) ' monto para el kardex
                                    '  dgvDetalleCompra.Item(14, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(neto - CDec(dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos) ' monto igv del item

                                    ' dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos) ' monto para el kardex USD
                                    ' dgvDetalleCompra.Item(18, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() - CDec(dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos) ' monto para el IGV USD


                                    'dgvDetalleCompra.Item(19, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvDetalleCompra.Item(15, dgvDetalleCompra.CurrentRow.Index).Value() / nudTipoCambio.Value), NumDigitos) ' monto OTROS TRIBUTOS DOLARES
                                Else
                                    If i.Cells(27).Value() = "S" Then
                                        i.Cells(7).Value() = colCantidad '  CDec(dgvDetalleCompra.Item(7, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                        i.Cells(8).Value() = colPrecUnit ' Math.Round(CDec(neto / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES
                                        i.Cells(9).Value() = colPrecUnitUSD ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                        i.Cells(11).Value() = colME ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                        i.Cells(10).Value() = colMN ' CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2")
                                        i.Cells(12).Value() = "0.00" ' monto para el kardex
                                        i.Cells(14).Value() = "0.00" ' monto igv del item

                                        i.Cells(16).Value() = "0.00" ' monto para el kardex USD
                                        i.Cells(18).Value() = "0.00" ' monto para el IGV USD


                                        i.Cells(19).Value() = "0.00" ' monto OTROS TRIBUTOS DOLARES
                                    Else
                                        i.Cells(7).Value() = colCantidad ' CDec(dgvDetalleCompra.Item(7, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                        i.Cells(8).Value() = colPrecUnit ' Math.Round(CDec(neto / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES
                                        i.Cells(9).Value() = colPrecUnitUSD ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                        i.Cells(11).Value() = colME ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                        i.Cells(10).Value() = colMN ' CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2")
                                        i.Cells(12).Value() = colBI ' Math.Round(CDec(neto / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                        i.Cells(14).Value() = colIGV ' Math.Round(CDec(neto - CDec(dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto igv del item

                                        i.Cells(16).Value() = colBI_ME ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex USD
                                        i.Cells(18).Value() = colIGV_ME ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() - CDec(dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto para el IGV USD


                                        i.Cells(19).Value() = Math.Round(CDec(i.Cells(15).Value() / nudTipoCambio.Value), NumDigitos).ToString("N2") ' monto OTROS TRIBUTOS DOLARES

                                    End If

                                End If

                            ElseIf rbExt.Checked = True Then

                                Select Case colDestinoGravado
                                    Case "4"
                                        ' DATOS DOLARES
                                        i.Cells(7).Value() = colCantidad ' CDec(dgvDetalleCompra.Item(7, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                        i.Cells(8).Value() = colPrecUnit ' Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                        i.Cells(9).Value() = colPrecUnitUSD ' Math.Round(CDec(netous / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO DOLARES
                                        i.Cells(10).Value() = colMN ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                        i.Cells(11).Value() = colME ' CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2")
                                        '  dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos) ' monto para el kardex
                                        '  dgvDetalleCompra.Item(14, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() - CDec(dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos) ' igv del item

                                        ' dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(netous / CDec(NUDIGV_VALUE)), NumDigitos) ' monto para el kardex
                                        ' dgvDetalleCompra.Item(18, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(netous - CDec(dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos) ' monto para el IGV

                                        ' dgvDetalleCompra.Item(15, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvDetalleCompra.Item(19, dgvDetalleCompra.CurrentRow.Index).Value() * nudTipoCambio.Value), NumDigitos) ' monto OTROS TRIBUTOS SOLES
                                    Case Else
                                        ' DATOS DOLARES
                                        If i.Cells(27).Value() = "S" Then
                                            i.Cells(7).Value() = colCantidad ' CDec(dgvDetalleCompra.Item(7, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                            i.Cells(8).Value() = colPrecUnit ' Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                            i.Cells(9).Value() = colPrecUnitUSD ' Math.Round(CDec(netous / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO DOLARES
                                            i.Cells(10).Value() = colMN ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                            i.Cells(11).Value() = colME ' CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2")
                                            i.Cells(12).Value() = "0.00" ' monto para el kardex
                                            i.Cells(14).Value() = "0.00" ' igv del item

                                            i.Cells(16).Value() = "0.00" ' monto para el kardex
                                            i.Cells(18).Value() = "0.00" ' monto para el IGV

                                            i.Cells(15).Value() = "0.00" ' monto OTROS TRIBUTOS SOLES
                                        Else
                                            i.Cells(7).Value() = colCantidad ' CDec(dgvDetalleCompra.Item(7, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                            i.Cells(8).Value() = colPrecUnit ' Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                            i.Cells(9).Value() = colPrecUnitUSD ' Math.Round(CDec(netous / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO DOLARES
                                            i.Cells(10).Value() = colMN ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                            i.Cells(11).Value() = colME ' CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2")
                                            i.Cells(12).Value() = colBI ' Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                            i.Cells(14).Value() = colIGV ' Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() - CDec(dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' igv del item

                                            i.Cells(16).Value() = colBI_ME ' Math.Round(CDec(netous / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                            i.Cells(18).Value() = colIGV_ME ' Math.Round(CDec(netous - CDec(dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto para el IGV

                                            i.Cells(15).Value() = Math.Round(CDec(i.Cells(19).Value() * nudTipoCambio.Value), NumDigitos).ToString("N2") ' monto OTROS TRIBUTOS SOLES
                                        End If

                                End Select

                            End If
                        End If
                        totales_xx()
                        TotalesCabeceras()


                End Select
            Next
        End If

    End Sub

    Private Sub glosa()
        If Not String.IsNullOrEmpty(txtSerieComp.Text) And Not String.IsNullOrEmpty(txtNumeroComp.Text) And _
        Not String.IsNullOrEmpty(txtidProveedor.Text) Then
            txtGlosa.Text = String.Concat("Por compras", Space(1), "según/ ", Space(1), txtComprobante.Text, Space(1), "Nro.", Space(1), txtSerieComp.Text, "-", txtNumeroComp.Text, ", de Fecha:", Space(1), txtFechaComprobante.Text, Space(1))
        End If
    End Sub
#End Region

#Region "Métodos manipulación data"
    Public Sub UbicarDocumento(ByVal intIdDocumento As Integer)
        Dim objDoc As New DocumentoSA
        Dim objDocCompra As New DocumentoCompraSA
        Dim objDocCompraDet As New DocumentoCompraDetalleSA
        Dim objTabla As New tablaDetalleSA
        Dim objEntidad As New entidadSA
        Dim nEntidad As New entidad

        Try
            With objDoc.UbicarDocumento(intIdDocumento)
                txtFechaComprobante.Text = .fechaProceso
                'COMPROBANTE
                With objTabla.GetUbicarTablaID(10, .tipoDoc)
                    txtIdComprobante.Text = .codigoDetalle
                    txtComprobante.Text = .descripcion
                End With
            End With
         
            'CABECERA COMPROBANTE
            With objDocCompra.UbicarDocumentoCompra(intIdDocumento)
                lblIdDocumento.Text = .idDocumento
                lblPeriodo.Text = .fechaContable
                txtSerieComp.Text = .serie
                txtNumeroComp.Text = .numeroDoc
                'PROVEEDOR
                nEntidad = objEntidad.UbicarEntidadPorID(.idProveedor).First()
                txtRuc.Text = nEntidad.nrodoc
                txtCuenta.Text = nEntidad.cuentaAsiento
                txtidProveedor.Text = nEntidad.idEntidad
                txtProveedor.Text = nEntidad.nombreCompleto

                '_::::::::::::::::::        :::::::::::::::::::
                nudTipoCambio.Value = .tcDolLoc
            End With


            'DETALLE DE LA COMPRA
            dgvNuevoDoc.Rows.Clear()
            Dim VALUEDES As String = ""
            For Each i In objDocCompraDet.UbicarDocumentoCompraDetalle(intIdDocumento)
                If i.destino = "1" Then
                    VALUEDES = "1"
                ElseIf i.destino.Trim = "2" Then
                    VALUEDES = "2"
                ElseIf i.destino.Trim = "3" Then
                    VALUEDES = "3"
                ElseIf i.destino.Trim = "4" Then
                    VALUEDES = "4"
                End If

                dgvNuevoDoc.Rows.Add(i.secuencia,
                                     VALUEDES,
                                     i.idItem,
                                     i.descripcionItem,
                                     i.unidad2,
                                     i.monto2,
                                     i.unidad1,
                                     FormatNumber(i.monto1, 2),
                                     FormatNumber(i.precioUnitario, 2),
                                     FormatNumber(i.precioUnitarioUS, 2),
                                     FormatNumber(i.importe, 2),
                                     FormatNumber(i.importeUS, 2),
                                     FormatNumber(i.montokardex, 2),
                                     FormatNumber(i.montoIsc, 2),
                                     FormatNumber(i.montoIgv, 2),
                                     FormatNumber(i.otrosTributos, 2),
                                     FormatNumber(i.montokardexUS, 2),
                                     FormatNumber(i.montoIscUS, 2),
                                     FormatNumber(i.montoIgvUS, 2),
                                     FormatNumber(i.otrosTributosUS, 2),
                                     ENTITY_ACTIONS.UPDATE, i.tipoExistencia,
                                     i.CuentaItem,
                                     i.preEvento,
                                     Nothing, Nothing, Nothing,
                                     IIf(i.bonificacion = "S", "S", "N"), Nothing, i.bonificacion, i.almacenRef)
            Next


            lblTotalItems.Text = "Nro. de items: " & dgvNuevoDoc.Rows.Count
            totales_xx()
            TotalesCabeceras()
        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try

    End Sub

    Sub Grabar()
        Dim CompraSA As New DocumentoCompraSA
        Dim ndocumento As New documento()
        Dim nDocumentoCompra As New documentocompra()
        Dim objDocumentoCompraDet As New documentocompradetalle
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        Dim g As New ListViewGroup

        Dim ListaDetalle As New List(Of documentocompradetalle)
        With ndocumento
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .idProyecto = GProyectos.IdProyectoActividad
            .tipoDoc = "00"
            .fechaProceso = txtFechaComprobante.Value
            .nroDoc = txtSerieComp.Text.Trim & "-" & txtNumeroComp.Text.Trim
            .idOrden = Nothing ' Me.IdOrden
            .tipoOperacion = "02"
            .usuarioActualizacion = "NN"
            .fechaActualizacion = DateTime.Now
        End With

        With nDocumentoCompra
            .codigoLibro = "1"
            .tipoDoc = "00"
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = txtFechaComprobante.Value ' PERIODO
            .fechaContable = lblPeriodo.Text
            .serie = txtSerieComp.Text.Trim
            .numeroDoc = txtNumeroComp.Text
            .idProveedor = txtidProveedor.Text
            .nombreProveedor = txtProveedor.Text
            .monedaDoc = IIf(rbNac.Checked = True, "1", "2")
            .tasaIgv = nudIgv.Value ' IIf(IsNothing(nudIgv.Value) Or String.IsNullOrEmpty(nudIgv.Value) Or String.IsNullOrWhiteSpace(nudIgv.Value), Nothing, Trim(nudIgv.Value))
            .tcDolLoc = IIf(nudTipoCambio.Value = 0 Or nudTipoCambio.Value = "0.00", 0, CDec(nudTipoCambio.Value))
            .tipoRecaudo = Nothing
            .regimen = Nothing
            .tasaRegimen = 0
            .nroRegimen = Nothing
            '****************** DESTINO EN SOLES ************************************************************************
            .bi01 = IIf(nudBase1.Value = 0 Or nudBase1.Value = "0.00", CDec(0.0), CDec(nudBase1.Value))
            .bi02 = IIf(nudBase2.Value = 0 Or nudBase2.Value = "0.00", CDec(0.0), CDec(nudBase2.Value))
            .bi03 = IIf(nudBase3.Value = 0 Or nudBase3.Value = "0.00", CDec(0.0), CDec(nudBase3.Value))
            .bi04 = IIf(nudBase4.Value = 0 Or nudBase4.Value = "0.00", CDec(0.0), CDec(nudBase4.Value))
            .isc01 = IIf(nudIsc1.Value = 0 Or nudIsc1.Value = "0.00", CDec(0.0), CDec(nudIsc1.Value))
            .isc02 = IIf(nudIsc2.Value = 0 Or nudIsc2.Value = "0.00", CDec(0.0), CDec(nudIsc2.Value))
            .isc03 = IIf(nudIsc3.Value = 0 Or nudIsc3.Value = "0.00", CDec(0.0), CDec(nudIsc3.Value))
            .igv01 = IIf(nudMontoIgv1.Value = 0 Or nudMontoIgv1.Value = "0.00", CDec(0.0), CDec(nudMontoIgv1.Value))
            .igv02 = IIf(nudMontoIgv2.Value = 0 Or nudMontoIgv2.Value = "0.00", CDec(0.0), CDec(nudMontoIgv2.Value))
            .igv03 = IIf(nudMontoIgv3.Value = 0 Or nudMontoIgv3.Value = "0.00", CDec(0.0), CDec(nudMontoIgv3.Value))
            .otc01 = IIf(nudOtrosTributos1.Value = 0 Or nudOtrosTributos1.Value = "0.00", CDec(0.0), CDec(nudOtrosTributos1.Value))
            .otc02 = IIf(nudOtrosTributos2.Value = 0 Or nudOtrosTributos2.Value = "0.00", CDec(0.0), CDec(nudOtrosTributos2.Value))
            .otc03 = IIf(nudOtrosTributos3.Value = 0 Or nudOtrosTributos3.Value = "0.00", CDec(0.0), CDec(nudOtrosTributos3.Value))
            .otc04 = IIf(nudOtrosTributos4.Value = 0 Or nudOtrosTributos4.Value = "0.00", CDec(0.0), CDec(nudOtrosTributos4.Value))
            '****************************************************************************************************************

            '****************** DESTINO EN DOLARES ************************************************************************
            .bi01us = IIf(nudBaseus1.Value = 0 Or nudBaseus1.Value = "0.00", CDec(0.0), CDec(nudBaseus1.Value))
            .bi02us = IIf(nudBaseus2.Value = 0 Or nudBaseus2.Value = "0.00", CDec(0.0), CDec(nudBaseus2.Value))
            .bi03us = IIf(nudBaseus3.Value = 0 Or nudBaseus3.Value = "0.00", CDec(0.0), CDec(nudBaseus3.Value))
            .bi04us = IIf(nudBaseus4.Value = 0 Or nudBaseus4.Value = "0.00", CDec(0.0), CDec(nudBaseus4.Value))
            .isc01us = IIf(nudIscus1.Value = 0 Or nudIscus1.Value = "0.00", CDec(0.0), CDec(nudIscus1.Value))
            .isc02us = IIf(nudIscus2.Value = 0 Or nudIscus2.Value = "0.00", CDec(0.0), CDec(nudIscus2.Value))
            .isc03us = IIf(nudIscus3.Value = 0 Or nudIscus3.Value = "0.00", CDec(0.0), CDec(nudIscus3.Value))
            .igv01us = IIf(nudMontoIgvus1.Value = 0 Or nudMontoIgvus1.Value = "0.00", CDec(0.0), CDec(nudMontoIgvus1.Value))
            .igv02us = IIf(nudMontoIgvus2.Value = 0 Or nudMontoIgvus2.Value = "0.00", CDec(0.0), CDec(nudMontoIgvus2.Value))
            .igv03us = IIf(nudMontoIgvus3.Value = 0 Or nudMontoIgvus3.Value = "0.00", CDec(0.0), CDec(nudMontoIgvus3.Value))
            .otc01us = IIf(nudOtrosTributosus1.Value = 0 Or nudOtrosTributosus1.Value = "0.00", CDec(0.0), CDec(nudOtrosTributosus1.Value))
            .otc02us = IIf(nudOtrosTributosus2.Value = 0 Or nudOtrosTributosus2.Value = "0.00", CDec(0.0), CDec(nudOtrosTributosus2.Value))
            .otc03us = IIf(nudOtrosTributosus3.Value = 0 Or nudOtrosTributosus3.Value = "0.00", CDec(0.0), CDec(nudOtrosTributosus3.Value))
            .otc04us = IIf(nudOtrosTributosus4.Value = 0 Or nudOtrosTributosus4.Value = "0.00", CDec(0.0), CDec(nudOtrosTributosus4.Value))
            '****************************************************************************************************************
            .importeTotal = IIf(lblTotalAdquisiones.Text = 0 Or lblTotalAdquisiones.Text = "0.00", CDec(0.0), CDec(lblTotalAdquisiones.Text))
            .importeUS = IIf(lblTotalUS.Text = 0 Or lblTotalUS.Text = "0.00", CDec(0.0), CDec(lblTotalUS.Text))

            .destino = TIPO_COMPRA.ORDEN_COMPRA
            .estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
            .glosa = IIf(IsNothing(txtGlosa.Text) Or String.IsNullOrEmpty(txtGlosa.Text) Or String.IsNullOrWhiteSpace(txtGlosa.Text), Nothing, Trim(txtGlosa.Text.Trim))
            .referenciaDestino = Nothing ' IIf(IsNothing(txtDestinoref.Text) Or String.IsNullOrEmpty(txtDestinoref.Text) Or String.IsNullOrWhiteSpace(txtDestinoref.Text), Nothing, Trim(txtDestinoref.Text.Trim))
            .tipoCompra = TIPO_COMPRA.ORDEN_COMPRA
            ' .DocumentoSustentado = "S"
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With
        ndocumento.documentocompra = nDocumentoCompra

        Dim S As Integer = 0
        For Each i As DataGridViewRow In dgvNuevoDoc.Rows
            objDocumentoCompraDet = New documentocompradetalle
            objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoCompraDet.IdEstablecimiento = GEstableciento.IdEstablecimiento
            objDocumentoCompraDet.FechaDoc = txtFechaComprobante.Value
            objDocumentoCompraDet.Action = dgvNuevoDoc.Rows(S).Cells(20).Value()
            '  If dgvNuevoDoc.Rows(S).Cells(20).Value() = ENTITY_ACTIONS.INSERT Then
            If dgvNuevoDoc.Rows(S).Cells(1).Value() = "1" Then '   ADQ. GRAVADAS DESTINADAS A OPE.GRAVADAS Y/O EXPORTACIONES" Then
                objDocumentoCompraDet.destino = "1"
            ElseIf dgvNuevoDoc.Rows(S).Cells(1).Value() = "2" Then '   ADQ. GRAV DEST CONJUNTAMENTE A OPER GRAV Y NO GRAV" Then
                objDocumentoCompraDet.destino = "2"
            ElseIf dgvNuevoDoc.Rows(S).Cells(1).Value() = "3" Then '   ADQ. GRAVADAS DESTINADAS A OPER.NO GRAVADAS" Then
                objDocumentoCompraDet.destino = "3"
            ElseIf dgvNuevoDoc.Rows(S).Cells(1).Value() = "4" Then '   ADQUISICIONES NO GRAVADAS" Then
                objDocumentoCompraDet.destino = "4"
            End If
            objDocumentoCompraDet.CuentaItem = dgvNuevoDoc.Rows(S).Cells(22).Value()
            objDocumentoCompraDet.idItem = dgvNuevoDoc.Rows(S).Cells(2).Value()
            objDocumentoCompraDet.tipoExistencia = dgvNuevoDoc.Rows(S).Cells(21).Value()
            objDocumentoCompraDet.descripcionItem = dgvNuevoDoc.Rows(S).Cells(3).Value()
            objDocumentoCompraDet.unidad1 = dgvNuevoDoc.Rows(S).Cells(6).Value().ToString.Trim
            objDocumentoCompraDet.monto1 = dgvNuevoDoc.Rows(S).Cells(7).Value()
            objDocumentoCompraDet.unidad2 = dgvNuevoDoc.Rows(S).Cells(4).Value().ToString.Trim 'IDPRESENTACION
            objDocumentoCompraDet.monto2 = dgvNuevoDoc.Rows(S).Cells(5).Value() ' PRESENTACION
            objDocumentoCompraDet.precioUnitario = dgvNuevoDoc.Rows(S).Cells(8).Value()
            objDocumentoCompraDet.precioUnitarioUS = dgvNuevoDoc.Rows(S).Cells(9).Value()
            objDocumentoCompraDet.importe = dgvNuevoDoc.Rows(S).Cells(10).Value()
            objDocumentoCompraDet.importeUS = dgvNuevoDoc.Rows(S).Cells(11).Value()
            objDocumentoCompraDet.montokardex = dgvNuevoDoc.Rows(S).Cells(12).Value()
            objDocumentoCompraDet.montoIsc = CDec(dgvNuevoDoc.Rows(S).Cells(13).Value())
            objDocumentoCompraDet.montoIgv = CDec(dgvNuevoDoc.Rows(S).Cells(14).Value())
            objDocumentoCompraDet.otrosTributos = CDec(dgvNuevoDoc.Rows(S).Cells(15).Value())
            '**********************************************************************************
            objDocumentoCompraDet.montokardexUS = CDec(dgvNuevoDoc.Rows(S).Cells(16).Value())
            objDocumentoCompraDet.montoIscUS = CDec(dgvNuevoDoc.Rows(S).Cells(17).Value())
            objDocumentoCompraDet.montoIgvUS = CDec(dgvNuevoDoc.Rows(S).Cells(18).Value())
            objDocumentoCompraDet.otrosTributosUS = CDec(dgvNuevoDoc.Rows(S).Cells(19).Value())
            objDocumentoCompraDet.preEvento = dgvNuevoDoc.Rows(S).Cells(23).Value() '= "00", Nothing, dgvNuevoDoc.Rows(S).Cells(23).Value())
            objDocumentoCompraDet.bonificacion = dgvNuevoDoc.Rows(S).Cells(29).Value()
            '**********************************************************************************
            objDocumentoCompraDet.usuarioModificacion = "Jiuni"
            objDocumentoCompraDet.fechaModificacion = DateTime.Now
            objDocumentoCompraDet.FechaVcto = Nothing ' IIf(IsNothing(dgvNuevoDoc.Rows(S).Cells(28).Value()), Nothing, CDate(dgvNuevoDoc.Rows(S).Cells(28).Value()))
            ' objDocumentoCompraDet.BonificacionMN =
            ListaDetalle.Add(objDocumentoCompraDet)
            '  End If
        Next
        ndocumento.documentocompra.documentocompradetalle = ListaDetalle
        '  Dim xcod As Integer = CompraSA.SaveDocumentoCompra(ndocumento)
        lblEstado.Text = "orden de compra registrndocumentoada!"
        lblEstado.Image = My.Resources.ok4

        ' g = New ListViewGroup(ndocumento.documentocompra.fechaDoc.Value.Date)
        Dim n As New ListViewItem(0)
        n.SubItems.Add("02")
        n.SubItems.Add(ndocumento.documentocompra.fechaDoc)
        n.SubItems.Add(ndocumento.documentocompra.tipoDoc)
        n.SubItems.Add(ndocumento.documentocompra.serie)
        n.SubItems.Add(ndocumento.documentocompra.numeroDoc)

        entidad = entidadSA.UbicarEntidadPorID(txtidProveedor.Text).First()
        n.SubItems.Add(entidad.tipoDoc)
        n.SubItems.Add(txtRuc.Text)
        n.SubItems.Add(txtProveedor.Text)
        n.SubItems.Add(txtTipoEntidad.Text)

        n.SubItems.Add(FormatNumber(ndocumento.documentocompra.importeTotal, 2))
        n.SubItems.Add(FormatNumber(ndocumento.documentocompra.tcDolLoc, 2))
        n.SubItems.Add(FormatNumber(ndocumento.documentocompra.importeUS, 2))
        n.SubItems.Add(FormatNumber(ndocumento.documentocompra.monedaDoc, 2))
        n.SubItems.Add(TIPO_COMPRA.ORDEN_COMPRA)
        ' n.Group = g

        With frmMantenimientoCompras
            '  Dim strNom = .lsvProduccion.Groups(g.Name.First)
            n.Group = .lsvProduccion.Groups(txtProveedor.Text)
            .lsvProduccion.Items.Add(n)
        End With
        Dispose()
    End Sub

    Sub UpdateCompra()
        Dim CompraSA As New DocumentoCompraSA
        Dim ndocumento As New documento()
        Dim nDocumentoCompra As New documentocompra()
        Dim objDocumentoCompraDet As New documentocompradetalle

        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        Dim ListaDetalle As New List(Of documentocompradetalle)
        With ndocumento
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idDocumento = lblIdDocumento.Text
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .idProyecto = GProyectos.IdProyectoActividad
            .tipoDoc = "00"
            .fechaProceso = txtFechaComprobante.Value
            .nroDoc = txtSerieComp.Text.Trim & "-" & txtNumeroComp.Text.Trim
            .idOrden = Nothing ' Me.IdOrden
            .tipoOperacion = "02"
            .usuarioActualizacion = "NN"
            .fechaActualizacion = DateTime.Now
        End With

        With nDocumentoCompra
            .idDocumento = ndocumento.idDocumento
            .codigoLibro = "1"
            .tipoDoc = "00"
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = txtFechaComprobante.Value ' PERIODO
            .fechaContable = lblPeriodo.Text
            .serie = txtSerieComp.Text.Trim
            .numeroDoc = txtNumeroComp.Text
            .idProveedor = txtidProveedor.Text
            .nombreProveedor = txtProveedor.Text
            .monedaDoc = IIf(rbNac.Checked = True, "1", "2")
            .tasaIgv = nudIgv.Value ' IIf(IsNothing(nudIgv.Value) Or String.IsNullOrEmpty(nudIgv.Value) Or String.IsNullOrWhiteSpace(nudIgv.Value), Nothing, Trim(nudIgv.Value))
            .tcDolLoc = IIf(nudTipoCambio.Value = 0 Or nudTipoCambio.Value = "0.00", 0, CDec(nudTipoCambio.Value))
            .tipoRecaudo = Nothing
            .regimen = Nothing
            .tasaRegimen = 0
            .nroRegimen = Nothing
            '****************** DESTINO EN SOLES ************************************************************************
            .bi01 = IIf(nudBase1.Value = 0 Or nudBase1.Value = "0.00", CDec(0.0), CDec(nudBase1.Value))
            .bi02 = IIf(nudBase2.Value = 0 Or nudBase2.Value = "0.00", CDec(0.0), CDec(nudBase2.Value))
            .bi03 = IIf(nudBase3.Value = 0 Or nudBase3.Value = "0.00", CDec(0.0), CDec(nudBase3.Value))
            .bi04 = IIf(nudBase4.Value = 0 Or nudBase4.Value = "0.00", CDec(0.0), CDec(nudBase4.Value))
            .isc01 = IIf(nudIsc1.Value = 0 Or nudIsc1.Value = "0.00", CDec(0.0), CDec(nudIsc1.Value))
            .isc02 = IIf(nudIsc2.Value = 0 Or nudIsc2.Value = "0.00", CDec(0.0), CDec(nudIsc2.Value))
            .isc03 = IIf(nudIsc3.Value = 0 Or nudIsc3.Value = "0.00", CDec(0.0), CDec(nudIsc3.Value))
            .igv01 = IIf(nudMontoIgv1.Value = 0 Or nudMontoIgv1.Value = "0.00", CDec(0.0), CDec(nudMontoIgv1.Value))
            .igv02 = IIf(nudMontoIgv2.Value = 0 Or nudMontoIgv2.Value = "0.00", CDec(0.0), CDec(nudMontoIgv2.Value))
            .igv03 = IIf(nudMontoIgv3.Value = 0 Or nudMontoIgv3.Value = "0.00", CDec(0.0), CDec(nudMontoIgv3.Value))
            .otc01 = IIf(nudOtrosTributos1.Value = 0 Or nudOtrosTributos1.Value = "0.00", CDec(0.0), CDec(nudOtrosTributos1.Value))
            .otc02 = IIf(nudOtrosTributos2.Value = 0 Or nudOtrosTributos2.Value = "0.00", CDec(0.0), CDec(nudOtrosTributos2.Value))
            .otc03 = IIf(nudOtrosTributos3.Value = 0 Or nudOtrosTributos3.Value = "0.00", CDec(0.0), CDec(nudOtrosTributos3.Value))
            .otc04 = IIf(nudOtrosTributos4.Value = 0 Or nudOtrosTributos4.Value = "0.00", CDec(0.0), CDec(nudOtrosTributos4.Value))
            '****************************************************************************************************************

            '****************** DESTINO EN DOLARES ************************************************************************
            .bi01us = IIf(nudBaseus1.Value = 0 Or nudBaseus1.Value = "0.00", CDec(0.0), CDec(nudBaseus1.Value))
            .bi02us = IIf(nudBaseus2.Value = 0 Or nudBaseus2.Value = "0.00", CDec(0.0), CDec(nudBaseus2.Value))
            .bi03us = IIf(nudBaseus3.Value = 0 Or nudBaseus3.Value = "0.00", CDec(0.0), CDec(nudBaseus3.Value))
            .bi04us = IIf(nudBaseus4.Value = 0 Or nudBaseus4.Value = "0.00", CDec(0.0), CDec(nudBaseus4.Value))
            .isc01us = IIf(nudIscus1.Value = 0 Or nudIscus1.Value = "0.00", CDec(0.0), CDec(nudIscus1.Value))
            .isc02us = IIf(nudIscus2.Value = 0 Or nudIscus2.Value = "0.00", CDec(0.0), CDec(nudIscus2.Value))
            .isc03us = IIf(nudIscus3.Value = 0 Or nudIscus3.Value = "0.00", CDec(0.0), CDec(nudIscus3.Value))
            .igv01us = IIf(nudMontoIgvus1.Value = 0 Or nudMontoIgvus1.Value = "0.00", CDec(0.0), CDec(nudMontoIgvus1.Value))
            .igv02us = IIf(nudMontoIgvus2.Value = 0 Or nudMontoIgvus2.Value = "0.00", CDec(0.0), CDec(nudMontoIgvus2.Value))
            .igv03us = IIf(nudMontoIgvus3.Value = 0 Or nudMontoIgvus3.Value = "0.00", CDec(0.0), CDec(nudMontoIgvus3.Value))
            .otc01us = IIf(nudOtrosTributosus1.Value = 0 Or nudOtrosTributosus1.Value = "0.00", CDec(0.0), CDec(nudOtrosTributosus1.Value))
            .otc02us = IIf(nudOtrosTributosus2.Value = 0 Or nudOtrosTributosus2.Value = "0.00", CDec(0.0), CDec(nudOtrosTributosus2.Value))
            .otc03us = IIf(nudOtrosTributosus3.Value = 0 Or nudOtrosTributosus3.Value = "0.00", CDec(0.0), CDec(nudOtrosTributosus3.Value))
            .otc04us = IIf(nudOtrosTributosus4.Value = 0 Or nudOtrosTributosus4.Value = "0.00", CDec(0.0), CDec(nudOtrosTributosus4.Value))
            '****************************************************************************************************************
            .importeTotal = IIf(lblTotalAdquisiones.Text = 0 Or lblTotalAdquisiones.Text = "0.00", CDec(0.0), CDec(lblTotalAdquisiones.Text))
            .importeUS = IIf(lblTotalUS.Text = 0 Or lblTotalUS.Text = "0.00", CDec(0.0), CDec(lblTotalUS.Text))

            .destino = TIPO_COMPRA.ORDEN_COMPRA
            .estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
            .glosa = IIf(IsNothing(txtGlosa.Text) Or String.IsNullOrEmpty(txtGlosa.Text) Or String.IsNullOrWhiteSpace(txtGlosa.Text), Nothing, Trim(txtGlosa.Text.Trim))
            .referenciaDestino = Nothing ' IIf(IsNothing(txtDestinoref.Text) Or String.IsNullOrEmpty(txtDestinoref.Text) Or String.IsNullOrWhiteSpace(txtDestinoref.Text), Nothing, Trim(txtDestinoref.Text.Trim))
            .tipoCompra = TIPO_COMPRA.ORDEN_COMPRA
            ' .DocumentoSustentado = "S"
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With
        ndocumento.documentocompra = nDocumentoCompra

        Dim S As Integer = 0
        For Each i As DataGridViewRow In dgvNuevoDoc.Rows
            objDocumentoCompraDet = New documentocompradetalle
            objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoCompraDet.IdEstablecimiento = GEstableciento.IdEstablecimiento
            objDocumentoCompraDet.FechaDoc = txtFechaComprobante.Value
            objDocumentoCompraDet.idDocumento = lblIdDocumento.Text
            objDocumentoCompraDet.secuencia = dgvNuevoDoc.Rows(S).Cells(0).Value()
            '  If dgvNuevoDoc.Rows(S).Cells(20).Value() = ENTITY_ACTIONS.UPDATE Then
            If dgvNuevoDoc.Rows(S).Cells(1).Value() = "1" Then '   ADQ. GRAVADAS DESTINADAS A OPE.GRAVADAS Y/O EXPORTACIONES" Then
                objDocumentoCompraDet.destino = "1"
            ElseIf dgvNuevoDoc.Rows(S).Cells(1).Value() = "2" Then '   ADQ. GRAV DEST CONJUNTAMENTE A OPER GRAV Y NO GRAV" Then
                objDocumentoCompraDet.destino = "2"
            ElseIf dgvNuevoDoc.Rows(S).Cells(1).Value() = "3" Then '   ADQ. GRAVADAS DESTINADAS A OPER.NO GRAVADAS" Then
                objDocumentoCompraDet.destino = "3"
            ElseIf dgvNuevoDoc.Rows(S).Cells(1).Value() = "4" Then '   ADQUISICIONES NO GRAVADAS" Then
                objDocumentoCompraDet.destino = "4"
            End If
            objDocumentoCompraDet.CuentaItem = dgvNuevoDoc.Rows(S).Cells(22).Value()
            objDocumentoCompraDet.idItem = dgvNuevoDoc.Rows(S).Cells(2).Value()
            objDocumentoCompraDet.tipoExistencia = dgvNuevoDoc.Rows(S).Cells(21).Value()
            objDocumentoCompraDet.descripcionItem = dgvNuevoDoc.Rows(S).Cells(3).Value()
            objDocumentoCompraDet.unidad1 = dgvNuevoDoc.Rows(S).Cells(6).Value().ToString.Trim
            objDocumentoCompraDet.monto1 = CDec(dgvNuevoDoc.Rows(S).Cells(7).Value())
            objDocumentoCompraDet.unidad2 = dgvNuevoDoc.Rows(S).Cells(4).Value().ToString.Trim 'IDPRESENTACION
            objDocumentoCompraDet.monto2 = dgvNuevoDoc.Rows(S).Cells(5).Value() ' PRESENTACION
            objDocumentoCompraDet.precioUnitario = CDec(dgvNuevoDoc.Rows(S).Cells(8).Value())
            objDocumentoCompraDet.precioUnitarioUS = CDec(dgvNuevoDoc.Rows(S).Cells(9).Value())
            objDocumentoCompraDet.importe = CDec(dgvNuevoDoc.Rows(S).Cells(10).Value())
            objDocumentoCompraDet.importeUS = CDec(dgvNuevoDoc.Rows(S).Cells(11).Value())
            objDocumentoCompraDet.montokardex = CDec(dgvNuevoDoc.Rows(S).Cells(12).Value())
            objDocumentoCompraDet.montoIsc = CDec(dgvNuevoDoc.Rows(S).Cells(13).Value())
            objDocumentoCompraDet.montoIgv = CDec(dgvNuevoDoc.Rows(S).Cells(14).Value())
            objDocumentoCompraDet.otrosTributos = CDec(dgvNuevoDoc.Rows(S).Cells(15).Value())
            '**********************************************************************************
            objDocumentoCompraDet.montokardexUS = CDec(dgvNuevoDoc.Rows(S).Cells(16).Value())
            objDocumentoCompraDet.montoIscUS = CDec(dgvNuevoDoc.Rows(S).Cells(17).Value())
            objDocumentoCompraDet.montoIgvUS = CDec(dgvNuevoDoc.Rows(S).Cells(18).Value())
            objDocumentoCompraDet.otrosTributosUS = CDec(dgvNuevoDoc.Rows(S).Cells(19).Value())
            objDocumentoCompraDet.preEvento = dgvNuevoDoc.Rows(S).Cells(23).Value() '= "00", Nothing, dgvNuevoDoc.Rows(S).Cells(23).Value())
            objDocumentoCompraDet.bonificacion = dgvNuevoDoc.Rows(S).Cells(29).Value()
            '**********************************************************************************
            objDocumentoCompraDet.usuarioModificacion = "Jiuni"
            objDocumentoCompraDet.fechaModificacion = DateTime.Now
            objDocumentoCompraDet.FechaVcto = Nothing ' IIf(IsNothing(dgvNuevoDoc.Rows(S).Cells(28).Value()), Nothing, CDate(dgvNuevoDoc.Rows(S).Cells(28).Value()))
            objDocumentoCompraDet.Action = dgvNuevoDoc.Rows(S).Cells(20).Value()
            ' objDocumentoCompraDet.BonificacionMN =
            ListaDetalle.Add(objDocumentoCompraDet)
            'End If
        Next
        ndocumento.documentocompra.documentocompradetalle = ListaDetalle
        CompraSA.UpdateDocumentoCompra(ndocumento, Nothing, Nothing)
        lblEstado.Text = "orden de compra modificada!"
        lblEstado.Image = My.Resources.ok4

        entidad = entidadSA.UbicarEntidadPorID(txtidProveedor.Text).First

        With frmMantenimientoCompras
            .lsvProduccion.SelectedItems(0).SubItems(1).Text = "02"
            .lsvProduccion.SelectedItems(0).SubItems(2).Text = ndocumento.documentocompra.fechaDoc
            .lsvProduccion.SelectedItems(0).SubItems(3).Text = ndocumento.documentocompra.tipoDoc
            .lsvProduccion.SelectedItems(0).SubItems(4).Text = ndocumento.documentocompra.serie
            .lsvProduccion.SelectedItems(0).SubItems(5).Text = ndocumento.documentocompra.numeroDoc
            .lsvProduccion.SelectedItems(0).SubItems(6).Text = entidad.tipoDoc
            .lsvProduccion.SelectedItems(0).SubItems(7).Text = txtRuc.Text
            .lsvProduccion.SelectedItems(0).SubItems(8).Text = txtProveedor.Text
            .lsvProduccion.SelectedItems(0).SubItems(9).Text = txtTipoEntidad.Text
            .lsvProduccion.SelectedItems(0).SubItems(10).Text = FormatNumber(ndocumento.documentocompra.importeTotal, 2)
            .lsvProduccion.SelectedItems(0).SubItems(11).Text = FormatNumber(ndocumento.documentocompra.tcDolLoc, 2)
            .lsvProduccion.SelectedItems(0).SubItems(12).Text = FormatNumber(ndocumento.documentocompra.importeUS, 2)
            .lsvProduccion.SelectedItems(0).SubItems(13).Text = ndocumento.documentocompra.monedaDoc
            .lsvProduccion.SelectedItems(0).SubItems(14).Text = TIPO_COMPRA.ORDEN_COMPRA
        End With

        Dispose()
    End Sub
#End Region

    Private Sub LinkTipoDoc_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkTipoDoc.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
        datos.Clear()
        'With frmModalComprobantesTabla
        '    .lblTipo.Text = "10"
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        '    If datos.Count > 0 Then
        '        txtIdComprobante.Text = datos(0).ID
        '        txtComprobante.Text = datos(0).NombreCampo
        '        glosa()
        '        txtSerieComp.Focus()
        '        txtSerieComp.Select(0, txtSerieComp.Text.Length)
        '        If dgvNuevoDoc.Rows.Count > 0 Then
        '            CellEndEditRefresh()
        '        End If
        '    Else
        '        txtIdComprobante.Text = String.Empty
        '        txtComprobante.Text = String.Empty
        '        MsgBox("Debe ingresar un comprobante.", MsgBoxStyle.Information, "Atención!")
        '    End If
        'End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtSerieComp_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtSerieComp.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtNumeroComp.Focus()
            txtNumeroComp.Select(0, txtSerieComp.Text.Length)
        End If
    End Sub

    Private Sub txtSerieComp_LostFocus(sender As Object, e As System.EventArgs) Handles txtSerieComp.LostFocus
        Try
            Select Case txtIdComprobante.Text
                Case "01", "02", "03", "04", "07", "08", "23", "34", "35", "37", "55", "99", "00"
                    If Not txtSerieComp.Text = "" Or Not String.IsNullOrEmpty(txtSerieComp.Text) Then
                        If IsNumeric(txtSerieComp.Text) Then
                            txtSerieComp.Text = String.Format("{0:00000}", Convert.ToInt32(txtSerieComp.Text))
                        Else
                            MessageBox.Show("Serie inválida", "Ingresa otra vez", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            txtSerieComp.Clear()
                            txtSerieComp.Focus()
                            txtSerieComp.SelectAll()
                        End If
                    End If
                Case "05", "06", "11", "13", "15", "16", "17", "18", "21", "22", "24", "25", "26", "27", "28",
                    "29", "30", "32"

                    If Not txtSerieComp.Text = "" Or Not String.IsNullOrEmpty(txtSerieComp.Text) Then
                        If IsNumeric(txtSerieComp.Text) Then
                            '        txtSerie.Text = String.Format("{0:00000}", Convert.ToInt32(txtSerie.Text))
                        Else
                            MessageBox.Show("Serie inválida", "Ingresa otra vez", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            txtSerieComp.Clear()
                            txtSerieComp.Focus()
                            txtSerieComp.SelectAll()
                        End If
                    End If
                    ' SOLO NUMEROS
                Case "10"

                Case "12", "14", "36", "87", "88" ' maquina registradora
                    ' SOLO NUMEROS Y FALANUMERICOS

            End Select
            glosa()
        Catch ex As Exception
            MsgBox("Formato Incorrecto " + vbCrLf + ex.Message)
        End Try
    End Sub

    Private Sub txtSerieComp_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSerieComp.TextChanged

    End Sub

    Private Sub txtComprobante_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtComprobante.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtSerieComp.Focus()
            txtSerieComp.Select(0, txtSerieComp.Text.Length)
        End If
    End Sub

    Private Sub txtComprobante_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtComprobante.TextChanged

    End Sub

    Private Sub txtComprobante_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtComprobante.Validating
        If Me.txtComprobante.Text.Trim.Length = 0 Then
            'Me.lblEstado.Image = Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\warning2.png")
            Me.lblEstado.Image = My.Resources.warning2
            Me.lblEstado.Text = "Indique el comprobante de compra!"
            ErrorProvider1.SetError(Me.txtComprobante, "Indique el comprobante de compra!")
            txtComprobante.Select(0, txtComprobante.Text.Length)
            e.Cancel = True
        Else
            ErrorProvider1.SetError(Me.txtComprobante, "")
            '  Me.lblEstado.Image = Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\ok.ico")
            Me.lblEstado.Image = My.Resources.ok4
            Me.lblEstado.Text = "Done!: Comprobante de compra." ' String.Empty
        End If
    End Sub

    Private Sub txtSerieComp_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtSerieComp.Validating
        If Me.txtSerieComp.Text.Trim.Length = 0 Then
            'Me.lblEstado.Image = Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\warning2.png")
            Me.lblEstado.Image = My.Resources.warning2
            Me.lblEstado.Text = "Indique el número de serie!"
            ErrorProvider1.SetError(Me.txtSerieComp, "Indique el número de serie!")
            txtSerieComp.Select(0, txtSerieComp.Text.Length)
            e.Cancel = True
        Else
            ErrorProvider1.SetError(Me.txtSerieComp, "")
            '  Me.lblEstado.Image = Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\ok.ico")
            Me.lblEstado.Image = My.Resources.ok4
            Me.lblEstado.Text = "Done!: Nro. serie." ' String.Empty
        End If
    End Sub

    Private Sub txtNumeroComp_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtNumeroComp.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtNumeroComp_LostFocus(sender, e)
            tvDatos.SelectedNode = newNodeProveedor
            txtProveedor.Focus()
            txtProveedor.Select()
            If txtProveedor.Text.Trim.Length > 0 Then

            Else
                ProveedoresShows()
            End If
        End If
    End Sub

    Private Sub txtNumeroComp_LostFocus(sender As Object, e As System.EventArgs) Handles txtNumeroComp.LostFocus
        Try
            Select Case txtIdComprobante.Text
                Case "01", "02", "03", "04", "07", "08", "23", "34", "35", "37", "55", "99", "00"
                    If Not txtNumeroComp.Text = "" Or Not String.IsNullOrEmpty(txtNumeroComp.Text) Then
                        If IsNumeric(txtNumeroComp.Text) Then
                            If txtNumeroComp.Text.Length = 20 Then

                            Else
                                txtNumeroComp.Text = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumeroComp.Text))
                            End If
                        Else
                            MessageBox.Show("Número inválido", "Ingresa otra vez", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            txtNumeroComp.Clear()
                            txtNumeroComp.Focus()
                            txtNumeroComp.SelectAll()
                        End If
                    End If
                Case "05", "06", "11", "13", "15", "16", "17", "18", "21", "22", "24", "25", "26", "27", "28",
                    "29", "30", "32"

                    If Not txtNumeroComp.Text = "" Or Not String.IsNullOrEmpty(txtNumeroComp.Text) Then
                        If IsNumeric(txtNumeroComp.Text) Then
                            If txtNumeroComp.Text.Length = 20 Then

                            Else
                                '     txtNumeroDoc.Text = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumeroDoc.Text))
                            End If
                        Else
                            MessageBox.Show("Número inválido", "Ingresa otra vez", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            txtNumeroComp.Clear()
                            txtNumeroComp.Focus()
                            txtNumeroComp.SelectAll()
                        End If
                    End If
                    ' SOLO NUMEROS
                Case "10"
                    If Not txtNumeroComp.Text = "" Or Not String.IsNullOrEmpty(txtNumeroComp.Text) Then
                        If IsNumeric(txtNumeroComp.Text) Then
                            If txtNumeroComp.Text.Length = 20 Then

                            Else
                                '     txtNumeroDoc.Text = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumeroDoc.Text))
                            End If
                        Else
                            MessageBox.Show("Número inválido", "Ingresa otra vez", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            txtNumeroComp.Clear()
                            txtNumeroComp.Focus()
                            txtNumeroComp.SelectAll()
                        End If
                    End If
                Case "12", "14", "36", "87", "88" ' maquina registradora
                    ' SOLO NUMEROS Y FALANUMERICOS

            End Select
            glosa()
        Catch ex As Exception
            MsgBox("Formato Incorrecto..!" + vbCrLf + ex.Message)
            txtNumeroComp.Clear()
        End Try
    End Sub

    Private Sub txtNumeroComp_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNumeroComp.TextChanged

    End Sub

    Private Sub txtNumeroComp_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtNumeroComp.Validating
        If Me.txtNumeroComp.Text.Trim.Length = 0 Then
            '    Me.lblEstado.Image = Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\warning2.png")
            Me.lblEstado.Image = My.Resources.warning2
            Me.lblEstado.Text = "Indique el número del comprobante!"
            ErrorProvider1.SetError(Me.txtNumeroComp, "Indique el número del comprobante!")
            txtNumeroComp.Select(0, txtNumeroComp.Text.Length)
            e.Cancel = True
        Else
            ErrorProvider1.SetError(Me.txtNumeroComp, "")
            '   Me.lblEstado.Image = Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\ok.ico")
            Me.lblEstado.Image = My.Resources.ok4
            Me.lblEstado.Text = "Done!: Nro. comprobante." ' String.Empty
        End If
    End Sub

    Sub ProveedoresShows()
        Me.Cursor = Cursors.WaitCursor
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        datos.Clear()
        'With frmModalEntidades
        '    .lblTipo.Text = "PR"
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        '    If datos.Count > 0 Then
        '        txtRuc.Text = datos(0).NroDoc
        '        txtCuenta.Text = datos(0).Cuenta
        '        txtidProveedor.Text = datos(0).ID
        '        txtProveedor.Text = datos(0).NombreEntidad

        '        txtProveedor.Focus()
        '    Else
        '        txtRuc.Text = String.Empty
        '        txtCuenta.Text = String.Empty
        '        txtidProveedor.Text = String.Empty
        '        txtProveedor.Text = String.Empty

        '        txtProveedor.Focus()
        '    End If
        'End With

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub LinkProveedor_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkProveedor.LinkClicked
        ProveedoresShows()
    End Sub

    Private Sub txtProveedor_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtProveedor.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            tvDatos.SelectedNode = newNodeDetalle
            '            TabPage2.Parent = TabCompra
            nudTipoCambio.Focus()
            nudTipoCambio.Select()
        End If
    End Sub

    Private Sub txtProveedor_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtProveedor.TextChanged

    End Sub

    Private Sub txtProveedor_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtProveedor.Validating
        If Me.txtProveedor.Text.Trim.Length = 0 Then
            '    Me.lblEstado.Image = Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\warning2.png")
            Me.lblEstado.Image = My.Resources.warning2
            Me.lblEstado.Text = "Indique el proveedor.!"
            ErrorProvider1.SetError(Me.txtProveedor, "Indique el proveedor.!")
            txtProveedor.Select(0, txtProveedor.Text.Length)
            e.Cancel = True
        Else
            ErrorProvider1.SetError(Me.txtProveedor, "")
            Me.lblEstado.Image = My.Resources.ok4
            'Me.lblEstado.Image = Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\ok.ico")
            Me.lblEstado.Text = "Done!: Proveedor." ' String.Empty
        End If
    End Sub

    Private Sub frmComprasExistencias_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmComprasExistencias_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        LoadTree()
        TabPage1.Parent = Nothing
        TabPage2.Parent = Nothing
        '  TabPage3.Parent = Nothing
        ' TabPage4.Parent = Nothing
        TabPage5.Parent = Nothing
        TabPage6.Parent = Nothing
        TabPage9.Parent = Nothing
        '        TabPage10.Parent = Nothing

        tvDatos.SelectedNode = newNodeComprobante
        txtFechaComprobante.Select()

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub tvDatos_AfterSelect(sender As System.Object, e As System.Windows.Forms.TreeViewEventArgs) Handles tvDatos.AfterSelect
        Me.Cursor = Cursors.WaitCursor
        Select Case tvDatos.SelectedNode.Tag
            Case "IF"
                TabPage1.Parent = TabCompra
                TabPage2.Parent = Nothing
                '      TabPage3.Parent = Nothing
                ' TabPage4.Parent = Nothing
                TabPage5.Parent = Nothing
                TabCompra.Focus()
                txtFechaComprobante.Select()
                txtFechaComprobante.Focus()
            Case "DP"
                TabPage2.Parent = TabCompra

                TabPage1.Parent = Nothing
                '    TabPage3.Parent = Nothing
                '  TabPage4.Parent = Nothing
                TabPage5.Parent = Nothing

                txtProveedor.Select()
                txtProveedor.Focus()
            Case "DC"
                '       TabPage3.Parent = TabCompra

                TabPage1.Parent = Nothing
                TabPage2.Parent = Nothing
                '  TabPage4.Parent = Nothing
                TabPage5.Parent = Nothing

                'cboEstableCosto.Focus()
                'cboEstableCosto.Select()
            Case "IP"
                '  TabPage4.Parent = TabCompra

                TabPage1.Parent = Nothing
                TabPage2.Parent = Nothing
                '    TabPage3.Parent = Nothing
                TabPage5.Parent = Nothing

                '   txtFechaPago.Select()
                '  txtFechaPago.Focus()
            Case "DT"
                TabPage5.Parent = TabCompra
                TabPage1.Parent = Nothing
                TabPage2.Parent = Nothing
                '    TabPage3.Parent = Nothing
                ' TabPage4.Parent = Nothing

                nudTipoCambio.Select()
                nudTipoCambio.Focus()
                nudTipoCambio.Select(0, nudTipoCambio.Text.Length)
        End Select
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvNuevoDoc_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvNuevoDoc.CellContentClick
        'If dgvNuevoDoc.Columns(e.ColumnIndex).Name = "Evento" Then
        '    With frmModalPreEvento
        '        .Tag = "CIS2"
        '        .StartPosition = FormStartPosition.CenterParent
        '        .ShowDialog()
        '    End With

        'End If
    End Sub

    Private Sub dgvNuevoDoc_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvNuevoDoc.CellEndEdit
        If dgvNuevoDoc.Rows.Count > 0 Then
            'DECLARANDO VARIABLES
            Dim colDestinoGravado As Decimal = 0
            colDestinoGravado = dgvNuevoDoc.Item(1, dgvNuevoDoc.CurrentRow.Index).Value

            Dim colCantidad As Decimal = dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value


            Dim colBI As Decimal = 0
            Dim colBI_ME As Decimal = 0
            Dim colIGV_ME As Decimal = 0
            Dim colIGV As Decimal = 0
            Dim colMN As Decimal = dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value
            Dim colME As Decimal = Math.Round(CDec(dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value) / CDec(nudTipoCambio.Value), 2)
            Dim colPrecUnit As Decimal = 0
            Dim colPrecUnitUSD As Decimal = 0


            If colCantidad > 0 AndAlso colMN > 0 Then

                colPrecUnit = Math.Round(colMN / colCantidad, 2)

                colPrecUnitUSD = Math.Round(colME / colCantidad, 2)

                colBI = Math.Round(colMN / 1.18, 2)
                colBI_ME = Math.Round(colME / 1.18, 2)
                colIGV = Math.Round((colMN / 1.18) * 0.18, 2) ' Math.Round(colBI * 0.18, 2)
                colIGV_ME = Math.Round((colME / 1.18) * 0.18, 2) ' Math.Round(colBI_ME * 0.18, 2)


            Else
                colPrecUnit = 0

                colPrecUnitUSD = 0

                colBI = 0
                colBI_ME = 0
                colIGV = 0
                colIGV_ME = 0
            End If
            Select Case txtIdComprobante.Text
                Case "08"
                    If dgvNuevoDoc.Columns(e.ColumnIndex).Name = "ImporteNeto" Or dgvNuevoDoc.Columns(e.ColumnIndex).Name = "ImporteUS" Then 'Or dgvNuevoDoc.Columns(e.ColumnIndex).Name = "otrostributos" Or dgvNuevoDoc.Columns(e.ColumnIndex).Name = "OTCus" Then
                        totales_xx()
                    End If
                Case "03", "02"
                    If dgvNuevoDoc.Columns(e.ColumnIndex).Name = "ImporteNeto" Or dgvNuevoDoc.Columns(e.ColumnIndex).Name = "Can1" Or dgvNuevoDoc.Columns(e.ColumnIndex).Name = "ImporteUS" Then 'Or dgvNuevoDoc.Columns(e.ColumnIndex).Name = "otrostributos" Or dgvNuevoDoc.Columns(e.ColumnIndex).Name = "OTCus" Then
                        If nudTipoCambio.Value = 0.0 Then
                            MsgBox("Ingrese Tipo de Cambio..!")
                            nudTipoCambio.Focus()
                            nudTipoCambio.Select(0, nudTipoCambio.Text.Length)
                            Exit Sub
                        End If
                        '   Dim cantidad As Decimal = Convert.ToDecimal(dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value())
                        '  Dim neto As Decimal = Convert.ToDecimal(dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value())
                        '  Dim netous As Decimal = Convert.ToDecimal(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value())
                        Dim NUDIGV_VALUE As Decimal = Math.Round((nudIgv.Value / 100) + 1, 2)
                        If colCantidad = 0 And colMN = 0 And colME = 0 Then
                            dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                            dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                            Exit Sub
                            'ElseIf neto > 0 And cantidad = 0 Then
                            '    dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                            '    dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                            '    Exit Sub
                        ElseIf colCantidad = 0 Then

                            If rbNac.Checked = True Then
                                ' DATOS SOLES
                                Select Case colDestinoGravado
                                    Case "4"
                                        dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"  'Math.Round(CDec(neto / cantidad), 4) ' PRECIO UNITARIO SOLES
                                        dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() = colME.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2")  ' MONTO TOTAL DOLARES
                                        dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = colMN.ToString("N2")
                                        dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' Math.Round(CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() / cantidad), 4)

                                        dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                        dgvNuevoDoc.Item(13, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                        dgvNuevoDoc.Item(14, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                        dgvNuevoDoc.Item(15, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                        dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                        dgvNuevoDoc.Item(17, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                        dgvNuevoDoc.Item(18, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                        dgvNuevoDoc.Item(19, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                    Case Else
                                        dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"  'Math.Round(CDec(neto / cantidad), 4) ' PRECIO UNITARIO SOLES
                                        dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() = colME.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                        dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = colMN.ToString("N2")
                                        dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' Math.Round(CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() / cantidad), 4)
                                        dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                        dgvNuevoDoc.Item(13, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                        dgvNuevoDoc.Item(14, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                        dgvNuevoDoc.Item(15, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                        dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                        dgvNuevoDoc.Item(17, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                        dgvNuevoDoc.Item(18, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                        dgvNuevoDoc.Item(19, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                End Select

                            ElseIf rbExt.Checked = True Then
                                ' DATOS DOLARES
                                Select Case colDestinoGravado
                                    Case "4"
                                        dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" 'Math.Round(CDec(netous / cantidad), 4) ' PRECIO UNITARIO DOLARES
                                        ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                        dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" 'Math.Round(CDec(dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() / cantidad), 2)
                                        dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = colMN.ToString("N2")
                                        dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() = colME.ToString("N2")
                                        dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                        dgvNuevoDoc.Item(13, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                        dgvNuevoDoc.Item(14, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                        dgvNuevoDoc.Item(15, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                        dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                        dgvNuevoDoc.Item(17, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                        dgvNuevoDoc.Item(18, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                        dgvNuevoDoc.Item(19, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                    Case Else
                                        dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" 'Math.Round(CDec(netous / cantidad), 4) ' PRECIO UNITARIO DOLARES
                                        dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = colMN.ToString("N2") ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                        dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() = colME.ToString("N2") ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                        dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" 'Math.Round(CDec(dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() / cantidad), 2)
                                        dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                        dgvNuevoDoc.Item(13, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                        dgvNuevoDoc.Item(14, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                        dgvNuevoDoc.Item(15, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                        dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                        dgvNuevoDoc.Item(17, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                        dgvNuevoDoc.Item(18, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                        dgvNuevoDoc.Item(19, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                End Select

                            End If
                        ElseIf colCantidad > 0 Then
                            If rbNac.Checked = True = "1" Then
                                ' DATOS SOLES
                                If dgvNuevoDoc.Item(1, dgvNuevoDoc.CurrentRow.Index).Value = "4" Then
                                    dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value() = colCantidad.ToString("N2")
                                    dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnit.ToString("N2") ' Math.Round(CDec(neto / colCantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES
                                    dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnitUSD.ToString("N2") ' Math.Round(CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() / colCantidad), NumDigitos).ToString("N2")
                                    dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() = colME.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                    dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = colMN.ToString("N2") 'CDec(dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value()).ToString("N2")

                                    dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                    dgvNuevoDoc.Item(13, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                    dgvNuevoDoc.Item(14, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                    dgvNuevoDoc.Item(15, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                    dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                    dgvNuevoDoc.Item(17, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                    dgvNuevoDoc.Item(18, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                    dgvNuevoDoc.Item(19, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                Else
                                    dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value() = colCantidad.ToString("N2") 'CDec(dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                    dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnit.ToString("N2") ' Math.Round(CDec(neto / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES
                                    dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnitUSD.ToString("N2") ' Math.Round(CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                    dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() = colME.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                    dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = colMN.ToString("N2") ' CDec(dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value()).ToString("N2")


                                    dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                    dgvNuevoDoc.Item(13, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                    dgvNuevoDoc.Item(14, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                    dgvNuevoDoc.Item(15, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                    dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                    dgvNuevoDoc.Item(17, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                    dgvNuevoDoc.Item(18, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                    dgvNuevoDoc.Item(19, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                End If

                            ElseIf rbExt.Checked = True Then

                                Select Case colDestinoGravado
                                    Case "4"
                                        ' DATOS DOLARES

                                        dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value() = colCantidad.ToString("N2") ' CDec(dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                        dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnit.ToString("N2") ' Math.Round(CDec(dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                        dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnitUSD.ToString("N2") ' Math.Round(CDec(netous / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO DOLARES
                                        dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = colMN.ToString("N2") ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                        dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() = colME.ToString("N2") ' CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value()).ToString("N2")


                                        dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                        dgvNuevoDoc.Item(13, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                        dgvNuevoDoc.Item(14, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                        dgvNuevoDoc.Item(15, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                        dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                        dgvNuevoDoc.Item(17, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                        dgvNuevoDoc.Item(18, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                        dgvNuevoDoc.Item(19, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                    Case Else
                                        ' DATOS DOLARES
                                        dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value() = colCantidad.ToString("N2") ' CDec(dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                        dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnit.ToString("N2") ' Math.Round(CDec(dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                        dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnitUSD.ToString("N2") ' Math.Round(CDec(netous / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO DOLARES
                                        dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = colMN.ToString("N2") ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                        dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() = colME.ToString("N2") ' CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value()).ToString("N2")


                                        dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                        dgvNuevoDoc.Item(13, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                        dgvNuevoDoc.Item(14, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                        dgvNuevoDoc.Item(15, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                        dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                        dgvNuevoDoc.Item(17, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                        dgvNuevoDoc.Item(18, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                        dgvNuevoDoc.Item(19, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                End Select

                            End If
                        End If
                        'totales()
                        'subTotales("All")
                        totales_xx()
                        TotalesCabeceras()
                    End If
                    If dgvNuevoDoc.Columns(e.ColumnIndex).Name = "ISC" Then
                        'totalesPorCaja("ISC")
                        'subTotales("All")
                    ElseIf dgvNuevoDoc.Columns(e.ColumnIndex).Name = "ISCus" Then
                        'totalesPorCaja("ISCUS")
                        'subTotales("All")
                    ElseIf dgvNuevoDoc.Columns(e.ColumnIndex).Name = "igv" Then
                        'totalesPorCaja("IGV")
                        'subTotales("All")
                    ElseIf dgvNuevoDoc.Columns(e.ColumnIndex).Name = "IGVus" Then
                        'totalesPorCaja("IGVUS")
                        'subTotales("All")
                    ElseIf dgvNuevoDoc.Columns(e.ColumnIndex).Name = "otrostributos" Then
                        'totalesPorCaja("OTC")
                        'subTotales("All")
                    ElseIf dgvNuevoDoc.Columns(e.ColumnIndex).Name = "OTCus" Then
                        'totalesPorCaja("OTCUS")
                        'subTotales("All")
                    ElseIf dgvNuevoDoc.Columns(e.ColumnIndex).Name = "kardex" Then
                        'totalesPorCaja("KARDEX")
                        'subTotales("All")
                    End If

                    If dgvNuevoDoc.Columns(e.ColumnIndex).Name = "ImporteNeto" Then

                    End If
                    '**********************************************************************************************************************************************************************************
                    '**********************************************************************************************************************************************************************************
                    '**********************************************************************************************************************************************************************************
                Case Else
                    If dgvNuevoDoc.Columns(e.ColumnIndex).Name = "ImporteNeto" Or dgvNuevoDoc.Columns(e.ColumnIndex).Name = "Can1" Or dgvNuevoDoc.Columns(e.ColumnIndex).Name = "ImporteUS" Then 'Or dgvNuevoDoc.Columns(e.ColumnIndex).Name = "otrostributos" Or dgvNuevoDoc.Columns(e.ColumnIndex).Name = "OTCus" Then
                        If nudTipoCambio.Value = 0.0 Then
                            MsgBox("Ingrese Tipo de Cambio..!")
                            nudTipoCambio.Focus()
                            nudTipoCambio.Select(0, nudTipoCambio.Text.Length)
                            Exit Sub
                        End If
                        ' Dim cantidad As Decimal = Convert.ToDecimal(dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value())
                        ' Dim neto As Decimal = Convert.ToDecimal(dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value())
                        ' Dim netous As Decimal = Convert.ToDecimal(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value())
                        Dim NUDIGV_VALUE As Decimal = Math.Round((nudIgv.Value / 100) + 1, 2)
                        If colCantidad = 0 And colMN = 0 And colME = 0 Then
                            dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                            dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                            Exit Sub
                            'ElseIf neto > 0 And cantidad = 0 Then
                            '    dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                            '    dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                            '    Exit Sub
                        ElseIf colCantidad = 0 Then

                            If rbNac.Checked = True Then
                                ' DATOS SOLES
                                Select Case colDestinoGravado
                                    Case "4"
                                        dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"  'Math.Round(CDec(neto / cantidad), 4) ' PRECIO UNITARIO SOLES
                                        dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' Math.Round(CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() / cantidad), 4)
                                        dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() = colME.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos) ' MONTO TOTAL DOLARES
                                        dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = colMN.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos) ' MONTO TOTAL DOLARES

                                    Case Else

                                        If dgvNuevoDoc.Item(27, dgvNuevoDoc.CurrentRow.Index).Value() = "S" Then
                                            dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"  'Math.Round(CDec(neto / cantidad), 4) ' PRECIO UNITARIO SOLES
                                            dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' Math.Round(CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() / cantidad), 4)
                                            dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = colMN.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                            dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() = colME.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                            dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' monto para el kardex
                                            dgvNuevoDoc.Item(14, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' monto igv del item
                                            dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' monto para el kardex USD
                                            dgvNuevoDoc.Item(18, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' monto para el IGV USD
                                            dgvNuevoDoc.Item(19, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' monto OTROS TRIBUTOS DOLARES
                                        Else
                                            dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"  'Math.Round(CDec(neto / cantidad), 4) ' PRECIO UNITARIO SOLES
                                            dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' Math.Round(CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() / cantidad), 4)
                                            dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = colMN.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                            dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() = colME.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                            dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value() = colBI.ToString("N2") ' Math.Round(CDec(neto / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                            dgvNuevoDoc.Item(14, dgvNuevoDoc.CurrentRow.Index).Value() = colIGV.ToString("N2")  ' Math.Round(CDec(neto - CDec(dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto igv del item

                                            dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value() = colBI_ME.ToString("N2") ' Math.Round(CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex USD
                                            dgvNuevoDoc.Item(18, dgvNuevoDoc.CurrentRow.Index).Value() = colIGV_ME.ToString("N2") ' Math.Round(CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() - CDec(dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto para el IGV USD


                                            dgvNuevoDoc.Item(19, dgvNuevoDoc.CurrentRow.Index).Value() = Math.Round(CDec(dgvNuevoDoc.Item(15, dgvNuevoDoc.CurrentRow.Index).Value() / nudTipoCambio.Value), NumDigitos).ToString("N2") ' monto OTROS TRIBUTOS DOLARES
                                        End If
                                End Select

                            ElseIf rbExt.Checked = True Then
                                ' DATOS DOLARES
                                Select Case colDestinoGravado
                                    Case "4"
                                        dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" 'Math.Round(CDec(netous / cantidad), 4) ' PRECIO UNITARIO DOLARES
                                        dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" 'Math.Round(CDec(dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() / cantidad), 2)
                                        dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = colMN.ToString("N2") ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                        dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() = colME.ToString("N2")

                                        ' dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value() = Math.Round(CDec(dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos) ' monto para el kardex
                                        ' dgvNuevoDoc.Item(14, dgvNuevoDoc.CurrentRow.Index).Value() = Math.Round(CDec(dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() - CDec(dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value())), NumDigitos) ' igv del item

                                        '  dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value() = Math.Round(CDec(netous / CDec(NUDIGV_VALUE)), NumDigitos) ' monto para el kardex
                                        '  dgvNuevoDoc.Item(18, dgvNuevoDoc.CurrentRow.Index).Value() = Math.Round(CDec(netous - CDec(dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value())), NumDigitos) ' monto para el IGV

                                        '  dgvNuevoDoc.Item(15, dgvNuevoDoc.CurrentRow.Index).Value() = Math.Round(CDec(dgvNuevoDoc.Item(19, dgvNuevoDoc.CurrentRow.Index).Value() * nudTipoCambio.Value), NumDigitos) ' monto OTROS TRIBUTOS SOLES
                                    Case Else

                                        If dgvNuevoDoc.Item(27, dgvNuevoDoc.CurrentRow.Index).Value() = "S" Then
                                            dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" 'Math.Round(CDec(netous / cantidad), 4) ' PRECIO UNITARIO DOLARES
                                            dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = colMN.ToString("N2") 'Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                            dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() = colME.ToString("N2")

                                            dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' monto para el kardex
                                            dgvNuevoDoc.Item(14, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' igv del item

                                            dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' monto para el kardex
                                            dgvNuevoDoc.Item(18, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' monto para el IGV
                                            dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" 'Math.Round(CDec(dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() / cantidad), 2)
                                            dgvNuevoDoc.Item(15, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' monto OTROS TRIBUTOS SOLES
                                        Else
                                            dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                            dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00"
                                            dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = colMN.ToString("N2")
                                            dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() = colME.ToString("N2")

                                            dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value() = colBI.ToString("N2") ' Math.Round(CDec(dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                            dgvNuevoDoc.Item(14, dgvNuevoDoc.CurrentRow.Index).Value() = colIGV.ToString("N2") ' Math.Round(CDec(dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() - CDec(dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' igv del item

                                            dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value() = colBI_ME.ToString("N2") ' Math.Round(CDec(netous / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                            dgvNuevoDoc.Item(18, dgvNuevoDoc.CurrentRow.Index).Value() = colIGV_ME.ToString("N2") ' Math.Round(CDec(netous - CDec(dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto para el IGV

                                            dgvNuevoDoc.Item(15, dgvNuevoDoc.CurrentRow.Index).Value() = Math.Round(CDec(dgvNuevoDoc.Item(19, dgvNuevoDoc.CurrentRow.Index).Value() * nudTipoCambio.Value), NumDigitos).ToString("N2") ' monto OTROS TRIBUTOS SOLES
                                        End If
                                End Select

                            End If
                        ElseIf colCantidad > 0 Then
                            If rbNac.Checked = True Then
                                ' DATOS SOLES
                                If colDestinoGravado = "4" Then
                                    dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value() = colCantidad.ToString("N2") ' CDec(dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                    dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnit.ToString("N2") ' Math.Round(CDec(neto / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES
                                    dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnitUSD.ToString("N2") ' Math.Round(CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                    dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() = colME.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                    dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = colMN.ToString("N2") ' CDec(dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value()).ToString("N2")
                                    '  dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value() = Math.Round(CDec(neto / CDec(NUDIGV_VALUE)), NumDigitos) ' monto para el kardex
                                    '  dgvNuevoDoc.Item(14, dgvNuevoDoc.CurrentRow.Index).Value() = Math.Round(CDec(neto - CDec(dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value())), NumDigitos) ' monto igv del item

                                    ' dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value() = Math.Round(CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos) ' monto para el kardex USD
                                    ' dgvNuevoDoc.Item(18, dgvNuevoDoc.CurrentRow.Index).Value() = Math.Round(CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() - CDec(dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value())), NumDigitos) ' monto para el IGV USD


                                    'dgvNuevoDoc.Item(19, dgvNuevoDoc.CurrentRow.Index).Value() = Math.Round(CDec(dgvNuevoDoc.Item(15, dgvNuevoDoc.CurrentRow.Index).Value() / nudTipoCambio.Value), NumDigitos) ' monto OTROS TRIBUTOS DOLARES
                                Else
                                    If dgvNuevoDoc.Item(27, dgvNuevoDoc.CurrentRow.Index).Value() = "S" Then
                                        dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value() = colCantidad.ToString("N2") '  CDec(dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                        dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnit.ToString("N2") ' Math.Round(CDec(neto / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES
                                        dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnitUSD.ToString("N2") ' Math.Round(CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                        dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() = colME.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                        dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = colMN.ToString("N2") ' CDec(dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value()).ToString("N2")
                                        dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' monto para el kardex
                                        dgvNuevoDoc.Item(14, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' monto igv del item

                                        dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' monto para el kardex USD
                                        dgvNuevoDoc.Item(18, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' monto para el IGV USD


                                        dgvNuevoDoc.Item(19, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' monto OTROS TRIBUTOS DOLARES
                                    Else
                                        dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value() = colCantidad.ToString("N2") ' CDec(dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                        dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnit.ToString("N2") ' Math.Round(CDec(neto / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES
                                        dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnitUSD.ToString("N2") ' Math.Round(CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                        dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() = colME.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                        dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = colMN.ToString("N2") ' CDec(dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value()).ToString("N2")
                                        dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value() = colBI.ToString("N2") ' Math.Round(CDec(neto / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                        dgvNuevoDoc.Item(14, dgvNuevoDoc.CurrentRow.Index).Value() = colIGV.ToString("N2") ' Math.Round(CDec(neto - CDec(dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto igv del item

                                        dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value() = colBI_ME.ToString("N2") ' Math.Round(CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex USD
                                        dgvNuevoDoc.Item(18, dgvNuevoDoc.CurrentRow.Index).Value() = colIGV_ME.ToString("N2") ' Math.Round(CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() - CDec(dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto para el IGV USD


                                        dgvNuevoDoc.Item(19, dgvNuevoDoc.CurrentRow.Index).Value() = Math.Round(CDec(dgvNuevoDoc.Item(15, dgvNuevoDoc.CurrentRow.Index).Value() / nudTipoCambio.Value), NumDigitos).ToString("N2") ' monto OTROS TRIBUTOS DOLARES

                                    End If

                                End If

                            ElseIf rbExt.Checked = True Then

                                Select Case colDestinoGravado
                                    Case "4"
                                        ' DATOS DOLARES
                                        dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value() = colCantidad.ToString("N2") ' CDec(dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                        dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnit.ToString("N2") ' Math.Round(CDec(dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                        dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnitUSD.ToString("N2") ' Math.Round(CDec(netous / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO DOLARES
                                        dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = colMN.ToString("N2") ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                        dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() = colME.ToString("N2") ' CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value()).ToString("N2")
                                        '  dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value() = Math.Round(CDec(dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos) ' monto para el kardex
                                        '  dgvNuevoDoc.Item(14, dgvNuevoDoc.CurrentRow.Index).Value() = Math.Round(CDec(dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() - CDec(dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value())), NumDigitos) ' igv del item

                                        ' dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value() = Math.Round(CDec(netous / CDec(NUDIGV_VALUE)), NumDigitos) ' monto para el kardex
                                        ' dgvNuevoDoc.Item(18, dgvNuevoDoc.CurrentRow.Index).Value() = Math.Round(CDec(netous - CDec(dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value())), NumDigitos) ' monto para el IGV

                                        ' dgvNuevoDoc.Item(15, dgvNuevoDoc.CurrentRow.Index).Value() = Math.Round(CDec(dgvNuevoDoc.Item(19, dgvNuevoDoc.CurrentRow.Index).Value() * nudTipoCambio.Value), NumDigitos) ' monto OTROS TRIBUTOS SOLES
                                    Case Else
                                        ' DATOS DOLARES
                                        If dgvNuevoDoc.Item(27, dgvNuevoDoc.CurrentRow.Index).Value() = "S" Then
                                            dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value() = colCantidad.ToString("N2") ' CDec(dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                            dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnit.ToString("N2") ' Math.Round(CDec(dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                            dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnitUSD.ToString("N2") ' Math.Round(CDec(netous / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO DOLARES
                                            dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = colMN.ToString("N2") ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                            dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() = colME.ToString("N2") ' CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value()).ToString("N2")
                                            dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' monto para el kardex
                                            dgvNuevoDoc.Item(14, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' igv del item

                                            dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' monto para el kardex
                                            dgvNuevoDoc.Item(18, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' monto para el IGV

                                            dgvNuevoDoc.Item(15, dgvNuevoDoc.CurrentRow.Index).Value() = "0.00" ' monto OTROS TRIBUTOS SOLES
                                        Else
                                            dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value() = colCantidad.ToString("N2") ' CDec(dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                            dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnit.ToString("N2") ' Math.Round(CDec(dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                            dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value() = colPrecUnitUSD.ToString("N2") ' Math.Round(CDec(netous / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO DOLARES
                                            dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() = colMN.ToString("N2") ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                            dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value() = colME.ToString("N2") ' CDec(dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value()).ToString("N2")
                                            dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value() = colBI.ToString("N2") ' Math.Round(CDec(dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                            dgvNuevoDoc.Item(14, dgvNuevoDoc.CurrentRow.Index).Value() = colIGV.ToString("N2") ' Math.Round(CDec(dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value() - CDec(dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' igv del item

                                            dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value() = colBI_ME.ToString("N2") ' Math.Round(CDec(netous / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                            dgvNuevoDoc.Item(18, dgvNuevoDoc.CurrentRow.Index).Value() = colIGV_ME.ToString("N2") ' Math.Round(CDec(netous - CDec(dgvNuevoDoc.Item(16, dgvNuevoDoc.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto para el IGV

                                            dgvNuevoDoc.Item(15, dgvNuevoDoc.CurrentRow.Index).Value() = Math.Round(CDec(dgvNuevoDoc.Item(19, dgvNuevoDoc.CurrentRow.Index).Value() * nudTipoCambio.Value), NumDigitos).ToString("N2") ' monto OTROS TRIBUTOS SOLES
                                        End If

                                End Select

                            End If
                        End If
                        'totales()
                        'subTotales("All")
                        totales_xx()
                        TotalesCabeceras()
                    End If
                    If dgvNuevoDoc.Columns(e.ColumnIndex).Name = "ISC" Then
                        'totalesPorCaja("ISC")
                        'subTotales("All")
                    ElseIf dgvNuevoDoc.Columns(e.ColumnIndex).Name = "ISCus" Then
                        'totalesPorCaja("ISCUS")
                        'subTotales("All")
                    ElseIf dgvNuevoDoc.Columns(e.ColumnIndex).Name = "igv" Then
                        'totalesPorCaja("IGV")
                        'subTotales("All")
                    ElseIf dgvNuevoDoc.Columns(e.ColumnIndex).Name = "IGVus" Then
                        'totalesPorCaja("IGVUS")
                        'subTotales("All")
                    ElseIf dgvNuevoDoc.Columns(e.ColumnIndex).Name = "otrostributos" Then
                        'If txtMoneda.Text = "1" Then
                        '    dgvNuevoDoc.Item(19, dgvNuevoDoc.CurrentRow.Index).Value() = Math.Round(CDec(dgvNuevoDoc.Item(15, dgvNuevoDoc.CurrentRow.Index).Value()) / CDec(nudTipoCambio.Value), 2)
                        '    'totalesPorCaja("OTC")
                        '    'subTotales("All")
                        'End If
                    ElseIf dgvNuevoDoc.Columns(e.ColumnIndex).Name = "OTCus" Then
                        'If txtMoneda.Text = "2" Then
                        '    dgvNuevoDoc.Item(15, dgvNuevoDoc.CurrentRow.Index).Value() = Math.Round(CDec(dgvNuevoDoc.Item(19, dgvNuevoDoc.CurrentRow.Index).Value()) / CDec(nudTipoCambio.Value), 2)
                        '    'totalesPorCaja("OTCUS")
                        '    'subTotales("All")
                        'End If
                    ElseIf dgvNuevoDoc.Columns(e.ColumnIndex).Name = "kardex" Then
                        'totalesPorCaja("KARDEX")
                        'subTotales("All")
                    End If

                    If dgvNuevoDoc.Columns(e.ColumnIndex).Name = "ImporteNeto" Then

                    End If

            End Select
        End If
    End Sub

    Private Sub dgvNuevoDoc_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvNuevoDoc.CellFormatting
        If e.ColumnIndex = Me.dgvNuevoDoc.Columns("Gravado").Index _
   AndAlso (e.Value IsNot Nothing) Then

            With Me.dgvNuevoDoc.Rows(e.RowIndex).Cells(e.ColumnIndex)

                If e.Value.Equals("1") Then
                    .ToolTipText = "1: ADQ. GRAVADAS DESTINADAS A OPE.GRAVADAS Y/O EXPORTACIONES"
                ElseIf e.Value.Equals("2") Then
                    .ToolTipText = "2: ADQ. GRAV DEST CONJUNTAMENTE A OPER GRAV Y NO GRAV"
                ElseIf e.Value.Equals("3") Then
                    .ToolTipText = "3: ADQ. GRAVADAS DESTINADAS A OPER.NO GRAVADAS"
                ElseIf e.Value.Equals("4") Then
                    .ToolTipText = "4: ADQUISICIONES NO GRAVADAS"
                End If

            End With

        End If
    End Sub
    Private CheckBoxClicked As Boolean = False

    Private Sub dgvNuevoDoc_CellValueChanged(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvNuevoDoc.CellValueChanged
        If dgvNuevoDoc.Rows.Count > 0 Then

            If e.ColumnIndex = 27 Then
                If (Me.dgvNuevoDoc.Rows(e.RowIndex).Cells("colBonif").Value) = "S" Then
                    CheckBoxClicked = True
                    '      dgvNuevoDoc.Item(29, dgvNuevoDoc.CurrentRow.Index).Value = "S"
                Else
                    CheckBoxClicked = False
                    '  dgvNuevoDoc.Item(29, dgvNuevoDoc.CurrentRow.Index).Value = "N"
                End If
                'Call the method to do when selected checkbox changes its state:
                MyMethodOnCheckBoxes()
            ElseIf e.ColumnIndex = 12 Then
                '    ValidaMontosBase()
            ElseIf e.ColumnIndex = 16 Then
                '      ValidaMontosBase()
            End If
        End If
    End Sub

    Private Sub dgvNuevoDoc_CurrentCellDirtyStateChanged(sender As Object, e As System.EventArgs) Handles dgvNuevoDoc.CurrentCellDirtyStateChanged
        Try
            If dgvNuevoDoc.IsCurrentCellDirty Then
                dgvNuevoDoc.CommitEdit(DataGridViewDataErrorContexts.Commit)
            End If

            If TypeOf dgvNuevoDoc.CurrentCell Is DataGridViewCheckBoxCell Then
                dgvNuevoDoc.CommitEdit(DataGridViewDataErrorContexts.Commit)
            End If


        Catch
        End Try
    End Sub

    Private Sub dgvNuevoDoc_EditingControlShowing(sender As Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvNuevoDoc.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf Validar_Numeros
    End Sub

    Private Sub dgvNuevoDoc_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgvNuevoDoc.KeyDown
        Dim conteo As Integer = dgvNuevoDoc.Rows.Count
        Try
            If e.KeyCode = Keys.Enter Then
                Select Case (dgvNuevoDoc.CurrentCell.ColumnIndex)
                    Case 7
                        If rbNac.Checked = True Then
                            If conteo = 1 Then
                                Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc(10, Me.dgvNuevoDoc.CurrentCell.RowIndex)
                            Else
                                Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc(10, Me.dgvNuevoDoc.CurrentCell.RowIndex)
                            End If
                        Else
                            If conteo = 1 Then
                                Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc(11, Me.dgvNuevoDoc.CurrentCell.RowIndex)
                            Else
                                Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc(11, Me.dgvNuevoDoc.CurrentCell.RowIndex)
                            End If
                        End If
                    Case 3
                        Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc(0, Me.dgvNuevoDoc.CurrentCell.RowIndex)
                    Case 10 Or 11
                        Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc(23, Me.dgvNuevoDoc.CurrentCell.RowIndex)
                End Select
                e.SuppressKeyPress = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ToolStrip3_ItemClicked(sender As System.Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolStrip3.ItemClicked

    End Sub
    Sub MostrarDetalle()
        Me.Cursor = Cursors.WaitCursor
        Dim objInsumo As GInsumo = GInsumo.InstanceSingle()
        objInsumo.Clear()
        With frmModalExistencia
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            lblTotalItems.Text = "Nro. de items: " & dgvNuevoDoc.Rows.Count

            If Not IsNothing(objInsumo.descripcionItem) Then
                dgvNuevoDoc.Rows.Add(ENTITY_ACTIONS.INSERT, "1", objInsumo.IdInsumo, objInsumo.descripcionItem,
                                     "09", "UND", objInsumo.unidad1, objInsumo.Cantidad, objInsumo.PU, objInsumo.PU, objInsumo.Total, objInsumo.Total, 0,
                                      0, 0, 0, 0, 0, 0, 0, ENTITY_ACTIONS.INSERT,
                                      objInsumo.tipoExistencia, objInsumo.cuenta, objInsumo.IdActividadRecurso)
            End If
            If dgvNuevoDoc.Rows.Count > 0 Then
                CellEndEditRefresh()
            End If

            If dgvNuevoDoc.Visible Then
                If dgvNuevoDoc.Rows.Count > 0 Then
                    Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc.Rows(dgvNuevoDoc.Rows.Count - 1).Cells(5)
                    Me.dgvNuevoDoc.BeginEdit(True)
                End If
            Else
                'If dgvSinControl.Rows.Count > 0 Then
                '    Me.dgvSinControl.CurrentCell = Me.dgvSinControl.Rows(dgvSinControl.Rows.Count - 1).Cells(10)
                '    Me.dgvSinControl.BeginEdit(True)
                'End If
            End If
        End With
        Me.Cursor = Cursors.Arrow
    End Sub
    Private Sub NuevoToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles NuevoToolStripButton.Click
        MostrarDetalle()
    End Sub
    Public Sub DeleteFilaDetalle(intCodigo As Integer)
        Dim documentocomprasa As New DocumentoCompraDetalleSA
        Dim compra As New documentocompradetalle
        compra.secuencia = intCodigo
        documentocomprasa.DeleteCompraDetalle(compra)
        lblEstado.Text = "Item eliminado de la canasta"
        lblEstado.Image = My.Resources.ok4
    End Sub
    Private Sub GuardarToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles GuardarToolStripButton1.Click
        If dgvNuevoDoc.Rows.Count > 0 Then
            If dgvNuevoDoc.Item(20, dgvNuevoDoc.CurrentRow.Index).Value = ENTITY_ACTIONS.INSERT Then
                deletefila()
            ElseIf dgvNuevoDoc.Item(20, dgvNuevoDoc.CurrentRow.Index).Value = ENTITY_ACTIONS.UPDATE Then
                DeleteFilaDetalle(dgvNuevoDoc.Item(0, dgvNuevoDoc.CurrentRow.Index).Value)
                deletefila()
            End If
            If dgvNuevoDoc.Rows.Count > 0 Then
                CellEndEditRefresh()
            End If
        End If

    End Sub

    Private Sub nudTipoCambio_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles nudTipoCambio.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            '     MostrarDetalle()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub nudTipoCambio_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nudTipoCambio.ValueChanged
        If dgvNuevoDoc.Rows.Count > 0 Then
            If nudTipoCambio.Value > 0 Then
                CellEndEditRefresh()
            End If

        End If
    End Sub

    Private Sub ImprimirToolStripButton_Click(sender As System.Object, e As System.EventArgs)
        Dispose()
    End Sub

    Private Sub txtFechaComprobante_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtFechaComprobante.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtComprobante.Select()
            txtComprobante.Focus()
            If txtComprobante.Text.Trim.Length > 0 Then

            Else
                Comprobantes()
            End If
        End If
    End Sub

    Private Sub txtFechaComprobante_ValueChanged(sender As System.Object, e As System.EventArgs) Handles txtFechaComprobante.ValueChanged

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click

    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        Dispose()
    End Sub

    Private Sub GuardarToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles GuardarToolStripButton2.Click
        Me.Cursor = Cursors.WaitCursor

        Dim validadoComp As Boolean = ValidarCajas(gbxComp)
        Dim validadoProv As Boolean = ValidarCajas(gbxProveedor)
        'Dim validadoCosto As Boolean = ValidarCajas(gbxCosto)
        '   Dim validadoPago As Boolean = ValidarCajas(gbxPago)
        Dim validadetalle As Boolean = ValidarCajas(TabPage5)


        If validadoComp = True Then
            Me.lblEstado.Image = My.Resources.ok4 ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\ok.ico")
            Me.lblEstado.Text = "Done Comprobantes!"
        Else
            Me.lblEstado.Image = My.Resources.cross 'Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\cross.png")
            Me.lblEstado.Text = "Complete todos los campos: Datos del comprobante!"
            tvDatos.SelectedNode = newNodeComprobante
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If

        If validadoProv = True Then
            Me.lblEstado.Image = My.Resources.ok4 ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\ok.ico")
            Me.lblEstado.Text = "Done Proveedores!"
        Else
            Me.lblEstado.Image = My.Resources.cross ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\cross.png")
            Me.lblEstado.Text = "Complete todos los campos: Datos del Proveedor!"
            tvDatos.SelectedNode = newNodeProveedor
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If

        If validadetalle = True Then
            Me.lblEstado.Image = My.Resources.ok4 ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\ok.ico")
            Me.lblEstado.Text = "Done Detalle de la compra!"
        Else
            Me.lblEstado.Image = My.Resources.cross ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\cross.png")
            Me.lblEstado.Text = "Complete todos los campos: Detalle de la compra!"
            tvDatos.SelectedNode = newNodeDetalle
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If
        '***********************************************************************
        If dgvNuevoDoc.Rows.Count > 0 Then
            Me.lblEstado.Image = My.Resources.ok4 ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\ok.ico")
            Me.lblEstado.Text = "Done!"
            If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
                Grabar()
            Else
                UpdateCompra()
            End If
        Else
            Me.lblEstado.Image = My.Resources.warning2 ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\warning2.png")
            Me.lblEstado.Text = "Ingrese items a la canasta de compra!"
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtCuenta_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCuenta.TextChanged

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

    End Sub

    Private Sub lblPeriodo_Click(sender As System.Object, e As System.EventArgs) Handles lblPeriodo.Click

    End Sub
End Class