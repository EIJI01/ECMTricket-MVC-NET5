using ECMTricket.Data.Base;
using ECMTricket.Models;

namespace ECMTricket.Data.Services
{
    public class ProducerService : EntityBaseRepository<Producer>, IProducerService
    {
        public ProducerService(AppDbContext context) : base(context) { }
    }
}
