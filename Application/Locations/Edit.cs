using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Locations
{
    public class Edit
    {
        public class Command : IRequest
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
            public float? Longitude { get; set; }
            public float? Latitude { get; set; }
            public int? CityId { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Name).NotEmpty().MaximumLength(20);
                RuleFor(x => x.Address).NotEmpty().MaximumLength(50);
                RuleFor(x => x.Longitude).NotEmpty();
                RuleFor(x => x.Latitude).NotEmpty();
                RuleFor(x => x.CityId).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var location = await _context.Locations.FindAsync(request.Id);

                if (location == null)
                    throw new RestException(HttpStatusCode.NotFound, new { location = "Could not find location" });


                location.Name = request.Name ?? location.Name;
                location.Address = request.Address ?? location.Address;
                location.Longitude = request.Longitude ?? location.Longitude;
                location.Name = request.Name ?? location.Name;
                location.CityId = request.CityId ?? location.CityId;

                var result = await _context.SaveChangesAsync() > 0;

                if (result) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}