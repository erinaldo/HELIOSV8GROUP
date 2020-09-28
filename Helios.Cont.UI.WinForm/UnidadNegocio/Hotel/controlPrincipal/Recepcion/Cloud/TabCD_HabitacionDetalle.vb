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
Imports System.Threading
Imports ProcesosGeneralesCajamiSoft
Imports System.Net
Imports System.IO

Public Class TabCD_HabitacionDetalle

    Public Property FormPurchase As TabCT_ControlXCliente
    Public Property IDDocumento As Integer = 0

    Public Sub New(formRepPiscina As TabCT_ControlXCliente)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormPurchase = formRepPiscina
    End Sub

    Public Sub New(idPadre As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        'AgregarCanastaPrincipal(FormPurchase.ListaPersonasHospedadas, idPadre)
        IDDocumento = idPadre
    End Sub

#Region "Metodo"

    Public Sub GetHabitacionUnico(idDistribucion As Integer, Id As Integer)
        Try
            Dim distribucionSA As New distribucionInfraestructuraSA
            Dim distribucionBE As documentoventaAbarrotes

            distribucionBE = New documentoventaAbarrotes
            distribucionBE.estado = "A"
            distribucionBE.idCliente = Id

            Dim ListaDistribucion = distribucionSA.GetDetalleHabitacion(distribucionBE)

            For Each item In ListaDistribucion
                txtHabitacion.Text = item.descripcionDistribucion
                txtHabitacion.Tag = item.idDistribucion
                txtNumeracion.Text = item.numeracion
                txtCapacidad.Text = 0
                txtCategoria.Text = item.Categoria
                txtTipoSubCategoria.Text = item.SubCategoria
            Next

            'Dim dt As New DataTable

            'With dt.Columns
            '    .Add("numero")
            '    .Add("habitacion")
            '    .Add("hospedado")
            '    .Add("nroDoc")
            '    .Add("sexo")
            '    .Add("nacionalidad")
            'End With

            'For Each i In listaPersona

            '    Dim sexo As String = String.Empty

            '    Select Case i.sexo
            '        Case "M"
            '            sexo = "MASCULINO"
            '        Case "F"
            '            sexo = "FEMENINO"
            '    End Select

            '    dt.Rows.Add(numeraciona,
            '               "HABITACION " & i.usuarioActualizacion,
            '                i.nombrePersona,
            '                i.nroDocumento,
            '               sexo,
            '                i.nacionalidad)

            '    numeraciona += 1
            'Next
            'dgvCompras.DataSource = dt
            'dgvCompras.TableDescriptor.Columns("habitacion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
            'dgvCompras.TableDescriptor.Columns("habitacion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub GetListaHabitaciones(idDistribucion As Integer, Id As Integer)
        Try
            Dim distribucionSA As New distribucionInfraestructuraSA
            Dim distribucionBE As documentoventaAbarrotes

            distribucionBE = New documentoventaAbarrotes
            distribucionBE.estado = "A"
            distribucionBE.idCliente = Id

            Dim ListaDistribucion = distribucionSA.GetDetalleHabitacion(distribucionBE)

            DibujarControl(ListaDistribucion)


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub DibujarControl(listDistr As List(Of distribucionInfraestructura))
        FlowHabitaciones.Controls.Clear()
        For Each items In listDistr
            Dim b As New RoundButton2
            b.BackColor = System.Drawing.Color.Green
            b.Text = items.descripcionDistribucion & " - " & items.numeracion & vbNewLine & items.SubCategoria
            b.Name = items.descripcionDistribucion
            b.TabIndex = 1
            b.FlatStyle = FlatStyle.Standard
            b.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            b.ForeColor = System.Drawing.Color.White
            b.Size = New System.Drawing.Size(120, 100)
            b.Tag = items.idDistribucion
            b.Image = ImageList1.Images(0)
            b.ImageAlign = ContentAlignment.MiddleCenter
            b.TextImageRelation = TextImageRelation.ImageAboveText
            b.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            b.UseVisualStyleBackColor = False
            FlowHabitaciones.Controls.Add(b)

            AddHandler b.Click, AddressOf Butto1
        Next
    End Sub

    Private Sub Butto1(sender As Object, e As EventArgs)
        Try

            'Dim dt As New DataTable

            'With dt.Columns
            '    .Add("numero")
            '    .Add("habitacion")
            '    .Add("hospedado")
            '    .Add("nroDoc")
            '    .Add("sexo")
            '    .Add("nacionalidad")
            'End With

            'For Each i In listaPersona

            '    Dim sexo As String = String.Empty

            '    Select Case i.sexo
            '        Case "M"
            '            sexo = "MASCULINO"
            '        Case "F"
            '            sexo = "FEMENINO"
            '    End Select

            '    dt.Rows.Add(numeraciona,
            '               "HABITACION " & i.usuarioActualizacion,
            '                i.nombrePersona,
            '                i.nroDocumento,
            '               sexo,
            '                i.nacionalidad)

            '    numeraciona += 1
            'Next
            'dgvCompras.DataSource = dt
            'dgvCompras.TableDescriptor.Columns("habitacion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
            'dgvCompras.TableDescriptor.Columns("habitacion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

#End Region


    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click
        FormPurchase.TabCD_HabitacionDetalle.Visible = False
        FormPurchase.Visible = False
        If FormPurchase IsNot Nothing Then
            FormPurchase.Visible = True
            FormPurchase.BringToFront()
            FormPurchase.Show()
        End If
    End Sub
End Class