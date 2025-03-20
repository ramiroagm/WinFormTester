using Microsoft.AspNetCore.SignalR.Client;
using TesterProyect.BusinessLogic.Interfaces;

namespace WinFormTester
{
    public partial class Form1 : Form
    {
        private HubConnection _hubConnection;
        private readonly IInyectionTester _inyectionTester;
        private readonly IDelegateTester _delegateTester;

        public Form1(IInyectionTester inyectionTester, IDelegateTester delegateTester)
        {
            _inyectionTester = inyectionTester ?? throw new ArgumentNullException(nameof(inyectionTester));
            _delegateTester = delegateTester ?? throw new ArgumentException(null, nameof(delegateTester));
            InitializeComponent();

            // Initialize the SignalR connection
            _hubConnection = new HubConnectionBuilder()
                .WithUrl("http://localhost/chathub")
                .Build();

            // Register event handlers
            _hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                Invoke(() =>
                {
                    // Update the UI with the received message
                    listBoxMessages.Items.Add($"{user}: {message}");
                });
            });

            // Start the connection
            StartConnection();
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

        #region SIGNALIR
        private async void StartConnection()
        {
            try
            {
                await _hubConnection.StartAsync();
                listBoxMessages.Items.Add("Connection started");
            }
            catch (Exception ex)
            {
                listBoxMessages.Items.Add($"Connection error: {ex.Message}");
            }
        }

        private void buttonSend_ClickAsync(object sender, EventArgs e)
        {
            if (_hubConnection.State == HubConnectionState.Connected)
            {
                _hubConnection.InvokeAsync("SendMessage", "User", textBoxMessage.Text);
            }
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
    }
}