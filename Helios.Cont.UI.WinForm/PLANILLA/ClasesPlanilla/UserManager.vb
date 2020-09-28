Imports Helios.Planilla.Business.Entity
Public NotInheritable Class UserManager
    Private Shared _TransactionData As TransactionDataBE
    Public Shared ReadOnly Property TransactionData As TransactionDataBE
        Get

            If _TransactionData Is Nothing Then
                _TransactionData = New TransactionDataBE With {.ComputerName = My.Computer.Name,
                                                               .LocalDate = Date.Now,
                                                               .LoggedUser = My.User.Name
                                                              }
            End If
            Return _TransactionData
        End Get
    End Property
End Class
Public Class LoggedUser

End Class