Imports System.Collections.Generic
Imports System.Drawing
Imports System.Text
Imports Syncfusion.Drawing
Imports Syncfusion.Windows.Forms.Chart

Public NotInheritable Class ChartAppearancePlan

    Private Sub New()

    End Sub
    Public Shared Sub ApplyChartStyles(chart As ChartControl)
        '#Region "ApplyCustomPalette"

        chart.Skins = Skins.Metro

        '#End Region

        '#Region "Chart Appearance Customization"

        chart.BorderAppearance.SkinStyle = Syncfusion.Windows.Forms.Chart.ChartBorderSkinStyle.None
        chart.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias
        chart.ChartArea.PrimaryXAxis.HidePartialLabels = True
        chart.ElementsSpacing = 5

        '#End Region

        '#Region "Axes Customization"


        chart.ChartArea.YAxesLayoutMode = Syncfusion.Windows.Forms.Chart.ChartAxesLayoutMode.SideBySide
        chart.ChartAreaMargins = New Syncfusion.Windows.Forms.Chart.ChartMargins(5, 5, 0, 4)
        chart.ChartArea.PrimaryXAxis.HidePartialLabels = True
        chart.PrimaryXAxis.OpposedPosition = True
        chart.ChartArea.XAxesLayoutMode = ChartAxesLayoutMode.Stacking
        chart.PrimaryYAxis.Inversed = True
        chart.PrimaryXAxis.OpposedPosition = False
        chart.PrimaryXAxis.LabelRotate = True
        chart.PrimaryXAxis.LabelRotateAngle = 60
        chart.Text = "Diagrama de Gantt"

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
            chart.Legend.Font = New Font("Segoe UI", 10.0F)
        Next
        '#End Region
    End Sub
End Class

