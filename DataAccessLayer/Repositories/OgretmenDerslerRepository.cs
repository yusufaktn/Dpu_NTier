using DataAccessLayer.Context;
using DataAccessLayer.Repositories;
using EntiityLayer.Models;

internal class OgretmenDerslerRepository : GenericRepository<OgretmenDersler>,IOgretmenDerslerRepository
{
    public OgretmenDerslerRepository(ApplicationDbContext context) : base(context)
    {
    }
}


