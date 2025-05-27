using DataAccessLayer.Context;
using EntiityLayer.Models;
using EntiityLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    internal class OdaRepository:GenericRepository<Oda>,IOdaRepository
    {
        public OdaRepository(ApplicationDbContext context) : base(context)
        {
        }

    }
}
