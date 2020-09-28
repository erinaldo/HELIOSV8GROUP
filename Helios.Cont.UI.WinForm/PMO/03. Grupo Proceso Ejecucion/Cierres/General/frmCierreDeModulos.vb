Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess

Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping
Public Class frmCierreDeModulos
    Inherits frmMaster

    Public Property FechaPeriodo() As DateTime

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ListaPorCerrar()
        Me.WindowState = FormWindowState.Maximized
        Dim str = CDate("1/" & PeriodoGeneral)
        FechaPeriodo = str
    End Sub

#Region "Métodos"
    Public Sub ListaPorCerrar()
        Dim cierreSA As New DocumentoCajaSA
        Dim lista As New List(Of documentoCaja)
        Dim entidad As String = Nothing
        Dim dt As New DataTable

        dt.Columns.Add("idEntidad")
        dt.Columns.Add("entidad")
        dt.Columns.Add("tipo")
        dt.Columns.Add("moneda")
        dt.Columns.Add("cuenta")
        dt.Columns.Add("importeMN")
        dt.Columns.Add("importeME")

        lista = cierreSA.ListaDeCajasPorCerrar(New documentoCaja With {.idEmpresa = Gempresas.IdEmpresaRuc, .periodo = PeriodoGeneral})

        For Each i In lista
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.entidadFinanciera
            dr(1) = i.NombreEntidad
            dr(2) = i.tipousuario
            dr(3) = i.moneda
            dr(4) = i.codigoLibro
            dr(5) = i.montoSoles
            dr(6) = i.montoUsd
            dt.Rows.Add(dr)
        Next
        dgvCierre.DataSource = dt

    End Sub

    Sub Grabar()
        Dim obj As New cierreCaja
        Dim cierreSA As New CierreCajaSA
        Dim lista As New List(Of cierreCaja)
        Try
            For Each i As Record In dgvCierre.Table.Records
                obj = New cierreCaja
                obj.idEntidadFinanciera = CInt(i.GetValue("idEntidad"))
                obj.idEmpresa = Gempresas.IdEmpresaRuc
                obj.idEstablecimiento = CInt(GEstableciento.IdEstablecimiento)
                obj.periodo = PeriodoGeneral
                obj.fechaProceso = txtfecha.Value
                obj.anio = AnioGeneral
                obj.mes = CInt(MesGeneral)
                obj.dia = FechaPeriodo.Day
                obj.montoMN = CDec(i.GetValue("importeMN"))
                obj.montoME = CDec(i.GetValue("importeME"))
                obj.usuarioActualizacion = "Jiuni"
                obj.fechaActualizacion = DateTime.Now
                lista.Add(obj)
            Next

            cierreSA.GrabarListaCierreCaja(lista)
            MessageBox.Show("Cierre realizado con éxito")
            Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
#End Region

    Private Sub frmCierreDeModulos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmCierreDeModulos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnCard_Click(sender As Object, e As EventArgs) Handles btnCard.Click
        Me.Cursor = Cursors.WaitCursor
        Grabar()
        Me.Cursor = Cursors.Arrow
    End Sub
End Class