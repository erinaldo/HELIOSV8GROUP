Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General.Constantes
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.GridHelperClasses

Public Class frmDocsPercepcion

#Region "Atributos"
    Dim listaMeses As New List(Of MesesAnio)
    Public Property empresaPeriodoSA As New empresaCierreMensualSA
    Public Property empresaAnioSA As New empresaPeriodoSA
#End Region

#Region "Constructor"

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        FormatoGrid(dgvCompras)
        Meses()
        ' Add any initialization after the InitializeComponent() call.

    End Sub
#End Region

#Region "Metodos"


    Private Sub ListadoPercepciones(intIdEstablecimiento As Integer, strPeriodo As String)
        Dim DocumentoCompraSA As New DocumentoCompraSA
        Dim DocumentoCompra As New List(Of documentocompra)

        Dim dt As New DataTable("Período: " & strPeriodo & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))

        dt.Columns.Add(New DataColumn("tipoDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("TipoPersona ", GetType(String)))

        dt.Columns.Add(New DataColumn("importeTotal"))
        dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeUS"))

        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("usuarioActualizacion", GetType(String)))
        dt.Columns.Add(New DataColumn("situacion", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("Aprobado", GetType(String)))
        dt.Columns.Add(New DataColumn("ant", GetType(Integer)))
        dt.Columns.Add("detraccion")

        '  If usuario.TieneCaja Then
        DocumentoCompra = DocumentoCompraSA.GetListarPercepciones(intIdEstablecimiento, strPeriodo)
        'Else
        '    DocumentoCompra = DocumentoCompraSA.GetListarComprasPorPeriodoGeneral_CONT_CONTADO(intIdEstablecimiento, strPeriodo)
        'End If

        Dim str As String
        For Each i As documentocompra In DocumentoCompra
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM HH:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoCompra
            dr(2) = str
            dr(3) = i.tipoDoc
            dr(4) = i.serie
            dr(5) = i.numeroDoc
            dr(6) = i.tipoDocEntidad
            dr(7) = i.NroDocEntidad
            dr(8) = i.NombreEntidad
            dr(9) = i.TipoPersona

            If i.tipoCompra = "BOFR" Then
                dr(10) = CDec(0.0)
                dr(11) = CDec(0.0)
                dr(12) = CDec(0.0)
            Else
                dr(10) = CDec(i.importeTotal).ToString("N2")
                dr(11) = i.tcDolLoc
                dr(12) = i.importeUS
            End If


            'dr(11) = i.tcDolLoc
            'dr(12) = i.importeUS
            dr(13) = i.monedaDoc
            dr(14) = i.usuarioActualizacion
            dr(15) = i.situacion
            Select Case i.estadoPago
                Case TIPO_COMPRA.PAGO.PAGADO
                    dr(16) = "Saldado"
                Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                    dr(16) = "Pendiente"
            End Select

            Select Case i.aprobado
                Case "S"
                    dr(17) = "Aprobado"
                Case Else
                    dr(17) = "Pendiente"
            End Select
            dr(18) = i.Atraso
            dr(19) = If(i.tieneDetraccion = "S", "Si", "No")
            dt.Rows.Add(dr)
        Next
        dgvCompras.DataSource = dt
    End Sub



    Private Sub Meses()

        listaMeses = New List(Of MesesAnio)
        Dim obj As New MesesAnio
        For x = 1 To 12
            obj = New MesesAnio
            obj.Codigo = String.Format("{0:00}", CInt(x))
            obj.Mes = New DateTime(AnioGeneral, x, 1).ToString("MMMM")
            listaMeses.Add(obj)
        Next x

        cboMesCompra.DisplayMember = "Mes"
        cboMesCompra.ValueMember = "Codigo"
        cboMesCompra.DataSource = listaMeses
        cboMesCompra.SelectedValue = MesGeneral

        cboAnio.DisplayMember = "periodo"
        cboAnio.ValueMember = "periodo"
        cboAnio.DataSource = empresaAnioSA.GetListar_empresaPeriodo(New empresaPeriodo With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento})
        cboAnio.Text = AnioGeneral
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
        GGC.ShowCurrentCellBorderBehavior = Grid.GridShowCurrentCellBorder.HideAlways
        GGC.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        GGC.TableOptions.ListBoxSelectionMode = SelectionMode.One
        GGC.TableOptions.SelectionBackColor = Color.Gray
        GGC.AllowProportionalColumnSizing = False
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = Grid.GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = Grid.GridHorizontalAlignment.Center
        GGC.Table.DefaultColumnHeaderRowHeight = 45
        GGC.Table.DefaultRecordRowHeight = 40
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub
#End Region

    Private Sub frmDocsPercepcion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonAdv6_Click(sender As Object, e As EventArgs) Handles ButtonAdv6.Click
        Dim periodo = String.Format("{0:00}", cboMesCompra.SelectedValue)
        periodo = periodo & "/" & cboAnio.Text
      
        ListadoPercepciones(GEstableciento.IdEstablecimiento, periodo)

    End Sub
End Class