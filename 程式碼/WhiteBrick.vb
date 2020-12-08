Public Class WhiteBrick
    Inherits Brick

    Public Sub New(X As Integer, Y As Integer)
        MyBase.New(X, Y)

        Me.isInevitable = True
        Me.Img.Image = My.Resources.WhiteBrick

        Me.Life = 10000

    End Sub

    Public Sub New(X As Integer, Y As Integer, width As Integer, height As Integer)
        MyBase.New(X, Y)

        Me.Height = height
        Me.Width = width

        Me.Img.Size = New Point(width, height)

        Me.isInevitable = True
        Me.Img.Image = My.Resources.WhiteBrick


    End Sub

End Class
