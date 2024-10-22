using AutoMapper;
using log4net;
using MediatR;
using RealEstate.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Application.UseCases.Property.Queries.GetAll
{
    public class GetAllQuery : IRequest<List<GetAllResponseDto>>
    {
    }
    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, List<GetAllResponseDto>>
    {
        public IGenericRepository<RealEstate.Domain.Entities.Property> _genericRepository;
        public IMapper _mapper;

        private static readonly ILog _logger = LogManager.GetLogger(typeof(GetAllQuery));
        public GetAllQueryHandler(IGenericRepository<RealEstate.Domain.Entities.Property> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }
        public async Task<List<GetAllResponseDto>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.Debug($"Get All Properties Start");
                var result = await _genericRepository.GetAllAsync();
                _logger.Debug($"Get All Properties End");
                return _mapper.Map<List<GetAllResponseDto>>(result);
            }
            catch (Exception ex) {
                _logger.Error($"Get all properties exception fired: Exception {ex}");
                throw new Exception();
            }
        }
    }
}
