using AutoMapper;
using RealEstate.Common.Contracts.PropertyTrace.Request;
using RealEstate.Core.Contracts;
using RealEstate.Core.Entities;

public class CreatePropertyTraceHandler
{
    private readonly IPropertyTraceRepository _repository;
    private readonly IMapper _mapper;

    public CreatePropertyTraceHandler(IPropertyTraceRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreatePropertyTraceRequest request)
    {
        var entity = _mapper.Map<PropertyTraceEntity>(request);
        return await _repository.CreateAsync(entity);
    }
}
