using Microsoft.EntityFrameworkCore;

namespace AdOut.Identity.Model.Interfaces.Context
{
    public interface IDatabaseSeeder
    {
        void Seed(ModelBuilder builder);
    }
}
