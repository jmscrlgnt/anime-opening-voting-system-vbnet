Public Class VotingPage
    Public Shared selectedOptionsGroup1 As New List(Of String)
    Public Shared selectedOptionsGroup2 As New List(Of String)
    Public Shared selectedOptionsGroup3 As New List(Of String)
    Public Shared selectedOptionsGroup4 As New List(Of String)

    Private Sub VotingPage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub OpenAnimeVideo(fileName As String)
        Dim videoPath As String = GetVideoFilePath(fileName)
        Dim animeOpeningForm As New AnimeOpening()
        animeOpeningForm.VideoFilePath = videoPath
        animeOpeningForm.Show()
    End Sub

    Private Function GetSelectedText(groupName As String) As String
        Select Case groupName
            Case "group1"
                If RdbPiece.Checked Then Return RdbPiece.Text
                If RdbNaruto.Checked Then Return RdbNaruto.Text
                If RdbBleach.Checked Then Return RdbBleach.Text
                If RdbShadow.Checked Then Return RdbShadow.Text
                If RdbHealer.Checked Then Return RdbHealer.Text
                If RdbDbs.Checked Then Return RdbDbs.Text
                If RdbFMA.Checked Then Return RdbFMA.Text
            Case "group2"
                If RadioButtonMob.Checked Then Return RadioButtonMob.Text
                If RadioButtonChainsaw.Checked Then Return RadioButtonChainsaw.Text
                If RadioButtonAOT.Checked Then Return RadioButtonAOT.Text
                If RadioButtonJujutsu.Checked Then Return RadioButtonJujutsu.Text
                If RadioButtonMashle.Checked Then Return RadioButtonMashle.Text
                If RadioButtonAkame.Checked Then Return RadioButtonAkame.Text
                If RadioButtonSAO.Checked Then Return RadioButtonSAO.Text
            Case "group3"
                If RadioButtonDanger.Checked Then Return RadioButtonDanger.Text
                If RadioButtonJuliet.Checked Then Return RadioButtonJuliet.Text
                If RadioButtonGolden.Checked Then Return RadioButtonGolden.Text
                If RadioButtonApril.Checked Then Return RadioButtonApril.Text
                If RadioButtonHorimiya.Checked Then Return RadioButtonHorimiya.Text
                If RadioButtonWotakoi.Checked Then Return RadioButtonWotakoi.Text
                If RadioButtonDarling.Checked Then Return RadioButtonDarling.Text
            Case "group4"
                If RadioButtonSlayer.Checked Then Return RadioButtonSlayer.Text
                If RadioButtonFire.Checked Then Return RadioButtonFire.Text
                If RadioButtonTail.Checked Then Return RadioButtonTail.Text
                If RadioButtonSins.Checked Then Return RadioButtonSins.Text
                If Radiobuttoninu.Checked Then Return Radiobuttoninu.Text
                If RadioButtonHunter.Checked Then Return RadioButtonHunter.Text
                If RadioButtonDororo.Checked Then Return RadioButtonDororo.Text
        End Select

        Return String.Empty
    End Function

    Private Function ValidateSelections() As Boolean
        If String.IsNullOrWhiteSpace(GetSelectedText("group1")) OrElse
           String.IsNullOrWhiteSpace(GetSelectedText("group2")) OrElse
           String.IsNullOrWhiteSpace(GetSelectedText("group3")) OrElse
           String.IsNullOrWhiteSpace(GetSelectedText("group4")) Then
            MessageBox.Show("Please select one anime in every category before submitting your vote.", "Incomplete Vote", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Return True
    End Function

    Private Sub ClearSelections()
        RdbPiece.Checked = False
        RdbNaruto.Checked = False
        RdbBleach.Checked = False
        RdbShadow.Checked = False
        RdbHealer.Checked = False
        RdbDbs.Checked = False
        RdbFMA.Checked = False

        RadioButtonMob.Checked = False
        RadioButtonChainsaw.Checked = False
        RadioButtonAOT.Checked = False
        RadioButtonJujutsu.Checked = False
        RadioButtonMashle.Checked = False
        RadioButtonAkame.Checked = False
        RadioButtonSAO.Checked = False

        RadioButtonDanger.Checked = False
        RadioButtonJuliet.Checked = False
        RadioButtonGolden.Checked = False
        RadioButtonApril.Checked = False
        RadioButtonHorimiya.Checked = False
        RadioButtonWotakoi.Checked = False
        RadioButtonDarling.Checked = False

        RadioButtonSlayer.Checked = False
        RadioButtonFire.Checked = False
        RadioButtonTail.Checked = False
        RadioButtonSins.Checked = False
        Radiobuttoninu.Checked = False
        RadioButtonHunter.Checked = False
        RadioButtonDororo.Checked = False
    End Sub

    Private Sub PctbxMashle_Click(sender As Object, e As EventArgs) Handles PctbxMashle.Click
        OpenAnimeVideo("Mashle.mp4")
    End Sub

    Private Sub PctbxJujutsu_Click(sender As Object, e As EventArgs) Handles PctbxJujutsu.Click
        OpenAnimeVideo("Jujutsu.mp4")
    End Sub

    Private Sub PctbxAOT_Click(sender As Object, e As EventArgs) Handles PctbxAOT.Click
        OpenAnimeVideo("AOT.mp4")
    End Sub

    Private Sub PctbxChainsaw_Click(sender As Object, e As EventArgs) Handles PctbxChainsaw.Click
        OpenAnimeVideo("Chainsaw.mp4")
    End Sub

    Private Sub PctbxMob_Click(sender As Object, e As EventArgs) Handles PctbxMob.Click
        OpenAnimeVideo("Mob.mp4")
    End Sub

    Private Sub PctbxAkame_Click(sender As Object, e As EventArgs) Handles PctbxAkame.Click
        OpenAnimeVideo("Akame-Ga-Kill.mp4")
    End Sub

    Private Sub PctbxSAO_Click(sender As Object, e As EventArgs) Handles PctbxSAO.Click
        OpenAnimeVideo("Sword-Art-Online.mp4")
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        OpenAnimeVideo("One-Piece.mp4")
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        OpenAnimeVideo("Naruto-Shippuden.mp4")
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        OpenAnimeVideo("Bleach.mp4")
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        OpenAnimeVideo("Shadow.mp4")
    End Sub

    Private Sub PctbxHealer1_Click(sender As Object, e As EventArgs) Handles PctbxHealer1.Click
        OpenAnimeVideo("Redo-of-Healer.mp4")
    End Sub

    Private Sub PctbxDBS_Click(sender As Object, e As EventArgs) Handles PctbxDBS.Click
        OpenAnimeVideo("DBS.mp4")
    End Sub

    Private Sub PctbxFMA_Click(sender As Object, e As EventArgs) Handles PctbxFMA.Click
        OpenAnimeVideo("FMA.mp4")
    End Sub

    Private Sub PctbxDanger_Click(sender As Object, e As EventArgs) Handles PctbxDanger.Click
        OpenAnimeVideo("Heart.mp4")
    End Sub

    Private Sub pctbxJuliet_Click_1(sender As Object, e As EventArgs) Handles pctbxJuliet.Click
        OpenAnimeVideo("Juliet.mp4")
    End Sub

    Private Sub PctbxGolden_Click(sender As Object, e As EventArgs) Handles PctbxGolden.Click
        OpenAnimeVideo("Golden.mp4")
    End Sub

    Private Sub PctbxApril_Click(sender As Object, e As EventArgs) Handles PctbxApril.Click
        OpenAnimeVideo("April.mp4")
    End Sub

    Private Sub PxtboxHorimiya_Click(sender As Object, e As EventArgs) Handles PxtboxHorimiya.Click
        OpenAnimeVideo("Horimiya.mp4")
    End Sub

    Private Sub PctbxWotakoi_Click(sender As Object, e As EventArgs) Handles PctbxWotakoi.Click
        OpenAnimeVideo("Wotakoi.mp4")
    End Sub

    Private Sub PctbxDarling_Click(sender As Object, e As EventArgs) Handles PctbxDarling.Click
        OpenAnimeVideo("Darling.mp4")
    End Sub

    Private Sub PctbxSlayer_Click(sender As Object, e As EventArgs) Handles PctbxSlayer.Click
        OpenAnimeVideo("Slayer.mp4")
    End Sub

    Private Sub pctbxFireForce_Click(sender As Object, e As EventArgs) Handles pctbxFireForce.Click
        OpenAnimeVideo("FireForce.mp4")
    End Sub

    Private Sub pctbxFairy_Click(sender As Object, e As EventArgs) Handles pctbxFairy.Click
        OpenAnimeVideo("Fairy.mp4")
    End Sub

    Private Sub pctbcSDS_Click(sender As Object, e As EventArgs) Handles pctbcSDS.Click
        OpenAnimeVideo("SDS.mp4")
    End Sub

    Private Sub PctbxInu_Click(sender As Object, e As EventArgs) Handles PctbxInu.Click
        OpenAnimeVideo("Inuyasha.mp4")
    End Sub

    Private Sub pctbxHxH_Click(sender As Object, e As EventArgs) Handles pctbxHxH.Click
        OpenAnimeVideo("HXH.mp4")
    End Sub

    Private Sub pctbxDororo_Click(sender As Object, e As EventArgs) Handles pctbxDororo.Click
        OpenAnimeVideo("Dororo.mp4")
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to go back?", "Go Back", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Me.Hide()
            Dim loginForm As New LoginForm()
            loginForm.Show()
        End If
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        If Not ValidateSelections() Then
            Return
        End If

        selectedOptionsGroup1.Add(GetSelectedText("group1"))
        selectedOptionsGroup2.Add(GetSelectedText("group2"))
        selectedOptionsGroup3.Add(GetSelectedText("group3"))
        selectedOptionsGroup4.Add(GetSelectedText("group4"))

        MessageBox.Show("Thank you for voting! Your choices were recorded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ClearSelections()
    End Sub
End Class
