Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports System.Drawing
Imports System.Drawing.Drawing2D
Public Class frmNuevaClasificacionInfraestructura

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub

    Public Sub New(idCategoria As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        UbicarCategoria(idCategoria)
    End Sub


#Region "metodos"

    Public Sub GrabarClasificacion()
        Dim categoriaInfraestructuraSA As New categoriaInfraestructuraSA
        Dim categoriaInfraestructura As New categoriaInfraestructura

        Dim datos As List(Of categoriaInfraestructura) = categoriaInfraestructura.Instance()
        datos.Clear()
        Dim c As New categoriaInfraestructura

        Try
            With categoriaInfraestructura
                '.[idCategoria] = TipoGrupoArticulo.CategoriaGeneral
                .[idEmpresa] = Gempresas.IdEmpresaRuc
                .[idEstablecimiento] = GEstableciento.IdEstablecimiento
                .[descripcionInfraestructura] = txtDescripcion.Text.Trim
                .[estado] = "A"
                .[usuarioActualizacion] = usuario.IDUsuario
                .[fechaActualizacion] = DateTime.Now

            End With

            Dim codx As Integer = categoriaInfraestructuraSA.SaveCategoriaInfraestructura(categoriaInfraestructura)
            'lstCategoria.Items.Add(New Categoria(txtNewClasificacion.Text.Trim, codx, 0, 0, 0))
            'Me.txtCategoria.Tag = CStr(codx)
            'txtCategoria.Text = txtNewClasificacion.Text.Trim
            c.idCategoria = codx
            c.descripcionInfraestructura = txtDescripcion.Text
            datos.Add(c)
            'clasificacion()
            Dispose()
            'ListadoProductosPorCategoriaTipoExistencia(codx, cboTipoExistencia.SelectedValue, 0, 0, 0)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub UbicarCategoria(idCategoria As Integer)
        Dim categoriaInfraestructuraBE As New categoriaInfraestructura
        Dim categoriaInfraestructuraSA As New categoriaInfraestructuraSA
        Dim objCategoriaInfraestructura As New categoriaInfraestructura

        categoriaInfraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
        categoriaInfraestructuraBE.idEstablecimiento = GEstableciento.IdEstablecimiento
        categoriaInfraestructuraBE.idCategoria = idCategoria

        objCategoriaInfraestructura = categoriaInfraestructuraSA.GetUbicarCategoriaInfraestructuraXID(categoriaInfraestructuraBE)

        If (Not IsNothing(objCategoriaInfraestructura)) Then
            txtDescripcion.Text = objCategoriaInfraestructura.descripcionInfraestructura
            txtDescripcion.Tag = objCategoriaInfraestructura.idCategoria
        End If

    End Sub

#End Region

    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        If txtDescripcion.Text.Trim.Length > 0 Then
            GrabarClasificacion()
        Else
            MessageBox.Show("Debe indicar el nombre de la categoría!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub frmNuevaClasificacion_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Dispose()
    End Sub
End Class