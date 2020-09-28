Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms

Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Microsoft.Reporting.WinForms
Imports System.Security
Imports System.Security.Permissions
Public Class frmProyectDashboard
    Inherits frmMaster
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        '    Me.WindowState = FormWindowState.Maximized
    End Sub


#Region "Métodos"
    Public Sub GetCostoByTipo(be As recursoCosto)
        Dim recursoSA As New recursoCostoSA

        cboProyecto.DataSource = recursoSA.GetListaRecursosXtipo(New recursoCosto With {.tipo = be.tipo,
                                                                                      .subtipo = be.subtipo})
        cboProyecto.DisplayMember = "nombreCosto"
        cboProyecto.ValueMember = "idCosto"

    End Sub
#End Region
   
    Private Sub CBOConsultas_Click(sender As Object, e As EventArgs) Handles CBOConsultas.Click

    End Sub

    Private Sub CBOConsultas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBOConsultas.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        Select Case CBOConsultas.Text
            Case "CONTRATOS DE CONSTRUCCION"

                GetCostoByTipo(New recursoCosto With {.tipo = "HC", .subtipo = TipoCosto.CONTRATOS_DE_CONSTRUCCION})

            Case "CONTRATOS DE SERVICIOS POR VALORIZACIONES O SIMILARES"

                GetCostoByTipo(New recursoCosto With {.tipo = "HC", .subtipo = TipoCosto.CONTRATOS_DE_SERVICIOS_POR_VALORIZACIONES_O_SIMILARES})


            Case "CONTRATOS DE ARRENDAMIENTOS"

                GetCostoByTipo(New recursoCosto With {.tipo = "HC", .subtipo = TipoCosto.CONTRATOS_DE_ARRENDAMIENTOS})

            Case "OP. CONTINUA DE BIENES"
                GetCostoByTipo(New recursoCosto With {.tipo = "HC", .subtipo = TipoCosto.OP_CONTINUA_DE_BIENES})

            Case "OP. DE BIENES - CONTROL INDEPENDIENTE"
                GetCostoByTipo(New recursoCosto With {.tipo = "HC", .subtipo = TipoCosto.OP_DE_BIENES_CONTROL_INDEPENDIENTE})

            Case "OP. CONTINUA DE SERVICIOS"
                GetCostoByTipo(New recursoCosto With {.tipo = "HC", .subtipo = TipoCosto.OP_CONTINUA_DE_SERVICIOS})

            Case "OP. DE SERVICIOS - CONTROL INDEPENDIENTE"

                GetCostoByTipo(New recursoCosto With {.tipo = "HC", .subtipo = TipoCosto.OP_DE_SERVICIOS_CONTROL_INDEPENDIENTE})

            Case "OP. DE SERVICIOS - CONSUMO INMEDIATO DE BIENES"
                GetCostoByTipo(New recursoCosto With {.tipo = "HC", .subtipo = TipoCosto.OP_DE_SERVICIOS_CONSUMO_INMEDIATO_DE_BIENES})

            Case "ACTIVO FIJO"
                GetCostoByTipo(New recursoCosto With {.tipo = "HC", .subtipo = TipoCosto.ActivoFijo})

            Case "GASTO ADMINISTRATIVO"
                GetCostoByTipo(New recursoCosto With {.tipo = "HG", .subtipo = TipoCosto.GastoAdministrativo})

            Case "GASTO DE VENTAS"
                GetCostoByTipo(New recursoCosto With {.tipo = "HG", .subtipo = TipoCosto.GastoVentas})

            Case "GASTO FINANCIERO"

                GetCostoByTipo(New recursoCosto With {.tipo = "HG", .subtipo = TipoCosto.GastoFinanciero})

        End Select
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Me.Cursor = Cursors.WaitCursor
        With frmNuevoCosto
            .cboTipo.Text = "HOJA DE COSTO"
            .cboSubtipo.Text = "CONTRATOS DE CONSTRUCCION"
            .cboSubtipo.Enabled = True
            .GetCuentaMax(New cuentaplanContableEmpresa With {.idEmpresa = Gempresas.IdEmpresaRuc, .cuenta = "92"})
            .Manipulacion = ENTITY_ACTIONS.INSERT
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub
End Class

