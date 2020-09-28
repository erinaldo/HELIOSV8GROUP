Imports Helios.Cont.Business.Entity
Imports Helios.Cont.Presentation.WinForm
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.GroupingGridExcelConverter
Public Class UCSubReporteVentas

#Region "Atributos"

    'Private UCResumenVentas As UCResumenVentas
    'Private UCResumenVentasCustom As UCResumenVentasCustom
    Private UCRentabilidad As UCRentabilidad
    'Private UCRankingVentas As UCRankingVentas

    Private UCSalesBySeller As UCSalesBySeller

#End Region

#Region "Constructor"

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        'UCFlujoCajaGeneral = New UCFlujoCajaGeneral With {.Dock = DockStyle.Fill, .Visible = False}
        'UCResumenVentasCustom = New UCResumenVentasCustom With {.Dock = DockStyle.Fill, .Visible = False}
        UCRentabilidad = New UCRentabilidad With {.Dock = DockStyle.Fill, .Visible = False}
        'UCResumenVentas = New UCResumenVentas With {.Dock = DockStyle.Fill, .Visible = False}
        'UCRankingVentas = New UCRankingVentas With {.Dock = DockStyle.Fill, .Visible = False}

        'PanelBody.Controls.Add(UCResumenVentas)
        'PanelBody.Controls.Add(UCFlujoCajaGeneral)
        'PanelBody.Controls.Add(UCResumenVentasCustom)
        PanelBody.Controls.Add(UCRentabilidad)
        'PanelBody.Controls.Add(UCRankingVentas)
    End Sub
#End Region

#Region "Metodos"

    Public Sub OcultarTodos()

        If UCRentabilidad IsNot Nothing Then
            UCRentabilidad.Visible = False
        End If

        If UCSalesBySeller IsNot Nothing Then
            UCSalesBySeller.Visible = False
        End If
    End Sub

    Public Sub SalesBySeller(typeConsult As String, idEstablecimiento As Integer, periodo As String, fechaLaboral As DateTime, IDUsuario As Integer, tipoComprobante As String)
        Dim ListaTipo As New List(Of String)

        If tipoComprobante = "VENTAS" Then
            ListaTipo.Add("01")
            ListaTipo.Add("03")
            ListaTipo.Add("9907")

        ElseIf tipoComprobante = "PEDIDOS" Then

            ListaTipo.Add("1000")

        End If


        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA
        Dim lista As List(Of documentoventaAbarrotes)
        If typeConsult = "PERIODO" Then

            If tipoComprobante = "VENTAS" Then
                ListaTipo.Add("01")
                ListaTipo.Add("03")
                ListaTipo.Add("9907")
                lista = DocumentoVentaSA.GetListarTodasVentas(New documentoventaAbarrotes With {.idEstablecimiento = idEstablecimiento, .fechaPeriodo = periodo, .tipoDocumento = "0"}, typeConsult).Where(Function(o) o.usuarioActualizacion = IDUsuario And ListaTipo.Contains(o.tipoDocumento)).ToList
            ElseIf tipoComprobante = "PEDIDOS" Then
                lista = DocumentoVentaSA.GetListarTodasVentas(New documentoventaAbarrotes With {.idEstablecimiento = idEstablecimiento, .fechaPeriodo = periodo, .tipoDocumento = "1000"}, typeConsult).Where(Function(o) o.usuarioActualizacion = IDUsuario).ToList
            End If

        ElseIf typeConsult = "DIA" Then

            If tipoComprobante = "VENTAS" Then
                lista = DocumentoVentaSA.GetListarTodasVentas(New documentoventaAbarrotes With {.idEstablecimiento = idEstablecimiento, .fechaDoc = fechaLaboral, .tipoDocumento = "0"}, typeConsult).Where(Function(o) o.usuarioActualizacion = IDUsuario And ListaTipo.Contains(o.tipoDocumento)).ToList
            ElseIf tipoComprobante = "PEDIDOS" Then
                lista = DocumentoVentaSA.GetListarTodasVentas(New documentoventaAbarrotes With {.idEstablecimiento = idEstablecimiento, .fechaDoc = fechaLaboral, .tipoDocumento = "1000"}, typeConsult).Where(Function(o) o.usuarioActualizacion = IDUsuario).ToList
            End If


        End If


        OcultarTodos()
        If UCSalesBySeller IsNot Nothing Then

            UCSalesBySeller.GetListSalesPerSeller(lista)

            UCSalesBySeller.Visible = True
            UCSalesBySeller.BringToFront()
            UCSalesBySeller.Show()
        Else
            UCSalesBySeller = New UCSalesBySeller With {.Dock = DockStyle.Fill, .Visible = False}
            PanelBody.Controls.Add(UCSalesBySeller)

            UCSalesBySeller.GetListSalesPerSeller(lista)

            UCSalesBySeller.Visible = True
            UCSalesBySeller.BringToFront()
            UCSalesBySeller.Show()
        End If




    End Sub





#End Region

    'Private Sub btnRentabilidad_Click(sender As Object, e As EventArgs) Handles btnRentabilidad.Click, btnRanking.Click, btnVentas.Click
    '    sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
    '    sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width
    '    '  End If
    '    Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)
    '    Select Case btn.Text
    '        Case "FLUJO DE CAJA: CAJERO"
    '            If UCRentabilidad Is Nothing Then Exit Sub
    '            'If UCFlujoCajaGeneral Is Nothing Then Exit Sub
    '            If UCResumenVentasCustom Is Nothing Then Exit Sub
    '            If UCRankingVentas Is Nothing Then Exit Sub
    '            UCRentabilidad.Visible = False
    '            'UCFlujoCajaGeneral.Visible = False
    '            UCResumenVentasCustom.Visible = False
    '            UCRankingVentas.Visible = False
    '            If UCResumenVentas IsNot Nothing Then
    '                UCResumenVentas.Visible = True
    '                UCResumenVentas.BringToFront()
    '                UCResumenVentas.Show()
    '            End If
    '        'Case "FLUJO DE CAJA: UNIDAD"
    '        '    UCRentabilidad.Visible = False
    '        '    'UCFlujoCajaGeneral.GetEstablecimientos()
    '        '    UCResumenVentas.Visible = False
    '        '    UCResumenVentasCustom.Visible = False
    '        '    UCRankingVentas.Visible = False
    '        '    If UCFlujoCajaGeneral IsNot Nothing Then
    '        '        UCFlujoCajaGeneral.ComboUnidad.Enabled = True
    '        '        UCFlujoCajaGeneral.Visible = True
    '        '        UCFlujoCajaGeneral.BringToFront()
    '        '        UCFlujoCajaGeneral.Show()
    '        '    End If
    '        Case "VENTAS"
    '            UCRentabilidad.Visible = False
    '            UCResumenVentasCustom.GetCombos()
    '            UCResumenVentas.Visible = False
    '            'UCFlujoCajaGeneral.Visible = False
    '            UCRankingVentas.Visible = False
    '            If UCResumenVentasCustom IsNot Nothing Then
    '                UCResumenVentasCustom.ComboUnidad.Enabled = True
    '                UCResumenVentasCustom.Visible = True
    '                UCResumenVentasCustom.BringToFront()
    '                UCResumenVentasCustom.Show()
    '            End If
    '        Case "RENTABILIDAD"
    '            UCResumenVentasCustom.Visible = False
    '            UCResumenVentas.Visible = False
    '            'UCFlujoCajaGeneral.Visible = False
    '            UCRankingVentas.Visible = False
    '            If UCRentabilidad IsNot Nothing Then
    '                UCRentabilidad.GetEstablecimientos()
    '                UCRentabilidad.ComboUnidad.Enabled = True
    '                UCRentabilidad.Visible = True
    '                UCRentabilidad.BringToFront()
    '                UCRentabilidad.Show()
    '            End If

    '        Case "RANKING"
    '            UCResumenVentasCustom.Visible = False
    '            UCResumenVentas.Visible = False
    '            'UCFlujoCajaGeneral.Visible = False
    '            UCRentabilidad.Visible = False
    '            If UCRentabilidad IsNot Nothing Then
    '                UCRankingVentas.Visible = True
    '                UCRankingVentas.BringToFront()
    '                UCRankingVentas.Show()
    '            End If
    '    End Select
    'End Sub

    Private Sub btnBuscarVenta_Click(sender As Object, e As EventArgs) Handles btnBuscarVenta.Click
        Try


            Select Case cboTipoBusqueda.Text
                Case "VENTA POR DIA"

                Case "VENTA POR MES"

                Case "VENTA POR VENDEDOR"


                    Dim datos As List(Of item) = item.Instance()
                    datos.Clear()

                    Dim f As New FormFiltroPeriodoVendedor()
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog(Me)
                    If f.Tag IsNot Nothing Then
                        Dim periodoSel = CType(f.Tag, DateTime?)
                        Dim periodoString = GetPeriodo(periodoSel, True)

                        If datos.Count > 0 Then


                            Select Case datos(0).tipo
                                Case "PERIODO"
                                    SalesBySeller(datos(0).tipo, GEstableciento.IdEstablecimiento, periodoString, DateTime.Now, datos(0).idEntidad, datos(0).descripcion)
                                Case "DIA"
                                    SalesBySeller(datos(0).tipo, GEstableciento.IdEstablecimiento, periodoString, datos(0).fechaActualizacion, datos(0).idEntidad, datos(0).descripcion)
                            End Select
                        End If
                    End If

                Case "VENTA POR ARTICULOS"

                Case "RENTABILIDAD"


                    OcultarTodos()
                    If UCRentabilidad IsNot Nothing Then



                        UCRentabilidad.Visible = True
                        UCRentabilidad.BringToFront()
                        UCRentabilidad.Show()
                    Else
                        UCRentabilidad = New UCRentabilidad With {.Dock = DockStyle.Fill, .Visible = False}
                        PanelBody.Controls.Add(UCRentabilidad)



                        UCRentabilidad.Visible = True
                        UCRentabilidad.BringToFront()
                        UCRentabilidad.Show()
                    End If

            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnImportarExcel_Click(sender As Object, e As EventArgs) Handles btnImportarExcel.Click
        Try


            If UCSalesBySeller IsNot Nothing Then
                Dim converter As New GroupingGridExcelConverterControl

                Dim saveFileDialog As New SaveFileDialog()
                saveFileDialog.Filter = "Files(*.xls)|*.xls"
                saveFileDialog.DefaultExt = ".xls"


                If saveFileDialog.ShowDialog() = DialogResult.OK Then
                    'If radioButton1.Checked Then
                    converter.GroupingGridToExcel(UCSalesBySeller.DgvComprobantes, saveFileDialog.FileName, Syncfusion.GridExcelConverter.ConverterOptions.Visible)
                    'ElseIf radioButton2.Checked Then
                    '    converter.GroupingGridToExcel(Me.GridGroupingControl1, saveFileDialog.FileName, Syncfusion.GridExcelConverter.ConverterOptions.[Default])
                    'End If

                    If MessageBox.Show("Exportar Registro de Ventas a un archivo excel ahora?", "Exportar a Excel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        Dim proc As New Process()
                        proc.StartInfo.FileName = saveFileDialog.FileName
                        proc.Start()
                    End If
                End If


            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
