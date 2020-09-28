Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping

Public Class frmCambioTipoExistencia

    Dim srtNomAlmacen As String = Nothing
    Dim strUM As String = Nothing
    Dim strTipoEx As String = Nothing
    Dim strCuenta As String = Nothing
    Dim intIdEstableAlm As Integer
    Dim strIdPresentacion As String = Nothing
    Dim selAlmacenPC As String


    Public Property ListaAsientonTransito As New List(Of asiento)
    Public Property ListaMovimientos As New List(Of movimiento)

    Public Property ManipulacionEstado() As String
    Private cantidaExistente As New List(Of Integer)
    Dim cuentaMascaraSA As New cuentaMascaraSA
    Dim cuentaMascara As New cuentaMascara
    Dim colorx As New GridMetroColors()
    Dim almacenDestino As New List(Of almacen)
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        Dim almacenSA As New almacenSA
        almacenDestino = almacenSA.GetListar_almacenExceptAV(GEstableciento.IdEstablecimiento)
        QGlobalColorSchemeManager1.Global.CurrentTheme = Qios.DevSuite.Components.QColorScheme.LunaBlueThemeName
        ' Add any initialization after the InitializeComponent() call.

        ' Me.Panel2.BringToFront()
        dockingClientPanel1.BringToFront()
        dockingManager1.MDIActivatedVisibility = True
        Me.dockingClientPanel1.AutoScroll = True
        '  Me.dockingClientPanel1.SizeToFit = True
        Me.dockingClientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        ' dockingManager1.SetDockVisibility ( panel)
        dockingManager1.SetDockLabel(Panel2, "Canasta existencias")

        'INICIO PERIODO
        lblPerido.Text = PeriodoGeneral
        txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0)
        txtFechaComprobante.Select()
        dockingManager1.CloseEnabled = False
        CargarListas()
        dgvCompra.DataSource = GetTableGrid2()
        GridCFG(dgvCompra)
        txtTipoCambio.Value = TmpTipoCambio


    End Sub

#Region "Asientos"


    Sub RegistrarMovimiento(nAsiento As asiento)

        Dim cuentaSA As New cuentaplanContableEmpresaSA

        Dim dt As New DataTable
        dt.Columns.Add("id", GetType(Integer))
        dt.Columns.Add("Modulo", GetType(String))
        dt.Columns.Add("cuenta", GetType(String))
        dt.Columns.Add("tipoAsiento", GetType(String))
        dt.Columns.Add("cant", GetType(Decimal))
        dt.Columns.Add("pumn", GetType(Decimal))
        dt.Columns.Add("importeMN", GetType(Decimal))
        dt.Columns.Add("pume", GetType(Decimal))
        dt.Columns.Add("importeME", GetType(Decimal))
        dt.Columns.Add("descripcion", GetType(String))

        Dim cosnulta = (From i In ListaMovimientos _
                       Where i.idAsiento = nAsiento.idAsiento).ToList

        '   For x As Integer = 0 To cosnulta.Count - 1

        'dt.Rows.Add(dt.NewRow())
        'dt.Rows(x)(0) = CInt(cosnulta(x).idmovimiento)
        'If Not IsNothing(cosnulta(x).cuenta) Then
        '    dt.Rows(x)(1) = cosnulta(x).nombreEntidad
        'Else
        '    dt.Rows(x)(1) = String.Empty
        'End If
        'dt.Rows(x)(2) = cosnulta(x).cuenta
        'dt.Rows(x)(3) = cosnulta(x).tipo
        'dt.Rows(x)(4) = cosnulta(x).Cant
        'dt.Rows(x)(5) = cosnulta(x).PUmn
        'dt.Rows(x)(6) = cosnulta(x).monto
        'dt.Rows(x)(7) = cosnulta(x).PUme
        'dt.Rows(x)(8) = cosnulta(x).montoUSD
        'dt.Rows(x)(9) = cosnulta(x).descripcion
        For Each x In cosnulta
            Dim dr As DataRow = dt.NewRow
            dr(0) = x.idmovimiento
            If Not IsNothing(x.cuenta) Then
                dr(1) = x.nombreEntidad
            Else
                dr(1) = String.Empty
            End If
            dr(2) = x.cuenta
            dr(3) = x.tipo
            dr(4) = x.Cant
            dr(5) = x.PUmn
            dr(6) = x.monto
            dr(7) = x.PUme
            dr(8) = x.montoUSD
            dr(9) = x.descripcion
            dt.Rows.Add(dr)
        Next

        dgvCompra.DataSource = dt
    End Sub

    Sub UbicarAsientoPorId(asiento As asiento)
        Dim consulta = (From n In ListaAsientonTransito _
                Where n.idAsiento = asiento.idAsiento).FirstOrDefault

        If Not IsNothing(consulta) Then
            txtGlosaAsiento.Text = consulta.glosa
        End If
    End Sub

    Sub GridCFG(GGC As GridGroupingControl)
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = False
        GGC.ShowColumnHeaders = True

        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        GGC.SetMetroStyle(colorx)
        GGC.BorderStyle = System.Windows.Forms.BorderStyle.None

        'GGC.BrowseOnly = True
        'GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        'GGC.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        'GGC.TableOptions.ListBoxSelectionMode = SelectionMode.One
        'GGC.TableOptions.SelectionBackColor = Color.Gray
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.Format = "MMM dd yyyy"
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.Hide
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).HeaderText = "Date"
        'Me.gridGroupingControl1.TableDescriptor.Columns(1).HeaderText = "Category"
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.Currency
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromArgb(168, 178, 189)
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.TextAlign = GridTextAlign.Left

        'this.gridGroupingControl1.TableDescriptor.Columns["Amount"].Width = (this.tableLayoutPanel3.Width / 5) - 50;
        GGC.AllowProportionalColumnSizing = False
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        GGC.Table.DefaultColumnHeaderRowHeight = 25
        GGC.Table.DefaultRecordRowHeight = 20
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Private Function GetTableGrid2() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add("id", GetType(Integer))
        dt.Columns.Add("Modulo", GetType(String))
        dt.Columns.Add("cuenta", GetType(String))
        dt.Columns.Add("tipoAsiento", GetType(String))
        dt.Columns.Add("cant", GetType(Decimal))
        dt.Columns.Add("pumn", GetType(Decimal))
        dt.Columns.Add("importeMN", GetType(Decimal))
        dt.Columns.Add("pume", GetType(Decimal))
        dt.Columns.Add("importeME", GetType(Decimal))
        dt.Columns.Add("descripcion", GetType(String))

        Return dt
    End Function

    Sub updateMovimiento(r As Record)
        '    Dim cuentaSA As New cuentaplanContableEmpresaSA

        Try
            Dim consulta = (From n In ListaMovimientos _
                       Where n.idmovimiento = r.GetValue("id")).FirstOrDefault

            If Not IsNothing(consulta) Then
                consulta.cuenta = r.GetValue("cuenta")
                Dim md = r.GetValue("Modulo").ToString
                If md.Trim.Length > 0 Then
                    consulta.nombreEntidad = r.GetValue("Modulo")
                Else
                    consulta.nombreEntidad = String.Empty
                End If

                Dim des = r.GetValue("descripcion").ToString
                If des.Trim.Length > 0 Then
                    consulta.descripcion = r.GetValue("descripcion")
                Else
                    consulta.descripcion = String.Empty
                End If
                consulta.tipo = r.GetValue("tipoAsiento")
                consulta.Cant = r.GetValue("cant")
                consulta.PUmn = r.GetValue("pumn")
                consulta.PUme = r.GetValue("pume")
                consulta.monto = r.GetValue("importeMN")
                consulta.montoUSD = r.GetValue("importeME")
            End If

            '      RegistrarMovimiento(New asiento With {.idAsiento = lstAsiento.SelectedValue})
        Catch ex As Exception
            MessageBoxAdv.Show(ex.Message)
        End Try
    End Sub

    Function GetMaxIDMovimiento() As Integer
        If ListaMovimientos.Count > 0 Then
            Return ListaMovimientos.Max(Function(o) o.idmovimiento)
        Else
            Return 0
        End If
    End Function

    Sub RegsitarMovimiento(nAsiento As asiento)
        Dim n As New movimiento
        n.cuenta = "10"
        n.idAsiento = nAsiento.idAsiento
        n.idmovimiento = GetMaxIDMovimiento() + 1
        n.tipo = "D"
        n.Cant = 1
        n.PUmn = 0
        n.PUme = 0
        n.monto = 0
        n.montoUSD = 0
        ListaMovimientos.Add(n)
    End Sub

    Sub RegistrarAsientos()
        Dim nAsiento As New asiento

        If ListaAsientonTransito.Count > 0 Then
            nAsiento.idAsiento = ListaAsientonTransito.Count + 1
        Else
            nAsiento.idAsiento = 1
        End If
        nAsiento.Descripcion = "Asiento Nro. " & ListaAsientonTransito.Count + 1
        ListaAsientonTransito.Add(nAsiento)

        GetasientosListbox()
    End Sub

    Sub GetasientosListbox()
        Dim dt As New DataTable()
        dt.Columns.Add("id")
        dt.Columns.Add("nombre")

        For Each i In ListaAsientonTransito
            Dim dr As DataRow = dt.NewRow
            dr(0) = i.idAsiento
            dr(1) = i.Descripcion
            dt.Rows.Add(dr)
        Next

        lstAsiento.DisplayMember = "nombre"
        lstAsiento.ValueMember = "id"
        lstAsiento.DataSource = dt
    End Sub
#End Region

#Region "TIMER"
    Sub parpadeo()
        Static parpadear As Boolean

        'If Not parpadear Then
        '    lblEstado.ForeColor = lblEstado.BackColor
        '    lblEstado.BackColor = Color.Yellow
        'Else
        '    lblEstado.ForeColor = SystemColors.WindowText
        'End If

        parpadear = Not parpadear
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick

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


#Region "PROVEEDOR"
    Public Sub InsertProveedor()
        Dim objCliente As New entidad
        Dim entidadSA As New entidadSA
        Try
            'Se asigna cada uno de los datos registrados
            objCliente.idEmpresa = Gempresas.IdEmpresaRuc
            objCliente.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR

            If btnRuc.Checked = True Then
                objCliente.tipoDoc = "6"
            ElseIf btnDni.Checked = True Then
                objCliente.tipoDoc = "1"
            ElseIf btnPassport.Checked = True Then
                objCliente.tipoDoc = "7"
            ElseIf btnCarnetEx.Checked = True Then
                objCliente.tipoDoc = "4"
            End If
            objCliente.nrodoc = txtDocProveedor.Text.Trim

            If rbNatural.Checked = True Then
                objCliente.appat = txtApePat.Text.Trim
                objCliente.nombre1 = txtNomProv.Text.Trim
                objCliente.nombreCompleto = objCliente.appat & ", " & objCliente.nombre1
                objCliente.tipoPersona = "N"
            ElseIf rbJuridico.Checked = True Then
                objCliente.nombre = txtNomProv.Text.Trim
                objCliente.nombreCompleto = txtNomProv.Text.Trim
                objCliente.tipoPersona = "J"
            End If
            objCliente.cuentaAsiento = "4212"
            objCliente.estado = "A"
            objCliente.usuarioModificacion = "NN"
            objCliente.fechaModificacion = DateTime.Now

            Dim codx As Integer = entidadSA.GrabarEntidad(objCliente)
            'lblEstado.Text = "Entidad registrada:" & vbCrLf & "Tipo: " & objCliente.tipoEntidad & vbCrLf & "Nombre: " & objCliente.nombreCompleto

            Dim n As New ListViewItem(codx)
            n.SubItems.Add(objCliente.nombreCompleto)
            n.SubItems.Add(objCliente.cuentaAsiento)
            n.SubItems.Add(objCliente.nrodoc)
            lsvProveedor.Items.Add(n)

            txtProveedor.Tag = codx
            txtProveedor.Text = objCliente.nombreCompleto
            txtRuc.Text = objCliente.nrodoc
            txtCuenta = objCliente.cuentaAsiento
        Catch ex As Exception
            'Manejo de errores
            MsgBox("No se pudo grabar el cliente." & vbCrLf & ex.Message)
        End Try
    End Sub
#End Region

#Region "PERSONA"
    Public Class Personal

        Private _name As String
        Private _id As Integer
        Public Sub New(ByVal name As String, ByVal id As Integer)
            _name = name
            _id = id
        End Sub

        Sub New()
            ' TODO: Complete member initialization 
        End Sub

        Public Property Name() As String
            Get
                Return _name
            End Get
            Set(ByVal value As String)
                _name = value
            End Set
        End Property
        Public Property Id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal value As Integer)
                _id = value
            End Set
        End Property
    End Class

    Public Sub GrabarPersona()
        Dim personaSA As New PersonaSA
        Dim personaBE As New Persona

        With personaBE
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idPersona = txtDniTrab.Text.Trim
            .nombres = txtNombreTrab.Text.Trim
            .appat = txtAppatTrab.Text.Trim
            .apmat = txtApmatTrab.Text.Trim
            .nombreCompleto = String.Concat(.appat & " " & .apmat & ", " & .nombres)
        End With
        personaSA.InsertPersona(personaBE)
        txtProveedor.Tag = personaBE.idPersona
        txtProveedor.Text = personaBE.nombreCompleto
        txtRuc.Text = personaBE.idPersona
        txtCuenta = "TR"

        lstPersonas.Items.Add(New Personal(personaBE.nombreCompleto, personaBE.idPersona))
    End Sub

    Private Sub ObtenerPersonaPorNombre(strPersona As String)
        Dim PersonaSA As New PersonaSA
        lstPersonas.Items.Clear()
        For Each i In PersonaSA.ObtenerPersonaPorNombres(Gempresas.IdEmpresaRuc, strPersona)
            lstPersonas.Items.Add(New Personal(i.nombreCompleto, i.idPersona))
        Next
        lstPersonas.DisplayMember = "Name"
        lstPersonas.ValueMember = "Id"
    End Sub
#End Region


#Region "Métodos"






    Public Sub ListaMercaderiasXIdHijo(intIdAlmacen As Integer, strtipoEx As String, idItem As Integer)
        Dim tablaSA As New tablaDetalleSA
        Dim totalSA As New TotalesAlmacenSA
        Try
            lsvExistencias.Items.Clear()
            For Each i As totalesAlmacen In totalSA.GetProductoPorAlmacenItem(intIdAlmacen, strtipoEx, idItem)
                If i.cantidad > 0 Then
                    Dim n As New ListViewItem(i.idEstablecimiento)
                    n.SubItems.Add(i.origenRecaudo)
                    n.SubItems.Add(i.idItem)
                    n.SubItems.Add(i.descripcion)
                    n.SubItems.Add(i.unidadMedida)
                    n.SubItems.Add(tablaSA.GetUbicarTablaID(21, i.Presentacion).descripcion)
                    n.SubItems.Add(FormatNumber(i.cantidad, 2))
                    n.SubItems.Add(FormatNumber(i.importeSoles, 2))
                    n.SubItems.Add(FormatNumber(i.importeDolares, 2))
                    If CDec(i.cantidad) > 0 Then
                        n.SubItems.Add(Math.Round(CDec(i.importeSoles) / CDec(i.cantidad), 2).ToString("N2"))
                    Else
                        n.SubItems.Add(0)
                    End If

                    If CDec(i.cantidad) > 0 Then
                        n.SubItems.Add(Math.Round(CDec(i.importeDolares) / CDec(i.cantidad), 2).ToString("N2"))
                    Else
                        n.SubItems.Add(0)
                    End If
                    lsvExistencias.Items.Add(n)
                End If

            Next
            For Each item As ListViewItem In lsvExistencias.Items
                Dim i As Short
                If i Mod 2 = 0 Then
                    item.BackColor = Color.Transparent
                    item.ForeColor = Color.Gray
                Else
                    item.BackColor = Color.WhiteSmoke
                    item.ForeColor = Color.Gray
                End If
                i = i + 1
            Next
        Catch ex As Exception
            MsgBox("No se pudo cargar la informacion de la BD." & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del Sistema.!")
        End Try
    End Sub


    Public Sub CargarTrabajadoresXnivel(strNivel As String, strBusqueda As String)
        Dim personaSA As New PersonaSA
        Try
            lsvProveedor.Items.Clear()
            For Each i In personaSA.ObtenerPersonaNumDocPorNivelxDescripcion(Gempresas.IdEmpresaRuc, strNivel, strBusqueda)
                Dim n As New ListViewItem(i.idPersona)
                n.SubItems.Add(i.nombreCompleto)
                n.SubItems.Add(String.Empty)
                n.SubItems.Add(i.idPersona)
                lsvProveedor.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Public Sub CargarEntidadesXtipo(strTipo As String, strBusqueda As String)
        Dim entidadSA As New entidadSA
        Try

            'Me.lstEntidades.DataSource = entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, strTipo, strBusqueda)
            'Me.lstEntidades.DisplayMember = "nombreCompleto"
            'Me.lstEntidades.ValueMember = "idEntidad"
            lsvProveedor.Items.Clear()
            For Each i As entidad In entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, strTipo, strBusqueda)
                Dim n As New ListViewItem(i.idEntidad)
                n.SubItems.Add(i.nombreCompleto)
                n.SubItems.Add(i.cuentaAsiento)
                n.SubItems.Add(i.nrodoc)
                lsvProveedor.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Public Sub UbicarEntidadPorRuc(strNro As String)
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        entidad = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, TIPO_ENTIDAD.PROVEEDOR, strNro)
        If Not IsNothing(entidad) Then
            With entidad
                txtProveedor.Text = .nombreCompleto
                txtProveedor.Tag = .idEntidad
                txtCuenta = .cuentaAsiento
                txtRuc.Text = .nrodoc
            End With
        Else
            txtProveedor.Clear()
            txtProveedor.Clear()

            txtRuc.Clear()
        End If
    End Sub

    Public Sub UbicarTrabPorDNI(strNumero As String)
        Dim personaSA As New PersonaSA
        Dim persona As New Persona

        persona = personaSA.ObtenerPersonaNumDoc(Gempresas.IdEmpresaRuc, strNumero)
        If Not IsNothing(persona) Then
            With persona
                txtProveedor.Text = .nombreCompleto
                txtProveedor.Tag = .idPersona
                txtCuenta = "TR"
                txtRuc.Text = .idPersona
            End With
        End If
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

#Region "ASIENTOS"
    Private Function ListaTotalesAlmacen() As List(Of totalesAlmacen)
        Dim objTotalesDet As New totalesAlmacen
        Dim ListaTotales As New List(Of totalesAlmacen)
        Dim almacenSA As New almacenSA

        For Each i As DataGridViewRow In dgvNuevoDoc.Rows
            objTotalesDet = New totalesAlmacen
            objTotalesDet.Action = Business.Entity.BaseBE.EntityAction.INSERT
            objTotalesDet.SecuenciaDetalle = 0
            objTotalesDet.idEmpresa = Gempresas.IdEmpresaRuc
            objTotalesDet.Modulo = "N"
            objTotalesDet.idEstablecimiento = almacenSA.GetUbicar_almacenPorID(CInt(cboalmacenDestino.SelectedValue)).idEstablecimiento
            objTotalesDet.idAlmacen = cboalmacenDestino.SelectedValue
            objTotalesDet.origenRecaudo = i.Cells(1).Value()
            objTotalesDet.tipoCambio = txtTipoCambio.Value
            objTotalesDet.tipoExistencia = i.Cells(13).Value()
            objTotalesDet.idItem = i.Cells(2).Value()
            objTotalesDet.descripcion = i.Cells(3).Value()
            objTotalesDet.idUnidad = i.Cells(6).Value()
            objTotalesDet.unidadMedida = Nothing
            objTotalesDet.cantidad = CType(i.Cells(7).Value(), Decimal)
            objTotalesDet.precioUnitarioCompra = CType(i.Cells(8).Value(), Decimal)
            objTotalesDet.importeSoles = CType(i.Cells(10).Value(), Decimal)
            objTotalesDet.importeDolares = CType(i.Cells(11).Value(), Decimal)
            objTotalesDet.montoIsc = 0
            objTotalesDet.montoIscUS = 0
            objTotalesDet.Otros = 0
            objTotalesDet.OtrosUS = 0
            objTotalesDet.porcentajeUtilidad = 0
            objTotalesDet.importePorcentaje = 0
            objTotalesDet.importePorcentajeUS = 0
            objTotalesDet.precioVenta = 0
            objTotalesDet.precioVentaUS = 0
            objTotalesDet.usuarioActualizacion = "NN"
            objTotalesDet.fechaActualizacion = Date.Now
            ListaTotales.Add(objTotalesDet)
        Next

        Return ListaTotales
    End Function

    Private Function ListaTotalesAlmacenOrigen() As List(Of totalesAlmacen)
        Dim objTotalesDet As New totalesAlmacen
        Dim ListaTotales As New List(Of totalesAlmacen)
        Dim almacenSA As New almacenSA

        For Each i As DataGridViewRow In dgvNuevoDoc.Rows
            objTotalesDet = New totalesAlmacen
            objTotalesDet.Action = Business.Entity.BaseBE.EntityAction.INSERT
            objTotalesDet.SecuenciaDetalle = 0
            objTotalesDet.idEmpresa = Gempresas.IdEmpresaRuc
            objTotalesDet.Modulo = "N"
            objTotalesDet.idEstablecimiento = almacenSA.GetUbicar_almacenPorID(CInt(i.Cells(21).Value())).idEstablecimiento
            objTotalesDet.idAlmacen = i.Cells(21).Value()
            objTotalesDet.origenRecaudo = i.Cells(1).Value()
            objTotalesDet.tipoCambio = txtTipoCambio.Value
            objTotalesDet.tipoExistencia = i.Cells(13).Value()
            objTotalesDet.idItem = i.Cells(2).Value()
            objTotalesDet.descripcion = i.Cells(3).Value()
            objTotalesDet.idUnidad = i.Cells(6).Value()
            objTotalesDet.unidadMedida = Nothing
            objTotalesDet.cantidad = CType(i.Cells(7).Value(), Decimal) * -1
            objTotalesDet.precioUnitarioCompra = CType(i.Cells(8).Value(), Decimal) * -1
            objTotalesDet.importeSoles = CType(i.Cells(10).Value(), Decimal) * -1
            objTotalesDet.importeDolares = CType(i.Cells(11).Value(), Decimal) * -1
            objTotalesDet.montoIsc = 0
            objTotalesDet.montoIscUS = 0
            objTotalesDet.Otros = 0
            objTotalesDet.OtrosUS = 0
            objTotalesDet.porcentajeUtilidad = 0
            objTotalesDet.importePorcentaje = 0
            objTotalesDet.importePorcentajeUS = 0
            objTotalesDet.precioVenta = 0
            objTotalesDet.precioVentaUS = 0
            objTotalesDet.usuarioActualizacion = "NN"
            objTotalesDet.fechaActualizacion = Date.Now
            ListaTotales.Add(objTotalesDet)
        Next

        Return ListaTotales
    End Function

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
            If chProv.Checked = True Then
                asientoBL.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
            Else
                asientoBL.tipoEntidad = TIPO_ENTIDAD.PERSONAL_PLANILLA
            End If

            asientoBL.fechaProceso = txtFechaComprobante.Value
            asientoBL.codigoLibro = "13"
            asientoBL.tipo = "D"
            asientoBL.tipoAsiento = ASIENTO_CONTABLE.OTRAS_ENTRADAS
            asientoBL.importeMN = CDec(txtTotalmn.Text)
            asientoBL.importeME = CDec(txtTotalme.Text)
            asientoBL.glosa = txtGlosa.Text.Trim ' Glosa()

            For Each i As DataGridViewRow In dgvNuevoDoc.Rows
                nMovimiento = New movimiento
                Select Case i.Cells(13).Value
                    Case "01"
                        cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "TRANS01.1")
                        nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                    Case "02"
                        cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "TRANS02.1")
                        nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                    Case "03"
                        cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "TRANS03.1")
                        nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                    Case "04"
                        cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "TRANS04.1")
                        nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                    Case "05"
                        cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "TRANS05.1")
                        nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                    Case "06"
                        cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "TRANS06.1")
                        nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                    Case "07"
                        cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "TRANS07.1")
                        nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                    Case "08"
                        cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "TRANS08.1")
                        nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                End Select

                nMovimiento.descripcion = i.Cells(3).Value
                nMovimiento.tipo = "D"
                nMovimiento.monto = CDec(i.Cells(10).Value)
                nMovimiento.montoUSD = CDec(i.Cells(11).Value)
                nMovimiento.usuarioActualizacion = "Jiuni"
                nMovimiento.fechaActualizacion = DateTime.Now
                asientoBL.movimiento.Add(nMovimiento)
                asientoBL.movimiento.Add(HaberTransferenciaMOv(i))
            Next
            ListaAsientonTransito.Add(asientoBL)
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try
    End Sub

    Function HaberTransferenciaMOv(i As DataGridViewRow) As movimiento
        Dim mascaraSA As New mascaraContable2SA
        Dim mascaraExistenciasSA As New mascaraContableExistenciaSA
        Dim nMovimiento As New movimiento

        nMovimiento = New movimiento
        Select Case i.Cells(13).Value
            Case "01"
                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "TRANS01.2")
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            Case "02"
                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "TRANS02.2")
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            Case "03"
                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "TRANS03.2")
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            Case "04"
                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "TRANS04.2")
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            Case "05"
                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "TRANS05.2")
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            Case "06"
                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "TRANS06.2")
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            Case "07"
                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "TRANS07.2")
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            Case "08"
                cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "TRANS08.2")
                nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
        End Select
        nMovimiento.descripcion = i.Cells(3).Value
        nMovimiento.tipo = "H"
        nMovimiento.monto = CDec(i.Cells(10).Value)
        nMovimiento.montoUSD = CDec(i.Cells(11).Value)
        nMovimiento.usuarioActualizacion = "Jiuni"
        nMovimiento.fechaActualizacion = DateTime.Now

        Return nMovimiento
    End Function

    Function HaberOtrasExistenciasMOv(i As DataGridViewRow) As movimiento
        Dim mascaraSA As New mascaraContable2SA
        Dim mascaraExistenciasSA As New mascaraContableExistenciaSA
        Dim nMovimiento As New movimiento

        nMovimiento = New movimiento
        nMovimiento.cuenta = "1000"
        nMovimiento.descripcion = i.Cells(3).Value
        nMovimiento.tipo = "H"
        nMovimiento.monto = CDec(i.Cells(10).Value)
        nMovimiento.montoUSD = CDec(i.Cells(11).Value)
        nMovimiento.usuarioActualizacion = "Jiuni"
        nMovimiento.fechaActualizacion = DateTime.Now

        Return nMovimiento
    End Function

    Sub AsientoEntrada()
        Dim listaMovimiento As New List(Of Movimientos)
        Dim asientoBL As New asiento
        Dim nMovimiento As New movimiento
        Dim TLmn As Decimal = 0
        Dim TLme As Decimal = 0
        For Each i In datos
            asientoBL = New asiento
            asientoBL.idEmpresa = Gempresas.IdEmpresaRuc
            asientoBL.idCentroCostos = GEstableciento.IdEstablecimiento
            asientoBL.idEntidad = CInt(txtProveedor.Tag)
            asientoBL.nombreEntidad = txtProveedor.Text
            asientoBL.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
            asientoBL.fechaProceso = txtFechaComprobante.Value
            asientoBL.codigoLibro = "13"
            asientoBL.tipo = "D"
            asientoBL.tipoAsiento = ASIENTO_CONTABLE.OTRAS_ENTRADAS
            asientoBL.glosa = i.NombreAsiento
            listaMovimiento = ListarMovimientoporAsiento(i.AsientoID)
            For Each x In listaMovimiento
                nMovimiento = New movimiento
                nMovimiento.cuenta = x.Cuenta
                nMovimiento.idAsiento = x.AsientoID
                nMovimiento.descripcion = x.Descripcion
                nMovimiento.tipo = x.Tipo
                nMovimiento.monto = x.Importemn
                nMovimiento.montoUSD = x.Importeme
                nMovimiento.usuarioActualizacion = usuario.IDUsuario
                nMovimiento.fechaActualizacion = DateTime.Now
                asientoBL.movimiento.Add(nMovimiento)
            Next
            asientoBL.importeMN = SumatoriaMovimientosMN(i.AsientoID, "D")
            asientoBL.importeME = SumatoriaMovimientosME(i.AsientoID, "D")
            ListaAsientonTransito.Add(asientoBL)
        Next
    End Sub

    Sub AsientoEntradaExistencia()
        Dim listaMovimiento As New List(Of Movimientos)
        Dim asientoBL As New asiento
        Dim nMovimiento As New movimiento
        Dim mascaraSA As New mascaraContable2SA
        Dim mascaraExistenciasSA As New mascaraContableExistenciaSA
        Try
            asientoBL = New asiento
            asientoBL.idEmpresa = Gempresas.IdEmpresaRuc
            asientoBL.idCentroCostos = GEstableciento.IdEstablecimiento
            asientoBL.idEntidad = CInt(txtProveedor.Tag)
            asientoBL.nombreEntidad = txtProveedor.Text
            asientoBL.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
            asientoBL.fechaProceso = txtFechaComprobante.Value
            asientoBL.codigoLibro = "13"
            asientoBL.tipo = "D"
            asientoBL.tipoAsiento = ASIENTO_CONTABLE.OTRAS_ENTRADAS
            asientoBL.importeMN = CDec(txtTotalmn.Text)
            asientoBL.importeME = CDec(txtTotalme.Text)
            asientoBL.glosa = txtGlosa.Text.Trim 'Glosa()

            For Each i As DataGridViewRow In dgvNuevoDoc.Rows
                If dgvNuevoDoc.Rows(i.Index).Cells(12).Value() <> Business.Entity.BaseBE.EntityAction.DELETE Then
                    nMovimiento = New movimiento
                    If dgvNuevoDoc.Rows(i.Index).Cells(13).Value = "01" Then
                        nMovimiento.cuenta = mascaraSA.GetUbicar_mascaraContable2PorEmpresa(Gempresas.IdEmpresaRuc, dgvNuevoDoc.Rows(i.Index).Cells(14).Value).cuentaDestinoKardex
                    Else
                        nMovimiento.cuenta = mascaraExistenciasSA.GetUbicar_mascaraContableExistenciaPorEmpresaCF(Gempresas.IdEmpresaRuc, dgvNuevoDoc.Rows(i.Index).Cells(14).Value, dgvNuevoDoc.Rows(i.Index).Cells(13).Value).cuentaIngAlmacen
                    End If
                    nMovimiento.descripcion = dgvNuevoDoc.Rows(i.Index).Cells(3).Value
                    nMovimiento.tipo = "D"
                    nMovimiento.monto = CDec(dgvNuevoDoc.Rows(i.Index).Cells(10).Value)
                    nMovimiento.montoUSD = CDec(dgvNuevoDoc.Rows(i.Index).Cells(11).Value)
                    nMovimiento.usuarioActualizacion = usuario.IDUsuario
                    nMovimiento.fechaActualizacion = DateTime.Now
                    asientoBL.movimiento.Add(nMovimiento)
                    asientoBL.movimiento.Add(HaberOtrasExistenciasMOv(i))
                End If
            Next
            ListaAsientonTransito.Add(asientoBL)
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try

    End Sub

#End Region

    Public Sub UbicarDocumento(ByVal intIdDocumento As Integer)
        Dim asientoSA As New AsientoSA
        Dim movimientoSA As New MovimientoSA

        Dim objDoc As New DocumentoSA
        Dim objDocCompra As New DocumentoCompraSA
        Dim objDocCompraDet As New DocumentoCompraDetalleSA
        Dim objTabla As New tablaDetalleSA
        Dim objEntidad As New entidadSA
        Dim nEntidad As New entidad
        Dim VALUEDES As String = ""
        Dim insumosSA As New detalleitemsSA
        Dim almacenSA As New almacenSA
        Dim PersonaSA As New PersonaSA
        Dim Persona As New Persona
        Try
            With objDoc.UbicarDocumento(intIdDocumento)
                txtFechaComprobante.Value = .fechaProceso
                'COMPROBANTE
                txtIdComprobante.Text = "99 - GUIA DE REMISION"
            End With

            'CABECERA COMPROBANTE
            With objDocCompra.UbicarDocumentoCompra(intIdDocumento)
                Select Case .destino
                    Case TIPO_COMPRA.MOVIMIENTO_ALMACEN.TRANSFERENCIA_ALMACENES
                        lblMovimiento.Text = "TRANSFERENCIA ENTRE ALMACENES"
                        '  ToolStripLabel1.Text = "TRANSFERENCIA ENTRE ALMACENES"
                    Case TIPO_COMPRA.MOVIMIENTO_ALMACEN.ENTRADA_EXISTENCIAS
                        lblMovimiento.Text = "OTRAS ENTRADAS DE EXISTENCIAS"
                        ' ToolStripLabel1.Text = "OTRAS ENTRADAS DE EXISTENCIAS"
                End Select

                lblIdDocumento.Text = .idDocumento
                txtFechaComprobante.Text = .fechaDoc
                lblPerido.Text = .fechaContable
                txtSerie.Text = .serie
                txtNumero.Text = .numeroDoc
                txtGlosa.Text = .glosa
                If Not IsNothing(.idProveedor) Then
                    chProv.Checked = True
                    chTrab.Checked = False

                    'PROVEEDOR
                    nEntidad = objEntidad.UbicarEntidadPorID(.idProveedor).First()
                    txtRuc.Text = nEntidad.nrodoc
                    txtCuenta = nEntidad.cuentaAsiento
                    txtProveedor.Tag = nEntidad.idEntidad
                    txtProveedor.Text = nEntidad.nombreCompleto

                Else
                    chTrab.Checked = True
                    chProv.Checked = False
                    Persona = PersonaSA.ObtenerPersonaNumDoc(Gempresas.IdEmpresaRuc, .idPersona)
                    If Not IsNothing(Persona) Then
                        txtRuc.Text = Persona.idPersona
                        txtCuenta = "TR"
                        txtProveedor.Tag = Persona.idPersona
                        txtProveedor.Text = Persona.nombreCompleto
                    End If
                End If
                dgvNuevoDoc.ReadOnly = True
                '_::::::::::::::::::        :::::::::::::::::::
                txtTipoCambio.Value = .tcDolLoc
            End With

            'DETALLE DE LA COMPRA
            dgvNuevoDoc.Rows.Clear()
            Dim almacenDestino As Integer
            For Each i In objDocCompraDet.UbicarDocumentoCompraDetalle(intIdDocumento)
                almacenDestino = i.almacenDestino
                If i.destino = "1" Then
                    VALUEDES = "1"
                ElseIf i.destino.Trim = "2" Then
                    VALUEDES = "2"
                ElseIf i.destino.Trim = "3" Then
                    VALUEDES = "3"
                ElseIf i.destino.Trim = "4" Then
                    VALUEDES = "4"
                End If

                dgvNuevoDoc.Rows.Add(i.secuencia,
                                     VALUEDES,
                                     i.idItem,
                                     i.descripcionItem,
                                     i.unidad2,
                                     i.monto2,
                                     i.unidad1,
                                     FormatNumber(i.monto1, 2),
                                     FormatNumber(i.precioUnitario, 2),
                                     FormatNumber(i.precioUnitarioUS, 2),
                                     FormatNumber(i.importe, 2),
                                     FormatNumber(i.importeUS, 2),
                                     Business.Entity.BaseBE.EntityAction.UPDATE, i.tipoExistencia,
                                     insumosSA.InvocarProductoID(i.idItem).cuenta,
                                     i.preEvento, Nothing, i.almacenRef, almacenSA.GetUbicar_almacenPorID(i.almacenRef).descripcionAlmacen,
                                     Nothing, almacenSA.GetUbicar_almacenPorID(i.almacenRef).descripcionAlmacen, i.almacenRef)
            Next
            With almacenSA.GetUbicar_almacenPorID(almacenDestino)
                cboalmacenDestino.SelectedValue = .idAlmacen
            End With
            colAlmacenBAck.Visible = True

            TotalesCabeceras()
        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try

    End Sub


    'Public Function Glosa() As String
    '    Return "Por Transferencia de " & cboTipoExistencia.Text & ", Del almacén " & cboAlmacen.Text & "hacia el almacén " & cboalmacenDestino.Text & ", según Doc. Nro. " & txtSerie.Text.Trim & "-" & txtNumero.Text.Trim
    'End Function

    Sub Grabar()
        Dim CompraSA As New DocumentoCompraSA
        Dim ndocumento As New documento()
        Dim DocCaja As New documento

        Dim ListaTotales As New List(Of totalesAlmacen)
        Dim ListaTotalesOrigen As New List(Of totalesAlmacen)

        Dim nDocumentoCompra As New documentocompra()
        Dim objDocumentoCompraDet As New documentocompradetalle
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        Dim asientoSA As New AsientoSA
        ' Dim ListaAsiento As New List(Of asiento)
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento

        Dim ListaDetalle As New List(Of documentocompradetalle)
        With ndocumento
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            If Not IsNothing(GProyectos) Then
                .idProyecto = GProyectos.IdProyectoActividad
            End If

            .tipoDoc = "99"
            .fechaProceso = txtFechaComprobante.Value
            .nroDoc = txtSerie.Text.Trim & "-" & txtNumero.Text.Trim
            .idOrden = Nothing ' Me.IdOrden
            .tipoOperacion = "11"
            .usuarioActualizacion = "NN"
            .fechaActualizacion = DateTime.Now
        End With

        With nDocumentoCompra
            .tipoOperacion = "11"
            .idPadre = lblIdDocumento.Text
            .codigoLibro = "13"
            .tipoDoc = "99"
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = txtFechaComprobante.Value ' PERIODO
            .fechaContable = PeriodoGeneral
            .serie = txtSerie.Text.Trim
            .numeroDoc = txtNumero.Text
            If chProv.Checked = True Then
                .idProveedor = CInt(txtProveedor.Tag)
            Else
                .idPersona = CInt(txtProveedor.Tag)
            End If
            .nombreProveedor = txtProveedor.Text
            .monedaDoc = IIf(cboMoneda.SelectedValue = 1, "1", "2")
            .tasaIgv = txtIgv.Value ' IIf(IsNothing(nudIgv.Value) Or String.IsNullOrEmpty(nudIgv.Value) Or String.IsNullOrWhiteSpace(nudIgv.Value), Nothing, Trim(nudIgv.Value))
            .tcDolLoc = txtTipoCambio.Value
            .tipoRecaudo = Nothing
            .regimen = Nothing
            .tasaRegimen = 0
            .nroRegimen = Nothing

            .importeTotal = CDec(txtTotalmn.Text)
            .importeUS = CDec(txtTotalme.Text)

            .destino = TIPO_COMPRA.MOVIMIENTO_ALMACEN.TRANSFERENCIA_ALMACENES
            .estadoPago = TIPO_COMPRA.PAGO.PAGADO
            .glosa = txtGlosa.Text.Trim ' Glosa()
            .referenciaDestino = Nothing ' IIf(IsNothing(txtDestinoref.Text) Or String.IsNullOrEmpty(txtDestinoref.Text) Or String.IsNullOrWhiteSpace(txtDestinoref.Text), Nothing, Trim(txtDestinoref.Text.Trim))
            .tipoCompra = TIPO_COMPRA.MOVIMIENTO_ALMACEN.TRANSFERENCIA_ALMACENES
            ' .DocumentoSustentado = "S"
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With
        ndocumento.documentocompra = nDocumentoCompra

        'ASIENTOS CONTABLES
        Dim almacenSA As New almacenSA
        For Each i As DataGridViewRow In dgvNuevoDoc.Rows

            objDocumentoCompraDet = New documentocompradetalle
            objDocumentoCompraDet.TipoOperacion = "11"
            objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoCompraDet.IdEstablecimiento = almacenSA.GetUbicar_almacenPorID(cboalmacenDestino.SelectedValue).idEstablecimiento ' i.Cells(19).Value()
            objDocumentoCompraDet.FechaDoc = txtFechaComprobante.Value
            objDocumentoCompraDet.CuentaProvedor = txtCuenta
            objDocumentoCompraDet.NombreProveedor = txtProveedor.Text.Trim
            objDocumentoCompraDet.TipoDoc = "99"
            objDocumentoCompraDet.NumDoc = txtNumero.Text.Trim
            objDocumentoCompraDet.Serie = txtSerie.Text.Trim
            '   If dgvNuevoDoc.Rows(S).Cells(20).Value() = ENTITY_ACTIONS.INSERT Then
            If i.Cells(1).Value() = "1" Then '   ADQ. GRAVADAS DESTINADAS A OPE.GRAVADAS Y/O EXPORTACIONES" Then
                objDocumentoCompraDet.destino = "1"
            ElseIf i.Cells(1).Value() = "2" Then '   ADQ. GRAV DEST CONJUNTAMENTE A OPER GRAV Y NO GRAV" Then
                objDocumentoCompraDet.destino = "2"
            ElseIf i.Cells(1).Value() = "3" Then '   ADQ. GRAVADAS DESTINADAS A OPER.NO GRAVADAS" Then
                objDocumentoCompraDet.destino = "3"
            ElseIf i.Cells(1).Value() = "4" Then '   ADQUISICIONES NO GRAVADAS" Then
                objDocumentoCompraDet.destino = "4"
            End If
            objDocumentoCompraDet.CuentaItem = i.Cells(14).Value()
            objDocumentoCompraDet.idItem = i.Cells(2).Value()
            objDocumentoCompraDet.tipoExistencia = i.Cells(13).Value()
            objDocumentoCompraDet.descripcionItem = i.Cells(3).Value()
            objDocumentoCompraDet.DetalleItem = i.Cells(3).Value()
            objDocumentoCompraDet.unidad1 = i.Cells(6).Value().ToString.Trim

            If IsNumeric(i.Cells(7).Value()) Then
                If CDec(i.Cells(7).Value()) <= 0 Then
                    MessageBox.Show("El valor de la cantidad debe ser mayor a cero", "Validar cantidad", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If
            End If

            If IsNumeric(i.Cells(10).Value()) Then
                If CDec(i.Cells(10).Value()) < 0 Then
                    MessageBox.Show("El valor del importe no puede ser negativo", "Validar importe", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If
            End If

            If CDec(i.Cells(7).Value()) > CDec(i.Cells(22).Value()) Then

                MessageBox.Show("El valor de la cantidad no puede exceder el stock disponible", "Validar cantidad", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
            objDocumentoCompraDet.monto1 = CDec(i.Cells(7).Value())
            objDocumentoCompraDet.unidad2 = i.Cells(4).Value().ToString.Trim 'IDPRESENTACION
            objDocumentoCompraDet.monto2 = i.Cells(5).Value() ' PRESENTACION
            objDocumentoCompraDet.precioUnitario = CDec(i.Cells(8).Value())
            objDocumentoCompraDet.precioUnitarioUS = CDec(i.Cells(9).Value())
            objDocumentoCompraDet.importe = CDec(i.Cells(10).Value())
            objDocumentoCompraDet.importeUS = CDec(i.Cells(11).Value())

            objDocumentoCompraDet.preEvento = i.Cells(15).Value() '= "00", Nothing, dgvNuevoDoc.Rows(S).Cells(23).Value())
            '**********************************************************************************
            objDocumentoCompraDet.usuarioModificacion = usuario.IDUsuario
            objDocumentoCompraDet.almacenRef = CInt(i.Cells(21).Value())
            objDocumentoCompraDet.almacenDestino = cboalmacenDestino.SelectedValue ' CDec(i.Cells(17).Value())
            objDocumentoCompraDet.fechaModificacion = DateTime.Now
            objDocumentoCompraDet.FechaVcto = Nothing ' IIf(IsNothing(dgvNuevoDoc.Rows(S).Cells(28).Value()), Nothing, CDate(dgvNuevoDoc.Rows(S).Cells(28).Value()))
            objDocumentoCompraDet.Glosa = txtGlosa.Text.Trim 'Glosa()
            ' objDocumentoCompraDet.BonificacionMN =
            ValidarCantidad(dgvNuevoDoc.CurrentRow.Index)

            ListaDetalle.Add(objDocumentoCompraDet)
            '   End If
        Next
        'TOTALES ALMACEN
        '     ListaTotales = ListaTotalesAlmacen() '+positivo

        'Select Case lblMovimiento.Text
        '    Case "TRANSFERENCIA ENTRE ALMACENES"
        AsientoTransferenciaEntreAlmacenes()
        'ListaTotalesOrigen = ListaTotalesAlmacenOrigen() 'negativo
        '    Case Else
        'AsientoEntrada()
        'End Select

        'For Each i In ListaAsientonTransito

        '    Dim consultaMov = (From n In ListaMovimientos _
        '                      Where n.idAsiento = i.idAsiento).ToList


        '    i.idEmpresa = Gempresas.IdEmpresaRuc
        '    i.idCentroCostos = GEstableciento.IdEstablecimiento
        '    i.idEntidad = CInt(txtProveedor.Tag)
        '    i.nombreEntidad = txtProveedor.Text
        '    i.tipoEntidad = "PR"
        '    i.fechaProceso = txtFechaComprobante.Value
        '    i.codigoLibro = "08"
        '    i.tipo = "D"
        '    i.tipoAsiento = "AS-M"
        '    i.importeMN = consultaMov.Where(Function(o) o.tipo = "D").Sum(Function(o) o.monto)
        '    i.importeME = consultaMov.Where(Function(o) o.tipo = "D").Sum(Function(o) o.montoUSD)
        '    i.glosa = "Asiento manual trasferencia entre almacenes"
        '    i.usuarioActualizacion = usuario.IDUsuario
        '    i.fechaActualizacion = DateTime.Now

        '    For Each mov In consultaMov
        '        i.movimiento.Add(mov)
        '    Next
        'Next

        ndocumento.asiento = ListaAsientonTransito
        ndocumento.documentocompra.documentocompradetalle = ListaDetalle
        'TOTALES ALMACEN

        CompraSA.GrabarTransferenciaAlmacenes(ndocumento)
        lblEstado.Text = "entrada registrada!"

        Dispose()
    End Sub

    Sub GrabarDefault()
        Dim CompraSA As New DocumentoCompraSA
        Dim ndocumento As New documento()
        Dim DocCaja As New documento

        Dim ListaTotales As New List(Of totalesAlmacen)
        Dim ListaTotalesOrigen As New List(Of totalesAlmacen)

        Dim nDocumentoCompra As New documentocompra()
        Dim objDocumentoCompraDet As New documentocompradetalle
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        Dim asientoSA As New AsientoSA
        ' Dim ListaAsiento As New List(Of asiento)
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento

        Dim ListaDetalle As New List(Of documentocompradetalle)
        With ndocumento
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            If Not IsNothing(GProyectos) Then
                .idProyecto = GProyectos.IdProyectoActividad
            End If

            .tipoDoc = "99"
            .fechaProceso = txtFechaComprobante.Value
            .nroDoc = txtSerie.Text.Trim & "-" & txtNumero.Text.Trim
            .idOrden = Nothing ' Me.IdOrden
            .tipoOperacion = "02"
            .usuarioActualizacion = "NN"
            .fechaActualizacion = DateTime.Now
        End With

        With nDocumentoCompra
            .idPadre = lblIdDocumento.Text
            .codigoLibro = "13"
            .tipoDoc = "99"
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = txtFechaComprobante.Value ' PERIODO
            .fechaContable = PeriodoGeneral
            .serie = txtSerie.Text.Trim
            .numeroDoc = txtNumero.Text
            If chProv.Checked = True Then
                .idProveedor = CInt(txtProveedor.Tag)
            Else
                .idPersona = CInt(txtProveedor.Tag)
            End If
            .nombreProveedor = txtProveedor.Text
            .monedaDoc = IIf(cboMoneda.SelectedValue = "1", "1", "2")
            .tasaIgv = txtIgv.Value ' IIf(IsNothing(nudIgv.Value) Or String.IsNullOrEmpty(nudIgv.Value) Or String.IsNullOrWhiteSpace(nudIgv.Value), Nothing, Trim(nudIgv.Value))
            .tcDolLoc = txtTipoCambio.Value
            .tipoRecaudo = Nothing
            .regimen = Nothing
            .tasaRegimen = 0
            .nroRegimen = Nothing

            .importeTotal = CDec(txtTotalmn.Text)
            .importeUS = CDec(txtTotalme.Text)

            .destino = TIPO_COMPRA.MOVIMIENTO_ALMACEN.ENTRADA_EXISTENCIAS
            .estadoPago = TIPO_COMPRA.PAGO.PAGADO
            .glosa = txtGlosa.Text.Trim ' Glosa()
            .referenciaDestino = Nothing ' IIf(IsNothing(txtDestinoref.Text) Or String.IsNullOrEmpty(txtDestinoref.Text) Or String.IsNullOrWhiteSpace(txtDestinoref.Text), Nothing, Trim(txtDestinoref.Text.Trim))
            .tipoCompra = TIPO_COMPRA.OTRAS_ENTRADAS
            ' .DocumentoSustentado = "S"
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With
        ndocumento.documentocompra = nDocumentoCompra

        '  GuiaRemision(ndocumento)

        'ASIENTOS CONTABLES
        For Each i As DataGridViewRow In dgvNuevoDoc.Rows

            objDocumentoCompraDet = New documentocompradetalle
            objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoCompraDet.IdEstablecimiento = i.Cells(19).Value()
            objDocumentoCompraDet.FechaDoc = txtFechaComprobante.Value
            objDocumentoCompraDet.CuentaProvedor = txtCuenta
            objDocumentoCompraDet.NombreProveedor = txtProveedor.Text.Trim
            objDocumentoCompraDet.TipoDoc = "99"
            objDocumentoCompraDet.NumDoc = txtNumero.Text.Trim
            objDocumentoCompraDet.Serie = txtSerie.Text.Trim
            '   If dgvNuevoDoc.Rows(S).Cells(20).Value() = ENTITY_ACTIONS.INSERT Then
            If i.Cells(1).Value() = "1" Then '   ADQ. GRAVADAS DESTINADAS A OPE.GRAVADAS Y/O EXPORTACIONES" Then
                objDocumentoCompraDet.destino = "1"
            ElseIf i.Cells(1).Value() = "2" Then '   ADQ. GRAV DEST CONJUNTAMENTE A OPER GRAV Y NO GRAV" Then
                objDocumentoCompraDet.destino = "2"
            ElseIf i.Cells(1).Value() = "3" Then '   ADQ. GRAVADAS DESTINADAS A OPER.NO GRAVADAS" Then
                objDocumentoCompraDet.destino = "3"
            ElseIf i.Cells(1).Value() = "4" Then '   ADQUISICIONES NO GRAVADAS" Then
                objDocumentoCompraDet.destino = "4"
            End If
            objDocumentoCompraDet.CuentaItem = i.Cells(14).Value()
            objDocumentoCompraDet.idItem = i.Cells(2).Value()
            objDocumentoCompraDet.tipoExistencia = i.Cells(13).Value()
            objDocumentoCompraDet.descripcionItem = i.Cells(3).Value()
            objDocumentoCompraDet.unidad1 = i.Cells(6).Value().ToString.Trim
            objDocumentoCompraDet.monto1 = CDec(i.Cells(7).Value())
            objDocumentoCompraDet.unidad2 = i.Cells(4).Value().ToString.Trim 'IDPRESENTACION
            objDocumentoCompraDet.monto2 = i.Cells(5).Value() ' PRESENTACION
            objDocumentoCompraDet.precioUnitario = CDec(i.Cells(8).Value())
            objDocumentoCompraDet.precioUnitarioUS = CDec(i.Cells(9).Value())
            objDocumentoCompraDet.importe = CDec(i.Cells(10).Value())
            objDocumentoCompraDet.importeUS = CDec(i.Cells(11).Value())
            'objDocumentoCompraDet.montokardex = CDec(i.Cells(12).Value())
            'objDocumentoCompraDet.montoIsc = CDec(i.Cells(13).Value())
            'objDocumentoCompraDet.montoIgv = CDec(i.Cells(14).Value())
            'objDocumentoCompraDet.otrosTributos = CDec(i.Cells(15).Value())
            ''**********************************************************************************
            'objDocumentoCompraDet.montokardexUS = CDec(i.Cells(16).Value())
            'objDocumentoCompraDet.montoIscUS = CDec(i.Cells(17).Value())
            'objDocumentoCompraDet.montoIgvUS = CDec(i.Cells(18).Value())
            'objDocumentoCompraDet.otrosTributosUS = CDec(i.Cells(19).Value())
            objDocumentoCompraDet.preEvento = i.Cells(15).Value() '= "00", Nothing, dgvNuevoDoc.Rows(S).Cells(23).Value())
            'objDocumentoCompraDet.bonificacion = i.Cells(29).Value()
            '**********************************************************************************
            objDocumentoCompraDet.usuarioModificacion = "Jiuni"
            'If i.Cells(18).Value() = "Asignar almacén" Then
            '    lblEstado.Enabled = "Debe asignar un almacén en la celda!"


            '    'Timer1.Enabled = True
            '    'TiempoEjecutar(5)
            '    Exit Sub
            'End If
            objDocumentoCompraDet.almacenRef = CInt(i.Cells(17).Value())
            '   objDocumentoCompraDet.almacenDestino = CDec(i.Cells(17).Value())
            objDocumentoCompraDet.fechaModificacion = DateTime.Now
            objDocumentoCompraDet.FechaVcto = Nothing ' IIf(IsNothing(dgvNuevoDoc.Rows(S).Cells(28).Value()), Nothing, CDate(dgvNuevoDoc.Rows(S).Cells(28).Value()))
            objDocumentoCompraDet.Glosa = txtGlosa.Text.Trim ' Glosa()
            ' objDocumentoCompraDet.BonificacionMN =



            ListaDetalle.Add(objDocumentoCompraDet)
            '   End If
        Next
        'TOTALES ALMACEN
        ListaTotales = ListaTotalesAlmacen() '+positivo
        AsientoEntradaExistencia()
        ndocumento.asiento = ListaAsientonTransito
        ndocumento.documentocompra.documentocompradetalle = ListaDetalle
        'TOTALES ALMACEN

        Dim xcod As Integer = CompraSA.SaveOtrasEntradasDefault(ndocumento, ListaTotales)
        lblEstado.Text = "entrada registrada!"

        'Dim n As New ListViewItem(xcod)
        'n.UseItemStyleForSubItems = False
        'n.SubItems.Add("13").BackColor = Color.FromArgb(225, 240, 190)
        'n.SubItems.Add(ndocumento.documentocompra.fechaDoc)
        'n.SubItems.Add(ndocumento.documentocompra.tipoDoc)
        'n.SubItems.Add(ndocumento.documentocompra.serie)
        'n.SubItems.Add(ndocumento.documentocompra.numeroDoc)

        'entidad = entidadSA.UbicarEntidadPorID(txtidProveedor.Text).First()
        'n.SubItems.Add(entidad.tipoDoc)
        'n.SubItems.Add(txtRuc.Text)
        'n.SubItems.Add(txtProveedor.Text)
        'n.SubItems.Add(txtTipoEntidad.Text)

        'n.SubItems.Add(FormatNumber(ndocumento.documentocompra.importeTotal, 2))
        'n.SubItems.Add(FormatNumber(ndocumento.documentocompra.tcDolLoc, 2))
        'n.SubItems.Add(FormatNumber(ndocumento.documentocompra.importeUS, 2))
        'n.SubItems.Add(FormatNumber(ndocumento.documentocompra.monedaDoc, 2))
        'n.SubItems.Add(ndocumento.documentocompra.destino)
        'With frmMantenimientoOtrasEntradas
        '    .lsvProduccion.Items.Add(n)
        'End With
        Dispose()
    End Sub

    Sub UpdateCompra()
        Dim CompraSA As New DocumentoCompraSA
        Dim DocCaja As New documento

        Dim ndocumento As New documento()
        Dim nDocumentoCompra As New documentocompra()
        Dim objDocumentoCompraDet As New documentocompradetalle

        Dim asientoSA As New AsientoSA
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento

        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        Dim objTotalesDet As New totalesAlmacen()
        Dim objActividadDeleteEO As New totalesAlmacen()
        Dim ListaTotales As New List(Of totalesAlmacen)
        Dim ListaDeleteEO As New List(Of totalesAlmacen)
        Dim almacensa As New almacenSA

        Dim ListaDetalle As New List(Of documentocompradetalle)
        With ndocumento
            .idDocumento = lblIdDocumento.Text
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            If Not IsNothing(GProyectos) Then
                .idProyecto = GProyectos.IdProyectoActividad
            End If
            .tipoDoc = "99"
            .fechaProceso = txtFechaComprobante.Value
            .nroDoc = txtSerie.Text.Trim & "-" & txtNumero.Text.Trim
            .idOrden = Nothing ' Me.IdOrden
            .tipoOperacion = "02"
            .usuarioActualizacion = "NN"
            .fechaActualizacion = DateTime.Now
        End With

        With nDocumentoCompra
            .idDocumento = lblIdDocumento.Text
            .idPadre = lblIdDocumento.Text
            .codigoLibro = "13"
            .tipoDoc = "99"
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = txtFechaComprobante.Value
            .fechaContable = PeriodoGeneral
            .serie = txtSerie.Text.Trim
            .numeroDoc = txtNumero.Text
            If chProv.Checked = True Then
                .idProveedor = CInt(txtProveedor.Tag)
            Else
                .idPersona = CInt(txtProveedor.Tag)
            End If
            .nombreProveedor = txtProveedor.Text
            .monedaDoc = IIf(cboMoneda.SelectedValue = "1", "1", "2")
            .tasaIgv = txtIgv.Value ' IIf(IsNothing(nudIgv.Value) Or String.IsNullOrEmpty(nudIgv.Value) Or String.IsNullOrWhiteSpace(nudIgv.Value), Nothing, Trim(nudIgv.Value))
            .tcDolLoc = IIf(txtTipoCambio.Value = 0 Or txtTipoCambio.Value = "0.00", 0, CDec(txtTipoCambio.Value))
            .tipoRecaudo = Nothing
            .regimen = Nothing
            .tasaRegimen = 0
            .nroRegimen = Nothing

            '****************************************************************************************************************
            .importeTotal = CDec(txtTotalmn.Text)
            .importeUS = CDec(txtTotalme.Text)

            .destino = TIPO_COMPRA.MOVIMIENTO_ALMACEN.ENTRADA_EXISTENCIAS
            .estadoPago = TIPO_COMPRA.PAGO.PAGADO
            .glosa = txtGlosa.Text.Trim ' Glosa()
            .referenciaDestino = Nothing ' IIf(IsNothing(txtDestinoref.Text) Or String.IsNullOrEmpty(txtDestinoref.Text) Or String.IsNullOrWhiteSpace(txtDestinoref.Text), Nothing, Trim(txtDestinoref.Text.Trim))
            .tipoCompra = TIPO_COMPRA.OTRAS_ENTRADAS
            ' .DocumentoSustentado = "S"
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With
        ndocumento.documentocompra = nDocumentoCompra

        '   GuiaRemision(ndocumento)

        For Each i As DataGridViewRow In dgvNuevoDoc.Rows

            objDocumentoCompraDet = New documentocompradetalle
            objDocumentoCompraDet.idDocumento = lblIdDocumento.Text
            objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoCompraDet.IdEstablecimiento = almacensa.GetUbicar_almacenPorID(CInt(cboalmacenDestino.SelectedValue)).idEstablecimiento
            objDocumentoCompraDet.FechaDoc = txtFechaComprobante.Value
            objDocumentoCompraDet.CuentaProvedor = txtCuenta
            objDocumentoCompraDet.NombreProveedor = txtProveedor.Text.Trim
            objDocumentoCompraDet.idDocumento = lblIdDocumento.Text
            objDocumentoCompraDet.secuencia = dgvNuevoDoc.Rows(i.Index).Cells(0).Value()
            objDocumentoCompraDet.TipoDoc = "99"
            objDocumentoCompraDet.NumDoc = txtNumero.Text.Trim
            objDocumentoCompraDet.Serie = txtSerie.Text.Trim

            objDocumentoCompraDet.destino = dgvNuevoDoc.Rows(i.Index).Cells(1).Value()

            objDocumentoCompraDet.CuentaItem = dgvNuevoDoc.Rows(i.Index).Cells(14).Value()
            objDocumentoCompraDet.idItem = dgvNuevoDoc.Rows(i.Index).Cells(2).Value()
            objDocumentoCompraDet.tipoExistencia = dgvNuevoDoc.Rows(i.Index).Cells(13).Value()
            objDocumentoCompraDet.descripcionItem = dgvNuevoDoc.Rows(i.Index).Cells(3).Value()
            objDocumentoCompraDet.unidad1 = dgvNuevoDoc.Rows(i.Index).Cells(6).Value()
            objDocumentoCompraDet.monto1 = CDec(dgvNuevoDoc.Rows(i.Index).Cells(7).Value())
            objDocumentoCompraDet.unidad2 = dgvNuevoDoc.Rows(i.Index).Cells(4).Value().ToString.Trim 'IDPRESENTACION
            objDocumentoCompraDet.monto2 = dgvNuevoDoc.Rows(i.Index).Cells(5).Value() ' PRESENTACION
            objDocumentoCompraDet.precioUnitario = CDec(dgvNuevoDoc.Rows(i.Index).Cells(8).Value())
            objDocumentoCompraDet.precioUnitarioUS = CDec(dgvNuevoDoc.Rows(i.Index).Cells(9).Value())
            objDocumentoCompraDet.importe = CDec(dgvNuevoDoc.Rows(i.Index).Cells(10).Value())
            objDocumentoCompraDet.importeUS = CDec(dgvNuevoDoc.Rows(i.Index).Cells(11).Value())

            objDocumentoCompraDet.preEvento = dgvNuevoDoc.Rows(i.Index).Cells(15).Value()

            If dgvNuevoDoc.Rows(i.Index).Cells(12).Value() = Business.Entity.BaseBE.EntityAction.UPDATE Then
                objDocumentoCompraDet.Action = Business.Entity.BaseBE.EntityAction.UPDATE
            ElseIf dgvNuevoDoc.Rows(i.Index).Cells(12).Value() = Business.Entity.BaseBE.EntityAction.INSERT Then
                objDocumentoCompraDet.Action = Business.Entity.BaseBE.EntityAction.INSERT
            ElseIf dgvNuevoDoc.Rows(i.Index).Cells(12).Value() = Business.Entity.BaseBE.EntityAction.DELETE Then
                objDocumentoCompraDet.Action = Business.Entity.BaseBE.EntityAction.DELETE
            End If

            '**********************************************************************************
            'If dgvNuevoDoc.Rows(i.Index).Cells(18).Value() = "Asignar almacén" Then
            '    lblEstado.Text = "Debe asignar un almacén en la celda!"
            '    'Timer1.Enabled = True
            '    'TiempoEjecutar(5)
            '    Exit Sub
            'End If
            objDocumentoCompraDet.almacenRef = CInt(cboalmacenDestino.SelectedValue) ' almacensa.GetUbicar_almacenVirtual(GEstableciento.IdEstablecimiento).idAlmacen
            objDocumentoCompraDet.usuarioModificacion = usuario.IDUsuario
            objDocumentoCompraDet.fechaModificacion = DateTime.Now
            objDocumentoCompraDet.FechaVcto = Nothing
            objDocumentoCompraDet.Glosa = txtGlosa.Text.Trim ' Glosa()
            ListaDetalle.Add(objDocumentoCompraDet)


            If dgvNuevoDoc.Rows(i.Index).Cells(12).Value() <> Business.Entity.BaseBE.EntityAction.DELETE Then
                objTotalesDet = New totalesAlmacen
                objTotalesDet.Action = Business.Entity.BaseBE.EntityAction.INSERT
                objTotalesDet.SecuenciaDetalle = dgvNuevoDoc.Rows(i.Index).Cells(0).Value()
                objTotalesDet.idEmpresa = Gempresas.IdEmpresaRuc
                objTotalesDet.TipoDoc = "99"
                objTotalesDet.Modulo = "N"
                objTotalesDet.idEstablecimiento = almacensa.GetUbicar_almacenPorID(cboalmacenDestino.SelectedValue).idEstablecimiento   ' almacensa.GetUbicar_almacenPorID(CInt(i.Cells(30).Value())).idEstablecimiento
                objTotalesDet.idAlmacen = cboalmacenDestino.SelectedValue
                objTotalesDet.origenRecaudo = dgvNuevoDoc.Rows(i.Index).Cells(1).Value()
                objTotalesDet.tipoCambio = "2.77"
                objTotalesDet.tipoExistencia = dgvNuevoDoc.Rows(i.Index).Cells(13).Value()
                objTotalesDet.idItem = dgvNuevoDoc.Rows(i.Index).Cells(2).Value()
                objTotalesDet.descripcion = dgvNuevoDoc.Rows(i.Index).Cells(3).Value()
                objTotalesDet.idUnidad = dgvNuevoDoc.Rows(i.Index).Cells(6).Value()
                objTotalesDet.unidadMedida = Nothing
                objTotalesDet.cantidad = CType(dgvNuevoDoc.Rows(i.Index).Cells(7).Value(), Decimal)
                objTotalesDet.precioUnitarioCompra = CType(dgvNuevoDoc.Rows(i.Index).Cells(8).Value(), Decimal)

                objTotalesDet.importeSoles = CType(dgvNuevoDoc.Rows(i.Index).Cells(10).Value(), Decimal)
                objTotalesDet.importeDolares = CType(dgvNuevoDoc.Rows(i.Index).Cells(11).Value(), Decimal)

                objTotalesDet.montoIsc = 0
                objTotalesDet.montoIscUS = 0
                objTotalesDet.Otros = 0
                objTotalesDet.OtrosUS = 0
                objTotalesDet.porcentajeUtilidad = 0
                objTotalesDet.importePorcentaje = 0
                objTotalesDet.importePorcentajeUS = 0
                objTotalesDet.precioVenta = 0
                objTotalesDet.precioVentaUS = 0
                objTotalesDet.usuarioActualizacion = "NN"
                objTotalesDet.fechaActualizacion = Date.Now
                ListaTotales.Add(objTotalesDet)
            End If

            If dgvNuevoDoc.Rows(i.Index).Cells(12).Value() = Business.Entity.BaseBE.EntityAction.UPDATE Or
                dgvNuevoDoc.Rows(i.Index).Cells(12).Value() = Business.Entity.BaseBE.EntityAction.DELETE Then
                Dim almacenVR As New almacen
                Dim almacenFS As New almacen
                objActividadDeleteEO = New totalesAlmacen
                objActividadDeleteEO.Action = Business.Entity.BaseBE.EntityAction.INSERT
                objActividadDeleteEO.TipoDoc = "99"
                objActividadDeleteEO.SecuenciaDetalle = dgvNuevoDoc.Rows(i.Index).Cells(0).Value()
                objActividadDeleteEO.idEmpresa = Gempresas.IdEmpresaRuc
                objActividadDeleteEO.Modulo = "N"
                'almacenFS = almacensa.GetUbicar_almacenPorID(CInt(dgvNuevoDoc.Rows(i.Index).Cells(30).Value()))
                'If Not IsNothing(almacenFS) Then
                objActividadDeleteEO.idEstablecimiento = almacensa.GetUbicar_almacenPorID(CInt(cboAlmacen.SelectedValue)).idEstablecimiento '   txtIdEstableAlmacen.Text
                objActividadDeleteEO.idAlmacen = cboAlmacen.SelectedValue ' dgvNuevoDoc.Rows(i.Index).Cells(20).Value() ' txtIdAlmacen.Text ' almacenFS.idAlmacen ' dgvNuevoDoc.Rows(i.Index).Cells(30).Value()
                'Else
                '    almacenVR = almacensa.GetUbicar_almacenVirtual(GEstableciento.IdEstablecimiento)
                '    If Not IsNothing(almacenVR) Then
                '        objActividadDeleteEO.idEstablecimiento = almacenVR.idEstablecimiento
                '        objActividadDeleteEO.idAlmacen = almacenVR.idAlmacen
                '    End If

                ' End If
                objActividadDeleteEO.origenRecaudo = dgvNuevoDoc.Rows(i.Index).Cells(1).Value()
                objActividadDeleteEO.tipoCambio = "2.77"
                objActividadDeleteEO.tipoExistencia = dgvNuevoDoc.Rows(i.Index).Cells(13).Value()
                objActividadDeleteEO.idItem = dgvNuevoDoc.Rows(i.Index).Cells(2).Value()
                objActividadDeleteEO.descripcion = dgvNuevoDoc.Rows(i.Index).Cells(3).Value()
                ListaDeleteEO.Add(objActividadDeleteEO)
            End If



        Next
        AsientoEntradaExistencia()
        ndocumento.asiento = ListaAsientonTransito
        ndocumento.documentocompra.documentocompradetalle = ListaDetalle

        CompraSA.UpdateOtrasEntradas(ndocumento, ListaTotales, ListaDeleteEO)
        lblEstado.Text = "entrada modificada!"

        '    entidad = entidadSA.UbicarEntidadPorID(txtidProveedor.Text).First

        'With frmMantenimientoOtrasEntradas
        '    .lsvProduccion.SelectedItems(0).SubItems(1).Text = "02"
        '    .lsvProduccion.SelectedItems(0).SubItems(1).BackColor = Color.FromArgb(225, 240, 190)
        '    .lsvProduccion.SelectedItems(0).SubItems(2).Text = ndocumento.documentocompra.fechaDoc
        '    .lsvProduccion.SelectedItems(0).SubItems(3).Text = ndocumento.documentocompra.tipoDoc
        '    .lsvProduccion.SelectedItems(0).SubItems(4).Text = ndocumento.documentocompra.serie
        '    .lsvProduccion.SelectedItems(0).SubItems(5).Text = ndocumento.documentocompra.numeroDoc
        '    .lsvProduccion.SelectedItems(0).SubItems(6).Text = entidad.tipoDoc
        '    .lsvProduccion.SelectedItems(0).SubItems(7).Text = txtRuc.Text
        '    .lsvProduccion.SelectedItems(0).SubItems(8).Text = txtProveedor.Text
        '    .lsvProduccion.SelectedItems(0).SubItems(9).Text = txtTipoEntidad.Text
        '    .lsvProduccion.SelectedItems(0).SubItems(10).Text = FormatNumber(ndocumento.documentocompra.importeTotal, 2)
        '    .lsvProduccion.SelectedItems(0).SubItems(11).Text = FormatNumber(ndocumento.documentocompra.tcDolLoc, 2)
        '    .lsvProduccion.SelectedItems(0).SubItems(12).Text = FormatNumber(ndocumento.documentocompra.importeUS, 2)
        '    .lsvProduccion.SelectedItems(0).SubItems(13).Text = ndocumento.documentocompra.monedaDoc
        '    .lsvProduccion.SelectedItems(0).SubItems(14).Text = ndocumento.documentocompra.destino
        'End With

        Dispose()
    End Sub

    Sub Productoshijos()
        Dim categoriaSA As New itemSA

        cboProductos.DisplayMember = "descripcion"
        cboProductos.ValueMember = "idItem"
        cboProductos.DataSource = categoriaSA.GetListaMarcaPadre(CboClasificacion.SelectedValue)
    End Sub


    Private Sub Validar_Numeros(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        'Dim Celda As DataGridViewCell = Me.dgvNuevoDoc.CurrentCell()

        'If Celda.ColumnIndex = 7 Or Celda.ColumnIndex = 10 Or Celda.ColumnIndex = 11 Then

        '    If e.KeyChar = "."c Or e.KeyChar = ","c Then

        '        If InStr(Celda.EditedFormattedValue.ToString, ".", CompareMethod.Text) > 0 Then

        '            e.Handled = True
        '        Else

        '            e.Handled = False
        '        End If
        '    Else

        '        If Len(Trim(Celda.EditedFormattedValue.ToString)) > 0 Then

        '            If Char.IsNumber(e.KeyChar) Or e.KeyChar = Convert.ToChar(8) Then

        '                e.Handled = False
        '            Else

        '                e.Handled = True
        '            End If
        '        Else

        '            If e.KeyChar = "0"c Then

        '                e.Handled = True
        '            Else

        '                If Char.IsNumber(e.KeyChar) Or e.KeyChar = Convert.ToChar(8) Then

        '                    e.Handled = False
        '                Else

        '                    e.Handled = True
        '                End If
        '            End If
        '        End If
        '    End If
        'End If
    End Sub
    Public Sub CargarListas()
        Dim tablaSA As New tablaDetalleSA
        Dim almacenSA As New almacenSA
        '   Dim entidadSA As New entidadSA
        Dim almacen As New List(Of almacen)

        Dim categoriaSA As New itemSA

        almacen = almacenSA.GetListar_almacenExceptAV(GEstableciento.IdEstablecimiento)
        cboAlmacen.ValueMember = "idAlmacen"
        cboAlmacen.DisplayMember = "descripcionAlmacen"
        cboAlmacen.DataSource = almacen



        cboTipoExistencia.ValueMember = "codigoDetalle"
        cboTipoExistencia.DisplayMember = "descripcion"
        cboTipoExistencia.DataSource = tablaSA.GetListaTablaDetalle(5, "1")

        cboMoneda.ValueMember = "codigoDetalle"
        cboMoneda.DisplayMember = "descripcion"
        cboMoneda.DataSource = tablaSA.GetListaTablaDetalle(4, "1")


        CboClasificacion.DisplayMember = "descripcion"
        CboClasificacion.ValueMember = "idItem"
        CboClasificacion.DataSource = categoriaSA.GetListaPadre()

    End Sub

    Private Sub ValidarCantidad(pos As Integer)
        'If Not CStr(dgvNuevoDoc.Item(7, pos).Value).Trim.Length > 0 Then
        '    dgvNuevoDoc.Item(7, pos).Value = cantidaExistente.Item(pos)
        '    lblEstado.Text = "Ingrese una cantidad válida!"
        '    Exit Sub
        'End If
        ''Valida que la cantidad sea mayor que cero
        'If dgvNuevoDoc.Item(7, pos).Value <= 0 Then
        '    dgvNuevoDoc.Item(7, pos).Value = cantidaExistente.Item(pos)
        '    lblEstado.Text = "Ingrese una cantidad mayor que 0!"
        '    Exit Sub
        'End If
        ''Se valida que no se transfiera una cantidad mayor a la existente
        'If dgvNuevoDoc.Item(7, pos).Value > cantidaExistente.Item(pos) Then
        '    Dim title = "Cantidad Incorrecta"
        '    Dim msg = "La cantidad a transferir debe ser menor o igual a la cantidad exitente en el almacén"
        '    MsgBox(msg, , title)
        '    dgvNuevoDoc.Item(7, pos).Value = cantidaExistente.Item(pos)
        '    Exit Sub
        'End If
    End Sub

    Public Sub ObtenerListadoPreciosLiked(intIdAlmacen As Integer, strtipoEx As String, strBusqueda As String)
        Dim tablaSA As New tablaDetalleSA
        Dim totalSA As New TotalesAlmacenSA
        Try
            lsvExistencias.Items.Clear()
            For Each i As totalesAlmacen In totalSA.GetProductoPorAlmacenTipoEx(intIdAlmacen, strtipoEx, strBusqueda)
                Dim n As New ListViewItem(i.idEstablecimiento)
                n.SubItems.Add(i.origenRecaudo)
                n.SubItems.Add(i.idItem)
                n.SubItems.Add(i.descripcion)
                n.SubItems.Add(i.unidadMedida)
                n.SubItems.Add(tablaSA.GetUbicarTablaID(21, i.Presentacion).descripcion)
                n.SubItems.Add(FormatNumber(i.cantidad, 2))
                n.SubItems.Add(FormatNumber(i.importeSoles, 2))
                n.SubItems.Add(FormatNumber(i.importeDolares, 2))
                If CDec(i.cantidad) > 0 Then
                    n.SubItems.Add(CDec(i.importeSoles) / CDec(i.cantidad))
                Else
                    n.SubItems.Add(0)
                End If

                If CDec(i.cantidad) > 0 Then
                    n.SubItems.Add(CDec(i.importeDolares) / CDec(i.cantidad))
                Else
                    n.SubItems.Add(0)
                End If
                lsvExistencias.Items.Add(n)
            Next
            For Each item As ListViewItem In lsvExistencias.Items
                Dim i As Short
                If i Mod 2 = 0 Then
                    item.BackColor = Color.Transparent
                    item.ForeColor = Color.Gray
                Else
                    item.BackColor = Color.WhiteSmoke
                    item.ForeColor = Color.Gray
                End If
                i = i + 1
            Next
        Catch ex As Exception
            MsgBox("No se pudo cargar la informacion de la BD." & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del Sistema.!")
        End Try
    End Sub

    Sub deletefila()
        'Dim fila As Byte
        'Try
        '    fila = dgvNuevoDoc.CurrentCell.RowIndex
        '    If fila > -1 And dgvNuevoDoc.Rows.Count > 0 Then
        '        '  total -= Single.Parse(dgvCentroCostos.Item(0, fila).Value)
        '        dgvNuevoDoc.Rows.RemoveAt(fila)
        '        Dim i As Integer
        '        For i = 0 To dgvNuevoDoc.Rows.Count - 1
        '            dgvNuevoDoc.BeginEdit(True)
        '            ' dgvNuevoDoc.Rows(i).BeginEdit()
        '            '      dgvCentroCostos.Rows(i).Cells(0).Value() = i + 1
        '            dgvNuevoDoc.EndEdit()
        '        Next

        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub

    'Public Sub cambioMovimiento()
    '    dgvNuevoDoc.Rows.Clear()
    '    ListaAsientonTransito.Clear()
    '    Can1.DefaultCellStyle.BackColor = Color.Yellow
    '    ImporteNeto.DefaultCellStyle.BackColor = Color.White
    '    ImporteUS.DefaultCellStyle.BackColor = Color.White
    '    Select Case lblMovimiento.Text
    '        Case "TRANSFERENCIA ENTRE ALMACENES"
    '            '  Label9.Text = "Almacén de origen:"
    '            'columnas DGV
    '            'Prec.ReadOnly = True
    '            Prec.DefaultCellStyle.BackColor = Color.White
    '            'PrecUnitUS.ReadOnly = True
    '        Case "OTRAS ENTRADAS DE EXISTENCIAS"
    '            'TabPage9.Parent = Nothing
    '            'LoadTree(0)
    '            'Label9.Text = "Almacén de destino:"

    '            'columnas DGV
    '            'Prec.ReadOnly = False
    '            Prec.DefaultCellStyle.BackColor = Color.Yellow
    '            'PrecUnitUS.ReadOnly = True
    '        Case "OTROS MOVIMIENTOS"
    '            'TabPage9.Parent = TabCompra
    '            'LoadTree(1)

    '            'If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
    '            '    Dim datos As List(Of Asientos_MN) = Asientos_MN.GetAsientos()
    '            '    Dim datosMov As List(Of Movimientos) = Movimientos.GetMovimientos()
    '            '    datos.Clear()
    '            '    datosMov.Clear()
    '            'End If
    '            'Label9.Text = "Almacén de destino:"
    '            'Prec.ReadOnly = False
    '            'Prec.DefaultCellStyle.BackColor = Color.Yellow
    '            'PrecUnitUS.ReadOnly = True
    '    End Select
    'End Sub

    Public Sub TotalesCabeceras()
        Dim cTotalMN As Decimal = 0
        Dim cTotalME As Decimal = 0


        For Each i As DataGridViewRow In dgvNuevoDoc.Rows
            If i.Cells(12).Value <> Helios.Cont.Business.Entity.BaseBE.EntityAction.DELETE Then
                cTotalMN += CDec(i.Cells(10).Value)
                cTotalME += CDec(i.Cells(11).Value)
            End If
        Next
        txtTotalmn.Text = cTotalMN.ToString("N2")
        txtTotalme.Text = cTotalME.ToString("N2")

    End Sub

    Private Sub CellEndEditRefresh()
        Dim colDestinoGravado As Decimal = 0
        Dim colPrecUnit As Decimal = 0
        Dim colCantidad As Decimal = 0
        Dim colPrecUnitUSD As Decimal = 0

        '**************************************************************
        If dgvNuevoDoc.Rows.Count > 0 Then
            'DECLARANDO VARIABLES

            For Each i As DataGridViewRow In dgvNuevoDoc.Rows
                If i.Cells(12).Value <> Helios.Cont.Business.Entity.BaseBE.EntityAction.DELETE Then

                    colDestinoGravado = i.Cells(1).Value
                    'DECLARANDO VARIABLES
                    colPrecUnit = i.Cells(8).Value
                    colPrecUnitUSD = i.Cells(9).Value

                    If Not CStr(i.Cells(7).Value).Trim.Length > 0 Then
                        lblEstado.Text = "Ingrese una cantidad válida!"
                        Exit Sub
                    Else
                        colCantidad = i.Cells(7).Value
                    End If

                    Dim colMN As Decimal = 0
                    colMN = Math.Round(colCantidad * colPrecUnit, 2)

                    Dim colME As Decimal = 0
                    colME = Math.Round(colCantidad * colPrecUnitUSD, 2)

                    i.Cells(10).Value = colMN.ToString("N2")
                    i.Cells(11).Value = colME.ToString("N2")

                End If

            Next
            TotalesCabeceras()
        Else
            TotalesCabeceras()
        End If


    End Sub

    'Sub MostrarDetalle()
    '    Me.Cursor = Cursors.WaitCursor
    '    Dim objInsumo As GInsumo = GInsumo.InstanceSingle()
    '    Dim strAlmacen As String = Nothing
    '    objInsumo.Clear()
    '    With frmModalExistencia
    '        .StartPosition = FormStartPosition.CenterParent
    '        .ShowDialog()
    '        '  lblTotalItems.Text = "Nro. de items: " & dgvNuevoDoc.Rows.Count

    '        Select Case ManipulacionEstado
    '            Case ENTITY_ACTIONS.INSERT
    '                If Not IsNothing(objInsumo.descripcionItem) Then
    '                    dgvNuevoDoc.Rows.Add(0, objInsumo.origenProducto, objInsumo.IdInsumo, objInsumo.descripcionItem,
    '                                         objInsumo.presentacion,
    '                                             objInsumo.Nombrepresentacion,
    '                                             objInsumo.unidad1, objInsumo.Cantidad, objInsumo.PU,
    '                                             objInsumo.PU, objInsumo.Total, objInsumo.Total,
    '                                             Business.Entity.BaseBE.EntityAction.INSERT,
    '                                          objInsumo.tipoExistencia, objInsumo.cuenta, objInsumo.IdActividadRecurso, Nothing,
    '                                          cboAlmacen.ValueMember, cboAlmacen.Text, txtEstablecimiento.ValueMember)
    '                End If
    '            Case ENTITY_ACTIONS.UPDATE
    '                If Not IsNothing(objInsumo.descripcionItem) Then
    '                    dgvNuevoDoc.Rows.Add(0, objInsumo.origenProducto, objInsumo.IdInsumo, objInsumo.descripcionItem,
    '                                         objInsumo.presentacion,
    '                                             objInsumo.Nombrepresentacion,
    '                                             objInsumo.unidad1, objInsumo.Cantidad, objInsumo.PU,
    '                                             objInsumo.PU, objInsumo.Total, objInsumo.Total,
    '                                             Business.Entity.BaseBE.EntityAction.INSERT,
    '                                          objInsumo.tipoExistencia, objInsumo.cuenta, objInsumo.IdActividadRecurso, Nothing,
    '                                          Nothing, "Asignar almacén", txtEstablecimiento.ValueMember)
    '                End If
    '        End Select


    '        If dgvNuevoDoc.Rows.Count > 0 Then
    '            CellEndEditRefresh()
    '        End If

    '        If dgvNuevoDoc.Visible Then
    '            If dgvNuevoDoc.Rows.Count > 0 Then
    '                Me.dgvNuevoDoc.CurrentCell = Me.dgvNuevoDoc.Rows(dgvNuevoDoc.Rows.Count - 1).Cells(5)
    '                Me.dgvNuevoDoc.BeginEdit(True)
    '            End If
    '        Else
    '            'If dgvSinControl.Rows.Count > 0 Then
    '            '    Me.dgvSinControl.CurrentCell = Me.dgvSinControl.Rows(dgvSinControl.Rows.Count - 1).Cells(10)
    '            '    Me.dgvSinControl.BeginEdit(True)
    '            'End If
    '        End If
    '    End With
    '    Me.Cursor = Cursors.Arrow
    'End Sub
#End Region

    Private Sub frmCambioTipoExistencia_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dispose()
    End Sub

    Dim comboTable As New DataTable
    Public Function GetTableAlmacen() As DataTable


        Dim cuentaSA As New cuentaplanContableEmpresaSA
        Dim dt As New DataTable()
        dt.Columns.Add("idCuenta", GetType(Integer))
        dt.Columns.Add("descripcionCuenta", GetType(String))

        For Each i In cuentaSA.ObtenerCuentasPorEmpresa(Gempresas.IdEmpresaRuc)
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.cuenta
            dr(1) = i.cuenta
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Public Function GetTableAsientos() As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("id", GetType(String))
        dt.Columns.Add("name", GetType(String))

        Dim dr As DataRow = dt.NewRow()
        dr(0) = "D"
        dr(1) = "DEBE"
        dt.Rows.Add(dr)

        Dim dr1 As DataRow = dt.NewRow()
        dr1(0) = "H"
        dr1(1) = "HABER"
        dt.Rows.Add(dr1)

        Return dt

    End Function

    Public Sub GetTableAlmacen2()
        Dim cuentaSA As New cuentaplanContableEmpresaSA
        comboTableh = New DataTable("Cuentas")
        comboTableh.Columns.Add("idCuenta")
        comboTableh.Columns.Add("descripcionCuenta")

        For Each i In cuentaSA.ObtenerCuentasPorEmpresaEscalableV2(Gempresas.IdEmpresaRuc)
            comboTableh.Rows.Add(New Object() {i.cuenta, i.descripcion})
        Next

    End Sub

    Dim comboTableh As New DataTable


    Private Sub frmCambioTipoExistencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetTableAlmacen2()

        Dim ggcStyle7 As GridTableCellStyleInfo = dgvCompra.TableDescriptor.Columns(2).Appearance.AnyRecordFieldCell
        ggcStyle7.CellType = "ComboBox"
        ggcStyle7.DataSource = Me.comboTableh
        ggcStyle7.ValueMember = "idCuenta"
        ggcStyle7.DisplayMember = "descripcionCuenta"
        ggcStyle7.DropDownStyle = GridDropDownStyle.AutoComplete

        Dim ggcStyle3 As GridTableCellStyleInfo = dgvCompra.TableDescriptor.Columns(3).Appearance.AnyRecordFieldCell
        ggcStyle7.CellType = "ComboBox"
        ggcStyle7.DataSource = Me.comboTableh
        ggcStyle7.DropDownStyle = GridDropDownStyle.AutoComplete
        dgvCompra.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
        dgvCompra.ShowRowHeaders = False


        Dim ggcStyle2 As GridTableCellStyleInfo = dgvCompra.TableDescriptor.Columns(3).Appearance.AnyRecordFieldCell
        ggcStyle2.CellType = "ComboBox"
        ggcStyle2.DataSource = Me.GetTableAsientos
        ggcStyle2.ValueMember = "id"
        ggcStyle2.DisplayMember = "name"
        ggcStyle2.DropDownStyle = GridDropDownStyle.Exclusive

        dgvCompra.ActivateCurrentCellBehavior = GridCellActivateAction.SelectAll
        dgvCompra.ShowRowHeaders = False

        RegistrarAsientos()
    End Sub

    Private Sub txtBuscarProducto_TextChanged(sender As Object, e As EventArgs) Handles txtBuscarProducto.TextChanged
       
    End Sub

    Private Sub lsvExistencias_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvExistencias.MouseDoubleClick
        Me.Cursor = Cursors.WaitCursor
        Dim n As New RecolectarDatos()
        Dim datos As List(Of RecolectarDatos) = RecolectarDatos.Instance()
        Dim itemsSA As New detalleitemsSA
        Dim almacenSA As New almacenSA
        Dim boollExiste As Boolean = False
        Try
            If lsvExistencias.SelectedItems.Count > 0 Then
               
                Select Case lblMovimiento.Text
                    Case "TRANSFERENCIA ENTRE ALMACENES"


                        With itemsSA.InvocarProductoID(lsvExistencias.SelectedItems(0).SubItems(2).Text)
                            strUM = .unidad1
                            strTipoEx = .tipoExistencia
                            strCuenta = .cuenta
                            strIdPresentacion = .presentacion
                        End With
                        With almacenSA.GetUbicar_almacenPorID(CInt(cboAlmacen.SelectedValue))
                            srtNomAlmacen = .descripcionAlmacen
                            intIdEstableAlm = .idEstablecimiento
                        End With

                        'se valida que el articulo seleccionado para transferir no se duplique
                        If dgvNuevoDoc.RowCount > 0 Then

                            For i As Integer = 0 To dgvNuevoDoc.RowCount - 1
                                If dgvNuevoDoc.Item(2, i).Value = lsvExistencias.SelectedItems(0).SubItems(2).Text Then
                                    boollExiste = True
                                    Exit For
                                End If
                            Next
                        End If

                        If Not boollExiste Then
                            cantidaExistente.Add(lsvExistencias.SelectedItems(0).SubItems(6).Text)

                            dgvNuevoDoc.Rows.Add("0",
                                                 lsvExistencias.SelectedItems(0).SubItems(1).Text,
                                                 lsvExistencias.SelectedItems(0).SubItems(2).Text,
                                                 lsvExistencias.SelectedItems(0).SubItems(3).Text,
                                                  strIdPresentacion,
                                                  lsvExistencias.SelectedItems(0).SubItems(5).Text,
                                                 strUM,
                                                 lsvExistencias.SelectedItems(0).SubItems(6).Text,
                                                 lsvExistencias.SelectedItems(0).SubItems(9).Text,
                                                 lsvExistencias.SelectedItems(0).SubItems(10).Text,
                                                 0,
                                                 0,
                                                  Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT,
                                                  strTipoEx,
                                                  strCuenta,
                                                 Nothing, Nothing,
                                                  Nothing,
                                                  "Asignar almacén",
                                                  intIdEstableAlm, Nothing,
                                                  CInt(cboAlmacen.SelectedValue), lsvExistencias.SelectedItems(0).SubItems(6).Text)
                        Else
                            boollExiste = False
                            lblEstado.Text = "El articulo ya existe en la lista!"
                            'Timer1.Enabled = True
                            'TiempoEjecutar(5)

                        End If
                    Case Else

                End Select


                '   End If
            End If
            If dgvNuevoDoc.Rows.Count > 0 Then
                CellEndEditRefresh()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lsvExistencias_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvExistencias.SelectedIndexChanged

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        'If dgvNuevoDoc.Rows.Count > 0 Then

        '    If Not IsNothing(dgvNuevoDoc.CurrentRow) Then



        '        If dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value = Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT Then
        '            deletefila()
        '        ElseIf dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value = Helios.Cont.Business.Entity.BaseBE.EntityAction.UPDATE Then
        '            '   DeleteFilaDetalle(dgvNuevoDoc.Item(0, dgvNuevoDoc.CurrentRow.Index).Value)
        '            dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value = Helios.Cont.Business.Entity.BaseBE.EntityAction.DELETE
        '            Dim pos As Integer = Me.dgvNuevoDoc.CurrentRow.Index
        '            cantidaExistente.RemoveAt(pos)
        '            dgvNuevoDoc.CurrentCell = Nothing
        '            Me.dgvNuevoDoc.Rows(pos).Visible = False

        '            '     deletefila()

        '        End If
        '        '      lblTotalItems.Text = dgvNuevoDoc.DisplayedRowCount(True) & " Filas"
        '        If dgvNuevoDoc.Rows.Count > 0 Then
        '            CellEndEditRefresh()
        '        End If
        '    End If
        'End If
    End Sub

    Private Sub dgvNuevoDoc_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvNuevoDoc.TableControlCellClick

    End Sub

    Private Sub dgvNuevoDoc_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvNuevoDoc.TableControlCurrentCellEditingComplete
        'If e.RowIndex > -1 Then
        '    Dim colDestinoGravado As Decimal = 0
        '    Dim colPrecUnit As Decimal = 0
        '    Dim colCantidad As Decimal = 0
        '    Dim colPM As Decimal = 0
        '    Dim colPrecUnitUSD As Decimal = 0
        '    Dim headerText As String = _
        ' dgvNuevoDoc.Columns(e.ColumnIndex).Name

        '    ' Abort validation if cell is not in the CompanyName column.

        '    dgvNuevoDoc.Rows(e.RowIndex).ErrorText = String.Empty
        '    If dgvNuevoDoc.Rows.Count > 0 Then
        '        colDestinoGravado = dgvNuevoDoc.Item(1, dgvNuevoDoc.CurrentRow.Index).Value

        '        Select Case lblMovimiento.Text
        '            Case "TRANSFERENCIA ENTRE ALMACENES"
        '                Dim colCant As Decimal = 0
        '                colCant = CDec(dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value)
        '                'DECLARANDO VARIABLES
        '                colPrecUnit = dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value
        '                colPrecUnitUSD = dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value

        '                '  ValidarCantidad(dgvNuevoDoc.CurrentRow.Index)
        '                'Valida que la cantidad no este vacia
        '                If Not CStr(dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value).Trim.Length > 0 Then
        '                    dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value = 0
        '                    lblEstado.Text = "Ingrese una cantidad válida!"
        '                    Exit Sub
        '                End If
        '                ''Valida que la cantidad sea mayor que cero
        '                If colCant <= 0 Then
        '                    dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value = 0
        '                    lblEstado.Text = "Ingrese una cantidad mayor que 0!"
        '                    Exit Sub
        '                End If

        '                'Se valida que no se transfiera una cantidad mayor a la existente
        '                If colCant > CDec(dgvNuevoDoc.Item(22, dgvNuevoDoc.CurrentRow.Index).Value) Then
        '                    Dim title = "Cantidad Incorrecta"
        '                    Dim msg = "La cantidad a transferir debe ser menor o igual a la cantidad exitente en el almacén"
        '                    MsgBox(msg, , title)
        '                    dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value = 0
        '                    Exit Sub
        '                End If

        '            Case "OTRAS ENTRADAS DE EXISTENCIAS"
        '                'DECLARANDO VARIABLES
        '                colPrecUnit = dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value
        '                colPrecUnitUSD = Math.Round(colPrecUnit / txtTipoCambio.Value, 2)
        '                dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value = colPrecUnitUSD.ToString("N2")
        '        End Select


        '        Dim colMN As Decimal = 0
        '        Dim colME As Decimal = 0

        '        Dim Celda As DataGridViewCell = Me.dgvNuevoDoc.CurrentCell()

        '        If Celda.ColumnIndex = 7 Then
        '            If Not CStr(dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value).Trim.Length > 0 Then
        '                lblEstado.Text = "Ingrese una cantidad válida!"
        '                Exit Sub
        '            Else
        '                colCantidad = dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value
        '                colMN = Math.Round(colCantidad * colPrecUnit, 2)
        '                colME = Math.Round(colCantidad * colPrecUnitUSD, 2)
        '                dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value = colMN.ToString("N2")
        '                dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value = colME.ToString("N2")
        '            End If
        '        ElseIf Celda.ColumnIndex = 8 Then
        '            If Not CStr(dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value).Trim.Length > 0 Then
        '                lblEstado.Text = "Ingrese un precio unitario válida!"
        '                Exit Sub
        '            Else

        '                If CDec(dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value) <= 0 Then
        '                    lblEstado.Text = "Ingrese un precio unitario mayor a cero!"
        '                    dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value = 0
        '                    Exit Sub
        '                End If

        '                colPM = dgvNuevoDoc.Item(8, dgvNuevoDoc.CurrentRow.Index).Value
        '                colMN = Math.Round(CDec(dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value) * colPM, 2)
        '                colME = 0.0
        '                dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value = 0.0
        '                dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value = colMN.ToString("N2")
        '                dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value = colME.ToString("N2")
        '            End If
        '        ElseIf Celda.ColumnIndex = 9 Then
        '            If Not CStr(dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value).Trim.Length > 0 Then
        '                lblEstado.Text = "Ingrese un precio unitario extranjero válida!"
        '                Exit Sub
        '            Else
        '                Dim colPMExtranjero As Decimal = 0
        '                colPMExtranjero = dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value
        '                colCantidad = dgvNuevoDoc.Item(7, dgvNuevoDoc.CurrentRow.Index).Value
        '                colME = CDec(colCantidad) * colPMExtranjero
        '                'dgvNuevoDoc.Item(9, dgvNuevoDoc.CurrentRow.Index).Value = 0.0
        '                'dgvNuevoDoc.Item(10, dgvNuevoDoc.CurrentRow.Index).Value = colMN.ToString("N2")
        '                dgvNuevoDoc.Item(11, dgvNuevoDoc.CurrentRow.Index).Value = colME.ToString("N2")
        '            End If
        '        End If



        '    End If
        '    TotalesCabeceras()
        'End If

    End Sub

    Private Sub txtSerie_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSerie.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtNumero.Focus()
        End If
    End Sub

    Private Sub txtSerie_LostFocus(sender As Object, e As EventArgs) Handles txtSerie.LostFocus
        Try
            If txtSerie.Text.Trim.Length > 0 Then
                '  If chFormato.Checked = True Then
                txtSerie.Text = String.Format("{0:00000}", Convert.ToInt32(txtSerie.Text))
                'End If
            End If

        Catch ex As Exception

            If IsNumeric(Microsoft.VisualBasic.Mid(Trim(txtSerie.Text), 2, 1)) = True Then

                If IsNumeric(Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 1)) = True Then

                    If Not IsNumeric(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1)) = True Then

                        If Len(txtSerie.Text) <= 2 Then

                            txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + "000" + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 1))

                        ElseIf Len(txtSerie.Text) <= 3 Then

                            txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + "00" + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 2))

                        ElseIf Len(txtSerie.Text) <= 4 Then

                            txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + "0" + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 3))

                        ElseIf Len(txtSerie.Text) <= 5 Then

                            txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 4))

                        End If
                    End If
                Else

                    txtSerie.Select()
                    txtSerie.Focus()
                    txtSerie.Clear()
                    lblEstado.Text = "INGRESE PRIMERO SOLO UNA LETRA SEGUIDO DE UN NUMERO"
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)

                End If

            Else

                txtSerie.Select()
                txtSerie.Focus()
                txtSerie.Clear()
                lblEstado.Text = "INGRESE PRIMERO SOLO UNA LETRA SEGUIDO DE UN NUMERO"
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
            End If

        End Try
    End Sub

    Private Sub txtSerie_TextChanged(sender As Object, e As EventArgs) Handles txtSerie.TextChanged

    End Sub

    Private Sub txtNumero_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumero.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtProveedor.Select()
            txtProveedor.Focus()
        End If
    End Sub

    Private Sub txtNumero_LostFocus(sender As Object, e As EventArgs) Handles txtNumero.LostFocus
        Try
            If txtNumero.Text.Trim.Length > 0 Then
                '    If chFormato.Checked = True Then
                txtNumero.Text = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumero.Text))

                'End If
            End If
        Catch ex As Exception
            'MessageBoxAdv.Show("Error de formato!", "Atención", Nothing, MessageBoxIcon.Error)
            txtNumero.Select()
            txtNumero.Focus()
            txtNumero.Clear()
            lblEstado.Text = "Error de formato verifiuqe el ingreso!"
        End Try
    End Sub

    Private Sub txtNumero_TextChanged(sender As Object, e As EventArgs) Handles txtNumero.TextChanged

    End Sub

    Private Sub btnGrabTRab_Click(sender As Object, e As EventArgs) Handles btnGrabTRab.Click
        If Not txtDniTrab.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese el nro de documento del trabajador"
            pcTrabajador.Font = New Font("Segoe UI", 8)
            pcTrabajador.Size = New Size(327, 250)
            Me.pcTrabajador.ParentControl = Me.txtProveedor
            Me.pcTrabajador.ShowPopup(Point.Empty)
            txtDniTrab.Select()
            Exit Sub
        End If

        If Not txtNombreTrab.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese el nombre del trabajador"
            pcTrabajador.Font = New Font("Segoe UI", 8)
            pcTrabajador.Size = New Size(327, 250)
            Me.pcTrabajador.ParentControl = Me.txtProveedor
            Me.pcTrabajador.ShowPopup(Point.Empty)
            txtNombreTrab.Select()
            Exit Sub
        End If

        If Not txtAppatTrab.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese los apellidos del trabajador"
            pcTrabajador.Font = New Font("Segoe UI", 8)
            pcTrabajador.Size = New Size(327, 250)
            Me.pcTrabajador.ParentControl = Me.txtProveedor
            Me.pcTrabajador.ShowPopup(Point.Empty)
            txtAppatTrab.Select()
            Exit Sub
        End If

        If Not txtApmatTrab.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese los apellidos del trabajador"
            pcTrabajador.Font = New Font("Segoe UI", 8)
            pcTrabajador.Size = New Size(327, 250)
            Me.pcTrabajador.ParentControl = Me.txtProveedor
            Me.pcTrabajador.ShowPopup(Point.Empty)
            txtApmatTrab.Select()
            Exit Sub
        End If

        btnGrabTRab.Tag = "G"
        Me.pcTrabajador.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub ButtonAdv8_Click(sender As Object, e As EventArgs) Handles ButtonAdv8.Click
        Me.pcTrabajador.HidePopup(PopupCloseType.Canceled)
    End Sub

    Private Sub pcTrabajador_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles pcTrabajador.BeforePopup
        Me.pcTrabajador.BackColor = Color.White
    End Sub

    Private Sub pcTrabajador_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcTrabajador.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If Not txtDniTrab.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese el nro de documento del trabajador"
                pcTrabajador.Font = New Font("Segoe UI", 8)
                pcTrabajador.Size = New Size(327, 250)
                Me.pcTrabajador.ParentControl = Me.txtProveedor
                Me.pcTrabajador.ShowPopup(Point.Empty)
                txtDniTrab.Select()
                Exit Sub
            End If

            If Not txtNombreTrab.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese el nombre del trabajador"
                pcTrabajador.Font = New Font("Segoe UI", 8)
                pcTrabajador.Size = New Size(327, 250)
                Me.pcTrabajador.ParentControl = Me.txtProveedor
                Me.pcTrabajador.ShowPopup(Point.Empty)
                txtNombreTrab.Select()
                Exit Sub
            End If

            If Not txtAppatTrab.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese los apellidos del trabajador"
                pcTrabajador.Font = New Font("Segoe UI", 8)
                pcTrabajador.Size = New Size(327, 250)
                Me.pcTrabajador.ParentControl = Me.txtProveedor
                Me.pcTrabajador.ShowPopup(Point.Empty)
                txtAppatTrab.Select()
                Exit Sub
            End If

            If Not txtApmatTrab.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese los apellidos del trabajador"
                pcTrabajador.Font = New Font("Segoe UI", 8)
                pcTrabajador.Size = New Size(327, 250)
                Me.pcTrabajador.ParentControl = Me.txtProveedor
                Me.pcTrabajador.ShowPopup(Point.Empty)
                txtApmatTrab.Select()
                Exit Sub
            End If

            If btnGrabTRab.Tag = "G" Then
                GrabarPersona()
                btnGrabTRab.Tag = "N"
            Else
                pcTrabajador.Font = New Font("Segoe UI", 8)
                pcTrabajador.Size = New Size(327, 250)
                Me.pcTrabajador.ParentControl = Me.txtProveedor
                Me.pcTrabajador.ShowPopup(Point.Empty)
            End If

        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtProveedor.Focus()
        End If
    End Sub

    Private Sub btnGRabarProv_Click(sender As Object, e As EventArgs) Handles btnGRabarProv.Click
        If Not txtDocProveedor.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese el nro de documento del proveedor"
            pcProveedor.Font = New Font("Tahoma", 8)
            pcProveedor.Size = New Size(327, 259)
            Me.pcProveedor.ParentControl = Me.txtProveedor
            Me.pcProveedor.ShowPopup(Point.Empty)
            txtDocProveedor.Select()
            Exit Sub
        End If

        If Not txtNomProv.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese el nombre del proveedor"
            pcProveedor.Font = New Font("Tahoma", 8)
            pcProveedor.Size = New Size(327, 259)
            Me.pcProveedor.ParentControl = Me.txtProveedor
            Me.pcProveedor.ShowPopup(Point.Empty)
            txtNomProv.Select()
            Exit Sub
        End If

        If rbNatural.Checked = True Then
            If Not txtApePat.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese los apellidos del proveedor"
                pcProveedor.Font = New Font("Tahoma", 8)
                pcProveedor.Size = New Size(327, 259)
                Me.pcProveedor.ParentControl = Me.txtProveedor
                Me.pcProveedor.ShowPopup(Point.Empty)
                txtApePat.Select()
                Exit Sub
            End If
        End If
        btnGRabarProv.Tag = "G"
        Me.pcProveedor.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub btnCancelarProv_Click(sender As Object, e As EventArgs) Handles btnCancelarProv.Click
        Me.pcProveedor.HidePopup(PopupCloseType.Canceled)
    End Sub

    Private Sub btnRuc_Click(sender As Object, e As EventArgs) Handles btnRuc.Click
        btnRuc.Checked = True
        If btnRuc.Checked = True Then
            btnDni.Checked = False
            btnPassport.Checked = False
            btnCarnetEx.Checked = False
        End If
    End Sub

    Private Sub btnDni_Click(sender As Object, e As EventArgs) Handles btnDni.Click
        btnDni.Checked = True
        If btnDni.Checked = True Then
            btnRuc.Checked = False
            btnPassport.Checked = False
            btnCarnetEx.Checked = False
        End If
    End Sub

    Private Sub rbNatural_CheckChanged(sender As Object, e As EventArgs) Handles rbNatural.CheckChanged
        If rbNatural.Checked = True Then
            txtNomProv.Visible = True
            txtNomProv.Clear()
            txtApePat.Visible = True
            txtApePat.Clear()
            Label31.Visible = True
            Label30.Text = "Nombres:"

            If btnRuc.Checked = True Then
                If rbNatural.Checked = True Then
                    txtDocProveedor.Text = "10"
                    txtDocProveedor.Select()
                End If
            End If
        End If
    End Sub

    Private Sub rbNatural_Click(sender As Object, e As EventArgs) Handles rbNatural.Click

    End Sub

    Private Sub btnPassport_Click(sender As Object, e As EventArgs) Handles btnPassport.Click
        btnPassport.Checked = True
        If btnPassport.Checked = True Then
            btnRuc.Checked = False
            btnDni.Checked = False
            btnCarnetEx.Checked = False
        End If
    End Sub

    Private Sub btnCarnetEx_Click(sender As Object, e As EventArgs) Handles btnCarnetEx.Click
        btnCarnetEx.Checked = True
        If btnCarnetEx.Checked = True Then
            btnRuc.Checked = False
            btnDni.Checked = False
            btnPassport.Checked = False
        End If
    End Sub

    Private Sub rbJuridico_CheckChanged(sender As Object, e As EventArgs) Handles rbJuridico.CheckChanged
        If rbJuridico.Checked = True Then
            txtNomProv.Visible = True
            txtNomProv.Clear()
            txtApePat.Visible = False
            txtApePat.Clear()
            Label31.Visible = False
            Label30.Text = "Nombre o Razón Social:"

            If btnRuc.Checked = True Then
                If rbJuridico.Checked = True Then
                    txtDocProveedor.Text = "20"
                    txtDocProveedor.Select()
                End If
            End If
        End If
    End Sub

    Private Sub pcProveedor_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles pcProveedor.BeforePopup
        Me.pcProveedor.BackColor = Color.White
    End Sub

    Private Sub pcProveedor_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcProveedor.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If Not txtDocProveedor.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese el nro de documento del proveedor"
                pcProveedor.Font = New Font("Tahoma", 8)
                pcProveedor.Size = New Size(327, 259)
                Me.pcProveedor.ParentControl = Me.txtProveedor
                Me.pcProveedor.ShowPopup(Point.Empty)
                txtDocProveedor.Select()
                Exit Sub
            End If

            If Not txtNomProv.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese el nombre del proveedor"
                pcProveedor.Font = New Font("Tahoma", 8)
                pcProveedor.Size = New Size(327, 259)
                Me.pcProveedor.ParentControl = Me.txtProveedor
                Me.pcProveedor.ShowPopup(Point.Empty)
                txtNomProv.Select()
                Exit Sub
            End If

            If rbNatural.Checked = True Then
                If Not txtApePat.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Ingrese los apellidos del proveedor"
                    pcProveedor.Font = New Font("Tahoma", 8)
                    pcProveedor.Size = New Size(327, 259)
                    Me.pcProveedor.ParentControl = Me.txtProveedor
                    Me.pcProveedor.ShowPopup(Point.Empty)
                    txtApePat.Select()
                    Exit Sub
                End If
            End If
            If btnGRabarProv.Tag = "G" Then
                InsertProveedor()
                btnGRabarProv.Tag = "N"
            Else
                pcProveedor.Font = New Font("Tahoma", 8)
                pcProveedor.Size = New Size(327, 259)
                Me.pcProveedor.ParentControl = Me.txtProveedor
                Me.pcProveedor.ShowPopup(Point.Empty)
            End If

        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtProveedor.Focus()
        End If
    End Sub

    Private Sub lstPersonas_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstPersonas.MouseDoubleClick
        If lstPersonas.SelectedItems.Count > 0 Then
            Me.pcPersonas.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Me.Cursor = Cursors.WaitCursor
        If txtFiltroTrab.Text.Trim.Length > 0 Then
            ObtenerPersonaPorNombre(txtFiltroTrab.Text.Trim)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub pcPersonas_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcPersonas.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lstPersonas.SelectedItems.Count > 0 Then
                Me.txtProveedor.Tag = DirectCast(Me.lstPersonas.SelectedItem, Personal).Id
                txtProveedor.Text = lstPersonas.Text
                txtCuenta = "TR"
                txtRuc.Text = DirectCast(Me.lstPersonas.SelectedItem, Personal).Id
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtProveedor.Focus()
        End If
    End Sub

    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvProveedor.MouseDoubleClick
        If lsvProveedor.SelectedItems.Count > 0 Then
            Me.popupControlContainer1.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub ContextMenuStrip1_Click(sender As Object, e As EventArgs) Handles ContextMenuStrip1.Click

    End Sub

    Private Sub ContextMenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ContextMenuStrip1.ItemClicked
        'Me.Cursor = Cursors.WaitCursor
        'Select Case e.ClickedItem.Text
        '    Case "Ver últimas entradas"

        '        If Not IsNothing(Me.dgvNuevoDoc.CurrentRow) Then
        '            If e.ClickedItem.Text = "Ver últimas entradas" Then
        '                '   Me.dgvCompra.Table.CurrentRecord.Delete()
        '                Dim a As New frmUltimasOtrasSalidasAlmacen()
        '                'a.txtAlmacen.Text = Me.dgvMov.Table.CurrentRecord.GetValue("almacenDestino")
        '                a.ObtenerAlmacen(dgvNuevoDoc.Item(21, dgvNuevoDoc.CurrentRow.Index).Value)
        '                a.idItem = dgvNuevoDoc.Item(2, dgvNuevoDoc.CurrentRow.Index).Value
        '                a.StartPosition = FormStartPosition.CenterParent
        '                a.ShowDialog()
        '            End If
        '        End If

        '    Case "Eliminar item"
        '        If e.ClickedItem.Text = "Eliminar item" Then
        '            If MessageBoxAdv.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
        '                deletefila()
        '            End If
        '        End If
        'End Select
        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btGrabar_Click(sender As Object, e As EventArgs) Handles btGrabar.Click
        Me.Cursor = Cursors.WaitCursor


        If Not txtSerie.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese el número de serie!"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If

        If Not txtNumero.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese el número de guía de remisión!"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If

        If Not txtProveedor.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese el proveedor!"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If

        If Not txtGlosa.Text.Trim.Length > 0 Then
            lblEstado.Text = "Detalle infromación de la operaión a realizar ?"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
            Me.Cursor = Cursors.Arrow
            txtGlosa.Select()
            Exit Sub
        End If

        Try


            '***********************************************************************
            Select Case lblMovimiento.Text
                Case "TRANSFERENCIA ENTRE ALMACENES"
                    Me.lblEstado.Text = "Done!"
                    If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
                        If dgvNuevoDoc.Rows.Count > 0 Then

                            If MessageBox.Show("Desea realizar la transferencia con fecha: " & vbCrLf & _
                                                txtFechaComprobante.Value, "Verifique la fecha", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                                Grabar()
                            End If

                            '    If ListaAsientonTransito.Count > 0 Then

                            'Else
                            '    Me.lblEstado.Text = "Ingrese items a la canasta de asientos contables!"
                            '    PanelError.Visible = True
                            '    Timer1.Enabled = True
                            '    TiempoEjecutar(10)

                            'End If
                        Else
                            Me.lblEstado.Text = "Ingrese items a la canasta de compra!"
                            PanelError.Visible = True
                            Timer1.Enabled = True
                            TiempoEjecutar(10)

                        End If

                    Else
                        Dim Filas As Integer = dgvNuevoDoc.DisplayedRowCount(True)
                        If Filas > 0 Then
                            UpdateCompra()
                        Else
                            Me.lblEstado.Text = "Ingrese items a la canasta de compra!"
                            PanelError.Visible = True
                            Timer1.Enabled = True
                            TiempoEjecutar(10)

                        End If

                    End If

            End Select


        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        PanelError.Visible = False
        Timer1.Enabled = False
    End Sub

    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs) Handles ToolStripButton9.Click
        updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
        RegistrarAsientos()
    End Sub

    Private Sub ToolStripButton10_Click(sender As Object, e As EventArgs) Handles ToolStripButton10.Click
        Dim consulta = (From n In ListaAsientonTransito _
               Where n.idAsiento = lstAsiento.SelectedValue).FirstOrDefault


        If Not IsNothing(consulta) Then
            Dim listaMov = (From i In ListaMovimientos _
                           Where i.idAsiento = lstAsiento.SelectedValue).ToList

            For Each obj In listaMov
                ListaMovimientos.Remove(obj)
            Next
            ListaAsientonTransito.Remove(consulta)
            GetasientosListbox()
            lstAsiento_SelectedIndexChanged(sender, e)
        End If
    End Sub

    Private Sub lstAsiento_Click(sender As Object, e As EventArgs) Handles lstAsiento.Click

    End Sub

    Private Sub lstAsiento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstAsiento.SelectedIndexChanged
        If lstAsiento.SelectedItems.Count > 0 Then


            RegistrarMovimiento(New asiento With {.idAsiento = lstAsiento.SelectedValue})
            UbicarAsientoPorId(New asiento With {.idAsiento = lstAsiento.SelectedValue})
        End If
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        If lstAsiento.SelectedItems.Count > 0 Then
            RegsitarMovimiento(New asiento With {.idAsiento = lstAsiento.SelectedValue})
            RegistrarMovimiento(New asiento With {.idAsiento = lstAsiento.SelectedValue})
        End If
    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        If Not IsNothing(dgvCompra.Table.CurrentRecord) Then
            Dim rec As Record = dgvCompra.Table.CurrentRecord
            Dim consulta = (From n In ListaMovimientos _
                           Where n.idmovimiento = rec.GetValue("id")).First

            If Not IsNothing(consulta) Then
                ListaMovimientos.Remove(consulta)
                Me.dgvCompra.Table.CurrentRecord.Delete()
            End If
        End If
        lstAsiento_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click
        If lstAsiento.SelectedItems.Count > 0 Then
            Dim consulta = (From n In ListaMovimientos _
                           Where n.idAsiento = lstAsiento.SelectedValue).ToList

            If consulta.Count > 0 Then

                Dim f As New frmViewAsiento(consulta)
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
            End If
        End If
    End Sub

    Private Sub dgvCompra_SelectedRecordsChanged(sender As Object, e As SelectedRecordsChangedEventArgs) Handles dgvCompra.SelectedRecordsChanged
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            'Select Case ColIndex
            '    Case 4
            '        e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 6, GridSetCurrentCellOptions.SetFocus)

            '        'Case 7
            '        '    e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 10, GridSetCurrentCellOptions.SetFocus)
            'End Select

            If ColIndex = 1 Then
                updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
            End If
            If ColIndex = 3 Then
                updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
            End If
        End If
    End Sub

    Private Sub dgvCompra_SelectedRecordsChanging(sender As Object, e As SelectedRecordsChangedEventArgs) Handles dgvCompra.SelectedRecordsChanging
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then

            If ColIndex = 3 Then
                updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
            End If
        End If
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellAcceptedChanges(sender As Object, e As GridTableControlCancelEventArgs) Handles dgvCompra.TableControlCurrentCellAcceptedChanges
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then

            If ColIndex = 2 Then
                updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
            End If
            If ColIndex = 4 Then
                updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
            End If
            If ColIndex = 7 Then
                updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
            End If
            If ColIndex = 1 Then
                updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
            End If

        End If
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellChanging(sender As Object, e As GridTableControlCancelEventArgs) Handles dgvCompra.TableControlCurrentCellChanging
        Dim cc As GridCurrentCell = Me.dgvCompra.TableControl.CurrentCell

        'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex

        If cc.ColIndex = 1 Then
            cc.ConfirmChanges()
            ' Me.dgvCompra.TableModel(cc.RowIndex, cc.ColIndex + 1).CellValue = "Hai"
            '  updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
            Dim str = Me.dgvCompra.TableModel(cc.RowIndex, 1).CellValue
            If str = "H" Then
                Me.dgvCompra.TableModel(cc.RowIndex, 1).CellValue = "D"
                updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
            Else
                Me.dgvCompra.TableModel(cc.RowIndex, 1).CellValue = "H"
                updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
            End If
        End If
        If cc.ColIndex = 3 Then

            updateMovimiento(Me.dgvCompra.Table.CurrentRecord)

        End If
        If cc.ColIndex = 2 Then

            updateMovimiento(Me.dgvCompra.Table.CurrentRecord)

        End If

        'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        'If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then

        '    If ColIndex = 1 Then
        '        updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
        '    End If
        '    If ColIndex = 3 Then
        '        updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
        '    End If
        'End If
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvCompra.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            'Select Case ColIndex
            '    Case 4
            '        e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 6, GridSetCurrentCellOptions.SetFocus)

            '        'Case 7
            '        '    e.TableControl.CurrentCell.MoveTo(e.TableControl.CurrentCell.RowIndex, 10, GridSetCurrentCellOptions.SetFocus)
            'End Select

            If ColIndex = 1 Then
                updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
            End If
            If ColIndex = 3 Then
                updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
            End If
            If ColIndex = 2 Then

                Dim cuentaSA As New cuentaplanContableEmpresaSA

                Me.dgvCompra.Table.CurrentRecord.SetValue("Modulo", cuentaSA.ObtenerCuentaPorID(Gempresas.IdEmpresaRuc, Me.dgvCompra.Table.CurrentRecord.GetValue("cuenta")).descripcion)

                'Me.dgvCompra.Table.CurrentRecord.SetValue("Modulo", Me.dgvCompra.Table.CurrentRecord.GetValue("cuenta"))
                updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
            End If
            If ColIndex = 4 Then
                updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
            End If
            If ColIndex = 7 Then

                Dim colMN As Decimal = Me.dgvCompra.Table.CurrentRecord.GetValue("importeMN")
                Dim cant As Decimal = Me.dgvCompra.Table.CurrentRecord.GetValue("cant")
                Dim colPUMN As Decimal = Math.Round(colMN / cant, 2).ToString("N2")

                Dim colPUME As Decimal = Math.Round(colMN / txtTipoCambio.Value, 2).ToString("N2")
                Dim colME As Decimal = Math.Round(colPUME / cant, 2).ToString("N2")

                Me.dgvCompra.Table.CurrentRecord.SetValue("importeME", colME)
                Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPUME)
                Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPUMN)


                updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
            End If
            'If ColIndex = 3 Then
            '    Dim importeDebeME As Decimal = 0

            '    If CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("importeMN")) > 0 Then
            '        Me.dgvCompra.Table.CurrentRecord.SetValue("HaberMN", 0)
            '        Me.dgvCompra.Table.CurrentRecord.SetValue("HaberME", 0)
            '        importeDebeME = Math.Round(CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("importeMN")) / txtTipoCambio.Value, 2)
            '        Me.dgvCompra.Table.CurrentRecord.SetValue("importeME", importeDebeME)
            '        Me.dgvCompra.Table.CurrentRecord.SetValue("tipoAsiento", "DEBE")
            '    End If

            'End If
            'If ColIndex = 4 Then
            '    Dim importeHaberME As Decimal = 0

            '    Me.dgvCompra.Table.CurrentRecord.SetValue("importeME", 0)
            '    Me.dgvCompra.Table.CurrentRecord.SetValue("importeMN", 0)
            '    importeHaberME = Math.Round(CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("HaberMN")) / txtTipoCambio.Value, 2)
            '    Me.dgvCompra.Table.CurrentRecord.SetValue("HaberME", importeHaberME)
            '    Me.dgvCompra.Table.CurrentRecord.SetValue("tipoAsiento", "HABER")

            'End If
        End If
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellKeyDown(sender As Object, e As GridTableControlKeyEventArgs) Handles dgvCompra.TableControlCurrentCellKeyDown
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then

            If ColIndex = 1 Then
                updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
            End If
            If ColIndex = 3 Then
                updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
            End If
            If ColIndex = 6 Then
                updateMovimiento(Me.dgvCompra.Table.CurrentRecord)
            End If
        End If
    End Sub

    Private Sub txtSerie_Click(sender As Object, e As EventArgs) Handles txtSerie.Click

    End Sub

    Private Sub txtProveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProveedor.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Me.popupControlContainer1.ParentControl = Me.txtProveedor
            Me.popupControlContainer1.ShowPopup(Point.Empty)
            If chProv.Checked = True Then
                CargarEntidadesXtipo(TIPO_ENTIDAD.PROVEEDOR, txtProveedor.Text.Trim)
            ElseIf chTrab.Checked = True Then
                CargarTrabajadoresXnivel(TIPO_ENTIDAD.PERSONA_GENERAL, txtProveedor.Text.Trim)

            ElseIf chCli.Checked = True Then
                CargarEntidadesXtipo(TIPO_ENTIDAD.CLIENTE, txtProveedor.Text.Trim)
            End If
        End If
    End Sub

    Public Property txtCuenta As String

    Private Sub popupControlContainer1_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles popupControlContainer1.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvProveedor.SelectedItems.Count > 0 Then
                Me.txtProveedor.Text = lsvProveedor.SelectedItems(0).SubItems(1).Text
                txtProveedor.Tag = lsvProveedor.SelectedItems(0).SubItems(0).Text
                txtRuc.Text = lsvProveedor.SelectedItems(0).SubItems(3).Text
                txtCuenta = lsvProveedor.SelectedItems(0).SubItems(2).Text
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtProveedor.Focus()
        End If
    End Sub

    Private Sub chProv_Click(sender As Object, e As EventArgs) Handles chProv.Click
        chProv.Checked = True
        chTrab.Checked = False
        chCli.Checked = False
        txtProveedor.Clear()
        txtRuc.Clear()
    End Sub

    Private Sub chTrab_Click(sender As Object, e As EventArgs) Handles chTrab.Click
        chProv.Checked = False
        chTrab.Checked = True
        chCli.Checked = False
        txtProveedor.Clear()
        txtRuc.Clear()
    End Sub

    Private Sub txtRuc_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRuc.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If chProv.Checked = True Then
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
                If txtRuc.Text.Trim.Length > 0 Then
                    UbicarEntidadPorRuc(txtRuc.Text.Trim)
                End If
            End If
        ElseIf chTrab.Checked = True Then
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
                If txtRuc.Text.Trim.Length > 0 Then
                    UbicarTrabPorDNI(txtRuc.Text.Trim)
                End If
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        If chProv.Checked = True Then
            Dim f As New frmCrearENtidades
            f.CaptionLabels(0).Text = "Nuevo proveedor"
            f.strTipo = TIPO_ENTIDAD.PROVEEDOR
            f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
        End If

        If chCli.Checked = True Then
            Dim f As New frmCrearENtidades
            f.CaptionLabels(0).Text = "Nuevo Cliente"
            f.strTipo = TIPO_ENTIDAD.CLIENTE
            f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
        End If

        If chTrab.Checked = True Then
            With FrmNuevaPersona
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
        End If
    End Sub

    Sub updateGlosaAsiento(asiento As asiento)
        '    Dim cuentaSA As New cuentaplanContableEmpresaSA

        Try
            Dim consulta = (From n In ListaAsientonTransito _
                       Where n.idAsiento = asiento.idAsiento).FirstOrDefault

            If Not IsNothing(consulta) Then
                consulta.glosa = txtGlosaAsiento.Text.Trim
            End If

            '      RegistrarMovimiento(New asiento With {.idAsiento = lstAsiento.SelectedValue})
        Catch ex As Exception
            MessageBoxAdv.Show(ex.Message)
        End Try
    End Sub


    Private Sub ButtonAdv10_Click(sender As Object, e As EventArgs) Handles ButtonAdv10.Click
        If lstAsiento.SelectedItems.Count > 0 Then
            If txtGlosaAsiento.Text.Trim.Length > 0 Then
                updateGlosaAsiento(New asiento With {.idAsiento = lstAsiento.SelectedValue})
                lstAsiento_SelectedIndexChanged(sender, e)
            End If
        Else
            lblEstado.Text = "Debe seleccionar un asiento!"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End If
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        'If dgvNuevoDoc.Rows.Count > 0 Then

        '    If Not IsNothing(dgvNuevoDoc.CurrentRow) Then



        '        If dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value = Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT Then
        '            deletefila()
        '        ElseIf dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value = Helios.Cont.Business.Entity.BaseBE.EntityAction.UPDATE Then
        '            '   DeleteFilaDetalle(dgvNuevoDoc.Item(0, dgvNuevoDoc.CurrentRow.Index).Value)
        '            dgvNuevoDoc.Item(12, dgvNuevoDoc.CurrentRow.Index).Value = Helios.Cont.Business.Entity.BaseBE.EntityAction.DELETE
        '            Dim pos As Integer = Me.dgvNuevoDoc.CurrentRow.Index
        '            cantidaExistente.RemoveAt(pos)
        '            dgvNuevoDoc.CurrentCell = Nothing
        '            Me.dgvNuevoDoc.Rows(pos).Visible = False

        '            '     deletefila()

        '        End If
        '        '      lblTotalItems.Text = dgvNuevoDoc.DisplayedRowCount(True) & " Filas"
        '        If dgvNuevoDoc.Rows.Count > 0 Then
        '            CellEndEditRefresh()
        '        End If
        '    End If
        'End If
    End Sub

    Private Sub chCli_Click(sender As Object, e As EventArgs) Handles chCli.Click
        chProv.Checked = False
        chTrab.Checked = False
        chCli.Checked = True
        txtProveedor.Clear()
        txtRuc.Clear()
    End Sub

    Private Sub CboClasificacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboClasificacion.SelectedIndexChanged
        Productoshijos()
    End Sub

    Private Sub cboProductos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboProductos.SelectedIndexChanged
        Dim codAlmacen = cboAlmacen.SelectedValue
        If IsNumeric(codAlmacen) Then
            ListaMercaderiasXIdHijo(codAlmacen, cboTipoExistencia.SelectedValue, cboProductos.SelectedValue)
        End If
    End Sub

    Private Sub cboalmacenDestino_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboalmacenDestino.SelectedIndexChanged
        If cboalmacenDestino.SelectedIndex > -1 Then
            dockingManager1.DockControlInAutoHideMode(Panel2, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 397)
        End If
    End Sub

    Private Sub cboAlmacen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAlmacen.SelectedIndexChanged
        dgvNuevoDoc.TableDescriptor.Relations.Clear()
        lsvExistencias.Items.Clear()

        Dim almacenSA As New almacenSA
        Dim codAlmacen As Integer = cboAlmacen.SelectedValue

        If Not IsNothing(cboAlmacen.SelectedValue) Then
            If IsNumeric(codAlmacen) Then

                Dim con = (From n In almacenDestino _
                          Where n.idAlmacen <> codAlmacen).ToList

                cboalmacenDestino.ValueMember = "idAlmacen"
                cboalmacenDestino.DisplayMember = "descripcionAlmacen"
                cboalmacenDestino.DataSource = con
                cboalmacenDestino.SelectedIndex = -1
            End If
        End If
    End Sub
End Class