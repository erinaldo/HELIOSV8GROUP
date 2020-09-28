Imports System.ComponentModel
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.Presentation.WinForm
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports System.IO
Imports OpenInvoicePeru.Comun.Dto.Intercambio
Imports OpenInvoicePeru.Comun.Dto.Modelos

Public Class frmMasterFacturacionPSE


#Region "Variables Globales"

    Dim documentoventaSA As New documentoVentaAbarrotesSA
    Dim documentoventa As New documentoventaAbarrotes

#End Region

#Region "Constructor"

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        'GetTableGrid()
        'FormatoGridAvanzado(dgvAlertas, False, False)
        ' Add any initialization after the InitializeComponent() call.

    End Sub

#End Region

#Region "Metodos2"



    Public Sub AlertasBoletas()
        lblboletaspendientes.Text = documentoventaSA.BoletasPendientesEnvio(documentoventa)
        LBLBOLETASELIMINADAS.Text = documentoventaSA.BoletasBaja(documentoventa)
    End Sub


    Public Sub AlertasPSE()
        Dim documentosa As New documentoVentaAbarrotesSA

        Dim consulta = documentosa.AlertaPSE(Gempresas.IdEmpresaRuc)

        lblFacturasPendientes.Text = consulta.CantFact
        lblNotasPendiente.Text = consulta.CantNotaFact
        lblFacturasAnuladas.Text = consulta.CantFactAnu

        lblboletaspendientes.Text = consulta.CantBol
        lblnotaboletas.Text = consulta.CantNotaBol
        LBLBOLETASELIMINADAS.Text = consulta.CantBolAnu

    End Sub



    Public Sub AlertasFacturacionElectronica()

        lblFacturasPendientes.Text = documentoventaSA.FacturasPendientesSunat(documentoventa)
        lblNotasPendiente.Text = documentoventaSA.NotasPendientesSunat(documentoventa)
        lblFacturasAnuladas.Text = documentoventaSA.FacturaBajasPendiente(documentoventa)

        'lblboletaspendientes.Text = documentoventaSA.BoletasPendientesEnvio()
        'LBLBOLETASELIMINADAS.Text = documentoventaSA.BoletasBaja()



        'lblResumenpendiente.Text = documentoventaSA.ResumenBoletasPendiente()
        'lblvalidarbajas.Text = documentoventaSA.FacturasBajasValidar()
        'LBLRESUMENBAJAVALIDAR.Text = documentoventaSA.BoletasBajaValidar()

    End Sub



#End Region

#Region "Metodos"

    'Public Sub CargarAlertas()
    '    Dim documentoSA As New documentoVentaAbarrotesSA

    '    Try
    '        Dim ListaAlertas = documentoSA.AlertasDocumentosElectronicos(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, DateTime.Now)

    '        Dim facturas = (From i In ListaAlertas
    '                        Where i.serieVenta.StartsWith("F")
    '                        Order By i.fechaDoc, i.tipoDocumento, i.estadoCobro).ToList

    '        Dim boletas = (From i In ListaAlertas
    '                       Where i.serieVenta.StartsWith("B")
    '                       Group i By i.fechaDoc, i.tipoDocumento, i.estadoCobro
    '                           Into g = Group
    '                       Order By fechaDoc
    '                       Select New With {g, .Cant_bol = g.Count(Function(i) i.idDocumento),
    '                                        .fecha = fechaDoc,
    '                                        .tipodoc = tipoDocumento,
    '                                         .cobro = estadoCobro}).ToList

    '        If ListaAlertas.Count = 0 Then

    '            MessageBox.Show("Esta al Dia en sus Envios")
    '        Else

    '            For Each i In facturas
    '                Me.dgvAlertas.Table.AddNewRecord.SetCurrent()
    '                Me.dgvAlertas.Table.AddNewRecord.BeginEdit()
    '                Me.dgvAlertas.Table.CurrentRecord.SetValue("idDocumento", i.idDocumento)
    '                Me.dgvAlertas.Table.CurrentRecord.SetValue("serie", i.serieVenta)
    '                Me.dgvAlertas.Table.CurrentRecord.SetValue("numero", i.numeroVenta)
    '                Me.dgvAlertas.Table.CurrentRecord.SetValue("tipodoc", i.tipoDocumento)
    '                Me.dgvAlertas.Table.CurrentRecord.SetValue("importe", i.ImporteNacional)
    '                Me.dgvAlertas.Table.CurrentRecord.SetValue("fecha", i.fechaDoc)
    '                Me.dgvAlertas.Table.AddNewRecord.EndEdit()
    '            Next

    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show("No se Pudo Actualizar")
    '    End Try




    'End Sub



    'Sub FormatoGridAvanzado(GGC As GridGroupingControl, FullRowSelect As Boolean, AllowProportionalColumnSizing As Boolean)
    '    Dim colorx As New GridMetroColors()
    '    GGC.TableOptions.ShowRowHeader = False
    '    GGC.TopLevelGroupOptions.ShowCaption = False
    '    GGC.ShowColumnHeaders = True

    '    colorx = New GridMetroColors()
    '    colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
    '    colorx.HeaderTextColor.HoverTextColor = Color.Gray
    '    colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
    '    GGC.SetMetroStyle(colorx)
    '    GGC.BorderStyle = BorderStyle.None
    '    '  GGC.BrowseOnly = True
    '    If FullRowSelect = True Then
    '        GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
    '        GGC.TableOptions.ListBoxSelectionCurrentCellOptions = GridListBoxSelectionCurrentCellOptions.HideCurrentCell
    '        GGC.TableOptions.ListBoxSelectionMode = SelectionMode.One
    '        GGC.TableOptions.SelectionBackColor = Color.Gray
    '    End If
    '    GGC.AllowProportionalColumnSizing = AllowProportionalColumnSizing
    '    GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
    '    GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
    '    GGC.Table.DefaultColumnHeaderRowHeight = 27
    '    GGC.Table.DefaultRecordRowHeight = 20
    '    GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    'End Sub

    'Sub GetTableGrid()
    '    Dim dt As New DataTable()

    '    dt.Columns.Add("idDocumento")
    '    dt.Columns.Add("serie")
    '    dt.Columns.Add("numero")
    '    dt.Columns.Add("tipodoc")
    '    dt.Columns.Add("importe")
    '    dt.Columns.Add("fecha")

    '    dgvAlertas.DataSource = dt
    'End Sub

#End Region

    Private Sub frmMasterFacturacionPSE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        documentoventa.idEmpresa = Gempresas.IdEmpresaRuc
        AlertasPSE()

        'AlertasFacturacionElectronica()
        'CargarAlertas()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Dim f As New frmFacturaElectronicaPSE  'frmVentaNuevoPOS

        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog(Me)
    End Sub

    'Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs)
    '    If TabControl1.SelectedIndex = 0 Then
    '        lblFacturasPendientes.Text = documentoventaSA.FacturasPendientesSunat(documentoventa)
    '        lblNotasPendiente.Text = documentoventaSA.NotasPendientesSunat(documentoventa)


    '    ElseIf TabControl1.SelectedIndex = 1 Then

    '        lblboletaspendientes.Text = documentoventaSA.BoletasPendientesEnvio(documentoventa)
    '        LBLBOLETASELIMINADAS.Text = documentoventaSA.BoletasBaja(documentoventa)



    '    End If
    'End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim f As New frmFacturaElectronicaPSE   'frmVentaNuevoPOS

        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog(Me)

        'AlertasFacturacionElectronica()
        AlertasPSE()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim f As New frmBoletasElectronicasPSE   'frmVentaNuevoPOS

        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog(Me)
        'AlertasBoletas()
        'AlertasFacturacionElectronica()

        AlertasPSE()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim f As New frmComunicacionBajaPSE    'frmVentaNuevoPOS

        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog(Me)

        'AlertasFacturacionElectronica()
        AlertasPSE()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        Dim f As New frmFacturaElectronicaPSE   'frmVentaNuevoPOS
        f.ComboBox1.Text = "NOTAS DE CREDITO BOLETAS"
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog(Me)

        'AlertasFacturacionElectronica()
        AlertasPSE()


        'Dim f As New frmBoletasElectronicasPSE   'frmVentaNuevoPOS
        'f.ComboBox1.Text = "NOTAS DE CREDITO"
        'f.StartPosition = FormStartPosition.CenterScreen
        'f.ShowDialog(Me)
        ''AlertasBoletas()

        'AlertasPSE()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim f As New frmBoletasElectronicasPSE   'frmVentaNuevoPOS
        f.ComboBox1.Text = "ANULADOS"
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog(Me)
        'AlertasBoletas()

        AlertasPSE()
    End Sub












    Private Sub Panel22_Paint(sender As Object, e As PaintEventArgs) Handles Panel22.Paint

    End Sub

    Private Sub Panel22_Click(sender As Object, e As EventArgs) Handles Panel22.Click
        Dim f As New frmFacturasAlertas    'frmVentaNuevoPOS
        f.StartPosition = FormStartPosition.CenterScreen
        f.txtTipoDoc.Text = "01"
        f.ShowDialog(Me)
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Panel1_Click(sender As Object, e As EventArgs) Handles Panel1.Click
        Dim f As New frmFacturasAlertas    'frmVentaNuevoPOS
        f.StartPosition = FormStartPosition.CenterScreen
        f.txtTipoDoc.Text = "07"
        f.ShowDialog(Me)
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Panel2_Click(sender As Object, e As EventArgs) Handles Panel2.Click
        Dim f As New frmBoletasAlertas    'frmVentaNuevoPOS
        f.StartPosition = FormStartPosition.CenterScreen
        f.txtTipoDoc.Text = "ANU"
        f.ShowDialog(Me)
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub Panel3_Click(sender As Object, e As EventArgs) Handles Panel3.Click
        Dim f As New frmBoletasAlertas    'frmVentaNuevoPOS
        f.StartPosition = FormStartPosition.CenterScreen
        f.txtTipoDoc.Text = "03"
        f.ShowDialog(Me)
    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint

    End Sub

    Private Sub Panel4_Click(sender As Object, e As EventArgs) Handles Panel4.Click
        Dim f As New frmBoletasAlertas    'frmVentaNuevoPOS
        f.StartPosition = FormStartPosition.CenterScreen
        f.txtTipoDoc.Text = "07"
        f.ShowDialog(Me)
    End Sub

    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs) Handles Panel5.Paint

    End Sub

    Private Sub Panel5_Click(sender As Object, e As EventArgs) Handles Panel5.Click
        Dim f As New frmBoletasAlertas    'frmVentaNuevoPOS
        f.StartPosition = FormStartPosition.CenterScreen
        f.txtTipoDoc.Text = "ANUBOL"
        f.ShowDialog(Me)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim f As New frmFacturaElectronicaPSE   'frmVentaNuevoPOS
        f.ComboBox1.Text = "NOTAS DE CREDITO"
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog(Me)

        AlertasPSE()
    End Sub
End Class