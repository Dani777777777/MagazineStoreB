using MagazineStoreB.DL.DB;
using MagazineStoreB.DL.Interfaces;
using MagazineStoreB.Models.DTO;

namespace MagazineStoreB.DL.Repositories
{
    //internal class MagazineStaticRepository : IMagazineRepository
    //{
    //    public List<MMagazine> GetMagazine()
    //    {
    //        return StaticData.Magazine;
    //    }

    //    public void AddMagazine(Magazine magazine)
    //    {
    //        StaticData.Magazine.Add(magazine);
    //    }
    //    public void DeleteMagazine(int id)
    //    {
    //        if (id <= 0) return;

    //        var magazine = GetMagazinesById(id);

    //        if (magazine != null)
    //        {
    //            StaticData.Magazine.Remove(magazine);
    //        }
    //    }
    //    public Magazine? GetMagazinesById(int id)
    //    {
    //        if (id <= 0) return null;

    //        return StaticData.Magazines
    //            .FirstOrDefault(x => x.Id == id);
    //    }
    //}
}
