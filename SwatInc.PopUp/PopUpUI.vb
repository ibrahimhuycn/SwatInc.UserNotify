Imports System.ComponentModel
Imports Notify

Public Class PopUpUI
    Implements INotify
#Region "initializations"
    Dim WithEvents AnimationControl As New Timer   'TO CONTROL THE WAY NOTIFICATION SHOWS UP.
    Dim i As Integer = 0                            'COUNTER FOR LOOP USED FOR NOTIFICATION SHOW UP ANIMATION.
    Dim WithEvents LifeTime As New Timer           'TIMER WHICH HANDLES AUTOMATIC CLOSING OF NOTIFICATION. 
    Dim TicksCount As Integer = 0

    Private AlreadyActiveNotificationsNO As Integer = 1 'THIS VARIABLE DETERMINES WHETHER THERE ARE ANY PREVIOUS NOTIFICATIONS
    Private Const NotificationWindowRelocationFactor As Integer = 130 'VERTICAL DISPLACEMENT OF THE NOTIFICATION OF THE NOTIFICATION POPUP IN THE PRESENCE OF 
    'ANOTHER POPUP TO AVOID OVERLAP OF NOTIFICATION POPUP WINDOWS.

    Private Const LifeTimeInMilliseconds As Integer = 1  'THIS IS THE INTERVAL OF THE TIMER WHICH COUNTS DOWN TO CLOSE THE NOTIFICATION.

    Dim IsLocationDefault As Boolean = False 'IF THIS IS TRUE THE NOTIFICATION POPUP WINDOW WILL SET My.Settings.IsRelocateNofitication to FALSE WHILE UNLOADING THE NOTIFICATION
    'THE CURRENT NOTIFICATION POPPED UP. THIS ALLOWS ADJUSTING THE LOCATION OF THE NOTIFICATION WNINDOW SO THAT BOTH THE 
    'NOTIFICATIONS CAN BE SEEN ON SCREEN.

    'VARIABLES TO STORE SCREEN DIAMENTIONS
    Dim NotificationLocation As New Point
    Dim POINT_X As Integer
    Dim POINT_Y As Integer
#End Region

    Private Shared Sub ScreenDiametions(ByRef POINT_X As Integer, ByRef POINT_Y As Integer)
        'GETTING SCREEN WIDTH AND HEIGHT TO DETERMINE THE LOCATION FOR NOTIFICATION.
        POINT_X = Screen.PrimaryScreen.Bounds.Width
        POINT_Y = Screen.PrimaryScreen.Bounds.Height

    End Sub

    Private Sub PopUpUI_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        RegisterNotification(False)
    End Sub

    Public Sub ShowNotification(ByVal sender As Object, ByVal f As EventArgs)
        RegisterNotification(True)

        ScreenDiametions(POINT_X, POINT_Y)

        'SETTING LOCATION RELATIVE TO SCREEN SIZE (POINT_X - 500, POINT_Y)
        NotificationLocation.X = POINT_X - 500
        NotificationLocation.Y = POINT_Y

        Dim e As PopUpEventArgs = f
        Me.Text = e.Title
        LabelControlMessage.Text = e.Message
        LabelControlHeading.Text = e.Heading
        PictureBoxPopUpIcon.Image = Image.FromFile(GetImagePath(e.PngIconName))


        Location = NotificationLocation     'SETTING INITIAL LOCATION OF NOTIFICATION FORM.

        If AnimationControl Is Nothing Then
            AnimationControl = New Timer
            LifeTime = New Timer
        End If
        AnimationControl.Interval = 100     'SETTING INTERVAL FOR ANMATION.


        LifeTime.Interval = LifeTimeInMilliseconds
        LifeTime.Enabled = True
        LifeTime.Start()
        AnimationControl.Enabled = True
        AnimationControl.Start()

        Show()

    End Sub


    Private Sub LifeTime_Tick(sender As Object, e As EventArgs) Handles LifeTime.Tick
        'THIS EVEN IS RAISED WHEN A SPECIFIED TIME HAS ELAPSED AND NOTIFICATION SHOULD CLOSE ON THIS TICK.

        If TicksCount >= 100 Then   'FADING OUT OF THE NOTIFICATION STARTS WHEN THE TIMER TICKS UPTO 100
            If Opacity > 0 Then
                Opacity -= 0.01     'WHEN THE NOTIFICATION IS TRANSPARENT, ITS UNLOADED.
            Else
                RegisterNotification(False)     'NOTIFYING THAT THE NOTIFICATION POP UP  IS UNLOADING.
                LifeTime.Stop()
                LifeTime.Enabled = False
                Close()
            End If

        Else
            TicksCount += 1
        End If

    End Sub

    Private Sub AnimationControl_Tick(sender As Object, e As EventArgs) Handles AnimationControl.Tick

        ScreenDiametions(POINT_X, POINT_Y)
        NotificationLocation.X = POINT_X - 450
        Do Until i = (200 + (AlreadyActiveNotificationsNO * NotificationWindowRelocationFactor))
            NotificationLocation.Y = POINT_Y - i
            Location = NotificationLocation
            i = i + 1
        Loop
        AnimationControl.Stop()
        AnimationControl.Enabled = False
        i = 0
        My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)
    End Sub

    Private Sub RegisterNotification(ByVal IsLoading As Boolean)

        'THIS SUB STILL HAVE SOME BUGS TO FIX. ADD COMMENTS
        Dim ErrorCount As Integer = 0

        Try

            If IsLoading = True Then    'WHEN LOADING A NOTIFICATION
                If My.Settings.IsRelocateNofitication = False Then 'THIS VARIABLE BEING FALSE MEANS THAT THERE IS NO WINDOW AT DEFAULT POSITION
                    My.Settings.IsRelocateNofitication = True
                    IsLocationDefault = True
                Else
                    My.Settings.AlreadyActiveNotificationsMonitor += 1
                End If

            ElseIf IsLoading = False Then   'WHEN UNLOADING A NOTIFICATION

                If IsLocationDefault = True Then        'IF THE NOTIFICATION AT THE DEFAULT LOCATION IS UNLOADING, NEXT NOTIFICATION WILL NOT BE RELOCATED.
                    My.Settings.IsRelocateNofitication = False
                    My.Settings.AlreadyActiveNotificationsMonitor = 0 'IF NOTIFICATION AT DEFAULT LOCATION HAS UNLOADED, THEN NEXT NOTIFICATION SHOULD APPEAR AT DEFAULT LOCATION AND HENCE THIS VARIABLE 
                    'SHOULD RESET.

                Else
                    If My.Settings.AlreadyActiveNotificationsMonitor >= 1 Then
                        My.Settings.AlreadyActiveNotificationsMonitor -= 1
                    Else
                        My.Settings.AlreadyActiveNotificationsMonitor = 0
                    End If
                End If

            End If


        Catch ex As Exception
            'InitiateErrorProcessing.LogManager(ex)  'LOGGING ERROR TO DISK
            MsgBox(String.Format("{0}{1}Error setting notification location.", ex.Message, vbCrLf))
            ErrorCount = 1
        Finally
            If ErrorCount = 1 Then
                AlreadyActiveNotificationsNO = 1
            Else
                AlreadyActiveNotificationsNO = My.Settings.AlreadyActiveNotificationsMonitor
            End If
        End Try
    End Sub

    Private Function GetImagePath(ImageName As String)
        'PURPOSE: PROVIDE COMPLETE PATH FOR A PNG TO BE DISPLAYED AS NOTIFICATION ICON WHEN THIS FUNCTION IS PROVIDED WITH THE IMAGE NAME. THIS AVOIDS HAVING TO CHANGE IMAGE PATH FROM EVERY SINGLE 
        'REFERENCE POINT INCASE THE PATH CHANGES.
        'ALL IMAGES ARE STORED IN A SINGLE DIRECTORY REFFERED TO AS "ImagerRootDir". THE PROVIDED "ImageName As String" IS CONCENCATED AS "ImagePath As String" AND RETURNED.

        Dim ImagerRootDir As String = My.Settings.ImageRootDir
        Dim ImagePath As String = ($"{Application.StartupPath}\Resources\{ImageName}.png")
        Return ImagePath.ToString
    End Function

    Private Sub NotificationInfocus() Handles LabelControlMessage.MouseEnter
        'IF THE CURSOR ENTERS THE UI OF THE NOTIFICATION. THE FADING OUT OF THE NOTIFICATION STOPS.
        'TRANSPARENCY OF THE FORM IS MADE OPAQUE TOO.
        LifeTime.Enabled = False
        Opacity = 100
        'MsgBox("Mouse Enter")

    End Sub

    Private Sub Notification_LostFocus() Handles Me.MouseLeave
        'ON MOUSE LEAVE. THE FADING OUT OF THE NOTIFICATION WILL START.
        LifeTime.Enabled = True
    End Sub

    Private Sub PictureBoxPopUpIcon_Click(sender As Object, e As EventArgs) Handles PictureBoxPopUpIcon.Click

        Dim a As New PopUpUI
        a.ShowNotification(Me, New PopUpEventArgs With {.Heading = "Testing",
                         .Title = "Test PopUp!",
                         .PngIconRefName = IconName.Patient,
                         .Message = $"This is a test message. {AlreadyActiveNotificationsNO}"})
    End Sub

    Public Async Sub InitializePopUps(sender As Object, e As EventArgs) Implements INotify.InitializePopUps
        BackgroundWorkerPopUpDriver.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWorkerPopUpDriver_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorkerPopUpDriver.DoWork

    End Sub
End Class