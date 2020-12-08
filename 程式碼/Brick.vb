Public Class Brick
    Inherits Instance
    'Public Img As PictureBox
    Public Sub New(X As Integer, Y As Integer)
        Me.SetLocation(X, Y)

        Height = 50
        Width = 50
        Me.Damage = 0

        Me.Img = New PictureBox()
        Me.Img.Top = Y
        Me.Img.Left = X
        Me.Img.SizeMode = PictureBoxSizeMode.StretchImage
        Me.Img.Size = New Point(50, 50)
    End Sub

    Public Overrides Sub Damaged(instance As Instance)
        If Me.isInevitable = True Then
            Return
        End If

        If Me.Life > instance.Damage Then
            Me.Life -= instance.Damage
        Else
            Me.AttachedMap.Remove(Me)
        End If
    End Sub
End Class
