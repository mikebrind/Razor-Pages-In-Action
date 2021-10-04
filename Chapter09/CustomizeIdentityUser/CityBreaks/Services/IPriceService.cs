namespace CityBreaks.Services
{
    public interface IPriceService
    {
        string GetLocation();
        double CalculatePrice();
    }
}
