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
Public Class frmModalCambioCosto
    Inherits frmMaster
    Dim costoSA As New recursoCostoSA
    Public Property IdSecuencia() As Integer

    Public Sub New(intIdCosto As Integer)
        Dim costo As New recursoCosto
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        costo = costoSA.GetCostoById(New recursoCosto With {.idCosto = intIdCosto})
        If Not IsNothing(costo) Then
            cboCosto.SelectedValue = costo.idpadre
            GetProcesos(costo.idpadre)
            cboproceso.SelectedValue = costo.idCosto
        End If
        cboCosto.Enabled = True
        cboproceso.Enabled = True
        cbotipo.Enabled = True
    End Sub

#Region "Métodos"
    Public Sub GetCostoByTipoCMBServicios(be As recursoCosto)
        Dim recursoSA As New recursoCostoSA
        cboCosto.DataSource = recursoSA.GetListaRecursosXtipo(New recursoCosto With {.tipo = be.tipo,
                                                                                      .subtipo = be.subtipo})

        cboCosto.DisplayMember = "nombreCosto"
        cboCosto.ValueMember = "idCosto"
    End Sub

    Public Sub GetProcesos(intIdCostoPadre As Integer)
        Dim costoSA As New recursoCostoSA

        cboproceso.DataSource = costoSA.GetProcesosByCosto(New recursoCosto With {.idCosto = intIdCostoPadre})
        cboproceso.DisplayMember = "nombreCosto"
        cboproceso.ValueMember = "idCosto"
    
    End Sub
#End Region

    Private Sub frmModalCambioCosto_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmModalCambioCosto_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


    Private Sub cbotipo_Click(sender As Object, e As EventArgs) Handles cbotipo.Click

    End Sub

    Private Sub cbotipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbotipo.SelectedIndexChanged
        cboCosto.DataSource = Nothing
        cboproceso.DataSource = Nothing

        Dim codValue = cbotipo.Text
        Select Case codValue
            Case "PROYECTO"
                GetCostoByTipoCMBServicios(New recursoCosto With {.tipo = "HC", .subtipo = TipoCosto.Proyecto})
            Case "ORDEN DE PRODUCCION"
                GetCostoByTipoCMBServicios(New recursoCosto With {.tipo = "HC", .subtipo = TipoCosto.OrdenProduccion})
            Case "ACTIVO FIJO"
                GetCostoByTipoCMBServicios(New recursoCosto With {.tipo = "HC", .subtipo = TipoCosto.ActivoFijo})
            Case "GASTO ADMINISTRATIVO"
                GetCostoByTipoCMBServicios(New recursoCosto With {.tipo = "HG", .subtipo = TipoCosto.GastoAdministrativo})
            Case "GASTO DE VENTAS"
                GetCostoByTipoCMBServicios(New recursoCosto With {.tipo = "HG", .subtipo = TipoCosto.GastoVentas})
            Case "GASTO FINANCIERO"
                GetCostoByTipoCMBServicios(New recursoCosto With {.tipo = "HG", .subtipo = TipoCosto.GastoFinanciero})
        End Select
        cboCosto.SelectedIndex = -1
        cboproceso.SelectedIndex = -1
    End Sub

    Private Sub cboCosto_Click(sender As Object, e As EventArgs) Handles cboCosto.Click

    End Sub

    Private Sub cboCosto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCosto.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        Dim codValue = cboCosto.SelectedValue

        If Not IsNothing(codValue) Then
            If IsNumeric(codValue) Then
                GetProcesos(codValue)
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboproceso_Click(sender As Object, e As EventArgs) Handles cboproceso.Click

    End Sub

    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        Dim obj As New recursoCostoDetalle
        Dim objSA As New recursoCostoDetalleSA

        obj = New recursoCostoDetalle
        obj.idProceso = cboproceso.SelectedValue
        obj.secuencia = IdSecuencia
        objSA.CambioAsigancion(obj)
        MessageBox.Show("Información grabada", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Dispose()
    End Sub
End Class