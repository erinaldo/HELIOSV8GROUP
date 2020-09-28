Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports System.IO
Imports OpenInvoicePeru.Comun.Dto.Intercambio
Imports OpenInvoicePeru.Comun.Dto.Modelos
Imports Syncfusion.Windows.Forms.Grid
Imports System.Runtime.Serialization
Public Class UCPrincipalCompras

#Region "Atributos"

    Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)
    Dim Alert As Alert
    Public Property CompraSA As New DocumentoCompraSA
#End Region

#Region "Constructor"
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        FormatoGridAvanzado(DgvComprobantes, False, False, 8.0F)
        'FormatoGrid(DgvComprobantes)
        ' Add any initialization after the InitializeComponent() call.


        FormatoGridPrincipal(DgvComprobantes)
    End Sub

#End Region

#Region "Metodos"

    Private Sub EliminarCompraGeneral()
        Dim compraSA As New DocumentoCompraSA
        Dim r As Record = DgvComprobantes.Table.CurrentRecord
        If r IsNot Nothing Then
            compraSA.AnularCompra(New documento With {.idDocumento = Integer.Parse(r.GetValue("idDocumento"))})
            Alert = New Alert("Compra eliminada", alertType.info)
            Alert.TopMost = True
            Alert.Show()
            r.Delete()
            DgvComprobantes.Refresh()
        End If
    End Sub

    Sub ElimnarDoc()
        Dim UsuarioEstadoCaja As New UsuarioEstadoCaja
        If Not IsNothing(Me.DgvComprobantes.Table.CurrentRecord) Then
            If DgvComprobantes.Table.CurrentRecord.GetValue("tipoCompra") = TIPO_COMPRA.COMPRA Then
                EliminarCompraGeneral()
            ElseIf Me.DgvComprobantes.Table.CurrentRecord.GetValue("tipoCompra") = TIPO_COMPRA.COMPRA_RECIBO_HONORARIOS Then
                '  EliminarReciboHonorario(Me.dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))
            ElseIf Me.DgvComprobantes.Table.CurrentRecord.GetValue("tipoCompra") = TIPO_COMPRA.COMPRA_SERVICIO_PUBLICO Then
                '  EliminarServicioPublico(Me.dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))

            ElseIf Me.DgvComprobantes.Table.CurrentRecord.GetValue("tipoCompra") = TIPO_COMPRA.COMPRA_ANTICIPADA_OTORGADO Then
                ' EliminarServicioPublico(Me.dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))

            ElseIf Me.DgvComprobantes.Table.CurrentRecord.GetValue("tipoCompra") = TIPO_COMPRA.COMPRA_ANTICIPADA_RECIBIDA Then
                ' EliminarServicioPublico(Me.dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))

            ElseIf Me.DgvComprobantes.Table.CurrentRecord.GetValue("tipoCompra") = TIPO_COMPRA.NOTA_CREDITO Then
                ' EliminarNota(Me.dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))

            ElseIf Me.DgvComprobantes.Table.CurrentRecord.GetValue("tipoCompra") = TIPO_COMPRA.NOTA_DEBITO Then
                ' EliminarDebito(Me.dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))

            ElseIf Me.DgvComprobantes.Table.CurrentRecord.GetValue("tipoCompra") = TIPO_COMPRA.BONIFICACIONES_RECIBIDAS Then
                '      EliminarNotaCreditoBonificacion(Me.dgvCompras.Table.CurrentRecord.GetValue("idDocumento"))
            End If
        End If
    End Sub
    Private Sub GetComprasPorMes(PeriodoSel As String, intIdEstable As Integer)
        Dim DocumentoCompraSA As New DocumentoCompraSA
        Dim ListaCompras As List(Of documentocompra)

        'Dim dt As New DataTable("Período: " & PeriodoSel & " ")
        'dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        'dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        ''lower case p
        'dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        'dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        'dt.Columns.Add(New DataColumn("serie", GetType(String)))
        'dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))

        'dt.Columns.Add(New DataColumn("tipoDocEntidad", GetType(String)))
        'dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        'dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        'dt.Columns.Add(New DataColumn("TipoPersona ", GetType(String)))

        'dt.Columns.Add(New DataColumn("importeTotal"))
        'dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
        'dt.Columns.Add(New DataColumn("importeUS"))

        'dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))
        'dt.Columns.Add(New DataColumn("usuarioActualizacion", GetType(String)))
        'dt.Columns.Add(New DataColumn("situacion", GetType(String)))
        'dt.Columns.Add(New DataColumn("estado", GetType(String)))
        'dt.Columns.Add(New DataColumn("Aprobado", GetType(String)))
        'dt.Columns.Add(New DataColumn("ant", GetType(Integer)))
        'dt.Columns.Add("detraccion")
        'dt.Columns.Add("relacionado")

        'dt.Columns.Add("bi01")
        'dt.Columns.Add("bi02")
        'dt.Columns.Add("igv")

        'ListaCompras = DocumentoCompraSA.GetListarComprasPorPeriodoGeneral_CONT_CONTADO((New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = intIdEstable}), PeriodoSel).Where(Function(o) o.tipoCompra <> TIPO_COMPRA.COMPRA_ANULADA).ToList

        'Dim str As String
        'For Each i As documentocompra In ListaCompras
        '    Dim dr As DataRow = dt.NewRow()
        '    str = Nothing
        '    str = CDate(i.fechaDoc).ToString("dd-MMM HH:mm tt ")
        '    dr(0) = i.idDocumento
        '    dr(1) = i.tipoCompra
        '    dr(2) = str
        '    dr(3) = i.tipoDoc
        '    dr(4) = i.serie
        '    dr(5) = i.numeroDoc
        '    dr(6) = i.tipoDocEntidad
        '    dr(7) = i.NroDocEntidad
        '    dr(8) = i.NombreEntidad
        '    dr(9) = i.TipoPersona

        '    If i.tipoCompra = "BOFR" Then
        '        dr(10) = CDec(0.0)
        '        dr(11) = CDec(0.0)
        '        dr(12) = CDec(0.0)
        '    Else
        '        dr(10) = CDec(i.importeTotal).ToString("N2")
        '        dr(11) = i.tcDolLoc
        '        dr(12) = i.importeUS
        '    End If



        '    'dr(11) = i.tcDolLoc
        '    'dr(12) = i.importeUS
        '    dr(13) = i.monedaDoc
        '    dr(14) = i.usuarioActualizacion
        '    dr(15) = i.situacion
        '    Select Case i.estadoPago
        '        Case TIPO_COMPRA.PAGO.PAGADO
        '            dr(16) = "Saldado"
        '        Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
        '            dr(16) = "Pendiente"
        '    End Select

        '    Select Case i.aprobado
        '        Case "S"
        '            dr(17) = "Aprobado"
        '        Case Else
        '            dr(17) = "Pendiente"
        '    End Select
        '    dr(18) = i.Atraso
        '    dr(19) = If(i.tieneDetraccion = "S", "Si", "No")
        '    If i.idPadre IsNot Nothing Then
        '        dr(20) = "SI"
        '    Else
        '        dr(20) = "NO"
        '    End If

        '    dr(21) = i.bi01
        '    dr(22) = i.bi02
        '    dr(23) = i.igv01

        '    dt.Rows.Add(dr)
        'Next
        'SetDatasourceCompra(dt)





        Dim dt As New DataTable("Compras de - " & PeriodoSel)
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("comprobante", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDocumento", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numero", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("bi", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("bi02", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("igv", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("icbper", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("total", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("aprobado", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))



        ListaCompras = DocumentoCompraSA.GetListarComprasPorPeriodoGeneral_CONT_CONTADO((New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = intIdEstable, .tipoConsulta = "UNIDAD_ORGANICA"}), PeriodoSel).Where(Function(o) o.tipoCompra <> TIPO_COMPRA.COMPRA_ANULADA).ToList
        Dim str As String
        For Each i As documentocompra In ListaCompras
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = str
            dr(2) = i.tipoDoc

            Select Case i.tipoDoc
                Case "01"
                    dr(3) = "Factura"
                Case "03"
                    dr(3) = "Boleta"
                Case "07"
                    dr(3) = "Nota Credito"
                Case "08"
                    dr(3) = "Nota Debito"
            End Select


            dr(4) = i.serie
            dr(5) = i.numeroDoc

            Select Case i.NroDocEntidad
                Case Is = Nothing

                    dr(6) = "-"
                    dr(7) = i.NombreEntidad
                Case Else

                    dr(6) = i.NroDocEntidad
                    dr(7) = i.NombreEntidad
            End Select



            dr(8) = i.bi01
            dr(9) = i.bi02

            dr(10) = i.igv01
            dr(11) = 0
            dr(12) = i.importeTotal




            Select Case i.estadoPago
                Case TIPO_COMPRA.PAGO.PAGADO
                    dr(13) = "Saldado"
                Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                    dr(13) = "Pendiente"
            End Select




            Select Case i.aprobado
                Case "S"
                    dr(14) = "Aprobado"
                Case Else
                    dr(14) = "Pendiente"
            End Select
            dr(15) = i.tipoCompra
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

#End Region

    Private Sub btnNuevaCompra_Click(sender As Object, e As EventArgs) Handles btnNuevaCompra.Click
        Me.Cursor = Cursors.WaitCursor
        If validarPermisos(PermisosDelSistema.INGRESO_DE_COMPRAS_, AutorizacionRolList) = 1 Then
            Dim f As New FormCrearCompra("COMPRAS")
            f.ComboComprobante.Enabled = True
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnBuscarCompra_Click(sender As Object, e As EventArgs) Handles btnBuscarCompra.Click
        Select Case cboTipoBusqueda.Text
            Case "COMPRAS DEL PERIODO"


                Dim datos As List(Of item) = item.Instance()
                datos.Clear()

                Dim f As New FormFiltroPeriodoCompras()
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog(Me)
                If f.Tag IsNot Nothing Then
                    Dim periodoSel = CType(f.Tag, DateTime?)
                    Dim periodoString = GetPeriodo(periodoSel, True)

                    If datos.Count > 0 Then


                        Select Case datos(0).descripcion
                            Case "TODAS LAS COMPRAS"
                                GetComprasPorMes(periodoString, GEstableciento.IdEstablecimiento)
                        End Select
                    End If
                End If


            Case "COMPRAS POR PROVEEDOR"

            Case "BUSCAR COMPROBANTE"

        End Select
    End Sub

    Private Sub btnAnularCompra_Click(sender As Object, e As EventArgs) Handles btnAnularCompra.Click
        Try
            'If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.ELIMINAR_ANULAR_Botón___, AutorizacionRolList) Then
            If DgvComprobantes.Table.Records.Count > 0 Then
                If Not IsNothing(DgvComprobantes.Table.CurrentRecord) Then
                    If MessageBox.Show("Desea eliminar el registro seleccionada!", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        ElimnarDoc()
                    End If
                End If
            End If
            'Else
            '    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'End If

        Catch ex As Exception
            If ex.Message = "ETEA" Then
                '        Alert = New Alert("Tiene produtos relacionados a otros almacenes", alertType.Errors)
                MsgBox("Tiene productos relacionados a otros almacenes", MsgBoxStyle.Critical, "Verificar documentos")
            Else
                Alert = New Alert(ex.Message, alertType.Errors)
                Alert.TopMost = True
                Alert.Show()
            End If

        End Try
    End Sub

    Private Sub btnNuevoComprobanteAdicional_Click(sender As Object, e As EventArgs) Handles btnNuevoComprobanteAdicional.Click
        Select Case cboComprobantesAdicional.Text
            Case "NOTA DE CREDITO"
                Cursor = Cursors.WaitCursor
                'If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.NOTA_DE_CREDITO_Formulario___, AutorizacionRolList) Then
                Dim r As Record = DgvComprobantes.Table.CurrentRecord
                If r IsNot Nothing Then
                    Try

                        Dim TieneExistenciasEntransito = CompraSA.GetTieneArticulosEnTransitoCompra(New documentocompra With {.idDocumento = CInt(r.GetValue("idDocumento"))})
                        If TieneExistenciasEntransito = True Then
                            MessageBox.Show("La compra tiene existencias en tránsito" & vbCrLf &
                                                       "realizar el envío pendiente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            LoadingAnimator.UnWire(DgvComprobantes.TableControl)
                            Cursor = Cursors.Default
                            Exit Sub
                        End If

                        Dim compra = CompraSA.UbicarDocumentoCompra(CInt(r.GetValue("idDocumento")))
                        Select Case compra.tipoDoc
                            Case "07", "08", "87", "88"
                                MessageBox.Show("Debe seleccionar una compra válida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Case Else

                                Dim ListadoReferencias = CompraSA.GetListarNotasPorIdCompraPadre(CInt(r.GetValue("idDocumento")), "00")

                                If ListadoReferencias.Count > 0 Then
                                    Dim frm As New frmDetalleReferenciasComprobantes(ListadoReferencias)
                                    frm.StartPosition = FormStartPosition.CenterParent
                                    frm.ShowDialog()
                                    Dim result = CType(frm.Tag, InfoNotas)
                                    If result.seguirOperaion = "SI" Then

                                        Dim f As New FormNotaCreditoCompras(CInt(r.GetValue("idDocumento"))) 'FormNotaVentaDescuentoFE(CInt(r.GetValue("idDocumento")))  'frmNotaVentaNewFE
                                        f.StartPosition = FormStartPosition.CenterParent
                                        f.ShowDialog()

                                    End If
                                Else



                                    Dim f As New FormNotaCreditoCompras(CInt(r.GetValue("idDocumento"))) 'FormNotaVentaDescuentoFE(CInt(r.GetValue("idDocumento")))  'frmNotaVentaNewFE
                                    f.StartPosition = FormStartPosition.CenterParent
                                    f.ShowDialog()



                                End If

                        End Select

                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                End If

                Cursor = Cursors.Default

        End Select
    End Sub

    Private Sub btnVerDetalle_Click(sender As Object, e As EventArgs) Handles btnVerDetalle.Click
        PictureLoad.Visible = True
        Dim r As Record = Me.DgvComprobantes.Table.CurrentRecord
        If r IsNot Nothing Then
            Dim f As New FormCrearCompra(Integer.Parse(r.GetValue("idDocumento")))
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
        End If
        PictureLoad.Visible = False
    End Sub
End Class
