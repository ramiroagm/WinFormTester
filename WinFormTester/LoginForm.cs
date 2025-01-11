using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Identity.Client;
using TesterProyect.Interfaces;

namespace WinFormTester
{
    public partial class LoginForm : Form
    {
        private readonly IInyectionTester _inyectionTester;
        private readonly IDelegateTester _delegateTester;

        public LoginForm(IInyectionTester inyectionTester, IDelegateTester delegateTester)
        {
            _inyectionTester = inyectionTester ?? throw new ArgumentNullException(nameof(inyectionTester));
            _delegateTester = delegateTester ?? throw new ArgumentException(nameof(delegateTester));
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Form1 form1 = new(_inyectionTester, _delegateTester);
            form1.Show();
            this.Hide();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void btnCreateAcc_Click(object sender, EventArgs e)
        {
            
        }
    }
}
