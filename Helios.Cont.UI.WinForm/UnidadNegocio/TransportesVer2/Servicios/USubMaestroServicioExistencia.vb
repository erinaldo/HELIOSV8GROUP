Imports System.IO
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class USubMaestroServicioExistencia

#Region "Attributes"
    Public Property MANIPULACION As String

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
        Dim servicioSA As New servicioSA
        Dim servicioBE As New servicio
        Dim listaservicio As New List(Of servicio)

        servicioBE.idEmpresa = Gempresas.IdEmpresaRuc

        listaservicio = servicioSA.GetListaServicios(servicioBE)

        dgvPedidoDetalle.Table.Records.DeleteAll()

        With dt.Columns
            .Add("ID")
            .Add("descripcion")
            .Add("estado")
        End With

        For Each i In listaservicio

            dt.Rows.Add(i.idServicio,
                    i.descripcion,
               i.estado
                    )

        Next
        dgvPedidoDetalle.DataSource = dt

    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        Dim f As New formNuevoServicioTransporte
        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        GetDocumentoVentaID()
    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click
        GetDocumentoVentaID()
    End Sub

    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton3.Click
        Try
            If (Not IsNothing(dgvPedidoDetalle.Table.CurrentRecord)) Then
                Dim f As New formNuevoServicioTransporte
                f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                f.txtidservicio.Text = dgvPedidoDetalle.Table.CurrentRecord.GetValue("ID")
                f.txtServicioNew.Text = dgvPedidoDetalle.Table.CurrentRecord.GetValue("descripcion")
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

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
        Try
            If (Not IsNothing(dgvPedidoDetalle.Table.CurrentRecord)) Then
                Dim servicioSA As New servicioSA
                Dim servicioBE As New servicio

                servicioBE.idServicio = dgvPedidoDetalle.Table.CurrentRecord.GetValue("ID")
                servicioBE.idEmpresa = Gempresas.IdEmpresaRuc


                If (dgvPedidoDetalle.Table.CurrentRecord.GetValue("estado") = "A") Then
                    servicioBE.estado = "I"
                ElseIf (dgvPedidoDetalle.Table.CurrentRecord.GetValue("estado") = "I") Then
                    servicioBE.estado = "A"
                End If
                servicioBE.tipo = "ESTADO"

                servicioSA.EditarServicioPadre(servicioBE)

                GetDocumentoVentaID()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

#End Region

#Region "Events"


#End Region

End Class
