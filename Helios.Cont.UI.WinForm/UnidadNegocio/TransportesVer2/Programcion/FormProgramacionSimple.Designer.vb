Imports Syncfusion.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormProgramacionSimple
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
        Me.components = New System.ComponentModel.Container()
        Dim GridColumnDescriptor1 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor2 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim GridColumnDescriptor3 As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor()
        Dim CaptionImage1 As Syncfusion.Windows.Forms.CaptionImage = New Syncfusion.Windows.Forms.CaptionImage()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormProgramacionSimple))
        Dim CaptionLabel1 As Syncfusion.Windows.Forms.CaptionLabel = New Syncfusion.Windows.Forms.CaptionLabel()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Label34 = New System.Windows.Forms.Label()
        Me.GridTotales = New Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridTotales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.BackColor = System.Drawing.Color.Transparent
        Me.Label34.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.Black
        Me.Label34.Location = New System.Drawing.Point(82, 44)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(65, 13)
        Me.Label34.TabIndex = 611
        Me.Label34.Text = "Ruta Origen"
        '
        'GridTotales
        '
        Me.GridTotales.ActivateCurrentCellBehavior = Syncfusion.Windows.Forms.Grid.GridCellActivateAction.SelectAll
        Me.GridTotales.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.GridTotales.BackColor = System.Drawing.SystemColors.Window
        Me.GridTotales.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Metro
        Me.GridTotales.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Metro
        Me.GridTotales.Location = New System.Drawing.Point(25, 71)
        Me.GridTotales.Name = "GridTotales"
        Me.GridTotales.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus
        Me.GridTotales.Size = New System.Drawing.Size(624, 215)
        Me.GridTotales.TabIndex = 418
        Me.GridTotales.TableDescriptor.AllowNew = False
        GridColumnDescriptor1.MappingName = "ID"
        GridColumnDescriptor1.Name = "ID"
        GridColumnDescriptor1.SortByDisplayMember = True
        GridColumnDescriptor1.Width = 0
        GridColumnDescriptor2.Appearance.AnyRecordFieldCell.CellType = "TextBox"
        GridColumnDescriptor2.HeaderText = "ORIGEN"
        GridColumnDescriptor2.MappingName = "ORIGEN"
        GridColumnDescriptor2.Name = "ORIGEN"
        GridColumnDescriptor2.Width = 300
        GridColumnDescriptor3.Appearance.AnyRecordFieldCell.CellType = "TextBox"
        GridColumnDescriptor3.MappingName = "DESTINO"
        GridColumnDescriptor3.Name = "DESTINO"
        GridColumnDescriptor3.Width = 300
        Me.GridTotales.TableDescriptor.Columns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor() {GridColumnDescriptor1, GridColumnDescriptor2, GridColumnDescriptor3})
        Me.GridTotales.TableDescriptor.TableOptions.ColumnHeaderRowHeight = 25
        Me.GridTotales.TableDescriptor.TableOptions.RecordRowHeight = 25
        Me.GridTotales.TableDescriptor.VisibleColumns.AddRange(New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor() {New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("ID"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("ORIGEN"), New Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("DESTINO")})
        Me.GridTotales.TableOptions.GridLineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder()
        Me.GridTotales.TableOptions.ListBoxSelectionOutlineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.Transparent)
        Me.GridTotales.TableOptions.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.GridTotales.TableOptions.SelectionTextColor = System.Drawing.SystemColors.HighlightText
        Me.GridTotales.TableOptions.TreeLineBorder = New Syncfusion.Windows.Forms.Grid.GridBorder(Syncfusion.Windows.Forms.Grid.GridBorderStyle.Solid, System.Drawing.Color.White)
        Me.GridTotales.Text = "GridGroupingControl2"
        Me.GridTotales.TopLevelGroupOptions.IsExpandedInitialValue = True
        Me.GridTotales.TopLevelGroupOptions.RepaintCaptionWhenItemsChanged = True
        Me.GridTotales.TopLevelGroupOptions.ShowAddNewRecordAfterDetails = False
        Me.GridTotales.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = True
        Me.GridTotales.TopLevelGroupOptions.ShowCaption = False
        Me.GridTotales.TopLevelGroupOptions.ShowColumnHeaders = True
        Me.GridTotales.UseRightToLeftCompatibleTextBox = True
        Me.GridTotales.VersionInfo = "12.4400.0.24"
        Me.GridTotales.VerticalScrollTips = True
        Me.GridTotales.WantTabKey = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(89, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(43, 41)
        Me.PictureBox1.TabIndex = 619
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImage = CType(resources.GetObject("PictureBox2.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Location = New System.Drawing.Point(528, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(43, 41)
        Me.PictureBox2.TabIndex = 620
        Me.PictureBox2.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(516, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 621
        Me.Label1.Text = "Ruta Destino"
        '
        'PictureBox3
        '
        Me.PictureBox3.BackgroundImage = CType(resources.GetObject("PictureBox3.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(202, 20)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(247, 21)
        Me.PictureBox3.TabIndex = 623
        Me.PictureBox3.TabStop = False
        '
        'FormProgramacionSimple
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderColor = System.Drawing.SystemColors.Highlight
        Me.BorderThickness = 2
        Me.CaptionBarHeight = 50
        Me.CaptionForeColor = System.Drawing.Color.White
        CaptionImage1.BackColor = System.Drawing.Color.Transparent
        CaptionImage1.ForeColor = System.Drawing.Color.Transparent
        CaptionImage1.Image = CType(resources.GetObject("CaptionImage1.Image"), System.Drawing.Image)
        CaptionImage1.Location = New System.Drawing.Point(30, 7)
        CaptionImage1.Name = "CaptionImage1"
        CaptionImage1.Size = New System.Drawing.Size(35, 35)
        Me.CaptionImages.Add(CaptionImage1)
        CaptionLabel1.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        CaptionLabel1.ForeColor = System.Drawing.Color.CornflowerBlue
        CaptionLabel1.Location = New System.Drawing.Point(70, 12)
        CaptionLabel1.Name = "CaptionLabel1"
        CaptionLabel1.Size = New System.Drawing.Size(300, 24)
        CaptionLabel1.Text = "Lista de Rutas"
        Me.CaptionLabels.Add(CaptionLabel1)
        Me.ClientSize = New System.Drawing.Size(672, 289)
        Me.Controls.Add(Me.GridTotales)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label34)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormProgramacionSimple"
        Me.ShowIcon = False
        Me.Text = " Crear Ruta"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridTotales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents Label34 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents GridTotales As Grid.Grouping.GridGroupingControl
End Class
