Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid.Grouping
Public Class FormAntReclamacionesPendientes
#Region "Attributes"
    Public Property anticipoSA As New documentoAnticipoSA
    Public Property moduloP As String
#End Region

#Region "Constructors"
    Public Sub New(ent As entidad, modulo As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        TextPersona.Text = ent.nombreCompleto
        TextPersona.Tag = ent.idEntidad
        TextRuc.Text = ent.nrodoc
        FormatoGridAvanzado(GridPersona, True, False, 10.0F)
        GetSaldoAnticiposPersona(ent)

        moduloP = modulo

        If moduloP = "VENTAS" Then
            GetSaldoAnticiposPersona(ent)
        ElseIf moduloP = "COMPRAS" Then
            GetSaldoAnticiposProveedor(ent)
        End If

    End Sub
#End Region

#Region "Methods"

    Sub GetSaldoAnticiposProveedor(ent As entidad)
        Dim dt As New DataTable
        dt.Columns.Add("iddocumeto")
        dt.Columns.Add("fecha")
        dt.Columns.Add("tipo")
        dt.Columns.Add("importe")
        dt.Columns.Add("usado")
        dt.Columns.Add("saldo")


        For Each i In anticipoSA.GetAntReclamacionesProveedor(New documentocompra With
                                                             {
                                                             .idEmpresa = Gempresas.IdEmpresaRuc,
                                                             .idCentroCosto = GEstableciento.IdEstablecimiento,
                                                             .tipoCompra = "VNCA",
                                                             .estado = "PN",
                                                             .idProveedor = ent.idEntidad
                                                             })

            dt.Rows.Add(i.idDocumento, i.fechaDoc, i.numeroDoc, i.importeMN, i.TotalNotas, i.SaldoReclamacion.GetValueOrDefault)
        Next
        GridPersona.DataSource = dt
    End Sub


    Sub GetAntReclamacionesProveedor(ent As entidad)
        Dim dt As New DataTable
        dt.Columns.Add("iddocumeto")
        dt.Columns.Add("fecha")
        dt.Columns.Add("tipo")
        dt.Columns.Add("importe")
        dt.Columns.Add("usado")
        dt.Columns.Add("saldo")


        For Each i In anticipoSA.GetAntReclamacionesProveedor(New documentocompra With
                                                             {
                                                             .idEmpresa = Gempresas.IdEmpresaRuc,
                                                             .idCentroCosto = GEstableciento.IdEstablecimiento,
                                                             .tipoCompra = "VRC",
                                                             .estado = "PN",
                                                             .idProveedor = ent.idEntidad
                                                             })

            dt.Rows.Add(i.idDocumento, i.fechaDoc, i.numeroDoc, i.importeMN, i.TotalNotas, i.SaldoReclamacion.GetValueOrDefault)
        Next
        GridPersona.DataSource = dt
    End Sub

    Sub GetSaldoReclamacionPersona(ent As entidad)
        Dim dt As New DataTable
        dt.Columns.Add("iddocumeto")
        dt.Columns.Add("fecha")
        dt.Columns.Add("tipo")
        dt.Columns.Add("importe")
        dt.Columns.Add("usado")
        dt.Columns.Add("saldo")


        For Each i In anticipoSA.GetANTReclamacionesPersona(New documentoventaAbarrotes With
                                                             {
                                                             .idEmpresa = Gempresas.IdEmpresaRuc,
                                                             .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                             .tipoVenta = "VRC",
                                                             .estado = "PN",
                                                             .idCliente = ent.idEntidad
                                                             })

            dt.Rows.Add(i.idDocumento, i.fechaDoc, i.numeroDoc, i.importeMN, i.TotalNotas, i.SaldoReclamacion.GetValueOrDefault)
        Next
        GridPersona.DataSource = dt
    End Sub

    Sub GetSaldoAnticiposPersona(ent As entidad)
        Dim dt As New DataTable
        dt.Columns.Add("iddocumeto")
        dt.Columns.Add("fecha")
        dt.Columns.Add("tipo")
        dt.Columns.Add("importe")
        dt.Columns.Add("usado")
        dt.Columns.Add("saldo")


        For Each i In anticipoSA.GetANTReclamacionesPersona(New documentoventaAbarrotes With
                                                             {
                                                             .idEmpresa = Gempresas.IdEmpresaRuc,
                                                             .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                             .tipoVenta = "VNCA",
                                                             .estado = "PN",
                                                             .idCliente = ent.idEntidad
                                                             })

            dt.Rows.Add(i.idDocumento, i.fechaDoc, i.numeroDoc, i.importeMN, i.TotalNotas, i.SaldoReclamacion.GetValueOrDefault)
        Next
        GridPersona.DataSource = dt
    End Sub


    Private Sub GridBeneficios_TableControlCellDoubleClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridPersona.TableControlCellDoubleClick
        Dim r As Record = GridPersona.Table.CurrentRecord

        If r IsNot Nothing Then
            Dim codVenta = Integer.Parse(r.GetValue("iddocumeto"))
            Tag = codVenta
            Close()
        End If

    End Sub

    Private Sub FormAntReclamacionesPendientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Text = "ANTICIPOS"
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If Not TextPersona.Tag Is Nothing Then

            Dim ent As New entidad

            ent.nombreCompleto = TextPersona.Text
            ent.idEntidad = TextPersona.Tag
            ent.nrodoc = TextRuc.Text

            If ComboBox1.Text = "RECLAMACIONES" Then
                If moduloP = "VENTAS" Then
                    GetSaldoReclamacionPersona(ent)
                ElseIf moduloP = "COMPRAS" Then
                    GetAntReclamacionesProveedor(ent)
                End If
            Else
                If moduloP = "VENTAS" Then
                    GetSaldoAnticiposPersona(ent)
                ElseIf moduloP = "COMPRAS" Then
                    GetSaldoAnticiposProveedor(ent)
                End If
            End If

        End If


    End Sub

    Private Sub GridPersona_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles GridPersona.TableControlCellClick

    End Sub
#End Region

End Class