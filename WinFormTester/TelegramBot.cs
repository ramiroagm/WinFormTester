using TelegramBot;
using TesterProyect.BusinessLogic.TelegramBot;

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
            rtxtLog.Text = "Conectando con servicio. ..";
            var result = await connection.InitializeBot();

            if (result != null)
            {
                if (result.MsgTypeId == (int)TypeEnum.CORRECT_RESPONSE)
                {
                    rtxtResult.Text = result.Message;
                }
                else
                {
                    rtxtLog.Text = result.Message;
                }
            }

            TelegramDatabaseInformation t = new();
            var a = await t.GetInformation(result.ChatId.Value);
            foreach (var h in a)
            {
                rtxtLog.Text += h.ChatId.ToString() + " wrote " + h.Message;
            }
        }

        private void btnSendMsg_Click(object sender, EventArgs e)
        {
            TelegramConnector connection = new();
        }
    }
}
