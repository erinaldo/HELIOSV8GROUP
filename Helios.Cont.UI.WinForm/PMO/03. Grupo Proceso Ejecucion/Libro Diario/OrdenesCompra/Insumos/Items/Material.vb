Public Class Material

    Private _codigo As String
    Private _clasificacion As String
    Private _capacidad As String
    Private _presion As String
    Private _electricidad As String
    Private _transmision As String
    Private _rpm As String
    Private _marca As String
    Private _ruido As String
    Private _peso As String
    Private _filtro As String

    Private _Presentacion As String
    Private _UnidadMedida As String
    Private _TipoEx As String
    Private _OrigenProducto As String
    Private _Cuenta As String

    Sub New()

    End Sub
    Sub New(cod As String, clas As String, cap As String, presion As String, elec As String, trans As String, rpm As String,
            marca As String, ruido As String, peso As String, filtro As String,
            presentac As String, unidad As String, tipoex As String, cuenta As String)
        Me.Codigo = cod
        Me.Clasificacion = clas
        Me.Capacidad = cap
        Me.Presion = presion
        Me.Electricidad = elec
        Me.Transmision = trans
        Me.Rpm = rpm
        Me.Marca = marca
        Me.Ruido = ruido
        Me.Peso = peso
        Me.Filtro = filtro
        Me.Presentacion = presentac
        Me.UnidadMedida = unidad
        Me.TipoEx = tipoex
        Me.Cuenta = cuenta
    End Sub

    Property Presentacion() As String
        Get
            Return _Presentacion
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                Throw New Exception("Ingrese una presentación")
            Else
                If value.Trim.Length > 0 Then
                    _Presentacion = value
                Else
                    Throw New Exception("Ingrese una presentación")
                End If
            End If
        End Set
    End Property

    Property UnidadMedida() As String
        Get
            Return _UnidadMedida
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                Throw New Exception("Ingrese la Unidad de medida")
            Else
                If value.Trim.Length > 0 Then
                    _UnidadMedida = value
                Else
                    Throw New Exception("Ingrese la Unidad de medida")
                End If
            End If
        End Set
    End Property

    Property TipoEx() As String
        Get
            Return _TipoEx
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                Throw New Exception("Ingrese el tipo de Existencia")
            Else
                If value.Trim.Length > 0 Then
                    _TipoEx = value
                Else
                    Throw New Exception("Ingrese el tipo de Existencia")
                End If
            End If
        End Set
    End Property

    Property Cuenta() As String
        Get
            Return _Cuenta
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                Throw New Exception("Ingrese la cuenta contable")
            Else
                If value.Trim.Length > 0 Then
                    _Cuenta = value
                Else
                    Throw New Exception("Ingrese la cuenta contable")
                End If
            End If
        End Set
    End Property

    Property Codigo() As String
        Get
            Return _codigo
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                Throw New Exception("Ingrese un código válido")
            Else
                If value.Trim.Length > 0 Then
                    _codigo = value
                Else
                    Throw New Exception("Ingrese un código válido")
                End If
            End If
        End Set
    End Property

    Property Clasificacion() As String
        Get
            Return _clasificacion
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                Throw New Exception("Ingrese la clasificación dle item")
            Else
                If value.Trim.Length > 0 Then
                    _clasificacion = value
                Else
                    Throw New Exception("Ingrese la clasificación del item")
                End If
            End If

        End Set
    End Property

    Property Capacidad() As String
        Get
            Return _capacidad
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _capacidad = "N"
            Else
                If value.Trim.Length > 0 Then
                    _capacidad = value
                Else
                    _capacidad = "N"
                End If
            End If

        End Set
    End Property

    Property Presion() As String
        Get
            Return _presion
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _presion = "N"
            Else
                If value.Trim.Length > 0 Then
                    _presion = value
                Else
                    _presion = "N"
                End If
            End If

        End Set
    End Property

    Property Electricidad() As String
        Get
            Return _electricidad
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _electricidad = "N"
            Else
                If value.Trim.Length > 0 Then
                    _electricidad = value
                Else
                    _electricidad = "N"
                End If
            End If

        End Set
    End Property

    Property Transmision() As String
        Get
            Return _transmision
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _transmision = "N"
            Else
                If value.Trim.Length > 0 Then
                    _transmision = value
                Else
                    _transmision = "N"
                End If
            End If

        End Set
    End Property

    Property Rpm() As String
        Get
            Return _rpm
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _rpm = "N"
            Else
                If value.Trim.Length > 0 Then
                    _rpm = value
                Else
                    _rpm = "N"
                End If
            End If

        End Set
    End Property

    Property Marca() As String
        Get
            Return _marca
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _marca = "N"
            Else
                If value.Trim.Length > 0 Then
                    _marca = value
                Else
                    _marca = "N"
                End If
            End If

        End Set
    End Property

    Property Ruido() As String
        Get
            Return _ruido
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _ruido = "N"
            Else
                If value.Trim.Length > 0 Then
                    _ruido = value
                Else
                    _ruido = "N"
                End If
            End If

        End Set
    End Property

    Property Peso() As String
        Get
            Return _peso
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _peso = "N"
            Else
                If value.Trim.Length > 0 Then
                    _peso = value
                Else
                    _peso = "N"
                End If
            End If

        End Set
    End Property

    Property Filtro() As String
        Get
            Return _filtro
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _filtro = "N"
            Else
                If value.Trim.Length > 0 Then
                    _filtro = value
                Else
                    _filtro = "N"
                End If
            End If

        End Set
    End Property

End Class
