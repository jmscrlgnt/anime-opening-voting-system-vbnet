Imports System.Linq

Module UserStore
    Private ReadOnly Users As New Dictionary(Of String, Tuple(Of String, String))(StringComparer.OrdinalIgnoreCase)
    Private isInitialized As Boolean = False

    Private Sub EnsureInitialized()
        If isInitialized Then Return

        Users("Asser") = Tuple.Create("jmscrlgnt", "asser@example.com")
        Users("Group1") = Tuple.Create("password12", "group1@example.com")
        isInitialized = True
    End Sub

    Public Function ValidateUser(username As String, password As String) As Boolean
        EnsureInitialized()

        If String.IsNullOrWhiteSpace(username) OrElse String.IsNullOrWhiteSpace(password) Then
            Return False
        End If

        Return Users.ContainsKey(username) AndAlso Users(username).Item1 = password
    End Function

    Public Function RegisterUser(username As String, email As String, password As String, ByRef errorMessage As String) As Boolean
        EnsureInitialized()

        If Users.ContainsKey(username) Then
            errorMessage = "Username already exists. Please choose another one."
            Return False
        End If

        If Users.Values.Any(Function(user) user.Item2.Equals(email, StringComparison.OrdinalIgnoreCase)) Then
            errorMessage = "Email is already registered. Please use another email."
            Return False
        End If

        Users(username) = Tuple.Create(password, email)
        errorMessage = String.Empty
        Return True
    End Function

    Public Function UsernameExists(username As String) As Boolean
        EnsureInitialized()
        Return Users.ContainsKey(username)
    End Function

    Public Function EmailMatchesUsername(username As String, email As String) As Boolean
        EnsureInitialized()

        If Not Users.ContainsKey(username) Then
            Return False
        End If

        Return Users(username).Item2.Equals(email, StringComparison.OrdinalIgnoreCase)
    End Function
End Module
