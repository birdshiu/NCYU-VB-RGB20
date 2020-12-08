<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.game_Start = New System.Windows.Forms.Label()
        Me.game_help = New System.Windows.Forms.Label()
        Me.leave_game = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.keyboard = New System.Windows.Forms.PictureBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.keyboard, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'game_Start
        '
        Me.game_Start.BackColor = System.Drawing.Color.Transparent
        Me.game_Start.Cursor = System.Windows.Forms.Cursors.Hand
        Me.game_Start.Font = New System.Drawing.Font("標楷體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.game_Start.Location = New System.Drawing.Point(216, 237)
        Me.game_Start.Name = "game_Start"
        Me.game_Start.Size = New System.Drawing.Size(359, 52)
        Me.game_Start.TabIndex = 0
        Me.game_Start.Text = "game start (遊戲開始)"
        Me.game_Start.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'game_help
        '
        Me.game_help.BackColor = System.Drawing.Color.Transparent
        Me.game_help.Cursor = System.Windows.Forms.Cursors.Hand
        Me.game_help.Font = New System.Drawing.Font("標楷體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.game_help.Location = New System.Drawing.Point(216, 289)
        Me.game_help.Name = "game_help"
        Me.game_help.Size = New System.Drawing.Size(359, 52)
        Me.game_help.TabIndex = 1
        Me.game_help.Text = "help (遊戲幫助)"
        Me.game_help.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'leave_game
        '
        Me.leave_game.BackColor = System.Drawing.Color.Transparent
        Me.leave_game.Cursor = System.Windows.Forms.Cursors.Hand
        Me.leave_game.Font = New System.Drawing.Font("標楷體", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.leave_game.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.leave_game.Location = New System.Drawing.Point(216, 342)
        Me.leave_game.Name = "leave_game"
        Me.leave_game.Size = New System.Drawing.Size(359, 52)
        Me.leave_game.TabIndex = 2
        Me.leave_game.Text = "leave (離開遊戲)"
        Me.leave_game.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label1.Font = New System.Drawing.Font("Segoe Print", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(38, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 65)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "X"
        Me.Label1.Visible = False
        '
        'keyboard
        '
        Me.keyboard.BackColor = System.Drawing.Color.Transparent
        Me.keyboard.Enabled = False
        Me.keyboard.Location = New System.Drawing.Point(900, 58)
        Me.keyboard.Name = "keyboard"
        Me.keyboard.Size = New System.Drawing.Size(605, 338)
        Me.keyboard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.keyboard.TabIndex = 6
        Me.keyboard.TabStop = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 400
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.程式碼.My.Resources.Resources.無標題繪圖
        Me.PictureBox1.Location = New System.Drawing.Point(160, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(485, 170)
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.keyboard)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.leave_game)
        Me.Controls.Add(Me.game_help)
        Me.Controls.Add(Me.game_Start)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RGB-20"
        CType(Me.keyboard, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents game_Start As Label
    Friend WithEvents game_help As Label
    Friend WithEvents leave_game As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents keyboard As PictureBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents PictureBox1 As PictureBox
End Class
