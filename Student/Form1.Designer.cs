namespace Student
{
    partial class StudentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.studentLabel = new System.Windows.Forms.Label();
            this.studentHeaderPanel = new System.Windows.Forms.Panel();
            this.sendAnsGroupBox = new System.Windows.Forms.GroupBox();
            this.answerTextBox = new System.Windows.Forms.TextBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.questionTextBox = new System.Windows.Forms.TextBox();
            this.studentAnswerLabel = new System.Windows.Forms.Label();
            this.quesLabel = new System.Windows.Forms.Label();
            this.studentBodyPanel = new System.Windows.Forms.Panel();
            this.studentExitButton = new System.Windows.Forms.Button();
            this.readOnlyToolTip = new System.Windows.Forms.ToolTip();
            this.studentHeaderPanel.SuspendLayout();
            this.sendAnsGroupBox.SuspendLayout();
            this.studentBodyPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // studentLabel
            // 
            this.studentLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.studentLabel.AutoSize = true;
            this.studentLabel.Font = new System.Drawing.Font("Britannic Bold", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentLabel.ForeColor = System.Drawing.Color.White;
            this.studentLabel.Location = new System.Drawing.Point(123, 9);
            this.studentLabel.Margin = new System.Windows.Forms.Padding(0);
            this.studentLabel.Name = "studentLabel";
            this.studentLabel.Size = new System.Drawing.Size(142, 41);
            this.studentLabel.TabIndex = 0;
            this.studentLabel.Text = "Student";
            this.studentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // studentHeaderPanel
            // 
            this.studentHeaderPanel.BackColor = System.Drawing.Color.RoyalBlue;
            this.studentHeaderPanel.Controls.Add(this.studentLabel);
            this.studentHeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.studentHeaderPanel.Name = "studentHeaderPanel";
            this.studentHeaderPanel.Size = new System.Drawing.Size(385, 63);
            this.studentHeaderPanel.TabIndex = 0;
            // 
            // sendAnsGroupBox
            // 
            this.sendAnsGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.sendAnsGroupBox.Controls.Add(this.answerTextBox);
            this.sendAnsGroupBox.Controls.Add(this.submitButton);
            this.sendAnsGroupBox.Controls.Add(this.questionTextBox);
            this.sendAnsGroupBox.Controls.Add(this.studentAnswerLabel);
            this.sendAnsGroupBox.Controls.Add(this.quesLabel);
            this.sendAnsGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendAnsGroupBox.Location = new System.Drawing.Point(12, 24);
            this.sendAnsGroupBox.Name = "sendAnsGroupBox";
            this.sendAnsGroupBox.Size = new System.Drawing.Size(360, 228);
            this.sendAnsGroupBox.TabIndex = 0;
            this.sendAnsGroupBox.TabStop = false;
            this.sendAnsGroupBox.Text = "Enter your answer and click SUBMIT";
            // 
            // answerTextBox
            // 
            this.answerTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.answerTextBox.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.answerTextBox.Location = new System.Drawing.Point(145, 80);
            this.answerTextBox.Name = "answerTextBox";
            this.answerTextBox.Size = new System.Drawing.Size(200, 26);
            this.answerTextBox.TabIndex = 2;
            // 
            // submitButton
            // 
            this.submitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.submitButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.submitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitButton.Location = new System.Drawing.Point(245, 120);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(100, 28);
            this.submitButton.TabIndex = 3;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // questionTextBox
            // 
            this.questionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.questionTextBox.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.questionTextBox.Location = new System.Drawing.Point(145, 41);
            this.questionTextBox.Name = "questionTextBox";
            this.questionTextBox.ReadOnly = true;
            this.questionTextBox.Size = new System.Drawing.Size(200, 26);
            this.questionTextBox.TabIndex = 1;
            this.questionTextBox.TabStop = false;
            this.readOnlyToolTip.SetToolTip(this.questionTextBox, "Cannot alter question!");
            // 
            // studentAnswerLabel
            // 
            this.studentAnswerLabel.AutoSize = true;
            this.studentAnswerLabel.Location = new System.Drawing.Point(54, 84);
            this.studentAnswerLabel.Name = "studentAnswerLabel";
            this.studentAnswerLabel.Size = new System.Drawing.Size(85, 16);
            this.studentAnswerLabel.TabIndex = 0;
            this.studentAnswerLabel.Text = "Your Answer:";
            // 
            // quesLabel
            // 
            this.quesLabel.AutoSize = true;
            this.quesLabel.Location = new System.Drawing.Point(76, 45);
            this.quesLabel.Name = "quesLabel";
            this.quesLabel.Size = new System.Drawing.Size(63, 16);
            this.quesLabel.TabIndex = 0;
            this.quesLabel.Text = "Question:";
            // 
            // studentBodyPanel
            // 
            this.studentBodyPanel.BackgroundImage = global::Student.Properties.Resources.student_background;
            this.studentBodyPanel.Controls.Add(this.sendAnsGroupBox);
            this.studentBodyPanel.Controls.Add(this.studentExitButton);
            this.studentBodyPanel.Location = new System.Drawing.Point(0, 54);
            this.studentBodyPanel.Name = "studentBodyPanel";
            this.studentBodyPanel.Size = new System.Drawing.Size(385, 309);
            this.studentBodyPanel.TabIndex = 0;
            // 
            // studentExitButton
            // 
            this.studentExitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.studentExitButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.studentExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentExitButton.Location = new System.Drawing.Point(257, 267);
            this.studentExitButton.Name = "studentExitButton";
            this.studentExitButton.Size = new System.Drawing.Size(100, 28);
            this.studentExitButton.TabIndex = 4;
            this.studentExitButton.Text = "Exit";
            this.studentExitButton.UseVisualStyleBackColor = true;
            this.studentExitButton.Click += new System.EventHandler(this.studentExitButton_Click);
            // 
            // readOnlyToolTip
            // 
            this.readOnlyToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.readOnlyToolTip.ToolTipTitle = "ReadOnly:";
            // 
            // StudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.studentHeaderPanel);
            this.Controls.Add(this.studentBodyPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(1320, 300);
            this.MaximizeBox = false;
            this.Name = "StudentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Student";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StudentForm_FormClosed);
            this.studentHeaderPanel.ResumeLayout(false);
            this.studentHeaderPanel.PerformLayout();
            this.sendAnsGroupBox.ResumeLayout(false);
            this.sendAnsGroupBox.PerformLayout();
            this.studentBodyPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label studentLabel;
        private System.Windows.Forms.Panel studentHeaderPanel;
        private System.Windows.Forms.GroupBox sendAnsGroupBox;
        private System.Windows.Forms.TextBox questionTextBox;
        private System.Windows.Forms.Label studentAnswerLabel;
        private System.Windows.Forms.Label quesLabel;
        private System.Windows.Forms.Panel studentBodyPanel;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.TextBox answerTextBox;
        private System.Windows.Forms.Button studentExitButton;
        private System.Windows.Forms.ToolTip readOnlyToolTip;
    }
}

