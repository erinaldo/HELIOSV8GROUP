Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Public Class frmMovimientoMascaras
    Inherits frmMaster

    Private Sub frmMovimientoMascaras_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        CargarMascaras()
    End Sub

    Private Sub ButtonAdv1_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAdv1.Click
        With frmModalMascaras
            .Tag = "INSERT"
            .StartPosition = FormStartPosition.CenterScreen
            .Show()
        End With
    End Sub

    Public Sub CargarMascaras()
        Dim contadoSA As New mascaraContable2SA
        gridGroupingControl1.DataSource = contadoSA.ObtenerMascaraContable2PorEmpresa(Gempresas.IdEmpresaRuc)
        '   Me.gridGroupingControl1.TableOptions.AllowSelection = GridSelectionFlags.Any
        gridGroupingControl1.TableOptions.ShowRecordPlusMinus = False
        gridGroupingControl1.TableOptions.ShowRecordPreviewRow = False
        gridGroupingControl1.TableOptions.ShowTableIndent = False
        gridGroupingControl1.TableDescriptor.Relations.Clear()
        gridGroupingControl1.TableDescriptor.GroupedColumns.Clear()
        gridGroupingControl1.TableDescriptor.GroupedColumns.Add("idEmpresa")
        gridGroupingControl1.TableDescriptor.GroupedColumns.Add("tipoExistencia")
        gridGroupingControl1.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
        gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One
        gridGroupingControl1.Appearance.AnyRecordFieldCell.Enabled = False
    End Sub

    Private Sub ButtonAdv2_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAdv2.Click
        Dim mascaraContable2 As New mascaraContable2SA
        Dim maskContable2 As New mascaraContable2
        Dim mascaraContableExistenciaSA As New mascaraContableExistenciaSA
        Dim mascaraContableExistencia As New mascaraContableExistencia


        With frmModalMascaras
            If (Not IsNothing(gridGroupingControl1.Table.CurrentRecord.GetValue("cuentraCompraFil"))) Then

                If (gridGroupingControl1.Table.CurrentRecord.GetValue("tipoExistencia") = "01") Then
                    maskContable2 = mascaraContable2.GetUbicar_mascaraContable2PorEmpresa(Gempresas.IdEmpresaRuc, gridGroupingControl1.Table.CurrentRecord.GetValue("cuentraCompraFil"))
                    Select Case maskContable2.tipoExistencia
                        Case "01"
                            .cboTipoExistencia.SelectedItem = "MERCADERIA"
                    End Select
                    .Tag = "UPDATE"
                    .txtCuentaPadre.Text = maskContable2.cuentaCompra
                    .txtDescripcionCuentaPadre.Text = maskContable2.descripcionCompra
                    .txtCuentaCC.Text = maskContable2.cuentaDestinoKardex
                    .txtDescripcionCC.Text = maskContable2.nameDestinoKardex
                    .txtCuentaCC2.Text = maskContable2.destinoCompra2
                    .txtDescripcionCC2.Text = maskContable2.descripcionDestino2
                    .txtCuentaCCredTransito.Text = maskContable2.destinoCompra
                    .txtDescripCCredTransito.Text = maskContable2.descripcionDestino
                    .txtCuentaCCredTransito2.Text = maskContable2.destinoCompra2
                    .txtDescripCCredTransito2.Text = maskContable2.descripcionDestino2
                    .StartPosition = FormStartPosition.CenterScreen
                    .Show()
                Else
                    mascaraContableExistencia = mascaraContableExistenciaSA.GetUbicar_mascaraContableExistenciaPorEmpresaCF(Gempresas.IdEmpresaRuc, gridGroupingControl1.Table.CurrentRecord.GetValue("cuentraCompraFil"), gridGroupingControl1.Table.CurrentRecord.GetValue("tipoExistencia"))
                    Select Case mascaraContableExistencia.tipoExistencia
                        Case "02"
                        Case "03"
                            .cboTipoExistencia.SelectedItem = "MATERIA PRIMA"
                        Case "04"
                            .cboTipoExistencia.SelectedItem = "ENVASES Y EMBALAJES"
                        Case "05"
                            .cboTipoExistencia.SelectedItem = "MATERIALES AUXILIARES, SUMINISTROS Y RESPUESTOS"
                    End Select

                    .Tag = "UPDATE"
                    .txtCuentaPadre.Text = mascaraContableExistencia.cuentaCompra
                    .txtDescripcionCuentaPadre.Text = mascaraContableExistencia.descripcionCompra
                    .txtCuentaCC.Text = mascaraContableExistencia.cuentaIngAlmacen
                    .txtDescripcionCC.Text = mascaraContableExistencia.nameIngAlmacen
                    .txtCuentaCC2.Text = mascaraContableExistencia.cuentaSalida
                    .txtDescripcionCC2.Text = mascaraContableExistencia.descripcionSalida
                    .txtCuentaCCredTransito.Text = mascaraContableExistencia.destinoCompra
                    .txtDescripCCredTransito.Text = mascaraContableExistencia.descripcionDestino
                    .txtCuentaCCredTransito2.Text = mascaraContableExistencia.destinoCompra2
                    .txtDescripCCredTransito2.Text = mascaraContableExistencia.descripcionDestino2
                    .StartPosition = FormStartPosition.CenterScreen
                    .Show()
                End If
            Else
                lblEstado.Text = "Debe Seleecionar un campo"
            End If
        End With
    End Sub
End Class