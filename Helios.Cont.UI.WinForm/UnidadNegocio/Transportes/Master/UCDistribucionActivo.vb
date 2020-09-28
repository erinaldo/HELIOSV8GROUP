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

Public Class UCDistribucionActivo

#Region "Attributes"


    Dim listaDistribucion As New List(Of distribucionInfraestructura)

    Dim ListaConfiguracion As New List(Of configuracionPrecio)

#End Region

    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        getCargarCombos()
    End Sub

#Region "Methods"

    Public Sub cargarBus(id As Integer, bus As String)

        LLAMARiNFRAESTRUCTURA(cboActivosFijos.SelectedValue)
    End Sub

    Public Sub LLAMARiNFRAESTRUCTURA(idActivo As Integer)
        Try
            Dim atributos As New FileAttributes
            Dim distribucionInfraestructuraSA As New distribucionInfraestructuraSA
            Dim distribucionInfraestructuraBE As New distribucionInfraestructura
            Dim conteo As Integer = 0
            Dim sumatoriaBoton As Integer = 1

            Dim estado As String = String.Empty
            estado = "U, A, L"

            distribucionInfraestructuraBE.tipo = "1"
            distribucionInfraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
            distribucionInfraestructuraBE.idEstablecimiento = GEstableciento.IdEstablecimiento
            distribucionInfraestructuraBE.tipo = "VPN"
            distribucionInfraestructuraBE.estado = "A"
            distribucionInfraestructuraBE.usuarioActualizacion = estado
            distribucionInfraestructuraBE.Categoria = 1
            distribucionInfraestructuraBE.SubCategoria = idActivo

            listaDistribucion = distribucionInfraestructuraSA.getInfraestructuraTransporte(distribucionInfraestructuraBE)

            DibujarControl(listaDistribucion)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub DibujarControl(listDistr As List(Of distribucionInfraestructura))
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


            'b.Image = ImageList1.Images(0)
            'b.ImageAlign = ContentAlignment.MiddleCenter
            'b.TextImageRelation = TextImageRelation.ImageAboveText
            'b.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            b.UseVisualStyleBackColor = False

            Select Case items.NombreSector
                Case "SECTOR 1"
                    Select Case items.NombrePiso
                        Case "PISO 1"
                            FlowPrimerPisoSector1.Controls.Add(b)
                        Case "PISO 2"
                            FlowNumero1.Controls.Add(b)
                    End Select
                Case "SECTOR 2"
                    Select Case items.NombrePiso
                        Case "PISO 1"
                            FlowPrimerPisoSector2.Controls.Add(b)
                        Case "PISO 2"
                            FlowNumero2.Controls.Add(b)
                    End Select
                Case "SECTOR 3"
                    Select Case items.NombrePiso
                        Case "PISO 1"
                            FlowPrimerPisoMedio.Controls.Add(b)
                        Case "PISO 2"
                            FlowPiso2Medio.Controls.Add(b)
                    End Select
                Case "SECTOR 4"
                    Select Case items.NombrePiso
                        Case "PISO 1"
                            FlowPrimerPisoSector3.Controls.Add(b)
                        Case "PISO 2"
                            FlowNumero3.Controls.Add(b)
                    End Select
                Case "SECTOR 5"
                    Select Case items.NombrePiso
                        Case "PISO 1"
                            FlowPrimerPisoSector4.Controls.Add(b)
                        Case "PISO 2"
                            FlowNumero4.Controls.Add(b)
                    End Select

            End Select

            Select Case items.estado
                Case "A"

                    b.BackgroundImage = My.Resources.libreTrans
                    b.BackgroundImage.Tag = 1
                    b.BackgroundImageLayout = ImageLayout.Zoom
                    b.Name = 0
                Case "U"

                    b.BackgroundImage = My.Resources.usadoTrans
                    b.BackgroundImage.Tag = 1
                    b.BackgroundImageLayout = ImageLayout.Zoom
                    'b.ContextMenuStrip.Tag = items
                    'b.ContextMenuStrip.Name = 1
                    'b.ContextMenuStrip.Text = items.descripcionDistribucion & " - " & items.numeracion
                    b.Name = 1
                Case "R"

                    b.BackgroundImage = My.Resources.reservado4
                    b.BackgroundImage.Tag = 1
                    b.BackgroundImageLayout = ImageLayout.Zoom
                    'b.ContextMenuStrip.Tag = items
                    'b.ContextMenuStrip.Name = 1
                    'b.ContextMenuStrip.Text = items.descripcionDistribucion & " - " & items.numeracion
                    b.Name = 2
                Case "L"

                    b.BackgroundImage = My.Resources.seleccioandoTrans
                    b.BackgroundImage.Tag = 1
                    b.BackgroundImageLayout = ImageLayout.Zoom
                    b.Name = 0

                Case "E"
                    b.Text = ""
                    b.Enabled = False
                    b.BackgroundImage = My.Resources.Text_Edit
                    b.BackgroundImage.Tag = 1
                    b.BackgroundImageLayout = ImageLayout.Zoom
                    b.Name = 3
            End Select

            Me.ToolTip1.IsBalloon = True

            Me.ToolTip1.SetToolTip(b, "S/." & items.menor)
            AddHandler b.Click, AddressOf Butto1

        Next
    End Sub

    Private Sub Butto1(sender As Object, e As EventArgs)
        Dim productoBE As New documentoventaAbarrotes
        Dim distribucionInfraestructuraSA As New distribucionInfraestructuraSA
        Dim distribucionInfraestructuraBE As New distribucionInfraestructura

        Try

            Dim c = CType(sender.Tag, distribucionInfraestructura)

            Dim f As New FormComfNumeracion
            f.pnBuscardor.Visible = True
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
            If f.Tag IsNot Nothing Then
                Dim idDistribucion = c.idDistribucion
                Dim numero = f.Tag
                GrabarPrecio(idDistribucion, numero)
                LLAMARiNFRAESTRUCTURA(cboActivosFijos.SelectedValue)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    Public Sub getCargarCombos()
        Dim ActivosFijosSA As New ActivosFijosSA
        Dim activosFijosBE As New List(Of activosFijos)
        Dim NuevoActivo As New activosFijos

        NuevoActivo.idActivo = 0
        NuevoActivo.descripcionItem = "Elija una opción"

        activosFijosBE.Add(NuevoActivo)
        activosFijosBE.AddRange(ActivosFijosSA.GetListar_activosFijos())

        If NuevoActivo IsNot Nothing Then
            cboActivosFijos.DataSource = activosFijosBE
            cboActivosFijos.ValueMember = "idActivo"
            cboActivosFijos.DisplayMember = "nroSeriePlaca"

            'If (Not IsNothing(activosFijosBE)) Then
            '    cboActivosFijos.SelectedValue = 0
            'End If

        End If
    End Sub

    Private Sub CboActivosFijos_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboActivosFijos.SelectionChangeCommitted
        LLAMARiNFRAESTRUCTURA(cboActivosFijos.SelectedValue)
    End Sub

    Private Sub GrabarPrecio(idDistribucion As Integer, numero As String)
        Try
            Dim numeroSA As New distribucionInfraestructuraSA
            Dim numeroBE As New distribucionInfraestructura

            If (numero.Length <= 0) Then
                MessageBox.Show("No existe una numeracion")
                Exit Sub
            End If
            numeroBE.idDistribucion = idDistribucion
            numeroBE.numeracion = numero
            numeroBE.idEmpresa = Gempresas.IdEmpresaRuc

            numeroSA.EditarNumeracion(numeroBE)
            'MessageBox.Show("Se cambio Con exito")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


#End Region

End Class
