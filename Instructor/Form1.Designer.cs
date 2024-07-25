namespace Instructor
{
    partial class InstructorForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.instructorHeaderPanel = new System.Windows.Forms.Panel();
            this.instructorLabel = new System.Windows.Forms.Label();
            this.instructorBodyPanel = new System.Windows.Forms.Panel();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.hashSearchButton = new System.Windows.Forms.Button();
            this.binarySearchButton = new System.Windows.Forms.Button();
            this.allQuesGroupBox = new System.Windows.Forms.GroupBox();
            this.searchDisplayTextBox = new System.Windows.Forms.TextBox();
            this.displayLinkedListButton = new System.Windows.Forms.Button();
            this.instructorExitButton = new System.Windows.Forms.Button();
            this.incorrectQuesGroupBox = new System.Windows.Forms.GroupBox();
            this.linkedListDisplayTextBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.inOrderPanel = new System.Windows.Forms.Panel();
            this.inOrderLabel = new System.Windows.Forms.Label();
            this.inDisplayButton = new System.Windows.Forms.Button();
            this.postOrderPanel = new System.Windows.Forms.Panel();
            this.postOrderLabel = new System.Windows.Forms.Label();
            this.inSaveButton = new System.Windows.Forms.Button();
            this.postSaveButton = new System.Windows.Forms.Button();
            this.postDisplayButton = new System.Windows.Forms.Button();
            this.preOrderPanel = new System.Windows.Forms.Panel();
            this.preOrderLabel = new System.Windows.Forms.Label();
            this.preSaveButton = new System.Windows.Forms.Button();
            this.preDisplayButton = new System.Windows.Forms.Button();
            this.selectionSortButton = new System.Windows.Forms.Button();
            this.insertionSortButton = new System.Windows.Forms.Button();
            this.bubbleSortButton = new System.Windows.Forms.Button();
            this.sendButton = new System.Windows.Forms.Button();
            this.sendQuesGroupBox = new System.Windows.Forms.GroupBox();
            this.operatorComboBox = new System.Windows.Forms.ComboBox();
            this.answerTextBox = new System.Windows.Forms.TextBox();
            this.secondNumTextBox = new System.Windows.Forms.TextBox();
            this.firstNumTextBox = new System.Windows.Forms.TextBox();
            this.answerLabel = new System.Windows.Forms.Label();
            this.operatorLabel = new System.Windows.Forms.Label();
            this.secondNumLabel = new System.Windows.Forms.Label();
            this.firstNumLabel = new System.Windows.Forms.Label();
            this.sortQuesGroupBox = new System.Windows.Forms.GroupBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exampleToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.readOnlyToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.instructorHeaderPanel.SuspendLayout();
            this.instructorBodyPanel.SuspendLayout();
            this.allQuesGroupBox.SuspendLayout();
            this.incorrectQuesGroupBox.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.inOrderPanel.SuspendLayout();
            this.postOrderPanel.SuspendLayout();
            this.preOrderPanel.SuspendLayout();
            this.sendQuesGroupBox.SuspendLayout();
            this.sortQuesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // instructorHeaderPanel
            // 
            this.instructorHeaderPanel.BackColor = System.Drawing.Color.RoyalBlue;
            this.instructorHeaderPanel.Controls.Add(this.instructorLabel);
            this.instructorHeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.instructorHeaderPanel.Name = "instructorHeaderPanel";
            this.instructorHeaderPanel.Size = new System.Drawing.Size(984, 63);
            this.instructorHeaderPanel.TabIndex = 0;
            // 
            // instructorLabel
            // 
            this.instructorLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.instructorLabel.AutoSize = true;
            this.instructorLabel.Font = new System.Drawing.Font("Britannic Bold", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instructorLabel.ForeColor = System.Drawing.Color.White;
            this.instructorLabel.Location = new System.Drawing.Point(402, 9);
            this.instructorLabel.Margin = new System.Windows.Forms.Padding(0);
            this.instructorLabel.Name = "instructorLabel";
            this.instructorLabel.Size = new System.Drawing.Size(183, 41);
            this.instructorLabel.TabIndex = 0;
            this.instructorLabel.Text = "Instructor";
            this.instructorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // instructorBodyPanel
            // 
            this.instructorBodyPanel.BackColor = System.Drawing.Color.Transparent;
            this.instructorBodyPanel.BackgroundImage = global::Instructor.Properties.Resources.instructor_background;
            this.instructorBodyPanel.Controls.Add(this.searchTextBox);
            this.instructorBodyPanel.Controls.Add(this.hashSearchButton);
            this.instructorBodyPanel.Controls.Add(this.binarySearchButton);
            this.instructorBodyPanel.Controls.Add(this.allQuesGroupBox);
            this.instructorBodyPanel.Controls.Add(this.displayLinkedListButton);
            this.instructorBodyPanel.Controls.Add(this.instructorExitButton);
            this.instructorBodyPanel.Controls.Add(this.incorrectQuesGroupBox);
            this.instructorBodyPanel.Controls.Add(this.groupBox3);
            this.instructorBodyPanel.Controls.Add(this.selectionSortButton);
            this.instructorBodyPanel.Controls.Add(this.insertionSortButton);
            this.instructorBodyPanel.Controls.Add(this.bubbleSortButton);
            this.instructorBodyPanel.Controls.Add(this.sendButton);
            this.instructorBodyPanel.Controls.Add(this.sendQuesGroupBox);
            this.instructorBodyPanel.Controls.Add(this.sortQuesGroupBox);
            this.instructorBodyPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instructorBodyPanel.Location = new System.Drawing.Point(0, 60);
            this.instructorBodyPanel.Name = "instructorBodyPanel";
            this.instructorBodyPanel.Size = new System.Drawing.Size(984, 676);
            this.instructorBodyPanel.TabIndex = 0;
            // 
            // searchTextBox
            // 
            this.searchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchTextBox.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchTextBox.Location = new System.Drawing.Point(19, 518);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(150, 26);
            this.searchTextBox.TabIndex = 9;
            this.searchTextBox.Tag = "";
            this.exampleToolTip.SetToolTip(this.searchTextBox, "4 + 4 = 8");
            // 
            // hashSearchButton
            // 
            this.hashSearchButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hashSearchButton.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.hashSearchButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.hashSearchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hashSearchButton.Location = new System.Drawing.Point(331, 518);
            this.hashSearchButton.Name = "hashSearchButton";
            this.hashSearchButton.Size = new System.Drawing.Size(150, 28);
            this.hashSearchButton.TabIndex = 11;
            this.hashSearchButton.Text = "Hash Search";
            this.hashSearchButton.UseVisualStyleBackColor = true;
            this.hashSearchButton.Click += new System.EventHandler(this.hashSearchButton_Click);
            // 
            // binarySearchButton
            // 
            this.binarySearchButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.binarySearchButton.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.binarySearchButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.binarySearchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.binarySearchButton.Location = new System.Drawing.Point(175, 518);
            this.binarySearchButton.Name = "binarySearchButton";
            this.binarySearchButton.Size = new System.Drawing.Size(150, 28);
            this.binarySearchButton.TabIndex = 10;
            this.binarySearchButton.Text = "Binary Search";
            this.binarySearchButton.UseVisualStyleBackColor = true;
            this.binarySearchButton.Click += new System.EventHandler(this.binarySearchButton_Click);
            // 
            // allQuesGroupBox
            // 
            this.allQuesGroupBox.Controls.Add(this.searchDisplayTextBox);
            this.allQuesGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.allQuesGroupBox.Location = new System.Drawing.Point(12, 270);
            this.allQuesGroupBox.Name = "allQuesGroupBox";
            this.allQuesGroupBox.Size = new System.Drawing.Size(475, 260);
            this.allQuesGroupBox.TabIndex = 9;
            this.allQuesGroupBox.TabStop = false;
            this.allQuesGroupBox.Text = "Binary Tree (of all questions - displayed in the order asked)";
            // 
            // searchDisplayTextBox
            // 
            this.searchDisplayTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchDisplayTextBox.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchDisplayTextBox.Location = new System.Drawing.Point(6, 21);
            this.searchDisplayTextBox.Multiline = true;
            this.searchDisplayTextBox.Name = "searchDisplayTextBox";
            this.searchDisplayTextBox.ReadOnly = true;
            this.searchDisplayTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.searchDisplayTextBox.Size = new System.Drawing.Size(463, 221);
            this.searchDisplayTextBox.TabIndex = 0;
            this.searchDisplayTextBox.TabStop = false;
            // 
            // displayLinkedListButton
            // 
            this.displayLinkedListButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.displayLinkedListButton.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.displayLinkedListButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.displayLinkedListButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayLinkedListButton.Location = new System.Drawing.Point(503, 518);
            this.displayLinkedListButton.Name = "displayLinkedListButton";
            this.displayLinkedListButton.Size = new System.Drawing.Size(150, 28);
            this.displayLinkedListButton.TabIndex = 12;
            this.displayLinkedListButton.Text = "Display Linked List";
            this.displayLinkedListButton.UseVisualStyleBackColor = true;
            this.displayLinkedListButton.Click += new System.EventHandler(this.displayLinkedListButton_Click);
            // 
            // instructorExitButton
            // 
            this.instructorExitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.instructorExitButton.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.instructorExitButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.instructorExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instructorExitButton.Location = new System.Drawing.Point(816, 518);
            this.instructorExitButton.Name = "instructorExitButton";
            this.instructorExitButton.Size = new System.Drawing.Size(150, 28);
            this.instructorExitButton.TabIndex = 19;
            this.instructorExitButton.Text = "Exit";
            this.instructorExitButton.UseVisualStyleBackColor = true;
            this.instructorExitButton.Click += new System.EventHandler(this.instructorExitButton_Click);
            // 
            // incorrectQuesGroupBox
            // 
            this.incorrectQuesGroupBox.Controls.Add(this.linkedListDisplayTextBox);
            this.incorrectQuesGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.incorrectQuesGroupBox.Location = new System.Drawing.Point(497, 270);
            this.incorrectQuesGroupBox.Name = "incorrectQuesGroupBox";
            this.incorrectQuesGroupBox.Size = new System.Drawing.Size(475, 260);
            this.incorrectQuesGroupBox.TabIndex = 12;
            this.incorrectQuesGroupBox.TabStop = false;
            this.incorrectQuesGroupBox.Text = "Linked List (of all incorrectly answered questions)";
            // 
            // linkedListDisplayTextBox
            // 
            this.linkedListDisplayTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.linkedListDisplayTextBox.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkedListDisplayTextBox.Location = new System.Drawing.Point(6, 21);
            this.linkedListDisplayTextBox.Multiline = true;
            this.linkedListDisplayTextBox.Name = "linkedListDisplayTextBox";
            this.linkedListDisplayTextBox.ReadOnly = true;
            this.linkedListDisplayTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.linkedListDisplayTextBox.Size = new System.Drawing.Size(463, 221);
            this.linkedListDisplayTextBox.TabIndex = 0;
            this.linkedListDisplayTextBox.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.inOrderPanel);
            this.groupBox3.Controls.Add(this.inDisplayButton);
            this.groupBox3.Controls.Add(this.postOrderPanel);
            this.groupBox3.Controls.Add(this.inSaveButton);
            this.groupBox3.Controls.Add(this.postSaveButton);
            this.groupBox3.Controls.Add(this.postDisplayButton);
            this.groupBox3.Controls.Add(this.preOrderPanel);
            this.groupBox3.Controls.Add(this.preSaveButton);
            this.groupBox3.Controls.Add(this.preDisplayButton);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 552);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(960, 112);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            // 
            // inOrderPanel
            // 
            this.inOrderPanel.BackColor = System.Drawing.Color.RoyalBlue;
            this.inOrderPanel.Controls.Add(this.inOrderLabel);
            this.inOrderPanel.Location = new System.Drawing.Point(378, 21);
            this.inOrderPanel.Name = "inOrderPanel";
            this.inOrderPanel.Size = new System.Drawing.Size(206, 40);
            this.inOrderPanel.TabIndex = 0;
            // 
            // inOrderLabel
            // 
            this.inOrderLabel.AutoSize = true;
            this.inOrderLabel.Font = new System.Drawing.Font("Britannic Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inOrderLabel.ForeColor = System.Drawing.Color.White;
            this.inOrderLabel.Location = new System.Drawing.Point(53, 5);
            this.inOrderLabel.Margin = new System.Windows.Forms.Padding(0);
            this.inOrderLabel.Name = "inOrderLabel";
            this.inOrderLabel.Size = new System.Drawing.Size(100, 27);
            this.inOrderLabel.TabIndex = 0;
            this.inOrderLabel.Text = "In-Order";
            this.inOrderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // inDisplayButton
            // 
            this.inDisplayButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.inDisplayButton.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.inDisplayButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.inDisplayButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inDisplayButton.Location = new System.Drawing.Point(378, 71);
            this.inDisplayButton.Name = "inDisplayButton";
            this.inDisplayButton.Size = new System.Drawing.Size(100, 28);
            this.inDisplayButton.TabIndex = 15;
            this.inDisplayButton.Text = "Display";
            this.inDisplayButton.UseVisualStyleBackColor = true;
            this.inDisplayButton.Click += new System.EventHandler(this.inDisplayButton_Click);
            // 
            // postOrderPanel
            // 
            this.postOrderPanel.BackColor = System.Drawing.Color.RoyalBlue;
            this.postOrderPanel.Controls.Add(this.postOrderLabel);
            this.postOrderPanel.Location = new System.Drawing.Point(739, 21);
            this.postOrderPanel.Name = "postOrderPanel";
            this.postOrderPanel.Size = new System.Drawing.Size(206, 40);
            this.postOrderPanel.TabIndex = 0;
            // 
            // postOrderLabel
            // 
            this.postOrderLabel.AutoSize = true;
            this.postOrderLabel.Font = new System.Drawing.Font("Britannic Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.postOrderLabel.ForeColor = System.Drawing.Color.White;
            this.postOrderLabel.Location = new System.Drawing.Point(40, 5);
            this.postOrderLabel.Margin = new System.Windows.Forms.Padding(0);
            this.postOrderLabel.Name = "postOrderLabel";
            this.postOrderLabel.Size = new System.Drawing.Size(125, 27);
            this.postOrderLabel.TabIndex = 0;
            this.postOrderLabel.Text = "Post-Order";
            this.postOrderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // inSaveButton
            // 
            this.inSaveButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.inSaveButton.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.inSaveButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.inSaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inSaveButton.Location = new System.Drawing.Point(484, 71);
            this.inSaveButton.Name = "inSaveButton";
            this.inSaveButton.Size = new System.Drawing.Size(100, 28);
            this.inSaveButton.TabIndex = 16;
            this.inSaveButton.Text = "Save";
            this.inSaveButton.UseVisualStyleBackColor = true;
            this.inSaveButton.Click += new System.EventHandler(this.inSaveButton_Click);
            // 
            // postSaveButton
            // 
            this.postSaveButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.postSaveButton.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.postSaveButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.postSaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.postSaveButton.Location = new System.Drawing.Point(845, 71);
            this.postSaveButton.Name = "postSaveButton";
            this.postSaveButton.Size = new System.Drawing.Size(100, 28);
            this.postSaveButton.TabIndex = 18;
            this.postSaveButton.Text = "Save";
            this.postSaveButton.UseVisualStyleBackColor = true;
            this.postSaveButton.Click += new System.EventHandler(this.postSaveButton_Click);
            // 
            // postDisplayButton
            // 
            this.postDisplayButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.postDisplayButton.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.postDisplayButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.postDisplayButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.postDisplayButton.Location = new System.Drawing.Point(739, 71);
            this.postDisplayButton.Name = "postDisplayButton";
            this.postDisplayButton.Size = new System.Drawing.Size(100, 28);
            this.postDisplayButton.TabIndex = 17;
            this.postDisplayButton.Text = "Display";
            this.postDisplayButton.UseVisualStyleBackColor = true;
            this.postDisplayButton.Click += new System.EventHandler(this.postDisplayButton_Click);
            // 
            // preOrderPanel
            // 
            this.preOrderPanel.BackColor = System.Drawing.Color.RoyalBlue;
            this.preOrderPanel.Controls.Add(this.preOrderLabel);
            this.preOrderPanel.Location = new System.Drawing.Point(15, 21);
            this.preOrderPanel.Name = "preOrderPanel";
            this.preOrderPanel.Size = new System.Drawing.Size(206, 40);
            this.preOrderPanel.TabIndex = 0;
            // 
            // preOrderLabel
            // 
            this.preOrderLabel.AutoSize = true;
            this.preOrderLabel.Font = new System.Drawing.Font("Britannic Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.preOrderLabel.ForeColor = System.Drawing.Color.White;
            this.preOrderLabel.Location = new System.Drawing.Point(48, 5);
            this.preOrderLabel.Margin = new System.Windows.Forms.Padding(0);
            this.preOrderLabel.Name = "preOrderLabel";
            this.preOrderLabel.Size = new System.Drawing.Size(115, 27);
            this.preOrderLabel.TabIndex = 0;
            this.preOrderLabel.Text = "Pre-Order";
            this.preOrderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // preSaveButton
            // 
            this.preSaveButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.preSaveButton.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.preSaveButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.preSaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.preSaveButton.Location = new System.Drawing.Point(121, 71);
            this.preSaveButton.Name = "preSaveButton";
            this.preSaveButton.Size = new System.Drawing.Size(100, 28);
            this.preSaveButton.TabIndex = 14;
            this.preSaveButton.Text = "Save";
            this.preSaveButton.UseVisualStyleBackColor = true;
            this.preSaveButton.Click += new System.EventHandler(this.preSaveButton_Click);
            // 
            // preDisplayButton
            // 
            this.preDisplayButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.preDisplayButton.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.preDisplayButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.preDisplayButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.preDisplayButton.Location = new System.Drawing.Point(15, 71);
            this.preDisplayButton.Name = "preDisplayButton";
            this.preDisplayButton.Size = new System.Drawing.Size(100, 28);
            this.preDisplayButton.TabIndex = 13;
            this.preDisplayButton.Text = "Display";
            this.preDisplayButton.UseVisualStyleBackColor = true;
            this.preDisplayButton.Click += new System.EventHandler(this.preDisplayButton_Click);
            // 
            // selectionSortButton
            // 
            this.selectionSortButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.selectionSortButton.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.selectionSortButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.selectionSortButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectionSortButton.Location = new System.Drawing.Point(606, 226);
            this.selectionSortButton.Name = "selectionSortButton";
            this.selectionSortButton.Size = new System.Drawing.Size(150, 28);
            this.selectionSortButton.TabIndex = 7;
            this.selectionSortButton.Text = "Selection Sort (desc)";
            this.selectionSortButton.UseVisualStyleBackColor = true;
            this.selectionSortButton.Click += new System.EventHandler(this.selectionSortButton_Click);
            // 
            // insertionSortButton
            // 
            this.insertionSortButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.insertionSortButton.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.insertionSortButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.insertionSortButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.insertionSortButton.Location = new System.Drawing.Point(816, 226);
            this.insertionSortButton.Name = "insertionSortButton";
            this.insertionSortButton.Size = new System.Drawing.Size(150, 28);
            this.insertionSortButton.TabIndex = 8;
            this.insertionSortButton.Text = "Insertion Sort (asc)";
            this.insertionSortButton.UseVisualStyleBackColor = true;
            this.insertionSortButton.Click += new System.EventHandler(this.insertionSortButton_Click);
            // 
            // bubbleSortButton
            // 
            this.bubbleSortButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bubbleSortButton.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.bubbleSortButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bubbleSortButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bubbleSortButton.Location = new System.Drawing.Point(396, 226);
            this.bubbleSortButton.Name = "bubbleSortButton";
            this.bubbleSortButton.Size = new System.Drawing.Size(150, 28);
            this.bubbleSortButton.TabIndex = 6;
            this.bubbleSortButton.Text = "Bubble Sort (asc)";
            this.bubbleSortButton.UseVisualStyleBackColor = true;
            this.bubbleSortButton.Click += new System.EventHandler(this.bubbleSortButton_Click);
            // 
            // sendButton
            // 
            this.sendButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sendButton.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.sendButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.sendButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendButton.Location = new System.Drawing.Point(225, 226);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(100, 28);
            this.sendButton.TabIndex = 5;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // sendQuesGroupBox
            // 
            this.sendQuesGroupBox.Controls.Add(this.operatorComboBox);
            this.sendQuesGroupBox.Controls.Add(this.answerTextBox);
            this.sendQuesGroupBox.Controls.Add(this.secondNumTextBox);
            this.sendQuesGroupBox.Controls.Add(this.firstNumTextBox);
            this.sendQuesGroupBox.Controls.Add(this.answerLabel);
            this.sendQuesGroupBox.Controls.Add(this.operatorLabel);
            this.sendQuesGroupBox.Controls.Add(this.secondNumLabel);
            this.sendQuesGroupBox.Controls.Add(this.firstNumLabel);
            this.sendQuesGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendQuesGroupBox.Location = new System.Drawing.Point(12, 22);
            this.sendQuesGroupBox.Name = "sendQuesGroupBox";
            this.sendQuesGroupBox.Size = new System.Drawing.Size(334, 217);
            this.sendQuesGroupBox.TabIndex = 1;
            this.sendQuesGroupBox.TabStop = false;
            this.sendQuesGroupBox.Text = "Enter question, then click SEND";
            // 
            // operatorComboBox
            // 
            this.operatorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.operatorComboBox.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.operatorComboBox.FormattingEnabled = true;
            this.operatorComboBox.Location = new System.Drawing.Point(213, 78);
            this.operatorComboBox.Name = "operatorComboBox";
            this.operatorComboBox.Size = new System.Drawing.Size(100, 26);
            this.operatorComboBox.TabIndex = 2;
            // 
            // answerTextBox
            // 
            this.answerTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.answerTextBox.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.answerTextBox.Location = new System.Drawing.Point(213, 162);
            this.answerTextBox.Name = "answerTextBox";
            this.answerTextBox.ReadOnly = true;
            this.answerTextBox.Size = new System.Drawing.Size(100, 26);
            this.answerTextBox.TabIndex = 4;
            this.answerTextBox.TabStop = false;
            this.readOnlyToolTip.SetToolTip(this.answerTextBox, "Calculated automatically");
            // 
            // secondNumTextBox
            // 
            this.secondNumTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.secondNumTextBox.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.secondNumTextBox.Location = new System.Drawing.Point(213, 121);
            this.secondNumTextBox.Name = "secondNumTextBox";
            this.secondNumTextBox.Size = new System.Drawing.Size(100, 26);
            this.secondNumTextBox.TabIndex = 3;
            // 
            // firstNumTextBox
            // 
            this.firstNumTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.firstNumTextBox.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstNumTextBox.Location = new System.Drawing.Point(213, 38);
            this.firstNumTextBox.Name = "firstNumTextBox";
            this.firstNumTextBox.Size = new System.Drawing.Size(100, 26);
            this.firstNumTextBox.TabIndex = 1;
            // 
            // answerLabel
            // 
            this.answerLabel.AutoSize = true;
            this.answerLabel.Location = new System.Drawing.Point(147, 166);
            this.answerLabel.Name = "answerLabel";
            this.answerLabel.Size = new System.Drawing.Size(54, 16);
            this.answerLabel.TabIndex = 0;
            this.answerLabel.Text = "Answer:";
            // 
            // operatorLabel
            // 
            this.operatorLabel.AutoSize = true;
            this.operatorLabel.Location = new System.Drawing.Point(138, 83);
            this.operatorLabel.Name = "operatorLabel";
            this.operatorLabel.Size = new System.Drawing.Size(63, 16);
            this.operatorLabel.TabIndex = 0;
            this.operatorLabel.Text = "Operator:";
            // 
            // secondNumLabel
            // 
            this.secondNumLabel.AutoSize = true;
            this.secondNumLabel.Location = new System.Drawing.Point(96, 125);
            this.secondNumLabel.Name = "secondNumLabel";
            this.secondNumLabel.Size = new System.Drawing.Size(105, 16);
            this.secondNumLabel.TabIndex = 0;
            this.secondNumLabel.Text = "Second number:";
            // 
            // firstNumLabel
            // 
            this.firstNumLabel.AutoSize = true;
            this.firstNumLabel.Location = new System.Drawing.Point(118, 42);
            this.firstNumLabel.Name = "firstNumLabel";
            this.firstNumLabel.Size = new System.Drawing.Size(83, 16);
            this.firstNumLabel.TabIndex = 0;
            this.firstNumLabel.Text = "First number:";
            // 
            // sortQuesGroupBox
            // 
            this.sortQuesGroupBox.Controls.Add(this.dataGridView);
            this.sortQuesGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sortQuesGroupBox.Location = new System.Drawing.Point(390, 22);
            this.sortQuesGroupBox.Name = "sortQuesGroupBox";
            this.sortQuesGroupBox.Size = new System.Drawing.Size(582, 217);
            this.sortQuesGroupBox.TabIndex = 6;
            this.sortQuesGroupBox.TabStop = false;
            this.sortQuesGroupBox.Text = "Array of questions asked";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dataGridView.Location = new System.Drawing.Point(6, 21);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView.RowHeadersWidth = 25;
            this.dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.dataGridView.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView.Size = new System.Drawing.Size(570, 177);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.TabStop = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Number 1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column2
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Column2.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column2.HeaderText = "Math";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Number 2";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column4
            // 
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Column4.DefaultCellStyle = dataGridViewCellStyle8;
            this.Column4.HeaderText = "=";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Answer";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // exampleToolTip
            // 
            this.exampleToolTip.Tag = "";
            this.exampleToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.exampleToolTip.ToolTipTitle = "Example:";
            // 
            // readOnlyToolTip
            // 
            this.readOnlyToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.readOnlyToolTip.ToolTipTitle = "ReadOnly:";
            // 
            // InstructorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 736);
            this.Controls.Add(this.instructorHeaderPanel);
            this.Controls.Add(this.instructorBodyPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(300, 300);
            this.MaximizeBox = false;
            this.Name = "InstructorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Instructor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.InstructorForm_FormClosed);
            this.instructorHeaderPanel.ResumeLayout(false);
            this.instructorHeaderPanel.PerformLayout();
            this.instructorBodyPanel.ResumeLayout(false);
            this.instructorBodyPanel.PerformLayout();
            this.allQuesGroupBox.ResumeLayout(false);
            this.allQuesGroupBox.PerformLayout();
            this.incorrectQuesGroupBox.ResumeLayout(false);
            this.incorrectQuesGroupBox.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.inOrderPanel.ResumeLayout(false);
            this.inOrderPanel.PerformLayout();
            this.postOrderPanel.ResumeLayout(false);
            this.postOrderPanel.PerformLayout();
            this.preOrderPanel.ResumeLayout(false);
            this.preOrderPanel.PerformLayout();
            this.sendQuesGroupBox.ResumeLayout(false);
            this.sendQuesGroupBox.PerformLayout();
            this.sortQuesGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel instructorBodyPanel;
        private System.Windows.Forms.Panel instructorHeaderPanel;
        private System.Windows.Forms.Label instructorLabel;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.GroupBox sendQuesGroupBox;
        private System.Windows.Forms.GroupBox sortQuesGroupBox;
        private System.Windows.Forms.Button bubbleSortButton;
        private System.Windows.Forms.Button selectionSortButton;
        private System.Windows.Forms.Button insertionSortButton;
        private System.Windows.Forms.GroupBox allQuesGroupBox;
        private System.Windows.Forms.Button binarySearchButton;
        private System.Windows.Forms.GroupBox incorrectQuesGroupBox;
        private System.Windows.Forms.Button instructorExitButton;
        private System.Windows.Forms.Button displayLinkedListButton;
        private System.Windows.Forms.Button hashSearchButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.TextBox searchDisplayTextBox;
        private System.Windows.Forms.TextBox linkedListDisplayTextBox;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox answerTextBox;
        private System.Windows.Forms.TextBox secondNumTextBox;
        private System.Windows.Forms.TextBox firstNumTextBox;
        private System.Windows.Forms.Label answerLabel;
        private System.Windows.Forms.Label operatorLabel;
        private System.Windows.Forms.Label secondNumLabel;
        private System.Windows.Forms.Label firstNumLabel;
        private System.Windows.Forms.ComboBox operatorComboBox;
        private System.Windows.Forms.Panel inOrderPanel;
        private System.Windows.Forms.Label inOrderLabel;
        private System.Windows.Forms.Button inDisplayButton;
        private System.Windows.Forms.Panel postOrderPanel;
        private System.Windows.Forms.Label postOrderLabel;
        private System.Windows.Forms.Button inSaveButton;
        private System.Windows.Forms.Button postSaveButton;
        private System.Windows.Forms.Button postDisplayButton;
        private System.Windows.Forms.Panel preOrderPanel;
        private System.Windows.Forms.Label preOrderLabel;
        private System.Windows.Forms.Button preSaveButton;
        private System.Windows.Forms.Button preDisplayButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.ToolTip exampleToolTip;
        private System.Windows.Forms.ToolTip readOnlyToolTip;
    }
}

