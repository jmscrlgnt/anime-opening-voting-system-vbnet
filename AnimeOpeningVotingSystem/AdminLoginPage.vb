Public Class AdminLoginPage

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtPassword.UseSystemPasswordChar = True
        Me.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub Guna2CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles Guna2CheckBox1.CheckedChanged
        txtPassword.UseSystemPasswordChar = Not Guna2CheckBox1.Checked
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Dim expectedUsername As String = "Admin"
        Dim expectedPassword As String = "Admin1234"

        Dim enteredUsername As String = txtUsername.Text.Trim()
        Dim enteredPassword As String = txtPassword.Text

        If enteredUsername = expectedUsername AndAlso enteredPassword = expectedPassword Then
            MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Hide()
            Dim adminControlPanel As New AdminControlPanel()
            adminControlPanel.Show()
        Else
            MessageBox.Show("Invalid Username or Password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtUsername.Clear()
            txtPassword.Clear()
            txtUsername.Focus()
        End If
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to go back?", "Go Back", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Me.Hide()
            Dim loginForm As New LoginForm()
            loginForm.Show()
        End If
    End Sub
End Class
