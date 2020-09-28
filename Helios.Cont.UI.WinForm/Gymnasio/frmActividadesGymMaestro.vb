Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping

Public Class frmActividadesGymMaestro
#Region "Attributes"
    Protected Friend frmActividadesGYM As frmActividadesGYM
    Protected Friend ActividadSA As actividadPersonalSA
    Public Property r As Record
#End Region

#Region "Constructors"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormatoGridAvanzado(dgvCompras, True, False)
        GetActividades()
    End Sub
#End Region

#Region "Methods"
    Public Sub GetActividades()
        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("actividad")
        dt.Columns.Add("tipo")
        dt.Columns.Add("encargado")
        Dim stado = Nothing
        For Each i In actividadPersonalSA.GetActividadesEmpresa(New actividadPersonal With {.tipo = 0})
            Select Case i.tipo
                Case Gimnasio_StatusActividades.TodosLosDias
                    stado = "Diario"
                Case Gimnasio_StatusActividades.RangoDeTiempo
                    stado = "Rango de tiempo"
            End Select
            dt.Rows.Add(i.idActividad, i.nombre, stado, "")
        Next
        dgvCompras.DataSource = dt
    End Sub
#End Region

#Region "Events"
    Private Sub frmActividadesGymMaestro_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ToolStripButton13_Click(sender As Object, e As EventArgs) Handles ToolStripButton13.Click
        frmActividadesGYM = New frmActividadesGYM
        frmActividadesGYM.statusAction = Entity.EntityState.Added
        frmActividadesGYM.StartPosition = FormStartPosition.CenterParent
        frmActividadesGYM.ShowDialog()
        GetActividades()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Try
            GetActividades()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs) Handles ToolStripButton9.Click
        r = dgvCompras.Table.CurrentRecord
        If r IsNot Nothing Then
            frmActividadesGYM = New frmActividadesGYM(Integer.Parse(r.GetValue("id")))
            frmActividadesGYM.statusAction = Entity.EntityState.Modified
            frmActividadesGYM.StartPosition = FormStartPosition.CenterParent
            frmActividadesGYM.ShowDialog()
            GetActividades()
        Else
            MessageBox.Show("Debe seleccionar un actividad", "Seleccionar fila", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
#End Region


End Class