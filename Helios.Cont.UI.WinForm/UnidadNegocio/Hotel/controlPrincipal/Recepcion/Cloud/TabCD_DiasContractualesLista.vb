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

Public Class TabCD_DiasContractualesLista

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
            Dim ocupacionInfraSA As New ocupacionInfraestructuraSA
            Dim ocupacionBE As ocupacionInfraestructura
            ocupacionBE = New ocupacionInfraestructura
            ocupacionBE.estado = "A"
            ocupacionBE.idDistribucion = idDistribucion
            ocupacionBE.idEntidad = Id

            Dim ocupacionInfraBE = ocupacionInfraSA.GetListaOcupacionInfra(ocupacionBE)

            Dim dt As New DataTable

            With dt.Columns
                .Add("numero")
                .Add("tipo")
                .Add("habitacion")
                .Add("fechaIngreso")
                .Add("fechaSalida")
                .Add("dias")
                .Add("estado")
            End With

            For Each i In ocupacionInfraBE

                Dim Cant As Integer = 0                         ' Almacenar total de dias 
                Dim Ini As DateTime = i.chek_in               ' Fecha Inicial
                Dim Fin As DateTime = i.check_on               ' Fecha Final
                Dim diferencia As TimeSpan = Fin.Subtract(Ini)  ' Diferencia entre el rango 
                Dim dic As New Dictionary(Of String, String)    ' Diccionario.

                For x As Integer = 0 To diferencia.TotalDays

                    Dim fecha As DateTime = Ini.AddDays(x)

                    'If Not (fecha.DayOfWeek = DayOfWeek.Saturday Or fecha.DayOfWeek = DayOfWeek.Sunday) Then
                    Cant = Cant + 1 ' Sumar contador
                    ' Uso de diccionario, almacenar nombre del mes (ejemplo: septiembre) y los dias seleccionados del mismo (ejemplo: 04, 05, 06, 07, 10, 11)
                    Dim currentValueA As String = If(dic.ContainsKey(MonthName(fecha.Month)), dic.Item(MonthName(fecha.Month)), "")
                    If dic.ContainsKey(MonthName(fecha.Month)) Then
                        dic.Item(MonthName(fecha.Month)) = currentValueA & ", " & fecha.ToString("dd")
                    Else
                        ' Agregar en el dicionario los valores.
                        dic.Add(MonthName(fecha.Month), currentValueA & " " & fecha.ToString("dd"))
                    End If
                    'End If
                Next

                dt.Rows.Add(numeraciona,
                            Nothing,
                           "HABITACION " & i.usuarioActualizacion,
                            i.chek_in,
                            i.check_on,
                           CInt(Cant - 1),
                            "")

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
        FormPurchase.TabCD_DiasContractualesLista.Visible = False
        FormPurchase.Visible = False
        If FormPurchase IsNot Nothing Then
            FormPurchase.Visible = True
            FormPurchase.BringToFront()
            FormPurchase.Show()
        End If
    End Sub
End Class