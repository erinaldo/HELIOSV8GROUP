Imports System.ComponentModel
Imports System.IO
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports System.Xml

Public Class frmCambiarMesa
    Inherits frmMaster

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub



    Public Sub cargarCombo()
        Dim distribucionInfraSa As New distribucionInfraestructuraSA
        Dim distribucionInfra As New List(Of distribucionInfraestructura)
        Dim distribucionInfraestructuraBE = New distribucionInfraestructura

        Dim estado As String = String.Empty
        estado = "A"

        distribucionInfraestructuraBE.tipo = "1"
        distribucionInfraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
        distribucionInfraestructuraBE.idEstablecimiento = GEstableciento.IdEstablecimiento
        distribucionInfraestructuraBE.tipo = "VPN"
        distribucionInfraestructuraBE.estado = "A"
        distribucionInfraestructuraBE.usuarioActualizacion = estado
        distribucionInfraestructuraBE.Categoria = 1

        distribucionInfra = (distribucionInfraSa.getInfraestructura(distribucionInfraestructuraBE))

        cboMesas.ValueMember = "idDistribucion"
        cboMesas.DisplayMember = "Categoria"
        cboMesas.DataSource = distribucionInfra

    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click
        Try
            If MessageBox.Show("¿Desea cambiar de mesa?", "Cambio de Mesa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                Dim distribucionInfraestructuraBE = New distribucionInfraestructura
                Dim documentoventaAbarrotesDetSA As New documentoVentaAbarrotesDetSA

                distribucionInfraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
                distribucionInfraestructuraBE.idEstablecimiento = GEstableciento.IdEstablecimiento
                distribucionInfraestructuraBE.idInfraestructura = txtInfraestructura.Tag
                distribucionInfraestructuraBE.InfraestructuraUpdate = cboMesas.SelectedValue
                distribucionInfraestructuraBE.estado = "A"
                distribucionInfraestructuraBE.Categoria = "P"

                documentoventaAbarrotesDetSA.updateMesa(distribucionInfraestructuraBE)
                Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click

    End Sub
End Class