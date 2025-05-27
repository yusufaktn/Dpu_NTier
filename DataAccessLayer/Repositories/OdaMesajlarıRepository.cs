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
    internal class OdaMesajlarıRepository:GenericRepository<OdaMesajları>, IOdaMesajlarıRepository
    {
        public OdaMesajlarıRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
    
}
