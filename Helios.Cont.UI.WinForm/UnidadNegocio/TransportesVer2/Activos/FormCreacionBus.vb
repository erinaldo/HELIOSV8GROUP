Public Class FormCreacionBus


    Private Sub contextMenuStrip_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)

        Try
            Dim ASIENTO = CType(sender.TAG, String)

            If (e.ClickedItem.Text = "1") Then
                ASIENTO = "B"
                MessageBox.Show("DEBE INGRESRA 1")
                Exit Sub
            ElseIf (e.ClickedItem.Text = "2") Then
                ASIENTO = "C"
                MessageBox.Show("DEBE INGRESRA 2")
                Exit Sub
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim CONTEO As Integer

        For index As Integer = 1 To 3
            Dim b As New Button
            b.ContextMenuStrip = ContextMenuStrip1
            b.Location = New System.Drawing.Point(333, 70 + CONTEO)
            b.Text = "PRRESIONA"
            b.TextAlign = ContentAlignment.MiddleLeft
            b.TabIndex = 0

            b.Size = New System.Drawing.Size(45, 45)
            b.Font = New Font(" Arial Narrow", 10, FontStyle.Bold)
            b.Tag = "B"

            b.BackgroundImage = My.Resources.usadoTrans
            b.BackgroundImage.Tag = 1
            b.BackgroundImageLayout = ImageLayout.Stretch
            b.Name = 0

            AddHandler b.ContextMenuStrip.ItemClicked, AddressOf contextMenuStrip_ItemClicked
            FlowLayoutPanel1.Controls.Add(b)
            CONTEO = CONTEO + 50
        Next






    End Sub
End Class
