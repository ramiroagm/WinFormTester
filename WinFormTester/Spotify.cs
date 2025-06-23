namespace WinFormTester
{
    public partial class Spotify : Form
    {
        public Spotify()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TesterProject.BusinessLogic.Spotify.SpotifyConnector connector = new("61c9641414f8426a880b504e5dc9a468");
            _ = connector.CreatingConnectionInformation().ContinueWith(task =>
            {
                //SpotifyAPI.Web.FullTrack track = task.Result;
                //rbSpotifyData.Text = $"Track Name: {track.Name}\nArtist: {track.Artists.First().Name}";
            });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TesterProject.BusinessLogic.Spotify.SpotifyConnector connector = new("61c9641414f8426a880b504e5dc9a468");
            _ = connector.CreatingConnectionPlayback().ContinueWith(task =>
            {
            });
        }
    }
}