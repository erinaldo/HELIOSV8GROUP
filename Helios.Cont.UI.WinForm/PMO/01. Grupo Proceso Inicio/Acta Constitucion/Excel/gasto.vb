Option Strict On
Public Class gasto
    Private _decripcion As String
    Private _extra As String
    Private _unidad As String
    Private _cantidad As Decimal
    Private _pu As Decimal
    Private _Importe As Decimal

    'Private _otrasDeduc As Decimal
    'Private _deducPlanilla As Decimal
    'Private _totalDeduc As Decimal
    'Private _netoPagar As Decimal
    'Private _otrosAporte As Decimal
    'Private _aportePlanilla As Decimal
    'Private _totalAporte As Decimal
    'Private _totalRA As Decimal
    Private _sustento As String
    Private _tipoRecurso As String
    Private _clasificacion As String
    'Private _tasaIgv As Decimal
    'Private _costo As Decimal
    'Private _noSustenta As Decimal
    'Private _Porcentaje As Decimal
    'Private _montoIgv As Decimal
    'Private _pstoRef As Decimal
    'Private _Total As Decimal

    Property Decripcion() As String
        Get
            Return _decripcion.Trim
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _decripcion = "N"
            Else
                If value.Trim.Length > 0 Then
                    _decripcion = value.ToUpper
                Else
                    _decripcion = "N"
                End If
            End If
        End Set
    End Property

    Property Extra() As String
        Get
            Return _extra
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _extra = "N"
            Else
                If value.Trim.Length > 0 Then
                    _extra = value
                Else
                    _extra = "N"
                End If
            End If
        End Set
    End Property

    Property Unidad() As String
        Get
            Return _unidad
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _unidad = "N"
            Else
                If value.Trim.Length > 0 Then
                    _unidad = value.ToUpper
                Else
                    _unidad = "N"
                End If
            End If
        End Set
    End Property

    Property Cantidad() As Decimal
        Get
            Return _cantidad
        End Get
        Set(ByVal value As Decimal)
            If IsNothing(value) Then
                _cantidad = 0
            Else
                _cantidad = value
            End If
        End Set
    End Property

    Property Pu() As Decimal
        Get
            Return _pu
        End Get
        Set(ByVal value As Decimal)
            If IsNothing(value) Then
                _pu = 0
            Else
                _pu = value
            End If
        End Set
    End Property

    Property Importe() As Decimal
        Get
            Return _Importe
        End Get
        Set(ByVal value As Decimal)
            If IsNothing(value) Then
                _Importe = 0
            Else
                _Importe = value
            End If
        End Set
    End Property

    'Property OtrasDeduc() As Decimal
    '    Get
    '        Return _otrasDeduc
    '    End Get
    '    Set(ByVal value As Decimal)
    '        If IsNothing(value) Then
    '            _otrasDeduc = 0
    '        Else
    '            _otrasDeduc = value
    '        End If
    '    End Set
    'End Property

    'Property DeducPlanilla() As Decimal
    '    Get
    '        Return _deducPlanilla
    '    End Get
    '    Set(ByVal value As Decimal)
    '        If IsNothing(value) Then
    '            _deducPlanilla = 0
    '        Else
    '            _deducPlanilla = value
    '        End If
    '    End Set
    'End Property

    'Property TotalDeduc() As Decimal
    '    Get
    '        Return _totalDeduc
    '    End Get
    '    Set(ByVal value As Decimal)
    '        If IsNothing(value) Then
    '            _totalDeduc = 0
    '        Else
    '            _totalDeduc = value
    '        End If
    '    End Set
    'End Property

    'Property NetoPagar() As Decimal
    '    Get
    '        Return _netoPagar
    '    End Get
    '    Set(ByVal value As Decimal)
    '        If IsNothing(value) Then
    '            _netoPagar = 0
    '        Else
    '            _netoPagar = value
    '        End If
    '    End Set
    'End Property

    'Property OtrosAporte() As Decimal
    '    Get
    '        Return _otrosAporte
    '    End Get
    '    Set(ByVal value As Decimal)
    '        If IsNothing(value) Then
    '            _otrosAporte = 0
    '        Else
    '            _otrosAporte = value
    '        End If
    '    End Set
    'End Property

    'Property AportePlanilla() As Decimal
    '    Get
    '        Return _aportePlanilla
    '    End Get
    '    Set(ByVal value As Decimal)
    '        If IsNothing(value) Then
    '            _aportePlanilla = 0
    '        Else
    '            _aportePlanilla = value
    '        End If
    '    End Set
    'End Property

    'Property TotalAporte() As Decimal
    '    Get
    '        Return _totalAporte
    '    End Get
    '    Set(ByVal value As Decimal)
    '        If IsNothing(value) Then
    '            _totalAporte = 0
    '        Else
    '            _totalAporte = value
    '        End If
    '    End Set
    'End Property

    'Property TotalRA() As Decimal
    '    Get
    '        Return _totalRA
    '    End Get
    '    Set(ByVal value As Decimal)
    '        If IsNothing(value) Then
    '            _totalRA = 0
    '        Else
    '            _totalRA = value
    '        End If
    '    End Set
    'End Property

    Property Sustento() As String
        Get
            Return _sustento.Trim
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _sustento = "N"
            Else
                If value.Trim.Length > 0 Then
                    _sustento = value.ToUpper
                Else
                    _sustento = "N"
                End If
            End If
        End Set
    End Property

    Property TipoRecurso() As String
        Get
            Return _tipoRecurso.Trim
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _tipoRecurso = "N"
            Else
                If value.Trim.Length > 0 Then
                    _tipoRecurso = value.ToUpper
                Else
                    _tipoRecurso = "N"
                End If
            End If
        End Set
    End Property

    Property Clasificacion() As String
        Get
            Return _clasificacion.Trim
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _clasificacion = "N"
            Else
                If value.Trim.Length > 0 Then
                    _clasificacion = value.ToUpper
                Else
                    _clasificacion = "N"
                End If
            End If
        End Set
    End Property
    'Property TasaIgv() As Decimal
    '    Get
    '        Return _tasaIgv
    '    End Get
    '    Set(ByVal value As Decimal)
    '        If IsNothing(value) Then
    '            _tasaIgv = 0
    '        Else
    '            _tasaIgv = value
    '        End If
    '    End Set
    'End Property

    'Property Costo() As Decimal
    '    Get
    '        Return _costo
    '    End Get
    '    Set(ByVal value As Decimal)
    '        If IsNothing(value) Then
    '            _costo = 0
    '        Else
    '            _costo = value
    '        End If
    '    End Set
    'End Property

    'Property NoSustenta() As Decimal
    '    Get
    '        Return _noSustenta
    '    End Get
    '    Set(ByVal value As Decimal)
    '        If IsNothing(value) Then
    '            _noSustenta = 0
    '        Else
    '            _noSustenta = value
    '        End If
    '    End Set
    'End Property

    'Property Porcentaje() As Decimal
    '    Get
    '        Return _Porcentaje
    '    End Get
    '    Set(ByVal value As Decimal)
    '        If IsNothing(value) Then
    '            _Porcentaje = 0
    '        Else
    '            _Porcentaje = value
    '        End If
    '    End Set
    'End Property

    'Property MontoIgv() As Decimal
    '    Get
    '        Return _montoIgv
    '    End Get
    '    Set(ByVal value As Decimal)
    '        If IsNothing(value) Then
    '            _montoIgv = 0
    '        Else
    '            _montoIgv = value
    '        End If
    '    End Set
    'End Property

    'Property PstoRef() As Decimal
    '    Get
    '        Return _pstoRef
    '    End Get
    '    Set(ByVal value As Decimal)
    '        If IsNothing(value) Then
    '            _pstoRef = 0
    '        Else
    '            _pstoRef = value
    '        End If
    '    End Set
    'End Property

    'Property Total() As Decimal
    '    Get
    '        Return _Total
    '    End Get
    '    Set(ByVal value As Decimal)
    '        If IsNothing(value) Then
    '            _Total = 0
    '        Else
    '            _Total = value
    '        End If
    '    End Set
    'End Property
End Class
