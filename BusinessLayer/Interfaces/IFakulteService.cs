using BusinessLayer.DTOs.Fakulte;
using BusinessLayer.DTOs.Kullanici;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IFakulteService
    {
        Task<FakulteDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<FakulteDTO> AddAsync(CreateFakulteDTO entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(Guid id, UpdateFakulteDTO entity, CancellationToken cancellationToken = default);
        Task Remove(Guid id, CancellationToken cancellationToken = default);
        Task<List<FakulteDTO>> GetAllAsync(CancellationToken cancellationToken);
        Task<List<FakulteDTO>> GetFakulteByUniversiteAsync(Guid id, CancellationToken cancellationToken = default);


    }
}
