Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General

Public Class FormNuevoRubro

    Dim listaCostoComercial As New List(Of negocioComercial)
    Dim regionesSA As New regionesSA
    Dim provinciasSA As New provinciasSA
    Dim distritosSA As New distritosSA
    Public Property ListaRegiones As List(Of regiones)
    Public Property ListaProvinvias As List(Of provincias)
    Public Property ListaDistritos As List(Of distritos)
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        txtPeriodo.Value = CDate(Date.Now).AddMonths(-1)
        CargarUbigeo()
        GetRegiones()
    End Sub

#Region "METODO"

    Private Sub CREARPLANTILLA()
        Dim infraestructuraSA As New infraestructuraSA
        Dim distribucionInfraestructuraBE As New distribucionInfraestructura
        Dim listaDistribucionInfraestructuraBE As New List(Of distribucionInfraestructura)

        Dim infraestructuraBE As New infraestructura
        Dim listainFraestructura As New List(Of infraestructura)

        Dim conponenteBE As New componente
        Dim listaConponenteBEE As New List(Of componente)

        conponenteBE = New componente With {
        .[idActivo] = Nothing,
        .[idEmpresa] = Gempresas.IdEmpresaRuc,
        .[idEstablecimiento] = Nothing,
        .[idPadre] = Nothing,
        .[idItem] = Nothing,
        .[descripcionItem] = "ASIENTOS",
        .[estado] = "A",
        .[tipo] = "P1",
        .[imagen] = Nothing,
        .[direccionImagen] = Nothing,
        .[usuarioActualizacion] = "ADMINISTRADOR",
        .[fechaActualizacion] = Date.Now
      }

        conponenteBE.listaComponentes = New List(Of componente)

        For index As Integer = 1 To 30
            Dim conponenteBE2 = New componente With {
              .[idActivo] = Nothing,
              .[idEmpresa] = Gempresas.IdEmpresaRuc,
              .[idEstablecimiento] = Nothing,
              .[idPadre] = Nothing,
              .[idItem] = Nothing,
              .[descripcionItem] = "ASIENTO",
              .[estado] = "A",
              .[tipo] = "P",
              .[imagen] = Nothing,
              .[direccionImagen] = Nothing,
              .[usuarioActualizacion] = "ADMINISTRADOR",
              .[fechaActualizacion] = Date.Now
            }

            conponenteBE.listaComponentes.Add(conponenteBE2)

        Next

        'PISO 1
        infraestructuraBE = New infraestructura With {
        .[idEmpresa] = Gempresas.IdEmpresaRuc,
        .[idEstablecimiento] = Nothing,
        .[idActivo] = Nothing,
        .[idPadre] = Nothing,
             .[numero] = 1,
        .[nombre] = "PISO",
        .[cantidad] = 30,
        .[estructura] = Nothing,
        .[tipo] = "P",
        .[estado] = "A",
        .[usuarioActualizacion] = "ADMINISTRADOR",
        .[fechaActualizacion] = Date.Now,
        .componenteBE = conponenteBE
      }

        listainFraestructura.Add(infraestructuraBE)

        conponenteBE = New componente With {
        .[idActivo] = Nothing,
        .[idEmpresa] = Gempresas.IdEmpresaRuc,
        .[idEstablecimiento] = Nothing,
        .[idPadre] = Nothing,
        .[idItem] = Nothing,
        .[descripcionItem] = "ASIENTOS",
        .[estado] = "A",
        .[tipo] = "P2",
        .[imagen] = Nothing,
        .[direccionImagen] = Nothing,
        .[usuarioActualizacion] = "ADMINISTRADOR",
        .[fechaActualizacion] = Date.Now
      }

        conponenteBE.listaComponentes = New List(Of componente)

        For index As Integer = 1 To 75
            Dim conponenteBE2 = New componente With {
              .[idActivo] = Nothing,
              .[idEmpresa] = Gempresas.IdEmpresaRuc,
              .[idEstablecimiento] = Nothing,
              .[idPadre] = Nothing,
              .[idItem] = Nothing,
              .[descripcionItem] = "ASIENTO",
              .[estado] = "A",
              .[tipo] = "P",
              .[imagen] = Nothing,
              .[direccionImagen] = Nothing,
              .[usuarioActualizacion] = "ADMINISTRADOR",
              .[fechaActualizacion] = Date.Now
            }

            conponenteBE.listaComponentes.Add(conponenteBE2)

        Next

        'PISO 2
        infraestructuraBE = New infraestructura With {
        .[idEmpresa] = Gempresas.IdEmpresaRuc,
        .[idEstablecimiento] = Nothing,
        .[idActivo] = Nothing,
        .[idPadre] = Nothing,
            .[numero] = 2,
        .[nombre] = "PISO",
        .[cantidad] = 75,
        .[estructura] = Nothing,
        .[tipo] = "P",
        .[estado] = "A",
        .[usuarioActualizacion] = "ADMINISTRADOR",
        .[fechaActualizacion] = Date.Now,
        .componenteBE = conponenteBE
      }

        listainFraestructura.Add(infraestructuraBE)



        '//////////////////////////////////////PLANTILLA BUS 1////////////////////////////////////////////////////////

        conponenteBE = New componente With {
       .[idActivo] = Nothing,
       .[idEmpresa] = Gempresas.IdEmpresaRuc,
       .[idEstablecimiento] = Nothing,
       .[idPadre] = Nothing,
       .[idItem] = Nothing,
       .[descripcionItem] = "ASIENTOS BUS 1 PISO",
       .[estado] = "A",
       .[tipo] = "P1",
       .[imagen] = Nothing,
       .[direccionImagen] = Nothing,
       .[usuarioActualizacion] = "ADMINISTRADOR",
       .[fechaActualizacion] = Date.Now
     }

        conponenteBE.listaComponentes = New List(Of componente)

        For index As Integer = 1 To 75
            Dim conponenteBE2 = New componente With {
              .[idActivo] = Nothing,
              .[idEmpresa] = Gempresas.IdEmpresaRuc,
              .[idEstablecimiento] = Nothing,
              .[idPadre] = Nothing,
              .[idItem] = Nothing,
              .[descripcionItem] = "ASIENTO",
              .[estado] = "A",
              .[tipo] = "P",
              .[imagen] = Nothing,
              .[direccionImagen] = Nothing,
              .[usuarioActualizacion] = "ADMINISTRADOR",
              .[fechaActualizacion] = Date.Now
            }

            conponenteBE.listaComponentes.Add(conponenteBE2)

        Next

        'PISO 1
        infraestructuraBE = New infraestructura With {
        .[idEmpresa] = Gempresas.IdEmpresaRuc,
        .[idEstablecimiento] = Nothing,
        .[idActivo] = Nothing,
        .[idPadre] = Nothing,
              .[numero] = 1,
        .[nombre] = "PISO",
        .[cantidad] = 75,
        .[estructura] = Nothing,
        .[tipo] = "P",
        .[estado] = "A",
        .[usuarioActualizacion] = "ADMINISTRADOR",
        .[fechaActualizacion] = Date.Now,
        .componenteBE = conponenteBE
      }

        listainFraestructura.Add(infraestructuraBE)

        '//////////////////////////////////////PLANTILLA MINIBAN ////////////////////////////////////////////////////////

        conponenteBE = New componente With {
       .[idActivo] = Nothing,
       .[idEmpresa] = Gempresas.IdEmpresaRuc,
       .[idEstablecimiento] = Nothing,
       .[idPadre] = Nothing,
       .[idItem] = Nothing,
       .[descripcionItem] = "ASIENTOS MINIBAN",
       .[estado] = "A",
       .[tipo] = "P1",
       .[imagen] = Nothing,
       .[direccionImagen] = Nothing,
       .[usuarioActualizacion] = "ADMINISTRADOR",
       .[fechaActualizacion] = Date.Now
     }

        conponenteBE.listaComponentes = New List(Of componente)

        For index As Integer = 1 To 30
            Dim conponenteBE2 = New componente With {
              .[idActivo] = Nothing,
              .[idEmpresa] = Gempresas.IdEmpresaRuc,
              .[idEstablecimiento] = Nothing,
              .[idPadre] = Nothing,
              .[idItem] = Nothing,
              .[descripcionItem] = "ASIENTO",
              .[estado] = "A",
              .[tipo] = "P",
              .[imagen] = Nothing,
              .[direccionImagen] = Nothing,
              .[usuarioActualizacion] = "ADMINISTRADOR",
              .[fechaActualizacion] = Date.Now
            }

            conponenteBE.listaComponentes.Add(conponenteBE2)

        Next

        'PISO 1
        infraestructuraBE = New infraestructura With {
        .[idEmpresa] = Gempresas.IdEmpresaRuc,
        .[idEstablecimiento] = Nothing,
        .[idActivo] = Nothing,
        .[idPadre] = Nothing,
               .[numero] = 1,
        .[nombre] = "PISO",
        .[cantidad] = 30,
        .[estructura] = Nothing,
        .[tipo] = "P",
        .[estado] = "A",
        .[usuarioActualizacion] = "ADMINISTRADOR",
        .[fechaActualizacion] = Date.Now,
        .componenteBE = conponenteBE
      }

        listainFraestructura.Add(infraestructuraBE)


        '//////////////////////////////////////PLANTILLA AUTO////////////////////////////////////////////////////////

        conponenteBE = New componente With {
       .[idActivo] = Nothing,
       .[idEmpresa] = Gempresas.IdEmpresaRuc,
       .[idEstablecimiento] = Nothing,
       .[idPadre] = Nothing,
       .[idItem] = Nothing,
       .[descripcionItem] = "ASIENTOS AUTO",
       .[estado] = "A",
       .[tipo] = "PA",
       .[imagen] = Nothing,
       .[direccionImagen] = Nothing,
       .[usuarioActualizacion] = "ADMINISTRADOR",
       .[fechaActualizacion] = Date.Now
     }

        conponenteBE.listaComponentes = New List(Of componente)

        For index As Integer = 1 To 9
            Dim conponenteBE2 = New componente With {
              .[idActivo] = Nothing,
              .[idEmpresa] = Gempresas.IdEmpresaRuc,
              .[idEstablecimiento] = Nothing,
              .[idPadre] = Nothing,
              .[idItem] = Nothing,
              .[descripcionItem] = "ASIENTO",
              .[estado] = "A",
              .[tipo] = "P",
              .[imagen] = Nothing,
              .[direccionImagen] = Nothing,
              .[usuarioActualizacion] = "ADMINISTRADOR",
              .[fechaActualizacion] = Date.Now
            }

            conponenteBE.listaComponentes.Add(conponenteBE2)

        Next

        'PISO 1
        infraestructuraBE = New infraestructura With {
        .[idEmpresa] = Gempresas.IdEmpresaRuc,
        .[idEstablecimiento] = Nothing,
        .[idActivo] = Nothing,
        .[idPadre] = Nothing,
          .[numero] = 1,
        .[nombre] = "PISO",
        .[cantidad] = 10,
        .[estructura] = Nothing,
        .[tipo] = "P",
        .[estado] = "A",
        .[usuarioActualizacion] = "ADMINISTRADOR",
        .[fechaActualizacion] = Date.Now,
        .componenteBE = conponenteBE
      }

        listainFraestructura.Add(infraestructuraBE)


        infraestructuraSA.SavePLantillaInfra(listainFraestructura)

    End Sub

    Private Sub CargarUbigeo()
        Dim regioneSA As New regionesSA

        ListaRegiones = regioneSA.ListarUbigeosActivos()
    End Sub

    Public Sub GetRegiones()

        ComboRegionOrigen.DataSource = ListaRegiones.ToList
        ComboRegionOrigen.ValueMember = "id"
        ComboRegionOrigen.DisplayMember = "name"
    End Sub

    Public Sub GetProvincias(ID As String)

        For Each i In ListaRegiones
            ListaProvinvias = i.provincias.Where(Function(o) o.region_id = ID).ToList
            If (ListaProvinvias.Count > 0) Then
                Exit For
            End If
        Next

        ComboProvinciaOrigen.DataSource = ListaProvinvias
        ComboProvinciaOrigen.ValueMember = "id"
        ComboProvinciaOrigen.DisplayMember = "name"
    End Sub

    Public Sub GetDistritos(ID As String)
        Dim distritoBE As New distritos

        For Each i In ListaRegiones
            For Each x In i.provincias.ToList
                ListaDistritos = x.distritos.Where(Function(o) o.province_id = ID).ToList
                If (ListaDistritos.Count > 0) Then
                    Exit For
                End If

            Next
            If (ListaDistritos.Count > 0) Then
                Exit For
            End If

        Next

        ComboDistritoOrigen.DataSource = ListaDistritos
        ComboDistritoOrigen.ValueMember = "id"
        ComboDistritoOrigen.DisplayMember = "name"
    End Sub

#End Region

    Public Sub ListarCargosPadre()
        Dim sa As New negocioComercialSA

        listaCostoComercial = sa.GetListaNegocioComercial()

        cboNegocioOrg.ValueMember = "IdNegocioComercial"
        cboNegocioOrg.DisplayMember = "nombreRubro"
        cboNegocioOrg.DataSource = listaCostoComercial.Where(Function(o) o.tipo = "UN").ToList

    End Sub
    Private Sub rbConControl_CheckedChanged(sender As Object, e As EventArgs) Handles rbConControl.CheckedChanged
        If (rbConControl.Checked = True) Then
            rbConControl.Checked = True
            rbSinControl.Checked = False

            If (listaCostoComercial.Count > 0) Then
                cboNegocioOrg.DataSource = Nothing
                cboNegocioOrg.ValueMember = "IdNegocioComercial"
                cboNegocioOrg.DisplayMember = "nombreRubro"
                cboNegocioOrg.DataSource = listaCostoComercial.Where(Function(o) o.tipo = "UN").ToList
            End If

        End If
    End Sub

    Private Sub rbSinControl_CheckedChanged(sender As Object, e As EventArgs) Handles rbSinControl.CheckedChanged
        If (rbSinControl.Checked = True) Then
            rbConControl.Checked = False
            rbSinControl.Checked = True

            'cboNegocioOrg.DataSource = Nothing
            cboNegocioOrg.ValueMember = "IdNegocioComercial"
            cboNegocioOrg.DisplayMember = "nombreRubro"
            cboNegocioOrg.DataSource = listaCostoComercial.Where(Function(o) o.tipo = "UA").ToList

        End If
    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
        Try
            Dim centroCostoBE As New centrocosto

            If (rbConControl.Checked = True) Then

                Dim RegionBE As String = CStr(ComboRegionOrigen.SelectedValue).Substring(0, 2)
                Dim provinciaBE As String = CStr(ComboProvinciaOrigen.SelectedValue).Substring(2, 2)
                Dim distritoBE As String = CStr(ComboDistritoOrigen.SelectedValue).Substring(4, 2)

                centroCostoBE.TipoEstab = "UN"
                centroCostoBE.IDNegocioComercial = cboNegocioOrg.SelectedValue
                centroCostoBE.ubigeo = RegionBE & provinciaBE & distritoBE
                centroCostoBE.direccion = txtDireccion.Text
                centroCostoBE.telefono = txttelefono.Text
                centroCostoBE.telefono2 = txtCelular.Text
                centroCostoBE.tipo = "UN"
                centroCostoBE.inicioOperaciones = txtPeriodo.Value

            ElseIf (rbSinControl.Checked = True) Then

                Dim RegionBE As String = CStr(ComboRegionOrigen.SelectedValue).Substring(0, 2)
                Dim provinciaBE As String = CStr(ComboProvinciaOrigen.SelectedValue).Substring(2, 2)
                Dim distritoBE As String = CStr(ComboDistritoOrigen.SelectedValue).Substring(4, 2)


                Select Case cboNegocioOrg.Text
                    Case "COMERCIAL"
                        centroCostoBE.tipo = "CM"

                    Case "LOGISTICA"
                        centroCostoBE.tipo = "LG"

                    Case "FINANZAS"
                        centroCostoBE.tipo = "FN"

                    Case "RR.HH."
                        centroCostoBE.tipo = "RH"

                    Case "TICS"
                        centroCostoBE.tipo = "TC"

                End Select

                centroCostoBE.TipoEstab = "SC"
                centroCostoBE.IDNegocioComercial = cboNegocioOrg.SelectedValue
                centroCostoBE.ubigeo = RegionBE & provinciaBE & distritoBE
                centroCostoBE.direccion = txtDireccion.Text
                centroCostoBE.telefono = txttelefono.Text
                centroCostoBE.telefono2 = txtCelular.Text
                centroCostoBE.inicioOperaciones = txtPeriodo.Value
            End If

            Me.Tag = centroCostoBE

            Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        'Close()
    End Sub

    Private Sub ComboRegionOrigen_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboRegionOrigen.SelectedValueChanged
        Try
            If IsNumeric(ComboRegionOrigen.SelectedValue) Then
                GetProvincias(ComboRegionOrigen.SelectedValue)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ComboProvinciaOrigen_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboProvinciaOrigen.SelectedValueChanged
        Try
            If IsNumeric(ComboProvinciaOrigen.SelectedValue) Then
                GetDistritos(ComboProvinciaOrigen.SelectedValue)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cboNegocioOrg_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboNegocioOrg.SelectionChangeCommitted
        Try
            Dim consultaSA As New infraestructuraSA

            Dim CONTEO = consultaSA.getCONTEOPlANTILLA(New infraestructura With {.idEmpresa = Gempresas.IdEmpresaRuc})

            If (CONTEO = 0) Then
                If (cboNegocioOrg.Text = "TRANSPORTE") Then
                    CREARPLANTILLA()
                End If

            End If

        Catch ex As Exception

        End Try
    End Sub
End Class