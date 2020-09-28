Imports Helios.Planilla.Business.Entity
Imports Helios.Planilla.WCFService.ServiceAccess

Public Class frmDerachohabiente
    Inherits frmMaster

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        LoadCombos()
    End Sub

#Region "Métodos"
    Public Sub LoadCombos()
        Dim tbl As New Helios.Planilla.Business.Entity.TablaDetalle
        Dim Listados As New Helios.Planilla.WCFService.ServiceAccess.TablaDetalleSA

        Dim lstSexo = Listados.TablaDetalleSelxTabla(New Helios.Planilla.Business.Entity.TablaDetalle With {.IDTabla = 16})
        Dim lstVinculoFamiliar = Listados.TablaDetalleSelxTabla(New Helios.Planilla.Business.Entity.TablaDetalle With {.IDTabla = 7})

        cboSexo.DataSource = lstSexo
        cboSexo.ValueMember = "IDTablaDetalle"
        cboSexo.DisplayMember = "DescripcionLarga"

        cboVinculo.DataSource = lstVinculoFamiliar
        cboVinculo.ValueMember = "IDTablaDetalle"
        cboVinculo.DisplayMember = "DescripcionLarga"

    End Sub

    Public Sub Grabar()
        Dim SA As New DerechoHabientesSA
        Dim obj As New DerechoHabientes

        obj = New DerechoHabientes
        obj.Nombre = txtNombres.Text
        obj.Sexo = cboSexo.SelectedValue
        obj.fechanacimiento = txtFechaNac.Value
        obj.Incapacidad = If(CheckBoxAdv1.Checked, 1, 0)
        obj.UsuarioModificacion = usuario.IDUsuario
        obj.FechaModificacion = DateTime.Now
        SA.DerechoHabientesSave(obj, UserManager.TransactionData)
        MessageBox.Show("Persona registrada", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Close()
    End Sub
#End Region


    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Cursor = Cursors.WaitCursor
        Grabar()
        Cursor = Cursors.Default
    End Sub
End Class