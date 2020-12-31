using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Locations
{
    public class Details
    {
        public class Query : IRequest<LocationDetailDTO>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, LocationDetailDTO>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<LocationDetailDTO> Handle(Query request, CancellationToken cancellationToken)
            {
                var location = await _context.Locations.Include(x => x.City).FirstOrDefaultAsync(x => x.Id == request.Id);

                if (location == null)
                    throw new RestException(HttpStatusCode.NotFound, new { location = "Could not find location" });

                var result = _mapper.Map<Location, LocationDetailDTO>(location);

                return result;
            }
        }
    }
}