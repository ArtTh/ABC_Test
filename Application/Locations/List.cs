using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Locations
{
    public class List
    {
        public class Query : IRequest<List<LocationDTO>> { }

        public class Handler : IRequestHandler<Query, List<LocationDTO>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<List<LocationDTO>> Handle(Query request, CancellationToken cancellationToken)
            {
                var locations = await _context.Locations.Include(x => x.City).ToListAsync();

                var result = _mapper.Map<IList<Location>, List<LocationDTO>>(locations);

                return result;
            }
        }
    }
}