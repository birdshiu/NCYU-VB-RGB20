<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
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

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請勿使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.pick_leave = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.move_left = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.move_right = New System.Windows.Forms.PictureBox()
        Me.comfirm = New System.Windows.Forms.Button()
        Me.tank_name = New System.Windows.Forms.Label()
        Me.tank_description = New System.Windows.Forms.Label()
        CType(Me.move_left, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.move_right, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Interval = 1
        '
        'pick_leave
        '
        Me.pick_leave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pick_leave.Font = New System.Drawing.Font("標楷體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.pick_leave.Location = New System.Drawing.Point(12, 393)
        Me.pick_leave.Name = "pick_leave"
        Me.pick_leave.Size = New System.Drawing.Size(95, 45)
        Me.pick_leave.TabIndex = 3
        Me.pick_leave.TabStop = False
        Me.pick_leave.Text = "返回"
        Me.pick_leave.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("微軟正黑體", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 31)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "選擇坦克"
        '
        'move_left
        '
        Me.move_left.BackColor = System.Drawing.Color.Transparent
        Me.move_left.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.move_left.Image = Global.程式碼.My.Resources.Resources.arrow
        Me.move_left.Location = New System.Drawing.Point(109, 184)
        Me.move_left.Name = "move_left"
        Me.move_left.Size = New System.Drawing.Size(57, 68)
        Me.move_left.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.move_left.TabIndex = 5
        Me.move_left.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Image = Global.程式碼.My.Resources.Resources.bear
        Me.PictureBox3.Location = New System.Drawing.Point(240, 93)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(313, 263)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 2
        Me.PictureBox3.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = Global.程式碼.My.Resources.Resources.kmt
        Me.PictureBox2.Location = New System.Drawing.Point(240, 94)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(313, 263)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 1
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.程式碼.My.Resources.Resources.DDP
        Me.PictureBox1.Location = New System.Drawing.Point(240, 93)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(313, 263)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'move_right
        '
        Me.move_right.BackColor = System.Drawing.Color.Transparent
        Me.move_right.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.move_right.Image = Global.程式碼.My.Resources.Resources.arrowR
        Me.move_right.Location = New System.Drawing.Point(643, 184)
        Me.move_right.Name = "move_right"
        Me.move_right.Size = New System.Drawing.Size(57, 68)
        Me.move_right.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.move_right.TabIndex = 6
        Me.move_right.TabStop = False
        '
        'comfirm
        '
        Me.comfirm.Cursor = System.Windows.Forms.Cursors.Hand
        Me.comfirm.Font = New System.Drawing.Font("標楷體", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.comfirm.Location = New System.Drawing.Point(693, 393)
        Me.comfirm.Name = "comfirm"
        Me.comfirm.Size = New System.Drawing.Size(95, 45)
        Me.comfirm.TabIndex = 7
        Me.comfirm.TabStop = False
        Me.comfirm.Text = "選擇"
        Me.comfirm.UseVisualStyleBackColor = True
        '
        'tank_name
        '
        Me.tank_name.AutoSize = True
        Me.tank_name.BackColor = System.Drawing.Color.Transparent
        Me.tank_name.Font = New System.Drawing.Font("標楷體", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.tank_name.Location = New System.Drawing.Point(356, 43)
        Me.tank_name.Name = "tank_name"
        Me.tank_name.Size = New System.Drawing.Size(81, 32)
        Me.tank_name.TabIndex = 8
        Me.tank_name.Text = "綠共"
        '
        'tank_description
        '
        Me.tank_description.AutoSize = True
        Me.tank_description.BackColor = System.Drawing.Color.Transparent
        Me.tank_description.Font = New System.Drawing.Font("標楷體", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.tank_description.Location = New System.Drawing.Point(157, 360)
        Me.tank_description.Name = "tank_description"
        Me.tank_description.Size = New System.Drawing.Size(493, 84)
        Me.tank_description.TabIndex = 9
        Me.tank_description.Text = "血量：200 傷害：30" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "科技【OFFZ(one four five zero)】" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "『召喚國家機器，本體發射子彈時，它也會發射" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "可召喚最多兩台』"
        Me.tank_description.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Form2
        '
        Me.AcceptButton = Me.comfirm
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.tank_description)
        Me.Controls.Add(Me.tank_name)
        Me.Controls.Add(Me.comfirm)
        Me.Controls.Add(Me.move_right)
        Me.Controls.Add(Me.move_left)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pick_leave)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.MaximizeBox = False
        Me.Name = "Form2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RGB-20"
        CType(Me.move_left, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.move_right, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents pick_leave As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents move_left As PictureBox
    Friend WithEvents move_right As PictureBox
    Friend WithEvents comfirm As Button
    Protected Friend WithEvents tank_name As Label
    Protected Friend WithEvents tank_description As Label
End Class
