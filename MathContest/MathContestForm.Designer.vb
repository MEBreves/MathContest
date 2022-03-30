<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MathContestForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ClearButton = New System.Windows.Forms.Button()
        Me.AgeTextBox = New System.Windows.Forms.TextBox()
        Me.GradeTextBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NameTextBox = New System.Windows.Forms.TextBox()
        Me.MultiplicationRadioButton = New System.Windows.Forms.RadioButton()
        Me.SubtractionRadioButton = New System.Windows.Forms.RadioButton()
        Me.DivisionRadioButton = New System.Windows.Forms.RadioButton()
        Me.AdditionRadioButton = New System.Windows.Forms.RadioButton()
        Me.ExitButton = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.SecondNumberLabel = New System.Windows.Forms.Label()
        Me.FirstNumberLabel = New System.Windows.Forms.Label()
        Me.AnswerBox = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.MathLabel = New System.Windows.Forms.Label()
        Me.SubmitButton = New System.Windows.Forms.Button()
        Me.SummaryButton = New System.Windows.Forms.Button()
        Me.ProblemTypeGroupBox = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.ProblemTypeGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ClearButton)
        Me.GroupBox1.Controls.Add(Me.AgeTextBox)
        Me.GroupBox1.Controls.Add(Me.GradeTextBox)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.NameTextBox)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(459, 310)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Student Info"
        '
        'ClearButton
        '
        Me.ClearButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ClearButton.Location = New System.Drawing.Point(19, 227)
        Me.ClearButton.Name = "ClearButton"
        Me.ClearButton.Size = New System.Drawing.Size(420, 63)
        Me.ClearButton.TabIndex = 3
        Me.ClearButton.Text = "&Clear Information"
        Me.ClearButton.UseVisualStyleBackColor = True
        '
        'AgeTextBox
        '
        Me.AgeTextBox.Location = New System.Drawing.Point(284, 171)
        Me.AgeTextBox.Name = "AgeTextBox"
        Me.AgeTextBox.Size = New System.Drawing.Size(45, 31)
        Me.AgeTextBox.TabIndex = 2
        Me.AgeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GradeTextBox
        '
        Me.GradeTextBox.Location = New System.Drawing.Point(93, 171)
        Me.GradeTextBox.Name = "GradeTextBox"
        Me.GradeTextBox.Size = New System.Drawing.Size(71, 31)
        Me.GradeTextBox.TabIndex = 1
        Me.GradeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(281, 140)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 25)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Age"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(93, 140)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 25)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Grade"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(148, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Student Name"
        '
        'NameTextBox
        '
        Me.NameTextBox.Location = New System.Drawing.Point(19, 87)
        Me.NameTextBox.Name = "NameTextBox"
        Me.NameTextBox.Size = New System.Drawing.Size(420, 31)
        Me.NameTextBox.TabIndex = 0
        '
        'MultiplicationRadioButton
        '
        Me.MultiplicationRadioButton.AutoSize = True
        Me.MultiplicationRadioButton.Location = New System.Drawing.Point(31, 79)
        Me.MultiplicationRadioButton.Name = "MultiplicationRadioButton"
        Me.MultiplicationRadioButton.Size = New System.Drawing.Size(169, 29)
        Me.MultiplicationRadioButton.TabIndex = 10
        Me.MultiplicationRadioButton.Text = "Multiplication"
        Me.MultiplicationRadioButton.UseVisualStyleBackColor = True
        '
        'SubtractionRadioButton
        '
        Me.SubtractionRadioButton.AutoSize = True
        Me.SubtractionRadioButton.Location = New System.Drawing.Point(261, 44)
        Me.SubtractionRadioButton.Name = "SubtractionRadioButton"
        Me.SubtractionRadioButton.Size = New System.Drawing.Size(152, 29)
        Me.SubtractionRadioButton.TabIndex = 9
        Me.SubtractionRadioButton.Text = "Subtraction"
        Me.SubtractionRadioButton.UseVisualStyleBackColor = True
        '
        'DivisionRadioButton
        '
        Me.DivisionRadioButton.AutoSize = True
        Me.DivisionRadioButton.Location = New System.Drawing.Point(261, 79)
        Me.DivisionRadioButton.Name = "DivisionRadioButton"
        Me.DivisionRadioButton.Size = New System.Drawing.Size(119, 29)
        Me.DivisionRadioButton.TabIndex = 8
        Me.DivisionRadioButton.Text = "Division"
        Me.DivisionRadioButton.UseVisualStyleBackColor = True
        '
        'AdditionRadioButton
        '
        Me.AdditionRadioButton.AutoSize = True
        Me.AdditionRadioButton.Location = New System.Drawing.Point(31, 44)
        Me.AdditionRadioButton.Name = "AdditionRadioButton"
        Me.AdditionRadioButton.Size = New System.Drawing.Size(121, 29)
        Me.AdditionRadioButton.TabIndex = 7
        Me.AdditionRadioButton.Text = "Addition"
        Me.AdditionRadioButton.UseVisualStyleBackColor = True
        '
        'ExitButton
        '
        Me.ExitButton.Location = New System.Drawing.Point(22, 382)
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.Size = New System.Drawing.Size(420, 63)
        Me.ExitButton.TabIndex = 4
        Me.ExitButton.Text = "Finish and E&xit"
        Me.ExitButton.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.SecondNumberLabel)
        Me.GroupBox2.Controls.Add(Me.FirstNumberLabel)
        Me.GroupBox2.Controls.Add(Me.AnswerBox)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.MathLabel)
        Me.GroupBox2.Controls.Add(Me.SubmitButton)
        Me.GroupBox2.Controls.Add(Me.SummaryButton)
        Me.GroupBox2.Controls.Add(Me.ExitButton)
        Me.GroupBox2.Location = New System.Drawing.Point(495, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(461, 462)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Math Problem"
        '
        'SecondNumberLabel
        '
        Me.SecondNumberLabel.AutoSize = True
        Me.SecondNumberLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SecondNumberLabel.Location = New System.Drawing.Point(167, 87)
        Me.SecondNumberLabel.MinimumSize = New System.Drawing.Size(60, 0)
        Me.SecondNumberLabel.Name = "SecondNumberLabel"
        Me.SecondNumberLabel.Size = New System.Drawing.Size(60, 29)
        Me.SecondNumberLabel.TabIndex = 14
        Me.SecondNumberLabel.Text = "0"
        Me.SecondNumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FirstNumberLabel
        '
        Me.FirstNumberLabel.AutoSize = True
        Me.FirstNumberLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FirstNumberLabel.Location = New System.Drawing.Point(34, 87)
        Me.FirstNumberLabel.MinimumSize = New System.Drawing.Size(60, 0)
        Me.FirstNumberLabel.Name = "FirstNumberLabel"
        Me.FirstNumberLabel.Size = New System.Drawing.Size(60, 29)
        Me.FirstNumberLabel.TabIndex = 13
        Me.FirstNumberLabel.Text = "0"
        Me.FirstNumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'AnswerBox
        '
        Me.AnswerBox.Location = New System.Drawing.Point(325, 87)
        Me.AnswerBox.Name = "AnswerBox"
        Me.AnswerBox.Size = New System.Drawing.Size(91, 31)
        Me.AnswerBox.TabIndex = 1
        Me.AnswerBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(249, 87)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(24, 25)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "="
        '
        'MathLabel
        '
        Me.MathLabel.AutoSize = True
        Me.MathLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MathLabel.Location = New System.Drawing.Point(121, 87)
        Me.MathLabel.Name = "MathLabel"
        Me.MathLabel.Size = New System.Drawing.Size(27, 29)
        Me.MathLabel.TabIndex = 9
        Me.MathLabel.Text = "+"
        Me.MathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SubmitButton
        '
        Me.SubmitButton.Location = New System.Drawing.Point(22, 227)
        Me.SubmitButton.Name = "SubmitButton"
        Me.SubmitButton.Size = New System.Drawing.Size(420, 63)
        Me.SubmitButton.TabIndex = 2
        Me.SubmitButton.Text = "Submit &Answer"
        Me.SubmitButton.UseVisualStyleBackColor = True
        '
        'SummaryButton
        '
        Me.SummaryButton.Location = New System.Drawing.Point(22, 304)
        Me.SummaryButton.Name = "SummaryButton"
        Me.SummaryButton.Size = New System.Drawing.Size(420, 63)
        Me.SummaryButton.TabIndex = 3
        Me.SummaryButton.Text = "Create &Summary"
        Me.SummaryButton.UseVisualStyleBackColor = True
        '
        'ProblemTypeGroupBox
        '
        Me.ProblemTypeGroupBox.Controls.Add(Me.SubtractionRadioButton)
        Me.ProblemTypeGroupBox.Controls.Add(Me.DivisionRadioButton)
        Me.ProblemTypeGroupBox.Controls.Add(Me.AdditionRadioButton)
        Me.ProblemTypeGroupBox.Controls.Add(Me.MultiplicationRadioButton)
        Me.ProblemTypeGroupBox.Enabled = False
        Me.ProblemTypeGroupBox.Location = New System.Drawing.Point(15, 342)
        Me.ProblemTypeGroupBox.Name = "ProblemTypeGroupBox"
        Me.ProblemTypeGroupBox.Size = New System.Drawing.Size(455, 131)
        Me.ProblemTypeGroupBox.TabIndex = 11
        Me.ProblemTypeGroupBox.TabStop = False
        Me.ProblemTypeGroupBox.Text = "Problem Type"
        '
        'MathContestForm
        '
        Me.AcceptButton = Me.SubmitButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.CancelButton = Me.ClearButton
        Me.ClientSize = New System.Drawing.Size(974, 494)
        Me.Controls.Add(Me.ProblemTypeGroupBox)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "MathContestForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Math Contest"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ProblemTypeGroupBox.ResumeLayout(False)
        Me.ProblemTypeGroupBox.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents NameTextBox As Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As Windows.Forms.GroupBox
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents ExitButton As Windows.Forms.Button
    Friend WithEvents MultiplicationRadioButton As Windows.Forms.RadioButton
    Friend WithEvents SubtractionRadioButton As Windows.Forms.RadioButton
    Friend WithEvents DivisionRadioButton As Windows.Forms.RadioButton
    Friend WithEvents AdditionRadioButton As Windows.Forms.RadioButton
    Friend WithEvents AgeTextBox As Windows.Forms.TextBox
    Friend WithEvents GradeTextBox As Windows.Forms.TextBox
    Friend WithEvents ClearButton As Windows.Forms.Button
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents MathLabel As Windows.Forms.Label
    Friend WithEvents SubmitButton As Windows.Forms.Button
    Friend WithEvents SummaryButton As Windows.Forms.Button
    Friend WithEvents AnswerBox As Windows.Forms.TextBox
    Friend WithEvents ProblemTypeGroupBox As Windows.Forms.GroupBox
    Friend WithEvents SecondNumberLabel As Windows.Forms.Label
    Friend WithEvents FirstNumberLabel As Windows.Forms.Label
End Class
