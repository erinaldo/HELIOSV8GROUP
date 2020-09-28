Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Public Class frmCerrarCajaUsuario
    Inherits frmMaster

    Public dniPerCaja As Integer
    Public idPersona As Integer
    Dim cajausuario As New List(Of cajaUsuario)

    Public Sub New(r As Record)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Inicio(r)
    End Sub

#Region "Métodos"
    Public Sub CerrarCajaUsuario()
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Dim objcajaUsuario As New cajaUsuario
        Dim nDocumento As New documento
        Dim asiento As New asiento
        Dim ListaAsiento As New List(Of asiento)
        Try
            With objcajaUsuario
                .idcajaUsuario = CInt(txtUsuariocaja.Tag)
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
                        '.ConsultaReporte(txtUsuariocaja.Tag, idPersona, txtUsuariocaja.Text, dniPerCaja, txtfecApertura.Text)
                        '.ConsultaReporte(cajaUsuario, txtUsuariocaja.Text, dniPerCaja)
                        .ConsultaReporte(cajausuario, txtUsuariocaja.Text, dniPerCaja, CDec(txtFondoInicioMN.Text), CDec(txtVentas.Text), CDec(txtSaldoMN.Text), 0)
                        .ShowDialog()
                        Dispose()
                    End With
                End If
            Else
                Dispose()
            End If

        Catch ex As Exception
            Tag = Nothing
            'lblEstado.Text = ex.Message
            'lblEstado.Image = My.Resources.warning2
        End Try
    End Sub

    Public Sub Inicio(r As Record)
        Dim cajausuariosa As New cajaUsuarioSA
        Dim FondoInicioMN As Decimal
        Dim FondoInicioME As Decimal
        Dim Ventas As Decimal
        Dim VentasME As Decimal
        Dim SaldoMN As Decimal
        Dim SaldoME As Decimal
        'Dim cajausuario As New List(Of cajaUsuario)

        'Me.dgvEntidadFinanciera.Table.CurrentRecord.GetValue("idCaja"), Me.dgvEntidadFinanciera.Table.CurrentRecord.GetValue("idPersona")

        cajausuario = cajausuariosa.usp_ResumenTransaccionesXusuarioCajaXCierre(New cajaUsuario With {.idcajaUsuario = r.GetValue("idCaja"), .idPersona = r.GetValue("idPersona"), .fechaRegistro = r.GetValue("fechaRegistro")})


        For Each i In cajausuario
            Select Case i.moneda
                Case 1
                    FondoInicioMN += i.fondoMN
                    Ventas += i.ingresoAdicMN
                    SaldoMN += i.Saldo
                Case 2
                    FondoInicioME += i.fondoME
                    VentasME += i.ingresoAdicME
                    SaldoME += i.SaldoME
            End Select
        Next

        'If cajausuario.Count > 0 Then
        '    txtFondoInicioMN.DecimalValue = cajausuario.Sum(Function(o) o.fondoMN)
        '    txtFondoInicioME.DecimalValue = cajausuario.Sum(Function(o) o.fondoME)

        '    txtVentas.DecimalValue = cajausuario.Sum(Function(o) o.ingresoAdicMN)
        '    txtVentasME.DecimalValue = cajausuario.Sum(Function(o) o.ingresoAdicME)

        '    txtSaldoMN.DecimalValue = txtFondoInicioMN.DecimalValue + txtVentas.DecimalValue
        '    txtSaldoME.DecimalValue = txtFondoInicioME.DecimalValue + txtVentasME.DecimalValue
        'Else
        '    txtFondoInicioMN.DecimalValue = 0
        '    txtFondoInicioME.DecimalValue = 0

        '    txtVentas.DecimalValue = 0
        '    txtVentasME.DecimalValue = 0

        '    txtSaldoMN.DecimalValue = 0
        '    txtSaldoME.DecimalValue = 0
        'End If


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


    End Sub

#End Region

    Private Sub frmCerrarCajaUsuario_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmCerrarCajaUsuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtfecCierre.Value = New DateTime(AnioGeneral, MesGeneral, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0)
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles btGrabar.Click
        CerrarCajaUsuario()
    End Sub
End Class