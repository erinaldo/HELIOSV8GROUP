Imports System.IO
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class TabR_GestionCajaCentralizada

#Region "Attributes"
    Dim tipoLista As String
    Dim lis As New ListBox
    Dim ListaproductosVendidos As List(Of documentoventaAbarrotesDet)
    Dim listaDistribucion As New List(Of distribucionInfraestructura)
    Public Property FormPurchase As FormControlRestaurant

    'Public Property FormCanastaPedidoPorCobrar As FormCanastaPedidoPorCobrar
#End Region

#Region "Constructors"
    Public Sub New(formRepPiscina As FormControlRestaurant)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormPurchase = formRepPiscina

        'FormCanastaPedidoPorCobrar = New FormCanastaPedidoPorCobrar(Me) With {.Dock = DockStyle.Fill}
        'PanelBody.Controls.Add(FormCanastaPedidoPorCobrar)

    End Sub

#End Region

#Region "Methods"


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
        lblCtasXcobrar.Visible = False
        CheckCtasXCobrar.Visible = False
        CheckCtasXCobrar.Checked = False

        Dim estado As String = String.Empty
        estado = "P"

        LLAMARiNFRAESTRUCTURA(estado, "VPN", 1, "CR")
        tipoLista = "P"
    End Sub

    Sub DibujarControl(listDistr As List(Of distribucionInfraestructura))
        flowProductoDetalle.Controls.Clear()
        For Each items In listDistr
            Dim b As New RoundButton2

            b.BackColor = System.Drawing.Color.DarkRed
                b.Text = items.descripcionDistribucion & " - " & items.numeracion & vbNewLine & ("S/. " & FormatNumber(CDec(items.conteoPrecioMenor), 2))
                b.TabIndex = 0

            b.FlatStyle = FlatStyle.Standard
            'b.TabIndex = items.idDistribucion
            b.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            b.ForeColor = System.Drawing.Color.White
            b.Size = New System.Drawing.Size(100, 80)
            b.Font = New Font("Copperplate Gothic Bold", 9, FontStyle.Regular)
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

    Private Sub Butto1(sender As Object, e As EventArgs)
        Dim productoBE As New documentoventaAbarrotes
        Dim distribucionInfraestructuraSA As New distribucionInfraestructuraSA
        Dim distribucionInfraestructuraBE As New distribucionInfraestructura

        Try
            Dim c = CType(sender.Tag, distribucionInfraestructura)

            FormPurchase.TabR_GestionCajaCentralizada.Visible = False

            If FormPurchase.FormCanastaPedidoPorCobrar IsNot Nothing Then
                FormPurchase.FormCanastaPedidoPorCobrar.Visible = True
                FormPurchase.FormCanastaPedidoPorCobrar.listaDistribucion = New List(Of String)
                FormPurchase.FormCanastaPedidoPorCobrar.listaDistribucion.Add(c.idDistribucion)
                FormPurchase.FormCanastaPedidoPorCobrar.txtInfraestructura.Tag = c.idDistribucion
                FormPurchase.FormCanastaPedidoPorCobrar.txtInfraestructura.Text = c.descripcionDistribucion & " " & c.numeracion
                FormPurchase.FormCanastaPedidoPorCobrar.CARGARdATOS()
                FormPurchase.FormCanastaPedidoPorCobrar.BringToFront()
                FormPurchase.FormCanastaPedidoPorCobrar.Show()
            End If

            'CargarDefault()

            'Dim f As New FormCanastaPedidoPorCobrar()
            ''f.IdDistribucion = sender.tag
            'f.listaDistribucion = New List(Of String)
            'f.listaDistribucion.Add(c.idDistribucion)
            'f.txtInfraestructura.Tag = c.idDistribucion
            'f.txtInfraestructura.Text = c.descripcionDistribucion & " " & c.numeracion
            'f.StartPosition = FormStartPosition.CenterParent
            'f.ShowDialog()
            'CargarDefault()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub BunifuFlatButton5_Click_1(sender As Object, e As EventArgs) Handles BunifuFlatButton5.Click
        lblCtasXcobrar.Visible = False
        CheckCtasXCobrar.Visible = False
        CheckCtasXCobrar.Checked = False

        Dim estado As String = String.Empty
        estado = "P"

        LLAMARiNFRAESTRUCTURA(estado, "VPN", 1, "CR")
        tipoLista = "P"

    End Sub

    Private Sub BunifuFlatButton10_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton10.Click
        Try
            FormPurchase.TabR_GestionCajaCentralizada.Visible = False

            If FormPurchase.TabP_RestaurantMaster IsNot Nothing Then
                FormPurchase.TabP_RestaurantMaster.Visible = True
                FormPurchase.TabP_RestaurantMaster.BringToFront()
                FormPurchase.TabP_RestaurantMaster.Show()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub




#End Region

#Region "Events"


#End Region

End Class
