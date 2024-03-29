using ECMTricket.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECMTricket.Data.Services
{
    public interface IActorsService
    {
        Task<IEnumerable<Actor>> GetAll();
        Actor GetById(int Id);
        Task Add(Actor actor);
        Actor Update(int id, Actor newActor);
        void Delete(int id);
    }
}
