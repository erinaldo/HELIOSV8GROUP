Imports System.IO
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess

Public Class TabMG_RecepcionCliente

    Private Property TabRC_RecepcionHuespedExt As TabRC_RecepcionHuespedExt
    Private Property FormVentaRecepcionCliente As FormVentaRecepcionCliente
    Public Property FormPurchase As Tab_RecepcionControl
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

#Region "Metodos"

    Public Function GetCodigoVendedor() As Helios.Seguridad.Business.Entity.Usuario
        GetCodigoVendedor = Nothing
        Dim f As New FormCodigoVendedor
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        If f.Tag IsNot Nothing Then
            Dim c = CType(f.Tag, Helios.Seguridad.Business.Entity.Usuario)
            GetCodigoVendedor = c
        End If
    End Function

    Public Sub GetDocumentoVentaID()
        Try

            Dim estadoCliente As String = String.Empty
            Dim dt As New DataTable
            Dim documentoVentaAbarrotesSA As New documentoVentaAbarrotesSA
            Dim entidadBE As New entidad

            entidadBE.estado = "A"

            Dim consulta = documentoVentaAbarrotesSA.ListaClienteActivo(entidadBE)

            'DETALLE DE LA COMPRA
            dgvPedidoDetalle.Table.Records.DeleteAll()

            With dt.Columns
                .Add("idEntidad")
                .Add("nrodoc")
                .Add("nombreCompleto")
                .Add("nroHuesped")
                .Add("nroHabitaciones")
                .Add("estado")
            End With

            For Each i In consulta
                If (i.estado = "A") Then
                    estadoCliente = "ACTIVO"
                ElseIf (i.estado = "C") Then
                    estadoCliente = "INACTIVO"
                End If

                dt.Rows.Add(i.idCliente,
                            i.numeroDocNormal,
                            i.nombreCliente,
                           i.nroImpresion,
                            i.nroOrdenVenta,
                            estadoCliente)

            Next
            dgvPedidoDetalle.DataSource = dt
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        FormVentaRecepcionCliente = New FormVentaRecepcionCliente
        FormVentaRecepcionCliente.ManipulacionEstado = "I"
        FormVentaRecepcionCliente.Show()
    End Sub

    Private Sub DgvPedidoDetalle_QueryCellStyleInfo(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableCellStyleInfoEventArgs) Handles dgvPedidoDetalle.QueryCellStyleInfo
        'If Not IsNothing(e.TableCellIdentity.Column) Then
        '    Dim el As Syncfusion.Grouping.Element = e.TableCellIdentity.DisplayElement

        '    If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "estado")) Then
        '        Dim value As String = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("estado").ToString()

        '        Select Case value
        '            Case "PENDIENTE"
        '                e.Style.BackColor = Color.Red
        '                e.Style.TextColor = Color.White
        '            Case "COBRADO"
        '                e.Style.BackColor = Color.BlueViolet
        '                e.Style.TextColor = Color.White
        '        End Select
        '    End If
        'End If
    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click
        GetDocumentoVentaID()
    End Sub

    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton3.Click
        FormPurchase.TabMG_RecepcionCliente.Visible = False

        If FormPurchase.TabRC_Cliente IsNot Nothing Then
            FormPurchase.TabRC_Cliente.Visible = True
            FormPurchase.TabRC_Cliente.GetCargarFechas()
            FormPurchase.TabRC_Cliente.limpiarCajas()
            FormPurchase.TabRC_Cliente.BringToFront()
            FormPurchase.TabRC_Cliente.Show()
        End If
    End Sub

    Private Sub BunifuFlatButton5_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton5.Click
        TabRC_RecepcionHuespedExt = New TabRC_RecepcionHuespedExt
        TabRC_RecepcionHuespedExt.Show()
    End Sub

#End Region


End Class
