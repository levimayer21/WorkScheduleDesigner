using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Csoportok
{
    public class Details
    {
        public class Query : IRequest<Result<Csoport>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<Csoport>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Csoport>> Handle(Query request, CancellationToken cancellationToken)
            {
                var csoport = await _context.Csoportok.FirstOrDefaultAsync(x => x.Id == request.Id,cancellationToken);

                if (csoport == null)
                {
                    return Result<Csoport>.Failure("Failed to fetch the group");
                }

                return Result<Csoport>.Success(csoport);
            }
        }
    }
}