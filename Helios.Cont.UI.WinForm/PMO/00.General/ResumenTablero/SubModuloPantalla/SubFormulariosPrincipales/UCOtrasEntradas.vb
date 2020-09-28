Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping

Public Class UCOtrasEntradas
#Region "Attributes"
    Public Property CompraSA As New DocumentoCompraSA
    Public Property TablaSA As New tablaDetalleSA
    Private listaOperacion As List(Of tabladetalle)
    Dim Alert As Alert
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
#End Region

#Region "Methods"

    Public Sub CargarComplementos()
        listaOperacion = TablaSA.GetListaTablaDetalle(12, "1")
        FormatoGridAvanzado(dgvCompras, True, False, 9.0F, SelectionMode.MultiExtended)
        OrdenamientoGrid(dgvCompras, False)
    End Sub


    Private Sub EliminarEntrada()
        Dim r As Record = dgvCompras.Table.CurrentRecord
        If r IsNot Nothing Then
            CompraSA.AnularEntradainv(New documento With {.idDocumento = Integer.Parse(r.GetValue("idDocumento"))})
            'compraSA.EliminarEntradainv(New documento With {.idDocumento = Integer.Parse(r.GetValue("idDocumento"))})
            Alert = New Alert("Entrada anulada", alertType.info)
            Alert.TopMost = True
            Alert.Show()
            r.Delete()
            dgvCompras.Refresh()
        End If
    End Sub

    Private Sub GetMovDia(fechaLab As Date, idEstable As Integer)

        Dim dt As New DataTable("Movimientos")
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("destino", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))

        dt.Columns.Add(New DataColumn("tipoDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("TipoPersona ", GetType(String)))

        dt.Columns.Add(New DataColumn("importeTotal", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeUS", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("tieneAsiento", GetType(String)))

        Dim str As String
        For Each i As documentocompra In CompraSA.GetListarMvimientosAlmacenPorDia(Gempresas.IdEmpresaRuc, idEstable, TIPO_COMPRA.OTRAS_ENTRADAS, StatusTipoConsulta.XUNIDAD_ORGANICA, fechaLab).ToList
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = listaOperacion.Where(Function(o) o.codigoDetalle = i.tipoOperacion).Select(Function(o) o.descripcion).FirstOrDefault

            dr(2) = str
            dr(3) = i.tipoDoc
            dr(4) = i.serie
            dr(5) = i.numeroDoc
            dr(6) = i.tipoDocEntidad
            dr(7) = i.NroDocEntidad
            dr(8) = i.NombreEntidad
            dr(9) = i.TipoPersona
            dr(10) = i.importeTotal
            dr(11) = i.tcDolLoc
            dr(12) = i.importeUS
            dr(13) = i.monedaDoc

            If i.estadoPago = TIPO_COMPRA.COMPRA_ANULADA Then
                dr(14) = "ANULADA"
            Else
                dr(14) = i.estadoPago
            End If
            dr(15) = If(i.aprobado = "S", "-SI-", "-NO-")
            dt.Rows.Add(dr)
        Next
        dgvCompras.DataSource = dt
        PictureLoad.Visible = False
        BunifuFlatButton5.Enabled = True
    End Sub

    Private Sub GetMovPorPeriodo(intIdEstablecimiento As Integer, strPeriodo As String)

        Dim dt As New DataTable("Movimientos")
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("destino", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))

        dt.Columns.Add(New DataColumn("tipoDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("TipoPersona ", GetType(String)))

        dt.Columns.Add(New DataColumn("importeTotal", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeUS", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("tieneAsiento", GetType(String)))

        Dim str As String
        For Each i As documentocompra In CompraSA.GetListarPorPeriodoEntradas(Gempresas.IdEmpresaRuc, intIdEstablecimiento, strPeriodo, TIPO_COMPRA.OTRAS_ENTRADAS, StatusTipoConsulta.XUNIDAD_ORGANICA).Where(Function(o) o.tipoCompra = TIPO_COMPRA.OTRAS_ENTRADAS).ToList
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = listaOperacion.Where(Function(o) o.codigoDetalle = i.tipoOperacion).Select(Function(o) o.descripcion).FirstOrDefault

            dr(2) = str
            dr(3) = i.tipoDoc
            dr(4) = i.serie
            dr(5) = i.numeroDoc
            dr(6) = i.tipoDocEntidad
            dr(7) = i.NroDocEntidad
            dr(8) = i.NombreEntidad
            dr(9) = i.TipoPersona
            dr(10) = i.importeTotal
            dr(11) = i.tcDolLoc
            dr(12) = i.importeUS
            dr(13) = i.monedaDoc

            If i.estadoPago = TIPO_COMPRA.COMPRA_ANULADA Then
                dr(14) = "ANULADA"
            Else
                dr(14) = i.estadoPago
            End If
            dr(15) = If(i.aprobado = "S", "-SI-", "-NO-")
            dt.Rows.Add(dr)
        Next
        dgvCompras.DataSource = dt
        PictureLoad.Visible = False
        BunifuFlatButton5.Enabled = True
    End Sub


#End Region

#Region "Events"
    Private Sub BunifuFlatButton5_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton5.Click
        Try


            Dim f As New FormFiltroAvanzadoPeriodo()
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
            If f.Tag IsNot Nothing Then
                Dim periodoSel = CType(f.Tag, DateTime?)
                PictureLoad.Visible = True
                BunifuFlatButton5.Enabled = False
                GetMovPorPeriodo(GEstableciento.IdEstablecimiento, GetPeriodo(periodoSel, True))
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton3.Click
        Dim f As New FormFiltroAvanzadoDia()
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        If f.Tag IsNot Nothing Then
            Dim FechaSel = CType(f.Tag, DateTime?)
            PictureLoad.Visible = True
            BunifuFlatButton5.Enabled = False
            GetMovDia(FechaSel, GEstableciento.IdEstablecimiento)
        End If
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        'LoadingAnimator.Wire(Me.dgvMov.TableControl)
        Try
            ' If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.ANULAR_ENTRADA_Botón___, AutorizacionRolList) Then
            If Not IsNothing(Me.dgvCompras.Table.CurrentRecord) Then

                If MessageBox.Show("Desea anular el registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    EliminarEntrada()
                End If

            Else
                MessageBox.Show("Debe seleccionar un item válido!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                LoadingAnimator.UnWire(Me.dgvCompras.TableControl)
            End If
            'Else
            '    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'End If
        Catch ex As Exception
            Alert = New Alert(ex.Message, alertType.warning)
            Alert.TopMost = True
            Alert.Show()
        End Try

        'LoadingAnimator.UnWire(Me.dgvMov.TableControl)
    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click
        Dim r As Record = dgvCompras.Table.CurrentRecord
        Dim CompraDetSA As New DocumentoCompraDetalleSA
        If Not IsNothing(r) Then
            ClipBoardDocumento = New documento
            ClipBoardDocumento.documentocompra = CompraSA.UbicarDocumentoCompra(Val(r.GetValue("idDocumento")))
            'Dim listaDetalle = CompraDetSA.UbicarDetalleCompraEval(Val(r.GetValue("idDocumento")))
            Dim listaDetalle = CompraDetSA.GetUbicarDetalleCompraLote(Val(r.GetValue("idDocumento")))
            ClipBoardDocumento.documentocompra.documentocompradetalle = listaDetalle
            MessageBox.Show("Comprobante copiado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
        PictureLoad.Visible = True
        Try
            Dim r As Record = Me.dgvCompras.Table.CurrentRecord
            If r IsNot Nothing Then
                Dim f As New FormCrearCompra(Integer.Parse(r.GetValue("idDocumento")))
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog(Me)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        PictureLoad.Visible = False
    End Sub

    Private Sub btnNuevaVenta_Click(sender As Object, e As EventArgs) Handles btnNuevaVenta.Click
        Me.Cursor = Cursors.WaitCursor

        'If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.NUEVA_COMPRA_Formulario___, AutorizacionRolList) Then
        If validarPermisos(PermisosDelSistema.ENTRADA_INVENTARIO_, AutorizacionRolList) = 1 Then
            Dim f As New FormCrearCompra("ALMACEN")
            f.ComboComprobante.Enabled = False
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Me.Cursor = Cursors.Default
    End Sub
#End Region

End Class
