namespace Library
{
    partial class IssueReturnForm
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
            this.lblAction = new System.Windows.Forms.Label();
            this.lblBorrower = new System.Windows.Forms.Label();
            this.txtBorrower = new System.Windows.Forms.TextBox();
            this.lblBook = new System.Windows.Forms.Label();
            this.cboBooks = new System.Windows.Forms.ComboBox();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.btnAction = new System.Windows.Forms.Button();
            this.lblIssuedBooks = new System.Windows.Forms.Label();
            this.dgvIssuedBooks = new System.Windows.Forms.DataGridView();
            this.lblError = new System.Windows.Forms.Label(); // Assuming you want this label for error display
            ((System.ComponentModel.ISupportInitialize)(this.dgvIssuedBooks)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAction
            // 
            this.lblAction.AutoSize = true;
            this.lblAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAction.Location = new System.Drawing.Point(30, 20);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(125, 25);
            this.lblAction.TabIndex = 0;
            this.lblAction.Text = "ISSUE BOOK"; // Default text, will be changed in IssueReturnForm.cs
            // 
            // lblBorrower
            // 
            this.lblBorrower.AutoSize = true;
            this.lblBorrower.Location = new System.Drawing.Point(30, 70);
            this.lblBorrower.Name = "lblBorrower";
            this.lblBorrower.Size = new System.Drawing.Size(68, 16);
            this.lblBorrower.TabIndex = 1;
            this.lblBorrower.Text = "Borrower:";
            // 
            // txtBorrower
            // 
            this.txtBorrower.Location = new System.Drawing.Point(120, 67);
            this.txtBorrower.Name = "txtBorrower";
            this.txtBorrower.ReadOnly = true; // Typically read-only for display
            this.txtBorrower.Size = new System.Drawing.Size(200, 22);
            this.txtBorrower.TabIndex = 2;
            // 
            // lblBook
            // 
            this.lblBook.AutoSize = true;
            this.lblBook.Location = new System.Drawing.Point(30, 110);
            this.lblBook.Name = "lblBook";
            this.lblBook.Size = new System.Drawing.Size(42, 16);
            this.lblBook.TabIndex = 3;
            this.lblBook.Text = "Book:";
            // 
            // cboBooks
            // 
            this.cboBooks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; // Prevents manual entry
            this.cboBooks.FormattingEnabled = true;
            this.cboBooks.Location = new System.Drawing.Point(120, 107);
            this.cboBooks.Name = "cboBooks";
            this.cboBooks.Size = new System.Drawing.Size(200, 24);
            this.cboBooks.TabIndex = 4;
            // 
            // lblDueDate
            // 
            this.lblDueDate.AutoSize = true;
            this.lblDueDate.Location = new System.Drawing.Point(30, 150);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(69, 16);
            this.lblDueDate.TabIndex = 5;
            this.lblDueDate.Text = "Due Date:";
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short; // Display date only
            this.dtpDueDate.Location = new System.Drawing.Point(120, 147);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(200, 22);
            this.dtpDueDate.TabIndex = 6;
            // 
            // btnAction
            // 
            this.btnAction.Location = new System.Drawing.Point(120, 190);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(120, 30);
            this.btnAction.TabIndex = 7;
            this.btnAction.Text = "Action"; // Default text, will be changed in IssueReturnForm.cs
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click); // Event handler linking
            // 
            // lblIssuedBooks
            // 
            this.lblIssuedBooks.AutoSize = true;
            this.lblIssuedBooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIssuedBooks.Location = new System.Drawing.Point(30, 240);
            this.lblIssuedBooks.Name = "lblIssuedBooks";
            this.lblIssuedBooks.Size = new System.Drawing.Size(125, 20);
            this.lblIssuedBooks.TabIndex = 8;
            this.lblIssuedBooks.Text = "Issued Books:";
            // 
            // dgvIssuedBooks
            // 
            this.dgvIssuedBooks.AllowUserToAddRows = false;
            this.dgvIssuedBooks.AllowUserToDeleteRows = false;
            this.dgvIssuedBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIssuedBooks.Location = new System.Drawing.Point(30, 270);
            this.dgvIssuedBooks.MultiSelect = false; // Allow only single row selection for return
            this.dgvIssuedBooks.Name = "dgvIssuedBooks";
            this.dgvIssuedBooks.ReadOnly = true; // Prevent editing data in the grid
            this.dgvIssuedBooks.RowHeadersWidth = 51;
            this.dgvIssuedBooks.RowTemplate.Height = 24;
            this.dgvIssuedBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect; // Select entire row
            this.dgvIssuedBooks.Size = new System.Drawing.Size(500, 150);
            this.dgvIssuedBooks.TabIndex = 9;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(30, 430);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 16); // Initially empty
            this.lblError.TabIndex = 10;
            // 
            // IssueReturnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 460); // Adjust size as needed
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.dgvIssuedBooks);
            this.Controls.Add(this.lblIssuedBooks);
            this.Controls.Add(this.btnAction);
            this.Controls.Add(this.dtpDueDate);
            this.Controls.Add(this.lblDueDate);
            this.Controls.Add(this.cboBooks);
            this.Controls.Add(this.lblBook);
            this.Controls.Add(this.txtBorrower);
            this.Controls.Add(this.lblBorrower);
            this.Controls.Add(this.lblAction);
            this.Name = "IssueReturnForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent; // Center the form on its parent
            this.Text = "IssueReturnForm"; // Default text, will be changed in IssueReturnForm.cs
            this.Load += new System.EventHandler(this.IssueReturnForm_Load); // Event handler linking
            ((System.ComponentModel.ISupportInitialize)(this.dgvIssuedBooks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAction;
        private System.Windows.Forms.Label lblBorrower;
        private System.Windows.Forms.TextBox txtBorrower;
        private System.Windows.Forms.Label lblBook;
        private System.Windows.Forms.ComboBox cboBooks;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.Label lblIssuedBooks;
        private System.Windows.Forms.DataGridView dgvIssuedBooks;
        private System.Windows.Forms.Label lblError;
    }
}