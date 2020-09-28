Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Microsoft
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Tools
Imports Syncfusion.Drawing
Imports System.Threading

Public Class frmControlDetalleInfra
    Inherits frmMaster

    Public Property EstadoManipulacion() As String

    Public Alert As Alert

    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
    Private Thread As Thread

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'FormatoGridPequeño(dgvDetalleArea, False, 11.0F)
        'FormatoGridPequeño(dgAtendido, False, 11.0F)
        'CargarCombos()
        FormatoGridAvanzado(dgvInfraestructura, True, False)

        CargarCombos()


    End Sub

    Private Sub CargarCombos()
        Dim tipoServicioInfraestructuraBE As New tipoServicioInfraestructura
        Dim tipoServicioInfraestructuraSA As New tipoServicioInfraestructuraSA

        Dim listaTipoServicio As New List(Of tipoServicioInfraestructura)
        Try

            tipoServicioInfraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
            tipoServicioInfraestructuraBE.idEstablecimiento = GEstableciento.IdEstablecimiento

            listaTipoServicio = tipoServicioInfraestructuraSA.GetUbicartipoServicioInfraestructura(tipoServicioInfraestructuraBE)

            cboTipoComposicion.DataSource = Nothing

            If ((listaTipoServicio.Count > 0)) Then
                cboTipoComposicion.ValueMember = "idTipoServicio"
                cboTipoComposicion.DisplayMember = "descripcionTipoServicio"
                cboTipoComposicion.DataSource = listaTipoServicio
                cboTipoComposicion.SelectedValue = listaTipoServicio(0).idTipoServicio

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub GetListaInfraestructura(listaComponentes As List(Of distribucionInfraestructura))
        Try
            Dim dt As New DataTable
            With dt.Columns
                .Add("ID")
                .Add("Descripcion")
            End With

            For Each i In listaComponentes
                Dim dr As DataRow = dt.NewRow()
                dr(0) = i.idDistribucion
                dr(1) = i.descripcionDistribucion & " " & i.numeracion
                dt.Rows.Add(dr)
            Next

            dgvInfraestructura.DataSource = dt

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton3.Click
        Dim distribucionInfraBE As New distribucionInfraestructura
        Dim listadistribucionInfra As New List(Of distribucionInfraestructura)
        Dim distribucionInfraSA As New distribucionInfraestructuraSA

        Dim ConteoCheck As Integer = 0
        Try

            If MessageBox.Show("Desea realizar la categortia/subcategoria?", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                For Each infra In dgvInfraestructura.Table.Records

                    distribucionInfraBE = New distribucionInfraestructura
                    distribucionInfraBE.[idEmpresa] = Gempresas.IdEmpresaRuc
                    distribucionInfraBE.[idEstablecimiento] = GEstableciento.IdEstablecimiento
                    distribucionInfraBE.[idTipoServicio] = CInt(cboTipoComposicion.SelectedValue)
                    distribucionInfraBE.[idDistribucion] = CInt(infra.GetValue("ID"))


                    listadistribucionInfra.Add(distribucionInfraBE)

                Next

                distribucionInfraSA.updateCategoriaXDistribucion(listadistribucionInfra)
                Dispose()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs)
        Dispose()
    End Sub

    Private Sub CboTipoComposicion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoComposicion.SelectedIndexChanged

    End Sub
End Class