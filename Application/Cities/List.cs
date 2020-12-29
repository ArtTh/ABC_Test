using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Cities
{
    public class List
    {
        public class Query : IRequest<List<CityDTO>> { }

        public class Handler : IRequestHandler<Query, List<CityDTO>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<List<CityDTO>> Handle(Query request, CancellationToken cancellationToken)
            {
                var cities = await _context.Cities.ToListAsync();

                var result = _mapper.Map<IList<City>, List<CityDTO>>(cities);

                return result;
            }
        }
    }
}