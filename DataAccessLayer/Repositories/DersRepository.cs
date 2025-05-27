using DataAccessLayer.Context;
using DataAccessLayer.Repositories;
using EntiityLayer.Models;

internal class DersRepository : GenericRepository<Dersler>,IDersRepository
{
    public DersRepository(ApplicationDbContext context) : base(context)
    {
    }
}



