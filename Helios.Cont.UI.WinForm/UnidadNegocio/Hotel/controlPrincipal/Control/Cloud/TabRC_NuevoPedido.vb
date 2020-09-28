Imports System.IO
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports System.Configuration.SettingsAttributeDictionary
Imports System.Configuration

Public Class TabRC_NuevoPedido


#Region "Attributes"

    Dim listaDistribucion As New List(Of distribucionInfraestructura)
    Dim listaDistribucionPrincipal As New List(Of distribucionInfraestructura)
    Public Property listaID As New List(Of String)
    Public Property IDDocumento As Integer = 0
    Dim ListaREservas As String

    Dim IDTagSeleccionado As Integer

    Dim listaInfra As New List(Of infraestructura)
    Dim listaServicioInfra As New List(Of tipoServicioInfraestructura)
    Public Property NroDoc As Integer
    Public Property nombre As String
    Public Property IdCliente As Integer

#End Region

#Region "Constructors"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub


#End Region

#Region "Methods"

    Public Function GetCodigoVendedor() As Helios.Seguridad.Business.Entity.Usuario
        GetCodigoVendedor = Nothing
        Dim f As New FormCodigoVendedor
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        If f.Tag IsNot Nothing Then
            Dim c = CType(f.Tag, Helios.Seguridad.Business.Entity.Usuario)
            GetCodigoVendedor = c
        End If
    End Function

    Sub DibujarControl(listDistr As List(Of distribucionInfraestructura))
        flowProductoDetalle.Controls.Clear()
        For Each items In listDistr
            Dim b As New RoundButton2
            If (items.estado = "A") Then
                'b.BackColor = System.Drawing.Color.Green
                'If (items.menor > 0) Then
                '    b.Text = items.descripcionDistribucion & " - " & items.numeracion & vbNewLine & (items.usuarioActualizacion) & vbNewLine & ("S/. " & FormatNumber(CDec(items.menor), 2))
                '    b.Name = items.menor
                'Else
                '    b.Text = items.descripcionDistribucion & " - " & items.numeracion & vbNewLine & (items.usuarioActualizacion)
                '    b.Name = items.menor
                'End If
            ElseIf (items.estado = "U") Then
                b.BackColor = System.Drawing.Color.Green
                b.Text = items.descripcionDistribucion & " - " & items.numeracion & vbNewLine & (items.usuarioActualizacion)
                b.Name = items.menor
                'ElseIf (items.estado = "U" And items.conteoPrecioMenor > 0) Then
                '    b.BackColor = System.Drawing.Color.DarkRed
                '    b.Text = items.descripcionDistribucion & " - " & items.numeracion & vbNewLine & (items.usuarioActualizacion) & vbNewLine & "(C. X COBRAR)" & vbNewLine & ("S/. " & FormatNumber(CDec(items.menor), 2))
                '    b.Name = items.menor
            Else
                'b.BackColor = System.Drawing.Color.DarkCyan
                'Dim CONTEOSW = (From x In FormPurchase.listaHospedados Where x.distribucionID = items.idDistribucion).Count
                'If (Not IsNothing(CONTEOSW)) Then
                '    b.Text = items.descripcionDistribucion & " - " & items.numeracion & vbNewLine & (items.usuarioActualizacion) & vbNewLine & "HOSPEDADOS(" & CONTEOSW & ")" & vbNewLine & "S/. " & CDec(FormatNumber(CDec(items.menor), 2))
                'Else
                '    b.Text = items.descripcionDistribucion & " - " & items.numeracion & vbNewLine & (items.usuarioActualizacion) & vbNewLine & "HOSPEDADOS(0)" & vbNewLine & "S/. " & CDec(FormatNumber(CDec(items.menor), 2))
                'End If
                'b.Name = items.menor
                'b.TabIndex = 0
            End If

            b.FlatStyle = FlatStyle.Standard
            b.TabIndex = items.idDistribucion
            b.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            b.ForeColor = System.Drawing.Color.White
            b.Size = New System.Drawing.Size(120, 100)
            b.Tag = items
            b.Image = ImageList1.Images(0)
            b.ImageAlign = ContentAlignment.MiddleCenter
            b.TextImageRelation = TextImageRelation.ImageAboveText
            b.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            b.UseVisualStyleBackColor = False
            flowProductoDetalle.Controls.Add(b)

            AddHandler b.Click, AddressOf Butto1
        Next
    End Sub

    Public Sub LLAMARiNFRAESTRUCTURA(listaId As List(Of String), Estado As String)
        Try
            Dim atributos As New FileAttributes
            Dim distribucionInfraestructuraSA As New distribucionInfraestructuraSA
            Dim distribucionInfraestructuraBE As New distribucionInfraestructura
            Dim conteo As Integer = 0
            Dim sumatoriaBoton As Integer = 1

            '//IMAGNE 
            distribucionInfraestructuraBE.tipo = "1"
            distribucionInfraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
            distribucionInfraestructuraBE.idEstablecimiento = GEstableciento.IdEstablecimiento
            distribucionInfraestructuraBE.tipo = "VNP"
            distribucionInfraestructuraBE.estado = "A"
            distribucionInfraestructuraBE.listaEstado = New List(Of String)
            distribucionInfraestructuraBE.listaEstado = (listaId)
            distribucionInfraestructuraBE.idInfraestructura = IDDocumento
            distribucionInfraestructuraBE.usuarioActualizacion = Estado
            distribucionInfraestructuraBE.Categoria = 4
            distribucionInfraestructuraBE.SubCategoria = IDDocumento

            listaDistribucion = distribucionInfraestructuraSA.getDistribucionInfraestructuraXtipoInfra(distribucionInfraestructuraBE)

            DibujarControl(listaDistribucion)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub UPDATEINFRAESTRUCTURA(colorBE As Color, Estado As String, sender As Object)
        'Try
        '    Dim c = CType(sender.Tag, distribucionInfraestructura)
        '    If (colorBE = System.Drawing.Color.DarkCyan) Then
        '        sender.BackColor = System.Drawing.Color.DarkCyan
        '        Dim CONTEOSW = (From x In FormPurchase.listaHospedados Where x.distribucionID = sender.TABINDEX).Count
        '        If (Not IsNothing(CONTEOSW)) Then
        '            sender.Text = c.descripcionDistribucion & " - " & c.numeracion & vbNewLine & (c.usuarioActualizacion) & vbNewLine & "HOSPEDADOS(" & CONTEOSW & ")" & vbNewLine & "S/. " & CDec(FormatNumber(CDec(c.menor), 2))
        '        Else
        '            sender.Text = c.descripcionDistribucion & " - " & c.numeracion & vbNewLine & (c.usuarioActualizacion) & vbNewLine & "HOSPEDADOS(0)" & vbNewLine & "S/. " & CDec(FormatNumber(CDec(c.menor), 2))
        '        End If
        '        sender.Name = c.menor
        '        sender.ContextMenuStrip.Name = 1

        '    ElseIf (colorBE = System.Drawing.Color.Green) Then
        '        sender.BackColor = System.Drawing.Color.Green
        '        If (c.menor > 0) Then
        '            sender.Text = c.descripcionDistribucion & " - " & c.numeracion & vbNewLine & (c.usuarioActualizacion) & vbNewLine & ("S/. " & FormatNumber(CDec(c.menor), 2))
        '            sender.Name = c.menor
        '            sender.ContextMenuStrip.Name = 0
        '        Else
        '            sender.Text = c.descripcionDistribucion & " - " & c.numeracion & vbNewLine & (c.usuarioActualizacion)
        '            sender.Name = c.menor
        '            sender.ContextMenuStrip.Name = 0

        '        End If
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
    End Sub


    Public Sub UpdateInfraestructuraManipulacion(colorBE As Color, Estado As String, sender As Object)
        'Try
        '    Dim c = CType(sender.Tag, distribucionInfraestructura)

        '    If (colorBE = System.Drawing.Color.DarkCyan) Then
        '        Dim CONTEOSW = (From x In FormPurchase.listaHospedados Where x.distribucionID = c.idDistribucion).Count
        '        If (Not IsNothing(CONTEOSW)) Then
        '            sender.Text = c.descripcionDistribucion & " - " & c.numeracion & vbNewLine & (c.usuarioActualizacion) & vbNewLine & "HOSPEDADOS(" & CONTEOSW & ")" & vbNewLine & "S/. " & CDec(FormatNumber(CDec(c.menor), 2))
        '        Else
        '            sender.Text = c.descripcionDistribucion & " - " & c.numeracion & vbNewLine & (c.usuarioActualizacion) & vbNewLine & "HOSPEDADOS(0)" & vbNewLine & "S/. " & CDec(FormatNumber(CDec(c.menor), 2))
        '        End If
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
    End Sub

#End Region

#Region "Events"
    Private Sub Butto1(sender As Object, e As EventArgs)
        Try

            If (sender.BACKCOLOR = System.Drawing.Color.Green) Then
                Dim c = CType(sender.Tag, distribucionInfraestructura)
                Dim VENDEDOR = GetCodigoVendedor()

                If (Not IsNothing(VENDEDOR)) Then
                    Dim f As New FormVentaNuevaTouch()
                    f.ComboComprobante.Text = "PEDIDO"
                    f.CheckStock.Checked = True
                    f.UCEstructuraCabeceraVentaV2.RoundButton21.Visible = False
                    f.UCEstructuraCabeceraVentaV2.txtIDResponsable = VENDEDOR.IDUsuario
                    f.UCEstructuraCabeceraVentaV2.txtNombreResponsable = VENDEDOR.Nombres & " " & VENDEDOR.ApellidoPaterno & " " & VENDEDOR.ApellidoMaterno
                    f.UCEstructuraCabeceraVentaV2.txtInfraestructura.Text = c.descripcionDistribucion & " " & c.numeracion
                    f.UCEstructuraCabeceraVentaV2.txtInfraestructura.Tag = c.idDistribucion
                    f.UCEstructuraCabeceraVentaV2.RadioButton2.Checked = True
                    f.UCEstructuraCabeceraVentaV2.txtCheckIn.Visible = False
                    f.UCEstructuraCabeceraVentaV2.txtCheckOn.Visible = False
                    f.UCEstructuraCabeceraVentaV2.txtdias.Visible = False
                    f.UCEstructuraCabeceraVentaV2.lblCheckIn.Visible = False
                    f.UCEstructuraCabeceraVentaV2.Label20.Visible = False
                    f.UCEstructuraCabeceraVentaV2.Label19.Visible = False
                    f.UCEstructuraCabeceraVentaV2.TextNumIdentrazon.Text = NroDoc
                    f.UCEstructuraCabeceraVentaV2.TextProveedor.Text = nombre
                    f.UCEstructuraCabeceraVentaV2.TextProveedor.Tag = IdCliente
                    f.UCEstructuraCabeceraVentaV2.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                    f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()
                End If

            ElseIf (sender.BACKCOLOR = System.Drawing.Color.DarkCyan) Then


            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click
        Close()
    End Sub


#End Region

End Class
