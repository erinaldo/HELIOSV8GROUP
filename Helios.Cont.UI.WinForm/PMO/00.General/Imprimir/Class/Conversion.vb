Public Class Conversion
    Private Const Millon As Integer = 1000000
    Private Const Billon As Long = 1000000000000

    Public Shared Function Enletras(ByVal num As Decimal) As String
        Dim entero = Convert.ToInt64(Math.Truncate(num))
        Dim decimales = Convert.ToInt32(Math.Round((num - entero) * 100, 2))
        Dim dec = If(decimales > 0, $" CON {decimales}/100", " CON 00/100")
        Dim res = ToText(entero) & dec
        Return res
    End Function

    Private Shared Function ToText(ByVal value As Decimal) As String
        Dim num2Text As String
        value = Math.Truncate(value)

        If value = 0 Then
            num2Text = "CERO"
        ElseIf value = 1 Then
            num2Text = "UNO"
        ElseIf value = 2 Then
            num2Text = "DOS"
        ElseIf value = 3 Then
            num2Text = "TRES"
        ElseIf value = 4 Then
            num2Text = "CUATRO"
        ElseIf value = 5 Then
            num2Text = "CINCO"
        ElseIf value = 6 Then
            num2Text = "SEIS"
        ElseIf value = 7 Then
            num2Text = "SIETE"
        ElseIf value = 8 Then
            num2Text = "OCHO"
        ElseIf value = 9 Then
            num2Text = "NUEVE"
        ElseIf value = 10 Then
            num2Text = "DIEZ"
        ElseIf value = 11 Then
            num2Text = "ONCE"
        ElseIf value = 12 Then
            num2Text = "DOCE"
        ElseIf value = 13 Then
            num2Text = "TRECE"
        ElseIf value = 14 Then
            num2Text = "CATORCE"
        ElseIf value = 15 Then
            num2Text = "QUINCE"
        ElseIf value < 20 Then
            num2Text = $"DIECI{ToText(value - 10)}"
        ElseIf value = 20 Then
            num2Text = "VEINTE"
        ElseIf value < 30 Then
            num2Text = $"VEINTI{ToText(value - 20)}"
        ElseIf value = 30 Then
            num2Text = "TREINTA"
        ElseIf value = 40 Then
            num2Text = "CUARENTA"
        ElseIf value = 50 Then
            num2Text = "CINCUENTA"
        ElseIf value = 60 Then
            num2Text = "SESENTA"
        ElseIf value = 70 Then
            num2Text = "SETENTA"
        ElseIf value = 80 Then
            num2Text = "OCHENTA"
        ElseIf value = 90 Then
            num2Text = "NOVENTA"
        ElseIf value < 100 Then
            num2Text = $"{ToText(Math.Truncate(value / 10) * 10)} Y {ToText(value Mod 10)}"
        ElseIf value = 100 Then
            num2Text = "CIEN"
        ElseIf value < 200 Then
            num2Text = $"CIENTO {ToText(value - 100)}"
        ElseIf (value = 200) OrElse (value = 300) OrElse (value = 400) OrElse (value = 600) OrElse (value = 800) Then
            num2Text = $"{ToText(Math.Truncate(value / 100))}CIENTOS"
        ElseIf value = 500 Then
            num2Text = "QUINIENTOS"
        ElseIf value = 700 Then
            num2Text = "SETECIENTOS"
        ElseIf value = 900 Then
            num2Text = "NOVECIENTOS"
        ElseIf value < 1000 Then
            num2Text = $"{ToText(Math.Truncate(value / 100) * 100)} {ToText(value Mod 100)}"
        ElseIf value = 1000 Then
            num2Text = "MIL"
        ElseIf value < 2000 Then
            num2Text = $"MIL {ToText(value Mod 1000)}"
        ElseIf value < Millon Then
            num2Text = $"{ToText(Math.Truncate(value / 1000))} MIL"
            If (value Mod 1000) > 0 Then num2Text = $"{num2Text} {ToText(value Mod 1000)}"
        ElseIf value = Millon Then
            num2Text = "UN MILLON"
        ElseIf value < 2000000 Then
            num2Text = $"UN MILLON {ToText(value Mod Millon)}"
        ElseIf value < Billon Then
            num2Text = $"{ToText(Math.Truncate(value / Millon))} MILLONES "
            If (value - Math.Truncate(value / Millon) * Millon) > 0 Then num2Text = $"{num2Text} {ToText(value - Math.Truncate(value / Millon) * Millon)}"
        ElseIf value = Billon Then
            num2Text = "UN BILLON"
        ElseIf value < 2000000000000 Then
            num2Text = $"UN BILLON {ToText(value - Math.Truncate(value / Billon) * Billon)}"
        Else
            num2Text = $"{ToText(Math.Truncate(value / Billon))} BILLONES"
            If (value - Math.Truncate(value / Billon) * Billon) > 0 Then num2Text = $"{num2Text} {ToText(value - Math.Truncate(value / Billon) * Billon)}"
        End If

        Return num2Text
    End Function
End Class
