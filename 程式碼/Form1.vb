Public Class Form1
    Public one As Map
    Public Shared virus As Integer = 0
    Dim key_pic As PictureBox
    Dim Y_point As Integer = 1
    Dim now_progress As Integer = 0
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox1.Visible = False
        game_Start.Visible = False
        game_help.Visible = False
        leave_game.Visible = False
        Icon = My.Resources.Tank1
        keyboard.Visible = False
        BackgroundImage = My.Resources.grass
        BackgroundImageLayout = ImageLayout.Stretch
        Timer1.Enabled = True
    End Sub 'SubSystem.InvalidOperationException: '建立表單時發生錯誤。如需詳細資訊，請參閱 Exception.InnerException。錯誤是: 找不到任何適用特定文化特性或中性文化特性的資源。請確定您已在編譯時期正確地將 "程式碼.Form2.resources" 嵌入或連結至組件 "程式碼" 中，或所有需要的附屬組件均為可載入且已完整簽署。'

    Private Sub Mouse_at(sender As Object, e As EventArgs) Handles game_Start.MouseMove, game_help.MouseMove, leave_game.MouseMove
        sender.font = New Font("標楷體", 20, FontStyle.Bold)
    End Sub
    Private Sub Mouse_left(sender As Object, e As EventArgs) Handles game_Start.MouseLeave, game_help.MouseLeave, leave_game.MouseLeave
        sender.font = New Font("標楷體", 16, FontStyle.Regular)
    End Sub
    Private Sub Mouse_at_x(sender As Object, e As EventArgs) Handles Label1.MouseLeave
        sender.font = New Font("Segoe Print", 37, FontStyle.Bold)
    End Sub
    Private Sub Mouse_left_x(sender As Object, e As EventArgs) Handles Label1.MouseLeave
        sender.font = New Font("Segoe Print", 28, FontStyle.Bold)
    End Sub
    Private Sub Start(sender As Object, e As EventArgs) Handles game_Start.Click
        My.Computer.Audio.Play(My.Resources.登, AudioPlayMode.Background)
        Form2.Show()
        Visible = False
    End Sub
    Private Sub game_help_Click(sender As Object, e As EventArgs) Handles game_help.Click
        'MsgBox("123123" & vbCrLf & "123123", 0, "遊戲幫助")
        game_Start.Visible = False
        game_help.Visible = False
        leave_game.Visible = False
        Label1.Visible = True
        keyboard.Location = New Point(100, 73)
        keyboard.Image = My.Resources.cont_key___space___Complete
        keyboard.Visible = True
        PictureBox1.Visible = False
        Text = "遊戲幫助"
        My.Computer.Audio.Play(My.Resources.登, AudioPlayMode.Background)
    End Sub

    Private Sub leave_game_Click(sender As Object, e As EventArgs) Handles leave_game.Click
        Dim leave As Integer
        My.Computer.Audio.Play(My.Resources.登, AudioPlayMode.Background)
        leave = MsgBox("是否離開遊戲？", 4, "確定")
        If leave = 6 Then
            Dispose()
        End If
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        game_Start.Visible = True
        game_help.Visible = True
        leave_game.Visible = True
        PictureBox1.Visible = True
        Label1.Visible = False
        keyboard.Visible = False
        Text = "主畫面"
        My.Computer.Audio.Play(My.Resources.登, AudioPlayMode.Background)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If now_progress = 0 Then
            PictureBox1.Visible = True
            now_progress += 1
            My.Computer.Audio.Play(My.Resources.登2, AudioPlayMode.Background)
        ElseIf now_progress = 1 Then
            game_Start.Visible = True
            now_progress += 1
            My.Computer.Audio.Play(My.Resources.登2, AudioPlayMode.Background)
        ElseIf now_progress = 2 Then
            game_help.Visible = True
            now_progress += 1
            My.Computer.Audio.Play(My.Resources.登2, AudioPlayMode.Background)
        ElseIf now_progress = 3 Then
            leave_game.Visible = True
            now_progress += 1
            My.Computer.Audio.Play(My.Resources.登2, AudioPlayMode.Background)
            Timer1.Enabled = False
        End If
    End Sub
End Class
