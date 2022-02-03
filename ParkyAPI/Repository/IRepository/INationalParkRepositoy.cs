using ParkyAPI.Model;
using System.Collections.Generic;

namespace ParkyAPI.Repository.IRepository
{
    public interface INationalParkRepositoy
    {
        ICollection<NationalPark> GetNationalParks();

        NationalPark GetNationalPark(int nationalParkId);
        bool NationalParkExists(string name);
        bool NationalParkExists(int id);
        bool CreateNationalPark(NationalPark nationalPark);
        bool UpdateNationalPark(NationalPark nationalPark);
        bool DeteleNationalPark(NationalPark nationalPark);
        bool Save();


    }
}
