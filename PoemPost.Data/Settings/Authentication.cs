namespace PoemPost.Data.Settings
{
    public class Authentication
    {
        public string Authority { get; set; }
        public bool RequireHttpsMetadata { get; set; }
        public string Audience { get; set; }
    }
}
