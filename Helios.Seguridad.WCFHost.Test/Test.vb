Imports System.ServiceModel
Imports Helios.Seguridad.WCFService.ServiceImplementation
Imports System.ServiceModel.Description

Module Test

    Sub Main()
        Try

            Console.WriteLine("***** Console Based WCF Host Engine *****")

            Using serviceHost As ServiceHost = New ServiceHost(GetType(SeguridadService))

                ' Open the HOST and Start LISTENING for incoming messages.
                serviceHost.Open()
                Console.WriteLine()
                Console.WriteLine("***** Host Information *****")
                For Each serviceEndpoint As System.ServiceModel.Description.ServiceEndpoint In serviceHost.Description.Endpoints

                    Console.WriteLine("A [Address]: {0}", serviceEndpoint.Address)
                    Console.WriteLine("B [Binding]: {0}", serviceEndpoint.Binding.Name)
                    Console.WriteLine("C [Contract]: {0}", serviceEndpoint.Contract.Name)
                    Console.WriteLine()
                Next
                Console.WriteLine("**********************")

                'Keep the service running until the Enter key is pressed.
                Console.WriteLine("THE WCF-CUSTOMER-SERIVE IS RUNNING.")
                Console.WriteLine("PRESS ENTER-KEY TO END WCF SERVICE.")
                Console.ReadLine()
                serviceHost.Close()
            End Using
        Catch ex As Exception
            Console.WriteLine(ex)
            Console.ReadLine()
        End Try
    End Sub

End Module
