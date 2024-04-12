using System.Collections.Generic;
using Web.Models;

namespace Web.Contracts
{
    public interface IActorRepository
    {
        List<Actor> GetActors();
        Actor GetActorById(int id);
        void AddActor(Actor actor);
        void UpdateActor(int id, Actor actor);
        void DeleteActor(int id);
    }
}
