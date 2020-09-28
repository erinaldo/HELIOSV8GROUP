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

Public Class TabCD_HospedadosLista

    Public Property FormPurchase As TabCT_ControlXCliente
    Public Property IDDocumento As Integer = 0

    Public Sub New(formRepPiscina As TabCT_ControlXCliente)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormPurchase = formRepPiscina
    End Sub

#Region "Metodo"

    Public Sub GetCargarFechasBD(idDistribucion As Integer, Id As Integer)
        Try

            Dim numeraciona As Integer = 1
            Dim personaSA As New personaBeneficioSA
            Dim personaBE As personaBeneficio
            personaBE = New personaBeneficio
            personaBE.estado = "A"
            personaBE.idDistribucion = idDistribucion
            personaBE.idEntidad = Id

            Dim listaPersona = personaSA.ListarHospedadosXCliente(personaBE)

            Dim dt As New DataTable

            With dt.Columns
                .Add("numero")
                .Add("habitacion")
                .Add("hospedado")
                .Add("nroDoc")
                .Add("sexo")
                .Add("nacionalidad")
            End With

            For Each i In listaPersona

                Dim sexo As String = String.Empty

                Select Case i.sexo
                    Case "M"
                        sexo = "MASCULINO"
                    Case "F"
                        sexo = "FEMENINO"
                End Select

                dt.Rows.Add(numeraciona,
                           "HABITACION " & i.usuarioActualizacion,
                            i.nombrePersona,
                            i.nroDocumento,
                           sexo,
                            i.nacionalidad)

                numeraciona += 1
            Next
            dgvCompras.DataSource = dt
            dgvCompras.TableDescriptor.Columns("habitacion").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
            dgvCompras.TableDescriptor.Columns("habitacion").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

#End Region

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click
        FormPurchase.TabCD_HospedadosLista.Visible = False
        FormPurchase.Visible = False
        If FormPurchase IsNot Nothing Then
            FormPurchase.Visible = True
            FormPurchase.BringToFront()
            FormPurchase.Show()
        End If
    End Sub
End Class