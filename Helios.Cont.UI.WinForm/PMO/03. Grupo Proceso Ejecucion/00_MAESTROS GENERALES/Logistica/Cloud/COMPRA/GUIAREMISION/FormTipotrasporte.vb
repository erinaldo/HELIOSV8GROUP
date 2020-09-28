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
Public Class FormTipotrasporte
#Region "ATRIBUTOS"
    Public Property UCTrasportePrivado As UCTrasportePrivado
    Public Property UCTrasportePublico As UCTrasportePublico
    Public MOSTRARFOR As Integer
#End Region

#Region "CONSTRTUCTOR"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        'UCTrasportePublico = New UCTrasportePublico()
        'UCTrasportePublico.Dock = DockStyle.Fill

    End Sub
#End Region

    Private Sub FormTipotrasporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TIPOTRASPORTE()
    End Sub



    Public Sub TIPOTRASPORTE()
        Dim listaTras As New List(Of TipoTrasporte)
        Dim obj As New TipoTrasporte

        obj = New TipoTrasporte
        obj.Codigo = "0"
        obj.Valor = " "
        listaTras.Add(obj)

        obj = New TipoTrasporte
        obj.Codigo = "1"
        obj.Valor = "PÚBLICO"
        listaTras.Add(obj)

        obj = New TipoTrasporte
        obj.Codigo = "2"
        obj.Valor = "PRIVADO"
        listaTras.Add(obj)

        cbTipotras.DataSource = listaTras
        cbTipotras.ValueMember = "Codigo"
        cbTipotras.DisplayMember = "Valor"
    End Sub

    Private Sub cbTipotras_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cbTipotras.SelectionChangeCommitted
        Select Case cbTipotras.Text
            Case "PÚBLICO"

                Dim Dist As New OTROSTIPODOCUMENTO With {
                .Codigo = 1
                      }
                Tag = Dist
                Me.Close()

            Case "PRIVADO"
                Dim Dist As New OTROSTIPODOCUMENTO With {
                .Codigo = 2
                      }
                Tag = Dist
                Me.Tag = Dist
                Me.Close()
        End Select
    End Sub


End Class