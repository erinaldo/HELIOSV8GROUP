Imports Helios.General
Imports Helios.Planilla.WCFService.ServiceAccess

Public Class frmTrainersMaster
#Region "Attributes"
    Protected Friend personalSA As PersonalSA
#End Region

#Region "Constructors"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormatoGridAvanzado(dgvTrainers, True, False)
        GetTrainers()
    End Sub
#End Region

#Region "Methods"
    Sub GetTrainers()
        Dim dt As New DataTable
        personalSA = New PersonalSA
        Try
            dt.Columns.Add("idPersonal")
            dt.Columns.Add("appat")
            dt.Columns.Add("apmat")
            dt.Columns.Add("nombres")
            dt.Columns.Add("tipodoc")
            dt.Columns.Add("nrodoc")
            dt.Columns.Add("status")

            Dim lista = personalSA.PersonalSelxEstado(New Planilla.Business.Entity.Personal With {.Situacion = "a"})
            For Each i In lista.Where(Function(o) o.TipoTrabajador = TIPO_ENTIDAD.INSTRUCTOR_GIMNASIO)
                dt.Rows.Add(i.IDPersonal, i.ApellidoPaterno, i.ApellidoMaterno, i.Nombre, i.Tipodocumento, i.Numerodocumento, "A")
            Next
            dgvTrainers.DataSource = dt
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton13_Click(sender As Object, e As EventArgs) Handles ToolStripButton13.Click
        Dim f As New frmNuevoTrabajador(TIPO_ENTIDAD.INSTRUCTOR_GIMNASIO, Gempresas.IdEmpresaRuc)
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        GetTrainers()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Dim f As New frmActividadesGYM
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub
#End Region

#Region "Events"

#End Region
End Class