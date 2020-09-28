Imports System.IO
Imports System.Net
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports ProcesosGeneralesCajamiSoft
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports HtmlAgilityPack
Imports System.Net.Http
Imports Helios.Cont.Business.Logic

Public Class TabR_Asiento

    Public Property libres As Integer
    Public Property reservado As Integer

    Public Property vendidos As Integer

    Public Property nombrebus As Integer

    Dim listaDistribucion As New List(Of vehiculoAsiento_Precios)

    Dim tipoLista As String = "T"

    Public Property programacion_ID As Integer

    Public Property placaBus As Integer

    Dim listaAsientos As List(Of vehiculoAsiento_Precios)

    Public Sub New(formRepTransporte As FormMasterReservacion)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        'FormPurchase = formRepTransporte

        LLAMARiNFRAESTRUCTURA(nombrebus, programacion_ID)
    End Sub

#Region "METODO"
    Public Sub cargarBus(id As Integer, bus As String, idProgramacion As Integer)

        LLAMARiNFRAESTRUCTURA(nombrebus, idProgramacion)
    End Sub

    Public Sub LLAMARiNFRAESTRUCTURA(idActivo As Integer, idProgramacion As Integer)
        Try

            Dim atributos As New FileAttributes
            Dim distribucionInfraestructuraSA As New VehiculoAsiento_PreciosSA
            Dim distribucionInfraestructuraBE As New vehiculoAsiento_Precios
            Dim conteo As Integer = 0
            Dim sumatoriaBoton As Integer = 1

            Dim estado As String = String.Empty
            estado = "U, A, L"

            distribucionInfraestructuraBE.moneda = "1"
            distribucionInfraestructuraBE.numeracion = idProgramacion
            distribucionInfraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
            distribucionInfraestructuraBE.idEstablecimiento = GEstableciento.IdEstablecimiento
            distribucionInfraestructuraBE.moneda = "VPN"
            distribucionInfraestructuraBE.estado = "A"
            distribucionInfraestructuraBE.usuarioActualizacion = estado
            distribucionInfraestructuraBE.piso = 1
            distribucionInfraestructuraBE.segmento = idActivo

            listaDistribucion = distribucionInfraestructuraSA.getInfraestructuraTransporteXProgramacion(distribucionInfraestructuraBE)

            DibujarControl(listaDistribucion)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub DibujarControl(listDistr As List(Of vehiculoAsiento_Precios))
        '//IMAGNE 
        FlowNumero1.Controls.Clear()
        FlowNumero2.Controls.Clear()
        FlowNumero3.Controls.Clear()
        FlowNumero4.Controls.Clear()
        FlowPiso2Medio.Controls.Clear()
        FlowPrimerPisoSector1.Controls.Clear()
        FlowPrimerPisoSector2.Controls.Clear()
        FlowPrimerPisoSector3.Controls.Clear()
        FlowPrimerPisoSector4.Controls.Clear()
        FlowPrimerPisoMedio.Controls.Clear()
        libres = 0
        vendidos = 0
        reservado = 0
        For Each items In listDistr

            Dim b As New RoundButton2


            b.Text = items.numeracion
            b.TextAlign = ContentAlignment.MiddleLeft
            b.TabIndex = 0
            b.FlatStyle = FlatStyle.Standard
            b.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            b.ForeColor = System.Drawing.Color.White
            b.Size = New System.Drawing.Size(45, 45)
            b.Font = New Font(" Arial Narrow", 10, FontStyle.Bold)
            b.Tag = items


            b.UseVisualStyleBackColor = False

            Select Case items.segmento
                Case "SECTOR 1"
                    Select Case items.piso
                        Case "PISO 1"
                            FlowPrimerPisoSector1.Controls.Add(b)
                        Case "PISO 2"
                            FlowNumero1.Controls.Add(b)
                    End Select
                Case "SECTOR 2"
                    Select Case items.piso
                        Case "PISO 1"
                            FlowPrimerPisoSector2.Controls.Add(b)
                        Case "PISO 2"
                            FlowNumero2.Controls.Add(b)
                    End Select
                Case "SECTOR 3"
                    Select Case items.piso
                        Case "PISO 1"
                            FlowPrimerPisoMedio.Controls.Add(b)
                        Case "PISO 2"
                            FlowPiso2Medio.Controls.Add(b)
                    End Select
                Case "SECTOR 4"
                    Select Case items.piso
                        Case "PISO 1"
                            FlowPrimerPisoSector3.Controls.Add(b)
                        Case "PISO 2"
                            FlowNumero3.Controls.Add(b)
                    End Select
                Case "SECTOR 5"
                    Select Case items.piso
                        Case "PISO 1"
                            FlowPrimerPisoSector4.Controls.Add(b)
                        Case "PISO 2"
                            FlowNumero4.Controls.Add(b)
                    End Select

            End Select

            Select Case items.estado
                Case "A"
                    libres = libres + 1
                    b.BackgroundImage = My.Resources.libreTrans
                    b.BackgroundImage.Tag = 1
                    b.BackgroundImageLayout = ImageLayout.Zoom
                    b.Name = 0
                Case "U"
                    vendidos = vendidos + 1
                    b.BackgroundImage = My.Resources.usadoTrans
                    b.BackgroundImage.Tag = 1
                    b.BackgroundImageLayout = ImageLayout.Zoom
                    b.Name = 1
                Case "R"
                    reservado = reservado + 1
                    b.BackgroundImage = My.Resources.reservado4
                    b.BackgroundImage.Tag = 1
                    b.BackgroundImageLayout = ImageLayout.Zoom
                    b.Name = 2
                Case "L"
                    libres = libres + 1
                    b.BackgroundImage = My.Resources.seleccioandoTrans
                    b.BackgroundImage.Tag = 1
                    b.BackgroundImageLayout = ImageLayout.Zoom
                    b.Name = 0
            End Select



            AddHandler b.Click, AddressOf Butto1
        Next
    End Sub




    Private Sub Butto1(sender As Object, e As EventArgs)
        Dim productoBE As New documentoventaAbarrotes
        Dim distribucionInfraestructuraSA As New VehiculoAsiento_PreciosSA
        Dim distribucionInfraestructuraBE As New vehiculoAsiento_Precios
        Dim documentoventaSA As New VehiculoAsiento_PreciosSA
        Dim comprobanteTransporte As New documentoventaTransporte
        Dim comprobanteEntidad As New entidad
        Dim ventaSA As New DocumentoventaTransporteSA
        Try

            Dim asiento = CType(sender.Tag, vehiculoAsiento_Precios)
            Select Case tipoLista
                Case "T"
                    If (sender.name = 0) Then


                        distribucionInfraestructuraBE = New vehiculoAsiento_Precios
                        distribucionInfraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
                        distribucionInfraestructuraBE.precio_id = asiento.precio_id
                        distribucionInfraestructuraBE.estado = "L"
                        distribucionInfraestructuraBE.programacion_id = programacion_ID
                        distribucionInfraestructuraBE.idDistribucion = sender.TEXT

                        documentoventaSA.updateAsientoTransportexIDxVerificaion(distribucionInfraestructuraBE)

                        LLAMARiNFRAESTRUCTURA(nombrebus, programacion_ID)

                    End If
            End Select

        Catch ex As Exception
            LLAMARiNFRAESTRUCTURA(nombrebus, programacion_ID)
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

#End Region



End Class
