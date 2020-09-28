Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Microsoft


Public Class FrmNuevaPersona
    Inherits frmMaster

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        LoadCombo()
        CBOCuentas()
    End Sub


#Region "metodos"

    Sub LoadCombo()
        Dim tablaDetalleSA As New tablaDetalleSA

        cboTipoDoc.DisplayMember = "descripcion"
        cboTipoDoc.ValueMember = "codigoDetalle"
        cboTipoDoc.DataSource = tablaDetalleSA.GetListaTablaDetalle(2, "1")
    End Sub

    Public Sub GrabarPersona()
        Dim personsa As New Persona
        Dim personaSA As New PersonaSA

        personsa = New Persona
        personsa.idPersona = txtdni.Text
        personsa.idEmpresa = Gempresas.IdEmpresaRuc
        personsa.tipodoc = cboTipoDoc.SelectedValue
        If ComboBoxAdv1.Text = "NATURAL" Then
            personsa.tipoPersona = "N"
            personsa.appat = txtpaterno.Text
            personsa.apmat = txtmaterno.Text
            personsa.nombres = txtnombres.Text
            personsa.nombreCompleto = txtpaterno.Text & " " & txtmaterno.Text & ", " & txtnombres.Text
        Else
            personsa.tipoPersona = "J"
            personsa.appat = String.Empty
            personsa.apmat = String.Empty
            personsa.nombres = String.Empty
            personsa.nombreCompleto = txtRazon.Text.Trim
        End If

        personsa.cuentaContable = cboCuenta.SelectedValue
        personsa.nivel = "TR"
        personsa.usuarioActualizacion = usuario.IDUsuario
        personsa.fechaActualizacion = Date.Now

        personaSA.InsertPersona(personsa)

        Tag = personsa

        Close()

    End Sub

    Sub CBOCuentas()
        Dim asientoSA As New cuentaplanContableEmpresaSA
        Dim DT As New DataTable("Table1")
        DT.Columns.Add("cuenta")
        DT.Columns.Add("descripcion")

        For Each i In asientoSA.ListarCuentasPorPadre(Gempresas.IdEmpresaRuc, "50")
            Dim dr As DataRow = DT.NewRow
            dr(0) = i.cuenta
            dr(1) = i.descripcion
            DT.Rows.Add(dr)
        Next

        Dim view As DataView = New DataView(DT)

        ' DATASOURCE is DATAVIEW

        Me.cboCuenta.DataSource = view

        Me.cboCuenta.DisplayMember = "descripcion"

        Me.cboCuenta.ValueMember = "cuenta"

        'cboCuenta.SelectedIndex = -1
    End Sub
#End Region


    Private Sub FrmNuevaPersona_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub FrmNuevaPersona_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs)
        Dispose()
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        Try
            If ComboBoxAdv1.Text = "NATURAL" Then
                If txtdni.Text.Trim.Length > 0 Then
                Else
                    MessageBox.Show("Escriba un DNI", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                If Not txtdni.Text.Trim.Length = 8 Then
                    MessageBox.Show("Ingrese formato correcto para DNI.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtdni.Focus()
                    txtdni.SelectAll()
                    Exit Sub
                End If

                If txtpaterno.Text.Trim.Length > 0 Then
                Else
                    MessageBox.Show("Escriba un apellido paterno")
                    Exit Sub
                End If
                If txtmaterno.Text.Trim.Length > 0 Then
                Else
                    MessageBox.Show("Escriba un apellido materno", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If



            Else 'PERSONA JURIDICA

                If txtdni.Text.Trim.Length > 0 Then
                Else
                    MessageBox.Show("Escriba un número documento", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If


                If txtRazon.Text.Trim.Length > 0 Then
                Else
                    MessageBox.Show("Escriba una razón social valida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

            End If
            GrabarPersona()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub ComboBoxAdv1_Click(sender As Object, e As EventArgs) Handles ComboBoxAdv1.Click

    End Sub

    Private Sub ComboBoxAdv1_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxAdv1.SelectedValueChanged
        If ComboBoxAdv1.Text = "NATURAL" Then
            txtpaterno.Visible = True
            txtmaterno.Visible = True
            txtnombres.Visible = True
            txtRazon.Visible = False
        Else

            txtpaterno.Visible = False
            txtmaterno.Visible = False
            txtnombres.Visible = False
            txtRazon.Visible = True
        End If
    End Sub

    Private Sub cboTipoDoc_Click(sender As Object, e As EventArgs) Handles cboTipoDoc.Click

    End Sub
End Class