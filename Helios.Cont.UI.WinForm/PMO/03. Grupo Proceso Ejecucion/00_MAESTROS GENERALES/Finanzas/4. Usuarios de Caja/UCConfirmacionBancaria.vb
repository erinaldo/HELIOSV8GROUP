Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Public Class UCConfirmacionBancaria

#Region "Atributos"
    Public Property cajaResponsable As List(Of estadosFinancierosConfiguracionPagos)
    Public Property ListaEstadoFinancierosMaster As List(Of estadosFinancieros)

    Public Property cajaactiva As cajaUsuario

#End Region

#Region "Constructor"

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        GetTableGrid()
        FormatoGridAvanzado(dgvVentas, False, False, 11.5F)
        ' Add any initialization after the InitializeComponent() call.
        txtPeriodoAFC.Value = DateTime.Now

        ResponsableCarga(usuario.IDUsuario)
    End Sub

#End Region

#Region "Metodos"


    Public Sub ResponsableCarga(idUsuario As Integer)


        Try


            cajaResponsable = New List(Of estadosFinancierosConfiguracionPagos)
            Dim SA As New EstadosFinancierosConfiguracionPagosSA



            'If ListViewHistorialCajas.SelectedItems.Count > 0 Then


            cajaactiva = (From i In ListaCajasActivas
                          Where i.tipoCaja = Tipo_Caja.ADMINISTRATIVO And
                                         i.estadoCaja = "A" And i.idEmpresa = Gempresas.IdEmpresaRuc And i.idEstablecimiento = GEstableciento.IdEstablecimiento).SingleOrDefault



            'Dim cajauser = Integer.Parse(ListViewHistorialCajas.SelectedItems(0).SubItems(0).Text)

            If (Not IsNothing(cajaactiva)) Then

                cajaResponsable = SA.GetConfigurationPayCaja(New estadosFinancierosConfiguracionPagos With
                                                                     {
                                                                     .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                     .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                     .IDCaja = cajaactiva.idcajaUsuario
                                                                    })


            End If
            'End If

        Catch ex As Exception

        End Try

    End Sub


    Public Sub ConfirmacionDineroBancario()
        Try


            Dim SA As New DocumentoCajaSA
            Dim List As New List(Of documentoCaja)
            Dim obj As documentoCaja

            For Each r As Record In dgvVentas.Table.Records
                Dim verficar = Boolean.Parse(r.GetValue("verficar"))

                If verficar = True Then



                    obj = New documentoCaja
                    obj.idDocumento = CInt(r.GetValue("idDocumento"))
                    obj.fechaconfirmacionOperacion = CDate(r.GetValue("fechaVerificacion"))
                    obj.confirmacionOperacion = "SI"
                    obj.idRol = usuario.IDRol
                    obj.IdUsuarioTransaccion = usuario.IDUsuario
                    List.Add(obj)
                End If


            Next

            SA.ConfirmacionBancaria(List)

            If cboEntidadFinanciera.Text.Trim.Length > 0 Then
                BuscarTransaccionesBancarias()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Public Sub CargarCajasTipo2(tiping As String)
        Dim estadoSA As New EstadosFinancierosSA
        Try
            ListaEstadoFinancierosMaster = New List(Of estadosFinancieros)
            ListaEstadoFinancierosMaster = estadoSA.ObtenerEFPorCuentaFinanciera(New estadosFinancieros With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                                                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                                  .tipo = tiping,
                                                                                  .tipoConsulta = StatusTipoConsulta.XEmpresa})
            cboEntidadFinanciera.DataSource = ListaEstadoFinancierosMaster
            cboEntidadFinanciera.DisplayMember = "descripcion"
            cboEntidadFinanciera.ValueMember = "idestado"
            cboEntidadFinanciera.SelectedValue = -1
        Catch ex As Exception

        End Try
    End Sub

    Public Sub BuscarTransaccionesBancarias()
        dgvVentas.Table.Records.DeleteAll()
        Dim sa As New DocumentoCajaSA

        Dim doc As New documentoCaja

        doc.entidadFinancieraDestino = cboEntidadFinanciera.SelectedValue
        doc.fechaProcesoDestino = txtPeriodoAFC.Value
        doc.idEmpresa = Gempresas.IdEmpresaRuc
        doc.idEstablecimiento = GEstableciento.IdEstablecimiento

        Dim lista = sa.GetMovimientosBancariosPendientes(doc)


        For Each i In lista

            Me.dgvVentas.Table.AddNewRecord.SetCurrent()
            Me.dgvVentas.Table.AddNewRecord.BeginEdit()
            Me.dgvVentas.Table.CurrentRecord.SetValue("idDocumento", i.idDocumento)
            Me.dgvVentas.Table.CurrentRecord.SetValue("fechaProceso", i.fechaProcesoDestino)
            Me.dgvVentas.Table.CurrentRecord.SetValue("identidadFinanciera", i.entidadFinancieraDestino)
            Me.dgvVentas.Table.CurrentRecord.SetValue("entidadFinanciera", cboEntidadFinanciera.Text)
            Me.dgvVentas.Table.CurrentRecord.SetValue("montoSoles", i.montoSoles)
            Me.dgvVentas.Table.CurrentRecord.SetValue("tipoDoc", i.tipoDocCompra)
            Me.dgvVentas.Table.CurrentRecord.SetValue("serie", i.SerieCompra)
            Me.dgvVentas.Table.CurrentRecord.SetValue("numero", i.numeroCompra)
            Me.dgvVentas.Table.CurrentRecord.SetValue("verficar", False)
            Me.dgvVentas.Table.CurrentRecord.SetValue("nroOperacion", i.numeroOperacion)
            Me.dgvVentas.Table.CurrentRecord.SetValue("formaPago", i.formaPagoName)
            Me.dgvVentas.Table.CurrentRecord.SetValue("fechaVerificacion", DateTime.Now)
            Me.dgvVentas.Table.AddNewRecord.EndEdit()

        Next

    End Sub
    Sub GetTableGrid()
        Dim dt As New DataTable()
        dt.Columns.Add("idDocumento")
        dt.Columns.Add("fechaProceso")
        dt.Columns.Add("identidadFinanciera")
        dt.Columns.Add("entidadFinanciera")
        dt.Columns.Add("montoSoles")
        dt.Columns.Add("tipoDoc")
        dt.Columns.Add("serie")
        dt.Columns.Add("numero")
        dt.Columns.Add("verficar")
        dt.Columns.Add("nroOperacion")
        dt.Columns.Add("formaPago")
        dt.Columns.Add("fechaVerificacion", GetType(DateTime))
        dgvVentas.DataSource = dt
        dgvVentas.TopLevelGroupOptions.ShowCaption = True
    End Sub

    Private Sub cboTipo_Click(sender As Object, e As EventArgs) Handles cboTipo.Click

    End Sub

    Private Sub cboTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipo.SelectedIndexChanged
        Cursor = Cursors.WaitCursor
        dgvVentas.Table.Records.DeleteAll()
        'If cboTipo.Text = "CUENTAS EN EFECTIVO" Then
        '    CargarCajasTipo2(CuentaFinanciera.Efectivo)
        'ElseIf cboTipo.Text = "CUENTAS EN EFECTIVO CAJERO" Then
        '    CargarCajasTipo2(CuentaFinanciera.Efectivo_Cajero)
        If cboTipo.Text = "CUENTAS EN BANCO" Then
            CargarCajasTipo2(CuentaFinanciera.Banco)
        ElseIf cboTipo.Text = "TARJETA DE CREDITO" Then
            CargarCajasTipo2(CuentaFinanciera.Tarjeta_Credito)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub cboEntidadFinanciera_Click(sender As Object, e As EventArgs) Handles cboEntidadFinanciera.Click

    End Sub

    Private Sub cboEntidadFinanciera_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEntidadFinanciera.SelectedIndexChanged
        dgvVentas.Table.Records.DeleteAll()

        Dim cod = cboEntidadFinanciera.SelectedValue

        If IsNumeric(cod) Then
            If (Not IsNothing(ListaEstadoFinancierosMaster)) Then
                Dim conusulta = (From a In ListaEstadoFinancierosMaster Where a.idestado = cod Select a).FirstOrDefault
                If (Not IsNothing(conusulta)) Then
                    txtMonedaKardex.Text = conusulta.codigo
                End If
            End If
        End If
    End Sub

    Private Sub ButtonAdv14_Click(sender As Object, e As EventArgs) Handles ButtonAdv14.Click
        If cboEntidadFinanciera.Text.Trim.Length > 0 Then
            BuscarTransaccionesBancarias()
        End If
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        ConfirmacionDineroBancario()
    End Sub

#End Region

End Class
