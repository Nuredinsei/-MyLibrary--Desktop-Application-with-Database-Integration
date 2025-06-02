using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Library
{
    public partial class IssueReturnForm : Form
    {
        // IMPORTANT: Replace "Your_Connection_String_Here" with your actual SQL Server connection string.
        // Example for Windows Authentication: "Data Source=YourServerName;Initial Catalog=YourDatabaseName;Integrated Security=True;"
        // Example for SQL Server Authentication: "Data Source=YourServerName;Initial Catalog=YourDatabaseName;User ID=YourUsername;Password=YourPassword;"
        private const string connectionString = "Data Source=YourServerName;Initial Catalog=YourDatabaseName;Integrated Security=True;";

        private readonly int borrowerId;
        private readonly bool isIssueMode;

        public IssueReturnForm(int borrowerId, bool isIssueMode)
        {
            InitializeComponent();
            this.borrowerId = borrowerId;
            this.isIssueMode = isIssueMode;
            // Set Due Date to a reasonable default, e.g., 2 weeks from today
            dtpDueDate.Value = DateTime.Today.AddDays(14);
        }

        private void IssueReturnForm_Load(object sender, EventArgs e)
        {
            // Set form title and button text based on mode
            if (isIssueMode)
            {
                this.Text = "Issue Book";
                lblAction.Text = "ISSUE BOOK";
                btnAction.Text = "Issue Book";
                LoadAvailableBooks();
                lblBook.Visible = true; // Ensure these are visible for issue mode
                cboBooks.Visible = true;
                lblDueDate.Visible = true;
                dtpDueDate.Visible = true;
                dgvIssuedBooks.Visible = false; // Hide issued books grid in issue mode
            }
            else
            {
                this.Text = "Return Book";
                lblAction.Text = "RETURN BOOK";
                btnAction.Text = "Return Book";
                lblBook.Visible = false;
                cboBooks.Visible = false;
                lblDueDate.Visible = false;
                dtpDueDate.Visible = false;
                dgvIssuedBooks.Visible = true; // Show issued books grid in return mode
            }

            LoadBorrowerInfo();
            LoadIssuedBooks(); // This will load issued books regardless of mode, useful for viewing
        }

        private void LoadBorrowerInfo()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT Name FROM Borrowers WHERE BorrowerID = @borrowerId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@borrowerId", borrowerId);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            txtBorrower.Text = result.ToString();
                        }
                        else
                        {
                            txtBorrower.Text = "Borrower Not Found"; // Handle case where borrower doesn't exist
                            MessageBox.Show("Error: Borrower information not found.", "Borrower Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.Close(); // Close if borrower not found to prevent further issues
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading borrower info: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void LoadAvailableBooks()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT BookID, Title FROM Books WHERE AvailableCopies > 0 ORDER BY Title"; // Added ORDER BY
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cboBooks.DataSource = dt;
                    cboBooks.DisplayMember = "Title";
                    cboBooks.ValueMember = "BookID";

                    if (dt.Rows.Count > 0)
                    {
                        cboBooks.SelectedIndex = 0; // Select the first item by default
                    }
                    else
                    {
                        cboBooks.Text = "No books available"; // Indicate no books
                        btnAction.Enabled = false; // Disable issue button if no books
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading available books: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadIssuedBooks()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT ib.IssueID, b.Title, ib.IssueDate, ib.DueDate 
                                      FROM IssuedBooks ib
                                      JOIN Books b ON ib.BookID = b.BookID
                                      WHERE ib.BorrowerID = @borrowerId AND ib.Returned = 0
                                      ORDER BY ib.IssueDate DESC"; // Order by issue date

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@borrowerId", borrowerId);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvIssuedBooks.DataSource = dt;

                    // Rename column headers for better readability
                    if (dgvIssuedBooks.Columns.Contains("Title"))
                        dgvIssuedBooks.Columns["Title"].HeaderText = "Book Title";
                    if (dgvIssuedBooks.Columns.Contains("IssueDate"))
                        dgvIssuedBooks.Columns["IssueDate"].HeaderText = "Issue Date";
                    if (dgvIssuedBooks.Columns.Contains("DueDate"))
                        dgvIssuedBooks.Columns["DueDate"].HeaderText = "Due Date";
                    if (dgvIssuedBooks.Columns.Contains("IssueID"))
                        dgvIssuedBooks.Columns["IssueID"].Visible = false; // Hide IssueID from general view
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading issued books: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            try
            {
                if (isIssueMode)
                {
                    IssueBook();
                }
                else
                {
                    ReturnBook();
                }

                // If successful, set DialogResult to OK and close the form
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                // Display specific error messages to the user
                MessageBox.Show("Operation failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void IssueBook()
        {
            if (cboBooks.SelectedValue == null)
            {
                throw new Exception("Please select a book to issue.");
            }

            int bookId = (int)cboBooks.SelectedValue;
            DateTime dueDate = dtpDueDate.Value;

            // Basic validation for due date
            if (dueDate < DateTime.Today)
            {
                throw new Exception("Due date cannot be in the past.");
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Check if there are available copies before decrementing
                    string checkAvailabilityQuery = "SELECT AvailableCopies FROM Books WHERE BookID = @bookId";
                    SqlCommand checkCmd = new SqlCommand(checkAvailabilityQuery, conn, transaction);
                    checkCmd.Parameters.AddWithValue("@bookId", bookId);
                    int availableCopies = (int)checkCmd.ExecuteScalar();

                    if (availableCopies <= 0)
                    {
                        throw new Exception("No available copies of this book to issue.");
                    }

                    // Decrement available copies
                    string updateQuery = "UPDATE Books SET AvailableCopies = AvailableCopies - 1 WHERE BookID = @bookId";
                    SqlCommand updateCmd = new SqlCommand(updateQuery, conn, transaction);
                    updateCmd.Parameters.AddWithValue("@bookId", bookId);
                    updateCmd.ExecuteNonQuery();

                    // Create issued book record
                    string insertQuery = @"INSERT INTO IssuedBooks (BookID, BorrowerID, IssueDate, DueDate, Returned) 
                                            VALUES (@bookId, @borrowerId, @issueDate, @dueDate, 0)"; // Explicitly set Returned to 0
                    SqlCommand insertCmd = new SqlCommand(insertQuery, conn, transaction);
                    insertCmd.Parameters.AddWithValue("@bookId", bookId);
                    insertCmd.Parameters.AddWithValue("@borrowerId", borrowerId);
                    insertCmd.Parameters.AddWithValue("@issueDate", DateTime.Today);
                    insertCmd.Parameters.AddWithValue("@dueDate", dueDate);
                    insertCmd.ExecuteNonQuery();

                    transaction.Commit();
                    MessageBox.Show("Book issued successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Failed to issue book: " + ex.Message); // Wrap original exception
                }
            }
        }

        private void ReturnBook()
        {
            if (dgvIssuedBooks.SelectedRows.Count == 0)
            {
                throw new Exception("Please select a book to return from the list of issued books.");
            }

            // Get the IssueID from the selected row
            int issueId = Convert.ToInt32(dgvIssuedBooks.SelectedRows[0].Cells["IssueID"].Value);
            string bookTitle = dgvIssuedBooks.SelectedRows[0].Cells["Book Title"].Value.ToString(); // Get title for confirmation

            if (MessageBox.Show($"Are you sure you want to return '{bookTitle}'?", "Confirm Return", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return; // User cancelled the return
            }

            int bookId = GetBookIdFromIssue(issueId);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Increment available copies
                    string updateQuery = "UPDATE Books SET AvailableCopies = AvailableCopies + 1 WHERE BookID = @bookId";
                    SqlCommand updateCmd = new SqlCommand(updateQuery, conn, transaction);
                    updateCmd.Parameters.AddWithValue("@bookId", bookId);
                    updateCmd.ExecuteNonQuery();

                    // Mark as returned
                    string returnQuery = "UPDATE IssuedBooks SET Returned = 1, ReturnDate = @returnDate WHERE IssueID = @issueId"; // Added ReturnDate
                    SqlCommand returnCmd = new SqlCommand(returnQuery, conn, transaction);
                    returnCmd.Parameters.AddWithValue("@issueId", issueId);
                    returnCmd.Parameters.AddWithValue("@returnDate", DateTime.Today); // Set return date to today
                    returnCmd.ExecuteNonQuery();

                    transaction.Commit();
                    MessageBox.Show("Book returned successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Failed to return book: " + ex.Message); // Wrap original exception
                }
            }
        }

        private int GetBookIdFromIssue(int issueId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT BookID FROM IssuedBooks WHERE IssueID = @issueId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@issueId", issueId);
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    return (int)result;
                }
                else
                {
                    throw new Exception("Could not find associated Book ID for the selected issue record.");
                }
            }
        }
    }
}