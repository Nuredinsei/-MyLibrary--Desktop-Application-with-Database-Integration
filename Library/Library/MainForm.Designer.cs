namespace Library
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabBooks = new System.Windows.Forms.TabPage();
            this.dgvBooks = new System.Windows.Forms.DataGridView();
            this.btnAddBook = new System.Windows.Forms.Button();
            this.btnEditBook = new System.Windows.Forms.Button();
            this.btnDeleteBook = new System.Windows.Forms.Button();
            this.txtSearchBooks = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabBorrowers = new System.Windows.Forms.TabPage();
            this.dgvBorrowers = new System.Windows.Forms.DataGridView();
            this.btnAddBorrower = new System.Windows.Forms.Button();
            this.btnEditBorrower = new System.Windows.Forms.Button();
            this.btnDeleteBorrower = new System.Windows.Forms.Button();
            this.btnIssueBook = new System.Windows.Forms.Button();
            this.btnReturnBook = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabBooks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).BeginInit();
            this.tabBorrowers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrowers)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabBooks);
            this.tabControl1.Controls.Add(this.tabBorrowers);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 450);
            this.tabControl1.TabIndex = 0;
            // 
            // tabBooks
            // 
            this.tabBooks.Controls.Add(this.label1);
            this.tabBooks.Controls.Add(this.txtSearchBooks);
            this.tabBooks.Controls.Add(this.btnDeleteBook);
            this.tabBooks.Controls.Add(this.btnEditBook);
            this.tabBooks.Controls.Add(this.btnAddBook);
            this.tabBooks.Controls.Add(this.dgvBooks);
            this.tabBooks.Location = new System.Drawing.Point(4, 22);
            this.tabBooks.Name = "tabBooks";
            this.tabBooks.Padding = new System.Windows.Forms.Padding(3);
            this.tabBooks.Size = new System.Drawing.Size(792, 424);
            this.tabBooks.TabIndex = 0;
            this.tabBooks.Text = "Books Management";
            this.tabBooks.UseVisualStyleBackColor = true;
            // 
            // dgvBooks
            // 
            this.dgvBooks.AllowUserToAddRows = false;
            this.dgvBooks.AllowUserToDeleteRows = false;
            this.dgvBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBooks.Location = new System.Drawing.Point(20, 50);
            this.dgvBooks.Name = "dgvBooks";
            this.dgvBooks.ReadOnly = true;
            this.dgvBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBooks.Size = new System.Drawing.Size(750, 300);
            this.dgvBooks.TabIndex = 0;
            // 
            // btnAddBook
            // 
            this.btnAddBook.Location = new System.Drawing.Point(20, 370);
            this.btnAddBook.Name = "btnAddBook";
            this.btnAddBook.Size = new System.Drawing.Size(100, 30);
            this.btnAddBook.TabIndex = 1;
            this.btnAddBook.Text = "Add Book";
            this.btnAddBook.UseVisualStyleBackColor = true;
            this.btnAddBook.Click += new System.EventHandler(this.btnAddBook_Click);
            // 
            // btnEditBook
            // 
            this.btnEditBook.Location = new System.Drawing.Point(140, 370);
            this.btnEditBook.Name = "btnEditBook";
            this.btnEditBook.Size = new System.Drawing.Size(100, 30);
            this.btnEditBook.TabIndex = 2;
            this.btnEditBook.Text = "Edit Book";
            this.btnEditBook.UseVisualStyleBackColor = true;
            this.btnEditBook.Click += new System.EventHandler(this.btnEditBook_Click);
            // 
            // btnDeleteBook
            // 
            this.btnDeleteBook.Location = new System.Drawing.Point(260, 370);
            this.btnDeleteBook.Name = "btnDeleteBook";
            this.btnDeleteBook.Size = new System.Drawing.Size(100, 30);
            this.btnDeleteBook.TabIndex = 3;
            this.btnDeleteBook.Text = "Delete Book";
            this.btnDeleteBook.UseVisualStyleBackColor = true;
            this.btnDeleteBook.Click += new System.EventHandler(this.btnDeleteBook_Click);
            // 
            // txtSearchBooks
            // 
            this.txtSearchBooks.Location = new System.Drawing.Point(100, 20);
            this.txtSearchBooks.Name = "txtSearchBooks";
            this.txtSearchBooks.Size = new System.Drawing.Size(200, 20);
            this.txtSearchBooks.TabIndex = 4;
            this.txtSearchBooks.TextChanged += new System.EventHandler(this.txtSearchBooks_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Search Books:";
            // 
            // tabBorrowers
            // 
            this.tabBorrowers.Controls.Add(this.btnReturnBook);
            this.tabBorrowers.Controls.Add(this.btnIssueBook);
            this.tabBorrowers.Controls.Add(this.btnDeleteBorrower);
            this.tabBorrowers.Controls.Add(this.btnEditBorrower);
            this.tabBorrowers.Controls.Add(this.btnAddBorrower);
            this.tabBorrowers.Controls.Add(this.dgvBorrowers);
            this.tabBorrowers.Location = new System.Drawing.Point(4, 22);
            this.tabBorrowers.Name = "tabBorrowers";
            this.tabBorrowers.Padding = new System.Windows.Forms.Padding(3);
            this.tabBorrowers.Size = new System.Drawing.Size(792, 424);
            this.tabBorrowers.TabIndex = 1;
            this.tabBorrowers.Text = "Borrowers Management";
            this.tabBorrowers.UseVisualStyleBackColor = true;
            // 
            // dgvBorrowers
            // 
            this.dgvBorrowers.AllowUserToAddRows = false;
            this.dgvBorrowers.AllowUserToDeleteRows = false;
            this.dgvBorrowers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBorrowers.Location = new System.Drawing.Point(20, 20);
            this.dgvBorrowers.Name = "dgvBorrowers";
            this.dgvBorrowers.ReadOnly = true;
            this.dgvBorrowers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBorrowers.Size = new System.Drawing.Size(750, 300);
            this.dgvBorrowers.TabIndex = 0;
            // 
            // btnAddBorrower
            // 
            this.btnAddBorrower.Location = new System.Drawing.Point(20, 350);
            this.btnAddBorrower.Name = "btnAddBorrower";
            this.btnAddBorrower.Size = new System.Drawing.Size(120, 30);
            this.btnAddBorrower.TabIndex = 1;
            this.btnAddBorrower.Text = "Add Borrower";
            this.btnAddBorrower.UseVisualStyleBackColor = true;
            this.btnAddBorrower.Click += new System.EventHandler(this.btnAddBorrower_Click);
            // 
            // btnEditBorrower
            // 
            this.btnEditBorrower.Location = new System.Drawing.Point(160, 350);
            this.btnEditBorrower.Name = "btnEditBorrower";
            this.btnEditBorrower.Size = new System.Drawing.Size(120, 30);
            this.btnEditBorrower.TabIndex = 2;
            this.btnEditBorrower.Text = "Edit Borrower";
            this.btnEditBorrower.UseVisualStyleBackColor = true;
            this.btnEditBorrower.Click += new System.EventHandler(this.btnEditBorrower_Click);
            // 
            // btnDeleteBorrower
            // 
            this.btnDeleteBorrower.Location = new System.Drawing.Point(300, 350);
            this.btnDeleteBorrower.Name = "btnDeleteBorrower";
            this.btnDeleteBorrower.Size = new System.Drawing.Size(120, 30);
            this.btnDeleteBorrower.TabIndex = 3;
            this.btnDeleteBorrower.Text = "Delete Borrower";
            this.btnDeleteBorrower.UseVisualStyleBackColor = true;
            this.btnDeleteBorrower.Click += new System.EventHandler(this.btnDeleteBorrower_Click);
            // 
            // btnIssueBook
            // 
            this.btnIssueBook.Location = new System.Drawing.Point(450, 350);
            this.btnIssueBook.Name = "btnIssueBook";
            this.btnIssueBook.Size = new System.Drawing.Size(120, 30);
            this.btnIssueBook.TabIndex = 4;
            this.btnIssueBook.Text = "Issue Book";
            this.btnIssueBook.UseVisualStyleBackColor = true;
            this.btnIssueBook.Click += new System.EventHandler(this.btnIssueBook_Click);
            // 
            // btnReturnBook
            // 
            this.btnReturnBook.Location = new System.Drawing.Point(590, 350);
            this.btnReturnBook.Name = "btnReturnBook";
            this.btnReturnBook.Size = new System.Drawing.Size(120, 30);
            this.btnReturnBook.TabIndex = 5;
            this.btnReturnBook.Text = "Return Book";
            this.btnReturnBook.UseVisualStyleBackColor = true;
            this.btnReturnBook.Click += new System.EventHandler(this.btnReturnBook_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Library Management System";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabBooks.ResumeLayout(false);
            this.tabBooks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).EndInit();
            this.tabBorrowers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrowers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabBooks;
        private System.Windows.Forms.DataGridView dgvBooks;
        private System.Windows.Forms.TabPage tabBorrowers;
        private System.Windows.Forms.DataGridView dgvBorrowers;
        private System.Windows.Forms.Button btnAddBook;
        private System.Windows.Forms.Button btnEditBook;
        private System.Windows.Forms.Button btnDeleteBook;
        private System.Windows.Forms.TextBox txtSearchBooks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReturnBook;
        private System.Windows.Forms.Button btnIssueBook;
        private System.Windows.Forms.Button btnDeleteBorrower;
        private System.Windows.Forms.Button btnEditBorrower;
        private System.Windows.Forms.Button btnAddBorrower;
    }
}