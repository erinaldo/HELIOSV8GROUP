Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Text.RegularExpressions
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports HtmlAgilityPack
Imports PopupControl
Imports ProcesosGeneralesCajamiSoft
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Imports System.Xml
Imports Syncfusion.Drawing
Public Class FormFiltroComprobante

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'GetMeses()
    End Sub
#End Region

#Region "methods"
    'Sub GetMeses()
    '    cboMesCompra.DisplayMember = "Mes"
    '    cboMesCompra.ValueMember = "Codigo"
    '    cboMesCompra.DataSource = General.ListaDeMeses
    '    cboMesCompra.SelectedValue = String.Format("{0:00}", DateTime.Now.Month)

    '    TExtAnio.DecimalValue = DateTime.Now.Year
    'End Sub
#End Region

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub RoundButton21_Click(sender As Object, e As EventArgs) Handles RoundButton21.Click
        'Dim periodo As New Date(TExtAnio.DecimalValue, CInt(cboMesCompra.SelectedValue), 1)
        'Tag = periodo
        'Close()
        Try


            Dim datos As List(Of item) = item.Instance()
            datos.Clear()
            Dim c As New item


            Select Case cboTipoComprobante.Text
                Case "FACTURA"
                    Tag = "01"
                    c.tipoDocumento = "01"
                Case "BOLETA"
                    Tag = "03"
                    c.tipoDocumento = "03"
                Case "NOTAS DE CREDITO"
                    Tag = "07"
                    c.tipoDocumento = "07"
                Case "NOTAS DE DEBITO"
                    Tag = "08"
                    c.tipoDocumento = "08"
                Case "NOTAS"
                    Tag = "9907"
                    c.tipoDocumento = "9907"

            End Select



            c.serie = txtSerie.Text
            c.numero = txtNumero.Text

            datos.Add(c)

            Close()


        Catch ex As Exception

        End Try

    End Sub
End Class