Public Class AdminControlPanel

    Private Sub AdminControlPanel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterScreen
        UpdateListBoxes()
    End Sub

    Private Sub UpdateListBoxes()
        UpdateListBox(VotingPage.selectedOptionsGroup1, ListBox1)
        UpdateListBox(VotingPage.selectedOptionsGroup2, ListBox2)
        UpdateListBox(VotingPage.selectedOptionsGroup3, ListBox3)
        UpdateListBox(VotingPage.selectedOptionsGroup4, ListBox4)
    End Sub

    Private Function GetWinningMessage(categoryName As String, selectedOptions As List(Of String)) As String
        If selectedOptions Is Nothing OrElse selectedOptions.Count = 0 Then
            Return categoryName & ": no votes yet."
        End If

        Dim groupedVotes = selectedOptions.GroupBy(Function(item) item).
            Select(Function(group) New With {.Name = group.Key, .Votes = group.Count()}).
            OrderByDescending(Function(item) item.Votes).
            ThenBy(Function(item) item.Name).
            ToList()

        Dim topVotes = groupedVotes.First().Votes
        Dim winners = groupedVotes.Where(Function(item) item.Votes = topVotes).Select(Function(item) item.Name).ToList()

        If winners.Count = 1 Then
            Return categoryName & ": " & winners(0) & " with " & topVotes.ToString() & " vote(s)."
        End If

        Return categoryName & ": tie between " & String.Join(", ", winners) & " with " & topVotes.ToString() & " vote(s) each."
    End Function

    Private Sub CountAndDisplayVotes(selectedOptions As List(Of String), listBox As ListBox)
        Dim itemCounts As New Dictionary(Of String, Integer)

        For Each item As String In selectedOptions
            If itemCounts.ContainsKey(item) Then
                itemCounts(item) += 1
            Else
                itemCounts.Add(item, 1)
            End If
        Next

        listBox.Items.Clear()
        If itemCounts.Count = 0 Then
            listBox.Items.Add("No votes yet.")
            Return
        End If

        For Each kvp As KeyValuePair(Of String, Integer) In itemCounts.OrderByDescending(Function(x) x.Value).ThenBy(Function(x) x.Key)
            listBox.Items.Add(kvp.Key & ": " & kvp.Value.ToString())
        Next
    End Sub

    Private Sub UpdateListBox(selectedOptions As List(Of String), listBox As ListBox)
        listBox.Items.Clear()

        If selectedOptions Is Nothing OrElse selectedOptions.Count = 0 Then
            listBox.Items.Add("No votes yet.")
            Return
        End If

        For Each item As String In selectedOptions
            listBox.Items.Add(item)
        Next
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Me.Hide()
            Dim loginForm As New LoginForm()
            loginForm.Show()
        End If
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Dim winnerSummary As String = String.Join(Environment.NewLine,
            GetWinningMessage("Best Anime", VotingPage.selectedOptionsGroup1),
            GetWinningMessage("Best Anime Opening", VotingPage.selectedOptionsGroup2),
            GetWinningMessage("Best Romance Anime", VotingPage.selectedOptionsGroup3),
            GetWinningMessage("Best Action Anime", VotingPage.selectedOptionsGroup4))

        MessageBox.Show(winnerSummary, "Current Winners", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        CountAndDisplayVotes(VotingPage.selectedOptionsGroup1, ListBox1)
        CountAndDisplayVotes(VotingPage.selectedOptionsGroup2, ListBox2)
        CountAndDisplayVotes(VotingPage.selectedOptionsGroup3, ListBox3)
        CountAndDisplayVotes(VotingPage.selectedOptionsGroup4, ListBox4)
    End Sub
End Class
