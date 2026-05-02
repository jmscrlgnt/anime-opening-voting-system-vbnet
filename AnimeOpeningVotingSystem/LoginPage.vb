Public Class LoginForm

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtPassword.UseSystemPasswordChar = True
        Me.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub LnklblPassword_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnklblPassword.LinkClicked
        Dim forgotPasswordForm As New ForgotPassword()
        forgotPasswordForm.Show()
        Me.Hide()
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Dim votingPage As New VotingPage()
        votingPage.Show()
        Me.Hide()
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        Dim adminControlPanel As New AdminControlPanel()
        adminControlPanel.Show()
        Me.Hide()
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Dim enteredUsername As String = txtUsername.Text.Trim()
        Dim enteredPassword As String = txtPassword.Text

        If ValidateUser(enteredUsername, enteredPassword) Then
            MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Hide()

            Dim votingPage As New VotingPage()
            votingPage.Show()
        Else
            MessageBox.Show("Invalid username or password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtPassword.Clear()
            txtUsername.Focus()
        End If
    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click
        Me.Hide()

        Dim adminLoginPage As New AdminLoginPage()
        adminLoginPage.Show()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Dim signupForm As New SignupPage()
        signupForm.Show()
        Me.Hide()
    End Sub

    Private Sub CheckBox1_CheckedChanged_1(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        txtPassword.UseSystemPasswordChar = Not CheckBox1.Checked
    End Sub
End Class
