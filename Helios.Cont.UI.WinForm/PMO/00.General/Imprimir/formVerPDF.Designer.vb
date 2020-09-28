<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formVerPDF
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim PdfViewerPrinterSettings1 As Syncfusion.Windows.PdfViewer.PdfViewerPrinterSettings = New Syncfusion.Windows.PdfViewer.PdfViewerPrinterSettings()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formVerPDF))
        Dim TextSearchSettings1 As Syncfusion.Windows.Forms.PdfViewer.TextSearchSettings = New Syncfusion.Windows.Forms.PdfViewer.TextSearchSettings()
        Me.pdfViewerControl1 = New Syncfusion.Windows.Forms.PdfViewer.PdfViewerControl()
        Me.SuspendLayout()
        '
        'pdfViewerControl1
        '
        Me.pdfViewerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pdfViewerControl1.EnableContextMenu = True
        Me.pdfViewerControl1.EnableNotificationBar = True
        Me.pdfViewerControl1.HorizontalScrollOffset = 0
        Me.pdfViewerControl1.IsBookmarkEnabled = True
        Me.pdfViewerControl1.Location = New System.Drawing.Point(0, 0)
        Me.pdfViewerControl1.Name = "pdfViewerControl1"
        Me.pdfViewerControl1.PageBorderThickness = 1
        PdfViewerPrinterSettings1.PageOrientation = Syncfusion.Windows.PdfViewer.PdfViewerPrintOrientation.[Auto]
        PdfViewerPrinterSettings1.PageSize = Syncfusion.Windows.PdfViewer.PdfViewerPrintSize.ActualSize
        PdfViewerPrinterSettings1.PrintLocation = CType(resources.GetObject("PdfViewerPrinterSettings1.PrintLocation"), System.Drawing.PointF)
        Me.pdfViewerControl1.PrinterSettings = PdfViewerPrinterSettings1
        Me.pdfViewerControl1.ReferencePath = Nothing
        Me.pdfViewerControl1.ScrollDisplacementValue = 0
        Me.pdfViewerControl1.ShowHorizontalScrollBar = True
        Me.pdfViewerControl1.ShowToolBar = True
        Me.pdfViewerControl1.ShowVerticalScrollBar = True
        Me.pdfViewerControl1.Size = New System.Drawing.Size(991, 670)
        Me.pdfViewerControl1.SpaceBetweenPages = 8
        Me.pdfViewerControl1.TabIndex = 4
        Me.pdfViewerControl1.Text = "pdfViewerControl1"
        TextSearchSettings1.CurrentInstanceColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(64, Byte), Integer))
        TextSearchSettings1.HighlightAllInstance = True
        TextSearchSettings1.OtherInstanceColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.pdfViewerControl1.TextSearchSettings = TextSearchSettings1
        Me.pdfViewerControl1.VerticalScrollOffset = 0
        Me.pdfViewerControl1.VisualStyle = Syncfusion.Windows.Forms.PdfViewer.VisualStyle.[Default]
        Me.pdfViewerControl1.ZoomMode = Syncfusion.Windows.Forms.PdfViewer.ZoomMode.[Default]
        '
        'formVerPDF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(991, 670)
        Me.Controls.Add(Me.pdfViewerControl1)
        Me.Name = "formVerPDF"
        Me.Text = "Ver PDF"
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents pdfViewerControl1 As Syncfusion.Windows.Forms.PdfViewer.PdfViewerControl
End Class
