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

Public Class FrmNuevaInfraestructura
    Inherits frmMaster

    Dim IdPadre As Integer
    Public tipo As String
    Public Property ManipulacionEstado() As String

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        IdPadre = Nothing
    End Sub

    Public Sub New(padreID As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        IdPadre = padreID

    End Sub

    Public Sub New(padreID As Integer, Nombre As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        IdPadre = padreID
        txtServicioNew.Text = Nombre
    End Sub

    Private Sub Guardar()
        Try
            If (txtServicioNew.Text.Length > 0) Then


                Dim infraestructuraBE As New infraestructura
                Dim infraestructuraSA As New infraestructuraSA

                infraestructuraBE.[idEmpresa] = Gempresas.IdEmpresaRuc
                infraestructuraBE.[idEstablecimiento] = GEstableciento.IdEstablecimiento
                infraestructuraBE.[idPadre] = IdPadre
                infraestructuraBE.[nombre] = txtServicioNew.Text
                infraestructuraBE.[cantidad] = 0
                infraestructuraBE.[estado] = "A"
                infraestructuraBE.[tipo] = tipo
                infraestructuraBE.numero = 0
                infraestructuraBE.[usuarioActualizacion] = usuario.IDUsuario
                infraestructuraBE.[fechaActualizacion] = Date.Now

                Dim codx = infraestructuraSA.Saveinfraestructura(infraestructuraBE)

                Dim infraestructura As New infraestructura
                infraestructura.idInfraestructura = codx
                infraestructura.nombre = txtServicioNew.Text
                Me.Tag = infraestructura
                Dispose()
            Else
                MessageBox.Show("Debe ingresar una descripción!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Editar(idInfra As Integer)
        Try
            If (txtServicioNew.Text.Length > 0) Then

                Dim infraestructuraBE As New infraestructura
                Dim infraestructuraSA As New infraestructuraSA

                infraestructuraBE.[nombre] = txtServicioNew.Text
                infraestructuraBE.idInfraestructura = idInfra
                infraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc

                Dim codx = infraestructuraSA.EditarNombreInfra(infraestructuraBE)

                Dim infraestructura As New infraestructura
                infraestructura.idInfraestructura = codx.idInfraestructura
                infraestructura.nombre = txtServicioNew.Text
                Me.Tag = infraestructura
                Dispose()
            Else
                MessageBox.Show("Debe ingresar una descripción!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub RoundButton21_Click(sender As Object, e As EventArgs) Handles RoundButton21.Click
        If (ManipulacionEstado = ENTITY_ACTIONS.INSERT) Then
            Guardar()
        ElseIf (ManipulacionEstado = ENTITY_ACTIONS.UPDATE) Then
            Editar(IdPadre)
        End If

    End Sub

    Private Sub RoundButton22_Click(sender As Object, e As EventArgs) Handles RoundButton22.Click
        Dispose()
    End Sub
End Class