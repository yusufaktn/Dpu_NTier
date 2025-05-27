using AutoMapper;
using BusinessLayer.DTOs.Fakulte;
using BusinessLayer.Interfaces;
using EntiityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class FakulteService : IFakulteService
    {
        private readonly IFakulteRepository _fakulteRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public FakulteService(IFakulteRepository fakulteRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _fakulteRepository = fakulteRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<FakulteDTO> AddAsync(CreateFakulteDTO entity, CancellationToken cancellationToken = default)
        {
            var fakulte = _mapper.Map<Fakulte>(entity);
            await _fakulteRepository.AddAsync(fakulte, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return _mapper.Map<FakulteDTO>(fakulte);
        }

        public async Task<List<FakulteDTO>> GetAllAsync(CancellationToken cancellationToken)
        {
          var fakulte=  await _fakulteRepository.GetAllAsync(cancellationToken);
           return _mapper.Map<List<FakulteDTO>>(fakulte);
        }

        public async Task<FakulteDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var fakulte = await _fakulteRepository.GetByIdAsync(id, cancellationToken);
            if (fakulte == null)
            {
                throw new Exception("Fakulte bulunamadı");
            }
            return _mapper.Map<FakulteDTO>(fakulte);
        }

        public async Task<List<FakulteDTO>> GetFakulteByUniversiteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var fakulte = await _fakulteRepository.GetWhereList(f => f.UniversiteID == id, cancellationToken);
            if (fakulte == null)
            {
                throw new Exception("Fakulte bulunamadı");
            }
            return _mapper.Map<List<FakulteDTO>>(fakulte);

        }

        public async Task Remove(Guid id, CancellationToken cancellationToken = default)
        {
            var fakulte = await _fakulteRepository.GetByIdAsync(id, cancellationToken);
            if (fakulte == null)
            {
                throw new Exception(" Silinecek Fakulte bulunamadı");
            }
            await _fakulteRepository.RemoveAsync(fakulte);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

        }

        public async Task UpdateAsync(Guid id, UpdateFakulteDTO entity, CancellationToken cancellationToken = default)
        {
            
            var find_fakulte = await _fakulteRepository.GetByIdAsync(id, cancellationToken);
            if(find_fakulte == null)
            {
                throw new Exception("Güncellenecek Fakulte bulunamadı");
            }
            var fakulte = _mapper.Map(entity,find_fakulte);
            await _fakulteRepository.UpdateAsync(fakulte, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);


        }
    }
}
