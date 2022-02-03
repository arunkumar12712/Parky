using ParkyAPI.Data;
using ParkyAPI.Model;
using ParkyAPI.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace ParkyAPI.Repository
{
    public class NationalParkRepositoy : INationalParkRepositoy
    {
        private readonly ApplicationDbContext _db;
        public NationalParkRepositoy(ApplicationDbContext db)
        {
            _db = db;
        }


        public bool CreateNationalPark(NationalPark nationalPark)
        {
            _db.NationalParks.Add(nationalPark);
           return Save();
        }

        public bool DeteleNationalPark(NationalPark nationalPark)
        {
            _db.NationalParks.Remove(nationalPark);
            return Save();
        }

        public NationalPark GetNationalPark(int nationalParkId)
        {
            return _db.NationalParks.FirstOrDefault(t => t.Id == nationalParkId);
        }

        public ICollection<NationalPark> GetNationalParks()
        {
            return _db.NationalParks.OrderBy(t=>t.Name).ToList();
        }

        public bool NationalParkExists(string name)
        {
            var value = _db.NationalParks.Any(
                a=>a.Name.ToLower().Trim() == name.ToLower().Trim());
            return value;
        }

        public bool NationalParkExists(int id)
        {
            return _db.NationalParks.Any(a=>a.Id == id);
        }

        public bool Save()
        {
            return _db.SaveChanges() >=0 ? true : false;
        }

        public bool UpdateNationalPark(NationalPark nationalPark)
        {
            _db.NationalParks.Update(nationalPark);
            return Save();
        }
    }
}
