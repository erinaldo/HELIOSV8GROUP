Imports System
Imports System.IO
Imports System.Net
Public Enum httpVerb
    [GET]
    POST
    PUT
    DELETE
End Enum


Public Class RESTClientAPI
    Public Property endPoint As String
    Public Property httpMethod As httpVerb

    Public Sub New()
        endPoint = ""
        httpMethod = httpVerb.GET
    End Sub

    Public Function makeRequest() As String
        Dim strResponseValue As String = String.Empty
        Dim request As HttpWebRequest = CType(WebRequest.Create(endPoint), HttpWebRequest)
        request.Method = httpMethod.ToString()
        Dim response As HttpWebResponse = Nothing

        Try
            response = CType(request.GetResponse(), HttpWebResponse)



            'Proecess the resppnse stream... (could be JSON, XML or HTML etc..._

            Using responseStream As Stream = response.GetResponseStream()

                If responseStream IsNot Nothing Then

                    Using reader As StreamReader = New StreamReader(responseStream)
                        strResponseValue = reader.ReadToEnd()
                    End Using
                End If
            End Using

        Catch ex As Exception
            strResponseValue = "{""errorMessages"":[""" & ex.Message.ToString() & """],""errors"":{}}"
        Finally

            If response IsNot Nothing Then
                CType(response, IDisposable).Dispose()
            End If
        End Try

        Return strResponseValue
    End Function
End Class
