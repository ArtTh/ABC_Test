using System.Net;
using System.Threading;
using Application.Errors;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Cities
{
    public class Details
    {
        public class Query : IRequest<CityDTO>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, CityDTO>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async System.Threading.Tasks.Task<CityDTO> Handle(Query request, CancellationToken cancellationToken)
            {
                var city = await _context.Cities.FindAsync(request.Id);

                if (city == null)
                    throw new RestException(
                        HttpStatusCode.NotFound, new { city = "Could not find location" });

                var result = _mapper.Map<City, CityDTO>(city);

                return result;
            }
        }
    }
}