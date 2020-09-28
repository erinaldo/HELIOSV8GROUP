Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Public Class FormCajaActivas

    Public Property DocumentoCajaSA As New DocumentoCajaSA
    Public Property ListaCajasActivas As List(Of cajaUsuario)
    Public Property tipoCaja As String

    Public Sub New(ListaCajas As List(Of cajaUsuario), tipo As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridBlack(gridGroupingControl1, True)
        tipoCaja = tipo
        ListaCajasActivas = ListaCajas
        GetMovimientosDeCaja(Nothing)
    End Sub

    Public Sub New(ListaCajas As List(Of cajaUsuario))

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        FormatoGridBlack(gridGroupingControl1, True)
        tipoCaja = "CONFIG"
        ListaCajasActivas = ListaCajas
        GetMovimientosDeCaja(Nothing)

    End Sub

    Private Sub BunifuThinButton23_Click(sender As Object, e As EventArgs) Handles BunifuThinButton23.Click
        ' GetMovimientosDeCaja(Nothing)
        GrabarCierre()
    End Sub

    Private Sub GrabarCierre()
        Dim be As cajaUsuario
        Dim cajaSA As New cajaUsuarioSA
        Dim lista As New List(Of cajaUsuario)

        For Each i In ListaCajasActivas
            be = New cajaUsuario
            With be
                .idcajaUsuario = i.idcajaUsuario
                .fechaCierre = Date.Now
                .enUso = "N"
                .estadoCaja = "C"
                .otrosEgresosMN = 0 ' nudImporteEgresosmn.Value
                .otrosEgresosME = 0 ' nudImporteEgresosme.Value
                .ingresoAdicMN = 0 ' nudIngresoMN.Value
                .ingresoAdicME = 0 'nudIngresoME.Value
                .idCajaCierre = 0 ' txtCajaDestino.ValueMember

                If i.tipoCaja = "GNR" Then  ' no tiene arqueo
                    .idPadre = i.idcajaUsuario
                End If

            End With
            lista.Add(be)
        Next
        cajaSA.CerrarCajasActivas(lista)
        MessageBox.Show("Caja cerradas con éxito!", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Close()
    End Sub

    Private Sub GetMovimientosDeCaja(fecha As Date?)
        Dim dt As New DataTable
        Dim tipoIngresos As New List(Of String)
        tipoIngresos.Add(TIPO_VENTA.VENTA_ELECTRONICA)
        tipoIngresos.Add(TIPO_VENTA.NOTA_DE_VENTA)
        tipoIngresos.Add("OEC")
        tipoIngresos.Add(MovimientoCaja.CobroCliente)
        tipoIngresos.Add(MovimientoCaja.Otras_Entradas_Especial)

        Dim egresos As New List(Of String)
        egresos.Add(MovimientoCaja.PagoProveedor)
        egresos.Add("OSC")

        Try

            If tipoCaja = Tipo_Caja.ADMINISTRATIVO Then


                Dim listaMovimientos = DocumentoCajaSA.GetMovimientosCajaFullCajerosAdmi(
                 New Business.Entity.cajaUsuario With
                 {
                 .idEmpresa = Gempresas.IdEmpresaRuc,
                 .idEstablecimiento = GEstableciento.IdEstablecimiento,
                 .fechaCierre = fecha,
                 .CustomListaUsuarios = ListaCajasActivas.Select(Function(u) u.idcajaUsuario).Distinct.ToList
                 })

                If listaMovimientos IsNot Nothing Or listaMovimientos.Count > 0 Then

                    Dim usuariosDecaja = listaMovimientos.Select(Function(o) o.idCajaUsuario).Distinct.ToList

                    dt.Columns.Add("Usuario")
                    dt.Columns.Add("Ingresos")
                    dt.Columns.Add("Gastos")
                    dt.Columns.Add("Saldo")

                    For Each i In usuariosDecaja

                        Dim NameUser = ListaCajasActivas.Where(Function(o) o.idcajaUsuario = i).FirstOrDefault

                        Dim IngresosUsuario = listaMovimientos.Where(Function(o) o.idCajaUsuario = i AndAlso tipoIngresos.Contains(o.movimientoCaja)).Sum(Function(o) o.montoSoles).GetValueOrDefault
                        Dim EgresosUsuario = listaMovimientos.Where(Function(o) o.idCajaUsuario = i AndAlso egresos.Contains(o.movimientoCaja)).Sum(Function(o) o.montoSoles).GetValueOrDefault
                        Dim saldo = IngresosUsuario - EgresosUsuario
                        dt.Rows.Add(NameUser.NombrePersona, $"S/{CDec(IngresosUsuario).ToString("N2")}",
                                     $"S/{CDec(EgresosUsuario).ToString("N2")}",
                                     $"S/{CDec(saldo).ToString("N2")}")

                    Next

                    gridGroupingControl1.DataSource = dt
                    'LabelReclamacionClientes.Text = "0.00"
                Else
                    'lblventaElectronica.Text = "0.00"
                    'lblventaNotas.Text = "0.00"
                    'lblOtrasEntradasCaja.Text = "0.00"
                    'lblPagosCobrados.Text = "0.00"
                    'lblIngresoEspecial.Text = "0.00"
                    'LabelPagoProveedor.Text = "0.00"
                    'LabelOtrosEgresos.Text = "0.00"
                    'LabelReclamacionClientes.Text = "0.00"
                End If


            ElseIf tipoCaja = Tipo_Caja.PUNTO_DE_VENTA Then


                Dim listaMovimientos = DocumentoCajaSA.GetMovimientosCajaFullCajeros(
                 New Business.Entity.cajaUsuario With
                 {
                 .idEmpresa = Gempresas.IdEmpresaRuc,
                 .idEstablecimiento = GEstableciento.IdEstablecimiento,
                 .fechaCierre = fecha,
                 .CustomListaUsuarios = ListaCajasActivas.Select(Function(u) u.idcajaUsuario).Distinct.ToList
                 })

                If listaMovimientos IsNot Nothing Or listaMovimientos.Count > 0 Then

                    Dim usuariosDecaja = listaMovimientos.Select(Function(o) o.idCajaUsuario).Distinct.ToList

                    dt.Columns.Add("Usuario")
                    dt.Columns.Add("Ingresos")
                    dt.Columns.Add("Gastos")
                    dt.Columns.Add("Saldo")

                    For Each i In usuariosDecaja

                        Dim NameUser = ListaCajasActivas.Where(Function(o) o.idcajaUsuario = i).FirstOrDefault

                        Dim IngresosUsuario = listaMovimientos.Where(Function(o) o.idCajaUsuario = i AndAlso tipoIngresos.Contains(o.movimientoCaja)).Sum(Function(o) o.montoSoles).GetValueOrDefault
                        Dim EgresosUsuario = listaMovimientos.Where(Function(o) o.idCajaUsuario = i AndAlso egresos.Contains(o.movimientoCaja)).Sum(Function(o) o.montoSoles).GetValueOrDefault
                        Dim saldo = IngresosUsuario - EgresosUsuario
                        dt.Rows.Add(NameUser.NombrePersona, $"S/{CDec(IngresosUsuario).ToString("N2")}",
                                     $"S/{CDec(EgresosUsuario).ToString("N2")}",
                                     $"S/{CDec(saldo).ToString("N2")}")

                    Next

                    gridGroupingControl1.DataSource = dt
                    'LabelReclamacionClientes.Text = "0.00"
                Else
                    'lblventaElectronica.Text = "0.00"
                    'lblventaNotas.Text = "0.00"
                    'lblOtrasEntradasCaja.Text = "0.00"
                    'lblPagosCobrados.Text = "0.00"
                    'lblIngresoEspecial.Text = "0.00"
                    'LabelPagoProveedor.Text = "0.00"
                    'LabelOtrosEgresos.Text = "0.00"
                    'LabelReclamacionClientes.Text = "0.00"
                End If
            ElseIf tipoCaja = "CONFIG" Then



                Dim listaMovimientos = DocumentoCajaSA.GetMovimientosCajaFullCajeros(
                    New Business.Entity.cajaUsuario With
                    {
                    .idEmpresa = Gempresas.IdEmpresaRuc,
                    .idEstablecimiento = GEstableciento.IdEstablecimiento,
                    .fechaCierre = fecha,
                    .CustomListaUsuarios = ListaCajasActivas.Select(Function(u) u.idcajaUsuario).Distinct.ToList
                    })

                If listaMovimientos IsNot Nothing Or listaMovimientos.Count > 0 Then

                    Dim usuariosDecaja = listaMovimientos.Select(Function(o) o.idCajaUsuario).Distinct.ToList

                    dt.Columns.Add("Usuario")
                    dt.Columns.Add("Ingresos")
                    dt.Columns.Add("Gastos")
                    dt.Columns.Add("Saldo")

                    For Each i In usuariosDecaja

                        Dim NameUser = ListaCajasActivas.Where(Function(o) o.idcajaUsuario = i).FirstOrDefault

                        Dim IngresosUsuario = listaMovimientos.Where(Function(o) o.idCajaUsuario = i AndAlso tipoIngresos.Contains(o.movimientoCaja)).Sum(Function(o) o.montoSoles).GetValueOrDefault
                        Dim EgresosUsuario = listaMovimientos.Where(Function(o) o.idCajaUsuario = i AndAlso egresos.Contains(o.movimientoCaja)).Sum(Function(o) o.montoSoles).GetValueOrDefault
                        Dim saldo = IngresosUsuario - EgresosUsuario
                        dt.Rows.Add(NameUser.NombrePersona, $"S/{CDec(IngresosUsuario).ToString("N2")}",
                                     $"S/{CDec(EgresosUsuario).ToString("N2")}",
                                     $"S/{CDec(saldo).ToString("N2")}")

                    Next

                    gridGroupingControl1.DataSource = dt
                    'LabelReclamacionClientes.Text = "0.00"
                Else
                    'lblventaElectronica.Text = "0.00"
                    'lblventaNotas.Text = "0.00"
                    'lblOtrasEntradasCaja.Text = "0.00"
                    'lblPagosCobrados.Text = "0.00"
                    'lblIngresoEspecial.Text = "0.00"
                    'LabelPagoProveedor.Text = "0.00"
                    'LabelOtrosEgresos.Text = "0.00"
                    'LabelReclamacionClientes.Text = "0.00"
                End If

            End If








        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function listaMovimientos() As List(Of documentoCaja)
        Throw New NotImplementedException()
    End Function

    Private Sub FormCajaActivas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FormCajaActivas_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        '    GrabarCierre()
    End Sub
End Class