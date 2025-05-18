using InstagramApiSharp.API;
using TesterProject.BusinessEntities.Instagram;
using TesterProject.BusinessLogic.Interfaces.Instagram;

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

                rtxtLog.AppendText($"[Connecting to Instagram with user {username}]{Environment.NewLine}");
                _instaApi = await _instagramConnector.CreateConnection(username, password);
                if (_instaApi != null)
                {
                    btnConnect.Enabled = false;
                    btnSend.Enabled = true;
                }
                rtxtLog.AppendText("[Connected to Instagram]{Environment.NewLine}");
            }
            catch (Exception ex)
            {
                rtxtLog.AppendText($"ERROR [Error connecting to Instagram: {ex.InnerException}]{Environment.NewLine}");
            }
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (_instaApi == null)
                {
                    rtxtLog.AppendText("ERROR [Please connect to Instagram first]{Environment.NewLine}");
                    return;
                }

                string userToMessage = txtUserToSend.Text;
                string textMessage = txtMessage.Text;

                rtxtLog.AppendText("[Sending message]{Environment.NewLine}");
                _ = await _instagramConnector.SendMessage(_instaApi, textMessage, userToMessage);
                rtxtLog.AppendText($"[Message \"{txtMessage.Text}\" sent to {txtUserToSend.Text}]{Environment.NewLine}");
            }
            catch (Exception ex)
            {
                rtxtLog.AppendText($"Error: {ex.Message}{Environment.NewLine}");
            }
        }

        private async void btnGetMsg_Click(object sender, EventArgs e)
        {
            try
            {
                if (_instaApi == null)
                {
                    rtxtLog.AppendText("ERROR: [Please connect to Instagram first]{Environment.NewLine}");
                    return;
                }

                int cantMessages = string.IsNullOrEmpty(txtCantMsg.Text) ? 1 : Convert.ToInt32(txtCantMsg.Text);

                rtxtLog.AppendText("[Getting messages]{Environment.NewLine}");
                List<InstagramMessage> result = await _instagramConnector.ReceiveMessages(_instaApi, cantMessages);
                List<InstagramMessage> orderedResult = [.. result.OrderByDescending(x => x.UserId)];
                foreach (InstagramMessage? a in orderedResult)
                {
                    rtxtLog.AppendText($"From {a.UserId}:  {a.Message}");
                }
            }
            catch (Exception ex)
            {
                rtxtLog.AppendText($"Error: {ex.Message}{Environment.NewLine}");
            }
        }
    }
}
