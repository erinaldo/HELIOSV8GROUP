Imports System.Threading
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.Presentation.WinForm
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class FormComprasRelacionadas
    Implements IProductoCompra

#Region "Fields"
    Private threadEntidades As Thread
    Public Property ListaEntidad As List(Of entidad)
    Dim entidadSA As New entidadSA
    Friend Delegate Sub SetDelegateEntidad(ByVal lista As List(Of entidad), tipo As String)
#End Region

#Region "Attributes"
    Public Property CompraSA As New DocumentoCompraDetalleSA
    Public Property ComprasSA As New DocumentoCompraSA
    Public Property IdCompra As Integer
#End Region

#Region "Constructors"
    Public Sub New(idDocumento As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormatoGridAvanzado(dgvCompra, False, False)
        IdCompra = idDocumento
        GetCombos()
        dgvCompra.DataSource = GetTableConfiguration()
        GetThreadEntidades()
    End Sub

#End Region

#Region "Proveedor"
    Private Sub GetThreadEntidades()
        ProgressBar2.Visible = True
        ProgressBar2.Style = ProgressBarStyle.Marquee
        threadEntidades = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetEntidades()))
        threadEntidades.Start()
    End Sub

    Private Sub GetEntidades()
        Dim ListaEntidades As New List(Of entidad)
        ListaEntidades = entidadSA.GetListarEntidad(New entidad With {.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR, .idEmpresa = Gempresas.IdEmpresaRuc, .idOrganizacion = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
        setDataSourceEntidad(ListaEntidades, "PR")
    End Sub

    Private Sub setDataSourceEntidad(GetEntidades As List(Of entidad), tipo As String)
        If Me.InvokeRequired Then
            Dim deleg As New SetDelegateEntidad(AddressOf setDataSourceEntidad)
            Invoke(deleg, New Object() {GetEntidades, tipo})
        Else
            ListaEntidad = New List(Of entidad)
            ListaEntidad = GetEntidades
            ProgressBar2.Visible = False
        End If
    End Sub
#End Region

#Region "Methods"
    Private Function GetTableConfiguration() As DataTable
        Dim dt As New DataTable
        With dt.Columns
            .Add("codigo")
            .Add("gravado")
            .Add("idProducto")
            .Add("item")
            .Add("um")
            .Add("vcmn")
            .Add("ivamn")
            .Add("totalmn")
            .Add("tipoExistencia")
            .Add("codigoLote")
            .Add("almacen")
        End With
        Return dt
    End Function

    Private Sub FinalizandoEventosGrid()
        dgvCompra.TableControl.CurrentCell.EndEdit()
        dgvCompra.TableControl.Table.TableDirty = True
        dgvCompra.TableControl.Table.EndEdit()
    End Sub

    Private Sub Grabar()
        FinalizandoEventosGrid()
        Dim FormatoFecha = New DateTime(cboAnio.Text, cboMesCompra.SelectedValue, TxtDia.Text, txtHora.Value.Hour, txtHora.Value.Minute, txtHora.Value.Second)

        Dim MontosCompra = GetTotalCompra()

        Dim be As New documento With
        {
        .Action = BaseBE.EntityAction.INSERT,
        .idEmpresa = Gempresas.IdEmpresaRuc,
        .idCentroCosto = GEstableciento.IdEstablecimiento,
        .tipoDoc = cboTipoDoc.SelectedValue,
        .fechaProceso = FormatoFecha,
        .moneda = "1",
        .idEntidad = txtProveedor.Tag,
        .entidad = txtProveedor.Text,
        .tipoEntidad = TIPO_ENTIDAD.PROVEEDOR,
        .nrodocEntidad = txtruc.Text,
        .nroDoc = txtSerie.Text.Trim & "-" & txtNumero.Text.Trim,
        .tipoOperacion = StatusTipoOperacion.COMPRA,
        .usuarioActualizacion = usuario.IDUsuario,
        .fechaActualizacion = DateTime.Now
        }

        be.documentocompra = New documentocompra With
        {
        .Action = BaseBE.EntityAction.INSERT,
        .codigoLibro = StatusCodigoLibroContable.REGISTRO_DE_COMPRAS,
        .idEmpresa = Gempresas.IdEmpresaRuc,
        .idCentroCosto = GEstableciento.IdEstablecimiento,
        .fechaLaboral = DateTime.Now,
        .fechaDoc = FormatoFecha,
        .fechaContable = GetPeriodo(FormatoFecha, True),
        .tipoDoc = cboTipoDoc.SelectedValue,
        .serie = txtSerie.Text.Trim,
        .numeroDoc = txtNumero.Text.Trim,
        .idProveedor = Integer.Parse(txtProveedor.Tag),
        .monedaDoc = "1",
        .tasaIgv = 0,
        .tcDolLoc = 0,
        .tipocambio = 0,
        .bi01 = MontosCompra.TotalBaseImponible,
        .bi02 = 0,
        .bi03 = 0,
        .bi04 = 0,
        .isc01 = 0,
        .isc02 = 0,
        .isc03 = 0,
        .igv01 = MontosCompra.TotalIva,
        .igv02 = 0,
        .igv03 = 0,
        .otc01 = 0,
        .otc02 = 0,
        .otc03 = 0,
        .otc04 = 0,
        .bi01us = 0,
        .bi02us = 0,
        .bi03us = 0,
        .bi04us = 0,
        .isc01us = 0,
        .isc02us = 0,
        .isc03us = 0,
        .igv01us = 0,
        .igv02us = 0,
        .igv03us = 0,
        .otc01us = 0,
        .otc02us = 0,
        .otc03us = 0,
        .otc04us = 0,
        .importeTotal = MontosCompra.Total,
        .importeUS = 0,
        .idPadre = IdCompra,
        .destino = TIPO_COMPRA.COMPRA,
        .estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO,
        .glosa = txtGlosa.Text,
        .tipoCompra = TIPO_COMPRA.COMPRA,
        .situacion = statusComprobantes.Normal,
        .tieneDetraccion = "N",
        .usuarioActualizacion = usuario.IDUsuario.ToString,
        .fechaActualizacion = DateTime.Now
        }

        be.documentocompra.documentocompradetalle = GetDetalleNota(be)
        ComprasSA.GrabarCompraAdicionalLoteExistente(be)
        Close()
    End Sub

    Private Function GetDetalleNota(ndocumento As documento) As List(Of documentocompradetalle)
        GetDetalleNota = New List(Of documentocompradetalle)
        Dim nroLotex = Nothing
        Dim objDetalle As documentocompradetalle
        For Each i In dgvCompra.Table.Records
            If Decimal.Parse(i.GetValue("totalmn")) <= 0 Then
                Throw New Exception("Debe ingresar un importe mayor a cero")
            End If

            objDetalle = New documentocompradetalle

            objDetalle.nrolote = i.GetValue("codigoLote").ToString()
            objDetalle.codigoLote = Integer.Parse(i.GetValue("codigoLote"))
            objDetalle.CustomRecursoCostoLote = New recursoCostoLote With {.codigoLote = i.GetValue("codigoLote")}
            objDetalle.IdEmpresa = Gempresas.IdEmpresaRuc
            objDetalle.IdEstablecimiento = GEstableciento.IdEstablecimiento
            objDetalle.tipoCompra = TIPO_COMPRA.COMPRA
            objDetalle.TipoOperacion = StatusTipoOperacion.COMPRA
            objDetalle.FechaDoc = ndocumento.fechaProceso
            objDetalle.FechaLaboral = DateTime.Now
            objDetalle.CuentaProvedor = "4212"
            objDetalle.NombreProveedor = txtProveedor.Text.Trim
            objDetalle.Serie = txtSerie.Text.Trim
            objDetalle.NumDoc = txtNumero.Text.Trim
            objDetalle.TipoDoc = ndocumento.tipoDoc
            objDetalle.idItem = Integer.Parse(i.GetValue("idProducto"))
            objDetalle.descripcionItem = i.GetValue("item")
            objDetalle.ItemEntregadototal = "S"
            objDetalle.tipoExistencia = i.GetValue("tipoExistencia")
            objDetalle.destino = i.GetValue("gravado")
            objDetalle.unidad1 = i.GetValue("um")
            objDetalle.monto1 = 0
            objDetalle.precioUnitario = 0
            objDetalle.precioUnitarioUS = 0
            objDetalle.importe = Decimal.Parse(i.GetValue("totalmn"))
            objDetalle.importeUS = 0
            objDetalle.montokardex = Decimal.Parse(i.GetValue("vcmn"))
            objDetalle.montoIsc = 0
            objDetalle.montoIgv = Decimal.Parse(i.GetValue("ivamn"))
            objDetalle.otrosTributos = 0
            objDetalle.montokardexUS = 0
            objDetalle.montoIscUS = 0
            objDetalle.montoIgvUS = 0
            objDetalle.otrosTributosUS = 0
            objDetalle.almacenRef = Integer.Parse(i.GetValue("almacen"))
            objDetalle.fechaEntrega = DateTime.Now
            objDetalle.estadoPago = "PN"
            objDetalle.usuarioModificacion = usuario.IDUsuario
            objDetalle.fechaModificacion = DateTime.Now

            'objDetalle.CustomInventarioMovimiento = GetInventario(objDetalle)
            GetDetalleNota.Add(objDetalle)
        Next
    End Function

    Private Sub GetCombos()
        Dim tablaDetalleSA As New tablaDetalleSA
        Dim periodoSA As New empresaPeriodoSA
        Dim almacenSA As New almacenSA

        cboMesCompra.DataSource = ListaDeMeses()
        cboMesCompra.DisplayMember = "Mes"
        cboMesCompra.ValueMember = "Codigo"
        cboMesCompra.SelectedValue = String.Format("{0:00}", DateTime.Now.Month)

        cboAnio.DataSource = periodoSA.GetListar_empresaPeriodo(New empresaPeriodo With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento})
        cboAnio.DisplayMember = "periodo"
        cboAnio.ValueMember = "periodo"
        cboAnio.Text = DateTime.Now.Year.ToString
        txtHora.Value = DateTime.Now

        Dim list As New List(Of String)
        list.Add("07")
        list.Add("08")
        list.Add("02")
        ListaComprobantes = New List(Of tabladetalle)
        ListaComprobantes = tablaDetalleSA.GetListaTablaDetalle(10, "1")

        Dim Comprobantes = (From n In ListaComprobantes
                            Where Not list.Contains(n.codigoDetalle)).ToList

        cboTipoDoc.DisplayMember = "descripcion"
        cboTipoDoc.ValueMember = "codigoDetalle"
        cboTipoDoc.DataSource = Comprobantes


        Dim ListaAlmacenes = almacenSA.GetListar_almacenesTipo(GEstableciento.IdEstablecimiento, "AF")
        Dim ggcStyle As GridTableCellStyleInfo = dgvCompra.TableDescriptor.Columns("almacen").Appearance.AnyRecordFieldCell
        ggcStyle.CellType = "ComboBox"
        ggcStyle.DataSource = ListaAlmacenes
        ggcStyle.ValueMember = "idAlmacen"
        ggcStyle.DisplayMember = "descripcionAlmacen"
        ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive
        dgvCompra.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
    End Sub

    Private Sub FillLSVEntidades(consulta As List(Of entidad))
        lsvProveedor.Items.Clear()
        '     Dim image = ImageList1.Images(0)
        For Each i In consulta
            Dim n As New ListViewItem(i.idEntidad)

            n.SubItems.Add(i.nombreCompleto)
            n.SubItems.Add(i.nrodoc)
            lsvProveedor.Items.Add(n)
        Next
    End Sub

    Public Class CamposMontos
        Public Property TotalIva As Decimal?
        Public Property TotalBaseImponible As Decimal?
        Public Property Total As Decimal?

        Public Sub New()
            TotalIva = 0
            TotalBaseImponible = 0
            Total = 0
        End Sub

    End Class

    Private Function GetTotalCompra() As CamposMontos
        Dim suma As Decimal = 0
        Dim sumaBase As Decimal = 0
        Dim sumaIva As Decimal = 0
        For Each i In dgvCompra.Table.Records
            suma += CDec(i.GetValue("totalmn"))
            sumaBase += CDec(i.GetValue("vcmn"))
            sumaIva += CDec(i.GetValue("ivamn"))

        Next
        GetTotalCompra = New CamposMontos With
        {
        .Total = suma,
        .TotalBaseImponible = sumaBase,
        .TotalIva = sumaIva
        }
    End Function

    Private Function ValidarGrabado() As Boolean
        Dim listaErrores As Integer = 0

        If txtSerie.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(txtSerie, "El campo serie es requerido")
            listaErrores += 1
        Else
            ErrorProvider1.SetError(txtSerie, Nothing)
        End If

        If txtNumero.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(txtNumero, "El campo número es requerido")
            listaErrores += 1
        Else
            ErrorProvider1.SetError(txtNumero, Nothing)
        End If

        If TxtDia.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(TxtDia, "El campo fecha es requerido")
            listaErrores += 1
        Else
            ErrorProvider1.SetError(TxtDia, Nothing)
        End If

        If txtProveedor.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(txtProveedor, "El campo persona es requerido")
            listaErrores += 1
        Else
            ErrorProvider1.SetError(txtProveedor, Nothing)
        End If

        If txtProveedor.Text.Trim.Length > 0 Then
            If txtProveedor.ForeColor = Color.Black Then
                ErrorProvider1.SetError(txtProveedor, "Verificar el ingreso correcto del personal")
                listaErrores += 1
            Else
                ErrorProvider1.SetError(txtProveedor, Nothing)
            End If
        Else
            'ErrorProvider1.SetError(TextPersona, Nothing)
        End If

        If txtGlosa.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(txtGlosa, "El campo glosa es requerido")
            listaErrores += 1
        Else
            ErrorProvider1.SetError(txtGlosa, Nothing)
        End If

        If listaErrores > 0 Then
            ValidarGrabado = False
        Else
            ValidarGrabado = True
        End If
    End Function

    Public Sub EnviarProducto(be As documentocompradetalle) Implements IProductoCompra.EnviarProducto
        If ValidacionEsCorrecta(be) Then
            Me.dgvCompra.Table.AddNewRecord.SetCurrent()
            Me.dgvCompra.Table.AddNewRecord.BeginEdit()
            Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", be.secuencia)
            Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", be.destino)
            Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", be.idItem)
            Me.dgvCompra.Table.CurrentRecord.SetValue("item", be.descripcionItem)
            Me.dgvCompra.Table.CurrentRecord.SetValue("um", be.unidad1)
            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("ivamn", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", be.tipoExistencia)
            Me.dgvCompra.Table.CurrentRecord.SetValue("codigoLote", be.CustomRecursoCostoLote.codigoLote)
            Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", be.almacenRef)
            Me.dgvCompra.Table.AddNewRecord.EndEdit()
        Else
            MessageBox.Show("El item ingresado ya se encuentra en la canasta!")
        End If
    End Sub

    Private Function ValidacionEsCorrecta(be As documentocompradetalle) As Boolean
        ValidacionEsCorrecta = True
        For Each i In dgvCompra.Table.Records
            If Integer.Parse(i.GetValue("codigo")) = be.secuencia AndAlso
                Integer.Parse(i.GetValue("almacen")) = be.almacenRef Then
                ValidacionEsCorrecta = False
                Exit For
            End If
        Next
    End Function
#End Region

#Region "Events"
    Private Sub FormComprasRelacionadas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim FormDocumentosAnexos As New FormDocumentosAnexos(IdCompra)
        FormDocumentosAnexos.StartPosition = FormStartPosition.CenterParent
        FormDocumentosAnexos.ShowDialog(Me)
    End Sub
    Sub GetDiasMes(mes As Integer, anio As Integer)
        Dim days As Integer = System.DateTime.DaysInMonth(anio, mes)
        TxtDia.MaxValue = days
        TxtDia.MinValue = 1

    End Sub

    Private Sub TxtDia_TextChanged(sender As Object, e As EventArgs) Handles TxtDia.TextChanged
        If cboMesCompra.Text.Trim.Length > 0 Then

        End If
    End Sub

    Private Sub cboMesCompra_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboMesCompra.SelectedValueChanged
        If Not IsNothing(cboMesCompra.SelectedValue) Then
            If IsNumeric(cboAnio.Text) AndAlso IsNumeric(cboMesCompra.SelectedValue) Then

                If TxtDia.Text.Trim.Length > 0 Then
                    GetDiasMes(Integer.Parse(cboMesCompra.SelectedValue), cboAnio.Text)
                Else
                    GetDiasMes(Integer.Parse(cboMesCompra.SelectedValue), cboAnio.Text)
                    TxtDia.Clear()
                End If
            End If
        End If
    End Sub

    Private Sub cboAnio_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboAnio.SelectedValueChanged
        If cboAnio.Text.Trim.Length > 0 Then
            TxtDia_TextChanged(sender, e)
        End If
    End Sub

    Private Sub txtProveedor_TextChanged(sender As Object, e As EventArgs) Handles txtProveedor.TextChanged
        txtProveedor.ForeColor = Color.Black
        txtProveedor.Tag = Nothing
        If txtProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            txtruc.Visible = True
        Else
            txtruc.Visible = False
        End If
    End Sub

    Private Sub TextPersona_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProveedor.KeyDown


        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        Else

            '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.PopupControlContainer4.Size = New Size(319, 128)
            Me.PopupControlContainer4.ParentControl = txtProveedor
            Me.PopupControlContainer4.ShowPopup(Point.Empty)
            Dim consulta As New List(Of entidad)
            consulta.Add(New entidad With {.nombreCompleto = "Agregar nuevo"})
            Dim consulta2 = (From n In ListaEntidad
                             Where n.nombreCompleto.StartsWith(txtProveedor.Text) Or n.nrodoc.StartsWith(txtProveedor.Text)).ToList
            consulta.AddRange(consulta2)
            '     consulta.Add(New entidad With {.idEntidad = 0, .nombreCompleto = "Agregar nuevo"})
            FillLSVEntidades(consulta)
            e.Handled = True

        End If

        If e.KeyCode = Keys.Down Then
            '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.PopupControlContainer4.Size = New Size(319, 128)
            Me.PopupControlContainer4.ParentControl = txtProveedor
            Me.PopupControlContainer4.ShowPopup(Point.Empty)
            lsvProveedor.Focus()
        End If
        '   End If

        ' e.SuppressKeyPress = True
        If e.KeyCode = Keys.Escape Then
            If Me.PopupControlContainer4.IsShowing() Then
                Me.PopupControlContainer4.HidePopup(PopupCloseType.Canceled)
            End If
        End If
    End Sub

    Private Sub PopupControlContainer4_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles PopupControlContainer4.CloseUp
        Me.Cursor = Cursors.WaitCursor

        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvProveedor.SelectedItems.Count > 0 Then
                If lsvProveedor.SelectedItems(0).SubItems(1).Text = "Agregar nuevo" Then
                    Dim f As New frmCrearENtidades
                    f.CaptionLabels(0).Text = "Nuevo proveedor"
                    f.strTipo = TIPO_ENTIDAD.PROVEEDOR
                    f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()
                    If f.Tag IsNot Nothing Then
                        Dim c = CType(f.Tag, entidad)
                        txtProveedor.Text = c.nombreCompleto
                        txtProveedor.Tag = c.idEntidad
                        txtruc.Visible = True
                        txtruc.Text = c.nrodoc
                        txtruc.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        txtProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        ListaEntidad.Add(c)
                    End If

                Else
                    txtProveedor.Text = lsvProveedor.SelectedItems(0).SubItems(1).Text
                    txtProveedor.Tag = lsvProveedor.SelectedItems(0).SubItems(0).Text
                    txtProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                    txtruc.Text = lsvProveedor.SelectedItems(0).SubItems(2).Text
                    txtruc.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                    txtruc.Visible = True
                End If
                'ListaMercaderiasXIdHijo(Val(txtSubCategoria.Tag), cboTipoExistencia.SelectedValue)
            End If
        End If

        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            txtProveedor.Focus()
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvProveedor.MouseDoubleClick
        If lsvProveedor.SelectedItems.Count > 0 Then
            PopupControlContainer4.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            Me.dgvCompra.Table.CurrentRecord.Delete()
        End If
    End Sub

    Private Sub btGrabar_Click(sender As Object, e As EventArgs) Handles btGrabar.Click
        Try
            If ValidarGrabado() Then
                If dgvCompra.Table.Records.Count > 0 Then
                    Grabar()
                Else
                    MsgBox("Debe ingresar items a la canasta", MsgBoxStyle.Exclamation, "Verificar canasta")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Atención")
        End Try
    End Sub

    Private Sub txtNumero_TextChanged(sender As Object, e As EventArgs) Handles txtNumero.TextChanged
        Select Case cboTipoDoc.SelectedValue
            Case "05", "55" ' NUMERO DE DIGITOS : 1
                txtNumero.MaxLength = 1

            Case "50", "51", "52", "53" ' NUMERO DE DIGITOS : 6
                txtNumero.MaxLength = 6

            Case "54" ' NUMERO DE DIGITOS : 20
                txtNumero.MaxLength = 20

            Case "02", "23", "25", "34", "35", "48", "89" ' NUMERO DE DIGITOS : 7
                txtNumero.MaxLength = 7

            Case "36", "01", "03", "04", "06", "07", "08" ' NUMERO DE DIGITOS : 8
                txtNumero.MaxLength = 8

            Case "56" ' NUMERO DE DIGITOS : 11
                txtNumero.MaxLength = 11

            Case "10", "22", "46" ' NUMERO DE DIGITOS : 20
                txtNumero.MaxLength = 20

            Case "11" ' 15 dig
                txtNumero.MaxLength = 15

            Case "12" To "19",
                "21", "24", "26", "27", "28", "29", "30", "32", "37",
                "42", "43", "44", "45", "49", "87", "88", "91", "96", "97", "98" 'NUMERO DE DIGITOS : 20
                txtNumero.MaxLength = 20

        End Select
    End Sub

    Private Sub txtSerie_TextChanged(sender As Object, e As EventArgs) Handles txtSerie.TextChanged
        Select Case cboTipoDoc.SelectedValue
            Case "05", "55" ' NUMERO DE DIGITOS : 1
                txtSerie.MaxLength = 1

            Case "50", "51", "52", "53" ' NUMERO DE DIGITOS : 3
                txtSerie.MaxLength = 3

            Case "54" ' NUMERO DE DIGITOS : 3
                txtSerie.MaxLength = 3

            Case "02", "23", "25", "34", "35", "48", "89" ' NUMERO DE DIGITOS : 4
                txtSerie.MaxLength = 4

            Case "36", "01", "03", "04", "06", "07", "08",
                "56", "10", "22", "46" ' NUMERO DE DIGITOS : 4
                txtSerie.MaxLength = 4

            Case "11" To "19",
                "21", "24", "26", "27", "28", "29", "30", "32", "37",
                "42", "43", "44", "45", "49", "87", "88", "91", "96", "97", "98" 'NUMERO DE DIGITOS : 20
                txtSerie.MaxLength = 20

        End Select
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellChanged(sender As Object, e As GridTableControlEventArgs) Handles dgvCompra.TableControlCurrentCellChanged

        Dim cc As GridCurrentCell = dgvCompra.TableControl.CurrentCell
        cc.ConfirmChanges()
        Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)

        If style.TableCellIdentity.Column.Name = "totalmn" Then
            Dim text As String = cc.Renderer.ControlText

            If text.Trim.Length > 0 Then
                Dim value As Decimal = Convert.ToDecimal(text)
                cc.Renderer.ControlValue = value
                CalculosByMontoTotal(value)
            End If

        End If

        'If Not IsNothing(cc) Then
        '    Select Case cc.ColIndex
        '        Case 7 ' cantidad
        '            'Calculos()
        '            CalculosByMontoTotal(cc)
        '    End Select
        'End If


        '    Dim q = dgvCompra.TableModel(cc.RowIndex, cc.ColIndex).CellValue

    End Sub

    Private Sub CalculosByMontoTotal(MontoTotalFila As Decimal)
        Dim r As Record = dgvCompra.Table.CurrentRecord
        Dim BaseImponible = CalculoBaseImponible(MontoTotalFila, 1.18)
        Dim iva = CalculoIva(BaseImponible, 0.18)

        ValidandoMontoTotalCuadre(r, BaseImponible, iva)

        r.SetValue("vcmn", CDec(BaseImponible).ToString("N2"))
        r.SetValue("ivamn", CDec(iva).ToString("N2"))
    End Sub

    Private Sub ValidandoMontoTotalCuadre(r As Record, ByRef VC As Decimal, Igv As Decimal)

        Dim ColTotalRecord As Decimal = CalculoTotal(VC, Igv)
        ColTotalRecord = Math.Round(ColTotalRecord, 2)
        If ColTotalRecord > CDec(r.GetValue("totalmn")) Then
            Dim diferenciaMayor = Math.Round(ColTotalRecord - CDec(r.GetValue("totalmn")), 2)
            'se debe restar la diferencia a la base imponible
            VC = VC - diferenciaMayor
        End If

        If ColTotalRecord < CDec(r.GetValue("totalmn")) Then
            Dim diferenciaMayor = Math.Round(CDec(r.GetValue("totalmn") - ColTotalRecord), 2)
            'se debe sumar la diferencia a la base imponible
            VC = VC + diferenciaMayor
        End If

    End Sub

    Private Sub dgvCompra_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCompra.TableControlCellClick

    End Sub


#End Region


End Class