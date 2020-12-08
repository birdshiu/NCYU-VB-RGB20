Public Class Instance
    Public X As Integer
    Public Y As Integer
    Public Height As Integer
    Public Width As Integer
    Public AttachedMap As Map
    Public Life As Integer
    Public Damage As Integer
    Public isInevitable As Boolean
    Public hasMoveDamage As Boolean
    Public canMove As Boolean
    Public LifeMax As Integer
    Public Img As PictureBox
    Protected Sub SetLocation(X As Integer, Y As Integer)
        Me.X = X
        Me.Y = Y
    End Sub
    Protected Overridable Sub Move()
    End Sub
    Protected Overridable Sub CheckCollision()
    End Sub
    Public Overridable Sub Collision(X As Integer, Y As Integer)
    End Sub

    Public Overridable Sub Damaged(instance As Instance)
    End Sub
End Class
