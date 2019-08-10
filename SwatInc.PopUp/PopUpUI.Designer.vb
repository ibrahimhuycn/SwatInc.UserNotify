<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PopUpUI
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.PictureBoxPopUpIcon = New System.Windows.Forms.PictureBox()
        Me.LabelControlHeading = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControlMessage = New DevExpress.XtraEditors.LabelControl()
        Me.BackgroundWorkerPopUpDriver = New System.ComponentModel.BackgroundWorker()
        CType(Me.PictureBoxPopUpIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBoxPopUpIcon
        '
        Me.PictureBoxPopUpIcon.Image = Global.SwatInc.PopUp.My.Resources.Resources.RecordsAdded
        Me.PictureBoxPopUpIcon.Location = New System.Drawing.Point(12, 0)
        Me.PictureBoxPopUpIcon.Name = "PictureBoxPopUpIcon"
        Me.PictureBoxPopUpIcon.Size = New System.Drawing.Size(96, 96)
        Me.PictureBoxPopUpIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBoxPopUpIcon.TabIndex = 0
        Me.PictureBoxPopUpIcon.TabStop = False
        '
        'LabelControlHeading
        '
        Me.LabelControlHeading.Appearance.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControlHeading.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold
        Me.LabelControlHeading.Appearance.Options.UseFont = True
        Me.LabelControlHeading.AppearanceDisabled.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LabelControlHeading.AppearanceDisabled.FontStyleDelta = System.Drawing.FontStyle.Bold
        Me.LabelControlHeading.AppearanceDisabled.Options.UseFont = True
        Me.LabelControlHeading.AppearanceHovered.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LabelControlHeading.AppearanceHovered.FontStyleDelta = System.Drawing.FontStyle.Bold
        Me.LabelControlHeading.AppearanceHovered.Options.UseFont = True
        Me.LabelControlHeading.AppearancePressed.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LabelControlHeading.AppearancePressed.FontStyleDelta = System.Drawing.FontStyle.Bold
        Me.LabelControlHeading.AppearancePressed.Options.UseFont = True
        Me.LabelControlHeading.Location = New System.Drawing.Point(122, 0)
        Me.LabelControlHeading.Name = "LabelControlHeading"
        Me.LabelControlHeading.Size = New System.Drawing.Size(60, 23)
        Me.LabelControlHeading.TabIndex = 1
        Me.LabelControlHeading.Text = "Heading"
        '
        'LabelControlMessage
        '
        Me.LabelControlMessage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControlMessage.Appearance.Options.UseTextOptions = True
        Me.LabelControlMessage.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
        Me.LabelControlMessage.AppearanceDisabled.Options.UseTextOptions = True
        Me.LabelControlMessage.AppearanceDisabled.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
        Me.LabelControlMessage.AppearanceHovered.Options.UseTextOptions = True
        Me.LabelControlMessage.AppearanceHovered.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
        Me.LabelControlMessage.AppearancePressed.Options.UseTextOptions = True
        Me.LabelControlMessage.AppearancePressed.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
        Me.LabelControlMessage.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControlMessage.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftTop
        Me.LabelControlMessage.Location = New System.Drawing.Point(122, 29)
        Me.LabelControlMessage.Name = "LabelControlMessage"
        Me.LabelControlMessage.Size = New System.Drawing.Size(282, 67)
        Me.LabelControlMessage.TabIndex = 2
        Me.LabelControlMessage.Text = "Message displayed on PopUpUI"
        '
        'BackgroundWorkerPopUpDriver
        '
        '
        'PopUpUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(416, 100)
        Me.Controls.Add(Me.LabelControlMessage)
        Me.Controls.Add(Me.LabelControlHeading)
        Me.Controls.Add(Me.PictureBoxPopUpIcon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PopUpUI"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "PopUpUI Title"
        CType(Me.PictureBoxPopUpIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBoxPopUpIcon As PictureBox
    Friend WithEvents LabelControlHeading As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControlMessage As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BackgroundWorkerPopUpDriver As System.ComponentModel.BackgroundWorker
End Class
