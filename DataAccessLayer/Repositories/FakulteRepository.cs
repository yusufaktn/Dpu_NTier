using DataAccessLayer.Context;
using DataAccessLayer.Repositories;
using EntiityLayer.Models;

internal class FakulteRepository : GenericRepository<Fakulte>,IFakulteRepository
{
    public FakulteRepository(ApplicationDbContext context) : base(context)
    {
    }
}

