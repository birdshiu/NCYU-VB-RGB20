Public Class BlueBullet
    Inherits Bullet
    Dim rwork As Integer
    Public AttachedTank As BlueTank
    Public Sub New(tank As Tank, X As Integer, Y As Integer, dir As Integer)
        MyBase.New(X, Y, dir)
        Me.AttachedTank = tank
        Me.AttachedMap = Me.AttachedTank.AttachedMap
        Me.AttachedMap.Attach(Me)

        If Me.AttachedTank.isUltimateWork Then

            rwork = 1
            Me.MoveTimer.Interval = 5
            Me.Damage = 15
        Else
            rwork = 0
            Me.MoveTimer.Interval = 20
            Me.Damage = 10
        End If

        Select Case dir
            Case 0
                Me.Height = 20
                Me.Width = 10
                If rwork = 1 Then
                    Me.Img.Image = My.Resources.toothpick__up
                Else Me.Img.Image = My.Resources.BlueBulletTop
                End If
            Case 1
                Me.Height = 10
                Me.Width = 20
                If rwork = 1 Then
                    Me.Img.Image = My.Resources.toothpick___right
                Else Me.Img.Image = My.Resources.BlueBulletRight
                End If
            Case 2
                Me.Height = 20
                Me.Width = 10
                If rwork = 1 Then
                    Me.Img.Image = My.Resources.toothpick
                Else Me.Img.Image = My.Resources.BlueBulletDown
                End If
            Case 3
                Me.Height = 10
                Me.Width = 20
                If rwork = 1 Then
                    Me.Img.Image = My.Resources.toothpick__left
                Else Me.Img.Image = My.Resources.BlueBulletLeft
                End If
        End Select
        Me.Img.Size = New Point(Me.Width, Me.Height)
    End Sub

    Protected Overrides Sub CheckCollision() Handles MoveTimer.Tick

        Select Case Me.Direction
            Case 0
                If Me.Y - Map.Unit <= 0 Then
                    Me.AttachedMap.Remove(Me)
                    Return
                End If

                For i As Integer = (Me.X / Map.Unit) To (Me.X / Map.Unit + Me.Width / Map.Unit - 1)
                    If Not (Me.AttachedMap.Map(Me.Y / Map.Unit - 1, i) Is Nothing) Then
                        Collision(i, Me.Y / Map.Unit - 1)
                        Return
                    End If
                Next

            Case 1
                If Me.X + Map.Unit + Width >= Me.AttachedMap.XBound Then
                    Me.AttachedMap.Remove(Me)
                    Return
                End If

                For i As Integer = (Me.Y / Map.Unit) To (Me.Y / Map.Unit + Me.Height / Map.Unit - 1)
                    If Not (Me.AttachedMap.Map(i, Me.X / Map.Unit + Me.Width / Map.Unit) Is Nothing) Then
                        Collision(Me.X / Map.Unit + Me.Width / Map.Unit, i)
                        Return
                    End If
                Next

            Case 2
                If Me.Y + Map.Unit + Height > Me.AttachedMap.YBound Then
                    Me.AttachedMap.Remove(Me)
                    Return
                End If

                For i As Integer = (Me.X / Map.Unit) To (Me.X / Map.Unit + Me.Width / Map.Unit - 1)
                    If Not (Me.AttachedMap.Map(Me.Y / Map.Unit + Me.Height / Map.Unit, i) Is Nothing) Then
                        Collision(i, Me.Y / Map.Unit + Me.Height / Map.Unit)
                        Return
                    End If
                Next

            Case 3
                If Me.X - Map.Unit <= 0 Then
                    Me.AttachedMap.Remove(Me)
                    Return
                End If

                For i As Integer = (Me.Y / Map.Unit) To (Me.Y / Map.Unit + Me.Height / Map.Unit - 1)
                    If Not (Me.AttachedMap.Map(i, Me.X / Map.Unit - 1) Is Nothing) Then
                        Collision(Me.X / Map.Unit - 1, i)
                        Return
                    End If
                Next
        End Select
        Move()
    End Sub

    Public Overrides Sub Collision(X As Integer, Y As Integer)
        Dim instance As Instance = Me.AttachedMap.Map(Y, X)
        Me.MoveTimer.Enabled = False
        instance.Damaged(Me)
        Me.AttachedMap.Remove(Me)
    End Sub
End Class
