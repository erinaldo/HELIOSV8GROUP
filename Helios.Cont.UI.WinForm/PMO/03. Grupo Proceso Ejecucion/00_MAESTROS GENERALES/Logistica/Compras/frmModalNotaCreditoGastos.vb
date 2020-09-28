Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Public Class frmModalNotaCreditoGastos

#Region "Attributes"
    Dim totalesSA As New TotalesAlmacenSA
    Public Property rowArticulo As New totalesAlmacen
#End Region

#Region "Constructors"
    Public Sub New(be As totalesAlmacen)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        rowArticulo = be
        txtBaseDev.Text = be.importeSoles
        ComboMotivo()
        txtBaseDev.Select()
    End Sub
#End Region

#Region "Methods"
    Sub ComboMotivo()
        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("name")

        Dim dr2 As DataRow = dt.NewRow()
        dr2(0) = "2"
        dr2(1) = "DISMINUIR IMPORTE"
        dt.Rows.Add(dr2)

        Dim dr4 As DataRow = dt.NewRow()
        dr4(0) = "4"
        dr4(1) = "PRONTO PAGO - VOLUMEN DE COMPRA"
        dt.Rows.Add(dr4)

        cboMotivo.DisplayMember = "name"
        cboMotivo.ValueMember = "id"
        cboMotivo.DataSource = dt
        cboMotivo.SelectedValue = "2"
    End Sub
#End Region

#Region "Events"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim cantidad As Decimal = 0
        Dim canSaldo As Decimal = 0
        Dim cantidadOrigen As Decimal = 0
        Dim be As New totalesAlmacen
        Try
            be = New totalesAlmacen

            If txtBaseMov.DecimalValue > CDec(txtBaseDev.Text) Then
                MessageBox.Show("El importe ingresado supera el costo a devolver", "Verificar costo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
                Cursor = Cursors.Default
            End If


            be.tipoExistencia = "GS"
            be.TipoAcces = cboMotivo.SelectedValue
            be.idAlmacen = 0
            be.cantidad = 0
            be.importeSoles = txtBaseMov.DecimalValue
            Tag = be
            Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
#End Region


End Class