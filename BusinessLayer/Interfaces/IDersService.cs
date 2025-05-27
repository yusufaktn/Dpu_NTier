using BusinessLayer.DTOs.Dersler;
using EntiityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IDersService
    {
        Task<DersDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task <DersDTO>AddAsync(CreateDersDTO entity, CancellationToken cancellationToken = default);
        Task  UpdateAsync(Guid id,UpdateDersDTO entity,CancellationToken cancellationToken=default);
        Task Remove(Guid id, CancellationToken cancellationToken = default);
        Task<List<DersDTO>> GetAllAsync(CancellationToken cancellationToken);



    }
}
