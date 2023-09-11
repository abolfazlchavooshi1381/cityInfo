namespace CityInfo.API.Models
{
    public class CityInfoUser
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string City { get; set; }

        public CityInfoUser(int UserId, string UserName, string FirstName, string LastName, string City)
        {
            this.UserId = UserId;
            this.UserName = UserName;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.City = City;
        }
    }
}
