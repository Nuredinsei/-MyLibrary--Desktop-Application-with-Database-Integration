using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Library
{
    public partial class BookForm : Form
    {
        private static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyLibrary;Integrated Security=True;";
        
        private readonly int? bookId;
        private readonly bool isEditMode;

        public BookForm()
        {
            InitializeComponent();
            isEditMode = false;
            this.Text = "Add New Book";
        }

        public BookForm(int bookId) : this()
        {
            this.bookId = bookId;
            isEditMode = true;
            this.Text = "Edit Book";
        }

        private void BookForm_Load(object sender, EventArgs e)
        {
            if (isEditMode && bookId.HasValue)
            {
                LoadBookData(bookId.Value);
            }
        }

        private void LoadBookData(int bookId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT Title, Author, Year, AvailableCopies FROM Books WHERE BookID = @bookId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@bookId", bookId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtTitle.Text = reader["Title"].ToString();
                                txtAuthor.Text = reader["Author"].ToString();
                                txtYear.Text = reader["Year"].ToString();
                                txtCopies.Text = reader["AvailableCopies"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading book data: " + ex.Message);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }

            try
            {
                if (isEditMode && bookId.HasValue)
                {
                    UpdateBook(bookId.Value);
                }
                else
                {
                    AddNewBook();
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                lblError.Text = "Error saving book: " + ex.Message;
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                lblError.Text = "Title is required";
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAuthor.Text))
            {
                lblError.Text = "Author is required";
                return false;
            }

            if (!int.TryParse(txtYear.Text, out int year) || year < 1000 || year > DateTime.Now.Year + 1)
            {
                lblError.Text = "Please enter a valid year (1000-" + (DateTime.Now.Year + 1) + ")";
                return false;
            }

            if (!int.TryParse(txtCopies.Text, out int copies) || copies < 0)
            {
                lblError.Text = "Available copies must be 0 or more";
                return false;
            }

            lblError.Text = "";
            return true;
        }

        private void AddNewBook()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"INSERT INTO Books (Title, Author, Year, AvailableCopies) 
                                VALUES (@title, @author, @year, @copies)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@title", txtTitle.Text.Trim());
                    cmd.Parameters.AddWithValue("@author", txtAuthor.Text.Trim());
                    cmd.Parameters.AddWithValue("@year", Convert.ToInt32(txtYear.Text));
                    cmd.Parameters.AddWithValue("@copies", Convert.ToInt32(txtCopies.Text));
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void UpdateBook(int bookId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"UPDATE Books 
                                SET Title = @title, 
                                    Author = @author, 
                                    Year = @year, 
                                    AvailableCopies = @copies 
                                WHERE BookID = @bookId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@title", txtTitle.Text.Trim());
                    cmd.Parameters.AddWithValue("@author", txtAuthor.Text.Trim());
                    cmd.Parameters.AddWithValue("@year", Convert.ToInt32(txtYear.Text));
                    cmd.Parameters.AddWithValue("@copies", Convert.ToInt32(txtCopies.Text));
                    cmd.Parameters.AddWithValue("@bookId", bookId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}