Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Drawing
Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping
Imports System.ComponentModel
Public Class frmCerrarCajaXUsuario

#Region "Attributes"
    Inherits frmMaster
    Dim colorx As New GridMetroColors()
    Dim objCajausuario As New cajaUsuario
    Dim idCajaUser As Integer
    Dim cajausuario As New List(Of cajaUsuario)
    Public Property strEstadoManipulacion() As String

#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGrid(dgvCajasAssig)
        txtfecCierre.Value = Date.Now

    End Sub
#End Region

#Region "Methods"

    Public Sub CerrarCajaUsuario()
        Dim cajaUsuarioSA As New cajaUsuarioSA
        'Dim objcajaUsuario As New cajaUsuario
        Dim nDocumento As New documento
        Dim asiento As New asiento
        Dim ListaAsiento As New List(Of asiento)
        Try
            With objcajaUsuario
                .idcajaUsuario = CInt(objCajausuario.idcajaUsuario)
                .fechaCierre = txtfecCierre.Value
                .enUso = "N"
                .estadoCaja = "C"
                .otrosEgresosMN = 0 ' nudImporteEgresosmn.Value
                .otrosEgresosME = 0 ' nudImporteEgresosme.Value
                .ingresoAdicMN = 0 ' nudIngresoMN.Value
                .ingresoAdicME = 0 'nudIngresoME.Value
                .idCajaCierre = 0 ' txtCajaDestino.ValueMember
            End With

            nDocumento.CustomDocumentoCaja = Nothing
            cajaUsuarioSA.CerrarCajaUsuario(objcajaUsuario, nDocumento)
            Tag = "cerrado"

            If MessageBoxAdv.Show("Desea mostrar reporte de cierre?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                If Not IsNothing(txtUsuariocaja.Text) Then
                    With frmCajaUsuarioCierre
                        '.ConsultaReporte(cajausuario, txtUsuariocaja.Text, txtDni.Text)
                        .ConsultaReporte(cajausuario, txtUsuariocaja.Text, txtDni.Text, CDec(txtFondoInicioMN.Text), CDec(txtVentas.Text), CDec(txtSaldoMN.Text), 0)
                        .ShowDialog()
                        Dispose()
                    End With
                End If
            Else
                Dispose()
            End If

        Catch ex As Exception
            Tag = Nothing
            MessageBoxAdv.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub UbicarCajaUsuario(inrIdPersona As Integer)
        Me.Cursor = Cursors.WaitCursor
        Dim cajausuarioSA As New cajaUsuarioSA
        Dim cajausuarioDetalleSA As New cajaUsuarioDetalleSA
        Dim usuarioSA As New UsuarioSA
        Dim efSA As New EstadosFinancierosSA
        Dim ef As New estadosFinancieros
        Dim usuarioBL As New Usuario
        Dim usuarioDetalleBL As New Usuario

        Try

            With usuarioBL
                .IDUsuario = inrIdPersona
            End With


            usuarioDetalleBL = usuarioSA.UbicarUsuarioXid(usuarioBL)

            If (Not IsNothing(usuarioDetalleBL)) Then
                txtUsuariocaja.Text = usuarioDetalleBL.Nombres & " " & usuarioDetalleBL.ApellidoPaterno & " " & usuarioDetalleBL.ApellidoMaterno
                txtUsuariocaja.Tag = usuarioBL.IDUsuario

                txtDni.Text = usuarioDetalleBL.NroDocumento

                txtfecApertura.Text = usuarioDetalleBL.FechaActualizacion

                Me.dgvCajasAssig.Table.Records.DeleteAll()

                objCajausuario = cajausuarioSA.UbicarUsuarioAbierto(inrIdPersona)

                If (Not IsNothing(objCajausuario)) Then


                    cajausuario = cajausuarioSA.ResumenTransaccionesXusuarioCajaPago(New cajaUsuario With {.idcajaUsuario = objCajausuario.idcajaUsuario, .idPersona = inrIdPersona, .fechaRegistro = objCajausuario.fechaRegistro})

                    Dim dt As New DataTable("Entidades financieras")
                    dt.Columns.Add(New DataColumn("idCajaUsuario", GetType(Integer)))
                    dt.Columns.Add(New DataColumn("idPersona", GetType(Integer)))
                    dt.Columns.Add(New DataColumn("nombreEntidad", GetType(String)))
                    dt.Columns.Add(New DataColumn("tipo", GetType(String)))
                    dt.Columns.Add(New DataColumn("moneda", GetType(String)))
                    dt.Columns.Add(New DataColumn("fondoMN", GetType(Decimal)))
                    dt.Columns.Add(New DataColumn("fondoME", GetType(Decimal)))
                    dt.Columns.Add(New DataColumn("ingresoAdicMN", GetType(Decimal)))
                    dt.Columns.Add(New DataColumn("ingresoAdicME", GetType(Decimal)))
                    dt.Columns.Add(New DataColumn("saldoMN", GetType(Decimal)))
                    dt.Columns.Add(New DataColumn("saldoME", GetType(Decimal)))

                    Dim FondoInicioMN As Decimal
                    Dim FondoInicioME As Decimal
                    Dim Ventas As Decimal
                    Dim VentasME As Decimal
                    Dim SaldoMN As Decimal
                    Dim SaldoME As Decimal

                    For Each i In cajausuario
                        Dim dr As DataRow = dt.NewRow()

                        Select Case i.moneda
                            Case 1
                                dr(0) = i.idcajaUsuario
                                dr(1) = i.idPersona
                                dr(2) = i.NombreEntidad
                                dr(3) = i.Tipo
                                dr(4) = "NACIONAL"
                                dr(5) = i.fondoMN
                                dr(6) = 0
                                dr(7) = i.ingresoAdicMN
                                dr(8) = 0
                                dr(9) = i.Saldo
                                dr(10) = 0
                                dt.Rows.Add(dr)
                                FondoInicioMN += i.fondoMN
                                Ventas += i.ingresoAdicMN
                                SaldoMN += i.Saldo

                            Case 2
                                dr(0) = i.idcajaUsuario
                                dr(1) = i.idPersona
                                dr(2) = i.NombreEntidad
                                dr(3) = i.Tipo
                                dr(4) = "EXTRANJERA"
                                dr(5) = 0
                                dr(6) = i.fondoME
                                dr(7) = 0
                                dr(8) = i.ingresoAdicME
                                dr(9) = 0
                                dr(10) = i.SaldoME
                                dt.Rows.Add(dr)
                                FondoInicioME += i.fondoME
                                VentasME += i.ingresoAdicME
                                SaldoME += i.SaldoME
                        End Select

                    Next
                    dgvCajasAssig.DataSource = dt


                    'cajausuario = cajausuarioSA.ResumenTransaccionesXusuarioCaja(New cajaUsuario With {.idcajaUsuario = objCajausuario.idcajaUsuario, .idPersona = inrIdPersona, .fechaRegistro = objCajausuario.fechaRegistro})

                    If cajausuario.Count > 0 Then
                        txtFondoInicioMN.DecimalValue = FondoInicioMN
                        txtFondoInicioME.DecimalValue = FondoInicioME

                        txtVentas.DecimalValue = Ventas
                        txtVentasME.DecimalValue = VentasME

                        txtSaldoMN.DecimalValue = FondoInicioMN + Ventas
                        txtSaldoME.DecimalValue = FondoInicioME + VentasME
                    Else
                        txtFondoInicioMN.DecimalValue = 0
                        txtFondoInicioME.DecimalValue = 0

                        txtVentas.DecimalValue = 0
                        txtVentasME.DecimalValue = 0

                        txtSaldoMN.DecimalValue = 0
                        txtSaldoME.DecimalValue = 0
                    End If
                End If
                btGrabar.Visible = True
            Else
                btGrabar.Visible = False
                MessageBoxAdv.Show("No tiene cajas asigandas", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

           

            Me.Cursor = Cursors.Arrow
        Catch ex As Exception
            MessageBoxAdv.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region "Events"

    Private Sub btGrabar_Click(sender As Object, e As EventArgs) Handles btGrabar.Click
        Me.Cursor = Cursors.WaitCursor
        CerrarCajaUsuario()
        Me.Cursor = Cursors.Arrow
    End Sub
#End Region
End Class