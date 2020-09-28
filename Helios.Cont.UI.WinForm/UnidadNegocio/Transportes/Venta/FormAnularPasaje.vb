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
Imports System.Net.NetworkInformation

Public Class FormAnularPasaje


    Dim documentoventaTrasnporteBE As New documentoventaTransporte
    Public Property IdProg As Integer
    Public Property AsientoNro As Integer

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        lblAsiento.Select(0, lblAsiento.Text.Length)
    End Sub


    Public Sub EnviarAnulacionDocumento(objeto As documentoventaTransporte)
        Try
            Dim documentoventasa As New DocumentoventaTransporteSA

            Dim objetoBaja As New Helios.Fact.Sunat.Business.Entity.RecepcionComunicacionBaja

            objetoBaja.IdDocumento = objeto.serie & "-" & String.Format("{0:00000000}", CInt(objeto.numero))
            objetoBaja.TipoDocumento = objeto.tipoDocumento
            objetoBaja.idEmpresa = Gempresas.ubigeo
            objetoBaja.FechaEmision = objeto.fechadoc
            objetoBaja.EnvioSunat = "NO"
            objetoBaja.estadoEnvio = "PE"
            objetoBaja.Contribuyente_id = Gempresas.IdEmpresaRuc

            Dim codigo = Helios.Fact.Sunat.WCFService.ServiceAccess.Admin.RecepcionComunicacionBajaSA.RecepcionComunicacionBajaSave(objetoBaja, Nothing)

            If codigo.idAnulacion > 0 Then
                'ActualizarEnvioSunat("0", objeto)
                documentoventasa.UpdateAnulacionEnviada(objeto.idDocumento, codigo.idAnulacion, 0)

                MessageBox.Show("La comunicacion se Envio Correctamente al PSE")
            End If

        Catch ex As Exception

        End Try
    End Sub

    'Public Sub EnviarAnulacionDocumento(objeto As documentoventaAbarrotes)
    '    Try
    '        Dim documentoventasa As New documentoVentaAbarrotesSA

    '        Dim objetoBaja As New Helios.Fact.Sunat.Business.Entity.RecepcionComunicacionBaja

    '        objetoBaja.IdDocumento = objeto.serieVenta & "-" & String.Format("{0:00000000}", CInt(objeto.numeroVenta))
    '        objetoBaja.TipoDocumento = objeto.tipoDocumento
    '        objetoBaja.idEmpresa = Gempresas.ubigeo
    '        objetoBaja.FechaEmision = objeto.fechaDoc
    '        objetoBaja.EnvioSunat = "NO"
    '        objetoBaja.estadoEnvio = "PE"
    '        objetoBaja.Contribuyente_id = Gempresas.IdEmpresaRuc

    '        Dim codigo = Helios.Fact.Sunat.WCFService.ServiceAccess.Admin.RecepcionComunicacionBajaSA.RecepcionComunicacionBajaSave(objetoBaja, Nothing)

    '        If codigo.idAnulacion > 0 Then
    '            'ActualizarEnvioSunat("0", objeto)
    '            documentoventasa.UpdateAnulacionEnviada(objeto.idDocumento, codigo.idAnulacion, 0)

    '            MessageBox.Show("La comunicacion se Envio Correctamente al PSE")
    '        End If

    '    Catch ex As Exception

    '    End Try
    'End Sub

    Public Sub EliminarPV(intIdDocumento As Integer)
        Dim documentoSA As New documentoVentaAbarrotesSA
        Dim objDocumento As New documento
        Dim ventaSA As New DocumentoventaTransporteSA
        ' Try
        With objDocumento
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .idDocumento = intIdDocumento
        End With

        ventaSA.EliminarVentaEncomienda(New Business.Entity.documento With {.idDocumento = intIdDocumento,
                                            .idPse = Gempresas.ubigeo})

        'documentoSA.EliminarVenta(objDocumento)
        ''documentoSA.EliminarVentaGeneralPV(objDocumento)
        ''dgPedidos.Table.CurrentRecord.Delete()
        'MessageBox.Show("venta anulada!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'lblEstado.Text = "Pedido eliminado!"
        'PanelError.Visible = True
        'Timer1.Enabled = True
        'TiempoEjecutar(10)

        'Catch ex As Exception
        'MsgBox(ex.Message)
        ' End Try
    End Sub

    Private Sub buscarAsiento(nroAsiento As Integer, ProgramcionID As Integer)
        Try
            'Dim documentoventaTrasnporteBL As New documentoventaTransporteBL
            Dim documentoventaTrasnporteSA As New DocumentoventaTransporteSA

            documentoventaTrasnporteBE = New documentoventaTransporte
            documentoventaTrasnporteBE = documentoventaTrasnporteSA.GetPasajeroXAsiwentoAnulacion(New Business.Entity.documentoventaTransporte With {.idDistribucion = nroAsiento,
                                            .programacion_id = ProgramcionID})


            If (Not IsNothing(documentoventaTrasnporteBE)) Then
                txtNombrePasajero.Tag = documentoventaTrasnporteBE.idDocumento
                txtNombrePasajero.Text = documentoventaTrasnporteBE.comprador
                txtEdad.Value = documentoventaTrasnporteBE.edad
                txtImporte.Value = documentoventaTrasnporteBE.total
                txtOrigen.Text = documentoventaTrasnporteBE.ciudadOrigen
                txtDestino.Text = documentoventaTrasnporteBE.ciudadDestino
                btnAsiento.Text = documentoventaTrasnporteBE.numeroAsiento
                btnAsiento.Tag = documentoventaTrasnporteBE.idDistribucion
                txtOrigen.Tag = documentoventaTrasnporteBE.programacion_id
            Else
                MessageBox.Show("Verificar asiento")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    'Public Function EstadoRed(ByVal mURL As String) As Boolean

    '    Try

    '        If My.Computer.Network.IsAvailable() Then
    '            If My.Computer.Network.Ping(mURL, 5000) Then 'Asignamos la pagina a consultar ejemplo www.google.cl y el tiempo de espera máximo
    '                EstadoRed = True
    '            Else
    '                EstadoRed = False
    '            End If
    '        Else
    '            EstadoRed = False
    '        End If

    '    Catch ex As Exception
    '        EstadoRed = False
    '    End Try

    'End Function

    Public Function EstadoRed(ByVal mURL As String) As Boolean

        Try
            Dim conteo As Integer = 0
            Dim ip As IPAddress = IPAddress.Parse(mURL)
            If My.Computer.Network.IsAvailable() Then

                Dim ping As Ping = New Ping()

                For i As Integer = 0 To 2 - 1
                    Dim pr As PingReply = ping.Send(ip)

                    If (pr.Status.ToString() = "Success") Then
                        conteo = conteo + 1

                    End If
                Next
                If (conteo = 0) Then
                    EstadoRed = False
                ElseIf (conteo >= 1) Then
                    EstadoRed = True
                End If

            Else
                EstadoRed = False
            End If

        Catch ex As Exception
            EstadoRed = False
        End Try

    End Function


    Private Sub FormAnularPasaje_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblAsiento.Select(0, lblAsiento.Text.Length)
    End Sub

    Private Sub LblAsiento_Click(sender As Object, e As EventArgs) Handles lblAsiento.Click
        lblAsiento.Select(0, lblAsiento.Text.Length)
    End Sub

    Private Sub lblAsiento_KeyDown(sender As Object, e As KeyEventArgs) Handles lblAsiento.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True

                buscarAsiento(lblAsiento.Value, IdProg)

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            lblAsiento.Value = 0.0
            lblAsiento.Focus()
            lblAsiento.Select()

        End Try
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Try
            Dim distribucionInfraestructuraSA As New VehiculoAsiento_PreciosSA
            Dim distribucionInfraestructuraBE As New vehiculoAsiento_Precios
            Dim documentoventaSA As New VehiculoAsiento_PreciosSA
            If MessageBox.Show("¿Desea Anular el pasaje?", "ANULAR PASAJE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then

                If EstadoRed("138.128.171.106") = True Then


                    Dim DOCUMENTOVENTABE As New documentoventaTransporteDetalle
                    DOCUMENTOVENTABE.idDistribucion = btnAsiento.Tag

                    Dim documentoTransportesa As New DocumentoventaTransporteSA
                    Dim IDDOCTRANSPORTE As Integer
                    Dim ENVIOSUNAT As String
                    Dim documentoTransporte As New documentoventaTransporte
                    documentoTransporte = documentoTransportesa.GetTransporteDocXIDAnulacion(DOCUMENTOVENTABE)

                    Dim f As New FormAnularVenta(CDate(documentoTransporte.fechadoc))
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog(Me)
                    If f.Tag IsNot Nothing Then
                        Dim c = CType(f.Tag, Boolean)
                        If c = True Then 'fecha dentro del rango permitido

                            Dim objeto As New documentoventaTransporte
                            objeto.idDocumento = CInt(documentoTransporte.idDocumento)
                            objeto.tipoDocumento = documentoTransporte.tipoDocumento
                            objeto.serie = documentoTransporte.serie
                            objeto.numero = CInt(documentoTransporte.numero)
                            objeto.fechadoc = CDate(documentoTransporte.fechadoc)
                            IDDOCTRANSPORTE = CInt(documentoTransporte.idDocumento)
                            ENVIOSUNAT = (documentoTransporte.EnvioSunat)

                            Try
                                If Gempresas.ubigeo > 0 Then
                                    'If My.Computer.Network.IsAvailable = True Then
                                    If My.Computer.Network.Ping("138.128.171.106") Then

                                        Try
                                            EliminarPV(Val(IDDOCTRANSPORTE))

                                            MessageBox.Show("Documento anulado con exito!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)

                                            Dim envio = ENVIOSUNAT
                                            If (Not IsNothing(envio)) Then
                                                If envio.ToString.Trim.Length > 0 Then
                                                    EnviarAnulacionDocumento(objeto)
                                                End If
                                            End If

                                            distribucionInfraestructuraBE = New vehiculoAsiento_Precios
                                            distribucionInfraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
                                            distribucionInfraestructuraBE.precio_id = btnAsiento.Tag
                                            distribucionInfraestructuraBE.estado = "A"
                                            distribucionInfraestructuraBE.sexo = ""
                                            distribucionInfraestructuraBE.programacion_id = IdProg
                                            documentoventaSA.updateAsientoPrecioXaNULACIONID(distribucionInfraestructuraBE)
                                            Dispose()

                                        Catch ex As Exception
                                            MsgBox(ex.Message)
                                            'MessageBox.Show("No se pudo eliminar el periodo esta cerrado", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        End Try

                                    Else
                                        MessageBox.Show("No tiene conexión con el servidor SPK!", "Verificar conexión a internet", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    End If
                                    'Else
                                    '    MessageBox.Show("No tiene conexión a internet!", "Verificar conexión a internet", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    'End If
                                Else


                                    EliminarPV(Val(IDDOCTRANSPORTE))

                                    distribucionInfraestructuraBE = New vehiculoAsiento_Precios
                                    distribucionInfraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
                                    distribucionInfraestructuraBE.precio_id = btnAsiento.Tag
                                    distribucionInfraestructuraBE.estado = "A"
                                    distribucionInfraestructuraBE.programacion_id = IdProg

                                    documentoventaSA.updateAsientoPrecioXaNULACIONID(distribucionInfraestructuraBE)
                                    Dispose()

                                End If

                            Catch ex As Exception
                                MessageBox.Show(ex.Message)
                            End Try
                        Else
                            MessageBox.Show("No puede anular la venta, debe estar dentro del rango de 5 días hábiles!", "Validar fechas", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If

                Else

                    Dim DOCUMENTOVENTABE As New documentoventaTransporteDetalle
                    DOCUMENTOVENTABE.idDistribucion = btnAsiento.Tag

                    Dim documentoTransportesa As New DocumentoventaTransporteSA
                    Dim IDDOCTRANSPORTE As Integer
                    Dim ENVIOSUNAT As String
                    Dim documentoTransporte As New documentoventaTransporte
                    documentoTransporte = documentoTransportesa.GetTransporteDocXIDAnulacion(DOCUMENTOVENTABE)

                    Dim objeto As New documentoventaAbarrotes
                    objeto.idDocumento = CInt(documentoTransporte.idDocumento)
                    objeto.tipoDocumento = documentoTransporte.tipoDocumento
                    objeto.serieVenta = documentoTransporte.serie
                    objeto.numeroVenta = CInt(documentoTransporte.numero)
                    objeto.fechaDoc = CDate(documentoTransporte.fechadoc)
                    IDDOCTRANSPORTE = CInt(documentoTransporte.idDocumento)
                    ENVIOSUNAT = (documentoTransporte.EnvioSunat)

                    EliminarPV(Val(IDDOCTRANSPORTE))

                    distribucionInfraestructuraBE = New vehiculoAsiento_Precios
                    distribucionInfraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
                    distribucionInfraestructuraBE.precio_id = btnAsiento.Tag
                    distribucionInfraestructuraBE.estado = "A"
                    distribucionInfraestructuraBE.programacion_id = IdProg

                    documentoventaSA.updateAsientoPrecioXaNULACIONID(distribucionInfraestructuraBE)
                    Dispose()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        buscarAsiento(lblAsiento.Value, IdProg)
    End Sub
End Class