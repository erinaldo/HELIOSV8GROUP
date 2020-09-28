Imports System.IO
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class TabMG_GestionAlertas

#Region "Attributes"
    Dim tipoLista As String
    Dim lis As New ListBox
    Dim ListaproductosVendidos As List(Of documentoventaAbarrotesDet)
    Dim listaDistribucion As New List(Of ocupacionInfraestructura)
    Public Property FormPurchase As FormAlertaPiscina
#End Region

#Region "Constructors"
    Public Sub New(formRepPiscina As FormAlertaPiscina)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormPurchase = formRepPiscina
        CargarDefault()
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

    Public Sub LLAMARiNFRAESTRUCTURA()
        Try

            Dim ocupacionInfraestructuraSA As New ocupacionInfraestructuraSA
            Dim ocupacionInfraestructuraBE As New ocupacionInfraestructura

            Dim conteo As Integer = 0
            Dim sumatoriaBoton As Integer = 1

            '//IMAGNE 
            flowProductoDetalle.Controls.Clear()

            ocupacionInfraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
            ocupacionInfraestructuraBE.idEstablecimiento = GEstableciento.IdEstablecimiento
            ocupacionInfraestructuraBE.check_on = DateTime.Now
            ocupacionInfraestructuraBE.estado = "A"

            listaDistribucion = ocupacionInfraestructuraSA.listaAlertaCheckOn(ocupacionInfraestructuraBE)


            For Each items In listaDistribucion
                Dim b As New RoundButton2

                b.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Metro

                If (items.conteoPago = 0) Then
                    b.BackColor = System.Drawing.Color.Maroon
                Else
                    b.BackColor = System.Drawing.Color.OrangeRed
                End If

                b.BeforeTouchSize = New System.Drawing.Size(83, 48)
                b.FlatStyle = System.Windows.Forms.FlatStyle.Flat
                b.ForeColor = System.Drawing.Color.White
                b.IsBackStageButton = False
                'b.Location = New System.Drawing.Point(51, 149)
                b.Size = New System.Drawing.Size(120, 100)


                b.Text = items.usuarioActualizacion
                b.Name = items.idDistribucion
                b.TabIndex = 0
                b.Tag = items.idOcupacion

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

    Private Sub CargarDefault()

        LLAMARiNFRAESTRUCTURA()

    End Sub

    Private Sub Butto1(sender As Object, e As EventArgs)
        Try

            If (sender.BACKCOLOR = System.Drawing.Color.Maroon) Then

                Dim ocupacionInfraBE As New ocupacionInfraestructura
                    Dim ocupacionInfraSA As New ocupacionInfraestructuraSA

                    ocupacionInfraBE.idEmpresa = Gempresas.IdEmpresaRuc
                    ocupacionInfraBE.idEstablecimiento = GEstableciento.IdEstablecimiento
                    ocupacionInfraBE.check_on = DateTime.Now
                    ocupacionInfraBE.listaId = New List(Of Integer)
                    ocupacionInfraBE.listaId.Add(sender.name)

                ocupacionInfraSA.EditarOcupacionInfra(ocupacionInfraBE)

                LLAMARiNFRAESTRUCTURA()

            ElseIf (sender.BACKCOLOR = System.Drawing.Color.OrangeRed) Then
                Dim f As New FormCanastaPedidoDeVentasInfra()
                'f.IdDistribucion = sender.tag
                f.txtInfraestructura.Tag = sender.tag
                f.txtInfraestructura.Text = sender.NAME
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog(Me)

                CargarDefault()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub BunifuFlatButton17_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton17.Click
        Try
            Dim ocupacionInfraBE As New ocupacionInfraestructura
            Dim ocupacionInfraSA As New ocupacionInfraestructuraSA

            ocupacionInfraBE.idEmpresa = Gempresas.IdEmpresaRuc
            ocupacionInfraBE.idEstablecimiento = GEstableciento.IdEstablecimiento
            ocupacionInfraBE.check_on = DateTime.Now
            ocupacionInfraBE.listaId = New List(Of Integer)

            For Each item In listaDistribucion
                ocupacionInfraBE.listaId.Add(item.idDistribucion)
            Next

            ocupacionInfraSA.EditarOcupacionInfra(ocupacionInfraBE)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        LLAMARiNFRAESTRUCTURA()
    End Sub


#End Region

#Region "Events"


#End Region

End Class
