using System.Diagnostics;
using Microsoft.AspNetCore.SignalR.Client;
using TesterProject.BusinessLogic.Instagram;
using TesterProject.BusinessLogic.Interfaces.DelegateTester;
using TesterProject.BusinessLogic.Interfaces.Instagram;
using TesterProject.BusinessLogic.Interfaces.InyectionTester;

namespace WinFormTester
{
    public partial class Form1 : Form
    {
        private readonly IInyectionTester _inyectionTester;
        private readonly IDelegateTester _delegateTester;
        private readonly IInstagramConnector _instagramConnector;

        public Form1(IInyectionTester inyectionTester, IDelegateTester delegateTester, IInstagramConnector instagramConnector)
        {
            _inyectionTester = inyectionTester ?? throw new ArgumentNullException(nameof(inyectionTester));
            _delegateTester = delegateTester ?? throw new ArgumentException(null, nameof(delegateTester));
            _instagramConnector = instagramConnector ?? throw new ArgumentNullException(null, nameof(InstagramConnectorForm));
            InitializeComponent();
        }

        #region DEPENDENCY INYECTION
        private void btnInyection_Click(object sender, EventArgs e)
        {
            errorProvider1.BlinkRate = 0;

            rtResult.Text = _inyectionTester.DevuelveStringTrim(txtTester.Text);
        }
        #endregion

        #region DELEGADOS
        private void btnDelegate_Click(object sender, EventArgs e)
        {
            errorProvider1.BlinkRate = 0;

            if (!int.TryParse(txtVal1.Text, out int val1) || !int.TryParse(txtVal2.Text, out int val2))
            {
                errorProvider1.DataSource = "Valores no validos";
                errorProvider1.BlinkRate = 500;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;
                errorProvider1.SetError(txtVal1, "Valores no validos");

                MessageBox.Show("Valores no validos", "Error", MessageBoxButtons.OK);

                rtResult.Text = "Valores no validos";
                return;
            }

            IDelegateTester.OperacionMatematica op = _delegateTester.Suma;
            rtResult.Text = "Suma: " + op.Invoke(val1, val2).ToString();

            op = _delegateTester.Resta;
            rtResult.Text += Environment.NewLine + "Resta: " + op.Invoke(val1, val2).ToString();
        }
        #endregion


        private void menúPrincipalToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void botTelegramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelegramBot create = new();
            create.Show();
        }

        private void instagramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InstagramConnectorForm create = new(_instagramConnector);
            create.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://www.linkedin.com/in/ramiroagm/",
                UseShellExecute = true
            });
        }

        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/ramiroagm",
                UseShellExecute = true
            });
        }
    }
}