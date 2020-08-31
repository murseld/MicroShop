using System.Threading.Tasks;

namespace MicroShop.Services.Basket.Data.Mongo
{
    public interface IDatabaseSeeder
    {
         Task SeedAsync();
    }
}