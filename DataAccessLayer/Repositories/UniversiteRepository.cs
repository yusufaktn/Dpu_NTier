using DataAccessLayer.Context;
using DataAccessLayer.Repositories;
using EntiityLayer.Models;

internal class UniversiteRepository : GenericRepository<Universite>,IUniversiteRepository
{
    public UniversiteRepository(ApplicationDbContext context) : base(context)
    {
    }
}


