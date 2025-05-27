using BusinessLayer.DTOs.Dersler;
using BusinessLayer.DTOs.Mesaj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IMesajService
    {
        Task<MesajDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<MesajDTO> AddAsync(CreateMesajDTO entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(Guid id, UpdateMesajDTO entity, CancellationToken cancellationToken = default);
        Task Remove(Guid id, CancellationToken cancellationToken = default);
        Task<List<MesajDTO>> GetAllAsync(CancellationToken cancellationToken);


    }
}
