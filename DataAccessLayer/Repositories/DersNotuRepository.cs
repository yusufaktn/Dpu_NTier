using DataAccessLayer.Context;
using DataAccessLayer.Repositories;
using EntiityLayer.Models;

internal class DersNotuRepository : GenericRepository<DersNotu>,IDersNotuRepository
{
    public DersNotuRepository(ApplicationDbContext context) : base(context)
    {
    }
}




