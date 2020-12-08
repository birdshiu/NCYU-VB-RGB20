Public Class WinnieBullet
    Inherits Bullet

    Public AttachedTank As WinnieTank
    Private EnemyHashSet As HashSet(Of Instance)
    Public Sub New(tank As Tank, X As Integer, Y As Integer, dir As Integer)
        MyBase.New(X, Y, dir)

        Me.AttachedTank = tank
        Me.AttachedMap = Me.AttachedTank.AttachedMap
        Me.AttachedMap.Attach(Me)

        EnemyHashSet = New HashSet(Of Instance)

        If Me.AttachedTank.isUltimateWork Then
            Me.MoveTimer.Interval = 20
        Else
            Me.MoveTimer.Interval = 50
        End If

        Me.Damage = 50

        Select Case dir
            Case 0
                Me.Height = 20
                Me.Width = 10
                Me.Img.Image = My.Resources.bearBulletTop
            Case 1
                Me.Height = 10
                Me.Width = 20
                Me.Img.Image = My.Resources.bearBulletRight
            Case 2
                Me.Height = 20
                Me.Width = 10
                Me.Img.Image = My.Resources.bearBulletDown
            Case 3
                Me.Height = 10
                Me.Width = 20
                Me.Img.Image = My.Resources.bearBulletLeft
        End Select
        Me.Img.Size = New Point(Me.Width, Me.Height)
    End Sub

    Protected Overrides Sub CheckCollision() Handles MoveTimer.Tick
        If Me.AttachedTank.canShoot = True Then
            Me.Explode()
            Return
        End If

        Select Case Me.Direction
            Case 0
                If Me.Y - Map.Unit <= 0 Then
                    Explode()
                    Return
                End If

                For i As Integer = (Me.X / Map.Unit) To (Me.X / Map.Unit + Me.Width / Map.Unit - 1)
                    If Not (Me.AttachedMap.Map(Me.Y / Map.Unit - 1, i) Is Nothing) Then
                        Explode()
                        Return
                    End If
                Next

            Case 1
                If Me.X + Map.Unit + Width >= Me.AttachedMap.XBound Then
                    Explode()
                    Return
                End If

                For i As Integer = (Me.Y / Map.Unit) To (Me.Y / Map.Unit + Me.Height / Map.Unit - 1)
                    If Not (Me.AttachedMap.Map(i, Me.X / Map.Unit + Me.Width / Map.Unit) Is Nothing) Then
                        Explode()
                        Return
                    End If
                Next

            Case 2
                If Me.Y + Map.Unit + Height > Me.AttachedMap.YBound Then
                    Me.Explode()
                    Return
                End If

                For i As Integer = (Me.X / Map.Unit) To (Me.X / Map.Unit + Me.Width / Map.Unit - 1)
                    If Not (Me.AttachedMap.Map(Me.Y / Map.Unit + Me.Height / Map.Unit, i) Is Nothing) Then
                        Explode()
                        Return
                    End If
                Next

            Case 3
                If Me.X - Map.Unit <= 0 Then
                    Explode()
                    Return
                End If

                For i As Integer = (Me.Y / Map.Unit) To (Me.Y / Map.Unit + Me.Height / Map.Unit - 1)
                    If Not (Me.AttachedMap.Map(i, Me.X / Map.Unit - 1) Is Nothing) Then
                        Explode()
                        Return
                    End If
                Next
        End Select
        Move()
    End Sub

    Private Sub Explode()
        If Not (Me.AttachedTank.isUltimateWork) Then
            My.Computer.Audio.Play(My.Resources.WinnieBulletExplode, AudioPlayMode.Background)
        End If

        Dim XStart, XEnd, YStart, YEnd As Integer
        Me.MoveTimer.Enabled = False
        Select Case Me.Direction
            Case 0
                XStart = Me.X - 70
                YStart = Me.Y - 80
                Me.AttachedTank.ShowExplode(XStart, YStart)
            Case 1
                XStart = Me.X - 50
                YStart = Me.Y - 70
                Me.AttachedTank.ShowExplode(XStart, YStart)
            Case 2
                XStart = Me.X - 70
                YStart = Me.Y - 50
                Me.AttachedTank.ShowExplode(XStart, YStart)
            Case 3
                XStart = Me.X - 70
                YStart = Me.Y - 80
                Me.AttachedTank.ShowExplode(XStart, YStart)
        End Select

        XEnd = XStart + 140
        YEnd = YStart + 140

        If XStart < 0 Then
            XStart = 0
        End If
        If YStart < 0 Then
            YStart = 0
        End If
        If XEnd > Me.AttachedMap.XBound Then
            XEnd = Me.AttachedMap.XBound
        End If
        If YEnd > Me.AttachedMap.YBound Then
            YEnd = Me.AttachedMap.YBound
        End If

        For i As Integer = YStart / Map.Unit To YEnd / Map.Unit Step 2
            For j As Integer = XStart / Map.Unit To XEnd / Map.Unit Step 2
                Collision(j, i)
            Next
        Next

        Me.MoveTimer.Enabled = False
        Me.AttachedMap.Remove(Me)
    End Sub
    Public Overrides Sub Collision(X As Integer, Y As Integer)
        Dim instance As Instance = Me.AttachedTank.AttachedMap.Map(Y, X)
        If instance Is Nothing Then
            Return
        End If

        If Not (EnemyHashSet.Contains(instance)) Then
            EnemyHashSet.Add(instance)
            instance.Damaged(Me)
        End If
    End Sub
End Class
