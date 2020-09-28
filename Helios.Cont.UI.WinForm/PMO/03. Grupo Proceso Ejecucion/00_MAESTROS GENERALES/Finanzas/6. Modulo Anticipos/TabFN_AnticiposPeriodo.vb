Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.GroupingGridExcelConverter
Public Class TabFN_AnticiposPeriodo

#Region "Attributes"

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

    Private Sub GetAnticiposPeriodo(fecha As Date)
        Dim anticipoSA As New documentoAnticipoSA
        Dim dt As New DataTable
        dt.Columns.Add("idDocumento")
        dt.Columns.Add("codigo")
        dt.Columns.Add("fecha")
        dt.Columns.Add("tipo")
        dt.Columns.Add("entidad")
        dt.Columns.Add("nrodoc")
        dt.Columns.Add("tipodeposito")
        dt.Columns.Add("monto")
        dt.Columns.Add("idEntidad")

        For Each i In anticipoSA.GetAnticiposPeriodo(New Business.Entity.documentoAnticipo With
                                                       {
                                                       .fechaDoc = fecha,
                                                       .idEmpresa = Gempresas.IdEmpresaRuc,
                                                       .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                       .tipoAnticipo = "AR"
                                                       })

            dt.Rows.Add(
                i.idDocumento,
                i.numeroDoc,
                i.fechaDoc,
                i.tipoAnticipo,
                i.CustomEntidad.nombreCompleto,
                i.CustomEntidad.nrodoc,
                i.formaPago,
                i.importeMN,
                i.CustomEntidad.idEntidad)
        Next
        GridStatus.DataSource = dt
    End Sub

#End Region

#Region "Events"
    Private Sub ButtonAdv19_Click(sender As Object, e As EventArgs) Handles ButtonAdv19.Click
        Dim periodo = $"{cboMes.SelectedValue.ToString}/{cboAnio.Text}"
        Dim fecha = GetPeriodoConvertirToDate(periodo)
        GetAnticiposPeriodo(fecha)
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

            If MessageBox.Show("Desea exportar la información?", "Exportar a Excel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim proc As New Process()
                proc.StartInfo.FileName = saveFileDialog.FileName
                proc.Start()
            End If
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim r As Record = GridStatus.Table.CurrentRecord
        'If r IsNot Nothing Then
        '    Dim ent As New entidad With
        '        {
        '        .idEntidad = Integer.Parse(r.GetValue("idEntidad")),
        '        .nombreCompleto = r.GetValue("entidad"),
        '        .nrodoc = r.GetValue("nrodoc")
        '    }
        '    Dim idDocumento As Integer = Integer.Parse(r.GetValue("idDocumento"))
        '    Dim f As New FormCrearNotaCreditoAnticipo(idDocumento, ent, Form)
        '    f.StartPosition = FormStartPosition.CenterParent
        '    f.ShowDialog(Me)
        'End If
    End Sub
#End Region

End Class
