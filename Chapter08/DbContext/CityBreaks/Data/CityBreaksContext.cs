
using Microsoft.EntityFrameworkCore;

namespace CityBreaks.Data;
public class CityBreaksContext : DbContext
{
    public CityBreaksContext(DbContextOptions options) : base(options)
    {

    }
}