<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTabbBusqueda
    Inherits WeifenLuo.WinFormsUI.Docking.DockContent

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.QGlobalColorSchemeManager1 = New Qios.DevSuite.Components.QGlobalColorSchemeManager(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboBuscar = New Qios.DevSuite.Components.QComboBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.QTabControl1 = New Qios.DevSuite.Components.QTabControl()
        Me.QTabPage1 = New Qios.DevSuite.Components.QTabPage()
        Me.QTabPage2 = New Qios.DevSuite.Components.QTabPage()
        Me.QTabPage3 = New Qios.DevSuite.Components.QTabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnConsulta = New Qios.DevSuite.Components.QButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.QTextBox1 = New Qios.DevSuite.Components.QTextBox()
        Me.QTextBox2 = New Qios.DevSuite.Components.QTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.QButton1 = New Qios.DevSuite.Components.QButton()
        Me.txtBusqueda = New Qios.DevSuite.Components.Ribbon.QRibbonInputBox()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.QTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.QTabControl1.SuspendLayout()
        Me.QTabPage1.SuspendLayout()
        Me.QTabPage2.SuspendLayout()
        Me.QTabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'QGlobalColorSchemeManager1
        '
        Me.QGlobalColorSchemeManager1.Global.CurrentTheme = "LunaBlue"
        Me.QGlobalColorSchemeManager1.Global.InheritCurrentThemeFromWindows = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(329, 129)
        Me.Panel1.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboBuscar)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(11, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(254, 54)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Buscar Por:"
        '
        'cboBuscar
        '
        Me.cboBuscar.Items.AddRange(New Object() {"Rango de fecha", "Nro. de comprobante", "Entidad"})
        Me.cboBuscar.Location = New System.Drawing.Point(6, 23)
        Me.cboBuscar.Name = "cboBuscar"
        Me.cboBuscar.Size = New System.Drawing.Size(236, 19)
        Me.cboBuscar.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.QTabControl1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 129)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(329, 255)
        Me.Panel2.TabIndex = 4
        '
        'QTabControl1
        '
        Me.QTabControl1.ActiveTabPage = Me.QTabPage1
        Me.QTabControl1.ColorScheme.TabControlBorder.SetColor("LunaBlue", System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer)), False)
        Me.QTabControl1.Controls.Add(Me.QTabPage1)
        Me.QTabControl1.Controls.Add(Me.QTabPage2)
        Me.QTabControl1.Controls.Add(Me.QTabPage3)
        Me.QTabControl1.Cursor = System.Windows.Forms.Cursors.Default
        Me.QTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.QTabControl1.FontScope = Qios.DevSuite.Components.QFontScope.Local
        Me.QTabControl1.LocalFont = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.QTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.QTabControl1.Name = "QTabControl1"
        Me.QTabControl1.PersistGuid = New System.Guid("fd93b9de-7276-4911-920f-80c6f3c6e653")
        Me.QTabControl1.Size = New System.Drawing.Size(329, 255)
        Me.QTabControl1.TabIndex = 1
        Me.QTabControl1.Text = "QTabControl1"
        '
        'QTabPage1
        '
        Me.QTabPage1.ButtonOrder = 0
        Me.QTabPage1.Controls.Add(Me.btnConsulta)
        Me.QTabPage1.Controls.Add(Me.DateTimePicker2)
        Me.QTabPage1.Controls.Add(Me.Label2)
        Me.QTabPage1.Controls.Add(Me.DateTimePicker1)
        Me.QTabPage1.Controls.Add(Me.Label1)
        Me.QTabPage1.FontScope = Qios.DevSuite.Components.QFontScope.Local
        Me.QTabPage1.LocalFont = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.QTabPage1.Location = New System.Drawing.Point(0, 27)
        Me.QTabPage1.Name = "QTabPage1"
        Me.QTabPage1.PersistGuid = New System.Guid("c9191512-ff8f-484a-bf7a-2eb1d8e3e954")
        Me.QTabPage1.Size = New System.Drawing.Size(327, 226)
        Me.QTabPage1.Text = "Rango de Fecha"
        '
        'QTabPage2
        '
        Me.QTabPage2.ButtonOrder = 1
        Me.QTabPage2.Controls.Add(Me.QButton1)
        Me.QTabPage2.Controls.Add(Me.QTextBox2)
        Me.QTabPage2.Controls.Add(Me.Label4)
        Me.QTabPage2.Controls.Add(Me.QTextBox1)
        Me.QTabPage2.Controls.Add(Me.Label3)
        Me.QTabPage2.FontScope = Qios.DevSuite.Components.QFontScope.Local
        Me.QTabPage2.LocalFont = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.QTabPage2.Location = New System.Drawing.Point(0, 27)
        Me.QTabPage2.Name = "QTabPage2"
        Me.QTabPage2.PersistGuid = New System.Guid("1fe744eb-df13-4dca-8577-9c7e6b2b837b")
        Me.QTabPage2.Size = New System.Drawing.Size(327, 226)
        Me.QTabPage2.Text = "Nro. de comprobante"
        '
        'QTabPage3
        '
        Me.QTabPage3.ButtonOrder = 2
        Me.QTabPage3.Controls.Add(Me.txtBusqueda)
        Me.QTabPage3.Location = New System.Drawing.Point(0, 27)
        Me.QTabPage3.Name = "QTabPage3"
        Me.QTabPage3.PersistGuid = New System.Guid("865a3762-807c-443a-971b-1865b0d099ef")
        Me.QTabPage3.Size = New System.Drawing.Size(327, 226)
        Me.QTabPage3.Text = "Por entidad"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(13, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fecha Inicio:"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(16, 46)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(154, 20)
        Me.DateTimePicker1.TabIndex = 1
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(16, 95)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(154, 20)
        Me.DateTimePicker2.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(13, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Fecha límite:"
        '
        'btnConsulta
        '
        Me.btnConsulta.FontScope = Qios.DevSuite.Components.QFontScope.Local
        Me.btnConsulta.Image = Nothing
        Me.btnConsulta.LocalFont = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConsulta.Location = New System.Drawing.Point(16, 132)
        Me.btnConsulta.Name = "btnConsulta"
        Me.btnConsulta.Size = New System.Drawing.Size(75, 23)
        Me.btnConsulta.TabIndex = 4
        Me.btnConsulta.Text = "Consultar"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(24, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Serie:"
        '
        'QTextBox1
        '
        Me.QTextBox1.Location = New System.Drawing.Point(27, 36)
        Me.QTextBox1.Name = "QTextBox1"
        Me.QTextBox1.Size = New System.Drawing.Size(162, 19)
        Me.QTextBox1.TabIndex = 2
        '
        'QTextBox2
        '
        Me.QTextBox2.Location = New System.Drawing.Point(27, 83)
        Me.QTextBox2.Name = "QTextBox2"
        Me.QTextBox2.Size = New System.Drawing.Size(162, 19)
        Me.QTextBox2.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(24, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Número:"
        '
        'QButton1
        '
        Me.QButton1.FontScope = Qios.DevSuite.Components.QFontScope.Local
        Me.QButton1.Image = Nothing
        Me.QButton1.LocalFont = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.QButton1.Location = New System.Drawing.Point(27, 126)
        Me.QButton1.Name = "QButton1"
        Me.QButton1.Size = New System.Drawing.Size(75, 23)
        Me.QButton1.TabIndex = 5
        Me.QButton1.Text = "Consultar"
        '
        'txtBusqueda
        '
        Me.txtBusqueda.Location = New System.Drawing.Point(10, 37)
        Me.txtBusqueda.Name = "txtBusqueda"
        Me.txtBusqueda.Size = New System.Drawing.Size(275, 21)
        Me.txtBusqueda.TabIndex = 0
        '
        'frmTabbBusqueda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(329, 384)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmTabbBusqueda"
        Me.Text = "Consultas"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.QTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.QTabControl1.ResumeLayout(False)
        Me.QTabPage1.ResumeLayout(False)
        Me.QTabPage1.PerformLayout()
        Me.QTabPage2.ResumeLayout(False)
        Me.QTabPage2.PerformLayout()
        Me.QTabPage3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents QGlobalColorSchemeManager1 As Qios.DevSuite.Components.QGlobalColorSchemeManager
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboBuscar As Qios.DevSuite.Components.QComboBox
    Friend WithEvents QTabControl1 As Qios.DevSuite.Components.QTabControl
    Friend WithEvents QTabPage1 As Qios.DevSuite.Components.QTabPage
    Friend WithEvents btnConsulta As Qios.DevSuite.Components.QButton
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents QTabPage2 As Qios.DevSuite.Components.QTabPage
    Friend WithEvents QTabPage3 As Qios.DevSuite.Components.QTabPage
    Friend WithEvents QButton1 As Qios.DevSuite.Components.QButton
    Friend WithEvents QTextBox2 As Qios.DevSuite.Components.QTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents QTextBox1 As Qios.DevSuite.Components.QTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtBusqueda As Qios.DevSuite.Components.Ribbon.QRibbonInputBox
End Class
