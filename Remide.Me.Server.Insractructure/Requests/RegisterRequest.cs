namespace Remide.Me.Server.Insractructure.Requests
{
    public class RegisterRequest
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public string Confirm { get; set; }

        public string Email { get; set; }

        public string Description { get; set; }
    }
}