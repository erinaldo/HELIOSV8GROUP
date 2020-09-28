Imports RestSharp

Public Class RestHelper(Of TRequest As Class, TResponse As {Class, New})
    ' Dim client As New RestClient("http://localhost/OpenInvoicePeruUBL21/api")
    Public Shared Function Execute(metodo As String, request As TRequest) As TResponse


        'Dim client As New RestClient("http://138.128.171.106/SoftpackUBL21/api")
        'Dim restRequest As New RestRequest(metodo, Method.POST) With {
        '        .RequestFormat = DataFormat.Json
        '        }
        'restRequest.AddBody(request)

        'Dim restResponse = client.Execute(Of TResponse)(restRequest)
        'Return restResponse.Data
    End Function

End Class