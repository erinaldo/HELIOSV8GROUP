Imports System.IO
Imports System.Net
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports ProcesosGeneralesCajamiSoft

Public Class TabRC_RecepcionHuespedExt

#Region "Attributes"

    Dim listaDistribucion As New List(Of distribucionInfraestructura)
    Public Property listaID As New List(Of String)
    Public Property IDDocumento As Integer = 0
    Dim ListaREservas As String

    Dim listaDist As String = String.Empty
    Dim listaEntidad As List(Of entidad)
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
            ContextMenuStrip = New ContextMenuStrip()
            ContextMenuStrip.Items.Add("Nuevo Hospedados")
            ContextMenuStrip.Items.Add("Ver Hospedados")
            ContextMenuStrip.Items.Add("Ver Estadia")
            ContextMenuStrip.Items.Add("Información Hab.")

            b.ContextMenuStrip = ContextMenuStrip
            If (items.estado = "A") Then
                b.BackColor = System.Drawing.Color.Green

                If (items.menor > 0) Then
                    b.Text = items.descripcionDistribucion & " - " & items.numeracion & vbNewLine & (items.usuarioActualizacion) & vbNewLine & ("S/. " & FormatNumber(items.menor, 2))
                    b.Name = items.menor

                    b.ContextMenuStrip.Name = 0
                Else
                    b.Text = items.descripcionDistribucion & " - " & items.numeracion & vbNewLine & (items.usuarioActualizacion)
                    b.Name = items.descripcionDistribucion & " - " & items.numeracion
                    b.ContextMenuStrip.Name = 0
                End If

            Else

                b.BackColor = System.Drawing.Color.DarkCyan
                'Dim CONTEOSW = (From x In FormPurchase.listaHospedados Where x.distribucionID = items.idDistribucion).Count
                If (items.conteoHospedados > 0) Then
                    b.Text = items.descripcionDistribucion & " - " & items.numeracion & vbNewLine & (items.usuarioActualizacion) & vbNewLine & "HOSPEDADOS(" & items.conteoHospedados & ")" & vbNewLine & ("S/. " & FormatNumber(items.menor, 2))
                Else
                    b.Text = items.descripcionDistribucion & " - " & items.numeracion & vbNewLine & (items.usuarioActualizacion) & vbNewLine & "HOSPEDADOS(0)" & vbNewLine & ("S/. " & FormatNumber(items.menor, 2))
                End If
                b.Name = items.conteoHospedados

                b.ContextMenuStrip.Name = 1
            End If
            b.FlatStyle = FlatStyle.Standard
            b.TabIndex = items.secuencia
            b.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            b.ForeColor = System.Drawing.Color.White
            b.Size = New System.Drawing.Size(120, 100)
            b.Tag = items.idDistribucion
            b.Image = ImageList1.Images(0)
            b.ImageAlign = ContentAlignment.MiddleCenter
            b.TextImageRelation = TextImageRelation.ImageAboveText
            b.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            b.UseVisualStyleBackColor = False
            flowProductoDetalle.Controls.Add(b)

            AddHandler b.ContextMenuStrip.ItemClicked, AddressOf contextMenuStrip_ItemClicked

            b.ContextMenuStrip.Tag = items.idDistribucion
            b.ContextMenuStrip.Text = items.descripcionDistribucion & " - " & items.numeracion
            AddHandler b.Click, AddressOf Butto1
        Next
    End Sub

    Public Sub LLAMARiNFRAESTRUCTURA(listaId As List(Of String), Estado As String, listaDist As String)
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
            distribucionInfraestructuraBE.SubCategoria = 0
            distribucionInfraestructuraBE.descripcionDistribucion = listaDist

            listaDistribucion = distribucionInfraestructuraSA.getDistribucionInfraHospedado(distribucionInfraestructuraBE)

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


            ElseIf (sender.BACKCOLOR = System.Drawing.Color.DarkCyan) Then


            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub contextMenuStrip_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)

        Try
            If (e.ClickedItem.Text = "Nuevo Hospedados") Then
                Dim f As New frmRecepcionHospedadosXCliente(sender.tag)
                f.tipoIngreso = 1
                f.listaDoc = listaEntidad
                f.txtHabitacion.Text = sender.text
                f.IDDocumento = IDDocumento
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
                If f.Tag IsNot Nothing Then
                    Dim estado As String = String.Empty
                    estado = "A,U,L,P"

                    LLAMARiNFRAESTRUCTURA(listaID, estado, listaDist)

                End If
            ElseIf (e.ClickedItem.Text = "Ver Hospedados") Then

                Dim secuencia = listaEntidad.Where(Function(o) o.listaDistribucion = sender.tag).FirstOrDefault.idEmpresa

                Dim f As New frmRecepcionHospedadosXCliente(sender.tag)
                f.tipoIngreso = 1
                f.BunifuFlatButton2.Enabled = False
                f.Panel1.Visible = False
                f.dgvCompras.Enabled = True
                'f.listaDoc = listaEntidad
                f.txtHabitacion.Text = sender.text
                'f.IDDocumento = IDDocumento
                f.cargarHospedadosBD(sender.tag, CInt(secuencia))
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
            ElseIf (e.ClickedItem.Text = "Ver Estadia") Then
                Dim f As New frmRecepcionFechaEstadia(sender.tag)
                f.txtHabitacion.Text = sender.text
                f.IDDocumento = sender.tag
                f.BunifuFlatButton2.Enabled = False
                f.txtdias.ReadOnly = True
                'f.monthCalendarAdv1.Enabled = True
                'f.MonthCalendarAdv2.Enabled = True
                f.GetCargarFechasBD(sender.tag, IDDocumento)
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
                If f.Tag IsNot Nothing Then


                End If
            ElseIf (e.ClickedItem.Text = "Información Hab.") Then
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub BunifuFlatButton5_Click(sender As Object, e As EventArgs)
        Try
            Dim estado As String = String.Empty
            estado = "A,U,L,P"

            LLAMARiNFRAESTRUCTURA(listaID, estado, listaDist)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub PictureLoad_Click(sender As Object, e As EventArgs) Handles PictureLoad.Click
        Try
            Dim estado As String = String.Empty
            estado = "A,U,L,P"

            LLAMARiNFRAESTRUCTURA(listaID, estado, listaDist)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TextNumIdentrazon_KeyDown(sender As Object, e As KeyEventArgs) Handles TextNumIdentrazon.KeyDown
        Dim nombres = String.Empty
        Try
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True

                Select Case TextNumIdentrazon.Text.Trim.Length
                    Case 8, 11
                        Dim entidadSA As New entidadSA

                        'CUANDO NO HAY CONEXION A INTERNET
                        Dim existeEnDB = entidadSA.UbicarEntidadPorRucNroxIdDistribucion(Gempresas.IdEmpresaRuc, "A", TextNumIdentrazon.Text.Trim).ToList

                        If (Not IsNothing(existeEnDB)) Then
                            listaDist = String.Empty
                            listaEntidad = New List(Of entidad)
                            For Each i In existeEnDB
                                IDDocumento = i.idOrganizacion
                                TextProveedor.Text = i.nombreCompleto
                                TextProveedor.Tag = i.idEntidad
                                TextProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                listaDist = listaDist & "," & i.listaDistribucion
                            Next
                            listaEntidad = existeEnDB
                            Dim estado As String = String.Empty
                            estado = "A,U,L,P"

                            LLAMARiNFRAESTRUCTURA(listaID, estado, listaDist)

                        Else
                            MessageBox.Show("No Existe Cliente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If

                    Case Else
                        TextProveedor.Text = String.Empty
                        TextNumIdentrazon.Text = String.Empty
                        MessageBox.Show("Ingrese un documento correcto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Select
            End If
        Catch ew As WebException

            If ew.Status = WebExceptionStatus.ProtocolError Then

                Dim [error] As String = New System.IO.StreamReader(ew.Response.GetResponseStream()).ReadToEnd()
                MessageBox.Show("DNI no encontrado en el padron, verifique si es menor de edad")
                TextNumIdentrazon.Clear()
                TextNumIdentrazon.Select()
                TextNumIdentrazon.Focus()
                TextProveedor.Clear()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

#End Region

End Class
