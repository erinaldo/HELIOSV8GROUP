Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports DPFP
Imports DPFP.Capture
Imports DPFP.Verification
Imports Helios.Cont.Business.Entity
Imports Syncfusion.Drawing
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Module Constantes
    'Public Enum ApisReniec
    '    ''' <summary>
    '    ''' 'https://api.reniec.cloud/dni/
    '    ''' </summary>
    '    ApiReniecCloud = 1 'https://api.reniec.cloud/dni/

    'End Enum
    Public Enum ApisReniec
        ''' <summary>
        ''' 'https://api.reniec.cloud/dni/
        ''' </summary>
        ApiReniecCloud = 1 'https://api.reniec.cloud/dni/

        ''' <summary>
        ''' 'http://apis.grupotecom.com/api/ConsultaDni?dni=43137038
        ''' </summary>
        ApiGrupoTeComCom = 2 'http://apis.grupotecom.com/api/ConsultaDni?dni=43137038

        ''' <summary>
        ''' 'http://consultas.dsdinformaticos.com/reniec.php?dni=44924569
        ''' </summary>
        ApiConsultasDsdInformaticos = 3 'http://consultas.dsdinformaticos.com/reniec.php?dni=44924569
    End Enum

    Public Enum ApisRuc
        ''' <summary>
        ''' 'https://api.reniec.cloud/dni/
        ''' </summary>
        ApiRucCloudPeru = 1

        ''' <summary>
        ''' 'http://apis.grupotecom.com/api/ConsultaDni?dni=43137038
        ''' </summary>
        ApiRucSunatCloud = 2

        ''' <summary>
        ''' 'http://consultas.dsdinformaticos.com/reniec.php?dni=44924569
        ''' </summary>
        ApiRucaqfac = 3
    End Enum


    Public Property ApiReniecOption As Integer

    Public Property ApiRucOption As Integer
    Public Property TmpAction As String

    Public Property VarClienteGeneral As entidad
    Public Property ListaCuentasFinancierasConfiguradas As List(Of estadosFinancierosConfiguracionPagos)
    Public Property ListaCuentasFinancierasUsuario As List(Of estadosFinancierosConfiguracionPagos)
    Public Property ListaCajasActivas As List(Of cajaUsuario)

    Public Property ListaUnidadOrganica As List(Of centrocosto)

    Public Property GconfigCaja As String

    Public Gempresas As GEmpresa
    Public GEstableciento As GEstablecimiento
    Public GImpresion As GImpresiones
    Public GPerfilXUnidad As GPerfilXUnidadOrg

    Public GProyectos As GProyecto
    Public GModoTRabajos As GModoTrabajo
    Public GModoProyecto As String
    Public GFichaUsuarios As GFichaUsuario
    Public NumDigitos As Short = 2
    Public Property ModuloAppx() As ModuloSistema
    Public Property PeriodoGeneral() As String
    Public Property AnioGeneral() As String
    Public Property MesGeneral() As String

    Public Property tmpConfigInicio As Cont.Business.Entity.configuracionInicio
    Public Property ClipBoardDocumento() As Cont.Business.Entity.documento
    Public Property ListConfigurationPays As List(Of estadosFinancierosConfiguracionPagos)

    Public Property SelecIDEstable() As Integer?
    Public Property SelecNombreEstable() As String
    Public Property SelectIdAlmacen() As Integer?
    Public Property SelectNombreAlmacen() As String
    Public Property IdAlmacenBack() As Integer?
    Public Property UserAccesoPermitido As Boolean
    Public Property TmpSelModulo As Integer?
    Public Property TmpTipoCambio As Decimal
    Public Property TmpTipoCambioTransaccionCompra As Decimal
    Public Property TmpTipoCambioTransaccionVenta As Decimal
    Public Property TmpPorcGanacia As Decimal
    Public Property TmpNombreAlmacen As String
    Public Property TmpIdAlmacen As Integer
    Public Property TmpTipoIVA As String
    Public Property TmpRetencion4 As Decimal
    Public Property TmpIGV As Decimal

    Public Property TmpProyecto As Boolean
    Public Property TmpOrdenProduccion As Boolean
    Public Property TmpActivo As Boolean
    Public Property TmpGastoAdmin As Boolean
    Public Property TmpGastoVentas As Boolean
    Public Property TmpGastoFinanciero As Boolean

    Public Property TmpProduccionPorLotes() As Boolean
    Public Property TmpCronogramaPagos() As Boolean

    Public Property MontoMaximoCliente As Decimal?
    Public Property DiaLaboral() As DateTime
    Public Property TmpIdEntidadFinanciera() As Integer
    Public Property TmpNombreEntidadFinanciera() As String

    Public Property ValorEntrada() As Decimal
    Public Property ValorEntradaME() As Decimal


    Public Property CierreInventarioPeriodo() As Boolean
    Public Property CierreCajaPeriodo() As Boolean
    Public Property CierreContablePeriodo() As Boolean

    Public Property CustomListaDatosGenerales As List(Of datosGenerales)

    Public captura As Capture
    Public template As DPFP.Template
    Public verificador As Verification
    Public Enroller As DPFP.Processing.Enrollment

    Public Sub InitHuella()
        Try
            captura = New Capture(DPFP.Capture.Priority.Normal)

            If captura IsNot Nothing Then
                'captura.EventHandler = Me
                verificador = New Verification
                template = New Template
                Enroller = New Processing.Enrollment
            Else
                MessageBox.Show("no se pudo instanciar la captura")
            End If

        Catch ex As Exception
            MessageBox.Show("no se pudo inicializar la captura")
        End Try

    End Sub

    Public Function LimpiarCadenaNombreFichero(cadenaTexto As String,
    sustituirPor As String) As String
        Dim i As Integer
        Dim tamanoCadena, cadenaResultado, caracteresValidos As String
        Dim caracterActual As String
        cadenaResultado = Nothing
        tamanoCadena = Len(cadenaTexto)
        If tamanoCadena > 0 Then
            caracteresValidos =
        " 0123456789.,abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ-/""ø"
            For i = 1 To tamanoCadena
                caracterActual = Mid(cadenaTexto, i, 1)
                If InStr(caracteresValidos, caracterActual) Then
                    cadenaResultado = cadenaResultado & caracterActual
                Else
                    cadenaResultado = cadenaResultado & sustituirPor
                End If
            Next
        End If

        LimpiarCadenaNombreFichero = cadenaResultado
    End Function

    Public Enum StatusAfiliacionBeneficiosCliente
        Pendiente = 0
        Aprobado = 1
        Retenido = 2
        Rechazado = 3
    End Enum

    Public Structure StatusComisionRegistro
        Const Pendiente = "PN"
        Const PagoAutorizado = "AUTH"
        Const ComisionBaja = "BJ"
    End Structure

    Public Structure StatusTipoConsulta
        Const XEmpresa = "EMPRESA"
        Const XUNIDAD_ORGANICA = "UNIDAD_ORGANICA"
    End Structure

    Public Sub OrdenamientoGrid(Grid As GridGroupingControl, ordenar As Boolean)
        For Each i In Grid.TableDescriptor.Columns
            Select Case ordenar
                Case True
                    i.AllowSort = True
                Case False
                    i.AllowSort = False
            End Select
            i.Appearance.AnyRecordFieldCell.TextColor = Color.Black
            '       i.Appearance.AnyRecordFieldCell.BackColor = Color.White
        Next
    End Sub

    Public Function validarDNIRUC(dni As String) As Boolean
        validarDNIRUC = True

        If dni.ToString.Trim.Length > 8 And dni.ToString.Trim.Length < 11 Then
            validarDNIRUC = False
        ElseIf dni.ToString.Length = 0 Then
            validarDNIRUC = False
        ElseIf dni.ToString.Length > 11 Then
            validarDNIRUC = False
        End If

        If Not IsNumeric(dni) Then
            validarDNIRUC = False
        End If



    End Function

    Public Function validarDNI(dni As String) As Boolean
        validarDNI = True
        If dni.ToString.Trim.Length > 8 Or dni.ToString.Length = 0 Then
            validarDNI = False
        End If
        If Not IsNumeric(dni) Then
            validarDNI = False
        End If
    End Function

    Public Function ValidationRUC(ruc As String) As Boolean
        '   msj = String.Empty

        If ruc.Length <> 11 Then
            '    msj = "NUMERO DE DIGITOS INVALIDO!!!."
            Return False

        End If

        Dim dig01 As Integer = Convert.ToInt32(ruc.Substring(0, 1)) * 5
        Dim dig02 As Integer = Convert.ToInt32(ruc.Substring(1, 1)) * 4
        Dim dig03 As Integer = Convert.ToInt32(ruc.Substring(2, 1)) * 3
        Dim dig04 As Integer = Convert.ToInt32(ruc.Substring(3, 1)) * 2
        Dim dig05 As Integer = Convert.ToInt32(ruc.Substring(4, 1)) * 7
        Dim dig06 As Integer = Convert.ToInt32(ruc.Substring(5, 1)) * 6
        Dim dig07 As Integer = Convert.ToInt32(ruc.Substring(6, 1)) * 5
        Dim dig08 As Integer = Convert.ToInt32(ruc.Substring(7, 1)) * 4
        Dim dig09 As Integer = Convert.ToInt32(ruc.Substring(8, 1)) * 3
        Dim dig10 As Integer = Convert.ToInt32(ruc.Substring(9, 1)) * 2
        Dim dig11 As Integer = Convert.ToInt32(ruc.Substring(10, 1))
        Dim suma As Integer = dig01 + dig02 + dig03 + dig04 + dig05 + dig06 + dig07 + dig08 + dig09 + dig10
        Dim residuo As Integer = suma Mod 11
        Dim resta As Integer = 11 - residuo
        Dim digChk As Integer = 0
        If resta = 10 Then
            digChk = 0

        ElseIf resta = 11 Then
            digChk = 1

        Else
            digChk = resta
        End If


        If dig11 = digChk Then
            '    msj = "NUMERO DE RUC VALIDO!!!."
            Return True

        Else
            '     msj = "NUMERO DE RUC INVALIDO!!!."
            Return False

        End If

        '   msj = "NUMERO DE RUC VALIDO!!!."
    End Function

    Public Structure TipoGrupoArticulo

        Const Principal = "H"
        Const CategoriaGeneral = "C"
        Const SubCategoriaGeneral = "S"
        Const Marca = "M"
        Const Presentacion = "P"

        Const Relacion = "R"
    End Structure

    Public Class BusquedaAvanzadaProductos
        Public Property tipo() As String
        Public Property codigo() As String
    End Class

    Public Class EnvioImpresionVendedorPernos
        Public Sub New()

        End Sub

        Public Property EntidadFinanciera() As Integer
        Public Property EntidadFinancieraName() As String
        Public Property CodigoVendedor() As String
        Public Property IDVendedor() As Integer
        Public Property IDCaja() As Integer
        Public Property NombreCajero() As String
        Public Property print() As Boolean
        Public Property Nombreprint() As String
        Public Property tipoFormato As String
        Public Property datosGenerales As datosGenerales
    End Class

    Public Class TotalesXcanbecera
        '   Private base_mn, base_me, igv_mn, igv_me, total_mn, total_me As Decimal?

        Public Property BaseMN() As Decimal
        Public Property BaseME() As Decimal

        Public Property BaseMN2() As Decimal
        Public Property BaseME2() As Decimal

        Public Property BaseMN3() As Decimal
        Public Property BaseME3() As Decimal

        Public Property IgvMN() As Decimal
        Public Property IgvME() As Decimal
        Public Property TotalMN() As Decimal
        Public Property TotalME() As Decimal

        Public Property base1() As Decimal
        Public Property base1me() As Decimal
        Public Property base2() As Decimal
        Public Property base2me() As Decimal
        Public Property MontoIgv1() As Decimal
        Public Property MontoIgv1me() As Decimal
        Public Property MontoIgv2() As Decimal
        Public Property MontoIgv2me() As Decimal

        Public Property PercepcionMN() As Decimal
        Public Property PercepcionME() As Decimal

        Public Sub New()
            BaseMN = 0
            BaseME = 0
            BaseMN2 = 0
            BaseME2 = 0
            BaseMN3 = 0
            BaseME3 = 0
            IgvMN = 0
            IgvME = 0
            TotalMN = 0
            TotalME = 0
            base1 = 0
            base1me = 0
            base2 = 0
            base2me = 0
            MontoIgv1 = 0
            MontoIgv1me = 0
            MontoIgv2 = 0
            MontoIgv2me = 0
            PercepcionMN = 0
            PercepcionME = 0
        End Sub


    End Class

    Public Structure EstadoTrasladoVenta
        ''' <summary>
        ''' Traslado Pendiente
        ''' </summary>
        Const Pedido = "TI"

        ''' <summary>
        ''' Traslado Parcial
        ''' </summary>
        Const TrasladoParcial = "TP"

        ''' <summary>
        ''' Traslado entregado
        ''' </summary>
        Const EntregaConExito = "TE"

        ''' <summary>
        ''' Productos entregados con exitos pero con observaciones
        ''' </summary>
        Const EntregaConObservaciones = "EO"

        Const Otros = "OT"

        ''' <summary>
        ''' Rechazados por diversos motivos
        ''' </summary>
        Const Rechazado = "RC"
    End Structure

    Public Structure EstadoTransferenciaAlmacen
        ''' <summary>
        ''' Pedido de transferencia generada
        ''' </summary>
        Const Pedido = "EM"

        ''' <summary>
        ''' Guia de remision generada para entregar a almacen de destino
        ''' </summary>
        Const GuiaGenerada = "GN"

        ''' <summary>
        ''' Guia de remision entregada con exito al destino sin problemas
        ''' </summary>
        Const EntregaConExito = "EN"

        ''' <summary>
        ''' Productos entregados con exitos pero con observaciones
        ''' </summary>
        Const EntregaConObservaciones = "EO"

        Const Otros = "OT"

        ''' <summary>
        ''' Rechazados por diversos motivos
        ''' </summary>
        Const Rechazado = "RC"
    End Structure

    Public Function CalculoBaseImponible(ByVal ImporteTotal As Decimal, ByVal porcentajeIva As Decimal) As Decimal?
        Return ImporteTotal / porcentajeIva
    End Function

    Public Function CalculoPrecioUnitario(ByVal ImporteTotal As Decimal, ByVal cantidad As Decimal) As Decimal?
        If cantidad = 0 Then
            Return 0
        End If
        Return ImporteTotal / cantidad
    End Function

    Public Function CalculoIva(ByVal BaseImponible As Decimal, ByVal porcentajeIva As Decimal) As Decimal?
        Return BaseImponible * porcentajeIva
    End Function

    Public Function CalculoTotal(ByVal BaseImponible As Decimal, ByVal Iva As Decimal) As Decimal?
        Return BaseImponible + Iva
    End Function

    Public Structure StatusProductosTransito
        Const Pendiente = "N"
        Const Recahazado = "R"
    End Structure

    Public Enum StatusCategoriaVenta
        Productos
        Servicios
        ProductosEnConsigna
        Bonificacion
        Promocion
    End Enum

    Public Enum StatusNotaDeVentas
        NoSustentado
        Sustentado
    End Enum

    Public Structure StatusAprobacionPagos
        Const Pendiente = "P"
        Const Aprobado = "A"
        Const Rechazado = "R"
    End Structure

    Public Enum alertType
        success
        info
        warning
        Errors
    End Enum

    Public Sub GetGlobalMappingCajaUsuario(be As cajaUsuario, idusuario As Integer, fullname As String)
        GFichaUsuarios = New GFichaUsuario
        GFichaUsuarios.IdCajaUsuario = be.idcajaUsuario
        GFichaUsuarios.IdPersona = idusuario
        GFichaUsuarios.NombrePersona = fullname
        GFichaUsuarios.ClaveUsuario = String.Empty
    End Sub


    Public Class DetalleVentageneral

        Public Sub New()
            valorVentaMN = 0
            valorVentaME = 0
            precioUnitMN = 0
            precioUnitME = 0
            IgvMN = 0
            IgvME = 0
            TotalVentaMN = 0
            TotalVentaME = 0
            CostoMN = 0
            CostoME = 0
        End Sub

        Public Property valorVentaMN As Decimal?
        Public Property valorVentaME As Decimal?
        Public Property precioUnitMN As Decimal?
        Public Property precioUnitME As Decimal?
        Public Property IgvMN As Decimal?
        Public Property IgvME As Decimal?
        Public Property TotalVentaMN As Decimal?
        Public Property TotalVentaME As Decimal?
        Public Property CostoMN As Decimal?
        Public Property CostoME As Decimal?
    End Class

    ''' <summary>
    ''' True: Estan dentro del rango ::: False: Fuera del rango
    ''' </summary>
    ''' <param name="vFechaIni"></param>
    ''' <param name="vFechaFin"></param>
    ''' <param name="vFechaSeleccionada"></param>
    ''' <returns></returns>
    Public Function IsInRange(ByVal vFechaIni As DateTime, ByVal vFechaFin As DateTime, ByVal vFechaSeleccionada As DateTime) As Boolean
        If vFechaSeleccionada.ToUniversalTime() >= vFechaIni.ToUniversalTime() AndAlso vFechaSeleccionada.ToUniversalTime() <= vFechaFin.ToUniversalTime() Then Return True
        Return False
    End Function

    Public Function GetPeriodo(dateVal As Date, conSlash As Boolean) As String

        Select Case conSlash
            Case True
                GetPeriodo = String.Format("{0:00}", dateVal.Month) & "/" & dateVal.Year
            Case Else
                GetPeriodo = String.Format("{0:00}", dateVal.Month) & dateVal.Year
        End Select

    End Function

    Public Function GetPeriodoConvertirToDate(periodo As String) As Date
        Dim nuevoPeriodo = CType("1/" & periodo, DateTime)
        Return nuevoPeriodo
    End Function

    Public Enum Gimnasio_StatusActividades
        TodosLosDias = 1
        RangoDeTiempo = 2
    End Enum

    Public Enum Gimnasio_StatusCobrosRealizados
        DineroEnEspera = 0
        DineroObservado = 1
        DineroEntregado = 2
    End Enum

    Public Enum Gimnasio_EstadoMembresiaPago
        PagoParcial = 1
        Pendiente = 0
        Completo = 2
        IngresoLibre = 3
    End Enum

    Public Enum Gimnasio_EstadoMembresia
        Activo = 1
        Baja = 0
    End Enum

    Public Enum Gimnasio_TipoServicio
        NORMAL = 1
        PROMOCION = 2
        PREMIO_REGALO = 3
        OTROS = 4
    End Enum

    Public Enum StatusTipoCierreEmpresa
        Logistica
        Finanzas
        Contabilidad
    End Enum

    Public Enum statusTipoCierre
        CierreMensual = 0
        AperturaEmpresa = 1
        CierreAnual = 2
    End Enum


    Public Class InfoNotas
        Public Property tieneGasto As String
        Public Property seguirOperaion As String
    End Class

    Public Enum ModulosSoftpack
        ModuloPos = 0
        ModuloComercial = 1
        SoftpackAdmin = 2
    End Enum

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="GGC"></param>
    ''' <param name="FilaSel">Full Row Select</param>
    ''' <remarks></remarks>
    Sub FormatoGridPequeño(GGC As GridGroupingControl, FilaSel As Boolean)
        Dim colorx As New GridMetroColors()
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = False
        GGC.ShowColumnHeaders = True

        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        GGC.SetMetroStyle(colorx)
        GGC.BorderStyle = BorderStyle.None
        '  GGC.BrowseOnly = True
        If FilaSel = True Then
            GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
            GGC.TableOptions.ListBoxSelectionCurrentCellOptions = GridListBoxSelectionCurrentCellOptions.HideCurrentCell
            GGC.TableOptions.ListBoxSelectionMode = SelectionMode.One
            GGC.TableOptions.SelectionBackColor = Color.Gray
        End If
        GGC.AllowProportionalColumnSizing = False
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        GGC.Table.DefaultColumnHeaderRowHeight = 27
        GGC.Table.DefaultRecordRowHeight = 20
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Public Sub FormatGrid_DarkCell(ByVal grid As GridGroupingControl, ByVal GridVerticalAlignment As GridVerticalAlignment, ByVal GridHorizontalAlignment As GridHorizontalAlignment, ByVal BorderStyle As BorderStyle)
        grid.Appearance.AnyCell.TextColor = Color.WhiteSmoke
        grid.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        grid.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.WhiteCurrentCell
        grid.TableOptions.ListBoxSelectionMode = SelectionMode.One
        grid.TableOptions.SelectionBackColor = Color.FromArgb(85, 170, 255) ' ColorTranslator.FromHtml("#FF97F4BB");//Color.FromArgb(85, 170, 255);
        grid.TableOptions.SelectionTextColor = Color.Black 'Color.FromArgb(85, 170, 255);
        grid.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment ' GridVerticalAlignment.Middle;
        grid.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment ' GridHorizontalAlignment.Center;
        grid.BorderStyle = BorderStyle
    End Sub


    Sub FormatoGridPequeño(GGC As GridGroupingControl, FilaSel As Boolean, fontSize As Single)
        Dim colorx As New GridMetroColors()
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = False
        GGC.ShowColumnHeaders = True

        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        GGC.SetMetroStyle(colorx)
        GGC.BorderStyle = BorderStyle.None
        '  GGC.BrowseOnly = True
        If FilaSel = True Then
            GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
            GGC.TableOptions.ListBoxSelectionCurrentCellOptions = GridListBoxSelectionCurrentCellOptions.HideCurrentCell
            GGC.TableOptions.ListBoxSelectionMode = SelectionMode.One
            GGC.TableOptions.SelectionBackColor = Color.Gray
        End If
        GGC.AllowProportionalColumnSizing = False
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        GGC.Table.DefaultColumnHeaderRowHeight = 27
        GGC.Table.DefaultRecordRowHeight = 25
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = fontSize ' 8.0F

    End Sub

    Sub FormatoGridBlack2(dgPedidos As GridGroupingControl, FilaSel As Boolean)
        dgPedidos.Appearance.ColumnHeaderCell.Interior = New BrushInfo(GradientStyle.Vertical, Color.Black, Color.Black)
        dgPedidos.TopLevelGroupOptions.ShowCaption = False
        Dim colorF As GridMetroColors = New GridMetroColors()
        colorF.HeaderColor.NormalColor = Color.Black
        colorF.HeaderColor.HoverColor = Color.Empty
        dgPedidos.SetMetroStyle(colorF)
        dgPedidos.AllowProportionalColumnSizing = False
        dgPedidos.DisplayVerticalLines = False
        '   dgPedidos.BrowseOnly = True
        If FilaSel = True Then
            dgPedidos.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
            dgPedidos.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
            dgPedidos.TableOptions.ListBoxSelectionMode = SelectionMode.One
            dgPedidos.TableOptions.SelectionBackColor = Color.FromArgb(85, 170, 255)
        Else

        End If
        dgPedidos.TableOptions.ShowRowHeader = False
        dgPedidos.TableDescriptor.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(30, 30, 30))
        Dim captionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        dgPedidos.Table.DefaultRecordRowHeight = 30
        dgPedidos.Table.DefaultColumnHeaderRowHeight = 35
        dgPedidos.Appearance.AnyCell.TextColor = Color.White
        dgPedidos.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        dgPedidos.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        dgPedidos.TableDescriptor.Appearance.AnyCell.Borders.Bottom = New GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, Color.FromArgb(25, 25, 25))
        dgPedidos.TableDescriptor.Appearance.AnyCell.Borders.Right = New GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, Color.FromArgb(25, 25, 25))
        dgPedidos.TableDescriptor.Appearance.AnyHeaderCell.Borders.Top = New GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, Color.FromArgb(25, 25, 25))
        dgPedidos.GridOfficeScrollBars = OfficeScrollBars.Metro
        dgPedidos.TableControl.MetroColorTable.ScrollerBackground = Color.FromArgb(45, 45, 45)
        dgPedidos.TableControl.MetroColorTable.ArrowNormal = Color.FromArgb(195, 195, 195)
        dgPedidos.TableControl.MetroColorTable.ArrowChecked = Color.FromArgb(94, 171, 222)
        dgPedidos.TableControl.MetroColorTable.ThumbNormal = Color.FromArgb(31, 31, 31)
        dgPedidos.TableControl.MetroColorTable.ThumbPushed = Color.FromArgb(94, 171, 222)
        dgPedidos.TableControl.HScrollBehavior = Syncfusion.Windows.Forms.Grid.GridScrollbarMode.Disabled
        dgPedidos.TableDescriptor.Appearance.AnyCell.Font.Size = 8
    End Sub
    Sub FormatoGridBlack(dgPedidos As GridGroupingControl, FilaSel As Boolean)
        dgPedidos.Appearance.ColumnHeaderCell.Interior = New BrushInfo(GradientStyle.Vertical, Color.Black, Color.Black)
        dgPedidos.TopLevelGroupOptions.ShowCaption = False
        Dim colorF As GridMetroColors = New GridMetroColors()
        colorF.HeaderColor.NormalColor = Color.Black
        colorF.HeaderColor.HoverColor = Color.Empty
        dgPedidos.SetMetroStyle(colorF)
        dgPedidos.AllowProportionalColumnSizing = False
        dgPedidos.DisplayVerticalLines = False
        '   dgPedidos.BrowseOnly = True
        If FilaSel = True Then
            dgPedidos.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
            dgPedidos.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
            dgPedidos.TableOptions.ListBoxSelectionMode = SelectionMode.One
            dgPedidos.TableOptions.SelectionBackColor = Color.FromArgb(85, 170, 255)
        Else

        End If
        dgPedidos.TableOptions.ShowRowHeader = False
        dgPedidos.TableDescriptor.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(30, 30, 30))
        Dim captionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        dgPedidos.Table.DefaultRecordRowHeight = 30
        dgPedidos.Table.DefaultColumnHeaderRowHeight = 35
        dgPedidos.Appearance.AnyCell.TextColor = Color.White
        dgPedidos.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        dgPedidos.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        dgPedidos.TableDescriptor.Appearance.AnyCell.Borders.Bottom = New GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, Color.FromArgb(25, 25, 25))
        dgPedidos.TableDescriptor.Appearance.AnyCell.Borders.Right = New GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, Color.FromArgb(25, 25, 25))
        dgPedidos.TableDescriptor.Appearance.AnyHeaderCell.Borders.Top = New GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, Color.FromArgb(25, 25, 25))
        dgPedidos.GridOfficeScrollBars = OfficeScrollBars.Metro
        dgPedidos.TableControl.MetroColorTable.ScrollerBackground = Color.FromArgb(45, 45, 45)
        dgPedidos.TableControl.MetroColorTable.ArrowNormal = Color.FromArgb(195, 195, 195)
        dgPedidos.TableControl.MetroColorTable.ArrowChecked = Color.FromArgb(94, 171, 222)
        dgPedidos.TableControl.MetroColorTable.ThumbNormal = Color.FromArgb(31, 31, 31)
        dgPedidos.TableControl.MetroColorTable.ThumbPushed = Color.FromArgb(94, 171, 222)
        dgPedidos.TableControl.HScrollBehavior = Syncfusion.Windows.Forms.Grid.GridScrollbarMode.Disabled
    End Sub

    Sub FormatoGridTouch(GGC As GridGroupingControl, FullRowSelect As Boolean, AllowProportionalColumnSizing As Boolean, sizeFont As Single)
        Dim colorx As New GridMetroColors()
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = False
        GGC.ShowColumnHeaders = True

        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        GGC.SetMetroStyle(colorx)
        GGC.BorderStyle = BorderStyle.None
        '  GGC.BrowseOnly = True
        If FullRowSelect = True Then
            GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
            GGC.TableOptions.ListBoxSelectionCurrentCellOptions = GridListBoxSelectionCurrentCellOptions.HideCurrentCell
            GGC.TableOptions.ListBoxSelectionMode = SelectionMode.One
            GGC.TableOptions.SelectionBackColor = Color.Gray
        End If
        GGC.AllowProportionalColumnSizing = AllowProportionalColumnSizing
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        GGC.Table.DefaultColumnHeaderRowHeight = 50
        GGC.Table.DefaultRecordRowHeight = 32
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = sizeFont ' 8.0F

    End Sub

    Sub FormatoGridAvanzado(GGC As GridGroupingControl, FullRowSelect As Boolean, AllowProportionalColumnSizing As Boolean)
        Dim colorx As New GridMetroColors()
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = False
        GGC.ShowColumnHeaders = True

        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        GGC.SetMetroStyle(colorx)
        GGC.BorderStyle = BorderStyle.None
        '  GGC.BrowseOnly = True
        If FullRowSelect = True Then
            GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
            GGC.TableOptions.ListBoxSelectionCurrentCellOptions = GridListBoxSelectionCurrentCellOptions.HideCurrentCell
            GGC.TableOptions.ListBoxSelectionMode = SelectionMode.One
            GGC.TableOptions.SelectionBackColor = Color.Gray
        End If
        GGC.AllowProportionalColumnSizing = AllowProportionalColumnSizing
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        GGC.Table.DefaultColumnHeaderRowHeight = 27
        GGC.Table.DefaultRecordRowHeight = 20
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Sub FormatoGridAvanzado(GGC As GridGroupingControl, FullRowSelect As Boolean, AllowProportionalColumnSizing As Boolean, sizeFont As Single)
        Dim colorx As New GridMetroColors()
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = False
        GGC.ShowColumnHeaders = True

        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        GGC.SetMetroStyle(colorx)
        GGC.BorderStyle = BorderStyle.None
        '  GGC.BrowseOnly = True
        If FullRowSelect = True Then
            GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
            GGC.TableOptions.ListBoxSelectionCurrentCellOptions = GridListBoxSelectionCurrentCellOptions.HideCurrentCell
            GGC.TableOptions.ListBoxSelectionMode = SelectionMode.One
            GGC.TableOptions.SelectionBackColor = Color.Gray
        End If
        GGC.AllowProportionalColumnSizing = AllowProportionalColumnSizing
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        GGC.Table.DefaultColumnHeaderRowHeight = 27
        GGC.Table.DefaultRecordRowHeight = 25
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = sizeFont ' 8.0F

    End Sub

    Sub FormatoGridAvanzado(GGC As GridGroupingControl, FullRowSelect As Boolean, AllowProportionalColumnSizing As Boolean, sizeFont As Single, SelectionMode As SelectionMode)
        Dim colorx As New GridMetroColors()
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = False
        GGC.ShowColumnHeaders = True

        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        GGC.SetMetroStyle(colorx)
        GGC.BorderStyle = BorderStyle.None
        '  GGC.BrowseOnly = True
        If FullRowSelect = True Then
            GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
            GGC.TableOptions.ListBoxSelectionCurrentCellOptions = GridListBoxSelectionCurrentCellOptions.HideCurrentCell
            GGC.TableOptions.ListBoxSelectionMode = SelectionMode
            GGC.TableOptions.SelectionBackColor = Color.Gray
        End If
        GGC.AllowProportionalColumnSizing = AllowProportionalColumnSizing
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        GGC.Table.DefaultColumnHeaderRowHeight = 27
        GGC.Table.DefaultRecordRowHeight = 25
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = sizeFont ' 8.0F

    End Sub


    Public Sub FormatoGridPrincipal(GGC As GridGroupingControl)
        'Dim colorx As New GridMetroColors()
        'GGC.TableOptions.ShowRowHeader = False
        'GGC.TopLevelGroupOptions.ShowCaption = False
        'GGC.ShowColumnHeaders = True

        'colorx = New GridMetroColors()
        'colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        'colorx.HeaderTextColor.HoverTextColor = Color.Gray
        'colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        'GGC.SetMetroStyle(colorx)
        'GGC.BorderStyle = System.Windows.Forms.BorderStyle.None
        ''  GGC.BrowseOnly = True
        'GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        GGC.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        GGC.TableOptions.ListBoxSelectionMode = SelectionMode.One
        GGC.TableOptions.SelectionBackColor = Color.Gray
        'GGC.AllowProportionalColumnSizing = False
        'GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        'GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'GGC.Table.DefaultColumnHeaderRowHeight = 45
        'GGC.Table.DefaultRecordRowHeight = 40
        'GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Public Sub FormatoGrid(GGC As GridGroupingControl)
        Dim colorx As New GridMetroColors()
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = False
        GGC.ShowColumnHeaders = True

        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        GGC.SetMetroStyle(colorx)
        GGC.BorderStyle = System.Windows.Forms.BorderStyle.None
        '  GGC.BrowseOnly = True
        GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        GGC.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        GGC.TableOptions.ListBoxSelectionMode = SelectionMode.One
        GGC.TableOptions.SelectionBackColor = Color.Gray
        GGC.AllowProportionalColumnSizing = False
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        GGC.Table.DefaultColumnHeaderRowHeight = 45
        GGC.Table.DefaultRecordRowHeight = 40
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Public Class CajaSeleccionada

        Public Sub New()

        End Sub

        Public Property FormaPago() As String
        Public Property FormaPagoDetalle() As String
        Public Property entidad() As String
        Public Property entidadDetalle() As String
        Public Property CuentaCorriente() As String
    End Class

    Public Structure StatusCodigoLibroContable
        Const LIBRO_CAJA_Y_BANCOS = "1"
        Const REGISTRO_DE_COSTOS = "10"
        Const REGISTRO_DE_HUESPEDES = "11"
        Const REGISTRO_DE_INVENTARIO_PERMANENTE_EN_UNIDADES_FISICAS = "12"
        Const REGISTRO_DE_INVENTARIO_PERMANENTE_VALORIZADO = "13"
        Const REGISTRO_DE_VENTAS_E_INGRESOS = "14"
        Const REGISTRO_DE_VENTAS_E_INGRESOS_ARTICULO_23_RESOL_DE_SUPERINT_N_266_2004_SUNAT = "15"
        Const REGISTRO_DEL_REGIMEN_DE_PERCEPCIONES = "16"
        Const REGISTRO_DEL_REGIMEN_DE_RETENCIONES = "17"
        Const REGISTRO_IVAP = "18"
        Const REGISTRO_AUXILIAR_DE_ADQUISICIONES_ART_8_RESOL_SUPERINT_N_022_98_SUNAT = "19"
        Const LIBRO_DE_INGRESOS_Y_GASTOS = "2"
        Const REGISTRO_AUXILIAR_DE_ADQUISICIONES_INCISO_A_PRIMER_PARRAFO_ART_5_RESOL_N021_99_SUNAT = "20"
        Const REG_AUX_DE_ADQINCISO_APRIMER_PARRAFO_ART5_RESOL_N_142_2001_SUNAT = "21"
        Const REG_AUX_DE_ADQINCISO_C_PRIMER_PARRAFO_ART5_RESOL_N256_2004_SUNAT = "22"
        Const REG_AUX_DE_ADQINCISO_A_PRIMER_PARRAFO_ART5_RESOL_N257_2004_SUNAT = "23"
        Const REG_AUX_DE_ADQINCISO_C_PRIMER_PARRAFO_ART5_RESOL_N258_2004_SUNAT = "24"
        Const REG_AUX_DE_ADQINCISO_A_PRIMER_PARRAFO_ART5_RESOL_N259_2004_SUNAT = "25"
        Const REGISTRO_DE_RETENCIONES_ART_77_A_DE_LA_LEY_DEL_IMPUESTO_A_LA_RENTA = "26"
        Const LIBRO_DE_ACTAS_DE_LA_EMPRESA_INDIVIDUAL_DE_RESPONSABILIDAD_LIMITADA = "27"
        Const LIBRO_DE_ACTAS_DE_LA_JUNTA_GENERAL_DE_ACCIONISTAS = "28"
        Const LIBRO_DE_ACTAS_DEL_DIRECTORIO = "29"
        Const LIBRO_DE_INVENTARIOS_Y_BALANCES = "3"
        Const LIBRO_DE_MATRICULAS_DE_ACCIONES = "30"
        Const LIBRO_DE_PLANILLAS = "31"
        Const REGISTRO_DE_PRESTAMOS = "32"
        Const LIBRO_DE_RETENCIONES_INCISOS_E_Y_F_DEL_ARTICULO_34_DE_LA_LEY_DEL_IMPUESTO_A_LA_RENTA = 4
        Const LIBRO_DIARIO = "5"
        Const LIBRO_DIARIO_DE_FORMATO_SIMPLIFICADO = "5-A"
        Const LIBRO_MAYOR = "6"
        Const REGISTRO_DE_ACTIVOS_FIJOS = "7"
        Const REGISTRO_DE_COMPRAS = "8"
        Const REGISTRO_DE_CONSIGNACIONES = "9"
    End Structure

    Public Enum StatusArticulo
        Activo = 1
        Inactivo = 0
        Retenido = 2
        Vencido = 3
        EnTransito = 4
    End Enum

    Public Enum StatusArticuloVentaPreparado
        Pendiente = 0
        ListoParaEntregar = 1
        EntregadoAlCliente = 2
        eliminado = 3
    End Enum

    Public Enum statusComprobantes
        Observado = 0
        Normal = 1
    End Enum


    Public Structure TIPO_MOVIMIENTO
        Public Const ENTRADAS_CAJA = "OTRAS ENTRADA CAJA"
        Public Const SALIDA_CAJA = "OTRAS SALIDA CAJA"
        Public Const TRANSFERENCIA_CAJA = "TRANSFERENCIA ENTRE CAJA"
        Public Const INGRESO_VENTA_GENERAL = "INGRESO POR VENTAS GENERAL"
        Public Const INGRESO_VENTA_POS = "INGRESO POR VENTA POS"
        Public Const INGRESO_VENTA_TICKET = "INGRESO POR VENTA POR TICKET"
        Public Const ANTICPO_OTORGADO = "ANTICIPO OTORGADO"
        Public Const ANTICPO_RECIBIDO = "ANTICIPPO RECIBIDO"
        Public Const APORTE = "APORTE"
    End Structure

    Public Structure TIPO_ESTADO_CAJA
        Public Const NO_USADO = "N"
        Public Const USADO_PARCIAL = "P"
        Public Const USADO_TOTAL = "U"
        Public Const ANULADO = "A"
        Public Const DEVOLUCION = "D"
    End Structure

    Public Structure TIPO_ESTADO_NOMBRE_CAJA
        Public Const NO_USADO = "PENDIENTE DE USO"
        Public Const USADO_PARCIAL = "IMPUTADO PARCIALMENTE"
        Public Const USADO_TOTAL = "IMPUTADO TOTAL"
        Public Const ANULADO = "REVERTIDO-ANULADO"
        Public Const DEVOLUCION = "DEVOLUCION"
    End Structure

    Public Enum StatusAsientoCosto
        NoTieneAsiento = 0
        AsientoPorConfirmar = 1
        AsientoProcesado = 2
    End Enum

    Public Function ListaDeMeses() As List(Of MesesAnio)
        Dim listaMeses As New List(Of MesesAnio)
        Dim obj As New MesesAnio

        For x = 1 To 12
            obj = New MesesAnio
            obj.Codigo = String.Format("{0:00}", CInt(x))
            obj.Mes = New DateTime(Date.Now.Year, x, 1).ToString("MMMM")
            listaMeses.Add(obj)
        Next x

        Return listaMeses
    End Function

    'Public Structure Configuracion_General
    '    Friend TipoCambio As Decimal
    '    Friend TmpPorcGanacia As Decimal
    '    Friend TmpNombreAlmacen As String
    '    Friend TmpIdAlmacen As Integer
    'End Structure

    Public Structure StatusTipoOperacion
        Const COBRO_A_PROVEEDORES_RECLAMACION = "9938"
        Const PAGO_A_CLIENTES_RECLAMACION = "9937"
        Const OTRAS_ENTRADAS_A_ALMACEN = "0000"
        Const OTRAS_SALIDAS_DE_ALMACEN = "0001"
        Const VENTA = "01"
        Const GUIA_REMISION = "09"
        Const NOTA_VENTA = "01.1"
        Const COMPRA = "02"
        Const CONSIGNACION_RECIBIDA = "03.01"
        Const DEVOLUCION_ANULACION_DE_CONSIGNACION_RECIBIDA = "03.02"
        Const CONSIGNACION_OTORGADA = "04.01"
        Const ANULACION_DEVOLUCION_DE_CONSIGNACION_OTORGADA = "04.02"
        Const DEVOLUCION_RECIBIDA = "05"
        Const DEVOLUCION_ENTREGADA = "06"
        Const PROMOCION_RECIBIDA = "07.01"
        Const PROMOCION_ENTREGADA = "07.02"
        Const PREMIO_RECIBIDO = "08.01"
        Const PREMIO_ENTREGADO = "08.02"
        Const DONACION_RECIBIDA = "09.01"
        Const DONACION_ENTREGADA = "09.02"
        Const SALIDA_DE_INVENTARIOS_PARA_PRODUCCION = "10.01"
        Const INGRESO_POR_DEVOLUCION_DE_INVENTARIOS_QUE_SALIERON_A_PRODUCCION = "10.02"
        Const RETORNO_DE_PRODUCTOS_TERMINADOS = "10.03"
        Const RETORNO_DE_SUB_PRODUCTOS = "10.04"
        Const SALIDA_DE_PRODUCTOS_EN_PROCESO = "10.05"
        Const RETORNO_DE_DESECHOS_Y_DESPERDICIOS = "10.06"
        Const RETORNO_DE_PRODUCTOS_EN_PROCESO = "10.07"
        Const PRESTAMOS_OTORGADOS = "100"
        Const PRESTAMOS_RECIBIDOS = "101"
        Const ANTICIPOS_RECIBIDOS = "103"
        Const ANTICIPOS_OTORGADOS = "104"
        Const Apertura_Cierre_de_Caja = "105"
        Const TRANSFERENCIA_ENTRE_ALMACENES = "11"
        Const RETIROS = "12"
        Const TICKET_BOLETA = "12.1"
        Const TICKET_FACTURA = "12.2"
        Const MERMAS = "13"
        Const DESMEDROS = "14"
        Const DESTRUCCION = "15"
        Const SALDO_INICIAL_O_CIERRES = "16"
        Const APORTES = "17"
        Const OTROS_EXCEDENTE_SOBRANTE_POR_INVENTARIO_ = "99.01"
        Const OTROS_BONIFICACIONES_OTORGADAS = "99.02"
        Const OTROS_INGRESO_POR_OTRAS_OPERACIONES = "99.07"
        Const OTROS_SALIDAS_POR_OTRAS_OPERACIONES = "99.09"
        Const INGRESO_DE_PRODUCTOS_TERMINADOS = "9903"
        Const INGRESO_DE_SUBPRODUCTOS_DESECHOS_Y_DESPERDICIOS = "9904"
        Const INVERSIONES_MOVILIARIAS = "9905"
        Const CIERRES = "9906"
        Const PAGO_A_PROVEEDORES = "9907"
        Const COBRO_A_CLIENTES = "9908"
        Const OTRAS_ENTRADAS_DE_DINERO = "9909"
        Const OTRAS_ENTRADAS_DE_DINERO_ESPECIAL = "9931"
        Const OTRAS_SALIDAS_DE_DINERO = "9910"
        Const TRANFERENCIAS_ENTRE_CAJAS_DE_DINERO = "9911"
        Const INGRESO_DINERO_POR_NOTA_CREDITO = "9912"
        Const NC_DISMINUIR_CANTIDAD = "9913"
        Const NC_DISMINUIR_IMPORTE = "9914"
        Const NC_DISMINUIR_CANTIDAD_E_IMPORTE = "9915"
        Const NC_DEVOLUCION_DE_EXISTENCIAS = "9916"
        Const BONIFICACIONES_RECIBIDAS_OPC_Beneficios = "9917"
        Const BONIFICACIONES_RECIBIDAS_OPC_Reduc_costos = "9918"
        Const INGRESO_CUENTAS_MANUALES = "9919"
        Const DEVOLUCION_X_NOTA_DE_CREDITO_A_CLIENTE = "9920"
        Const NB_INCREMENTO_DEL_COSTO = "9921"
        Const DEVOLUCION_X_NOTA_DE_CREDITO_A_PROVEEDOR = "9922"
        Const NB_OTROS = "9923"
        Const CIERRE_COSTO_VENTA = "9924"
        Const PRONTO_PAGO_VOLUMEN_DE_COMPRA = "9925"
        Const REVERSIONES = "9926"
        Const DEVOLUCION_DE_ANTICIPO_A_CLIENTE = "9927"
        Const DEVOLUCION_DE_ANTICIPO_A_PROVEEDOR = "9928"
        Const DEVOLUCION_DE_ANTICIPO_A_TRABAJADOR = "9929"
        Const SALIDA_DINERO_POR_NOTA_CREDITO = "9931"
        Const PAGO_COMISIONES = "9932"
    End Structure


    Public Enum StatusPresupestoProyecto
        Abierto = 1
        Cerrado = 0
    End Enum

    Public Property ModuloPadreSeleccionado() As String

    Public Property ProyectoGeneralSel() As Helios.Cont.Business.Entity.recursoCosto

    Public Property ListaComprobantes As List(Of Helios.Cont.Business.Entity.tabladetalle)
    Public Property ListaUnidadMedida As List(Of Helios.Cont.Business.Entity.tabladetalle)
    Public Property ListaPresentacion As List(Of Helios.Cont.Business.Entity.tabladetalle)


    Public Enum StatusProductosTerminados
        Pendiente = 0
        Entregado = 1
        Observado = 2
        Erroneo = 3
    End Enum

    Public Sub Centrar(ByVal Objeto As Object)

        ' Centrar un Formulario ...  
        If TypeOf Objeto Is Form Then
            Dim frm As Form = CType(Objeto, Form)
            With Screen.PrimaryScreen.WorkingArea ' Dimensiones de la pantalla sin el TaskBar  
                frm.Top = (.Height - frm.Height) \ 2
                frm.Left = (.Width - frm.Width) \ 2
            End With

            ' Centrar un control dentro del contenedor  
        Else
            ' referencia al control  
            Dim c As Control = CType(Objeto, Control)

            'le  establece el top y el Left dentro del Parent  
            With c
                .Top = (.Parent.ClientSize.Height - c.Height) \ 2
                .Left = (.Parent.ClientSize.Width - c.Width) \ 2
            End With
        End If
    End Sub

    Public Enum StatusPagoMonedaExtranjera
        Saldado = 2
        Pendiente = 0
        Parcial = 1
    End Enum

    Public Structure StatusEntidad
        Const Activo = "A"
        Const Inactivo = "I"
    End Structure

    Public Enum StatusCajaExtranjera
        pago = 0
        cobro = 1
    End Enum

    Public Structure TipoGuiaDetalle
        Const Pendiente = "PN"
        Const Entrega_Total = "ET"
        Const Entrega_Parcial = "EO"
    End Structure

    Public Structure TipoGuia
        Const Pendiente = "PN"
        Const Transito = "TR"
        Const Entregado = "ET"
    End Structure

    Public Enum TipoRecursoPlaneado
        Inventario = 0
        ManoDeObra = 1
        ActivoInmovilizado = 2
        Terceros = 3
    End Enum

    Public Structure MaestrosGenerales
        Const PuntoVentaBasico = "frmPos_0"
        Const PuntoVentaIntermendio = "0"
        Const PuntoVentaAvanzado = "frmMaestroModulos"
    End Structure

    Public Structure Status
        Const Distribuido = "D"
        Const Entrada_almacen = "E"
        Const Salida_almacen = "S"
        Const Pendiente_Entrega = "P"
    End Structure

    Public Structure TipoAlmacen
        Const transito = "AV"
        Const Deposito = "AF"
    End Structure

    Public Class BusquedaExstencia
        Public Property NombreExistencia() As String
        Public Property TipoExistencia() As String
        Public Property IdExistencia() As Integer
        Public Property UnidadMedida() As String
        Public Property nroLote() As String
        Public Property fechaVcto() As String
    End Class

    Public Class EnvioExistencia
        Public Property FechaEnvio As DateTime
        Public Property TipoDoc() As String
        Public Property Serie() As String
        Public Property Numero() As String
        Public Property Almacen() As Integer
        Public Property nroLote() As String
        Public Property fechaVcto() As DateTime?
    End Class

    Public Enum TipoMoneda
        Nacional = 1
        Extranjero = 2
    End Enum

    Public Structure CuentaFinanciera
        Const Efectivo = "EF"
        Const Efectivo_Cajero = "EP"
        Const Banco = "BC"
        Const Tarjeta_Credito = "TC"
        Const Tarjeta_Debito = "TD"
    End Structure

    Public Class MesesAnio
        Public Property Codigo() As String
        Public Property Mes() As String
    End Class

    Public Structure TipoExistencia
        Const Mercaderia = "01"
        Const ProductoTerminado = "02"
        Const MateriaPrima = "03"
        Const EnvasesEmbalajes = "04"
        Const MaterialAuxiliar_SuministroRepuesto = "05"
        Const SubProductosDesechos = "06"
        Const ProductosEnProceso = "07"
        Const ActivoInmovilizado = "08"
        Const ServicioGasto = "GS"
        Const Kit = "09"
        Const Infraestructura = "IF"
    End Structure


    Public Enum OperacionGravada
        Grabado = 1
        Exonerado = 2
        Inafecto = 3
    End Enum

    Public Structure TipoCosto
        Const Proyecto = "PY"
        Const CONTRATOS_DE_CONSTRUCCION = "CC1"
        Const CONTRATOS_DE_SERVICIOS_POR_VALORIZACIONES_O_SIMILARES = "CC2"
        Const CONTRATOS_DE_ARRENDAMIENTOS = "CC3"
        Const OP_CONTINUA_DE_BIENES = "OP1"
        Const OP_DE_BIENES_CONTROL_INDEPENDIENTE = "OP2"
        Const OP_CONTINUA_DE_SERVICIOS = "OP3"
        Const OP_DE_SERVICIOS_CONTROL_INDEPENDIENTE = "OP4"
        Const OP_DE_SERVICIOS_CONSUMO_INMEDIATO_DE_BIENES = "OP5"
        Const OrdenProduccion = "ORP"
        Const ActivoFijo = "ACT"
        Const GastoAdministrativo = "GADM"
        Const GastoVentas = "GAVT"
        Const GastoFinanciero = "FIN"
        Const HC_Mercaderia = "HMC"
        Const ProductoProducido = "PPR"


        Const COSTOS_POR_VALORACION = "CPV"
        Const COSTOS_POR_PROCESOS_PROD = "CPP"
        Const COSTOS_POR_PROCESO_ESTIMADO = "CPE"
    End Structure

    Public Structure StatusCosto
        Const Avance_Obra_Cartera = "0"
        Const Suspendido = "3"
        Const Culminado = "1"
        Const Proceso = "2"

    End Structure

    Structure Tipo_Caja
        Const PUNTO_DE_VENTA = "POS"
        Const ADMINISTRATIVO = "ADM"
        Const GENERAL = "GNR"
    End Structure

    Structure Nota_Credito
        Const DINERO_ENTREGADO = "DEN"
        Const DINERO_PENDIENTE_DE_ENTREGA = "DEP"
        Const PROCESADO_SIN_MOVIMIENTOS = "PRS"
    End Structure

    Public GConfiguracion As GConfiguracionModulo
    'Public GConfiguracion2 As GConfiguracionModulo
    ''Structure TipoEntidad
    '    Const CLIENTE = "CL"
    '    Const PROVEEDOR = "PR"
    '    Const OTRO_CLIENTE = "OCL"dd
    '    Const OTRO_PROVEEDOR = "OPR"
    'End Structure

    Public Property Modpreliminar() As Modulo_Preliminar

    Enum ModuloSistema
        PLANEAMIENTO = 1
        CONTABILIDAD = 2
        CAJA = 3
        PUNTO_DE_VENTA = 4
    End Enum

    Public Structure Notas_Credito
        Const DEV_EXISTENCIA = "01"
        Const DR_REDUCCION_COSTOS = "02"
        Const DR_BENEFICIO = "03"
        Const ERR_PRECIO = "04"
        Const ERR_CANTIDAD = "05"
        Const BOF_REDUC_COSTO_IGUAL_COMPRA = "06"
        Const BOF_REDUC_COSTO_DISTINTO_COMPRA = "07"
        Const BOF_BENEFICIO_TERCEROS = "08"
    End Structure

    Public Structure TIPO_SITUACION
        Const ALMACEN_TRANSITO = "ALT"
        Const ALMACEN_TRANSITO_FISICO = "ALTF"
        Const ALMACEN_FISICO = "ALF"
        Const ALMACEN_FISICO_SOBRANTE = "ALFS"
        Const NOTIFICACION_SOBRANTE = "NS"
        Const NOTIFICACION_COMPLETA = "NC"
        Const NOTIFICACION_DOCUMENTO_CAJA = "NDC"
        Const NOTIFICACION_DOCUMENTO_CAJA_COMPLETA = "NDCC"
        Const CAJA_COBRO = "CC"
        Const CAJA_PAGO = "CP"
        Const ORDEN_COMPRA_RECEPCION = "OCR"
        Const ORDEN_SERVICIO_RECEPCION = "OSR"
        Const ORDEN_COMPRA_TRANSITO = "OCT"
        Const ORDEN_SERVICIO_TRANSITO = "OST"
        Const ORDEN_COMPRA_TRANSITO_RECEPCION = "OCTR"

        Structure SUSPENSION_RETENCION
            Const TIENE = "SI"
            Const NO_TIENE = "NO"
        End Structure

    End Structure

    Public Structure MovimientoCaja
        Const PagoProveedor = "PPR"
        Const CobroCliente = "CCR"
        Const TrasferenciaEntreCajas = "TEC"
        Const VentaDirectaPOS = "VPOS"
        Const SalidaDinero = "PG"
        Const EntradaDinero = "DC"
        Const Otras_Entradas = "OEC"
        Const Otras_Entradas_Especial = "OECP"
        Const Otras_Saliadas = "OSC"
        Const Aportes = "OAC"
        Const Devolucion = "DV"
        Const Reversion = "RV"
        Const Compensacion = "AC"
        Const Anticipos_recibidos = "AR"
        Const Anticipos_Otorgados = "AO"
    End Structure

    Enum Modulo_Preliminar
        BASICO = 1
        INTERMEDIO = 2
    End Enum

    Public Structure ASIENTO_CONTABLE
        Const InicioDeOperaciones = "Init"
        Const CostoVenta = "Cstv"
        Const Finanzas = "Fnz"
        Const Inventario = "Inv"
        Const OrdenCompra = "Orc"
        Const OrdenServicio = "Ors"
        Const Entregables = "CEnt"

        Const Compra_Existencia = "Cex"
        Const Compra_ServiciosPublicos = "Csp"
        Const Compra_ReciboHonorarios = "Crh"
        Const Compra_Importaciones = "Cip"
        Const Compra_Anticipada = "Cap"
        Const Compra_NotaCredito = "Cncr"
        Const Compra_NotaDebito = "Cndb"
        Const Compra_AnulacionFinanciera = "Cnuf"

        Const Venta_Existencia = "Vex"
        Const Venta_ServiciosPublicos = "Vsp"
        Const Venta_ReciboHonorarios = "Vrh"
        Const Venta_Importaciones = "Vrh"
        Const Venta_Anticipada = "Vap"
        Const Venta_NotaCredito = "Vncr"
        Const Venta_NotaDebito = "Vndb"
        Const Venta_AnulacionFinanciera = "Vnuf"
        Const AjustesContables = "AJ"

        Const PAGO_RECLAMACION = "AS-CR"
        Const COBRO_RECLAMACION = "AS-PR"
        Const APORTE_EXISTENCIA = "APEX"
        'Const COMPRA = "AS-C"
        Const OTRAS_ENTRADAS = "AS-OEA"
        'Const COMPRA_NOTA_CREDITO = "AS-NTC"
        'Const COMPRA_NOTA_DEBITO = "AS-NDB"
        Const PRODUCTOS_EN_TRANSITO = "AS-PT"
        Const COBRO_VENTA = "AS-VC"
        Const COBRO_OTROS_CONCEPTOS = "AS-COCP"
        Const PAGO_COMPRA = "AS-CP"
        Const BONIFICACION = "AS-BOF"
        Const EXCEDENTE_NOTA_CREDITO = "AS-EXC"
        Const CIERRE_CAJA_USUARIO = "CJU"
        Const OTRAS_ENTRADAS_CAJA = "AS-OEC"
        Const OTRAS_SALIDAS_CAJA = "AS-OSC"
        Const TRANSFERENCIA_CAJA = "AS-TEC"
        Const PRESTAMOS_OTORGADOS = "PR-OT"
        Const PRESTAMOS_OTORGADOS_INTERES = "PR-OTI"

        Const PRESTAMOS_RECIBIDO = "PR-RC"
        Const PRESTAMOS_RECIBIDO_INTERES = "PR-RCI"
        Const APORTES = "AS-APO"

        Const ANTICIPOS = "AR"
        Structure UBICACION
            Const DEBE = "D"
            Const HABER = "H"
        End Structure

        Structure HABILITADO
            Const ENABLED = "E"
            Const DISABLED = "D"
        End Structure
    End Structure

    Public Structure TIPO_ACTIVIDAD_MODULO
        Const FASE = "FS"
        Const ENTREGABLE = "EDT"
        Const PROYECTO = "PY"
        Const ACTIVIDAD = "AC"
        Const EQUIPO_PROYECTO = "EQ"
        Const EQUIPO_CLIENTE = "EQC"
    End Structure


    Public Structure TIPO_ENTIDAD
        Const INSTRUCTOR_GIMNASIO = "IS"
        Const VENDEDOR_MEMBRESIAS = "VM"
        Const PERSONA_GENERAL = "TR"
        Const PROVEEDOR = "PR"
        Const CLIENTE = "CL"
        Const OTRO_CLIENTE = "OCL"
        Const OTRO_PROVEEDOR = "OPR"
        Const ACCIONISTA = "AC"
        Const CLIENTE_INDEPENDIENTE = "CI"
        Const PERSONAL_PLANILLA = "PL"
        Const TRANSPORTE_CONDUCTOR = "TR"
        Const USUARIO = "UC"
    End Structure

    Public Structure TipoReferenciaSustento
        Const COSTO_IGV = "COSTO IGV"
        Const SOLO_COSTO = "SOLO COSTO"
        Const NO_SUSTENTADO = "NO SUSTENTADO"
    End Structure

    Public Structure TipoRecurso
        Const EXISTENCIA = "EX"
        Const SERVICIO = "GS"
        Const RECURSOS_HUMANOS = "RH"
        Const TAREA_OPERACIONAL = "SM"
    End Structure

    Public Structure ENTITY_ACTIONS
        Public Const INSERT As String = "I"
        Public Const UPDATE As String = "U"
        Public Const DELETE As String = "D"
    End Structure



    Public Structure SEGURIDAD
        Public Enum Roles
            NINGUNO = 0
            'ADMIN = 1
            'USUARIO = 2
            'INVITADO = 3

            ADMINISTRADOR_POS = 1
            ATENCION_PREVENTA = 2
            CAJA_CENTRALIZADA = 3
            CAJA_VENTA_DIRECTA = 4

        End Enum

        Public Structure Asegurables
            Public Const EMPRESA As String = "EMPRESA"
            Public Const ESTABLECIMIENTO As String = "ESTABLECIMIENTO"
        End Structure
    End Structure

    Public Structure TIPO_DIRECCION
        Public Const INICIACION As String = "INICIACION"
        Public Const PLANIFICACION As String = "PLANIFICACION"
        Public Const EJECUCION As String = "EJECUCION"
        Public Const MONITOREO As String = "MONITOREO"
        Public Const CIERRE As String = "CIERRE"
    End Structure


    Public Structure StatusVentaMatizados
        Const PorPreparar = "C1"
        Const TerminadaYentregada = "C2"
    End Structure

    Public Structure TIPO_VENTA

        Const PROFORMA = "PRF"
        Const NOTA_DE_VENTA = "NOTE"
        Const COTIZACION = "CTZ"
        Const PRE_VENTA = "PV"
        Const VENTA_RECLAMACION_COMPROMISO = "VRC"
        Const NOTA_CREDITO_ELECTRONICA = "NTCE"
        Const RETENCION = "RET"
        Const CambioArticulo = "CAT"
        Const VENTA_RECONOCIMIENTO = "VREC"
        Const VENTA_POS_DIRECTA = "VPOS"
        Const VENTA_ELECTRONICA = "VELC"
        Const VENTA_HEREDAD = "VHE"
        Const NOTA_DE_VENTA_ANULADA = "NOTEA"
        Const OTRAS_SALIDAS_PRODUCCION = "OSAP"
        Const VENTA_GENERAL = "VTAG"
        Const OTRAS_SALIDAS = "OSA"
        Const VENTA_PAGADA = "VPG"
        Const VENTA_AL_CREDITO = "VAC"
        Const VENTA_AL_TICKET = "VTK"
        Const VENTA_AL_TICKET_DIRECTA = "VTKD"
        Const VENTA_NORMAL_CREDITO = "VNC"
        Const INGRESO_CAJA_OTROS_CONCEPTOS = "ICOC"
        Const SALIDA_CAJA_OTROS_CONCEPTOS = "SCOC"
        Const VENTA_ANULADA = "VA"
        Const AnuladaPorNotaCredito = "ANUC"
        Const VENTA_NORMAL_CONTADO = "VND"
        Const VENTA_NOTA_CREDITO = "VNC"
        Const VENTA_NOTA_CREDITO_ANTICIPO = "VNCA"
        Const VENTA_NORMAL_SERVICIO = "VNS"
        Const VENTA_NORMAL_SERVICIO_CREDITO = "VNSC"
        Const VENTA_NOTA_PEDIDO = "VNP"
        Const VENTA_NOTA_PEDIDO_ESPECIAL = "VNPE"
        Const VENTA_ANTICIPADA = "VAC"
        Const VENTA_ANTICIPADA_RECIBIDO = "VAR"
        Const VENTA_ANTICIPADA_OTORGADO = "VAO"
        Const VENTA_CONTADO_TOTAL = "VCET"
        Const VENTA_CONTADO_PARCIAL = "VCEP"
        Const VENTA_CREDITO_TOTAL = "VCT"
        Const VENTA_CREDITO_PARCIAL = "VCP"
        Const VENTA_MEMBRESIAS_GIMANSIO = "VGYM"
        Const VENTA_PEDIDO = "VP"
        Const VENTA_ENCOMIENDAS = "ENDAS"
        Const VENTA_PASAJES = "VPSJ"
        Const VENTA_PASAJES_RESERVACION = "VPSJR"

        Public Structure PAGO
            Const PENDIENTE_PAGO = "PN"
            Const PARCIAL = "PR"
            Const COBRADO = "DC"
        End Structure
    End Structure

    Public Structure TipoEntregado
        Const Entregado = "DC"
        Const PorEntregar = "PN"
    End Structure



    Public Structure TIPO_COMPRA
        Const NOTA_DE_COMPRA = "NOTE"
        Const NOTA_DE_COMPRA_EN_ESPERA = "WAIT"
        Const PERCEPCION = "PERC"
        Const COMPRA_ANULADA = "CA"
        Const NOTA_COMPRA_ANULADA = "NCA"
        Const ENTRADA_INVENTARIO_ANULADA = "AEI"
        Const SALIDA_INVENTARIO_ANULADA = "ASI"
        Const COMPRA_SERVICIO_PUBLICO = "CSP"
        Const TRANSFERENCIA_ENTRE_ALMACEN = "TEA"
        Const COMPRA_RECIBO_HONORARIOS = "CRH"
        Const BONIFICACIONES_RECIBIDAS = "BOFR"
        Const SALDO_INICIAL = "SAI"
        Const TIPO_CAMBIO_INVENTARIO = "CTI"
        Const APORTE_INICIAL = "AP_IN"
        Const APORTE_EXISTENCIAS = "APE"
        Const OTRAS_ENTRADAS = "OEA"
        Const OTRAS_SALIDAS = "OSA"
        Const ORDEN_COMPRA = "OR-C"
        Const ORDEN_SERVICIO = "OR-S"
        Const ORDEN_SERVICIO_APROBADO = "OR-SA"
        Const ORDEN_APROBADO = "OR-A"
        Const COMPRA = "CMP"
        Const COMPRA_VINCULADA = "CMPV"
        Const COMPRA_PAGADA = "CPG"
        Const COMPRA_DIRECTA_SERVICIO = "CDS"
        Const COMPRA_AL_CREDITO = "CAC"
        Const COMPRA_SERVICIO_CREDITO = "CSC"
        Const COMPRA_AL_CREDITO_CON_RECEPCION = "CACR"
        Const NOTA_CREDITO = "NTC"
        Const NOTA_CREDITO_ELECTRONICA = "NTCE"
        Const NOTA_DEBITO = "NDB"
        Const COMPRA_DIRECTA_SIN_RECEPCION = "CDSR"
        Const COMPRA_DIRECTA_CON_RECEPCION = "CDCR"
        Const PRESTAMOS_OTORGADOS = "POT"
        Const NOTA_DEBITO_DEVOLUCION = "NDD"
        Const SOLICITUD_ESPERA = "SOL"
        Const SOLICITUD_ACEPTADA = "SOLA"
        Const PROFORMA_ESPERA = "PROF"
        Const PROFORMA_ACEPTADA = "PROFA"
        Const ANTICIPO = "ANT-C"
        Const COMPRA_TRANSITO = "C-TR"
        'Const COMPRA_ANTICIPADA = "CMA"
        Const COMPRA_ANTICIPADA_RECIBIDA = "CVR"
        Const COMPRA_ANTICIPADA_OTORGADO = "CVO"
        Public Structure PAGO
            Const PagoParcial = "PAR"
            Const PENDIENTE_PAGO = "PN"
            Const PAGADO = "PG"
        End Structure

        Structure MOVIMIENTO_ALMACEN
            Const TRANSFERENCIA_ALMACENES = "TEA"
            Const ENTRADA_EXISTENCIAS = "EEX"
            Const SALIDA_EXISTENCIAS = "SEX"
            Const CAMBIO_TIPO_INVENTARIO = "CTI"
        End Structure

        Public Structure TIPO_REPORTE
            Const PERIODO = "PERIODO"
            Const ACUMULADO = "ACUMULADOO"
            Const FULL = "FULL"
        End Structure

        Public Structure ESTADO_CAJA
            Public Const DISPONIBLE As String = "DEC"
            Public Const TRANSACCION As String = "TEC"
            Public Const CERRADO As String = "CEC"
        End Structure



    End Structure

    Public Function GetRoundedRect(ByVal bounds As Rectangle, ByVal radius As Integer) As GraphicsPath
        Dim diameter As Integer = radius * 2
        Dim size As Size = New Size(diameter, diameter)
        Dim arc As Rectangle = New Rectangle(bounds.Location, size)
        Dim path As GraphicsPath = New GraphicsPath()

        If radius = 0 Then
            path.AddRectangle(bounds)
            Return path
        End If


        ' top left arc  
        path.AddArc(arc, 180, 90)
        ' top right arc  
        arc.X = bounds.Right - diameter
        path.AddArc(arc, 270, 90)
        ' bottom right arc  
        arc.Y = bounds.Bottom - diameter
        path.AddArc(arc, 0, 90)
        ' bottom left arc 
        arc.X = bounds.Left
        path.AddArc(arc, 90, 90)
        path.CloseFigure()
        Return path
    End Function


#Region "GUIA REMISION"
    Public Class OTROSTIPODOCUMENTO
        Public Property Codigo() As String
        Public Property Valor() As String
        Public Property NumDoc() As Integer
    End Class

    Public Class TIPODOCUMENTO
        Public Property Codigo() As String
        Public Property Valor() As String
    End Class
    Public Class TipoGuiaRemision
        Public Property Codigo() As String
        Public Property Valor() As String
    End Class

    Public Class MOTIVOTRASLADO
        Public Property Codigo() As String
        Public Property Valor() As String
    End Class

    Public Class TipoTrasporte
        Public Property Codigo() As String
        Public Property Valor() As String
    End Class
#End Region

#Region "ORGANIGRMA"
    Public Class TipoDirecM
        Public Property Codigo() As String
        Public Property Valor() As String
    End Class
#End Region
End Module
