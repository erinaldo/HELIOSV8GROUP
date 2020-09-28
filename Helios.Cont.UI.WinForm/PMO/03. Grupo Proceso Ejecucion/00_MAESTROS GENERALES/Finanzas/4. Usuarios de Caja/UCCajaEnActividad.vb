Imports System.ComponentModel
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity

Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Public Class UCCajaEnActividad

#Region "Contructor"

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        'FormatoGridBlack2(DgvOpenBox, False)
        'ListBoxOpen()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

#End Region

#Region "Metodos"

    'Public Sub FormatoGridBlack2(dgPedidos As GridGroupingControl, FilaSel As Boolean)
    '    dgPedidos.Appearance.ColumnHeaderCell.Interior = New BrushInfo(GradientStyle.Vertical, Color.Black, Color.Black)
    '    dgPedidos.TopLevelGroupOptions.ShowCaption = False
    '    Dim colorF As GridMetroColors = New GridMetroColors()
    '    colorF.HeaderColor.NormalColor = Color.Black
    '    colorF.HeaderColor.HoverColor = Color.Empty
    '    dgPedidos.SetMetroStyle(colorF)
    '    dgPedidos.AllowProportionalColumnSizing = False
    '    dgPedidos.DisplayVerticalLines = False
    '    '   dgPedidos.BrowseOnly = True
    '    If FilaSel = True Then
    '        dgPedidos.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
    '        dgPedidos.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
    '        dgPedidos.TableOptions.ListBoxSelectionMode = SelectionMode.One
    '        dgPedidos.TableOptions.SelectionBackColor = Color.FromArgb(85, 170, 255)
    '    Else

    '    End If
    '    dgPedidos.TableOptions.ShowRowHeader = False
    '    dgPedidos.TableDescriptor.Appearance.AlternateRecordFieldCell.Interior = New Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(30, 30, 30))
    '    Dim captionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
    '    dgPedidos.Table.DefaultRecordRowHeight = 30
    '    dgPedidos.Table.DefaultColumnHeaderRowHeight = 35
    '    dgPedidos.Appearance.AnyCell.TextColor = Color.White
    '    dgPedidos.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
    '    dgPedidos.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
    '    dgPedidos.TableDescriptor.Appearance.AnyCell.Borders.Bottom = New GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, Color.FromArgb(25, 25, 25))
    '    dgPedidos.TableDescriptor.Appearance.AnyCell.Borders.Right = New GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, Color.FromArgb(25, 25, 25))
    '    dgPedidos.TableDescriptor.Appearance.AnyHeaderCell.Borders.Top = New GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, Color.FromArgb(25, 25, 25))
    '    dgPedidos.GridOfficeScrollBars = OfficeScrollBars.Metro
    '    dgPedidos.TableControl.MetroColorTable.ScrollerBackground = Color.FromArgb(45, 45, 45)
    '    dgPedidos.TableControl.MetroColorTable.ArrowNormal = Color.FromArgb(195, 195, 195)
    '    dgPedidos.TableControl.MetroColorTable.ArrowChecked = Color.FromArgb(94, 171, 222)
    '    dgPedidos.TableControl.MetroColorTable.ThumbNormal = Color.FromArgb(31, 31, 31)
    '    dgPedidos.TableControl.MetroColorTable.ThumbPushed = Color.FromArgb(94, 171, 222)
    '    dgPedidos.TableControl.HScrollBehavior = Syncfusion.Windows.Forms.Grid.GridScrollbarMode.Disabled
    'End Sub

    Public Sub ListBoxOpen()

        Dim be As New cajaUsuario
        be.idEmpresa = Gempresas.IdEmpresaRuc
        be.idEstablecimiento = GEstableciento.IdEstablecimiento

        Dim dt As New DataTable("Usuario")
        Dim boxUserSA As New cajaUsuarioSA

        dt.Columns.Add(New DataColumn("idUser", GetType(Integer)))
        dt.Columns.Add(New DataColumn("User", GetType(String)))
        dt.Columns.Add(New DataColumn("idBox", GetType(String)))
        dt.Columns.Add(New DataColumn("namePc", GetType(String)))
        dt.Columns.Add(New DataColumn("date", GetType(String)))
        dt.Columns.Add(New DataColumn("importe", GetType(String)))
        dt.Columns.Add(New DataColumn("importeme", GetType(String)))


        Dim ListOpenBox = boxUserSA.ListBoxOpen(New cajaUsuario With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento})

        For Each i In ListOpenBox
            Dim dr As DataRow = dt.NewRow()
            dr(0) = i.idPersona
            dr(1) = (From j In UsuariosList Where j.IDUsuario = i.idPersona Select j.Nombres).FirstOrDefault
            dr(2) = i.idcajaUsuario
            dr(3) = i.namepc
            dr(4) = i.fechaRegistro
            dr(5) = i.montoMN
            dr(6) = i.montoME
            dt.Rows.Add(dr)
        Next

        DgvOpenBox.DataSource = dt

    End Sub

    Private Sub ButtonAdv8_Click(sender As Object, e As EventArgs) Handles ButtonAdv8.Click
        ListBoxOpen()
    End Sub

#End Region





End Class
