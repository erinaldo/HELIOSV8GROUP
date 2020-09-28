Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' ListView1 = New ListView()
        ListView1.Width = 200
        ListView1.View = View.List

        ' Show item tooltips.
        ListView1.ShowItemToolTips = True

        ' Create items with a tooltip.
        Dim item1WithToolTip As New ListViewItem("Item with a tooltip")
        item1WithToolTip.ToolTipText = "This is the item tooltip."
        Dim item2WithToolTip As New ListViewItem("Second item with a tooltip")
        item2WithToolTip.ToolTipText = "A different tooltip for this item."

        ' Create an item without a tooltip.
        Dim itemWithoutToolTip As New ListViewItem("Item without tooltip.")

        ' Add the items to the ListView.
        ListView1.Items.AddRange(New ListViewItem() _
            {item1WithToolTip, item2WithToolTip, itemWithoutToolTip})

    End Sub
End Class