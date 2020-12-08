Public Class Form3
    Dim now_map, pre_map, Xpoint, Ypoint As Integer
    Dim one As Map
    Public Shared now_play As Integer
    Public Shared max_stage As Integer = 1
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Xpoint < 254 Or Xpoint > 256 Then
            If now_map = 1 Then
                PictureBox1.Visible = True
                PictureBox1.Location = New Point(Xpoint, Ypoint)
                PictureBox1.Left = PictureBox1.Left + 30
                PictureBox2.Left = PictureBox2.Left + 30
                Xpoint += 30
            ElseIf now_map = 2 Then
                PictureBox2.Visible = True
                If pre_map = 1 Then
                    PictureBox2.Location = New Point(Xpoint, Ypoint)
                    PictureBox2.Left = PictureBox2.Left + 30
                    PictureBox3.Left = PictureBox3.Left + 30
                    Xpoint += 30
                Else
                    PictureBox2.Location = New Point(Xpoint, Ypoint)
                    PictureBox2.Left = PictureBox2.Left - 30
                    PictureBox1.Left = PictureBox1.Left - 30
                    Xpoint -= 30
                End If
            ElseIf now_map = 3 Then
                PictureBox3.Visible = True
                If pre_map = 1 Then
                    PictureBox3.Location = New Point(Xpoint, Ypoint)
                    PictureBox3.Left = PictureBox3.Left + 30
                    PictureBox4.Left = PictureBox4.Left + 30
                    Xpoint += 30
                Else
                    PictureBox3.Location = New Point(Xpoint, Ypoint)
                    PictureBox3.Left = PictureBox3.Left - 30
                    PictureBox2.Left = PictureBox2.Left - 30
                    Xpoint -= 30
                End If
            ElseIf now_map = 4 Then
                PictureBox4.Visible = True
                If pre_map = 1 Then
                    PictureBox4.Location = New Point(Xpoint, Ypoint)
                    PictureBox4.Left = PictureBox4.Left + 30
                    PictureBox5.Left = PictureBox5.Left + 30
                    Xpoint += 30
                Else
                    PictureBox4.Location = New Point(Xpoint, Ypoint)
                    PictureBox4.Left = PictureBox4.Left - 30
                    PictureBox3.Left = PictureBox3.Left - 30
                    Xpoint -= 30
                End If
            ElseIf now_map = 5 Then
                PictureBox5.Visible = True
                PictureBox5.Location = New Point(Xpoint, Ypoint)
                PictureBox5.Left = PictureBox5.Left - 30
                PictureBox4.Left = PictureBox4.Left - 30
                Xpoint -= 30
            End If

        Else
            If now_map > max_stage Then
                confirm.Enabled = False
            Else
                confirm.Enabled = True
            End If
            If now_map = 1 Or now_map = 2 Then
                BackgroundImage = My.Resources.grass
                BackgroundImageLayout = ImageLayout.Center
            ElseIf now_map = 3 Or now_map = 4 Then
                BackgroundImage = My.Resources.mud
                BackgroundImageLayout = ImageLayout.Stretch
            Else
                BackgroundImage = My.Resources.snow
                BackgroundImageLayout = ImageLayout.Center
            End If
            Timer1.Enabled = False
            arrow_show()
        End If
    End Sub

    Private Sub Move_left_Click(sender As Object, e As EventArgs) Handles move_left.Click
        If now_map > 1 Then
            Xpoint = -345
            Ypoint = 69
            now_map -= 1
            pre_map = 1
            Timer1.Enabled = True
            arrow_hid()
        End If
    End Sub

    Private Sub Move_right_Click(sender As Object, e As EventArgs) Handles move_right.Click
        If now_map < 5 Then
            Xpoint = 855
            Ypoint = 69
            now_map += 1
            pre_map = -1
            Timer1.Enabled = True
            arrow_hid()
        End If
    End Sub
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CancelButton = pick_leave
        Icon = My.Resources.Tank1
        now_map = 1
        BackgroundImage = My.Resources.grass
        BackgroundImageLayout = ImageLayout.Center
        PictureBox2.Visible = False
        PictureBox3.Visible = False
        PictureBox4.Visible = False
        PictureBox5.Visible = False
        move_left.Visible = False
    End Sub

    Sub arrow_show()
        If now_map <> 1 Then
            move_left.Visible = True
        End If
        If now_map <> 5 Then
            move_right.Visible = True
        End If
    End Sub
    Sub arrow_hid()
        move_left.Visible = False
        move_right.Visible = False
    End Sub

    Private Sub confirm_Click(sender As Object, e As EventArgs) Handles confirm.Click  ' 這裡啊
        My.Computer.Audio.Play(My.Resources.登3, AudioPlayMode.Background)
        If now_map = 1 Then

            now_play = 1

            one = New Map(515, 600, My.Resources.grass)
            If Form2.tank_type = 1 Then
                one.Attach(New GreenTank(0, 0))
            ElseIf Form2.tank_type = 2 Then
                one.Attach(New BlueTank(0, 0))
            Else
                one.Attach(New WinnieTank(0, 0))
            End If


            one.Attach(New Covid19(450, 0, 200, 20, 50, 0, 0))
            one.Attach(New Covid19(450, 450, 200, 20, 50, 0, 0))
            one.Attach(New Covid19(0, 450, 200, 20, 50, 0, 0))

            one.Attach(New NormBrick(150, 0))
            one.Attach(New NormBrick(200, 0))
            one.Attach(New NormBrick(300, 0))
            one.Attach(New NormBrick(350, 0))
            one.Attach(New NormBrick(50, 100))
            one.Attach(New NormBrick(100, 100))
            one.Attach(New NormBrick(150, 100))
            one.Attach(New NormBrick(200, 100))
            one.Attach(New NormBrick(250, 100))
            one.Attach(New NormBrick(300, 100))
            one.Attach(New NormBrick(400, 100))
            one.Attach(New WhiteBrick(450, 100))
            one.Attach(New WhiteBrick(200, 150))
            one.Attach(New NormBrick(50, 200))
            one.Attach(New WhiteBrick(200, 200))
            one.Attach(New WhiteBrick(400, 200))
            one.Attach(New NormBrick(50, 250))
            one.Attach(New NormBrick(400, 250))
            one.Attach(New WhiteBrick(50, 300))
            one.Attach(New NormBrick(400, 300))
            one.Attach(New NormBrick(50, 350))
            one.Attach(New NormBrick(100, 350))
            one.Attach(New NormBrick(150, 350))
            one.Attach(New NormBrick(400, 350))
            one.Attach(New NormBrick(250, 400))
            one.Attach(New NormBrick(400, 400))
            one.Attach(New WhiteBrick(200, 450))
            one.Attach(New NormBrick(250, 450))

            one.StartMap()
        End If

        If now_map = 2 Then
            now_play = 2
            one = New Map(615, 700, My.Resources.grass)
            If Form2.tank_type = 1 Then
                one.Attach(New GreenTank(0, 0))
            ElseIf Form2.tank_type = 2 Then
                one.Attach(New BlueTank(0, 0))
            Else
                one.Attach(New WinnieTank(0, 0))
            End If

            one.Attach(New Covid19(350, 150, 200, 20, 40, 0, 0))
            one.Attach(New Covid19(450, 0, 200, 20, 40, 0, 0))
            one.Attach(New Covid19(50, 500, 200, 20, 40, 0, 0))
            one.Attach(New Covid19(200, 400, 200, 20, 40, 0, 0))
            one.Attach(New Covid19(550, 550, 300, 20, 40, 0, 5))

            one.Attach(New NormBrick(250, 0))
            one.Attach(New NormBrick(400, 0))
            one.Attach(New NormBrick(150, 50))
            one.Attach(New WhiteBrick(100, 50))
            one.Attach(New WhiteBrick(250, 50))
            one.Attach(New WhiteBrick(50, 100))
            one.Attach(New WhiteBrick(250, 100))
            one.Attach(New NormBrick(400, 100))
            one.Attach(New WhiteBrick(500, 100))
            one.Attach(New NormBrick(400, 150))
            one.Attach(New WhiteBrick(500, 150))
            one.Attach(New NormBrick(50, 200))
            one.Attach(New WhiteBrick(0, 250))
            one.Attach(New NormBrick(50, 250))
            one.Attach(New WhiteBrick(150, 250))
            one.Attach(New WhiteBrick(250, 250))
            one.Attach(New WhiteBrick(300, 250))
            one.Attach(New WhiteBrick(350, 250))
            one.Attach(New WhiteBrick(400, 250))
            one.Attach(New WhiteBrick(450, 250))
            one.Attach(New NormBrick(500, 250))
            one.Attach(New NormBrick(250, 300))
            one.Attach(New NormBrick(150, 350))
            one.Attach(New WhiteBrick(250, 350))
            one.Attach(New NormBrick(550, 350))
            one.Attach(New NormBrick(150, 400))
            one.Attach(New WhiteBrick(250, 400))
            one.Attach(New WhiteBrick(100, 450))
            one.Attach(New WhiteBrick(150, 450))
            one.Attach(New WhiteBrick(250, 450))
            one.Attach(New NormBrick(400, 450))
            one.Attach(New WhiteBrick(500, 450))
            one.Attach(New WhiteBrick(550, 450))
            one.Attach(New NormBrick(400, 500))
            one.Attach(New NormBrick(450, 500))
            one.Attach(New NormBrick(100, 550))

            one.StartMap()
        End If

        If now_map = 3 Then
            now_play = 3
            one = New Map(615, 700, My.Resources.mud)
            If Form2.tank_type = 1 Then
                one.Attach(New GreenTank(0, 0))
            ElseIf Form2.tank_type = 2 Then
                one.Attach(New BlueTank(0, 0))
            Else
                one.Attach(New WinnieTank(0, 0))
            End If

            one.Attach(New Covid19(150, 50, 300, 20, 40, 0, 5))
            one.Attach(New Covid19(500, 0, 300, 20, 40, 0, 5))
            one.Attach(New Covid19(250, 150, 300, 20, 40, 0, 5))
            one.Attach(New Covid19(0, 550, 300, 20, 40, 0, 5))
            one.Attach(New Covid19(400, 550, 300, 20, 40, 0, 5))

            one.Attach(New WhiteBrick(50, 50, 100, 100))
            one.Attach(New WhiteBrick(250, 0))
            one.Attach(New WhiteBrick(200, 50))
            one.Attach(New WhiteBrick(250, 50))
            one.Attach(New WhiteBrick(200, 100))
            one.Attach(New WhiteBrick(250, 100))
            one.Attach(New WhiteBrick(400, 100))
            one.Attach(New WhiteBrick(450, 100))
            one.Attach(New WhiteBrick(500, 100))
            one.Attach(New WhiteBrick(550, 100))
            one.Attach(New NormBrick(0, 200))
            one.Attach(New NormBrick(0, 250))
            one.Attach(New NormBrick(0, 300))
            one.Attach(New WhiteBrick(50, 200))
            one.Attach(New WhiteBrick(100, 200))
            one.Attach(New WhiteBrick(150, 200))
            one.Attach(New WhiteBrick(200, 200))
            one.Attach(New WhiteBrick(250, 200))
            one.Attach(New WhiteBrick(250, 250))
            one.Attach(New WhiteBrick(500, 250))
            one.Attach(New WhiteBrick(350, 250))
            one.Attach(New WhiteBrick(400, 250))
            one.Attach(New WhiteBrick(450, 250))
            one.Attach(New WhiteBrick(450, 300))
            one.Attach(New WhiteBrick(0, 350, 100, 100))
            one.Attach(New WhiteBrick(100, 350))
            one.Attach(New WhiteBrick(450, 350))
            one.Attach(New WhiteBrick(100, 400))
            one.Attach(New WhiteBrick(250, 400))
            one.Attach(New WhiteBrick(100, 450))
            one.Attach(New WhiteBrick(250, 450))
            one.Attach(New WhiteBrick(450, 450, 100, 100))
            one.Attach(New WhiteBrick(250, 500))
            one.Attach(New WhiteBrick(350, 550))

            one.StartMap()
        End If

        If now_map = 4 Then
            now_play = 4
            one = New Map(615, 700, My.Resources.mud)
            If Form2.tank_type = 1 Then
                one.Attach(New GreenTank(0, 0))
            ElseIf Form2.tank_type = 2 Then
                one.Attach(New BlueTank(0, 0))
            Else
                one.Attach(New WinnieTank(0, 0))
            End If

            one.Attach(New Covid19(250, 0, 300, 20, 40, 1, 5))
            one.Attach(New Covid19(500, 150, 300, 25, 40, 0, 5))
            one.Attach(New Covid19(50, 300, 300, 25, 40, 0, 5))
            one.Attach(New Covid19(250, 300, 300, 20, 40, 1, 5))
            one.Attach(New Covid19(50, 550, 300, 20, 40, 1, 5))
            one.Attach(New Covid19(400, 450, 300, 25, 40, 0, 5))

            one.Attach(New StarlightBrick(150, 50, 100, 100))
            one.Attach(New StarlightBrick(250, 400, 100, 100))
            one.Attach(New StarlightBrick(400, 200, 100, 100))
            one.Attach(New WhiteBrick(350, 0))
            one.Attach(New NormBrick(500, 0))
            one.Attach(New StarlightBrick(500, 50))
            one.Attach(New StarlightBrick(0, 100))
            one.Attach(New StarlightBrick(50, 100))
            one.Attach(New StarlightBrick(500, 100))
            one.Attach(New WhiteBrick(100, 100))
            one.Attach(New WhiteBrick(100, 150))
            one.Attach(New NormBrick(0, 200))
            one.Attach(New NormBrick(50, 200))
            one.Attach(New WhiteBrick(100, 200))
            one.Attach(New WhiteBrick(200, 250))
            one.Attach(New WhiteBrick(250, 250))
            one.Attach(New NormBrick(300, 250))
            one.Attach(New NormBrick(350, 250))
            one.Attach(New StarlightBrick(0, 350))
            one.Attach(New StarlightBrick(50, 350))
            one.Attach(New StarlightBrick(100, 350))
            one.Attach(New StarlightBrick(450, 350))
            one.Attach(New StarlightBrick(500, 350))
            one.Attach(New StarlightBrick(550, 350))
            one.Attach(New WhiteBrick(150, 500))
            one.Attach(New WhiteBrick(150, 550))
            one.Attach(New StarlightBrick(400, 500))
            one.Attach(New StarlightBrick(400, 550))

            one.StartMap()
        End If

        If now_map = 5 Then
            now_play = 5
            one = New Map(765, 700, My.Resources.snow)
            If Form2.tank_type = 1 Then
                one.Attach(New GreenTank(350, 270))
            ElseIf Form2.tank_type = 2 Then
                one.Attach(New BlueTank(350, 270))
            Else
                one.Attach(New WinnieTank(350, 270))
            End If

            one.Attach(New Covid19(700, 550, 700, 25, 50, 0, 4))
            one.Attach(New Covid19(400, 50, 300, 20, 40, 1, 5))
            one.Attach(New Covid19(550, 100, 300, 20, 40, 1, 5))
            one.Attach(New Covid19(150, 150, 300, 20, 40, 1, 5))
            one.Attach(New Covid19(700, 350, 300, 20, 40, 1, 5))
            one.Attach(New Covid19(450, 400, 300, 20, 40, 1, 5))
            one.Attach(New Covid19(100, 550, 300, 20, 40, 1, 5))
            one.Attach(New Covid19(350, 550, 300, 20, 40, 1, 5))

            one.Attach(New NormBrick(0, 0))
            one.Attach(New NormBrick(300, 0))
            one.Attach(New NormBrick(350, 0))
            one.Attach(New NormBrick(400, 0))
            one.Attach(New NormBrick(700, 0))
            one.Attach(New WhiteBrick(50, 150, 100, 100))
            one.Attach(New WhiteBrick(200, 50))
            one.Attach(New WhiteBrick(250, 50))
            one.Attach(New WhiteBrick(450, 50))
            one.Attach(New WhiteBrick(500, 50))
            one.Attach(New WhiteBrick(550, 50))
            one.Attach(New WhiteBrick(600, 100))
            one.Attach(New WhiteBrick(650, 100))
            one.Attach(New WhiteBrick(350, 150))
            one.Attach(New WhiteBrick(400, 150))
            one.Attach(New WhiteBrick(450, 150))
            one.Attach(New WhiteBrick(600, 150))
            one.Attach(New WhiteBrick(250, 200))
            one.Attach(New WhiteBrick(600, 200))
            one.Attach(New WhiteBrick(250, 250))
            one.Attach(New WhiteBrick(500, 250))
            one.Attach(New WhiteBrick(250, 300))
            one.Attach(New WhiteBrick(500, 300))
            one.Attach(New WhiteBrick(100, 350))
            one.Attach(New WhiteBrick(250, 350))
            one.Attach(New WhiteBrick(500, 350))
            one.Attach(New WhiteBrick(100, 400))
            one.Attach(New WhiteBrick(500, 400))
            one.Attach(New WhiteBrick(100, 450))
            one.Attach(New WhiteBrick(300, 450))
            one.Attach(New WhiteBrick(350, 450))
            one.Attach(New WhiteBrick(400, 450))
            one.Attach(New WhiteBrick(600, 450))
            one.Attach(New WhiteBrick(150, 500))
            one.Attach(New WhiteBrick(200, 500))
            one.Attach(New WhiteBrick(600, 500))
            one.Attach(New WhiteBrick(0, 550))
            one.Attach(New WhiteBrick(500, 550))
            one.Attach(New WhiteBrick(550, 550))
            one.Attach(New StarlightBrick(100, 50, 100, 100))
            one.Attach(New StarlightBrick(300, 150))
            one.Attach(New StarlightBrick(500, 200))
            one.Attach(New StarlightBrick(700, 200))
            one.Attach(New StarlightBrick(50, 250))
            one.Attach(New StarlightBrick(50, 300))
            one.Attach(New StarlightBrick(550, 350))
            one.Attach(New StarlightBrick(250, 400))
            one.Attach(New StarlightBrick(650, 400))
            one.Attach(New StarlightBrick(450, 450))
            one.Attach(New StarlightBrick(200, 550))

            one.StartMap()
        End If

    End Sub

    Private Sub my_bad_Click(sender As Object, e As EventArgs) Handles my_bad.Click
        confirm.Enabled = True
    End Sub

    Private Sub pick_leave_Click(sender As Object, e As EventArgs) Handles pick_leave.Click
        My.Computer.Audio.Play(My.Resources.登3, AudioPlayMode.Background)
        Form2.Show()
        Close()
    End Sub
    Private Sub Pick_button_font(sender As Object, e As EventArgs) Handles pick_leave.MouseMove, confirm.MouseMove
        pick_leave.Font = New Font("標楷體", 18, FontStyle.Bold)
    End Sub

    Private Sub Mouse_left(sender As Object, e As EventArgs) Handles pick_leave.MouseLeave, pick_leave.MouseLeave
        pick_leave.Font = New Font("標楷體", 14, FontStyle.Bold)
    End Sub

End Class