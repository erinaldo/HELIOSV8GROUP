Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Runtime.InteropServices
Imports System.Text
Imports Syncfusion.Collections
Imports Syncfusion.Collections.BinaryTree
Imports Syncfusion.Diagnostics
Imports Syncfusion.Grouping
Imports ISummary = Syncfusion.Collections.BinaryTree.ITreeTableSummary
Public NotInheritable Class TotalSummary
    Inherits SummaryBase

    Private _total As Double
    Public Shared ReadOnly Empty As TotalSummary = New TotalSummary(0)

    Public Shared Function CreateSummaryMethod(ByVal sd As SummaryDescriptor, ByVal record As Record) As ISummary
        Dim obj As Object = sd.GetValue(record)
        Dim isNull As Boolean = (obj Is Nothing OrElse TypeOf obj Is DBNull)

        If isNull Then
            Return Empty
        Else
            Dim val As Double = Convert.ToDouble(obj)
            Return New TotalSummary(val)
        End If
    End Function

    Public Sub New(ByVal total As Double)
        _total = total
    End Sub

    Public ReadOnly Property Total As Double
        Get
            Return _total
        End Get
    End Property

    Public Overrides Function Combine(ByVal other As SummaryBase) As SummaryBase
        Return Combines(CType(other, TotalSummary))
    End Function

    Public Function Combines(ByVal other As TotalSummary) As TotalSummary
        If other.Total = 0 Then
            Return Me
        ElseIf Total = 0 Then
            Return other
        Else
            Return New TotalSummary(Me.Total + other.Total)
        End If
    End Function


    Public Overrides Function ToString() As String
        Return String.Format("Total = {0:0.00}", Total)
    End Function

End Class

Public Class StatisticsSummary
    Inherits SummaryBase

    Private _values As Double()
    Private _length As Integer
    Public Shared ReadOnly Empty As StatisticsSummary = New StatisticsSummary(New Double(-1) {}, 0)

    Public Shared Function CreateSummaryMethod(ByVal sd As SummaryDescriptor, ByVal record As Record) As ISummary
        Dim obj As Object = sd.GetValue(record)
        Dim isNull As Boolean = (obj Is Nothing OrElse TypeOf obj Is DBNull) OrElse (TypeOf obj Is Double) AndAlso Double.IsNaN(CDbl(obj))

        If isNull Then
            Return New StatisticsSummary(New Double(-1) {}, 0)
        Else
            Dim val As Double = Convert.ToDouble(obj)
            Return New StatisticsSummary(New Double() {val}, 1)
        End If
    End Function

    Public Sub New(ByVal values As Double(), ByVal length As Integer)
        _values = values
        _length = length
    End Sub

    Public ReadOnly Property Count As Integer
        Get
            If _values Is Nothing Then Return 0
            Return _length
        End Get
    End Property

    Public ReadOnly Property Values As Double()
        Get
            Return _values
        End Get
    End Property

    Public Overrides Function Combine(ByVal other As SummaryBase) As SummaryBase
        Return Combines(CType(other, StatisticsSummary))
    End Function

    Private Function _Compare(ByVal x As Double, ByVal y As Double) As Integer
        Dim cmp As Integer
        Dim xIsNull As Boolean = Double.IsNaN(x)
        Dim yIsNull As Boolean = Double.IsNaN(y)

        If yIsNull AndAlso xIsNull Then
            cmp = 0
        ElseIf xIsNull Then
            cmp = -1
        ElseIf yIsNull Then
            cmp = 1
        ElseIf y = x Then
            cmp = 0
        ElseIf y > x Then
            cmp = 1
        Else
            cmp = -1
        End If

        Return cmp
    End Function

    Public Function Combines(ByVal other As StatisticsSummary) As StatisticsSummary
        Dim length As Integer
        Dim d As Double() = CombineHelper(other, False, length)

        If length = Me.Count Then
            Return Me
        ElseIf length = other.Count Then
            Return other
        Else
            Return New StatisticsSummary(d, length)
        End If
    End Function

    Protected Function CombineHelper(ByVal other As StatisticsSummary, ByVal distinct As Boolean, <Out> ByRef length As Integer) As Double()
        Dim d As Double() = New Double((Count + other.Count) - 1) {}
        Dim others As Double() = other.Values
        Dim n1 As Integer = 0
        Dim n2 As Integer = 0
        Dim len1 As Integer = Count
        Dim len2 As Integer = other.Count
        Dim n3 As Integer = 0

        While n1 < len1 AndAlso n2 < len2
            Dim cmp As Integer = _Compare(_values(n1), others(n2))

            If cmp > 0 Then
                d(n3) = (_values(Math.Min(System.Threading.Interlocked.Increment(n1), n1 - 1)))
            ElseIf cmp < 0 Then
                d(n3) = (others(Math.Min(System.Threading.Interlocked.Increment(n2), n2 - 1)))
            Else
                d(n3) = (_values(Math.Min(System.Threading.Interlocked.Increment(n1), n1 - 1)))
                If distinct Then n2 += 1
            End If

            n3 += 1
        End While

        While n1 < len1
            d(Math.Min(System.Threading.Interlocked.Increment(n3), n3 - 1)) = (_values(Math.Min(System.Threading.Interlocked.Increment(n1), n1 - 1)))
        End While

        While n2 < len2
            d(Math.Min(System.Threading.Interlocked.Increment(n3), n3 - 1)) = (others(Math.Min(System.Threading.Interlocked.Increment(n2), n2 - 1)))
        End While

        length = n3
        Return d
    End Function

    Private Function GetPercentile(ByVal p As Double) As Double
        If p < 0 OrElse p > 1 Then Throw New ArgumentOutOfRangeException("Percentile out-of-range.")
        Dim s As Double() = _values
        Dim t As Double = p * (_length - 1)
        Dim i As Integer = CInt(t)
        Return (i + 1 - t) * s(i) + (t - i) * s(i + 1)
    End Function

    Public ReadOnly Property Median As Double
        Get
            If _length < 2 Then Return Double.NaN
            Return GetPercentile(0.5)
        End Get
    End Property

    Public ReadOnly Property Percentile25 As Double
        Get
            If _length < 2 Then Return Double.NaN
            Return GetPercentile(0.25)
        End Get
    End Property

    Public ReadOnly Property Percentile75 As Double
        Get
            If _length < 2 Then Return Double.NaN
            Return GetPercentile(0.75)
        End Get
    End Property

    Public ReadOnly Property PercentileQ As Double
        Get
            If _length < 2 Then Return Double.NaN
            Return Percentile75 - Percentile25
        End Get
    End Property

    Public Overrides Function ToString() As String
        Dim sb As StringBuilder = New StringBuilder()
        sb.Append(String.Concat("Count = " & Me.Count.ToString(), ", Values = { "))

        For n As Integer = 0 To Math.Min(5, Count) - 1
            If n > 0 Then sb.Append(", ")
            sb.Append(If(Double.IsNaN(_values(n)), "null", _values(n).ToString("G")))
        Next

        If Count >= 5 Then sb.Append(", ...")
        sb.Append(" }")

        If Count > 1 Then
            sb.AppendFormat(", Med={0}", Me.Median)
            sb.AppendFormat(", P25={0}", Me.Percentile25)
            sb.AppendFormat(", P75={0}", Me.Percentile75)
            sb.AppendFormat(", PQ={0}", Me.PercentileQ)
        End If

        Return sb.ToString()
    End Function
End Class

Public NotInheritable Class DistinctInt32CountSummary
    Inherits SummaryBase

    Private _values As Int32()
    Public Shared ReadOnly Empty As DistinctInt32CountSummary = New DistinctInt32CountSummary(New Int32(-1) {})

    Public Shared Function CreateSummaryMethod(ByVal sd As SummaryDescriptor, ByVal record As Record) As ISummary
        Dim obj As Object = sd.GetValue(record)
        Dim isNull As Boolean = (obj Is Nothing OrElse TypeOf obj Is DBNull)

        If isNull Then
            Return New DistinctInt32CountSummary(New Int32(-1) {})
        Else
            Dim val As Int32 = Convert.ToInt32(obj)
            Return New DistinctInt32CountSummary(New Int32() {val})
        End If
    End Function

    Public Sub New(ByVal values As Int32())
        _values = values
    End Sub

    Public ReadOnly Property Count As Integer
        Get
            If _values Is Nothing Then Return 0
            Return _values.Length
        End Get
    End Property

    Public ReadOnly Property Values As Int32()
        Get
            Return _values
        End Get
    End Property

    Public Overrides Function Combine(ByVal other As SummaryBase) As SummaryBase
        Return Combines(CType(other, DistinctInt32CountSummary))
    End Function

    Private Function _Compare(ByVal x As Object, ByVal y As Object) As Integer
        Dim cmp As Integer
        Dim xIsNull As Boolean = (x Is Nothing OrElse TypeOf x Is DBNull)
        Dim yIsNull As Boolean = (y Is Nothing OrElse TypeOf y Is DBNull)

        If yIsNull AndAlso xIsNull Then
            cmp = 0
        ElseIf xIsNull Then
            cmp = -1
        ElseIf yIsNull Then
            cmp = 1
        Else
            cmp = (CType(x, IComparable)).CompareTo(y)
        End If

        Return cmp
    End Function

    Public Function Combines(ByVal other As DistinctInt32CountSummary) As DistinctInt32CountSummary
        Dim d As ArrayList = New ArrayList(Count + other.Count)
        Dim others As Int32() = other.Values
        Dim n1 As Integer = 0
        Dim n2 As Integer = 0
        Dim len1 As Integer = _values.Length
        Dim len2 As Integer = others.Length

        While n1 < len1 AndAlso n2 < len2
            Dim cmp As Integer = _Compare(_values(n1), others(n2))

            If cmp < 0 Then
                d.Add(_values(Math.Min(System.Threading.Interlocked.Increment(n1), n1 - 1)))
            ElseIf cmp > 0 Then
                d.Add(others(Math.Min(System.Threading.Interlocked.Increment(n2), n2 - 1)))
            Else
                d.Add(_values(Math.Min(System.Threading.Interlocked.Increment(n1), n1 - 1)))
                n2 += 1
            End If
        End While

        While n1 < len1
            d.Add(_values(Math.Min(System.Threading.Interlocked.Increment(n1), n1 - 1)))
        End While

        While n2 < len2
            d.Add(others(Math.Min(System.Threading.Interlocked.Increment(n2), n2 - 1)))
        End While

        Return New DistinctInt32CountSummary(CType(d.ToArray(GetType(Int32)), Int32()))
    End Function

    Public Overrides Function ToString() As String
        Dim sb As StringBuilder = New StringBuilder()
        sb.Append(String.Concat("Count = " & Me.Count.ToString(), ", Values = {"))

        For n As Integer = 0 To Math.Min(10, Count) - 1
            If n > 0 Then sb.Append(", ")
            sb.Append(Values(n).ToString())
        Next

        If Count >= 10 Then sb.Append(", ...")
        sb.Append("}")
        Return sb.ToString()
    End Function
End Class
