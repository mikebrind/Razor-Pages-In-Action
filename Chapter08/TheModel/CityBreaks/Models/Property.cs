namespace CityBreaks.Models
{
    public class Property
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public int MaxNumberOfGuests { get; set; }
        public decimal DayRate { get; set; }
        public bool SmokingPermitted { get; set; }
        public DateTime AvailableFrom { get; set; }
    }
}