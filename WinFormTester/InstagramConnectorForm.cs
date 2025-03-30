using InstagramApiSharp.API;
using TesterProyect.BusinessLogic.Interfaces;

namespace WinFormTester
{
    public partial class InstagramConnectorForm : Form
    {
        private readonly IInstagramConnector _instagramConnector;
        private IInstaApi? _instaApi;

        public InstagramConnectorForm(IInstagramConnector instagramConnector)
        {
            InitializeComponent();
            _instagramConnector = instagramConnector;
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUserName.Text;
                string password = txtPassword.Text;

                rtxtLog.Text = $"[Connecting to Instagram with user {username}]";
                _instaApi = await _instagramConnector.CreateConnection(username, password);
                if (_instaApi != null)
                {
                    btnConnect.Enabled = false;
                    btnSend.Enabled = true;
                }
                rtxtLog.Text = "[Connected to Instagram]";

            }
            catch (Exception ex)
            {
                rtxtLog.Text = $"ERROR [Error connecting to Instagram: {ex.InnerException}]";
            }
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (_instaApi == null)
                {
                    rtxtLog.Text = "ERROR [Please connect to Instagram first]";
                    return;
                }

                string userToMessage = txtUserToSend.Text;
                string textMessage = txtMessage.Text;

                rtxtLog.Text = "[Sending message]";
                _ = await _instagramConnector.SendMessage(_instaApi, userToMessage, textMessage);
                rtxtLog.Text = $"[Message \"{txtMessage.Text}\" sent to {txtUserToSend.Text}]";
            }
            catch (Exception ex)
            {
                rtxtLog.Text = $"Error: {ex.Message}";
            }
        }

        private async void btnGetMsg_Click(object sender, EventArgs e)
        {
            try
            {
                if (_instaApi == null)
                {
                    rtxtLog.Text = "ERROR: [Please connect to Instagram first]";
                    return;
                }

                int cantMessages = string.IsNullOrEmpty(txtCantMsg.Text) ? 1 : Convert.ToInt32(txtCantMsg.Text);

                rtxtLog.Text = "[Getting messages]";
                List<TesterProyect.BusinessEntities.InstagramMessage> result = await _instagramConnector.ReceiveMessages(_instaApi, cantMessages);
                List<TesterProyect.BusinessEntities.InstagramMessage> orderedResult = result.OrderByDescending(x => x.UserId).ToList();
                string resultWindow = "";
                foreach (TesterProyect.BusinessEntities.InstagramMessage? a in orderedResult)
                {
                    resultWindow += $"From {a.UserId}:  {a.Message}";
                }

                rtxtLog.Text = resultWindow;
            }
            catch (Exception ex)
            {
                rtxtLog.Text = $"Error: {ex.Message}";
            }
        }
    }
}
