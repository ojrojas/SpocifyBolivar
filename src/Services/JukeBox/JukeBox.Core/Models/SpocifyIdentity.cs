namespace JukeBox.Core.Models
{
    public class SpocifyIdentity : BaseEntity
    {
        public string Code { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public string StateSpocify { get; set; }
        public string FullName { get; set; }
    }
}