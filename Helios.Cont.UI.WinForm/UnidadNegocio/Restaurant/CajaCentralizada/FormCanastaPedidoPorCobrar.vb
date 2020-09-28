Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports System.Xml

Public Class FormCanastaPedidoPorCobrar

    Protected Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
    Public Property DocumentoVentaSA As New documentoVentaAbarrotesSA
    Public Property DocumentoVentaDetSA As New documentoVentaAbarrotesDetSA

    Public Property listaDistribucion As List(Of String)

    Public Property FormPurchase As FormControlRestaurant

    Dim m_xmld As XmlDocument
    Dim m_nodelist As XmlNodeList
    Dim m_node As XmlNode

#Region "Constructors"
    Public Sub New(formRepPiscina As FormControlRestaurant)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormPurchase = formRepPiscina

    End Sub
#End Region

#Region "Methods"

    Public Sub CARGARdATOS()
        FormatoGridAvanzado(GridPedidos, False, False, 11.0F)
        GridPedidos.Enabled = True
        ProgressBar1.Visible = True
        ProgressBar1.Style = ProgressBarStyle.Marquee
        Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf GetListaVentasPorPeriodo))
        thread.Start()
    End Sub


    Private Sub GetListaVentasPorPeriodo()
        Dim dt As New DataTable("Pedidos del día " & Date.Now & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("pedido", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("importeTotal", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeUS", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("usuarioActualizacion", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("estadoPreparado", GetType(String)))
        dt.Columns.Add(New DataColumn("idcliente", GetType(Integer)))
        dt.Columns.Add(New DataColumn("validar", GetType(Boolean)))


        Dim str As String
        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarAllVentasPeriodoPendienteInfra(GEstableciento.IdEstablecimiento, PeriodoGeneral, listaDistribucion).OrderByDescending(Function(o) o.fechaDoc).ToList
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoVenta
            dr(2) = str
            dr(3) = i.nombrePedido
            dr(4) = i.tipoDocumento
            dr(5) = i.serieVenta
            dr(6) = i.numeroVenta
            dr(7) = i.NroDocEntidad
            dr(8) = i.NombreEntidad
            dr(9) = FormatNumber(i.ImporteNacional, 2)
            dr(10) = i.tipoCambio
            dr(11) = FormatNumber(i.ImporteExtranjero, 2)
            dr(12) = i.moneda
            dr(13) = i.usuarioActualizacion

            Select Case i.tipoVenta
                Case "NTC"
                    dr(14) = "-"
                Case Else
                    Select Case i.estadoCobro
                        Case "DC"
                            dr(14) = "Cobrado"
                        Case "ANU"
                            dr(14) = "Anulado"
                        Case TIPO_VENTA.AnuladaPorNotaCredito
                            dr(14) = "Anulado x NC."
                        Case Else
                            dr(14) = "Pendiente"
                    End Select
            End Select
            Select Case i.notaCredito
                Case StatusVentaMatizados.PorPreparar
                    dr(15) = "Pendiente"
                Case StatusVentaMatizados.TerminadaYentregada
                    dr(15) = "Entregada"
            End Select
            dr(16) = i.idCliente
            dr(17) = True
            dt.Rows.Add(dr)
        Next
        setDataSource(dt)
    End Sub

    Private Sub setDataSource(ByVal table As DataTable)
        If Me.InvokeRequired Then
            'Me.Invoke(New SetDataSourceDelegate(AddressOf setDataSource), table)

            Dim deleg As New SetDataSourceDelegate(AddressOf setDataSource)
            Invoke(deleg, New Object() {table})
        Else
            GridPedidos.DataSource = table
            GridPedidos.TopLevelGroupOptions.ShowCaption = True
            ProgressBar1.Visible = False

            'If (GridPedidos.Table.Records.Count = 0) Then
            '    FormPurchase.Tab_ListaPedidosRestaurant.Visible = False
            '    If FormPurchase.TabR_GestionInfraRestaurant IsNot Nothing Then
            '        FormPurchase.TabR_GestionInfraRestaurant.CargarDefault()
            '        FormPurchase.TabR_GestionInfraRestaurant.Visible = True
            '        FormPurchase.TabR_GestionInfraRestaurant.BringToFront()
            '        FormPurchase.TabR_GestionInfraRestaurant.Show()
            '    End If
            'End If

        End If
    End Sub

    Public Sub EliminarPedido(intIdDocumento As Integer)
        Dim documentoSA As New DocumentoSA
        Dim objDocumento As New documento
        Try
            With objDocumento
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idCentroCosto = GEstableciento.IdEstablecimiento
                .idDocumento = intIdDocumento
            End With

            documentoSA.EliminarPedidos(objDocumento)
            Me.GridPedidos.Table.CurrentRecord.Delete()
            GridPedidos.Refresh()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
        Dim listaDocumento As New List(Of Integer)
        If GridPedidos.Table.Records.Count > 0 Then

            For Each ITEM In GridPedidos.Table.Records
                If (ITEM.GetValue("validar") = True) Then
                    Dim codDocumento = Integer.Parse(ITEM.GetValue("idDocumento"))
                    listaDocumento.Add(codDocumento)
                End If
            Next

            Dim venta = DocumentoVentaSA.GetListaVentaID(New documento With {.ListaDocumentoID = listaDocumento, .tipoDoc = "VNP"})
            'Tag = venta
            'Close()


            If (venta.Count > 0) Then

                Dim f As New FormCajeroIndependienteV2
                f.DocumentoVentaLista = venta
                f.nombremesa = txtInfraestructura.Text
                f.CargarPagos()
                f.MaximizeBox = False
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog(Me)
                CARGARdATOS()

            End If


            End If
    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click
        LoadingAnimator.Wire(GridPedidos.TableControl)
        Dim r As Record = GridPedidos.Table.CurrentRecord
        Dim nombrePedido = Nothing
        If r IsNot Nothing Then
            Dim frmDetalleVentaView = New frmDetalleVentaView(Integer.Parse(r.GetValue("idDocumento")))
            nombrePedido = r.GetValue("pedido")
            If nombrePedido.ToString.Trim.Length > 0 Then
                frmDetalleVentaView.CaptionLabels(1).Text = r.GetValue("pedido")
            Else
                frmDetalleVentaView.CaptionLabels(1).Text = r.GetValue("NombreEntidad")
            End If
            frmDetalleVentaView.StartPosition = FormStartPosition.CenterParent
            frmDetalleVentaView.ShowDialog(Me)
        Else
            MessageBox.Show("Debe seleccionar un pedido!", "Seleccionar Fila", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        LoadingAnimator.UnWire(GridPedidos.TableControl)
    End Sub

    Private Sub BunifuFlatButton5_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton5.Click
        Dim DocumentoSA As New DocumentoSA
        Try
            If GridPedidos.Table.Records.Count > 0 Then
                If Not IsNothing(Me.GridPedidos.Table.CurrentRecord) Then
                    If MessageBox.Show("Desea elimiar el pedido seleccionado?", "Pedidos de venta!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        Dim r As Record = GridPedidos.Table.CurrentRecord
                        If r IsNot Nothing Then
                            Dim codDocumento = Integer.Parse(r.GetValue("idDocumento"))
                            EliminarPedido(codDocumento)
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al eliminar, consulte con el proveedor del sistema!")
        End Try
    End Sub

    Private Sub BunifuFlatButton17_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton17.Click
        ProgressBar1.Visible = True
        ProgressBar1.Style = ProgressBarStyle.Marquee
        Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf GetListaVentasPorPeriodo))
        thread.Start()
    End Sub

    Private Sub BunifuFlatButton10_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton10.Click
        Try

            Dim Formulario As Object = Nothing

            'Creamos el "Document"
            m_xmld = New XmlDocument()

            'Cargamos el archivo
            m_xmld.Load("C:\SPKconfiguration.xml")

            'Obtenemos la lista de los nodos "name"
            m_nodelist = m_xmld.SelectNodes("/spk/Restaurant")

            'Iniciamos el ciclo de lectura
            For Each m_node In m_nodelist
                'Obtenemos el Formulario de inicio
                Formulario = m_node.ChildNodes.Item(0).InnerText
                Exit For
            Next

            If Formulario = "DIRECTO" Then
                'FormPurchase.FormCanastaPedidoPorCobrar.Visible = False
                'FormPurchase.TabR_GestionCajaCentralizada.Visible = False
                'If FormPurchase.TabR_GestionInfraRestaurant IsNot Nothing Then
                '    FormPurchase.TabR_GestionInfraRestaurant.Visible = True
                '    FormPurchase.TabR_GestionInfraRestaurant.CargarDefault()
                '    FormPurchase.TabR_GestionInfraRestaurant.BringToFront()
                '    FormPurchase.TabR_GestionInfraRestaurant.Show()
                'End If
                FormPurchase.FormCanastaPedidoPorCobrar.Visible = False

                If FormPurchase.TabR_GestionCajaCentralizada IsNot Nothing Then
                    FormPurchase.TabR_GestionCajaCentralizada.Visible = True
                    FormPurchase.TabR_GestionCajaCentralizada.CargarDefault()
                    FormPurchase.TabR_GestionCajaCentralizada.BringToFront()
                    FormPurchase.TabR_GestionCajaCentralizada.Show()
                End If

            ElseIf Formulario = "PRECUENTA" Then
                FormPurchase.FormCanastaPedidoPorCobrar.Visible = False

                If FormPurchase.TabR_GestionCajaCentralizada IsNot Nothing Then
                    FormPurchase.TabR_GestionCajaCentralizada.Visible = True
                    FormPurchase.TabR_GestionCajaCentralizada.CargarDefault()
                    FormPurchase.TabR_GestionCajaCentralizada.BringToFront()
                    FormPurchase.TabR_GestionCajaCentralizada.Show()
                End If
            End If



        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub




#End Region
End Class