using AutoMapper;
using BusinessLayer.DTOs.Mesaj;
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
    public class MesajService : IMesajService
    {

        private readonly IOdaMesajlarıRepository _mesajRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MesajService(IOdaMesajlarıRepository mesajRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mesajRepository = mesajRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }



        public async Task<MesajDTO> AddAsync(CreateMesajDTO entity, CancellationToken cancellationToken = default)
        {
            var mesaj = _mapper.Map<OdaMesajları>(entity);
            await _mesajRepository.AddAsync(mesaj, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return _mapper.Map<MesajDTO>(mesaj);


        }

        public async Task<List<MesajDTO>> GetAllAsync(CancellationToken cancellationToken)
        {
            var mesajlarEntities = await _mesajRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<List<MesajDTO>>(mesajlarEntities);
        }

        public async Task<MesajDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var mesaj = await _mesajRepository.GetByIdAsync(id, cancellationToken);
            if (mesaj == null)
            {
                throw new Exception($"{id}:Aranan mesaj bulunamadı");
            }

            return _mapper.Map<MesajDTO>(mesaj);


        }

        public async Task Remove(Guid id, CancellationToken cancellationToken = default)
        {
            var mesaj = await _mesajRepository.GetByIdAsync(id, cancellationToken);
            if (mesaj == null)
            {
                throw new Exception($"{id}:Silinecek mesaj bulunamadı");
            }
            await _mesajRepository.RemoveAsync(mesaj);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Guid id, UpdateMesajDTO entity, CancellationToken cancellationToken = default)
        {
            var mesaj = await  _mesajRepository.GetByIdAsync(id, cancellationToken);
            if (mesaj == null)
            {
                throw new Exception($"{id}:Güncellenecek mesaj bulunamadı");
            }
             var mesaj_entitiy=_mapper.Map(entity, mesaj);
            await _mesajRepository.UpdateAsync(mesaj_entitiy,cancellationToken);
            await  _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
