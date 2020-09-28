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

Public Class TabTR_ConfiguracionPrecio

#Region "Attributes"


    Dim listaDistribucion As New List(Of vehiculoAsiento_Precios)

    Dim ListaConfiguracion As New List(Of configuracionPrecio)

    Public Property idProgramacion As Integer

#End Region

    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

#Region "Methods"

    Public Sub cargarBus(id As Integer, bus As String)

        LLAMARiNFRAESTRUCTURA(cboActivosFijos.SelectedValue, idProgramacion)
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

        For Each items In listDistr

            Dim b As New RoundButton2

            'ContextMenuStrip = New ContextMenuStrip()
            'ContextMenuStrip.Items.Add("ANULAR")
            'b.ContextMenuStrip = ContextMenuStrip

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
                Case "L"
                    b.BackgroundImage = My.Resources.seleccioandoTrans
                    b.BackgroundImage.Tag = 1
                    b.BackgroundImageLayout = ImageLayout.Zoom
                    b.Name = 0
            End Select

            'AddHandler b.ContextMenuStrip.ItemClicked, AddressOf contextMenuStrip_ItemClicked

            AddHandler b.Click, AddressOf Butto1
        Next
    End Sub

    Private Sub Butto1(sender As Object, e As EventArgs)
        Dim productoBE As New documentoventaAbarrotes
        Dim distribucionInfraestructuraSA As New VehiculoAsiento_PreciosSA
        Dim distribucionInfraestructuraBE As New vehiculoAsiento_Precios

        Try

            Dim c = CType(sender.Tag, vehiculoAsiento_Precios)

            Dim f As New FormComfPrecio
            f.pnBuscardor.Visible = True
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
            If f.Tag IsNot Nothing Then
                GrabarPrecio(CDec(f.Tag), c.precio_id)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    Public Sub getCargarCombos(idActivo As Integer)
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
            cboActivosFijos.SelectedValue = idActivo
            'If (Not IsNothing(activosFijosBE)) Then
            '    cboActivosFijos.SelectedValue = 0
            'End If

        End If
    End Sub

    Private Sub CboActivosFijos_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboActivosFijos.SelectionChangeCommitted
        LLAMARiNFRAESTRUCTURA(cboActivosFijos.SelectedValue, idProgramacion)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim configuracionPrecio As New vehiculoAsiento_Precios
        Dim configuracionPrecioSA As New VehiculoAsiento_PreciosSA

        If (cboActivosFijos.Text <> "Elija una opción") Then
            Dim precioMenor As Decimal = 0.0
            precioMenor = txtImporte.DecimalValue

            GrabarPrecioaLL(precioMenor, Nothing, "IF")
            LLAMARiNFRAESTRUCTURA(cboActivosFijos.SelectedValue, idProgramacion)
            txtImporte.Clear()
        End If

    End Sub


    Private Sub GrabarPrecioaLL(precioMenor As Decimal, idProducto As Integer, tipoModalidad As String)
        Try
            'Dim listaPrecio As New List(Of configuracionPrecioProducto)
            Dim precioSA As New VehiculoAsiento_PreciosSA
            Dim precio As New vehiculoAsiento_Precios
            'listaPrecio = New List(Of configuracionPrecioProducto)

            'For Each ITEM In listaDistribucion
            precio = New vehiculoAsiento_Precios
            precio.idActivo = cboActivosFijos.SelectedValue
            precio.precioAsientoMN = precioMenor
            precio.programacion_id = idProgramacion
            precio.idEmpresa = Gempresas.IdEmpresaRuc
            'Next

            precioSA.updateAsientoPrecioXall(precio)
            LLAMARiNFRAESTRUCTURA(cboActivosFijos.SelectedValue, idProgramacion)
            MsgBox("PrecioS actualizado", MsgBoxStyle.Information, "Done!")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GrabarPrecio(precioMenor As Decimal, idProducto As Integer)
        'Dim listaPrecio As New List(Of configuracionPrecioProducto)
        Dim precioSA As New VehiculoAsiento_PreciosSA
        Dim precio As New vehiculoAsiento_Precios
        'listaPrecio = New List(Of configuracionPrecioProducto)

        'For Each ITEM In listaDistribucion
        precio = New vehiculoAsiento_Precios
        precio.idActivo = cboActivosFijos.SelectedValue
        precio.precioAsientoMN = precioMenor
        precio.programacion_id = idProgramacion
        precio.idEmpresa = Gempresas.IdEmpresaRuc
        precio.precio_id = idProducto
        'Next

        precioSA.updateAsientoPrecioXID(precio)

    End Sub

    Private Sub TxtImporte_TextChanged(sender As Object, e As EventArgs) Handles txtImporte.TextChanged
        txtImporte.Select(0, txtImporte.Text.Length)
    End Sub

#End Region

End Class
