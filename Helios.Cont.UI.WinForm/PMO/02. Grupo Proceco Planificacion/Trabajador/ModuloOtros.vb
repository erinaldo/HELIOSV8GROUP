Module ModuloOtros
    Sub LimpiarCajas(ByVal controls As Control)
        For Each control As Control In controls.Controls
            If TypeOf control Is TextBox Then
                control.Text = ""
                If control.TabIndex = 1 Then
                    control.Focus()
                End If
            ElseIf TypeOf control Is Syncfusion.Windows.Forms.Tools.TextBoxExt Then
                control.Text = ""
                If control.TabIndex = 1 Then
                    control.Focus()
                End If
            ElseIf TypeOf control Is NumericUpDown Then
                control.Text = "0.00"
            ElseIf TypeOf control Is ComboBox Then
                control.Text = ""
            End If
        Next
    End Sub

    Function ValidarCajas(ByVal controls As Control) As Boolean
        For Each control As Control In controls.Controls
            If TypeOf control Is TextBox Then
                If control.Text.Trim.Length > 0 Then

                Else
                    If control.Name = "txtNumCaja" Or _
                        control.Name = "txtProyecto" Or _
                        control.Name = "txtIdProyecto" Or _
                        control.Name = "txtEstrategia" Or _
                        control.Name = "txtIdEstrategia" Then
                    Else


                        Return False
                        Exit Function
                    End If
                    ' control.Focus()
                    ' control.Select()

                End If
            ElseIf TypeOf control Is NumericUpDown Then

                If CDec(control.Text) > 0 Then

                Else
                    If control.Name = "nudInteres" Or control.Name = "nudInteresSoles" Or control.Name = "nudInteresDolares" Then
                    Else
                        ' control.Focus()
                        ' control.Select()
                        Return False
                        Exit Function
                    End If
                End If

            ElseIf TypeOf control Is ComboBox Then
                If control.Text.Trim.Length > 0 Then

                Else
                    If control.Name = "cboProyecto" Or control.Name = "cboEstrategia" Then
                    Else
                        Return False
                        Exit Function
                    End If
                    ' control.Focus()
                    ' control.Select()

                End If
            End If

        Next


        Return True
    End Function
End Module
