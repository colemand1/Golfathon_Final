Public Class frmEvent


    Private Sub frmEvent_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Load_EventYears(sender, e)
        Load_Golfers(sender, e)
        Load_EventGolfers(sender, e)

    End Sub



    Private Sub Load_EventYears(sender As Object, e As EventArgs)

        Try

            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand
            Dim drSourceTable As OleDb.OleDbDataReader
            Dim dt As DataTable = New DataTable

            'clear old textbox data (in case of delete or update)
            For Each cntrl As Control In Controls
                If TypeOf cntrl Is TextBox Then
                    cntrl.Text = String.Empty
                End If
            Next

            'open the connection
            'if connection not open
            '   show error message
            '   close the form
            If OpenDatabaseConnectionSQLServer() = False Then

                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                Me.Close()
            End If

            'Show changes at once
            'Update for cboGolfers
            cboEventYear.BeginUpdate()


            'Select statement to get ID and make from table
            strSelect = "SELECT intEventYearID, intEventYear FROM TEventYears"


            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            dt.Load(drSourceTable)

            cboEventYear.ValueMember = "intEventYearID"
            cboEventYear.DisplayMember = "intEventYear"
            cboEventYear.DataSource = dt


            If cboEventYear.Items.Count > 0 Then cboEventYear.SelectedIndex = 0

            'Show changes
            cboEventYear.EndUpdate()

            'close all databases
            drSourceTable.Close()

            CloseDatabaseConnection()
        Catch excError As Exception

            MessageBox.Show(excError.Message)

        End Try

    End Sub

    Private Sub Load_EventGolfers(sender As Object, e As EventArgs)

        Try

            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand
            Dim drSourceTable As OleDb.OleDbDataReader
            Dim dt As DataTable = New DataTable

            'clear old textbox data (in case of delete or update)
            For Each cntrl As Control In Controls
                If TypeOf cntrl Is TextBox Then
                    cntrl.Text = String.Empty
                End If
            Next

            'open the connection
            'if connection not open
            '   show error message
            '   close the form
            If OpenDatabaseConnectionSQLServer() = False Then

                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                Me.Close()
            End If

            'Show changes at once
            'Update for cboGolfers
            lstEventGolfers.BeginUpdate()


            'Select statement to get data from table
            strSelect = "Select	TGEY.intGolferEventYearID
                          ,TG.intGolferID
                          ,TG.strLastName + ', ' + TG.strFirstName as GolferName
                          ,TGEY.intEventYearID
                         From	TGolfers as TG
                          Join TGolferEventYears as TGEY
                           on TGEY.intGolferID = TG.intGolferID
                         Where	TGEY.intEventYearID = " & cboEventYear.SelectedValue


            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            dt.Load(drSourceTable)

            lstEventGolfers.ValueMember = "TG.intGolferID"
            lstEventGolfers.DisplayMember = "GolferName"
            lstEventGolfers.DataSource = dt


            If lstEventGolfers.Items.Count > 0 Then lstEventGolfers.SelectedIndex = 0

            'Show changes
            lstEventGolfers.EndUpdate()

            'close all databases
            drSourceTable.Close()

            CloseDatabaseConnection()

        Catch excError As Exception

            MessageBox.Show(excError.Message)

        End Try

    End Sub

    Private Sub Load_Golfers(sender As Object, e As EventArgs)
        Try

            Dim strSelect As String = ""
            Dim cmdSelect As OleDb.OleDbCommand
            Dim drSourceTable As OleDb.OleDbDataReader
            Dim dt As DataTable = New DataTable

            'open the connection
            'if connection not open
            '   show error message
            '   close the form
            If OpenDatabaseConnectionSQLServer() = False Then

                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                Me.Close()
            End If

            'Show changes at once
            'Update for cboGolfers
            lstGolfers.BeginUpdate()


            'Select statement to get ID and make from table
            strSelect = "Select TG.intGolferID, TG.strLastName + ', ' + TG.strFirstName AS GolferName
                            FROM TGolfers as TG
                            WHERE TG.intGolferID Not In (   Select  TG.intGolferID
    			                                From    TGolferEventYears as TGEY
    					                                Join TGolfers as TG
    						                                on TG.intGolferID = TGEY.intGolferID
    			                                Where   TGEY.intEventYearID = " & cboEventYear.SelectedValue & ")"


            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            dt.Load(drSourceTable)

            lstGolfers.ValueMember = "intGolferID"
            lstGolfers.DisplayMember = "GolferName"
            lstGolfers.DataSource = dt


            If lstGolfers.Items.Count > 0 Then lstGolfers.SelectedIndex = 0

            'Show changes
            lstGolfers.EndUpdate()

            'close all databases
            drSourceTable.Close()

            CloseDatabaseConnection()


        Catch excError As Exception

            MessageBox.Show(excError.Message)

        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try

            Dim strSelect As String
            Dim strInsert As String
            Dim cmdSelect As OleDb.OleDbCommand
            Dim cmdInsert As OleDb.OleDbCommand
            Dim drSourceTable As OleDb.OleDbDataReader
            Dim intNextHighestRecordId As Integer
            Dim intRowsAffected As Integer



            'open the connection
            'if connection not open
            '   show error message
            '   close the form
            If OpenDatabaseConnectionSQLServer() = False Then

                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                        "The application will now close.",
                                        Me.Text + " Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error)

                Me.Close()

            End If


            'build the select statement
            strSelect = "   SELECT MAX(intGolferEventYearID) + 1 As intHighestRecordID
                            FROM TGolferEventYears"

            'execute command
            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader


            drSourceTable.Read()

            If drSourceTable.IsDBNull(0) = True Then

                intNextHighestRecordId = 1

            Else

                intNextHighestRecordId = CInt(drSourceTable.Item(0))

            End If


            'build the insert command
            strInsert = "INSERT INTO TGolferEventYears ( intGolferEventYearID, intGolferID, intEventYearID)" &
                " Values (" & intNextHighestRecordId & ", '" & lstGolfers.SelectedValue & "' , '" & cboEventYear.SelectedValue & "')"

            'execute the command
            cmdInsert = New OleDb.OleDbCommand(strInsert, m_conAdministrator)

            intRowsAffected = cmdInsert.ExecuteNonQuery()


            If intRowsAffected > 0 Then
                MessageBox.Show("Golfer has been added")
            End If

            'close the connection
            CloseDatabaseConnection()

            frmEvent_Load(sender, e)


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub cboEventYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEventYear.SelectedIndexChanged

        Load_EventGolfers(sender, e)
        Load_Golfers(sender, e)

    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click

        Try


            Dim strDelete As String = ""
            Dim strSelect As String = String.Empty
            Dim intRowsAffected As Integer
            Dim cmdDelete As OleDb.OleDbCommand
            Dim dt As DataTable = New DataTable
            Dim result As DialogResult


            'open the connection
            'if connection not open
            '   show error message
            '   close the form
            If OpenDatabaseConnectionSQLServer() = False Then

                MessageBox.Show(Me, "Database connection error." & vbNewLine &
                                    "The application will now close.",
                                    Me.Text + " Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                Me.Close()

            End If

            'confirm if record should be deleted
            result = MessageBox.Show("Are you sure you want to Remove Golfer: ?", "Confirm Deletion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

            Select Case result
                Case DialogResult.Cancel
                    MessageBox.Show("Action Canceled")
                Case DialogResult.No
                    MessageBox.Show("Action Canceled")
                Case DialogResult.Yes

                    'build the delete statement
                    strDelete = "   DELETE FROM TGolferEventYears
                                    WHERE intGolferID = " & lstEventGolfers.SelectedValue & " AND intEventYearID = " & cboEventYear.SelectedValue

                    'delete the record
                    cmdDelete = New OleDb.OleDbCommand(strDelete, m_conAdministrator)
                    intRowsAffected = cmdDelete.ExecuteNonQuery()

                    '
                    If intRowsAffected > 0 Then

                        MessageBox.Show("Delete was a success!")
                    Else
                        MessageBox.Show("Delete unsuccessful")

                    End If

            End Select

            CloseDatabaseConnection()

            frmEvent_Load(sender, e)


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
End Class