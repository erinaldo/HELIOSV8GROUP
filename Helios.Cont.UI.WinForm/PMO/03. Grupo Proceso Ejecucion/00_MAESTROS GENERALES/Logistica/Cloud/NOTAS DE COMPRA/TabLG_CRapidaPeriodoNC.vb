Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.GroupingGridExcelConverter
Imports Helios.Cont.Business.Entity
Public Class TabLG_CRapidaPeriodoNC
#Region "Variables"
    Public Property compraSA As New DocumentoCompraSA
    Public Property FormMDI As FormMantenimientoComprasRapidas
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        General.FormatoGridAvanzado(GridStatus, True, False, 10.0F, SelectionMode.One)
        GetCombos()
    End Sub
#End Region

#Region "Methods"
    Private Sub GetCombos()
        Dim empresaAnioSA As New empresaPeriodoSA
        cboAnio.DisplayMember = "periodo"
        cboAnio.ValueMember = "periodo"
        cboAnio.DataSource = empresaAnioSA.GetListar_empresaPeriodo(New empresaPeriodo With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento})
        cboAnio.Text = DateTime.Now.Year

        cboMes.DisplayMember = "Mes"
        cboMes.ValueMember = "Codigo"
        cboMes.DataSource = ListaDeMeses()
        cboMes.SelectedValue = String.Format("{0:00}", DateTime.Now.Month)
    End Sub
#End Region

#Region "Events"
    Private Sub ButtonAdv19_Click(sender As Object, e As EventArgs) Handles ButtonAdv19.Click
        GetComprasRepidas()
    End Sub

    Private Sub GetComprasRepidas()
        Dim dt As New DataTable
        dt.Columns.Add("idDocumento")
        dt.Columns.Add("tipoCompra")
        dt.Columns.Add("fechaDoc")
        dt.Columns.Add("tipoDoc")
        dt.Columns.Add("serie")
        dt.Columns.Add("numeroDoc")
        dt.Columns.Add("iditem")
        dt.Columns.Add("item")
        dt.Columns.Add("unidad")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("usuarioActualizacion")
        dt.Columns.Add("estado")
        dt.Columns.Add("secuencia")

        Dim estado As String = String.Empty
        Dim periodo = cboMes.SelectedValue & "/" & cboAnio.Text
        For Each i In compraSA.GetEscaneadasNotaComprasseriodo(New Business.Entity.documentocompra With
                                                       {
                                                       .fechaDoc = GetPeriodoConvertirToDate(periodo),
                                                       .idEmpresa = General.Gempresas.IdEmpresaRuc,
                                                       .idCentroCosto = General.GEstableciento.IdEstablecimiento,
                                                       .tipoCompra = General.TIPO_COMPRA.NOTA_DE_COMPRA,
                                                       .aprobado = "N"
                                                       })

            Select Case i.aprobado
                Case "N"
                    estado = "Pendiente"
                Case "R"
                    estado = "Rechazado"
                Case "S"
                    estado = "Revisado"
                Case Else
                    estado = "Pendiente"
            End Select

            dt.Rows.Add(
                i.idDocumento,
                i.tipoCompra,
                i.fechaDoc,
                i.tipoDoc,
                i.serie,
                i.numeroDoc,
                String.Empty,
                i.nombreProveedor,
                String.Empty,
                String.Empty,
                "NN",
                estado,
                String.Empty)
        Next
        GridStatus.DataSource = dt
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Dim converter As New GroupingGridExcelConverterControl

        Dim saveFileDialog As New SaveFileDialog()
        saveFileDialog.Filter = "Files(*.xls)|*.xls"
        saveFileDialog.DefaultExt = ".xls"


        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            'If radioButton1.Checked Then
            converter.GroupingGridToExcel(Me.GridStatus, saveFileDialog.FileName, Syncfusion.GridExcelConverter.ConverterOptions.Visible)
            'ElseIf radioButton2.Checked Then
            '    converter.GroupingGridToExcel(Me.GridGroupingControl1, saveFileDialog.FileName, Syncfusion.GridExcelConverter.ConverterOptions.[Default])
            'End If

            If MessageBox.Show("Desea exportar información?", "Exportar a Excel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim proc As New Process()
                proc.StartInfo.FileName = saveFileDialog.FileName
                proc.Start()
            End If
        End If

    End Sub
#End Region
End Class
