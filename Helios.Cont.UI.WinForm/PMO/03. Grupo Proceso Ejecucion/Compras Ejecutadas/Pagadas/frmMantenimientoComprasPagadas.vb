Imports <xmlns="urn:schemas-microsoft-com:office:spreadsheet">
Imports <xmlns:o="urn:schemas-microsoft-com:office:office">
Imports <xmlns:x="urn:schemas-microsoft-com:office:excel">
Imports <xmlns:ss="urn:schemas-microsoft-com:office:spreadsheet">
Imports <xmlns:html="http://www.w3.org/TR/REC-html40">

Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess


Public Class frmMantenimientoComprasPagadas
    Inherits frmMaster

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        lblPerido.Text = PeriodoGeneral
        ListaCompras(PeriodoGeneral)
        InitializeRAdial()
    End Sub
#Region "TIMER"
    Sub parpadeo()
        Static parpadear As Boolean

        If Not parpadear Then
            lblEstado.ForeColor = lblEstado.BackColor
            lblEstado.BackColor = Color.Yellow
        Else
            lblEstado.ForeColor = SystemColors.WindowText
        End If

        parpadear = Not parpadear
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If TiempoRestante > 0 Then
            parpadeo()

            'lblAgregar.Visible = True
            'lblMensaje.Visible = True
            'tsSave.Enabled = False
            'lblMensaje.Text = "Agregar otro en: " & TiempoRestante
            TiempoRestante = TiempoRestante - 1
        ElseIf TiempoRestante = 0 Then
            Timer1.Enabled = False
            lblEstado.ForeColor = Color.Navy
            lblEstado.BackColor = Color.Transparent
            '      Dispose()
        Else
            Timer1.Enabled = False
            'Ejecuta tu función cuando termina el tiempo
            TiempoEjecutar(10)

        End If
    End Sub
    Private TiempoRestante As Integer
    Public Sub TimerOn(ByRef Interval As Short)
        If Interval > 0 Then
            Timer1.Enabled = True
        Else
            Timer1.Enabled = False
        End If

    End Sub
    Public Function TiempoEjecutar(ByVal Tiempo As Integer)
        TiempoEjecutar = ""
        TiempoRestante = Tiempo  ' 1 minutos=60 segundos 
        Timer1.Interval = 400

        Call TimerOn(1000) ' Hechanos a andar el timer
    End Function
#End Region

#Region "Métodos"

    Public Function TieneCuentaFinanciera(Optional intIdDocumento As Integer = Nothing) As Boolean
        Dim efSA As New EstadosFinancierosSA
        Dim ef As New estadosFinancieros
        Dim estableSA As New establecimientoSA

        GFichaUsuarios = New GFichaUsuario
        With frmFichaUsuarioCaja
            ModuloAppx = ModuloSistema.CAJA
            .lblNivel.Text = "Caja"
            .lblEstadoCaja.Visible = True
            '.GroupBox1.Visible = True
            '.GroupBox2.Visible = True
            '.GroupBox4.Visible = True
            '.cboMoneda.Visible = True
            .Timer1.Enabled = False
            .StartPosition = FormStartPosition.CenterParent
            '.UbicarUsuarioCaja(intIdDocumento, "COMPRA")
            .ShowDialog()
            If IsNothing(GFichaUsuarios.NombrePersona) Then
                Return False
            Else
                Return True
            End If
        End With

        Return True

    End Function

    Public Sub ListaComprasPorRango(desde As Date, hasta As Date)
        Dim documentoCompraSA As New DocumentoCompraSA
        Dim grupoActual As String = String.Empty
        Dim g As New ListViewGroup
        Try

            lsvProduccion.Columns.Clear()
            lsvProduccion.Items.Clear()
            lsvProduccion.Columns.Add("idDocumento", 0, HorizontalAlignment.Center) '0
            lsvProduccion.Columns.Add("T/OP", 50, HorizontalAlignment.Left) '1
            lsvProduccion.Columns.Add("Fecha emisión/pago", 155, HorizontalAlignment.Left) '2
            lsvProduccion.Columns.Add("C/P", 40, HorizontalAlignment.Left) '3
            lsvProduccion.Columns.Add("Serie", 59, HorizontalAlignment.Center) '4
            lsvProduccion.Columns.Add("N° Comprobante de pago", 146, HorizontalAlignment.Center) '5
            lsvProduccion.Columns.Add("T/D/P", 50, HorizontalAlignment.Left) '6
            lsvProduccion.Columns.Add("N° Documento", 95, HorizontalAlignment.Center) '7
            lsvProduccion.Columns.Add("Proveedor", 237, HorizontalAlignment.Left) '8
            lsvProduccion.Columns.Add("Tipo de Persona", 0, HorizontalAlignment.Left) '9
            lsvProduccion.Columns.Add("Importe (MN)", 90, HorizontalAlignment.Right) '10
            lsvProduccion.Columns.Add("T/C", 50, HorizontalAlignment.Center) '11
            lsvProduccion.Columns.Add("Importe (ME)", 90, HorizontalAlignment.Right) '12
            lsvProduccion.Columns.Add("Moneda", 50, HorizontalAlignment.Center) '13
            lsvProduccion.Columns.Add("TIPO", 50, HorizontalAlignment.Center) '14
            lsvProduccion.Columns.Add("Docs/Sust.", 0, HorizontalAlignment.Center) '15
            lsvProduccion.Columns.Add("Estado", 70, HorizontalAlignment.Center) '16


            For Each i As documentocompra In documentoCompraSA.GetListarComprasPorRango_CONT(desde, hasta)

                Dim n As New ListViewItem(i.idDocumento)
                n.UseItemStyleForSubItems = False
                If i.tipoCompra = TIPO_COMPRA.COMPRA_AL_CREDITO Then
                    n.SubItems.Add(i.tipoOperacion).BackColor = Color.Lavender
                ElseIf i.tipoCompra = TIPO_COMPRA.COMPRA_PAGADA Then
                    n.SubItems.Add(i.tipoOperacion).BackColor = Color.FromArgb(225, 240, 190)
                ElseIf i.tipoCompra = TIPO_COMPRA.NOTA_CREDITO Then
                    n.SubItems.Add(i.tipoOperacion).BackColor = Color.LavenderBlush
                ElseIf i.tipoCompra = TIPO_COMPRA.NOTA_DEBITO Then
                    n.SubItems.Add(i.tipoOperacion).BackColor = Color.LightYellow
                End If

                '    n.SubItems.Add(IIf(i.Destino = "CI", "COMPRA INTERNA", "COMPRA DIRECTA INTERNA"))
                n.SubItems.Add(FormatDateTime(i.fechaDoc, DateFormat.GeneralDate))
                n.SubItems.Add(i.tipoDoc)
                n.SubItems.Add(i.serie)
                n.SubItems.Add(i.numeroDoc)
                n.SubItems.Add(i.tipoDocEntidad)
                n.SubItems.Add(i.NroDocEntidad)
                n.SubItems.Add(i.NombreEntidad)
                n.SubItems.Add(IIf(i.TipoPersona = "N", "PERS.NATURAL", "PERS.JURIDICA"))
                n.SubItems.Add(FormatNumber(i.importeTotal, 2))
                n.SubItems.Add(FormatNumber(i.tcDolLoc, 2))
                n.SubItems.Add(FormatNumber(i.importeUS, 2))
                n.SubItems.Add(i.monedaDoc)
                n.SubItems.Add(i.tipoCompra)
                n.SubItems.Add("")
                If i.estadoPago = TIPO_COMPRA.PAGO.PAGADO Then
                    n.SubItems.Add("Pagado")
                ElseIf i.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO Then
                    n.SubItems.Add("En trámite")
                End If
                lsvProduccion.Items.Add(n)

            Next

            If lsvProduccion.Items.Count > 0 Then
                lsvProduccion.Focus()
                lsvProduccion.Items(0).Selected = True
                lsvProduccion.Items(0).Focused = True

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ListaComprasPorMes(año As Integer, mes As String)
        Dim documentoCompraSA As New DocumentoCompraSA
        Dim grupoActual As String = String.Empty
        Dim g As New ListViewGroup
        Try

            lsvProduccion.Columns.Clear()
            lsvProduccion.Items.Clear()
            lsvProduccion.Columns.Add("idDocumento", 0, HorizontalAlignment.Center) '0
            lsvProduccion.Columns.Add("T/OP", 50, HorizontalAlignment.Left) '1
            lsvProduccion.Columns.Add("Fecha emisión/pago", 155, HorizontalAlignment.Left) '2
            lsvProduccion.Columns.Add("C/P", 40, HorizontalAlignment.Left) '3
            lsvProduccion.Columns.Add("Serie", 59, HorizontalAlignment.Center) '4
            lsvProduccion.Columns.Add("N° Comprobante de pago", 146, HorizontalAlignment.Center) '5
            lsvProduccion.Columns.Add("T/D/P", 50, HorizontalAlignment.Left) '6
            lsvProduccion.Columns.Add("N° Documento", 95, HorizontalAlignment.Center) '7
            lsvProduccion.Columns.Add("Proveedor", 237, HorizontalAlignment.Left) '8
            lsvProduccion.Columns.Add("Tipo de Persona", 0, HorizontalAlignment.Left) '9
            lsvProduccion.Columns.Add("Importe (MN)", 90, HorizontalAlignment.Right) '10
            lsvProduccion.Columns.Add("T/C", 50, HorizontalAlignment.Center) '11
            lsvProduccion.Columns.Add("Importe (ME)", 90, HorizontalAlignment.Right) '12
            lsvProduccion.Columns.Add("Moneda", 50, HorizontalAlignment.Center) '13
            lsvProduccion.Columns.Add("TIPO", 50, HorizontalAlignment.Center) '14
            lsvProduccion.Columns.Add("Docs/Sust.", 0, HorizontalAlignment.Center) '15
            lsvProduccion.Columns.Add("Estado", 70, HorizontalAlignment.Center) '16

            For Each i As documentocompra In documentoCompraSA.GetListarComprasPorMes_CONT(año, mes)

                Dim n As New ListViewItem(i.idDocumento)
                n.UseItemStyleForSubItems = False
                If i.tipoCompra = TIPO_COMPRA.COMPRA_AL_CREDITO Then
                    n.SubItems.Add(i.tipoOperacion).BackColor = Color.Lavender
                ElseIf i.tipoCompra = TIPO_COMPRA.COMPRA_PAGADA Then
                    n.SubItems.Add(i.tipoOperacion).BackColor = Color.FromArgb(225, 240, 190)
                ElseIf i.tipoCompra = TIPO_COMPRA.NOTA_CREDITO Then
                    n.SubItems.Add(i.tipoOperacion).BackColor = Color.LavenderBlush
                ElseIf i.tipoCompra = TIPO_COMPRA.NOTA_DEBITO Then
                    n.SubItems.Add(i.tipoOperacion).BackColor = Color.LightYellow
                End If

                '    n.SubItems.Add(IIf(i.Destino = "CI", "COMPRA INTERNA", "COMPRA DIRECTA INTERNA"))
                n.SubItems.Add(FormatDateTime(i.fechaDoc, DateFormat.GeneralDate))
                n.SubItems.Add(i.tipoDoc)
                n.SubItems.Add(i.serie)
                n.SubItems.Add(i.numeroDoc)
                n.SubItems.Add(i.tipoDocEntidad)
                n.SubItems.Add(i.NroDocEntidad)
                n.SubItems.Add(i.NombreEntidad)
                n.SubItems.Add(IIf(i.TipoPersona = "N", "PERS.NATURAL", "PERS.JURIDICA"))
                n.SubItems.Add(FormatNumber(i.importeTotal, 2))
                n.SubItems.Add(FormatNumber(i.tcDolLoc, 2))
                n.SubItems.Add(FormatNumber(i.importeUS, 2))
                n.SubItems.Add(i.monedaDoc)
                n.SubItems.Add(i.tipoCompra)
                n.SubItems.Add("")
                If i.estadoPago = TIPO_COMPRA.PAGO.PAGADO Then
                    n.SubItems.Add("Pagado")
                ElseIf i.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO Then
                    n.SubItems.Add("En trámite")
                End If
                lsvProduccion.Items.Add(n)

            Next

            If lsvProduccion.Items.Count > 0 Then
                lsvProduccion.Focus()
                lsvProduccion.Items(0).Selected = True
                lsvProduccion.Items(0).Focused = True

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Public Sub ListaComprasPorDia()
    '    Dim documentoCompraSA As New DocumentoCompraSA
    '    Dim grupoActual As String = String.Empty
    '    Dim g As New ListViewGroup
    '    Try

    '        lsvProduccion.Columns.Clear()
    '        lsvProduccion.Items.Clear()
    '        lsvProduccion.Columns.Add("idDocumento", 0, HorizontalAlignment.Center) '0
    '        lsvProduccion.Columns.Add("T/OP", 50, HorizontalAlignment.Left) '1
    '        lsvProduccion.Columns.Add("Fecha emisión/pago", 155, HorizontalAlignment.Left) '2
    '        lsvProduccion.Columns.Add("C/P", 40, HorizontalAlignment.Left) '3
    '        lsvProduccion.Columns.Add("Serie", 59, HorizontalAlignment.Center) '4
    '        lsvProduccion.Columns.Add("N° Comprobante de pago", 146, HorizontalAlignment.Center) '5
    '        lsvProduccion.Columns.Add("T/D/P", 50, HorizontalAlignment.Left) '6
    '        lsvProduccion.Columns.Add("N° Documento", 95, HorizontalAlignment.Center) '7
    '        lsvProduccion.Columns.Add("Proveedor", 237, HorizontalAlignment.Left) '8
    '        lsvProduccion.Columns.Add("Tipo de Persona", 0, HorizontalAlignment.Left) '9
    '        lsvProduccion.Columns.Add("Importe (MN)", 90, HorizontalAlignment.Right) '10
    '        lsvProduccion.Columns.Add("T/C", 50, HorizontalAlignment.Center) '11
    '        lsvProduccion.Columns.Add("Importe (ME)", 90, HorizontalAlignment.Right) '12
    '        lsvProduccion.Columns.Add("Moneda", 50, HorizontalAlignment.Center) '13
    '        lsvProduccion.Columns.Add("TIPO", 50, HorizontalAlignment.Center) '14
    '        lsvProduccion.Columns.Add("Docs/Sust.", 0, HorizontalAlignment.Center) '15
    '        lsvProduccion.Columns.Add("Estado", 70, HorizontalAlignment.Center) '16

    '        For Each i As documentocompra In documentoCompraSA.GetListarComprasPorDia_CONT()

    '            Dim n As New ListViewItem(i.idDocumento)
    '            n.UseItemStyleForSubItems = False
    '            If i.tipoCompra = TIPO_COMPRA.COMPRA_AL_CREDITO Then
    '                n.SubItems.Add(i.tipoOperacion).BackColor = Color.Lavender
    '            ElseIf i.tipoCompra = TIPO_COMPRA.COMPRA_PAGADA Then
    '                n.SubItems.Add(i.tipoOperacion).BackColor = Color.FromArgb(225, 240, 190)
    '            ElseIf i.tipoCompra = TIPO_COMPRA.NOTA_CREDITO Then
    '                n.SubItems.Add(i.tipoOperacion).BackColor = Color.LavenderBlush
    '            ElseIf i.tipoCompra = TIPO_COMPRA.NOTA_DEBITO Then
    '                n.SubItems.Add(i.tipoOperacion).BackColor = Color.LightYellow
    '            End If

    '            '    n.SubItems.Add(IIf(i.Destino = "CI", "COMPRA INTERNA", "COMPRA DIRECTA INTERNA"))
    '            n.SubItems.Add(FormatDateTime(i.fechaDoc, DateFormat.GeneralDate))
    '            n.SubItems.Add(i.tipoDoc)
    '            n.SubItems.Add(i.serie)
    '            n.SubItems.Add(i.numeroDoc)
    '            n.SubItems.Add(i.tipoDocEntidad)
    '            n.SubItems.Add(i.NroDocEntidad)
    '            n.SubItems.Add(i.NombreEntidad)
    '            n.SubItems.Add(IIf(i.TipoPersona = "N", "PERS.NATURAL", "PERS.JURIDICA"))
    '            n.SubItems.Add(FormatNumber(i.importeTotal, 2))
    '            n.SubItems.Add(FormatNumber(i.tcDolLoc, 2))
    '            n.SubItems.Add(FormatNumber(i.importeUS, 2))
    '            n.SubItems.Add(i.monedaDoc)
    '            n.SubItems.Add(i.tipoCompra)
    '            n.SubItems.Add("")
    '            If i.estadoPago = TIPO_COMPRA.PAGO.PAGADO Then
    '                n.SubItems.Add("Pagado")
    '            ElseIf i.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO Then
    '                n.SubItems.Add("En trámite")
    '            End If
    '            lsvProduccion.Items.Add(n)
    '        Next

    '        If lsvProduccion.Items.Count > 0 Then
    '            lsvProduccion.Focus()
    '            lsvProduccion.Items(0).Selected = True
    '            lsvProduccion.Items(0).Focused = True

    '        End If

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub



    Sub ElimnarDocRadial()
        GFichaUsuarios = New GFichaUsuario
        If lsvProduccion.SelectedItems.Count > 0 Then
            If lsvProduccion.SelectedItems(0).SubItems(14).Text = TIPO_COMPRA.COMPRA_AL_CREDITO Then
                If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    RemoveCompraSimple(lsvProduccion.SelectedItems(0).SubItems(0).Text)
                    lsvProduccion.SelectedItems(0).Remove()
                    lblEstado.Image = My.Resources.ok4
                    lblEstado.Text = "Compra eliminada!"
                End If

            ElseIf lsvProduccion.SelectedItems(0).SubItems(14).Text = TIPO_COMPRA.COMPRA_DIRECTA_CON_RECEPCION Then
                If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    If TieneCuentaFinanciera(CInt(lsvProduccion.SelectedItems(0).SubItems(0).Text)) = True Then
                        RemoveCompra(lsvProduccion.SelectedItems(0).SubItems(0).Text)
                        lsvProduccion.SelectedItems(0).Remove()
                        lblEstado.Image = My.Resources.ok4
                        lblEstado.Text = "Compra eliminada!"
                    Else
                        lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
                        Timer1.Enabled = True
                        TiempoEjecutar(5)
                    End If
                End If
            ElseIf lsvProduccion.SelectedItems(0).SubItems(14).Text = TIPO_COMPRA.COMPRA_DIRECTA_SIN_RECEPCION Then
                If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    If TieneCuentaFinanciera(CInt(lsvProduccion.SelectedItems(0).SubItems(0).Text)) = True Then
                        EliminarCompraDirectaSinRecepcion(lsvProduccion.SelectedItems(0).SubItems(0).Text)
                        lsvProduccion.SelectedItems(0).Remove()
                        lblEstado.Image = My.Resources.ok4
                        lblEstado.Text = "Compra eliminada!"
                    Else
                        lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
                        Timer1.Enabled = True
                        TiempoEjecutar(5)
                    End If
                End If
            ElseIf lsvProduccion.SelectedItems(0).SubItems(14).Text = TIPO_COMPRA.NOTA_CREDITO Then
                If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    EliminarNota(lsvProduccion.SelectedItems(0).SubItems(0).Text)
                    lsvProduccion.SelectedItems(0).Remove()
                    lblEstado.Image = My.Resources.ok4
                    lblEstado.Text = "nota de crédito eliminada!"
                End If
            ElseIf lsvProduccion.SelectedItems(0).SubItems(14).Text = TIPO_COMPRA.NOTA_DEBITO Then
                If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    EliminarNotaDebito(lsvProduccion.SelectedItems(0).SubItems(0).Text)
                    lsvProduccion.SelectedItems(0).Remove()
                    lblEstado.Image = My.Resources.ok4
                    lblEstado.Text = "nota de débito eliminada!"
                End If
            End If
        End If
    End Sub

    Private Sub setRadialMenuLocation()
        Dim locationX As Integer = 0
        Dim locationY As Integer = 0
        locationX = (Cursor.Position.X + Me.rmCompra.Width / 8)
        If locationX + Me.rmCompra.Width > Screen.PrimaryScreen.Bounds.Width Then
            locationX = Screen.PrimaryScreen.Bounds.Width - Me.rmCompra.Width
        End If
        locationY = Cursor.Position.Y - Me.rmCompra.Height / 2
        If locationY + Me.rmCompra.Height > Screen.PrimaryScreen.Bounds.Height Then
            locationY = Screen.PrimaryScreen.Bounds.Height - Me.rmCompra.Height
        End If
        Dim location As New Point(locationX, locationY)
        Me.rmCompra.ShowRadialMenu(location)
        Me.rmCompra.PopupHost.Location = location
        If Me.rmCompra.PopupHost.Location.Y < 0 Then
            Me.rmCompra.PopupHost.Location = New Point(Me.rmCompra.PopupHost.Location.X, 0)
        End If
    End Sub

#Region "RAdial Menu"
    Sub InitializeRAdial()
        rmCompra.Icon = My.Resources.configuration_13194
        rmCompra.MenuIcon = My.Resources.configuration_13194

        Me.rmCompra.ParentControl = lsvProduccion
        Me.rmCompra.MenuVisibility = True
        Me.rmCompra.OuterRimThickness = 20
        '     Me.MinimumSize = Me.Size
        Me.rmCompra.DisplayStyle = Syncfusion.Windows.Forms.Tools.DisplayStyle.TextAboveImage

        Dim myImageNuevoCompra As System.Drawing.Image = My.Resources.icono_new_documento
        ImageList1.Images.Add(myImageNuevoCompra) '0

        Dim myImageEditCompra As System.Drawing.Image = My.Resources.icono_editar_compra
        ImageList1.Images.Add(myImageEditCompra) '01

        Dim myImageElminarDoc As System.Drawing.Image = My.Resources.icono_eliminar_compra
        ImageList1.Images.Add(myImageElminarDoc) '02

        Dim myImageNotasDoc As System.Drawing.Image = My.Resources.icono_Sel_nota
        ImageList1.Images.Add(myImageNotasDoc) '03

        Dim myImageTributo As System.Drawing.Image = My.Resources.icono_tributo
        ImageList1.Images.Add(myImageTributo) '04

        Dim myImageGuia As System.Drawing.Image = My.Resources.icono_guia2
        ImageList1.Images.Add(myImageGuia) '05

        Dim myImageCompraAlCredito As System.Drawing.Image = My.Resources.icono_compra_credito
        ImageList1.Images.Add(myImageCompraAlCredito) '06

        Dim myImageCompraAlContado As System.Drawing.Image = My.Resources.icono_compra_contado
        ImageList1.Images.Add(myImageCompraAlContado) '07

        'Dim myImageNotacredito As System.Drawing.Image = My.Resources.icono_tributo3
        'ImageList1.Images.Add(myImageNotacredito) '08



        ImageList1.ColorDepth = ColorDepth.Depth32Bit
        ImageList1.ImageSize = New Size(50, 50)


        rmCompra.ImageList = ImageList1
        rmNuevaCompra.ImageIndex = 0
        rmEditarCompra.ImageIndex = 1
        rmEliminarDoc.ImageIndex = 2
        rmNotas.ImageIndex = 3
        rmTributos.ImageIndex = 4
        rmRemision.ImageIndex = 5
        rmiCompraAlcredito.ImageIndex = 6
        rmiCompraAlContado.ImageIndex = 7

        Me.rmCompra.RimBackground = Color.FromArgb(177, 245, 247) '("#FFFFD2")
        '   Me.rmCompra.OuterArcColor = Color.FromArgb(229, 229, 236) '("#FFFFD2")
    End Sub
#End Region

    Private Sub ObtenerListaGuias(intIDDOcumentoCompra As Integer)
        Dim documentoGuiaSA As New DocumentoGuiaSA
        Dim tablaSA As New tablaDetalleSA
        KryptonDataGridView1.Rows.Clear()
        For Each i In documentoGuiaSA.ListaGuiasPorCompra(intIDDOcumentoCompra)
            KryptonDataGridView1.Rows.Add(i.idDocumento, i.fechaDoc, tablaSA.GetUbicarTablaID(10, i.tipoDoc).descripcion, i.serie, i.numeroDoc)
        Next
    End Sub

    Private Sub ObtenerObligaciones(intIdDocCompra As Integer)
        Dim docObligacionSA As New DocumentoObligacionTributariaSA
        dgvObligacion.Rows.Clear()
        For Each i As documentoObligacionTributaria In docObligacionSA.ListadoTributoPorIdDocumentoOrigen(intIdDocCompra)
            dgvObligacion.Rows.Add(i.idDocumento, i.tipoTributo, i.fechaDoc, i.serieDoc, i.numeroDoc, i.NomProveedor, i.moneda, i.porcTributario,
                                   0, 0)
        Next
    End Sub

    Private Sub EliminarTributo(intIdDocumento As Integer)
        Dim docTributoSA As New DocumentoObligacionTributariaSA

        docTributoSA.EliminarObligacion(intIdDocumento)
        lblEstado.Text = "Tributo eliminado correctamente!"
        lblEstado.Image = My.Resources.ok4
    End Sub
    Public Function EsEditable(intIdDocumentoCompra As Integer) As Boolean
        Dim documentoCompraSA As New DocumentoCompraSA
        Dim compra As New Integer
        Dim valorEdicion As Boolean = False

        Try
            compra = documentoCompraSA.ValidarEstadoManipulacion(intIdDocumentoCompra)
            If compra > 0 Then
                valorEdicion = False
            Else
                valorEdicion = True
            End If

        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try
        Return valorEdicion
    End Function

    Public Sub RemoveCompraSimple(IntIdDocumento As Integer)
        Dim almacenSA As New almacenSA
        Dim almacen As New almacen
        Dim documentoSA As New DocumentoSA
        Dim documentoDetalleSA As New DocumentoCompraDetalleSA
        Dim objDocumento As New documento
        Dim objNuevo As New totalesAlmacen
        Dim ListaTotales As New List(Of totalesAlmacen)

        With objDocumento
            .idDocumento = IntIdDocumento
        End With
        For Each i In documentoDetalleSA.UbicarDocumentoCompraDetalle(IntIdDocumento)
            If Not IsNothing(i.almacenRef) Then

                almacen = almacenSA.GetUbicar_almacenPorID(i.almacenRef)
                If Not IsNothing(almacen) Then
                    If Not almacen.tipo = "AV" Then
                        objNuevo = New totalesAlmacen
                        objNuevo.SecuenciaDetalle = i.secuencia
                        objNuevo.idEmpresa = Gempresas.IdEmpresaRuc
                        objNuevo.idEstablecimiento = almacen.idEstablecimiento
                        objNuevo.idAlmacen = almacen.idAlmacen
                        objNuevo.origenRecaudo = i.destino
                        objNuevo.idItem = i.idItem
                        objNuevo.TipoDoc = lsvProduccion.SelectedItems(0).SubItems(3).Text

                        Select Case lsvProduccion.SelectedItems(0).SubItems(3).Text
                            Case "03", "02"
                                objNuevo.importeSoles = i.importe
                                objNuevo.importeDolares = i.importeUS
                            Case Else
                                Select Case i.destino
                                    Case "1"
                                        objNuevo.importeSoles = i.montokardex
                                        objNuevo.importeDolares = i.montokardexUS
                                    Case Else
                                        objNuevo.importeSoles = i.importe
                                        objNuevo.importeDolares = i.importeUS
                                End Select
                        End Select

                        objNuevo.cantidad = i.monto1
                        objNuevo.precioUnitarioCompra = i.precioUnitario

                        objNuevo.montoIsc = i.montoIsc
                        objNuevo.montoIscUS = i.montoIscUS

                        ListaTotales.Add(objNuevo)
                    ElseIf almacen.tipo = "AV" Then
                        objNuevo = New totalesAlmacen
                        objNuevo.SecuenciaDetalle = i.secuencia
                        objNuevo.idEmpresa = Gempresas.IdEmpresaRuc
                        objNuevo.idEstablecimiento = almacen.idEstablecimiento
                        objNuevo.idAlmacen = almacen.idAlmacen
                        objNuevo.origenRecaudo = i.destino
                        objNuevo.idItem = i.idItem
                        objNuevo.TipoDoc = lsvProduccion.SelectedItems(0).SubItems(3).Text

                        Select Case lsvProduccion.SelectedItems(0).SubItems(3).Text
                            Case "03", "02"
                                objNuevo.importeSoles = i.importe
                                objNuevo.importeDolares = i.importeUS
                            Case Else
                                Select Case i.destino
                                    Case "1"
                                        objNuevo.importeSoles = i.montokardex
                                        objNuevo.importeDolares = i.montokardexUS
                                    Case Else
                                        objNuevo.importeSoles = i.importe
                                        objNuevo.importeDolares = i.importeUS
                                End Select
                        End Select

                        objNuevo.cantidad = i.monto1
                        objNuevo.precioUnitarioCompra = i.precioUnitario

                        objNuevo.montoIsc = i.montoIsc
                        objNuevo.montoIscUS = i.montoIscUS

                        ListaTotales.Add(objNuevo)
                    End If
                End If




            End If

        Next
        documentoSA.DeleteDocumento(objDocumento, ListaTotales)
    End Sub

    Public Sub RemoveCompra(IntIdDocumento As Integer)
        Dim almacenSA As New almacenSA
        Dim almacen As New almacen
        Dim documentoSA As New DocumentoSA
        Dim documentoDetalleSA As New DocumentoCompraDetalleSA
        Dim objDocumento As New documento
        Dim objNuevo As New totalesAlmacen
        Dim ListaTotales As New List(Of totalesAlmacen)

        With objDocumento
            .idDocumento = IntIdDocumento
            .usuarioActualizacion = GFichaUsuarios.IdCajaUsuario
            .tipoDoc = TIPO_COMPRA.COMPRA_PAGADA
        End With
        For Each i In documentoDetalleSA.UbicarDocumentoCompraDetalle(IntIdDocumento)
            If Not IsNothing(i.almacenRef) Then

                almacen = almacenSA.GetUbicar_almacenPorID(i.almacenRef)
                If Not IsNothing(almacen) Then
                    If Not almacen.tipo = "AV" Then
                        objNuevo = New totalesAlmacen
                        objNuevo.SecuenciaDetalle = i.secuencia
                        objNuevo.idEmpresa = Gempresas.IdEmpresaRuc
                        objNuevo.idEstablecimiento = almacen.idEstablecimiento
                        objNuevo.idAlmacen = almacen.idAlmacen
                        objNuevo.origenRecaudo = i.destino
                        objNuevo.idItem = i.idItem
                        objNuevo.TipoDoc = lsvProduccion.SelectedItems(0).SubItems(3).Text

                        Select Case lsvProduccion.SelectedItems(0).SubItems(3).Text
                            Case "03", "02"
                                objNuevo.importeSoles = i.importe
                                objNuevo.importeDolares = i.importeUS
                            Case Else
                                Select Case i.destino
                                    Case "1"
                                        objNuevo.importeSoles = i.montokardex
                                        objNuevo.importeDolares = i.montokardexUS
                                    Case Else
                                        objNuevo.importeSoles = i.importe
                                        objNuevo.importeDolares = i.importeUS
                                End Select
                        End Select

                        objNuevo.cantidad = i.monto1
                        objNuevo.precioUnitarioCompra = i.precioUnitario

                        objNuevo.montoIsc = i.montoIsc
                        objNuevo.montoIscUS = i.montoIscUS

                        ListaTotales.Add(objNuevo)

                    End If
                End If

            End If

        Next
        documentoSA.DeleteDocumentoPagado(objDocumento, ListaTotales)
    End Sub

    Public Sub EliminarCompraDirectaSinRecepcion(IntIdDocumento As Integer)
        Dim almacenSA As New almacenSA
        Dim almacen As New almacen
        Dim documentoSA As New DocumentoSA
        Dim documentoDetalleSA As New DocumentoCompraDetalleSA
        Dim objDocumento As New documento
        Dim objNuevo As New totalesAlmacen
        Dim ListaTotales As New List(Of totalesAlmacen)

        With objDocumento
            .idDocumento = IntIdDocumento
            .usuarioActualizacion = GFichaUsuarios.IdCajaUsuario
            .tipoDoc = TIPO_COMPRA.COMPRA_DIRECTA_SIN_RECEPCION
        End With
        For Each i In documentoDetalleSA.UbicarDocumentoCompraDetalle(IntIdDocumento)
            If Not IsNothing(i.almacenRef) Then

                almacen = almacenSA.GetUbicar_almacenPorID(i.almacenRef)
                If Not IsNothing(almacen) Then
                    '      If Not almacen.tipo = "AV" Then
                    objNuevo = New totalesAlmacen
                    objNuevo.SecuenciaDetalle = i.secuencia
                    objNuevo.idEmpresa = Gempresas.IdEmpresaRuc
                    objNuevo.idEstablecimiento = almacen.idEstablecimiento
                    objNuevo.idAlmacen = almacen.idAlmacen
                    objNuevo.origenRecaudo = i.destino
                    objNuevo.idItem = i.idItem
                    objNuevo.TipoDoc = lsvProduccion.SelectedItems(0).SubItems(3).Text

                    Select Case lsvProduccion.SelectedItems(0).SubItems(3).Text
                        Case "03", "02"
                            objNuevo.importeSoles = i.importe
                            objNuevo.importeDolares = i.importeUS
                        Case Else
                            Select Case i.destino
                                Case "1"
                                    objNuevo.importeSoles = i.montokardex
                                    objNuevo.importeDolares = i.montokardexUS
                                Case Else
                                    objNuevo.importeSoles = i.importe
                                    objNuevo.importeDolares = i.importeUS
                            End Select
                    End Select

                    objNuevo.cantidad = i.monto1
                    objNuevo.precioUnitarioCompra = i.precioUnitario

                    objNuevo.montoIsc = i.montoIsc
                    objNuevo.montoIscUS = i.montoIscUS

                    ListaTotales.Add(objNuevo)

                    '     End If
                End If

            End If

        Next
        documentoSA.DeleteCompraDirectaSinRecepcion(objDocumento, ListaTotales)
    End Sub

    Public Sub EliminarNota(IntIdDocumento As Integer)
        Dim almacenSA As New almacenSA
        Dim almacen As New almacen
        Dim documentoSA As New DocumentoSA

        Dim documentoDetalleSA As New DocumentoCompraDetalleSA
        Dim objDocumento As New documento
        Dim DOcumentoCompraSA As New DocumentoCompraSA
        Dim DOcumentoCompra As New documentocompra
        Dim objNuevo As New totalesAlmacen
        Dim ListaTotales As New List(Of totalesAlmacen)

        With objDocumento
            .idDocumento = IntIdDocumento
        End With
        DOcumentoCompra = DOcumentoCompraSA.UbicarDocumentoCompra(IntIdDocumento)
        objDocumento.documentocompra = DOcumentoCompra
        For Each i In documentoDetalleSA.UbicarDocumentoCompraDetalle(IntIdDocumento)
            If Not IsNothing(i.almacenRef) Then

                almacen = almacenSA.GetUbicar_almacenPorID(i.almacenRef)
                If Not IsNothing(almacen) Then
                    If Not almacen.tipo = "AV" Then
                        objNuevo = New totalesAlmacen
                        objNuevo.SecuenciaDetalle = i.secuencia
                        objNuevo.idEmpresa = Gempresas.IdEmpresaRuc
                        objNuevo.idEstablecimiento = almacen.idEstablecimiento
                        objNuevo.idAlmacen = almacen.idAlmacen
                        objNuevo.origenRecaudo = i.destino
                        objNuevo.idItem = i.idItem
                        objNuevo.TipoDoc = lsvProduccion.SelectedItems(0).SubItems(3).Text

                        Select Case DOcumentoCompra.sustentado
                            Case Notas_Credito.DEV_EXISTENCIA
                                objNuevo.cantidad = i.monto1
                                objNuevo.importeSoles = i.montokardex
                                objNuevo.importeDolares = i.montokardexUS

                            Case Notas_Credito.DR_REDUCCION_COSTOS
                                objNuevo.cantidad = 0
                                objNuevo.importeSoles = i.montokardex
                                objNuevo.importeDolares = i.montokardexUS

                            Case Notas_Credito.DR_BENEFICIO

                            Case Notas_Credito.ERR_PRECIO
                                objNuevo.cantidad = 0
                                objNuevo.importeSoles = i.montokardex
                                objNuevo.importeDolares = i.montokardexUS

                            Case Notas_Credito.ERR_CANTIDAD
                                objNuevo.cantidad = i.monto1
                                objNuevo.importeSoles = 0
                                objNuevo.importeDolares = 0

                            Case Notas_Credito.BOF_REDUC_COSTO_IGUAL_COMPRA
                                objNuevo.cantidad = CDec(i.monto1) * -1
                                objNuevo.importeSoles = 0
                                objNuevo.importeDolares = 0

                            Case Notas_Credito.BOF_REDUC_COSTO_DISTINTO_COMPRA

                            Case Notas_Credito.BOF_BENEFICIO_TERCEROS

                        End Select

                        objNuevo.precioUnitarioCompra = i.precioUnitario
                        objNuevo.montoIsc = i.montoIsc
                        objNuevo.montoIscUS = i.montoIscUS

                        ListaTotales.Add(objNuevo)

                    End If
                End If

            End If

        Next
        documentoSA.DeleteNotas(objDocumento, ListaTotales)
    End Sub

    Public Sub EliminarNotaDebito(IntIdDocumento As Integer)
        Dim almacenSA As New almacenSA
        Dim almacen As New almacen
        Dim documentoSA As New DocumentoSA

        Dim documentoDetalleSA As New DocumentoCompraDetalleSA
        Dim objDocumento As New documento
        Dim DOcumentoCompraSA As New DocumentoCompraSA
        Dim DOcumentoCompra As New documentocompra
        Dim objNuevo As New totalesAlmacen
        Dim ListaTotales As New List(Of totalesAlmacen)

        With objDocumento
            .idDocumento = IntIdDocumento
        End With
        DOcumentoCompra = DOcumentoCompraSA.UbicarDocumentoCompra(IntIdDocumento)
        objDocumento.documentocompra = DOcumentoCompra
        For Each i In documentoDetalleSA.UbicarDocumentoCompraDetalle(IntIdDocumento)
            If Not IsNothing(i.almacenRef) Then

                almacen = almacenSA.GetUbicar_almacenPorID(i.almacenRef)
                If Not IsNothing(almacen) Then
                    If Not almacen.tipo = "AV" Then
                        objNuevo = New totalesAlmacen
                        objNuevo.SecuenciaDetalle = i.secuencia
                        objNuevo.idEmpresa = Gempresas.IdEmpresaRuc
                        objNuevo.idEstablecimiento = almacen.idEstablecimiento
                        objNuevo.idAlmacen = almacen.idAlmacen
                        objNuevo.origenRecaudo = i.destino
                        objNuevo.idItem = i.idItem
                        objNuevo.TipoDoc = lsvProduccion.SelectedItems(0).SubItems(3).Text
                        objNuevo.cantidad = 0
                        objNuevo.importeSoles = i.montokardex
                        objNuevo.importeDolares = i.montokardexUS
                        objNuevo.precioUnitarioCompra = i.precioUnitario
                        objNuevo.montoIsc = i.montoIsc
                        objNuevo.montoIscUS = i.montoIscUS

                        ListaTotales.Add(objNuevo)

                    End If
                End If

            End If

        Next
        documentoSA.DeleteNotasDebito(objDocumento, ListaTotales)
    End Sub

    Public Sub ListaCompras(strPeriodo As String)
        Dim documentoCompraSA As New DocumentoCompraSA
        Dim grupoActual As String = String.Empty
        Dim g As New ListViewGroup
        Try
            lsvProduccion.Columns.Clear()
            lsvProduccion.Items.Clear()
            lsvProduccion.Columns.Add("idDocumento", 0, HorizontalAlignment.Center) '0
            lsvProduccion.Columns.Add("T/OP", 50, HorizontalAlignment.Left) '1
            lsvProduccion.Columns.Add("Fecha emisión/pago", 155, HorizontalAlignment.Left) '2
            lsvProduccion.Columns.Add("C/P", 40, HorizontalAlignment.Left) '3
            lsvProduccion.Columns.Add("Serie", 59, HorizontalAlignment.Center) '4
            lsvProduccion.Columns.Add("N° Comprobante de pago", 146, HorizontalAlignment.Center) '5
            lsvProduccion.Columns.Add("T/D/P", 50, HorizontalAlignment.Left) '6
            lsvProduccion.Columns.Add("N° Documento", 95, HorizontalAlignment.Center) '7
            lsvProduccion.Columns.Add("Proveedor", 237, HorizontalAlignment.Left) '8
            lsvProduccion.Columns.Add("Tipo de Persona", 0, HorizontalAlignment.Left) '9
            lsvProduccion.Columns.Add("Importe (MN)", 90, HorizontalAlignment.Right) '10
            lsvProduccion.Columns.Add("T/C", 50, HorizontalAlignment.Center) '11
            lsvProduccion.Columns.Add("Importe (ME)", 90, HorizontalAlignment.Right) '12
            lsvProduccion.Columns.Add("Moneda", 50, HorizontalAlignment.Center) '13
            lsvProduccion.Columns.Add("TIPO", 50, HorizontalAlignment.Center) '14
            lsvProduccion.Columns.Add("Docs/Sust.", 0, HorizontalAlignment.Center) '15
            lsvProduccion.Columns.Add("Estado", 70, HorizontalAlignment.Center) '16

            Select Case ModuloAppx
                Case ModuloSistema.PLANEAMIENTO
                    For Each i As documentocompra In documentoCompraSA.GetListarComprasPorPeriodoGeneral(GProyectos.IdProyectoActividad, strPeriodo)

                        Dim n As New ListViewItem(i.idDocumento)
                        n.UseItemStyleForSubItems = False
                        If i.tipoCompra = TIPO_COMPRA.COMPRA_AL_CREDITO Then
                            n.SubItems.Add(i.tipoOperacion).BackColor = Color.Lavender
                        ElseIf i.tipoCompra = TIPO_COMPRA.COMPRA_PAGADA Then
                            n.SubItems.Add(i.tipoOperacion).BackColor = Color.FromArgb(225, 240, 190)
                        ElseIf i.tipoCompra = TIPO_COMPRA.NOTA_CREDITO Then
                            n.SubItems.Add(i.tipoOperacion).BackColor = Color.LavenderBlush
                        ElseIf i.tipoCompra = TIPO_COMPRA.NOTA_DEBITO Then
                            n.SubItems.Add(i.tipoOperacion).BackColor = Color.LightYellow
                        End If

                        '    n.SubItems.Add(IIf(i.Destino = "CI", "COMPRA INTERNA", "COMPRA DIRECTA INTERNA"))
                        n.SubItems.Add(FormatDateTime(i.fechaDoc, "dd/MM/yyyy hh:mm:ss"))
                        n.SubItems.Add(i.tipoDoc)
                        n.SubItems.Add(i.serie)
                        n.SubItems.Add(i.numeroDoc)
                        n.SubItems.Add(i.tipoDocEntidad)
                        n.SubItems.Add(i.NroDocEntidad)
                        n.SubItems.Add(i.NombreEntidad)
                        n.SubItems.Add(IIf(i.TipoPersona = "N", "PERS.NATURAL", "PERS.JURIDICA"))
                        n.SubItems.Add(FormatNumber(i.importeTotal, 2))
                        n.SubItems.Add(FormatNumber(i.tcDolLoc, 2))
                        n.SubItems.Add(FormatNumber(i.importeUS, 2))
                        n.SubItems.Add(i.monedaDoc)
                        n.SubItems.Add(i.tipoCompra)
                        n.SubItems.Add(i.idPadre)
                        If i.estadoPago = TIPO_COMPRA.PAGO.PAGADO Then
                            n.SubItems.Add("Pagado")
                        ElseIf i.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO Then
                            n.SubItems.Add("En trámite")
                        End If
                        lsvProduccion.Items.Add(n)

                    Next
                Case Else

                    For Each i As documentocompra In documentoCompraSA.GetListarComprasPorPeriodoGeneral_CONT(GEstableciento.IdEstablecimiento, strPeriodo)

                        Dim n As New ListViewItem(i.idDocumento)
                        n.UseItemStyleForSubItems = False
                        If i.tipoCompra = TIPO_COMPRA.COMPRA_AL_CREDITO Then
                            n.SubItems.Add(i.tipoOperacion).BackColor = Color.Lavender
                        ElseIf i.tipoCompra = TIPO_COMPRA.COMPRA_DIRECTA_CON_RECEPCION Then
                            n.SubItems.Add(i.tipoOperacion).BackColor = Color.FromArgb(225, 240, 190)
                        ElseIf i.tipoCompra = TIPO_COMPRA.COMPRA_DIRECTA_SIN_RECEPCION Then
                            n.SubItems.Add(i.tipoOperacion).BackColor = Color.FromArgb(225, 240, 190)
                        ElseIf i.tipoCompra = TIPO_COMPRA.NOTA_CREDITO Then
                            n.SubItems.Add(i.tipoOperacion).BackColor = Color.LavenderBlush
                        ElseIf i.tipoCompra = TIPO_COMPRA.NOTA_DEBITO Then
                            n.SubItems.Add(i.tipoOperacion).BackColor = Color.LightYellow
                        End If

                        '    n.SubItems.Add(IIf(i.Destino = "CI", "COMPRA INTERNA", "COMPRA DIRECTA INTERNA"))
                        n.SubItems.Add(FormatDateTime(i.fechaDoc, DateFormat.GeneralDate))
                        n.SubItems.Add(i.tipoDoc)
                        n.SubItems.Add(i.serie)
                        n.SubItems.Add(i.numeroDoc)
                        n.SubItems.Add(i.tipoDocEntidad)
                        n.SubItems.Add(i.NroDocEntidad)
                        n.SubItems.Add(i.NombreEntidad)
                        n.SubItems.Add(IIf(i.TipoPersona = "N", "PERS.NATURAL", "PERS.JURIDICA"))
                        n.SubItems.Add(FormatNumber(i.importeTotal, 2))
                        n.SubItems.Add(FormatNumber(i.tcDolLoc, 2))
                        n.SubItems.Add(FormatNumber(i.importeUS, 2))
                        n.SubItems.Add(i.monedaDoc)
                        n.SubItems.Add(i.tipoCompra)
                        n.SubItems.Add(IIf(IsNothing(i.idPadre), String.Empty, i.idPadre))
                        If i.estadoPago = TIPO_COMPRA.PAGO.PAGADO Then
                            n.SubItems.Add("Pagado")
                        ElseIf i.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO Then
                            n.SubItems.Add("En trámite")
                        End If
                        lsvProduccion.Items.Add(n)

                    Next
            End Select

            If lsvProduccion.Items.Count > 0 Then
                lsvProduccion.Focus()
                lsvProduccion.Items(0).Selected = True
                lsvProduccion.Items(0).Focused = True

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub UbicarNotasPorIdPadre(intIdDocumentoPadre As Integer)
        Dim documentocompraSA As New DocumentoCompraSA
        Dim movimientostr As String = Nothing
        dgvNotaCredito.Rows.Clear()
        dgvNotaDebito.Rows.Clear()

        For Each i In documentocompraSA.GetListarNotasPorIdCompraPadre(intIdDocumentoPadre, TIPO_COMPRA.NOTA_CREDITO)
            Select Case i.sustentado
                Case Notas_Credito.DEV_EXISTENCIA
                    movimientostr = "DEVOLUCION DE EXISTENCIA"

                Case Notas_Credito.DR_REDUCCION_COSTOS
                    movimientostr = "REDUCCION DE COSTOS"

                Case Notas_Credito.DR_BENEFICIO
                    movimientostr = "BENEFICIO"

                Case Notas_Credito.ERR_PRECIO
                    movimientostr = "ERROR EN PRECIO"

                Case Notas_Credito.ERR_CANTIDAD
                    movimientostr = "ERROR EN CANTIDAD"

                Case Notas_Credito.BOF_REDUC_COSTO_IGUAL_COMPRA
                    movimientostr = "BONIF.: REDUCCION DE COSTO IGUAL AL COMPRADO"

                Case Notas_Credito.BOF_REDUC_COSTO_DISTINTO_COMPRA
                    movimientostr = "BONIF.: REDUCCION DE COSTO DISTINTO AL COMPRADO"

                Case Notas_Credito.BOF_BENEFICIO_TERCEROS
                    movimientostr = "BONIF.: BENFICIO DE TERCEROS"
            End Select
            dgvNotaCredito.Rows.Add(i.idDocumento, i.fechaDoc, movimientostr, i.serie, i.numeroDoc, i.importeTotal, i.importeUS)
        Next

        For Each i In documentocompraSA.GetListarNotasPorIdCompraPadre(intIdDocumentoPadre, TIPO_COMPRA.NOTA_DEBITO)
            dgvNotaDebito.Rows.Add(i.idDocumento, i.fechaDoc, i.serie, i.numeroDoc, i.importeTotal, i.importeUS)
        Next

        '  ggNotacRedito.TableDescriptor.Columns.Add("")
    End Sub
    Private FileName As String = "Customers2.xml"
    Private Sub ExportarNotas(intIdDocumentoPadre As Integer, strTipoNota As String)
        Dim documentocompraSA As New DocumentoCompraSA
        Dim listaConsulta As New List(Of documentocompra)

        listaConsulta = documentocompraSA.GetListarNotasPorIdCompraPadre(intIdDocumentoPadre, strTipoNota)

        Dim customers = _
            From customer In listaConsulta _
            Order By customer.fechaDoc _
            Select <Row>
                       <Cell><Data ss:Type="String"><%= customer.fechaDoc %></Data></Cell>
                       <Cell><Data ss:Type="String"><%= customer.serie %></Data></Cell>
                       <Cell><Data ss:Type="String"><%= customer.numeroDoc %></Data></Cell>
                       <Cell><Data ss:Type="String"><%= customer.importeTotal %></Data></Cell>
                       <Cell><Data ss:Type="String"><%= customer.importeUS %></Data></Cell>
                   </Row>

        Dim sheet = <?xml version="1.0"?>
                    <?mso-application progid="Excel.Sheet"?>
                    <Workbook xmlns="urn:schemas-microsoft-com:office:spreadsheet"
                        xmlns:o="urn:schemas-microsoft-com:office:office"
                        xmlns:x="urn:schemas-microsoft-com:office:excel"
                        xmlns:ss="urn:schemas-microsoft-com:office:spreadsheet"
                        xmlns:html="http://www.w3.org/TR/REC-html40">
                        <DocumentProperties xmlns="urn:schemas-microsoft-com:office:office">
                            <Author>MSADMIN</Author>
                            <LastAuthor>MSADMIN</LastAuthor>
                            <Created>2007-10-23T23:40:11Z</Created>
                            <Company>Microsoft</Company>
                            <Version>12.00</Version>
                        </DocumentProperties>
                        <ExcelWorkbook xmlns="urn:schemas-microsoft-com:office:excel">
                            <WindowHeight>6600</WindowHeight>
                            <WindowWidth>12255</WindowWidth>
                            <WindowTopX>0</WindowTopX>
                            <WindowTopY>60</WindowTopY>
                            <ProtectStructure>False</ProtectStructure>
                            <ProtectWindows>False</ProtectWindows>
                        </ExcelWorkbook>
                        <Styles>
                            <Style ss:ID="Default" ss:Name="Normal">
                                <Alignment ss:Vertical="Bottom"/>
                                <Borders/>
                                <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"/>
                                <Interior/>
                                <NumberFormat/>
                                <Protection/>
                            </Style>
                            <Style ss:ID="s62">
                                <Font ss:FontName="Calibri" x:Family="Swiss" ss:Size="11" ss:Color="#000000"
                                    ss:Bold="1"/>
                            </Style>
                        </Styles>
                        <Worksheet ss:Name="Sheet1">
                            <Table ss:ExpandedColumnCount="5" ss:ExpandedRowCount=<%= customers.Count + 1 %> x:FullColumns="1"
                                x:FullRows="1" ss:DefaultRowHeight="15">
                                <Row ss:StyleID="s62">
                                    <Cell><Data ss:Type="String">Fecha</Data></Cell>
                                    <Cell><Data ss:Type="String">Serie</Data></Cell>
                                    <Cell><Data ss:Type="String">Número</Data></Cell>
                                    <Cell><Data ss:Type="String">Importe mn.</Data></Cell>
                                    <Cell><Data ss:Type="String">Importe me.</Data></Cell>
                                </Row>
                                <%= customers %>
                            </Table>
                            <WorksheetOptions xmlns="urn:schemas-microsoft-com:office:excel">
                                <PageSetup>
                                    <Header x:Margin="0.3"/>
                                    <Footer x:Margin="0.3"/>
                                    <PageMargins x:Bottom="0.75" x:Left="0.7" x:Right="0.7" x:Top="0.75"/>
                                </PageSetup>
                                <Print>
                                    <ValidPrinterInfo/>
                                    <HorizontalResolution>300</HorizontalResolution>
                                    <VerticalResolution>300</VerticalResolution>
                                </Print>
                                <Selected/>
                                <Panes>
                                    <Pane>
                                        <Number>3</Number>
                                        <ActiveCol>2</ActiveCol>
                                    </Pane>
                                </Panes>
                                <ProtectObjects>False</ProtectObjects>
                                <ProtectScenarios>False</ProtectScenarios>
                            </WorksheetOptions>
                        </Worksheet>
                        <Worksheet ss:Name="Sheet2">
                            <Table ss:ExpandedColumnCount="1" ss:ExpandedRowCount="1" x:FullColumns="1"
                                x:FullRows="1" ss:DefaultRowHeight="15">
                            </Table>
                            <WorksheetOptions xmlns="urn:schemas-microsoft-com:office:excel">
                                <PageSetup>
                                    <Header x:Margin="0.3"/>
                                    <Footer x:Margin="0.3"/>
                                    <PageMargins x:Bottom="0.75" x:Left="0.7" x:Right="0.7" x:Top="0.75"/>
                                </PageSetup>
                                <ProtectObjects>False</ProtectObjects>
                                <ProtectScenarios>False</ProtectScenarios>
                            </WorksheetOptions>
                        </Worksheet>
                        <Worksheet ss:Name="Sheet3">
                            <Table ss:ExpandedColumnCount="1" ss:ExpandedRowCount="1" x:FullColumns="1"
                                x:FullRows="1" ss:DefaultRowHeight="15">
                            </Table>
                            <WorksheetOptions xmlns="urn:schemas-microsoft-com:office:excel">
                                <PageSetup>
                                    <Header x:Margin="0.3"/>
                                    <Footer x:Margin="0.3"/>
                                    <PageMargins x:Bottom="0.75" x:Left="0.7" x:Right="0.7" x:Top="0.75"/>
                                </PageSetup>
                                <ProtectObjects>False</ProtectObjects>
                                <ProtectScenarios>False</ProtectScenarios>
                            </WorksheetOptions>
                        </Worksheet>
                    </Workbook>

        sheet.Save(Me.FileName)
        Process.Start("Excel.exe", Me.FileName)
    End Sub
#End Region

    Private Sub ToolStripButton7_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton7.Click
        'frmPMO.Panel3.Width = 249
        '  Me.Visible = False
        Dispose()
    End Sub

    Private Sub frmMantenimientoComprasPagadas_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed

    End Sub

    Private Sub frmMasterCompras_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '  Dispose()
    End Sub

    Private Sub AbrirToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles AbrirToolStripButton.Click
        Me.Cursor = Cursors.WaitCursor
        Dim documentoCompraSA As New DocumentoCompraDetalleSA
        GConfiguracion = New GConfiguracionModulo
        If lsvProduccion.SelectedItems.Count > 0 Then
            If lsvProduccion.SelectedItems(0).SubItems(14).Text = TIPO_COMPRA.COMPRA_AL_CREDITO Then
                '  If EsEditable(lsvProduccion.SelectedItems(0).SubItems(0).Text) = True Then
                'With frmCompraEjecutada
                '    If documentoCompraSA.TieneItemsEnAV(lsvProduccion.SelectedItems(0).SubItems(0).Text) = True Then
                '        .gbxGuias.Visible = False
                '    Else
                '        .gbxGuias.Visible = True
                '    End If
                '    .txtFechaComprobante.ShowUpDown = True
                '    .Width = 925
                '    .Height = 521
                '    .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                '    .UbicarDocumento(lsvProduccion.SelectedItems(0).SubItems(0).Text)
                '    .StartPosition = FormStartPosition.CenterParent
                '    .ShowDialog()
                'End With
                'Else
                '    lblEstado.Text = "No se puede editar, utilice una nota de crédito/débito"
                '    lblEstado.Image = My.Resources.warning2
                'End If

            ElseIf lsvProduccion.SelectedItems(0).SubItems(14).Text = TIPO_COMPRA.COMPRA_PAGADA Then
                '   If EsEditable(lsvProduccion.SelectedItems(0).SubItems(0).Text) = True Then
                'With frmCompraPagada
                '    .txtFechaComprobante.ShowUpDown = True
                '    .Width = 925
                '    .Height = 521
                '    .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                '    .UbicarDocumento(lsvProduccion.SelectedItems(0).SubItems(0).Text)
                '    .StartPosition = FormStartPosition.CenterParent
                '    .ShowDialog()
                'End With
                'Else
                '    lblEstado.Text = "No se puede editar, utilice una nota de crédito/débito"
                '    lblEstado.Image = My.Resources.warning2
                'End If
            ElseIf lsvProduccion.SelectedItems(0).SubItems(14).Text = TIPO_COMPRA.NOTA_CREDITO Then
                'With frmNotaCredito
                '    .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                '    .UbicarDocumento(lsvProduccion.SelectedItems(0).SubItems(0).Text)
                '    .StartPosition = FormStartPosition.CenterParent
                '    .ShowDialog()
                'End With
            ElseIf lsvProduccion.SelectedItems(0).SubItems(14).Text = TIPO_COMPRA.NOTA_DEBITO Then
                'With frmNotaDebito
                '    .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                '    .UbicarDocumento(lsvProduccion.SelectedItems(0).SubItems(0).Text)
                '    .StartPosition = FormStartPosition.CenterParent
                '    .ShowDialog()
                'End With
            End If
            lsvProduccion.SelectedItems(0).Selected = True
            lsvProduccion.SelectedItems(0).Focused = True
            lsvProduccion.FocusedItem.EnsureVisible()
            If ExpandCollapsePanel1.IsExpanded Then
                ObtenerObligaciones(lsvProduccion.SelectedItems(0).SubItems(0).Text)
            End If
            If EXGuias.IsExpanded = True Then
                ObtenerListaGuias(lsvProduccion.SelectedItems(0).SubItems(0).Text)
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub GuardarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles GuardarToolStripButton.Click
        ElimnarDocRadial()
    End Sub

    Private Sub cboPeriodo_Click(sender As System.Object, e As System.EventArgs) Handles cboPeriodo.Click

    End Sub

    Private Sub cboPeriodo_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboPeriodo.SelectedIndexChanged
        Select Case cboPeriodo.Text
            Case "ENERO"
                lblPerido.Text = "01" & "/" & PeriodoGeneral
            Case "FEBRERO"
                lblPerido.Text = "02" & "/" & PeriodoGeneral
            Case "MARZO"
                lblPerido.Text = "03" & "/" & PeriodoGeneral
            Case "ABRIL"
                lblPerido.Text = "04" & "/" & PeriodoGeneral
            Case "MAYO"
                lblPerido.Text = "05" & "/" & PeriodoGeneral
            Case "JUNIO"
                lblPerido.Text = "06" & "/" & PeriodoGeneral
            Case "JULIO"
                lblPerido.Text = "07" & "/" & PeriodoGeneral
            Case "AGOSTO"
                lblPerido.Text = "08" & "/" & PeriodoGeneral
            Case "SETIEMBRE"
                lblPerido.Text = "09" & "/" & PeriodoGeneral
            Case "OCTUBRE"
                lblPerido.Text = "10" & "/" & PeriodoGeneral
            Case "NOVIEMBRE"
                lblPerido.Text = "11" & "/" & PeriodoGeneral
            Case "DICIEMBRE"
                lblPerido.Text = "12" & "/" & PeriodoGeneral
        End Select
        ListaCompras(lblPerido.Text)
        ContextMenuStrip1.Hide()
    End Sub

    Private Sub lblPerido_Click(sender As System.Object, e As System.EventArgs) Handles lblPerido.Click

    End Sub

    Private Sub lblPerido_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lblPerido.MouseUp
        'Dim p As Point = e.Location
        'p.Offset(lblPerido.Bounds.Location)
        'ContextMenuStrip1.Show(ToolStrip4.PointToScreen(p))
        'cboPeriodo.DroppedDown = True
    End Sub

    Private Sub CompraPagadaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CompraPagadaToolStripMenuItem.Click
        'With frmCompraDirectaRecepcion
        '    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
        '    If .TieneCuentaFinanciera = True Then
        '        .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
        '        .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
        '        .lblPerido.Text = lblPerido.Text
        '        .StartPosition = FormStartPosition.CenterParent
        '        .ShowDialog()
        '        lsvProduccion.Refresh()
        '    Else
        '        lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
        '        Timer1.Enabled = True
        '        TiempoEjecutar(5)
        '    End If
        'End With
    End Sub

    Private Sub frmMantenimientoComprasPagadas_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        'Me.Location = Screen.FromControl(frmPMO.Panel4).WorkingArea.Location
        'Me.Size = Screen.FromControl(frmPMO.Panel4).WorkingArea.Size

    End Sub

    Private Sub lsvProduccion_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lsvProduccion.MouseClick
        If e.Button = MouseButtons.Right Then
            If lsvProduccion.Items.Count > 0 Then
                With lsvProduccion.SelectedItems(0)
                    If .SubItems(14).Text = TIPO_COMPRA.COMPRA_AL_CREDITO Or _
                       .SubItems(14).Text = TIPO_COMPRA.COMPRA_DIRECTA_CON_RECEPCION Or _
                       .SubItems(14).Text = TIPO_COMPRA.COMPRA_DIRECTA_SIN_RECEPCION Then
                        If lsvProduccion.FocusedItem.Bounds.Contains(e.Location) = True Then
                            'ContextMenuStrip2.Show(Cursor.Position)
                            Me.rmCompra.ParentControl = Me.lsvProduccion
                            setRadialMenuLocation()
                            Me.rmCompra.CenterCircleRadiusFactor = New System.Drawing.Size(34, 34)
                        End If
                    End If
                End With
            Else
                Me.rmCompra.ParentControl = Me.lsvProduccion
                setRadialMenuLocation()
                Me.rmCompra.CenterCircleRadiusFactor = New System.Drawing.Size(34, 34)
            End If

        End If
    End Sub

    Private Sub lsvProduccion_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lsvProduccion.MouseDown
        Me.rmCompra.Hide()
        Me.rmCompra.HidePopup()
        Me.rmCompra.ItemOnLoad = Nothing
        rmCompra.ResetInnerCircleRadius()
        Me.rmCompra.MenuVisibility = False
        Me.rmCompra.Refresh()
    End Sub

    Private Sub lsvProduccion_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lsvProduccion.MouseUp
        If e.Button = MouseButtons.Right And lsvProduccion.SelectedItems.Count > 0 Then

        End If
    End Sub

    Private Sub lsvProduccion_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lsvProduccion.SelectedIndexChanged
        If lsvProduccion.SelectedItems.Count > 0 Then
            ExpandCollapsePanel1.Enabled = True
            EXGuias.Enabled = True
            exNotas.Enabled = True
            If ExpandCollapsePanel1.IsExpanded Then
                ObtenerObligaciones(lsvProduccion.SelectedItems(0).SubItems(0).Text)
            End If

            If EXGuias.IsExpanded = True Then
                ObtenerListaGuias(lsvProduccion.SelectedItems(0).SubItems(0).Text)
            End If

            If exNotas.IsExpanded = True Then
                UbicarNotasPorIdPadre(lsvProduccion.SelectedItems(0).SubItems(0).Text)
            End If
        Else
            ExpandCollapsePanel1.Enabled = False
            EXGuias.Enabled = False
            exNotas.Enabled = False
        End If
    End Sub

    Private Sub ExpandCollapsePanel1_ExpandCollapse(sender As Object, e As MakarovDev.ExpandCollapsePanel.ExpandCollapseEventArgs) Handles ExpandCollapsePanel1.ExpandCollapse
        If e.IsExpanded Then
            If lsvProduccion.SelectedItems.Count > 0 Then
                ObtenerObligaciones(lsvProduccion.SelectedItems(0).SubItems(0).Text)
            Else
                'lblEstado.Text = "Debe seleccionar una compra"
                'lblEstado .
            End If
        End If
    End Sub

    Private Sub ExpandCollapsePanel1_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles ExpandCollapsePanel1.Paint

    End Sub

    Private Sub dgvObligacion_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvObligacion.CellClick
        Me.Cursor = Cursors.WaitCursor
        If e.RowIndex > -1 Then
            If e.ColumnIndex = 10 Then
                If dgvObligacion.Rows(e.RowIndex).Cells(1).Value <> "P" Then
                    If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        EliminarTributo(dgvObligacion.Item(0, dgvObligacion.CurrentRow.Index).Value)
                        If ExpandCollapsePanel1.IsExpanded = True Then
                            lsvProduccion.SelectedItems(0).Selected = True
                            lsvProduccion.SelectedItems(0).Focused = True
                            lsvProduccion.FocusedItem.EnsureVisible()
                            ObtenerObligaciones(lsvProduccion.SelectedItems(0).SubItems(0).Text)
                        End If
                    End If
                End If

            ElseIf e.ColumnIndex = 11 Then
                If dgvObligacion.Rows(e.RowIndex).Cells(1).Value <> "P" Then
                    With frmRegistroTributos
                        .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                        .txtFechaTributo.ShowUpDown = True
                        .UbicarDOcumentoTirbuto(dgvObligacion.Rows(e.RowIndex).Cells(0).Value)
                        .StartPosition = FormStartPosition.CenterParent
                        .ShowDialog()
                        If ExpandCollapsePanel1.IsExpanded = True Then
                            lsvProduccion.SelectedItems(0).Selected = True
                            lsvProduccion.SelectedItems(0).Focused = True
                            lsvProduccion.FocusedItem.EnsureVisible()
                            ObtenerObligaciones(lsvProduccion.SelectedItems(0).SubItems(0).Text)
                        End If
                    End With
                End If
            ElseIf e.ColumnIndex = 1 Then
                If dgvObligacion.Rows(e.RowIndex).Cells(1).Value = "P" Then
                    With frmCanastaTributo
                        .UbicarDetalleTributo(dgvObligacion.Rows(e.RowIndex).Cells(0).Value)
                        .StartPosition = FormStartPosition.CenterParent
                        .ShowDialog()
                    End With
                End If

            End If
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvObligacion_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvObligacion.CellContentClick

    End Sub

    Private Sub dgvObligacion_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvObligacion.CellFormatting
        If e.RowIndex > -1 Then
            Dim colPorcentaje As Decimal = 0
            If e.ColumnIndex = Me.dgvObligacion.Columns("colTipoTributo").Index _
AndAlso (e.Value IsNot Nothing) Then

                With Me.dgvObligacion.Rows(e.RowIndex).Cells(e.ColumnIndex)

                    If e.Value.Equals("D") Then
                        '   .ToolTipText = "1: ADQ. GRAVADAS DESTINADAS A OPE.GRAVADAS Y/O EXPORTACIONES"
                        e.Value = "DETRACCION"
                    ElseIf e.Value.Equals("R") Then
                        '  .ToolTipText = "2: ADQ. GRAV DEST CONJUNTAMENTE A OPER GRAV Y NO GRAV"
                        e.Value = "RETENCION"
                    ElseIf e.Value.Equals("P") Then
                        '  .ToolTipText = "3: ADQ. GRAVADAS DESTINADAS A OPER.NO GRAVADAS"
                        e.Value = "PERCEPCION"
                        e.CellStyle.BackColor = Color.Navy
                        e.CellStyle.ForeColor = Color.White

                    End If
                End With
            End If

            If e.ColumnIndex = Me.dgvObligacion.Columns("colDepmn").Index Then

                If lsvProduccion.SelectedItems.Count > 0 Then
                    colPorcentaje = Math.Round(CDec(dgvObligacion.Rows(e.RowIndex).Cells(7).Value) / 100, 2)
                    e.Value = Math.Round(CDec(lsvProduccion.SelectedItems(0).SubItems(10).Text) * colPorcentaje, 2).ToString("N2")
                End If
            End If

            If e.ColumnIndex = Me.dgvObligacion.Columns("colDepME").Index Then
                If lsvProduccion.SelectedItems.Count > 0 Then
                    colPorcentaje = Math.Round(CDec(dgvObligacion.Rows(e.RowIndex).Cells(7).Value) / 100, 2)
                    e.Value = Math.Round(CDec(lsvProduccion.SelectedItems(0).SubItems(12).Text) * colPorcentaje, 2).ToString("N2")
                End If
            End If
        End If
    End Sub

    Private Sub AsignarTributoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AsignarTributoToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        Dim docObligacionDetalleSA As New DocumentoObligacionDetalleSA
        If docObligacionDetalleSA.ComprobanteTieneTributo(lsvProduccion.SelectedItems(0).SubItems(0).Text) = False Then
            With frmRegistroTributos
                .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                .lblPeriodo.Text = lblPerido.Text
                .cboOT.Text = "DETRACCION"
                .UbicarCompra(lsvProduccion.SelectedItems(0).SubItems(0).Text)
                .txtFechaTributo.CustomFormat = "dd/MM/yyyy"
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
                If ExpandCollapsePanel1.IsExpanded = True Then
                    lsvProduccion.SelectedItems(0).Selected = True
                    lsvProduccion.SelectedItems(0).Focused = True
                    lsvProduccion.FocusedItem.EnsureVisible()
                    ObtenerObligaciones(lsvProduccion.SelectedItems(0).SubItems(0).Text)
                End If

            End With
        Else
            lblEstado.Text = "El comprobante ya tiene asignado un tributo"
            Timer1.Enabled = True
            TiempoEjecutar(5)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvObligacion_CellPainting(sender As Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgvObligacion.CellPainting
        If e.RowIndex > -1 Then
            If e.ColumnIndex = 11 AndAlso e.RowIndex >= 0 Then
                e.Paint(e.CellBounds, DataGridViewPaintParts.All)

                Dim bmpFind As Bitmap = My.Resources.edit4
                Dim ico As Icon = Icon.FromHandle(bmpFind.GetHicon)
                e.Graphics.DrawIcon(ico, e.CellBounds.Left + 3, e.CellBounds.Top + 3)
                e.Handled = True
            End If

            If e.ColumnIndex = 10 AndAlso e.RowIndex >= 0 Then
                e.Paint(e.CellBounds, DataGridViewPaintParts.All)

                Dim bmpFind As Bitmap = My.Resources.icono_eliminar
                Dim ico As Icon = Icon.FromHandle(bmpFind.GetHicon)
                e.Graphics.DrawIcon(ico, e.CellBounds.Left + 3, e.CellBounds.Top + 3)
                e.Handled = True

            End If
        End If
    End Sub

    Private Sub KryptonContextMenu1_Opened(sender As Object, e As System.EventArgs)

    End Sub

    Private Sub KryptonContextMenu1_Opening(sender As System.Object, e As System.ComponentModel.CancelEventArgs)

    End Sub

    Private Sub AsinarRetenciónToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AsinarRetenciónToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        Dim docObligacionDetalleSA As New DocumentoObligacionDetalleSA
        If docObligacionDetalleSA.ComprobanteTieneTributo(lsvProduccion.SelectedItems(0).SubItems(0).Text) = False Then
            With frmRegistroTributos
                .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                .lblPeriodo.Text = lblPerido.Text
                .cboOT.Text = "RETENCION"
                .UbicarCompra(lsvProduccion.SelectedItems(0).SubItems(0).Text)
                .txtFechaTributo.CustomFormat = "dd/MM/yyyy"
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
                If ExpandCollapsePanel1.IsExpanded = True Then
                    lsvProduccion.SelectedItems(0).Selected = True
                    lsvProduccion.SelectedItems(0).Focused = True
                    lsvProduccion.FocusedItem.EnsureVisible()
                    ObtenerObligaciones(lsvProduccion.SelectedItems(0).SubItems(0).Text)
                End If

            End With
        Else
            lblEstado.Text = "El comprobante ya tiene asignado un tributo"
            Timer1.Enabled = True
            TiempoEjecutar(5)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub AsignarPercepciónToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AsignarPercepciónToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        Dim docObligacionDetalleSA As New DocumentoObligacionDetalleSA
        If docObligacionDetalleSA.ComprobanteTieneTributo(lsvProduccion.SelectedItems(0).SubItems(0).Text) = False Then
            With frmRegistroTributos
                .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                .lblPeriodo.Text = lblPerido.Text
                .cboOT.Text = "PERCEPCION"
                .UbicarCompra(lsvProduccion.SelectedItems(0).SubItems(0).Text)
                .txtFechaTributo.CustomFormat = "dd/MM/yyyy"
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
                If ExpandCollapsePanel1.IsExpanded = True Then
                    lsvProduccion.SelectedItems(0).Selected = True
                    lsvProduccion.SelectedItems(0).Focused = True
                    lsvProduccion.FocusedItem.EnsureVisible()
                    ObtenerObligaciones(lsvProduccion.SelectedItems(0).SubItems(0).Text)
                End If

            End With
        Else
            lblEstado.Text = "El comprobante ya tiene asignado un tributo"
            Timer1.Enabled = True
            TiempoEjecutar(5)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub KryptonDataGridView1_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles KryptonDataGridView1.CellClick
        If e.RowIndex > -1 Then
            Me.Cursor = Cursors.WaitCursor
            If e.ColumnIndex = 5 Then
                With frmGuiaDetalle
                    .UbicarDetalleGuia(KryptonDataGridView1.Rows(e.RowIndex).Cells(0).Value)
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            End If
            Me.Cursor = Cursors.Arrow
        End If
    End Sub

    Private Sub KryptonDataGridView1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles KryptonDataGridView1.CellContentClick

    End Sub

    Private Sub KryptonDataGridView1_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles KryptonDataGridView1.CellFormatting

    End Sub

    Private Sub KryptonDataGridView1_CellPainting(sender As Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles KryptonDataGridView1.CellPainting
        If e.RowIndex > -1 Then
            If e.ColumnIndex = 5 AndAlso e.RowIndex >= 0 Then
                e.Paint(e.CellBounds, DataGridViewPaintParts.All)

                Dim bmpFind As Bitmap = My.Resources.icon_detalle_compra
                Dim ico As Icon = Icon.FromHandle(bmpFind.GetHicon)
                e.Graphics.DrawIcon(ico, e.CellBounds.Left + 3, e.CellBounds.Top + 3)

                e.Handled = True
            End If
        End If
    End Sub

    Private Sub EXGuias_ExpandCollapse(sender As Object, e As MakarovDev.ExpandCollapsePanel.ExpandCollapseEventArgs) Handles EXGuias.ExpandCollapse
        If e.IsExpanded Then
            If lsvProduccion.SelectedItems.Count > 0 Then
                ObtenerListaGuias(lsvProduccion.SelectedItems(0).SubItems(0).Text)
            Else
                'lblEstado.Text = "Debe seleccionar una compra"
                'lblEstado .
            End If
        End If
    End Sub

    Private Sub EXGuias_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles EXGuias.Paint

    End Sub

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        If EXGuias.IsExpanded = True Then
            MenGuia.Text = "Ocultar guías de remisión"
            MenGuia.Tag = "O"
        Else
            MenGuia.Text = "Ver guías de remisión"
            MenGuia.Tag = "V"
        End If
    End Sub

    Private Sub MenGuia_Click(sender As System.Object, e As System.EventArgs) Handles MenGuia.Click
        If MenGuia.Tag = "V" Then
            EXGuias.IsExpanded = True
        ElseIf MenGuia.Tag = "O" Then
            EXGuias.IsExpanded = False
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click

    End Sub
    'Private Sub OptimizeGrid(gridGroupingControl As Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl)
    '    ' Couple settings to perform better:
    '    gridGroupingControl.Engine.CounterLogic = EngineCounters.FilteredRecords
    '    gridGroupingControl.Engine.AllowedOptimizations = EngineOptimizations.DisableCounters Or EngineOptimizations.RecordsAsDisplayElements Or EngineOptimizations.VirtualMode
    '    gridGroupingControl.TableOptions.VerticalPixelScroll = False
    '    gridGroupingControl.Engine.TableOptions.ColumnsMaxLengthStrategy = GridColumnsMaxLengthStrategy.FirstNRecords
    '    gridGroupingControl.Engine.TableOptions.ColumnsMaxLengthFirstNRecords = 100
    'End Sub
    Private Sub exNotas_ExpandCollapse(sender As System.Object, e As MakarovDev.ExpandCollapsePanel.ExpandCollapseEventArgs) Handles exNotas.ExpandCollapse
        If e.IsExpanded Then
            If lsvProduccion.SelectedItems.Count > 0 Then
                UbicarNotasPorIdPadre(lsvProduccion.SelectedItems(0).SubItems(0).Text)
            Else
                'lblEstado.Text = "Debe seleccionar una compra"
                'lblEstado .
            End If
        End If
    End Sub

    Private Sub dgvNotaCredito_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvNotaCredito.CellClick
        If e.RowIndex > -1 Then
            Me.Cursor = Cursors.WaitCursor
            If e.ColumnIndex = 7 Then
                With frmCanastaCompraDetalle
                    .UbicarDetalle(dgvNotaCredito.Rows(e.RowIndex).Cells(0).Value)
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            ElseIf e.ColumnIndex = 8 Then
                ExportarNotas(lsvProduccion.SelectedItems(0).SubItems(0).Text, TIPO_COMPRA.NOTA_CREDITO)
            ElseIf e.ColumnIndex = 9 Then
                If MessageBox.Show("Desea eliminar la nota de crédito?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    EliminarNotaDebito(dgvNotaCredito.Rows(e.RowIndex).Cells(0).Value)
                    dgvNotaCredito.Rows.RemoveAt(e.RowIndex)
                    lblEstado.Image = My.Resources.ok4
                    lblEstado.Text = "nota de crédito eliminada!"
                End If
            End If
            Me.Cursor = Cursors.Arrow
        End If
    End Sub

    Private Sub dgvNotaCredito_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvNotaCredito.CellContentClick

    End Sub

    Private Sub dgvNotaCredito_CellPainting(sender As Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgvNotaCredito.CellPainting
        If e.RowIndex > -1 Then
            If e.ColumnIndex = 7 AndAlso e.RowIndex >= 0 Then
                e.Paint(e.CellBounds, DataGridViewPaintParts.All)

                Dim bmpFind As Bitmap = My.Resources.icon_detalle_compra
                Dim ico As Icon = Icon.FromHandle(bmpFind.GetHicon)
                e.Graphics.DrawIcon(ico, e.CellBounds.Left + 3, e.CellBounds.Top + 3)

                e.Handled = True
            End If
        End If
    End Sub

    Private Sub dgvNotaDebito_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvNotaDebito.CellClick
        If e.RowIndex > -1 Then
            Me.Cursor = Cursors.WaitCursor
            If e.ColumnIndex = 6 Then
                With frmCanastaCompraDetalle
                    .UbicarDetalle(dgvNotaDebito.Rows(e.RowIndex).Cells(0).Value)
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            ElseIf e.ColumnIndex = 7 Then
                ExportarNotas(lsvProduccion.SelectedItems(0).SubItems(0).Text, TIPO_COMPRA.NOTA_DEBITO)
            ElseIf e.ColumnIndex = 9 Then
                'With frmNotaDebito
                '    .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                '    .UbicarDocumento(dgvNotaDebito.Rows(e.RowIndex).Cells(0).Value)
                '    .StartPosition = FormStartPosition.CenterParent
                '    .TabPage1.Parent = Nothing
                '    .ShowDialog()
                'End With
            ElseIf e.ColumnIndex = 8 Then
                If MessageBox.Show("Desea eliminar la nota de débito?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    EliminarNotaDebito(dgvNotaDebito.Rows(e.RowIndex).Cells(0).Value)
                    dgvNotaDebito.Rows.RemoveAt(e.RowIndex)
                    lblEstado.Image = My.Resources.ok4
                    lblEstado.Text = "nota de débito eliminada!"
                End If
            End If


            Me.Cursor = Cursors.Arrow
        End If
    End Sub

    Private Sub dgvNotaDebito_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvNotaDebito.CellContentClick

    End Sub

    Private Sub dgvNotaDebito_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvNotaDebito.CellFormatting
        If e.ColumnIndex = Me.dgvNotaDebito.Columns("DataGridViewImageColumn2").Index _
AndAlso (e.Value IsNot Nothing) Then
            dgvNotaDebito.Rows(e.RowIndex).Cells(e.ColumnIndex).ToolTipText = "Existencias anexadas"
        End If

        If e.ColumnIndex = Me.dgvNotaDebito.Columns("colExcel1").Index _
AndAlso (e.Value IsNot Nothing) Then
            dgvNotaDebito.Rows(e.RowIndex).Cells(e.ColumnIndex).ToolTipText = "Exportar datos"
        End If

        If e.ColumnIndex = Me.dgvNotaDebito.Columns("colDeleteND").Index _
AndAlso (e.Value IsNot Nothing) Then
            dgvNotaDebito.Rows(e.RowIndex).Cells(e.ColumnIndex).ToolTipText = "Eliminar nota de débito"
        End If

        If e.ColumnIndex = Me.dgvNotaDebito.Columns("colEditND").Index _
AndAlso (e.Value IsNot Nothing) Then
            dgvNotaDebito.Rows(e.RowIndex).Cells(e.ColumnIndex).ToolTipText = "Ver Nota de Débito"
        End If
    End Sub

    Private Sub dgvNotaDebito_CellPainting(sender As Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgvNotaDebito.CellPainting
        If e.RowIndex > -1 Then
            If e.ColumnIndex = 6 AndAlso e.RowIndex >= 0 Then
                e.Paint(e.CellBounds, DataGridViewPaintParts.All)

                Dim bmpFind As Bitmap = My.Resources.icon_detalle_compra
                Dim ico As Icon = Icon.FromHandle(bmpFind.GetHicon)
                e.Graphics.DrawIcon(ico, e.CellBounds.Left + 3, e.CellBounds.Top + 3)

                e.Handled = True
            End If
            'If e.ColumnIndex = 7 AndAlso e.RowIndex >= 0 Then
            '    e.Paint(e.CellBounds, DataGridViewPaintParts.All)

            '    Dim bmpFind As Bitmap = My.Resources.export_excel
            '    Dim ico As Icon = Icon.FromHandle(bmpFind.GetHicon)
            '    e.Graphics.DrawIcon(ico, e.CellBounds.Left + 3, e.CellBounds.Top + 3)

            '    e.Handled = True
            'End If
        End If
    End Sub

    Private Sub AsignarNotaDeCréditoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AsignarNotaDeCréditoToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        Dim documentoCompraSA As New DocumentoCompraDetalleSA
        If documentoCompraSA.TieneItemsEnAV(lsvProduccion.SelectedItems(0).SubItems(0).Text) = True Then
            lblEstado.Text = "El comprobante posee items en el almacen virtual," & "necesita realizar la distribución, para seguir el proceso!"
            Timer1.Enabled = True
            TiempoEjecutar(5)
            Me.Cursor = Cursors.Arrow
        Else
            'With frmNotaCredito
            '    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            '    .StartPosition = FormStartPosition.CenterParent
            '    .configuracionModulo(Gempresas.IdEmpresaRuc, .Tag, .Text)
            '    .UbicarCabeceraCompra(lsvProduccion.SelectedItems(0).SubItems(0).Text)
            '    '.WindowState = FormWindowState.Maximized
            '    .ShowDialog()
            'End With
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub AsignarNotaDeDébitoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AsignarNotaDeDébitoToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        Dim documentoCompraSA As New DocumentoCompraDetalleSA
        If documentoCompraSA.TieneItemsEnAV(lsvProduccion.SelectedItems(0).SubItems(0).Text) = True Then
            lblEstado.Text = "El comprobante posee items en el almacen virtual," & "necesita realizar la distribución, para seguir el proceso!"
            Timer1.Enabled = True
            TiempoEjecutar(5)
            Me.Cursor = Cursors.Arrow
        Else
            'With frmNotaDebito
            '    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            '    .StartPosition = FormStartPosition.CenterParent
            '    .UbicarCabeceraCompra(lsvProduccion.SelectedItems(0).SubItems(0).Text)
            '    '.WindowState = FormWindowState.Maximized
            '    .ShowDialog()
            'End With
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lblTitulo_Click(sender As System.Object, e As System.EventArgs) Handles lblTitulo.Click

    End Sub

    Private Sub rmCompra_BeforeCloseUp(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles rmCompra.BeforeCloseUp
        If Me.rmCompra.MenuVisibility Then
            Me.rmCompra.MenuVisibility = False
            Me.rmCompra.ItemOnLoad = Nothing
            Me.rmCompra.Refresh()
        End If
    End Sub

    Private Sub rmCompra_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles rmCompra.Paint

    End Sub

    Private Sub rmEditarCompra_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles rmEditarCompra.MouseDown
        Me.Cursor = Cursors.WaitCursor
        Dim documentoCompraSA As New DocumentoCompraDetalleSA
        GConfiguracion = New GConfiguracionModulo
        GFichaUsuarios = New GFichaUsuario

        SelecIDEstable = Nothing
        SelecNombreEstable = Nothing
        SelectIdAlmacen = Nothing
        SelectNombreAlmacen = Nothing
        IdAlmacenBack = Nothing

        If lsvProduccion.SelectedItems.Count > 0 Then
            If lsvProduccion.SelectedItems(0).SubItems(14).Text = TIPO_COMPRA.COMPRA_AL_CREDITO Then
                'With frmCompraCreditoSinRecepcion
                '    .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                '    .txtFechaComprobante.ShowUpDown = True
                '    .UbicarDocumento(lsvProduccion.SelectedItems(0).SubItems(0).Text)
                '    .StartPosition = FormStartPosition.CenterParent
                '    .ShowDialog()
                'End With
            ElseIf lsvProduccion.SelectedItems(0).SubItems(14).Text = TIPO_COMPRA.COMPRA_DIRECTA_CON_RECEPCION Then
                'With frmCompraDirectaRecepcion
                '    .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                '    If .TieneCuentaFinanciera(CInt(lsvProduccion.SelectedItems(0).SubItems(0).Text)) = True Then
                '        .txtFechaComprobante.ShowUpDown = True
                '        .UbicarDocumento(lsvProduccion.SelectedItems(0).SubItems(0).Text)
                '        .StartPosition = FormStartPosition.CenterParent
                '        .ShowDialog()
                '    Else
                '        lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
                '        Timer1.Enabled = True
                '        TiempoEjecutar(5)
                '    End If
                'End With

            ElseIf lsvProduccion.SelectedItems(0).SubItems(14).Text = TIPO_COMPRA.COMPRA_DIRECTA_SIN_RECEPCION Then
                With frmCompraPagadaSinRecepcion
                    .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                    If .TieneCuentaFinanciera(CInt(lsvProduccion.SelectedItems(0).SubItems(0).Text)) = True Then
                        .txtFechaComprobante.ShowUpDown = True
                        .UbicarDocumento(lsvProduccion.SelectedItems(0).SubItems(0).Text)
                        .StartPosition = FormStartPosition.CenterParent
                        .ShowDialog()
                    Else
                        lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
                        Timer1.Enabled = True
                        TiempoEjecutar(5)
                    End If
                End With
            ElseIf lsvProduccion.SelectedItems(0).SubItems(14).Text = TIPO_COMPRA.NOTA_CREDITO Then
                'With frmNotaCredito
                '    .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                '    .UbicarDocumento(lsvProduccion.SelectedItems(0).SubItems(0).Text)
                '    .StartPosition = FormStartPosition.CenterParent
                '    .ShowDialog()
                'End With
            ElseIf lsvProduccion.SelectedItems(0).SubItems(14).Text = TIPO_COMPRA.NOTA_DEBITO Then
                'With frmNotaDebito
                '    .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                '    .UbicarDocumento(lsvProduccion.SelectedItems(0).SubItems(0).Text)
                '    .StartPosition = FormStartPosition.CenterParent
                '    .ShowDialog()
                'End With
            End If
            lsvProduccion.SelectedItems(0).Selected = True
            lsvProduccion.SelectedItems(0).Focused = True
            lsvProduccion.FocusedItem.EnsureVisible()
            If ExpandCollapsePanel1.IsExpanded Then
                ObtenerObligaciones(lsvProduccion.SelectedItems(0).SubItems(0).Text)
            End If
            If EXGuias.IsExpanded = True Then
                ObtenerListaGuias(lsvProduccion.SelectedItems(0).SubItems(0).Text)
            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub rmEliminarDoc_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles rmEliminarDoc.MouseDown
        ElimnarDocRadial()
    End Sub

    Private Sub rmiCompraAlContado_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles rmiCompraAlContado.MouseDown
        GConfiguracion = New GConfiguracionModulo
        'With frmCompraPagada
        '    If .TieneCuentaFinanciera = True Then
        '        .Width = 925
        '        .Height = 521
        '        Dim cfecha As Date = Date.Now.Day & "/" & lblPerido.Text
        '        .txtFechaComprobante.Text = New Date(PeriodoGeneral, cfecha.Month, cfecha.Day)
        '        .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
        '        .lblPeriodo.Text = lblPerido.Text
        '        .ManipulacionEstado = ENTITY_ACTIONS.INSERT
        '        .StartPosition = FormStartPosition.CenterParent
        '        .configuracionModulo(Gempresas.IdEmpresaRuc, .Tag, .Text)
        '        .ShowDialog()
        '        lsvProduccion.Refresh()
        '    Else
        '        lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
        '        Timer1.Enabled = True
        '        TiempoEjecutar(5)
        '    End If
        'End With
    End Sub

    Private Sub rmiCompraAlcredito_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles rmiCompraAlcredito.MouseDown
        GConfiguracion = New GConfiguracionModulo
        'With frmCompraEjecutada
        '    .Width = 925
        '    .Height = 521
        '    .gbxGuias.Visible = False
        '    Dim cfecha As Date = Date.Now.Day & "/" & lblPerido.Text
        '    .txtFechaComprobante.Text = New Date(PeriodoGeneral, cfecha.Month, cfecha.Day)
        '    .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
        '    .lblPeriodo.Text = lblPerido.Text
        '    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
        '    .StartPosition = FormStartPosition.CenterParent
        '    .configuracionModulo(Gempresas.IdEmpresaRuc, .Tag, .Text)
        '    .ShowDialog()
        '    lsvProduccion.Refresh()
        'End With
    End Sub

    Private Sub rmiNotaCredito_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles rmiNotaCredito.MouseDown
        Me.Cursor = Cursors.WaitCursor
        Dim documentoCompraSA As New DocumentoCompraDetalleSA
        If documentoCompraSA.TieneItemsEnAV(lsvProduccion.SelectedItems(0).SubItems(0).Text) = True Then
            lblEstado.Text = "El comprobante posee items en el almacen virtual," & "necesita realizar la distribución, para seguir el proceso!"
            Timer1.Enabled = True
            TiempoEjecutar(5)
            Me.Cursor = Cursors.Arrow
        Else
            'With frmNotaCredito
            '    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            '    .StartPosition = FormStartPosition.CenterParent
            '    .configuracionModulo(Gempresas.IdEmpresaRuc, .Tag, .Text)
            '    .UbicarCabeceraCompra(lsvProduccion.SelectedItems(0).SubItems(0).Text)
            '    '.WindowState = FormWindowState.Maximized
            '    .ShowDialog()
            'End With
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub rmiNotaDebito_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles rmiNotaDebito.MouseDown
        Me.Cursor = Cursors.WaitCursor
        Dim documentoCompraSA As New DocumentoCompraDetalleSA
        If documentoCompraSA.TieneItemsEnAV(lsvProduccion.SelectedItems(0).SubItems(0).Text) = True Then
            lblEstado.Text = "El comprobante posee items en el almacen virtual," & "necesita realizar la distribución, para seguir el proceso!"
            Timer1.Enabled = True
            TiempoEjecutar(5)
            Me.Cursor = Cursors.Arrow
        Else
            'With frmNotaDebito
            '    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            '    .StartPosition = FormStartPosition.CenterParent
            '    .UbicarCabeceraCompra(lsvProduccion.SelectedItems(0).SubItems(0).Text)
            '    '.WindowState = FormWindowState.Maximized
            '    .ShowDialog()
            'End With
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub rmiDetraccion_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles rmiDetraccion.MouseDown
        Me.Cursor = Cursors.WaitCursor
        Dim docObligacionDetalleSA As New DocumentoObligacionDetalleSA
        If docObligacionDetalleSA.ComprobanteTieneTributo(lsvProduccion.SelectedItems(0).SubItems(0).Text) = False Then
            With frmRegistroTributos
                .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                .lblPeriodo.Text = lblPerido.Text
                .cboOT.Text = "DETRACCION"
                .UbicarCompra(lsvProduccion.SelectedItems(0).SubItems(0).Text)
                .txtFechaTributo.CustomFormat = "dd/MM/yyyy"
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
                If ExpandCollapsePanel1.IsExpanded = True Then
                    lsvProduccion.SelectedItems(0).Selected = True
                    lsvProduccion.SelectedItems(0).Focused = True
                    lsvProduccion.FocusedItem.EnsureVisible()
                    ObtenerObligaciones(lsvProduccion.SelectedItems(0).SubItems(0).Text)
                End If

            End With
        Else
            lblEstado.Text = "El comprobante ya tiene asignado un tributo"
            Timer1.Enabled = True
            TiempoEjecutar(5)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub rmiRetencion_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles rmiRetencion.MouseDown
        Me.Cursor = Cursors.WaitCursor
        Dim docObligacionDetalleSA As New DocumentoObligacionDetalleSA
        If docObligacionDetalleSA.ComprobanteTieneTributo(lsvProduccion.SelectedItems(0).SubItems(0).Text) = False Then
            With frmRegistroTributos
                .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                .lblPeriodo.Text = lblPerido.Text
                .cboOT.Text = "RETENCION"
                .UbicarCompra(lsvProduccion.SelectedItems(0).SubItems(0).Text)
                .txtFechaTributo.CustomFormat = "dd/MM/yyyy"
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
                If ExpandCollapsePanel1.IsExpanded = True Then
                    lsvProduccion.SelectedItems(0).Selected = True
                    lsvProduccion.SelectedItems(0).Focused = True
                    lsvProduccion.FocusedItem.EnsureVisible()
                    ObtenerObligaciones(lsvProduccion.SelectedItems(0).SubItems(0).Text)
                End If

            End With
        Else
            lblEstado.Text = "El comprobante ya tiene asignado un tributo"
            Timer1.Enabled = True
            TiempoEjecutar(5)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub rmiPercepcion_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles rmiPercepcion.MouseDown
        Me.Cursor = Cursors.WaitCursor
        Dim docObligacionDetalleSA As New DocumentoObligacionDetalleSA
        If docObligacionDetalleSA.ComprobanteTieneTributo(lsvProduccion.SelectedItems(0).SubItems(0).Text) = False Then
            With frmRegistroTributos
                .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                .lblPeriodo.Text = lblPerido.Text
                .cboOT.Text = "PERCEPCION"
                .UbicarCompra(lsvProduccion.SelectedItems(0).SubItems(0).Text)
                .txtFechaTributo.CustomFormat = "dd/MM/yyyy"
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
                If ExpandCollapsePanel1.IsExpanded = True Then
                    lsvProduccion.SelectedItems(0).Selected = True
                    lsvProduccion.SelectedItems(0).Focused = True
                    lsvProduccion.FocusedItem.EnsureVisible()
                    ObtenerObligaciones(lsvProduccion.SelectedItems(0).SubItems(0).Text)
                End If

            End With
        Else
            lblEstado.Text = "El comprobante ya tiene asignado un tributo"
            Timer1.Enabled = True
            TiempoEjecutar(5)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub rmiVerGuia_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles rmiVerGuia.MouseDown
        If MenGuia.Tag = "V" Then
            EXGuias.IsExpanded = True
        ElseIf MenGuia.Tag = "O" Then
            EXGuias.IsExpanded = False
        End If
    End Sub

    Private Sub ToolStrip4_ItemClicked(sender As System.Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolStrip4.ItemClicked

    End Sub

    Private Sub ToolStripButton7_Disposed(sender As Object, e As System.EventArgs) Handles ToolStripButton7.Disposed

    End Sub

    'Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged
    '    If CheckBox1.Checked = True Then

    '        ListaComprasPorDia()

    '        CheckBox1.Checked = True
    '        CheckBox2.Checked = False
    '        CheckBox3.Checked = False

    '    End If
    'End Sub

    Private Sub CheckBox2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            ListaComprasPorMes(PeriodoGeneral, String.Format("{0:00}", lblPerido.Text.Substring(0, 2)))

            CheckBox1.Checked = False
            CheckBox2.Checked = True
            CheckBox3.Checked = False
        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked = True Then
            ListaComprasPorRango(CDate(DateTimePicker1.Value), CDate(DateTimePicker2.Value))

            CheckBox1.Checked = False
            CheckBox2.Checked = False
            CheckBox3.Checked = True
        End If
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As System.Object, e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        If CheckBox3.Checked = True Then
            ListaComprasPorRango(CDate(DateTimePicker1.Value), CDate(DateTimePicker2.Value))

            CheckBox1.Checked = False
            CheckBox2.Checked = False
            CheckBox3.Checked = True
        End If
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As System.Object, e As System.EventArgs) Handles DateTimePicker2.ValueChanged
        If CheckBox3.Checked = True Then
            ListaComprasPorRango(CDate(DateTimePicker1.Value), CDate(DateTimePicker2.Value))

            CheckBox1.Checked = False
            CheckBox2.Checked = False
            CheckBox3.Checked = True
        End If
    End Sub

    Private Sub CompraAlContadoSinRecepcionDeExistenciaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CompraAlContadoSinRecepcionDeExistenciaToolStripMenuItem.Click
        With frmCompraPagadaSinRecepcion
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            If .TieneCuentaFinanciera = True Then
                .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
                .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
                '    .lblPerido.Text = lblPerido.Text

                .StartPosition = FormStartPosition.CenterParent
                '  .configuracionModulo(Gempresas.IdEmpresaRuc, .Tag, .Text)
                .ShowDialog()
                lsvProduccion.Refresh()
            Else
                lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
                Timer1.Enabled = True
                TiempoEjecutar(5)
            End If
        End With
    End Sub
End Class