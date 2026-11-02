namespace QuizMaster.Forms
{
    partial class QuizzesControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblHeading = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lvQuizzes = new System.Windows.Forms.ListView();
            this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Duration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Questions = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Available = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlForm = new System.Windows.Forms.Panel();
            this.lblT = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.numDuration = new System.Windows.Forms.NumericUpDown();
            this.lblF = new System.Windows.Forms.Label();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.lblU = new System.Windows.Forms.Label();
            this.dtUntil = new System.Windows.Forms.DateTimePicker();
            this.btnSaveDraft = new System.Windows.Forms.Button();
            this.btnPublish = new System.Windows.Forms.Button();
            this.btnManage = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.pnlForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDuration)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.lblHeading.Location = new System.Drawing.Point(0, 0);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(202, 41);
            this.lblHeading.TabIndex = 0;
            this.lblHeading.Text = "My Quizzes";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(208, 10);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(200, 34);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "All",
            "Draft",
            "Published",
            "Closed"});
            this.cmbStatus.Location = new System.Drawing.Point(451, 8);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(120, 36);
            this.cmbStatus.TabIndex = 2;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(165)))), ((int)(((byte)(38)))));
            this.btnNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.btnNew.Location = new System.Drawing.Point(588, 10);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(158, 36);
            this.btnNew.TabIndex = 3;
            this.btnNew.Text = "New Quiz";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(68)))), ((int)(((byte)(47)))));
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(68)))), ((int)(((byte)(47)))));
            this.btnDelete.Location = new System.Drawing.Point(766, 9);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 36);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lvQuizzes
            // 
            this.lvQuizzes.BackColor = System.Drawing.Color.White;
            this.lvQuizzes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Title,
            this.Duration,
            this.Questions,
            this.Available,
            this.Status});
            this.lvQuizzes.FullRowSelect = true;
            this.lvQuizzes.GridLines = true;
            this.lvQuizzes.HideSelection = false;
            this.lvQuizzes.Location = new System.Drawing.Point(0, 62);
            this.lvQuizzes.MultiSelect = false;
            this.lvQuizzes.Name = "lvQuizzes";
            this.lvQuizzes.Size = new System.Drawing.Size(856, 180);
            this.lvQuizzes.TabIndex = 6;
            this.lvQuizzes.UseCompatibleStateImageBehavior = false;
            this.lvQuizzes.View = System.Windows.Forms.View.Details;
            this.lvQuizzes.SelectedIndexChanged += new System.EventHandler(this.lvQuizzes_SelectedIndexChanged);
            // 
            // Title
            // 
            this.Title.Text = "Title";
            this.Title.Width = 250;
            // 
            // Duration
            // 
            this.Duration.Text = "Duration";
            this.Duration.Width = 120;
            // 
            // Questions
            // 
            this.Questions.Text = "Questions";
            this.Questions.Width = 120;
            // 
            // Available
            // 
            this.Available.Text = "Available";
            this.Available.Width = 220;
            // 
            // Status
            // 
            this.Status.Text = "Status";
            this.Status.Width = 150;
            // 
            // pnlForm
            // 
            this.pnlForm.BackColor = System.Drawing.Color.White;
            this.pnlForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlForm.Controls.Add(this.dtUntil);
            this.pnlForm.Controls.Add(this.lblU);
            this.pnlForm.Controls.Add(this.dtFrom);
            this.pnlForm.Controls.Add(this.lblF);
            this.pnlForm.Controls.Add(this.numDuration);
            this.pnlForm.Controls.Add(this.lblID);
            this.pnlForm.Controls.Add(this.txtTitle);
            this.pnlForm.Controls.Add(this.lblT);
            this.pnlForm.Location = new System.Drawing.Point(0, 276);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(762, 150);
            this.pnlForm.TabIndex = 7;
            // 
            // lblT
            // 
            this.lblT.AutoSize = true;
            this.lblT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(90)))), ((int)(((byte)(92)))));
            this.lblT.Location = new System.Drawing.Point(12, 10);
            this.lblT.Name = "lblT";
            this.lblT.Size = new System.Drawing.Size(94, 28);
            this.lblT.TabIndex = 0;
            this.lblT.Text = "Quiz Title";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(12, 40);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(340, 34);
            this.txtTitle.TabIndex = 1;
            this.txtTitle.TextChanged += new System.EventHandler(this.txtTitle_TextChanged);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(90)))), ((int)(((byte)(92)))));
            this.lblID.Location = new System.Drawing.Point(380, 10);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(139, 28);
            this.lblID.TabIndex = 2;
            this.lblID.Text = "Duration (min)";
            // 
            // numDuration
            // 
            this.numDuration.Location = new System.Drawing.Point(380, 40);
            this.numDuration.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numDuration.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDuration.Name = "numDuration";
            this.numDuration.Size = new System.Drawing.Size(120, 34);
            this.numDuration.TabIndex = 3;
            this.numDuration.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // lblF
            // 
            this.lblF.AutoSize = true;
            this.lblF.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(90)))), ((int)(((byte)(92)))));
            this.lblF.Location = new System.Drawing.Point(12, 82);
            this.lblF.Name = "lblF";
            this.lblF.Size = new System.Drawing.Size(143, 28);
            this.lblF.TabIndex = 4;
            this.lblF.Text = "Available From";
            // 
            // dtFrom
            // 
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFrom.Location = new System.Drawing.Point(12, 110);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(200, 34);
            this.dtFrom.TabIndex = 5;
            // 
            // lblU
            // 
            this.lblU.AutoSize = true;
            this.lblU.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(90)))), ((int)(((byte)(92)))));
            this.lblU.Location = new System.Drawing.Point(375, 82);
            this.lblU.Name = "lblU";
            this.lblU.Size = new System.Drawing.Size(139, 28);
            this.lblU.TabIndex = 6;
            this.lblU.Text = "Available Until";
            // 
            // dtUntil
            // 
            this.dtUntil.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtUntil.Location = new System.Drawing.Point(385, 110);
            this.dtUntil.Name = "dtUntil";
            this.dtUntil.Size = new System.Drawing.Size(200, 34);
            this.dtUntil.TabIndex = 7;
            // 
            // btnSaveDraft
            // 
            this.btnSaveDraft.BackColor = System.Drawing.Color.Transparent;
            this.btnSaveDraft.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveDraft.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.btnSaveDraft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveDraft.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.btnSaveDraft.Location = new System.Drawing.Point(0, 440);
            this.btnSaveDraft.Name = "btnSaveDraft";
            this.btnSaveDraft.Size = new System.Drawing.Size(185, 36);
            this.btnSaveDraft.TabIndex = 8;
            this.btnSaveDraft.Text = "Save as Draft";
            this.btnSaveDraft.UseVisualStyleBackColor = false;
            this.btnSaveDraft.Click += new System.EventHandler(this.btnSaveDraft_Click);
            // 
            // btnPublish
            // 
            this.btnPublish.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(165)))), ((int)(((byte)(38)))));
            this.btnPublish.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPublish.FlatAppearance.BorderSize = 0;
            this.btnPublish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPublish.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.btnPublish.Location = new System.Drawing.Point(208, 440);
            this.btnPublish.Name = "btnPublish";
            this.btnPublish.Size = new System.Drawing.Size(110, 36);
            this.btnPublish.TabIndex = 9;
            this.btnPublish.Text = "Publish";
            this.btnPublish.UseVisualStyleBackColor = false;
            this.btnPublish.Click += new System.EventHandler(this.btnPublish_Click);
            // 
            // btnManage
            // 
            this.btnManage.BackColor = System.Drawing.Color.Transparent;
            this.btnManage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnManage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.btnManage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(54)))), ((int)(((byte)(58)))));
            this.btnManage.Location = new System.Drawing.Point(341, 440);
            this.btnManage.Name = "btnManage";
            this.btnManage.Size = new System.Drawing.Size(160, 36);
            this.btnManage.TabIndex = 10;
            this.btnManage.Text = "Manage Questions";
            this.btnManage.UseVisualStyleBackColor = false;
            this.btnManage.Click += new System.EventHandler(this.btnManage_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(542, 448);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(65, 28);
            this.lblMessage.TabIndex = 11;
            this.lblMessage.Text = "label1";
            // 
            // QuizzesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(243)))), ((int)(((byte)(236)))));
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnManage);
            this.Controls.Add(this.btnPublish);
            this.Controls.Add(this.btnSaveDraft);
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.lvQuizzes);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblHeading);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "QuizzesControl";
            this.Size = new System.Drawing.Size(931, 700);
            this.Load += new System.EventHandler(this.QuizzesControl_Load);
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDuration)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ListView lvQuizzes;
        private System.Windows.Forms.ColumnHeader Title;
        private System.Windows.Forms.ColumnHeader Duration;
        private System.Windows.Forms.ColumnHeader Questions;
        private System.Windows.Forms.ColumnHeader Available;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Label lblT;
        private System.Windows.Forms.NumericUpDown numDuration;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Label lblF;
        private System.Windows.Forms.DateTimePicker dtUntil;
        private System.Windows.Forms.Label lblU;
        private System.Windows.Forms.Button btnSaveDraft;
        private System.Windows.Forms.Button btnPublish;
        private System.Windows.Forms.Button btnManage;
        private System.Windows.Forms.Label lblMessage;
    }
}
