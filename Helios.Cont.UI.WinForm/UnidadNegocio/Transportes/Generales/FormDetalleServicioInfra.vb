Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping

Public Class FormDetalleServicioInfra
#Region "ATTRIBUTES"
    Public Property ServicioInfraestructuraSA As New ServicioInfraestructuraSA

    Public Property Manipulation As Entity.EntityState

#End Region

#Region "Constructors"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        txtFecha.Value = Date.Now

    End Sub

    Public Sub New(idServicio As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        txtFecha.Value = Date.Now

        GetDocumentoVentaID(idServicio)
    End Sub

#End Region

#Region "Methods"

    Private Sub GrabarServicio()
        Dim f As New FormCrearServcioInfraDet
        f.ID = txtDescripcion.Tag
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        GetDocumentoVentaID(txtDescripcion.Tag)
    End Sub

    Public Sub GetDocumentoVentaID(idServicio As Integer)
        Dim dt As New DataTable
        Dim ServicioInfraestructuraSA As New ServicioInfraestructuraDetSA
        Dim listaCategoria As New List(Of servicioInfraestructuraDet)


        listaCategoria = ServicioInfraestructuraSA.GellAllServiciosInfraDet(idServicio)

        dgvPedidoDetalle.Table.Records.DeleteAll()

        With dt.Columns
            .Add("ID")
            .Add("descripcion")
            .Add("estado")
        End With

        For Each i In listaCategoria

            dt.Rows.Add(i.idServicioInfraestructura,
                    i.detalleServicio,
                    "HABILITADO"
                   )

        Next
        dgvPedidoDetalle.DataSource = dt

    End Sub

#End Region

#Region "Events"
    Private Sub RoundButton21_Click(sender As Object, e As EventArgs) Handles RoundButton21.Click
        GrabarServicio()
    End Sub

    Private Sub RoundButton22_Click(sender As Object, e As EventArgs) Handles RoundButton22.Click
        Dispose()
    End Sub

    Private Sub RoundButton23_Click(sender As Object, e As EventArgs) Handles RoundButton23.Click
        Try

            Dim Rec As Record
            Rec = dgvPedidoDetalle.Table.CurrentRecord

            If (Not IsNothing(Rec)) Then
                Dim f As New FormCrearServcioInfraDet(txtDescripcion.Tag, Rec.GetValue("ID"))
                f.ID = txtDescripcion.Tag
                f.txtDescripcion.Tag = Rec.GetValue("ID")
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
                GetDocumentoVentaID(txtDescripcion.Tag)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

#End Region
End Class