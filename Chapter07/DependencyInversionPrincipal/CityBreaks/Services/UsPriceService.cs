namespace CityBreaks.Services
{
public class UsPriceService : IPriceService
{
    public string GetLocation() => "us";
    public double CalculatePrice()
    {
        throw new System.NotImplementedException();
    }
}
}
