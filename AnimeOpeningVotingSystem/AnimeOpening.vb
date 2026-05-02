Imports System.IO
Imports System.Threading

Public Class AnimeOpening
    Public Property VideoFilePath As String

    Private Sub AnimeOpening_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterScreen

        If String.IsNullOrWhiteSpace(VideoFilePath) Then
            MessageBox.Show("No video file was selected.", "Missing Video", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Close()
            Return
        End If

        If Not File.Exists(VideoFilePath) Then
            MessageBox.Show("Video file not found:" & Environment.NewLine & VideoFilePath & Environment.NewLine & Environment.NewLine & "Upload the missing file again to the Project Videos folder.", "Missing Video", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Close()
            Return
        End If

        AxWindowsMediaPlayer1.URL = VideoFilePath
        AxWindowsMediaPlayer1.Ctlcontrols.play()

        Dim t As New Thread(Sub()
                                Thread.Sleep(500)
                                If Not IsDisposed AndAlso IsHandleCreated Then
                                    Invoke(New Action(Sub() AxWindowsMediaPlayer1.fullScreen = False))
                                End If
                            End Sub)
        t.IsBackground = True
        t.Start()
    End Sub
End Class
