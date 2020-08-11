namespace Healthcare020.OAuth.Models
{
    public class ClientCredentials
    {
        public string Client_Id { get; set; }
        public string Client_Secret { get; set; }
        public string Grant_Type { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Scope { get; set; }
        public string Image { get; set; }
    }
}