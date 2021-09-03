namespace CityBreaks.Services;
public class LifetimeDemoService
{

    public LifetimeDemoService()
    {
        Value = Guid.NewGuid();
          
    }
    public Guid Value { get; }

}
