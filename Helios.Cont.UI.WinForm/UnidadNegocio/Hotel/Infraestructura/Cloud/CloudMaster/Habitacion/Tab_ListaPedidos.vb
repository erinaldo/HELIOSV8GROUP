Imports System.IO
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess

Public Class Tab_ListaPedidos

    Public Property FormPurchase As Tab_RecepcionControl
    'Public Property documentoVentaDetalle As List(Of documentoPedidoDet)
    Public Property ID As Integer
    Public Sub New(formRepPiscina As Tab_RecepcionControl)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        FormPurchase = formRepPiscina

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

    Public Sub GetDocumentoVentaID(ID As Integer, TipoBusqueda As String, listaEstadoEntrega As List(Of String))
        Dim SumatoriaPendientes As Decimal = 0.0
        Dim documentoPedidoDetSA As New documentoPedidoDetSA
        Dim eentidaSA As New entidadSA
        Dim documentoBE As New documentoPedido
        Dim conteoNumeracio As Integer = 1
        Dim idDocumentoAnt As Integer = 0
        Dim ListaTipoExistencia As New List(Of String)
        Dim usuariosa As New UsuarioSA
        Dim dt As New DataTable
        'documentoventa = New documentoventaAbarrotes
        Dim consulta As New List(Of documentoventaAbarrotesDet)
        'documentoBE.idDistribucion = ID
        documentoBE.idEmpresa = Gempresas.IdEmpresaRuc
        documentoBE.idEstablecimiento = GEstableciento.IdEstablecimiento
        documentoBE.ListaTipoVenta = New List(Of String)
        documentoBE.ListaTipoVenta.Add("VELC")
        documentoBE.ListaTipoVenta.Add("VNP")
        documentoBE.ListaTipoVenta.Add("VP")
        documentoBE.ListaTipoVenta.Add("NOTE")
        'documentoBE.estadoEntrega = "PN"
        documentoBE.idCliente = ID
        documentoBE.ListaEstado = New List(Of String)
        documentoBE.ListaEstado = listaEstadoEntrega



        Select Case TipoBusqueda
            Case "CL"
                'documentoVentaDetalle = objDocCompraDet.GetUbicar_documentoPedidoxCliente(documentoBE) ' objDocCompraDet.usp_EditarDetalleVenta(ID)
            Case "IF"
                consulta = documentoPedidoDetSA.GetUbicar_DocveNTAxIdDistribucion(documentoBE)
        End Select

        If (consulta.Count > 0) Then
            idDocumentoAnt = consulta(0).idDocumento
        End If

        'DETALLE DE LA COMPRA
        dgvPedidoDetalle.Table.Records.DeleteAll()

        With dt.Columns
            .Add("idDocumento")
            .Add("fecha")
            .Add("hora")
            .Add("tipoDoc")
            .Add("numero")
            .Add("Descripcion")
            .Add("cantidad")
            .Add("total")
            .Add("estado")
            .Add("idCliente")
            .Add("cliente")
            .Add("idVendedor")
            .Add("nombreVendedor")
        End With

        Dim ListaUsuarios = usuariosa.GetListaUsuarios()

        For Each i In consulta '.Where(Function(o) tables.Contains(o.idtabla)).ToList
            Dim numeropedido As String = String.Empty
            Dim tipoDocumento As String = String.Empty
            If (idDocumentoAnt <> i.idDocumento) Then
                conteoNumeracio = conteoNumeracio + 1
                idDocumentoAnt = i.idDocumento
                numeropedido = ("Pedido" & conteoNumeracio)
            Else
                numeropedido = ("Pedido" & conteoNumeracio)
            End If
            Dim estadoCobr As String = String.Empty

            If (i.estadoPago = "DC") Then
                estadoCobr = "COBRADO"
            ElseIf (i.estadoPago = "PN") Then
                estadoCobr = "PENDIENTE"
                SumatoriaPendientes = SumatoriaPendientes + i.importeMN
            End If


            Select Case i.TipoDoc
                Case "01"
                    tipoDocumento = "FACTURA"
                Case "03"
                    tipoDocumento = "BOLETA"
                Case "1000"
                    tipoDocumento = "PEDIDO"
                Case "9907"
                    tipoDocumento = "NOTA DE VENTA"
            End Select

            Dim USUARIO = (From LitUsu In ListaUsuarios Where LitUsu.IDUsuario = i.usuarioModificacion).FirstOrDefault

            If (Not IsNothing(USUARIO)) Then
                dt.Rows.Add(i.idDocumento,
                        i.FechaDoc.Value.ToShortDateString,
                        i.FechaDoc.Value.ToLongTimeString,
                       tipoDocumento,
                        numeropedido, i.nombreItem, i.monto1, i.importeMN, estadoCobr, i.idCajaUsuario, i.NombreProveedor, i.usuarioModificacion, (USUARIO.Nombres & " " & USUARIO.ApellidoPaterno & " " & USUARIO.ApellidoMaterno))

            Else
                dt.Rows.Add(i.idDocumento,
                        i.FechaDoc.Value.ToShortDateString,
                        i.FechaDoc.Value.ToLongTimeString,
                       tipoDocumento,
                        numeropedido, i.nombreItem, i.monto1, i.importeMN, estadoCobr, i.idCajaUsuario, i.NombreProveedor, i.usuarioModificacion, "VARIOS")

            End If


        Next
        dgvPedidoDetalle.DataSource = dt
        TextSubTotal.Text = SumatoriaPendientes
    End Sub

    Private Sub llamarDefault()
        Try
            Dim listaEntrega = New List(Of String)
            listaEntrega.Add("DC")
            listaEntrega.Add("PN")
            listaEntrega.Add("PR")
            listaEntrega.Add("AN")
            GetDocumentoVentaID(ID, "IF", listaEntrega)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BtnRetorno_Click(sender As Object, e As EventArgs) Handles btnRetorno.Click
        Try
            FormPurchase.Tab_ListaPedidos.Visible = False

            If FormPurchase.TabMG_GestionInfraestructura IsNot Nothing Then
                FormPurchase.TabMG_GestionInfraestructura.CargarDefault()
                FormPurchase.TabMG_GestionInfraestructura.Visible = True
                FormPurchase.TabMG_GestionInfraestructura.BringToFront()
                FormPurchase.TabMG_GestionInfraestructura.Show()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BunifuFlatButton17_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton17.Click
        Try
            Dim f As New FormCanastaPedidoDeVentasInfra()
            'f.IdDistribucion = txtInfraestructura.Tag
            f.txtInfraestructura.Tag = txtInfraestructura.Tag
            f.txtInfraestructura.Text = txtInfraestructura.Name
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            FormPurchase.Tab_ListaPedidos.Visible = False
            If FormPurchase.TabMG_GestionInfraestructura IsNot Nothing Then
                FormPurchase.TabMG_GestionInfraestructura.CargarDefault()
                FormPurchase.TabMG_GestionInfraestructura.Visible = True
                FormPurchase.TabMG_GestionInfraestructura.BringToFront()
                FormPurchase.TabMG_GestionInfraestructura.Show()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub BunifuFlatButton5_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton5.Click
        Try

            Dim VENDEDOR = GetCodigoVendedor()

            If (Not IsNothing(VENDEDOR)) Then
                Dim f As New FormVentaNuevaTouch()
                f.ComboComprobante.Text = "VENTA"
                f.UCEstructuraCabeceraVentaV2.RoundButton21.Visible = False
                f.UCEstructuraCabeceraVentaV2.txtIDResponsable = VENDEDOR.IDUsuario
                f.UCEstructuraCabeceraVentaV2.txtNombreResponsable = VENDEDOR.Nombres & " " & VENDEDOR.ApellidoPaterno & " " & VENDEDOR.ApellidoMaterno
                f.UCEstructuraCabeceraVentaV2.txtInfraestructura.Text = txtInfraestructura.Text
                f.UCEstructuraCabeceraVentaV2.txtInfraestructura.Tag = txtInfraestructura.Tag
                f.UCEstructuraCabeceraVentaV2.RadioButton2.Checked = True
                f.UCEstructuraCabeceraVentaV2.txtCheckIn.Visible = False
                f.UCEstructuraCabeceraVentaV2.txtCheckOn.Visible = False
                f.UCEstructuraCabeceraVentaV2.txtdias.Visible = False
                f.UCEstructuraCabeceraVentaV2.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
            End If
            ID = txtInfraestructura.Tag
            Dim listaEntrega = New List(Of String)
            listaEntrega.Add("DC")
            listaEntrega.Add("PN")
            listaEntrega.Add("PR")
            listaEntrega.Add("AN")
            GetDocumentoVentaID(ID, "IF", listaEntrega)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BunifuFlatButton7_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton7.Click
        Try

            Dim VENDEDOR = GetCodigoVendedor()

            If (Not IsNothing(VENDEDOR)) Then
                Dim f As New FormVentaNuevaTouch()
                f.ComboComprobante.Text = "NOTA DE VENTA"
                f.UCEstructuraCabeceraVentaV2.RoundButton21.Visible = False
                f.UCEstructuraCabeceraVentaV2.txtIDResponsable = VENDEDOR.IDUsuario
                f.UCEstructuraCabeceraVentaV2.txtNombreResponsable = VENDEDOR.Nombres & " " & VENDEDOR.ApellidoPaterno & " " & VENDEDOR.ApellidoMaterno
                f.UCEstructuraCabeceraVentaV2.txtInfraestructura.Text = txtInfraestructura.Text
                f.UCEstructuraCabeceraVentaV2.txtInfraestructura.Tag = txtInfraestructura.Tag
                f.UCEstructuraCabeceraVentaV2.RadioButton2.Checked = True
                f.UCEstructuraCabeceraVentaV2.txtCheckIn.Visible = False
                f.UCEstructuraCabeceraVentaV2.txtCheckOn.Visible = False
                f.UCEstructuraCabeceraVentaV2.txtdias.Visible = False
                f.UCEstructuraCabeceraVentaV2.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
            End If
            ID = txtInfraestructura.Tag
            Dim listaEntrega = New List(Of String)
            listaEntrega.Add("DC")
            listaEntrega.Add("PN")
            listaEntrega.Add("PR")
            listaEntrega.Add("AN")
            GetDocumentoVentaID(ID, "IF", listaEntrega)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
        Try
            Dim listaEntrega = New List(Of String)
            listaEntrega.Add("AN")
            GetDocumentoVentaID(ID, "IF", listaEntrega)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        'Try
        '    Dim listaEntrega = New List(Of String)
        '    listaEntrega.Add("PR")
        '    GetDocumentoVentaID(ID, "IF", listaEntrega)
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
    End Sub

    Private Sub BtnPedido_Click(sender As Object, e As EventArgs) Handles btnPedido.Click

    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        Try

            Dim VENDEDOR = GetCodigoVendedor()

            If (Not IsNothing(VENDEDOR)) Then
                Dim f As New FormVentaNuevaTouch()
                f.ComboComprobante.Text = "PEDIDO"
                f.CheckStock.Checked = True
                f.UCEstructuraCabeceraVentaV2.RoundButton21.Visible = False
                f.UCEstructuraCabeceraVentaV2.txtIDResponsable = VENDEDOR.IDUsuario
                f.UCEstructuraCabeceraVentaV2.txtNombreResponsable = VENDEDOR.Nombres & " " & VENDEDOR.ApellidoPaterno & " " & VENDEDOR.ApellidoMaterno
                f.UCEstructuraCabeceraVentaV2.txtInfraestructura.Text = txtInfraestructura.Text
                f.UCEstructuraCabeceraVentaV2.txtInfraestructura.Tag = txtInfraestructura.Tag
                f.UCEstructuraCabeceraVentaV2.RadioButton2.Checked = True
                f.UCEstructuraCabeceraVentaV2.txtCheckIn.Visible = False
                f.UCEstructuraCabeceraVentaV2.txtCheckOn.Visible = False
                f.UCEstructuraCabeceraVentaV2.txtdias.Visible = False
                f.UCEstructuraCabeceraVentaV2.lblCheckIn.Visible = False
                f.UCEstructuraCabeceraVentaV2.Label20.Visible = False
                f.UCEstructuraCabeceraVentaV2.Label19.Visible = False
                f.UCEstructuraCabeceraVentaV2.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
            End If
            ID = txtInfraestructura.Tag
            Dim listaEntrega = New List(Of String)
            listaEntrega.Add("DC")
            listaEntrega.Add("PN")
            listaEntrega.Add("PR")
            listaEntrega.Add("AN")
            GetDocumentoVentaID(ID, "IF", listaEntrega)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click

        Dim listaEntrega = New List(Of String)
        listaEntrega.Add("DC")
        listaEntrega.Add("PN")
        listaEntrega.Add("PR")
        listaEntrega.Add("AN")
        GetDocumentoVentaID(ID, "IF", listaEntrega)

    End Sub

    Private Sub DgvPedidoDetalle_QueryCellStyleInfo(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableCellStyleInfoEventArgs) Handles dgvPedidoDetalle.QueryCellStyleInfo
        If Not IsNothing(e.TableCellIdentity.Column) Then
            Dim el As Syncfusion.Grouping.Element = e.TableCellIdentity.DisplayElement

            If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "estado")) Then
                Dim value As String = e.TableCellIdentity.DisplayElement.GetRecord().GetValue("estado").ToString()

                Select Case value
                    Case "PENDIENTE"
                        e.Style.BackColor = Color.Red
                        e.Style.TextColor = Color.White
                    Case "COBRADO"
                        e.Style.BackColor = Color.BlueViolet
                        e.Style.TextColor = Color.White
                End Select
            End If
        End If
    End Sub


#End Region


End Class
