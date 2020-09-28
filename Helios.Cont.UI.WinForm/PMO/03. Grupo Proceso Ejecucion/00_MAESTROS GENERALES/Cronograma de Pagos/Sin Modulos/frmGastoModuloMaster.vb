Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Tools
Imports System.Collections
Imports Syncfusion.Windows.Forms.Grid
Imports System.Collections.Specialized
Imports Syncfusion.Grouping
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports System.ComponentModel

Public Class frmGastoModuloMaster
    Inherits frmMaster

#Region "metodos"


    Public Sub EliminarGastoModulo(iddocumento As Integer)
        Dim objeto As New documentoLibroDiarioSA

        objeto.DeleteLibroDiario(iddocumento)

    End Sub



    Public Sub ListadoItems()
        Dim listadoSA As New documentoLibroDiarioSA
        Dim objeto As New tablaDetalleSA
        Dim dt As New DataTable()
        Dim entidadSA As New entidadSA
        Dim personaSA As New PersonaSA

        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("descripcion", GetType(String))
        dt.Columns.Add("tipoBen", GetType(String))
        dt.Columns.Add("beneficiario", GetType(String))
        dt.Columns.Add("tipodoc", GetType(String))
        dt.Columns.Add("nrodoc", GetType(String))
        dt.Columns.Add("moneda", GetType(String))
        dt.Columns.Add("tipoc", GetType(Decimal))
        dt.Columns.Add("importemn", GetType(Decimal))
        dt.Columns.Add("importeme", GetType(Decimal))
        dt.Columns.Add("fecha", GetType(Date))
        dt.Columns.Add("fechavct", GetType(Date))
        dt.Columns.Add("idBene", GetType(Integer))
        dt.Columns.Add("identificacion", GetType(String))



        'Dim str As String
        'For Each i In listadoSA.ListarGastosModulo("GXM")
        '    Dim dr As DataRow = dt.NewRow()
        '    'str = Nothing
        '    'If Not IsNothing(i.fecha) Then
        '    '    str = CDate(i.fecha).ToString("dd-MMM-yy HH:mm tt ")
        '    'End If

        '    dr(0) = i.idDocumento
        '    dr(1) = i.infoReferencial


        '    If IsNothing(i.razonSocial) Then

        '    Else

        '        Select Case i.tipoRazonSocial
        '            Case TIPO_ENTIDAD.PROVEEDOR
        '                dr(2) = "Proveedor"
        '                With entidadSA.UbicarEntidadPorID(i.razonSocial).First
        '                    dr(3) = .nombreCompleto
        '                End With
        '            Case TIPO_ENTIDAD.CLIENTE
        '                dr(2) = "Cliente"
        '                With entidadSA.UbicarEntidadPorID(i.razonSocial).First
        '                    dr(3) = .nombreCompleto
        '                End With
        '            Case "TR"
        '                dr(2) = "Trabajador"
        '                With personaSA.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, i.razonSocial, "TR")
        '                    dr(3) = .nombreCompleto
        '                End With
        '        End Select
        '    End If


        '    dr(4) = "VOUCHER CONTABLE"
        '    dr(5) = i.nroDoc

        '    If i.moneda = "1" Then
        '        dr(6) = "NACIONAL"

        '    ElseIf i.moneda = "2" Then

        '        dr(6) = "EXTRANJERO"
        '    End If

        '    dr(7) = i.tipoCambio
        '    dr(8) = i.importeMN

        '    dr(9) = i.importeME
        '    dr(10) = i.fecha
        '    dr(11) = i.fechaVct


        '    If IsNothing(i.razonSocial) Then
        '        dr(13) = "N"
        '    Else
        '        dr(12) = i.razonSocial
        '        dr(13) = "S"
        '    End If








        '    dt.Rows.Add(dr)
        'Next
        dgvCompra.DataSource = dt
        Me.dgvCompra.TableOptions.ListBoxSelectionMode = SelectionMode.One

    End Sub
#End Region

   

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click
        ListadoItems()
    End Sub

   

  

    Private Sub frmGastoModuloMaster_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmGastoModuloMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click
        Me.Cursor = Cursors.WaitCursor

        If Not IsNothing(dgvCompra.Table.CurrentRecord) Then
            EliminarGastoModulo(dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))
            dgvCompra.Table.CurrentRecord.Delete()
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        If Not IsNothing(dgvCompra.Table.CurrentRecord) Then

            With frmGastoXModulos
                .UbicarDocumento(dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))
                .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                .lblIdDocumento.Text = dgvCompra.Table.CurrentRecord.GetValue("idDocumento")


                If dgvCompra.Table.CurrentRecord.GetValue("identificacion") = "S" Then
                    .txtProveedor.Tag = dgvCompra.Table.CurrentRecord.GetValue("idBene")
                    .txtProveedor.Text = dgvCompra.Table.CurrentRecord.GetValue("beneficiario")
                    .CheckBox2.Checked = True
                End If
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With




        End If
    End Sub

    Private Sub ButtonAdv7_Click(sender As Object, e As EventArgs) Handles ButtonAdv7.Click
        With frmGastoXModulos
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
    End Sub
End Class