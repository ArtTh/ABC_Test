using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Locations
{
    public class Details
    {
        public class Query : IRequest<LocationDTO>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, LocationDTO>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<LocationDTO> Handle(Query request, CancellationToken cancellationToken)
            {
                var location = await _context.Locations.FindAsync(request.Id);

                if (location == null)
                    throw new RestException(HttpStatusCode.NotFound, new { location = "Could not find location" });

                var result = _mapper.Map<Location, LocationDTO>(location);

                return result;
            }
        }
    }
}