Imports System.Collections.Generic
Imports System.Drawing
Imports System.IO
Imports System.Linq
Imports System.Net
Imports System.Text
Imports System.Web
Public Class Reniec

#Region "Variables"
    Private _Nombres As String
    Private _ApePaterno As String
    Private _ApeMaterno As String
    Private _Dni As String
    Private state As Resul
    Private myCookie As CookieContainer
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

#Region "Propiedades"
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
    Public ReadOnly Property Dni() As String
        Get
            Return _Dni
        End Get
    End Property
    Public ReadOnly Property Nombres() As String
        Get
            Return _Nombres
        End Get
    End Property
    Public ReadOnly Property ApePaterno() As String
        Get
            Return _ApePaterno
        End Get
    End Property
    Public ReadOnly Property ApeMaterno() As String
        Get
            Return _ApeMaterno
        End Get
    End Property
    Public ReadOnly Property GetResul() As Resul
        Get
            Return state
        End Get
    End Property
#End Region


#Region "Metodos"
    Private Function ReadCapcha() As Image
        Try
            Dim myWebRequest As HttpWebRequest = DirectCast(WebRequest.Create("https://cel.reniec.gob.pe/valreg/codigo.do"), HttpWebRequest)
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
    Public Sub GetInfo(numDni As String, ImgCapcha As String)
        Try
            Dim myUrl As String = [String].Format("https://cel.reniec.gob.pe/valreg/valreg.do?accion=buscar&nuDni={0}&imagen={1}", numDni, ImgCapcha)
            Dim myWebRequest As HttpWebRequest = DirectCast(WebRequest.Create(myUrl), HttpWebRequest)
            myWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:23.0) Gecko/20100101 Firefox/23.0"
            'esto creo que lo puse por gusto :/
            myWebRequest.CookieContainer = myCookie
            myWebRequest.Credentials = CredentialCache.DefaultCredentials
            myWebRequest.Proxy = Nothing
            Dim myHttpWebResponse As HttpWebResponse = DirectCast(myWebRequest.GetResponse(), HttpWebResponse)
            Dim myStream As Stream = myHttpWebResponse.GetResponseStream()
            Dim myStreamReader As New StreamReader(myStream)
            Dim _WebSource As String = HttpUtility.HtmlDecode(myStreamReader.ReadToEnd())
            Dim _split As String() = _WebSource.Split(New Char() {"<"c, ">"c, ControlChars.Lf, ControlChars.Cr})
            Dim _resul As New List(Of String)()
            For i As Integer = 0 To _split.Length - 1
                If Not String.IsNullOrEmpty(_split(i).Trim()) Then
                    _resul.Add(_split(i).Trim())
                End If
            Next
            Select Case _resul.Count
                Case 217
                    state = Resul.ErrorCapcha
                    Exit Select
                Case 232
                    state = Resul.Ok
                    Exit Select
                Case 222
                    state = Resul.NoResul
                    Exit Select
                Case Else
                    state = Resul.[Error]
                    Exit Select
            End Select
            If state = Resul.Ok Then
                Me._Dni = numDni
                Me._Nombres = _resul(185)
                Me._ApePaterno = _resul(186)
                Me._ApeMaterno = _resul(187)
            End If
            myHttpWebResponse.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

End Class
