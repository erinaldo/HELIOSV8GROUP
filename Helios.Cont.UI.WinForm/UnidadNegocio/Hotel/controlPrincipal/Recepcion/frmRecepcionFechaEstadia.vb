﻿Imports Syncfusion.Windows.Forms
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

Public Class frmRecepcionFechaEstadia
    Inherits frmMaster


    Public Property IDDocumento As Integer = 0

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Sub New(idPadre As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me.KeyPreview = True
        'AgregarCanastaPrincipal(FormPurchase.ListaPersonasHospedadas, idPadre)
        IDDocumento = idPadre
    End Sub

#Region "Metodo"
    Public Sub GetCargarFechas(fechaIngreso As DateTime, fechasalida As DateTime, dias As Integer)
        Try
            Me.monthCalendarAdv1.Value = fechaIngreso
            Me.MonthCalendarAdv2.Value = fechasalida
            txtdias.Text = dias
            Me.textBox1.Text = Me.monthCalendarAdv1.Value.ToLongDateString()
            Me.TextBox2.Text = Me.MonthCalendarAdv2.Value.ToLongDateString()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub GetCargarFechasBD(idDistribucion As Integer, Id As Integer)
        Try
            Dim ocupacionInfraSA As New ocupacionInfraestructuraSA
            Dim ocupacionInfraBE As New ocupacionInfraestructura
            Dim ocupacionBE As ocupacionInfraestructura
            ocupacionBE = New ocupacionInfraestructura
            ocupacionBE.estado = "A"
            ocupacionBE.idDistribucion = idDistribucion
            ocupacionBE.idDocumento = Id

            ocupacionInfraBE = ocupacionInfraSA.OcupacionInfra(ocupacionBE)

            Me.monthCalendarAdv1.Value = ocupacionInfraBE.chek_in
            Me.MonthCalendarAdv2.Value = ocupacionInfraBE.check_on


            Dim Cant As Integer = 0                         ' Almacenar total de dias 
            Dim Ini As DateTime = monthCalendarAdv1.Value              ' Fecha Inicial
            Dim Fin As DateTime = MonthCalendarAdv2.Value              ' Fecha Final
            Dim diferencia As TimeSpan = Fin.Subtract(Ini)  ' Diferencia entre el rango 
            Dim dic As New Dictionary(Of String, String)    ' Diccionario.

            For i As Integer = 0 To diferencia.TotalDays
                Dim fecha As DateTime = Ini.AddDays(i)

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

            txtdias.Text = Cant - 1

            Me.textBox1.Text = Me.monthCalendarAdv1.Value.ToLongDateString()
            Me.TextBox2.Text = Me.MonthCalendarAdv2.Value.ToLongDateString()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
#End Region


    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData

            Case Keys.Escape
                Close()
            Case Else
                'Do Nothing
        End Select

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function


    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        Close()
    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click
        Try
            Dim ocupacionInfraBE As New ocupacionInfraestructura
            ocupacionInfraBE.idEmpresa = Gempresas.IdEmpresaRuc
            ocupacionInfraBE.idEstablecimiento = GEstableciento.IdEstablecimiento
            ocupacionInfraBE.chek_in = monthCalendarAdv1.Value
            ocupacionInfraBE.check_on = MonthCalendarAdv2.Value
            ocupacionInfraBE.idDistribucion = IDDocumento
            ocupacionInfraBE.estado = "A"
            ocupacionInfraBE.dias = txtdias.Text
            Tag = ocupacionInfraBE
            Hide()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Txtdias_KeyDown(sender As Object, e As KeyEventArgs) Handles txtdias.KeyDown
        Dim nombres = String.Empty
        Try
            'TextNumIdentrazon.Enabled = False
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True

                MonthCalendarAdv2.Tag = 1
                MonthCalendarAdv2.Value = DateAdd(DateInterval.Day, CInt(txtdias.Text), monthCalendarAdv1.Value)
                MonthCalendarAdv2.Tag = 0
                Me.textBox1.Text = Me.monthCalendarAdv1.Value.ToShortDateString()
                Me.textBox2.Text = Me.MonthCalendarAdv2.Value.ToShortDateString()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Txtdias_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtdias.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub Txtdias_Click(sender As Object, e As EventArgs) Handles txtdias.Click
        Try
            txtdias.Tag = 1
            txtdias.Select(0, txtdias.Text.Length)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub MonthCalendarAdv1_DateSelected(sender As Object, e As EventArgs) Handles monthCalendarAdv1.DateSelected
        Try
            Me.MonthCalendarAdv2.MinValue = DateAdd(DateInterval.Day, 1, monthCalendarAdv1.Value)
            MonthCalendarAdv2.Value = DateAdd(DateInterval.Day, 1, monthCalendarAdv1.Value)
            Me.textBox1.Text = Me.monthCalendarAdv1.Value.ToShortDateString()
            Me.textBox2.Text = Me.MonthCalendarAdv2.Value.ToShortDateString()

            Dim Cant As Integer = 0                         ' Almacenar total de dias 
            Dim Ini As DateTime = monthCalendarAdv1.Value              ' Fecha Inicial
            Dim Fin As DateTime = MonthCalendarAdv2.Value              ' Fecha Final
            Dim diferencia As TimeSpan = Fin.Subtract(Ini)  ' Diferencia entre el rango 
            Dim dic As New Dictionary(Of String, String)    ' Diccionario.

            For i As Integer = 0 To diferencia.TotalDays
                Dim fecha As DateTime = Ini.AddDays(i)

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

            'Dim strCadena As String = ""
            'For Each item In dic
            '    strCadena += item.Value & " de " & item.Key
            'Next
            txtdias.Text = Cant - 1


            'BoldDateTime.Clear()
            'BoldDateTime.Add(monthCalendarAdv1.Value.AddDays(+1))
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub MonthCalendarAdv2_DateSelected(sender As Object, e As EventArgs) Handles MonthCalendarAdv2.DateSelected
        Try

            Dim Cant As Integer = 0                         ' Almacenar total de dias 
            Dim Ini As DateTime = monthCalendarAdv1.Value              ' Fecha Inicial
            Dim Fin As DateTime = MonthCalendarAdv2.Value              ' Fecha Final
            Dim diferencia As TimeSpan = Fin.Subtract(Ini)  ' Diferencia entre el rango 
            Dim dic As New Dictionary(Of String, String)    ' Diccionario.

            For i As Integer = 0 To diferencia.TotalDays
                Dim fecha As DateTime = Ini.AddDays(i)

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

            'Dim strCadena As String = ""
            'For Each item In dic
            '    strCadena += item.Value & " de " & item.Key
            'Next
            txtdias.Text = Cant - 1

            MonthCalendarAdv2.Value = DateAdd(DateInterval.Day, CInt(txtdias.Text), monthCalendarAdv1.Value)
            'Dim DiferenciaDias As Integer = DateDiff(DateInterval.Day, txtCheckIn.Value, txtCheckOn.Value)
            'txtdias.Text = DiferenciaDias + 1
            Me.textBox2.Text = Me.MonthCalendarAdv2.Value.ToLongDateString()
            'BoldDateTime.Clear()
            'BoldDateTime.Add(monthCalendarAdv1.Value.AddDays(+(TextBox3.Text)))
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class