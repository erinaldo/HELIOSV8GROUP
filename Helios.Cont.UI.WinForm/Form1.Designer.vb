<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.btnOpcion1 = New System.Windows.Forms.Button()
        Me.btnOpcion2 = New System.Windows.Forms.Button()
        Me.btnOpcion3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.TabbedMDIManager1 = New Syncfusion.Windows.Forms.Tools.TabbedMDIManager(Me.components)
        'CType(Me.scPrincipal, System.ComponentModel.ISupportInitialize).BeginInit()
        'Me.scPrincipal.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'scPrincipal
        '
        'Me.scPrincipal.Dock = System.Windows.Forms.DockStyle.None
        'Me.scPrincipal.Location = New System.Drawing.Point(0, 28)
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(43, 29)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(13, 68)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(439, 177)
        Me.DataGridView1.TabIndex = 1
        '
        'btnOpcion1
        '
        Me.btnOpcion1.Location = New System.Drawing.Point(208, 39)
        Me.btnOpcion1.Name = "btnOpcion1"
        Me.btnOpcion1.Size = New System.Drawing.Size(75, 23)
        Me.btnOpcion1.TabIndex = 2
        Me.btnOpcion1.Text = "Opcion1"
        Me.btnOpcion1.UseVisualStyleBackColor = True
        '
        'btnOpcion2
        '
        Me.btnOpcion2.Location = New System.Drawing.Point(289, 39)
        Me.btnOpcion2.Name = "btnOpcion2"
        Me.btnOpcion2.Size = New System.Drawing.Size(75, 23)
        Me.btnOpcion2.TabIndex = 3
        Me.btnOpcion2.Text = "Opcion2"
        Me.btnOpcion2.UseVisualStyleBackColor = True
        '
        'btnOpcion3
        '
        Me.btnOpcion3.Location = New System.Drawing.Point(371, 38)
        Me.btnOpcion3.Name = "btnOpcion3"
        Me.btnOpcion3.Size = New System.Drawing.Size(75, 23)
        Me.btnOpcion3.TabIndex = 4
        Me.btnOpcion3.Text = "Opcion3"
        Me.btnOpcion3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(208, 13)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(124, 29)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 6
        Me.Button3.Text = "Person"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(13, 3)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 23)
        Me.Button5.TabIndex = 8
        Me.Button5.Text = "New project"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Image = Global.Helios.Cont.Presentation.WinForm.My.Resources.Resources.icono_tributo2
        Me.Button4.Location = New System.Drawing.Point(371, 9)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 7
        Me.Button4.Text = "Button4"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'TabbedMDIManager1
        '
        Me.TabbedMDIManager1.AttachedTo = Me
        Me.TabbedMDIManager1.CloseButtonBackColor = System.Drawing.Color.White
        Me.TabbedMDIManager1.ImageSize = New System.Drawing.Size(16, 16)
        Me.TabbedMDIManager1.NeedUpdateHostedForm = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(464, 257)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btnOpcion3)
        Me.Controls.Add(Me.btnOpcion2)
        Me.Controls.Add(Me.btnOpcion1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Button1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.IsMdiContainer = True
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.Controls.SetChildIndex(Me.Button1, 0)
        Me.Controls.SetChildIndex(Me.DataGridView1, 0)
        Me.Controls.SetChildIndex(Me.btnOpcion1, 0)
        Me.Controls.SetChildIndex(Me.btnOpcion2, 0)
        Me.Controls.SetChildIndex(Me.btnOpcion3, 0)
        Me.Controls.SetChildIndex(Me.Button2, 0)
        Me.Controls.SetChildIndex(Me.Button3, 0)
        Me.Controls.SetChildIndex(Me.Button4, 0)
        Me.Controls.SetChildIndex(Me.Button5, 0)
        '  Me.Controls.SetChildIndex(Me.scPrincipal, 0)
        'CType(Me.scPrincipal, System.ComponentModel.ISupportInitialize).EndInit()
        'Me.scPrincipal.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnOpcion1 As System.Windows.Forms.Button
    Friend WithEvents btnOpcion2 As System.Windows.Forms.Button
    Friend WithEvents btnOpcion3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents TabbedMDIManager1 As Syncfusion.Windows.Forms.Tools.TabbedMDIManager

End Class
