Public Class Bullet
    Inherits Instance

    Public Direction As Integer
    Public WithEvents MoveTimer As Timer
    'Public Img As PictureBox


    Public Sub New(X As Integer, Y As Integer, dir As Integer)
        SetLocation(X, Y)

        Me.Img = New PictureBox()
        Me.Img.Top = Y
        Me.Img.Left = X
        Me.Img.SizeMode = PictureBoxSizeMode.StretchImage
        Me.Img.BackColor = Color.Transparent

        Me.Direction = dir

        Me.MoveTimer = New Timer()
        Me.MoveTimer.Enabled = False

    End Sub

    Protected Overrides Sub Move()
        Select Case Me.Direction
            Case 0
                For i As Integer = (Me.X / Map.Unit) To (Me.X / Map.Unit + Me.Width / Map.Unit - 1)
                    Me.AttachedMap.Map(Me.Y / Map.Unit - 1, i) = Me
                    Me.AttachedMap.Map(Me.Y / Map.Unit + Me.Height / Map.Unit - 1, i) = Nothing
                Next
                Me.Img.Top -= Map.Unit
                Me.Y -= Map.Unit
            Case 1
                For i As Integer = (Me.Y / Map.Unit) To (Me.Y / Map.Unit + Me.Height / Map.Unit - 1)
                    Me.AttachedMap.Map(i, Me.X / Map.Unit + Me.Width / Map.Unit) = Me
                    Me.AttachedMap.Map(i, Me.X / Map.Unit) = Nothing
                Next
                Me.Img.Left += Map.Unit
                Me.X += Map.Unit
            Case 2
                For i As Integer = (Me.X / Map.Unit) To (Me.X / Map.Unit + Me.Width / Map.Unit - 1)
                    Me.AttachedMap.Map(Me.Y / Map.Unit + Me.Height / Map.Unit, i) = Me
                    Me.AttachedMap.Map(Me.Y / Map.Unit, i) = Nothing
                Next
                Me.Img.Top += Map.Unit
                Me.Y += Map.Unit
            Case 3
                For i As Integer = (Me.Y / Map.Unit) To (Me.Y / Map.Unit + Me.Height / Map.Unit - 1)
                    Me.AttachedMap.Map(i, Me.X / Map.Unit - 1) = Me
                    Me.AttachedMap.Map(i, Me.X / Map.Unit + Me.Width / Map.Unit - 1) = Nothing
                Next
                Me.Img.Left -= Map.Unit
                Me.X -= Map.Unit
        End Select
    End Sub
End Class
