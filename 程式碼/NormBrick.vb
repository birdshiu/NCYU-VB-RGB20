Public Class NormBrick
    Inherits Brick

    Private ImgState(2) As Bitmap

    Public Sub New(X As Integer, Y As Integer)
        MyBase.New(X, Y)
        Me.isInevitable = False
        Me.ImgState = {My.Resources.brick3, My.Resources.brick2, My.Resources.brick1}
        Me.Life = 60
        Me.Img.Image = ImgState(2)
    End Sub

    Public Overrides Sub Damaged(instance As Instance)
        MyBase.Damaged(instance)
        Me.Img.Image = ImgState(Me.Life / 60)
    End Sub
End Class
