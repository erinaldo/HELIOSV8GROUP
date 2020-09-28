Imports System.IO
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class TabMG_GestionInfraestructura

#Region "Attributes"
    Dim tipoLista As String
    Dim lis As New ListBox
    Dim ListaproductosVendidos As List(Of documentoventaAbarrotesDet)
    Dim listaDistribucion As New List(Of distribucionInfraestructura)
    Public Property FormPurchase As Tab_RecepcionControl

#End Region

#Region "Constructors"
    Public Sub New(formRepPiscina As Tab_RecepcionControl)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormPurchase = formRepPiscina
        CargarCombos()
        CargarDefault()
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


        objServicioInfraBE.idEmpresa = Gempresas.IdEmpresaRuc
        objServicioInfraBE.idEstablecimiento = GEstableciento.IdEstablecimiento

        objServicioInfraDefault.idTipoServicio = 0
        objServicioInfraDefault.descripcionTipoServicio = "TODO"

        listaServicioInfra.Add(objServicioInfraDefault)
        listaServicioInfra.AddRange(tipoServicioInfraestructuraSA.GetUbicartipoServicioInfra(objServicioInfraBE))

        cboCategoria.ValueMember = "idTipoServicio"
        cboCategoria.DisplayMember = "descripcionTipoServicio"
        cboCategoria.DataSource = listaServicioInfra
        cboCategoria.SelectedValue = 0

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

        LLAMARiNFRAESTRUCTURA(estado, "A")
        tipoLista = "A"
        lblFiltro.Visible = True
        cboFormato.Visible = True
    End Sub

    Private Sub BunifuFlatButton7_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton7.Click
        lblCtasXcobrar.Visible = False
        CheckCtasXCobrar.Visible = False
        CheckCtasXCobrar.Checked = False
        'Dim listaItem As List(Of String)
        'listaItem = New List(Of String)
        'listaItem.Add("U")
        ''CargarCombos()
        Dim estado As String = String.Empty
        estado = "U"
        LLAMARiNFRAESTRUCTURA(estado, "U")
        tipoLista = "U"
        lblFiltro.Visible = True
        cboFormato.Visible = True
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
        estado = "U"

        LLAMARiNFRAESTRUCTURA(estado, "P")
        tipoLista = "P"
        lblFiltro.Visible = True
        cboFormato.Visible = True
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
        LLAMARiNFRAESTRUCTURA(estado, "P")
        tipoLista = "P"
        lblFiltro.Visible = True
        cboFormato.Visible = True
    End Sub

    Private Sub RefrescarLimpieza()
        'Dim listaItem As List(Of String)
        'listaItem = New List(Of String)
        'listaItem.Add("U")
        ''CargarCombos()
        Dim estado As String = String.Empty
        estado = "U"
        LLAMARiNFRAESTRUCTURAlIMPIEZA(estado, "U")
        tipoLista = "L"
        lblFiltro.Visible = True
        cboFormato.Visible = True
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

    Public Sub LLAMARiNFRAESTRUCTURA(tipoEstado As String, Tipo As String)
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
            distribucionInfraestructuraBE.tipo = "VNP"
            distribucionInfraestructuraBE.estado = "A"
            distribucionInfraestructuraBE.usuarioActualizacion = tipoEstado
            distribucionInfraestructuraBE.Categoria = 1

            'distribucionInfraestructuraBE.listaEstado = New List(Of String)
            'distribucionInfraestructuraBE.listaEstado = (tipoEstado)

            listaDistribucion = distribucionInfraestructuraSA.getDistribucionInfraestructuraXtipo(distribucionInfraestructuraBE)

            Select Case Tipo
                Case "P"
                    listaDistribucion = listaDistribucion.Where(Function(O) O.conteoPrecioMenor > 0).ToList
            End Select

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
                    b.BackColor = System.Drawing.Color.DarkGray
                    b.Text = items.descripcionDistribucion & " - " & items.numeracion & vbNewLine & (items.usuarioActualizacion)
                    b.Name = items.descripcionDistribucion & " - " & items.numeracion
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
                b.Tag = items.idDistribucion
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

    Public Sub LLAMARiNFRAESTRUCTURAlIMPIEZA(tipoEstado As String, Tipo As String)
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
            distribucionInfraestructuraBE.tipo = "VNP"
            distribucionInfraestructuraBE.estado = "A"
            distribucionInfraestructuraBE.usuarioActualizacion = tipoEstado
            distribucionInfraestructuraBE.Categoria = 1

            listaDistribucion = distribucionInfraestructuraSA.getDistribucionInfraestructuraXtipo(distribucionInfraestructuraBE)

            Select Case Tipo
                Case "L"
                    listaDistribucion = listaDistribucion.Where(Function(O) O.conteoPrecioMenor = 0).ToList
            End Select

            For Each items In listaDistribucion
                Dim b As New RoundButton2
                b.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
                If (items.estado = "U" And items.conteoPrecioMenor = 0) Then
                    b.BackColor = System.Drawing.Color.OrangeRed
                    b.Text = items.descripcionDistribucion & " - " & items.numeracion & vbNewLine & (items.usuarioActualizacion)
                    b.Name = items.descripcionDistribucion & " - " & items.numeracion
                ElseIf (items.estado = "U" And items.conteoPrecioMenor > 0) Then
                    b.BackColor = System.Drawing.Color.OrangeRed
                    b.Text = items.descripcionDistribucion & " - " & items.numeracion & vbNewLine & (items.usuarioActualizacion) & vbNewLine & "(C. X COBRAR)" & vbNewLine & ("S/. " & FormatNumber(items.conteoPrecioMenor, 2))
                    b.Name = items.descripcionDistribucion & " - " & items.numeracion

                End If
                b.TabIndex = 0
                b.BeforeTouchSize = New System.Drawing.Size(83, 48)
                b.FlatStyle = System.Windows.Forms.FlatStyle.Flat
                b.ForeColor = System.Drawing.Color.White
                b.IsBackStageButton = False
                b.Size = New System.Drawing.Size(120, 100)
                b.Tag = items.idDistribucion
                '//BUSCA Y TRAE LA IMAGEN
                b.Image = ImageList1.Images(0)
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


    Public Sub CargarDefault()
        'Dim listaItem As List(Of String)
        'listaItem = New List(Of String)
        'listaItem.Add("A")
        'listaItem.Add("U")
        'listaItem.Add("P")
        ''CargarCombos()
        Dim estado As String = String.Empty
        estado = "U, A,P"
        LLAMARiNFRAESTRUCTURA(estado, "T")
        tipoLista = "T"
        lblFiltro.Visible = True
        cboFormato.Visible = True
    End Sub

    Private Sub ActualizarInfra()
        'Dim listaItem As List(Of String)
        'listaItem = New List(Of String)
        'listaItem.Add("A")
        'listaItem.Add("U")
        'listaItem.Add("P")
        Dim estado As String = String.Empty
        estado = "U, A, P"
        LLAMARiNFRAESTRUCTURA(estado, "T")
        tipoLista = "T"
        lblFiltro.Visible = True
        cboFormato.Visible = True
        cboFormato.SelectedValue = 0
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
                    b.BackColor = System.Drawing.Color.DarkGray

                    b.Text = items.descripcionDistribucion & " - " & items.numeracion & vbNewLine & (items.usuarioActualizacion)
                    b.Name = items.descripcionDistribucion & " - " & items.numeracion

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

    Private Sub CargarDistribucionXTipoCategoria(tipoEstado As String, listaEst As List(Of String))
        Try
            Dim atributos As New FileAttributes
            Dim distribucionInfraestructuraSA As New distribucionInfraestructuraSA
            Dim distribucionInfraestructuraBE As New distribucionInfraestructura
            Dim conteo As Integer = 0
            Dim sumatoriaBoton As Integer = 1

            '//IMAGNE 
            flowProductoDetalle.Controls.Clear()
            cboFormato.Text = "TODO"

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

            If (cboCategoria.SelectedValue = 0) Then
                distribucionInfraestructuraBE.Categoria = 1
                listaDistribucion = distribucionInfraestructuraSA.getDistribucionInfraestructuraXtipo(distribucionInfraestructuraBE)
            Else
                distribucionInfraestructuraBE.Categoria = 2
                listaDistribucion = distribucionInfraestructuraSA.getDistribucionInfraestructuraXCategoria(distribucionInfraestructuraBE)
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
                    b.BackColor = System.Drawing.Color.DarkGray

                    b.Text = items.descripcionDistribucion & " - " & items.numeracion & vbNewLine & (items.usuarioActualizacion)
                    b.Name = items.descripcionDistribucion & " - " & items.numeracion

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
                b.Size = New System.Drawing.Size(120, 100)
                b.Tag = items.idDistribucion
                b.Image = ImageList1.Images(0)


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
        Dim obj As documentoventaAbarrotesDet

        Try

            Select Case tipoLista
                Case "A"
                    Dim VENDEDOR = GetCodigoVendedor()

                    If (Not IsNothing(VENDEDOR)) Then

                        distribucionInfraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
                        distribucionInfraestructuraBE.idDistribucion = sender.tag
                        distribucionInfraestructuraBE.estado = "U"
                        distribucionInfraestructuraSA.updateDistribucionxID(distribucionInfraestructuraBE)

                        If (sender.TABINDEX = 1) Then

                            Dim CONSULTA = (From ListaItem In listaDistribucion Where ListaItem.idDistribucion = sender.tag).FirstOrDefault

                            If (Not IsNothing(CONSULTA)) Then

                                Dim canti As Decimal = 1
                                Dim baseImponible As Decimal = 0
                                Dim Iva As Decimal = 0
                                'Dim sub_total As Decimal = canti * eq.fraccionUnidad.GetValueOrDefault
                                Dim total As Decimal = canti * CDec(CONSULTA.menor)   'Decimal.Parse(r.GetValue("totalmn"))
                                baseImponible = Math.Round(CDec(CalculoBaseImponible(total, 1.18)), 2)
                                Iva = Math.Round(total - baseImponible, 2)

                                ListaproductosVendidos = New List(Of documentoventaAbarrotesDet)
                                obj = New documentoventaAbarrotesDet
                                Dim cod = System.Guid.NewGuid.ToString()
                                obj.CodigoCosto = 1
                                obj.CustomProducto = New detalleitems
                                obj.CustomProducto.origenProducto = 1
                                obj.CustomProducto.descripcionItem = sender.NAME
                                obj.CustomProducto.unidad1 = "NIU"
                                obj.CustomProducto.codigodetalle = sender.TAG
                                obj.CustomProducto.tipoExistencia = "IF"
                                obj.CustomEquivalencia = New detalleitem_equivalencias
                                obj.CustomEquivalencia.fraccionUnidad = 0
                                obj.idItem = sender.tag
                                obj.DetalleItem = sender.TEXT
                                obj.catalogo_id = 0
                                obj.monto1 = 1
                                obj.unidad1 = "NIU"
                                obj.tipoExistencia = "IF"
                                obj.montokardex = baseImponible
                                obj.montoIgv = Iva
                                obj.importeMN = CDec(total)
                                obj.PrecioUnitarioVentaMN = CDec(CONSULTA.menor)
                                obj.precioUnitario = CDec(CONSULTA.menor)
                                obj.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                                obj.CustomEquivalencia.equivalencia_id = 0
                                obj.CustomCatalogo = New detalleitemequivalencia_catalogos
                                obj.CustomCatalogo.idCatalogo = 0
                                obj.FlagBonif = False
                                obj.CustomListaInventarioMovimiento = New List(Of InventarioMovimiento)
                                'obj.CustomDocumentoCaja = New List(Of documentoCaja)
                                ListaproductosVendidos.Add(obj)

                                Dim f As New FormVentaNuevaTouch()
                                f.UCEstructuraCabeceraVentaV2.txtIDResponsable = VENDEDOR.IDUsuario
                                f.UCEstructuraCabeceraVentaV2.txtNombreResponsable = VENDEDOR.Nombres & " " & VENDEDOR.ApellidoPaterno & " " & VENDEDOR.ApellidoMaterno
                                f.UCEstructuraCabeceraVentaV2.txtInfraestructura.Text = sender.NAME
                                f.UCEstructuraCabeceraVentaV2.txtInfraestructura.Tag = sender.tag
                                f.UCEstructuraCabeceraVentaV2.ListaproductosVendidos.Add(obj)
                                f.UCEstructuraCabeceraVentaV2.LoadCanastaVentas(ListaproductosVendidos)
                                f.UCEstructuraCabeceraVentaV2.GetTotalesDocumento()
                                f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                                f.StartPosition = FormStartPosition.CenterParent
                                f.ShowDialog()
                                ActualizarInfra()
                            Else
                                MessageBox.Show("Verificar los datos")
                            End If

                        Else
                            Dim f As New FormVentaNuevaTouch()
                            f.UCEstructuraCabeceraVentaV2.txtIDResponsable = VENDEDOR.IDUsuario
                            f.UCEstructuraCabeceraVentaV2.txtNombreResponsable = VENDEDOR.Nombres & " " & VENDEDOR.ApellidoPaterno & " " & VENDEDOR.ApellidoMaterno
                            f.UCEstructuraCabeceraVentaV2.txtInfraestructura.Text = sender.text
                            f.UCEstructuraCabeceraVentaV2.txtInfraestructura.Tag = sender.tag
                            f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                            f.StartPosition = FormStartPosition.CenterParent
                            f.Show(Me)

                        End If
                    End If
                Case "T"
                    If (sender.BACKCOLOR = System.Drawing.Color.Green) Then
                        Dim VENDEDOR = GetCodigoVendedor()

                        If (Not IsNothing(VENDEDOR)) Then

                            distribucionInfraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
                            distribucionInfraestructuraBE.idDistribucion = sender.tag
                            distribucionInfraestructuraBE.estado = "U"
                            distribucionInfraestructuraSA.updateDistribucionxID(distribucionInfraestructuraBE)

                            If (sender.TABINDEX = 1) Then

                                Dim CONSULTA = (From ListaItem In listaDistribucion Where ListaItem.idDistribucion = sender.tag).FirstOrDefault

                                If (Not IsNothing(CONSULTA)) Then
                                    Dim canti As Decimal = 1
                                    Dim baseImponible As Decimal = 0
                                    Dim Iva As Decimal = 0
                                    'Dim sub_total As Decimal = canti * eq.fraccionUnidad.GetValueOrDefault
                                    Dim total As Decimal = canti * CDec(CONSULTA.menor)   'Decimal.Parse(r.GetValue("totalmn"))
                                    baseImponible = Math.Round(CDec(CalculoBaseImponible(total, 1.18)), 2)
                                    Iva = Math.Round(total - baseImponible, 2)

                                    ListaproductosVendidos = New List(Of documentoventaAbarrotesDet)
                                    obj = New documentoventaAbarrotesDet
                                    Dim cod = System.Guid.NewGuid.ToString()
                                    obj.CodigoCosto = 1
                                    obj.CustomProducto = New detalleitems
                                    obj.CustomProducto.origenProducto = 1
                                    obj.CustomProducto.descripcionItem = sender.NAME
                                    obj.CustomProducto.unidad1 = "NIU"
                                    obj.CustomProducto.codigodetalle = sender.TAG
                                    obj.CustomProducto.tipoExistencia = "IF"
                                    obj.CustomEquivalencia = New detalleitem_equivalencias
                                    obj.CustomEquivalencia.fraccionUnidad = 0
                                    obj.idItem = sender.tag
                                    obj.DetalleItem = sender.TEXT
                                    obj.catalogo_id = 0
                                    obj.monto1 = 1
                                    obj.unidad1 = "NIU"
                                    obj.tipoExistencia = "IF"
                                    obj.montokardex = baseImponible
                                    obj.montoIgv = Iva
                                    obj.importeMN = CDec(total)
                                    obj.PrecioUnitarioVentaMN = CDec(CONSULTA.menor)
                                    obj.precioUnitario = CDec(CONSULTA.menor)
                                    obj.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                                    obj.CustomEquivalencia.equivalencia_id = 0
                                    obj.CustomCatalogo = New detalleitemequivalencia_catalogos
                                    obj.CustomCatalogo.idCatalogo = 0
                                    obj.FlagBonif = False
                                    obj.CustomListaInventarioMovimiento = New List(Of InventarioMovimiento)
                                    'obj.CustomDocumentoCaja = New List(Of documentoCaja)
                                    ListaproductosVendidos.Add(obj)

                                    Dim f As New FormVentaNuevaTouch()
                                    f.UCEstructuraCabeceraVentaV2.txtIDResponsable = VENDEDOR.IDUsuario
                                    f.UCEstructuraCabeceraVentaV2.txtNombreResponsable = VENDEDOR.Nombres & " " & VENDEDOR.ApellidoPaterno & " " & VENDEDOR.ApellidoMaterno
                                    f.UCEstructuraCabeceraVentaV2.txtInfraestructura.Text = sender.NAME
                                    f.UCEstructuraCabeceraVentaV2.txtInfraestructura.Tag = sender.tag
                                    f.UCEstructuraCabeceraVentaV2.ListaproductosVendidos.Add(obj)
                                    f.UCEstructuraCabeceraVentaV2.LoadCanastaVentas(ListaproductosVendidos)
                                    f.UCEstructuraCabeceraVentaV2.GetTotalesDocumento()
                                    f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                                    f.StartPosition = FormStartPosition.CenterParent
                                    f.ShowDialog()
                                    ActualizarInfra()

                                Else
                                    MessageBox.Show("Verificar los datos")
                                End If

                            Else
                                Dim f As New FormVentaNuevaTouch()
                                f.UCEstructuraCabeceraVentaV2.txtIDResponsable = VENDEDOR.IDUsuario
                                f.UCEstructuraCabeceraVentaV2.txtNombreResponsable = VENDEDOR.Nombres & " " & VENDEDOR.ApellidoPaterno & " " & VENDEDOR.ApellidoMaterno
                                f.UCEstructuraCabeceraVentaV2.txtInfraestructura.Text = sender.text
                                f.UCEstructuraCabeceraVentaV2.txtInfraestructura.Tag = sender.tag
                                f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                                f.StartPosition = FormStartPosition.CenterParent
                                f.Show(Me)

                            End If
                        End If

                    ElseIf (sender.BACKCOLOR = System.Drawing.Color.DarkGray) Then
                        Dim listaEntrega = New List(Of String)
                        listaEntrega.Add("DC")
                        listaEntrega.Add("PN")
                        listaEntrega.Add("PR")
                        listaEntrega.Add("AN")

                        FormPurchase.TabMG_GestionInfraestructura.Visible = False

                        If FormPurchase.Tab_ListaPedidos IsNot Nothing Then
                            FormPurchase.Tab_ListaPedidos.txtInfraestructura.Tag = sender.TAG
                            FormPurchase.Tab_ListaPedidos.txtInfraestructura.Text = sender.NAME
                            FormPurchase.Tab_ListaPedidos.GetDocumentoVentaID(sender.tag, "IF", listaEntrega)
                            FormPurchase.Tab_ListaPedidos.ID = sender.tag
                            FormPurchase.Tab_ListaPedidos.Visible = True
                            FormPurchase.Tab_ListaPedidos.BringToFront()
                            FormPurchase.Tab_ListaPedidos.Show()
                        End If
                    ElseIf (sender.BACKCOLOR = System.Drawing.Color.DarkRed) Then
                        Dim listaEntrega = New List(Of String)
                        listaEntrega.Add("DC")
                        listaEntrega.Add("PN")
                        listaEntrega.Add("PR")
                        listaEntrega.Add("AN")

                        FormPurchase.TabMG_GestionInfraestructura.Visible = False

                        If FormPurchase.Tab_ListaPedidos IsNot Nothing Then
                            FormPurchase.Tab_ListaPedidos.txtInfraestructura.Tag = sender.TAG
                            FormPurchase.Tab_ListaPedidos.txtInfraestructura.Text = sender.NAME
                            FormPurchase.Tab_ListaPedidos.GetDocumentoVentaID(sender.tag, "IF", listaEntrega)
                            FormPurchase.Tab_ListaPedidos.ID = sender.tag
                            FormPurchase.Tab_ListaPedidos.Visible = True
                            FormPurchase.Tab_ListaPedidos.BringToFront()
                            FormPurchase.Tab_ListaPedidos.Show()
                        End If
                    End If

                Case "U"

                        Dim listaEntrega = New List(Of String)
                    listaEntrega.Add("DC")
                    listaEntrega.Add("PN")
                    listaEntrega.Add("PR")
                    listaEntrega.Add("AN")

                    FormPurchase.TabMG_GestionInfraestructura.Visible = False

                    If FormPurchase.Tab_ListaPedidos IsNot Nothing Then
                        FormPurchase.Tab_ListaPedidos.txtInfraestructura.Tag = sender.TAG
                        FormPurchase.Tab_ListaPedidos.txtInfraestructura.Text = sender.NAME
                        FormPurchase.Tab_ListaPedidos.GetDocumentoVentaID(sender.tag, "IF", listaEntrega)
                        FormPurchase.Tab_ListaPedidos.Visible = True
                        FormPurchase.Tab_ListaPedidos.BringToFront()
                        FormPurchase.Tab_ListaPedidos.Show()
                    End If

                Case "P"

                    Dim f As New FormCanastaPedidoDeVentasInfra()
                    'f.IdDistribucion = sender.tag
                    f.txtInfraestructura.Tag = sender.tag
                    f.txtInfraestructura.Text = sender.NAME
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()
                    CargarDefault()
                    RefrescarCobros()

                Case "L"


                    If (sender.BACKCOLOR = System.Drawing.Color.OrangeRed) Then
                        If MessageBox.Show("¿Desea liberar la habitación?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            Dim ocupacionInfraBE As New ocupacionInfraestructura
                            Dim ocupacionInfraSA As New ocupacionInfraestructuraSA

                            ocupacionInfraBE.idEmpresa = Gempresas.IdEmpresaRuc
                            ocupacionInfraBE.idEstablecimiento = GEstableciento.IdEstablecimiento
                            ocupacionInfraBE.check_on = DateTime.Now
                            ocupacionInfraBE.listaId = New List(Of Integer)
                            ocupacionInfraBE.listaId.Add(sender.TAG)

                            ocupacionInfraSA.EditarOcupacionInfra(ocupacionInfraBE)
                            CheckCtasXCobrar.Checked = False

                            RefrescarLimpieza()
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

        LLAMARiNFRAESTRUCTURA(estado, "T")
        tipoLista = "T"
        lblFiltro.Visible = True
        cboFormato.Visible = True
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

    Private Sub CboCategoria_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboCategoria.SelectionChangeCommitted
        If (tipoLista = "T") Then
            Dim listaItem As List(Of String)
            listaItem = New List(Of String)
            listaItem.Add("A")
            listaItem.Add("U")
            listaItem.Add("P")
            listaItem.Add("L")
            Dim estado As String = String.Empty
            estado = "U,A,P,L"
            CargarDistribucionXTipoCategoria(estado, listaItem)
        ElseIf (tipoLista = "U") Then
            Dim listaItem As List(Of String)
            listaItem = New List(Of String)
            listaItem.Add("U")
            Dim estado As String = String.Empty
            estado = "U"
            CargarDistribucionXTipoCategoria(estado, listaItem)
        ElseIf (tipoLista = "A") Then
            Dim listaItem As List(Of String)
            listaItem = New List(Of String)
            listaItem.Add("A")
            Dim estado As String = String.Empty
            estado = "A"
            CargarDistribucionXTipoCategoria(estado, listaItem)
        End If
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        lblCtasXcobrar.Visible = True
        CheckCtasXCobrar.Visible = True
        CheckCtasXCobrar.Checked = False
        'Dim listaItem As List(Of String)
        'listaItem = New List(Of String)
        'listaItem.Add("U")
        ''CargarCombos()
        Dim estado As String = String.Empty
        estado = "U"
        LLAMARiNFRAESTRUCTURAlIMPIEZA(estado, "L")
        tipoLista = "L"
        lblFiltro.Visible = True
        cboFormato.Visible = True
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

                LLAMARiNFRAESTRUCTURAlIMPIEZA(estado, "L")
                tipoLista = "L"
                lblFiltro.Visible = True
                cboFormato.Visible = True
            ElseIf (CheckCtasXCobrar.Checked = True) Then
                'Dim listaItem As List(Of String)
                'listaItem = New List(Of String)
                'listaItem.Add("U")
                ''CargarCombos()
                Dim estado As String = String.Empty
                estado = "U"
                LLAMARiNFRAESTRUCTURAlIMPIEZA(estado, "U")
                tipoLista = "L"
                lblFiltro.Visible = True
                cboFormato.Visible = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

#End Region

#Region "Events"


#End Region

End Class
