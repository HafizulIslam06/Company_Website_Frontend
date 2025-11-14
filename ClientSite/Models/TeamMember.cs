namespace ClientSite.Models
{
    public class TeamMember
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Role { get; set; }
        public string? Bio { get; set; }

        // Base64 string returned from API
        public string? Photo { get; set; }

        // Auto-formatted Base64 with prefix for <img src="">
        public string? PhotoBase64
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Photo))
                    return null;

                return $"data:image/jpeg;base64,{Photo}";
            }
        }

        public string? FacebookUrl { get; set; }
        public string? InstagramUrl { get; set; }
        public string? LinkedInUrl { get; set; }
        public string? GitHubUrl { get; set; }
    }

}
