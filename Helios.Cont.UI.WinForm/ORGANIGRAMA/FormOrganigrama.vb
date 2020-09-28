Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports PopupControl
Imports ProcesosGeneralesCajamiSoft
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Syncfusion.Windows.Forms
Imports System.Text.RegularExpressions
Imports Syncfusion.Windows.Forms.Tools

Public Class FormOrganigrama

#Region "ATRIBUTOS"
    Private Property UCARBOL As UCARBOL
    Private Property UCUnidOrganica_Jerarq As UCUnidOrganica_Jerarq
    Private Property UCOrganica_Especifica As UCOrganica_Especifica

#End Region

#Region "CONSTRUCTOR"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        UCARBOL = New UCARBOL With {.Dock = DockStyle.Fill}

        UCOrganica_Especifica = New UCOrganica_Especifica With {.Dock = DockStyle.Fill}

        UCUnidOrganica_Jerarq = New UCUnidOrganica_Jerarq With {.Dock = DockStyle.Fill}
        Panel1.Controls.Add(UCUnidOrganica_Jerarq)
    End Sub
#End Region

#Region "METODOS"


#End Region

    Private Sub BunifuFlatButton5_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton9.Click, BunifuFlatButton8.Click, BunifuFlatButton7.Click

        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width

        Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)

        Select Case btn.Text
            Case "UNI. ORGANICA"

                UCARBOL.Visible = False
                UCOrganica_Especifica.Visible = False
                UCUnidOrganica_Jerarq.Visible = True



            Case "UNI. ORG. ESPEC"
                UCARBOL.Visible = False
                UCUnidOrganica_Jerarq.Visible = False
                UCOrganica_Especifica.Visible = True
                Panel1.Controls.Add(UCOrganica_Especifica)

            Case "MOSTRAR ARBOL"
                UCUnidOrganica_Jerarq.Visible = False
                UCOrganica_Especifica.Visible = False
                UCARBOL.Visible = True
                Panel1.Controls.Add(UCARBOL)


        End Select
    End Sub

End Class