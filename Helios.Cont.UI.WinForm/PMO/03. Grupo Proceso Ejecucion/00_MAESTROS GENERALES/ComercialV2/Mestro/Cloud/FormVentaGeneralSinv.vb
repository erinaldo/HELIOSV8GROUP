Imports System.ComponentModel
Imports System.Drawing.Printing
Imports System.Runtime.Serialization
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.Presentation.WinForm
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Drawing
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Public Class FormVentaGeneralSinv
    Implements IForm, IPrecio, IListaInventario, IProductoConsignado,
        IOferta

    '    BOLETA ELECTRONICA
    'FACTURA ELECTRONICA

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData
            Case Keys.F7
                ToolStripButton1.PerformClick()

            Case Keys.F9
                ToolStripButton1.PerformClick()

            Case Keys.F10
                ToolStripButton2.PerformClick()

            Case Else
                'Do Nothing
        End Select

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

#Region "Fields"
    Public Property VentaSA As New documentoVentaAbarrotesSA
    Public Property ListaAsientonTransito As New List(Of asiento)
    Public Property TotalesXcanbeceras As TotalesXcanbecera
    Public Property listaClientes As New List(Of entidad)
    Public Property entidadSA As New entidadSA
    Friend Delegate Sub SetDataSourceDelegate(ByVal lista As List(Of entidad))
    Friend Delegate Sub SetDataSourceDelegateNumeracion(ByVal numeracion As moduloConfiguracion)
    Public ListaEstadosFinancieros As List(Of estadosFinancieros)
    '    Public ListaTipoExistencia As List(Of tabladetalle)
    '   Public ListaComprobantesCaja As List(Of tabladetalle)
    Public ListaAlmacenes As List(Of almacen)
    Public Alert As Alert
    Public Property documentoVenta As documentoventaAbarrotes
    Public Property documentoVentaDetalle As List(Of documentoventaAbarrotesDet)
    Public Property entidad As entidad
    Public Property frmCanastaInventary As frminfoInventario
    'Public Property FormInventarioCanastaTotales As FormInventarioCanastaTotales
    'Public Property FormVentaEnConsigna As FormVentaEnConsigna
    Private FormNotaCompraDirecta As FormNotaCompraDirecta
    Public Property InventarioSA As New TotalesAlmacenSA
    Public Property FormInventarioCanastaTotales As FormCanastaTotalesServVer2

    Public Property TipoVentaGeneral As String

#End Region

#Region "Impresion Matricial"
    Dim ImporteSobranteMN As Decimal
    Dim ImporteTotalMN As Decimal
    Dim ImporteTotalME As Decimal
    Dim estadoImpresion As Integer


    Public Título As String = ""
    Private prtSettings As PrinterSettings
    Private prtDoc As PrintDocument
    Private ppc As New PrintPreviewControl
    Private prtFont As System.Drawing.Font
    Dim conteo As Integer = 0
    Dim datosEst As Integer = 0
    Private lineaActual As Integer
    Public fontNCabecera As New System.Drawing.Font("Arial", 8, FontStyle.Regular)
    Dim X1, X2, X3, X4, X5 As Integer
    Dim W1, W2, W3, W4, W5 As Integer
    Dim Y As Integer
    Public NFecha As String
    Public NNombre As String
    Public NDireccion As String
    Public NProforma As String
    Dim lblIdDocreferenciaAnticipo As Integer
    Dim lblNumeroDoc As Integer

    Public listaproforma As New List(Of documentoventaAbarrotesDet)

    Sub llenarDatos()

        PrintPreviewDialogTicket.Document = PrintTikect

        'PrintPreviewDialog1.ShowDialog()

        ' La fuente a usar en la impresión
        prtFont = New System.Drawing.Font("Courier New", 11)
        '
        ' La configuración actual de la impresora predeterminada
        prtSettings = New PrinterSettings

    End Sub

    Public Sub prt_PrintPageSinRuc(ByVal sender As Object, ByVal e As PrintPageEventArgs)

        'mostrar si existe ruc o no
        Dim Ruc As String = ""
        ' Este evento se produce cada vez que se va a imprimir una página
        Dim pageWidth As Integer
        Dim lineHeight As Single
        Dim yPos As Single = e.MarginBounds.Top
        Dim leftMargin As Single = e.MarginBounds.Left

        Dim printFont As System.Drawing.Font

        ' Asignar el tipo de letra
        printFont = prtFont
        lineHeight = printFont.GetHeight(e.Graphics)

        If (lineaActual < 37 And lineaActual = 0) Then

            '--------------------------------------------- Encabezado del reporte -------------------------------------------

            NFecha = vbCrLf & vbCrLf & DateTime.Now
            Dim fontNFecha As New System.Drawing.Font("arial", 8, FontStyle.Regular)
            e.Graphics.DrawString(NFecha, fontNFecha, Brushes.Black, leftMargin - 35, yPos + 80)

            NProforma = vbCrLf & vbCrLf & "X"
            Dim fontNProforma As New System.Drawing.Font("arial", 8, FontStyle.Regular)
            e.Graphics.DrawString(NProforma, fontNProforma, Brushes.Black, leftMargin + 250, yPos + 48)

            NNombre = vbCrLf & vbCrLf & TXTcOMPRADOR.Text
            Dim fontNNombre As New System.Drawing.Font("arial", 8, FontStyle.Regular)
            e.Graphics.DrawString(NNombre, fontNNombre, Brushes.Black, leftMargin - 37, yPos + 110)

            NDireccion = vbCrLf & vbCrLf & "-"
            Dim fontNDireccion As New System.Drawing.Font("arial", 8, FontStyle.Regular)
            e.Graphics.DrawString(NDireccion, fontNDireccion, Brushes.Black, leftMargin - 37, yPos + 130)


            'Dim NLinea As String = "----------------------------------------------------------" & vbLf
            ''separacion del primer titulo con la segunda linea
            'Dim fontNLinea As New System.Drawing.Font("Tahoma", 7, FontStyle.Bold)
            'e.Graphics.DrawString(NLinea, fontNLinea, _
            '                       Brushes.Black, leftMargin - 100, yPos + 10)

            'margen a la derecha de toda la lista
            X1 = PrintTikect.DefaultPageSettings.Margins.Left + 130 '85
            With PrintTikect.DefaultPageSettings
                pageWidth = (.PaperSize.Width) - (.Margins.Left + 10) - (.Margins.Right) '10
                If .Landscape Then
                    pageWidth = .PaperSize.Height - (.Margins.Top) - (.Margins.Bottom)
                End If
            End With
            'tamaño de la primera celda cantidad
            X2 = X1 + 17
            'tamaño de la segunda celda
            X3 = CInt(X2 + pageWidth * 3)

            X4 = X1 + 5
            X5 = X1 + 20

            W1 = (X2 - X1)
            W2 = (X3 - X2)
            W4 = (X3 - X2)
            W5 = (X3 - X2)
            W3 = pageWidth - W1 - W2

            'If itm < lsvDetalle.Items.Count Then
            'ubicacion para abajo
            Y = PrintTikect.DefaultPageSettings.Margins.Top + 185
            Dim fontNColumna As New System.Drawing.Font("arial", 8, FontStyle.Bold)
            ' Draw the column headers at the top of the page
            'ubicacion de las columnas para la izquierda
            'e.Graphics.DrawString("Cant", fontNColumna, Brushes.Black, X1 - 187, Y + 5)
            'e.Graphics.DrawString("Producto", fontNColumna, Brushes.Black, X2 - 175, Y + 5)
            'e.Graphics.DrawString("P.U.", fontNColumna, Brushes.Black, X3 - 175, Y + 5)
            'e.Graphics.DrawString("Total", fontNColumna, Brushes.Black, X4 + 2, Y + 5)
            ' Advance the Y coordinate for the first text line on the printout
            Y = Y + 20
            'End If
            Dim ii As Integer = 0
            Dim ultimaFila As Integer = 0

            For Each i In listaproforma 'dgvCompra.Table.Records

                'If (MaxImpresion >= 1) Then
                ' extract each item's text into the str variable
                Dim str As String
                str = (CDbl(i.monto1))

                e.Graphics.DrawString(str, fontNCabecera, Brushes.Black, X1 - 180, Y)

                Dim nroCaracteres = i.nombreItem.Trim.Length

                If nroCaracteres >= 27 Then
                    str = i.nombreItem.Substring(0, 27).ToString()
                Else
                    str = i.nombreItem
                End If

                Dim R As New RectangleF(X2 - 175, Y, W2, 80)
                e.Graphics.DrawString(str, fontNCabecera, Brushes.Black, R)

                Dim lines, cols As Integer
                e.Graphics.MeasureString(str, fontNCabecera, New SizeF(W2, 50), New StringFormat, cols, lines)
                Dim Yc As Integer ' subitm As Integer
                Yc = Y

                str = Math.Round(CDec(i.importeMN) / CDbl(i.monto1), 2)
                Dim R2 As New RectangleF(X4 + 40, Y, W4, 80)
                e.Graphics.DrawString(CDec(str).ToString("N2"), fontNCabecera, Brushes.Black, R2)

                str = Math.Round(CDec(i.importeMN), 2)
                Dim R3 As New RectangleF(X5 + 80, Y, W5, 80)
                e.Graphics.DrawString(CDec(str).ToString("N2"), fontNCabecera, Brushes.Black, R3)

                '  Dim conteo As Integer

                'For subitm = 1 To 1
                '    str = i.nombreItem
                '    'str = i.SubItems(subitm).Text
                '    'conteo = 0
                '    conteo = (str.Length / 2)
                '    Dim strformat As New StringFormat
                '    strformat.Trimming = StringTrimming.EllipsisCharacter
                '    Yc = Yc + fontNCabecera.Height + 2
                'Next
                Y = Y + lines * fontNCabecera.Height + 10 ' + (conteo + 2)
                Y = Math.Max(Y, Yc)

                With PrintTikect.DefaultPageSettings
                    If (Not e.PageSettings.Landscape And (Y > 0.95 * (.PaperSize.Height - .Margins.Bottom))) Or
                             (e.PageSettings.Landscape And (Y > 0.95 * (.PaperSize.Width - .Margins.Bottom))) Then
                        e.HasMorePages = True
                        ii += 1
                        Exit Sub
                    Else
                        ii += 1
                        e.HasMorePages = False
                    End If
                End With
                'End If

                'MaxImpresion = MaxImpresion - 1
            Next

            Dim NTotalPagar As String = vbCrLf & vbCrLf & listaproforma.Sum(Function(o) o.importeMN).GetValueOrDefault
            Dim fontNTotalPagar As New System.Drawing.Font("Ebrima", 9, FontStyle.Bold)
            e.Graphics.DrawString(NTotalPagar, fontNTotalPagar, Brushes.Black, leftMargin + 220, Y + 210)

            'oRIGINAL FORMATO

            'NFecha = vbCrLf & vbCrLf & DateTime.Now
            'Dim fontNFecha As New System.Drawing.Font("Tahoma", 8, FontStyle.Regular)
            'e.Graphics.DrawString(NFecha, fontNFecha, Brushes.Black, leftMargin + 5, yPos - 0)

            'NProforma = vbCrLf & vbCrLf & "X"
            'Dim fontNProforma As New System.Drawing.Font("Tahoma", 8, FontStyle.Regular)
            'e.Graphics.DrawString(NProforma, fontNProforma, Brushes.Black, leftMargin + 270, yPos - 30)

            'NNombre = vbCrLf & vbCrLf & "MAYKOL SANCGHEZ CORIS"
            'Dim fontNNombre As New System.Drawing.Font("Tahoma", 8, FontStyle.Regular)
            'e.Graphics.DrawString(NNombre, fontNNombre, Brushes.Black, leftMargin - 10, yPos + 35)

            'NDireccion = vbCrLf & vbCrLf & "CALLE REAL"
            'Dim fontNDireccion As New System.Drawing.Font("Tahoma", 8, FontStyle.Regular)
            'e.Graphics.DrawString(NDireccion, fontNDireccion, Brushes.Black, leftMargin - 10, yPos + 55)


            'Dim NLinea As String = "----------------------------------------------------------" & vbLf
            'separacion del primer titulo con la segunda linea
            ''Dim fontNLinea As New System.Drawing.Font("Tahoma", 7, FontStyle.Bold)
            ''e.Graphics.DrawString(NLinea, fontNLinea, _
            ''                       Brushes.Black, leftMargin - 100, yPos + 10)

            ''margen a la derecha de toda la lista
            'X1 = PrintTikect.DefaultPageSettings.Margins.Left + 150 '85
            'With PrintTikect.DefaultPageSettings
            '    pageWidth = (.PaperSize.Width) - (.Margins.Left + 10) - (.Margins.Right) '10
            '    If .Landscape Then
            '        pageWidth = .PaperSize.Height - (.Margins.Top) - (.Margins.Bottom)
            '    End If
            'End With
            ''tamaño de la primera celda cantidad
            'X2 = X1 + 17
            ''tamaño de la segunda celda
            'X3 = CInt(X2 + pageWidth * 3)

            'X4 = X1 + 5
            'X5 = X1 + 20

            'W1 = (X2 - X1)
            'W2 = (X3 - X2)
            'W4 = (X3 - X2)
            'W5 = (X3 - X2)
            'W3 = pageWidth - W1 - W2

            ''If itm < lsvDetalle.Items.Count Then
            ''ubicacion para abajo
            'Y = PrintTikect.DefaultPageSettings.Margins.Top + 100
            'Dim fontNColumna As New System.Drawing.Font("Tahoma", 7, FontStyle.Bold)
            '' Draw the column headers at the top of the page
            ''ubicacion de las columnas para la izquierda
            'e.Graphics.DrawString("Cant", fontNColumna, Brushes.Black, X1 - 187, Y + 5)
            'e.Graphics.DrawString("Producto", fontNColumna, Brushes.Black, X2 - 175, Y + 5)
            'e.Graphics.DrawString("P.U.", fontNColumna, Brushes.Black, X3 - 175, Y + 5)
            'e.Graphics.DrawString("Total", fontNColumna, Brushes.Black, X4 + 2, Y + 5)
            '' Advance the Y coordinate for the first text line on the printout
            'Y = Y + 20
            ''End If
            'Dim ii As Integer = 0
            'Dim ultimaFila As Integer = 0

            'For Each i As Record In dgvCompra.Table.Records

            '    ' extract each item's text into the str variable
            '    Dim str As String
            '    str = (CDbl(i.GetValue("1")))

            '    e.Graphics.DrawString(str, fontNCabecera, Brushes.Black, X1 - 180, Y)

            '    str = i.GetValue("2")
            '    Dim R As New RectangleF(X2 - 175, Y, W2, 80)
            '    e.Graphics.DrawString(str, fontNCabecera, Brushes.Black, R)

            '    Dim lines, cols As Integer
            '    e.Graphics.MeasureString(str, fontNCabecera, New SizeF(W2, 50), New StringFormat, cols, lines)
            '    Dim subitm As Integer, Yc As Integer
            '    Yc = Y

            '    str = Math.Round(CDec(i.GetValue("3")) / CDbl(i.GetValue("1")), 2)
            '    Dim R2 As New RectangleF(X4 + 40, Y, W4, 80)
            '    e.Graphics.DrawString(CDec(str).ToString("N2"), fontNCabecera, Brushes.Black, R2)

            '    str = Math.Round(CDec(i.GetValue("3")), 2)
            '    Dim R3 As New RectangleF(X5 + 80, Y, W5, 80)
            '    e.Graphics.DrawString(CDec(str).ToString("N2"), fontNCabecera, Brushes.Black, R3)

            '    Dim conteo As Integer

            '    For subitm = 1 To 1
            '        str = i.GetValue("2")
            '        'str = i.SubItems(subitm).Text
            '        'conteo = 0
            '        conteo = (str.Length / 2)
            '        Dim strformat As New StringFormat
            '        strformat.Trimming = StringTrimming.EllipsisCharacter
            '        Yc = Yc + fontNCabecera.Height + 2
            '    Next
            '    Y = Y + lines * fontNCabecera.Height + (conteo + 2)
            '    Y = Math.Max(Y, Yc)

            '    With PrintTikect.DefaultPageSettings
            '        If (Not e.PageSettings.Landscape And (Y > 0.95 * (.PaperSize.Height - .Margins.Bottom))) Or
            '         (e.PageSettings.Landscape And (Y > 0.95 * (.PaperSize.Width - .Margins.Bottom))) Then
            '            e.HasMorePages = True
            '            ii += 1
            '            Exit Sub
            '        Else
            '            ii += 1
            '            e.HasMorePages = False
            '        End If
            '    End With

            'Next

            e.HasMorePages = False


        End If



    End Sub

    Private Sub imprimir(ByVal esPreview As Boolean)

        ' imprimir o mostrar el PrintPreview
        '
        If prtSettings Is Nothing Then
            prtSettings = New PrinterSettings
        End If
        '
        'If chkSelAntes.Checked Then
        If seleccionarImpresora() = False Then Return
        'End If
        '

        'For Each item In dgvCompra.Table.Records
        '    listaproforma.Add(item)
        'Next


        If prtDoc Is Nothing Then
            prtDoc = New PrintDocument
            AddHandler prtDoc.PrintPage, AddressOf prt_PrintPageSinRuc

        End If
        '
        ' resetear la línea actual
        lineaActual = 0
        '
        ' la configuración a usar en la impresión
        prtDoc.PrinterSettings = prtSettings
        '
        'If esPreview Then
        '    Dim prtPrev As New PrintPreviewDialog
        '    prtPrev.PrintPreviewControl.Zoom = 1.0
        '    prtPrev.Document = prtDoc
        '    prtPrev.Text = "Previsualizar datos de Ticket" & Título
        '    DirectCast(prtPrev, Form).WindowState = FormWindowState.Maximized
        '    prtPrev.ShowDialog()
        'Else
        prtDoc.Print()
        'End If
    End Sub

    Private Function seleccionarImpresora() As Boolean
        Dim prtDialog As New PrintDialog
        If prtSettings Is Nothing Then
            prtSettings = New PrinterSettings
        End If

        'SELECCION DE IMPRESORA
        'With prtDialog
        '    .AllowPrintToFile = False
        '    .AllowSelection = False
        '    .AllowSomePages = False
        '    .PrintToFile = False
        '    .ShowHelp = False
        '    .ShowNetwork = True

        '    .PrinterSettings = prtSettings

        '    If .ShowDialog() = DialogResult.OK Then
        '        prtSettings = .PrinterSettings
        '    Else
        '        Return False
        '    End If

        'End With
        Return (True)
    End Function

    Sub imprimirTicketMatricial(intIdDocumento As Integer)
        Dim contador As Integer = 1
        Dim contacto As Integer = dgvCompra.Table.Records.Count
        Dim contadorMax As Integer = dgvCompra.Table.Records.Count
        Dim list As New List(Of List(Of Record))
        Dim entidadSA As New entidadSA
        Dim documentoSA As New documentoVentaAbarrotesSA
        Dim documentoDetSA As New documentoVentaAbarrotesDetSA
        Dim comprobante = documentoSA.GetUbicar_documentoventaAbarrotesPorID(intIdDocumento)
        Dim comprobanteDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(intIdDocumento)

        If (dgvCompra.Table.Records.Count = 1) Then
            listaproforma.Add(comprobanteDetalle(0))
            llenarDatos()
            imprimir(True)
            'prtDoc.PrinterSettings = prtSettings
            'prtDoc.Print()
            listaproforma = New List(Of documentoventaAbarrotesDet)
            contador = 0
        Else
            For Each item In comprobanteDetalle
                listaproforma.Add(item)
                If (contadorMax < contacto And contador = 14) Then
                    llenarDatos()
                    imprimir(True)
                    'prtDoc.PrinterSettings = prtSettings
                    'prtDoc.Print()
                    listaproforma = New List(Of documentoventaAbarrotesDet)
                    contador = 0
                ElseIf (contadorMax = 1 And contadorMax <> dgvCompra.Table.Records.Count) Then
                    llenarDatos()
                    imprimir(True)
                    contacto = 0
                    contador = 0
                    listaproforma = New List(Of documentoventaAbarrotesDet)
                End If
                contadorMax = contadorMax - 1
                contador = contador + 1
            Next
        End If


    End Sub
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        Me.WindowState = FormWindowState.Maximized
        Me.KeyPreview = True
        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(dgvCompra, False, False, 11.5F)
        'FormatoGridAvanzado(dgvCompra, False, False, 9)
        frmCanastaInventary = New frminfoInventario()
        ConfiguracionInicio()
        CalculoGridCeldas()
        GetTableGrid()
        threadClientes()
        bgCombos.RunWorkerAsync()
        dgvCompra.TableModel.CellModels.Add("LinkLabelCell", New LinkLabelCellModel(dgvCompra.TableModel))
        If ClipBoardDocumento IsNot Nothing Then
            If Not IsNothing(ClipBoardDocumento.documentoventaAbarrotes) Then
                btnPegadoEspecial.Visible = True
            End If
        End If

    End Sub

    Public Sub New(iddocumento As Integer)

        ' This call is required by the designer.
        InitializeComponent()
        Me.WindowState = FormWindowState.Maximized
        Me.KeyPreview = True
        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(dgvCompra, False, False, 11.5F)
        'FormatoGridAvanzado(dgvCompra, False, False)
        frmCanastaInventary = New frminfoInventario
        ConfiguracionInicio()
        CalculoGridCeldas()
        GetTableGrid()
        threadClientes()
        bgCombos.RunWorkerAsync()
        Tag = iddocumento
        bgVenta.RunWorkerAsync()
        dgvCompra.TableModel.CellModels.Add("LinkLabelCell", New LinkLabelCellModel(dgvCompra.TableModel))
    End Sub

#End Region

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

#Region "Class LinkLabel"
    Public Class LinkLabelCellModel
        Inherits GridStaticCellModel

        Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            MyBase.New(info, context)
        End Sub

        Public Sub New(ByVal grid As GridModel)
            MyBase.New(grid)
        End Sub

        Public Overrides Function CreateRenderer(ByVal control As GridControlBase) As GridCellRendererBase
            Return New LinkLabelCellRenderer(control, Me)
        End Function
    End Class

    Public Class LinkLabelCellRenderer
        Inherits GridStaticCellRenderer

        Private _isMouseDown As Boolean
        Private _drawHotLink As Boolean
        Private _hotColor As Color
        Private _visitedColor As Color
        Private _EXEname As String

        Public Sub New(ByVal grid As GridControlBase, ByVal cellModel As GridCellModelBase)
            MyBase.New(grid, cellModel)
            _isMouseDown = False
            _drawHotLink = False
            _hotColor = Color.Red
            _visitedColor = Color.Purple
            _EXEname = "iexplore.exe"
        End Sub

        Public Property VisitedLinkColor As Color
            Get
                Return _visitedColor
            End Get
            Set(ByVal value As Color)
                _visitedColor = value
            End Set
        End Property

        Public Property ActiveLinkColor As Color
            Get
                Return _hotColor
            End Get
            Set(ByVal value As Color)
                _hotColor = value
            End Set
        End Property

        Public Property EXEname As String
            Get
                Return _EXEname
            End Get
            Set(ByVal value As String)
                _EXEname = value
            End Set
        End Property

        Private Sub DrawLink(ByVal useHotColor As Boolean, ByVal rowIndex As Integer, ByVal colIndex As Integer)
            If useHotColor Then _drawHotLink = True
            Me.Grid.RefreshRange(GridRangeInfo.Cell(rowIndex, colIndex), GridRangeOptions.None)
            _drawHotLink = False
        End Sub

        Protected Overrides Sub OnMouseDown(ByVal rowIndex As Integer, ByVal colIndex As Integer, ByVal e As System.Windows.Forms.MouseEventArgs)
            MyBase.OnMouseDown(rowIndex, colIndex, e)
            DrawLink(True, rowIndex, colIndex)
            _isMouseDown = True
        End Sub

        Protected Overrides Sub OnMouseUp(ByVal rowIndex As Integer, ByVal colIndex As Integer, ByVal e As System.Windows.Forms.MouseEventArgs)
            MyBase.OnMouseUp(rowIndex, colIndex, e)
            Dim row, col As Integer
            Me.Grid.PointToRowCol(New Point(e.X, e.Y), row, col)

            If row = rowIndex AndAlso col = colIndex Then
                Dim style As GridStyleInfo = Me.Grid.Model(row, col)
                style.TextColor = VisitedLinkColor
            End If

            DrawLink(False, rowIndex, colIndex)
            _isMouseDown = False
        End Sub

        Protected Overrides Sub OnCancelMode(ByVal rowIndex As Integer, ByVal colIndex As Integer)
            MyBase.OnCancelMode(rowIndex, colIndex)
            _isMouseDown = False
            _drawHotLink = False
        End Sub

        Protected Overrides Function OnGetCursor(ByVal rowIndex As Integer, ByVal colIndex As Integer) As System.Windows.Forms.Cursor
            Dim pt As Point = Me.Grid.PointToClient(Cursor.Position)
            Dim row, col As Integer
            Me.Grid.PointToRowCol(pt, row, col)
            Return If((row = rowIndex AndAlso col = colIndex), Cursors.Hand, If((Me._isMouseDown), Cursors.No, MyBase.OnGetCursor(rowIndex, colIndex)))
        End Function

        Protected Overrides Function OnHitTest(ByVal rowIndex As Integer, ByVal colIndex As Integer, ByVal e As MouseEventArgs, ByVal controller As IMouseController) As Integer
            If controller IsNot Nothing AndAlso controller.Name = "OleDataSource" Then Return 0
            Return 1
        End Function

        Protected Overrides Sub OnDraw(ByVal g As System.Drawing.Graphics, ByVal clientRectangle As System.Drawing.Rectangle, ByVal rowIndex As Integer, ByVal colIndex As Integer, ByVal style As Syncfusion.Windows.Forms.Grid.GridStyleInfo)
            style.Font.Underline = True

            If _drawHotLink Then
                style.TextColor = ActiveLinkColor
            End If

            MyBase.OnDraw(g, clientRectangle, rowIndex, colIndex, style)
        End Sub

        Protected Overrides Sub OnMouseHoverEnter(ByVal rowIndex As Integer, ByVal colIndex As Integer)
            MyBase.OnMouseHoverEnter(rowIndex, colIndex)
            DrawLink(True, rowIndex, colIndex)
        End Sub

        Protected Overrides Sub OnMouseHoverLeave(ByVal rowIndex As Integer, ByVal colIndex As Integer, ByVal e As System.EventArgs)
            MyBase.OnMouseHoverLeave(rowIndex, colIndex, e)
            DrawLink(False, rowIndex, colIndex)
        End Sub
    End Class
#End Region

#Region "Methods"
    Sub GrabarProforma()
        Dim VentaSA As New documentoVentaAbarrotesSA
        Dim ndocumento As New documento()
        Dim DocCaja As New documento

        Dim ListaTotales As New List(Of totalesAlmacen)
        Dim docVentaSA As New documentoVentaAbarrotesSA

        Dim nDocumentoVenta As New documentoventaAbarrotes()
        Dim objDocumentoVentaDet As New documentoventaAbarrotesDet
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        Dim asientoSA As New AsientoSA
        ' Dim ListaAsiento As New List(Of asiento)
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento

        Dim ListaDetalle As New List(Of documentoventaAbarrotesDet)
        Dim proveedor As String
        Dim idProveedor As Integer

        dgvCompra.TableControl.CurrentCell.EndEdit()
        dgvCompra.TableControl.Table.TableDirty = True
        dgvCompra.TableControl.Table.EndEdit()
        proveedor = TXTcOMPRADOR.Text
        idProveedor = CInt(TXTcOMPRADOR.Tag)

        '-------------------------------------------------------------------------------------
        ndocumento = New documento
        ndocumento.Action = Business.Entity.BaseBE.EntityAction.INSERT
        ndocumento.idEmpresa = Gempresas.IdEmpresaRuc
        ndocumento.idCentroCosto = GEstableciento.IdEstablecimiento
        If IsNothing(GProyectos) Then
        Else
            ndocumento.idProyecto = GProyectos.IdProyectoActividad
        End If
        ndocumento.tipoDoc = GConfiguracion.TipoComprobante
        ndocumento.fechaProceso = txtFecha.Value
        ndocumento.nroDoc = GConfiguracion.Serie
        ndocumento.idOrden = Nothing ' Me.IdOrden
        ndocumento.moneda = "1"
        ndocumento.idEntidad = Val(idProveedor)
        ndocumento.entidad = proveedor
        ndocumento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        ndocumento.nrodocEntidad = txtruc.Text
        ndocumento.tipoOperacion = StatusTipoOperacion.VENTA
        ndocumento.usuarioActualizacion = usuario.IDUsuario
        ndocumento.fechaActualizacion = DateTime.Now

        nDocumentoVenta = New documentoventaAbarrotes With {
            .IdDocumentoCotizacion = False,
                 .TipoConfiguracion = If(GConfiguracion Is Nothing, Nothing, GConfiguracion.TipoConfiguracion),
                  .IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante),
                  .tipoOperacion = "01",
                  .codigoLibro = "14",
                  .tipoDocumento = GConfiguracion.TipoComprobante,
                  .idEmpresa = Gempresas.IdEmpresaRuc,
                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                  .fechaDoc = txtFecha.Value,
                  .fechaPeriodo = lblPerido.Text,
                  .serie = GConfiguracion.Serie,
                  .numeroDocNormal = Nothing,
                  .idCliente = idProveedor,
                  .nombrePedido = proveedor,
                  .moneda = "1",
                  .tasaIgv = TmpIGV,
                  .tipoCambio = TmpTipoCambio,
                  .bi01 = TotalesXcanbeceras.base1,
                  .bi02 = TotalesXcanbeceras.base2,
                  .igv01 = TotalesXcanbeceras.MontoIgv1,
                  .igv02 = TotalesXcanbeceras.MontoIgv2,
                  .bi01us = TotalesXcanbeceras.base1me,
                  .bi02us = TotalesXcanbeceras.base2me,
                  .igv01us = TotalesXcanbeceras.MontoIgv1me,
                  .igv02us = TotalesXcanbeceras.MontoIgv2me,
                  .ImporteNacional = TotalesXcanbeceras.TotalMN,
                  .ImporteExtranjero = TotalesXcanbeceras.TotalME,
                  .tipoVenta = TIPO_VENTA.COTIZACION,
                  .estadoCobro = TIPO_VENTA.PAGO.PENDIENTE_PAGO,
                  .glosa = txtGlosa.Text.Trim,
                  .usuarioActualizacion = usuario.IDUsuario,
                  .fechaActualizacion = DateTime.Now}
        ndocumento.documentoventaAbarrotes = nDocumentoVenta


        'REGISTRANDO LA GUIA DE REMISION
        'GuiaRemision(ndocumento)

        For Each r As Record In dgvCompra.Table.Records
            objDocumentoVentaDet = New documentoventaAbarrotesDet
            Select Case r.GetValue("valPago")
                Case "Pagado"
                    objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.COBRADO
                Case Else
                    objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.PENDIENTE_PAGO
            End Select
            objDocumentoVentaDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoVentaDet.IdEstablecimiento = GEstableciento.IdEstablecimiento ' almacenSA.GetUbicar_almacenPorID(i.Cells(24).Value()).idEstablecimiento
            objDocumentoVentaDet.FechaDoc = txtFecha.Value
            objDocumentoVentaDet.Serie = GConfiguracion.Serie
            objDocumentoVentaDet.NumDoc = Nothing
            objDocumentoVentaDet.TipoDoc = GConfiguracion.TipoComprobante
            If r.GetValue("tipoExistencia") = "GS" Then
                objDocumentoVentaDet.idAlmacenOrigen = Nothing
                objDocumentoVentaDet.tipoVenta = Nothing
            Else
                objDocumentoVentaDet.idAlmacenOrigen = Nothing 'CInt(r.GetValue("almacen"))
                objDocumentoVentaDet.tipoVenta = r.GetValue("tipoPrecio")
            End If
            objDocumentoVentaDet.establecimientoOrigen = GEstableciento.IdEstablecimiento
            objDocumentoVentaDet.cuentaOrigen = Nothing
            objDocumentoVentaDet.idItem = r.GetValue("idProducto")
            objDocumentoVentaDet.DetalleItem = r.GetValue("item")
            objDocumentoVentaDet.tipoExistencia = r.GetValue("tipoExistencia")
            objDocumentoVentaDet.destino = r.GetValue("gravado")
            objDocumentoVentaDet.unidad1 = r.GetValue("um")
            If CDec(r.GetValue("cantidad")) <= 0 Then
                MessageBoxAdv.Show("Debe ingresar un cantidad mayor a cero.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Question)
                Exit Sub
            End If

            If CDec(r.GetValue("totalmn")) <= 0 Then
                MessageBoxAdv.Show("El importe de venta debe ser mayor a cero.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Question)
                Exit Sub
            End If

            objDocumentoVentaDet.monto1 = CDec(r.GetValue("cantidad"))
            objDocumentoVentaDet.unidad2 = Nothing
            objDocumentoVentaDet.monto2 = Nothing 'i.Cells(31).Value()
            objDocumentoVentaDet.precioUnitario = CDec(r.GetValue("pumn"))
            objDocumentoVentaDet.precioUnitarioUS = CDec(r.GetValue("pume"))
            objDocumentoVentaDet.importeMN = CDec(r.GetValue("totalmn"))
            objDocumentoVentaDet.importeME = CDec(r.GetValue("totalme"))
            objDocumentoVentaDet.descuentoMN = 0
            objDocumentoVentaDet.descuentoME = 0

            objDocumentoVentaDet.montokardex = CDec(r.GetValue("vcmn"))
            objDocumentoVentaDet.montoIsc = 0
            objDocumentoVentaDet.montoIgv = CDec(r.GetValue("igvmn"))
            objDocumentoVentaDet.otrosTributos = 0
            '**********************************************************************************
            objDocumentoVentaDet.montokardexUS = CDec(r.GetValue("vcme"))
            objDocumentoVentaDet.montoIscUS = 0
            objDocumentoVentaDet.montoIgvUS = CDec(r.GetValue("igvme"))
            objDocumentoVentaDet.otrosTributosUS = 0
            '  objDocumentoVentaDet.PreEvento = i.Cells(25).Value()
            objDocumentoVentaDet.estadoMovimiento = "NO" 'ENTREGADO/COBRADO
            '**********************************************************************************
            objDocumentoVentaDet.importeMNK = CDec(r.GetValue("puKardex"))
            objDocumentoVentaDet.importeMEK = CDec(r.GetValue("pukardeme"))
            objDocumentoVentaDet.fechaVcto = Nothing
            objDocumentoVentaDet.salidaCostoMN = CDec(r.GetValue("costoMN")) ' CDec(i.Cells(6).Value()) * CDec(i.Cells(5).Value())
            objDocumentoVentaDet.salidaCostoME = CDec(r.GetValue("costoME")) 'CDec(i.Cells(28).Value()) * CDec(i.Cells(5).Value())
            objDocumentoVentaDet.categoria = Nothing
            objDocumentoVentaDet.preEvento = Nothing
            objDocumentoVentaDet.usuarioModificacion = usuario.IDUsuario
            objDocumentoVentaDet.fechaModificacion = Date.Now

            objDocumentoVentaDet.Glosa = txtGlosa.Text.Trim
            ListaDetalle.Add(objDocumentoVentaDet)
        Next
        ndocumento.documentoventaAbarrotes.documentoventaAbarrotesDet = ListaDetalle
        Dim cod = VentaSA.GrabarCotizacion(ndocumento)
        MessageBox.Show("Proforma registrada", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        LimpiarControles()
        Alert = New Alert("Proforma registrada", alertType.success)
        Alert.TopMost = True
        Alert.Show()

        'Dim f As New FormImpresionNuevo
        'f.DocumentoID = cod
        'f.StartPosition = FormStartPosition.CenterScreen
        'f.Show(Me)
        VentaSA.GetActualizarImpresion(New documentoventaAbarrotes With {.idDocumento = cod})
        With FormCanastaTotalesServVer2
            .GridTotales.Table.Records.DeleteAll()
            .txtFiltrar.Clear()
        End With
        ToolStrip5.Focus()
        ToolStripButton1.Select()

    End Sub


    Private Sub CalculoGridCeldas()
        Dim expField0 As ExpressionFieldDescriptor = New ExpressionFieldDescriptor("totalmn", "([cantidad]*[pumn])", GetType(System.Double))
        Dim expField1 As ExpressionFieldDescriptor = New ExpressionFieldDescriptor("totalme", "([cantidad]*[pume])", GetType(System.Double))

        dgvCompra.TableDescriptor.ExpressionFields.AddRange(New ExpressionFieldDescriptor() {expField0, expField1})
    End Sub

    'Private Sub SumarioColumnas()
    '    Dim scd1 As New GridSummaryColumnDescriptor("Freight", SummaryType.Int32Aggregate, "Freight", "Total ={Count}")

    '    'Create summary column descriptor 2
    '    Dim scd2 As New GridSummaryColumnDescriptor("Freight", SummaryType.Int32Aggregate, "Freight", "Avg ={Average:#.00}")
    '    scd2.Appearance.AnySummaryCell.Interior = New BrushInfo(Color.LavenderBlush)

    '    Dim srd1 As New GridSummaryRowDescriptor()
    '    'Adding the summary columns into the summary row descriptor
    '    srd1.SummaryColumns.Add(scd1)

    '    Dim srd2 As New GridSummaryRowDescriptor()
    '    'Adding the summary columns into the summary row descriptor
    '    srd2.SummaryColumns.Add(scd2)
    '    srd1.Appearance.AnySummaryCell.Interior = New BrushInfo(Color.FromArgb(255, 232, 162))
    '    srd2.Appearance.AnySummaryCell.Interior = New BrushInfo(Color.FromArgb(255, 232, 162))
    '    Me.dgvCompra.TableDescriptor.SummaryRows.Add(srd1)
    '    Me.dgvCompra.TableDescriptor.SummaryRows.Add(srd2)

    'End Sub

    Sub ImprimirTicketGladis(intIdDocumento As Integer)
        Dim gravMN As Decimal = 0
        Dim gravME As Decimal = 0
        Dim ExoMN As Decimal = 0
        Dim ExoME As Decimal = 0
        Dim InaMN As Decimal = 0
        Dim InaME As Decimal = 0
        Dim ticket As New CrearTicket()

        '  Dim r As Record = dgPedidos.Table.CurrentRecord
        Dim entidadSA As New entidadSA
        Dim documentoSA As New documentoVentaAbarrotesSA
        Dim documentoDetSA As New documentoVentaAbarrotesDetSA
        Dim comprobante = documentoSA.GetUbicar_documentoventaAbarrotesPorID(intIdDocumento)
        Dim comprobanteDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(intIdDocumento)


        'Ya podemos usar todos sus metodos
        ticket.AbreCajon()
        'Para abrir el cajon de dinero.
        'De aqui en adelante pueden formar su ticket a su gusto... Les muestro un ejemplo

        'Datos de la cabecera del Ticket.
        ticket.TextoCentro(Gempresas.NomEmpresa)
        'ticket.TextoCentro("ERM NEGOCIOS SAC.")
        'ticket.TextoCentro("JR. GN. SANTA CRUZ 481 INT-1506")
        'ticket.TextoCentro("JESUS MARIA - LIMA PERU")
        'ticket.TextoCentro("SUC: JR.SEBASTIAN LORENTE 199 TAMBO-HYO.")
        ticket.TextoCentro("RUC. " & Gempresas.IdEmpresaRuc)
        ticket.TextoCentro("JR. RICARDO PALMA N° 881 CHILCA - HUANCAYO")
        ticket.TextoCentro("TEF. 966557413")
        '   ticket.TextoIzquierda("EMAIL: cmcmarce14@gmail.com")
        'Es el mio por si me quieren contactar ...
        ticket.TextoIzquierda("")
        ticket.lineasHorizontales()
        Select Case comprobante.tipoDocumento
            Case "12.1"
                'ticket.TextoExtremos("Caja # 1", "Ticket boleta # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                ticket.TextoIzquierda("Ticket Boleta # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
            Case "12.2"
                '  ticket.TextoExtremos("Caja # 1", "Ticket factura # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                ticket.TextoIzquierda("Ticket Factura # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)

            Case Else
                ticket.TextoIzquierda("Ticket nota # " & comprobante.numeroVenta)
        End Select

        'Sub cabecera.
        'ticket.TextoIzquierda("")

        If comprobante.idCliente <> 0 Then
            Dim entidad = entidadSA.UbicarEntidadPorID(comprobante.idCliente).FirstOrDefault
            Dim NBoletaElectronica As String = "Cliente: " & entidad.nombreCompleto
            ticket.TextoIzquierda(NBoletaElectronica)
            If entidad.nrodoc.Trim.Length = 11 Then
                ticket.TextoIzquierda("RUC.: " & entidad.nrodoc)
            ElseIf entidad.nrodoc.Trim.Length = 8 Then
                ticket.TextoIzquierda("DNI.: " & entidad.nrodoc)
            Else
                ticket.TextoIzquierda("NRO DOC.: " & entidad.nrodoc)
            End If

        Else
            Dim NBoletaElectronica As String = "Cliente: " & comprobante.nombrePedido
            ticket.TextoIzquierda(NBoletaElectronica)

        End If
        '    ticket.TextoIzquierda("COD. MAQUINA REG.: USAFIKA12050121")
        'ticket.TextoIzquierda("")
        ticket.TextoExtremos("FECHA: " + comprobante.fechaDoc.Value.ToShortDateString(), "HORA: " + comprobante.fechaDoc.Value.ToShortTimeString())
        ticket.lineasHorizontales()

        'Articulos a vender.
        ticket.EncabezadoVentaV2()
        'NOMBRE DEL ARTICULO, CANT, PRECIO, IMPORTE
        'ticket.lineasAsteriscos()
        ticket.lineasHorizontales()
        'Si tiene una DataGridView donde estan sus articulos a vender pueden usar esta manera para agregarlos al ticket.
        'foreach (DataGridViewRow fila in dgvLista.Rows)//dgvLista es el nombre del datagridview
        '{
        'ticket.AgregaArticulo(fila.Cells[2].Value.ToString(), int.Parse(fila.Cells[5].Value.ToString()),
        'decimal.Parse(fila.Cells[4].Value.ToString()), decimal.Parse(fila.Cells[6].Value.ToString()));
        '}

        For Each i In comprobanteDetalle

            Select Case i.destino
                Case OperacionGravada.Grabado
                    gravMN += CDec(i.montokardex)
                    gravME += CDec(i.montokardexUS)

                Case OperacionGravada.Exonerado
                    ExoMN += CDec(i.montokardex)
                    ExoME += CDec(i.montokardexUS)

                Case OperacionGravada.Inafecto
                    InaMN += CDec(i.montokardex)
                    InaME += CDec(i.montokardexUS)
            End Select

            ticket.AgregaArticuloV2(i.nombreItem, String.Format("{0:0.00}", i.monto1), String.Format("{0:0.00}", i.importeMN / i.monto1), i.importeMN)
        Next
        ticket.lineasIgual()

        'Resumen de la venta. Sólo son ejemplos
        'ticket.AgregarTotales("         TOTAL.........$", comprobante.ImporteNacional)

        'ticket.AgregarTotales("         EXONERADA...S/.", ExoMN)
        'ticket.AgregarTotales("         INAFECTA....S/.", InaMN)
        'ticket.AgregarTotales("         GRAVADA.....S/.", gravMN)
        'ticket.AgregarTotales("         IGV.........S/.", comprobante.igv01)
        ''La M indica que es un decimal en C#
        ticket.AgregarTotales("         TOTAL.......S/.", comprobante.ImporteNacional)
        'ticket.TextoIzquierda("")
        'ticket.AgregarTotales("         EFECTIVO....S/.", comprobante.ImporteNacional)
        ''ticket.AgregarTotales("         CAMBIO........$", 0)

        'Texto final del Ticket.
        'ticket.TextoIzquierda("")
        'ticket.TextoIzquierda("ARTICULOS VENDIDOS: " & comprobanteDetalle.Count)
        ticket.TextoIzquierda("")
        ticket.TextoCentro("¡GRACIAS POR SU COMPRA!")
        ticket.CortaTicket()

        ticket.ImprimirTicket("POS-80C")
        ' ticket.ImprimirTicket("BIXOLON SRP-270")
        'Nombre de la impresora ticketera

    End Sub

    Sub ImprimirTicket(intIdDocumento As Integer)
        Dim gravMN As Decimal = 0
        Dim gravME As Decimal = 0
        Dim ExoMN As Decimal = 0
        Dim ExoME As Decimal = 0
        Dim InaMN As Decimal = 0
        Dim InaME As Decimal = 0
        Dim ticket As New CrearTicket()

        '  Dim r As Record = dgPedidos.Table.CurrentRecord
        Dim entidadSA As New entidadSA
        Dim documentoSA As New documentoVentaAbarrotesSA
        Dim documentoDetSA As New documentoVentaAbarrotesDetSA
        Dim comprobante = documentoSA.GetUbicar_documentoventaAbarrotesPorID(intIdDocumento)
        Dim comprobanteDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(intIdDocumento)


        'Ya podemos usar todos sus metodos
        ticket.AbreCajon()
        'Para abrir el cajon de dinero.
        'De aqui en adelante pueden formar su ticket a su gusto... Les muestro un ejemplo

        'Datos de la cabecera del Ticket.
        ticket.TextoCentro("REPRESENTACIONES PIEROS")
        'ticket.TextoCentro("ERM NEGOCIOS SAC.")
        'ticket.TextoCentro("JR. GN. SANTA CRUZ 481 INT-1506")
        'ticket.TextoCentro("JESUS MARIA - LIMA PERU")
        'ticket.TextoCentro("SUC: JR.SEBASTIAN LORENTE 199 TAMBO-HYO.")
        ticket.TextoCentro("RUC. " & "20486529131")
        '   ticket.TextoIzquierda("EMAIL: cmcmarce14@gmail.com")
        'Es el mio por si me quieren contactar ...
        ticket.TextoIzquierda("")
        Select Case comprobante.tipoDocumento
            Case "12.1"
                'ticket.TextoExtremos("Caja # 1", "Ticket boleta # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                ticket.TextoIzquierda("Ticket Boleta # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
            Case "12.2"
                '  ticket.TextoExtremos("Caja # 1", "Ticket factura # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                ticket.TextoIzquierda("Ticket Factura # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)

            Case Else
                ticket.TextoIzquierda("Ticket nota # " & comprobante.numeroVenta)
        End Select


        ticket.lineasHorizontales()
        'Sub cabecera.
        ticket.TextoIzquierda("")

        If comprobante.idCliente <> 0 Then
            Dim entidad = entidadSA.UbicarEntidadPorID(comprobante.idCliente).FirstOrDefault
            Dim NBoletaElectronica As String = "Cliente: " & entidad.nombreCompleto
            ticket.TextoIzquierda(NBoletaElectronica)
            If entidad.nrodoc.Trim.Length = 11 Then
                ticket.TextoIzquierda("RUC.: " & entidad.nrodoc)
            ElseIf entidad.nrodoc.Trim.Length = 8 Then
                ticket.TextoIzquierda("DNI.: " & entidad.nrodoc)
            Else
                ticket.TextoIzquierda("NRO DOC.: " & entidad.nrodoc)
            End If

        Else
            Dim NBoletaElectronica As String = "Cliente: " & comprobante.nombrePedido
            ticket.TextoIzquierda(NBoletaElectronica)

        End If
        '    ticket.TextoIzquierda("COD. MAQUINA REG.: USAFIKA12050121")
        ticket.TextoIzquierda("")
        ticket.TextoExtremos("FECHA: " + comprobante.fechaDoc.Value.ToShortDateString(), "HORA: " + comprobante.fechaDoc.Value.ToShortTimeString())
        ticket.lineasHorizontales()

        'Articulos a vender.
        ticket.EncabezadoVentaV2()
        'NOMBRE DEL ARTICULO, CANT, PRECIO, IMPORTE
        'ticket.lineasAsteriscos()
        ticket.lineasHorizontales()
        'Si tiene una DataGridView donde estan sus articulos a vender pueden usar esta manera para agregarlos al ticket.
        'foreach (DataGridViewRow fila in dgvLista.Rows)//dgvLista es el nombre del datagridview
        '{
        'ticket.AgregaArticulo(fila.Cells[2].Value.ToString(), int.Parse(fila.Cells[5].Value.ToString()),
        'decimal.Parse(fila.Cells[4].Value.ToString()), decimal.Parse(fila.Cells[6].Value.ToString()));
        '}

        For Each i In comprobanteDetalle

            Select Case i.destino
                Case OperacionGravada.Grabado
                    gravMN += CDec(i.montokardex)
                    gravME += CDec(i.montokardexUS)

                Case OperacionGravada.Exonerado
                    ExoMN += CDec(i.montokardex)
                    ExoME += CDec(i.montokardexUS)

                Case OperacionGravada.Inafecto
                    InaMN += CDec(i.montokardex)
                    InaME += CDec(i.montokardexUS)
            End Select

            ticket.AgregaArticuloV2(i.nombreItem, String.Format("{0:0.00}", i.monto1), String.Format("{0:0.00}", i.importeMN / i.monto1), i.importeMN)
        Next
        ticket.lineasIgual()

        'Resumen de la venta. Sólo son ejemplos
        'ticket.AgregarTotales("         TOTAL.........$", comprobante.ImporteNacional)

        'ticket.AgregarTotales("         EXONERADA...S/.", ExoMN)
        'ticket.AgregarTotales("         INAFECTA....S/.", InaMN)
        'ticket.AgregarTotales("         GRAVADA.....S/.", gravMN)
        'ticket.AgregarTotales("         IGV.........S/.", comprobante.igv01)
        'La M indica que es un decimal en C#
        ticket.AgregarTotales("         TOTAL.......S/.", comprobante.ImporteNacional)
        'ticket.TextoIzquierda("")
        'ticket.AgregarTotales("         EFECTIVO....S/.", comprobante.ImporteNacional)
        'ticket.AgregarTotales("         CAMBIO........$", 0)

        'Texto final del Ticket.
        'ticket.TextoIzquierda("")
        'ticket.TextoIzquierda("ARTICULOS VENDIDOS: " & comprobanteDetalle.Count)
        ticket.TextoIzquierda("")
        ticket.TextoCentro("¡GRACIAS POR SU COMPRA!")
        ticket.CortaTicket()

        ticket.ImprimirTicket("POS-80C")
        ' ticket.ImprimirTicket("BIXOLON SRP-270")
        'Nombre de la impresora ticketera

    End Sub

    'Sub ImprimirTicket(intIdDocumento As Integer)
    '    Dim gravMN As Decimal = 0
    '    Dim gravME As Decimal = 0
    '    Dim ExoMN As Decimal = 0
    '    Dim ExoME As Decimal = 0
    '    Dim InaMN As Decimal = 0
    '    Dim InaME As Decimal = 0
    '    Dim ticket As New CrearTicket()

    '    '  Dim r As Record = dgPedidos.Table.CurrentRecord
    '    Dim entidadSA As New entidadSA
    '    Dim documentoSA As New documentoVentaAbarrotesSA
    '    Dim documentoDetSA As New documentoVentaAbarrotesDetSA
    '    Dim comprobante = documentoSA.GetUbicar_documentoventaAbarrotesPorID(intIdDocumento)
    '    Dim comprobanteDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(intIdDocumento)


    '    'Ya podemos usar todos sus metodos
    '    ticket.AbreCajon()
    '    'Para abrir el cajon de dinero.
    '    'De aqui en adelante pueden formar su ticket a su gusto... Les muestro un ejemplo

    '    'Datos de la cabecera del Ticket.
    '    ticket.TextoCentro(Gempresas.NomEmpresa)
    '    'ticket.TextoCentro("ERM NEGOCIOS SAC.")
    '    'ticket.TextoCentro("JR. GN. SANTA CRUZ 481 INT-1506")
    '    'ticket.TextoCentro("JESUS MARIA - LIMA PERU")
    '    'ticket.TextoCentro("SUC: JR.SEBASTIAN LORENTE 199 TAMBO-HYO.")
    '    ticket.TextoCentro(Gempresas.IdEmpresaRuc)
    '    '   ticket.TextoIzquierda("EMAIL: cmcmarce14@gmail.com")
    '    'Es el mio por si me quieren contactar ...
    '    ticket.TextoIzquierda("")
    '    Select Case comprobante.tipoDocumento
    '        Case "12.1"
    '            'ticket.TextoExtremos("Caja # 1", "Ticket boleta # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
    '            ticket.TextoIzquierda("Ticket Boleta # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
    '        Case "12.2"
    '            '  ticket.TextoExtremos("Caja # 1", "Ticket factura # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
    '            ticket.TextoIzquierda("Ticket Factura # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)

    '        Case Else
    '            ticket.TextoIzquierda("Ticket nota # " & comprobante.numeroVenta)
    '    End Select


    '    ticket.lineasHorizontales()
    '    'Sub cabecera.
    '    ticket.TextoIzquierda("")

    '    If comprobante.idCliente <> 0 Then
    '        Dim entidad = entidadSA.UbicarEntidadPorID(comprobante.idCliente).FirstOrDefault
    '        Dim NBoletaElectronica As String = "Cliente: " & entidad.nombreCompleto
    '        ticket.TextoIzquierda(NBoletaElectronica)
    '        If entidad.nrodoc.Trim.Length = 11 Then
    '            ticket.TextoIzquierda("RUC.: " & entidad.nrodoc)
    '        ElseIf entidad.nrodoc.Trim.Length = 8 Then
    '            ticket.TextoIzquierda("DNI.: " & entidad.nrodoc)
    '        Else
    '            ticket.TextoIzquierda("NRO DOC.: " & entidad.nrodoc)
    '        End If

    '    Else
    '        Dim NBoletaElectronica As String = "Cliente: " & comprobante.nombrePedido
    '        ticket.TextoIzquierda(NBoletaElectronica)

    '    End If
    '    '    ticket.TextoIzquierda("COD. MAQUINA REG.: USAFIKA12050121")
    '    ticket.TextoIzquierda("")
    '    ticket.TextoExtremos("FECHA: " + comprobante.fechaDoc.Value.ToShortDateString(), "HORA: " + comprobante.fechaDoc.Value.ToShortTimeString())
    '    ticket.lineasHorizontales()

    '    'Articulos a vender.
    '    ticket.EncabezadoVentaV2()
    '    'NOMBRE DEL ARTICULO, CANT, PRECIO, IMPORTE
    '    'ticket.lineasAsteriscos()
    '    ticket.lineasHorizontales()
    '    'Si tiene una DataGridView donde estan sus articulos a vender pueden usar esta manera para agregarlos al ticket.
    '    'foreach (DataGridViewRow fila in dgvLista.Rows)//dgvLista es el nombre del datagridview
    '    '{
    '    'ticket.AgregaArticulo(fila.Cells[2].Value.ToString(), int.Parse(fila.Cells[5].Value.ToString()),
    '    'decimal.Parse(fila.Cells[4].Value.ToString()), decimal.Parse(fila.Cells[6].Value.ToString()));
    '    '}

    '    For Each i In comprobanteDetalle

    '        Select Case i.destino
    '            Case OperacionGravada.Grabado
    '                gravMN += CDec(i.montokardex)
    '                gravME += CDec(i.montokardexUS)

    '            Case OperacionGravada.Exonerado
    '                ExoMN += CDec(i.montokardex)
    '                ExoME += CDec(i.montokardexUS)

    '            Case OperacionGravada.Inafecto
    '                InaMN += CDec(i.montokardex)
    '                InaME += CDec(i.montokardexUS)
    '        End Select

    '        ticket.AgregaArticuloV2(i.nombreItem, String.Format("{0:0.00}", i.monto1), String.Format("{0:0.00}", i.importeMN / i.monto1), i.importeMN)
    '    Next
    '    ticket.lineasIgual()

    '    'Resumen de la venta. Sólo son ejemplos
    '    'ticket.AgregarTotales("         TOTAL.........$", comprobante.ImporteNacional)

    '    ticket.AgregarTotales("         EXONERADA...S/.", ExoMN)
    '    ticket.AgregarTotales("         INAFECTA....S/.", InaMN)
    '    ticket.AgregarTotales("         GRAVADA.....S/.", gravMN)
    '    ticket.AgregarTotales("         IGV.........S/.", comprobante.igv01)
    '    'La M indica que es un decimal en C#
    '    ticket.AgregarTotales("         TOTAL.......S/.", comprobante.ImporteNacional)
    '    ticket.TextoIzquierda("")
    '    ticket.AgregarTotales("         EFECTIVO....S/.", comprobante.ImporteNacional)
    '    'ticket.AgregarTotales("         CAMBIO........$", 0)

    '    'Texto final del Ticket.
    '    ticket.TextoIzquierda("")
    '    ticket.TextoIzquierda("ARTICULOS VENDIDOS: " & comprobanteDetalle.Count)
    '    ticket.TextoIzquierda("")
    '    ticket.TextoCentro("¡GRACIAS POR SU COMPRA!")
    '    ticket.CortaTicket()

    '    ticket.ImprimirTicket("POS-80C")
    '    ' ticket.ImprimirTicket("BIXOLON SRP-270")
    '    'Nombre de la impresora ticketera

    'End Sub

    Sub ImprimirTicketAcumulado(intIdDocumento As Integer)
        Dim gravMN As Decimal = 0
        Dim gravME As Decimal = 0
        Dim ExoMN As Decimal = 0
        Dim ExoME As Decimal = 0
        Dim InaMN As Decimal = 0
        Dim InaME As Decimal = 0
        Dim ticket As New CrearTicket()

        '  Dim r As Record = dgPedidos.Table.CurrentRecord
        Dim entidadSA As New entidadSA
        Dim documentoSA As New documentoVentaAbarrotesSA
        Dim documentoDetSA As New documentoVentaAbarrotesDetSA
        Dim comprobante = documentoSA.GetUbicar_documentoventaAbarrotesPorID(intIdDocumento)
        Dim comprobanteDetalle = documentoDetSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(intIdDocumento)


        'Ya podemos usar todos sus metodos
        ticket.AbreCajon()
        'Para abrir el cajon de dinero.
        'De aqui en adelante pueden formar su ticket a su gusto... Les muestro un ejemplo

        'Datos de la cabecera del Ticket.
        ticket.TextoCentro(Gempresas.NomEmpresa)
        'ticket.TextoCentro("ERM NEGOCIOS SAC.")
        'ticket.TextoCentro("JR. GN. SANTA CRUZ 481 INT-1506")
        'ticket.TextoCentro("JESUS MARIA - LIMA PERU")
        'ticket.TextoCentro("SUC: JR.SEBASTIAN LORENTE 199 TAMBO-HYO.")
        ticket.TextoCentro(Gempresas.IdEmpresaRuc)
        '   ticket.TextoIzquierda("EMAIL: cmcmarce14@gmail.com")
        'Es el mio por si me quieren contactar ...
        ticket.TextoIzquierda("")
        Select Case comprobante.tipoDocumento
            Case "12.1"
                'ticket.TextoExtremos("Caja # 1", "Ticket boleta # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                ticket.TextoIzquierda("Ticket Boleta # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
            Case "12.2"
                '  ticket.TextoExtremos("Caja # 1", "Ticket factura # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                ticket.TextoIzquierda("Ticket Factura # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)

            Case Else
                ticket.TextoIzquierda("Ticket nota # " & comprobante.numeroVenta)
        End Select


        ticket.lineasHorizontales()
        'Sub cabecera.
        ticket.TextoIzquierda("")

        If comprobante.idCliente <> 0 Then
            Dim entidad = entidadSA.UbicarEntidadPorID(comprobante.idCliente).FirstOrDefault
            Dim NBoletaElectronica As String = "Cliente: " & entidad.nombreCompleto
            ticket.TextoIzquierda(NBoletaElectronica)
            If entidad.nrodoc.Trim.Length = 11 Then
                ticket.TextoIzquierda("RUC.: " & entidad.nrodoc)
            ElseIf entidad.nrodoc.Trim.Length = 8 Then
                ticket.TextoIzquierda("DNI.: " & entidad.nrodoc)
            Else
                ticket.TextoIzquierda("NRO DOC.: " & entidad.nrodoc)
            End If

        Else
            Dim NBoletaElectronica As String = "Cliente: " & comprobante.nombrePedido
            ticket.TextoIzquierda(NBoletaElectronica)

        End If
        ticket.TextoIzquierda("COD. MAQUINA REG.: USAFIKA12050121")
        ticket.TextoIzquierda("")
        ticket.TextoExtremos("FECHA: " + comprobante.fechaDoc.Value.ToShortDateString(), "HORA: " + comprobante.fechaDoc.Value.ToShortTimeString())
        ticket.lineasHorizontales()

        'Articulos a vender.
        ticket.EncabezadoVentaV2()
        'NOMBRE DEL ARTICULO, CANT, PRECIO, IMPORTE
        'ticket.lineasAsteriscos()
        ticket.lineasHorizontales()
        'Si tiene una DataGridView donde estan sus articulos a vender pueden usar esta manera para agregarlos al ticket.
        'foreach (DataGridViewRow fila in dgvLista.Rows)//dgvLista es el nombre del datagridview
        '{
        'ticket.AgregaArticulo(fila.Cells[2].Value.ToString(), int.Parse(fila.Cells[5].Value.ToString()),
        'decimal.Parse(fila.Cells[4].Value.ToString()), decimal.Parse(fila.Cells[6].Value.ToString()));
        '}

        Dim nuevoDetalle = (From member In comprobanteDetalle
                            Group member By keys = New With
                           {
                                Key member.destino,
                                Key member.idItem,
                                Key member.nombreItem
                           }
                                Into Group
                            Select New With
                                {
                                .idItem = keys.idItem,
                                .destino = keys.destino,
                                .nombreItem = keys.nombreItem,
                                .sumCantidad = Group.Sum(Function(x) x.monto1),
                                .SumMonto = Group.Max(Function(x) x.importeMN)
                                }).ToList

        For Each i In nuevoDetalle

            'Select Case i.destino
            '    Case OperacionGravada.Grabado
            '        gravMN += CDec(i.montokardex)
            '        gravME += CDec(i.montokardexUS)

            '    Case OperacionGravada.Exonerado
            '        ExoMN += CDec(i.montokardex)
            '        ExoME += CDec(i.montokardexUS)

            '    Case OperacionGravada.Inafecto
            '        InaMN += CDec(i.montokardex)
            '        InaME += CDec(i.montokardexUS)
            'End Select

            ticket.AgregaArticuloV2(
                i.nombreItem,
                String.Format("{0:0.00}", i.sumCantidad.GetValueOrDefault),
                String.Format("{0:0.00}", i.SumMonto / i.sumCantidad),
                i.SumMonto)
        Next
        ticket.lineasIgual()

        'Resumen de la venta. Sólo son ejemplos
        'ticket.AgregarTotales("         TOTAL.........$", comprobante.ImporteNacional)

        ticket.AgregarTotales("         EXONERADA...S/.", ExoMN)
        ticket.AgregarTotales("         INAFECTA....S/.", InaMN)
        ticket.AgregarTotales("         GRAVADA.....S/.", gravMN)
        ticket.AgregarTotales("         IGV.........S/.", comprobante.igv01)
        'La M indica que es un decimal en C#
        ticket.AgregarTotales("         TOTAL.......S/.", comprobante.ImporteNacional)
        ticket.TextoIzquierda("")
        ticket.AgregarTotales("         EFECTIVO....S/.", comprobante.ImporteNacional)
        'ticket.AgregarTotales("         CAMBIO........$", 0)

        'Texto final del Ticket.
        ticket.TextoIzquierda("")
        ticket.TextoIzquierda("ARTICULOS VENDIDOS: " & nuevoDetalle.Count)
        ticket.TextoIzquierda("")
        ticket.TextoCentro("¡GRACIAS POR SU COMPRA!")
        ticket.CortaTicket()

        ticket.ImprimirTicket("POS-80C")
        ' ticket.ImprimirTicket("BIXOLON SRP-270")
        'Nombre de la impresora ticketera

    End Sub

    Sub GrabarNotaDeVenta()
        objPleaseWait = New FeedbackForm()
        objPleaseWait.StartPosition = FormStartPosition.CenterScreen
        objPleaseWait.Show()
        Application.DoEvents()

        Dim ndocumento As New documento()
        Dim DocCaja As New documento
        Dim listaDocumento As New List(Of documento)
        Dim ListaTotales As New List(Of totalesAlmacen)
        Dim docVentaSA As New documentoVentaAbarrotesSA

        Dim nDocumentoVenta As New documentoventaAbarrotes()
        Dim objDocumentoVentaDet As New documentoventaAbarrotesDet
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        Dim asientoSA As New AsientoSA
        ' Dim ListaAsiento As New List(Of asiento)
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento

        Dim ListaDetalle As New List(Of documentoventaAbarrotesDet)

        Dim TipoCobro As String

        Dim proveedor As String
        Dim idProveedor As Integer
        Dim conteoCantidad As Integer

        dgvCompra.TableControl.CurrentCell.EndEdit()
        dgvCompra.TableControl.Table.TableDirty = True
        dgvCompra.TableControl.Table.EndEdit()

        '-------------------------------------------------------------------------------------
        ndocumento = New documento
        ndocumento.Action = Business.Entity.BaseBE.EntityAction.INSERT
        ndocumento.IsFormatoGeneral = False
        ndocumento.idEmpresa = Gempresas.IdEmpresaRuc
        ndocumento.idCentroCosto = GEstableciento.IdEstablecimiento
        ndocumento.tipoDoc = "9907"
        ndocumento.fechaProceso = txtFecha.Value
        ndocumento.nroDoc = "1"
        ndocumento.moneda = "1"

        If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            ndocumento.entidad = TXTcOMPRADOR.Text
            ndocumento.nrodocEntidad = txtruc.Text
            ndocumento.idEntidad = Val(TXTcOMPRADOR.Tag)
        Else
            ndocumento.entidad = TXTcOMPRADOR.Text
            ndocumento.nrodocEntidad = 0
            ndocumento.idEntidad = Val(0)
        End If
        ndocumento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        ndocumento.tipoOperacion = StatusTipoOperacion.VENTA
        ndocumento.usuarioActualizacion = usuario.IDUsuario
        ndocumento.fechaActualizacion = DateTime.Now
        TipoCobro = TIPO_VENTA.PAGO.COBRADO
        Dim TipoEntrega = TipoEntregado.Entregado
        Dim tipoEstado = TipoGuia.Entregado

        If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            proveedor = TXTcOMPRADOR.Text
            idProveedor = CInt(TXTcOMPRADOR.Tag)
        Else
            proveedor = TXTcOMPRADOR.Text
            idProveedor = 0
        End If

        nDocumentoVenta = New documentoventaAbarrotes With {
                  .tipoOperacion = StatusTipoOperacion.VENTA,
                  .horaVenta = txtFecha.Value.TimeOfDay.ToString(),
                  .codigoLibro = "14",
                  .tipoDocumento = "9907",
                  .idEmpresa = Gempresas.IdEmpresaRuc,
                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                  .fechaDoc = txtFecha.Value,
                  .fechaConfirmacion = txtFecha.Value,
                  .fechaPeriodo = lblPerido.Text,
                  .serie = "NOTA",
                  .serieVenta = "NOTA",
                  .numeroDoc = 1,
                  .numeroVenta = 1,
                  .numeroDocNormal = Nothing,
                  .idCliente = CInt(idProveedor),
                  .idClientePedido = CInt(idProveedor),
                  .nombrePedido = proveedor,
                  .moneda = "1",
                  .tasaIgv = TmpIGV,
                  .tipoCambio = TmpTipoCambio,
                  .bi01 = TotalesXcanbeceras.base1,
                  .bi02 = TotalesXcanbeceras.base2,
                  .igv01 = TotalesXcanbeceras.MontoIgv1,
                  .igv02 = TotalesXcanbeceras.MontoIgv2,
                  .bi01us = TotalesXcanbeceras.base1me,
                  .bi02us = TotalesXcanbeceras.base2me,
                  .igv01us = TotalesXcanbeceras.MontoIgv1me,
                  .igv02us = TotalesXcanbeceras.MontoIgv2me,
                  .ImporteNacional = TotalesXcanbeceras.TotalMN,
                  .ImporteExtranjero = TotalesXcanbeceras.TotalME,
                  .tipoVenta = TIPO_VENTA.NOTA_DE_VENTA,
                  .estado = StatusNotaDeVentas.NoSustentado,
                  .estadoCobro = TipoCobro,
                  .estadoEntrega = TipoEntrega,
                  .terminos = "CONTADO",
                  .glosa = "Por ventas con nota de venta del cliente: " & TXTcOMPRADOR.Text & "con tipo Doc. " & cboTipoDoc.Text & ", fecha de venta " & txtFecha.Value,
                  .fechaVcto = txtFecha.Value,
                  .usuarioActualizacion = usuario.IDUsuario,
                  .fechaActualizacion = DateTime.Now}
        'tipoEstado,
        ndocumento.documentoventaAbarrotes = nDocumentoVenta

        'REGISTRANDO LA GUIA DE REMISION
        'GuiaRemision(ndocumento)
        ListaDetalle = New List(Of documentoventaAbarrotesDet)
        For Each r As Record In dgvCompra.Table.Records

            If CDec(r.GetValue("cantidad")) <= 0 Then
                'MessageBoxAdv.Show("Debe ingresar un cantidad mayor a cero.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Question)
                Throw New Exception("Debe ingresar un cantidad mayor a cero.")
                'Exit Sub
            End If

            If CDec(r.GetValue("totalmn")) <= 0 Then
                Throw New Exception("El importe de venta debe ser mayor a cero.")
                '  MessageBoxAdv.Show("El importe de venta debe ser mayor a cero.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Question)
                '  Exit Sub
            End If
            objDocumentoVentaDet = New documentoventaAbarrotesDet
            objDocumentoVentaDet.codigoLote = 0 'Integer.Parse(r.GetValue("codigoLote"))
            If ChPagoDirecto.Checked Then
                objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.COBRADO
            ElseIf ChPagoAvanzado.Checked Then
                If CDec(r.GetValue("MontoSaldo")) <= 0 Then
                    objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.COBRADO
                Else
                    objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.PENDIENTE_PAGO
                End If
            Else
                objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.PENDIENTE_PAGO
            End If

            objDocumentoVentaDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoVentaDet.IdEstablecimiento = GEstableciento.IdEstablecimiento ' almacenSA.GetUbicar_almacenPorID(i.Cells(24).Value()).idEstablecimiento
            objDocumentoVentaDet.FechaDoc = txtFecha.Value
            objDocumentoVentaDet.Serie = "NOTA"
            objDocumentoVentaDet.NumDoc = 1
            objDocumentoVentaDet.TipoDoc = "9907"
            If r.GetValue("tipoExistencia") = "GS" Then
                objDocumentoVentaDet.idAlmacenOrigen = Nothing
                objDocumentoVentaDet.tipoVenta = r.GetValue("tipoPrecio")
            Else
                objDocumentoVentaDet.idAlmacenOrigen = Nothing
                objDocumentoVentaDet.tipoVenta = r.GetValue("tipoPrecio")
            End If
            objDocumentoVentaDet.establecimientoOrigen = GEstableciento.IdEstablecimiento
            objDocumentoVentaDet.cuentaOrigen = Nothing
            objDocumentoVentaDet.idItem = r.GetValue("idProducto")
            objDocumentoVentaDet.DetalleItem = r.GetValue("item")
            objDocumentoVentaDet.nombreItem = r.GetValue("item")
            objDocumentoVentaDet.tipoExistencia = r.GetValue("tipoExistencia")
            objDocumentoVentaDet.destino = r.GetValue("gravado")
            objDocumentoVentaDet.unidad1 = r.GetValue("um")
            objDocumentoVentaDet.monto1 = CDec(r.GetValue("cantidad"))
            objDocumentoVentaDet.unidad2 = Nothing
            objDocumentoVentaDet.monto2 = 0 ' CDec(r.GetValue("cantidad2")) ' i.Cells(31).Value()
            objDocumentoVentaDet.precioUnitario = CDec(r.GetValue("pumn"))
            objDocumentoVentaDet.precioUnitarioUS = CDec(r.GetValue("pume"))
            objDocumentoVentaDet.importeMN = CDec(r.GetValue("totalmn"))
            objDocumentoVentaDet.importeME = CDec(r.GetValue("totalme"))
            objDocumentoVentaDet.descuentoMN = 0
            objDocumentoVentaDet.descuentoME = 0

            objDocumentoVentaDet.montokardex = CDec(r.GetValue("vcmn"))
            objDocumentoVentaDet.montoIsc = 0
            objDocumentoVentaDet.montoIgv = CDec(r.GetValue("igvmn"))
            objDocumentoVentaDet.otrosTributos = 0
            '**********************************************************************************
            objDocumentoVentaDet.montokardexUS = CDec(r.GetValue("vcme"))
            objDocumentoVentaDet.montoIscUS = 0
            objDocumentoVentaDet.montoIgvUS = CDec(r.GetValue("igvme"))
            objDocumentoVentaDet.otrosTributosUS = 0
            objDocumentoVentaDet.estadoMovimiento = "V" 'ENTREGADO/COBRADO
            '**********************************************************************************
            objDocumentoVentaDet.importeMNK = 0 ' CDec(r.GetValue("puKardex"))
            objDocumentoVentaDet.importeMEK = 0 'CDec(r.GetValue("pukardeme"))
            objDocumentoVentaDet.fechaVcto = txtFecha.Value
            objDocumentoVentaDet.estadoEntrega = TipoEntrega
            objDocumentoVentaDet.cantidadEntrega = CDec(r.GetValue("cantEntregar"))
            objDocumentoVentaDet.salidaCostoMN = CDec(r.GetValue("costoMN")) ' Math.Round(CDec(i.Cells(6).Value()) * CDec(i.Cells(5).Value()), 2)
            objDocumentoVentaDet.salidaCostoME = CDec(r.GetValue("costoME")) 'Math.Round(CDec(i.Cells(28).Value()) * CDec(i.Cells(5).Value()), 2)

            If (TipoEntrega = TipoEntregado.PorEntregar) Then
                conteoCantidad = CDec(r.GetValue("cantEntregar"))
            End If
            objDocumentoVentaDet.NomMarca = Nothing ' r.GetValue("marca")
            objDocumentoVentaDet.categoria = Nothing
            objDocumentoVentaDet.preEvento = Nothing
            objDocumentoVentaDet.usuarioModificacion = usuario.IDUsuario
            objDocumentoVentaDet.fechaModificacion = DateTime.Now
            objDocumentoVentaDet.Glosa = txtGlosa.Text.Trim
            ListaDetalle.Add(objDocumentoVentaDet)
        Next

        ndocumento.documentoventaAbarrotes.documentoventaAbarrotesDet = ListaDetalle

        'Dim listaExistencias As List(Of documentoventaAbarrotesDet) = (From n In ListaDetalle
        '                                                               Where n.tipoExistencia <> TipoRecurso.SERVICIO).ToList
        'If listaExistencias.Count > 0 Then
        '    AsientoVenta(listaExistencias)
        'End If

        'Dim listaServicios As List(Of documentoventaAbarrotesDet) = (From n In ListaDetalle
        '                                                             Where n.tipoExistencia = TipoRecurso.SERVICIO).ToList

        'If listaServicios.Count > 0 Then
        '    AsientoVentaServicios(listaServicios)
        'End If

        'GuiaRemision(ndocumento)

        If ChPagoDirecto.Checked Then
            ndocumento.ListaCustomDocumento = ListaDocumentoCaja(ndocumento.documentoventaAbarrotes)
            ndocumento.documentoventaAbarrotes.estadoCobro = TIPO_VENTA.PAGO.COBRADO
            ndocumento.documentoventaAbarrotes.terminos = "CONTADO"
        ElseIf ChPagoAvanzado.Checked = True Then
            Dim f As New frmFormatoPagoComprobantes
            f.txtMontoXcobrar.Text = txtTotalPagar.DecimalValue
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            If f.Tag IsNot Nothing Then
                Dim c = CType(f.Tag, List(Of documentoCaja))
                If c.Count > 0 Then
                    Dim ListaPagos = ListaPagosCajas(c, ndocumento.documentoventaAbarrotes, ndocumento.documentoventaAbarrotes.documentoventaAbarrotesDet)
                    Dim SumaPagos As Decimal = 0
                    For Each i In ListaPagos
                        SumaPagos += i.documentoCaja.montoSoles.GetValueOrDefault
                    Next
                    If SumaPagos = txtTotalPagar.DecimalValue Then
                        ndocumento.documentoventaAbarrotes.terminos = "CONTADO"
                    Else
                        'ndocumento.documentoventaAbarrotes.terminos = "PARCIAL"
                        ndocumento.documentoventaAbarrotes.terminos = "CREDITO"
                    End If
                    ndocumento.documentoventaAbarrotes.estadoCobro = ndocumento.documentoventaAbarrotes.GetEstadoPagoComprobante
                    ndocumento.ListaCustomDocumento = ListaPagos 'ListaPagosCajas(c)
                Else
                    MessageBox.Show("Debe realizar el pago del comprobante", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            Else
                MessageBox.Show("Debe realizar el pago del comprobante", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        Else
            ndocumento.documentoventaAbarrotes.estadoCobro = "PN"
            ndocumento.documentoventaAbarrotes.terminos = "CREDITO"
        End If


        '    Dim idDocuentoGrabado As Integer
        If ListaDetalle.Where(Function(o) o.monto1 = 0).Count = 0 Then
            ndocumento.asiento = ListaAsientonTransito

            'listaDocumento.Add(ndocumento)
            Dim lista = VentaSA.Grabar_VentaNotaSinInventario(ndocumento)

            'GetImpresionTicketsEspecial(lista)
            'If MessageBox.Show("Desea imprimir la nota de venta ?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            '    imprimirTicketMatricial(idDocuentoGrabado)
            '    '   ImprimirTicket(idDocuentoGrabado)
            '    'ImprimirTicket(idDocuentoGrabado)
            '    'ImprimirTicketAcumulado(idDocuentoGrabado)
            '    'VentaSA.GetActualizarImpresion(New documentoventaAbarrotes With {.idDocumento = idDocuentoGrabado})

            'Dim f As New FormImpresionNuevo  ' frmVentaNuevoFormato
            'f.DocumentoID = lista
            'f.StartPosition = FormStartPosition.CenterScreen
            '' f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
            'f.Show(Me)


            'End If
            LimpiarControles()
            ChPagoDirecto.Checked = True
            ChPagoAvanzado.Checked = False
            PagoDirectoCheck()
            objPleaseWait.Close()
            Alert = New Alert("Nota registrada", alertType.success)
            Alert.TopMost = True
            Alert.Show()
            With FormCanastaTotalesServVer2
                .GridTotales.Table.Records.DeleteAll()
                .txtFiltrar.Clear()
            End With
            ToolStrip5.Focus()
            ToolStripButton1.Select()

        Else
            Throw New Exception("Debe verificar que las celdas estan completas!")
        End If
    End Sub

    Public Sub GetDocumentoVentaID(ID As Integer)
        Dim objDocCompra As New documentoVentaAbarrotesSA
        Dim objDocCompraDet As New documentoVentaAbarrotesDetSA

        documentoVenta = New documentoventaAbarrotes
        documentoVentaDetalle = New List(Of documentoventaAbarrotesDet)

        documentoVenta = objDocCompra.GetUbicar_documentoventaAbarrotesPorID(ID)
        entidad = entidadSA.UbicarEntidadPorID(documentoVenta.idCliente).FirstOrDefault
        documentoVentaDetalle = objDocCompraDet.GetUbicar_documentoventaAbarrotesDetPorIDocumento(ID) ' objDocCompraDet.usp_EditarDetalleVenta(ID)
    End Sub

    Public Sub GetDocumentoVentaIDDone()
        Dim loteSA As New recursoCostoLoteSA
        'CABECERA COMPROBANTE
        With documentoVenta
            txtFecha.Value = .fechaDoc
            lblPerido.Text = .fechaPeriodo
            txtSerie.Text = .serieVenta
            txtNumero.Text = .numeroVenta
            txtNumero.Visible = True
            Dim codigoComprobante = .tipoDocumento
            Select Case codigoComprobante
                Case "12.1", "03"
                    cboTipoDoc.Text = "BOLETA"
                Case "12.2", "01"
                    cboTipoDoc.Text = "FACTURA"

                Case "9907"
                    cboTipoDoc.Text = "NOTA DE VENTA"
            End Select
            cboTipoDoc.SelectedValue = .tipoDocumento
            cboTipoDoc.Enabled = False
            dgvCompra.TableDescriptor.Columns("pumn").Width = 60
            dgvCompra.TableDescriptor.Columns("vcmn").Width = 65
            dgvCompra.TableDescriptor.Columns("igvmn").Width = 65
            dgvCompra.TableDescriptor.Columns("totalmn").Width = 70

            dgvCompra.TableDescriptor.Columns("pume").Width = 0
            dgvCompra.TableDescriptor.Columns("vcme").Width = 0
            dgvCompra.TableDescriptor.Columns("igvme").Width = 0
            dgvCompra.TableDescriptor.Columns("totalme").Width = 0

            If Not IsNothing(entidad) Then
                txtruc.Text = entidad.nrodoc
                TXTcOMPRADOR.Tag = entidad.idEntidad
                TXTcOMPRADOR.Text = entidad.nombreCompleto
                TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                txtruc.Visible = True
            Else
                TXTcOMPRADOR.Text = .nombrePedido
            End If
            txtGlosa.Text = .glosa
        End With

        'DETALLE DE LA COMPRA
        dgvCompra.Table.Records.DeleteAll()
        For Each i In documentoVentaDetalle
            'Dim lote = loteSA.GetLoteByID(i.codigoLote)

            Me.dgvCompra.Table.AddNewRecord.SetCurrent()
            Me.dgvCompra.Table.AddNewRecord.BeginEdit()
            Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", i.destino)
            Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", i.idItem)
            Me.dgvCompra.Table.CurrentRecord.SetValue("item", i.nombreItem)
            Me.dgvCompra.Table.CurrentRecord.SetValue("um", i.unidad1)
            Me.dgvCompra.Table.CurrentRecord.SetValue("canDisponible", i.monto1)
            Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", i.monto1)
            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", i.montokardex)
            '    Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", i.importeMN)

            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", i.montokardexUS)
            '    Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", i.importeME)
            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", i.montoIgv)
            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", i.montoIgvUS)
            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", i.tipoExistencia)
            'Me.dgvCompra.Table.CurrentRecord.SetValue("marca", If(lote.productoSustentado = True, "Doc.", "Not."))

            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", i.precioUnitario)
            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", i.precioUnitarioUS)
            Me.dgvCompra.Table.CurrentRecord.SetValue("presentacion", i.unidad2)
            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", i.idAlmacenOrigen)
            Me.dgvCompra.Table.AddNewRecord.EndEdit()
        Next
        btGrabar.Enabled = False
        TotalTalesXcolumna()

    End Sub

    Public Function AS_IGV(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
              .cuenta = "40111",
              .descripcion = "I.G.V.",
              .tipo = ASIENTO_CONTABLE.UBICACION.HABER,
              .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = usuario.IDUsuario}

        Return nMovimiento
    End Function

    Sub AsientoVenta(listadoExistencias As List(Of documentoventaAbarrotesDet))
        Dim nMovimiento As New movimiento
        Dim nAsiento As New asiento

        Dim SumaCliente = Aggregate n In listadoExistencias
                         Into totalMN = Sum(n.importeMN),
                         TotalME = Sum(n.importeME)

        nAsiento = New asiento
        nAsiento.idAsiento = 0
        nAsiento.idDocumento = 0
        nAsiento.periodo = lblPerido.Text
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idDocumentoRef = 0
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.idAlmacen = Nothing
        nAsiento.nombreAlmacen = Nothing

        If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            nAsiento.nombreEntidad = TXTcOMPRADOR.Text
            nAsiento.idEntidad = Integer.Parse(TXTcOMPRADOR.Tag)
        Else
            nAsiento.nombreEntidad = TXTcOMPRADOR.Text
            nAsiento.idEntidad = Integer.Parse(0)
        End If

        nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        nAsiento.codigoLibro = "14"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_Existencia
        nAsiento.glosa = txtGlosa.Text.Trim
        nAsiento.importeMN = SumaCliente.totalMN.GetValueOrDefault
        nAsiento.importeME = SumaCliente.TotalME.GetValueOrDefault
        nAsiento.fechaActualizacion = DateTime.Now
        nAsiento.usuarioActualizacion = usuario.IDUsuario

        ListaAsientonTransito.Add(nAsiento)

        nAsiento.movimiento.Add(AS_Cliente(SumaCliente.totalMN.GetValueOrDefault, SumaCliente.TotalME.GetValueOrDefault))

        Dim SumaIGV = Aggregate n In listadoExistencias
                       Into totalIGVMN = Sum(n.montoIgv),
                       totalIGVME = Sum(n.montoIgvUS)

        If SumaIGV.totalIGVMN.GetValueOrDefault > 0 Then
            nAsiento.movimiento.Add(AS_IGV(SumaIGV.totalIGVMN.GetValueOrDefault, SumaIGV.totalIGVME.GetValueOrDefault))
        End If
        'nAsiento.movimiento.Add(AS_CAJA(TotalesXcanbeceras.TotalMN, TotalesXcanbeceras.TotalME))
        For Each i In listadoExistencias
            'MV_Item_Transito(i.DetalleItem, i.salidaCostoMN, i.salidaCostoME, i.tipoExistencia)
            nMovimiento = New movimiento
            nMovimiento.cuenta = "70111"
            nMovimiento.descripcion = i.DetalleItem
            nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
            nMovimiento.monto = CDec(i.montokardex)
            nMovimiento.montoUSD = CDec(i.montokardexUS)
            nMovimiento.fechaActualizacion = DateTime.Now
            nMovimiento.usuarioActualizacion = usuario.IDUsuario
            nAsiento.movimiento.Add(nMovimiento)
        Next

    End Sub

    Sub AsientoVentaServicios(listadoServicios As List(Of documentoventaAbarrotesDet))
        Dim nMovimiento As New movimiento
        Dim nAsiento As New asiento

        Dim SumaCliente = Aggregate n In listadoServicios
                    Into totalMN = Sum(n.importeMN),
                    TotalME = Sum(n.importeME)

        nAsiento = New asiento
        nAsiento.idAsiento = 0
        nAsiento.idDocumento = 0
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.periodo = lblPerido.Text
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idDocumentoRef = 0
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.idAlmacen = Nothing
        nAsiento.nombreAlmacen = Nothing

        If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            nAsiento.idEntidad = Integer.Parse(TXTcOMPRADOR.Tag) ' txtIdCliente.Text
            nAsiento.nombreEntidad = TXTcOMPRADOR.Text
        Else
            nAsiento.nombreEntidad = TXTcOMPRADOR.Text
            nAsiento.idEntidad = Integer.Parse(0)
        End If

        nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        nAsiento.codigoLibro = "14"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_Existencia
        nAsiento.glosa = txtGlosa.Text.Trim
        nAsiento.importeMN = SumaCliente.totalMN.GetValueOrDefault
        nAsiento.importeME = SumaCliente.TotalME.GetValueOrDefault
        nAsiento.fechaActualizacion = DateTime.Now
        If IsNothing(GFichaUsuarios) Then
            nAsiento.usuarioActualizacion = usuario.IDUsuario
        Else
            nAsiento.usuarioActualizacion = GFichaUsuarios.IdCajaUsuario
        End If

        ListaAsientonTransito.Add(nAsiento)

        nAsiento.movimiento.Add(AS_Cliente(SumaCliente.totalMN.GetValueOrDefault, SumaCliente.TotalME.GetValueOrDefault))

        Dim SumaIGV = Aggregate n In listadoServicios
                       Into totalIGVMN = Sum(n.montoIgv),
                       totalIGVME = Sum(n.montoIgvUS)

        If SumaIGV.totalIGVMN.GetValueOrDefault > 0 Then
            nAsiento.movimiento.Add(AS_IGV(SumaIGV.totalIGVMN.GetValueOrDefault, SumaIGV.totalIGVME.GetValueOrDefault))
        End If
        'nAsiento.movimiento.Add(AS_CAJA(TotalesXcanbeceras.TotalMN, TotalesXcanbeceras.TotalME))
        For Each i In listadoServicios
            nMovimiento = New movimiento
            nMovimiento.cuenta = "7041" 'i.idItem
            nMovimiento.descripcion = i.DetalleItem
            nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
            nMovimiento.monto = CDec(i.montokardex)
            nMovimiento.montoUSD = CDec(i.montokardexUS)
            nMovimiento.fechaActualizacion = DateTime.Now
            nMovimiento.usuarioActualizacion = usuario.IDUsuario
            nAsiento.movimiento.Add(nMovimiento)
        Next

    End Sub

    Public Function AS_Cliente(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        nMovimiento = New movimiento With {
              .cuenta = "1213",
              .descripcion = TXTcOMPRADOR.Text,
              .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
              .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = usuario.IDUsuario}

        Return nMovimiento
    End Function

    Private Function ValidarGrabado() As Boolean
        Dim listaErrores As Integer = 0

        Select Case cboTipoDoc.Text

            Case "BOLETA", "FACTURA"
                If TXTcOMPRADOR.Text.Trim.Length = 0 Then
                    ErrorProvider1.SetError(TXTcOMPRADOR, "Ingrese un cliente")
                    listaErrores += 1
                Else
                    ErrorProvider1.SetError(TXTcOMPRADOR, Nothing)
                End If

                If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
                    ErrorProvider1.SetError(TXTcOMPRADOR, Nothing)
                Else
                    ErrorProvider1.SetError(TXTcOMPRADOR, "Ingrese un cliente válido")
                    listaErrores += 1
                End If

                If chAutoNumeracion.Checked = False Then
                    If txtSerie.Text.Trim.Length = 0 Then
                        ErrorProvider1.SetError(txtSerie, "El campo serie es obligatorio")
                        listaErrores += 1
                    Else
                        ErrorProvider1.SetError(txtSerie, Nothing)
                    End If

                    If txtNumero.Text.Trim.Length = 0 Then
                        ErrorProvider1.SetError(txtNumero, "El campo número es obligatorio")
                        listaErrores += 1
                    Else
                        ErrorProvider1.SetError(txtNumero, Nothing)
                    End If
                End If
            Case "NOTA DE VENTA"
                'If TXTcOMPRADOR.Text.Trim.Length = 0 Then
                '    ErrorProvider1.SetError(TXTcOMPRADOR, "Ingrese un cliente")
                '    listaErrores += 1
                'Else
                '    ErrorProvider1.SetError(TXTcOMPRADOR, Nothing)
                'End If

                'If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
                '    ErrorProvider1.SetError(TXTcOMPRADOR, Nothing)
                'Else
                '    ErrorProvider1.SetError(TXTcOMPRADOR, "Ingrese un cliente válido")
                '    listaErrores += 1
                'End If



            Case "BOLETA ELECTRONICA"

                If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
                    ErrorProvider1.SetError(TXTcOMPRADOR, Nothing)
                Else
                    ErrorProvider1.SetError(TXTcOMPRADOR, "Ingrese un cliente válido")
                    listaErrores += 1
                End If

            '    If txtTipoDocClie.Text = "6" Then
            '        ErrorProvider1.SetError(TXTcOMPRADOR, "Debe ingresar Cliente DNI/Otros")
            '        listaErrores += 1
            '    Else
            '        ErrorProvider1.SetError(TXTcOMPRADOR, Nothing)
            '    End If

            Case "FACTURA ELECTRONICA"

                If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
                    ErrorProvider1.SetError(TXTcOMPRADOR, Nothing)
                Else
                    ErrorProvider1.SetError(TXTcOMPRADOR, "Ingrese un cliente válido")
                    listaErrores += 1
                End If

                If txtTipoDocClie.Text = "1" Or txtTipoDocClie.Text = "0" Then
                    ErrorProvider1.SetError(TXTcOMPRADOR, "Debe ingresar Cliente RUC")
                    listaErrores += 1
                Else
                    ErrorProvider1.SetError(TXTcOMPRADOR, Nothing)
                End If
        End Select


        If txtTotalPagar.DecimalValue <= 0 Then
            ErrorProvider1.SetError(txtTotalPagar, "La venta debe ser mayor a cero")
            listaErrores += 1
        Else
            ErrorProvider1.SetError(txtTotalPagar, Nothing)
        End If

        If listaErrores > 0 Then
            ValidarGrabado = False
        Else
            ValidarGrabado = True
        End If
    End Function

    Sub GrabarVentaDuplex()
        objPleaseWait = New FeedbackForm()
        objPleaseWait.StartPosition = FormStartPosition.CenterScreen
        objPleaseWait.Show()
        Application.DoEvents()

        Dim ListProductosVendidos = GetDetalleVenta()
        'Dim ListaProductos_empresa = ListProductosVendidos.Where(Function(o) o.categoria = StatusCategoriaVenta.Productos).ToList
        'Dim ListaProductos_consignados = ListProductosVendidos.Where(Function(o) o.categoria = StatusCategoriaVenta.ProductosEnConsigna).ToList

        If ListProductosVendidos.Count = 0 Then
            Throw New Exception("Debe ingresar artículos a la canasta de venta")
        End If

        Dim listaDocumento As New List(Of documento)

        If ListProductosVendidos.Where(Function(o) o.GetSustento = True).Count > 0 Then
            Dim DocComprobante =
            CType(GetGrabarVentaComprobante(ListProductosVendidos.Where(Function(o) o.GetSustento = True).ToList()), documento)

            listaDocumento.Add(DocComprobante)
        End If

        If ListProductosVendidos.Where(Function(o) o.GetSustento = False).Count > 0 Then
            Dim DocNota = CType(GetGrabarNotaVenta(ListProductosVendidos.Where(Function(o) o.GetSustento = False).ToList()), documento)

            listaDocumento.Add(DocNota)
        End If

        'If ListaProductos_consignados.Count > 0 Then
        '    Dim docConsigna As New documento
        '    docConsigna.tipoDoc = StatusTipoOperacion.CONSIGNACION_RECIBIDA
        '    docConsigna.tipoOperacion = StatusTipoOperacion.CONSIGNACION_RECIBIDA

        '    docConsigna.documentoventaAbarrotes = New documentoventaAbarrotes With
        '    {
        '    .tipoDocumento = StatusTipoOperacion.CONSIGNACION_RECIBIDA,
        '    .tipoOperacion = StatusTipoOperacion.CONSIGNACION_RECIBIDA
        '    }
        '    docConsigna.documentoventaAbarrotes.documentoventaAbarrotesDet = ListaProductos_consignados
        '    listaDocumento.Add(docConsigna)
        'End If

        Dim lista = VentaSA.Grabar_VentaList(listaDocumento)
        GetImpresionTickets(lista)

        LimpiarControles()
        ChPagoDirecto.Checked = True
        ChPagoAvanzado.Checked = False
        PagoDirectoCheck()
        objPleaseWait.Close()
        Alert = New Alert("Venta registrada", alertType.success)
        Alert.TopMost = True
        Alert.Show()
    End Sub


    ''' <summary>
    ''' Omite la separacion de notas de venta y la factura de venta
    ''' </summary>
    Sub GrabarVentaCasoEspecial()
        Dim ListProductosVendidos As New List(Of documentoventaAbarrotesDet)
        objPleaseWait = New FeedbackForm()
        objPleaseWait.StartPosition = FormStartPosition.CenterScreen
        objPleaseWait.Show()
        Application.DoEvents()

        ListProductosVendidos = New List(Of documentoventaAbarrotesDet)
        ListProductosVendidos = GetDetalleVenta()
        If ListProductosVendidos.Count = 0 Then
            objPleaseWait.Close()
            Throw New Exception("Debe ingresar artículos a la canasta de venta")
        End If

        Dim listaDocumento As New List(Of documento)

        If ListProductosVendidos.Count > 0 Then
            Dim DocComprobante =
            CType(GetGrabarVentaComprobante(ListProductosVendidos.ToList()), documento)

            listaDocumento.Add(DocComprobante)
        End If

        Dim lista = VentaSA.GrabarVentaSinIventario(listaDocumento)

        GetImpresionTicketsEspecial(lista)

        LimpiarControles()
        ChPagoDirecto.Checked = True
        ChPagoAvanzado.Checked = False
        PagoDirectoCheck()
        objPleaseWait.Close()
        Alert = New Alert("Venta registrada", alertType.success)
        Alert.TopMost = True
        Alert.Show()

        'GetImpresionTicketsEspecial(lista)



        With FormCanastaTotalesServVer2
            .GridTotales.Table.Records.DeleteAll()
            .txtFiltrar.Clear()
        End With
        ToolStrip5.Focus()
        ToolStripButton1.Select()
    End Sub

    Private Sub GetImpresionTickets(listaDocumento As List(Of documentoventaAbarrotes))
        Dim ventaSA As New documentoVentaAbarrotesSA
        Dim impresionTicketDoc = listaDocumento.Where(Function(o) o.tipoVenta = TIPO_VENTA.VENTA_POS_DIRECTA).FirstOrDefault
        If impresionTicketDoc IsNot Nothing Then
            If MessageBox.Show("Desea imprimir la venta ?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                'ImprimirTicket(impresionTicketDoc.idDocumento)
                ImprimirTicketAcumulado(impresionTicketDoc.idDocumento)
                ventaSA.GetActualizarImpresion(New documentoventaAbarrotes With {.idDocumento = impresionTicketDoc.idDocumento})
            End If

        End If

        Dim impresionNota = listaDocumento.Where(Function(o) o.tipoVenta = TIPO_VENTA.NOTA_DE_VENTA).FirstOrDefault
        If impresionNota IsNot Nothing Then
            If MessageBox.Show("Desea imprimir la nota de venta ?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                '   ImprimirTicket(impresionNota.idDocumento)
                ImprimirTicketAcumulado(impresionNota.idDocumento)
                ventaSA.GetActualizarImpresion(New documentoventaAbarrotes With {.idDocumento = impresionNota.idDocumento})
            End If
        End If
    End Sub

    Private Sub GetImpresionTicketsEspecial(listaDocumento As List(Of documentoventaAbarrotes))
        Dim ventaSA As New documentoVentaAbarrotesSA
        Dim impresionTicketDoc = listaDocumento.Where(Function(o) o.tipoVenta = TIPO_VENTA.VENTA_POS_DIRECTA).FirstOrDefault
        If impresionTicketDoc IsNot Nothing Then
            'If MessageBox.Show("Desea imprimir la venta ?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            '    ImprimirTicket(impresionTicketDoc.idDocumento)
            ' ImprimirTicketAcumulado(impresionTicketDoc.idDocumento)
            'Dim f As New FormImpresionNuevo  ' frmVentaNuevoFormato
            'f.DocumentoID = impresionTicketDoc.idDocumento
            'f.StartPosition = FormStartPosition.CenterScreen
            '' f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
            'f.Show(Me)
            ventaSA.GetActualizarImpresion(New documentoventaAbarrotes With {.idDocumento = impresionTicketDoc.idDocumento})
            'End If
        End If
    End Sub

    Private Sub GetImpresionTicketsEspecialNota(idDocumento As Integer)
        Dim ventaSA As New documentoVentaAbarrotesSA

        'If MessageBox.Show("Desea imprimir la venta ?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
        'ImprimirTicketGladis(idDocumento)
        'ImprimirTicketAcumulado(idDocumento)

        'Dim f As New FormImpresionNuevo  ' frmVentaNuevoFormato
        'f.DocumentoID = idDocumento
        'f.StartPosition = FormStartPosition.CenterScreen
        ' f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        ' f.Show(Me)

        ventaSA.GetActualizarImpresion(New documentoventaAbarrotes With {.idDocumento = idDocumento})
        'End If
    End Sub

    Private Function GetGrabarNotaVenta(DetalleVenta As List(Of documentoventaAbarrotesDet)) As documento
        Dim objDocumentoVentaDet As documentoventaAbarrotesDet
        Dim ListaVenta As List(Of documentoventaAbarrotesDet)
        Dim ndocumento As New documento()
        Dim DocCaja As New documento

        Dim ListaTotales As New List(Of totalesAlmacen)
        Dim docVentaSA As New documentoVentaAbarrotesSA

        Dim nDocumentoVenta As New documentoventaAbarrotes()
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        Dim asientoSA As New AsientoSA
        ' Dim ListaAsiento As New List(Of asiento)
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento

        Dim TipoCobro As String
        Dim proveedor As String
        Dim idProveedor As Integer

        '-------------------------------------------------------------------------------------
        ndocumento = New documento
        ndocumento.Action = Business.Entity.BaseBE.EntityAction.INSERT
        ndocumento.IsFormatoGeneral = False
        ndocumento.idEmpresa = Gempresas.IdEmpresaRuc
        ndocumento.idCentroCosto = GEstableciento.IdEstablecimiento
        ndocumento.tipoDoc = "9907"
        ndocumento.fechaProceso = txtFecha.Value
        ndocumento.nroDoc = "1"
        ndocumento.moneda = "1"

        If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            ndocumento.entidad = TXTcOMPRADOR.Text
            ndocumento.nrodocEntidad = txtruc.Text
            ndocumento.idEntidad = Val(TXTcOMPRADOR.Tag)
        Else
            ndocumento.entidad = TXTcOMPRADOR.Text
            ndocumento.nrodocEntidad = 0
            ndocumento.idEntidad = Val(0)
        End If
        ndocumento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        ndocumento.tipoOperacion = StatusTipoOperacion.VENTA
        ndocumento.usuarioActualizacion = usuario.IDUsuario
        ndocumento.fechaActualizacion = DateTime.Now
        TipoCobro = TIPO_VENTA.PAGO.COBRADO
        Dim TipoEntrega = TipoEntregado.Entregado
        Dim tipoEstado = TipoGuia.Entregado

        If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            proveedor = TXTcOMPRADOR.Text
            idProveedor = CInt(TXTcOMPRADOR.Tag)
        Else
            proveedor = TXTcOMPRADOR.Text
            idProveedor = 0
        End If

        Dim sumaVentaMN As Decimal = DetalleVenta.Sum(Function(o) o.importeMN).GetValueOrDefault
        Dim sumaVentaME As Decimal = DetalleVenta.Sum(Function(o) o.importeME).GetValueOrDefault
        Dim sumaBase1MN As Decimal =
            DetalleVenta.Where(Function(o) o.destino = OperacionGravada.Grabado).Sum(Function(o) o.montokardex).GetValueOrDefault

        Dim sumaBase1ME As Decimal =
            DetalleVenta.Where(Function(o) o.destino = OperacionGravada.Grabado).Sum(Function(o) o.montokardexUS).GetValueOrDefault

        Dim sumaBase2MN As Decimal =
            DetalleVenta.Where(Function(o) o.destino = OperacionGravada.Exonerado).Sum(Function(o) o.montokardex).GetValueOrDefault

        Dim sumaBase2ME As Decimal =
            DetalleVenta.Where(Function(o) o.destino = OperacionGravada.Exonerado).Sum(Function(o) o.montokardexUS).GetValueOrDefault

        Dim sumaIgvMN As Decimal = DetalleVenta.Sum(Function(o) o.montoIgv).GetValueOrDefault
        Dim sumaIgvME As Decimal = DetalleVenta.Sum(Function(o) o.montoIgvUS).GetValueOrDefault
        '-------------------------------------------------------------------------------------

        nDocumentoVenta = New documentoventaAbarrotes With {
            .horaVenta = txtFecha.Value.TimeOfDay.ToString(),
                  .tipoOperacion = StatusTipoOperacion.VENTA,
                  .codigoLibro = "14",
                  .tipoDocumento = "9907",
                  .idEmpresa = Gempresas.IdEmpresaRuc,
                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                  .fechaDoc = txtFecha.Value,
                  .fechaPeriodo = lblPerido.Text,
                  .serie = "NOTA",
                  .serieVenta = "NOTA",
                  .numeroDoc = 1,
                  .numeroVenta = 1,
                  .numeroDocNormal = Nothing,
                  .idCliente = CInt(idProveedor),
                  .idClientePedido = CInt(idProveedor),
                  .nombrePedido = proveedor,
                  .moneda = "1",
                  .tasaIgv = TmpIGV,
                  .tipoCambio = TmpTipoCambio,
                  .bi01 = sumaBase1MN,
                  .bi02 = sumaBase2MN,
                  .igv01 = sumaIgvMN,
                  .igv02 = 0,
                  .bi01us = sumaBase1ME,
                  .bi02us = sumaBase2ME,
                  .igv01us = sumaIgvME,
                  .igv02us = 0,
                  .ImporteNacional = sumaVentaMN,
                  .ImporteExtranjero = sumaVentaME,
                  .tipoVenta = TIPO_VENTA.NOTA_DE_VENTA,
                  .estadoCobro = TipoCobro,
                  .estadoEntrega = TipoEntrega,
                  .terminos = "CONTADO",
                  .glosa = txtGlosa.Text.Trim,
                  .fechaVcto = txtFecha.Value,
                  .estado = StatusNotaDeVentas.NoSustentado,
                  .usuarioActualizacion = usuario.IDUsuario,
                  .fechaActualizacion = DateTime.Now}
        'tipoEstado,
        ndocumento.documentoventaAbarrotes = nDocumentoVenta

        ListaVenta = New List(Of documentoventaAbarrotesDet)
        For Each i In DetalleVenta
            objDocumentoVentaDet = New documentoventaAbarrotesDet
            objDocumentoVentaDet.codigoLote = 0 'i.codigoLote
            objDocumentoVentaDet.IdEmpresa = i.IdEmpresa
            objDocumentoVentaDet.IdEstablecimiento = i.IdEstablecimiento
            objDocumentoVentaDet.FechaDoc = txtFecha.Value
            objDocumentoVentaDet.Serie = "NOTA"
            objDocumentoVentaDet.NumDoc = 1
            objDocumentoVentaDet.TipoDoc = "9907"

            objDocumentoVentaDet.idAlmacenOrigen = i.idAlmacenOrigen
            objDocumentoVentaDet.tipoVenta = i.tipoVenta
            objDocumentoVentaDet.establecimientoOrigen = i.establecimientoOrigen
            objDocumentoVentaDet.cuentaOrigen = Nothing
            objDocumentoVentaDet.idItem = i.idItem
            objDocumentoVentaDet.DetalleItem = i.DetalleItem
            objDocumentoVentaDet.tipoExistencia = i.tipoExistencia
            objDocumentoVentaDet.destino = i.destino
            objDocumentoVentaDet.unidad1 = i.unidad1
            objDocumentoVentaDet.monto1 = i.monto1
            objDocumentoVentaDet.unidad2 = Nothing
            objDocumentoVentaDet.monto2 = Nothing 'i.Cells(31).Value()
            objDocumentoVentaDet.precioUnitario = Math.Round(CDec(i.importeMN) / CDec(i.monto1), 2)
            objDocumentoVentaDet.precioUnitarioUS = Math.Round(CDec(i.importeME) / CDec(i.monto1), 2)
            objDocumentoVentaDet.importeMN = i.importeMN
            objDocumentoVentaDet.importeME = i.importeME
            objDocumentoVentaDet.descuentoMN = 0
            objDocumentoVentaDet.descuentoME = 0

            objDocumentoVentaDet.montokardex = i.importeMN
            objDocumentoVentaDet.montoIsc = 0
            objDocumentoVentaDet.montoIgv = 0
            objDocumentoVentaDet.otrosTributos = 0
            '**********************************************************************************
            objDocumentoVentaDet.montokardexUS = i.importeME
            objDocumentoVentaDet.montoIscUS = 0
            objDocumentoVentaDet.montoIgvUS = 0
            objDocumentoVentaDet.otrosTributosUS = 0
            objDocumentoVentaDet.estadoMovimiento = "V" 'ENTREGADO/COBRADO
            '**********************************************************************************
            objDocumentoVentaDet.importeMNK = i.importeMNK
            objDocumentoVentaDet.importeMEK = i.importeMEK
            objDocumentoVentaDet.fechaVcto = txtFecha.Value
            objDocumentoVentaDet.estadoEntrega = TipoEntrega
            objDocumentoVentaDet.cantidadEntrega = i.cantidadEntrega
            objDocumentoVentaDet.salidaCostoMN = i.salidaCostoMN ' Math.Round(CDec(i.Cells(6).Value()) * CDec(i.Cells(5).Value()), 2)
            objDocumentoVentaDet.salidaCostoME = i.salidaCostoME 'Math.Round(CDec(i.Cells(28).Value()) * CDec(i.Cells(5).Value()), 2)
            objDocumentoVentaDet.categoria = Nothing
            objDocumentoVentaDet.preEvento = Nothing
            objDocumentoVentaDet.usuarioModificacion = usuario.IDUsuario
            objDocumentoVentaDet.fechaModificacion = DateTime.Now
            objDocumentoVentaDet.Glosa = "Nota de venta del cliente: " & TXTcOMPRADOR.Text & "con tipo Doc. " & cboTipoDoc.Text & ", fecha de venta " & txtFecha.Value
            ListaVenta.Add(objDocumentoVentaDet)
        Next

        ndocumento.documentoventaAbarrotes.documentoventaAbarrotesDet = ListaVenta

        Return ndocumento
    End Function

    Private Function GetDetalleVenta() As List(Of documentoventaAbarrotesDet)
        Dim TipoEntrega = TipoEntregado.Entregado
        Dim objDocumentoVentaDet As documentoventaAbarrotesDet
        GetDetalleVenta = New List(Of documentoventaAbarrotesDet)
        For Each r As Record In dgvCompra.Table.Records

            If CDec(r.GetValue("cantidad")) <= 0 Then
                Throw New Exception("Debe ingresar un cantidad mayor a cero.")
            End If

            If CDec(r.GetValue("totalmn")) <= 0 Then
                Throw New Exception("El importe de venta debe ser mayor a cero.")
            End If
            objDocumentoVentaDet = New documentoventaAbarrotesDet
            If r.GetValue("tipoExistencia") = "OF" Then
                objDocumentoVentaDet.CustomOferta_Detalle = New ventaDetalle_oferta With {
                .id_oferta = r.GetValue("codigo")
                }
            End If

            objDocumentoVentaDet.codigoLote = 0 ' Integer.Parse(r.GetValue("codigoLote"))
            If ChPagoDirecto.Checked Then
                objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.COBRADO
            ElseIf ChPagoAvanzado.Checked Then
                If CDec(r.GetValue("MontoSaldo")) <= 0 Then
                    objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.COBRADO
                Else
                    objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.PENDIENTE_PAGO
                End If
            Else
                objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.PENDIENTE_PAGO
            End If

            objDocumentoVentaDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoVentaDet.IdEstablecimiento = GEstableciento.IdEstablecimiento ' almacenSA.GetUbicar_almacenPorID(i.Cells(24).Value()).idEstablecimiento
            objDocumentoVentaDet.FechaDoc = txtFecha.Value
            objDocumentoVentaDet.Serie = GConfiguracion.Serie
            objDocumentoVentaDet.NumDoc = GConfiguracion.Serie
            objDocumentoVentaDet.TipoDoc = GConfiguracion.TipoComprobante
            If r.GetValue("tipoExistencia") = "GS" Then
                objDocumentoVentaDet.idAlmacenOrigen = Nothing
                objDocumentoVentaDet.tipoVenta = r.GetValue("tipoPrecio")
            ElseIf r.GetValue("tipoExistencia") = "OF" Then
                objDocumentoVentaDet.idAlmacenOrigen = Nothing
                objDocumentoVentaDet.tipoVenta = "F"
            Else
                objDocumentoVentaDet.idAlmacenOrigen = Nothing
                objDocumentoVentaDet.tipoVenta = r.GetValue("tipoPrecio")
            End If
            objDocumentoVentaDet.establecimientoOrigen = GEstableciento.IdEstablecimiento
            objDocumentoVentaDet.cuentaOrigen = Nothing
            objDocumentoVentaDet.idItem = r.GetValue("idProducto")
            objDocumentoVentaDet.DetalleItem = r.GetValue("item")
            objDocumentoVentaDet.nombreItem = r.GetValue("item")
            objDocumentoVentaDet.tipoExistencia = r.GetValue("tipoExistencia")
            objDocumentoVentaDet.destino = r.GetValue("gravado")
            objDocumentoVentaDet.unidad1 = r.GetValue("um")
            objDocumentoVentaDet.monto1 = CDec(r.GetValue("cantidad"))
            objDocumentoVentaDet.unidad2 = Nothing
            objDocumentoVentaDet.monto2 = Nothing ''CDec(r.GetValue("cantidad2")) '  Nothing 'i.Cells(31).Value()
            objDocumentoVentaDet.precioUnitario = CDec(r.GetValue("pumn"))
            objDocumentoVentaDet.precioUnitarioUS = CDec(r.GetValue("pume"))
            objDocumentoVentaDet.importeMN = CDec(r.GetValue("totalmn"))
            objDocumentoVentaDet.importeME = CDec(r.GetValue("totalme"))
            objDocumentoVentaDet.descuentoMN = 0
            objDocumentoVentaDet.descuentoME = 0

            objDocumentoVentaDet.montokardex = CDec(r.GetValue("vcmn"))
            objDocumentoVentaDet.montoIsc = 0
            objDocumentoVentaDet.montoIgv = CDec(r.GetValue("igvmn"))
            objDocumentoVentaDet.otrosTributos = 0
            '**********************************************************************************
            objDocumentoVentaDet.montokardexUS = CDec(r.GetValue("vcme"))
            objDocumentoVentaDet.montoIscUS = 0
            objDocumentoVentaDet.montoIgvUS = CDec(r.GetValue("igvme"))
            objDocumentoVentaDet.otrosTributosUS = 0
            objDocumentoVentaDet.estadoMovimiento = "V" 'ENTREGADO/COBRADO
            '**********************************************************************************
            objDocumentoVentaDet.importeMNK = CDec(r.GetValue("puKardex"))
            objDocumentoVentaDet.importeMEK = CDec(r.GetValue("pukardeme"))
            objDocumentoVentaDet.fechaVcto = txtFecha.Value
            objDocumentoVentaDet.estadoEntrega = TipoEntrega
            objDocumentoVentaDet.cantidadEntrega = CDec(r.GetValue("cantEntregar"))
            objDocumentoVentaDet.salidaCostoMN = CDec(r.GetValue("costoMN")) ' Math.Round(CDec(i.Cells(6).Value()) * CDec(i.Cells(5).Value()), 2)
            objDocumentoVentaDet.salidaCostoME = CDec(r.GetValue("costoME")) 'Math.Round(CDec(i.Cells(28).Value()) * CDec(i.Cells(5).Value()), 2)

            'If (TipoEntrega = TipoEntregado.PorEntregar) Then
            '    conteoCantidad = CDec(r.GetValue("cantEntregar"))
            'End If
            objDocumentoVentaDet.categoria = r.GetValue("cat")
            objDocumentoVentaDet.preEvento = Nothing
            objDocumentoVentaDet.usuarioModificacion = usuario.IDUsuario
            objDocumentoVentaDet.fechaModificacion = DateTime.Now
            objDocumentoVentaDet.Glosa = txtGlosa.Text.Trim
            objDocumentoVentaDet.NomMarca = Nothing ' r.GetValue("marca")
            GetDetalleVenta.Add(objDocumentoVentaDet)
        Next
    End Function

    Private Function GetGrabarVentaComprobante(DetalleVenta As List(Of documentoventaAbarrotesDet)) As documento
        Dim ndocumento As New documento()
        Dim DocCaja As New documento

        Dim ListaTotales As New List(Of totalesAlmacen)
        Dim docVentaSA As New documentoVentaAbarrotesSA

        Dim nDocumentoVenta As New documentoventaAbarrotes()
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        Dim asientoSA As New AsientoSA
        ' Dim ListaAsiento As New List(Of asiento)
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento

        Dim TipoCobro As String
        Dim proveedor As String
        Dim idProveedor As Integer

        Dim sumaVentaMN As Decimal = DetalleVenta.Sum(Function(o) o.importeMN).GetValueOrDefault
        Dim sumaVentaME As Decimal = DetalleVenta.Sum(Function(o) o.importeME).GetValueOrDefault
        Dim sumaBase1MN As Decimal =
            DetalleVenta.Where(Function(o) o.destino = OperacionGravada.Grabado).Sum(Function(o) o.montokardex).GetValueOrDefault

        Dim sumaBase1ME As Decimal =
            DetalleVenta.Where(Function(o) o.destino = OperacionGravada.Grabado).Sum(Function(o) o.montokardexUS).GetValueOrDefault

        Dim sumaBase2MN As Decimal =
            DetalleVenta.Where(Function(o) o.destino = OperacionGravada.Exonerado).Sum(Function(o) o.montokardex).GetValueOrDefault

        Dim sumaBase2ME As Decimal =
            DetalleVenta.Where(Function(o) o.destino = OperacionGravada.Exonerado).Sum(Function(o) o.montokardexUS).GetValueOrDefault

        Dim sumaIgvMN As Decimal = DetalleVenta.Sum(Function(o) o.montoIgv).GetValueOrDefault
        Dim sumaIgvME As Decimal = DetalleVenta.Sum(Function(o) o.montoIgvUS).GetValueOrDefault
        '-------------------------------------------------------------------------------------

        Dim tipoDocumentoVenta As String = Nothing
        Dim serieVenta As String = Nothing
        Dim numeroVenta As String = Nothing
        Dim NroDoc As String = Nothing

        Select Case chAutoNumeracion.Checked
            Case True
                Select Case cboTipoDoc.Text

                    Case "FACTURA ELECTRONICA", "BOLETA ELECTRONICA"
                        'tipoDocumentoVenta = If(cboTipoDoc.Text = "BOLETA ELECTRONICA", "03", "01")
                        'serieVenta = txtSerie.Text
                        'numeroVenta = txtNumero.Text
                        'NroDoc = String.Concat(txtSerie.Text.Trim, "-", txtNumero.Text.Trim)

                        tipoDocumentoVenta = GConfiguracion.TipoComprobante
                        serieVenta = GConfiguracion.Serie
                        numeroVenta = 1
                        NroDoc = GConfiguracion.Serie

                    Case Else

                        tipoDocumentoVenta = GConfiguracion.TipoComprobante
                        serieVenta = GConfiguracion.Serie
                        numeroVenta = 1
                        NroDoc = GConfiguracion.Serie

                End Select
            Case False
                tipoDocumentoVenta = If(cboTipoDoc.Text = "BOLETA", "03", "01")
                serieVenta = txtSerie.Text.Trim
                numeroVenta = txtNumero.Text.Trim
                NroDoc = String.Concat(txtSerie.Text.Trim, "-", txtNumero.Text.Trim)
        End Select


        ndocumento = New documento
        ndocumento.Action = BaseBE.EntityAction.INSERT
        ndocumento.IsFormatoGeneral = If(chAutoNumeracion.Checked, False, True)
        ndocumento.idEmpresa = Gempresas.IdEmpresaRuc
        ndocumento.idCentroCosto = GEstableciento.IdEstablecimiento
        ndocumento.tipoDoc = tipoDocumentoVenta 'conf.TipoComprobante
        ndocumento.fechaProceso = txtFecha.Value
        ndocumento.nroDoc = NroDoc ' conf.Serie
        ndocumento.moneda = "1"

        If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            ndocumento.entidad = TXTcOMPRADOR.Text
            ndocumento.nrodocEntidad = txtruc.Text
            ndocumento.idEntidad = Val(TXTcOMPRADOR.Tag)
        Else
            ndocumento.entidad = TXTcOMPRADOR.Text
            ndocumento.nrodocEntidad = 0
            ndocumento.idEntidad = Val(0)
        End If
        ndocumento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        ndocumento.tipoOperacion = StatusTipoOperacion.VENTA
        ndocumento.usuarioActualizacion = usuario.IDUsuario
        ndocumento.fechaActualizacion = DateTime.Now
        TipoCobro = TIPO_VENTA.PAGO.COBRADO
        Dim TipoEntrega = TipoEntregado.Entregado
        Dim tipoEstado = TipoGuia.Entregado

        If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            proveedor = TXTcOMPRADOR.Text
            idProveedor = CInt(TXTcOMPRADOR.Tag)
        Else
            proveedor = TXTcOMPRADOR.Text
            idProveedor = 0
        End If

        nDocumentoVenta = New documentoventaAbarrotes With {
            .horaVenta = txtFecha.Value.TimeOfDay.ToString(),
                  .TipoConfiguracion = If(GConfiguracion Is Nothing, Nothing, GConfiguracion.TipoConfiguracion),
                  .IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante),
                  .tipoOperacion = StatusTipoOperacion.VENTA,
                  .codigoLibro = "14",
                  .tipoDocumento = tipoDocumentoVenta,
                  .idEmpresa = Gempresas.IdEmpresaRuc,
                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                  .fechaDoc = txtFecha.Value,
                  .fechaConfirmacion = txtFecha.Value,
                  .fechaPeriodo = lblPerido.Text,
                  .serie = serieVenta,
                  .serieVenta = serieVenta,
                  .numeroDocNormal = Nothing,
                  .numeroVenta = numeroVenta,
                  .idCliente = CInt(idProveedor),
                  .idClientePedido = CInt(idProveedor),
                  .nombrePedido = proveedor,
                  .moneda = "1",
                  .tasaIgv = TmpIGV,
                  .tipoCambio = TmpTipoCambio,
                  .bi01 = sumaBase1MN,
                  .bi02 = sumaBase2MN,
                  .igv01 = sumaIgvMN,
                  .igv02 = 0,
                  .bi01us = sumaBase1ME,
                  .bi02us = sumaBase2ME,
                  .igv01us = sumaIgvME,
                  .igv02us = 0,
                  .ImporteNacional = sumaVentaMN,
                  .ImporteExtranjero = sumaVentaME,
                  .tipoVenta = TipoVentaGeneral, 'TIPO_VENTA.VENTA_POS_DIRECTA,
                  .estadoCobro = TipoCobro,
                  .estadoEntrega = TipoEntrega,
                  .terminos = "CONTADO",
                  .glosa = txtGlosa.Text.Trim,
                  .fechaVcto = txtFecha.Value,
                  .estado = StatusNotaDeVentas.Sustentado,
                  .usuarioActualizacion = usuario.IDUsuario,
                  .fechaActualizacion = DateTime.Now}
        'tipoEstado,
        ndocumento.documentoventaAbarrotes = nDocumentoVenta

        ndocumento.documentoventaAbarrotes.documentoventaAbarrotesDet = DetalleVenta

        '--------------------------------------------------------------------------------------
        Dim listaExistencias As List(Of documentoventaAbarrotesDet) = (From n In DetalleVenta
                                                                       Where n.tipoExistencia <> TipoRecurso.SERVICIO).ToList
        If listaExistencias.Count > 0 Then
            AsientoVenta(listaExistencias)
        End If

        Dim listaServicios As List(Of documentoventaAbarrotesDet) = (From n In DetalleVenta
                                                                     Where n.tipoExistencia = TipoRecurso.SERVICIO).ToList

        If listaServicios.Count > 0 Then
            AsientoVentaServicios(listaServicios)
        End If

        GuiaRemisionGenerico(ndocumento)

        If ChPagoDirecto.Checked Then
            ndocumento.ListaCustomDocumento = ListaDocumentoCajaGenerico(ndocumento.documentoventaAbarrotes)
            ndocumento.documentoventaAbarrotes.estadoCobro = TIPO_VENTA.PAGO.COBRADO
            ndocumento.documentoventaAbarrotes.terminos = "CONTADO"
        ElseIf ChPagoAvanzado.Checked = True Then
            Dim f As New frmFormatoPagoComprobantes
            f.txtMontoXcobrar.Text = txtTotalPagar.DecimalValue
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            If f.Tag IsNot Nothing Then
                Dim c = CType(f.Tag, List(Of documentoCaja))
                If c.Count > 0 Then
                    Dim ListaPagos = ListaPagosCajas(c, ndocumento.documentoventaAbarrotes, ndocumento.documentoventaAbarrotes.documentoventaAbarrotesDet)
                    Dim SumaPagos As Decimal = 0
                    For Each i In ListaPagos
                        SumaPagos += i.documentoCaja.montoSoles.GetValueOrDefault
                    Next
                    If SumaPagos = txtTotalPagar.DecimalValue Then
                        ndocumento.documentoventaAbarrotes.terminos = "CONTADO"
                    Else
                        'ndocumento.documentoventaAbarrotes.terminos = "PARCIAL"
                        ndocumento.documentoventaAbarrotes.terminos = "CREDITO"
                    End If
                    ndocumento.documentoventaAbarrotes.estadoCobro = ndocumento.documentoventaAbarrotes.GetEstadoPagoComprobante
                    ndocumento.ListaCustomDocumento = ListaPagos 'ListaPagosCajas(c)
                Else
                    Throw New Exception("Debe realizar el pago del comprobante")
                End If
            Else
                Throw New Exception("Debe realizar el pago del comprobante")
            End If
        Else
            ndocumento.documentoventaAbarrotes.estadoCobro = "PN"
            ndocumento.documentoventaAbarrotes.terminos = "CREDITO"
        End If

        ndocumento.asiento = ListaAsientonTransito
        Return ndocumento
    End Function

    Sub Grabar()

        Dim ndocumento As New documento()
        Dim DocCaja As New documento

        Dim ListaTotales As New List(Of totalesAlmacen)
        Dim docVentaSA As New documentoVentaAbarrotesSA

        Dim nDocumentoVenta As New documentoventaAbarrotes()
        Dim objDocumentoVentaDet As New documentoventaAbarrotesDet
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        Dim asientoSA As New AsientoSA
        ' Dim ListaAsiento As New List(Of asiento)
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento

        Dim ListaDetalle As New List(Of documentoventaAbarrotesDet)

        Dim TipoCobro As String

        Dim proveedor As String
        Dim idProveedor As Integer
        Dim conteoCantidad As Integer
        '-------------------------------------------------------------------------------------
        ndocumento = New documento
        ndocumento.Action = Business.Entity.BaseBE.EntityAction.INSERT
        ndocumento.idEmpresa = Gempresas.IdEmpresaRuc
        ndocumento.idCentroCosto = GEstableciento.IdEstablecimiento
        ndocumento.tipoDoc = GConfiguracion.TipoComprobante
        ndocumento.fechaProceso = txtFecha.Value
        ndocumento.nroDoc = GConfiguracion.Serie
        ndocumento.moneda = "1"

        If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            ndocumento.entidad = TXTcOMPRADOR.Text
            ndocumento.nrodocEntidad = txtruc.Text
            ndocumento.idEntidad = Val(TXTcOMPRADOR.Tag)
        Else
            ndocumento.entidad = TXTcOMPRADOR.Text
            ndocumento.nrodocEntidad = 0
            ndocumento.idEntidad = Val(0)
        End If
        ndocumento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        ndocumento.tipoOperacion = StatusTipoOperacion.VENTA
        ndocumento.usuarioActualizacion = usuario.IDUsuario
        ndocumento.fechaActualizacion = DateTime.Now
        TipoCobro = TIPO_VENTA.PAGO.COBRADO
        Dim TipoEntrega = TipoEntregado.Entregado
        Dim tipoEstado = TipoGuia.Entregado

        If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            proveedor = TXTcOMPRADOR.Text
            idProveedor = CInt(TXTcOMPRADOR.Tag)
        Else
            proveedor = TXTcOMPRADOR.Text
            idProveedor = 0
        End If


        nDocumentoVenta = New documentoventaAbarrotes With {
                  .TipoConfiguracion = GConfiguracion.TipoConfiguracion,
                  .IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante),
                  .tipoOperacion = StatusTipoOperacion.VENTA,
                  .codigoLibro = "14",
                  .tipoDocumento = GConfiguracion.TipoComprobante,
                  .idEmpresa = Gempresas.IdEmpresaRuc,
                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                  .fechaDoc = txtFecha.Value,
                  .fechaPeriodo = lblPerido.Text,
                  .serie = GConfiguracion.Serie,
                  .numeroDocNormal = Nothing,
                  .idCliente = CInt(idProveedor),
                  .idClientePedido = CInt(idProveedor),
                  .nombrePedido = proveedor,
                  .moneda = "1",
                  .tasaIgv = TmpIGV,
                  .tipoCambio = TmpTipoCambio,
                  .bi01 = TotalesXcanbeceras.base1,
                  .bi02 = TotalesXcanbeceras.base2,
                  .igv01 = TotalesXcanbeceras.MontoIgv1,
                  .igv02 = TotalesXcanbeceras.MontoIgv2,
                  .bi01us = TotalesXcanbeceras.base1me,
                  .bi02us = TotalesXcanbeceras.base2me,
                  .igv01us = TotalesXcanbeceras.MontoIgv1me,
                  .igv02us = TotalesXcanbeceras.MontoIgv2me,
                  .ImporteNacional = TotalesXcanbeceras.TotalMN,
                  .ImporteExtranjero = TotalesXcanbeceras.TotalME,
                  .tipoVenta = TIPO_VENTA.VENTA_POS_DIRECTA,
                  .estadoCobro = TipoCobro,
                  .estadoEntrega = TipoEntrega,
                  .terminos = "CONTADO",
                  .glosa = txtGlosa.Text.Trim,
                  .fechaVcto = txtFecha.Value,
                  .usuarioActualizacion = usuario.IDUsuario,
                  .fechaActualizacion = DateTime.Now}
        'tipoEstado,
        ndocumento.documentoventaAbarrotes = nDocumentoVenta

        'REGISTRANDO LA GUIA DE REMISION
        'GuiaRemision(ndocumento)

        For Each r As Record In dgvCompra.Table.Records

            If CDec(r.GetValue("cantidad")) <= 0 Then
                'MessageBoxAdv.Show("Debe ingresar un cantidad mayor a cero.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Question)
                Throw New Exception("Debe ingresar un cantidad mayor a cero.")
                'Exit Sub
            End If

            If CDec(r.GetValue("totalmn")) <= 0 Then
                Throw New Exception("El importe de venta debe ser mayor a cero.")
                '  MessageBoxAdv.Show("El importe de venta debe ser mayor a cero.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Question)
                '  Exit Sub
            End If
            objDocumentoVentaDet = New documentoventaAbarrotesDet
            objDocumentoVentaDet.codigoLote = Integer.Parse(r.GetValue("codigoLote"))
            If ChPagoDirecto.Checked Then
                objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.COBRADO
            ElseIf ChPagoAvanzado.Checked Then
                If CDec(r.GetValue("MontoSaldo")) <= 0 Then
                    objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.COBRADO
                Else
                    objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.PENDIENTE_PAGO
                End If
            Else
                objDocumentoVentaDet.estadoPago = TIPO_VENTA.PAGO.PENDIENTE_PAGO
            End If

            objDocumentoVentaDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoVentaDet.IdEstablecimiento = GEstableciento.IdEstablecimiento ' almacenSA.GetUbicar_almacenPorID(i.Cells(24).Value()).idEstablecimiento
            objDocumentoVentaDet.FechaDoc = txtFecha.Value
            objDocumentoVentaDet.Serie = GConfiguracion.Serie
            objDocumentoVentaDet.NumDoc = GConfiguracion.Serie
            objDocumentoVentaDet.TipoDoc = GConfiguracion.TipoComprobante
            If r.GetValue("tipoExistencia") = "GS" Then
                objDocumentoVentaDet.idAlmacenOrigen = Nothing
                objDocumentoVentaDet.tipoVenta = r.GetValue("tipoPrecio")
            Else
                objDocumentoVentaDet.idAlmacenOrigen = CInt(r.GetValue("almacen"))
                objDocumentoVentaDet.tipoVenta = r.GetValue("tipoPrecio")
            End If
            objDocumentoVentaDet.establecimientoOrigen = GEstableciento.IdEstablecimiento
            objDocumentoVentaDet.cuentaOrigen = Nothing
            objDocumentoVentaDet.idItem = r.GetValue("idProducto")
            objDocumentoVentaDet.DetalleItem = r.GetValue("item")
            objDocumentoVentaDet.tipoExistencia = r.GetValue("tipoExistencia")
            objDocumentoVentaDet.destino = r.GetValue("gravado")
            objDocumentoVentaDet.unidad1 = r.GetValue("um")
            objDocumentoVentaDet.monto1 = CDec(r.GetValue("cantidad"))
            objDocumentoVentaDet.unidad2 = Nothing
            objDocumentoVentaDet.monto2 = Nothing 'i.Cells(31).Value()
            objDocumentoVentaDet.precioUnitario = CDec(r.GetValue("pumn"))
            objDocumentoVentaDet.precioUnitarioUS = CDec(r.GetValue("pume"))
            objDocumentoVentaDet.importeMN = CDec(r.GetValue("totalmn"))
            objDocumentoVentaDet.importeME = CDec(r.GetValue("totalme"))
            objDocumentoVentaDet.descuentoMN = 0
            objDocumentoVentaDet.descuentoME = 0

            objDocumentoVentaDet.montokardex = CDec(r.GetValue("vcmn"))
            objDocumentoVentaDet.montoIsc = 0
            objDocumentoVentaDet.montoIgv = CDec(r.GetValue("igvmn"))
            objDocumentoVentaDet.otrosTributos = 0
            '**********************************************************************************
            objDocumentoVentaDet.montokardexUS = CDec(r.GetValue("vcme"))
            objDocumentoVentaDet.montoIscUS = 0
            objDocumentoVentaDet.montoIgvUS = CDec(r.GetValue("igvme"))
            objDocumentoVentaDet.otrosTributosUS = 0
            objDocumentoVentaDet.estadoMovimiento = "V" 'ENTREGADO/COBRADO
            '**********************************************************************************
            objDocumentoVentaDet.importeMNK = CDec(r.GetValue("puKardex"))
            objDocumentoVentaDet.importeMEK = CDec(r.GetValue("pukardeme"))
            objDocumentoVentaDet.fechaVcto = txtFecha.Value
            objDocumentoVentaDet.estadoEntrega = TipoEntrega
            objDocumentoVentaDet.cantidadEntrega = CDec(r.GetValue("cantEntregar"))
            objDocumentoVentaDet.salidaCostoMN = CDec(r.GetValue("costoMN")) ' Math.Round(CDec(i.Cells(6).Value()) * CDec(i.Cells(5).Value()), 2)
            objDocumentoVentaDet.salidaCostoME = CDec(r.GetValue("costoME")) 'Math.Round(CDec(i.Cells(28).Value()) * CDec(i.Cells(5).Value()), 2)

            If (TipoEntrega = TipoEntregado.PorEntregar) Then
                conteoCantidad = CDec(r.GetValue("cantEntregar"))
            End If
            objDocumentoVentaDet.categoria = r.GetValue("cat")
            objDocumentoVentaDet.preEvento = Nothing
            objDocumentoVentaDet.usuarioModificacion = usuario.IDUsuario
            objDocumentoVentaDet.fechaModificacion = DateTime.Now
            objDocumentoVentaDet.Glosa = txtGlosa.Text.Trim
            ListaDetalle.Add(objDocumentoVentaDet)
        Next
        'Dim GetVentaLista As New List(Of documentoventaAbarrotesDet)

        'GetVentaLista = (From c In ListaDetalle
        '                 Group c By
        '                        c.idDocumento,
        '                        c.codigoLote,
        '                        c.estadoPago,
        '                        c.IdEmpresa,
        '                        c.IdEstablecimiento,
        '                        c.FechaDoc,
        '                        c.Serie,
        '                        c.NumDoc,
        '                        c.TipoDoc,
        '                        c.idAlmacenOrigen,
        '                        c.tipoVenta,
        '                        c.establecimientoOrigen,
        '                        c.cuentaOrigen,
        '                        c.idItem,
        '                        c.DetalleItem,
        '                        c.tipoExistencia,
        '                        c.destino,
        '                        c.unidad1,
        '                        c.monto1,
        '                        c.unidad2,
        '                        c.monto2,
        '                        c.precioUnitario,
        '                        c.precioUnitarioUS,
        '                        c.importeMN,
        '                        c.importeME,
        '                        c.descuentoMN,
        '                        c.descuentoME,
        '                        c.montokardex,
        '                        c.montoIsc,
        '                        c.montoIgv,
        '                        c.otrosTributos,
        '                        c.montokardexUS,
        '                        c.montoIscUS,
        '                        c.montoIgvUS,
        '                        c.otrosTributosUS,
        '                        c.estadoMovimiento,
        '                        c.importeMNK,
        '                        c.importeMEK,
        '                        c.fechaVcto,
        '                        c.estadoEntrega,
        '                        c.cantidadEntrega,
        '                        c.salidaCostoMN,
        '                        c.salidaCostoME,
        '                        c.categoria,
        '                        c.preEvento,
        '                        c.usuarioModificacion,
        '                        c.fechaModificacion,
        '                        c.Glosa
        '                        Into g = Group
        '                 Select
        '                         idDocumento,
        '                         codigoLote,
        '                        estadoPago,
        '                        IdEmpresa,
        '                        IdEstablecimiento,
        '                        FechaDoc,
        '                        Serie,
        '                        NumDoc,
        '                        TipoDoc,
        '                        idAlmacenOrigen,
        '                        tipoVenta,
        '                        establecimientoOrigen,
        '                        cuentaOrigen,
        '                        idItem,
        '                        DetalleItem,
        '                        tipoExistencia,
        '                        destino,
        '                        unidad1,
        '                        unidad2,
        '                        monto2,
        '                        precioUnitario,
        '                        precioUnitarioUS,
        '                        descuentoMN,
        '                        descuentoME,
        '                        montokardex,
        '                        montoIsc,
        '                        montoIgv,
        '                        otrosTributos,
        '                        montokardexUS,
        '                        montoIscUS,
        '                        montoIgvUS,
        '                        otrosTributosUS,
        '                        estadoMovimiento,
        '                        importeMNK,
        '                        importeMEK,
        '                        fechaVcto,
        '                        estadoEntrega,
        '                        cantidadEntrega,
        '                        salidaCostoMN,
        '                        salidaCostoME,
        '                        categoria,
        '                        preEvento,
        '                        usuarioModificacion,
        '                        fechaModificacion,
        '                        Glosa,
        '                        cantidad = CType(g.Sum(Function(p) p.monto1), Decimal?),
        '                        MontoMN = CType(g.Sum(Function(p) p.importeMN), Decimal?),
        '                        MontoME = CType(g.Sum(Function(p) p.importeME), Decimal?)).ToList


        ndocumento.documentoventaAbarrotes.documentoventaAbarrotesDet = ListaDetalle

        Dim listaExistencias As List(Of documentoventaAbarrotesDet) = (From n In ListaDetalle
                                                                       Where n.tipoExistencia <> TipoRecurso.SERVICIO).ToList
        If listaExistencias.Count > 0 Then
            AsientoVenta(listaExistencias)
        End If

        Dim listaServicios As List(Of documentoventaAbarrotesDet) = (From n In ListaDetalle
                                                                     Where n.tipoExistencia = TipoRecurso.SERVICIO).ToList

        If listaServicios.Count > 0 Then
            AsientoVentaServicios(listaServicios)
        End If

        GuiaRemision(ndocumento)

        If ChPagoDirecto.Checked Then
            ndocumento.ListaCustomDocumento = ListaDocumentoCaja(ndocumento.documentoventaAbarrotes)
            ndocumento.documentoventaAbarrotes.estadoCobro = TIPO_VENTA.PAGO.COBRADO
            ndocumento.documentoventaAbarrotes.terminos = "CONTADO"
        ElseIf ChPagoAvanzado.Checked = True Then
            Dim f As New frmFormatoPagoComprobantes
            f.txtMontoXcobrar.Text = txtTotalPagar.DecimalValue
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            If f.Tag IsNot Nothing Then
                Dim c = CType(f.Tag, List(Of documentoCaja))
                If c.Count > 0 Then
                    Dim ListaPagos = ListaPagosCajas(c, ndocumento.documentoventaAbarrotes, ndocumento.documentoventaAbarrotes.documentoventaAbarrotesDet)
                    Dim SumaPagos As Decimal = 0
                    For Each i In ListaPagos
                        SumaPagos += i.documentoCaja.montoSoles.GetValueOrDefault
                    Next
                    If SumaPagos = txtTotalPagar.DecimalValue Then
                        ndocumento.documentoventaAbarrotes.terminos = "CONTADO"
                    Else
                        'ndocumento.documentoventaAbarrotes.terminos = "PARCIAL"
                        ndocumento.documentoventaAbarrotes.terminos = "CREDITO"
                    End If
                    ndocumento.documentoventaAbarrotes.estadoCobro = ndocumento.documentoventaAbarrotes.GetEstadoPagoComprobante
                    ndocumento.ListaCustomDocumento = ListaPagos 'ListaPagosCajas(c)
                Else
                    MessageBox.Show("Debe realizar el pago del comprobante", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            Else
                MessageBox.Show("Debe realizar el pago del comprobante", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        Else
            ndocumento.documentoventaAbarrotes.estadoCobro = "PN"
            ndocumento.documentoventaAbarrotes.terminos = "CREDITO"
        End If


        Dim idDocuentoGrabado As Integer
        If ListaDetalle.Where(Function(o) o.monto1 = 0).Count = 0 Then
            ndocumento.asiento = ListaAsientonTransito
            idDocuentoGrabado = VentaSA.Grabar_Venta(ndocumento)
            If MessageBox.Show("Desea imprimir ticket ?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                ImprimirTicket(idDocuentoGrabado)
            End If
            LimpiarControles()
            ChPagoDirecto.Checked = True
            ChPagoAvanzado.Checked = False
            PagoDirectoCheck()
            Alert = New Alert("Venta registrada", alertType.success)
            Alert.TopMost = True
            Alert.Show()
        Else
            Throw New Exception("Debe verificar que las celdas estan completas!")
        End If
    End Sub

    Private Sub GetReiniciarPagos()
        For Each i In dgvCompra.Table.Records
            i.SetValue("MontoSaldo", i.GetValue("totalmn"))
        Next
    End Sub




    Private Sub LimpiarControles()
        TXTcOMPRADOR.Clear()
        txtruc.Clear()
        dgvCompra.DataSource = New DataTable
        txtTotalBase.DecimalValue = 0
        txtTotalBase2.DecimalValue = 0
        txtTotalBase3.DecimalValue = 0
        txtTotalIva.DecimalValue = 0
        lblTotalPercepcion.DecimalValue = 0
        txtVentaTotal.DecimalValue = 0
        TXTcOMPRADOR.Clear()
        txtSerie.Text = ""
        txtNumero.Text = ""
        txtTotalPagar.DecimalValue = 0
        DigitalGauge2.Text = "0.00"
        DigitalGauge2.Value = "0.00"
        GetTableGrid()
        txtFecha.Value = Date.Now
        ConteoLabelVentas()
    End Sub

    Public Function ListaPagosCajas(lista As List(Of documentoCaja), venta As documentoventaAbarrotes, ventaDetalle As List(Of documentoventaAbarrotesDet)) As List(Of documento)
        Dim nDocumentoCaja As New documento
        Dim objCaja As New documentoCaja
        Dim ListaDoc As New List(Of documento)
        For Each i In lista

            nDocumentoCaja = New documento
            nDocumentoCaja.idDocumento = CInt(Me.Tag)
            nDocumentoCaja.idEmpresa = Gempresas.IdEmpresaRuc
            nDocumentoCaja.idCentroCosto = GEstableciento.IdEstablecimiento
            nDocumentoCaja.tipoDoc = venta.tipoDocumento ' cbotipoDocPago.SelectedValue
            nDocumentoCaja.fechaProceso = txtFecha.Value
            nDocumentoCaja.nroDoc = GConfiguracion.Serie
            nDocumentoCaja.idOrden = Nothing
            nDocumentoCaja.moneda = 1
            If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
                nDocumentoCaja.idEntidad = Val(TXTcOMPRADOR.Tag)
                nDocumentoCaja.entidad = TXTcOMPRADOR.Text
                nDocumentoCaja.nrodocEntidad = txtruc.Text
            Else
                nDocumentoCaja.entidad = TXTcOMPRADOR.Text
                nDocumentoCaja.nrodocEntidad = 0
                nDocumentoCaja.idEntidad = Val(0)
            End If
            nDocumentoCaja.tipoEntidad = TIPO_ENTIDAD.CLIENTE
            nDocumentoCaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES
            nDocumentoCaja.usuarioActualizacion = usuario.IDUsuario
            nDocumentoCaja.fechaActualizacion = DateTime.Now


            'DOCUMENTO CAJA
            objCaja = New documentoCaja
            objCaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES
            objCaja.idDocumento = 0
            objCaja.periodo = lblPerido.Text
            objCaja.idEmpresa = Gempresas.IdEmpresaRuc
            objCaja.idEstablecimiento = GEstableciento.IdEstablecimiento
            objCaja.fechaProceso = txtFecha.Value
            objCaja.fechaCobro = txtFecha.Value
            objCaja.tipoMovimiento = TIPO_VENTA.PAGO.COBRADO
            If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
                objCaja.codigoProveedor = Integer.Parse(TXTcOMPRADOR.Tag)
                objCaja.IdProveedor = Integer.Parse(TXTcOMPRADOR.Tag)
                objCaja.idPersonal = Integer.Parse(TXTcOMPRADOR.Tag)
            End If
            objCaja.TipoDocumentoPago = venta.tipoDocumento 'cbotipoDocPago.SelectedValue
            objCaja.codigoLibro = "1"
            objCaja.tipoDocPago = venta.tipoDocumento
            objCaja.formapago = i.formapago
            objCaja.NumeroDocumento = "-"
            objCaja.numeroOperacion = "-"
            Select Case venta.tipoDocumento
                Case "9907"
                    objCaja.movimientoCaja = TIPO_VENTA.NOTA_DE_VENTA
                Case Else
                    objCaja.movimientoCaja = TipoVentaGeneral 'TIPO_VENTA.VENTA_POS_DIRECTA,
            End Select
            objCaja.montoSoles = Decimal.Parse(i.montoSoles)

            objCaja.moneda = 1
            objCaja.tipoCambio = TmpTipoCambio
            objCaja.montoUsd = Decimal.Parse(objCaja.montoSoles / TmpTipoCambio)

            objCaja.estado = "1"
            objCaja.glosa = "Por ventas POS directa del cliente: " & TXTcOMPRADOR.Text & "con tipo Doc. " & cboTipoDoc.Text & ", fecha de venta " & txtFecha.Value
            objCaja.entregado = "SI"

            objCaja.idCajaUsuario = GFichaUsuarios.IdCajaUsuario
            objCaja.entidadFinanciera = i.IdEntidadFinanciera
            objCaja.NombreEntidad = i.NomCajaOrigen
            objCaja.usuarioModificacion = usuario.IDUsuario
            objCaja.fechaModificacion = DateTime.Now
            nDocumentoCaja.documentoCaja = objCaja
            nDocumentoCaja.documentoCaja.documentoCajaDetalle = GetDetallePago(objCaja, ventaDetalle)
            asientoDocumento(nDocumentoCaja.documentoCaja)
            ListaDoc.Add(nDocumentoCaja)
        Next

        Return ListaDoc
    End Function

    'Public Function ListaPagosCajas(lista As List(Of documentoCaja)) As List(Of documento)
    '    Dim entidadSA As New entidadSA
    '    Dim nDocumentoCaja As New documento
    '    Dim objCaja As New documentoCaja
    '    Dim ListaDoc As New List(Of documento)
    '    Dim r As Record = dgvCompra.Table.CurrentRecord
    '    For Each i In lista

    '        nDocumentoCaja = New documento
    '        nDocumentoCaja.idDocumento = CInt(Me.Tag)
    '        nDocumentoCaja.idEmpresa = Gempresas.IdEmpresaRuc
    '        nDocumentoCaja.idCentroCosto = GEstableciento.IdEstablecimiento
    '        nDocumentoCaja.tipoDoc = conf.TipoComprobante ' cbotipoDocPago.SelectedValue
    '        nDocumentoCaja.fechaProceso = venta.fechaDoc
    '        nDocumentoCaja.nroDoc = conf.Serie
    '        nDocumentoCaja.idOrden = Nothing
    '        nDocumentoCaja.moneda = 1

    '        Dim cliente = entidadSA.GetUbicarEntPorID(Gempresas.IdEmpresaRuc, venta.idCliente)
    '        If cliente IsNot Nothing Then
    '            nDocumentoCaja.idEntidad = cliente.idEntidad
    '            nDocumentoCaja.entidad = cliente.nombreCompleto
    '            nDocumentoCaja.nrodocEntidad = cliente.nrodoc
    '        Else
    '            nDocumentoCaja.idEntidad = "0"
    '            nDocumentoCaja.entidad = "Clientes varios"
    '            nDocumentoCaja.nrodocEntidad = "-"
    '        End If
    '        nDocumentoCaja.tipoEntidad = TIPO_ENTIDAD.CLIENTE
    '        nDocumentoCaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES
    '        nDocumentoCaja.usuarioActualizacion = usuario.IDUsuario
    '        nDocumentoCaja.fechaActualizacion = DateTime.Now

    '        '  documento CAJA
    '        objCaja = New documentoCaja
    '        objCaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES
    '        objCaja.idDocumento = 0
    '        objCaja.periodo = venta.fechaPeriodo
    '        objCaja.idEmpresa = Gempresas.IdEmpresaRuc
    '        objCaja.idEstablecimiento = GEstableciento.IdEstablecimiento
    '        objCaja.fechaProceso = venta.fechaDoc
    '        objCaja.fechaCobro = DateTime.Now
    '        objCaja.tipoMovimiento = TIPO_VENTA.PAGO.COBRADO

    '        If cliente IsNot Nothing Then
    '            objCaja.codigoProveedor = cliente.idEntidad
    '            objCaja.IdProveedor = cliente.idEntidad
    '            objCaja.idPersonal = Integer.Parse(cliente.idEntidad)
    '        End If

    '        objCaja.TipoDocumentoPago = conf.TipoComprobante 'cbotipoDocPago.SelectedValue
    '        objCaja.codigoLibro = "1"
    '        objCaja.tipoDocPago = conf.TipoComprobante
    '        objCaja.formapago = i.formapago
    '        objCaja.NumeroDocumento = "-"
    '        objCaja.numeroOperacion = "-"
    '        objCaja.movimientoCaja = TIPO_VENTA.VENTA_POS_DIRECTA
    '        objCaja.montoSoles = Decimal.Parse(i.montoSoles)

    '        objCaja.moneda = venta.moneda
    '        objCaja.tipoCambio = TmpTipoCambio
    '        objCaja.montoUsd = Decimal.Parse(objCaja.montoSoles / TmpTipoCambio)

    '        objCaja.estado = "P"
    '        objCaja.glosa = "Por ventas con ticket"
    '        objCaja.entregado = "SI"

    '        objCaja.idCajaUsuario = GFichaUsuarios.IdCajaUsuario
    '        objCaja.entidadFinanciera = i.IdEntidadFinanciera
    '        objCaja.NombreEntidad = i.NomCajaOrigen
    '        objCaja.usuarioModificacion = usuario.IDUsuario
    '        objCaja.fechaModificacion = DateTime.Now
    '        nDocumentoCaja.documentoCaja = objCaja
    '        nDocumentoCaja.documentoCaja.documentoCajaDetalle = GetDetallePago(objCaja)
    '        asientoDocumento(nDocumentoCaja.documentoCaja)
    '        ListaDoc.Add(nDocumentoCaja)
    '    Next

    '    Return ListaDoc
    'End Function

    'Private Function GetDetallePago(objCaja As documentoCaja) As List(Of documentoCajaDetalle)
    '    Dim montoPago = objCaja.montoSoles
    '    GetDetallePago = New List(Of documentoCajaDetalle)
    '    For Each i In dgvCompra.Table.Records
    '        If montoPago > 0 Then
    '            If CDec(i.GetValue("MontoSaldo")) > 0 Then
    '                Dim ImporteDisponible = CDec(i.GetValue("MontoSaldo"))
    '                Dim ImportetDisponibleRow As Decimal = i.GetValue("MontoSaldo")

    '                Dim calculoCelda = ImporteDisponible - montoPago
    '                If calculoCelda <= 0 Then
    '                    i.SetValue("MontoSaldo", 0)
    '                    i.SetValue("MontoPago", ImporteDisponible)
    '                Else
    '                    i.SetValue("MontoSaldo", calculoCelda)
    '                    If ImporteDisponible > montoPago Then
    '                        Dim canUso = montoPago
    '                        i.SetValue("MontoPago", canUso)
    '                    Else
    '                        Dim canUso = ImporteDisponible
    '                        i.SetValue("MontoPago", canUso)
    '                    End If
    '                End If
    '                montoPago -= ImporteDisponible

    '                GetDetallePago.Add(New documentoCajaDetalle With
    '                               {
    '                               .fecha = Date.Now,
    '                               .idItem = CInt(i.GetValue("idProducto")),
    '                               .DetalleItem = i.GetValue("item"),
    '                               .montoSoles = FormatNumber(Decimal.Parse(i.GetValue("MontoPago")), 2),
    '                               .montoUsd = FormatNumber(Decimal.Parse(i.GetValue("MontoPago") / TmpTipoCambio), 2),
    '                               .diferTipoCambio = TmpTipoCambio,
    '                               .tipoCambioTransacc = TmpTipoCambio,
    '                               .entregado = "SI",
    '                               .idCajaUsuario = GFichaUsuarios.IdCajaUsuario,
    '                               .usuarioModificacion = usuario.IDUsuario,
    '                               .documentoAfectado = CInt(Me.Tag),
    '                               .fechaModificacion = DateTime.Now
    '                               })
    '            End If
    '        End If
    '    Next
    'End Function

    Private Function GetDetallePago(objCaja As documentoCaja, ventaDetalle As List(Of documentoventaAbarrotesDet)) As List(Of documentoCajaDetalle)
        Dim montoPago = objCaja.montoSoles
        GetDetallePago = New List(Of documentoCajaDetalle)
        For Each i In ventaDetalle
            If montoPago > 0 Then
                If i.MontoSaldo > 0 Then
                    If i.MontoSaldo > montoPago Then
                        Dim canUso = montoPago
                        i.MontoPago = canUso
                        i.estadoPago = i.ItemPendiente
                    ElseIf i.MontoSaldo = montoPago Then
                        i.MontoPago = montoPago
                        i.estadoPago = i.ItemSaldado
                    Else
                        Dim canUso = i.MontoSaldo
                        i.MontoPago = canUso
                        i.estadoPago = i.ItemSaldado
                    End If
                    montoPago -= i.MontoPago 'ImporteDisponible

                    '.codigoLote = Integer.Parse(i.codigoLote),

                    GetDetallePago.Add(New documentoCajaDetalle With
                                   {
                                   .fecha = Date.Now,
                                   .codigoLote = 0,
                                   .otroMN = 0,
                                   .idItem = i.idItem,
                                   .DetalleItem = i.DetalleItem,
                                   .montoSoles = i.MontoPago,
                                   .montoUsd = FormatNumber(i.MontoPago / TmpTipoCambio, 2),
                                   .diferTipoCambio = TmpTipoCambio,
                                   .tipoCambioTransacc = TmpTipoCambio,
                                   .entregado = "SI",
                                   .idCajaUsuario = GFichaUsuarios.IdCajaUsuario,
                                   .usuarioModificacion = usuario.IDUsuario,
                                   .documentoAfectado = CInt(Me.Tag),
                                   .documentoAfectadodetalle = i.secuencia,
                                   .EstadoCobro = i.estadoPago,
                                   .fechaModificacion = DateTime.Now
                                   })
                    i.estadoPago = i.estadoPago
                    'Dim item = ventaDetalle.Where(Function(o) o.secuencia = i.secuencia).Single
                    'item.estadoPago = i.EstadoPagos
                End If
            End If
        Next
    End Function

    Function ListaDocumentoCaja(VENTA As documentoventaAbarrotes) As List(Of documento)
        Dim nDocumentoCaja As New documento
        Dim objCaja As New documentoCaja
        Dim ListaDoc As New List(Of documento)

        Dim tipoDocumento As String = Nothing
        Dim serieVenta As String = Nothing
        Dim numeroVenta As String = Nothing

        Select Case VENTA.tipoDocumento
            Case "9907"
                tipoDocumento = "9907"
                serieVenta = "NOTE"
                numeroVenta = "1"
            Case Else
                tipoDocumento = VENTA.tipoDocumento
                serieVenta = VENTA.serieVenta
                numeroVenta = VENTA.numeroVenta
        End Select

        nDocumentoCaja = New documento
        'DOCUMENTO
        nDocumentoCaja.idDocumento = CInt(Me.Tag)
        nDocumentoCaja.idEmpresa = Gempresas.IdEmpresaRuc
        nDocumentoCaja.idCentroCosto = GEstableciento.IdEstablecimiento
        nDocumentoCaja.tipoDoc = tipoDocumento ' cbotipoDocPago.SelectedValue
        nDocumentoCaja.fechaProceso = txtFecha.Value
        nDocumentoCaja.nroDoc = serieVenta & "-" & numeroVenta
        nDocumentoCaja.idOrden = Nothing
        nDocumentoCaja.moneda = 1
        If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            nDocumentoCaja.idEntidad = Val(TXTcOMPRADOR.Tag)
            nDocumentoCaja.entidad = TXTcOMPRADOR.Text
            nDocumentoCaja.nrodocEntidad = txtruc.Text
        Else
            nDocumentoCaja.entidad = TXTcOMPRADOR.Text
            nDocumentoCaja.nrodocEntidad = 0
            nDocumentoCaja.idEntidad = Val(0)
        End If
        nDocumentoCaja.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        nDocumentoCaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES
        nDocumentoCaja.usuarioActualizacion = usuario.IDUsuario
        nDocumentoCaja.fechaActualizacion = DateTime.Now

        'DOCUMENTO CAJA
        objCaja = New documentoCaja
        objCaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES
        objCaja.idDocumento = 0
        objCaja.periodo = lblPerido.Text
        objCaja.idEmpresa = Gempresas.IdEmpresaRuc
        objCaja.idEstablecimiento = GEstableciento.IdEstablecimiento
        objCaja.fechaProceso = txtFecha.Value
        objCaja.fechaCobro = txtFecha.Value
        objCaja.tipoMovimiento = TIPO_VENTA.PAGO.COBRADO
        If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            objCaja.codigoProveedor = Integer.Parse(TXTcOMPRADOR.Tag)
            objCaja.IdProveedor = Integer.Parse(TXTcOMPRADOR.Tag)
            objCaja.idPersonal = Integer.Parse(TXTcOMPRADOR.Tag)
        End If
        objCaja.tipoDocPago = tipoDocumento
        objCaja.TipoDocumentoPago = tipoDocumento 'cbotipoDocPago.SelectedValue
        objCaja.codigoLibro = "1"
        objCaja.formapago = "109"
        objCaja.NumeroDocumento = "-"
        objCaja.numeroOperacion = "-"

        Select Case VENTA.tipoDocumento
            Case "9907"
                objCaja.movimientoCaja = TIPO_VENTA.NOTA_DE_VENTA
            Case Else
                objCaja.movimientoCaja = TIPO_VENTA.VENTA_POS_DIRECTA
        End Select

        objCaja.montoSoles = Decimal.Parse(txtTotalPagar.DecimalValue)

        objCaja.moneda = 1
        objCaja.tipoCambio = TmpTipoCambio
        objCaja.montoUsd = FormatNumber(objCaja.montoSoles / TmpTipoCambio, 2)

        objCaja.estado = "1"
        objCaja.glosa = "Por ventas POS directa del cliente: " & TXTcOMPRADOR.Text & "con tipo Doc. " & cboTipoDoc.Text & ", fecha de venta " & txtFecha.Value
        objCaja.entregado = "SI"

        objCaja.idCajaUsuario = GFichaUsuarios.IdCajaUsuario
        objCaja.usuarioModificacion = usuario.IDUsuario
        objCaja.entidadFinanciera = cbocajaPago.SelectedValue
        objCaja.NombreEntidad = cbocajaPago.Text
        objCaja.fechaModificacion = DateTime.Now

        nDocumentoCaja.documentoCaja = objCaja
        ListaDoc.Add(nDocumentoCaja)
        ListaDetalleCaja(nDocumentoCaja.documentoCaja)
        asientoDocumento(nDocumentoCaja.documentoCaja)

        Return ListaDoc
    End Function

    Function ListaDocumentoCajaGenerico(be As documentoventaAbarrotes) As List(Of documento)
        Dim nDocumentoCaja As New documento
        Dim objCaja As New documentoCaja
        Dim ListaDoc As New List(Of documento)

        nDocumentoCaja = New documento
        'DOCUMENTO
        nDocumentoCaja.idDocumento = CInt(Me.Tag)
        nDocumentoCaja.idEmpresa = Gempresas.IdEmpresaRuc
        nDocumentoCaja.idCentroCosto = GEstableciento.IdEstablecimiento
        nDocumentoCaja.tipoDoc = be.tipoDocumento ' cbotipoDocPago.SelectedValue
        nDocumentoCaja.fechaProceso = txtFecha.Value
        nDocumentoCaja.nroDoc = GConfiguracion.Serie
        nDocumentoCaja.idOrden = Nothing
        nDocumentoCaja.moneda = 1
        If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            nDocumentoCaja.idEntidad = Val(TXTcOMPRADOR.Tag)
            nDocumentoCaja.entidad = TXTcOMPRADOR.Text
            nDocumentoCaja.nrodocEntidad = txtruc.Text
        Else
            nDocumentoCaja.entidad = TXTcOMPRADOR.Text
            nDocumentoCaja.nrodocEntidad = 0
            nDocumentoCaja.idEntidad = Val(0)
        End If
        nDocumentoCaja.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        nDocumentoCaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES
        nDocumentoCaja.usuarioActualizacion = usuario.IDUsuario
        nDocumentoCaja.fechaActualizacion = DateTime.Now

        'DOCUMENTO CAJA
        objCaja = New documentoCaja
        objCaja.tipoOperacion = StatusTipoOperacion.COBRO_A_CLIENTES
        objCaja.idDocumento = 0
        objCaja.periodo = lblPerido.Text
        objCaja.idEmpresa = Gempresas.IdEmpresaRuc
        objCaja.idEstablecimiento = GEstableciento.IdEstablecimiento
        objCaja.fechaProceso = txtFecha.Value
        objCaja.fechaCobro = txtFecha.Value
        objCaja.tipoMovimiento = TIPO_VENTA.PAGO.COBRADO
        If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            objCaja.codigoProveedor = Integer.Parse(TXTcOMPRADOR.Tag)
            objCaja.IdProveedor = Integer.Parse(TXTcOMPRADOR.Tag)
            objCaja.idPersonal = Integer.Parse(TXTcOMPRADOR.Tag)
        End If
        objCaja.tipoDocPago = be.tipoDocumento
        objCaja.TipoDocumentoPago = be.tipoDocumento 'cbotipoDocPago.SelectedValue
        objCaja.codigoLibro = "1"
        objCaja.formapago = "109"
        objCaja.NumeroDocumento = "-"
        objCaja.numeroOperacion = "-"
        objCaja.movimientoCaja = TipoVentaGeneral 'TIPO_VENTA.VENTA_POS_DIRECTA,
        objCaja.montoSoles = Decimal.Parse(be.ImporteNacional)

        objCaja.moneda = 1
        objCaja.tipoCambio = TmpTipoCambio
        objCaja.montoUsd = FormatNumber(objCaja.montoSoles / TmpTipoCambio, 2)

        objCaja.estado = "1"
        objCaja.glosa = "Por ventas POS directa del cliente: " & TXTcOMPRADOR.Text & "con tipo Doc. " & cboTipoDoc.Text & ", fecha de venta " & txtFecha.Value
        objCaja.entregado = "SI"

        objCaja.idCajaUsuario = GFichaUsuarios.IdCajaUsuario
        objCaja.usuarioModificacion = usuario.IDUsuario
        objCaja.entidadFinanciera = cbocajaPago.SelectedValue
        objCaja.NombreEntidad = cbocajaPago.Text
        objCaja.fechaModificacion = DateTime.Now

        nDocumentoCaja.documentoCaja = objCaja
        ListaDoc.Add(nDocumentoCaja)
        ListaDetalleCajaGenerico(nDocumentoCaja.documentoCaja, be.documentoventaAbarrotesDet.ToList)
        asientoDocumento(nDocumentoCaja.documentoCaja)

        Return ListaDoc
    End Function

    Public Function AsientoTransito(cMonto As Decimal, cMontoUS As Decimal) As asiento
        Dim nAsiento As New asiento
        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.periodo = lblPerido.Text
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            nAsiento.idEntidad = Integer.Parse(TXTcOMPRADOR.Tag)
            nAsiento.nombreEntidad = TXTcOMPRADOR.Text
        Else
            nAsiento.idEntidad = Integer.Parse(0)
            nAsiento.nombreEntidad = TXTcOMPRADOR.Text
        End If

        nAsiento.tipoEntidad = TIPO_ENTIDAD.CLIENTE
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.codigoLibro = "14"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Venta_Existencia
        nAsiento.importeMN = cMonto
        nAsiento.importeME = cMontoUS
        nAsiento.glosa = txtGlosa.Text.Trim
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now
        Return nAsiento
    End Function

    Sub asientoDocumento(doc As documentoCaja)
        Dim asiento As New asiento
        Dim nMovimiento As New movimiento
        Dim efSA As New EstadosFinancierosSA
        Dim ef As New estadosFinancieros


        ef = efSA.GetUbicar_estadosFinancierosPorID(doc.entidadFinanciera)

        asiento = AsientoTransito(doc.montoSoles, doc.montoUsd)

        ListaAsientonTransito.Add(asiento)

        nMovimiento = New movimiento
        nMovimiento.cuenta = ef.cuenta
        nMovimiento.descripcion = ef.descripcion
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
        nMovimiento.monto = doc.montoSoles
        nMovimiento.montoUSD = doc.montoUsd
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        nMovimiento.fechaActualizacion = DateTime.Now
        asiento.movimiento.Add(nMovimiento)

        nMovimiento = New movimiento
        nMovimiento.cuenta = "1213"
        nMovimiento.descripcion = TXTcOMPRADOR.Text
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
        nMovimiento.monto = doc.montoSoles
        nMovimiento.montoUSD = doc.montoUsd
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        nMovimiento.fechaActualizacion = DateTime.Now
        asiento.movimiento.Add(nMovimiento)

    End Sub

    Private Sub ListaDetalleCajaGenerico(doc As documentoCaja, detalleVenta As List(Of documentoventaAbarrotesDet))
        Dim obj As New documentoCajaDetalle
        Dim lista As New List(Of documentoCajaDetalle)
        For Each i In detalleVenta

            obj = New documentoCajaDetalle
            obj.fecha = Date.Now
            '   obj.codigoLote = Integer.Parse(i.codigoLote)
            obj.idItem = CInt(i.idItem)
            obj.DetalleItem = i.DetalleItem
            obj.montoSoles = FormatNumber(Decimal.Parse(i.importeMN), 2)
            obj.montoUsd = FormatNumber(Decimal.Parse(i.importeME), 2) '
            obj.diferTipoCambio = TmpTipoCambio
            obj.tipoCambioTransacc = TmpTipoCambio
            obj.entregado = "SI"
            obj.idCajaUsuario = GFichaUsuarios.IdCajaUsuario
            obj.usuarioModificacion = usuario.IDUsuario
            obj.documentoAfectado = CInt(Me.Tag)
            obj.fechaModificacion = DateTime.Now
            lista.Add(obj)
        Next
        doc.documentoCajaDetalle = lista
    End Sub

    Private Sub ListaDetalleCaja(doc As documentoCaja)
        Dim obj As New documentoCajaDetalle
        Dim lista As New List(Of documentoCajaDetalle)
        For Each i As Record In dgvCompra.Table.Records

            obj = New documentoCajaDetalle
            obj.fecha = Date.Now
            obj.codigoLote = 0 'Integer.Parse(i.GetValue("codigoLote"))
            obj.otroMN = 0 'Integer.Parse(i.GetValue("codigoLote"))
            obj.idItem = CInt(i.GetValue("idProducto"))
            obj.DetalleItem = i.GetValue("item")
            obj.montoSoles = FormatNumber(Decimal.Parse(i.GetValue("totalmn")), 2)
            obj.montoUsd = FormatNumber(Decimal.Parse(i.GetValue("totalme")), 2) '
            obj.diferTipoCambio = TmpTipoCambio
            obj.tipoCambioTransacc = TmpTipoCambio
            obj.entregado = "SI"
            obj.idCajaUsuario = GFichaUsuarios.IdCajaUsuario
            obj.usuarioModificacion = usuario.IDUsuario
            obj.documentoAfectado = CInt(Me.Tag)
            obj.fechaModificacion = DateTime.Now
            lista.Add(obj)
        Next
        doc.documentoCajaDetalle = lista
    End Sub

    Sub GuiaRemision(objDocumentoCompra As documento)
        Dim guiaRemisionBE As New documentoGuia
        Dim documentoguiaDetalle As New documentoguiaDetalle
        Dim ListaGuiaDetalle As New List(Of documentoguiaDetalle)
        'REGISTRANDO LA GUIA DE REMISION

        Dim idCliente As Integer = 0
        Dim nomCliente As String = Nothing

        If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            idCliente = TXTcOMPRADOR.Tag
            nomCliente = TXTcOMPRADOR.Text
        Else
            nomCliente = TXTcOMPRADOR.Text
        End If

        With guiaRemisionBE
            .idDocumento = 0
            .codigoLibro = "14"
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = txtFecha.Value
            .periodo = lblPerido.Text
            .tipoDoc = "99"
            .idEntidad = idCliente
            .monedaDoc = "1"
            .tasaIgv = 0 'txtIva.DoubleValue
            .tipoCambio = 1 ' txtTipoCambio.DecimalValue
            .importeMN = TotalesXcanbeceras.TotalMN
            .importeME = TotalesXcanbeceras.TotalMN
            .glosa = txtGlosa.Text.Trim
            .estado = TipoGuia.Entregado
            .direccionPartida = "ORIGEN"
            .fechaTraslado = Date.Now
            .estado = TipoGuia.Entregado
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With
        objDocumentoCompra.documentoGuia = guiaRemisionBE

        For Each r As Record In dgvCompra.Table.Records
            If r.GetValue("tipoExistencia") <> "GS" Then
                documentoguiaDetalle = New documentoguiaDetalle
                objDocumentoCompra.documentoGuia.serie = GConfiguracion.Serie
                objDocumentoCompra.documentoGuia.numeroDoc = GConfiguracion.Serie
                documentoguiaDetalle.idDocumento = 0
                documentoguiaDetalle.idItem = r.GetValue("idProducto")
                documentoguiaDetalle.descripcionItem = r.GetValue("item")
                documentoguiaDetalle.destino = r.GetValue("gravado")
                documentoguiaDetalle.unidadMedida = r.GetValue("um")
                documentoguiaDetalle.cantidad = CDec(r.GetValue("cantEntregar"))

                documentoguiaDetalle.almacenRef = CInt(r.GetValue("almacen"))
                documentoguiaDetalle.nombreRecepcion = nomCliente
                documentoguiaDetalle.dniRecepcion = Nothing
                documentoguiaDetalle.puntoLlegada = "ORIGEN"
                documentoguiaDetalle.estado = TipoGuiaDetalle.Entrega_Total
                documentoguiaDetalle.usuarioModificacion = usuario.IDUsuario
                documentoguiaDetalle.fechaModificacion = DateTime.Now
                ListaGuiaDetalle.Add(documentoguiaDetalle)
                ' End If
            End If

        Next
        objDocumentoCompra.documentoGuia.documentoguiaDetalle = ListaGuiaDetalle
    End Sub

    Sub GuiaRemisionGenerico(beDocumento As documento)
        Dim guiaRemisionBE As New documentoGuia
        Dim documentoguiaDetalle As New documentoguiaDetalle
        Dim ListaGuiaDetalle As New List(Of documentoguiaDetalle)
        'REGISTRANDO LA GUIA DE REMISION

        Dim idCliente As Integer = 0
        Dim nomCliente As String = Nothing

        If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            idCliente = TXTcOMPRADOR.Tag
            nomCliente = TXTcOMPRADOR.Text
        Else
            nomCliente = TXTcOMPRADOR.Text
        End If

        With guiaRemisionBE
            .idDocumento = 0
            .codigoLibro = "14"
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = txtFecha.Value
            .periodo = lblPerido.Text
            .tipoDoc = "99"
            .idEntidad = idCliente
            .monedaDoc = "1"
            .tasaIgv = 0 'txtIva.DoubleValue
            .tipoCambio = 1 ' txtTipoCambio.DecimalValue
            .importeMN = beDocumento.documentoventaAbarrotes.ImporteNacional
            .importeME = beDocumento.documentoventaAbarrotes.ImporteExtranjero
            .glosa = txtGlosa.Text.Trim
            .estado = TipoGuia.Entregado
            .direccionPartida = "ORIGEN"
            .fechaTraslado = Date.Now
            .estado = TipoGuia.Entregado
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With
        beDocumento.documentoGuia = guiaRemisionBE

        For Each r In beDocumento.documentoventaAbarrotes.documentoventaAbarrotesDet.ToList
            If r.tipoExistencia <> "GS" Then
                documentoguiaDetalle = New documentoguiaDetalle
                'sdfsdfsdf
                'beDocumento.documentoGuia.serie = GConfiguracion2.Serie
                'beDocumento.documentoGuia.numeroDoc = GConfiguracion2.Serie
                documentoguiaDetalle.idDocumento = 0
                documentoguiaDetalle.idItem = r.idItem
                documentoguiaDetalle.descripcionItem = r.DetalleItem
                documentoguiaDetalle.destino = r.destino
                documentoguiaDetalle.unidadMedida = r.unidad1
                documentoguiaDetalle.cantidad = CDec(r.monto1)

                documentoguiaDetalle.almacenRef = r.idAlmacenOrigen
                documentoguiaDetalle.nombreRecepcion = nomCliente
                documentoguiaDetalle.dniRecepcion = Nothing
                documentoguiaDetalle.puntoLlegada = "ORIGEN"
                documentoguiaDetalle.estado = TipoGuiaDetalle.Entrega_Total
                documentoguiaDetalle.usuarioModificacion = usuario.IDUsuario
                documentoguiaDetalle.fechaModificacion = DateTime.Now
                ListaGuiaDetalle.Add(documentoguiaDetalle)
                ' End If
            End If

        Next
        beDocumento.documentoGuia.documentoguiaDetalle = ListaGuiaDetalle
    End Sub

    Sub ConfiguracionInicio()
        'Me.WindowState = FormWindowState.Maximized
        TotalesXcanbeceras = New TotalesXcanbecera()

        'confgiurando variables generales
        cboTipoDoc.Enabled = True
        cbocajaPago.Enabled = True
        '  cbotipoDocPago.Enabled = True
        txtGlosa.Text = "Por la venta según " & cboTipoDoc.Text
        txtFecha.Value = DateTime.Now
        txtFecha.Select()
    End Sub

    ''' <summary>
    ''' Calculando totas las filas de la venta
    ''' </summary>
    Function GetDetalleVenta_Calculo(item As totalesAlmacen, cantventa As Decimal?, pumn As Decimal, pume As Decimal,
                                     puKardex As Decimal, puKardexme As Decimal) As DetalleVentageneral
        Dim colcantidad As Decimal = 0
        Dim cantidadDisponible As Decimal = 0
        Dim Igv As Decimal = 0
        Dim IgvME As Decimal = 0
        Dim totalMN As Decimal = 0
        Dim totalME As Decimal = 0
        Dim colBI As Decimal = 0
        Dim colBIme As Decimal = 0
        Dim colPrecUnit As Decimal = 0
        Dim colPrecUnitme As Decimal = 0
        Dim colDestinoGravado As Integer
        Dim colBonifica As String = Nothing

        Dim valPercepMN As Decimal = 0
        Dim valPercepME As Decimal = 0

        Dim colCostoMN As Decimal = 0
        Dim colCostoME As Decimal = 0
        Dim colPrecUnitAlmacen As Decimal = 0
        Dim colPrecUnitUSAlmacen As Decimal = 0


        colcantidad = item.cantidad
        cantidadDisponible = 0
        colPrecUnitAlmacen = puKardex ' Me.dgvCompra.Table.CurrentRecord.GetValue("puKardex")
        colPrecUnitUSAlmacen = puKardexme ' Me.dgvCompra.Table.CurrentRecord.GetValue("pukardeme")
        colPrecUnit = pumn ' Me.dgvCompra.Table.CurrentRecord.GetValue("pumn")
        colPrecUnitme = pume ' Me.dgvCompra.Table.CurrentRecord.GetValue("pume")
        colDestinoGravado = item.origenRecaudo

        colCostoMN = colcantidad * colPrecUnitAlmacen
        colCostoME = colcantidad * colPrecUnitUSAlmacen

        totalMN = colcantidad * colPrecUnit
        totalME = colcantidad * colPrecUnitme

        If colDestinoGravado = 1 Then
            valPercepMN = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionMN")
            valPercepME = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionME")
        Else
            valPercepMN = 0
            valPercepME = 0

        End If

        '****************************************************************
        Dim iva As Decimal = TmpIGV / 100

        If colcantidad > 0 Then

            colBI = (totalMN / (iva + 1))
            colBIme = (totalME / (iva + 1))

            Dim iv As Decimal = 0
            Dim iv2 As Decimal = 0
            iv = totalMN / (iva + 1)
            iv2 = totalME / (iva + 1)

            Igv = iv * (iva)
            IgvME = iv2 * (iva)

            'colIGV = (colMN / 1.18) * 0.18 ' colBI * 0.18
            'colIGV_ME = (colME / 1.18) * 0.18 ' colBI_ME * 0.18

        Else
            colBI = 0
            colBIme = 0
            Igv = 0
            IgvME = 0
        End If
        GetDetalleVenta_Calculo = New DetalleVentageneral
        Select Case colDestinoGravado
            Case 1

                GetDetalleVenta_Calculo.valorVentaMN = Math.Round(colBI, 2)
                GetDetalleVenta_Calculo.valorVentaME = Math.Round(colBIme, 2)
                GetDetalleVenta_Calculo.precioUnitMN = colPrecUnit
                GetDetalleVenta_Calculo.precioUnitME = colPrecUnitme
                GetDetalleVenta_Calculo.TotalVentaMN = Math.Round(totalMN, 2)
                GetDetalleVenta_Calculo.TotalVentaME = Math.Round(totalME, 2)
                GetDetalleVenta_Calculo.IgvMN = Math.Round(Igv, 2)
                GetDetalleVenta_Calculo.IgvME = Math.Round(IgvME, 2)
                GetDetalleVenta_Calculo.CostoMN = colCostoMN
                GetDetalleVenta_Calculo.CostoME = colCostoME

            Case 2

                GetDetalleVenta_Calculo.valorVentaMN = Math.Round(totalMN, 2)
                GetDetalleVenta_Calculo.valorVentaME = Math.Round(totalME, 2)
                GetDetalleVenta_Calculo.precioUnitMN = colPrecUnit
                GetDetalleVenta_Calculo.precioUnitME = colPrecUnitme
                GetDetalleVenta_Calculo.TotalVentaMN = Math.Round(totalMN, 2)
                GetDetalleVenta_Calculo.TotalVentaME = Math.Round(totalME, 2)
                GetDetalleVenta_Calculo.IgvMN = 0
                GetDetalleVenta_Calculo.IgvME = 0
                GetDetalleVenta_Calculo.CostoMN = colCostoMN
                GetDetalleVenta_Calculo.CostoME = colCostoME
        End Select
        ' TotalTalesXcolumna()
    End Function
    Dim thread As System.Threading.Thread
    Private Sub threadClientes()
        Dim tipo = TIPO_ENTIDAD.CLIENTE
        Dim empresa = Gempresas.IdEmpresaRuc
        ProgressBar1.Visible = True
        ProgressBar1.Style = ProgressBarStyle.Marquee
        thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetClientes(tipo, empresa)))
        thread.Start()
    End Sub

    Private Sub GetClientes(tipo As String, empresa As String)
        Dim lista As New List(Of entidad)
        lista = New List(Of entidad)
        Dim varios = entidadSA.UbicarEntidadVarios("VR", Gempresas.IdEmpresaRuc, String.Empty, GEstableciento.IdEstablecimiento)
        'Dim lista = entidadSA.ObtenerListaEntidad(tipo, empresa)
        lista.Add(varios)
        lista.AddRange(entidadSA.GetListarEntidad(New entidad With {.tipoEntidad = tipo, .idEmpresa = Gempresas.IdEmpresaRuc, .idOrganizacion = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA}))
        setDataSource(lista)
    End Sub

    'Private Sub ThreadNumeracion()
    '    Dim strIdModulo As String = Nothing
    '    If cboTipoDoc.Text = "BOLETA" Then
    '        strIdModulo = "VT2"
    '    ElseIf cboTipoDoc.Text = "FACTURA" Then
    '        strIdModulo = "VT3"
    '    End If

    '    Dim strIDEmpresa = Gempresas.IdEmpresaRuc
    '    ProgressBar2.Visible = True
    '    ProgressBar2.Style = ProgressBarStyle.Marquee
    '    Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetNumeracion(strIdModulo, strIDEmpresa)))
    '    thread.Start()
    'End Sub

    'Private Sub GetNumeracion(strIdModulo As String, strIDEmpresa As String, intIdEstablecimiento As Integer)
    '    Dim moduloConfiguracionSA As New ModuloConfiguracionSA
    '    Dim moduloConfiguracion As New moduloConfiguracion
    '    moduloConfiguracion = moduloConfiguracionSA.UbicarConfiguracionPorEmpresaModulo(strIdModulo, strIDEmpresa, intIdEstablecimiento)
    '    conf = New GConfiguracionModulo
    '    conf = ConfigurarComprobanteVenta(moduloConfiguracion)
    '    'SetDataSourceNumeracion(moduloConfiguracion)
    'End Sub
    'Dim conf As New GConfiguracionModulo
    'Private v As Object

    'Private Sub SetDataSourceNumeracion(ByVal moduloConfiguracion As moduloConfiguracion)
    '    If Me.InvokeRequired Then
    '        'Me.Invoke(New SetDataSourceDelegate(AddressOf setDataSource), table)

    '        Dim deleg As New SetDataSourceDelegateNumeracion(AddressOf SetDataSourceNumeracion)
    '        Invoke(deleg, New Object() {moduloConfiguracion})
    '    Else
    '        conf = New GConfiguracionModulo
    '        conf = ConfigurarComprobanteVenta(moduloConfiguracion)
    '        ProgressBar2.Visible = False
    '    End If
    '    'txtSerie.Text = conf.Serie
    'End Sub

    'Public Function ConfigurarComprobanteVenta(moduloConfiguracion As moduloConfiguracion) As GConfiguracionModulo
    '    Dim numeracionSA As New NumeracionBoletaSA
    '    Dim TablaSA As New tablaDetalleSA
    '    Dim almacenSA As New almacenSA
    '    Dim cajaSA As New EstadosFinancierosSA

    '    If Not IsNothing(moduloConfiguracion) Then
    '        With moduloConfiguracion
    '            GConfiguracion2 = New GConfiguracionModulo
    '            GConfiguracion2.IdModulo = .idModulo
    '            GConfiguracion2.TipoConfiguracion = .tipoConfiguracion
    '            Select Case .tipoConfiguracion
    '                Case "P"
    '                    With numeracionSA.GetUbicar_numeracionBoletasPorID(.configComprobante)
    '                        GConfiguracion2.ConfigComprobante = .IdEnumeracion

    '                        If cboTipoDoc.Text = "BOLETA" Then
    '                            GConfiguracion2.TipoComprobante = "12.1" ' .tipo
    '                            GConfiguracion2.Serie = .serie
    '                            GConfiguracion2.ValorActual = .valorInicial

    '                        End If
    '                        If cboTipoDoc.Text = "FACTURA" Then
    '                            GConfiguracion2.TipoComprobante = "12.2" '.tipo
    '                            GConfiguracion2.Serie = .serie
    '                            GConfiguracion2.ValorActual = .valorInicial

    '                        End If

    '                        If cboTipoDoc.Text = "FACTURA ELECTRONICA" Then

    '                            GConfiguracion2.TipoComprobante = "01" '.tipo
    '                            GConfiguracion2.Serie = .serie
    '                            GConfiguracion2.ValorActual = .valorInicial


    '                        End If
    '                        If cboTipoDoc.Text = "BOLETA ELECTRONICA" Then
    '                            GConfiguracion2.TipoComprobante = "03" ' .tipo
    '                            GConfiguracion2.Serie = .serie
    '                            GConfiguracion2.ValorActual = .valorInicial

    '                        End If

    '                        If cboTipoDoc.Text = "PROFORMA" Then
    '                            GConfiguracion2.TipoComprobante = .tipo
    '                            GConfiguracion2.Serie = .serie
    '                            GConfiguracion2.ValorActual = .valorInicial
    '                        End If
    '                    End With
    '                Case "M"

    '            End Select

    '        End With
    '    Else
    '        lblEstado.Text = "Este módulo no contiene una configuración disponible, intentelo más tarde.!"
    '        Timer1.Enabled = True
    '        'TabCompra.Enabled = False
    '        TiempoEjecutar(5)
    '    End If
    '    Return GConfiguracion2
    'End Function

    Public Function configuracionModuloV2(strIDEmpresa As String, strIdModulo As String, strNomModulo As String, intIdEstablecimiento As Integer) As GConfiguracionModulo
        Try
            Dim numeracionSA As New NumeracionBoletaSA
            Dim TablaSA As New tablaDetalleSA
            Dim almacenSA As New almacenSA
            Dim cajaSA As New EstadosFinancierosSA

            Dim RecuperacionNumeracion = numeracionSA.GetUbicar_numeracionBoletasXUnidadNegocio(New numeracionBoletas With {.empresa = strIDEmpresa, .establecimiento = intIdEstablecimiento, .codigoNumeracion = strIdModulo, .estado = "A"})

            If (Not IsNothing(RecuperacionNumeracion)) Then
                GConfiguracion = New GConfiguracionModulo
                GConfiguracion.ConfigComprobante = CInt(RecuperacionNumeracion.IdEnumeracion)

                If cboTipoDoc.Text = "BOLETA" Then
                    GConfiguracion.TipoComprobante = "12.1" ' .tipo
                    GConfiguracion.Serie = RecuperacionNumeracion.serie
                    GConfiguracion.ValorActual = RecuperacionNumeracion.valorInicial

                End If
                If cboTipoDoc.Text = "FACTURA" Then
                    GConfiguracion.TipoComprobante = "12.2" '.tipo
                    GConfiguracion.Serie = RecuperacionNumeracion.serie
                    GConfiguracion.ValorActual = RecuperacionNumeracion.valorInicial

                End If

                If cboTipoDoc.Text = "FACTURA ELECTRONICA" Then

                    GConfiguracion.TipoComprobante = "01" '.tipo
                    GConfiguracion.Serie = RecuperacionNumeracion.serie
                    GConfiguracion.ValorActual = RecuperacionNumeracion.valorInicial


                End If
                If cboTipoDoc.Text = "BOLETA ELECTRONICA" Then
                    GConfiguracion.TipoComprobante = "03" ' .tipo
                    GConfiguracion.Serie = RecuperacionNumeracion.serie
                    GConfiguracion.ValorActual = RecuperacionNumeracion.valorInicial

                End If

                If cboTipoDoc.Text = "PROFORMA" Then
                    GConfiguracion.TipoComprobante = RecuperacionNumeracion.tipo
                    GConfiguracion.Serie = RecuperacionNumeracion.serie
                    GConfiguracion.ValorActual = RecuperacionNumeracion.valorInicial
                End If
            Else
                Throw New Exception("Verificar configuración")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return GConfiguracion
    End Function

    Private Sub setDataSource(ByVal lista As List(Of entidad))
        If Me.InvokeRequired Then
            'Me.Invoke(New SetDataSourceDelegate(AddressOf setDataSource), table)

            Dim deleg As New SetDataSourceDelegate(AddressOf setDataSource)
            Invoke(deleg, New Object() {lista})
        Else
            listaClientes = New List(Of entidad)
            listaClientes = lista
            ProgressBar1.Visible = False
        End If
    End Sub

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

    Sub GetTableGrid()
        Dim dt As New DataTable()

        dt.Columns.Add("codigo", GetType(String))
        dt.Columns.Add("gravado", GetType(String))
        dt.Columns.Add("idProducto", GetType(Integer))
        dt.Columns.Add("item", GetType(String))
        dt.Columns.Add("um", GetType(String))
        dt.Columns.Add("cantidad", GetType(Decimal))
        dt.Columns.Add("vcmn", GetType(Decimal))
        dt.Columns.Add("pcmn", GetType(Decimal))
        dt.Columns.Add("totalmn", GetType(Decimal))
        dt.Columns.Add("vcme", GetType(Decimal))
        dt.Columns.Add("pcme", GetType(Decimal))
        dt.Columns.Add("totalme", GetType(Decimal))
        dt.Columns.Add("igvmn", GetType(Decimal))
        dt.Columns.Add("igvme", GetType(Decimal))

        dt.Columns.Add("tipoExistencia", GetType(String))
        dt.Columns.Add("marca", GetType(String))
        dt.Columns.Add("almacen", GetType(String))
        dt.Columns.Add("caja", GetType(String))

        dt.Columns.Add("pumn", GetType(Decimal))
        dt.Columns.Add("pume", GetType(Decimal))
        dt.Columns.Add("chPago", GetType(Boolean))
        dt.Columns.Add("valPago", GetType(String))

        dt.Columns.Add("chBonif", GetType(Boolean))
        dt.Columns.Add("valBonif", GetType(String))
        dt.Columns.Add("presentacion", GetType(String))

        dt.Columns.Add("percepcionMN", GetType(Decimal))
        dt.Columns.Add("percepcionME", GetType(Decimal))
        dt.Columns.Add("puKardex", GetType(Decimal))
        dt.Columns.Add("pukardeme", GetType(Decimal))
        dt.Columns.Add("canDisponible", GetType(Decimal))
        dt.Columns.Add("costoMN", GetType(Decimal))
        dt.Columns.Add("costoME", GetType(Decimal))
        dt.Columns.Add("tipoPrecio", GetType(String))
        dt.Columns.Add("cat", GetType(Integer))
        dt.Columns.Add("codBarra", GetType(String))
        dt.Columns.Add("empresa", GetType(String))
        dt.Columns.Add("cboprecio", GetType(String))
        dt.Columns.Add("codigoLote")
        dt.Columns.Add("MontoPago")
        dt.Columns.Add("MontoSaldo")
        dt.Columns.Add("tipoventa")
        dt.Columns.Add("cantidad2")

        dt.Columns.Add("menor")
        dt.Columns.Add("mayor")
        dt.Columns.Add("gmayor")
        dgvCompra.DataSource = dt
    End Sub

    Public Sub GetCombos()
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Dim cajaSA As New EstadosFinancierosSA
        Dim almacenSA As New almacenSA
        Dim tablaDetalleSA As New tablaDetalleSA

        ListaAlmacenes = New List(Of almacen)
        ListaEstadosFinancieros = New List(Of estadosFinancieros)
        '    ListaTipoExistencia = New List(Of tabladetalle)
        'ListaComprobantesCaja = New List(Of tabladetalle)

        '  ListaTipoExistencia = tablaDetalleSA.GetListaTablaDetalle(5, "1")

        ListaAlmacenes = almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
        '  ListaComprobantesCaja = tablaDetalleSA.GetListaTablaDetalle(10, "1")
        'Dim cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
        'If Not IsNothing(cajaUsuario) Then
        For Each i As cajaUsuario In cajaUsuarioSA.ResumenTransaccionesXusuarioCajaPago(New cajaUsuario With {.idcajaUsuario = GFichaUsuarios.IdCajaUsuario, .idPersona = usuario.IDUsuario})
            ListaEstadosFinancieros.Add(New estadosFinancieros With {.idestado = i.idEntidad, .descripcion = i.NombreEntidad, .tipo = i.Tipo, .codigo = i.moneda})
        Next
        'Else
        '    ListaEstadosFinancieros = cajaSA.GetCuentasFinancierasByEmpresa(Gempresas.IdEmpresaRuc, "EF")
        'End If

    End Sub

    Public Sub Loadcontroles()
        If ListaAlmacenes.Count > 0 Then
            cboalmacen.ValueMember = "idAlmacen"
            cboalmacen.DisplayMember = "descripcionAlmacen"
            cboalmacen.DataSource = ListaAlmacenes 'almacenSA.GetListar_almacenExceptAV(GEstableciento.IdEstablecimiento)
        End If



        'cbotipoDocPago.DataSource = ListaComprobantesCaja 'tablaDetalleSA.GetListaTablaDetalle(10, "1")
        'cbotipoDocPago.ValueMember = "codigoDetalle"
        'cbotipoDocPago.DisplayMember = "descripcion"
        If ListaEstadosFinancieros.Count > 0 Then
            cbocajaPago.DataSource = ListaEstadosFinancieros ' cajaSA.GetCuentasFinancierasByEmpresa(Gempresas.IdEmpresaRuc, "EF")
            cbocajaPago.ValueMember = "idestado"
            cbocajaPago.DisplayMember = "descripcion"
        End If


    End Sub

    Public Sub AgregarAcanastaCodigoBarra_Index(precio As configuracionPrecioProducto, item As totalesAlmacen, cantidadDisponible As Decimal)
        'Me.Cursor = Cursors.WaitCursor
        Dim valTipoVenta As String = Nothing
        Dim valPUmn As Decimal = 0
        Dim valPUme As Decimal = 0
        Dim productoSA As New detalleitemsSA

        valPUmn = precio.precioMN
        valPUme = precio.precioME

        Dim valPUKardexMN = CDec(item.importeSoles) / CDec(item.cantidad)
        Dim valPUKardexME = CDec(item.importeDolares) / CDec(item.cantidad)

        Dim calculoDetalle = GetDetalleVenta_Calculo(item, item.cantidad, valPUmn, valPUme, valPUKardexMN, valPUKardexME)


        With productoSA.InvocarProductoID(item.idItem)
            Me.dgvCompra.Table.AddNewRecord.SetCurrent()
            Me.dgvCompra.Table.AddNewRecord.BeginEdit()
            Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", .origenProducto)
            Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", .codigodetalle)
            Me.dgvCompra.Table.CurrentRecord.SetValue("item", .descripcionItem)
            Me.dgvCompra.Table.CurrentRecord.SetValue("um", .unidad1)
            Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", item.cantidad)
            Me.dgvCompra.Table.CurrentRecord.SetValue("canDisponible", cantidadDisponible)
            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", calculoDetalle.valorVentaMN.GetValueOrDefault)
            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", calculoDetalle.TotalVentaMN.GetValueOrDefault)
            Me.dgvCompra.Table.CurrentRecord.SetValue("MontoSaldo", calculoDetalle.TotalVentaMN.GetValueOrDefault)

            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", calculoDetalle.valorVentaME.GetValueOrDefault)
            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", calculoDetalle.TotalVentaME.GetValueOrDefault)
            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", calculoDetalle.IgvMN.GetValueOrDefault)
            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", calculoDetalle.IgvME.GetValueOrDefault)
            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", .tipoExistencia)
            Me.dgvCompra.Table.CurrentRecord.SetValue("marca", If(item.CustomLote.productoSustentado = True, "Doc.", "Not."))

            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", valPUmn)
            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", valPUme)

            Me.dgvCompra.Table.CurrentRecord.SetValue("puKardex", CDec(item.importeSoles) / CDec(item.cantidad))
            Me.dgvCompra.Table.CurrentRecord.SetValue("pukardeme", CDec(item.importeDolares) / CDec(item.cantidad))

            Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", False)
            Me.dgvCompra.Table.CurrentRecord.SetValue("valPago", "No Pagado")

            Me.dgvCompra.Table.CurrentRecord.SetValue("chBonif", False)
            Me.dgvCompra.Table.CurrentRecord.SetValue("valBonif", "N")
            Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", item.idAlmacen)
            Me.dgvCompra.Table.CurrentRecord.SetValue("presentacion", item.NomAlmacen)

            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", (0))
            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", (0))
            Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", calculoDetalle.CostoMN.GetValueOrDefault)
            Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", calculoDetalle.CostoME.GetValueOrDefault)
            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoPrecio", precio.idPrecio)
            Me.dgvCompra.Table.CurrentRecord.SetValue("cat", .idItem)

            Me.dgvCompra.Table.CurrentRecord.SetValue("codBarra", .codigo)
            Me.dgvCompra.Table.CurrentRecord.SetValue("empresa", item.idEmpresa)
            Me.dgvCompra.Table.CurrentRecord.SetValue("cboprecio", 1)
            Me.dgvCompra.Table.CurrentRecord.SetValue("codigoLote", item.CustomLote.codigoLote)
            dgvCompra.Table.CurrentRecord.SetValue("tipoventa", "V")
            Me.dgvCompra.Table.AddNewRecord.EndEdit()
        End With
        'txtBarCode.Select()
        'txtBarCode.SelectAll()


    End Sub

    Sub TotalTalesXcolumna()
        '  Dim totalNotaMN As Decimal = 0
        Dim totalNotaME As Decimal = 0
        Dim totalpercepMN As Decimal = 0
        Dim totalpercepME As Decimal = 0

        'VC01
        Dim totalVC As Decimal = 0
        Dim totalVCme As Decimal = 0

        'VC02
        Dim totalVC2 As Decimal = 0
        Dim totalVCme2 As Decimal = 0

        'VC03
        Dim totalVC3 As Decimal = 0
        Dim totalVCme3 As Decimal = 0

        Dim totalIVA As Decimal = 0
        Dim totalIVAme As Decimal = 0

        Dim totalDesc As Decimal = 0
        Dim totalDescme As Decimal = 0

        Dim total As Decimal = 0
        Dim totalme As Decimal = 0

        Dim bs1 As Decimal = 0
        Dim bs1me As Decimal = 0
        Dim bs2 As Decimal = 0
        Dim bs2me As Decimal = 0
        Dim igv1 As Decimal = 0
        Dim igv1me As Decimal = 0
        Dim igv2 As Decimal = 0
        Dim igv2me As Decimal = 0

        For Each r As Record In dgvCompra.Table.Records

            totalpercepMN += CDec(r.GetValue("percepcionMN"))
            totalpercepME += CDec(r.GetValue("percepcionME"))

            totalIVA += CDec(r.GetValue("igvmn"))
            totalIVAme += CDec(r.GetValue("igvme"))

            total += CDec(r.GetValue("totalmn"))
            totalme += CDec(r.GetValue("totalme"))
            'End If

            Select Case r.GetValue("gravado")
                Case "1"
                    bs1 += CDec(r.GetValue("vcmn"))
                    bs1me += CDec(r.GetValue("vcme"))

                    igv1 += CDec(r.GetValue("igvmn"))
                    igv1me += CDec(r.GetValue("igvme"))
                Case "2"
                    bs2 += CDec(r.GetValue("vcmn"))
                    bs2me += CDec(r.GetValue("vcme"))

                    igv2 += CDec(r.GetValue("igvmn"))
                    igv2me += CDec(r.GetValue("igvme"))
            End Select

            Select Case r.GetValue("gravado")
                Case OperacionGravada.Grabado
                    totalVC += CDec(r.GetValue("vcmn"))
                    totalVCme += CDec(r.GetValue("vcme"))

                Case OperacionGravada.Exonerado
                    totalVC2 += CDec(r.GetValue("vcmn"))
                    totalVCme2 += CDec(r.GetValue("vcme"))

                Case OperacionGravada.Inafecto
                    totalVC3 += CDec(r.GetValue("vcmn"))
                    totalVCme3 += CDec(r.GetValue("vcme"))
            End Select

        Next

        TotalesXcanbeceras = New TotalesXcanbecera()

        TotalesXcanbeceras.PercepcionMN = totalpercepMN
        TotalesXcanbeceras.PercepcionME = totalpercepME

        TotalesXcanbeceras.BaseMN = totalVC
        TotalesXcanbeceras.BaseME = totalVCme

        TotalesXcanbeceras.BaseMN2 = totalVC2
        TotalesXcanbeceras.BaseME2 = totalVCme2

        TotalesXcanbeceras.BaseMN3 = totalVC3
        TotalesXcanbeceras.BaseME3 = totalVCme3

        TotalesXcanbeceras.IgvMN = totalIVA
        TotalesXcanbeceras.IgvME = totalIVAme

        TotalesXcanbeceras.TotalMN = total
        TotalesXcanbeceras.TotalME = totalme

        TotalesXcanbeceras.base1 = bs1
        TotalesXcanbeceras.base1me = bs1me
        TotalesXcanbeceras.base2 = bs2
        TotalesXcanbeceras.base2me = bs2me

        TotalesXcanbeceras.MontoIgv1 = igv1
        TotalesXcanbeceras.MontoIgv1me = igv1me
        TotalesXcanbeceras.MontoIgv2 = igv2
        TotalesXcanbeceras.MontoIgv2me = igv2me

        '****************************************************
        'If cboMoneda.SelectedValue = 1 Then
        txtTotalBase3.DecimalValue = totalVC3
        txtTotalBase2.DecimalValue = totalVC2
        txtTotalBase.DecimalValue = totalVC
        txtTotalIva.Text = ((totalIVA))
        'Label4.Text = Decimal.Round(totalIVA)
        'Button1.Text = (CDec(totalIVA))
        lblTotalPercepcion.DecimalValue = TotalesXcanbeceras.PercepcionMN

        txtTotalNotaVenta.DecimalValue = 0
        txtVentaTotal.DecimalValue = total
        txtTotalPagar.DecimalValue = total
        DigitalGauge2.Text = total.ToString("N2")
        DigitalGauge2.Value = total.ToString("N2")
        'Else
        '    txtTotalBase3.DecimalValue = totalVCme3
        '    txtTotalBase2.DecimalValue = totalVCme2
        '    txtTotalBase.DecimalValue = totalVCme
        '    txtTotalIva.DecimalValue = totalIVAme
        '    txtTotalPagar.DecimalValue = totalme
        '    lblTotalPercepcion.DecimalValue = TotalesXcanbeceras.PercepcionME
        'End If


    End Sub

    ''Sub TotalTalesXcolumnaEspecial()
    ''    Dim totalNotaMN As Decimal = 0
    ''    Dim totalNotaME As Decimal = 0
    ''    Dim totalpercepMN As Decimal = 0
    ''    Dim totalpercepME As Decimal = 0

    ''    'VC01
    ''    Dim totalVC As Decimal = 0
    ''    Dim totalVCme As Decimal = 0

    ''    'VC02
    ''    Dim totalVC2 As Decimal = 0
    ''    Dim totalVCme2 As Decimal = 0

    ''    'VC03
    ''    Dim totalVC3 As Decimal = 0
    ''    Dim totalVCme3 As Decimal = 0

    ''    Dim totalIVA As Decimal = 0
    ''    Dim totalIVAme As Decimal = 0

    ''    Dim totalDesc As Decimal = 0
    ''    Dim totalDescme As Decimal = 0

    ''    Dim total As Decimal = 0
    ''    Dim totalme As Decimal = 0

    ''    Dim bs1 As Decimal = 0
    ''    Dim bs1me As Decimal = 0
    ''    Dim bs2 As Decimal = 0
    ''    Dim bs2me As Decimal = 0
    ''    Dim igv1 As Decimal = 0
    ''    Dim igv1me As Decimal = 0
    ''    Dim igv2 As Decimal = 0
    ''    Dim igv2me As Decimal = 0

    ''    For Each r As Record In dgvCompra.Table.Records

    ''        totalpercepMN += CDec(r.GetValue("percepcionMN"))
    ''        totalpercepME += CDec(r.GetValue("percepcionME"))

    ''        totalIVA += CDec(r.GetValue("igvmn"))
    ''        totalIVAme += CDec(r.GetValue("igvme"))

    ''        total += CDec(r.GetValue("totalmn"))
    ''        totalme += CDec(r.GetValue("totalme"))
    ''        'End If

    ''        Select Case r.GetValue("gravado")
    ''            Case "1"
    ''                bs1 += CDec(r.GetValue("vcmn"))
    ''                bs1me += CDec(r.GetValue("vcme"))

    ''                igv1 += CDec(r.GetValue("igvmn"))
    ''                igv1me += CDec(r.GetValue("igvme"))
    ''            Case "2"
    ''                bs2 += CDec(r.GetValue("vcmn"))
    ''                bs2me += CDec(r.GetValue("vcme"))

    ''                igv2 += CDec(r.GetValue("igvmn"))
    ''                igv2me += CDec(r.GetValue("igvme"))
    ''        End Select

    ''        Select Case r.GetValue("gravado")
    ''            Case OperacionGravada.Grabado
    ''                totalVC += CDec(r.GetValue("vcmn"))
    ''                totalVCme += CDec(r.GetValue("vcme"))

    ''            Case OperacionGravada.Exonerado
    ''                totalVC2 += CDec(r.GetValue("vcmn"))
    ''                totalVCme2 += CDec(r.GetValue("vcme"))

    ''            Case OperacionGravada.Inafecto
    ''                totalVC3 += CDec(r.GetValue("vcmn"))
    ''                totalVCme3 += CDec(r.GetValue("vcme"))
    ''        End Select


    ''        'If r.GetValue("valBonif") = "S" Then
    ''        '    totalDesc += CDec(r.GetValue("igvmn"))
    ''        '    totalDescme += CDec(r.GetValue("igvme"))
    ''        'Else
    ''    Next

    ''    TotalesXcanbeceras = New TotalesXcanbecera()

    ''    TotalesXcanbeceras.PercepcionMN = totalpercepMN
    ''    TotalesXcanbeceras.PercepcionME = totalpercepME

    ''    TotalesXcanbeceras.BaseMN = totalVC
    ''    TotalesXcanbeceras.BaseME = totalVCme

    ''    TotalesXcanbeceras.BaseMN2 = totalVC2
    ''    TotalesXcanbeceras.BaseME2 = totalVCme2

    ''    TotalesXcanbeceras.BaseMN3 = totalVC3
    ''    TotalesXcanbeceras.BaseME3 = totalVCme3

    ''    TotalesXcanbeceras.IgvMN = totalIVA
    ''    TotalesXcanbeceras.IgvME = totalIVAme

    ''    TotalesXcanbeceras.TotalMN = total
    ''    TotalesXcanbeceras.TotalME = totalme

    ''    TotalesXcanbeceras.base1 = bs1
    ''    TotalesXcanbeceras.base1me = bs1me
    ''    TotalesXcanbeceras.base2 = bs2
    ''    TotalesXcanbeceras.base2me = bs2me

    ''    TotalesXcanbeceras.MontoIgv1 = igv1
    ''    TotalesXcanbeceras.MontoIgv1me = igv1me
    ''    TotalesXcanbeceras.MontoIgv2 = igv2
    ''    TotalesXcanbeceras.MontoIgv2me = igv2me

    ''    '****************************************************
    ''    'If cboMoneda.SelectedValue = 1 Then
    ''    txtTotalBase3.DecimalValue = totalVC3
    ''    txtTotalBase2.DecimalValue = totalVC2
    ''    txtTotalBase.DecimalValue = totalVC
    ''    txtTotalIva.Text = ((totalIVA))
    ''    'Label4.Text = Decimal.Round(totalIVA)
    ''    'Button1.Text = (CDec(totalIVA))
    ''    lblTotalPercepcion.DecimalValue = TotalesXcanbeceras.PercepcionMN

    ''    txtTotalNotaVenta.DecimalValue = totalNotaMN
    ''    txtVentaTotal.DecimalValue = total
    ''    txtTotalPagar.DecimalValue = total + totalNotaMN
    ''    'Else
    ''    '    txtTotalBase3.DecimalValue = totalVCme3
    ''    '    txtTotalBase2.DecimalValue = totalVCme2
    ''    '    txtTotalBase.DecimalValue = totalVCme
    ''    '    txtTotalIva.DecimalValue = totalIVAme
    ''    '    txtTotalPagar.DecimalValue = totalme
    ''    '    lblTotalPercepcion.DecimalValue = TotalesXcanbeceras.PercepcionME
    ''    'End If


    ''End Sub

    Sub Calculos()
        Dim colcantidad As Decimal = 0
        Dim cantidadDisponible As Decimal = 0
        Dim Igv As Decimal = 0
        Dim IgvME As Decimal = 0
        Dim totalMN As Decimal = 0
        Dim totalME As Decimal = 0
        Dim colBI As Decimal = 0
        Dim colBIme As Decimal = 0
        Dim colPrecUnit As Decimal = 0
        Dim colPrecUnitme As Decimal = 0
        Dim colDestinoGravado As Integer
        Dim colBonifica As String = Nothing

        Dim valPercepMN As Decimal = 0
        Dim valPercepME As Decimal = 0

        Dim colCostoMN As Decimal = 0
        Dim colCostoME As Decimal = 0
        Dim colPrecUnitAlmacen As Decimal = 0
        Dim colPrecUnitUSAlmacen As Decimal = 0

        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            Dim strTipoExistencia = Me.dgvCompra.Table.CurrentRecord.GetValue("tipoExistencia")
            Select Case strTipoExistencia
                Case "GS"
                    colcantidad = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
                    cantidadDisponible = 0 ' Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                    colPrecUnitAlmacen = 0 ' Me.dgvCompra.Table.CurrentRecord.GetValue("puKardex")
                    colPrecUnitUSAlmacen = 0 ' Me.dgvCompra.Table.CurrentRecord.GetValue("pukardeme")
                    colPrecUnit = Me.dgvCompra.Table.CurrentRecord.GetValue("totalmn")
                    colPrecUnitme = Me.dgvCompra.Table.CurrentRecord.GetValue("totalmn")
                    colDestinoGravado = Me.dgvCompra.Table.CurrentRecord.GetValue("gravado")

                    colCostoMN = 0 ' colcantidad * colPrecUnitAlmacen
                    colCostoME = 0 ' colcantidad * colPrecUnitUSAlmacen

                    totalMN = Me.dgvCompra.Table.CurrentRecord.GetValue("totalmn") ' colcantidad * colPrecUnit
                    totalME = Me.dgvCompra.Table.CurrentRecord.GetValue("totalme") ' colcantidad * colPrecUnitme

                    If colDestinoGravado = 1 Then
                        Dim iva As Decimal = TmpIGV / 100
                        colBI = (totalMN / (iva + 1))
                        colBIme = (totalME / (iva + 1))

                        Dim iv As Decimal = 0
                        Dim iv2 As Decimal = 0
                        iv = totalMN / (iva + 1)
                        iv2 = totalME / (iva + 1)

                        Igv = iv * (iva)
                        IgvME = iv2 * (iva)
                    Else

                        colBI = 0
                        colBIme = 0
                        Igv = 0
                        IgvME = 0

                    End If

                    '****************************************************************

                    Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", colcantidad)
                    If colcantidad > 0 Then



                        'colIGV = (colMN / 1.18) * 0.18 ' colBI * 0.18
                        'colIGV_ME = (colME / 1.18) * 0.18 ' colBI_ME * 0.18

                    Else

                    End If

                    Select Case colDestinoGravado
                        Case 1
                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", Math.Round(colBI, 2))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", Math.Round(colBIme, 2))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("MontoSaldo", Math.Round(totalMN, 2))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Math.Round(Igv, 2))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", Math.Round(IgvME, 2))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                        Case 2
                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", Math.Round(totalMN, 2))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", Math.Round(totalME, 2))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("MontoSaldo", Math.Round(totalMN, 2))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                    End Select
                    TotalTalesXcolumna()
                Case Else
                    Select Case cboTipoDoc.Text
                        Case "PROFORMA"
#Region "Calculos"

                            colcantidad = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
                            cantidadDisponible = Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                            colPrecUnitAlmacen = Me.dgvCompra.Table.CurrentRecord.GetValue("puKardex")
                            colPrecUnitUSAlmacen = Me.dgvCompra.Table.CurrentRecord.GetValue("pukardeme")
                            colPrecUnit = Me.dgvCompra.Table.CurrentRecord.GetValue("pumn")
                            colPrecUnitme = Me.dgvCompra.Table.CurrentRecord.GetValue("pume")
                            colDestinoGravado = Me.dgvCompra.Table.CurrentRecord.GetValue("gravado")

                            colCostoMN = colcantidad * colPrecUnitAlmacen
                            colCostoME = colcantidad * colPrecUnitUSAlmacen

                            totalMN = colcantidad * colPrecUnit
                            totalME = colcantidad * colPrecUnitme

                            If colDestinoGravado = 1 Then
                                valPercepMN = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionMN")
                                valPercepME = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionME")
                            Else
                                valPercepMN = 0
                                valPercepME = 0

                            End If

                            '****************************************************************
                            Dim iva As Decimal = TmpIGV / 100

                            Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", colcantidad)
                            If colcantidad > 0 Then

                                colBI = (totalMN / (iva + 1))
                                colBIme = (totalME / (iva + 1))

                                Dim iv As Decimal = 0
                                Dim iv2 As Decimal = 0
                                iv = totalMN / (iva + 1)
                                iv2 = totalME / (iva + 1)

                                Igv = iv * (iva)
                                IgvME = iv2 * (iva)

                                'colIGV = (colMN / 1.18) * 0.18 ' colBI * 0.18
                                'colIGV_ME = (colME / 1.18) * 0.18 ' colBI_ME * 0.18

                            Else
                                colBI = 0
                                colBIme = 0
                                Igv = 0
                                IgvME = 0
                            End If

                            Select Case colDestinoGravado
                                Case 1
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", Math.Round(colBI, 2))
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", Math.Round(colBIme, 2))
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                                    '     Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("MontoSaldo", Math.Round(totalMN, 2))
                                    '    Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Math.Round(Igv, 2))
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", Math.Round(IgvME, 2))
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                                Case 2
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", Math.Round(totalMN, 2))
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", Math.Round(totalME, 2))
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                                    '   Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("MontoSaldo", Math.Round(totalMN, 2))
                                    '  Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                                    Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                            End Select
                            TotalTalesXcolumna()

#End Region
                        Case Else
                            'If (Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad") <= Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")) Then

                            colcantidad = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
                                cantidadDisponible = Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                                colPrecUnitAlmacen = 0 ' Me.dgvCompra.Table.CurrentRecord.GetValue("puKardex")
                                colPrecUnitUSAlmacen = 0 ' Me.dgvCompra.Table.CurrentRecord.GetValue("pukardeme")
                                colPrecUnit = Me.dgvCompra.Table.CurrentRecord.GetValue("pumn")
                                colPrecUnitme = Me.dgvCompra.Table.CurrentRecord.GetValue("pume")
                                colDestinoGravado = Me.dgvCompra.Table.CurrentRecord.GetValue("gravado")

                                colCostoMN = colcantidad * colPrecUnitAlmacen
                                colCostoME = colcantidad * colPrecUnitUSAlmacen

                                totalMN = colcantidad * colPrecUnit
                                totalME = colcantidad * colPrecUnitme

                                If colDestinoGravado = 1 Then
                                    valPercepMN = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionMN")
                                    valPercepME = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionME")
                                Else
                                    valPercepMN = 0
                                    valPercepME = 0

                                End If

                                '****************************************************************
                                Dim iva As Decimal = TmpIGV / 100

                                Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", colcantidad)
                                If colcantidad > 0 Then

                                    colBI = (totalMN / (iva + 1))
                                    colBIme = (totalME / (iva + 1))

                                    Dim iv As Decimal = 0
                                    Dim iv2 As Decimal = 0
                                    iv = totalMN / (iva + 1)
                                    iv2 = totalME / (iva + 1)

                                    Igv = iv * (iva)
                                    IgvME = iv2 * (iva)

                                    'colIGV = (colMN / 1.18) * 0.18 ' colBI * 0.18
                                    'colIGV_ME = (colME / 1.18) * 0.18 ' colBI_ME * 0.18

                                Else
                                    colBI = 0
                                    colBIme = 0
                                    Igv = 0
                                    IgvME = 0
                                End If

                                Select Case colDestinoGravado
                                    Case 1
                                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", Math.Round(colBI, 2))
                                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", Math.Round(colBIme, 2))
                                        Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                                        Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                                        '     Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                                        Me.dgvCompra.Table.CurrentRecord.SetValue("MontoSaldo", Math.Round(totalMN, 2))
                                        '    Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
                                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Math.Round(Igv, 2))
                                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", Math.Round(IgvME, 2))
                                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                                    Case 2
                                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", Math.Round(totalMN, 2))
                                        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", Math.Round(totalME, 2))
                                        Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                                        Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                                        '   Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                                        Me.dgvCompra.Table.CurrentRecord.SetValue("MontoSaldo", Math.Round(totalMN, 2))
                                        '  Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
                                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
                                        Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
                                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                                        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                                        Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                                End Select
                                TotalTalesXcolumna()
                            'Else
                            '    dgvCompra.Table.CurrentRecord.EndEdit()
                            '    lblEstado.Text = "La cantidad disponible es: " & Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                            '    Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 0.0)
                            '    Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", Math.Round(colBI, 2))
                            '    Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", Math.Round(colBIme, 2))
                            '    'Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                            '    'Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                            '    'Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                            '    Me.dgvCompra.Table.CurrentRecord.SetValue("MontoSaldo", Math.Round(totalMN, 2))
                            '    'Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
                            '    Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Math.Round(Igv, 2))
                            '    Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", Math.Round(IgvME, 2))
                            '    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                            '    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                            '    Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                            '    Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                            '    txtTotalBase.Text = 0.0
                            '    txtTotalBase2.Text = 0.0
                            '    txtTotalIva.Text = 0.0
                            '    lblTotalPercepcion.Text = 0.0
                            '    txtTotalPagar.Text = 0.0
                            '    PanelError.Visible = True
                            '    Timer1.Enabled = True
                            '    TiempoEjecutar(10)
                            'End If
                    End Select


            End Select
        End If
    End Sub

    Sub CalculosByCantidad(cant As Decimal)
        Dim colcantidad As Decimal = 0
        Dim cantidadDisponible As Decimal = 0
        Dim Igv As Decimal = 0
        Dim IgvME As Decimal = 0
        Dim totalMN As Decimal = 0
        Dim totalME As Decimal = 0
        Dim colBI As Decimal = 0
        Dim colBIme As Decimal = 0
        Dim colPrecUnit As Decimal = 0
        Dim colPrecUnitme As Decimal = 0
        Dim colDestinoGravado As Integer
        Dim colBonifica As String = Nothing

        Dim valPercepMN As Decimal = 0
        Dim valPercepME As Decimal = 0

        Dim colCostoMN As Decimal = 0
        Dim colCostoME As Decimal = 0
        Dim colPrecUnitAlmacen As Decimal = 0
        Dim colPrecUnitUSAlmacen As Decimal = 0

        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            Dim strTipoExistencia = Me.dgvCompra.Table.CurrentRecord.GetValue("tipoExistencia")
            Select Case strTipoExistencia
                Case "GS"
                    colcantidad = 1 ' Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
                    cantidadDisponible = 0 ' Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                    colPrecUnitAlmacen = 0 ' Me.dgvCompra.Table.CurrentRecord.GetValue("puKardex")
                    colPrecUnitUSAlmacen = 0 ' Me.dgvCompra.Table.CurrentRecord.GetValue("pukardeme")
                    colPrecUnit = Me.dgvCompra.Table.CurrentRecord.GetValue("totalmn")
                    colPrecUnitme = Me.dgvCompra.Table.CurrentRecord.GetValue("totalmn")
                    colDestinoGravado = Me.dgvCompra.Table.CurrentRecord.GetValue("gravado")

                    colCostoMN = 0 ' colcantidad * colPrecUnitAlmacen
                    colCostoME = 0 ' colcantidad * colPrecUnitUSAlmacen

                    totalMN = Me.dgvCompra.Table.CurrentRecord.GetValue("totalmn") ' colcantidad * colPrecUnit
                    totalME = Me.dgvCompra.Table.CurrentRecord.GetValue("totalme") ' colcantidad * colPrecUnitme

                    If colDestinoGravado = 1 Then
                        Dim iva As Decimal = TmpIGV / 100
                        colBI = (totalMN / (iva + 1))
                        colBIme = (totalME / (iva + 1))

                        Dim iv As Decimal = 0
                        Dim iv2 As Decimal = 0
                        iv = totalMN / (iva + 1)
                        iv2 = totalME / (iva + 1)

                        Igv = iv * (iva)
                        IgvME = iv2 * (iva)
                    Else

                        colBI = 0
                        colBIme = 0
                        Igv = 0
                        IgvME = 0

                    End If

                    '****************************************************************

                    Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", colcantidad)
                    If colcantidad > 0 Then



                        'colIGV = (colMN / 1.18) * 0.18 ' colBI * 0.18
                        'colIGV_ME = (colME / 1.18) * 0.18 ' colBI_ME * 0.18

                    Else

                    End If

                    Select Case colDestinoGravado
                        Case 1
                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", Math.Round(colBI, 2))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", Math.Round(colBIme, 2))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Math.Round(Igv, 2))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", Math.Round(IgvME, 2))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                        Case 2
                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", Math.Round(totalMN, 2))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", Math.Round(totalME, 2))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                    End Select
                    TotalTalesXcolumna()
                Case Else
                    'If (Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad") <= Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")) Then

                    colcantidad = cant 'Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
                        cantidadDisponible = Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                        colPrecUnitAlmacen = Me.dgvCompra.Table.CurrentRecord.GetValue("puKardex")
                        colPrecUnitUSAlmacen = Me.dgvCompra.Table.CurrentRecord.GetValue("pukardeme")
                        colPrecUnit = Me.dgvCompra.Table.CurrentRecord.GetValue("pumn")
                        colPrecUnitme = Me.dgvCompra.Table.CurrentRecord.GetValue("pume")
                        colDestinoGravado = Me.dgvCompra.Table.CurrentRecord.GetValue("gravado")

                        colCostoMN = colcantidad * colPrecUnitAlmacen
                        colCostoME = colcantidad * colPrecUnitUSAlmacen

                        totalMN = colcantidad * colPrecUnit
                        totalME = colcantidad * colPrecUnitme

                        If colDestinoGravado = 1 Then
                            valPercepMN = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionMN")
                            valPercepME = Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionME")
                        Else
                            valPercepMN = 0
                            valPercepME = 0

                        End If

                        '****************************************************************
                        Dim iva As Decimal = TmpIGV / 100

                        Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", colcantidad)
                        If colcantidad > 0 Then

                            colBI = (totalMN / (iva + 1))
                            colBIme = (totalME / (iva + 1))

                            Dim iv As Decimal = 0
                            Dim iv2 As Decimal = 0
                            iv = totalMN / (iva + 1)
                            iv2 = totalME / (iva + 1)

                            Igv = iv * (iva)
                            IgvME = iv2 * (iva)

                            'colIGV = (colMN / 1.18) * 0.18 ' colBI * 0.18
                            'colIGV_ME = (colME / 1.18) * 0.18 ' colBI_ME * 0.18

                        Else
                            colBI = 0
                            colBIme = 0
                            Igv = 0
                            IgvME = 0
                        End If

                        Select Case colDestinoGravado
                            Case 1
                                Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", Math.Round(colBI, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", Math.Round(colBIme, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Math.Round(Igv, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", Math.Round(IgvME, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                            Case 2
                                Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", Math.Round(totalMN, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", Math.Round(totalME, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
                                Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                                Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                        End Select
                        TotalTalesXcolumna()
                    'Else
                    '    dgvCompra.Table.CurrentRecord.EndEdit()
                    '    lblEstado.Text = "La cantidad disponible es: " & Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                    '    Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 0.0)
                    '    Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", Math.Round(colBI, 2))
                    '    Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", Math.Round(colBIme, 2))
                    '    'Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit)
                    '    'Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme)
                    '    Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                    '    Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
                    '    Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", Math.Round(Igv, 2))
                    '    Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", Math.Round(IgvME, 2))
                    '    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
                    '    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
                    '    Me.dgvCompra.Table.CurrentRecord.SetValue("costoMN", colCostoMN)
                    '    Me.dgvCompra.Table.CurrentRecord.SetValue("costoME", colCostoME)
                    '    txtTotalBase.Text = 0.0
                    '    txtTotalBase2.Text = 0.0
                    '    txtTotalIva.Text = 0.0
                    '    lblTotalPercepcion.Text = 0.0
                    '    txtTotalPagar.Text = 0.0
                    '    PanelError.Visible = True
                    '    Timer1.Enabled = True
                    '    TiempoEjecutar(10)
                    'End If
            End Select
        End If
    End Sub

    Sub CalculosByCantidadExistente(cant As Decimal, recordAlive As Record)
        Dim colcantidad As Decimal = 0
        Dim cantidadDisponible As Decimal = 0
        Dim Igv As Decimal = 0
        Dim IgvME As Decimal = 0
        Dim totalMN As Decimal = 0
        Dim totalME As Decimal = 0
        Dim colBI As Decimal = 0
        Dim colBIme As Decimal = 0
        Dim colPrecUnit As Decimal = 0
        Dim colPrecUnitme As Decimal = 0
        Dim colDestinoGravado As Integer
        Dim colBonifica As String = Nothing

        Dim valPercepMN As Decimal = 0
        Dim valPercepME As Decimal = 0

        Dim colCostoMN As Decimal = 0
        Dim colCostoME As Decimal = 0
        Dim colPrecUnitAlmacen As Decimal = 0
        Dim colPrecUnitUSAlmacen As Decimal = 0

        Dim strTipoExistencia = recordAlive.GetValue("tipoExistencia")
        Select Case strTipoExistencia
            Case "GS"
                colcantidad = 1 ' Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")
                cantidadDisponible = 0 ' Me.dgvCompra.Table.CurrentRecord.GetValue("canDisponible")
                colPrecUnitAlmacen = 0 ' Me.dgvCompra.Table.CurrentRecord.GetValue("puKardex")
                colPrecUnitUSAlmacen = 0 ' Me.dgvCompra.Table.CurrentRecord.GetValue("pukardeme")
                colPrecUnit = recordAlive.GetValue("totalmn")
                colPrecUnitme = recordAlive.GetValue("totalmn")
                colDestinoGravado = recordAlive.GetValue("gravado")

                colCostoMN = 0 ' colcantidad * colPrecUnitAlmacen
                colCostoME = 0 ' colcantidad * colPrecUnitUSAlmacen

                totalMN = recordAlive.GetValue("totalmn") ' colcantidad * colPrecUnit
                totalME = recordAlive.GetValue("totalme") ' colcantidad * colPrecUnitme

                If colDestinoGravado = 1 Then
                    Dim iva As Decimal = TmpIGV / 100
                    colBI = (totalMN / (iva + 1))
                    colBIme = (totalME / (iva + 1))

                    Dim iv As Decimal = 0
                    Dim iv2 As Decimal = 0
                    iv = totalMN / (iva + 1)
                    iv2 = totalME / (iva + 1)

                    Igv = iv * (iva)
                    IgvME = iv2 * (iva)
                Else

                    colBI = 0
                    colBIme = 0
                    Igv = 0
                    IgvME = 0

                End If

                '****************************************************************

                recordAlive.SetValue("cantidad", colcantidad)
                If colcantidad > 0 Then



                    'colIGV = (colMN / 1.18) * 0.18 ' colBI * 0.18
                    'colIGV_ME = (colME / 1.18) * 0.18 ' colBI_ME * 0.18

                Else

                End If

                Select Case colDestinoGravado
                    Case 1

                        recordAlive.SetValue("vcmn", Math.Round(colBI, 2))
                        recordAlive.SetValue("vcme", Math.Round(colBIme, 2))
                        recordAlive.SetValue("pumn", colPrecUnit)
                        recordAlive.SetValue("pume", colPrecUnitme)
                        recordAlive.SetValue("totalmn", Math.Round(totalMN, 2))
                        recordAlive.SetValue("totalme", Math.Round(totalME, 2))
                        recordAlive.SetValue("igvmn", Math.Round(Igv, 2))
                        recordAlive.SetValue("igvme", Math.Round(IgvME, 2))
                        recordAlive.SetValue("percepcionMN", 0)
                        recordAlive.SetValue("percepcionME", 0)
                        recordAlive.SetValue("costoMN", colCostoMN)
                        recordAlive.SetValue("costoME", colCostoME)
                    Case 2
                        recordAlive.SetValue("vcmn", Math.Round(totalMN, 2))
                        recordAlive.SetValue("vcme", Math.Round(totalME, 2))
                        recordAlive.SetValue("pumn", colPrecUnit)
                        recordAlive.SetValue("pume", colPrecUnitme)
                        recordAlive.SetValue("totalmn", Math.Round(totalMN, 2))
                        recordAlive.SetValue("totalme", Math.Round(totalME, 2))
                        recordAlive.SetValue("igvmn", 0)
                        recordAlive.SetValue("igvme", 0)
                        recordAlive.SetValue("percepcionMN", 0)
                        recordAlive.SetValue("percepcionME", 0)
                        recordAlive.SetValue("costoMN", colCostoMN)
                        recordAlive.SetValue("costoME", colCostoME)
                End Select
                TotalTalesXcolumna()
            Case Else
                'If (recordAlive.GetValue("cantidad") <= recordAlive.GetValue("canDisponible")) Then

                colcantidad = CDec(recordAlive.GetValue("cantidad")) + cant
                    cantidadDisponible = recordAlive.GetValue("canDisponible")
                    colPrecUnitAlmacen = recordAlive.GetValue("puKardex")
                    colPrecUnitUSAlmacen = recordAlive.GetValue("pukardeme")
                    colPrecUnit = recordAlive.GetValue("pumn")
                    colPrecUnitme = recordAlive.GetValue("pume")
                    colDestinoGravado = recordAlive.GetValue("gravado")

                    colCostoMN = colcantidad * colPrecUnitAlmacen
                    colCostoME = colcantidad * colPrecUnitUSAlmacen

                    totalMN = colcantidad * colPrecUnit
                    totalME = colcantidad * colPrecUnitme

                    If colDestinoGravado = 1 Then
                        valPercepMN = recordAlive.GetValue("percepcionMN")
                        valPercepME = recordAlive.GetValue("percepcionME")
                    Else
                        valPercepMN = 0
                        valPercepME = 0

                    End If

                    '****************************************************************
                    Dim iva As Decimal = TmpIGV / 100

                    recordAlive.SetValue("cantidad", colcantidad)
                    If colcantidad > 0 Then

                        colBI = (totalMN / (iva + 1))
                        colBIme = (totalME / (iva + 1))

                        Dim iv As Decimal = 0
                        Dim iv2 As Decimal = 0
                        iv = totalMN / (iva + 1)
                        iv2 = totalME / (iva + 1)

                        Igv = iv * (iva)
                        IgvME = iv2 * (iva)

                        'colIGV = (colMN / 1.18) * 0.18 ' colBI * 0.18
                        'colIGV_ME = (colME / 1.18) * 0.18 ' colBI_ME * 0.18

                    Else
                        colBI = 0
                        colBIme = 0
                        Igv = 0
                        IgvME = 0
                    End If

                    Select Case colDestinoGravado
                        Case 1
                            recordAlive.SetValue("vcmn", Math.Round(colBI, 2))
                            recordAlive.SetValue("vcme", Math.Round(colBIme, 2))
                            recordAlive.SetValue("pumn", colPrecUnit)
                        recordAlive.SetValue("pume", colPrecUnitme)
                        recordAlive.SetValue("totalmn", 0.0)
                        recordAlive.SetValue("totalmn", Math.Round(totalMN, 2))
                            recordAlive.SetValue("totalme", Math.Round(totalME, 2))
                            recordAlive.SetValue("igvmn", Math.Round(Igv, 2))
                            recordAlive.SetValue("igvme", Math.Round(IgvME, 2))
                            recordAlive.SetValue("percepcionMN", 0)
                            recordAlive.SetValue("percepcionME", 0)
                            recordAlive.SetValue("costoMN", colCostoMN)
                            recordAlive.SetValue("costoME", colCostoME)
                        Case 2
                            recordAlive.SetValue("vcmn", Math.Round(totalMN, 2))
                            recordAlive.SetValue("vcme", Math.Round(totalME, 2))
                            recordAlive.SetValue("pumn", colPrecUnit)
                            recordAlive.SetValue("pume", colPrecUnitme)
                            recordAlive.SetValue("totalmn", Math.Round(totalMN, 2))
                            recordAlive.SetValue("totalme", Math.Round(totalME, 2))
                            recordAlive.SetValue("igvmn", 0)
                            recordAlive.SetValue("igvme", 0)
                            recordAlive.SetValue("percepcionMN", 0)
                            recordAlive.SetValue("percepcionME", 0)
                            recordAlive.SetValue("costoMN", colCostoMN)
                            recordAlive.SetValue("costoME", colCostoME)
                    End Select
                    TotalTalesXcolumna()
                'Else
                '    dgvCompra.Table.CurrentRecord.EndEdit()
                '    lblEstado.Text = "La cantidad disponible es: " & recordAlive.GetValue("canDisponible")
                '    recordAlive.SetValue("cantidad", 0.0)
                '    recordAlive.SetValue("vcmn", Math.Round(colBI, 2))
                '    recordAlive.SetValue("vcme", Math.Round(colBIme, 2))
                '    'recordAlive.SetValue("pumn", colPrecUnit)
                '    'recordAlive.SetValue("pume", colPrecUnitme)
                '    recordAlive.SetValue("totalmn", Math.Round(totalMN, 2))
                '    recordAlive.SetValue("totalme", Math.Round(totalME, 2))
                '    recordAlive.SetValue("igvmn", Math.Round(Igv, 2))
                '    recordAlive.SetValue("igvme", Math.Round(IgvME, 2))
                '    recordAlive.SetValue("percepcionMN", 0)
                '    recordAlive.SetValue("percepcionME", 0)
                '    recordAlive.SetValue("costoMN", colCostoMN)
                '    recordAlive.SetValue("costoME", colCostoME)
                '    txtTotalBase.Text = 0.0
                '    txtTotalBase2.Text = 0.0
                '    txtTotalIva.Text = 0.0
                '    lblTotalPercepcion.Text = 0.0
                '    txtTotalPagar.Text = 0.0
                '    PanelError.Visible = True
                '    Timer1.Enabled = True
                '    TiempoEjecutar(10)
                'End If
        End Select

    End Sub

    Private Sub gridGroupingControl1_TableControlMouseDown(sender As Object, e As GridTableControlMouseEventArgs)
        Dim row As Integer = 0, col As Integer = 0
        dgvCompra.TableControl.PointToRowCol(e.Inner.Location, row, col)
        Dim style As GridTableCellStyleInfo = dgvCompra.TableControl.GetTableViewStyleInfo(row, col)
        'To check whether it is columnheadercell
        If style IsNot Nothing AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso e.Inner.Button = System.Windows.Forms.MouseButtons.Right Then
            '  gridGroupingControl1.ContextMenuStrip = fieldchooser.ContextMenu

        Else
            dgvCompra.ContextMenuStrip = ContextMenuStrip
            'If it is not column header cell
            'dgvCompra.ContextMenuStrip = ContextMenuStrip
        End If
    End Sub

    Private Sub contextMenuStrip_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)
        Cursor = Cursors.WaitCursor
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim nuevoprecio As New configuracionPrecioProducto
        If Not IsNothing(dgvCompra.Table.CurrentRecord) Then
            'Modificar precio'
            If e.ClickedItem.Text = "Modificar precio" Then
                Dim f As New FormModificarPecio
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog(Me)
            End If
            'Select Case usuario.CustomUsuario.CustomUsuarioRol.IDRol
            '    Case 1
            '        If e.ClickedItem.Text = "Agregar nuevo precio" Then
            '            Dim f As New frmNuevoPrecio
            '            f.txtProducto.Tag = dgvCompra.Table.CurrentRecord.GetValue("idProducto")
            '            f.txtProducto.Text = dgvCompra.Table.CurrentRecord.GetValue("item")
            '            f.txtGrav.Text = dgvCompra.Table.CurrentRecord.GetValue("gravado")
            '            f.StartPosition = FormStartPosition.CenterParent
            '            f.ShowDialog()

            '            nuevoprecio = precioSA.GetPreciosproductoMaxFecha(Integer.Parse(dgvCompra.Table.CurrentRecord.GetValue("idProducto")), Integer.Parse(dgvCompra.Table.CurrentRecord.GetValue("cboprecio")))

            '            If Not IsNothing(nuevoprecio) Then
            '                dgvCompra.Table.CurrentRecord.SetValue("pumn", nuevoprecio.precioMN)
            '                dgvCompra.Table.CurrentRecord.SetValue("pume", nuevoprecio.precioME)
            '                Calculos()

            '            Else
            '                MessageBox.Show("No tiene una configuración para este precio", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '                dgvCompra.Table.CurrentRecord.SetValue("pumn", 0)
            '                dgvCompra.Table.CurrentRecord.SetValue("pume", 0)
            '                Calculos()
            '            End If
            '        ElseIf e.ClickedItem.Text = "Ver tabla de precios" Then
            '            Dim f As New frmPreciosByArticulos(New detalleitems With {.codigodetalle = dgvCompra.Table.CurrentRecord.GetValue("idProducto"),
            '                                               .descripcionItem = dgvCompra.Table.CurrentRecord.GetValue("item")})
            '            f.StartPosition = FormStartPosition.CenterParent
            '            f.ShowDialog()
            '        End If

            '    Case Else
            '        MessageBox.Show("No tiene derechos de administrador, para realizar está tarea", "No autorizado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'End Select

        End If
        Cursor = Cursors.Default
    End Sub

    Public Sub CargarPrecios()
        Dim precioSA As New ConfiguracionPrecioSA
        Dim precio As New List(Of configuracionPrecio)
        Dim ggcStyle As GridTableCellStyleInfo = dgvCompra.TableDescriptor.Columns("cboprecio").Appearance.AnyRecordFieldCell

        precio.AddRange(precioSA.ListadoPrecios())
        'precio.Add(New configuracionPrecio With {.idPrecio = 0, .precio = "-Ver tabla de precios-"})

        ggcStyle.CellType = "ComboBox"
        ggcStyle.DataSource = precio ' precioSA.ListadoPrecios()
        ggcStyle.ValueMember = "idPrecio"
        ggcStyle.DisplayMember = "precio"
        ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive

    End Sub

    Sub ConteoLabelVentas()
        lblConteo.Text = "Artículos en Canasta: " & dgvCompra.Table.Records.Count
    End Sub

    Private Sub LimpiarProductosIguales(idItem As Integer)
        For Each r As Record In dgvCompra.Table.Records
            If Integer.Parse(r.GetValue("idProducto")) = idItem Then
                r.Delete()
            End If
        Next
    End Sub

    'Private Sub GetListaProductosEmpresaByCodigoBarra(lista As List(Of totalesAlmacen))
    '    Dim CanastaSA As New TotalesAlmacenSA
    '    'Dim lista As New listadoPrecios

    '    Dim dt As New DataTable()
    '    Try
    '        dt.Columns.Add("idEmpresa", GetType(String))
    '        dt.Columns.Add("destino", GetType(String))
    '        dt.Columns.Add("idItem", GetType(Integer))
    '        dt.Columns.Add("descripcion", GetType(String))
    '        dt.Columns.Add("unidad", GetType(String))
    '        dt.Columns.Add("idPres", GetType(String))
    '        dt.Columns.Add("presentacion", GetType(String))
    '        dt.Columns.Add("cantidad", GetType(Decimal))
    '        dt.Columns.Add("puKardexmn", GetType(Decimal))
    '        dt.Columns.Add("puKardexme", GetType(Decimal))
    '        dt.Columns.Add("importeMn", GetType(Decimal))
    '        dt.Columns.Add("importeME", GetType(Decimal))
    '        dt.Columns.Add("idalmacen", GetType(Integer))
    '        dt.Columns.Add("almacen", GetType(String))
    '        dt.Columns.Add("cantDisponible", GetType(Decimal))
    '        dt.Columns.Add("cantUso", GetType(Decimal))

    '        For Each i As totalesAlmacen In lista
    '            If CDec(i.cantidad) > 0 Then
    '                Dim valPrecUnitario As Decimal = CDec(i.importeSoles) / CDec(i.cantidad)
    '                Dim valPrecUnitarioUS As Decimal = CDec(i.importeDolares) / CDec(i.cantidad)
    '                Dim dr As DataRow = dt.NewRow()
    '                dr(0) = i.idEmpresa
    '                dr(1) = i.origenRecaudo
    '                dr(2) = i.idItem
    '                dr(3) = i.descripcion
    '                dr(4) = i.unidadMedida
    '                dr(5) = i.Presentacion
    '                dr(6) = i.NombrePresentacion
    '                dr(7) = i.cantidad
    '                dr(8) = valPrecUnitario
    '                dr(9) = valPrecUnitarioUS
    '                dr(10) = i.importeSoles
    '                dr(11) = i.importeDolares
    '                dr(12) = i.idAlmacen
    '                dr(13) = i.NomAlmacen
    '                dr(14) = 0
    '                dr(15) = 0
    '                dt.Rows.Add(dr)
    '            End If
    '        Next
    '        dgCanastaSel.DataSource = dt
    '    Catch ex As Exception
    '        MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
    '    End Try
    'End Sub
#End Region

#Region "Events"
    Private Sub TXTcOMPRADOR_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTcOMPRADOR.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        Else
            '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.pcLikeCategoria.Size = New Size(282, 128)
            Me.pcLikeCategoria.ParentControl = Me.TXTcOMPRADOR
            Me.pcLikeCategoria.ShowPopup(Point.Empty)
            Dim consulta As New List(Of entidad)
            consulta.Add(New entidad With {.nombreCompleto = "Agregar nuevo"})



            Dim consulta2 = (From n In listaClientes
                             Where n.nombreCompleto.StartsWith(TXTcOMPRADOR.Text) Or n.nrodoc.StartsWith(TXTcOMPRADOR.Text)).ToList




            consulta.AddRange(consulta2)
            FillLSVClientes(consulta)
            e.Handled = True
        End If

        If e.KeyCode = Keys.Down Then
            '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.pcLikeCategoria.Size = New Size(282, 128)
            Me.pcLikeCategoria.ParentControl = Me.TXTcOMPRADOR
            Me.pcLikeCategoria.ShowPopup(Point.Empty)
            LsvProveedor.Focus()
        End If
        '   End If

        ' e.SuppressKeyPress = True
        If e.KeyCode = Keys.Escape Then
            If Me.pcLikeCategoria.IsShowing() Then
                Me.pcLikeCategoria.HidePopup(PopupCloseType.Canceled)
            End If
        End If
    End Sub

    Private Sub FillLSVClientes(consulta As List(Of entidad))
        LsvProveedor.Items.Clear()
        '     Dim image = ImageList1.Images(0)
        For Each i In consulta
            Dim n As New ListViewItem(i.idEntidad)

            n.SubItems.Add(i.nombreCompleto)
            n.SubItems.Add(i.nrodoc)
            n.SubItems.Add(i.tipoDoc)
            LsvProveedor.Items.Add(n)
        Next
    End Sub

    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles LsvProveedor.MouseDoubleClick, TXTcOMPRADOR.MouseDoubleClick
        Me.pcLikeCategoria.HidePopup(PopupCloseType.Done)
    End Sub
    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            Me.dgvCompra.Table.CurrentRecord.Delete()
            TotalTalesXcolumna()

            If dgvCompra.Table.Records.Count > 0 Then
                dgvCompra.Table.Records(dgvCompra.Table.Records.Count - 1).SetCurrent()
                dgvCompra.Table.Records(dgvCompra.Table.Records.Count - 1).BeginEdit()
            End If
            ConteoLabelVentas()
        End If
    End Sub


    Private Function sumColumnByName(Column As String, sustentado As String) As Decimal
        Dim suma As Decimal = 0
        For Each i In dgvCompra.Table.Records
            If i.GetValue("marca") = sustentado Then
                Dim valNumber = i.GetValue(Column).ToString
                If valNumber.Trim.Length > 0 Then
                    suma += CDec(i.GetValue(Column))
                End If
            End If
        Next
        Return suma
    End Function

    Private Sub dgvCompra_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvCompra.QueryCellStyleInfo
        If e.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso e.TableCellIdentity.Column.Name = "chPago" Then
            e.Style.CellType = "CheckBox"
            e.Style.CellValueType = GetType(Boolean)
            '   e.Style.CellValue = CheckBoxValue
            e.Style.[ReadOnly] = False
            e.Style.CellAppearance = GridCellAppearance.Raised
            e.Style.Enabled = True
            e.Style.Description = e.Style.CellValue.ToString()
        End If

        If e.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso e.TableCellIdentity.Column.Name = "chBonif" Then
            e.Style.CellType = "CheckBox"
            e.Style.CellValueType = GetType(Boolean)
            '   e.Style.CellValue = CheckBoxValue
            e.Style.[ReadOnly] = False
            e.Style.CellAppearance = GridCellAppearance.Raised
            e.Style.Enabled = True
            e.Style.Description = e.Style.CellValue.ToString()
        End If

        e.Handled = True

        If Not IsNothing(e.TableCellIdentity.Column) Then
            Dim el As Syncfusion.Grouping.Element = e.TableCellIdentity.DisplayElement

            If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "vcmn")) Then
                Dim strTipoExistencia = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 18).CellValue
                Select Case strTipoExistencia
                    Case "GS"
                        'e.Style.BackColor = Color.Yellow
                        'e.Style.TextColor = Color.Black
                        e.Style.[ReadOnly] = True
                    Case Else
                        e.Style.[ReadOnly] = True
                End Select
            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "totalmn")) Then
                Dim strTipoExistencia = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 18).CellValue
                Select Case strTipoExistencia
                    Case "GS"
                        e.Style.BackColor = Color.Yellow
                        e.Style.TextColor = Color.Black
                        e.Style.[ReadOnly] = False
                    Case Else
                        e.Style.[ReadOnly] = True
                End Select


            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "item")) Then
                Dim strTipoExistencia = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 18).CellValue
                Select Case strTipoExistencia
                    Case "GS"
                        e.Style.[ReadOnly] = False
                    Case Else
                        e.Style.[ReadOnly] = True
                End Select
            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "gravado")) Then
                Dim strTipoExistencia = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 18).CellValue
                Select Case strTipoExistencia
                    Case "GS"
                        e.Style.[ReadOnly] = False
                    Case Else
                        e.Style.[ReadOnly] = True
                End Select
            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "cantidad")) Then
                Dim strTipoExistencia = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 18).CellValue
                'Dim cantidadActual = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 7).CellValue
                'Dim cantidadDisponible = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 25).CellValue

                'If cantidadActual > cantidadDisponible Then
                '    e.Style.CellValue = 0
                'End If

                Select Case strTipoExistencia
                    Case "GS"
                        e.Style.[ReadOnly] = True
                        e.Style.BackColor = Color.Yellow
                        e.Style.TextColor = Color.Black
                    Case Else
                        e.Style.[ReadOnly] = False
                        e.Style.BackColor = Color.Yellow
                        e.Style.TextColor = Color.Black
                End Select


            End If


        End If

        If (e.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell OrElse e.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell) Then

            Select Case cboTipoDoc.Text
                Case "PROFORMA"

                Case Else
                    'If e.TableCellIdentity.Column.MappingName = "cantidad" AndAlso CDbl(Fix(e.Style.CellValue)) > 0 Then
                    '    Dim el As Element = e.Style.TableCellIdentity.DisplayElement
                    '    If el IsNot Nothing AndAlso el.Kind = DisplayElementKind.Record Then
                    '        Dim r As Record = el.GetRecord()
                    '        If r Is Nothing Then Return
                    '        Dim cant As Decimal? = r.GetValue("cantidad")
                    '        'Dim cantDis As Decimal? = r.GetValue("canDisponible")

                    '        'If cant > cantDis Then
                    '        '    'e.Style.Enabled = False
                    '        '    e.Style.CellValue = 0
                    '        'End If
                    '    End If
                    'If e.TableCellIdentity.Column.MappingName = "pumn" AndAlso CDbl(Fix(e.Style.CellValue)) > 0 Then
                    '    Dim el As Element = e.Style.TableCellIdentity.DisplayElement
                    '    If el IsNot Nothing AndAlso el.Kind = DisplayElementKind.Record Then
                    '        Dim r As Record = el.GetRecord()
                    '        If r Is Nothing Then Return
                    '        Dim PrecioVenta As Decimal? = r.GetValue("pumn")
                    '        Dim PrecioMenor = r.GetValue("menor")
                    '        Dim PrecioMayor = r.GetValue("mayor")
                    '        Dim PrecioGranMayor = r.GetValue("gmayor")

                    '        Dim lista As New List(Of Decimal)
                    '        If PrecioMenor > 0 Then
                    '            lista.Add(PrecioMenor)
                    '        End If
                    '        If PrecioMayor > 0 Then
                    '            lista.Add(PrecioMayor)
                    '        End If
                    '        If PrecioGranMayor > 0 Then
                    '            lista.Add(PrecioGranMayor)
                    '        End If

                    '        Dim minimo = lista.Min()
                    '        Dim maximo = lista.Max()

                    '        If IsNumeric(minimo) AndAlso IsNumeric(maximo) Then
                    '            If PrecioVenta < minimo Then
                    '                e.Style.CellValue = minimo
                    '            Else

                    '            End If
                    '        End If


                    '        'If IsNumeric(PrecioMenor) AndAlso IsNumeric(PrecioGranMayor) Then
                    '        '        If PrecioVenta >= PrecioGranMayor And PrecioVenta <= PrecioMenor Then

                    '        '        Else
                    '        '            e.Style.CellValue = PrecioVenta
                    '        '        End If
                    '        '    End If
                    '        'End If
                    '    End If
                    'End If
            End Select
        End If
        'Select Case e.TableCellIdentity.TableCellType
        '    Case GridTableCellType.SummaryFieldCell
        '        If e.TableCellIdentity.SummaryColumn.Name = "totalDocMN" Then
        '            Dim sumaTotalDoc As Decimal = sumColumnByName("totalmn", "Doc.")
        '            e.Style.CellValue = sumaTotalDoc
        '        End If

        '        If e.TableCellIdentity.SummaryColumn.Name = "totalNotaMN" Then
        '            Dim sumaTotalNota As Decimal = sumColumnByName("totalmn", "Not.")
        '            e.Style.CellValue = sumaTotalNota
        '        End If

        '        Exit Select
        'End Select
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvCompra.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim cc As GridCurrentCell = dgvCompra.TableControl.CurrentCell
        cc.ConfirmChanges()

        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            Dim strTipoEx As String = dgvCompra.Table.CurrentRecord.GetValue("tipoExistencia")

            Select Case cc.ColIndex
                Case 1 ' CODIGO BARRA


                Case 2 ' seleccion de empresa stock

                Case 3 ' seleccionar precios de venta: Mayo,r menor, gran mayor
                    Dim r As Record = dgvCompra.Table.CurrentRecord
                    If Not IsNothing(r) Then

                        'Select Case Int32.Parse(r.GetValue("cboprecio"))
                        '    Case 0
                        '        'Dim f As New frmPreciosByArticulos(r)
                        '        'f.StartPosition = FormStartPosition.CenterParent
                        '        'f.ShowDialog()

                        '    Case Else
                        '        precio = precioSA.GetPreciosproductoMaxFecha(Int32.Parse(r.GetValue("idProducto").ToString), Int32.Parse(r.GetValue("cboprecio")))

                        '        If Not IsNothing(precio) Then
                        '            r.SetValue("pumn", precio.precioMN)
                        '            r.SetValue("pume", precio.precioME)
                        '            Calculos()
                        '        Else
                        '            MessageBox.Show("No tiene una configuración para este precio", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        '            r.SetValue("pumn", 0)
                        '            r.SetValue("pume", 0)
                        '            Calculos()
                        '        End If
                        'End Select

                    Else

                    End If

                Case 9 'precio unitario

                    Dim r As Record = dgvCompra.Table.CurrentRecord
                    Dim text As String = cc.Renderer.ControlText
                    If text.Trim.Length > 0 Then
                        Dim valuePrecioVenta As Decimal = Convert.ToDecimal(text)
                        cc.Renderer.ControlValue = valuePrecioVenta

                        Dim menor = r.GetValue("menor")
                        Dim mayor = r.GetValue("mayor")
                        Dim gmayor = r.GetValue("gmayor")


                        Dim lista As New List(Of Decimal)
                        If menor > 0 Then
                            lista.Add(menor)
                        End If
                        If mayor > 0 Then
                            lista.Add(mayor)
                        End If
                        If gmayor > 0 Then
                            lista.Add(gmayor)
                        End If

                        Dim minimo = lista.Min()
                        Dim maximo = lista.Max()

                        If valuePrecioVenta < menor Then
                            cc.Renderer.ControlValue = menor
                            cc.ConfirmChanges()
                            cc.EndEdit()
                            Calculos()
                            r.SetValue("tipoPrecio", "0")
                            Exit Sub
                        Else
                            If valuePrecioVenta = menor Then
                                r.SetValue("tipoPrecio", "1")
                            ElseIf valuePrecioVenta = mayor Then
                                r.SetValue("tipoPrecio", "2")
                            ElseIf valuePrecioVenta = gmayor Then
                                r.SetValue("tipoPrecio", "3")
                            Else
                                r.SetValue("tipoPrecio", "0")
                            End If
                            Calculos()
                        End If

                        'If valuePrecioVenta > gmayor And valuePrecioVenta > menor Then
                        '    cc.Renderer.ControlValue = menor
                        '    cc.ConfirmChanges()
                        '    cc.EndEdit()
                        '    Calculos()
                        '    Exit Sub
                        'ElseIf valuePrecioVenta > menor Then
                        '    cc.Renderer.ControlValue = menor
                        '    cc.ConfirmChanges()
                        '    cc.EndEdit()
                        '    Calculos()
                        '    Exit Sub
                        'ElseIf valuePrecioVenta < gmayor Then
                        '    cc.Renderer.ControlValue = menor
                        '    cc.ConfirmChanges()
                        '    cc.EndEdit()
                        '    Calculos()
                        '    Exit Sub
                        'Else
                        '    Calculos()
                        'End If

                    End If

            End Select
        End If

    End Sub

    Private Sub dgvCompra_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCompra.TableControlCellClick
        Dim style As GridTableCellStyleInfo = e.TableControl.Model(e.Inner.RowIndex, e.Inner.ColIndex)
        If style.Enabled Then
            If style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso style.TableCellIdentity.Column.Name = "chPago" Then
                e.Inner.Cancel = True
            End If
            '   Console.WriteLine(e.Inner.RowIndex.ToString() & "TableControlCellClick")
        End If

        Dim style2 As GridTableCellStyleInfo = e.TableControl.Model(e.Inner.RowIndex, e.Inner.ColIndex)
        If style2.Enabled Then
            If style2.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso style2.TableCellIdentity.Column.Name = "chBonif" Then
                e.Inner.Cancel = True
            End If
            '     Console.WriteLine(e.Inner.RowIndex.ToString() & "TableControlCellClick")
        End If
        Dim style3 As GridTableCellStyleInfo = e.TableControl.Model(e.Inner.RowIndex, e.Inner.ColIndex)
        If style3.Enabled Then
            If style3.TableCellIdentity.Column.Name = "item" Then
                '       e.Inner.Cancel = True
                dgvCompra.TableDescriptor.GroupedColumns.Clear()
                Dim nomproduct = Me.dgvCompra.TableModel(e.Inner.RowIndex, 5).CellValue
                'FormInventarioCanastaTotales = New FormInventarioCanastaTotales(cboalmacen.SelectedValue, nomproduct)
                'FormInventarioCanastaTotales.validaStocks = True
                'FormInventarioCanastaTotales.StartPosition = FormStartPosition.CenterScreen
                'FormInventarioCanastaTotales.Show(Me)
            End If

        End If
        If dgvCompra.Table.Records.Count > 0 Then
            GetUbicarPrecio(dgvCompra.Table.CurrentRecord)
        End If
    End Sub

    Private Sub GetUbicarPrecio()
        Dim precioSA As New detalleitemsSA
        Dim r As Record = dgvCompra.Table.CurrentRecord
        TextProduct.Text = r.GetValue("item")
        Dim precio = precioSA.GetPrecioPorProducto(Gempresas.IdEmpresaRuc, r.GetValue("idProducto"))
        If precio.Count > 0 Then
            For Each i In precio
                TextMenor.DecimalValue = i.precioMenor.GetValueOrDefault
                TextMayor.DecimalValue = i.precioMayor.GetValueOrDefault
                TextGMayor.DecimalValue = i.precioGranMayor.GetValueOrDefault
                If i.CustomDetalleCompra IsNot Nothing Then
                    If i.CustomDetalleCompra.monto1.GetValueOrDefault > 0 Then

                        If i.CustomDetalleCompra.documentocompra.tipoCompra = TIPO_COMPRA.COMPRA Then
                            Select Case i.CustomDetalleCompra.destino
                                Case 1
                                    Dim precioTotalConIva =
                           i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault

                                    Dim precioTotalSinIva = Math.Round(precioTotalConIva / 1.18, 2)

                                    '    dr(13) = precioTotalSinIva
                                    '   TextBoxPrecioCOmpra.DecimalValue = precioTotalConIva
                                    '    TextfechaCompra.Text = i.CustomDetalleCompra.FechaDoc.GetValueOrDefault
                                Case Else

                                    Dim precioTotalConIva = i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault
                                    '      Dim precioTotalSinIva = Math.Round(precioTotalConIva / 1.18, 2)

                                    '  dr(13) = precioTotalConIva
                                    '  TextBoxPrecioCOmpra.DecimalValue = precioTotalConIva
                                    '   TextfechaCompra.Text = i.CustomDetalleCompra.FechaDoc.GetValueOrDefault
                            End Select

                        Else

                            Select Case i.CustomDetalleCompra.destino
                                Case 1
                                    Dim precioTotalConIva2 = i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault

                                    Dim iva = precioTotalConIva2 * 0.18
                                    precioTotalConIva2 = Math.Round(iva + precioTotalConIva2, 2)

                                    Dim precioTotalConIva =
                           i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault

                                    '     TextBoxPrecioCOmpra.DecimalValue = precioTotalConIva
                                    '   dr(14) = precioTotalConIva2 '0 'precioTotalConIva
                                    '   TextfechaCompra.Text = i.CustomDetalleCompra.FechaDoc.GetValueOrDefault
                                Case Else

                                    Dim precioTotalConIva = i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault
                                    '      Dim precioTotalSinIva = Math.Round(precioTotalConIva / 1.18, 2)

                                    'TextBoxPrecioCOmpra.DecimalValue = precioTotalConIva
                                    'dr(14) = 0 'precioTotalConIva
                                    '  TextfechaCompra.Text = i.CustomDetalleCompra.FechaDoc.GetValueOrDefault
                            End Select

                        End If

                    End If
                End If
            Next

        End If

    End Sub

    Private Sub GetUbicarPrecio(r As Record)
        Dim precioSA As New detalleitemsSA
        TextProduct.Text = r.GetValue("item")

        Dim precioMenor = r.GetValue("menor")
        Dim precioMayor = r.GetValue("mayor")
        Dim precioGmayor = r.GetValue("gmayor")

        If r IsNot Nothing Then
            If precioMenor.ToString.Trim.Length > 0 Then
                TextMenor.DecimalValue = r.GetValue("menor")
            End If
            If precioMayor.ToString.Trim.Length > 0 Then
                TextMayor.DecimalValue = r.GetValue("mayor")
            End If
            If precioGmayor.ToString.Trim.Length > 0 Then
                TextGMayor.DecimalValue = r.GetValue("gmayor")
            End If
        Else
            TextMenor.DecimalValue = String.Empty
            TextMayor.DecimalValue = String.Empty
            TextGMayor.DecimalValue = String.Empty
        End If


        '   Dim precio = precioSA.GetPrecioPorProducto(Gempresas.IdEmpresaRuc, r.GetValue("idProducto"))
        'If precio.Count > 0 Then
        '    For Each i In precio
        '        TextMenor.DecimalValue = i.precioMenor.GetValueOrDefault
        '        TextMayor.DecimalValue = i.precioMayor.GetValueOrDefault
        '        TextGMayor.DecimalValue = i.precioGranMayor.GetValueOrDefault
        '        If i.CustomDetalleCompra IsNot Nothing Then
        '            If i.CustomDetalleCompra.monto1.GetValueOrDefault > 0 Then

        '                If i.CustomDetalleCompra.documentocompra.tipoCompra = TIPO_COMPRA.COMPRA Then
        '                    Select Case i.CustomDetalleCompra.destino
        '                        Case 1
        '                            Dim precioTotalConIva =
        '                   i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault

        '                            Dim precioTotalSinIva = Math.Round(precioTotalConIva / 1.18, 2)

        '                            '    dr(13) = precioTotalSinIva
        '                            '     TextBoxPrecioCOmpra.DecimalValue = precioTotalConIva
        '                            '   TextfechaCompra.Text = i.CustomDetalleCompra.FechaDoc.GetValueOrDefault
        '                        Case Else

        '                            Dim precioTotalConIva = i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault
        '                            '      Dim precioTotalSinIva = Math.Round(precioTotalConIva / 1.18, 2)

        '                            '  dr(13) = precioTotalConIva
        '                            '   TextBoxPrecioCOmpra.DecimalValue = precioTotalConIva
        '                            '     TextfechaCompra.Text = i.CustomDetalleCompra.FechaDoc.GetValueOrDefault
        '                    End Select

        '                Else

        '                    Select Case i.CustomDetalleCompra.destino
        '                        Case 1
        '                            Dim precioTotalConIva2 = i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault

        '                            Dim iva = precioTotalConIva2 * 0.18
        '                            precioTotalConIva2 = Math.Round(iva + precioTotalConIva2, 2)

        '                            Dim precioTotalConIva =
        '                   i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault

        '                            ' TextBoxPrecioCOmpra.DecimalValue = precioTotalConIva
        '                            '   dr(14) = precioTotalConIva2 '0 'precioTotalConIva
        '                            ' TextfechaCompra.Text = i.CustomDetalleCompra.FechaDoc.GetValueOrDefault
        '                        Case Else

        '                            Dim precioTotalConIva = i.CustomDetalleCompra.importe.GetValueOrDefault / i.CustomDetalleCompra.monto1.GetValueOrDefault
        '                            '      Dim precioTotalSinIva = Math.Round(precioTotalConIva / 1.18, 2)

        '                            ' TextBoxPrecioCOmpra.DecimalValue = precioTotalConIva
        '                            'dr(14) = 0 'precioTotalConIva
        '                            ' TextfechaCompra.Text = i.CustomDetalleCompra.FechaDoc.GetValueOrDefault
        '                    End Select

        '                End If

        '            End If
        '        End If
        '    Next

        'End If

    End Sub

    Private Sub dgvCompra_SaveCellText(sender As Object, e As GridCellTextEventArgs) Handles dgvCompra.SaveCellText
        Dim style As GridTableCellStyleInfo = DirectCast(e.Style, GridTableCellStyleInfo)
        If style.Enabled AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell Then
            '  Me.CheckBoxValue = Boolean.Parse(e.Text)
            e.Handled = True
        End If
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles dgvCompra.TableControlCurrentCellCloseDropDown
        e.TableControl.CurrentCell.EndEdit()
        e.TableControl.Table.TableDirty = True
        e.TableControl.Table.EndEdit()
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellChanged(sender As Object, e As GridTableControlEventArgs) Handles dgvCompra.TableControlCurrentCellChanged
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Dim precio As New configuracionPrecioProducto
        Dim cc As GridCurrentCell = dgvCompra.TableControl.CurrentCell
        cc.ConfirmChanges()
        Try
            If Not IsNothing(cc) Then
                Select Case cc.ColIndex
                    Case 1 ' CODIGO BARRA


                    Case 2 ' seleccion de empresa stock

                    Case 3 ' seleccionar precios de venta: Mayo,r menor, gran mayor
                        Dim r As Record = dgvCompra.Table.CurrentRecord
                        If Not IsNothing(r) Then

                            Select Case Int32.Parse(r.GetValue("cboprecio"))
                                Case 0
                                    'Dim f As New frmPreciosByArticulos(r)
                                    'f.StartPosition = FormStartPosition.CenterParent
                                    'f.ShowDialog()

                                Case Else
                                    dgvCompra.TableDescriptor.GroupedColumns.Clear()
                                    precio = precioSA.GetPreciosproductoMaxFecha(Int32.Parse(r.GetValue("idProducto").ToString), Int32.Parse(r.GetValue("cboprecio")))

                                    If Not IsNothing(precio) Then
                                        r.SetValue("pumn", precio.precioMN)
                                        r.SetValue("pume", precio.precioME)
                                        Calculos()
                                    Else
                                        MessageBox.Show("No tiene una configuración para este precio", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                        r.SetValue("pumn", 0)
                                        r.SetValue("pume", 0)
                                        Calculos()
                                    End If
                            End Select

                        Else

                        End If



                    Case 7 ' cantidad

                        Select Case cboTipoDoc.Text
                            Case "PROFORMA"
                                Dim r As Record = dgvCompra.Table.CurrentRecord
                                Dim text As String = cc.Renderer.ControlText
                                If text.Trim.Length > 0 Then
                                    Dim value As Decimal = Convert.ToDecimal(text)
                                    cc.Renderer.ControlValue = value
                                    Calculos()
                                End If


                            Case Else
                                Dim r As Record = dgvCompra.Table.CurrentRecord
                                Dim text As String = cc.Renderer.ControlText
                                If text.Trim.Length > 0 Then
                                    Dim value As Decimal = Convert.ToDecimal(text)
                                    cc.Renderer.ControlValue = value

                                    'Dim cantiDisponible = r.GetValue("canDisponible")
                                    'If value > cantiDisponible Then
                                    '    cc.Renderer.ControlValue = 0
                                    '    cc.ConfirmChanges()
                                    '    cc.EndEdit()
                                    '    Calculos()
                                    '    lblEstado.Text = "La cantidad disponible es: " & cantiDisponible
                                    '    PanelError.Visible = True
                                    '    Timer1.Enabled = True
                                    '    TiempoEjecutar(10)
                                    '    Exit Sub
                                    'Else
                                    Calculos()
                                    'End If

                                End If
                        End Select

                    Case 8
                        Dim r As Record = dgvCompra.Table.CurrentRecord
                        Calculos()

                    Case 9 'precio unitario

                        'Dim r As Record = dgvCompra.Table.CurrentRecord
                        'Dim text As String = cc.Renderer.ControlText
                        'If text.Trim.Length > 0 Then
                        '    Dim valuePrecioVenta As Decimal = Convert.ToDecimal(text)
                        '    cc.Renderer.ControlValue = valuePrecioVenta

                        '    Dim menor = r.GetValue("menor")
                        '    Dim gmayor = r.GetValue("gmayor")

                        '    'If valuePrecioVenta >= gmayor And valuePrecioVenta <= menor Then
                        '    '    Calculos()
                        '    'Else
                        '    '    'cc.Renderer.ControlValue = menor
                        '    '    cc.ConfirmChanges()
                        '    '    cc.EndEdit()
                        '    '    Calculos()
                        '    '    Exit Sub
                        '    'End If

                        '    If valuePrecioVenta > gmayor And valuePrecioVenta > menor Then
                        '        cc.Renderer.ControlValue = menor
                        '        'cc.ConfirmChanges()
                        '        'cc.EndEdit()
                        '        Calculos()
                        '        Exit Sub
                        '    ElseIf valuePrecioVenta > menor Then
                        '        cc.Renderer.ControlValue = menor
                        '        'cc.ConfirmChanges()
                        '        'cc.EndEdit()
                        '        Calculos()
                        '        Exit Sub
                        '    ElseIf valuePrecioVenta < gmayor Then
                        '        cc.Renderer.ControlValue = menor
                        '        'cc.ConfirmChanges()
                        '        'cc.EndEdit()
                        '        Calculos()
                        '        Exit Sub
                        '    Else
                        '        Calculos()
                        '    End If

                        'End If
                End Select
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



    End Sub

    'Private Sub dgvCompra_TableControlKeyDown(sender As Object, e As GridTableControlKeyEventArgs) Handles dgvCompra.TableControlKeyDown
    '    Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
    '    Dim precioSA As New ConfiguracionPrecioProductoSA
    '    Dim precio As New configuracionPrecioProducto
    '    Dim cc As GridCurrentCell = dgvCompra.TableControl.CurrentCell
    '    cc.ConfirmChanges()

    '    If Not IsNothing(cc) Or dgvCompra.TableControl.CurrentCell IsNot Nothing Then
    '        Select Case cc.ColIndex
    '            Case 1 ' CODIGO BARRA


    '            Case 2 ' seleccion de empresa stock

    '            Case 3 ' seleccionar precios de venta: Mayo,r menor, gran mayor
    '                Dim r As Record = dgvCompra.Table.CurrentRecord
    '                If Not IsNothing(r) Then

    '                    Select Case Int32.Parse(r.GetValue("cboprecio"))
    '                        Case 0
    '                            'Dim f As New frmPreciosByArticulos(r)
    '                            'f.StartPosition = FormStartPosition.CenterParent
    '                            'f.ShowDialog()

    '                        Case Else
    '                            precio = precioSA.GetPreciosproductoMaxFecha(Int32.Parse(r.GetValue("idProducto").ToString), Int32.Parse(r.GetValue("cboprecio")))

    '                            If Not IsNothing(precio) Then
    '                                r.SetValue("pumn", precio.precioMN)
    '                                r.SetValue("pume", precio.precioME)
    '                                Calculos()
    '                            Else
    '                                MessageBox.Show("No tiene una configuración para este precio", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                                r.SetValue("pumn", 0)
    '                                r.SetValue("pume", 0)
    '                                Calculos()
    '                            End If
    '                    End Select

    '                Else

    '                End If



    '            Case 7 ' cantidad
    '                'Select Case strTipoEx
    '                'Case "GS"
    '                Dim r As Record = dgvCompra.Table.CurrentRecord

    '                If (r.GetValue("cantidad") <= r.GetValue("canDisponible")) Then

    '                Else
    '                    cc.ConfirmChanges()
    '                    cc.EndEdit()

    '                End If
    '                Calculos()

    '                'End Select
    '            Case 8
    '                Dim r As Record = dgvCompra.Table.CurrentRecord
    '                Calculos()
    '        End Select
    '    End If
    'End Sub

    'Private Sub dgvCompra_TableControlKeyPress(sender As Object, e As GridTableControlKeyPressEventArgs) Handles dgvCompra.TableControlKeyPress
    '    Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
    '    Dim precioSA As New ConfiguracionPrecioProductoSA
    '    Dim precio As New configuracionPrecioProducto
    '    Dim cc As GridCurrentCell = dgvCompra.TableControl.CurrentCell
    '    cc.ConfirmChanges()

    '    If Not IsNothing(cc) Or dgvCompra.TableControl.CurrentCell IsNot Nothing Then
    '        Select Case cc.ColIndex
    '            Case 1 ' CODIGO BARRA


    '            Case 2 ' seleccion de empresa stock

    '            Case 3 ' seleccionar precios de venta: Mayo,r menor, gran mayor
    '                Dim r As Record = dgvCompra.Table.CurrentRecord
    '                If Not IsNothing(r) Then

    '                    Select Case Int32.Parse(r.GetValue("cboprecio"))
    '                        Case 0
    '                            'Dim f As New frmPreciosByArticulos(r)
    '                            'f.StartPosition = FormStartPosition.CenterParent
    '                            'f.ShowDialog()

    '                        Case Else
    '                            precio = precioSA.GetPreciosproductoMaxFecha(Int32.Parse(r.GetValue("idProducto").ToString), Int32.Parse(r.GetValue("cboprecio")))

    '                            If Not IsNothing(precio) Then
    '                                r.SetValue("pumn", precio.precioMN)
    '                                r.SetValue("pume", precio.precioME)
    '                                Calculos()
    '                            Else
    '                                MessageBox.Show("No tiene una configuración para este precio", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                                r.SetValue("pumn", 0)
    '                                r.SetValue("pume", 0)
    '                                Calculos()
    '                            End If
    '                    End Select

    '                Else

    '                End If



    '            Case 7 ' cantidad
    '                'Select Case strTipoEx
    '                'Case "GS"
    '                Dim r As Record = dgvCompra.Table.CurrentRecord

    '                If (r.GetValue("cantidad") <= r.GetValue("canDisponible")) Then

    '                Else
    '                    cc.ConfirmChanges()
    '                    cc.EndEdit()

    '                End If
    '                Calculos()

    '                'End Select
    '            Case 8
    '                Dim r As Record = dgvCompra.Table.CurrentRecord
    '                Calculos()
    '        End Select
    '    End If
    'End Sub

    Private Sub dgvCompra_TableControlLeftColChanged(sender As Object, e As GridTableControlRowColIndexChangedEventArgs) Handles dgvCompra.TableControlLeftColChanged

    End Sub

    Private Sub dgvCompra_TableControlKeyUp(sender As Object, e As GridTableControlKeyEventArgs) Handles dgvCompra.TableControlKeyUp
        'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        'Dim precioSA As New ConfiguracionPrecioProductoSA
        'Dim precio As New configuracionPrecioProducto
        'Dim cc As GridCurrentCell = dgvCompra.TableControl.CurrentCell
        'cc.ConfirmChanges()

        'If Not IsNothing(cc) Or dgvCompra.TableControl.CurrentCell IsNot Nothing Then
        '    Select Case cc.ColIndex
        '        Case 1 ' CODIGO BARRA


        '        Case 2 ' seleccion de empresa stock

        '        Case 3 ' seleccionar precios de venta: Mayo,r menor, gran mayor
        '            Dim r As Record = dgvCompra.Table.CurrentRecord
        '            If Not IsNothing(r) Then

        '                Select Case Int32.Parse(r.GetValue("cboprecio"))
        '                    Case 0
        '                        'Dim f As New frmPreciosByArticulos(r)
        '                        'f.StartPosition = FormStartPosition.CenterParent
        '                        'f.ShowDialog()

        '                    Case Else
        '                        precio = precioSA.GetPreciosproductoMaxFecha(Int32.Parse(r.GetValue("idProducto").ToString), Int32.Parse(r.GetValue("cboprecio")))

        '                        If Not IsNothing(precio) Then
        '                            r.SetValue("pumn", precio.precioMN)
        '                            r.SetValue("pume", precio.precioME)
        '                            Calculos()
        '                        Else
        '                            MessageBox.Show("No tiene una configuración para este precio", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '                            r.SetValue("pumn", 0)
        '                            r.SetValue("pume", 0)
        '                            Calculos()
        '                        End If
        '                End Select

        '            Else

        '            End If



        '        Case 7 ' cantidad
        '            'Select Case strTipoEx
        '            'Case "GS"
        '            Dim r As Record = dgvCompra.Table.CurrentRecord

        '            If (r.GetValue("cantidad") <= r.GetValue("canDisponible")) Then

        '            Else
        '                cc.ConfirmChanges()
        '                cc.EndEdit()

        '            End If
        '            Calculos()

        '            'End Select
        '        Case 8
        '            Dim r As Record = dgvCompra.Table.CurrentRecord
        '            Calculos()
        '    End Select
        'End If
    End Sub

    Private Sub gradientPanel2_Paint(sender As Object, e As PaintEventArgs) Handles gradientPanel2.Paint

    End Sub

    Private Sub cboTipoDoc_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboTipoDoc.SelectedValueChanged
        If cboTipoDoc.Text.Trim.Length > 0 Then
            Select Case cboTipoDoc.Text
                Case "BOLETA"

                    chAutoNumeracion.Enabled = True
                    If chAutoNumeracion.Checked = True Then
                        txtNumero.Clear()
                        txtSerie.Visible = False
                        txtSerie.ReadOnly = True
                        txtNumero.Visible = False
                        txtNumero.ReadOnly = True

                        ProgressBar2.Visible = True
                        ProgressBar2.Style = ProgressBarStyle.Marquee
                        BackgroundWorker1.RunWorkerAsync()
                    Else
                        txtNumero.Clear()
                        txtSerie.Visible = True
                        txtSerie.ReadOnly = False
                        txtNumero.Visible = True
                        txtNumero.ReadOnly = False
                    End If
                Case "FACTURA"

                    chAutoNumeracion.Enabled = True
                    If chAutoNumeracion.Checked = True Then
                        txtNumero.Clear()
                        txtSerie.Visible = False
                        txtSerie.ReadOnly = True
                        txtNumero.Visible = False
                        txtNumero.ReadOnly = True

                        ProgressBar2.Visible = True
                        ProgressBar2.Style = ProgressBarStyle.Marquee
                        BackgroundWorker1.RunWorkerAsync()
                    Else
                        txtNumero.Clear()
                        txtSerie.Visible = True
                        txtSerie.ReadOnly = False
                        txtNumero.Visible = True
                        txtNumero.ReadOnly = False
                    End If
                Case "NOTA DE VENTA"

                    chAutoNumeracion.Checked = False
                    chAutoNumeracion.Enabled = False
                    txtSerie.Visible = False
                    txtNumero.Visible = False
                    txtSerie.ReadOnly = False

                Case "BOLETA ELECTRONICA"

                    chAutoNumeracion.Enabled = True
                    chAutoNumeracion.Checked = True

                    'txtSerie.Visible = True
                    'txtSerie.Text = "B001"
                    'txtSerie.ReadOnly = True
                    'txtNumero.Visible = True
                    'txtNumero.ReadOnly = True
                    txtNumero.Clear()
                    txtSerie.Visible = False
                    txtSerie.ReadOnly = True
                    txtNumero.Visible = False
                    txtNumero.ReadOnly = True

                    ProgressBar2.Visible = True
                    ProgressBar2.Style = ProgressBarStyle.Marquee
                    BackgroundWorker1.RunWorkerAsync()
                Case "FACTURA ELECTRONICA"

                    chAutoNumeracion.Enabled = True
                    chAutoNumeracion.Checked = True

                    'txtSerie.Visible = True
                    'txtSerie.Text = "F001"
                    'txtSerie.ReadOnly = True
                    'txtNumero.Visible = True
                    'txtNumero.ReadOnly = True

                    txtNumero.Clear()
                    txtSerie.Visible = False
                    txtSerie.ReadOnly = True
                    txtNumero.Visible = False
                    txtNumero.ReadOnly = True


                    ProgressBar2.Visible = True
                    ProgressBar2.Style = ProgressBarStyle.Marquee
                    BackgroundWorker1.RunWorkerAsync()
                Case "PROFORMA"
                    txtNumero.Clear()
                    txtSerie.Visible = False
                    txtSerie.ReadOnly = True
                    txtNumero.Visible = False
                    txtNumero.ReadOnly = True

                    ProgressBar2.Visible = True
                    ProgressBar2.Style = ProgressBarStyle.Marquee
                    BackgroundWorker1.RunWorkerAsync()
            End Select
            GetResetCantidades()
        End If
    End Sub

    Private Sub GetResetCantidades()
        For Each i In dgvCompra.Table.Records
            i.SetValue("cantidad", 0)
        Next
        txtTotalBase.DecimalValue = 0
        txtTotalBase2.DecimalValue = 0
        txtTotalBase3.DecimalValue = 0
        txtTotalIva.DecimalValue = 0
        lblTotalPercepcion.DecimalValue = 0
        txtVentaTotal.DecimalValue = 0
        txtTotalPagar.DecimalValue = 0
        DigitalGauge2.Text = "0.00"
        DigitalGauge2.Value = "0.00"
        'Calculos()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        If BackgroundWorker1.CancellationPending Then
            ' MessageBox.Show("Up to here? ...")
            e.Cancel = True
        Else
            Dim strIdModulo As String = Nothing
            If cboTipoDoc.Text = "BOLETA" Then
                strIdModulo = "VT2"
            ElseIf cboTipoDoc.Text = "FACTURA" Then
                strIdModulo = "VT3"
            ElseIf cboTipoDoc.Text = "BOLETA ELECTRONICA" Then
                strIdModulo = "VT2E"
            ElseIf cboTipoDoc.Text = "FACTURA ELECTRONICA" Then
                strIdModulo = "VT3E"
            ElseIf cboTipoDoc.Text = "PROFORMA" Then
                strIdModulo = "COTIZACION"
            End If
            Dim strIDEmpresa = Gempresas.IdEmpresaRuc
            configuracionModuloV2(strIDEmpresa, strIdModulo, "", GEstableciento.IdEstablecimiento)
        End If
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If e.Cancelled Then

        Else
            'Select Case cboTipoDoc.Text
            '    Case "FACTURA ELECTRONICA", "BOLETA ELECTRONICA"
            '        txtSerie.Text = conf.Serie
            '        txtNumero.Text = conf.ValorActual + 1

            '        ProgressBar2.Visible = False
            '    Case Else
            txtSerie.Text = GConfiguracion.Serie
            ProgressBar2.Visible = False

            'End Select

        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

        Dim f As New FormUltimasVentas(TXTcOMPRADOR.Tag)
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)

        'Dim f As New frmCrearENtidades
        'f.CaptionLabels(0).Text = "Nuevo cliente"
        'f.strTipo = TIPO_ENTIDAD.CLIENTE
        'f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        ''f.tipoPersona(TIPO_ENTIDAD.CLIENTE)
        'f.StartPosition = FormStartPosition.CenterParent
        'f.ShowDialog()
        'If Not IsNothing(f.Tag) Then
        '    Dim c = CType(f.Tag, entidad)
        '    listaClientes.Add(c)
        '    TXTcOMPRADOR.Text = c.nombreCompleto
        '    txtruc.Text = c.nrodoc
        '    TXTcOMPRADOR.Tag = c.idEntidad
        '    txtruc.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        '    txtruc.Visible = True
        '    TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        'End If
    End Sub

    Private Sub TXTcOMPRADOR_MouseDoubleClick(sender As Object, e As MouseEventArgs)
        TXTcOMPRADOR.SelectAll()
    End Sub

    Private Sub btGrabar_Click(sender As Object, e As EventArgs) Handles btGrabar.Click
        Try
            If ValidarGrabado() = True Then
                '   Grabar()
                btGrabar.Enabled = False
                Select Case cboTipoDoc.Text
                    Case "BOLETA", "FACTURA"
                        'GrabarVentaDuplex()

                        TipoVentaGeneral = TIPO_VENTA.VENTA_POS_DIRECTA

                        GrabarVentaCasoEspecial()

                    Case "FACTURA ELECTRONICA", "BOLETA ELECTRONICA"

                        TipoVentaGeneral = TIPO_VENTA.VENTA_ELECTRONICA
                        GrabarVentaCasoEspecial()


                    Case "NOTA DE VENTA"
                        GrabarNotaDeVenta()
                    Case "PROFORMA"
                        GrabarProforma()
                End Select
                btGrabar.Enabled = True
            End If
        Catch ex As Exception
            objPleaseWait.Close()
            MsgBox(ex.Message)
            btGrabar.Enabled = True
        End Try
    End Sub

    Private Sub bgCombos_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgCombos.DoWork
        If bgCombos.CancellationPending Then
            ' MessageBox.Show("Up to here? ...")
            e.Cancel = True
        Else
            GetCombos()
        End If
    End Sub

    Private Sub bgCombos_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgCombos.RunWorkerCompleted
        If e.Cancelled Then

        Else
            Loadcontroles()
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        'FormInventarioCanastaTotales = New FormInventarioCanastaTotales(cboalmacen.SelectedValue)
        'FormInventarioCanastaTotales.validaStocks = True
        'FormInventarioCanastaTotales.StartPosition = FormStartPosition.CenterScreen
        '  FormInventarioCanastaTotales.Show(Me)

        'With FormInventarioCanastaTotalesSinv
        '    .validaStocks = True
        '    .StartPosition = FormStartPosition.CenterScreen
        '    ' .Show(Me)
        '    .ShowDialog(Me)
        '    If dgvCompra.Table.Records.Count > 0 Then
        '        dgvCompra.Focus()
        '        Me.dgvCompra.TableControl.CurrentCell.MoveTo(dgvCompra.Table.Records.Count - 1, 7, Syncfusion.Windows.Forms.Grid.GridSetCurrentCellOptions.SetFocus)
        '        dgvCompra.Table.Records(dgvCompra.Table.Records.Count - 1).SetCurrent()
        '        dgvCompra.Table.Records(dgvCompra.Table.Records.Count - 1).BeginEdit()
        '        Me.ActiveControl = Me.dgvCompra.TableControl
        '        dgvCompra.WantTabKey = True

        '        'Dim colIndex As Integer = Me.dgvCompra.TableDescriptor.FieldToColIndex(0)
        '        'Dim rowIndex As Integer = Me.dgvCompra.Table.Records(0).GetRowIndex()
        '        'Me.dgvCompra.TableControl.CurrentCell.MoveTo(rowIndex, colIndex, Syncfusion.Windows.Forms.Grid.GridSetCurrentCellOptions.SetFocus)
        '        'Me.dgvCompra.Focus()
        '    End If
        'End With

        FormInventarioCanastaTotales = New FormCanastaTotalesServVer2()
        FormInventarioCanastaTotales.validaStocks = True
        FormInventarioCanastaTotales.StartPosition = FormStartPosition.CenterScreen
        FormInventarioCanastaTotales.Show(Me)

        'frmCanastaInventary = New frminfoInventario(cboalmacen.SelectedValue)
        'frmCanastaInventary.StartPosition = FormStartPosition.CenterScreen
        'frmCanastaInventary.Show(Me)
    End Sub

    Private Sub bgVenta_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgVenta.DoWork
        If bgVenta.CancellationPending Then
            ' MessageBox.Show("Up to here? ...")
            e.Cancel = True
        Else
            GetDocumentoVentaID(Integer.Parse(Tag))
        End If

        'While Not bgVenta.CancellationPending
        '    System.Threading.Thread.Sleep(1000)
        'End While

        'If bgVenta.CancellationPending Then
        '    e.Cancel = True
        'End If
    End Sub

    Private Sub bgVenta_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgVenta.RunWorkerCompleted
        If e.Cancelled Then
            'MessageBox.Show("Worker cancelled")
        Else
            GetDocumentoVentaIDDone()
        End If

    End Sub

    Private Sub ChPagoAvanzado_OnChange(sender As Object, e As EventArgs) Handles ChPagoAvanzado.OnChange
        If ChPagoAvanzado.Checked = True Then
            ChPagoDirecto.Checked = False
            cbocajaPago.Visible = False
        Else
            '       cbocajaPago.Visible = True
        End If
        If ChPagoAvanzado.Checked = False AndAlso ChPagoDirecto.Checked = False Then
            LblPagoCredito.Visible = True
        Else
            LblPagoCredito.Visible = False
        End If
    End Sub

    Private Sub ChPagoQuestion_OnChange(sender As Object, e As EventArgs) Handles ChPagoDirecto.OnChange
        PagoDirectoCheck()
    End Sub

    Private Sub PagoDirectoCheck()
        If ChPagoDirecto.Checked Then
            cbocajaPago.Visible = True
            ' ChPagoAvanzado.Visible = True
            ChPagoAvanzado.Checked = False
            Label8.Visible = True
        Else
            cbocajaPago.Visible = False
            ''  ChPagoAvanzado.Visible = False
            'ChPagoAvanzado.Checked = False
            'Label8.Visible = False
        End If
        If ChPagoAvanzado.Checked = False AndAlso ChPagoDirecto.Checked = False Then
            LblPagoCredito.Visible = True
        Else
            LblPagoCredito.Visible = False
        End If
    End Sub

    Private Sub pcLikeCategoria_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcLikeCategoria.CloseUp
        Me.Cursor = Cursors.WaitCursor

        If e.PopupCloseType = PopupCloseType.Done Then
            If LsvProveedor.SelectedItems.Count > 0 Then
                If LsvProveedor.SelectedItems(0).SubItems(1).Text = "Agregar nuevo" Then
                    Dim f As New frmCrearENtidades
                    f.CaptionLabels(0).Text = "Nuevo cliente"
                    f.strTipo = TIPO_ENTIDAD.CLIENTE
                    f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    'f.tipoPersona(TIPO_ENTIDAD.CLIENTE)
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()
                    If Not IsNothing(f.Tag) Then
                        Dim c = CType(f.Tag, entidad)
                        listaClientes.Add(c)
                        txtTipoDocClie.Text = c.tipoDoc
                        TXTcOMPRADOR.Text = c.nombreCompleto
                        txtruc.Text = c.nrodoc
                        TXTcOMPRADOR.Tag = c.idEntidad
                        txtruc.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        txtruc.Visible = True
                        TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                    End If
                Else
                    TXTcOMPRADOR.Text = LsvProveedor.SelectedItems(0).SubItems(1).Text
                    TXTcOMPRADOR.Tag = LsvProveedor.SelectedItems(0).SubItems(0).Text
                    TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                    txtruc.Text = LsvProveedor.SelectedItems(0).SubItems(2).Text
                    txtTipoDocClie.Text = LsvProveedor.SelectedItems(0).SubItems(3).Text
                    txtruc.Visible = True
                End If
                'ListaMercaderiasXIdHijo(Val(txtSubCategoria.Tag), cboTipoExistencia.SelectedValue)
            End If
        End If

        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.TXTcOMPRADOR.Focus()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    'Private Function VerificarItemDuplicadoV2(cantidad As Decimal, lote As Integer, intIdItem As Integer) As Boolean
    '    VerificarItemDuplicadoV2 = False
    '    Dim colIdItem As Integer
    '    Dim codigoLote As Integer

    '    colIdItem = intIdItem
    '    codigoLote = lote
    '    For Each i In dgvCompra.Table.Records
    '        If colIdItem = i.GetValue("idProducto") AndAlso codigoLote = i.GetValue("codigoLote") Then
    '            CalculosByCantidadExistente(cantidad, i)
    '            VerificarItemDuplicadoV2 = True
    '            Exit For
    '        End If
    '    Next
    'End Function

    'Private Sub ValidarItemsDuplicados(intIdItem As Integer, tipoprecio As String)
    '    Dim colIdItem As Integer
    '    Dim precio As String

    '    colIdItem = intIdItem
    '    precio = tipoprecio

    '    For Each i In dgvCompra.Table.Records
    '        If colIdItem = i.GetValue("idProducto") AndAlso precio = i.GetValue("cboprecio") Then
    '            Throw New Exception("El artículo " & i.GetValue("item") & ", ya se encuentra en la canasta. Ingrese otro")
    '        End If
    '    Next
    'End Sub
    Private Function VerificarItemDuplicadoV2(cantidad As Decimal, lote As Integer, intIdItem As Integer) As Boolean
        VerificarItemDuplicadoV2 = False
        Dim colIdItem As Integer
        Dim codigoLote As Integer

        colIdItem = intIdItem
        codigoLote = lote
        For Each i In dgvCompra.Table.Records
            If colIdItem = i.GetValue("idProducto") Then
                'CalculosByCantidadExistente(cantidad, i)
                VerificarItemDuplicadoV2 = True
                MessageBox.Show("El producto ya existe en la canaste de venta!", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit For
            End If
        Next
    End Function
    Dim objPleaseWait As New FeedbackForm()
    Public Sub EnviarProducto(productoBE As totalesAlmacen) Implements IForm.EnviarProducto
        Try
            Dim cantidad = productoBE.cantidad
            Dim valPUmn As Decimal = 0
            Dim valPUme As Decimal = 0

            valPUmn = productoBE.PMprecioMN
            valPUme = productoBE.PMprecioME

            'With productoSA.InvocarProductoID(r.GetValue("idItem"))

            'Select Case productoBE.SelecionDirecta
            '    Case True
            '        cantidad = 1
            '    Case False
            '        cantidad = InputBox("Ingrese cantidad a vender", productoBE.descripcion, "")
            'End Select

            'objPleaseWait = New FeedbackForm()
            'objPleaseWait.StartPosition = FormStartPosition.CenterScreen
            'objPleaseWait.Show()
            'Application.DoEvents()

            'If IsNumeric(cantidad) Then
            '    If cantidad <= 0 Then
            '        MessageBox.Show("La cantidad ingresada debe ser mayor a cero!", "Validación stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '        Exit Sub
            '        Cursor = Cursors.Default
            '    End If

            '    If (CDec(cantidad) > productoBE.cantidad) Then
            '        MessageBox.Show("La cantidad ingresada no debe exceder la disponible!", "Validación stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '        Exit Sub
            '        Cursor = Cursors.Default
            '    End If

            'Dim existeEnCanasta = VerificarItemDuplicado(CDec(cantidad), productoBE.codigoLote, productoBE.idItem, productoBE.tipoConfiguracion)
            Dim existeEnCanasta = VerificarItemDuplicadoV2(CDec(productoBE.cantidad), productoBE.codigoLote, productoBE.idItem)
            If existeEnCanasta Then

            Else
                'CalculosByCantidad(CDec(cantidad))

                Dim colBI As Decimal = 0
                Dim colBIme As Decimal = 0
                Dim Igv As Decimal = 0
                Dim IgvME As Decimal = 0
                Dim cantidadDisponible = productoBE.cantidad
                Dim colPrecUnitAlmacen = valPUmn
                Dim colPrecUnitUSAlmacen = valPUmn
                Dim colPrecUnit = valPUmn
                Dim colPrecUnitme = valPUme
                Dim colDestinoGravado = productoBE.origenRecaudo

                Dim colCostoMN = productoBE.cantidad * colPrecUnitAlmacen
                Dim colCostoME = productoBE.cantidad * colPrecUnitUSAlmacen

                Dim totalMN = productoBE.cantidad * colPrecUnit
                Dim totalME = productoBE.cantidad * colPrecUnitme

                Dim iva As Decimal = TmpIGV / 100

                Select Case productoBE.origenRecaudo
                    Case OperacionGravada.Grabado
                        If cantidad > 0 Then

                            colBI = (totalMN / (iva + 1))
                            colBIme = (totalME / (iva + 1))

                            Dim iv As Decimal = 0
                            Dim iv2 As Decimal = 0
                            iv = totalMN / (iva + 1)
                            iv2 = totalME / (iva + 1)

                            Igv = iv * (iva)
                            IgvME = iv2 * (iva)

                            'colIGV = (colMN / 1.18) * 0.18 ' colBI * 0.18
                            'colIGV_ME = (colME / 1.18) * 0.18 ' colBI_ME * 0.18

                        Else
                            colBI = 0
                            colBIme = 0
                            Igv = 0
                            IgvME = 0
                        End If
                    Case OperacionGravada.Exonerado, OperacionGravada.Inafecto
                        If cantidad > 0 Then
                            colBI = (totalMN)
                            colBIme = (totalME)
                            Igv = 0
                            IgvME = 0
                        Else
                            colBI = 0
                            colBIme = 0
                            Igv = 0
                            IgvME = 0
                        End If
                End Select


                With dgvCompra.Table
                    .AddNewRecord.SetCurrent()
                    .AddNewRecord.BeginEdit()
                    .CurrentRecord.SetValue("codigo", 0)
                    .CurrentRecord.SetValue("gravado", productoBE.origenRecaudo)
                    .CurrentRecord.SetValue("idProducto", productoBE.idItem)
                    .CurrentRecord.SetValue("item", productoBE.descripcion)
                    .CurrentRecord.SetValue("um", productoBE.idUnidad)
                    .CurrentRecord.SetValue("cantidad", productoBE.cantidad)
                    .CurrentRecord.SetValue("canDisponible", productoBE.cantidad)
                    .CurrentRecord.SetValue("vcmn", Math.Round(colBI, 2))
                    '.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                    .CurrentRecord.SetValue("MontoSaldo", Math.Round(totalMN, 2))

                    .CurrentRecord.SetValue("vcme", Math.Round(colBIme, 2))
                    '.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
                    .CurrentRecord.SetValue("igvmn", Math.Round(Igv, 2))
                    .CurrentRecord.SetValue("igvme", Math.Round(IgvME, 2))
                    .CurrentRecord.SetValue("tipoExistencia", TipoExistencia.Mercaderia)
                    .CurrentRecord.SetValue("marca", productoBE.Marca) 'Susuentado y no sustentado

                    .CurrentRecord.SetValue("pumn", valPUmn)
                    .CurrentRecord.SetValue("pume", valPUme)

                    .CurrentRecord.SetValue("puKardex", valPUmn)
                    .CurrentRecord.SetValue("pukardeme", valPUmn)

                    .CurrentRecord.SetValue("chPago", False)
                    .CurrentRecord.SetValue("valPago", "No Pagado")

                    .CurrentRecord.SetValue("chBonif", False)
                    .CurrentRecord.SetValue("valBonif", "N")
                    '   If .tipoExistencia <> "GS" Then
                    .CurrentRecord.SetValue("almacen", Nothing)
                    .CurrentRecord.SetValue("presentacion", Nothing)

                    .CurrentRecord.SetValue("percepcionMN", FormatNumber(0, 2))
                    .CurrentRecord.SetValue("percepcionME", FormatNumber(0, 2))
                    .CurrentRecord.SetValue("costoMN", colCostoMN)
                    .CurrentRecord.SetValue("costoME", colCostoME)
                    .CurrentRecord.SetValue("tipoPrecio", productoBE.tipoConfiguracion)
                    .CurrentRecord.SetValue("cboprecio", Integer.Parse(productoBE.tipoConfiguracion))
                    .CurrentRecord.SetValue("cat", StatusCategoriaVenta.Productos)
                    .CurrentRecord.SetValue("codigoLote", productoBE.codigoLote)
                    .CurrentRecord.SetValue("codBarra", productoBE.CodigoBarra)
                    .CurrentRecord.SetValue("empresa", Gempresas.IdEmpresaRuc)
                    .CurrentRecord.SetValue("tipoventa", "V")
                    .CurrentRecord.SetValue("cantidad2", productoBE.CantidadComprada)

                    .CurrentRecord.SetValue("menor", productoBE.montoDsctounitMenorMN)
                    .CurrentRecord.SetValue("mayor", productoBE.montoDsctounitMayorMN)
                    .CurrentRecord.SetValue("gmayor", productoBE.montoDsctounitGMayorMN)
                    .AddNewRecord.EndEdit()
                    .TableDirty = True
                End With
            End If

            ConteoLabelVentas()
            'Calculos()
            TotalTalesXcolumna()

            'Dim conexos = InventarioSA.ListProductsConexos(New totalesAlmacen With {.idMovimiento = productoBE.idMovimiento})
            'If conexos.Count > 0 Then
            '    If MessageBox.Show("El producto tiene, articulos conexos, desea agregarlos", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            '        GetproductsConexos(valPUmn, valPUme, conexos)
            '    End If
            'End If
            'Else
            '    MessageBox.Show("Ingrese una cantidad válida!", "Validar cantidad", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    Return
            'End If

            objPleaseWait.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Verificar producto")
        End Try
    End Sub

    Private Sub GetproductsConexos(valPUmn As Decimal, valPUme As Decimal, conexos As List(Of totalesAlmacen))
        For Each i In conexos
            With dgvCompra.Table
                .AddNewRecord.SetCurrent()
                .AddNewRecord.BeginEdit()
                .CurrentRecord.SetValue("codigo", 0)
                .CurrentRecord.SetValue("gravado", i.origenRecaudo)
                .CurrentRecord.SetValue("idProducto", i.idItem)
                .CurrentRecord.SetValue("item", i.descripcion)
                .CurrentRecord.SetValue("um", i.idUnidad)
                .CurrentRecord.SetValue("cantidad", 0)
                .CurrentRecord.SetValue("canDisponible", i.cantidad)
                .CurrentRecord.SetValue("vcmn", 0)
                .CurrentRecord.SetValue("totalmn", 0)
                .CurrentRecord.SetValue("MontoSaldo", 0)

                .CurrentRecord.SetValue("vcme", 0)
                .CurrentRecord.SetValue("totalme", 0)
                .CurrentRecord.SetValue("igvmn", 0)
                .CurrentRecord.SetValue("igvme", 0)
                .CurrentRecord.SetValue("tipoExistencia", TipoExistencia.Mercaderia)
                .CurrentRecord.SetValue("marca", Nothing)

                .CurrentRecord.SetValue("pumn", valPUmn)
                .CurrentRecord.SetValue("pume", valPUme)

                .CurrentRecord.SetValue("puKardex", i.importeSoles / i.cantidad)
                .CurrentRecord.SetValue("pukardeme", i.importeDolares / i.cantidad)

                .CurrentRecord.SetValue("chPago", False)
                .CurrentRecord.SetValue("valPago", "No Pagado")

                .CurrentRecord.SetValue("chBonif", False)
                .CurrentRecord.SetValue("valBonif", "N")
                '   If .tipoExistencia <> "GS" Then
                .CurrentRecord.SetValue("almacen", i.idAlmacen)
                .CurrentRecord.SetValue("presentacion", i.NomAlmacen)

                .CurrentRecord.SetValue("percepcionMN", FormatNumber(0, 2))
                .CurrentRecord.SetValue("percepcionME", FormatNumber(0, 2))
                .CurrentRecord.SetValue("costoMN", 0)
                .CurrentRecord.SetValue("costoME", 0)
                .CurrentRecord.SetValue("tipoPrecio", i.tipoConfiguracion)
                .CurrentRecord.SetValue("cboprecio", Integer.Parse(i.tipoConfiguracion))
                .CurrentRecord.SetValue("cat", 0)
                .CurrentRecord.SetValue("codigoLote", i.codigoLote)
                .CurrentRecord.SetValue("codBarra", i.CodigoBarra)
                .CurrentRecord.SetValue("empresa", Gempresas.IdEmpresaRuc)
                .AddNewRecord.EndEdit()
                .TableDirty = True
            End With
        Next
    End Sub

    Public Sub CambiarPrecio(precio As configuracionPrecioProducto) Implements IPrecio.CambiarPrecio
        dgvCompra.Table.CurrentRecord.SetValue("pumn", precio.precioMN)
        dgvCompra.Table.CurrentRecord.SetValue("pume", precio.precioME)
        dgvCompra.Refresh()
        Calculos()
        TotalTalesXcolumna()
    End Sub

    Public Sub EnviarListaArticulos(lista As List(Of totalesAlmacen)) Implements IListaInventario.EnviarListaArticulos
        LimpiarProductosIguales(lista(0).idItem)
        For Each i In lista
            EnvioProductoSolo(i)
        Next
        ConteoLabelVentas()
        TotalTalesXcolumna()
    End Sub

    Sub EnvioProductoSolo(productoBE As totalesAlmacen)
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Try
            Dim cantidad = Nothing
            Dim valPUmn As Decimal = 0
            Dim valPUme As Decimal = 0
            cantidad = productoBE.cantidad
            valPUmn = productoBE.PMprecioMN
            valPUme = productoBE.PMprecioME
            Dim existeEnCanasta = VerificarItemDuplicadoV2(CDec(cantidad), 0, productoBE.idItem)
            If existeEnCanasta Then

            Else
                Dim colBI As Decimal = 0
                Dim colBIme As Decimal = 0
                Dim Igv As Decimal = 0
                Dim IgvME As Decimal = 0
                Dim cantidadDisponible = productoBE.cantidad
                Dim colPrecUnitAlmacen = productoBE.importeSoles / productoBE.cantidad
                Dim colPrecUnitUSAlmacen = productoBE.importeDolares / productoBE.cantidad
                Dim colPrecUnit = valPUmn
                Dim colPrecUnitme = valPUme
                Dim colDestinoGravado = productoBE.origenRecaudo

                Dim colCostoMN = cantidad * colPrecUnitAlmacen
                Dim colCostoME = cantidad * colPrecUnitUSAlmacen

                Dim totalMN = cantidad * colPrecUnit
                Dim totalME = cantidad * colPrecUnitme

                Dim iva As Decimal = TmpIGV / 100

                Select Case productoBE.origenRecaudo
                    Case OperacionGravada.Grabado
                        If cantidad > 0 Then

                            colBI = (totalMN / (iva + 1))
                            colBIme = (totalME / (iva + 1))

                            Dim iv As Decimal = 0
                            Dim iv2 As Decimal = 0
                            iv = totalMN / (iva + 1)
                            iv2 = totalME / (iva + 1)

                            Igv = iv * (iva)
                            IgvME = iv2 * (iva)

                            'colIGV = (colMN / 1.18) * 0.18 ' colBI * 0.18
                            'colIGV_ME = (colME / 1.18) * 0.18 ' colBI_ME * 0.18

                        Else
                            colBI = 0
                            colBIme = 0
                            Igv = 0
                            IgvME = 0
                        End If
                    Case OperacionGravada.Exonerado, OperacionGravada.Inafecto
                        If cantidad > 0 Then
                            colBI = (totalMN)
                            colBIme = (totalME)
                            Igv = 0
                            IgvME = 0
                        Else
                            colBI = 0
                            colBIme = 0
                            Igv = 0
                            IgvME = 0
                        End If
                End Select

                With dgvCompra.Table
                    .AddNewRecord.SetCurrent()
                    .AddNewRecord.BeginEdit()
                    .CurrentRecord.SetValue("codigo", 0)
                    .CurrentRecord.SetValue("gravado", productoBE.origenRecaudo)
                    .CurrentRecord.SetValue("idProducto", productoBE.idItem)
                    .CurrentRecord.SetValue("item", productoBE.descripcion)
                    .CurrentRecord.SetValue("um", productoBE.idUnidad)
                    .CurrentRecord.SetValue("cantidad", cantidad)
                    .CurrentRecord.SetValue("canDisponible", productoBE.cantidad2)
                    .CurrentRecord.SetValue("vcmn", Math.Round(colBI, 2))
                    '.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                    .CurrentRecord.SetValue("MontoSaldo", Math.Round(totalMN, 2))

                    .CurrentRecord.SetValue("vcme", Math.Round(colBIme, 2))
                    '.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
                    .CurrentRecord.SetValue("igvmn", Math.Round(Igv, 2))
                    .CurrentRecord.SetValue("igvme", Math.Round(IgvME, 2))
                    .CurrentRecord.SetValue("tipoExistencia", TipoExistencia.Mercaderia)
                    .CurrentRecord.SetValue("marca", Nothing) ') If(productoBE.CustomLote.productoSustentado = True, "Doc.", "Not.")) 'Susuentado y no sustentado

                    .CurrentRecord.SetValue("pumn", valPUmn)
                    .CurrentRecord.SetValue("pume", valPUme)

                    .CurrentRecord.SetValue("puKardex", productoBE.importeSoles / productoBE.cantidad)
                    .CurrentRecord.SetValue("pukardeme", productoBE.importeDolares / productoBE.cantidad)

                    .CurrentRecord.SetValue("chPago", False)
                    .CurrentRecord.SetValue("valPago", "No Pagado")

                    .CurrentRecord.SetValue("chBonif", False)
                    .CurrentRecord.SetValue("valBonif", "N")
                    '   If .tipoExistencia <> "GS" Then
                    .CurrentRecord.SetValue("almacen", productoBE.idAlmacen)
                    .CurrentRecord.SetValue("presentacion", productoBE.NomAlmacen)

                    .CurrentRecord.SetValue("percepcionMN", FormatNumber(0, 2))
                    .CurrentRecord.SetValue("percepcionME", FormatNumber(0, 2))
                    .CurrentRecord.SetValue("costoMN", colCostoMN)
                    .CurrentRecord.SetValue("costoME", colCostoME)
                    .CurrentRecord.SetValue("tipoPrecio", productoBE.tipoConfiguracion)
                    .CurrentRecord.SetValue("cboprecio", Integer.Parse(productoBE.tipoConfiguracion))
                    .CurrentRecord.SetValue("cat", StatusCategoriaVenta.Productos)
                    .CurrentRecord.SetValue("codigoLote", 0) ' productoBE.codigoLote)
                    .CurrentRecord.SetValue("codBarra", productoBE.CodigoBarra)
                    .CurrentRecord.SetValue("empresa", Gempresas.IdEmpresaRuc)
                    .CurrentRecord.SetValue("tipoventa", "V")
                    .CurrentRecord.SetValue("cantidad2", productoBE.CantidadComprada)

                    .CurrentRecord.SetValue("menor", productoBE.montoDsctounitMenorMN)
                    .CurrentRecord.SetValue("mayor", productoBE.montoDsctounitMayorMN)
                    .CurrentRecord.SetValue("gmayor", productoBE.montoDsctounitGMayorMN)
                    .AddNewRecord.EndEdit()
                    .TableDirty = True
                End With
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Verificar producto")
        End Try
    End Sub


    Sub EnvioProductoConsignado(productoBE As totalesAlmacen)
        Dim precioSA As New ConfiguracionPrecioProductoSA
        Try
            Dim cantidad = Nothing
            Dim valPUmn As Decimal = 0
            Dim valPUme As Decimal = 0


            cantidad = productoBE.cantidad

            'Dim precios = precioSA.ListarPreciosXproductoMaxFecha(0, productoBE.idItem)

            'If precios.Count = 0 Then
            '    MessageBox.Show("El producto seleccionado no tiene precios configurados!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)

            '    Exit Sub
            'End If
            'productoBE.PMprecioMN = precios.FirstOrDefault.precioMN ' Me.GridGroupingControl2.Table.CurrentRecord.GetValue("Preciomn")
            'productoBE.PMprecioME = precios.FirstOrDefault.precioME
            'productoBE.tipoConfiguracion = precios.FirstOrDefault.idPrecio
            valPUmn = productoBE.PMprecioMN
            valPUme = productoBE.PMprecioME

            'Dim existeEnCanasta = VerificarItemDuplicado(CDec(cantidad), productoBE.codigoLote, productoBE.idItem, productoBE.tipoConfiguracion)
            ' If existeEnCanasta Then

            ' Else
            CalculosByCantidad(CDec(cantidad))

            Dim colBI As Decimal = 0
            Dim colBIme As Decimal = 0
            Dim Igv As Decimal = 0
            Dim IgvME As Decimal = 0
            Dim cantidadDisponible = productoBE.cantidad
            Dim colPrecUnitAlmacen = productoBE.importeSoles / productoBE.cantidad
            Dim colPrecUnitUSAlmacen = productoBE.importeDolares / productoBE.cantidad
            Dim colPrecUnit = valPUmn
            Dim colPrecUnitme = valPUme
            Dim colDestinoGravado = productoBE.origenRecaudo

            Dim colCostoMN = cantidad * colPrecUnitAlmacen
            Dim colCostoME = cantidad * colPrecUnitUSAlmacen

            Dim totalMN = cantidad * colPrecUnit
            Dim totalME = cantidad * colPrecUnitme

            Dim iva As Decimal = TmpIGV / 100

            Select Case productoBE.origenRecaudo
                Case OperacionGravada.Grabado
                    If cantidad > 0 Then

                        colBI = (totalMN / (iva + 1))
                        colBIme = (totalME / (iva + 1))

                        Dim iv As Decimal = 0
                        Dim iv2 As Decimal = 0
                        iv = totalMN / (iva + 1)
                        iv2 = totalME / (iva + 1)

                        Igv = iv * (iva)
                        IgvME = iv2 * (iva)

                        'colIGV = (colMN / 1.18) * 0.18 ' colBI * 0.18
                        'colIGV_ME = (colME / 1.18) * 0.18 ' colBI_ME * 0.18

                    Else
                        colBI = 0
                        colBIme = 0
                        Igv = 0
                        IgvME = 0
                    End If
                Case OperacionGravada.Exonerado, OperacionGravada.Inafecto
                    If cantidad > 0 Then
                        colBI = (totalMN)
                        colBIme = (totalME)
                        Igv = 0
                        IgvME = 0
                    Else
                        colBI = 0
                        colBIme = 0
                        Igv = 0
                        IgvME = 0
                    End If
            End Select


            With dgvCompra.Table
                .AddNewRecord.SetCurrent()
                .AddNewRecord.BeginEdit()
                .CurrentRecord.SetValue("codigo", 0)
                .CurrentRecord.SetValue("gravado", productoBE.origenRecaudo)
                .CurrentRecord.SetValue("idProducto", productoBE.idItem)
                .CurrentRecord.SetValue("item", productoBE.descripcion)
                .CurrentRecord.SetValue("um", productoBE.idUnidad)
                .CurrentRecord.SetValue("cantidad", cantidad)
                .CurrentRecord.SetValue("canDisponible", 100000)
                .CurrentRecord.SetValue("vcmn", Math.Round(colBI, 2))
                .CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
                .CurrentRecord.SetValue("MontoSaldo", Math.Round(totalMN, 2))

                .CurrentRecord.SetValue("vcme", Math.Round(colBIme, 2))
                .CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
                .CurrentRecord.SetValue("igvmn", Math.Round(Igv, 2))
                .CurrentRecord.SetValue("igvme", Math.Round(IgvME, 2))
                .CurrentRecord.SetValue("tipoExistencia", TipoExistencia.Mercaderia)
                .CurrentRecord.SetValue("marca", "Doc.") 'Susuentado y no sustentado

                .CurrentRecord.SetValue("pumn", valPUmn)
                .CurrentRecord.SetValue("pume", valPUme)

                .CurrentRecord.SetValue("puKardex", productoBE.importeSoles / productoBE.cantidad)
                .CurrentRecord.SetValue("pukardeme", productoBE.importeDolares / productoBE.cantidad)

                .CurrentRecord.SetValue("chPago", False)
                .CurrentRecord.SetValue("valPago", "No Pagado")

                .CurrentRecord.SetValue("chBonif", False)
                .CurrentRecord.SetValue("valBonif", "N")
                '   If .tipoExistencia <> "GS" Then
                .CurrentRecord.SetValue("almacen", cboalmacen.SelectedValue)
                .CurrentRecord.SetValue("presentacion", cboalmacen.Text)

                .CurrentRecord.SetValue("percepcionMN", FormatNumber(0, 2))
                .CurrentRecord.SetValue("percepcionME", FormatNumber(0, 2))
                .CurrentRecord.SetValue("costoMN", colCostoMN)
                .CurrentRecord.SetValue("costoME", colCostoME)
                .CurrentRecord.SetValue("tipoPrecio", 1)
                .CurrentRecord.SetValue("cboprecio", 1)
                .CurrentRecord.SetValue("cat", StatusCategoriaVenta.ProductosEnConsigna)
                .CurrentRecord.SetValue("codigoLote", "-")
                .CurrentRecord.SetValue("codBarra", "-")
                .CurrentRecord.SetValue("empresa", Gempresas.IdEmpresaRuc)
                .CurrentRecord.SetValue("tipoventa", "V")
                .AddNewRecord.EndEdit()
                .TableDirty = True
            End With
            '    End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Verificar producto")
        End Try
    End Sub

    Public Sub EnviarConsigna(be As totalesAlmacen) Implements IProductoConsignado.EnviarConsigna
        EnvioProductoConsignado(be)
    End Sub

    Private Sub ToolStripLabel1_Click(sender As Object, e As EventArgs) Handles ToolStripLabel1.Click
        Dim f As New FormCanastaOfertas
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Cursor = Cursors.WaitCursor
        'FormVentaEnConsigna = New FormVentaEnConsigna
        'FormVentaEnConsigna.StartPosition = FormStartPosition.CenterScreen
        'FormVentaEnConsigna.ShowDialog(Me)
        FormNotaCompraDirecta = New FormNotaCompraDirecta(txtFecha.Value)
        FormNotaCompraDirecta.StartPosition = FormStartPosition.CenterScreen
        FormNotaCompraDirecta.ShowDialog(Me)
        Cursor = Cursors.Arrow
    End Sub

    Private Sub chAutoNumeracion_OnChange(sender As Object, e As EventArgs) Handles chAutoNumeracion.OnChange
        If chAutoNumeracion.Checked = True Then
            txtNumero.Clear()
            txtSerie.Visible = False
            txtSerie.ReadOnly = True
            txtNumero.Visible = False
            txtNumero.ReadOnly = True
            cboTipoDoc_SelectedValueChanged(sender, e)
        ElseIf chAutoNumeracion.Checked = False Then
            txtNumero.Clear()
            txtSerie.Visible = True
            txtSerie.Enabled = True
            txtSerie.ReadOnly = False
            txtNumero.Visible = True
            txtNumero.ReadOnly = False
            txtNumero.Enabled = True

        End If
    End Sub

    Private Sub cboTipoDoc_Click(sender As Object, e As EventArgs) Handles cboTipoDoc.Click

    End Sub

    Private Sub TXTcOMPRADOR_TextChanged(sender As Object, e As EventArgs) Handles TXTcOMPRADOR.TextChanged
        TXTcOMPRADOR.ForeColor = Color.Black
        TXTcOMPRADOR.Tag = Nothing
        If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            txtruc.Visible = True
        Else
            txtruc.Visible = False
        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        If dgvCompra.Table.CurrentRecord IsNot Nothing Then
            Dim f As New FormModificarPecio
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
        End If
    End Sub

    Private Sub FormVentaGeneral_Load(sender As Object, e As EventArgs) Handles Me.Load
        dgvCompra.TableDescriptor.Columns("pumn").Width = 60
        dgvCompra.TableDescriptor.Columns("vcmn").Width = 0 '65
        dgvCompra.TableDescriptor.Columns("igvmn").Width = 0 '65
        dgvCompra.TableDescriptor.Columns("totalmn").Width = 70

        dgvCompra.TableDescriptor.Columns("pume").Width = 0
        dgvCompra.TableDescriptor.Columns("vcme").Width = 0
        dgvCompra.TableDescriptor.Columns("igvme").Width = 0
        dgvCompra.TableDescriptor.Columns("totalme").Width = 0

        dgvCompra.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
        CargarPrecios()
        lblConteo.Visible = True
        'dgvCompra.TableDescriptor.Columns("item").Appearance.AnyRecordFieldCell.CellType = "LinkLabelCell"
        DigitalGauge2.ForeColor = Color.Black
        dgvCompra.TableDescriptor.Columns("pumn").ReadOnly = True
        dgvCompra.Refresh()
    End Sub

    Public Sub RecuperarOferta(be As oferta) Implements IOferta.RecuperarOferta
        If be IsNot Nothing Then
            InsertarOfertaEnCanasta(be)
        End If
    End Sub

    Private Sub btnPegadoEspecial_Click(sender As Object, e As EventArgs) Handles btnPegadoEspecial.Click
        If Not IsNothing(ClipBoardDocumento) Then
            UbicarDocumentoPegado()
        End If
    End Sub

    Public Sub UbicarDocumentoPegado()
        Dim ventaSA As New documentoVentaAbarrotesSA
        With ClipBoardDocumento.documentoventaAbarrotes
            txtFecha.Value = .fechaDoc
            lblPerido.Text = .fechaPeriodo
            'txtSerie.Text = .serieVenta
            'txtNumero.Text = .numeroVenta
            'txtNumero.Visible = True
            'Dim codigoComprobante = .tipoDocumento
            'Select Case codigoComprobante
            '    Case "12.1", "03"
            '        cboTipoDoc.Text = "BOLETA"
            '    Case "12.2", "01"
            '        cboTipoDoc.Text = "FACTURA"

            '    Case "9907"
            '        cboTipoDoc.Text = "NOTA DE VENTA"
            'End Select
            'cboTipoDoc.SelectedValue = .tipoDocumento
            'cboTipoDoc.Enabled = False
            dgvCompra.TableDescriptor.Columns("pumn").Width = 60
            dgvCompra.TableDescriptor.Columns("vcmn").Width = 65
            dgvCompra.TableDescriptor.Columns("igvmn").Width = 65
            dgvCompra.TableDescriptor.Columns("totalmn").Width = 70

            dgvCompra.TableDescriptor.Columns("pume").Width = 0
            dgvCompra.TableDescriptor.Columns("vcme").Width = 0
            dgvCompra.TableDescriptor.Columns("igvme").Width = 0
            dgvCompra.TableDescriptor.Columns("totalme").Width = 0

            If Not IsNothing(entidad) Then
                txtruc.Text = entidad.nrodoc
                TXTcOMPRADOR.Tag = entidad.idEntidad
                TXTcOMPRADOR.Text = entidad.nombreCompleto
                TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                txtruc.Visible = True
            Else
                TXTcOMPRADOR.Text = .nombrePedido
            End If
            txtGlosa.Text = .glosa
        End With

        'DETALLE DE LA COMPRA
        dgvCompra.Table.Records.DeleteAll()
        For Each i In ClipBoardDocumento.documentoventaAbarrotes.documentoventaAbarrotesDet.ToList
            'Dim lote = loteSA.GetLoteByID(i.codigoLote)
            Dim productoInventory = ventaSA.GetInventoryProductoID(i.idItem, i.idAlmacenOrigen)

            Me.dgvCompra.Table.AddNewRecord.SetCurrent()
            Me.dgvCompra.Table.AddNewRecord.BeginEdit()
            Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", i.destino)
            Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", i.idItem)
            Me.dgvCompra.Table.CurrentRecord.SetValue("item", i.nombreItem)
            Me.dgvCompra.Table.CurrentRecord.SetValue("um", i.unidad1)
            Me.dgvCompra.Table.CurrentRecord.SetValue("canDisponible", productoInventory.stock.GetValueOrDefault)
            Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", 0)
            '    Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", i.importeMN)

            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", 0)
            '    Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", i.importeME)
            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", i.tipoExistencia)
            'Me.dgvCompra.Table.CurrentRecord.SetValue("marca", If(lote.productoSustentado = True, "Doc.", "Not."))

            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("presentacion", productoInventory.descripcionAlmacen)
            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", i.idAlmacenOrigen)

            If productoInventory.menor > 0 Then
                Me.dgvCompra.Table.CurrentRecord.SetValue("tipoPrecio", "1")
                Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", productoInventory.menor)
            ElseIf productoInventory.mayor > 0 Then
                Me.dgvCompra.Table.CurrentRecord.SetValue("tipoPrecio", "2")
                Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", productoInventory.mayor)
            ElseIf productoInventory.granMayor > 0 Then
                Me.dgvCompra.Table.CurrentRecord.SetValue("tipoPrecio", "3")
                Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", productoInventory.granMayor)
            Else
                Me.dgvCompra.Table.CurrentRecord.SetValue("tipoPrecio", "0")
                Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", 0)
            End If
            Me.dgvCompra.Table.CurrentRecord.SetValue("menor", productoInventory.menor)
            Me.dgvCompra.Table.CurrentRecord.SetValue("mayor", productoInventory.mayor)
            Me.dgvCompra.Table.CurrentRecord.SetValue("gmayor", productoInventory.granMayor)

            Me.dgvCompra.Table.AddNewRecord.EndEdit()
        Next
        btGrabar.Enabled = True
        TotalTalesXcolumna()
        ConteoLabelVentas()
        'Dim objEntidad As New entidadSA
        'Dim nEntidad As New entidad
        'Try

        '    txtSerieGuia.Text = ClipBoardDocumento.documentocompra.serie
        '    txtNumeroGuia.Text = ClipBoardDocumento.documentocompra.numeroDoc

        '    'CABECERA COMPROBANT
        '    cboMesCompra.SelectedValue = String.Format("{0:00}", ClipBoardDocumento.documentocompra.fechaDoc.Value.Month)
        '    TxtDia.Text = ClipBoardDocumento.documentocompra.fechaDoc.Value.Day
        '    cboAnio.Text = ClipBoardDocumento.documentocompra.fechaDoc.Value.Year
        '    txtFechaGuia.Value = ClipBoardDocumento.documentocompra.fechaDoc
        '    cboTipoDoc.SelectedValue = ClipBoardDocumento.documentocompra.tipoDoc
        '    txtSerie.Text = ClipBoardDocumento.documentocompra.serie
        '    txtNumero.Text = ClipBoardDocumento.documentocompra.numeroDoc
        '    cboMoneda.SelectedValue = ClipBoardDocumento.documentocompra.monedaDoc

        '    Select Case cboMoneda.SelectedValue
        '        Case 1

        '            dgvCompra.TableDescriptor.Columns("pumn").Width = 60
        '            dgvCompra.TableDescriptor.Columns("vcmn").Width = 65
        '            dgvCompra.TableDescriptor.Columns("igvmn").Width = 65
        '            dgvCompra.TableDescriptor.Columns("totalmn").Width = 70
        '            dgvCompra.TableDescriptor.Columns("percepcionMN").Width = 70
        '            dgvCompra.TableDescriptor.Columns("tipoExistencia").Width = 50

        '            dgvCompra.TableDescriptor.Columns("pume").Width = 0
        '            dgvCompra.TableDescriptor.Columns("vcme").Width = 0
        '            dgvCompra.TableDescriptor.Columns("igvme").Width = 0
        '            dgvCompra.TableDescriptor.Columns("totalme").Width = 0
        '            dgvCompra.TableDescriptor.Columns("percepcionME").Width = 0

        '            cboMoneda.SelectedValue = 1
        '            '      tb19.ToggleState = ToggleButton2.ToggleButtonState.ON
        '        Case 2

        '            dgvCompra.TableDescriptor.Columns("pumn").Width = 0
        '            dgvCompra.TableDescriptor.Columns("vcmn").Width = 0
        '            dgvCompra.TableDescriptor.Columns("igvmn").Width = 0
        '            dgvCompra.TableDescriptor.Columns("totalmn").Width = 0
        '            dgvCompra.TableDescriptor.Columns("percepcionMN").Width = 0

        '            dgvCompra.TableDescriptor.Columns("tipoExistencia").Width = 50
        '            dgvCompra.TableDescriptor.Columns("pume").Width = 60
        '            dgvCompra.TableDescriptor.Columns("vcme").Width = 65
        '            dgvCompra.TableDescriptor.Columns("igvme").Width = 65
        '            dgvCompra.TableDescriptor.Columns("totalme").Width = 70
        '            dgvCompra.TableDescriptor.Columns("percepcionME").Width = 70
        '            cboMoneda.SelectedValue = 2
        '            '    tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF
        '    End Select

        '    nEntidad = objEntidad.UbicarEntidadPorID(ClipBoardDocumento.documentocompra.idProveedor).First()
        '    txtruc.Text = nEntidad.nrodoc
        '    txtProveedor.Tag = nEntidad.idEntidad
        '    txtProveedor.Text = nEntidad.nombreCompleto

        '    txtTipoCambio.DecimalValue = ClipBoardDocumento.documentocompra.tcDolLoc
        '    txtIva.DoubleValue = ClipBoardDocumento.documentocompra.tasaIgv
        '    txtGlosa.Text = ClipBoardDocumento.documentocompra.glosa


        '    'DETALLE DE LA COMPRA
        '    dgvCompra.Table.Records.DeleteAll()

        '    For Each i In ClipBoardDocumento.documentocompra.documentocompradetalle.ToList

        '        Me.dgvCompra.Table.AddNewRecord.SetCurrent()
        '        Me.dgvCompra.Table.AddNewRecord.BeginEdit()
        '        Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
        '        Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", i.destino)
        '        Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", i.idItem)
        '        Me.dgvCompra.Table.CurrentRecord.SetValue("item", i.descripcionItem)
        '        Me.dgvCompra.Table.CurrentRecord.SetValue("um", i.unidad1)
        '        Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", i.monto1)
        '        Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", i.montokardex)
        '        Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", i.importe)

        '        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", i.montokardexUS)
        '        Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", i.importeUS)
        '        Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", i.montoIgv)
        '        Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", i.montoIgvUS)
        '        Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", i.tipoExistencia)
        '        Me.dgvCompra.Table.CurrentRecord.SetValue("marca", Nothing)

        '        Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", i.precioUnitario)
        '        Me.dgvCompra.Table.CurrentRecord.SetValue("pume", i.precioUnitarioUS)
        '        Me.dgvCompra.Table.CurrentRecord.SetValue("presentacion", i.unidad2)
        '        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", i.percepcionMN)
        '        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", i.percepcionME)

        '        Select Case i.estadoPago
        '            Case TIPO_COMPRA.PAGO.PAGADO
        '                Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", True)
        '                Me.dgvCompra.Table.CurrentRecord.SetValue("valPago", "Pagado")
        '            Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
        '                Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", False)
        '                Me.dgvCompra.Table.CurrentRecord.SetValue("valPago", "No Pagado")
        '        End Select

        '        Select Case i.bonificacion
        '            Case "S"
        '                Me.dgvCompra.Table.CurrentRecord.SetValue("chBonif", True)
        '                Me.dgvCompra.Table.CurrentRecord.SetValue("valBonif", "S")
        '            Case "N"
        '                Me.dgvCompra.Table.CurrentRecord.SetValue("chBonif", False)
        '                Me.dgvCompra.Table.CurrentRecord.SetValue("valBonif", "N")
        '        End Select


        '        Select Case i.tipoExistencia
        '            Case "GS"

        '            Case "01"
        '                Me.dgvCompra.Table.CurrentRecord.SetValue("fecEntrega", i.fechaEntrega)
        '                Me.dgvCompra.Table.CurrentRecord.SetValue("tipo", "A")
        '            Case "08"
        '                Me.dgvCompra.Table.CurrentRecord.SetValue("tipo", "T")

        '        End Select



        '        Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", i.almacenRef)



        '        Me.dgvCompra.Table.AddNewRecord.EndEdit()
        '    Next
        '    TotalTalesXcolumna()
        'Catch ex As Exception
        '    MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        'End Try

    End Sub

    Private Sub InsertarOfertaEnCanasta(be As oferta)

        Dim colBI = CalculoBaseImponible(be.precioventa, 1.18)
        Dim iva = CalculoIva(colBI, 0.18)


        With dgvCompra.Table
            .AddNewRecord.SetCurrent()
            .AddNewRecord.BeginEdit()
            .CurrentRecord.SetValue("codigo", be.id)
            .CurrentRecord.SetValue("gravado", "1")
            .CurrentRecord.SetValue("idProducto", be.id)
            .CurrentRecord.SetValue("item", be.descripcion)
            .CurrentRecord.SetValue("um", be.codigo)
            .CurrentRecord.SetValue("cantidad", 1)
            .CurrentRecord.SetValue("canDisponible", 1)
            .CurrentRecord.SetValue("vcmn", Math.Round(CDec(colBI), 2))
            '.CurrentRecord.SetValue("totalmn", Math.Round(totalMN, 2))
            .CurrentRecord.SetValue("MontoSaldo", be.precioventa)

            .CurrentRecord.SetValue("vcme", 0)
            '.CurrentRecord.SetValue("totalme", Math.Round(totalME, 2))
            .CurrentRecord.SetValue("igvmn", Math.Round(CDec(iva), 2))
            .CurrentRecord.SetValue("igvme", 0)
            .CurrentRecord.SetValue("tipoExistencia", "OF")
            .CurrentRecord.SetValue("marca", Nothing) ') If(productoBE.CustomLote.productoSustentado = True, "Doc.", "Not.")) 'Susuentado y no sustentado

            .CurrentRecord.SetValue("pumn", be.precioventa)
            .CurrentRecord.SetValue("pume", 0)

            .CurrentRecord.SetValue("puKardex", be.precioventa)
            .CurrentRecord.SetValue("pukardeme", be.precioventa)

            .CurrentRecord.SetValue("chPago", False)
            .CurrentRecord.SetValue("valPago", "No Pagado")

            .CurrentRecord.SetValue("chBonif", False)
            .CurrentRecord.SetValue("valBonif", "N")
            '   If .tipoExistencia <> "GS" Then
            .CurrentRecord.SetValue("almacen", 0)
            .CurrentRecord.SetValue("presentacion", "-")

            .CurrentRecord.SetValue("percepcionMN", FormatNumber(0, 2))
            .CurrentRecord.SetValue("percepcionME", FormatNumber(0, 2))
            .CurrentRecord.SetValue("costoMN", 0)
            .CurrentRecord.SetValue("costoME", 0)
            .CurrentRecord.SetValue("tipoPrecio", 0)
            .CurrentRecord.SetValue("cboprecio", 0)
            .CurrentRecord.SetValue("cat", StatusCategoriaVenta.Productos)
            .CurrentRecord.SetValue("codigoLote", 0) ' productoBE.codigoLote)
            .CurrentRecord.SetValue("codBarra", be.codigo)
            .CurrentRecord.SetValue("empresa", be.idemprea)
            .CurrentRecord.SetValue("tipoventa", "V")
            .CurrentRecord.SetValue("cantidad2", 0)
            .AddNewRecord.EndEdit()
            .TableDirty = True
        End With
        TotalTalesXcolumna()
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellKeyDown(sender As Object, e As GridTableControlKeyEventArgs) Handles dgvCompra.TableControlCurrentCellKeyDown
        If e.Inner.KeyCode = Keys.Delete Then
            If Me.dgvCompra.Table.CurrentRecord IsNot Nothing Then
                Me.dgvCompra.Table.CurrentRecord.Delete()
                TotalTalesXcolumna()
            End If
            If dgvCompra.Table.Records.Count > 0 Then
                dgvCompra.Table.Records(dgvCompra.Table.Records.Count - 1).SetCurrent()
                dgvCompra.Table.Records(dgvCompra.Table.Records.Count - 1).BeginEdit()
            End If
            ConteoLabelVentas()
        ElseIf e.Inner.KeyCode = Keys.Up Or e.Inner.KeyCode = Keys.Down Then
            'If Me.dgvCompra.Table.CurrentRecord IsNot Nothing Then
            '    GetUbicarPrecio(Me.dgvCompra.Table.CurrentRecord)
            'End If

        End If
    End Sub

    Private Sub FormVentaGeneral_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub FormVentaGeneral_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If dgvCompra.Table.Records.Count > 0 Then
            If MessageBox.Show("¿Desea salir de la venta?", "Salir de la venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                ListaEstadosFinancieros.Clear()
                ListaAlmacenes.Clear()
                bgCombos.CancelAsync()
                bgVenta.CancelAsync()
                BackgroundWorker1.CancelAsync()
                If thread IsNot Nothing Then
                    thread.Abort()
                End If
                With FormCanastaTotalesServVer2
                    .GridTotales.Table.Records.DeleteAll()
                    .txtFiltrar.Clear()
                End With
            Else
                e.Cancel = True
            End If
        Else
            ListaEstadosFinancieros.Clear()
            ListaAlmacenes.Clear()
            bgCombos.CancelAsync()
            'bgCombos.Dispose()
            'bgCombos = Nothing

            bgVenta.CancelAsync()
            'bgVenta.Dispose()
            'bgVenta = Nothing

            BackgroundWorker1.CancelAsync()
            'BackgroundWorker1.Dispose()
            'BackgroundWorker1 = Nothing
            If thread IsNot Nothing Then
                thread.Abort()
            End If
            With FormCanastaTotalesServVer2
                .GridTotales.Table.Records.DeleteAll()
                .txtFiltrar.Clear()
            End With
        End If
    End Sub

    Private Sub dgvCompra_SelectedRecordsChanged(sender As Object, e As SelectedRecordsChangedEventArgs) Handles dgvCompra.SelectedRecordsChanged
        Try
            If e.SelectedRecord IsNot Nothing Then
                GetUbicarPrecio(e.SelectedRecord.Record)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellChanging(sender As Object, e As GridTableControlCancelEventArgs) Handles dgvCompra.TableControlCurrentCellChanging

    End Sub

    Private Sub dgvCompra_TableControlKeyDown(sender As Object, e As GridTableControlKeyEventArgs) Handles dgvCompra.TableControlKeyDown
        Try
            Dim cc As GridCurrentCell = dgvCompra.TableControl.CurrentCell
            If cc.RowIndex > -1 Then
                If e.Inner.KeyCode = Keys.Up Then
                    If cc IsNot Nothing Then
                        cc.ConfirmChanges()
                        If cc.RowIndex = 2 Then
                            Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(cc.RowIndex, cc.ColIndex), GridTableCellStyleInfo)
                            Dim currenrecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
                            GetUbicarPrecio(currenrecord)
                        Else
                            Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(cc.RowIndex - 1, cc.ColIndex), GridTableCellStyleInfo)
                            Dim currenrecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
                            GetUbicarPrecio(currenrecord)
                        End If

                    End If
                ElseIf e.Inner.KeyCode = Keys.Down Then
                    If cc IsNot Nothing Then
                        cc.ConfirmChanges()
                        Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(cc.RowIndex + 1, cc.ColIndex), GridTableCellStyleInfo)
                        If style IsNot Nothing Then
                            ' Dim rows = dgvCompra.Table.Records.Count
                            If style.TableCellIdentity IsNot Nothing Then
                                Dim currenrecord = style.TableCellIdentity.DisplayElement.GetRecord()
                                If currenrecord IsNot Nothing Then
                                    GetUbicarPrecio(currenrecord)
                                End If
                            End If

                        End If

                    End If

                Else
                    cc.ConfirmChanges()
                    Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(cc.RowIndex, cc.ColIndex), GridTableCellStyleInfo)
                    Dim currenrecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
                    GetUbicarPrecio(currenrecord)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub FormVentaGeneral_Shown(sender As Object, e As EventArgs) Handles Me.Shown

    End Sub

#End Region

End Class