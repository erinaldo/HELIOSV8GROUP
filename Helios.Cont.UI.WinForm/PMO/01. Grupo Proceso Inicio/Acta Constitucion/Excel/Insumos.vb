Option Strict On
Public Class Insumos
    'Private _clasificacion As String
    'Private _tipoEx As String

    Private _decripcion As String
    Private _extra As String
    Private _unidad As String
    Private _cantidad As String
    Private _costoUnitario As String
    Private _CostoDirecto1 As String
    Private _CostoDirecto2 As String
    Private _ggPorc As String
    Private _ggImporte As String
    Private _utPorc As String
    Private _utImporte As String
    Private _costoFinal As String

    Private _igvPorc As String
    Private _igvImporte As String

    Private _OtrosAportes As String
    Private _PlanillaAporte As String
    Private _OtrosDeduccion As String
    Private _PlanillaDeduccion As String

    Private _precioFinal As String
    Private _cantidadFinal As String
    Private _precioUnitFinal As String
    Private _sustento As String
    Private _clasificacion As String

    Private _laborDiaria As String
    Private _cantHm As String
    Private _porc As String
    Private _dias As String
    Private _costoHm As String
    Private _TipoRecurso As String

    'Property TipoEx() As String
    '    Get
    '        Return _tipoEx
    '    End Get
    '    Set(ByVal value As String)
    '        If IsNothing(value) Then
    '            _tipoEx = "N"
    '        Else
    '            If value.Trim.Length > 0 Then
    '                _tipoEx = value
    '            Else
    '                _tipoEx = "N"
    '            End If
    '        End If
    '    End Set
    'End Property

    'Property Clasificacion() As String
    '    Get
    '        Return _clasificacion
    '    End Get
    '    Set(ByVal value As String)
    '        If IsNothing(value) Then
    '            _clasificacion = "N"
    '        Else
    '            If value.Trim.Length > 0 Then
    '                _clasificacion = value
    '            Else
    '                _clasificacion = "N"
    '            End If
    '        End If
    '    End Set
    'End Property

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

    '---------------------------INFORMACION TECNICA----------------------------------------------
    Property LaborDiaria() As String
        Get
            Return _laborDiaria
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _laborDiaria = "N"
            Else
                If value.Trim.Length > 0 Then
                    _laborDiaria = value
                Else
                    _laborDiaria = "N"
                End If
            End If
        End Set
    End Property

    Property CantHM() As String
        Get
            Return _cantHm
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _cantHm = "N"
            Else
                If value.Trim.Length > 0 Then
                    _cantHm = value
                Else
                    _cantHm = "N"
                End If
            End If
        End Set
    End Property

    Property Porc() As String
        Get
            Return _porc
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _porc = "N"
            Else
                If value.Trim.Length > 0 Then
                    _porc = value
                Else
                    _porc = "N"
                End If
            End If
        End Set
    End Property


    Property Dias() As String
        Get
            Return _dias
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _dias = "N"
            Else
                If value.Trim.Length > 0 Then
                    _dias = value
                Else
                    _dias = "N"
                End If
            End If
        End Set
    End Property

    Property CostoHM() As String
        Get
            Return _costoHm
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _costoHm = "N"
            Else
                If value.Trim.Length > 0 Then
                    _costoHm = value
                Else
                    _costoHm = "N"
                End If
            End If
        End Set
    End Property
    '--------------------------------------------------------------------------------

    Property Cantidad() As String
        Get
            Return _cantidad
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _cantidad = "0"
            Else
                If value.Trim.Length > 0 Then
                    _cantidad = value
                Else
                    _cantidad = "0"
                End If
            End If
        End Set
    End Property

    Property CostoUnitario() As String
        Get
            Return _costoUnitario
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _costoUnitario = "0"
            Else
                If value.Trim.Length > 0 Then
                    _costoUnitario = value
                Else
                    _costoUnitario = "0"
                End If
            End If
        End Set
    End Property

    Property CostoDirecto1() As String
        Get
            Return _CostoDirecto1
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _CostoDirecto1 = "0"
            Else
                If value.Trim.Length > 0 Then
                    _CostoDirecto1 = value
                Else
                    _CostoDirecto1 = "0"
                End If
            End If
        End Set
    End Property

    Property CostoDirecto2() As String
        Get
            Return _CostoDirecto2
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _CostoDirecto2 = "0"
            Else
                If value.Trim.Length > 0 Then
                    _CostoDirecto2 = value
                Else
                    _CostoDirecto2 = "0"
                End If
            End If
        End Set
    End Property

    Property GGPorc() As String
        Get
            Return _ggPorc
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _ggPorc = "0"
            Else
                If value.Trim.Length > 0 Then
                    _ggPorc = value
                Else
                    _ggPorc = "0"
                End If
            End If
        End Set
    End Property

    Property GGImporte() As String
        Get
            Return _ggImporte
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _ggImporte = "0"
            Else
                If value.Trim.Length > 0 Then
                    _ggImporte = value
                Else
                    _ggImporte = "0"
                End If
            End If
        End Set
    End Property

    Property UTPorc() As String
        Get
            Return _utPorc
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _utPorc = "0"
            Else
                If value.Trim.Length > 0 Then
                    _utPorc = value
                Else
                    _utPorc = "0"
                End If
            End If
        End Set
    End Property

    Property UTtImporte() As String
        Get
            Return _utImporte
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _utImporte = "0"
            Else
                If value.Trim.Length > 0 Then
                    _utImporte = value
                Else
                    _utImporte = "0"
                End If
            End If
        End Set
    End Property

    Property CostoFinal() As String
        Get
            Return _costoFinal
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _costoFinal = "0"
            Else
                If value.Trim.Length > 0 Then
                    _costoFinal = value
                Else
                    _costoFinal = "0"
                End If
            End If
        End Set
    End Property

    Property IgvPorc() As String
        Get
            Return _igvPorc
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _igvPorc = "0"
            Else
                If value.Trim.Length > 0 Then
                    _igvPorc = value
                Else
                    _igvPorc = "0"
                End If
            End If
        End Set
    End Property

    Property IgvImporte() As String
        Get
            Return _igvImporte
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _igvImporte = "0"
            Else
                If value.Trim.Length > 0 Then
                    _igvImporte = value
                Else
                    _igvImporte = "0"
                End If
            End If
        End Set
    End Property

    Property OtrosAportes() As String
        Get
            Return _OtrosAportes
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _OtrosAportes = "0"
            Else
                If value.Trim.Length > 0 Then
                    _OtrosAportes = value
                Else
                    _OtrosAportes = "0"
                End If
            End If
        End Set
    End Property

    Property PlanillaAporte() As String
        Get
            Return _PlanillaAporte
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _PlanillaAporte = "0"
            Else
                If value.Trim.Length > 0 Then
                    _PlanillaAporte = value
                Else
                    _PlanillaAporte = "0"
                End If
            End If
        End Set
    End Property

    Property OtrosDeduccion() As String
        Get
            Return _OtrosDeduccion
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _OtrosDeduccion = "0"
            Else
                If value.Trim.Length > 0 Then
                    _OtrosDeduccion = value
                Else
                    _OtrosDeduccion = "0"
                End If
            End If
        End Set
    End Property

    Property PlanillaDeduccion() As String
        Get
            Return _PlanillaDeduccion
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _PlanillaDeduccion = "0"
            Else
                If value.Trim.Length > 0 Then
                    _PlanillaDeduccion = value
                Else
                    _PlanillaDeduccion = "0"
                End If
            End If
        End Set
    End Property

    Property PrecioFinal() As String
        Get
            Return _precioFinal
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _precioFinal = "0"
            Else
                If value.Trim.Length > 0 Then
                    _precioFinal = value
                Else
                    _precioFinal = "0"
                End If
            End If
        End Set
    End Property

    Property CantidadFinal() As String
        Get
            Return _cantidadFinal
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _cantidadFinal = "0"
            Else
                If value.Trim.Length > 0 Then
                    _cantidadFinal = value
                Else
                    _cantidadFinal = "0"
                End If
            End If
        End Set
    End Property

    Property PrecioUnitFinal() As String
        Get
            Return _precioUnitFinal
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _precioUnitFinal = "0"
            Else
                If value.Trim.Length > 0 Then
                    _precioUnitFinal = value
                Else
                    _precioUnitFinal = "0"
                End If
            End If
        End Set
    End Property

    Property Sustento() As String
        Get
            Return _sustento
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _sustento = "N"
            Else
                If value.Trim.Length > 0 Then
                    _sustento = value
                Else
                    _sustento = "N"
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
                _clasificacion = "N"
            Else
                If value.Trim.Length > 0 Then
                    _clasificacion = value
                Else
                    _clasificacion = "N"
                End If
            End If
        End Set
    End Property

    Property TipoRecurso() As String
        Get
            Return _TipoRecurso
        End Get
        Set(ByVal value As String)
            If IsNothing(value) Then
                _TipoRecurso = "N"
            Else
                If value.Trim.Length > 0 Then
                    _TipoRecurso = value
                Else
                    _TipoRecurso = "N"
                End If
            End If
        End Set
    End Property
End Class
