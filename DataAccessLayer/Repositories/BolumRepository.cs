using DataAccessLayer.Context;
using DataAccessLayer.Repositories;
using EntiityLayer.Models;

internal class BolumRepository : GenericRepository<Bolum>, IBolumRepository
{
    public BolumRepository(ApplicationDbContext context) : base(context)
    {
    }
}

