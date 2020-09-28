Imports Syncfusion.Windows.Forms.Chart

Public Class ChartAppearancePie

    Public Shared Sub ApplyChartStyles(chart As ChartControl)

        '#Region "ApplyCustomPalette"
        chart.Skins = Skins.Metro
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
