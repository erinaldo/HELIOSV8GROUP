Public Class FormTableroGeneralPOS
#Region "Attributes"
    Private UCResumenVentas As UCResumenVentas
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UCResumenVentas = New UCResumenVentas With {.Dock = DockStyle.Fill}
        PanelBody.Controls.Add(UCResumenVentas)
    End Sub
#End Region

#Region "MEthods"

#End Region

#Region "Events"

#End Region
End Class