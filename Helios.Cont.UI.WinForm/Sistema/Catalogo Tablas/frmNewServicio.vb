Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class frmNewServicio

    Public Property EstadoManipulacion() As String

    Public Sub New(strTipo As String)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Select Case strTipo
            Case "SERVICIOS"
                CUENTAS()
                cboCuenta.SelectedValue = 7041
                txtCodigoCuenta.Text = 7041
                'Case "TERMINADOS"
                '    cboCuenta.SelectedValue = 70211
                'Case "SUBPRODUCTOS"
                '    cboCuenta.SelectedValue = 70311
        End Select


    End Sub



#Region "Metodos"

    Private Sub CUENTAS()
        Dim asientoSA As New cuentaplanContableEmpresaSA
        Dim DT As New DataTable("Table1")
        DT.Columns.Add("cuenta")
        DT.Columns.Add("descripcion")

        For Each i In asientoSA.LoadCuentasServicios(Gempresas.IdEmpresaRuc)
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
    End Sub


    Public Sub InsertServicio()

        Dim obj As New servicioSA
        Dim item As New servicio

        'Dim datos As List(Of item) = item.Instance()
        'datos.Clear()
        'Dim c As New item

        Try
            With item
                .idPadre = CInt(1015)
                .descripcion = txtDescripcion.Text
                .cuenta = txtCodigoCuenta.Text
            End With

            Dim codx As Integer = obj.GrabarNewServicio(item)

            'c.idItem = codx
            'c.descripcion = txtDescripcion.Text
            'datos.Add(c)

            Dispose()

        Catch ex As Exception
            MsgBox("No se pudo grabar la marca." & vbCrLf & ex.Message)
        End Try

    End Sub



    Public Sub UpdateServicio()

        Dim obj As New servicioSA
        Dim item As New servicio

        'Dim datos As List(Of item) = item.Instance()
        'datos.Clear()
        'Dim c As New item

        Try
            With item
                .idServicio = lblidservicio.Text
                .descripcion = txtDescripcion.Text

            End With

            obj.UpdateServicio(item)

            'c.idItem = codx
            'c.descripcion = txtDescripcion.Text
            'datos.Add(c)

            Dispose()

        Catch ex As Exception
            MsgBox("No se pudo grabar la marca." & vbCrLf & ex.Message)
        End Try

    End Sub
#End Region

    Private Sub frmNewServicio_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtDescripcion.Text.Trim.Length > 0 Then

            If EstadoManipulacion = ENTITY_ACTIONS.UPDATE Then
                UpdateServicio()
            Else
                InsertServicio()
            End If
        Else
            MessageBox.Show("Escriba una Descripcion")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dispose()
    End Sub

    Private Sub txtDescripcion_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub cboCuenta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCuenta.SelectedIndexChanged
        Dim value As Object = cboCuenta.SelectedValue

        If (TypeOf value Is String) Then
            ' Lo pasamos a la función únicamente si es
            ' del tipo Integer.
            '
            txtCodigoCuenta.Text = cboCuenta.SelectedValue
        End If
    End Sub
End Class