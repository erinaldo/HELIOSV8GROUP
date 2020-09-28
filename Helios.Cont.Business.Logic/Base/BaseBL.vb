Imports Helios.Cont.Data.EF
Imports System.Transactions

Public MustInherit Class BaseBL
    Protected _DbContext As HELIOSEntities
    Protected _ts As TransactionScope

    'Public Sub New(Context As HELIOSEntities, ts As TransactionScope)
    '    _DbContext = Context
    '    _ts = ts
    'End Sub
    Public ReadOnly Property HeliosData As HELIOSEntities
        Get
            If _DbContext Is Nothing Then
                _DbContext = New HELIOSEntities
            End If
            Return _DbContext
        End Get
    End Property


End Class
