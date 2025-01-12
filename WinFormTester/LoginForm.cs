using Microsoft.Data.SqlClient;
using TesterProyect;
using TesterProyect.Interfaces;
using static TesterProyect.PasswordHasher;

namespace WinFormTester
{
    public partial class LoginForm : Form
    {
        private readonly IInyectionTester _inyectionTester;
        private readonly IDelegateTester _delegateTester;
        private readonly string _connectionString;

        public LoginForm(IInyectionTester inyectionTester, IDelegateTester delegateTester, string connectionString)
        {
            _inyectionTester = inyectionTester ?? throw new ArgumentNullException(nameof(inyectionTester));
            _delegateTester = delegateTester ?? throw new ArgumentNullException(nameof(delegateTester));
            _connectionString = connectionString;
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            HashResult? passwordVerifier = GetUserName(txtUsername.Text);
            if (passwordVerifier != null)
            {
                if (VerifyPassword(txtPassword.Text, passwordVerifier.Hash, passwordVerifier.Salt))
                {
                    Form1 form1 = new(_inyectionTester, _delegateTester);
                    form1.Show();
                    Hide(); 
                }
                else
                {
                    MessageBox.Show("Invalid username or password", "Error");
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password", "Error");
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void btnCreateAcc_Click(object sender, EventArgs e)
        {
            CreateAccountForm create = new(_connectionString);
            create.Show();
        }

        private HashResult? GetUserName(string userName)
        {
            using SqlConnection connection = new(_connectionString);
            SqlCommand command = new("SELECT Test_UserName, Test_PasswordHash, Test_Salt FROM Test_Users WHERE Test_UserName = @username", connection);
            command.Parameters.AddWithValue("@username", userName);
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                HashResult hashResult = new()
                {
                    Hash = reader["Test_PasswordHash"].ToString() ?? string.Empty,
                    Salt = reader["Test_Salt"] as byte[] ?? []
                };
                return hashResult;
            }
            else
            {
                return null;
            }
        }
    }
}
