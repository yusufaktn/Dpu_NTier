using AutoMapper;
using BusinessLayer.DTOs.Bolum;
using BusinessLayer.Interfaces;
using EntiityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class BolumService : IBolumService
    {
        private readonly IBolumRepository _bolumRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public BolumService(IBolumRepository bolumRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _bolumRepository = bolumRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<BolumDTO> AddAsync(CreateBolumDTO entity, CancellationToken cancellationToken = default)
        {
            var bolum = _mapper.Map<Bolum>(entity);
            await _bolumRepository.AddAsync(bolum, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return _mapper.Map<BolumDTO>(bolum);
        }

        public async Task<List<BolumDTO>> GetAllAsync(CancellationToken cancellationToken)
        {
            var bolumEntities = await _bolumRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<List<BolumDTO>>(bolumEntities);
        }

        public async Task<List<BolumDTO>> GetBolumByFakulteId(Guid fakulteId, CancellationToken cancellationToken = default)
        {
          
            var bolumEntities = await _bolumRepository.GetWhereList(x => x.FakulteID == fakulteId, cancellationToken);
            if (bolumEntities == null)
            {
                throw new Exception($"{fakulteId}:Aranan Fakülteye ait Bölüm bulunamadı");
            }
            return _mapper.Map<List<BolumDTO>>(bolumEntities);

        }

        public async Task<BolumDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var bolum = await _bolumRepository.GetByIdAsync(id, cancellationToken);
            if (bolum == null)
            {
                throw new Exception($"{id}:Aranan Bölüm bulunamadı");
            }

            return _mapper.Map<BolumDTO>(bolum);


        }

        public async Task Remove(Guid id, CancellationToken cancellationToken = default)
        {
            var bolum = await _bolumRepository.GetByIdAsync(id, cancellationToken);
            if (bolum == null)
            {
                throw new Exception($"{id}:Aranan Bölüm bulunamadı");
            }
            await _bolumRepository.RemoveAsync(bolum, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Guid id, UpdateBolumDTO entity, CancellationToken cancellationToken = default)
        {
            
            var existingBolum = await _bolumRepository.GetByIdAsync(id, cancellationToken);
            if (existingBolum == null)
            {
                throw new Exception($"{id}:Güncellenecek Bölüm bulunamadı");
            }
            var bolum = _mapper.Map(entity,existingBolum);
            await _bolumRepository.UpdateAsync(bolum, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

        }
    }
}
