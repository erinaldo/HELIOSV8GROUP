Imports Syncfusion.Windows.Forms.Tools
Imports Helios.Cont.Business.Entity
Imports Helios.General
'Imports Helios.Planilla.Business.Entity

Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
'Imports Helios.Planilla.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Windows.Forms.Chart
Imports Syncfusion.Drawing

Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Public Class frmPresupuestoProduccion
    Inherits frmMaster

    Public Property CodigoEDT As Integer

    Public Sub New(edt As Integer, idSubProy As Integer, idProdTerminado As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        CodigoEDT = edt
        GetEntregables(idSubProy)
        cboEntregable.SelectedValue = idProdTerminado
        txtCategoria.Select()
    End Sub

#Region "Métodos"
    Sub GetEntregables(idSUbproyecto As Integer)
        Dim costoSA As New recursoCostoSA
        Dim costo As New List(Of recursoCosto)


        costo = costoSA.GetProductosTerminadosByProyecto(New recursoCosto With {.idCosto = idSUbproyecto})
        cboEntregable.DisplayMember = "nombreCosto"
        cboEntregable.ValueMember = "idCosto"
        cboEntregable.DataSource = costo
        'For Each i In costo
        '    dt.Rows.Add(i.idCosto, i.secuenciaCosto, i.nombreCosto, i.finaliza.GetValueOrDefault, i.finalizaActual.GetValueOrDefault, _
        '                i.tipoExistencia, i.UnidadMedida, i.cantidad, 0, 0, i.cantidad, i.costoCierre.GetValueOrDefault, 0, 0)
        'Next
        'dgvEntregables.DataSource = dt
    End Sub

    Sub GrabarRecurso()
        Dim recursoSA As New recursoCostoDetalleSA
        Dim obj As New recursoCostoDetalle

        obj = New recursoCostoDetalle
        obj.idCosto = cboEntregable.SelectedValue ' producto terminado
        obj.fechaRegistro = DateTime.Now
        Select Case cbotipoRecurso.Text
            Case "INVENTARIO"
                obj.iditem = TipoRecursoPlaneado.Inventario
                obj.um = "UND"
            Case "MANO DE OBRA"
                obj.iditem = TipoRecursoPlaneado.ManoDeObra
                obj.um = "HH"
            Case "ACTIVOS INMOVILIZADOS"
                obj.iditem = TipoRecursoPlaneado.ActivoInmovilizado
                obj.um = "HM"
            Case "TERCEROS"
                obj.iditem = TipoRecursoPlaneado.Terceros
                obj.um = "UND"
        End Select
        obj.destino = "1"
        obj.descripcion = txtCategoria.Text
        obj.cant = 0
        obj.puMN = 0
        obj.puME = 0
        obj.montoMN = 0
        obj.montoME = 0
        obj.documentoRef = Nothing
        obj.itemRef = Nothing
        obj.operacion = Nothing
        obj.procesado = Nothing
        obj.idProceso = CodigoEDT ' edt
        obj.tipoCosto = "PL"
        recursoSA.GrabarDetalleRecursosByTarea(obj)
        Close()
        '   GetRecursosAsignadosXTarea(New recursoCosto With {.idCosto = txtActividadActual.Tag})
    End Sub
#End Region

    Private Sub frmPresupuestoProduccion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Me.Cursor = Cursors.WaitCursor
        GrabarRecurso()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub ComboBoxAdv1_Click(sender As Object, e As EventArgs)

    End Sub
End Class