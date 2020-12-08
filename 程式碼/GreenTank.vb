Imports System.Threading

Public Class GreenTank
    Inherits Tank
    Public SubTanks As List(Of GreenTankSub)
    Public Sub New(X As Integer, Y As Integer)
        MyBase.New(X, Y)
        Me.SubTanks = New List(Of GreenTankSub)

        Me.ImgState = {My.Resources.greenTankTop, My.Resources.greenTankRight, My.Resources.greenTankDown, My.Resources.greenTankLeft}

        Me.Img.Image = ImgState(0)

        Me.MoveTimer.Interval = 50
        Me.ShootTimeInterval = 1000
        Me.EnergyRecoveryTimer.Interval = 1500
        Me.EnergyRecoveryTimer.Enabled = True

        Me.Life = 200
        Me.LifeMax = 200
    End Sub

    Protected Overrides Sub CheckCollision() Handles MoveTimer.Tick
        MyBase.CheckCollision()
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
        Dim bullet As GreenBullet

        If currentTime - Me.PrewShootTime < Me.ShootTimeInterval Then
            Return
        Else
            Me.PrewShootTime = currentTime
        End If

        For Each i In Me.SubTanks
            i.StartShoot()
        Next

        Select Case Me.Direction
            Case 0
                If Me.Y - 20 >= 0 Then
                    If Me.AttachedMap.Map(Me.Y / Map.Unit - 2, Me.X / Map.Unit + 2) Is Nothing Then
                        bullet = New GreenBullet(Me, Me.X + 20, Me.Y - 20, Me.Direction)
                    Else
                        bullet = New GreenBullet(Me, 0, Me.AttachedMap.YBound, 2)
                        bullet.Collision(Me.X / Map.Unit + 2, Me.Y / Map.Unit - 2)
                    End If

                End If
            Case 1
                If Me.X + 20 + Me.Width <= Me.AttachedMap.XBound Then
                    If Me.AttachedMap.Map(Me.Y / Map.Unit + 2, Me.X / Map.Unit + 6) Is Nothing Then
                        bullet = New GreenBullet(Me, Me.X + 60, Me.Y + 20, Me.Direction)
                    Else
                        bullet = New GreenBullet(Me, 0, Me.AttachedMap.YBound, 2)
                        bullet.Collision(Me.X / Map.Unit + 6, Me.Y / Map.Unit + 2)
                    End If

                End If

            Case 2
                If Me.Y + 20 + Me.Height <= Me.AttachedMap.YBound Then
                    If Me.AttachedMap.Map(Me.Y / Map.Unit + 5, Me.X / Map.Unit + 2) Is Nothing Then
                        bullet = New GreenBullet(Me, Me.X + 20, Me.Y + 50, Me.Direction)
                    Else
                        bullet = New GreenBullet(Me, 0, Me.AttachedMap.YBound, 2)
                        bullet.Collision(Me.X / Map.Unit + 2, Me.Y / Map.Unit + 5)
                    End If

                End If

            Case 3
                If Me.X - 20 >= 0 Then
                    If Me.AttachedMap.Map(Me.Y / Map.Unit + 2, Me.X / Map.Unit - 2) Is Nothing Then
                        bullet = New GreenBullet(Me, Me.X - 20, Me.Y + 20, Me.Direction)
                    Else
                        bullet = New GreenBullet(Me, 0, Me.AttachedMap.YBound, 2)
                        bullet.Collision(Me.X / Map.Unit - 2, Me.Y / Map.Unit + 2)
                    End If
                End If
        End Select
    End Sub

    Protected Overrides Sub EnergyRecover() Handles EnergyRecoveryTimer.Tick
        MyBase.EnergyRecover()
    End Sub

    Public Overrides Sub StartUltimate()


        If Me.Energy <> 100 Then
            My.Computer.Audio.Play(My.Resources.Nope, AudioPlayMode.Background)
            Me.AttachedMap.Form.BackgroundImage = Me.AttachedMap.BackGroundImg
            Return
        End If

        If Me.SubTanks.Count = 2 Then
            My.Computer.Audio.Play(My.Resources.Nope, AudioPlayMode.Background)
            Me.AttachedMap.Form.BackgroundImage = Me.AttachedMap.BackGroundImg
            Return
        End If



        Select Case Me.Direction
            Case 0
                If Me.Y - 50 < 0 Then
                    My.Computer.Audio.Play(My.Resources.Nope, AudioPlayMode.Background)
                    Me.AttachedMap.Form.BackgroundImage = Me.AttachedMap.BackGroundImg
                    Return
                End If

                For i As Integer = Me.Y / Map.Unit - 5 To Me.Y / Map.Unit - 1
                    For j As Integer = Me.X / Map.Unit To Me.X / Map.Unit + 4
                        If Me.AttachedMap.Map(i, j) IsNot Nothing Then
                            My.Computer.Audio.Play(My.Resources.Nope, AudioPlayMode.Background)
                            Return
                        End If
                    Next
                Next

                Me.AttachedMap.Attach(New GreenTankSub(Me.X, Me.Y - 50, Me.Direction))
            Case 1
                If Me.X + 100 > Me.AttachedMap.XBound Then
                    My.Computer.Audio.Play(My.Resources.Nope, AudioPlayMode.Background)
                    Me.AttachedMap.Form.BackgroundImage = Me.AttachedMap.BackGroundImg
                    Return
                End If

                For i As Integer = Me.Y / Map.Unit To Me.Y / Map.Unit + 4
                    For j As Integer = Me.X / Map.Unit + 5 To Me.X / Map.Unit + 9
                        If Me.AttachedMap.Map(i, j) IsNot Nothing Then
                            My.Computer.Audio.Play(My.Resources.Nope, AudioPlayMode.Background)
                            Me.AttachedMap.Form.BackgroundImage = Me.AttachedMap.BackGroundImg
                            Return
                        End If
                    Next
                Next

                Me.AttachedMap.Attach(New GreenTankSub(Me.X + 50, Me.Y, Me.Direction))
            Case 2
                If Me.Y + 100 > Me.AttachedMap.YBound Then
                    My.Computer.Audio.Play(My.Resources.Nope, AudioPlayMode.Background)
                    Me.AttachedMap.Form.BackgroundImage = Me.AttachedMap.BackGroundImg
                    Return
                End If

                For i As Integer = Me.Y / Map.Unit + 5 To Me.Y / Map.Unit + 9
                    For j As Integer = Me.X / Map.Unit To Me.X / Map.Unit + 4
                        If Me.AttachedMap.Map(i, j) IsNot Nothing Then
                            My.Computer.Audio.Play(My.Resources.Nope, AudioPlayMode.Background)
                            Me.AttachedMap.Form.BackgroundImage = Me.AttachedMap.BackGroundImg
                            Return
                        End If
                    Next
                Next

                Me.AttachedMap.Attach(New GreenTankSub(Me.X, Me.Y + 50, Me.Direction))
            Case 3
                If Me.X - 50 < 0 Then
                    My.Computer.Audio.Play(My.Resources.Nope, AudioPlayMode.Background)
                    Me.AttachedMap.Form.BackgroundImage = Me.AttachedMap.BackGroundImg
                    Return
                End If

                For i As Integer = Me.Y / Map.Unit To Me.Y / Map.Unit + 4
                    For j As Integer = Me.X / Map.Unit - 5 To Me.X / Map.Unit - 1
                        If Me.AttachedMap.Map(i, j) IsNot Nothing Then
                            My.Computer.Audio.Play(My.Resources.Nope, AudioPlayMode.Background)
                            Me.AttachedMap.Form.BackgroundImage = Me.AttachedMap.BackGroundImg
                            Return
                        End If
                    Next
                Next

                Me.AttachedMap.Attach(New GreenTankSub(Me.X - 50, Me.Y, Me.Direction))
        End Select

        Me.AttachedMap.StopVirus()
        Me.AttachedMap.Form.BackgroundImage = My.Resources.GreenUltimate

        RemoveHandler Me.AttachedMap.Form.KeyDown, AddressOf Me.AttachedMap.MainTankMove
        RemoveHandler Me.AttachedMap.Form.KeyUp, AddressOf Me.AttachedMap.MainTankStop
        Me.StopMove()

        My.Computer.Audio.Play(My.Resources.國家機器, AudioPlayMode.Background)

        Delay(1200)

        AddHandler Me.AttachedMap.Form.KeyDown, AddressOf Me.AttachedMap.MainTankMove
        AddHandler Me.AttachedMap.Form.KeyUp, AddressOf Me.AttachedMap.MainTankStop

        Me.Energy -= 100
        Me.AttachedMap.EnergyBar.Width = (Me.Energy / Tank.EnergyMax) * Me.AttachedMap.EnergyBarMaxLength
        Me.EnergyRecoveryTimer.Enabled = True


        'Thread.Sleep(800)
        Me.AttachedMap.StartVirus()
        Me.AttachedMap.Form.BackgroundImage = Me.AttachedMap.BackGroundImg

    End Sub
End Class
