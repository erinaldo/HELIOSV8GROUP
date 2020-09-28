
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
'Agregamos las librerias que utilizaremos.
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Runtime.InteropServices

'Esta es la clase para crear el ticket de venta. Crearemos varios métodos aquí.
Public Class CrearTicket
    'Creamos un objeto de la clase StringBuilder, en este objeto agregaremos las lineas del ticket
    Private linea As New StringBuilder()
    'Creamos una variable para almacenar el numero maximo de caracteres que permitiremos en el ticket.
    Private maxCar As Integer = 40, cortar As Integer
    'Para una impresora ticketera que imprime a 40 columnas. La variable cortar cortara el texto cuando rebase el limte.
    'Creamos el primer metodo, este dibujara lineas guion.
    Public Function lineasGuio() As String
        Dim lineasGuion As String = ""
        For i As Integer = 0 To maxCar - 1
            'Agregara un guio hasta llegar la numero maximo de caracteres.
            lineasGuion += "-"
        Next
        Return linea.AppendLine(lineasGuion).ToString()
        'Devolvemos la lineaGuion
    End Function

    'Metodo para dibujar una linea con asteriscos
    Public Function lineasAsteriscos() As String
        Dim lineasAsterisco As String = ""
        For i As Integer = 0 To maxCar - 1
            'Agregara un asterisco hasta llegar la numero maximo de caracteres.
            lineasAsterisco += "*"
        Next
        Return linea.AppendLine(lineasAsterisco).ToString()
        'Devolvemos la linea con asteriscos
    End Function

    Public Function lineasHorizontales() As String
        Dim lineasAsterisco As String = ""
        For i As Integer = 0 To maxCar - 1
            'Agregara un asterisco hasta llegar la numero maximo de caracteres.
            lineasAsterisco += "-"
        Next
        Return linea.AppendLine(lineasAsterisco).ToString()
        'Devolvemos la linea con asteriscos
    End Function

    'Realizamos el mismo procedimiento para dibujar una lineas con el signo igual
    Public Function lineasIgual() As String
        Dim lineasIgual2 As String = ""
        For i As Integer = 0 To maxCar - 1
            'Agregara un igual hasta llegar la numero maximo de caracteres.
            lineasIgual2 += "="
        Next
        Return linea.AppendLine(lineasIgual2).ToString()
        'Devolvemos la lienas con iguales
    End Function

    'Creamos el encabezado para los articulos
    Public Sub EncabezadoVenta()
        'Escribimos los espacios para mostrar el articulo. En total tienen que ser 40 caracteres
        linea.AppendLine("ARTÍCULO            |CANT|PRECIO|IMPORTE")
    End Sub

    Public Sub EncabezadoVentaV2()
        'Escribimos los espacios para mostrar el articulo. En total tienen que ser 40 caracteres
        linea.AppendLine("CANT     |ARTICULO  |PRECIO   |IMPORTE  ")
    End Sub

    Public Sub EncabezadoVentaV3()
        'Escribimos los espacios para mostrar el articulo. En total tienen que ser 40 caracteres
        linea.AppendLine("RESUMEN CIERRE DE CAJA")
    End Sub

    'Creamos un metodo para poner el texto a la izquierda
    Public Sub TextoIzquierda(texto As String)
        'Si la longitud del texto es mayor al numero maximo de caracteres permitidos, realizar el siguiente procedimiento.
        If texto.Length > maxCar Then
            Dim caracterActual As Integer = 0
            'Nos indicara en que caracter se quedo al bajar el texto a la siguiente linea
            Dim longitudTexto As Integer = texto.Length
            While longitudTexto > maxCar
                'Agregamos los fragmentos que salgan del texto
                linea.AppendLine(texto.Substring(caracterActual, maxCar))
                caracterActual += maxCar
                longitudTexto -= maxCar
            End While
            'agregamos el fragmento restante
            linea.AppendLine(texto.Substring(caracterActual, texto.Length - caracterActual))
        Else
            'Si no es mayor solo agregarlo.
            linea.AppendLine(texto)
        End If
    End Sub

    'Creamos un metodo para poner texto a la derecha.
    Public Sub TextoDerecha(texto As String)
        'Si la longitud del texto es mayor al numero maximo de caracteres permitidos, realizar el siguiente procedimiento.
        If texto.Length > maxCar Then
            Dim caracterActual As Integer = 0
            'Nos indicara en que caracter se quedo al bajar el texto a la siguiente linea
            Dim longitudTexto As Integer = texto.Length
            While longitudTexto > maxCar
                'Agregamos los fragmentos que salgan del texto
                linea.AppendLine(texto.Substring(caracterActual, maxCar))
                caracterActual += maxCar
                longitudTexto -= maxCar
            End While
            'Variable para poner espacios restntes
            Dim espacios As String = ""
            'Obtenemos la longitud del texto restante.
            For i As Integer = 0 To (maxCar - texto.Substring(caracterActual, texto.Length - caracterActual).Length) - 1
                'Agrega espacios para alinear a la derecha
                espacios += " "
            Next

            'agregamos el fragmento restante, agregamos antes del texto los espacios
            linea.AppendLine(espacios & texto.Substring(caracterActual, texto.Length - caracterActual))
        Else
            Dim espacios As String = ""
            'Obtenemos la longitud del texto restante.
            For i As Integer = 0 To (maxCar - texto.Length) - 1
                'Agrega espacios para alinear a la derecha
                espacios += " "
            Next
            'Si no es mayor solo agregarlo.
            linea.AppendLine(espacios & texto)
        End If
    End Sub

    'Metodo para centrar el texto
    Public Sub TextoCentro(texto As String)
        If texto.Length > maxCar Then
            Dim caracterActual As Integer = 0
            'Nos indicara en que caracter se quedo al bajar el texto a la siguiente linea
            Dim longitudTexto As Integer = texto.Length
            While longitudTexto > maxCar
                'Agregamos los fragmentos que salgan del texto
                linea.AppendLine(texto.Substring(caracterActual, maxCar))
                caracterActual += maxCar
                longitudTexto -= maxCar
            End While
            'Variable para poner espacios restntes
            Dim espacios As String = ""
            'sacamos la cantidad de espacios libres y el resultado lo dividimos entre dos
            Dim centrar As Integer = (maxCar - texto.Substring(caracterActual, texto.Length - caracterActual).Length) / 2
            'Obtenemos la longitud del texto restante.
            For i As Integer = 0 To centrar - 1
                'Agrega espacios para centrar
                espacios += " "
            Next

            'agregamos el fragmento restante, agregamos antes del texto los espacios
            linea.AppendLine(espacios & texto.Substring(caracterActual, texto.Length - caracterActual))
        Else
            Dim espacios As String = ""
            'sacamos la cantidad de espacios libres y el resultado lo dividimos entre dos
            Dim centrar As Integer = (maxCar - texto.Length) / 2
            'Obtenemos la longitud del texto restante.
            For i As Integer = 0 To centrar - 1
                'Agrega espacios para centrar
                espacios += " "
            Next

            'agregamos el fragmento restante, agregamos antes del texto los espacios

            linea.AppendLine(espacios & texto)
        End If
    End Sub

    'Metodo para poner texto a los extremos
    Public Sub TextoExtremos(textoIzquierdo As String, textoDerecho As String)
        'variables que utilizaremos
        Dim textoIzq As String, textoDer As String, textoCompleto As String = "", espacios As String = ""

        'Si el texto que va a la izquierda es mayor a 18, cortamos el texto.
        If textoIzquierdo.Length > 18 Then
            cortar = textoIzquierdo.Length - 18
            textoIzq = textoIzquierdo.Remove(18, cortar)
        Else
            textoIzq = textoIzquierdo
        End If

        textoCompleto = textoIzq
        'Agregamos el primer texto.
        If textoDerecho.Length > 20 Then
            'Si es mayor a 20 lo cortamos
            cortar = textoDerecho.Length - 20
            textoDer = textoDerecho.Remove(20, cortar)
        Else
            textoDer = textoDerecho
        End If

        'Obtenemos el numero de espacios restantes para poner textoDerecho al final
        Dim nroEspacios As Integer = maxCar - (textoIzq.Length + textoDer.Length)
        For i As Integer = 0 To nroEspacios - 1
            'agrega los espacios para poner textoDerecho al final
            espacios += " "
        Next
        textoCompleto += espacios & textoDerecho
        'Agregamos el segundo texto con los espacios para alinearlo a la derecha.
        linea.AppendLine(textoCompleto)
        'agregamos la linea al ticket, al objeto en si.
    End Sub

    'Metodo para agregar los totales d ela venta
    Public Sub AgregarTotales(texto As String, total As Decimal)
        'Variables que usaremos
        Dim resumen As String, valor As String, textoCompleto As String, espacios As String = ""

        If texto.Length > 25 Then
            'Si es mayor a 25 lo cortamos
            cortar = texto.Length - 25
            resumen = texto.Remove(25, cortar)
        Else
            resumen = texto
        End If

        textoCompleto = resumen
        valor = total.ToString("#,#.00")
        'Agregamos el total previo formateo.
        'Obtenemos el numero de espacios restantes para alinearlos a la derecha
        Dim nroEspacios As Integer = maxCar - (resumen.Length + valor.Length)
        'agregamos los espacios
        For i As Integer = 0 To nroEspacios - 1
            espacios += " "
        Next
        textoCompleto += espacios & valor
        linea.AppendLine(textoCompleto)
    End Sub

    'Metodo para agreagar articulos al ticket de venta
    Public Sub AgregaArticulo(articulo As String, cant As Integer, precio As Decimal, importe As Decimal)
        'Valida que cant precio e importe esten dentro del rango.
        If cant.ToString().Length <= 5 AndAlso precio.ToString().Length <= 7 AndAlso importe.ToString().Length <= 8 Then
            Dim elemento As String = "", espacios As String = ""
            Dim bandera As Boolean = False
            'Indicara si es la primera linea que se escribe cuando bajemos a la segunda si el nombre del articulo no entra en la primera linea
            Dim nroEspacios As Integer = 0

            'Si el nombre o descripcion del articulo es mayor a 20, bajar a la siguiente linea
            If articulo.Length > 20 Then
                'Colocar la cantidad a la derecha.
                nroEspacios = (5 - cant.ToString().Length)
                espacios = ""
                For i As Integer = 0 To nroEspacios - 1
                    'Generamos los espacios necesarios para alinear a la derecha
                    espacios += " "
                Next
                elemento += espacios & cant.ToString()
                'agregamos la cantidad con los espacios
                'Colocar el precio a la derecha.
                nroEspacios = (7 - precio.ToString().Length)
                espacios = ""
                For i As Integer = 0 To nroEspacios - 1
                    'Genera los espacios
                    espacios += " "
                Next
                'el operador += indica que agregar mas cadenas a lo que ya existe.
                elemento += espacios & precio.ToString()
                'Agregamos el precio a la variable elemento
                'Colocar el importe a la derecha.
                nroEspacios = (8 - importe.ToString().Length)
                espacios = ""
                For i As Integer = 0 To nroEspacios - 1
                    espacios += " "
                Next
                elemento += espacios & importe.ToString()
                'Agregamos el importe alineado a la derecha
                Dim caracterActual As Integer = 0
                'Indicara en que caracter se quedo al bajae a la siguiente linea
                'Por cada 20 caracteres se agregara una linea siguiente
                For longitudTexto As Integer = articulo.Length To 21 Step -20
                    If bandera = False Then
                        'si es false o la primera linea en recorrerer, continuar...
                        'agregamos los primeros 20 caracteres del nombre del articulos, mas lo que ya tiene la variable elemento
                        linea.AppendLine(articulo.Substring(caracterActual, 20) & elemento)
                        'cambiamos su valor a verdadero
                        bandera = True
                    Else
                        linea.AppendLine(articulo.Substring(caracterActual, 20))
                    End If
                    'Solo agrega el nombre del articulo
                    'incrementa en 20 el valor de la variable caracterActual
                    caracterActual += 20
                Next
                'Agrega el resto del fragmento del  nombre del articulo

                linea.AppendLine(articulo.Substring(caracterActual, articulo.Length - caracterActual))
            Else
                'Si no es mayor solo agregarlo, sin dar saltos de lineas
                For i As Integer = 0 To (20 - articulo.Length) - 1
                    'Agrega espacios para completar los 20 caracteres
                    espacios += " "
                Next
                elemento = articulo & espacios

                'Colocar la cantidad a la derecha.
                nroEspacios = (5 - cant.ToString().Length)
                ' +(20 - elemento.Length);
                espacios = ""
                For i As Integer = 0 To nroEspacios - 1
                    espacios += " "
                Next
                elemento += espacios & cant.ToString()

                'Colocar el precio a la derecha.
                nroEspacios = (7 - precio.ToString().Length)
                espacios = ""
                For i As Integer = 0 To nroEspacios - 1
                    espacios += " "
                Next
                elemento += espacios & precio.ToString()

                'Colocar el importe a la derecha.
                nroEspacios = (8 - importe.ToString().Length)
                espacios = ""
                For i As Integer = 0 To nroEspacios - 1
                    espacios += " "
                Next
                elemento += espacios & importe.ToString()

                'Agregamos todo el elemento: nombre del articulo, cant, precio, importe.
                linea.AppendLine(elemento)
            End If
        Else
            linea.AppendLine("Los valores ingresados para esta fila")
            linea.AppendLine("superan las columnas soportdas por éste.")
            Throw New Exception("Los valores ingresados para algunas filas del ticket" & vbLf & "superan las columnas soportdas por éste.")
        End If
    End Sub

    Public Sub AgregaArticuloV2(articulo As String, cant As Decimal, precio As Decimal, importe As Decimal)
        'Valida que cant precio e importe esten dentro del rango.
        If cant.ToString().Length <= 9 AndAlso precio.ToString().Length <= 9 AndAlso importe.ToString().Length <= 9 Then
            Dim elemento As String = "", espacios As String = "", elementoCant As String = ""
            Dim bandera As Boolean = False
            'Indicara si es la primera linea que se escribe cuando bajemos a la segunda si el nombre del articulo no entra en la primera linea
            Dim nroEspacios As Integer = 0

            'Si el nombre o descripcion del articulo es mayor a 20, bajar a la siguiente linea
            If articulo.Length > 10 Then
                'Colocar la cantidad a la derecha.
                nroEspacios = (9 - cant.ToString().Length)
                espacios = ""
                For i As Integer = 0 To nroEspacios - 1
                    'Generamos los espacios necesarios para alinear a la derecha
                    espacios += " "
                Next
                elementoCant = cant.ToString() & espacios
                'agregamos la cantidad con los espacios
                'Colocar el precio a la derecha.
                nroEspacios = (9 - precio.ToString().Length)
                espacios = ""
                For i As Integer = 0 To nroEspacios - 1
                    'Genera los espacios
                    espacios += " "
                Next
                'el operador += indica que agregar mas cadenas a lo que ya existe.
                elemento += espacios & precio.ToString()
                'Agregamos el precio a la variable elemento
                'Colocar el importe a la derecha.
                nroEspacios = (10 - importe.ToString().Length)
                espacios = ""
                For i As Integer = 0 To nroEspacios - 1
                    espacios += " "
                Next
                elemento += espacios & importe.ToString()
                'Agregamos el importe alineado a la derecha
                Dim caracterActual As Integer = 0
                'Indicara en que caracter se quedo al bajae a la siguiente linea
                'Por cada 20 caracteres se agregara una linea siguiente
                For longitudTexto As Integer = articulo.Length To 11 Step -10
                    If bandera = False Then
                        'si es false o la primera linea en recorrerer, continuar...
                        'agregamos los primeros 20 caracteres del nombre del articulos, mas lo que ya tiene la variable elemento
                        linea.AppendLine(elementoCant & articulo.Substring(caracterActual, 11) & Space(1) & elemento)
                        'cambiamos su valor a verdadero
                        bandera = True
                    Else
                        linea.AppendLine(Space(9) & articulo.Substring(caracterActual, 11))
                    End If
                    'Solo agrega el nombre del articulo
                    'incrementa en 20 el valor de la variable caracterActual
                    caracterActual += 10
                Next
                'Agrega el resto del fragmento del  nombre del articulo

                linea.AppendLine(Space(9) & articulo.Substring(caracterActual, articulo.Length - caracterActual))
            Else

                'Colocar la cantidad a la derecha.
                nroEspacios = (9 - cant.ToString().Length)
                ' +(20 - elemento.Length);
                espacios = ""
                For i As Integer = 0 To nroEspacios - 1
                    espacios += " "
                Next
                elemento = cant.ToString() & espacios

                'Si no es mayor solo agregarlo, sin dar saltos de lineas
                Dim n = (12 - articulo.Length) ' - 3
                n = n - 1
                espacios = ""
                For i As Integer = 0 To n '(20 - articulo.Length) - 3
                    'Agrega espacios para completar los 20 caracteres
                    espacios += " "
                Next
                elemento += articulo & espacios


                'Colocar el precio a la derecha.
                nroEspacios = (9 - precio.ToString().Length)
                espacios = ""
                For i As Integer = 0 To nroEspacios - 1
                    espacios += " "
                Next
                elemento += espacios & precio.ToString()

                'Colocar el importe a la derecha.
                nroEspacios = (10 - importe.ToString().Length)
                espacios = ""
                For i As Integer = 0 To nroEspacios - 1
                    espacios += " "
                Next
                elemento += espacios & importe.ToString()

                'Agregamos todo el elemento: nombre del articulo, cant, precio, importe.
                linea.AppendLine(elemento)
            End If
        Else
            linea.AppendLine("Los valores ingresados para esta fila")
            linea.AppendLine("superan las columnas soportdas por éste.")
            Throw New Exception("Los valores ingresados para algunas filas del ticket" & vbLf & "superan las columnas soportdas por éste.")
        End If
    End Sub

    'Metodos para enviar secuencias de escape a la impresora
    'Para cortar el ticket
    Public Sub CortaTicket()

        linea.AppendLine(ChrW(27) + "d" + vbTab)
        ' linea.AppendLine(ChrW(27) + "d" + ChrW(5))
        'Avanza 9 renglones, Tambien varian
        linea.AppendLine(ChrW(27) + "m")
        'Caracteres de corte. Estos comando varian segun el tipo de impresora
        '     linea.AppendLine(ChrW(27) + "d" + ChrW(3))
        'Avanza 9 renglones, Tambien varian
    End Sub
    'Para abrir el cajon
    Public Sub AbreCajon()
        'Estos tambien varian, tienen que ever el manual de la impresora para poner los correctos.
        'linea.AppendLine(ChrW(27) + "p" + vbNullChar + ChrW(15) + ChrW(150))
        linea.AppendLine(ChrW(27) + ChrW(112) + ChrW(48) + ChrW(55) + ChrW(121))
        'Caracteres de apertura cajon 0
        'linea.AppendLine("\x1B" + "p" + "\x01" + "\x0F" + "\x96"); //Caracteres de apertura cajon 1
    End Sub
    'Para mandara a imprimir el texto a la impresora que le indiquemos.
    Public Sub ImprimirTicket(impresora As String)
        'Este metodo recibe el nombre de la impresora a la cual se mandara a imprimir y el texto que se imprimira.
        'Usaremos un código que nos proporciona Microsoft. https://support.microsoft.com/es-es/kb/322091

        RawPrinterHelper.SendStringToPrinter(impresora, linea.ToString())
        'Imprime texto.
        linea.Clear()
        'Al cabar de imprimir limpia la linea de todo el texto agregado.
    End Sub
End Class


'Clase para mandara a imprimir texto plano a la impresora
Public Class RawPrinterHelper
    ' Structure and API declarions:
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> _
    Public Class DOCINFOA
        <MarshalAs(UnmanagedType.LPStr)> _
        Public pDocName As String
        <MarshalAs(UnmanagedType.LPStr)> _
        Public pOutputFile As String
        <MarshalAs(UnmanagedType.LPStr)> _
        Public pDataType As String
    End Class
    <DllImport("winspool.Drv", EntryPoint:="OpenPrinterA", SetLastError:=True, CharSet:=CharSet.Ansi, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function OpenPrinter(<MarshalAs(UnmanagedType.LPStr)> szPrinter As String, ByRef hPrinter As IntPtr, pd As IntPtr) As Boolean
    End Function

    <DllImport("winspool.Drv", EntryPoint:="ClosePrinter", SetLastError:=True, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function ClosePrinter(hPrinter As IntPtr) As Boolean
    End Function

    <DllImport("winspool.Drv", EntryPoint:="StartDocPrinterA", SetLastError:=True, CharSet:=CharSet.Ansi, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function StartDocPrinter(hPrinter As IntPtr, level As Int32, <[In], MarshalAs(UnmanagedType.LPStruct)> di As DOCINFOA) As Boolean
    End Function

    <DllImport("winspool.Drv", EntryPoint:="EndDocPrinter", SetLastError:=True, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function EndDocPrinter(hPrinter As IntPtr) As Boolean
    End Function

    <DllImport("winspool.Drv", EntryPoint:="StartPagePrinter", SetLastError:=True, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function StartPagePrinter(hPrinter As IntPtr) As Boolean
    End Function

    <DllImport("winspool.Drv", EntryPoint:="EndPagePrinter", SetLastError:=True, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function EndPagePrinter(hPrinter As IntPtr) As Boolean
    End Function

    <DllImport("winspool.Drv", EntryPoint:="WritePrinter", SetLastError:=True, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
    Public Shared Function WritePrinter(hPrinter As IntPtr, pBytes As IntPtr, dwCount As Int32, ByRef dwWritten As Int32) As Boolean
    End Function

    ' SendBytesToPrinter()
    ' When the function is given a printer name and an unmanaged array
    ' of bytes, the function sends those bytes to the print queue.
    ' Returns true on success, false on failure.
    Public Shared Function SendBytesToPrinter(szPrinterName As String, pBytes As IntPtr, dwCount As Int32) As Boolean
        Dim dwError As Int32 = 0, dwWritten As Int32 = 0
        Dim hPrinter As New IntPtr(0)
        Dim di As New DOCINFOA()
        Dim bSuccess As Boolean = False
        ' Assume failure unless you specifically succeed.
        di.pDocName = "Ticket de Venta"
        'Este es el nombre con el que guarda el archivo en caso de no imprimir a la impresora fisica.
        di.pDataType = "RAW"
        'de tipo texto plano
        ' Open the printer.
        If OpenPrinter(szPrinterName.Normalize(), hPrinter, IntPtr.Zero) Then
            ' Start a document.
            If StartDocPrinter(hPrinter, 1, di) Then
                ' Start a page.
                If StartPagePrinter(hPrinter) Then
                    ' Write your bytes.
                    bSuccess = WritePrinter(hPrinter, pBytes, dwCount, dwWritten)
                    EndPagePrinter(hPrinter)
                End If
                EndDocPrinter(hPrinter)
            End If
            ClosePrinter(hPrinter)
        End If
        ' If you did not succeed, GetLastError may give more information
        ' about why not.
        If bSuccess = False Then
            dwError = Marshal.GetLastWin32Error()
        End If
        Return bSuccess
    End Function

    Public Shared Function SendStringToPrinter(szPrinterName As String, szString As String) As Boolean
        Dim pBytes As IntPtr
        Dim dwCount As Int32
        ' How many characters are in the string?
        dwCount = szString.Length
        ' Assume that the printer is expecting ANSI text, and then convert
        ' the string to ANSI text.
        pBytes = Marshal.StringToCoTaskMemAnsi(szString)
        ' Send the converted ANSI string to the printer.
        SendBytesToPrinter(szPrinterName, pBytes, dwCount)
        Marshal.FreeCoTaskMem(pBytes)
        Return True
    End Function
End Class
'

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
