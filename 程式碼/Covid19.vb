Public Class Covid19
    Inherits Instance
    Dim Direction As Integer
    'Public Img As PictureBox
    Dim type As Integer
    Dim steal As Integer
    Dim stealth1 As Integer
    Dim stealth2 As Integer
    Dim number As Integer = 0
    Dim picture As Integer
    Public WithEvents covidmove0 As Windows.Forms.Timer
    Public WithEvents covidmove1 As Windows.Forms.Timer
    Public WithEvents covidmove2 As Windows.Forms.Timer
    Public WithEvents covidmove3 As Windows.Forms.Timer
    Public WithEvents covidmove4 As Windows.Forms.Timer
    Public WithEvents covidmove5 As Windows.Forms.Timer
    Public WithEvents covidmove6 As Windows.Forms.Timer
    Dim rand As Random
    Sub New(X As Integer, Y As Integer, life As Integer, damage As Integer, moveInterval As Integer, stealth As Integer, pic As Integer)
        Form1.virus += 1
        Me.SetLocation(X, Y)
        steal = stealth
        Height = 50
        Width = 50
        picture = pic
        Me.Img = New PictureBox()
        Me.Img.Top = Y
        Me.Img.Left = X
        If picture = 0 Then
            Me.Img.Image = My.Resources.Covid19
        ElseIf picture = 4 Then
            Me.Img.Image = My.Resources.Covid19boss
        ElseIf picture = 5 Then
            Me.Img.Image = My.Resources.Covid19str
        End If
        Me.Img.BackColor = Color.Transparent
        Me.Img.SizeMode = PictureBoxSizeMode.StretchImage
        Me.Img.Size = New Point(50, 50)

        Me.covidmove0 = New Timer()
        Me.covidmove1 = New Timer()
        Me.covidmove2 = New Timer()
        Me.covidmove3 = New Timer()
        Me.covidmove4 = New Timer()
        Me.covidmove5 = New Timer()
        Me.covidmove6 = New Timer()
        rand = New Random
        If steal = 1 Then
            covidmove5.Enabled = True
        Else covidmove5.Enabled = False

        End If
        covidmove6.Enabled = False
        covidmove0.Enabled = True
        covidmove0.Interval = moveInterval
        covidmove1.Interval = moveInterval
        covidmove2.Interval = moveInterval
        covidmove3.Interval = moveInterval
        covidmove4.Interval = moveInterval

        Me.Life = life
        Me.hasMoveDamage = True
        Me.Damage = damage
    End Sub
    Sub move5() Handles covidmove5.Tick
        Me.Img.Image = Nothing
        covidmove6.Interval = (Me.rand.Next() Mod 10) * 50 + 2000
        covidmove5.Enabled = False
        covidmove6.Enabled = True
    End Sub
    Sub move6() Handles covidmove6.Tick
        If picture = 0 Then
            Me.Img.Image = My.Resources.Covid19
        ElseIf picture = 5 Then
            Me.Img.Image = My.Resources.Covid19str
        End If
        covidmove5.Interval = (Me.rand.Next() Mod 10) * 300 + 1000 '出現時間
        covidmove6.Enabled = False
        covidmove5.Enabled = True
    End Sub
    Public Overrides Sub Damaged(instance As Instance)
        If Me.Life > instance.Damage Then
            Me.Life -= instance.Damage
        Else
            covidmove0.Enabled = False
            covidmove1.Enabled = False
            covidmove2.Enabled = False
            covidmove3.Enabled = False
            covidmove4.Enabled = False
            Me.AttachedMap.Remove(Me)
        End If
    End Sub
    Protected Overrides Sub Move() Handles covidmove0.Tick
        Randomize()
        Direction = Fix(Rnd() * 4) Mod 4
        If Direction = 0 Then
            covidmove0.Enabled = False
            covidmove1.Enabled = True
        ElseIf Direction = 1 Then
            covidmove0.Enabled = False
            covidmove2.Enabled = True
        ElseIf Direction = 2 Then
            covidmove0.Enabled = False
            covidmove3.Enabled = True
        ElseIf Direction = 3 Then
            covidmove0.Enabled = False
            covidmove4.Enabled = True
        End If
    End Sub
    Sub move0() Handles covidmove1.Tick
        Dim instance As Instance
        If picture = 1 Then
            Me.Img.Image = My.Resources.blueTankTop

        ElseIf picture = 2 Then
            Me.Img.Image = My.Resources.greenTankTop

        ElseIf picture = 3 Then
            Me.Img.Image = My.Resources.bearTop
        End If
        If Me.Y - Map.Unit >= 0 Then
            For i As Integer = (Me.X / Map.Unit) To (Me.X / Map.Unit + 4) Step 1
                If Not (Me.AttachedMap.Map((Me.Y - Map.Unit) / Map.Unit, i) Is Nothing) Then ' Or Me.Y - Map.Unit = 0 Then
                    instance = Me.AttachedMap.Map((Me.Y - Map.Unit) / Map.Unit, i)
                    If TypeOf instance Is Tank Then
                        instance.Damaged(Me)
                        Return
                    End If
                    covidmove1.Enabled = False
                    covidmove0.Enabled = True
                    Return
                End If
            Next

            For i As Integer = (Me.X / Map.Unit) To (Me.X / Map.Unit + 4) Step 1
                Me.AttachedMap.Map(Me.Y / Map.Unit - 1, i) = Me
                Me.AttachedMap.Map(Me.Y / Map.Unit + 4, i) = Nothing
            Next

            Me.Y -= Map.Unit
            Me.Img.Top -= Map.Unit
        Else
            covidmove1.Enabled = False
            covidmove0.Enabled = True
        End If
    End Sub
    Sub move1() Handles covidmove2.Tick
        Dim instance As Instance
        If picture = 1 Then
            Me.Img.Image = My.Resources.blueTankRight

        ElseIf picture = 2 Then
            Me.Img.Image = My.Resources.greenTankRight

        ElseIf picture = 3 Then
            Me.Img.Image = My.Resources.bearRight

        End If
        If Me.X + Map.Unit + Me.Width <= AttachedMap.XBound Then
            For i As Integer = (Me.Y / Map.Unit) To (Me.Y / Map.Unit + 4) Step 1
                If Not (Me.AttachedMap.Map(i, Me.X / Map.Unit + 5) Is Nothing) Then ' Or Me.X + Map.Unit = AttachedMap.XBound Then
                    instance = Me.AttachedMap.Map(i, Me.X / Map.Unit + 5)
                    If TypeOf instance Is Tank Then
                        instance.Damaged(Me)
                        Return
                    End If
                    covidmove2.Enabled = False
                    covidmove0.Enabled = True
                    Return
                End If
            Next
            For i As Integer = (Me.Y / Map.Unit) To (Me.Y / Map.Unit + 4) Step 1
                Me.AttachedMap.Map(i, Me.X / Map.Unit + 5) = Me
                Me.AttachedMap.Map(i, Me.X / Map.Unit) = Nothing
            Next

            Me.X += Map.Unit
            Me.Img.Left += Map.Unit
        Else
            covidmove2.Enabled = False
            covidmove0.Enabled = True
        End If
    End Sub
    Sub move2() Handles covidmove3.Tick
        Dim instance As Instance
        If picture = 1 Then
            Me.Img.Image = My.Resources.blueTankDown

        ElseIf picture = 2 Then
            Me.Img.Image = My.Resources.greenTankDown

        ElseIf picture = 3 Then
            Me.Img.Image = My.Resources.bearDown

        End If
        If Me.Y + Map.Unit + Me.Height <= AttachedMap.YBound Then
            For i As Integer = (Me.X / Map.Unit) To (Me.X / Map.Unit + 4) Step 1
                If Not Me.AttachedMap.Map(Me.Y / Map.Unit + 5, i) Is Nothing Then 'Or Me.Y + Map.Unit = AttachedMap.YBound Then
                    instance = Me.AttachedMap.Map(Me.Y / Map.Unit + 5, i)
                    If TypeOf instance Is Tank Then
                        instance.Damaged(Me)
                        Return
                    End If
                    covidmove3.Enabled = False
                    covidmove0.Enabled = True
                    Return

                End If
            Next
            For i As Integer = Me.X / Map.Unit To Me.X / Map.Unit + 4
                Me.AttachedMap.Map(Me.Y / Map.Unit + 5, i) = Me
                Me.AttachedMap.Map(Me.Y / Map.Unit, i) = Nothing
            Next

            Me.Y += Map.Unit
            Me.Img.Top += Map.Unit
        Else
            covidmove3.Enabled = False
            covidmove0.Enabled = True
        End If
    End Sub
    Sub move3() Handles covidmove4.Tick
        Dim instance As Instance
        If picture = 1 Then
            Me.Img.Image = My.Resources.blueTankLeft

        ElseIf picture = 2 Then
            Me.Img.Image = My.Resources.greenTankLeft

        ElseIf picture = 3 Then
            Me.Img.Image = My.Resources.bearLeft

        End If
        If Me.X - Map.Unit >= 0 Then
            For i As Integer = (Me.Y / Map.Unit) To (Me.Y / Map.Unit + 4) Step 1
                If Not (Me.AttachedMap.Map(i, Me.X / Map.Unit - 1) Is Nothing) Then ' Or Me.X - Map.Unit = 0 Then
                    instance = Me.AttachedMap.Map(i, Me.X / Map.Unit - 1)
                    If TypeOf instance Is Tank Then
                        instance.Damaged(Me)
                        Return
                    End If
                    covidmove4.Enabled = False
                    covidmove0.Enabled = True
                    Return
                End If
            Next
            For i As Integer = (Me.Y / Map.Unit) To (Me.Y / Map.Unit + 4) Step 1
                Me.AttachedMap.Map(i, Me.X / Map.Unit + -1) = Me
                Me.AttachedMap.Map(i, Me.X / Map.Unit + 4) = Nothing
            Next
            Me.X -= Map.Unit
            Me.Img.Left -= Map.Unit
        Else
            covidmove4.Enabled = False
            covidmove0.Enabled = True
        End If
    End Sub
End Class
