Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Text.RegularExpressions
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports PopupControl
Imports ProcesosGeneralesCajamiSoft
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports HtmlAgilityPack
Public Class UCGuiaDestinatario

#Region "ATRIBUTOS"
    Private Property SelRazon As entidad
    Private Property entidadSA As New entidadSA
    Dim tipotroDocD As Integer
#End Region

#Region "CONSTRUCTOR"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
#End Region
    Private Sub cbTipoDocdes_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub
#Region "BUSCA DNI Y RUC"

    Private Sub BgProveedor_DoWork(sender As Object, e As DoWorkEventArgs) Handles BgProveedor.DoWork

    End Sub


#End Region



    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton3.Click
        Dim L As New FormUbigeo
        L.StartPosition = FormStartPosition.CenterScreen
        L.ShowDialog()


        If Not IsNothing(L.Tag) Then


            Dim c = CType(L.Tag, distritos)

            txtUbigDestino.Text = c.name
            txtUbigDestino.Tag = c.id
        End If
    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click
        Dim U As New FormUbigeo
        U.StartPosition = FormStartPosition.CenterScreen
        U.ShowDialog()



        If Not IsNothing(U.Tag) Then
            Dim c = CType(U.Tag, distritos)

            txtUbiRemit.Text = c.name
            txtUbiRemit.Tag = c.id

        End If
    End Sub
End Class
