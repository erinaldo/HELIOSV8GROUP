Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid

Public Class frmConfirmarPrestamoOtor

    Public Property TipoPrestamoAprobado() As String




#Region "metodos"

    Public Sub UbicarPrestamo(intCodigo As Integer)
        Dim prestamosSA As New prestamosSA
        Dim prestamos As New prestamos
        Dim entidadSA As New entidadSA
        Dim personaSA As New PersonaSA

        prestamos = prestamosSA.UbicarPrestamoXcodigo(intCodigo)
        If Not IsNothing(prestamos) Then
            lblIdDocumento.Text = prestamos.codigo
            txtNumero.Text = prestamos.nroDoc
            txtFechaComprobante.Value = prestamos.fechaPrestamo
            txtMoneda.ValueMember = prestamos.moneda
            txtMoneda.Text = IIf(prestamos.moneda = "1", "NAC", "EXT")
            txtTipoBeneficiario.Text = prestamos.tipoBeneficiario
            txtTipoBeneficiario.Tag = prestamos.idBeneficiario


            Select Case prestamos.tipoBeneficiario
                Case TIPO_ENTIDAD.PROVEEDOR
                    With entidadSA.UbicarEntidadPorID(prestamos.idBeneficiario).First
                        txtBeneficiario.Text = .nombreCompleto
                    End With
                Case TIPO_ENTIDAD.CLIENTE
                    With entidadSA.UbicarEntidadPorID(prestamos.idBeneficiario).First
                        txtBeneficiario.Text = .nombreCompleto
                    End With
                Case "TR"
                    With personaSA.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, prestamos.idBeneficiario, "TR")
                        txtBeneficiario.Text = .nombreCompleto
                    End With
                Case "OT"
                    With personaSA.ObtenerPersonaNumDocPorNivel(Gempresas.IdEmpresaRuc, prestamos.idBeneficiario, "OT")
                        txtBeneficiario.Text = .nombreCompleto
                    End With
            End Select
            txtTipoCambio.Value = prestamos.tipoCambio
            nudImporteMN.Value = prestamos.monto
            nudImporteME.Value = prestamos.montoUSD
            
            'DateTimePicker1.Value = prestamos.fechaDesembolso
           

            Dim cuota As Decimal = prestamos.numCuotas

            txtCuotas.Value = CDec(cuota)

            

            cboModo.Text = prestamos.modoPago


           


            If cboModo.Text = "MENSUAL" Then

                Label24.Visible = True
                cboDiaPago.Visible = True

            ElseIf cboModo.Text = "QUINCENAL" Then

                Label24.Visible = False
                cboDiaPago.Visible = False

            ElseIf cboModo.Text = "SEMANAL" Then

                Label24.Visible = False
                cboDiaPago.Visible = False

            ElseIf cboModo.Text = "DIARIO" Then

                Label24.Visible = False
                cboDiaPago.Visible = False

            End If


            cboDiaPago.Text = prestamos.diaPago
            DateTimePickerAdv2.Value = prestamos.fechaInicio

            cbodiaplazo.Text = prestamos.plazoDias

            'cargarcuotas()

        End If
    End Sub
#End Region

    Private Sub frmConfirmarPrestamoOtor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub GuardarToolStripButton_Click(sender As Object, e As EventArgs) Handles GuardarToolStripButton.Click

    End Sub
End Class