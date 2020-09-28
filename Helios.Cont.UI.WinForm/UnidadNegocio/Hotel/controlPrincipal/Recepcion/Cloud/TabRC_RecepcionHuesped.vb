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

Public Class TabRC_RecepcionHuesped


#Region "Attributes"

    Public Property listaDistribucion As New List(Of distribucionInfraestructura)

    Public Property listaID As New List(Of String)
    Public Property FormPurchase As TabRC_RecepcionPersona
    Public Property IDDocumento As Integer = 0
    Dim ListaREservas As String
    Public Property fechainicio As DateTime
    Public Property fechaFin As DateTime
    Public Property dias As Integer

    Dim IDTagSeleccionado As Integer

    Dim listaInfra As New List(Of infraestructura)
    Dim listaServicioInfra As New List(Of tipoServicioInfraestructura)

#End Region

#Region "Constructors"
    Public Sub New(formRepPiscina As TabRC_RecepcionPersona)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormPurchase = formRepPiscina
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
            ContextMenuStrip = New ContextMenuStrip()
            ContextMenuStrip.Items.Add("Hospedados")
            ContextMenuStrip.Items.Add("Fecha de Estadia")
            ContextMenuStrip.Items.Add("Información Hab.")
            b.ContextMenuStrip = ContextMenuStrip
            If (items.estado = "A") Then
                b.BackColor = System.Drawing.Color.Green

                If (items.menor > 0) Then
                    b.Text = items.descripcionDistribucion & " - " & items.numeracion & vbNewLine & (items.usuarioActualizacion) & vbNewLine & ("S/. " & FormatNumber(CDec(items.menor), 2))
                    b.Name = items.menor
                    b.ContextMenuStrip.Name = 0
                Else
                    b.Text = items.descripcionDistribucion & " - " & items.numeracion & vbNewLine & (items.usuarioActualizacion)
                    b.Name = items.menor
                    b.ContextMenuStrip.Name = 0
                End If
            ElseIf (items.estado = "U" And items.conteoPrecioMenor = 0) Then
                b.BackColor = System.Drawing.Color.DarkGray
                b.Text = items.descripcionDistribucion & " - " & items.numeracion & vbNewLine & (items.usuarioActualizacion)
                b.Name = items.menor
                b.ContextMenuStrip.Name = 0
            ElseIf (items.estado = "U" And items.conteoPrecioMenor > 0) Then
                b.BackColor = System.Drawing.Color.DarkRed
                b.Text = items.descripcionDistribucion & " - " & items.numeracion & vbNewLine & (items.usuarioActualizacion) & vbNewLine & "(C. X COBRAR)" & vbNewLine & ("S/. " & FormatNumber(CDec(items.menor), 2))
                b.Name = items.menor
                b.ContextMenuStrip.Name = 0
            Else
                b.BackColor = System.Drawing.Color.DarkCyan
                Dim CONTEOSW = (From x In FormPurchase.listaHospedados Where x.distribucionID = items.idDistribucion).Count
                If (Not IsNothing(CONTEOSW)) Then
                    b.Text = items.descripcionDistribucion & " - " & items.numeracion & vbNewLine & (items.usuarioActualizacion) & vbNewLine & "HOSPEDADOS(" & CONTEOSW & ")" & vbNewLine & "S/. " & CDec(dias * FormatNumber(CDec(items.menor), 2))
                Else
                    b.Text = items.descripcionDistribucion & " - " & items.numeracion & vbNewLine & (items.usuarioActualizacion) & vbNewLine & "HOSPEDADOS(0)" & vbNewLine & "S/. " & CDec(dias * FormatNumber(CDec(items.menor), 2))
                End If
                b.Name = items.menor
                b.TabIndex = 0
                'b.Checked = True
                b.ContextMenuStrip.Name = 1
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

            AddHandler b.ContextMenuStrip.ItemClicked, AddressOf contextMenuStrip_ItemClicked
            b.ContextMenuStrip.Tag = items
            b.ContextMenuStrip.Name = 1
            b.ContextMenuStrip.Text = items.descripcionDistribucion & " - " & items.numeracion
            AddHandler b.Click, AddressOf Butto1

            Dim itemSeleccioando = listaDistribucion.Where(Function(o) o.idDistribucion = items.idDistribucion).FirstOrDefault
            itemSeleccioando.mayor = FormatNumber(CDec(dias * items.menor), 2)

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
            distribucionInfraestructuraBE.Categoria = 1

            listaDistribucion = distribucionInfraestructuraSA.getDistribucionInfraestructuraXtipo(distribucionInfraestructuraBE)

            DibujarControl(listaDistribucion)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub UPDATEINFRAESTRUCTURA(colorBE As Color, Estado As String, sender As Object)
        Try
            Dim c = CType(sender.Tag, distribucionInfraestructura)
            If (colorBE = System.Drawing.Color.DarkCyan) Then
                sender.BackColor = System.Drawing.Color.DarkCyan
                Dim CONTEOSW = (From x In FormPurchase.listaHospedados Where x.distribucionID = sender.TABINDEX).Count
                If (Not IsNothing(CONTEOSW)) Then
                    sender.Text = c.descripcionDistribucion & " - " & c.numeracion & vbNewLine & (c.usuarioActualizacion) & vbNewLine & "HOSPEDADOS(" & CONTEOSW & ")" & vbNewLine & "S/. " & CDec(FormatNumber(CDec(dias * c.menor), 2))
                Else
                    sender.Text = c.descripcionDistribucion & " - " & c.numeracion & vbNewLine & (c.usuarioActualizacion) & vbNewLine & "HOSPEDADOS(0)" & vbNewLine & "S/. " & CDec(FormatNumber(CDec(dias * c.menor), 2))
                End If
                sender.Name = c.menor
                sender.ContextMenuStrip.Name = 1

            ElseIf (colorBE = System.Drawing.Color.Green) Then
                sender.BackColor = System.Drawing.Color.Green
                If (c.menor > 0) Then
                    sender.Text = c.descripcionDistribucion & " - " & c.numeracion & vbNewLine & (c.usuarioActualizacion) & vbNewLine & ("S/. " & FormatNumber(CDec(c.menor), 2))
                    sender.Name = c.menor
                    sender.ContextMenuStrip.Name = 0
                Else
                    sender.Text = c.descripcionDistribucion & " - " & c.numeracion & vbNewLine & (c.usuarioActualizacion)
                    sender.Name = c.menor
                    sender.ContextMenuStrip.Name = 0

                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Public Sub UpdateInfraestructuraManipulacion(colorBE As Color, Estado As String, sender As Object)
        Try
            Dim c = CType(sender.Tag, distribucionInfraestructura)

            If (colorBE = System.Drawing.Color.DarkCyan) Then
                Dim CONTEOSW = (From x In FormPurchase.listaHospedados Where x.distribucionID = c.idDistribucion).Count
                If (Not IsNothing(CONTEOSW)) Then
                    sender.Text = c.descripcionDistribucion & " - " & c.numeracion & vbNewLine & (c.usuarioActualizacion) & vbNewLine & "HOSPEDADOS(" & CONTEOSW & ")" & vbNewLine & "S/. " & CDec(FormatNumber(CDec(dias * c.menor), 2))
                Else
                    sender.Text = c.descripcionDistribucion & " - " & c.numeracion & vbNewLine & (c.usuarioActualizacion) & vbNewLine & "HOSPEDADOS(0)" & vbNewLine & "S/. " & CDec(FormatNumber(CDec(dias * c.menor), 2))
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub CargarDistribucionXTipoInfra(tipoEstado As String, listaEst As List(Of String))
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
            distribucionInfraestructuraBE.usuarioActualizacion = tipoEstado
            distribucionInfraestructuraBE.idInfraestructura = cboFormato.SelectedValue
            distribucionInfraestructuraBE.listaEstado = New List(Of String)
            distribucionInfraestructuraBE.SubCategoria = cboFormato.SelectedValue

            If (cboFormato.SelectedValue = 0) Then
                distribucionInfraestructuraBE.Categoria = 1
                listaDistribucion = distribucionInfraestructuraSA.getDistribucionInfraestructuraXtipo(distribucionInfraestructuraBE)
            Else
                distribucionInfraestructuraBE.Categoria = 3
                listaDistribucion = distribucionInfraestructuraSA.getDistribucionInfraestructuraXtipoInfra(distribucionInfraestructuraBE)
            End If

            DibujarControl(listaDistribucion)

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
            distribucionInfraestructuraBE.tipo = "1"
            distribucionInfraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
            distribucionInfraestructuraBE.idEstablecimiento = GEstableciento.IdEstablecimiento
            distribucionInfraestructuraBE.tipo = "VNP"
            distribucionInfraestructuraBE.estado = "A"
            distribucionInfraestructuraBE.usuarioActualizacion = tipoEstado
            distribucionInfraestructuraBE.idTipoServicio = cboCategoria.SelectedValue
            distribucionInfraestructuraBE.listaEstado = New List(Of String)
            distribucionInfraestructuraBE.listaEstado = listaEst
            distribucionInfraestructuraBE.SubCategoria = cboCategoria.SelectedValue

            If (cboCategoria.SelectedValue = 0) Then
                distribucionInfraestructuraBE.Categoria = 1
                listaDistribucion = distribucionInfraestructuraSA.getDistribucionInfraestructuraXtipo(distribucionInfraestructuraBE)
            Else
                distribucionInfraestructuraBE.Categoria = 2
                listaDistribucion = distribucionInfraestructuraSA.getDistribucionInfraestructuraXCategoria(distribucionInfraestructuraBE)
            End If

            DibujarControl(listaDistribucion)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

#End Region

#Region "Events"
    Private Sub Butto1(sender As Object, e As EventArgs)
        Try

            Dim DinstriBucionSA As New distribucionInfraestructuraSA
            Dim DistribucionBE As New distribucionInfraestructura
            If (sender.BACKCOLOR = System.Drawing.Color.Green) Then



                'ACTUALIZAR LA HABITACION
                DistribucionBE.idEmpresa = Gempresas.IdEmpresaRuc
                DistribucionBE.idEstablecimiento = GEstableciento.IdEstablecimiento
                DistribucionBE.idDistribucion = sender.TABINDEX
                DistribucionBE.estado = sender.TABINDEX
                listaID.Add(sender.TABINDEX)

                Dim infraestrucutura = DinstriBucionSA.updateDistribucionxID(DistribucionBE)

                Dim itemSeleccioando = listaDistribucion.Where(Function(o) o.idDistribucion = infraestrucutura.idDistribucion).FirstOrDefault
                itemSeleccioando.estado = sender.TABINDEX

                'AGREGAR OCUAPCION INFRAESTUCTURA PARA CADA HABITACION SELECCIONADO
                Dim ocupacionInfraBE As New ocupacionInfraestructura
                ocupacionInfraBE.idEmpresa = Gempresas.IdEmpresaRuc
                ocupacionInfraBE.idEstablecimiento = GEstableciento.IdEstablecimiento
                ocupacionInfraBE.chek_in = fechainicio
                ocupacionInfraBE.check_on = fechaFin
                ocupacionInfraBE.idDistribucion = sender.TABINDEX
                ocupacionInfraBE.estado = "A"
                FormPurchase.listaOcupacionInfra.Add(ocupacionInfraBE)

                'LLAMAR PARA QUE CARGUE NUEVAMENTE LOS DIBUJOS DE LAS HAB 
                ListaREservas = ""
                For Each item In FormPurchase.listaInfraestructura
                    ListaREservas = ListaREservas & "," & item.numeracion
                Next
                Dim estado As String = String.Empty
                estado = "A," & ListaREservas
                UPDATEINFRAESTRUCTURA(System.Drawing.Color.DarkCyan, estado, sender)

                'FormPurchase.Infraestructura = New distribucionInfraestructura
                'FormPurchase.Infraestructura.numeracion = sender.TABINDEX
                'FormPurchase.Infraestructura.NombrePiso = CDec(sender.NAME)
                'FormPurchase.listaInfraestructura.Add(infraestrucutura)
                FormPurchase.listaid.Add(sender.TABINDEX)

            ElseIf (sender.BACKCOLOR = System.Drawing.Color.DarkCyan) Then
                Dim item = FormPurchase.listaInfraestructura.Where(Function(o) o.numeracion = sender.TABINDEX).FirstOrDefault
                FormPurchase.listaInfraestructura.Remove(item)

                Dim itemHospedados = FormPurchase.listaHospedados.Where(Function(o) o.distribucionID = sender.TABINDEX).ToList
                For Each itemss In itemHospedados
                    FormPurchase.listaHospedados.Remove(itemss)
                Next

                DistribucionBE.idEmpresa = Gempresas.IdEmpresaRuc
                DistribucionBE.idEstablecimiento = GEstableciento.IdEstablecimiento
                DistribucionBE.idDistribucion = sender.TABINDEX
                DistribucionBE.estado = "A"

                Dim infraestrucutura = DinstriBucionSA.updateDistribucionxID(DistribucionBE)

                Dim itemSeleccioando = listaDistribucion.Where(Function(o) o.idDistribucion = infraestrucutura.idDistribucion).FirstOrDefault
                itemSeleccioando.estado = "A"

                Dim estado As String = String.Empty
                estado = "A," & ListaREservas
                UPDATEINFRAESTRUCTURA(System.Drawing.Color.Green, estado, sender)

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs)
        FormPurchase.listaHospedados.Clear()
        FormPurchase.listaOcupacionInfra.Clear()
        FormPurchase.listaInfraestructura.Clear()
        FormPurchase.listaInfra.Clear()
    End Sub


    Private Sub contextMenuStrip_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)

        Try
            Dim c = CType(sender.Tag, distribucionInfraestructura)

            If (sender.NAME = 1) Then

                If (e.ClickedItem.Text = "Hospedados") Then
                    Dim f As New frmRecepcionHospedadosXCliente(c.idDistribucion)
                    f.tipoIngreso = 0
                    f.txtHabitacion.Text = sender.text
                    f.IDDocumento = IDDocumento
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()
                    If f.Tag IsNot Nothing Then
                        For Each item In f.Tag
                            FormPurchase.listaHospedados.Add(item)
                        Next

                        ListaREservas = ""
                        For Each item In FormPurchase.listaInfraestructura
                            ListaREservas = ListaREservas & "," & item.numeracion
                        Next

                        Dim estado As String = String.Empty
                        estado = "A," & ListaREservas

                        DibujarControl(listaDistribucion)

                        'UpdateInfraestructuraManipulacion(System.Drawing.Color.DarkCyan, estado, sender)
                        ''LLAMARiNFRAESTRUCTURA(listaID, estado)
                    End If

                ElseIf (e.ClickedItem.Text = "Fecha de Estadia") Then
                    Dim f As New frmRecepcionFechaEstadia(c.idDistribucion)
                    f.txtHabitacion.Text = sender.text
                    f.IDDocumento = c.idDistribucion
                    f.GetCargarFechas(fechainicio, fechaFin, dias)
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()
                    If f.Tag IsNot Nothing Then
                        Dim ocupacion = CType(f.Tag, ocupacionInfraestructura)
                        Dim item = FormPurchase.listaOcupacionInfra.Where(Function(o) o.idDistribucion = c.idDistribucion).FirstOrDefault
                        FormPurchase.listaOcupacionInfra.Remove(item)
                        FormPurchase.listaOcupacionInfra.Add(ocupacion)

                        Dim itemSeleccioando = listaDistribucion.Where(Function(o) o.idDistribucion = c.idDistribucion).FirstOrDefault
                        itemSeleccioando.mayor = FormatNumber(CDec(ocupacion.dias * itemSeleccioando.menor), 2)

                        MessageBox.Show("Se Actualizo la Estadia")
                    End If

                ElseIf (e.ClickedItem.Text = "Información Hab.") Then
                End If
            Else
                MessageBox.Show("Debe seleccionar Hab.")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub BunifuFlatButton5_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton5.Click
        Try
            ListaREservas = ""
            For Each item In FormPurchase.listaInfraestructura
                ListaREservas = ListaREservas & "," & item.numeracion
            Next

            Dim estado As String = String.Empty
            estado = "A," & ListaREservas

            LLAMARiNFRAESTRUCTURA(listaID, estado)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CboFormato_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboFormato.SelectionChangeCommitted
        Try
            ListaREservas = ""
            For Each item In FormPurchase.listaInfraestructura
                ListaREservas = ListaREservas & "," & item.numeracion
            Next

            Dim estado As String = String.Empty
            estado = "A," & ListaREservas
            CargarDistribucionXTipoInfra(estado, Nothing)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CboCategoria_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboCategoria.SelectionChangeCommitted
        Try
            ListaREservas = ""
            For Each item In FormPurchase.listaInfraestructura
                ListaREservas = ListaREservas & "," & item.numeracion
            Next
            Dim estado As String = String.Empty
            estado = "A," & ListaREservas
            CargarDistribucionXTipoCategoria(estado, Nothing)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub BGHoteles_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BGHoteles.DoWork
        Try

            Dim tipoServicioInfraestructuraSA As New tipoServicioInfraestructuraSA
            Dim infraestrucutraSA As New infraestructuraSA
            Dim objInfraBE As New infraestructura
            Dim objServicioInfraBE As New tipoServicioInfraestructura
            Dim objInfraDefault As New infraestructura
            Dim objServicioInfraDefault As New tipoServicioInfraestructura

            objInfraBE.idEmpresa = Gempresas.IdEmpresaRuc
            objInfraBE.idEstablecimiento = GEstableciento.IdEstablecimiento
            objInfraBE.tipo = "P"

            objInfraDefault.idInfraestructura = 0
            objInfraDefault.nombre = "TODO"

            listaInfra.Add(objInfraDefault)
            listaInfra.AddRange(infraestrucutraSA.getListaInfraestructura(objInfraBE))

            objServicioInfraBE.idEmpresa = Gempresas.IdEmpresaRuc
            objServicioInfraBE.idEstablecimiento = GEstableciento.IdEstablecimiento

            objServicioInfraDefault.idTipoServicio = 0
            objServicioInfraDefault.descripcionTipoServicio = "TODO"

            listaServicioInfra.Add(objServicioInfraDefault)
            listaServicioInfra.AddRange(tipoServicioInfraestructuraSA.GetUbicartipoServicioInfra(objServicioInfraBE))

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub BGHoteles_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BGHoteles.RunWorkerCompleted
        Try
            cboFormato.ValueMember = "idInfraestructura"
            cboFormato.DisplayMember = "nombre"
            cboFormato.DataSource = listaInfra
            cboFormato.SelectedValue = 0


            cboCategoria.ValueMember = "idTipoServicio"
            cboCategoria.DisplayMember = "descripcionTipoServicio"
            cboCategoria.DataSource = listaServicioInfra
            cboCategoria.SelectedValue = 0
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

#End Region

End Class
