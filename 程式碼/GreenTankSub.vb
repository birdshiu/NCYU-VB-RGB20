Public Class GreenTankSub
    Inherits Tank
    Dim Rand As Random

    Public Sub New(X As Integer, Y As Integer, dir As Integer)
        MyBase.New(X, Y)

        Me.Rand = New Random()

        Me.MoveTimer.Interval = 100
        Me.LifeMax = 60
        Me.Life = 60

        Me.Img.Image = My.Resources.greenTankSub

        Me.StartMove()
    End Sub

    Protected Overrides Sub CheckCollision() Handles MoveTimer.Tick
        Dim instance As Instance

        If canMove = False Then
            Return
        End If

        Select Case Me.Direction
            Case 0
                If Me.Y - Map.Unit < 0 Then
                    Me.Direction = Rand.Next() Mod 4
                    Return
                End If
                For i As Integer = (Me.X / Map.Unit) To (Me.X / Map.Unit + Width / Map.Unit - 1) Step 1
                    If Not (Me.AttachedMap.Map((Me.Y - Map.Unit) / Map.Unit, i) Is Nothing) Then
                        instance = Me.AttachedMap.Map((Me.Y - Map.Unit) / Map.Unit, i)
                        If instance.hasMoveDamage Then
                            Me.Damaged(instance)
                        End If
                        Me.Direction = Rand.Next() Mod 4
                        Return
                    End If
                Next i
            Case 1
                If Me.X + Map.Unit + Width > AttachedMap.XBound Then
                    Me.Direction = Rand.Next() Mod 4
                    Return
                End If
                For i As Integer = (Me.Y / Map.Unit) To (Me.Y / Map.Unit + Height / Map.Unit - 1) Step 1
                    If Not (Me.AttachedMap.Map(i, Me.X / Map.Unit + Width / Map.Unit) Is Nothing) Then
                        instance = Me.AttachedMap.Map(i, Me.X / Map.Unit + Width / Map.Unit)
                        If instance.hasMoveDamage Then
                            Me.Damaged(instance)
                        End If
                        Me.Direction = Rand.Next() Mod 4
                        Return
                    End If
                Next i
            Case 2
                If Me.Y + Map.Unit + Height > AttachedMap.YBound Then
                    Me.Direction = Rand.Next() Mod 4
                    Return
                End If
                For i As Integer = (Me.X / Map.Unit) To (Me.X / Map.Unit + 4) Step 1
                    If Not (Me.AttachedMap.Map(Me.Y / Map.Unit + 5, i) Is Nothing) Then
                        instance = Me.AttachedMap.Map(Me.Y / Map.Unit + 5, i)
                        If instance.hasMoveDamage Then
                            Me.Damaged(instance)
                        End If
                        Me.Direction = Rand.Next() Mod 4
                        Return
                    End If
                Next i
            Case 3
                If Me.X - Map.Unit < 0 Then
                    Me.Direction = Rand.Next() Mod 4
                    Return
                End If
                For i As Integer = (Me.Y / Map.Unit) To (Me.Y / Map.Unit + 4) Step 1
                    If Not (Me.AttachedMap.Map(i, Me.X / Map.Unit - 1) Is Nothing) Then
                        instance = Me.AttachedMap.Map(i, Me.X / Map.Unit - 1)
                        If instance.hasMoveDamage Then
                            Me.Damaged(instance)
                        End If
                        Me.Direction = Rand.Next() Mod 4
                        Return
                    End If
                Next i
        End Select
        Move()
    End Sub

    Public Overrides Sub StartShoot()
        Dim bullet As GreenBullet

        If Me.Y - 20 >= 0 Then
            If Me.AttachedMap.Map(Me.Y / Map.Unit - 2, Me.X / Map.Unit + 2) Is Nothing Then
                bullet = New GreenBullet(Me, Me.X + 20, Me.Y - 20, 0)
            Else
                bullet = New GreenBullet(Me, 0, Me.AttachedMap.YBound, 2)
                bullet.Collision(Me.X / Map.Unit + 2, Me.Y / Map.Unit - 2)
            End If

        End If

        If Me.X + 20 + Me.Width <= Me.AttachedMap.XBound Then
            If Me.AttachedMap.Map(Me.Y / Map.Unit + 2, Me.X / Map.Unit + 6) Is Nothing Then
                bullet = New GreenBullet(Me, Me.X + 60, Me.Y + 20, 1)
            Else
                bullet = New GreenBullet(Me, 0, Me.AttachedMap.YBound, 2)
                bullet.Collision(Me.X / Map.Unit + 6, Me.Y / Map.Unit + 2)
            End If

        End If

        If Me.Y + 20 + Me.Height <= Me.AttachedMap.YBound Then
            If Me.AttachedMap.Map(Me.Y / Map.Unit + 5, Me.X / Map.Unit + 2) Is Nothing Then
                bullet = New GreenBullet(Me, Me.X + 20, Me.Y + 50, 2)
            Else
                bullet = New GreenBullet(Me, 0, Me.AttachedMap.YBound, 2)
                bullet.Collision(Me.X / Map.Unit + 2, Me.Y / Map.Unit + 5)
            End If

        End If

        If Me.X - 20 >= 0 Then
            If Me.AttachedMap.Map(Me.Y / Map.Unit + 2, Me.X / Map.Unit - 2) Is Nothing Then
                bullet = New GreenBullet(Me, Me.X - 20, Me.Y + 20, 3)
            Else
                bullet = New GreenBullet(Me, 0, Me.AttachedMap.YBound, 2)
                bullet.Collision(Me.X / Map.Unit - 2, Me.Y / Map.Unit + 2)
            End If
        End If
    End Sub

    Public Overrides Sub Damaged(instance As Instance)
        If Me.isInevitable = True Then
            Return
        End If

        If Me.Life - instance.Damage <= 0 Then
            Me.MoveTimer.Enabled = False
            Me.AttachedMap.Remove(Me)
        Else
            Me.Life -= instance.Damage
        End If

        Me.StartInevitable()
    End Sub
End Class
