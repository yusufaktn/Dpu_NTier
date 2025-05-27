using AutoMapper;
using BusinessLayer.DTOs.Dersler;
using BusinessLayer.Interfaces;
using EntiityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class DerslerService : IDersService
    {
        private readonly IDersRepository _dersRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;   
        public DerslerService(IDersRepository dersRepository, IUnitOfWork unitOfWork,IMapper mapper)
        {
            _dersRepository = dersRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<DersDTO> AddAsync(CreateDersDTO entity, CancellationToken cancellationToken = default)
        {

            var ders = _mapper.Map<Dersler>(entity);
            await _dersRepository.AddAsync(ders, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return _mapper.Map<DersDTO>(ders);

        }


        public async Task<List<DersDTO>> GetAllAsync(CancellationToken cancellationToken)
        {
            var derslerEntities = await _dersRepository.GetAllAsync(cancellationToken);      
            return _mapper.Map<List<DersDTO>>(derslerEntities);
        }

        public async Task<DersDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var ders= await _dersRepository.GetByIdAsync(id, cancellationToken);
            if (ders == null)
            {
                throw new Exception($"{id}:Aranan ders bulunamadı");
            }
            return _mapper.Map<DersDTO>(ders);
        }

        public async Task Remove(Guid id, CancellationToken cancellationToken = default)
        {

            var dersler = await _dersRepository.GetByIdAsync(id,cancellationToken);
            if (dersler == null)
            {
                throw new Exception($"{id}:Silinecek Ders bulunamadı");
            }


            await _dersRepository.RemoveAsync(dersler);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Guid id,UpdateDersDTO entity , CancellationToken cancellationToken = default)
        {
            var updateDers = await _dersRepository.GetByIdAsync(id,cancellationToken);
            if (updateDers == null)
            {
                throw new Exception($"{id}: Güncellenecek ders bulunamadı");
            }
            var newDers=  _mapper.Map(entity, updateDers);
            await _dersRepository.UpdateAsync(newDers);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
