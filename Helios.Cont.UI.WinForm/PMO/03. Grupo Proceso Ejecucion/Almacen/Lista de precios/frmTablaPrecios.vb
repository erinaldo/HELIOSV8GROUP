Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Tools
Imports System.Collections
Imports Syncfusion.Windows.Forms.Grid
Imports System.Collections.Specialized
Imports Syncfusion.Grouping
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Windows.Forms.Grid.Grouping
Public Class frmTablaPrecios
    Inherits frmMaster

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        GetTableGrid()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

#Region "Métodos"
    Private Sub GetTableGrid()
        Dim dt As New DataTable
        dt.Columns.Add("IdItem", GetType(Integer))
        dt.Columns.Add("existencia", GetType(String))
        dt.Columns.Add("destino", GetType(String))
        dt.Columns.Add("vc", GetType(Decimal))
        dt.Columns.Add("porcUtilidad", GetType(Decimal))
        dt.Columns.Add("impUti1", GetType(Decimal))
        dt.Columns.Add("vv", GetType(Decimal))
        dt.Columns.Add("igv", GetType(Decimal))
        dt.Columns.Add("precVenta", GetType(Decimal))
        dgvMenor.DataSource = dt

        Dim dt2 As New DataTable
        dt2.Columns.Add("IdItem2", GetType(Integer))
        dt2.Columns.Add("existencia2", GetType(String))
        dt2.Columns.Add("destino2", GetType(String))
        dt2.Columns.Add("vc2", GetType(Decimal))
        dt2.Columns.Add("porcUtilidad2", GetType(Decimal))
        dt2.Columns.Add("impUti", GetType(Decimal))
        dt2.Columns.Add("vv2", GetType(Decimal))
        dt2.Columns.Add("igv2", GetType(Decimal))
        dt2.Columns.Add("precVenta2", GetType(Decimal))
        dgvMayor.DataSource = dt2

        Dim dt3 As New DataTable
        dt3.Columns.Add("IdItem3", GetType(Integer))
        dt3.Columns.Add("existencia3", GetType(String))
        dt3.Columns.Add("destino3", GetType(String))
        dt3.Columns.Add("vc3", GetType(Decimal))
        dt3.Columns.Add("porcUtilidad3", GetType(Decimal))
        dt3.Columns.Add("impUti3", GetType(Decimal))
        dt3.Columns.Add("vv3", GetType(Decimal))
        dt3.Columns.Add("igv3", GetType(Decimal))
        dt3.Columns.Add("precVenta3", GetType(Decimal))
        dgvGranMayor.DataSource = dt3

    End Sub


    Private Sub Grabar()
        Dim TC As Decimal = txtTipoCambio.Value
        Dim objConfiEO As New listadoPrecios
        Dim ListadoSA As New ListadoPrecioSA
        Dim totalesAlmacenSA As New TotalesAlmacenSA
        Dim ListaPrecioFull As New List(Of listadoPrecios)

        Dim tipoExistencia As String
        Dim destinoGravado As String
        Dim presentacion As String
        Dim unidad As String

        Try

            With totalesAlmacenSA.GetUbicarProductoTAlmacen(txtAlmacenDestino.ValueMember, txtProducto.ValueMember)
                tipoExistencia = .tipoExistencia
                destinoGravado = .origenRecaudo
                presentacion = .Presentacion
                unidad = Nothing ' lblUnidad.Text
            End With

            objConfiEO = New listadoPrecios
            With objConfiEO
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                '   .idAlmacen = txtAlmacenDestino.ValueMember  ' frmListaPreciosExistencias.txtAlmacen.ValueMember

                .tipoExistencia = tipoExistencia
                .destinoGravado = destinoGravado
                .idItem = txtProducto.ValueMember
                .descripcion = txtProducto.Text.Trim
                .presentacion = presentacion
                .unidad = Nothing ' lblUnidad.Text
                .fecha = txtFechaRegistro.Value
                .tipoConfiguracion = IIf(rbPorcentaje.Checked = True, "P", "F")
                .porcUtimenor = Me.dgvMenor.Table.Records(0).GetValue("porcUtilidad")
                .porcUtimayor = Me.dgvMayor.Table.Records(0).GetValue("porcUtilidad2")
                .porcUtigranmayor = Me.dgvGranMayor.Table.Records(0).GetValue("porcUtilidad3")

                .vcmenor = Me.dgvMenor.Table.Records(0).GetValue("vc")
                .vcmenorme = Me.dgvMenor.Table.Records(1).GetValue("vc")

                .vcmayor = Me.dgvMayor.Table.Records(0).GetValue("vc2")
                .vcmayorme = Me.dgvMayor.Table.Records(1).GetValue("vc2")

                .vcgranmayor = Me.dgvGranMayor.Table.Records(0).GetValue("vc3")
                .vcgranmayorme = Me.dgvGranMayor.Table.Records(1).GetValue("vc3")


                .montoUtimenor = Me.dgvMenor.Table.Records(0).GetValue("impUti1")
                .montoUtimenorme = Me.dgvMenor.Table.Records(1).GetValue("impUti1")

                .montoUtimayor = Me.dgvMayor.Table.Records(0).GetValue("impUti")
                .montoUtimayorme = Me.dgvMayor.Table.Records(1).GetValue("impUti")

                .montoUtigranmayor = Me.dgvGranMayor.Table.Records(0).GetValue("impUti3")
                .montoUtigranmayorme = Me.dgvGranMayor.Table.Records(1).GetValue("impUti3")

                .vvmenor = Me.dgvMenor.Table.Records(0).GetValue("vv")
                .vvmenorme = Me.dgvMenor.Table.Records(1).GetValue("vv")

                .vvmayor = Me.dgvMayor.Table.Records(0).GetValue("vv2")
                .vvmayorme = Me.dgvMayor.Table.Records(1).GetValue("vv2")

                .vvgranmayor = Me.dgvGranMayor.Table.Records(0).GetValue("vv3")
                .vvgranmayorme = Me.dgvGranMayor.Table.Records(1).GetValue("vv3")

                .igvmenor = Me.dgvMenor.Table.Records(0).GetValue("igv")
                .igvmenormeme = Me.dgvMenor.Table.Records(1).GetValue("igv")

                .igvmayor = Me.dgvMayor.Table.Records(0).GetValue("igv2")
                .igvmayormeme = Me.dgvMayor.Table.Records(1).GetValue("igv2")

                .igvgranmayor = Me.dgvGranMayor.Table.Records(0).GetValue("igv3")
                .igvgranmayorme = Me.dgvGranMayor.Table.Records(1).GetValue("igv3")

                .pvmenor = Me.dgvMenor.Table.Records(0).GetValue("precVenta")
                .pvmenorme = Me.dgvMenor.Table.Records(1).GetValue("precVenta")

                .pvmayor = Me.dgvMayor.Table.Records(0).GetValue("precVenta2")
                .pvmayorme = Me.dgvMayor.Table.Records(1).GetValue("precVenta2")

                .pvgranmayor = Me.dgvGranMayor.Table.Records(0).GetValue("precVenta3")
                .pvgranmayorme = Me.dgvGranMayor.Table.Records(1).GetValue("precVenta3")
            End With
            ListadoSA.InsertarPrecioVV(objConfiEO)
            Dispose()

        Catch ex As Exception
            MsgBox("No se grabó correctamente." & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del Sistema.!")
        End Try
    End Sub

#End Region

    Private Sub frmTablaPrecios_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmTablaPrecios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.dgvMenor.Table.AddNewRecord.SetCurrent()
        Me.dgvMenor.Table.AddNewRecord.BeginEdit()
        Me.dgvMenor.Table.CurrentRecord.SetValue("vc", 0)
        Me.dgvMenor.Table.AddNewRecord.EndEdit()
        Me.dgvMenor.Table.AddNewRecord.SetCurrent()
        Me.dgvMenor.Table.AddNewRecord.BeginEdit()
        Me.dgvMenor.Table.CurrentRecord.SetValue("vc", 0)
        Me.dgvMenor.Table.AddNewRecord.EndEdit()

        Me.dgvMayor.Table.AddNewRecord.SetCurrent()
        Me.dgvMayor.Table.AddNewRecord.BeginEdit()
        Me.dgvMayor.Table.CurrentRecord.SetValue("vc2", 0)
        Me.dgvMayor.Table.AddNewRecord.EndEdit()
        Me.dgvMayor.Table.AddNewRecord.SetCurrent()
        Me.dgvMayor.Table.AddNewRecord.BeginEdit()
        Me.dgvMayor.Table.CurrentRecord.SetValue("vc2", 0)
        Me.dgvMayor.Table.AddNewRecord.EndEdit()

        Me.dgvGranMayor.Table.AddNewRecord.SetCurrent()
        Me.dgvGranMayor.Table.AddNewRecord.BeginEdit()
        Me.dgvGranMayor.Table.CurrentRecord.SetValue("vc3", 0)
        Me.dgvGranMayor.Table.AddNewRecord.EndEdit()
        Me.dgvGranMayor.Table.AddNewRecord.SetCurrent()
        Me.dgvGranMayor.Table.AddNewRecord.BeginEdit()
        Me.dgvGranMayor.Table.CurrentRecord.SetValue("vc3", 0)
        Me.dgvGranMayor.Table.AddNewRecord.EndEdit()
    End Sub

    Private Sub GuardarToolStripButton_Click(sender As Object, e As EventArgs) Handles GuardarToolStripButton.Click
        Grabar()
    End Sub

    Private Sub dgvMenor_QueryCellStyleInfo(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableCellStyleInfoEventArgs) Handles dgvMenor.QueryCellStyleInfo
        If Not IsNothing(e.TableCellIdentity.Column) Then
            'If e.TableCellIdentity.RowIndex = 3 Then
            '    e.Style.BackColor = Color.LightYellow
            'ElseIf e.TableCellIdentity.RowIndex = 4 Then
            '    e.Style.BackColor = Color.PaleGreen
            'End If
            'If rbPorcentaje.Checked = True Then
            '    ' If e.Style.CellValue.Equals("MR") Then
            '    e.Style.BackColor = Color.LightYellow
            '    'End If
            'End If
            'If e.TableCellIdentity.Column.Name = "importeMN" Then
            '    If IsNumeric(e.Style.CellValue) Then
            '        '        If Fix(e.Style.CellValue) > 0 Then
            '        '    e.Style.ReadOnly = True
            '        e.TableCellIdentity.Table.CurrentRecord.SetValue("HaberMN", 0)
            '        'End If
            '    End If

            'End If
        End If
    End Sub

    Private Sub dgvMenor_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvMenor.TableControlCellClick

    End Sub

    Private Sub dgvMenor_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvMenor.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim RowIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.RowIndex
        If ColIndex = 2 Then
            If RowIndex = 3 Then
                If Not IsNothing(Me.dgvMenor.Table.CurrentRecord) Then
                    Dim colValCompraMenor As Decimal = Me.dgvMenor.Table.Records(0).GetValue("vc")
                    Dim colValCompraMenorME As Decimal = Me.dgvMenor.Table.Records(1).GetValue("vc")
                    If Not IsDBNull(Me.dgvMenor.Table.CurrentRecord.GetValue("porcUtilidad")) Then
                        Dim colPorcUtiMenor As Decimal = Me.dgvMenor.Table.CurrentRecord.GetValue("porcUtilidad")
                        Dim colMontoUtiMenor As Decimal = Math.Round(colValCompraMenor * (colPorcUtiMenor / 100), 2)
                        Dim colMontoUtiMenorME As Decimal = Math.Round(colValCompraMenorME * (colPorcUtiMenor / 100), 2)

                        Dim colValorVentaMenor As Decimal = colValCompraMenor + colMontoUtiMenor
                        Dim colValorVentaMenorME As Decimal = colValCompraMenorME + colMontoUtiMenorME


                        ' Dim a As Decimal = 1.16
                      

                        Select Case txtDestino.Text.Trim
                            Case "1"

                                Dim colIgvMenor As Decimal = Math.Round(colValorVentaMenor * (18 / 100), 2)
                                Dim colIgvMenorME As Decimal = Math.Round(colValorVentaMenorME * (18 / 100), 2)

                                Dim colPrecioVentaMenor As Decimal = colValorVentaMenor + colIgvMenor
                                Dim colPrecioVentaMenorME As Decimal = colValorVentaMenorME + colIgvMenorME

                                Dim b As Decimal = 0
                                Dim b1 As Decimal = 0
                                b = colPrecioVentaMenor - Int(colPrecioVentaMenor)
                                b1 = colPrecioVentaMenorME - Int(colPrecioVentaMenorME)
                                Dim s = b.ToString.Replace("0.", "")
                                Dim s1 = b1.ToString.Replace("0.", "")
                                Dim x = Mid(s, 1, 1) & "0"
                                Dim x1 = Mid(s1, 1, 1) & "0"
                                If s > x Then
                                    Dim z = CDbl(x) + 10
                                    'Dim zz = Int(a).ToString
                                    Dim zzz = Int(z).ToString
                                    If z = 100 Then
                                        Dim zzzz = Int(colPrecioVentaMenor) + 1 & "." & 0
                                        Dim resultMN = CDbl(zzzz)
                                        colPrecioVentaMenor = resultMN
                                    Else
                                        Dim zzzz = Int(colPrecioVentaMenor).ToString & "." & zzz
                                        Dim resultMN = CDbl(zzzz)
                                        '    MsgBox(resultMN)
                                        colPrecioVentaMenor = resultMN
                                    End If
                                    
                                End If

                                If s1 > x1 Then
                                    Dim z1 = CDbl(x1) + 10
                                    'Dim zz = Int(a).ToString
                                    Dim zzz1 = Int(z1).ToString
                                    If z1 = 100 Then
                                        Dim zzzz1 = Int(colPrecioVentaMenorME) + 1 & "." & 0
                                        Dim resultMe = CDbl(zzzz1)
                                        colPrecioVentaMenorME = resultMe
                                    Else
                                        Dim zzzz1 = Int(colPrecioVentaMenorME).ToString & "." & zzz1
                                        Dim resultME = CDbl(zzzz1)
                                        colPrecioVentaMenorME = resultME
                                    End If
                                    '    MsgBox(resultMN)
                                End If


                                '  Me.dgvMenor.Table.CurrentRecord.SetValue("vc", importeDebeME)
                                '  Me.dgvMenor.Table.CurrentRecord.SetValue("porcUtilidad", importeDebeME)
                                Me.dgvMenor.Table.Records(0).SetValue("impUti1", colMontoUtiMenor)
                                Me.dgvMenor.Table.Records(0).SetValue("vv", colValorVentaMenor)
                                Me.dgvMenor.Table.Records(0).SetValue("igv", colIgvMenor)
                                Me.dgvMenor.Table.Records(0).SetValue("precVenta", colPrecioVentaMenor)

                                Me.dgvMenor.Table.Records(1).SetValue("impUti1", colMontoUtiMenorME)
                                Me.dgvMenor.Table.Records(1).SetValue("vv", colValorVentaMenorME)
                                Me.dgvMenor.Table.Records(1).SetValue("igv", colIgvMenorME)
                                Me.dgvMenor.Table.Records(1).SetValue("precVenta", colPrecioVentaMenorME)
                            Case "2"

                                Dim colIgvMenor As Decimal = 0
                                Dim colIgvMenorME As Decimal = 0

                                Dim colPrecioVentaMenor As Decimal = colValorVentaMenor + colIgvMenor
                                Dim colPrecioVentaMenorME As Decimal = colValorVentaMenorME + colIgvMenorME


                                Dim b As Decimal = 0
                                Dim b1 As Decimal = 0
                                b = colPrecioVentaMenor - Int(colPrecioVentaMenor)
                                b1 = colPrecioVentaMenorME - Int(colPrecioVentaMenorME)
                                Dim s = b.ToString.Replace("0.", "")
                                Dim s1 = b1.ToString.Replace("0.", "")
                                Dim x = Mid(s, 1, 1) & "0"
                                Dim x1 = Mid(s1, 1, 1) & "0"
                                If s > x Then
                                    Dim z = CDbl(x) + 10
                                    'Dim zz = Int(a).ToString
                                    Dim zzz = Int(z).ToString
                                    If z = 100 Then
                                        Dim zzzz = Int(colPrecioVentaMenor) + 1 & "." & 0
                                        Dim resultMN = CDbl(zzzz)
                                        colPrecioVentaMenor = resultMN
                                    Else
                                        Dim zzzz = Int(colPrecioVentaMenor).ToString & "." & zzz
                                        Dim resultMN = CDbl(zzzz)
                                        '    MsgBox(resultMN)
                                        colPrecioVentaMenor = resultMN
                                    End If

                                End If

                                If s1 > x1 Then
                                    Dim z1 = CDbl(x1) + 10
                                    'Dim zz = Int(a).ToString
                                    Dim zzz1 = Int(z1).ToString
                                    If z1 = 100 Then
                                        Dim zzzz1 = Int(colPrecioVentaMenorME) + 1 & "." & 0
                                        Dim resultMe = CDbl(zzzz1)
                                        colPrecioVentaMenorME = resultMe
                                    Else
                                        Dim zzzz1 = Int(colPrecioVentaMenorME).ToString & "." & zzz1
                                        Dim resultME = CDbl(zzzz1)
                                        colPrecioVentaMenorME = resultME
                                    End If
                                    '    MsgBox(resultMN)
                                End If


                                '  Me.dgvMenor.Table.CurrentRecord.SetValue("vc", importeDebeME)
                                '  Me.dgvMenor.Table.CurrentRecord.SetValue("porcUtilidad", importeDebeME)
                                Me.dgvMenor.Table.Records(0).SetValue("impUti1", colMontoUtiMenor)
                                Me.dgvMenor.Table.Records(0).SetValue("vv", colValorVentaMenor)
                                Me.dgvMenor.Table.Records(0).SetValue("igv", colIgvMenor)
                                Me.dgvMenor.Table.Records(0).SetValue("precVenta", colPrecioVentaMenor)

                                Me.dgvMenor.Table.Records(1).SetValue("impUti1", colMontoUtiMenorME)
                                Me.dgvMenor.Table.Records(1).SetValue("vv", colValorVentaMenorME)
                                Me.dgvMenor.Table.Records(1).SetValue("igv", colIgvMenorME)
                                Me.dgvMenor.Table.Records(1).SetValue("precVenta", colPrecioVentaMenorME)
                        End Select

                        Me.dgvMenor.Table.Records(1).SetValue("porcUtilidad", Me.dgvMenor.Table.CurrentRecord.GetValue("porcUtilidad"))
                    End If
                End If
            Else
                Me.dgvMenor.Table.Records(1).SetValue("porcUtilidad", Me.dgvMenor.Table.Records(0).GetValue("porcUtilidad"))
            End If

        End If

    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        With frmUltimasCompras
            .txtItem.Text = txtProducto.Text
            .txtItem.ValueMember = txtProducto.ValueMember
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            If ValorEntrada > 0 Then
                Me.dgvMenor.Table.Records(0).SetValue("vc", ValorEntrada)
                Me.dgvMenor.Table.Records(1).SetValue("vc", ValorEntradaME)

                Me.dgvMayor.Table.Records(0).SetValue("vc2", ValorEntrada)
                Me.dgvMayor.Table.Records(1).SetValue("vc2", ValorEntradaME)

                Me.dgvGranMayor.Table.Records(0).SetValue("vc3", ValorEntrada)
                Me.dgvGranMayor.Table.Records(1).SetValue("vc3", ValorEntradaME)
                ValorEntrada = 0
                ValorEntradaME = 0
            End If
        End With
    End Sub

    Private Sub dgvMayor_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvMayor.TableControlCellClick

    End Sub

    Private Sub dgvMayor_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvMayor.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim RowIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.RowIndex
        If ColIndex = 2 Then
            If RowIndex = 3 Then
                If Not IsNothing(Me.dgvMayor.Table.CurrentRecord) Then
                    Dim colValCompraMenor As Decimal = Me.dgvMayor.Table.Records(0).GetValue("vc2")
                    Dim colValCompraMenorME As Decimal = Me.dgvMayor.Table.Records(1).GetValue("vc2")
                    If Not IsDBNull(Me.dgvMayor.Table.CurrentRecord.GetValue("porcUtilidad2")) Then
                        Dim colPorcUtiMenor As Decimal = Me.dgvMayor.Table.CurrentRecord.GetValue("porcUtilidad2")
                        Dim colMontoUtiMenor As Decimal = Math.Round(colValCompraMenor * (colPorcUtiMenor / 100), 2)
                        Dim colMontoUtiMenorME As Decimal = Math.Round(colValCompraMenorME * (colPorcUtiMenor / 100), 2)

                        Dim colValorVentaMenor As Decimal = colValCompraMenor + colMontoUtiMenor
                        Dim colValorVentaMenorME As Decimal = colValCompraMenorME + colMontoUtiMenorME

                        Select Case txtDestino.Text.Trim
                            Case "1"
                                Dim colIgvMenor As Decimal = Math.Round(colValorVentaMenor * (18 / 100), 2)
                                Dim colIgvMenorME As Decimal = Math.Round(colValorVentaMenorME * (18 / 100), 2)

                                Dim colPrecioVentaMenor As Decimal = colValorVentaMenor + colIgvMenor
                                Dim colPrecioVentaMenorME As Decimal = colValorVentaMenorME + colIgvMenorME

                                Dim b As Decimal = 0
                                Dim b1 As Decimal = 0
                                b = colPrecioVentaMenor - Int(colPrecioVentaMenor)
                                b1 = colPrecioVentaMenorME - Int(colPrecioVentaMenorME)
                                Dim s = b.ToString.Replace("0.", "")
                                Dim s1 = b1.ToString.Replace("0.", "")
                                Dim x = Mid(s, 1, 1) & "0"
                                Dim x1 = Mid(s1, 1, 1) & "0"
                                If s > x Then
                                    Dim z = CDbl(x) + 10
                                    'Dim zz = Int(a).ToString
                                    Dim zzz = Int(z).ToString
                                    If z = 100 Then
                                        Dim zzzz = Int(colPrecioVentaMenor) + 1 & "." & 0
                                        Dim resultMN = CDbl(zzzz)
                                        colPrecioVentaMenor = resultMN
                                    Else
                                        Dim zzzz = Int(colPrecioVentaMenor).ToString & "." & zzz
                                        Dim resultMN = CDbl(zzzz)
                                        '    MsgBox(resultMN)
                                        colPrecioVentaMenor = resultMN
                                    End If

                                End If

                                If s1 > x1 Then
                                    Dim z1 = CDbl(x1) + 10
                                    'Dim zz = Int(a).ToString
                                    Dim zzz1 = Int(z1).ToString
                                    If z1 = 100 Then
                                        Dim zzzz1 = Int(colPrecioVentaMenorME) + 1 & "." & 0
                                        Dim resultMe = CDbl(zzzz1)
                                        colPrecioVentaMenorME = resultMe
                                    Else
                                        Dim zzzz1 = Int(colPrecioVentaMenorME).ToString & "." & zzz1
                                        Dim resultME = CDbl(zzzz1)
                                        colPrecioVentaMenorME = resultME
                                    End If
                                    '    MsgBox(resultMN)
                                End If

                                '  Me.dgvMenor.Table.CurrentRecord.SetValue("vc", importeDebeME)
                                '  Me.dgvMenor.Table.CurrentRecord.SetValue("porcUtilidad", importeDebeME)
                                Me.dgvMayor.Table.Records(0).SetValue("impUti", colMontoUtiMenor)
                                Me.dgvMayor.Table.Records(0).SetValue("vv2", colValorVentaMenor)
                                Me.dgvMayor.Table.Records(0).SetValue("igv2", colIgvMenor)
                                Me.dgvMayor.Table.Records(0).SetValue("precVenta2", colPrecioVentaMenor)

                                Me.dgvMayor.Table.Records(1).SetValue("impUti", colMontoUtiMenorME)
                                Me.dgvMayor.Table.Records(1).SetValue("vv2", colValorVentaMenorME)
                                Me.dgvMayor.Table.Records(1).SetValue("igv2", colIgvMenorME)
                                Me.dgvMayor.Table.Records(1).SetValue("precVenta2", colPrecioVentaMenorME)
                            Case "2"
                                Dim colIgvMenor As Decimal = 0
                                Dim colIgvMenorME As Decimal = 0

                                Dim colPrecioVentaMenor As Decimal = colValorVentaMenor + colIgvMenor
                                Dim colPrecioVentaMenorME As Decimal = colValorVentaMenorME + colIgvMenorME

                                Dim b As Decimal = 0
                                Dim b1 As Decimal = 0
                                b = colPrecioVentaMenor - Int(colPrecioVentaMenor)
                                b1 = colPrecioVentaMenorME - Int(colPrecioVentaMenorME)
                                Dim s = b.ToString.Replace("0.", "")
                                Dim s1 = b1.ToString.Replace("0.", "")
                                Dim x = Mid(s, 1, 1) & "0"
                                Dim x1 = Mid(s1, 1, 1) & "0"
                                If s > x Then
                                    Dim z = CDbl(x) + 10
                                    'Dim zz = Int(a).ToString
                                    Dim zzz = Int(z).ToString
                                    If z = 100 Then
                                        Dim zzzz = Int(colPrecioVentaMenor) + 1 & "." & 0
                                        Dim resultMN = CDbl(zzzz)
                                        colPrecioVentaMenor = resultMN
                                    Else
                                        Dim zzzz = Int(colPrecioVentaMenor).ToString & "." & zzz
                                        Dim resultMN = CDbl(zzzz)
                                        '    MsgBox(resultMN)
                                        colPrecioVentaMenor = resultMN
                                    End If

                                End If

                                If s1 > x1 Then
                                    Dim z1 = CDbl(x1) + 10
                                    'Dim zz = Int(a).ToString
                                    Dim zzz1 = Int(z1).ToString
                                    If z1 = 100 Then
                                        Dim zzzz1 = Int(colPrecioVentaMenorME) + 1 & "." & 0
                                        Dim resultMe = CDbl(zzzz1)
                                        colPrecioVentaMenorME = resultMe
                                    Else
                                        Dim zzzz1 = Int(colPrecioVentaMenorME).ToString & "." & zzz1
                                        Dim resultME = CDbl(zzzz1)
                                        colPrecioVentaMenorME = resultME
                                    End If
                                    '    MsgBox(resultMN)
                                End If

                                '  Me.dgvMenor.Table.CurrentRecord.SetValue("vc", importeDebeME)
                                '  Me.dgvMenor.Table.CurrentRecord.SetValue("porcUtilidad", importeDebeME)
                                Me.dgvMayor.Table.Records(0).SetValue("impUti", colMontoUtiMenor)
                                Me.dgvMayor.Table.Records(0).SetValue("vv2", colValorVentaMenor)
                                Me.dgvMayor.Table.Records(0).SetValue("igv2", colIgvMenor)
                                Me.dgvMayor.Table.Records(0).SetValue("precVenta2", colPrecioVentaMenor)

                                Me.dgvMayor.Table.Records(1).SetValue("impUti", colMontoUtiMenorME)
                                Me.dgvMayor.Table.Records(1).SetValue("vv2", colValorVentaMenorME)
                                Me.dgvMayor.Table.Records(1).SetValue("igv2", colIgvMenorME)
                                Me.dgvMayor.Table.Records(1).SetValue("precVenta2", colPrecioVentaMenorME)
                        End Select

                        Me.dgvMayor.Table.Records(1).SetValue("porcUtilidad2", Me.dgvMayor.Table.Records(0).GetValue("porcUtilidad2"))
                    End If
                End If
            Else
                Me.dgvMayor.Table.Records(1).SetValue("porcUtilidad2", Me.dgvMayor.Table.Records(0).GetValue("porcUtilidad2"))
            End If

        End If
    End Sub

    Private Sub dgvGranMayor_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvGranMayor.TableControlCellClick

    End Sub

    Private Sub dgvGranMayor_TableControlCurrentCellDeleting(sender As Object, e As GridTableControlCancelEventArgs) Handles dgvGranMayor.TableControlCurrentCellDeleting

    End Sub

    Private Sub dgvGranMayor_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvGranMayor.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim RowIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.RowIndex
        If ColIndex = 2 Then
            If RowIndex = 3 Then
                If Not IsNothing(Me.dgvGranMayor.Table.CurrentRecord) Then
                    Dim colValCompraMenor As Decimal = Me.dgvGranMayor.Table.Records(0).GetValue("vc3")
                    Dim colValCompraMenorME As Decimal = Me.dgvGranMayor.Table.Records(1).GetValue("vc3")
                    If Not IsDBNull(Me.dgvGranMayor.Table.CurrentRecord.GetValue("porcUtilidad3")) Then
                        Dim colPorcUtiMenor As Decimal = Me.dgvGranMayor.Table.CurrentRecord.GetValue("porcUtilidad3")
                        Dim colMontoUtiMenor As Decimal = Math.Round(colValCompraMenor * (colPorcUtiMenor / 100), 2)
                        Dim colMontoUtiMenorME As Decimal = Math.Round(colValCompraMenorME * (colPorcUtiMenor / 100), 2)

                        Dim colValorVentaMenor As Decimal = colValCompraMenor + colMontoUtiMenor
                        Dim colValorVentaMenorME As Decimal = colValCompraMenorME + colMontoUtiMenorME

                        Select Case txtDestino.Text.Trim
                            Case "1"
                                Dim colIgvMenor As Decimal = Math.Round(colValorVentaMenor * (18 / 100), 2)
                                Dim colIgvMenorME As Decimal = Math.Round(colValorVentaMenorME * (18 / 100), 2)

                                Dim colPrecioVentaMenor As Decimal = colValorVentaMenor + colIgvMenor
                                Dim colPrecioVentaMenorME As Decimal = colValorVentaMenorME + colIgvMenorME


                                Dim b As Decimal = 0
                                Dim b1 As Decimal = 0
                                b = colPrecioVentaMenor - Int(colPrecioVentaMenor)
                                b1 = colPrecioVentaMenorME - Int(colPrecioVentaMenorME)
                                Dim s = b.ToString.Replace("0.", "")
                                Dim s1 = b1.ToString.Replace("0.", "")
                                Dim x = Mid(s, 1, 1) & "0"
                                Dim x1 = Mid(s1, 1, 1) & "0"
                                If s > x Then
                                    Dim z = CDbl(x) + 10
                                    'Dim zz = Int(a).ToString
                                    Dim zzz = Int(z).ToString
                                    If z = 100 Then
                                        Dim zzzz = Int(colPrecioVentaMenor) + 1 & "." & 0
                                        Dim resultMN = CDbl(zzzz)
                                        colPrecioVentaMenor = resultMN
                                    Else
                                        Dim zzzz = Int(colPrecioVentaMenor).ToString & "." & zzz
                                        Dim resultMN = CDbl(zzzz)
                                        '    MsgBox(resultMN)
                                        colPrecioVentaMenor = resultMN
                                    End If

                                End If

                                If s1 > x1 Then
                                    Dim z1 = CDbl(x1) + 10
                                    'Dim zz = Int(a).ToString
                                    Dim zzz1 = Int(z1).ToString
                                    If z1 = 100 Then
                                        Dim zzzz1 = Int(colPrecioVentaMenorME) + 1 & "." & 0
                                        Dim resultMe = CDbl(zzzz1)
                                        colPrecioVentaMenorME = resultMe
                                    Else
                                        Dim zzzz1 = Int(colPrecioVentaMenorME).ToString & "." & zzz1
                                        Dim resultME = CDbl(zzzz1)
                                        colPrecioVentaMenorME = resultME
                                    End If
                                    '    MsgBox(resultMN)
                                End If

                                '  Me.dgvMenor.Table.CurrentRecord.SetValue("vc", importeDebeME)
                                '  Me.dgvMenor.Table.CurrentRecord.SetValue("porcUtilidad", importeDebeME)
                                Me.dgvGranMayor.Table.Records(0).SetValue("impUti3", colMontoUtiMenor)
                                Me.dgvGranMayor.Table.Records(0).SetValue("vv3", colValorVentaMenor)
                                Me.dgvGranMayor.Table.Records(0).SetValue("igv3", colIgvMenor)
                                Me.dgvGranMayor.Table.Records(0).SetValue("precVenta3", colPrecioVentaMenor)

                                Me.dgvGranMayor.Table.Records(1).SetValue("impUti3", colMontoUtiMenorME)
                                Me.dgvGranMayor.Table.Records(1).SetValue("vv3", colValorVentaMenorME)
                                Me.dgvGranMayor.Table.Records(1).SetValue("igv3", colIgvMenorME)
                                Me.dgvGranMayor.Table.Records(1).SetValue("precVenta3", colPrecioVentaMenorME)
                            Case "2"
                                Dim colIgvMenor As Decimal = 0
                                Dim colIgvMenorME As Decimal = 0

                                Dim colPrecioVentaMenor As Decimal = colValorVentaMenor + colIgvMenor
                                Dim colPrecioVentaMenorME As Decimal = colValorVentaMenorME + colIgvMenorME

                                Dim b As Decimal = 0
                                Dim b1 As Decimal = 0
                                b = colPrecioVentaMenor - Int(colPrecioVentaMenor)
                                b1 = colPrecioVentaMenorME - Int(colPrecioVentaMenorME)
                                Dim s = b.ToString.Replace("0.", "")
                                Dim s1 = b1.ToString.Replace("0.", "")
                                Dim x = Mid(s, 1, 1) & "0"
                                Dim x1 = Mid(s1, 1, 1) & "0"
                                If s > x Then
                                    Dim z = CDbl(x) + 10
                                    'Dim zz = Int(a).ToString
                                    Dim zzz = Int(z).ToString
                                    If z = 100 Then
                                        Dim zzzz = Int(colPrecioVentaMenor) + 1 & "." & 0
                                        Dim resultMN = CDbl(zzzz)
                                        colPrecioVentaMenor = resultMN
                                    Else
                                        Dim zzzz = Int(colPrecioVentaMenor).ToString & "." & zzz
                                        Dim resultMN = CDbl(zzzz)
                                        '    MsgBox(resultMN)
                                        colPrecioVentaMenor = resultMN
                                    End If

                                End If

                                If s1 > x1 Then
                                    Dim z1 = CDbl(x1) + 10
                                    'Dim zz = Int(a).ToString
                                    Dim zzz1 = Int(z1).ToString
                                    If z1 = 100 Then
                                        Dim zzzz1 = Int(colPrecioVentaMenorME) + 1 & "." & 0
                                        Dim resultMe = CDbl(zzzz1)
                                        colPrecioVentaMenorME = resultMe
                                    Else
                                        Dim zzzz1 = Int(colPrecioVentaMenorME).ToString & "." & zzz1
                                        Dim resultME = CDbl(zzzz1)
                                        colPrecioVentaMenorME = resultME
                                    End If
                                    '    MsgBox(resultMN)
                                End If


                                '  Me.dgvMenor.Table.CurrentRecord.SetValue("vc", importeDebeME)
                                '  Me.dgvMenor.Table.CurrentRecord.SetValue("porcUtilidad", importeDebeME)
                                Me.dgvGranMayor.Table.Records(0).SetValue("impUti3", colMontoUtiMenor)
                                Me.dgvGranMayor.Table.Records(0).SetValue("vv3", colValorVentaMenor)
                                Me.dgvGranMayor.Table.Records(0).SetValue("igv3", colIgvMenor)
                                Me.dgvGranMayor.Table.Records(0).SetValue("precVenta3", colPrecioVentaMenor)

                                Me.dgvGranMayor.Table.Records(1).SetValue("impUti3", colMontoUtiMenorME)
                                Me.dgvGranMayor.Table.Records(1).SetValue("vv3", colValorVentaMenorME)
                                Me.dgvGranMayor.Table.Records(1).SetValue("igv3", colIgvMenorME)
                                Me.dgvGranMayor.Table.Records(1).SetValue("precVenta3", colPrecioVentaMenorME)
                        End Select

                        Me.dgvGranMayor.Table.Records(1).SetValue("porcUtilidad3", Me.dgvGranMayor.Table.Records(0).GetValue("porcUtilidad3"))
                    End If
                End If
            Else
                Me.dgvGranMayor.Table.Records(1).SetValue("porcUtilidad3", Me.dgvGranMayor.Table.Records(0).GetValue("porcUtilidad3"))
            End If

        End If
    End Sub
End Class