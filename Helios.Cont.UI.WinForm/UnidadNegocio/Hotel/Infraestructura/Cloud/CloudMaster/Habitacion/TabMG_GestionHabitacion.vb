Imports System.IO
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class TabMG_GestionHabitacion

#Region "Attributes"
    Public Property tipoLista As String
    Dim lis As New ListBox
    Dim ListaproductosVendidos As List(Of documentoventaAbarrotesDet)
    Dim listaDistribucion As New List(Of distribucionInfraestructura)
    Public Property FormPurchase As FormRepositoryPiscina

#End Region

#Region "Constructors"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
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

    Private Sub BunifuFlatButton5_Click(sender As Object, e As EventArgs)
        Dim listaItem As List(Of String)
        listaItem = New List(Of String)
        listaItem.Add("A")
        CargarCombos()
        LLAMARiNFRAESTRUCTURA(listaItem, "A")
        tipoLista = "A"
        lblFiltro.Visible = True
        cboFormato.Visible = True
    End Sub

    Private Sub BunifuFlatButton7_Click(sender As Object, e As EventArgs)
        Dim listaItem As List(Of String)
        listaItem = New List(Of String)
        listaItem.Add("U")
        CargarCombos()
        LLAMARiNFRAESTRUCTURA(listaItem, "U")
        tipoLista = "U"
        lblFiltro.Visible = True
        cboFormato.Visible = True
    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs)
        Dim listaItem As List(Of String)
        listaItem = New List(Of String)
        listaItem.Add("U")
        CargarCombos()
        LLAMARiNFRAESTRUCTURA(listaItem, "P")
        tipoLista = "P"
        lblFiltro.Visible = True
        cboFormato.Visible = True
    End Sub
#End Region

#Region "Methods"

    Private Sub RefrescarCobros()
        Dim listaItem As List(Of String)
        listaItem = New List(Of String)
        listaItem.Add("U")
        CargarCombos()
        LLAMARiNFRAESTRUCTURA(listaItem, "P")
        tipoLista = "P"
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

    Public Sub LLAMARiNFRAESTRUCTURA(tipoEstado As List(Of String), Tipo As String)
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

            distribucionInfraestructuraBE.tipo = "1"
            distribucionInfraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
            distribucionInfraestructuraBE.idEstablecimiento = GEstableciento.IdEstablecimiento
            distribucionInfraestructuraBE.listaEstado = New List(Of String)

            distribucionInfraestructuraBE.listaEstado = (tipoEstado)

            listaDistribucion = distribucionInfraestructuraSA.getDistribucionInfraestructuraXtipo(distribucionInfraestructuraBE)

            Select Case Tipo
                Case "P"
                    listaDistribucion = listaDistribucion.Where(Function(O) O.conteoPrecioMenor > 0).ToList
                    'Case "U"
                    '    listaDistribucion = listaDistribucion.Where(Function(O) O.conteoPrecioMenor = 0).ToList
            End Select

            For Each items In listaDistribucion
                Dim b As New RoundButton2

                b.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
                If (items.estado = "A") Then
                    b.BackColor = System.Drawing.Color.Green

                    If (items.menor > 0) Then
                        b.Text = items.descripcionDistribucion & " - " & items.numeracion & vbNewLine & (items.usuarioActualizacion)
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

                    b.Text = items.descripcionDistribucion & " - " & items.numeracion & vbNewLine & (items.usuarioActualizacion)
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

    Public Sub CargarDefault()
        Dim listaItem As List(Of String)
        listaItem = New List(Of String)
        listaItem.Add("A")
        listaItem.Add("U")
        listaItem.Add("P")
        CargarCombos()
        LLAMARiNFRAESTRUCTURA(listaItem, "T")
        tipoLista = "T"
        lblFiltro.Visible = True
        cboFormato.Visible = True
    End Sub

    Private Sub ActualizarInfra()
        Dim listaItem As List(Of String)
        listaItem = New List(Of String)
        listaItem.Add("A")
        listaItem.Add("U")
        listaItem.Add("P")
        LLAMARiNFRAESTRUCTURA(listaItem, "T")
        tipoLista = "T"
        lblFiltro.Visible = True
        cboFormato.Visible = True
        cboFormato.SelectedValue = 0
    End Sub

    Private Sub CargarDistribucionXTipoInfra(tipoEstado As List(Of String))
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

            distribucionInfraestructuraBE.tipo = "1"
            distribucionInfraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
            distribucionInfraestructuraBE.idEstablecimiento = GEstableciento.IdEstablecimiento
            distribucionInfraestructuraBE.idInfraestructura = cboFormato.SelectedValue
            distribucionInfraestructuraBE.listaEstado = New List(Of String)

            distribucionInfraestructuraBE.listaEstado = (tipoEstado)

            If (cboFormato.SelectedValue = 0) Then
                listaDistribucion = distribucionInfraestructuraSA.getDistribucionInfraestructuraXtipo(distribucionInfraestructuraBE)
            Else
                listaDistribucion = distribucionInfraestructuraSA.getDistribucionInfraestructuraXtipoInfra(distribucionInfraestructuraBE)
            End If

            For Each items In listaDistribucion
                Dim b As New RoundButton2

                b.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
                If (items.estado = "A") Then
                    b.BackColor = System.Drawing.Color.Green

                    If (items.menor > 0) Then
                        b.Text = items.descripcionDistribucion & " - " & items.numeracion & vbNewLine & (items.usuarioActualizacion)
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

                    b.Text = items.descripcionDistribucion & " - " & items.numeracion & vbNewLine & (items.usuarioActualizacion)
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

    Private Sub CargarDistribucionXTipoCategoria(tipoEstado As List(Of String))
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
            distribucionInfraestructuraBE.idTipoServicio = cboCategoria.SelectedValue
            distribucionInfraestructuraBE.listaEstado = New List(Of String)

            distribucionInfraestructuraBE.listaEstado = (tipoEstado)

            If (cboCategoria.SelectedValue = 0) Then
                listaDistribucion = distribucionInfraestructuraSA.getDistribucionInfraestructuraXtipo(distribucionInfraestructuraBE)
            Else
                listaDistribucion = distribucionInfraestructuraSA.getDistribucionInfraestructuraXCategoria(distribucionInfraestructuraBE)
            End If

            For Each items In listaDistribucion
                Dim b As New RoundButton2

                b.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro
                If (items.estado = "A") Then
                    b.BackColor = System.Drawing.Color.Green

                    If (items.menor > 0) Then
                        b.Text = items.descripcionDistribucion & " - " & items.numeracion & vbNewLine & (items.usuarioActualizacion)
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

                    b.Text = items.descripcionDistribucion & " - " & items.numeracion & vbNewLine & (items.usuarioActualizacion)
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

                Case "T"
                    If (sender.BACKCOLOR = System.Drawing.Color.Green) Then


                    ElseIf (sender.BACKCOLOR = System.Drawing.Color.DarkGray) Then

                    ElseIf (sender.BACKCOLOR = System.Drawing.Color.DarkRed) Then

                    End If

                Case "U"

                Case "P"

            End Select

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub BunifuFlatButton17_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton17.Click
        Dim listaItem As List(Of String)
        listaItem = New List(Of String)
        listaItem.Add(tipoLista)
        'listaItem.Add("U")
        'listaItem.Add("P")
        CargarCombos()
        LLAMARiNFRAESTRUCTURA(listaItem, "T")
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
            CargarDistribucionXTipoInfra(listaItem)
        ElseIf (tipoLista = "U") Then
            Dim listaItem As List(Of String)
            listaItem = New List(Of String)
            listaItem.Add("U")
            CargarDistribucionXTipoInfra(listaItem)
        ElseIf (tipoLista = "A") Then
            Dim listaItem As List(Of String)
            listaItem = New List(Of String)
            listaItem.Add("A")
            CargarDistribucionXTipoInfra(listaItem)
        ElseIf (tipoLista = "P") Then
            Dim listaItem As List(Of String)
            listaItem = New List(Of String)
            listaItem.Add("P")
            CargarDistribucionXTipoInfra(listaItem)
        End If
    End Sub

    Private Sub CboCategoria_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboCategoria.SelectionChangeCommitted
        If (tipoLista = "T") Then
            Dim listaItem As List(Of String)
            listaItem = New List(Of String)
            listaItem.Add("A")
            listaItem.Add("U")
            listaItem.Add("P")
            CargarDistribucionXTipoCategoria(listaItem)
        ElseIf (tipoLista = "U") Then
            Dim listaItem As List(Of String)
            listaItem = New List(Of String)
            listaItem.Add("U")
            CargarDistribucionXTipoCategoria(listaItem)
        ElseIf (tipoLista = "A") Then
            Dim listaItem As List(Of String)
            listaItem = New List(Of String)
            listaItem.Add("A")
            CargarDistribucionXTipoCategoria(listaItem)
        ElseIf (tipoLista = "P") Then
            Dim listaItem As List(Of String)
            listaItem = New List(Of String)
            listaItem.Add("P")
            CargarDistribucionXTipoCategoria(listaItem)
        End If
    End Sub

#End Region

#Region "Events"


#End Region

End Class
