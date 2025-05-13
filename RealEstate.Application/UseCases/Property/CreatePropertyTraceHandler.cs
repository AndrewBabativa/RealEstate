using AutoMapper;
using RealEstate.Application.DTOs.PropertyTrace;
using RealEstate.Application.Interfaces.Property;
using RealEstate.Core.Contracts;
using RealEstate.Core.Entities;

namespace RealEstate.Application.UseCases.Property
{
    public class CreatePropertyTraceHandler : ICreatePropertyTraceHandler
    {
        private readonly IPropertyTraceRepository _repository;
        private readonly IMapper _mapper;

        public CreatePropertyTraceHandler(IPropertyTraceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreatePropertyTraceDto dto)
        {
            var entity = _mapper.Map<PropertyTraceEntity>(dto);
            return await _repository.CreateAsync(entity);
        }
    }
}
