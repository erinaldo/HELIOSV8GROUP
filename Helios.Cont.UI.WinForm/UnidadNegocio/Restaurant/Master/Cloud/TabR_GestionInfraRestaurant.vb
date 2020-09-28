Imports System.ComponentModel
Imports System.IO
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports System.Xml

Public Class TabR_GestionInfraRestaurant

#Region "Attributes"
    Dim tipoLista As String
    Dim lis As New ListBox
    Dim ListaproductosVendidos As List(Of documentoventaAbarrotesDet)
    Dim listaDistribucion As New List(Of distribucionInfraestructura)
    Public Property FormPurchase As FormControlRestaurant
    Private Property FormVentaTouch As FormVentaTouch

    Dim m_xmld As XmlDocument
    Dim m_nodelist As XmlNodeList
    Dim m_node As XmlNode

#End Region

#Region "Constructors"
    Public Sub New(formRepPiscina As FormControlRestaurant)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormPurchase = formRepPiscina
        'CargarCombos()
        'CargarDefault()
    End Sub

    Public Sub New(formRepPiscina As FormControlRestaurant, TIPO As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormPurchase = formRepPiscina
        'CargarCombos()
        'CargarDefault()

        pnCargaDatos.Visible = True
        BunifuFlatButton10.Visible = False
        CargarDefault()
        pnCargaDatos.Visible = False
    End Sub

    Public Sub CargarCombos()
        Dim tipoServicioInfraestructuraSA As New tipoServicioInfraestructuraSA
        Dim infraestrucutraSA As New infraestructuraSA
        Dim objInfraBE As New infraestructura
        Dim objServicioInfraBE As New tipoServicioInfraestructura
        Dim listaInfra As New List(Of infraestructura)
        Dim listaServicioInfra As New List(Of tipoServicioInfraestructura)
        Dim objInfraDefault As New infraestructura
        Dim objServicioInfraDefault As New tipoServicioInfraestructura

        objInfraBE.idEmpresa = Gempresas.IdEmpresaRuc
        objInfraBE.idEstablecimiento = GEstableciento.IdEstablecimiento
        objInfraBE.tipo = "P"

        objInfraDefault.idInfraestructura = 0
        objInfraDefault.nombre = "TODO"

        listaInfra.Add(objInfraDefault)
        listaInfra.AddRange(infraestrucutraSA.getListaInfraestructura(objInfraBE))

        cboFormato.ValueMember = "idInfraestructura"
        cboFormato.DisplayMember = "nombre"
        cboFormato.DataSource = listaInfra
        cboFormato.SelectedValue = 0


        'objServicioInfraBE.idEmpresa = Gempresas.IdEmpresaRuc
        'objServicioInfraBE.idEstablecimiento = GEstableciento.IdEstablecimiento

        'objServicioInfraDefault.idTipoServicio = 0
        'objServicioInfraDefault.descripcionTipoServicio = "TODO"

        'listaServicioInfra.Add(objServicioInfraDefault)
        'listaServicioInfra.AddRange(tipoServicioInfraestructuraSA.GetUbicartipoServicioInfra(objServicioInfraBE))

        'cboCategoria.ValueMember = "idTipoServicio"
        'cboCategoria.DisplayMember = "descripcionTipoServicio"
        'cboCategoria.DataSource = listaServicioInfra
        'cboCategoria.SelectedValue = 0

    End Sub

    Private Sub BunifuFlatButton5_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton5.Click
        lblCtasXcobrar.Visible = False
        CheckCtasXCobrar.Visible = False
        CheckCtasXCobrar.Checked = False
        'Dim listaItem As List(Of String)
        'listaItem = New List(Of String)
        'listaItem.Add("A")
        ''CargarCombos()

        Dim estado As String = String.Empty
        estado = "A"

        LLAMARiNFRAESTRUCTURA(estado, "VPN", 1, "DP")
        tipoLista = "A"
        'lblFiltro.Visible = True
        'cboFormato.Visible = True
    End Sub

    Private Sub BunifuFlatButton7_Click(sender As Object, e As EventArgs)
        lblCtasXcobrar.Visible = False
        CheckCtasXCobrar.Visible = False
        CheckCtasXCobrar.Checked = False
        'Dim listaItem As List(Of String)
        'listaItem = New List(Of String)
        'listaItem.Add("U")
        ''CargarCombos()
        Dim estado As String = String.Empty
        estado = "U"
        LLAMARiNFRAESTRUCTURA(estado, "VPN", 1, "EU")
        tipoLista = "U"
        'lblFiltro.Visible = True
        'cboFormato.Visible = True
    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
        lblCtasXcobrar.Visible = False
        CheckCtasXCobrar.Visible = False
        CheckCtasXCobrar.Checked = False
        'Dim listaItem As List(Of String)
        'listaItem = New List(Of String)
        'listaItem.Add("U")
        ''CargarCombos()

        Dim estado As String = String.Empty
        estado = "P"

        LLAMARiNFRAESTRUCTURA(estado, "VPN", 1, "CR")
        tipoLista = "P"
        'lblFiltro.Visible = True
        'cboFormato.Visible = True
    End Sub
#End Region

#Region "Methods"

    Private Sub RefrescarCobros()
        'Dim listaItem As List(Of String)
        'listaItem = New List(Of String)
        'listaItem.Add("U")
        ''CargarCombos()
        Dim estado As String = String.Empty
        estado = "U"
        LLAMARiNFRAESTRUCTURA(estado, "VPN", 1, "RF")
        tipoLista = "P"
        'lblFiltro.Visible = True
        'cboFormato.Visible = True
    End Sub

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

    Public Sub LLAMARiNFRAESTRUCTURA(tipoEstado As String, Tipo As String, formaBusqueda As Integer, estadoConsulta As String)
        Try
            Dim atributos As New FileAttributes
            Dim distribucionInfraestructuraSA As New distribucionInfraestructuraSA
            Dim distribucionInfraestructuraBE As New distribucionInfraestructura
            Dim conteo As Integer = 0
            Dim sumatoriaBoton As Integer = 1

            '//IMAGNE 
            flowProductoDetalle.Controls.Clear()

            distribucionInfraestructuraBE.tipo = "1"
            distribucionInfraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
            distribucionInfraestructuraBE.idEstablecimiento = GEstableciento.IdEstablecimiento
            distribucionInfraestructuraBE.tipo = Tipo
            distribucionInfraestructuraBE.estado = "A"
            distribucionInfraestructuraBE.usuarioActualizacion = tipoEstado
            distribucionInfraestructuraBE.Categoria = formaBusqueda

            Select Case estadoConsulta
                Case "CF"
                    listaDistribucion = distribucionInfraestructuraSA.getDistribucionInfraestructuraXtipo(distribucionInfraestructuraBE)
                Case Else
                    listaDistribucion = distribucionInfraestructuraSA.getInfraestructura(distribucionInfraestructuraBE)
            End Select

            DibujarControl(listaDistribucion)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub CargarDefault()
        Dim estado As String = String.Empty
        estado = "U, A,P, L"
        LLAMARiNFRAESTRUCTURA(estado, "VPN", 1, "RF")
        tipoLista = "T"
        'lblFiltro.Visible = True
        'cboFormato.Visible = True
    End Sub

    Sub DibujarControl(listDistr As List(Of distribucionInfraestructura))
        flowProductoDetalle.Controls.Clear()
        For Each items In listDistr
            Dim b As New RoundButton2

            If (items.estado = "A") Then
                b.BackColor = System.Drawing.Color.Green
                b.Text = items.descripcionDistribucion & " - " & items.numeracion '& vbNewLine & ("DISPONIBLE")
                b.TabIndex = 1
            ElseIf (items.estado = "U" And items.conteoPrecioMenor = 0) Then
                b.BackColor = System.Drawing.Color.DimGray
                b.Text = items.descripcionDistribucion & " - " & items.numeracion '& vbNewLine & ("OCUPADO")
                b.TabIndex = 0
            ElseIf (items.estado = "U" And items.conteoPrecioMenor > 0) Then
                b.BackColor = System.Drawing.Color.Peru
                b.Text = items.descripcionDistribucion & " - " & items.numeracion & vbNewLine & ("S/. " & FormatNumber(CDec(items.conteoPrecioMenor), 2))
                b.TabIndex = 0

            ElseIf (items.estado = "P") Then
                b.BackColor = System.Drawing.Color.DarkRed
                b.Text = items.descripcionDistribucion & " - " & items.numeracion & vbNewLine & ("S/. " & FormatNumber(CDec(items.conteoPrecioMenor), 2))
                b.TabIndex = 0

            ElseIf (items.estado = "L") Then
                b.BackColor = System.Drawing.Color.OrangeRed
                b.Text = items.descripcionDistribucion & " - " & items.numeracion
                b.TabIndex = 0
            End If

            b.FlatStyle = FlatStyle.Standard
            'b.TabIndex = items.idDistribucion
            b.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            b.ForeColor = System.Drawing.Color.White
            b.Size = New System.Drawing.Size(100, 80)
            b.Font = New Font("Franklin Gothic Medium", 9, FontStyle.Regular)
            b.Tag = items
            b.Image = ImageList1.Images(1)
            b.ImageAlign = ContentAlignment.MiddleCenter
            b.TextImageRelation = TextImageRelation.ImageAboveText
            b.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            b.UseVisualStyleBackColor = False
            flowProductoDetalle.Controls.Add(b)

            'b.ContextMenuStrip.Text = items.descripcionDistribucion & " - " & items.numeracion
            AddHandler b.Click, AddressOf Butto1

        Next
    End Sub

    Public Sub UPDATEINFRAESTRUCTURA(colorBE As Color, Estado As String, sender As Object, distri As distribucionInfraestructura)
        Try
            Dim c = CType(sender.Tag, distribucionInfraestructura)

            If (colorBE = System.Drawing.Color.DarkCyan) Then
                If (c.conteoPrecioMenor > 0) Then
                    sender.BackColor = System.Drawing.Color.DarkRed
                    sender.Text = c.descripcionDistribucion & " - " & c.numeracion & vbNewLine & ("S/. " & FormatNumber(CDec(distri.Devolucion), 2))
                Else
                    sender.BackColor = System.Drawing.Color.DimGray
                    sender.Text = c.descripcionDistribucion & " " & c.numeracion
                End If
            ElseIf (colorBE = System.Drawing.Color.DimGray) Then
                If (c.conteoPrecioMenor > 0) Then
                    sender.BackColor = System.Drawing.Color.DarkRed
                    sender.Text = c.descripcionDistribucion & " - " & c.numeracion & vbNewLine & ("S/. " & FormatNumber(CDec(distri.Devolucion), 2))
                Else
                    sender.BackColor = System.Drawing.Color.DimGray
                    sender.Text = c.descripcionDistribucion & " " & c.numeracion
                End If

            ElseIf (colorBE = System.Drawing.Color.Green) Then
                Select Case distri.tipo
                    Case "PEDIDO"
                        If (distri.Devolucion > 0) Then
                            sender.BackColor = System.Drawing.Color.Peru
                            sender.Text = c.descripcionDistribucion & " - " & c.numeracion & vbNewLine & ("S/. " & FormatNumber(CDec(distri.Devolucion), 2))
                        End If
                    Case "PRE VENTA"
                        If (distri.Devolucion > 0) Then
                            sender.BackColor = System.Drawing.Color.DarkRed
                            sender.Text = c.descripcionDistribucion & " - " & c.numeracion & vbNewLine & ("S/. " & FormatNumber(CDec(distri.Devolucion), 2))
                        End If
                    Case Else
                        If (distri.TipoExistencia = "CREDITO") Then
                            sender.BackColor = System.Drawing.Color.DarkRed
                            sender.Text = c.descripcionDistribucion & " - " & c.numeracion & vbNewLine & ("S/. " & FormatNumber(CDec(distri.Devolucion), 2))
                        Else
                            sender.BackColor = System.Drawing.Color.DimGray
                            sender.Text = c.descripcionDistribucion & " " & c.numeracion & vbNewLine
                        End If
                End Select
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CargarDistribucionXTipoInfra(tipoEstado As String, listaEst As List(Of String))
        Try
            Dim atributos As New FileAttributes
            'Dim infoReader As FileInfo
            'Dim attributeReader As FileAttributes
            Dim distribucionInfraestructuraSA As New distribucionInfraestructuraSA
            Dim distribucionInfraestructuraBE As New distribucionInfraestructura

            Dim conteo As Integer = 0
            Dim sumatoriaBoton As Integer = 1

            '//IMAGNE 
            flowProductoDetalle.Controls.Clear()
            cboCategoria.Text = "TODO"
            distribucionInfraestructuraBE.tipo = "1"
            distribucionInfraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
            distribucionInfraestructuraBE.idEstablecimiento = GEstableciento.IdEstablecimiento
            distribucionInfraestructuraBE.tipo = "VNP"
            distribucionInfraestructuraBE.estado = "A"
            distribucionInfraestructuraBE.usuarioActualizacion = tipoEstado
            distribucionInfraestructuraBE.idInfraestructura = cboFormato.SelectedValue
            distribucionInfraestructuraBE.listaEstado = New List(Of String)
            distribucionInfraestructuraBE.listaEstado = listaEst
            distribucionInfraestructuraBE.SubCategoria = cboFormato.SelectedValue


            If (cboFormato.SelectedValue = 0) Then
                distribucionInfraestructuraBE.Categoria = 1
                listaDistribucion = distribucionInfraestructuraSA.getDistribucionInfraestructuraXtipo(distribucionInfraestructuraBE)
            Else
                distribucionInfraestructuraBE.Categoria = 3
                listaDistribucion = distribucionInfraestructuraSA.getDistribucionInfraestructuraXtipoInfra(distribucionInfraestructuraBE)
            End If

            For Each items In listaDistribucion
                Dim b As New RoundButton2

                b.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
                If (items.estado = "A") Then
                    b.BackColor = System.Drawing.Color.Green
                    If (items.menor > 0) Then
                        b.Text = items.descripcionDistribucion & " - " & items.numeracion & vbNewLine & (items.usuarioActualizacion) & vbNewLine & ("S/. " & FormatNumber(items.menor, 2))
                        b.Name = items.descripcionDistribucion & " - " & items.numeracion
                        b.TabIndex = 1
                    Else
                        b.Text = items.descripcionDistribucion & " - " & items.numeracion & vbNewLine & (items.usuarioActualizacion)
                        b.Name = items.descripcionDistribucion & " - " & items.numeracion
                        b.TabIndex = 0
                    End If
                ElseIf (items.estado = "U" And items.conteoPrecioMenor = 0) Then
                    b.BackColor = System.Drawing.Color.DimGray
                    b.Text = items.descripcionDistribucion & " - " & items.numeracion & vbNewLine & (items.usuarioActualizacion)
                    b.Name = items.descripcionDistribucion & " - " & items.numeracion
                    b.TabIndex = 0
                ElseIf (items.estado = "U" And items.conteoPrecioMenor > 0) Then
                    b.BackColor = System.Drawing.Color.DarkRed
                    b.Text = items.descripcionDistribucion & " - " & items.numeracion & vbNewLine & (items.usuarioActualizacion) & vbNewLine & "(C. X COBRAR)" & vbNewLine & ("S/. " & FormatNumber(items.conteoPrecioMenor, 2))
                    b.Name = items.descripcionDistribucion & " - " & items.numeracion
                    b.TabIndex = 0
                End If

                b.BeforeTouchSize = New System.Drawing.Size(83, 48)
                b.FlatStyle = System.Windows.Forms.FlatStyle.Flat
                b.ForeColor = System.Drawing.Color.White
                b.IsBackStageButton = False
                'b.Location = New System.Drawing.Point(51, 149)
                b.Size = New System.Drawing.Size(120, 100)


                'If (items.menor > 0) Then
                '    b.Text = items.descripcionDistribucion & " - " & items.numeracion & vbNewLine & ("S/. " & (items.menor))
                '    b.Name = items.descripcionDistribucion & " - " & items.numeracion
                '    b.TabIndex = 1
                'Else
                '    b.Text = items.descripcionDistribucion & " - " & items.numeracion
                '    b.Name = items.descripcionDistribucion & " - " & items.numeracion
                '    b.TabIndex = 0
                'End If

                b.Tag = items.idDistribucion

                '//BUSCA Y TRAE LA IMAGEN

                'Dim fileName As String = items.usuarioActualizacion

                'If ((fileName.Length > 0)) Then
                '    infoReader = My.Computer.FileSystem.GetFileInfo(fileName)
                '    attributeReader = infoReader.Attributes
                '    If (attributeReader And FileAttributes.Hidden) = 0 Then
                '        Dim fileDetail As FileInfo
                '        fileDetail = My.Computer.FileSystem.GetFileInfo(Path.GetFileName(fileName))
                '        If fileDetail.Extension = ".gif" Or fileDetail.Extension = ".bmp" _
                '                    Or fileDetail.Extension = ".jpg" Or fileDetail.Extension = ".jpeg" Or fileDetail.Extension = ".png" _
                '                    Or fileDetail.Extension = ".tif" Or fileDetail.Extension = ".tiff" Then
                '            lis.Items.Add(fileName)
                '            'Dim lv As New ListViewItem
                '            ImageList1.Images.Add(Image.FromFile(fileName))
                '        Else
                '            lis.Items.Add(fileName)
                '            ImageList1.Images.Add(Icon.ExtractAssociatedIcon(fileName))
                '        End If
                '    End If
                '    b.Image = ImageList1.Images(1)
                'Else
                b.Image = ImageList1.Images(0)
                'End If

                b.ImageAlign = ContentAlignment.MiddleCenter
                b.TextImageRelation = TextImageRelation.ImageAboveText
                'b.Top = (I - 1) * (b.Height + 3
                flowProductoDetalle.Controls.Add(b)
                AddHandler b.Click, AddressOf Butto1
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Butto1(sender As Object, e As EventArgs)
        Dim productoBE As New documentoventaAbarrotes
        Dim distribucionInfraestructuraSA As New distribucionInfraestructuraSA
        Dim distribucionInfraestructuraBE As New distribucionInfraestructura

        Try

            Dim c = CType(sender.Tag, distribucionInfraestructura)
            Select Case tipoLista
                Case "A"

                    Dim Formulario As Object = Nothing

                    'Creamos el "Document"
                    m_xmld = New XmlDocument()

                    'Cargamos el archivo
                    m_xmld.Load("C:\SPKconfiguration.xml")

                    'Obtenemos la lista de los nodos "name"
                    m_nodelist = m_xmld.SelectNodes("/spk/Restaurant")

                    'Iniciamos el ciclo de lectura
                    For Each m_node In m_nodelist
                        'Obtenemos el Formulario de inicio
                        Formulario = m_node.ChildNodes.Item(0).InnerText
                        Exit For
                    Next

                    If (sender.TABINDEX = 1) Then
                        sender.enabled = False
                        Dim frm As MetroForm = Application.OpenForms.OfType(Of MetroForm)().Where(Function(pre) pre.Name = "FormVentaTouch").SingleOrDefault
                        If frm Is Nothing Then
                            FormVentaTouch = New FormVentaTouch
                            FormVentaTouch.GetComboPrincipal()
                            FormVentaTouch.UCEstructuraCabeceraVentaV2.CargarCategorias()
                            If Formulario = "DIRECTO" Then
                                FormVentaTouch.ComboComprobante.Text = "PRE VENTA"
                            ElseIf Formulario = "PRECUENTA" Then
                                FormVentaTouch.ComboComprobante.Text = "PEDIDO"
                            End If
                            FormVentaTouch.ComboComprobante.ReadOnly = True
                            FormVentaTouch.UCEstructuraCabeceraVentaV2.txtInfraestructura.Text = c.descripcionDistribucion & " " & c.numeracion
                            FormVentaTouch.UCEstructuraCabeceraVentaV2.txtInfraestructura.Tag = c.idDistribucion
                            FormVentaTouch.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                            FormVentaTouch.ShowDialog()
                        Else
                            FormVentaTouch.WindowState = FormWindowState.Normal
                            FormVentaTouch.BringToFront()
                        End If


                        'Dim f As New FormVentaTouch()
                        'f.GetComboPrincipal()
                        'If Formulario = "DIRECTO" Then
                        '    f.ComboComprobante.Text = "PRE VENTA"
                        'ElseIf Formulario = "PRECUENTA" Then
                        '    f.ComboComprobante.Text = "PEDIDO"
                        'End If
                        'f.ComboComprobante.ReadOnly = True
                        ''f.UCEstructuraCabeceraVentaV2.txtIDResponsable = VENDEDOR.IDUsuario
                        ''f.UCEstructuraCabeceraVentaV2.txtNombreResponsable = VENDEDOR.Nombres & " " & VENDEDOR.ApellidoPaterno & " " & VENDEDOR.ApellidoMaterno
                        'f.UCEstructuraCabeceraVentaV2.txtInfraestructura.Text = c.descripcionDistribucion & " " & c.numeracion
                        'f.UCEstructuraCabeceraVentaV2.txtInfraestructura.Tag = c.idDistribucion
                        'f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        'f.StartPosition = FormStartPosition.CenterParent
                        'f.ShowDialog(Me)

                        If FormVentaTouch.Tag IsNot Nothing Then
                            Dim ent = CType(FormVentaTouch.Tag, distribucionInfraestructura)


                            If (ent.estado = "U") Then
                                Dim estado As String = String.Empty
                                estado = "U"

                                UPDATEINFRAESTRUCTURA(System.Drawing.Color.Green, estado, sender, ent)
                            End If

                        End If
                        sender.enabled = True
                    End If
                Case "T"
                    If (sender.BACKCOLOR = System.Drawing.Color.Green) Then
                        sender.enabled = False
                        Dim Formulario As Object = Nothing

                        'Creamos el "Document"
                        m_xmld = New XmlDocument()

                        'Cargamos el archivo
                        m_xmld.Load("C:\SPKconfiguration.xml")

                        'Obtenemos la lista de los nodos "name"
                        m_nodelist = m_xmld.SelectNodes("/spk/Restaurant")

                        'Iniciamos el ciclo de lectura
                        For Each m_node In m_nodelist
                            'Obtenemos el Formulario de inicio
                            Formulario = m_node.ChildNodes.Item(0).InnerText
                            Exit For
                        Next

                        If (sender.TABINDEX = 1) Then
                            'Dim f As New FormVentaTouch()
                            'f.GetComboPrincipal()

                            'If Formulario = "DIRECTO" Then
                            '    f.ComboComprobante.Text = "PRE VENTA"
                            'ElseIf Formulario = "PRECUENTA" Then
                            '    f.ComboComprobante.Text = "PEDIDO"
                            'End If

                            'f.ComboComprobante.ReadOnly = True
                            'f.UCEstructuraCabeceraVentaV2.txtInfraestructura.Text = c.descripcionDistribucion & " " & c.numeracion
                            'f.UCEstructuraCabeceraVentaV2.txtInfraestructura.Tag = c.idDistribucion
                            'f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                            'f.UCEstructuraCabeceraVentaV2.CargarCategorias()
                            'f.StartPosition = FormStartPosition.CenterParent
                            'f.ShowDialog(Me)


                            Dim frm As MetroForm = Application.OpenForms.OfType(Of MetroForm)().Where(Function(pre) pre.Name = "FormVentaTouch").SingleOrDefault
                            If frm Is Nothing Then
                                FormVentaTouch = New FormVentaTouch
                                FormVentaTouch.GetComboPrincipal()
                                FormVentaTouch.UCEstructuraCabeceraVentaV2.CargarCategorias()
                                If Formulario = "DIRECTO" Then
                                    FormVentaTouch.ComboComprobante.Text = "PRE VENTA"
                                ElseIf Formulario = "PRECUENTA" Then
                                    FormVentaTouch.ComboComprobante.Text = "PEDIDO"
                                End If
                                FormVentaTouch.ComboComprobante.ReadOnly = True
                                FormVentaTouch.UCEstructuraCabeceraVentaV2.txtInfraestructura.Text = c.descripcionDistribucion & " " & c.numeracion
                                FormVentaTouch.UCEstructuraCabeceraVentaV2.txtInfraestructura.Tag = c.idDistribucion
                                FormVentaTouch.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                                FormVentaTouch.ShowDialog()
                            Else
                                FormVentaTouch.WindowState = FormWindowState.Normal
                                FormVentaTouch.BringToFront()
                            End If

                            If FormVentaTouch.Tag IsNot Nothing Then

                                Dim ent = CType(FormVentaTouch.Tag, distribucionInfraestructura)

                                If (ent.estado = "U") Then
                                    Dim estado As String = String.Empty
                                    estado = "U"

                                    UPDATEINFRAESTRUCTURA(System.Drawing.Color.Green, estado, sender, ent)
                                End If
                            End If
                        End If
                        sender.enabled = True
                        'Dim frm As MetroForm = Application.OpenForms.OfType(Of MetroForm)().Where(Function(pre) pre.Name = "FormTablaPrincipal").SingleOrDefault


                    ElseIf (sender.BACKCOLOR = System.Drawing.Color.DimGray) Then
                        Dim listaEntrega = New List(Of String)
                        listaEntrega.Add("DC")
                        listaEntrega.Add("PN")
                        listaEntrega.Add("PR")
                        listaEntrega.Add("AN")

                        Dim listaTipoVenta = New List(Of String)
                        listaTipoVenta.Add("VP")
                        listaTipoVenta.Add("VNP")
                        listaTipoVenta.Add("VELC")
                        listaTipoVenta.Add("NOTE")

                        Dim listaTipoVenta2 = New List(Of String)
                        listaTipoVenta2.Add("1001")

                        FormPurchase.TabR_GestionInfraRestaurant.Visible = False

                        If FormPurchase.Tab_ListaPedidosRestaurant IsNot Nothing Then
                            FormPurchase.Tab_ListaPedidosRestaurant.txtInfraestructura.Tag = c.idDistribucion
                            FormPurchase.Tab_ListaPedidosRestaurant.txtInfraestructura.Text = c.descripcionDistribucion
                            FormPurchase.Tab_ListaPedidosRestaurant.lblHabitacion.Text = c.numeracion
                            FormPurchase.Tab_ListaPedidosRestaurant.GetDocumentoVentaID(c.idDistribucion, listaTipoVenta2, listaEntrega, listaTipoVenta)
                            FormPurchase.Tab_ListaPedidosRestaurant.ID = c.idDistribucion
                            FormPurchase.Tab_ListaPedidosRestaurant.Visible = True
                            FormPurchase.Tab_ListaPedidosRestaurant.BringToFront()
                            FormPurchase.Tab_ListaPedidosRestaurant.Show()
                        End If

                    ElseIf (sender.BACKCOLOR = System.Drawing.Color.DarkRed) Then
                        Dim Formulario As Object = Nothing

                        'Creamos el "Document"
                        m_xmld = New XmlDocument()

                        'Cargamos el archivo
                        m_xmld.Load("C:\SPKconfiguration.xml")

                        'Obtenemos la lista de los nodos "name"
                        m_nodelist = m_xmld.SelectNodes("/spk/Restaurant")

                        'Iniciamos el ciclo de lectura
                        For Each m_node In m_nodelist
                            'Obtenemos el Formulario de inicio
                            Formulario = m_node.ChildNodes.Item(0).InnerText
                            Exit For
                        Next


                        Dim listaEntrega = New List(Of String)
                        listaEntrega.Add("DC")
                        listaEntrega.Add("PN")
                        listaEntrega.Add("PR")
                        listaEntrega.Add("AN")

                        Dim listaTipoVenta = New List(Of String)
                        listaTipoVenta.Add("VP")
                        listaTipoVenta.Add("VNP")
                        listaTipoVenta.Add("VELC")
                        listaTipoVenta.Add("NOTE")

                        FormPurchase.TabR_GestionInfraRestaurant.Visible = False

                        If FormPurchase.Tab_ListaPedidosRestaurant IsNot Nothing Then
                            If Formulario = "DIRECTO" Then
                                Dim listaTipoVenta2 = New List(Of String)
                                listaTipoVenta2.Add("1000")
                                FormPurchase.Tab_ListaPedidosRestaurant.BunifuFlatButton7.Text = "COBRAR"
                                FormPurchase.Tab_ListaPedidosRestaurant.GetDocumentoVentaID(c.idDistribucion, listaTipoVenta2, listaEntrega, listaTipoVenta)
                                FormPurchase.Tab_ListaPedidosRestaurant.lblpendiente.Enabled = False
                            ElseIf Formulario = "PRECUENTA" Then
                                Dim listaTipoVenta2 = New List(Of String)
                                listaTipoVenta2.Add("1001")
                                FormPurchase.Tab_ListaPedidosRestaurant.BunifuFlatButton7.Text = "CONFIRMAR PRE CUENTA"
                                FormPurchase.Tab_ListaPedidosRestaurant.GetDocumentoVentaID(c.idDistribucion, listaTipoVenta2, listaEntrega, listaTipoVenta)
                                FormPurchase.Tab_ListaPedidosRestaurant.lblpendiente.Enabled = True
                            End If

                            FormPurchase.Tab_ListaPedidosRestaurant.txtInfraestructura.Tag = c.idDistribucion
                            FormPurchase.Tab_ListaPedidosRestaurant.txtInfraestructura.Text = c.descripcionDistribucion
                            FormPurchase.Tab_ListaPedidosRestaurant.lblHabitacion.Text = c.numeracion
                            FormPurchase.Tab_ListaPedidosRestaurant.ID = c.idDistribucion
                            FormPurchase.Tab_ListaPedidosRestaurant.Visible = True
                            FormPurchase.Tab_ListaPedidosRestaurant.BringToFront()
                            FormPurchase.Tab_ListaPedidosRestaurant.Show()
                        End If

                    ElseIf (sender.BACKCOLOR = System.Drawing.Color.Peru) Then
                        Dim Formulario As Object = Nothing

                        'Creamos el "Document"
                        m_xmld = New XmlDocument()

                        'Cargamos el archivo
                        m_xmld.Load("C:\SPKconfiguration.xml")

                        'Obtenemos la lista de los nodos "name"
                        m_nodelist = m_xmld.SelectNodes("/spk/Restaurant")

                        'Iniciamos el ciclo de lectura
                        For Each m_node In m_nodelist
                            'Obtenemos el Formulario de inicio
                            Formulario = m_node.ChildNodes.Item(0).InnerText
                            Exit For
                        Next


                        Dim listaEntrega = New List(Of String)
                        listaEntrega.Add("DC")
                        listaEntrega.Add("PN")
                        listaEntrega.Add("PR")
                        listaEntrega.Add("AN")

                        Dim listaTipoVenta = New List(Of String)
                        listaTipoVenta.Add("VP")
                        listaTipoVenta.Add("VNP")
                        listaTipoVenta.Add("VELC")
                        listaTipoVenta.Add("NOTE")

                        FormPurchase.TabR_GestionInfraRestaurant.Visible = False

                        If FormPurchase.Tab_ListaPedidosRestaurant IsNot Nothing Then
                            If Formulario = "DIRECTO" Then
                                Dim listaTipoVenta2 = New List(Of String)
                                listaTipoVenta2.Add("1000")
                                FormPurchase.Tab_ListaPedidosRestaurant.BunifuFlatButton7.Text = "CONFIRMAR PRE CUENTA"
                                FormPurchase.Tab_ListaPedidosRestaurant.GetDocumentoVentaID(c.idDistribucion, listaTipoVenta2, listaEntrega, listaTipoVenta)
                                FormPurchase.Tab_ListaPedidosRestaurant.lblpendiente.Enabled = True
                            ElseIf Formulario = "PRECUENTA" Then
                                Dim listaTipoVenta2 = New List(Of String)
                                listaTipoVenta2.Add("1001")
                                FormPurchase.Tab_ListaPedidosRestaurant.BunifuFlatButton7.Text = "COBRAR"
                                FormPurchase.Tab_ListaPedidosRestaurant.GetDocumentoVentaID(c.idDistribucion, listaTipoVenta2, listaEntrega, listaTipoVenta)
                                FormPurchase.Tab_ListaPedidosRestaurant.lblpendiente.Enabled = False
                            End If

                            FormPurchase.Tab_ListaPedidosRestaurant.txtInfraestructura.Tag = c.idDistribucion
                            FormPurchase.Tab_ListaPedidosRestaurant.txtInfraestructura.Text = c.descripcionDistribucion
                            FormPurchase.Tab_ListaPedidosRestaurant.lblHabitacion.Text = c.numeracion
                            FormPurchase.Tab_ListaPedidosRestaurant.ID = c.idDistribucion
                            FormPurchase.Tab_ListaPedidosRestaurant.Visible = True
                            FormPurchase.Tab_ListaPedidosRestaurant.BringToFront()
                            FormPurchase.Tab_ListaPedidosRestaurant.Show()
                        End If

                    ElseIf (sender.BACKCOLOR = System.Drawing.Color.OrangeRed) Then
                        If MessageBox.Show("¿Desea liberar la mesa?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            Dim documentoventaSA As New documentoPedidoDetSA
                            Dim documentoventaBE As New distribucionInfraestructura

                            distribucionInfraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
                            distribucionInfraestructuraBE.idDistribucion = c.idDistribucion
                            distribucionInfraestructuraBE.estado = "A"

                            documentoventaSA.EditarEstadoDocPedidoMasivo(distribucionInfraestructuraBE)

                            CheckCtasXCobrar.Checked = False
                            CargarDefault()
                        End If

                    ElseIf (sender.BACKCOLOR = System.Drawing.Color.Peru) Then

                        Dim Formulario As Object = Nothing

                        'Creamos el "Document"
                        m_xmld = New XmlDocument()

                        'Cargamos el archivo
                        m_xmld.Load("C:\SPKconfiguration.xml")

                        'Obtenemos la lista de los nodos "name"
                        m_nodelist = m_xmld.SelectNodes("/spk/Restaurant")

                        'Iniciamos el ciclo de lectura
                        For Each m_node In m_nodelist
                            'Obtenemos el Formulario de inicio
                            Formulario = m_node.ChildNodes.Item(0).InnerText
                            Exit For
                        Next


                        Dim listaEntrega = New List(Of String)
                        listaEntrega.Add("DC")
                        listaEntrega.Add("PN")
                        listaEntrega.Add("PR")
                        listaEntrega.Add("AN")

                        Dim listaTipoVenta = New List(Of String)
                        listaTipoVenta.Add("VP")
                        listaTipoVenta.Add("VNP")
                        listaTipoVenta.Add("VELC")
                        listaTipoVenta.Add("NOTE")

                        FormPurchase.TabR_GestionInfraRestaurant.Visible = False

                        If FormPurchase.Tab_ListaPedidosRestaurant IsNot Nothing Then
                            If Formulario = "DIRECTO" Then
                                Dim listaTipoVenta2 = New List(Of String)
                                listaTipoVenta2.Add("1000")
                                FormPurchase.Tab_ListaPedidosRestaurant.BunifuFlatButton7.Text = "CONFIRMAR PRE CUENTA"
                                FormPurchase.Tab_ListaPedidosRestaurant.GetDocumentoVentaID(c.idDistribucion, listaTipoVenta2, listaEntrega, listaTipoVenta)
                                FormPurchase.Tab_ListaPedidosRestaurant.lblpendiente.Enabled = True
                            ElseIf Formulario = "PRECUENTA" Then
                                Dim listaTipoVenta2 = New List(Of String)
                                listaTipoVenta2.Add("1001")
                                FormPurchase.Tab_ListaPedidosRestaurant.BunifuFlatButton7.Text = "COBRAR"
                                FormPurchase.Tab_ListaPedidosRestaurant.GetDocumentoVentaID(c.idDistribucion, listaTipoVenta2, listaEntrega, listaTipoVenta)
                                FormPurchase.Tab_ListaPedidosRestaurant.lblpendiente.Enabled = False
                            End If

                            FormPurchase.Tab_ListaPedidosRestaurant.txtInfraestructura.Tag = c.idDistribucion
                            FormPurchase.Tab_ListaPedidosRestaurant.txtInfraestructura.Text = c.descripcionDistribucion
                            FormPurchase.Tab_ListaPedidosRestaurant.lblHabitacion.Text = c.numeracion
                            FormPurchase.Tab_ListaPedidosRestaurant.ID = c.idDistribucion
                            FormPurchase.Tab_ListaPedidosRestaurant.Visible = True
                            FormPurchase.Tab_ListaPedidosRestaurant.BringToFront()
                            FormPurchase.Tab_ListaPedidosRestaurant.Show()
                        End If

                        CargarDefault()

                    End If

                Case "U"

                    Dim Formulario As Object = Nothing

                    'Creamos el "Document"
                    m_xmld = New XmlDocument()

                    'Cargamos el archivo
                    m_xmld.Load("C:\SPKconfiguration.xml")

                    'Obtenemos la lista de los nodos "name"
                    m_nodelist = m_xmld.SelectNodes("/spk/Restaurant")

                    'Iniciamos el ciclo de lectura
                    For Each m_node In m_nodelist
                        'Obtenemos el Formulario de inicio
                        Formulario = m_node.ChildNodes.Item(0).InnerText
                        Exit For
                    Next


                    Dim listaEntrega = New List(Of String)
                    listaEntrega.Add("DC")
                    listaEntrega.Add("PN")
                    listaEntrega.Add("PR")
                    listaEntrega.Add("AN")

                    Dim listaTipoVenta = New List(Of String)
                    listaTipoVenta.Add("VP")
                    listaTipoVenta.Add("VNP")
                    listaTipoVenta.Add("VELC")
                    listaTipoVenta.Add("NOTE")

                    FormPurchase.TabR_GestionInfraRestaurant.Visible = False

                    If FormPurchase.Tab_ListaPedidosRestaurant IsNot Nothing Then
                        If Formulario = "DIRECTO" Then
                            Dim listaTipoVenta2 = New List(Of String)
                            listaTipoVenta2.Add("1000")
                            FormPurchase.Tab_ListaPedidosRestaurant.BunifuFlatButton7.Text = "CONFIRMAR PRE CUENTA"
                            FormPurchase.Tab_ListaPedidosRestaurant.GetDocumentoVentaID(c.idDistribucion, listaTipoVenta2, listaEntrega, listaTipoVenta)
                            FormPurchase.Tab_ListaPedidosRestaurant.lblpendiente.Enabled = True
                        ElseIf Formulario = "PRECUENTA" Then
                            Dim listaTipoVenta2 = New List(Of String)
                            listaTipoVenta2.Add("1001")
                            FormPurchase.Tab_ListaPedidosRestaurant.BunifuFlatButton7.Text = "COBRAR"
                            FormPurchase.Tab_ListaPedidosRestaurant.GetDocumentoVentaID(c.idDistribucion, listaTipoVenta2, listaEntrega, listaTipoVenta)
                            FormPurchase.Tab_ListaPedidosRestaurant.lblpendiente.Enabled = False
                        End If

                        FormPurchase.Tab_ListaPedidosRestaurant.txtInfraestructura.Tag = c.idDistribucion
                        FormPurchase.Tab_ListaPedidosRestaurant.txtInfraestructura.Text = c.descripcionDistribucion
                        FormPurchase.Tab_ListaPedidosRestaurant.lblHabitacion.Text = c.numeracion
                        FormPurchase.Tab_ListaPedidosRestaurant.ID = c.idDistribucion
                        FormPurchase.Tab_ListaPedidosRestaurant.Visible = True
                        FormPurchase.Tab_ListaPedidosRestaurant.BringToFront()
                        FormPurchase.Tab_ListaPedidosRestaurant.Show()
                    End If

                Case "P"

                    Dim f As New FormCanastaPedidoDeVentasInfra()
                    'f.IdDistribucion = sender.tag
                    f.listaDistribucion = New List(Of String)
                    f.listaDistribucion.Add(c.idDistribucion)
                    f.txtInfraestructura.Tag = c.idDistribucion
                    f.txtInfraestructura.Text = c.descripcionDistribucion & " " & c.numeracion
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()
                    CargarDefault()
                    'RefrescarCobros()

                Case "C"
                    'PictureLoad.Visible = True

                    'Dim documentoventaSA As New documentoVentaAbarrotesDetSA
                    'Dim documentoventaBE As New documentoventaAbarrotesDet
                    'Dim documentoBE As New documento

                    'documentoventaBE.idDistribucion = c.idDistribucion
                    'documentoventaBE.estadoDistribucion = "A"

                    'documentoBE = documentoventaSA.GetUbicar_ListaDocumento(documentoventaBE)

                    'Dim f As New frmConfirmacionPedido(documentoBE.ListaDocumentoID)
                    'f.txtInfraestructura.Tag = c.idDistribucion
                    'f.txtInfraestructura.Text = c.descripcionDistribucion & " " & c.numeracion
                    'f.StartPosition = FormStartPosition.CenterParent
                    'f.ShowDialog()
                    'CargarDefault()

                    Dim Formulario As Object = Nothing

                    'Creamos el "Document"
                    m_xmld = New XmlDocument()

                    'Cargamos el archivo
                    m_xmld.Load("C:\SPKconfiguration.xml")

                    'Obtenemos la lista de los nodos "name"
                    m_nodelist = m_xmld.SelectNodes("/spk/Restaurant")

                    'Iniciamos el ciclo de lectura
                    For Each m_node In m_nodelist
                        'Obtenemos el Formulario de inicio
                        Formulario = m_node.ChildNodes.Item(0).InnerText
                        Exit For
                    Next


                    Dim listaEntrega = New List(Of String)
                    listaEntrega.Add("DC")
                    listaEntrega.Add("PN")
                    listaEntrega.Add("PR")
                    listaEntrega.Add("AN")

                    Dim listaTipoVenta = New List(Of String)
                    listaTipoVenta.Add("VP")
                    listaTipoVenta.Add("VNP")
                    listaTipoVenta.Add("VELC")
                    listaTipoVenta.Add("NOTE")

                    FormPurchase.TabR_GestionInfraRestaurant.Visible = False

                    If FormPurchase.Tab_ListaPedidosRestaurant IsNot Nothing Then
                        If Formulario = "DIRECTO" Then
                            Dim listaTipoVenta2 = New List(Of String)
                            listaTipoVenta2.Add("1000")
                            FormPurchase.Tab_ListaPedidosRestaurant.BunifuFlatButton7.Text = "CONFIRMAR PRE CUENTA"
                            FormPurchase.Tab_ListaPedidosRestaurant.GetDocumentoVentaID(c.idDistribucion, listaTipoVenta2, listaEntrega, listaTipoVenta)
                            FormPurchase.Tab_ListaPedidosRestaurant.lblpendiente.Enabled = True
                        ElseIf Formulario = "PRECUENTA" Then
                            Dim listaTipoVenta2 = New List(Of String)
                            listaTipoVenta2.Add("1001")
                            FormPurchase.Tab_ListaPedidosRestaurant.BunifuFlatButton7.Text = "COBRAR"
                            FormPurchase.Tab_ListaPedidosRestaurant.GetDocumentoVentaID(c.idDistribucion, listaTipoVenta2, listaEntrega, listaTipoVenta)
                            FormPurchase.Tab_ListaPedidosRestaurant.lblpendiente.Enabled = False
                        End If

                        FormPurchase.Tab_ListaPedidosRestaurant.txtInfraestructura.Tag = c.idDistribucion
                        FormPurchase.Tab_ListaPedidosRestaurant.txtInfraestructura.Text = c.descripcionDistribucion
                        FormPurchase.Tab_ListaPedidosRestaurant.lblHabitacion.Text = c.numeracion
                        FormPurchase.Tab_ListaPedidosRestaurant.ID = c.idDistribucion
                        FormPurchase.Tab_ListaPedidosRestaurant.Visible = True
                        FormPurchase.Tab_ListaPedidosRestaurant.BringToFront()
                        FormPurchase.Tab_ListaPedidosRestaurant.Show()
                    End If


                Case "L"


                    If (sender.BACKCOLOR = System.Drawing.Color.OrangeRed) Then
                        If MessageBox.Show("¿Desea liberar la Mesa?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            Dim documentoventaSA As New documentoPedidoDetSA
                            Dim documentoventaBE As New distribucionInfraestructura

                            distribucionInfraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
                            distribucionInfraestructuraBE.idDistribucion = c.idDistribucion
                            distribucionInfraestructuraBE.estado = "A"

                            documentoventaSA.EditarEstadoDocPedidoMasivo(distribucionInfraestructuraBE)

                            CheckCtasXCobrar.Checked = False
                            CargarDefault()
                        End If
                    End If
            End Select

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub BunifuFlatButton17_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton17.Click
        lblCtasXcobrar.Visible = False
        CheckCtasXCobrar.Visible = False
        CheckCtasXCobrar.Checked = False
        'Dim listaItem As List(Of String)
        'listaItem = New List(Of String)
        'listaItem.Add("A")
        'listaItem.Add("U")
        'listaItem.Add("P")
        'listaItem.Add("L")
        ''CargarCombos()
        Dim estado As String = String.Empty
        estado = "U, A, P, L"

        LLAMARiNFRAESTRUCTURA(estado, "VPN", 1, "TD")
        tipoLista = "T"
        'lblFiltro.Visible = True
        'cboFormato.Visible = True
    End Sub

    Private Sub CboFormato_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboFormato.SelectionChangeCommitted
        If (tipoLista = "T") Then
            Dim listaItem As List(Of String)
            listaItem = New List(Of String)
            listaItem.Add("A")
            listaItem.Add("U")
            listaItem.Add("P")
            listaItem.Add("L")
            Dim estado As String = String.Empty
            estado = "U,A,P,L"
            CargarDistribucionXTipoInfra(estado, listaItem)
        ElseIf (tipoLista = "U") Then
            Dim listaItem As List(Of String)
            listaItem = New List(Of String)
            listaItem.Add("U")
            Dim estado As String = String.Empty
            estado = "U"
            CargarDistribucionXTipoInfra(estado, listaItem)
        ElseIf (tipoLista = "A") Then
            Dim listaItem As List(Of String)
            listaItem = New List(Of String)
            listaItem.Add("A")
            Dim estado As String = String.Empty
            estado = "A"
            CargarDistribucionXTipoInfra(estado, listaItem)
        End If
    End Sub

    Private Sub CheckCtasXCobrar_OnChange(sender As Object, e As EventArgs) Handles CheckCtasXCobrar.OnChange
        Try
            If (CheckCtasXCobrar.Checked = False) Then
                'Dim listaItem As List(Of String)
                'listaItem = New List(Of String)
                'listaItem.Add("U")
                ''CargarCombos()

                Dim estado As String = String.Empty
                estado = "U"

                'LLAMARiNFRAESTRUCTURAlIMPIEZA(estado, "L")
                tipoLista = "L"
                'lblFiltro.Visible = True
                'cboFormato.Visible = True
            ElseIf (CheckCtasXCobrar.Checked = True) Then
                'Dim listaItem As List(Of String)
                'listaItem = New List(Of String)
                'listaItem.Add("U")
                ''CargarCombos()
                Dim estado As String = String.Empty
                estado = "U"
                'LLAMARiNFRAESTRUCTURAlIMPIEZA(estado, "U")
                tipoLista = "L"
                'lblFiltro.Visible = True
                'cboFormato.Visible = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click
        lblCtasXcobrar.Visible = False
        CheckCtasXCobrar.Visible = False
        CheckCtasXCobrar.Checked = False

        Dim estado As String = String.Empty
        estado = "U"

        LLAMARiNFRAESTRUCTURA(estado, "VP", 5, "CF")
        tipoLista = "C"
        'lblFiltro.Visible = True
        'cboFormato.Visible = True
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        lblCtasXcobrar.Visible = False
        CheckCtasXCobrar.Visible = False
        CheckCtasXCobrar.Checked = False

        Dim estado As String = String.Empty
        estado = "L"
        LLAMARiNFRAESTRUCTURA(estado, "VPN", 1, "EL")
        tipoLista = "L"
        'lblFiltro.Visible = True
        'cboFormato.Visible = True
    End Sub

    Private Sub BunifuFlatButton10_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton10.Click
        Try
            FormPurchase.TabR_GestionInfraRestaurant.Visible = False

            If FormPurchase.TabP_RestaurantMaster IsNot Nothing Then
                FormPurchase.TabP_RestaurantMaster.Visible = True
                FormPurchase.TabP_RestaurantMaster.BringToFront()
                FormPurchase.TabP_RestaurantMaster.Show()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    'Private Sub BgProveedor_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs)
    '    'pnCargaDatos.Visible = True

    '    Dim estado As String = String.Empty
    '    estado = "U, A,P, L"
    '    tipoLista = "T"


    '    Dim atributos As New FileAttributes
    '    Dim distribucionInfraestructuraSA As New distribucionInfraestructuraSA
    '    Dim distribucionInfraestructuraBE As New distribucionInfraestructura
    '    Dim conteo As Integer = 0
    '    Dim sumatoriaBoton As Integer = 1

    '    '//IMAGNE 
    '    flowProductoDetalle.Controls.Clear()

    '    distribucionInfraestructuraBE.tipo = "1"
    '    distribucionInfraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
    '    distribucionInfraestructuraBE.idEstablecimiento = GEstableciento.IdEstablecimiento
    '    distribucionInfraestructuraBE.tipo = "VP"
    '    distribucionInfraestructuraBE.estado = "A"
    '    distribucionInfraestructuraBE.usuarioActualizacion = estado
    '    distribucionInfraestructuraBE.Categoria = "1"

    '    Select Case "DP"
    '        Case "CF"
    '            listaDistribucion = distribucionInfraestructuraSA.getDistribucionInfraestructuraXtipo(distribucionInfraestructuraBE)
    '        Case Else
    '            listaDistribucion = distribucionInfraestructuraSA.getInfraestructura(distribucionInfraestructuraBE)
    '    End Select

    'End Sub

    'Private Sub BgProveedor_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs)

    '    DibujarControl(listaDistribucion)
    '    pnCargaDatos.Visible = False
    'End Sub

#End Region

#Region "Events"


#End Region

End Class
