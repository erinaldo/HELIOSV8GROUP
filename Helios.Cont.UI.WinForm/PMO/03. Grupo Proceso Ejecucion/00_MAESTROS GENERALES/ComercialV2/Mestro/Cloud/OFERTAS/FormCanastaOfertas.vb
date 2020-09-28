Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class FormCanastaOfertas

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(GridOferta, True, False)
        GetOfertas()
    End Sub

    Private Sub GetOfertas()
        Dim OfertaSA As New OfertaSA
        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("codigo")
        dt.Columns.Add("detalle")
        dt.Columns.Add("precio")

        For Each i In OfertaSA.OfertaSelAll(New oferta With {.idemprea = Gempresas.IdEmpresaRuc})
            dt.Rows.Add(i.id, i.codigo, i.nombreCorto, i.precioventa.GetValueOrDefault)
        Next
        GridOferta.DataSource = dt

    End Sub

    Private Sub FormCanastaOfertas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub GridOferta_TableControlCellClick(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs) Handles GridOferta.TableControlCellClick

    End Sub

    Private Sub GridOferta_TableControlCellDoubleClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridOferta.TableControlCellDoubleClick
        Dim ofertaSA As New OfertaSA
        Dim codigoOferta = GridOferta.Table.CurrentRecord.GetValue("id")

        Dim ofertaSEl = ofertaSA.OfertaSel(New oferta With {.id = codigoOferta})

        Dim miInterfaz As IOferta = TryCast(Me.Owner, IOferta)
        If miInterfaz IsNot Nothing Then miInterfaz.RecuperarOferta(ofertaSEl)
        Close()
    End Sub
End Class