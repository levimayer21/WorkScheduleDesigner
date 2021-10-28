using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Beosztasok
{
    public class Details
    {
        public class Query : IRequest<Result<Beosztas>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<Beosztas>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Beosztas>> Handle(Query request, CancellationToken cancellationToken)
            {
                var beosztas = await _context.Beosztasok.Include(x => x.Csoport).FirstOrDefaultAsync(x => x.Id == request.Id);

                if (beosztas == null)
                {
                    return Result<Beosztas>.Failure("Failed to fetch event");
                }

                return Result<Beosztas>.Success(beosztas);
            }
        }
    }
}