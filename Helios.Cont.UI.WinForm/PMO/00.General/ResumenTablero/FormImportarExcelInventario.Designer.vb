Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormImportarExcelInventario
    Inherits MetroForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormImportarExcelInventario))
        Me.pictureBox3 = New System.Windows.Forms.PictureBox()
        Me.button2 = New System.Windows.Forms.Button()
        Me.button1 = New System.Windows.Forms.Button()
        Me.label2 = New System.Windows.Forms.Label()
        Me.dataGrid1 = New System.Windows.Forms.DataGrid()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.cboAlmacen = New Syncfusion.Windows.Forms.Tools.ComboBoxAdv()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        CType(Me.pictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pictureBox3
        '
        Me.pictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.pictureBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.pictureBox3.Image = CType(resources.GetObject("pictureBox3.Image"), System.Drawing.Image)
        Me.pictureBox3.Location = New System.Drawing.Point(0, 0)
        Me.pictureBox3.Name = "pictureBox3"
        Me.pictureBox3.Size = New System.Drawing.Size(1039, 71)
        Me.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pictureBox3.TabIndex = 18
        Me.pictureBox3.TabStop = False
        '
        'button2
        '
        Me.button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(145, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.button2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.button2.ForeColor = System.Drawing.Color.White
        Me.button2.Location = New System.Drawing.Point(178, 103)
        Me.button2.Name = "button2"
        Me.button2.Size = New System.Drawing.Size(138, 26)
        Me.button2.TabIndex = 21
        Me.button2.Text = "Grabar productos"
        Me.button2.UseVisualStyleBackColor = False
        '
        'button1
        '
        Me.button1.BackColor = System.Drawing.SystemColors.HotTrack
        Me.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.button1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.button1.ForeColor = System.Drawing.Color.White
        Me.button1.Location = New System.Drawing.Point(12, 103)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(152, 26)
        Me.button1.TabIndex = 20
        Me.button1.Text = "Importar Data de Excel"
        Me.button1.UseVisualStyleBackColor = False
        '
        'label2
        '
        Me.label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2.Location = New System.Drawing.Point(12, 81)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(368, 22)
        Me.label2.TabIndex = 19
        Me.label2.Text = "Importar inventario inicial"
        '
        'dataGrid1
        '
        Me.dataGrid1.AllowSorting = False
        Me.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dataGrid1.CaptionBackColor = System.Drawing.Color.SteelBlue
        Me.dataGrid1.DataMember = ""
        Me.dataGrid1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dataGrid1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dataGrid1.GridLineColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dataGrid1.HeaderBackColor = System.Drawing.Color.LightSteelBlue
        Me.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dataGrid1.Location = New System.Drawing.Point(0, 135)
        Me.dataGrid1.Name = "dataGrid1"
        Me.dataGrid1.ParentRowsBackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dataGrid1.PreferredRowHeight = 20
        Me.dataGrid1.ReadOnly = True
        Me.dataGrid1.SelectionBackColor = System.Drawing.Color.White
        Me.dataGrid1.SelectionForeColor = System.Drawing.Color.White
        Me.dataGrid1.Size = New System.Drawing.Size(1039, 392)
        Me.dataGrid1.TabIndex = 22
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(177, Byte), Integer))
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Location = New System.Drawing.Point(330, 103)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(184, 26)
        Me.Button3.TabIndex = 23
        Me.Button3.Text = "Generar Inventario Inicial"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'cboAlmacen
        '
        Me.cboAlmacen.BackColor = System.Drawing.Color.White
        Me.cboAlmacen.BeforeTouchSize = New System.Drawing.Size(220, 21)
        Me.cboAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAlmacen.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAlmacen.Location = New System.Drawing.Point(578, 107)
        Me.cboAlmacen.Name = "cboAlmacen"
        Me.cboAlmacen.Size = New System.Drawing.Size(220, 21)
        Me.cboAlmacen.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
        Me.cboAlmacen.TabIndex = 25
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(521, 113)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 13)
        Me.Label5.TabIndex = 24
        Me.Label5.Text = "Almacén:"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'FormImportarExcelInventario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1039, 527)
        Me.Controls.Add(Me.cboAlmacen)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.dataGrid1)
        Me.Controls.Add(Me.button2)
        Me.Controls.Add(Me.button1)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.pictureBox3)
        Me.Name = "FormImportarExcelInventario"
        Me.ShowIcon = False
        Me.Text = "Importar inventario"
        CType(Me.pictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents pictureBox3 As PictureBox
    Private WithEvents button2 As Button
    Private WithEvents button1 As Button
    Private WithEvents label2 As Label
    Private WithEvents dataGrid1 As DataGrid
    Private WithEvents Button3 As Button
    Friend WithEvents cboAlmacen As Tools.ComboBoxAdv
    Friend WithEvents Label5 As Label
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
End Class
