namespace CityBreaks.Models
{
    public class SmtpSettings
    {
        public string Host { get; init; }
        public int Port { get; init; }
        public bool StartTls { get; init; }
        public Credentials Credentials { get; init; }
    }

    public class Credentials
    {
        public string UserName { get; init; }
        public string Password { get; init; }
    }
}
