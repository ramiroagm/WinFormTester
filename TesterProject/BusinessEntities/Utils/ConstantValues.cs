namespace TesterProject.BusinessEntities.Utils
{
    public static class ConstantValues
    {
        // Azure Key Values
        public static readonly string A_TelegramKeyValue = "TelegramKeyCode";
        public static readonly string A_ConnectionString = "ConnectionString";

        // Google Key Values
        [Obsolete("ID ya sin funcionamento - ID Previo respaldo")]
        public static readonly string G_ProjectIdPrev = "tribal-bonsai-455602-p8";
        public static readonly string G_ProjectId = "condado-del-monte";
        public static readonly string G_TelegramKey = "telegram_api_key";
        public static readonly string G_ConnectionString = "connection_string";
        public static readonly string G_SpotifyClientId = "spotify_client_id";
        public static readonly string G_SpotifyClientSecret = "spotify_client_secret";

        // InfoCredito Key Values
        public static readonly string IC_PathToSave = "C:\\lib\\bugreport";

        // Windows Credential Manager
        public static readonly string CM_ConnectionString = "connection_string";
        public static readonly string CM_TelegramKey = "telegram_api_key";
        public static readonly string CM_SpotifyClientId = "spotify_client_id";
        public static readonly string CM_SpotifyClientSecret = "spotify_client_secret";
    }
}