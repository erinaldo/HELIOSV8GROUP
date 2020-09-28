Imports System.IO
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class USubMaestroTipoServicio

#Region "Attributes"

    Public Property MANIPULACION As String
    Public Property ItemID As Integer

#End Region

#Region "Constructors"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        FormatoGridAvanzado(dgvPedidoDetalle, False, False)

    End Sub


#End Region

#Region "Metodos"

    Public Sub GetDocumentoVentaID()
        Dim dt As New DataTable
        Dim tipoServicioInfraestructuraSA As New tipoServicioInfraestructuraSA
        Dim tipoServicioInfraestructuraBE As New tipoServicioInfraestructura
        Dim listatipoServicioInfraestructura As New List(Of tipoServicioInfraestructura)

        tipoServicioInfraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
        tipoServicioInfraestructuraBE.idEstablecimiento = GEstableciento.IdEstablecimiento

        listatipoServicioInfraestructura = tipoServicioInfraestructuraSA.GetUbicartipoServicioInfra(tipoServicioInfraestructuraBE)

        dgvPedidoDetalle.Table.Records.DeleteAll()

        With dt.Columns
            .Add("ID")
            .Add("descripcion")
            .Add("estado")
        End With

        For Each i In listatipoServicioInfraestructura

            dt.Rows.Add(i.idTipoServicio,
                    i.descripcionTipoServicio,
                          i.estadoTipoServicio)

        Next
        dgvPedidoDetalle.DataSource = dt

    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        Dim f As New formNuevaTipoServicio
        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        GetDocumentoVentaID()
    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click
        GetDocumentoVentaID()
    End Sub

    Private Sub BunifuFlatButton5_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton5.Click
        Try
            If (Not IsNothing(dgvPedidoDetalle.Table.CurrentRecord)) Then
                Dim tipoServicioInfraestructuraSA As New tipoServicioInfraestructuraSA
                Dim tipoServicioInfraestructuraBE As New tipoServicioInfraestructura

                tipoServicioInfraestructuraBE.idTipoServicio = dgvPedidoDetalle.Table.CurrentRecord.GetValue("ID")
                tipoServicioInfraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc


                If (dgvPedidoDetalle.Table.CurrentRecord.GetValue("estado") = "A") Then
                    tipoServicioInfraestructuraBE.estadoTipoServicio = "I"
                ElseIf (dgvPedidoDetalle.Table.CurrentRecord.GetValue("estado") = "I") Then
                    tipoServicioInfraestructuraBE.estadoTipoServicio = "A"
                End If

                'tipoServicioInfraestructuraSA.EditarTipoServicioInfraestructuraXCategoria(tipoServicioInfraestructuraBE, "ESTADO")

                GetDocumentoVentaID()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton3.Click
        Try
            If (Not IsNothing(dgvPedidoDetalle.Table.CurrentRecord)) Then
                Dim f As New formNuevaTipoServicio
                f.lblCodigo.Text = dgvPedidoDetalle.Table.CurrentRecord.GetValue("ID")
                f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
                GetDocumentoVentaID()
            Else
                MessageBox.Show("DEBE SELECCIONAR UN CAMPO")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

#End Region

#Region "Events"


#End Region

End Class
