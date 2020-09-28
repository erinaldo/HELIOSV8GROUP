Imports System.IO
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class Tab_GestionServicio

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
        Dim ServicioInfraestructuraSA As New ServicioInfraestructuraSA
        Dim listaCategoria As New List(Of servicioInfraestructura)


        listaCategoria = ServicioInfraestructuraSA.GellAllServiciosInfra()

        dgvPedidoDetalle.Table.Records.DeleteAll()

        With dt.Columns
            .Add("ID")
            .Add("descripcion")
            .Add("estado")
        End With

        For Each i In listaCategoria

            dt.Rows.Add(i.idServicioInfraestructura,
                    i.descripcionServicio,
                    "HABILITADO"
                   )

        Next
        dgvPedidoDetalle.DataSource = dt

    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        Dim f As New FormCrearServcioInfra
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        GetDocumentoVentaID()
    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click
        Try
            Dim R As Record
            R = dgvPedidoDetalle.Table.CurrentRecord

            If (Not IsNothing(R)) Then
                Dim f As New FormDetalleServicioInfra(R.GetValue("ID"))
                f.txtDescripcion.Tag = R.GetValue("ID")
                f.txtDescripcion.Text = R.GetValue("descripcion")
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub BunifuFlatButton5_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton5.Click
        GetDocumentoVentaID()
    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click

    End Sub

#End Region

#Region "Events"


#End Region

End Class
