'Miranda Breves
'RCET0265
'Spring 20222
'Math Contest
'github url

Option Strict On
Option Explicit On

Public Class MathContestForm

    Dim validationTrigger As Boolean
    Dim correctAnswerCount As Integer = 0
    Dim totalSubmissionCount As Integer = 0

    Private Sub MathContestForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AdditionRadioButton.Checked = True
        SubmitButton.Enabled = False
        SummaryButton.Enabled = False
    End Sub

    Private Sub AdditionRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles AdditionRadioButton.CheckedChanged
        If AdditionRadioButton.Checked Then
            MathLabel.Text = "+"
            GenerateMathNumbers()
        End If
    End Sub

    Private Sub MultiplicationRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles MultiplicationRadioButton.CheckedChanged
        If MultiplicationRadioButton.Checked Then
            MathLabel.Text = "x"
            GenerateMathNumbers()
        End If
    End Sub

    Private Sub SubtractionRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles SubtractionRadioButton.CheckedChanged
        If SubtractionRadioButton.Checked Then
            MathLabel.Text = "-"
            GenerateMathNumbers()
        End If
    End Sub

    Private Sub DivisionRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles DivisionRadioButton.CheckedChanged
        If DivisionRadioButton.Checked Then
            MathLabel.Text = "/"
            GenerateMathNumbers()
        End If
    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        NameTextBox.Text = ""
        GradeTextBox.Text = ""
        AgeTextBox.Text = ""
        NameTextBox.Focus()
    End Sub

    Private Sub SubmitButton_Click(sender As Object, e As EventArgs) Handles SubmitButton.Click
        Dim studentAnswer As Integer = 0
        Dim correctAnswer As Integer = 0

        totalSubmissionCount += 1

        Select Case MathLabel.Text
            Case "+"
                correctAnswer = CInt(FirstNumberLabel.Text) + CInt(SecondNumberLabel.Text)
            Case "-"
                correctAnswer = CInt(FirstNumberLabel.Text) - CInt(SecondNumberLabel.Text)
            Case "x"
                correctAnswer = CInt(FirstNumberLabel.Text) * CInt(SecondNumberLabel.Text)
            Case "/"
                correctAnswer = CInt(CInt(FirstNumberLabel.Text) / CInt(SecondNumberLabel.Text))
        End Select

        'First, check to see if the answer is valid.
        Try
            studentAnswer = CInt(AnswerBox.Text)

            If studentAnswer = correctAnswer Then
                MsgBox("Your answer was correct!")
                correctAnswerCount += 1
            Else
                MsgBox($"Your answer was wrong. The correct answer is {correctAnswer}.")
            End If

        Catch ex As Exception
            MsgBox($"Your answer was wrong. The correct answer is {correctAnswer}.")
        End Try

        GenerateMathNumbers()
        AnswerBox.Text = ""
        SummaryButton.Enabled = True

    End Sub

    Private Sub SummaryButton_Click(sender As Object, e As EventArgs) Handles SummaryButton.Click
        MsgBox($"{NameTextBox.Text} got {correctAnswerCount} answers correct out of a " &
                 $"possible {totalSubmissionCount}.",, "Total Score")
    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    Private Sub NameTextBox_Lost_Focus(sender As Object, e As EventArgs) Handles NameTextBox.Leave
        If NameTextBox.Text <> "" And GradeTextBox.Text <> "" And AgeTextBox.Text <> "" Then
            ValidateStudentInfo()
        End If
    End Sub

    Private Sub GradeTextBox_Lost_Focus(sender As Object, e As EventArgs) Handles GradeTextBox.Leave
        If NameTextBox.Text <> "" And GradeTextBox.Text <> "" And AgeTextBox.Text <> "" Then
            ValidateStudentInfo()
        End If
    End Sub

    Private Sub AgeTextBox_Lost_Focus(sender As Object, e As EventArgs) Handles AgeTextBox.Leave
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

        If Not validationTrigger Then
            Dim grade As Integer
            Dim age As Integer

            Try
                grade = CInt(GradeTextBox.Text)
            Catch ex As Exception
                MsgBox("The grade value is incorrect. Please enter a grade from 1 - 4.",, "Input Error")
                validationTrigger = True
                GradeTextBox.Focus()
                validationTrigger = False
                Exit Sub
            End Try

            Try
                age = CInt(AgeTextBox.Text)
            Catch ex As Exception
                MsgBox("The age value is incorrect. Please enter an age from 7 - 11.",, "Input Error")
                validationTrigger = True
                AgeTextBox.Focus()
                validationTrigger = False
                Exit Sub
            End Try

            If grade < 1 Or grade > 4 Or age < 7 Or age > 11 Then
                MsgBox("Student is not eligible to compete.",, "Grade and Age Values")
                Exit Sub
            End If

            ProblemTypeGroupBox.Enabled = True
            GenerateMathNumbers()
            SubmitButton.Enabled = True

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

        FirstNumberLabel.Text = CStr(CInt(Math.Floor((upperBound + 1) * Rnd())))
        SecondNumberLabel.Text = CStr(CInt(Math.Floor((upperBound + 1) * Rnd())))

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