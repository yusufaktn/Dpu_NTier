using AutoMapper;
using BusinessLayer.DTOs.Odalar;
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
    public class OdaService : IOdaService
    {
        private readonly IOdaRepository _odaRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OdaService(IOdaRepository odaRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _odaRepository = odaRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<OdaDTO> AddAsync(CreateOdaDTO entity, CancellationToken cancellationToken = default)
        {
            var oda= _mapper.Map<Oda>(entity);
           await _odaRepository.AddAsync(oda, cancellationToken);
            return _mapper.Map<OdaDTO>(oda);
        }

        public async Task<List<OdaDTO>> GetAllAsync(CancellationToken cancellationToken)
        {
           var odalarEntities =await _odaRepository.GetAllAsync(cancellationToken);
           return _mapper.Map<List<OdaDTO>>(odalarEntities);
        }

        public async Task<OdaDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var oda = await _odaRepository.GetByIdAsync(id, cancellationToken);
            if (oda == null)
            {
                throw new Exception($"{id}:Aranan oda bulunamadı");
            }
            return _mapper.Map<OdaDTO>(oda);
        }

        public async Task Remove(Guid id, CancellationToken cancellationToken = default)
        {
            var  oda = await _odaRepository.GetByIdAsync(id, cancellationToken);
            if (oda == null)
            {
                throw new Exception($"{id}:Aranan oda bulunamadı");
            }
            await _odaRepository.RemoveAsync(oda);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Guid id, UpdateOdaDTO entity, CancellationToken cancellationToken = default)
        {
            var oda = await _odaRepository.GetByIdAsync(id, cancellationToken);
            if (oda == null)
            {
                throw new Exception($"{id}:Güncellenecek oda bulunamadı");
            }
            var odaentity = _mapper.Map(entity, oda);
            await _odaRepository.UpdateAsync(odaentity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
