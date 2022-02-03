using Microsoft.EntityFrameworkCore;
using ParkyAPI.Data;
using ParkyAPI.Model;
using ParkyAPI.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace ParkyAPI.Repository
{
    public class TrailRepositoy : ITrailRepositoy
    {
        private readonly ApplicationDbContext _db;
        public TrailRepositoy(ApplicationDbContext db)
        {
            _db = db;
        }


        public bool CreateTrail(Trail trail)
        {
            _db.Trails.Add(trail);
           return Save();
        }

        public bool DeteleTrail(Trail trail)
        {
            _db.Trails.Remove(trail);
            return Save();
        }

        public Trail GetTrail(int trailId)
        {
            return _db.Trails.Include(c => c.NationalPark).FirstOrDefault(t => t.Id == trailId);
        }

        public ICollection<Trail> GetTrails()
        {
            return _db.Trails.Include(c => c.NationalPark).OrderBy(t=>t.Name).ToList();
        }

        public bool TrailExists(string name)
        {
            var value = _db.Trails.Any(
                a=>a.Name.ToLower().Trim() == name.ToLower().Trim());
            return value;
        }

        public bool TrailExists(int id)
        {
            return _db.Trails.Any(a=>a.Id == id);
        }

        public bool Save()
        {
            return _db.SaveChanges() >=0 ? true : false;
        }

        public bool UpdateTrail(Trail trail)
        {
            _db.Trails.Update(trail);
            return Save();
        }

        public ICollection<Trail> GetTrailsInNationalPark(int npId)
        {
            return _db.Trails.Include(c => c.NationalPark).Where(c=>c.NationalParkId==npId).ToList();
        }
    }
}
