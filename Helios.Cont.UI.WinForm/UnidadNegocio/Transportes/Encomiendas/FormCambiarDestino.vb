Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Cont.Business.Entity
Imports Helios.General
Imports System.Net
Imports System.IO

Public Class FormCambiarDestino

#Region "Attributes"
    Public Property SelDocumento As Integer
    Public Property PersonaSA As New PersonaSA
#End Region

#Region "Constructors"
    Public Sub New(IdDocumento As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(GridEncomiendas, True, False, 9.0F)
        GetAgencias()
        GetUbicarDocumentoVenta(IdDocumento)
        SelDocumento = IdDocumento
    End Sub

#End Region

#Region "Methods"
    Private Sub GetAgencias()
        Dim agenciaSA As New establecimientoSA
        Dim listaAgenciasOrigen = ListaAgencias.Where(Function(o) o.TipoEstab = "UN").ToList
        '      Dim listaAgenciasDestino = listaAgencias.Where(Function(o) o.TipoEstab = "AG").ToList

        ComboAgenciaOrigen.DataSource = listaAgenciasOrigen
        ComboAgenciaOrigen.DisplayMember = "nombre"
        ComboAgenciaOrigen.ValueMember = "idCentroCosto"
        ComboAgenciaOrigen.Text = GEstableciento.NombreEstablecimiento
    End Sub

    Private Sub GetUbicarDocumentoVenta(IdDocumento As Integer)
        Dim ventaSA As New DocumentoventaTransporteSA

        Dim venta = ventaSA.DocumentoTransporteSelID(New documentoventaTransporte With {.idDocumento = IdDocumento})

        If venta IsNot Nothing Then
            Dim dt As New DataTable
            dt.Columns.Add("codigo")
            dt.Columns.Add("tipo")
            dt.Columns.Add("detalle")
            dt.Columns.Add("cantidad")
            dt.Columns.Add("unidad")
            dt.Columns.Add("importe")

            'Tag = venta.idDocumento
            TextNumIdentrazon.Text = ""
            TextEmpresaPasajero.Text = venta.Remitente

            ComboAgenciaOrigen.SelectedValue = venta.idOrganizacion
            ComboAgenciaDestino.SelectedValue = venta.agenciaDestino_id

            If venta.CustomPerson.idPersona IsNot Nothing Then
                RadioButton1.Checked = True
                textPersona.Text = venta.CustomPerson.nombreCompleto
                textPersona.Tag = Integer.Parse(venta.CustomPerson.codigo)
                txtruc.Text = venta.CustomPerson.idPersona
                textPersona.Enabled = False
                textPersona.ReadOnly = True
            Else
                RadioButton2.Checked = True
                txtruc.Text = ""
                textPersona.Text = venta.comprador
                textPersona.Enabled = True
                textPersona.ReadOnly = False
            End If

            For Each i In venta.documentoventaTransporteDetalle
                dt.Rows.Add(i.secuencia, i.tipo, i.detalle, i.cantidad, i.unidadMedida, i.importe)
            Next
            GridEncomiendas.DataSource = dt
        End If

    End Sub
#End Region

#Region "Events"
    Private Sub ComboAgenciaOrigen_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboAgenciaOrigen.SelectedValueChanged
        Try
            If IsNumeric(ComboAgenciaOrigen.SelectedValue) Then

                Dim lista = ListaAgencias.Where(Function(o) o.TipoEstab = "UN" And o.idCentroCosto <> ComboAgenciaOrigen.SelectedValue).ToList

                ComboAgenciaDestino.DataSource = lista
                ComboAgenciaDestino.DisplayMember = "nombre"
                ComboAgenciaDestino.ValueMember = "idCentroCosto"
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub RoundButton22_Click(sender As Object, e As EventArgs) Handles RoundButton22.Click
        If textPersona.Text.Trim.Length > 0 Then
            If RadioButton1.Checked = True Then
                If txtruc.Text.Trim.Length = 8 Then
                    ActualizarRutaDestino(SelDocumento)
                Else
                    MessageBox.Show("Debe ingresar un dni con 8 dígitos", "Verificar DNI", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                If textPersona.Text.Trim.Length > 0 Then
                    ActualizarRutaDestino(SelDocumento)
                Else
                    MessageBox.Show("Debe identificar a la persona consignada la encomienda", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        End If
    End Sub

    Private Sub ActualizarRutaDestino(intIdDocumento As Integer)
        Dim personaID As Integer?

        If RadioButton1.Checked = True Then ' Con identificacion
            personaID = Integer.Parse(textPersona.Tag)
        ElseIf RadioButton2.Checked = True Then
            personaID = Nothing
        End If

        Dim rutaEncomiendaSA As New DocumentoventaTransporteSA
        Dim obj As New documentoventaTransporte With
        {
        .idDocumento = intIdDocumento,
        .agenciaDestino_id = ComboAgenciaDestino.SelectedValue,
        .ciudadDestino = ComboAgenciaDestino.Text,
        .idPersona = personaID,
        .comprador = textPersona.Text
        }

        rutaEncomiendaSA.ActualizarRutaDestino(obj)
        MessageBox.Show("Agencia de destino modificada!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Tag = obj
        Close()
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked Then
            textPersona.Enabled = False
            textPersona.ReadOnly = True
            textPersona.Clear()
            txtruc.Clear()
            txtruc.Visible = True
            txtruc.Enabled = True
            txtruc.ReadOnly = False
            txtruc.Select()
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked Then
            txtruc.Visible = False

            textPersona.Enabled = True
            textPersona.ReadOnly = False
            textPersona.Clear()
            textPersona.Select()
        End If
    End Sub

    Private Function GetConsultarDNIReniec(Dni As String) As String
        Dim CLIENTE As New WebClient
        Dim PAGINA As Stream = CLIENTE.OpenRead("http://aplicaciones007.jne.gob.pe/srop_publico/Consulta/Afiliado/GetNombresCiudadano?DNI=" & Dni)
        Dim LECTOR As New StreamReader(PAGINA)
        Dim MIHTML As String = LECTOR.ReadToEnd
        ' Dim array = MIHTML.Split("|")

        Dim nombres = MIHTML.Replace("|", Space(1))
        Return nombres
    End Function

    Private Sub txtruc_KeyDown(sender As Object, e As KeyEventArgs) Handles txtruc.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
                If RadioButton1.Checked Then

                    If My.Computer.Network.IsAvailable = True Then
                        If txtruc.Text.Trim.Length = 8 Then
                            Dim nombres = GetConsultarDNIReniec(txtruc.Text.Trim)

                            If nombres.Trim.Length > 0 Then
                                textPersona.Text = nombres
                                Dim personaSel = PersonaSA.ObtenerPersonaNumDoc(Gempresas.IdEmpresaRuc, txtruc.Text.Trim)

                                If personaSel Is Nothing Then
                                    'textPersona.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    ' GrabarEntidadRapida()
                                    GrabarPersonaRapida()
                                    PictureLoad.Visible = False
                                Else
                                    textPersona.Text = personaSel.nombreCompleto
                                    'textPersona.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                                    textPersona.Tag = personaSel.codigo
                                End If
                            Else
                                txtruc.Clear()
                                textPersona.Text = String.Empty
                            End If
                        Else
                            txtruc.Clear()
                            textPersona.Clear()
                            MessageBox.Show("El DNI debe ser de 8 digitos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            PictureLoad.Visible = False
                            Exit Sub
                        End If

                    Else

                        'NO HAY CONEXION A INTERNET
                        Dim existeEnDB = PersonaSA.ObtenerPersonaNumDoc(Gempresas.IdEmpresaRuc, txtruc.Text.Trim)
                        If existeEnDB Is Nothing Then
                            CrearPersonaFormRapido()
                            'TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                            'GrabarEntidadRapida()
                            'PictureLoad.Visible = False
                        Else
                            txtruc.Text = existeEnDB.idPersona
                            textPersona.Text = existeEnDB.nombreCompleto
                            textPersona.Tag = existeEnDB.codigo
                            '   textPersona.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        End If
                    End If

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CrearPersonaFormRapido()
        Dim f As New FormCrearPersonaPasajero
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        If f.Tag IsNot Nothing Then
            Dim per = CType(f.Tag, Persona)
            txtruc.Text = per.idPersona
            textPersona.Text = per.nombreCompleto
            textPersona.Tag = per.codigo
        Else
            txtruc.Text = String.Empty
            textPersona.Text = String.Empty
            textPersona.Tag = Nothing
        End If
    End Sub

    Private Sub GrabarPersonaRapida()
        Dim personaSA As New PersonaSA
        Dim obj As New Persona
        obj.idEntidad = 0 ' entidadSel.idEntidad
        obj.idPersona = txtruc.Text.Trim
        obj.idEmpresa = Gempresas.IdEmpresaRuc
        obj.idOrganizacion = GEstableciento.IdEstablecimiento
        'obj.fechaNac = Date.Now
        obj.tipoPersona = "N"
        obj.tipodoc = "1"
        obj.nombreCompleto = textPersona.Text
        obj.appat = "-"
        obj.apmat = "-"
        obj.nombres = "-"
        obj.nivel = "1"
        obj.edad = 0
        obj.usuarioActualizacion = usuario.IDUsuario
        obj.fechaActualizacion = Date.Now
        Dim per = personaSA.InsertPersona(obj)
        textPersona.Tag = per.codigo
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        CrearPersonaFormRapido()
    End Sub

    Private Sub txtruc_TextChanged(sender As Object, e As EventArgs) Handles txtruc.TextChanged

    End Sub
#End Region

End Class