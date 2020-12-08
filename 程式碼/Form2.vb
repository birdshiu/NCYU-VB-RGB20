Public Class Form2
    Public Shared tank_type As Integer
    Dim now_map, pre_map, Xpoint, Ypoint As Integer
    Private Sub Pick_leave_Click(sender As Object, e As EventArgs) Handles pick_leave.Click
        ' reset
        now_map = 1
        tank_type = 1
        move_left.Visible = False
        PictureBox1.Location = New Point(240, 93)
        Timer1.Enabled = False
        arrow_show()
        PictureBox2.Visible = False
        PictureBox3.Visible = False
        ''
        My.Computer.Audio.Play(My.Resources.登3, AudioPlayMode.Background)
        Form1.Show()
        Hide()
    End Sub
    Private Sub comfirm_Click(sender As Object, e As EventArgs) Handles comfirm.Click
        My.Computer.Audio.Play(My.Resources.登3, AudioPlayMode.Background)
        Form3.Show()
        Hide()
    End Sub
    Private Sub Pick_leave_font(sender As Object, e As EventArgs) Handles pick_leave.MouseMove, comfirm.MouseMove
        sender.Font = New Font("標楷體", 18, FontStyle.Bold)
    End Sub
    Private Sub Mouse_left(sender As Object, e As EventArgs) Handles pick_leave.MouseLeave, comfirm.MouseLeave
        sender.Font = New Font("標楷體", 14, FontStyle.Bold)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Xpoint < 239 Or Xpoint > 241 Then
            If now_map = 1 Then ' 2 到 1
                PictureBox1.Visible = True
                PictureBox1.Location = New Point(Xpoint, Ypoint)
                PictureBox1.Left = PictureBox1.Left + 26
                PictureBox2.Left = PictureBox2.Left + 26
                Xpoint += 26
            ElseIf now_map = 2 Then
                PictureBox2.Visible = True
                If pre_map = 1 Then ' 3 到 2
                    PictureBox2.Location = New Point(Xpoint, Ypoint)
                    PictureBox2.Left = PictureBox2.Left + 26
                    PictureBox3.Left = PictureBox3.Left + 26
                    Xpoint += 26
                Else                ' 1 到 2
                    PictureBox2.Location = New Point(Xpoint, Ypoint)
                    PictureBox2.Left = PictureBox2.Left - 26
                    PictureBox1.Left = PictureBox1.Left - 26
                    Xpoint -= 26
                End If
            ElseIf now_map = 3 Then '2 到 3
                PictureBox3.Visible = True
                PictureBox3.Location = New Point(Xpoint, Ypoint)
                PictureBox3.Left = PictureBox3.Left - 26
                PictureBox2.Left = PictureBox2.Left - 26
                Xpoint -= 26
            End If

        Else
            If now_map = 1 Then
                tank_name.Text = "鳴噤黨"
                tank_description.Text = "血量：200 傷害：30" & vbCrLf & "科技【OFFZ(one four five zero)】" & vbCrLf & "『召喚國家機器，本體發射子彈時，它也會發射" & vbCrLf & "可召喚最多兩台』"
                tank_description.Location = New Point(157, 360)
            ElseIf now_map = 2 Then
                tank_name.Text = "國魚黨"
                tank_description.Text = "血量：100 傷害：10" & vbCrLf & "科技【我現在要出征ㄓㄓ】" & vbCrLf & "『在15秒內，炮彈會變成黑色小牙籤，" & vbCrLf & "傷害會些許提升，發射、移動速度會再加快』"
                tank_description.Location = New Point(166, 360)
            Else
                tank_name.Text = "共慘黨"
                tank_description.Text = "血量：300 傷害：50" & vbCrLf & "科技【維尼出征】" & vbCrLf & "『發動期間內車身無敵，發射速度變快』"
                tank_description.Location = New Point(194, 360)
            End If
            tank_name.Visible = True
            tank_description.Visible = True
            Timer1.Enabled = False
            arrow_show()
        End If
    End Sub

    Private Sub Move_left_Click(sender As Object, e As EventArgs) Handles move_left.Click
        If now_map > 1 Then
            Xpoint = -332
            Ypoint = 93
            now_map -= 1
            tank_type -= 1
            pre_map = 1
            Timer1.Enabled = True
            tank_name.Visible = False
            tank_description.Visible = False
            arrow_hid()
        End If
    End Sub

    Private Sub Move_right_Click(sender As Object, e As EventArgs) Handles move_right.Click
        If now_map < 3 Then
            Xpoint = 812
            Ypoint = 93
            now_map += 1
            tank_type += 1
            pre_map = -1
            Timer1.Enabled = True
            tank_name.Visible = False
            tank_description.Visible = False
            arrow_hid()
        End If
    End Sub
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CancelButton = pick_leave
        now_map = 1
        tank_type = 1
        Icon = My.Resources.Tank1
        BackgroundImage = My.Resources.grass
        BackgroundImageLayout = ImageLayout.Center

        'Console.WriteLine(tank_type)
        PictureBox2.Visible = False
        PictureBox3.Visible = False
        move_left.Visible = False
    End Sub

    Sub arrow_show()
        If now_map <> 1 Then
            move_left.Visible = True
        End If
        If now_map <> 3 Then
            move_right.Visible = True
        End If
    End Sub
    Sub arrow_hid()
        move_left.Visible = False
        move_right.Visible = False
    End Sub
End Class