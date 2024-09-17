namespace WebTask.Utils
{
    public class AppSettings
    {
        public string BaseAddress { get; set; }
        public Settings Settings { get; set; }
    }

    public class Settings
    {
        public string ApiKey { get; set; }
        public string ApiUrl { get; set; }
    }
}
