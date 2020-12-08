Public Class Tank
    Inherits Instance

    Public Const EnergyMax = 100

    Protected WithEvents ShootTimer As Timer
    Protected WithEvents MoveTimer As Timer
    Protected WithEvents InevitableTimer As Timer
    Protected WithEvents UltimateTimer As Windows.Forms.Timer
    Public WithEvents EnergyRecoveryTimer As Timer
    Public Energy As Integer
    Public isUltimateWork As Boolean
    Public Direction As Integer '0 上 1 右 2 下 3 左
    Public ShootTimeInterval As Integer
    Protected PrewShootTime As Long
    'Public Img As PictureBox
    Public ImgState(3) As Bitmap
    Public canShoot As Boolean

    Public Sub New(X As Integer, Y As Integer)
        Me.Img = New PictureBox()
        Me.Img.Top = Y
        Me.Img.Left = X
        Width = 50
        Height = 50
        Me.Img.BackColor = Color.Transparent '去掉背景

        Me.UltimateTimer = New Timer()
        Me.MoveTimer = New Timer()
        Me.ShootTimer = New Timer()
        Me.EnergyRecoveryTimer = New Timer()
        Me.InevitableTimer = New Timer()
        Me.ShootTimer.Interval = 10
        Me.InevitableTimer.Interval = 2000

        Me.Img.Size = New Point(Width, Height)
        Me.Img.SizeMode = PictureBoxSizeMode.StretchImage

        Me.canMove = True
        Me.canShoot = True

        Me.PrewShootTime = 0

        Me.SetLocation(X, Y)

        Me.hasMoveDamage = False
        Me.isInevitable = False
        Me.isUltimateWork = False
    End Sub

    Public Overridable Sub StartShoot()
    End Sub
    Public Overridable Sub StopShoot()
    End Sub

    Public Overridable Sub StartUltimate()
    End Sub

    Protected Overridable Sub EnergyRecover()
        Me.Energy += 10
        If Me.Energy = Tank.EnergyMax Then
            Me.EnergyRecoveryTimer.Enabled = False
        End If

        Me.AttachedMap.EnergyBar.Width = Me.Energy / Tank.EnergyMax * Me.AttachedMap.EnergyBarMaxLength
    End Sub

    Public Overridable Sub StartInevitable()
        Me.isInevitable = True
        Me.InevitableTimer.Enabled = True
    End Sub

    Public Overridable Sub StopInevitable()
        Me.InevitableTimer.Enabled = False
    End Sub

    Private Sub Inevitable() Handles InevitableTimer.Tick
        Me.isInevitable = False
        Me.InevitableTimer.Enabled = False
    End Sub
    Public Sub StartMove()
        Me.MoveTimer.Enabled = True
    End Sub

    Public Sub StopMove()
        Me.MoveTimer.Enabled = False
    End Sub

    Public Sub ChangeDirection(dir As Integer)
        Me.Direction = dir
        Me.Img.Image = Me.ImgState(Me.Direction)
    End Sub

    Protected Overrides Sub CheckCollision()
        Dim instance As Instance

        If canMove = False Then
            Return
        End If

        Select Case Me.Direction
            Case 0
                If Me.Y - Map.Unit < 0 Then
                    Return
                End If
                For i As Integer = (Me.X / Map.Unit) To (Me.X / Map.Unit + Width / Map.Unit - 1) Step 1
                    If Not (Me.AttachedMap.Map((Me.Y - Map.Unit) / Map.Unit, i) Is Nothing) Then
                        instance = Me.AttachedMap.Map((Me.Y - Map.Unit) / Map.Unit, i)
                        If instance.hasMoveDamage Then
                            Me.Damaged(instance)
                        End If
                        Return
                    End If
                Next i
            Case 1
                If Me.X + Map.Unit + Width > AttachedMap.XBound Then
                    Return
                End If
                For i As Integer = (Me.Y / Map.Unit) To (Me.Y / Map.Unit + Height / Map.Unit - 1) Step 1
                    If Not (Me.AttachedMap.Map(i, Me.X / Map.Unit + Width / Map.Unit) Is Nothing) Then
                        instance = Me.AttachedMap.Map(i, Me.X / Map.Unit + Width / Map.Unit)
                        If instance.hasMoveDamage Then
                            Me.Damaged(instance)
                        End If
                        Return
                    End If
                Next i
            Case 2
                If Me.Y + Map.Unit + Height > AttachedMap.YBound Then
                    Return
                End If
                For i As Integer = (Me.X / Map.Unit) To (Me.X / Map.Unit + 4) Step 1
                    If Not (Me.AttachedMap.Map(Me.Y / Map.Unit + 5, i) Is Nothing) Then
                        instance = Me.AttachedMap.Map(Me.Y / Map.Unit + 5, i)
                        If instance.hasMoveDamage Then
                            Me.Damaged(instance)
                        End If
                        Return
                    End If
                Next i
            Case 3
                If Me.X - Map.Unit < 0 Then
                    Return
                End If
                For i As Integer = (Me.Y / Map.Unit) To (Me.Y / Map.Unit + 4) Step 1
                    If Not (Me.AttachedMap.Map(i, Me.X / Map.Unit - 1) Is Nothing) Then
                        instance = Me.AttachedMap.Map(i, Me.X / Map.Unit - 1)
                        If instance.hasMoveDamage Then
                            Me.Damaged(instance)
                        End If
                        Return
                    End If
                Next i
        End Select
        Move()
    End Sub

    Protected Overrides Sub Move()
        Select Case Me.Direction
            Case 0
                For i As Integer = (Me.X / Map.Unit) To (Me.X / Map.Unit + Width / Map.Unit - 1) Step 1
                    Me.AttachedMap.Map(Me.Y / Map.Unit - 1, i) = Me
                    Me.AttachedMap.Map(Me.Y / Map.Unit + Height / Map.Unit - 1, i) = Nothing
                Next

                Me.Y -= Map.Unit
                Me.Img.Top -= Map.Unit
            Case 1
                For i As Integer = (Me.Y / Map.Unit) To (Me.Y / Map.Unit + Height / Map.Unit - 1) Step 1
                    Me.AttachedMap.Map(i, Me.X / Map.Unit + Width / Map.Unit) = Me
                    Me.AttachedMap.Map(i, Me.X / Map.Unit) = Nothing
                Next

                Me.X += Map.Unit
                Me.Img.Left += Map.Unit
            Case 2
                For i As Integer = (Me.X / Map.Unit) To (Me.X / Map.Unit + 4) Step 1
                    Me.AttachedMap.Map(Me.Y / Map.Unit + 5, i) = Me
                    Me.AttachedMap.Map(Me.Y / Map.Unit, i) = Nothing
                Next

                Me.Y += Map.Unit
                Me.Img.Top += Map.Unit
            Case 3
                For i As Integer = (Me.Y / Map.Unit) To (Me.Y / Map.Unit + 4) Step 1
                    Me.AttachedMap.Map(i, Me.X / Map.Unit - 1) = Me
                    Me.AttachedMap.Map(i, Me.X / Map.Unit + 4) = Nothing
                Next

                Me.X -= Map.Unit
                Me.Img.Left -= Map.Unit
        End Select
    End Sub

    Public Overrides Sub Damaged(instance As Instance)
        If Me.isInevitable = True Then
            Return
        End If

        Me.StartInevitable()

        My.Computer.Audio.Play(My.Resources.OHOH, AudioPlayMode.Background) '播放音源

        If Me.Life > instance.Damage Then
            Me.Life -= instance.Damage
        Else
            Me.AttachedMap.LifeBar.Width = 0
            Me.AttachedMap.LifeBar.Visible = False

            Me.AttachedMap.Remove(Me)
            If MsgBox("你輸了") = 1 Then
                Me.AttachedMap.EndMap()
            End If


        End If

        Me.AttachedMap.LifeBar.Width = Me.AttachedMap.LifeBarMaxLength * Me.Life / Me.LifeMax

        Dim preDirection As Integer = Me.Direction

        If TypeOf instance Is WinnieBullet Then
            Select Case Me.Direction
                Case 0
                    Me.ChangeDirection(2)
                Case 1
                    Me.ChangeDirection(3)
                Case 2
                    Me.ChangeDirection(0)
                Case 3
                    Me.ChangeDirection(1)
            End Select
        Else
            If Me.Y - instance.Y >= 50 Then
                Me.ChangeDirection(2)
            ElseIf Me.Y - instance.Y <= -50 Then
                Me.ChangeDirection(0)
            ElseIf Me.X - instance.X >= 50 Then
                Me.ChangeDirection(1)
            ElseIf Me.X - instance.X <= -50 Then
                Me.ChangeDirection(3)
            End If
        End If

        For i As Integer = 0 To 4
            CheckCollision()
        Next

        Me.ChangeDirection(preDirection)
    End Sub

    Sub Delay(theT As Integer)
        Dim Start As Integer = Environment.TickCount()
        Dim TimeLast As Integer = theT ' 要延遲 t 秒,就設為 t *1000
        Do
            If Environment.TickCount() - Start > TimeLast Then Exit Do
            Application.DoEvents() ' 要記得寫這行，不然都在跑迴圈，畫面可能會不見
        Loop
    End Sub
End Class
