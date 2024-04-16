using ECMTricket.Data.Base;
using ECMTricket.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

namespace ECMTricket.Data.Services
{
    public class ActorService : EntityBaseRepository<Actor>, IActorsService
    {
        public ActorService(AppDbContext context) : base(context) { }
    }
}
