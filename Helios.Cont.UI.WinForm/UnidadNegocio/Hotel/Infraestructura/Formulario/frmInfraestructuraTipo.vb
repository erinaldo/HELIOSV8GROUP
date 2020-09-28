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

Public Class frmInfraestructuraTipo
    Inherits frmMaster

    Dim IdPadre As Integer
    Public tipo As String

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub Guardar()
        Try
            If (txtServicioNew.Text.Length > 0) Then

                Dim componenteBE As New componente
                Dim componenteSA As New componenteSA

                componenteBE.[idEmpresa] = Gempresas.IdEmpresaRuc
                componenteBE.[idEstablecimiento] = GEstableciento.IdEstablecimiento
                componenteBE.[idPadre] = IdPadre
                componenteBE.idItem = 0
                componenteBE.descripcionItem = txtServicioNew.Text
                componenteBE.[estado] = "A"
                componenteBE.[tipo] = "T"
                componenteBE.[usuarioActualizacion] = "MAYKOL"
                componenteBE.[fechaActualizacion] = Date.Now

                Dim codx = componenteSA.SaveComponente(componenteBE)

                Dim objComponenteBE As New componente
                objComponenteBE.idComponente = codx
                objComponenteBE.descripcionItem = txtServicioNew.Text
                Me.Tag = objComponenteBE
                Dispose()
            Else
                MessageBox.Show("Debe ingresar una descripción!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Dispose()
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Guardar()
    End Sub
End Class