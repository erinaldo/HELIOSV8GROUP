Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports ProcesosGeneralesCajamiSoft
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class TabCT_ControlXCliente

    Public Property TabCD_DiasContractuales As TabCD_DiasContractuales
    Public Property TabCD_DiasContractualesLista As TabCD_DiasContractualesLista
    Public Property TabCD_HospedadosLista As TabCD_HospedadosLista
    Public Property TabCD_HabitacionDetalle As TabCD_HabitacionDetalle
    Public Property TabRC_ListaPedidosXCliente As TabRC_ListaPedidosXCliente

    Public Property TabFN_GetCuentasCobrarPeriodo As TabFN_GetCuentasCobrarPeriodo
    Public Property TabFN_Reclamaciones As TabFN_Reclamaciones

    Public Property TabFN_AnticipoReclamacionStatus As TabFN_AnticipoReclamacionStatus
    Public Property TabFN_DevolucionNotaCreditoAnt As TabFN_DevolucionNotaCreditoAnt

    Public Property FormPurchase As FormControlHotel
    Private Property SelRazon As entidad
    Private Property entidadSA As New entidadSA
    Dim listaIDDistribucion As New List(Of String)
    Dim IdDocumento As Integer
    Dim secuencia As Integer
    Dim idDistribucion As Integer

    Dim TipoEstadia As Integer

    Dim HabitacionSA As New distribucionInfraestructuraSA
    Dim HabitacionBE As New documentoventaAbarrotes
    Dim DocumentoVentaSa As New documentoVentaAbarrotesSA
    Dim dt As New DataTable
    Dim ResumenVenta
    Dim Saldos
    Dim consulta
    Private Start As Boolean

    Public Sub New(formRepPiscina As FormControlHotel)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormPurchase = formRepPiscina

        TabCD_DiasContractuales = New TabCD_DiasContractuales(Me)
        TabCD_DiasContractuales.Dock = DockStyle.Fill
        pnPrincipal.Controls.Add(TabCD_DiasContractuales)
        TabCD_DiasContractuales.Visible = False

        TabCD_DiasContractualesLista = New TabCD_DiasContractualesLista(Me)
        TabCD_DiasContractualesLista.Dock = DockStyle.Fill
        pnPrincipal.Controls.Add(TabCD_DiasContractualesLista)
        TabCD_DiasContractualesLista.Visible = False

        TabCD_HospedadosLista = New TabCD_HospedadosLista(Me)
        TabCD_HospedadosLista.Dock = DockStyle.Fill
        pnPrincipal.Controls.Add(TabCD_HospedadosLista)
        TabCD_HospedadosLista.Visible = False

        TabCD_HabitacionDetalle = New TabCD_HabitacionDetalle(Me)
        TabCD_HabitacionDetalle.Dock = DockStyle.Fill
        pnPrincipal.Controls.Add(TabCD_HabitacionDetalle)
        TabCD_HabitacionDetalle.Visible = False

        TabRC_ListaPedidosXCliente = New TabRC_ListaPedidosXCliente(Me)
        TabRC_ListaPedidosXCliente.Dock = DockStyle.Fill
        pnPrincipal.Controls.Add(TabRC_ListaPedidosXCliente)
        TabRC_ListaPedidosXCliente.Visible = False


        TabFN_GetCuentasCobrarPeriodo = New TabFN_GetCuentasCobrarPeriodo(Me)
        TabFN_GetCuentasCobrarPeriodo.Dock = DockStyle.Fill
        pnPrincipal.Controls.Add(TabFN_GetCuentasCobrarPeriodo)
        TabFN_GetCuentasCobrarPeriodo.Visible = False

        TabFN_Reclamaciones = New TabFN_Reclamaciones(Me, False, "A")
        TabFN_Reclamaciones.Dock = DockStyle.Fill
        pnPrincipal.Controls.Add(TabFN_Reclamaciones)
        TabFN_Reclamaciones.Visible = False

        TabFN_AnticipoReclamacionStatus = New TabFN_AnticipoReclamacionStatus(Me, False, "A")
        TabFN_AnticipoReclamacionStatus.Dock = DockStyle.Fill
        pnPrincipal.Controls.Add(TabFN_AnticipoReclamacionStatus)
        TabFN_AnticipoReclamacionStatus.Visible = False

        TabFN_DevolucionNotaCreditoAnt = New TabFN_DevolucionNotaCreditoAnt(Me, False, "A")
        TabFN_DevolucionNotaCreditoAnt.Dock = DockStyle.Fill
        pnPrincipal.Controls.Add(TabFN_DevolucionNotaCreditoAnt)
        TabFN_DevolucionNotaCreditoAnt.Visible = False


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

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click
        FormPurchase.TabCT_ControlXCliente.Visible = False
        If FormPurchase.TabP_IdentificacionCliente IsNot Nothing Then
            FormPurchase.TabP_IdentificacionCliente.Visible = True
            FormPurchase.TabP_IdentificacionCliente.BringToFront()
            FormPurchase.TabP_IdentificacionCliente.Show()
        End If
        pnCargaDatos.Visible = True
    End Sub


    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click
        Try
            Dim listaEntrega = New List(Of String)
            listaEntrega.Add("DC")
            listaEntrega.Add("PN")
            listaEntrega.Add("PR")
            listaEntrega.Add("AN")

            TabCD_DiasContractuales.Visible = False
            TabCD_HospedadosLista.Visible = False
            TabCD_DiasContractualesLista.Visible = False
            TabCD_HabitacionDetalle.Visible = False
            If TabRC_ListaPedidosXCliente IsNot Nothing Then
                TabRC_ListaPedidosXCliente.txtInfraestructura.Tag = lblHabitaciones.Tag
                TabRC_ListaPedidosXCliente.txtInfraestructura.Text = lblHabitaciones.Text
                TabRC_ListaPedidosXCliente.GetDocumentoVentaID(lblHabitaciones.Tag, "IF", listaEntrega)
                TabRC_ListaPedidosXCliente.ID = lblHabitaciones.Tag
                TabRC_ListaPedidosXCliente.Visible = True
                TabRC_ListaPedidosXCliente.BringToFront()
                TabRC_ListaPedidosXCliente.Show()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub UpdateCtasxCobrar()
        Saldos = HabitacionSA.GetDashboardDistribucion(HabitacionBE)
        For Each xx In Saldos
            lblCtasXCobrar.Text = CDec(xx.ctaXCobrar)
        Next
    End Sub

    Private Sub bwCargarDAshBoar_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bwCargarDAshBoar.RunWorkerCompleted
        Try
            For Each item In consulta

                lblHospedadosCount.Text = item.conteoHospedados
                IdDocumento = item.idDocumento
                idDistribucion = item.idDistribucion
                secuencia = item.secuencia
                TipoEstadia = item.tipo

                If (item.numeracion > 0) Then
                    lblHabitaciones.Text = "HABITACION " & item.numeracion
                    lblHabitacionCount.Text = 1
                    lblHabitaciones.Tag = idDistribucion
                    lblDiasContractualesCount.Text = 1
                    listaIDDistribucion = item.listaestado
                    lblDiasContractualesCount.Visible = True
                Else
                    lblHabitaciones.Text = "HABITACIONES"
                    lblHabitacionCount.Text = item.conteoHabitaciones
                    listaIDDistribucion = item.listaestado
                    lblDiasContractualesCount.Visible = False
                End If

            Next

            For Each xx In Saldos
                lblCtasXCobrar.Text = Math.Round(CDec(xx.ctaXCobrar), 2)
                lblVentaCredito.Text = Math.Round(CDec(xx.VentaCredito), 2)
                lblVentaTotal.Text = Math.Round(CDec(xx.VentaTotal), 2)
                lblAnticiposRecibidos.Text = Math.Round(CDec(xx.AnticiposRecibidos), 2)
                lblDEvoluciones.Text = Math.Round(CDec(xx.Devolucion), 2)
                lblCompensanciones.Text = Math.Round(CDec(xx.Reclamaciones), 2)
                lblPedidoPendiente.Text = CInt(xx.conteoPedidoPendiente)
            Next

            dgvCompras.Table.Records.DeleteAll()
            dt = New DataTable
            With dt.Columns
                .Add("ID")
                .Add("HABITACION")
                .Add("PEDIDO")
                .Add("IMPORTE")
                .Add("ESTADO")
            End With

            For Each i In ResumenVenta
                Dim ESTADO As String = i.estadoCobro

                Select Case ESTADO
                    Case "PN"
                        ESTADO = "PENDIENTE"
                    Case "DC"
                        ESTADO = "COBRADO"
                End Select

                dt.Rows.Add(i.idDocumento,
                    i.EnvioSunat,
                i.usuarioActualizacion,
                i.ImporteNacional,
          ESTADO)

            Next
            dgvCompras.DataSource = dt

            pnCargaDatos.Visible = False
            Start = False

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Public Sub llamarCArgar()
        bwCargarDAshBoar.RunWorkerAsync()
    End Sub

    Private Sub BwCargarDAshBoar_DoWork(sender As Object, e As DoWorkEventArgs) Handles bwCargarDAshBoar.DoWork
        Try

            HabitacionBE.NroDocEntidad = TextNumIdentrazon.Text
            HabitacionBE.estado = "A"
            HabitacionBE.idCliente = TextProveedor.Tag
            HabitacionBE.idDocumento = lblHabitaciones.Tag

            consulta = HabitacionSA.GetDashBoardXCliente(HabitacionBE)

            For Each xx In consulta
                HabitacionBE.ListaEstado = (xx.listaestado)
                HabitacionBE.idDocumento = (xx.listaestado(0))
            Next

            Saldos = HabitacionSA.GetDashboardDistribucion(HabitacionBE)
            ResumenVenta = DocumentoVentaSa.GetListaPedidosXCliente(HabitacionBE)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles timer1.Tick
        If Start Then
            bwCargarDAshBoar.RunWorkerAsync()
        End If
    End Sub

    Private Sub BunifuFlatButton7_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton7.Click
        Try
            Dim HabitacionBE As New documentoventaAbarrotes
            Dim DocumentoVentaSa As New documentoVentaAbarrotesSA

            If (CInt(lblHabitacionCount.Text) = 1) Then

                Dim VENDEDOR = GetCodigoVendedor()

                If (Not IsNothing(VENDEDOR)) Then
                    Dim f As New FormVentaNuevaTouch()
                    f.ComboComprobante.Text = "PEDIDO"
                    f.CheckStock.Checked = True
                    f.UCEstructuraCabeceraVentaV2.RoundButton21.Visible = False
                    f.UCEstructuraCabeceraVentaV2.txtIDResponsable = VENDEDOR.IDUsuario
                    f.UCEstructuraCabeceraVentaV2.txtNombreResponsable = VENDEDOR.Nombres & " " & VENDEDOR.ApellidoPaterno & " " & VENDEDOR.ApellidoMaterno
                    f.UCEstructuraCabeceraVentaV2.txtInfraestructura.Text = lblHabitaciones.Text
                    f.UCEstructuraCabeceraVentaV2.txtInfraestructura.Tag = lblHabitaciones.Tag
                    f.UCEstructuraCabeceraVentaV2.RadioButton2.Checked = True
                    f.UCEstructuraCabeceraVentaV2.txtCheckIn.Visible = False
                    f.UCEstructuraCabeceraVentaV2.txtCheckOn.Visible = False
                    f.UCEstructuraCabeceraVentaV2.txtdias.Visible = False
                    f.UCEstructuraCabeceraVentaV2.lblCheckIn.Visible = False
                    f.UCEstructuraCabeceraVentaV2.Label20.Visible = False
                    f.UCEstructuraCabeceraVentaV2.Label19.Visible = False
                    f.UCEstructuraCabeceraVentaV2.TextNumIdentrazon.Text = TextNumIdentrazon.Text
                    f.UCEstructuraCabeceraVentaV2.TextProveedor.Text = TextProveedor.Text
                    f.UCEstructuraCabeceraVentaV2.TextProveedor.Tag = TextProveedor.Tag
                    f.UCEstructuraCabeceraVentaV2.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                    f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()
                End If

                llamarCArgar()


            ElseIf (CInt(lblHabitacionCount.Text) > 1) Then
                Dim estado As String = String.Empty
                estado = "U"

                Dim f As New TabRC_NuevoPedido()
                f.NroDoc = TextNumIdentrazon.Text
                f.nombre = TextProveedor.Text
                f.IdCliente = TextProveedor.Tag
                f.IDDocumento = TextProveedor.Tag
                f.LLAMARiNFRAESTRUCTURA(Nothing, estado)
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()

                llamarCArgar()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LblHabitaciones_Click(sender As Object, e As EventArgs) Handles lblHabitaciones.Click
        Try
            If (CInt(lblHabitacionCount.Text) = 1) Then
                TabCD_DiasContractuales.Visible = False
                TabCD_HospedadosLista.Visible = False
                TabCD_DiasContractualesLista.Visible = False
                TabFN_Reclamaciones.Visible = False
                TabFN_DevolucionNotaCreditoAnt.Visible = False
                TabFN_AnticipoReclamacionStatus.Visible = False
                If TabCD_HabitacionDetalle IsNot Nothing Then
                    TabCD_HabitacionDetalle.FlowHabitaciones.Visible = False
                    TabCD_HabitacionDetalle.GetHabitacionUnico(idDistribucion, TextProveedor.Tag)
                    TabCD_HabitacionDetalle.Visible = True
                    TabCD_HabitacionDetalle.BringToFront()
                    TabCD_HabitacionDetalle.Show()
                End If
            ElseIf (CInt(lblHabitacionCount.Text) > 1) Then
                TabCD_DiasContractuales.Visible = False
                TabCD_HospedadosLista.Visible = False
                TabCD_DiasContractualesLista.Visible = False
                TabFN_DevolucionNotaCreditoAnt.Visible = False
                TabFN_AnticipoReclamacionStatus.Visible = False
                If TabCD_HabitacionDetalle IsNot Nothing Then
                    TabCD_HabitacionDetalle.FlowHabitaciones.Visible = True
                    TabCD_HabitacionDetalle.GetListaHabitaciones(idDistribucion, TextProveedor.Tag)
                    TabCD_HabitacionDetalle.Visible = True
                    TabCD_HabitacionDetalle.BringToFront()
                    TabCD_HabitacionDetalle.Show()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LblHospedados_Click(sender As Object, e As EventArgs) Handles lblHospedados.Click
        TabCD_DiasContractualesLista.Visible = False
        TabCD_DiasContractuales.Visible = False
        TabCD_HabitacionDetalle.Visible = False
        TabFN_Reclamaciones.Visible = False
        TabFN_DevolucionNotaCreditoAnt.Visible = False
        TabFN_AnticipoReclamacionStatus.Visible = False
        If TabCD_HospedadosLista IsNot Nothing Then
            TabCD_HospedadosLista.GetCargarFechasBD(idDistribucion, TextProveedor.Tag)
            TabCD_HospedadosLista.Visible = True
            TabCD_HospedadosLista.BringToFront()
            TabCD_HospedadosLista.Show()
        End If
    End Sub

    Private Sub LblDiasContractuales_Click(sender As Object, e As EventArgs) Handles lblDiasContractuales.Click
        Try
            If (TipoEstadia = 2) Then
                TabCD_DiasContractuales.Visible = False
                TabCD_HospedadosLista.Visible = False
                TabCD_HabitacionDetalle.Visible = False
                TabFN_Reclamaciones.Visible = False
                TabFN_DevolucionNotaCreditoAnt.Visible = False
                TabFN_AnticipoReclamacionStatus.Visible = False
                If TabCD_DiasContractualesLista IsNot Nothing Then
                    TabCD_DiasContractualesLista.GetCargarFechasBD(idDistribucion, TextProveedor.Tag)
                    TabCD_DiasContractualesLista.Visible = True
                    TabCD_DiasContractualesLista.BringToFront()
                    TabCD_DiasContractualesLista.Show()
                End If
            ElseIf (TipoEstadia = 1) Then
                TabCD_DiasContractualesLista.Visible = False
                TabCD_HospedadosLista.Visible = False
                TabCD_HabitacionDetalle.Visible = False
                TabFN_DevolucionNotaCreditoAnt.Visible = False
                TabFN_AnticipoReclamacionStatus.Visible = False
                If TabCD_DiasContractuales IsNot Nothing Then
                    TabCD_DiasContractuales.IDDocumento = IdDocumento
                    TabCD_DiasContractuales.txtHabitacion.Text = lblHabitaciones.Text & " " & (lblHabitacionCount.Text)
                    TabCD_DiasContractuales.GetCargarFechasBD(idDistribucion, IdDocumento)
                    TabCD_DiasContractuales.Visible = True
                    TabCD_DiasContractuales.BringToFront()
                    TabCD_DiasContractuales.Show()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LblHabitacionCount_Click(sender As Object, e As EventArgs) Handles lblHabitacionCount.Click
        Try
            If (CInt(lblHabitacionCount.Text) = 1) Then
                TabCD_DiasContractuales.Visible = False
                TabCD_HospedadosLista.Visible = False
                TabCD_DiasContractualesLista.Visible = False
                TabFN_Reclamaciones.Visible = False
                TabFN_DevolucionNotaCreditoAnt.Visible = False
                TabFN_AnticipoReclamacionStatus.Visible = False
                If TabCD_HabitacionDetalle IsNot Nothing Then
                    TabCD_HabitacionDetalle.FlowHabitaciones.Visible = False
                    TabCD_HabitacionDetalle.GetHabitacionUnico(idDistribucion, TextProveedor.Tag)
                    TabCD_HabitacionDetalle.Visible = True
                    TabCD_HabitacionDetalle.BringToFront()
                    TabCD_HabitacionDetalle.Show()
                End If
            ElseIf (CInt(lblHabitacionCount.Text) > 1) Then
                TabCD_DiasContractuales.Visible = False
                TabCD_HospedadosLista.Visible = False
                TabCD_DiasContractualesLista.Visible = False
                TabFN_DevolucionNotaCreditoAnt.Visible = False
                TabFN_AnticipoReclamacionStatus.Visible = False
                If TabCD_HabitacionDetalle IsNot Nothing Then
                    TabCD_HabitacionDetalle.FlowHabitaciones.Visible = True
                    TabCD_HabitacionDetalle.GetListaHabitaciones(idDistribucion, TextProveedor.Tag)
                    TabCD_HabitacionDetalle.Visible = True
                    TabCD_HabitacionDetalle.BringToFront()
                    TabCD_HabitacionDetalle.Show()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LblHospedadosCount_Click(sender As Object, e As EventArgs) Handles lblHospedadosCount.Click
        TabCD_DiasContractualesLista.Visible = False
        TabCD_DiasContractuales.Visible = False
        TabCD_HabitacionDetalle.Visible = False
        TabFN_DevolucionNotaCreditoAnt.Visible = False
        TabFN_AnticipoReclamacionStatus.Visible = False
        If TabCD_HospedadosLista IsNot Nothing Then
            TabCD_HospedadosLista.GetCargarFechasBD(idDistribucion, TextProveedor.Tag)
            TabCD_HospedadosLista.Visible = True
            TabCD_HospedadosLista.BringToFront()
            TabCD_HospedadosLista.Show()
        End If
    End Sub

    Private Sub LblDiasContractualesCount_Click(sender As Object, e As EventArgs) Handles lblDiasContractualesCount.Click
        Try
            If (TipoEstadia = 2) Then
                TabCD_DiasContractuales.Visible = False
                TabCD_HospedadosLista.Visible = False
                TabCD_HabitacionDetalle.Visible = False
                TabFN_Reclamaciones.Visible = False
                TabFN_DevolucionNotaCreditoAnt.Visible = False
                TabFN_AnticipoReclamacionStatus.Visible = False
                If TabCD_DiasContractualesLista IsNot Nothing Then
                    TabCD_DiasContractualesLista.GetCargarFechasBD(idDistribucion, TextProveedor.Tag)
                    TabCD_DiasContractualesLista.Visible = True
                    TabCD_DiasContractualesLista.BringToFront()
                    TabCD_DiasContractualesLista.Show()
                End If
            ElseIf (TipoEstadia = 1) Then
                TabCD_DiasContractualesLista.Visible = False
                TabCD_HospedadosLista.Visible = False
                TabCD_HabitacionDetalle.Visible = False
                TabFN_DevolucionNotaCreditoAnt.Visible = False
                TabFN_AnticipoReclamacionStatus.Visible = False
                If TabCD_DiasContractuales IsNot Nothing Then
                    TabCD_DiasContractuales.IDDocumento = IdDocumento
                    TabCD_DiasContractuales.txtHabitacion.Text = lblHabitaciones.Text & " " & (lblHabitacionCount.Text)
                    TabCD_DiasContractuales.GetCargarFechasBD(idDistribucion, IdDocumento)
                    TabCD_DiasContractuales.Visible = True
                    TabCD_DiasContractuales.BringToFront()
                    TabCD_DiasContractuales.Show()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click
        Try

            Dim listaEntrega = New List(Of String)
            listaEntrega.Add("DC")
            listaEntrega.Add("PN")
            listaEntrega.Add("PR")
            listaEntrega.Add("AN")

            TabCD_DiasContractuales.Visible = False
            TabCD_HospedadosLista.Visible = False
            TabCD_DiasContractualesLista.Visible = False
            TabCD_HabitacionDetalle.Visible = False
            TabFN_Reclamaciones.Visible = False
            TabFN_DevolucionNotaCreditoAnt.Visible = False
            TabFN_AnticipoReclamacionStatus.Visible = False
            If TabRC_ListaPedidosXCliente IsNot Nothing Then
                TabRC_ListaPedidosXCliente.txtInfraestructura.Tag = lblHabitaciones.Tag
                TabRC_ListaPedidosXCliente.txtInfraestructura.Text = lblHabitaciones.Text
                TabRC_ListaPedidosXCliente.GetDocumentoVentaIDXCliente(listaIDDistribucion, "IF", listaEntrega)
                TabRC_ListaPedidosXCliente.ID = lblHabitaciones.Tag
                TabRC_ListaPedidosXCliente.Visible = True
                TabRC_ListaPedidosXCliente.BringToFront()
                TabRC_ListaPedidosXCliente.Show()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        FormPurchase.TabP_IdentificacionCliente.Visible = False
        FormPurchase.TabCT_ControlXCliente.Visible = False
        If FormPurchase.TabRC_RecepcionPersona IsNot Nothing Then
            FormPurchase.TabRC_RecepcionPersona.Visible = True
            FormPurchase.TabRC_RecepcionPersona.pnPrincipal.Visible = True
            FormPurchase.TabRC_RecepcionPersona.GetCargarFechas()
            FormPurchase.TabRC_RecepcionPersona.limpiarCajas()
            FormPurchase.TabRC_RecepcionPersona.TextNumIdentrazon.Text = TextNumIdentrazon.Text
            FormPurchase.TabRC_RecepcionPersona.TextProveedor.Text = TextProveedor.Text
            FormPurchase.TabRC_RecepcionPersona.TextProveedor.Tag = TextProveedor.Tag
            'FormPurchase.TabRC_RecepcionPersona.textDireccion.Text = textDireccion.Text
            FormPurchase.TabRC_RecepcionPersona.TextNumIdentrazon.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            FormPurchase.TabRC_RecepcionPersona.TextProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            FormPurchase.TabRC_RecepcionPersona.textDireccion.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            FormPurchase.TabRC_RecepcionPersona.BringToFront()
            FormPurchase.TabRC_RecepcionPersona.Show()

            llamarCArgar()

        End If
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        TabCD_DiasContractuales.Visible = False
        TabCD_HospedadosLista.Visible = False
        TabCD_HabitacionDetalle.Visible = False
        TabCD_DiasContractualesLista.Visible = False
        TabFN_Reclamaciones.Visible = False
        TabFN_DevolucionNotaCreditoAnt.Visible = False
        TabFN_AnticipoReclamacionStatus.Visible = False
        If TabFN_GetCuentasCobrarPeriodo IsNot Nothing Then
            TabFN_GetCuentasCobrarPeriodo.ToolStripButton2.Visible = False
            TabFN_GetCuentasCobrarPeriodo.GradientPanel19.Visible = False
            TabFN_GetCuentasCobrarPeriodo.btnRetornar.Visible = True
            TabFN_GetCuentasCobrarPeriodo.txtRucPago.Text = TextNumIdentrazon.Text
            TabFN_GetCuentasCobrarPeriodo.txtBuscarProveedorPago.Text = TextProveedor.Text
            TabFN_GetCuentasCobrarPeriodo.txtBuscarProveedorPago.Tag = TextProveedor.Tag
            TabFN_GetCuentasCobrarPeriodo.CuentasPorPagarTerminos("1", "PN")
            TabFN_GetCuentasCobrarPeriodo.Visible = True
            TabFN_GetCuentasCobrarPeriodo.BringToFront()
            TabFN_GetCuentasCobrarPeriodo.Show()
        End If

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        'Dim f As New FormCajeroIndependiente
        'f.ToolImportar.PerformClick()
        'f.StartPosition = FormStartPosition.CenterParent
        'f.ShowDialog(Me)

        Dim f As New FormCanastaPedidoDeVentasInfra()
        f.listaDistribucion = listaIDDistribucion
        f.txtInfraestructura.Tag = lblHabitaciones.Tag
        f.txtInfraestructura.Text = lblHabitaciones.Text
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()

        llamarCArgar()

    End Sub

    Private Sub Label57_Click(sender As Object, e As EventArgs) Handles Label57.Click
        TabCD_DiasContractuales.Visible = False
        TabCD_HospedadosLista.Visible = False
        TabCD_HabitacionDetalle.Visible = False
        TabCD_DiasContractualesLista.Visible = False
        TabFN_GetCuentasCobrarPeriodo.Visible = False
        TabFN_DevolucionNotaCreditoAnt.Visible = False
        TabFN_AnticipoReclamacionStatus.Visible = False
        If TabFN_Reclamaciones IsNot Nothing Then
            TabFN_Reclamaciones.ToolStripButton2.Visible = False
            TabFN_Reclamaciones.Visible = True
            TabFN_Reclamaciones.btnRetornar.Visible = True
            TabFN_Reclamaciones.clienteID = TextProveedor.Tag
            TabFN_Reclamaciones.NombreCliente = TextProveedor.Text
            TabFN_Reclamaciones.NumeroCliente = TextNumIdentrazon.Text
            TabFN_Reclamaciones.GetAnticiposPeriodoxCliente(Date.Now, "AR", TextProveedor.Tag)
            TabFN_Reclamaciones.BringToFront()
            TabFN_Reclamaciones.Show()
        End If
    End Sub

    Private Sub Label58_Click(sender As Object, e As EventArgs) Handles Label58.Click

    End Sub

    Private Sub Label60_Click(sender As Object, e As EventArgs) Handles Label60.Click
        TabCD_DiasContractuales.Visible = False
        TabCD_HospedadosLista.Visible = False
        TabCD_HabitacionDetalle.Visible = False
        TabCD_DiasContractualesLista.Visible = False
        TabFN_GetCuentasCobrarPeriodo.Visible = False
        TabFN_AnticipoReclamacionStatus.Visible = False
        TabFN_Reclamaciones.Visible = False
        If TabFN_DevolucionNotaCreditoAnt IsNot Nothing Then
            TabFN_DevolucionNotaCreditoAnt.GetNotasXCliente("PN", TextProveedor.Tag)
            TabFN_DevolucionNotaCreditoAnt.Visible = True
            TabFN_DevolucionNotaCreditoAnt.btnRetornar.Visible = True
            TabFN_DevolucionNotaCreditoAnt.BringToFront()
            TabFN_DevolucionNotaCreditoAnt.Show()
        End If

    End Sub

    Private Sub Label63_Click(sender As Object, e As EventArgs) Handles Label63.Click
        TabCD_DiasContractuales.Visible = False
        TabCD_HospedadosLista.Visible = False
        TabCD_HabitacionDetalle.Visible = False
        TabCD_DiasContractualesLista.Visible = False
        TabFN_GetCuentasCobrarPeriodo.Visible = False
        TabFN_Reclamaciones.Visible = False
        TabFN_DevolucionNotaCreditoAnt.Visible = False
        If TabFN_AnticipoReclamacionStatus IsNot Nothing Then
            TabFN_AnticipoReclamacionStatus.GetNotasXCliente("SOD", TextProveedor.Tag)
            TabFN_AnticipoReclamacionStatus.Visible = True
            TabFN_AnticipoReclamacionStatus.btnRetornar.Visible = True
            TabFN_AnticipoReclamacionStatus.BringToFront()
            TabFN_AnticipoReclamacionStatus.Show()
        End If
    End Sub
#End Region


End Class
