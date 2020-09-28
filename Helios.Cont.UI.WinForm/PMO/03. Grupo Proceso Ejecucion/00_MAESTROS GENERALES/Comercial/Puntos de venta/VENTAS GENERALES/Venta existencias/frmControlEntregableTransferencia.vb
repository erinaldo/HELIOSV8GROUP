Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Imports System.Collections
Imports System.Collections.Specialized
Imports Syncfusion.Windows.Forms.Tools
Public Class frmControlEntregableTransferencia
    Inherits frmMaster

    Dim listacondicion As New List(Of documentoguiaDetalleCondicion)
    Dim listaDocumentoGuiaDet As New List(Of documentoguiaDetalle)
    Dim listaDocumentoGuiaCondicion As New List(Of documentoguiaDetalleCondicion)
    Dim estado As Integer
    Public strTipo As String
    Public Property ListaAsientonTransito As New List(Of asiento)
    Dim TotalMN As Decimal
    Dim totalME As Decimal
    Dim importeNeto As Decimal
    Dim importeNetoUS As Decimal
    Dim cuentaMascaraSA As New cuentaMascaraSA
    Dim cuentaMascara As New cuentaMascara
    Dim idAlmacenOrigen As Integer

    Public Sub New(idDocumento As Integer)

        InitializeComponent()
        GridCFG(dgvOrdenCompra)
        GetTableGrid()
        UbicarDocumentoGuiaRemision(idDocumento)
        btGrabar.Visible = True
        DateTimePickerAdv1.Value = New Date(CInt(AnioGeneral), CInt(MesGeneral), DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        GradientPanel2.Visible = True
        Me.Size = New System.Drawing.Size(1073, 637)
        ToolStripButton3.Visible = False
    End Sub

    Public Sub New(idDocumento As Integer, intSecuencia As Integer)

        InitializeComponent()
        GridCFG(dgvOrdenCompra)
        GetTableGrid()
        UbicarDocumentoGuiaRemisionParcial(idDocumento)
        estado = 1
        btGrabar.Visible = False
        GradientPanel2.Visible = False
        Me.Size = New System.Drawing.Size(710, 637)
        ToolStripButton3.Visible = True
    End Sub

#Region "TIMER"
    Sub parpadeo()
        Static parpadear As Boolean
        parpadear = Not parpadear
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If TiempoRestante > 0 Then
            parpadeo()

            'lblAgregar.Visible = True
            'lblMensaje.Visible = True
            'tsSave.Enabled = False
            'lblMensaje.Text = "Agregar otro en: " & TiempoRestante
            TiempoRestante = TiempoRestante - 1
        ElseIf TiempoRestante = 0 Then
            Timer1.Enabled = False
            'lblEstado.ForeColor = Color.Navy
            'lblEstado.BackColor = Color.Transparent
            PanelError.Visible = False
            '      Dispose()
        Else
            Timer1.Enabled = False
            'Ejecuta tu función cuando termina el tiempo
            TiempoEjecutar(10)

        End If
    End Sub
    Private TiempoRestante As Integer
    Public Sub TimerOn(ByRef Interval As Short)
        If Interval > 0 Then
            Timer1.Enabled = True
        Else
            Timer1.Enabled = False
        End If

    End Sub
    Public Function TiempoEjecutar(ByVal Tiempo As Integer)
        TiempoEjecutar = ""
        TiempoRestante = Tiempo  ' 1 minutos=60 segundos 
        Timer1.Interval = 400

        Call TimerOn(1000) ' Hechanos a andar el timer
    End Function
#End Region

    Sub GridCFG(grid As GridGroupingControl)
        grid.TopLevelGroupOptions.ShowCaption = False
        Dim colorx As New GridMetroColors()
        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        grid.SetMetroStyle(colorx)
        grid.BorderStyle = System.Windows.Forms.BorderStyle.None

        'Me.gridGroupingControl1.BrowseOnly = true
        'Me.gridGroupingControl1.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        'Me.gridGroupingControl1.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        'Me.gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One
        grid.TableOptions.SelectionBackColor = Color.Gray
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.Format = "MMM dd yyyy"
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.Hide
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).HeaderText = "Date"
        'Me.gridGroupingControl1.TableDescriptor.Columns(1).HeaderText = "Category"
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.Currency
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromArgb(168, 178, 189)
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.TextAlign = GridTextAlign.Left
        'this.gridGroupingControl1.TableDescriptor.Columns["Amount"].Width = (this.tableLayoutPanel3.Width / 5) - 50;
        grid.AllowProportionalColumnSizing = False
        grid.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        grid.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        grid.Table.DefaultColumnHeaderRowHeight = 25
        grid.Table.DefaultRecordRowHeight = 20
        grid.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub


#Region "Clases Asientos"

    Private Shared datos As List(Of Asientos_MN)
    Private Shared datosMov As List(Of Movimientos)
    ' Asiento contable Class.
    Private Class Asientos_MN
        Public Property AsientoID As Integer
        Public Property NombreAsiento As String
        Public Property Tipo As String
        'Public Property Country As String

        Public Shared Function GetAsientos() As List(Of Asientos_MN)

            If datos Is Nothing Then
                datos = New List(Of Asientos_MN)
            End If

            Return datos
        End Function



        Private Sub AddAsiento(objAsiento As Asientos_MN)
            datos.Add(objAsiento)
        End Sub



    End Class
    Public Class Movimientos

        Public Property IdMovimiento As Integer
        Public Property AsientoID As Integer
        Public Property Cuenta As String
        Public Property Descripcion As String
        Public Property Tipo As String
        Public Property Importemn As Decimal
        Public Property Importeme As Decimal


        Public Shared Function GetMovimientos() As List(Of Movimientos)

            If datosMov Is Nothing Then
                datosMov = New List(Of Movimientos)
            End If

            Return datosMov
        End Function

        Public Sub AddMovimiento(nMovimiento As Movimientos)
            datosMov.Add(nMovimiento)
        End Sub
    End Class
    ' Detalle movimientos del asiento Class.


    Private Sub DeletePorID(id As Integer)

        Dim queryResults = (From cust In datos _
                           Where cust.AsientoID = id).First
        datos.Remove(queryResults)

        Dim ListaMov = (From n In datosMov _
                  Where n.AsientoID = id).ToList

        For Each i In ListaMov
            datosMov.Remove(i)
        Next

        'lstAsientos.DataSource = Nothing
        'lstAsientos.DisplayMember = "NombreAsiento"
        'lstAsientos.ValueMember = "AsientoID"
        'lstAsientos.DataSource = datos

        'If Not datosMov.Count > 0 Then
        '    dgvMovimiento.Rows.Clear()
        'End If

    End Sub

    Private Sub DeleteMovimientoID(id As Integer)

        Dim queryResults = (From cust In datosMov _
                           Where cust.IdMovimiento = id).First
        datosMov.Remove(queryResults)

        'If Not datosMov.Count > 0 Then
        '    dgvMovimiento.Rows.Clear()
        'End If

    End Sub

    Private Sub ubicarMovimientoporID(id As Integer)

        Dim queryResults = (From cust In datosMov _
                           Where cust.AsientoID = id).ToList

        'If queryResults.Count > 0 Then
        '    dgvMovimiento.Rows.Clear()
        '    For Each I As Movimientos In queryResults
        '        If I.Tipo = "D" Then
        '            dgvMovimiento.Rows.Add(I.AsientoID, I.Cuenta, I.Descripcion, I.Tipo, I.Importemn, I.Importeme, "0.00", "0.00", I.IdMovimiento)
        '        ElseIf I.Tipo = "H" Then
        '            dgvMovimiento.Rows.Add(I.AsientoID, I.Cuenta, I.Descripcion, I.Tipo, "0.00", "0.00", I.Importemn, I.Importeme, I.IdMovimiento)
        '        End If

        '    Next
        '    lblEstado.Text = "Listado de movimientos"
        'Else
        '    dgvMovimiento.Rows.Clear()
        'End If


    End Sub


    Private Function ListarMovimientoporAsiento(id As Integer) As List(Of Movimientos)

        Dim queryResults = (From cust In datosMov _
                           Where cust.AsientoID = id).ToList


        Return queryResults
    End Function

    Private Function SumatoriaMovimientosMN(idAsiento As Integer, strTipo As String) As Decimal
        Dim queryResults = (From cust In datosMov _
                        Where cust.AsientoID = idAsiento _
                        And cust.Tipo = strTipo _
                        Select cust.Importemn).Sum


        Return queryResults
    End Function

    Private Function SumatoriaMovimientosME(idAsiento As Integer, strTipo As String) As Decimal
        Dim queryResults = (From cust In datosMov _
                        Where cust.AsientoID = idAsiento _
                        And cust.Tipo = strTipo _
                        Select cust.Importeme).Sum


        Return queryResults
    End Function
#End Region


    Sub GetTableGrid()
        Dim dt As New DataTable()

        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("secuencia", GetType(Integer))
        dt.Columns.Add("cantidad", GetType(Integer))
        dt.Columns.Add("pendiente", GetType(Integer))
        dt.Columns.Add("total", GetType(Integer))
        dt.Columns.Add("descripcionItem", GetType(String))
        dt.Columns.Add("cantEntregado", GetType(Integer))
        dt.Columns.Add("cantObservado", GetType(Integer))
        dt.Columns.Add("observacion", GetType(String))
        dt.Columns.Add("totalItem", GetType(Decimal))
        dt.Columns.Add("tipoExistencia", GetType(String))
        dt.Columns.Add("importeMN", GetType(Decimal))
        dt.Columns.Add("importeME", GetType(Decimal))
        dt.Columns.Add("puMN", GetType(Decimal))
        dt.Columns.Add("puME", GetType(Decimal))
        dt.Columns.Add("unidad", GetType(String))
        dt.Columns.Add("destino", GetType(String))
        dt.Columns.Add("almacenRef", GetType(Integer))
        dt.Columns.Add("idItem", GetType(String))
      

        dgvOrdenCompra.DataSource = dt

    End Sub

    Public Sub Grabar()
        Dim objdocumentoSA As New DocumentoGuiaDetalleCondicionSA
        Dim condicion As New documentoguiaDetalleCondicion
        Dim asiento As New List(Of asiento)
        Dim listaDetalle As New List(Of documentoguiaDetalle)
        Dim objListaGuia As New documentoguiaDetalle
        Dim documento As New documento

        For Each r As Record In dgvOrdenCompra.Table.Records
            condicion = New documentoguiaDetalleCondicion
            With condicion
                .idDocumento = r.GetValue("idDocumento")
                .secuencia = r.GetValue("secuencia")
                .cantConforme = r.GetValue("cantEntregado")
                .descripcionCondicion = r.GetValue("descripcionItem")
                .cantObservado = r.GetValue("cantObservado")
                .estadoCondcion = r.GetValue("cantEntregado") + (r.GetValue("total") - r.GetValue("pendiente"))
                .usuarioActualizacion = "MAYKOL"
                .nombreRececpcion = txtnombreRecpcion.Text
                .dniRecepcion = txtdniRecepcion.Text
                .estado = "PN"
                .status = 1
                .fechaActualizacion = Date.Now
            End With
            listacondicion.Add(condicion)

            objListaGuia = New documentoguiaDetalle
            With objListaGuia
                .idDocumento = r.GetValue("idDocumento")
                .secuencia = r.GetValue("secuencia")
                .idEmpresa = Gempresas.IdEmpresaRuc
                .IdEstablecimiento = GEstableciento.IdEstablecimiento
                .Serie = txtSerieGuia.Text
                .numerodoc = txtNumeroGuia.Text
                .pendiente = (r.GetValue("pendiente") - r.GetValue("cantEntregado"))
                .cantConforme = r.GetValue("cantEntregado")
                .cantidad = r.GetValue("totalItem")
                .descripcionItem = r.GetValue("descripcionItem")
                .destino = r.GetValue("destino")
                .fecha = txtFecha.Value
                .tipoExistencia = r.GetValue("tipoExistencia")
                .idItem = r.GetValue("idItem")
                .unidadMedida = r.GetValue("unidad")
                .almacenRef = r.GetValue("almacenRef")
                .destino = r.GetValue("destino")
                .precioUnitario = r.GetValue("puMN")
                .precioUnitarioUS = r.GetValue("puME")
                .importeMN = r.GetValue("importeMN")
                .importeME = r.GetValue("importeME")
                .usuarioModificacion = "Maykol"
                .fechaModificacion = DateTime.Now
                .idDocumentoPadre = idAlmacenOrigen
            End With
            listaDetalle.add(objListaGuia)
        Next

        AsientoTransferenciaEntreAlmacenes()

        documento.asiento = ListaAsientonTransito
        'REGISTRANDO LA GUIA DE REMISION

        If (strTipo = "TRANSFERENCIA") Then
            objdocumentoSA.SaveGuiaRemisionCondicionTransferenciaAlmacenSC(listacondicion, listaDetalle, documento)
        Else
            objdocumentoSA.SaveGuiaRemisionCondicion(listacondicion, listaDetalle)
        End If


    End Sub

    Sub AsientoTransferenciaEntreAlmacenes()
        Dim listaMovimiento As New List(Of Movimientos)
        Dim asientoBL As New asiento
        Dim nMovimiento As New movimiento
        Dim mascaraSA As New mascaraContable2SA
        Dim mascaraExistenciasSA As New mascaraContableExistenciaSA
        Try
            ListaAsientonTransito = New List(Of asiento)

            asientoBL = New asiento
            asientoBL.idEmpresa = Gempresas.IdEmpresaRuc
            asientoBL.idCentroCostos = GEstableciento.IdEstablecimiento
            asientoBL.idEntidad = CInt(txtProveedor.Tag)
            asientoBL.nombreEntidad = txtProveedor.Text
            asientoBL.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
           
            asientoBL.fechaProceso = txtFecha.Value
            asientoBL.codigoLibro = "13"
            asientoBL.tipo = "D"
            asientoBL.tipoAsiento = ASIENTO_CONTABLE.OTRAS_ENTRADAS
            asientoBL.importeMN = CDec(TotalMN)
            asientoBL.importeME = CDec(totalME)
            asientoBL.glosa = "Tranferencia entre almacenes - recepción" ' Glosa()

            For Each r As Record In dgvOrdenCompra.Table.Records
                nMovimiento = New movimiento
                Select Case r.GetValue("tipoExistencia")
                    'Case "01"
                    '    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "TRANS01.1")
                    '    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                    'Case "02"
                    '    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "02", "ITEM", "TRANS02.1")
                    '    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                    'Case "03"
                    '    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "03", "ITEM", "TRANS03.1")
                    '    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                    'Case "04"
                    '    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "04", "ITEM", "TRANS04.1")
                    '    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                    'Case "05"
                    '    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "05", "ITEM", "TRANS05.1")
                    '    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                    'Case "06"
                    '    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "06", "ITEM", "TRANS06.1")
                    '    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                    'Case "07"
                    '    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "07", "ITEM", "TRANS07.1")
                    '    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                    'Case "08"
                    '    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "08", "ITEM", "TRANS08.1")
                    '    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica

                    Case "01"
                        cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "TRANS01.1")
                        nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                    Case "02"
                        cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "02", "ITEM", "TRANS02.1")
                        nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                    Case "03"
                        cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "03", "ITEM", "ALM03.1")
                        nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                    Case "04"
                        cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "04", "ITEM", "ALM04.1")
                        nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                    Case "05"
                        cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "05", "ITEM", "ALM05.1")
                        nMovimiento.cuenta = cuentaMascara.cuentaEspecifica

                End Select

                nMovimiento.descripcion = r.GetValue("descripcionItem")
                nMovimiento.tipo = "D"
                nMovimiento.monto = CDec(r.GetValue("importeMN"))
                nMovimiento.montoUSD = CDec(r.GetValue("importeME"))
                nMovimiento.usuarioActualizacion = "Jiuni"
                nMovimiento.fechaActualizacion = DateTime.Now
                asientoBL.movimiento.Add(nMovimiento)
                asientoBL.movimiento.Add(HaberTransferenciaMOv(r))
            Next

            ListaAsientonTransito.Add(asientoBL)
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try
    End Sub

    Function HaberTransferenciaMOv(r As Record) As movimiento
        Dim mascaraSA As New mascaraContable2SA
        Dim mascaraExistenciasSA As New mascaraContableExistenciaSA
        Dim nMovimiento As New movimiento

        nMovimiento = New movimiento
        Select Case r.GetValue("tipoExistencia")
            Case "01"
                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "ALM01.2")
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                'Case "02"
                '    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "TRANS02.2")
                'nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            Case "03"
                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "03", "ITEM", "ALM03.2")
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            Case "04"
                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "04", "ITEM", "ALM04.2")
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            Case "05"
                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "05", "ITEM", "ALM05.2")
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                'Case "06"
                '    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "TRANS06.2")
                '    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                'Case "07"
                '    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "TRANS07.2")
                '    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                'Case "08"
                '    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "TRANS08.2")
                '    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
        End Select
        nMovimiento.descripcion = r.GetValue("descripcionItem")
        nMovimiento.tipo = "H"
        nMovimiento.monto = CDec(r.GetValue("importeMN"))
        nMovimiento.montoUSD = CDec(r.GetValue("importeME"))
        nMovimiento.usuarioActualizacion = "Jiuni"
        nMovimiento.fechaActualizacion = DateTime.Now

        Return nMovimiento
    End Function


    Public Sub UbicarDocumentoGuiaRemisionParcial(ByVal intIdDocumento As Integer)
        Dim objDocCompra As New DocumentoGuiaSA
        Dim objDocCompraDet As New DocumentoGuiaDetalleSA
        Dim objDocCompraDetCondicion As New DocumentoGuiaDetalleCondicionSA
        Dim objEntidad As New entidadSA
        Dim nEntidad As New entidad
        'Dim objListaOtros As New List(Of documentoOtrosDatos)

        Try
            With objDocCompra.UbicarGuiaPorIdDocumento(intIdDocumento)
                If Not IsNothing(.fechaDoc) Then
                    txtFecha.Value = .fechaDoc
                End If
                If (.idEntidad = 0) Then
                    txtRuc.Text = ""
                    txtProveedor.Tag = ""
                    txtProveedor.Text = ""
                Else
                    nEntidad = objEntidad.UbicarEntidadPorID(.idEntidad).First()
                    txtRuc.Text = nEntidad.nrodoc
                    txtProveedor.Tag = nEntidad.idEntidad
                    txtProveedor.Text = nEntidad.nombreCompleto
                End If

            End With

            'DETALLE DE LA COMPRA
            dgvOrdenCompra.Table.Records.DeleteAll()


            Me.dgvOrdenCompra.TableDescriptor.Columns("cantEntregado").Width = 0
            Me.dgvOrdenCompra.TableDescriptor.Columns("observacion").Width = 0
            Me.dgvOrdenCompra.TableDescriptor.Columns("pendiente").Width = 0

            listaDocumentoGuiaDet = objDocCompraDet.UbicarGuiaDetallePorIdDocumentoguia(intIdDocumento)
            For Each i In listaDocumentoGuiaDet
                Me.dgvOrdenCompra.Table.AddNewRecord.SetCurrent()
                Me.dgvOrdenCompra.Table.AddNewRecord.BeginEdit()
                Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("idDocumento", i.idDocumento)
                Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("secuencia", i.secuencia)
                Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("cantidad", i.idItem)
                Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("pendiente", (i.cantidad - i.cantConforme))
                Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("total", i.cantidad)
                Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("descripcionItem", i.descripcionItem)
                Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("cantEntregado", 0)
                Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("cantObservado", i.secuenciaRef)
                Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("observacion", Nothing)
                Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("totalItem", i.cantidad)
                Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("tipoExistencia", i.tipoExistencia)
                Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("importeMN", i.importeMN)
                Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("importeME", i.importeME)
                Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("puMN", i.precioUnitario)
                Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("puME", i.precioUnitarioUS)
                Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("unidad", i.unidadMedida)
                Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("destino", i.destino)
                Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("almacenRef", i.almacenRef)
                Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("idItem", i.idItem)

                Me.dgvOrdenCompra.Table.AddNewRecord.EndEdit()

                TotalMN += i.importeMN
                totalME += i.importeME

            Next

            txtSerieGuia.Text = listaDocumentoGuiaDet(0).Serie
            txtNumeroGuia.Text = listaDocumentoGuiaDet(0).numerodoc

            'txtnombreRecpcion .Text = 
            '    txtdniRecepcion.Text = 

            listacondicion = objDocCompraDetCondicion.UbicarDocumentoGuiaDetCondicionFull(intIdDocumento)
            'For Each i In listaDocumentoGuiaCondicion
            '    'Me.dgvHistorialDetalle.Table.AddNewRecord.SetCurrent()
            '    'Me.dgvHistorialDetalle.Table.AddNewRecord.BeginEdit()
            '    'Me.dgvHistorialDetalle.Table.CurrentRecord.SetValue("idDocumento", i.idDocumento)
            '    'Me.dgvHistorialDetalle.Table.CurrentRecord.SetValue("secuencia", i.secuencia)
            '    'Me.dgvHistorialDetalle.Table.CurrentRecord.SetValue("cantidad", i.cantidad)
            '    'Me.dgvHistorialDetalle.Table.CurrentRecord.SetValue("descripcionItem", i.nombreCondicion)
            '    'Me.dgvHistorialDetalle.Table.CurrentRecord.SetValue("observacion", i.observaciones)
            '    'Me.dgvHistorialDetalle.Table.CurrentRecord.SetValue("status", 1)
            '    'Me.dgvHistorialDetalle.Table.AddNewRecord.EndEdit()
            'Next

        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try

    End Sub

    Public Sub UbicarDocumentoGuiaRemision(ByVal intIdDocumento As Integer)
        Dim objDocCompra As New DocumentoGuiaSA
        Dim objDocCompraDet As New DocumentoGuiaDetalleSA
        Dim objEntidad As New entidadSA
        Dim nEntidad As New entidad
        Dim objDocCompraDetCondicion As New DocumentoGuiaDetalleCondicionSA
        'Dim objListaOtros As New List(Of documentoOtrosDatos)

        Try
            With objDocCompra.UbicarGuiaPorIdDocumento(intIdDocumento)
                If Not IsNothing(.fechaDoc) Then
                    txtFecha.Value = .fechaDoc
                End If

                If ((.idEntidad) <> 0) Then
                    nEntidad = objEntidad.UbicarEntidadPorID(.idEntidad).First()
                    txtRuc.Text = nEntidad.nrodoc
                    txtProveedor.Tag = nEntidad.idEntidad
                    txtProveedor.Text = nEntidad.nombreCompleto
                Else

                End If


            End With

            'DETALLE DE LA COMPRA
            dgvOrdenCompra.Table.Records.DeleteAll()
            Me.dgvOrdenCompra.TableDescriptor.Columns("cantEntregado").Width = 90
            Me.dgvOrdenCompra.TableDescriptor.Columns("cantObservado").Width = 90
            Me.dgvOrdenCompra.TableDescriptor.Columns("observacion").Width = 350
            Me.dgvOrdenCompra.TableDescriptor.Columns("cantidad").Width = 0
            Me.dgvOrdenCompra.TableDescriptor.Columns("pendiente").Width = 0


            listaDocumentoGuiaDet = objDocCompraDet.UbicarGuiaDetallePorIdDocumentoguia(intIdDocumento)
            For Each i In listaDocumentoGuiaDet

                If ((i.cantidad - i.idItem) <> 0) Then
                    Me.dgvOrdenCompra.Table.AddNewRecord.SetCurrent()
                    Me.dgvOrdenCompra.Table.AddNewRecord.BeginEdit()
                    Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("idDocumento", i.idDocumento)
                    Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("secuencia", i.secuencia)
                    Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("cantidad", i.cantidad)
                    Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("pendiente", (i.cantidad - i.cantConforme))
                    Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("total", (i.cantidad - i.cantConforme))
                    Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("descripcionItem", i.descripcionItem)
                    Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("cantEntregado", 0)
                    Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("cantObservado", 0)
                    Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("observacion", Nothing)
                    Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("totalItem", i.cantidad)
                    Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("tipoExistencia", i.tipoExistencia)
                    Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("importeMN", i.importeMN)
                    Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("importeME", i.importeME)
                    Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("puMN", i.precioUnitario)
                    Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("puME", i.precioUnitarioUS)
                    Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("unidad", i.unidadMedida)
                    Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("destino", i.destino)
                    Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("almacenRef", i.almacenRef)
                    Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("idItem", i.idItem)
                    Me.dgvOrdenCompra.Table.AddNewRecord.EndEdit()
                End If

                TotalMN += i.importeMN
                totalME += i.importeME

            Next

            txtSerieGuia.Text = listaDocumentoGuiaDet(0).Serie
            txtNumeroGuia.Text = listaDocumentoGuiaDet(0).numerodoc

            listacondicion = objDocCompraDetCondicion.UbicarDocumentoGuiaDetCondicionFull(intIdDocumento)


        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try

    End Sub

    Public Sub cargarDato()

        Dim con = listaDocumentoGuiaDet

    End Sub

    Private Sub dgvOrdenCompra_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvOrdenCompra.TableControlCellClick
        'Dim style As GridTableCellStyleInfo = e.TableControl.Model(e.Inner.RowIndex, e.Inner.ColIndex)
        'If style.Enabled Then
        '    If style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso style.TableCellIdentity.Column.Name = "cantEntregado" Then
        '        e.Inner.Cancel = True
        '    End If
        '    Console.WriteLine(e.Inner.RowIndex.ToString() & "TableControlCellClick")
        'End If

        'Dim style2 As GridTableCellStyleInfo = e.TableControl.Model(e.Inner.RowIndex, e.Inner.ColIndex)
        'If style2.Enabled Then
        '    If style2.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso style2.TableCellIdentity.Column.Name = "cantObservado" Then
        '        e.Inner.Cancel = True
        '    End If
        '    Console.WriteLine(e.Inner.RowIndex.ToString() & "TableControlCellClick")
        'End If

        'txtcantidad.Clear()
        'txtcondicion.Clear()
        'txtObervacion.Clear()
        'ObtenerListaGuiaRemision()
        'txtcantidad.Select()
    End Sub

    Private Sub btGrabar_Click(sender As Object, e As EventArgs) Handles btGrabar.Click
        Grabar()
        Dispose()
    End Sub

    Private Sub dgvOrdenCompra_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvOrdenCompra.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        If Not IsNothing(Me.dgvOrdenCompra.Table.CurrentRecord) Then

            Dim pendiente As Integer
            Dim cantEntregado As Integer
            Dim cantObservado As Integer
            Dim puMn As Decimal
            Dim puME As Decimal


            pendiente = Me.dgvOrdenCompra.Table.CurrentRecord.GetValue("pendiente")
            cantEntregado = Me.dgvOrdenCompra.Table.CurrentRecord.GetValue("cantEntregado")
            cantObservado = Me.dgvOrdenCompra.Table.CurrentRecord.GetValue("cantObservado")
            puMn = Me.dgvOrdenCompra.Table.CurrentRecord.GetValue("puMN")
            puME = Me.dgvOrdenCompra.Table.CurrentRecord.GetValue("puME")

            Select Case ColIndex
                Case 5 ' cantidad
                    If (Int(pendiente >= cantEntregado)) Then
                        Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("cantObservado", pendiente - cantEntregado)

                        Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("importeMN", CDec(cantEntregado * puMn))
                        Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("importeME", CDec(cantEntregado * puME))

                    Else
                        Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("cantEntregado", 0)
                        lblEstado.Text = "no debe exceder la cantidad permitido"
                        PanelError.Visible = True
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                    End If
                Case 6
                    'If ((pendiente - cantEntregado) >= cantObservado) Then

                    'Else
                    '    Me.dgvOrdenCompra.Table.CurrentRecord.SetValue("cantObservado", 0)
                    '    lblEstado.Text = "no debe exceder la cantidad permitido"
                    '    PanelError.Visible = True
                    '    Timer1.Enabled = True
                    '    TiempoEjecutar(10)
                    'End If
                Case 6

                Case 8

                    'dt.Columns.Add("cantidad", GetType(Integer))
                    'dt.Columns.Add("pendiente", GetType(Integer))
                    'dt.Columns.Add("total", GetType(Integer))
                    'dt.Columns.Add("descripcionItem", GetType(String))
                    'dt.Columns.Add("cantEntregado", GetType(Integer))
                    'dt.Columns.Add("cantObservado", GetType(Integer))
                    'dt.Columns.Add("observacion", GetType(String))

                    'Dim colPercepcionME As Decimal = 0
                    'colPercepcionME = Math.Round(CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionMN")) / txtTipoCambio.DecimalValue, 2)
                    'Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", colPercepcionME)
                    'Calculos()
            End Select
        End If
    End Sub

    Private Sub frmReporteControlEntregable_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvOrdenCompra.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
        dgvOrdenCompra.ShowRowHeaders = False
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Me.Cursor = Cursors.WaitCursor
        Dim r As Record = dgvOrdenCompra.Table.CurrentRecord
        If Not IsNothing(r) Then

            Dim f As New frmHistorialRecepcion(dgvOrdenCompra.Table.CurrentRecord.GetValue("idDocumento"), dgvOrdenCompra.Table.CurrentRecord.GetValue("secuencia"))
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()

        Else
            MessageBox.Show("Debe elegir una venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtnombreRecpcion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtnombreRecpcion.KeyDown
        'If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.[End] Then
        'Else

        '    txtdniRecepcion.Select()

        'End If
    End Sub
End Class