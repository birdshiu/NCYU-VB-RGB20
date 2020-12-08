Public Class StarlightBrick
    Inherits Brick

    Private WithEvents ShowTimer As Windows.Forms.Timer
    Private WithEvents HideTimer As Windows.Forms.Timer
    Private Rand As Random

    Public Sub New(X As Integer, Y As Integer)
        MyBase.New(X, Y)

        Me.isInevitable = True
        Me.Life = 10000
        Me.Img.Image = My.Resources.StarlightBrick

        Me.Rand = New Random()

        Me.ShowTimer = New Windows.Forms.Timer()
        Me.ShowTimer.Interval = 4000
        Me.ShowTimer.Enabled = True
        Me.HideTimer = New Windows.Forms.Timer()
        Me.HideTimer.Interval = (Me.Rand.Next() Mod 10) * 500 + 1000
        Me.HideTimer.Enabled = False

    End Sub
    Public Sub New(X As Integer, Y As Integer, width As Integer, height As Integer)
        MyBase.New(X, Y)

        Me.Height = height
        Me.Width = width

        Me.Img.Size = New Point(width, height)
        Me.isInevitable = True
        Me.Life = 10000
        Me.Img.Image = My.Resources.StarlightBrick

        Me.Rand = New Random()

        Me.ShowTimer = New Windows.Forms.Timer()
        Me.ShowTimer.Interval = 4000
        Me.ShowTimer.Enabled = True
        Me.HideTimer = New Windows.Forms.Timer()
        Me.HideTimer.Interval = (Me.Rand.Next() Mod 10) * 500 + 1000
        Me.HideTimer.Enabled = False

    End Sub

    Private Sub Show() Handles ShowTimer.Tick
        Me.ShowTimer.Enabled = False
        Me.AttachedMap.Hide(Me)
        Me.HideTimer.Interval = (Me.Rand.Next() Mod 10) * 500 + 1000
        Me.HideTimer.Enabled = True
    End Sub

    Private Sub Hide() Handles HideTimer.Tick
        For i As Integer = Me.Y / Map.Unit To Me.Y / Map.Unit + Me.Height / Map.Unit - 1
            For j As Integer = Me.X / Map.Unit To Me.X / Map.Unit + Me.Width / Map.Unit - 1
                If Not (Me.AttachedMap.Map(i, j) Is Nothing) Then
                    Me.HideTimer.Interval = 250
                    Return
                End If
            Next
        Next

        Me.HideTimer.Enabled = False
        Me.AttachedMap.Show(Me)
        Me.ShowTimer.Enabled = True
    End Sub
End Class
