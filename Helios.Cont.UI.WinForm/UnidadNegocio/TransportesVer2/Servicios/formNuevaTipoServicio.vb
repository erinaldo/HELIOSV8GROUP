Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports Helios.Cont.WCFService.ServiceAccess

Public Class formNuevaTipoServicio

#Region "Variables"

    Public Property ManipulacionEstado() As String

#End Region


#Region "Constructor"

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

    End Sub

#End Region

#Region "metodos"

    Public Sub UpdateTipoCategoria()
        Dim itemSA As New tipoServicioInfraestructuraSA
        Dim item As New tipoServicioInfraestructura

        Try
            With item
                .idTipoServicio = lblCodigo.Text
                .descripcionTipoServicio = txtDescripcion.Text.Trim
            End With


            'itemSA.EditarTipoServicioInfraestructuraXCategoria(item, "DESCRIPCION")

            Dispose()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Public Sub GrabarClasificacion()
        Dim itemSA As New tipoServicioInfraestructuraSA
        Dim item As New tipoServicioInfraestructura


        Dim c As New item

        Try
            With item
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                .descripcionTipoServicio = txtDescripcion.Text.Trim
                .estadoTipoServicio = "A"
                .usuarioActualizacion = usuario.IDUsuario
                .fechaActualizacion = DateTime.Now
            End With

            Dim codx As Integer = itemSA.SaveTipoServicioInfraestructura(item)

            Dispose()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click

        Try

            If txtDescripcion.Text.Trim.Length > 0 Then

                If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
                    GrabarClasificacion()
                ElseIf ManipulacionEstado = ENTITY_ACTIONS.UPDATE Then
                    UpdateTipoCategoria()
                End If

            Else
                MessageBox.Show("Debe indicar el nombre de la categoría!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Dispose()
    End Sub


End Class