Imports System.Threading

Public Class WinnieTank
    Inherits Tank

    Public ExplodeImg As PictureBox '爆炸效果的圖片
    Public WithEvents ExplodeTimer As Windows.Forms.Timer
    Public ExplodeStartTime As Long
    Public Sub New(X As Integer, Y As Integer)
        MyBase.New(X, Y)

        Me.Life = 300
        Me.LifeMax = 300

        Me.ImgState = {My.Resources.bearTop, My.Resources.bearRight, My.Resources.bearDown, My.Resources.bearLeft}

        Me.ExplodeTimer = New Windows.Forms.Timer()
        Me.ExplodeTimer.Interval = 10

        Me.ExplodeImg = New PictureBox()
        Me.ExplodeImg.BackgroundImage = My.Resources.Explode
        Me.ExplodeImg.BackgroundImageLayout = ImageLayout.Stretch
        Me.ExplodeImg.BackColor = Color.Transparent
        Me.ExplodeImg.Size = New Point(150, 150)
        Me.ExplodeImg.Visible = False

        Me.Img.Image = ImgState(0)

        Me.MoveTimer.Interval = 80
        Me.ShootTimeInterval = 2500
        Me.UltimateTimer.Interval = 1400
        Me.EnergyRecoveryTimer.Interval = 25
        Me.EnergyRecoveryTimer.Enabled = True
        Me.isUltimateWork = False


    End Sub

    Public Overrides Sub StartShoot()
        If Me.canShoot = False Then
            Return
        Else
            Me.canShoot = False
            Me.Shoot()
        End If
    End Sub

    Public Overrides Sub StopShoot()
        Me.canShoot = True
    End Sub

    Protected Overrides Sub CheckCollision() Handles MoveTimer.Tick
        MyBase.CheckCollision()
    End Sub
    Public Sub Shoot() 'Handles ShootTimer.Tick
        Dim currentTime = Math.Round((DateTime.Now - New DateTime(1970, 1, 1)).TotalMilliseconds) '得到目前的毫秒
        Dim bullet As WinnieBullet

        If currentTime - Me.PrewShootTime < Me.ShootTimeInterval Then
            Return
        Else
            Me.PrewShootTime = currentTime
        End If

        If Not (Me.isUltimateWork) Then
            My.Computer.Audio.Play(My.Resources.WinnieShoot, AudioPlayMode.Background)
        End If


        Select Case Me.Direction
            Case 0
                If Me.Y - 20 >= 0 Then
                    bullet = New WinnieBullet(Me, Me.X + 20, Me.Y - 20, Me.Direction)
                End If
            Case 1
                If Me.X + 20 + Me.Width <= Me.AttachedMap.XBound Then
                    bullet = New WinnieBullet(Me, Me.X + 60, Me.Y + 20, Me.Direction)
                End If

            Case 2
                If Me.Y + 20 + Me.Height <= Me.AttachedMap.YBound Then
                    bullet = New WinnieBullet(Me, Me.X + 20, Me.Y + 50, Me.Direction)
                End If

            Case 3
                If Me.X - 20 >= 0 Then
                    bullet = New WinnieBullet(Me, Me.X - 20, Me.Y + 20, Me.Direction)
                End If
        End Select
    End Sub

    Public Sub ShowExplode(X As Integer, Y As Integer)
        Me.ExplodeImg.Left = X
        Me.ExplodeImg.Top = Y
        Me.AttachedMap.Form.Controls.SetChildIndex(Me.ExplodeImg, 1000) ''把圖片放到很後面
        Me.ExplodeImg.Visible = True

        Me.ExplodeTimer.Enabled = True
        Me.ExplodeStartTime = Math.Round((DateTime.Now - New DateTime(1970, 1, 1)).TotalMilliseconds)
    End Sub

    Private Sub ExplodeLast() Handles ExplodeTimer.Tick
        If Math.Round((DateTime.Now - New DateTime(1970, 1, 1)).TotalMilliseconds) - Me.ExplodeStartTime > 250 Then
            Me.ExplodeTimer.Enabled = False
            Me.ExplodeImg.Visible = False
        End If
    End Sub

    Protected Overrides Sub EnergyRecover() Handles EnergyRecoveryTimer.Tick
        MyBase.EnergyRecover()
    End Sub

    Private Sub ShowUltiPic()
        Me.AttachedMap.Form.BackgroundImage = My.Resources.WinnieUltimate
    End Sub
    Public Overrides Sub StartUltimate()
        If Me.isUltimateWork Then
            Return
        End If

        If Me.Energy <> 100 Then
            My.Computer.Audio.Play(My.Resources.Nope, AudioPlayMode.Background)
            Return
        End If

        Me.AttachedMap.StopVirus()
        Me.AttachedMap.Form.BackgroundImage = My.Resources.WinnieUltimate

        RemoveHandler Me.AttachedMap.Form.KeyDown, AddressOf Me.AttachedMap.MainTankMove
        RemoveHandler Me.AttachedMap.Form.KeyUp, AddressOf Me.AttachedMap.MainTankStop
        Me.MoveTimer.Enabled = False

        My.Computer.Audio.Play(My.Resources.拉清單, AudioPlayMode.Background)
        Delay(3000)

        Me.InevitableTimer.Enabled = False
        Me.isInevitable = True
        Me.isUltimateWork = True
        Me.ShootTimeInterval = 500
        Me.MoveTimer.Interval = 150
        Me.EnergyRecoveryTimer.Enabled = False
        Me.UltimateTimer.Enabled = True

        AddHandler Me.AttachedMap.Form.KeyDown, AddressOf Me.AttachedMap.MainTankMove
        AddHandler Me.AttachedMap.Form.KeyUp, AddressOf Me.AttachedMap.MainTankStop

        Me.AttachedMap.StartVirus()
        My.Computer.Audio.Play(My.Resources.維尼寫史, AudioPlayMode.Background)
    End Sub

    Private Sub Ultimate() Handles UltimateTimer.Tick
        Me.Energy -= 10
        Me.AttachedMap.EnergyBar.Width = Me.Energy / Tank.EnergyMax * Me.AttachedMap.EnergyBarMaxLength

        If Me.Energy = 0 Then
            Me.AttachedMap.Form.BackgroundImage = Me.AttachedMap.BackGroundImg
            Me.isUltimateWork = False
            Me.ShootTimeInterval = 2500
            Me.MoveTimer.Interval = 80
            Me.EnergyRecoveryTimer.Enabled = True
            Me.isInevitable = False
            Me.UltimateTimer.Enabled = False
            My.Computer.Audio.Play(My.Resources.我們懷念他們, AudioPlayMode.Background)
        End If
    End Sub

End Class
