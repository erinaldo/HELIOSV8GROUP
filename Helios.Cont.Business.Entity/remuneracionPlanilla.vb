'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated from a template.
'
'     Manual changes to this file may cause unexpected behavior in your application.
'     Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Partial Public Class remuneracionPlanilla
    Public Property idRemuneracionPlanilla As Integer
    Public Property idProyecto As Nullable(Of Integer)
    Public Property codigoSunat As String
    Public Property remOrdinaria As Nullable(Of Decimal)
    Public Property sobretiempo As Nullable(Of Decimal)
    Public Property remDescansoFeriado As Nullable(Of Decimal)
    Public Property remImprecisa As Nullable(Of Decimal)
    Public Property remOtras As Nullable(Of Decimal)
    Public Property totalIngreso As Nullable(Of Decimal)
    Public Property DICtardanza As Nullable(Of Decimal)
    Public Property DICinasistencia As Nullable(Of Decimal)
    Public Property DICremNeta As Nullable(Of Decimal)
    Public Property DISadelanto As Nullable(Of Decimal)
    Public Property DIScuotaSindical As Nullable(Of Decimal)
    Public Property DISdescuentoAutor As Nullable(Of Decimal)
    Public Property DISotrosDeduc As Nullable(Of Decimal)
    Public Property DISotrosNoDeduc As Nullable(Of Decimal)
    Public Property totalDsctoSinInc As Nullable(Of Decimal)
    Public Property aporteObligatorio As Nullable(Of Decimal)
    Public Property primaSeguro As Nullable(Of Decimal)
    Public Property comisPorcentual As Nullable(Of Decimal)
    Public Property aportVoluntaria As Nullable(Of Decimal)
    Public Property conafovicer As Nullable(Of Decimal)
    Public Property contribSolidaria As Nullable(Of Decimal)
    Public Property essaludVida As Nullable(Of Decimal)
    Public Property snp As Nullable(Of Decimal)
    Public Property essaludRegularPens As Nullable(Of Decimal)
    Public Property reten5taCat As Nullable(Of Decimal)
    Public Property totalAportaTrab As Nullable(Of Decimal)
    Public Property sppAportaVolunt As Nullable(Of Decimal)
    Public Property polizaSeguro As Nullable(Of Decimal)
    Public Property essaludSeguroReg As Nullable(Of Decimal)
    Public Property sctrPension As Nullable(Of Decimal)
    Public Property sctrEssalud As Nullable(Of Decimal)
    Public Property Senati As Nullable(Of Decimal)
    Public Property impExtraSolidar As Nullable(Of Decimal)
    Public Property sctrEps As Nullable(Of Decimal)
    Public Property sis As Nullable(Of Decimal)
    Public Property totalAportaEmpleador As Nullable(Of Decimal)
    Public Property netoApagar As Nullable(Of Decimal)

    Public Overridable Property remuneracionPlanillaDetalle As ICollection(Of remuneracionPlanillaDetalle) = New HashSet(Of remuneracionPlanillaDetalle)

End Class
