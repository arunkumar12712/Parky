using ParkyAPI.Model;
using System.Collections.Generic;

namespace ParkyAPI.Repository.IRepository
{
    public interface ITrailRepositoy
    {
        ICollection<Trail> GetTrails();
        ICollection<Trail> GetTrailsInNationalPark(int npId);
        Trail GetTrail(int trailId);
        bool TrailExists(string name);
        bool TrailExists(int id);
        bool CreateTrail(Trail trail);
        bool UpdateTrail(Trail trail);
        bool DeteleTrail(Trail trail);
        bool Save();


    }
}
