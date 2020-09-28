Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmRentabilidad
    Inherits frmMaster

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Dim cfecha As Date = DateTime.Now.Date
        lblPeriodo.Text = String.Format("{0:00}", Convert.ToInt32(cfecha.Month)) & "/" & PeriodoGeneral
        GenerarRentabilidad(lblPeriodo.Text)
    End Sub
#Region "Métodos"
    Sub SumatoriaLista()
        Dim cCant As Decimal = 0
        Dim cKardex As Decimal = 0
        Dim cCosto As Decimal = 0
        Dim Renta As Decimal = 0

        For Each i As ListViewItem In lsvRentabilidad.Items
            cCant += CDec(i.SubItems(5).Text)
            cKardex += CDec(i.SubItems(6).Text)
            cCosto += CDec(i.SubItems(7).Text)
            Renta += CDec(i.SubItems(8).Text)
        Next

        txtCantidad.Text = cCant.ToString("N2")
        txtTotalKardex.Text = cKardex.ToString("N2")
        txtTotalCosto.Text = cCosto.ToString("N2")
        txtRenta.Text = Renta.ToString("N2")

    End Sub

    Public Sub GenerarRentabilidad(srtPeriodo As String)
        Dim objLista As New documentoVentaAbarrotesDetSA
        Dim cRenta As Decimal = 0
        Try
            lsvRentabilidad.Columns.Clear()
            lsvRentabilidad.Items.Clear()

            lsvRentabilidad.Columns.Add("Descripcion", 200) '0
            lsvRentabilidad.Columns.Add("Tipo existencia", 40) '1
            lsvRentabilidad.Columns.Add("U.M.", 40) '2
            lsvRentabilidad.Columns.Add("Presentación", 60) '3
            lsvRentabilidad.Columns.Add("T.V", 50) '4
            lsvRentabilidad.Columns.Add("Cantidad", 60) '5
            lsvRentabilidad.Columns.Add("Base MN", 70) '6
            lsvRentabilidad.Columns.Add("Costo MN", 70) '7

            lsvRentabilidad.Columns.Add("Rentabilidad", 90, HorizontalAlignment.Right) '8

            For Each i As documentoventaAbarrotesDet In objLista.GetAnalisiRentabilidad(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, srtPeriodo)
                Dim n As New ListViewItem(i.nombreItem)
                n.SubItems.Add(i.tipoExistencia)
                n.SubItems.Add(i.unidad1)
                n.SubItems.Add(i.monto2)
                n.SubItems.Add(i.tipoVenta)
                n.SubItems.Add(i.monto1)
                n.SubItems.Add(i.montokardex)
                n.SubItems.Add(i.salidaCostoMN)
                cRenta = Math.Round(CDec(i.montokardex) - CDec(i.salidaCostoMN), 2)
                n.SubItems.Add(cRenta.ToString("N2"))
                lsvRentabilidad.Items.Add(n)
            Next
            SumatoriaLista()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        Dispose()
    End Sub

    Private Sub frmRentabilidad_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmRentabilidad_Load(sender As Object, e As System.EventArgs) Handles Me.Load
     
    End Sub
End Class