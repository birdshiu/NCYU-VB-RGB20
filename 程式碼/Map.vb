'Imports System.Runtime.Remoting.Channels

Imports System.Threading

Public Class Map
    Public AllVirus As List(Of Covid19)
    Public AllInstance As List(Of Instance)
    Public Const Unit = 10
    Public WithEvents Form As Form
    Public XBound As Integer
    Public YBound As Integer
    Public MainTank As Tank
    Public Map(,) As Instance
    Public MessagePanel As Panel
    Public MessagePanelFrame As PictureBox
    Public LifeBar As PictureBox
    Public EnergyBar As PictureBox
    Public LifeBarMaxLength As Integer
    Public EnergyBarMaxLength As Integer
    Public tmpPicBox As PictureBox
    Public BackGroundImg As Bitmap
    Public covid_pic As PictureBox
    Public num_pic As PictureBox
    Public num_x As PictureBox

    Public Sub New(width As Integer, height As Integer, pic As Bitmap)
        Me.Form = New Form()
        Me.Form.Height = height
        Me.Form.Width = width
        Me.Form.MaximumSize = New Point(width, height)
        Me.Form.MinimumSize = New Point(width, height)
        Me.Form.MaximizeBox = False
        Me.Form.Icon = My.Resources.Tank1
        Me.Form.Text = "RGB-20"
        Me.Form.StartPosition = FormStartPosition.CenterScreen
        Me.Form.BackgroundImage = pic
        Me.Form.BackgroundImageLayout = ImageLayout.Stretch
        Me.BackGroundImg = pic
        Me.covid_pic = New PictureBox()
        Me.covid_pic.SizeMode = PictureBoxSizeMode.StretchImage
        Me.covid_pic.Image = My.Resources.Covid19
        Me.covid_pic.Width = 30
        Me.covid_pic.Height = 30
        Me.covid_pic.Top = 15
        Me.covid_pic.Left = Me.Form.Width * 0.8
        Me.num_pic = New PictureBox()
        Me.num_pic.SizeMode = PictureBoxSizeMode.StretchImage
        'Me.num_pic.Image = My.Resources._9
        ' MsgBox(Form1.virus)

        Me.num_pic.Width = 30
        Me.num_pic.Height = 30
        Me.num_pic.Top = 15
        Me.num_pic.Left = Me.Form.Width * 0.9
        Me.num_x = New PictureBox()
        Me.num_x.SizeMode = PictureBoxSizeMode.StretchImage
        Me.num_x.Image = My.Resources.x
        Me.num_x.Width = 30
        Me.num_x.Height = 30
        Me.num_x.Top = 15
        Me.num_x.Left = Me.Form.Width * 0.85

        Me.LifeBar = New PictureBox()
        Me.LifeBar.SizeMode = PictureBoxSizeMode.StretchImage
        Me.LifeBar.Image = My.Resources.LifeBar
        Me.LifeBar.Width = (width - 15) * 0.3
        Me.LifeBar.Height = 20
        Me.LifeBar.Top = 20
        Me.LifeBar.Left = (width - 15) * 0.1

        Me.EnergyBar = New PictureBox()
        Me.EnergyBar.SizeMode = PictureBoxSizeMode.StretchImage
        Me.EnergyBar.Image = My.Resources.EnergyBar
        Me.EnergyBar.Width = 0
        Me.EnergyBar.Height = 20
        Me.EnergyBar.Top = 20
        Me.EnergyBar.Left = (width - 15) * 0.51

        Me.LifeBarMaxLength = (width - 15) * 0.3
        Me.EnergyBarMaxLength = (width - 15) * 0.3

        Me.MessagePanelFrame = New PictureBox()
        Me.MessagePanelFrame.Height = 60
        Me.MessagePanelFrame.Width = width - 15
        Me.MessagePanelFrame.Top = 0
        Me.MessagePanelFrame.Left = 0
        Me.MessagePanelFrame.SizeMode = PictureBoxSizeMode.StretchImage
        Me.MessagePanelFrame.Image = My.Resources.MessagePanelFrame
        Me.MessagePanelFrame.BackColor = Color.Transparent

        Me.MessagePanel = New Panel()
        Me.MessagePanel.Controls.Add(Me.num_x)
        Me.MessagePanel.Controls.Add(Me.covid_pic)
        Me.MessagePanel.Controls.Add(Me.num_pic)
        Me.MessagePanel.Controls.Add(Me.EnergyBar)
        Me.MessagePanel.Controls.Add(Me.LifeBar)
        Me.MessagePanel.Controls.Add(Me.MessagePanelFrame)
        Me.MessagePanel.Width = width - 15
        Me.MessagePanel.Height = 60
        Me.MessagePanel.Top = height - 100
        Me.MessagePanel.Left = 0

        Me.Form.Controls.Add(Me.MessagePanel)

        ReDim Me.Map(height / Unit, width / Unit)

        Me.XBound = width - 15
        Me.YBound = height - 100

        AllVirus = New List(Of Covid19)
        Me.AllInstance = New List(Of Instance)

        For i As Integer = 0 To (height / Unit) Step 1
            For j As Integer = 0 To (width / Unit) Step 1
                Me.Map(i, j) = Nothing
            Next
        Next

        tmpPicBox = New PictureBox()
        With tmpPicBox
            .Size = Me.Form.Size
            .SizeMode = PictureBoxSizeMode.StretchImage
            .Top = 0
            .Left = 0
            .Image = My.Resources.WinnieUltimate
            .Visible = True
        End With
    End Sub

    Public Sub Attach(tank As Tank)   ''''新增坦克
        Me.MainTank = tank
        For i As Integer = (tank.Y / Unit) To (tank.Y / Unit + tank.Height / Unit - 1) Step 1
            For j As Integer = (tank.X / Unit) To (tank.X / Unit + tank.Width / Unit - 1) Step 1
                Me.Map(i, j) = tank
            Next
        Next
        tank.AttachedMap = Me
        Me.Form.Controls.Add(tank.Img)

        If TypeOf tank Is WinnieTank Then
            Dim newtank As WinnieTank
            newtank = CType(tank, WinnieTank)
            Me.Form.Controls.Add(newtank.ExplodeImg)
            Me.Form.Controls.SetChildIndex(newtank.ExplodeImg, 0)
        End If
    End Sub

    Public Sub Attach(t As GreenTankSub)
        For i As Integer = (t.Y / Unit) To (t.Y / Unit + t.Height / Unit - 1) Step 1
            For j As Integer = (t.X / Unit) To (t.X / Unit + t.Width / Unit - 1) Step 1
                Me.Map(i, j) = t
            Next
        Next
        Dim tmpTank As GreenTank
        tmpTank = CType(Me.MainTank, GreenTank)
        tmpTank.SubTanks.Add(t)
        t.AttachedMap = Me
        Me.Form.Controls.Add(t.Img)
    End Sub

    Public Sub Attach(brick As Brick)
        For i As Integer = (brick.Y / Unit) To (brick.Y / Unit + brick.Height / Unit - 1) Step 1
            For j As Integer = (brick.X / Unit) To (brick.X / Unit + brick.Width / Unit - 1) Step 1
                Me.Map(i, j) = brick
            Next
        Next

        brick.AttachedMap = Me
        Me.Form.Controls.Add(brick.Img)
    End Sub

    Public Sub Attach(bullet As Bullet)
        For i As Integer = (bullet.Y / Unit) To (bullet.Y / Unit + bullet.Height / Unit - 1) Step 1
            For j As Integer = (bullet.X / Unit) To (bullet.X / Unit + bullet.Width / Unit - 1) Step 1
                Me.Map(i, j) = bullet
            Next
        Next

        bullet.AttachedMap = Me
        Me.Form.Controls.Add(bullet.Img)
        bullet.MoveTimer.Enabled = True
    End Sub

    Public Sub Attach(covid As Covid19)
        For i As Integer = (covid.Y / Unit) To (covid.Y / Unit + covid.Height / Unit - 1) Step 1
            For j As Integer = (covid.X / Unit) To (covid.X / Unit + covid.Width / Unit - 1) Step 1
                Me.Map(i, j) = covid
            Next
        Next

        covid.AttachedMap = Me
        Me.Form.Controls.Add(covid.Img)
        Me.AllVirus.Add(covid)
        If Form1.virus = 9 Then
            Me.num_pic.Image = My.Resources._9
        ElseIf Form1.virus = 8 Then
            Me.num_pic.Image = My.Resources._8
        ElseIf Form1.virus = 7 Then
            Me.num_pic.Image = My.Resources._7
        ElseIf Form1.virus = 6 Then
            Me.num_pic.Image = My.Resources._6
        ElseIf Form1.virus = 5 Then
            Me.num_pic.Image = My.Resources._5
        ElseIf Form1.virus = 4 Then
            Me.num_pic.Image = My.Resources._4
        ElseIf Form1.virus = 3 Then
            Me.num_pic.Image = My.Resources._3
        ElseIf Form1.virus = 2 Then
            Me.num_pic.Image = My.Resources._2
        ElseIf Form1.virus = 1 Then
            Me.num_pic.Image = My.Resources._1
        End If
    End Sub

    Public Sub Remove(brick As Brick)
        For i As Integer = (brick.Y / Unit) To (brick.Y / Unit + brick.Height / Unit - 1)
            For j As Integer = (brick.X / Unit) To (brick.X / Unit + brick.Width / Unit - 1)
                Me.Map(i, j) = Nothing
            Next
        Next
        Me.Form.Controls.Remove(brick.Img)
        brick = Nothing
    End Sub

    Public Sub Remove(tank As Tank)
        For i As Integer = (tank.Y / Unit) To (tank.Y / Unit + tank.Height / Unit - 1)
            For j As Integer = (tank.X / Unit) To (tank.X / Unit + tank.Width / Unit - 1)
                Me.Map(i, j) = Nothing
            Next
        Next
        Me.Form.Controls.Remove(tank.Img)
        tank = Nothing
    End Sub

    Public Sub Remove(tank As GreenTankSub)
        For i As Integer = (tank.Y / Unit) To (tank.Y / Unit + tank.Height / Unit - 1)
            For j As Integer = (tank.X / Unit) To (tank.X / Unit + tank.Width / Unit - 1)
                Me.Map(i, j) = Nothing
            Next
        Next
        Dim tmpTank As GreenTank = CType(Me.MainTank, GreenTank)
        Me.Form.Controls.Remove(tank.Img)
        tmpTank.SubTanks.Remove(tank)
        tank = Nothing
    End Sub

    Public Sub Remove(bullet As Bullet)
        For i As Integer = (bullet.Y / Unit) To (bullet.Y / Unit + bullet.Height / Unit - 1) Step 1
            For j As Integer = (bullet.X / Unit) To (bullet.X / Unit + bullet.Width / Unit - 1) Step 1
                Me.Map(i, j) = Nothing
            Next
        Next
        Me.Form.Controls.Remove(bullet.Img)
        bullet = Nothing
    End Sub

    Public Sub Remove(covid As Covid19)
        For i As Integer = (covid.Y / Unit) To (covid.Y / Unit + covid.Height / Unit - 1) Step 1
            For j As Integer = (covid.X / Unit) To (covid.X / Unit + covid.Width / Unit - 1) Step 1
                Me.Map(i, j) = Nothing
            Next
        Next
        Me.Form.Controls.Remove(covid.Img)
        Me.AllVirus.Remove(covid)
        covid = Nothing
        Form1.virus -= 1
        If Form1.virus = 9 Then
            Me.num_pic.Image = My.Resources._9
        ElseIf Form1.virus = 8 Then
            Me.num_pic.Image = My.Resources._8
        ElseIf Form1.virus = 7 Then
            Me.num_pic.Image = My.Resources._7
        ElseIf Form1.virus = 6 Then
            Me.num_pic.Image = My.Resources._6
        ElseIf Form1.virus = 5 Then
            Me.num_pic.Image = My.Resources._5
        ElseIf Form1.virus = 4 Then
            Me.num_pic.Image = My.Resources._4
        ElseIf Form1.virus = 3 Then
            Me.num_pic.Image = My.Resources._3
        ElseIf Form1.virus = 2 Then
            Me.num_pic.Image = My.Resources._2
        ElseIf Form1.virus = 1 Then
            Me.num_pic.Image = My.Resources._1
        End If

        If Me.AllVirus.Count = 0 Or Me.AllVirus Is Nothing Then

            If Form3.max_stage = Form3.now_play Then
                Form3.max_stage += 1
            End If
            If MsgBox("你贏了") = 1 Then
                Me.EndMap()
            End If
        End If
    End Sub

    Public Sub Hide(instance As Instance)
        Me.AllInstance.Add(instance)
        For i As Integer = instance.Y / Unit To instance.Y / Unit + instance.Height / Unit - 1
            For j As Integer = instance.X / Unit To instance.X / Unit + instance.Width / Unit - 1
                Me.Map(i, j) = Nothing
            Next
        Next
        instance.Img.Visible = False

    End Sub

    Public Sub Show(instance As Instance)

        For i As Integer = instance.Y / Unit To instance.Y / Unit + instance.Height / Unit - 1
            For j As Integer = instance.X / Unit To instance.X / Unit + instance.Width / Unit - 1
                Me.Map(i, j) = instance
            Next
        Next

        instance.Img.Visible = True
        Me.AllInstance.Remove(instance)
    End Sub
    Public Sub MainTankMove(sender As Object, e As KeyEventArgs) Handles Form.KeyDown
        Select Case e.KeyCode
            Case Keys.Up
                MainTank.ChangeDirection(0)
                MainTank.StartMove()
            Case Keys.Down
                MainTank.ChangeDirection(2)
                MainTank.StartMove()
            Case Keys.Left
                MainTank.ChangeDirection(3)
                MainTank.StartMove()
            Case Keys.Right
                MainTank.ChangeDirection(1)
                MainTank.StartMove()
            Case Keys.Space
                MainTank.StartShoot()
            Case Keys.Z
                MainTank.StartUltimate()
        End Select
    End Sub

    Public Sub MainTankStop(sender As Object, e As KeyEventArgs) Handles Form.KeyUp
        Select Case e.KeyCode
            Case Keys.Up
                MainTank.StopMove()
            Case Keys.Down
                MainTank.StopMove()
            Case Keys.Left
                MainTank.StopMove()
            Case Keys.Right
                MainTank.StopMove()
            Case Keys.Space
                MainTank.StopShoot()
        End Select
    End Sub
    Public Sub StartMap()
        Me.Form.Activate()
        Me.Form.Show()
    End Sub

    Public Sub EndMap()
        StopVirus()
        RemoveHandler Form.KeyDown, AddressOf MainTankMove
        RemoveHandler Form.KeyUp, AddressOf MainTankStop
        Me.MainTank.StopMove()
        Me.MainTank.StopShoot()
        Me.MainTank.EnergyRecoveryTimer.Enabled = False
        Form1.one = Nothing
        Me.Form.Dispose()
        Form1.virus = 0

    End Sub

    Public Sub StopVirus()
        For Each i In AllVirus
            i.covidmove0.Enabled = False
            i.covidmove1.Enabled = False
            i.covidmove2.Enabled = False
            i.covidmove3.Enabled = False
            i.covidmove4.Enabled = False
        Next
    End Sub

    Public Sub StartVirus()
        For Each i In AllVirus
            i.covidmove0.Enabled = True
        Next
    End Sub

    Private Sub CloseMap() Handles Form.Disposed
        RemoveHandler Form.KeyDown, AddressOf MainTankMove
        RemoveHandler Form.KeyUp, AddressOf MainTankStop
        Me.MainTank.StopMove()
        Me.MainTank.StopShoot()
        Me.MainTank.EnergyRecoveryTimer.Enabled = False
        Form1.one = Nothing
        StopVirus()
        Form1.virus = 0
    End Sub
End Class
