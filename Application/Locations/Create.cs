using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Locations
{
    public class Create
    {
        public class Command : IRequest
        {
            public string Name { get; set; }
            public string Address { get; set; }
            public double Longitude { get; set; }
            public double Latitude { get; set; }
            public int CityId { get; set; }
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
                var location = new Location
                {
                    Name = request.Name,
                    Address = request.Address,
                    Longitude = request.Longitude,
                    Latitude = request.Latitude,
                    CityId = request.CityId
                };

                _context.Locations.Add(location);
                var result = await _context.SaveChangesAsync() > 0;

                if (result) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}