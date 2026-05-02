Imports System.Linq

Public Class SignupPage
    Dim draggable As Boolean
    Dim mouseX As Integer
    Dim mouseY As Integer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna2TextBox3.UseSystemPasswordChar = True
        Guna2TextBox4.UseSystemPasswordChar = True
        Me.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Dim loginForm As New LoginForm()
        loginForm.Show()
        Me.Hide()
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Dim username As String = Guna2TextBox2.Text.Trim()
        Dim email As String = Guna2TextBox1.Text.Trim()
        Dim password As String = Guna2TextBox3.Text
        Dim confirmPassword As String = Guna2TextBox4.Text
        Dim registerError As String = String.Empty

        If String.IsNullOrWhiteSpace(username) OrElse
           String.IsNullOrWhiteSpace(email) OrElse
           String.IsNullOrWhiteSpace(password) OrElse
           String.IsNullOrWhiteSpace(confirmPassword) Then
            MessageBox.Show("Please enter all required information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If Not IsValidEmail(email) Then
            MessageBox.Show("Please enter a valid email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If username.Length < 6 OrElse Not username.Any(Function(c) Char.IsUpper(c)) OrElse Not username.Any(Function(c) Char.IsDigit(c)) Then
            MessageBox.Show("Please enter a username that is at least 6 characters long and contains at least 1 uppercase letter and 1 digit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If password.Length < 8 OrElse password.Count(Function(c) Char.IsDigit(c)) < 2 Then
            MessageBox.Show("Please enter a password that is at least 8 characters long and contains at least 2 digits.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If password <> confirmPassword Then
            MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If Not RegisterUser(username, email, password, registerError) Then
            MessageBox.Show(registerError, "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        MessageBox.Show("Registration successful! You can now log in with your new account.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Guna2TextBox2.Clear()
        Guna2TextBox1.Clear()
        Guna2TextBox3.Clear()
        Guna2TextBox4.Clear()

        Dim loginForm As New LoginForm()
        loginForm.Show()
        Me.Hide()
    End Sub

    Private Sub Guna2CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles Guna2CheckBox1.CheckedChanged
        Guna2TextBox3.UseSystemPasswordChar = Not Guna2CheckBox1.Checked
        Guna2TextBox4.UseSystemPasswordChar = Not Guna2CheckBox1.Checked
    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        draggable = True
        mouseX = Cursor.Position.X - Me.Left
        mouseY = Cursor.Position.Y - Me.Top
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        If draggable Then
            Me.Top = Cursor.Position.Y - mouseY
            Me.Left = Cursor.Position.X - mouseX
        End If
    End Sub

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp
        draggable = False
    End Sub
End Class
