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

Public Class FrmNuevaTipoServicioInfraDet
    Inherits frmMaster

    Public TipoServicioID As Integer

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        txtNumero.Visible = True
    End Sub

    Public Sub New(padreID As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        TipoServicioID = padreID
    End Sub

    Private Sub Guardar()
        Try
            If (txtDescripcion.Text.Length > 0) Then

                'Dim tipoServicioInfraEstructuraDetBE As New tipoServicioInfraEstructuraDet
                Dim tipoServicioInfraEstructuraDetSA As New tipoServicioInfraestructuraDetSA

                'tipoServicioInfraEstructuraDetBE.[idTipoServicio] = TipoServicioID
                ''tipoServicioInfraEstructuraDetBE.[secuencia] = GEstableciento.IdEstablecimiento
                'tipoServicioInfraEstructuraDetBE.[descripcion] = txtDescripcion.Text
                'tipoServicioInfraEstructuraDetBE.[numero] = 1
                'tipoServicioInfraEstructuraDetBE.[tipo] = Nothing
                'tipoServicioInfraEstructuraDetBE.[uso] = Nothing
                'tipoServicioInfraEstructuraDetBE.[estado] = "A"
                'tipoServicioInfraEstructuraDetBE.[glosatio] = "Detalle de la Sub Categoria"
                'tipoServicioInfraEstructuraDetBE.[usuarioActualizacion] = usuario.IDUsuario
                'tipoServicioInfraEstructuraDetBE.[fechaActualizacion] = Date.Now

                'Dim codx = tipoServicioInfraEstructuraDetSA.SavetipoServicioInfraestructuraDet(tipoServicioInfraEstructuraDetBE)

                'Dim infraestructura As New infraestructura
                'infraestructura.idInfraestructura = codx
                'infraestructura.nombre = txtDescripcion.Text
                'Me.Tag = infraestructura
                'Dispose()
            Else
                MessageBox.Show("Debe ingresar una descripción!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CargarTipoServicio(ID As Integer)
        Try
            'If (txtDescripcion.Text.Length > 0) Then

            '    Dim tipoServicioInfraEstructuraDetBE As New tipoServicioInfraEstructuraDet
            '    Dim tipoServicioInfraEstructuraDetSA As New tipoServicioInfraestructuraDetSA

            '    tipoServicioInfraEstructuraDetBE.secuencia = ID

            '    Dim codx = tipoServicioInfraEstructuraDetSA.GetUbicartipoServicioInfraestructuraDetXID(tipoServicioInfraEstructuraDetBE)

            '    If (Not IsNothing(codx)) Then
            '        txtDescripcion.Text = codx.descripcion
            '        txtDescripcion.Tag = codx.secuencia
            '        txtNumero.Text = codx.numero
            '    End If

            'Else
            '    MessageBox.Show("Debe ingresar una descripción!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub RoundButton21_Click(sender As Object, e As EventArgs) Handles RoundButton21.Click
        Guardar()
    End Sub

    Private Sub RoundButton22_Click(sender As Object, e As EventArgs) Handles RoundButton22.Click
        Dispose()
    End Sub
End Class