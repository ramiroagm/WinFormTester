using TelegramBot;

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
            TelegramResult result = await TelegramConnector.InitializeBot();
            if (result.MsgTypeId == (int)TypeEnum.CORRECT_RESPONSE)
            {
                rtxtResult.Text = result.Message;
            }
            else
            {
                rtxtLog.Text = result.Message;
            }
        }
    }
}
