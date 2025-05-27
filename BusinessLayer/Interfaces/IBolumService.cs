using BusinessLayer.DTOs.Bolum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IBolumService
    {
        Task<BolumDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<BolumDTO> AddAsync(CreateBolumDTO entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(Guid id, UpdateBolumDTO entity, CancellationToken cancellationToken = default);
        Task Remove(Guid id, CancellationToken cancellationToken = default);
        Task<List<BolumDTO>> GetAllAsync(CancellationToken cancellationToken);
        Task<List<BolumDTO>> GetBolumByFakulteId(Guid fakulteId, CancellationToken cancellationToken = default);
    }
}
