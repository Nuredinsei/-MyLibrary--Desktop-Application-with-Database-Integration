using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Library
{
    public partial class MainForm : Form
    {
        private static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyLibrary;Integrated Security=True;";

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadBooks();
            LoadBorrowers();
        }

        private void LoadBooks()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT BookID, Title, Author, Year, AvailableCopies FROM Books";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvBooks.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading books: " + ex.Message);
            }
        }

        private void LoadBorrowers()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT BorrowerID, Name, Email, Phone FROM Borrowers";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvBorrowers.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading borrowers: " + ex.Message);
            }
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            BookForm bookForm = new BookForm();
            if (bookForm.ShowDialog() == DialogResult.OK)
            {
                LoadBooks();
            }
        }

        private void btnEditBook_Click(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a book to edit");
                return;
            }

            int bookId = Convert.ToInt32(dgvBooks.SelectedRows[0].Cells["BookID"].Value);
            BookForm bookForm = new BookForm(bookId);
            if (bookForm.ShowDialog() == DialogResult.OK)
            {
                LoadBooks();
            }
        }

        private void btnDeleteBook_Click(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a book to delete");
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this book?", "Confirm Delete",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int bookId = Convert.ToInt32(dgvBooks.SelectedRows[0].Cells["BookID"].Value);

                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM Books WHERE BookID = @bookId";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@bookId", bookId);
                        cmd.ExecuteNonQuery();
                        LoadBooks();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting book: " + ex.Message);
                }
            }
        }

        private void txtSearchBooks_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearchBooks.Text.Trim();
            if (string.IsNullOrEmpty(searchText))
            {
                LoadBooks();
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT BookID, Title, Author, Year, AvailableCopies FROM Books " +
                                   "WHERE Title LIKE @search OR Author LIKE @search";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@search", "%" + searchText + "%");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvBooks.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching books: " + ex.Message);
            }
        }

        private void btnAddBorrower_Click(object sender, EventArgs e)
        {
            BorrowerForm borrowerForm = new BorrowerForm();
            if (borrowerForm.ShowDialog() == DialogResult.OK)
            {
                LoadBorrowers();
            }
        }

        private void btnEditBorrower_Click(object sender, EventArgs e)
        {
            if (dgvBorrowers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a borrower to edit");
                return;
            }

            int borrowerId = Convert.ToInt32(dgvBorrowers.SelectedRows[0].Cells["BorrowerID"].Value);
            BorrowerForm borrowerForm = new BorrowerForm(borrowerId);
            if (borrowerForm.ShowDialog() == DialogResult.OK)
            {
                LoadBorrowers();
            }
        }

        private void btnDeleteBorrower_Click(object sender, EventArgs e)
        {
            if (dgvBorrowers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a borrower to delete");
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this borrower?", "Confirm Delete",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int borrowerId = Convert.ToInt32(dgvBorrowers.SelectedRows[0].Cells["BorrowerID"].Value);

                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM Borrowers WHERE BorrowerID = @borrowerId";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@borrowerId", borrowerId);
                        cmd.ExecuteNonQuery();
                        LoadBorrowers();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting borrower: " + ex.Message);
                }
            }
        }

        private void btnIssueBook_Click(object sender, EventArgs e)
        {
            if (dgvBorrowers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a borrower");
                return;
            }

            IssueReturnForm issueForm = new IssueReturnForm(
                Convert.ToInt32(dgvBorrowers.SelectedRows[0].Cells["BorrowerID"].Value),
                true);

            if (issueForm.ShowDialog() == DialogResult.OK)
            {
                LoadBooks();
                LoadBorrowers();
            }
        }

        private void btnReturnBook_Click(object sender, EventArgs e)
        {
            if (dgvBorrowers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a borrower");
                return;
            }

            IssueReturnForm returnForm = new IssueReturnForm(
                Convert.ToInt32(dgvBorrowers.SelectedRows[0].Cells["BorrowerID"].Value),
                false);

            if (returnForm.ShowDialog() == DialogResult.OK)
            {
                LoadBooks();
                LoadBorrowers();
            }
        }
    }
}