Imports System.IO
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General

Public Class UCCrearBus
    Public Property FormPurchase As FormTablaPrincipalTransportes
    Dim listaDistribucion As New List(Of distribucionInfraestructura)
    Dim listaPlantillaActivo As New List(Of PlantillaActivo)
    Dim CONDICION As String = String.Empty
    Dim IDINFRA As Integer = 0
    Public TIPOCONTROL As String = String.Empty
    Dim TIPOCONSULTA As String = String.Empty

    Public Sub New(FormventaNueva As FormTablaPrincipalTransportes)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        FormPurchase = FormventaNueva
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        TIPOCONTROL = "ESPACIOS"
    End Sub

    Public Sub New(TIPO As String, IDACTIVO As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        TIPOCONTROL = TIPO
    End Sub

    Public Sub cargarBusxACTIVO(IDACTIVO As Integer)
        PnCarga.Visible = True
        pnBus2Pisos.Visible = True
        pnBus1Piso.Visible = False
        pnBan.Visible = False
        pnAuto.Visible = False
        LLAMARiNFRAESTRUCTURAXACTIVO(IDACTIVO)
        PnCarga.Visible = False
    End Sub

    Public Sub cargarTipoServicios()
        Try
            Dim tipoServicioSA As New tipoServicioInfraestructuraSA
            Dim listaTipoInfra As New List(Of tipoServicioInfraestructura)

            listaTipoInfra = tipoServicioSA.GetUbicartipoServicioInfra(New tipoServicioInfraestructura With {
                                                                       .idEmpresa = Gempresas.IdEmpresaRuc})


            cboTipoServicio.ValueMember = "idTipoServicio"
            cboTipoServicio.DisplayMember = "descripcionTipoServicio"
            cboTipoServicio.DataSource = listaTipoInfra

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Public Sub cargarBus(id As Integer, bus As String)
        PnCarga.Visible = True
        cargarPlantilla()
        LLAMARiNFRAESTRUCTURA(cboPlantilla.SelectedValue)
        PnCarga.Visible = False
    End Sub
    Public Sub cargarPlantilla()
        Try

            Dim sa As New PlantillaActivoSA


            'listaPlantillaActivo = sa.GetPlantillaActivo(New PlantillaActivo With {.idEmpresa = Gempresas.IdEmpresaRuc, .estado = "A"})

            cboPlantilla.ValueMember = "IdPlantilla"
            cboPlantilla.DisplayMember = "nombre"
            cboPlantilla.DataSource = listaPlantillaActivo
            cboPlantilla.SelectedValue = 1

            pnBus2Pisos.Visible = True
            pnBus1Piso.Visible = False
            pnBan.Visible = False
            pnAuto.Visible = False

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub LLAMARiNFRAESTRUCTURA(idPlantilla As Integer)
        Try

            Dim atributos As New FileAttributes
            Dim distribucionInfraestructuraSA As New distribucionInfraestructuraSA
            Dim distribucionInfraestructuraBE As New distribucionInfraestructura
            Dim conteo As Integer = 0
            Dim sumatoriaBoton As Integer = 1

            Dim estado As String = String.Empty
            estado = "P"

            distribucionInfraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
            distribucionInfraestructuraBE.estado = "A"
            distribucionInfraestructuraBE.tipo = "P"
            distribucionInfraestructuraBE.IDPlantilla = idPlantilla


            listaDistribucion = distribucionInfraestructuraSA.getDistribucionInfraestructuraPlantilla(distribucionInfraestructuraBE)

            DibujarControl(listaDistribucion)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub LLAMARiNFRAESTRUCTURAXACTIVO(IDACTIVO As Integer)
        Try

            Dim atributos As New FileAttributes
            Dim distribucionInfraestructuraSA As New distribucionInfraestructuraSA
            Dim distribucionInfraestructuraBE As New distribucionInfraestructura
            Dim conteo As Integer = 0
            Dim sumatoriaBoton As Integer = 1

            Dim estado As String = String.Empty
            estado = "P"

            distribucionInfraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
            distribucionInfraestructuraBE.tipo = "C"
            distribucionInfraestructuraBE.idActivo = IDACTIVO


            listaDistribucion = distribucionInfraestructuraSA.getDistribucionInfraestructura(distribucionInfraestructuraBE)

            DibujarControl(listaDistribucion)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub DibujarControl(listDistr As List(Of distribucionInfraestructura))
        '//IMAGNE TRY
        Try


            FlowNumero1.Controls.Clear()

            FlowPrimerPisoSector1.Controls.Clear()
            flpBus1Piso.Controls.Clear()
            flpMiniBan.Controls.Clear()
            flpAuto.Controls.Clear()

            For Each items In listDistr

                Dim b As New Button

                'b.ContextMenuStrip = ContextMenuStrip1

                b.Text = items.numeracion
                b.TextAlign = ContentAlignment.MiddleLeft
                b.TabIndex = 0
                b.FlatStyle = FlatStyle.Standard
                b.FlatStyle = System.Windows.Forms.FlatStyle.Flat
                b.ForeColor = System.Drawing.Color.White
                b.Size = New System.Drawing.Size(35, 35)
                b.Font = New Font(" Arial Narrow", 8, FontStyle.Bold)
                b.Tag = items



                b.UseVisualStyleBackColor = False

                Select Case items.idInfraestructura
                    Case "1"
                        FlowPrimerPisoSector1.Controls.Add(b)
                    Case "2"
                        FlowNumero1.Controls.Add(b)
                    Case "3"
                        flpBus1Piso.Controls.Add(b)
                    Case "4"
                        flpMiniBan.Controls.Add(b)
                    Case "5"
                        flpAuto.Controls.Add(b)
                End Select

                Select Case items.estado
                    Case "A"

                        b.BackgroundImage = My.Resources.usadoTrans
                        b.BackgroundImage.Tag = 1
                        b.BackgroundImageLayout = ImageLayout.Stretch
                        b.Name = 0

                    Case "L"
                        b.BackgroundImage = My.Resources.LibreBus
                        b.BackgroundImage.Tag = 1
                        b.BackgroundImageLayout = ImageLayout.Stretch
                        b.Name = 0

                    Case "C"
                        b.BackgroundImage = My.Resources.ConductorBus
                        b.BackgroundImage.Tag = 1
                        b.BackgroundImageLayout = ImageLayout.Stretch
                        b.Name = 0

                    Case "B"
                        b.BackgroundImage = My.Resources.BanioBus
                        b.BackgroundImage.Tag = 1
                        b.BackgroundImageLayout = ImageLayout.Stretch
                        b.Name = 0

                    Case "T"
                        b.BackgroundImage = My.Resources.TerramozaBus
                        b.BackgroundImage.Tag = 1
                        b.BackgroundImageLayout = ImageLayout.Stretch
                        b.Name = 0

                    Case "M"
                        b.BackgroundImage = My.Resources.tvBus
                        b.BackgroundImage.Tag = 1
                        b.BackgroundImageLayout = ImageLayout.Stretch
                        b.Name = 0

                    Case "I"
                        b.BackgroundImage = My.Resources.IngresoBus
                        b.BackgroundImage.Tag = 1
                        b.BackgroundImageLayout = ImageLayout.Stretch
                        b.Name = 0

                    Case "K"
                        b.BackgroundImage = My.Resources.CocinaBus
                        b.BackgroundImage.Tag = 1
                        b.BackgroundImageLayout = ImageLayout.Stretch
                        b.Name = 0

                End Select
                'b.ContextMenuStrip = ContextMenuStrip1
                'b.ContextMenuStrip.Tag = items

                'AddHandler b.ContextMenuStrip.ItemClicked, AddressOf contextMenuStrip_ItemClicked

                AddHandler b.Click, AddressOf Butto1
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub Butto1(sender As Object, e As EventArgs)
        'Dim productoBE As New documentoventaAbarrotes
        'Dim distribucionInfraestructuraSA As New VehiculoAsiento_PreciosSA
        'Dim distribucionInfraestructuraBE As New vehiculoAsiento_Precios

        Try

            Select Case TIPOCONTROL
                Case "ESPACIOS"
                    Dim C = CType(sender.TAG, distribucionInfraestructura)
                    PNMENU.Visible = True

                    IDINFRA = C.idDistribucion
                Case "NUMERACION"

                    Dim c = CType(sender.Tag, distribucionInfraestructura)


                    If (c.estado <> "A") Then
                        MessageBox.Show("SOLO ASIENTOS SE PUEDE INGRESAR UNA NUMERACION")
                    Else
                        Dim f As New FormComfNumeracion
                        f.pnBuscardor.Visible = True
                        f.StartPosition = FormStartPosition.CenterParent
                        f.ShowDialog(Me)
                        If f.Tag IsNot Nothing Then
                            Dim idDistribucion = c.idDistribucion
                            Dim numero = f.Tag

                            listaDistribucion.Where(Function(O) O.idDistribucion = idDistribucion And O.estado = "A").FirstOrDefault.numeracion = numero

                            DibujarControl(listaDistribucion)
                        End If
                    End If



            End Select

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    Public Sub GrabarBus(TIPOACTIVO As Integer)

        Dim infraestructuraSA As New infraestructuraSA
        Dim distribucionInfraestructuraBE As New distribucionInfraestructura
        Dim listaDistribucionInfraestructuraBE As New List(Of distribucionInfraestructura)

        Dim infraestructuraBE As New infraestructura
        Dim listainFraestructura As New List(Of infraestructura)

        Dim conponenteBE As New componente
        Dim listaConponenteBEE As New List(Of componente)


        Select Case TIPOACTIVO
            Case 1

                conponenteBE = New componente With {
                        .[idActivo] = CInt(txtActivo.Tag),
                        .[idEmpresa] = Gempresas.IdEmpresaRuc,
                        .[idEstablecimiento] = Nothing,
                        .[idPadre] = Nothing,
                        .[idItem] = Nothing,
                        .[descripcionItem] = txtActivo.Text,
                        .[estado] = "A",
                        .[tipo] = "C",
                        .[imagen] = Nothing,
                        .[direccionImagen] = Nothing,
                        .[usuarioActualizacion] = "ADMINISTRADOR",
                        .[fechaActualizacion] = Date.Now
                      }

                conponenteBE.listaComponentes = New List(Of componente)

                For Each ITEM In listaDistribucion.Where(Function(O) O.idInfraestructura = 1).ToList
                    Dim conponenteBE2 = New componente With {
                      .[idActivo] = CInt(txtActivo.Tag),
                      .[idEmpresa] = Gempresas.IdEmpresaRuc,
                      .[idEstablecimiento] = Nothing,
                      .[idPadre] = Nothing,
                      .[idItem] = Nothing,
                      .[descripcionItem] = "COMPONENTE - " & txtActivo.Text,
                      .[estado] = ITEM.estado,
                      .[tipo] = "C",
                      .[imagen] = Nothing,
                      .[direccionImagen] = Nothing,
                      .[usuarioActualizacion] = "ADMINISTRADOR",
                      .[fechaActualizacion] = Date.Now,
                      .IDInfraestructura = ITEM.idInfraestructura,
                      .tipoServicio = cboTipoServicio.SelectedValue
                    }

                    conponenteBE.listaComponentes.Add(conponenteBE2)

                Next



                'PISO 1
                infraestructuraBE = New infraestructura With {
                        .idInfraestructura = 0,
                .[idEmpresa] = Gempresas.IdEmpresaRuc,
                .[idEstablecimiento] = Nothing,
                .[idActivo] = CInt(txtActivo.Tag),
                .[idPadre] = Nothing,
                              .[numero] = 1,
                .[nombre] = "PISO",
                .[cantidad] = 30,
                .[estructura] = Nothing,
                .[tipo] = "C",
                .[estado] = "A",
                .[usuarioActualizacion] = "ADMINISTRADOR",
                .[fechaActualizacion] = Date.Now,
                .componenteBE = conponenteBE
              }

                listainFraestructura.Add(infraestructuraBE)


                conponenteBE = New componente With {
                .[idActivo] = CInt(txtActivo.Tag),
                .[idEmpresa] = Gempresas.IdEmpresaRuc,
                .[idEstablecimiento] = Nothing,
                .[idPadre] = Nothing,
                .[idItem] = Nothing,
                .[descripcionItem] = txtActivo.Text,
                .[estado] = "A",
                .[tipo] = "C",
                .[imagen] = Nothing,
                .[direccionImagen] = Nothing,
                .[usuarioActualizacion] = "ADMINISTRADOR",
                .[fechaActualizacion] = Date.Now
              }

                conponenteBE.listaComponentes = New List(Of componente)

                For Each ITEM In listaDistribucion.Where(Function(O) O.idInfraestructura = 2).ToList
                    Dim conponenteBE2 = New componente With {
                      .[idActivo] = CInt(txtActivo.Tag),
                      .[idEmpresa] = Gempresas.IdEmpresaRuc,
                      .[idEstablecimiento] = Nothing,
                      .[idPadre] = Nothing,
                      .[idItem] = Nothing,
                      .[descripcionItem] = "COMPONENTE - " & txtActivo.Text,
                      .[estado] = ITEM.estado,
                      .[tipo] = "C",
                      .[imagen] = Nothing,
                      .[direccionImagen] = Nothing,
                      .[usuarioActualizacion] = "ADMINISTRADOR",
                      .[fechaActualizacion] = Date.Now,
                      .IDInfraestructura = ITEM.idInfraestructura,
                      .tipoServicio = cboTipoServicio.SelectedValue
                    }

                    conponenteBE.listaComponentes.Add(conponenteBE2)

                Next

                'PISO 2
                infraestructuraBE = New infraestructura With {
                    .idInfraestructura = 0,
                .[idEmpresa] = Gempresas.IdEmpresaRuc,
                .[idEstablecimiento] = Nothing,
                .[idActivo] = CInt(txtActivo.Tag),
                .[idPadre] = Nothing,
                          .[numero] = 1,
                .[nombre] = "PISO",
                .[cantidad] = 75,
                .[estructura] = Nothing,
                .[tipo] = "C",
                .[estado] = "A",
                .[usuarioActualizacion] = "ADMINISTRADOR",
                .[fechaActualizacion] = Date.Now,
                .componenteBE = conponenteBE
              }

                listainFraestructura.Add(infraestructuraBE)

                infraestructuraSA.SaveActivoInfra(listainFraestructura)


            Case 2
                conponenteBE = New componente With {
                      .[idActivo] = CInt(txtActivo.Tag),
                      .[idEmpresa] = Gempresas.IdEmpresaRuc,
                      .[idEstablecimiento] = Nothing,
                      .[idPadre] = Nothing,
                      .[idItem] = Nothing,
                      .[descripcionItem] = txtActivo.Text,
                      .[estado] = "A",
                      .[tipo] = "C",
                      .[imagen] = Nothing,
                      .[direccionImagen] = Nothing,
                      .[usuarioActualizacion] = "ADMINISTRADOR",
                      .[fechaActualizacion] = Date.Now
                    }

                conponenteBE.listaComponentes = New List(Of componente)

                For Each ITEM In listaDistribucion.Where(Function(O) O.idInfraestructura = 3).ToList
                    Dim conponenteBE2 = New componente With {
                      .[idActivo] = CInt(txtActivo.Tag),
                      .[idEmpresa] = Gempresas.IdEmpresaRuc,
                      .[idEstablecimiento] = Nothing,
                      .[idPadre] = Nothing,
                      .[idItem] = Nothing,
                      .[descripcionItem] = "COMPONENTE - " & txtActivo.Text,
                      .[estado] = ITEM.estado,
                      .[tipo] = "C",
                      .[imagen] = Nothing,
                      .[direccionImagen] = Nothing,
                      .[usuarioActualizacion] = "ADMINISTRADOR",
                      .[fechaActualizacion] = Date.Now,
                      .IDInfraestructura = ITEM.idInfraestructura,
                      .tipoServicio = cboTipoServicio.SelectedValue
                    }

                    conponenteBE.listaComponentes.Add(conponenteBE2)

                Next



                'PISO 1
                infraestructuraBE = New infraestructura With {
                .[idEmpresa] = Gempresas.IdEmpresaRuc,
                .[idEstablecimiento] = Nothing,
                .[idActivo] = CInt(txtActivo.Tag),
                .[idPadre] = Nothing,
                                .[numero] = 2,
                .[nombre] = "PISO",
                .[cantidad] = 75,
                .[estructura] = Nothing,
                .[tipo] = "C",
                .[estado] = "A",
                .[usuarioActualizacion] = "ADMINISTRADOR",
                .[fechaActualizacion] = Date.Now,
                .componenteBE = conponenteBE
              }

                listainFraestructura.Add(infraestructuraBE)

                infraestructuraSA.SaveActivoInfra(listainFraestructura)

            Case 3

                conponenteBE = New componente With {
      .[idActivo] = CInt(txtActivo.Tag),
      .[idEmpresa] = Gempresas.IdEmpresaRuc,
      .[idEstablecimiento] = Nothing,
      .[idPadre] = Nothing,
      .[idItem] = Nothing,
      .[descripcionItem] = txtActivo.Text,
      .[estado] = "A",
      .[tipo] = "C",
      .[imagen] = Nothing,
      .[direccionImagen] = Nothing,
      .[usuarioActualizacion] = "ADMINISTRADOR",
      .[fechaActualizacion] = Date.Now
    }

                conponenteBE.listaComponentes = New List(Of componente)

                For Each ITEM In listaDistribucion.Where(Function(O) O.idInfraestructura = 4).ToList
                    Dim conponenteBE2 = New componente With {
                      .[idActivo] = CInt(txtActivo.Tag),
                      .[idEmpresa] = Gempresas.IdEmpresaRuc,
                      .[idEstablecimiento] = Nothing,
                      .[idPadre] = Nothing,
                      .[idItem] = Nothing,
                      .[descripcionItem] = "COMPONENTE - " & txtActivo.Text,
                      .[estado] = ITEM.estado,
                      .[tipo] = "C",
                      .[imagen] = Nothing,
                      .[direccionImagen] = Nothing,
                      .[usuarioActualizacion] = "ADMINISTRADOR",
                      .[fechaActualizacion] = Date.Now,
                      .IDInfraestructura = ITEM.idInfraestructura,
                      .tipoServicio = cboTipoServicio.SelectedValue
                    }

                    conponenteBE.listaComponentes.Add(conponenteBE2)

                Next



                'PISO 1
                infraestructuraBE = New infraestructura With {
                .[idEmpresa] = Gempresas.IdEmpresaRuc,
                .[idEstablecimiento] = Nothing,
                .[idActivo] = CInt(txtActivo.Tag),
                .[idPadre] = Nothing,
                             .[numero] = 1,
                .[nombre] = "PISO",
                .[cantidad] = 30,
                .[estructura] = Nothing,
                .[tipo] = "C",
                .[estado] = "A",
                .[usuarioActualizacion] = "ADMINISTRADOR",
                .[fechaActualizacion] = Date.Now,
                .componenteBE = conponenteBE
              }

                listainFraestructura.Add(infraestructuraBE)

                infraestructuraSA.SaveActivoInfra(listainFraestructura)

            Case 4


                conponenteBE = New componente With {
.[idActivo] = CInt(txtActivo.Tag),
.[idEmpresa] = Gempresas.IdEmpresaRuc,
.[idEstablecimiento] = Nothing,
.[idPadre] = Nothing,
.[idItem] = Nothing,
.[descripcionItem] = txtActivo.Text,
.[estado] = "A",
.[tipo] = "C",
.[imagen] = Nothing,
.[direccionImagen] = Nothing,
.[usuarioActualizacion] = "ADMINISTRADOR",
.[fechaActualizacion] = Date.Now
}

                conponenteBE.listaComponentes = New List(Of componente)

                For Each ITEM In listaDistribucion.Where(Function(O) O.idInfraestructura = 5).ToList
                    Dim conponenteBE2 = New componente With {
                      .[idActivo] = CInt(txtActivo.Tag),
                      .[idEmpresa] = Gempresas.IdEmpresaRuc,
                      .[idEstablecimiento] = Nothing,
                      .[idPadre] = Nothing,
                      .[idItem] = Nothing,
                      .[descripcionItem] = "COMPONENTE - " & txtActivo.Text,
                      .[estado] = ITEM.estado,
                      .[tipo] = "C",
                      .[imagen] = Nothing,
                      .[direccionImagen] = Nothing,
                      .[usuarioActualizacion] = "ADMINISTRADOR",
                      .[fechaActualizacion] = Date.Now,
                      .IDInfraestructura = ITEM.idInfraestructura,
                      .tipoServicio = cboTipoServicio.SelectedValue
                    }

                    conponenteBE.listaComponentes.Add(conponenteBE2)

                Next



                'PISO 1
                infraestructuraBE = New infraestructura With {
                .[idEmpresa] = Gempresas.IdEmpresaRuc,
                .[idEstablecimiento] = Nothing,
                .[idActivo] = CInt(txtActivo.Tag),
                .[idPadre] = Nothing,
                             .[numero] = 1,
                .[nombre] = "PISO",
                .[cantidad] = 9,
                .[estructura] = Nothing,
                .[tipo] = "C",
                .[estado] = "A",
                .[usuarioActualizacion] = "ADMINISTRADOR",
                .[fechaActualizacion] = Date.Now,
                .componenteBE = conponenteBE
              }

                listainFraestructura.Add(infraestructuraBE)

                infraestructuraSA.SaveActivoInfra(listainFraestructura)

        End Select



    End Sub

    Public Sub grabarBusNumeracion()
        Try
            Dim distribucionInfraSA As New distribucionInfraestructuraSA

            distribucionInfraSA.updateDistribucionNumeracion(listaDistribucion)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Select Case TIPOCONTROL
                Case "ESPACIOS"
                    CONDICION = "A"
                    PNMENU.Visible = False
                    listaDistribucion.Where(Function(O) O.idDistribucion = IDINFRA).FirstOrDefault.estado = CONDICION
                    DibujarControl(listaDistribucion)

                Case "NUMERACION"




            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Select Case TIPOCONTROL
                Case "ESPACIOS"
                    CONDICION = "L"
                    PNMENU.Visible = False
                    listaDistribucion.Where(Function(O) O.idDistribucion = IDINFRA).FirstOrDefault.estado = CONDICION
                    listaDistribucion.Where(Function(O) O.idDistribucion = IDINFRA).FirstOrDefault.numeracion = ""
                    DibujarControl(listaDistribucion)

                Case "NUMERACION"

            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Select Case TIPOCONTROL
                Case "ESPACIOS"
                    CONDICION = "C"
                    PNMENU.Visible = False
                    listaDistribucion.Where(Function(O) O.idDistribucion = IDINFRA).FirstOrDefault.estado = CONDICION
                    listaDistribucion.Where(Function(O) O.idDistribucion = IDINFRA).FirstOrDefault.numeracion = ""
                    DibujarControl(listaDistribucion)

                Case "NUMERACION"

            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            Select Case TIPOCONTROL
                Case "ESPACIOS"
                    CONDICION = "B"
                    PNMENU.Visible = False
                    listaDistribucion.Where(Function(O) O.idDistribucion = IDINFRA).FirstOrDefault.estado = CONDICION
                    listaDistribucion.Where(Function(O) O.idDistribucion = IDINFRA).FirstOrDefault.numeracion = ""
                    DibujarControl(listaDistribucion)

                Case "NUMERACION"

            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Try
            Select Case TIPOCONTROL
                Case "ESPACIOS"
                    CONDICION = "M"
                    PNMENU.Visible = False
                    listaDistribucion.Where(Function(O) O.idDistribucion = IDINFRA).FirstOrDefault.estado = CONDICION
                    listaDistribucion.Where(Function(O) O.idDistribucion = IDINFRA).FirstOrDefault.numeracion = ""
                    DibujarControl(listaDistribucion)

                Case "NUMERACION"

            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Try
            Select Case TIPOCONTROL
                Case "ESPACIOS"
                    CONDICION = "T"
                    PNMENU.Visible = False
                    listaDistribucion.Where(Function(O) O.idDistribucion = IDINFRA).FirstOrDefault.estado = CONDICION
                    listaDistribucion.Where(Function(O) O.idDistribucion = IDINFRA).FirstOrDefault.numeracion = ""
                    DibujarControl(listaDistribucion)

                Case "NUMERACION"

            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub rbEspacio_CheckedChanged(sender As Object, e As EventArgs) Handles rbEspacio.CheckedChanged
        If (rbEspacio.Checked = True) Then
            rbEspacio.Checked = True
            rbControlAsientos.Checked = False
            TIPOCONTROL = "ESPACIOS"
        End If
    End Sub

    Private Sub rbControlAsientos_CheckedChanged(sender As Object, e As EventArgs) Handles rbControlAsientos.CheckedChanged
        If (rbControlAsientos.Checked = True) Then
            rbControlAsientos.Checked = True
            rbEspacio.Checked = False
            TIPOCONTROL = "NUMERACION"
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Try
            Select Case TIPOCONTROL
                Case "ESPACIOS"
                    CONDICION = "I"
                    PNMENU.Visible = False
                    listaDistribucion.Where(Function(O) O.idDistribucion = IDINFRA).FirstOrDefault.estado = CONDICION
                    listaDistribucion.Where(Function(O) O.idDistribucion = IDINFRA).FirstOrDefault.numeracion = ""
                    DibujarControl(listaDistribucion)

                Case "NUMERACION"

            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click
        PNMENU.Visible = False
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Try
            Select Case TIPOCONTROL
                Case "ESPACIOS"
                    CONDICION = "K"
                    PNMENU.Visible = False
                    listaDistribucion.Where(Function(O) O.idDistribucion = IDINFRA).FirstOrDefault.estado = CONDICION
                    listaDistribucion.Where(Function(O) O.idDistribucion = IDINFRA).FirstOrDefault.numeracion = ""
                    DibujarControl(listaDistribucion)

                Case "NUMERACION"

            End Select
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cboPlantilla_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboPlantilla.SelectionChangeCommitted
        Try
            PnCarga.Visible = True
            If (cboPlantilla.SelectedValue = 1) Then
                pnBus2Pisos.Visible = True
                pnBus1Piso.Visible = False
                pnBan.Visible = False
                pnAuto.Visible = False

                LLAMARiNFRAESTRUCTURA(cboPlantilla.SelectedValue)

            ElseIf (cboPlantilla.SelectedValue = 2) Then
                pnBus2Pisos.Visible = False
                pnBus1Piso.Visible = True
                pnBan.Visible = False
                pnAuto.Visible = False

                LLAMARiNFRAESTRUCTURA(cboPlantilla.SelectedValue)

            ElseIf (cboPlantilla.SelectedValue = 3) Then
                pnBus2Pisos.Visible = False
                pnBus1Piso.Visible = False
                pnBan.Visible = True
                pnAuto.Visible = False


                LLAMARiNFRAESTRUCTURA(cboPlantilla.SelectedValue)

            ElseIf (cboPlantilla.SelectedValue = 4) Then
                pnBus2Pisos.Visible = False
                pnBus1Piso.Visible = False
                pnBan.Visible = False
                pnAuto.Visible = True


                LLAMARiNFRAESTRUCTURA(cboPlantilla.SelectedValue)

            End If
            PnCarga.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
        Select Case TIPOCONTROL
            Case "ESPACIOS"
                GrabarBus(cboPlantilla.SelectedValue)
                Me.Visible = False
                FormPurchase.UCMaestroActivo.Visible = True
                FormPurchase.UCMaestroActivo.GetVehiculos()
            Case "NUMERACION"
                grabarBusNumeracion()
                Me.Visible = False
                FormPurchase.UCMaestroActivo.GetVehiculos()
        End Select

    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        Me.Visible = False
        FormPurchase.UCMaestroActivo.Visible = True
    End Sub

    'Private Sub contextMenuStrip_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)

    '    Try
    '        Dim C = CType(sender.TAG, distribucionInfraestructura)

    '        If (e.ClickedItem.Text = "1") Then
    '            listaDistribucion.Where(Function(O) O.idDistribucion = C.idDistribucion).FirstOrDefault.estado = "B"
    '            DibujarControl(listaDistribucion)
    '        ElseIf (E.ClickedItem.Text = "2") Then
    '            listaDistribucion.Where(Function(O) O.idDistribucion = C.idDistribucion).FirstOrDefault.estado = "C"
    '            DibujarControl(listaDistribucion)
    '        End If

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try

    'End Sub



    ''Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click

    '    Dim c = CType(sender.TAG, distribucionInfraestructura)

    '    c.estado = "C"

    '    DibujarControl(listaDistribucion)

    '    MessageBox.Show("SE CAMBIO LA IMAGEN")
    'End Sub

    'Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
    '    Dim c = CType(sender.TAG, distribucionInfraestructura)

    '    c.estado = "B"

    '    DibujarControl(listaDistribucion)

    '    MessageBox.Show("SE CAMBIO LA IMAGEN")
    'End Sub
End Class
