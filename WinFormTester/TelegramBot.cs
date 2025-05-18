using TesterProject.BusinessEntities.Telegram;
using TesterProject.BusinessEntities.Utils;
using TesterProject.BusinessLogic.TelegramBot;

namespace WinFormTester
{
    public partial class TelegramBot : Form
    {
        public TelegramBot()
        {
            InitializeComponent();
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            TelegramConnector connection = new();
            connection.MessageReceived += Connection_MessageReceived;
            connection.ErrorOccurred += Connection_ErrorOccurred;
            connection.UpdateOccurred += Connection_UpdateOccurred;

            rtxtLog.Text = "[Connecting to service]";
            var result = await connection.InitializeBot();

            if (result != null)
            {
                if (result.MsgTypeId == (int)TypeEnum.CORRECT_RESPONSE)
                {
                    rtxtLog.Text = result.Message + Environment.NewLine;
                }
                else
                {
                    rtxtLog.Text = result.Message + Environment.NewLine;
                }
            }
        }

        private void Connection_MessageReceived(object? sender, TelegramResult e)
        {
            rtxtResult.Invoke((MethodInvoker)(() => rtxtLog.AppendText($"Message: {e.ChatId} sent: {e.Message}{Environment.NewLine}")));
        }

        private void Connection_ErrorOccurred(object? sender, TelegramResult e)
        {
            rtxtLog.Invoke((MethodInvoker)(() => rtxtLog.AppendText($"Error: {e.Message}{Environment.NewLine}")));
        }

        private void Connection_UpdateOccurred(object? sender, TelegramResult e)
        {
            rtxtResult.Invoke((MethodInvoker)(() => rtxtLog.AppendText($"Update: {e.ChatId} sent: {e.Message}{Environment.NewLine}")));
        }

        private void btnSendMsg_Click(object sender, EventArgs e)
        {
            TelegramConnector connection = new();
        }
    }
}
