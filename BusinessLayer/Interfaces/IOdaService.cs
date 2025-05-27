using BusinessLayer.DTOs.Mesaj;
using BusinessLayer.DTOs.Odalar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IOdaService
    {
        Task<OdaDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<OdaDTO> AddAsync(CreateOdaDTO entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(Guid id, UpdateOdaDTO entity, CancellationToken cancellationToken = default);
        Task Remove(Guid id, CancellationToken cancellationToken = default);
        Task<List<OdaDTO>> GetAllAsync(CancellationToken cancellationToken);
    }
}
