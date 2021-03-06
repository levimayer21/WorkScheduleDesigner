using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Beosztasok
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Beosztas Beosztas { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                request.Beosztas.Munkaido = TimeSpan.Zero;

                request.Beosztas.Letrehozva = DateTime.Now;

                request.Beosztas.Modositva = DateTime.Now;

                _context.Beosztasok.Add(request.Beosztas);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result)
                {
                    return Result<Unit>.Failure("Failed to create event");
                }

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}