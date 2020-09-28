
Imports System.Collections.Generic
Imports System.Drawing
Imports System.IO
Imports System.Linq
Imports System.Net
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Web
Public Class SunatAPIV2

#Region "Variables"
    Private _RazonSocial As String
    Private _Direcion As String
    Private _Ruc As String
    Private _EstadoContr As String
    Private _TipoContr As String
    Private _Telefono As String
    Private myCookie As CookieContainer
    Private state As Resul
#End Region


    Public Sub New()
        Try
            myCookie = Nothing
            myCookie = New CookieContainer()
            ServicePointManager.Expect100Continue = True
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3
            ReadCapcha()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#Region "propiedades"
    Public Enum Resul
        Ok = 0
        NoResul = 1
        ErrorCapcha = 2
        [Error] = 3
    End Enum
    Public ReadOnly Property GetCapcha() As Image
        Get
            Return ReadCapcha()
        End Get
    End Property
    Public ReadOnly Property RazonSocial() As String
        Get
            Return _RazonSocial
        End Get
    End Property
    Public ReadOnly Property Direcion() As String
        Get
            Return _Direcion
        End Get
    End Property
    Public ReadOnly Property Ruc() As String
        Get
            Return _Ruc
        End Get
    End Property
    Public ReadOnly Property EstadoContr() As String
        Get
            Return _EstadoContr
        End Get
    End Property
    Public ReadOnly Property TipoContr() As String
        Get
            Return _TipoContr
        End Get
    End Property
    Public ReadOnly Property Telefono() As String
        Get
            Return _Telefono
        End Get
    End Property
    Public ReadOnly Property GetResul() As Resul
        Get
            Return state
        End Get
    End Property
#End Region

#Region "Metodos"
    Private Function ValidarCertificado(sender As Object, certificate As System.Security.Cryptography.X509Certificates.X509Certificate, chain As System.Security.Cryptography.X509Certificates.X509Chain, sslPolicyErrors As System.Net.Security.SslPolicyErrors) As [Boolean]
        Return True
    End Function
    Private Function ReadCapcha() As Image
        Try
            System.Net.ServicePointManager.ServerCertificateValidationCallback = New System.Net.Security.RemoteCertificateValidationCallback(AddressOf ValidarCertificado)
            Dim myWebRequest As HttpWebRequest = DirectCast(WebRequest.Create("http://www.sunat.gob.pe/cl-ti-itmrconsruc/captcha?accion=image&magic=2"), HttpWebRequest)
            myWebRequest.CookieContainer = myCookie
            myWebRequest.Proxy = Nothing
            myWebRequest.Credentials = CredentialCache.DefaultCredentials
            Dim myWebResponse As HttpWebResponse = DirectCast(myWebRequest.GetResponse(), HttpWebResponse)
            Dim myImgStream As Stream = myWebResponse.GetResponseStream()
            Return Image.FromStream(myImgStream)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub GetInfo(numRuc As String, TextoCapcha As String)
        Try
            Dim myUrl As String = [String].Format("http://www.sunat.gob.pe/cl-ti-itmrconsruc/jcrS00Alias?accion=consPorRuc&nroRuc={0}&codigo={1}", numRuc, TextoCapcha)
            Dim myWebRequest As HttpWebRequest = DirectCast(WebRequest.Create(myUrl), HttpWebRequest)
            myWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:23.0) Gecko/20100101 Firefox/23.0"
            myWebRequest.CookieContainer = myCookie
            myWebRequest.Credentials = CredentialCache.DefaultCredentials
            myWebRequest.Proxy = Nothing
            Dim myHttpWebResponse As HttpWebResponse = DirectCast(myWebRequest.GetResponse(), HttpWebResponse)
            Dim myStream As Stream = myHttpWebResponse.GetResponseStream()
            Dim myStreamReader As New StreamReader(myStream)
            Dim xDat As String = HttpUtility.HtmlDecode(myStreamReader.ReadToEnd())
            Dim _split As String() = xDat.Split(New Char() {"<"c, ">"c, ControlChars.Lf, ControlChars.Cr})
            Dim _result As New List(Of [String])()
            For i As Integer = 0 To _split.Length - 1
                If Not String.IsNullOrEmpty(_split(i).Trim()) Then
                    _result.Add(_split(i).Trim())
                End If
            Next
            If _result.Count = 77 Then
                state = Resul.ErrorCapcha
            End If
            If _result.Count = 147 Then
                state = Resul.NoResul
            End If
            If _result.Count >= 635 Then
                state = Resul.Ok
            End If
            Select Case state
                Case Resul.Ok
                    StateOK(xDat, numRuc)
                    Exit Select
                Case Resul.ErrorCapcha
                    Exit Select
                Case Resul.NoResul
                    Exit Select
                Case Else
                    Exit Select
            End Select
            myHttpWebResponse.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub StateOK(xDat As String, numRuc As String)
        Dim xRuc As String = String.Empty
        Dim xRazSoc As String = String.Empty
        Dim xDir As String = String.Empty
        Dim xEsCn As String = String.Empty
        Dim xTpCn As String = String.Empty
        Dim xTef As String = String.Empty
        Dim tabla As String()
        xDat = xDat.Replace("     ", " ")
        xDat = xDat.Replace("    ", " ")
        xDat = xDat.Replace("   ", " ")
        xDat = xDat.Replace("  ", " ")
        xDat = xDat.Replace("( ", "(")
        xDat = xDat.Replace(" )", ")")
        tabla = Regex.Split(xDat, "<td class")
        If numRuc.StartsWith("1") Then
            tabla(1) = tabla(1).Replace((Convert.ToString("=""bg"" colspan=3>") & numRuc) + " - ", "")
            tabla(1) = tabla(1).Replace("</td>" & vbCr & vbLf & " </tr>" & vbCr & vbLf & " <tr>" & vbCr & vbLf, "")
            tabla(3) = tabla(3).Replace("=""bg"" colspan=3>", "")
            tabla(3) = tabla(3).Replace("</td>" & vbCr & vbLf & " </tr>" & vbCr & vbLf & " " & vbCr & vbLf & " <tr>" & vbCr & vbLf & " ", "")
            tabla(8) = tabla(8).Replace("=""bgn"" colspan=1 >", "")
            tabla(8) = tabla(8).Replace("</td>" & vbCr & vbLf & " ", "")
            Dim NuevoRUS As [String] = tabla(8).Trim()
            If NuevoRUS = "Afecto al Nuevo RUS:" Then
                tabla(14) = tabla(14).Replace("=""bg"" colspan=1>", "")
                tabla(14) = tabla(14).Replace("</td>" & vbCr & vbLf & " ", "")
                tabla(19) = tabla(19).Replace("=""bg"" colspan=3>", "")
                tabla(19) = tabla(19).Replace("</td>" & vbCr & vbLf & " </tr>" & vbCr & vbLf & "<!-- SE COMENTO POR INDICACION DEL PASE PAS20134EA20000207 -->" & vbCr & vbLf & "<!-- <tr> -->" & vbCr & vbLf & "<!-- ", "")
                tabla(21) = tabla(21).Replace("=""bg"" colspan=1>", "")
                tabla(21) = tabla(21).Replace("</td> -->" & vbCr & vbLf & "<!-- ", "")
                xEsCn = DirectCast(tabla(14), String)
                xDir = DirectCast(tabla(19), String)
                xTef = DirectCast(tabla(21), String)
            Else
                tabla(12) = tabla(12).Replace("=""bg"" colspan=1>", "")
                tabla(12) = tabla(12).Replace("</td>" & vbCr & vbLf & " ", "")
                tabla(17) = tabla(17).Replace("=""bg"" colspan=3>", "")
                tabla(17) = tabla(17).Replace("</td>" & vbCr & vbLf & " </tr>" & vbCr & vbLf & "<!-- SE COMENTO POR INDICACION DEL PASE PAS20134EA20000207 -->" & vbCr & vbLf & "<!-- <tr> -->" & vbCr & vbLf & "<!-- ", "")
                tabla(19) = tabla(19).Replace("=""bg"" colspan=1>", "")
                tabla(19) = tabla(19).Replace("</td> -->" & vbCr & vbLf & "<!-- ", "")
                xEsCn = DirectCast(tabla(12), String)
                xDir = DirectCast(tabla(17), String)
                xTef = DirectCast(tabla(19), String)
            End If
            xRuc = numRuc
            xRazSoc = DirectCast(tabla(1), String)
            xTpCn = DirectCast(tabla(3), String)
        ElseIf numRuc.StartsWith("2") Then
            tabla(1) = tabla(1).Replace((Convert.ToString("=""bg"" colspan=3>") & numRuc) + " - ", "")
            tabla(1) = tabla(1).Replace("</td>" & vbCr & vbLf & " </tr>" & vbCr & vbLf & " <tr>" & vbCr & vbLf, "")
            tabla(3) = tabla(3).Replace("=""bg"" colspan=3>", "")
            tabla(3) = tabla(3).Replace("</td>" & vbCr & vbLf & " </tr>" & vbCr & vbLf & " " & vbCr & vbLf & " <tr>" & vbCr & vbLf & " ", "")
            tabla(10) = tabla(10).Replace("=""bg"" colspan=1>", "")
            tabla(10) = tabla(10).Replace("</td>" & vbCr & vbLf, "")
            tabla(15) = tabla(15).Replace("=""bg"" colspan=3>", "")
            tabla(15) = tabla(15).Replace("</td>" & vbCr & vbLf & " </tr>" & vbCr & vbLf & "<!-- SE COMENTO POR INDICACION DEL PASE PAS20134EA20000207 -->" & vbCr & vbLf & "<!-- <tr> -->" & vbCr & vbLf & "<!-- ", "")
            tabla(17) = tabla(17).Replace("=""bg"" colspan=1>", "")
            tabla(17) = tabla(17).Replace("</td> -->" & vbCr & vbLf & "<!-- ", "")
            xRuc = numRuc
            xRazSoc = DirectCast(tabla(1), String)
            xTpCn = DirectCast(tabla(3), String)
            xEsCn = DirectCast(tabla(10), String)
            xDir = DirectCast(tabla(15), String)
            xTef = DirectCast(tabla(17), String)
        End If
        _Ruc = xRuc
        _TipoContr = xTpCn
        _RazonSocial = xRazSoc
        _Direcion = xDir
        _EstadoContr = xEsCn
        _Telefono = xTef
    End Sub
#End Region

End Class
