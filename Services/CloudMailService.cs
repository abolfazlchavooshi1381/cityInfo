namespace CityInfo.API.Services
{
    public class CloudMailService : IMailService
    {
        private readonly string mailTo = string.Empty;
        private readonly string mailFrom = string.Empty;

        public CloudMailService(IConfiguration configuration)
        {
            mailTo = configuration["mailSetting:mailToAdress"];
            mailFrom = configuration["mailSetting:mailFromAdress"];
        }

        public void Send(string subject, string message)
        {
            Console.WriteLine($"Mail from {mailFrom} to {mailTo} , "
                + $"with {nameof(LocalMailService)}");
            Console.WriteLine($"Subject {subject}");
            Console.WriteLine($"Message {message}");
        }
    }
}
