using BusinessLayer.DTOs.Dersler;
using BusinessLayer.DTOs.Kullanici;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IKullaniciService
    {

        Task<KullaniciDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<KullaniciDTO> AddAsync(CreateKullaniciDTO entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(Guid id, UpdateKullaniciDTO entity, CancellationToken cancellationToken = default);
        Task Remove(Guid id, CancellationToken cancellationToken = default);
        Task<List<KullaniciDTO>> GetAllAsync(CancellationToken cancellationToken);
        Task <KullaniciLoginDTO> login(string email, string password, CancellationToken cancellationToken = default);
    }
}
