using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using TesterProject.BusinessLogic.PasswordManager;

namespace WinFormTester
{
    public partial class CreateAccountForm : Form
    {
        private readonly string _connectionString;
        public CreateAccountForm(string connectionString)
        {
            _connectionString = connectionString;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password;
            if (txtPassword.Text == txtRptPwd.Text)
            {
                if (txtPassword.Text.IsNullOrEmpty())
                {
                    MessageBox.Show("Password cannot be empty", "Error");
                    return;
                }
                password = txtPassword.Text;
            }
            else
            {
                MessageBox.Show("Passwords do not match", "Error");
                return;
            }

            PasswordHasher.HashResult hashResult = PasswordHasher.HashPassword(password);
            string hashedPassword = hashResult.Hash;
            byte[] salt = hashResult.Salt;

            if (StoreUserInDatabase(username, hashedPassword, salt))
            {
                Hide();
            }
        }

        private bool StoreUserInDatabase(string username, string hashedPassword, byte[] salt)
        {
            // TODO: Use stored procedure or ORM instead of inline SQL
            using SqlConnection connection = new(_connectionString);
            SqlCommand command = new("INSERT INTO Test_Users (Test_UserName, Test_PasswordHash, Test_Salt) VALUES (@username, @passwordHash, @salt)", connection);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@passwordHash", hashedPassword);
            command.Parameters.AddWithValue("@salt", salt);

            connection.Open();
            int result = command.ExecuteNonQuery();
            if (result == 1)
            {
                MessageBox.Show("User created successfully");
                return true;
            }
            else
            {
                MessageBox.Show("Error creating user");
                return false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}