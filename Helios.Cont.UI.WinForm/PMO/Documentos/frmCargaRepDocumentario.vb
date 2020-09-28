Imports System.IO

Public Class frmCargaRepDocumentario
    Inherits frmBase

    Private Sub btnExplorar_Click(sender As System.Object, e As System.EventArgs) Handles btnExplorar.Click
        Dim rutaArchivo As String
        OpenFileDialog1.FileName = String.Empty
        OpenFileDialog1.Filter = "Hojas de cálculo(*.xls,*.xlsx)|*.xls;*.xlsx" +
                                "|Procesador de texto(*.doc,*.docx)|*.doc;*docx" +
                                "|Presentaciones(*.ppt,*.pptx)|*.ppt;*.pptx" +
                                "|Pdf (*.pdf)|*.pdf" +
                                "|Texto plano (*.txt,*.xml.*.csv)|*.txt;*.xml;*.csv"
        Dim result = OpenFileDialog1.ShowDialog
        If result = Windows.Forms.DialogResult.OK Then
            rutaArchivo = OpenFileDialog1.FileName
            txtArchivo.Text = Path.GetFileName(rutaArchivo)
            'txtArchivo.Controls.Add()

            txtComentario.Focus()

        End If
    End Sub

    Public Overrides Function ValidaDatosGrabar() As Boolean
        ValidaDatosGrabar = True
        If String.IsNullOrWhiteSpace(txtArchivo.Text) Then
            btnExplorar.Focus()
            BarraEstado_Notificacion(TipoMensaje.TIPO_WARNING, "Falta seleccionar un archivo")
            Return False
        End If
        'If String.IsNullOrWhiteSpace(txtEtiqueta.Text) Then
        '    txtEtiqueta.Focus()
        '    BarraEstado_Notificacion(TipoMensaje.TIPO_WARNING, "Falta ingresar la etiqueta para el archivo")
        '    Return False
        'End If
        'If String.IsNullOrWhiteSpace(txtComentario.Text) Then
        '    txtComentario.Focus()
        '    BarraEstado_Notificacion(TipoMensaje.TIPO_WARNING, "Falta ingresar el comentario para el archivo")
        '    Return False
        'End If
    End Function

    Public Overrides Sub Grabar()

    End Sub

    Private Sub scPrincipal_Panel1_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles scPrincipal.Panel1.Paint

    End Sub
End Class