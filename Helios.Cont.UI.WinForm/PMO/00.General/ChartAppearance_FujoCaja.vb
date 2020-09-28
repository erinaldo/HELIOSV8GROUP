Imports Syncfusion.Drawing
Imports Syncfusion.Windows.Forms.Chart
Imports System.Drawing

Public NotInheritable Class ChartAppearance_FujoCaja

    Public Sub New()

    End Sub

    Public Shared Sub ApplyChartStyles(chart As ChartControl)
        '#Region "ApplyCustomPalette"
        '  chart.Skins = Skins.Metro
        '#End Region

        '#Region "Chart Appearance Customization"

        chart.BorderAppearance.SkinStyle = Syncfusion.Windows.Forms.Chart.ChartBorderSkinStyle.None
        chart.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias
        chart.ChartArea.PrimaryXAxis.HidePartialLabels = True
        chart.ElementsSpacing = 0

        '#End Region

        '#Region "Axes Customization"
        chart.PrimaryXAxis.ValueType = ChartValueType.DateTime
        chart.PrimaryXAxis.RangeType = ChartAxisRangeType.[Set]
        chart.PrimaryXAxis.Range = New MinMaxInfo(0, 13, 1)
        chart.PrimaryXAxis.DateTimeFormat = "MMM"

        chart.Text = " "
        'chart.PrimaryYAxis.Title = "Nro. de transacciones"
        chart.PrimaryXAxis.Title = "Revisión mensual"

        '#End Region
        'chart.Series(0).Style.Font = New Font("Segoe UI", 10)
        '  chart.Series(0).Style.TextOffset = 5.0F
        chart.Series(0).Style.TextColor = Color.DimGray
        chart.Series(0).Style.Interior = New BrushInfo(Color.FromArgb(220, 108, 141))

        chart.Series(1).Style.TextColor = Color.DimGray
        chart.Series(1).Style.Interior = New BrushInfo(Color.FromArgb(46, 198, 217))

        'chart.Series(2).Style.TextColor = Color.DimGray
        'chart.Series(2).Style.Interior = New BrushInfo(Color.FromArgb(48, 182, 125))
        'chart.Series.Item.Styles.Font = New Font("Segoe UI", 10.25F)

        '#Region "Legend Customization"
        For i As Integer = 0 To chart.Legend.Items.Length - 1
            chart.Legend.Items(i).Spacing = 2
            chart.Legend.Items(i).Symbol.Color = Color.YellowGreen
            chart.Legend.ItemsSize = New Size(13, 13)
            chart.Legend.Items(i).TextAligment = VerticalAlignment.Bottom
            chart.Legend.Items(i).TextColor = Color.Black
            chart.Legend.BackColor = Color.Transparent
            chart.LegendsPlacement = ChartPlacement.Outside
            chart.LegendAlignment = ChartAlignment.Center
            chart.LegendPosition = ChartDock.Bottom
            chart.Legend.Font = New Font("Segoe UI", 8.25F)
        Next
        ' chart.Legend.BackInterior = New BrushInfo(GradientStyle.ForwardDiagonal, System.Drawing.Color.White, System.Drawing.Color.LightBlue)
        '#End Region
    End Sub

    Public Shared Sub ApplyChartStylesPie(chart As ChartControl)

        '#Region "ApplyCustomPalette"
        '  chart.Skins = Skins.Metro
        '#End Region

        '#Region "Chart Appearance Customization"

        chart.BorderAppearance.SkinStyle = Syncfusion.Windows.Forms.Chart.ChartBorderSkinStyle.None
        chart.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias
        chart.ElementsSpacing = 0
        chart.Series(0).ConfigItems.PieItem.HeightByAreaDepth = False
        chart.Series(0).ConfigItems.PieItem.HeightCoeficient = 0.1F
        chart.Tilt = 90
        '#End Region

        '#Region "Legend Customization"
        For i As Integer = 0 To chart.Legend.Items.Length - 1
            chart.Legend.Items(i).Spacing = 2
            chart.Legend.ItemsSize = New Size(13, 13)
            chart.Legend.Items(i).TextAligment = VerticalAlignment.Bottom
            chart.Legend.BackColor = Color.Transparent
            chart.LegendsPlacement = ChartPlacement.Outside
            chart.LegendAlignment = ChartAlignment.Center
            chart.LegendPosition = ChartDock.Bottom
            chart.Legend.Font = New Font("Segoe UI", 8.0F)
        Next
        '#End Region
    End Sub
End Class
