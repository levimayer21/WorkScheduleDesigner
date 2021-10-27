using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Beosztasok
{
    public class List
    {
        public class Query : IRequest<Result<List<Beosztas>>> {}

        public class Handler : IRequestHandler<Query, Result<List<Beosztas>>>
        {
            private readonly DataContext _context;

            private readonly ILogger<List> _logger;

            public Handler (DataContext context, ILogger<List> logger)
            {
                _context = context;
                _logger = logger;
            }

            public async Task<Result<List<Beosztas>>> Handle(Query request, CancellationToken cancellationToken)
            {
                return Result<List<Beosztas>>.Success(await _context.Beosztasok.Include(x => x.Csoport).ToListAsync(cancellationToken));
            }
        }
    }
}