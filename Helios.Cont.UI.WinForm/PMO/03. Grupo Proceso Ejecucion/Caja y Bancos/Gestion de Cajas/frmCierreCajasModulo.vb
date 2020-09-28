Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess

Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping

Imports Syncfusion.DocIO
Imports Syncfusion.DocIO.DLS
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Tools
Imports System.Data.OleDb
Imports System.Data.SqlServerCe
Imports System.ComponentModel

Public Class frmCierreCajasModulo
    Inherits frmMaster

    Public Property xIdCajaUser As Integer

    'Private Sub GRabar()
    '    Dim lista As New List(Of cierreCaja)
    '    Dim caja As New cierreCaja
    '    Dim cierreCajaSA As New CierreCajaSA
    '    For Each r As Record In dgvCierres.Table.Records
    '        caja = New cierreCaja
    '        caja.idCajaUsuario = xIdCajaUser
    '        caja.idEmpresa = Gempresas.IdEmpresaRuc
    '        caja.idEstablecimiento = GEstableciento.IdEstablecimiento
    '        caja.periodo = PeriodoGeneral
    '        caja.fechaProceso = DateTime.Now
    '        caja.horaProceso = Nothing ' DateTime.Now.
    '        caja.montoMN = r.GetValue("montoSoles")
    '        caja.montoME = r.GetValue("montoUsd")
    '        Select Case r.GetValue("codigoLibro")
    '            Case "Compras"
    '                caja.idModulo = "CMP"
    '            Case Else
    '                caja.idModulo = "OT"
    '        End Select
    '        caja.usuarioActualizacion = "Jiuni"
    '        caja.fechaActualizacion = DateTime.Now
    '        lista.Add(caja)
    '    Next r
    '    cierreCajaSA.GrabarListaCierreCaja(lista)
    '    Dispose()
    'End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        lblPerido.Text = PeriodoGeneral
    End Sub

    Private Function getParentCierreModulos(intIdUser As Integer) As DataTable
        Dim cajaSa As New DocumentoCajaSA

        Dim dt As New DataTable("Modulos")
        dt.Columns.Add(New DataColumn("codigoLibro", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("montoSoles", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoUsd", GetType(Decimal)))

        For Each i As documentoCaja In cajaSa.GetObtenerCierreCajasModulos(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, PeriodoGeneral, intIdUser)
            Dim dr As DataRow = dt.NewRow()
            Select Case i.codigoLibro
                Case 8
                    dr(0) = "Compras"
                Case Else
                    dr(0) = i.codigoLibro
            End Select

            dr(1) = i.montoSoles
            dr(2) = i.montoUsd
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Public Sub ListaCierresPorModulo(intIdUser As Integer)
        'GetObtenerCierreCajasModulos
        dgvCierres.TableOptions.ClearCache()
        '    dgvCuentasFinanzas.DataSource = Nothing
        dgvCierres.DataSource = getParentCierreModulos(intIdUser) ' cajaSa.ListaCajasHabilitadas(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
        dgvCierres.TableDescriptor.Relations.Clear()
        dgvCierres.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
        dgvCierres.TableOptions.ListBoxSelectionMode = SelectionMode.One
        dgvCierres.TableOptions.ShowRowHeader = False
        dgvCierres.Appearance.AnyRecordFieldCell.Enabled = False
        Me.dgvCierres.TableDescriptor.GroupedColumns.Clear()
    End Sub

    Private Sub frmCierreCajasModulo_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmCierreCajasModulo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PegarToolStripButton_Click(sender As Object, e As EventArgs) Handles PegarToolStripButton.Click
        Dispose()
    End Sub

    Private Sub GuardarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles GuardarToolStripButton.Click
        Me.Cursor = Cursors.WaitCursor
        If dgvCierres.Table.Records.Count > 0 Then
            'GRabar()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub
End Class