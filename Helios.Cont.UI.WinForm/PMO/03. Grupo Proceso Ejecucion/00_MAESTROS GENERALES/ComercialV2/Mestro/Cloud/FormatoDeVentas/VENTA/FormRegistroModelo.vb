Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class FormRegistroModelo

#Region "Metodos"

    Public Sub GrabarModelo()
        Dim itemSA As New caracteristicaItemSA
        Dim caracteristicaItem As New caracteristicaItem

        Dim datos As List(Of item) = item.Instance()
        datos.Clear()
        Dim c As New item

        Try
            With caracteristicaItem
                .idSubClasificacion = CInt(lbliDSubClasificacion.Text)
                .tipo = "MO"
                .descripcion = txtDescripcion.Text
            End With

            Dim codx = itemSA.InsertCabezera(caracteristicaItem)
            'lstCategoria.Items.Add(New Categoria(txtNewClasificacion.Text.Trim, codx, 0, 0, 0))
            'Me.txtCategoria.Tag = CStr(codx)
            'txtCategoria.Text = txtNewClasificacion.Text.Trim
            c.idItem = codx.idCaracteristica
            c.descripcion = txtDescripcion.Text
            datos.Add(c)
            'clasificacion()
            Dispose()
            'ListadoProductosPorCategoriaTipoExistencia(codx, cboTipoExistencia.SelectedValue, 0, 0, 0)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region



    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        If txtDescripcion.Text.Trim.Length > 0 Then
            GrabarModelo()
        Else
            MessageBox.Show("Debe indicar el nombre de la categoría!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class