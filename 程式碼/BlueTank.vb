Imports System.Threading

Public Class BlueTank
    Inherits Tank

    Public Sub New(X As Integer, Y As Integer)
        MyBase.New(X, Y)

        Me.UltimateTimer.Interval = 1000

        Me.ImgState = {My.Resources.blueTankTop, My.Resources.blueTankRight, My.Resources.blueTankDown, My.Resources.blueTankLeft}

        Me.Img.Image = ImgState(0)

        Me.MoveTimer.Interval = 30
        Me.ShootTimeInterval = 300
        Me.EnergyRecoveryTimer.Interval = 80
        Me.EnergyRecoveryTimer.Enabled = True

        Me.Life = 100
        Me.LifeMax = 100
    End Sub

    Public Overrides Sub StartShoot()
        If Me.canShoot = False Then
            Return
        Else
            Me.ShootTimer.Enabled = True
        End If
    End Sub

    Public Overrides Sub StopShoot()
        Me.ShootTimer.Enabled = False
    End Sub
    Public Sub Shoot() Handles ShootTimer.Tick
        Dim currentTime = Math.Round((DateTime.Now - New DateTime(1970, 1, 1)).TotalMilliseconds) '得到目前的毫秒
        Dim bullet As BlueBullet

        If currentTime - Me.PrewShootTime < Me.ShootTimeInterval Then
            Return
        Else
            Me.PrewShootTime = currentTime
        End If

        Select Case Me.Direction
            Case 0
                If Me.Y - 20 >= 0 Then
                    If Me.AttachedMap.Map(Me.Y / Map.Unit - 2, Me.X / Map.Unit + 2) Is Nothing Then
                        bullet = New BlueBullet(Me, Me.X + 20, Me.Y - 20, Me.Direction)
                    Else
                        bullet = New BlueBullet(Me, 0, Me.AttachedMap.YBound, 2)
                        bullet.Collision(Me.X / Map.Unit + 2, Me.Y / Map.Unit - 2)
                    End If

                End If
            Case 1
                If Me.X + 20 + Me.Width <= Me.AttachedMap.XBound Then
                    If Me.AttachedMap.Map(Me.Y / Map.Unit + 2, Me.X / Map.Unit + 6) Is Nothing Then
                        bullet = New BlueBullet(Me, Me.X + 60, Me.Y + 20, Me.Direction)
                    Else
                        bullet = New BlueBullet(Me, 0, Me.AttachedMap.YBound, 2)
                        bullet.Collision(Me.X / Map.Unit + 6, Me.Y / Map.Unit + 2)
                    End If

                End If

            Case 2
                If Me.Y + 20 + Me.Height <= Me.AttachedMap.YBound Then
                    If Me.AttachedMap.Map(Me.Y / Map.Unit + 5, Me.X / Map.Unit + 2) Is Nothing Then
                        bullet = New BlueBullet(Me, Me.X + 20, Me.Y + 50, Me.Direction)
                    Else
                        bullet = New BlueBullet(Me, 0, Me.AttachedMap.YBound, 2)
                        bullet.Collision(Me.X / Map.Unit + 2, Me.Y / Map.Unit + 5)
                    End If

                End If

            Case 3
                If Me.X - 20 >= 0 Then
                    If Me.AttachedMap.Map(Me.Y / Map.Unit + 2, Me.X / Map.Unit - 2) Is Nothing Then
                        bullet = New BlueBullet(Me, Me.X - 20, Me.Y + 20, Me.Direction)
                    Else
                        bullet = New BlueBullet(Me, 0, Me.AttachedMap.YBound, 2)
                        bullet.Collision(Me.X / Map.Unit - 2, Me.Y / Map.Unit + 2)
                    End If
                End If
        End Select
    End Sub

    Protected Overrides Sub CheckCollision() Handles MoveTimer.Tick
        MyBase.CheckCollision()
    End Sub

    Protected Overrides Sub EnergyRecover() Handles EnergyRecoveryTimer.Tick
        MyBase.EnergyRecover()
    End Sub

    Private Sub ShowUltiPic()
        Me.AttachedMap.Form.BackgroundImage = My.Resources.BlueUltimate
    End Sub
    Public Overrides Sub StartUltimate()
        If Me.isUltimateWork Then
            Return
        End If

        If Me.Energy <> 100 Then
            My.Computer.Audio.Play(My.Resources.Nope, AudioPlayMode.Background)
            Return
        End If

        RemoveHandler Me.AttachedMap.Form.KeyDown, AddressOf Me.AttachedMap.MainTankMove
        RemoveHandler Me.AttachedMap.Form.KeyUp, AddressOf Me.AttachedMap.MainTankStop
        Me.StopMove()
        Me.AttachedMap.StopVirus()
        Me.AttachedMap.Form.BackgroundImage = My.Resources.BlueUltimate
        My.Computer.Audio.Play(My.Resources.我現在要出征, AudioPlayMode.Background) '播放音源

        Delay(1500)
        AddHandler Me.AttachedMap.Form.KeyDown, AddressOf Me.AttachedMap.MainTankMove
        AddHandler Me.AttachedMap.Form.KeyUp, AddressOf Me.AttachedMap.MainTankStop
        Me.AttachedMap.StartVirus()
        Me.isUltimateWork = True
        Me.EnergyRecoveryTimer.Enabled = False
        Me.MoveTimer.Interval = 10
        Me.ShootTimeInterval = 150
        Me.UltimateTimer.Enabled = True


    End Sub

    Private Sub Ultimate() Handles UltimateTimer.Tick
        Me.Energy -= 10
        Me.AttachedMap.EnergyBar.Width = Me.Energy / Tank.EnergyMax * Me.AttachedMap.EnergyBarMaxLength

        If Me.Energy = 0 Then
            Me.AttachedMap.Form.BackgroundImage = Me.AttachedMap.BackGroundImg
            Me.isUltimateWork = False
            Me.EnergyRecoveryTimer.Enabled = True
            Me.MoveTimer.Interval = 30
            Me.ShootTimeInterval = 300
            Me.UltimateTimer.Enabled = False
            My.Computer.Audio.Play(My.Resources.溜之大吉, AudioPlayMode.Background) '播放音源
        End If

    End Sub
End Class
