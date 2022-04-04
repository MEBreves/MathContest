Option Strict On
Option Explicit On
'Miranda Breves
'RCET0265
'Spring 2022
'Math Contest
'https://github.com/MEBreves/MathContest

Imports System.Text.RegularExpressions

Public Class MathContestForm

    'This exists to remember the counts for the student's correct answers and total submissions without using global
    'variables. The clear boolean allows the counts to be reset back to 0.
    Function StudentScores(ByVal correctCount As Integer, ByVal totalCount As Integer, ByVal clear As Boolean) As Integer()

        'The correct answer and total submission count as declared static so their values are remembered while the program
        'is still running.
        Static correctAnswerCount As Integer
        Static totalSubmissionCount As Integer
        Dim countArray(1) As Integer

        'If clear was true, then the counts are set back to 0. If false, the user-entered counts are added to the
        'function counts.
        If clear Then
            correctAnswerCount = 0
            totalSubmissionCount = 0
        Else
            correctAnswerCount += correctCount
            totalSubmissionCount += totalCount
        End If

        'To send both variables back, they are loaded into an array
        countArray(0) = correctAnswerCount
        countArray(1) = totalSubmissionCount

        Return countArray

    End Function

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
        Dim unused = StudentScores(0, 0, True)  'Here, the clear boolean value is used to clear the counts

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
            If studentAnswer = correctAnswer Then
                MsgBox("Your answer was correct!")
                StudentScores(1, 1, False)  'Both the correct answer and total submissions counts are incrimented
            Else
                MsgBox($"Your answer was wrong. The correct answer is {correctAnswer}.")
                StudentScores(0, 1, False)  'The correct answer count is not incremented by the total submission is
            End If

            GenerateMathNumbers()
            AnswerBox.Text = ""
            SummaryButton.Enabled = True

        Catch ex As Exception
            'The answer is not counted as submitted, and so the student scores function will not be updated.
            MsgBox($"Your answer was not valid. Please enter a number.")
            AnswerBox.Focus()
        End Try
    End Sub

    Private Sub SummaryButton_Click(sender As Object, e As EventArgs) Handles SummaryButton.Click
        'The Student Score function will be used to retrieve the counts that have been entered, and the values
        'will be stored in the score array
        Dim scoreArray(1) As Integer
        scoreArray = StudentScores(0, 0, False)

        'The results are displayed to the user via a message box.
        MsgBox($"{NameTextBox.Text} got {scoreArray(0)} answers correct out of a " &
                 $"possible {scoreArray(1)}.",, "Total Score")
    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()  'Closes the program completely
    End Sub

    'When the student info textboxes have all been filled, this script will check the values entered when
    'any of the info textboxes have been left
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
            'The ^ symbol means begin at the first value, $ means end at the last value, the [] contain the values to
            'check against, and the + allows the regex to check for incorrect values across the whole string
            Dim pattern As String = "^[a-zA-Z\s]+$"
            Dim regex As New Regex(pattern)

            'Forcing the msgBoxEntries variable to equal {""} creates a single-entry array that is not empty or null
            Dim msgBoxEntries() As String = {""}
            Dim totalString As String = ""
            Dim grade As Integer
            Dim age As Integer

            'The regex.isMatch function checks the user's entry against the regex's pattern (letters and spaces) and will
            'return true if the entry fits within the pattern set. This code will add the student name as an invalid
            'answer if the regex returns false
            If Not regex.IsMatch(NameTextBox.Text) Then
                msgBoxEntries(msgBoxEntries.Length - 1) = "Student name"
                NameTextBox.Text = ""
            End If

            'If the grade is not a number, the grade will be considered an invalid answer and be added to the msgBoxEntries
            'array
            Try
                grade = CInt(GradeTextBox.Text)
            Catch ex As Exception
                If Not msgBoxEntries(0) = "" Then 'The array will be expanded by one entry if the first entry is full
                    ReDim Preserve msgBoxEntries(msgBoxEntries.Length)
                End If
                msgBoxEntries(msgBoxEntries.Length - 1) = "Grade"
                GradeTextBox.Text = ""
            End Try

            'If the age is not a number, the age will be considered an invalid answer and be added to the msgBoxEntries
            'array
            Try
                age = CInt(AgeTextBox.Text)
            Catch ex As Exception
                If Not msgBoxEntries(0) = "" Then 'The array will be expanded by one entry if the first entry is full
                    ReDim Preserve msgBoxEntries(msgBoxEntries.Length)
                End If
                msgBoxEntries(msgBoxEntries.Length - 1) = "Age"
                AgeTextBox.Text = ""
            End Try

            'If invalid answers were found, the errors will be displayed in a message box and the first incorrect textbox
            'will be focused on
            If Not msgBoxEntries(0) = "" Then
                '
                'This for loop concatenates the errors into a grammatically correct format (error 1 and error 2 instead
                'of error 1, error 2 or error 1 error 2)
                For i As Integer = 0 To msgBoxEntries.Length - 1
                    If i <> 0 And i = msgBoxEntries.Length - 1 Then
                        totalString += $"and {msgBoxEntries(i)} "
                    ElseIf msgBoxEntries.Length > 2 Then
                        totalString += $"{msgBoxEntries(i)}, "
                    Else
                        totalString += $"{msgBoxEntries(i)} "
                    End If
                Next

                'The concatenated error string is used in a prompt for a message box to alert the user to fix the values.
                If msgBoxEntries.Length > 2 Then
                    'Multiple errors were found
                    MsgBox($"The textboxes with {totalString}were not valid. Please re-enter the values.",, "Info Error")
                Else
                    'A single error was found
                    MsgBox($"The textbox with the {totalString}was not valid. Please re-enter the value.",, "Info Error")
                End If

                'The validation trigger boolean forces the program to only run once when the focus is changed instead of
                'triggering the code again.
                validationTrigger = True
                Select Case msgBoxEntries(0)    'The first entry in the array determines which textbox gets focus
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

            'If the name, grade, and age values were in the correct format, the grade and age values are checked
            'to be within range of the student parameters (grade between 1 and 4, age between 7 and 11)
            If grade < 1 Or grade > 4 Or age < 7 Or age > 11 Then
                MsgBox("Student is not eligible to compete. The student's grade must be between 1 and 4, and " &
                       "the student's age must be between 7 and 10.",, "Grade and Age Values")
                validationTrigger = True
                GradeTextBox.Focus()
                validationTrigger = False
                Exit Sub  'This exits the sub and prevents the code below in the sub from running.
            End If

            'If the rest of the options on the form are disabled, this code enables them and generates the first
            'problem to be solved by the student.
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

        'Necessary to allow the randomize function to generate different values on call
        Randomize()

        'The difficulty of the question is adjusted by grade.
        Select Case GradeTextBox.Text
            Case "1"                                            '1st grade difficult is set low - numbers up to 20
                upperBound = 20
                MultiplicationRadioButton.Enabled = False       '1st graders have not learned to multiply or divide
                DivisionRadioButton.Enabled = False
            Case "2"                                            '2nd graders have harder adding and subtracting difficulty
                upperBound = 100
                If MultiplicationRadioButton.Checked Then
                    upperBound = 5                              'Their multiplication problems go up to 5 x 5
                End If
                MultiplicationRadioButton.Enabled = True        '2nd graders have not learned to divide yet
                DivisionRadioButton.Enabled = False
            Case "3"                                            '3rd graders have harder addition and subtraction problems
                upperBound = 500
                If MultiplicationRadioButton.Checked Then       'By now, 3rd graders are learning multiplication and division
                    upperBound = 12                             'up to 12 x 12
                ElseIf DivisionRadioButton.Checked Then
                    upperBound = 144
                End If
                MultiplicationRadioButton.Enabled = True
                DivisionRadioButton.Enabled = True
            Case "4"                                            '4th grade has the harderst problems involving numbers up
                upperBound = 1000                               'to 1000
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

                'The code also does not allow division by zero as it is undefined
                If CInt(SecondNumberLabel.Text) = 0 Then
                    divisibleIntoWholeNumber = False
                    FirstNumberLabel.Text = CStr(CInt(Math.Floor((upperBound + 1) * Rnd())))
                    SecondNumberLabel.Text = CStr(CInt(Math.Floor((upperBound + 1) * Rnd())))

                    'In both cases, the first and second numbers are re-randomized until a whole number answer is possible
                ElseIf (CInt(FirstNumberLabel.Text) Mod CInt(SecondNumberLabel.Text)) <> 0 Then
                    divisibleIntoWholeNumber = False
                    FirstNumberLabel.Text = CStr(CInt(Math.Floor((upperBound + 1) * Rnd())))
                    SecondNumberLabel.Text = CStr(CInt(Math.Floor((upperBound + 1) * Rnd())))

                Else
                    'At this point, the whole number answer was found and the loop can end
                    divisibleIntoWholeNumber = True
                End If

            Loop

        End If

    End Sub

End Class