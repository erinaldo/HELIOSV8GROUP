Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Drawing

Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping
Imports System.ComponentModel

Public Class formNuevoServicioTransporte

    Inherits frmMaster
    Public Property ManipulacionEstado() As String


    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

#Region "metodos"

    Public Sub GrabarServicioPadre()
        Dim objitem As New servicio
        Dim servicioSA As New servicioSA

        Try

            objitem = New servicio With {
            .[idItemServicio] = Nothing,
            .[idEmpresa] = Gempresas.IdEmpresaRuc,
            .[idEstablecimiento] = GEstableciento.IdEstablecimiento,
            .[idPadre] = Nothing,
            .[fecha] = Date.Now,
            .[descripcion] = txtidservicio.Text,
            .[unidadMedida] = "NIU",
            .[tipo] = "UNID",
            .[tipoExist] = "GS",
            .[tipoServicio] = Nothing,
            .[idProveedor] = Nothing,
            .[codigo] = Nothing,
            .[costo] = Nothing,
            .[valor] = Nothing,
            .[categoria] = Nothing,
            .[subCategoria] = Nothing,
            .[cuenta] = Nothing,
            .[cuentaH] = Nothing,
            .[cuentaDev] = Nothing,
            .[cuentaDevH] = Nothing,
            .[observaciones] = txtObservaciones.Text,
            .[estado] = "A",
            .[usuarioActualizacion] = "ADMINISTRADOR",
            .[fechaActualizacion] = Date.Now
            }

            servicioSA.GrabarServicioPadre(objitem)

            Dispose()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Public Sub EditarServicioPadre(idservicio As Integer)
        Dim objitem As New servicio
        Dim servicioSA As New servicioSA
        Try
            objitem.idServicio = txtidservicio.Text
            objitem.descripcion = txtServicioNew.Text
            objitem.observaciones = txtObservaciones.Text
            objitem.tipo = "DESCRIPCION"
            servicioSA.EditarServicioPadre(objitem)
            Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub




#End Region

    Private Sub FrmAddServicio_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub


    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        Me.Cursor = Cursors.WaitCursor

        If txtServicioNew.Text.Trim.Length > 0 Then

            If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
                GrabarServicioPadre()
            ElseIf ManipulacionEstado = ENTITY_ACTIONS.UPDATE Then
                'UpdateTipoCategoria()
            End If

        Else
            MessageBoxAdv.Show("Debe ingresar una descripción para el servicio padre!", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton3.Click
        Dispose()
    End Sub
End Class