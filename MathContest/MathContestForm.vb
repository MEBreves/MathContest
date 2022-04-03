Option Strict On
Option Explicit On
'Miranda Breves
'RCET0265
'Spring 2022
'Math Contest
'https://github.com/MEBreves/MathContest

Imports System.Text.RegularExpressions

Public Class MathContestForm

    Dim correctAnswerCount As Integer
    Dim totalSubmissionCount As Integer

    Private Sub MathContestForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Sets the addition button to be the default radio button in the group to be checked
        AdditionRadioButton.Checked = True

        'The submit button and summary button are disabled to prevent the user from moving forward without
        'the student information having been entered and validated.
        SubmitButton.Enabled = False
        SummaryButton.Enabled = False

        'Tooltip Messages are set for every text box in the display.
        MathContestToolTip.SetToolTip(NameTextBox, "Enter the student's name.")
        MathContestToolTip.SetToolTip(GradeTextBox, "Enter the student's grade level.")
        MathContestToolTip.SetToolTip(AgeTextBox, "Enter the student's age.")
        MathContestToolTip.SetToolTip(AnswerBox, "What is the math problem's answer?")

        'Tooltip messages are set for every button in the display
        MathContestToolTip.SetToolTip(ClearButton, "Clears the student's information. Press Esc or click " &
                                      "to trigger this button.")
        MathContestToolTip.SetToolTip(AdditionRadioButton, "Sets the math problem type to addition.")
        MathContestToolTip.SetToolTip(SubtractionRadioButton, "Sets the math problem type to subtraction.")
        MathContestToolTip.SetToolTip(MultiplicationRadioButton, "Sets the math problem type to multiplication.")
        MathContestToolTip.SetToolTip(DivisionRadioButton, "Sets the math problem type to division.")
        MathContestToolTip.SetToolTip(SubmitButton, "Grades the answer of the math problem entered. Press Enter " &
                                      "or click to trigger this button.")
        MathContestToolTip.SetToolTip(SummaryButton, "Displays a summary of the student's results.")
        MathContestToolTip.SetToolTip(ExitButton, "Exits the program.")

    End Sub

    'When the radio button selection has been changed, the type of math problem in the Math Problem section will
    'change accordingly, with a corresponding math type and new numbers.
    Private Sub RadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles AdditionRadioButton.CheckedChanged,
        SubtractionRadioButton.CheckedChanged, MultiplicationRadioButton.CheckedChanged, DivisionRadioButton.CheckedChanged

        'Based on the radio button selected, the problem type in the Math Problem section will adjust accordingly.
        Select Case True
            Case AdditionRadioButton.Checked
                OperationLabel.Text = "+"
            Case SubtractionRadioButton.Checked
                OperationLabel.Text = "-"
            Case MultiplicationRadioButton.Checked
                OperationLabel.Text = "x"
            Case DivisionRadioButton.Checked
                OperationLabel.Text = "/"

        End Select

        'The numbers in the Math Problem section will change.
        GenerateMathNumbers()

    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        'Clear will act as a reset button. If the student's information is cleared, all entered values will be cleared.
        NameTextBox.Text = ""
        GradeTextBox.Text = ""
        AgeTextBox.Text = ""

        'The rest of the display will also be reset back to their default values. 
        AdditionRadioButton.Checked = True
        SubmitButton.Enabled = False
        SummaryButton.Enabled = False
        ProblemTypeGroupBox.Enabled = False
        FirstNumberLabel.Text = "0"
        SecondNumberLabel.Text = "0"

        'Any progress made by the student originally entered will be discarded.
        AnswerBox.Text = ""
        correctAnswerCount = 0
        totalSubmissionCount = 0

        'Everything will start back at the beginning, the Name Textbox.
        NameTextBox.Focus()
    End Sub

    Private Sub SubmitButton_Click(sender As Object, e As EventArgs) Handles SubmitButton.Click
        'Declaring variables
        Dim studentAnswer As Integer = 0
        Dim correctAnswer As Integer = 0

        'The correct math operation is used to find the answer to the math problem based on the operation label
        Select Case OperationLabel.Text
            Case "+"
                correctAnswer = CInt(FirstNumberLabel.Text) + CInt(SecondNumberLabel.Text)
            Case "-"
                correctAnswer = CInt(FirstNumberLabel.Text) - CInt(SecondNumberLabel.Text)
            Case "x"
                correctAnswer = CInt(FirstNumberLabel.Text) * CInt(SecondNumberLabel.Text)
            Case "/"
                correctAnswer = CInt(CInt(FirstNumberLabel.Text) / CInt(SecondNumberLabel.Text))
        End Select

        'The student's answer is checked to see if it is an number, and if not, the answer is not considered submitted.
        Try
            studentAnswer = CInt(AnswerBox.Text)

            'If the student's answer was a number, the submission is counted towards the total questions solved and
            'compared to the correct answer
            totalSubmissionCount += 1
            If studentAnswer = correctAnswer Then
                MsgBox("Your answer was correct!")
                correctAnswerCount += 1
            Else
                MsgBox($"Your answer was wrong. The correct answer is {correctAnswer}.")
            End If

            GenerateMathNumbers()
            AnswerBox.Text = ""
            SummaryButton.Enabled = True

        Catch ex As Exception
            MsgBox($"Your answer was not valid. Please enter a number.")
            AnswerBox.Focus()
        End Try
    End Sub

    Private Sub SummaryButton_Click(sender As Object, e As EventArgs) Handles SummaryButton.Click
        MsgBox($"{NameTextBox.Text} got {correctAnswerCount} answers correct out of a " &
                 $"possible {totalSubmissionCount}.",, "Total Score")
    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    Private Sub InfoTextBox_Lost_Focus(sender As Object, e As EventArgs) Handles NameTextBox.Leave,
        GradeTextBox.Leave, AgeTextBox.Leave

        If NameTextBox.Text <> "" And GradeTextBox.Text <> "" And AgeTextBox.Text <> "" Then
            ValidateStudentInfo()
        End If
    End Sub

    Sub ValidateStudentInfo()

        'Whenever the clear or exit button was clicked and the grade and age were incorrect,
        'the program wouldn't let the exit button code be performed and kept displaying the 
        'message boxes. An exit button press will be checked before running the validation
        'so that the user is able to exit smoothly.
        If ClearButton.Focused Or ExitButton.Focused Then
            Exit Sub
        End If

        'Depending on what information entered was incorrect, having the focus change could trigger the validation
        'code twice. This trigger boolean forces the code to run once so the user only sees one MsgBox with errors.
        Static validationTrigger As Boolean

        If Not validationTrigger Then
            'To check if the name entered contains only letters and spaces, a regular expression or "Regex" function will
            'be used after being set to the upper and lower case letters a through z and the space character \s
            Dim pattern As String = "^[a-zA-Z\s]+$"
            Dim regex As New Regex(pattern)

            Dim msgBoxEntries() As String = {""}
            Dim totalString As String = ""
            Dim grade As Integer
            Dim age As Integer

            'The regex.isMatch function checks the user's entry against the regex's patter (letters and spaces) and will
            'return true if the entry fits within the pattern set.
            If Not regex.IsMatch(NameTextBox.Text) Then
                msgBoxEntries(msgBoxEntries.Length - 1) = "Student name"
                NameTextBox.Text = ""
            End If

            Try
                grade = CInt(GradeTextBox.Text)
            Catch ex As Exception
                If Not msgBoxEntries(0) = "" Then
                    ReDim Preserve msgBoxEntries(msgBoxEntries.Length)
                End If
                msgBoxEntries(msgBoxEntries.Length - 1) = "Grade"
                GradeTextBox.Text = ""
            End Try

            Try
                age = CInt(AgeTextBox.Text)
            Catch ex As Exception
                If Not msgBoxEntries(0) = "" Then
                    ReDim Preserve msgBoxEntries(msgBoxEntries.Length)
                End If
                msgBoxEntries(msgBoxEntries.Length - 1) = "Age"
                AgeTextBox.Text = ""
            End Try

            If Not msgBoxEntries(0) = "" Then
                For i As Integer = 0 To msgBoxEntries.Length - 1
                    If i <> 0 And i = msgBoxEntries.Length - 1 Then
                        totalString += $"and {msgBoxEntries(i)} "
                    ElseIf msgBoxEntries.Length > 2 Then
                        totalString += $"{msgBoxEntries(i)}, "
                    Else
                        totalString += $"{msgBoxEntries(i)} "
                    End If
                Next

                If msgBoxEntries.Length > 2 Then
                    MsgBox($"The textboxes with {totalString}were not valid. Please re-enter the values.")
                Else
                    MsgBox($"The textbox with the {totalString}was not valid. Please re-enter the value.")
                End If

                validationTrigger = True
                Select Case msgBoxEntries(0)
                    Case "Student name"
                        NameTextBox.Focus()
                    Case "Grade"
                        GradeTextBox.Focus()
                    Case "Age"
                        AgeTextBox.Focus()
                End Select
                validationTrigger = False

                Exit Sub 'This exits the sub and prevents the code below in the sub from running.
            End If

            If grade < 1 Or grade > 4 Or age < 7 Or age > 11 Then
                MsgBox("Student is not eligible to compete. The student's grade must be between 1 and 4, and " &
                       "the student's age must be between 7 and 10.",, "Grade and Age Values")
                validationTrigger = True
                GradeTextBox.Focus()
                validationTrigger = False
                Exit Sub  'This exits the sub and prevents the code below in the sub from running.
            End If

            If ProblemTypeGroupBox.Enabled = False Then
                ProblemTypeGroupBox.Enabled = True
                GenerateMathNumbers()
                SubmitButton.Enabled = True
            End If

        End If

    End Sub

    Sub GenerateMathNumbers()

        Dim upperBound As Integer = 0
        Dim divisibleIntoWholeNumber As Boolean = False

        Randomize()

        'The difficulty of the question is adjusted by grade.
        Select Case GradeTextBox.Text
            Case "1"
                upperBound = 20
                MultiplicationRadioButton.Enabled = False
                DivisionRadioButton.Enabled = False
            Case "2"
                upperBound = 100
                If MultiplicationRadioButton.Checked Then
                    upperBound = 5
                ElseIf DivisionRadioButton.Checked Then
                    upperBound = 25
                End If

                MultiplicationRadioButton.Enabled = True
                DivisionRadioButton.Enabled = False
            Case "3"
                upperBound = 500
                If MultiplicationRadioButton.Checked Then
                    upperBound = 12
                ElseIf DivisionRadioButton.Checked Then
                    upperBound = 144
                End If
                MultiplicationRadioButton.Enabled = True
                DivisionRadioButton.Enabled = True
            Case "4"
                upperBound = 1000
                If MultiplicationRadioButton.Checked Then
                    upperBound = 100
                ElseIf DivisionRadioButton.Checked Then
                    upperBound = 1000
                End If
                MultiplicationRadioButton.Enabled = True
                DivisionRadioButton.Enabled = True
        End Select

        'Based on the max possible values set above, the two values for the problem are set
        FirstNumberLabel.Text = CStr(CInt(Math.Floor((upperBound + 1) * Rnd())))
        SecondNumberLabel.Text = CStr(CInt(Math.Floor((upperBound + 1) * Rnd())))

        'If the division button is checked, the answer should be a whole number and not need any remainder values.
        'The code below forces the two values for the problem result in a whole number answer. 
        If DivisionRadioButton.Checked Then

            Do Until divisibleIntoWholeNumber

                If CInt(SecondNumberLabel.Text) = 0 Then
                    divisibleIntoWholeNumber = False
                    FirstNumberLabel.Text = CStr(CInt(Math.Floor((upperBound + 1) * Rnd())))
                    SecondNumberLabel.Text = CStr(CInt(Math.Floor((upperBound + 1) * Rnd())))

                ElseIf (CInt(FirstNumberLabel.Text) Mod CInt(SecondNumberLabel.Text)) <> 0 Then
                    divisibleIntoWholeNumber = False
                    FirstNumberLabel.Text = CStr(CInt(Math.Floor((upperBound + 1) * Rnd())))
                    SecondNumberLabel.Text = CStr(CInt(Math.Floor((upperBound + 1) * Rnd())))

                Else
                    divisibleIntoWholeNumber = True
                End If

            Loop

        End If

    End Sub

End Class