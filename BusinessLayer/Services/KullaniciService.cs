using AutoMapper;
using BusinessLayer.DTOs.Kullanici;
using BusinessLayer.Interfaces;
using EntiityLayer.Models;
using EntiityLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class KullaniciService : IKullaniciService
    {


        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public KullaniciService(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<KullaniciDTO> AddAsync(CreateKullaniciDTO entity, CancellationToken cancellationToken = default)
        {
            var kullanici = _mapper.Map<AppUser>(entity);
            await _userRepository.AddAsync(kullanici, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return _mapper.Map<KullaniciDTO>(kullanici);
        }

        public async Task<List<KullaniciDTO>> GetAllAsync(CancellationToken cancellationToken)
        {
            var kullaniciEntities = await _userRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<List<KullaniciDTO>>(kullaniciEntities);

        }

        public async Task<KullaniciDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var kullanici = await _userRepository.GetByIdAsync(id, cancellationToken);
            if (kullanici == null)
            {
                throw new Exception($"{id}:Aranan Kullanıcı bulunamadı");
            }
            return _mapper.Map<KullaniciDTO>(kullanici);

        }

        public async Task<KullaniciLoginDTO> login(string email, string password, CancellationToken cancellationToken = default)
        {
            var user = await _userRepository.GetWhere(x => x.Email == email&& x.PasswordHash == password, cancellationToken);
            if (user == null)
            {
                throw new Exception($"{email}:Aranan Kullanıcı bulunamadı");
            }
            if(user.PasswordHash != password)
            {
                throw new Exception($"{email}:Kullanıcı adı veya şifre hatalı");
            }
            return _mapper.Map<KullaniciLoginDTO>(user);
        }

        public async Task Remove(Guid id, CancellationToken cancellationToken = default)
        {
            var kullanici = await _userRepository.GetByIdAsync(id, cancellationToken);
            if (kullanici == null)
            {
                throw new Exception($"{id}:Silinecek Kullanıcı bulunamadı");
            }
            await _userRepository.RemoveAsync(kullanici);
            await _unitOfWork.SaveChangesAsync(cancellationToken);  
        }

        public async Task UpdateAsync(Guid id, UpdateKullaniciDTO entity, CancellationToken cancellationToken = default)
        {
            var kullanici = await _userRepository.GetByIdAsync(id, cancellationToken);
            if (kullanici == null)
            {
                throw new Exception($"{id}:Güncellenecek Kullanıcı bulunamadı");
            }
            var kullaniciEntity = _mapper.Map(entity,kullanici);
            await _userRepository.UpdateAsync(kullaniciEntity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

        }
    }
}
