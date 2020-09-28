Imports System.Net
Imports Helios.General

Public Class FormAnularVenta

    Public Property FechaEval As Date

    Public Sub New(fechaDocumento As Date)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'Dim myHttpWebRequest = CType(WebRequest.Create("http://www.microsoft.com"), HttpWebRequest)
        'Dim response = myHttpWebRequest.GetResponse()
        'Dim dt As String() = response.Headers.GetValues("Date")
        'Dim t As DateTime = Convert.ToDateTime(dt(0))
        txtFechaConfirma.Value = Date.Now
        txtFechaConfirma.Enabled = False
        FechaEval = fechaDocumento
    End Sub

    Private Sub BunifuThinButton23_Click(sender As Object, e As EventArgs) Handles BunifuThinButton23.Click
        Tag = ApruebaAnulacion()
        Close()
    End Sub

    Private Function ApruebaAnulacion() As Boolean
        ApruebaAnulacion = False

        '    Dim range As New General.Range(FechaEval, FechaEval.AddDays(-5))
        Dim fechaActual = txtFechaConfirma.Value.Date

        Dim numeroDias = DateDiff(DateInterval.Day, FechaEval.Date, fechaActual.Date)

        If numeroDias <= 7 AndAlso numeroDias >= 0 Then
            ApruebaAnulacion = True
        End If

        'If range.ContainsDate(fechaActual) Then
        '    ApruebaAnulacion = True
        'End If
    End Function
End Class