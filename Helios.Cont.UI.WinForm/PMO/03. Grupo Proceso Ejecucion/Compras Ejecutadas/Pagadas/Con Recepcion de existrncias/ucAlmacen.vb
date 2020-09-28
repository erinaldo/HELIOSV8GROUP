Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Public Class ucAlmacen
    ' Declaramos el evento
    'Public Event ButtonClick As EventHandler

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        LoadControles()
    End Sub

    'Private Sub Button1_Click( _
    '    ByVal sender As Object, _
    '    ByVal e As EventArgs) Handles ButtonAdv2.Click

    '    ' Desencadenamos el evento
    '    RaiseEvent ButtonClick(sender, e)

    'End Sub

    'Protected Overloads Overrides Sub OnCreateControl()
    '    MyBase.OnCreateControl()
    '    AddHandler Me.ParentForm.FormClosing, AddressOf ParentForm_FormClosing
    'End Sub

    'Private Sub RecordButtons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
    ' ButtonAdv2.Click
    '    If sender Is ButtonAdv2 Then Me.ParentForm.Close()
    '    RaiseEvent ButtonClick(sender, e)
    'End Sub

#Region "Métodos"
    Public Sub LoadControles()
        Dim estableSA As New establecimientoSA
        Dim almacenSA As New almacenSA
        cboEstable.DisplayMember = "nombre"
        cboEstable.ValueMember = "idCentroCosto"
        cboEstable.DataSource = estableSA.ObtenerListaEstablecimientos(Gempresas.IdEmpresaRuc)

        cboAlmacen.DisplayMember = "descripcionAlmacen"
        cboAlmacen.ValueMember = "idAlmacen"
        cboAlmacen.DataSource = almacenSA.GetListar_almacenExceptAV(cboEstable.SelectedValue)
    End Sub



#End Region

    Private Sub ButtonAdv2_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAdv2.Click
        SelecIDEstable = cboEstable.SelectedValue
        SelecNombreEstable = cboEstable.Text

        SelectIdAlmacen = cboAlmacen.SelectedValue
        SelectNombreAlmacen = cboAlmacen.Text
    End Sub

    Private Sub ButtonAdv1_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub ucAlmacen_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    ' Private Sub ParentForm_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs)
    '    If MessageBox.Show("Would you like to close the parent form?", "Close parent form?", _
    '                       MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
    '        e.Cancel = True
    '    End If
    'End Sub
End Class
