Public Class PopUpEventArgs
    Inherits EventArgs
    Public Property Message As String
    Public Property Title As String
    Public WriteOnly Property PngIconRefName As IconName
        Set
            _pngIconName = Value.ToString
        End Set
    End Property

    Private _pngIconName As String
    Public ReadOnly Property PngIconName As String
        Get
            Return _pngIconName
        End Get
    End Property

    Public Property Heading As String
End Class
