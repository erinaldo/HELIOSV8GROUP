Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Syncfusion.Windows.Forms
Public Class formVerPDF

    Public Sub New(ubicaionPDF As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        mostrarPDF(ubicaionPDF)
    End Sub


    Private Sub mostrarPDF(ubicacionPDF As String)
        pdfViewerControl1.Load(ubicacionPDF)
    End Sub


End Class