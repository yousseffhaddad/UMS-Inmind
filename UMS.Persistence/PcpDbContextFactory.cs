using Microsoft.EntityFrameworkCore;
using PCP.Persistence.Infrastructure;
using UMS.Persistence;

namespace PCP.Persistence
{
    public class PcpDbContextFactory 
        : DesignTimeDbContextFactoryBase<umsContext>
    {
        protected override umsContext CreateNewInstance(DbContextOptions<umsContext> options)
        {
            return new umsContext(options);
        }
    }
}
