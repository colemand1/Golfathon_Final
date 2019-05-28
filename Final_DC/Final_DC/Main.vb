Public Class Main

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        Me.Close()

    End Sub

    Private Sub btnGolfers_Click(sender As Object, e As EventArgs) Handles btnGolfers.Click

        frmGolfer.ShowDialog()

    End Sub

    Private Sub btnSponsors_Click(sender As Object, e As EventArgs) Handles btnSponsors.Click

        frmSponsor.ShowDialog()

    End Sub

    Private Sub btnEvents_Click(sender As Object, e As EventArgs) Handles btnEvents.Click

        frmEvent.ShowDialog()

    End Sub
End Class
