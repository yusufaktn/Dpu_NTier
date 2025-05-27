using DataAccessLayer.Context;
using DataAccessLayer.Repositories;
using EntiityLayer.Models;

internal class OgretmenRepository : GenericRepository<Ogretmen>,IOgretmenRepository
{
    public OgretmenRepository(ApplicationDbContext context) : base(context)
    {
    }
}


