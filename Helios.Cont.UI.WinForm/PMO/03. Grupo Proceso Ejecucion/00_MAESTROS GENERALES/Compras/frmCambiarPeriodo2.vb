Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Public Class frmCambiarPeriodo2
    Inherits frmMaster
    Public Property operacion As String
    Public Sub New(be As documentocompra)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UbicarCompra(be)
    End Sub

    Public Sub New(be As documentoventaAbarrotes)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UbicarVenta(be)
    End Sub

    Public Sub New(be As documentoLibroDiario)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UbicarLibroDiario(be)
    End Sub

    Public Sub New(be As documentoCaja)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        UbicarDocumentoCaja(be)
    End Sub


#Region "Mètodos"

    Public Sub UbicarDocumentoCaja(be As documentoCaja)
        Dim compra As New documentoCaja
        Dim compraSA As New DocumentoCajaSA

        compra = compraSA.GetUbicar_documentoCajaID(be.idDocumento)

        If Not IsNothing(compra) Then
            txtNumero.Tag = compra.idDocumento
            txtNumero.Text = compra.numeroDoc
            txtFecha.Text = compra.fechaProceso
            txtPeriodo.Text = compra.periodo

        Else
            MessageBox.Show("El comprobante no existe")
        End If

    End Sub



    Public Sub UbicarCompra(be As documentocompra)
        Dim compra As New documentocompra
        Dim compraSA As New DocumentoCompraSA

        compra = compraSA.UbicarDocumentoCompra(be.idDocumento)

        If Not IsNothing(compra) Then
            txtNumero.Tag = compra.idDocumento
            txtNumero.Text = compra.serie & "-" & compra.numeroDoc
            txtFecha.Text = compra.fechaDoc
            txtPeriodo.Text = compra.fechaContable

        Else
            MessageBox.Show("El comprobante no existe")
        End If

    End Sub


    Public Sub UbicarVenta(be As documentoventaAbarrotes)
        Dim compra As New documentoventaAbarrotes
        Dim compraSA As New documentoVentaAbarrotesSA

        compra = compraSA.GetUbicar_documentoventaAbarrotesPorID(be.idDocumento)

        If Not IsNothing(compra) Then
            txtNumero.Tag = compra.idDocumento
            txtNumero.Text = compra.serie & "-" & compra.numeroDoc
            txtFecha.Text = compra.fechaDoc
            txtPeriodo.Text = compra.fechaPeriodo

        Else
            MessageBox.Show("El comprobante no existe")
        End If

    End Sub

    Public Sub UbicarLibroDiario(be As documentoLibroDiario)
        Dim compra As New documentoLibroDiario
        Dim compraSA As New documentoLibroDiarioSA

        compra = compraSA.UbicarDocumentoLibroDiario(be.idDocumento)

        If Not IsNothing(compra) Then
            txtNumero.Tag = compra.idDocumento
            txtNumero.Text = compra.nroDoc
            txtFecha.Text = compra.fecha
            txtPeriodo.Text = compra.fechaPeriodo

        Else
            MessageBox.Show("El comprobante no existe")
        End If

    End Sub



    Private Sub CambiarPeriodoCaja()
        Dim caja As New documentoCaja
        Dim compraSA As New DocumentoCajaSA

        caja.idDocumento = txtNumero.Tag
        caja.periodo = txtNuevoPeriodoMes.Text & "/" & txtNuevoPeriodoAnio.Text

        compraSA.CambiarPeriodoCaja(caja)
        MessageBox.Show("Período cambiado con éxito", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Close()
    End Sub


    Private Sub CambiarPeriodo()
        Dim compra As New documentocompra
        Dim compraSA As New DocumentoCompraSA

        compra.idDocumento = txtNumero.Tag
        compra.fechaContable = txtNuevoPeriodoMes.Text & "/" & txtNuevoPeriodoAnio.Text

        compraSA.CambiarPeriodoCompra(compra)
        MessageBox.Show("Período cambiado con éxito", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Close()
    End Sub

    Private Sub CambiarPeriodoVenta()
        Dim compra As New documentoventaAbarrotes
        Dim compraSA As New documentoVentaAbarrotesSA

        compra.idDocumento = txtNumero.Tag
        compra.fechaPeriodo = txtNuevoPeriodoMes.Text & "/" & txtNuevoPeriodoAnio.Text

        compraSA.CambiarPeriodoVenta(compra)
        MessageBox.Show("Período cambiado con éxito", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Close()
    End Sub

    Private Sub CambiarPeriodoLibroDiario()
        Dim compra As New documentoLibroDiario
        Dim compraSA As New documentoLibroDiarioSA

        compra.idDocumento = txtNumero.Tag
        compra.fechaPeriodo = txtNuevoPeriodoMes.Text & "/" & txtNuevoPeriodoAnio.Text

        compraSA.CambiarPeriodoLibroDiario(compra)
        MessageBox.Show("Período cambiado con éxito", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Close()
    End Sub
#End Region

    Private Sub frmCambiarPeriodo2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtNuevoPeriodoMes.Select()
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        If txtNuevoPeriodoMes.Text.Trim.Length <= 0 Then
            MessageBox.Show("Debe indicar el mes dentro del rango {1:12}", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Val(txtNuevoPeriodoMes.Text) <= 12 Then
            If txtNuevoPeriodoAnio.Text.Trim.Length > 0 Then
                If MessageBox.Show("Desea cambiar el período del comprobante ?" & vbCrLf & txtPeriodo.Text & " --> " & txtNuevoPeriodoMes.Text & "/" & txtNuevoPeriodoAnio.Text,
                                   "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                    Select Case operacion
                        Case StatusTipoOperacion.COMPRA
                            CambiarPeriodo()

                        Case StatusTipoOperacion.VENTA
                            CambiarPeriodoVenta()

                        Case StatusTipoOperacion.INGRESO_CUENTAS_MANUALES
                            CambiarPeriodoLibroDiario()
                        Case StatusTipoOperacion.OTRAS_ENTRADAS_DE_DINERO
                            CambiarPeriodoCaja()
                        Case StatusTipoOperacion.OTRAS_SALIDAS_DE_DINERO
                            CambiarPeriodoCaja()

                        Case Else
                            CambiarPeriodoCaja()
                    End Select


                End If
            Else
                MessageBox.Show("Debe indicar el período a cambiar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Debe indicar el mes dentro del rango {1:12}", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If


    End Sub

    Private Sub txtNuevoPeriodoMes_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles txtNuevoPeriodoMes.MaskInputRejected

    End Sub

    Private Sub txtNuevoPeriodoMes_TextChanged(sender As Object, e As EventArgs) Handles txtNuevoPeriodoMes.TextChanged
        If txtNuevoPeriodoMes.Text.Trim.Length = 2 Then
            txtNuevoPeriodoAnio.Select()
        End If
    End Sub
End Class