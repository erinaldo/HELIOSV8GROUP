Public Class UCReportesLogistica
#Region "Attributes"
    'Private UCResumenVentas As UCResumenVentas
    'Private UCFlujoCajaGeneral As UCFlujoCajaGeneral
    Public UCReporteCompras As UCReporteCompras
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UCReporteCompras = New UCReporteCompras With {.Dock = DockStyle.Fill}
        'UCReporteCompras.GetCombos()
        PanelBody.Controls.Add(UCReporteCompras)
    End Sub
#End Region
End Class
