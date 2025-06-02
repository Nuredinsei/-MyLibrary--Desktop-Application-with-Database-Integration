using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Library
{
    public partial class BorrowerForm : Form
    {
        private static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyLibrary;Integrated Security=True;";
        
        private readonly int? borrowerId;
        private readonly bool isEditMode;

        public BorrowerForm()
        {
            InitializeComponent();
            isEditMode = false;
            this.Text = "Add New Borrower";
        }

        public BorrowerForm(int borrowerId) : this()
        {
            this.borrowerId = borrowerId;
            isEditMode = true;
            this.Text = "Edit Borrower";
        }

        private void BorrowerForm_Load(object sender, EventArgs e)
        {
            if (isEditMode && borrowerId.HasValue)
            {
                LoadBorrowerData(borrowerId.Value);
            }
        }

        private void LoadBorrowerData(int borrowerId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT Name, Email, Phone FROM Borrowers WHERE BorrowerID = @borrowerId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@borrowerId", borrowerId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtName.Text = reader["Name"].ToString();
                                txtEmail.Text = reader["Email"].ToString();
                                txtPhone.Text = reader["Phone"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading borrower data: " + ex.Message);
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
                if (isEditMode && borrowerId.HasValue)
                {
                    UpdateBorrower(borrowerId.Value);
                }
                else
                {
                    AddNewBorrower();
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                lblError.Text = "Error saving borrower: " + ex.Message;
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                lblError.Text = "Name is required";
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !IsValidEmail(txtEmail.Text))
            {
                lblError.Text = "Valid email is required";
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                lblError.Text = "Phone number is required";
                return false;
            }

            lblError.Text = "";
            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void AddNewBorrower()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"INSERT INTO Borrowers (Name, Email, Phone) 
                                VALUES (@name, @email, @phone)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void UpdateBorrower(int borrowerId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"UPDATE Borrowers 
                                SET Name = @name, 
                                    Email = @email, 
                                    Phone = @phone 
                                WHERE BorrowerID = @borrowerId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());
                    cmd.Parameters.AddWithValue("@borrowerId", borrowerId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}