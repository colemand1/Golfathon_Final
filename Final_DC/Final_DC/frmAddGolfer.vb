Public Class frmAddGolfer

    Private Sub frmAddGolfer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LoadShirtSizes()
        LoadGenders()

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

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try

            Dim strSelect As String
            Dim strInsert As String
            Dim cmdSelect As OleDb.OleDbCommand
            Dim cmdInsert As OleDb.OleDbCommand
            Dim drSourceTable As OleDb.OleDbDataReader
            Dim intNextHighestRecordId As Integer
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



            If Validate() = True Then

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
                strSelect = "SELECT MAX(intGolferID) + 1 AS intNextHighestRecordID " &
                        " FROM TGolfers"

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
                strInsert = "INSERT INTO TGolfers ( intGolferID, strFirstName, strLastName, strStreetAddress, strCity, strState, strZip, strPhoneNumber, strEmail, intShirtSizeId, intGenderId )" &
                " Values (" & intNextHighestRecordId & ", '" & strFistName & "' , '" & strLastName & "', '" & strStreetAddress & "', '" & strCity & "', '" & strState & "', '" & strZip & "', '" & strPhoneNumber & "', '" & strEmail & "', '" & intShirtSizeId & "', '" & intGenderId & "')"

                'execute the command
                cmdInsert = New OleDb.OleDbCommand(strInsert, m_conAdministrator)

                intRowsAffected = cmdInsert.ExecuteNonQuery()


                If intRowsAffected > 0 Then
                    MessageBox.Show("Golfer has been added")
                    Me.Close()
                End If

                'close the connection
                CloseDatabaseConnection()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
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