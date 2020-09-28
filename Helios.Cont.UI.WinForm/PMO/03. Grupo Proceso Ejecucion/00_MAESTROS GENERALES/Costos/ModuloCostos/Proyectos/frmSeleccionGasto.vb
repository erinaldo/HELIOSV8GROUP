Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Public Class frmSeleccionGasto

#Region "Attributes"
    Public Property recursoSA() As New recursoCostoSA

#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        cboGastoPadre.Items.Clear()
        cboGastoPadre.Items.Add("GASTO ADMINISTRATIVO")
        cboGastoPadre.Items.Add("GASTO DE VENTAS")
        cboGastoPadre.Items.Add("GASTO FINANCIERO")
    End Sub
#End Region

#Region "methods"
    Public Sub GetCostoByTipo(be As recursoCosto)

        cboGastohijo.DisplayMember = "nombreCosto"
        cboGastohijo.ValueMember = "idCosto"
        cboGastohijo.DataSource = recursoSA.GetListaRecursosXtipo(New recursoCosto With {.tipo = be.tipo,
                                                                                    .subtipo = be.subtipo})
    End Sub
#End Region

#Region "Events"
    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Dim obj As New SeleccionCosto
        obj.GastoPadre = cboGastoPadre.Text
        obj.idGastoHijo = cboGastohijo.SelectedValue
        obj.GastoHijo = cboGastohijo.Text
        Select Case cboGastoPadre.Text
            Case "GASTO ADMINISTRATIVO"
                obj.TipoCosto = TipoCosto.GastoAdministrativo
            Case "GASTO DE VENTAS"
                obj.TipoCosto = TipoCosto.GastoVentas
            Case "GASTO FINANCIERO"
                obj.TipoCosto = TipoCosto.GastoFinanciero
        End Select
        obj.Abreviatura = "HG"
        Me.Tag = obj
        Close()
    End Sub

    Private Sub cboGastoPadre_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboGastoPadre.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        Select Case cboGastoPadre.Text
            Case "GASTO ADMINISTRATIVO"
                '
                GetCostoByTipo(New recursoCosto With {.tipo = "HG", .subtipo = TipoCosto.GastoAdministrativo})
            Case "GASTO DE VENTAS"

                GetCostoByTipo(New recursoCosto With {.tipo = "HG", .subtipo = TipoCosto.GastoVentas})
            Case "GASTO FINANCIERO"

                GetCostoByTipo(New recursoCosto With {.tipo = "HG", .subtipo = TipoCosto.GastoFinanciero})

        End Select
        Me.Cursor = Cursors.Arrow
    End Sub
#End Region

End Class