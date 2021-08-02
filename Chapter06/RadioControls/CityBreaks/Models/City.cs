namespace CityBreaks.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public string CountryName { get; set; }
        public Country Country { get; set; }
    }
}
