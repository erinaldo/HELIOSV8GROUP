Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class FormAnticiposVigentesPersona

#Region "Attributes"
    Public Property anticipoSA As New documentoAnticipoSA
#End Region

#Region "Constructors"
    Public Sub New(ent As entidad)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        TextPersona.Text = ent.nombreCompleto
        TextPersona.Tag = ent.idEntidad
        TextRuc.Text = ent.nrodoc
        FormatoGridAvanzado(GridBeneficios, True, False, 10.0F)
        GetSaldoAnticiposPersona(ent)
    End Sub
#End Region

#Region "Methods"
    Sub GetSaldoAnticiposPersona(ent As entidad)
        Dim dt As New DataTable
        dt.Columns.Add("iddocumeto")
        dt.Columns.Add("codigo")
        dt.Columns.Add("fecha")
        dt.Columns.Add("tipo")
        dt.Columns.Add("importe")
        dt.Columns.Add("usado")
        dt.Columns.Add("saldo")


        For Each i In anticipoSA.ObtenerSaldoAnticipoPersona(New documentoAnticipo With
                                                             {
                                                             .idEmpresa = Gempresas.IdEmpresaRuc,
                                                             .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                             .tipoAnticipo = "AR",
                                                             .razonSocial = ent.idEntidad
                                                             })

            dt.Rows.Add(i.idDocumento, i.numeroDoc, i.fechaDoc, i.formaPago, i.importeMN, i.MontoPagadoSoles, i.Saldo.GetValueOrDefault)
        Next
        GridBeneficios.DataSource = dt
    End Sub

    Private Sub GridBeneficios_TableControlCellClick(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs) Handles GridBeneficios.TableControlCellClick

    End Sub

    Private Sub GridBeneficios_TableControlCellDoubleClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridBeneficios.TableControlCellDoubleClick
        Dim r As Record = GridBeneficios.Table.CurrentRecord

        If r IsNot Nothing Then
            Dim codVenta = Integer.Parse(r.GetValue("iddocumeto"))
            Tag = codVenta
            Close()
        End If

    End Sub
#End Region

#Region "Events"

#End Region

End Class