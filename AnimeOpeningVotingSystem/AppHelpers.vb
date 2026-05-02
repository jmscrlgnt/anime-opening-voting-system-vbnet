Imports System.IO

Module AppHelpers
    Public Function GetVideoFolderPath() As String
        Dim startupPath As String = Application.StartupPath
        Dim candidatePaths As String() = {
            Path.Combine(startupPath, "Project Videos"),
            Path.Combine(startupPath, "..", "..", "Project Videos"),
            Path.Combine(startupPath, "..", "..", "..", "Project Videos"),
            Path.Combine(Application.CommonAppDataPath, "Project Videos")
        }

        For Each candidate In candidatePaths
            Dim fullPath = Path.GetFullPath(candidate)
            If Directory.Exists(fullPath) Then
                Return fullPath
            End If
        Next

        Return Path.GetFullPath(candidatePaths(1))
    End Function

    Public Function GetVideoFilePath(fileName As String) As String
        Return Path.Combine(GetVideoFolderPath(), fileName)
    End Function

    Public Function IsValidEmail(email As String) As Boolean
        If String.IsNullOrWhiteSpace(email) Then Return False
        Try
            Dim addr = New Net.Mail.MailAddress(email)
            Return addr.Address.Equals(email, StringComparison.OrdinalIgnoreCase)
        Catch
            Return False
        End Try
    End Function
End Module
