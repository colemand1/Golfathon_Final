Public Class frmGolfer
    Private Sub frmGolfer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            cboGolfers.BeginUpdate()


            'Select statement to get ID and make from table
            strSelect = "SELECT intGolferID, strLastName + ', ' + strFirstName AS GolferName FROM TGolfers"


            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            dt.Load(drSourceTable)

            cboGolfers.ValueMember = "intGolferID"
            cboGolfers.DisplayMember = "GolferName"
            cboGolfers.DataSource = dt


            If cboGolfers.Items.Count > 0 Then cboGolfers.SelectedIndex = 0

            'Show changes
            cboGolfers.EndUpdate()

            'close all databases
            drSourceTable.Close()

            CloseDatabaseConnection()

            'Load the shirt size combo box
            Me.LoadShirtSizes()

            'Load the gender combo box
            Me.LoadGenders()

            cboGender.SelectedIndex = -1
            cboShirtSize.SelectedIndex = -1


        Catch excError As Exception

            MessageBox.Show(excError.Message)

        End Try

    End Sub


    Private Sub LoadShirtSizes()
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

            '---------------------------------------------------------------------
            'Update cboShirtSizes
            cboShirtSize.BeginUpdate()


            'Select statement to get ID and size from table
            strSelect = "Select intShirtSizeID, strShirtSizeDesc from TShirtSizes"


            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            dt.Load(drSourceTable)

            cboShirtSize.ValueMember = "intShirtSizeID"
            cboShirtSize.DisplayMember = "strShirtSizeDesc"
            cboShirtSize.DataSource = dt


            If cboShirtSize.Items.Count > 0 Then cboShirtSize.SelectedIndex = 0


            cboShirtSize.EndUpdate()
            'close all databases
            drSourceTable.Close()

            CloseDatabaseConnection()



        Catch excError As Exception

            MessageBox.Show(excError.Message)

        End Try
    End Sub

    Private Sub LoadGenders()
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

            '---------------------------------------------------------------------
            'Update cboShirtSizes
            cboGender.BeginUpdate()


            'Select statement to get ID and size from table
            strSelect = "Select intGenderID, strGenderDesc from TGenders"


            cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
            drSourceTable = cmdSelect.ExecuteReader

            dt.Load(drSourceTable)

            cboGender.ValueMember = "intGenderID"
            cboGender.DisplayMember = "strGenderDesc"
            cboGender.DataSource = dt


            If cboGender.Items.Count > 0 Then cboGender.SelectedIndex = 0


            cboGender.EndUpdate()
            'close all databases
            drSourceTable.Close()

            CloseDatabaseConnection()



        Catch excError As Exception

            MessageBox.Show(excError.Message)

        End Try
    End Sub


    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        Dim strSelect As String = ""
        Dim strName As String = ""
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

        'use id or primary key to build select statement
        strSelect = "
	        SELECT TG.strFirstName, TG.strLastName, TG.strStreetAddress, TG.strCity, TG.strState, TG.strZip, TG.strPhoneNumber, TG.strEmail, TG.intShirtSizeId, TG.intGenderID
	        FROM	TGolfers as TG
	        WHERE TG.intGolferId = " & cboGolfers.SelectedValue.ToString

        'get the records
        cmdSelect = New OleDb.OleDbCommand(strSelect, m_conAdministrator)
        drSourceTable = cmdSelect.ExecuteReader

        'load the data from the reader
        dt.Load(drSourceTable)

        'add the data to the text boxes
        txtFirstName.Text = dt.Rows(0).Item(0).ToString
        txtLastName.Text = dt.Rows(0).Item(1).ToString
        txtStreetAddress.Text = dt.Rows(0).Item(2).ToString
        txtCity.Text = dt.Rows(0).Item(3).ToString
        txtState.Text = dt.Rows(0).Item(4).ToString
        txtZip.Text = dt.Rows(0).Item(5).ToString
        txtPhoneNumber.Text = dt.Rows(0).Item(6).ToString
        txtEmail.Text = dt.Rows(0).Item(7).ToString
        cboShirtSize.SelectedValue = dt.Rows(0).Item(8)
        cboGender.SelectedValue = dt.Rows(0).Item(9)

        'close the database connection
        CloseDatabaseConnection()
    End Sub




    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

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
            result = MessageBox.Show("Are you sure you want to Delete Golfer: " & cboGolfers.Text & "?", "Confirm Deletion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

            Select Case result
                Case DialogResult.Cancel
                    MessageBox.Show("Action Canceled")
                Case DialogResult.No
                    MessageBox.Show("Action Canceled")
                Case DialogResult.Yes

                    'build the delete statement
                    strDelete = "Delete FROM TGolfers
                    Where intGolferID = " & cboGolfers.SelectedValue.ToString

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

            frmGolfer_Load(sender, e)


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        Try
            If Validate() = True Then

                Dim strSelect As String = ""
                Dim intRowsAffected As Integer


                Dim strFistName As String = ""
                Dim strLastName As String = ""
                Dim strStreetAddress As String = ""
                Dim strCity As String = ""
                Dim strState As String = ""
                Dim strZip As String = ""
                Dim strPhoneNumber As String = ""
                Dim strEmail As String = ""
                Dim intShirtSizeId As Integer
                Dim intGenderId As Integer



                Dim cmdUpdate As OleDb.OleDbCommand

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

                strFistName = txtFirstName.Text
                strLastName = txtLastName.Text
                strStreetAddress = txtStreetAddress.Text
                strCity = txtCity.Text
                strState = txtState.Text
                strZip = txtZip.Text
                strPhoneNumber = txtPhoneNumber.Text
                strEmail = txtEmail.Text
                intShirtSizeId = cboShirtSize.SelectedValue
                intGenderId = cboGender.SelectedValue


                'build the update statement using the pk from the selected combo box item
                strSelect = "UPDATE TGolfers SET strFirstName = '" & strFistName & "'" & ", strLastName = '" & strLastName & "'" & ", strStreetAddress = '" & strStreetAddress & "'" & ", strCity = '" & strCity & "'" & ", strState = '" & strState & "'" & ", strZip = '" & strZip & "'" & ", strPhoneNumber = '" & strPhoneNumber & "'" & ", strEmail = '" & strEmail & "'" & ", intShirtSizeID = '" & intShirtSizeId & "'" & ", intGenderID = '" & intGenderId & "'" & "Where intGolferID = " & cboGolfers.SelectedValue.ToString

                cmdUpdate = New OleDb.OleDbCommand(strSelect, m_conAdministrator)

                'Insert the Row
                intRowsAffected = cmdUpdate.ExecuteNonQuery()

                'Display outcome of the query
                If intRowsAffected = 1 Then
                    MessageBox.Show("Update Successful")
                Else
                    MessageBox.Show("Update Failed")
                End If

                'clse the database connection
                CloseDatabaseConnection()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        frmAddGolfer.ShowDialog()
        frmGolfer_Load(sender, e)

    End Sub

    Public Function Validate() As Boolean

        For Each cntrl As Control In Controls

            If TypeOf cntrl Is TextBox Then

                cntrl.BackColor = Color.White
                If cntrl.Text = String.Empty Then
                    cntrl.BackColor = Color.Yellow
                    cntrl.Focus()
                    Return False
                End If
                'check if gender combo box and shirt size combo box has been checked
            ElseIf cboGender.SelectedValue = -1 Or cboShirtSize.SelectedValue = -1 Then

                Return False

            End If

        Next

        Return True

    End Function
End Class