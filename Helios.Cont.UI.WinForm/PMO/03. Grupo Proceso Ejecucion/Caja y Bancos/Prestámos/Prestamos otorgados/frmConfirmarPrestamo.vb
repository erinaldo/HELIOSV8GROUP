
Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid

Public Class frmConfirmarPrestamo
    Inherits frmMaster
    Public Property ListaAsientos As New List(Of asiento)
    'Public Property TipoPrestamoAprobado() As String

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        GConfiguracion = New GConfiguracionModulo
        QGlobalColorSchemeManager1.Global.CurrentTheme = Qios.DevSuite.Components.QColorScheme.LunaBlueThemeName
        lblPerido.Text = PeriodoGeneral

        'GridCFG(dgvPrestamos)
        'GetTableGrid()

        GridCFG(dgvPrestamoRO)
        GetTableGridPrestamo()

        configuracionModuloV2(Gempresas.IdEmpresaRuc, "PTO", Me.Text, GEstableciento.IdEstablecimiento)
        ConfiguracionInicio()


        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub


#Region "metodos"


    Private Sub ConfirmarPrestamo(idDocumento As Integer)
        Dim prestamoSA As New prestamosSA
        Dim objPrestamoEO As New prestamos
        Try

            prestamoSA.UpdateConfirmarPrestamo(idDocumento)
            Dispose()

        Catch ex As Exception
            MsgBox("No se pudo guardar los datos." & vbCrLf & ex.Message)
        End Try
    End Sub


    Sub GetTableGridPrestamo()
        Dim dt As New DataTable()
        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("idCuota", GetType(Integer))
        dt.Columns.Add("secuencia", GetType(Integer))
        dt.Columns.Add("cuota", GetType(Integer))
        dt.Columns.Add("descripcion", GetType(String))
        dt.Columns.Add("montomn", GetType(Decimal))
        dt.Columns.Add("montome", GetType(Decimal))
        dt.Columns.Add("FechaVct", GetType(Date))
        dt.Columns.Add("FechaPlazo", GetType(Date))


        dgvPrestamoRO.DataSource = dt
        dgvPrestamoRO.ShowGroupDropArea = False
        dgvPrestamoRO.TableDescriptor.GroupedColumns.Clear()
        dgvPrestamoRO.TableDescriptor.GroupedColumns.Add("cuota")
    End Sub


    Sub GridCFG(grid As GridGroupingControl)
        grid.TableOptions.ShowRowHeader = False
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


    Sub ConfiguracionInicio()
        'TotalesXcanbeceras = New TotalesXcanbecera()
        'Dim almacenSA As New almacenSA
        'idAlmacenVirtual = almacenSA.GetUbicar_almacenVirtual(GEstableciento.IdEstablecimiento).idAlmacen
        ''configurando docking manager
        'dockingManager1.DockControlInAutoHideMode(Panel4, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 420)
        'dockingManager1.DockControlInAutoHideMode(Panel5, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 420)
        'dockingManager1.DockControlInAutoHideMode(Panel4, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 420)
        'Me.dockingClientPanel1.AutoScroll = True
        'Me.dockingClientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        'dockingManager1.SetDockLabel(Panel4, "Datos Generales")
        'dockingManager1.SetDockLabel(Panel5, "Servicios")
        'dockingManager1.SetDockLabel(Panel4, "Activo Inmovilizado")
        'dockingManager1.CloseEnabled = False

        'If Not IsNothing(GFichaUsuarios) Then
        'ToolStripButton1.Image = ImageListAdv1.Images(1)
        'dgvCompra.TableDescriptor.Columns("chPago").Width = 50
        'Else
        'dgvCompra.TableDescriptor.Columns("chPago").Width = 0
        'ToolStripButton1.Image = ImageListAdv1.Images(0)
        'GFichaUsuarios = Nothing
        'End If
        'dgvCompra.TableDescriptor.Columns("pume").Width = 0
        'dgvCompra.TableDescriptor.Columns("vcme").Width = 0
        'dgvCompra.TableDescriptor.Columns("igvme").Width = 0
        'dgvCompra.TableDescriptor.Columns("totalme").Width = 0
        'dgvCompra.TableDescriptor.Columns("percepcionME").Width = 0
        'cboMoneda.SelectedValue = 1


        ''confgiurando variables generales
        'txtGlosa.Text = "Por la compra según " & cboTipoDoc.Text
        'txtIva.DoubleValue = TmpIGV / 100
        'lblPerido.Text = PeriodoGeneral
        'txtTipoCambio.DecimalValue = TmpTipoCambio
        'txtFecha.Value = New Date(CInt(AnioGeneral), CInt(MesGeneral), DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        'txtFecVence.Value = New Date(CInt(AnioGeneral), CInt(MesGeneral), DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        'txtFecha.Select()
    End Sub
#End Region
    Public Class Categoria

        Private _name As String
        Private _id As Integer
        Private _cuenta As String

        Public Sub New(ByVal name As String, ByVal id As Integer, ByVal cuenta As String)
            _name = name
            _id = id
            _cuenta = cuenta
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

        Public Property Cuenta() As String
            Get
                Return _cuenta
            End Get
            Set(ByVal value As String)
                _cuenta = value
            End Set
        End Property

    End Class


#Region "CONFIG MODULO"

    'Public Sub configuracionModulo(strIDEmpresa As String, strIdModulo As String, strNomModulo As String, intIdEstablecimiento As Integer)
    '    Dim moduloConfiguracionSA As New ModuloConfiguracionSA
    '    Dim moduloConfiguracion As New moduloConfiguracion
    '    Dim numeracionSA As New NumeracionBoletaSA
    '    Dim TablaSA As New tablaDetalleSA
    '    Dim almacenSA As New almacenSA
    '    Dim cajaSA As New EstadosFinancierosSA

    '    moduloConfiguracion = moduloConfiguracionSA.UbicarConfiguracionPorEmpresaModulo(strIdModulo, strIDEmpresa, intIdEstablecimiento)
    '    If Not IsNothing(moduloConfiguracion) Then
    '        With moduloConfiguracion
    '            GConfiguracion = New GConfiguracionModulo
    '            GConfiguracion.IdModulo = .idModulo
    '            GConfiguracion.NomModulo = strNomModulo
    '            GConfiguracion.TipoConfiguracion = .tipoConfiguracion
    '            Select Case .tipoConfiguracion
    '                Case "P"
    '                    With numeracionSA.GetUbicar_numeracionBoletasPorID(.configComprobante)
    '                        GConfiguracion.ConfigComprobante = .IdEnumeracion
    '                        GConfiguracion.TipoComprobante = .tipo
    '                        GConfiguracion.NombreComprobante = TablaSA.GetUbicarTablaID(10, .tipo).descripcion
    '                        GConfiguracion.Serie = .serie
    '                        GConfiguracion.ValorActual = .valorInicial
    '                        'txtSerieComp.Visible = True
    '                        'txtSerieComp.Text = .serie
    '                        'txtNumeroComp.Visible = False
    '                        'txtIdComprobante.Text = GConfiguracion.TipoComprobante
    '                        'txtComprobante.Text = GConfiguracion.NombreComprobante
    '                        'LinkTipoDoc.Enabled = False
    '                        'txtSerieComp.Enabled = False
    '                    End With
    '                Case "M"
    '                    'txtSerieComp.Visible = True
    '                    'txtNumeroComp.Visible = True
    '                    'LinkTipoDoc.Enabled = True
    '                    'txtSerieComp.Enabled = True
    '            End Select
    '            If Not IsNothing(.configAlmacen) Then
    '                Dim estableSA As New establecimientoSA
    '                With almacenSA.GetUbicar_almacenPorID(.configAlmacen)
    '                    GConfiguracion.IdAlmacen = .idAlmacen
    '                    GConfiguracion.NombreAlmacen = .descripcionAlmacen

    '                    'txtAlmacen.Text = GConfiguracion.NombreAlmacen
    '                    'txtIdAlmacen.Text = GConfiguracion.IdAlmacen
    '                    With estableSA.UbicaEstablecimientoPorID(.idEstablecimiento)
    '                        'txtIdEstableAlmacen.Text = .idCentroCosto
    '                        'txtEstableAlmacen.Text = .nombre
    '                    End With
    '                End With
    '            End If
    '            If Not IsNothing(.ConfigentidadFinanciera) Then
    '                With cajaSA.GetUbicar_estadosFinancierosPorID(.ConfigentidadFinanciera)
    '                    GConfiguracion.IDCaja = .idestado
    '                    GConfiguracion.NomCaja = .descripcion
    '                End With
    '            End If

    '        End With
    '    Else
    '        lblEstado.Text = "Este módulo no contiene una configuración disponible, intentelo más tarde.!"
    '        'Timer1.Enabled = True
    '        'TabCompra.Enabled = False
    '        'TiempoEjecutar(5)
    '    End If
    'End Sub

    Public Sub configuracionModuloV2(strIDEmpresa As String, strIdModulo As String, strNomModulo As String, intIdEstablecimiento As Integer)
        Try

            Dim moduloConfiguracionSA As New ModuloConfiguracionSA
            Dim moduloConfiguracion As New moduloConfiguracion
            Dim numeracionSA As New NumeracionBoletaSA
            Dim TablaSA As New tablaDetalleSA
            Dim almacenSA As New almacenSA
            Dim cajaSA As New EstadosFinancierosSA

            Dim RecuperacionNumeracion = numeracionSA.GetUbicar_numeracionBoletasXUnidadNegocio(New numeracionBoletas With {.empresa = strIDEmpresa, .establecimiento = intIdEstablecimiento, .codigoNumeracion = strIdModulo, .estado = "A"})

            If (Not IsNothing(RecuperacionNumeracion)) Then
                GConfiguracion = New GConfiguracionModulo
                GConfiguracion.ConfigComprobante = CInt(RecuperacionNumeracion.IdEnumeracion)
                GConfiguracion.TipoComprobante = RecuperacionNumeracion.tipo
                GConfiguracion.NombreComprobante = TablaSA.GetUbicarTablaID(10, RecuperacionNumeracion.tipo).descripcion
                GConfiguracion.Serie = RecuperacionNumeracion.serie
                GConfiguracion.ValorActual = RecuperacionNumeracion.valorInicial
            Else
                Throw New Exception("Verificar configuración")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
#End Region


#Region "DATETIME PICKER COLUMN"
    Public Class CalendarColumn
        Inherits DataGridViewColumn

        Public Sub New()
            MyBase.New(New CalendarCell())
        End Sub

        Public Overrides Property CellTemplate() As DataGridViewCell
            Get
                Return MyBase.CellTemplate
            End Get
            Set(ByVal value As DataGridViewCell)

                ' Ensure that the cell used for the template is a CalendarCell. 
                If (value IsNot Nothing) AndAlso _
                    Not value.GetType().IsAssignableFrom(GetType(CalendarCell)) _
                    Then
                    Throw New InvalidCastException("Must be a CalendarCell")
                End If
                MyBase.CellTemplate = value

            End Set
        End Property

    End Class

    Public Class CalendarCell
        Inherits DataGridViewTextBoxCell

        Public Sub New()
            ' Use the short date format. 
            Me.Style.Format = "d"
        End Sub

        Public Overrides Sub InitializeEditingControl(ByVal rowIndex As Integer, _
            ByVal initialFormattedValue As Object, _
            ByVal dataGridViewCellStyle As DataGridViewCellStyle)

            ' Set the value of the editing control to the current cell value. 
            MyBase.InitializeEditingControl(rowIndex, initialFormattedValue, _
                dataGridViewCellStyle)

            Dim ctl As CalendarEditingControl = _
                CType(DataGridView.EditingControl, CalendarEditingControl)

            ' Use the default row value when Value property is null. 
            If (Me.Value Is Nothing) Then
                ctl.Value = CType(Me.DefaultNewRowValue, DateTime)
            Else
                ctl.Value = CType(Me.Value, DateTime)
            End If
        End Sub

        Public Overrides ReadOnly Property EditType() As Type
            Get
                ' Return the type of the editing control that CalendarCell uses. 
                Return GetType(CalendarEditingControl)
            End Get
        End Property

        Public Overrides ReadOnly Property ValueType() As Type
            Get
                ' Return the type of the value that CalendarCell contains. 
                Return GetType(DateTime)
            End Get
        End Property

        Public Overrides ReadOnly Property DefaultNewRowValue() As Object
            Get
                ' Use the current date and time as the default value. 
                Return DateTime.Now
            End Get
        End Property

    End Class

    Class CalendarEditingControl
        Inherits DateTimePicker
        Implements IDataGridViewEditingControl

        Private dataGridViewControl As DataGridView
        Private valueIsChanged As Boolean = False
        Private rowIndexNum As Integer

        Public Sub New()
            Me.Format = DateTimePickerFormat.Short
        End Sub

        Public Property EditingControlFormattedValue() As Object _
            Implements IDataGridViewEditingControl.EditingControlFormattedValue

            Get
                Return Me.Value.ToShortDateString()
            End Get

            Set(ByVal value As Object)
                Try
                    ' This will throw an exception of the string is  
                    ' null, empty, or not in the format of a date. 
                    Me.Value = DateTime.Parse(CStr(value))
                Catch
                    ' In the case of an exception, just use the default 
                    ' value so we're not left with a null value. 
                    Me.Value = DateTime.Now
                End Try
            End Set

        End Property

        Public Function GetEditingControlFormattedValue(ByVal context _
            As DataGridViewDataErrorContexts) As Object _
            Implements IDataGridViewEditingControl.GetEditingControlFormattedValue

            Return Me.Value.ToShortDateString()

        End Function

        Public Sub ApplyCellStyleToEditingControl(ByVal dataGridViewCellStyle As  _
            DataGridViewCellStyle) _
            Implements IDataGridViewEditingControl.ApplyCellStyleToEditingControl

            Me.Font = dataGridViewCellStyle.Font
            Me.CalendarForeColor = dataGridViewCellStyle.ForeColor
            Me.CalendarMonthBackground = dataGridViewCellStyle.BackColor

        End Sub

        Public Property EditingControlRowIndex() As Integer _
            Implements IDataGridViewEditingControl.EditingControlRowIndex

            Get
                Return rowIndexNum
            End Get
            Set(ByVal value As Integer)
                rowIndexNum = value
            End Set

        End Property

        Public Function EditingControlWantsInputKey(ByVal key As Keys, _
            ByVal dataGridViewWantsInputKey As Boolean) As Boolean _
            Implements IDataGridViewEditingControl.EditingControlWantsInputKey

            ' Let the DateTimePicker handle the keys listed. 
            Select Case key And Keys.KeyCode
                Case Keys.Left, Keys.Up, Keys.Down, Keys.Right, _
                    Keys.Home, Keys.End, Keys.PageDown, Keys.PageUp

                    Return True

                Case Else
                    Return Not dataGridViewWantsInputKey
            End Select

        End Function

        Public Sub PrepareEditingControlForEdit(ByVal selectAll As Boolean) _
            Implements IDataGridViewEditingControl.PrepareEditingControlForEdit

            ' No preparation needs to be done. 

        End Sub

        Public ReadOnly Property RepositionEditingControlOnValueChange() _
            As Boolean Implements _
            IDataGridViewEditingControl.RepositionEditingControlOnValueChange

            Get
                Return False
            End Get

        End Property

        Public Property EditingControlDataGridView() As DataGridView _
            Implements IDataGridViewEditingControl.EditingControlDataGridView

            Get
                Return dataGridViewControl
            End Get
            Set(ByVal value As DataGridView)
                dataGridViewControl = value
            End Set

        End Property

        Public Property EditingControlValueChanged() As Boolean _
            Implements IDataGridViewEditingControl.EditingControlValueChanged

            Get
                Return valueIsChanged
            End Get
            Set(ByVal value As Boolean)
                valueIsChanged = value
            End Set

        End Property

        Public ReadOnly Property EditingControlCursor() As Cursor _
            Implements IDataGridViewEditingControl.EditingPanelCursor

            Get
                Return MyBase.Cursor
            End Get

        End Property

        Protected Overrides Sub OnValueChanged(ByVal eventargs As EventArgs)

            ' Notify the DataGridView that the contents of the cell have changed.
            valueIsChanged = True
            Me.EditingControlDataGridView.NotifyCurrentCellDirty(True)
            MyBase.OnValueChanged(eventargs)

        End Sub

    End Class
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

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
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
            ToolStrip1.Visible = False
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
            Timer2.Enabled = True
        Else
            Timer2.Enabled = False
        End If

    End Sub
    Public Function TiempoEjecutar(ByVal Tiempo As Integer)
        TiempoEjecutar = ""
        TiempoRestante = Tiempo  ' 1 minutos=60 segundos 
        Timer2.Interval = 400

        Call TimerOn(1000) ' Hechanos a andar el timer
    End Function
#End Region


#Region "Métodos"

    Public Sub UbicarPrestamo(intCodigo As Integer)
        Dim objLista As New DocumentoCajaDetalleSA
        Dim listadetalle As New List(Of documentoPrestamoDetalle)
        Dim entidadSA As New entidadSA
        Dim personaSA As New PersonaSA

        lblIdDocumento.Text = intCodigo
        listadetalle = objLista.PrestamoListaDetalle(intCodigo)
        txtTipoBeneficiario.Text = listadetalle(0).tipo
        If listadetalle(0).moneda = "1" Then
            txtMoneda.Text = "NACIONAL"
        ElseIf listadetalle(0).moneda = "2" Then
            txtMoneda.Text = "EXTRANJERA"
        End If
        Dim cuota As Decimal = listadetalle(0).numcuotas
        txtCuotas.Value = CDec(cuota)
        nudImporteMN.Value = listadetalle(0).montoprestamo
        nudImporteME.Value = listadetalle(0).montoprestamome
        DateTimePickerAdv2.Value = listadetalle(0).fechainicio
        txtModoPago.Text = listadetalle(0).modopago

        Select Case listadetalle(0).tipoBeneficiario
            Case TIPO_ENTIDAD.PROVEEDOR
                With entidadSA.UbicarEntidadPorID(listadetalle(0).idBeneficiario).First
                    txtBeneficiario.Text = .nombreCompleto
                End With
            Case TIPO_ENTIDAD.CLIENTE
                With entidadSA.UbicarEntidadPorID(listadetalle(0).idBeneficiario).First
                    txtBeneficiario.Text = .nombreCompleto
                End With
            Case "TR"
                With personaSA.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, listadetalle(0).idBeneficiario, "TR")
                    txtBeneficiario.Text = .nombreCompleto
                End With
            Case "OT"
                With personaSA.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, listadetalle(0).idBeneficiario, "OT")
                    txtBeneficiario.Text = .nombreCompleto
                End With
        End Select


        For Each i In listadetalle

            Me.dgvPrestamoRO.Table.AddNewRecord.SetCurrent()
            Me.dgvPrestamoRO.Table.AddNewRecord.BeginEdit()
            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("idDocumento", i.idDocumento)
            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("idCuota", i.idCuota)
            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("secuencia", i.secuencia)
            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("cuota", i.cuota)
            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("descripcion", i.descripcion)
            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montomn", i.montoSoles)
            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("montome", i.montoUsd)
            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaVct", i.fechaVencimiento)
            Me.dgvPrestamoRO.Table.CurrentRecord.SetValue("FechaPlazo", i.fechaPlazo)

            Me.dgvPrestamoRO.Table.AddNewRecord.EndEdit()

        Next

    End Sub


#End Region


    Private Sub frmConfirmarPrestamo_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmConfirmarPrestamo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        Timer1.Interval = 100 'velocidad del parpadeo
        Timer1.Start()


    End Sub

    Private Sub PegarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles PegarToolStripButton.Click
        Dispose()
    End Sub


    Private Sub GuardarToolStripButton_Click(sender As Object, e As EventArgs) Handles GuardarToolStripButton.Click
        Me.Cursor = Cursors.WaitCursor
        
        Me.Cursor = Cursors.Arrow
    End Sub


    Private Sub btGrabar_Click(sender As Object, e As EventArgs) Handles btGrabar.Click
        Me.Cursor = Cursors.WaitCursor
        ConfirmarPrestamo(lblIdDocumento.Text)
        Me.Cursor = Cursors.Arrow
    End Sub

    
End Class