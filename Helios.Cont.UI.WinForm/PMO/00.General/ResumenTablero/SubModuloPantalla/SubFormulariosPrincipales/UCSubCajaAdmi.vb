Imports System.ComponentModel
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity

Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Public Class UCSubCajaAdmi

#Region "Atributos"

    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)

#End Region

#Region "Metodos"

    Private Sub GetListCuentaFinancierasTotal(tipo As String)
        Dim estadosFinancierosSA As New EstadosFinancierosSA


        Select Case tipo
            Case "CUENTAS EN EFECTIVO"
                tipo = "EF"
            Case "CUENTAS EN BANCO"
                tipo = "BC"
            Case "TARJETA DE CREDITO"
                tipo = "TC"
        End Select

        Dim dt As New DataTable("Mis Cuentas Financieras")
        dt.Columns.Add(New DataColumn("idestado", GetType(Integer)))
        dt.Columns.Add(New DataColumn("descripcion"))
        dt.Columns.Add(New DataColumn("moneda"))
        dt.Columns.Add(New DataColumn("monto"))

        For Each i In estadosFinancierosSA.GetCuentasFinancierasEmpresaXtipoFecha(New Business.Entity.estadosFinancieros With {
                                       .idEmpresa = Gempresas.IdEmpresaRuc,
                                       .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                       .tipo = tipo, .fechaBalance = DateTime.Now})

            Dim dr As DataRow = dt.NewRow()

            dr(0) = i.idestado
            dr(1) = i.descripcion
            dr(2) = "-"
            dr(3) = (i.SaldoAnterior.GetValueOrDefault + i.Cobros.GetValueOrDefault) - i.Pagos.GetValueOrDefault
            dt.Rows.Add(dr)
        Next

        setDatasource(dt)


    End Sub
    Public Sub setDatasource(ByVal table As DataTable)
        If Me.InvokeRequired Then
            Dim deleg As New SetDataSourceDelegate(AddressOf setDatasource)
            Invoke(deleg, New Object() {table})
        Else
            DgvComprobantes.DataSource = table
            'ProgressBar1.Visible = False
        End If
    End Sub

    Public Sub AbrirCajaGeneral()
        Dim usuarioSel = UsuariosList.Where(Function(o) o.TipoDocumento = "SUPER").FirstOrDefault
        If usuarioSel IsNot Nothing Then

            Dim CargoSelec = usuarioSel.UsuarioRol.FirstOrDefault  ' super usuairo solo tiene 1 rol 
            If CargoSelec IsNot Nothing Then


                Dim cajaSA As New cajaUsuarioSA
                Dim objCaja As New cajaUsuario
                Dim documentoCajaSA As New DocumentoCajaSA
                Dim UserDetalle As New cajaUsuariodetalle
                Dim ListaUserDetalle As New List(Of cajaUsuariodetalle)
                Try
                    objCaja = New cajaUsuario

                    Dim shostname As String
                    shostname = System.Net.Dns.GetHostName
                    With objCaja
                        .IDRol = CargoSelec.IDRol
                        .tipoCaja = Tipo_Caja.GENERAL
                        .namepc = shostname
                        .idEmpresa = Gempresas.IdEmpresaRuc
                        .idEstablecimiento = GEstableciento.IdEstablecimiento
                        .periodo = GetPeriodo(Date.Now, True)
                        .idPersona = usuarioSel.IDUsuario
                        .idCajaOrigen = 0
                        .idCajaDestino = 0
                        .moneda = "1"
                        .tipoCambio = TmpTipoCambio
                        .fechaRegistro = Date.Now
                        .fondoMN = 0
                        .fondoME = 0
                        .ingresoAdicMN = 0
                        .ingresoAdicME = 0
                        .otrosIngresosMN = 0
                        .otrosIngresosME = 0
                        .otrosEgresosMN = 0
                        .otrosEgresosME = 0
                        .estadoCaja = "A"
                        .enUso = "N"
                        .usuarioActualizacion = usuario.IDUsuario
                        .fechaActualizacion = DateTime.Now
                    End With

                    ListaUserDetalle = New List(Of cajaUsuariodetalle)

                    For Each d In ListaCuentasFinancierasConfiguradas.Where(Function(o) o.IDFormaPago <> "9991" And o.tipoCaja <> "EP").ToList
                        UserDetalle = New cajaUsuariodetalle
                        UserDetalle.idEntidad = Integer.Parse(d.identidad)
                        UserDetalle.moneda = d.moneda

                        If UserDetalle.moneda = "1" Then
                            UserDetalle.importeMN = CDec(0.0)
                            UserDetalle.importeME = 0
                        ElseIf UserDetalle.moneda = "2" Then
                            UserDetalle.importeMN = 0
                            UserDetalle.importeME = CDec(0.0)
                        End If

                        UserDetalle.tipoCambio = TmpTipoCambio
                        UserDetalle.usuarioActualizacion = usuario.IDUsuario
                        UserDetalle.idConfiguracion = Integer.Parse(d.idConfiguracion)
                        UserDetalle.fechaActualizacion = DateTime.Now
                        ListaUserDetalle.Add(UserDetalle)
                    Next
                    objCaja.cajaUsuariodetalle = ListaUserDetalle
                    If ListaUserDetalle.Count = 0 Then Exit Sub
                    Dim codigoUsuarioClave = documentoCajaSA.SaveCajaAdministrativaApertura(Nothing, objCaja, Nothing)
                    ListaCajasActivas = cajaSA.ListadoCajaXEstado(New cajaUsuario With {
                                                                     .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                     .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                     .estadoCaja = "A"
                                                                     })

                Catch ex As Exception

                End Try


            End If

        End If




    End Sub

#End Region
    Private Sub btnSalidaDeDinero_Click(sender As Object, e As EventArgs) Handles btnSalidaDeDinero.Click
        Cursor = Cursors.WaitCursor


        Dim cajaActivaGeneral = ListaCajasActivas.Where(Function(o) o.tipoCaja = Tipo_Caja.GENERAL).SingleOrDefault

        If cajaActivaGeneral Is Nothing Then
            AbrirCajaGeneral()
        End If

        Dim f As New FormPagoEgreso
            f.txtAnioCompra.Text = DateTime.Now.Year
            f.cboMesCompra.SelectedValue = String.Format("{0:00}", DateTime.Now.Month)
            f.txtHora.Value = DateTime.Now
            f.TxtDia.Text = DateTime.Now.Day ' ""
            f.StartPosition = FormStartPosition.CenterParent
            f.txtTipoCambio.Value = TmpTipoCambio
            f.ShowDialog(Me)


        Cursor = Cursors.Default
    End Sub

    Private Sub btnEntradaDeDinero_Click(sender As Object, e As EventArgs) Handles btnEntradaDeDinero.Click
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Cursor = Cursors.WaitCursor

        Dim cajaActivaGeneral = ListaCajasActivas.Where(Function(o) o.tipoCaja = Tipo_Caja.GENERAL).SingleOrDefault

        If cajaActivaGeneral Is Nothing Then
            AbrirCajaGeneral()
        End If



        Dim f As New FormRealizacionDePagos
            f.txtAnioCompra.Text = DateTime.Now.Year
            f.cboMesCompra.SelectedValue = String.Format("{0:00}", DateTime.Now.Month)
            f.txtHora.Value = DateTime.Now
            f.TxtDia.Text = DateTime.Now.Day ' ""
            f.StartPosition = FormStartPosition.CenterParent
            f.txtTipoCambio.Value = TmpTipoCambio
            f.ShowDialog(Me)

        Cursor = Cursors.Default
    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click

        GetListCuentaFinancierasTotal(cboTipo.Text)
    End Sub
End Class
